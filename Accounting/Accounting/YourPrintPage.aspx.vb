Imports CrystalDecisions.CrystalReports.Engine
Imports System.IO
Imports System.Text
Imports System.Data.SqlClient
Imports System.Data
Imports System.Net.Sockets
Imports CrystalDecisions.Web

Partial Class Accounting_YourPrintPage
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Dim sRepFName = Request.QueryString("rep")
        Dim recNo = Request.QueryString("id")
        Dim sRepFName As String = Server.MapPath("rptReceipt.rpt")
        'Dim CrystalReportViewer1 As CrystalDecisions.Web.CrystalReportViewer = New CrystalDecisions.Web.CrystalReportViewer()
        Dim cryRpt As ReportDocument = New ReportDocument()
        Dim kk As String = ""
        'If IsManual = "Y" Then
        '    kk = Server.MapPath("~/Reports/PrintChequeManually.rpt")
        'Else
        kk = sRepFName
        'End If
        'Dim PrinterName As String = cmbPrinters.SelectedItem.Text

        cryRpt.Load(kk)
        cryRpt.SetParameterValue(0, recNo)
        CrystalReportViewer1.ToolPanelView = ToolPanelViewType.None
        CrystalReportViewer1.ReportSource = cryRpt
        'CrystalReportViewer1.Refresh()
        CrystalReportViewer1.ShowFirstPage()
        'msgbox("all well")
        'cryRpt.PrintOptions.PrinterName = PrinterName
        'cryRpt.PrintToPrinter(1, False, 0, 0)



        Dim sw As New StringWriter()
        Dim hw As New HtmlTextWriter(sw)
        CrystalReportViewer1.RenderControl(hw)
        Dim gridHTML As String = sw.ToString().Replace("""", "'") _
           .Replace(System.Environment.NewLine, "")
        Dim sb As New StringBuilder()
        sb.Append("<script type = 'text/javascript'>")
        sb.Append("window.onload = new function(){")
        sb.Append("var printWin = window.open('', '', 'left=0")
        sb.Append(",top=0,width=1000,height=600,status=0');")
        sb.Append("printWin.document.write(""")
        sb.Append(gridHTML)
        sb.Append(""");")
        sb.Append("printWin.document.close();")
        sb.Append("printWin.focus();")
        sb.Append("printWin.print();")
        sb.Append("printWin.close();};")
        sb.Append("</script>")

        ClientScript.RegisterStartupScript(Me.GetType(), "GridPrint", sb.ToString())
        'printPage()
    End Sub

    Public Sub msgbox(ByVal strMessage As String)

        'finishes server processing, returns to client.
        Dim strScript As String = "<script language=JavaScript>"
        strScript += "window.alert(""" & strMessage & """);"
        strScript += "</script>"
        Dim lbl As New System.Web.UI.WebControls.Label
        lbl.Text = strScript
        Page.Controls.Add(lbl)
    End Sub
End Class
