Public Class xrptDailyDisbursements
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
    Private WithEvents xrLabel12 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel13 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel14 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel15 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel16 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel17 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel18 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel19 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel20 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents dsAllReports1 As dsAllReports
    Private WithEvents dailyDisbursementTableAdapter1 As dsAllReportsTableAdapters.DailyDisbursementTableAdapter
    Private WithEvents groupHeaderBand1 As DevExpress.XtraReports.UI.GroupHeaderBand
    Private WithEvents xrLabel2 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents groupHeaderBand2 As DevExpress.XtraReports.UI.GroupHeaderBand
    Private WithEvents xrLabel3 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel4 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel5 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel6 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel7 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel8 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel9 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel10 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel11 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLine1 As DevExpress.XtraReports.UI.XRLine
    Private WithEvents xrLine2 As DevExpress.XtraReports.UI.XRLine
    Private WithEvents pageFooterBand1 As DevExpress.XtraReports.UI.PageFooterBand
    Private WithEvents xrPageInfo1 As DevExpress.XtraReports.UI.XRPageInfo
    Private WithEvents xrPageInfo2 As DevExpress.XtraReports.UI.XRPageInfo
    Private WithEvents reportHeaderBand1 As DevExpress.XtraReports.UI.ReportHeaderBand
    Private WithEvents xrLabel21 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents groupFooterBand1 As DevExpress.XtraReports.UI.GroupFooterBand
    Private WithEvents groupFooterBand2 As DevExpress.XtraReports.UI.GroupFooterBand
    Private WithEvents xrLabel23 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel24 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel26 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel27 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents reportFooterBand1 As DevExpress.XtraReports.UI.ReportFooterBand
    Private WithEvents xrLabel29 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel30 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents Title As DevExpress.XtraReports.UI.XRControlStyle
    Private WithEvents FieldCaption As DevExpress.XtraReports.UI.XRControlStyle
    Private WithEvents PageInfo As DevExpress.XtraReports.UI.XRControlStyle
    Private WithEvents DataField As DevExpress.XtraReports.UI.XRControlStyle
    Private WithEvents topMarginBand1 As DevExpress.XtraReports.UI.TopMarginBand
    Private WithEvents bottomMarginBand1 As DevExpress.XtraReports.UI.BottomMarginBand
    Private WithEvents fromDate As DevExpress.XtraReports.Parameters.Parameter
    Private WithEvents toDate As DevExpress.XtraReports.Parameters.Parameter

    'Required by the Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Designer
    'It can be modified using the Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resourceFileName As String = "xrptDailyDisbursements.resx"
        Dim xrSummary1 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
        Dim xrSummary2 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
        Dim xrSummary3 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
        Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
        Me.xrLabel12 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel13 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel14 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel15 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel16 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel17 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel18 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel19 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel20 = New DevExpress.XtraReports.UI.XRLabel()
        Me.dsAllReports1 = New dsAllReports()
        Me.dailyDisbursementTableAdapter1 = New dsAllReportsTableAdapters.DailyDisbursementTableAdapter()
        Me.groupHeaderBand1 = New DevExpress.XtraReports.UI.GroupHeaderBand()
        Me.xrLabel2 = New DevExpress.XtraReports.UI.XRLabel()
        Me.groupHeaderBand2 = New DevExpress.XtraReports.UI.GroupHeaderBand()
        Me.xrLabel3 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel4 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel5 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel6 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel7 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel8 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel9 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel10 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel11 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLine1 = New DevExpress.XtraReports.UI.XRLine()
        Me.xrLine2 = New DevExpress.XtraReports.UI.XRLine()
        Me.pageFooterBand1 = New DevExpress.XtraReports.UI.PageFooterBand()
        Me.xrPageInfo1 = New DevExpress.XtraReports.UI.XRPageInfo()
        Me.xrPageInfo2 = New DevExpress.XtraReports.UI.XRPageInfo()
        Me.reportHeaderBand1 = New DevExpress.XtraReports.UI.ReportHeaderBand()
        Me.xrLabel21 = New DevExpress.XtraReports.UI.XRLabel()
        Me.groupFooterBand1 = New DevExpress.XtraReports.UI.GroupFooterBand()
        Me.groupFooterBand2 = New DevExpress.XtraReports.UI.GroupFooterBand()
        Me.xrLabel23 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel24 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel26 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel27 = New DevExpress.XtraReports.UI.XRLabel()
        Me.reportFooterBand1 = New DevExpress.XtraReports.UI.ReportFooterBand()
        Me.xrLabel29 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel30 = New DevExpress.XtraReports.UI.XRLabel()
        Me.Title = New DevExpress.XtraReports.UI.XRControlStyle()
        Me.FieldCaption = New DevExpress.XtraReports.UI.XRControlStyle()
        Me.PageInfo = New DevExpress.XtraReports.UI.XRControlStyle()
        Me.DataField = New DevExpress.XtraReports.UI.XRControlStyle()
        Me.topMarginBand1 = New DevExpress.XtraReports.UI.TopMarginBand()
        Me.bottomMarginBand1 = New DevExpress.XtraReports.UI.BottomMarginBand()
        Me.fromDate = New DevExpress.XtraReports.Parameters.Parameter()
        Me.toDate = New DevExpress.XtraReports.Parameters.Parameter()
        CType(Me.dsAllReports1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.xrLabel12, Me.xrLabel13, Me.xrLabel14, Me.xrLabel15, Me.xrLabel16, Me.xrLabel17, Me.xrLabel18, Me.xrLabel19, Me.xrLabel20})
        Me.Detail.HeightF = 53.0!
        Me.Detail.Name = "Detail"
        Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.Detail.StyleName = "DataField"
        Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'xrLabel12
        '
        Me.xrLabel12.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "DailyDisbursement.Debit", "{0:n2}")})
        Me.xrLabel12.LocationFloat = New DevExpress.Utils.PointFloat(647.6002!, 0.0!)
        Me.xrLabel12.Name = "xrLabel12"
        Me.xrLabel12.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel12.SizeF = New System.Drawing.SizeF(96.83783!, 18.0!)
        Me.xrLabel12.Text = "xrLabel12"
        '
        'xrLabel13
        '
        Me.xrLabel13.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "DailyDisbursement.CUSTOMER_NUMBER")})
        Me.xrLabel13.LocationFloat = New DevExpress.Utils.PointFloat(10.0!, 0.0!)
        Me.xrLabel13.Name = "xrLabel13"
        Me.xrLabel13.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel13.SizeF = New System.Drawing.SizeF(83.40468!, 18.0!)
        Me.xrLabel13.Text = "xrLabel13"
        '
        'xrLabel14
        '
        Me.xrLabel14.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "DailyDisbursement.SURNAME")})
        Me.xrLabel14.LocationFloat = New DevExpress.Utils.PointFloat(93.40468!, 0.0!)
        Me.xrLabel14.Name = "xrLabel14"
        Me.xrLabel14.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel14.SizeF = New System.Drawing.SizeF(98.08542!, 18.0!)
        Me.xrLabel14.Text = "xrLabel14"
        '
        'xrLabel15
        '
        Me.xrLabel15.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "DailyDisbursement.FORENAMES")})
        Me.xrLabel15.LocationFloat = New DevExpress.Utils.PointFloat(191.4901!, 0.0!)
        Me.xrLabel15.Name = "xrLabel15"
        Me.xrLabel15.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel15.SizeF = New System.Drawing.SizeF(121.6259!, 18.0!)
        Me.xrLabel15.Text = "xrLabel15"
        '
        'xrLabel16
        '
        Me.xrLabel16.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "DailyDisbursement.IDNO")})
        Me.xrLabel16.LocationFloat = New DevExpress.Utils.PointFloat(313.116!, 0.0!)
        Me.xrLabel16.Name = "xrLabel16"
        Me.xrLabel16.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel16.SizeF = New System.Drawing.SizeF(97.87943!, 18.0!)
        Me.xrLabel16.Text = "xrLabel16"
        '
        'xrLabel17
        '
        Me.xrLabel17.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "DailyDisbursement.ADDRESS")})
        Me.xrLabel17.LocationFloat = New DevExpress.Utils.PointFloat(410.9954!, 0.0!)
        Me.xrLabel17.Name = "xrLabel17"
        Me.xrLabel17.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel17.SizeF = New System.Drawing.SizeF(128.5369!, 18.0!)
        Me.xrLabel17.Text = "xrLabel17"
        '
        'xrLabel18
        '
        Me.xrLabel18.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "DailyDisbursement.FIN_AMT", "{0:n2}")})
        Me.xrLabel18.LocationFloat = New DevExpress.Utils.PointFloat(539.5323!, 0.0!)
        Me.xrLabel18.Name = "xrLabel18"
        Me.xrLabel18.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel18.SizeF = New System.Drawing.SizeF(108.0678!, 18.0!)
        Me.xrLabel18.Text = "xrLabel18"
        '
        'xrLabel19
        '
        Me.xrLabel19.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "DailyDisbursement.FIN_TENOR", "{0:#,#}")})
        Me.xrLabel19.LocationFloat = New DevExpress.Utils.PointFloat(744.438!, 0.0!)
        Me.xrLabel19.Name = "xrLabel19"
        Me.xrLabel19.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel19.SizeF = New System.Drawing.SizeF(55.39996!, 18.0!)
        Me.xrLabel19.Text = "xrLabel19"
        '
        'xrLabel20
        '
        Me.xrLabel20.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "DailyDisbursement.PAYMENT", "{0:n2}")})
        Me.xrLabel20.LocationFloat = New DevExpress.Utils.PointFloat(799.838!, 0.0!)
        Me.xrLabel20.Name = "xrLabel20"
        Me.xrLabel20.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel20.SizeF = New System.Drawing.SizeF(94.16205!, 18.0!)
        Me.xrLabel20.Text = "xrLabel20"
        '
        'dsAllReports1
        '
        Me.dsAllReports1.DataSetName = "dsAllReports"
        Me.dsAllReports1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'dailyDisbursementTableAdapter1
        '
        Me.dailyDisbursementTableAdapter1.ClearBeforeFill = True
        '
        'groupHeaderBand1
        '
        Me.groupHeaderBand1.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.xrLabel2})
        Me.groupHeaderBand1.GroupFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("TrxnDate", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
        Me.groupHeaderBand1.HeightF = 36.0!
        Me.groupHeaderBand1.Level = 1
        Me.groupHeaderBand1.Name = "groupHeaderBand1"
        '
        'xrLabel2
        '
        Me.xrLabel2.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "DailyDisbursement.TrxnDate", "{0:dd MMMM yyyy}")})
        Me.xrLabel2.Font = New System.Drawing.Font("Times New Roman", 10.0!, System.Drawing.FontStyle.Bold)
        Me.xrLabel2.LocationFloat = New DevExpress.Utils.PointFloat(38.54167!, 0.0!)
        Me.xrLabel2.Name = "xrLabel2"
        Me.xrLabel2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel2.SizeF = New System.Drawing.SizeF(228.375!, 36.0!)
        Me.xrLabel2.StyleName = "DataField"
        Me.xrLabel2.StylePriority.UseFont = False
        Me.xrLabel2.Text = "xrLabel2"
        '
        'groupHeaderBand2
        '
        Me.groupHeaderBand2.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.xrLabel3, Me.xrLabel4, Me.xrLabel5, Me.xrLabel6, Me.xrLabel7, Me.xrLabel8, Me.xrLabel9, Me.xrLabel10, Me.xrLabel11, Me.xrLine1, Me.xrLine2})
        Me.groupHeaderBand2.HeightF = 27.0!
        Me.groupHeaderBand2.Name = "groupHeaderBand2"
        Me.groupHeaderBand2.StyleName = "FieldCaption"
        '
        'xrLabel3
        '
        Me.xrLabel3.LocationFloat = New DevExpress.Utils.PointFloat(647.6002!, 7.000001!)
        Me.xrLabel3.Name = "xrLabel3"
        Me.xrLabel3.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel3.SizeF = New System.Drawing.SizeF(96.83783!, 18.0!)
        Me.xrLabel3.Text = "Disbursed Amount"
        '
        'xrLabel4
        '
        Me.xrLabel4.LocationFloat = New DevExpress.Utils.PointFloat(10.0!, 7.000001!)
        Me.xrLabel4.Name = "xrLabel4"
        Me.xrLabel4.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel4.SizeF = New System.Drawing.SizeF(83.40468!, 18.0!)
        Me.xrLabel4.Text = "Customer Ref"
        '
        'xrLabel5
        '
        Me.xrLabel5.LocationFloat = New DevExpress.Utils.PointFloat(93.40468!, 7.0!)
        Me.xrLabel5.Name = "xrLabel5"
        Me.xrLabel5.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel5.SizeF = New System.Drawing.SizeF(98.08542!, 18.0!)
        Me.xrLabel5.Text = "Surname"
        '
        'xrLabel6
        '
        Me.xrLabel6.LocationFloat = New DevExpress.Utils.PointFloat(191.4901!, 7.0!)
        Me.xrLabel6.Name = "xrLabel6"
        Me.xrLabel6.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel6.SizeF = New System.Drawing.SizeF(121.6259!, 18.0!)
        Me.xrLabel6.Text = "Forenames"
        '
        'xrLabel7
        '
        Me.xrLabel7.LocationFloat = New DevExpress.Utils.PointFloat(313.116!, 7.000001!)
        Me.xrLabel7.Name = "xrLabel7"
        Me.xrLabel7.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel7.SizeF = New System.Drawing.SizeF(97.87943!, 18.0!)
        Me.xrLabel7.Text = "ID No"
        '
        'xrLabel8
        '
        Me.xrLabel8.LocationFloat = New DevExpress.Utils.PointFloat(410.9954!, 7.000001!)
        Me.xrLabel8.Name = "xrLabel8"
        Me.xrLabel8.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel8.SizeF = New System.Drawing.SizeF(128.5369!, 18.0!)
        Me.xrLabel8.Text = "Address"
        '
        'xrLabel9
        '
        Me.xrLabel9.LocationFloat = New DevExpress.Utils.PointFloat(539.5323!, 7.000001!)
        Me.xrLabel9.Name = "xrLabel9"
        Me.xrLabel9.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel9.SizeF = New System.Drawing.SizeF(108.0678!, 18.0!)
        Me.xrLabel9.Text = "Applied Amount"
        '
        'xrLabel10
        '
        Me.xrLabel10.LocationFloat = New DevExpress.Utils.PointFloat(744.438!, 7.000001!)
        Me.xrLabel10.Name = "xrLabel10"
        Me.xrLabel10.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel10.SizeF = New System.Drawing.SizeF(55.40002!, 18.0!)
        Me.xrLabel10.Text = "Tenure"
        '
        'xrLabel11
        '
        Me.xrLabel11.LocationFloat = New DevExpress.Utils.PointFloat(799.838!, 7.0!)
        Me.xrLabel11.Name = "xrLabel11"
        Me.xrLabel11.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel11.SizeF = New System.Drawing.SizeF(94.16205!, 18.0!)
        Me.xrLabel11.Text = "Instalment"
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
        Me.reportHeaderBand1.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.xrLabel21})
        Me.reportHeaderBand1.HeightF = 51.0!
        Me.reportHeaderBand1.Name = "reportHeaderBand1"
        '
        'xrLabel21
        '
        Me.xrLabel21.LocationFloat = New DevExpress.Utils.PointFloat(6.0!, 6.0!)
        Me.xrLabel21.Name = "xrLabel21"
        Me.xrLabel21.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel21.SizeF = New System.Drawing.SizeF(888.0!, 33.0!)
        Me.xrLabel21.StyleName = "Title"
        Me.xrLabel21.Text = "Daily Disbursement Report"
        '
        'groupFooterBand1
        '
        Me.groupFooterBand1.HeightF = 1.0!
        Me.groupFooterBand1.Name = "groupFooterBand1"
        '
        'groupFooterBand2
        '
        Me.groupFooterBand2.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.xrLabel23, Me.xrLabel24, Me.xrLabel26, Me.xrLabel27})
        Me.groupFooterBand2.HeightF = 54.0!
        Me.groupFooterBand2.Level = 1
        Me.groupFooterBand2.Name = "groupFooterBand2"
        '
        'xrLabel23
        '
        Me.xrLabel23.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "DailyDisbursement.PAYMENT", "{0:C2}")})
        Me.xrLabel23.LocationFloat = New DevExpress.Utils.PointFloat(799.838!, 6.0!)
        Me.xrLabel23.Name = "xrLabel23"
        Me.xrLabel23.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel23.SizeF = New System.Drawing.SizeF(94.16205!, 18.0!)
        Me.xrLabel23.StyleName = "FieldCaption"
        xrSummary1.FormatString = "{0:C2}"
        xrSummary1.IgnoreNullValues = True
        xrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
        Me.xrLabel23.Summary = xrSummary1
        Me.xrLabel23.Text = "xrLabel23"
        '
        'xrLabel24
        '
        Me.xrLabel24.LocationFloat = New DevExpress.Utils.PointFloat(6.0!, 6.0!)
        Me.xrLabel24.Name = "xrLabel24"
        Me.xrLabel24.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel24.SizeF = New System.Drawing.SizeF(35.0!, 18.0!)
        Me.xrLabel24.StyleName = "FieldCaption"
        Me.xrLabel24.Text = "Sum"
        '
        'xrLabel26
        '
        Me.xrLabel26.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "DailyDisbursement.PAYMENT", "{0:C2}")})
        Me.xrLabel26.LocationFloat = New DevExpress.Utils.PointFloat(799.838!, 30.0!)
        Me.xrLabel26.Name = "xrLabel26"
        Me.xrLabel26.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel26.SizeF = New System.Drawing.SizeF(94.16205!, 18.0!)
        Me.xrLabel26.StyleName = "FieldCaption"
        xrSummary2.FormatString = "{0:C2}"
        xrSummary2.Func = DevExpress.XtraReports.UI.SummaryFunc.Avg
        xrSummary2.IgnoreNullValues = True
        xrSummary2.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
        Me.xrLabel26.Summary = xrSummary2
        Me.xrLabel26.Text = "xrLabel26"
        '
        'xrLabel27
        '
        Me.xrLabel27.LocationFloat = New DevExpress.Utils.PointFloat(6.0!, 30.0!)
        Me.xrLabel27.Name = "xrLabel27"
        Me.xrLabel27.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel27.SizeF = New System.Drawing.SizeF(31.0!, 18.0!)
        Me.xrLabel27.StyleName = "FieldCaption"
        Me.xrLabel27.Text = "Avg"
        '
        'reportFooterBand1
        '
        Me.reportFooterBand1.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.xrLabel29, Me.xrLabel30})
        Me.reportFooterBand1.HeightF = 30.0!
        Me.reportFooterBand1.Name = "reportFooterBand1"
        '
        'xrLabel29
        '
        Me.xrLabel29.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "DailyDisbursement.PAYMENT", "{0:C2}")})
        Me.xrLabel29.LocationFloat = New DevExpress.Utils.PointFloat(799.838!, 6.0!)
        Me.xrLabel29.Name = "xrLabel29"
        Me.xrLabel29.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel29.SizeF = New System.Drawing.SizeF(94.16205!, 18.0!)
        Me.xrLabel29.StyleName = "FieldCaption"
        xrSummary3.FormatString = "{0:C2}"
        xrSummary3.IgnoreNullValues = True
        xrSummary3.Running = DevExpress.XtraReports.UI.SummaryRunning.Report
        Me.xrLabel29.Summary = xrSummary3
        Me.xrLabel29.Text = "xrLabel29"
        '
        'xrLabel30
        '
        Me.xrLabel30.LocationFloat = New DevExpress.Utils.PointFloat(6.0!, 6.0!)
        Me.xrLabel30.Name = "xrLabel30"
        Me.xrLabel30.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel30.SizeF = New System.Drawing.SizeF(82.0!, 18.0!)
        Me.xrLabel30.StyleName = "FieldCaption"
        Me.xrLabel30.Text = "Grand Total"
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
        Me.fromDate.ValueInfo = "2015-01-01"
        '
        'toDate
        '
        Me.toDate.Description = "To Date"
        Me.toDate.Name = "toDate"
        Me.toDate.Type = GetType(Date)
        Me.toDate.ValueInfo = Date.Now.ToLongDateString ' "2016-01-25"
        '
        'xrptDailyDisbursements
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.groupHeaderBand1, Me.groupHeaderBand2, Me.pageFooterBand1, Me.reportHeaderBand1, Me.groupFooterBand2, Me.reportFooterBand1, Me.topMarginBand1, Me.bottomMarginBand1})
        Me.DataAdapter = Me.dailyDisbursementTableAdapter1
        Me.DataMember = "DailyDisbursement"
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

    Private Sub xrptDailyDisbursements_DataSourceDemanded(sender As Object, e As EventArgs) Handles Me.DataSourceDemanded
        dailyDisbursementTableAdapter1.FillByDateRange(dsAllReports1.DailyDisbursement, Me.fromDate.Value, Me.toDate.Value)
    End Sub
End Class