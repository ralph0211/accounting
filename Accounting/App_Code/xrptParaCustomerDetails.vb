Public Class xrptParaCustomerDetails
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
    Private WithEvents xrLabel11 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel12 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel13 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel14 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel15 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel16 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel18 As DevExpress.XtraReports.UI.XRLabel
    Private dsStaticDetails1 As dsStaticDetails
    Private customerDetailsTableAdapter1 As dsStaticDetailsTableAdapters.CustomerDetailsTableAdapter
    Private WithEvents groupHeaderBand1 As DevExpress.XtraReports.UI.GroupHeaderBand
    Private WithEvents xrLabel2 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLine1 As DevExpress.XtraReports.UI.XRLine
    Private WithEvents groupHeaderBand2 As DevExpress.XtraReports.UI.GroupHeaderBand
    Private WithEvents xrLabel3 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel4 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel5 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel6 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel7 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel8 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel10 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents pageFooterBand1 As DevExpress.XtraReports.UI.PageFooterBand
    Private WithEvents xrLine2 As DevExpress.XtraReports.UI.XRLine
    Private WithEvents xrPageInfo1 As DevExpress.XtraReports.UI.XRPageInfo
    Private WithEvents xrPageInfo2 As DevExpress.XtraReports.UI.XRPageInfo
    Private WithEvents reportHeaderBand1 As DevExpress.XtraReports.UI.ReportHeaderBand
    Private WithEvents xrLabel19 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLine3 As DevExpress.XtraReports.UI.XRLine
    Private WithEvents xrLine4 As DevExpress.XtraReports.UI.XRLine
    Private WithEvents Title As DevExpress.XtraReports.UI.XRControlStyle
    Private WithEvents FieldCaption As DevExpress.XtraReports.UI.XRControlStyle
    Private WithEvents PageInfo As DevExpress.XtraReports.UI.XRControlStyle
    Private WithEvents DataField As DevExpress.XtraReports.UI.XRControlStyle
    Private WithEvents topMarginBand1 As DevExpress.XtraReports.UI.TopMarginBand
    Private WithEvents bottomMarginBand1 As DevExpress.XtraReports.UI.BottomMarginBand
    Private WithEvents custName As DevExpress.XtraReports.UI.CalculatedField
    Private WithEvents custAddress As DevExpress.XtraReports.UI.CalculatedField

    'Required by the Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Designer
    'It can be modified using the Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resourceFileName As String = "xrptParaCustomerDetails.resx"
        Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
        Me.dsStaticDetails1 = New dsStaticDetails()
        Me.customerDetailsTableAdapter1 = New dsStaticDetailsTableAdapters.CustomerDetailsTableAdapter()
        Me.groupHeaderBand1 = New DevExpress.XtraReports.UI.GroupHeaderBand()
        Me.xrLabel2 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLine1 = New DevExpress.XtraReports.UI.XRLine()
        Me.groupHeaderBand2 = New DevExpress.XtraReports.UI.GroupHeaderBand()
        Me.xrLabel3 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel4 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel5 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel6 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel7 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel8 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel10 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel11 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel12 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel13 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel14 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel15 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel16 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel18 = New DevExpress.XtraReports.UI.XRLabel()
        Me.pageFooterBand1 = New DevExpress.XtraReports.UI.PageFooterBand()
        Me.xrLine2 = New DevExpress.XtraReports.UI.XRLine()
        Me.xrPageInfo1 = New DevExpress.XtraReports.UI.XRPageInfo()
        Me.xrPageInfo2 = New DevExpress.XtraReports.UI.XRPageInfo()
        Me.reportHeaderBand1 = New DevExpress.XtraReports.UI.ReportHeaderBand()
        Me.xrLabel19 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLine3 = New DevExpress.XtraReports.UI.XRLine()
        Me.xrLine4 = New DevExpress.XtraReports.UI.XRLine()
        Me.Title = New DevExpress.XtraReports.UI.XRControlStyle()
        Me.FieldCaption = New DevExpress.XtraReports.UI.XRControlStyle()
        Me.PageInfo = New DevExpress.XtraReports.UI.XRControlStyle()
        Me.DataField = New DevExpress.XtraReports.UI.XRControlStyle()
        Me.topMarginBand1 = New DevExpress.XtraReports.UI.TopMarginBand()
        Me.bottomMarginBand1 = New DevExpress.XtraReports.UI.BottomMarginBand()
        Me.custName = New DevExpress.XtraReports.UI.CalculatedField()
        Me.custAddress = New DevExpress.XtraReports.UI.CalculatedField()
        CType(Me.dsStaticDetails1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.xrLabel11, Me.xrLabel12, Me.xrLabel13, Me.xrLabel14, Me.xrLabel15, Me.xrLabel16, Me.xrLabel18})
        Me.Detail.HeightF = 35.49998!
        Me.Detail.Name = "Detail"
        Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.Detail.StyleName = "DataField"
        Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'dsStaticDetails1
        '
        Me.dsStaticDetails1.DataSetName = "dsStaticDetails"
        Me.dsStaticDetails1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'customerDetailsTableAdapter1
        '
        Me.customerDetailsTableAdapter1.ClearBeforeFill = True
        '
        'groupHeaderBand1
        '
        Me.groupHeaderBand1.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.xrLabel2, Me.xrLine1})
        Me.groupHeaderBand1.GroupFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("CUSTOMER_TYPE", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
        Me.groupHeaderBand1.HeightF = 29.66665!
        Me.groupHeaderBand1.Level = 1
        Me.groupHeaderBand1.Name = "groupHeaderBand1"
        '
        'xrLabel2
        '
        Me.xrLabel2.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "CustomerDetails.CUSTOMER_TYPE")})
        Me.xrLabel2.Font = New System.Drawing.Font("Times New Roman", 11.0!, System.Drawing.FontStyle.Bold)
        Me.xrLabel2.LocationFloat = New DevExpress.Utils.PointFloat(5.999994!, 1.999982!)
        Me.xrLabel2.Name = "xrLabel2"
        Me.xrLabel2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel2.SizeF = New System.Drawing.SizeF(509.0001!, 26.00002!)
        Me.xrLabel2.StyleName = "DataField"
        Me.xrLabel2.StylePriority.UseFont = False
        Me.xrLabel2.Text = "xrLabel2"
        '
        'xrLine1
        '
        Me.xrLine1.LocationFloat = New DevExpress.Utils.PointFloat(6.0!, 0.0!)
        Me.xrLine1.Name = "xrLine1"
        Me.xrLine1.SizeF = New System.Drawing.SizeF(254.0!, 2.0!)
        '
        'groupHeaderBand2
        '
        Me.groupHeaderBand2.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.xrLabel3, Me.xrLabel4, Me.xrLabel5, Me.xrLabel6, Me.xrLabel7, Me.xrLabel8, Me.xrLabel10})
        Me.groupHeaderBand2.HeightF = 24.00001!
        Me.groupHeaderBand2.Name = "groupHeaderBand2"
        Me.groupHeaderBand2.StyleName = "FieldCaption"
        '
        'xrLabel3
        '
        Me.xrLabel3.LocationFloat = New DevExpress.Utils.PointFloat(6.00001!, 6.00001!)
        Me.xrLabel3.Name = "xrLabel3"
        Me.xrLabel3.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel3.SizeF = New System.Drawing.SizeF(89.9593!, 18.0!)
        Me.xrLabel3.Text = "Account No."
        '
        'xrLabel4
        '
        Me.xrLabel4.LocationFloat = New DevExpress.Utils.PointFloat(95.95931!, 6.00001!)
        Me.xrLabel4.Name = "xrLabel4"
        Me.xrLabel4.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel4.SizeF = New System.Drawing.SizeF(143.9392!, 18.0!)
        Me.xrLabel4.Text = "Name"
        '
        'xrLabel5
        '
        Me.xrLabel5.LocationFloat = New DevExpress.Utils.PointFloat(239.8985!, 6.00001!)
        Me.xrLabel5.Name = "xrLabel5"
        Me.xrLabel5.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel5.SizeF = New System.Drawing.SizeF(130.3067!, 18.0!)
        Me.xrLabel5.Text = "ID Number"
        '
        'xrLabel6
        '
        Me.xrLabel6.LocationFloat = New DevExpress.Utils.PointFloat(370.2052!, 6.00001!)
        Me.xrLabel6.Name = "xrLabel6"
        Me.xrLabel6.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel6.SizeF = New System.Drawing.SizeF(108.6689!, 18.0!)
        Me.xrLabel6.Text = "Date of Birth"
        '
        'xrLabel7
        '
        Me.xrLabel7.LocationFloat = New DevExpress.Utils.PointFloat(478.8741!, 6.00001!)
        Me.xrLabel7.Name = "xrLabel7"
        Me.xrLabel7.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel7.SizeF = New System.Drawing.SizeF(214.7651!, 18.0!)
        Me.xrLabel7.Text = "Address"
        '
        'xrLabel8
        '
        Me.xrLabel8.LocationFloat = New DevExpress.Utils.PointFloat(693.6392!, 6.00001!)
        Me.xrLabel8.Name = "xrLabel8"
        Me.xrLabel8.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel8.SizeF = New System.Drawing.SizeF(123.116!, 18.0!)
        Me.xrLabel8.Text = "Phone"
        '
        'xrLabel10
        '
        Me.xrLabel10.LocationFloat = New DevExpress.Utils.PointFloat(816.7552!, 6.00001!)
        Me.xrLabel10.Name = "xrLabel10"
        Me.xrLabel10.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel10.SizeF = New System.Drawing.SizeF(82.24487!, 18.0!)
        Me.xrLabel10.Text = "Gender"
        '
        'xrLabel11
        '
        Me.xrLabel11.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "CustomerDetails.CUSTOMER_NUMBER")})
        Me.xrLabel11.LocationFloat = New DevExpress.Utils.PointFloat(6.00001!, 0.0!)
        Me.xrLabel11.Name = "xrLabel11"
        Me.xrLabel11.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96.0!)
        Me.xrLabel11.SizeF = New System.Drawing.SizeF(89.9593!, 34.87498!)
        Me.xrLabel11.Text = "xrLabel11"
        '
        'xrLabel12
        '
        Me.xrLabel12.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "CustomerDetails.custName")})
        Me.xrLabel12.LocationFloat = New DevExpress.Utils.PointFloat(95.95931!, 0.0!)
        Me.xrLabel12.Name = "xrLabel12"
        Me.xrLabel12.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96.0!)
        Me.xrLabel12.SizeF = New System.Drawing.SizeF(143.9392!, 34.87498!)
        '
        'xrLabel13
        '
        Me.xrLabel13.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "CustomerDetails.IDNO")})
        Me.xrLabel13.LocationFloat = New DevExpress.Utils.PointFloat(239.8985!, 0.0!)
        Me.xrLabel13.Name = "xrLabel13"
        Me.xrLabel13.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96.0!)
        Me.xrLabel13.SizeF = New System.Drawing.SizeF(130.3067!, 34.87498!)
        Me.xrLabel13.Text = "xrLabel13"
        '
        'xrLabel14
        '
        Me.xrLabel14.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "CustomerDetails.DOB", "{0:dd MMM,yyyy}")})
        Me.xrLabel14.LocationFloat = New DevExpress.Utils.PointFloat(370.2052!, 0.0!)
        Me.xrLabel14.Name = "xrLabel14"
        Me.xrLabel14.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96.0!)
        Me.xrLabel14.SizeF = New System.Drawing.SizeF(108.6689!, 34.87498!)
        Me.xrLabel14.Text = "xrLabel14"
        '
        'xrLabel15
        '
        Me.xrLabel15.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "CustomerDetails.custAddress")})
        Me.xrLabel15.LocationFloat = New DevExpress.Utils.PointFloat(478.8741!, 0.0!)
        Me.xrLabel15.Name = "xrLabel15"
        Me.xrLabel15.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96.0!)
        Me.xrLabel15.SizeF = New System.Drawing.SizeF(214.7651!, 34.87498!)
        '
        'xrLabel16
        '
        Me.xrLabel16.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "CustomerDetails.PHONE_NO")})
        Me.xrLabel16.LocationFloat = New DevExpress.Utils.PointFloat(693.6392!, 0.0!)
        Me.xrLabel16.Name = "xrLabel16"
        Me.xrLabel16.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96.0!)
        Me.xrLabel16.SizeF = New System.Drawing.SizeF(123.116!, 34.87498!)
        Me.xrLabel16.Text = "xrLabel16"
        '
        'xrLabel18
        '
        Me.xrLabel18.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "CustomerDetails.GENDER")})
        Me.xrLabel18.LocationFloat = New DevExpress.Utils.PointFloat(816.7552!, 0.0!)
        Me.xrLabel18.Name = "xrLabel18"
        Me.xrLabel18.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96.0!)
        Me.xrLabel18.SizeF = New System.Drawing.SizeF(82.24487!, 34.87498!)
        Me.xrLabel18.Text = "xrLabel18"
        '
        'pageFooterBand1
        '
        Me.pageFooterBand1.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.xrLine2, Me.xrPageInfo1, Me.xrPageInfo2})
        Me.pageFooterBand1.HeightF = 31.0!
        Me.pageFooterBand1.Name = "pageFooterBand1"
        '
        'xrLine2
        '
        Me.xrLine2.LocationFloat = New DevExpress.Utils.PointFloat(6.00001!, 0.0!)
        Me.xrLine2.Name = "xrLine2"
        Me.xrLine2.SizeF = New System.Drawing.SizeF(893.0001!, 5.125014!)
        '
        'xrPageInfo1
        '
        Me.xrPageInfo1.LocationFloat = New DevExpress.Utils.PointFloat(6.0!, 8.0!)
        Me.xrPageInfo1.Name = "xrPageInfo1"
        Me.xrPageInfo1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrPageInfo1.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime
        Me.xrPageInfo1.SizeF = New System.Drawing.SizeF(313.0!, 23.0!)
        Me.xrPageInfo1.StyleName = "PageInfo"
        '
        'xrPageInfo2
        '
        Me.xrPageInfo2.Format = "Page {0} of {1}"
        Me.xrPageInfo2.LocationFloat = New DevExpress.Utils.PointFloat(331.0!, 7.999992!)
        Me.xrPageInfo2.Name = "xrPageInfo2"
        Me.xrPageInfo2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrPageInfo2.SizeF = New System.Drawing.SizeF(568.0001!, 23.0!)
        Me.xrPageInfo2.StyleName = "PageInfo"
        Me.xrPageInfo2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'reportHeaderBand1
        '
        Me.reportHeaderBand1.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.xrLabel19, Me.xrLine3, Me.xrLine4})
        Me.reportHeaderBand1.HeightF = 51.0!
        Me.reportHeaderBand1.Name = "reportHeaderBand1"
        '
        'xrLabel19
        '
        Me.xrLabel19.LocationFloat = New DevExpress.Utils.PointFloat(6.00001!, 2.083333!)
        Me.xrLabel19.Name = "xrLabel19"
        Me.xrLabel19.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel19.SizeF = New System.Drawing.SizeF(893.0!, 32.91664!)
        Me.xrLabel19.StyleName = "Title"
        Me.xrLabel19.Text = "Static Details - Customer Details"
        '
        'xrLine3
        '
        Me.xrLine3.LocationFloat = New DevExpress.Utils.PointFloat(6.00001!, 0.0!)
        Me.xrLine3.Name = "xrLine3"
        Me.xrLine3.SizeF = New System.Drawing.SizeF(893.0!, 2.083333!)
        '
        'xrLine4
        '
        Me.xrLine4.LocationFloat = New DevExpress.Utils.PointFloat(6.00001!, 35.00001!)
        Me.xrLine4.Name = "xrLine4"
        Me.xrLine4.SizeF = New System.Drawing.SizeF(893.0!, 2.083332!)
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
        'custName
        '
        Me.custName.DataMember = "CustomerDetails"
        Me.custName.Expression = "[FORENAMES] + ' ' + [SURNAME]"
        Me.custName.Name = "custName"
        '
        'custAddress
        '
        Me.custAddress.DataMember = "CustomerDetails"
        Me.custAddress.Expression = "[ADDRESS] + ' ' + [CITY]"
        Me.custAddress.Name = "custAddress"
        '
        'xrptParaCustomerDetails
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.groupHeaderBand1, Me.groupHeaderBand2, Me.pageFooterBand1, Me.reportHeaderBand1, Me.topMarginBand1, Me.bottomMarginBand1})
        Me.CalculatedFields.AddRange(New DevExpress.XtraReports.UI.CalculatedField() {Me.custName, Me.custAddress})
        Me.DataAdapter = Me.customerDetailsTableAdapter1
        Me.DataMember = "CustomerDetails"
        Me.DataSource = Me.dsStaticDetails1
        Me.Landscape = True
        Me.Margins = New System.Drawing.Printing.Margins(100, 101, 100, 100)
        Me.PageHeight = 850
        Me.PageWidth = 1100
        Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
        Me.StyleSheet.AddRange(New DevExpress.XtraReports.UI.XRControlStyle() {Me.Title, Me.FieldCaption, Me.PageInfo, Me.DataField})
        Me.Version = "13.2"
        CType(Me.dsStaticDetails1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand

#End Region

End Class