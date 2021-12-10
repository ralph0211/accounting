Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Partial Class Accounting_AssetRegister
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
    Protected Sub btnSaveTrxn_Click(sender As Object, e As EventArgs) Handles btnSaveTrxn.Click
        Try
            If Checkfeilds("save") = True Then
                cmd = New SqlCommand("SaveAssetDetails", con)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("@ID", txtID.Text)
                cmd.Parameters.AddWithValue("@name", txtName.Text)
                cmd.Parameters.AddWithValue("@category", cmbCategory.Text)
                cmd.Parameters.AddWithValue("@initvalue", txtInitValue.Text)
                cmd.Parameters.AddWithValue("@currvalue", txtCurrVal.Text)
                cmd.Parameters.AddWithValue("@dateacquired", dtpTrxnDate.Text)
                cmd.Parameters.AddWithValue("@Description", txtdesc.Text)
                cmd.Parameters.AddWithValue("@user", Session("UserID").ToString)
                cmd.Parameters.AddWithValue("@strtype", "Save")

                If con.State = ConnectionState.Open Then
                    con.Close()
                End If
                con.Open()
                If cmd.ExecuteNonQuery() Then
                    msgbox("Asset Details Saved")
                    loadGrid()
                    ClearFeilds()
                Else
                    msgbox("Error Saving Account")
                End If

            End If
            con.Close()
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            Page.MaintainScrollPositionOnPostBack = True
            con = New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
            If Not IsPostBack Then
                loadGrid()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub loadGrid()
        Try
            cmd = New SqlCommand("select [AssetID]  ,[Name] ,[Category] ,[InitialValue]  ,[CurrentValue] ,[DateAcquire]  ,[Description] ,[CreatedBy] ,[UpdatedBy]  ,[UpdateDate] from tbl_AssetRegister ", con)
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
            msgbox(ex.Message)
        End Try
    End Sub

    Public Function Checkfeilds(ByVal str As String) As Boolean
        Checkfeilds = False
        Try
            If txtName.Text = "" Then
                msgbox("Account Name Is Mandatory")
                txtName.Focus()
                Exit Function
            End If
            If txtCurrVal.Text = "" Or Not IsNumeric(txtCurrVal.Text) Then
                msgbox("Main Account Is Mandatory")
                txtCurrVal.Focus()
                Exit Function
            End If
            If txtInitValue.Text = "" Or Not IsNumeric(txtInitValue.Text) Then
                msgbox("Sub Account Is Mandatory")
                txtInitValue.Focus()
                Exit Function
            End If
            If cmbCategory.SelectedIndex = 0 Then
                msgbox("Please Select a Valid Default")
                cmbCategory.Focus()
                Exit Function
            End If
            If str = "save" Then
                cmd = New SqlCommand("select * from tbl_AssetRegister where AssetID='" & txtID.Text & "'", con)
                Dim ds As New DataSet
                adp = New SqlDataAdapter(cmd)
                adp.Fill(ds, "Assets")
                If ds.Tables(0).Rows.Count > 0 Then
                    msgbox("Asset ID Must be Unique")
                    txtID.Focus()
                    Exit Function
                End If
            End If
            Checkfeilds = True
        Catch ex As Exception

        End Try
    End Function

    Public Sub ClearFeilds()
        txtID.Enabled = True
        txtCurrVal.Text = ""
        txtdesc.Text = ""
        txtID.Text = ""
        txtInitValue.Text = ""
        txtName.Text = ""
        cmbCategory.SelectedIndex = -1
        dtpTrxnDate.Text = ""

    End Sub

    Protected Sub grdDetails_SelectedIndexChanged(sender As Object, e As EventArgs) Handles grdDetails.SelectedIndexChanged
        Try

            txtID.Text = grdDetails.SelectedRow.Cells(1).Text
            txtName.Text = grdDetails.SelectedRow.Cells(2).Text
            cmbCategory.SelectedValue = grdDetails.SelectedRow.Cells(3).Text
            txtInitValue.Text = grdDetails.SelectedRow.Cells(4).Text
            txtCurrVal.Text = grdDetails.SelectedRow.Cells(5).Text
            txtdesc.Text = grdDetails.SelectedRow.Cells(7).Text
            dtpTrxnDate.Text = grdDetails.SelectedRow.Cells(6).Text
            txtID.Enabled = False
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnSaveTrxn0_Click(sender As Object, e As EventArgs) Handles btnSaveTrxn0.Click
        Try
            If Checkfeilds("Update") = True Then
                cmd = New SqlCommand("SaveAssetDetails", con)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("@ID", txtID.Text)
                cmd.Parameters.AddWithValue("@name", txtName.Text)
                cmd.Parameters.AddWithValue("@category", cmbCategory.Text)
                cmd.Parameters.AddWithValue("@initvalue", txtInitValue.Text)
                cmd.Parameters.AddWithValue("@currvalue", txtCurrVal.Text)
                cmd.Parameters.AddWithValue("@dateacquired", dtpTrxnDate.Text)
                cmd.Parameters.AddWithValue("@Description", txtdesc.Text)
                cmd.Parameters.AddWithValue("@user", Session("UserID").ToString)
                cmd.Parameters.AddWithValue("@strtype", "Update")

                If con.State = ConnectionState.Open Then
                    con.Close()
                End If
                con.Open()
                If cmd.ExecuteNonQuery() Then
                    msgbox("Asset Details Saved")
                    loadGrid()
                    ClearFeilds()
                Else
                    msgbox("Error Saving Account")
                End If

            End If
            con.Close()
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub btnSaveTrxn2_Click(sender As Object, e As EventArgs) Handles btnSaveTrxn2.Click
        ClearFeilds()
    End Sub
End Class