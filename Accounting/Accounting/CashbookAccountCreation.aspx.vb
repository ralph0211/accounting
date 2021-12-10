Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports CreditManager
Imports ErrorLogging

Partial Class Accounting_CashbookAccountCreation
    Inherits System.Web.UI.Page

    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            Using con = New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd = New SqlCommand("insert into CashbookAccounts (AccountName,AccountNo,AccountDesc,MainAccount) values (@AccountName,@AccountNo,@AccountDesc,@MainAccount)", con)
                    cmd.Parameters.AddWithValue("@AccountName", txtAccountName.Text)
                    cmd.Parameters.AddWithValue("@AccountNo", txtAccNumber.Text)
                    cmd.Parameters.AddWithValue("@AccountDesc", txtAccDesc.Text)
                    cmd.Parameters.AddWithValue("@MainAccount", cmbMainAccount.SelectedValue)
                    con.Open()
                    If cmd.ExecuteNonQuery Then
                        notify("Account created", "success")
                        loadAccounts()
                        txtAccDesc.Text = ""
                        txtAccNumber.Text = ""
                        txtAccountName.Text = ""
                        cmbMainAccount.ClearSelection()
                    Else
                        notify("Error creating account", "error")
                    End If
                    con.Close()
                End Using
            End Using
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- btnSave_Click()", ex.ToString)
        End Try
    End Sub

    Private Sub Accounting_CashbookAccountCreation_Load(sender As Object, e As EventArgs) Handles Me.Load
        Page.MaintainScrollPositionOnPostBack = True
        If Not IsPostBack Then
            loadAccounts()
            getMainAccounts(cmbMainAccount)
        End If
    End Sub

    Protected Sub loadAccounts()
        Try
            Using con = New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd = New SqlCommand("select ca.*,fac.MainAccount as [MAcc],fac.AccountName as [MainAccName] from CashbookAccounts ca left JOIN tbl_FinancialAccountsCreation fac ON ca.MainAccount=fac.MainAccount", con)
                    Dim dt As New DataTable
                    Using adp = New SqlDataAdapter(cmd)
                        adp.Fill(dt)
                    End Using
                    bindGrid(dt, grdAccounts)
                End Using
            End Using
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- loadAccounts()", ex.ToString)
        End Try
    End Sub

    Private Sub grdAccounts_RowCancelingEdit(sender As Object, e As GridViewCancelEditEventArgs) Handles grdAccounts.RowCancelingEdit
        grdAccounts.EditIndex = -1
        loadAccounts()
    End Sub

    Private Sub grdAccounts_RowDeleting(sender As Object, e As GridViewDeleteEventArgs) Handles grdAccounts.RowDeleting
        Try
            ViewState("accEditID") = DirectCast(grdAccounts.Rows(e.RowIndex).FindControl("txtGrdID"), TextBox).Text
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd = New SqlCommand("delete from [CashbookAccounts] where id='" & ViewState("accEditID") & "'", con)
                    If con.State = ConnectionState.Open Then
                        con.Close()
                    End If
                    con.Open()
                    If cmd.ExecuteNonQuery Then
                        notify("Successfully deleted", "success")
                    Else
                        notify("Error deleting", "error")
                    End If
                    con.Close()
                    loadAccounts()
                End Using
            End Using
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- grdAccounts_RowDeleting()", ex.ToString)
        End Try
    End Sub

    Private Sub grdAccounts_RowEditing(sender As Object, e As GridViewEditEventArgs) Handles grdAccounts.RowEditing
        Try
            ViewState("accEditID") = DirectCast(grdAccounts.Rows(e.NewEditIndex).FindControl("txtGrdID"), TextBox).Text
            grdAccounts.EditIndex = e.NewEditIndex
            loadAccounts()
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- grdAccounts_RowEditing()", ex.ToString)
        End Try
    End Sub

    Private Sub grdAccounts_RowUpdating(sender As Object, e As GridViewUpdateEventArgs) Handles grdAccounts.RowUpdating
        Try
            If Trim(ViewState("accEditID")) = "" Or IsDBNull(ViewState("accEditID")) Then
                notify("No record selected for update", "error")
                Exit Sub
            End If
            Dim tAccName As TextBox = DirectCast(grdAccounts.Rows(e.RowIndex).FindControl("txtGrdAccountName"), TextBox)
            Dim tAccNo As TextBox = DirectCast(grdAccounts.Rows(e.RowIndex).FindControl("txtGrdMainAccount"), TextBox)
            Dim tAccDesc As TextBox = DirectCast(grdAccounts.Rows(e.RowIndex).FindControl("txtGrdDescription"), TextBox)
            Dim cmbAcc As DropDownList = DirectCast(grdAccounts.Rows(e.RowIndex).FindControl("cmbGrdMainAccount"), DropDownList)

            If Trim(tAccName.Text) = "" Then
                notify("Enter the account name", "error")
            ElseIf Trim(tAccNo.Text) = "" Then
                notify("Enter the account number", "error")
            ElseIf Trim(cmbAcc.SelectedValue) = "" Then
                notify("Select the main account", "error")
            Else
                Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                    Using cmd = New SqlCommand("update [CashbookAccounts] set AccountName=@AccountName,AccountNo=@AccountNo,AccountDesc=@AccountDesc,MainAccount=@MainAccount where id='" & ViewState("accEditID") & "'", con)
                        cmd.Parameters.AddWithValue("@AccountName", tAccName.Text)
                        cmd.Parameters.AddWithValue("@AccountNo", tAccNo.Text)
                        cmd.Parameters.AddWithValue("@AccountDesc", tAccDesc.Text)
                        cmd.Parameters.AddWithValue("@MainAccount", cmbAcc.SelectedValue)
                        con.Open()
                        If cmd.ExecuteNonQuery Then
                            notify("Successfully updated", "success")
                        Else
                            notify("Error updating value", "error")
                        End If
                        con.Close()
                        grdAccounts.EditIndex = -1
                        loadAccounts()
                    End Using
                End Using
            End If
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- grdCategories_RowUpdating()", ex.ToString)
        End Try
    End Sub

    Protected Sub getMainAccounts(cmbMA As DropDownList)
        Try
            Using con = New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd = New SqlCommand("select mainaccount,AccountName+' - '+MainAccount as AccountName from [tbl_FinancialAccountsCreation]", con)
                    Dim dt As New DataTable
                    Using adp = New SqlDataAdapter(cmd)
                        adp.Fill(dt)
                    End Using
                    loadCombo(dt, cmbMA, "AccountName", "MainAccount")
                End Using
            End Using
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- getMainAccounts()", ex.ToString)
        End Try
    End Sub

    Private Sub grdAccounts_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles grdAccounts.RowDataBound
        Try
            If (e.Row.RowType = DataControlRowType.DataRow And grdAccounts.EditIndex = e.Row.RowIndex) Then
                Dim cmbAcc = DirectCast(e.Row.FindControl("cmbGrdMainAccount"), DropDownList)
                getMainAccounts(cmbAcc)
                Try
                    cmbAcc.SelectedValue = DirectCast(e.Row.FindControl("txtGrdMainAccountNo"), TextBox).Text
                Catch ex As Exception
                    cmbAcc.ClearSelection()
                End Try
            End If
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- grdAccounts_RowDataBound()", ex.ToString)
        End Try
    End Sub
End Class