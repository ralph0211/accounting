Imports System.Data.SqlClient
Imports System.Data

Partial Class Credit_rptRatingStatement
    Inherits System.Web.UI.Page
    Dim myreport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Session("UserID") = String.Empty Then
                'not logged in redirect to login page
                Response.Redirect("~/Login.aspx", False)
                Exit Sub
            End If

            Dim loanID = Request.QueryString("LOANID")

            myreport.Load(Server.MapPath("rptRatingStatement.rpt"))

            Dim myParameterFields As New CrystalDecisions.Shared.ParameterFields()
            Dim myParameterField2 As New CrystalDecisions.Shared.ParameterField()
            Dim myDiscreteValue2 As New CrystalDecisions.Shared.ParameterDiscreteValue()

            myParameterField2.ParameterFieldName = "ploanID"
            myDiscreteValue2.Value = loanID
            myParameterField2.CurrentValues.Add(myDiscreteValue2)
            myParameterFields.Add(myParameterField2)
            CrystalReportViewer1.ReportSource = myreport
            CrystalReportViewer1.ParameterFieldInfo = myParameterFields
            CrystalReportViewer1.RefreshReport()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Unload
        myreport.Close()
        myreport.Dispose()
        GC.Collect()
    End Sub
End Class