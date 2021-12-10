Imports Microsoft.VisualBasic
Imports System
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient

Public Class LoginParameters
    Shared cmd As SqlCommand
    Shared con As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
    Shared adp As New SqlDataAdapter
    Shared connection As String

    Public Shared Function hasSpecialPermissions(ByVal mModule As String, ByVal user As String) As Boolean
        ''afer access to certain page has been denied,
        ''check if permissions are in special_permissions table
        ''and still valid
        Try
            cmd = New SqlCommand("select ID from SPECIAL_PERMISSIONS where UserID='" & user & "' and ModuleID='" & mModule & "' and EndDate > getDate() and StartDate < getDate()", con)
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            con.Open()
            If cmd.ExecuteScalar Then
                Return True
            Else
                Return False
            End If
            con.Close()
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Shared Function isValidLoginTime() As Boolean
        ''first confirm that passed arguments are valid time objects
        ''then validate if system time is within range
        ''update error label on login page if out of range
        Try
            Dim uptime, downtime As String
            cmd = New SqlCommand("select uptime,downtime from PARA_LOGIN", con)
            Dim ds As New DataSet
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "PARA_LOGIN")
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
            Return False
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Shared Function maxUsersNotReached(ByVal maxUser As Integer) As Boolean
        ''check number of currently logged in users and compare against maxUser
        ''update error label if maxUsers already reached
        ''return true to continue login and false to deny access(same for all functions)
        ''if maxUser=0 then unlimited
    End Function

    Public Shared Function passwordExpired(ByVal user As String) As Boolean
        ''period is in days
        ''check if number of days since password was updated is still in range
        ''return true to continue with normal login and false to redirect to change password page
        Dim period As Integer
        Dim pDate As Date
        cmd = New SqlCommand("select PasswordExpiryPeriod from PARA_LOGIN", con)
        If con.State = ConnectionState.Open Then
            con.Close()
        End If
        con.Open()
        period = cmd.ExecuteScalar
        con.Close()
        If period = 0 Or IsDBNull(period) Then
            ''NO LIMIT, so allow login
            Return True
        Else
            cmd = New SqlCommand("select PWD_DATE from MASTER_USERS where USER_LOGIN='" & user & "'", con)
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            con.Open()
            pDate = cmd.ExecuteScalar
            con.Close()
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
        Return False
    End Function

    Public Shared Sub lockUser(ByVal user As String)
        ''if user is correct and password wrong, increase lock_count by 1
        ''if value in parameters table has been reached, update error label on login page and deny access through isLockedOut function
        ''if login success reset lock_count to 0
        Try
            cmd = New SqlCommand("update MASTER_USERS set LOCK_COUNT=isnull(LOCK_COUNT,0) + 1 where USER_LOGIN='" & user & "'", con)
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Catch
        End Try
    End Sub

    Public Shared Sub resetlockUser(ByVal user As String)
        ''if user is correct and password wrong, increase lock_count by 1
        ''if value in parameters table has been reached, update error label on login page and deny access through isLockedOut function
        ''if login success reset lock_count to 0
        Try
            cmd = New SqlCommand("update MASTER_USERS set LOCK_COUNT=0 where USER_LOGIN='" & user & "'", con)
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Catch
        End Try
    End Sub

    Public Shared Function getLockCount(ByVal userID As String) As String
        Try
            cmd = New SqlCommand("select LOCK_COUNT from MASTER_USERS where USER_LOGIN='" & userID & "'", con)
            Dim dsLock As New DataSet
            Dim adpLock As SqlDataAdapter
            adpLock = New SqlDataAdapter(cmd)
            adpLock.Fill(dsLock, "LOCK")
            If dsLock.Tables(0).Rows.Count > 0 Then
                Return dsLock.Tables(0).Rows(0).Item("LOCK_COUNT")
            Else
                Return ""
            End If
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Public Shared Function userPassword(ByVal userID As String) As String
        Try
            cmd = New SqlCommand("select USER_PWD from MASTER_USERS where USER_LOGIN='" & userID & "'", con)
            Dim dsPwd As New DataSet
            Dim adpPwd As SqlDataAdapter
            adpPwd = New SqlDataAdapter(cmd)
            adpPwd.Fill(dsPwd, "PWD")
            If dsPwd.Tables(0).Rows.Count > 0 Then
                Return dsPwd.Tables(0).Rows(0).Item("USER_PWD")
            Else
                Return ""
            End If
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Public Shared Function isLockedOut(ByVal lockNumber As Integer, ByVal lockedTimes As Integer) As Boolean
        ''check value of lock_count in users table for user
        ''if lock_count<lockNumber then continue login process else advise user that account is locked
        ''if lockNumber=0 then number of attempts is unlimited
        If lockedTimes >= lockNumber Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Shared Function userExists(ByVal userID As String) As Boolean
        Try
            cmd = New SqlCommand("select * from MASTER_USERS where USER_LOGIN='" & userID & "'", con)
            Dim ds = New DataSet
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "USERS")
            If ds.Tables(0).Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Shared Function userNotYetActivated(ByVal userID As String) As Boolean
        Try
            cmd = New SqlCommand("select * from MASTER_USERS where USER_LOGIN='" & userID & "'", con)
            Dim ds = New DataSet
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "USERS")
            If ds.Tables(0).Rows.Count > 0 Then
                Return False
            Else
                cmd = New SqlCommand("select * from TEMP_USERS where ACTION='Insert' and USER_LOGIN='" & userID & "' and UPDATED='0'", con)
                Dim dsUsers As New DataSet
                Dim adpUsers As SqlDataAdapter = New SqlDataAdapter(cmd)
                adpUsers.Fill(dsUsers, "USERS")
                If dsUsers.Tables(0).Rows.Count > 0 Then
                    Return True
                Else
                    Return False
                End If
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Shared Function passwordIsShort(ByVal minPasswordLength As Integer, ByVal enteredPasswordLength As Integer) As Boolean
        If enteredPasswordLength < minPasswordLength Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Shared Function isDefaultPassword(ByVal defPwd As String, ByVal enteredPwd As String) As Boolean
        If defPwd = enteredPwd Then
            Return True
        Else
            Return False
        End If
    End Function
End Class