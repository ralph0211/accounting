Partial Class Credit_frmMaturity
    Inherits System.Web.UI.Page

    Protected Sub btnPrint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Try
            Dim strscript As String

            strscript = "<script langauage=JavaScript>"
            strscript += "window.open('rptMaturity.aspx?from=" & bdpFromDate.Text & "&to=" & bdpToDate.Text & "');"
            strscript += "</script>"
            ClientScript.RegisterStartupScript(Me.GetType(), "newwin", strscript)
        Catch ex As Exception

        End Try
    End Sub
End Class