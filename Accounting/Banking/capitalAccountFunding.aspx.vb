Imports System.Data
Imports System.Data.SqlClient
Imports CreditManager
Imports ErrorLogging

Partial Class Banking_Acc_Funding
    Inherits System.Web.UI.Page
    Dim urlPermission As String = "..\PermissionDenied.aspx"
    Private Sub Banking_Withdrawals_Load(sender As Object, e As EventArgs) Handles Me.Load
        Page.MaintainScrollPositionOnPostBack = True
        If Not IsPostBack Then
            If CashBoxActive() = False Then
                Response.Redirect(urlPermission)
            Else
                'load branch cash accounts
                loadAccounts("101", cmbBankAccount)
                'load branch loan officers
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
                Using cmd As New SqlCommand("select AccountName + ' | ' + convert(varchar,MainAccount) +'/'+ convert(varchar,SubAccount) as AccountName, convert(varchar,MainAccount) +'/'+ convert(varchar,SubAccount) as 'Accno' from tbl_FinancialAccountsCreation where convert(varchar,MainAccount)='" & mainAcc & "' and SubAccount<>1", con)
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

    Protected Sub cmbBranchAccount_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbBankAccount.SelectedIndexChanged
        Try
            lblBankBalance.Text = getAccountBalance(cmbBankAccount.SelectedValue)
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- cmbBranchAccount_SelectedIndexChanged()", ex.ToString)
        End Try
    End Sub
    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            If Trim(cmbBankAccount.SelectedValue) = "" Then
                notify("Select branch account", "error")
                cmbBankAccount.Focus()
            ElseIf txtAmount.Text = "" Then
                notify("Enter numeric amount", "error")
                txtAmount.Focus()
            ElseIf Not IsNumeric(toMoney(txtAmount.Text)) Or toMoney(txtAmount.Text) <= 0 Then
                notify("Enter numeric amount", "error")
                txtAmount.Focus()
            ElseIf Not IsDate(txtTrxnDate.Text) Then
                notify("Enter valid transaction date", "error")
                txtTrxnDate.Focus()
            Else
                If save_SINGLE_Transaction("Journal Entry", "New fund-" & cmbBankAccount.Text, txtComment.Text, txtAmount.Text, 0, cmbBankAccount.SelectedValue, "NEWFUND", cmbBankAccount.SelectedValue, "New fund-" & cmbBankAccount.Text, txtTrxnDate.Text) Then
                    notify("Transaction saved", "success")
                    cmbBankAccount.ClearSelection()
                    txtAmount.Text = ""
                    txtComment.Text = ""
                    txtTrxnDate.Text = ""
                    lblBankBalance.Text = ""
                Else
                    notify("Error saving transaction", "error")
                End If
            End If
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- btnSave_Click()", ex.ToString)
        End Try
    End Sub
    Private Function save_SINGLE_Transaction(category As String, reference As String, description As String, debit As Double, credit As Double, account As String, contra As String, other As String, batchRef As String, trxnDate As Date) As Boolean
        Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
            Using cmd As New SqlCommand("insert into Accounts_Transactions(Type, Category, TrxnDate, Account, Refrence, Description, Debit, Credit, ContraAccount,Status, Other, CaptureDate,BatchRef)values(@Type, @Category, @TrxnDate, @Account, @Refrence, @Description, @Debit, @Credit, @ContraAccount,1, @Other, GETDATE(),@BatchRef)", con)
                cmd.CommandType = CommandType.Text
                cmd.Parameters.AddWithValue("@Type", "System Entry")
                cmd.Parameters.AddWithValue("@Category", category)
                cmd.Parameters.AddWithValue("@Refrence", reference)
                cmd.Parameters.AddWithValue("@Description", description)
                cmd.Parameters.AddWithValue("@Debit", debit)
                cmd.Parameters.AddWithValue("@Credit", credit)
                cmd.Parameters.AddWithValue("@Account", account)
                cmd.Parameters.AddWithValue("@ContraAccount", contra)
                cmd.Parameters.AddWithValue("@Other", other)
                cmd.Parameters.AddWithValue("@BatchRef", batchRef)
                cmd.Parameters.AddWithValue("@TrxnDate", trxnDate)

                If con.State = ConnectionState.Open Then
                    con.Close()
                End If
                con.Open()
                If cmd.ExecuteNonQuery() Then
                    Return True
                Else
                    Return False
                End If
                con.Close()
            End Using
        End Using
    End Function
End Class