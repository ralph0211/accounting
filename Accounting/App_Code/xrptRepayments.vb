Public Class xrptRepayments
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
    Private WithEvents xrTable2 As DevExpress.XtraReports.UI.XRTable
    Private WithEvents xrTableRow4 As DevExpress.XtraReports.UI.XRTableRow
    Private WithEvents xrTableCell8 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell10 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell12 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell14 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell16 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell18 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell20 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell22 As DevExpress.XtraReports.UI.XRTableCell
    Private dsAnalystReports1 As dsAnalystReports
    Private repaymentsTableAdapter1 As dsAnalystReportsTableAdapters.RepaymentsTableAdapter
    Private WithEvents pageHeaderBand1 As DevExpress.XtraReports.UI.PageHeaderBand
    Private WithEvents xrTable1 As DevExpress.XtraReports.UI.XRTable
    Private WithEvents xrTableRow3 As DevExpress.XtraReports.UI.XRTableRow
    Private WithEvents xrTableCell7 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell9 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell11 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell13 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell15 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell17 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell19 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell21 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableRow1 As DevExpress.XtraReports.UI.XRTableRow
    Private WithEvents xrTableCell1 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell2 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell3 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableRow2 As DevExpress.XtraReports.UI.XRTableRow
    Private WithEvents xrTableCell4 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell5 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell6 As DevExpress.XtraReports.UI.XRTableCell
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
    Private WithEvents xrTableRow5 As DevExpress.XtraReports.UI.XRTableRow
    Private WithEvents xrTableCell23 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell25 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell26 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell27 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell28 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell29 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell30 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents fDate As DevExpress.XtraReports.Parameters.Parameter
    Private WithEvents tDate As DevExpress.XtraReports.Parameters.Parameter
    Private WithEvents dsStaticDetails1 As dsStaticDetails
    Private WithEvents branchesTableAdapter1 As dsAllReportsTableAdapters.BranchesTableAdapter
    Private WithEvents bnch As DevExpress.XtraReports.Parameters.Parameter
    Private WithEvents GroupHeader1 As DevExpress.XtraReports.UI.GroupHeaderBand
    Private WithEvents GroupFooter1 As DevExpress.XtraReports.UI.GroupFooterBand
    Private WithEvents xrTable4 As DevExpress.XtraReports.UI.XRTable
    Private WithEvents xrTableRow6 As DevExpress.XtraReports.UI.XRTableRow
    Private WithEvents xrTableCell24 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell31 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell32 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell33 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell34 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell35 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell36 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrLabel2 As DevExpress.XtraReports.UI.XRLabel

    'Required by the Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Designer
    'It can be modified using the Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resourceFileName As String = "xrptRepayments.resx"
        Dim xrSummary1 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
        Dim xrSummary2 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
        Dim xrSummary3 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
        Dim xrSummary4 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
        Dim xrSummary5 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
        Dim dynamicListLookUpSettings1 As DevExpress.XtraReports.Parameters.DynamicListLookUpSettings = New DevExpress.XtraReports.Parameters.DynamicListLookUpSettings()
        Dim xrSummary6 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
        Dim xrSummary7 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
        Dim xrSummary8 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
        Dim xrSummary9 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
        Dim xrSummary10 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
        Me.branchesTableAdapter1 = New dsAllReportsTableAdapters.BranchesTableAdapter()
        Me.dsStaticDetails1 = New dsStaticDetails()
        Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
        Me.xrTable2 = New DevExpress.XtraReports.UI.XRTable()
        Me.xrTableRow4 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.xrTableCell8 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell10 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell12 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell14 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell16 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell18 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell20 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell22 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.dsAnalystReports1 = New dsAnalystReports()
        Me.repaymentsTableAdapter1 = New dsAnalystReportsTableAdapters.RepaymentsTableAdapter()
        Me.pageHeaderBand1 = New DevExpress.XtraReports.UI.PageHeaderBand()
        Me.xrTable1 = New DevExpress.XtraReports.UI.XRTable()
        Me.xrTableRow3 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.xrTableCell7 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell9 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell11 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell13 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell15 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell17 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell19 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell21 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableRow1 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.xrTableCell1 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell2 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell3 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableRow2 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.xrTableCell4 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell5 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell6 = New DevExpress.XtraReports.UI.XRTableCell()
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
        Me.xrTable3 = New DevExpress.XtraReports.UI.XRTable()
        Me.xrTableRow5 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.xrTableCell23 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell25 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell26 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell27 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell28 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell29 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell30 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.fDate = New DevExpress.XtraReports.Parameters.Parameter()
        Me.tDate = New DevExpress.XtraReports.Parameters.Parameter()
        Me.bnch = New DevExpress.XtraReports.Parameters.Parameter()
        Me.GroupHeader1 = New DevExpress.XtraReports.UI.GroupHeaderBand()
        Me.GroupFooter1 = New DevExpress.XtraReports.UI.GroupFooterBand()
        Me.xrTable4 = New DevExpress.XtraReports.UI.XRTable()
        Me.xrTableRow6 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.xrTableCell24 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell31 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell32 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell33 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell34 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell35 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell36 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrLabel2 = New DevExpress.XtraReports.UI.XRLabel()
        CType(Me.dsStaticDetails1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.xrTable2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dsAnalystReports1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.xrTable1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.xrTable3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.xrTable4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'branchesTableAdapter1
        '
        Me.branchesTableAdapter1.ClearBeforeFill = True
        '
        'dsStaticDetails1
        '
        Me.dsStaticDetails1.DataSetName = "dsStaticDetails"
        Me.dsStaticDetails1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.xrTable2})
        Me.Detail.HeightF = 39.66665!
        Me.Detail.Name = "Detail"
        Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'xrTable2
        '
        Me.xrTable2.AnchorVertical = CType((DevExpress.XtraReports.UI.VerticalAnchorStyles.Top Or DevExpress.XtraReports.UI.VerticalAnchorStyles.Bottom), DevExpress.XtraReports.UI.VerticalAnchorStyles)
        Me.xrTable2.LocationFloat = New DevExpress.Utils.PointFloat(6.0!, 0!)
        Me.xrTable2.Name = "xrTable2"
        Me.xrTable2.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.xrTableRow4})
        Me.xrTable2.SizeF = New System.Drawing.SizeF(637.0!, 39.66665!)
        '
        'xrTableRow4
        '
        Me.xrTableRow4.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.xrTableCell8, Me.xrTableCell10, Me.xrTableCell12, Me.xrTableCell14, Me.xrTableCell16, Me.xrTableCell18, Me.xrTableCell20, Me.xrTableCell22})
        Me.xrTableRow4.Name = "xrTableRow4"
        Me.xrTableRow4.Weight = 1.0R
        '
        'xrTableCell8
        '
        Me.xrTableCell8.CanGrow = False
        Me.xrTableCell8.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Repayments.Name")})
        Me.xrTableCell8.Name = "xrTableCell8"
        Me.xrTableCell8.StyleName = "DataField"
        Me.xrTableCell8.Text = "xrTableCell8"
        Me.xrTableCell8.Weight = 42.659209837781262R
        '
        'xrTableCell10
        '
        Me.xrTableCell10.CanGrow = False
        Me.xrTableCell10.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Repayments.CUSTOMER_NUMBER")})
        Me.xrTableCell10.Name = "xrTableCell10"
        Me.xrTableCell10.StyleName = "DataField"
        Me.xrTableCell10.Text = "xrTableCell10"
        Me.xrTableCell10.Weight = 28.0074568288854R
        '
        'xrTableCell12
        '
        Me.xrTableCell12.CanGrow = False
        Me.xrTableCell12.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Repayments.TrxnDate", "{0:dd MMMM yyyy}")})
        Me.xrTableCell12.Name = "xrTableCell12"
        Me.xrTableCell12.StyleName = "DataField"
        Me.xrTableCell12.Text = "xrTableCell12"
        Me.xrTableCell12.Weight = 25.0R
        '
        'xrTableCell14
        '
        Me.xrTableCell14.CanGrow = False
        Me.xrTableCell14.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Repayments.Principal", "{0:n2}")})
        Me.xrTableCell14.Name = "xrTableCell14"
        Me.xrTableCell14.StyleName = "DataField"
        Me.xrTableCell14.StylePriority.UseTextAlignment = False
        Me.xrTableCell14.Text = "xrTableCell14"
        Me.xrTableCell14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        Me.xrTableCell14.Weight = 22.666666666666668R
        '
        'xrTableCell16
        '
        Me.xrTableCell16.CanGrow = False
        Me.xrTableCell16.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Repayments.Interest", "{0:n2}")})
        Me.xrTableCell16.Name = "xrTableCell16"
        Me.xrTableCell16.StyleName = "DataField"
        Me.xrTableCell16.StylePriority.UseTextAlignment = False
        Me.xrTableCell16.Text = "xrTableCell16"
        Me.xrTableCell16.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        Me.xrTableCell16.Weight = 19.666666666666668R
        '
        'xrTableCell18
        '
        Me.xrTableCell18.CanGrow = False
        Me.xrTableCell18.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Repayments.Admin", "{0:n2}")})
        Me.xrTableCell18.Name = "xrTableCell18"
        Me.xrTableCell18.StyleName = "DataField"
        Me.xrTableCell18.StylePriority.UseTextAlignment = False
        Me.xrTableCell18.Text = "xrTableCell18"
        Me.xrTableCell18.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        Me.xrTableCell18.Weight = 23.220580336063211R
        '
        'xrTableCell20
        '
        Me.xrTableCell20.CanGrow = False
        Me.xrTableCell20.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Repayments.Charges", "{0:n2}")})
        Me.xrTableCell20.Name = "xrTableCell20"
        Me.xrTableCell20.StyleName = "DataField"
        Me.xrTableCell20.StylePriority.UseTextAlignment = False
        Me.xrTableCell20.Text = "xrTableCell20"
        Me.xrTableCell20.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        Me.xrTableCell20.Weight = 19.593109514125661R
        '
        'xrTableCell22
        '
        Me.xrTableCell22.CanGrow = False
        Me.xrTableCell22.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Repayments.TotalAmount", "{0:n2}")})
        Me.xrTableCell22.Name = "xrTableCell22"
        Me.xrTableCell22.StyleName = "DataField"
        Me.xrTableCell22.StylePriority.UseTextAlignment = False
        Me.xrTableCell22.Text = "xrTableCell22"
        Me.xrTableCell22.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        Me.xrTableCell22.Weight = 30.519643483144456R
        '
        'dsAnalystReports1
        '
        Me.dsAnalystReports1.DataSetName = "dsAnalystReports"
        Me.dsAnalystReports1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'repaymentsTableAdapter1
        '
        Me.repaymentsTableAdapter1.ClearBeforeFill = True
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
        Me.xrTable1.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.xrTableRow3})
        Me.xrTable1.SizeF = New System.Drawing.SizeF(637.0!, 36.0!)
        '
        'xrTableRow3
        '
        Me.xrTableRow3.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.xrTableCell7, Me.xrTableCell9, Me.xrTableCell11, Me.xrTableCell13, Me.xrTableCell15, Me.xrTableCell17, Me.xrTableCell19, Me.xrTableCell21})
        Me.xrTableRow3.Name = "xrTableRow3"
        Me.xrTableRow3.Weight = 1.0R
        '
        'xrTableCell7
        '
        Me.xrTableCell7.CanGrow = False
        Me.xrTableCell7.Name = "xrTableCell7"
        Me.xrTableCell7.StyleName = "FieldCaption"
        Me.xrTableCell7.Text = "Name"
        Me.xrTableCell7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        Me.xrTableCell7.Weight = 42.659209837781262R
        '
        'xrTableCell9
        '
        Me.xrTableCell9.CanGrow = False
        Me.xrTableCell9.Name = "xrTableCell9"
        Me.xrTableCell9.StyleName = "FieldCaption"
        Me.xrTableCell9.Text = "Account No"
        Me.xrTableCell9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        Me.xrTableCell9.Weight = 28.0074568288854R
        '
        'xrTableCell11
        '
        Me.xrTableCell11.CanGrow = False
        Me.xrTableCell11.Name = "xrTableCell11"
        Me.xrTableCell11.StyleName = "FieldCaption"
        Me.xrTableCell11.Text = "Date"
        Me.xrTableCell11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        Me.xrTableCell11.Weight = 25.0R
        '
        'xrTableCell13
        '
        Me.xrTableCell13.CanGrow = False
        Me.xrTableCell13.Name = "xrTableCell13"
        Me.xrTableCell13.StyleName = "FieldCaption"
        Me.xrTableCell13.StylePriority.UseTextAlignment = False
        Me.xrTableCell13.Text = "Principal"
        Me.xrTableCell13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.xrTableCell13.Weight = 22.666666666666668R
        '
        'xrTableCell15
        '
        Me.xrTableCell15.CanGrow = False
        Me.xrTableCell15.Name = "xrTableCell15"
        Me.xrTableCell15.StyleName = "FieldCaption"
        Me.xrTableCell15.StylePriority.UseTextAlignment = False
        Me.xrTableCell15.Text = "Interest"
        Me.xrTableCell15.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.xrTableCell15.Weight = 19.666666666666668R
        '
        'xrTableCell17
        '
        Me.xrTableCell17.CanGrow = False
        Me.xrTableCell17.Name = "xrTableCell17"
        Me.xrTableCell17.StyleName = "FieldCaption"
        Me.xrTableCell17.StylePriority.UseTextAlignment = False
        Me.xrTableCell17.Text = "Admin"
        Me.xrTableCell17.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.xrTableCell17.Weight = 23.220580336063211R
        '
        'xrTableCell19
        '
        Me.xrTableCell19.CanGrow = False
        Me.xrTableCell19.Name = "xrTableCell19"
        Me.xrTableCell19.StyleName = "FieldCaption"
        Me.xrTableCell19.StylePriority.UseTextAlignment = False
        Me.xrTableCell19.Text = "Charges"
        Me.xrTableCell19.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.xrTableCell19.Weight = 19.593109514125661R
        '
        'xrTableCell21
        '
        Me.xrTableCell21.CanGrow = False
        Me.xrTableCell21.Name = "xrTableCell21"
        Me.xrTableCell21.StyleName = "FieldCaption"
        Me.xrTableCell21.StylePriority.UseTextAlignment = False
        Me.xrTableCell21.Text = "Total Amount"
        Me.xrTableCell21.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.xrTableCell21.Weight = 30.519643483144456R
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
        Me.reportHeaderBand1.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.xrLabel2, Me.xrLabel1})
        Me.reportHeaderBand1.HeightF = 98.91666!
        Me.reportHeaderBand1.Name = "reportHeaderBand1"
        '
        'xrLabel1
        '
        Me.xrLabel1.LocationFloat = New DevExpress.Utils.PointFloat(6.0!, 6.0!)
        Me.xrLabel1.Name = "xrLabel1"
        Me.xrLabel1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel1.SizeF = New System.Drawing.SizeF(638.0!, 33.0!)
        Me.xrLabel1.StyleName = "Title"
        Me.xrLabel1.Text = "Repayments Report"
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
        Me.ReportFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.xrTable3})
        Me.ReportFooter.HeightF = 43.75!
        Me.ReportFooter.Name = "ReportFooter"
        '
        'xrTable3
        '
        Me.xrTable3.AnchorVertical = CType((DevExpress.XtraReports.UI.VerticalAnchorStyles.Top Or DevExpress.XtraReports.UI.VerticalAnchorStyles.Bottom), DevExpress.XtraReports.UI.VerticalAnchorStyles)
        Me.xrTable3.Borders = DevExpress.XtraPrinting.BorderSide.Top
        Me.xrTable3.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold)
        Me.xrTable3.LocationFloat = New DevExpress.Utils.PointFloat(5.999994!, 0!)
        Me.xrTable3.Name = "xrTable3"
        Me.xrTable3.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.xrTableRow5})
        Me.xrTable3.SizeF = New System.Drawing.SizeF(637.0!, 33.75!)
        Me.xrTable3.StylePriority.UseBorders = False
        Me.xrTable3.StylePriority.UseFont = False
        '
        'xrTableRow5
        '
        Me.xrTableRow5.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.xrTableCell23, Me.xrTableCell25, Me.xrTableCell26, Me.xrTableCell27, Me.xrTableCell28, Me.xrTableCell29, Me.xrTableCell30})
        Me.xrTableRow5.Name = "xrTableRow5"
        Me.xrTableRow5.Weight = 1.0R
        '
        'xrTableCell23
        '
        Me.xrTableCell23.Borders = DevExpress.XtraPrinting.BorderSide.Top
        Me.xrTableCell23.CanGrow = False
        Me.xrTableCell23.Font = New System.Drawing.Font("Times New Roman", 10.0!, System.Drawing.FontStyle.Bold)
        Me.xrTableCell23.Name = "xrTableCell23"
        Me.xrTableCell23.StyleName = "DataField"
        Me.xrTableCell23.StylePriority.UseBorders = False
        Me.xrTableCell23.StylePriority.UseFont = False
        Me.xrTableCell23.StylePriority.UseTextAlignment = False
        Me.xrTableCell23.Text = "Grand Total"
        Me.xrTableCell23.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        Me.xrTableCell23.Weight = 84.129644165358457R
        '
        'xrTableCell25
        '
        Me.xrTableCell25.Borders = DevExpress.XtraPrinting.BorderSide.Top
        Me.xrTableCell25.CanGrow = False
        Me.xrTableCell25.Font = New System.Drawing.Font("Times New Roman", 10.0!, System.Drawing.FontStyle.Bold)
        Me.xrTableCell25.Name = "xrTableCell25"
        Me.xrTableCell25.StyleName = "DataField"
        Me.xrTableCell25.StylePriority.UseBorders = False
        Me.xrTableCell25.StylePriority.UseFont = False
        Me.xrTableCell25.StylePriority.UseTextAlignment = False
        Me.xrTableCell25.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.xrTableCell25.Weight = 11.537022501308208R
        '
        'xrTableCell26
        '
        Me.xrTableCell26.Borders = DevExpress.XtraPrinting.BorderSide.Top
        Me.xrTableCell26.CanGrow = False
        Me.xrTableCell26.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Repayments.Principal")})
        Me.xrTableCell26.Font = New System.Drawing.Font("Times New Roman", 10.0!, System.Drawing.FontStyle.Bold)
        Me.xrTableCell26.Name = "xrTableCell26"
        Me.xrTableCell26.StyleName = "DataField"
        Me.xrTableCell26.StylePriority.UseBorders = False
        Me.xrTableCell26.StylePriority.UseFont = False
        Me.xrTableCell26.StylePriority.UseTextAlignment = False
        xrSummary1.FormatString = "{0:n2}"
        xrSummary1.IgnoreNullValues = True
        xrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Report
        Me.xrTableCell26.Summary = xrSummary1
        Me.xrTableCell26.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.xrTableCell26.Weight = 22.666666666666668R
        '
        'xrTableCell27
        '
        Me.xrTableCell27.Borders = DevExpress.XtraPrinting.BorderSide.Top
        Me.xrTableCell27.CanGrow = False
        Me.xrTableCell27.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Repayments.Interest")})
        Me.xrTableCell27.Font = New System.Drawing.Font("Times New Roman", 10.0!, System.Drawing.FontStyle.Bold)
        Me.xrTableCell27.Name = "xrTableCell27"
        Me.xrTableCell27.StyleName = "DataField"
        Me.xrTableCell27.StylePriority.UseBorders = False
        Me.xrTableCell27.StylePriority.UseFont = False
        Me.xrTableCell27.StylePriority.UseTextAlignment = False
        xrSummary2.FormatString = "{0:n2}"
        xrSummary2.IgnoreNullValues = True
        xrSummary2.Running = DevExpress.XtraReports.UI.SummaryRunning.Report
        Me.xrTableCell27.Summary = xrSummary2
        Me.xrTableCell27.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.xrTableCell27.Weight = 19.666666666666668R
        '
        'xrTableCell28
        '
        Me.xrTableCell28.Borders = DevExpress.XtraPrinting.BorderSide.Top
        Me.xrTableCell28.CanGrow = False
        Me.xrTableCell28.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Repayments.Admin")})
        Me.xrTableCell28.Font = New System.Drawing.Font("Times New Roman", 10.0!, System.Drawing.FontStyle.Bold)
        Me.xrTableCell28.Name = "xrTableCell28"
        Me.xrTableCell28.StyleName = "DataField"
        Me.xrTableCell28.StylePriority.UseBorders = False
        Me.xrTableCell28.StylePriority.UseFont = False
        Me.xrTableCell28.StylePriority.UseTextAlignment = False
        xrSummary3.FormatString = "{0:n2}"
        xrSummary3.IgnoreNullValues = True
        xrSummary3.Running = DevExpress.XtraReports.UI.SummaryRunning.Report
        Me.xrTableCell28.Summary = xrSummary3
        Me.xrTableCell28.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.xrTableCell28.Weight = 23.220580336063211R
        '
        'xrTableCell29
        '
        Me.xrTableCell29.Borders = DevExpress.XtraPrinting.BorderSide.Top
        Me.xrTableCell29.CanGrow = False
        Me.xrTableCell29.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Repayments.Charges")})
        Me.xrTableCell29.Font = New System.Drawing.Font("Times New Roman", 10.0!, System.Drawing.FontStyle.Bold)
        Me.xrTableCell29.Name = "xrTableCell29"
        Me.xrTableCell29.StyleName = "DataField"
        Me.xrTableCell29.StylePriority.UseBorders = False
        Me.xrTableCell29.StylePriority.UseFont = False
        Me.xrTableCell29.StylePriority.UseTextAlignment = False
        xrSummary4.FormatString = "{0:n2}"
        xrSummary4.IgnoreNullValues = True
        xrSummary4.Running = DevExpress.XtraReports.UI.SummaryRunning.Report
        Me.xrTableCell29.Summary = xrSummary4
        Me.xrTableCell29.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.xrTableCell29.Weight = 19.593109514125661R
        '
        'xrTableCell30
        '
        Me.xrTableCell30.Borders = DevExpress.XtraPrinting.BorderSide.Top
        Me.xrTableCell30.CanGrow = False
        Me.xrTableCell30.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Repayments.TotalAmount")})
        Me.xrTableCell30.Font = New System.Drawing.Font("Times New Roman", 10.0!, System.Drawing.FontStyle.Bold)
        Me.xrTableCell30.Name = "xrTableCell30"
        Me.xrTableCell30.StyleName = "DataField"
        Me.xrTableCell30.StylePriority.UseBorders = False
        Me.xrTableCell30.StylePriority.UseFont = False
        Me.xrTableCell30.StylePriority.UseTextAlignment = False
        xrSummary5.FormatString = "{0:n2}"
        xrSummary5.IgnoreNullValues = True
        xrSummary5.Running = DevExpress.XtraReports.UI.SummaryRunning.Report
        Me.xrTableCell30.Summary = xrSummary5
        Me.xrTableCell30.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.xrTableCell30.Weight = 30.519643483144456R
        '
        'fDate
        '
        Me.fDate.Description = "From"
        Me.fDate.Name = "fDate"
        Me.fDate.Type = GetType(Date)
        Me.fDate.ValueInfo = "2017-01-01"
        '
        'tDate
        '
        Me.tDate.Description = "To"
        Me.tDate.Name = "tDate"
        Me.tDate.Type = GetType(Date)
        Me.tDate.ValueInfo = Today.ToLongDateString ' "2017-01-01"
        '
        'bnch
        '
        Me.bnch.Description = "Branch"
        dynamicListLookUpSettings1.DataAdapter = Me.branchesTableAdapter1
        dynamicListLookUpSettings1.DataMember = "Branches"
        dynamicListLookUpSettings1.DataSource = Me.dsStaticDetails1
        dynamicListLookUpSettings1.DisplayMember = "BNCH_NAME"
        dynamicListLookUpSettings1.ValueMember = "BNCH_CODE"
        Me.bnch.LookUpSettings = dynamicListLookUpSettings1
        Me.bnch.Name = "bnch"
        '
        'GroupHeader1
        '
        Me.GroupHeader1.HeightF = 29.16667!
        Me.GroupHeader1.Name = "GroupHeader1"
        '
        'GroupFooter1
        '
        Me.GroupFooter1.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.xrTable4})
        Me.GroupFooter1.HeightF = 41.66667!
        Me.GroupFooter1.Name = "GroupFooter1"
        '
        'xrTable4
        '
        Me.xrTable4.AnchorVertical = CType((DevExpress.XtraReports.UI.VerticalAnchorStyles.Top Or DevExpress.XtraReports.UI.VerticalAnchorStyles.Bottom), DevExpress.XtraReports.UI.VerticalAnchorStyles)
        Me.xrTable4.Borders = DevExpress.XtraPrinting.BorderSide.Top
        Me.xrTable4.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold)
        Me.xrTable4.LocationFloat = New DevExpress.Utils.PointFloat(6.0!, 0!)
        Me.xrTable4.Name = "xrTable4"
        Me.xrTable4.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.xrTableRow6})
        Me.xrTable4.SizeF = New System.Drawing.SizeF(637.0!, 33.75!)
        Me.xrTable4.StylePriority.UseBorders = False
        Me.xrTable4.StylePriority.UseFont = False
        '
        'xrTableRow6
        '
        Me.xrTableRow6.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.xrTableCell24, Me.xrTableCell31, Me.xrTableCell32, Me.xrTableCell33, Me.xrTableCell34, Me.xrTableCell35, Me.xrTableCell36})
        Me.xrTableRow6.Name = "xrTableRow6"
        Me.xrTableRow6.Weight = 1.0R
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
        Me.xrTableCell24.Text = "Total"
        Me.xrTableCell24.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        Me.xrTableCell24.Weight = 84.129644165358457R
        '
        'xrTableCell31
        '
        Me.xrTableCell31.Borders = DevExpress.XtraPrinting.BorderSide.Top
        Me.xrTableCell31.CanGrow = False
        Me.xrTableCell31.Font = New System.Drawing.Font("Times New Roman", 10.0!, System.Drawing.FontStyle.Bold)
        Me.xrTableCell31.Name = "xrTableCell31"
        Me.xrTableCell31.StyleName = "DataField"
        Me.xrTableCell31.StylePriority.UseBorders = False
        Me.xrTableCell31.StylePriority.UseFont = False
        Me.xrTableCell31.StylePriority.UseTextAlignment = False
        Me.xrTableCell31.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.xrTableCell31.Weight = 11.537022501308208R
        '
        'xrTableCell32
        '
        Me.xrTableCell32.Borders = DevExpress.XtraPrinting.BorderSide.Top
        Me.xrTableCell32.CanGrow = False
        Me.xrTableCell32.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Repayments.Principal")})
        Me.xrTableCell32.Font = New System.Drawing.Font("Times New Roman", 10.0!, System.Drawing.FontStyle.Bold)
        Me.xrTableCell32.Name = "xrTableCell32"
        Me.xrTableCell32.StyleName = "DataField"
        Me.xrTableCell32.StylePriority.UseBorders = False
        Me.xrTableCell32.StylePriority.UseFont = False
        Me.xrTableCell32.StylePriority.UseTextAlignment = False
        xrSummary6.FormatString = "{0:n2}"
        xrSummary6.IgnoreNullValues = True
        xrSummary6.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
        Me.xrTableCell32.Summary = xrSummary6
        Me.xrTableCell32.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.xrTableCell32.Weight = 22.666666666666668R
        '
        'xrTableCell33
        '
        Me.xrTableCell33.Borders = DevExpress.XtraPrinting.BorderSide.Top
        Me.xrTableCell33.CanGrow = False
        Me.xrTableCell33.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Repayments.Interest")})
        Me.xrTableCell33.Font = New System.Drawing.Font("Times New Roman", 10.0!, System.Drawing.FontStyle.Bold)
        Me.xrTableCell33.Name = "xrTableCell33"
        Me.xrTableCell33.StyleName = "DataField"
        Me.xrTableCell33.StylePriority.UseBorders = False
        Me.xrTableCell33.StylePriority.UseFont = False
        Me.xrTableCell33.StylePriority.UseTextAlignment = False
        xrSummary7.FormatString = "{0:n2}"
        xrSummary7.IgnoreNullValues = True
        xrSummary7.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
        Me.xrTableCell33.Summary = xrSummary7
        Me.xrTableCell33.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.xrTableCell33.Weight = 19.666666666666668R
        '
        'xrTableCell34
        '
        Me.xrTableCell34.Borders = DevExpress.XtraPrinting.BorderSide.Top
        Me.xrTableCell34.CanGrow = False
        Me.xrTableCell34.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Repayments.Admin")})
        Me.xrTableCell34.Font = New System.Drawing.Font("Times New Roman", 10.0!, System.Drawing.FontStyle.Bold)
        Me.xrTableCell34.Name = "xrTableCell34"
        Me.xrTableCell34.StyleName = "DataField"
        Me.xrTableCell34.StylePriority.UseBorders = False
        Me.xrTableCell34.StylePriority.UseFont = False
        Me.xrTableCell34.StylePriority.UseTextAlignment = False
        xrSummary8.FormatString = "{0:n2}"
        xrSummary8.IgnoreNullValues = True
        xrSummary8.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
        Me.xrTableCell34.Summary = xrSummary8
        Me.xrTableCell34.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.xrTableCell34.Weight = 23.220580336063211R
        '
        'xrTableCell35
        '
        Me.xrTableCell35.Borders = DevExpress.XtraPrinting.BorderSide.Top
        Me.xrTableCell35.CanGrow = False
        Me.xrTableCell35.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Repayments.Charges")})
        Me.xrTableCell35.Font = New System.Drawing.Font("Times New Roman", 10.0!, System.Drawing.FontStyle.Bold)
        Me.xrTableCell35.Name = "xrTableCell35"
        Me.xrTableCell35.StyleName = "DataField"
        Me.xrTableCell35.StylePriority.UseBorders = False
        Me.xrTableCell35.StylePriority.UseFont = False
        Me.xrTableCell35.StylePriority.UseTextAlignment = False
        xrSummary9.FormatString = "{0:n2}"
        xrSummary9.IgnoreNullValues = True
        xrSummary9.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
        Me.xrTableCell35.Summary = xrSummary9
        Me.xrTableCell35.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.xrTableCell35.Weight = 19.593109514125661R
        '
        'xrTableCell36
        '
        Me.xrTableCell36.Borders = DevExpress.XtraPrinting.BorderSide.Top
        Me.xrTableCell36.CanGrow = False
        Me.xrTableCell36.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Repayments.TotalAmount")})
        Me.xrTableCell36.Font = New System.Drawing.Font("Times New Roman", 10.0!, System.Drawing.FontStyle.Bold)
        Me.xrTableCell36.Name = "xrTableCell36"
        Me.xrTableCell36.StyleName = "DataField"
        Me.xrTableCell36.StylePriority.UseBorders = False
        Me.xrTableCell36.StylePriority.UseFont = False
        Me.xrTableCell36.StylePriority.UseTextAlignment = False
        xrSummary10.FormatString = "{0:n2}"
        xrSummary10.IgnoreNullValues = True
        xrSummary10.Running = DevExpress.XtraReports.UI.SummaryRunning.Report
        Me.xrTableCell36.Summary = xrSummary10
        Me.xrTableCell36.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.xrTableCell36.Weight = 30.519643483144456R
        '
        'xrLabel2
        '
        Me.xrLabel2.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold)
        Me.xrLabel2.LocationFloat = New DevExpress.Utils.PointFloat(5.999994!, 65.91666!)
        Me.xrLabel2.Name = "xrLabel2"
        Me.xrLabel2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel2.SizeF = New System.Drawing.SizeF(637.0!, 23.0!)
        Me.xrLabel2.StylePriority.UseFont = False
        Me.xrLabel2.Text = "From [Parameters.fDate!dd MMM yyyy] to [Parameters.tDate!dd MMM yyyy]"
        '
        'xrptRepayments
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.pageHeaderBand1, Me.pageFooterBand1, Me.reportHeaderBand1, Me.topMarginBand1, Me.bottomMarginBand1, Me.ReportFooter, Me.GroupHeader1, Me.GroupFooter1})
        Me.DataAdapter = Me.repaymentsTableAdapter1
        Me.DataMember = "Repayments"
        Me.DataSource = Me.dsAnalystReports1
        Me.FilterString = "[TrxnDate] >= ?fDate And [TrxnDate] <= ?tDate"
        Me.Parameters.AddRange(New DevExpress.XtraReports.Parameters.Parameter() {Me.fDate, Me.tDate, Me.bnch})
        Me.StyleSheet.AddRange(New DevExpress.XtraReports.UI.XRControlStyle() {Me.Title, Me.FieldCaption, Me.PageInfo, Me.DataField})
        Me.Version = "13.2"
        CType(Me.dsStaticDetails1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.xrTable2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dsAnalystReports1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.xrTable1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.xrTable3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.xrTable4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub

    Private Sub xrptRepayments_DataSourceDemanded(sender As Object, e As EventArgs) Handles Me.DataSourceDemanded
        Try
            If bnch.Value = "" Then
                repaymentsTableAdapter1.Fill(dsAnalystReports1.Repayments)
            Else
                repaymentsTableAdapter1.FillByBranch(dsAnalystReports1.Repayments, bnch.Value, fDate.Value, tDate.Value)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand

#End Region

End Class