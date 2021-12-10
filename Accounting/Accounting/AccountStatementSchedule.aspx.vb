Imports System
Imports System.Data
Imports System.Data.SqlClient

Partial Class Accounting_AccountStatementSchedule
    Inherits System.Web.UI.Page
    Dim con As New SqlConnection

    Public Sub msgbox(ByVal strMessage As String)

        'finishes server processing, returns to client.
        Dim strScript As String = "<script language=JavaScript>"
        strScript += "window.alert(""" & strMessage & """);"
        strScript += "</script>"
        Dim lbl As New System.Web.UI.WebControls.Label
        lbl.Text = strScript
        Page.Controls.Add(lbl)

    End Sub
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Page.MaintainScrollPositionOnPostBack = True
        con = New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
        If Not IsPostBack Then
            getBatches()
        End If
    End Sub

    Protected Sub getBatches()
        Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
            Using cmd As New SqlCommand("select [AccountName] + ' - ' + convert(varchar,[MainAccount]) as Account,[MainAccount] from [tbl_FinancialAccountsCreation] where subaccount=0 or SubAccount=1", con)
                Dim ds As New DataSet
                Dim adp As New SqlDataAdapter(cmd)
                adp.Fill(ds, "rr")
                If ds.Tables(0).Rows.Count > 0 Then
                    CreditManager.loadCombo(ds.Tables(0), cmbBatchRef, "Account", "MainAccount")
                End If
            End Using
        End Using
    End Sub

    Protected Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        Try
            Dim strscript As String
            strscript = "<script langauage=JavaScript>"
            strscript += "window.open('rptAccStmtSchedule.aspx?ref=" & cmbBatchRef.SelectedValue & "')"
            strscript += "</script>"
            ClientScript.RegisterStartupScript(Me.GetType(), "newwin", strscript)
        Catch ex As Exception

        End Try
    End Sub
End Class