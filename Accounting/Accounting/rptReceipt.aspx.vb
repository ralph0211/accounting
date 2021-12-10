
Partial Class Accounting_rptReceipt
    Inherits System.Web.UI.Page
    Dim myreport As CrystalDecisions.CrystalReports.Engine.ReportDocument

    Protected Sub CrystalReportViewer1_Init(sender As Object, e As System.EventArgs) Handles CrystalReportViewer1.Init

    End Sub

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Try
            If Session("UserID") = String.Empty Then
                'not logged in redirect to login page
                Response.Redirect("~/Login.aspx", False)
                Exit Sub
            End If
            'Dim DecQuery As New BankEncryption64

            'Dim query = DecQuery.Decrypt(Request.QueryString("qry").Replace(" ", "+"), "lovely12345")
            Dim receiptno As String = Request.QueryString("receiptno")
            myreport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()
            myreport.Load(Server.MapPath("rptReceipt.rpt"))
            myreport.SetParameterValue("receiptno", receiptno)
            'Dim myParameterFields As New CrystalDecisions.Shared.ParameterFields()
            'Dim myParameterField As New CrystalDecisions.Shared.ParameterField()
            'Dim myDiscreteValue As New CrystalDecisions.Shared.ParameterDiscreteValue()
            'myParameterField.ParameterFieldName = "refNo"
            'myDiscreteValue.Value = refNo
            'myParameterField.CurrentValues.Add(myDiscreteValue)
            'myParameterFields.Add(myParameterField)
            CrystalReportViewer1.ReportSource = myreport
            'msgbox(receiptno)
            'CrystalReportViewer1.ParameterFieldInfo = myParameterFields

            'CrystalReportViewer1.RefreshReport()


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub msgbox(ByVal strMessage As String)

        'finishes server processing, returns to client.
        Dim strScript As String = "<script language=JavaScript>"
        strScript += "window.alert(""" & strMessage & """);"
        strScript += "</script>"
        Dim lbl As New System.Web.UI.WebControls.Label
        lbl.Text = strScript
        Page.Controls.Add(lbl)

    End Sub

    Protected Sub Page_Unload(sender As Object, e As System.EventArgs) Handles Me.Unload
        Try
            myreport.Close()
            myreport.Dispose()
            GC.Collect()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class
