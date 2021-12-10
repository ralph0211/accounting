Imports Microsoft.VisualBasic
Imports System.IO
Imports System.Web

Public Class ErrorLogging

    Public Shared Sub WriteLogFile(ByVal userName As String, pageName As String, ByVal message As String)
        Try
            If message <> "" And message <> "Thread was being aborted." And Not message.Contains("Thread was being aborted") Then
                Using file As New FileStream(HttpContext.Current.Server.MapPath("~/log.txt"), FileMode.Append, FileAccess.Write)
                    Dim streamWriter As New StreamWriter(file)
                    streamWriter.WriteLine((((System.DateTime.Now & " - ") + userName & " - " + pageName & " - ")) + message)
                    streamWriter.Close()
                    Mailhelper.SendMailMessage("administrator", "ralph@escrowgroup.org", "", "", "Escrow 360 Credit Management System Error Logged", userName & "<br/>" & pageName & "<br/>" & message)
                End Using
            End If
        Catch
        End Try
    End Sub

    Public Shared Sub WriteLogFile(message As String)
        Try
            If message <> "" And message <> "Thread was being aborted." And Not message.Contains("Thread was being aborted") Then
                Using file As New FileStream(HttpContext.Current.Server.MapPath("~/log.txt"), FileMode.Append, FileAccess.Write)
                    Dim streamWriter As New StreamWriter(file)
                    streamWriter.WriteLine((((System.DateTime.Now & " - ") + HttpContext.Current.Session("UserId") & " - " + HttpContext.Current.Request.Url.ToString & " - ")) + message)
                    streamWriter.Close()
                    Mailhelper.SendMailMessage("administrator", "ralph@escrowgroup.org", "", "", "Escrow 360 Credit Management System Error Logged", HttpContext.Current.Session("UserId") & "<br/>" & HttpContext.Current.Request.Url.ToString & "<br/>" & message)
                End Using
            End If
        Catch
        End Try
    End Sub
End Class