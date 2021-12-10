Imports System.Data
Imports System.Data.SqlClient
Imports CreditManager
Imports ErrorLogging

Partial Class OTPConfirm
    Inherits System.Web.UI.Page

    Private Sub OTPConfirm_Load(sender As Object, e As EventArgs) Handles Me.Load
        Page.MaintainScrollPositionOnPostBack = True
        If Not IsPostBack Then

        End If
    End Sub
    ''''''''''''''''SHOULD NOT NAVIGATE FROM THIS PAGE UNTIL OTP CODE IS VALIDATED... TO REDIRECT TO LOGIN IF OTP NOT VALIDATED WITHIN CERTAIN PERIOD
    Protected Sub btnConfirm_Click(sender As Object, e As EventArgs) Handles btnConfirm.Click
        Try
            Using con = New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd = New SqlCommand("select id from OTPVerification where SessionID=@SessionID and OTP=@OTP", con)
                    cmd.Parameters.AddWithValue("@SessionID", Session("SessionID"))
                    cmd.Parameters.AddWithValue("@OTP", txtConfirm.Value.ToString)
                    Dim dt As New DataTable
                    Using adp As New SqlDataAdapter(cmd)
                        adp.Fill(dt)
                    End Using
                    If dt.Rows.Count > 0 Then
                        'OTP correct
                        Session("OTPConfirmed") = "1"
                        Response.Redirect("index.aspx", False)
                    Else
                        'OTP not correct
                        lblFailed.Visible = True
                    End If
                End Using
            End Using
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- btnConfirm_Click()", ex.ToString)
        End Try
    End Sub
End Class
