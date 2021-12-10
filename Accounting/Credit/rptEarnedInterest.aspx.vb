Imports CrystalDecisions.CrystalReports.Engine

Partial Class Credit_rptEarnedInterest
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
            Dim typ = Request.QueryString("t")

            Dim kk As String = ""
            If typ = "Daily" Then
                kk = Server.MapPath("../Accounting/rptEarnedInterestAudit.rpt")
                cryRpt.Load(kk)
                cryRpt.SetParameterValue(0, fDat)
                cryRpt.SetParameterValue(1, tDat)
            Else
                If brnch = "All" Then
                    kk = Server.MapPath("rptEarnedInterestAll.rpt")
                    cryRpt.Load(kk)
                    cryRpt.SetParameterValue(0, fDat)
                    cryRpt.SetParameterValue(1, tDat)
                Else
                    kk = Server.MapPath("rptEarnedInterest.rpt")
                    cryRpt.Load(kk)
                    cryRpt.SetParameterValue(0, fDat)
                    cryRpt.SetParameterValue(1, tDat)
                    cryRpt.SetParameterValue(2, brnch)
                End If
            End If

            CrystalReportViewer1.ReportSource = cryRpt
        Catch ex As Exception
            CreditManager.msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Unload
        cryRpt.Close()
        cryRpt.Dispose()
        GC.Collect()
    End Sub
End Class