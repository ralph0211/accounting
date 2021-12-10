Imports System.Data
Imports System.Data.SqlClient
Imports SecureBank
Imports CreditManager
Imports ErrorLogging

Partial Class UserMgtAuth
    Inherits System.Web.UI.Page
    'for editing roles grid and users grid
    Public Shared rolesEditID, usersEditID, moduleEditID As String

    Dim adp As New SqlDataAdapter
    Dim cmd As SqlCommand
    Dim con As New SqlConnection
    Dim connection As String
    Dim ds As New DataSet()
    Dim Objclsdb As New CreditManager
    Dim urlPermission As String = "PermissionDenied.aspx"
    Public Sub msgbox(ByVal strMessage As String)
        'finishes server processing, returns to client.
        Dim strScript As String = "<script language=JavaScript>"
        strScript += "window.alert(""" & strMessage & """);"
        strScript += "</script>"
        Dim lbl As New System.Web.UI.WebControls.Label
        lbl.Text = strScript
        Page.Controls.Add(lbl)
    End Sub

    Protected Sub authorizeRole(ByVal ID As Double)
        Try
            cmd = New SqlCommand("select USER_MODIFIED_BY from TEMP_ROLES where ID='" & ID & "'", con)
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            con.Open()
            Dim updateUser = cmd.ExecuteScalar
            con.Close()

            'If isSameUser(updateUser, Session("UserID")) Then
            '    msgbox("Your can not authorize your own update")
            'Else

            cmd = New SqlCommand("select COMMAND from TEMP_ROLES where ID='" & ID & "'", con)
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            con.Open()
            Dim updateCmd = cmd.ExecuteScalar
            con.Close()
            cmd = New SqlCommand(updateCmd, con)
            Dim cmd1 = New SqlCommand("update TEMP_ROLES set UPDATED=1,USER_APPROVED_BY='" & Session("UserID") & "',USER_APPROVED_DATE=GETDATE() where ID='" & ID & "'", con)
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            con.Open()
            If cmd.ExecuteNonQuery Then
                cmd1.ExecuteNonQuery()
                msgbox("Record successfully authorized")
                recordAction("cmbAuthRolesAction_RowCommand", "Authorized role update: " & ID.ToString)
            Else
                msgbox("Error authorizing record")
            End If
            con.Close()
            loadRolesToBeAuthorized(cmbAuthRolesAction.SelectedValue.ToString)
            'End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub authorizeUser(ByVal ID As Double)
        Try
            cmd = New SqlCommand("select isnull(USER_CREATED_BY,USER_MODIFIED_BY) as userID, USER_SIGN,ACTION from TEMP_USERS where ID='" & ID & "'", con)
            Dim ds11 As New DataSet
            Dim adp11 As New SqlDataAdapter
            adp11 = New SqlDataAdapter(cmd)
            adp11.Fill(ds11, "USERS")

            Dim updateUser = ds11.Tables(0).Rows(0).Item("userID")
            Dim userSign As Byte()
            Try
                userSign = ds11.Tables(0).Rows(0).Item("USER_SIGN")
            Catch ex As Exception
                userSign = Nothing
            End Try

            'msgbox(ID)

            'If isSameUser(updateUser, Session("UserID")) Then
            '    msgbox("Your can not authorize your own update")
            'Else
            cmd = New SqlCommand("select COMMAND from TEMP_USERS where ID='" & ID & "'", con)
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            con.Open()
            Dim updateCmd = cmd.ExecuteScalar
            con.Close()
            cmd = New SqlCommand(updateCmd, con)
            If ds11.Tables(0).Rows(0).Item("ACTION") = "UPDATE" Or ds11.Tables(0).Rows(0).Item("ACTION") = "DELETE" Then
            Else
                'cmd.Parameters.Add(New SqlParameter("@SignImage", DirectCast(userSign, Object)))
            End If
            Dim cmd1 = New SqlCommand("update TEMP_USERS set UPDATED=1 where ID='" & ID & "'", con)
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            con.Open()
            If cmd.ExecuteNonQuery Then
                cmd1.ExecuteNonQuery()
                msgbox("Record successfully authorized")
                recordAction("cmbAuthUsersAction_RowCommand", "Authorized user update: " & ID.ToString)
            Else
                msgbox("Error authorizing record")
            End If
            con.Close()
            loadUsersToBeAuthorized(cmbAuthUsersAction.SelectedValue.ToString)
            'End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub cmbAuthRolesAction_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbAuthRolesAction.SelectedIndexChanged
        loadRolesToBeAuthorized(cmbAuthRolesAction.SelectedValue.ToString)
    End Sub

    Protected Sub cmbAuthUsersAction_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbAuthUsersAction.SelectedIndexChanged
        'msgbox(cmbAuthUsersAction.SelectedValue.ToString)
        loadUsersToBeAuthorized(cmbAuthUsersAction.SelectedValue.ToString)
    End Sub

    Protected Sub discardRole(ByVal ID As Double)
        Try
            cmd = New SqlCommand("delete from TEMP_ROLES where ID='" & ID & "'", con)
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            con.Open()
            If cmd.ExecuteNonQuery Then
                msgbox("Record successfully discarded")
                recordAction("grdAuthRoles_RowCommand", "Discarded role update: " & ID.ToString)
            Else
                msgbox("Error discarding record")
            End If
            con.Close()
            loadRolesToBeAuthorized(cmbAuthRolesAction.SelectedValue.ToString)
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub discardUser(ByVal ID As Double)
        Try
            cmd = New SqlCommand("delete from TEMP_USERS where ID='" & ID & "'", con)
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            con.Open()
            If cmd.ExecuteNonQuery Then
                msgbox("Record successfully discarded")
                recordAction("grdAuthUsers_RowCommand", "Discarded user update: " & ID.ToString)
            Else
                msgbox("Error discarding record")
            End If
            con.Close()
            loadUsersToBeAuthorized(cmbAuthUsersAction.SelectedValue.ToString)
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub grdAuthRoles_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdAuthRoles.RowCommand
        Dim updateID = CDbl(e.CommandArgument)
        If e.CommandName = "AuthorizeRole" Then
            authorizeRole(updateID)
        ElseIf e.CommandName = "DiscardRole" Then
            discardRole(updateID)
        End If
    End Sub

    Protected Sub grdAuthUsers_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdAuthUsers.RowCommand
        'Dim updateID = CDbl(e.CommandArgument)
        ''msgbox(updateID)
        'If e.CommandName = "AuthorizeUser" Then
        '    authorizeUser(updateID)
        'ElseIf e.CommandName = "DiscardUser" Then
        '    discardUser(updateID)
        'End If
        Try
            Dim action = e.CommandName
            Dim rID = e.CommandArgument
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd As New SqlCommand("AuthorizeUser", con)
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.AddWithValue("@editID", rID)
                    cmd.Parameters.AddWithValue("@Decision", action)
                    cmd.Parameters.AddWithValue("@User", Session("UserId"))
                    con.Open()
                    If cmd.ExecuteNonQuery Then
                        If action = "Authorize" Then
                            notify("User successfully authorized", "success")
                            '''''''''IF IS USER CREATION THEN SEND ACTIVATION EMAIL''''''''''''''
                            Dim dr As DataRow
                            dr = getAuthorizedUserRow(rID)
                            If dr IsNot Nothing Then
                                'construct email
                                Dim baseUrl As String = Request.Url.Scheme & "://" & Request.Url.Authority + Request.ApplicationPath.TrimEnd("/"c) & "/"
                                Dim emailBody As String = ""
                                If dr("ACTION") = "UPDATE" Then
                                    emailBody += "Hi " + dr("FNAME") + "<br/><br/>"
                                    emailBody += "Your Escrow 360 Credit Management account has been updated. Your user profile is as below:<br/><br/>"
                                    emailBody += "<table style='border: 1px solid black; width:750px;border-collapse: collapse; font-size:13px'>"
                                    emailBody += "<tr style='background-color: blue;padding: 15px;text-align: left;'><th style='border: 1px solid black;text-align: left;'>Field</th><th style='border: 1px solid black;text-align: left;'>Old Value</th><th style='border: 1px solid black;text-align: left;'>New Value</th></tr>"
                                    emailBody += "<tr style='background-color: #f5f5f5;padding: 15px;text-align: left;'><td style='border: 1px solid black;text-align: left;'>Forenames</td><td style='border: 1px solid black;text-align: left;'>" & dr("OLD_FNAME") & "</td><td style='border: 1px solid black;text-align: left;'>" & dr("FNAME") & "</td></tr>"
                                    emailBody += "<tr style='background-color: white;padding: 15px;text-align: left;'><td style='border: 1px solid black;text-align: left;'>Surname</td><td style='border: 1px solid black;text-align: left;'>" & dr("OLD_LNAME") & "</td><td style='border: 1px solid black;text-align: left;'>" & dr("LNAME") & "</td></tr>"
                                    emailBody += "<tr style='background-color: #f5f5f5;padding: 15px;text-align: left;'><td style='border: 1px solid black;text-align: left;'>Username</td><td style='border: 1px solid black;text-align: left;'>" & dr("OLD_USER_LOGIN") & "</td><td style='border: 1px solid black;text-align: left;'>" & dr("USER_LOGIN") & "</td></tr>"
                                    emailBody += "<tr style='background-color: white;padding: 15px;text-align: left;'><td style='border: 1px solid black;text-align: left;'>Branch</td><td style='border: 1px solid black;text-align: left;'>" & dr("OLD_USER_BRANCH") & " - " & dr("OLD_FullBranchName") & "</td><td style='border: 1px solid black;text-align: left;'>" & dr("USER_BRANCH") & " - " & dr("FullBranchName") & "</td></tr>"
                                    emailBody += "<tr style='background-color: #f5f5f5;padding: 15px;text-align: left;'><td style='border: 1px solid black;text-align: left;'>User Role</td><td style='border: 1px solid black;text-align: left;'>" & dr("OLD_FullRoleName") & "</td><td style='border: 1px solid black;text-align: left;'>" & dr("FullRoleName") & "</td></tr>"
                                    emailBody += "<tr style='background-color: white;padding: 15px;text-align: left;'><td style='border: 1px solid black;text-align: left;'>Email Address</td><td style='border: 1px solid black;text-align: left;'>" & dr("OLD_USER_EMAIL_ID") & "</td><td style='border: 1px solid black;text-align: left;'>" & dr("USER_EMAIL_ID") & "</td></tr>"
                                    emailBody += "<tr style='background-color: #f5f5f5;padding: 15px;text-align: left;'><td style='border: 1px solid black;text-align: left;'>Cellphone Number</td><td style='border: 1px solid black;text-align: left;'>" & dr("OLD_USER_PHONE_NO1") & "</td><td style='border: 1px solid black;text-align: left;'>" & dr("USER_PHONE_NO1") & "</td></tr>"
                                    emailBody += "</table><br/><br/>"
                                    emailBody += "If any of the details is not correct, please contact the administrator to correct.<br/><br/>"
                                    emailBody += "<a href='" + baseUrl + "Login.aspx'>Click here to login to the system</a><br/><br/>"
                                ElseIf dr("ACTION") = "Insert" Then
                                    emailBody += "Hi " + dr("FNAME") + "<br/><br/>"
                                    emailBody += "Your Escrow 360 Credit Management account has been created. Your user profile is as below:<br/><br/>"
                                    emailBody += "<table style='border: 1px solid black; width:750px;border-collapse: collapse; font-size:13px'>"
                                    emailBody += "<tr style='background-color: #f5f5f5;padding: 15px;text-align: left;'><th style='border: 1px solid black;text-align: left;'>Forenames:</th><td style='border: 1px solid black;'>" & dr("FNAME") & "</td></tr>"
                                    emailBody += "<tr style='background-color: white;padding: 15px;text-align: left;'><th style='border: 1px solid black;text-align: left;'>Surname:</th><td style='border: 1px solid black;'>" & dr("LNAME") & "</td></tr>"
                                    emailBody += "<tr style='background-color: #f5f5f5;padding: 15px;text-align: left;'><th style='border: 1px solid black;text-align: left;'>Username:</th><td style='border: 1px solid black;'>" & dr("USER_LOGIN") & "</td></tr>"
                                    emailBody += "<tr style='background-color: white;padding: 15px;text-align: left;'><th style='border: 1px solid black;text-align: left;'>Password:</th><td style='border: 1px solid black;'>" & dr("USER_PWD") & "</td></tr>"
                                    emailBody += "<tr style='background-color: #f5f5f5;padding: 15px;text-align: left;'><th style='border: 1px solid black;text-align: left;'>User Role:</th><td style='border: 1px solid black;'>" & dr("FullRoleName") & "</td></tr>"
                                    emailBody += "<tr style='background-color: white;padding: 15px;text-align: left;'><th style='border: 1px solid black;text-align: left;'>Branch:</th><td style='border: 1px solid black;'>" & dr("USER_BRANCH") & " - " & dr("FullBranchName") & "</td></tr>"
                                    emailBody += "<tr style='background-color: #f5f5f5;padding: 15px;text-align: left;'><th style='border: 1px solid black;text-align: left;'>Cellphone Number:</th><td style='border: 1px solid black;'>" & dr("USER_PHONE_NO1") & "</td></tr>"
                                    emailBody += "<tr style='background-color: white;padding: 15px;text-align: left;'><th style='border: 1px solid black;text-align: left;'>Email Address:</th><td style='border: 1px solid black;'>" & dr("USER_EMAIL_ID") & "</td></tr>"
                                    emailBody += "</table><br/><br/>"
                                    emailBody += "If any of the details is not correct, please contact the administrator to correct.<br/><br/>"
                                    emailBody += "<a href='" + baseUrl + "Login.aspx'>Click here to login to the system</a><br/><br/>"
                                ElseIf dr("ACTION") = "DELETE" Then
                                    emailBody += "Hi " + dr("FNAME") + "<br/><br/>"
                                    emailBody += "Your Escrow 360 Credit Management account has been disabled. You can no longer log in to the system<br/>"
                                End If
                                emailBody += "Regards<br/>"
                                Dim SignatoryEMail = dr("USER_EMAIL_ID")
                                    Mailhelper.SendMailMessage("administrator", SignatoryEMail, "", "", "Escrow 360 Credit Management System Account Created", emailBody)
                                End If
                            Else
                            notify("User successfully discarded", "success")
                        End If
                        loadUsersToBeAuthorized(cmbAuthUsersAction.SelectedValue)
                    Else
                        If action = "Authorize" Then
                            notify("Error authorizing user", "error")
                        Else
                            notify("Error discarding user", "error")
                        End If
                    End If
                    con.Close()
                End Using
            End Using
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- grdAuthBranch_RowCommand()", ex.ToString)
        End Try
    End Sub

    Protected Function getAuthorizedUserRow(id As String) As DataRow
        Try
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd As New SqlCommand("select tu.*,MASTER_ROLES.RoleName as FullRoleName,omr.RoleName as OLD_FullRoleName,bd.BNCH_NAME as FullBranchName,obd.BNCH_NAME as OLD_FullBranchName from TEMP_USERS tu left join MASTER_ROLES on tu.USER_TYPE=MASTER_ROLES.RoleID left join MASTER_ROLES omr on tu.OLD_USER_TYPE=omr.RoleID left JOIN BNCH_DETAILS bd ON USER_BRANCH=bd.BNCH_CODE left JOIN BNCH_DETAILS obd ON OLD_USER_BRANCH=obd.BNCH_CODE where tu.id=@id", con)
                    cmd.Parameters.AddWithValue("@id", id)
                    Dim dt As New DataTable
                    Using adp As New SqlDataAdapter(cmd)
                        adp.Fill(dt)
                    End Using
                    If dt.Rows.Count > 0 Then
                        Return dt.Rows(0)
                    Else
                        Return Nothing
                    End If
                End Using
            End Using
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- getAuthorizedUserRow()", ex.ToString)
            Return Nothing
        End Try
    End Function

    Protected Function isEmptyString(ByVal str As String) As Boolean
        If IsDBNull(str) Or Trim(str) = "" Then
            Return True
        Else
            Return False
        End If
    End Function

    Protected Function isSameUser(ByVal user1 As String, ByVal user2 As String) As Boolean
        If Not isEmptyString(user1) And Not isEmptyString(user2) Then
            If user1 = user2 Then
                Return True
            Else
                Return False
            End If
        Else

        End If
    End Function

    Protected Sub loadRolesToBeAuthorized(ByVal authValue As Integer)
        'If authValue = 1 Then
        cmd = New SqlCommand("select [ID],[ACTION],[OLD_RoleID],[RoleID],[OLD_RoleName],[RoleName],[OLD_DASHBOARD],[DASHBOARD] from TEMP_ROLES where UPDATED=0", con)
            'ElseIf authValue = 2 Then
            '    cmd = New SqlCommand("select [ID],[ACTION],[RoleID],[RoleName],[USER_STATUS],[DASHBOARD],[USER_CREATED_DATE],[USER_CREATED_BY] from TEMP_ROLES where action='Insert' and UPDATED=0", con)
            'ElseIf authValue = 3 Then
            '    cmd = New SqlCommand("select [ID],[ACTION],[OLD_RoleID],[RoleID],[OLD_RoleName],[RoleName],[OLD_DASHBOARD],[DASHBOARD],[USER_MODIFIED_BY],[USER_MODIFIED_DATE] from TEMP_ROLES where action='Update' and UPDATED=0", con)
            'ElseIf authValue = 4 Then
            '    cmd = New SqlCommand("select [ID],[ACTION],[RoleID],[RoleName],[DASHBOARD],[USER_STATUS],[USER_MODIFIED_BY],[USER_MODIFIED_DATE] from TEMP_ROLES where action='Delete' and UPDATED=0", con)
            'End If
            Dim ds1 As New DataSet
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds1, "TEMP_ROLES")
        If ds1.Tables(0).Rows.Count > 0 Then
            grdAuthRoles.DataSource = ds1.Tables(0)
        Else
            grdAuthRoles.DataSource = Nothing
        End If
        grdAuthRoles.DataBind()
    End Sub

    Protected Sub loadUsersToBeAuthorized(ByVal authValue As Integer)
        'If authValue = 1 Then
        cmd = New SqlCommand("select [ID],[ACTION],[OLD_USER_LOGIN],[USER_LOGIN],[OLD_USER_TYPE],[USER_TYPE],[OLD_USER_EMAIL_ID],[USER_EMAIL_ID],[OLD_FNAME],[FNAME],[OLD_LNAME],[LNAME] from TEMP_USERS where ([Authorized] is null or [Authorized]=0) and ([Discarded] is null or [Discarded]=0)", con)
            'ElseIf authValue = 2 Then
            '    cmd = New SqlCommand("select [ID],[ACTION],[USER_LOGIN],[FNAME],[LNAME],[USER_PWD],[USER_TYPE],[USER_SIGN],[USER_BRANCH],[USER_PHONE_NO1],[USER_EMAIL_ID],[USER_CREATED_DATE],[USER_CREATED_BY] from TEMP_USERS where action='Insert' and UPDATED=0", con)
            'ElseIf authValue = 3 Then
            '    cmd = New SqlCommand("select [ID],[ACTION],[OLD_USER_LOGIN],[USER_LOGIN],[OLD_USER_PWD],[USER_PWD],[OLD_USER_TYPE],[USER_TYPE],[OLD_USER_SIGN],[USER_SIGN],[OLD_USER_BRANCH],[USER_BRANCH],[OLD_USER_PHONE_NO1],[USER_PHONE_NO1],[OLD_USER_EMAIL_ID],[USER_EMAIL_ID],[USER_CREATED_DATE],[USER_CREATED_BY],[USER_MODIFIED_BY],[USER_MODIFIED_DATE],[OLD_FNAME],[FNAME],[OLD_LNAME],[LNAME] from TEMP_USERS where action='Update' and UPDATED=0", con)
            'ElseIf authValue = 4 Then
            '    cmd = New SqlCommand("select [ID],[ACTION],[USER_LOGIN],[FNAME],[LNAME],[USER_TYPE],[USER_SIGN],[USER_BRANCH],[USER_PHONE_NO1],[USER_EMAIL_ID],[USER_CREATED_DATE],[USER_CREATED_BY] from TEMP_USERS where action='Delete' and UPDATED=0", con)
            'End If
            Dim ds1 As New DataSet
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds1, "TEMP_USERS")
        If ds1.Tables(0).Rows.Count > 0 Then
            grdAuthUsers.DataSource = ds1.Tables(0)
        Else
            grdAuthUsers.DataSource = Nothing
        End If
        grdAuthUsers.DataBind()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Page.MaintainScrollPositionOnPostBack = True
            con = New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
            If Not IsPostBack Then
                loadUsersToBeAuthorized(cmbAuthUsersAction.SelectedValue.ToString)
                loadRolesToBeAuthorized(cmbAuthRolesAction.SelectedValue.ToString)
            End If
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- Page_Load()", ex.ToString)
        End Try
    End Sub
End Class