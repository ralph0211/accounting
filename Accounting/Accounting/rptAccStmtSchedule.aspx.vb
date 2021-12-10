Imports CrystalDecisions.CrystalReports.Engine

Partial Class Accounting_rptAccStmtSchedule
    Inherits System.Web.UI.Page
    Dim cryRpt As ReportDocument = New ReportDocument()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Session("UserID") = String.Empty Then
                Response.Redirect("~/Login.aspx", False)
                Exit Sub
            End If
            Dim DecQuery As New BankEncryption64

            'Dim lID = DecQuery.Decrypt(Request.QueryString("ref").Replace(" ", "+"), "taDz392018hbdER")
            Dim acc = Request.QueryString("acc")
            Dim dat = Request.QueryString("dat")
            'Dim startDate = DecQuery.Decrypt(Request.QueryString("sDate").Replace(" ", "+"), "taDz392018hbdER")
            'Dim endDate = DecQuery.Decrypt(Request.QueryString("eDate").Replace(" ", "+"), "taDz392018hbdER")
            Dim kk As String = ""

            kk = Server.MapPath("rptAccStmtSchedule.rpt")
            cryRpt.Load(kk)
            'msgbox(lID & "    " & startDate & "    " & endDate)
            cryRpt.SetParameterValue(0, acc)
            cryRpt.SetParameterValue(1, dat)
            'cryRpt.SetParameterValue(2, endDate)
            CrystalReportViewer1.ReportSource = cryRpt
        Catch ex As Exception

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

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Unload
        cryRpt.Close()
        cryRpt.Dispose()
        GC.Collect()
    End Sub
End Class