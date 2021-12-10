Imports Microsoft.VisualBasic
Imports System
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports System.Web

Public Class SecureBank
    Shared cmd As SqlCommand
    Shared con As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
    Shared adp As New SqlDataAdapter
    Shared IPAdd, machName, browser, url, user, pageViewID As String
    Shared actionTime As Date

    Shared Sub recordAction(ByVal button As String, ByVal action As String)
        Try
            'actionTime = DateFormat.getSaveDateTime(HttpContext.Current.Timestamp)
            IPAdd = HttpContext.Current.Request.UserHostAddress
            machName = HttpContext.Current.Request.UserHostName 'System.Environment.MachineName
            browser = HttpContext.Current.Request.UserAgent
            url = HttpContext.Current.Request.Url.AbsoluteUri
            user = HttpContext.Current.Session("USERID")
            pageViewID = HttpContext.Current.Session("PageViewID")

            'cmd = New SqlCommand("insert into SECURITY_LOG (SESSION_ID,USERID,CLIENT_IP_ADDRESS,CLIENT_MACH_NAME,PAGE,BUTTON,ACTION,ACTION_DATE,BROWSER) values ('" & HttpContext.Current.Session("SessionID") & "','" & user & "','" & IPAdd & "','" & machName & "','" & url & "','" & button & "','" & action & "','" & actionTime & "','" & browser & "')", con)
            cmd = New SqlCommand("insert into SECURITY_LOG (SESSION_ID,USERID,CLIENT_IP_ADDRESS,CLIENT_MACH_NAME,PAGE,BUTTON,ACTION,ACTION_DATE,BROWSER,PAGE_VIEW_ID) values ('" & HttpContext.Current.Session("SessionID") & "','" & user & "','" & IPAdd & "','" & machName & "','" & url & "','" & button & "','" & BankString.removeSpecialCharacter(action) & "',getdate(),'" & browser & "','" & pageViewID & "')", con)

            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception

        End Try
    End Sub

    Shared Sub recordSession(ByVal sessionID As String)
        Try
            actionTime = HttpContext.Current.Timestamp
            IPAdd = HttpContext.Current.Request.UserHostAddress
            machName = HttpContext.Current.Request.UserHostName 'System.Environment.MachineName
            browser = HttpContext.Current.Request.UserAgent
            user = HttpContext.Current.Session("USERID")

            'cmd = New SqlCommand("insert into SESSION_LOG (SESSION_ID,START_TIME,USERID,IP_ADDRESS,MACHINE_NAME) values ('" & sessionID & "','" & actionTime & "','" & user & "','" & IPAdd & "','" & machName & "')", con)
            cmd = New SqlCommand("insert into SESSION_LOG (SESSION_ID,START_TIME,USERID,IP_ADDRESS,MACHINE_NAME,BROWSER) values ('" & sessionID & "',getdate(),'" & user & "','" & IPAdd & "','" & machName & "','" & browser & "')", con)
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception

        End Try
    End Sub

    Shared Sub recordPageView(ByVal sessionID As String)
        Try
            Dim urlArr As Array
            actionTime = HttpContext.Current.Timestamp
            IPAdd = HttpContext.Current.Request.UserHostAddress
            machName = HttpContext.Current.Request.UserHostName 'System.Environment.MachineName
            browser = HttpContext.Current.Request.UserAgent
            url = HttpContext.Current.Request.Url.AbsoluteUri
            urlArr = Split(url, "/")
            url = urlArr(urlArr.Length - 1)
            user = HttpContext.Current.Session("USERID")
            sessionID = HttpContext.Current.Session("sessionID")
            pageViewID = HttpContext.Current.Session("PageViewID")

            Dim modName As String = ""

            cmd = New SqlCommand("select ModuleName from MASTER_MODULES where URL_NAME like '%" & url & "'", con)
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            con.Open()
            modName = cmd.ExecuteScalar
            con.Close()

            'cmd = New SqlCommand("insert into SESSION_LOG (SESSION_ID,START_TIME,USERID,IP_ADDRESS,MACHINE_NAME) values ('" & sessionID & "','" & actionTime & "','" & user & "','" & IPAdd & "','" & machName & "')", con)
            cmd = New SqlCommand("insert into PAGES_LOG (SESSION_ID,USERID,CLIENT_IP_ADDRESS,CLIENT_MACH_NAME,PAGE_URL,PAGE_NAME,ACTION,ACTION_DATE,BROWSER,PAGE_VIEW_ID) values ('" & sessionID & "','" & user & "','" & IPAdd & "','" & machName & "','" & url & "','" & BankString.removeSpecialCharacter(modName) & "','View',getdate(),'" & browser & "','" & pageViewID & "')", con)
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception

        End Try
    End Sub

    Shared Sub endSession(ByVal sessionID As String)
        Try
            'cmd = New SqlCommand("update SESSION_LOG set END_TIME='" & HttpContext.Current.Timestamp & "' where SESSION_ID='" & sessionID & "'", con)
            cmd = New SqlCommand("update SESSION_LOG set END_TIME=getdate() where SESSION_ID='" & sessionID & "'", con)
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
            HttpContext.Current.Session.Clear()
        Catch ex As Exception

        End Try
    End Sub
End Class