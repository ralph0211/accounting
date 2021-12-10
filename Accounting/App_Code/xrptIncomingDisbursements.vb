Imports System.Drawing.Printing

Public Class xrptIncomingDisbursements
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
    Private dsAnalystReports1 As dsAnalystReports
    Private disbursementsTableAdapter1 As dsAnalystReportsTableAdapters.DisbursementsTableAdapter
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
    Private WithEvents xrTableCell22 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell24 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell26 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents dsAnalystReports2 As dsAnalystReports
    Private WithEvents xrPageInfo1 As DevExpress.XtraReports.UI.XRPageInfo
    Private WithEvents xrPageInfo2 As DevExpress.XtraReports.UI.XRPageInfo
    Private WithEvents reportHeaderBand1 As DevExpress.XtraReports.UI.ReportHeaderBand
    Private WithEvents xrLabel15 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents topMarginBand1 As DevExpress.XtraReports.UI.TopMarginBand
    Private WithEvents bottomMarginBand1 As DevExpress.XtraReports.UI.BottomMarginBand
    Private WithEvents pageHeaderBand1 As DevExpress.XtraReports.UI.PageHeaderBand
    Private WithEvents xrTable1 As DevExpress.XtraReports.UI.XRTable
    Private WithEvents xrTableRow5 As DevExpress.XtraReports.UI.XRTableRow
    Private WithEvents xrTableCell13 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell15 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell17 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell19 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell21 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell23 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell25 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableRow3 As DevExpress.XtraReports.UI.XRTableRow
    Private WithEvents xrTableCell7 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell8 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell9 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableRow4 As DevExpress.XtraReports.UI.XRTableRow
    Private WithEvents xrTableCell10 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell11 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell12 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents pageFooterBand1 As DevExpress.XtraReports.UI.PageFooterBand
    Private WithEvents xrPageInfo3 As DevExpress.XtraReports.UI.XRPageInfo
    Private WithEvents xrPageInfo4 As DevExpress.XtraReports.UI.XRPageInfo
    Private WithEvents reportHeaderBand2 As DevExpress.XtraReports.UI.ReportHeaderBand
    Private WithEvents xrLabel1 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents Title As DevExpress.XtraReports.UI.XRControlStyle
    Private WithEvents FieldCaption As DevExpress.XtraReports.UI.XRControlStyle
    Private WithEvents PageInfo As DevExpress.XtraReports.UI.XRControlStyle
    Private WithEvents DataField As DevExpress.XtraReports.UI.XRControlStyle
    Private WithEvents topMarginBand2 As DevExpress.XtraReports.UI.TopMarginBand
    Private WithEvents bottomMarginBand2 As DevExpress.XtraReports.UI.BottomMarginBand
    Private WithEvents dsAllReports1 As dsAllReports
    Private WithEvents dsAnalystReports3 As dsAnalystReports
    Private WithEvents GroupHeader1 As DevExpress.XtraReports.UI.GroupHeaderBand
    Private WithEvents xrLabel3 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents GroupFooter1 As DevExpress.XtraReports.UI.GroupFooterBand
    Private WithEvents xrLine1 As DevExpress.XtraReports.UI.XRLine
    Private WithEvents xrTable3 As DevExpress.XtraReports.UI.XRTable
    Private WithEvents xrTableRow7 As DevExpress.XtraReports.UI.XRTableRow
    Private WithEvents xrTableCell27 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell29 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell31 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell32 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell33 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents New_BranchesTableAdapter As dsAnalystReportsTableAdapters.New_BranchesTableAdapter
    Private WithEvents brnch As DevExpress.XtraReports.Parameters.Parameter
    Private WithEvents xrLabel4 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrTableCell30 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell28 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents incomingDisbursementsTableAdapter1 As dsAnalystReportsTableAdapters.IncomingDisbursementsTableAdapter
    Private WithEvents dateFrom As DevExpress.XtraReports.Parameters.Parameter
    Private WithEvents dateTo As DevExpress.XtraReports.Parameters.Parameter
    Private WithEvents xrTableCell34 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell35 As DevExpress.XtraReports.UI.XRTableCell

    'Required by the Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Designer
    'It can be modified using the Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resourceFileName As String = "xrptIncomingDisbursements.resx"
        Dim xrSummary1 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
        Dim xrSummary2 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
        Dim dynamicListLookUpSettings1 As DevExpress.XtraReports.Parameters.DynamicListLookUpSettings = New DevExpress.XtraReports.Parameters.DynamicListLookUpSettings()
        Me.New_BranchesTableAdapter = New dsAnalystReportsTableAdapters.New_BranchesTableAdapter()
        Me.dsAnalystReports3 = New dsAnalystReports()
        Me.dsAllReports1 = New dsAllReports()
        Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
        Me.xrTable2 = New DevExpress.XtraReports.UI.XRTable()
        Me.xrTableRow6 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.xrTableCell14 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell16 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell18 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell20 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell22 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell30 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell24 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell26 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell34 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.dsAnalystReports1 = New dsAnalystReports()
        Me.disbursementsTableAdapter1 = New dsAnalystReportsTableAdapters.DisbursementsTableAdapter()
        Me.xrTableRow1 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.xrTableCell1 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell2 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell3 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableRow2 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.xrTableCell4 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell5 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell6 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.dsAnalystReports2 = New dsAnalystReports()
        Me.xrPageInfo1 = New DevExpress.XtraReports.UI.XRPageInfo()
        Me.xrPageInfo2 = New DevExpress.XtraReports.UI.XRPageInfo()
        Me.reportHeaderBand1 = New DevExpress.XtraReports.UI.ReportHeaderBand()
        Me.xrLabel15 = New DevExpress.XtraReports.UI.XRLabel()
        Me.topMarginBand1 = New DevExpress.XtraReports.UI.TopMarginBand()
        Me.bottomMarginBand1 = New DevExpress.XtraReports.UI.BottomMarginBand()
        Me.pageHeaderBand1 = New DevExpress.XtraReports.UI.PageHeaderBand()
        Me.xrTable1 = New DevExpress.XtraReports.UI.XRTable()
        Me.xrTableRow5 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.xrTableCell13 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell15 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell17 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell19 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell21 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell28 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell23 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell25 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell35 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableRow3 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.xrTableCell7 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell8 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell9 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableRow4 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.xrTableCell10 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell11 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell12 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.pageFooterBand1 = New DevExpress.XtraReports.UI.PageFooterBand()
        Me.xrPageInfo3 = New DevExpress.XtraReports.UI.XRPageInfo()
        Me.xrPageInfo4 = New DevExpress.XtraReports.UI.XRPageInfo()
        Me.reportHeaderBand2 = New DevExpress.XtraReports.UI.ReportHeaderBand()
        Me.xrLabel1 = New DevExpress.XtraReports.UI.XRLabel()
        Me.Title = New DevExpress.XtraReports.UI.XRControlStyle()
        Me.FieldCaption = New DevExpress.XtraReports.UI.XRControlStyle()
        Me.PageInfo = New DevExpress.XtraReports.UI.XRControlStyle()
        Me.DataField = New DevExpress.XtraReports.UI.XRControlStyle()
        Me.topMarginBand2 = New DevExpress.XtraReports.UI.TopMarginBand()
        Me.bottomMarginBand2 = New DevExpress.XtraReports.UI.BottomMarginBand()
        Me.GroupHeader1 = New DevExpress.XtraReports.UI.GroupHeaderBand()
        Me.xrLabel4 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel3 = New DevExpress.XtraReports.UI.XRLabel()
        Me.GroupFooter1 = New DevExpress.XtraReports.UI.GroupFooterBand()
        Me.xrLine1 = New DevExpress.XtraReports.UI.XRLine()
        Me.xrTable3 = New DevExpress.XtraReports.UI.XRTable()
        Me.xrTableRow7 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.xrTableCell27 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell29 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell31 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell32 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell33 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.brnch = New DevExpress.XtraReports.Parameters.Parameter()
        Me.incomingDisbursementsTableAdapter1 = New dsAnalystReportsTableAdapters.IncomingDisbursementsTableAdapter()
        Me.dateFrom = New DevExpress.XtraReports.Parameters.Parameter()
        Me.dateTo = New DevExpress.XtraReports.Parameters.Parameter()
        CType(Me.dsAnalystReports3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dsAllReports1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.xrTable2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dsAnalystReports1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dsAnalystReports2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.xrTable1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.xrTable3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'New_BranchesTableAdapter
        '
        Me.New_BranchesTableAdapter.ClearBeforeFill = True
        '
        'dsAnalystReports3
        '
        Me.dsAnalystReports3.DataSetName = "dsAnalystReports"
        Me.dsAnalystReports3.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'dsAllReports1
        '
        Me.dsAllReports1.DataSetName = "dsAllReports"
        Me.dsAllReports1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.xrTable2})
        Me.Detail.HeightF = 38.62495!
        Me.Detail.Name = "Detail"
        Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'xrTable2
        '
        Me.xrTable2.AnchorVertical = CType((DevExpress.XtraReports.UI.VerticalAnchorStyles.Top Or DevExpress.XtraReports.UI.VerticalAnchorStyles.Bottom), DevExpress.XtraReports.UI.VerticalAnchorStyles)
        Me.xrTable2.LocationFloat = New DevExpress.Utils.PointFloat(6.0!, 0!)
        Me.xrTable2.Name = "xrTable2"
        Me.xrTable2.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.xrTableRow6})
        Me.xrTable2.SizeF = New System.Drawing.SizeF(884.0!, 38.62495!)
        '
        'xrTableRow6
        '
        Me.xrTableRow6.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.xrTableCell14, Me.xrTableCell16, Me.xrTableCell18, Me.xrTableCell20, Me.xrTableCell22, Me.xrTableCell30, Me.xrTableCell24, Me.xrTableCell26, Me.xrTableCell34})
        Me.xrTableRow6.Name = "xrTableRow6"
        Me.xrTableRow6.Weight = 1.0R
        '
        'xrTableCell14
        '
        Me.xrTableCell14.CanGrow = False
        Me.xrTableCell14.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "IncomingDisbursements.CUSTOMER_NUMBER")})
        Me.xrTableCell14.Name = "xrTableCell14"
        Me.xrTableCell14.StyleName = "DataField"
        Me.xrTableCell14.Weight = 31.560998087213783R
        '
        'xrTableCell16
        '
        Me.xrTableCell16.CanGrow = False
        Me.xrTableCell16.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "IncomingDisbursements.Name")})
        Me.xrTableCell16.Name = "xrTableCell16"
        Me.xrTableCell16.StyleName = "DataField"
        Me.xrTableCell16.Weight = 83.7845632592026R
        '
        'xrTableCell18
        '
        Me.xrTableCell18.CanGrow = False
        Me.xrTableCell18.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "IncomingDisbursements.CREATED_DATE", "{0:dd MMM yyyy}")})
        Me.xrTableCell18.Name = "xrTableCell18"
        Me.xrTableCell18.StyleName = "DataField"
        Me.xrTableCell18.Weight = 53.865622426127338R
        '
        'xrTableCell20
        '
        Me.xrTableCell20.CanGrow = False
        Me.xrTableCell20.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "IncomingDisbursements.MaturityDate", "{0:dd MMM yyyy}")})
        Me.xrTableCell20.Name = "xrTableCell20"
        Me.xrTableCell20.StyleName = "DataField"
        Me.xrTableCell20.Weight = 45.28881622745628R
        '
        'xrTableCell22
        '
        Me.xrTableCell22.CanGrow = False
        Me.xrTableCell22.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "IncomingDisbursements.Bank")})
        Me.xrTableCell22.Name = "xrTableCell22"
        Me.xrTableCell22.StyleName = "DataField"
        Me.xrTableCell22.Weight = 31.999996553597683R
        '
        'xrTableCell30
        '
        Me.xrTableCell30.CanGrow = False
        Me.xrTableCell30.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "IncomingDisbursements.BankAccountNo")})
        Me.xrTableCell30.Name = "xrTableCell30"
        Me.xrTableCell30.Weight = 33.615131605738178R
        '
        'xrTableCell24
        '
        Me.xrTableCell24.CanGrow = False
        Me.xrTableCell24.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "IncomingDisbursements.Amount", "{0:n2}")})
        Me.xrTableCell24.Name = "xrTableCell24"
        Me.xrTableCell24.StyleName = "DataField"
        Me.xrTableCell24.Weight = 48.2854801609153R
        '
        'xrTableCell26
        '
        Me.xrTableCell26.CanGrow = False
        Me.xrTableCell26.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "IncomingDisbursements.Instalment", "{0:n2}")})
        Me.xrTableCell26.Name = "xrTableCell26"
        Me.xrTableCell26.StyleName = "DataField"
        Me.xrTableCell26.Weight = 35.453334765925625R
        '
        'xrTableCell34
        '
        Me.xrTableCell34.CanGrow = False
        Me.xrTableCell34.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "IncomingDisbursements.Product")})
        Me.xrTableCell34.Name = "xrTableCell34"
        Me.xrTableCell34.Weight = 76.758265123061051R
        '
        'dsAnalystReports1
        '
        Me.dsAnalystReports1.DataSetName = "dsAnalystReports"
        Me.dsAnalystReports1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'disbursementsTableAdapter1
        '
        Me.disbursementsTableAdapter1.ClearBeforeFill = True
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
        'dsAnalystReports2
        '
        Me.dsAnalystReports2.DataSetName = "dsAnalystReports"
        Me.dsAnalystReports2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'xrPageInfo1
        '
        Me.xrPageInfo1.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
        Me.xrPageInfo1.Name = "xrPageInfo1"
        Me.xrPageInfo1.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
        '
        'xrPageInfo2
        '
        Me.xrPageInfo2.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
        Me.xrPageInfo2.Name = "xrPageInfo2"
        Me.xrPageInfo2.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
        '
        'reportHeaderBand1
        '
        Me.reportHeaderBand1.HeightF = 51.0!
        Me.reportHeaderBand1.Name = "reportHeaderBand1"
        '
        'xrLabel15
        '
        Me.xrLabel15.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
        Me.xrLabel15.Name = "xrLabel15"
        Me.xrLabel15.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
        '
        'topMarginBand1
        '
        Me.topMarginBand1.Name = "topMarginBand1"
        '
        'bottomMarginBand1
        '
        Me.bottomMarginBand1.Name = "bottomMarginBand1"
        '
        'pageHeaderBand1
        '
        Me.pageHeaderBand1.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.xrTable1})
        Me.pageHeaderBand1.HeightF = 42.0!
        Me.pageHeaderBand1.Name = "pageHeaderBand1"
        '
        'xrTable1
        '
        Me.xrTable1.AnchorVertical = DevExpress.XtraReports.UI.VerticalAnchorStyles.Bottom
        Me.xrTable1.LocationFloat = New DevExpress.Utils.PointFloat(6.0!, 6.0!)
        Me.xrTable1.Name = "xrTable1"
        Me.xrTable1.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.xrTableRow5})
        Me.xrTable1.SizeF = New System.Drawing.SizeF(884.0!, 36.0!)
        '
        'xrTableRow5
        '
        Me.xrTableRow5.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.xrTableCell13, Me.xrTableCell15, Me.xrTableCell17, Me.xrTableCell19, Me.xrTableCell21, Me.xrTableCell28, Me.xrTableCell23, Me.xrTableCell25, Me.xrTableCell35})
        Me.xrTableRow5.Name = "xrTableRow5"
        Me.xrTableRow5.Weight = 1.0R
        '
        'xrTableCell13
        '
        Me.xrTableCell13.CanGrow = False
        Me.xrTableCell13.Name = "xrTableCell13"
        Me.xrTableCell13.StyleName = "FieldCaption"
        Me.xrTableCell13.Text = "Account"
        Me.xrTableCell13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        Me.xrTableCell13.Weight = 31.560998087213783R
        '
        'xrTableCell15
        '
        Me.xrTableCell15.CanGrow = False
        Me.xrTableCell15.Name = "xrTableCell15"
        Me.xrTableCell15.StyleName = "FieldCaption"
        Me.xrTableCell15.Text = "Name"
        Me.xrTableCell15.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        Me.xrTableCell15.Weight = 83.7845632592026R
        '
        'xrTableCell17
        '
        Me.xrTableCell17.CanGrow = False
        Me.xrTableCell17.Name = "xrTableCell17"
        Me.xrTableCell17.StyleName = "FieldCaption"
        Me.xrTableCell17.Text = "Application Date"
        Me.xrTableCell17.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        Me.xrTableCell17.Weight = 53.865622426127338R
        '
        'xrTableCell19
        '
        Me.xrTableCell19.CanGrow = False
        Me.xrTableCell19.Name = "xrTableCell19"
        Me.xrTableCell19.StyleName = "FieldCaption"
        Me.xrTableCell19.Text = "Maturity Date"
        Me.xrTableCell19.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        Me.xrTableCell19.Weight = 45.28881622745628R
        '
        'xrTableCell21
        '
        Me.xrTableCell21.CanGrow = False
        Me.xrTableCell21.Name = "xrTableCell21"
        Me.xrTableCell21.StyleName = "FieldCaption"
        Me.xrTableCell21.Text = "Bank"
        Me.xrTableCell21.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        Me.xrTableCell21.Weight = 31.999996553597683R
        '
        'xrTableCell28
        '
        Me.xrTableCell28.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
        Me.xrTableCell28.CanGrow = False
        Me.xrTableCell28.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.xrTableCell28.ForeColor = System.Drawing.Color.Maroon
        Me.xrTableCell28.Name = "xrTableCell28"
        Me.xrTableCell28.StylePriority.UseBorders = False
        Me.xrTableCell28.StylePriority.UseFont = False
        Me.xrTableCell28.StylePriority.UseForeColor = False
        Me.xrTableCell28.StylePriority.UseTextAlignment = False
        Me.xrTableCell28.Text = "Bank A/c No."
        Me.xrTableCell28.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        Me.xrTableCell28.Weight = 33.615087874455952R
        '
        'xrTableCell23
        '
        Me.xrTableCell23.CanGrow = False
        Me.xrTableCell23.Name = "xrTableCell23"
        Me.xrTableCell23.StyleName = "FieldCaption"
        Me.xrTableCell23.Text = "Amount"
        Me.xrTableCell23.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        Me.xrTableCell23.Weight = 48.285523892197546R
        '
        'xrTableCell25
        '
        Me.xrTableCell25.CanGrow = False
        Me.xrTableCell25.Name = "xrTableCell25"
        Me.xrTableCell25.StyleName = "FieldCaption"
        Me.xrTableCell25.Text = "Instalment"
        Me.xrTableCell25.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        Me.xrTableCell25.Weight = 35.453368502845947R
        '
        'xrTableCell35
        '
        Me.xrTableCell35.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
        Me.xrTableCell35.CanGrow = False
        Me.xrTableCell35.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.xrTableCell35.ForeColor = System.Drawing.Color.Maroon
        Me.xrTableCell35.Name = "xrTableCell35"
        Me.xrTableCell35.StylePriority.UseBorders = False
        Me.xrTableCell35.StylePriority.UseFont = False
        Me.xrTableCell35.StylePriority.UseForeColor = False
        Me.xrTableCell35.StylePriority.UseTextAlignment = False
        Me.xrTableCell35.Text = "Product"
        Me.xrTableCell35.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        Me.xrTableCell35.Weight = 76.758268074862059R
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
        Me.pageFooterBand1.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.xrPageInfo3, Me.xrPageInfo4})
        Me.pageFooterBand1.HeightF = 29.0!
        Me.pageFooterBand1.Name = "pageFooterBand1"
        '
        'xrPageInfo3
        '
        Me.xrPageInfo3.LocationFloat = New DevExpress.Utils.PointFloat(6.0!, 6.0!)
        Me.xrPageInfo3.Name = "xrPageInfo3"
        Me.xrPageInfo3.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrPageInfo3.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime
        Me.xrPageInfo3.SizeF = New System.Drawing.SizeF(313.0!, 23.0!)
        Me.xrPageInfo3.StyleName = "PageInfo"
        '
        'xrPageInfo4
        '
        Me.xrPageInfo4.Format = "Page {0} of {1}"
        Me.xrPageInfo4.LocationFloat = New DevExpress.Utils.PointFloat(331.0!, 6.0!)
        Me.xrPageInfo4.Name = "xrPageInfo4"
        Me.xrPageInfo4.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrPageInfo4.SizeF = New System.Drawing.SizeF(313.0!, 23.0!)
        Me.xrPageInfo4.StyleName = "PageInfo"
        Me.xrPageInfo4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'reportHeaderBand2
        '
        Me.reportHeaderBand2.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.xrLabel1})
        Me.reportHeaderBand2.HeightF = 89.54166!
        Me.reportHeaderBand2.Name = "reportHeaderBand2"
        '
        'xrLabel1
        '
        Me.xrLabel1.LocationFloat = New DevExpress.Utils.PointFloat(6.0!, 6.0!)
        Me.xrLabel1.Name = "xrLabel1"
        Me.xrLabel1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel1.SizeF = New System.Drawing.SizeF(638.0!, 33.0!)
        Me.xrLabel1.StyleName = "Title"
        Me.xrLabel1.Text = "Incoming Disbursements Report"
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
        'topMarginBand2
        '
        Me.topMarginBand2.Name = "topMarginBand2"
        '
        'bottomMarginBand2
        '
        Me.bottomMarginBand2.Name = "bottomMarginBand2"
        '
        'GroupHeader1
        '
        Me.GroupHeader1.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.xrLabel4, Me.xrLabel3})
        Me.GroupHeader1.GroupFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("BRANCH_CODE", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
        Me.GroupHeader1.HeightF = 23.95835!
        Me.GroupHeader1.Name = "GroupHeader1"
        '
        'xrLabel4
        '
        Me.xrLabel4.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold)
        Me.xrLabel4.LocationFloat = New DevExpress.Utils.PointFloat(6.00001!, 0!)
        Me.xrLabel4.Name = "xrLabel4"
        Me.xrLabel4.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel4.SizeF = New System.Drawing.SizeF(63.3208!, 23.0!)
        Me.xrLabel4.StylePriority.UseFont = False
        Me.xrLabel4.Text = "Branch:"
        '
        'xrLabel3
        '
        Me.xrLabel3.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "IncomingDisbursements.BRANCH_NAME")})
        Me.xrLabel3.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold)
        Me.xrLabel3.LocationFloat = New DevExpress.Utils.PointFloat(69.32081!, 0.9583473!)
        Me.xrLabel3.Name = "xrLabel3"
        Me.xrLabel3.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel3.SizeF = New System.Drawing.SizeF(249.6792!, 23.0!)
        Me.xrLabel3.StylePriority.UseFont = False
        '
        'GroupFooter1
        '
        Me.GroupFooter1.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.xrLine1, Me.xrTable3})
        Me.GroupFooter1.HeightF = 35.41667!
        Me.GroupFooter1.Name = "GroupFooter1"
        '
        'xrLine1
        '
        Me.xrLine1.LocationFloat = New DevExpress.Utils.PointFloat(6.00001!, 0!)
        Me.xrLine1.Name = "xrLine1"
        Me.xrLine1.SizeF = New System.Drawing.SizeF(880.0!, 2.083333!)
        '
        'xrTable3
        '
        Me.xrTable3.AnchorVertical = CType((DevExpress.XtraReports.UI.VerticalAnchorStyles.Top Or DevExpress.XtraReports.UI.VerticalAnchorStyles.Bottom), DevExpress.XtraReports.UI.VerticalAnchorStyles)
        Me.xrTable3.LocationFloat = New DevExpress.Utils.PointFloat(6.00001!, 2.083333!)
        Me.xrTable3.Name = "xrTable3"
        Me.xrTable3.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.xrTableRow7})
        Me.xrTable3.SizeF = New System.Drawing.SizeF(733.0001!, 23.0!)
        '
        'xrTableRow7
        '
        Me.xrTableRow7.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.xrTableCell27, Me.xrTableCell29, Me.xrTableCell31, Me.xrTableCell32, Me.xrTableCell33})
        Me.xrTableRow7.Name = "xrTableRow7"
        Me.xrTableRow7.Weight = 1.0R
        '
        'xrTableCell27
        '
        Me.xrTableCell27.CanGrow = False
        Me.xrTableCell27.Font = New System.Drawing.Font("Times New Roman", 10.0!, System.Drawing.FontStyle.Bold)
        Me.xrTableCell27.Name = "xrTableCell27"
        Me.xrTableCell27.StyleName = "DataField"
        Me.xrTableCell27.StylePriority.UseFont = False
        Me.xrTableCell27.StylePriority.UseTextAlignment = False
        Me.xrTableCell27.Text = "Total"
        Me.xrTableCell27.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        Me.xrTableCell27.Weight = 31.560998087213783R
        '
        'xrTableCell29
        '
        Me.xrTableCell29.CanGrow = False
        Me.xrTableCell29.Name = "xrTableCell29"
        Me.xrTableCell29.StyleName = "DataField"
        Me.xrTableCell29.Weight = 137.65018568532994R
        '
        'xrTableCell31
        '
        Me.xrTableCell31.CanGrow = False
        Me.xrTableCell31.Name = "xrTableCell31"
        Me.xrTableCell31.StyleName = "DataField"
        Me.xrTableCell31.Weight = 110.90391966911089R
        '
        'xrTableCell32
        '
        Me.xrTableCell32.CanGrow = False
        Me.xrTableCell32.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "IncomingDisbursements.Amount")})
        Me.xrTableCell32.Font = New System.Drawing.Font("Times New Roman", 10.0!, System.Drawing.FontStyle.Bold)
        Me.xrTableCell32.Name = "xrTableCell32"
        Me.xrTableCell32.StyleName = "DataField"
        Me.xrTableCell32.StylePriority.UseFont = False
        Me.xrTableCell32.StylePriority.UseTextAlignment = False
        xrSummary1.FormatString = "{0:n2}"
        xrSummary1.IgnoreNullValues = True
        xrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
        Me.xrTableCell32.Summary = xrSummary1
        Me.xrTableCell32.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        Me.xrTableCell32.Weight = 48.285504878596555R
        '
        'xrTableCell33
        '
        Me.xrTableCell33.CanGrow = False
        Me.xrTableCell33.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "IncomingDisbursements.Instalment")})
        Me.xrTableCell33.Font = New System.Drawing.Font("Times New Roman", 10.0!, System.Drawing.FontStyle.Bold)
        Me.xrTableCell33.Name = "xrTableCell33"
        Me.xrTableCell33.StyleName = "DataField"
        Me.xrTableCell33.StylePriority.UseFont = False
        Me.xrTableCell33.StylePriority.UseTextAlignment = False
        xrSummary2.FormatString = "{0:n2}"
        xrSummary2.IgnoreNullValues = True
        xrSummary2.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
        Me.xrTableCell33.Summary = xrSummary2
        Me.xrTableCell33.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        Me.xrTableCell33.Weight = 36.948715665089665R
        '
        'brnch
        '
        Me.brnch.Description = "Branch"
        dynamicListLookUpSettings1.DataAdapter = Me.New_BranchesTableAdapter
        dynamicListLookUpSettings1.DataMember = "New_Branches"
        dynamicListLookUpSettings1.DataSource = Me.dsAnalystReports3
        dynamicListLookUpSettings1.DisplayMember = "BNCH_NAME"
        dynamicListLookUpSettings1.ValueMember = "BNCH_CODE"
        Me.brnch.LookUpSettings = dynamicListLookUpSettings1
        Me.brnch.Name = "brnch"
        '
        'incomingDisbursementsTableAdapter1
        '
        Me.incomingDisbursementsTableAdapter1.ClearBeforeFill = True
        '
        'dateFrom
        '
        Me.dateFrom.Name = "dateFrom"
        Me.dateFrom.Type = GetType(Date)
        '
        'dateTo
        '
        Me.dateTo.Name = "dateTo"
        Me.dateTo.Type = GetType(Date)
        '
        'xrptIncomingDisbursements
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.pageHeaderBand1, Me.pageFooterBand1, Me.reportHeaderBand2, Me.topMarginBand2, Me.bottomMarginBand2, Me.GroupHeader1, Me.GroupFooter1})
        Me.DataAdapter = Me.incomingDisbursementsTableAdapter1
        Me.DataMember = "IncomingDisbursements"
        Me.DataSource = Me.dsAnalystReports3
        Me.FilterString = "[BRANCH_CODE] = ?brnch And [MODIFIED_DATE] Between(?dateFrom, ?dateTo)"
        Me.Margins = New System.Drawing.Printing.Margins(100, 0, 100, 100)
        Me.PageWidth = 1000
        Me.PaperKind = System.Drawing.Printing.PaperKind.Custom
        Me.Parameters.AddRange(New DevExpress.XtraReports.Parameters.Parameter() {Me.brnch, Me.dateFrom, Me.dateTo})
        Me.StyleSheet.AddRange(New DevExpress.XtraReports.UI.XRControlStyle() {Me.Title, Me.FieldCaption, Me.PageInfo, Me.DataField})
        Me.Version = "13.2"
        CType(Me.dsAnalystReports3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dsAllReports1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.xrTable2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dsAnalystReports1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dsAnalystReports2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.xrTable1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.xrTable3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub

    Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand

#End Region
    Private Sub xrptIncomingDisbursements_BeforePrint(sender As Object, e As PrintEventArgs) Handles Me.BeforePrint
        If Me.brnch.Value = "ALL" Or Me.brnch.Value = "" Then
            Me.FilterString = "[MODIFIED_DATE] Between(?dateFrom, ?dateTo)"
        Else
            Me.FilterString = "[BRANCH_CODE] = ?brnch And [MODIFIED_DATE] Between(?dateFrom, ?dateTo)"
        End If
    End Sub
End Class