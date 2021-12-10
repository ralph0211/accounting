Public Class xrptDelinquency
    Inherits DevExpress.XtraReports.UI.XtraReport

#Region " Designer generated code "

    Private WithEvents bottomMarginBand1 As DevExpress.XtraReports.UI.BottomMarginBand

    Private WithEvents DataField As DevExpress.XtraReports.UI.XRControlStyle

    Private WithEvents delinquencyTableAdapter1 As dsAllReportsTableAdapters.DelinquencyTableAdapter

    Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand

    Private WithEvents dsAllReports1 As dsAllReports

    Private WithEvents FieldCaption As DevExpress.XtraReports.UI.XRControlStyle

    Private WithEvents pageFooterBand1 As DevExpress.XtraReports.UI.PageFooterBand

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
    Private WithEvents toDate As DevExpress.XtraReports.Parameters.Parameter
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
    Private WithEvents xrTableCell24 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell26 As DevExpress.XtraReports.UI.XRTableCell
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
    Private WithEvents xrTableCell23 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell25 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableRow1 As DevExpress.XtraReports.UI.XRTableRow
    Private WithEvents xrTableCell1 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell2 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell3 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableRow2 As DevExpress.XtraReports.UI.XRTableRow
    Private WithEvents xrTableCell4 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell5 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell6 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrPageInfo1 As DevExpress.XtraReports.UI.XRPageInfo
    Private WithEvents xrPageInfo2 As DevExpress.XtraReports.UI.XRPageInfo
    Private WithEvents reportHeaderBand1 As DevExpress.XtraReports.UI.ReportHeaderBand
    Private WithEvents xrLabel1 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents Title As DevExpress.XtraReports.UI.XRControlStyle
    Private WithEvents PageInfo As DevExpress.XtraReports.UI.XRControlStyle
    Private WithEvents topMarginBand1 As DevExpress.XtraReports.UI.TopMarginBand
    Private WithEvents xrLabel2 As DevExpress.XtraReports.UI.XRLabel

    'Required by the Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Designer
    'It can be modified using the Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resourceFileName As String = "xrptDelinquency.resx"
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
        Me.xrTableCell24 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell26 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.dsAllReports1 = New dsAllReports()
        Me.delinquencyTableAdapter1 = New dsAllReportsTableAdapters.DelinquencyTableAdapter()
        Me.toDate = New DevExpress.XtraReports.Parameters.Parameter()
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
        Me.xrTableCell23 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell25 = New DevExpress.XtraReports.UI.XRTableCell()
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
        Me.xrLabel2 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel1 = New DevExpress.XtraReports.UI.XRLabel()
        Me.Title = New DevExpress.XtraReports.UI.XRControlStyle()
        Me.FieldCaption = New DevExpress.XtraReports.UI.XRControlStyle()
        Me.PageInfo = New DevExpress.XtraReports.UI.XRControlStyle()
        Me.DataField = New DevExpress.XtraReports.UI.XRControlStyle()
        Me.topMarginBand1 = New DevExpress.XtraReports.UI.TopMarginBand()
        Me.bottomMarginBand1 = New DevExpress.XtraReports.UI.BottomMarginBand()
        CType(Me.xrTable2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dsAllReports1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.xrTable1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.xrTable2})
        Me.Detail.HeightF = 37.58335!
        Me.Detail.Name = "Detail"
        Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.Detail.StyleName = "DataField"
        Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'xrTable2
        '
        Me.xrTable2.AnchorVertical = CType((DevExpress.XtraReports.UI.VerticalAnchorStyles.Top Or DevExpress.XtraReports.UI.VerticalAnchorStyles.Bottom), DevExpress.XtraReports.UI.VerticalAnchorStyles)
        Me.xrTable2.LocationFloat = New DevExpress.Utils.PointFloat(6.000002!, 0.0!)
        Me.xrTable2.Name = "xrTable2"
        Me.xrTable2.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.xrTableRow4})
        Me.xrTable2.SizeF = New System.Drawing.SizeF(1033.0!, 37.58335!)
        '
        'xrTableRow4
        '
        Me.xrTableRow4.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.xrTableCell8, Me.xrTableCell10, Me.xrTableCell12, Me.xrTableCell14, Me.xrTableCell16, Me.xrTableCell18, Me.xrTableCell20, Me.xrTableCell22, Me.xrTableCell24, Me.xrTableCell26})
        Me.xrTableRow4.Name = "xrTableRow4"
        Me.xrTableRow4.Weight = 1.0R
        '
        'xrTableCell8
        '
        Me.xrTableCell8.CanGrow = False
        Me.xrTableCell8.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Delinquency.customer_number")})
        Me.xrTableCell8.Name = "xrTableCell8"
        Me.xrTableCell8.StyleName = "DataField"
        Me.xrTableCell8.Text = "xrTableCell8"
        Me.xrTableCell8.Weight = 16.473537934793008R
        '
        'xrTableCell10
        '
        Me.xrTableCell10.CanGrow = False
        Me.xrTableCell10.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Delinquency.Name")})
        Me.xrTableCell10.Name = "xrTableCell10"
        Me.xrTableCell10.StyleName = "DataField"
        Me.xrTableCell10.Text = "xrTableCell10"
        Me.xrTableCell10.Weight = 34.026462065206992R
        '
        'xrTableCell12
        '
        Me.xrTableCell12.CanGrow = False
        Me.xrTableCell12.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Delinquency.IDNO")})
        Me.xrTableCell12.Name = "xrTableCell12"
        Me.xrTableCell12.StyleName = "DataField"
        Me.xrTableCell12.Text = "xrTableCell12"
        Me.xrTableCell12.Weight = 21.50129182710306R
        '
        'xrTableCell14
        '
        Me.xrTableCell14.CanGrow = False
        Me.xrTableCell14.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Delinquency.Address")})
        Me.xrTableCell14.Name = "xrTableCell14"
        Me.xrTableCell14.StyleName = "DataField"
        Me.xrTableCell14.Text = "xrTableCell14"
        Me.xrTableCell14.Weight = 31.371247157699717R
        '
        'xrTableCell16
        '
        Me.xrTableCell16.CanGrow = False
        Me.xrTableCell16.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Delinquency.CITY")})
        Me.xrTableCell16.Name = "xrTableCell16"
        Me.xrTableCell16.StyleName = "DataField"
        Me.xrTableCell16.Text = "xrTableCell16"
        Me.xrTableCell16.Weight = 19.487407122150461R
        '
        'xrTableCell18
        '
        Me.xrTableCell18.CanGrow = False
        Me.xrTableCell18.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Delinquency.disbursed_date", "{0:dd MMM yyyy}")})
        Me.xrTableCell18.Name = "xrTableCell18"
        Me.xrTableCell18.StyleName = "DataField"
        Me.xrTableCell18.Text = "xrTableCell18"
        Me.xrTableCell18.Weight = 23.722528307557852R
        '
        'xrTableCell20
        '
        Me.xrTableCell20.CanGrow = False
        Me.xrTableCell20.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Delinquency.FIN_TENOR")})
        Me.xrTableCell20.Name = "xrTableCell20"
        Me.xrTableCell20.StyleName = "DataField"
        Me.xrTableCell20.Text = "xrTableCell20"
        Me.xrTableCell20.Weight = 12.947912240813727R
        '
        'xrTableCell22
        '
        Me.xrTableCell22.CanGrow = False
        Me.xrTableCell22.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Delinquency.fin_amt", "{0:n2}")})
        Me.xrTableCell22.Name = "xrTableCell22"
        Me.xrTableCell22.StyleName = "DataField"
        Me.xrTableCell22.Text = "xrTableCell22"
        Me.xrTableCell22.Weight = 18.702407634506852R
        '
        'xrTableCell24
        '
        Me.xrTableCell24.CanGrow = False
        Me.xrTableCell24.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Delinquency.LoanBalance", "{0:n2}")})
        Me.xrTableCell24.Name = "xrTableCell24"
        Me.xrTableCell24.StyleName = "DataField"
        Me.xrTableCell24.Text = "xrTableCell24"
        Me.xrTableCell24.Weight = 23.237246200598651R
        '
        'xrTableCell26
        '
        Me.xrTableCell26.CanGrow = False
        Me.xrTableCell26.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Delinquency.DaysOverdue")})
        Me.xrTableCell26.Name = "xrTableCell26"
        Me.xrTableCell26.StyleName = "DataField"
        Me.xrTableCell26.Text = "xrTableCell26"
        Me.xrTableCell26.Weight = 19.529959509569682R
        '
        'dsAllReports1
        '
        Me.dsAllReports1.DataSetName = "dsAllReports"
        Me.dsAllReports1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'delinquencyTableAdapter1
        '
        Me.delinquencyTableAdapter1.ClearBeforeFill = True
        '
        'toDate
        '
        Me.toDate.Description = "To Date"
        Me.toDate.Name = "toDate"
        Me.toDate.Type = GetType(Date)
        Me.toDate.ValueInfo = Date.Now.ToLongDateString ' "2016-01-25"
        '
        'pageHeaderBand1
        '
        Me.pageHeaderBand1.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.xrTable1})
        Me.pageHeaderBand1.HeightF = 42.00001!
        Me.pageHeaderBand1.Name = "pageHeaderBand1"
        '
        'xrTable1
        '
        Me.xrTable1.AnchorVertical = DevExpress.XtraReports.UI.VerticalAnchorStyles.Bottom
        Me.xrTable1.LocationFloat = New DevExpress.Utils.PointFloat(6.000002!, 6.00001!)
        Me.xrTable1.Name = "xrTable1"
        Me.xrTable1.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.xrTableRow3})
        Me.xrTable1.SizeF = New System.Drawing.SizeF(1033.0!, 36.0!)
        '
        'xrTableRow3
        '
        Me.xrTableRow3.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.xrTableCell7, Me.xrTableCell9, Me.xrTableCell11, Me.xrTableCell13, Me.xrTableCell15, Me.xrTableCell17, Me.xrTableCell19, Me.xrTableCell21, Me.xrTableCell23, Me.xrTableCell25})
        Me.xrTableRow3.Name = "xrTableRow3"
        Me.xrTableRow3.Weight = 1.0R
        '
        'xrTableCell7
        '
        Me.xrTableCell7.CanGrow = False
        Me.xrTableCell7.Name = "xrTableCell7"
        Me.xrTableCell7.StyleName = "FieldCaption"
        Me.xrTableCell7.Text = "Account"
        Me.xrTableCell7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        Me.xrTableCell7.Weight = 16.473537934793008R
        '
        'xrTableCell9
        '
        Me.xrTableCell9.CanGrow = False
        Me.xrTableCell9.Name = "xrTableCell9"
        Me.xrTableCell9.StyleName = "FieldCaption"
        Me.xrTableCell9.Text = "Name"
        Me.xrTableCell9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        Me.xrTableCell9.Weight = 34.026462065206992R
        '
        'xrTableCell11
        '
        Me.xrTableCell11.CanGrow = False
        Me.xrTableCell11.Name = "xrTableCell11"
        Me.xrTableCell11.StyleName = "FieldCaption"
        Me.xrTableCell11.Text = "ID Number"
        Me.xrTableCell11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        Me.xrTableCell11.Weight = 21.50129182710306R
        '
        'xrTableCell13
        '
        Me.xrTableCell13.CanGrow = False
        Me.xrTableCell13.Name = "xrTableCell13"
        Me.xrTableCell13.StyleName = "FieldCaption"
        Me.xrTableCell13.Text = "Address"
        Me.xrTableCell13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        Me.xrTableCell13.Weight = 31.371247157699717R
        '
        'xrTableCell15
        '
        Me.xrTableCell15.CanGrow = False
        Me.xrTableCell15.Name = "xrTableCell15"
        Me.xrTableCell15.StyleName = "FieldCaption"
        Me.xrTableCell15.Text = "City"
        Me.xrTableCell15.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        Me.xrTableCell15.Weight = 19.487407122150461R
        '
        'xrTableCell17
        '
        Me.xrTableCell17.CanGrow = False
        Me.xrTableCell17.Name = "xrTableCell17"
        Me.xrTableCell17.StyleName = "FieldCaption"
        Me.xrTableCell17.Text = "Disbursed Date"
        Me.xrTableCell17.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        Me.xrTableCell17.Weight = 23.722528307557852R
        '
        'xrTableCell19
        '
        Me.xrTableCell19.CanGrow = False
        Me.xrTableCell19.Name = "xrTableCell19"
        Me.xrTableCell19.StyleName = "FieldCaption"
        Me.xrTableCell19.Text = "Tenure"
        Me.xrTableCell19.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        Me.xrTableCell19.Weight = 12.947912240813727R
        '
        'xrTableCell21
        '
        Me.xrTableCell21.CanGrow = False
        Me.xrTableCell21.Name = "xrTableCell21"
        Me.xrTableCell21.StyleName = "FieldCaption"
        Me.xrTableCell21.Text = "Loan Amount"
        Me.xrTableCell21.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        Me.xrTableCell21.Weight = 18.702407634506852R
        '
        'xrTableCell23
        '
        Me.xrTableCell23.CanGrow = False
        Me.xrTableCell23.Name = "xrTableCell23"
        Me.xrTableCell23.StyleName = "FieldCaption"
        Me.xrTableCell23.Text = "Loan Balance"
        Me.xrTableCell23.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        Me.xrTableCell23.Weight = 23.237246200598651R
        '
        'xrTableCell25
        '
        Me.xrTableCell25.CanGrow = False
        Me.xrTableCell25.Name = "xrTableCell25"
        Me.xrTableCell25.StyleName = "FieldCaption"
        Me.xrTableCell25.Text = "Days Overdue"
        Me.xrTableCell25.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        Me.xrTableCell25.Weight = 19.529959509569682R
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
        Me.pageFooterBand1.HeightF = 133.4167!
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
        Me.xrPageInfo2.LocationFloat = New DevExpress.Utils.PointFloat(456.0!, 6.00001!)
        Me.xrPageInfo2.Name = "xrPageInfo2"
        Me.xrPageInfo2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrPageInfo2.SizeF = New System.Drawing.SizeF(583.0!, 23.0!)
        Me.xrPageInfo2.StyleName = "PageInfo"
        Me.xrPageInfo2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'reportHeaderBand1
        '
        Me.reportHeaderBand1.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.xrLabel2, Me.xrLabel1})
        Me.reportHeaderBand1.HeightF = 104.125!
        Me.reportHeaderBand1.Name = "reportHeaderBand1"
        '
        'xrLabel2
        '
        Me.xrLabel2.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold)
        Me.xrLabel2.LocationFloat = New DevExpress.Utils.PointFloat(6.000002!, 71.125!)
        Me.xrLabel2.Name = "xrLabel2"
        Me.xrLabel2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel2.SizeF = New System.Drawing.SizeF(562.75!, 23.0!)
        Me.xrLabel2.StylePriority.UseFont = False
        Me.xrLabel2.Text = "As At: [Parameters.toDate!dd MMMM yyyy]"
        '
        'xrLabel1
        '
        Me.xrLabel1.LocationFloat = New DevExpress.Utils.PointFloat(6.0!, 6.0!)
        Me.xrLabel1.Name = "xrLabel1"
        Me.xrLabel1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel1.SizeF = New System.Drawing.SizeF(888.0!, 33.0!)
        Me.xrLabel1.StyleName = "Title"
        Me.xrLabel1.Text = "Delinquency Report"
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
        'xrptDelinquency
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.pageHeaderBand1, Me.pageFooterBand1, Me.reportHeaderBand1, Me.topMarginBand1, Me.bottomMarginBand1})
        Me.DataAdapter = Me.delinquencyTableAdapter1
        Me.DataMember = "Delinquency"
        Me.DataSource = Me.dsAllReports1
        Me.Landscape = True
        Me.Margins = New System.Drawing.Printing.Margins(25, 26, 100, 100)
        Me.PageHeight = 850
        Me.PageWidth = 1100
        Me.Parameters.AddRange(New DevExpress.XtraReports.Parameters.Parameter() {Me.toDate})
        Me.StyleSheet.AddRange(New DevExpress.XtraReports.UI.XRControlStyle() {Me.Title, Me.FieldCaption, Me.PageInfo, Me.DataField})
        Me.Version = "13.2"
        CType(Me.xrTable2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dsAllReports1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.xrTable1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
#End Region

    Private Sub xrptDelinquency_DataSourceDemanded(sender As Object, e As EventArgs) Handles Me.DataSourceDemanded
        delinquencyTableAdapter1.FillByDate(dsAllReports1.Delinquency, Me.toDate.Value)
    End Sub
End Class