Public Class Maturity
    Inherits DevExpress.XtraReports.UI.XtraReport

#Region " Designer generated code "

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
    Private WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
    Private WithEvents CUSTOMERNUMBER1 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents Text6 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents PAYMENTDATE1 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents AMTAPPLIED1 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents oleDbDataAdapter1 As System.Data.OleDb.OleDbDataAdapter
    Private WithEvents oleDbCommand1 As System.Data.OleDb.OleDbCommand
    Private WithEvents oleDbConnection1 As System.Data.OleDb.OleDbConnection
    Private WithEvents GroupHeader1 As DevExpress.XtraReports.UI.GroupHeaderBand
    Private WithEvents GroupNameCUSTOMERTYPE1 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents GroupFooter1 As DevExpress.XtraReports.UI.GroupFooterBand
    Private WithEvents SumofFINAMT2 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents CountofCUSTOMERNUMBER1 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents Line1 As DevExpress.XtraReports.UI.XRLine
    Private WithEvents ReportHeader As DevExpress.XtraReports.UI.ReportHeaderBand
    Private WithEvents Text5 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents Text8 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents Picture1 As DevExpress.XtraReports.UI.XRPictureBox
    Private WithEvents PageHeader As DevExpress.XtraReports.UI.PageHeaderBand
    Private WithEvents Text2 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents Text7 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents Text1 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents Text4 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents ReportFooter As DevExpress.XtraReports.UI.ReportFooterBand
    Private WithEvents SumofFINAMT1 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents CountofCUSTOMERNUMBER2 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents PageFooter As DevExpress.XtraReports.UI.PageFooterBand

    'Required by the Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Designer
    'It can be modified using the Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resourceFileName As String = "Maturity.resx"
        Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
        Me.oleDbDataAdapter1 = New System.Data.OleDb.OleDbDataAdapter()
        Me.oleDbCommand1 = New System.Data.OleDb.OleDbCommand()
        Me.oleDbConnection1 = New System.Data.OleDb.OleDbConnection()
        Me.GroupHeader1 = New DevExpress.XtraReports.UI.GroupHeaderBand()
        Me.GroupNameCUSTOMERTYPE1 = New DevExpress.XtraReports.UI.XRLabel()
        Me.GroupFooter1 = New DevExpress.XtraReports.UI.GroupFooterBand()
        Me.SumofFINAMT2 = New DevExpress.XtraReports.UI.XRLabel()
        Me.CountofCUSTOMERNUMBER1 = New DevExpress.XtraReports.UI.XRLabel()
        Me.Line1 = New DevExpress.XtraReports.UI.XRLine()
        Me.ReportHeader = New DevExpress.XtraReports.UI.ReportHeaderBand()
        Me.Text5 = New DevExpress.XtraReports.UI.XRLabel()
        Me.Text8 = New DevExpress.XtraReports.UI.XRLabel()
        Me.Picture1 = New DevExpress.XtraReports.UI.XRPictureBox()
        Me.PageHeader = New DevExpress.XtraReports.UI.PageHeaderBand()
        Me.Text2 = New DevExpress.XtraReports.UI.XRLabel()
        Me.Text7 = New DevExpress.XtraReports.UI.XRLabel()
        Me.Text1 = New DevExpress.XtraReports.UI.XRLabel()
        Me.Text4 = New DevExpress.XtraReports.UI.XRLabel()
        Me.CUSTOMERNUMBER1 = New DevExpress.XtraReports.UI.XRLabel()
        Me.Text6 = New DevExpress.XtraReports.UI.XRLabel()
        Me.PAYMENTDATE1 = New DevExpress.XtraReports.UI.XRLabel()
        Me.AMTAPPLIED1 = New DevExpress.XtraReports.UI.XRLabel()
        Me.ReportFooter = New DevExpress.XtraReports.UI.ReportFooterBand()
        Me.SumofFINAMT1 = New DevExpress.XtraReports.UI.XRLabel()
        Me.CountofCUSTOMERNUMBER2 = New DevExpress.XtraReports.UI.XRLabel()
        Me.PageFooter = New DevExpress.XtraReports.UI.PageFooterBand()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.CUSTOMERNUMBER1, Me.Text6, Me.PAYMENTDATE1, Me.AMTAPPLIED1})
        Me.Detail.HeightF = 22.0!
        Me.Detail.Name = "Detail"
        '
        'oleDbDataAdapter1
        '
        Me.oleDbDataAdapter1.SelectCommand = Me.oleDbCommand1
        Me.oleDbDataAdapter1.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "maturity", New System.Data.Common.DataColumnMapping(-1) {})})
        '
        'oleDbCommand1
        '
        Me.oleDbCommand1.CommandText = "SELECT * FROM maturity"
        Me.oleDbCommand1.Connection = Me.oleDbConnection1
        '
        'oleDbConnection1
        '
        Me.oleDbConnection1.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=localhost"
        '
        'GroupHeader1
        '
        Me.GroupHeader1.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.GroupNameCUSTOMERTYPE1})
        Me.GroupHeader1.GroupFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("CUSTOMER_TYPE", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
        Me.GroupHeader1.HeightF = 15.0!
        Me.GroupHeader1.Name = "GroupHeader1"
        '
        'GroupNameCUSTOMERTYPE1
        '
        Me.GroupNameCUSTOMERTYPE1.BackColor = System.Drawing.Color.White
        Me.GroupNameCUSTOMERTYPE1.BorderColor = System.Drawing.Color.Black
        Me.GroupNameCUSTOMERTYPE1.CanGrow = False
        Me.GroupNameCUSTOMERTYPE1.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "maturity.CUSTOMER_TYPE")})
        Me.GroupNameCUSTOMERTYPE1.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.GroupNameCUSTOMERTYPE1.ForeColor = System.Drawing.Color.Black
        Me.GroupNameCUSTOMERTYPE1.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.0!)
        Me.GroupNameCUSTOMERTYPE1.Name = "GroupNameCUSTOMERTYPE1"
        Me.GroupNameCUSTOMERTYPE1.SizeF = New System.Drawing.SizeF(177.0!, 15.0!)
        Me.GroupNameCUSTOMERTYPE1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'GroupFooter1
        '
        Me.GroupFooter1.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.SumofFINAMT2, Me.CountofCUSTOMERNUMBER1, Me.Line1})
        Me.GroupFooter1.HeightF = 36.0!
        Me.GroupFooter1.Name = "GroupFooter1"
        '
        'SumofFINAMT2
        '
        Me.SumofFINAMT2.BackColor = System.Drawing.Color.White
        Me.SumofFINAMT2.BorderColor = System.Drawing.Color.Black
        Me.SumofFINAMT2.CanGrow = False
        Me.SumofFINAMT2.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.SumofFINAMT2.ForeColor = System.Drawing.Color.Black
        Me.SumofFINAMT2.LocationFloat = New DevExpress.Utils.PointFloat(683.0!, 16.0!)
        Me.SumofFINAMT2.Name = "SumofFINAMT2"
        Me.SumofFINAMT2.SizeF = New System.Drawing.SizeF(92.0!, 15.0!)
        Me.SumofFINAMT2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'CountofCUSTOMERNUMBER1
        '
        Me.CountofCUSTOMERNUMBER1.BackColor = System.Drawing.Color.White
        Me.CountofCUSTOMERNUMBER1.BorderColor = System.Drawing.Color.Black
        Me.CountofCUSTOMERNUMBER1.CanGrow = False
        Me.CountofCUSTOMERNUMBER1.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.CountofCUSTOMERNUMBER1.ForeColor = System.Drawing.Color.Black
        Me.CountofCUSTOMERNUMBER1.LocationFloat = New DevExpress.Utils.PointFloat(483.0!, 16.0!)
        Me.CountofCUSTOMERNUMBER1.Name = "CountofCUSTOMERNUMBER1"
        Me.CountofCUSTOMERNUMBER1.SizeF = New System.Drawing.SizeF(138.0!, 15.0!)
        Me.CountofCUSTOMERNUMBER1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'Line1
        '
        Me.Line1.BackColor = System.Drawing.Color.White
        Me.Line1.BorderColor = System.Drawing.Color.Black
        Me.Line1.Borders = DevExpress.XtraPrinting.BorderSide.Top
        Me.Line1.ForeColor = System.Drawing.Color.Black
        Me.Line1.LocationFloat = New DevExpress.Utils.PointFloat(246.0!, 10.0!)
        Me.Line1.Name = "Line1"
        Me.Line1.SizeF = New System.Drawing.SizeF(528.0!, 2.0!)
        '
        'ReportHeader
        '
        Me.ReportHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.Text5, Me.Text8, Me.Picture1})
        Me.ReportHeader.HeightF = 192.0!
        Me.ReportHeader.Name = "ReportHeader"
        '
        'Text5
        '
        Me.Text5.BackColor = System.Drawing.Color.White
        Me.Text5.BorderColor = System.Drawing.Color.Black
        Me.Text5.CanGrow = False
        Me.Text5.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Text5.ForeColor = System.Drawing.Color.Black
        Me.Text5.LocationFloat = New DevExpress.Utils.PointFloat(175.0!, 8.0!)
        Me.Text5.Name = "Text5"
        Me.Text5.SizeF = New System.Drawing.SizeF(575.0!, 15.0!)
        Me.Text5.Text = "Maturity Pfofile"
        Me.Text5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
        '
        'Text8
        '
        Me.Text8.BackColor = System.Drawing.Color.White
        Me.Text8.BorderColor = System.Drawing.Color.Black
        Me.Text8.CanGrow = False
        Me.Text8.Font = New System.Drawing.Font("Arial", 10.0!)
        Me.Text8.ForeColor = System.Drawing.Color.Black
        Me.Text8.LocationFloat = New DevExpress.Utils.PointFloat(175.0!, 50.0!)
        Me.Text8.Name = "Text8"
        Me.Text8.SizeF = New System.Drawing.SizeF(533.0!, 15.0!)
        Me.Text8.Text = "From " & Global.Microsoft.VisualBasic.ChrW(10) & "{?fDate}" & Global.Microsoft.VisualBasic.ChrW(10) & " to " & Global.Microsoft.VisualBasic.ChrW(10) & "{?tDate}"
        Me.Text8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'Picture1
        '
        Me.Picture1.BackColor = System.Drawing.Color.White
        Me.Picture1.BorderColor = System.Drawing.Color.Black
        Me.Picture1.LocationFloat = New DevExpress.Utils.PointFloat(8.0!, 8.0!)
        Me.Picture1.Name = "Picture1"
        Me.Picture1.SizeF = New System.Drawing.SizeF(141.0!, 166.0!)
        '
        'PageHeader
        '
        Me.PageHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.Text2, Me.Text7, Me.Text1, Me.Text4})
        Me.PageHeader.HeightF = 41.0!
        Me.PageHeader.Name = "PageHeader"
        '
        'Text2
        '
        Me.Text2.BackColor = System.Drawing.Color.White
        Me.Text2.BorderColor = System.Drawing.Color.Black
        Me.Text2.CanGrow = False
        Me.Text2.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Text2.ForeColor = System.Drawing.Color.Black
        Me.Text2.LocationFloat = New DevExpress.Utils.PointFloat(125.0!, 26.0!)
        Me.Text2.Name = "Text2"
        Me.Text2.SizeF = New System.Drawing.SizeF(138.0!, 15.0!)
        Me.Text2.Text = "CUST NUMBER"
        Me.Text2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'Text7
        '
        Me.Text7.BackColor = System.Drawing.Color.White
        Me.Text7.BorderColor = System.Drawing.Color.Black
        Me.Text7.CanGrow = False
        Me.Text7.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Text7.ForeColor = System.Drawing.Color.Black
        Me.Text7.LocationFloat = New DevExpress.Utils.PointFloat(291.0!, 25.0!)
        Me.Text7.Name = "Text7"
        Me.Text7.SizeF = New System.Drawing.SizeF(129.0!, 15.0!)
        Me.Text7.Text = "Name"
        Me.Text7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'Text1
        '
        Me.Text1.BackColor = System.Drawing.Color.White
        Me.Text1.BorderColor = System.Drawing.Color.Black
        Me.Text1.CanGrow = False
        Me.Text1.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Text1.ForeColor = System.Drawing.Color.Black
        Me.Text1.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 26.0!)
        Me.Text1.Name = "Text1"
        Me.Text1.SizeF = New System.Drawing.SizeF(116.0!, 15.0!)
        Me.Text1.Text = "MATURITY DATE"
        Me.Text1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'Text4
        '
        Me.Text4.BackColor = System.Drawing.Color.White
        Me.Text4.BorderColor = System.Drawing.Color.Black
        Me.Text4.CanGrow = False
        Me.Text4.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Text4.ForeColor = System.Drawing.Color.Black
        Me.Text4.LocationFloat = New DevExpress.Utils.PointFloat(658.0!, 26.0!)
        Me.Text4.Name = "Text4"
        Me.Text4.SizeF = New System.Drawing.SizeF(116.0!, 15.0!)
        Me.Text4.Text = "LOAN AMOUNT"
        Me.Text4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'CUSTOMERNUMBER1
        '
        Me.CUSTOMERNUMBER1.BackColor = System.Drawing.Color.White
        Me.CUSTOMERNUMBER1.BorderColor = System.Drawing.Color.Black
        Me.CUSTOMERNUMBER1.CanGrow = False
        Me.CUSTOMERNUMBER1.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "maturity.CUSTOMER_NUMBER")})
        Me.CUSTOMERNUMBER1.Font = New System.Drawing.Font("Arial", 10.0!)
        Me.CUSTOMERNUMBER1.ForeColor = System.Drawing.Color.Black
        Me.CUSTOMERNUMBER1.LocationFloat = New DevExpress.Utils.PointFloat(125.0!, 0.0!)
        Me.CUSTOMERNUMBER1.Name = "CUSTOMERNUMBER1"
        Me.CUSTOMERNUMBER1.SizeF = New System.Drawing.SizeF(138.0!, 15.0!)
        Me.CUSTOMERNUMBER1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'Text6
        '
        Me.Text6.BackColor = System.Drawing.Color.White
        Me.Text6.BorderColor = System.Drawing.Color.Black
        Me.Text6.CanGrow = False
        Me.Text6.Font = New System.Drawing.Font("Arial", 10.0!)
        Me.Text6.ForeColor = System.Drawing.Color.Black
        Me.Text6.LocationFloat = New DevExpress.Utils.PointFloat(288.0!, 0.0!)
        Me.Text6.Name = "Text6"
        Me.Text6.SizeF = New System.Drawing.SizeF(364.0!, 15.0!)
        Me.Text6.Text = "{maturity.SURNAME}" & Global.Microsoft.VisualBasic.ChrW(10) & " " & Global.Microsoft.VisualBasic.ChrW(10) & "{maturity.FORENAMES}"
        Me.Text6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'PAYMENTDATE1
        '
        Me.PAYMENTDATE1.BackColor = System.Drawing.Color.White
        Me.PAYMENTDATE1.BorderColor = System.Drawing.Color.Black
        Me.PAYMENTDATE1.CanGrow = False
        Me.PAYMENTDATE1.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "maturity.PAYMENT_DATE")})
        Me.PAYMENTDATE1.Font = New System.Drawing.Font("Arial", 10.0!)
        Me.PAYMENTDATE1.ForeColor = System.Drawing.Color.Black
        Me.PAYMENTDATE1.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.0!)
        Me.PAYMENTDATE1.Name = "PAYMENTDATE1"
        Me.PAYMENTDATE1.SizeF = New System.Drawing.SizeF(116.0!, 15.0!)
        Me.PAYMENTDATE1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'AMTAPPLIED1
        '
        Me.AMTAPPLIED1.BackColor = System.Drawing.Color.White
        Me.AMTAPPLIED1.BorderColor = System.Drawing.Color.Black
        Me.AMTAPPLIED1.CanGrow = False
        Me.AMTAPPLIED1.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "maturity.AMT_APPLIED")})
        Me.AMTAPPLIED1.Font = New System.Drawing.Font("Arial", 10.0!)
        Me.AMTAPPLIED1.ForeColor = System.Drawing.Color.Black
        Me.AMTAPPLIED1.LocationFloat = New DevExpress.Utils.PointFloat(658.0!, 0.0!)
        Me.AMTAPPLIED1.Name = "AMTAPPLIED1"
        Me.AMTAPPLIED1.SizeF = New System.Drawing.SizeF(116.0!, 15.0!)
        Me.AMTAPPLIED1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'ReportFooter
        '
        Me.ReportFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.SumofFINAMT1, Me.CountofCUSTOMERNUMBER2})
        Me.ReportFooter.HeightF = 41.0!
        Me.ReportFooter.Name = "ReportFooter"
        '
        'SumofFINAMT1
        '
        Me.SumofFINAMT1.BackColor = System.Drawing.Color.White
        Me.SumofFINAMT1.BorderColor = System.Drawing.Color.Black
        Me.SumofFINAMT1.CanGrow = False
        Me.SumofFINAMT1.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.SumofFINAMT1.ForeColor = System.Drawing.Color.Black
        Me.SumofFINAMT1.LocationFloat = New DevExpress.Utils.PointFloat(680.0!, 0.0!)
        Me.SumofFINAMT1.Name = "SumofFINAMT1"
        Me.SumofFINAMT1.SizeF = New System.Drawing.SizeF(92.0!, 15.0!)
        Me.SumofFINAMT1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'CountofCUSTOMERNUMBER2
        '
        Me.CountofCUSTOMERNUMBER2.BackColor = System.Drawing.Color.White
        Me.CountofCUSTOMERNUMBER2.BorderColor = System.Drawing.Color.Black
        Me.CountofCUSTOMERNUMBER2.CanGrow = False
        Me.CountofCUSTOMERNUMBER2.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.CountofCUSTOMERNUMBER2.ForeColor = System.Drawing.Color.Black
        Me.CountofCUSTOMERNUMBER2.LocationFloat = New DevExpress.Utils.PointFloat(483.0!, 0.0!)
        Me.CountofCUSTOMERNUMBER2.Name = "CountofCUSTOMERNUMBER2"
        Me.CountofCUSTOMERNUMBER2.SizeF = New System.Drawing.SizeF(138.0!, 15.0!)
        Me.CountofCUSTOMERNUMBER2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'PageFooter
        '
        Me.PageFooter.HeightF = 41.0!
        Me.PageFooter.Name = "PageFooter"
        '
        'Maturity
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.GroupHeader1, Me.GroupFooter1, Me.ReportHeader, Me.PageHeader, Me.ReportFooter, Me.PageFooter})
        Me.DataAdapter = Me.oleDbDataAdapter1
        Me.Margins = New System.Drawing.Printing.Margins(23, 23, 16, 16)
        Me.PageHeight = 1167
        Me.PageWidth = 825
        Me.PaperKind = System.Drawing.Printing.PaperKind.Custom
        Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
        Me.Version = "13.2"
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub

#End Region

End Class