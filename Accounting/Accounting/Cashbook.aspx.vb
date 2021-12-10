Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports CreditManager
Imports ErrorLogging

Partial Class Accounting_Cashbook
    Inherits System.Web.UI.Page
    Dim cmd As SqlCommand
    Dim con As New SqlConnection
    Dim adp As New SqlDataAdapter

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        Page.MaintainScrollPositionOnPostBack = True
        con = New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
        If Not IsPostBack Then
            loadTypes()
            loadCash()
            loadBathces()
            getCutOffDate()
            getCashCutOffDate()
        End If
    End Sub

    'Protected Sub loadTypes()
    '    Try
    '        'cmd = New SqlCommand("select AccountName + ' | ' + convert(varchar,MainAccount) +'/'+ convert(varchar,SubAccount) as 'AccName',  convert(varchar,MainAccount) +'/'+ convert(varchar,SubAccount) as 'Accno' from tbl_FinancialAccountsCreation order by mainAccount,AccountName", con)
    '        cmd = New SqlCommand("select AccountName + ' ' + convert(varchar,MainAccount) +'/'+ convert(varchar,SubAccount) as AccName,  convert(varchar,MainAccount) +'/'+ convert(varchar,SubAccount) as 'Accno' from tbl_FinancialAccountsCreation union select LTRIM(isnull(surname,'')+' ')+rtrim(isnull(forenames,''))+' '+customer_number as AccName,customer_number as 'Accno' from customer_details order by AccName", con)
    '        Dim ds As New DataSet
    '        adp = New SqlDataAdapter(cmd)
    '        adp.Fill(ds, "AccountsTypes")
    '        loadCombo(ds.Tables(0), cmbAccount, "AccName", "Accno")
    '        'If ds.Tables(0).Rows.Count > 0 Then
    '        '    cmbAccount.DataSource = ds
    '        '    cmbAccount.DataTextField = "AccName"
    '        '    cmbAccount.DataValueField = "Accno"
    '        '    cmbAccount.DataBind()
    '        '    cmbAccount.Items.Add("-Select-")
    '        '    cmbAccount.SelectedIndex = cmbAccount.Items.Count - 1
    '        'Else
    '        '    cmbAccount.DataSource = Nothing
    '        '    cmbAccount.DataBind()
    '        'End If

    '    Catch ex As Exception
    '        msgbox(ex.Message)
    '    End Try
    'End Sub

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

    Protected Sub loadBathces()
        '  Try
        cmbBatchNo.DataSource = Nothing
        cmbBatchNo.DataBind()
        cmd = New SqlCommand("select * from [tbl_BatchRec] where BatchType= 'Cashbook' and [status]=0", con)
        Dim ds As New DataSet
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "BatchRec")
        CreditManager.loadCombo(ds.Tables(0), cmbBatchNo, "BatchNo", "BatchNo")
        'If ds.Tables(0).Rows.Count > 0 Then
        '    cmbBatchNo.DataSource = ds
        '    cmbBatchNo.DataTextField = "BatchNo"
        '    cmbBatchNo.DataValueField = "id"
        '    cmbBatchNo.DataBind()
        '    cmbBatchNo.Items.Add(" ")
        '    cmbBatchNo.SelectedIndex = cmbBatchNo.Items.Count - 1
        'Else
        '    cmbBatchNo.DataSource = Nothing
        '    cmbBatchNo.DataBind()
        'End If

        'Catch ex As Exception
        'msgbox(ex.Message)
        'End Try
    End Sub
    Protected Sub loadGrid()
        Try
            'cmd = New SqlCommand("select ID,Type, Category, convert(varchar,TrxnDate,106) as [Date], Refrence, Description,Account,Debit,Credit,ContraAccount as Contra,BatchRef from  Acc_Trans_Temp where BatchRef= '" & cmbBatchNo.SelectedItem.Text & "' and ([Authorized] is null or [Authorized]=0)", con)
            cmd = New SqlCommand("select act.ID,act.Type, act.Category, convert(varchar,TrxnDate,106) as [Date], Refrence, act.Description,act.Account + ' --- '+ ISNULL(f.AccountName,isnull(c.FORENAMES,'') + ' ' + isnull(c.SURNAME,'')) Account,Debit,Credit,act.ContraAccount + ' --- '+ ISNULL(f1.AccountName,isnull(c1.FORENAMES,'') + ' ' + isnull(c1.SURNAME,'')) as Contra,BatchRef from  Acc_Trans_Temp act left JOIN tbl_FinancialAccountsCreation f ON act.Account=CONVERT(VARCHAR,f.MainAccount)+'/'+CONVERT(VARCHAR,f.SubAccount) LEFT JOIN CUSTOMER_DETAILS c ON act.Account=c.CUSTOMER_NUMBER left JOIN tbl_FinancialAccountsCreation f1 ON act.ContraAccount=CONVERT(VARCHAR,f1.MainAccount)+'/'+CONVERT(VARCHAR,f1.SubAccount) LEFT JOIN CUSTOMER_DETAILS c1 ON act.ContraAccount=c1.CUSTOMER_NUMBER where BatchRef= '" & cmbBatchNo.SelectedItem.Text & "' and ([Authorized] is null or [Authorized]=0)", con)
            '  msgbox(cmd.CommandText)
            Dim ds As New DataSet
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "Accounts")
            If ds.Tables(0).Rows.Count > 0 Then
                grdDetails.DataSource = ds.Tables(0)
                grdDetails.DataBind()
            Else
                grdDetails.DataSource = Nothing
                grdDetails.DataBind()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Public Function Checkfeilds() As Boolean
        Checkfeilds = False
        Try
            If Not IsNumeric(txtAmount.Text) Then
                msgbox("Amount Must Be Numeric")
                txtAmount.Focus()
                Exit Function
            End If
            If txtAmount.Text = "" Then
                msgbox("Amount Is Mandatory")
                txtAmount.Focus()
                Exit Function
            End If
            If cmbAccount.SelectedValue = "-Select-" Then
                msgbox("Account Is Mandatory")
                cmbAccount.Focus()
                Exit Function
            End If
            If txtRef.Text = "" Then
                msgbox("Ref Is Mandatory")
                txtRef.Focus()
                Exit Function
            End If
            If cmbBatchNo.SelectedIndex < 0 Then
                msgbox("Select a valid Batch")
                cmbBatchNo.Focus()
                Exit Function
            End If

            If rdbType0.SelectedIndex < 0 Then
                msgbox("Select Trxn Type")
                rdbType0.Focus()
                Exit Function
            End If
            If rdbPayType.SelectedIndex < 0 Then
                msgbox("Select Pay Type")
                rdbPayType.Focus()
                Exit Function
            End If
            Checkfeilds = True
        Catch ex As Exception

        End Try
    End Function
    Protected Sub btnSaveTrxn_Click(sender As Object, e As EventArgs) Handles btnSaveTrxn.Click
        Try
            If cmbBatchNo.SelectedValue = "" Then
                notify("Select batch number", "error")
                cmbBatchNo.Focus()
            Else
                Dim ds As New DataSet
                Using cmd = New SqlCommand("select (amount) as batch_amount, sum(debit) as debits, sum(credit) as credits, count(b.id) as trxns from tbl_BatchRec a, [Acc_Trans_Temp] b where a.batchno=b.batchref and  a.BatchNo= '" & cmbBatchNo.SelectedItem.Text & "' group by amount", con)
                    adp = New SqlDataAdapter(cmd)
                    adp.Fill(ds, "batch")
                End Using
                If ds.Tables(0).Rows.Count > 0 Then
                    If ds.Tables(0).Rows(0).Item("batch_amount") <> ds.Tables(0).Rows(0).Item("debits") Or ds.Tables(0).Rows(0).Item("debits") <> ds.Tables(0).Rows(0).Item("credits") Then
                        msgbox("Batch Not Balanced, Not Committed!")
                        Exit Sub
                    Else
                        commitTrans(cmbBatchNo.SelectedItem.Text)
                        ClearFeilds1()
                        'msgbox("Batch Balanced, Committed")
                        'Response.Redirect("~/Accounting/Cashbook.aspx")
                        Response.Write("<script>alert('Batch Balanced, Committed') ; location.href='Cashbook.aspx'</script>")
                    End If
                End If
            End If
        Catch ex As Exception
            msgbox(ex.ToString)
        End Try
    End Sub

    Protected Sub commitTrans(batchRef As String)
        Using cmd As New SqlCommand("CommitAccTrans")
            cmd.CommandType = CommandType.StoredProcedure
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                cmd.Connection = con
                cmd.Parameters.AddWithValue("@BatchRef", batchRef)
                con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            End Using
        End Using
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

    Protected Sub btnSaveTrxn3_Click(sender As Object, e As EventArgs) Handles btnSaveTrxn3.Click
        'Try
        If isCashAccount(cmbAccount.SelectedValue) Or isCashAccount(cmbAccount0.SelectedValue) Then
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
            If rdbPayType.SelectedIndex = 1 And (cmbAccount0.SelectedItem.Text = "-Select-" Or cmbAccount0.SelectedValue = "") Then
                msgbox("Select bank account")
                Exit Sub
            End If
            'Dim PayType As String
            'If rdbPayType.SelectedIndex = 0 Then
            '    PayType = "211/1"
            'Else
            '    ''PayType = "212/1"
            '    PayType = cmbAccount0.SelectedValue
            'End If
            Dim cramount, dramount As Double
            If rdbType0.SelectedIndex = 0 Then
                dramount = 0.0
                cramount = CDbl(txtAmount.Text)
            ElseIf rdbType0.SelectedIndex = 1 Then
                dramount = CDbl(txtAmount.Text)
                cramount = 0.0
            Else
                msgbox("Invalid Trxn Type")
            End If
            Using cmd = New SqlCommand("SaveAccTransTemp", con)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("@Type", "Cashbook")
                cmd.Parameters.AddWithValue("@Category", rdbType0.SelectedItem.Text)
                cmd.Parameters.AddWithValue("@Ref", txtRef.Text)
                cmd.Parameters.AddWithValue("@Desc", txtdesc.Text)
                cmd.Parameters.AddWithValue("@Debit", dramount)
                cmd.Parameters.AddWithValue("@Credit", cramount)
                cmd.Parameters.AddWithValue("@Account", cmbAccount.SelectedValue)
                cmd.Parameters.AddWithValue("@ContraAccount", cmbAccount0.SelectedValue)
                cmd.Parameters.AddWithValue("@Status", IIf(rdbType0.SelectedIndex = 0, 1, 0))
                cmd.Parameters.AddWithValue("@Other", IIf(cmbAccount1.SelectedValue <> "-Select-" And cmbAccount1.SelectedValue <> "", cmbAccount1.SelectedValue, txtRecFrom.Text))
                cmd.Parameters.AddWithValue("@BankAccID", "")
                cmd.Parameters.AddWithValue("@BankAccName", "") 'receipt number for transaction
                cmd.Parameters.AddWithValue("@BatchRef", cmbBatchNo.SelectedValue)
                cmd.Parameters.AddWithValue("@TrxnDate", dtpTrxnDate.Text)
                cmd.Parameters.AddWithValue("@CaptureBy", Session("UserId"))
                cmd.Parameters.AddWithValue("@AccountName", cmbAccount.SelectedItem.Text)

                If con.State = ConnectionState.Open Then
                    con.Close()
                End If
                con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            End Using

            Using cmd = New SqlCommand("SaveAccTransTemp", con)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("@Type", "Cashbook")
                cmd.Parameters.AddWithValue("@Category", rdbType0.SelectedItem.Text)
                cmd.Parameters.AddWithValue("@Ref", txtRef.Text)
                cmd.Parameters.AddWithValue("@Desc", txtdesc.Text)
                cmd.Parameters.AddWithValue("@Debit", dramount)
                cmd.Parameters.AddWithValue("@Credit", cramount)
                cmd.Parameters.AddWithValue("@Account", cmbAccount0.SelectedValue)
                cmd.Parameters.AddWithValue("@ContraAccount", cmbAccount.SelectedValue)
                cmd.Parameters.AddWithValue("@Status", IIf(rdbType0.SelectedIndex = 0, 1, 0))
                cmd.Parameters.AddWithValue("@Other", IIf(cmbAccount1.SelectedValue <> "-Select-" And cmbAccount1.SelectedValue <> "", cmbAccount1.SelectedValue, txtRecFrom.Text))
                cmd.Parameters.AddWithValue("@BankAccID", "")
                cmd.Parameters.AddWithValue("@BankAccName", "") 'receipt number for transaction
                cmd.Parameters.AddWithValue("@BatchRef", cmbBatchNo.SelectedValue)
                cmd.Parameters.AddWithValue("@TrxnDate", dtpTrxnDate.Text)
                cmd.Parameters.AddWithValue("@CaptureBy", Session("UserId"))
                cmd.Parameters.AddWithValue("@AccountName", cmbAccount0.SelectedItem.Text)

                If con.State = ConnectionState.Open Then
                    con.Close()
                End If
                con.Open()
                If cmd.ExecuteNonQuery() Then
                    notify("Cashbook Entry Added", "success")
                    loadGrid()
                    ClearFeilds()
                Else
                    notify("Error Saving Details", "error")
                End If
                con.Close()
            End Using

        End If
        'Catch ex As Exception
        '    msgbox(ex.Message)
        'End Try
    End Sub

    Public Sub ClearFeilds()
        txtAmount.Text = ""
        txtdesc.Text = ""
        txtRef.Text = ""
        cmbAccount.ClearSelection()
        cmbAccount0.ClearSelection()
        txtRecFrom.Text = ""
        rdbPayType.SelectedIndex = -1
        rdbType0.SelectedIndex = -1
    End Sub

    Public Sub ClearFeilds1()
        loadBathces()
        txtAmount.Text = ""
        txtdesc.Text = ""
        txtRef.Text = ""
        cmbAccount.SelectedIndex = cmbAccount.Items.Count - 1
        txtRecFrom.Text = ""
        rdbPayType.SelectedIndex = -1
        rdbType0.SelectedIndex = -1
        grdDetails0.DataSource = Nothing
        grdDetails0.DataBind()
        grdDetails.DataSource = Nothing
        grdDetails.DataBind()
    End Sub
    Protected Sub rdbPayType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rdbPayType.SelectedIndexChanged
        If rdbPayType.SelectedIndex = 1 Then
            cmbAccount0.Visible = True
            loadBanks()
        Else
            'cmbAccount0.Visible = False
            'cmbAccount0.DataSource = Nothing
            'cmbAccount0.DataBind()
            cmbAccount0.Visible = True
            loadCash()
        End If
    End Sub
    Protected Sub loadBanks()
        Try
            'cmd = New SqlCommand("select * from tbl_BankAccounts", con)
            'cmd = New SqlCommand("select *,convert(varchar,MainAccount) +'/'+ convert(varchar,SubAccount) as Acc,AccountName + ' | ' + CONVERT(varchar,mainaccount) + '/' + CONVERT(varchar,subaccount) as 'AccName' from [tbl_FinancialAccountsCreation] where MainAccount='212' and SubAccount<>1 order by AccountName", con)
            cmd = New SqlCommand("select accountName + ' | ' + accountNo as AccName,accountNo AS Accno from cashbookaccounts", con)
            Dim ds As New DataSet
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "banks")
            loadCombo(ds.Tables(0), cmbAccount0, "AccName", "AccNo")
            'If ds.Tables(0).Rows.Count > 0 Then
            '    cmbAccount0.DataSource = ds
            '    'cmbAccount0.DataTextField = "Code"
            '    'cmbAccount0.DataValueField = "id"
            '    cmbAccount0.DataTextField = "AccName"
            '    cmbAccount0.DataValueField = "Acc"
            '    cmbAccount0.DataBind()
            '    cmbAccount0.Items.Add("-Select-")
            '    cmbAccount0.SelectedIndex = cmbAccount0.Items.Count - 1
            'Else
            '    cmbAccount0.DataSource = Nothing
            '    cmbAccount0.DataBind()
            'End If

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub loadCash()
        Try
            'cmd = New SqlCommand("select *,convert(varchar,MainAccount) +'/'+ convert(varchar,SubAccount) as Acc,AccountName + ' | ' + CONVERT(varchar,mainaccount) + '/' + CONVERT(varchar,subaccount) as 'AccName' from [tbl_FinancialAccountsCreation] where MainAccount='211' and SubAccount<>1 order by AccountName", con)
            cmd = New SqlCommand("select accountName + ' | ' + accountNo as AccName,accountNo AS Accno from cashbookaccounts", con)
            Dim ds As New DataSet
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "banks")
            loadCombo(ds.Tables(0), cmbAccount0, "AccName", "AccNo")
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub cmbBatchNo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbBatchNo.SelectedIndexChanged
        'loadGrid2()
        loadGrid()
        getBatchDetails(cmbBatchNo.SelectedValue)
    End Sub

    Protected Sub cmbAccount_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbAccount.SelectedIndexChanged
        '  Try

        cmd = New SqlCommand("select [Default]  from tbl_FinancialAccountsCreation where [AccountName]= '" & cmbAccount.SelectedItem.Text & "'", con)
        Dim ds As New DataSet
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "Accounts")
        If ds.Tables(0).Rows.Count > 0 Then
            lblDefault.Text = ds.Tables(0).Rows(0).Item("Default").ToString
        End If
        If cmbAccount.SelectedValue = "100/1" Then
            lblLoanDebtor.Visible = True
            cmbAccount1.Visible = True
            loadIndvAccs()
        Else
            lblLoanDebtor.Visible = False
            cmbAccount1.Visible = False

        End If
        If cmbAccount.SelectedValue = "213/1" Then
            lblLoanDebtor.Visible = True
            cmbAccount1.Visible = True
            loadIndvAccs()
        Else
            lblLoanDebtor.Visible = False
            cmbAccount1.Visible = False

        End If

        'Catch ex As Exception
        '    msgbox(ex.ToString)
        'End Try
    End Sub

    Protected Sub loadIndvAccs()
        Try
            cmd = New SqlCommand("select distinct isnull([SURNAME],'')+' '+ isnull([FORENAMES],'') + ' | ' + CUSTOMER_NUMBER as Name, CUSTOMER_NUMBER from CUSTOMER_DETAILS order by 'Name'", con)
            Dim ds As New DataSet
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "QUEST_APPLICATION")
            loadCombo(ds.Tables(0), cmbAccount1, "Name", "CUSTOMER_NUMBER")
            'If ds.Tables(0).Rows.Count > 0 Then
            '    cmbAccount1.DataSource = ds
            '    cmbAccount1.DataTextField = "Name"
            '    cmbAccount1.DataValueField = "CUSTOMER_NUMBER"
            '    cmbAccount1.DataBind()
            '    cmbAccount1.Items.Add("-Select-")
            '    cmbAccount1.SelectedIndex = cmbAccount1.Items.Count - 1
            'Else
            '    cmbAccount1.DataSource = Nothing
            '    cmbAccount1.DataBind()
            'End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim i As Integer
            For i = 0 To grdDetails.Rows.Count - 1
                Dim ch As CheckBox = CType(grdDetails.Rows(i).Cells(0).FindControl("CheckBox2"), CheckBox)
                If ch.Checked Then
                    Using cmd = New SqlCommand("delete from  Acc_Trans_Temp where ID=" & grdDetails.Rows(i).Cells(1).Text & "", con)
                        cmd.CommandType = CommandType.Text
                        If con.State = ConnectionState.Open Then
                            con.Close()
                        End If
                        con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    End Using
                End If
            Next
            loadGrid()
        Catch ex As Exception

        End Try
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
    End Sub

    Protected Sub getBatchDetails(bRef As String)
        Try
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd As New SqlCommand("select BatchNo, convert(varchar,BatchDate,106) as [Batch Date], BatchName as [Description], NumberOfTrxns as [Number of Trxns],format(Amount,'c') as Amount,CreatedBy as [Created By],convert(varchar,DateCreated,113) as [Date Created] from tbl_BatchRec where [BatchNo]='" & bRef & "'", con)
                    Dim ds As New DataSet
                    Dim adp = New SqlDataAdapter(cmd)
                    adp.Fill(ds, "APP")
                    CreditManager.bindGrid(ds.Tables(0), grdDetails0)
                End Using
            End Using
        Catch ex As Exception
            ErrorLogging.WriteLogFile(Session("UserId"), "Accounting/Cashbook - getBatchDetails()", ex.Message)
        End Try
    End Sub
End Class