Imports CrystalDecisions.CrystalReports.Engine

Partial Class Credit_rptArrears
    Inherits System.Web.UI.Page
    Dim cryRpt As ReportDocument = New ReportDocument()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Session("UserID") = String.Empty Then
                'not logged in redirect to login page
                Response.Redirect("~/Login.aspx", False)
                Exit Sub
            End If
            Dim DecQuery As New BankEncryption64

            Dim fDat = Request.QueryString("from")
            Dim tDat = Request.QueryString("to")
            Dim brnch = Request.QueryString("brnch")

            Dim kk As String = ""
            If brnch = "All" Then
                kk = Server.MapPath("rptArrearsAll.rpt")
                cryRpt.Load(kk)
                cryRpt.SetParameterValue(0, fDat)
                cryRpt.SetParameterValue(1, tDat)
            Else
                kk = Server.MapPath("rptArrears.rpt")
                cryRpt.Load(kk)
                cryRpt.SetParameterValue(0, fDat)
                cryRpt.SetParameterValue(1, tDat)
                cryRpt.SetParameterValue(2, brnch)
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