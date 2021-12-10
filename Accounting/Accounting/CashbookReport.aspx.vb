Partial Class Accounting_CashbookReport
    Inherits System.Web.UI.Page

    Protected Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        If dtpTrxnDate.Text = "" Or Not IsDate(dtpTrxnDate.Text) Then
            CreditManager.notify("Enter the date to print", "error")
        Else
            Dim EncQuery As New BankEncryption64
            Dim strscript As String
            strscript = "<script langauage=JavaScript>"
            'strscript += "window.open('rptTrialBalanceFull.aspx')"
            strscript += "window.open('rptCashbookRpt.aspx?d=" & EncQuery.Encrypt(dtpTrxnDate.Text) & "')"
            strscript += "</script>"
            ClientScript.RegisterStartupScript(Me.GetType(), "newwin", strscript)
        End If
    End Sub
End Class