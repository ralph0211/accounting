Imports System.Data
Imports System.Data.SqlClient

Partial Class Credit_frmBranchReport
    Inherits System.Web.UI.Page
    Dim adp As SqlDataAdapter
    Dim cmd As SqlCommand
    Dim con As New SqlConnection
    Dim connection As String

    Protected Sub btnPrint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Try
            Dim strscript As String

            strscript = "<script langauage=JavaScript>"
            strscript += "window.open('rptBranchReport.aspx?brnch=" & cmbBranch.SelectedValue & "&from=" & bdpFromDate.Text & "&to=" & bdpToDate.Text & "');"
            strscript += "</script>"
            ClientScript.RegisterStartupScript(Me.GetType(), "newwin", strscript)
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub loadBranches()
        Try
            cmd = New SqlCommand("select * from BNCH_DETAILS", con)
            Dim ds As New DataSet
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "bnch")
            If ds.Tables(0).Rows.Count > 0 Then
                cmbBranch.DataSource = ds.Tables(0)
                cmbBranch.DataTextField = "BNCH_NAME"
                cmbBranch.DataValueField = "BNCH_CODE"
            Else
                cmbBranch.DataSource = Nothing
            End If
            cmbBranch.DataBind()
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Page.MaintainScrollPositionOnPostBack = True
            con = New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
            If Not IsPostBack Then
                loadBranches()
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class