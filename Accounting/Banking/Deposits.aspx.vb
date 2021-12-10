Imports System.Data
Imports System.Data.SqlClient
Imports CreditManager
Imports ErrorLogging
Partial Class Banking_Deposits
    Inherits System.Web.UI.Page
    Dim urlPermission As String = "..\PermissionDenied.aspx"
    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            Dim bal As Double = Convert.ToDouble(lblBankBalance.Text)
            Dim cmp As double=Convert.ToDouble(txtAmount.Text)
            If cmp>=bal Then
            txtAmount.Text=""
            txtAmount.Focus()
                msgbox("The amount  must be less than or equal to Bank Balance")
                Exit Sub
            End If
        Catch ex As Exception
             msgbox("The amount  must be less than or equal to Bank Balance")
                Exit Sub
        End Try
         
        Try
            If Trim(cmbBankAccount.SelectedValue) = "" Then
                notify("Select bank account", "error")
                cmbBankAccount.Focus()
            ElseIf Trim(cmbBranchAccount.SelectedValue) = "" Then
                notify("Select the branch account", "error")
                cmbBranchAccount.Focus()
            ElseIf Not IsNumeric(toMoney(txtAmount.Text)) Or toMoney(txtAmount.Text) <= 0 Then
                notify("Enter numeric amount", "error")
                txtAmount.Focus()
            ElseIf Not IsDate(txtTrxnDate.Text) Then
                notify("Enter valid transaction date", "error")
                txtTrxnDate.Focus()
            Else
                If saveTransaction("Deposit", "", txtComment.Text, 0, txtAmount.Text, cmbBankAccount.SelectedValue, cmbBranchAccount.SelectedValue, "1", "", "", "", "", txtTrxnDate.Text) Then
                    notify("Transaction saved", "success")
                    cmbBankAccount.ClearSelection()
                    cmbBranchAccount.ClearSelection()
                    txtAmount.Text = ""
                    txtComment.Text = ""
                    txtTrxnDate.Text = ""
                Else
                    notify("Error saving transaction", "error")
                End If
            End If
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- btnSave_Click()", ex.ToString)
        End Try
    End Sub

    Protected Function getAccountBalance(accNo As String) As Double
        Try
            Using con As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd As New SqlCommand("select isnull(sum(debit-credit),0) as Bal from Accounts_Transactions where Account='" & accNo & "'", con)
                    Dim bal As Double = 0
                    con.Open()
                    bal = cmd.ExecuteScalar
                    con.Close()
                    Return bal
                End Using
            End Using
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- getAccountBalance()", ex.ToString)
            Return 0
        End Try
    End Function

    Protected Sub loadbANKAccounts(mainAcc As String, cmb As DropDownList)
        Try
            Using con As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd As New SqlCommand("select AccountName + ' | ' + convert(varchar,MainAccount) +'/'+ convert(varchar,SubAccount) as AccountName, convert(varchar,MainAccount) +'/'+ convert(varchar,SubAccount) as 'Accno' from tbl_FinancialAccountsCreation where convert(varchar,MainAccount)='" & mainAcc & "' and SubAccount<>1 and Branch ='" & Session("BRANCHCODE") & "'", con)
                    Dim dt As New DataTable
                    Using adp As New SqlDataAdapter(cmd)
                        adp.Fill(dt)
                    End Using
                    loadCombo(dt, cmb, "AccountName", "Accno")
                End Using
            End Using
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- loadAccounts()", ex.ToString)
        End Try
    End Sub
    Protected Sub loadbRANCHAccounts(mainAcc As String, cmb As DropDownList)
        Try
            Using con As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd As New SqlCommand("select AccountName + ' | ' + convert(varchar,MainAccount) +'/'+ convert(varchar,SubAccount) as AccountName, convert(varchar,MainAccount) +'/'+ convert(varchar,SubAccount) as 'Accno' from tbl_FinancialAccountsCreation where convert(varchar,MainAccount)='" & mainAcc & "' and SubAccount<>1 and Branch ='" & Session("BRANCHCODE") & "'", con)
                    Dim dt As New DataTable
                    Using adp As New SqlDataAdapter(cmd)
                        adp.Fill(dt)
                    End Using
                    loadCombo(dt, cmb, "AccountName", "Accno")
                End Using
            End Using
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- loadAccounts()", ex.ToString)
        End Try
    End Sub

    Private Sub Banking_CashAllocations_Load(sender As Object, e As EventArgs) Handles Me.Load
        Page.MaintainScrollPositionOnPostBack = True
        If Not IsPostBack Then
            If CashBoxActive() = False Then
                Response.Redirect(urlPermission)
            Else
                'load bank accounts
                loadbANKAccounts("212", cmbBankAccount)
                'load branch cash accounts
                loadbRANCHAccounts("211", cmbBranchAccount)
            End If
        End If
    End Sub
    Protected Sub cmbBankAccount_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbBankAccount.SelectedIndexChanged
        Try
            lblBankBalance.Text = getAccountBalance(cmbBankAccount.SelectedValue)
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- cmbBankAccount_SelectedIndexChanged()", ex.ToString)
        End Try
    End Sub
End Class