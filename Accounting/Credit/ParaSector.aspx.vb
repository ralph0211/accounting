Imports System.Data
Imports System.Data.SqlClient
Imports CreditManager
Imports ErrorLogging

Partial Class Credit_ParaSector
    Inherits System.Web.UI.Page
    Public Shared typeEditID As Double
    Const urlPermission As String = "PermissionDenied.aspx"
    Dim adp As New SqlDataAdapter
    Dim cmd As SqlCommand
    Dim con As New SqlConnection
    Dim connection As String

    Protected Sub btnAddPurpose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddPurpose.Click
        Try
            cmd = New SqlCommand(String.Format("select * from PARA_SECTOR where SECTOR='{0}'", txtPurpose.Text), con)
            Dim ds As New DataSet
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "PRODUCTS")
            If ds.Tables(0).Rows.Count > 0 Then
                'cmd = New SqlCommand("update PARA_PURPOSE set PURPOSE='" & BankString.removeSpecialCharacter(Trim(txtPurpose.Text)) & "', LOAN_MODIFIED_BY='" & Session("UserID") & "', LOAN_MODIFIED_DATE=getdate() where LOAN_SHORT_DESC='" & Trim(txtShortName.Text) & "'", con)
            Else
                cmd = New SqlCommand(String.Format("insert into PARA_SECTOR ([SECTOR]) values ('{0}')", BankString.removeSpecialCharacter(Trim(txtPurpose.Text))), con)
            End If
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
            notify("New purpose entered", "success")
            clearAll()
            getSectors()
        Catch ex As Exception
            WriteLogFile(Session("UserId"), "Credit/ParaSector - btnAddPurpose_Click()", ex.Message)
        End Try
    End Sub

    Protected Sub clearAll()
        Try
            txtPurpose.Text = ""
        Catch ex As Exception
            WriteLogFile(Session("UserId"), "Credit/ParaSector - clearAll()", ex.Message)
        End Try
    End Sub
    Protected Sub getSectors()
        Try
            cmd = New SqlCommand("select * from PARA_SECTOR", con)
            Dim ds As New DataSet
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "Purposes")
            bindGrid(ds.Tables(0), grdPurpose)
        Catch ex As Exception
            WriteLogFile(Session("UserId"), "Credit/ParaSector - getSectors()", ex.Message)
        End Try
    End Sub

    Protected Sub grdPurpose_RowCancelingEdit(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles grdPurpose.RowCancelingEdit
        grdPurpose.EditIndex = -1
        getSectors()
    End Sub

    Protected Sub grdPurpose_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles grdPurpose.RowDeleting
        typeEditID = DirectCast(grdPurpose.Rows(e.RowIndex).FindControl("txtGrdPurposeID"), TextBox).Text
        cmd = New SqlCommand(String.Format("delete from PARA_SECTOR where ID='{0}'", typeEditID), con)
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
        getSectors()
    End Sub

    Protected Sub grdPurpose_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles grdPurpose.RowEditing
        typeEditID = DirectCast(grdPurpose.Rows(e.NewEditIndex).FindControl("txtGrdPurposeID"), TextBox).Text
        grdPurpose.EditIndex = e.NewEditIndex
        getSectors()
    End Sub

    Protected Sub grdPurpose_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles grdPurpose.RowUpdating
        If Trim(typeEditID) = "" Or IsDBNull(typeEditID) Then
            notify("No record selected for update", "error")
            Exit Sub
        End If

        Dim purpose As String = DirectCast(grdPurpose.Rows(e.RowIndex).FindControl("txtGrdPurpose"), TextBox).Text
        'Dim newLongName As String = DirectCast(grdProductTypes.Rows(e.RowIndex).FindControl("txtGrdLongNameEdit"), TextBox).Text
        cmd = New SqlCommand(String.Format("update PARA_SECTOR set SECTOR='{0}' where ID='{1}'", BankString.removeSpecialCharacter(purpose), typeEditID), con)

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
        getSectors()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Page.MaintainScrollPositionOnPostBack = True
            con = New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
            If Not IsPostBack Then
                getSectors()
            End If
        Catch ex As Exception
            WriteLogFile(Session("UserId"), "Credit/ParaSector - Page_Load()", ex.Message)
        End Try
    End Sub
End Class