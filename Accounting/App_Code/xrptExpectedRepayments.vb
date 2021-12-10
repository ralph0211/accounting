Public Class xrptExpectedRepayments
    Inherits DevExpress.XtraReports.UI.XtraReport

#Region " Designer generated code "

    Private WithEvents xrLabel14 As DevExpress.XtraReports.UI.XRLabel

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
    Private WithEvents dsAllReports1 As dsAllReports
    Private WithEvents expectedRepaymentsTableAdapter1 As dsAllReportsTableAdapters.ExpectedRepaymentsTableAdapter
    Private WithEvents groupHeaderBand1 As DevExpress.XtraReports.UI.GroupHeaderBand
    Private WithEvents xrLabel2 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents groupHeaderBand2 As DevExpress.XtraReports.UI.GroupHeaderBand
    Private WithEvents xrLabel6 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel7 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel8 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel9 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel10 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel11 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel12 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel13 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLine1 As DevExpress.XtraReports.UI.XRLine
    Private WithEvents xrLine2 As DevExpress.XtraReports.UI.XRLine
    Private WithEvents pageFooterBand1 As DevExpress.XtraReports.UI.PageFooterBand
    Private WithEvents xrPageInfo1 As DevExpress.XtraReports.UI.XRPageInfo
    Private WithEvents xrPageInfo2 As DevExpress.XtraReports.UI.XRPageInfo
    Private WithEvents reportHeaderBand1 As DevExpress.XtraReports.UI.ReportHeaderBand
    Private WithEvents xrLabel25 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents groupFooterBand1 As DevExpress.XtraReports.UI.GroupFooterBand
    Private WithEvents groupFooterBand2 As DevExpress.XtraReports.UI.GroupFooterBand
    Private WithEvents xrLabel27 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel28 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel29 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel30 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel31 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel32 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel33 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel34 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel35 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel36 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel37 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel38 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents reportFooterBand1 As DevExpress.XtraReports.UI.ReportFooterBand
    Private WithEvents xrLabel40 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel41 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel42 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel43 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel44 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel45 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents Title As DevExpress.XtraReports.UI.XRControlStyle
    Private WithEvents FieldCaption As DevExpress.XtraReports.UI.XRControlStyle
    Private WithEvents PageInfo As DevExpress.XtraReports.UI.XRControlStyle
    Private WithEvents DataField As DevExpress.XtraReports.UI.XRControlStyle
    Private WithEvents topMarginBand1 As DevExpress.XtraReports.UI.TopMarginBand
    Private WithEvents bottomMarginBand1 As DevExpress.XtraReports.UI.BottomMarginBand
    Private WithEvents fromDate As DevExpress.XtraReports.Parameters.Parameter
    Private WithEvents toDate As DevExpress.XtraReports.Parameters.Parameter
    Private WithEvents xrLine4 As DevExpress.XtraReports.UI.XRLine
    Private WithEvents xrLine5 As DevExpress.XtraReports.UI.XRLine
    Private WithEvents xrLine3 As DevExpress.XtraReports.UI.XRLine
    Private WithEvents xrLabel1 As DevExpress.XtraReports.UI.XRLabel

    'Required by the Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Designer
    'It can be modified using the Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resourceFileName As String = "xrptExpectedRepayments.resx"
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
        Dim xrSummary12 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
        Dim xrSummary13 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
        Dim xrSummary14 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
        Dim xrSummary15 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
        Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
        Me.xrLabel17 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel18 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel19 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel20 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel21 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel22 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel23 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel24 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel14 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel15 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel16 = New DevExpress.XtraReports.UI.XRLabel()
        Me.dsAllReports1 = New dsAllReports()
        Me.expectedRepaymentsTableAdapter1 = New dsAllReportsTableAdapters.ExpectedRepaymentsTableAdapter()
        Me.groupHeaderBand1 = New DevExpress.XtraReports.UI.GroupHeaderBand()
        Me.xrLine4 = New DevExpress.XtraReports.UI.XRLine()
        Me.xrLabel2 = New DevExpress.XtraReports.UI.XRLabel()
        Me.groupHeaderBand2 = New DevExpress.XtraReports.UI.GroupHeaderBand()
        Me.xrLabel6 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel7 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel8 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel9 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel10 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel11 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel12 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel13 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLine1 = New DevExpress.XtraReports.UI.XRLine()
        Me.xrLine2 = New DevExpress.XtraReports.UI.XRLine()
        Me.pageFooterBand1 = New DevExpress.XtraReports.UI.PageFooterBand()
        Me.xrPageInfo1 = New DevExpress.XtraReports.UI.XRPageInfo()
        Me.xrPageInfo2 = New DevExpress.XtraReports.UI.XRPageInfo()
        Me.reportHeaderBand1 = New DevExpress.XtraReports.UI.ReportHeaderBand()
        Me.xrLabel25 = New DevExpress.XtraReports.UI.XRLabel()
        Me.groupFooterBand1 = New DevExpress.XtraReports.UI.GroupFooterBand()
        Me.groupFooterBand2 = New DevExpress.XtraReports.UI.GroupFooterBand()
        Me.xrLine5 = New DevExpress.XtraReports.UI.XRLine()
        Me.xrLine3 = New DevExpress.XtraReports.UI.XRLine()
        Me.xrLabel27 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel28 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel29 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel30 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel31 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel32 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel33 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel34 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel35 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel36 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel37 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel38 = New DevExpress.XtraReports.UI.XRLabel()
        Me.reportFooterBand1 = New DevExpress.XtraReports.UI.ReportFooterBand()
        Me.xrLabel40 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel41 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel42 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel43 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel44 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel45 = New DevExpress.XtraReports.UI.XRLabel()
        Me.Title = New DevExpress.XtraReports.UI.XRControlStyle()
        Me.FieldCaption = New DevExpress.XtraReports.UI.XRControlStyle()
        Me.PageInfo = New DevExpress.XtraReports.UI.XRControlStyle()
        Me.DataField = New DevExpress.XtraReports.UI.XRControlStyle()
        Me.topMarginBand1 = New DevExpress.XtraReports.UI.TopMarginBand()
        Me.bottomMarginBand1 = New DevExpress.XtraReports.UI.BottomMarginBand()
        Me.fromDate = New DevExpress.XtraReports.Parameters.Parameter()
        Me.toDate = New DevExpress.XtraReports.Parameters.Parameter()
        Me.xrLabel1 = New DevExpress.XtraReports.UI.XRLabel()
        CType(Me.dsAllReports1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.xrLabel17, Me.xrLabel18, Me.xrLabel19, Me.xrLabel20, Me.xrLabel21, Me.xrLabel22, Me.xrLabel23, Me.xrLabel24})
        Me.Detail.HeightF = 25.91667!
        Me.Detail.Name = "Detail"
        Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.Detail.StyleName = "DataField"
        Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'xrLabel17
        '
        Me.xrLabel17.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ExpectedRepayments.FIN_AMT", "{0:n2}")})
        Me.xrLabel17.LocationFloat = New DevExpress.Utils.PointFloat(199.4905!, 0.0!)
        Me.xrLabel17.Name = "xrLabel17"
        Me.xrLabel17.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel17.SizeF = New System.Drawing.SizeF(126.8106!, 18.0!)
        Me.xrLabel17.StylePriority.UseTextAlignment = False
        Me.xrLabel17.Text = "xrLabel17"
        Me.xrLabel17.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'xrLabel18
        '
        Me.xrLabel18.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ExpectedRepayments.FIN_TENOR", "{0:#,#}")})
        Me.xrLabel18.LocationFloat = New DevExpress.Utils.PointFloat(116.56!, 0.0!)
        Me.xrLabel18.Name = "xrLabel18"
        Me.xrLabel18.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel18.SizeF = New System.Drawing.SizeF(82.93048!, 18.0!)
        Me.xrLabel18.Text = "xrLabel18"
        '
        'xrLabel19
        '
        Me.xrLabel19.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ExpectedRepayments.PAYMENT_DATE", "{0:dd MMM,yyyy}")})
        Me.xrLabel19.LocationFloat = New DevExpress.Utils.PointFloat(10.00001!, 0.0!)
        Me.xrLabel19.Name = "xrLabel19"
        Me.xrLabel19.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel19.SizeF = New System.Drawing.SizeF(106.56!, 18.0!)
        Me.xrLabel19.Text = "xrLabel19"
        '
        'xrLabel20
        '
        Me.xrLabel20.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ExpectedRepayments.PRINCIPAL", "{0:n2}")})
        Me.xrLabel20.LocationFloat = New DevExpress.Utils.PointFloat(436.9137!, 0.0!)
        Me.xrLabel20.Name = "xrLabel20"
        Me.xrLabel20.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel20.SizeF = New System.Drawing.SizeF(116.1451!, 18.0!)
        Me.xrLabel20.StylePriority.UseTextAlignment = False
        Me.xrLabel20.Text = "xrLabel20"
        Me.xrLabel20.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'xrLabel21
        '
        Me.xrLabel21.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ExpectedRepayments.INTEREST", "{0:n2}")})
        Me.xrLabel21.LocationFloat = New DevExpress.Utils.PointFloat(553.0588!, 0.0!)
        Me.xrLabel21.Name = "xrLabel21"
        Me.xrLabel21.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel21.SizeF = New System.Drawing.SizeF(93.23578!, 18.0!)
        Me.xrLabel21.StylePriority.UseTextAlignment = False
        Me.xrLabel21.Text = "xrLabel21"
        Me.xrLabel21.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'xrLabel22
        '
        Me.xrLabel22.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ExpectedRepayments.ADMIN_CHARGE", "{0:n2}")})
        Me.xrLabel22.LocationFloat = New DevExpress.Utils.PointFloat(646.2947!, 0.0!)
        Me.xrLabel22.Name = "xrLabel22"
        Me.xrLabel22.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel22.SizeF = New System.Drawing.SizeF(106.56!, 18.0!)
        Me.xrLabel22.StylePriority.UseTextAlignment = False
        Me.xrLabel22.Text = "xrLabel22"
        Me.xrLabel22.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'xrLabel23
        '
        Me.xrLabel23.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ExpectedRepayments.PAYMENT", "{0:n2}")})
        Me.xrLabel23.LocationFloat = New DevExpress.Utils.PointFloat(326.3011!, 0.0!)
        Me.xrLabel23.Name = "xrLabel23"
        Me.xrLabel23.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel23.SizeF = New System.Drawing.SizeF(110.6126!, 18.0!)
        Me.xrLabel23.StylePriority.UseTextAlignment = False
        Me.xrLabel23.Text = "xrLabel23"
        Me.xrLabel23.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'xrLabel24
        '
        Me.xrLabel24.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ExpectedRepayments.PRINCIPAL_BALANCE", "{0:n2}")})
        Me.xrLabel24.LocationFloat = New DevExpress.Utils.PointFloat(752.8547!, 0.0!)
        Me.xrLabel24.Name = "xrLabel24"
        Me.xrLabel24.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel24.SizeF = New System.Drawing.SizeF(141.1453!, 18.0!)
        Me.xrLabel24.StylePriority.UseTextAlignment = False
        Me.xrLabel24.Text = "xrLabel24"
        Me.xrLabel24.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'xrLabel14
        '
        Me.xrLabel14.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ExpectedRepayments.SURNAME")})
        Me.xrLabel14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.xrLabel14.LocationFloat = New DevExpress.Utils.PointFloat(199.4905!, 23.41665!)
        Me.xrLabel14.Name = "xrLabel14"
        Me.xrLabel14.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel14.SizeF = New System.Drawing.SizeF(167.479!, 18.0!)
        Me.xrLabel14.StylePriority.UseFont = False
        Me.xrLabel14.Text = "xrLabel14"
        '
        'xrLabel15
        '
        Me.xrLabel15.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ExpectedRepayments.FORENAMES")})
        Me.xrLabel15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.xrLabel15.LocationFloat = New DevExpress.Utils.PointFloat(366.9695!, 23.41665!)
        Me.xrLabel15.Name = "xrLabel15"
        Me.xrLabel15.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel15.SizeF = New System.Drawing.SizeF(224.4305!, 18.0!)
        Me.xrLabel15.StylePriority.UseFont = False
        Me.xrLabel15.Text = "xrLabel15"
        '
        'xrLabel16
        '
        Me.xrLabel16.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ExpectedRepayments.IDNO")})
        Me.xrLabel16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.xrLabel16.LocationFloat = New DevExpress.Utils.PointFloat(591.4!, 23.41665!)
        Me.xrLabel16.Name = "xrLabel16"
        Me.xrLabel16.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel16.SizeF = New System.Drawing.SizeF(161.4548!, 18.0!)
        Me.xrLabel16.StylePriority.UseFont = False
        Me.xrLabel16.Text = "xrLabel16"
        '
        'dsAllReports1
        '
        Me.dsAllReports1.DataSetName = "dsAllReports"
        Me.dsAllReports1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'expectedRepaymentsTableAdapter1
        '
        Me.expectedRepaymentsTableAdapter1.ClearBeforeFill = True
        '
        'groupHeaderBand1
        '
        Me.groupHeaderBand1.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.xrLine4, Me.xrLabel2, Me.xrLabel14, Me.xrLabel15, Me.xrLabel16})
        Me.groupHeaderBand1.GroupFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("CUSTOMER_NUMBER", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
        Me.groupHeaderBand1.HeightF = 51.41665!
        Me.groupHeaderBand1.Level = 1
        Me.groupHeaderBand1.Name = "groupHeaderBand1"
        '
        'xrLine4
        '
        Me.xrLine4.LineWidth = 2
        Me.xrLine4.LocationFloat = New DevExpress.Utils.PointFloat(50.49054!, 41.41665!)
        Me.xrLine4.Name = "xrLine4"
        Me.xrLine4.SizeF = New System.Drawing.SizeF(764.0928!, 5.000002!)
        '
        'xrLabel2
        '
        Me.xrLabel2.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ExpectedRepayments.CUSTOMER_NUMBER")})
        Me.xrLabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.xrLabel2.LocationFloat = New DevExpress.Utils.PointFloat(50.49054!, 23.41665!)
        Me.xrLabel2.Name = "xrLabel2"
        Me.xrLabel2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel2.SizeF = New System.Drawing.SizeF(148.9999!, 18.0!)
        Me.xrLabel2.StyleName = "DataField"
        Me.xrLabel2.StylePriority.UseFont = False
        Me.xrLabel2.Text = "xrLabel2"
        '
        'groupHeaderBand2
        '
        Me.groupHeaderBand2.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.xrLabel6, Me.xrLabel7, Me.xrLabel8, Me.xrLabel9, Me.xrLabel10, Me.xrLabel11, Me.xrLabel12, Me.xrLabel13, Me.xrLine1, Me.xrLine2})
        Me.groupHeaderBand2.HeightF = 27.0!
        Me.groupHeaderBand2.Name = "groupHeaderBand2"
        Me.groupHeaderBand2.StyleName = "FieldCaption"
        '
        'xrLabel6
        '
        Me.xrLabel6.LocationFloat = New DevExpress.Utils.PointFloat(199.4905!, 7.000001!)
        Me.xrLabel6.Name = "xrLabel6"
        Me.xrLabel6.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel6.SizeF = New System.Drawing.SizeF(126.8106!, 18.0!)
        Me.xrLabel6.StylePriority.UseTextAlignment = False
        Me.xrLabel6.Text = "Disbursed Amount"
        Me.xrLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'xrLabel7
        '
        Me.xrLabel7.LocationFloat = New DevExpress.Utils.PointFloat(116.56!, 7.000001!)
        Me.xrLabel7.Name = "xrLabel7"
        Me.xrLabel7.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel7.SizeF = New System.Drawing.SizeF(82.9305!, 18.0!)
        Me.xrLabel7.Text = "Loan Tenure"
        '
        'xrLabel8
        '
        Me.xrLabel8.LocationFloat = New DevExpress.Utils.PointFloat(10.00001!, 7.000001!)
        Me.xrLabel8.Name = "xrLabel8"
        Me.xrLabel8.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel8.SizeF = New System.Drawing.SizeF(106.56!, 18.0!)
        Me.xrLabel8.Text = "Payment Date"
        '
        'xrLabel9
        '
        Me.xrLabel9.LocationFloat = New DevExpress.Utils.PointFloat(436.9137!, 7.000001!)
        Me.xrLabel9.Name = "xrLabel9"
        Me.xrLabel9.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel9.SizeF = New System.Drawing.SizeF(116.1451!, 18.0!)
        Me.xrLabel9.StylePriority.UseTextAlignment = False
        Me.xrLabel9.Text = "Principal"
        Me.xrLabel9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'xrLabel10
        '
        Me.xrLabel10.LocationFloat = New DevExpress.Utils.PointFloat(553.0588!, 7.000001!)
        Me.xrLabel10.Name = "xrLabel10"
        Me.xrLabel10.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel10.SizeF = New System.Drawing.SizeF(93.23578!, 18.0!)
        Me.xrLabel10.StylePriority.UseTextAlignment = False
        Me.xrLabel10.Text = "Interest"
        Me.xrLabel10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'xrLabel11
        '
        Me.xrLabel11.LocationFloat = New DevExpress.Utils.PointFloat(646.2947!, 7.0!)
        Me.xrLabel11.Name = "xrLabel11"
        Me.xrLabel11.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel11.SizeF = New System.Drawing.SizeF(106.56!, 18.0!)
        Me.xrLabel11.StylePriority.UseTextAlignment = False
        Me.xrLabel11.Text = "Admin Charge"
        Me.xrLabel11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'xrLabel12
        '
        Me.xrLabel12.LocationFloat = New DevExpress.Utils.PointFloat(326.3011!, 7.000001!)
        Me.xrLabel12.Name = "xrLabel12"
        Me.xrLabel12.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel12.SizeF = New System.Drawing.SizeF(110.6126!, 18.0!)
        Me.xrLabel12.StylePriority.UseTextAlignment = False
        Me.xrLabel12.Text = "Instalment"
        Me.xrLabel12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'xrLabel13
        '
        Me.xrLabel13.LocationFloat = New DevExpress.Utils.PointFloat(752.8547!, 7.0!)
        Me.xrLabel13.Name = "xrLabel13"
        Me.xrLabel13.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel13.SizeF = New System.Drawing.SizeF(141.1453!, 18.0!)
        Me.xrLabel13.StylePriority.UseTextAlignment = False
        Me.xrLabel13.Text = "Principal Balance"
        Me.xrLabel13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'xrLine1
        '
        Me.xrLine1.LocationFloat = New DevExpress.Utils.PointFloat(6.0!, 5.0!)
        Me.xrLine1.Name = "xrLine1"
        Me.xrLine1.SizeF = New System.Drawing.SizeF(888.0!, 2.0!)
        '
        'xrLine2
        '
        Me.xrLine2.LocationFloat = New DevExpress.Utils.PointFloat(6.0!, 25.0!)
        Me.xrLine2.Name = "xrLine2"
        Me.xrLine2.SizeF = New System.Drawing.SizeF(888.0!, 2.0!)
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
        Me.xrPageInfo1.SizeF = New System.Drawing.SizeF(438.0!, 23.0!)
        Me.xrPageInfo1.StyleName = "PageInfo"
        '
        'xrPageInfo2
        '
        Me.xrPageInfo2.Format = "Page {0} of {1}"
        Me.xrPageInfo2.LocationFloat = New DevExpress.Utils.PointFloat(456.0!, 6.0!)
        Me.xrPageInfo2.Name = "xrPageInfo2"
        Me.xrPageInfo2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrPageInfo2.SizeF = New System.Drawing.SizeF(438.0!, 23.0!)
        Me.xrPageInfo2.StyleName = "PageInfo"
        Me.xrPageInfo2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'reportHeaderBand1
        '
        Me.reportHeaderBand1.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.xrLabel1, Me.xrLabel25})
        Me.reportHeaderBand1.HeightF = 78.08334!
        Me.reportHeaderBand1.Name = "reportHeaderBand1"
        '
        'xrLabel25
        '
        Me.xrLabel25.LocationFloat = New DevExpress.Utils.PointFloat(6.0!, 6.0!)
        Me.xrLabel25.Name = "xrLabel25"
        Me.xrLabel25.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel25.SizeF = New System.Drawing.SizeF(888.0!, 33.0!)
        Me.xrLabel25.StyleName = "Title"
        Me.xrLabel25.Text = "Expected Repayments Report"
        '
        'groupFooterBand1
        '
        Me.groupFooterBand1.HeightF = 1.0!
        Me.groupFooterBand1.Name = "groupFooterBand1"
        '
        'groupFooterBand2
        '
        Me.groupFooterBand2.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.xrLine5, Me.xrLine3, Me.xrLabel27, Me.xrLabel28, Me.xrLabel29, Me.xrLabel30, Me.xrLabel31, Me.xrLabel32, Me.xrLabel33, Me.xrLabel34, Me.xrLabel35, Me.xrLabel36, Me.xrLabel37, Me.xrLabel38})
        Me.groupFooterBand2.HeightF = 59.2083!
        Me.groupFooterBand2.Level = 1
        Me.groupFooterBand2.Name = "groupFooterBand2"
        '
        'xrLine5
        '
        Me.xrLine5.ForeColor = System.Drawing.Color.Maroon
        Me.xrLine5.LocationFloat = New DevExpress.Utils.PointFloat(5.999994!, 53.20829!)
        Me.xrLine5.Name = "xrLine5"
        Me.xrLine5.SizeF = New System.Drawing.SizeF(888.0!, 6.0!)
        '
        'xrLine3
        '
        Me.xrLine3.ForeColor = System.Drawing.Color.Maroon
        Me.xrLine3.LocationFloat = New DevExpress.Utils.PointFloat(6.00001!, 0.0!)
        Me.xrLine3.Name = "xrLine3"
        Me.xrLine3.SizeF = New System.Drawing.SizeF(888.0!, 6.0!)
        '
        'xrLabel27
        '
        Me.xrLabel27.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ExpectedRepayments.PRINCIPAL", "{0:C2}")})
        Me.xrLabel27.LocationFloat = New DevExpress.Utils.PointFloat(436.9137!, 6.00001!)
        Me.xrLabel27.Name = "xrLabel27"
        Me.xrLabel27.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel27.SizeF = New System.Drawing.SizeF(116.1451!, 18.0!)
        Me.xrLabel27.StyleName = "FieldCaption"
        Me.xrLabel27.StylePriority.UseTextAlignment = False
        xrSummary1.FormatString = "{0:n2}"
        xrSummary1.IgnoreNullValues = True
        xrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
        Me.xrLabel27.Summary = xrSummary1
        Me.xrLabel27.Text = "xrLabel27"
        Me.xrLabel27.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'xrLabel28
        '
        Me.xrLabel28.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ExpectedRepayments.INTEREST", "{0:C2}")})
        Me.xrLabel28.LocationFloat = New DevExpress.Utils.PointFloat(553.0588!, 6.00001!)
        Me.xrLabel28.Name = "xrLabel28"
        Me.xrLabel28.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel28.SizeF = New System.Drawing.SizeF(93.23578!, 18.0!)
        Me.xrLabel28.StyleName = "FieldCaption"
        Me.xrLabel28.StylePriority.UseTextAlignment = False
        xrSummary2.FormatString = "{0:n2}"
        xrSummary2.IgnoreNullValues = True
        xrSummary2.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
        Me.xrLabel28.Summary = xrSummary2
        Me.xrLabel28.Text = "xrLabel28"
        Me.xrLabel28.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'xrLabel29
        '
        Me.xrLabel29.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ExpectedRepayments.ADMIN_CHARGE", "{0:C2}")})
        Me.xrLabel29.LocationFloat = New DevExpress.Utils.PointFloat(646.2947!, 6.0!)
        Me.xrLabel29.Name = "xrLabel29"
        Me.xrLabel29.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel29.SizeF = New System.Drawing.SizeF(106.56!, 18.0!)
        Me.xrLabel29.StyleName = "FieldCaption"
        Me.xrLabel29.StylePriority.UseTextAlignment = False
        xrSummary3.FormatString = "{0:n2}"
        xrSummary3.IgnoreNullValues = True
        xrSummary3.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
        Me.xrLabel29.Summary = xrSummary3
        Me.xrLabel29.Text = "xrLabel29"
        Me.xrLabel29.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'xrLabel30
        '
        Me.xrLabel30.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ExpectedRepayments.PAYMENT", "{0:C2}")})
        Me.xrLabel30.LocationFloat = New DevExpress.Utils.PointFloat(326.3011!, 6.00001!)
        Me.xrLabel30.Name = "xrLabel30"
        Me.xrLabel30.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel30.SizeF = New System.Drawing.SizeF(110.6126!, 18.0!)
        Me.xrLabel30.StyleName = "FieldCaption"
        Me.xrLabel30.StylePriority.UseTextAlignment = False
        xrSummary4.FormatString = "{0:n2}"
        xrSummary4.IgnoreNullValues = True
        xrSummary4.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
        Me.xrLabel30.Summary = xrSummary4
        Me.xrLabel30.Text = "xrLabel30"
        Me.xrLabel30.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'xrLabel31
        '
        Me.xrLabel31.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ExpectedRepayments.PRINCIPAL_BALANCE", "{0:C2}")})
        Me.xrLabel31.LocationFloat = New DevExpress.Utils.PointFloat(752.8547!, 6.0!)
        Me.xrLabel31.Name = "xrLabel31"
        Me.xrLabel31.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel31.SizeF = New System.Drawing.SizeF(141.1453!, 18.0!)
        Me.xrLabel31.StyleName = "FieldCaption"
        Me.xrLabel31.StylePriority.UseTextAlignment = False
        xrSummary5.FormatString = "{0:n2}"
        xrSummary5.IgnoreNullValues = True
        xrSummary5.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
        Me.xrLabel31.Summary = xrSummary5
        Me.xrLabel31.Text = "xrLabel31"
        Me.xrLabel31.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'xrLabel32
        '
        Me.xrLabel32.LocationFloat = New DevExpress.Utils.PointFloat(6.0!, 6.0!)
        Me.xrLabel32.Name = "xrLabel32"
        Me.xrLabel32.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel32.SizeF = New System.Drawing.SizeF(35.0!, 18.0!)
        Me.xrLabel32.StyleName = "FieldCaption"
        Me.xrLabel32.Text = "Sum"
        '
        'xrLabel33
        '
        Me.xrLabel33.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ExpectedRepayments.PRINCIPAL", "{0:C2}")})
        Me.xrLabel33.LocationFloat = New DevExpress.Utils.PointFloat(436.9137!, 29.99999!)
        Me.xrLabel33.Name = "xrLabel33"
        Me.xrLabel33.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel33.SizeF = New System.Drawing.SizeF(116.1451!, 18.0!)
        Me.xrLabel33.StyleName = "FieldCaption"
        Me.xrLabel33.StylePriority.UseTextAlignment = False
        xrSummary6.FormatString = "{0:n2}"
        xrSummary6.Func = DevExpress.XtraReports.UI.SummaryFunc.Avg
        xrSummary6.IgnoreNullValues = True
        xrSummary6.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
        Me.xrLabel33.Summary = xrSummary6
        Me.xrLabel33.Text = "xrLabel33"
        Me.xrLabel33.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'xrLabel34
        '
        Me.xrLabel34.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ExpectedRepayments.INTEREST", "{0:C2}")})
        Me.xrLabel34.LocationFloat = New DevExpress.Utils.PointFloat(553.0588!, 29.99999!)
        Me.xrLabel34.Name = "xrLabel34"
        Me.xrLabel34.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel34.SizeF = New System.Drawing.SizeF(93.23578!, 18.0!)
        Me.xrLabel34.StyleName = "FieldCaption"
        Me.xrLabel34.StylePriority.UseTextAlignment = False
        xrSummary7.FormatString = "{0:n2}"
        xrSummary7.Func = DevExpress.XtraReports.UI.SummaryFunc.Avg
        xrSummary7.IgnoreNullValues = True
        xrSummary7.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
        Me.xrLabel34.Summary = xrSummary7
        Me.xrLabel34.Text = "xrLabel34"
        Me.xrLabel34.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'xrLabel35
        '
        Me.xrLabel35.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ExpectedRepayments.ADMIN_CHARGE", "{0:C2}")})
        Me.xrLabel35.LocationFloat = New DevExpress.Utils.PointFloat(646.2947!, 30.0!)
        Me.xrLabel35.Name = "xrLabel35"
        Me.xrLabel35.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel35.SizeF = New System.Drawing.SizeF(106.56!, 18.0!)
        Me.xrLabel35.StyleName = "FieldCaption"
        Me.xrLabel35.StylePriority.UseTextAlignment = False
        xrSummary8.FormatString = "{0:n2}"
        xrSummary8.Func = DevExpress.XtraReports.UI.SummaryFunc.Avg
        xrSummary8.IgnoreNullValues = True
        xrSummary8.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
        Me.xrLabel35.Summary = xrSummary8
        Me.xrLabel35.Text = "xrLabel35"
        Me.xrLabel35.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'xrLabel36
        '
        Me.xrLabel36.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ExpectedRepayments.PAYMENT", "{0:C2}")})
        Me.xrLabel36.LocationFloat = New DevExpress.Utils.PointFloat(326.3011!, 29.99999!)
        Me.xrLabel36.Name = "xrLabel36"
        Me.xrLabel36.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel36.SizeF = New System.Drawing.SizeF(110.6126!, 18.0!)
        Me.xrLabel36.StyleName = "FieldCaption"
        Me.xrLabel36.StylePriority.UseTextAlignment = False
        xrSummary9.FormatString = "{0:n2}"
        xrSummary9.Func = DevExpress.XtraReports.UI.SummaryFunc.Avg
        xrSummary9.IgnoreNullValues = True
        xrSummary9.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
        Me.xrLabel36.Summary = xrSummary9
        Me.xrLabel36.Text = "xrLabel36"
        Me.xrLabel36.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'xrLabel37
        '
        Me.xrLabel37.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ExpectedRepayments.PRINCIPAL_BALANCE", "{0:C2}")})
        Me.xrLabel37.LocationFloat = New DevExpress.Utils.PointFloat(752.8547!, 30.0!)
        Me.xrLabel37.Name = "xrLabel37"
        Me.xrLabel37.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel37.SizeF = New System.Drawing.SizeF(141.1453!, 18.0!)
        Me.xrLabel37.StyleName = "FieldCaption"
        Me.xrLabel37.StylePriority.UseTextAlignment = False
        xrSummary10.FormatString = "{0:n2}"
        xrSummary10.Func = DevExpress.XtraReports.UI.SummaryFunc.Avg
        xrSummary10.IgnoreNullValues = True
        xrSummary10.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
        Me.xrLabel37.Summary = xrSummary10
        Me.xrLabel37.Text = "xrLabel37"
        Me.xrLabel37.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'xrLabel38
        '
        Me.xrLabel38.LocationFloat = New DevExpress.Utils.PointFloat(6.0!, 30.0!)
        Me.xrLabel38.Name = "xrLabel38"
        Me.xrLabel38.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel38.SizeF = New System.Drawing.SizeF(31.0!, 18.0!)
        Me.xrLabel38.StyleName = "FieldCaption"
        Me.xrLabel38.Text = "Avg"
        '
        'reportFooterBand1
        '
        Me.reportFooterBand1.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.xrLabel40, Me.xrLabel41, Me.xrLabel42, Me.xrLabel43, Me.xrLabel44, Me.xrLabel45})
        Me.reportFooterBand1.HeightF = 30.0!
        Me.reportFooterBand1.Name = "reportFooterBand1"
        '
        'xrLabel40
        '
        Me.xrLabel40.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ExpectedRepayments.PRINCIPAL", "{0:C2}")})
        Me.xrLabel40.LocationFloat = New DevExpress.Utils.PointFloat(436.9137!, 6.00001!)
        Me.xrLabel40.Name = "xrLabel40"
        Me.xrLabel40.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel40.SizeF = New System.Drawing.SizeF(116.1451!, 18.0!)
        Me.xrLabel40.StyleName = "FieldCaption"
        Me.xrLabel40.StylePriority.UseTextAlignment = False
        xrSummary11.FormatString = "{0:n2}"
        xrSummary11.IgnoreNullValues = True
        xrSummary11.Running = DevExpress.XtraReports.UI.SummaryRunning.Report
        Me.xrLabel40.Summary = xrSummary11
        Me.xrLabel40.Text = "xrLabel40"
        Me.xrLabel40.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'xrLabel41
        '
        Me.xrLabel41.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ExpectedRepayments.INTEREST", "{0:C2}")})
        Me.xrLabel41.LocationFloat = New DevExpress.Utils.PointFloat(553.0588!, 6.00001!)
        Me.xrLabel41.Name = "xrLabel41"
        Me.xrLabel41.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel41.SizeF = New System.Drawing.SizeF(93.23578!, 18.0!)
        Me.xrLabel41.StyleName = "FieldCaption"
        Me.xrLabel41.StylePriority.UseTextAlignment = False
        xrSummary12.FormatString = "{0:n2}"
        xrSummary12.IgnoreNullValues = True
        xrSummary12.Running = DevExpress.XtraReports.UI.SummaryRunning.Report
        Me.xrLabel41.Summary = xrSummary12
        Me.xrLabel41.Text = "xrLabel41"
        Me.xrLabel41.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'xrLabel42
        '
        Me.xrLabel42.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ExpectedRepayments.ADMIN_CHARGE", "{0:C2}")})
        Me.xrLabel42.LocationFloat = New DevExpress.Utils.PointFloat(646.2947!, 6.0!)
        Me.xrLabel42.Name = "xrLabel42"
        Me.xrLabel42.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel42.SizeF = New System.Drawing.SizeF(106.56!, 18.0!)
        Me.xrLabel42.StyleName = "FieldCaption"
        Me.xrLabel42.StylePriority.UseTextAlignment = False
        xrSummary13.FormatString = "{0:n2}"
        xrSummary13.IgnoreNullValues = True
        xrSummary13.Running = DevExpress.XtraReports.UI.SummaryRunning.Report
        Me.xrLabel42.Summary = xrSummary13
        Me.xrLabel42.Text = "xrLabel42"
        Me.xrLabel42.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'xrLabel43
        '
        Me.xrLabel43.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ExpectedRepayments.PAYMENT", "{0:C2}")})
        Me.xrLabel43.LocationFloat = New DevExpress.Utils.PointFloat(326.3011!, 6.00001!)
        Me.xrLabel43.Name = "xrLabel43"
        Me.xrLabel43.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel43.SizeF = New System.Drawing.SizeF(110.6126!, 18.0!)
        Me.xrLabel43.StyleName = "FieldCaption"
        Me.xrLabel43.StylePriority.UseTextAlignment = False
        xrSummary14.FormatString = "{0:n2}"
        xrSummary14.IgnoreNullValues = True
        xrSummary14.Running = DevExpress.XtraReports.UI.SummaryRunning.Report
        Me.xrLabel43.Summary = xrSummary14
        Me.xrLabel43.Text = "xrLabel43"
        Me.xrLabel43.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'xrLabel44
        '
        Me.xrLabel44.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ExpectedRepayments.PRINCIPAL_BALANCE", "{0:C2}")})
        Me.xrLabel44.LocationFloat = New DevExpress.Utils.PointFloat(752.8547!, 6.0!)
        Me.xrLabel44.Name = "xrLabel44"
        Me.xrLabel44.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel44.SizeF = New System.Drawing.SizeF(141.1453!, 18.0!)
        Me.xrLabel44.StyleName = "FieldCaption"
        Me.xrLabel44.StylePriority.UseTextAlignment = False
        xrSummary15.FormatString = "{0:n2}"
        xrSummary15.IgnoreNullValues = True
        xrSummary15.Running = DevExpress.XtraReports.UI.SummaryRunning.Report
        Me.xrLabel44.Summary = xrSummary15
        Me.xrLabel44.Text = "xrLabel44"
        Me.xrLabel44.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'xrLabel45
        '
        Me.xrLabel45.LocationFloat = New DevExpress.Utils.PointFloat(6.0!, 6.0!)
        Me.xrLabel45.Name = "xrLabel45"
        Me.xrLabel45.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel45.SizeF = New System.Drawing.SizeF(82.0!, 18.0!)
        Me.xrLabel45.StyleName = "FieldCaption"
        Me.xrLabel45.Text = "Grand Total"
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
        Me.topMarginBand1.Name = "topMarginBand1"
        '
        'bottomMarginBand1
        '
        Me.bottomMarginBand1.Name = "bottomMarginBand1"
        '
        'fromDate
        '
        Me.fromDate.Description = "From Date"
        Me.fromDate.Name = "fromDate"
        Me.fromDate.Type = GetType(Date)
        Me.fromDate.ValueInfo = "2016-01-01"
        '
        'toDate
        '
        Me.toDate.Description = "To Date"
        Me.toDate.Name = "toDate"
        Me.toDate.Type = GetType(Date)
        Me.toDate.ValueInfo = Date.Now.ToLongDateString ' "2016-01-25"
        '
        'xrLabel1
        '
        Me.xrLabel1.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold)
        Me.xrLabel1.LocationFloat = New DevExpress.Utils.PointFloat(6.00001!, 55.08334!)
        Me.xrLabel1.Name = "xrLabel1"
        Me.xrLabel1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96.0!)
        Me.xrLabel1.SizeF = New System.Drawing.SizeF(585.4!, 23.0!)
        Me.xrLabel1.StylePriority.UseFont = False
        Me.xrLabel1.Text = "From [Parameters.fromDate!dd MMM yyyy] to [Parameters.toDate!dd MMM yyyy]"
        '
        'xrptExpectedRepayments
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.groupHeaderBand1, Me.groupHeaderBand2, Me.pageFooterBand1, Me.reportHeaderBand1, Me.groupFooterBand2, Me.reportFooterBand1, Me.topMarginBand1, Me.bottomMarginBand1})
        Me.DataAdapter = Me.expectedRepaymentsTableAdapter1
        Me.DataMember = "ExpectedRepayments"
        Me.DataSource = Me.dsAllReports1
        Me.Landscape = True
        Me.PageHeight = 850
        Me.PageWidth = 1100
        Me.Parameters.AddRange(New DevExpress.XtraReports.Parameters.Parameter() {Me.fromDate, Me.toDate})
        Me.StyleSheet.AddRange(New DevExpress.XtraReports.UI.XRControlStyle() {Me.Title, Me.FieldCaption, Me.PageInfo, Me.DataField})
        Me.Version = "13.2"
        CType(Me.dsAllReports1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand

#End Region

    Private Sub xrptExpectedRepayments_DataSourceDemanded(sender As Object, e As EventArgs) Handles Me.DataSourceDemanded
        expectedRepaymentsTableAdapter1.FillByDateRange(dsAllReports1.ExpectedRepayments, Me.fromDate.Value, Me.toDate.Value)
    End Sub
End Class