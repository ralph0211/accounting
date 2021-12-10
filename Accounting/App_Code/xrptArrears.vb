Imports System.Drawing
Imports DevExpress.XtraReports.UI

Public Class xrptArrears
    Inherits DevExpress.XtraReports.UI.XtraReport

#Region " Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub
    Private Sub AddColorCodingFormattingRules(ByVal sections As IEnumerable, ByVal statusColors As Dictionary(Of String, Color))
        For Each s In sections
            Dim cellName = String.Format("xrTableCell{0}", s)
            Dim cell = TryCast(FindControl(cellName, False), XRTableCell)
            If cell Is Nothing Then
                Continue For
            End If
            For Each pair In statusColors
                Dim rule = New FormattingRule With {.Condition = String.Format("[{1}] == '{0}'", pair.Key, s), .Name = String.Format("_formatStatus{1}{0}", pair.Key, s)}
                rule.Formatting.BackColor = pair.Value

                FormattingRuleSheet.Add(rule)
                cell.FormattingRules.Add(rule)
            Next pair
        Next s
    End Sub

    'XtraReport overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub
    Private dsAllReports1 As dsAllReports
    Private arrearsTableAdapter1 As dsAllReportsTableAdapters.ArrearsTableAdapter
    Private WithEvents xrTableRow1 As DevExpress.XtraReports.UI.XRTableRow
    Private WithEvents xrTableCell1 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell2 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell3 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableRow2 As DevExpress.XtraReports.UI.XRTableRow
    Private WithEvents xrTableCell4 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell5 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell6 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents greenLoans As DevExpress.XtraReports.UI.FormattingRule
    Private WithEvents yellowLoans As DevExpress.XtraReports.UI.FormattingRule
    Private WithEvents redLoans As DevExpress.XtraReports.UI.FormattingRule
    Private WithEvents blackest As DevExpress.XtraReports.UI.FormattingRule
    Private WithEvents xrTable2 As DevExpress.XtraReports.UI.XRTable
    Private WithEvents xrTableRow6 As DevExpress.XtraReports.UI.XRTableRow
    Private WithEvents xrTableCell14 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell16 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell18 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell20 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell22 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell24 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell26 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell28 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell30 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell32 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents newArrearsTableAdapter1 As dsAllReportsTableAdapters.NewArrearsTableAdapter
    Private WithEvents newArrearsTableAdapter2 As dsAllReportsTableAdapters.NewArrearsTableAdapter
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
    Private WithEvents xrTableCell27 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell29 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell31 As DevExpress.XtraReports.UI.XRTableCell
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
    Private WithEvents name As DevExpress.XtraReports.UI.CalculatedField
    Private WithEvents xrLabel2 As XRLabel
    Private WithEvents ReportFooter As ReportFooterBand
    Private WithEvents xrTable3 As XRTable
    Private WithEvents xrTableRow7 As XRTableRow
    Private WithEvents xrTableCell33 As XRTableCell
    Private WithEvents xrTableCell41 As XRTableCell
    Private WithEvents xrTableCell42 As XRTableCell

    'Required by the Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Designer
    'It can be modified using the Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resourceFileName As String = "xrptArrears.resx"
        Dim xrSummary1 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
        Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
        Me.xrTable2 = New DevExpress.XtraReports.UI.XRTable()
        Me.xrTableRow6 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.xrTableCell14 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell16 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell18 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell20 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell22 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell24 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell26 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell28 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell30 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell32 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.greenLoans = New DevExpress.XtraReports.UI.FormattingRule()
        Me.yellowLoans = New DevExpress.XtraReports.UI.FormattingRule()
        Me.redLoans = New DevExpress.XtraReports.UI.FormattingRule()
        Me.blackest = New DevExpress.XtraReports.UI.FormattingRule()
        Me.dsAllReports1 = New dsAllReports()
        Me.arrearsTableAdapter1 = New dsAllReportsTableAdapters.ArrearsTableAdapter()
        Me.xrTableRow1 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.xrTableCell1 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell2 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell3 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableRow2 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.xrTableCell4 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell5 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell6 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.newArrearsTableAdapter1 = New dsAllReportsTableAdapters.NewArrearsTableAdapter()
        Me.newArrearsTableAdapter2 = New dsAllReportsTableAdapters.NewArrearsTableAdapter()
        Me.pageHeaderBand1 = New DevExpress.XtraReports.UI.PageHeaderBand()
        Me.xrTable1 = New DevExpress.XtraReports.UI.XRTable()
        Me.xrTableRow5 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.xrTableCell13 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell15 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell17 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell19 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell21 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell23 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell25 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell27 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell29 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell31 = New DevExpress.XtraReports.UI.XRTableCell()
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
        Me.xrLabel2 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel1 = New DevExpress.XtraReports.UI.XRLabel()
        Me.Title = New DevExpress.XtraReports.UI.XRControlStyle()
        Me.FieldCaption = New DevExpress.XtraReports.UI.XRControlStyle()
        Me.PageInfo = New DevExpress.XtraReports.UI.XRControlStyle()
        Me.DataField = New DevExpress.XtraReports.UI.XRControlStyle()
        Me.topMarginBand1 = New DevExpress.XtraReports.UI.TopMarginBand()
        Me.bottomMarginBand1 = New DevExpress.XtraReports.UI.BottomMarginBand()
        Me.name = New DevExpress.XtraReports.UI.CalculatedField()
        Me.ReportFooter = New DevExpress.XtraReports.UI.ReportFooterBand()
        Me.xrTable3 = New DevExpress.XtraReports.UI.XRTable()
        Me.xrTableRow7 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.xrTableCell33 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell41 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell42 = New DevExpress.XtraReports.UI.XRTableCell()
        CType(Me.xrTable2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dsAllReports1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.xrTable1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.xrTable3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.BackColor = System.Drawing.Color.Red
        Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.xrTable2})
        Me.Detail.FormattingRules.Add(Me.greenLoans)
        Me.Detail.FormattingRules.Add(Me.yellowLoans)
        Me.Detail.FormattingRules.Add(Me.redLoans)
        Me.Detail.HeightF = 36.33334!
        Me.Detail.Name = "Detail"
        Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.Detail.StylePriority.UseBackColor = False
        Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'xrTable2
        '
        Me.xrTable2.AnchorVertical = CType((DevExpress.XtraReports.UI.VerticalAnchorStyles.Top Or DevExpress.XtraReports.UI.VerticalAnchorStyles.Bottom), DevExpress.XtraReports.UI.VerticalAnchorStyles)
        Me.xrTable2.BackColor = System.Drawing.Color.Transparent
        Me.xrTable2.LocationFloat = New DevExpress.Utils.PointFloat(5.0!, 0!)
        Me.xrTable2.Name = "xrTable2"
        Me.xrTable2.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.xrTableRow6})
        Me.xrTable2.SizeF = New System.Drawing.SizeF(1056.0!, 36.33334!)
        Me.xrTable2.StylePriority.UseBackColor = False
        '
        'xrTableRow6
        '
        Me.xrTableRow6.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.xrTableCell14, Me.xrTableCell16, Me.xrTableCell18, Me.xrTableCell20, Me.xrTableCell22, Me.xrTableCell24, Me.xrTableCell26, Me.xrTableCell28, Me.xrTableCell30, Me.xrTableCell32})
        Me.xrTableRow6.Name = "xrTableRow6"
        Me.xrTableRow6.Weight = 1.0R
        '
        'xrTableCell14
        '
        Me.xrTableCell14.CanGrow = False
        Me.xrTableCell14.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "NewArrears.CUSTOMER_NUMBER")})
        Me.xrTableCell14.Name = "xrTableCell14"
        Me.xrTableCell14.StyleName = "DataField"
        Me.xrTableCell14.Text = "xrTableCell14"
        Me.xrTableCell14.Weight = 18.610365089636485R
        '
        'xrTableCell16
        '
        Me.xrTableCell16.CanGrow = False
        Me.xrTableCell16.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "NewArrears.name")})
        Me.xrTableCell16.Name = "xrTableCell16"
        Me.xrTableCell16.StyleName = "DataField"
        Me.xrTableCell16.Weight = 31.206791761548924R
        '
        'xrTableCell18
        '
        Me.xrTableCell18.CanGrow = False
        Me.xrTableCell18.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "NewArrears.ID1")})
        Me.xrTableCell18.Name = "xrTableCell18"
        Me.xrTableCell18.StyleName = "DataField"
        Me.xrTableCell18.Text = "xrTableCell18"
        Me.xrTableCell18.Weight = 7.8337274447694387R
        '
        'xrTableCell20
        '
        Me.xrTableCell20.CanGrow = False
        Me.xrTableCell20.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "NewArrears.IDNO")})
        Me.xrTableCell20.Name = "xrTableCell20"
        Me.xrTableCell20.StyleName = "DataField"
        Me.xrTableCell20.Text = "xrTableCell20"
        Me.xrTableCell20.Weight = 10.849115704045151R
        '
        'xrTableCell22
        '
        Me.xrTableCell22.CanGrow = False
        Me.xrTableCell22.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "NewArrears.ADDRESS")})
        Me.xrTableCell22.Name = "xrTableCell22"
        Me.xrTableCell22.StyleName = "DataField"
        Me.xrTableCell22.Text = "xrTableCell22"
        Me.xrTableCell22.Weight = 32.3676399530149R
        '
        'xrTableCell24
        '
        Me.xrTableCell24.CanGrow = False
        Me.xrTableCell24.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "NewArrears.PHONE_NO")})
        Me.xrTableCell24.Name = "xrTableCell24"
        Me.xrTableCell24.StyleName = "DataField"
        Me.xrTableCell24.Text = "xrTableCell24"
        Me.xrTableCell24.Weight = 17.042486976174747R
        '
        'xrTableCell26
        '
        Me.xrTableCell26.CanGrow = False
        Me.xrTableCell26.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "NewArrears.CREATED_BY")})
        Me.xrTableCell26.Name = "xrTableCell26"
        Me.xrTableCell26.StyleName = "DataField"
        Me.xrTableCell26.Text = "xrTableCell26"
        Me.xrTableCell26.Weight = 24.589872921214386R
        '
        'xrTableCell28
        '
        Me.xrTableCell28.CanGrow = False
        Me.xrTableCell28.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "NewArrears.payment_date", "{0:dd MMM,yyyy}")})
        Me.xrTableCell28.Name = "xrTableCell28"
        Me.xrTableCell28.StyleName = "DataField"
        Me.xrTableCell28.Text = "xrTableCell28"
        Me.xrTableCell28.Weight = 18.79739335004021R
        '
        'xrTableCell30
        '
        Me.xrTableCell30.CanGrow = False
        Me.xrTableCell30.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "NewArrears.DaysPast")})
        Me.xrTableCell30.Name = "xrTableCell30"
        Me.xrTableCell30.StyleName = "DataField"
        Me.xrTableCell30.Text = "xrTableCell30"
        Me.xrTableCell30.Weight = 13.64542673148361R
        '
        'xrTableCell32
        '
        Me.xrTableCell32.CanGrow = False
        Me.xrTableCell32.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "NewArrears.instalmentBal", "{0:n2}")})
        Me.xrTableCell32.Name = "xrTableCell32"
        Me.xrTableCell32.StyleName = "DataField"
        Me.xrTableCell32.StylePriority.UseTextAlignment = False
        Me.xrTableCell32.Text = "xrTableCell32"
        Me.xrTableCell32.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        Me.xrTableCell32.Weight = 15.057180068072151R
        '
        'greenLoans
        '
        Me.greenLoans.Condition = "[LateDays] <= 90"
        Me.greenLoans.DataMember = "NewArrears"
        '
        '
        '
        Me.greenLoans.Formatting.BackColor = System.Drawing.Color.Green
        Me.greenLoans.Formatting.BorderColor = System.Drawing.Color.Transparent
        Me.greenLoans.Formatting.Visible = DevExpress.Utils.DefaultBoolean.[True]
        Me.greenLoans.Name = "greenLoans"
        '
        'yellowLoans
        '
        Me.yellowLoans.Condition = "[LateDays] > 90 And [LateDays] <= 180"
        Me.yellowLoans.DataMember = "NewArrears"
        '
        '
        '
        Me.yellowLoans.Formatting.BackColor = System.Drawing.Color.Yellow
        Me.yellowLoans.Formatting.Visible = DevExpress.Utils.DefaultBoolean.[True]
        Me.yellowLoans.Name = "yellowLoans"
        '
        'redLoans
        '
        Me.redLoans.Condition = "[LateDays] > 180"
        Me.redLoans.DataMember = "NewArrears"
        '
        '
        '
        Me.redLoans.Formatting.BackColor = System.Drawing.Color.Red
        Me.redLoans.Formatting.Visible = DevExpress.Utils.DefaultBoolean.[True]
        Me.redLoans.Name = "redLoans"
        '
        'blackest
        '
        '
        '
        '
        Me.blackest.Formatting.BackColor = System.Drawing.Color.Black
        Me.blackest.Name = "blackest"
        '
        'dsAllReports1
        '
        Me.dsAllReports1.DataSetName = "dsAllReports"
        Me.dsAllReports1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'arrearsTableAdapter1
        '
        Me.arrearsTableAdapter1.ClearBeforeFill = True
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
        'newArrearsTableAdapter1
        '
        Me.newArrearsTableAdapter1.ClearBeforeFill = True
        '
        'newArrearsTableAdapter2
        '
        Me.newArrearsTableAdapter2.ClearBeforeFill = True
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
        Me.xrTable1.LocationFloat = New DevExpress.Utils.PointFloat(5.0!, 5.0!)
        Me.xrTable1.Name = "xrTable1"
        Me.xrTable1.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.xrTableRow5})
        Me.xrTable1.SizeF = New System.Drawing.SizeF(1056.0!, 36.0!)
        '
        'xrTableRow5
        '
        Me.xrTableRow5.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.xrTableCell13, Me.xrTableCell15, Me.xrTableCell17, Me.xrTableCell19, Me.xrTableCell21, Me.xrTableCell23, Me.xrTableCell25, Me.xrTableCell27, Me.xrTableCell29, Me.xrTableCell31})
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
        Me.xrTableCell13.Weight = 18.610365089636485R
        '
        'xrTableCell15
        '
        Me.xrTableCell15.CanGrow = False
        Me.xrTableCell15.Name = "xrTableCell15"
        Me.xrTableCell15.StyleName = "FieldCaption"
        Me.xrTableCell15.Text = "Name"
        Me.xrTableCell15.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        Me.xrTableCell15.Weight = 31.206791761548924R
        '
        'xrTableCell17
        '
        Me.xrTableCell17.CanGrow = False
        Me.xrTableCell17.Name = "xrTableCell17"
        Me.xrTableCell17.StyleName = "FieldCaption"
        Me.xrTableCell17.Text = "Loan ID"
        Me.xrTableCell17.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        Me.xrTableCell17.Weight = 7.8337274447694387R
        '
        'xrTableCell19
        '
        Me.xrTableCell19.CanGrow = False
        Me.xrTableCell19.Name = "xrTableCell19"
        Me.xrTableCell19.StyleName = "FieldCaption"
        Me.xrTableCell19.Text = "ID Number"
        Me.xrTableCell19.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        Me.xrTableCell19.Weight = 10.849115704045151R
        '
        'xrTableCell21
        '
        Me.xrTableCell21.CanGrow = False
        Me.xrTableCell21.Name = "xrTableCell21"
        Me.xrTableCell21.StyleName = "FieldCaption"
        Me.xrTableCell21.Text = "Address"
        Me.xrTableCell21.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        Me.xrTableCell21.Weight = 32.3676399530149R
        '
        'xrTableCell23
        '
        Me.xrTableCell23.CanGrow = False
        Me.xrTableCell23.Name = "xrTableCell23"
        Me.xrTableCell23.StyleName = "FieldCaption"
        Me.xrTableCell23.Text = "Phone Number"
        Me.xrTableCell23.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        Me.xrTableCell23.Weight = 17.042486976174747R
        '
        'xrTableCell25
        '
        Me.xrTableCell25.CanGrow = False
        Me.xrTableCell25.Name = "xrTableCell25"
        Me.xrTableCell25.StyleName = "FieldCaption"
        Me.xrTableCell25.Text = "Loan Officer"
        Me.xrTableCell25.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        Me.xrTableCell25.Weight = 24.589872921214386R
        '
        'xrTableCell27
        '
        Me.xrTableCell27.CanGrow = False
        Me.xrTableCell27.Name = "xrTableCell27"
        Me.xrTableCell27.StyleName = "FieldCaption"
        Me.xrTableCell27.Text = "Due Date"
        Me.xrTableCell27.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        Me.xrTableCell27.Weight = 18.79739335004021R
        '
        'xrTableCell29
        '
        Me.xrTableCell29.CanGrow = False
        Me.xrTableCell29.Name = "xrTableCell29"
        Me.xrTableCell29.StyleName = "FieldCaption"
        Me.xrTableCell29.Text = "Late Days"
        Me.xrTableCell29.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        Me.xrTableCell29.Weight = 13.64542673148361R
        '
        'xrTableCell31
        '
        Me.xrTableCell31.CanGrow = False
        Me.xrTableCell31.Name = "xrTableCell31"
        Me.xrTableCell31.StyleName = "FieldCaption"
        Me.xrTableCell31.StylePriority.UseTextAlignment = False
        Me.xrTableCell31.Text = "Outstanding Balance"
        Me.xrTableCell31.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.xrTableCell31.Weight = 15.057180068072151R
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
        Me.xrPageInfo1.SizeF = New System.Drawing.SizeF(377.0!, 23.0!)
        Me.xrPageInfo1.StyleName = "PageInfo"
        '
        'xrPageInfo2
        '
        Me.xrPageInfo2.Format = "Page {0} of {1}"
        Me.xrPageInfo2.LocationFloat = New DevExpress.Utils.PointFloat(392.0!, 5.0!)
        Me.xrPageInfo2.Name = "xrPageInfo2"
        Me.xrPageInfo2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrPageInfo2.SizeF = New System.Drawing.SizeF(669.0!, 23.0!)
        Me.xrPageInfo2.StyleName = "PageInfo"
        Me.xrPageInfo2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'reportHeaderBand1
        '
        Me.reportHeaderBand1.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.xrLabel2, Me.xrLabel1})
        Me.reportHeaderBand1.HeightF = 88.83334!
        Me.reportHeaderBand1.Name = "reportHeaderBand1"
        '
        'xrLabel2
        '
        Me.xrLabel2.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold)
        Me.xrLabel2.LocationFloat = New DevExpress.Utils.PointFloat(5.0!, 55.83333!)
        Me.xrLabel2.Name = "xrLabel2"
        Me.xrLabel2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel2.SizeF = New System.Drawing.SizeF(637.0!, 23.0!)
        Me.xrLabel2.StylePriority.UseFont = False
        Me.xrLabel2.Text = "As at [Parameters.toDate!dd MMM yyyy]"
        '
        'xrLabel1
        '
        Me.xrLabel1.LocationFloat = New DevExpress.Utils.PointFloat(5.0!, 5.0!)
        Me.xrLabel1.Name = "xrLabel1"
        Me.xrLabel1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel1.SizeF = New System.Drawing.SizeF(765.0!, 33.0!)
        Me.xrLabel1.StyleName = "Title"
        Me.xrLabel1.Text = "Arrears Report"
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
        'name
        '
        Me.name.DataMember = "NewArrears"
        Me.name.Expression = "[FORENAMES] + ' ' + [SURNAME]"
        Me.name.Name = "name"
        '
        'ReportFooter
        '
        Me.ReportFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.xrTable3})
        Me.ReportFooter.HeightF = 41.66667!
        Me.ReportFooter.Name = "ReportFooter"
        '
        'xrTable3
        '
        Me.xrTable3.AnchorVertical = CType((DevExpress.XtraReports.UI.VerticalAnchorStyles.Top Or DevExpress.XtraReports.UI.VerticalAnchorStyles.Bottom), DevExpress.XtraReports.UI.VerticalAnchorStyles)
        Me.xrTable3.BackColor = System.Drawing.Color.Transparent
        Me.xrTable3.LocationFloat = New DevExpress.Utils.PointFloat(5.000003!, 0!)
        Me.xrTable3.Name = "xrTable3"
        Me.xrTable3.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.xrTableRow7})
        Me.xrTable3.SizeF = New System.Drawing.SizeF(1056.0!, 36.33334!)
        Me.xrTable3.StylePriority.UseBackColor = False
        '
        'xrTableRow7
        '
        Me.xrTableRow7.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.xrTableCell33, Me.xrTableCell41, Me.xrTableCell42})
        Me.xrTableRow7.Name = "xrTableRow7"
        Me.xrTableRow7.Weight = 1.0R
        '
        'xrTableCell33
        '
        Me.xrTableCell33.Borders = DevExpress.XtraPrinting.BorderSide.Top
        Me.xrTableCell33.CanGrow = False
        Me.xrTableCell33.Font = New System.Drawing.Font("Times New Roman", 10.0!, System.Drawing.FontStyle.Bold)
        Me.xrTableCell33.Name = "xrTableCell33"
        Me.xrTableCell33.StyleName = "DataField"
        Me.xrTableCell33.StylePriority.UseBorders = False
        Me.xrTableCell33.StylePriority.UseFont = False
        Me.xrTableCell33.Text = "Total"
        Me.xrTableCell33.Weight = 18.610365089636485R
        '
        'xrTableCell41
        '
        Me.xrTableCell41.Borders = DevExpress.XtraPrinting.BorderSide.Top
        Me.xrTableCell41.CanGrow = False
        Me.xrTableCell41.Font = New System.Drawing.Font("Times New Roman", 10.0!, System.Drawing.FontStyle.Bold)
        Me.xrTableCell41.Name = "xrTableCell41"
        Me.xrTableCell41.StyleName = "DataField"
        Me.xrTableCell41.StylePriority.UseBorders = False
        Me.xrTableCell41.StylePriority.UseFont = False
        Me.xrTableCell41.Weight = 156.33245484229136R
        '
        'xrTableCell42
        '
        Me.xrTableCell42.Borders = DevExpress.XtraPrinting.BorderSide.Top
        Me.xrTableCell42.CanGrow = False
        Me.xrTableCell42.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "NewArrears.instalmentBal")})
        Me.xrTableCell42.Font = New System.Drawing.Font("Times New Roman", 10.0!, System.Drawing.FontStyle.Bold)
        Me.xrTableCell42.Name = "xrTableCell42"
        Me.xrTableCell42.StyleName = "DataField"
        Me.xrTableCell42.StylePriority.UseBorders = False
        Me.xrTableCell42.StylePriority.UseFont = False
        Me.xrTableCell42.StylePriority.UseTextAlignment = False
        xrSummary1.FormatString = "{0:n2}"
        xrSummary1.IgnoreNullValues = True
        xrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Report
        Me.xrTableCell42.Summary = xrSummary1
        Me.xrTableCell42.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        Me.xrTableCell42.Weight = 15.057180068072151R
        '
        'xrptArrears
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.pageHeaderBand1, Me.pageFooterBand1, Me.reportHeaderBand1, Me.topMarginBand1, Me.bottomMarginBand1, Me.ReportFooter})
        Me.CalculatedFields.AddRange(New DevExpress.XtraReports.UI.CalculatedField() {Me.name})
        Me.DataAdapter = Me.newArrearsTableAdapter2
        Me.DataMember = "NewArrears"
        Me.DataSource = Me.dsAllReports1
        Me.FilterString = "[instalmentBal] > 0.0m"
        Me.FormattingRuleSheet.AddRange(New DevExpress.XtraReports.UI.FormattingRule() {Me.greenLoans, Me.yellowLoans, Me.redLoans, Me.blackest})
        Me.Landscape = True
        Me.Margins = New System.Drawing.Printing.Margins(12, 27, 100, 100)
        Me.PageHeight = 850
        Me.PageWidth = 1100
        Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
        Me.StyleSheet.AddRange(New DevExpress.XtraReports.UI.XRControlStyle() {Me.Title, Me.FieldCaption, Me.PageInfo, Me.DataField})
        Me.Version = "13.2"
        CType(Me.xrTable2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dsAllReports1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.xrTable1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.xrTable3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand

#End Region

End Class