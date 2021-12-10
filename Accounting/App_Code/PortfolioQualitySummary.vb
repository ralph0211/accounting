Public Class PortfolioQualitySummary
    Inherits DevExpress.XtraReports.UI.XtraReport

#Region " Designer generated code "

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
    Private WithEvents xrLabel9 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel8 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel7 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel1 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel2 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel3 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel4 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel5 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel6 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel13 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel14 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel15 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel16 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel17 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel18 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel19 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel20 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel21 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel22 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel23 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel24 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLine1 As DevExpress.XtraReports.UI.XRLine
    Private WithEvents dsAllReports1 As dsAllReports
    Private WithEvents agingArrearsSummaryTableAdapter1 As dsAllReportsTableAdapters.AgingArrearsSummaryTableAdapter
    Private WithEvents pageFooterBand1 As DevExpress.XtraReports.UI.PageFooterBand
    Private WithEvents xrPageInfo1 As DevExpress.XtraReports.UI.XRPageInfo
    Private WithEvents xrPageInfo2 As DevExpress.XtraReports.UI.XRPageInfo
    Private WithEvents reportHeaderBand1 As DevExpress.XtraReports.UI.ReportHeaderBand
    Private WithEvents xrLabel25 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents Title As DevExpress.XtraReports.UI.XRControlStyle
    Private WithEvents FieldCaption As DevExpress.XtraReports.UI.XRControlStyle
    Private WithEvents PageInfo As DevExpress.XtraReports.UI.XRControlStyle
    Private WithEvents DataField As DevExpress.XtraReports.UI.XRControlStyle
    Private WithEvents topMarginBand1 As DevExpress.XtraReports.UI.TopMarginBand
    Private WithEvents bottomMarginBand1 As DevExpress.XtraReports.UI.BottomMarginBand
    Private WithEvents xrLabel10 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents toDate As DevExpress.XtraReports.Parameters.Parameter
    Private WithEvents xrLine2 As DevExpress.XtraReports.UI.XRLine
    Private WithEvents CountTotal As DevExpress.XtraReports.UI.CalculatedField
    Private WithEvents SumTotal As DevExpress.XtraReports.UI.CalculatedField
    Private WithEvents xrLabel26 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel12 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel11 As DevExpress.XtraReports.UI.XRLabel

    'Required by the Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Designer
    'It can be modified using the Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resourceFileName As String = "PortfolioQualitySummary.resx"
        Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
        Me.xrLabel9 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel8 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel7 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel1 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel2 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel3 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel4 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel5 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel6 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel13 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel14 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel15 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel16 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel17 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel18 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel19 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel20 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel21 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel22 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel23 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel24 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLine1 = New DevExpress.XtraReports.UI.XRLine()
        Me.dsAllReports1 = New dsAllReports()
        Me.agingArrearsSummaryTableAdapter1 = New dsAllReportsTableAdapters.AgingArrearsSummaryTableAdapter()
        Me.pageFooterBand1 = New DevExpress.XtraReports.UI.PageFooterBand()
        Me.xrPageInfo1 = New DevExpress.XtraReports.UI.XRPageInfo()
        Me.xrPageInfo2 = New DevExpress.XtraReports.UI.XRPageInfo()
        Me.reportHeaderBand1 = New DevExpress.XtraReports.UI.ReportHeaderBand()
        Me.xrLabel10 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel25 = New DevExpress.XtraReports.UI.XRLabel()
        Me.Title = New DevExpress.XtraReports.UI.XRControlStyle()
        Me.FieldCaption = New DevExpress.XtraReports.UI.XRControlStyle()
        Me.PageInfo = New DevExpress.XtraReports.UI.XRControlStyle()
        Me.DataField = New DevExpress.XtraReports.UI.XRControlStyle()
        Me.topMarginBand1 = New DevExpress.XtraReports.UI.TopMarginBand()
        Me.bottomMarginBand1 = New DevExpress.XtraReports.UI.BottomMarginBand()
        Me.toDate = New DevExpress.XtraReports.Parameters.Parameter()
        Me.xrLine2 = New DevExpress.XtraReports.UI.XRLine()
        Me.CountTotal = New DevExpress.XtraReports.UI.CalculatedField()
        Me.SumTotal = New DevExpress.XtraReports.UI.CalculatedField()
        Me.xrLabel11 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel12 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel26 = New DevExpress.XtraReports.UI.XRLabel()
        CType(Me.dsAllReports1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.xrLabel26, Me.xrLabel12, Me.xrLabel11, Me.xrLine2, Me.xrLabel9, Me.xrLabel8, Me.xrLabel7, Me.xrLabel1, Me.xrLabel2, Me.xrLabel3, Me.xrLabel4, Me.xrLabel5, Me.xrLabel6, Me.xrLabel13, Me.xrLabel14, Me.xrLabel15, Me.xrLabel16, Me.xrLabel17, Me.xrLabel18, Me.xrLabel19, Me.xrLabel20, Me.xrLabel21, Me.xrLabel22, Me.xrLabel23, Me.xrLabel24, Me.xrLine1})
        Me.Detail.HeightF = 406.0!
        Me.Detail.Name = "Detail"
        Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'xrLabel9
        '
        Me.xrLabel9.Font = New System.Drawing.Font("Times New Roman", 10.0!, System.Drawing.FontStyle.Bold)
        Me.xrLabel9.LocationFloat = New DevExpress.Utils.PointFloat(6.00001!, 25.62501!)
        Me.xrLabel9.Name = "xrLabel9"
        Me.xrLabel9.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel9.SizeF = New System.Drawing.SizeF(293.75!, 23.0!)
        Me.xrLabel9.StylePriority.UseFont = False
        Me.xrLabel9.Text = "Range of Days in Arrears"
        '
        'xrLabel8
        '
        Me.xrLabel8.Font = New System.Drawing.Font("Times New Roman", 10.0!, System.Drawing.FontStyle.Bold)
        Me.xrLabel8.LocationFloat = New DevExpress.Utils.PointFloat(365.8333!, 25.62501!)
        Me.xrLabel8.Name = "xrLabel8"
        Me.xrLabel8.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel8.SizeF = New System.Drawing.SizeF(124.1667!, 23.0!)
        Me.xrLabel8.StylePriority.UseFont = False
        Me.xrLabel8.StylePriority.UseTextAlignment = False
        Me.xrLabel8.Text = "Number of Loans"
        Me.xrLabel8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'xrLabel7
        '
        Me.xrLabel7.Font = New System.Drawing.Font("Times New Roman", 10.0!, System.Drawing.FontStyle.Bold)
        Me.xrLabel7.LocationFloat = New DevExpress.Utils.PointFloat(500.2083!, 25.62501!)
        Me.xrLabel7.Name = "xrLabel7"
        Me.xrLabel7.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel7.SizeF = New System.Drawing.SizeF(139.7917!, 23.0!)
        Me.xrLabel7.StylePriority.UseFont = False
        Me.xrLabel7.StylePriority.UseTextAlignment = False
        Me.xrLabel7.Text = "Total Value of Loans"
        Me.xrLabel7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'xrLabel1
        '
        Me.xrLabel1.LocationFloat = New DevExpress.Utils.PointFloat(5.999994!, 50.62501!)
        Me.xrLabel1.Name = "xrLabel1"
        Me.xrLabel1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel1.SizeF = New System.Drawing.SizeF(162.0!, 18.0!)
        Me.xrLabel1.StyleName = "FieldCaption"
        Me.xrLabel1.Text = "Unexpired"
        '
        'xrLabel2
        '
        Me.xrLabel2.LocationFloat = New DevExpress.Utils.PointFloat(5.999994!, 74.62502!)
        Me.xrLabel2.Name = "xrLabel2"
        Me.xrLabel2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel2.SizeF = New System.Drawing.SizeF(162.0!, 18.0!)
        Me.xrLabel2.StyleName = "FieldCaption"
        Me.xrLabel2.Text = "1 - 30 Days"
        '
        'xrLabel3
        '
        Me.xrLabel3.LocationFloat = New DevExpress.Utils.PointFloat(5.999994!, 98.62499!)
        Me.xrLabel3.Name = "xrLabel3"
        Me.xrLabel3.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel3.SizeF = New System.Drawing.SizeF(162.0!, 18.0!)
        Me.xrLabel3.StyleName = "FieldCaption"
        Me.xrLabel3.Text = "31 - 60 Days"
        '
        'xrLabel4
        '
        Me.xrLabel4.LocationFloat = New DevExpress.Utils.PointFloat(5.999994!, 122.625!)
        Me.xrLabel4.Name = "xrLabel4"
        Me.xrLabel4.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel4.SizeF = New System.Drawing.SizeF(162.0!, 18.0!)
        Me.xrLabel4.StyleName = "FieldCaption"
        Me.xrLabel4.Text = "61 - 90 Days"
        '
        'xrLabel5
        '
        Me.xrLabel5.LocationFloat = New DevExpress.Utils.PointFloat(5.999994!, 146.625!)
        Me.xrLabel5.Name = "xrLabel5"
        Me.xrLabel5.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel5.SizeF = New System.Drawing.SizeF(162.0!, 18.0!)
        Me.xrLabel5.StyleName = "FieldCaption"
        Me.xrLabel5.Text = "91 - 180 Days"
        '
        'xrLabel6
        '
        Me.xrLabel6.LocationFloat = New DevExpress.Utils.PointFloat(5.999994!, 170.625!)
        Me.xrLabel6.Name = "xrLabel6"
        Me.xrLabel6.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel6.SizeF = New System.Drawing.SizeF(162.0!, 18.0!)
        Me.xrLabel6.StyleName = "FieldCaption"
        Me.xrLabel6.Text = ">180 Days"
        '
        'xrLabel13
        '
        Me.xrLabel13.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "AgingArrearsSummary.SumUnexpired", "{0:n2}")})
        Me.xrLabel13.LocationFloat = New DevExpress.Utils.PointFloat(515.8333!, 50.62501!)
        Me.xrLabel13.Name = "xrLabel13"
        Me.xrLabel13.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel13.SizeF = New System.Drawing.SizeF(124.1667!, 18.0!)
        Me.xrLabel13.StyleName = "DataField"
        Me.xrLabel13.StylePriority.UseTextAlignment = False
        Me.xrLabel13.Text = "xrLabel13"
        Me.xrLabel13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'xrLabel14
        '
        Me.xrLabel14.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "AgingArrearsSummary.Sum1-30Days", "{0:n2}")})
        Me.xrLabel14.LocationFloat = New DevExpress.Utils.PointFloat(515.8333!, 74.62502!)
        Me.xrLabel14.Name = "xrLabel14"
        Me.xrLabel14.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel14.SizeF = New System.Drawing.SizeF(124.1667!, 18.0!)
        Me.xrLabel14.StyleName = "DataField"
        Me.xrLabel14.StylePriority.UseTextAlignment = False
        Me.xrLabel14.Text = "xrLabel14"
        Me.xrLabel14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'xrLabel15
        '
        Me.xrLabel15.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "AgingArrearsSummary.Sum31-60Days", "{0:n2}")})
        Me.xrLabel15.LocationFloat = New DevExpress.Utils.PointFloat(515.8333!, 98.62499!)
        Me.xrLabel15.Name = "xrLabel15"
        Me.xrLabel15.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel15.SizeF = New System.Drawing.SizeF(124.1667!, 18.0!)
        Me.xrLabel15.StyleName = "DataField"
        Me.xrLabel15.StylePriority.UseTextAlignment = False
        Me.xrLabel15.Text = "xrLabel15"
        Me.xrLabel15.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'xrLabel16
        '
        Me.xrLabel16.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "AgingArrearsSummary.Sum61-90Days", "{0:n2}")})
        Me.xrLabel16.LocationFloat = New DevExpress.Utils.PointFloat(515.8333!, 122.625!)
        Me.xrLabel16.Name = "xrLabel16"
        Me.xrLabel16.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel16.SizeF = New System.Drawing.SizeF(124.1667!, 18.0!)
        Me.xrLabel16.StyleName = "DataField"
        Me.xrLabel16.StylePriority.UseTextAlignment = False
        Me.xrLabel16.Text = "xrLabel16"
        Me.xrLabel16.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'xrLabel17
        '
        Me.xrLabel17.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "AgingArrearsSummary.Sum91-180Days", "{0:n2}")})
        Me.xrLabel17.LocationFloat = New DevExpress.Utils.PointFloat(515.8333!, 146.625!)
        Me.xrLabel17.Name = "xrLabel17"
        Me.xrLabel17.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel17.SizeF = New System.Drawing.SizeF(124.1667!, 18.0!)
        Me.xrLabel17.StyleName = "DataField"
        Me.xrLabel17.StylePriority.UseTextAlignment = False
        Me.xrLabel17.Text = "xrLabel17"
        Me.xrLabel17.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'xrLabel18
        '
        Me.xrLabel18.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "AgingArrearsSummary.Sum>180Days", "{0:n2}")})
        Me.xrLabel18.LocationFloat = New DevExpress.Utils.PointFloat(515.8333!, 170.625!)
        Me.xrLabel18.Name = "xrLabel18"
        Me.xrLabel18.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel18.SizeF = New System.Drawing.SizeF(124.1667!, 18.0!)
        Me.xrLabel18.StyleName = "DataField"
        Me.xrLabel18.StylePriority.UseTextAlignment = False
        Me.xrLabel18.Text = "xrLabel18"
        Me.xrLabel18.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'xrLabel19
        '
        Me.xrLabel19.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "AgingArrearsSummary.CountUnexpired", "{0:#,#}")})
        Me.xrLabel19.LocationFloat = New DevExpress.Utils.PointFloat(365.8333!, 50.62501!)
        Me.xrLabel19.Name = "xrLabel19"
        Me.xrLabel19.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel19.SizeF = New System.Drawing.SizeF(124.1667!, 18.0!)
        Me.xrLabel19.StyleName = "DataField"
        Me.xrLabel19.StylePriority.UseTextAlignment = False
        Me.xrLabel19.Text = "xrLabel19"
        Me.xrLabel19.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'xrLabel20
        '
        Me.xrLabel20.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "AgingArrearsSummary.Count1-30Days", "{0:#,#}")})
        Me.xrLabel20.LocationFloat = New DevExpress.Utils.PointFloat(365.8333!, 74.62495!)
        Me.xrLabel20.Name = "xrLabel20"
        Me.xrLabel20.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel20.SizeF = New System.Drawing.SizeF(124.1667!, 18.0!)
        Me.xrLabel20.StyleName = "DataField"
        Me.xrLabel20.StylePriority.UseTextAlignment = False
        Me.xrLabel20.Text = "xrLabel20"
        Me.xrLabel20.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'xrLabel21
        '
        Me.xrLabel21.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "AgingArrearsSummary.Count31-60Days", "{0:#,#}")})
        Me.xrLabel21.LocationFloat = New DevExpress.Utils.PointFloat(365.8333!, 98.62502!)
        Me.xrLabel21.Name = "xrLabel21"
        Me.xrLabel21.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel21.SizeF = New System.Drawing.SizeF(124.1667!, 17.99998!)
        Me.xrLabel21.StyleName = "DataField"
        Me.xrLabel21.StylePriority.UseTextAlignment = False
        Me.xrLabel21.Text = "xrLabel21"
        Me.xrLabel21.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'xrLabel22
        '
        Me.xrLabel22.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "AgingArrearsSummary.Count61-90Days", "{0:#,#}")})
        Me.xrLabel22.LocationFloat = New DevExpress.Utils.PointFloat(365.8333!, 122.625!)
        Me.xrLabel22.Name = "xrLabel22"
        Me.xrLabel22.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel22.SizeF = New System.Drawing.SizeF(124.1667!, 18.0!)
        Me.xrLabel22.StyleName = "DataField"
        Me.xrLabel22.StylePriority.UseTextAlignment = False
        Me.xrLabel22.Text = "xrLabel22"
        Me.xrLabel22.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'xrLabel23
        '
        Me.xrLabel23.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "AgingArrearsSummary.Count91-180Days", "{0:#,#}")})
        Me.xrLabel23.LocationFloat = New DevExpress.Utils.PointFloat(365.8333!, 146.625!)
        Me.xrLabel23.Name = "xrLabel23"
        Me.xrLabel23.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel23.SizeF = New System.Drawing.SizeF(124.1667!, 18.00002!)
        Me.xrLabel23.StyleName = "DataField"
        Me.xrLabel23.StylePriority.UseTextAlignment = False
        Me.xrLabel23.Text = "xrLabel23"
        Me.xrLabel23.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'xrLabel24
        '
        Me.xrLabel24.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "AgingArrearsSummary.Count>180Days", "{0:#,#}")})
        Me.xrLabel24.LocationFloat = New DevExpress.Utils.PointFloat(365.8333!, 170.625!)
        Me.xrLabel24.Name = "xrLabel24"
        Me.xrLabel24.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel24.SizeF = New System.Drawing.SizeF(124.1667!, 18.0!)
        Me.xrLabel24.StyleName = "DataField"
        Me.xrLabel24.StylePriority.UseTextAlignment = False
        Me.xrLabel24.Text = "xrLabel24"
        Me.xrLabel24.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'xrLine1
        '
        Me.xrLine1.LocationFloat = New DevExpress.Utils.PointFloat(6.0!, 48.62501!)
        Me.xrLine1.Name = "xrLine1"
        Me.xrLine1.SizeF = New System.Drawing.SizeF(638.0!, 2.0!)
        '
        'dsAllReports1
        '
        Me.dsAllReports1.DataSetName = "dsAllReports"
        Me.dsAllReports1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'agingArrearsSummaryTableAdapter1
        '
        Me.agingArrearsSummaryTableAdapter1.ClearBeforeFill = True
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
        Me.reportHeaderBand1.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.xrLabel10, Me.xrLabel25})
        Me.reportHeaderBand1.HeightF = 93.70833!
        Me.reportHeaderBand1.Name = "reportHeaderBand1"
        '
        'xrLabel10
        '
        Me.xrLabel10.Font = New System.Drawing.Font("Times New Roman", 10.0!, System.Drawing.FontStyle.Bold)
        Me.xrLabel10.LocationFloat = New DevExpress.Utils.PointFloat(22.50001!, 60.70833!)
        Me.xrLabel10.Name = "xrLabel10"
        Me.xrLabel10.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel10.SizeF = New System.Drawing.SizeF(371.875!, 23.0!)
        Me.xrLabel10.StylePriority.UseFont = False
        Me.xrLabel10.Text = "As at: [Parameters.toDate!dd MMM,yyyy]"
        '
        'xrLabel25
        '
        Me.xrLabel25.LocationFloat = New DevExpress.Utils.PointFloat(6.0!, 6.0!)
        Me.xrLabel25.Name = "xrLabel25"
        Me.xrLabel25.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel25.SizeF = New System.Drawing.SizeF(638.0!, 33.0!)
        Me.xrLabel25.StyleName = "Title"
        Me.xrLabel25.Text = "Portfolio Quality Summary"
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
        Me.topMarginBand1.HeightF = 95.83334!
        Me.topMarginBand1.Name = "topMarginBand1"
        '
        'bottomMarginBand1
        '
        Me.bottomMarginBand1.Name = "bottomMarginBand1"
        '
        'toDate
        '
        Me.toDate.Description = "To Date"
        Me.toDate.Name = "toDate"
        Me.toDate.Type = GetType(Date)
        Me.toDate.ValueInfo = Date.Now.ToLongDateString '"2016-02-19"
        '
        'xrLine2
        '
        Me.xrLine2.LineWidth = 2
        Me.xrLine2.LocationFloat = New DevExpress.Utils.PointFloat(6.00001!, 188.625!)
        Me.xrLine2.Name = "xrLine2"
        Me.xrLine2.SizeF = New System.Drawing.SizeF(638.0!, 14.66667!)
        '
        'CountTotal
        '
        Me.CountTotal.DataMember = "AgingArrearsSummary"
        Me.CountTotal.Expression = "[Count>180Days] + [Count1-30Days] + [Count31-60Days] + [Count61-90Days] + [Count9" &
    "1-180Days] + [CountUnexpired]"
        Me.CountTotal.Name = "CountTotal"
        '
        'SumTotal
        '
        Me.SumTotal.DataMember = "AgingArrearsSummary"
        Me.SumTotal.Expression = "[Sum>180Days] + [Sum1-30Days] + [Sum31-60Days] + [Sum61-90Days] + [Sum91-180Days]" &
    " + [SumUnexpired]"
        Me.SumTotal.Name = "SumTotal"
        '
        'xrLabel11
        '
        Me.xrLabel11.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "AgingArrearsSummary.SumTotal", "{0:n2}")})
        Me.xrLabel11.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold)
        Me.xrLabel11.LocationFloat = New DevExpress.Utils.PointFloat(515.8334!, 203.2917!)
        Me.xrLabel11.Name = "xrLabel11"
        Me.xrLabel11.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96.0!)
        Me.xrLabel11.SizeF = New System.Drawing.SizeF(124.1666!, 23.0!)
        Me.xrLabel11.StylePriority.UseFont = False
        Me.xrLabel11.StylePriority.UseTextAlignment = False
        Me.xrLabel11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'xrLabel12
        '
        Me.xrLabel12.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "AgingArrearsSummary.CountTotal", "{0:#,#}")})
        Me.xrLabel12.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold)
        Me.xrLabel12.LocationFloat = New DevExpress.Utils.PointFloat(365.8333!, 203.2917!)
        Me.xrLabel12.Name = "xrLabel12"
        Me.xrLabel12.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96.0!)
        Me.xrLabel12.SizeF = New System.Drawing.SizeF(124.1667!, 23.0!)
        Me.xrLabel12.StylePriority.UseFont = False
        Me.xrLabel12.StylePriority.UseTextAlignment = False
        Me.xrLabel12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'xrLabel26
        '
        Me.xrLabel26.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.xrLabel26.ForeColor = System.Drawing.Color.Maroon
        Me.xrLabel26.LocationFloat = New DevExpress.Utils.PointFloat(6.00001!, 203.2917!)
        Me.xrLabel26.Name = "xrLabel26"
        Me.xrLabel26.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96.0!)
        Me.xrLabel26.SizeF = New System.Drawing.SizeF(162.0!, 23.0!)
        Me.xrLabel26.StylePriority.UseFont = False
        Me.xrLabel26.StylePriority.UseForeColor = False
        Me.xrLabel26.Text = "Total"
        '
        'PortfolioQualitySummary
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.pageFooterBand1, Me.reportHeaderBand1, Me.topMarginBand1, Me.bottomMarginBand1})
        Me.CalculatedFields.AddRange(New DevExpress.XtraReports.UI.CalculatedField() {Me.CountTotal, Me.SumTotal})
        Me.DataAdapter = Me.agingArrearsSummaryTableAdapter1
        Me.DataMember = "AgingArrearsSummary"
        Me.DataSource = Me.dsAllReports1
        Me.Margins = New System.Drawing.Printing.Margins(100, 100, 96, 100)
        Me.Parameters.AddRange(New DevExpress.XtraReports.Parameters.Parameter() {Me.toDate})
        Me.StyleSheet.AddRange(New DevExpress.XtraReports.UI.XRControlStyle() {Me.Title, Me.FieldCaption, Me.PageInfo, Me.DataField})
        Me.Version = "13.2"
        CType(Me.dsAllReports1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand

#End Region

    Private Sub PortfolioQualitySummary_DataSourceDemanded(sender As Object, e As EventArgs) Handles Me.DataSourceDemanded
        agingArrearsSummaryTableAdapter1.FillByDate(dsAllReports1.AgingArrearsSummary, Me.toDate.Value)
    End Sub
End Class