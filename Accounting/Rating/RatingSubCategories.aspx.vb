Imports System.Data
Imports System.Data.SqlClient

Partial Class Rating_RatingSubCategories
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
            loadCategories()
            bindSubCategories()
        End If
    End Sub

    Protected Sub loadEntities()
        Using con As New SqlConnection(strConnString)
            Using sda As New SqlDataAdapter()
                'Dim query As String = "SELECT * FROM entity_types where active='1'"
                Dim query As String = "SELECT * FROM PARA_CLIENT_TYPES"
                Dim cmd As New SqlCommand(query)
                cmd.Connection = con
                sda.SelectCommand = cmd
                Using ds As New DataSet()
                    sda.Fill(ds)
                    'CreditManager.loadCombo(ds.Tables(0), cmbEntityType, "description", "id")
                    CreditManager.loadCombo(ds.Tables(0), cmbEntityType, "CLIENT_TYPE", "ID")
                End Using
            End Using
        End Using
    End Sub

    Protected Sub addSubCategory(ByVal entID As String, catID As String, ByVal subCatName As String)
        Try
            Dim strConnString As String = ConfigurationManager.ConnectionStrings("Constring").ConnectionString
            Using con As New SqlConnection(strConnString)
                Using sda As New SqlDataAdapter()
                    Dim query As String = "INSERT INTO entity_scoring_subcategories(category_id,sub_category,active) values ('" & cmbRatingCategory.SelectedValue & "','" & txtRatingSubCategory.Text & "','1')"
                    Dim cmd As New SqlCommand(query)
                    cmd.Connection = con
                    sda.SelectCommand = cmd
                    If con.State = ConnectionState.Open Then
                        con.Close()
                    End If
                    con.Open()
                    If cmd.ExecuteNonQuery() > 0 Then
                        msgbox("Sub-category was successfully added")
                        txtRatingSubCategory.Text = ""
                        bindSubCategories(cmbRatingCategory.SelectedValue)
                    Else
                        msgbox("Error adding sub-category")
                    End If
                    con.Close()
                End Using
            End Using
        Catch ex As Exception
            msgbox(ex.Message)
        Finally

        End Try
    End Sub
    Protected Sub bindSubCategories(Optional catID As String = "0")
        Dim strConnString As String = ConfigurationManager.ConnectionStrings("Constring").ConnectionString
        Using con As New SqlConnection(strConnString)
            Using sda As New SqlDataAdapter()
                Dim query As String = "select *, ess.active as activated,ess.id as sub_id from entity_scoring_categories esc join entity_scoring_subcategories ess on esc.id=ess.category_id where ess.category_id='" & catID & "'"
                Dim cmd As New SqlCommand(query)
                cmd.Connection = con
                sda.SelectCommand = cmd
                Using ds As New DataSet()
                    sda.Fill(ds)
                    CreditManager.bindGrid(ds.Tables(0), grdSubCategory)
                End Using
            End Using
        End Using
    End Sub
    Protected Sub loadCategories(Optional entityID As String = "0")
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
                    CreditManager.loadCombo(ds.Tables(0), cmbRatingCategory, "description", "id")
                End Using
            End Using
        End Using
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

    Public Sub msgbox(ByVal strMessage As String)
        'finishes server processing, returns to client.
        Dim strScript As String = "<script language=JavaScript>"
        strScript += "window.alert(""" & strMessage & """);"
        strScript += "</script>"
        Dim lbl As New System.Web.UI.WebControls.Label
        lbl.Text = strScript
        Page.Controls.Add(lbl)
    End Sub

    Protected Sub btnAddCategory_Click(sender As Object, e As EventArgs) Handles btnAddCategory.Click
        addSubCategory(cmbEntityType.SelectedValue, cmbRatingCategory.SelectedValue, txtRatingSubCategory.Text)
    End Sub

    Protected Sub cmbEntityType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbEntityType.SelectedIndexChanged
        loadCategories(cmbEntityType.SelectedValue)
    End Sub

    Protected Sub grdSubCategory_RowCancelingEdit(sender As Object, e As GridViewCancelEditEventArgs) Handles grdSubCategory.RowCancelingEdit
        grdSubCategory.EditIndex = -1
        ViewState("subCatEditID") = 0
        bindSubCategories(cmbRatingCategory.SelectedValue)
    End Sub

    Protected Sub grdSubCategory_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles grdSubCategory.RowDataBound
        If (e.Row.RowType = DataControlRowType.DataRow And grdSubCategory.EditIndex = e.Row.RowIndex) Then
            'msgbox(DirectCast(e.Row.FindControl("grdUsers_txtUserType"), TextBox).Text)
            Dim cmbCategory = DirectCast(e.Row.FindControl("cmbCategory0Edit"), DropDownList)
            loadCategories(cmbCategory, cmbEntityType.SelectedValue)
            Try
                cmbCategory.SelectedValue = DirectCast(e.Row.FindControl("txtCategory0Edit"), TextBox).Text
            Catch ex As Exception
                cmbCategory.ClearSelection()
            End Try
        End If
    End Sub

    Protected Sub grdSubCategory_RowDeleting(sender As Object, e As GridViewDeleteEventArgs) Handles grdSubCategory.RowDeleting
        ViewState("subCatEditID") = DirectCast(grdSubCategory.Rows(e.RowIndex).FindControl("txtClassId0"), TextBox).Text
        cmd = New SqlCommand("delete from entity_scoring_subcategories where id='" & ViewState("subCatEditID") & "'", con)
        Dim cmd1 = New SqlCommand("delete from entity_scoring_variables where subcategory_id='" & ViewState("subCatEditID") & "'", con)
        'Dim cmd1 = New SqlCommand("delete from rating_ranges where variable_id='" & ViewState("subCatEditID") & "'", con)
        If con.State = ConnectionState.Open Then
            con.Close()
        End If
        con.Open()
        If cmd.ExecuteNonQuery Then
            cmd1.ExecuteNonQuery()
            msgbox("Sub category successfully deleted")
        Else
            msgbox("Error deleting sub category")
        End If
        con.Close()
        ViewState("subCatEditID") = 0
        bindSubCategories(cmbRatingCategory.SelectedValue)
    End Sub

    Protected Sub grdSubCategory_RowEditing(sender As Object, e As GridViewEditEventArgs) Handles grdSubCategory.RowEditing
        ViewState("subCatEditID") = DirectCast(grdSubCategory.Rows(e.NewEditIndex).FindControl("txtClassId0"), TextBox).Text
        grdSubCategory.EditIndex = e.NewEditIndex
        bindSubCategories(cmbRatingCategory.SelectedValue)
    End Sub

    Protected Sub grdSubCategory_RowUpdating(sender As Object, e As GridViewUpdateEventArgs) Handles grdSubCategory.RowUpdating
        If Trim(ViewState("subCatEditID")) = "" Or IsDBNull(ViewState("subCatEditID")) Then
            msgbox("No sub category selected for update")
            Exit Sub
        End If
        Dim cat As String = DirectCast(grdSubCategory.Rows(e.RowIndex).FindControl("cmbCategory0Edit"), DropDownList).SelectedValue
        Dim subCat As String = DirectCast(grdSubCategory.Rows(e.RowIndex).FindControl("txtSubCategory0Edit"), TextBox).Text
        Dim activ As String = DirectCast(grdSubCategory.Rows(e.RowIndex).FindControl("chkActive0Edit"), CheckBox).Checked
        'Dim premium As String = DirectCast(grdSubCategory.Rows(e.RowIndex).FindControl("txtPremium0Edit"), TextBox).Text
        cmd = New SqlCommand("update entity_scoring_subcategories set category_id='" & cat & "',sub_category='" & subCat & "',active='" & activ & "' where id='" & ViewState("subCatEditID") & "'", con)
        Dim cmd1 = New SqlCommand("update entity_scoring_variables set category_id='" & cat & "' where subcategory_id='" & ViewState("subCatEditID") & "'", con)
        If con.State = ConnectionState.Open Then
            con.Close()
        End If
        con.Open()
        If cmd.ExecuteNonQuery Then
            cmd1.ExecuteNonQuery()
            msgbox("Sub category successfully updated")
        Else
            msgbox("Error updating sub category")
        End If
        con.Close()
        grdSubCategory.EditIndex = -1
        bindSubCategories(cmbRatingCategory.SelectedValue)
    End Sub

    Protected Sub cmbRatingCategory_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbRatingCategory.SelectedIndexChanged
        bindSubCategories(cmbRatingCategory.SelectedValue)
    End Sub
End Class