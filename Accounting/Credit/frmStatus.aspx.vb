Imports System.Data
Imports System.Data.SqlClient

Partial Class Credit_frmStatus
    Inherits System.Web.UI.Page
    Dim adp As SqlDataAdapter
    Dim cmd As SqlCommand
    Dim con As New SqlConnection
    Dim connection As String

    Protected Sub btnPrint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Try
            Dim strscript As String

            strscript = "<script langauage=JavaScript>"
            strscript += "window.open('rptStatusReport.aspx?brnch=" & cmbBranch.SelectedValue & "&from=" & bdpFromDate.Text & "&to=" & bdpToDate.Text & "&status=" & cmbStatus.SelectedValue & "');"
            strscript += "</script>"
            ClientScript.RegisterStartupScript(Me.GetType(), "newwin", strscript)
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub loadBranches()
        Try
            cmbBranch.Items.Clear()
            cmbBranch.Items.Add("")
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

    Protected Sub loadStatus()
        Try
            cmbStatus.Items.Clear()
            cmbStatus.Items.Add("")
            cmd = New SqlCommand("select distinct STATUS from QUEST_APPLICATION", con)
            Dim ds As New DataSet
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "bnch")
            If ds.Tables(0).Rows.Count > 0 Then
                cmbStatus.DataSource = ds.Tables(0)
                cmbStatus.DataTextField = "STATUS"
                cmbStatus.DataValueField = "STATUS"
            Else
                cmbStatus.DataSource = Nothing
            End If
            cmbStatus.DataBind()
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Page.MaintainScrollPositionOnPostBack = True
            con = New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
            If Not IsPostBack Then
                loadStatus()
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class