Imports System.Data
Imports System.Data.SqlClient

Partial Class LoginParameters
    Inherits System.Web.UI.Page
    Const urlPermission As String = "PermissionDenied.aspx"
    Dim adp As New SqlDataAdapter
    Dim cmd As SqlCommand
    Dim con As New SqlConnection
    Dim connection As String
    Dim ds As New DataSet()
    Public Sub msgbox(ByVal strMessage As String)

        'finishes server processing, returns to client.
        Dim strScript As String = "<script language=JavaScript>"
        strScript += String.Format("window.alert(""{0}"");", strMessage)
        strScript += "</script>"
        Dim lbl As New System.Web.UI.WebControls.Label() With {.Text = strScript}
        Page.Controls.Add(lbl)
    End Sub

    Protected Sub btnSaveLoginParameters_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSaveLoginParameters.Click
        cmd = New SqlCommand("select * from PARA_LOGIN", con)
        Dim ds As New DataSet
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "PARA_LOGIN")
        If ds.Tables(0).Rows.Count > 0 Then
            updateLoginParameters()
        Else
            saveLoginParameters()
        End If
    End Sub

    Protected Sub loadLoginParameters()
        Try
            cmd = New SqlCommand("select * from PARA_LOGIN", con)
            Dim ds As New DataSet
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "PARA_LOGIN")
            If ds.Tables(0).Rows.Count > 0 Then
                'bdpUptime.SelectedValue = ds.Tables(0).Rows(0).Item("UPTIME").ToString
                'bdpDowntime.SelectedValue = ds.Tables(0).Rows(0).Item("DOWNTIME").ToString
                txtPasswordExpiry.Text = ds.Tables(0).Rows(0).Item("PasswordExpiryPeriod").ToString
                txtPasswordLength.Text = ds.Tables(0).Rows(0).Item("MinimumPasswordLength").ToString
                chkSpecialCharacters.Checked = ds.Tables(0).Rows(0).Item("AllowSpecialCharacters")
                txtAccessUsers.Text = ds.Tables(0).Rows(0).Item("MaxAccessUsers").ToString
                txtSessionTimeout.Text = ds.Tables(0).Rows(0).Item("SessionTimeout").ToString
                chkUserCaseSensitive.Checked = ds.Tables(0).Rows(0).Item("UseridCaseSensitive")
                txtLoginAttempts.Text = ds.Tables(0).Rows(0).Item("MaximumLoginAttempts").ToString
                txtDomain.Text = ds.Tables(0).Rows(0).Item("DomainName").ToString
                txtDefaultPassword.Text = ds.Tables(0).Rows(0).Item("DefaultPassword").ToString
                Try
                    chkOTP.Checked = ds.Tables(0).Rows(0).Item("SendOTP")
                Catch ex As Exception
                End Try
                Try
                    rdbOTPOption.SelectedValue = ds.Tables(0).Rows(0).Item("OTPOption")
                Catch ex As Exception

                End Try
                Try
                    rdbOTPCharacters.SelectedValue = ds.Tables(0).Rows(0).Item("OTPCharacters")
                Catch ex As Exception

                End Try
                Try
                    txtOTPLength.Text = ds.Tables(0).Rows(0).Item("OTPLength")
                Catch ex As Exception

                End Try
                btnSaveLoginParameters.Text = "Update"
                'Try
                '    cmbDisbOption.SelectedValue = ds.Tables(0).Rows(0).Item("DisbursementOption").ToString
                'Catch ex As Exception
                '    cmbDisbOption.ClearSelection()
                'End Try
            Else
                'bdpUptime.Clear()
                'bdpDowntime.Clear()
                txtPasswordExpiry.Text = ""
                txtPasswordLength.Text = ""
                chkSpecialCharacters.Checked = False
                txtAccessUsers.Text = ""
                txtSessionTimeout.Text = ""
                chkUserCaseSensitive.Checked = False
                txtLoginAttempts.Text = ""
                txtDefaultPassword.Text = ""
                txtDomain.Text = ""
                chkOTP.Checked = False
                rdbOTPOption.ClearSelection()
                btnSaveLoginParameters.Text = "Save"
                'cmbDisbOption.ClearSelection()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Page.MaintainScrollPositionOnPostBack = True
            con = New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
            If Not IsPostBack Then
                loadLoginParameters()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub saveLoginParameters()
        Try
            Dim downTime, pwdExpiry, maxPwdLen, accessUsers, timeout, caseSensitive, loginAttempts, defaultPassword, domain As String
            Dim upTime As String = "" ' bdpUptime.SelectedValue.ToString
            downTime = "" ' bdpDowntime.SelectedValue.ToString
            pwdExpiry = txtPasswordExpiry.Text
            maxPwdLen = txtPasswordLength.Text
            Dim specChrtrs As String = chkSpecialCharacters.Checked
            accessUsers = txtAccessUsers.Text
            timeout = txtSessionTimeout.Text
            caseSensitive = chkUserCaseSensitive.Checked
            loginAttempts = txtLoginAttempts.Text
            defaultPassword = txtDefaultPassword.Text
            domain = txtDomain.Text

            'cmd = New SqlCommand(String.Format("insert into PARA_LOGIN ([DisbursementOption],[UPTIME],[DOWNTIME],[PasswordExpiryPeriod],[MinimumPasswordLength],[AllowSpecialCharacters],[MaxAccessUsers],[SessionTimeout],[UseridCaseSensitive],[MaximumLoginAttempts],[DefaultPassword],[DomainName]) values ('" & cmbDisbOption.SelectedValue & "','{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}','{9}','{10}')", upTime, downTime, pwdExpiry, maxPwdLen, specChrtrs, accessUsers, timeout, caseSensitive, loginAttempts, defaultPassword, domain), con)

            cmd = New SqlCommand(String.Format("insert into PARA_LOGIN ([UPTIME],[DOWNTIME],[PasswordExpiryPeriod],[MinimumPasswordLength],[AllowSpecialCharacters],[MaxAccessUsers],[SessionTimeout],[UseridCaseSensitive],[MaximumLoginAttempts],[DefaultPassword],[DomainName],[SendOTP],[OTPOption],[OTPCharacters],[OTPLength]) values ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}','{9}','{10}','" & chkOTP.Checked & "','" & rdbOTPOption.SelectedValue & "','" & rdbOTPCharacters.SelectedValue & "',nullif('" & txtOTPLength.Text & "',''))", upTime, downTime, pwdExpiry, maxPwdLen, specChrtrs, accessUsers, timeout, caseSensitive, loginAttempts, defaultPassword, domain), con)
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            con.Open()
            If cmd.ExecuteNonQuery Then
                msgbox("Parameters successfully saved")
            End If
            con.Close()
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub updateLoginParameters()
        Try
            Dim downTime, maxPwdLen, accessUsers, timeout, caseSensitive, loginAttempts, defaultPassword, domain As Object
            Dim upTime As Object = "" ' bdpUptime.SelectedValue.ToString
            downTime = "" ' bdpDowntime.SelectedValue.ToString
            Dim pwdExpiry As Object = txtPasswordExpiry.Text
            maxPwdLen = txtPasswordLength.Text
            Dim specChrtrs As Object = chkSpecialCharacters.Checked
            accessUsers = txtAccessUsers.Text
            timeout = txtSessionTimeout.Text
            caseSensitive = chkUserCaseSensitive.Checked
            loginAttempts = txtLoginAttempts.Text
            defaultPassword = txtDefaultPassword.Text
            domain = txtDomain.Text

            'cmd = New SqlCommand(String.Format("update PARA_LOGIN set DisbursementOption='" & cmbDisbOption.SelectedValue & "',[UPTIME]='{0}',[DOWNTIME]= '{1}',[PasswordExpiryPeriod]='{2}',[MinimumPasswordLength]='{3}',[AllowSpecialCharacters]='{4}',[MaxAccessUsers]='{5}',[SessionTimeout]='{6}',[UseridCaseSensitive]='{7}',[MaximumLoginAttempts]='{8}',[DefaultPassword]='{9}',[DomainName]='{10}'", upTime, downTime, pwdExpiry, maxPwdLen, specChrtrs, accessUsers, timeout, caseSensitive, loginAttempts, defaultPassword, domain), con)

            cmd = New SqlCommand(String.Format("update PARA_LOGIN set [UPTIME]='{0}',[DOWNTIME]= '{1}',[PasswordExpiryPeriod]='{2}',[MinimumPasswordLength]='{3}',[AllowSpecialCharacters]='{4}',[MaxAccessUsers]='{5}',[SessionTimeout]='{6}',[UseridCaseSensitive]='{7}',[MaximumLoginAttempts]='{8}',[DefaultPassword]='{9}',[DomainName]='{10}',[SendOTP]='" & chkOTP.Checked & "',[OTPOption]='" & rdbOTPOption.SelectedValue & "',[OTPCharacters]='" & rdbOTPCharacters.SelectedValue & "',[OTPLength]=nullif('" & txtOTPLength.Text & "','')", upTime, downTime, pwdExpiry, maxPwdLen, specChrtrs, accessUsers, timeout, caseSensitive, loginAttempts, defaultPassword, domain), con)

            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            con.Open()
            If cmd.ExecuteNonQuery Then
                msgbox("Parameters successfully updated")
            End If
            con.Close()
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
End Class