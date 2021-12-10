Public Class xrptLoanAnalysis
    Inherits DevExpress.XtraReports.UI.XtraReport

#Region " Designer generated code "

    Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
    Public Sub New()
        MyBase.New()

        'This call is required by the Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'XtraReport overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub
    Private WithEvents xrTableRow1 As DevExpress.XtraReports.UI.XRTableRow
    Private WithEvents xrTableCell1 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell2 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell3 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableRow2 As DevExpress.XtraReports.UI.XRTableRow
    Private WithEvents xrTableCell4 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell5 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell6 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents toDate As DevExpress.XtraReports.Parameters.Parameter
    Private WithEvents xrTable2 As DevExpress.XtraReports.UI.XRTable
    Private WithEvents xrTableRow6 As DevExpress.XtraReports.UI.XRTableRow
    Private WithEvents xrTableCell14 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell16 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell18 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell20 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents dsAllReports1 As dsAllReports
    Private WithEvents loansAnalysisTableAdapter1 As dsAllReportsTableAdapters.LoansAnalysisTableAdapter
    Private WithEvents reportsGroupingTableAdapter1 As dsChartTypesTableAdapters.ReportsGroupingTableAdapter
    Private WithEvents pageHeaderBand1 As DevExpress.XtraReports.UI.PageHeaderBand
    Private WithEvents xrTable1 As DevExpress.XtraReports.UI.XRTable
    Private WithEvents xrTableRow5 As DevExpress.XtraReports.UI.XRTableRow
    Private WithEvents xrTableCell13 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell15 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell17 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell19 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableRow3 As DevExpress.XtraReports.UI.XRTableRow
    Private WithEvents xrTableCell7 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell8 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell9 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableRow4 As DevExpress.XtraReports.UI.XRTableRow
    Private WithEvents xrTableCell10 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell11 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell12 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents pageFooterBand1 As DevExpress.XtraReports.UI.PageFooterBand
    Private WithEvents xrPageInfo1 As DevExpress.XtraReports.UI.XRPageInfo
    Private WithEvents xrPageInfo2 As DevExpress.XtraReports.UI.XRPageInfo
    Private WithEvents reportHeaderBand1 As DevExpress.XtraReports.UI.ReportHeaderBand
    Private WithEvents xrLabel1 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents Title As DevExpress.XtraReports.UI.XRControlStyle
    Private WithEvents FieldCaption As DevExpress.XtraReports.UI.XRControlStyle
    Private WithEvents PageInfo As DevExpress.XtraReports.UI.XRControlStyle
    Private WithEvents DataField As DevExpress.XtraReports.UI.XRControlStyle
    Private WithEvents topMarginBand1 As DevExpress.XtraReports.UI.TopMarginBand
    Private WithEvents bottomMarginBand1 As DevExpress.XtraReports.UI.BottomMarginBand
    Private WithEvents xrChart1 As DevExpress.XtraReports.UI.XRChart
    Private WithEvents fromDate As DevExpress.XtraReports.Parameters.Parameter
    Private WithEvents dsChartTypes1 As dsChartTypes
    Private WithEvents grouping As DevExpress.XtraReports.Parameters.Parameter
    Private WithEvents xrLabel2 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents GroupFooter1 As DevExpress.XtraReports.UI.GroupFooterBand
    Private WithEvents xrTable3 As DevExpress.XtraReports.UI.XRTable
    Private WithEvents xrTableRow7 As DevExpress.XtraReports.UI.XRTableRow
    Private WithEvents xrTableCell21 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell22 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell23 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell24 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents dsChartTypes2 As dsChartTypes
    Private WithEvents chartOptionsTableAdapter1 As dsChartTypesTableAdapters.ChartOptionsTableAdapter
    Private WithEvents chartType As DevExpress.XtraReports.Parameters.Parameter
    'Private WithEvents chartType As DevExpress.XtraReports.Parameters.Parameter

    'Required by the Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Designer
    'It can be modified using the Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resourceFileName As String = "xrptLoanAnalysis.resx"
        Dim xyDiagram1 As DevExpress.XtraCharts.XYDiagram = New DevExpress.XtraCharts.XYDiagram()
        Dim sideBySideBarSeriesLabel1 As DevExpress.XtraCharts.SideBySideBarSeriesLabel = New DevExpress.XtraCharts.SideBySideBarSeriesLabel()
        Dim pointOptions1 As DevExpress.XtraCharts.PointOptions = New DevExpress.XtraCharts.PointOptions()
        Dim dynamicListLookUpSettings1 As DevExpress.XtraReports.Parameters.DynamicListLookUpSettings = New DevExpress.XtraReports.Parameters.DynamicListLookUpSettings()
        Dim xrSummary1 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
        Dim xrSummary2 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
        Dim xrSummary3 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
        Dim dynamicListLookUpSettings2 As DevExpress.XtraReports.Parameters.DynamicListLookUpSettings = New DevExpress.XtraReports.Parameters.DynamicListLookUpSettings()
        Me.reportsGroupingTableAdapter1 = New dsChartTypesTableAdapters.ReportsGroupingTableAdapter()
        Me.dsChartTypes1 = New dsChartTypes()
        Me.chartOptionsTableAdapter1 = New dsChartTypesTableAdapters.ChartOptionsTableAdapter()
        Me.dsChartTypes2 = New dsChartTypes()
        Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
        Me.xrTable2 = New DevExpress.XtraReports.UI.XRTable()
        Me.xrTableRow6 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.xrTableCell14 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell16 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell18 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell20 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableRow1 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.xrTableCell1 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell2 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell3 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableRow2 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.xrTableCell4 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell5 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell6 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.toDate = New DevExpress.XtraReports.Parameters.Parameter()
        Me.dsAllReports1 = New dsAllReports()
        Me.loansAnalysisTableAdapter1 = New dsAllReportsTableAdapters.LoansAnalysisTableAdapter()
        Me.pageHeaderBand1 = New DevExpress.XtraReports.UI.PageHeaderBand()
        Me.xrTable1 = New DevExpress.XtraReports.UI.XRTable()
        Me.xrTableRow5 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.xrTableCell13 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell15 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell17 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell19 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableRow3 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.xrTableCell7 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell8 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell9 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableRow4 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.xrTableCell10 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell11 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell12 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.pageFooterBand1 = New DevExpress.XtraReports.UI.PageFooterBand()
        Me.xrPageInfo1 = New DevExpress.XtraReports.UI.XRPageInfo()
        Me.xrPageInfo2 = New DevExpress.XtraReports.UI.XRPageInfo()
        Me.reportHeaderBand1 = New DevExpress.XtraReports.UI.ReportHeaderBand()
        Me.xrLabel2 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrChart1 = New DevExpress.XtraReports.UI.XRChart()
        Me.xrLabel1 = New DevExpress.XtraReports.UI.XRLabel()
        Me.Title = New DevExpress.XtraReports.UI.XRControlStyle()
        Me.FieldCaption = New DevExpress.XtraReports.UI.XRControlStyle()
        Me.PageInfo = New DevExpress.XtraReports.UI.XRControlStyle()
        Me.DataField = New DevExpress.XtraReports.UI.XRControlStyle()
        Me.topMarginBand1 = New DevExpress.XtraReports.UI.TopMarginBand()
        Me.bottomMarginBand1 = New DevExpress.XtraReports.UI.BottomMarginBand()
        Me.fromDate = New DevExpress.XtraReports.Parameters.Parameter()
        Me.grouping = New DevExpress.XtraReports.Parameters.Parameter()
        Me.GroupFooter1 = New DevExpress.XtraReports.UI.GroupFooterBand()
        Me.xrTable3 = New DevExpress.XtraReports.UI.XRTable()
        Me.xrTableRow7 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.xrTableCell21 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell22 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell23 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell24 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.chartType = New DevExpress.XtraReports.Parameters.Parameter()
        CType(Me.dsChartTypes1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dsChartTypes2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.xrTable2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dsAllReports1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.xrTable1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.xrChart1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(xyDiagram1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(sideBySideBarSeriesLabel1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.xrTable3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'reportsGroupingTableAdapter1
        '
        Me.reportsGroupingTableAdapter1.ClearBeforeFill = True
        '
        'dsChartTypes1
        '
        Me.dsChartTypes1.DataSetName = "dsChartTypes"
        Me.dsChartTypes1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'chartOptionsTableAdapter1
        '
        Me.chartOptionsTableAdapter1.ClearBeforeFill = True
        '
        'dsChartTypes2
        '
        Me.dsChartTypes2.DataSetName = "dsChartTypes"
        Me.dsChartTypes2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.xrTable2})
        Me.Detail.Dpi = 254.0!
        Me.Detail.HeightF = 58.42!
        Me.Detail.Name = "Detail"
        Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 254.0!)
        Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'xrTable2
        '
        Me.xrTable2.AnchorVertical = CType((DevExpress.XtraReports.UI.VerticalAnchorStyles.Top Or DevExpress.XtraReports.UI.VerticalAnchorStyles.Bottom), DevExpress.XtraReports.UI.VerticalAnchorStyles)
        Me.xrTable2.Dpi = 254.0!
        Me.xrTable2.LocationFloat = New DevExpress.Utils.PointFloat(16.0!, 0!)
        Me.xrTable2.Name = "xrTable2"
        Me.xrTable2.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.xrTableRow6})
        Me.xrTable2.SizeF = New System.Drawing.SizeF(1618.0!, 58.42!)
        '
        'xrTableRow6
        '
        Me.xrTableRow6.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.xrTableCell14, Me.xrTableCell16, Me.xrTableCell18, Me.xrTableCell20})
        Me.xrTableRow6.Dpi = 254.0!
        Me.xrTableRow6.Name = "xrTableRow6"
        Me.xrTableRow6.Weight = 1.0R
        '
        'xrTableCell14
        '
        Me.xrTableCell14.CanGrow = False
        Me.xrTableCell14.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "LoansAnalysis.Variable")})
        Me.xrTableCell14.Dpi = 254.0!
        Me.xrTableCell14.Name = "xrTableCell14"
        Me.xrTableCell14.StyleName = "DataField"
        Me.xrTableCell14.Text = "xrTableCell14"
        Me.xrTableCell14.Weight = 301.52174481178542R
        '
        'xrTableCell16
        '
        Me.xrTableCell16.CanGrow = False
        Me.xrTableCell16.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "LoansAnalysis.NoClients", "{0:#,#}")})
        Me.xrTableCell16.Dpi = 254.0!
        Me.xrTableCell16.Name = "xrTableCell16"
        Me.xrTableCell16.StyleName = "DataField"
        Me.xrTableCell16.Text = "xrTableCell16"
        Me.xrTableCell16.Weight = 186.00414571302341R
        '
        'xrTableCell18
        '
        Me.xrTableCell18.CanGrow = False
        Me.xrTableCell18.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "LoansAnalysis.NoApps", "{0:#,#}")})
        Me.xrTableCell18.Dpi = 254.0!
        Me.xrTableCell18.Name = "xrTableCell18"
        Me.xrTableCell18.StyleName = "DataField"
        Me.xrTableCell18.Text = "xrTableCell18"
        Me.xrTableCell18.Weight = 166.18070253954534R
        '
        'xrTableCell20
        '
        Me.xrTableCell20.CanGrow = False
        Me.xrTableCell20.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "LoansAnalysis.SumApps", "{0:n2}")})
        Me.xrTableCell20.Dpi = 254.0!
        Me.xrTableCell20.Name = "xrTableCell20"
        Me.xrTableCell20.StyleName = "DataField"
        Me.xrTableCell20.StylePriority.UseTextAlignment = False
        Me.xrTableCell20.Text = "xrTableCell20"
        Me.xrTableCell20.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        Me.xrTableCell20.Weight = 154.29340693564586R
        '
        'xrTableRow1
        '
        Me.xrTableRow1.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.xrTableCell1, Me.xrTableCell2, Me.xrTableCell3})
        Me.xrTableRow1.Dpi = 254.0!
        Me.xrTableRow1.Name = "xrTableRow1"
        Me.xrTableRow1.Weight = 1.0R
        '
        'xrTableCell1
        '
        Me.xrTableCell1.Dpi = 254.0!
        Me.xrTableCell1.Name = "xrTableCell1"
        Me.xrTableCell1.Weight = 1.0R
        '
        'xrTableCell2
        '
        Me.xrTableCell2.Dpi = 254.0!
        Me.xrTableCell2.Name = "xrTableCell2"
        Me.xrTableCell2.Weight = 1.0R
        '
        'xrTableCell3
        '
        Me.xrTableCell3.Dpi = 254.0!
        Me.xrTableCell3.Name = "xrTableCell3"
        Me.xrTableCell3.Weight = 1.0R
        '
        'xrTableRow2
        '
        Me.xrTableRow2.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.xrTableCell4, Me.xrTableCell5, Me.xrTableCell6})
        Me.xrTableRow2.Dpi = 254.0!
        Me.xrTableRow2.Name = "xrTableRow2"
        Me.xrTableRow2.Weight = 1.0R
        '
        'xrTableCell4
        '
        Me.xrTableCell4.Dpi = 254.0!
        Me.xrTableCell4.Name = "xrTableCell4"
        Me.xrTableCell4.Weight = 1.0R
        '
        'xrTableCell5
        '
        Me.xrTableCell5.Dpi = 254.0!
        Me.xrTableCell5.Name = "xrTableCell5"
        Me.xrTableCell5.Weight = 1.0R
        '
        'xrTableCell6
        '
        Me.xrTableCell6.Dpi = 254.0!
        Me.xrTableCell6.Name = "xrTableCell6"
        Me.xrTableCell6.Weight = 1.0R
        '
        'toDate
        '
        Me.toDate.Description = "To"
        Me.toDate.Name = "toDate"
        Me.toDate.Type = GetType(Date)
        Me.toDate.ValueInfo = Date.Now.ToLongDateString
        '
        'dsAllReports1
        '
        Me.dsAllReports1.DataSetName = "dsAllReports"
        Me.dsAllReports1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'loansAnalysisTableAdapter1
        '
        Me.loansAnalysisTableAdapter1.ClearBeforeFill = True
        '
        'pageHeaderBand1
        '
        Me.pageHeaderBand1.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.xrTable1})
        Me.pageHeaderBand1.Dpi = 254.0!
        Me.pageHeaderBand1.HeightF = 106.0!
        Me.pageHeaderBand1.Name = "pageHeaderBand1"
        '
        'xrTable1
        '
        Me.xrTable1.AnchorVertical = DevExpress.XtraReports.UI.VerticalAnchorStyles.Bottom
        Me.xrTable1.Dpi = 254.0!
        Me.xrTable1.LocationFloat = New DevExpress.Utils.PointFloat(16.0!, 16.0!)
        Me.xrTable1.Name = "xrTable1"
        Me.xrTable1.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.xrTableRow5})
        Me.xrTable1.SizeF = New System.Drawing.SizeF(1618.0!, 90.0!)
        '
        'xrTableRow5
        '
        Me.xrTableRow5.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.xrTableCell13, Me.xrTableCell15, Me.xrTableCell17, Me.xrTableCell19})
        Me.xrTableRow5.Dpi = 254.0!
        Me.xrTableRow5.Name = "xrTableRow5"
        Me.xrTableRow5.Weight = 1.0R
        '
        'xrTableCell13
        '
        Me.xrTableCell13.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
        Me.xrTableCell13.CanGrow = False
        Me.xrTableCell13.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "LoansAnalysis.VariableName")})
        Me.xrTableCell13.Dpi = 254.0!
        Me.xrTableCell13.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.xrTableCell13.ForeColor = System.Drawing.Color.Maroon
        Me.xrTableCell13.Name = "xrTableCell13"
        Me.xrTableCell13.StyleName = "DataField"
        Me.xrTableCell13.StylePriority.UseBorders = False
        Me.xrTableCell13.StylePriority.UseFont = False
        Me.xrTableCell13.StylePriority.UseForeColor = False
        Me.xrTableCell13.Text = "Variable"
        Me.xrTableCell13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        Me.xrTableCell13.Weight = 301.52174481178542R
        '
        'xrTableCell15
        '
        Me.xrTableCell15.CanGrow = False
        Me.xrTableCell15.Dpi = 254.0!
        Me.xrTableCell15.Name = "xrTableCell15"
        Me.xrTableCell15.StyleName = "FieldCaption"
        Me.xrTableCell15.Text = "Number of Clients"
        Me.xrTableCell15.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        Me.xrTableCell15.Weight = 186.00414571302341R
        '
        'xrTableCell17
        '
        Me.xrTableCell17.CanGrow = False
        Me.xrTableCell17.Dpi = 254.0!
        Me.xrTableCell17.Name = "xrTableCell17"
        Me.xrTableCell17.StyleName = "FieldCaption"
        Me.xrTableCell17.Text = "Number of Applications"
        Me.xrTableCell17.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        Me.xrTableCell17.Weight = 166.18070253954534R
        '
        'xrTableCell19
        '
        Me.xrTableCell19.CanGrow = False
        Me.xrTableCell19.Dpi = 254.0!
        Me.xrTableCell19.Name = "xrTableCell19"
        Me.xrTableCell19.StyleName = "FieldCaption"
        Me.xrTableCell19.StylePriority.UseTextAlignment = False
        Me.xrTableCell19.Text = "Total Amount"
        Me.xrTableCell19.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.xrTableCell19.Weight = 154.29340693564586R
        '
        'xrTableRow3
        '
        Me.xrTableRow3.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.xrTableCell7, Me.xrTableCell8, Me.xrTableCell9})
        Me.xrTableRow3.Dpi = 254.0!
        Me.xrTableRow3.Name = "xrTableRow3"
        Me.xrTableRow3.Weight = 1.0R
        '
        'xrTableCell7
        '
        Me.xrTableCell7.Dpi = 254.0!
        Me.xrTableCell7.Name = "xrTableCell7"
        Me.xrTableCell7.Weight = 1.0R
        '
        'xrTableCell8
        '
        Me.xrTableCell8.Dpi = 254.0!
        Me.xrTableCell8.Name = "xrTableCell8"
        Me.xrTableCell8.Weight = 1.0R
        '
        'xrTableCell9
        '
        Me.xrTableCell9.Dpi = 254.0!
        Me.xrTableCell9.Name = "xrTableCell9"
        Me.xrTableCell9.Weight = 1.0R
        '
        'xrTableRow4
        '
        Me.xrTableRow4.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.xrTableCell10, Me.xrTableCell11, Me.xrTableCell12})
        Me.xrTableRow4.Dpi = 254.0!
        Me.xrTableRow4.Name = "xrTableRow4"
        Me.xrTableRow4.Weight = 1.0R
        '
        'xrTableCell10
        '
        Me.xrTableCell10.Dpi = 254.0!
        Me.xrTableCell10.Name = "xrTableCell10"
        Me.xrTableCell10.Weight = 1.0R
        '
        'xrTableCell11
        '
        Me.xrTableCell11.Dpi = 254.0!
        Me.xrTableCell11.Name = "xrTableCell11"
        Me.xrTableCell11.Weight = 1.0R
        '
        'xrTableCell12
        '
        Me.xrTableCell12.Dpi = 254.0!
        Me.xrTableCell12.Name = "xrTableCell12"
        Me.xrTableCell12.Weight = 1.0R
        '
        'pageFooterBand1
        '
        Me.pageFooterBand1.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.xrPageInfo1, Me.xrPageInfo2})
        Me.pageFooterBand1.Dpi = 254.0!
        Me.pageFooterBand1.HeightF = 74.42!
        Me.pageFooterBand1.Name = "pageFooterBand1"
        '
        'xrPageInfo1
        '
        Me.xrPageInfo1.Dpi = 254.0!
        Me.xrPageInfo1.LocationFloat = New DevExpress.Utils.PointFloat(16.0!, 16.0!)
        Me.xrPageInfo1.Name = "xrPageInfo1"
        Me.xrPageInfo1.Padding = New DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254.0!)
        Me.xrPageInfo1.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime
        Me.xrPageInfo1.SizeF = New System.Drawing.SizeF(793.0!, 58.42!)
        Me.xrPageInfo1.StyleName = "PageInfo"
        '
        'xrPageInfo2
        '
        Me.xrPageInfo2.Dpi = 254.0!
        Me.xrPageInfo2.Format = "Page {0} of {1}"
        Me.xrPageInfo2.LocationFloat = New DevExpress.Utils.PointFloat(841.0!, 16.0!)
        Me.xrPageInfo2.Name = "xrPageInfo2"
        Me.xrPageInfo2.Padding = New DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254.0!)
        Me.xrPageInfo2.SizeF = New System.Drawing.SizeF(793.0!, 58.42!)
        Me.xrPageInfo2.StyleName = "PageInfo"
        Me.xrPageInfo2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'reportHeaderBand1
        '
        Me.reportHeaderBand1.Dpi = 254.0!
        Me.reportHeaderBand1.HeightF = 0!
        Me.reportHeaderBand1.Name = "reportHeaderBand1"
        '
        'xrLabel2
        '
        Me.xrLabel2.Dpi = 254.0!
        Me.xrLabel2.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold)
        Me.xrLabel2.LocationFloat = New DevExpress.Utils.PointFloat(15.99999!, 208.3332!)
        Me.xrLabel2.Name = "xrLabel2"
        Me.xrLabel2.Padding = New DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254.0!)
        Me.xrLabel2.SizeF = New System.Drawing.SizeF(1341.313!, 58.41998!)
        Me.xrLabel2.StylePriority.UseFont = False
        Me.xrLabel2.Text = "From [Parameters.fromDate!dd MMMM yyyy] to [Parameters.toDate!dd MMMM yyyy]"
        '
        'xrChart1
        '
        Me.xrChart1.BorderColor = System.Drawing.Color.Black
        Me.xrChart1.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.xrChart1.DataAdapter = Me.loansAnalysisTableAdapter1
        Me.xrChart1.DataMember = "LoansAnalysis"
        Me.xrChart1.DataSource = Me.dsAllReports1
        xyDiagram1.AxisX.VisibleInPanesSerializable = "-1"
        xyDiagram1.AxisY.VisibleInPanesSerializable = "-1"
        xyDiagram1.DefaultPane.EnableAxisXScrolling = DevExpress.Utils.DefaultBoolean.[False]
        xyDiagram1.DefaultPane.EnableAxisXZooming = DevExpress.Utils.DefaultBoolean.[False]
        xyDiagram1.DefaultPane.EnableAxisYScrolling = DevExpress.Utils.DefaultBoolean.[False]
        xyDiagram1.DefaultPane.EnableAxisYZooming = DevExpress.Utils.DefaultBoolean.[False]
        Me.xrChart1.Diagram = xyDiagram1
        Me.xrChart1.Dpi = 254.0!
        Me.xrChart1.Legend.AlignmentHorizontal = DevExpress.XtraCharts.LegendAlignmentHorizontal.Left
        Me.xrChart1.Legend.AlignmentVertical = DevExpress.XtraCharts.LegendAlignmentVertical.BottomOutside
        Me.xrChart1.Legend.Direction = DevExpress.XtraCharts.LegendDirection.LeftToRight
        Me.xrChart1.Legend.EquallySpacedItems = False
        Me.xrChart1.LocationFloat = New DevExpress.Utils.PointFloat(25.00001!, 289.5623!)
        Me.xrChart1.Name = "xrChart1"
        Me.xrChart1.SeriesDataMember = "Chartt"
        Me.xrChart1.SeriesSerializable = New DevExpress.XtraCharts.Series(-1) {}
        Me.xrChart1.SeriesTemplate.ArgumentDataMember = "Variable"
        Me.xrChart1.SeriesTemplate.ArgumentScaleType = DevExpress.XtraCharts.ScaleType.Qualitative
        pointOptions1.PointView = DevExpress.XtraCharts.PointView.ArgumentAndValues
        sideBySideBarSeriesLabel1.PointOptions = pointOptions1
        sideBySideBarSeriesLabel1.ResolveOverlappingMode = DevExpress.XtraCharts.ResolveOverlappingMode.[Default]
        Me.xrChart1.SeriesTemplate.Label = sideBySideBarSeriesLabel1
        Me.xrChart1.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.[True]
        Me.xrChart1.SeriesTemplate.ValueDataMembersSerializable = "SumApps"
        Me.xrChart1.SizeF = New System.Drawing.SizeF(1601.0!, 1272.646!)
        '
        'xrLabel1
        '
        Me.xrLabel1.Dpi = 254.0!
        Me.xrLabel1.LocationFloat = New DevExpress.Utils.PointFloat(15.99999!, 66.27083!)
        Me.xrLabel1.Name = "xrLabel1"
        Me.xrLabel1.Padding = New DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254.0!)
        Me.xrLabel1.SizeF = New System.Drawing.SizeF(1619.0!, 84.0!)
        Me.xrLabel1.StyleName = "Title"
        Me.xrLabel1.Text = "[Chartt] Report"
        '
        'Title
        '
        Me.Title.BackColor = System.Drawing.Color.Transparent
        Me.Title.BorderColor = System.Drawing.Color.Black
        Me.Title.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.Title.BorderWidth = 1.0!
        Me.Title.Font = New System.Drawing.Font("Times New Roman", 20.0!, System.Drawing.FontStyle.Bold)
        Me.Title.ForeColor = System.Drawing.Color.Maroon
        Me.Title.Name = "Title"
        '
        'FieldCaption
        '
        Me.FieldCaption.BackColor = System.Drawing.Color.Transparent
        Me.FieldCaption.BorderColor = System.Drawing.Color.Black
        Me.FieldCaption.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
        Me.FieldCaption.BorderWidth = 1.0!
        Me.FieldCaption.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.FieldCaption.ForeColor = System.Drawing.Color.Maroon
        Me.FieldCaption.Name = "FieldCaption"
        '
        'PageInfo
        '
        Me.PageInfo.BackColor = System.Drawing.Color.Transparent
        Me.PageInfo.BorderColor = System.Drawing.Color.Black
        Me.PageInfo.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.PageInfo.BorderWidth = 1.0!
        Me.PageInfo.Font = New System.Drawing.Font("Times New Roman", 10.0!, System.Drawing.FontStyle.Bold)
        Me.PageInfo.ForeColor = System.Drawing.Color.Black
        Me.PageInfo.Name = "PageInfo"
        '
        'DataField
        '
        Me.DataField.BackColor = System.Drawing.Color.Transparent
        Me.DataField.BorderColor = System.Drawing.Color.Black
        Me.DataField.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.DataField.BorderWidth = 1.0!
        Me.DataField.Font = New System.Drawing.Font("Times New Roman", 10.0!)
        Me.DataField.ForeColor = System.Drawing.Color.Black
        Me.DataField.Name = "DataField"
        Me.DataField.Padding = New DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254.0!)
        '
        'topMarginBand1
        '
        Me.topMarginBand1.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.xrLabel1, Me.xrLabel2, Me.xrChart1})
        Me.topMarginBand1.Dpi = 254.0!
        Me.topMarginBand1.HeightF = 1562.208!
        Me.topMarginBand1.Name = "topMarginBand1"
        '
        'bottomMarginBand1
        '
        Me.bottomMarginBand1.Dpi = 254.0!
        Me.bottomMarginBand1.HeightF = 259.0!
        Me.bottomMarginBand1.Name = "bottomMarginBand1"
        '
        'fromDate
        '
        Me.fromDate.Description = "From"
        Me.fromDate.Name = "fromDate"
        Me.fromDate.Type = GetType(Date)
        Me.fromDate.ValueInfo = "2016-01-01"
        '
        'grouping
        '
        Me.grouping.Description = "Group By"
        dynamicListLookUpSettings1.DataAdapter = Me.reportsGroupingTableAdapter1
        dynamicListLookUpSettings1.DataMember = "ReportsGrouping"
        dynamicListLookUpSettings1.DataSource = Me.dsChartTypes1
        dynamicListLookUpSettings1.DisplayMember = "GroupingName"
        dynamicListLookUpSettings1.ValueMember = "GroupingValue"
        Me.grouping.LookUpSettings = dynamicListLookUpSettings1
        Me.grouping.Name = "grouping"
        Me.grouping.ValueInfo = "Branch"
        '
        'GroupFooter1
        '
        Me.GroupFooter1.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.xrTable3})
        Me.GroupFooter1.Dpi = 254.0!
        Me.GroupFooter1.HeightF = 254.0!
        Me.GroupFooter1.Name = "GroupFooter1"
        '
        'xrTable3
        '
        Me.xrTable3.AnchorVertical = CType((DevExpress.XtraReports.UI.VerticalAnchorStyles.Top Or DevExpress.XtraReports.UI.VerticalAnchorStyles.Bottom), DevExpress.XtraReports.UI.VerticalAnchorStyles)
        Me.xrTable3.Dpi = 254.0!
        Me.xrTable3.LocationFloat = New DevExpress.Utils.PointFloat(15.99999!, 0!)
        Me.xrTable3.Name = "xrTable3"
        Me.xrTable3.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.xrTableRow7})
        Me.xrTable3.SizeF = New System.Drawing.SizeF(1618.0!, 84.375!)
        '
        'xrTableRow7
        '
        Me.xrTableRow7.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.xrTableCell21, Me.xrTableCell22, Me.xrTableCell23, Me.xrTableCell24})
        Me.xrTableRow7.Dpi = 254.0!
        Me.xrTableRow7.Name = "xrTableRow7"
        Me.xrTableRow7.Weight = 1.0R
        '
        'xrTableCell21
        '
        Me.xrTableCell21.Borders = DevExpress.XtraPrinting.BorderSide.Top
        Me.xrTableCell21.CanGrow = False
        Me.xrTableCell21.Dpi = 254.0!
        Me.xrTableCell21.Font = New System.Drawing.Font("Times New Roman", 10.0!, System.Drawing.FontStyle.Bold)
        Me.xrTableCell21.Name = "xrTableCell21"
        Me.xrTableCell21.StyleName = "DataField"
        Me.xrTableCell21.StylePriority.UseBorders = False
        Me.xrTableCell21.StylePriority.UseFont = False
        Me.xrTableCell21.Text = "Total"
        Me.xrTableCell21.Weight = 301.52174481178542R
        '
        'xrTableCell22
        '
        Me.xrTableCell22.Borders = DevExpress.XtraPrinting.BorderSide.Top
        Me.xrTableCell22.CanGrow = False
        Me.xrTableCell22.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "LoansAnalysis.NoClients")})
        Me.xrTableCell22.Dpi = 254.0!
        Me.xrTableCell22.Font = New System.Drawing.Font("Times New Roman", 10.0!, System.Drawing.FontStyle.Bold)
        Me.xrTableCell22.Name = "xrTableCell22"
        Me.xrTableCell22.StyleName = "DataField"
        Me.xrTableCell22.StylePriority.UseBorders = False
        Me.xrTableCell22.StylePriority.UseFont = False
        xrSummary1.FormatString = "{0:#,#}"
        xrSummary1.IgnoreNullValues = True
        xrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
        Me.xrTableCell22.Summary = xrSummary1
        Me.xrTableCell22.Weight = 186.00414571302341R
        '
        'xrTableCell23
        '
        Me.xrTableCell23.Borders = DevExpress.XtraPrinting.BorderSide.Top
        Me.xrTableCell23.CanGrow = False
        Me.xrTableCell23.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "LoansAnalysis.NoApps")})
        Me.xrTableCell23.Dpi = 254.0!
        Me.xrTableCell23.Font = New System.Drawing.Font("Times New Roman", 10.0!, System.Drawing.FontStyle.Bold)
        Me.xrTableCell23.Name = "xrTableCell23"
        Me.xrTableCell23.StyleName = "DataField"
        Me.xrTableCell23.StylePriority.UseBorders = False
        Me.xrTableCell23.StylePriority.UseFont = False
        xrSummary2.FormatString = "{0:#,#}"
        xrSummary2.IgnoreNullValues = True
        xrSummary2.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
        Me.xrTableCell23.Summary = xrSummary2
        Me.xrTableCell23.Weight = 166.18070253954534R
        '
        'xrTableCell24
        '
        Me.xrTableCell24.Borders = DevExpress.XtraPrinting.BorderSide.Top
        Me.xrTableCell24.CanGrow = False
        Me.xrTableCell24.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "LoansAnalysis.SumApps")})
        Me.xrTableCell24.Dpi = 254.0!
        Me.xrTableCell24.Font = New System.Drawing.Font("Times New Roman", 10.0!, System.Drawing.FontStyle.Bold)
        Me.xrTableCell24.Name = "xrTableCell24"
        Me.xrTableCell24.StyleName = "DataField"
        Me.xrTableCell24.StylePriority.UseBorders = False
        Me.xrTableCell24.StylePriority.UseFont = False
        Me.xrTableCell24.StylePriority.UseTextAlignment = False
        xrSummary3.FormatString = "{0:n2}"
        xrSummary3.IgnoreNullValues = True
        xrSummary3.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
        Me.xrTableCell24.Summary = xrSummary3
        Me.xrTableCell24.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        Me.xrTableCell24.Weight = 154.29340693564586R
        '
        'chartType
        '
        Me.chartType.Description = "Chart Option"
        dynamicListLookUpSettings2.DataAdapter = Me.chartOptionsTableAdapter1
        dynamicListLookUpSettings2.DataMember = "ChartOptions"
        dynamicListLookUpSettings2.DataSource = Me.dsChartTypes1
        dynamicListLookUpSettings2.DisplayMember = "ChartType"
        dynamicListLookUpSettings2.ValueMember = "ChartValue"
        Me.chartType.LookUpSettings = dynamicListLookUpSettings2
        Me.chartType.Name = "chartType"
        Me.chartType.ValueInfo = "3D Pie"
        '
        'xrptLoanAnalysis
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.pageHeaderBand1, Me.pageFooterBand1, Me.reportHeaderBand1, Me.topMarginBand1, Me.bottomMarginBand1, Me.GroupFooter1})
        Me.DataAdapter = Me.loansAnalysisTableAdapter1
        Me.DataMember = "LoansAnalysis"
        Me.DataSource = Me.dsAllReports1
        Me.Dpi = 254.0!
        Me.Margins = New System.Drawing.Printing.Margins(254, 254, 1562, 259)
        Me.PageHeight = 2794
        Me.PageWidth = 2159
        Me.Parameters.AddRange(New DevExpress.XtraReports.Parameters.Parameter() {Me.grouping, Me.fromDate, Me.toDate, Me.chartType})
        Me.ReportUnit = DevExpress.XtraReports.UI.ReportUnit.TenthsOfAMillimeter
        Me.StyleSheet.AddRange(New DevExpress.XtraReports.UI.XRControlStyle() {Me.Title, Me.FieldCaption, Me.PageInfo, Me.DataField})
        Me.Version = "13.2"
        CType(Me.dsChartTypes1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dsChartTypes2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.xrTable2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dsAllReports1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.xrTable1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(xyDiagram1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(sideBySideBarSeriesLabel1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.xrChart1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.xrTable3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
#End Region

    Private Sub xrptLoanAnalysis_DataSourceDemanded(sender As Object, e As EventArgs) Handles Me.DataSourceDemanded
        'If IsDate(toDate.Value.ToString) Then
        '    loanGradingTableAdapter1.FillByDate(dsAnalystReports1.LoanGrading, toDate.Value.ToString)
        'Else
        '    loanGradingTableAdapter1.Fill(dsAnalystReports1.LoanGrading)
        'End If
        If grouping.Value = "Branch" Then
            Try
                loansAnalysisTableAdapter1.FillByBranch(dsAllReports1.LoansAnalysis, fromDate.Value, toDate.Value)
            Catch ex As Exception
            End Try
        ElseIf grouping.Value = "Sector" Then
            Try
                loansAnalysisTableAdapter1.FillBySector(dsAllReports1.LoansAnalysis, fromDate.Value, toDate.Value)
            Catch ex As Exception
            End Try
        ElseIf grouping.Value = "Product" Then
            Try
                loansAnalysisTableAdapter1.FillByLoanPurpose(dsAllReports1.LoansAnalysis, fromDate.Value, toDate.Value)
            Catch ex As Exception
            End Try
        ElseIf grouping.Value = "Applicant" Then
            Try
                loansAnalysisTableAdapter1.FillByCustomerType(dsAllReports1.LoansAnalysis, fromDate.Value, toDate.Value)
            Catch ex As Exception
            End Try
        ElseIf grouping.Value = "Officer" Then
            Try
                loansAnalysisTableAdapter1.FillByLoanOfficer(dsAllReports1.LoansAnalysis, fromDate.Value, toDate.Value)
            Catch ex As Exception
            End Try
        ElseIf grouping.Value = "Gender" Then
            Try
                loansAnalysisTableAdapter1.FillByGender(dsAllReports1.LoansAnalysis, fromDate.Value, toDate.Value)
            Catch ex As Exception
            End Try
        Else
            Try
                loansAnalysisTableAdapter1.FillByBranch(dsAllReports1.LoansAnalysis, fromDate.Value, toDate.Value)
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub xrChart1_BoundDataChanged(sender As Object, e As EventArgs) Handles xrChart1.BoundDataChanged
        Dim chart As DevExpress.XtraReports.UI.XRChart = CType(sender, DevExpress.XtraReports.UI.XRChart)
        Charts.changeViewType(chart, Me.chartType.Value)
    End Sub

    Private Sub xrChart1_PrintOnPage(sender As Object, e As DevExpress.XtraReports.UI.PrintOnPageEventArgs) Handles xrChart1.PrintOnPage
        If e.PageIndex <> 0 Then
            e.Cancel = True
        End If
    End Sub
End Class