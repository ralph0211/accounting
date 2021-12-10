Imports System.Data
Imports System.Data.SqlClient
Imports CreditManager
Imports ErrorLogging

Partial Class Admin_UnlockUsers
    Inherits System.Web.UI.Page
    'for editing roles grid and users grid
    Public Shared rolesEditID, usersEditID, moduleEditID As String

    Const urlPermission As String = "PermissionDenied.aspx"
    Dim adp As New SqlDataAdapter
    Dim cmd As SqlCommand
    Dim con As New SqlConnection
    Dim connection As String
    Dim ds As New DataSet()
    Dim Objclsdb As New CreditManager

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

    Protected Sub getLockedUsers()
        Try
            Dim logAttempt = 0
            cmd = New SqlCommand("select MaximumLoginAttempts from PARA_LOGIN", con)
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            con.Open()
            logAttempt = cmd.ExecuteScalar
            con.Close()
            cmd = New SqlCommand(String.Format("select MASTER_USERS.*,MASTER_ROLES.RoleName as FullRoleName,BNCH_NAME as FullBranchName from MASTER_USERS left join MASTER_ROLES on MASTER_USERS.USER_TYPE=MASTER_ROLES.RoleID LEFT JOIN BNCH_DETAILS on USER_BRANCH=BNCH_CODE where MASTER_USERS.LOCK_COUNT>={0}", logAttempt), con)
            Dim ds As New DataSet
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "MASTER_USERS")
            If ds.Tables(0).Rows.Count > 0 Then
                grdLockedUsers.DataSource = ds.Tables(0)
            Else
                grdLockedUsers.DataSource = Nothing
            End If
            grdLockedUsers.DataBind()
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- getLockedUsers()", ex.ToString)
        End Try
    End Sub

    Protected Sub getAllUsers()
        Try
            cmd = New SqlCommand("select MASTER_USERS.*,MASTER_ROLES.RoleName as FullRoleName,bd.BNCH_NAME as FullBranchName from MASTER_USERS left join MASTER_ROLES on MASTER_USERS.USER_TYPE=MASTER_ROLES.RoleID left JOIN BNCH_DETAILS bd ON USER_BRANCH=bd.BNCH_CODE", con)
            Dim ds As New DataSet
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "MASTER_USERS")
            bindGrid(ds.Tables(0), grdResetPassword)
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- getLockedUsers()", ex.ToString)
        End Try
    End Sub

    Protected Sub grdLockedUsers_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdLockedUsers.RowCommand
        Try
            If e.CommandName = "Unlock" Then
                Dim uID = e.CommandArgument
                Dim newPass = randomPasswordGenerator()
                'call reset procedure
                Using con = New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                    Using cmd As New SqlCommand("ResetPassword", con)
                        cmd.CommandType = CommandType.StoredProcedure
                        cmd.Parameters.AddWithValue("@userID", uID)
                        cmd.Parameters.AddWithValue("@newPass", newPass)
                        con.Open()
                        If cmd.ExecuteNonQuery Then
                            'send new password to user
                            Dim dr As DataRow
                            dr = getUserRow(uID)
                            If dr IsNot Nothing Then
                                'construct email

                                Dim drSMS = CreditManager.getInternalControls
                                If drSMS("SMSUserAccountUnlocked") Then
                                    ViaNettSMS.messagesend("User Account Unlocked", getUserPhoneNo(dr("USER_LOGIN")), CreditManager.writeTXTMessage(drSMS("SMSUserAccountUnlockedText").ToString, dr("USER_LOGIN"), drSMS("MFICompanyName").ToString))
                                End If
                                Dim baseUrl As String = Request.Url.Scheme & "://" & Request.Url.Authority + Request.ApplicationPath.TrimEnd("/"c) & "/"
                                Dim emailBody As String = ""
                                emailBody += "Hi " + dr("FNAME") + "<br/><br/>"
                                emailBody += "Your Escrow 360 Credit Management account has been unlocked. Your new login credentials are:<br/><br/>"
                                emailBody += "Username: " & dr("USER_LOGIN") & "<br/>"
                                emailBody += "Password: <b>" & newPass & "</b>"
                                emailBody += "<br/><br/>"
                                emailBody += "<a href='" + baseUrl + "Login.aspx'>Click here to login to the system</a><br/><br/>"
                                emailBody += "Regards"
                                Dim SignatoryEMail = dr("USER_EMAIL_ID")
                                Mailhelper.SendMailMessage("administrator", SignatoryEMail, "", "", "Escrow 360 Credit Management System Account Unlocked", emailBody)
                                getLockedUsers()
                            End If
                            notify("User account unlocked", "success")
                        Else
                            notify("Error unlocking account", "error")
                        End If
                        con.Close()
                    End Using
                End Using
            End If
        Catch ex As Exception

        End Try
    End Sub
    Protected Function getUserPhoneNo(userId As String) As String
        Try
            Using con = New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd = New SqlCommand("select [USER_MOB_NO],[USER_PHONE_NO1],[USER_PHONE_NO2] from MASTER_USERS where [USER_LOGIN]=@uID", con)
                    cmd.Parameters.AddWithValue("@uID", userId)
                    Dim dt As New DataTable
                    Using adp = New SqlDataAdapter(cmd)
                        adp.Fill(dt)
                    End Using
                    Dim phone As String = dt.Rows(0).Item("USER_PHONE_NO1")
                    'If IsDBNull(dt.Rows(0).Item("USER_MOB_NO")) Or Trim(dt.Rows(0).Item("USER_MOB_NO")) = "" Then

                    'End If
                    Return phone
                End Using
            End Using
        Catch ex As Exception
            ErrorLogging.WriteLogFile(Session("UserId"), Request.Url.ToString & " --- getUserPhoneNo()", ex.ToString)
            Return ""
        End Try
    End Function
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Page.MaintainScrollPositionOnPostBack = True
            con = New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
            If Not IsPostBack Then
                getLockedUsers()
                getAllUsers()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Private Sub grdResetPassword_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles grdResetPassword.RowCommand
        Try
            If e.CommandName = "Reset" Then
                Dim uID = e.CommandArgument
                Dim newPass = randomPasswordGenerator()
                'call reset procedure
                Using con = New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                    Using cmd As New SqlCommand("ResetPassword", con)
                        cmd.CommandType = CommandType.StoredProcedure
                        cmd.Parameters.AddWithValue("@userID", uID)
                        cmd.Parameters.AddWithValue("@newPass", newPass)
                        con.Open()
                        If cmd.ExecuteNonQuery Then
                            'send new password to user
                            Dim dr As DataRow
                            dr = getUserRow(uID)
                            If dr IsNot Nothing Then
                                'construct email
                                Dim baseUrl As String = Request.Url.Scheme & "://" & Request.Url.Authority + Request.ApplicationPath.TrimEnd("/"c) & "/"
                                Dim emailBody As String = ""
                                emailBody += "Hi " + dr("FNAME") + "<br/><br/>"
                                emailBody += "Your Escrow 360 Credit Management password has been reset. Your new login credentials are:<br/><br/>"
                                emailBody += "Username: " & dr("USER_LOGIN") & "<br/>"
                                emailBody += "Password: <b>" & newPass & "</b>"
                                emailBody += "<br/><br/>"
                                emailBody += "<a href='" + baseUrl + "Login.aspx'>Click here to login to the system</a><br/><br/>"
                                emailBody += "Regards"
                                Dim SignatoryEMail = dr("USER_EMAIL_ID")
                                Mailhelper.SendMailMessage("administrator", SignatoryEMail, "", "", "Escrow 360 Credit Management System Password Reset", emailBody)
                            End If
                            notify("User password reset", "success")
                        Else
                            notify("Error resetting password", "error")
                        End If
                        con.Close()
                    End Using
                End Using
            End If
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- grdResetPassword_RowCommand()", ex.ToString)
        End Try
    End Sub

    Protected Function randomPasswordGenerator() As String
        Try
            Return Web.Security.Membership.GeneratePassword(8, 2)
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Protected Function getUserRow(id As String) As DataRow
        Try
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd As New SqlCommand("select tu.* from MASTER_USERS tu where tu.USERID=@id", con)
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

    Private Sub grdResetPassword_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles grdResetPassword.PageIndexChanging
        grdResetPassword.PageIndex = e.NewPageIndex
        getAllUsers()
    End Sub
End Class