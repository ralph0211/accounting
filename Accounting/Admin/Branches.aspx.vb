Imports System.Data
Imports System.Data.SqlClient
Imports CreditManager
Imports ErrorLogging

Partial Class Admin_Branches
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Page.MaintainScrollPositionOnPostBack = True
        'cmbBankName.Focus()
        Try
            If (Not IsPostBack) Then
                loadBranches(cmbBankUpdate.SelectedValue)
                BindBankCOmbo()
                getBank()
                getBranchCode()
            End If
            'BindGrid()

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub BindBankCOmbo()
        Dim dss As New DataSet
        Try
            Using cn As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd = New SqlCommand("select * from para_bank", cn)
                    Using adp = New SqlDataAdapter(cmd)
                        adp.Fill(dss, "para_bank")
                    End Using
                    'cmbBankName.DataSource = dss.Tables(0)
                    'cmbBankName.DataValueField = "Bank"

                    'cmbBankName.DataTextField = "bank_name"
                    'cmbBankName.DataBind()
                End Using
            End Using
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
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

    'Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
    '    Try
    '        cmd = New SqlCommand("insert into para_branch(bank,branch,branch_name) values('" & cmbBankName.SelectedValue & "','" & txtBranchCode.Text & "','" & txtBranchName.Text & "')", cn)
    '        cn.Open()
    '        cmd.ExecuteNonQuery()
    '        cn.Close()
    '        adp = New SqlDataAdapter(cmd)
    '        BindGrid()
    '        ClearAll()
    '        msgbox("Record Is Added")
    '    Catch ex As Exception
    '        cn.Close()
    '        msgbox(ex.Message)
    '    End Try
    'End Sub
    Public Sub loadBranches(bnk As String)
        Dim ds As New DataSet
        Try
            Using cn As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd = New SqlCommand("select * from para_branch where bank=@bank", cn)
                    cmd.Parameters.AddWithValue("@bank", bnk)
                    Using adp = New SqlDataAdapter(cmd)
                        adp.Fill(ds, "para_branch")
                    End Using
                    grdBank.DataSource = ds.Tables(0)
                    grdBank.DataBind()
                End Using
            End Using
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub ClearAll()
        'txtBranchCode.Text = ""
        'txtBranchName.Text = ""
    End Sub
    Protected Sub grdBank_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdBank.PageIndexChanging
        Try
            grdBank.PageIndex = e.NewPageIndex
            loadBranches(cmbBankUpdate.SelectedValue)
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub getBank()
        Try
            Dim ds As New DataSet
            Using cn As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd = New SqlCommand("Select * from para_bank ", cn)
                    Using adp = New SqlDataAdapter(cmd)
                        adp.Fill(ds, "para_bank")
                    End Using
                    loadCombo(ds.Tables(0), cmbBankUpdate, "bank_name", "bank")
                End Using
            End Using
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub getBranchCode()
        Try
            Dim ds As New DataSet
            Using cn As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd = New SqlCommand("Select * from para_branch where bank='" & cmbBankUpdate.SelectedValue & "'", cn)
                    Using adp = New SqlDataAdapter(cmd)
                        adp.Fill(ds, "para_branch")
                    End Using
                    bindGrid(ds.Tables(0), grdBank)
                End Using
            End Using
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub cmbBankUpdate_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbBankUpdate.SelectedIndexChanged
        getBranchCode()
    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            Using cn As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd = New SqlCommand("insert into para_branch (branch, branch_name, bank) values (@brnch,@bName,@bank)", cn)
                    cmd.Parameters.AddWithValue("@brnch", txtBankCodeUpdate.Text)
                    cmd.Parameters.AddWithValue("@bName", txtBankNameUpdate.Text)
                    cmd.Parameters.AddWithValue("@bank", cmbBankUpdate.SelectedValue)
                    If (cn.State = ConnectionState.Open) Then
                        cn.Close()
                    End If
                    cn.Open()
                    If cmd.ExecuteNonQuery() Then
                        notify("Branch saved", "success")
                        loadBranches(cmbBankUpdate.SelectedValue)
                        txtBankCodeUpdate.Text = ""
                        txtBankNameUpdate.Text = ""
                    Else
                        notify("Error saving branch", "error")
                    End If
                    cn.Close()
                End Using
            End Using
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Private Sub grdBank_RowCancelingEdit(sender As Object, e As GridViewCancelEditEventArgs) Handles grdBank.RowCancelingEdit
        Try
            grdBank.EditIndex = -1
            loadBranches(cmbBankUpdate.SelectedValue)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub grdBank_RowDeleting(sender As Object, e As GridViewDeleteEventArgs) Handles grdBank.RowDeleting
        ViewState("BranchEditID") = DirectCast(grdBank.Rows(e.RowIndex).FindControl("txtGrdID"), TextBox).Text
        Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
            Using cmd = New SqlCommand("delete from para_branch where ID='" & ViewState("BranchEditID") & "'", con)
                If con.State = ConnectionState.Open Then
                    con.Close()
                End If
                con.Open()
                If cmd.ExecuteNonQuery Then
                    notify("Branch successfully deleted.", "success")
                    loadBranches(cmbBankUpdate.SelectedValue)
                Else
                    notify("Error deleting branch", "error")
                End If
                con.Close()
            End Using
        End Using
    End Sub

    Private Sub grdBank_RowEditing(sender As Object, e As GridViewEditEventArgs) Handles grdBank.RowEditing
        ViewState("BranchEditID") = DirectCast(grdBank.Rows(e.NewEditIndex).FindControl("txtGrdID"), TextBox).Text
        grdBank.EditIndex = e.NewEditIndex
        loadBranches(cmbBankUpdate.SelectedValue)
    End Sub

    Private Sub grdBank_RowUpdating(sender As Object, e As GridViewUpdateEventArgs) Handles grdBank.RowUpdating
        If Trim(ViewState("BranchEditID")) = "" Or IsDBNull(ViewState("BranchEditID")) Then
            msgbox("No branch selected for update")
            Exit Sub
        End If
        Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
            Dim code As String = DirectCast(grdBank.Rows(e.RowIndex).FindControl("txtGrdBranchCode"), TextBox).Text
            Dim name = DirectCast(grdBank.Rows(e.RowIndex).FindControl("txtGrdBranchName"), TextBox).Text

            Dim oldUserStatus, oldRoleName As String
            oldUserStatus = ""
            oldRoleName = ""

            Dim updateCmd As New SqlCommand
            updateCmd = New SqlCommand("update para_branch set branch='" & BankString.removeSpecialCharacter(code) & "', branch_name='" & BankString.removeSpecialCharacter(name) & "' where ID='" & ViewState("BranchEditID") & "'", con)

            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            con.Open()
            If updateCmd.ExecuteNonQuery Then
                msgbox("Branch successfully updated")
            Else
                msgbox("Error updating branch")
            End If
            con.Close()
            grdBank.EditIndex = -1
            loadBranches(cmbBankUpdate.SelectedValue)
        End Using
    End Sub
End Class