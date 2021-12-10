Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data

Partial Class Accounting_rptBL
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Page.MaintainScrollPositionOnPostBack = True
        ' If Not IsPostBack Then
        Dim DecQuery As New BankEncryption64
        Dim lID = DecQuery.Decrypt(Request.QueryString("id").Replace(" ", "+"), "taDz392018hbdER")
        ''ErrorLogging.WriteLogFile("ralph", "rptBL.aspx", lID)
        ''msgbox(lID)
        'Dim report As xrptBalanceSheet = New xrptBalanceSheet()
        'report.Parameters(0).Value = lID.ToString
        'ASPxDocumentViewer1.Report = report

        Dim ds As New DataTable
        Dim dt As New dsAllReports.BalanceSheetDataTable
        Dim dss As New dsAllReportsTableAdapters.BalanceSheetTableAdapter
        dss.Fill(dt, lID)

        Dim crystalReport As New ReportDocument()
        crystalReport.Load(Server.MapPath("rptBalanceSheet.rpt"))
        '            Dim dsCustomers As dsAllReports = GetData("select * from customers")
        ds = dt
        crystalReport.SetDataSource(ds)
        crystalReport.SetParameterValue(0, lID)
        CrystalReportViewer1.ReportSource = crystalReport
        'End If
    End Sub
End Class