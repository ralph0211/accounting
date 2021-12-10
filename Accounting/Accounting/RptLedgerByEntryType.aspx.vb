Imports System.Data
Imports System.Data.SqlClient

Partial Class Accounting_RptLedgerByEntryType
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
        lblAccount.Text = Session("Account").ToString & " Account"
        lblDateFrom.Text = Session("DateFrom").ToString
        lblDateTo.Text = Session("DateTo").ToString
        Page.MaintainScrollPositionOnPostBack = True
        con = New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
        If Not IsPostBack Then
            'Try
            If Session("Account").ToString = "Journals" Then
                'cmd = New SqlCommand("select  a.ID, convert(varchar,TrxnDate,106) as Trxn_Date, AccountName, Refrence, a.Description, Debit, Credit, ContraAccount from Accounts_Transactions  a left outer join tbl_FinancialAccountsCreation b on a.Account= convert(varchar,b.mainaccount) +'/'+ convert(varchar,b.subaccount)  where TrxnDate>='" & Session("datefrom").ToString & "' and TrxnDate <='" & Session("dateto").ToString & "' and a.[Type]='Journal Entry'", con)
                cmd = New SqlCommand("select  ID, convert(varchar,TrxnDate,106) as Trxn_Date, Account, Refrence, Description, Debit, Credit, ContraAccount from tbl_Journal where convert(varchar,TrxnDate,106)>= '" & Session("datefrom").ToString & "' and convert(varchar,TrxnDate,106)<='" & Session("dateto").ToString & "'", con)
            ElseIf Session("Account").ToString = "Daily Transaction" Then
                cmd = New SqlCommand("select cur.TRXN_DATE, cur.trxn_type as 'Trxn Type', convert(varchar,cur.FIN_ACC) + ' - ' + convert(varchar,d.AccountName)  as 'Account', cur.ID as 'Trxn Refs', cur.[DESCRIPTION], convert(varchar,cur.FIN_ACC_CONTR) + ' - ' + convert(varchar,e.AccountName) as 'Contra Account',  case cur.TRXN_TYPE when 'D' then convert(money,sum(cur.TRXN_AMT)) when 'C' then sum(cur.trxn_amt) when 'T' then '$' +convert(money,sum(cur.trxn_amt)) else 0.00 end as DR,  case cur.TRXN_TYPE when 'W' then sum(cur.TRXN_AMT) else 0.00 end as CR,isnull(sum(cur.trxn_amt),0) + isnull(sum(prev.TRXN_AMT),0) as 'Cumm Bal'  from BANK_ACCOUNTS b, BANK_CUSTOMER_DETAILS c, BANK_TRANSACTION_SUMMARY cur,  BANK_TRANSACTION_SUMMARY prev, tbl_FinancialAccountsCreation d, tbl_FinancialAccountsCreation e  where cur.ACC_NO=b.ACC_NO and b.CUST_NO=c.CUSTOMER_NUMBER and  cur.TRXN_DATE >= prev.TRXN_DATE  and cur.TRXN_DATE>=convert(date,'" & Session("datefrom").ToString & "') and cur.TRXN_DATE<=convert(date,'" & Session("dateto").ToString & "') and cur.FIN_ACC=d.MainAccount and cur.FIN_ACC_CONTR=e.MainAccount  group by cur.ACC_NO, cur.TRXN_DATE, cur.FIN_ACC, cur.TRXN_TYPE, convert(varchar,d.AccountName), cur.TRXN_TYPE+ ' - ' + convert(varchar,d.AccountName), cur.FIN_ACC_CONTR,  convert(varchar,cur.FIN_ACC_CONTR) + ' - ' + convert(varchar,e.AccountName), cur.ID, cur.[DESCRIPTION] order by cur.TRXN_DATE", con)
            ElseIf Session("Account").ToString = "Receipting" Then
                cmd = New SqlCommand("select  a.ID, convert(varchar,TrxnDate,106) as Trxn_Date, AccountName, Refrence,a. Description, Debit, Credit, ContraAccount from Accounts_Transactions  a left outer join tbl_FinancialAccountsCreation b on a.Account= convert(varchar,b.mainaccount) +'/'+ convert(varchar,b.subaccount)  where TrxnDate >='" & Session("datefrom").ToString & "' and TrxnDate <= '" & Session("dateto").ToString & "' and a.[Type]='Receipt'", con)
            ElseIf Session("Account").ToString = "Cashbook" Then
                cmd = New SqlCommand("select  a.ID, convert(varchar,TrxnDate,106) as Trxn_Date, AccountName, Refrence, a.Description, Debit, Credit, ContraAccount from Accounts_Transactions  a left outer join tbl_FinancialAccountsCreation b on a.Account= convert(varchar,b.mainaccount) +'/'+ convert(varchar,b.subaccount)  where TrxnDate >='" & Session("datefrom").ToString & "' and TrxnDate <='" & Session("dateto").ToString & "' and Account='Cash'", con)
            Else
                cmd = New SqlCommand("select  a.ID, convert(varchar,TrxnDate,106) as Trxn_Date, AccountName, Refrence, a.Description, Debit, Credit, ContraAccount from Accounts_Transactions a left outer join tbl_FinancialAccountsCreation b on a.Account= convert(varchar,b.mainaccount) +'/'+ convert(varchar,b.subaccount)  where TrxnDate >='" & Session("datefrom").ToString & "' and TrxnDate <='" & Session("dateto").ToString & "'", con)
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
            'Catch ex As Exception
            '    '        MsgBox(ex.Message)
            'End Try
        End If
    End Sub

End Class
