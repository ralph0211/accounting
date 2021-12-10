Partial Class Accounting_IncomeStatement
    Inherits System.Web.UI.Page

    Protected Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        Session("DateFrom") = txtFromDate.Text
        Session("DateTo") = txtToDate.Text
        Dim EncQuery As New BankEncryption64
        Try
            Dim strscript As String
            strscript = "<script langauage=JavaScript>"
            strscript += "window.open('rptIncomeStatement.aspx?dt=" & HttpUtility.UrlEncode(EncQuery.Encrypt(txtToDate.Text)) & "&df=" & HttpUtility.UrlEncode(EncQuery.Encrypt(txtFromDate.Text)) & "')"
            strscript += "</script>"
            ClientScript.RegisterStartupScript(Me.GetType(), "newwin", strscript)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class