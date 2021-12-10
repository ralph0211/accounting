Imports System.Data
Imports System.Data.SqlClient
Imports CreditManager
Imports ErrorLogging

Partial Class Credit_ParaPurpose
    Inherits System.Web.UI.Page
    Public Shared typeEditID As Double
    Dim adp As New SqlDataAdapter
    Dim cmd As SqlCommand
    Dim con As New SqlConnection
    Dim connection As String
    Dim urlPermission As String = "PermissionDenied.aspx"

    Protected Sub btnAddPurpose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddPurpose.Click
        Try
            cmd = New SqlCommand("select * from PARA_PURPOSE where PURPOSE='" & txtPurpose.Text & "'", con)
            Dim ds As New DataSet
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "PRODUCTS")
            If ds.Tables(0).Rows.Count > 0 Then
                'cmd = New SqlCommand("update PARA_PURPOSE set PURPOSE='" & BankString.removeSpecialCharacter(Trim(txtPurpose.Text)) & "', LOAN_MODIFIED_BY='" & Session("UserID") & "', LOAN_MODIFIED_DATE=getdate() where LOAN_SHORT_DESC='" & Trim(txtShortName.Text) & "'", con)
            Else
                cmd = New SqlCommand("insert into PARA_PURPOSE ([PURPOSE]) values ('" & BankString.removeSpecialCharacter(Trim(txtPurpose.Text)) & "')", con)
            End If
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
            notify("Loan purpose saved", "success")
            clearAll()
            getCreditPurpose(cmbClientType.SelectedValue)
        Catch ex As Exception
            WriteLogFile(Session("UserId"), "Credit/ParaPurpose - btnAddPurpose_Click()", ex.Message)
        End Try
    End Sub

    Protected Sub clearAll()
        Try
            txtPurpose.Text = ""
        Catch ex As Exception
            WriteLogFile(Session("UserId"), "Credit/ParaPurpose - clearAll()", ex.Message)
        End Try
    End Sub
    Protected Sub cmbClientType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbClientType.SelectedIndexChanged
        getCreditPurpose(cmbClientType.SelectedValue)
    End Sub

    Protected Sub getCreditPurpose(cliType As String)
        Try
            If Trim(cliType) <> "" Then
                Using cmd = New SqlCommand("select pp.ID,pct.CLIENT_TYPE as [Client Type],pp.Purpose from PARA_PURPOSE pp join PARA_CLIENT_TYPES pct on pp.ClientType=pct.ID where ClientType='" & cliType & "'", con)
                    Dim ds As New DataSet
                    Using adp = New SqlDataAdapter(cmd)
                        adp.Fill(ds, "Purposes")
                    End Using
                    If ds.Tables(0).Rows.Count > 0 Then
                        grdPurpose.DataSource = ds.Tables(0)
                    Else
                        grdPurpose.DataSource = Nothing
                    End If
                    grdPurpose.DataBind()
                End Using
            End If
        Catch ex As Exception
            WriteLogFile(Session("UserId"), "Credit/ParaPurpose - getCreditPurpose(" & cliType & ")", ex.Message)
        End Try
    End Sub

    Protected Sub grdPurpose_RowCancelingEdit(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles grdPurpose.RowCancelingEdit
        grdPurpose.EditIndex = -1
        getCreditPurpose(cmbClientType.SelectedValue)
    End Sub

    Protected Sub grdPurpose_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles grdPurpose.RowDeleting
        typeEditID = DirectCast(grdPurpose.Rows(e.RowIndex).FindControl("txtGrdPurposeID"), TextBox).Text
        cmd = New SqlCommand("delete from PARA_PURPOSE where ID='" & typeEditID & "'", con)
        If con.State = ConnectionState.Open Then
            con.Close()
        End If
        con.Open()
        If cmd.ExecuteNonQuery Then
            notify("Successfully deleted", "success")
        Else
            notify("Error deleting", "error")
        End If
        con.Close()
        getCreditPurpose(cmbClientType.SelectedValue)
    End Sub

    Protected Sub grdPurpose_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles grdPurpose.RowEditing
        typeEditID = DirectCast(grdPurpose.Rows(e.NewEditIndex).FindControl("txtGrdPurposeID"), TextBox).Text
        grdPurpose.EditIndex = e.NewEditIndex
        getCreditPurpose(cmbClientType.SelectedValue)
    End Sub

    Protected Sub grdPurpose_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles grdPurpose.RowUpdating
        If Trim(typeEditID) = "" Or IsDBNull(typeEditID) Then
            notify("No record selected for update", "error")
            Exit Sub
        End If

        Dim purpose As String = DirectCast(grdPurpose.Rows(e.RowIndex).FindControl("txtGrdPurpose"), TextBox).Text
        'Dim newLongName As String = DirectCast(grdProductTypes.Rows(e.RowIndex).FindControl("txtGrdLongNameEdit"), TextBox).Text
        cmd = New SqlCommand("update PARA_PURPOSE set PURPOSE='" & BankString.removeSpecialCharacter(purpose) & "' where ID='" & typeEditID & "'", con)

        If con.State = ConnectionState.Open Then
            con.Close()
        End If
        con.Open()
        If cmd.ExecuteNonQuery Then
            notify("Successfully updated", "success")
        Else
            notify("Error updating value", "error")
        End If
        con.Close()
        grdPurpose.EditIndex = -1
        getCreditPurpose(cmbClientType.SelectedValue)
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Page.MaintainScrollPositionOnPostBack = True
            con = New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
            If Not IsPostBack Then
                loadClientType(cmbClientType)
                getCreditPurpose(cmbClientType.SelectedValue)
            End If
        Catch ex As Exception
            WriteLogFile(Session("UserId"), "Credit/ParaPurpose - Page_Load()", ex.Message)
        End Try
    End Sub
End Class