Imports System.Data
Imports System.Data.SqlClient
Imports CreditManager
Imports ErrorLogging
Imports BankString

Partial Class Credit_RollOver
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Page.MaintainScrollPositionOnPostBack = True
        If Not IsPostBack Then
            getOutstandingLoans(txtSearch.Text)
        End If
    End Sub

    Protected Sub getOutstandingLoans(srch As String)
        Try
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd = New SqlCommand("SELECT b.Refrence as [Loan ID],qa.CUSTOMER_NUMBER as [Customer Number],qa.FORENAMES +' '+qa.SURNAME as [Name],ISNULL(NULLIF(qa.RECOMMENDED_AMT,0),qa.FIN_AMT) as [Loan Amount],CONVERT(VARCHAR,qa.DISBURSED_DATE,106) as [Disbursement Date],CONVERT(VARCHAR,a.MaturityDate,106) as [Maturity Date],b.Balance as [Loan Balance] from (SELECT acct.Refrence,SUM(acct.Debit-acct.Credit) as Balance from Accounts_Transactions acct WHERE acct.Account IN (SELECT CUSTOMER_NUMBER from CUSTOMER_DETAILS) GROUP BY acct.Refrence HAVING SUM(debit-credit)>0) b join (SELECT am.LOANID,MAX(am.PAYMENT_DATE) as MaturityDate from AMORTIZATION_SCHEDULE am GROUP BY am.LOANID) a on b.refrence=CONVERT(VARCHAR, a.loanid) JOIN QUEST_APPLICATION qa ON qa.ID=a.LOANID where isnull(forenames,'')+' '+isnull(surname,'') like '%'+@sName+'%' or isnull(surname,'')+' '+isnull(forenames,'') like '%'+@sName+'%'", con)
                    cmd.Parameters.AddWithValue("@sName", Trim(srch))
                    Dim dt As New DataTable
                    Using adp As New SqlDataAdapter(cmd)
                        adp.Fill(dt)
                    End Using
                    bindGrid(dt, grdApps)
                End Using
            End Using
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- getOutstandingLoans()", ex.ToString)
        End Try
    End Sub

    Protected Sub grdApps_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles grdApps.PageIndexChanging
        grdApps.PageIndex = e.NewPageIndex
        getOutstandingLoans(txtSearch.Text)
    End Sub
    Protected Sub grdApps_SelectedIndexChanged(sender As Object, e As EventArgs) Handles grdApps.SelectedIndexChanged
        Try
            Dim row = grdApps.SelectedRow
            Dim lID As String = row.Cells(1).Text
            ViewState("loanID") = lID
            getLoanDetails(lID)
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- grdApps_SelectedIndexChanged()", ex.ToString)
        End Try
    End Sub
    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        getOutstandingLoans(txtSearch.Text)
    End Sub

    Protected Sub getLoanDetails(loanID As String)
        Try
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd = New SqlCommand("SELECT a.InterestAmt, b.Refrence as [LoanID],qa.CUSTOMER_NUMBER as [CustomerNumber],qa.FIN_INT_RATE,ISNULL(NULLIF(qa.RECOMMENDED_AMT,0),qa.FIN_AMT) as [LoanAmount],CONVERT(VARCHAR,qa.DISBURSED_DATE,106) as [DisbursementDate],CONVERT(VARCHAR,a.MaturityDate,106) as [MaturityDate],b.Balance as [LoanBalance] from (SELECT acct.Refrence,SUM(acct.Debit-acct.Credit) as Balance from Accounts_Transactions acct WHERE acct.Account IN (SELECT CUSTOMER_NUMBER from CUSTOMER_DETAILS) GROUP BY acct.Refrence HAVING SUM(debit-credit)>0) b join (SELECT am.LOANID,MAX(am.PAYMENT_DATE) as MaturityDate,MAX(am.CUMULATIVE_INTEREST) as InterestAmt from AMORTIZATION_SCHEDULE am GROUP BY am.LOANID) a on b.refrence=CONVERT(VARCHAR, a.loanid) JOIN QUEST_APPLICATION qa ON qa.ID=a.LOANID where qa.ID=@lID", con)
                    cmd.Parameters.AddWithValue("@lID", Trim(loanID))
                    Dim dt As New DataTable
                    Using adp As New SqlDataAdapter(cmd)
                        adp.Fill(dt)
                    End Using
                    If dt.Rows.Count > 0 Then
                        lblDisbDate.Text = isNullString(dt.Rows(0).Item("DisbursementDate"))
                        lblInterestAmount.Text = isNullString(dt.Rows(0).Item("InterestAmt"))
                        lblInterestRate.Text = isNullString(dt.Rows(0).Item("FIN_INT_RATE"))
                        lblCustNo.Text = isNullString(dt.Rows(0).Item("CustomerNumber"))
                        lblLoanAmount.Text = isNullString(dt.Rows(0).Item("LoanAmount"))
                        lblMaturityDate.Text = isNullString(dt.Rows(0).Item("MaturityDate"))
                    Else
                        lblDisbDate.Text = ""
                        lblInterestAmount.Text = ""
                        lblInterestRate.Text = ""
                        lblCustNo.Text = ""
                        lblLoanAmount.Text = ""
                        lblMaturityDate.Text = ""
                    End If
                End Using
            End Using
            loadPrevRepayments(loanID)
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- getLoanDetails()", ex.ToString)
        End Try
    End Sub

    Protected Sub loadPrevRepayments(lID As Double)
        Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
            Using cmd As New SqlCommand("Select convert(nvarchar,TrxnDate,106) as [Payment Date],FORMAT(TotalAmount,'c') as [Total Amount],FORMAT(Principal,'c') as [Capital Amount],FORMAT(Interest,'c') as [Interest],FORMAT([Admin],'c') as [Admin] from Repayments where [LoanID]='" & lID & "' order by TrxnDate asc", con)
                Dim ds As New DataSet
                Dim adp As New SqlDataAdapter(cmd)
                adp.Fill(ds, "FUN")
                If ds.Tables(0).Rows.Count > 0 Then
                    grdRepaymentHistory.DataSource = ds.Tables(0)
                Else
                    grdRepaymentHistory.DataSource = Nothing
                End If
                grdRepaymentHistory.DataBind()
            End Using
        End Using
    End Sub
    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            If Not IsNumeric(txtAmtPaid.Text.Replace("US", "").Replace("$", "").Replace(",", "")) Then
                notify("Enter numeric value for total amount", "error")
                txtAmtPaid.Text = "0"
                txtAmtPaid.Focus()
            ElseIf Not IsNumeric(txtCapital.Text.Replace("US", "").Replace("$", "").Replace(",", "")) Then
                notify("Enter numeric value for capital amount", "error")
                txtCapital.Text = "0"
                txtCapital.Focus()
            ElseIf Not IsNumeric(txtInterest.Text.Replace("US", "").Replace("$", "").Replace(",", "")) Then
                notify("Enter numeric value for interest", "error")
                txtInterest.Text = "0"
                txtInterest.Focus()
                'ElseIf Not IsNumeric(txtPenalty.Text.Replace("US", "").Replace("$", "").Replace(",", "")) Then
                '    notify("Enter numeric value for penalty amount", "error")
                '    txtPenalty.Text = "0"
                '    txtPenalty.Focus()
            ElseIf Val(txtAmtPaid.Text.Replace("US", "").Replace("$", "").Replace(",", "")) <> Val(txtCapital.Text.Replace("US", "").Replace("$", "").Replace(",", "")) + Val(txtInterest.Text.Replace("US", "").Replace("$", "").Replace(",", "")) Then
                notify("Total amount paid must be equal to Capital + Interest + Penalty", "error")
            Else
                'procedure to rollover facility
                Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                    Using cmd As New SqlCommand("SaveFacilityRollover", con)
                        cmd.CommandType = CommandType.StoredProcedure
                        cmd.Parameters.AddWithValue("@LoanId", ViewState("loanID"))
                        cmd.Parameters.AddWithValue("@RolloverAmt", txtAmtPaid.Text)
                        cmd.Parameters.AddWithValue("@CapitalAmt", txtCapital.Text)
                        cmd.Parameters.AddWithValue("@Tenure", txtTenure.Text)
                        cmd.Parameters.AddWithValue("@RolloverDate", txtRolloverDate.Text)
                        cmd.Parameters.AddWithValue("@InterestRate", txtIntRate.Text)
                        cmd.Parameters.AddWithValue("@InterestDue", txtInterest.Text)
                        cmd.Parameters.AddWithValue("@Comment", txtComment.Text)
                        cmd.Parameters.AddWithValue("@User", Session("UserId"))
                        cmd.Parameters.AddWithValue("@CustNo", lblCustNo.Text)
                        cmd.Parameters.Add("@newAppID", SqlDbType.BigInt).Direction = ParameterDirection.Output

                        If con.State = ConnectionState.Open Then
                            con.Close()
                        End If
                        con.Open()
                        If cmd.ExecuteNonQuery() Then
                            ViewState("newLoanID") = cmd.Parameters("@newAppID").Value.ToString()
                        End If
                        con.Close()
                    End Using
                End Using
                Response.Write("<script>alert('Loan rolled over. New loan ID is " & ViewState("newLoanID") & "') ; location.href='Rollover.aspx'</script>")
            End If
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- btnSave_Click()", ex.ToString)
        End Try
    End Sub
End Class