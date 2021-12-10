'-------------------------------------------------------------------------------------------
' Updated: 29.10.2009
' This source code can only be used and altered together with ViaNett's SMS system.
'
' Requirements:
' You need to have a ViaNett SMS account.
' Register at: http://sms.vianett.com/cat/485.aspx
' You need to add System.Web as a reference.
'
' Support: smssupport@vianett.no.
'-------------------------------------------------------------------------------------------

Option Strict On
Imports System.Web
Imports System.Net
Imports System.Data.SqlClient
Imports System
Imports System.Configuration

''' <summary>
''' ViaNett SMS class provides an easy way of sending SMS messages through the HTTP API.
''' </summary>
Public Class ViaNettSMS
    Dim username As String
    Dim password As String

    ''' <summary>
    ''' Constructor with username and password to ViaNett gateway.
    ''' </summary>
    Public Sub New(ByVal username As String, ByVal password As String)
        Me.username = username
        Me.password = password
    End Sub

    Public Shared Function messagesend(mType As String, mobile As String, message As String) As String
        Dim client As New Net.WebClient
        Dim comp As String = CreditManager.getInternalControls("MFICompanyName").ToString
        Dim pn As New libphonenumber.PhoneNumber
        pn = libphonenumber.PhoneNumberUtil.Instance.Parse(mobile, "ZW")
        mobile = pn.Format(libphonenumber.PhoneNumberUtil.PhoneNumberFormat.INTERNATIONAL).Replace(" ", "").Replace("+", "")
        Dim resp As String = client.DownloadString("http://etext.co.zw/sendsms.php?user=263773360785&password=simbaj80&mobile=" + HttpUtility.UrlEncode(mobile.ToString) + "&senderid=" + HttpUtility.UrlEncode(comp) + "&message=" + HttpUtility.UrlEncode(message) + "")
        'client.DownloadString("http://etext.co.zw/sendsms.php?user=263773360785&password=simbaj80&mobile=" + HttpUtility.UrlEncode(mobile.ToString) + "&senderid=" + HttpUtility.UrlEncode(comp) + "&message=" + HttpUtility.UrlEncode(message) + "")
        LogMessages(mType, comp, mobile, message, resp)
        'ErrorLogging.WriteLogFile("http://etext.co.zw/sendsms.php?user=263773360785&password=simbaj80&mobile=" + HttpUtility.UrlEncode(mobile.ToString.Replace("+", "")) + "&senderid=" + HttpUtility.UrlEncode(comp) + "&message=" + HttpUtility.UrlEncode(message) + "")
        Return "Success"
    End Function

    Public Shared Sub LogMessages(msgType As String, sender As String, phoneNo As String, msgText As String, msgResponse As String)
        Try
            Using con As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd As New SqlCommand("insert into MessagesLog (MsgType,Sender,PhoneNo,MsgText,MsgResponse,SendTime) values (@MsgType,@Sender,@PhoneNo,@MsgText,@MsgResponse,GETDATE())", con)
                    cmd.Parameters.AddWithValue("@MsgType", msgType)
                    cmd.Parameters.AddWithValue("@Sender", sender)
                    cmd.Parameters.AddWithValue("@PhoneNo", phoneNo)
                    cmd.Parameters.AddWithValue("@MsgText", msgText)
                    cmd.Parameters.AddWithValue("@MsgResponse", msgResponse)
                    con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                End Using
            End Using
        Catch ex As Exception
            ErrorLogging.WriteLogFile(ex.ToString)
        End Try
    End Sub

    Public Shared Sub sendTXT(phoneNo As String, msg As String)
        Dim s As New ViaNettSMS(username:="clivetaps@gmail.com", password:="bt40b")
        Dim result As ViaNettSMS.Result
        ' Try
        'result = s.SendSMS(msgsender:="MH Sacco", destinationaddr:=txtPhoneNo.Text, message:="Dear " + txtSurname.Text + " " + txtForenames.Text + ",your new MH Sacco account number is " + txtCustNo.Text + ". Total Savings Received  " + txtinitial.Text + ". Total Shares Value=" + txtsharesvalue.Text + "")
        Dim comp As String = CreditManager.getInternalControls("MFICompanyName").ToString
        result = s.SendSMS(msgsender:=comp, destinationaddr:=phoneNo, message:=msg + "")

        If result.Success Then
            'CreditManager.notify("Message successfully sent", "success")
        Else
            'CreditManager.notify("Received error: " & result.ErrorCode & " " & result.ErrorMessage, "error")
        End If
    End Sub

    ''' <summary>
    ''' Send SMS message through the ViaNett HTTP API.
    ''' </summary>
    ''' <returns>Returns an object with the following parameters: Success, ErrorCode, ErrorMessage</returns>
    ''' <param name="msgsender">Message sender address. Mobile number or small text, e.g. company name</param>
    ''' <param name="destinationaddr">Message destination address. Mobile number.</param>
    ''' <param name="message">Text message</param>
    Public Function SendSMS(ByVal msgsender As String,
                            ByVal destinationaddr As String,
                            ByVal message As String) As Result

        'Declarations
        Dim url, serverResult As String, l As Long, result As Result

        'Build the URL request for sending SMS.
        url = "http://smsc.vianett.no/ActiveServer/MT/?" &
        "username=" & HttpUtility.UrlEncode(username) &
        "&password=" & HttpUtility.UrlEncode(password) &
        "&destinationaddr=" & HttpUtility.UrlEncode(destinationaddr) &
        "&message=" & HttpUtility.UrlEncode(message) &
        "&refno=1" ' refno is required

        'Check if the message sender is numeric or alphanumeric.
        If Long.TryParse(msgsender, l) Then
            url = url & "&sourceAddr=" & msgsender
        Else
            url = url & "&fromAlpha=" & msgsender
        End If
        'CreditManager.msgbox(url)
        'Send the SMS by submitting the URL request to the server. The response is saved as an XML string.
        serverResult = DownloadString(url)
        'Converts the XML response from the server into a more structured Result object.
        result = ParseServerResult(serverResult)
        'Return the Result object.
        Return result
    End Function
    ''' <summary>
    ''' Downloads the URL from the server, and returns the response as string.
    ''' </summary>
    ''' <param name="URL"></param>
    ''' <returns>Returns the http/xml response as string</returns>
    ''' <exception cref="WebException">WebException is thrown if there is a connection problem.</exception>
    Private Function DownloadString(ByVal URL As String) As String
        'Create WebClient instanse.
        Using wlc As New System.Net.WebClient
            Try
                'Download and return the xml response
                Return wlc.DownloadString(URL)
            Catch ex As WebException
                'Failed to connect to server. Throw an exception with a customized text.
                Throw New WebException("Error occurred while connecting to server. " & ex.Message, ex)
            End Try
        End Using
    End Function

    ''' <summary>
    ''' Parses the XML code and returns a Result object.
    ''' </summary>
    ''' <param name="ServerResult">XML data from a request through HTTP API.</param>
    ''' <returns>Returns a Result object with the parsed data.</returns>
    Private Function ParseServerResult(ByVal ServerResult As String) As Result
        Dim xDoc As New System.Xml.XmlDocument()
        Dim ack As System.Xml.XmlNode
        Dim result As New Result

        xDoc.LoadXml(ServerResult)
        ack = xDoc.GetElementsByTagName("ack").Item(0)

        result.ErrorCode = CInt(ack.Attributes("errorcode").Value)
        result.ErrorMessage = ack.InnerText
        result.Success = (result.ErrorCode = 0)
        Return result
    End Function

    ''' <summary>
    ''' The Result object from the SendSMS function, which returns Success(Boolean), ErrorCode(Integer), ErrorMessage(String).
    ''' </summary>
    Public Class Result
        Public Success As Boolean
        Public ErrorCode As Integer
        Public ErrorMessage As String
    End Class
End Class