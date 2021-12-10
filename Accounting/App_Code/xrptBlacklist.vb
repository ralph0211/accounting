Public Class xrptBlacklist
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
    Private WithEvents blacklistTableAdapter1 As dsAllReportsTableAdapters.BlacklistTableAdapter
    Private WithEvents xrTableRow3 As DevExpress.XtraReports.UI.XRTableRow
    Private WithEvents xrTableCell7 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell8 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell9 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableRow4 As DevExpress.XtraReports.UI.XRTableRow
    Private WithEvents xrTableCell10 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell11 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell12 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents blacklistTableAdapter2 As dsAllReportsTableAdapters.BlacklistTableAdapter
    Private WithEvents xrTable2 As DevExpress.XtraReports.UI.XRTable
    Private WithEvents xrTableRow8 As DevExpress.XtraReports.UI.XRTableRow
    Private WithEvents xrTableCell20 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell22 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell24 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell26 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell28 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell30 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell32 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell34 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents dsAllReports2 As dsAllReports
    Private WithEvents dsAllReports3 As dsAllReports
    Private WithEvents pageHeaderBand1 As DevExpress.XtraReports.UI.PageHeaderBand
    Private WithEvents xrTable1 As DevExpress.XtraReports.UI.XRTable
    Private WithEvents xrTableRow7 As DevExpress.XtraReports.UI.XRTableRow
    Private WithEvents xrTableCell19 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell21 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell23 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell25 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell27 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell29 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell31 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell33 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableRow5 As DevExpress.XtraReports.UI.XRTableRow
    Private WithEvents xrTableCell13 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell14 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell15 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableRow6 As DevExpress.XtraReports.UI.XRTableRow
    Private WithEvents xrTableCell16 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell17 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell18 As DevExpress.XtraReports.UI.XRTableCell
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
    Private WithEvents fDate As DevExpress.XtraReports.Parameters.Parameter
    Private WithEvents tDate As DevExpress.XtraReports.Parameters.Parameter
    Private WithEvents blDate As DevExpress.XtraReports.UI.CalculatedField
    Private WithEvents xrLabel2 As DevExpress.XtraReports.UI.XRLabel

    'Required by the Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Designer
    'It can be modified using the Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resourceFileName As String = "xrptBlacklist.resx"
        Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
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
        Me.blacklistTableAdapter1 = New dsAllReportsTableAdapters.BlacklistTableAdapter()
        Me.xrTableRow3 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.xrTableCell7 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell8 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell9 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableRow4 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.xrTableCell10 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell11 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell12 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.blacklistTableAdapter2 = New dsAllReportsTableAdapters.BlacklistTableAdapter()
        Me.dsAllReports2 = New dsAllReports()
        Me.dsAllReports3 = New dsAllReports()
        Me.pageHeaderBand1 = New DevExpress.XtraReports.UI.PageHeaderBand()
        Me.xrTable1 = New DevExpress.XtraReports.UI.XRTable()
        Me.xrTableRow5 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.xrTableCell13 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell14 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell15 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTable2 = New DevExpress.XtraReports.UI.XRTable()
        Me.xrTableRow6 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.xrTableCell16 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell17 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell18 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableRow7 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.xrTableRow8 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.xrTableCell19 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell20 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell21 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell22 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell23 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell24 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell25 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell26 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell27 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell28 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell29 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell30 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell31 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell32 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell33 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell34 = New DevExpress.XtraReports.UI.XRTableCell()
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
        Me.fDate = New DevExpress.XtraReports.Parameters.Parameter()
        Me.tDate = New DevExpress.XtraReports.Parameters.Parameter()
        Me.blDate = New DevExpress.XtraReports.UI.CalculatedField()
        Me.xrLabel2 = New DevExpress.XtraReports.UI.XRLabel()
        CType(Me.dsAllReports1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dsAllReports2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dsAllReports3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.xrTable1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.xrTable2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.xrTable2})
        Me.Detail.HeightF = 47.16665!
        Me.Detail.Name = "Detail"
        Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
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
        'blacklistTableAdapter1
        '
        Me.blacklistTableAdapter1.ClearBeforeFill = True
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
        Me.xrTableCell7.Text = ""
        Me.xrTableCell7.Weight = 1.0R
        '
        'xrTableCell8
        '
        Me.xrTableCell8.Name = "xrTableCell8"
        Me.xrTableCell8.Text = ""
        Me.xrTableCell8.Weight = 1.0R
        '
        'xrTableCell9
        '
        Me.xrTableCell9.Name = "xrTableCell9"
        Me.xrTableCell9.Text = ""
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
        Me.xrTableCell10.Text = ""
        Me.xrTableCell10.Weight = 1.0R
        '
        'xrTableCell11
        '
        Me.xrTableCell11.Name = "xrTableCell11"
        Me.xrTableCell11.Text = ""
        Me.xrTableCell11.Weight = 1.0R
        '
        'xrTableCell12
        '
        Me.xrTableCell12.Name = "xrTableCell12"
        Me.xrTableCell12.Text = ""
        Me.xrTableCell12.Weight = 1.0R
        '
        'blacklistTableAdapter2
        '
        Me.blacklistTableAdapter2.ClearBeforeFill = True
        '
        'dsAllReports2
        '
        Me.dsAllReports2.DataSetName = "dsAllReports"
        Me.dsAllReports2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'dsAllReports3
        '
        Me.dsAllReports3.DataSetName = "dsAllReports"
        Me.dsAllReports3.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
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
        Me.xrTable1.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.xrTableRow7})
        Me.xrTable1.SizeF = New System.Drawing.SizeF(1014.0!, 36.0!)
        '
        'xrTableRow5
        '
        Me.xrTableRow5.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.xrTableCell13, Me.xrTableCell14, Me.xrTableCell15})
        Me.xrTableRow5.Name = "xrTableRow5"
        Me.xrTableRow5.Weight = 1.0R
        '
        'xrTableCell13
        '
        Me.xrTableCell13.Name = "xrTableCell13"
        Me.xrTableCell13.Text = ""
        Me.xrTableCell13.Weight = 1.0R
        '
        'xrTableCell14
        '
        Me.xrTableCell14.Name = "xrTableCell14"
        Me.xrTableCell14.Text = ""
        Me.xrTableCell14.Weight = 1.0R
        '
        'xrTableCell15
        '
        Me.xrTableCell15.Name = "xrTableCell15"
        Me.xrTableCell15.Text = ""
        Me.xrTableCell15.Weight = 1.0R
        '
        'xrTable2
        '
        Me.xrTable2.AnchorVertical = CType((DevExpress.XtraReports.UI.VerticalAnchorStyles.Top Or DevExpress.XtraReports.UI.VerticalAnchorStyles.Bottom), DevExpress.XtraReports.UI.VerticalAnchorStyles)
        Me.xrTable2.LocationFloat = New DevExpress.Utils.PointFloat(5.0!, 0!)
        Me.xrTable2.Name = "xrTable2"
        Me.xrTable2.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.xrTableRow8})
        Me.xrTable2.SizeF = New System.Drawing.SizeF(1014.0!, 47.16665!)
        '
        'xrTableRow6
        '
        Me.xrTableRow6.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.xrTableCell16, Me.xrTableCell17, Me.xrTableCell18})
        Me.xrTableRow6.Name = "xrTableRow6"
        Me.xrTableRow6.Weight = 1.0R
        '
        'xrTableCell16
        '
        Me.xrTableCell16.Name = "xrTableCell16"
        Me.xrTableCell16.Text = ""
        Me.xrTableCell16.Weight = 1.0R
        '
        'xrTableCell17
        '
        Me.xrTableCell17.Name = "xrTableCell17"
        Me.xrTableCell17.Text = ""
        Me.xrTableCell17.Weight = 1.0R
        '
        'xrTableCell18
        '
        Me.xrTableCell18.Name = "xrTableCell18"
        Me.xrTableCell18.Text = ""
        Me.xrTableCell18.Weight = 1.0R
        '
        'xrTableRow7
        '
        Me.xrTableRow7.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.xrTableCell19, Me.xrTableCell21, Me.xrTableCell23, Me.xrTableCell25, Me.xrTableCell27, Me.xrTableCell29, Me.xrTableCell31, Me.xrTableCell33})
        Me.xrTableRow7.Name = "xrTableRow7"
        Me.xrTableRow7.Weight = 1.0R
        '
        'xrTableRow8
        '
        Me.xrTableRow8.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.xrTableCell20, Me.xrTableCell22, Me.xrTableCell24, Me.xrTableCell26, Me.xrTableCell28, Me.xrTableCell30, Me.xrTableCell32, Me.xrTableCell34})
        Me.xrTableRow8.Name = "xrTableRow8"
        Me.xrTableRow8.Weight = 1.0R
        '
        'xrTableCell19
        '
        Me.xrTableCell19.CanGrow = False
        Me.xrTableCell19.Name = "xrTableCell19"
        Me.xrTableCell19.StyleName = "FieldCaption"
        Me.xrTableCell19.Text = "Cust No"
        Me.xrTableCell19.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        Me.xrTableCell19.Weight = 20.15704938222671R
        '
        'xrTableCell20
        '
        Me.xrTableCell20.CanGrow = False
        Me.xrTableCell20.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Blacklist.CustNo")})
        Me.xrTableCell20.Name = "xrTableCell20"
        Me.xrTableCell20.StyleName = "DataField"
        Me.xrTableCell20.Text = "xrTableCell20"
        Me.xrTableCell20.Weight = 20.15704938222671R
        '
        'xrTableCell21
        '
        Me.xrTableCell21.CanGrow = False
        Me.xrTableCell21.Name = "xrTableCell21"
        Me.xrTableCell21.StyleName = "FieldCaption"
        Me.xrTableCell21.Text = "Name"
        Me.xrTableCell21.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        Me.xrTableCell21.Weight = 34.898332941931848R
        '
        'xrTableCell22
        '
        Me.xrTableCell22.CanGrow = False
        Me.xrTableCell22.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Blacklist.Name")})
        Me.xrTableCell22.Name = "xrTableCell22"
        Me.xrTableCell22.StyleName = "DataField"
        Me.xrTableCell22.Text = "xrTableCell22"
        Me.xrTableCell22.Weight = 34.898332941931848R
        '
        'xrTableCell23
        '
        Me.xrTableCell23.CanGrow = False
        Me.xrTableCell23.Name = "xrTableCell23"
        Me.xrTableCell23.StyleName = "FieldCaption"
        Me.xrTableCell23.Text = "Blacklist Date"
        Me.xrTableCell23.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        Me.xrTableCell23.Weight = 30.776547569259854R
        '
        'xrTableCell24
        '
        Me.xrTableCell24.CanGrow = False
        Me.xrTableCell24.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Blacklist.BlacklistDate")})
        Me.xrTableCell24.Name = "xrTableCell24"
        Me.xrTableCell24.StyleName = "DataField"
        Me.xrTableCell24.Text = "xrTableCell24"
        Me.xrTableCell24.Weight = 30.776547569259854R
        '
        'xrTableCell25
        '
        Me.xrTableCell25.CanGrow = False
        Me.xrTableCell25.Name = "xrTableCell25"
        Me.xrTableCell25.StyleName = "FieldCaption"
        Me.xrTableCell25.Text = "Reason"
        Me.xrTableCell25.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        Me.xrTableCell25.Weight = 52.646453503791165R
        '
        'xrTableCell26
        '
        Me.xrTableCell26.CanGrow = False
        Me.xrTableCell26.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Blacklist.Reason")})
        Me.xrTableCell26.Name = "xrTableCell26"
        Me.xrTableCell26.StyleName = "DataField"
        Me.xrTableCell26.Text = "xrTableCell26"
        Me.xrTableCell26.Weight = 52.646453503791165R
        '
        'xrTableCell27
        '
        Me.xrTableCell27.CanGrow = False
        Me.xrTableCell27.Name = "xrTableCell27"
        Me.xrTableCell27.StyleName = "FieldCaption"
        Me.xrTableCell27.Text = "Blacklisted By"
        Me.xrTableCell27.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        Me.xrTableCell27.Weight = 33.771616602790424R
        '
        'xrTableCell28
        '
        Me.xrTableCell28.CanGrow = False
        Me.xrTableCell28.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Blacklist.Blacklisted By")})
        Me.xrTableCell28.Name = "xrTableCell28"
        Me.xrTableCell28.StyleName = "DataField"
        Me.xrTableCell28.Text = "xrTableCell28"
        Me.xrTableCell28.Weight = 33.771616602790424R
        '
        'xrTableCell29
        '
        Me.xrTableCell29.CanGrow = False
        Me.xrTableCell29.Name = "xrTableCell29"
        Me.xrTableCell29.StyleName = "FieldCaption"
        Me.xrTableCell29.Text = "Lifted"
        Me.xrTableCell29.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        Me.xrTableCell29.Weight = 14.354693888677412R
        '
        'xrTableCell30
        '
        Me.xrTableCell30.CanGrow = False
        Me.xrTableCell30.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Blacklist.Lifted")})
        Me.xrTableCell30.Name = "xrTableCell30"
        Me.xrTableCell30.StyleName = "DataField"
        Me.xrTableCell30.Text = "xrTableCell30"
        Me.xrTableCell30.Weight = 14.354693888677412R
        '
        'xrTableCell31
        '
        Me.xrTableCell31.CanGrow = False
        Me.xrTableCell31.Name = "xrTableCell31"
        Me.xrTableCell31.StyleName = "FieldCaption"
        Me.xrTableCell31.Text = "Lift Date"
        Me.xrTableCell31.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        Me.xrTableCell31.Weight = 34.64530611132259R
        '
        'xrTableCell32
        '
        Me.xrTableCell32.CanGrow = False
        Me.xrTableCell32.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Blacklist.LiftDate")})
        Me.xrTableCell32.Name = "xrTableCell32"
        Me.xrTableCell32.StyleName = "DataField"
        Me.xrTableCell32.Text = "xrTableCell32"
        Me.xrTableCell32.Weight = 34.64530611132259R
        '
        'xrTableCell33
        '
        Me.xrTableCell33.CanGrow = False
        Me.xrTableCell33.Name = "xrTableCell33"
        Me.xrTableCell33.StyleName = "FieldCaption"
        Me.xrTableCell33.Text = "Lifted By"
        Me.xrTableCell33.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        Me.xrTableCell33.Weight = 31.25R
        '
        'xrTableCell34
        '
        Me.xrTableCell34.CanGrow = False
        Me.xrTableCell34.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Blacklist.LiftedBy")})
        Me.xrTableCell34.Name = "xrTableCell34"
        Me.xrTableCell34.StyleName = "DataField"
        Me.xrTableCell34.Text = "xrTableCell34"
        Me.xrTableCell34.Weight = 31.25R
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
        Me.xrPageInfo1.SizeF = New System.Drawing.SizeF(502.0!, 23.0!)
        Me.xrPageInfo1.StyleName = "PageInfo"
        '
        'xrPageInfo2
        '
        Me.xrPageInfo2.Format = "Page {0} of {1}"
        Me.xrPageInfo2.LocationFloat = New DevExpress.Utils.PointFloat(517.0!, 5.0!)
        Me.xrPageInfo2.Name = "xrPageInfo2"
        Me.xrPageInfo2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrPageInfo2.SizeF = New System.Drawing.SizeF(502.0!, 23.0!)
        Me.xrPageInfo2.StyleName = "PageInfo"
        Me.xrPageInfo2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'reportHeaderBand1
        '
        Me.reportHeaderBand1.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.xrLabel2, Me.xrLabel1})
        Me.reportHeaderBand1.HeightF = 95.50001!
        Me.reportHeaderBand1.Name = "reportHeaderBand1"
        '
        'xrLabel1
        '
        Me.xrLabel1.LocationFloat = New DevExpress.Utils.PointFloat(5.0!, 5.0!)
        Me.xrLabel1.Name = "xrLabel1"
        Me.xrLabel1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel1.SizeF = New System.Drawing.SizeF(1015.0!, 33.0!)
        Me.xrLabel1.StyleName = "Title"
        Me.xrLabel1.Text = "Blacklist Report"
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
        'fDate
        '
        Me.fDate.Description = "Date From"
        Me.fDate.Name = "fDate"
        Me.fDate.Type = GetType(Date)
        Me.fDate.ValueInfo = "2016-09-01"
        '
        'tDate
        '
        Me.tDate.Description = "Date To"
        Me.tDate.Name = "tDate"
        Me.tDate.Type = GetType(Date)
        Me.tDate.ValueInfo = Today.ToLongDateString ' "2016-12-31"
        '
        'blDate
        '
        Me.blDate.DataMember = "Blacklist"
        Me.blDate.DisplayName = "blDate"
        Me.blDate.Expression = "GetDate([BlacklistDate])"
        Me.blDate.Name = "blDate"
        '
        'xrLabel2
        '
        Me.xrLabel2.Font = New System.Drawing.Font("Times New Roman", 10.0!, System.Drawing.FontStyle.Bold)
        Me.xrLabel2.LocationFloat = New DevExpress.Utils.PointFloat(5.0!, 62.5!)
        Me.xrLabel2.Name = "xrLabel2"
        Me.xrLabel2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel2.SizeF = New System.Drawing.SizeF(546.875!, 23.0!)
        Me.xrLabel2.StylePriority.UseFont = False
        Me.xrLabel2.Text = "From [Parameters.fDate!dd MMM,yyyy] to [Parameters.tDate!dd MMM,yyyy]"
        '
        'xrptBlacklist
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.pageHeaderBand1, Me.pageFooterBand1, Me.reportHeaderBand1, Me.topMarginBand1, Me.bottomMarginBand1})
        Me.CalculatedFields.AddRange(New DevExpress.XtraReports.UI.CalculatedField() {Me.blDate})
        Me.DataAdapter = Me.blacklistTableAdapter2
        Me.DataMember = "Blacklist"
        Me.DataSource = Me.dsAllReports3
        Me.FilterString = "[blDate] >= ?fDate And [blDate] <= ?tDate"
        Me.Landscape = True
        Me.Margins = New System.Drawing.Printing.Margins(48, 27, 100, 100)
        Me.PageHeight = 850
        Me.PageWidth = 1100
        Me.Parameters.AddRange(New DevExpress.XtraReports.Parameters.Parameter() {Me.fDate, Me.tDate})
        Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
        Me.StyleSheet.AddRange(New DevExpress.XtraReports.UI.XRControlStyle() {Me.Title, Me.FieldCaption, Me.PageInfo, Me.DataField})
        Me.Version = "13.2"
        CType(Me.dsAllReports1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dsAllReports2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dsAllReports3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.xrTable1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.xrTable2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand

#End Region

End Class