Imports CrystalDecisions.CrystalReports.Engine

Partial Class Credit_rptSSBUpload
    Inherits System.Web.UI.Page
    Dim cryRpt As ReportDocument = New ReportDocument()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Session("UserID") = String.Empty Then
                Response.Redirect("~/Logout.aspx", False)
                Exit Sub
            End If
            Dim filDate = Request.QueryString("date")

            Dim kk As String = ""

            kk = Server.MapPath("rptSSBUpload.rpt")
            cryRpt.Load(kk)
            'cryRpt.SetDatabaseLogon("sa", "")
            cryRpt.SetParameterValue(0, filDate)
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