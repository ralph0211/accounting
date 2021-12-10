Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports CreditManager
Imports ErrorLogging

Partial Class Accounting_Budget
    Inherits System.Web.UI.Page

    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            If Trim(txtAmount.Text) = "" Or Not IsNumeric(toMoney(txtAmount.Text)) Then
                notify("Amount must be numeric", "error")
                txtAmount.Focus()
            ElseIf Trim(txtMonth.Text) = "" Then
                notify("Select month", "error")
                txtMonth.Focus()
            ElseIf cmbAccount.SelectedValue = "" Then
                notify("Select the account", "error")
                cmbAccount.Focus()
            Else
                Using con = New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                    Using cmd As New SqlCommand("insert into Budget (BudgetMonth,AccountNo,BudgetedAmt,SavedBy,SaveDate) values (@BudgetMonth,@AccountNo,@BudgetedAmt,@SavedBy,GETDATE())", con)
                        cmd.Parameters.AddWithValue("@BudgetMonth", txtMonth.Text)
                        cmd.Parameters.AddWithValue("@AccountNo", cmbAccount.SelectedValue)
                        cmd.Parameters.AddWithValue("@BudgetedAmt", toMoney(txtAmount.Text))
                        cmd.Parameters.AddWithValue("@SavedBy", Session("UserId"))
                        con.Open()
                        If cmd.ExecuteNonQuery Then
                            getBudgets()
                            notify("Saved successfully", "success")
                        Else
                            notify("Error saving budget", "error")
                        End If
                        con.Close()
                    End Using
                End Using
            End If
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- btnSave_Click()", ex.ToString)
        End Try
    End Sub

    Protected Sub loadAccounts()
        Try
            Using con = New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd = New SqlCommand("select AccountName + ' | ' + convert(varchar,MainAccount) as AccountName, convert(varchar,MainAccount) as 'Accno' from tbl_FinancialAccountsCreation union select accountName + ' | ' + accountNo as AccountName,accountNo AS Accno from cashbookaccounts union select accountName + ' | ' + accountNo as AccountName,accountNo AS Accno from CreditorAccounts union select accountName + ' | ' + accountNo as AccountName,accountNo AS Accno from DebtorAccounts order by 'AccountName'", con)
                    Dim ds As New DataSet
                    Using adp = New SqlDataAdapter(cmd)
                        adp.Fill(ds, "AccountsTypes")
                    End Using
                    loadCombo(ds.Tables(0), cmbAccount, "AccountName", "Accno")
                End Using
            End Using
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- loadAccounts()", ex.ToString)
        End Try
    End Sub

    Private Sub Accounting_Budget_Load(sender As Object, e As EventArgs) Handles Me.Load
        Page.MaintainScrollPositionOnPostBack = True
        If Not IsPostBack Then
            loadAccounts()
            getBudgets()
        End If
    End Sub

    Protected Sub getBudgets()
        Try
            Using con = New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd = New SqlCommand("select *,convert(varchar,StartDate,106) as StartDate1,convert(varchar,EndDate,106) as EndDate1 from Budget", con)
                    Dim dt As New DataTable
                    Using adp = New SqlDataAdapter(cmd)
                        adp.Fill(dt)
                    End Using
                    bindGrid(dt, grdBudget)
                End Using
            End Using
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- getBudgets()", ex.ToString)
        End Try
    End Sub

    Private Sub grdBudget_RowCancelingEdit(sender As Object, e As GridViewCancelEditEventArgs) Handles grdBudget.RowCancelingEdit
        grdBudget.EditIndex = -1
        getBudgets()
    End Sub

    Private Sub grdBudget_RowDeleting(sender As Object, e As GridViewDeleteEventArgs) Handles grdBudget.RowDeleting
        Try
            ViewState("budgetEditID") = DirectCast(grdBudget.Rows(e.RowIndex).FindControl("txtGrdID"), TextBox).Text
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd = New SqlCommand("delete from [Budget] where id='" & ViewState("budgetEditID") & "'", con)
                    con.Open()
                    If cmd.ExecuteNonQuery Then
                        notify("Successfully deleted", "success")
                    Else
                        notify("Error deleting", "error")
                    End If
                    con.Close()
                    getBudgets()
                End Using
            End Using
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- grdBudget_RowDeleting()", ex.ToString)
        End Try
    End Sub

    Private Sub grdBudget_RowEditing(sender As Object, e As GridViewEditEventArgs) Handles grdBudget.RowEditing
        Try
            ViewState("budgetEditID") = DirectCast(grdBudget.Rows(e.NewEditIndex).FindControl("txtGrdID"), TextBox).Text
            grdBudget.EditIndex = e.NewEditIndex
            getBudgets()
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- grdBudget_RowEditing()", ex.ToString)
        End Try
    End Sub

    Private Sub grdBudget_RowUpdating(sender As Object, e As GridViewUpdateEventArgs) Handles grdBudget.RowUpdating
        Try
            If Trim(ViewState("budgetEditID")) = "" Or IsDBNull(ViewState("budgetEditID")) Then
                CreditManager.notify("No record selected for update", "error")
                Exit Sub
            End If
            Dim dFrom As String = DirectCast(grdBudget.Rows(e.RowIndex).FindControl("txtGrdMonth"), TextBox).Text
            'Dim dTo As String = DirectCast(grdBudget.Rows(e.RowIndex).FindControl("txtGrdDateTo"), TextBox).Text
            Dim bAmt As String = DirectCast(grdBudget.Rows(e.RowIndex).FindControl("txtGrdBudgetedAmt"), TextBox).Text

            If Trim(dFrom) = "" Then
                notify("Select the month", "error")
            ElseIf Trim(bAmt) = "" Or Not IsNumeric(bAmt) Then
                notify("Enter numeric value for amount", "error")
            Else
                Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                    Using cmd = New SqlCommand("update [Budget] set [BudgetMonth]='" & dFrom & "',BudgetedAmt='" & toMoney(bAmt) & "' where id='" & ViewState("budgetEditID") & "'", con)
                        con.Open()
                        If cmd.ExecuteNonQuery Then
                            CreditManager.notify("Successfully updated", "success")
                        Else
                            CreditManager.notify("Error updating value", "error")
                        End If
                        con.Close()
                        grdBudget.EditIndex = -1
                        getBudgets()
                    End Using
                End Using
            End If
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- grdBudget_RowUpdating()", ex.ToString)
        End Try
    End Sub

End Class