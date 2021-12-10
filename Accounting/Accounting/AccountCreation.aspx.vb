Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports CreditManager
Imports ErrorLogging
Partial Class Accounting_AccountCreation
    Inherits System.Web.UI.Page
    Dim adp As New SqlDataAdapter
    Dim cmd As SqlCommand
    Dim con As New SqlConnection

    Public Function Checkfeilds() As Boolean
        Checkfeilds = False
        Try
            If txtAccName.Text = "" Then
                msgbox("Account Name Is Mandatory")
                txtAccName.Focus()
                Exit Function
            End If
            If txtMainAcc.Text = "" Then
                msgbox("Main Account Is Mandatory")
                txtMainAcc.Focus()
                Exit Function
            End If
            If txtSubAcc.Text = "" Then
                msgbox("Sub Account Is Mandatory")
                txtSubAcc.Focus()
                Exit Function
            End If

            cmd = New SqlCommand("select * from tbl_FinancialAccountsCreation where MainAccount='" & txtMainAcc.Text & "' and SubAccount='" & txtSubAcc.Text & "'", con)
            Dim ds As New DataSet
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "Accounts")
            If ds.Tables(0).Rows.Count > 0 Then
                msgbox("Main Account / Sub Account Must be Unique")
                txtMainAcc.Focus()
                Exit Function
            End If
            Checkfeilds = True
        Catch ex As Exception

        End Try
    End Function

    Public Function Checkfeilds1() As Boolean
        Checkfeilds1 = False
        Try
            If txtAccName.Text = "" Then
                msgbox("Account Name Is Mandatory")
                txtAccName.Focus()
                Exit Function
            End If
            If txtMainAcc.Text = "" Then
                msgbox("Main Account Is Mandatory")
                txtMainAcc.Focus()
                Exit Function
            End If
            If txtSubAcc.Text = "" Then
                msgbox("Sub Account Is Mandatory")
                txtSubAcc.Focus()
                Exit Function
            End If

            Checkfeilds1 = True
        Catch ex As Exception

        End Try
    End Function

    Public Sub ClearFeilds()
        txtMainAcc.Enabled = True
        txtAccName.Text = ""
        txtdesc.Text = ""
        txtMainAcc.Text = ""
        txtSubAcc.Text = ""
        cmbTax.ClearSelection()
        cmbType.ClearSelection()
        rdbAccountType.SelectedIndex = -1
        rdbType.SelectedIndex = -1
        cmbCategory.ClearSelection()
        cmbBSItem.ClearSelection()
    End Sub

    Public Sub DCDetails()
        ' Try
        cmd = New SqlCommand("SaveDebtorsCreditors", con)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@mainacc", txtMainAcc.Text)
        cmd.Parameters.AddWithValue("@subacc", txtSubAcc.Text)
        cmd.Parameters.AddWithValue("@accname", txtAccName.Text)
        cmd.Parameters.AddWithValue("@type", IIf(rdbType.SelectedIndex = 0, "Income", "Balance Sheet"))
        cmd.Parameters.AddWithValue("@subtype", cmbType.SelectedValue)
        cmd.Parameters.AddWithValue("@tax", cmbTax.SelectedValue)
        cmd.Parameters.AddWithValue("@description", txtdesc.Text)
        cmd.Parameters.AddWithValue("@default", cmbDefault.SelectedItem.Text)
        cmd.Parameters.AddWithValue("@PhysAdd", txtPhysAdd.Text)
        cmd.Parameters.AddWithValue("@PostAdd", txtPostAddr.Text)
        cmd.Parameters.AddWithValue("@Tel", txtTelNo.Text)
        cmd.Parameters.AddWithValue("@Fax", txtFaxNo.Text)
        cmd.Parameters.AddWithValue("@ContactPerson", txtContactPerson.Text)
        cmd.Parameters.AddWithValue("@EmailAdd", txtEmailAdd.Text)

        If con.State = ConnectionState.Open Then
            con.Close()
        End If
        con.Open()
        If cmd.ExecuteNonQuery() Then
            msgbox("Details Saved.")
            loadGrid()
            ClearFeilds()
        Else
            msgbox("Error Saving Account")
        End If
        'Catch ex As Exception

        'End Try
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

    Protected Sub btnSaveTrxn_Click(sender As Object, e As EventArgs) Handles btnSaveTrxn.Click
        Try
            If Checkfeilds() = True Then
                cmd = New SqlCommand("SaveFinancialAccounts", con)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("@mainacc", txtMainAcc.Text)
                cmd.Parameters.AddWithValue("@subacc", txtSubAcc.Text)
                cmd.Parameters.AddWithValue("@accname", txtAccName.Text)
                cmd.Parameters.AddWithValue("@type", IIf(rdbType.SelectedIndex = 0, "Income", "Balance Sheet"))
                cmd.Parameters.AddWithValue("@Category", cmbCategory.SelectedValue)
                'cmd.Parameters.AddWithValue("@BSItemId", cmbBSItem.SelectedValue)
                cmd.Parameters.AddWithValue("@BSItemId", IIf(cmbBSItem.Visible = False, 0, cmbBSItem.SelectedValue))
                cmd.Parameters.AddWithValue("@subtype", cmbType.SelectedValue)
                cmd.Parameters.AddWithValue("@tax", cmbTax.SelectedValue)
                cmd.Parameters.AddWithValue("@description", txtdesc.Text)
                cmd.Parameters.AddWithValue("@default", "Save")

                If con.State = ConnectionState.Open Then
                    con.Close()
                End If
                con.Open()
                If cmd.ExecuteNonQuery() Then
                    If rdbAccountType.SelectedIndex = 0 Or rdbAccountType.SelectedIndex = 1 Then
                        DCDetails()
                    End If
                    msgbox("Financial Account saved.")
                    loadGrid()
                    ClearFeilds()
                Else
                    msgbox("Error Saving Account")
                End If

            End If
            con.Close()
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub btnSaveTrxn1_Click(sender As Object, e As EventArgs) Handles btnSaveTrxn1.Click
        Try
            If Checkfeilds1() = True Then
                'msgbox(cmbBSItem.SelectedValue)
                'Exit Sub
                Using cmd = New SqlCommand("SaveFinancialAccounts", con)
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.AddWithValue("@mainacc", txtMainAcc.Text)
                    'cmd.Parameters.AddWithValue("@subacc", grdDetails.SelectedRow.Cells(4).Text)
                    cmd.Parameters.AddWithValue("@subacc", txtSubAcc.Text)
                    cmd.Parameters.AddWithValue("@accname", txtAccName.Text)
                    cmd.Parameters.AddWithValue("@type", IIf(rdbType.SelectedIndex = 0, "Income", "Balance Sheet"))
                    cmd.Parameters.AddWithValue("@Category", cmbCategory.SelectedValue)
                    cmd.Parameters.AddWithValue("@BSItemId", IIf(cmbBSItem.Visible = False, 0, cmbBSItem.SelectedValue))
                    cmd.Parameters.AddWithValue("@subtype", cmbType.SelectedValue)
                    cmd.Parameters.AddWithValue("@tax", cmbTax.SelectedValue)
                    cmd.Parameters.AddWithValue("@description", txtdesc.Text)
                    cmd.Parameters.AddWithValue("@default", "Update")
                    cmd.Parameters.AddWithValue("@EditID", hfEditID.Value)

                    If con.State = ConnectionState.Open Then
                        con.Close()
                    End If
                    con.Open()
                    If cmd.ExecuteNonQuery() Then
                        ''If rdbAccountType.SelectedIndex = 0 Or 1 Then
                        ''    DCDetails()
                        ''End If
                        notify("Financial Account saved.", "success")
                        loadGrid()
                        ClearFeilds()
                        grdDetails.SelectedIndex = -1
                    Else
                        notify("Error Saving Account", "error")
                    End If
                End Using
            End If
            con.Close()
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub btnSearchAccNo_Click(sender As Object, e As EventArgs) Handles btnSearchAccNo.Click
        Try
            cmd = New SqlCommand("select * from tbl_FinancialAccountsCreation where [MainAccount] = '" & txtMainAcc.Text & "' and [SubAccount]='" & txtSubAcc.Text & "'", con)
            Dim ds As New DataSet
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "Clients")
            If ds.Tables(0).Rows.Count > 0 Then
                Try
                    hfEditID.Value = ds.Tables(0).Rows(0).Item("ID")
                    btnSaveTrxn1.Enabled = True
                    ClearFeilds()
                    txtAccName.Text = ds.Tables(0).Rows(0).Item(1)
                    txtMainAcc.Text = ds.Tables(0).Rows(0).Item(2)
                    'txtMainAcc.Enabled = False
                    txtSubAcc.Text = ds.Tables(0).Rows(0).Item(3)
                    If ds.Tables(0).Rows(0).Item(4) = "Income" Then
                        rdbType.SelectedIndex = 0
                    Else
                        rdbType.SelectedIndex = 1
                    End If
                    rdbType_SelectedIndexChanged(Me, e)
                    cmbType.SelectedValue = ds.Tables(0).Rows(0).Item(5)
                    cmbTax.SelectedValue = ds.Tables(0).Rows(0).Item(6)
                    txtdesc.Text = ds.Tables(0).Rows(0).Item(7)
                Catch ex As Exception
                    msgbox(ex.Message)
                End Try
            Else
                cmbType.DataSource = Nothing
            End If
            cmbType.DataBind()
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            searchAccName(txtAccName.Text)
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub cmbCategory_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCategory.SelectedIndexChanged
        loadSubCategories(cmbCategory.SelectedValue)
    End Sub

    Protected Sub cmbType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbType.SelectedIndexChanged
        Try
            If rdbType.SelectedValue = "Balance Sheet" Then
                lblBSItem.Visible = True
                cmbBSItem.Visible = True
                loadBSItems(cmbType.SelectedValue)
            Else
                lblBSItem.Visible = False
                cmbBSItem.Visible = False
                cmbBSItem.Items.Clear()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub grdDetails_SelectedIndexChanged(sender As Object, e As EventArgs) Handles grdDetails.SelectedIndexChanged
        Try
            hfEditID.Value = grdDetails.SelectedRow.Cells(1).Text
            ClearFeilds()
            Using con = New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd = New SqlCommand("select * from tbl_FinancialAccountsCreation where id='" & grdDetails.SelectedRow.Cells(1).Text & "'", con)
                    Dim ds As New DataSet
                    Using adp = New SqlDataAdapter(cmd)
                        adp.Fill(ds)
                    End Using
                    If ds.Tables(0).Rows.Count > 0 Then
                        Dim dr = ds.Tables(0).Rows(0)
                        txtAccName.Text = dr("AccountName")
                        txtMainAcc.Text = dr("MainAccount")
                        txtSubAcc.Text = dr("SubAccount")
                        'If grdDetails.SelectedRow.Cells(5).Text = "Income Statement" Or grdDetails.SelectedRow.Cells(5).Text = "Income" Then
                        '    rdbType.SelectedIndex = 0
                        'Else
                        '    rdbType.SelectedIndex = 1
                        'End If
                        Try
                            rdbType.SelectedValue = dr("Type")
                        Catch ex As Exception
                            rdbType.ClearSelection()
                        End Try
                        rdbType_SelectedIndexChanged(Me, e)
                        Try
                            cmbCategory.SelectedValue = dr("Category")
                        Catch ex As Exception
                            cmbCategory.ClearSelection()
                        End Try
                        loadSubCategories(cmbCategory.SelectedValue)
                        Try
                            cmbType.SelectedValue = dr("Sub")
                        Catch ex As Exception
                            cmbType.ClearSelection()
                        End Try
                        txtdesc.Text = dr("Description")
                        If rdbType.SelectedValue = "Balance Sheet" Then
                            lblBSItem.Visible = True
                            cmbBSItem.Visible = True
                            loadBSItems(cmbType.SelectedValue)
                        Else
                            lblBSItem.Visible = False
                            cmbBSItem.Visible = False
                            cmbBSItem.Items.Clear()
                        End If
                        Try
                            cmbTax.SelectedValue = dr("TaxMode")
                        Catch ex As Exception
                            cmbTax.ClearSelection()
                        End Try
                    End If
                End Using
            End Using
            btnSaveTrxn1.Enabled = True
            'txtAccName.Text = IIf(grdDetails.SelectedRow.Cells(2).Text <> "&nbsp;", grdDetails.SelectedRow.Cells(2).Text, "")
            'txtMainAcc.Text = IIf(grdDetails.SelectedRow.Cells(3).Text <> "&nbsp;", grdDetails.SelectedRow.Cells(3).Text, "")
            ''txtMainAcc.Enabled = False
            'txtSubAcc.Text = IIf(grdDetails.SelectedRow.Cells(4).Text <> "&nbsp;", grdDetails.SelectedRow.Cells(4).Text, "")
            'cmbType.SelectedValue = IIf(grdDetails.SelectedRow.Cells(6).Text <> "&nbsp;", grdDetails.SelectedRow.Cells(6).Text, "")
            'cmbTax.SelectedValue = IIf(grdDetails.SelectedRow.Cells(7).Text <> "&nbsp;", grdDetails.SelectedRow.Cells(7).Text, "")
            'txtdesc.Text = IIf(grdDetails.SelectedRow.Cells(8).Text <> "&nbsp;", grdDetails.SelectedRow.Cells(8).Text, "")
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub loadBSItems(subCat As String)
        Try
            Using cmd = New SqlCommand("select * from BalanceSheetItems where [SubCategoryId]='" & subCat & "'", con)
                Dim ds As New DataSet
                adp = New SqlDataAdapter(cmd)
                adp.Fill(ds, "Clients")
                loadCombo(ds.Tables(0), cmbBSItem, "ItemName", "id")
            End Using
        Catch ex As Exception

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

    Protected Sub loadGrid()
        Try
            'cmd = New SqlCommand("select ID as 'SysID', AccountName, MainAccount, SubAccount, Type, Sub, TaxMode, Description from tbl_FinancialAccountsCreation ", con)
            'Using cmd = New SqlCommand("select fin.ID as 'SysID', AccountName, MainAccount, SubAccount,sc.Statement as [Type],sc.Category,subCat.SubType as [Sub Category], TaxMode, Description from tbl_FinancialAccountsCreation fin LEFT JOIN tbl_FinancialCategory subCat ON fin.Sub=convert(varchar,Subcat.id) LEFT JOIN statementCategories sc ON subCat.category=convert(varchar,sc.id)", con)
            Using cmd = New SqlCommand("select fin.ID as 'SysID', AccountName, MainAccount, SubAccount,sc.Statement as [Type],sc.Category,subCat.SubType as [Sub Category],bsi.ItemName as [Balance Sheet Item], TaxMode, Description from tbl_FinancialAccountsCreation fin LEFT JOIN tbl_FinancialCategory subCat ON fin.Sub=convert(varchar,Subcat.id) LEFT JOIN statementCategories sc ON subCat.category=convert(varchar,sc.id) LEFT JOIN balancesheetitems bsi ON convert(varchar,bsi.id)=convert(varchar,fin.BSItemId)", con)
                Dim ds As New DataSet
                adp = New SqlDataAdapter(cmd)
                adp.Fill(ds, "Tax")
                If ds.Tables(0).Rows.Count > 0 Then
                    grdDetails.DataSource = ds.Tables(0)
                    grdDetails.DataBind()
                Else
                    grdDetails.DataSource = Nothing
                    grdDetails.DataBind()
                End If
            End Using
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- loadGrid()", ex.ToString)
            'msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub loadSubCategories(cat As String)
        Try
            Using cmd = New SqlCommand("select * from tbl_FinancialCategory where [Category]='" & cat & "'", con)
                Dim ds As New DataSet
                adp = New SqlDataAdapter(cmd)
                adp.Fill(ds, "Clients")
                loadCombo(ds.Tables(0), cmbType, "SubType", "id")
            End Using
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub loadTaxTypes()
        Try
            Using cmd = New SqlCommand("select * from tbl_TaxProc", con)
                Dim ds As New DataSet
                adp = New SqlDataAdapter(cmd)
                adp.Fill(ds, "Tax")
                If ds.Tables(0).Rows.Count > 0 Then
                    cmbTax.DataSource = ds
                    cmbTax.DataValueField = "Name"
                    cmbTax.DataBind()
                Else
                    cmbTax.DataSource = Nothing
                    cmbTax.DataBind()
                End If
            End Using
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub loadTypes()
        Try
            Using cmd = New SqlCommand("select * from tbl_FinancialCategory", con)
                Dim ds As New DataSet
                adp = New SqlDataAdapter(cmd)
                adp.Fill(ds, "Clients")
                If ds.Tables(0).Rows.Count > 0 Then
                    cmbType.DataSource = ds.Tables(0)
                    cmbType.DataValueField = "SubTYPE"
                Else
                    cmbType.DataSource = Nothing
                End If
                cmbType.DataBind()
            End Using
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub lstAccSearch_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstAccSearch.SelectedIndexChanged
        hfEditID.Value = lstAccSearch.SelectedValue
        cmd = New SqlCommand("select * from tbl_FinancialAccountsCreation where ID = '" & lstAccSearch.SelectedValue & "'", con)
        Dim ds As New DataSet
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "Clients")
        If ds.Tables(0).Rows.Count > 0 Then
            Try
                lstAccSearch.ClearSelection()
                lstAccSearch.Visible = False
                hfEditID.Value = ds.Tables(0).Rows(0).Item("id")
                btnSaveTrxn1.Enabled = True
                ClearFeilds()
                txtAccName.Text = ds.Tables(0).Rows(0).Item(1)
                txtMainAcc.Text = ds.Tables(0).Rows(0).Item(2)
                'txtMainAcc.Enabled = False
                txtSubAcc.Text = ds.Tables(0).Rows(0).Item(3)
                If ds.Tables(0).Rows(0).Item(4) = "Income" Then
                    rdbType.SelectedIndex = 0
                Else
                    rdbType.SelectedIndex = 1
                End If
                rdbType_SelectedIndexChanged(Me, e)
                cmbType.SelectedValue = ds.Tables(0).Rows(0).Item(5)
                cmbTax.SelectedValue = ds.Tables(0).Rows(0).Item(6)
                txtdesc.Text = ds.Tables(0).Rows(0).Item(7)
                cmbType.DataBind()
            Catch ex As Exception
                msgbox(ex.Message)
            End Try
        Else
            cmbType.DataSource = Nothing
        End If
        ' cmbType.DataBind()
    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            Page.MaintainScrollPositionOnPostBack = True
            con = New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
            If Not IsPostBack Then
                loadGrid()
                'loadTypes()
                loadTaxTypes()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub rdbType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rdbType.SelectedIndexChanged
        Dim type As String
        If rdbType.SelectedIndex = 0 Then
            type = "Income Statement"
        Else
            type = "Balance Sheet"
        End If
        If rdbType.SelectedValue = "Balance Sheet" Then
            lblBSItem.Visible = True
            cmbBSItem.Visible = True
            loadBSItems(cmbType.SelectedValue)
        Else
            lblBSItem.Visible = False
            cmbBSItem.Visible = False
            cmbBSItem.Items.Clear()
        End If
        Try
            loadCategories(type)
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub rdbType0_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rdbAccountType.SelectedIndexChanged
        If rdbAccountType.SelectedIndex = 0 Or rdbAccountType.SelectedIndex = 1 Then
            Panel1.Visible = True
            txtMainAcc.Text = rdbAccountType.SelectedValue
            txtMainAcc.Enabled = False
        Else
            Panel1.Visible = False
            txtMainAcc.Text = ""
            txtMainAcc.Enabled = True
        End If

    End Sub
    Protected Sub searchAccName(accName As String)
        cmd = New SqlCommand("select * from tbl_FinancialAccountsCreation where AccountName like '%" & accName & "%'", con)
        Dim ds As New DataSet
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "Clients")
        If ds.Tables(0).Rows.Count > 0 Then
            lstAccSearch.DataSource = ds.Tables(0)
            lstAccSearch.DataTextField = "AccountName"
            lstAccSearch.DataValueField = "ID"
            lstAccSearch.Visible = True
        Else
            lstAccSearch.DataSource = Nothing
            lstAccSearch.Visible = False
        End If
        lstAccSearch.DataBind()
    End Sub
End Class