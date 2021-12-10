Imports System.Data
Imports System.Data.SqlClient

Partial Class Credit_popApplicationApproval
    Inherits System.Web.UI.Page
    Dim adp As SqlDataAdapter
    Dim cmd As SqlCommand
    Dim con As New SqlConnection
    Dim connection As String

    Public Sub msgbox(ByVal strMessage As String)

        'finishes server processing, returns to client.
        Dim strScript As String = "<script language=JavaScript>"
        strScript += "window.alert(""" & strMessage & """);"
        strScript += "</script>"
        Dim lbl As New System.Web.UI.WebControls.Label
        lbl.Text = strScript
        Page.Controls.Add(lbl)
    End Sub

    Protected Sub btnApprove_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnApprove.Click
        Try

        Catch ex As Exception

        End Try
    End Sub

    Protected Sub loadDetails(ByVal loanID As String)
        Try
            cmd = New SqlCommand("select * from QUEST_APPLICATION where ID='" & loanID & "'", con)
            Dim ds As New DataSet
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "apps")
            If ds.Tables(0).Rows.Count > 0 Then
                lblAmount.Text = ds.Tables(0).Rows(0).Item("FIN_AMT")
                lblAppName.Text = ds.Tables(0).Rows(0).Item("SURNAME") & "" & ds.Tables(0).Rows(0).Item("FORENAMES")
                lblAppDate.Text = ds.Tables(0).Rows(0).Item("CREATED_DATE")
                lblAppNo.Text = loanID
            End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Page.MaintainScrollPositionOnPostBack = True
            con = New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
            If Not IsPostBack Then
                loadDetails(Request.QueryString("ID"))
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class