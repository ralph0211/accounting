Imports System.Data
Imports System.Data.SqlClient

Partial Class Rating_RatingVariables
    Inherits System.Web.UI.Page
    Private strConnString As String = ConfigurationManager.ConnectionStrings("Constring").ConnectionString
    Dim cmd As SqlCommand
    Dim con As New SqlConnection
    Dim connection As String
    Dim adp As New SqlDataAdapter
    Dim ds As New DataSet()
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        Page.MaintainScrollPositionOnPostBack = True
        con = New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
        If (Not IsPostBack) Then
            loadEntities()
            bindVariables()
        End If
    End Sub

    Protected Sub btnAddVariable_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAddVariable.Click
        addVariable(cmbEntityType.SelectedValue, cmbRatingCategory.SelectedValue, cmbRatingSubCategory.SelectedValue, txtRatingVariable.Text, rdbValueType.SelectedValue)
        bindVariables(cmbRatingSubCategory.SelectedValue)
    End Sub

    Protected Sub loadEntities()
        'Using con As New SqlConnection(strConnString)
        '    Using sda As New SqlDataAdapter()
        '        Dim query As String = "SELECT * FROM entity_types where active='1'"
        '        Dim cmd As New SqlCommand(query)
        '        cmd.Connection = con
        '        sda.SelectCommand = cmd
        '        Using ds As New DataSet()
        '            sda.Fill(ds)
        '            CreditManager.loadCombo(ds.Tables(0), cmbEntityType, "description", "id")
        '        End Using
        '    End Using
        'End Using
        Dim con As New SqlConnection(strConnString)
        Dim sda As New SqlDataAdapter()
        'Dim query As String = "SELECT * FROM entity_types where active='1'"
        Dim query As String = "SELECT * FROM PARA_CLIENT_TYPES"
        Dim cmd As New SqlCommand(query, con)
        sda = New SqlDataAdapter(cmd)
        Dim ds As New DataSet()
        sda.Fill(ds)
        'CreditManager.loadCombo(ds.Tables(0), cmbEntityType, "description", "id")
        CreditManager.loadCombo(ds.Tables(0), cmbEntityType, "CLIENT_TYPE", "ID")
    End Sub

    'TODO: INSTANT VB TODO TASK: Assignments within expressions are not supported in VB.NET
    'ORIGINAL LINE: public void loadCategories(string entityID = "0")
    Public Sub loadCategories(Optional entityID As String = "0")
        If entityID = "" Then
            entityID = "0"
        End If
        Using con As New SqlConnection(strConnString)
            Using sda As New SqlDataAdapter()
                Dim query As String = "SELECT * FROM entity_scoring_categories where active='1' and entity_id='" & entityID & "'"
                Dim cmd As New SqlCommand(query)
                cmd.Connection = con
                sda.SelectCommand = cmd
                Using ds As New DataSet()
                    sda.Fill(ds)
                    CreditManager.loadCombo(ds.Tables(0), cmbRatingCategory, "description", "id")
                End Using
            End Using
        End Using
    End Sub
    Public Sub loadSubCategories(Optional catID As String = "0")
        If catID = "" Then
            catID = "0"
        End If
        Using con As New SqlConnection(strConnString)
            Using sda As New SqlDataAdapter()
                Dim query As String = "SELECT * FROM entity_scoring_subcategories where active='1' and category_id='" & catID & "'"
                Dim cmd As New SqlCommand(query)
                cmd.Connection = con
                sda.SelectCommand = cmd
                Using ds As New DataSet()
                    sda.Fill(ds)
                    CreditManager.loadCombo(ds.Tables(0), cmbRatingSubCategory, "sub_category", "id")
                End Using
            End Using
        End Using
    End Sub

    Protected Sub addVariable(ByVal entID As String, ByVal catId As String, subCatID As String, ByVal varName As String, ByVal valType As String)
        Try
            Dim strConnString As String = ConfigurationManager.ConnectionStrings("Constring").ConnectionString
            Using con As New SqlConnection(strConnString)
                Using sda As New SqlDataAdapter()
                    Dim query As String = "INSERT INTO entity_scoring_variables(entity_id,category_id,subcategory_id,description,value_type,active) values ('" & entID & "','" & catId & "','" & subCatID & "','" & varName & "','" & valType & "','1')"
                    Dim cmd As New SqlCommand(query)
                    cmd.Connection = con
                    sda.SelectCommand = cmd
                    If con.State = ConnectionState.Open Then
                        con.Close()
                    End If
                    con.Open()
                    If cmd.ExecuteNonQuery() > 0 Then
                        CreditManager.notify("Variable was successfully created", "success")
                        'msgbox("Variable was successfully created")
                        txtRatingVariable.Text = ""
                        bindVariables(cmbRatingSubCategory.SelectedValue)
                    Else
                        CreditManager.notify("Error adding variable", "error")
                        'msgbox("Error adding variable")
                    End If
                    con.Close()
                End Using
            End Using
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    'TODO: INSTANT VB TODO TASK: Assignments within expressions are not supported in VB.NET
    'ORIGINAL LINE: protected void bindVariables(string catID = "0")
    Protected Sub bindVariables(Optional subCatID As String = "0")
        If subCatID = "" Then
            subCatID = "0"
        End If
        Dim strConnString As String = ConfigurationManager.ConnectionStrings("Constring").ConnectionString
        Using con As New SqlConnection(strConnString)
            Using sda As New SqlDataAdapter()
                Dim query As String = "select *,esv.active as activated,esv.id as var_id,esv.description as question,esc.description as category,esc.id as category_id,ess.id as subcat_id,case esv.value_type when 'R' then 'Range' when 'A' then 'Absolute' end as valType from entity_scoring_variables esv join entity_scoring_subcategories ess on esv.subcategory_id=ess.id join entity_scoring_categories esc on esv.category_id=esc.id where esv.subcategory_id='" & subCatID & "'"
                Dim cmd As New SqlCommand(query)
                cmd.Connection = con
                sda.SelectCommand = cmd
                Using ds As New DataSet()
                    sda.Fill(ds)
                    CreditManager.bindGrid(ds.Tables(0), grdVariable)
                End Using
            End Using
        End Using
    End Sub

    Protected Sub cmbRatingCategory_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbRatingCategory.SelectedIndexChanged
        bindVariables(cmbRatingSubCategory.SelectedValue)
        loadSubCategories(cmbRatingCategory.SelectedValue)
    End Sub

    Protected Sub cmbEntityType_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbEntityType.SelectedIndexChanged
        loadCategories(cmbEntityType.SelectedValue)
        bindVariables(cmbRatingSubCategory.SelectedValue)
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

    Protected Sub cmbRatingSubCategory_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbRatingSubCategory.SelectedIndexChanged
        bindVariables(cmbRatingSubCategory.SelectedValue)
    End Sub

    Protected Sub loadCategories(cmbCat As DropDownList, Optional entityID As String = "0")
        Dim strConnString As String = ConfigurationManager.ConnectionStrings("Constring").ConnectionString
        Using con As New SqlConnection(strConnString)
            Using sda As New SqlDataAdapter()
                Dim query As String = "SELECT * FROM entity_scoring_categories where entity_id='" & entityID & "'"
                Dim cmd As New SqlCommand(query)
                cmd.Connection = con
                sda.SelectCommand = cmd
                Using ds As New DataSet()
                    sda.Fill(ds)
                    'CreditManager.bindGrid(ds.Tables(0), grdCategory)
                    CreditManager.loadCombo(ds.Tables(0), cmbCat, "description", "id")
                End Using
            End Using
        End Using
    End Sub

    Protected Sub loadSubCategories(cmbSubCat As DropDownList, Optional catID As String = "0")
        Dim strConnString As String = ConfigurationManager.ConnectionStrings("Constring").ConnectionString
        Using con As New SqlConnection(strConnString)
            Using sda As New SqlDataAdapter()
                Dim query As String = "SELECT * FROM entity_scoring_subcategories where category_id='" & catID & "'"
                Dim cmd As New SqlCommand(query)
                cmd.Connection = con
                sda.SelectCommand = cmd
                Using ds As New DataSet()
                    sda.Fill(ds)
                    'CreditManager.bindGrid(ds.Tables(0), grdCategory)
                    CreditManager.loadCombo(ds.Tables(0), cmbSubCat, "sub_category", "id")
                End Using
            End Using
        End Using
    End Sub

    Protected Sub grdVariable_RowCancelingEdit(sender As Object, e As GridViewCancelEditEventArgs) Handles grdVariable.RowCancelingEdit
        grdVariable.EditIndex = -1
        bindVariables(cmbRatingSubCategory.SelectedValue)
    End Sub

    Protected Sub grdVariable_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles grdVariable.RowDataBound
        If (e.Row.RowType = DataControlRowType.DataRow And grdVariable.EditIndex = e.Row.RowIndex) Then
            'msgbox(DirectCast(e.Row.FindControl("grdUsers_txtUserType"), TextBox).Text)
            Dim cmbCategory = DirectCast(e.Row.FindControl("cmbCategory0Edit"), DropDownList)
            loadCategories(cmbCategory, cmbEntityType.SelectedValue)
            Try
                cmbCategory.SelectedValue = DirectCast(e.Row.FindControl("txtCategory0Edit"), TextBox).Text
            Catch ex As Exception
                cmbCategory.ClearSelection()
            End Try
            cmbCategory.AutoPostBack = True

            Dim cmbSubCategory = DirectCast(e.Row.FindControl("cmbSubCategory0Edit"), DropDownList)
            loadSubCategories(cmbSubCategory, cmbCategory.SelectedValue)
            Try
                cmbSubCategory.SelectedValue = DirectCast(e.Row.FindControl("txtSubCategory0Edit"), TextBox).Text
            Catch ex As Exception
                cmbSubCategory.ClearSelection()
            End Try

            Dim cmbValType = DirectCast(e.Row.FindControl("cmbvalType0Edit"), DropDownList)
            Try
                cmbValType.SelectedValue = DirectCast(e.Row.FindControl("txtvalType0Edit"), TextBox).Text
            Catch ex As Exception
                cmbValType.ClearSelection()
            End Try
        End If
    End Sub

    Protected Sub grdVariable_RowDeleting(sender As Object, e As GridViewDeleteEventArgs) Handles grdVariable.RowDeleting
        ViewState("varEditID") = DirectCast(grdVariable.Rows(e.RowIndex).FindControl("txtClassId0"), TextBox).Text
        cmd = New SqlCommand("delete from entity_scoring_variables where id='" & ViewState("varEditID") & "'", con)
        Dim cmd1 = New SqlCommand("delete from rating_ranges where variable_id='" & ViewState("varEditID") & "'", con)
        If con.State = ConnectionState.Open Then
            con.Close()
        End If
        con.Open()
        If cmd.ExecuteNonQuery Then
            cmd1.ExecuteNonQuery()
            msgbox("Question successfully deleted")
        Else
            msgbox("Error deleting question")
        End If
        con.Close()
        ViewState("varEditID") = 0
        bindVariables(cmbRatingSubCategory.SelectedValue)
    End Sub

    Protected Sub grdVariable_RowEditing(sender As Object, e As GridViewEditEventArgs) Handles grdVariable.RowEditing
        ViewState("varEditID") = DirectCast(grdVariable.Rows(e.NewEditIndex).FindControl("txtClassId0"), TextBox).Text
        'msgbox(ViewState("varEditID"))
        grdVariable.EditIndex = e.NewEditIndex
        bindVariables(cmbRatingSubCategory.SelectedValue)
    End Sub

    Protected Sub grdVariable_RowUpdating(sender As Object, e As GridViewUpdateEventArgs) Handles grdVariable.RowUpdating
        'msgbox(ViewState("varEditID"))
        If Trim(ViewState("varEditID")) = "" Or IsDBNull(ViewState("varEditID")) Then
            msgbox("No question selected for update")
            Exit Sub
        End If
        Dim cat As String = DirectCast(grdVariable.Rows(e.RowIndex).FindControl("cmbCategory0Edit"), DropDownList).SelectedValue
        Dim valType As String = DirectCast(grdVariable.Rows(e.RowIndex).FindControl("cmbvalType0Edit"), DropDownList).SelectedValue
        Dim subCat As String = DirectCast(grdVariable.Rows(e.RowIndex).FindControl("cmbSubCategory0Edit"), DropDownList).SelectedValue
        Dim questn As String = DirectCast(grdVariable.Rows(e.RowIndex).FindControl("txtQuestion0Edit"), TextBox).Text
        Dim activ As String = DirectCast(grdVariable.Rows(e.RowIndex).FindControl("chkActive0Edit"), CheckBox).Checked
        'Dim premium As String = DirectCast(grdSubCategory.Rows(e.RowIndex).FindControl("txtPremium0Edit"), TextBox).Text
        cmd = New SqlCommand("update entity_scoring_variables set category_id='" & cat & "',subcategory_id='" & subCat & "',[description]='" & questn & "',[value_type]='" & valType & "',active='" & activ & "' where id='" & ViewState("varEditID") & "'", con)
        If con.State = ConnectionState.Open Then
            con.Close()
        End If
        con.Open()
        If cmd.ExecuteNonQuery Then
            msgbox("Sub category successfully updated")
        Else
            msgbox("Error updating sub category")
        End If
        con.Close()
        grdVariable.EditIndex = -1
        ViewState("varEditID") = 0
        bindVariables(cmbRatingSubCategory.SelectedValue)
    End Sub

    Protected Sub cmbCategory0Edit_SelectedIndexChanged(sender As Object, e As EventArgs)
        Dim row As GridViewRow = grdVariable.Rows(grdVariable.EditIndex)
        Dim cmbCategory = DirectCast(row.FindControl("cmbCategory0Edit"), DropDownList)
        Dim cmbSubCategory = DirectCast(row.FindControl("cmbSubCategory0Edit"), DropDownList)
        loadSubCategories(cmbSubCategory, cmbCategory.SelectedValue)
    End Sub
End Class