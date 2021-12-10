Imports CrystalDecisions.CrystalReports.Engine

Partial Class Accounting_rptBankRecon
    Inherits System.Web.UI.Page
    Dim cryRpt As ReportDocument = New ReportDocument()

    Public Sub msgbox(ByVal strMessage As String)

        'finishes server processing, returns to client.
        Dim strScript As String = "<script language=JavaScript>"
        strScript += "window.alert(""" & strMessage & """);"
        strScript += "</script>"
        Dim lbl As New System.Web.UI.WebControls.Label
        lbl.Text = strScript
        Page.Controls.Add(lbl)
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Session("UserID") = String.Empty Then
                Response.Redirect("~/Login.aspx", False)
                Exit Sub
            End If
            Dim DecQuery As New BankEncryption64
            'Dim lID = DecQuery.Decrypt(Request.QueryString("ref").Replace(" ", "+"), "taDz392018hbdER")
            'Dim lID = Request.QueryString("t")
            Dim startDate = Request.QueryString("df").ToString
            Dim endDate = Request.QueryString("dt").ToString
            Dim bRef = Request.QueryString("bnk").ToString
            Dim kk As String = ""
            'If lID = "5" Then
            kk = Server.MapPath("../Accounting/rptBankRecon.rpt")
            cryRpt.Load(kk)
            cryRpt.SetParameterValue("pFDate", startDate)
            cryRpt.SetParameterValue("stmtBal", endDate)
            cryRpt.SetParameterValue("pAccNo", bRef)
            CrystalReportViewer1.ReportSource = cryRpt
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Unload
        cryRpt.Close()
        cryRpt.Dispose()
        GC.Collect()
    End Sub
End Class