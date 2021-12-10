Imports System.Data
Imports System.Data.SqlClient

Partial Class Accounting_ViewJournalEntries
    Inherits System.Web.UI.Page
    Dim cmd As SqlCommand
    Dim con As New SqlConnection
    Dim adp As New SqlDataAdapter
    Dim connection As String

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
        con = New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
        If Not IsPostBack Then

        End If
    End Sub
    Protected Sub loadGrid()
        Try
            If cmbType.SelectedValue = "Journals" Then
                cmd = New SqlCommand("select  ID, convert(varchar,TrxnDate,106) as Trxn_Date, Account, Refrence, Description, Debit, Credit, ContraAccount from tbl_Journal where convert(varchar,TrxnDate,106)>= '" & dtpTrxnDate.Text & "' and convert(varchar,TrxnDate,106)<='" & dtpTrxnDate0.Text & "'", con)
            ElseIf cmbType.SelectedValue = "Daily Transactions" Then
                If cmbAccount0.SelectedValue = "Loan Disbursments" Then
                    'cmd = New SqlCommand("select LOANID, convert(varchar,TRANS_DATE,105), convert(varchar,FIN_ACC) + ' - ' + convert(varchar,TRANS_DESC) AS 'ACCOUNT - TRXN DESCRIPTION', convert(varchar,FIN_ACC_CONTR) + ' - ' + B.AccountName AS 'CONTRA ACCOUNT',  DEBIT, CREDIT  from QUEST_TRANSACTIONS A, tbl_FinancialAccountsCreation B where A.FIN_ACC_CONTR=B.MainAccount  and convert(date,TRANS_DATE)>='" & dtpTrxnDate.Text & "' and convert(date,TRANS_DATE)<=convert(date,'" & dtpTrxnDate0.Text & "') AND FIN_ACC=101", con)
                    cmd = New SqlCommand("select Refrence, convert(varchar,TrxnDate,105), convert(varchar,Account) + ' - ' + convert(varchar,a.Description) AS 'ACCOUNT - TRXN DESCRIPTION', convert(varchar,ContraAccount) + ' - ' + contr.AccountName AS 'CONTRA ACCOUNT',  DEBIT, CREDIT from Accounts_Transactions a join tbl_FinancialAccountsCreation fac on a.Account=convert(varchar,fac.mainaccount)+ '/' + convert(varchar,fac.subaccount) join tbl_FinancialAccountsCreation contr on a.Account=convert(varchar,contr.mainaccount) + '/' + convert(varchar,contr.subaccount) and convert(date,TrxnDate)>='" & dtpTrxnDate.Text & "' and convert(date,TrxnDate)<=convert(date,'" & dtpTrxnDate0.Text & "') AND a.[Description]='Disbursement'", con)
                ElseIf cmbAccount0.SelectedValue = "Loan Repayments" Then
                    'cmd = New SqlCommand("select LOANID, convert(varchar,TrxnDate,105), convert(varchar,FIN_ACC) + ' - ' + convert(varchar,TRANS_DESC) AS 'ACCOUNT - TRXN DESCRIPTION', convert(varchar,FIN_ACC_CONTR) + ' - ' + B.AccountName AS 'CONTRA ACCOUNT',  DEBIT, CREDIT  from QUEST_TRANSACTIONS A, tbl_FinancialAccountsCreation B where A.FIN_ACC_CONTR=B.MainAccount  and convert(date,TrxnDate)>='" & dtpTrxnDate.Text & "' and convert(date,TrxnDate)<=convert(date,'" & dtpTrxnDate0.Text & "') AND FIN_ACC=110", con)
                    cmd = New SqlCommand("select Refrence, convert(varchar,TrxnDate,105), convert(varchar,Account) + ' - ' + convert(varchar,a.Description) AS 'ACCOUNT - TRXN DESCRIPTION', convert(varchar,ContraAccount) + ' - ' + contr.AccountName AS 'CONTRA ACCOUNT',  DEBIT, CREDIT from Accounts_Transactions a join tbl_FinancialAccountsCreation fac on a.Account=convert(varchar,fac.mainaccount)+ '/' + convert(varchar,fac.subaccount) join tbl_FinancialAccountsCreation contr on a.Account=convert(varchar,contr.mainaccount) + '/' + convert(varchar,contr.subaccount) and convert(date,TrxnDate)>='" & dtpTrxnDate.Text & "' and convert(date,TrxnDate)<=convert(date,'" & dtpTrxnDate0.Text & "') AND a.[Description] like '%repayment%'", con)
                ElseIf cmbAccount0.SelectedValue = "Interest On Loan" Then
                    'cmd = New SqlCommand("select LOANID, convert(varchar,TrxnDate,105), convert(varchar,FIN_ACC) + ' - ' + convert(varchar,TRANS_DESC) AS 'ACCOUNT - TRXN DESCRIPTION', convert(varchar,FIN_ACC_CONTR) + ' - ' + B.AccountName AS 'CONTRA ACCOUNT',  DEBIT, CREDIT  from QUEST_TRANSACTIONS A, tbl_FinancialAccountsCreation B where A.FIN_ACC_CONTR=B.MainAccount  and convert(date,TrxnDate)>='" & dtpTrxnDate.Text & "' and convert(date,TrxnDate)<=convert(date,'" & dtpTrxnDate0.Text & "') AND FIN_ACC=108", con)
                    cmd = New SqlCommand("select Refrence, convert(varchar,TrxnDate,105), convert(varchar,Account) + ' - ' + convert(varchar,a.Description) AS 'ACCOUNT - TRXN DESCRIPTION', convert(varchar,ContraAccount) + ' - ' + contr.AccountName AS 'CONTRA ACCOUNT',  DEBIT, CREDIT from Accounts_Transactions a join tbl_FinancialAccountsCreation fac on a.Account=convert(varchar,fac.mainaccount)+ '/' + convert(varchar,fac.subaccount) join tbl_FinancialAccountsCreation contr on a.Account=convert(varchar,contr.mainaccount) + '/' + convert(varchar,contr.subaccount) and convert(date,TrxnDate)>='" & dtpTrxnDate.Text & "' and convert(date,TrxnDate)<=convert(date,'" & dtpTrxnDate0.Text & "') AND a.[Description]='Interest to Maturity'", con)
                Else
                    'cmd = New SqlCommand("select LOANID, convert(varchar,TrxnDate,105), convert(varchar,FIN_ACC) + ' - ' + convert(varchar,TRANS_DESC) AS 'ACCOUNT - TRXN DESCRIPTION', convert(varchar,FIN_ACC_CONTR) + ' - ' + B.AccountName AS 'CONTRA ACCOUNT',  DEBIT, CREDIT  from QUEST_TRANSACTIONS A, tbl_FinancialAccountsCreation B where A.FIN_ACC_CONTR=B.MainAccount  and convert(date,TrxnDate)>='" & dtpTrxnDate.Text & "' and convert(date,TrxnDate)<=convert(date,'" & dtpTrxnDate0.Text & "')", con)
                    cmd = New SqlCommand("select Refrence, convert(varchar,TrxnDate,105), convert(varchar,Account) + ' - ' + convert(varchar,a.Description) AS 'ACCOUNT - TRXN DESCRIPTION', convert(varchar,ContraAccount) + ' - ' + contr.AccountName AS 'CONTRA ACCOUNT',  DEBIT, CREDIT from Accounts_Transactions a join tbl_FinancialAccountsCreation fac on a.Account=convert(varchar,fac.mainaccount)+ '/' + convert(varchar,fac.subaccount) join tbl_FinancialAccountsCreation contr on a.Account=convert(varchar,contr.mainaccount) + '/' + convert(varchar,contr.subaccount) and convert(date,TrxnDate)>='" & dtpTrxnDate.Text & "' and convert(date,TrxnDate)<=convert(date,'" & dtpTrxnDate0.Text & "')", con)
                End If
                'msgbox(cmd.CommandText.ToString)
            ElseIf cmbType.SelectedValue = "Receipting" Then
                cmd = New SqlCommand("select  ID, convert(varchar,TrxnDate,106) as Trxn_Date, Account, Refrence, Description, Debit, Credit, ContraAccount from Accounts_Transactions where convert(varchar,TrxnDate,106)>= '" & dtpTrxnDate.Text & "' and convert(varchar,TrxnDate,106)<='" & dtpTrxnDate0.Text & "' and [Type]='Receipt'", con)
            ElseIf cmbType.SelectedValue = "Cashbook" Then
                cmd = New SqlCommand("select  ID, convert(varchar,TrxnDate,106) as Trxn_Date, Account, Refrence, Description, Debit, Credit, ContraAccount from Accounts_Transactions where convert(varchar,TrxnDate,106)>= '" & dtpTrxnDate.Text & "' and convert(varchar,TrxnDate,106)<='" & dtpTrxnDate0.Text & "' and [Type]='Cashbook'", con)
            Else
                cmd = New SqlCommand("select cur.trxn_type as 'Trxn Type', convert(varchar,cur.FIN_ACC) + ' - ' + convert(varchar,d.AccountName)  as 'Account', cur.ID as 'Trxn Refs', cur.[DESCRIPTION], convert(varchar,cur.FIN_ACC_CONTR) + ' - ' + convert(varchar,e.AccountName) as 'Contra Account', case cur.TRXN_TYPE when 'D' then convert(money,sum(cur.TRXN_AMT)) when 'C' then sum(cur.trxn_amt) when 'T' then '$' +convert(money,sum(cur.trxn_amt)) else 0.00 end as DR,  case cur.TRXN_TYPE when 'W' then sum(cur.TRXN_AMT) else 0.00 end as CR,isnull(sum(cur.trxn_amt),0) + isnull(sum(prev.TRXN_AMT),0) as 'Cumm Bal' from BANK_ACCOUNTS b, BANK_CUSTOMER_DETAILS c, BANK_TRANSACTION_SUMMARY cur,  BANK_TRANSACTION_SUMMARY prev, tbl_FinancialAccountsCreation d, tbl_FinancialAccountsCreation e where cur.ACC_NO=b.ACC_NO and b.CUST_NO=c.CUSTOMER_NUMBER and  cur.TRXN_DATE >= prev.TRXN_DATE and convert(varchar,cur.TRXN_DATE,105)>=convert(varchar,'" & dtpTrxnDate.Text & "',105) and convert(varchar,cur.TRXN_DATE,105)<=convert(varchar,'" & dtpTrxnDate0.Text & "',105) and cur.FIN_ACC=d.MainAccount and cur.FIN_ACC_CONTR=e.MainAccount  group by cur.ACC_NO, cur.TRXN_DATE, cur.FIN_ACC, cur.TRXN_TYPE, convert(varchar,d.AccountName), cur.TRXN_TYPE+ ' - ' + convert(varchar,d.AccountName), cur.FIN_ACC_CONTR,  convert(varchar,cur.FIN_ACC_CONTR) + ' - ' + convert(varchar,e.AccountName), cur.ID, cur.[DESCRIPTION] order by cur.TRXN_DATE", con)
            End If
            Dim ds As New DataSet
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "Journal")
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

    Protected Sub btnSaveTrxn3_Click(sender As Object, e As EventArgs) Handles btnSaveTrxn3.Click
        loadGrid()
    End Sub

    Protected Sub cmbType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbType.SelectedIndexChanged
        If cmbType.SelectedValue = "Daily Transactions" Then
            cmbAccount0.Visible = True
            lblTType.Visible = True
            cmbAccount0.Items.Clear()
            cmbAccount0.Items.Add("All")
            cmbAccount0.Items.Add("Loan Disbursments")
            cmbAccount0.Items.Add("Loan Repayments")
            cmbAccount0.Items.Add("Interest On Loan")
        Else
            cmbAccount0.Visible = False
            lblTType.Visible = False
        End If
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If cmbType.SelectedIndex < 0 Then
            msgbox("Select Entry Type")
            cmbType.Focus()
            Exit Sub
        End If
        If Trim(dtpTrxnDate.Text.ToString) = "" Then
            msgbox("Select Date")
            cmbType.Focus()
            Exit Sub
        End If
        If Trim(dtpTrxnDate0.Text.ToString) = "" Then
            msgbox("Select Date")
            cmbType.Focus()
            Exit Sub
        End If
        Session("Account") = cmbType.Text.Trim
        Session("DateFrom") = dtpTrxnDate.Text
        Session("DateTo") = dtpTrxnDate0.Text
        Try
            Dim strscript As String
            strscript = "<script langauage=JavaScript>"
            strscript += "window.open('RptLedgerByEntryType.aspx')"
            strscript += "</script>"
            ClientScript.RegisterStartupScript(Me.GetType(), "newwin", strscript)
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

End Class