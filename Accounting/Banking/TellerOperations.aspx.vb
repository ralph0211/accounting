Imports System.Data
Imports System.Data.SqlClient
Imports CreditManager
Imports ErrorLogging
Partial Class Banking_TellerOperations
    Inherits System.Web.UI.Page

    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            If cmbBankTeller.SelectedValue = "" Then
                notify("Select the bank teller", "error")
                cmbBankTeller.Focus()
            ElseIf rdbTransactionType.SelectedIndex = -1
                notify("Select tranction type", "error")
                rdbTransactionType.Focus()
            ElseIf Not IsNumeric(txtAmount.Text)
                notify("Enter numeric value for amount", "error")
                txtAmount.Focus()
            ElseIf Not IsDate(txtTrxnDate.Text)
                notify("Enter transaction date", "error")
                txtTrxnDate.Focus()
            Else
                Using con As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                    Using cmd As New SqlCommand("SaveTellerOperation", con)
                        cmd.CommandType = CommandType.StoredProcedure
                        cmd.Parameters.AddWithValue("@TrxnType", rdbTransactionType.SelectedValue)
                        cmd.Parameters.AddWithValue("@TrxnDate", txtTrxnDate.Text)
                        cmd.Parameters.AddWithValue("@TellerID", cmbBankTeller.SelectedValue)
                        cmd.Parameters.AddWithValue("@TellerName", cmbBankTeller.SelectedItem.Text)
                        cmd.Parameters.AddWithValue("@Amount", txtAmount.Text)
                        cmd.Parameters.AddWithValue("@CapturedBy", Session("UserId"))
                        cmd.Parameters.AddWithValue("@Comment", txtComment.Text)
                        con.Open()
                        If cmd.ExecuteNonQuery Then
                            saveTempTransaction("Teller Transaction", "", txtComment.Text, txtAmount.Text, 0, cmbBankTeller.SelectedValue, lblVaultAccNo.Text, 0, "", "", "", "", txtTrxnDate.Text)
                            notify("Transaction saved", "success")
                        Else
                            notify("Error saving transaction", "error")
                        End If
                    End Using
                End Using
            End If
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- btnSave_Click()", ex.ToString)
        End Try
    End Sub

    Private Sub Banking_TellerOperations_Load(sender As Object, e As EventArgs) Handles Me.Load
        Page.MaintainScrollPositionOnPostBack = True
        If Not IsPostBack Then
            getVaultAccNo()
            lblVaultBalance.Text = getVaultBalance()
            loadUsersByRole(cmbBankTeller, "5047")
        End If
    End Sub

    Protected Function getVaultBalance() As Double
        Try
            Using con As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd As New SqlCommand("select isnull(sum(debit-credit),0) as Bal from Accounts_Transactions where Account=(select CONVERT(varchar,MainAccount)+AccountSeparator+CONVERT(varchar,subAccount) from tbl_FinancialAccountsCreation join ParaInternalControls on 1=1 where IsVault=1)", con)
                    Dim bal As Double = 0
                    con.Open()
                    bal = cmd.ExecuteScalar
                    con.Close()
                    Return bal
                End Using
            End Using
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- getVaultBalance()", ex.ToString)
            Return 0
        End Try
    End Function

    Protected Sub getVaultAccNo()
        Try
            Using con As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd As New SqlCommand("select CONVERT(varchar,MainAccount)+AccountSeparator+CONVERT(varchar,subAccount) from tbl_FinancialAccountsCreation join ParaInternalControls on 1=1 where IsVault=1", con)
                    con.Open()
                    lblVaultAccNo.Text = cmd.ExecuteScalar
                    con.Close()
                End Using
            End Using
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- getVaultAccNo()", ex.ToString)
        End Try
    End Sub
End Class