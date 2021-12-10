Public Class xrptPortfolioActivity
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
    Private WithEvents dsPortfolioManagement1 As dsPortfolioManagement
    Private WithEvents portfolioActivityTableAdapter1 As dsPortfolioManagementTableAdapters.PortfolioActivityTableAdapter
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
    Private WithEvents xrLine1 As DevExpress.XtraReports.UI.XRLine
    Private WithEvents dsPortfolioManagement2 As dsPortfolioManagement
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
    Private WithEvents xrLine13 As DevExpress.XtraReports.UI.XRLine
    Private WithEvents xrLine12 As DevExpress.XtraReports.UI.XRLine
    Private WithEvents xrLine11 As DevExpress.XtraReports.UI.XRLine
    Private WithEvents xrLine10 As DevExpress.XtraReports.UI.XRLine
    Private WithEvents xrLine9 As DevExpress.XtraReports.UI.XRLine
    Private WithEvents xrLine8 As DevExpress.XtraReports.UI.XRLine
    Private WithEvents xrLine7 As DevExpress.XtraReports.UI.XRLine
    Private WithEvents xrLine6 As DevExpress.XtraReports.UI.XRLine
    Private WithEvents xrLine5 As DevExpress.XtraReports.UI.XRLine
    Private WithEvents fromDate As DevExpress.XtraReports.Parameters.Parameter
    Private WithEvents toDate As DevExpress.XtraReports.Parameters.Parameter
    Private WithEvents xrLabel20 As DevExpress.XtraReports.UI.XRLabel

    'Required by the Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Designer
    'It can be modified using the Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resourceFileName As String = "xrptPortfolioActivity.resx"
        Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
        Me.xrLine13 = New DevExpress.XtraReports.UI.XRLine()
        Me.xrLine12 = New DevExpress.XtraReports.UI.XRLine()
        Me.xrLine11 = New DevExpress.XtraReports.UI.XRLine()
        Me.xrLine10 = New DevExpress.XtraReports.UI.XRLine()
        Me.xrLine9 = New DevExpress.XtraReports.UI.XRLine()
        Me.xrLine8 = New DevExpress.XtraReports.UI.XRLine()
        Me.xrLine7 = New DevExpress.XtraReports.UI.XRLine()
        Me.xrLine6 = New DevExpress.XtraReports.UI.XRLine()
        Me.xrLine5 = New DevExpress.XtraReports.UI.XRLine()
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
        Me.xrLine1 = New DevExpress.XtraReports.UI.XRLine()
        Me.dsPortfolioManagement1 = New dsPortfolioManagement()
        Me.portfolioActivityTableAdapter1 = New dsPortfolioManagementTableAdapters.PortfolioActivityTableAdapter()
        Me.dsPortfolioManagement2 = New dsPortfolioManagement()
        Me.pageFooterBand1 = New DevExpress.XtraReports.UI.PageFooterBand()
        Me.xrPageInfo1 = New DevExpress.XtraReports.UI.XRPageInfo()
        Me.xrPageInfo2 = New DevExpress.XtraReports.UI.XRPageInfo()
        Me.reportHeaderBand1 = New DevExpress.XtraReports.UI.ReportHeaderBand()
        Me.xrLabel20 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel19 = New DevExpress.XtraReports.UI.XRLabel()
        Me.Title = New DevExpress.XtraReports.UI.XRControlStyle()
        Me.FieldCaption = New DevExpress.XtraReports.UI.XRControlStyle()
        Me.PageInfo = New DevExpress.XtraReports.UI.XRControlStyle()
        Me.DataField = New DevExpress.XtraReports.UI.XRControlStyle()
        Me.topMarginBand1 = New DevExpress.XtraReports.UI.TopMarginBand()
        Me.bottomMarginBand1 = New DevExpress.XtraReports.UI.BottomMarginBand()
        Me.fromDate = New DevExpress.XtraReports.Parameters.Parameter()
        Me.toDate = New DevExpress.XtraReports.Parameters.Parameter()
        CType(Me.dsPortfolioManagement1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dsPortfolioManagement2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.xrLine13, Me.xrLine12, Me.xrLine11, Me.xrLine10, Me.xrLine9, Me.xrLine8, Me.xrLine7, Me.xrLine6, Me.xrLine5, Me.xrLabel1, Me.xrLabel2, Me.xrLabel3, Me.xrLabel4, Me.xrLabel5, Me.xrLabel6, Me.xrLabel7, Me.xrLabel8, Me.xrLabel9, Me.xrLabel10, Me.xrLabel11, Me.xrLabel12, Me.xrLabel13, Me.xrLabel14, Me.xrLabel15, Me.xrLabel16, Me.xrLabel17, Me.xrLabel18, Me.xrLine1})
        Me.Detail.HeightF = 229.2084!
        Me.Detail.Name = "Detail"
        Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'xrLine13
        '
        Me.xrLine13.LocationFloat = New DevExpress.Utils.PointFloat(7.916609!, 220.0!)
        Me.xrLine13.Name = "xrLine13"
        Me.xrLine13.SizeF = New System.Drawing.SizeF(634.0834!, 2.0!)
        '
        'xrLine12
        '
        Me.xrLine12.LocationFloat = New DevExpress.Utils.PointFloat(7.916705!, 195.0!)
        Me.xrLine12.Name = "xrLine12"
        Me.xrLine12.SizeF = New System.Drawing.SizeF(634.0834!, 2.0!)
        '
        'xrLine11
        '
        Me.xrLine11.LocationFloat = New DevExpress.Utils.PointFloat(7.916705!, 171.0!)
        Me.xrLine11.Name = "xrLine11"
        Me.xrLine11.SizeF = New System.Drawing.SizeF(634.0834!, 2.0!)
        '
        'xrLine10
        '
        Me.xrLine10.LocationFloat = New DevExpress.Utils.PointFloat(7.916705!, 147.0!)
        Me.xrLine10.Name = "xrLine10"
        Me.xrLine10.SizeF = New System.Drawing.SizeF(634.0834!, 2.0!)
        '
        'xrLine9
        '
        Me.xrLine9.LocationFloat = New DevExpress.Utils.PointFloat(7.916705!, 123.0!)
        Me.xrLine9.Name = "xrLine9"
        Me.xrLine9.SizeF = New System.Drawing.SizeF(634.0834!, 2.0!)
        '
        'xrLine8
        '
        Me.xrLine8.LocationFloat = New DevExpress.Utils.PointFloat(7.916626!, 103.0!)
        Me.xrLine8.Name = "xrLine8"
        Me.xrLine8.SizeF = New System.Drawing.SizeF(634.0834!, 2.0!)
        '
        'xrLine7
        '
        Me.xrLine7.LocationFloat = New DevExpress.Utils.PointFloat(7.916705!, 75.0!)
        Me.xrLine7.Name = "xrLine7"
        Me.xrLine7.SizeF = New System.Drawing.SizeF(634.0834!, 2.083336!)
        '
        'xrLine6
        '
        Me.xrLine6.LocationFloat = New DevExpress.Utils.PointFloat(7.916626!, 50.99999!)
        Me.xrLine6.Name = "xrLine6"
        Me.xrLine6.SizeF = New System.Drawing.SizeF(634.0834!, 2.0!)
        '
        'xrLine5
        '
        Me.xrLine5.LocationFloat = New DevExpress.Utils.PointFloat(7.916657!, 27.00001!)
        Me.xrLine5.Name = "xrLine5"
        Me.xrLine5.SizeF = New System.Drawing.SizeF(634.0834!, 2.0!)
        '
        'xrLabel1
        '
        Me.xrLabel1.LocationFloat = New DevExpress.Utils.PointFloat(21.45834!, 9.000015!)
        Me.xrLabel1.Name = "xrLabel1"
        Me.xrLabel1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel1.SizeF = New System.Drawing.SizeF(404.0!, 18.0!)
        Me.xrLabel1.StyleName = "FieldCaption"
        Me.xrLabel1.Text = "Value of Loans Disbursed"
        '
        'xrLabel2
        '
        Me.xrLabel2.LocationFloat = New DevExpress.Utils.PointFloat(21.45834!, 32.99999!)
        Me.xrLabel2.Name = "xrLabel2"
        Me.xrLabel2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel2.SizeF = New System.Drawing.SizeF(404.0!, 18.0!)
        Me.xrLabel2.StyleName = "FieldCaption"
        Me.xrLabel2.Text = "Number of Loans Disbursed"
        '
        'xrLabel3
        '
        Me.xrLabel3.LocationFloat = New DevExpress.Utils.PointFloat(21.45834!, 57.0!)
        Me.xrLabel3.Name = "xrLabel3"
        Me.xrLabel3.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel3.SizeF = New System.Drawing.SizeF(404.0!, 18.0!)
        Me.xrLabel3.StyleName = "FieldCaption"
        Me.xrLabel3.Text = "Number of Clients Taking First Loan"
        '
        'xrLabel4
        '
        Me.xrLabel4.LocationFloat = New DevExpress.Utils.PointFloat(21.45834!, 81.00001!)
        Me.xrLabel4.Name = "xrLabel4"
        Me.xrLabel4.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel4.SizeF = New System.Drawing.SizeF(404.0!, 18.0!)
        Me.xrLabel4.StyleName = "FieldCaption"
        Me.xrLabel4.Text = "Number of Clients Taking Second and Subsequent Loan"
        '
        'xrLabel5
        '
        Me.xrLabel5.LocationFloat = New DevExpress.Utils.PointFloat(21.45834!, 105.0!)
        Me.xrLabel5.Name = "xrLabel5"
        Me.xrLabel5.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel5.SizeF = New System.Drawing.SizeF(404.0!, 18.0!)
        Me.xrLabel5.StyleName = "FieldCaption"
        Me.xrLabel5.Text = "Number of Active Clients At Start"
        '
        'xrLabel6
        '
        Me.xrLabel6.LocationFloat = New DevExpress.Utils.PointFloat(21.45834!, 129.0!)
        Me.xrLabel6.Name = "xrLabel6"
        Me.xrLabel6.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel6.SizeF = New System.Drawing.SizeF(404.0!, 18.0!)
        Me.xrLabel6.StyleName = "FieldCaption"
        Me.xrLabel6.Text = "Number of Active Clients At End"
        '
        'xrLabel7
        '
        Me.xrLabel7.LocationFloat = New DevExpress.Utils.PointFloat(21.45834!, 153.0!)
        Me.xrLabel7.Name = "xrLabel7"
        Me.xrLabel7.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel7.SizeF = New System.Drawing.SizeF(404.0!, 18.0!)
        Me.xrLabel7.StyleName = "FieldCaption"
        Me.xrLabel7.Text = "Number of Outstanding Loans"
        '
        'xrLabel8
        '
        Me.xrLabel8.LocationFloat = New DevExpress.Utils.PointFloat(21.45834!, 177.0!)
        Me.xrLabel8.Name = "xrLabel8"
        Me.xrLabel8.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel8.SizeF = New System.Drawing.SizeF(404.0!, 18.0!)
        Me.xrLabel8.StyleName = "FieldCaption"
        Me.xrLabel8.Text = "Average Loan Term"
        '
        'xrLabel9
        '
        Me.xrLabel9.LocationFloat = New DevExpress.Utils.PointFloat(21.45834!, 201.0!)
        Me.xrLabel9.Name = "xrLabel9"
        Me.xrLabel9.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel9.SizeF = New System.Drawing.SizeF(404.0!, 17.99998!)
        Me.xrLabel9.StyleName = "FieldCaption"
        Me.xrLabel9.Text = "Total Number of Clients"
        '
        'xrLabel10
        '
        Me.xrLabel10.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "PortfolioActivity.ValueLoansDisbursed", "{0:n2}")})
        Me.xrLabel10.LocationFloat = New DevExpress.Utils.PointFloat(450.7917!, 9.000015!)
        Me.xrLabel10.Name = "xrLabel10"
        Me.xrLabel10.NullValueText = "0"
        Me.xrLabel10.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel10.SizeF = New System.Drawing.SizeF(178.7917!, 18.0!)
        Me.xrLabel10.StyleName = "DataField"
        Me.xrLabel10.StylePriority.UseTextAlignment = False
        Me.xrLabel10.Text = "xrLabel10"
        Me.xrLabel10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'xrLabel11
        '
        Me.xrLabel11.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "PortfolioActivity.NoLoansDisbursed", "{0:#,#}")})
        Me.xrLabel11.LocationFloat = New DevExpress.Utils.PointFloat(450.7917!, 32.99999!)
        Me.xrLabel11.Name = "xrLabel11"
        Me.xrLabel11.NullValueText = "0"
        Me.xrLabel11.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel11.SizeF = New System.Drawing.SizeF(178.7917!, 18.0!)
        Me.xrLabel11.StyleName = "DataField"
        Me.xrLabel11.StylePriority.UseTextAlignment = False
        Me.xrLabel11.Text = "xrLabel11"
        Me.xrLabel11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'xrLabel12
        '
        Me.xrLabel12.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "PortfolioActivity.NoClients1stLoan", "{0:#,#}")})
        Me.xrLabel12.LocationFloat = New DevExpress.Utils.PointFloat(450.7917!, 57.0!)
        Me.xrLabel12.Name = "xrLabel12"
        Me.xrLabel12.NullValueText = "0"
        Me.xrLabel12.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel12.SizeF = New System.Drawing.SizeF(178.7917!, 18.0!)
        Me.xrLabel12.StyleName = "DataField"
        Me.xrLabel12.StylePriority.UseTextAlignment = False
        Me.xrLabel12.Text = "xrLabel12"
        Me.xrLabel12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'xrLabel13
        '
        Me.xrLabel13.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "PortfolioActivity.NoClients2ndLoan", "{0:#,#}")})
        Me.xrLabel13.LocationFloat = New DevExpress.Utils.PointFloat(450.7917!, 81.00001!)
        Me.xrLabel13.Name = "xrLabel13"
        Me.xrLabel13.NullValueText = "0"
        Me.xrLabel13.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel13.SizeF = New System.Drawing.SizeF(178.7917!, 18.0!)
        Me.xrLabel13.StyleName = "DataField"
        Me.xrLabel13.StylePriority.UseTextAlignment = False
        Me.xrLabel13.Text = "xrLabel13"
        Me.xrLabel13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'xrLabel14
        '
        Me.xrLabel14.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "PortfolioActivity.NoActiveClientsAtStart", "{0:#,#}")})
        Me.xrLabel14.LocationFloat = New DevExpress.Utils.PointFloat(450.7917!, 105.0!)
        Me.xrLabel14.Name = "xrLabel14"
        Me.xrLabel14.NullValueText = "0"
        Me.xrLabel14.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel14.SizeF = New System.Drawing.SizeF(178.7917!, 18.0!)
        Me.xrLabel14.StyleName = "DataField"
        Me.xrLabel14.StylePriority.UseTextAlignment = False
        Me.xrLabel14.Text = "xrLabel14"
        Me.xrLabel14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'xrLabel15
        '
        Me.xrLabel15.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "PortfolioActivity.NoActiveClientsAtEnd", "{0:#,#}")})
        Me.xrLabel15.LocationFloat = New DevExpress.Utils.PointFloat(450.7917!, 129.0!)
        Me.xrLabel15.Name = "xrLabel15"
        Me.xrLabel15.NullValueText = "0"
        Me.xrLabel15.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel15.SizeF = New System.Drawing.SizeF(178.7917!, 18.0!)
        Me.xrLabel15.StyleName = "DataField"
        Me.xrLabel15.StylePriority.UseTextAlignment = False
        Me.xrLabel15.Text = "xrLabel15"
        Me.xrLabel15.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'xrLabel16
        '
        Me.xrLabel16.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "PortfolioActivity.NoOutstandingLoans", "{0:#,#}")})
        Me.xrLabel16.LocationFloat = New DevExpress.Utils.PointFloat(450.7917!, 153.0!)
        Me.xrLabel16.Name = "xrLabel16"
        Me.xrLabel16.NullValueText = "0"
        Me.xrLabel16.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel16.SizeF = New System.Drawing.SizeF(178.7917!, 18.0!)
        Me.xrLabel16.StyleName = "DataField"
        Me.xrLabel16.StylePriority.UseTextAlignment = False
        Me.xrLabel16.Text = "xrLabel16"
        Me.xrLabel16.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'xrLabel17
        '
        Me.xrLabel17.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "PortfolioActivity.AvgLoanTerm", "{0:n2}")})
        Me.xrLabel17.LocationFloat = New DevExpress.Utils.PointFloat(450.7917!, 177.0!)
        Me.xrLabel17.Name = "xrLabel17"
        Me.xrLabel17.NullValueText = "0"
        Me.xrLabel17.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel17.SizeF = New System.Drawing.SizeF(178.7917!, 18.0!)
        Me.xrLabel17.StyleName = "DataField"
        Me.xrLabel17.StylePriority.UseTextAlignment = False
        Me.xrLabel17.Text = "xrLabel17"
        Me.xrLabel17.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'xrLabel18
        '
        Me.xrLabel18.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "PortfolioActivity.TotNoClients", "{0:#,#}")})
        Me.xrLabel18.LocationFloat = New DevExpress.Utils.PointFloat(450.7917!, 201.0!)
        Me.xrLabel18.Name = "xrLabel18"
        Me.xrLabel18.NullValueText = "0"
        Me.xrLabel18.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel18.SizeF = New System.Drawing.SizeF(178.7917!, 17.99998!)
        Me.xrLabel18.StyleName = "DataField"
        Me.xrLabel18.StylePriority.UseTextAlignment = False
        Me.xrLabel18.Text = "xrLabel18"
        Me.xrLabel18.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'xrLine1
        '
        Me.xrLine1.LocationFloat = New DevExpress.Utils.PointFloat(6.0!, 3.0!)
        Me.xrLine1.Name = "xrLine1"
        Me.xrLine1.SizeF = New System.Drawing.SizeF(638.0!, 2.0!)
        '
        'dsPortfolioManagement1
        '
        Me.dsPortfolioManagement1.DataSetName = "dsPortfolioManagement"
        Me.dsPortfolioManagement1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'portfolioActivityTableAdapter1
        '
        Me.portfolioActivityTableAdapter1.ClearBeforeFill = True
        '
        'dsPortfolioManagement2
        '
        Me.dsPortfolioManagement2.DataSetName = "dsPortfolioManagement"
        Me.dsPortfolioManagement2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
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
        Me.reportHeaderBand1.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.xrLabel20, Me.xrLabel19})
        Me.reportHeaderBand1.HeightF = 89.54166!
        Me.reportHeaderBand1.Name = "reportHeaderBand1"
        '
        'xrLabel20
        '
        Me.xrLabel20.Font = New System.Drawing.Font("Times New Roman", 10.0!, System.Drawing.FontStyle.Bold)
        Me.xrLabel20.LocationFloat = New DevExpress.Utils.PointFloat(21.45834!, 56.54166!)
        Me.xrLabel20.Name = "xrLabel20"
        Me.xrLabel20.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel20.SizeF = New System.Drawing.SizeF(371.875!, 23.0!)
        Me.xrLabel20.StylePriority.UseFont = False
        Me.xrLabel20.Text = "As at: [Parameters.toDate!dd MMM,yyyy]"
        '
        'xrLabel19
        '
        Me.xrLabel19.LocationFloat = New DevExpress.Utils.PointFloat(6.0!, 6.0!)
        Me.xrLabel19.Name = "xrLabel19"
        Me.xrLabel19.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel19.SizeF = New System.Drawing.SizeF(638.0!, 33.0!)
        Me.xrLabel19.StyleName = "Title"
        Me.xrLabel19.Text = "Portfolio Activity Report"
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
        'xrptPortfolioActivity
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.pageFooterBand1, Me.reportHeaderBand1, Me.topMarginBand1, Me.bottomMarginBand1})
        Me.DataAdapter = Me.portfolioActivityTableAdapter1
        Me.DataMember = "PortfolioActivity"
        Me.DataSource = Me.dsPortfolioManagement2
        Me.Parameters.AddRange(New DevExpress.XtraReports.Parameters.Parameter() {Me.fromDate, Me.toDate})
        Me.StyleSheet.AddRange(New DevExpress.XtraReports.UI.XRControlStyle() {Me.Title, Me.FieldCaption, Me.PageInfo, Me.DataField})
        Me.Version = "13.2"
        CType(Me.dsPortfolioManagement1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dsPortfolioManagement2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand

#End Region

    Private Sub xrptPortfolioActivity_DataSourceDemanded(sender As Object, e As EventArgs) Handles Me.DataSourceDemanded
        portfolioActivityTableAdapter1.FillByDateRange(dsPortfolioManagement2.PortfolioActivity, fromDate.Value, toDate.Value)
    End Sub
End Class