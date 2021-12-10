Imports CrystalDecisions.CrystalReports.Engine

Partial Class Credit_rptAcknowledgeSSB
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

            'Dim query = DecQuery.Decrypt(Request.QueryString("qry").Replace(" ", "+"), "lovely12345")
            Dim lnID = DecQuery.Decrypt(Request.QueryString("ID").Replace(" ", "+"))

            Dim kk As String = ""

            kk = Server.MapPath("rptAcknowledgeSSB.rpt")
            cryRpt.Load(kk)
            'cryRpt.SetDatabaseLogon("sa", "")
            'cryRpt.SetParameterValue(0, query)
            cryRpt.SetParameterValue(0, lnID)
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