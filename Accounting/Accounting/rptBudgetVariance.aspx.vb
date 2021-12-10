Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data

Partial Class Accounting_rptBudgetVariance
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Page.MaintainScrollPositionOnPostBack = True
        ' If Not IsPostBack Then
        Dim DecQuery As New BankEncryption64
        Dim f = DecQuery.Decrypt(Request.QueryString("f").Replace(" ", "+"))
        Dim t = DecQuery.Decrypt(Request.QueryString("t").Replace(" ", "+"))

        Dim ds As New DataTable
        Dim dt As New dsAllReports.BudgetVarianceReportDataTable
        Dim dss As New dsAllReportsTableAdapters.BudgetVarianceReportTableAdapter
        dss.Fill(dt, f, t)

        Dim crystalReport As New ReportDocument()
        crystalReport.Load(Server.MapPath("rptBudgetVariance.rpt"))
        ds = dt
        crystalReport.SetDataSource(ds)
        crystalReport.SetParameterValue(0, f)
        crystalReport.SetParameterValue(1, t)
        CrystalReportViewer1.ReportSource = crystalReport
        'End If
    End Sub

End Class