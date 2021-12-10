Public Class xrptSummaryAgingArrears
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
    Private WithEvents dsAllReports1 As dsAllReports
    Private WithEvents loansAnalysisTableAdapter1 As dsAllReportsTableAdapters.LoansAnalysisTableAdapter
    Private WithEvents reportsGroupingTableAdapter1 As dsChartTypesTableAdapters.ReportsGroupingTableAdapter
    Private WithEvents xrTableRow3 As DevExpress.XtraReports.UI.XRTableRow
    Private WithEvents xrTableCell7 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell8 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell9 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableRow4 As DevExpress.XtraReports.UI.XRTableRow
    Private WithEvents xrTableCell10 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell11 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell12 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents fromDate As DevExpress.XtraReports.Parameters.Parameter
    Private WithEvents dsChartTypes1 As dsChartTypes
    Private WithEvents grouping As DevExpress.XtraReports.Parameters.Parameter
    Private WithEvents dsChartTypes2 As dsChartTypes
    Private WithEvents chartOptionsTableAdapter1 As dsChartTypesTableAdapters.ChartOptionsTableAdapter
    Private WithEvents chartType As DevExpress.XtraReports.Parameters.Parameter
    Private WithEvents xrTable2 As DevExpress.XtraReports.UI.XRTable
    Private WithEvents xrTableRow8 As DevExpress.XtraReports.UI.XRTableRow
    Private WithEvents xrTableCell20 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell22 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell24 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell26 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell28 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell30 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell32 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents agingArrearsStatsTableAdapter1 As dsAllReportsTableAdapters.AgingArrearsStatsTableAdapter
    Private WithEvents pageHeaderBand1 As DevExpress.XtraReports.UI.PageHeaderBand
    Private WithEvents xrTable1 As DevExpress.XtraReports.UI.XRTable
    Private WithEvents xrTableRow7 As DevExpress.XtraReports.UI.XRTableRow
    Private WithEvents xrTableCell19 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell21 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell23 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell25 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell27 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell29 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell31 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableRow5 As DevExpress.XtraReports.UI.XRTableRow
    Private WithEvents xrTableCell13 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell14 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell15 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableRow6 As DevExpress.XtraReports.UI.XRTableRow
    Private WithEvents xrTableCell16 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell17 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell18 As DevExpress.XtraReports.UI.XRTableCell
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
    Private WithEvents GroupFooter1 As DevExpress.XtraReports.UI.GroupFooterBand
    Private WithEvents xrTable3 As DevExpress.XtraReports.UI.XRTable
    Private WithEvents xrTableRow9 As DevExpress.XtraReports.UI.XRTableRow
    Private WithEvents xrTableCell33 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell34 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell35 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell36 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell37 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell38 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell39 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrChart1 As DevExpress.XtraReports.UI.XRChart
    Private WithEvents agingArrearsStatsChartTableAdapter1 As dsAllReportsTableAdapters.AgingArrearsStatsChartTableAdapter
    Private WithEvents xrLabel2 As DevExpress.XtraReports.UI.XRLabel
    'Private WithEvents chartType As DevExpress.XtraReports.Parameters.Parameter

    'Required by the Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Designer
    'It can be modified using the Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resourceFileName As String = "xrptSummaryAgingArrears.resx"
        Dim dynamicListLookUpSettings1 As DevExpress.XtraReports.Parameters.DynamicListLookUpSettings = New DevExpress.XtraReports.Parameters.DynamicListLookUpSettings()
        Dim dynamicListLookUpSettings2 As DevExpress.XtraReports.Parameters.DynamicListLookUpSettings = New DevExpress.XtraReports.Parameters.DynamicListLookUpSettings()
        Dim xyDiagram1 As DevExpress.XtraCharts.XYDiagram = New DevExpress.XtraCharts.XYDiagram()
        Dim sideBySideBarSeriesLabel1 As DevExpress.XtraCharts.SideBySideBarSeriesLabel = New DevExpress.XtraCharts.SideBySideBarSeriesLabel()
        Dim pointOptions1 As DevExpress.XtraCharts.PointOptions = New DevExpress.XtraCharts.PointOptions()
        Dim xrSummary1 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
        Dim xrSummary2 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
        Dim xrSummary3 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
        Dim xrSummary4 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
        Dim xrSummary5 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
        Dim xrSummary6 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
        Me.reportsGroupingTableAdapter1 = New dsChartTypesTableAdapters.ReportsGroupingTableAdapter()
        Me.dsChartTypes1 = New dsChartTypes()
        Me.chartOptionsTableAdapter1 = New dsChartTypesTableAdapters.ChartOptionsTableAdapter()
        Me.dsChartTypes2 = New dsChartTypes()
        Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
        Me.xrTable2 = New DevExpress.XtraReports.UI.XRTable()
        Me.xrTableRow8 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.xrTableCell20 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell22 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell24 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell26 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell28 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell30 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell32 = New DevExpress.XtraReports.UI.XRTableCell()
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
        Me.xrTableRow3 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.xrTableCell7 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell8 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell9 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableRow4 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.xrTableCell10 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell11 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell12 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.fromDate = New DevExpress.XtraReports.Parameters.Parameter()
        Me.grouping = New DevExpress.XtraReports.Parameters.Parameter()
        Me.chartType = New DevExpress.XtraReports.Parameters.Parameter()
        Me.agingArrearsStatsTableAdapter1 = New dsAllReportsTableAdapters.AgingArrearsStatsTableAdapter()
        Me.pageHeaderBand1 = New DevExpress.XtraReports.UI.PageHeaderBand()
        Me.xrTable1 = New DevExpress.XtraReports.UI.XRTable()
        Me.xrTableRow7 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.xrTableCell19 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell21 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell23 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell25 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell27 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell29 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell31 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableRow5 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.xrTableCell13 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell14 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell15 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableRow6 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.xrTableCell16 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell17 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell18 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.pageFooterBand1 = New DevExpress.XtraReports.UI.PageFooterBand()
        Me.xrPageInfo1 = New DevExpress.XtraReports.UI.XRPageInfo()
        Me.xrPageInfo2 = New DevExpress.XtraReports.UI.XRPageInfo()
        Me.reportHeaderBand1 = New DevExpress.XtraReports.UI.ReportHeaderBand()
        Me.xrChart1 = New DevExpress.XtraReports.UI.XRChart()
        Me.agingArrearsStatsChartTableAdapter1 = New dsAllReportsTableAdapters.AgingArrearsStatsChartTableAdapter()
        Me.xrLabel1 = New DevExpress.XtraReports.UI.XRLabel()
        Me.Title = New DevExpress.XtraReports.UI.XRControlStyle()
        Me.FieldCaption = New DevExpress.XtraReports.UI.XRControlStyle()
        Me.PageInfo = New DevExpress.XtraReports.UI.XRControlStyle()
        Me.DataField = New DevExpress.XtraReports.UI.XRControlStyle()
        Me.topMarginBand1 = New DevExpress.XtraReports.UI.TopMarginBand()
        Me.bottomMarginBand1 = New DevExpress.XtraReports.UI.BottomMarginBand()
        Me.GroupFooter1 = New DevExpress.XtraReports.UI.GroupFooterBand()
        Me.xrTable3 = New DevExpress.XtraReports.UI.XRTable()
        Me.xrTableRow9 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.xrTableCell33 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell34 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell35 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell36 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell37 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell38 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell39 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrLabel2 = New DevExpress.XtraReports.UI.XRLabel()
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
        Me.xrTable2.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.xrTableRow8})
        Me.xrTable2.SizeF = New System.Drawing.SizeF(1619.0!, 58.42!)
        '
        'xrTableRow8
        '
        Me.xrTableRow8.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.xrTableCell20, Me.xrTableCell22, Me.xrTableCell24, Me.xrTableCell26, Me.xrTableCell28, Me.xrTableCell30, Me.xrTableCell32})
        Me.xrTableRow8.Dpi = 254.0!
        Me.xrTableRow8.Name = "xrTableRow8"
        Me.xrTableRow8.Weight = 1.0R
        '
        'xrTableCell20
        '
        Me.xrTableCell20.CanGrow = False
        Me.xrTableCell20.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "AgingArrearsStats.Variable")})
        Me.xrTableCell20.Dpi = 254.0!
        Me.xrTableCell20.Name = "xrTableCell20"
        Me.xrTableCell20.StyleName = "DataField"
        Me.xrTableCell20.Text = "xrTableCell20"
        Me.xrTableCell20.Weight = 145.2021824171299R
        '
        'xrTableCell22
        '
        Me.xrTableCell22.CanGrow = False
        Me.xrTableCell22.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "AgingArrearsStats.Unexpired", "{0:n2}")})
        Me.xrTableCell22.Dpi = 254.0!
        Me.xrTableCell22.Name = "xrTableCell22"
        Me.xrTableCell22.StyleName = "DataField"
        Me.xrTableCell22.StylePriority.UseTextAlignment = False
        Me.xrTableCell22.Text = "xrTableCell22"
        Me.xrTableCell22.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        Me.xrTableCell22.Weight = 67.008983691386121R
        '
        'xrTableCell24
        '
        Me.xrTableCell24.CanGrow = False
        Me.xrTableCell24.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "AgingArrearsStats.1-30Days", "{0:n2}")})
        Me.xrTableCell24.Dpi = 254.0!
        Me.xrTableCell24.Name = "xrTableCell24"
        Me.xrTableCell24.StyleName = "DataField"
        Me.xrTableCell24.StylePriority.UseTextAlignment = False
        Me.xrTableCell24.Text = "xrTableCell24"
        Me.xrTableCell24.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        Me.xrTableCell24.Weight = 62.611966700766942R
        '
        'xrTableCell26
        '
        Me.xrTableCell26.CanGrow = False
        Me.xrTableCell26.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "AgingArrearsStats.31-60Days", "{0:n2}")})
        Me.xrTableCell26.Dpi = 254.0!
        Me.xrTableCell26.Name = "xrTableCell26"
        Me.xrTableCell26.StyleName = "DataField"
        Me.xrTableCell26.StylePriority.UseTextAlignment = False
        Me.xrTableCell26.Text = "xrTableCell26"
        Me.xrTableCell26.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        Me.xrTableCell26.Weight = 63.192399450454872R
        '
        'xrTableCell28
        '
        Me.xrTableCell28.CanGrow = False
        Me.xrTableCell28.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "AgingArrearsStats.61-90Days", "{0:n2}")})
        Me.xrTableCell28.Dpi = 254.0!
        Me.xrTableCell28.Name = "xrTableCell28"
        Me.xrTableCell28.StyleName = "DataField"
        Me.xrTableCell28.StylePriority.UseTextAlignment = False
        Me.xrTableCell28.Text = "xrTableCell28"
        Me.xrTableCell28.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        Me.xrTableCell28.Weight = 68.008968460871557R
        '
        'xrTableCell30
        '
        Me.xrTableCell30.CanGrow = False
        Me.xrTableCell30.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "AgingArrearsStats.91-180Days", "{0:n2}")})
        Me.xrTableCell30.Dpi = 254.0!
        Me.xrTableCell30.Name = "xrTableCell30"
        Me.xrTableCell30.StyleName = "DataField"
        Me.xrTableCell30.StylePriority.UseTextAlignment = False
        Me.xrTableCell30.Text = "xrTableCell30"
        Me.xrTableCell30.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        Me.xrTableCell30.Weight = 67.325574818721691R
        '
        'xrTableCell32
        '
        Me.xrTableCell32.CanGrow = False
        Me.xrTableCell32.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "AgingArrearsStats.>180Days", "{0:n2}")})
        Me.xrTableCell32.Dpi = 254.0!
        Me.xrTableCell32.Name = "xrTableCell32"
        Me.xrTableCell32.StyleName = "DataField"
        Me.xrTableCell32.StylePriority.UseTextAlignment = False
        Me.xrTableCell32.Text = "xrTableCell32"
        Me.xrTableCell32.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        Me.xrTableCell32.Weight = 65.316591127335542R
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
        Me.toDate.Visible = False
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
        'fromDate
        '
        Me.fromDate.Description = "From"
        Me.fromDate.Name = "fromDate"
        Me.fromDate.Type = GetType(Date)
        Me.fromDate.ValueInfo = "2016-01-01"
        Me.fromDate.Visible = False
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
        Me.chartType.ValueInfo = "Bar"
        '
        'agingArrearsStatsTableAdapter1
        '
        Me.agingArrearsStatsTableAdapter1.ClearBeforeFill = True
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
        Me.xrTable1.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.xrTableRow7})
        Me.xrTable1.SizeF = New System.Drawing.SizeF(1619.0!, 90.0!)
        '
        'xrTableRow7
        '
        Me.xrTableRow7.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.xrTableCell19, Me.xrTableCell21, Me.xrTableCell23, Me.xrTableCell25, Me.xrTableCell27, Me.xrTableCell29, Me.xrTableCell31})
        Me.xrTableRow7.Dpi = 254.0!
        Me.xrTableRow7.Name = "xrTableRow7"
        Me.xrTableRow7.Weight = 1.0R
        '
        'xrTableCell19
        '
        Me.xrTableCell19.CanGrow = False
        Me.xrTableCell19.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "AgingArrearsStats.VariableName")})
        Me.xrTableCell19.Dpi = 254.0!
        Me.xrTableCell19.Name = "xrTableCell19"
        Me.xrTableCell19.StyleName = "FieldCaption"
        Me.xrTableCell19.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        Me.xrTableCell19.Weight = 145.2021824171299R
        '
        'xrTableCell21
        '
        Me.xrTableCell21.CanGrow = False
        Me.xrTableCell21.Dpi = 254.0!
        Me.xrTableCell21.Name = "xrTableCell21"
        Me.xrTableCell21.StyleName = "FieldCaption"
        Me.xrTableCell21.StylePriority.UseTextAlignment = False
        Me.xrTableCell21.Text = "Unexpired"
        Me.xrTableCell21.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.xrTableCell21.Weight = 67.008983691386121R
        '
        'xrTableCell23
        '
        Me.xrTableCell23.CanGrow = False
        Me.xrTableCell23.Dpi = 254.0!
        Me.xrTableCell23.Name = "xrTableCell23"
        Me.xrTableCell23.StyleName = "FieldCaption"
        Me.xrTableCell23.StylePriority.UseTextAlignment = False
        Me.xrTableCell23.Text = "1-30Days"
        Me.xrTableCell23.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.xrTableCell23.Weight = 62.611966700766942R
        '
        'xrTableCell25
        '
        Me.xrTableCell25.CanGrow = False
        Me.xrTableCell25.Dpi = 254.0!
        Me.xrTableCell25.Name = "xrTableCell25"
        Me.xrTableCell25.StyleName = "FieldCaption"
        Me.xrTableCell25.StylePriority.UseTextAlignment = False
        Me.xrTableCell25.Text = "31-60Days"
        Me.xrTableCell25.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.xrTableCell25.Weight = 63.192399450454872R
        '
        'xrTableCell27
        '
        Me.xrTableCell27.CanGrow = False
        Me.xrTableCell27.Dpi = 254.0!
        Me.xrTableCell27.Name = "xrTableCell27"
        Me.xrTableCell27.StyleName = "FieldCaption"
        Me.xrTableCell27.StylePriority.UseTextAlignment = False
        Me.xrTableCell27.Text = "61-90Days"
        Me.xrTableCell27.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.xrTableCell27.Weight = 68.008968460871557R
        '
        'xrTableCell29
        '
        Me.xrTableCell29.CanGrow = False
        Me.xrTableCell29.Dpi = 254.0!
        Me.xrTableCell29.Name = "xrTableCell29"
        Me.xrTableCell29.StyleName = "FieldCaption"
        Me.xrTableCell29.StylePriority.UseTextAlignment = False
        Me.xrTableCell29.Text = "91-180Days"
        Me.xrTableCell29.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.xrTableCell29.Weight = 67.325574818721691R
        '
        'xrTableCell31
        '
        Me.xrTableCell31.CanGrow = False
        Me.xrTableCell31.Dpi = 254.0!
        Me.xrTableCell31.Name = "xrTableCell31"
        Me.xrTableCell31.StyleName = "FieldCaption"
        Me.xrTableCell31.StylePriority.UseTextAlignment = False
        Me.xrTableCell31.Text = ">180Days"
        Me.xrTableCell31.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.xrTableCell31.Weight = 65.316591127335542R
        '
        'xrTableRow5
        '
        Me.xrTableRow5.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.xrTableCell13, Me.xrTableCell14, Me.xrTableCell15})
        Me.xrTableRow5.Dpi = 254.0!
        Me.xrTableRow5.Name = "xrTableRow5"
        Me.xrTableRow5.Weight = 1.0R
        '
        'xrTableCell13
        '
        Me.xrTableCell13.Dpi = 254.0!
        Me.xrTableCell13.Name = "xrTableCell13"
        Me.xrTableCell13.Weight = 1.0R
        '
        'xrTableCell14
        '
        Me.xrTableCell14.Dpi = 254.0!
        Me.xrTableCell14.Name = "xrTableCell14"
        Me.xrTableCell14.Weight = 1.0R
        '
        'xrTableCell15
        '
        Me.xrTableCell15.Dpi = 254.0!
        Me.xrTableCell15.Name = "xrTableCell15"
        Me.xrTableCell15.Weight = 1.0R
        '
        'xrTableRow6
        '
        Me.xrTableRow6.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.xrTableCell16, Me.xrTableCell17, Me.xrTableCell18})
        Me.xrTableRow6.Dpi = 254.0!
        Me.xrTableRow6.Name = "xrTableRow6"
        Me.xrTableRow6.Weight = 1.0R
        '
        'xrTableCell16
        '
        Me.xrTableCell16.Dpi = 254.0!
        Me.xrTableCell16.Name = "xrTableCell16"
        Me.xrTableCell16.Weight = 1.0R
        '
        'xrTableCell17
        '
        Me.xrTableCell17.Dpi = 254.0!
        Me.xrTableCell17.Name = "xrTableCell17"
        Me.xrTableCell17.Weight = 1.0R
        '
        'xrTableCell18
        '
        Me.xrTableCell18.Dpi = 254.0!
        Me.xrTableCell18.Name = "xrTableCell18"
        Me.xrTableCell18.Weight = 1.0R
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
        Me.reportHeaderBand1.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.xrLabel2, Me.xrChart1, Me.xrLabel1})
        Me.reportHeaderBand1.Dpi = 254.0!
        Me.reportHeaderBand1.HeightF = 1276.458!
        Me.reportHeaderBand1.Name = "reportHeaderBand1"
        '
        'xrChart1
        '
        Me.xrChart1.BorderColor = System.Drawing.Color.Black
        Me.xrChart1.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.xrChart1.DataAdapter = Me.agingArrearsStatsChartTableAdapter1
        Me.xrChart1.DataMember = "AgingArrearsStatsChart"
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
        Me.xrChart1.LocationFloat = New DevExpress.Utils.PointFloat(25.0!, 210.1874!)
        Me.xrChart1.Name = "xrChart1"
        Me.xrChart1.SeriesDataMember = "Variable"
        Me.xrChart1.SeriesSerializable = New DevExpress.XtraCharts.Series(-1) {}
        Me.xrChart1.SeriesTemplate.ArgumentDataMember = "DaysRange"
        Me.xrChart1.SeriesTemplate.ArgumentScaleType = DevExpress.XtraCharts.ScaleType.Qualitative
        pointOptions1.PointView = DevExpress.XtraCharts.PointView.ArgumentAndValues
        pointOptions1.ValueNumericOptions.Format = DevExpress.XtraCharts.NumericFormat.Number
        sideBySideBarSeriesLabel1.PointOptions = pointOptions1
        sideBySideBarSeriesLabel1.ResolveOverlappingMode = DevExpress.XtraCharts.ResolveOverlappingMode.[Default]
        Me.xrChart1.SeriesTemplate.Label = sideBySideBarSeriesLabel1
        Me.xrChart1.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.[False]
        Me.xrChart1.SeriesTemplate.ValueDataMembersSerializable = "Balance"
        Me.xrChart1.SizeF = New System.Drawing.SizeF(1601.0!, 1066.271!)
        '
        'agingArrearsStatsChartTableAdapter1
        '
        Me.agingArrearsStatsChartTableAdapter1.ClearBeforeFill = True
        '
        'xrLabel1
        '
        Me.xrLabel1.Dpi = 254.0!
        Me.xrLabel1.LocationFloat = New DevExpress.Utils.PointFloat(16.0!, 16.0!)
        Me.xrLabel1.Name = "xrLabel1"
        Me.xrLabel1.Padding = New DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254.0!)
        Me.xrLabel1.SizeF = New System.Drawing.SizeF(1619.0!, 84.0!)
        Me.xrLabel1.StyleName = "Title"
        Me.xrLabel1.Text = "Summary Aging Arrears Report"
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
        Me.topMarginBand1.Dpi = 254.0!
        Me.topMarginBand1.HeightF = 19.47911!
        Me.topMarginBand1.Name = "topMarginBand1"
        '
        'bottomMarginBand1
        '
        Me.bottomMarginBand1.Dpi = 254.0!
        Me.bottomMarginBand1.HeightF = 259.0!
        Me.bottomMarginBand1.Name = "bottomMarginBand1"
        '
        'GroupFooter1
        '
        Me.GroupFooter1.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.xrTable3})
        Me.GroupFooter1.Dpi = 254.0!
        Me.GroupFooter1.HeightF = 124.3542!
        Me.GroupFooter1.Name = "GroupFooter1"
        '
        'xrTable3
        '
        Me.xrTable3.AnchorVertical = CType((DevExpress.XtraReports.UI.VerticalAnchorStyles.Top Or DevExpress.XtraReports.UI.VerticalAnchorStyles.Bottom), DevExpress.XtraReports.UI.VerticalAnchorStyles)
        Me.xrTable3.Dpi = 254.0!
        Me.xrTable3.LocationFloat = New DevExpress.Utils.PointFloat(15.0!, 0!)
        Me.xrTable3.Name = "xrTable3"
        Me.xrTable3.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.xrTableRow9})
        Me.xrTable3.SizeF = New System.Drawing.SizeF(1619.0!, 58.42!)
        '
        'xrTableRow9
        '
        Me.xrTableRow9.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.xrTableCell33, Me.xrTableCell34, Me.xrTableCell35, Me.xrTableCell36, Me.xrTableCell37, Me.xrTableCell38, Me.xrTableCell39})
        Me.xrTableRow9.Dpi = 254.0!
        Me.xrTableRow9.Name = "xrTableRow9"
        Me.xrTableRow9.Weight = 1.0R
        '
        'xrTableCell33
        '
        Me.xrTableCell33.Borders = DevExpress.XtraPrinting.BorderSide.Top
        Me.xrTableCell33.CanGrow = False
        Me.xrTableCell33.Dpi = 254.0!
        Me.xrTableCell33.Font = New System.Drawing.Font("Times New Roman", 10.0!, System.Drawing.FontStyle.Bold)
        Me.xrTableCell33.Name = "xrTableCell33"
        Me.xrTableCell33.StyleName = "DataField"
        Me.xrTableCell33.StylePriority.UseBorders = False
        Me.xrTableCell33.StylePriority.UseFont = False
        Me.xrTableCell33.StylePriority.UseTextAlignment = False
        Me.xrTableCell33.Text = "Total"
        Me.xrTableCell33.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        Me.xrTableCell33.Weight = 145.2021824171299R
        '
        'xrTableCell34
        '
        Me.xrTableCell34.Borders = DevExpress.XtraPrinting.BorderSide.Top
        Me.xrTableCell34.CanGrow = False
        Me.xrTableCell34.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "AgingArrearsStats.Unexpired")})
        Me.xrTableCell34.Dpi = 254.0!
        Me.xrTableCell34.Font = New System.Drawing.Font("Times New Roman", 10.0!, System.Drawing.FontStyle.Bold)
        Me.xrTableCell34.Name = "xrTableCell34"
        Me.xrTableCell34.StyleName = "DataField"
        Me.xrTableCell34.StylePriority.UseBorders = False
        Me.xrTableCell34.StylePriority.UseFont = False
        Me.xrTableCell34.StylePriority.UseTextAlignment = False
        xrSummary1.FormatString = "{0:n2}"
        xrSummary1.IgnoreNullValues = True
        xrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
        Me.xrTableCell34.Summary = xrSummary1
        Me.xrTableCell34.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.xrTableCell34.Weight = 67.008993845062534R
        '
        'xrTableCell35
        '
        Me.xrTableCell35.Borders = DevExpress.XtraPrinting.BorderSide.Top
        Me.xrTableCell35.CanGrow = False
        Me.xrTableCell35.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "AgingArrearsStats.1-30Days")})
        Me.xrTableCell35.Dpi = 254.0!
        Me.xrTableCell35.Font = New System.Drawing.Font("Times New Roman", 10.0!, System.Drawing.FontStyle.Bold)
        Me.xrTableCell35.Name = "xrTableCell35"
        Me.xrTableCell35.StyleName = "DataField"
        Me.xrTableCell35.StylePriority.UseBorders = False
        Me.xrTableCell35.StylePriority.UseFont = False
        Me.xrTableCell35.StylePriority.UseTextAlignment = False
        xrSummary2.FormatString = "{0:n2}"
        xrSummary2.IgnoreNullValues = True
        xrSummary2.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
        Me.xrTableCell35.Summary = xrSummary2
        Me.xrTableCell35.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.xrTableCell35.Weight = 62.611956547090543R
        '
        'xrTableCell36
        '
        Me.xrTableCell36.Borders = DevExpress.XtraPrinting.BorderSide.Top
        Me.xrTableCell36.CanGrow = False
        Me.xrTableCell36.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "AgingArrearsStats.31-60Days")})
        Me.xrTableCell36.Dpi = 254.0!
        Me.xrTableCell36.Font = New System.Drawing.Font("Times New Roman", 10.0!, System.Drawing.FontStyle.Bold)
        Me.xrTableCell36.Name = "xrTableCell36"
        Me.xrTableCell36.StyleName = "DataField"
        Me.xrTableCell36.StylePriority.UseBorders = False
        Me.xrTableCell36.StylePriority.UseFont = False
        Me.xrTableCell36.StylePriority.UseTextAlignment = False
        xrSummary3.FormatString = "{0:n2}"
        xrSummary3.IgnoreNullValues = True
        xrSummary3.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
        Me.xrTableCell36.Summary = xrSummary3
        Me.xrTableCell36.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.xrTableCell36.Weight = 63.1923588357493R
        '
        'xrTableCell37
        '
        Me.xrTableCell37.Borders = DevExpress.XtraPrinting.BorderSide.Top
        Me.xrTableCell37.CanGrow = False
        Me.xrTableCell37.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "AgingArrearsStats.61-90Days")})
        Me.xrTableCell37.Dpi = 254.0!
        Me.xrTableCell37.Font = New System.Drawing.Font("Times New Roman", 10.0!, System.Drawing.FontStyle.Bold)
        Me.xrTableCell37.Name = "xrTableCell37"
        Me.xrTableCell37.StyleName = "DataField"
        Me.xrTableCell37.StylePriority.UseBorders = False
        Me.xrTableCell37.StylePriority.UseFont = False
        Me.xrTableCell37.StylePriority.UseTextAlignment = False
        xrSummary4.FormatString = "{0:n2}"
        xrSummary4.IgnoreNullValues = True
        xrSummary4.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
        Me.xrTableCell37.Summary = xrSummary4
        Me.xrTableCell37.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.xrTableCell37.Weight = 68.3417145900086R
        '
        'xrTableCell38
        '
        Me.xrTableCell38.Borders = DevExpress.XtraPrinting.BorderSide.Top
        Me.xrTableCell38.CanGrow = False
        Me.xrTableCell38.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "AgingArrearsStats.91-180Days")})
        Me.xrTableCell38.Dpi = 254.0!
        Me.xrTableCell38.Font = New System.Drawing.Font("Times New Roman", 10.0!, System.Drawing.FontStyle.Bold)
        Me.xrTableCell38.Name = "xrTableCell38"
        Me.xrTableCell38.StyleName = "DataField"
        Me.xrTableCell38.StylePriority.UseBorders = False
        Me.xrTableCell38.StylePriority.UseFont = False
        Me.xrTableCell38.StylePriority.UseTextAlignment = False
        xrSummary5.FormatString = "{0:n2}"
        xrSummary5.IgnoreNullValues = True
        xrSummary5.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
        Me.xrTableCell38.Summary = xrSummary5
        Me.xrTableCell38.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.xrTableCell38.Weight = 67.325574818721691R
        '
        'xrTableCell39
        '
        Me.xrTableCell39.Borders = DevExpress.XtraPrinting.BorderSide.Top
        Me.xrTableCell39.CanGrow = False
        Me.xrTableCell39.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "AgingArrearsStats.>180Days")})
        Me.xrTableCell39.Dpi = 254.0!
        Me.xrTableCell39.Font = New System.Drawing.Font("Times New Roman", 10.0!, System.Drawing.FontStyle.Bold)
        Me.xrTableCell39.Name = "xrTableCell39"
        Me.xrTableCell39.StyleName = "DataField"
        Me.xrTableCell39.StylePriority.UseBorders = False
        Me.xrTableCell39.StylePriority.UseFont = False
        Me.xrTableCell39.StylePriority.UseTextAlignment = False
        xrSummary6.FormatString = "{0:n2}"
        xrSummary6.IgnoreNullValues = True
        xrSummary6.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
        Me.xrTableCell39.Summary = xrSummary6
        Me.xrTableCell39.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.xrTableCell39.Weight = 64.983885612904061R
        '
        'xrLabel2
        '
        Me.xrLabel2.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "AgingArrearsStats.Chartt")})
        Me.xrLabel2.Dpi = 254.0!
        Me.xrLabel2.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.xrLabel2.LocationFloat = New DevExpress.Utils.PointFloat(16.0!, 123.5416!)
        Me.xrLabel2.Name = "xrLabel2"
        Me.xrLabel2.Padding = New DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254.0!)
        Me.xrLabel2.SizeF = New System.Drawing.SizeF(1619.0!, 60.1875!)
        Me.xrLabel2.StyleName = "Title"
        Me.xrLabel2.StylePriority.UseFont = False
        '
        'xrptSummaryAgingArrears
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.pageHeaderBand1, Me.pageFooterBand1, Me.reportHeaderBand1, Me.topMarginBand1, Me.bottomMarginBand1, Me.GroupFooter1})
        Me.DataAdapter = Me.agingArrearsStatsTableAdapter1
        Me.DataMember = "AgingArrearsStats"
        Me.DataSource = Me.dsAllReports1
        Me.Dpi = 254.0!
        Me.Margins = New System.Drawing.Printing.Margins(254, 254, 19, 259)
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

    Private Sub xrptSummaryAgingArrears_DataSourceDemanded(sender As Object, e As EventArgs) Handles Me.DataSourceDemanded
        If grouping.Value = "Branch" Then
            Try
                agingArrearsStatsTableAdapter1.FillByBranch(dsAllReports1.AgingArrearsStats)
                agingArrearsStatsChartTableAdapter1.FillByBranch(dsAllReports1.AgingArrearsStatsChart)
            Catch ex As Exception
                'ErrorLogging.WriteLogFile("", "Branch", ex.ToString)
            End Try
        ElseIf grouping.Value = "Sector" Then
            Try
                agingArrearsStatsTableAdapter1.FillBySector(dsAllReports1.AgingArrearsStats)
                agingArrearsStatsChartTableAdapter1.FillBySector(dsAllReports1.AgingArrearsStatsChart)
            Catch ex As Exception
                'ErrorLogging.WriteLogFile("", "Sector", ex.ToString)
            End Try

        ElseIf grouping.Value = "Product" Then
            Try
                agingArrearsStatsTableAdapter1.FillByLoanPurpose(dsAllReports1.AgingArrearsStats)
                agingArrearsStatsChartTableAdapter1.FillByLoanPurpose(dsAllReports1.AgingArrearsStatsChart)
            Catch ex As Exception
                'ErrorLogging.WriteLogFile("", "Product", ex.ToString)
            End Try

        ElseIf grouping.Value = "Applicant" Then
            Try
                agingArrearsStatsTableAdapter1.FillByCustomerType(dsAllReports1.AgingArrearsStats)
                agingArrearsStatsChartTableAdapter1.FillByCustomerType(dsAllReports1.AgingArrearsStatsChart)
            Catch ex As Exception
                'ErrorLogging.WriteLogFile("", "Applicant", ex.ToString)
            End Try
        ElseIf grouping.Value = "Officer" Then
            Try
                agingArrearsStatsTableAdapter1.FillByLoanOfficer(dsAllReports1.AgingArrearsStats)
                agingArrearsStatsChartTableAdapter1.FillByLoanOfficer(dsAllReports1.AgingArrearsStatsChart)
            Catch ex As Exception
                'ErrorLogging.WriteLogFile("", "Officer", ex.ToString)
            End Try
        ElseIf grouping.Value = "Gender" Then
            Try
                agingArrearsStatsTableAdapter1.FillByGender(dsAllReports1.AgingArrearsStats)
                agingArrearsStatsChartTableAdapter1.FillByGender(dsAllReports1.AgingArrearsStatsChart)
            Catch ex As Exception
                'ErrorLogging.WriteLogFile("", "Officer", ex.ToString)
            End Try
        Else
            Try
                agingArrearsStatsTableAdapter1.FillByBranch(dsAllReports1.AgingArrearsStats)
                agingArrearsStatsChartTableAdapter1.FillByBranch(dsAllReports1.AgingArrearsStatsChart)
            Catch ex As Exception
                'ErrorLogging.WriteLogFile("", "Branch", ex.ToString)
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