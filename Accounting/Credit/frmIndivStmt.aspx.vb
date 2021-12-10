Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient

Partial Class Credit_frmIndivStmt
    Inherits System.Web.UI.Page
    Shared adp As New SqlDataAdapter
    Shared cmd As SqlCommand
    Shared con As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
    Protected Sub btnPrint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Dim strscript As String

        strscript = "<script langauage=JavaScript>"
        strscript += "window.open('rptIndivStmt.aspx?id=" & txtLoanID.Text & "');"
        strscript += "</script>"
        ClientScript.RegisterStartupScript(Me.GetType(), "newwin", strscript)
    End Sub

    Protected Sub btnSearchLoanID_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearchLoanID.Click
        Try
            If Trim(Session("SessionID")) = "" Or IsDBNull(Session("SessionID")) Then
                Response.Redirect("~/logout.aspx")
            Else
                btnPrint_Click(sender, New EventArgs)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Protected Sub btnSearchName_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearchName.Click
        Try
            cmd = New SqlCommand("select ID,SURNAME+' '+FORENAMES+' '+convert(varchar,CUSTOMER_NUMBER)+' '+convert(varchar,FIN_AMT) as DISPLAY from QUEST_APPLICATION where SURNAME like '" & txtSearchName.Text & "%'", con)
            Dim ds As New DataSet
            Dim adp As New SqlDataAdapter
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "LOANS")
            If ds.Tables(0).Rows.Count > 0 Then
                lstLoans.DataSource = ds.Tables(0)
                lstLoans.DataTextField = "DISPLAY"
                lstLoans.DataValueField = "ID"
                lstLoans.Visible = True
            Else
                lstLoans.DataSource = Nothing
                lstLoans.Visible = False
                'msgbox("Search name not found")
                ClientScript.RegisterStartupScript(Me.GetType(), "Gritter", "<script type=""text/javascript"">$.gritter.add({title: 'Name not found!',text: 'There is no record which matches the entered name.',image: 'images/error_button.png'});</script>")
                txtLoanID.Text = ""
            End If
            lstLoans.DataBind()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Protected Sub lstLoans_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstLoans.SelectedIndexChanged
        Try
            Dim loanID = lstLoans.SelectedValue
            txtLoanID.Text = loanID
            btnSearchLoanID_Click(sender, New EventArgs)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class