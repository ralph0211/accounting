Public Class xrptLoanGrading
    Inherits DevExpress.XtraReports.UI.XtraReport

#Region " Designer generated code "

    Private WithEvents bottomMarginBand1 As DevExpress.XtraReports.UI.BottomMarginBand

    Private WithEvents DataField As DevExpress.XtraReports.UI.XRControlStyle

    Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand

    Private WithEvents FieldCaption As DevExpress.XtraReports.UI.XRControlStyle
    Private WithEvents pageFooterBand1 As DevExpress.XtraReports.UI.PageFooterBand
    Private WithEvents pageHeaderBand1 As DevExpress.XtraReports.UI.PageHeaderBand
    Private WithEvents PageInfo As DevExpress.XtraReports.UI.XRControlStyle
    Private WithEvents ReportFooter As DevExpress.XtraReports.UI.ReportFooterBand
    Private WithEvents reportHeaderBand1 As DevExpress.XtraReports.UI.ReportHeaderBand
    Private WithEvents Title As DevExpress.XtraReports.UI.XRControlStyle
    Private WithEvents xrChart1 As DevExpress.XtraReports.UI.XRChart
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
    Private WithEvents xrTable2 As DevExpress.XtraReports.UI.XRTable
    Private WithEvents xrTableRow4 As DevExpress.XtraReports.UI.XRTableRow
    Private WithEvents xrTableCell8 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell10 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell12 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell14 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell16 As DevExpress.XtraReports.UI.XRTableCell
    Private dsAnalystReports1 As dsAnalystReports
    Private loanGradingTableAdapter1 As dsAnalystReportsTableAdapters.LoanGradingTableAdapter
    Private WithEvents xrTable1 As DevExpress.XtraReports.UI.XRTable
    Private WithEvents xrTableRow3 As DevExpress.XtraReports.UI.XRTableRow
    Private WithEvents xrTableCell7 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell9 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell11 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell13 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell15 As DevExpress.XtraReports.UI.XRTableCell
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
    Private WithEvents xrLabel1 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents topMarginBand1 As DevExpress.XtraReports.UI.TopMarginBand
    Private WithEvents xrTable3 As DevExpress.XtraReports.UI.XRTable
    Private WithEvents xrTableRow5 As DevExpress.XtraReports.UI.XRTableRow
    Private WithEvents xrTableCell17 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell18 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell19 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell20 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrTableCell21 As DevExpress.XtraReports.UI.XRTableCell
    Private WithEvents xrLabel2 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents toDate As DevExpress.XtraReports.Parameters.Parameter

    'Required by the Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Designer
    'It can be modified using the Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resourceFileName As String = "xrptLoanGrading.resx"
        Dim xyDiagram1 As DevExpress.XtraCharts.XYDiagram = New DevExpress.XtraCharts.XYDiagram()
        Dim customAxisLabel1 As DevExpress.XtraCharts.CustomAxisLabel = New DevExpress.XtraCharts.CustomAxisLabel()
        Dim xrSummary1 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
        Dim xrSummary2 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
        Dim xrSummary3 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
        Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
        Me.xrTable2 = New DevExpress.XtraReports.UI.XRTable()
        Me.xrTableRow4 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.xrTableCell8 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell10 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell12 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell14 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell16 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.dsAnalystReports1 = New dsAnalystReports()
        Me.loanGradingTableAdapter1 = New dsAnalystReportsTableAdapters.LoanGradingTableAdapter()
        Me.pageHeaderBand1 = New DevExpress.XtraReports.UI.PageHeaderBand()
        Me.xrTable1 = New DevExpress.XtraReports.UI.XRTable()
        Me.xrTableRow3 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.xrTableCell7 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell9 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell11 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell13 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell15 = New DevExpress.XtraReports.UI.XRTableCell()
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
        Me.xrChart1 = New DevExpress.XtraReports.UI.XRChart()
        Me.xrLabel2 = New DevExpress.XtraReports.UI.XRLabel()
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
        Me.xrTableCell17 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell18 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell19 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell20 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.xrTableCell21 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.toDate = New DevExpress.XtraReports.Parameters.Parameter()
        CType(Me.xrTable2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dsAnalystReports1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.xrTable1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.xrChart1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(xyDiagram1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.xrTable3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.xrTable2})
        Me.Detail.Dpi = 254.0!
        Me.Detail.HeightF = 58.42!
        Me.Detail.Name = "Detail"
        Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 254.0!)
        Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'xrTable2
        '
        Me.xrTable2.AnchorVertical = CType((DevExpress.XtraReports.UI.VerticalAnchorStyles.Top Or DevExpress.XtraReports.UI.VerticalAnchorStyles.Bottom), DevExpress.XtraReports.UI.VerticalAnchorStyles)
        Me.xrTable2.Borders = CType((DevExpress.XtraPrinting.BorderSide.Right Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.xrTable2.Dpi = 254.0!
        Me.xrTable2.LocationFloat = New DevExpress.Utils.PointFloat(16.0!, 0.0!)
        Me.xrTable2.Name = "xrTable2"
        Me.xrTable2.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.xrTableRow4})
        Me.xrTable2.SizeF = New System.Drawing.SizeF(1619.0!, 58.42!)
        Me.xrTable2.StylePriority.UseBorders = False
        '
        'xrTableRow4
        '
        Me.xrTableRow4.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.xrTableCell8, Me.xrTableCell10, Me.xrTableCell12, Me.xrTableCell14, Me.xrTableCell16})
        Me.xrTableRow4.Dpi = 254.0!
        Me.xrTableRow4.Name = "xrTableRow4"
        Me.xrTableRow4.Weight = 1.0R
        '
        'xrTableCell8
        '
        Me.xrTableCell8.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.xrTableCell8.CanGrow = False
        Me.xrTableCell8.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "LoanGrading.Grade")})
        Me.xrTableCell8.Dpi = 254.0!
        Me.xrTableCell8.Name = "xrTableCell8"
        Me.xrTableCell8.Padding = New DevExpress.XtraPrinting.PaddingInfo(16, 0, 0, 0, 254.0!)
        Me.xrTableCell8.StyleName = "DataField"
        Me.xrTableCell8.StylePriority.UseBorders = False
        Me.xrTableCell8.StylePriority.UsePadding = False
        Me.xrTableCell8.Text = "xrTableCell8"
        Me.xrTableCell8.Weight = 99.0R
        '
        'xrTableCell10
        '
        Me.xrTableCell10.Borders = CType((DevExpress.XtraPrinting.BorderSide.Right Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.xrTableCell10.CanGrow = False
        Me.xrTableCell10.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "LoanGrading.DaysInArrears")})
        Me.xrTableCell10.Dpi = 254.0!
        Me.xrTableCell10.Name = "xrTableCell10"
        Me.xrTableCell10.Padding = New DevExpress.XtraPrinting.PaddingInfo(16, 0, 0, 0, 254.0!)
        Me.xrTableCell10.StyleName = "DataField"
        Me.xrTableCell10.StylePriority.UseBorders = False
        Me.xrTableCell10.StylePriority.UsePadding = False
        Me.xrTableCell10.Text = "xrTableCell10"
        Me.xrTableCell10.Weight = 143.51226085641639R
        '
        'xrTableCell12
        '
        Me.xrTableCell12.Borders = CType((DevExpress.XtraPrinting.BorderSide.Right Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.xrTableCell12.CanGrow = False
        Me.xrTableCell12.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "LoanGrading.sumPrin")})
        Me.xrTableCell12.Dpi = 254.0!
        Me.xrTableCell12.Name = "xrTableCell12"
        Me.xrTableCell12.Padding = New DevExpress.XtraPrinting.PaddingInfo(16, 16, 0, 0, 254.0!)
        Me.xrTableCell12.StyleName = "DataField"
        Me.xrTableCell12.StylePriority.UseBorders = False
        Me.xrTableCell12.StylePriority.UsePadding = False
        Me.xrTableCell12.StylePriority.UseTextAlignment = False
        Me.xrTableCell12.Text = "xrTableCell12"
        Me.xrTableCell12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        Me.xrTableCell12.Weight = 184.01231122267251R
        '
        'xrTableCell14
        '
        Me.xrTableCell14.Borders = CType((DevExpress.XtraPrinting.BorderSide.Right Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.xrTableCell14.CanGrow = False
        Me.xrTableCell14.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "LoanGrading.Provision")})
        Me.xrTableCell14.Dpi = 254.0!
        Me.xrTableCell14.Name = "xrTableCell14"
        Me.xrTableCell14.Padding = New DevExpress.XtraPrinting.PaddingInfo(16, 0, 0, 0, 254.0!)
        Me.xrTableCell14.StyleName = "DataField"
        Me.xrTableCell14.StylePriority.UseBorders = False
        Me.xrTableCell14.StylePriority.UsePadding = False
        Me.xrTableCell14.Text = "xrTableCell14"
        Me.xrTableCell14.Weight = 196.62207464791877R
        '
        'xrTableCell16
        '
        Me.xrTableCell16.Borders = CType((DevExpress.XtraPrinting.BorderSide.Right Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.xrTableCell16.CanGrow = False
        Me.xrTableCell16.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "LoanGrading.provAmt")})
        Me.xrTableCell16.Dpi = 254.0!
        Me.xrTableCell16.Name = "xrTableCell16"
        Me.xrTableCell16.Padding = New DevExpress.XtraPrinting.PaddingInfo(16, 16, 0, 0, 254.0!)
        Me.xrTableCell16.StyleName = "DataField"
        Me.xrTableCell16.StylePriority.UseBorders = False
        Me.xrTableCell16.StylePriority.UsePadding = False
        Me.xrTableCell16.StylePriority.UseTextAlignment = False
        Me.xrTableCell16.Text = "xrTableCell16"
        Me.xrTableCell16.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        Me.xrTableCell16.Weight = 185.35335327299234R
        '
        'dsAnalystReports1
        '
        Me.dsAnalystReports1.DataSetName = "dsAnalystReports"
        Me.dsAnalystReports1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'loanGradingTableAdapter1
        '
        Me.loanGradingTableAdapter1.ClearBeforeFill = True
        '
        'pageHeaderBand1
        '
        Me.pageHeaderBand1.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.xrTable1})
        Me.pageHeaderBand1.Dpi = 254.0!
        Me.pageHeaderBand1.HeightF = 106.0!
        Me.pageHeaderBand1.Name = "pageHeaderBand1"
        '
        'xrTable1
        '
        Me.xrTable1.AnchorVertical = DevExpress.XtraReports.UI.VerticalAnchorStyles.Bottom
        Me.xrTable1.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Top Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.xrTable1.Dpi = 254.0!
        Me.xrTable1.LocationFloat = New DevExpress.Utils.PointFloat(16.0!, 16.0!)
        Me.xrTable1.Name = "xrTable1"
        Me.xrTable1.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.xrTableRow3})
        Me.xrTable1.SizeF = New System.Drawing.SizeF(1619.0!, 90.0!)
        Me.xrTable1.StylePriority.UseBorders = False
        '
        'xrTableRow3
        '
        Me.xrTableRow3.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.xrTableCell7, Me.xrTableCell9, Me.xrTableCell11, Me.xrTableCell13, Me.xrTableCell15})
        Me.xrTableRow3.Dpi = 254.0!
        Me.xrTableRow3.Name = "xrTableRow3"
        Me.xrTableRow3.Weight = 1.0R
        '
        'xrTableCell7
        '
        Me.xrTableCell7.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.xrTableCell7.CanGrow = False
        Me.xrTableCell7.Dpi = 254.0!
        Me.xrTableCell7.Name = "xrTableCell7"
        Me.xrTableCell7.Padding = New DevExpress.XtraPrinting.PaddingInfo(15, 0, 0, 0, 254.0!)
        Me.xrTableCell7.StyleName = "FieldCaption"
        Me.xrTableCell7.StylePriority.UseBorders = False
        Me.xrTableCell7.StylePriority.UsePadding = False
        Me.xrTableCell7.Text = "Grade"
        Me.xrTableCell7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        Me.xrTableCell7.Weight = 99.0R
        '
        'xrTableCell9
        '
        Me.xrTableCell9.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Top Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.xrTableCell9.CanGrow = False
        Me.xrTableCell9.Dpi = 254.0!
        Me.xrTableCell9.Name = "xrTableCell9"
        Me.xrTableCell9.Padding = New DevExpress.XtraPrinting.PaddingInfo(15, 0, 0, 0, 254.0!)
        Me.xrTableCell9.StyleName = "FieldCaption"
        Me.xrTableCell9.StylePriority.UseBorders = False
        Me.xrTableCell9.StylePriority.UsePadding = False
        Me.xrTableCell9.Text = "Days In Arrears"
        Me.xrTableCell9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        Me.xrTableCell9.Weight = 143.51226085641639R
        '
        'xrTableCell11
        '
        Me.xrTableCell11.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Top Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.xrTableCell11.CanGrow = False
        Me.xrTableCell11.Dpi = 254.0!
        Me.xrTableCell11.Name = "xrTableCell11"
        Me.xrTableCell11.Padding = New DevExpress.XtraPrinting.PaddingInfo(16, 16, 0, 0, 254.0!)
        Me.xrTableCell11.StyleName = "FieldCaption"
        Me.xrTableCell11.StylePriority.UseBorders = False
        Me.xrTableCell11.StylePriority.UsePadding = False
        Me.xrTableCell11.StylePriority.UseTextAlignment = False
        Me.xrTableCell11.Text = "Principal Balance"
        Me.xrTableCell11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.xrTableCell11.Weight = 184.01231122267251R
        '
        'xrTableCell13
        '
        Me.xrTableCell13.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Top Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.xrTableCell13.CanGrow = False
        Me.xrTableCell13.Dpi = 254.0!
        Me.xrTableCell13.Name = "xrTableCell13"
        Me.xrTableCell13.Padding = New DevExpress.XtraPrinting.PaddingInfo(15, 0, 0, 0, 254.0!)
        Me.xrTableCell13.StyleName = "FieldCaption"
        Me.xrTableCell13.StylePriority.UseBorders = False
        Me.xrTableCell13.StylePriority.UsePadding = False
        Me.xrTableCell13.Text = "Provision (%)"
        Me.xrTableCell13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        Me.xrTableCell13.Weight = 196.62207464791877R
        '
        'xrTableCell15
        '
        Me.xrTableCell15.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Top Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.xrTableCell15.CanGrow = False
        Me.xrTableCell15.Dpi = 254.0!
        Me.xrTableCell15.Name = "xrTableCell15"
        Me.xrTableCell15.Padding = New DevExpress.XtraPrinting.PaddingInfo(16, 16, 0, 0, 254.0!)
        Me.xrTableCell15.StyleName = "FieldCaption"
        Me.xrTableCell15.StylePriority.UseBorders = False
        Me.xrTableCell15.StylePriority.UsePadding = False
        Me.xrTableCell15.StylePriority.UseTextAlignment = False
        Me.xrTableCell15.Text = "Provision Amount"
        Me.xrTableCell15.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.xrTableCell15.Weight = 185.35335327299234R
        '
        'xrTableRow1
        '
        Me.xrTableRow1.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.xrTableCell1, Me.xrTableCell2, Me.xrTableCell3})
        Me.xrTableRow1.Dpi = 254.0!
        Me.xrTableRow1.Name = "xrTableRow1"
        Me.xrTableRow1.Weight = 1.0R
        '
        'xrTableCell1
        '
        Me.xrTableCell1.Dpi = 254.0!
        Me.xrTableCell1.Name = "xrTableCell1"
        Me.xrTableCell1.Weight = 1.0R
        '
        'xrTableCell2
        '
        Me.xrTableCell2.Dpi = 254.0!
        Me.xrTableCell2.Name = "xrTableCell2"
        Me.xrTableCell2.Weight = 1.0R
        '
        'xrTableCell3
        '
        Me.xrTableCell3.Dpi = 254.0!
        Me.xrTableCell3.Name = "xrTableCell3"
        Me.xrTableCell3.Weight = 1.0R
        '
        'xrTableRow2
        '
        Me.xrTableRow2.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.xrTableCell4, Me.xrTableCell5, Me.xrTableCell6})
        Me.xrTableRow2.Dpi = 254.0!
        Me.xrTableRow2.Name = "xrTableRow2"
        Me.xrTableRow2.Weight = 1.0R
        '
        'xrTableCell4
        '
        Me.xrTableCell4.Dpi = 254.0!
        Me.xrTableCell4.Name = "xrTableCell4"
        Me.xrTableCell4.Weight = 1.0R
        '
        'xrTableCell5
        '
        Me.xrTableCell5.Dpi = 254.0!
        Me.xrTableCell5.Name = "xrTableCell5"
        Me.xrTableCell5.Weight = 1.0R
        '
        'xrTableCell6
        '
        Me.xrTableCell6.Dpi = 254.0!
        Me.xrTableCell6.Name = "xrTableCell6"
        Me.xrTableCell6.Weight = 1.0R
        '
        'pageFooterBand1
        '
        Me.pageFooterBand1.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.xrPageInfo1, Me.xrPageInfo2})
        Me.pageFooterBand1.Dpi = 254.0!
        Me.pageFooterBand1.HeightF = 74.42!
        Me.pageFooterBand1.Name = "pageFooterBand1"
        '
        'xrPageInfo1
        '
        Me.xrPageInfo1.Dpi = 254.0!
        Me.xrPageInfo1.LocationFloat = New DevExpress.Utils.PointFloat(16.0!, 16.0!)
        Me.xrPageInfo1.Name = "xrPageInfo1"
        Me.xrPageInfo1.Padding = New DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254.0!)
        Me.xrPageInfo1.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime
        Me.xrPageInfo1.SizeF = New System.Drawing.SizeF(793.0!, 58.42!)
        Me.xrPageInfo1.StyleName = "PageInfo"
        '
        'xrPageInfo2
        '
        Me.xrPageInfo2.Dpi = 254.0!
        Me.xrPageInfo2.Format = "Page {0} of {1}"
        Me.xrPageInfo2.LocationFloat = New DevExpress.Utils.PointFloat(841.0!, 16.0!)
        Me.xrPageInfo2.Name = "xrPageInfo2"
        Me.xrPageInfo2.Padding = New DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254.0!)
        Me.xrPageInfo2.SizeF = New System.Drawing.SizeF(793.0!, 58.42!)
        Me.xrPageInfo2.StyleName = "PageInfo"
        Me.xrPageInfo2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'reportHeaderBand1
        '
        Me.reportHeaderBand1.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.xrChart1, Me.xrLabel2, Me.xrLabel1})
        Me.reportHeaderBand1.Dpi = 254.0!
        Me.reportHeaderBand1.HeightF = 1420.521!
        Me.reportHeaderBand1.Name = "reportHeaderBand1"
        '
        'xrChart1
        '
        Me.xrChart1.BorderColor = System.Drawing.Color.Black
        Me.xrChart1.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.xrChart1.DataAdapter = Me.loanGradingTableAdapter1
        Me.xrChart1.DataMember = "LoanGrading"
        Me.xrChart1.DataSource = Me.dsAnalystReports1
        customAxisLabel1.AxisValueSerializable = "B"
        customAxisLabel1.Name = "Provision Amount [$]"
        customAxisLabel1.Visible = False
        xyDiagram1.AxisX.CustomLabels.AddRange(New DevExpress.XtraCharts.CustomAxisLabel() {customAxisLabel1})
        xyDiagram1.AxisX.Label.EndText = " days"
        xyDiagram1.AxisX.VisibleInPanesSerializable = "-1"
        xyDiagram1.AxisY.Label.NumericOptions.Format = DevExpress.XtraCharts.NumericFormat.Number
        xyDiagram1.AxisY.VisibleInPanesSerializable = "-1"
        xyDiagram1.DefaultPane.EnableAxisXScrolling = DevExpress.Utils.DefaultBoolean.[False]
        xyDiagram1.DefaultPane.EnableAxisXZooming = DevExpress.Utils.DefaultBoolean.[False]
        xyDiagram1.DefaultPane.EnableAxisYScrolling = DevExpress.Utils.DefaultBoolean.[False]
        xyDiagram1.DefaultPane.EnableAxisYZooming = DevExpress.Utils.DefaultBoolean.[False]
        Me.xrChart1.Diagram = xyDiagram1
        Me.xrChart1.Dpi = 254.0!
        Me.xrChart1.Legend.AlignmentHorizontal = DevExpress.XtraCharts.LegendAlignmentHorizontal.Left
        Me.xrChart1.Legend.AlignmentVertical = DevExpress.XtraCharts.LegendAlignmentVertical.BottomOutside
        Me.xrChart1.Legend.Direction = DevExpress.XtraCharts.LegendDirection.LeftToRight
        Me.xrChart1.Legend.EquallySpacedItems = False
        Me.xrChart1.LocationFloat = New DevExpress.Utils.PointFloat(25.00001!, 285.75!)
        Me.xrChart1.Name = "xrChart1"
        Me.xrChart1.SeriesDataMember = "DaysInArrears"
        Me.xrChart1.SeriesNameTemplate.EndText = " days"
        Me.xrChart1.SeriesSerializable = New DevExpress.XtraCharts.Series(-1) {}
        Me.xrChart1.SeriesTemplate.ArgumentDataMember = "DaysInArrears"
        Me.xrChart1.SeriesTemplate.ArgumentScaleType = DevExpress.XtraCharts.ScaleType.Qualitative
        Me.xrChart1.SeriesTemplate.LabelsVisibility = DevExpress.Utils.DefaultBoolean.[False]
        Me.xrChart1.SeriesTemplate.ValueDataMembersSerializable = "provAmt"
        Me.xrChart1.SizeF = New System.Drawing.SizeF(1601.0!, 1066.271!)
        '
        'xrLabel2
        '
        Me.xrLabel2.Dpi = 254.0!
        Me.xrLabel2.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold)
        Me.xrLabel2.LocationFloat = New DevExpress.Utils.PointFloat(15.99999!, 163.9358!)
        Me.xrLabel2.Name = "xrLabel2"
        Me.xrLabel2.Padding = New DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254.0!)
        Me.xrLabel2.SizeF = New System.Drawing.SizeF(1341.313!, 58.41998!)
        Me.xrLabel2.StylePriority.UseFont = False
        Me.xrLabel2.Text = "As At: [Parameters.toDate!dd MMMM yyyy]"
        '
        'xrLabel1
        '
        Me.xrLabel1.Dpi = 254.0!
        Me.xrLabel1.LocationFloat = New DevExpress.Utils.PointFloat(16.0!, 16.0!)
        Me.xrLabel1.Name = "xrLabel1"
        Me.xrLabel1.Padding = New DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254.0!)
        Me.xrLabel1.SizeF = New System.Drawing.SizeF(1619.0!, 84.0!)
        Me.xrLabel1.StyleName = "Title"
        Me.xrLabel1.Text = "Loan Grading and Provisions Report"
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
        Me.DataField.Padding = New DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254.0!)
        '
        'topMarginBand1
        '
        Me.topMarginBand1.Dpi = 254.0!
        Me.topMarginBand1.HeightF = 254.0!
        Me.topMarginBand1.Name = "topMarginBand1"
        '
        'bottomMarginBand1
        '
        Me.bottomMarginBand1.Dpi = 254.0!
        Me.bottomMarginBand1.HeightF = 254.0!
        Me.bottomMarginBand1.Name = "bottomMarginBand1"
        '
        'ReportFooter
        '
        Me.ReportFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.xrTable3})
        Me.ReportFooter.Dpi = 254.0!
        Me.ReportFooter.HeightF = 153.4583!
        Me.ReportFooter.Name = "ReportFooter"
        '
        'xrTable3
        '
        Me.xrTable3.AnchorVertical = CType((DevExpress.XtraReports.UI.VerticalAnchorStyles.Top Or DevExpress.XtraReports.UI.VerticalAnchorStyles.Bottom), DevExpress.XtraReports.UI.VerticalAnchorStyles)
        Me.xrTable3.Borders = CType((DevExpress.XtraPrinting.BorderSide.Right Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.xrTable3.Dpi = 254.0!
        Me.xrTable3.LocationFloat = New DevExpress.Utils.PointFloat(16.0!, 0.0!)
        Me.xrTable3.Name = "xrTable3"
        Me.xrTable3.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.xrTableRow5})
        Me.xrTable3.SizeF = New System.Drawing.SizeF(1619.0!, 65.85416!)
        Me.xrTable3.StylePriority.UseBorders = False
        '
        'xrTableRow5
        '
        Me.xrTableRow5.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.xrTableCell17, Me.xrTableCell18, Me.xrTableCell19, Me.xrTableCell20, Me.xrTableCell21})
        Me.xrTableRow5.Dpi = 254.0!
        Me.xrTableRow5.Name = "xrTableRow5"
        Me.xrTableRow5.Weight = 1.0R
        '
        'xrTableCell17
        '
        Me.xrTableCell17.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.xrTableCell17.CanGrow = False
        Me.xrTableCell17.Dpi = 254.0!
        Me.xrTableCell17.Font = New System.Drawing.Font("Times New Roman", 10.0!, System.Drawing.FontStyle.Bold)
        Me.xrTableCell17.Name = "xrTableCell17"
        Me.xrTableCell17.Padding = New DevExpress.XtraPrinting.PaddingInfo(16, 0, 0, 0, 254.0!)
        Me.xrTableCell17.StyleName = "DataField"
        Me.xrTableCell17.StylePriority.UseBorders = False
        Me.xrTableCell17.StylePriority.UseFont = False
        Me.xrTableCell17.StylePriority.UsePadding = False
        Me.xrTableCell17.StylePriority.UseTextAlignment = False
        Me.xrTableCell17.Text = "Total"
        Me.xrTableCell17.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        Me.xrTableCell17.Weight = 99.0R
        '
        'xrTableCell18
        '
        Me.xrTableCell18.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Top Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.xrTableCell18.CanGrow = False
        Me.xrTableCell18.Dpi = 254.0!
        Me.xrTableCell18.Name = "xrTableCell18"
        Me.xrTableCell18.Padding = New DevExpress.XtraPrinting.PaddingInfo(16, 0, 0, 0, 254.0!)
        Me.xrTableCell18.StyleName = "DataField"
        Me.xrTableCell18.StylePriority.UseBorders = False
        Me.xrTableCell18.StylePriority.UsePadding = False
        Me.xrTableCell18.StylePriority.UseTextAlignment = False
        Me.xrTableCell18.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        Me.xrTableCell18.Weight = 143.51226085641639R
        '
        'xrTableCell19
        '
        Me.xrTableCell19.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Top Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.xrTableCell19.CanGrow = False
        Me.xrTableCell19.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "LoanGrading.sumPrin")})
        Me.xrTableCell19.Dpi = 254.0!
        Me.xrTableCell19.Font = New System.Drawing.Font("Times New Roman", 10.0!, System.Drawing.FontStyle.Bold)
        Me.xrTableCell19.Name = "xrTableCell19"
        Me.xrTableCell19.Padding = New DevExpress.XtraPrinting.PaddingInfo(16, 16, 0, 0, 254.0!)
        Me.xrTableCell19.StyleName = "DataField"
        Me.xrTableCell19.StylePriority.UseBorders = False
        Me.xrTableCell19.StylePriority.UseFont = False
        Me.xrTableCell19.StylePriority.UsePadding = False
        Me.xrTableCell19.StylePriority.UseTextAlignment = False
        xrSummary1.FormatString = "{0:n2}"
        xrSummary1.IgnoreNullValues = True
        xrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Report
        Me.xrTableCell19.Summary = xrSummary1
        Me.xrTableCell19.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.xrTableCell19.Weight = 184.01231122267251R
        '
        'xrTableCell20
        '
        Me.xrTableCell20.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Top Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.xrTableCell20.CanGrow = False
        Me.xrTableCell20.Dpi = 254.0!
        Me.xrTableCell20.Name = "xrTableCell20"
        Me.xrTableCell20.Padding = New DevExpress.XtraPrinting.PaddingInfo(16, 0, 0, 0, 254.0!)
        Me.xrTableCell20.StyleName = "DataField"
        Me.xrTableCell20.StylePriority.UseBorders = False
        Me.xrTableCell20.StylePriority.UsePadding = False
        Me.xrTableCell20.StylePriority.UseTextAlignment = False
        xrSummary2.IgnoreNullValues = True
        Me.xrTableCell20.Summary = xrSummary2
        Me.xrTableCell20.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        Me.xrTableCell20.Weight = 196.62207464791877R
        '
        'xrTableCell21
        '
        Me.xrTableCell21.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Top Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.xrTableCell21.CanGrow = False
        Me.xrTableCell21.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "LoanGrading.provAmt")})
        Me.xrTableCell21.Dpi = 254.0!
        Me.xrTableCell21.Font = New System.Drawing.Font("Times New Roman", 10.0!, System.Drawing.FontStyle.Bold)
        Me.xrTableCell21.Name = "xrTableCell21"
        Me.xrTableCell21.Padding = New DevExpress.XtraPrinting.PaddingInfo(16, 16, 0, 0, 254.0!)
        Me.xrTableCell21.StyleName = "DataField"
        Me.xrTableCell21.StylePriority.UseBorders = False
        Me.xrTableCell21.StylePriority.UseFont = False
        Me.xrTableCell21.StylePriority.UsePadding = False
        Me.xrTableCell21.StylePriority.UseTextAlignment = False
        xrSummary3.FormatString = "{0:n2}"
        xrSummary3.IgnoreNullValues = True
        xrSummary3.Running = DevExpress.XtraReports.UI.SummaryRunning.Report
        Me.xrTableCell21.Summary = xrSummary3
        Me.xrTableCell21.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.xrTableCell21.Weight = 185.35335327299234R
        '
        'toDate
        '
        Me.toDate.Description = "As at Date"
        Me.toDate.Name = "toDate"
        Me.toDate.Type = GetType(Date)
        Me.toDate.ValueInfo = Date.Now.ToLongDateString ' "01/07/2016"
        '
        'xrptLoanGrading
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.pageHeaderBand1, Me.pageFooterBand1, Me.reportHeaderBand1, Me.topMarginBand1, Me.bottomMarginBand1, Me.ReportFooter})
        Me.DataAdapter = Me.loanGradingTableAdapter1
        Me.DataMember = "LoanGrading"
        Me.DataSource = Me.dsAnalystReports1
        Me.Dpi = 254.0!
        Me.Margins = New System.Drawing.Printing.Margins(254, 254, 254, 254)
        Me.PageHeight = 2794
        Me.PageWidth = 2159
        Me.Parameters.AddRange(New DevExpress.XtraReports.Parameters.Parameter() {Me.toDate})
        Me.ReportUnit = DevExpress.XtraReports.UI.ReportUnit.TenthsOfAMillimeter
        Me.StyleSheet.AddRange(New DevExpress.XtraReports.UI.XRControlStyle() {Me.Title, Me.FieldCaption, Me.PageInfo, Me.DataField})
        Me.Version = "13.2"
        CType(Me.xrTable2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dsAnalystReports1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.xrTable1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(xyDiagram1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.xrChart1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.xrTable3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
#End Region

    Private Sub xrptLoanGrading_DataSourceDemanded(sender As Object, e As EventArgs) Handles Me.DataSourceDemanded
        If IsDate(toDate.Value.ToString) Then
            loanGradingTableAdapter1.FillByDate(dsAnalystReports1.LoanGrading, toDate.Value.ToString)
        Else
            loanGradingTableAdapter1.Fill(dsAnalystReports1.LoanGrading)
        End If
    End Sub
End Class