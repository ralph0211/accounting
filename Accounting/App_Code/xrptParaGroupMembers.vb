Public Class xrptParaGroupMembers
    Inherits DevExpress.XtraReports.UI.XtraReport

#Region " Designer generated code "

    Private WithEvents bottomMarginBand1 As DevExpress.XtraReports.UI.BottomMarginBand

    Private WithEvents custNo As DevExpress.XtraReports.Parameters.Parameter

    Private WithEvents DataField As DevExpress.XtraReports.UI.XRControlStyle

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
    Private WithEvents xrLabel12 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel13 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel14 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel15 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel16 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel17 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel18 As DevExpress.XtraReports.UI.XRLabel
    Private dsStaticDetails1 As dsStaticDetails
    Private groupMembersTableAdapter1 As dsStaticDetailsTableAdapters.GroupMembersTableAdapter
    Private WithEvents groupHeaderBand1 As DevExpress.XtraReports.UI.GroupHeaderBand
    Private WithEvents xrLabel3 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel4 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLine1 As DevExpress.XtraReports.UI.XRLine
    Private WithEvents groupHeaderBand2 As DevExpress.XtraReports.UI.GroupHeaderBand
    Private WithEvents xrLabel5 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel6 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel7 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel8 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel9 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel10 As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents xrLabel11 As DevExpress.XtraReports.UI.XRLabel
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
    Private WithEvents topMarginBand1 As DevExpress.XtraReports.UI.TopMarginBand
    'Required by the Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Designer
    'It can be modified using the Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resourceFileName As String = "xrptParaGroupMembers.resx"
        Dim dynamicListLookUpSettings1 As DevExpress.XtraReports.Parameters.DynamicListLookUpSettings = New DevExpress.XtraReports.Parameters.DynamicListLookUpSettings()
        Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
        Me.dsStaticDetails1 = New dsStaticDetails()
        Me.groupMembersTableAdapter1 = New dsStaticDetailsTableAdapters.GroupMembersTableAdapter()
        Me.groupHeaderBand1 = New DevExpress.XtraReports.UI.GroupHeaderBand()
        Me.xrLabel3 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel4 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLine1 = New DevExpress.XtraReports.UI.XRLine()
        Me.groupHeaderBand2 = New DevExpress.XtraReports.UI.GroupHeaderBand()
        Me.xrLabel5 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel6 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel7 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel8 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel9 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel10 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel11 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel12 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel13 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel14 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel15 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel16 = New DevExpress.XtraReports.UI.XRLabel()
        Me.xrLabel17 = New DevExpress.XtraReports.UI.XRLabel()
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
        Me.custNo = New DevExpress.XtraReports.Parameters.Parameter()
        CType(Me.dsStaticDetails1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.xrLabel12, Me.xrLabel13, Me.xrLabel14, Me.xrLabel15, Me.xrLabel16, Me.xrLabel17, Me.xrLabel18})
        Me.Detail.HeightF = 36.0!
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
        'groupMembersTableAdapter1
        '
        Me.groupMembersTableAdapter1.ClearBeforeFill = True
        '
        'groupHeaderBand1
        '
        Me.groupHeaderBand1.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.xrLabel3, Me.xrLabel4, Me.xrLine1})
        Me.groupHeaderBand1.GroupFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("CUSTOMER_NUMBER1", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending), New DevExpress.XtraReports.UI.GroupField("SURNAME", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
        Me.groupHeaderBand1.HeightF = 46.0!
        Me.groupHeaderBand1.Level = 1
        Me.groupHeaderBand1.Name = "groupHeaderBand1"
        '
        'xrLabel3
        '
        Me.xrLabel3.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "GroupMembers.CUSTOMER_NUMBER1")})
        Me.xrLabel3.Font = New System.Drawing.Font("Times New Roman", 11.0!, System.Drawing.FontStyle.Bold)
        Me.xrLabel3.LocationFloat = New DevExpress.Utils.PointFloat(6.00001!, 19.99998!)
        Me.xrLabel3.Name = "xrLabel3"
        Me.xrLabel3.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel3.SizeF = New System.Drawing.SizeF(122.625!, 26.00002!)
        Me.xrLabel3.StyleName = "DataField"
        Me.xrLabel3.StylePriority.UseFont = False
        Me.xrLabel3.Text = "xrLabel3"
        '
        'xrLabel4
        '
        Me.xrLabel4.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "GroupMembers.SURNAME")})
        Me.xrLabel4.Font = New System.Drawing.Font("Times New Roman", 11.0!, System.Drawing.FontStyle.Bold)
        Me.xrLabel4.LocationFloat = New DevExpress.Utils.PointFloat(128.625!, 19.99998!)
        Me.xrLabel4.Name = "xrLabel4"
        Me.xrLabel4.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel4.SizeF = New System.Drawing.SizeF(353.375!, 26.00002!)
        Me.xrLabel4.StyleName = "DataField"
        Me.xrLabel4.StylePriority.UseFont = False
        Me.xrLabel4.Text = "xrLabel4"
        '
        'xrLine1
        '
        Me.xrLine1.LocationFloat = New DevExpress.Utils.PointFloat(6.0!, 18.0!)
        Me.xrLine1.Name = "xrLine1"
        Me.xrLine1.SizeF = New System.Drawing.SizeF(476.0!, 2.0!)
        '
        'groupHeaderBand2
        '
        Me.groupHeaderBand2.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.xrLabel5, Me.xrLabel6, Me.xrLabel7, Me.xrLabel8, Me.xrLabel9, Me.xrLabel10, Me.xrLabel11})
        Me.groupHeaderBand2.HeightF = 24.00001!
        Me.groupHeaderBand2.Name = "groupHeaderBand2"
        Me.groupHeaderBand2.StyleName = "FieldCaption"
        '
        'xrLabel5
        '
        Me.xrLabel5.LocationFloat = New DevExpress.Utils.PointFloat(6.00001!, 6.00001!)
        Me.xrLabel5.Name = "xrLabel5"
        Me.xrLabel5.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel5.SizeF = New System.Drawing.SizeF(84.66579!, 18.0!)
        Me.xrLabel5.Text = "Position"
        '
        'xrLabel6
        '
        Me.xrLabel6.LocationFloat = New DevExpress.Utils.PointFloat(90.6658!, 6.00001!)
        Me.xrLabel6.Name = "xrLabel6"
        Me.xrLabel6.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel6.SizeF = New System.Drawing.SizeF(175.9912!, 18.0!)
        Me.xrLabel6.Text = "Name"
        '
        'xrLabel7
        '
        Me.xrLabel7.LocationFloat = New DevExpress.Utils.PointFloat(266.657!, 6.00001!)
        Me.xrLabel7.Name = "xrLabel7"
        Me.xrLabel7.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel7.SizeF = New System.Drawing.SizeF(123.4285!, 18.0!)
        Me.xrLabel7.Text = "ID Number"
        '
        'xrLabel8
        '
        Me.xrLabel8.LocationFloat = New DevExpress.Utils.PointFloat(390.0855!, 6.00001!)
        Me.xrLabel8.Name = "xrLabel8"
        Me.xrLabel8.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel8.SizeF = New System.Drawing.SizeF(111.9978!, 18.0!)
        Me.xrLabel8.Text = "Date of Birth"
        '
        'xrLabel9
        '
        Me.xrLabel9.LocationFloat = New DevExpress.Utils.PointFloat(502.0833!, 6.00001!)
        Me.xrLabel9.Name = "xrLabel9"
        Me.xrLabel9.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel9.SizeF = New System.Drawing.SizeF(199.5027!, 18.0!)
        Me.xrLabel9.Text = "Address"
        '
        'xrLabel10
        '
        Me.xrLabel10.LocationFloat = New DevExpress.Utils.PointFloat(701.5859!, 6.00001!)
        Me.xrLabel10.Name = "xrLabel10"
        Me.xrLabel10.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel10.SizeF = New System.Drawing.SizeF(117.8561!, 18.0!)
        Me.xrLabel10.Text = "Phone"
        '
        'xrLabel11
        '
        Me.xrLabel11.LocationFloat = New DevExpress.Utils.PointFloat(819.4421!, 6.00001!)
        Me.xrLabel11.Name = "xrLabel11"
        Me.xrLabel11.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel11.SizeF = New System.Drawing.SizeF(74.55792!, 18.0!)
        Me.xrLabel11.Text = "Gender"
        '
        'xrLabel12
        '
        Me.xrLabel12.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "GroupMembers.POSITION")})
        Me.xrLabel12.LocationFloat = New DevExpress.Utils.PointFloat(6.00001!, 0.0!)
        Me.xrLabel12.Name = "xrLabel12"
        Me.xrLabel12.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96.0!)
        Me.xrLabel12.SizeF = New System.Drawing.SizeF(84.66579!, 18.0!)
        Me.xrLabel12.Text = "xrLabel12"
        '
        'xrLabel13
        '
        Me.xrLabel13.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "GroupMembers.NAME")})
        Me.xrLabel13.LocationFloat = New DevExpress.Utils.PointFloat(90.6658!, 0.0!)
        Me.xrLabel13.Name = "xrLabel13"
        Me.xrLabel13.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96.0!)
        Me.xrLabel13.SizeF = New System.Drawing.SizeF(175.9912!, 18.0!)
        Me.xrLabel13.Text = "xrLabel13"
        '
        'xrLabel14
        '
        Me.xrLabel14.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "GroupMembers.IDNO")})
        Me.xrLabel14.LocationFloat = New DevExpress.Utils.PointFloat(266.657!, 0.0!)
        Me.xrLabel14.Name = "xrLabel14"
        Me.xrLabel14.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96.0!)
        Me.xrLabel14.SizeF = New System.Drawing.SizeF(123.4285!, 18.0!)
        Me.xrLabel14.Text = "xrLabel14"
        '
        'xrLabel15
        '
        Me.xrLabel15.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "GroupMembers.DOB", "{0:dd MMM,yyyy}")})
        Me.xrLabel15.LocationFloat = New DevExpress.Utils.PointFloat(390.0855!, 0.0!)
        Me.xrLabel15.Name = "xrLabel15"
        Me.xrLabel15.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96.0!)
        Me.xrLabel15.SizeF = New System.Drawing.SizeF(111.9978!, 18.0!)
        Me.xrLabel15.Text = "xrLabel15"
        '
        'xrLabel16
        '
        Me.xrLabel16.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "GroupMembers.ADDRESS")})
        Me.xrLabel16.LocationFloat = New DevExpress.Utils.PointFloat(502.0833!, 0.0!)
        Me.xrLabel16.Name = "xrLabel16"
        Me.xrLabel16.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96.0!)
        Me.xrLabel16.SizeF = New System.Drawing.SizeF(199.5027!, 18.0!)
        Me.xrLabel16.Text = "xrLabel16"
        '
        'xrLabel17
        '
        Me.xrLabel17.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "GroupMembers.PHONE")})
        Me.xrLabel17.LocationFloat = New DevExpress.Utils.PointFloat(701.5859!, 0.0!)
        Me.xrLabel17.Name = "xrLabel17"
        Me.xrLabel17.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96.0!)
        Me.xrLabel17.SizeF = New System.Drawing.SizeF(117.8561!, 18.0!)
        Me.xrLabel17.Text = "xrLabel17"
        '
        'xrLabel18
        '
        Me.xrLabel18.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "GroupMembers.GENDER")})
        Me.xrLabel18.LocationFloat = New DevExpress.Utils.PointFloat(819.4421!, 0.0!)
        Me.xrLabel18.Name = "xrLabel18"
        Me.xrLabel18.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96.0!)
        Me.xrLabel18.SizeF = New System.Drawing.SizeF(74.55792!, 18.0!)
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
        Me.xrLine2.LocationFloat = New DevExpress.Utils.PointFloat(6.0!, 0.0!)
        Me.xrLine2.Name = "xrLine2"
        Me.xrLine2.SizeF = New System.Drawing.SizeF(888.0!, 2.0!)
        '
        'xrPageInfo1
        '
        Me.xrPageInfo1.LocationFloat = New DevExpress.Utils.PointFloat(6.0!, 8.0!)
        Me.xrPageInfo1.Name = "xrPageInfo1"
        Me.xrPageInfo1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrPageInfo1.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime
        Me.xrPageInfo1.SizeF = New System.Drawing.SizeF(438.0!, 23.0!)
        Me.xrPageInfo1.StyleName = "PageInfo"
        '
        'xrPageInfo2
        '
        Me.xrPageInfo2.Format = "Page {0} of {1}"
        Me.xrPageInfo2.LocationFloat = New DevExpress.Utils.PointFloat(456.0!, 8.0!)
        Me.xrPageInfo2.Name = "xrPageInfo2"
        Me.xrPageInfo2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrPageInfo2.SizeF = New System.Drawing.SizeF(438.0!, 23.0!)
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
        Me.xrLabel19.LocationFloat = New DevExpress.Utils.PointFloat(6.0!, 2.0!)
        Me.xrLabel19.Name = "xrLabel19"
        Me.xrLabel19.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrLabel19.SizeF = New System.Drawing.SizeF(888.0!, 33.0!)
        Me.xrLabel19.StyleName = "Title"
        Me.xrLabel19.Text = "Static Details - Group Members"
        '
        'xrLine3
        '
        Me.xrLine3.LocationFloat = New DevExpress.Utils.PointFloat(6.0!, 0.0!)
        Me.xrLine3.Name = "xrLine3"
        Me.xrLine3.SizeF = New System.Drawing.SizeF(888.0!, 2.0!)
        '
        'xrLine4
        '
        Me.xrLine4.LocationFloat = New DevExpress.Utils.PointFloat(6.0!, 35.0!)
        Me.xrLine4.Name = "xrLine4"
        Me.xrLine4.SizeF = New System.Drawing.SizeF(888.0!, 2.0!)
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
        'custNo
        '
        Me.custNo.Description = "Group Name"
        dynamicListLookUpSettings1.DataAdapter = Me.groupMembersTableAdapter1
        dynamicListLookUpSettings1.DataMember = "CustomerDetails"
        dynamicListLookUpSettings1.DataSource = Me.dsStaticDetails1
        dynamicListLookUpSettings1.DisplayMember = "SURNAME"
        dynamicListLookUpSettings1.ValueMember = "CUSTOMER_NUMBER"
        Me.custNo.LookUpSettings = dynamicListLookUpSettings1
        Me.custNo.Name = "custNo"
        '
        'xrptParaGroupMembers
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.groupHeaderBand1, Me.groupHeaderBand2, Me.pageFooterBand1, Me.reportHeaderBand1, Me.topMarginBand1, Me.bottomMarginBand1})
        Me.DataAdapter = Me.groupMembersTableAdapter1
        Me.DataMember = "GroupMembers"
        Me.DataSource = Me.dsStaticDetails1
        ' Me.FilterString = "[CUSTOMER_NUMBER] = ?custNo"
        Me.FilterString = "true"
        Me.Landscape = True
        Me.PageHeight = 850
        Me.PageWidth = 1100
        Me.Parameters.AddRange(New DevExpress.XtraReports.Parameters.Parameter() {Me.custNo})
        Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
        Me.StyleSheet.AddRange(New DevExpress.XtraReports.UI.XRControlStyle() {Me.Title, Me.FieldCaption, Me.PageInfo, Me.DataField})
        Me.Version = "13.2"
        CType(Me.dsStaticDetails1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand

#End Region

    Private Sub xrptParaGroupMembers_ParametersRequestSubmit(sender As Object, e As DevExpress.XtraReports.Parameters.ParametersRequestEventArgs) Handles Me.ParametersRequestSubmit
        If custNo.Value.ToString = String.Empty Then
            Me.FilterString = "true"
        Else

        End If
    End Sub
End Class