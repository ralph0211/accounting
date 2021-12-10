Partial Class Accounting_rptTrialBalanceRpt
    Inherits System.Web.UI.Page
    Dim myreport As CrystalDecisions.CrystalReports.Engine.ReportDocument

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Try
            If Session("UserID") = String.Empty Then
                'not logged in redirect to login page
                Response.Redirect("~/Login.aspx", False)
                Exit Sub
            End If
            Dim DecQuery As New BankEncryption64

            Dim tDat = DecQuery.Decrypt(Request.QueryString("d").Replace(" ", "+"))
            Dim main As String = Request.QueryString("m")
            myreport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()
            If main = "1" Then
                myreport.Load(Server.MapPath("rptTrialBalanceMain.rpt"))
            Else
                myreport.Load(Server.MapPath("rptTrialBalance.rpt"))
            End If
            myreport.SetParameterValue(0, tDat)
            CrystalReportViewer1.ReportSource = myreport
            'msgbox(receiptno)
            'CrystalReportViewer1.ParameterFieldInfo = myParameterFields

            'CrystalReportViewer1.RefreshReport()

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub msgbox(ByVal strMessage As String)

        'finishes server processing, returns to client.
        Dim strScript As String = "<script language=JavaScript>"
        strScript += "window.alert(""" & strMessage & """);"
        strScript += "</script>"
        Dim lbl As New System.Web.UI.WebControls.Label
        lbl.Text = strScript
        Page.Controls.Add(lbl)

    End Sub

    Protected Sub Page_Unload(sender As Object, e As System.EventArgs) Handles Me.Unload
        Try
            myreport.Close()
            myreport.Dispose()
            GC.Collect()
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
End Class