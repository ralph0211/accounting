Public Class xrptAgingArrearsGroup
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
    Private WithEvents dsAllReports1 As dsAllReports
    Private WithEvents newAgingArrearsTableAdapter1 As dsAllReportsTableAdapters.NewAgingArrearsTableAdapter
    Private WithEvents xrTableRow3 As DevExpress.XtraReports.UI.XRTableRow
    Private WithEvents xrTableCell7 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell8 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell9 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableRow4 As DevExpress.XtraReports.UI.XRTableRow
    Private WithEvents xrTableCell10 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell11 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell12 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents onePerc As DevExpress.XtraReports.UI.CalculatedField
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
    Private WithEvents agingArrearsGroupingTableAdapter1 As dsAllReportsTableAdapters.AgingArrearsGroupingTableAdapter
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
    Private WithEvents xrLabel12 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLine1 As DevExpress.XtraReports.UI.XRLine
    Private WithEvents xrLine2 As DevExpress.XtraReports.UI.XRLine
    Private WithEvents pageFooterBand1 As DevExpress.XtraReports.UI.PageFooterBand
    Private WithEvents xrPageInfo1 As DevExpress.XtraReports.UI.XRPageInfo
    Private WithEvents xrPageInfo2 As DevExpress.XtraReports.UI.XRPageInfo
    Private WithEvents reportHeaderBand1 As DevExpress.XtraReports.UI.ReportHeaderBand
    Private WithEvents xrLabel23 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents Title As DevExpress.XtraReports.UI.XRControlStyle
    Private WithEvents FieldCaption As DevExpress.XtraReports.UI.XRControlStyle
    Private WithEvents PageInfo As DevExpress.XtraReports.UI.XRControlStyle
    Private WithEvents DataField As DevExpress.XtraReports.UI.XRControlStyle
    Private WithEvents topMarginBand1 As DevExpress.XtraReports.UI.TopMarginBand
    Private WithEvents bottomMarginBand1 As DevExpress.XtraReports.UI.BottomMarginBand
    Private WithEvents GroupFooter1 As DevExpress.XtraReports.UI.GroupFooterBand
    Private WithEvents xrLabel1 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel27 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel28 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel29 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel30 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel31 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel32 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents ReportFooter As DevExpress.XtraReports.UI.ReportFooterBand
    Private WithEvents xrLabel24 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel25 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel26 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel33 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel34 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel35 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel36 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel37 As DevExpress.XtraReports.UI.XRLabel

    'Required by the Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Designer
    'It can be modified using the Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resourceFileName As String = "xrptAgingArrearsGroup.resx"
        Dim dynamicListLookUpSettings1 As DevExpress.XtraReports.Parameters.DynamicListLookUpSettings = New DevExpress.XtraReports.Parameters.DynamicListLookUpSettings()
        Dim dynamicListLookUpSettings2 As DevExpress.XtraReports.Parameters.DynamicListLookUpSettings = New DevExpress.XtraReports.Parameters.DynamicListLookUpSettings()
        Dim dynamicListLookUpSettings3 As DevExpress.XtraReports.Parameters.DynamicListLookUpSettings = New DevExpress.XtraReports.Parameters.DynamicListLookUpSettings()
        Dim staticListLookUpSettings1 As DevExpress.XtraReports.Parameters.StaticListLookUpSettings = New DevExpress.XtraReports.Parameters.StaticListLookUpSettings()
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
        Me.masterUsersTableAdapter1 = New dsStaticDetailsTableAdapters.MasterUsersTableAdapter()
        Me.dsStaticDetails1 = New dsStaticDetails()
        Me.branchesTableAdapter1 = New dsAllReportsTableAdapters.BranchesTableAdapter()
        Me.loanPurposeTableAdapter1 = New dsStaticDetailsTableAdapters.LoanPurposeTableAdapter()
        Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
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
        Me.xrTableRow3 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.xrTableCell7 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell8 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell9 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableRow4 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.xrTableCell10 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell11 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell12 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.onePerc = New DevExpress.XtraReports.UI.CalculatedField()
        Me.thirtyPerc = New DevExpress.XtraReports.UI.CalculatedField()
        Me.sixtyPerc = New DevExpress.XtraReports.UI.CalculatedField()
        Me.nintyPerc = New DevExpress.XtraReports.UI.CalculatedField()
        Me.oneEightPerc = New DevExpress.XtraReports.UI.CalculatedField()
        Me.loanOfficer = New DevExpress.XtraReports.Parameters.Parameter()
        Me.brnch = New DevExpress.XtraReports.Parameters.Parameter()
        Me.purp = New DevExpress.XtraReports.Parameters.Parameter()
        Me.filterOption = New DevExpress.XtraReports.Parameters.Parameter()
        Me.agingArrearsGroupingTableAdapter1 = New dsAllReportsTableAdapters.AgingArrearsGroupingTableAdapter()
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
        Me.xrLabel12 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLine1 = New DevExpress.XtraReports.UI.XRLine()
        Me.xrLine2 = New DevExpress.XtraReports.UI.XRLine()
        Me.pageFooterBand1 = New DevExpress.XtraReports.UI.PageFooterBand()
        Me.xrPageInfo1 = New DevExpress.XtraReports.UI.XRPageInfo()
        Me.xrPageInfo2 = New DevExpress.XtraReports.UI.XRPageInfo()
        Me.reportHeaderBand1 = New DevExpress.XtraReports.UI.ReportHeaderBand()
        Me.xrLabel23 = New DevExpress.XtraReports.UI.XRLabel()
        Me.Title = New DevExpress.XtraReports.UI.XRControlStyle()
        Me.FieldCaption = New DevExpress.XtraReports.UI.XRControlStyle()
        Me.PageInfo = New DevExpress.XtraReports.UI.XRControlStyle()
        Me.DataField = New DevExpress.XtraReports.UI.XRControlStyle()
        Me.topMarginBand1 = New DevExpress.XtraReports.UI.TopMarginBand()
        Me.bottomMarginBand1 = New DevExpress.XtraReports.UI.BottomMarginBand()
        Me.GroupFooter1 = New DevExpress.XtraReports.UI.GroupFooterBand()
        Me.xrLabel1 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel27 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel28 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel29 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel30 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel31 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel32 = New DevExpress.XtraReports.UI.XRLabel()
        Me.ReportFooter = New DevExpress.XtraReports.UI.ReportFooterBand()
        Me.xrLabel24 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel25 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel26 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel33 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel34 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel35 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel36 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel37 = New DevExpress.XtraReports.UI.XRLabel()
        CType(Me.dsStaticDetails1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dsAllReports1, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.xrLabel13, Me.xrLabel14, Me.xrLabel15, Me.xrLabel16, Me.xrLabel17, Me.xrLabel18, Me.xrLabel19, Me.xrLabel20, Me.xrLabel21, Me.xrLabel22})
        Me.Detail.HeightF = 23.0!
        Me.Detail.Name = "Detail"
        Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.Detail.StyleName = "DataField"
        Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'xrLabel13
        '
        Me.xrLabel13.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "AgingArrearsGrouping.CUSTOMER_NUMBER")})
        Me.xrLabel13.LocationFloat = New DevExpress.Utils.PointFloat(6.000002!, 0!)
        Me.xrLabel13.Name = "xrLabel13"
        Me.xrLabel13.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel13.SizeF = New System.Drawing.SizeF(86.5929!, 18.0!)
        Me.xrLabel13.Text = "xrLabel13"
        '
        'xrLabel14
        '
        Me.xrLabel14.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "AgingArrearsGrouping.Name")})
        Me.xrLabel14.LocationFloat = New DevExpress.Utils.PointFloat(92.59287!, 0!)
        Me.xrLabel14.Name = "xrLabel14"
        Me.xrLabel14.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel14.SizeF = New System.Drawing.SizeF(144.8995!, 18.0!)
        Me.xrLabel14.Text = "xrLabel14"
        '
        'xrLabel15
        '
        Me.xrLabel15.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "AgingArrearsGrouping.IDNO")})
        Me.xrLabel15.LocationFloat = New DevExpress.Utils.PointFloat(237.4923!, 0!)
        Me.xrLabel15.Name = "xrLabel15"
        Me.xrLabel15.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel15.SizeF = New System.Drawing.SizeF(99.95139!, 18.0!)
        Me.xrLabel15.Text = "xrLabel15"
        '
        'xrLabel16
        '
        Me.xrLabel16.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "AgingArrearsGrouping.Address")})
        Me.xrLabel16.LocationFloat = New DevExpress.Utils.PointFloat(337.4437!, 0!)
        Me.xrLabel16.Name = "xrLabel16"
        Me.xrLabel16.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel16.SizeF = New System.Drawing.SizeF(144.7971!, 18.0!)
        Me.xrLabel16.Text = "xrLabel16"
        '
        'xrLabel17
        '
        Me.xrLabel17.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "AgingArrearsGrouping.1-30Days", "{0:n2}")})
        Me.xrLabel17.LocationFloat = New DevExpress.Utils.PointFloat(482.2407!, 0!)
        Me.xrLabel17.Name = "xrLabel17"
        Me.xrLabel17.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel17.SizeF = New System.Drawing.SizeF(95.10993!, 18.0!)
        Me.xrLabel17.Text = "xrLabel17"
        '
        'xrLabel18
        '
        Me.xrLabel18.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "AgingArrearsGrouping.31-60Days", "{0:n2}")})
        Me.xrLabel18.LocationFloat = New DevExpress.Utils.PointFloat(577.3506!, 0!)
        Me.xrLabel18.Name = "xrLabel18"
        Me.xrLabel18.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel18.SizeF = New System.Drawing.SizeF(105.1973!, 18.0!)
        Me.xrLabel18.Text = "xrLabel18"
        '
        'xrLabel19
        '
        Me.xrLabel19.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "AgingArrearsGrouping.61-90Days", "{0:n2}")})
        Me.xrLabel19.LocationFloat = New DevExpress.Utils.PointFloat(682.5479!, 0!)
        Me.xrLabel19.Name = "xrLabel19"
        Me.xrLabel19.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel19.SizeF = New System.Drawing.SizeF(105.1973!, 18.0!)
        Me.xrLabel19.Text = "xrLabel19"
        '
        'xrLabel20
        '
        Me.xrLabel20.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "AgingArrearsGrouping.91-180Days", "{0:n2}")})
        Me.xrLabel20.LocationFloat = New DevExpress.Utils.PointFloat(787.7454!, 0!)
        Me.xrLabel20.Name = "xrLabel20"
        Me.xrLabel20.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel20.SizeF = New System.Drawing.SizeF(116.7258!, 18.0!)
        Me.xrLabel20.Text = "xrLabel20"
        '
        'xrLabel21
        '
        Me.xrLabel21.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "AgingArrearsGrouping.>180Days", "{0:n2}")})
        Me.xrLabel21.LocationFloat = New DevExpress.Utils.PointFloat(904.4711!, 0!)
        Me.xrLabel21.Name = "xrLabel21"
        Me.xrLabel21.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel21.SizeF = New System.Drawing.SizeF(99.43311!, 18.0!)
        Me.xrLabel21.Text = "xrLabel21"
        '
        'xrLabel22
        '
        Me.xrLabel22.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "AgingArrearsGrouping.ArrearBalance", "{0:n2}")})
        Me.xrLabel22.LocationFloat = New DevExpress.Utils.PointFloat(1003.904!, 0!)
        Me.xrLabel22.Name = "xrLabel22"
        Me.xrLabel22.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel22.SizeF = New System.Drawing.SizeF(90.09576!, 18.0!)
        Me.xrLabel22.Text = "xrLabel22"
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
        Me.loanOfficer.Visible = False
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
        Me.brnch.Visible = False
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
        Me.purp.Visible = False
        '
        'filterOption
        '
        Me.filterOption.Description = "Group By"
        staticListLookUpSettings1.LookUpValues.Add(New DevExpress.XtraReports.Parameters.LookUpValue("Loan Officer", "Loan Officer"))
        staticListLookUpSettings1.LookUpValues.Add(New DevExpress.XtraReports.Parameters.LookUpValue("Branch", "Branch"))
        staticListLookUpSettings1.LookUpValues.Add(New DevExpress.XtraReports.Parameters.LookUpValue("Purpose", "Purpose"))
        Me.filterOption.LookUpSettings = staticListLookUpSettings1
        Me.filterOption.Name = "filterOption"
        Me.filterOption.ValueInfo = "Branch"
        '
        'agingArrearsGroupingTableAdapter1
        '
        Me.agingArrearsGroupingTableAdapter1.ClearBeforeFill = True
        '
        'groupHeaderBand1
        '
        Me.groupHeaderBand1.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.xrLabel2})
        Me.groupHeaderBand1.GroupFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("Variable", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
        Me.groupHeaderBand1.HeightF = 36.0!
        Me.groupHeaderBand1.Level = 1
        Me.groupHeaderBand1.Name = "groupHeaderBand1"
        '
        'xrLabel2
        '
        Me.xrLabel2.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "AgingArrearsGrouping.Variable")})
        Me.xrLabel2.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.xrLabel2.ForeColor = System.Drawing.Color.Maroon
        Me.xrLabel2.LocationFloat = New DevExpress.Utils.PointFloat(9.999998!, 0!)
        Me.xrLabel2.Name = "xrLabel2"
        Me.xrLabel2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel2.SizeF = New System.Drawing.SizeF(1080.0!, 36.0!)
        Me.xrLabel2.StyleName = "DataField"
        Me.xrLabel2.StylePriority.UseFont = False
        Me.xrLabel2.StylePriority.UseForeColor = False
        Me.xrLabel2.Text = "xrLabel2"
        '
        'groupHeaderBand2
        '
        Me.groupHeaderBand2.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.xrLabel3, Me.xrLabel4, Me.xrLabel5, Me.xrLabel6, Me.xrLabel7, Me.xrLabel8, Me.xrLabel9, Me.xrLabel10, Me.xrLabel11, Me.xrLabel12, Me.xrLine1, Me.xrLine2})
        Me.groupHeaderBand2.HeightF = 28.00001!
        Me.groupHeaderBand2.Name = "groupHeaderBand2"
        Me.groupHeaderBand2.StyleName = "FieldCaption"
        '
        'xrLabel3
        '
        Me.xrLabel3.LocationFloat = New DevExpress.Utils.PointFloat(6.000002!, 7.000001!)
        Me.xrLabel3.Name = "xrLabel3"
        Me.xrLabel3.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel3.SizeF = New System.Drawing.SizeF(86.5929!, 18.0!)
        Me.xrLabel3.Text = "Account No"
        '
        'xrLabel4
        '
        Me.xrLabel4.LocationFloat = New DevExpress.Utils.PointFloat(92.59287!, 7.000001!)
        Me.xrLabel4.Name = "xrLabel4"
        Me.xrLabel4.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel4.SizeF = New System.Drawing.SizeF(144.8995!, 18.0!)
        Me.xrLabel4.Text = "Name"
        '
        'xrLabel5
        '
        Me.xrLabel5.LocationFloat = New DevExpress.Utils.PointFloat(237.4923!, 7.000001!)
        Me.xrLabel5.Name = "xrLabel5"
        Me.xrLabel5.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel5.SizeF = New System.Drawing.SizeF(99.95139!, 18.0!)
        Me.xrLabel5.Text = "ID Number"
        '
        'xrLabel6
        '
        Me.xrLabel6.LocationFloat = New DevExpress.Utils.PointFloat(337.4437!, 7.000001!)
        Me.xrLabel6.Name = "xrLabel6"
        Me.xrLabel6.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel6.SizeF = New System.Drawing.SizeF(144.7971!, 18.0!)
        Me.xrLabel6.Text = "Address"
        '
        'xrLabel7
        '
        Me.xrLabel7.LocationFloat = New DevExpress.Utils.PointFloat(482.2407!, 7.0!)
        Me.xrLabel7.Name = "xrLabel7"
        Me.xrLabel7.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel7.SizeF = New System.Drawing.SizeF(95.10993!, 18.0!)
        Me.xrLabel7.Text = "1-30Days"
        '
        'xrLabel8
        '
        Me.xrLabel8.LocationFloat = New DevExpress.Utils.PointFloat(577.3506!, 7.0!)
        Me.xrLabel8.Name = "xrLabel8"
        Me.xrLabel8.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel8.SizeF = New System.Drawing.SizeF(105.1973!, 18.0!)
        Me.xrLabel8.Text = "31-60Days"
        '
        'xrLabel9
        '
        Me.xrLabel9.LocationFloat = New DevExpress.Utils.PointFloat(682.5479!, 7.0!)
        Me.xrLabel9.Name = "xrLabel9"
        Me.xrLabel9.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel9.SizeF = New System.Drawing.SizeF(105.1973!, 18.0!)
        Me.xrLabel9.Text = "61-90Days"
        '
        'xrLabel10
        '
        Me.xrLabel10.LocationFloat = New DevExpress.Utils.PointFloat(787.7454!, 7.0!)
        Me.xrLabel10.Name = "xrLabel10"
        Me.xrLabel10.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel10.SizeF = New System.Drawing.SizeF(116.7258!, 18.0!)
        Me.xrLabel10.Text = "91-180Days"
        '
        'xrLabel11
        '
        Me.xrLabel11.LocationFloat = New DevExpress.Utils.PointFloat(904.4711!, 7.0!)
        Me.xrLabel11.Name = "xrLabel11"
        Me.xrLabel11.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel11.SizeF = New System.Drawing.SizeF(99.43311!, 18.0!)
        Me.xrLabel11.Text = ">180Days"
        '
        'xrLabel12
        '
        Me.xrLabel12.LocationFloat = New DevExpress.Utils.PointFloat(1003.904!, 7.000001!)
        Me.xrLabel12.Name = "xrLabel12"
        Me.xrLabel12.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel12.SizeF = New System.Drawing.SizeF(90.09576!, 18.0!)
        Me.xrLabel12.Text = "Balance"
        '
        'xrLine1
        '
        Me.xrLine1.LocationFloat = New DevExpress.Utils.PointFloat(6.0!, 5.0!)
        Me.xrLine1.Name = "xrLine1"
        Me.xrLine1.SizeF = New System.Drawing.SizeF(1088.0!, 2.0!)
        '
        'xrLine2
        '
        Me.xrLine2.LocationFloat = New DevExpress.Utils.PointFloat(6.0!, 25.0!)
        Me.xrLine2.Name = "xrLine2"
        Me.xrLine2.SizeF = New System.Drawing.SizeF(1088.0!, 2.0!)
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
        Me.xrPageInfo1.SizeF = New System.Drawing.SizeF(538.0!, 23.0!)
        Me.xrPageInfo1.StyleName = "PageInfo"
        '
        'xrPageInfo2
        '
        Me.xrPageInfo2.Format = "Page {0} of {1}"
        Me.xrPageInfo2.LocationFloat = New DevExpress.Utils.PointFloat(556.0!, 6.0!)
        Me.xrPageInfo2.Name = "xrPageInfo2"
        Me.xrPageInfo2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrPageInfo2.SizeF = New System.Drawing.SizeF(538.0!, 23.0!)
        Me.xrPageInfo2.StyleName = "PageInfo"
        Me.xrPageInfo2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'reportHeaderBand1
        '
        Me.reportHeaderBand1.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.xrLabel37, Me.xrLabel23})
        Me.reportHeaderBand1.HeightF = 83.29166!
        Me.reportHeaderBand1.Name = "reportHeaderBand1"
        '
        'xrLabel23
        '
        Me.xrLabel23.LocationFloat = New DevExpress.Utils.PointFloat(6.0!, 6.0!)
        Me.xrLabel23.Name = "xrLabel23"
        Me.xrLabel23.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel23.SizeF = New System.Drawing.SizeF(1088.0!, 33.0!)
        Me.xrLabel23.StyleName = "Title"
        Me.xrLabel23.Text = "Aging Of Arrears Report"
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
        'GroupFooter1
        '
        Me.GroupFooter1.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.xrLabel1, Me.xrLabel27, Me.xrLabel28, Me.xrLabel29, Me.xrLabel30, Me.xrLabel31, Me.xrLabel32})
        Me.GroupFooter1.HeightF = 39.58333!
        Me.GroupFooter1.Name = "GroupFooter1"
        '
        'xrLabel1
        '
        Me.xrLabel1.Borders = DevExpress.XtraPrinting.BorderSide.Top
        Me.xrLabel1.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold)
        Me.xrLabel1.LocationFloat = New DevExpress.Utils.PointFloat(6.000122!, 10.00001!)
        Me.xrLabel1.Name = "xrLabel1"
        Me.xrLabel1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel1.SizeF = New System.Drawing.SizeF(476.2407!, 18.0!)
        Me.xrLabel1.StylePriority.UseBorders = False
        Me.xrLabel1.StylePriority.UseFont = False
        Me.xrLabel1.Text = "Total ([Variable])"
        '
        'xrLabel27
        '
        Me.xrLabel27.Borders = DevExpress.XtraPrinting.BorderSide.Top
        Me.xrLabel27.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "AgingArrearsGrouping.1-30Days")})
        Me.xrLabel27.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold)
        Me.xrLabel27.LocationFloat = New DevExpress.Utils.PointFloat(482.2408!, 10.0!)
        Me.xrLabel27.Name = "xrLabel27"
        Me.xrLabel27.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel27.SizeF = New System.Drawing.SizeF(95.10993!, 18.0!)
        Me.xrLabel27.StylePriority.UseBorders = False
        Me.xrLabel27.StylePriority.UseFont = False
        xrSummary1.FormatString = "{0:n2}"
        xrSummary1.IgnoreNullValues = True
        xrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
        Me.xrLabel27.Summary = xrSummary1
        '
        'xrLabel28
        '
        Me.xrLabel28.Borders = DevExpress.XtraPrinting.BorderSide.Top
        Me.xrLabel28.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "AgingArrearsGrouping.31-60Days")})
        Me.xrLabel28.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold)
        Me.xrLabel28.LocationFloat = New DevExpress.Utils.PointFloat(577.3507!, 10.0!)
        Me.xrLabel28.Name = "xrLabel28"
        Me.xrLabel28.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel28.SizeF = New System.Drawing.SizeF(105.1973!, 18.0!)
        Me.xrLabel28.StylePriority.UseBorders = False
        Me.xrLabel28.StylePriority.UseFont = False
        xrSummary2.FormatString = "{0:n2}"
        xrSummary2.IgnoreNullValues = True
        xrSummary2.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
        Me.xrLabel28.Summary = xrSummary2
        '
        'xrLabel29
        '
        Me.xrLabel29.Borders = DevExpress.XtraPrinting.BorderSide.Top
        Me.xrLabel29.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "AgingArrearsGrouping.61-90Days")})
        Me.xrLabel29.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold)
        Me.xrLabel29.LocationFloat = New DevExpress.Utils.PointFloat(682.548!, 10.0!)
        Me.xrLabel29.Name = "xrLabel29"
        Me.xrLabel29.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel29.SizeF = New System.Drawing.SizeF(105.1973!, 18.0!)
        Me.xrLabel29.StylePriority.UseBorders = False
        Me.xrLabel29.StylePriority.UseFont = False
        xrSummary3.FormatString = "{0:n2}"
        xrSummary3.IgnoreNullValues = True
        xrSummary3.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
        Me.xrLabel29.Summary = xrSummary3
        '
        'xrLabel30
        '
        Me.xrLabel30.Borders = DevExpress.XtraPrinting.BorderSide.Top
        Me.xrLabel30.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "AgingArrearsGrouping.91-180Days")})
        Me.xrLabel30.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold)
        Me.xrLabel30.LocationFloat = New DevExpress.Utils.PointFloat(787.7455!, 10.0!)
        Me.xrLabel30.Name = "xrLabel30"
        Me.xrLabel30.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel30.SizeF = New System.Drawing.SizeF(116.7258!, 18.0!)
        Me.xrLabel30.StylePriority.UseBorders = False
        Me.xrLabel30.StylePriority.UseFont = False
        xrSummary4.FormatString = "{0:n2}"
        xrSummary4.IgnoreNullValues = True
        xrSummary4.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
        Me.xrLabel30.Summary = xrSummary4
        '
        'xrLabel31
        '
        Me.xrLabel31.Borders = DevExpress.XtraPrinting.BorderSide.Top
        Me.xrLabel31.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "AgingArrearsGrouping.>180Days")})
        Me.xrLabel31.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold)
        Me.xrLabel31.LocationFloat = New DevExpress.Utils.PointFloat(904.4713!, 10.0!)
        Me.xrLabel31.Name = "xrLabel31"
        Me.xrLabel31.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel31.SizeF = New System.Drawing.SizeF(99.43311!, 18.0!)
        Me.xrLabel31.StylePriority.UseBorders = False
        Me.xrLabel31.StylePriority.UseFont = False
        xrSummary5.FormatString = "{0:n2}"
        xrSummary5.IgnoreNullValues = True
        xrSummary5.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
        Me.xrLabel31.Summary = xrSummary5
        '
        'xrLabel32
        '
        Me.xrLabel32.Borders = DevExpress.XtraPrinting.BorderSide.Top
        Me.xrLabel32.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "AgingArrearsGrouping.ArrearBalance")})
        Me.xrLabel32.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold)
        Me.xrLabel32.LocationFloat = New DevExpress.Utils.PointFloat(1003.904!, 10.0!)
        Me.xrLabel32.Name = "xrLabel32"
        Me.xrLabel32.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel32.SizeF = New System.Drawing.SizeF(90.09576!, 18.0!)
        Me.xrLabel32.StylePriority.UseBorders = False
        Me.xrLabel32.StylePriority.UseFont = False
        xrSummary6.FormatString = "{0:n2}"
        xrSummary6.IgnoreNullValues = True
        xrSummary6.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
        Me.xrLabel32.Summary = xrSummary6
        '
        'ReportFooter
        '
        Me.ReportFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.xrLabel24, Me.xrLabel25, Me.xrLabel26, Me.xrLabel33, Me.xrLabel34, Me.xrLabel35, Me.xrLabel36})
        Me.ReportFooter.HeightF = 41.66667!
        Me.ReportFooter.Name = "ReportFooter"
        '
        'xrLabel24
        '
        Me.xrLabel24.Borders = DevExpress.XtraPrinting.BorderSide.Top
        Me.xrLabel24.BorderWidth = 2.0!
        Me.xrLabel24.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold)
        Me.xrLabel24.LocationFloat = New DevExpress.Utils.PointFloat(6.000122!, 11.83334!)
        Me.xrLabel24.Name = "xrLabel24"
        Me.xrLabel24.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel24.SizeF = New System.Drawing.SizeF(476.2407!, 18.0!)
        Me.xrLabel24.StylePriority.UseBorders = False
        Me.xrLabel24.StylePriority.UseBorderWidth = False
        Me.xrLabel24.StylePriority.UseFont = False
        Me.xrLabel24.Text = "Grand Total"
        '
        'xrLabel25
        '
        Me.xrLabel25.Borders = DevExpress.XtraPrinting.BorderSide.Top
        Me.xrLabel25.BorderWidth = 2.0!
        Me.xrLabel25.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "AgingArrearsGrouping.1-30Days")})
        Me.xrLabel25.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold)
        Me.xrLabel25.LocationFloat = New DevExpress.Utils.PointFloat(482.2408!, 11.83333!)
        Me.xrLabel25.Name = "xrLabel25"
        Me.xrLabel25.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel25.SizeF = New System.Drawing.SizeF(95.10993!, 18.0!)
        Me.xrLabel25.StylePriority.UseBorders = False
        Me.xrLabel25.StylePriority.UseBorderWidth = False
        Me.xrLabel25.StylePriority.UseFont = False
        xrSummary7.FormatString = "{0:n2}"
        xrSummary7.IgnoreNullValues = True
        xrSummary7.Running = DevExpress.XtraReports.UI.SummaryRunning.Report
        Me.xrLabel25.Summary = xrSummary7
        '
        'xrLabel26
        '
        Me.xrLabel26.Borders = DevExpress.XtraPrinting.BorderSide.Top
        Me.xrLabel26.BorderWidth = 2.0!
        Me.xrLabel26.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "AgingArrearsGrouping.31-60Days")})
        Me.xrLabel26.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold)
        Me.xrLabel26.LocationFloat = New DevExpress.Utils.PointFloat(577.3507!, 11.83333!)
        Me.xrLabel26.Name = "xrLabel26"
        Me.xrLabel26.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel26.SizeF = New System.Drawing.SizeF(105.1973!, 18.0!)
        Me.xrLabel26.StylePriority.UseBorders = False
        Me.xrLabel26.StylePriority.UseBorderWidth = False
        Me.xrLabel26.StylePriority.UseFont = False
        xrSummary8.FormatString = "{0:n2}"
        xrSummary8.IgnoreNullValues = True
        xrSummary8.Running = DevExpress.XtraReports.UI.SummaryRunning.Report
        Me.xrLabel26.Summary = xrSummary8
        '
        'xrLabel33
        '
        Me.xrLabel33.Borders = DevExpress.XtraPrinting.BorderSide.Top
        Me.xrLabel33.BorderWidth = 2.0!
        Me.xrLabel33.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "AgingArrearsGrouping.61-90Days")})
        Me.xrLabel33.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold)
        Me.xrLabel33.LocationFloat = New DevExpress.Utils.PointFloat(682.548!, 11.83333!)
        Me.xrLabel33.Name = "xrLabel33"
        Me.xrLabel33.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel33.SizeF = New System.Drawing.SizeF(105.1973!, 18.0!)
        Me.xrLabel33.StylePriority.UseBorders = False
        Me.xrLabel33.StylePriority.UseBorderWidth = False
        Me.xrLabel33.StylePriority.UseFont = False
        xrSummary9.FormatString = "{0:n2}"
        xrSummary9.IgnoreNullValues = True
        xrSummary9.Running = DevExpress.XtraReports.UI.SummaryRunning.Report
        Me.xrLabel33.Summary = xrSummary9
        '
        'xrLabel34
        '
        Me.xrLabel34.Borders = DevExpress.XtraPrinting.BorderSide.Top
        Me.xrLabel34.BorderWidth = 2.0!
        Me.xrLabel34.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "AgingArrearsGrouping.91-180Days")})
        Me.xrLabel34.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold)
        Me.xrLabel34.LocationFloat = New DevExpress.Utils.PointFloat(787.7455!, 11.83333!)
        Me.xrLabel34.Name = "xrLabel34"
        Me.xrLabel34.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel34.SizeF = New System.Drawing.SizeF(116.7258!, 18.0!)
        Me.xrLabel34.StylePriority.UseBorders = False
        Me.xrLabel34.StylePriority.UseBorderWidth = False
        Me.xrLabel34.StylePriority.UseFont = False
        xrSummary10.FormatString = "{0:n2}"
        xrSummary10.IgnoreNullValues = True
        xrSummary10.Running = DevExpress.XtraReports.UI.SummaryRunning.Report
        Me.xrLabel34.Summary = xrSummary10
        '
        'xrLabel35
        '
        Me.xrLabel35.Borders = DevExpress.XtraPrinting.BorderSide.Top
        Me.xrLabel35.BorderWidth = 2.0!
        Me.xrLabel35.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "AgingArrearsGrouping.>180Days")})
        Me.xrLabel35.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold)
        Me.xrLabel35.LocationFloat = New DevExpress.Utils.PointFloat(904.4713!, 11.83333!)
        Me.xrLabel35.Name = "xrLabel35"
        Me.xrLabel35.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel35.SizeF = New System.Drawing.SizeF(99.43311!, 18.0!)
        Me.xrLabel35.StylePriority.UseBorders = False
        Me.xrLabel35.StylePriority.UseBorderWidth = False
        Me.xrLabel35.StylePriority.UseFont = False
        xrSummary11.FormatString = "{0:n2}"
        xrSummary11.IgnoreNullValues = True
        xrSummary11.Running = DevExpress.XtraReports.UI.SummaryRunning.Report
        Me.xrLabel35.Summary = xrSummary11
        '
        'xrLabel36
        '
        Me.xrLabel36.Borders = DevExpress.XtraPrinting.BorderSide.Top
        Me.xrLabel36.BorderWidth = 2.0!
        Me.xrLabel36.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "AgingArrearsGrouping.ArrearBalance")})
        Me.xrLabel36.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold)
        Me.xrLabel36.LocationFloat = New DevExpress.Utils.PointFloat(1003.904!, 11.83333!)
        Me.xrLabel36.Name = "xrLabel36"
        Me.xrLabel36.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel36.SizeF = New System.Drawing.SizeF(90.09576!, 18.0!)
        Me.xrLabel36.StylePriority.UseBorders = False
        Me.xrLabel36.StylePriority.UseBorderWidth = False
        Me.xrLabel36.StylePriority.UseFont = False
        xrSummary12.FormatString = "{0:n2}"
        xrSummary12.IgnoreNullValues = True
        xrSummary12.Running = DevExpress.XtraReports.UI.SummaryRunning.Report
        Me.xrLabel36.Summary = xrSummary12
        '
        'xrLabel37
        '
        Me.xrLabel37.Font = New System.Drawing.Font("Times New Roman", 14.0!, System.Drawing.FontStyle.Bold)
        Me.xrLabel37.LocationFloat = New DevExpress.Utils.PointFloat(6.000002!, 50.70834!)
        Me.xrLabel37.Name = "xrLabel37"
        Me.xrLabel37.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel37.SizeF = New System.Drawing.SizeF(1088.0!, 22.58332!)
        Me.xrLabel37.StyleName = "Title"
        Me.xrLabel37.StylePriority.UseFont = False
        Me.xrLabel37.Text = "Grouped by [Parameters.filterOption]"
        '
        'xrptAgingArrearsGroup
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.groupHeaderBand1, Me.groupHeaderBand2, Me.pageFooterBand1, Me.reportHeaderBand1, Me.topMarginBand1, Me.bottomMarginBand1, Me.GroupFooter1, Me.ReportFooter})
        Me.CalculatedFields.AddRange(New DevExpress.XtraReports.UI.CalculatedField() {Me.onePerc, Me.thirtyPerc, Me.sixtyPerc, Me.nintyPerc, Me.oneEightPerc})
        Me.DataAdapter = Me.agingArrearsGroupingTableAdapter1
        Me.DataMember = "AgingArrearsGrouping"
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
        CType(Me.dsAllReports1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand

#End Region

    Private Sub xrptAgingArrearsGroupGroup_DataSourceDemanded(sender As Object, e As EventArgs) Handles Me.DataSourceDemanded
        'newAgingArrearsTableAdapter1.FillByDate(dsAllReports1.NewAgingArrears, Me.toDate.Value)
        'newAgingArrearsTableAdapter1.Fill(dsAllReports1.NewAgingArrears)
        If filterOption.Value = "Branch" Then
            agingArrearsGroupingTableAdapter1.FillBranch(dsAllReports1.AgingArrearsGrouping)
        ElseIf filterOption.Value = "Loan Officer" Then
            agingArrearsGroupingTableAdapter1.FillLoanOfficer(dsAllReports1.AgingArrearsGrouping)
        ElseIf filterOption.Value = "Purpose" Then
            agingArrearsGroupingTableAdapter1.FillPurpose(dsAllReports1.AgingArrearsGrouping)
            'Else
            '    agingArrearsGroupingTableAdapter1.FillBranch(dsAllReports1.AgingArrearsGrouping)
        End If
    End Sub
End Class