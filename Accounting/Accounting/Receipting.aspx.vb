Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports CreditManager
Imports ErrorLogging

Partial Class Accounting_Receipting
    Inherits System.Web.UI.Page
    Dim cmd As SqlCommand
    Dim con As New SqlConnection
    Dim adp As New SqlDataAdapter
    Public Sub msgbox(ByVal strMessage As String)

        'finishes server processing, returns to client.
        Dim strScript As String = "<script language=JavaScript>"
        strScript += "window.alert(""" & strMessage & """);"
        strScript += "</script>"
        Dim lbl As New System.Web.UI.WebControls.Label
        lbl.Text = strScript
        Page.Controls.Add(lbl)

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
            If cmbAccount.SelectedValue = "-Select-" Or cmbAccount.SelectedValue = "" Or cmbAccount1.SelectedValue = "-Select-" Or cmbAccount1.SelectedValue = "" Then
                msgbox("Account Is Mandatory")
                cmbAccount.Focus()
                Exit Function
            End If
            If txtRef.Text = "" Then
                msgbox("Ref Is Mandatory")
                txtRef.Focus()
                Exit Function
            End If
            If cmbBatchNo.SelectedItem.Text = "-Select-" Then
                msgbox("Select a valid Batch")
                cmbBatchNo.Focus()
                Exit Function
            End If
            Checkfeilds = True
        Catch ex As Exception

        End Try
    End Function

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Page.MaintainScrollPositionOnPostBack = True
        con = New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
        If Not IsPostBack Then
            loadBathces()
            loadFinAccs()
            loadIndvAccs()
            getCutOffDate()
            getCashCutOffDate()
        End If
    End Sub

    Protected Sub loadFinAccs()
        Try
            'cmd = New SqlCommand("select AccountName + ' | ' + convert(varchar,MainAccount) +'/'+ convert(varchar,SubAccount) as AccountName, convert(varchar,MainAccount) +'/'+ convert(varchar,SubAccount) as 'Accno' from tbl_FinancialAccountsCreation where SubAccount<>1 union select Distinct(isnull([SURNAME],'')+' '+ isnull([FORENAMES],'') + ' | ' + isnull(CUSTOMER_NUMBER,'')) as AccountName, CUSTOMER_NUMBER as 'Accno' from CUSTOMER_DETAILS order by 'AccountName'", con)
            cmd = New SqlCommand("select AccountName + ' | ' + convert(varchar,MainAccount) as AccountName, convert(varchar,MainAccount) as 'Accno' from tbl_FinancialAccountsCreation union select Distinct(isnull([SURNAME],'')+' '+ isnull([FORENAMES],'') + ' | ' + isnull(CUSTOMER_NUMBER,'')) as AccountName, CUSTOMER_NUMBER as 'Accno' from CUSTOMER_DETAILS union select accountName + ' | ' + accountNo as AccountName,accountNo AS Accno from cashbookaccounts union select accountName + ' | ' + accountNo as AccountName,accountNo AS Accno from CreditorAccounts union select accountName + ' | ' + accountNo as AccountName,accountNo AS Accno from DebtorAccounts order by 'AccountName'", con)
            Dim ds As New DataSet
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "AccountsTypes")
            If ds.Tables(0).Rows.Count > 0 Then
                cmbAccount.DataSource = ds
                cmbAccount.DataTextField = "AccountName"
                cmbAccount.DataValueField = "Accno"
                cmbAccount.DataBind()
                cmbAccount.Items.Add("-Select-")
                cmbAccount.SelectedIndex = cmbAccount.Items.Count - 1
            Else
                cmbAccount.DataSource = Nothing
                cmbAccount.DataBind()
            End If

        Catch ex As Exception
            msgbox(ex.Message)
        End Try

    End Sub
    Protected Sub loadBathces()
        '  Try
        cmd = New SqlCommand("select * from [tbl_BatchRec] where BatchType= 'Receipting' and [status]=0", con)
        Dim ds As New DataSet
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "BatchRec")
        If ds.Tables(0).Rows.Count > 0 Then
            cmbBatchNo.DataSource = ds
            cmbBatchNo.DataTextField = "BatchNo"
            cmbBatchNo.DataValueField = "id"
            cmbBatchNo.DataBind()
            cmbBatchNo.Items.Add(" ")
            cmbBatchNo.SelectedIndex = cmbBatchNo.Items.Count - 1
        Else
            cmbBatchNo.DataSource = Nothing
            cmbBatchNo.DataBind()
        End If

        'Catch ex As Exception
        'msgbox(ex.Message)
        'End Try
    End Sub
    Protected Sub loadIndvAccs()
        Try
            cmd = New SqlCommand("select [SURNAME]+' '+ [FORENAMES] + ' | ' + CUSTOMER_NUMBER as Name, CUSTOMER_NUMBER from CUSTOMER_DETAILS order by 'Name'", con)
            Dim ds As New DataSet
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "QUEST_APPLICATION")
            If ds.Tables(0).Rows.Count > 0 Then
                cmbAccount0.DataSource = ds
                cmbAccount0.DataTextField = "Name"
                cmbAccount0.DataValueField = "CUSTOMER_NUMBER"
                cmbAccount0.DataBind()
                cmbAccount0.Items.Add("-Select-")
                cmbAccount0.SelectedIndex = cmbAccount0.Items.Count - 1
            Else
                cmbAccount0.DataSource = Nothing
                cmbAccount0.DataBind()
            End If

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub loadGrid()
        Try
            cmd = New SqlCommand("select * from Accounts_Transactions where BatchRef= '" & cmbBatchNo.SelectedItem.Text & "'", con)
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

    Protected Sub loadGrid2()
        Try
            cmd = New SqlCommand("select [BatchNo],[BatchType] ,[Amount] ,[NumberOfTrxns],[CreatedBy],convert(varchar,[DateCreated],106) as BatchDate from tbl_BatchRec where [BatchNo]= '" & cmbBatchNo.SelectedItem.Text & "'", con)
            Dim ds As New DataSet
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "Accounts")
            If ds.Tables(0).Rows.Count > 0 Then
                grdDetails0.DataSource = ds.Tables(0)
                grdDetails0.DataBind()
            Else
                grdDetails0.DataSource = Nothing
                grdDetails0.DataBind()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub btnSaveTrxn_Click(sender As Object, e As EventArgs) Handles btnSaveTrxn.Click
        ' Try
        If cmbBatchNo.Text.Trim <> "" Then
            cmd = New SqlCommand("select (amount) as batch_amount, sum(debit) as debits, sum(credit) as credits, count(b.id) as trxns from tbl_BatchRec a, Accounts_Transactions b where a.batchno=b.batchref and  a.BatchNo= '" & cmbBatchNo.SelectedItem.Text & "' group by amount", con)
            Dim ds As New DataSet
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "batch")
            'msgbox(cmd.CommandText)
            If ds.Tables(0).Rows.Count > 0 Then
                If ds.Tables(0).Rows(0).Item("batch_amount") <> ds.Tables(0).Rows(0).Item("debits") Or ds.Tables(0).Rows(0).Item("debits") <> ds.Tables(0).Rows(0).Item("credits") Then
                    msgbox("Batch Not Balanced, Not Comitted!")
                    Exit Sub
                Else
                    cmd = New SqlCommand("Update tbl_BatchRec set status = 1 where BatchNo='" & cmbBatchNo.SelectedItem.Text & "'", con)
                    If con.State = ConnectionState.Open Then
                        con.Close()
                    End If
                    con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                    loadBathces()
                    ClearFeilds()

                    'msgbox("Batch Balanced, Committed")
                    'Response.Redirect("~/Accounting/Cashbook.aspx")
                    Response.Write("<script>alert('Batch Balanced, Committed') ; location.href='~/Accounting/Cashbook.aspx'</script>")

                End If
            End If
        Else

        End If

        'Catch ex As Exception
        '    msgbox(ex.Message)
        'End Try
    End Sub

    Protected Sub BalanceBatch()
        Try

        Catch ex As Exception
            msgbox(ex.ToString)
        End Try
    End Sub

    Protected Sub btnSaveTrxn3_Click(sender As Object, e As EventArgs) Handles btnSaveTrxn3.Click
        Try
            If isCashAccount(cmbAccount.SelectedValue) Or isCashAccount(cmbAccount1.SelectedValue) Then
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
                Dim PayType As String
                'If rdbPayType.SelectedIndex = 0 Then
                '    PayType = "211/26"
                'Else
                '    PayType = "212/2"
                'End If
                PayType = cmbAccount1.SelectedValue
                Dim cramount, dramount As Double
                dramount = 0.0
                cramount = CDbl(txtAmount.Text)

                cmd = New SqlCommand("SaveAccountsTrxns", con)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("@Type", "Receipt")
                cmd.Parameters.AddWithValue("@Category", "")
                cmd.Parameters.AddWithValue("@Ref", txtRef.Text)
                cmd.Parameters.AddWithValue("@Desc", txtdesc.Text)
                cmd.Parameters.AddWithValue("@Debit", dramount)
                cmd.Parameters.AddWithValue("@Credit", cramount)
                cmd.Parameters.AddWithValue("@Account", cmbAccount.SelectedValue)
                cmd.Parameters.AddWithValue("@ContraAccount", PayType)
                cmd.Parameters.AddWithValue("@Status", IIf(rdbType0.SelectedIndex = 0, 1, 0))
                cmd.Parameters.AddWithValue("@Other", IIf(cmbAccount0.SelectedValue <> "-Select-", cmbAccount0.SelectedValue, 0))
                cmd.Parameters.AddWithValue("@BankAccID", "")
                cmd.Parameters.AddWithValue("@BankAccName", "")
                cmd.Parameters.AddWithValue("@BatchRef", cmbBatchNo.SelectedItem.Text)
                cmd.Parameters.AddWithValue("@TrxnDate", dtpTrxnDate.Text)

                If con.State = ConnectionState.Open Then
                    con.Close()
                End If
                con.Open()
                If cmd.ExecuteNonQuery() Then
                    If SaveContra() = True Then
                        msgbox("Receipt Saved Successfully")
                        loadGrid()
                        ClearFeilds()
                    Else
                        msgbox("Error Saving Details")
                    End If

                Else
                    msgbox("Error Saving Details")
                End If
                con.Close()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Public Function SaveContra() As Boolean
        SaveContra = False
        Try
            SaveContra = False
            Dim bankacc As String = ""
            Dim acc As Integer = 0
            If Checkfeilds() = True Then
                Dim PayType As String
                'If rdbPayType.SelectedIndex = 0 Then
                '    PayType = "211/26"
                '    bankacc = ""
                '    acc = 0
                'Else
                '    PayType = "212/2"
                '    If cmbAccount1.Text = "" Then
                '        bankacc = ""
                '        acc = 0
                '    Else
                '        bankacc = cmbAccount1.SelectedItem.Text
                '        acc = cmbAccount1.SelectedValue
                '    End If
                'End If
                PayType = cmbAccount1.SelectedValue
                Dim cramount, dramount As Double
                dramount = CDbl(txtAmount.Text)
                cramount = 0.0

                cmd = New SqlCommand("SaveAccountsTrxns", con)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("@Type", "Receipt")
                cmd.Parameters.AddWithValue("@Category", "")
                cmd.Parameters.AddWithValue("@Ref", txtRef.Text)
                cmd.Parameters.AddWithValue("@Desc", txtdesc.Text)
                cmd.Parameters.AddWithValue("@Debit", dramount)
                cmd.Parameters.AddWithValue("@Credit", cramount)
                cmd.Parameters.AddWithValue("@Account", PayType)
                cmd.Parameters.AddWithValue("@ContraAccount", cmbAccount.SelectedValue)
                cmd.Parameters.AddWithValue("@Status", IIf(rdbType0.SelectedIndex = 0, 1, 0))
                cmd.Parameters.AddWithValue("@Other", IIf(cmbAccount0.SelectedValue <> "-Select-", cmbAccount0.SelectedValue, 0))
                cmd.Parameters.AddWithValue("@BankAccID", acc)
                cmd.Parameters.AddWithValue("@BankAccName", bankacc)
                cmd.Parameters.AddWithValue("@BatchRef", cmbBatchNo.SelectedItem.Text)
                cmd.Parameters.AddWithValue("@TrxnDate", dtpTrxnDate.Text)

                If con.State = ConnectionState.Open Then
                    con.Close()
                End If
                con.Open()
                If cmd.ExecuteNonQuery() Then
                    SaveContra = True
                Else
                    msgbox("Error Saving Details")
                End If
                con.Close()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Function
    Public Sub ClearFeilds()
        txtAmount.Text = ""
        txtdesc.Text = ""
        txtRef.Text = ""
        cmbAccount.ClearSelection()
        cmbAccount0.ClearSelection()
        rdbPayType.ClearSelection()
        rdbType0.ClearSelection()
    End Sub

    Protected Sub rdbPayType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rdbPayType.SelectedIndexChanged
        If rdbPayType.SelectedValue = "Bank" Then
            'cmbAccount1.Visible = True
            'loadAccounts("212")
            loadCashAccounts()
            'loadBanks()
        ElseIf rdbPayType.SelectedValue = "Cash" Then
            'cmbAccount1.Visible = False
            'cmbAccount1.DataSource = Nothing
            'cmbAccount1.DataBind()
            'loadAccounts("211")
            loadCashAccounts()
        End If
    End Sub

    'Protected Sub loadAccounts(mainAcc As String)
    '    Try
    '        Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
    '            Using cmd = New SqlCommand("select convert(varchar,MainAccount)  + '/' + convert(varchar,SubAccount) as AccountNo, AccountName  + '  ' + convert(varchar,MainAccount)  + '/' + convert(varchar,SubAccount) as AccountName from tbl_FinancialAccountsCreation where MainAccount='" & mainAcc & "' and SubAccount<>1", con)
    '                'End if
    '                Dim ds As New DataSet
    '                Using adp = New SqlDataAdapter(cmd)
    '                    adp.Fill(ds, "LRS2")
    '                End Using
    '                cmbAccount1.Visible = True
    '                CreditManager.loadCombo(ds.Tables(0), cmbAccount1, "AccountName", "AccountNo")
    '            End Using
    '        End Using
    '    Catch ex As Exception
    '        ErrorLogging.WriteLogFile(Session("UserId"), Request.Url.ToString & " --- loadAccounts()", ex.ToString)
    '    End Try
    'End Sub

    Protected Sub loadCashAccounts()
        Try
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd = New SqlCommand("select AccountNo, AccountName  + '  ' + convert(varchar,AccountNo) as AccountName from CashbookAccounts", con)
                    'End if
                    Dim ds As New DataSet
                    Using adp = New SqlDataAdapter(cmd)
                        adp.Fill(ds, "LRS2")
                    End Using
                    cmbAccount1.Visible = True
                    CreditManager.loadCombo(ds.Tables(0), cmbAccount1, "AccountName", "AccountNo")
                End Using
            End Using
        Catch ex As Exception
            ErrorLogging.WriteLogFile(Session("UserId"), Request.Url.ToString & " --- loadAccounts()", ex.ToString)
        End Try
    End Sub

    Protected Sub loadBanks()
        Try
            cmd = New SqlCommand("select * from tbl_BankAccounts", con)
            Dim ds As New DataSet
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "banks")
            If ds.Tables(0).Rows.Count > 0 Then
                cmbAccount1.DataSource = ds
                cmbAccount1.DataTextField = "Code"
                cmbAccount1.DataValueField = "id"
                cmbAccount1.DataBind()
                cmbAccount1.Items.Add("-Select-")
                cmbAccount1.SelectedIndex = cmbAccount1.Items.Count - 1
            Else
                cmbAccount1.DataSource = Nothing
                cmbAccount1.DataBind()
            End If

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub cmbBatchNo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbBatchNo.SelectedIndexChanged
        txtRef.Text = cmbBatchNo.SelectedItem.Text
        If Trim(cmbBatchNo.SelectedItem.Text) = "" Then
        Else
            loadGrid2()
            loadGrid()
        End If
    End Sub

    Protected Sub cmbAccount_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbAccount.SelectedIndexChanged
        If cmbAccount.SelectedItem.Text = "Loan Debtors" Then
            lblLoanDebtor.Visible = True
            cmbAccount0.Visible = True
            getDefault()
        Else
            lblLoanDebtor.Visible = False
            cmbAccount0.Visible = False
            getDefault()
        End If
    End Sub

    Public Sub getDefault()
        '  Try

        Using cmd = New SqlCommand("select [Default]  from tbl_FinancialAccountsCreation where [AccountName]=@accName", con)
            cmd.Parameters.AddWithValue("@accName", cmbAccount.SelectedItem.Text)
            Dim ds As New DataSet
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "Accounts")
            If ds.Tables(0).Rows.Count > 0 Then
                lblDefault.Text = ds.Tables(0).Rows(0).Item("Default").ToString
            End If
        End Using
        'Catch ex As Exception
        '    msgbox(ex.ToString)
        'End Try
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Try

        Dim i As Integer
        For i = 0 To grdDetails.Rows.Count - 1
            Dim ch As CheckBox
            ch = CType(grdDetails.Rows(i).Cells(0).FindControl("CheckBox2"), CheckBox)
            If ch.Checked Then

                cmd = New SqlCommand("delete from  Accounts_Transactions where ID=" & grdDetails.Rows(i).Cells(1).Text & "", con)
                cmd.CommandType = CommandType.Text
                If con.State = ConnectionState.Open Then
                    con.Close()
                End If
                con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            End If
        Next
        loadGrid()
        'Catch ex As Exception

        'End Try

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
End Class