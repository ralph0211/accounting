Imports System.Data
Imports System.Data.SqlClient
Imports CreditManager

Partial Class Rating_CategoryWeighting
    Inherits System.Web.UI.Page
    Private strConnString As String = ConfigurationManager.ConnectionStrings("Constring").ConnectionString
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        Page.MaintainScrollPositionOnPostBack = True
        If (Not IsPostBack) Then
            loadEntities()
            getCategories(cmbEntityType.SelectedValue)
        End If
    End Sub

    Protected Sub loadEntities()
        Dim con As New SqlConnection(strConnString)
        Dim sda As New SqlDataAdapter()
        'Dim query As String = "SELECT * FROM entity_types where active='1'"
        Dim query As String = "SELECT * FROM PARA_CLIENT_TYPES"
        Dim cmd As New SqlCommand(query, con)
        sda = New SqlDataAdapter(cmd)
        Dim ds As New DataSet()
        sda.Fill(ds)
        'CreditManager.loadCombo(ds.Tables(0), cmbEntityType, "description", "id")
        'CreditManager.loadCombo(ds.Tables(0), cmbEntityType, "CLIENT_TYPE", "ID")
        If ds.Tables(0).Rows.Count > 0 Then
            cmbEntityType.DataSource = ds.Tables(0)
            cmbEntityType.DataTextField = "CLIENT_TYPE"
            cmbEntityType.DataValueField = "ID"
            cmbEntityType.DataBind()
        Else

        End If
    End Sub

    Protected Sub cmbEntityType_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        'loadCategories(cmbEntityType.SelectedValue);
        getCategories(cmbEntityType.SelectedValue)
    End Sub

    Protected Sub cmbRatingCategory_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        'bindVariables(cmbRatingCategory.SelectedValue);
    End Sub

    'TODO: INSTANT VB TODO TASK: Assignments within expressions are not supported in VB.NET
    'ORIGINAL LINE: protected void getCategories(string entityID = "0")
    Protected Sub getCategories(Optional entityID As String = "0")
        Try
            If entityID = "" Then
                entityID = "0"
            End If
            Using con As New SqlConnection(strConnString)
                Using sda As New SqlDataAdapter()
                    'Dim query As String = "select distinct esc.[description] as category,esc.id as cat_id, esc.weight from entity_scoring_categories esc where esc.active='1' and esc.entity_id='" & entityID & "'"
                    Dim query As String = "select distinct esc.[CATEGORY] as category,esc.id as cat_id, esc.weight from PARA_RATING_CATEGORIES esc where esc.CLIENT_TYPE='Individual'"
                    'msgbox(query)
                    Dim cmd As New SqlCommand(query)
                    cmd.Connection = con
                    sda.SelectCommand = cmd
                    Using ds As New DataSet()
                        sda.Fill(ds)
                        If ds.Tables(0).Rows.Count > 0 Then
                            rptCategories.DataSource = ds.Tables(0)
                        Else
                            rptCategories.DataSource = Nothing
                        End If
                        rptCategories.DataBind()
                    End Using
                End Using
            End Using
            ClientScript.RegisterStartupScript(Me.GetType, "summation", "<script type=""text/javascript"">calcSum();</script>")
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub rptCategories_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.RepeaterItemEventArgs)
        If (e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem) Then
            Dim lblCatID As Label = CType(e.Item.FindControl("lblCatID"), Label)
            'Repeater childRepeater = (Repeater)e.Item.FindControl("rptQuestions");
            Dim txtWeight As TextBox = CType(e.Item.FindControl("txtWeight"), TextBox)
            txtWeight.Attributes.Add("onchange", "calcSum();")
            ClientScript.RegisterStartupScript(Me.GetType(), "summing", "<script language=JavaScript>calcSum();</script>")
        End If
    End Sub
    Protected Function getQuestions(ByVal catID As Double) As DataTable
        Try
            Using con As New SqlConnection(strConnString)
                Using sda As New SqlDataAdapter()
                    Dim query As String = "select id as esvID, [description] as esvDesc, weight from entity_scoring_variables esv where esv.active='1' and category_id='" & catID & "'"
                    Dim cmd As New SqlCommand(query)
                    cmd.Connection = con
                    sda.SelectCommand = cmd
                    Using ds As New DataSet()
                        sda.Fill(ds)
                        If ds.Tables(0).Rows.Count > 0 Then
                            Return ds.Tables(0)
                        Else
                            Return Nothing
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            'log exception
            msgbox(ex.Message)
            Return Nothing
        End Try
    End Function
    Protected Sub rptQuestions_ItemDatabound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.RepeaterItemEventArgs)
        If (e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem) Then
            Dim lblQuestID As Label = CType(e.Item.FindControl("lblQuestionID"), Label)
            Dim txtWeight As TextBox = CType(e.Item.FindControl("txtWeight"), TextBox)
            txtWeight.Attributes.Add("onchange", "calcSum();")
            ClientScript.RegisterStartupScript(Me.GetType(), "summing", "<script language=JavaScript>calcSum();</script>")
        End If
    End Sub

    Protected Sub btnSaveWeight_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSaveWeight.Click
        For Each category As RepeaterItem In rptCategories.Items
            'Repeater rptQuestions = (Repeater)category.FindControl("rptQuestions");
            'foreach (RepeaterItem wgt in rptQuestions.Items)
            '{
            Dim lblCategoryID As Label = CType(category.FindControl("lblCatID"), Label)
            Dim txtWeight As TextBox = CType(category.FindControl("txtWeight"), TextBox)
            Dim questID As String = lblCategoryID.Text
            Dim weight As String = txtWeight.Text
            If weight.Trim() = "" Or Not IsNumeric(weight) Then
                weight = 0
            End If
            If weight.Trim() = "" Then

            Else
                Dim strConnString As String = ConfigurationManager.ConnectionStrings("Constring").ConnectionString
                Using con As New SqlConnection(strConnString)
                    Try
                        Dim query As String = "UPDATE [PARA_RATING_CATEGORIES] set weight = '" & weight & "' where id='" & questID & "'"
                        Dim cmd As New SqlCommand(query)
                        cmd.Connection = con
                        If con.State = ConnectionState.Open Then
                            con.Close()
                        End If
                        con.Open()
                        If cmd.ExecuteNonQuery() > 0 Then
                        Else
                            notify("Error updating weight", "error")
                        End If
                        con.Close()
                    Catch ex As Exception
                        msgbox(ex.Message)
                    End Try
                End Using
            End If
        Next category
        notify("Weight successfully updated", "success")
    End Sub
End Class