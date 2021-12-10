Imports System.Data
Imports System.Data.SqlClient
Partial Class Accounting_TaxProcessing
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
            loadGrid()
        End If
    End Sub


    Protected Sub loadGrid()
        Try
            cmd = New SqlCommand("select * from tbl_TaxProc ", con)
            Dim ds As New DataSet
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "Tax")
            If ds.Tables(0).Rows.Count > 0 Then
                grdDetails.DataSource = ds.Tables(0)
                grdDetails.DataBind()
            Else
                grdDetails.DataSource = Nothing
                grdDetails.DataBind()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Protected Sub btnSaveTrxn3_Click(sender As Object, e As EventArgs) Handles btnSaveTrxn3.Click
        Try
            cmd = New SqlCommand("SaveTaxProc", con)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@Name", txtName.Text)
            cmd.Parameters.AddWithValue("@Desc", txtdesc.Text)
            cmd.Parameters.AddWithValue("@Amount", Val(txtAmount.Text))
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            con.Open()
            If cmd.ExecuteNonQuery() Then
                MsgBox("Tax Type Created")
                txtAmount.Text = ""
                txtdesc.Text = ""
                txtName.Text = ""
                loadGrid()
            Else
                MsgBox("Error Saving Account")
            End If
            con.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class
