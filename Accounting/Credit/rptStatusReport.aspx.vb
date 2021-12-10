Imports CrystalDecisions.CrystalReports.Engine

Partial Class Credit_rptStatusReport
    Inherits System.Web.UI.Page
    Dim cryRpt As ReportDocument = New ReportDocument()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        Try
            If Session("UserID") = String.Empty Then
                'not logged in redirect to login page
                Response.Redirect("~/Login.aspx", False)
                Exit Sub
            End If
            'Dim DecQuery As New BankEncryption64

            'Dim query = DecQuery.Decrypt(Request.QueryString("qry").Replace(" ", "+"), "lovely12345")
            Dim fDat = Request.QueryString("from")
            Dim tDat = Request.QueryString("to")
            Dim branch = Request.QueryString("brnch")
            Dim status = Request.QueryString("status")

            Dim kk As String = ""

            If branch = "All" Then
                kk = Server.MapPath("rptStatusReportAll.rpt")
                cryRpt.Load(kk)
                cryRpt.SetParameterValue(0, fDat)
                cryRpt.SetParameterValue(1, tDat)
                cryRpt.SetParameterValue(2, status)
            Else
                kk = Server.MapPath("rptStatusReport.rpt")
                cryRpt.Load(kk)
                cryRpt.SetParameterValue(0, fDat)
                cryRpt.SetParameterValue(1, tDat)
                cryRpt.SetParameterValue(2, status)
                cryRpt.SetParameterValue(3, branch)
            End If
            CrystalReportViewer1.ReportSource = cryRpt
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Unload
        cryRpt.Close()
        cryRpt.Dispose()
        GC.Collect()
    End Sub
End Class