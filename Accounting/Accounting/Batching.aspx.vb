Imports System.Data
Imports System.Data.SqlClient
Imports CreditManager
Imports ErrorLogging

Partial Class Accounting_Batching
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

    Protected Sub btnSaveTrxn3_Click(sender As Object, e As EventArgs) Handles btnSaveTrxn3.Click
        If cmbBatchType.SelectedValue = "" Then
            CreditManager.notify("Enter the batch type", "error")
            cmbBatchType.Focus()
            Exit Sub
        ElseIf Trim(txtBatchDate.Text) = "" Or Not IsDate(txtBatchDate.Text) Then
            CreditManager.notify("Enter valid batch date", "error")
            txtBatchDate.Focus()
            Exit Sub
        End If
        Dim acc As String
        If chkSingle.Checked = True Then
            acc = cmbAccount.Text
        Else
            acc = ""
        End If
        Try
            getBatchNo()
            Using cmd = New SqlCommand("SaveBatchReciepts", con)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("@BatchNo", txtBatchNo.Text)
                cmd.Parameters.AddWithValue("@BatchType", cmbBatchType.SelectedItem.Text)
                cmd.Parameters.AddWithValue("@Amount", txtAmount.Text)
                cmd.Parameters.AddWithValue("@NoTrxns", txtTrxns.Text)
                cmd.Parameters.AddWithValue("@CreatedBy", Session("UserID").ToString)
                cmd.Parameters.AddWithValue("@CreatedOn", txtBatchDate.Text)
                cmd.Parameters.AddWithValue("@BatchName", txtBatchName.Text)
                cmd.Parameters.AddWithValue("@SingleAcc", IIf(chkSingle.Checked = True, 1, 0))
                cmd.Parameters.AddWithValue("@account", acc)

                If con.State = ConnectionState.Open Then
                    con.Close()
                End If
                con.Open()
                If cmd.ExecuteNonQuery() Then
                    msgbox("Batch Created with batch number " & txtBatchNo.Text)
                    getUncommittedBatches()
                    ClearFeilds()
                    CheckBox1_CheckedChanged(Me, e)
                Else
                    msgbox("Error Saving Details")
                End If
                con.Close()
            End Using
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Page.MaintainScrollPositionOnPostBack = True
        con = New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)

        If Not IsPostBack Then
            getUncommittedBatches()
        End If
    End Sub

    Protected Sub cmbBatchType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbBatchType.SelectedIndexChanged

    End Sub

    Protected Sub getBatchNo()
        Try
            cmd = New SqlCommand("select isnull(max(id+1),1) as 'BatchID' from tbl_BatchRec", con)
            Dim ds As New DataSet
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "BatchRec")
            If ds.Tables(0).Rows.Count > 0 Then
                txtBatchNo.Text = cmbBatchType.Text.Substring(0, 3).ToString & "" & CInt(ds.Tables(0).Rows(0).Item("BatchID")).ToString()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Public Sub ClearFeilds()
        txtAmount.Text = ""
        txtBatchNo.Text = ""
        txtTrxns.Text = ""
        cmbBatchType.SelectedIndex = -1
        chkSingle.Checked = False
        txtBatchName.Text = ""
        txtBatchDate.Text = ""
        cmbAccount.SelectedIndex = cmbAccount.Items.Count - 1
    End Sub

    Protected Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles chkSingle.CheckedChanged
        If chkSingle.Checked = True Then
            lblAccount.Visible = True
            cmbAccount.Visible = True
            loadFinAccs()
        Else
            lblAccount.Visible = False
            cmbAccount.Visible = False
            cmbAccount.DataSource = Nothing
            cmbAccount.DataBind()
        End If
    End Sub

    Protected Sub loadFinAccs()
        Try
            cmd = New SqlCommand("select * from tbl_FinancialAccountsCreation", con)
            Dim ds As New DataSet
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "AccountsTypes")
            If ds.Tables(0).Rows.Count > 0 Then
                cmbAccount.DataSource = ds
                cmbAccount.DataValueField = "AccountName"
                cmbAccount.DataBind()
                cmbAccount.Items.Add("-Select-")
                cmbAccount.SelectedIndex = cmbAccount.Items.Count - 1
            Else
                cmbAccount.DataSource = Nothing
                cmbAccount.DataBind()
            End If

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub getUncommittedBatches()
        Try
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd As New SqlCommand("select *,convert(varchar,BatchDate,106) as BatchDate1,convert(varchar,DateCreated,113) as DateCreated1 from tbl_BatchRec where status is null or status=0", con)
                    Dim dt As New DataTable
                    Using adp As New SqlDataAdapter(cmd)
                        adp.Fill(dt)
                    End Using
                    CreditManager.bindGrid(dt, grdDetails)
                End Using
            End Using
        Catch ex As Exception
            ErrorLogging.WriteLogFile(Session("UserId"), Request.Url.ToString & " --- getUncommittedBatches()", ex.ToString)
        End Try
    End Sub

    Private Sub grdDetails_RowCancelingEdit(sender As Object, e As GridViewCancelEditEventArgs) Handles grdDetails.RowCancelingEdit
        grdDetails.EditIndex = -1
        getUncommittedBatches()
    End Sub

    Private Sub grdDetails_RowEditing(sender As Object, e As GridViewEditEventArgs) Handles grdDetails.RowEditing
        ViewState("batchEditID") = DirectCast(grdDetails.Rows(e.NewEditIndex).FindControl("txtBatchId"), TextBox).Text
        grdDetails.EditIndex = e.NewEditIndex
        getUncommittedBatches()
    End Sub

    Private Sub grdDetails_RowDeleting(sender As Object, e As GridViewDeleteEventArgs) Handles grdDetails.RowDeleting
        ViewState("batchEditID") = DirectCast(grdDetails.Rows(e.RowIndex).FindControl("txtBatchId"), TextBox).Text
        cmd = New SqlCommand("delete from [tbl_BatchRec] where ID='" & ViewState("batchEditID") & "'", con)
        If con.State = ConnectionState.Open Then
            con.Close()
        End If
        con.Open()
        If cmd.ExecuteNonQuery Then
            notify("Batch successfully deleted", "success")
        Else
            notify("Error deleting batch", "error")
        End If
        con.Close()
        getUncommittedBatches()
    End Sub

    Private Sub grdDetails_RowUpdating(sender As Object, e As GridViewUpdateEventArgs) Handles grdDetails.RowUpdating
        If Trim(ViewState("batchEditID")) = "" Or IsDBNull(ViewState("batchEditID")) Then
            notify("No batch selected for update", "error")
            Exit Sub
        End If
        Dim des As String = DirectCast(grdDetails.Rows(e.RowIndex).FindControl("txtBatchNameEdit"), TextBox).Text
        Dim bDat As String = DirectCast(grdDetails.Rows(e.RowIndex).FindControl("txtBatchDateEdit"), TextBox).Text
        Dim val As String = DirectCast(grdDetails.Rows(e.RowIndex).FindControl("txtAmountEdit"), TextBox).Text
        Dim noTrxn As String = DirectCast(grdDetails.Rows(e.RowIndex).FindControl("txtNumberOfTrxnsEdit"), TextBox).Text
        cmd = New SqlCommand("update [tbl_BatchRec] set [BatchName]='" & BankString.removeSpecialCharacter(des) & "',[BatchDate]='" & bDat & "',[Amount]='" & val & "',[NumberOfTrxns]='" & noTrxn & "' where ID='" & ViewState("batchEditID") & "'", con)
        If con.State = ConnectionState.Open Then
            con.Close()
        End If
        con.Open()
        If cmd.ExecuteNonQuery Then
            notify("Collateral successfully updated", "success")
        Else
            notify("Error updating collateral", "error")
        End If
        con.Close()
        grdDetails.EditIndex = -1
        getUncommittedBatches()
    End Sub
End Class