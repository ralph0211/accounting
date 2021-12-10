Imports System.Data
Imports System.Data.SqlClient
Imports SecureBank

Partial Class SpecialPermissions
    Inherits System.Web.UI.Page
    'for editing roles grid and users grid
    Public Shared rolesEditID, usersEditID, moduleEditID As String

    Dim adp As New SqlDataAdapter
    Dim cmd As SqlCommand
    Dim con As New SqlConnection
    Dim connection As String
    Dim ds As New DataSet()
    Dim Objclsdb As New CreditManager
    Dim urlPermission As String = "PermissionDenied.aspx"
    Public Sub msgbox(ByVal strMessage As String)

        'finishes server processing, returns to client.
        Dim strScript As String = "<script language=JavaScript>"
        strScript += "window.alert(""" & strMessage & """);"
        strScript += "</script>"
        Dim lbl As New System.Web.UI.WebControls.Label
        lbl.Text = strScript
        Page.Controls.Add(lbl)
    End Sub

    Protected Sub addSpecialPermission(ByVal user As String, ByVal moduleId As String, ByVal sDate As Date, ByVal eDate As Date, ByVal reason As String)
        Try
            cmd = New SqlCommand("insert into SPECIAL_PERMISSIONS (UserID,ModuleID,StartDate,EndDate,Reason,AssignedBy,AssignedDate) values ('" & user & "','" & moduleId & "','" & sDate & "','" & eDate & "','" & BankString.removeSpecialCharacter(reason) & "','" & Session("UserID") & "',GETDATE())", con)
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            con.Open()
            If cmd.ExecuteNonQuery Then
                msgbox("Special permission successfully added")
                recordAction("btnAddSpecPerm", "Added special permission: " & moduleId & " to " & user)
            Else
                msgbox("Error adding special permission")
            End If
            con.Close()
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub btnAddSpecPerm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddSpecPerm.Click
        If isEmptyString(cmbSpecPermUser.Text) Then
            msgbox("Select user")
            cmbSpecPermUser.Focus()
            Exit Sub
        ElseIf isEmptyString(cmbSpecPermModule.SelectedValue.ToString) Then
            msgbox("Select module")
            cmbSpecPermModule.Focus()
            Exit Sub
        ElseIf isEmptyString(bdpStartDate.Text) Then
            msgbox("Select start date")
            bdpStartDate.Focus()
            Exit Sub
        ElseIf isEmptyString(bdpEndDate.Text) Then
            msgbox("Select end date")
            bdpEndDate.Focus()
            Exit Sub
        ElseIf isEmptyString(txtSpecPermReason.Text) Then
            msgbox("Enter reason")
            bdpEndDate.Focus()
            Exit Sub
        End If
        addSpecialPermission(cmbSpecPermUser.Text, cmbSpecPermModule.SelectedValue.ToString, bdpStartDate.Text, bdpEndDate.Text, txtSpecPermReason.Text)
        loadcmbSpecPermModule(cmbSpecPermUser.Text)
        loadSpecPermModules()
    End Sub

    Protected Sub clearAll()
        Try

        Catch ex As Exception

        End Try
    End Sub

    Protected Sub cmbSpecPermUser_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbSpecPermUser.SelectedIndexChanged
        getSpecPermUserNameAndRole()
        loadSpecPermModules()
        loadcmbSpecPermModule(cmbSpecPermUser.Text)
    End Sub

    Protected Function getFullRoleName(ByVal roleID As String) As String
        cmd = New SqlCommand("select RoleName from MASTER_ROLES where RoleID=" & CDbl(roleID) & "", con)
        Dim ds1 As New DataSet
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds1, "MASTER_ROLES")
        Return ds1.Tables(0).Rows(0).Item("RoleName").ToString
    End Function

    Protected Function getRolePermissions(ByVal Role As String, ByVal Permission As String) As Boolean
        Try
            'msgbox(Role & " : " & Permission)
            cmd = New SqlCommand("select ID from MASTER_PERMISSIONS where RoleID='" & Role & "' and ModuleName='" & Permission & "'", con)
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
            msgbox(ex.Message)
        End Try
    End Function

    Protected Function getSpecialPermissions(ByVal User As String, ByVal ModuleID As String) As Boolean
        Try
            'msgbox(Role & " : " & Permission)
            cmd = New SqlCommand("select ID from SPECIAL_PERMISSIONS where UserID='" & User & "' and ModuleID='" & ModuleID & "' and EndDate > getDate() and StartDate < getDate()", con)
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
            msgbox(ex.Message)
        End Try
    End Function

    Protected Sub getSpecPermUserNameAndRole()
        cmd = New SqlCommand("select * from MASTER_USERS where USER_LOGIN='" & cmbSpecPermUser.Text & "'", con)
        Dim ds1 As New DataSet
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds1, "MASTER_USERS")
        lblSpecPermUserName.Text = "Name: " & ds1.Tables(0).Rows(0).Item("FNAME") & " " & ds1.Tables(0).Rows(0).Item("LNAME")
        lblSpecPermUserRole.Text = "Role: " & getFullRoleName(ds1.Tables(0).Rows(0).Item("USER_TYPE"))
    End Sub

    Protected Sub getSpecPermUsers()
        cmd = New SqlCommand("select * from MASTER_USERS", con)
        Dim ds1 As New DataSet
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds1, "MASTER_USERS")
        cmbSpecPermUser.DataSource = ds1.Tables(0)
        cmbSpecPermUser.DataTextField = "USER_LOGIN"
        cmbSpecPermUser.DataValueField = "USER_LOGIN"
        cmbSpecPermUser.DataBind()
    End Sub

    Protected Function getUserRole(ByVal userName As String) As String
        cmd = New SqlCommand("select MASTER_ROLES.RoleID from MASTER_ROLES,MASTER_USERS where MASTER_USERS.USER_TYPE=MASTER_ROLES.RoleID and MASTER_USERS.USER_LOGIN='" & userName & "'", con)
        Dim ds1 As New DataSet
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds1, "MASTER_ROLES")
        Return ds1.Tables(0).Rows(0).Item("RoleID").ToString
    End Function

    Protected Sub grdSpecPermModules_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdSpecPermModules.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim chkView As CheckBox
            chkView = DirectCast(e.Row.FindControl("chkSpecPermView"), CheckBox)
            Dim modName = DirectCast(e.Row.FindControl("lblModuleName"), Label).Text
            Dim modID = DirectCast(e.Row.FindControl("lblModuleID"), Label).Text
            Dim userName = cmbSpecPermUser.SelectedValue.ToString
            Dim roleName = getUserRole(userName)
            chkView.Checked = getRolePermissions(roleName, modName)
            If getRolePermissions(roleName, modName) Then
                chkView.Checked = True
                chkView.Enabled = False
                e.Row.BackColor = Drawing.Color.Azure
            Else
                If getSpecialPermissions(userName, modID) Then
                    chkView.Checked = True
                    e.Row.BackColor = Drawing.Color.Cornsilk
                End If
            End If
        End If
    End Sub

    Protected Function isEmptyString(ByVal str As String) As Boolean
        If IsDBNull(str) Or Trim(str) = "" Then
            Return True
        Else
            Return False
        End If
    End Function

    Protected Sub loadcmbSpecPermModule(ByVal userName As String)
        Try
            cmbSpecPermModule.Items.Clear()
            Dim userRole = getUserRole(userName)
            cmd = New SqlCommand("select MASTER_MODULES.ModuleID, MASTER_MODULES.ModuleName from MASTER_MODULES where (MASTER_MODULES.ModuleID not in (Select MASTER_PERMISSIONS.ModuleID From MASTER_PERMISSIONS where MASTER_PERMISSIONS.RoleId='" & userRole & "') and MASTER_MODULES.ModuleID not in (select SPECIAL_PERMISSIONS.ModuleID from SPECIAL_PERMISSIONS where SPECIAL_PERMISSIONS.UserID='" & userName & "' and SPECIAL_PERMISSIONS.StartDate < GetDate() and SPECIAL_PERMISSIONS.EndDate > GetDate()))", con)
            'msgbox(cmd.CommandText)
            Dim ds1 As New DataSet
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds1, "MASTER_MODULES")
            If ds1.Tables(0).Rows.Count > 0 Then
                cmbSpecPermModule.DataSource = ds1.Tables(0)
                cmbSpecPermModule.DataTextField = "ModuleName"
                cmbSpecPermModule.DataValueField = "ModuleID"
            Else
                cmbSpecPermModule.DataSource = Nothing
            End If
            cmbSpecPermModule.DataBind()
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Page.MaintainScrollPositionOnPostBack = True
            Page.Header.Title = "360 Credit Management: User Management"
            con = New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
            Dim surl As String = HttpContext.Current.Request.Url.AbsoluteUri
            surl = Mid(surl, surl.LastIndexOf("/") + 2)
            If Not IsPostBack Then
                Dim dd_Module As DataTable
                dd_Module = Objclsdb.UserHasPermissionForModule(Session("Role").ToString().Trim(), surl)
                If (dd_Module Is Nothing) Or (dd_Module.Rows.Count <= 0) Then
                    Response.Redirect(urlPermission)
                    'ClientScript.RegisterStartupScript(GetType(Page), "anil", "<script>alert('Permission denied')</script>")
                Else
                    getSpecPermUsers()
                    getSpecPermUserNameAndRole()
                    loadSpecPermModules()
                    loadcmbSpecPermModule(cmbSpecPermUser.Text)
                End If

            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Private Sub loadSpecPermModules()
        Try
            cmd = New SqlCommand("select * from MASTER_MODULES order by ModuleId", con)
            adp = New SqlDataAdapter(cmd)
            Dim ds1 As New DataSet
            ds1.Clear()
            adp.Fill(ds1, "MASTER_MODULES")
            If ds1.Tables(0).Rows.Count > 0 Then
                grdSpecPermModules.DataSource = ds1.Tables(0)
            Else
                grdSpecPermModules.DataSource = Nothing
            End If
            grdSpecPermModules.DataBind()
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
End Class