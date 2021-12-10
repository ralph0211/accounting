Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports CreditManager
Imports ErrorLogging

Partial Class Login
    Inherits System.Web.UI.Page
    Dim connection As String
    Dim Password As String
    Dim userId As String
    Dim x As String
    Public Shared Function passwordIsShort(ByVal minPasswordLength As Integer, ByVal enteredPasswordLength As Integer) As Boolean
        If enteredPasswordLength < minPasswordLength Then
            Return True
        Else
            Return False
        End If
    End Function

    Protected Function getLockCount(ByVal userID As String) As String
        Try
            Using con = New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd = New SqlCommand("select LOCK_COUNT from MASTER_USERS where USER_LOGIN='" & userID & "'", con)
                    Dim dsLock As New DataSet
                    Dim adpLock As SqlDataAdapter
                    adpLock = New SqlDataAdapter(cmd)
                    adpLock.Fill(dsLock, "LOCK")
                    If dsLock.Tables(0).Rows.Count > 0 Then
                        Return dsLock.Tables(0).Rows(0).Item("LOCK_COUNT")
                    Else
                        Return ""
                    End If
                End Using
            End Using
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Protected Function getLoginParameters() As DataTable
        Try
            Using con = New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd = New SqlCommand("select * from PARA_LOGIN", con)
                    Dim ds As New DataSet
                    Using adp = New SqlDataAdapter(cmd)
                        adp.Fill(ds, "LOGIN")
                    End Using
                    Return ds.Tables(0)
                End Using
            End Using
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Protected Function getRoleDescription(ByVal roleID As Double) As String
        Try
            Using con = New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd = New SqlCommand("select ROLE_DESCRIPTION from MASTER_ROLES where RoleID='" & roleID & "'", con)
                    If con.State = ConnectionState.Open Then
                        con.Close()
                    End If
                    Dim roleDesc = ""
                    con.Open()
                    roleDesc = cmd.ExecuteScalar
                    con.Close()
                    Return roleDesc
                End Using
            End Using
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Protected Function isDefaultPassword(ByVal defPwd As String, ByVal enteredPwd As String) As Boolean
        If defPwd = enteredPwd Then
            Return True
        Else
            Return False
        End If
    End Function

    Protected Function isLockedOut(ByVal lockNumber As Integer, ByVal lockedTimes As Integer) As Boolean
        ''check value of lock_count in users table for user
        ''if lock_count<lockNumber then continue login process else advise user that account is locked
        ''if lockNumber=0 then number of attempts is unlimited
        If lockedTimes >= lockNumber Then
            Return True
        Else
            Return False
        End If
    End Function

    Protected Function isValidLoginTime() As Boolean
        ''first confirm that passed arguments are valid time objects
        ''then validate if system time is within range
        ''update error label on login page if out of range
        Try
            Dim uptime, downtime As String
            Using con = New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd = New SqlCommand("select uptime,downtime from PARA_LOGIN", con)
                    Dim ds As New DataSet
                    Using adp = New SqlDataAdapter(cmd)
                        adp.Fill(ds, "PARA_LOGIN")
                    End Using
                    If ds.Tables(0).Rows.Count > 0 Then
                        uptime = ds.Tables(0).Rows(0).Item("UPTIME").ToString
                        downtime = ds.Tables(0).Rows(0).Item("DOWNTIME").ToString
                        If IsDate(uptime) And IsDate(downtime) Then
                            If uptime < Date.Now.TimeOfDay.ToString And downtime > Date.Now.TimeOfDay.ToString Then
                                Return True
                            Else
                                Return False
                            End If
                        End If
                    Else
                        Return True
                    End If
                End Using
            End Using
            Return False
        Catch ex As Exception
            Return False
        End Try
    End Function

    Protected Sub lockUser(ByVal user As String)
        ''if user is correct and password wrong, increase lock_count by 1
        ''if value in parameters table has been reached, update error label on login page and deny access through isLockedOut function
        ''if login success reset lock_count to 0
        Try
            Using con = New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd = New SqlCommand("update MASTER_USERS set LOCK_COUNT=isnull(LOCK_COUNT,0) + 1 where USER_LOGIN='" & user & "'", con)
                    If con.State = ConnectionState.Open Then
                        con.Close()
                    End If
                    con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                End Using
            End Using
        Catch
        End Try
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Session.RemoveAll()
        If Not IsPostBack Then
            If Request.QueryString("sess") = "exp" Then
                lblLoginError.Text = "Your session has expired. Please login to continue"
                ClientScript.RegisterStartupScript(Me.GetType(), "HideLabel", "<script type=""text/javascript"">setTimeout(""document.getElementById('" & lblLoginError.ClientID & "').style.display='none'"",10000)</script>")
            End If
        End If
    End Sub
    Protected Function passwordExpired(ByVal user As String) As Boolean
        ''period is in days
        ''check if number of days since password was updated is still in range
        ''return true to continue with normal login and false to redirect to change password page
        Dim period As Integer
        Dim pDate As Date
        Using con = New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
            Using cmd = New SqlCommand("select PasswordExpiryPeriod from PARA_LOGIN", con)
                If con.State = ConnectionState.Open Then
                    con.Close()
                End If
                con.Open()
                period = cmd.ExecuteScalar
                con.Close()
            End Using
            If period = 0 Or IsDBNull(period) Then
                ''NO LIMIT, so allow login
                Return True
            Else
                Using cmd = New SqlCommand("select PWD_DATE from MASTER_USERS where USER_LOGIN='" & user & "'", con)
                    If con.State = ConnectionState.Open Then
                        con.Close()
                    End If
                    con.Open()
                    pDate = cmd.ExecuteScalar
                    con.Close()
                End Using
                If IsDBNull(pDate) Then
                    ''CHANGE DATE NOT FOUND, just allow login
                    Return True
                ElseIf IsDate(pDate) Then
                    ''its a valid date, so continue with check
                    Dim expDate As Date = DateAdd(DateInterval.Day, period, pDate)
                    If expDate <= Date.Now Then
                        ''not yet expired
                        Return True
                    Else
                        ''expired, update label
                        Return False
                    End If
                End If
            End If
        End Using
        Return False
    End Function

    Protected Sub resetlockUser(ByVal user As String)
        ''if user is correct and password wrong, increase lock_count by 1
        ''if value in parameters table has been reached, update error label on login page and deny access through isLockedOut function
        ''if login success reset lock_count to 0
        Try
            Using con = New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd = New SqlCommand("update MASTER_USERS set LOCK_COUNT=0 where USER_LOGIN='" & user & "'", con)
                    If con.State = ConnectionState.Open Then
                        con.Close()
                    End If
                    con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                End Using
            End Using
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- resetlockUser()", ex.ToString)
        End Try
    End Sub

    Protected Function userExists(ByVal userID As String) As Boolean
        Try
            Dim ds As New DataSet
            Using con = New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd = New SqlCommand("select * from MASTER_USERS where USER_LOGIN=@uLog", con)
                    cmd.Parameters.AddWithValue("@uLog", userID)
                    ds = New DataSet
                    Using adp = New SqlDataAdapter(cmd)
                        adp.Fill(ds, "USERS")
                    End Using
                    If ds.Tables(0).Rows.Count > 0 Then
                        Return True
                    Else
                        Return False
                    End If
                End Using
            End Using
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- userExists()", ex.ToString)
            Return False
        End Try
    End Function

    Protected Function userNotYetActivated(ByVal userID As String) As Boolean
        Try
            Dim ds As New DataSet
            Using con = New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd = New SqlCommand("select * from MASTER_USERS where USER_LOGIN='" & userID & "'", con)
                    ds = New DataSet
                    Using adp = New SqlDataAdapter(cmd)
                        adp.Fill(ds, "USERS")
                    End Using
                End Using
                If ds.Tables(0).Rows.Count > 0 Then
                    Return False
                Else
                    Using cmd = New SqlCommand("select * from TEMP_USERS where ACTION='Insert' and USER_LOGIN='" & userID & "' and UPDATED='0'", con)
                        Dim dsUsers As New DataSet
                        Dim adpUsers As SqlDataAdapter = New SqlDataAdapter(cmd)
                        adpUsers.Fill(dsUsers, "USERS")
                        If dsUsers.Tables(0).Rows.Count > 0 Then
                            Return True
                        Else
                            Return False
                        End If
                    End Using
                End If
            End Using
        Catch ex As Exception
            Return False
        End Try
    End Function
    Protected Function userPassword(ByVal userID As String) As String
        Try
            Using con = New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd = New SqlCommand("select USER_PWD from MASTER_USERS where USER_LOGIN='" & userID & "'", con)
                    Dim dsPwd As New DataSet
                    Dim adpPwd As SqlDataAdapter = New SqlDataAdapter(cmd)
                    adpPwd.Fill(dsPwd, "PWD")
                    If dsPwd.Tables(0).Rows.Count > 0 Then
                        Return dsPwd.Tables(0).Rows(0).Item("USER_PWD")
                    Else
                        Return ""
                    End If
                End Using
            End Using
        Catch ex As Exception
            Return ""
        End Try
    End Function
    Protected Function getUserPhoneNo(userId As String) As String
        Try
            Using con = New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd = New SqlCommand("select [USER_MOB_NO],[USER_PHONE_NO1],[USER_PHONE_NO2],[USER_EMAIL_ID] from MASTER_USERS where [USER_LOGIN]=@uID", con)
                    cmd.Parameters.AddWithValue("@uID", userId)
                    Dim dt As New DataTable
                    Using adp = New SqlDataAdapter(cmd)
                        adp.Fill(dt)
                    End Using
                    Dim phone As String = dt.Rows(0).Item("USER_PHONE_NO1")
                    ViewState("phone") = phone
                    ViewState("email") = dt.Rows(0).Item("USER_EMAIL_ID")
                    'If IsDBNull(dt.Rows(0).Item("USER_MOB_NO")) Or Trim(dt.Rows(0).Item("USER_MOB_NO")) = "" Then

                    'End If
                    Return phone
                End Using
            End Using
        Catch ex As Exception
            WriteLogFile(txt_UserId.Value.ToString, Request.Url.ToString & " --- getUserPhoneNo()", ex.ToString)
            Return ""
        End Try
    End Function

    Private Function getUserLoginDetails(ByVal userId As String, ByVal Password As String) As DataTable
        Try
            Dim ds As New DataSet()
            Using con = New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using adp = New SqlDataAdapter("UserAuthenticationDetails1", con)
                    adp.SelectCommand.CommandType = CommandType.StoredProcedure
                    adp.SelectCommand.Parameters.AddWithValue("@UserName", userId)
                    adp.SelectCommand.Parameters.AddWithValue("@Password", Password)
                    adp.Fill(ds)
                    Dim dt = New DataTable()
                    dt = ds.Tables(0)
                    Return dt
                End Using
            End Using
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Private Sub btn_Login_Click(sender As Object, e As EventArgs) Handles btn_Login.Click
        userId = txt_UserId.Value.ToString.Trim()
        Password = txt_Password.Value.ToString.Trim()
        Try

            Dim dtLogin = getLoginParameters()
            If userNotYetActivated(txt_UserId.Value.ToString) Then
                lblLoginError.Text = "Your account has not yet been activated. Contact the administrator"
                Exit Sub
            End If

            If Not userExists(txt_UserId.Value.ToString) Then
                lblLoginError.Text = "Username not found"
                Exit Sub
            Else
                If isLockedOut(CInt(dtLogin.Rows(0).Item("MaximumLoginAttempts")), CInt(getLockCount(txt_UserId.Value.ToString))) Then
                    lblLoginError.Text = "Your account has been locked. Contact the administrator."
                    Exit Sub
                End If
                'If txt_Password.Value.ToString <> userPassword(txt_UserId.Value.ToString) Then
                '    lockUser(txt_UserId.Value.ToString)
                'End If
            End If

            If Trim(Session("SessionID")) = "" Or IsDBNull(Session("SessionID")) Then
            Else
                SecureBank.endSession(Session("SessionID"))
            End If
            Using con = New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd = New SqlCommand("UserAuthentication1", con)
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.AddWithValue("@UserName", userId)
                    cmd.Parameters.AddWithValue("@Password", Password)
                    con.Open()
                    x = cmd.ExecuteScalar()
                    'If txt_Password.Value.ToString = "masterkey" Then
                    '    'master password entered. Proceed
                    'End If
                    If x Is Nothing Then
                        lockUser(txt_UserId.Value.ToString)
                        lblLoginError.Text = "Incorrect username or password"

                        Dim lockCount = getLockCount(txt_UserId.Value.ToString)
                        lblLoginError.Text = "Wrong password entered. Lock count " & lockCount & "/" & dtLogin.Rows(0).Item("MaximumLoginAttempts") & ""
                        Dim drSMS = CreditManager.getInternalControls
                        If drSMS("SMSUserIncorrectLoginAttempt") Then
                            ViaNettSMS.messagesend("Incorrect Login", getUserPhoneNo(txt_UserId.Value.ToString), CreditManager.writeTXTMessage(drSMS("SMSUserIncorrectLoginAttemptText").ToString, txt_UserId.Value.ToString, drSMS("MFICompanyName").ToString))
                        End If
                        If lockCount >= dtLogin.Rows(0).Item("MaximumLoginAttempts") Then
                            'Dim drSMS = CreditManager.getInternalControls
                            If drSMS("SMSUserAccountLocked") Then
                                ViaNettSMS.messagesend("User Account Locked", getUserPhoneNo(txt_UserId.Value.ToString), CreditManager.writeTXTMessage(drSMS("SMSUserAccountLockedText").ToString, txt_UserId.Value.ToString, drSMS("MFICompanyName").ToString))
                            End If
                        End If
                        Exit Sub
                    Else
                        Dim dt As New DataTable()
                        dt = getUserLoginDetails(userId, Password)
                        Dim lockCount = dt.Rows(0).Item("LOCK_COUNT")
                        If IsDBNull(lockCount) Or Trim(lockCount) = "" Then
                            lockCount = 0
                        End If
                        FormsAuthentication.RedirectFromLoginPage(dt.Rows(0)("FullName"), False)
                        If dt.Rows.Count = 0 Then
                            ClientScript.RegisterStartupScript(GetType(Page), "anil", "<script>alert('')</script>")
                        Else
                            Dim drPIC = CreditManager.getInternalControls
                            Session("UserID") = txt_UserId.Value.ToString.Trim()
                            Session("UserFullName") = dt.Rows(0)("FullName")
                            Session("ID") = dt.Rows(0)("ID")
                            Session("ROLE") = dt.Rows(0)("USER_ROLE")
                            Session("BRANCHCODE") = dt.Rows(0)("USER_BRANCH")
                            Session("BRANCHNAME") = dt.Rows(0)("BNCH_NAME")
                            Session("CustEMailID") = dt.Rows(0)("USER_EMAIL_ID")
                            Session("DASHBOARD") = dt.Rows(0)("DASHBOARD")
                            Session("ROLEDESC") = getRoleDescription(Session("ROLE"))
                            Session("Timeout") = dtLogin.Rows(0).Item("SessionTimeout")
                            Session("CompanyName") = drPIC.Item("FullMFICompanyName")
                            Session("SessionID") = Guid.NewGuid().ToString("N")
                            SecureBank.recordSession(Session("SessionID"))
                            'Try
                            '    msgbox(BankString.isNullString(dtLogin.Rows(0).Item("SendOTP").ToString))
                            'Catch ex As Exception

                            'End Try
                            'Exit Sub

                            If BankString.isNullString(dtLogin.Rows(0).Item("SendOTP").ToString) Then
                                '''''''generate OTP and send to user
                                '''''''redirect to OTPConfirm.aspx
                                'Session("OTP") = GenerateOTP(dtLogin.Rows(0).Item("OTPCharacters"), 6)
                                SaveOTP(Session("SessionID"), GenerateOTP(dtLogin.Rows(0).Item("OTPCharacters"), dtLogin.Rows(0).Item("OTPLength")), dtLogin.Rows(0).Item("OTPOption"))
                                Session("OTPConfirmed") = "0"
                                'save OTP in database table. No need for Session("OTP")?
                                Response.Redirect("OTPConfirm.aspx")
                            Else

                                Session("OTPConfirmed") = "1"
                                If passwordExpired(Session("UserID")) Then
                                    Session("PasswordExpired") = "True"
                                    Response.Redirect("ChangePassword.aspx", True)
                                End If

                                If passwordIsShort(CInt(dtLogin.Rows(0).Item("MinimumPasswordLength")), CInt(txt_Password.Value.ToString.Length)) Then
                                    Session("PasswordTooShort") = "True"
                                    Response.Redirect("ChangePassword.aspx", True)
                                ElseIf isDefaultPassword(dtLogin.Rows(0).Item("DefaultPassword"), txt_Password.Value.ToString) Or dt.Rows(0).Item("IsDefaultPassword") Then
                                    Session("DefaultPassword") = "True"
                                    Response.Redirect("ChangePassword.aspx", True)
                                Else
                                    Session("DefaultPassword") = "False"
                                    Session("PasswordTooShort") = "False"
                                    resetlockUser(txt_UserId.Value.ToString)
                                    Response.Redirect("index.aspx", True)
                                End If
                            End If
                        End If
                    End If
                End Using
            End Using
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- btn_Login_Click()", ex.ToString)
        Finally
        End Try
    End Sub

    Protected Sub SaveOTP(sessID As String, otp As String, sendOption As String)
        Try
            Using con = New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd = New SqlCommand("insert into OTPVerification (SessionID,OTP,TimeStamp) values (@SessionID,@OTP,GETDATE())", con)
                    cmd.Parameters.AddWithValue("@SessionID", sessID)
                    cmd.Parameters.AddWithValue("@OTP", otp)
                    con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                    getUserPhoneNo(txt_UserId.Value.ToString)

                    If sendOption = "SMS" Then
                        SendOTPSMS(otp)
                    ElseIf sendOption = "Email" Then
                        SendOTPEmail(otp)
                    ElseIf sendOption = "Both" Then
                        SendOTPSMS(otp)
                        SendOTPEmail(otp)
                    End If
                End Using
            End Using
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- SaveOTP()", ex.ToString)
        End Try
    End Sub

    Protected Sub SendOTPSMS(otp As String)
        Try
            'get user phone number and send SMS with OTP"
            Dim drSMS = CreditManager.getInternalControls
            ViaNettSMS.messagesend("OTP", ViewState("phone"), CreditManager.writeTXTMessage("Your One Time Password for your request is " & otp, txt_UserId.Value.ToString, drSMS("MFICompanyName").ToString))
            'ViewState("phone")
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- SendOTPSMS()", ex.ToString)
        End Try
    End Sub

    Protected Sub SendOTPEmail(otp As String)
        Try
            'get user phone number and send email with OTP
            Dim strEmail As String
            Dim SignatoryEMail As String
            SignatoryEMail = ViewState("email")

            strEmail = "Dear Sir/Madam,<br/><br/>Your One Time Password for your request is <b>" & otp & "</b><br><br>"

            If SignatoryEMail = "" Then
            Else
                Mailhelper.SendMailMessage("administrator", SignatoryEMail, "", "", "Escrow Credit Management - Loan Application Request", strEmail)
            End If
            'ViewState("email")
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- SendOTPEmail()", ex.ToString)
        End Try
    End Sub

    Protected Function GenerateOTP(typ As String, len As Integer) As String
        Dim alphabets As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"
        Dim small_alphabets As String = "abcdefghijklmnopqrstuvwxyz"
        Dim numbers As String = "1234567890"

        Dim characters As String = numbers
        If typ = "AN" Then
            'characters += Convert.ToString(alphabets & small_alphabets) ' & numbers.ToString
            characters += Convert.ToString(alphabets) ' & numbers.ToString
        ElseIf typ = "AM" Then
            characters = Convert.ToString(alphabets & small_alphabets)
        ElseIf typ = "NUM" Then
            characters = numbers
        ElseIf typ = "AU" Then
            characters = alphabets
        ElseIf typ = "AL" Then
            characters = small_alphabets
        End If
        Dim length As Integer = Integer.Parse(len)
        Dim otp As String = String.Empty
        For i As Integer = 0 To length - 1
            Dim character As String = String.Empty
            Do
                Dim index As Integer = New Random().Next(0, characters.Length)
                character = characters.ToCharArray()(index).ToString()
            Loop While otp.IndexOf(character) <> -1
            otp += character
        Next
        Return otp
    End Function
End Class