Imports System.Data
Imports System.Data.SqlClient

Partial Class Rating_RatingCategories
    Inherits System.Web.UI.Page
    Private strConnString As String = ConfigurationManager.ConnectionStrings("Constring").ConnectionString
    Dim con As New SqlConnection
    Dim urlPermission As String = "PermissionDenied.aspx"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        Page.MaintainScrollPositionOnPostBack = True
        con = New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
        If (Not IsPostBack) Then
            loadEntities()
            bindCategories()
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

    Protected Sub addCategory(ByVal entID As String, ByVal catName As String)
        Try
            Dim strConnString As String = ConfigurationManager.ConnectionStrings("Constring").ConnectionString
            Using con As New SqlConnection(strConnString)
                Using sda As New SqlDataAdapter()
                    Dim query As String = "INSERT INTO entity_scoring_categories(entity_id,description,active) values ('" & cmbEntityType.SelectedValue & "','" & txtRatingCategory.Text & "','1')"
                    Dim cmd As New SqlCommand(query)
                    cmd.Connection = con
                    sda.SelectCommand = cmd
                    If con.State = ConnectionState.Open Then
                        con.Close()
                    End If
                    con.Open()
                    If cmd.ExecuteNonQuery() > 0 Then
                        msgbox("Category was successfully added")
                        txtRatingCategory.Text = ""
                        bindCategories()
                    Else
                        msgbox("Error adding category")
                    End If
                    con.Close()
                End Using
            End Using
        Catch ex As Exception
            ErrorLogging.WriteLogFile(Session("UserId"), "Rating/RatingCategories---addCategory", ex.Message)
            msgbox(ex.Message)
        Finally

        End Try
    End Sub
    Protected Sub bindCategories()
        Dim strConnString As String = ConfigurationManager.ConnectionStrings("Constring").ConnectionString
        Using con As New SqlConnection(strConnString)
            Using sda As New SqlDataAdapter()
                'Dim query As String = "SELECT * FROM entity_scoring_categories"
                Dim query As String = "select esc.id as cat_id,esc.entity_id,esc.description,esc.active,pct.CLIENT_TYPE from entity_scoring_categories esc join PARA_CLIENT_TYPES pct on esc.entity_id=pct.ID"
                Dim cmd As New SqlCommand(query)
                cmd.Connection = con
                sda.SelectCommand = cmd
                Using ds As New DataSet()
                    sda.Fill(ds)
                    CreditManager.bindGrid(ds.Tables(0), grdCategory)
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

    Protected Sub loadEntities(cmbEntity As DropDownList)
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
                    CreditManager.loadCombo(ds.Tables(0), cmbEntity, "CLIENT_TYPE", "ID")
                End Using
            End Using
        End Using
    End Sub

    Protected Sub btnAddCategory_Click(sender As Object, e As EventArgs) Handles btnAddCategory.Click
        addCategory(cmbEntityType.SelectedValue, txtRatingCategory.Text)
    End Sub

    Protected Sub grdCategory_RowCancelingEdit(sender As Object, e As GridViewCancelEditEventArgs) Handles grdCategory.RowCancelingEdit
        grdCategory.EditIndex = -1
        bindCategories()
    End Sub

    Protected Sub grdCategory_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles grdCategory.RowDataBound
        If (e.Row.RowType = DataControlRowType.DataRow And grdCategory.EditIndex = e.Row.RowIndex) Then
            'msgbox(DirectCast(e.Row.FindControl("grdUsers_txtUserType"), TextBox).Text)
            Dim cmbClientTypes = DirectCast(e.Row.FindControl("cmbClientTypeEdit"), DropDownList)
            loadEntities(cmbClientTypes)
            Try
                cmbClientTypes.SelectedValue = DirectCast(e.Row.FindControl("lblClientType0Edit"), Label).Text
            Catch ex As Exception
                cmbClientTypes.ClearSelection()
            End Try
        End If
    End Sub

    Protected Sub grdCategory_RowDeleting(sender As Object, e As GridViewDeleteEventArgs) Handles grdCategory.RowDeleting

    End Sub

    Protected Sub grdCategory_RowEditing(sender As Object, e As GridViewEditEventArgs) Handles grdCategory.RowEditing
        ViewState("categoryEditID") = DirectCast(grdCategory.Rows(e.NewEditIndex).FindControl("txtCategoryId0"), TextBox).Text
        grdCategory.EditIndex = e.NewEditIndex
        bindCategories()
    End Sub

    Protected Sub grdCategory_RowUpdating(sender As Object, e As GridViewUpdateEventArgs) Handles grdCategory.RowUpdating
        If Trim(ViewState("categoryEditID")) = "" Or IsDBNull(ViewState("categoryEditID")) Then
            msgbox("No client type selected for update")
            Exit Sub
        End If
        Dim cat As String = DirectCast(grdCategory.Rows(e.RowIndex).FindControl("txtCategory0Edit"), TextBox).Text
        Dim activated As String = DirectCast(grdCategory.Rows(e.RowIndex).FindControl("chkActive0Edit"), CheckBox).Checked
        Dim clientType As String = DirectCast(grdCategory.Rows(e.RowIndex).FindControl("cmbClientTypeEdit"), DropDownList).SelectedValue
        Dim cmd = New SqlCommand("update entity_scoring_categories set entity_id='" & clientType & "',description='" & cat & "',active='" & activated & "' where id='" & ViewState("categoryEditID") & "'", con)
        If con.State = ConnectionState.Open Then
            con.Close()
        End If
        con.Open()
        If cmd.ExecuteNonQuery Then
            msgbox("Base rate successfully updated")
        Else
            msgbox("Error updating base rate")
        End If
        con.Close()
        grdCategory.EditIndex = -1
        bindCategories()
    End Sub

    Protected Sub cmbEntityType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbEntityType.SelectedIndexChanged
        bindCategories()
    End Sub
End Class