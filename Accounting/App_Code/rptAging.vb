Public Class rptAging
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
    ' Private WithEvents dsAging1 As dsAging
    'Private WithEvents getAgingProfileTableAdapter1 As dsAgingTableAdapters.GetAgingProfileTableAdapter
    Private WithEvents xrLabel13 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel14 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel15 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel16 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel17 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel18 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents groupHeaderBand1 As DevExpress.XtraReports.UI.GroupHeaderBand
    Private WithEvents xrLabel3 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel4 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel1 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLine1 As DevExpress.XtraReports.UI.XRLine
    Private WithEvents groupHeaderBand2 As DevExpress.XtraReports.UI.GroupHeaderBand
    Private WithEvents xrLabel6 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel7 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel8 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel9 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel10 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel11 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents pageFooterBand1 As DevExpress.XtraReports.UI.PageFooterBand
    Private WithEvents xrLine2 As DevExpress.XtraReports.UI.XRLine
    Private WithEvents xrPageInfo1 As DevExpress.XtraReports.UI.XRPageInfo
    Private WithEvents xrPageInfo2 As DevExpress.XtraReports.UI.XRPageInfo
    Private WithEvents reportHeaderBand1 As DevExpress.XtraReports.UI.ReportHeaderBand
    Private WithEvents xrLabel19 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLine3 As DevExpress.XtraReports.UI.XRLine
    Private WithEvents xrLine4 As DevExpress.XtraReports.UI.XRLine
    Private WithEvents groupFooterBand1 As DevExpress.XtraReports.UI.GroupFooterBand
    Private WithEvents groupFooterBand2 As DevExpress.XtraReports.UI.GroupFooterBand
    Private WithEvents xrLabel20 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel21 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel22 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel23 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel24 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel25 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel44 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents reportFooterBand1 As DevExpress.XtraReports.UI.ReportFooterBand
    Private WithEvents xrLabel50 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel51 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel52 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel53 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel54 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel55 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents Title As DevExpress.XtraReports.UI.XRControlStyle
    Private WithEvents FieldCaption As DevExpress.XtraReports.UI.XRControlStyle
    Private WithEvents PageInfo As DevExpress.XtraReports.UI.XRControlStyle
    Private WithEvents DataField As DevExpress.XtraReports.UI.XRControlStyle
    Private WithEvents topMarginBand1 As DevExpress.XtraReports.UI.TopMarginBand
    Private WithEvents bottomMarginBand1 As DevExpress.XtraReports.UI.BottomMarginBand
    Private WithEvents xrLine6 As DevExpress.XtraReports.UI.XRLine
    Private WithEvents xrLine5 As DevExpress.XtraReports.UI.XRLine

    'Required by the Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Designer
    'It can be modified using the Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resourceFileName As String = "rptAging.resx"
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
        Dim xrSummary11 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
        Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
        Me.xrLabel13 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel14 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel15 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel16 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel17 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel18 = New DevExpress.XtraReports.UI.XRLabel()
        ' Me.dsAging1 = New dsAging()
        ' Me.getAgingProfileTableAdapter1 = New dsAgingTableAdapters.GetAgingProfileTableAdapter()
        Me.groupHeaderBand1 = New DevExpress.XtraReports.UI.GroupHeaderBand()
        Me.xrLabel3 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel4 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel1 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLine1 = New DevExpress.XtraReports.UI.XRLine()
        Me.groupHeaderBand2 = New DevExpress.XtraReports.UI.GroupHeaderBand()
        Me.xrLabel6 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel7 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel8 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel9 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel10 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel11 = New DevExpress.XtraReports.UI.XRLabel()
        Me.pageFooterBand1 = New DevExpress.XtraReports.UI.PageFooterBand()
        Me.xrLine2 = New DevExpress.XtraReports.UI.XRLine()
        Me.xrPageInfo1 = New DevExpress.XtraReports.UI.XRPageInfo()
        Me.xrPageInfo2 = New DevExpress.XtraReports.UI.XRPageInfo()
        Me.reportHeaderBand1 = New DevExpress.XtraReports.UI.ReportHeaderBand()
        Me.xrLabel19 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLine3 = New DevExpress.XtraReports.UI.XRLine()
        Me.xrLine4 = New DevExpress.XtraReports.UI.XRLine()
        Me.groupFooterBand1 = New DevExpress.XtraReports.UI.GroupFooterBand()
        Me.groupFooterBand2 = New DevExpress.XtraReports.UI.GroupFooterBand()
        Me.xrLine6 = New DevExpress.XtraReports.UI.XRLine()
        Me.xrLine5 = New DevExpress.XtraReports.UI.XRLine()
        Me.xrLabel20 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel21 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel22 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel23 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel24 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel25 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel44 = New DevExpress.XtraReports.UI.XRLabel()
        Me.reportFooterBand1 = New DevExpress.XtraReports.UI.ReportFooterBand()
        Me.xrLabel50 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel51 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel52 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel53 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel54 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel55 = New DevExpress.XtraReports.UI.XRLabel()
        Me.Title = New DevExpress.XtraReports.UI.XRControlStyle()
        Me.FieldCaption = New DevExpress.XtraReports.UI.XRControlStyle()
        Me.PageInfo = New DevExpress.XtraReports.UI.XRControlStyle()
        Me.DataField = New DevExpress.XtraReports.UI.XRControlStyle()
        Me.topMarginBand1 = New DevExpress.XtraReports.UI.TopMarginBand()
        Me.bottomMarginBand1 = New DevExpress.XtraReports.UI.BottomMarginBand()
        ' CType(Me.dsAging1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.xrLabel13, Me.xrLabel14, Me.xrLabel15, Me.xrLabel16, Me.xrLabel17, Me.xrLabel18})
        Me.Detail.HeightF = 23.95833!
        Me.Detail.Name = "Detail"
        Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.Detail.StyleName = "DataField"
        Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'xrLabel13
        '
        Me.xrLabel13.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "GetAgingProfile.Account Description")})
        Me.xrLabel13.LocationFloat = New DevExpress.Utils.PointFloat(55.37849!, 0.0!)
        Me.xrLabel13.Name = "xrLabel13"
        Me.xrLabel13.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel13.SizeF = New System.Drawing.SizeF(152.6056!, 15.0!)
        Me.xrLabel13.Text = "xrLabel13"
        '
        'xrLabel14
        '
        Me.xrLabel14.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "GetAgingProfile.Current Bal", "{0:###,###.00}")})
        Me.xrLabel14.LocationFloat = New DevExpress.Utils.PointFloat(207.9841!, 0.0!)
        Me.xrLabel14.Name = "xrLabel14"
        Me.xrLabel14.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel14.SizeF = New System.Drawing.SizeF(93.25896!, 15.0!)
        Me.xrLabel14.StylePriority.UseTextAlignment = False
        Me.xrLabel14.Text = "xrLabel14"
        Me.xrLabel14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'xrLabel15
        '
        Me.xrLabel15.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "GetAgingProfile.00-30 days", "{0:###,###.00}")})
        Me.xrLabel15.LocationFloat = New DevExpress.Utils.PointFloat(301.243!, 0.0!)
        Me.xrLabel15.Name = "xrLabel15"
        Me.xrLabel15.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel15.SizeF = New System.Drawing.SizeF(81.14742!, 15.0!)
        Me.xrLabel15.StylePriority.UseTextAlignment = False
        Me.xrLabel15.Text = "xrLabel15"
        Me.xrLabel15.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'xrLabel16
        '
        Me.xrLabel16.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "GetAgingProfile.31-60 days", "{0:###,###.00}")})
        Me.xrLabel16.LocationFloat = New DevExpress.Utils.PointFloat(382.3904!, 0.0!)
        Me.xrLabel16.Name = "xrLabel16"
        Me.xrLabel16.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel16.SizeF = New System.Drawing.SizeF(81.14742!, 15.0!)
        Me.xrLabel16.StylePriority.UseTextAlignment = False
        Me.xrLabel16.Text = "xrLabel16"
        Me.xrLabel16.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'xrLabel17
        '
        Me.xrLabel17.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "GetAgingProfile.61-90 days", "{0:###,###.00}")})
        Me.xrLabel17.LocationFloat = New DevExpress.Utils.PointFloat(463.5378!, 0.0!)
        Me.xrLabel17.Name = "xrLabel17"
        Me.xrLabel17.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel17.SizeF = New System.Drawing.SizeF(81.14742!, 15.0!)
        Me.xrLabel17.StylePriority.UseTextAlignment = False
        Me.xrLabel17.Text = "xrLabel17"
        Me.xrLabel17.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'xrLabel18
        '
        Me.xrLabel18.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "GetAgingProfile.Over 90 days", "{0:###,###.00}")})
        Me.xrLabel18.LocationFloat = New DevExpress.Utils.PointFloat(544.6852!, 0.0!)
        Me.xrLabel18.Name = "xrLabel18"
        Me.xrLabel18.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel18.SizeF = New System.Drawing.SizeF(99.31476!, 15.0!)
        Me.xrLabel18.StylePriority.UseTextAlignment = False
        Me.xrLabel18.Text = "xrLabel18"
        Me.xrLabel18.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'dsAging1
        '
        'Me.dsAging1.DataSetName = "dsAging"
        'Me.dsAging1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'getAgingProfileTableAdapter1
        '
        'Me.getAgingProfileTableAdapter1.ClearBeforeFill = True
        '
        'groupHeaderBand1
        '
        Me.groupHeaderBand1.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.xrLabel3, Me.xrLabel4, Me.xrLabel1, Me.xrLine1})
        Me.groupHeaderBand1.GroupFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("BRANCH_CODE", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending), New DevExpress.XtraReports.UI.GroupField("BRANCH_NAME", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
        Me.groupHeaderBand1.HeightF = 65.08333!
        Me.groupHeaderBand1.Level = 1
        Me.groupHeaderBand1.Name = "groupHeaderBand1"
        '
        'xrLabel3
        '
        Me.xrLabel3.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "GetAgingProfile.BRANCH_CODE")})
        Me.xrLabel3.LocationFloat = New DevExpress.Utils.PointFloat(72.33334!, 29.08331!)
        Me.xrLabel3.Name = "xrLabel3"
        Me.xrLabel3.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel3.SizeF = New System.Drawing.SizeF(54.875!, 36.00001!)
        Me.xrLabel3.StyleName = "DataField"
        '
        'xrLabel4
        '
        Me.xrLabel4.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "GetAgingProfile.BRANCH_NAME")})
        Me.xrLabel4.LocationFloat = New DevExpress.Utils.PointFloat(127.2083!, 29.08331!)
        Me.xrLabel4.Name = "xrLabel4"
        Me.xrLabel4.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel4.SizeF = New System.Drawing.SizeF(174.0347!, 36.00001!)
        Me.xrLabel4.StyleName = "DataField"
        Me.xrLabel4.Text = "xrLabel4"
        '
        'xrLabel1
        '
        Me.xrLabel1.LocationFloat = New DevExpress.Utils.PointFloat(6.00001!, 29.08331!)
        Me.xrLabel1.Name = "xrLabel1"
        Me.xrLabel1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel1.SizeF = New System.Drawing.SizeF(66.33334!, 36.0!)
        Me.xrLabel1.StyleName = "FieldCaption"
        Me.xrLabel1.Text = "BRANCH"
        '
        'xrLine1
        '
        Me.xrLine1.LocationFloat = New DevExpress.Utils.PointFloat(6.0!, 27.08333!)
        Me.xrLine1.Name = "xrLine1"
        Me.xrLine1.SizeF = New System.Drawing.SizeF(450.0!, 2.0!)
        '
        'groupHeaderBand2
        '
        Me.groupHeaderBand2.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.xrLabel6, Me.xrLabel7, Me.xrLabel8, Me.xrLabel9, Me.xrLabel10, Me.xrLabel11})
        Me.groupHeaderBand2.HeightF = 24.0!
        Me.groupHeaderBand2.Name = "groupHeaderBand2"
        Me.groupHeaderBand2.StyleName = "FieldCaption"
        '
        'xrLabel6
        '
        Me.xrLabel6.LocationFloat = New DevExpress.Utils.PointFloat(55.37849!, 6.0!)
        Me.xrLabel6.Name = "xrLabel6"
        Me.xrLabel6.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel6.SizeF = New System.Drawing.SizeF(152.6056!, 18.0!)
        Me.xrLabel6.Text = "Account Description"
        '
        'xrLabel7
        '
        Me.xrLabel7.LocationFloat = New DevExpress.Utils.PointFloat(207.9841!, 6.0!)
        Me.xrLabel7.Name = "xrLabel7"
        Me.xrLabel7.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel7.SizeF = New System.Drawing.SizeF(93.25896!, 18.0!)
        Me.xrLabel7.StylePriority.UseTextAlignment = False
        Me.xrLabel7.Text = "Current Bal"
        Me.xrLabel7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'xrLabel8
        '
        Me.xrLabel8.LocationFloat = New DevExpress.Utils.PointFloat(301.243!, 6.0!)
        Me.xrLabel8.Name = "xrLabel8"
        Me.xrLabel8.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel8.SizeF = New System.Drawing.SizeF(81.14742!, 18.0!)
        Me.xrLabel8.StylePriority.UseTextAlignment = False
        Me.xrLabel8.Text = "00-30 days"
        Me.xrLabel8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'xrLabel9
        '
        Me.xrLabel9.LocationFloat = New DevExpress.Utils.PointFloat(382.3904!, 6.0!)
        Me.xrLabel9.Name = "xrLabel9"
        Me.xrLabel9.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel9.SizeF = New System.Drawing.SizeF(81.14742!, 18.0!)
        Me.xrLabel9.StylePriority.UseTextAlignment = False
        Me.xrLabel9.Text = "31-60 days"
        Me.xrLabel9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'xrLabel10
        '
        Me.xrLabel10.LocationFloat = New DevExpress.Utils.PointFloat(463.5378!, 6.0!)
        Me.xrLabel10.Name = "xrLabel10"
        Me.xrLabel10.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel10.SizeF = New System.Drawing.SizeF(81.14742!, 18.0!)
        Me.xrLabel10.StylePriority.UseTextAlignment = False
        Me.xrLabel10.Text = "61-90 days"
        Me.xrLabel10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'xrLabel11
        '
        Me.xrLabel11.LocationFloat = New DevExpress.Utils.PointFloat(544.6852!, 6.0!)
        Me.xrLabel11.Name = "xrLabel11"
        Me.xrLabel11.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel11.SizeF = New System.Drawing.SizeF(99.31476!, 18.0!)
        Me.xrLabel11.StylePriority.UseTextAlignment = False
        Me.xrLabel11.Text = "Over 90 days"
        Me.xrLabel11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'pageFooterBand1
        '
        Me.pageFooterBand1.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.xrLine2, Me.xrPageInfo1, Me.xrPageInfo2})
        Me.pageFooterBand1.HeightF = 31.0!
        Me.pageFooterBand1.Name = "pageFooterBand1"
        '
        'xrLine2
        '
        Me.xrLine2.LocationFloat = New DevExpress.Utils.PointFloat(6.0!, 0.0!)
        Me.xrLine2.Name = "xrLine2"
        Me.xrLine2.SizeF = New System.Drawing.SizeF(638.0!, 2.0!)
        '
        'xrPageInfo1
        '
        Me.xrPageInfo1.LocationFloat = New DevExpress.Utils.PointFloat(6.0!, 8.0!)
        Me.xrPageInfo1.Name = "xrPageInfo1"
        Me.xrPageInfo1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrPageInfo1.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime
        Me.xrPageInfo1.SizeF = New System.Drawing.SizeF(313.0!, 23.0!)
        Me.xrPageInfo1.StyleName = "PageInfo"
        '
        'xrPageInfo2
        '
        Me.xrPageInfo2.Format = "Page {0} of {1}"
        Me.xrPageInfo2.LocationFloat = New DevExpress.Utils.PointFloat(331.0!, 8.0!)
        Me.xrPageInfo2.Name = "xrPageInfo2"
        Me.xrPageInfo2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrPageInfo2.SizeF = New System.Drawing.SizeF(313.0!, 23.0!)
        Me.xrPageInfo2.StyleName = "PageInfo"
        Me.xrPageInfo2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'reportHeaderBand1
        '
        Me.reportHeaderBand1.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.xrLabel19, Me.xrLine3, Me.xrLine4})
        Me.reportHeaderBand1.HeightF = 57.0!
        Me.reportHeaderBand1.Name = "reportHeaderBand1"
        '
        'xrLabel19
        '
        Me.xrLabel19.LocationFloat = New DevExpress.Utils.PointFloat(6.0!, 2.0!)
        Me.xrLabel19.Name = "xrLabel19"
        Me.xrLabel19.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel19.SizeF = New System.Drawing.SizeF(638.0!, 39.0!)
        Me.xrLabel19.StyleName = "Title"
        Me.xrLabel19.Text = "Aging Profile"
        '
        'xrLine3
        '
        Me.xrLine3.LocationFloat = New DevExpress.Utils.PointFloat(6.0!, 0.0!)
        Me.xrLine3.Name = "xrLine3"
        Me.xrLine3.SizeF = New System.Drawing.SizeF(638.0!, 2.0!)
        '
        'xrLine4
        '
        Me.xrLine4.LocationFloat = New DevExpress.Utils.PointFloat(6.0!, 41.0!)
        Me.xrLine4.Name = "xrLine4"
        Me.xrLine4.SizeF = New System.Drawing.SizeF(638.0!, 2.0!)
        '
        'groupFooterBand1
        '
        Me.groupFooterBand1.HeightF = 1.0!
        Me.groupFooterBand1.Name = "groupFooterBand1"
        '
        'groupFooterBand2
        '
        Me.groupFooterBand2.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.xrLine6, Me.xrLine5, Me.xrLabel20, Me.xrLabel21, Me.xrLabel22, Me.xrLabel23, Me.xrLabel24, Me.xrLabel25, Me.xrLabel44})
        Me.groupFooterBand2.HeightF = 71.08339!
        Me.groupFooterBand2.Level = 1
        Me.groupFooterBand2.Name = "groupFooterBand2"
        '
        'xrLine6
        '
        Me.xrLine6.LocationFloat = New DevExpress.Utils.PointFloat(2.775892!, 2.791659!)
        Me.xrLine6.Name = "xrLine6"
        Me.xrLine6.SizeF = New System.Drawing.SizeF(647.2241!, 23.0!)
        '
        'xrLine5
        '
        Me.xrLine5.LocationFloat = New DevExpress.Utils.PointFloat(2.775892!, 43.79168!)
        Me.xrLine5.Name = "xrLine5"
        Me.xrLine5.SizeF = New System.Drawing.SizeF(647.2241!, 23.0!)
        '
        'xrLabel20
        '
        Me.xrLabel20.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "GetAgingProfile.Current Bal", "{0:C2}")})
        Me.xrLabel20.LocationFloat = New DevExpress.Utils.PointFloat(207.9841!, 25.79167!)
        Me.xrLabel20.Name = "xrLabel20"
        Me.xrLabel20.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel20.SizeF = New System.Drawing.SizeF(93.25896!, 18.0!)
        Me.xrLabel20.StyleName = "FieldCaption"
        Me.xrLabel20.StylePriority.UseTextAlignment = False
        xrSummary1.FormatString = "{0:0.00}"
        xrSummary1.IgnoreNullValues = True
        xrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
        Me.xrLabel20.Summary = xrSummary1
        Me.xrLabel20.Text = "xrLabel20"
        Me.xrLabel20.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'xrLabel21
        '
        Me.xrLabel21.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "GetAgingProfile.00-30 days", "{0:C2}")})
        Me.xrLabel21.LocationFloat = New DevExpress.Utils.PointFloat(301.243!, 25.79167!)
        Me.xrLabel21.Name = "xrLabel21"
        Me.xrLabel21.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel21.SizeF = New System.Drawing.SizeF(81.14742!, 18.0!)
        Me.xrLabel21.StyleName = "FieldCaption"
        Me.xrLabel21.StylePriority.UseTextAlignment = False
        xrSummary2.FormatString = "{0:0.00}"
        xrSummary2.IgnoreNullValues = True
        xrSummary2.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
        Me.xrLabel21.Summary = xrSummary2
        Me.xrLabel21.Text = "xrLabel21"
        Me.xrLabel21.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'xrLabel22
        '
        Me.xrLabel22.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "GetAgingProfile.31-60 days", "{0:C2}")})
        Me.xrLabel22.LocationFloat = New DevExpress.Utils.PointFloat(382.3904!, 25.79167!)
        Me.xrLabel22.Name = "xrLabel22"
        Me.xrLabel22.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel22.SizeF = New System.Drawing.SizeF(81.14742!, 18.0!)
        Me.xrLabel22.StyleName = "FieldCaption"
        Me.xrLabel22.StylePriority.UseTextAlignment = False
        xrSummary3.FormatString = "{0:0.00}"
        xrSummary3.IgnoreNullValues = True
        xrSummary3.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
        Me.xrLabel22.Summary = xrSummary3
        Me.xrLabel22.Text = "xrLabel22"
        Me.xrLabel22.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'xrLabel23
        '
        Me.xrLabel23.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "GetAgingProfile.61-90 days", "{0:C2}")})
        Me.xrLabel23.LocationFloat = New DevExpress.Utils.PointFloat(463.5378!, 25.79167!)
        Me.xrLabel23.Name = "xrLabel23"
        Me.xrLabel23.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel23.SizeF = New System.Drawing.SizeF(81.14742!, 18.0!)
        Me.xrLabel23.StyleName = "FieldCaption"
        Me.xrLabel23.StylePriority.UseTextAlignment = False
        xrSummary4.FormatString = "{0:0.00}"
        xrSummary4.IgnoreNullValues = True
        xrSummary4.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
        Me.xrLabel23.Summary = xrSummary4
        Me.xrLabel23.Text = "xrLabel23"
        Me.xrLabel23.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'xrLabel24
        '
        Me.xrLabel24.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "GetAgingProfile.Over 90 days", "{0:C2}")})
        Me.xrLabel24.LocationFloat = New DevExpress.Utils.PointFloat(544.6852!, 25.79167!)
        Me.xrLabel24.Name = "xrLabel24"
        Me.xrLabel24.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel24.SizeF = New System.Drawing.SizeF(99.31476!, 18.0!)
        Me.xrLabel24.StyleName = "FieldCaption"
        Me.xrLabel24.StylePriority.UseTextAlignment = False
        xrSummary5.FormatString = "{0:0.00}"
        xrSummary5.IgnoreNullValues = True
        xrSummary5.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
        Me.xrLabel24.Summary = xrSummary5
        Me.xrLabel24.Text = "xrLabel24"
        Me.xrLabel24.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'xrLabel25
        '
        Me.xrLabel25.LocationFloat = New DevExpress.Utils.PointFloat(6.00001!, 25.79168!)
        Me.xrLabel25.Name = "xrLabel25"
        Me.xrLabel25.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel25.SizeF = New System.Drawing.SizeF(93.54169!, 18.0!)
        Me.xrLabel25.StyleName = "FieldCaption"
        Me.xrLabel25.Text = "Sum"
        '
        'xrLabel44
        '
        Me.xrLabel44.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "GetAgingProfile.id", "{0:C2}")})
        Me.xrLabel44.LocationFloat = New DevExpress.Utils.PointFloat(102.7757!, 25.79167!)
        Me.xrLabel44.Name = "xrLabel44"
        Me.xrLabel44.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel44.SizeF = New System.Drawing.SizeF(93.25896!, 18.0!)
        Me.xrLabel44.StyleName = "FieldCaption"
        xrSummary6.FormatString = "{0:###,###}"
        xrSummary6.Func = DevExpress.XtraReports.UI.SummaryFunc.Count
        xrSummary6.IgnoreNullValues = True
        xrSummary6.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
        Me.xrLabel44.Summary = xrSummary6
        '
        'reportFooterBand1
        '
        Me.reportFooterBand1.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.xrLabel50, Me.xrLabel51, Me.xrLabel52, Me.xrLabel53, Me.xrLabel54, Me.xrLabel55})
        Me.reportFooterBand1.HeightF = 30.0!
        Me.reportFooterBand1.Name = "reportFooterBand1"
        '
        'xrLabel50
        '
        Me.xrLabel50.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "GetAgingProfile.Current Bal", "{0:C2}")})
        Me.xrLabel50.LocationFloat = New DevExpress.Utils.PointFloat(207.9841!, 6.0!)
        Me.xrLabel50.Name = "xrLabel50"
        Me.xrLabel50.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel50.SizeF = New System.Drawing.SizeF(93.25896!, 18.0!)
        Me.xrLabel50.StyleName = "FieldCaption"
        Me.xrLabel50.StylePriority.UseTextAlignment = False
        xrSummary7.FormatString = "{0:0.00}"
        xrSummary7.IgnoreNullValues = True
        xrSummary7.Running = DevExpress.XtraReports.UI.SummaryRunning.Report
        Me.xrLabel50.Summary = xrSummary7
        Me.xrLabel50.Text = "xrLabel50"
        Me.xrLabel50.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'xrLabel51
        '
        Me.xrLabel51.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "GetAgingProfile.00-30 days", "{0:C2}")})
        Me.xrLabel51.LocationFloat = New DevExpress.Utils.PointFloat(301.243!, 6.0!)
        Me.xrLabel51.Name = "xrLabel51"
        Me.xrLabel51.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel51.SizeF = New System.Drawing.SizeF(81.14742!, 18.0!)
        Me.xrLabel51.StyleName = "FieldCaption"
        Me.xrLabel51.StylePriority.UseTextAlignment = False
        xrSummary8.FormatString = "{0:0.00}"
        xrSummary8.IgnoreNullValues = True
        xrSummary8.Running = DevExpress.XtraReports.UI.SummaryRunning.Report
        Me.xrLabel51.Summary = xrSummary8
        Me.xrLabel51.Text = "xrLabel51"
        Me.xrLabel51.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'xrLabel52
        '
        Me.xrLabel52.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "GetAgingProfile.31-60 days", "{0:C2}")})
        Me.xrLabel52.LocationFloat = New DevExpress.Utils.PointFloat(382.3904!, 6.0!)
        Me.xrLabel52.Name = "xrLabel52"
        Me.xrLabel52.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel52.SizeF = New System.Drawing.SizeF(81.14742!, 18.0!)
        Me.xrLabel52.StyleName = "FieldCaption"
        Me.xrLabel52.StylePriority.UseTextAlignment = False
        xrSummary9.FormatString = "{0:0.00}"
        xrSummary9.IgnoreNullValues = True
        xrSummary9.Running = DevExpress.XtraReports.UI.SummaryRunning.Report
        Me.xrLabel52.Summary = xrSummary9
        Me.xrLabel52.Text = "xrLabel52"
        Me.xrLabel52.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'xrLabel53
        '
        Me.xrLabel53.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "GetAgingProfile.61-90 days", "{0:C2}")})
        Me.xrLabel53.LocationFloat = New DevExpress.Utils.PointFloat(463.5378!, 6.0!)
        Me.xrLabel53.Name = "xrLabel53"
        Me.xrLabel53.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel53.SizeF = New System.Drawing.SizeF(81.14742!, 18.0!)
        Me.xrLabel53.StyleName = "FieldCaption"
        Me.xrLabel53.StylePriority.UseTextAlignment = False
        xrSummary10.FormatString = "{0:0.00}"
        xrSummary10.IgnoreNullValues = True
        xrSummary10.Running = DevExpress.XtraReports.UI.SummaryRunning.Report
        Me.xrLabel53.Summary = xrSummary10
        Me.xrLabel53.Text = "xrLabel53"
        Me.xrLabel53.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'xrLabel54
        '
        Me.xrLabel54.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "GetAgingProfile.Over 90 days", "{0:C2}")})
        Me.xrLabel54.LocationFloat = New DevExpress.Utils.PointFloat(544.6852!, 6.0!)
        Me.xrLabel54.Name = "xrLabel54"
        Me.xrLabel54.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel54.SizeF = New System.Drawing.SizeF(99.31476!, 18.0!)
        Me.xrLabel54.StyleName = "FieldCaption"
        Me.xrLabel54.StylePriority.UseTextAlignment = False
        xrSummary11.FormatString = "{0:0.00}"
        xrSummary11.IgnoreNullValues = True
        xrSummary11.Running = DevExpress.XtraReports.UI.SummaryRunning.Report
        Me.xrLabel54.Summary = xrSummary11
        Me.xrLabel54.Text = "xrLabel54"
        Me.xrLabel54.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'xrLabel55
        '
        Me.xrLabel55.LocationFloat = New DevExpress.Utils.PointFloat(6.00001!, 6.00001!)
        Me.xrLabel55.Name = "xrLabel55"
        Me.xrLabel55.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel55.SizeF = New System.Drawing.SizeF(108.0!, 18.0!)
        Me.xrLabel55.StyleName = "FieldCaption"
        Me.xrLabel55.Text = "Grand Total"
        '
        'Title
        '
        Me.Title.BackColor = System.Drawing.Color.Transparent
        Me.Title.BorderColor = System.Drawing.Color.Black
        Me.Title.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.Title.BorderWidth = 1.0!
        Me.Title.Font = New System.Drawing.Font("Times New Roman", 24.0!)
        Me.Title.ForeColor = System.Drawing.Color.Black
        Me.Title.Name = "Title"
        '
        'FieldCaption
        '
        Me.FieldCaption.BackColor = System.Drawing.Color.Transparent
        Me.FieldCaption.BorderColor = System.Drawing.Color.Black
        Me.FieldCaption.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.FieldCaption.BorderWidth = 1.0!
        Me.FieldCaption.Font = New System.Drawing.Font("Times New Roman", 10.0!, System.Drawing.FontStyle.Bold)
        Me.FieldCaption.ForeColor = System.Drawing.Color.Black
        Me.FieldCaption.Name = "FieldCaption"
        '
        'PageInfo
        '
        Me.PageInfo.BackColor = System.Drawing.Color.Transparent
        Me.PageInfo.BorderColor = System.Drawing.Color.Black
        Me.PageInfo.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.PageInfo.BorderWidth = 1.0!
        Me.PageInfo.Font = New System.Drawing.Font("Times New Roman", 8.0!)
        Me.PageInfo.ForeColor = System.Drawing.Color.Black
        Me.PageInfo.Name = "PageInfo"
        '
        'DataField
        '
        Me.DataField.BackColor = System.Drawing.Color.Transparent
        Me.DataField.BorderColor = System.Drawing.Color.Black
        Me.DataField.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.DataField.BorderWidth = 1.0!
        Me.DataField.Font = New System.Drawing.Font("Times New Roman", 8.0!)
        Me.DataField.ForeColor = System.Drawing.Color.Black
        Me.DataField.Name = "DataField"
        Me.DataField.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        '
        'topMarginBand1
        '
        Me.topMarginBand1.Name = "topMarginBand1"
        '
        'bottomMarginBand1
        '
        Me.bottomMarginBand1.Name = "bottomMarginBand1"
        '
        'rptAging
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.groupHeaderBand1, Me.groupHeaderBand2, Me.pageFooterBand1, Me.reportHeaderBand1, Me.groupFooterBand2, Me.reportFooterBand1, Me.topMarginBand1, Me.bottomMarginBand1})
        ' Me.DataAdapter = Me.getAgingProfileTableAdapter1
        Me.DataMember = "GetAgingProfile"
        ' Me.DataSource = Me.dsAging1
        Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
        Me.StyleSheet.AddRange(New DevExpress.XtraReports.UI.XRControlStyle() {Me.Title, Me.FieldCaption, Me.PageInfo, Me.DataField})
        Me.Version = "13.2"
        Me.Watermark.ForeColor = System.Drawing.Color.LightGray
        Me.Watermark.Text = "Escrow 360"
        'CType(Me.dsAging1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand

#End Region

End Class