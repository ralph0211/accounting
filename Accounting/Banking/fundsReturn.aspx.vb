Imports System.Data
Imports System.Data.SqlClient
Imports CreditManager
Imports ErrorLogging

Partial Class Banking_Withdrawals
    Inherits System.Web.UI.Page
    Dim urlPermission As String = "..\PermissionDenied.aspx"
    Private Sub Banking_Withdrawals_Load(sender As Object, e As EventArgs) Handles Me.Load
        Page.MaintainScrollPositionOnPostBack = True
        If Not IsPostBack Then
            If CashBoxActive() = False Then
                Response.Redirect(urlPermission)
            Else
                'load branch cash accounts
                loadAccounts("211", cmbBranchAccount)
                'load branch loan officers
                loadLoanOfficerAccounts(Session("BRANCHCODE"), cmbLoanOfficerAccount)
            End If
        End If
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
    Protected Sub loadAccounts(mainAcc As String, cmb As DropDownList)
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
    Protected Sub loadLoanOfficerAccounts(branch As String, cmb As DropDownList)
        Try
            Using con As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd As New SqlCommand("select FNAME + ' '+ LNAME + ' | ' + 'LO/'+ CONVERT(VARCHAR,USERID) as AccountName, 'LO/'+ CONVERT(VARCHAR,USERID) as AccNo from MASTER_USERS where USER_TYPE in ('4041','5049') AND USER_BRANCH='" & branch & "'", con)
                    Dim dt As New DataTable
                    Using adp As New SqlDataAdapter(cmd)
                        adp.Fill(dt)
                    End Using
                    loadCombo(dt, cmb, "AccountName", "AccNo")
                End Using
            End Using
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- loadLoanOfficerAccounts()", ex.ToString)
        End Try
    End Sub
    Protected Sub cmbBranchAccount_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbBranchAccount.SelectedIndexChanged
        Try
            lblBranchBalance.Text = getAccountBalance(cmbBranchAccount.SelectedValue)
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- cmbBranchAccount_SelectedIndexChanged()", ex.ToString)
        End Try
    End Sub
    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            If Trim(cmbBranchAccount.SelectedValue) = "" Then
                notify("Select branch account", "error")
                cmbBranchAccount.Focus()
            ElseIf Trim(cmbLoanOfficerAccount.SelectedValue) = "" Then
                notify("Insufficient Balance", "error")
                cmbLoanOfficerAccount.Focus()
            ElseIf Not IsNumeric(toMoney(txtAmount.Text)) Or toMoney(txtAmount.Text) <= 0 Then
                notify("Enter numeric amount", "error")
                txtAmount.Focus()
            ElseIf toMoney(LblLoanOfficerBal.Text) <= 0 Then
                notify("Insufficient Balance", "error")
                txtAmount.Focus()
            ElseIf Not IsDate(txtTrxnDate.Text) Then
                notify("Enter valid transaction date", "error")
                txtTrxnDate.Focus()
            Else
                If saveTransaction("Funds Return", "", txtComment.Text, txtAmount.Text, 0, cmbBranchAccount.SelectedValue, cmbLoanOfficerAccount.SelectedValue, "1", "", "", "", "", txtTrxnDate.Text) Then
                    notify("Transaction saved", "success")
                    cmbLoanOfficerAccount.ClearSelection()
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
    Protected Sub cmbLoanOfficerAccount_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbLoanOfficerAccount.SelectedIndexChanged
        Try
            Dim bal = getAccountBalance(cmbLoanOfficerAccount.SelectedValue)
            LblLoanOfficerBal.Text = bal
            txtAmount.Text = bal
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- mbLoanOfficerAccount_SelectedIndexChanged()", ex.ToString)
        End Try
    End Sub
End Class