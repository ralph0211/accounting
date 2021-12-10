Public Class xrptMaturityAnalysis
    Inherits DevExpress.XtraReports.UI.XtraReport

#Region " Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'XtraReport overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub
    Private dsAnalystReports1 As dsAnalystReports
    Private maturityAnalysisTableAdapter1 As dsAnalystReportsTableAdapters.MaturityAnalysisTableAdapter
    Private WithEvents xrLabel6 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel7 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel8 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents groupHeaderBand1 As DevExpress.XtraReports.UI.GroupHeaderBand
    Private WithEvents groupHeaderBand2 As DevExpress.XtraReports.UI.GroupHeaderBand
    Private WithEvents xrLabel3 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel4 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel5 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLine1 As DevExpress.XtraReports.UI.XRLine
    Private WithEvents xrLine2 As DevExpress.XtraReports.UI.XRLine
    Private WithEvents pageFooterBand1 As DevExpress.XtraReports.UI.PageFooterBand
    Private WithEvents xrPageInfo1 As DevExpress.XtraReports.UI.XRPageInfo
    Private WithEvents xrPageInfo2 As DevExpress.XtraReports.UI.XRPageInfo
    Private WithEvents reportHeaderBand1 As DevExpress.XtraReports.UI.ReportHeaderBand
    Private WithEvents xrLabel9 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents groupFooterBand1 As DevExpress.XtraReports.UI.GroupFooterBand
    Private WithEvents groupFooterBand2 As DevExpress.XtraReports.UI.GroupFooterBand
    Private WithEvents xrLabel10 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel11 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel12 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel13 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel14 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel15 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel16 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel17 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel18 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel19 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel20 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel21 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents reportFooterBand1 As DevExpress.XtraReports.UI.ReportFooterBand
    Private WithEvents xrLabel22 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel23 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel24 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents Title As DevExpress.XtraReports.UI.XRControlStyle
    Private WithEvents FieldCaption As DevExpress.XtraReports.UI.XRControlStyle
    Private WithEvents PageInfo As DevExpress.XtraReports.UI.XRControlStyle
    Private WithEvents DataField As DevExpress.XtraReports.UI.XRControlStyle
    Private WithEvents topMarginBand1 As DevExpress.XtraReports.UI.TopMarginBand
    Private WithEvents bottomMarginBand1 As DevExpress.XtraReports.UI.BottomMarginBand
    Private WithEvents xrChart1 As DevExpress.XtraReports.UI.XRChart

    'Required by the Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Designer
    'It can be modified using the Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resourceFileName As String = "xrptMaturityAnalysis.resx"
        Dim xyDiagram1 As DevExpress.XtraCharts.XYDiagram = New DevExpress.XtraCharts.XYDiagram()
        Dim series1 As DevExpress.XtraCharts.Series = New DevExpress.XtraCharts.Series()
        Dim sideBySideBarSeriesLabel1 As DevExpress.XtraCharts.SideBySideBarSeriesLabel = New DevExpress.XtraCharts.SideBySideBarSeriesLabel()
        Dim pointOptions1 As DevExpress.XtraCharts.PointOptions = New DevExpress.XtraCharts.PointOptions()
        Dim series2 As DevExpress.XtraCharts.Series = New DevExpress.XtraCharts.Series()
        Dim sideBySideBarSeriesLabel2 As DevExpress.XtraCharts.SideBySideBarSeriesLabel = New DevExpress.XtraCharts.SideBySideBarSeriesLabel()
        Dim pointOptions2 As DevExpress.XtraCharts.PointOptions = New DevExpress.XtraCharts.PointOptions()
        Dim xrSummary1 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
        Dim xrSummary2 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
        Dim xrSummary3 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
        Dim xrSummary4 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
        Dim xrSummary5 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
        Dim xrSummary6 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
        Dim xrSummary7 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
        Dim xrSummary8 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
        Dim xrSummary9 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
        Dim xrSummary10 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
        Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
        Me.xrLabel6 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel7 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel8 = New DevExpress.XtraReports.UI.XRLabel()
        Me.dsAnalystReports1 = New dsAnalystReports()
        Me.maturityAnalysisTableAdapter1 = New dsAnalystReportsTableAdapters.MaturityAnalysisTableAdapter()
        Me.groupHeaderBand1 = New DevExpress.XtraReports.UI.GroupHeaderBand()
        Me.groupHeaderBand2 = New DevExpress.XtraReports.UI.GroupHeaderBand()
        Me.xrLabel3 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel4 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel5 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLine1 = New DevExpress.XtraReports.UI.XRLine()
        Me.xrLine2 = New DevExpress.XtraReports.UI.XRLine()
        Me.pageFooterBand1 = New DevExpress.XtraReports.UI.PageFooterBand()
        Me.xrPageInfo1 = New DevExpress.XtraReports.UI.XRPageInfo()
        Me.xrPageInfo2 = New DevExpress.XtraReports.UI.XRPageInfo()
        Me.reportHeaderBand1 = New DevExpress.XtraReports.UI.ReportHeaderBand()
        Me.xrLabel9 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrChart1 = New DevExpress.XtraReports.UI.XRChart()
        Me.groupFooterBand1 = New DevExpress.XtraReports.UI.GroupFooterBand()
        Me.groupFooterBand2 = New DevExpress.XtraReports.UI.GroupFooterBand()
        Me.xrLabel10 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel11 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel12 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel13 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel14 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel15 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel16 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel17 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel18 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel19 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel20 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel21 = New DevExpress.XtraReports.UI.XRLabel()
        Me.reportFooterBand1 = New DevExpress.XtraReports.UI.ReportFooterBand()
        Me.xrLabel22 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel23 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel24 = New DevExpress.XtraReports.UI.XRLabel()
        Me.Title = New DevExpress.XtraReports.UI.XRControlStyle()
        Me.FieldCaption = New DevExpress.XtraReports.UI.XRControlStyle()
        Me.PageInfo = New DevExpress.XtraReports.UI.XRControlStyle()
        Me.DataField = New DevExpress.XtraReports.UI.XRControlStyle()
        Me.topMarginBand1 = New DevExpress.XtraReports.UI.TopMarginBand()
        Me.bottomMarginBand1 = New DevExpress.XtraReports.UI.BottomMarginBand()
        CType(Me.dsAnalystReports1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.xrChart1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(xyDiagram1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(series1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(sideBySideBarSeriesLabel1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(series2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(sideBySideBarSeriesLabel2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.xrLabel6, Me.xrLabel7, Me.xrLabel8})
        Me.Detail.HeightF = 18.0!
        Me.Detail.Name = "Detail"
        Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.Detail.StyleName = "DataField"
        Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'xrLabel6
        '
        Me.xrLabel6.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
        Me.xrLabel6.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "MaturityAnalysis.MatRange")})
        Me.xrLabel6.LocationFloat = New DevExpress.Utils.PointFloat(36.0!, 0!)
        Me.xrLabel6.Name = "xrLabel6"
        Me.xrLabel6.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel6.SizeF = New System.Drawing.SizeF(147.5728!, 18.0!)
        Me.xrLabel6.StylePriority.UseBorders = False
        Me.xrLabel6.Text = "xrLabel6"
        '
        'xrLabel7
        '
        Me.xrLabel7.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
        Me.xrLabel7.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "MaturityAnalysis.PrincipalMaturity", "{0:n2}")})
        Me.xrLabel7.LocationFloat = New DevExpress.Utils.PointFloat(183.5728!, 0!)
        Me.xrLabel7.Name = "xrLabel7"
        Me.xrLabel7.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel7.SizeF = New System.Drawing.SizeF(238.0841!, 18.0!)
        Me.xrLabel7.StylePriority.UseBorders = False
        Me.xrLabel7.Text = "xrLabel7"
        '
        'xrLabel8
        '
        Me.xrLabel8.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
        Me.xrLabel8.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "MaturityAnalysis.InterestMaturity", "{0:n2}")})
        Me.xrLabel8.LocationFloat = New DevExpress.Utils.PointFloat(421.657!, 0!)
        Me.xrLabel8.Name = "xrLabel8"
        Me.xrLabel8.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel8.SizeF = New System.Drawing.SizeF(222.343!, 18.0!)
        Me.xrLabel8.StylePriority.UseBorders = False
        Me.xrLabel8.Text = "xrLabel8"
        '
        'dsAnalystReports1
        '
        Me.dsAnalystReports1.DataSetName = "dsAnalystReports"
        Me.dsAnalystReports1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'maturityAnalysisTableAdapter1
        '
        Me.maturityAnalysisTableAdapter1.ClearBeforeFill = True
        '
        'groupHeaderBand1
        '
        Me.groupHeaderBand1.GroupFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("Chartt", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
        Me.groupHeaderBand1.HeightF = 9.958331!
        Me.groupHeaderBand1.Level = 1
        Me.groupHeaderBand1.Name = "groupHeaderBand1"
        '
        'groupHeaderBand2
        '
        Me.groupHeaderBand2.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.xrLabel3, Me.xrLabel4, Me.xrLabel5, Me.xrLine1, Me.xrLine2})
        Me.groupHeaderBand2.HeightF = 27.0!
        Me.groupHeaderBand2.Name = "groupHeaderBand2"
        Me.groupHeaderBand2.StyleName = "FieldCaption"
        '
        'xrLabel3
        '
        Me.xrLabel3.LocationFloat = New DevExpress.Utils.PointFloat(36.0!, 7.0!)
        Me.xrLabel3.Name = "xrLabel3"
        Me.xrLabel3.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel3.SizeF = New System.Drawing.SizeF(147.5728!, 18.0!)
        Me.xrLabel3.Text = "Maturity Range"
        '
        'xrLabel4
        '
        Me.xrLabel4.LocationFloat = New DevExpress.Utils.PointFloat(183.5728!, 7.0!)
        Me.xrLabel4.Name = "xrLabel4"
        Me.xrLabel4.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel4.SizeF = New System.Drawing.SizeF(238.0841!, 18.0!)
        Me.xrLabel4.Text = "Principal Maturity"
        '
        'xrLabel5
        '
        Me.xrLabel5.LocationFloat = New DevExpress.Utils.PointFloat(421.657!, 7.0!)
        Me.xrLabel5.Name = "xrLabel5"
        Me.xrLabel5.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel5.SizeF = New System.Drawing.SizeF(222.343!, 18.0!)
        Me.xrLabel5.Text = "Interest Maturity"
        '
        'xrLine1
        '
        Me.xrLine1.LocationFloat = New DevExpress.Utils.PointFloat(36.0!, 5.0!)
        Me.xrLine1.Name = "xrLine1"
        Me.xrLine1.SizeF = New System.Drawing.SizeF(608.0!, 2.0!)
        '
        'xrLine2
        '
        Me.xrLine2.LocationFloat = New DevExpress.Utils.PointFloat(36.0!, 25.0!)
        Me.xrLine2.Name = "xrLine2"
        Me.xrLine2.SizeF = New System.Drawing.SizeF(608.0!, 2.0!)
        '
        'pageFooterBand1
        '
        Me.pageFooterBand1.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.xrPageInfo1, Me.xrPageInfo2})
        Me.pageFooterBand1.HeightF = 29.0!
        Me.pageFooterBand1.Name = "pageFooterBand1"
        '
        'xrPageInfo1
        '
        Me.xrPageInfo1.LocationFloat = New DevExpress.Utils.PointFloat(6.0!, 6.0!)
        Me.xrPageInfo1.Name = "xrPageInfo1"
        Me.xrPageInfo1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrPageInfo1.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime
        Me.xrPageInfo1.SizeF = New System.Drawing.SizeF(313.0!, 23.0!)
        Me.xrPageInfo1.StyleName = "PageInfo"
        '
        'xrPageInfo2
        '
        Me.xrPageInfo2.Format = "Page {0} of {1}"
        Me.xrPageInfo2.LocationFloat = New DevExpress.Utils.PointFloat(331.0!, 6.0!)
        Me.xrPageInfo2.Name = "xrPageInfo2"
        Me.xrPageInfo2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrPageInfo2.SizeF = New System.Drawing.SizeF(313.0!, 23.0!)
        Me.xrPageInfo2.StyleName = "PageInfo"
        Me.xrPageInfo2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'reportHeaderBand1
        '
        Me.reportHeaderBand1.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.xrLabel9, Me.xrChart1})
        Me.reportHeaderBand1.HeightF = 497.9167!
        Me.reportHeaderBand1.Name = "reportHeaderBand1"
        '
        'xrLabel9
        '
        Me.xrLabel9.LocationFloat = New DevExpress.Utils.PointFloat(6.0!, 6.0!)
        Me.xrLabel9.Name = "xrLabel9"
        Me.xrLabel9.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel9.SizeF = New System.Drawing.SizeF(638.0!, 33.0!)
        Me.xrLabel9.StyleName = "Title"
        Me.xrLabel9.Text = "Maturity Analysis Report"
        '
        'xrChart1
        '
        Me.xrChart1.BorderColor = System.Drawing.Color.Black
        Me.xrChart1.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.xrChart1.DataSource = Me.dsAnalystReports1
        xyDiagram1.AxisX.VisibleInPanesSerializable = "-1"
        xyDiagram1.AxisY.VisibleInPanesSerializable = "-1"
        xyDiagram1.DefaultPane.EnableAxisXScrolling = DevExpress.Utils.DefaultBoolean.[False]
        xyDiagram1.DefaultPane.EnableAxisXZooming = DevExpress.Utils.DefaultBoolean.[False]
        xyDiagram1.DefaultPane.EnableAxisYScrolling = DevExpress.Utils.DefaultBoolean.[False]
        xyDiagram1.DefaultPane.EnableAxisYZooming = DevExpress.Utils.DefaultBoolean.[False]
        Me.xrChart1.Diagram = xyDiagram1
        Me.xrChart1.Legend.AlignmentHorizontal = DevExpress.XtraCharts.LegendAlignmentHorizontal.Left
        Me.xrChart1.Legend.AlignmentVertical = DevExpress.XtraCharts.LegendAlignmentVertical.BottomOutside
        Me.xrChart1.Legend.Direction = DevExpress.XtraCharts.LegendDirection.LeftToRight
        Me.xrChart1.Legend.EquallySpacedItems = False
        Me.xrChart1.LocationFloat = New DevExpress.Utils.PointFloat(14.0!, 67.08333!)
        Me.xrChart1.Name = "xrChart1"
        series1.ArgumentDataMember = "MaturityAnalysis.MatRange"
        series1.ArgumentScaleType = DevExpress.XtraCharts.ScaleType.Qualitative
        pointOptions1.ValueNumericOptions.Format = DevExpress.XtraCharts.NumericFormat.Currency
        sideBySideBarSeriesLabel1.PointOptions = pointOptions1
        series1.Label = sideBySideBarSeriesLabel1
        series1.LabelsVisibility = DevExpress.Utils.DefaultBoolean.[False]
        series1.LegendText = "Principal Maturities"
        series1.Name = "PrincipalSeries"
        series1.ValueDataMembersSerializable = "MaturityAnalysis.PrincipalMaturity"
        series2.ArgumentDataMember = "MaturityAnalysis.MatRange"
        series2.ArgumentScaleType = DevExpress.XtraCharts.ScaleType.Qualitative
        pointOptions2.ValueNumericOptions.Format = DevExpress.XtraCharts.NumericFormat.Currency
        sideBySideBarSeriesLabel2.PointOptions = pointOptions2
        series2.Label = sideBySideBarSeriesLabel2
        series2.LabelsVisibility = DevExpress.Utils.DefaultBoolean.[False]
        series2.LegendText = "Interest Maturities"
        series2.Name = "InterestSeries"
        series2.ValueDataMembersSerializable = "MaturityAnalysis.InterestMaturity"
        Me.xrChart1.SeriesSerializable = New DevExpress.XtraCharts.Series() {series1, series2}
        Me.xrChart1.SizeF = New System.Drawing.SizeF(630.0!, 420.8334!)
        '
        'groupFooterBand1
        '
        Me.groupFooterBand1.HeightF = 1.0!
        Me.groupFooterBand1.Name = "groupFooterBand1"
        '
        'groupFooterBand2
        '
        Me.groupFooterBand2.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.xrLabel10, Me.xrLabel11, Me.xrLabel12, Me.xrLabel13, Me.xrLabel14, Me.xrLabel15, Me.xrLabel16, Me.xrLabel17, Me.xrLabel18, Me.xrLabel19, Me.xrLabel20, Me.xrLabel21})
        Me.groupFooterBand2.HeightF = 102.0!
        Me.groupFooterBand2.Level = 1
        Me.groupFooterBand2.Name = "groupFooterBand2"
        '
        'xrLabel10
        '
        Me.xrLabel10.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "MaturityAnalysis.PrincipalMaturity")})
        Me.xrLabel10.LocationFloat = New DevExpress.Utils.PointFloat(183.5728!, 6.0!)
        Me.xrLabel10.Name = "xrLabel10"
        Me.xrLabel10.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel10.SizeF = New System.Drawing.SizeF(238.0841!, 18.0!)
        Me.xrLabel10.StyleName = "FieldCaption"
        xrSummary1.FormatString = "{0:n2}"
        xrSummary1.IgnoreNullValues = True
        xrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
        Me.xrLabel10.Summary = xrSummary1
        '
        'xrLabel11
        '
        Me.xrLabel11.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "MaturityAnalysis.InterestMaturity", "{0:C2}")})
        Me.xrLabel11.LocationFloat = New DevExpress.Utils.PointFloat(421.657!, 6.0!)
        Me.xrLabel11.Name = "xrLabel11"
        Me.xrLabel11.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel11.SizeF = New System.Drawing.SizeF(222.343!, 18.0!)
        Me.xrLabel11.StyleName = "FieldCaption"
        xrSummary2.FormatString = "{0:n2}"
        xrSummary2.IgnoreNullValues = True
        xrSummary2.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
        Me.xrLabel11.Summary = xrSummary2
        Me.xrLabel11.Text = "xrLabel11"
        '
        'xrLabel12
        '
        Me.xrLabel12.LocationFloat = New DevExpress.Utils.PointFloat(6.00001!, 6.00001!)
        Me.xrLabel12.Name = "xrLabel12"
        Me.xrLabel12.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel12.SizeF = New System.Drawing.SizeF(97.70834!, 18.0!)
        Me.xrLabel12.StyleName = "FieldCaption"
        Me.xrLabel12.Text = "Sum"
        '
        'xrLabel13
        '
        Me.xrLabel13.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "MaturityAnalysis.PrincipalMaturity", "{0:C2}")})
        Me.xrLabel13.LocationFloat = New DevExpress.Utils.PointFloat(183.5728!, 30.0!)
        Me.xrLabel13.Name = "xrLabel13"
        Me.xrLabel13.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel13.SizeF = New System.Drawing.SizeF(238.0841!, 18.0!)
        Me.xrLabel13.StyleName = "FieldCaption"
        xrSummary3.FormatString = "{0:n2}"
        xrSummary3.Func = DevExpress.XtraReports.UI.SummaryFunc.Avg
        xrSummary3.IgnoreNullValues = True
        xrSummary3.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
        Me.xrLabel13.Summary = xrSummary3
        Me.xrLabel13.Text = "xrLabel13"
        '
        'xrLabel14
        '
        Me.xrLabel14.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "MaturityAnalysis.InterestMaturity", "{0:C2}")})
        Me.xrLabel14.LocationFloat = New DevExpress.Utils.PointFloat(421.657!, 30.0!)
        Me.xrLabel14.Name = "xrLabel14"
        Me.xrLabel14.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel14.SizeF = New System.Drawing.SizeF(222.343!, 18.0!)
        Me.xrLabel14.StyleName = "FieldCaption"
        xrSummary4.FormatString = "{0:n2}"
        xrSummary4.Func = DevExpress.XtraReports.UI.SummaryFunc.Avg
        xrSummary4.IgnoreNullValues = True
        xrSummary4.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
        Me.xrLabel14.Summary = xrSummary4
        Me.xrLabel14.Text = "xrLabel14"
        '
        'xrLabel15
        '
        Me.xrLabel15.LocationFloat = New DevExpress.Utils.PointFloat(6.00001!, 29.99999!)
        Me.xrLabel15.Name = "xrLabel15"
        Me.xrLabel15.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel15.SizeF = New System.Drawing.SizeF(97.70834!, 18.0!)
        Me.xrLabel15.StyleName = "FieldCaption"
        Me.xrLabel15.Text = "Avg"
        '
        'xrLabel16
        '
        Me.xrLabel16.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "MaturityAnalysis.PrincipalMaturity", "{0:C2}")})
        Me.xrLabel16.LocationFloat = New DevExpress.Utils.PointFloat(183.5728!, 54.0!)
        Me.xrLabel16.Name = "xrLabel16"
        Me.xrLabel16.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel16.SizeF = New System.Drawing.SizeF(238.0841!, 18.0!)
        Me.xrLabel16.StyleName = "FieldCaption"
        xrSummary5.FormatString = "{0:n2}"
        xrSummary5.Func = DevExpress.XtraReports.UI.SummaryFunc.Min
        xrSummary5.IgnoreNullValues = True
        xrSummary5.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
        Me.xrLabel16.Summary = xrSummary5
        Me.xrLabel16.Text = "xrLabel16"
        '
        'xrLabel17
        '
        Me.xrLabel17.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "MaturityAnalysis.InterestMaturity", "{0:C2}")})
        Me.xrLabel17.LocationFloat = New DevExpress.Utils.PointFloat(421.657!, 54.0!)
        Me.xrLabel17.Name = "xrLabel17"
        Me.xrLabel17.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel17.SizeF = New System.Drawing.SizeF(222.343!, 18.0!)
        Me.xrLabel17.StyleName = "FieldCaption"
        xrSummary6.FormatString = "{0:n2}"
        xrSummary6.Func = DevExpress.XtraReports.UI.SummaryFunc.Min
        xrSummary6.IgnoreNullValues = True
        xrSummary6.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
        Me.xrLabel17.Summary = xrSummary6
        Me.xrLabel17.Text = "xrLabel17"
        '
        'xrLabel18
        '
        Me.xrLabel18.LocationFloat = New DevExpress.Utils.PointFloat(6.00001!, 54.00003!)
        Me.xrLabel18.Name = "xrLabel18"
        Me.xrLabel18.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel18.SizeF = New System.Drawing.SizeF(97.70836!, 18.0!)
        Me.xrLabel18.StyleName = "FieldCaption"
        Me.xrLabel18.Text = "Min"
        '
        'xrLabel19
        '
        Me.xrLabel19.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "MaturityAnalysis.PrincipalMaturity", "{0:C2}")})
        Me.xrLabel19.LocationFloat = New DevExpress.Utils.PointFloat(183.5728!, 78.0!)
        Me.xrLabel19.Name = "xrLabel19"
        Me.xrLabel19.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel19.SizeF = New System.Drawing.SizeF(238.0841!, 18.0!)
        Me.xrLabel19.StyleName = "FieldCaption"
        xrSummary7.FormatString = "{0:n2}"
        xrSummary7.Func = DevExpress.XtraReports.UI.SummaryFunc.Max
        xrSummary7.IgnoreNullValues = True
        xrSummary7.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
        Me.xrLabel19.Summary = xrSummary7
        Me.xrLabel19.Text = "xrLabel19"
        '
        'xrLabel20
        '
        Me.xrLabel20.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "MaturityAnalysis.InterestMaturity", "{0:C2}")})
        Me.xrLabel20.LocationFloat = New DevExpress.Utils.PointFloat(421.657!, 78.0!)
        Me.xrLabel20.Name = "xrLabel20"
        Me.xrLabel20.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel20.SizeF = New System.Drawing.SizeF(222.343!, 18.0!)
        Me.xrLabel20.StyleName = "FieldCaption"
        xrSummary8.FormatString = "{0:n2}"
        xrSummary8.Func = DevExpress.XtraReports.UI.SummaryFunc.Max
        xrSummary8.IgnoreNullValues = True
        xrSummary8.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
        Me.xrLabel20.Summary = xrSummary8
        Me.xrLabel20.Text = "xrLabel20"
        '
        'xrLabel21
        '
        Me.xrLabel21.LocationFloat = New DevExpress.Utils.PointFloat(6.00001!, 78.00001!)
        Me.xrLabel21.Name = "xrLabel21"
        Me.xrLabel21.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel21.SizeF = New System.Drawing.SizeF(97.70836!, 18.00001!)
        Me.xrLabel21.StyleName = "FieldCaption"
        Me.xrLabel21.Text = "Max"
        '
        'reportFooterBand1
        '
        Me.reportFooterBand1.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.xrLabel22, Me.xrLabel23, Me.xrLabel24})
        Me.reportFooterBand1.HeightF = 30.0!
        Me.reportFooterBand1.Name = "reportFooterBand1"
        '
        'xrLabel22
        '
        Me.xrLabel22.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "MaturityAnalysis.PrincipalMaturity", "{0:C2}")})
        Me.xrLabel22.LocationFloat = New DevExpress.Utils.PointFloat(183.5728!, 6.0!)
        Me.xrLabel22.Name = "xrLabel22"
        Me.xrLabel22.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel22.SizeF = New System.Drawing.SizeF(238.0841!, 18.0!)
        Me.xrLabel22.StyleName = "FieldCaption"
        xrSummary9.FormatString = "{0:n2}"
        xrSummary9.IgnoreNullValues = True
        xrSummary9.Running = DevExpress.XtraReports.UI.SummaryRunning.Report
        Me.xrLabel22.Summary = xrSummary9
        Me.xrLabel22.Text = "xrLabel22"
        '
        'xrLabel23
        '
        Me.xrLabel23.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "MaturityAnalysis.InterestMaturity", "{0:C2}")})
        Me.xrLabel23.LocationFloat = New DevExpress.Utils.PointFloat(421.657!, 6.0!)
        Me.xrLabel23.Name = "xrLabel23"
        Me.xrLabel23.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel23.SizeF = New System.Drawing.SizeF(222.343!, 18.0!)
        Me.xrLabel23.StyleName = "FieldCaption"
        xrSummary10.FormatString = "{0:n2}"
        xrSummary10.IgnoreNullValues = True
        xrSummary10.Running = DevExpress.XtraReports.UI.SummaryRunning.Report
        Me.xrLabel23.Summary = xrSummary10
        Me.xrLabel23.Text = "xrLabel23"
        '
        'xrLabel24
        '
        Me.xrLabel24.LocationFloat = New DevExpress.Utils.PointFloat(6.00001!, 6.00001!)
        Me.xrLabel24.Name = "xrLabel24"
        Me.xrLabel24.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel24.SizeF = New System.Drawing.SizeF(97.70836!, 18.0!)
        Me.xrLabel24.StyleName = "FieldCaption"
        Me.xrLabel24.Text = "Grand Total"
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
        Me.FieldCaption.Borders = DevExpress.XtraPrinting.BorderSide.None
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
        Me.DataField.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        '
        'topMarginBand1
        '
        Me.topMarginBand1.HeightF = 62.5!
        Me.topMarginBand1.Name = "topMarginBand1"
        '
        'bottomMarginBand1
        '
        Me.bottomMarginBand1.Name = "bottomMarginBand1"
        '
        'xrptMaturityAnalysis
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.groupHeaderBand1, Me.groupHeaderBand2, Me.pageFooterBand1, Me.reportHeaderBand1, Me.groupFooterBand2, Me.reportFooterBand1, Me.topMarginBand1, Me.bottomMarginBand1})
        Me.DataAdapter = Me.maturityAnalysisTableAdapter1
        Me.DataMember = "MaturityAnalysis"
        Me.DataSource = Me.dsAnalystReports1
        Me.Margins = New System.Drawing.Printing.Margins(100, 100, 62, 100)
        Me.StyleSheet.AddRange(New DevExpress.XtraReports.UI.XRControlStyle() {Me.Title, Me.FieldCaption, Me.PageInfo, Me.DataField})
        Me.Version = "13.2"
        CType(Me.dsAnalystReports1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(xyDiagram1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(sideBySideBarSeriesLabel1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(series1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(sideBySideBarSeriesLabel2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(series2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.xrChart1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand

#End Region

End Class