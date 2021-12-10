
Partial Class Accounting_BalanceSheet
    Inherits System.Web.UI.Page
    Public Sub msgbox(ByVal strMessage As String)

        'finishes server processing, returns to client.
        Dim strScript As String = "<script language=JavaScript>"
        strScript += "window.alert(""" & strMessage & """);"
        strScript += "</script>"
        Dim lbl As New System.Web.UI.WebControls.Label
        lbl.Text = strScript
        Page.Controls.Add(lbl)

    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Session("DateFrom") = dtpTrxnDate.Text
        Session("DateTo") = dtpTrxnDate0.Text
        Try
            Dim strscript As String
            strscript = "<script langauage=JavaScript>"
            strscript += "window.open('BalanceSheetReport.aspx')"
            strscript += "</script>"
            ClientScript.RegisterStartupScript(Me.GetType(), "newwin", strscript)
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

End Class
