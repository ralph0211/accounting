Imports System.Data
Imports System.Data.SqlClient
Imports CreditManager
Imports ErrorLogging

Partial Class Accounting_AccountSetup
    Inherits System.Web.UI.Page

    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            Using con = New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd = New SqlCommand("insert into StatementCategories (Statement,Category) values (@Statement,@Category)", con)
                    cmd.Parameters.AddWithValue("@Statement", rdbStatementType.SelectedValue)
                    cmd.Parameters.AddWithValue("@Category", txtCategory.Text)
                    con.Open()
                    If cmd.ExecuteNonQuery() Then
                        notify("Category saved", "success")
                        getCategories()
                        loadCategories()
                        rdbStatementType.ClearSelection()
                        txtCategory.Text = ""
                    Else
                        notify("Error saving category", "error")
                    End If
                    con.Close()
                End Using
            End Using
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- btnSave_Click()", ex.ToString)
        End Try
    End Sub

    Protected Sub btnSaveItem_Click(sender As Object, e As EventArgs) Handles btnSaveItem.Click
        Try
            Using con = New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd = New SqlCommand("insert into BalanceSheetItems (SubCategoryId,ItemName) values (@SubCategoryId,@ItemName)", con)
                    cmd.Parameters.AddWithValue("@SubCategoryId", cmbSubCategory.SelectedValue)
                    cmd.Parameters.AddWithValue("@ItemName", txtItemName.Text)
                    con.Open()
                    If cmd.ExecuteNonQuery() Then
                        notify("Balance Sheet Item saved", "success")
                        getBalanceSheetItems()
                        'getCategories()
                        'loadCategories()
                        cmbSubCategory.ClearSelection()
                        txtItemName.Text = ""
                    Else
                        notify("Error saving category", "error")
                    End If
                    con.Close()
                End Using
            End Using
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- btnSaveItem_Click()", ex.ToString)
        End Try
    End Sub

    Protected Sub btnSaveSubCategory_Click(sender As Object, e As EventArgs) Handles btnSaveSubCategory.Click
        Try
            Using con = New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd = New SqlCommand("insert into tbl_FinancialCategory (Type,SubType,Category,MinAccount,MaxAccount) values (@Type,@SubType,@Category,@MinAccount,@MaxAccount)", con)
                    cmd.Parameters.AddWithValue("@Type", "")
                    cmd.Parameters.AddWithValue("@SubType", txtSubCategory.Text)
                    cmd.Parameters.AddWithValue("@Category", cmbCategory.SelectedValue)
                    cmd.Parameters.AddWithValue("@MinAccount", txtMinAccNo.Text)
                    cmd.Parameters.AddWithValue("@MaxAccount", txtMaxAccNo.Text)
                    con.Open()
                    If cmd.ExecuteNonQuery() Then
                        notify("Category saved", "success")
                        getSubCategories()
                        cmbCategory.ClearSelection()
                        txtSubCategory.Text = ""
                    Else
                        notify("Error saving category", "error")
                    End If
                    con.Close()
                End Using
            End Using
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- btnSave_Click()", ex.ToString)
        End Try
    End Sub

    Protected Sub getBalanceSheetItems()
        Try
            Using con = New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd = New SqlCommand("select fin.SubType as [Sub Category],bsi.ItemName as [Item] from StatementCategories sc join tbl_FinancialCategory fin on sc.id=fin.Category JOIN BalanceSheetItems bsi ON fin.ID=bsi.SubCategoryId WHERE sc.Statement='Balance Sheet'", con)
                    Dim ds As New DataSet
                    Using adp = New SqlDataAdapter(cmd)
                        adp.Fill(ds)
                    End Using
                    bindGrid(ds.Tables(0), grdBalanceSheetItems)
                End Using
            End Using
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- getBalanceSheetItems()", ex.ToString)
        End Try
    End Sub

    Protected Sub getCategories()
        Try
            Using con = New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd = New SqlCommand("select id,Statement,Category from StatementCategories", con)
                    Dim ds As New DataSet
                    Using adp = New SqlDataAdapter(cmd)
                        adp.Fill(ds)
                    End Using
                    bindGrid(ds.Tables(0), grdCategories)
                End Using
            End Using
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- getCategories()", ex.ToString)
        End Try
    End Sub

    Protected Sub getSubCategories()
        Try
            Using con = New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd = New SqlCommand("select fin.id,sc.Statement,sc.Category,fin.SubType as [SubCategory],[MinAccount],[MaxAccount] from StatementCategories sc join tbl_FinancialCategory fin on convert(varchar,sc.id)=fin.Category", con)
                    Dim ds As New DataSet
                    Using adp = New SqlDataAdapter(cmd)
                        adp.Fill(ds)
                    End Using
                    bindGrid(ds.Tables(0), grdSubCategory)
                End Using
            End Using
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- getSubCategories()", ex.ToString)
        End Try
    End Sub
    Protected Sub grdCategories_RowCancelingEdit(sender As Object, e As GridViewCancelEditEventArgs) Handles grdCategories.RowCancelingEdit
        grdCategories.EditIndex = -1
        getCategories()
    End Sub

    Protected Sub grdCategories_RowDeleting(sender As Object, e As GridViewDeleteEventArgs) Handles grdCategories.RowDeleting
        Try
            ViewState("catEditID") = DirectCast(grdCategories.Rows(e.RowIndex).FindControl("txtGrdID"), TextBox).Text
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd = New SqlCommand("delete from [StatementCategories] where id='" & ViewState("catEditID") & "'", con)
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
                    getCategories()
                End Using
            End Using
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- grdCategories_RowDeleting()", ex.ToString)
        End Try
    End Sub
    Protected Sub grdSubCategory_RowCancelingEdit(sender As Object, e As GridViewCancelEditEventArgs) Handles grdSubCategory.RowCancelingEdit
        grdSubCategory.EditIndex = -1
        getSubCategories()
    End Sub

    Protected Sub grdSubCategory_RowDeleting(sender As Object, e As GridViewDeleteEventArgs) Handles grdSubCategory.RowDeleting
        Try
            ViewState("subcatEditID") = DirectCast(grdCategories.Rows(e.RowIndex).FindControl("txtGrdID"), TextBox).Text
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd = New SqlCommand("delete from [tbl_FinancialCategory] where id='" & ViewState("subcatEditID") & "'", con)
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
                    getSubCategories()
                End Using
            End Using
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- grdSubCategory_RowDeleting()", ex.ToString)
        End Try
    End Sub

    Protected Sub loadBalanceSheetSubCategories()
        Try
            Using con = New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd = New SqlCommand("select fin.id,sc.Category +' --- '+fin.SubType as [SubCategory] from StatementCategories sc join tbl_FinancialCategory fin on sc.id=fin.Category WHERE sc.Statement='Balance Sheet'", con)
                    Dim ds As New DataSet
                    Using adp = New SqlDataAdapter(cmd)
                        adp.Fill(ds)
                    End Using
                    loadCombo(ds.Tables(0), cmbSubCategory, "SubCategory", "id")
                End Using
            End Using
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- loadBalanceSheetSubCategories()", ex.ToString)
        End Try
    End Sub
    Protected Sub grdCategories_RowEditing(sender As Object, e As GridViewEditEventArgs) Handles grdCategories.RowEditing
        Try
            ViewState("catEditID") = DirectCast(grdCategories.Rows(e.NewEditIndex).FindControl("txtGrdID"), TextBox).Text
            grdCategories.EditIndex = e.NewEditIndex
            getCategories()
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- grdCategories_RowEditing()", ex.ToString)
        End Try
    End Sub

    Protected Sub grdCategories_RowUpdating(sender As Object, e As GridViewUpdateEventArgs) Handles grdCategories.RowUpdating
        Try
            If Trim(ViewState("catEditID")) = "" Or IsDBNull(ViewState("catEditID")) Then
                CreditManager.notify("No record selected for update", "error")
                Exit Sub
            End If
            Dim cat As String = DirectCast(grdCategories.Rows(e.RowIndex).FindControl("txtGrdCategory"), TextBox).Text
            Dim cmbStmt As DropDownList = DirectCast(grdCategories.Rows(e.RowIndex).FindControl("cmbGrdStatement"), DropDownList)

            If Trim(cmbStmt.SelectedValue) = "" Then
                notify("Select the statement for category", "error")
            Else
                Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                    Using cmd = New SqlCommand("update [StatementCategories] set [Category]='" & cat.Replace("'", "''") & "',Statement='" & cmbStmt.SelectedValue & "' where id='" & ViewState("catEditID") & "'", con)
                        If con.State <> ConnectionState.Closed Then
                            con.Close()
                        End If
                        con.Open()
                        If cmd.ExecuteNonQuery Then
                            CreditManager.notify("Successfully updated", "success")
                        Else
                            CreditManager.notify("Error updating value", "error")
                        End If
                        con.Close()
                        grdCategories.EditIndex = -1
                        getCategories()
                    End Using
                End Using
            End If
        Catch ex As Exception
            ErrorLogging.WriteLogFile(Session("UserId"), Request.Url.ToString & " --- grdCategories_RowUpdating()", ex.ToString)
        End Try
    End Sub
    Protected Sub grdSubCategory_RowEditing(sender As Object, e As GridViewEditEventArgs) Handles grdSubCategory.RowEditing
        Try
            ViewState("subcatEditID") = DirectCast(grdSubCategory.Rows(e.NewEditIndex).FindControl("txtGrdID"), TextBox).Text
            grdSubCategory.EditIndex = e.NewEditIndex
            getSubCategories()
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- grdSubCategory_RowEditing()", ex.ToString)
        End Try
    End Sub

    Protected Sub grdSubCategory_RowUpdating(sender As Object, e As GridViewUpdateEventArgs) Handles grdSubCategory.RowUpdating
        Try
            If Trim(ViewState("subcatEditID")) = "" Or IsDBNull(ViewState("subcatEditID")) Then
                CreditManager.notify("No record selected for update", "error")
                Exit Sub
            End If
            Dim cat As String = DirectCast(grdSubCategory.Rows(e.RowIndex).FindControl("txtGrdSubCategory"), TextBox).Text
            Dim MinAccount As String = DirectCast(grdSubCategory.Rows(e.RowIndex).FindControl("txtGrdMinAccount"), TextBox).Text
            Dim MaxAccount As String = DirectCast(grdSubCategory.Rows(e.RowIndex).FindControl("txtGrdMaxAccount"), TextBox).Text

            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd = New SqlCommand("update [tbl_FinancialCategory] set [SubType]='" & cat.Replace("'", "''") & "',MaxAccount='" & MaxAccount & "',MinAccount='" & MinAccount & "' where id='" & ViewState("subcatEditID") & "'", con)
                    If con.State <> ConnectionState.Closed Then
                        con.Close()
                    End If
                    con.Open()
                    If cmd.ExecuteNonQuery Then
                        CreditManager.notify("Successfully updated", "success")
                    Else
                        CreditManager.notify("Error updating value", "error")
                    End If
                    con.Close()
                    grdSubCategory.EditIndex = -1
                    getSubCategories()
                End Using
            End Using
        Catch ex As Exception
            ErrorLogging.WriteLogFile(Session("UserId"), Request.Url.ToString & " --- grdSubCategory_RowUpdating()", ex.ToString)
        End Try
    End Sub

    Protected Sub loadCategories()
        Try
            Using con = New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd = New SqlCommand("select id,Statement+' --- '+Category as disp from StatementCategories", con)
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

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Page.MaintainScrollPositionOnPostBack = True
        If Not IsPostBack Then
            getCategories()
            loadCategories()
            getSubCategories()
            loadBalanceSheetSubCategories()
            getBalanceSheetItems()
            loadAccounts()
        Else
            TabName.Value = Request.Form(TabName.UniqueID)
        End If
    End Sub

    Private Sub grdCategories_RowCreated(sender As Object, e As GridViewRowEventArgs) Handles grdCategories.RowCreated
        'Try
        '    If e.Row.RowType = DataControlRowType.DataRow And e.Row.RowIndex = grdCategories.EditIndex Then
        '        Dim r As GridViewRow = e.Row
        '        Dim cmbType As DropDownList = r.FindControl("cmbGrdStatement")
        '        cmbType.AppendDataBoundItems = True
        '        cmbType.Items.Add("")
        '        cmbType.Items.Add("PL")
        '        cmbType.Items.Add("BS")
        '    End If
        'Catch ex As Exception
        '    WriteLogFile(Session("UserId"), Request.Url.ToString & " --- grdCategories_RowCreated()", ex.ToString)
        'End Try
    End Sub

    Private Sub grdCategories_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles grdCategories.RowDataBound
        Try
            If (e.Row.RowType = DataControlRowType.DataRow And grdCategories.EditIndex = e.Row.RowIndex) Then
                Dim r As GridViewRow = e.Row
                Dim cmbType As DropDownList = DirectCast(r.FindControl("cmbGrdStatement"), DropDownList)
                cmbType.Items.Clear()
                cmbType.AppendDataBoundItems = True
                cmbType.Items.Add("")
                cmbType.Items.Add("PL")
                cmbType.Items.Add("BS")

                Try
                    cmbType.SelectedValue = DirectCast(e.Row.FindControl("txtGrdStatement"), TextBox).Text
                Catch ex As Exception
                    cmbType.ClearSelection()
                End Try
            End If
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- grdCategories_RowDataBound()", ex.ToString)
        End Try
    End Sub






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
                    loadCombo(ds.Tables(0), cmbCategoryAcc, "disp", "id")
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
    Protected Sub btnSaveAcc_Click(sender As Object, e As EventArgs) Handles btnSaveAcc.Click
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
                    cmd.Parameters.AddWithValue("@Sub", cmbSubCategoryAcc.SelectedValue)
                    cmd.Parameters.AddWithValue("@Category", cmbCategoryAcc.SelectedValue)
                    cmd.Parameters.AddWithValue("@Description", txtAccDesc.Text)
                    con.Open()
                    If cmd.ExecuteNonQuery Then
                        notify("Account created", "success")
                        loadAccounts()
                        rdbAccType.ClearSelection()
                        txtAccDesc.Text = ""
                        txtAccNumber.Text = ""
                        txtAccountName.Text = ""
                        cmbCategoryAcc.ClearSelection()
                        cmbSubCategoryAcc.ClearSelection()
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

    Protected Sub rdbAccType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rdbAccType.SelectedIndexChanged
        Try
            loadCategories(rdbAccType.SelectedValue)
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub cmbCategoryAcc_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCategoryAcc.SelectedIndexChanged
        Try
            loadSubCategories(cmbCategoryAcc.SelectedValue)
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
                    loadCombo(ds.Tables(0), cmbSubCategoryAcc, "SubType", "id")
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
    Protected Sub cmbSubCategoryAcc_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSubCategoryAcc.SelectedIndexChanged
        Try
            Using con = New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd = New SqlCommand("select * from tbl_FinancialCategory where [id]='" & cmbSubCategoryAcc.SelectedValue & "'", con)
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
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- cmbSubCategoryAcc_SelectedIndexChanged()", ex.ToString)
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
                    'WriteLogFile(DirectCast(e.Row.FindControl("txtGrdCategory"), TextBox).Text)
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
