Imports System
Imports System.Data
Imports System.Data.SqlClient

Partial Class Accounting_rptaccountStatement
    Inherits System.Web.UI.Page
    Dim adp As New SqlDataAdapter
    Dim cmd As SqlCommand
    Dim con As New SqlConnection
    Dim connection As String

    Public Sub getBankStatement(ByVal strAccount As String)
        Try
            'cmd = New SqlCommand("select TrxnDate as'Transaction Date',ID as 'Ledger ID', BatchRef as 'Ref', [Description], [Type], Debit,Credit from Accounts_Transactions where account='Bank' and BankAccName='" & strAccount & "'", con)
            cmd = New SqlCommand("select TrxnDate as'Transaction Date',ID as 'Ledger ID', BatchRef as 'Ref', [Description], [Type], Debit,Credit from Accounts_Transactions where account='" & strAccount & "'", con)
            Dim ds As New DataSet
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "banks")
            If ds.Tables(0).Rows.Count > 0 Then
                grdDetails.DataSource = ds
                grdDetails.DataBind()
                lblNoTrxns.Visible = False
            Else
                lblNoTrxns.Visible = True
                grdDetails.DataSource = Nothing
                grdDetails.DataBind()
            End If

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Public Sub getLoanDebtors(ByVal strAccount As String)
        Try
            Dim acc() As String
            acc = strAccount.Split("|")
            strAccount = acc(1).Trim

            'cmd = New SqlCommand("select convert(varchar,TrxnDate,106) as'Transaction Date', ID as 'Ledger ID', BatchRef as 'Ref', [Description], [Type], Debit,Credit from Accounts_Transactions where (account='100/1') and Other='" & strAccount & "'  order by TrxnDate,ID asc", con)

            cmd = New SqlCommand("select convert(varchar,TrxnDate,106) as'Transaction Date', ID as 'Ledger ID', BatchRef as 'Ref', [Description], [Type], Debit,Credit from Accounts_Transactions where (account='213/1') and Other='" & strAccount & "'  order by TrxnDate,ID asc", con)

            'msgbox(cmd.CommandText)
            Dim ds As New DataSet
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "banks")
            If ds.Tables(0).Rows.Count > 0 Then
                grdDetails.DataSource = ds
                grdDetails.DataBind()
                lblNoTrxns.Visible = False
            Else
                lblNoTrxns.Visible = True
                grdDetails.DataSource = Nothing
                grdDetails.DataBind()
            End If

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Public Sub getOtherStatement(ByVal strAcc As String)
        '    Try
        'cmd = New SqlCommand("select TrxnDate as'Transaction Date', a.ID as 'Ledger ID', BatchRef as 'Ref', [Description] + ' :  ' + Other + ' | ' + b.FORENAMES + ' ' + b.SURNAME, [Type], Debit,Credit from Accounts_Transactions a left outer join QUEST_APPLICATION b on a.Other= b.CUSTOMER_NUMBER where a.account= (select  convert(varchar,mainaccount) +'/'+ convert(varchar,subaccount) from tbl_FinancialAccountsCreation where AccountName='" & strAcc & "') order by TrxnDate,a.ID", con)
        'cmd = New SqlCommand("select distinct * from (select convert(varchar,TrxnDate,106) as'Transaction Date', a.ID as 'Ledger ID', BatchRef as 'Ref', isnull([Description],'') + ' :  ' + isnull(Other,'') + ' | ' + isnull(b.FORENAMES,'') + ' ' + isnull(b.SURNAME,'') as [Description], [Type], Debit,Credit from Accounts_Transactions a left outer join QUEST_APPLICATION b on a.Other= b.CUSTOMER_NUMBER where a.account= (select  convert(varchar,mainaccount) +'/'+ convert(varchar,subaccount) from tbl_FinancialAccountsCreation where AccountName='Cash') and a.Refrence=convert(varchar,b.ID) union select convert(varchar,TrxnDate,106) as'Transaction Date', a.ID as 'Ledger ID', BatchRef as 'Ref', isnull([Description],'') + ' :  ' + isnull(Other,'') + ' | ' + isnull(b.FORENAMES,'') + ' ' + isnull(b.SURNAME,'') as [Description], [Type], Debit,Credit from Accounts_Transactions a left outer join QUEST_APPLICATION b on a.Other= b.CUSTOMER_NUMBER where a.account= (select  convert(varchar,mainaccount) +'/'+ convert(varchar,subaccount) from tbl_FinancialAccountsCreation where AccountName='Cash')) r order by r.[Transaction Date],[ledger ID]", con)
        'cmd = New SqlCommand("select distinct * from (select convert(varchar,TrxnDate,106) as'Transaction Date', a.ID as 'Ledger ID', BatchRef as 'Ref', isnull([Description],'') + ' :  ' + isnull(Other,'') + ' | ' + isnull(c.FORENAMES,'') + ' ' + isnull(c.SURNAME,'') as [Description], [Type], Debit,Credit from Accounts_Transactions a left outer join QUEST_APPLICATION b on a.Refrence= convert(varchar,b.id) join CUSTOMER_DETAILS c on b.CUSTOMER_NUMBER=c.CUSTOMER_NUMBER where a.account= (select  convert(varchar,mainaccount) +'/'+ convert(varchar,subaccount) from tbl_FinancialAccountsCreation where AccountName='Cash') and a.Refrence=convert(varchar,b.ID) union select convert(varchar,TrxnDate,106) as'Transaction Date', a.ID as 'Ledger ID', BatchRef as 'Ref', isnull([Description],'') + ' :  ' + isnull(Other,'') + ' | ' + isnull(b.FORENAMES,'') + ' ' + isnull(b.SURNAME,'') as [Description], [Type], Debit,Credit from Accounts_Transactions a left outer join QUEST_APPLICATION b on a.Other= b.CUSTOMER_NUMBER where a.account= (select  convert(varchar,mainaccount) +'/'+ convert(varchar,subaccount) from tbl_FinancialAccountsCreation where AccountName='Cash')) r order by r.[Transaction Date],[ledger ID]", con)
        'cmd = New SqlCommand("select distinct * from (select convert(varchar,TrxnDate,106) as'Transaction Date', a.ID as 'Ledger ID', BatchRef as 'Ref', isnull([Description],'') + ' :  ' + isnull(Other,'') + ' | ' + isnull(c.FORENAMES,'') + ' ' + isnull(c.SURNAME,'') as [Description], [Type], Debit,Credit from Accounts_Transactions a left outer join QUEST_APPLICATION b on a.Refrence= convert(varchar,b.id) join CUSTOMER_DETAILS c on b.CUSTOMER_NUMBER=c.CUSTOMER_NUMBER where a.account in (select  convert(varchar,mainaccount) +'/'+ convert(varchar,subaccount) from tbl_FinancialAccountsCreation where MainAccount='211') and a.Refrence=convert(varchar,b.ID) union select convert(varchar,TrxnDate,106) as'Transaction Date', a.ID as 'Ledger ID', BatchRef as 'Ref', isnull([Description],'') + ' :  ' + isnull(Other,'') + ' | ' + isnull(b.FORENAMES,'') + ' ' + isnull(b.SURNAME,'') as [Description], [Type], Debit,Credit from Accounts_Transactions a left outer join QUEST_APPLICATION b on a.Other= b.CUSTOMER_NUMBER where a.account in (select  convert(varchar,mainaccount) +'/'+ convert(varchar,subaccount) from tbl_FinancialAccountsCreation where MainAccount='211')) r order by r.[Transaction Date],[ledger ID]", con)
        cmd = New SqlCommand("select distinct * from (select convert(varchar,TrxnDate,106) as'Transaction Date', a.ID as 'Ledger ID', BatchRef as 'Ref', isnull([Description],'') + ' :  ' + isnull(Other,'') + ' | ' + isnull(c.FORENAMES,'') + ' ' + isnull(c.SURNAME,'') as [Description], [Type], Debit,Credit from Accounts_Transactions a left outer join QUEST_APPLICATION b on a.Refrence= convert(varchar,b.id) join CUSTOMER_DETAILS c on b.CUSTOMER_NUMBER=c.CUSTOMER_NUMBER where a.account = '" & strAcc & "' and a.Refrence=convert(varchar,b.ID) union select convert(varchar,TrxnDate,106) as'Transaction Date', a.ID as 'Ledger ID', BatchRef as 'Ref', isnull([Description],'') + ' :  ' + isnull(Other,'') + ' | ' + isnull(b.FORENAMES,'') + ' ' + isnull(b.SURNAME,'') as [Description], [Type], Debit,Credit from Accounts_Transactions a left outer join QUEST_APPLICATION b on a.Other= b.CUSTOMER_NUMBER where a.account = '" & strAcc & "') r order by [ledger ID]", con)
        Dim ds As New DataSet
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "banks")
        If ds.Tables(0).Rows.Count > 0 Then
            grdDetails.DataSource = ds
            grdDetails.DataBind()
            lblNoTrxns.Visible = False
        Else
            lblNoTrxns.Visible = True
            grdDetails.DataSource = Nothing
            grdDetails.DataBind()
        End If

        'Catch ex As Exception
        '    msgbox(ex.Message)
        'End Try
    End Sub

    Public Sub getTotals()

        Dim i As Integer
        Dim Dr, Cr, CB As Double
        Cr = 0.0
        Dr = 0.0
        CB = 0.0

        For i = 1 To grdDetails.Rows.Count - 1
            Dr = Dr + CDbl(grdDetails.Rows(i).Cells(4).Text)
            Cr = Cr + CDbl(grdDetails.Rows(i).Cells(5).Text)
            CB = lblOB.Text - CDbl(Cr - Dr)
        Next
        lblTotCr.Text = "$" & FormatNumber(Cr.ToString, 2, TriState.UseDefault)
        lblTotDr.Text = "$" & FormatNumber(Dr.ToString, 2, TriState.UseDefault)
        lblCB.Text = "$" & FormatNumber(CB.ToString, 2, TriState.UseDefault)
        lblOB.Text = "$" & FormatNumber(lblOB.Text, 2, TriState.UseDefault)
        If grdDetails.Rows.Count <= 1 Then
            lblCB.Text = lblOB.Text
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
    Protected Sub grdDetails_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles grdDetails.RowDataBound
        Try
            If e.Row.RowType = DataControlRowType.DataRow Or e.Row.RowType = DataControlRowType.Header Then
                e.Row.Cells(2).HorizontalAlign = HorizontalAlign.Right
                e.Row.Cells(3).HorizontalAlign = HorizontalAlign.Right
                e.Row.Cells(4).HorizontalAlign = HorizontalAlign.Right
                e.Row.Cells(5).HorizontalAlign = HorizontalAlign.Right
                e.Row.Cells(6).HorizontalAlign = HorizontalAlign.Right
            End If
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Page.MaintainScrollPositionOnPostBack = True
        con = New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
        If Not IsPostBack Then
            lblAccName.Text = lblAccName.Text & "    " & Session("Account").ToString
            lblAccType.Text = lblAccType.Text & "    " & Session("Type").ToString
            lblAccNo.Text = lblAccNo.Text & "    " & Session("AccNo").ToString
            lblPrintDate.Text = lblPrintDate.Text & "    " & Date.Now.ToString
            lblDateRange.Text = "From  " & Session("DateFrom").ToString & " To " & Session("DateTo").ToString
            If Session("type") <> Nothing Then
                If Session("Type").ToString = "Cash" Then
                    'getOtherStatement(Session("Account"))
                    'getOtherStatement(Session("AccNo"))
                    printStmt()
                ElseIf Session("Type").ToString = "Bank" Then
                    'getBankStatement(Session("AccNo"))
                    printStmt()
                ElseIf Session("Type").ToString = "Loans and Advances" Then
                    'getLoanDebtors(Session("Account"))
                    printAccStmt()
                Else
                    'getOtherStatement(Session("Account"))
                    printStmt()
                End If
            End If
            getTotals()
        End If
    End Sub

    Protected Sub printAccStmt()
        Try
            'cmd = New SqlCommand("select isnull(Sum(isnull(Debit,0)) - SUM(isnull(Credit,0)),0) as Bbfwd from Accounts_Transactions a left outer join tbl_FinancialAccountsCreation b on a.Account= convert(varchar,b.mainaccount) +'/'+ convert(varchar,b.subaccount) where convert(varchar,b.mainaccount) +'/'+ convert(varchar,b.subaccount)='" & Session("AccNo").ToString & "' and TrxnDate<'" & Session("DateFrom").ToString & "'", con)
            'cmd = New SqlCommand("select isnull(Sum(isnull(Debit,0)) - SUM(isnull(Credit,0)),0) as Bbfwd from Accounts_Transactions a where (account='213/1') and a.Other='" & Session("AccNo").ToString & "' and TrxnDate<'" & Session("DateFrom").ToString & "'", con)
            cmd = New SqlCommand("select isnull(Sum(isnull(Debit,0)) - SUM(isnull(Credit,0)),0) as Bbfwd from Accounts_Transactions a where account='" & Session("AccNo").ToString & "' and TrxnDate<'" & Session("DateFrom").ToString & "'", con)
            Dim dsBbfwd As New DataSet
            adp = New SqlDataAdapter(cmd)
            adp.Fill(dsBbfwd, "BBFWD")
            Dim bfwd = dsBbfwd.Tables(0).Rows(0).Item("Bbfwd")
            lblOB.Text = bfwd

            Dim cmdAccrued = New SqlCommand("select top 1 format(asd.CUMULATIVE_INTEREST,'n') as Bbfwd,format(asd.CUMULATIVE_PRINCIPAL,'n') as CapBFwd from AMORTIZATION_SCHEDULE_DAILY asd join QUEST_APPLICATION qa on asd.LOANID=qa.ID where qa.CUSTOMER_NUMBER='" & Session("AccNo").ToString & "' and asd.DAY_DATE<='" & Session("DateTo").ToString & "' order BY asd.DAY_DATE desc  SELECT SUM(Debit-Credit) as CapBal from Accounts_Transactions where (Description='Disbursement' OR Description='Capital Repayment') AND Account='" & Session("AccNo").ToString & "'", con)
            Dim dsAccrue As New DataSet
            Dim adpAcc = New SqlDataAdapter(cmdAccrued)
            adpAcc.Fill(dsAccrue, "BBFWD")
            Try
                Dim accrue = dsAccrue.Tables(0).Rows(0).Item("Bbfwd")
                lblAddress.Visible = True
                lblAddress.Text = "Accrued Interest: " & accrue
                lblAccruedCapital.Visible = True
                lblAccruedCapital.Text = "Capital Balance: " & dsAccrue.Tables(1).Rows(0).Item("CapBal")
            Catch ex As Exception
                lblAddress.Text = "Accrued Interest: 0"
                lblAccruedCapital.Text = "Capital Balance: 0"
            End Try

            cmd = New SqlCommand("select convert(varchar,'" & Session("DateFrom").ToString & "',113) as [Transaction Date],'Balance B/Fwd' as [Trxn Type],'' as [Loan ID],'' as [Receipt Number],'' as Debit,'' as Credit, FORMAT(" & bfwd & ",N'N') as 'Cumulative Balance'", con)
            Dim dsLedger As New DataSet
            adp = New SqlDataAdapter(cmd)
            adp.Fill(dsLedger, "bf")
            '    MsgBox(cmbAccount.SelectedValue.ToString)
            cmd = New SqlCommand("SP_GetAccStmt", con)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@DATEFROM", Session("DateFrom").ToString)
            cmd.Parameters.AddWithValue("@DATETO", Session("DateTo").ToString)
            cmd.Parameters.AddWithValue("@ACCNO", Session("AccNo").ToString)
            Dim ds As New DataSet
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "LEDGERS")
            For Each row As DataRow In ds.Tables(0).Rows
                dsLedger.Tables(0).ImportRow(row)
            Next
            If dsLedger.Tables(0).Rows.Count > 0 Then
                grdDetails.DataSource = dsLedger
                grdDetails.DataBind()
            Else
                grdDetails.DataSource = Nothing
                grdDetails.DataBind()
            End If
        Catch ex As Exception
            ErrorLogging.WriteLogFile(Session("UserId"), Request.Url.ToString & " --- printAccStmt()", ex.ToString)
        End Try
    End Sub

    Protected Sub printStmt()
        Try
            cmd = New SqlCommand("select isnull(Sum(isnull(Debit,0)) - SUM(isnull(Credit,0)),0) as Bbfwd from Accounts_Transactions a left outer join tbl_FinancialAccountsCreation b on a.Account= convert(varchar,b.mainaccount) +'/'+ convert(varchar,b.subaccount) where convert(varchar,b.mainaccount) +'/'+ convert(varchar,b.subaccount)='" & Session("AccNo").ToString & "' and TrxnDate<'" & Session("DateFrom").ToString & "'", con)
            Dim dsBbfwd As New DataSet
            adp = New SqlDataAdapter(cmd)
            adp.Fill(dsBbfwd, "BBFWD")
            Dim bfwd = dsBbfwd.Tables(0).Rows(0).Item("Bbfwd")
            lblOB.Text = bfwd

            cmd = New SqlCommand("select convert(varchar,'" & Session("DateFrom").ToString & "',113) as [Transaction Date],'Balance B/Fwd' as [Trxn Type],'' as [Trxn ID],'' as [.],'' as Debit,'' as Credit, FORMAT(" & bfwd & ",N'N') as 'Cumulative Balance'", con)
            Dim dsLedger As New DataSet
            adp = New SqlDataAdapter(cmd)
            adp.Fill(dsLedger, "bf")
            '    MsgBox(cmbAccount.SelectedValue.ToString)
            cmd = New SqlCommand("SP_GetLedger", con)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@DATEFROM", Session("DateFrom").ToString)
            cmd.Parameters.AddWithValue("@DATETO", Session("DateTo").ToString)
            cmd.Parameters.AddWithValue("@ACCNO", Session("AccNo").ToString)
            Dim ds As New DataSet
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "LEDGERS")
            For Each row As DataRow In ds.Tables(0).Rows
                dsLedger.Tables(0).ImportRow(row)
            Next
            If dsLedger.Tables(0).Rows.Count > 0 Then
                grdDetails.DataSource = dsLedger
                grdDetails.DataBind()
            Else
                grdDetails.DataSource = Nothing
                grdDetails.DataBind()
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class