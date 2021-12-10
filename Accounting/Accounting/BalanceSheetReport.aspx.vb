Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Partial Class Accounting_BalanceSheet
    Inherits System.Web.UI.Page
    Dim cmd As SqlCommand
    Dim con As New SqlConnection
    Dim adp As New SqlDataAdapter
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

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Page.MaintainScrollPositionOnPostBack = True
        con = New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
        If Not IsPostBack Then

            '   lblAccount.Text = Session("Account").ToString & " Account"
            lblDateFrom.Text = Session("DateFrom").ToString
            lblDateTo.Text = Session("DateTo").ToString
            Try
                cmd = New SqlCommand("SP_BalanceSheet", con)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("@DATEFROM", Session("DateFrom").ToString)
                cmd.Parameters.AddWithValue("@DATETO", Session("DateTo").ToString)
                Dim ds As New DataSet
                adp = New SqlDataAdapter(cmd)
                adp.Fill(ds, "BL")
                If ds.Tables(0).Rows.Count > 0 Then
                    grdIncome0.DataSource = ds.Tables(1)
                    grdIncome0.DataBind()

                    grdIncome1.DataSource = ds.Tables(0)
                    grdIncome1.DataBind()
                End If
              
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        End If
    End Sub
End Class
