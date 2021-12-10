Public Class xrptAgingArrears
    Inherits DevExpress.XtraReports.UI.XtraReport

#Region " Designer generated code "

    Private WithEvents agingArrearsTableAdapter1 As dsAllReportsTableAdapters.AgingArrearsTableAdapter

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
    Private WithEvents xrTable2 As DevExpress.XtraReports.UI.XRTable
    Private WithEvents xrTableRow6 As DevExpress.XtraReports.UI.XRTableRow
    Private WithEvents xrTableCell14 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell16 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell18 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell20 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell26 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell28 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell30 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell32 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell34 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents dsAllReports1 As dsAllReports
    Private WithEvents newAgingArrearsTableAdapter1 As dsAllReportsTableAdapters.NewAgingArrearsTableAdapter
    Private WithEvents pageHeaderBand1 As DevExpress.XtraReports.UI.PageHeaderBand
    Private WithEvents xrTable1 As DevExpress.XtraReports.UI.XRTable
    Private WithEvents xrTableRow5 As DevExpress.XtraReports.UI.XRTableRow
    Private WithEvents xrTableCell13 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell15 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell17 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell19 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell25 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell27 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell29 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell31 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell33 As DevExpress.XtraReports.UI.XRTableCell
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
    Private WithEvents ReportFooter As DevExpress.XtraReports.UI.ReportFooterBand
    Private WithEvents xrTable3 As DevExpress.XtraReports.UI.XRTable
    Private WithEvents xrTableRow7 As DevExpress.XtraReports.UI.XRTableRow
    Private WithEvents xrTableCell39 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell41 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell42 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell43 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell44 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell45 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell22 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell23 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell21 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents onePerc As DevExpress.XtraReports.UI.CalculatedField
    Private WithEvents xrTable4 As DevExpress.XtraReports.UI.XRTable
    Private WithEvents xrTableRow8 As DevExpress.XtraReports.UI.XRTableRow
    Private WithEvents xrTableCell24 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell35 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell36 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell37 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell38 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell40 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell46 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents thirtyPerc As DevExpress.XtraReports.UI.CalculatedField
    Private WithEvents sixtyPerc As DevExpress.XtraReports.UI.CalculatedField
    Private WithEvents nintyPerc As DevExpress.XtraReports.UI.CalculatedField
    Private WithEvents oneEightPerc As DevExpress.XtraReports.UI.CalculatedField
    Private WithEvents dsStaticDetails1 As dsStaticDetails
    Private WithEvents masterUsersTableAdapter1 As dsStaticDetailsTableAdapters.MasterUsersTableAdapter
    Private WithEvents branchesTableAdapter1 As dsAllReportsTableAdapters.BranchesTableAdapter
    Private WithEvents loanPurposeTableAdapter1 As dsStaticDetailsTableAdapters.LoanPurposeTableAdapter
    Private WithEvents filterOption As DevExpress.XtraReports.Parameters.Parameter
    Private WithEvents loanOfficer As DevExpress.XtraReports.Parameters.Parameter
    Private WithEvents brnch As DevExpress.XtraReports.Parameters.Parameter
    Private WithEvents purp As DevExpress.XtraReports.Parameters.Parameter

    'Required by the Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Designer
    'It can be modified using the Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resourceFileName As String = "xrptAgingArrears.resx"
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
        Dim dynamicListLookUpSettings1 As DevExpress.XtraReports.Parameters.DynamicListLookUpSettings = New DevExpress.XtraReports.Parameters.DynamicListLookUpSettings()
        Dim dynamicListLookUpSettings2 As DevExpress.XtraReports.Parameters.DynamicListLookUpSettings = New DevExpress.XtraReports.Parameters.DynamicListLookUpSettings()
        Dim dynamicListLookUpSettings3 As DevExpress.XtraReports.Parameters.DynamicListLookUpSettings = New DevExpress.XtraReports.Parameters.DynamicListLookUpSettings()
        Dim staticListLookUpSettings1 As DevExpress.XtraReports.Parameters.StaticListLookUpSettings = New DevExpress.XtraReports.Parameters.StaticListLookUpSettings()
        Me.masterUsersTableAdapter1 = New dsStaticDetailsTableAdapters.MasterUsersTableAdapter()
        Me.dsStaticDetails1 = New dsStaticDetails()
        Me.branchesTableAdapter1 = New dsAllReportsTableAdapters.BranchesTableAdapter()
        Me.loanPurposeTableAdapter1 = New dsStaticDetailsTableAdapters.LoanPurposeTableAdapter()
        Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
        Me.xrTable2 = New DevExpress.XtraReports.UI.XRTable()
        Me.xrTableRow6 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.xrTableCell14 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell16 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell18 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell20 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell26 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell28 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell30 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell32 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell34 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell22 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.agingArrearsTableAdapter1 = New dsAllReportsTableAdapters.AgingArrearsTableAdapter()
        Me.xrTableRow1 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.xrTableCell1 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell2 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell3 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableRow2 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.xrTableCell4 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell5 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell6 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.dsAllReports1 = New dsAllReports()
        Me.newAgingArrearsTableAdapter1 = New dsAllReportsTableAdapters.NewAgingArrearsTableAdapter()
        Me.pageHeaderBand1 = New DevExpress.XtraReports.UI.PageHeaderBand()
        Me.xrTable1 = New DevExpress.XtraReports.UI.XRTable()
        Me.xrTableRow5 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.xrTableCell13 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell15 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell17 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell19 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell25 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell27 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell29 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell31 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell33 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell23 = New DevExpress.XtraReports.UI.XRTableCell()
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
        Me.xrLabel1 = New DevExpress.XtraReports.UI.XRLabel()
        Me.Title = New DevExpress.XtraReports.UI.XRControlStyle()
        Me.FieldCaption = New DevExpress.XtraReports.UI.XRControlStyle()
        Me.PageInfo = New DevExpress.XtraReports.UI.XRControlStyle()
        Me.DataField = New DevExpress.XtraReports.UI.XRControlStyle()
        Me.topMarginBand1 = New DevExpress.XtraReports.UI.TopMarginBand()
        Me.bottomMarginBand1 = New DevExpress.XtraReports.UI.BottomMarginBand()
        Me.ReportFooter = New DevExpress.XtraReports.UI.ReportFooterBand()
        Me.xrTable4 = New DevExpress.XtraReports.UI.XRTable()
        Me.xrTableRow8 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.xrTableCell24 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell35 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell36 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell37 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell38 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell40 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell46 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTable3 = New DevExpress.XtraReports.UI.XRTable()
        Me.xrTableRow7 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.xrTableCell39 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell41 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell42 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell43 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell44 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell45 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell21 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.onePerc = New DevExpress.XtraReports.UI.CalculatedField()
        Me.thirtyPerc = New DevExpress.XtraReports.UI.CalculatedField()
        Me.sixtyPerc = New DevExpress.XtraReports.UI.CalculatedField()
        Me.nintyPerc = New DevExpress.XtraReports.UI.CalculatedField()
        Me.oneEightPerc = New DevExpress.XtraReports.UI.CalculatedField()
        Me.loanOfficer = New DevExpress.XtraReports.Parameters.Parameter()
        Me.brnch = New DevExpress.XtraReports.Parameters.Parameter()
        Me.purp = New DevExpress.XtraReports.Parameters.Parameter()
        Me.filterOption = New DevExpress.XtraReports.Parameters.Parameter()
        CType(Me.dsStaticDetails1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.xrTable2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dsAllReports1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.xrTable1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.xrTable4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.xrTable3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'masterUsersTableAdapter1
        '
        Me.masterUsersTableAdapter1.ClearBeforeFill = True
        '
        'dsStaticDetails1
        '
        Me.dsStaticDetails1.DataSetName = "dsStaticDetails"
        Me.dsStaticDetails1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'branchesTableAdapter1
        '
        Me.branchesTableAdapter1.ClearBeforeFill = True
        '
        'loanPurposeTableAdapter1
        '
        Me.loanPurposeTableAdapter1.ClearBeforeFill = True
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.xrTable2})
        Me.Detail.HeightF = 38.0!
        Me.Detail.Name = "Detail"
        Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'xrTable2
        '
        Me.xrTable2.AnchorVertical = CType((DevExpress.XtraReports.UI.VerticalAnchorStyles.Top Or DevExpress.XtraReports.UI.VerticalAnchorStyles.Bottom), DevExpress.XtraReports.UI.VerticalAnchorStyles)
        Me.xrTable2.LocationFloat = New DevExpress.Utils.PointFloat(5.000003!, 0!)
        Me.xrTable2.Name = "xrTable2"
        Me.xrTable2.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.xrTableRow6})
        Me.xrTable2.SizeF = New System.Drawing.SizeF(1095.0!, 38.0!)
        '
        'xrTableRow6
        '
        Me.xrTableRow6.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.xrTableCell14, Me.xrTableCell16, Me.xrTableCell18, Me.xrTableCell20, Me.xrTableCell26, Me.xrTableCell28, Me.xrTableCell30, Me.xrTableCell32, Me.xrTableCell34, Me.xrTableCell22})
        Me.xrTableRow6.Name = "xrTableRow6"
        Me.xrTableRow6.Weight = 1.0R
        '
        'xrTableCell14
        '
        Me.xrTableCell14.CanGrow = False
        Me.xrTableCell14.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "NewAgingArrears.CUSTOMER_NUMBER")})
        Me.xrTableCell14.Name = "xrTableCell14"
        Me.xrTableCell14.StyleName = "DataField"
        Me.xrTableCell14.Text = "xrTableCell14"
        Me.xrTableCell14.Weight = 16.3792366679186R
        '
        'xrTableCell16
        '
        Me.xrTableCell16.CanGrow = False
        Me.xrTableCell16.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "NewAgingArrears.Name")})
        Me.xrTableCell16.Name = "xrTableCell16"
        Me.xrTableCell16.StyleName = "DataField"
        Me.xrTableCell16.Text = "xrTableCell16"
        Me.xrTableCell16.Weight = 27.104894129208049R
        '
        'xrTableCell18
        '
        Me.xrTableCell18.CanGrow = False
        Me.xrTableCell18.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "NewAgingArrears.IDNO")})
        Me.xrTableCell18.Name = "xrTableCell18"
        Me.xrTableCell18.StyleName = "DataField"
        Me.xrTableCell18.Text = "xrTableCell18"
        Me.xrTableCell18.Weight = 18.918035272112647R
        '
        'xrTableCell20
        '
        Me.xrTableCell20.CanGrow = False
        Me.xrTableCell20.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "NewAgingArrears.Address")})
        Me.xrTableCell20.Name = "xrTableCell20"
        Me.xrTableCell20.StyleName = "DataField"
        Me.xrTableCell20.Text = "xrTableCell20"
        Me.xrTableCell20.Weight = 31.518551046937151R
        '
        'xrTableCell26
        '
        Me.xrTableCell26.CanGrow = False
        Me.xrTableCell26.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "NewAgingArrears.1-30Days", "{0:n2}")})
        Me.xrTableCell26.Name = "xrTableCell26"
        Me.xrTableCell26.StyleName = "DataField"
        Me.xrTableCell26.StylePriority.UseTextAlignment = False
        Me.xrTableCell26.Text = "xrTableCell26"
        Me.xrTableCell26.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        Me.xrTableCell26.Weight = 14.383968561412839R
        '
        'xrTableCell28
        '
        Me.xrTableCell28.CanGrow = False
        Me.xrTableCell28.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "NewAgingArrears.31-60Days", "{0:n2}")})
        Me.xrTableCell28.Name = "xrTableCell28"
        Me.xrTableCell28.StyleName = "DataField"
        Me.xrTableCell28.StylePriority.UseTextAlignment = False
        Me.xrTableCell28.Text = "xrTableCell28"
        Me.xrTableCell28.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        Me.xrTableCell28.Weight = 14.706155254703326R
        '
        'xrTableCell30
        '
        Me.xrTableCell30.CanGrow = False
        Me.xrTableCell30.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "NewAgingArrears.61-90Days", "{0:n2}")})
        Me.xrTableCell30.Name = "xrTableCell30"
        Me.xrTableCell30.StyleName = "DataField"
        Me.xrTableCell30.StylePriority.UseTextAlignment = False
        Me.xrTableCell30.Text = "xrTableCell30"
        Me.xrTableCell30.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        Me.xrTableCell30.Weight = 13.768517895493796R
        '
        'xrTableCell32
        '
        Me.xrTableCell32.CanGrow = False
        Me.xrTableCell32.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "NewAgingArrears.91-180Days", "{0:n2}")})
        Me.xrTableCell32.Name = "xrTableCell32"
        Me.xrTableCell32.StyleName = "DataField"
        Me.xrTableCell32.StylePriority.UseTextAlignment = False
        Me.xrTableCell32.Text = "xrTableCell32"
        Me.xrTableCell32.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        Me.xrTableCell32.Weight = 14.503233108184606R
        '
        'xrTableCell34
        '
        Me.xrTableCell34.CanGrow = False
        Me.xrTableCell34.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "NewAgingArrears.>180Days", "{0:n2}")})
        Me.xrTableCell34.Name = "xrTableCell34"
        Me.xrTableCell34.StyleName = "DataField"
        Me.xrTableCell34.StylePriority.UseTextAlignment = False
        Me.xrTableCell34.Text = "xrTableCell34"
        Me.xrTableCell34.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        Me.xrTableCell34.Weight = 12.85870649850369R
        '
        'xrTableCell22
        '
        Me.xrTableCell22.CanGrow = False
        Me.xrTableCell22.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "NewAgingArrears.ArrearBalance", "{0:n2}")})
        Me.xrTableCell22.Name = "xrTableCell22"
        Me.xrTableCell22.StylePriority.UseTextAlignment = False
        Me.xrTableCell22.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        Me.xrTableCell22.Weight = 12.858701565525308R
        '
        'agingArrearsTableAdapter1
        '
        Me.agingArrearsTableAdapter1.ClearBeforeFill = True
        '
        'xrTableRow1
        '
        Me.xrTableRow1.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.xrTableCell1, Me.xrTableCell2, Me.xrTableCell3})
        Me.xrTableRow1.Name = "xrTableRow1"
        Me.xrTableRow1.Weight = 1.0R
        '
        'xrTableCell1
        '
        Me.xrTableCell1.Name = "xrTableCell1"
        Me.xrTableCell1.Weight = 1.0R
        '
        'xrTableCell2
        '
        Me.xrTableCell2.Name = "xrTableCell2"
        Me.xrTableCell2.Weight = 1.0R
        '
        'xrTableCell3
        '
        Me.xrTableCell3.Name = "xrTableCell3"
        Me.xrTableCell3.Weight = 1.0R
        '
        'xrTableRow2
        '
        Me.xrTableRow2.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.xrTableCell4, Me.xrTableCell5, Me.xrTableCell6})
        Me.xrTableRow2.Name = "xrTableRow2"
        Me.xrTableRow2.Weight = 1.0R
        '
        'xrTableCell4
        '
        Me.xrTableCell4.Name = "xrTableCell4"
        Me.xrTableCell4.Weight = 1.0R
        '
        'xrTableCell5
        '
        Me.xrTableCell5.Name = "xrTableCell5"
        Me.xrTableCell5.Weight = 1.0R
        '
        'xrTableCell6
        '
        Me.xrTableCell6.Name = "xrTableCell6"
        Me.xrTableCell6.Weight = 1.0R
        '
        'dsAllReports1
        '
        Me.dsAllReports1.DataSetName = "dsAllReports"
        Me.dsAllReports1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'newAgingArrearsTableAdapter1
        '
        Me.newAgingArrearsTableAdapter1.ClearBeforeFill = True
        '
        'pageHeaderBand1
        '
        Me.pageHeaderBand1.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.xrTable1})
        Me.pageHeaderBand1.HeightF = 41.0!
        Me.pageHeaderBand1.Name = "pageHeaderBand1"
        '
        'xrTable1
        '
        Me.xrTable1.AnchorVertical = DevExpress.XtraReports.UI.VerticalAnchorStyles.Bottom
        Me.xrTable1.LocationFloat = New DevExpress.Utils.PointFloat(5.000003!, 4.999987!)
        Me.xrTable1.Name = "xrTable1"
        Me.xrTable1.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.xrTableRow5})
        Me.xrTable1.SizeF = New System.Drawing.SizeF(1095.0!, 36.0!)
        '
        'xrTableRow5
        '
        Me.xrTableRow5.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.xrTableCell13, Me.xrTableCell15, Me.xrTableCell17, Me.xrTableCell19, Me.xrTableCell25, Me.xrTableCell27, Me.xrTableCell29, Me.xrTableCell31, Me.xrTableCell33, Me.xrTableCell23})
        Me.xrTableRow5.Name = "xrTableRow5"
        Me.xrTableRow5.Weight = 1.0R
        '
        'xrTableCell13
        '
        Me.xrTableCell13.CanGrow = False
        Me.xrTableCell13.Name = "xrTableCell13"
        Me.xrTableCell13.StyleName = "FieldCaption"
        Me.xrTableCell13.Text = "Account No"
        Me.xrTableCell13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        Me.xrTableCell13.Weight = 16.3792366679186R
        '
        'xrTableCell15
        '
        Me.xrTableCell15.CanGrow = False
        Me.xrTableCell15.Name = "xrTableCell15"
        Me.xrTableCell15.StyleName = "FieldCaption"
        Me.xrTableCell15.Text = "Name"
        Me.xrTableCell15.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        Me.xrTableCell15.Weight = 27.104894129208049R
        '
        'xrTableCell17
        '
        Me.xrTableCell17.CanGrow = False
        Me.xrTableCell17.Name = "xrTableCell17"
        Me.xrTableCell17.StyleName = "FieldCaption"
        Me.xrTableCell17.Text = "ID Number"
        Me.xrTableCell17.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        Me.xrTableCell17.Weight = 18.918035272112647R
        '
        'xrTableCell19
        '
        Me.xrTableCell19.CanGrow = False
        Me.xrTableCell19.Name = "xrTableCell19"
        Me.xrTableCell19.StyleName = "FieldCaption"
        Me.xrTableCell19.Text = "Address"
        Me.xrTableCell19.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        Me.xrTableCell19.Weight = 31.518551046937151R
        '
        'xrTableCell25
        '
        Me.xrTableCell25.CanGrow = False
        Me.xrTableCell25.Name = "xrTableCell25"
        Me.xrTableCell25.StyleName = "FieldCaption"
        Me.xrTableCell25.StylePriority.UseTextAlignment = False
        Me.xrTableCell25.Text = "1-30Days"
        Me.xrTableCell25.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.xrTableCell25.Weight = 14.383968561412839R
        '
        'xrTableCell27
        '
        Me.xrTableCell27.CanGrow = False
        Me.xrTableCell27.Name = "xrTableCell27"
        Me.xrTableCell27.StyleName = "FieldCaption"
        Me.xrTableCell27.StylePriority.UseTextAlignment = False
        Me.xrTableCell27.Text = "31-60Days"
        Me.xrTableCell27.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.xrTableCell27.Weight = 14.706155254703326R
        '
        'xrTableCell29
        '
        Me.xrTableCell29.CanGrow = False
        Me.xrTableCell29.Name = "xrTableCell29"
        Me.xrTableCell29.StyleName = "FieldCaption"
        Me.xrTableCell29.StylePriority.UseTextAlignment = False
        Me.xrTableCell29.Text = "61-90Days"
        Me.xrTableCell29.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.xrTableCell29.Weight = 13.768517895493796R
        '
        'xrTableCell31
        '
        Me.xrTableCell31.CanGrow = False
        Me.xrTableCell31.Name = "xrTableCell31"
        Me.xrTableCell31.StyleName = "FieldCaption"
        Me.xrTableCell31.StylePriority.UseTextAlignment = False
        Me.xrTableCell31.Text = "91-180Days"
        Me.xrTableCell31.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.xrTableCell31.Weight = 14.503233108184606R
        '
        'xrTableCell33
        '
        Me.xrTableCell33.CanGrow = False
        Me.xrTableCell33.Name = "xrTableCell33"
        Me.xrTableCell33.StyleName = "FieldCaption"
        Me.xrTableCell33.StylePriority.UseTextAlignment = False
        Me.xrTableCell33.Text = ">180Days"
        Me.xrTableCell33.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.xrTableCell33.Weight = 12.85870649850369R
        '
        'xrTableCell23
        '
        Me.xrTableCell23.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
        Me.xrTableCell23.CanGrow = False
        Me.xrTableCell23.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.xrTableCell23.ForeColor = System.Drawing.Color.Maroon
        Me.xrTableCell23.Name = "xrTableCell23"
        Me.xrTableCell23.StylePriority.UseBorders = False
        Me.xrTableCell23.StylePriority.UseFont = False
        Me.xrTableCell23.StylePriority.UseForeColor = False
        Me.xrTableCell23.StylePriority.UseTextAlignment = False
        Me.xrTableCell23.Text = "Balance"
        Me.xrTableCell23.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.xrTableCell23.Weight = 12.858701565525308R
        '
        'xrTableRow3
        '
        Me.xrTableRow3.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.xrTableCell7, Me.xrTableCell8, Me.xrTableCell9})
        Me.xrTableRow3.Name = "xrTableRow3"
        Me.xrTableRow3.Weight = 1.0R
        '
        'xrTableCell7
        '
        Me.xrTableCell7.Name = "xrTableCell7"
        Me.xrTableCell7.Weight = 1.0R
        '
        'xrTableCell8
        '
        Me.xrTableCell8.Name = "xrTableCell8"
        Me.xrTableCell8.Weight = 1.0R
        '
        'xrTableCell9
        '
        Me.xrTableCell9.Name = "xrTableCell9"
        Me.xrTableCell9.Weight = 1.0R
        '
        'xrTableRow4
        '
        Me.xrTableRow4.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.xrTableCell10, Me.xrTableCell11, Me.xrTableCell12})
        Me.xrTableRow4.Name = "xrTableRow4"
        Me.xrTableRow4.Weight = 1.0R
        '
        'xrTableCell10
        '
        Me.xrTableCell10.Name = "xrTableCell10"
        Me.xrTableCell10.Weight = 1.0R
        '
        'xrTableCell11
        '
        Me.xrTableCell11.Name = "xrTableCell11"
        Me.xrTableCell11.Weight = 1.0R
        '
        'xrTableCell12
        '
        Me.xrTableCell12.Name = "xrTableCell12"
        Me.xrTableCell12.Weight = 1.0R
        '
        'pageFooterBand1
        '
        Me.pageFooterBand1.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.xrPageInfo1, Me.xrPageInfo2})
        Me.pageFooterBand1.HeightF = 28.0!
        Me.pageFooterBand1.Name = "pageFooterBand1"
        '
        'xrPageInfo1
        '
        Me.xrPageInfo1.LocationFloat = New DevExpress.Utils.PointFloat(5.0!, 5.0!)
        Me.xrPageInfo1.Name = "xrPageInfo1"
        Me.xrPageInfo1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrPageInfo1.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime
        Me.xrPageInfo1.SizeF = New System.Drawing.SizeF(440.0!, 23.0!)
        Me.xrPageInfo1.StyleName = "PageInfo"
        '
        'xrPageInfo2
        '
        Me.xrPageInfo2.Format = "Page {0} of {1}"
        Me.xrPageInfo2.LocationFloat = New DevExpress.Utils.PointFloat(455.0!, 4.999987!)
        Me.xrPageInfo2.Name = "xrPageInfo2"
        Me.xrPageInfo2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrPageInfo2.SizeF = New System.Drawing.SizeF(645.0!, 23.0!)
        Me.xrPageInfo2.StyleName = "PageInfo"
        Me.xrPageInfo2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'reportHeaderBand1
        '
        Me.reportHeaderBand1.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.xrLabel1})
        Me.reportHeaderBand1.HeightF = 92.16667!
        Me.reportHeaderBand1.Name = "reportHeaderBand1"
        '
        'xrLabel1
        '
        Me.xrLabel1.LocationFloat = New DevExpress.Utils.PointFloat(5.0!, 5.0!)
        Me.xrLabel1.Name = "xrLabel1"
        Me.xrLabel1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel1.SizeF = New System.Drawing.SizeF(1061.0!, 33.0!)
        Me.xrLabel1.StyleName = "Title"
        Me.xrLabel1.Text = "Aging Of Arrears Report"
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
        'ReportFooter
        '
        Me.ReportFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.xrTable4, Me.xrTable3})
        Me.ReportFooter.Name = "ReportFooter"
        '
        'xrTable4
        '
        Me.xrTable4.AnchorVertical = CType((DevExpress.XtraReports.UI.VerticalAnchorStyles.Top Or DevExpress.XtraReports.UI.VerticalAnchorStyles.Bottom), DevExpress.XtraReports.UI.VerticalAnchorStyles)
        Me.xrTable4.LocationFloat = New DevExpress.Utils.PointFloat(5.0!, 52.0!)
        Me.xrTable4.Name = "xrTable4"
        Me.xrTable4.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.xrTableRow8})
        Me.xrTable4.SizeF = New System.Drawing.SizeF(1095.0!, 38.0!)
        '
        'xrTableRow8
        '
        Me.xrTableRow8.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.xrTableCell24, Me.xrTableCell35, Me.xrTableCell36, Me.xrTableCell37, Me.xrTableCell38, Me.xrTableCell40, Me.xrTableCell46})
        Me.xrTableRow8.Name = "xrTableRow8"
        Me.xrTableRow8.Weight = 1.0R
        '
        'xrTableCell24
        '
        Me.xrTableCell24.Borders = DevExpress.XtraPrinting.BorderSide.Top
        Me.xrTableCell24.CanGrow = False
        Me.xrTableCell24.Font = New System.Drawing.Font("Times New Roman", 10.0!, System.Drawing.FontStyle.Bold)
        Me.xrTableCell24.Name = "xrTableCell24"
        Me.xrTableCell24.StyleName = "DataField"
        Me.xrTableCell24.StylePriority.UseBorders = False
        Me.xrTableCell24.StylePriority.UseFont = False
        Me.xrTableCell24.StylePriority.UseTextAlignment = False
        Me.xrTableCell24.Text = "Percentages"
        Me.xrTableCell24.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        Me.xrTableCell24.Weight = 93.9207277495693R
        '
        'xrTableCell35
        '
        Me.xrTableCell35.Borders = DevExpress.XtraPrinting.BorderSide.Top
        Me.xrTableCell35.CanGrow = False
        Me.xrTableCell35.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "NewAgingArrears.onePerc", "{0:n2}")})
        Me.xrTableCell35.Font = New System.Drawing.Font("Times New Roman", 10.0!, System.Drawing.FontStyle.Bold)
        Me.xrTableCell35.Name = "xrTableCell35"
        Me.xrTableCell35.StyleName = "DataField"
        Me.xrTableCell35.StylePriority.UseBorders = False
        Me.xrTableCell35.StylePriority.UseFont = False
        Me.xrTableCell35.StylePriority.UseTextAlignment = False
        xrSummary1.FormatString = "{0:n2}"
        xrSummary1.IgnoreNullValues = True
        Me.xrTableCell35.Summary = xrSummary1
        Me.xrTableCell35.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.xrTableCell35.Weight = 14.38395792802001R
        '
        'xrTableCell36
        '
        Me.xrTableCell36.Borders = DevExpress.XtraPrinting.BorderSide.Top
        Me.xrTableCell36.CanGrow = False
        Me.xrTableCell36.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "NewAgingArrears.thirtyPerc", "{0:n2}")})
        Me.xrTableCell36.Font = New System.Drawing.Font("Times New Roman", 10.0!, System.Drawing.FontStyle.Bold)
        Me.xrTableCell36.Name = "xrTableCell36"
        Me.xrTableCell36.StyleName = "DataField"
        Me.xrTableCell36.StylePriority.UseBorders = False
        Me.xrTableCell36.StylePriority.UseFont = False
        Me.xrTableCell36.StylePriority.UseTextAlignment = False
        xrSummary2.FormatString = "{0:n2}"
        xrSummary2.IgnoreNullValues = True
        Me.xrTableCell36.Summary = xrSummary2
        Me.xrTableCell36.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.xrTableCell36.Weight = 14.706155254703326R
        '
        'xrTableCell37
        '
        Me.xrTableCell37.Borders = DevExpress.XtraPrinting.BorderSide.Top
        Me.xrTableCell37.CanGrow = False
        Me.xrTableCell37.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "NewAgingArrears.sixtyPerc", "{0:n2}")})
        Me.xrTableCell37.Font = New System.Drawing.Font("Times New Roman", 10.0!, System.Drawing.FontStyle.Bold)
        Me.xrTableCell37.Name = "xrTableCell37"
        Me.xrTableCell37.StyleName = "DataField"
        Me.xrTableCell37.StylePriority.UseBorders = False
        Me.xrTableCell37.StylePriority.UseFont = False
        Me.xrTableCell37.StylePriority.UseTextAlignment = False
        xrSummary3.FormatString = "{0:n2}"
        xrSummary3.IgnoreNullValues = True
        Me.xrTableCell37.Summary = xrSummary3
        Me.xrTableCell37.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.xrTableCell37.Weight = 13.768517895493794R
        '
        'xrTableCell38
        '
        Me.xrTableCell38.Borders = DevExpress.XtraPrinting.BorderSide.Top
        Me.xrTableCell38.CanGrow = False
        Me.xrTableCell38.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "NewAgingArrears.nintyPerc", "{0:n2}")})
        Me.xrTableCell38.Font = New System.Drawing.Font("Times New Roman", 10.0!, System.Drawing.FontStyle.Bold)
        Me.xrTableCell38.Name = "xrTableCell38"
        Me.xrTableCell38.StyleName = "DataField"
        Me.xrTableCell38.StylePriority.UseBorders = False
        Me.xrTableCell38.StylePriority.UseFont = False
        Me.xrTableCell38.StylePriority.UseTextAlignment = False
        xrSummary4.FormatString = "{0:n2}"
        xrSummary4.IgnoreNullValues = True
        Me.xrTableCell38.Summary = xrSummary4
        Me.xrTableCell38.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.xrTableCell38.Weight = 14.503233108184604R
        '
        'xrTableCell40
        '
        Me.xrTableCell40.Borders = DevExpress.XtraPrinting.BorderSide.Top
        Me.xrTableCell40.CanGrow = False
        Me.xrTableCell40.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "NewAgingArrears.oneEightPerc", "{0:n2}")})
        Me.xrTableCell40.Font = New System.Drawing.Font("Times New Roman", 10.0!, System.Drawing.FontStyle.Bold)
        Me.xrTableCell40.Name = "xrTableCell40"
        Me.xrTableCell40.StyleName = "DataField"
        Me.xrTableCell40.StylePriority.UseBorders = False
        Me.xrTableCell40.StylePriority.UseFont = False
        Me.xrTableCell40.StylePriority.UseTextAlignment = False
        xrSummary5.FormatString = "{0:n2}"
        xrSummary5.IgnoreNullValues = True
        Me.xrTableCell40.Summary = xrSummary5
        Me.xrTableCell40.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.xrTableCell40.Weight = 12.858706498503691R
        '
        'xrTableCell46
        '
        Me.xrTableCell46.Borders = DevExpress.XtraPrinting.BorderSide.Top
        Me.xrTableCell46.CanGrow = False
        Me.xrTableCell46.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold)
        Me.xrTableCell46.Name = "xrTableCell46"
        Me.xrTableCell46.StylePriority.UseBorders = False
        Me.xrTableCell46.StylePriority.UseFont = False
        Me.xrTableCell46.StylePriority.UseTextAlignment = False
        xrSummary6.FormatString = "{0:n2}"
        xrSummary6.IgnoreNullValues = True
        Me.xrTableCell46.Summary = xrSummary6
        Me.xrTableCell46.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.xrTableCell46.Weight = 12.858701565525308R
        '
        'xrTable3
        '
        Me.xrTable3.AnchorVertical = CType((DevExpress.XtraReports.UI.VerticalAnchorStyles.Top Or DevExpress.XtraReports.UI.VerticalAnchorStyles.Bottom), DevExpress.XtraReports.UI.VerticalAnchorStyles)
        Me.xrTable3.LocationFloat = New DevExpress.Utils.PointFloat(5.000003!, 0!)
        Me.xrTable3.Name = "xrTable3"
        Me.xrTable3.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.xrTableRow7})
        Me.xrTable3.SizeF = New System.Drawing.SizeF(1095.0!, 38.0!)
        '
        'xrTableRow7
        '
        Me.xrTableRow7.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.xrTableCell39, Me.xrTableCell41, Me.xrTableCell42, Me.xrTableCell43, Me.xrTableCell44, Me.xrTableCell45, Me.xrTableCell21})
        Me.xrTableRow7.Name = "xrTableRow7"
        Me.xrTableRow7.Weight = 1.0R
        '
        'xrTableCell39
        '
        Me.xrTableCell39.Borders = DevExpress.XtraPrinting.BorderSide.Top
        Me.xrTableCell39.CanGrow = False
        Me.xrTableCell39.Font = New System.Drawing.Font("Times New Roman", 10.0!, System.Drawing.FontStyle.Bold)
        Me.xrTableCell39.Name = "xrTableCell39"
        Me.xrTableCell39.StyleName = "DataField"
        Me.xrTableCell39.StylePriority.UseBorders = False
        Me.xrTableCell39.StylePriority.UseFont = False
        Me.xrTableCell39.StylePriority.UseTextAlignment = False
        Me.xrTableCell39.Text = "Total"
        Me.xrTableCell39.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        Me.xrTableCell39.Weight = 93.9207277495693R
        '
        'xrTableCell41
        '
        Me.xrTableCell41.Borders = DevExpress.XtraPrinting.BorderSide.Top
        Me.xrTableCell41.CanGrow = False
        Me.xrTableCell41.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "NewAgingArrears.1-30Days")})
        Me.xrTableCell41.Font = New System.Drawing.Font("Times New Roman", 10.0!, System.Drawing.FontStyle.Bold)
        Me.xrTableCell41.Name = "xrTableCell41"
        Me.xrTableCell41.StyleName = "DataField"
        Me.xrTableCell41.StylePriority.UseBorders = False
        Me.xrTableCell41.StylePriority.UseFont = False
        Me.xrTableCell41.StylePriority.UseTextAlignment = False
        xrSummary7.FormatString = "{0:n2}"
        xrSummary7.IgnoreNullValues = True
        xrSummary7.Running = DevExpress.XtraReports.UI.SummaryRunning.Report
        Me.xrTableCell41.Summary = xrSummary7
        Me.xrTableCell41.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.xrTableCell41.Weight = 14.38395792802001R
        '
        'xrTableCell42
        '
        Me.xrTableCell42.Borders = DevExpress.XtraPrinting.BorderSide.Top
        Me.xrTableCell42.CanGrow = False
        Me.xrTableCell42.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "NewAgingArrears.31-60Days")})
        Me.xrTableCell42.Font = New System.Drawing.Font("Times New Roman", 10.0!, System.Drawing.FontStyle.Bold)
        Me.xrTableCell42.Name = "xrTableCell42"
        Me.xrTableCell42.StyleName = "DataField"
        Me.xrTableCell42.StylePriority.UseBorders = False
        Me.xrTableCell42.StylePriority.UseFont = False
        Me.xrTableCell42.StylePriority.UseTextAlignment = False
        xrSummary8.FormatString = "{0:n2}"
        xrSummary8.IgnoreNullValues = True
        xrSummary8.Running = DevExpress.XtraReports.UI.SummaryRunning.Report
        Me.xrTableCell42.Summary = xrSummary8
        Me.xrTableCell42.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.xrTableCell42.Weight = 14.706155254703326R
        '
        'xrTableCell43
        '
        Me.xrTableCell43.Borders = DevExpress.XtraPrinting.BorderSide.Top
        Me.xrTableCell43.CanGrow = False
        Me.xrTableCell43.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "NewAgingArrears.61-90Days")})
        Me.xrTableCell43.Font = New System.Drawing.Font("Times New Roman", 10.0!, System.Drawing.FontStyle.Bold)
        Me.xrTableCell43.Name = "xrTableCell43"
        Me.xrTableCell43.StyleName = "DataField"
        Me.xrTableCell43.StylePriority.UseBorders = False
        Me.xrTableCell43.StylePriority.UseFont = False
        Me.xrTableCell43.StylePriority.UseTextAlignment = False
        xrSummary9.FormatString = "{0:n2}"
        xrSummary9.IgnoreNullValues = True
        xrSummary9.Running = DevExpress.XtraReports.UI.SummaryRunning.Report
        Me.xrTableCell43.Summary = xrSummary9
        Me.xrTableCell43.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.xrTableCell43.Weight = 13.768517895493794R
        '
        'xrTableCell44
        '
        Me.xrTableCell44.Borders = DevExpress.XtraPrinting.BorderSide.Top
        Me.xrTableCell44.CanGrow = False
        Me.xrTableCell44.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "NewAgingArrears.91-180Days")})
        Me.xrTableCell44.Font = New System.Drawing.Font("Times New Roman", 10.0!, System.Drawing.FontStyle.Bold)
        Me.xrTableCell44.Name = "xrTableCell44"
        Me.xrTableCell44.StyleName = "DataField"
        Me.xrTableCell44.StylePriority.UseBorders = False
        Me.xrTableCell44.StylePriority.UseFont = False
        Me.xrTableCell44.StylePriority.UseTextAlignment = False
        xrSummary10.FormatString = "{0:n2}"
        xrSummary10.IgnoreNullValues = True
        xrSummary10.Running = DevExpress.XtraReports.UI.SummaryRunning.Report
        Me.xrTableCell44.Summary = xrSummary10
        Me.xrTableCell44.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.xrTableCell44.Weight = 14.503233108184604R
        '
        'xrTableCell45
        '
        Me.xrTableCell45.Borders = DevExpress.XtraPrinting.BorderSide.Top
        Me.xrTableCell45.CanGrow = False
        Me.xrTableCell45.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "NewAgingArrears.>180Days")})
        Me.xrTableCell45.Font = New System.Drawing.Font("Times New Roman", 10.0!, System.Drawing.FontStyle.Bold)
        Me.xrTableCell45.Name = "xrTableCell45"
        Me.xrTableCell45.StyleName = "DataField"
        Me.xrTableCell45.StylePriority.UseBorders = False
        Me.xrTableCell45.StylePriority.UseFont = False
        Me.xrTableCell45.StylePriority.UseTextAlignment = False
        xrSummary11.FormatString = "{0:n2}"
        xrSummary11.IgnoreNullValues = True
        xrSummary11.Running = DevExpress.XtraReports.UI.SummaryRunning.Report
        Me.xrTableCell45.Summary = xrSummary11
        Me.xrTableCell45.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.xrTableCell45.Weight = 12.858706498503691R
        '
        'xrTableCell21
        '
        Me.xrTableCell21.Borders = DevExpress.XtraPrinting.BorderSide.Top
        Me.xrTableCell21.CanGrow = False
        Me.xrTableCell21.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "NewAgingArrears.ArrearBalance")})
        Me.xrTableCell21.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold)
        Me.xrTableCell21.Name = "xrTableCell21"
        Me.xrTableCell21.StylePriority.UseBorders = False
        Me.xrTableCell21.StylePriority.UseFont = False
        Me.xrTableCell21.StylePriority.UseTextAlignment = False
        xrSummary12.FormatString = "{0:n2}"
        xrSummary12.IgnoreNullValues = True
        xrSummary12.Running = DevExpress.XtraReports.UI.SummaryRunning.Report
        Me.xrTableCell21.Summary = xrSummary12
        Me.xrTableCell21.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.xrTableCell21.Weight = 12.858701565525308R
        '
        'onePerc
        '
        Me.onePerc.DataMember = "NewAgingArrears"
        Me.onePerc.Expression = "[].Sum([1-30Days]) / [].Sum([TotBalance])  * 100"
        Me.onePerc.Name = "onePerc"
        '
        'thirtyPerc
        '
        Me.thirtyPerc.DataMember = "NewAgingArrears"
        Me.thirtyPerc.Expression = "[].Sum([31-60Days]) / [].Sum([TotBalance]) * 100"
        Me.thirtyPerc.Name = "thirtyPerc"
        '
        'sixtyPerc
        '
        Me.sixtyPerc.DataMember = "NewAgingArrears"
        Me.sixtyPerc.Expression = "[].Sum([61-90Days]) / [].Sum([TotBalance]) * 100"
        Me.sixtyPerc.Name = "sixtyPerc"
        '
        'nintyPerc
        '
        Me.nintyPerc.DataMember = "NewAgingArrears"
        Me.nintyPerc.Expression = "[].Sum([91-180Days]) / [].Sum([TotBalance]) * 100"
        Me.nintyPerc.Name = "nintyPerc"
        '
        'oneEightPerc
        '
        Me.oneEightPerc.DataMember = "NewAgingArrears"
        Me.oneEightPerc.Expression = "[].Sum([>180Days]) / [].Sum([TotBalance]) * 100"
        Me.oneEightPerc.Name = "oneEightPerc"
        '
        'loanOfficer
        '
        Me.loanOfficer.Description = "Loan Officer"
        dynamicListLookUpSettings1.DataAdapter = Me.masterUsersTableAdapter1
        dynamicListLookUpSettings1.DataMember = "MasterUsers"
        dynamicListLookUpSettings1.DataSource = Me.dsStaticDetails1
        dynamicListLookUpSettings1.DisplayMember = "Name"
        dynamicListLookUpSettings1.ValueMember = "USERID"
        Me.loanOfficer.LookUpSettings = dynamicListLookUpSettings1
        Me.loanOfficer.Name = "loanOfficer"
        '
        'brnch
        '
        Me.brnch.Description = "Branch"
        dynamicListLookUpSettings2.DataAdapter = Me.branchesTableAdapter1
        dynamicListLookUpSettings2.DataMember = "Branches"
        dynamicListLookUpSettings2.DataSource = Me.dsStaticDetails1
        dynamicListLookUpSettings2.DisplayMember = "BNCH_NAME"
        dynamicListLookUpSettings2.ValueMember = "BNCH_CODE"
        Me.brnch.LookUpSettings = dynamicListLookUpSettings2
        Me.brnch.Name = "brnch"
        '
        'purp
        '
        Me.purp.Description = "Purpose"
        dynamicListLookUpSettings3.DataAdapter = Me.loanPurposeTableAdapter1
        dynamicListLookUpSettings3.DataMember = "LoanPurpose"
        dynamicListLookUpSettings3.DataSource = Me.dsStaticDetails1
        dynamicListLookUpSettings3.DisplayMember = "Purpose"
        dynamicListLookUpSettings3.ValueMember = "Purpose"
        Me.purp.LookUpSettings = dynamicListLookUpSettings3
        Me.purp.Name = "purp"
        '
        'filterOption
        '
        Me.filterOption.Description = "Filter Option"
        staticListLookUpSettings1.LookUpValues.Add(New DevExpress.XtraReports.Parameters.LookUpValue(Nothing, "None"))
        staticListLookUpSettings1.LookUpValues.Add(New DevExpress.XtraReports.Parameters.LookUpValue("lo", "Loan Officer"))
        staticListLookUpSettings1.LookUpValues.Add(New DevExpress.XtraReports.Parameters.LookUpValue("br", "Branch"))
        staticListLookUpSettings1.LookUpValues.Add(New DevExpress.XtraReports.Parameters.LookUpValue("pu", "Purpose"))
        Me.filterOption.LookUpSettings = staticListLookUpSettings1
        Me.filterOption.Name = "filterOption"
        '
        'xrptAgingArrears
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.pageHeaderBand1, Me.pageFooterBand1, Me.reportHeaderBand1, Me.topMarginBand1, Me.bottomMarginBand1, Me.ReportFooter})
        Me.CalculatedFields.AddRange(New DevExpress.XtraReports.UI.CalculatedField() {Me.onePerc, Me.thirtyPerc, Me.sixtyPerc, Me.nintyPerc, Me.oneEightPerc})
        Me.DataAdapter = Me.newAgingArrearsTableAdapter1
        Me.DataMember = "NewAgingArrears"
        Me.DataSource = Me.dsAllReports1
        Me.FilterString = "[ArrearBalance] > 0.0m"
        Me.Landscape = True
        Me.Margins = New System.Drawing.Printing.Margins(0, 0, 100, 100)
        Me.PageHeight = 850
        Me.PageWidth = 1100
        Me.Parameters.AddRange(New DevExpress.XtraReports.Parameters.Parameter() {Me.filterOption, Me.loanOfficer, Me.brnch, Me.purp})
        Me.StyleSheet.AddRange(New DevExpress.XtraReports.UI.XRControlStyle() {Me.Title, Me.FieldCaption, Me.PageInfo, Me.DataField})
        Me.Version = "13.2"
        CType(Me.dsStaticDetails1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.xrTable2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dsAllReports1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.xrTable1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.xrTable4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.xrTable3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand

#End Region

    Private Sub xrptAgingArrears_DataSourceDemanded(sender As Object, e As EventArgs) Handles Me.DataSourceDemanded
        'newAgingArrearsTableAdapter1.FillByDate(dsAllReports1.NewAgingArrears, Me.toDate.Value)
        newAgingArrearsTableAdapter1.Fill(dsAllReports1.NewAgingArrears)
    End Sub
End Class