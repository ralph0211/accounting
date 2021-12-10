Imports System.Net.Mail
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Net.Mime
Imports System.IO
Imports System.Configuration
Imports System
Imports System.Web

Public Class Mailhelper

    Public Shared Function GetEMailID(ByVal UserID As String) As String
        Try
            Dim con As New SqlConnection
            Dim adp As New SqlDataAdapter
            Dim ds As New DataSet()
            con = New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)

            adp = New SqlDataAdapter("UserEMailDetails", con)
            'adp = New SqlDataAdapter("UserDetails1", con)
            adp.SelectCommand.CommandType = CommandType.StoredProcedure
            adp.SelectCommand.Parameters.AddWithValue("@UserID", UserID)
            'adp.SelectCommand.Parameters.AddWithValue("@Password", Password)
            adp.Fill(ds)
            Dim strEmail As String = ""
            Dim dt = New DataTable()
            dt = ds.Tables(0)
            strEmail = ds.Tables(0).Rows(0).Item(0).ToString
            Return strEmail
        Catch ex As Exception
        End Try
        Return ""
    End Function

    Public Shared Function GetMultiBranchRoleEMailID(ByVal Branch As String, ByVal UserType As String) As String
        Try
            Dim con As New SqlConnection
            Dim adp As New SqlDataAdapter
            Dim ds As New DataSet()
            con = New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)

            adp = New SqlDataAdapter("UserMultiBranchRoleEMailDetails", con)
            'adp = New SqlDataAdapter("UserDetails1", con)
            adp.SelectCommand.CommandType = CommandType.StoredProcedure
            adp.SelectCommand.Parameters.AddWithValue("@UserType", UserType)
            adp.SelectCommand.Parameters.AddWithValue("@Branch", Branch)
            'adp.SelectCommand.Parameters.AddWithValue("@Password", Password)
            adp.Fill(ds)
            Dim strEmail As String = ""
            Dim dt = New DataTable()
            dt = ds.Tables(0)
            If dt.Rows.Count > 0 Then
                For Each row As DataRow In ds.Tables(0).Rows
                    If strEmail = "" Then
                        strEmail = row.Item(0).ToString
                    Else
                        strEmail = strEmail & " " & row.Item(0).ToString
                    End If
                Next

            End If

            Return strEmail
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Public Shared Function GetMultipleEMailID(ByVal UserType As String) As String
        Try
            Dim con As New SqlConnection
            Dim adp As New SqlDataAdapter
            Dim ds As New DataSet()
            con = New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)

            adp = New SqlDataAdapter("UserMultipleEMailDetails", con)
            'adp = New SqlDataAdapter("UserDetails1", con)
            adp.SelectCommand.CommandType = CommandType.StoredProcedure
            adp.SelectCommand.Parameters.AddWithValue("@UserType", UserType)
            'adp.SelectCommand.Parameters.AddWithValue("@Password", Password)
            adp.Fill(ds)
            Dim strEmail As String = ""
            Dim dt = New DataTable()
            dt = ds.Tables(0)
            If dt.Rows.Count > 0 Then
                For Each row As DataRow In ds.Tables(0).Rows
                    If strEmail = "" Then
                        strEmail = row.Item(0).ToString
                    Else
                        strEmail = strEmail & " " & row.Item(0).ToString
                    End If
                Next

            End If

            Return strEmail
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Public Shared Sub SendMailMessage(ByVal FromAddress As String, ByVal ToAddress As String, ByVal bcc As String, ByVal cc As String, ByVal subject As String, ByVal body As String)
        Try
            '
            Dim config As System.Configuration.Configuration = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration(HttpContext.Current.Request.ApplicationPath)
            Dim settings As System.Net.Configuration.MailSettingsSectionGroup = DirectCast(config.GetSectionGroup("system.net/mailSettings"), System.Net.Configuration.MailSettingsSectionGroup)
            Dim Username As String = settings.Smtp.Network.UserName
            Dim Password As String = settings.Smtp.Network.Password
            Dim SmtpAddress As String = settings.Smtp.Network.Host
            Dim PortNumber As String = settings.Smtp.Network.Port

            FromAddress = settings.Smtp.From
            ' Instantiate a new instance of MailMessage

            Dim mMailMessage As New MailMessage()

            'body = body + "<br/><br/><table width=""100%"" border=""0""><tr><td width=""100%"" align=""left"" valign=""middle"">Powered by <a href='http://www.escrowsystems.net'><img src=""cid:MyPictureId"" width=""71"" height=""41""></a></td><td width=""64%"" align=""right"" valign=""bottom"" <font color=""green""><h2></h2></td></tr></table>"
            'body = body + "<br/><br/><p style='font-size:10px; color:gray; text-align: left;padding: 5px;'><span style='vertical-align:top;'>Powered by </span><a href='escrowsystems.net'><img src=""cid:MyPictureId"" width=""71"" height=""41"" style='padding: 0; margin: 0;vertical-align:middle;'/></a></p>"
            body = body + "<br/><br/><p style='font-size:10px; color:gray; text-align: left;padding: 5px;'><span style='background-color: white; vertical-align:top;'>Powered by </span><br/><a href='escrowsystems.net'><img src=""cid:MyPictureId"" width='71' height='41' style='padding: 0; margin: 0;vertical-align:middle;'/></a></p>"

            Dim altView As AlternateView = AlternateView.CreateAlternateViewFromString(body, Nothing, MediaTypeNames.Text.Html)

            Dim myPictureRes As LinkedResource = New LinkedResource(System.Web.HttpContext.Current.Server.MapPath("~/Images/escrow-small.jpg"), MediaTypeNames.Image.Jpeg)
            myPictureRes.ContentId = "MyPictureId"
            altView.LinkedResources.Add(myPictureRes)

            mMailMessage.AlternateViews.Add(altView)

            ' Set the sender address of the mail message
            mMailMessage.From = New MailAddress(FromAddress, "Escrow 360 Credit Management System")

            ''''cater for multiple email, separated by space
            ToAddress = ToAddress.Replace(";", " ")
            Dim cleanToAddress = Trim(ToAddress)
            Dim emailArray() As String
            Dim i As Integer
            If cleanToAddress.Contains(" ") Then
                emailArray = Split(cleanToAddress)
                For i = 0 To emailArray.Length - 1
                    ' Set the recepient address of the mail message
                    mMailMessage.To.Add(New MailAddress(emailArray(i)))
                Next
            Else
                ' Set the recepient address of the mail message
                mMailMessage.To.Add(New MailAddress(cleanToAddress))
            End If

            ' Check if the bcc value is nothing or an empty string
            If Not bcc Is Nothing And bcc <> String.Empty Then
                ' Set the Bcc address of the mail message
                mMailMessage.Bcc.Add(New MailAddress(bcc))
            End If

            ' Check if the cc value is nothing or an empty value
            If Not cc Is Nothing And cc <> String.Empty Then
                ' Set the CC address of the mail message
                mMailMessage.CC.Add(New MailAddress(cc))
            End If

            ' Set the subject of the mail message
            mMailMessage.Subject = subject

            ' Set the body of the mail message
            mMailMessage.Body = body

            ' Set the format of the mail message body as HTML
            mMailMessage.IsBodyHtml = True

            ' Set the priority of the mail message to normal
            mMailMessage.Priority = MailPriority.Normal

            ' Instantiate a new instance of SmtpClient
            Dim mSmtpClient As New SmtpClient(SmtpAddress, PortNumber)
            Dim nc = New System.Net.NetworkCredential(Username, Password)

            mSmtpClient.EnableSsl = True
            mSmtpClient.UseDefaultCredentials = False
            mSmtpClient.Credentials = nc

            ' Send the mail message
            mSmtpClient.Send(mMailMessage)
        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try

    End Sub

    Public Shared Sub SendMailMessageAttach(ByVal FromAddress As String, ByVal ToAddress As String, ByVal bcc As String, ByVal cc As String, ByVal subject As String, ByVal body As String, Optional attcmtPath As String = "")

        Try
            '
            Dim config As System.Configuration.Configuration = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration(HttpContext.Current.Request.ApplicationPath)
            Dim settings As System.Net.Configuration.MailSettingsSectionGroup = DirectCast(config.GetSectionGroup("system.net/mailSettings"), System.Net.Configuration.MailSettingsSectionGroup)

            Dim Username As String = settings.Smtp.Network.UserName
            Dim Password As String = settings.Smtp.Network.Password
            Dim SmtpAddress As String = settings.Smtp.Network.Host
            Dim PortNumber As String = settings.Smtp.Network.Port

            FromAddress = settings.Smtp.From
            ' Instantiate a new instance of MailMessage

            Dim mMailMessage As New MailMessage()

            Dim altView As AlternateView = AlternateView.CreateAlternateViewFromString(body, Nothing, MediaTypeNames.Text.Html)

            Dim yourPictureRes As LinkedResource = New LinkedResource(System.Web.HttpContext.Current.Server.MapPath("~/Images/escrow-small.png"), MediaTypeNames.Image.Jpeg)
            yourPictureRes.ContentId = "YourPictureId"
            altView.LinkedResources.Add(yourPictureRes)

            mMailMessage.AlternateViews.Add(altView)
            ' Set the sender address of the mail message
            mMailMessage.From = New MailAddress(FromAddress, "Escrow Systems")

            ''''cater for multiple email, separated by space
            ToAddress = ToAddress.Replace(";", " ")
            Dim cleanToAddress = Trim(ToAddress)
            Dim emailArray() As String
            Dim i As Integer
            If cleanToAddress.Contains(" ") Then
                emailArray = Split(cleanToAddress)
                For i = 0 To emailArray.Length - 1
                    ' Set the recepient address of the mail message
                    mMailMessage.To.Add(New MailAddress(emailArray(i)))
                Next
            Else
                ' Set the recepient address of the mail message
                mMailMessage.To.Add(New MailAddress(cleanToAddress))
            End If

            ' Check if the bcc value is nothing or an empty string
            If Not bcc Is Nothing And bcc <> String.Empty Then
                ' Set the Bcc address of the mail message
                mMailMessage.Bcc.Add(New MailAddress(bcc))
            End If

            ' Check if the cc value is nothing or an empty value
            If Not cc Is Nothing And cc <> String.Empty Then
                ' Set the CC address of the mail message
                mMailMessage.CC.Add(New MailAddress(cc))
            End If

            ' Set the subject of the mail message
            mMailMessage.Subject = subject

            ' Set the body of the mail message
            mMailMessage.Body = body

            If attcmtPath <> "" Then
                Dim FileName As String = System.IO.Path.GetFileName(attcmtPath)

                Dim fs As System.IO.FileStream = New System.IO.FileStream(attcmtPath, FileMode.Open, FileAccess.Read)
                Dim br As BinaryReader = New BinaryReader(fs)
                Dim bytes As Byte() = br.ReadBytes(Convert.ToInt32(fs.Length))

                Dim ms As MemoryStream = New MemoryStream(bytes)
                Dim attach = New Attachment(ms, FileName)
                mMailMessage.Attachments.Add(attach)

                br.Close()
                fs.Close()
            End If

            ' Set the format of the mail message body as HTML
            mMailMessage.IsBodyHtml = True

            ' Set the priority of the mail message to normal
            mMailMessage.Priority = MailPriority.Normal

            ' Instantiate a new instance of SmtpClient
            Dim mSmtpClient As New SmtpClient(SmtpAddress, PortNumber)
            Dim nc = New System.Net.NetworkCredential(Username, Password)

            mSmtpClient.EnableSsl = True
            mSmtpClient.UseDefaultCredentials = False
            mSmtpClient.Credentials = nc

            ' Send the mail message
            mSmtpClient.Send(mMailMessage)
        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try
    End Sub
End Class