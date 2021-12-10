Imports CrystalDecisions.CrystalReports.Engine

Partial Class Credit_rptInterestIncome
    Inherits System.Web.UI.Page
    Dim cryRpt As ReportDocument = New ReportDocument()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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
            Dim brnch = Request.QueryString("brnch")

            Dim kk As String = ""

            kk = Server.MapPath("rptInterestIncome.rpt")
            cryRpt.Load(kk)
            'cryRpt.SetDatabaseLogon("sa", "")
            'cryRpt.SetParameterValue(0, query)
            cryRpt.SetParameterValue(0, fDat)
            cryRpt.SetParameterValue(1, tDat)
            cryRpt.SetParameterValue(2, brnch)
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