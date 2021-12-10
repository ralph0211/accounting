Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient

Partial Class Site2
    Inherits System.Web.UI.MasterPage
    Dim adp As New SqlDataAdapter
    Dim cmd As SqlCommand
    Dim con As New SqlConnection
    Dim connection As String
    Dim Objclsdb As New CreditManager
    Dim urlPermission As String = "~/PermissionDenied.aspx"

    Public Function GetModuleDetails(ByVal RoleID As String) As DataSet
        Dim adp As New SqlDataAdapter
        Dim ds As New DataSet()
        Dim con As New SqlConnection
        con = New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)

        Try
            adp = New SqlDataAdapter("GetModuleDetails_BYROLE", con)
            adp.SelectCommand.CommandType = CommandType.StoredProcedure
            adp.SelectCommand.Parameters.AddWithValue("@ROLEID", RoleID)
            adp.Fill(ds)
            Return ds
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Sub LoanMenus()
        Dim ds As New DataSet
        Dim dt As New DataTable
        Dim i As Integer
        Dim ModName As String
        Dim ModURL As String
        Dim RoleID As String = Session("ROLE")
        Dim sUser As String = Session("UserID")
        If RoleID = "" Or LCase(sUser) = "admin" Then
        Else

            If Not Page.IsPostBack Then

                ds = GetModuleDetails(RoleID)
                Dim hom As New MenuItem
                hom.Text = "Home"
                hom.NavigateUrl = "~/Credit/NewDashboard.aspx"
                Menu1.Items.Add(hom)

                If ds.Tables(0).Rows.Count > 0 Then
                    For i = 0 To ds.Tables(0).Rows.Count - 1
                        'Dim home As MenuItem()
                        ModName = ds.Tables(0).Rows(i).Item(3).ToString()
                        ModURL = "~/" & ds.Tables(0).Rows(i).Item(4).ToString

                        Dim party As New MenuItem()
                        party.Text = ModName
                        party.NavigateUrl = ModURL
                        Menu1.Items.Add(party)

                    Next
                    'Menu1.Items.AddAt(0, hom)
                End If
            End If
        End If
    End Sub

    Public Sub PopulateMenu()
        Try
            Dim dt As DataTable = getPermissions(Session("ID").ToString(), Session("ROLE").ToString())
            'dt = dt.OrderBy("ORDERING")
            If dt.Rows.Count > 0 Then
                Dim categories = (From dr As DataRow In dt.Rows
                                  Select CStr(dr("CATEGORY"))).Distinct()

                Menu1.Items.Clear()
                For Each category As String In categories
                    Dim MasterItem As New MenuItem(category)
                    Menu1.Items.Add(MasterItem)
                    For Each dr As DataRow In dt.Rows
                        If dr("CATEGORY").ToString() = category Then
                            Dim subMenuItem As New MenuItem(CStr(dr("ModuleName")), "", "", "~/" & CStr(dr("URL_NAME")))
                            MasterItem.ChildItems.Add(subMenuItem)
                            Dim url As String = Request.Url.GetLeftPart(UriPartial.Path).Trim()
                            Dim navURL As String = subMenuItem.NavigateUrl.Trim()
                            If url = navURL Then
                                subMenuItem.Selected = True
                            End If
                        End If
                    Next dr
                Next category

            End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub checkSessionTimeout(ByVal tSpan As TimeSpan)
        Try
            'If Not IsDBNull(Session("SessionID")) Then
            If tSpan.Minutes < HttpContext.Current.Session("Timeout") Then
            Else
                SecureBank.endSession(Session("SessionID"))
                Dim url = HttpContext.Current.Request.Url.AbsoluteUri
                If url.Contains("Login.aspx") Then
                    'hid_Ticker.Value = New TimeSpan(0, 0, 0).ToString
                    'lit_Timer.Text = ""
                Else
                    HttpContext.Current.Response.Redirect("Login.aspx")
                    Dim someScript As String = ""
                    someScript = "<script language='text/javascript'>alert('Called from CodeBehind');</script>"
                    ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), Guid.NewGuid().ToString(), someScript, True)
                End If

            End If

            'End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub getBreadCrumb()
        'Dim urlArr As Array
        'Dim url = HttpContext.Current.Request.Url.AbsoluteUri
        'urlArr = Split(url, "/")
        'url = urlArr(urlArr.Length - 1)

        Dim surl As String = HttpContext.Current.Request.Url.AbsoluteUri
        Dim baseUrl As String = Request.Url.Scheme & "://" & Request.Url.Authority + Request.ApplicationPath.TrimEnd("/"c) & "/"
        surl = surl.Replace(baseUrl, "")

        Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
            Using cmd = New SqlCommand("select mmc.CATEGORY,mm.ModuleName from MASTER_MODULE_CATEGORIES mmc join MASTER_MODULES mm on mmc.ID=mm.MODULE_CATEGORY where URL_NAME = '" & surl & "' or URL_NAME = '" & surl & ".aspx'", con)
                Dim ds As New DataSet
                Using adp = New SqlDataAdapter(cmd)
                    adp.Fill(ds, "MM")
                End Using
                If ds.Tables(0).Rows.Count > 0 Then
                    lblBreadCrumb.Text = "You are here >> " + ds.Tables(0).Rows(0).Item("CATEGORY") + " > " + ds.Tables(0).Rows(0).Item("ModuleName")
                Else
                    lblBreadCrumb.Text = ""
                End If
            End Using
        End Using
    End Sub

    Protected Function getPermissions(ByVal user_id As String, ByVal user_role As String) As DataTable
        Try
            Dim strConnString As String = ConfigurationManager.ConnectionStrings("Constring").ConnectionString
            Using con As New SqlConnection(strConnString)
                'string query = "INSERT INTO entity_types(description,active) values ('" + CreditRatingClass.removeSpecialCharacter(txtEntityType.Text) + "','1')";
                Dim query As String = "sp_getPermissions"
                Dim cmd As New SqlCommand(query)
                cmd.Connection = con
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("@userID", user_id)
                cmd.Parameters.AddWithValue("@userRole", user_role)
                Dim dt As New DataTable()
                If con.State = ConnectionState.Open Then
                    con.Close()
                End If
                con.Open()
                dt.Load(cmd.ExecuteReader())
                con.Close()

                If dt.Rows.Count > 0 Then
                    Return dt
                Else
                    Return Nothing
                End If
            End Using
        Catch ex As Exception

        End Try
    End Function

    'Protected Sub Timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer1.Tick
    '    hid_Ticker.Value = TimeSpan.Parse(hid_Ticker.Value).Add(New TimeSpan(0, 0, 1)).ToString()
    '    lit_Timer.Text = "Time spent on this page: " + hid_Ticker.Value.ToString() + HttpContext.Current.Session("Timeout")
    '    ''checkSessionTimeout(TimeSpan.Parse(hid_Ticker.Value))
    'End Sub
    Protected Sub LoginStatus2_LoggingOut(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.LoginCancelEventArgs) Handles LoginStatus2.LoggingOut
        SecureBank.endSession(Session("SessionID"))
    End Sub

    Protected Sub mainMenu_MenuItemDataBound(ByVal sender As Object, ByVal e As MenuEventArgs)
        Dim menuitem As MenuItem = CType(e.Item, MenuItem)
        Dim url As String = Request.Url.GetLeftPart(UriPartial.Path).Trim()
        Dim navURL As String = menuitem.NavigateUrl.Trim()
        If url = navURL Then
            menuitem.Selected = True
        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (Trim(Session("SessionID")) = "" Or IsDBNull(Session("SessionID"))) Then
            SecureBank.endSession(lblSessionID.Text)
            Response.Redirect("~/Login.aspx?sess=exp", True)
        End If
        If Session("OTPConfirmed") = "0" Then
            Response.Redirect("~/OTPConfirm.aspx", True)
        ElseIf Session("PasswordExpired") = "True" Or Session("PasswordTooShort") = "True" Or Session("DefaultPassword") = "True" Then
            Response.Redirect("~/ChangePassword.aspx", True)
        Else
            con = New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
            If lblSessionID.Text = "" Then
                lblSessionID.Text = Session("SessionID")
            End If
            If Not IsPostBack And (Trim(Session("SessionID")) <> "" Or IsDBNull(Session("SessionID"))) Then
                Dim surl As String = HttpContext.Current.Request.Url.AbsoluteUri
                Dim baseUrl As String = Request.Url.Scheme & "://" & Request.Url.Authority + Request.ApplicationPath.TrimEnd("/"c) & "/"
                surl = surl.Replace(baseUrl, "") ' Mid(surl, surl.LastIndexOf("/") + 2)
                'ErrorLogging.WriteLogFile(surl, Session("Role"), baseUrl)
                Dim dd_Module As DataTable
                dd_Module = Objclsdb.UserHasPermissionForModule(Session("Role").ToString().Trim(), surl)
                If (dd_Module Is Nothing) Or (dd_Module.Rows.Count <= 0) Then
                    Response.Redirect(urlPermission)
                Else
                    PopulateMenu()
                    getBreadCrumb()

                    If Trim(Session("PageViewID")) = "" Or IsDBNull(Session("PageViewID")) Then
                        Session("PageViewID") = 1
                    Else
                        Session("PageViewID") = Session("PageViewID") + 1
                    End If
                    SecureBank.recordPageView(Session("SesssionID"))
                End If
            End If
        End If

    End Sub
End Class