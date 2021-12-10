Imports CrystalDecisions.CrystalReports.Engine

Partial Class Credit_rptFormLetter
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

            'kk = Server.MapPath("rptFormLetter.rpt")
            'cryRpt.Load(kk)
            If Request.QueryString("typ") = "grp" Then
                Dim cust = Request.QueryString("cust")
                kk = Server.MapPath("rptFormLetterGrp.rpt")
                cryRpt.Load(kk)
                cryRpt.SetParameterValue("loanID", lnID)
                cryRpt.SetParameterValue("custno", cust)
            Else
                kk = Server.MapPath("rptFormLetter.rpt")
                cryRpt.Load(kk)
                cryRpt.SetParameterValue(0, lnID)
            End If
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