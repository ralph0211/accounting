Imports System.Data
Imports System.Data.SqlClient

Partial Class UserActivityReports
    Inherits System.Web.UI.Page
    Dim cmd As SqlCommand
    Dim adp As SqlDataAdapter
    Dim con As New SqlConnection

    Protected Sub btnView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnView.Click
        Try
            'Dim strscript As String

            Dim activity = rdbActivityType.SelectedValue
            If activity = "Logins" Then
                Response.Redirect("frmUserActivityLogin.aspx")
            ElseIf activity = "Page Views" Then
                Response.Redirect("frmUserActivityPages.aspx")
            ElseIf activity = "Actions" Then
                Response.Redirect("frmUserActivityActions.aspx")
            End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Page.MaintainScrollPositionOnPostBack = True
        Page.Header.Title = "360 Credit Management: Print Amortization Schedule"
        con = New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
    End Sub
End Class
