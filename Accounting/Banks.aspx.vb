Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.Web

Partial Class Banks
    Inherits System.Web.UI.Page
    Dim cmd As SqlCommand
    Dim con As New SqlConnection
    Dim adp As New SqlDataAdapter
    Dim connection As String
    Dim urlPermission As String = "PermissionDenied.aspx"
    Public Shared branchEditID As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            con = New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
            Page.MaintainScrollPositionOnPostBack = True
            If Not IsPostBack Then
                getBranches()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub clearAll()
        Try
            txtBranchCode.Text = ""
            txtBranchName.Text = ""
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub getBranches()
        Try
            cmd = New SqlCommand("select * from BANK_DETAILS", con)
            Dim ds As New DataSet
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "BANK")
            If ds.Tables(0).Rows.Count > 0 Then
                grdBranches.DataSource = ds.Tables(0)
            Else
                grdBranches.DataSource = Nothing
            End If
            grdBranches.DataBind()
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Public Sub msgbox(ByVal strMessage As String)

        'finishes server processing, returns to client.
        Dim strScript As String = "<script language=JavaScript>"
        strScript += "window.alert(""" & strMessage & """);"
        strScript += "</script>"
        Dim lbl As New System.Web.UI.WebControls.Label
        lbl.Text = strScript
        Page.Controls.Add(lbl)
    End Sub

    Protected Sub btnAddBranch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddBranch.Click
        Try
            Dim cmdIns = New SqlCommand("insert into BANK_DETAILS (BANK_CODE,BANK_NAME) values ('" & txtBranchCode.Text & "','" & BankString.removeSpecialCharacter(txtBranchName.Text) & "')", con)
            'msgbox(cmd.CommandText)
            'Dim cmdAudit As SqlCommand
            'cmdAudit = New SqlCommand("insert into TEMP_BNCH_DETAILS ([ACTION],[PERFORMED_BY],[PERFORMED_DATE],[BNCH_CODE],[BNCH_NAME],[BNCH_ADDRESS],[BNCH_PHONENO],[BNCH_FAXNO]) values ('INSERT','" & Session("UserID") & "',getDate(),'" & txtBranchCode.Text & "','" & BankString.removeSpecialCharacter(txtBranchName.Text) & "','" & BankString.removeSpecialCharacter(txtBranchAddress.Text) & "','" & txtPhoneNumber.Text & "','')", con)
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            con.Open()
            If isUniqueCode(txtBranchCode.Text) Then
                If cmdIns.ExecuteNonQuery Then
                    'cmdAudit.ExecuteNonQuery()
                    msgbox("Bank successfully saved")
                    clearAll()
                    getBranches()
                Else
                    msgbox("Error saving bank")
                End If
            Else
                msgbox("A bank with this code already exists")
                txtBranchCode.Focus()
            End If
            con.Close()
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub grdBranches_RowCancelingEdit(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles grdBranches.RowCancelingEdit
        grdBranches.EditIndex = -1
        getBranches()
    End Sub

    Protected Sub grdBranches_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles grdBranches.RowDeleting
        Try
            branchEditID = DirectCast(grdBranches.Rows(e.RowIndex).FindControl("txtOldBranchCode"), TextBox).Text
            'cmd = New SqlCommand("update BNCH_DETAILS set active=0 where BNCH_CODE='" & branchEditID & "'", con)
            'Dim cmdSelect = New SqlCommand("select * from BANK_DETAILS where BANK_CODE='" & branchEditID & "'", con)
            'Dim dsSelect As New DataSet
            'Dim adpSel = New SqlDataAdapter(cmd)
            'adpSel.Fill(dsSelect, "BRANCH")

            'Dim cmdAudit As SqlCommand
            'cmdAudit = New SqlCommand("insert into TEMP_BNCH_DETAILS ([ACTION],[PERFORMED_BY],[PERFORMED_DATE],[BNCH_CODE],[BNCH_NAME],[BNCH_ADDRESS],[BNCH_PHONENO],[BNCH_FAXNO]) values ('DELETE','" & Session("UserID") & "',getDate(),'" & dsSelect.Tables(0).Rows(0).Item("BNCH_CODE") & "','" & BankString.removeSpecialCharacter(dsSelect.Tables(0).Rows(0).Item("BNCH_NAME")) & "','" & BankString.removeSpecialCharacter(dsSelect.Tables(0).Rows(0).Item("BNCH_ADDRESS")) & "','" & dsSelect.Tables(0).Rows(0).Item("BNCH_PHONENO") & "','')", con)
            cmd = New SqlCommand("delete from BANK_DETAILS where BANK_CODE='" & branchEditID & "'", con)
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            con.Open()
            If cmd.ExecuteNonQuery Then
                'cmdAudit.ExecuteNonQuery()
                msgbox("Successfully deleted")
            Else
                msgbox("Error deleting")
            End If
            con.Close()
            getBranches()

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub grdBranches_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles grdBranches.RowEditing
        Try
            branchEditID = DirectCast(grdBranches.Rows(e.NewEditIndex).FindControl("txtOldBranchCode"), TextBox).Text
            grdBranches.EditIndex = e.NewEditIndex
            getBranches()

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub grdBranches_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles grdBranches.RowUpdating
        Try
            If Trim(branchEditID) = "" Or IsDBNull(branchEditID) Then
                msgbox("No record selected for update")
                Exit Sub
            End If
            Dim bnchCode As String = DirectCast(grdBranches.Rows(e.RowIndex).FindControl("txtGrdBranchCode"), TextBox).Text

            Dim bnchName As String = DirectCast(grdBranches.Rows(e.RowIndex).FindControl("txtBranchNameEdit"), TextBox).Text
            'Dim bnchAddress As String = DirectCast(grdBranches.Rows(e.RowIndex).FindControl("txtGrdBranchAddressEdit"), TextBox).Text

            'Dim bnchPhone As String = DirectCast(grdBranches.Rows(e.RowIndex).FindControl("txtBranchPhoneEdit"), TextBox).Text

            Dim oldBnchCode, oldBnchName, oldBnchAddress, oldBnchPhone, oldBnchFax As String
            oldBnchCode = ""
            oldBnchName = ""
            oldBnchAddress = ""
            oldBnchPhone = ""
            oldBnchFax = ""

            cmd = New SqlCommand("select * from BANK_DETAILS where BANK_CODE='" & branchEditID & "'", con)
            Dim ds1 As New DataSet
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds1, "DETAILS")
            If ds1.Tables(0).Rows.Count > 0 Then
                oldBnchCode = ds1.Tables(0).Rows(0).Item("BANK_CODE").ToString
                oldBnchName = ds1.Tables(0).Rows(0).Item("BANK_NAME").ToString
                'oldBnchAddress = ds1.Tables(0).Rows(0).Item("BNCH_ADDRESS").ToString
                'oldBnchPhone = ds1.Tables(0).Rows(0).Item("BNCH_PHONENO").ToString
                'oldBnchFax = ds1.Tables(0).Rows(0).Item("BNCH_FAXNO").ToString
            End If

            cmd = New SqlCommand("update BANK_DETAILS set BANK_CODE='" & bnchCode & "', BANK_NAME='" & BankString.removeSpecialCharacter(bnchName) & "' where BANK_CODE='" & branchEditID & "'", con)
            'Dim cmdAudit As SqlCommand
            'cmdAudit = New SqlCommand("insert into TEMP_BNCH_DETAILS ([ACTION],[PERFORMED_BY],[PERFORMED_DATE],[OLD_BNCH_CODE],[BNCH_CODE],[OLD_BNCH_NAME],[BNCH_NAME],[OLD_BNCH_ADDRESS],[BNCH_ADDRESS],[OLD_BNCH_PHONENO],[BNCH_PHONENO],[OLD_BNCH_FAXNO],[BNCH_FAXNO]) values ('UPDATE','" & Session("UserID") & "',getDate(),'" & oldBnchCode & "','" & bnchCode & "','" & oldBnchName & "','" & bnchName & "','" & oldBnchAddress & "','" & bnchAddress & "','" & oldBnchPhone & "','" & bnchPhone & "','" & oldBnchFax & "','')", con)
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            con.Open()
            If cmd.ExecuteNonQuery Then
                'cmdAudit.ExecuteNonQuery()
                msgbox("Successfully updated")
            Else
                msgbox("Error updating value")
            End If
            con.Close()
            grdBranches.EditIndex = -1
            getBranches()

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Function isUniqueCode(ByVal bnchCode As String) As Boolean
        Try
            cmd = New SqlCommand("select * from BANK_DETAILS where BANK_CODE='" & bnchCode & "'", con)
            Dim ds As New DataSet
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "BANKS")
            If ds.Tables(0).Rows.Count > 0 Then
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Function

    Protected Sub grdBranches_SelectedIndexChanged(sender As Object, e As EventArgs) Handles grdBranches.SelectedIndexChanged

    End Sub
End Class