Public Class xrptOutreach
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
    Private WithEvents xrLabel20 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel21 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel1 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel2 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel3 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel4 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel5 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel6 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel7 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel8 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel9 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel10 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel11 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel12 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel13 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel14 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel15 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel16 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel17 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel18 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents dsPortfolioManagement1 As dsPortfolioManagement
    Private WithEvents outreachTableAdapter1 As dsPortfolioManagementTableAdapters.OutreachTableAdapter
    Private WithEvents pageFooterBand1 As DevExpress.XtraReports.UI.PageFooterBand
    Private WithEvents xrPageInfo1 As DevExpress.XtraReports.UI.XRPageInfo
    Private WithEvents xrPageInfo2 As DevExpress.XtraReports.UI.XRPageInfo
    Private WithEvents reportHeaderBand1 As DevExpress.XtraReports.UI.ReportHeaderBand
    Private WithEvents xrLabel19 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents Title As DevExpress.XtraReports.UI.XRControlStyle
    Private WithEvents FieldCaption As DevExpress.XtraReports.UI.XRControlStyle
    Private WithEvents PageInfo As DevExpress.XtraReports.UI.XRControlStyle
    Private WithEvents DataField As DevExpress.XtraReports.UI.XRControlStyle
    Private WithEvents topMarginBand1 As DevExpress.XtraReports.UI.TopMarginBand
    Private WithEvents bottomMarginBand1 As DevExpress.XtraReports.UI.BottomMarginBand
    Private WithEvents fromDate As DevExpress.XtraReports.Parameters.Parameter
    Private WithEvents toDate As DevExpress.XtraReports.Parameters.Parameter
    Private WithEvents xrLabel22 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents PercWomen As DevExpress.XtraReports.UI.CalculatedField

    'Required by the Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Designer
    'It can be modified using the Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resourceFileName As String = "xrptOutreach.resx"
        Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
        Me.xrLabel20 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel21 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel1 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel2 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel3 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel4 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel5 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel6 = New DevExpress.XtraReports.UI.XRLabel()
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
        Me.dsPortfolioManagement1 = New dsPortfolioManagement()
        Me.outreachTableAdapter1 = New dsPortfolioManagementTableAdapters.OutreachTableAdapter()
        Me.pageFooterBand1 = New DevExpress.XtraReports.UI.PageFooterBand()
        Me.xrPageInfo1 = New DevExpress.XtraReports.UI.XRPageInfo()
        Me.xrPageInfo2 = New DevExpress.XtraReports.UI.XRPageInfo()
        Me.reportHeaderBand1 = New DevExpress.XtraReports.UI.ReportHeaderBand()
        Me.xrLabel22 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel19 = New DevExpress.XtraReports.UI.XRLabel()
        Me.Title = New DevExpress.XtraReports.UI.XRControlStyle()
        Me.FieldCaption = New DevExpress.XtraReports.UI.XRControlStyle()
        Me.PageInfo = New DevExpress.XtraReports.UI.XRControlStyle()
        Me.DataField = New DevExpress.XtraReports.UI.XRControlStyle()
        Me.topMarginBand1 = New DevExpress.XtraReports.UI.TopMarginBand()
        Me.bottomMarginBand1 = New DevExpress.XtraReports.UI.BottomMarginBand()
        Me.fromDate = New DevExpress.XtraReports.Parameters.Parameter()
        Me.toDate = New DevExpress.XtraReports.Parameters.Parameter()
        Me.PercWomen = New DevExpress.XtraReports.UI.CalculatedField()
        CType(Me.dsPortfolioManagement1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.xrLabel20, Me.xrLabel21, Me.xrLabel1, Me.xrLabel2, Me.xrLabel3, Me.xrLabel4, Me.xrLabel5, Me.xrLabel6, Me.xrLabel7, Me.xrLabel8, Me.xrLabel9, Me.xrLabel10, Me.xrLabel11, Me.xrLabel12, Me.xrLabel13, Me.xrLabel14, Me.xrLabel15, Me.xrLabel16, Me.xrLabel17, Me.xrLabel18})
        Me.Detail.HeightF = 262.5417!
        Me.Detail.Name = "Detail"
        Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'xrLabel20
        '
        Me.xrLabel20.LocationFloat = New DevExpress.Utils.PointFloat(20.41667!, 225.0!)
        Me.xrLabel20.Name = "xrLabel20"
        Me.xrLabel20.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel20.SizeF = New System.Drawing.SizeF(484.0!, 18.0!)
        Me.xrLabel20.StyleName = "FieldCaption"
        Me.xrLabel20.Text = "Percentage of Female Borrowers to Total Borrowers"
        '
        'xrLabel21
        '
        Me.xrLabel21.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Outreach.PercWomen", "{0:#,#}")})
        Me.xrLabel21.LocationFloat = New DevExpress.Utils.PointFloat(523.1666!, 225.0!)
        Me.xrLabel21.Name = "xrLabel21"
        Me.xrLabel21.NullValueText = "0"
        Me.xrLabel21.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel21.SizeF = New System.Drawing.SizeF(116.8334!, 18.0!)
        Me.xrLabel21.StyleName = "DataField"
        Me.xrLabel21.StylePriority.UseTextAlignment = False
        Me.xrLabel21.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'xrLabel1
        '
        Me.xrLabel1.LocationFloat = New DevExpress.Utils.PointFloat(20.41667!, 9.000015!)
        Me.xrLabel1.Name = "xrLabel1"
        Me.xrLabel1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel1.SizeF = New System.Drawing.SizeF(484.0!, 18.0!)
        Me.xrLabel1.StyleName = "FieldCaption"
        Me.xrLabel1.Text = "Number of Branches"
        '
        'xrLabel2
        '
        Me.xrLabel2.LocationFloat = New DevExpress.Utils.PointFloat(20.41667!, 32.99999!)
        Me.xrLabel2.Name = "xrLabel2"
        Me.xrLabel2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel2.SizeF = New System.Drawing.SizeF(484.0!, 18.0!)
        Me.xrLabel2.StyleName = "FieldCaption"
        Me.xrLabel2.Text = "Number of Outstanding Loans"
        '
        'xrLabel3
        '
        Me.xrLabel3.LocationFloat = New DevExpress.Utils.PointFloat(20.41667!, 57.0!)
        Me.xrLabel3.Name = "xrLabel3"
        Me.xrLabel3.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel3.SizeF = New System.Drawing.SizeF(484.0!, 18.0!)
        Me.xrLabel3.StyleName = "FieldCaption"
        Me.xrLabel3.Text = "Number of Borrowing Groups"
        '
        'xrLabel4
        '
        Me.xrLabel4.LocationFloat = New DevExpress.Utils.PointFloat(20.41667!, 81.00001!)
        Me.xrLabel4.Name = "xrLabel4"
        Me.xrLabel4.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel4.SizeF = New System.Drawing.SizeF(484.0!, 18.0!)
        Me.xrLabel4.StyleName = "FieldCaption"
        Me.xrLabel4.Text = "Number of Active Loan Clients Receiving Loans as Members of a Group"
        '
        'xrLabel5
        '
        Me.xrLabel5.LocationFloat = New DevExpress.Utils.PointFloat(20.41667!, 105.0!)
        Me.xrLabel5.Name = "xrLabel5"
        Me.xrLabel5.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel5.SizeF = New System.Drawing.SizeF(484.0!, 18.0!)
        Me.xrLabel5.StyleName = "FieldCaption"
        Me.xrLabel5.Text = "Number of Active Loan Clients Receiving Loans as Individual"
        '
        'xrLabel6
        '
        Me.xrLabel6.LocationFloat = New DevExpress.Utils.PointFloat(20.41667!, 129.0!)
        Me.xrLabel6.Name = "xrLabel6"
        Me.xrLabel6.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel6.SizeF = New System.Drawing.SizeF(484.0!, 18.0!)
        Me.xrLabel6.StyleName = "FieldCaption"
        Me.xrLabel6.Text = "Number of Loans with a Disbursed Loan Amount More Than $10,000"
        '
        'xrLabel7
        '
        Me.xrLabel7.LocationFloat = New DevExpress.Utils.PointFloat(20.41667!, 153.0!)
        Me.xrLabel7.Name = "xrLabel7"
        Me.xrLabel7.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel7.SizeF = New System.Drawing.SizeF(484.0!, 18.0!)
        Me.xrLabel7.StyleName = "FieldCaption"
        Me.xrLabel7.Text = "Number of Loans with a Disbursed Loan Amount Greater Than $20,000"
        '
        'xrLabel8
        '
        Me.xrLabel8.LocationFloat = New DevExpress.Utils.PointFloat(20.41667!, 177.0!)
        Me.xrLabel8.Name = "xrLabel8"
        Me.xrLabel8.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel8.SizeF = New System.Drawing.SizeF(484.0!, 18.0!)
        Me.xrLabel8.StyleName = "FieldCaption"
        Me.xrLabel8.Text = "Number of Female Borrowers"
        '
        'xrLabel9
        '
        Me.xrLabel9.LocationFloat = New DevExpress.Utils.PointFloat(20.41667!, 201.0!)
        Me.xrLabel9.Name = "xrLabel9"
        Me.xrLabel9.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel9.SizeF = New System.Drawing.SizeF(484.0!, 17.99998!)
        Me.xrLabel9.StyleName = "FieldCaption"
        Me.xrLabel9.Text = "Number of Individual Loans"
        '
        'xrLabel10
        '
        Me.xrLabel10.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Outreach.NoBranches", "{0:#,#}")})
        Me.xrLabel10.LocationFloat = New DevExpress.Utils.PointFloat(523.1666!, 8.999999!)
        Me.xrLabel10.Name = "xrLabel10"
        Me.xrLabel10.NullValueText = "0"
        Me.xrLabel10.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel10.SizeF = New System.Drawing.SizeF(116.8334!, 18.0!)
        Me.xrLabel10.StyleName = "DataField"
        Me.xrLabel10.StylePriority.UseTextAlignment = False
        Me.xrLabel10.Text = "xrLabel10"
        Me.xrLabel10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'xrLabel11
        '
        Me.xrLabel11.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Outreach.NoOutstandingLoans", "{0:#,#}")})
        Me.xrLabel11.LocationFloat = New DevExpress.Utils.PointFloat(523.1666!, 32.99999!)
        Me.xrLabel11.Name = "xrLabel11"
        Me.xrLabel11.NullValueText = "0"
        Me.xrLabel11.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel11.SizeF = New System.Drawing.SizeF(116.8334!, 18.0!)
        Me.xrLabel11.StyleName = "DataField"
        Me.xrLabel11.StylePriority.UseTextAlignment = False
        Me.xrLabel11.Text = "xrLabel11"
        Me.xrLabel11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'xrLabel12
        '
        Me.xrLabel12.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Outreach.NoBorrowingGroups")})
        Me.xrLabel12.LocationFloat = New DevExpress.Utils.PointFloat(523.1666!, 57.0!)
        Me.xrLabel12.Name = "xrLabel12"
        Me.xrLabel12.NullValueText = "0"
        Me.xrLabel12.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel12.SizeF = New System.Drawing.SizeF(116.8334!, 18.0!)
        Me.xrLabel12.StyleName = "DataField"
        Me.xrLabel12.StylePriority.UseTextAlignment = False
        Me.xrLabel12.Text = "xrLabel12"
        Me.xrLabel12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'xrLabel13
        '
        Me.xrLabel13.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Outreach.NoOutstandingLoansGroups", "{0:#,#}")})
        Me.xrLabel13.LocationFloat = New DevExpress.Utils.PointFloat(523.1666!, 81.00001!)
        Me.xrLabel13.Name = "xrLabel13"
        Me.xrLabel13.NullValueText = "0"
        Me.xrLabel13.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel13.SizeF = New System.Drawing.SizeF(116.8334!, 18.0!)
        Me.xrLabel13.StyleName = "DataField"
        Me.xrLabel13.StylePriority.UseTextAlignment = False
        Me.xrLabel13.Text = "xrLabel13"
        Me.xrLabel13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'xrLabel14
        '
        Me.xrLabel14.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Outreach.NoOutstandingLoansIndiv", "{0:#,#}")})
        Me.xrLabel14.LocationFloat = New DevExpress.Utils.PointFloat(523.1666!, 105.0!)
        Me.xrLabel14.Name = "xrLabel14"
        Me.xrLabel14.NullValueText = "0"
        Me.xrLabel14.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel14.SizeF = New System.Drawing.SizeF(116.8334!, 18.0!)
        Me.xrLabel14.StyleName = "DataField"
        Me.xrLabel14.StylePriority.UseTextAlignment = False
        Me.xrLabel14.Text = "xrLabel14"
        Me.xrLabel14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'xrLabel15
        '
        Me.xrLabel15.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Outreach.NoLoans10000", "{0:#,#}")})
        Me.xrLabel15.LocationFloat = New DevExpress.Utils.PointFloat(523.1666!, 129.0!)
        Me.xrLabel15.Name = "xrLabel15"
        Me.xrLabel15.NullValueText = "0"
        Me.xrLabel15.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel15.SizeF = New System.Drawing.SizeF(116.8334!, 18.0!)
        Me.xrLabel15.StyleName = "DataField"
        Me.xrLabel15.StylePriority.UseTextAlignment = False
        Me.xrLabel15.Text = "xrLabel15"
        Me.xrLabel15.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'xrLabel16
        '
        Me.xrLabel16.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Outreach.NoLoans20000", "{0:#,#}")})
        Me.xrLabel16.LocationFloat = New DevExpress.Utils.PointFloat(523.1666!, 153.0!)
        Me.xrLabel16.Name = "xrLabel16"
        Me.xrLabel16.NullValueText = "0"
        Me.xrLabel16.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel16.SizeF = New System.Drawing.SizeF(116.8334!, 18.0!)
        Me.xrLabel16.StyleName = "DataField"
        Me.xrLabel16.StylePriority.UseTextAlignment = False
        Me.xrLabel16.Text = "xrLabel16"
        Me.xrLabel16.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'xrLabel17
        '
        Me.xrLabel17.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Outreach.NoFemale", "{0:#,#}")})
        Me.xrLabel17.LocationFloat = New DevExpress.Utils.PointFloat(523.1666!, 177.0!)
        Me.xrLabel17.Name = "xrLabel17"
        Me.xrLabel17.NullValueText = "0"
        Me.xrLabel17.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel17.SizeF = New System.Drawing.SizeF(116.8334!, 18.0!)
        Me.xrLabel17.StyleName = "DataField"
        Me.xrLabel17.StylePriority.UseTextAlignment = False
        Me.xrLabel17.Text = "xrLabel17"
        Me.xrLabel17.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'xrLabel18
        '
        Me.xrLabel18.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Outreach.NoIndivLoans", "{0:#,#}")})
        Me.xrLabel18.LocationFloat = New DevExpress.Utils.PointFloat(523.1666!, 201.0!)
        Me.xrLabel18.Name = "xrLabel18"
        Me.xrLabel18.NullValueText = "0"
        Me.xrLabel18.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel18.SizeF = New System.Drawing.SizeF(116.8334!, 17.99998!)
        Me.xrLabel18.StyleName = "DataField"
        Me.xrLabel18.StylePriority.UseTextAlignment = False
        Me.xrLabel18.Text = "xrLabel18"
        Me.xrLabel18.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'dsPortfolioManagement1
        '
        Me.dsPortfolioManagement1.DataSetName = "dsPortfolioManagement"
        Me.dsPortfolioManagement1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'outreachTableAdapter1
        '
        Me.outreachTableAdapter1.ClearBeforeFill = True
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
        Me.reportHeaderBand1.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.xrLabel22, Me.xrLabel19})
        Me.reportHeaderBand1.HeightF = 91.62499!
        Me.reportHeaderBand1.Name = "reportHeaderBand1"
        '
        'xrLabel22
        '
        Me.xrLabel22.Font = New System.Drawing.Font("Times New Roman", 10.0!, System.Drawing.FontStyle.Bold)
        Me.xrLabel22.LocationFloat = New DevExpress.Utils.PointFloat(20.41667!, 58.62499!)
        Me.xrLabel22.Name = "xrLabel22"
        Me.xrLabel22.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel22.SizeF = New System.Drawing.SizeF(371.875!, 23.0!)
        Me.xrLabel22.StylePriority.UseFont = False
        Me.xrLabel22.Text = "As at: [Parameters.toDate!dd MMM,yyyy]"
        '
        'xrLabel19
        '
        Me.xrLabel19.LocationFloat = New DevExpress.Utils.PointFloat(6.0!, 6.0!)
        Me.xrLabel19.Name = "xrLabel19"
        Me.xrLabel19.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel19.SizeF = New System.Drawing.SizeF(638.0!, 33.0!)
        Me.xrLabel19.StyleName = "Title"
        Me.xrLabel19.Text = "Outreach Report"
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
        Me.toDate.ValueInfo = Now.ToLongDateString
        '
        'PercWomen
        '
        Me.PercWomen.DataMember = "Outreach"
        Me.PercWomen.Expression = "[NoFemale] / [NoIndivLoans] * 100"
        Me.PercWomen.FieldType = DevExpress.XtraReports.UI.FieldType.Float
        Me.PercWomen.Name = "PercWomen"
        '
        'xrptOutreach
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.pageFooterBand1, Me.reportHeaderBand1, Me.topMarginBand1, Me.bottomMarginBand1})
        Me.CalculatedFields.AddRange(New DevExpress.XtraReports.UI.CalculatedField() {Me.PercWomen})
        Me.DataAdapter = Me.outreachTableAdapter1
        Me.DataMember = "Outreach"
        Me.DataSource = Me.dsPortfolioManagement1
        Me.Parameters.AddRange(New DevExpress.XtraReports.Parameters.Parameter() {Me.fromDate, Me.toDate})
        Me.StyleSheet.AddRange(New DevExpress.XtraReports.UI.XRControlStyle() {Me.Title, Me.FieldCaption, Me.PageInfo, Me.DataField})
        Me.Version = "13.2"
        CType(Me.dsPortfolioManagement1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand

#End Region

    Private Sub xrptOutreach_DataSourceDemanded(sender As Object, e As EventArgs) Handles Me.DataSourceDemanded
        outreachTableAdapter1.FillByDateRange(dsPortfolioManagement1.Outreach, Me.fromDate.Value, toDate.Value)
    End Sub
End Class