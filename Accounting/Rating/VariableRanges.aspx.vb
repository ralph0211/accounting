Imports System.Data
Imports System.Data.SqlClient

Partial Class Rating_VariableRanges
    Inherits System.Web.UI.Page
    Private Shared inputSelector As String = ""
    Private strConnString As String = ConfigurationManager.ConnectionStrings("Constring").ConnectionString
    Private Shared variableEditID As String
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
        End If
    End Sub

    Protected Sub btnAddRange_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAddRange.Click
        addRange()
    End Sub

    Protected Sub addRange()
        Try
            Using con As New SqlConnection(strConnString)
                Using sda As New SqlDataAdapter()
                    Dim query As String = ""
                    If inputSelector = "R" Then
                        query = "INSERT INTO rating_ranges(variable_id,lower_range,upper_range,score,scale,comment) values ('" & cmbRatingVariable.SelectedValue & "','" & txtLowerRange.Text & "','" & txtUpperRange.Text & "','" & txtScore.Text & "','" & txtScale.Text & "','" & txtComment.Text & "')"
                    ElseIf inputSelector = "A" Then
                        query = "INSERT INTO rating_ranges(variable_id,lower_range,score,scale,comment) values ('" & cmbRatingVariable.SelectedValue & "','" & txtAbsValue.Text & "','" & txtScore.Text & "','" & txtScale.Text & "','" & txtComment.Text & "')"
                    End If
                    Dim cmd As New SqlCommand(query)
                    cmd.Connection = con
                    sda.SelectCommand = cmd
                    If con.State = ConnectionState.Open Then
                        con.Close()
                    End If
                    con.Open()
                    If cmd.ExecuteNonQuery() > 0 Then
                        'msgbox("Range was successfully added")
                        CreditManager.notify("Range was successfully added", "success")
                        txtLowerRange.Text = ""
                        txtUpperRange.Text = ""
                        txtScore.Text = ""
                        bindRanges(cmbRatingVariable.SelectedValue)
                    Else
                        'msgbox("Error adding variable")
                        CreditManager.notify("Error adding variable", "error")
                    End If
                    con.Close()
                End Using
            End Using
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    'TODO: INSTANT VB TODO TASK: Assignments within expressions are not supported in VB.NET
    'ORIGINAL LINE: protected void bindRanges(string varID = "0")
    Protected Sub bindRanges(Optional varID As String = "0")
        If varID = "" Then
            varID = "0"
        End If
        Using con As New SqlConnection(strConnString)
            Using sda As New SqlDataAdapter()
                'Dim query As String = "SELECT * FROM rating_ranges where variable_id='" & varID & "'"
                Dim query As String = "select *,rr.id as range_id from rating_ranges rr join entity_scoring_variables esv on rr.variable_id=esv.id where rr.variable_id='" & varID & "' order by score asc"
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

    Protected Sub inputSelect(ByVal varID As String)
        If varID = "" Then
            varID = "0"
        End If
        Dim valType As String = ""
        Using con As New SqlConnection(strConnString)
            Using sda As New SqlDataAdapter()
                Dim query As String = "SELECT ISNULL(value_type,'') FROM entity_scoring_variables where active='1' and id='" & varID & "'"
                Dim cmd As New SqlCommand(query)
                cmd.Connection = con
                sda.SelectCommand = cmd
                con.Open()
                valType = CStr(cmd.ExecuteScalar())
                con.Close()
            End Using
        End Using
        If valType = "A" Then
            valLabel.Visible = True
            valText.Visible = True
            rangeInput.Visible = False
        ElseIf valType = "R" Then
            valLabel.Visible = False
            valText.Visible = False
            rangeInput.Visible = True
        Else
            valLabel.Visible = True
            valText.Visible = True
            rangeInput.Visible = False
        End If
        txtValueType.Text = valType
        inputSelector = valType
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
    'ORIGINAL LINE: protected void loadCategories(string entityID="0")
    Protected Sub loadCategories(Optional entityID As String = "0")
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

    'TODO: INSTANT VB TODO TASK: Assignments within expressions are not supported in VB.NET
    'ORIGINAL LINE: protected void loadVariables(string catID="0")
    Protected Sub loadVariables(Optional catID As String = "0")
        If catID = "" Then
            catID = "0"
        End If
        Using con As New SqlConnection(strConnString)
            Using sda As New SqlDataAdapter()
                Dim query As String = "SELECT * FROM entity_scoring_variables where active='1' and category_id='" & catID & "'"
                Dim cmd As New SqlCommand(query)
                cmd.Connection = con
                sda.SelectCommand = cmd
                Using ds As New DataSet()
                    sda.Fill(ds)
                    CreditManager.loadCombo(ds.Tables(0), cmbRatingVariable, "description", "id")
                End Using
            End Using
        End Using
    End Sub

    Protected Sub cmbEntityType_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbEntityType.SelectedIndexChanged
        loadCategories(cmbEntityType.SelectedValue)
        loadVariables()
        bindRanges()
        inputSelect(cmbRatingVariable.SelectedValue)
    End Sub

    Protected Sub cmbRatingVariable_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbRatingVariable.SelectedIndexChanged
        bindRanges(cmbRatingVariable.SelectedValue)
        inputSelect(cmbRatingVariable.SelectedValue)
    End Sub

    Protected Sub cmbRatingCategory_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbRatingCategory.SelectedIndexChanged
        loadVariables(cmbRatingCategory.SelectedValue)
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

    Protected Sub grdVariable_RowCancelingEdit(sender As Object, e As GridViewCancelEditEventArgs) Handles grdVariable.RowCancelingEdit
        grdVariable.EditIndex = -1
        bindRanges(cmbRatingVariable.SelectedValue)
    End Sub

    Protected Sub grdVariable_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles grdVariable.RowDataBound
        If txtValueType.Text = "A" Then
            e.Row.Cells(5).Visible = False
        ElseIf txtValueType.Text = "R" Then
            e.Row.Cells(5).Visible = True
        End If
        'End If
        If e.Row.RowType = DataControlRowType.Header Then
            If txtValueType.Text = "A" Then
                e.Row.Cells(4).Text = "Value"
            ElseIf txtValueType.Text = "R" Then
                e.Row.Cells(5).Text = "Upper Value"
            End If
        End If
    End Sub

    Protected Sub grdVariable_RowDeleting(sender As Object, e As GridViewDeleteEventArgs) Handles grdVariable.RowDeleting

    End Sub

    Protected Sub grdVariable_RowEditing(sender As Object, e As GridViewEditEventArgs) Handles grdVariable.RowEditing
        variableEditID = DirectCast(grdVariable.Rows(e.NewEditIndex).FindControl("txtRangeId0"), TextBox).Text
        grdVariable.EditIndex = e.NewEditIndex
        bindRanges(cmbRatingVariable.SelectedValue)
    End Sub

    Protected Sub grdVariable_RowUpdating(sender As Object, e As GridViewUpdateEventArgs) Handles grdVariable.RowUpdating
        If Trim(variableEditID) = "" Or IsDBNull(variableEditID) Then
            msgbox("No question selected for update")
            Exit Sub
        End If
        Dim lVal As String = DirectCast(grdVariable.Rows(e.RowIndex).FindControl("txtLowerValue0Edit"), TextBox).Text
        Dim uVal As String = DirectCast(grdVariable.Rows(e.RowIndex).FindControl("txtUpperValue0Edit"), TextBox).Text
        Dim score As String = DirectCast(grdVariable.Rows(e.RowIndex).FindControl("txtScore0Edit"), TextBox).Text
        Dim scale As String = DirectCast(grdVariable.Rows(e.RowIndex).FindControl("txtScale0Edit"), TextBox).Text
        Dim comment As String = DirectCast(grdVariable.Rows(e.RowIndex).FindControl("txtComment0Edit"), TextBox).Text
        cmd = New SqlCommand("update rating_ranges set lower_range='" & lVal & "',upper_range='" & uVal & "',score='" & score & "',scale='" & scale & "',comment='" & comment & "' where id='" & variableEditID & "'", con)
        If con.State = ConnectionState.Open Then
            con.Close()
        End If
        con.Open()
        If cmd.ExecuteNonQuery Then
            msgbox("Range successfully updated")
        Else
            msgbox("Error updating range")
        End If
        con.Close()
        grdVariable.EditIndex = -1
        bindRanges(cmbRatingVariable.SelectedValue)
    End Sub
End Class