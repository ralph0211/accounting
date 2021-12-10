Partial Class Credit_frmEarnedInterest
    Inherits System.Web.UI.Page

    Protected Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        Try
            Dim strscript As String

            strscript = "<script langauage=JavaScript>"
            strscript += "window.open('rptEarnedInterest.aspx?from=" & bdpFromDate.Text & "&to=" & bdpToDate.Text & "&t=" & rdbReportType.SelectedValue & "&brnch=All');"
            strscript += "</script>"
            ClientScript.RegisterStartupScript(Me.GetType(), "newwin", strscript)
        Catch ex As Exception

        End Try
    End Sub
End Class