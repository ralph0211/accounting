Imports System.Data
Imports System.Data.SqlClient
Imports CreditManager

Partial Class Rating_PricingSheet
    Inherits System.Web.UI.Page
    Protected inputSelector As String = ""
    Private strConnString As String = ConfigurationManager.ConnectionStrings("Constring").ConnectionString
    Dim cmd As SqlCommand
    Dim con As New SqlConnection

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        Page.MaintainScrollPositionOnPostBack = True
        con = New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
        If (Not IsPostBack) Then
            loadEntities()
        End If

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

    Protected Sub btnAddClass_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAddClass.Click
        addClass()
    End Sub

    Protected Sub addClass()
        Try
            Using con As New SqlConnection(strConnString)
                Using sda As New SqlDataAdapter()
                    Dim query As String = ""
                    query = "INSERT INTO rating_sheet(entity_id,lower_range,upper_range,class,premium,reject,letter_class,S_P,moody,recommended) values ('" & cmbEntityType.SelectedValue & "','" & txtLowerRange.Text & "','" & txtUpperRange.Text & "','" & txtClass.Text & "','" & txtPremium.Text & "','" & chkRejectApp.Checked & "','" & txtLetterClass.Text & "','" & txtSPRating.Text & "','" & txtMoodyRating.Text & "','" & txtRecPerc.Text & "')"
                    Dim cmd As New SqlCommand(query)
                    cmd.Connection = con
                    sda.SelectCommand = cmd
                    If con.State = ConnectionState.Open Then
                        con.Close()
                    End If
                    con.Open()
                    If cmd.ExecuteNonQuery() > 0 Then
                        notify("Range was successfully added", "success")
                        txtLowerRange.Text = ""
                        txtUpperRange.Text = ""
                        txtLetterClass.Text = ""
                        txtPremium.Text = ""
                        txtSPRating.Text = ""
                        txtMoodyRating.Text = ""
                        chkRejectApp.Checked = False
                        bindRanges(cmbEntityType.SelectedValue)
                    Else
                        notify("Error adding variable", "error")
                    End If
                    con.Close()
                End Using
            End Using
        Catch ex As Exception
            notify(ex.Message, "error")
            ErrorLogging.WriteLogFile(Session("UserId"), "Rating/PricingSheet --- addClass()", ex.Message)
        End Try
    End Sub

    'TODO: INSTANT VB TODO TASK: Assignments within expressions are not supported in VB.NET
    'ORIGINAL LINE: protected void bindRanges(string entityID = "0")
    Protected Sub bindRanges(Optional entityID As String = "0")
        If entityID = "" Then
            entityID = "0"
        End If
        Using con As New SqlConnection(strConnString)
            Using sda As New SqlDataAdapter()
                'Dim query As String = "SELECT [id],[entity_id],[class],[lower_range],[upper_range],[premium],case when ISNULL(reject,0)=0 then 'false' else 'true' end as [reject] FROM rating_sheet where entity_id='" & entityID & "'"
                Dim query As String = "SELECT [id],[entity_id],[class],[lower_range],[upper_range],[premium],isnull(letter_class,'') as [letter_class],isnull(s_p,'') as [s_p],isnull(moody,'') as [moody],case when ISNULL(reject,0)=0 then 'false' else 'true' end as [reject],recommended FROM rating_sheet where entity_id='" & entityID & "' order by lower_range"
                Dim cmd As New SqlCommand(query)
                cmd.Connection = con
                sda.SelectCommand = cmd
                Using ds As New DataSet()
                    sda.Fill(ds)
                    CreditManager.bindGrid(ds.Tables(0), grdClass)
                End Using
            End Using
        End Using
    End Sub

    Protected Sub cmbEntityType_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        bindRanges(cmbEntityType.SelectedValue)
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

    Protected Sub grdClass_RowCancelingEdit(sender As Object, e As GridViewCancelEditEventArgs) Handles grdClass.RowCancelingEdit
        grdClass.EditIndex = -1
        bindRanges(cmbEntityType.SelectedValue)
    End Sub

    Protected Sub grdClass_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles grdClass.RowDataBound

    End Sub

    Protected Sub grdClass_RowDeleting(sender As Object, e As GridViewDeleteEventArgs) Handles grdClass.RowDeleting

    End Sub

    Protected Sub grdClass_RowEditing(sender As Object, e As GridViewEditEventArgs) Handles grdClass.RowEditing
        ViewState("classEditID") = DirectCast(grdClass.Rows(e.NewEditIndex).FindControl("txtClassId0"), TextBox).Text
        grdClass.EditIndex = e.NewEditIndex
        bindRanges(cmbEntityType.SelectedValue)
    End Sub

    Protected Sub grdClass_RowUpdating(sender As Object, e As GridViewUpdateEventArgs) Handles grdClass.RowUpdating
        If Trim(ViewState("classEditID")) = "" Or IsDBNull(ViewState("classEditID")) Then
            notify("No class selected for update", "error")
            Exit Sub
        End If
        Dim lVal As String = DirectCast(grdClass.Rows(e.RowIndex).FindControl("txtLowerValue0Edit"), TextBox).Text
        Dim clas As String = DirectCast(grdClass.Rows(e.RowIndex).FindControl("txtClass0Edit"), TextBox).Text
        Dim letClass As String = DirectCast(grdClass.Rows(e.RowIndex).FindControl("txtLetterClass0Edit"), TextBox).Text
        Dim uVal As String = DirectCast(grdClass.Rows(e.RowIndex).FindControl("txtUpperValue0Edit"), TextBox).Text
        Dim sp As String = DirectCast(grdClass.Rows(e.RowIndex).FindControl("txtSP0Edit"), TextBox).Text
        Dim moody As String = DirectCast(grdClass.Rows(e.RowIndex).FindControl("txtMoody0Edit"), TextBox).Text
        Dim premium As String = DirectCast(grdClass.Rows(e.RowIndex).FindControl("txtPremium0Edit"), TextBox).Text
        Dim recommended As String = DirectCast(grdClass.Rows(e.RowIndex).FindControl("txtRecommend0Edit"), TextBox).Text
        Dim reject As String = DirectCast(grdClass.Rows(e.RowIndex).FindControl("chkReject0Edit"), CheckBox).Checked
        cmd = New SqlCommand("update rating_sheet set class='" & clas & "',lower_range='" & lVal & "',upper_range='" & uVal & "',premium='" & premium & "',reject='" & reject & "',letter_class='" & letClass & "',s_p='" & sp & "',moody='" & moody & "',recommended='" & recommended & "' where id='" & ViewState("classEditID") & "'", con)
        If con.State = ConnectionState.Open Then
            con.Close()
        End If
        con.Open()
        If cmd.ExecuteNonQuery Then
            notify("Grade successfully updated", "success")
        Else
            notify("Error updating grade", "error")
        End If
        con.Close()
        grdClass.EditIndex = -1
        bindRanges(cmbEntityType.SelectedValue)
    End Sub
End Class