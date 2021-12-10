Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports CreditManager
Imports ErrorLogging

Partial Class Accounting_Journals
    Inherits System.Web.UI.Page
    'Dim cmd As SqlCommand
    'Dim con As New SqlConnection
    'Dim adp As New SqlDataAdapter
    'Dim connection As String
    'Public PBatchNo As String
    Public Sub msgbox(ByVal strMessage As String)

        'finishes server processing, returns to client.
        Dim strScript As String = "<script language=JavaScript>"
        strScript += "window.alert(""" & strMessage & """);"
        strScript += "</script>"
        Dim lbl As New System.Web.UI.WebControls.Label
        lbl.Text = strScript
        Page.Controls.Add(lbl)

    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Page.MaintainScrollPositionOnPostBack = True

        If Not IsPostBack Then
            rdTranType.SelectedIndex = 1
            rdTranType.Visible = False
            getCutOffDate()
            getCashCutOffDate()
            loadTypes()
            loadBathces()
            rdTranType.SelectedIndex = 1
        End If
    End Sub
    Protected Sub loadBathces()
        Try
            Using con = New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd = New SqlCommand("select * from [tbl_BatchRec] where BatchType= 'Journal' and [status]=0", con)
                    Dim ds As New DataSet
                    Using adp = New SqlDataAdapter(cmd)
                        adp.Fill(ds, "BatchRec")
                    End Using
                    If ds.Tables(0).Rows.Count > 0 Then
                        cmbBatchNo.DataSource = ds
                        cmbBatchNo.DataTextField = "BatchNo"
                        cmbBatchNo.DataBind()
                        cmbBatchNo.Items.Add(" ")
                        cmbBatchNo.SelectedIndex = cmbBatchNo.Items.Count - 1
                    Else
                        cmbBatchNo.DataSource = Nothing
                        cmbBatchNo.DataBind()
                    End If
                End Using
            End Using
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub loadTypes()
        Try
            'cmd = New SqlCommand("select AccountName,  convert(varchar,MainAccount) +'/'+ convert(varchar,SubAccount) as 'Accno' from tbl_FinancialAccountsCreation union select Distinct(isnull([SURNAME],'')+' '+ isnull([FORENAMES],'') + ' | ' + isnull(CUSTOMER_NUMBER,'')) as AccountName, CUSTOMER_NUMBER as 'Accno' from CUSTOMER_DETAILS order by 'AccountName'", con)
            'cmd = New SqlCommand("select AccountName + ' | ' + convert(varchar,MainAccount) +'/'+ convert(varchar,SubAccount) as AccountName, convert(varchar,MainAccount) +'/'+ convert(varchar,SubAccount) as 'Accno' from tbl_FinancialAccountsCreation where SubAccount<>1 union select Distinct(isnull([SURNAME],'')+' '+ isnull([FORENAMES],'') + ' | ' + isnull(CUSTOMER_NUMBER,'')) as AccountName, CUSTOMER_NUMBER as 'Accno' from CUSTOMER_DETAILS order by 'AccountName'", con)
            Using con = New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd = New SqlCommand("select AccountName + ' | ' + convert(varchar,MainAccount) as AccountName, convert(varchar,MainAccount) as 'Accno' from tbl_FinancialAccountsCreation union select Distinct(isnull([SURNAME],'')+' '+ isnull([FORENAMES],'') + ' | ' + isnull(CUSTOMER_NUMBER,'')) as AccountName, CUSTOMER_NUMBER as 'Accno' from CUSTOMER_DETAILS union select accountName + ' | ' + accountNo as AccountName,accountNo AS Accno from cashbookaccounts union select accountName + ' | ' + accountNo as AccountName,accountNo AS Accno from CreditorAccounts union select accountName + ' | ' + accountNo as AccountName,accountNo AS Accno from DebtorAccounts order by 'AccountName'", con)
                    Dim ds As New DataSet
                    Using adp = New SqlDataAdapter(cmd)
                        adp.Fill(ds, "AccountsTypes")
                    End Using
                    loadCombo(ds.Tables(0), cmbAccount, "AccountName", "Accno")
                End Using
            End Using
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub loadTypes1()
        Try
            'cmd = New SqlCommand("select AccountName + ' | ' + convert(varchar,MainAccount) +'/'+ convert(varchar,SubAccount) as AccountName, convert(varchar,MainAccount) +'/'+ convert(varchar,SubAccount) as 'Accno' from tbl_FinancialAccountsCreation where convert(varchar,MainAccount) +'/'+ convert(varchar,SubAccount)<>'" & cmbAccount.SelectedValue & "' and SubAccount<>1", con)
            Using con = New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd = New SqlCommand("select AccountName + ' | ' + convert(varchar,MainAccount) as AccountName, convert(varchar,MainAccount) as 'Accno' from tbl_FinancialAccountsCreation union select accountName + ' | ' + accountNo as AccountName,accountNo AS Accno from cashbookaccounts union select accountName + ' | ' + accountNo as AccountName,accountNo AS Accno from CreditorAccounts union select accountName + ' | ' + accountNo as AccountName,accountNo AS Accno from DebtorAccounts order by 'AccountName'", con)
                    Dim ds As New DataSet
                    Using adp = New SqlDataAdapter(cmd)
                        adp.Fill(ds, "AccountsTypes")
                    End Using
                    loadCombo(ds.Tables(0), cmbContraAccount, "AccountName", "Accno")
                End Using
            End Using
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub loadGrid()
        'Try
        'cmd = New SqlCommand("select * from tbl_JournalTemp where BatchNo= '" & PBatchNo & "'", con)
        Using con = New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
            Using cmd = New SqlCommand("select act.ID,convert(varchar,act.TrxnDate,106) as TrxnDate,act.Account + ' --- '+ ISNULL(f.AccountName,isnull(c.FORENAMES,'') + ' ' + isnull(c.SURNAME,'')) Account,act.Refrence,act.Description,act.Debit,act.Credit,act.BatchNo from tbl_JournalTemp act left JOIN tbl_FinancialAccountsCreation f ON act.Account=CONVERT(VARCHAR,f.MainAccount)+'/'+CONVERT(VARCHAR,f.SubAccount) LEFT JOIN CUSTOMER_DETAILS c ON act.Account=c.CUSTOMER_NUMBER where BatchNo=  '" & ViewState("BatchNo") & "'", con)
                Dim ds As New DataSet
                Using adp = New SqlDataAdapter(cmd)
                    adp.Fill(ds, "Accounts")
                End Using
                If ds.Tables(0).Rows.Count > 0 Then
                    grdDetails.DataSource = ds.Tables(0)
                    grdDetails.DataBind()
                Else
                    grdDetails.DataSource = Nothing
                    grdDetails.DataBind()
                End If
            End Using
        End Using
        'Catch ex As Exception
        '    msgbox(ex.Message)
        'End Try
    End Sub

    Public Function Checkfeilds() As Boolean
        Checkfeilds = False
        'Try
        If Not IsNumeric(txtAmount.Text) Then
            notify("Amount Must Be Numeric", "error")
            txtAmount.Focus()
            Exit Function
        End If
        If txtAmount.Text = "" Then
            notify("Amount Is Mandatory", "error")
            txtAmount.Focus()
            Exit Function
        End If
        If txtAmount.Text <= 0 Then
            notify("Amount must be greater than zero", "error")
            txtAmount.Focus()
            Exit Function
        End If
        If dtpTrxnDate.Text = "" Then
            notify("Trxn Date Is Mandatory", "error")
            dtpTrxnDate.Focus()
            Exit Function
        End If
        Checkfeilds = True
        'Catch ex As Exception

        'End Try
    End Function

    Protected Function getBatchAmount(bNo As String) As Double
        Try
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd As New SqlCommand("select isnull(Amount,0) as Amount from tbl_BatchRec where BatchNo='" & bNo & "'", con)
                    Dim amt As Double = 0
                    con.Open()
                    amt = cmd.ExecuteScalar
                    con.Close()
                    Return amt
                End Using
            End Using
        Catch ex As Exception
            ErrorLogging.WriteLogFile(Session("UserId"), Request.Url.ToString & " --- getBatchAmount()", ex.ToString)
            Return 0
        End Try
    End Function
    Protected Sub btnSaveTrxn_Click(sender As Object, e As EventArgs) Handles btnSaveTrxn.Click
        'Try
        Dim i As Integer

        Dim debit, credit As Double
        debit = 0.0
        credit = 0.0
        For i = 0 To grdDetails.Rows.Count - 1
            debit = debit + grdDetails.Rows(i).Cells(6).Text
            credit = credit + grdDetails.Rows(i).Cells(7).Text
        Next
        If debit.ToString <> credit.ToString Then
            msgbox("Debit: " & debit & "    Credit: " & credit)
            msgbox("Transaction is out of Balance, Cannot Commit")
            txtdesc.Focus()
            Exit Sub
        End If
        If debit <> getBatchAmount(cmbBatchNo.SelectedValue) Then
            msgbox("Total transaction amount not equal to batch amount")
            Exit Sub
        End If
        If grdDetails.Rows.Count > 0 = True Then
            ''cmd = New SqlCommand("Select [TrxnDate] from tbl_journaltemp Where BatchNo='" & grdDetails.Rows(0).Cells(12).Text & "'", con)
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd = New SqlCommand("Select [TrxnDate] from tbl_journaltemp Where BatchNo='" & cmbBatchNo.SelectedValue & "'", con)
                    Dim ds1 As New DataSet
                    Using adp = New SqlDataAdapter(cmd)
                        adp.Fill(ds1, "batch")
                    End Using
                    If isCashAccount(cmbAccount.SelectedValue) Then
                        If CDate(ds1.Tables(0).Rows(0).Item("TrxnDate")) <= CDate(lblCashCutOffDate.Text) Then
                            msgbox("You cannot commit a cash transaction before the cut off date")
                            dtpTrxnDate.Focus()
                            Exit Sub
                        End If
                    Else
                        If CDate(ds1.Tables(0).Rows(0).Item("TrxnDate")) <= CDate(lblCutOffDate.Text) Then
                            msgbox("You cannot commit a transaction before the cut off date")
                            dtpTrxnDate.Focus()
                            Exit Sub
                        End If
                    End If
                End Using
                Using cmd = New SqlCommand("INSERT INTO [tbl_Journal]  ([TrxnDate],Account ,Refrence ,[Description]  ,Debit ,Credit,ContraAccount ,BankID,BankAccName,BatchNo,Other) Select [TrxnDate],Account ,Refrence,[Description],Debit,Credit ,ContraAccount,BankID,BankAccName,BatchNo,Other from tbl_journaltemp Where BatchNo='" & cmbBatchNo.SelectedValue & "'", con)
                    cmd.CommandType = CommandType.Text
                    If con.State = ConnectionState.Open Then
                        con.Close()
                    End If
                    con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                End Using
                Using cmd = New SqlCommand("INSERT INTO Accounts_Transactions  ([TrxnDate],[Type],Category,Account,Refrence,[Description],Debit,Credit,ContraAccount,BankAccID,BankAccName,BatchRef,Other,AccountName,[CaptureDate],[CaptureBy])  Select [TrxnDate],'Journal Entry','New Journal entry' ,Account ,Refrence,[Description],Debit ,Credit,ContraAccount,BankID,BankAccName ,BatchNo,Other,AccountName,GETDATE(),'" & Session("UserId") & "' from tbl_journaltemp Where BatchNo='" & cmbBatchNo.SelectedValue & "'", con)
                    cmd.CommandType = CommandType.Text
                    If con.State = ConnectionState.Open Then
                        con.Close()
                    End If
                    con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                End Using
                Using cmd = New SqlCommand("update tbl_BatchRec set [Status]=1 where BatchNo ='" & cmbBatchNo.SelectedValue & "'", con)
                    cmd.CommandType = CommandType.Text
                    If con.State = ConnectionState.Open Then
                        con.Close()
                    End If
                    con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                End Using
                Using cmd = New SqlCommand("DELETE FROM TBL_JOURNALTEMP WHERE BatchNo='" & cmbBatchNo.SelectedValue & "'", con)
                    cmd.CommandType = CommandType.Text
                    If con.State = ConnectionState.Open Then
                        con.Close()
                    End If
                    con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                End Using
                msgbox("Journal Entry Comitted")
                grdDetails.DataSource = Nothing
                grdDetails.DataBind()
            End Using
        Else
            msgbox("Error Saving Account")
        End If

        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try
    End Sub

    Protected Sub btnSaveTrxn3_Click(sender As Object, e As EventArgs) Handles btnSaveTrxn3.Click
        Try
            SaveTrxn()
        Catch ex As Exception

        End Try
    End Sub

    Protected Function isCashAccount(accNo As String) As Boolean
        Try
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd As New SqlCommand("select id from CashbookAccounts where AccountNo=@AccNo", con)
                    cmd.Parameters.AddWithValue("@AccNo", accNo)
                    Dim dt As New DataTable
                    Using adp As New SqlDataAdapter(cmd)
                        adp.Fill(dt)
                    End Using
                    If dt.Rows.Count > 0 Then
                        Return True
                    Else
                        Return False
                    End If
                End Using
            End Using
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- isCashAccount()", ex.ToString)
            Return False
        End Try
    End Function

    Public Sub SaveTrxn()
        ' Try
        If isCashAccount(cmbAccount.SelectedValue) Then
            If CDate(dtpTrxnDate.Text) <= CDate(lblCashCutOffDate.Text) Then
                msgbox("You cannot post a cash transaction before the cut off date")
                dtpTrxnDate.Focus()
                Exit Sub
            End If
        Else
            If CDate(dtpTrxnDate.Text) <= CDate(lblCutOffDate.Text) Then
                msgbox("You cannot post a transaction before the cut off date")
                dtpTrxnDate.Focus()
                Exit Sub
            End If
        End If
        If Checkfeilds() = True Then
            Dim batchno As String = ""
            If cmbBatchNo.Text.Trim = "" Then
                Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                    Using cmd = New SqlCommand("select 'AB000'+ convert(varchar,isnull((max(ID)+1),1)) as AutoBatch from tbl_Journal", con)
                        Dim ds As New DataSet
                        Using adp = New SqlDataAdapter(cmd)
                            adp.Fill(ds, "Accounts")
                        End Using
                        If ds.Tables(0).Rows.Count > 0 Then
                            batchno = ds.Tables(0).Rows(0).Item("AutoBatch").ToString
                            ViewState("BatchNo") = ds.Tables(0).Rows(0).Item("AutoBatch").ToString
                        End If
                    End Using
                End Using
                ' msgbox(1)
            Else
                batchno = cmbBatchNo.Text
                ViewState("BatchNo") = cmbBatchNo.Text
                'msgbox(2)
            End If

            Dim BankID As Integer
            Dim BankName As String

            If cmbAccount0.Visible = True And cmbAccount.SelectedItem.Text = "Bank" Then
                BankID = cmbAccount0.SelectedValue
                BankName = cmbAccount0.SelectedItem.Text
            Else
                BankID = 0
                BankName = ""
            End If
            Dim dr, cr As Double
            If rdbType.SelectedIndex = 0 Then
                dr = txtAmount.Text
                cr = 0.0
            Else
                cr = txtAmount.Text
                dr = 0.0
            End If
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd = New SqlCommand("SaveJournalTemp", con)
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.AddWithValue("@Date", dtpTrxnDate.Text)
                    'cmd.Parameters.AddWithValue("@Account", IIf(cmbAccount.SelectedValue.Substring(0, 4) = "213/", "213/1", cmbAccount.SelectedValue))
                    cmd.Parameters.AddWithValue("@Account", cmbAccount.SelectedValue)
                    cmd.Parameters.AddWithValue("@Ref", txtRef.Text)
                    cmd.Parameters.AddWithValue("@Desc", txtdesc.Text)
                    cmd.Parameters.AddWithValue("@Debit", dr)
                    cmd.Parameters.AddWithValue("@Credit", cr)
                    cmd.Parameters.AddWithValue("@ContraAccount", IIf(cmbContraAccount.SelectedValue = "-Select-", "", cmbContraAccount.SelectedValue))
                    cmd.Parameters.AddWithValue("@BankID", BankID)
                    cmd.Parameters.AddWithValue("@BankAccName", BankName)
                    cmd.Parameters.AddWithValue("@BatchNo", batchno)
                    cmd.Parameters.AddWithValue("@Other", cmbAccount.SelectedValue)
                    cmd.Parameters.AddWithValue("@AccountName", cmbAccount.SelectedItem.Text)

                    If con.State = ConnectionState.Open Then
                        con.Close()
                    End If
                    con.Open()
                    If cmd.ExecuteNonQuery() Then
                        msgbox("Journal Entry Added")
                        loadGrid()
                        ClearFeilds()
                    Else
                        msgbox("Error Saving Details")
                    End If
                    con.Close()
                End Using
            End Using
        End If
        'Catch ex As Exception
        '    msgbox(ex.Message)
        'End Try
    End Sub
    Public Sub CreateContraEntry()
        '  Try

        'If Checkfeilds() = True Then
        Dim BankID As Integer = 0
        Dim BankName As String = ""

        If cmbAccount1.Visible = True And cmbContraAccount.SelectedValue = "Bank" Then
            BankID = cmbAccount1.SelectedValue
            BankName = cmbAccount1.SelectedItem.Text
        Else
            BankID = 0
            BankName = ""
        End If
        Dim dr, cr As Double
        If rdbType.SelectedIndex = 0 Then
            dr = 0.0
            cr = txtAmount.Text
        Else
            cr = 0.0
            dr = txtAmount.Text
        End If
        Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
            Using cmd = New SqlCommand("INSERT INTO [tbl_JournalTemp] ([TrxnDate] ,[Account]  ,[Refrence] ,[Description],[Debit] ,[Credit] ,[ContraAccount],[BankID],[BankAccName],[BatchNo],AccountName) VaLUES ('" & dtpTrxnDate.Text & "','" & cmbContraAccount.SelectedValue & "', '" & txtRef.Text & "','" & txtdesc.Text & "', " & dr & ", " & cr & ",'" & cmbAccount.SelectedValue & "','" & BankID & "', '" & BankName & "','" & cmbBatchNo.SelectedItem.Text & "','" & cmbContraAccount.SelectedItem.Text.Replace("'", "''") & "')", con)
                cmd.CommandType = CommandType.Text
                If con.State = ConnectionState.Open Then
                    con.Close()
                End If
                con.Open()
                If cmd.ExecuteNonQuery() Then
                    msgbox("Journal Entry Added")
                    loadGrid()
                Else
                    msgbox("Error Saving Details")
                End If
                con.Close()
            End Using
        End Using
        ' End If
        'Catch ex As Exception
        '    msgbox(ex.Message)
        'End Try
    End Sub

    Protected Sub cmbAccount_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbAccount.SelectedIndexChanged
        loadTypes1()
        If cmbAccount.SelectedItem.Text.ToUpper = "BANK" Then
            loadBanks()
        ElseIf cmbAccount.SelectedValue = "100/1" Or cmbAccount.SelectedValue = "213/1" Then
            cmbAccount1.Visible = True
            loadIndvAccs()
        End If

    End Sub

    Protected Sub loadIndvAccs()
        Try
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd = New SqlCommand("select isnull([SURNAME],'')+' '+ isnull([FORENAMES],'') + ' | ' + isnull(CUSTOMER_NUMBER,'') as Name, CUSTOMER_NUMBER from QUEST_APPLICATION order by 'Name'", con)
                    Dim ds As New DataSet
                    Using adp = New SqlDataAdapter(cmd)
                        adp.Fill(ds, "QUEST_APPLICATION")
                    End Using
                    If ds.Tables(0).Rows.Count > 0 Then
                        cmbAccount1.DataSource = ds
                        cmbAccount1.DataTextField = "Name"
                        cmbAccount1.DataValueField = "CUSTOMER_NUMBER"
                        cmbAccount1.DataBind()
                        cmbAccount1.Items.Add("-Select-")
                        cmbAccount1.SelectedIndex = cmbAccount0.Items.Count - 1
                    Else
                        cmbAccount1.DataSource = Nothing
                        cmbAccount1.DataBind()
                    End If
                End Using
            End Using
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Public Sub ClearFeilds()
        rdbType.Enabled = True
        rdbType.ClearSelection()
        txtAmount.Text = ""
        txtdesc.Text = ""
        txtRef.Text = ""
        cmbAccount.ClearSelection()
        cmbContraAccount.ClearSelection()
    End Sub

    Protected Sub rdTranType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rdTranType.SelectedIndexChanged
        If rdTranType.SelectedIndex = 0 Then
            lblTrxnSearch.Visible = True
            txtTrxnSearch.Visible = True
            btnSearch.Visible = True
            Panel1.Visible = False
            DisableAll()
        Else
            lblTrxnSearch.Visible = False
            txtTrxnSearch.Visible = False
            btnSearch.Visible = False
            Panel1.Visible = True
            EnableAll()
        End If
    End Sub

    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Try
            ViewState("BatchNo") = txtTrxnSearch.Text
            loadGrid()
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub loadBanks()
        Try
            cmbAccount0.Visible = True
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd = New SqlCommand("select * from tbl_BankAccounts", con)
                    Dim ds As New DataSet
                    Using adp = New SqlDataAdapter(cmd)
                        adp.Fill(ds, "banks")
                    End Using
                    If ds.Tables(0).Rows.Count > 0 Then
                        cmbAccount0.DataSource = ds
                        cmbAccount0.DataTextField = "Code"
                        cmbAccount0.DataValueField = "id"
                        cmbAccount0.DataBind()
                        cmbAccount0.Items.Add("-Select-")
                        cmbAccount0.SelectedIndex = cmbAccount0.Items.Count - 1
                    Else
                        cmbAccount0.DataSource = Nothing
                        cmbAccount0.DataBind()
                    End If
                End Using
            End Using
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub loadBanks2()
        Try
            cmbAccount1.Visible = True
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd = New SqlCommand("select * from tbl_BankAccounts", con)
                    Dim ds As New DataSet
                    Using adp = New SqlDataAdapter(cmd)
                        adp.Fill(ds, "banks")
                    End Using
                    If ds.Tables(0).Rows.Count > 0 Then
                        cmbAccount1.DataSource = ds
                        cmbAccount1.DataTextField = "Code"
                        cmbAccount1.DataValueField = "id"
                        cmbAccount1.DataBind()
                        cmbAccount1.Items.Add("-Select-")
                        cmbAccount1.SelectedIndex = cmbAccount0.Items.Count - 1
                    Else
                        cmbAccount1.DataSource = Nothing
                        cmbAccount1.DataBind()
                    End If
                End Using
            End Using
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Public Sub DisableAll()
        txtAmount.Enabled = False
        txtdesc.Enabled = False
        txtRef.Enabled = False
        cmbAccount.Enabled = False
        cmbContraAccount.Enabled = False
        dtpTrxnDate.Enabled = False
        rdbType.Enabled = False
    End Sub
    Public Sub EnableAll()
        txtAmount.Enabled = True
        txtdesc.Enabled = True
        txtRef.Enabled = True
        cmbAccount.Enabled = True
        cmbContraAccount.Enabled = True
        dtpTrxnDate.Enabled = True
        rdbType.Enabled = True
        grdDetails.DataSource = Nothing
        grdDetails.DataBind()
    End Sub

    Protected Sub cmbContraAccount_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbContraAccount.SelectedIndexChanged
        If cmbContraAccount.SelectedItem.Text = "Bank" Then
            loadBanks2()
        End If
    End Sub

    Protected Sub cmbBatchNo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbBatchNo.SelectedIndexChanged
        Try
            getBatchDetails(cmbBatchNo.SelectedValue)
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd = New SqlCommand("select * from [tbl_BatchRec] where [BatchNo]='" & cmbBatchNo.SelectedItem.Text & "'", con)
                    Dim ds As New DataSet
                    Using adp = New SqlDataAdapter(cmd)
                        adp.Fill(ds, "BatchRec")
                    End Using
                    If ds.Tables(0).Rows.Count > 0 And ds.Tables(0).Rows(0).Item("Account").ToString <> "" Then
                        ViewState("BatchNo") = cmbBatchNo.SelectedItem.Text
                        loadGrid()
                        cmbContraAccount.Items.Clear()
                        cmbContraAccount.DataSource = Nothing
                        cmbContraAccount.DataBind()
                        cmbContraAccount.Enabled = False

                        cmbAccount.SelectedValue = ds.Tables(0).Rows(0).Item("Account").ToString
                        cmbAccount.Enabled = False

                        txtAmount.Text = ds.Tables(0).Rows(0).Item("Amount").ToString
                        txtdesc.Text = ds.Tables(0).Rows(0).Item("BatchName").ToString
                        txtAmount.Enabled = False
                    Else
                        ViewState("BatchNo") = cmbBatchNo.SelectedItem.Text
                        loadGrid()
                        cmbAccount.Enabled = True
                        cmbContraAccount.Enabled = True
                        txtAmount.Enabled = True
                        cmbAccount.SelectedIndex = -1
                        cmbContraAccount.SelectedIndex = -1
                        txtAmount.Text = ""
                    End If
                End Using
            End Using
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim i As Integer
            For i = 0 To grdDetails.Rows.Count - 1
                Dim ch As CheckBox
                ch = CType(grdDetails.Rows(i).Cells(0).FindControl("CheckBox2"), CheckBox)
                If ch.Checked Then

                    Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                        'cmd = New SqlCommand("delete from  tbl_JournalTemp where BatchNo='" & grdDetails.Rows(i).Cells(12).Text & "' and ID =" & grdDetails.Rows(i).Cells(1).Text & "", con)
                        Using cmd = New SqlCommand("delete from  tbl_JournalTemp where BatchNo='" & cmbBatchNo.SelectedValue & "' and ID =" & grdDetails.Rows(i).Cells(1).Text & "", con)
                            cmd.CommandType = CommandType.Text
                            If con.State = ConnectionState.Open Then
                                con.Close()
                            End If
                            con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()
                            'If cmd.ExecuteNonQuery() Then
                            '    loadGrid()
                            'Else
                            '    msgbox("Trxns Not Found")
                            '    loadGrid()
                            'End If
                        End Using
                    End Using
                End If
            Next
            ViewState("BatchNo") = cmbBatchNo.SelectedValue ' grdDetails.Rows(0).Cells(12).Text
            loadGrid()
        Catch ex As Exception
            ErrorLogging.WriteLogFile(Session("UserId"), Request.Url.ToString & " --- Button1_Click()", ex.ToString)
        End Try
    End Sub

    Protected Sub btnSaveTrxn4_Click(sender As Object, e As EventArgs) Handles btnSaveTrxn4.Click
        lblTrxnSearch.Visible = True
        txtTrxnSearch.Visible = True
        btnSearch.Visible = True

    End Sub

    Protected Sub getCutOffDate()
        Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
            Using cmd As New SqlCommand("select id,convert(varchar,CutOff,106) as [Date],CapturedBy as [Captured By],convert(varchar,CaptureDate,113) as [Capture Date] from AccCutOffDates where Authorised=1 order by id desc", con)
                Dim ds As New DataSet
                Dim adp = New SqlDataAdapter(cmd)
                adp.Fill(ds, "APP")
                If ds.Tables(0).Rows.Count > 0 Then
                    lblCutOffDate.Text = ds.Tables(0).Rows(0).Item("Date")
                Else
                    lblCutOffDate.Text = ""
                End If
            End Using
        End Using
    End Sub

    Protected Sub getCashCutOffDate()
        Try
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd As New SqlCommand("select id,convert(varchar,CutOff,106) as [Date],CapturedBy as [Captured By],convert(varchar,CaptureDate,113) as [Capture Date] from AccCashCutOffDates where Authorised=1 order by id desc", con)
                    Dim ds As New DataSet
                    Dim adp = New SqlDataAdapter(cmd)
                    adp.Fill(ds, "APP")
                    If ds.Tables(0).Rows.Count > 0 Then
                        lblCashCutOffDate.Text = ds.Tables(0).Rows(0).Item("Date")
                    Else
                        lblCashCutOffDate.Text = ""
                    End If
                End Using
            End Using
        Catch ex As Exception
            ErrorLogging.WriteLogFile(Session("UserId"), Request.Url.ToString & " --- getCashCutOffDate()", ex.Message)
        End Try
    End Sub

    Protected Sub getBatchDetails(bRef As String)
        Try
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd As New SqlCommand("select BatchNo, convert(varchar,BatchDate,106) as [Batch Date], BatchName as [Description], NumberOfTrxns as [Number of Trxns],format(Amount,'c') as Amount,CreatedBy as [Created By],convert(varchar,DateCreated,113) as [Date Created] from tbl_BatchRec where [BatchNo]='" & bRef & "'", con)
                    Dim ds As New DataSet
                    Dim adp = New SqlDataAdapter(cmd)
                    adp.Fill(ds, "APP")
                    CreditManager.bindGrid(ds.Tables(0), grdBatchRec)
                End Using
            End Using
        Catch ex As Exception
            ErrorLogging.WriteLogFile(Session("UserId"), Request.Url.ToString & " --- getBatchDetails()", ex.ToString)
        End Try
    End Sub
End Class