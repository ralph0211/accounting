Imports System.Data
Imports System.Data.SqlClient
Imports CreditManager
Imports ErrorLogging

Partial Class Accounting_BankReconciliation
    Inherits System.Web.UI.Page

    Protected Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        Try
            Dim strscript As String
            strscript = "<script langauage=JavaScript>"
            strscript += "window.open('rptBankRecon.aspx?bnk=" & cmbBankAccount.SelectedValue & "&df=" & txtFromDate.Text & "&dt=" & txtBankStmtBal.Text & "')"
            strscript += "</script>"
            ClientScript.RegisterStartupScript(Me.GetType(), "newwin", strscript)
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub loadAccounts(mainAcc As String)
        Try
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                'Using cmd = New SqlCommand("select convert(varchar,MainAccount)  + '/' + convert(varchar,SubAccount) as AccountNo, AccountName  + '  ' + convert(varchar,MainAccount)  + '/' + convert(varchar,SubAccount) as AccountName from tbl_FinancialAccountsCreation where MainAccount='" & mainAcc & "' and SubAccount<>1", con)
                Using cmd = New SqlCommand("select AccountNo, AccountName  + '  ' + convert(varchar,AccountNo) as AccountName from CashbookAccounts", con)
                    'End if
                    Dim ds As New DataSet
                    Using adp = New SqlDataAdapter(cmd)
                        adp.Fill(ds, "LRS2")
                    End Using
                    cmbBankAccount.Visible = True
                    loadCombo(ds.Tables(0), cmbBankAccount, "AccountName", "AccountNo")
                End Using
            End Using
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- loadAccounts()", ex.ToString)
        End Try
    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Page.MaintainScrollPositionOnPostBack = True
        If Not IsPostBack Then
            loadAccounts("212")
        End If
    End Sub
End Class