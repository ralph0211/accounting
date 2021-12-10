Imports System.Data
Imports System.Data.SqlClient
Imports CreditManager
Imports ErrorLogging

Partial Class Accounting_YearEndProcessing
    Inherits System.Web.UI.Page

    Protected Sub btnSearchRange_Click(sender As Object, e As EventArgs) Handles btnSearchRange.Click
        Try
            Using con = New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                'Using cmd As New SqlCommand("SELECT fac.Type,trn.Account, isnull(trn.MainAccount,fac.MainAccount) as [MainAccount],trn.TrxnAccountName,fac.AccountName,CASE WHEN trn.Balance<0 THEN 0 ELSE trn.Balance END AS [Debit],CASE WHEN trn.Balance<0 THEN trn.Balance*-1 ELSE 0 END AS [Credit] FROM (SELECT k.*,isnull(ISNULL(ISNULL(csh.MainAccount,crd.MainAccount),dbt.MainAccount),case when k.Account LIKE 'SW/%' THEN 'SW' ELSE Account END) as [MainAccount],ISNULL(ISNULL(ISNULL(csh.AccountName,crd.AccountName),dbt.AccountName),isnull(cd.FORENAMES,'') +' '+isnull(cd.SURNAME,'')) as [TrxnAccountName] from (SELECT acct.Account,SUM(acct.Debit-acct.Credit) as Balance from Accounts_Transactions acct WHERE acct.TrxnDate<=@tDate GROUP BY acct.Account)k LEFT JOIN CashbookAccounts csh ON k.Account=csh.AccountNo LEFT JOIN CreditorAccounts crd ON k.Account=crd.AccountNo LEFT JOIN DebtorAccounts dbt ON k.Account=dbt.AccountNo LEFT JOIN CUSTOMER_DETAILS cd ON k.Account=cd.CUSTOMER_NUMBER) trn LEFT JOIN tbl_FinancialAccountsCreation fac ON trn.MainAccount=fac.MainAccount", con)
                Using cmd As New SqlCommand("SELECT fac.Type, isnull(trn.MainAccount,fac.MainAccount) as [MainAccount],fac.AccountName,CASE WHEN sum(trn.Balance)<0 THEN 0 ELSE sum(trn.Balance) END AS [Debit],CASE WHEN sum(trn.Balance)<0 THEN sum(trn.Balance)*-1 ELSE 0 END AS [Credit] FROM (SELECT k.*,isnull(ISNULL(ISNULL(csh.MainAccount,crd.MainAccount),dbt.MainAccount),case when k.Account LIKE 'SW/%' THEN 'SW' ELSE Account END) as [MainAccount],ISNULL(ISNULL(ISNULL(csh.AccountName,crd.AccountName),dbt.AccountName),isnull(cd.FORENAMES,'') +' '+isnull(cd.SURNAME,'')) as [TrxnAccountName] from (SELECT acct.Account,SUM(acct.Debit-acct.Credit) as Balance from Accounts_Transactions acct WHERE acct.TrxnDate<=@tDate GROUP BY acct.Account)k LEFT JOIN CashbookAccounts csh ON k.Account=csh.AccountNo LEFT JOIN CreditorAccounts crd ON k.Account=crd.AccountNo LEFT JOIN DebtorAccounts dbt ON k.Account=dbt.AccountNo LEFT JOIN CUSTOMER_DETAILS cd ON k.Account=cd.CUSTOMER_NUMBER) trn LEFT JOIN tbl_FinancialAccountsCreation fac ON trn.MainAccount=fac.MainAccount GROUP BY isnull(trn.MainAccount,fac.MainAccount),fac.Type,fac.AccountName HAVING (CASE WHEN sum(trn.Balance)<0 THEN 0 ELSE sum(trn.Balance) END>0 OR CASE WHEN sum(trn.Balance)<0 THEN sum(trn.Balance)*-1 ELSE 0 END>0)", con)
                    cmd.Parameters.AddWithValue("@tDate", txtEndDate.Text)
                    Dim dt As New DataTable
                    Using adp As New SqlDataAdapter(cmd)
                        adp.Fill(dt)
                    End Using
                    bindGrid(dt, grdApps)
                End Using
            End Using
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- btnSearchRange_Click()", ex.ToString)
        End Try
    End Sub
    Protected Sub btnProcess_Click(sender As Object, e As EventArgs) Handles btnProcess.Click
        Try
            If Trim(cmbMoveAccount.SelectedValue) = "" Then
                notify("Select the account to move balances to", "error")
            Else
                Dim accStr As String = "", cntr As Integer = 0
                For Each r As GridViewRow In grdApps.Rows
                    If r.RowType = DataControlRowType.DataRow Then
                        Dim chk As CheckBox = DirectCast(r.FindControl("chkProcess"), CheckBox)
                        Dim mainAcc As String = r.Cells(1).Text
                        If chk.Checked Then
                            'If cntr = 0 Then
                            '    accStr += "'" + mainAcc + "'"
                            'Else
                            '    accStr += ",'" + mainAcc + "'"
                            'End If
                            'cntr += 1
                            accStr = mainAcc
                            Using con = New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                                Using cmd As New SqlCommand("INSERT INTO [Accounts_Transactions] ([Type],[Category],[TrxnDate],[Account],[Refrence],[Description],[Debit],[Credit],[ContraAccount],[CostCode],[Status],[Other],[Committed],[BankAccID],[BankAccName],[BatchRef],[CaptureDate],[AccountName]) SELECT 'Year End','Year End Closing',DATEADD(DAY,1,@tDate),trn.Account,'YE'+CONVERT(VARCHAR,DATEADD(DAY,1,@tDate),112),'Year-end Closing',CASE WHEN trn.Balance<0 THEN trn.Balance*-1 ELSE 0 END AS [Credit],CASE WHEN trn.Balance<0 THEN 0 ELSE trn.Balance END AS [Debit],'" & cmbMoveAccount.SelectedValue & "','',1,Account,1,'','','YE'+CONVERT(VARCHAR,DATEADD(DAY,1,@tDate),112),GETDATE(),trn.TrxnAccountName FROM (SELECT k.*,isnull(ISNULL(ISNULL(csh.MainAccount,crd.MainAccount),dbt.MainAccount),case when k.Account LIKE pic.AccountPrefix+pic.AccountSeparator THEN pic.AccountPrefix ELSE Account END) as [MainAccount],ISNULL(ISNULL(ISNULL(csh.AccountName,crd.AccountName),dbt.AccountName),isnull(cd.FORENAMES,'') +' '+isnull(cd.SURNAME,'')) as [TrxnAccountName] from (SELECT acct.Account,SUM(acct.Debit-acct.Credit) as Balance from Accounts_Transactions acct WHERE acct.TrxnDate<=@tDate GROUP BY acct.Account)k LEFT JOIN CashbookAccounts csh ON k.Account=csh.AccountNo LEFT JOIN CreditorAccounts crd ON k.Account=crd.AccountNo LEFT JOIN DebtorAccounts dbt ON k.Account=dbt.AccountNo LEFT JOIN CUSTOMER_DETAILS cd ON k.Account=cd.CUSTOMER_NUMBER JOIN parainternalcontrols pic ON 1=1) trn LEFT JOIN tbl_FinancialAccountsCreation fac ON trn.MainAccount=fac.MainAccount WHERE isnull(trn.MainAccount,fac.MainAccount) IN (@accNos)", con)
                                    cmd.Parameters.AddWithValue("@tDate", txtEndDate.Text)
                                    cmd.Parameters.AddWithValue("@accNos", accStr)
                                    con.Open()
                                    If cmd.ExecuteNonQuery Then
                                        '    notify("Processed successfully", "success")
                                        'Else
                                        '    notify("Error processing year-end", "error")
                                    End If
                                    con.Close()
                                End Using
                                Using cmd As New SqlCommand("INSERT INTO [Accounts_Transactions] ([Type],[Category],[TrxnDate],[Account],[Refrence],[Description],[Credit],[Debit],[ContraAccount],[CostCode],[Status],[Other],[Committed],[BankAccID],[BankAccName],[BatchRef],[CaptureDate],[AccountName]) SELECT 'Year End','Year End Closing',DATEADD(DAY,1,@tDate),'" & cmbMoveAccount.SelectedValue & "','YE'+CONVERT(VARCHAR,DATEADD(DAY,1,@tDate),112),'Year-end Closing',CASE WHEN trn.Balance<0 THEN trn.Balance*-1 ELSE 0 END AS [Credit],CASE WHEN trn.Balance<0 THEN 0 ELSE trn.Balance END AS [Debit],trn.Account,'',1,'" & cmbMoveAccount.SelectedValue & "',1,'','','YE'+CONVERT(VARCHAR,DATEADD(DAY,1,@tDate),112),GETDATE(),'" & cmbMoveAccount.SelectedItem.Text & "' FROM (SELECT k.*,isnull(ISNULL(ISNULL(csh.MainAccount,crd.MainAccount),dbt.MainAccount),case when k.Account LIKE pic.AccountPrefix+pic.AccountSeparator THEN pic.AccountPrefix ELSE Account END) as [MainAccount],ISNULL(ISNULL(ISNULL(csh.AccountName,crd.AccountName),dbt.AccountName),isnull(cd.FORENAMES,'') +' '+isnull(cd.SURNAME,'')) as [TrxnAccountName] from (SELECT acct.Account,SUM(acct.Debit-acct.Credit) as Balance from Accounts_Transactions acct WHERE acct.TrxnDate<=@tDate GROUP BY acct.Account)k LEFT JOIN CashbookAccounts csh ON k.Account=csh.AccountNo LEFT JOIN CreditorAccounts crd ON k.Account=crd.AccountNo LEFT JOIN DebtorAccounts dbt ON k.Account=dbt.AccountNo LEFT JOIN CUSTOMER_DETAILS cd ON k.Account=cd.CUSTOMER_NUMBER JOIN parainternalcontrols pic ON 1=1) trn LEFT JOIN tbl_FinancialAccountsCreation fac ON trn.MainAccount=fac.MainAccount WHERE isnull(trn.MainAccount,fac.MainAccount) IN (@accNos)", con)
                                    cmd.Parameters.AddWithValue("@tDate", txtEndDate.Text)
                                    cmd.Parameters.AddWithValue("@accNos", accStr)
                                    con.Open()
                                    If cmd.ExecuteNonQuery Then
                                        '    notify("Processed successfully", "success")
                                        'Else
                                        '    notify("Error processing year-end", "error")
                                    End If
                                    con.Close()
                                End Using
                            End Using
                        End If
                    End If
                Next
                notify("Processed successfully", "success")
            End If
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- btnProcess_Click()", ex.ToString)
        End Try
    End Sub

    Protected Sub getMainAccounts(cmbMA As DropDownList)
        Try
            Using con = New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd = New SqlCommand("select mainaccount,AccountName+' - '+MainAccount as AccountName from [tbl_FinancialAccountsCreation]", con)
                    Dim dt As New DataTable
                    Using adp = New SqlDataAdapter(cmd)
                        adp.Fill(dt)
                    End Using
                    loadCombo(dt, cmbMA, "AccountName", "MainAccount")
                End Using
            End Using
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- getMainAccounts()", ex.ToString)
        End Try
    End Sub

    Private Sub Accounting_YearEndProcessing_Load(sender As Object, e As EventArgs) Handles Me.Load
        Page.MaintainScrollPositionOnPostBack = True
        If Not IsPostBack Then
            getMainAccounts(cmbMoveAccount)
        End If
    End Sub

    Private Sub grdApps_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles grdApps.RowDataBound
        Try
            Dim r As GridViewRow = e.Row
            If r.RowType = DataControlRowType.DataRow Then
                Dim typ = DirectCast(r.FindControl("lblType"), Label).Text
                Dim chk As CheckBox = DirectCast(r.FindControl("chkProcess"), CheckBox)
                If typ = "Income" Then
                    chk.Checked = True
                End If
            End If
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- grdApps_RowDataBound()", ex.ToString)
        End Try
    End Sub
End Class
