Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.Web

Partial Class ChangePassword
    Inherits System.Web.UI.Page
    Dim ConfigurationManager As ConfigurationManager
    Dim cmd As SqlCommand
    Dim con As New SqlConnection
    Dim connection As String
    Dim x As String
    Dim adp As New SqlDataAdapter

    Protected Sub btnChangePwd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnChangePwd.Click
        If IsDBNull(Session("UserID")) Or Trim(Session("UserID")) = "" Then
            msgbox("Please login to change your password")
            Exit Sub
        End If
        cmd = New SqlCommand("select * from MASTER_USERS where USER_LOGIN='" & Session("UserID") & "'", con)
        Dim ds As New DataSet
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "USERS")
        If ds.Tables(0).Rows.Count > 0 Then
            Using con = New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmdAuth = New SqlCommand("UserAuthentication1", con)
                    cmdAuth.CommandType = CommandType.StoredProcedure
                    cmdAuth.Parameters.AddWithValue("@UserName", Session("UserID"))
                    cmdAuth.Parameters.AddWithValue("@Password", txtold.Text)
                    con.Open()
                    x = cmdAuth.ExecuteScalar()
                    con.Close()
                End Using
                If x Is Nothing Then
                    msgbox("Wrong old password")
                Else
                    If txtnew.Text = txtconfirm.Text Then
                        'change password
                        cmd = New SqlCommand("select * from PARA_LOGIN", con)
                        Dim dsPwd As New DataSet
                        adp = New SqlDataAdapter(cmd)
                        adp.Fill(dsPwd, "PARA_LOGIN")
                        Dim minPwdLength = dsPwd.Tables(0).Rows(0).Item("MinimumPasswordLength")
                        If txtnew.Text.Length < minPwdLength Then
                            msgbox("The password you entered is too short. At least " & minPwdLength & " characters are required")
                        Else
                            If txtnew.Text = txtold.Text Then
                                msgbox("You have not changed your old password. Please enter a different password")
                                Exit Sub
                            End If
                            'cmd = New SqlCommand("update MASTER_USERS set USER_PWD='" & txtnew.Text & "',PWD_DATE= getdate() where USER_LOGIN='" & Session("UserID") & "'", con)
                            Using cmdChange = New SqlCommand("ChangePassword", con)
                                cmdChange.CommandType = CommandType.StoredProcedure
                                cmdChange.Parameters.AddWithValue("@LoginName", Session("UserID"))
                                cmdChange.Parameters.AddWithValue("@Password", txtnew.Text)
                                If con.State = ConnectionState.Open Then
                                    con.Close()
                                End If
                                con.Open()
                                If cmdChange.ExecuteNonQuery Then
                                    'msgbox("Password successfully changed")
                                    'enableMenu()
                                    Session("PasswordTooShort") = "False"
                                    Session("DefaultPassword") = "False"
                                    Session("PasswordExpired") = "False"
                                    Response.Write("<script>alert('Password successfully changed') ; location.href='index.aspx'</script>")
                                End If
                                con.Close()
                            End Using
                        End If
                    Else
                        msgbox("The confirmation password does not match you new password")
                    End If
                End If
            End Using
        End If
    End Sub

    Public Sub msgbox(ByVal strMessage As String)

        'finishes server processing, returns to client.
        Dim strScript As String = "<script language=JavaScript>"
        strScript += "window.alert(""" & strMessage & """);"
        strScript += "</script>"
        Dim lbl As New System.Web.UI.WebControls.Label
        lbl.Text = strScript
        Page.Controls.Add(lbl)
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        con = New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
        If Not IsPostBack Then
            If Session("PasswordTooShort") = "True" Then
                disableMenu()
                lblPwdShort.Text = "Your password is too short. Please change it before you proceed"
                lblPwdShort.Visible = True
            ElseIf Session("DefaultPassword") = "True" Then
                disableMenu()
                lblPwdShort.Text = "You are still using the default password. Please change it before you continue"
                lblPwdShort.Visible = True
            ElseIf Session("PasswordExpired") = "True" Then
                disableMenu()
                lblPwdShort.Text = "Your password has expired. Please change it before you continue"
                lblPwdShort.Visible = True
            Else
                enableMenu()
                lblPwdShort.Visible = False
            End If
        End If

    End Sub

    Protected Sub disableMenu()
        Try
            Dim mMenu As New Menu
            mMenu = Master.FindControl("Menu1")
            mMenu.Visible = False
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub enableMenu()
        Try
            Dim mMenu As New Menu
            mMenu = Master.FindControl("Menu1")
            mMenu.Visible = True
        Catch ex As Exception

        End Try
    End Sub
End Class