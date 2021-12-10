Imports System.Data
Imports System.Data.SqlClient
Imports SecureBank
Imports CreditManager
Imports ErrorLogging

Partial Class Modules
    Inherits System.Web.UI.Page

    Public Sub FillListView(ByRef lvList As ListBox, ByRef myData As SqlDataReader)
        Dim itmListItem As ListBox
        Dim strValue As String
        Do While myData.Read
            itmListItem = New ListBox()
            strValue = IIf(myData.IsDBNull(0), "", myData.GetValue(0))
            itmListItem.Text = strValue
            For shtCntr = 1 To myData.FieldCount() - 1
                If myData.IsDBNull(shtCntr) Then
                    itmListItem.Items.Add("")
                Else
                    itmListItem.Items.Add(myData.GetValue(shtCntr))
                End If
            Next shtCntr
        Loop
    End Sub

    Protected Sub btnSaveModule_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSaveModule.Click
        Try
            Dim moduleName = txtModuleName.Text
            Dim url = txtURL.Text
            If cmbModuleCategory.SelectedValue = "" Then
                notify("Select module category", "error")
                cmbModuleCategory.Focus()
                Exit Sub
            End If
            If isEmptyString(moduleName) Then
                notify("Enter the module name", "error")
                txtModuleName.Focus()
                Exit Sub
            End If
            If isEmptyString(url) Then
                notify("Enter module URL", "error")
                txtURL.Focus()
            End If
            If isUniqueModuleName(moduleName, cmbModuleCategory.SelectedValue) Then
                Using con = New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                    Using cmd = New SqlCommand("insert into MASTER_MODULES ([ModuleName],[USER_CREATED_DATE],[USER_CREATED_BY],[USER_MODIFIED_BY],[USER_MODIFIED_DATE],[URL_NAME],[MODULE_CATEGORY]) values('" & BankString.removeSpecialCharacter(moduleName) & "',GetDate(),'" & Session("UserID") & "','','','" & url & "','" & BankString.removeSpecialCharacter(cmbModuleCategory.SelectedValue) & "')", con)
                        If con.State = ConnectionState.Open Then
                            con.Close()
                        End If
                        con.Open()
                        If cmd.ExecuteNonQuery Then
                            notify("Module successfully created", "success")
                            recordAction("btnSaveModule", "Added new module: " & txtModuleName.Text)
                            clearAll()
                            loadModules()
                        Else
                            notify("Error adding new module", "error")
                        End If
                        con.Close()
                    End Using
                End Using
            Else
                notify("The name you entered already exists.", "error")
                txtModuleName.Focus()
            End If

        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- btnSaveModule_Click()", ex.ToString)
        End Try
    End Sub

    Protected Sub clearAll()
        Try
            txtModuleName.Text = ""
            txtURL.Text = ""
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub grdModules_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdModules.PageIndexChanging
        grdModules.PageIndex = e.NewPageIndex
        loadModules()
    End Sub

    Protected Sub grdModules_RowCancelingEdit(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles grdModules.RowCancelingEdit
        grdModules.EditIndex = -1
        loadModules()
    End Sub

    Protected Sub grdModules_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdModules.RowDataBound
        If (e.Row.RowType = DataControlRowType.DataRow And grdModules.EditIndex = e.Row.RowIndex) Then
            Dim cmbCategory = DirectCast(e.Row.FindControl("cmbModuleCategoryEdit"), DropDownList)
            loadModuleCategories(cmbCategory)
            Try
                cmbCategory.SelectedValue = DirectCast(e.Row.FindControl("txtModuleCategory0Edit"), TextBox).Text
            Catch ex As Exception
                cmbCategory.SelectedItem.Text = ""
            End Try
        End If
    End Sub

    Protected Sub grdModules_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles grdModules.RowDeleting
        ViewState("moduleEditID") = DirectCast(grdModules.Rows(e.RowIndex).FindControl("txtModuleId0"), TextBox).Text
        Using con = New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
            Using cmd = New SqlCommand("delete from MASTER_MODULES where ModuleID='" & ViewState("moduleEditID") & "'", con)
                If con.State = ConnectionState.Open Then
                    con.Close()
                End If
                con.Open()
                If cmd.ExecuteNonQuery Then
                    notify("Module successfully deleted", "success")
                    recordAction("grdModules_RowDeleting", "Deleted module: " & ViewState("moduleEditID"))
                Else
                    notify("Error deleting module", "error")
                End If
                con.Close()
                loadModules()
            End Using
        End Using
    End Sub

    Protected Sub grdModules_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles grdModules.RowEditing
        ViewState("moduleEditID") = DirectCast(grdModules.Rows(e.NewEditIndex).FindControl("txtModuleId0"), TextBox).Text
        grdModules.EditIndex = e.NewEditIndex
        loadModules()
    End Sub

    Protected Sub grdModules_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles grdModules.RowUpdating
        If Trim(ViewState("moduleEditID")) = "" Or IsDBNull(ViewState("moduleEditID")) Then
            notify("No module selected for update", "error")
            Exit Sub
        End If
        Dim modName As String = DirectCast(grdModules.Rows(e.RowIndex).FindControl("txtModuleName0Edit"), TextBox).Text
        Dim modURL As String = DirectCast(grdModules.Rows(e.RowIndex).FindControl("txtURLName0Edit"), TextBox).Text
        Dim modCat As String = DirectCast(grdModules.Rows(e.RowIndex).FindControl("cmbModuleCategoryEdit"), DropDownList).SelectedValue
        Using con = New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
            Using cmd = New SqlCommand("update MASTER_MODULES set ModuleName='" & modName & "',URL_NAME='" & modURL & "',[MODULE_CATEGORY]='" & BankString.removeSpecialCharacter(modCat) & "' where ModuleID='" & ViewState("moduleEditID") & "'", con)
                Dim cmdPerm = New SqlCommand("update MASTER_PERMISSIONS set ModuleName='" & modName & "',URL_NAME='" & modURL & "' where ModuleID='" & ViewState("moduleEditID") & "'", con)
                If con.State = ConnectionState.Open Then
                    con.Close()
                End If
                con.Open()
                If cmd.ExecuteNonQuery Then
                    cmdPerm.ExecuteNonQuery()
                    notify("Module successfully updated", "success")
                    recordAction("grdModules_RowUpdating", "Updated module: " & modName)
                Else
                    notify("Error updating module", "error")
                End If
                con.Close()
                grdModules.EditIndex = -1
                loadModules()
            End Using
        End Using
    End Sub

    Protected Sub grdModules_SelectedIndexChanged(sender As Object, e As EventArgs) Handles grdModules.SelectedIndexChanged

    End Sub

    Protected Function isEmptyString(ByVal str As String) As Boolean
        If IsDBNull(str) Or Trim(str) = "" Then
            Return True
        Else
            Return False
        End If
    End Function

    Protected Function isUniqueModuleName(ByVal moduleName As String, cat As String) As Boolean
        Using con = New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
            Using cmd = New SqlCommand("select * from MASTER_MODULES where ModuleName=@modName and [MODULE_CATEGORY]=@modCat", con)
                cmd.Parameters.AddWithValue("@modName", moduleName)
                cmd.Parameters.AddWithValue("@modCat", cat)
                Dim dt As New DataTable
                Using adp = New SqlDataAdapter(cmd)
                    adp.Fill(dt)
                End Using
                If dt.Rows.Count > 0 Then
                    Return False
                Else
                    Return True
                End If
            End Using
        End Using
    End Function

    Protected Function isUniqueModuleURL(ByVal moduleURL As String) As Boolean
        Using con = New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
            Using cmd = New SqlCommand("select * from MASTER_MODULES where URL_NAME=@modURL", con)
                cmd.Parameters.AddWithValue("@modURL", moduleURL)
                Dim dt As New DataTable
                Using adp = New SqlDataAdapter(cmd)
                    adp.Fill(dt)
                End Using
                If dt.Rows.Count > 0 Then
                    Return False
                Else
                    Return True
                End If
            End Using
        End Using
    End Function

    Protected Sub loadModuleCategories(ByVal cmbCategory As DropDownList)
        Try
            Using con = New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmdSel = New SqlCommand("select * from MASTER_MODULE_CATEGORIES", con)
                    Dim dsSel As New DataSet
                    Using adp = New SqlDataAdapter(cmdSel)
                        adp.Fill(dsSel, "CATEGORY")
                    End Using
                    loadCombo(dsSel.Tables(0), cmbCategory, "CATEGORY", "ID")
                End Using
            End Using
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Page.MaintainScrollPositionOnPostBack = True
            If Not IsPostBack Then
                loadModuleCategories(cmbModuleCategory)
                loadModules()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Private Sub loadModules()
        Try
            Using con = New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd = New SqlCommand("select * from MASTER_MODULES mm join MASTER_MODULE_CATEGORIES mmc on mm.MODULE_CATEGORY=mmc.ID order by ModuleId", con)
                    Dim ds1 As New DataSet
                    Using adp = New SqlDataAdapter(cmd)
                        adp.Fill(ds1, "MASTER_MODULES")
                    End Using
                    bindGrid(ds1.Tables(0), grdModules)
                End Using
            End Using
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
End Class