Imports System.Data
Imports System.Data.SqlClient

Partial Class Credit_CommRegister
    Inherits System.Web.UI.Page
    Public Shared commEditID As String
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

    Protected Sub btnAddResponse_Click(sender As Object, e As EventArgs) Handles btnAddResponse.Click
        Try
            cmd = New SqlCommand("insert into comm_register(cust_no,date_comm,officer,response) values ('" & txtCustNo.Text & "','" & txtDate.Text & "','" & txtOfficer.Text & "','" & txtResponse.Text & "')", con)
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            con.Open()
            If cmd.ExecuteNonQuery Then
                msgbox("Communication saved")
                getRegister(txtCustNo.Text)
            Else
                msgbox("Error saving communication")
            End If
            con.Close()
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub btnSearchCustNo_Click(sender As Object, e As EventArgs) Handles btnSearchCustNo.Click
        getCustDetails(txtCustNo.Text)
        getRegister(txtCustNo.Text)
    End Sub

    Protected Sub btnSearchName_Click(sender As Object, e As EventArgs) Handles btnSearchName.Click

    End Sub

    Protected Sub chkAddResponse_CheckedChanged(sender As Object, e As EventArgs) Handles chkAddResponse.CheckedChanged
        If chkAddResponse.Checked = True Then
            CaptureResponse.Visible = True
        Else
            CaptureResponse.Visible = False
        End If
    End Sub

    Protected Sub getCustDetails(custNo As String)
        Try
            cmd = New SqlCommand("select *,convert(varchar(50),REC_DATE,106) as REC_DATE1,[FIN_AMT] from quest_application where CUSTOMER_NUMBER='" & custNo & "'", con)
            adp = New SqlDataAdapter(cmd)
            Dim ds As New DataSet
            adp.Fill(ds, "cr")
            If ds.Tables(0).Rows.Count > 0 Then
                lblAddress.Text = "Address: " & ds.Tables(0).Rows(0).Item("ADDRESS") & " " & ds.Tables(0).Rows(0).Item("CITY")
                lblName.Text = "Name: " & ds.Tables(0).Rows(0).Item("SURNAME") & " " & ds.Tables(0).Rows(0).Item("FORENAMES")
                grdLoans.DataSource = ds.Tables(0)
            Else
                grdLoans.DataSource = Nothing
            End If
            grdLoans.DataBind()
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub getRegister(custNo As String)
        Try
            cmd = New SqlCommand("select * from comm_register where cust_no='" & custNo & "'", con)
            adp = New SqlDataAdapter(cmd)
            Dim ds As New DataSet
            adp.Fill(ds, "cr")
            If ds.Tables(0).Rows.Count > 0 Then
                grdRegister.DataSource = ds.Tables(0)
            Else
                grdRegister.DataSource = Nothing
            End If
            grdRegister.DataBind()
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub grdRegister_RowCancelingEdit(sender As Object, e As GridViewCancelEditEventArgs) Handles grdRegister.RowCancelingEdit
        grdRegister.EditIndex = -1
        getRegister(txtCustNo.Text)
    End Sub

    Protected Sub grdRegister_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles grdRegister.RowDataBound
        If (e.Row.RowType = DataControlRowType.DataRow And grdRegister.EditIndex = e.Row.RowIndex) Then
            'msgbox(DirectCast(e.Row.FindControl("grdUsers_txtUserType"), TextBox).Text)
            Dim txtGrdDate = DirectCast(e.Row.FindControl("txtDateCommEdit"), TextBox)
            'loadEntities(cmbClientTypes)
            'Try
            '    cmbClientTypes.SelectedValue = DirectCast(e.Row.FindControl("lblClientType0Edit"), Label).Text
            'Catch ex As Exception
            '    cmbClientTypes.ClearSelection()
            'End Try
            ClientScript.RegisterStartupScript(Me.GetType, "genDate", "<script language=JavaScript>genDates();</script>")
        End If
    End Sub

    Protected Sub grdRegister_RowDeleting(sender As Object, e As GridViewDeleteEventArgs) Handles grdRegister.RowDeleting

    End Sub

    Protected Sub grdRegister_RowEditing(sender As Object, e As GridViewEditEventArgs) Handles grdRegister.RowEditing
        commEditID = DirectCast(grdRegister.Rows(e.NewEditIndex).FindControl("txtCommId0"), TextBox).Text
        grdRegister.EditIndex = e.NewEditIndex
        getRegister(txtCustNo.Text)
    End Sub

    Protected Sub grdRegister_RowUpdating(sender As Object, e As GridViewUpdateEventArgs) Handles grdRegister.RowUpdating
        If Trim(commEditID) = "" Or IsDBNull(commEditID) Then
            msgbox("No client type selected for update")
            Exit Sub
        End If
        Dim commDate As String = DirectCast(grdRegister.Rows(e.RowIndex).FindControl("txtDateCommEdit"), TextBox).Text
        Dim officer As String = DirectCast(grdRegister.Rows(e.RowIndex).FindControl("txtGrdOfficerEdit"), TextBox).Text
        Dim response As String = DirectCast(grdRegister.Rows(e.RowIndex).FindControl("txtGrdResponseEdit"), TextBox).Text
        cmd = New SqlCommand("update comm_register set date_comm='" & commDate & "',officer='" & officer & "',response='" & response & "' where id='" & commEditID & "'", con)
        If con.State = ConnectionState.Open Then
            con.Close()
        End If
        con.Open()
        If cmd.ExecuteNonQuery Then
            msgbox("Communication successfully updated")
        Else
            msgbox("Error updating communication")
        End If
        con.Close()
        grdRegister.EditIndex = -1
        getRegister(txtCustNo.Text)
    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Page.MaintainScrollPositionOnPostBack = True
        con = New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
        If Not IsPostBack Then
            'chkAddResponse.Checked = True
            'ClientScript.RegisterStartupScript(Me.GetType, "response", "<script language=JavaScript>setTimeout(runEffect(),100);</script>")
            txtOfficer.Text = Session("UserID")
        End If
    End Sub
End Class