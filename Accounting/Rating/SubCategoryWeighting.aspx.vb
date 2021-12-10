Imports System.Data
Imports System.Data.SqlClient

Partial Class Rating_SubCategoryWeighting
    Inherits System.Web.UI.Page
    Protected subCatID As String = ""
    Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)

    Protected Sub getCategories(ByVal entityID As String)
        Try
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using sda As New SqlDataAdapter()
                    Dim query As String = "select distinct ROW_NUMBER() OVER(ORDER BY esc.id ASC) AS Row,esc.[description] as category,esc.id as cat_id, isnull(esc.weight,0) as weight from entity_scoring_categories esc where esc.active='1' and esc.entity_id='" & entityID & "'"
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
                        'loadNavBar(ds.Tables(0))
                        'showActivePanel(ds.Tables(0).Rows(0).Item("cat_id"))
                    End Using
                End Using
            End Using
            'ClientScript.RegisterStartupScript(Me.GetType, "summation", "<script type=""text/javascript"">calcSum();</script>")
        Catch ex As Exception
            CreditManager.notify(ex.Message, "error")
        End Try
    End Sub

    Protected Sub rptCategories_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.RepeaterItemEventArgs) Handles rptCategories.ItemDataBound
        If (e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem) Then
            Dim lblCatID As Label = CType(e.Item.FindControl("lblCatID"), Label)
            Dim childRepeater As Repeater = CType(e.Item.FindControl("rptSubCategory"), Repeater)
            'Dim rdbList As RadioButtonList = CType(childRepeater.FindControl("rdbQuestionRating"), RadioButtonList)
            'Dim lblActRating As Label = CType(e.Item.FindControl("lblActRating"), Label)
            Dim lblCategory As Label = CType(e.Item.FindControl("lblCategory"), Label)
            Dim txtWeight As Label = CType(e.Item.FindControl("txtWeight"), Label)
            'Dim lblVariableWeight As Label = CType(e.Item.FindControl("lblVariableWeight"), Label)
            Dim dt As New DataTable()
            dt = Nothing
            dt = getSubCategories(Convert.ToDouble(lblCatID.Text))
            If dt.Rows.Count > 0 Then
                childRepeater.DataSource = dt
            Else
                childRepeater.DataSource = Nothing
            End If
            'msgbox(lblCatID.Text)
            childRepeater.DataBind()
            Try
                'showCategoryRating(lblActRating, lblWgtScore, lblWgtScoreText, lblVariableWeight, txtCustNo.Text, lblCatID.Text)
            Catch

            End Try

        End If
    End Sub

    Protected Function getSubCategories(ByVal catID As Double) As DataTable
        Try
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using sda As New SqlDataAdapter()
                    'Dim query As String = "select id as esvID, [description] as esvDesc, isnull(weight,0) as weight from entity_scoring_variables esv where esv.active='1' and category_id='" & catID & "'"
                    Dim query As String = "select isnull(essc.weight,0) as weight,essc.id as subcatID, essc.sub_category from entity_scoring_subcategories essc where essc.category_id='" & catID & "'"
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
            CreditManager.notify(ex.Message, "error")
            Return Nothing
        End Try
    End Function

    Public Sub msgbox(ByVal strMessage As String)
        'finishes server processing, returns to client.
        Dim strScript As String = "<script language=JavaScript>"
        strScript += "window.alert(""" & strMessage & """);"
        strScript += "</script>"
        Dim lbl As New System.Web.UI.WebControls.Label
        lbl.Text = strScript
        Page.Controls.Add(lbl)
    End Sub

    Protected Sub rptSubCategory_ItemDataBound(sender As Object, e As RepeaterItemEventArgs)
        If (e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem) Then
            Dim txtSubWeight As TextBox = CType(e.Item.FindControl("txtSubWeight"), TextBox)
            'Dim lblQuestID As Label = CType(e.Item.FindControl("lblQuestionID"), Label)
            Dim lblSubCategory As Label = CType(e.Item.FindControl("lblSubCategory"), Label)
            Dim lblSubCategoryID As Label = CType(e.Item.FindControl("lblSubCatID"), Label)

            'loadRadioButton(rdbList, lblQuestID.Text)

            If subCatID = "" Then
                lblSubCategory.Visible = True
            Else
                If subCatID = lblSubCategoryID.Text Then
                    lblSubCategory.Visible = False
                Else
                    lblSubCategory.Visible = True
                End If
            End If
            subCatID = lblSubCategoryID.Text
            If lblSubCategory.Text = "" Then
                lblSubCategory.Visible = False
                txtSubWeight.Visible = False
            End If
            'lblSubCategory.Visible = e.Item.DataItem("AccountID") <> CType(s, Repeater).items(e.Item.ItemIndex - 1).dataitem("AccountID")
            'e.Item.
            ''If rdbList.Text <> "" Then

            ''TO BE IMPLEMENTED

        End If
    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Page.MaintainScrollPositionOnPostBack = True
        If Not IsPostBack Then
            loadEntities()
            'getCategories(cmbEntityType.SelectedValue)
            getCategories(2)
        End If
    End Sub

    Protected Sub btnSaveWeight_Click(sender As Object, e As EventArgs) Handles btnSaveWeight.Click
        saveSubCatWeights()
    End Sub

    Protected Sub saveSubCatWeights()
        ''server side validation
        For Each category As RepeaterItem In rptCategories.Items
            Dim childRepeater As Repeater = CType(category.FindControl("rptSubCategory"), Repeater)
            Dim lblSubCatError As Label = CType(category.FindControl("lblSubCatError"), Label)
            Dim subWeight As Double
            subWeight = 0
            Dim subCatID As Double
            subCatID = 0
            Dim subCatWeight As Double
            subCatWeight = 0
            For Each subcategory As RepeaterItem In childRepeater.Items
                Dim txtSubWeight As TextBox = CType(subcategory.FindControl("txtSubWeight"), TextBox)
                Dim lblSubCatID As Label = CType(subcategory.FindControl("lblSubCatID"), Label)
                subCatWeight = txtSubWeight.Text
                subCatID = lblSubCatID.Text
                subWeight = subWeight + txtSubWeight.Text
                ''save in database/ might need temporary table
                saveTemporaryWeight(subCatID, subCatWeight)
            Next
            If subWeight = 100 Then
                'get temp values
                Dim dt As DataTable = getTemporaryWeight()
                For Each dr As DataRow In dt.Rows
                    commitTemporaryWeight(dr("sub_category_id"), dr("weight"))
                Next
                deleteTemporaryWeight()
            Else
                'roll back all saved changes
                deleteTemporaryWeight()
                'update lblSubCatError error message
                'lblSubCatError.Text = "Values are not 100%. Saving cancelled"
                CreditManager.notify("Values do not sum to 100%. Saving cancelled", "error")
            End If
            'CreditManager.notify(subWeight, "success")
        Next
        getCategories(2)
    End Sub

    Protected Sub saveTemporaryWeight(subCatID As String, wgt As Double)
        Dim cmd = New SqlCommand("insert into temp_sub_cat_wgt values('" & subCatID & "','" & wgt & "')", con)
        If con.State <> ConnectionState.Closed Then
            con.Close()
        End If
        con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Protected Sub deleteTemporaryWeight()
        Dim cmd = New SqlCommand("delete from temp_sub_cat_wgt", con)
        If con.State <> ConnectionState.Closed Then
            con.Close()
        End If
        con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Protected Function getTemporaryWeight() As DataTable
        Dim cmd = New SqlCommand("select * from temp_sub_cat_wgt", con)
        Dim ds As New DataSet
        Dim adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "tscw")
        Return ds.Tables(0)
    End Function

    Protected Sub commitTemporaryWeight(subCatID As String, wgt As Double)
        Dim cmd = New SqlCommand("update entity_scoring_subcategories set weight='" & wgt & "' where id='" & subCatID & "'", con)
        If con.State <> ConnectionState.Closed Then
            con.Close()
        End If
        con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Protected Sub cmbEntityType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbEntityType.SelectedIndexChanged
        'CreditManager.notify(cmbEntityType.SelectedValue, "error")
        loadCategories(cmbEntityType.SelectedValue)
    End Sub

    Protected Sub loadEntities()
        Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
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

    Protected Sub loadCategories(ent As String)
        Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
            Using sda As New SqlDataAdapter()
                'Dim query As String = "SELECT * FROM entity_types where active='1'"
                Dim query As String = "select isnull(esc.weight,0) as weight,esc.id as catID, esc.[description] from [entity_scoring_categories] esc where esc.entity_id='" & ent & "'"
                Dim cmd As New SqlCommand(query)
                cmd.Connection = con
                sda.SelectCommand = cmd
                Using ds As New DataSet()
                    sda.Fill(ds)
                    'CreditManager.loadCombo(ds.Tables(0), cmbEntityType, "description", "id")
                    CreditManager.loadCombo(ds.Tables(0), cmbCategory, "description", "catID")
                End Using
            End Using
        End Using
    End Sub

    Protected Sub cmbCategory_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCategory.SelectedIndexChanged
        getSubCategories(cmbCategory.SelectedValue)
    End Sub
End Class