Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports CreditManager
Imports ErrorLogging

Partial Class Accounting_AccountsCreation
    Inherits System.Web.UI.Page

    Protected Sub loadBSItems(subCat As String)
        Try
            Using con = New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd = New SqlCommand("select * from BalanceSheetItems where [SubCategoryId]='" & subCat & "'", con)
                    Dim ds As New DataSet
                    Using adp = New SqlDataAdapter(cmd)
                        adp.Fill(ds, "Clients")
                    End Using
                    'loadCombo(ds.Tables(0), cmbBSItem, "ItemName", "id")
                End Using
            End Using
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- loadBSItems()", ex.ToString)
        End Try
    End Sub

    Protected Sub loadCategories(stmt As String)
        Try
            Using con = New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd = New SqlCommand("select id,Statement +' --- '+Category as disp from StatementCategories where Statement='" & stmt & "'", con)
                    Dim ds As New DataSet
                    Using adp = New SqlDataAdapter(cmd)
                        adp.Fill(ds)
                    End Using
                    loadCombo(ds.Tables(0), cmbCategory, "disp", "id")
                End Using
            End Using
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- loadCategories()", ex.ToString)
        End Try
    End Sub

    Protected Sub loadCategories(cmb As DropDownList, stmt As String)
        Try
            Using con = New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd = New SqlCommand("select id,Statement +' --- '+Category as disp from StatementCategories where Statement='" & stmt & "'", con)
                    Dim ds As New DataSet
                    Using adp = New SqlDataAdapter(cmd)
                        adp.Fill(ds)
                    End Using
                    loadCombo(ds.Tables(0), cmb, "disp", "id")
                End Using
            End Using
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- loadCategories()", ex.ToString)
        End Try
    End Sub
    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            If IsNumeric(ViewState("MinAccNo")) And IsNumeric(ViewState("MaxAccNo")) Then
                If txtAccNumber.Text > ViewState("MaxAccNo") Or txtAccNumber.Text < ViewState("MinAccNo") Then
                    notify("Entered account number out Of range", "error")
                    Exit Sub
                End If
            End If
            Using con = New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd = New SqlCommand("insert into tbl_FinancialAccountsCreation (AccountName,MainAccount,Type,Category,Sub,Description) values (@AccountName,@MainAccount,@Type,@Category,@Sub,@Description)", con)
                    cmd.Parameters.AddWithValue("@AccountName", txtAccountName.Text)
                    cmd.Parameters.AddWithValue("@MainAccount", txtAccNumber.Text)
                    cmd.Parameters.AddWithValue("@Type", rdbAccType.SelectedValue)
                    cmd.Parameters.AddWithValue("@Sub", cmbSubCategory.SelectedValue)
                    cmd.Parameters.AddWithValue("@Category", cmbCategory.SelectedValue)
                    cmd.Parameters.AddWithValue("@Description", txtAccDesc.Text)
                    con.Open()
                    If cmd.ExecuteNonQuery Then
                        notify("Account created", "success")
                        loadAccounts()
                        rdbAccType.ClearSelection()
                        txtAccDesc.Text = ""
                        txtAccNumber.Text = ""
                        txtAccountName.Text = ""
                        cmbCategory.ClearSelection()
                        cmbSubCategory.ClearSelection()
                    Else
                        notify("Error creating account", "error")
                    End If
                    con.Close()
                End Using
            End Using
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- btnSave_Click()", ex.ToString)
        End Try
    End Sub

    Private Sub Accounting_AccountsCreation_Load(sender As Object, e As EventArgs) Handles Me.Load
        Page.MaintainScrollPositionOnPostBack = True
        If Not IsPostBack Then
            loadAccounts()
        End If
    End Sub
    Protected Sub rdbAccType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rdbAccType.SelectedIndexChanged
        Try
            loadCategories(rdbAccType.SelectedValue)
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub cmbCategory_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCategory.SelectedIndexChanged
        Try
            loadSubCategories(cmbCategory.SelectedValue)
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub loadSubCategories(cat As String)
        Try
            Using con = New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd = New SqlCommand("select * from tbl_FinancialCategory where [Category]='" & cat & "'", con)
                    Dim ds As New DataSet
                    Using adp = New SqlDataAdapter(cmd)
                        adp.Fill(ds, "Clients")
                    End Using
                    loadCombo(ds.Tables(0), cmbSubCategory, "SubType", "id")
                End Using
            End Using
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub loadSubCategories(cmbCat As DropDownList, cmbSubCat As DropDownList)
        Try
            Using con = New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd = New SqlCommand("select * from tbl_FinancialCategory where [Category]='" & cmbCat.SelectedValue & "'", con)
                    Dim ds As New DataSet
                    Using adp = New SqlDataAdapter(cmd)
                        adp.Fill(ds, "Clients")
                    End Using
                    loadCombo(ds.Tables(0), cmbSubCat, "SubType", "id")
                End Using
            End Using
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub loadAccounts()
        Try
            Using con = New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd = New SqlCommand("select fin.ID as 'SysID', AccountName, MainAccount, SubAccount,sc.Statement as [Type],sc.Category,subCat.SubType as [SubCategory],bsi.ItemName as [Balance Sheet Item], TaxMode, Description,fin.category as CatID,fin.Sub as SubCatID from tbl_FinancialAccountsCreation fin LEFT JOIN tbl_FinancialCategory subCat ON fin.Sub=convert(varchar,Subcat.id) LEFT JOIN statementCategories sc ON subCat.category=convert(varchar,sc.id) LEFT JOIN balancesheetitems bsi ON convert(varchar,bsi.id)=convert(varchar,fin.BSItemId) order by MainAccount", con)
                    Dim dt As New DataTable
                    Using adp = New SqlDataAdapter(cmd)
                        adp.Fill(dt)
                    End Using
                    bindGrid(dt, grdAccounts)
                End Using
            End Using
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- loadAccounts()", ex.ToString)
        End Try
    End Sub

    Private Sub grdAccounts_RowCancelingEdit(sender As Object, e As GridViewCancelEditEventArgs) Handles grdAccounts.RowCancelingEdit
        grdAccounts.EditIndex = -1
        loadAccounts()
    End Sub

    Private Sub grdAccounts_RowDeleting(sender As Object, e As GridViewDeleteEventArgs) Handles grdAccounts.RowDeleting
        Try
            ViewState("accEditID") = DirectCast(grdAccounts.Rows(e.RowIndex).FindControl("txtGrdID"), TextBox).Text
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd = New SqlCommand("delete from [tbl_FinancialAccountsCreation] where id='" & ViewState("accEditID") & "'", con)
                    If con.State = ConnectionState.Open Then
                        con.Close()
                    End If
                    con.Open()
                    If cmd.ExecuteNonQuery Then
                        notify("Successfully deleted", "success")
                    Else
                        notify("Error deleting", "error")
                    End If
                    con.Close()
                    loadAccounts()
                End Using
            End Using
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- grdAccounts_RowDeleting()", ex.ToString)
        End Try
    End Sub

    Private Sub grdAccounts_RowEditing(sender As Object, e As GridViewEditEventArgs) Handles grdAccounts.RowEditing
        Try
            ViewState("accEditID") = DirectCast(grdAccounts.Rows(e.NewEditIndex).FindControl("txtGrdID"), TextBox).Text
            grdAccounts.EditIndex = e.NewEditIndex
            loadAccounts()
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- grdAccounts_RowEditing()", ex.ToString)
        End Try
    End Sub

    Private Sub grdAccounts_RowUpdating(sender As Object, e As GridViewUpdateEventArgs) Handles grdAccounts.RowUpdating
        Try
            If Trim(ViewState("accEditID")) = "" Or IsDBNull(ViewState("accEditID")) Then
                notify("No record selected for update", "error")
                Exit Sub
            End If
            Dim cmbCat As DropDownList = DirectCast(grdAccounts.Rows(e.RowIndex).FindControl("cmbGrdCategory"), DropDownList)
            Dim cmbSubCat As DropDownList = DirectCast(grdAccounts.Rows(e.RowIndex).FindControl("cmbGrdSubCategory"), DropDownList)
            Dim cmbTyp As DropDownList = DirectCast(grdAccounts.Rows(e.RowIndex).FindControl("cmbGrdType"), DropDownList)
            Dim tAccName As TextBox = DirectCast(grdAccounts.Rows(e.RowIndex).FindControl("txtGrdAccountName"), TextBox)
            Dim tAccNo As TextBox = DirectCast(grdAccounts.Rows(e.RowIndex).FindControl("txtGrdMainAccount"), TextBox)
            Dim tAccDesc As TextBox = DirectCast(grdAccounts.Rows(e.RowIndex).FindControl("txtGrdDescription"), TextBox)

            If cmbTyp.SelectedValue = "" Then
                notify("Select account type", "error")
            ElseIf Trim(tAccName.Text) = "" Then
                notify("Enter the account name", "error")
            ElseIf Trim(cmbCat.SelectedValue) = "" Then
                notify("Select the account category", "error")
            ElseIf Trim(cmbSubCat.SelectedValue) = "" Then
                notify("Select the account sub category", "error")
            ElseIf Trim(tAccNo.Text) = "" Then
                notify("Enter the account number", "error")
            Else
                Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                    Using cmd = New SqlCommand("update [tbl_FinancialAccountsCreation] set [Category]=@Category,AccountName=@AccountName,MainAccount=@MainAccount,Type=@Type,Sub=@Sub,Description=@Description where id='" & ViewState("accEditID") & "'", con)
                        cmd.Parameters.AddWithValue("@AccountName", tAccName.Text)
                        cmd.Parameters.AddWithValue("@MainAccount", tAccNo.Text)
                        cmd.Parameters.AddWithValue("@Type", cmbTyp.SelectedValue)
                        cmd.Parameters.AddWithValue("@Sub", cmbSubCat.SelectedValue)
                        cmd.Parameters.AddWithValue("@Category", cmbCat.SelectedValue)
                        cmd.Parameters.AddWithValue("@Description", tAccDesc.Text)
                        con.Open()
                        If cmd.ExecuteNonQuery Then
                            notify("Successfully updated", "success")
                        Else
                            notify("Error updating value", "error")
                        End If
                        con.Close()
                        grdAccounts.EditIndex = -1
                        loadAccounts()
                    End Using
                End Using
            End If
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- grdCategories_RowUpdating()", ex.ToString)
        End Try
    End Sub
    Protected Sub cmbSubCategory_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSubCategory.SelectedIndexChanged
        Try
            Using con = New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd = New SqlCommand("select * from tbl_FinancialCategory where [id]='" & cmbSubCategory.SelectedValue & "'", con)
                    Dim dt As New DataTable
                    Using adp = New SqlDataAdapter(cmd)
                        adp.Fill(dt)
                    End Using
                    If dt.Rows.Count > 0 Then
                        ViewState("MinAccNo") = BankString.isNullString(dt.Rows(0).Item("MinAccount"))
                        ViewState("MaxAccNo") = BankString.isNullString(dt.Rows(0).Item("MaxAccount"))
                        lblAccNoRange.Text = "Range of account numbers is :" & ViewState("MinAccNo") & " to " & ViewState("MaxAccNo")
                    End If
                End Using
            End Using
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- cmbSubCategory_SelectedIndexChanged()", ex.ToString)
        End Try
    End Sub

    Private Sub grdAccounts_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles grdAccounts.RowDataBound
        Try
            If (e.Row.RowType = DataControlRowType.DataRow And grdAccounts.EditIndex = e.Row.RowIndex) Then
                'msgbox(DirectCast(e.Row.FindControl("grdUsers_txtUserType"), TextBox).Text)
                Dim cmbType = DirectCast(e.Row.FindControl("cmbGrdType"), DropDownList)
                'loadCategories(cmbCategory, cmbEntityType.SelectedValue)
                Try
                    cmbType.SelectedValue = DirectCast(e.Row.FindControl("txtGrdType"), TextBox).Text
                Catch ex As Exception
                    cmbType.ClearSelection()
                End Try
                cmbType.AutoPostBack = True

                Dim cmbCat = DirectCast(e.Row.FindControl("cmbGrdCategory"), DropDownList)
                loadCategories(cmbCat, cmbType.SelectedValue)
                'msgbox(DirectCast(e.Row.FindControl("txtGrdCategory"), TextBox).Text)
                Try
                    cmbCat.SelectedValue = DirectCast(e.Row.FindControl("txtGrdCategory"), TextBox).Text
                Catch ex As Exception
                    cmbCat.ClearSelection()
                End Try

                Dim cmbSubCat = DirectCast(e.Row.FindControl("cmbGrdSubCategory"), DropDownList)
                loadSubCategories(cmbCat, cmbSubCat)
                Try
                    cmbSubCat.SelectedValue = DirectCast(e.Row.FindControl("txtGrdSubCategory"), TextBox).Text
                Catch ex As Exception
                    cmbSubCat.ClearSelection()
                End Try
            End If
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- grdAccounts_RowDataBound()", ex.ToString)
        End Try
    End Sub
    Protected Sub cmbGrdType_SelectedIndexChanged(sender As Object, e As EventArgs)
        Try
            Dim row As GridViewRow = grdAccounts.Rows(grdAccounts.EditIndex)
            Dim cmbType = DirectCast(row.FindControl("cmbGrdType"), DropDownList)
            Dim cmbCat = DirectCast(row.FindControl("cmbGrdCategory"), DropDownList)

            loadCategories(cmbCat, cmbType.SelectedValue)
            Try
                cmbCat.SelectedValue = DirectCast(row.FindControl("txtGrdCategory"), TextBox).Text
            Catch ex As Exception
                cmbCat.ClearSelection()
            End Try

            Dim cmbSubCat = DirectCast(row.FindControl("cmbGrdSubCategory"), DropDownList)
            loadSubCategories(cmbCat, cmbSubCat)
            Try
                cmbSubCat.SelectedValue = DirectCast(row.FindControl("txtGrdSubCategory"), TextBox).Text
            Catch ex As Exception
                cmbSubCat.ClearSelection()
            End Try
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- cmbGrdType_SelectedIndexChanged()", ex.ToString)
        End Try
    End Sub
    Protected Sub cmbGrdCategory_SelectedIndexChanged(sender As Object, e As EventArgs)
        Try
            Dim row As GridViewRow = grdAccounts.Rows(grdAccounts.EditIndex)
            'Dim cmbType = DirectCast(row.FindControl("cmbGrdType"), DropDownList)
            Dim cmbCat = DirectCast(row.FindControl("cmbGrdCategory"), DropDownList)

            'loadCategories(cmbCat, cmbType.SelectedValue)
            'Try
            '    cmbCat.SelectedValue = DirectCast(row.FindControl("txtGrdCategory"), TextBox).Text
            'Catch ex As Exception
            '    cmbCat.ClearSelection()
            'End Try

            Dim cmbSubCat = DirectCast(row.FindControl("cmbGrdSubCategory"), DropDownList)
            loadSubCategories(cmbCat, cmbSubCat)
            Try
                cmbSubCat.SelectedValue = DirectCast(row.FindControl("txtGrdSubCategory"), TextBox).Text
            Catch ex As Exception
                cmbSubCat.ClearSelection()
            End Try
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- cmbGrdCategory_SelectedIndexChanged()", ex.ToString)
        End Try
    End Sub
End Class