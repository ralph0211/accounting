Imports CrystalDecisions.CrystalReports.Engine

Partial Class Credit_rptOutreach
    Inherits System.Web.UI.Page
    Dim cryRpt As ReportDocument = New ReportDocument()

    Protected Sub btnLoadReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLoadReport.Click
        Try
            If Session("UserID") = String.Empty Then
                Response.Redirect("~/Login.aspx", False)
                Exit Sub
            End If
            Dim DecQuery As New BankEncryption64
            Dim myreport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()

            Dim cryRpt As ReportDocument = New ReportDocument()
            Dim kk As String = ""

            If cmbIndicator.SelectedValue = "A" Then
                kk = Server.MapPath("rptOutreachArea.rpt")
            ElseIf cmbIndicator.SelectedValue = "Age" Then
                kk = Server.MapPath("rptOutreachAge.rpt")
            ElseIf cmbIndicator.SelectedValue = "G" Then
                kk = Server.MapPath("rptOutreachGender.rpt")
            ElseIf cmbIndicator.SelectedValue = "P" Then
                kk = Server.MapPath("rptOutreachPurpose.rpt")
            End If
            cryRpt.Load(kk)
            'cryRpt.SetDatabaseLogon("sa", "")
            cryRpt.SetParameterValue(0, bdpFromDate.Text)
            cryRpt.SetParameterValue(1, bdpToDate.Text)
            CrystalReportViewer1.ReportSource = cryRpt
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Session("UserID") = String.Empty Then
                Response.Redirect("~/Login.aspx", False)
                Exit Sub
            End If
            Dim DecQuery As New BankEncryption64

            Dim kk As String = ""

            If cmbIndicator.SelectedValue = "A" Then
                kk = Server.MapPath("rptOutreachArea.rpt")
            ElseIf cmbIndicator.SelectedValue = "Age" Then
                kk = Server.MapPath("rptOutreachAge.rpt")
            ElseIf cmbIndicator.SelectedValue = "G" Then
                kk = Server.MapPath("rptOutreachGender.rpt")
            ElseIf cmbIndicator.SelectedValue = "P" Then
                kk = Server.MapPath("rptOutreachPurpose.rpt")
            End If
            cryRpt.Load(kk)
            'cryRpt.SetDatabaseLogon("sa", "")
            cryRpt.SetParameterValue(0, bdpFromDate.Text)
            cryRpt.SetParameterValue(1, bdpToDate.Text)
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