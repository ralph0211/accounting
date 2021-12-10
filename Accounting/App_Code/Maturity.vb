Public Class Maturity
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
    Private WithEvents dsMaturity1 As dsMaturity
    Private WithEvents dsMaturity2 As dsMaturity
    Private WithEvents getMaturityProfileTableAdapter1 As dsMaturityTableAdapters.GetMaturityProfileTableAdapter
    Private WithEvents xrLabel14 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel15 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel16 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel17 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel18 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel19 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel20 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents groupHeaderBand1 As DevExpress.XtraReports.UI.GroupHeaderBand
    Private WithEvents xrLabel2 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel1 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLine1 As DevExpress.XtraReports.UI.XRLine
    Private WithEvents groupHeaderBand2 As DevExpress.XtraReports.UI.GroupHeaderBand
    Private WithEvents xrLabel5 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel6 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel3 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel4 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLine2 As DevExpress.XtraReports.UI.XRLine
    Private WithEvents groupHeaderBand3 As DevExpress.XtraReports.UI.GroupHeaderBand
    Private WithEvents xrLabel7 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel8 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel9 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel10 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel11 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel12 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel13 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents pageFooterBand1 As DevExpress.XtraReports.UI.PageFooterBand
    Private WithEvents xrLine3 As DevExpress.XtraReports.UI.XRLine
    Private WithEvents xrPageInfo1 As DevExpress.XtraReports.UI.XRPageInfo
    Private WithEvents xrPageInfo2 As DevExpress.XtraReports.UI.XRPageInfo
    Private WithEvents reportHeaderBand1 As DevExpress.XtraReports.UI.ReportHeaderBand
    Private WithEvents xrLabel21 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLine4 As DevExpress.XtraReports.UI.XRLine
    Private WithEvents xrLine5 As DevExpress.XtraReports.UI.XRLine
    Private WithEvents groupFooterBand1 As DevExpress.XtraReports.UI.GroupFooterBand
    Private WithEvents groupFooterBand2 As DevExpress.XtraReports.UI.GroupFooterBand
    Private WithEvents xrLabel22 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel23 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel24 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel25 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel26 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel27 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel28 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel29 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel30 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel31 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents groupFooterBand3 As DevExpress.XtraReports.UI.GroupFooterBand
    Private WithEvents xrLabel32 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel33 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel34 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel35 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel36 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel37 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel38 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel39 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel40 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel41 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents reportFooterBand1 As DevExpress.XtraReports.UI.ReportFooterBand
    Private WithEvents xrLabel42 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel43 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents Title As DevExpress.XtraReports.UI.XRControlStyle
    Private WithEvents FieldCaption As DevExpress.XtraReports.UI.XRControlStyle
    Private WithEvents PageInfo As DevExpress.XtraReports.UI.XRControlStyle
    Private WithEvents DataField As DevExpress.XtraReports.UI.XRControlStyle
    Private WithEvents topMarginBand1 As DevExpress.XtraReports.UI.TopMarginBand
    Private WithEvents bottomMarginBand1 As DevExpress.XtraReports.UI.BottomMarginBand

    'Required by the Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Designer
    'It can be modified using the Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resourceFileName As String = "Maturity.resx"
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
        Me.dsMaturity1 = New dsMaturity()
        Me.dsMaturity2 = New dsMaturity()
        Me.getMaturityProfileTableAdapter1 = New dsMaturityTableAdapters.GetMaturityProfileTableAdapter()
        Me.groupHeaderBand1 = New DevExpress.XtraReports.UI.GroupHeaderBand()
        Me.xrLabel1 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel2 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLine1 = New DevExpress.XtraReports.UI.XRLine()
        Me.groupHeaderBand2 = New DevExpress.XtraReports.UI.GroupHeaderBand()
        Me.xrLabel3 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel4 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel5 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel6 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLine2 = New DevExpress.XtraReports.UI.XRLine()
        Me.groupHeaderBand3 = New DevExpress.XtraReports.UI.GroupHeaderBand()
        Me.xrLabel7 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel8 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel9 = New DevExpress.XtraReports.UI.XRLabel()
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
        Me.pageFooterBand1 = New DevExpress.XtraReports.UI.PageFooterBand()
        Me.xrLine3 = New DevExpress.XtraReports.UI.XRLine()
        Me.xrPageInfo1 = New DevExpress.XtraReports.UI.XRPageInfo()
        Me.xrPageInfo2 = New DevExpress.XtraReports.UI.XRPageInfo()
        Me.reportHeaderBand1 = New DevExpress.XtraReports.UI.ReportHeaderBand()
        Me.xrLabel21 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLine4 = New DevExpress.XtraReports.UI.XRLine()
        Me.xrLine5 = New DevExpress.XtraReports.UI.XRLine()
        Me.groupFooterBand1 = New DevExpress.XtraReports.UI.GroupFooterBand()
        Me.groupFooterBand2 = New DevExpress.XtraReports.UI.GroupFooterBand()
        Me.xrLabel22 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel23 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel24 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel25 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel26 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel27 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel28 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel29 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel30 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel31 = New DevExpress.XtraReports.UI.XRLabel()
        Me.groupFooterBand3 = New DevExpress.XtraReports.UI.GroupFooterBand()
        Me.xrLabel32 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel33 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel34 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel35 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel36 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel37 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel38 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel39 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel40 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel41 = New DevExpress.XtraReports.UI.XRLabel()
        Me.reportFooterBand1 = New DevExpress.XtraReports.UI.ReportFooterBand()
        Me.xrLabel42 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel43 = New DevExpress.XtraReports.UI.XRLabel()
        Me.Title = New DevExpress.XtraReports.UI.XRControlStyle()
        Me.FieldCaption = New DevExpress.XtraReports.UI.XRControlStyle()
        Me.PageInfo = New DevExpress.XtraReports.UI.XRControlStyle()
        Me.DataField = New DevExpress.XtraReports.UI.XRControlStyle()
        Me.topMarginBand1 = New DevExpress.XtraReports.UI.TopMarginBand()
        Me.bottomMarginBand1 = New DevExpress.XtraReports.UI.BottomMarginBand()
        CType(Me.dsMaturity1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dsMaturity2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.xrLabel14, Me.xrLabel15, Me.xrLabel16, Me.xrLabel17, Me.xrLabel18, Me.xrLabel19, Me.xrLabel20})
        Me.Detail.HeightF = 125.0!
        Me.Detail.Name = "Detail"
        Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.Detail.StyleName = "DataField"
        Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'dsMaturity1
        '
        Me.dsMaturity1.DataSetName = "dsMaturity"
        Me.dsMaturity1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'dsMaturity2
        '
        Me.dsMaturity2.DataSetName = "dsMaturity"
        Me.dsMaturity2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'getMaturityProfileTableAdapter1
        '
        Me.getMaturityProfileTableAdapter1.ClearBeforeFill = True
        '
        'groupHeaderBand1
        '
        Me.groupHeaderBand1.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.xrLabel2, Me.xrLabel1, Me.xrLine1})
        Me.groupHeaderBand1.GroupFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("CUSTOMER_TYPE", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
        Me.groupHeaderBand1.HeightF = 38.0!
        Me.groupHeaderBand1.Level = 2
        Me.groupHeaderBand1.Name = "groupHeaderBand1"
        '
        'xrLabel1
        '
        Me.xrLabel1.LocationFloat = New DevExpress.Utils.PointFloat(6.0!, 2.0!)
        Me.xrLabel1.Name = "xrLabel1"
        Me.xrLabel1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel1.SizeF = New System.Drawing.SizeF(125.0!, 36.0!)
        Me.xrLabel1.StyleName = "FieldCaption"
        Me.xrLabel1.Text = "CUSTOMER TYPE"
        '
        'xrLabel2
        '
        Me.xrLabel2.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "GetMaturityProfile.CUSTOMER_TYPE")})
        Me.xrLabel2.LocationFloat = New DevExpress.Utils.PointFloat(131.0!, 2.0!)
        Me.xrLabel2.Name = "xrLabel2"
        Me.xrLabel2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel2.SizeF = New System.Drawing.SizeF(125.0!, 36.0!)
        Me.xrLabel2.StyleName = "DataField"
        Me.xrLabel2.Text = "xrLabel2"
        '
        'xrLine1
        '
        Me.xrLine1.LocationFloat = New DevExpress.Utils.PointFloat(6.0!, 0.0!)
        Me.xrLine1.Name = "xrLine1"
        Me.xrLine1.SizeF = New System.Drawing.SizeF(256.0!, 2.0!)
        '
        'groupHeaderBand2
        '
        Me.groupHeaderBand2.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.xrLabel5, Me.xrLabel6, Me.xrLabel3, Me.xrLabel4, Me.xrLine2})
        Me.groupHeaderBand2.GroupFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("BRANCH_CODE", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending), New DevExpress.XtraReports.UI.GroupField("BRANCH_NAME", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
        Me.groupHeaderBand2.HeightF = 38.0!
        Me.groupHeaderBand2.Level = 1
        Me.groupHeaderBand2.Name = "groupHeaderBand2"
        '
        'xrLabel3
        '
        Me.xrLabel3.LocationFloat = New DevExpress.Utils.PointFloat(36.0!, 2.0!)
        Me.xrLabel3.Name = "xrLabel3"
        Me.xrLabel3.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel3.SizeF = New System.Drawing.SizeF(108.0!, 36.0!)
        Me.xrLabel3.StyleName = "FieldCaption"
        Me.xrLabel3.Text = "BRANCH CODE"
        '
        'xrLabel4
        '
        Me.xrLabel4.LocationFloat = New DevExpress.Utils.PointFloat(258.0!, 2.0!)
        Me.xrLabel4.Name = "xrLabel4"
        Me.xrLabel4.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel4.SizeF = New System.Drawing.SizeF(111.0!, 36.0!)
        Me.xrLabel4.StyleName = "FieldCaption"
        Me.xrLabel4.Text = "BRANCH NAME"
        '
        'xrLabel5
        '
        Me.xrLabel5.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "GetMaturityProfile.BRANCH_CODE")})
        Me.xrLabel5.LocationFloat = New DevExpress.Utils.PointFloat(144.0!, 2.0!)
        Me.xrLabel5.Name = "xrLabel5"
        Me.xrLabel5.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel5.SizeF = New System.Drawing.SizeF(108.0!, 36.0!)
        Me.xrLabel5.StyleName = "DataField"
        Me.xrLabel5.Text = "xrLabel5"
        '
        'xrLabel6
        '
        Me.xrLabel6.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "GetMaturityProfile.BRANCH_NAME")})
        Me.xrLabel6.LocationFloat = New DevExpress.Utils.PointFloat(369.0!, 2.0!)
        Me.xrLabel6.Name = "xrLabel6"
        Me.xrLabel6.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel6.SizeF = New System.Drawing.SizeF(111.0!, 36.0!)
        Me.xrLabel6.StyleName = "DataField"
        Me.xrLabel6.Text = "xrLabel6"
        '
        'xrLine2
        '
        Me.xrLine2.LocationFloat = New DevExpress.Utils.PointFloat(36.0!, 0.0!)
        Me.xrLine2.Name = "xrLine2"
        Me.xrLine2.SizeF = New System.Drawing.SizeF(450.0!, 2.0!)
        '
        'groupHeaderBand3
        '
        Me.groupHeaderBand3.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.xrLabel7, Me.xrLabel8, Me.xrLabel9, Me.xrLabel10, Me.xrLabel11, Me.xrLabel12, Me.xrLabel13})
        Me.groupHeaderBand3.HeightF = 24.0!
        Me.groupHeaderBand3.Name = "groupHeaderBand3"
        Me.groupHeaderBand3.StyleName = "FieldCaption"
        '
        'xrLabel7
        '
        Me.xrLabel7.LocationFloat = New DevExpress.Utils.PointFloat(66.0!, 6.0!)
        Me.xrLabel7.Name = "xrLabel7"
        Me.xrLabel7.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel7.SizeF = New System.Drawing.SizeF(96.88539!, 18.0!)
        Me.xrLabel7.Text = "PAYMENT DATE"
        '
        'xrLabel8
        '
        Me.xrLabel8.LocationFloat = New DevExpress.Utils.PointFloat(162.8854!, 6.0!)
        Me.xrLabel8.Name = "xrLabel8"
        Me.xrLabel8.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel8.SizeF = New System.Drawing.SizeF(62.10602!, 18.0!)
        Me.xrLabel8.Text = "PAYMENT"
        '
        'xrLabel9
        '
        Me.xrLabel9.LocationFloat = New DevExpress.Utils.PointFloat(224.9914!, 6.0!)
        Me.xrLabel9.Name = "xrLabel9"
        Me.xrLabel9.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel9.SizeF = New System.Drawing.SizeF(124.212!, 18.0!)
        Me.xrLabel9.Text = "CUSTOMER NUMBER"
        '
        'xrLabel10
        '
        Me.xrLabel10.LocationFloat = New DevExpress.Utils.PointFloat(349.2034!, 6.0!)
        Me.xrLabel10.Name = "xrLabel10"
        Me.xrLabel10.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel10.SizeF = New System.Drawing.SizeF(62.10602!, 18.0!)
        Me.xrLabel10.Text = "SURNAME"
        '
        'xrLabel11
        '
        Me.xrLabel11.LocationFloat = New DevExpress.Utils.PointFloat(411.3094!, 6.0!)
        Me.xrLabel11.Name = "xrLabel11"
        Me.xrLabel11.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel11.SizeF = New System.Drawing.SizeF(77.01146!, 18.0!)
        Me.xrLabel11.Text = "FORENAMES"
        '
        'xrLabel12
        '
        Me.xrLabel12.LocationFloat = New DevExpress.Utils.PointFloat(488.3209!, 6.0!)
        Me.xrLabel12.Name = "xrLabel12"
        Me.xrLabel12.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel12.SizeF = New System.Drawing.SizeF(72.04298!, 18.0!)
        Me.xrLabel12.Text = "ISSUE DATE"
        '
        'xrLabel13
        '
        Me.xrLabel13.LocationFloat = New DevExpress.Utils.PointFloat(560.3639!, 6.0!)
        Me.xrLabel13.Name = "xrLabel13"
        Me.xrLabel13.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel13.SizeF = New System.Drawing.SizeF(83.63611!, 18.0!)
        Me.xrLabel13.Text = "AMT APPLIED"
        '
        'xrLabel14
        '
        Me.xrLabel14.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "GetMaturityProfile.PAYMENT_DATE")})
        Me.xrLabel14.LocationFloat = New DevExpress.Utils.PointFloat(66.0!, 0.0!)
        Me.xrLabel14.Name = "xrLabel14"
        Me.xrLabel14.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96.0!)
        Me.xrLabel14.SizeF = New System.Drawing.SizeF(96.88539!, 15.0!)
        Me.xrLabel14.Text = "xrLabel14"
        '
        'xrLabel15
        '
        Me.xrLabel15.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "GetMaturityProfile.PAYMENT", "{0:C2}")})
        Me.xrLabel15.LocationFloat = New DevExpress.Utils.PointFloat(162.8854!, 0.0!)
        Me.xrLabel15.Name = "xrLabel15"
        Me.xrLabel15.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96.0!)
        Me.xrLabel15.SizeF = New System.Drawing.SizeF(62.10602!, 15.0!)
        Me.xrLabel15.Text = "xrLabel15"
        '
        'xrLabel16
        '
        Me.xrLabel16.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "GetMaturityProfile.CUSTOMER_NUMBER")})
        Me.xrLabel16.LocationFloat = New DevExpress.Utils.PointFloat(224.9914!, 0.0!)
        Me.xrLabel16.Name = "xrLabel16"
        Me.xrLabel16.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96.0!)
        Me.xrLabel16.SizeF = New System.Drawing.SizeF(124.212!, 15.0!)
        Me.xrLabel16.Text = "xrLabel16"
        '
        'xrLabel17
        '
        Me.xrLabel17.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "GetMaturityProfile.SURNAME")})
        Me.xrLabel17.LocationFloat = New DevExpress.Utils.PointFloat(349.2034!, 0.0!)
        Me.xrLabel17.Name = "xrLabel17"
        Me.xrLabel17.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96.0!)
        Me.xrLabel17.SizeF = New System.Drawing.SizeF(62.10602!, 15.0!)
        Me.xrLabel17.Text = "xrLabel17"
        '
        'xrLabel18
        '
        Me.xrLabel18.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "GetMaturityProfile.FORENAMES")})
        Me.xrLabel18.LocationFloat = New DevExpress.Utils.PointFloat(411.3094!, 0.0!)
        Me.xrLabel18.Name = "xrLabel18"
        Me.xrLabel18.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96.0!)
        Me.xrLabel18.SizeF = New System.Drawing.SizeF(77.01146!, 15.0!)
        Me.xrLabel18.Text = "xrLabel18"
        '
        'xrLabel19
        '
        Me.xrLabel19.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "GetMaturityProfile.ISSUE_DATE")})
        Me.xrLabel19.LocationFloat = New DevExpress.Utils.PointFloat(488.3209!, 0.0!)
        Me.xrLabel19.Name = "xrLabel19"
        Me.xrLabel19.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96.0!)
        Me.xrLabel19.SizeF = New System.Drawing.SizeF(72.04298!, 15.0!)
        Me.xrLabel19.Text = "xrLabel19"
        '
        'xrLabel20
        '
        Me.xrLabel20.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "GetMaturityProfile.AMT_APPLIED", "{0:C2}")})
        Me.xrLabel20.LocationFloat = New DevExpress.Utils.PointFloat(560.3639!, 0.0!)
        Me.xrLabel20.Name = "xrLabel20"
        Me.xrLabel20.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96.0!)
        Me.xrLabel20.SizeF = New System.Drawing.SizeF(83.63611!, 15.0!)
        Me.xrLabel20.Text = "xrLabel20"
        '
        'pageFooterBand1
        '
        Me.pageFooterBand1.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.xrLine3, Me.xrPageInfo1, Me.xrPageInfo2})
        Me.pageFooterBand1.HeightF = 31.0!
        Me.pageFooterBand1.Name = "pageFooterBand1"
        '
        'xrLine3
        '
        Me.xrLine3.LocationFloat = New DevExpress.Utils.PointFloat(6.0!, 0.0!)
        Me.xrLine3.Name = "xrLine3"
        Me.xrLine3.SizeF = New System.Drawing.SizeF(638.0!, 2.0!)
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
        Me.reportHeaderBand1.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.xrLabel21, Me.xrLine4, Me.xrLine5})
        Me.reportHeaderBand1.HeightF = 57.0!
        Me.reportHeaderBand1.Name = "reportHeaderBand1"
        '
        'xrLabel21
        '
        Me.xrLabel21.LocationFloat = New DevExpress.Utils.PointFloat(6.0!, 2.0!)
        Me.xrLabel21.Name = "xrLabel21"
        Me.xrLabel21.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel21.SizeF = New System.Drawing.SizeF(638.0!, 39.0!)
        Me.xrLabel21.StyleName = "Title"
        Me.xrLabel21.Text = "Maturity Profile"
        '
        'xrLine4
        '
        Me.xrLine4.LocationFloat = New DevExpress.Utils.PointFloat(6.0!, 0.0!)
        Me.xrLine4.Name = "xrLine4"
        Me.xrLine4.SizeF = New System.Drawing.SizeF(638.0!, 2.0!)
        '
        'xrLine5
        '
        Me.xrLine5.LocationFloat = New DevExpress.Utils.PointFloat(6.0!, 41.0!)
        Me.xrLine5.Name = "xrLine5"
        Me.xrLine5.SizeF = New System.Drawing.SizeF(638.0!, 2.0!)
        '
        'groupFooterBand1
        '
        Me.groupFooterBand1.HeightF = 1.0!
        Me.groupFooterBand1.Name = "groupFooterBand1"
        '
        'groupFooterBand2
        '
        Me.groupFooterBand2.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.xrLabel22, Me.xrLabel23, Me.xrLabel24, Me.xrLabel25, Me.xrLabel26, Me.xrLabel27, Me.xrLabel28, Me.xrLabel29, Me.xrLabel30, Me.xrLabel31})
        Me.groupFooterBand2.HeightF = 126.0!
        Me.groupFooterBand2.Level = 1
        Me.groupFooterBand2.Name = "groupFooterBand2"
        '
        'xrLabel22
        '
        Me.xrLabel22.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "GetMaturityProfile.AMT_APPLIED", "{0:C2}")})
        Me.xrLabel22.LocationFloat = New DevExpress.Utils.PointFloat(560.3639!, 6.0!)
        Me.xrLabel22.Name = "xrLabel22"
        Me.xrLabel22.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel22.SizeF = New System.Drawing.SizeF(83.63611!, 18.0!)
        Me.xrLabel22.StyleName = "FieldCaption"
        xrSummary1.FormatString = "{0:C2}"
        xrSummary1.IgnoreNullValues = True
        xrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
        Me.xrLabel22.Summary = xrSummary1
        Me.xrLabel22.Text = "xrLabel22"
        '
        'xrLabel23
        '
        Me.xrLabel23.LocationFloat = New DevExpress.Utils.PointFloat(36.0!, 6.0!)
        Me.xrLabel23.Name = "xrLabel23"
        Me.xrLabel23.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel23.SizeF = New System.Drawing.SizeF(30.0!, 18.0!)
        Me.xrLabel23.StyleName = "FieldCaption"
        Me.xrLabel23.Text = "Sum"
        '
        'xrLabel24
        '
        Me.xrLabel24.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "GetMaturityProfile.AMT_APPLIED", "{0:C2}")})
        Me.xrLabel24.LocationFloat = New DevExpress.Utils.PointFloat(560.3639!, 30.0!)
        Me.xrLabel24.Name = "xrLabel24"
        Me.xrLabel24.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel24.SizeF = New System.Drawing.SizeF(83.63611!, 18.0!)
        Me.xrLabel24.StyleName = "FieldCaption"
        xrSummary2.FormatString = "{0:C2}"
        xrSummary2.Func = DevExpress.XtraReports.UI.SummaryFunc.Avg
        xrSummary2.IgnoreNullValues = True
        xrSummary2.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
        Me.xrLabel24.Summary = xrSummary2
        Me.xrLabel24.Text = "xrLabel24"
        '
        'xrLabel25
        '
        Me.xrLabel25.LocationFloat = New DevExpress.Utils.PointFloat(36.0!, 30.0!)
        Me.xrLabel25.Name = "xrLabel25"
        Me.xrLabel25.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel25.SizeF = New System.Drawing.SizeF(30.0!, 18.0!)
        Me.xrLabel25.StyleName = "FieldCaption"
        Me.xrLabel25.Text = "Avg"
        '
        'xrLabel26
        '
        Me.xrLabel26.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "GetMaturityProfile.AMT_APPLIED", "{0:C2}")})
        Me.xrLabel26.LocationFloat = New DevExpress.Utils.PointFloat(560.3639!, 54.0!)
        Me.xrLabel26.Name = "xrLabel26"
        Me.xrLabel26.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel26.SizeF = New System.Drawing.SizeF(83.63611!, 18.0!)
        Me.xrLabel26.StyleName = "FieldCaption"
        xrSummary3.FormatString = "{0:C2}"
        xrSummary3.Func = DevExpress.XtraReports.UI.SummaryFunc.Min
        xrSummary3.IgnoreNullValues = True
        xrSummary3.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
        Me.xrLabel26.Summary = xrSummary3
        Me.xrLabel26.Text = "xrLabel26"
        '
        'xrLabel27
        '
        Me.xrLabel27.LocationFloat = New DevExpress.Utils.PointFloat(36.0!, 54.0!)
        Me.xrLabel27.Name = "xrLabel27"
        Me.xrLabel27.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel27.SizeF = New System.Drawing.SizeF(30.0!, 18.0!)
        Me.xrLabel27.StyleName = "FieldCaption"
        Me.xrLabel27.Text = "Min"
        '
        'xrLabel28
        '
        Me.xrLabel28.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "GetMaturityProfile.AMT_APPLIED", "{0:C2}")})
        Me.xrLabel28.LocationFloat = New DevExpress.Utils.PointFloat(560.3639!, 78.0!)
        Me.xrLabel28.Name = "xrLabel28"
        Me.xrLabel28.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel28.SizeF = New System.Drawing.SizeF(83.63611!, 18.0!)
        Me.xrLabel28.StyleName = "FieldCaption"
        xrSummary4.FormatString = "{0:C2}"
        xrSummary4.Func = DevExpress.XtraReports.UI.SummaryFunc.Max
        xrSummary4.IgnoreNullValues = True
        xrSummary4.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
        Me.xrLabel28.Summary = xrSummary4
        Me.xrLabel28.Text = "xrLabel28"
        '
        'xrLabel29
        '
        Me.xrLabel29.LocationFloat = New DevExpress.Utils.PointFloat(36.0!, 78.0!)
        Me.xrLabel29.Name = "xrLabel29"
        Me.xrLabel29.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel29.SizeF = New System.Drawing.SizeF(30.0!, 18.0!)
        Me.xrLabel29.StyleName = "FieldCaption"
        Me.xrLabel29.Text = "Max"
        '
        'xrLabel30
        '
        Me.xrLabel30.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "GetMaturityProfile.AMT_APPLIED", "{0:C2}")})
        Me.xrLabel30.LocationFloat = New DevExpress.Utils.PointFloat(560.3639!, 102.0!)
        Me.xrLabel30.Name = "xrLabel30"
        Me.xrLabel30.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel30.SizeF = New System.Drawing.SizeF(83.63611!, 18.0!)
        Me.xrLabel30.StyleName = "FieldCaption"
        xrSummary5.FormatString = "{0:C2}"
        xrSummary5.Func = DevExpress.XtraReports.UI.SummaryFunc.Count
        xrSummary5.IgnoreNullValues = True
        xrSummary5.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
        Me.xrLabel30.Summary = xrSummary5
        Me.xrLabel30.Text = "xrLabel30"
        '
        'xrLabel31
        '
        Me.xrLabel31.LocationFloat = New DevExpress.Utils.PointFloat(36.0!, 102.0!)
        Me.xrLabel31.Name = "xrLabel31"
        Me.xrLabel31.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel31.SizeF = New System.Drawing.SizeF(30.0!, 18.0!)
        Me.xrLabel31.StyleName = "FieldCaption"
        Me.xrLabel31.Text = "Count"
        '
        'groupFooterBand3
        '
        Me.groupFooterBand3.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.xrLabel32, Me.xrLabel33, Me.xrLabel34, Me.xrLabel35, Me.xrLabel36, Me.xrLabel37, Me.xrLabel38, Me.xrLabel39, Me.xrLabel40, Me.xrLabel41})
        Me.groupFooterBand3.HeightF = 126.0!
        Me.groupFooterBand3.Level = 2
        Me.groupFooterBand3.Name = "groupFooterBand3"
        '
        'xrLabel32
        '
        Me.xrLabel32.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "GetMaturityProfile.AMT_APPLIED", "{0:C2}")})
        Me.xrLabel32.LocationFloat = New DevExpress.Utils.PointFloat(560.3639!, 6.0!)
        Me.xrLabel32.Name = "xrLabel32"
        Me.xrLabel32.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel32.SizeF = New System.Drawing.SizeF(83.63611!, 18.0!)
        Me.xrLabel32.StyleName = "FieldCaption"
        xrSummary6.FormatString = "{0:C2}"
        xrSummary6.IgnoreNullValues = True
        xrSummary6.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
        Me.xrLabel32.Summary = xrSummary6
        Me.xrLabel32.Text = "xrLabel32"
        '
        'xrLabel33
        '
        Me.xrLabel33.LocationFloat = New DevExpress.Utils.PointFloat(6.0!, 6.0!)
        Me.xrLabel33.Name = "xrLabel33"
        Me.xrLabel33.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel33.SizeF = New System.Drawing.SizeF(60.0!, 18.0!)
        Me.xrLabel33.StyleName = "FieldCaption"
        Me.xrLabel33.Text = "Sum"
        '
        'xrLabel34
        '
        Me.xrLabel34.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "GetMaturityProfile.AMT_APPLIED", "{0:C2}")})
        Me.xrLabel34.LocationFloat = New DevExpress.Utils.PointFloat(560.3639!, 30.0!)
        Me.xrLabel34.Name = "xrLabel34"
        Me.xrLabel34.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel34.SizeF = New System.Drawing.SizeF(83.63611!, 18.0!)
        Me.xrLabel34.StyleName = "FieldCaption"
        xrSummary7.FormatString = "{0:C2}"
        xrSummary7.Func = DevExpress.XtraReports.UI.SummaryFunc.Avg
        xrSummary7.IgnoreNullValues = True
        xrSummary7.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
        Me.xrLabel34.Summary = xrSummary7
        Me.xrLabel34.Text = "xrLabel34"
        '
        'xrLabel35
        '
        Me.xrLabel35.LocationFloat = New DevExpress.Utils.PointFloat(6.0!, 30.0!)
        Me.xrLabel35.Name = "xrLabel35"
        Me.xrLabel35.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel35.SizeF = New System.Drawing.SizeF(60.0!, 18.0!)
        Me.xrLabel35.StyleName = "FieldCaption"
        Me.xrLabel35.Text = "Avg"
        '
        'xrLabel36
        '
        Me.xrLabel36.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "GetMaturityProfile.AMT_APPLIED", "{0:C2}")})
        Me.xrLabel36.LocationFloat = New DevExpress.Utils.PointFloat(560.3639!, 54.0!)
        Me.xrLabel36.Name = "xrLabel36"
        Me.xrLabel36.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel36.SizeF = New System.Drawing.SizeF(83.63611!, 18.0!)
        Me.xrLabel36.StyleName = "FieldCaption"
        xrSummary8.FormatString = "{0:C2}"
        xrSummary8.Func = DevExpress.XtraReports.UI.SummaryFunc.Min
        xrSummary8.IgnoreNullValues = True
        xrSummary8.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
        Me.xrLabel36.Summary = xrSummary8
        Me.xrLabel36.Text = "xrLabel36"
        '
        'xrLabel37
        '
        Me.xrLabel37.LocationFloat = New DevExpress.Utils.PointFloat(6.0!, 54.0!)
        Me.xrLabel37.Name = "xrLabel37"
        Me.xrLabel37.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel37.SizeF = New System.Drawing.SizeF(60.0!, 18.0!)
        Me.xrLabel37.StyleName = "FieldCaption"
        Me.xrLabel37.Text = "Min"
        '
        'xrLabel38
        '
        Me.xrLabel38.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "GetMaturityProfile.AMT_APPLIED", "{0:C2}")})
        Me.xrLabel38.LocationFloat = New DevExpress.Utils.PointFloat(560.3639!, 78.0!)
        Me.xrLabel38.Name = "xrLabel38"
        Me.xrLabel38.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel38.SizeF = New System.Drawing.SizeF(83.63611!, 18.0!)
        Me.xrLabel38.StyleName = "FieldCaption"
        xrSummary9.FormatString = "{0:C2}"
        xrSummary9.Func = DevExpress.XtraReports.UI.SummaryFunc.Max
        xrSummary9.IgnoreNullValues = True
        xrSummary9.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
        Me.xrLabel38.Summary = xrSummary9
        Me.xrLabel38.Text = "xrLabel38"
        '
        'xrLabel39
        '
        Me.xrLabel39.LocationFloat = New DevExpress.Utils.PointFloat(6.0!, 78.0!)
        Me.xrLabel39.Name = "xrLabel39"
        Me.xrLabel39.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel39.SizeF = New System.Drawing.SizeF(60.0!, 18.0!)
        Me.xrLabel39.StyleName = "FieldCaption"
        Me.xrLabel39.Text = "Max"
        '
        'xrLabel40
        '
        Me.xrLabel40.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "GetMaturityProfile.AMT_APPLIED", "{0:C2}")})
        Me.xrLabel40.LocationFloat = New DevExpress.Utils.PointFloat(560.3639!, 102.0!)
        Me.xrLabel40.Name = "xrLabel40"
        Me.xrLabel40.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel40.SizeF = New System.Drawing.SizeF(83.63611!, 18.0!)
        Me.xrLabel40.StyleName = "FieldCaption"
        xrSummary10.FormatString = "{0:C2}"
        xrSummary10.Func = DevExpress.XtraReports.UI.SummaryFunc.Count
        xrSummary10.IgnoreNullValues = True
        xrSummary10.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
        Me.xrLabel40.Summary = xrSummary10
        Me.xrLabel40.Text = "xrLabel40"
        '
        'xrLabel41
        '
        Me.xrLabel41.LocationFloat = New DevExpress.Utils.PointFloat(6.0!, 102.0!)
        Me.xrLabel41.Name = "xrLabel41"
        Me.xrLabel41.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel41.SizeF = New System.Drawing.SizeF(60.0!, 18.0!)
        Me.xrLabel41.StyleName = "FieldCaption"
        Me.xrLabel41.Text = "Count"
        '
        'reportFooterBand1
        '
        Me.reportFooterBand1.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.xrLabel42, Me.xrLabel43})
        Me.reportFooterBand1.HeightF = 30.0!
        Me.reportFooterBand1.Name = "reportFooterBand1"
        '
        'xrLabel42
        '
        Me.xrLabel42.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "GetMaturityProfile.AMT_APPLIED", "{0:C2}")})
        Me.xrLabel42.LocationFloat = New DevExpress.Utils.PointFloat(560.3639!, 6.0!)
        Me.xrLabel42.Name = "xrLabel42"
        Me.xrLabel42.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel42.SizeF = New System.Drawing.SizeF(83.63611!, 18.0!)
        Me.xrLabel42.StyleName = "FieldCaption"
        xrSummary11.FormatString = "{0:C2}"
        xrSummary11.IgnoreNullValues = True
        xrSummary11.Running = DevExpress.XtraReports.UI.SummaryRunning.Report
        Me.xrLabel42.Summary = xrSummary11
        Me.xrLabel42.Text = "xrLabel42"
        '
        'xrLabel43
        '
        Me.xrLabel43.LocationFloat = New DevExpress.Utils.PointFloat(6.0!, 6.0!)
        Me.xrLabel43.Name = "xrLabel43"
        Me.xrLabel43.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel43.SizeF = New System.Drawing.SizeF(60.0!, 18.0!)
        Me.xrLabel43.StyleName = "FieldCaption"
        Me.xrLabel43.Text = "Grand Total"
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
        'Maturity
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.groupHeaderBand1, Me.groupHeaderBand2, Me.groupHeaderBand3, Me.pageFooterBand1, Me.reportHeaderBand1, Me.groupFooterBand2, Me.groupFooterBand3, Me.reportFooterBand1, Me.topMarginBand1, Me.bottomMarginBand1})
        Me.DataAdapter = Me.getMaturityProfileTableAdapter1
        Me.DataMember = "GetMaturityProfile"
        Me.DataSource = Me.dsMaturity2
        Me.StyleSheet.AddRange(New DevExpress.XtraReports.UI.XRControlStyle() {Me.Title, Me.FieldCaption, Me.PageInfo, Me.DataField})
        Me.Version = "13.2"
        CType(Me.dsMaturity1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dsMaturity2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand

#End Region

End Class