Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports CreditManager
Imports ErrorLogging
Imports SecureBank

Partial Class Users
    Inherits System.Web.UI.Page
    'for editing roles grid and users grid
    Public Shared rolesEditID, usersEditID, moduleEditID As String

    Dim adp As New SqlDataAdapter
    Dim cmd As SqlCommand
    Dim con As New SqlConnection

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Page.MaintainScrollPositionOnPostBack = True
            con = New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
            Dim surl As String = HttpContext.Current.Request.Url.AbsoluteUri
            surl = Mid(surl, surl.LastIndexOf("/") + 2)
            If Not IsPostBack Then
                loadUserRoles(cmbUserRole)
                getAddedUsers()
                loadBranches(cmbBranch)
                txtPwd.Text = randomPasswordGenerator() ' getDefaultPassword()
                'msgbox(randomPasswordGenerator)
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Function getDefaultPassword() As String
        cmd = New SqlCommand("select DefaultPassword from PARA_LOGIN", con)
        Dim ds As New DataSet
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "LOGIN")
        If ds.Tables(0).Rows.Count > 0 Then
            Return ds.Tables(0).Rows(0).Item("DefaultPassword")
        Else
            Return ""
        End If
    End Function

    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSubmit.Click
        Try
            AdduserFname1()
            getAddedUsers()
            clearAddedUserInfo()
            unselectAllRoles()
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- btnSubmit_Click()", ex.ToString)
        End Try
    End Sub
    Protected Sub clearAddedUserInfo()
        Try
            cmbUserRole.ClearSelection()
            txtForeName.Text = ""
            txtSurName.Text = ""
            txtUserName.Text = ""
            txtEmailAddress.Text = ""
            txtPhoneNumber.Text = ""
            'txtPwd.Text = ""
            cmbBranch.ClearSelection()
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub AdduserFname1()
        Try
            cmd = New SqlCommand("insert into TEMP_USERS(ACTION,USER_LOGIN,USER_PWD,USER_TYPE,USER_BRANCH,USER_PHONE_NO1,USER_EMAIL_ID,USER_CREATED_DATE,USER_CREATED_BY,FNAME,LNAME,PWD_DATE,LOCK_COUNT,UPDATED,SavedBy,SaveDate) values ('Insert',@UserName,@Pwd,@UserRole,'" & cmbBranch.SelectedValue & "','" & txtPhoneNumber.Text & "',@EmailAddress,GETDATE(),@creater,@ForeName,@SurName,GETDATE(),'0','0',@creater,GETDATE())", con)
            cmd.Parameters.AddWithValue("@UserName", txtUserName.Text)
            cmd.Parameters.AddWithValue("@Pwd", txtPwd.Text)
            cmd.Parameters.AddWithValue("@UserRole", cmbUserRole.SelectedValue)
            cmd.Parameters.AddWithValue("@EmailAddress", txtEmailAddress.Text)
            cmd.Parameters.AddWithValue("@ForeName", txtForeName.Text)
            cmd.Parameters.AddWithValue("@SurName", txtSurName.Text)
            cmd.Parameters.AddWithValue("@creater", Session("UserId"))
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            con.Open()
            If cmd.ExecuteNonQuery Then
                notify("User created. Pending authorization", "success")
                recordAction("btnSubmit", "Added new system user: " & txtUserName.Text)
            Else
                notify("Error creating user", "error")
            End If
            con.Close()
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub getAddedUsers()
        Try
            cmd = New SqlCommand("select MASTER_USERS.*,MASTER_ROLES.RoleName as FullRoleName,bd.BNCH_NAME as FullBranchName from MASTER_USERS left join MASTER_ROLES on MASTER_USERS.USER_TYPE=MASTER_ROLES.RoleID left JOIN BNCH_DETAILS bd ON USER_BRANCH=bd.BNCH_CODE", con)
            Dim ds As New DataSet
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "MASTER_USERS")
            If ds.Tables(0).Rows.Count > 0 Then
                grdAddedUsers.DataSource = ds.Tables(0)
            Else
                grdAddedUsers.DataSource = Nothing
            End If
            grdAddedUsers.DataBind()
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub grdAddedUsers_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdAddedUsers.PageIndexChanging
        grdAddedUsers.PageIndex = e.NewPageIndex
        getAddedUsers()
    End Sub

    Protected Sub grdAddedUsers_RowCancelingEdit(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles grdAddedUsers.RowCancelingEdit
        grdAddedUsers.EditIndex = -1
        getAddedUsers()
    End Sub

    Protected Sub grdAddedUsers_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdAddedUsers.RowDataBound
        If (e.Row.RowType = DataControlRowType.DataRow And grdAddedUsers.EditIndex = e.Row.RowIndex) Then
            Dim cmbRole = DirectCast(e.Row.FindControl("grdUsers_cmbUserTypeEdit"), DropDownList)
            Dim cmbUserBranch = DirectCast(e.Row.FindControl("grdUsers_cmbBranchEdit"), DropDownList)
            loadUserRoles(cmbRole)
            loadBranches(cmbUserBranch)
            Try
                cmbRole.SelectedValue = DirectCast(e.Row.FindControl("grdUsers_txtUserTypeEdit"), TextBox).Text
            Catch ex As Exception
                cmbRole.ClearSelection()
            End Try
            Try
                cmbUserBranch.SelectedValue = DirectCast(e.Row.FindControl("grdUsers_txtBranchEdit"), TextBox).Text
            Catch ex As Exception
                cmbUserBranch.ClearSelection()
            End Try
        End If
    End Sub

    Protected Sub grdAddedUsers_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles grdAddedUsers.RowDeleting
        Try
            usersEditID = DirectCast(grdAddedUsers.Rows(e.RowIndex).FindControl("grdUsers_txtUserId"), TextBox).Text
            Dim userType = DirectCast(grdAddedUsers.Rows(e.RowIndex).FindControl("grdUsers_txtUserType"), TextBox).Text
            Dim userName = DirectCast(grdAddedUsers.Rows(e.RowIndex).FindControl("grdUsers_txtUsername"), TextBox).Text
            Dim branch = DirectCast(grdAddedUsers.Rows(e.RowIndex).FindControl("grdUsers_txtBranch"), TextBox).Text
            Dim forename = DirectCast(grdAddedUsers.Rows(e.RowIndex).FindControl("grdUsers_lblForenames"), Label).Text
            Dim surname = DirectCast(grdAddedUsers.Rows(e.RowIndex).FindControl("grdUsers_lblSurname"), Label).Text
            Dim email = DirectCast(grdAddedUsers.Rows(e.RowIndex).FindControl("grdUsers_lblEmail"), Label).Text
            Dim telephone = DirectCast(grdAddedUsers.Rows(e.RowIndex).FindControl("grdUsers_lblTel"), Label).Text

            cmd = New SqlCommand("insert into TEMP_USERS (ACTION,USER_LOGIN,USER_TYPE,USER_BRANCH,USER_PHONE_NO1,UPDATED,USER_MODIFIED_BY,USER_MODIFIED_DATE,SavedBy,SaveDate,USER_EMAIL_ID,UserID,[FNAME],[LNAME]) values('DELETE',@UserName,@userType,@branch,@phone," & 0 & ",@creater,GETDATE(),@creater,GETDATE(),@email,@uID,@fName,@sName)", con)
            cmd.Parameters.AddWithValue("@UserName", userName)
            cmd.Parameters.AddWithValue("@userType", userType)
            cmd.Parameters.AddWithValue("@branch", branch)
            cmd.Parameters.AddWithValue("@phone", telephone)
            cmd.Parameters.AddWithValue("@email", email)
            cmd.Parameters.AddWithValue("@uID", usersEditID)
            cmd.Parameters.AddWithValue("@creater", Session("UserId"))
            cmd.Parameters.AddWithValue("@fName", forename)
            cmd.Parameters.AddWithValue("@sName", surname)

            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            con.Open()
            If cmd.ExecuteNonQuery Then
                recordAction("grdAddedUsers_RowDeleting", "Deleted system user: " & usersEditID)
                notify("User successfully flagged for deletion", "success")
            Else
                notify("Error deleting user", "error")
            End If
            con.Close()
            getAddedUsers()
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- grdAddedUsers_RowDeleting()", ex.ToString)
        End Try
    End Sub

    Protected Sub grdAddedUsers_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles grdAddedUsers.RowEditing
        usersEditID = DirectCast(grdAddedUsers.Rows(e.NewEditIndex).FindControl("grdUsers_txtUserId"), TextBox).Text
        grdAddedUsers.EditIndex = e.NewEditIndex
        getAddedUsers()
    End Sub

    Protected Sub grdAddedUsers_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles grdAddedUsers.RowUpdating
        Try
            If Trim(usersEditID) = "" Or IsDBNull(usersEditID) Then
                msgbox("No user selected for update")
                Exit Sub
            End If
            Dim userType = DirectCast(grdAddedUsers.Rows(e.RowIndex).FindControl("grdUsers_cmbUserTypeEdit"), DropDownList).SelectedValue
            Dim FName As String = DirectCast(grdAddedUsers.Rows(e.RowIndex).FindControl("grdUsers_txtForenamesEdit"), TextBox).Text
            Dim LName As String = DirectCast(grdAddedUsers.Rows(e.RowIndex).FindControl("grdUsers_txtSurnameEdit"), TextBox).Text
            Dim email As String = DirectCast(grdAddedUsers.Rows(e.RowIndex).FindControl("grdUsers_txtEmailEdit"), TextBox).Text
            Dim telephone As String = DirectCast(grdAddedUsers.Rows(e.RowIndex).FindControl("grdUsers_txtTelEdit"), TextBox).Text
            Dim userName As String = DirectCast(grdAddedUsers.Rows(e.RowIndex).FindControl("grdUsers_txtUsernameEdit"), TextBox).Text
            Dim branch = DirectCast(grdAddedUsers.Rows(e.RowIndex).FindControl("grdUsers_cmbBranchEdit"), DropDownList).SelectedValue

            If Trim(userType) = "" Then
                notify("User role is required", "error")
            ElseIf Trim(FName) = "" Then
                notify("Forenames is required", "error")
            ElseIf Trim(LName) = "" Then
                notify("Surname is required", "error")
            ElseIf Trim(email) = "" Then
                notify("Email address is required", "error")
            ElseIf Trim(telephone) = "" Then
                notify("Telephone is required", "error")
            ElseIf Trim(userName) = "" Then
                notify("Username is required", "error")
            ElseIf Trim(branch) = "" Then
                notify("Branch is required", "error")
            Else

                Dim oldUserType, oldFName, oldLName, oldEmail, oldTelephone, oldBranch, oldUserName As String
                oldUserType = ""
                oldFName = ""
                oldLName = ""
                oldEmail = ""
                oldTelephone = ""
                oldBranch = ""
                oldUserName = ""

                'command to get currently existing values
                cmd = New SqlCommand("select * from MASTER_USERS where USERID='" & usersEditID & "'", con)
                Dim ds1 As New DataSet
                adp = New SqlDataAdapter(cmd)
                adp.Fill(ds1, "MASTER_USERS")
                If ds1.Tables(0).Rows.Count > 0 Then
                    oldUserType = ds1.Tables(0).Rows(0).Item("USER_TYPE").ToString
                    oldFName = ds1.Tables(0).Rows(0).Item("FNAME").ToString
                    oldLName = ds1.Tables(0).Rows(0).Item("LNAME").ToString
                    oldEmail = ds1.Tables(0).Rows(0).Item("USER_EMAIL_ID").ToString
                    oldTelephone = ds1.Tables(0).Rows(0).Item("USER_PHONE_NO1").ToString
                    oldBranch = ds1.Tables(0).Rows(0).Item("USER_BRANCH").ToString
                    oldUserName = ds1.Tables(0).Rows(0).Item("USER_LOGIN").ToString
                End If

                cmd = New SqlCommand("insert into TEMP_USERS (ACTION,OLD_USER_LOGIN,USER_LOGIN,OLD_FNAME,FNAME,OLD_LNAME,LNAME,OLD_USER_PHONE_NO1,USER_PHONE_NO1,OLD_USER_EMAIL_ID,USER_EMAIL_ID,OLD_USER_TYPE,USER_TYPE,OLD_USER_BRANCH,USER_BRANCH,UPDATED,USER_MODIFIED_BY,USER_MODIFIED_DATE,SavedBy,SaveDate,UserID) values ('UPDATE',@oldUserLogin,@userLogin,@oldFName,@FName,@oldLName,@LName,@oldTelephone,@telephone,@oldEmail,@email,@oldUserType,@userType,@oldBranch,@branch,0,@creater,GETDATE(),@creater,GETDATE(),@uID)", con)
                cmd.Parameters.AddWithValue("@oldUserLogin", oldUserName)
                cmd.Parameters.AddWithValue("@userLogin", userName)
                cmd.Parameters.AddWithValue("@oldFName", oldFName)
                cmd.Parameters.AddWithValue("@FName", FName)
                cmd.Parameters.AddWithValue("@oldLName", oldLName)
                cmd.Parameters.AddWithValue("@LName", LName)
                cmd.Parameters.AddWithValue("@oldTelephone", oldTelephone)
                cmd.Parameters.AddWithValue("@telephone", telephone)
                cmd.Parameters.AddWithValue("@oldEmail", oldEmail)
                cmd.Parameters.AddWithValue("@email", email)
                cmd.Parameters.AddWithValue("@oldUserType", oldUserType)
                cmd.Parameters.AddWithValue("@userType", userType)
                cmd.Parameters.AddWithValue("@oldBranch", oldBranch)
                cmd.Parameters.AddWithValue("@branch", branch)
                cmd.Parameters.AddWithValue("@creater", Session("UserId"))
                cmd.Parameters.AddWithValue("@uID", usersEditID)
                If con.State = ConnectionState.Open Then
                    con.Close()
                End If
                con.Open()
                If cmd.ExecuteNonQuery Then
                    recordAction("grdAddedUsers_RowUpdating", "Updated system user: " & FName & " " & LName)
                    notify("User successfully flagged for update. Authorization pending", "success")
                Else
                    notify("Error updating user", "error")
                End If
                con.Close()
                grdAddedUsers.EditIndex = -1
                getAddedUsers()
            End If
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- grdAddedUsers_RowUpdating()", ex.ToString)
        End Try
    End Sub

    Protected Function isEmptyString(ByVal str As String) As Boolean
        If IsDBNull(str) Or Trim(str) = "" Then
            Return True
        Else
            Return False
        End If
    End Function

    Protected Sub btnReset_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReset.Click
        clearAddedUserInfo()
    End Sub

    Protected Sub txtSurName_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSurName.TextChanged
        Try
            txtUserName.Text = (txtForeName.Text & "." & txtSurName.Text).ToLower
        Catch ex As Exception
            txtUserName.Text = ""
        End Try
    End Sub

    Protected Sub btnSearchUser_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearchUser.Click
        Try

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub loadMultiRoles()
        Try
            cmd = New SqlCommand("select * from MASTER_ROLES", con)
            Dim ds As New DataSet
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "ROLES")
            If ds.Tables(0).Rows.Count > 0 Then
                grdUserRoles.DataSource = ds.Tables(0)
            Else
                grdUserRoles.DataSource = Nothing
            End If
            grdUserRoles.DataBind()
        Catch ex As Exception

        End Try
    End Sub

    Protected Function buildSelectedRoles() As String
        Try
            Dim roles As String = ""
            For Each row As GridViewRow In grdUserRoles.Rows
                Dim chkView As CheckBox = DirectCast(row.FindControl("chk"), CheckBox)
                Dim roleID = DirectCast(row.FindControl("lblRoleId"), Label).Text
                If chkView.Checked Then
                    If roles = "" Then
                        roles = roleID
                    Else
                        roles = roles & "," & roleID
                    End If
                Else

                End If
            Next
            Return roles
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Protected Sub unselectAllRoles()
        Try
            For Each row As GridViewRow In grdUserRoles.Rows
                Dim chkView As CheckBox = DirectCast(row.FindControl("chk"), CheckBox)
                If chkView.Checked Then
                    chkView.Checked = False
                Else

                End If
            Next
        Catch ex As Exception
        End Try
    End Sub

    Protected Function randomPasswordGenerator() As String
        Try
            Dim ran As New Random
            Dim ntw As New NumberToWordsConverter
            'Return ntw.ConvertCurrencyToEnglish(123232.98, "USD")
            ''ran.Next.ToString()
            Return Web.Security.Membership.GeneratePassword(8, 2)
        Catch ex As Exception
            Return ""
        End Try
    End Function
End Class