Imports System.Data
Imports System.Data.SqlClient
Imports CreditManager
Imports ErrorLogging
Imports BankString

Partial Class Credit_Repayment
    Inherits System.Web.UI.Page

    Protected Shared Function getLastRepaymentDate(loanId As String) As String
        Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
            'Using cmd As New SqlCommand("select isnull(rep.TrxnDate,act.DISBURSED_DATE) as TrxnDate from QUEST_APPLICATION act left join Repayments rep on rep.[LoanID]=act.ID where act.[ID]='" + loanId + "' order by TrxnDate desc", con)
            Using cmd As New SqlCommand("select convert(varchar,isnull(rep.TrxnDate,''),113) as TrxnDate from Repayments rep where rep.[LoanID]='" + loanId + "' order by TrxnDate desc", con)
                Dim ds As New DataSet
                Dim adp As New SqlDataAdapter(cmd)
                adp.Fill(ds, "FUN")
                If ds.Tables(0).Rows.Count > 0 Then
                    Return ds.Tables(0).Rows(0).Item("TrxnDate").ToString
                Else
                    Return ""
                End If
            End Using
        End Using
    End Function

    Protected Sub allocateRepayment(order1 As String, order2 As String, order3 As String, order4 As String, amtPaid As Double, expPrincipal As Double, expInterest As Double, expPenalty As Double, expFees As Double)
        Try
            Dim remBalance As Double = amtPaid
            If order1 = "Principal" Then
                If remBalance > expPrincipal Then
                    ViewState("PrincipalPaid") = expPrincipal
                    remBalance = remBalance - expPrincipal
                Else
                    ViewState("PrincipalPaid") = remBalance
                    remBalance = 0
                End If
            ElseIf order1 = "Interest" Then
                If remBalance > expInterest Then
                    ViewState("InterestPaid") = expInterest
                    remBalance = remBalance - expInterest
                Else
                    ViewState("InterestPaid") = remBalance
                    remBalance = 0
                End If
            ElseIf order1 = "Fees" Then
                If remBalance > expFees Then
                    ViewState("FeesPaid") = expFees
                    remBalance = remBalance - expFees
                Else
                    ViewState("FeesPaid") = remBalance
                    remBalance = 0
                End If
            ElseIf order1 = "Penalties" Then
                If remBalance > expPenalty Then
                    ViewState("PenaltiesPaid") = expPenalty
                    remBalance = remBalance - expPenalty
                Else
                    ViewState("PenaltiesPaid") = remBalance
                    remBalance = 0
                End If
            End If
            If order2 = "Principal" Then
                If remBalance > expPrincipal Then
                    ViewState("PrincipalPaid") = expPrincipal
                    remBalance = remBalance - expPrincipal
                Else
                    ViewState("PrincipalPaid") = remBalance
                    remBalance = 0
                End If
            ElseIf order2 = "Interest" Then
                If remBalance > expInterest Then
                    ViewState("InterestPaid") = expInterest
                    remBalance = remBalance - expInterest
                Else
                    ViewState("InterestPaid") = remBalance
                    remBalance = 0
                End If
            ElseIf order2 = "Fees" Then
                If remBalance > expFees Then
                    ViewState("FeesPaid") = expFees
                    remBalance = remBalance - expFees
                Else
                    ViewState("FeesPaid") = remBalance
                    remBalance = 0
                End If
            ElseIf order2 = "Penalties" Then
                If remBalance > expPenalty Then
                    ViewState("PenaltiesPaid") = expPenalty
                    remBalance = remBalance - expPenalty
                Else
                    ViewState("PenaltiesPaid") = remBalance
                    remBalance = 0
                End If
            End If
            If order3 = "Principal" Then
                If remBalance > expPrincipal Then
                    ViewState("PrincipalPaid") = expPrincipal
                    remBalance = remBalance - expPrincipal
                Else
                    ViewState("PrincipalPaid") = remBalance
                    remBalance = 0
                End If
            ElseIf order3 = "Interest" Then
                If remBalance > expInterest Then
                    ViewState("InterestPaid") = expInterest
                    remBalance = remBalance - expInterest
                Else
                    ViewState("InterestPaid") = remBalance
                    remBalance = 0
                End If
            ElseIf order3 = "Fees" Then
                If remBalance > expFees Then
                    ViewState("FeesPaid") = expFees
                    remBalance = remBalance - expFees
                Else
                    ViewState("FeesPaid") = remBalance
                    remBalance = 0
                End If
            ElseIf order3 = "Penalties" Then
                If remBalance > expPenalty Then
                    ViewState("PenaltiesPaid") = expPenalty
                    remBalance = remBalance - expPenalty
                Else
                    ViewState("PenaltiesPaid") = remBalance
                    remBalance = 0
                End If
            End If
            If order4 = "Principal" Then
                If remBalance > expPrincipal Then
                    ViewState("PrincipalPaid") = expPrincipal
                    remBalance = remBalance - expPrincipal
                Else
                    ViewState("PrincipalPaid") = remBalance
                    remBalance = 0
                End If
            ElseIf order4 = "Interest" Then
                If remBalance > expInterest Then
                    ViewState("InterestPaid") = expInterest
                    remBalance = remBalance - expInterest
                Else
                    ViewState("InterestPaid") = remBalance
                    remBalance = 0
                End If
            ElseIf order4 = "Fees" Then
                If remBalance > expFees Then
                    ViewState("FeesPaid") = expFees
                    remBalance = remBalance - expFees
                Else
                    ViewState("FeesPaid") = remBalance
                    remBalance = 0
                End If
            ElseIf order4 = "Penalties" Then
                If remBalance > expPenalty Then
                    ViewState("PenaltiesPaid") = expPenalty
                    remBalance = remBalance - expPenalty
                Else
                    ViewState("PenaltiesPaid") = remBalance
                    remBalance = 0
                End If
            End If
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- allocateRepayment()", ex.ToString)
        End Try
    End Sub

    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            If Trim(txtCustNo.Text) = "" Then
                notify("Enter the customer number", "error")
                txtCustNo.Focus()
            ElseIf Not IsNumeric(txtAmtPaid.Text.Replace("US", "").Replace("$", "").Replace(",", "").Replace("Z", "")) Then
                notify("Enter numeric value for total amount", "error")
                txtAmtPaid.Text = "0"
                txtAmtPaid.Focus()
            ElseIf Not IsNumeric(txtCapital.Text.Replace("US", "").Replace("$", "").Replace(",", "").Replace("Z", "")) Then
                notify("Enter numeric value for capital amount", "error")
                txtCapital.Text = "0"
                txtCapital.Focus()
            ElseIf Not IsNumeric(txtInterest.Text.Replace("US", "").Replace("$", "").Replace(",", "").Replace("Z", "")) Then
                notify("Enter numeric value for interest", "error")
                txtInterest.Text = "0"
                txtInterest.Focus()
            ElseIf Not IsNumeric(txtPenalty.Text.Replace("US", "").Replace("$", "").Replace(",", "").Replace("Z", "")) Then
                notify("Enter numeric value for penalty amount", "error")
                txtPenalty.Text = "0"
                txtPenalty.Focus()
            ElseIf CDbl(txtAmtPaid.Text.Replace("US", "").Replace("$", "").Replace(",", "").Replace("Z", "")) <> CDbl(txtCapital.Text.Replace("US", "").Replace("$", "").Replace(",", "").Replace("Z", "")) + CDbl(txtInterest.Text.Replace("US", "").Replace("$", "").Replace(",", "").Replace("Z", "")) + CDbl(txtPenalty.Text.Replace("US", "").Replace("$", "").Replace(",", "").Replace("Z", "")) Then
                notify("Total amount paid must be equal to Capital + Interest + Penalty", "error")
            ElseIf Not IsDate(txtRepaymentDate.Text) Then
                notify("Enter valid repayment date", "error")
                txtRepaymentDate.Focus()
            ElseIf CDbl(txtAmtPaid.Text) <= 0 Then
                notify("Amount paid must be greater than zero", "error")
                txtAmtPaid.Focus()
            ElseIf CDbl(txtCapital.Text) > 0 And cmbCapitalAccount.SelectedValue = "" Then
                notify("Select capital account", "error")
                cmbCapitalAccount.Focus()
                'ElseIf CDbl(txtInterest.Text) > 0 And cmbInterestAccount.SelectedValue = "" Then
                '    notify("Select interest account", "error")
                '    cmbInterestAccount.Focus()
                'ElseIf CDbl(txtPenalty.Text) > 0 And cmbPenaltyAccount.SelectedValue = "" Then
                '    notify("Select penalty account", "error")
                '    cmbPenaltyAccount.Focus()
            Else
                'txtCapital.Text = "0"
                'txtPenalty.Text = "0"
                'txtInterest.Text = "0"
                saveRepayment()
                '''''''''''''''''''''''''HARDCODED ACCOUNTS'''''''''''''''''''
                ''saveRepaymentTransaction(ViewState("globLoanID"), "Loan Repayment", "Loan Repayment", toMoney(txtAmtPaid.Text), 0, cmbCapitalAccount.SelectedValue, "", "1", "", "", "", "", txtRepaymentDate.Text)
                ''saveTransaction(ViewState("globLoanID"), "Loan Repayment", "Loan Repayment", toMoney( txtAmtPaid.Text), 0, cmbCapitalAccount.SelectedValue, txtCustNo.Text, "1", "", "", "", "", txtRepaymentDate.Text)
                'If txtCapital.Text.Replace("US", "").Replace("$", "").Replace(",", "").Replace("Z", "") > 0 Then
                '    ''notify("Capital saving", "information")
                '    saveTransaction(ViewState("globLoanID"), "Loan Repayment", "Capital Repayment", toMoney(txtCapital.Text), 0, cmbCapitalAccount.SelectedValue, txtCustNo.Text, "1", "", "", "", "", txtRepaymentDate.Text)
                '    ''saveTransaction(ViewState("globLoanID"), "Capital Repayment", txtCapital.Text.Replace("US", "").Replace("$", "").Replace(",", "").Replace("Z", ""), 0, "212/11", txtCustNo.Text, "1", "", "", "", "", txtRepaymentDate.Text)
                '    'saveRepaymentTransaction(ViewState("globLoanID"), "Loan Repayment", "Capital Repayment", 0, toMoney(txtCapital.Text), txtCustNo.Text, "", "1", "", "", "", "", txtRepaymentDate.Text)
                'End If
                If toMoney(txtPenalty.Text) > 0 Then
                    'notify("Penalty saving", "information")
                    saveTransaction(ViewState("globLoanID"), "Penalty Charge", "Penalty Charged", txtPenalty.Text.Replace("US", "").Replace("$", "").Replace(",", "").Replace("Z", ""), 0, txtCustNo.Text, "223/4", "1", "", "", "", "", txtRepaymentDate.Text, txtApplicantName.Text)
                    saveTransaction(ViewState("globLoanID"), "Penalty Charge", "Penalty Charged", 0, txtPenalty.Text.Replace("US", "").Replace("$", "").Replace(",", "").Replace("Z", ""), "223/4", txtCustNo.Text, "1", "", "", "", "", txtRepaymentDate.Text, "Penalty Charged")
                    'saveTransaction(ViewState("globLoanID"), "Penalty Repayment", txtPenalty.Text.Replace("US", "").Replace("$", "").Replace(",", "").Replace("Z", ""), 0, txtCustNo.Text, cmbPenaltyAccount.SelectedValue, "1", "", "", "", "", txtRepaymentDate.Text)
                    saveTransaction(ViewState("globLoanID"), "Loan Repayment", "Penalty Repayment", txtPenalty.Text.Replace("US", "").Replace("$", "").Replace(",", "").Replace("Z", ""), 0, "223/4", "421/2", "1", "", "", "", "", txtRepaymentDate.Text, cmbCapitalAccount.SelectedItem.Text)
                    saveTransaction(ViewState("globLoanID"), "Loan Repayment", "Penalty Repayment", 0, txtPenalty.Text.Replace("US", "").Replace("$", "").Replace(",", "").Replace("Z", ""), "421/2", "223/4", "1", "", "", "", "", txtRepaymentDate.Text, txtApplicantName.Text)
                End If

                saveTransaction(ViewState("globLoanID"), "Loan Repayment", "Loan Repayment", toMoney(txtAmtPaid.Text), 0, cmbCapitalAccount.SelectedValue, txtCustNo.Text, "1", "", "", "", "", txtRepaymentDate.Text, cmbCapitalAccount.SelectedItem.Text)
                saveTransaction(ViewState("globLoanID"), "Loan Repayment", "Loan Repayment", 0, toMoney(txtAmtPaid.Text), txtCustNo.Text, cmbCapitalAccount.SelectedValue, "1", "", "", "", "", txtRepaymentDate.Text, txtApplicantName.Text)
                saveTransaction(ViewState("globLoanID"), "Loan Repayment", "Interest Repayment", 0, toMoney(txtInterest.Text), "211/17", "223/2", "1", "", "", "", "", txtRepaymentDate.Text, "Unearned Interest")
                saveTransaction(ViewState("globLoanID"), "Loan Repayment", "Interest Repayment", toMoney(txtInterest.Text), 0, "223/2", "211/17", "1", "", "", "", "", txtRepaymentDate.Text, "Earned Interest")
                UpdateAllRepaidLoans()
                Dim drSMS = CreditManager.getInternalControls
                If drSMS("SMSClientRepayment") Then
                    Try
                        ViaNettSMS.messagesend("Loan Repayment", ViewState("Phone"), CreditManager.writeTXTMessage(drSMS("SMSClientRepaymentText").ToString, txtApplicantName.Text, drSMS("MFICompanyName").ToString, txtAmtPaid.Text))
                    Catch ex As Exception
                    End Try
                End If
                Response.Write("<script>alert('Repayment saved') ; location.href='Repayment.aspx'</script>")
            End If
        Catch ex As Exception
            ErrorLogging.WriteLogFile(Session("UserId"), Request.Url.ToString & " --- btnSave_Click()", ex.ToString)
        End Try
    End Sub

    Protected Sub btnSearchName_Click(sender As Object, e As EventArgs) Handles btnSearchName.Click
        'populate listbox
        Try
            'Using cmd As New SqlCommand("Select id,isnull([SURNAME],' ') + ' ' + isnull([FORENAMES],' ') + ' - ' + isnull([CUSTOMER_NUMBER],' ') + ' - ' + convert(varchar,isnull([CREATED_DATE],' '),106) + ' - ' + isnull(FORMAT([FIN_AMT],'c'),' ') as [Name] FROM [QUEST_APPLICATION] where (isnull([SURNAME],'') like '%" & txtApplicantName.Text & "%' or isnull(FORENAMES,'') like '%" & txtApplicantName.Text & "%') and [STATUS]='Disbursed'")
            Using cmd As New SqlCommand("Select id,isnull([SURNAME],' ') + ' ' + isnull([FORENAMES],' ') + ' - ' + isnull([CUSTOMER_NUMBER],' ') + ' - ' + convert(varchar,isnull([CREATED_DATE],' '),106) + ' - ' + isnull(FORMAT([FIN_AMT],'c'),' ') as [Name] FROM [QUEST_APPLICATION] where (isnull([SURNAME],'') like '%" & txtApplicantName.Text & "%' or isnull(FORENAMES,'') like '%" & txtApplicantName.Text & "%') and ([STATUS]='Disbursed' OR GroupLoanID IN (SELECT id from QUEST_APPLICATION where STATUS='DISBURSED'))")
                'msgbox(cmd.CommandText)
                cmd.CommandType = CommandType.Text
                Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                    cmd.Connection = con
                    Dim ds As New DataSet
                    Dim adp As New SqlDataAdapter(cmd)
                    adp.Fill(ds, "FUN")
                    If ds.Tables(0).Rows.Count > 0 Then
                        lstLoans.DataSource = ds.Tables(0)
                        lstLoans.DataTextField = "Name"
                        lstLoans.DataValueField = "id"
                        lstLoans.Visible = True
                    Else
                        lstLoans.DataSource = Nothing
                        lstLoans.Visible = False
                    End If
                    lstLoans.DataBind()
                    clearLoanDetails()
                    'cmbFSP.ClearSelection()
                    txtLoanID.Text = ""
                    ViewState("globLoanID") = "0"
                    txtCustNo.Text = ""
                    clearLoanDetails()
                    txtInterest.Text = ""
                    lblCurrentInterestBalance.Text = ""
                    lblCurrentLoanBalance.Text = ""
                    lblTotalCapitalRepayment.Text = ""
                    grdRepaymentHistory.DataSource = Nothing
                    grdRepaymentHistory.DataBind()
                End Using
            End Using
        Catch ex As Exception
            ErrorLogging.WriteLogFile(Session("UserId"), Request.Url.ToString & " --- btnSearchName_Click", ex.ToString)
        End Try
    End Sub

    Protected Sub btnSearchVCAID_Click(sender As Object, e As EventArgs) Handles btnSearchVCAID.Click
        Try
            displayLoanDetails(txtLoanID.Text)
        Catch ex As Exception
            ErrorLogging.WriteLogFile(Session("UserId"), Request.Url.ToString & " --- btnSearchVCAID_Click", ex.ToString)
        End Try
    End Sub

    Protected Function calculateInterestDue(disbDate As String, firstPayDate As String, lastPayDate As String, calcDate As String, principalBal As Decimal, interestRate As Decimal) As Decimal
        Try
            'msgbox("in")
            Dim noDays As Decimal = 0
            Dim monthDays As Decimal = 30 'default value
            Dim intDue As Decimal = 0
            If lastPayDate = "" Then
                'no payment made yet
                'if calculation date less than firstPayDate then expected interest is less
                'else it is greater
                If CDate(calcDate) <= CDate(firstPayDate) Then
                    'monthDays = DateDiff(DateInterval.Day, CDate(disbDate), CDate(firstPayDate))
                    noDays = DateDiff(DateInterval.Day, CDate(disbDate), CDate(calcDate))
                Else
                    'get 100% interest upto firstPayDate then calculate subsequent interest on 30-day month
                    intDue = principalBal * (interestRate / 100)
                    noDays = DateDiff(DateInterval.Day, CDate(firstPayDate), CDate(calcDate))
                End If
            Else
                'some repayment made before
                noDays = DateDiff(DateInterval.Day, CDate(lastPayDate), CDate(calcDate))
            End If
            Dim dayFrac = noDays / monthDays
            Dim intRate = interestRate / 100
            intDue = intDue + (dayFrac * principalBal * intRate)
            Return intDue
        Catch ex As Exception
            ErrorLogging.WriteLogFile(Session("UserId"), Request.Url.ToString & " --- calculateInterestDue()", ex.ToString)
        End Try
    End Function

    Protected Sub clearLoanDetails()
        loanDets.Visible = False
        lblDisbDate.Text = ""
        lblInterestAmount.Text = ""
        lblInterestUpfront.Text = ""
        lblLoanAmount.Text = ""
        lblTenure.Text = ""
        lblNetAmount.Text = ""
    End Sub

    Protected Sub displayLoanDetails(vca As String)
        Try
            If Trim(vca) = "" Then
                notify("Invalid loan ID", "error")
            Else
                Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                    'Using cmd As New SqlCommand("Select *,isnull(nullif(RECOMMENDED_AMT,0),[FIN_AMT]) as DisbAmt,convert(nvarchar,[DISBURSED_DATE],106) as DisburseDate1,convert(nvarchar,[FIN_REPAY_DATE],106) as FIN_REPAY_DATE1,convert(nvarchar,MaturityDate,106) as MaturityDate1 FROM [QUEST_APPLICATION] where id='" & vca & "' and [STATUS]='Disbursed'", con)
                    Using cmd As New SqlCommand("Select *,isnull(nullif(RECOMMENDED_AMT,0),[FIN_AMT]) as DisbAmt,convert(nvarchar,[DISBURSED_DATE],106) as DisburseDate1,convert(nvarchar,[FIN_REPAY_DATE],106) as FIN_REPAY_DATE1,convert(nvarchar,MaturityDate,106) as MaturityDate1 FROM [QUEST_APPLICATION] where id='" & vca & "' and ([STATUS]='Disbursed' OR GroupLoanID IN (SELECT id from QUEST_APPLICATION where STATUS='DISBURSED'))", con)
                        'fillAppForm(vca)
                        cmd.CommandType = CommandType.Text
                        Dim ds As New DataSet
                        Dim adp As New SqlDataAdapter(cmd)
                        adp.Fill(ds, "VCA")
                        clearLoanDetails()
                        If ds.Tables(0).Rows.Count > 0 Then
                            Dim dr As DataRow = ds.Tables(0).Rows(0)
                            txtApplicantName.Text = isNullString(dr.Item("SURNAME")) + " " + isNullString(dr.Item("FORENAMES"))
                            txtLoanID.Text = isNullString(dr.Item("ID"))
                            ViewState("globLoanID") = isNullString(dr.Item("ID"))
                            txtCustNo.Text = isNullString(dr.Item("CUSTOMER_NUMBER"))
                            ViewState("Phone") = BankString.isNullString(dr.Item("PHONE_NO"))
                            Try
                                getProductOptions(dr.Item("FinProductType"))
                            Catch ex As Exception

                            End Try
                            loanDets.Visible = True
                            Try
                                'lblLoanAmount.Text = FormatNumber(isNullString(dr.Item("FIN_AMT")), 2)
                                lblLoanAmount.Text = FormatNumber(isNullString(dr.Item("DisbAmt")), 2)
                                'lblLoanAmount.Text = FormatCurrency(200)
                            Catch ex As Exception

                            End Try
                            Try
                                lblDisbDate.Text = isNullString(dr.Item("DisburseDate1"))
                            Catch ex As Exception

                            End Try
                            Try
                                lblTenure.Text = FormatNumber(isNullString(dr.Item("FIN_TENOR")), 0)
                            Catch ex As Exception

                            End Try
                            Try
                                lblInterestRate.Text = FormatNumber(isNullString(dr.Item("FIN_INT_RATE")), 2)
                            Catch ex As Exception

                            End Try
                            Try
                                lblRepayDate.Text = isNullString(dr.Item("FIN_REPAY_DATE1"))
                            Catch ex As Exception

                            End Try
                            Try
                                lblInterestAmount.Text = FormatNumber(getInterestToMaturity(txtCustNo.Text, ViewState("globLoanID")), 2) ' FormatCurrency(isNullString(dr.Item("IntAmt")))
                            Catch ex As Exception

                            End Try

                            lblInterestUpfront.Text = 0 ' FormatCurrency(isNullString(dr.Item("InterestUpfront")))
                            lblNetAmount.Text = lblLoanAmount.Text ' FormatCurrency(isNullString(dr.Item("NetAmount")))
                            Try
                                lblLastRepayDate.Text = getLastRepaymentDate(vca)
                            Catch ex As Exception

                            End Try

                            ' txtInterest.Text = lblInterestAmount.Text - lblInterestUpfront.Text
                            Try
                                loadPrevRepayments(vca)
                            Catch ex As Exception

                            End Try
                            Try
                                loadAmortization(vca)
                            Catch ex As Exception

                            End Try
                            Try
                                getCurrentBalances(vca, txtRepaymentDate.Text)
                            Catch ex As Exception

                            End Try
                            Try
                                getCurrentLoanBalance()
                            Catch ex As Exception

                            End Try

                            'txtInterest.Text = FormatCurrency(calculateInterestDue(lblDisbDate.Text, lblRepayDate.Text, lblLastRepayDate.Text, txtRepaymentDate.Text, lblCurrentLoanBalance.Text.Replace("US", "").Replace("$", ""), lblInterestRate.Text))
                        Else
                            'cmbFSP.ClearSelection()
                            txtLoanID.Text = ""
                            ViewState("globLoanID") = "0"
                            txtCustNo.Text = ""
                            txtApplicantName.Text = ""
                            clearLoanDetails()
                            txtInterest.Text = ""
                            'loadPrevRepayments(vca)
                            grdRepaymentHistory.DataSource = Nothing
                            grdRepaymentHistory.DataBind()
                            lblCurrentInterestBalance.Text = ""
                            lblCurrentLoanBalance.Text = ""
                            lblTotalCapitalRepayment.Text = ""
                            'txtPastelInterest.Text = ""
                            notify("Loan not found or already repaid", "error")
                        End If
                    End Using
                End Using
            End If
        Catch ex As Exception
            ErrorLogging.WriteLogFile(Session("UserId"), Request.Url.ToString & " --- displayLoanDetails()", ex.ToString)
        End Try
    End Sub

    Protected Sub getCurrentBalances(vca As Double, dat As String)
        Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
            'Using cmd As New SqlCommand("select top 1 * from AMORTIZATION_SCHEDULE_DAILY where loanid='" & vca & "' and DAY_DATE<='" & dat & "' order by DAY_DATE desc", con)
            Using cmd As New SqlCommand("select top 1 * from AMORTIZATION_SCHEDULE where loanid='" & vca & "' and dateadd(DAY,14,PAYMENT_DATE)<='" & dat & "' order by PAYMENT_DATE desc", con)
                Dim ds As New DataSet
                Dim adp As New SqlDataAdapter(cmd)
                adp.Fill(ds, "FUN")
                If ds.Tables(0).Rows.Count > 0 Then
                    Dim dr = ds.Tables(0).Rows(0)
                    Try
                        'lblCapitalRepaymentDue.Text = FormatCurrency(dr.Item("CUMULATIVE_PRINCIPAL"))
                        lblCapitalRepaymentDue.Text = FormatNumber(dr.Item("CUMULATIVE_PRINCIPAL"), 2)
                    Catch ex As Exception
                        lblCapitalRepaymentDue.Text = ""
                    End Try
                    Try
                        'lblInterestRepaymentDue.Text = FormatCurrency(dr.Item("CUMULATIVE_INTEREST"))
                        lblInterestRepaymentDue.Text = FormatNumber(dr.Item("CUMULATIVE_INTEREST"), 2)
                    Catch ex As Exception
                        lblInterestRepaymentDue.Text = ""
                    End Try
                    lblPenaltyChargesAccrued.Text = "0"
                    lblEarlyRepaymentDeduction.Text = ""
                    lblTotalRepaymentDue.Text = ""
                Else
                    lblCapitalRepaymentDue.Text = 0
                    lblInterestRepaymentDue.Text = 0
                    lblPenaltyChargesAccrued.Text = 0
                    lblEarlyRepaymentDeduction.Text = 0
                    lblTotalRepaymentDue.Text = 0
                End If
            End Using
        End Using
    End Sub

    Protected Sub getCurrentLoanBalance()
        Try
            lblCurrentLoanBalance.Text = ""
            lblTotalCapitalRepayment.Text = ""
            Dim TotCapRepay = 0.00
            Dim TotIntRepay = 0.00
            Dim TotRepay = 0.00
            For Each row As GridViewRow In grdRepaymentHistory.Rows
                TotRepay = TotRepay + CDbl(row.Cells(1).Text.Replace("$", "").Replace(",", ""))
                TotCapRepay = TotCapRepay + CDbl(row.Cells(2).Text.Replace("$", "").Replace(",", ""))
                TotIntRepay = TotIntRepay + CDbl(row.Cells(3).Text.Replace("$", "").Replace(",", ""))
            Next
            lblTotalCapitalRepayment.Text = FormatNumber(TotCapRepay, 2)
            lblCurrentLoanBalance.Text = FormatNumber(toMoney(lblLoanAmount.Text) + toMoney(lblInterestAmount.Text) - toMoney(TotRepay), 2)
            'lblCurrentLoanBalance.Text = FormatNumber(toMoney(lblLoanAmount.Text) - toMoney(TotRepay), 2)

            lblCurrentInterestBalance.Text = FormatNumber(toMoney(lblInterestAmount.Text) - toMoney(lblInterestUpfront.Text) - toMoney(TotIntRepay), 2)

            Dim capRepDue As Double = 0.00
            Try
                capRepDue = CDbl(toMoney(lblCapitalRepaymentDue.Text))
            Catch ex As Exception

            End Try
            Try
                capRepDue = CDbl(toMoney(lblCapitalRepaymentDue.Text)) - TotCapRepay
            Catch ex As Exception

            End Try
            Try
                If capRepDue <= 0 Then
                    capRepDue = CDbl(toMoney(lblLoanAmount.Text)) - TotCapRepay
                End If
            Catch ex As Exception

            End Try

            Dim intRepDue As Double = 0.00
            Try
                intRepDue = CDbl(toMoney(lblInterestRepaymentDue.Text))
            Catch ex As Exception

            End Try
            Try
                intRepDue = CDbl(toMoney(lblInterestRepaymentDue.Text)) - TotIntRepay
            Catch ex As Exception

            End Try
            Try
                If intRepDue <= 0 Then
                    intRepDue = CDbl(toMoney(lblInterestAmount.Text)) - TotIntRepay
                End If
            Catch ex As Exception

            End Try

            Try
                lblCapitalRepaymentDue.Text = capRepDue
            Catch ex As Exception

            End Try
            Try
                lblInterestRepaymentDue.Text = intRepDue
            Catch ex As Exception

            End Try

            Try
                lblInterestRepaymentDue.Text = FormatNumber(IIf(toMoney(lblInterestRepaymentDue.Text) - TotIntRepay < 0, 0, CDbl(toMoney(lblInterestRepaymentDue.Text) - TotIntRepay)), 2)
                ViewState("Interest") = toMoney(lblInterestRepaymentDue.Text)
            Catch ex As Exception
            End Try
            'If lblCurrentInterestBalance.Text > lblInterestRepaymentDue.Text Then
            '    lblInterestRepaymentDue.Text =
            'End If
            Try
                lblTotalRepaymentDue.Text = toMoney(lblCapitalRepaymentDue.Text) + toMoney(lblInterestRepaymentDue.Text) + toMoney(lblPenaltyChargesAccrued.Text)
            Catch ex As Exception
                WriteLogFile(ex.ToString)
            End Try
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- getCurrentLoanBalance()", ex.ToString)
        End Try
    End Sub

    Protected Function getInterestToMaturity(custNo As String, loanID As String) As String
        Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
            'Using cmd As New SqlCommand("select sum(debit) as Interest from Accounts_Transactions act where Description='Interest to Maturity' and Account='" + custNo + "' and Refrence='" + loanID + "'", con)
            Using cmd As New SqlCommand("SELECT MAX(CUMULATIVE_INTEREST) as Interest FROM AMORTIZATION_SCHEDULE WHERE LOANID='" + loanID + "'", con)
                Dim ds As New DataSet
                Dim adp As New SqlDataAdapter(cmd)
                adp.Fill(ds, "FUN")
                If ds.Tables(0).Rows.Count > 0 Then
                    Return ds.Tables(0).Rows(0).Item("Interest").ToString
                Else
                    Return "0"
                End If
            End Using
        End Using
    End Function

    Protected Sub getProductOptions(prodID As String)
        Try
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd = New SqlCommand("SELECT * FROM creditproducts where id='" & prodID & "'", con)
                    Dim dt As New DataTable
                    Using adp As New SqlDataAdapter(cmd)
                        adp.Fill(dt)
                    End Using
                    If dt.Rows.Count > 0 Then
                        Dim dr = dt.Rows(0)
                        ViewState("RepayOrder1") = dr("RepayOrder1")
                        ViewState("RepayOrder2") = dr("RepayOrder2")
                        ViewState("RepayOrder3") = dr("RepayOrder3")
                        ViewState("RepayOrder4") = dr("RepayOrder4")
                    End If
                End Using
            End Using
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- getProductOptions()", ex.ToString)
        End Try
    End Sub

    Protected Sub loadAccounts()
        Try
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                'Using cmd = New SqlCommand("select convert(varchar,MainAccount)  + '/' + convert(varchar,SubAccount) as AccountNo, AccountName  + '  ' + convert(varchar,MainAccount)  + '/' + convert(varchar,SubAccount) as AccountName from tbl_FinancialAccountsCreation where (MainAccount='212' or MainAccount='211') and SubAccount<>1", con)
                'Using cmd = New SqlCommand("select convert(varchar,MainAccount)  + '/' + convert(varchar,SubAccount) as AccountNo, AccountName as AccountName from tbl_FinancialAccountsCreation where (MainAccount='211') and SubAccount<>'1' and SubAccount<>'18' and SubAccount<>'17'", con)
                Using cmd = New SqlCommand("select * from CashbookAccounts", con)
                    'End if
                    Dim ds As New DataSet
                    Using adp = New SqlDataAdapter(cmd)
                        adp.Fill(ds, "LRS2")
                    End Using
                    cmbCapitalAccount.Visible = True
                    loadCombo(ds.Tables(0), cmbCapitalAccount, "AccountName", "AccountNo")
                End Using
            End Using
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- loadAccounts()", ex.ToString)
        End Try
    End Sub

    Protected Sub loadAmortization(vca As Double)
        Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
            Using cmd As New SqlCommand("Select [PAYMENT_NO] as [No.],convert(nvarchar,[PAYMENT_DATE],106) as [Date],FORMAT([PRINCIPAL],'c') as [Principal],FORMAT([INTEREST],'c') as [Interest],FORMAT([ADMIN_CHARGE],'c') as [Admin],FORMAT([PAYMENT],'c') as [Total] from [AMORTIZATION_SCHEDULE] where LoanId='" & vca & "' order by [PAYMENT_NO] asc", con)
                Dim ds As New DataSet
                Dim adp As New SqlDataAdapter(cmd)
                adp.Fill(ds, "FUN")
                If ds.Tables(0).Rows.Count > 0 Then
                    grdAmortization.DataSource = ds.Tables(0)
                    ViewState("Interest") = ds.Tables(0).Rows(0).Item("Interest")
                    ViewState("Principal") = ds.Tables(0).Rows(0).Item("Principal")
                    ViewState("Fees") = ds.Tables(0).Rows(0).Item("Admin")
                    ViewState("Penalty") = 0
                Else
                    grdAmortization.DataSource = Nothing
                End If
                grdAmortization.DataBind()
            End Using
        End Using
    End Sub

    Protected Sub loadInterestAccounts()
        Try
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd = New SqlCommand("select convert(varchar,MainAccount)  + '/' + convert(varchar,SubAccount) as AccountNo, AccountName  + '  ' + convert(varchar,MainAccount)  + '/' + convert(varchar,SubAccount) as AccountName from tbl_FinancialAccountsCreation where MainAccount='217' and SubAccount<>1", con)
                    Dim ds As New DataSet
                    Using adp = New SqlDataAdapter(cmd)
                        adp.Fill(ds, "LRS2")
                    End Using
                    cmbInterestAccount.Visible = True
                    loadCombo(ds.Tables(0), cmbInterestAccount, "AccountName", "AccountNo")
                End Using
            End Using
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- loadInterestAccounts()", ex.ToString)
        End Try
    End Sub

    Protected Sub loadPrevRepayments(vca As Double)
        Try
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd As New SqlCommand("Select convert(nvarchar,[TrxnDate],106) as [Payment Date],FORMAT([TotalAmount],'c') as [Total Amount],FORMAT([Principal],'c') as [Principal Amount],FORMAT([Interest],'c') as [Interest],FORMAT([Charges],'c') as [Penalty] from Repayments where LoanId='" & vca & "' order by [TrxnDate] asc", con)
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
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- loadPrevRepayments()", ex.ToString)
        End Try
    End Sub

    Protected Sub lstLoans_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstLoans.SelectedIndexChanged
        Try
            txtLoanID.Text = lstLoans.SelectedValue
            btnSearchVCAID_Click(sender, New EventArgs)
        Catch ex As Exception
            ErrorLogging.WriteLogFile(Session("UserId"), Request.Url.ToString & " --- lstLoans_SelectedIndexChanged", ex.ToString)
        End Try
    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Page.MaintainScrollPositionOnPostBack = True
        If Not IsPostBack Then
            txtRepaymentDate.Text = Date.Now.ToString("dd MMM yyyy")
            loadAccounts()
            loadInterestAccounts()
            loadPenaltyAccounts()
            If Request.QueryString("id") <> "" Then
                Dim EncQuery As New BankEncryption64
                ViewState("globLoanID") = EncQuery.Decrypt(Request.QueryString("id"), "taDz392018hbdER")
                ''fillAppForm(ViewState("globLoanID"))
                'cmbCapitalAccount.SelectedValue = ""
                'cmbInterestAccount.SelectedValue = ""
            Else
                ViewState("globLoanID") = 0
            End If
        End If
    End Sub
    Protected Sub loadPenaltyAccounts()
        Try
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd = New SqlCommand("select convert(varchar,MainAccount)  + '/' + convert(varchar,SubAccount) as AccountNo, AccountName  + '  ' + convert(varchar,MainAccount)  + '/' + convert(varchar,SubAccount) as AccountName from tbl_FinancialAccountsCreation where MainAccount='218' and SubAccount<>1", con)
                    Dim ds As New DataSet
                    Using adp = New SqlDataAdapter(cmd)
                        adp.Fill(ds, "LRS2")
                    End Using
                    cmbPenaltyAccount.Visible = True
                    loadCombo(ds.Tables(0), cmbPenaltyAccount, "AccountName", "AccountNo")
                End Using
            End Using
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- loadPenaltyAccounts()", ex.ToString)
        End Try
    End Sub

    Protected Sub saveRepayment()
        Try
            If txtAmtPaid.Text = "" Or Not IsNumeric(toMoney(txtAmtPaid.Text)) Then
                notify("Enter valid total amount paid", "error")
                txtAmtPaid.Focus()
                Exit Sub
                'ElseIf cmbCapitalAccount.SelectedValue = "" Then
                '    notify("Select the capital account", "error")
                '    cmbCapitalAccount.Focus()
                '    Exit Sub
                '    'ElseIf cmbInterestAccount.SelectedValue = "" Then
                '    '    notify("Select the interest account", "error")
                '    '    cmbInterestAccount.Focus()
                '    '    Exit Sub
            End If
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd As New SqlCommand("SaveRepayment", con)
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.AddWithValue("@loanID", txtLoanID.Text)
                    cmd.Parameters.AddWithValue("@CustNo", txtCustNo.Text)
                    cmd.Parameters.AddWithValue("@TrxnDate", txtRepaymentDate.Text)
                    cmd.Parameters.AddWithValue("@Interest", toMoney(txtInterest.Text))
                    cmd.Parameters.AddWithValue("@Principal", toMoney(txtCapital.Text))
                    cmd.Parameters.AddWithValue("@Penalty", toMoney(txtPenalty.Text))
                    cmd.Parameters.AddWithValue("@TotalAmount", toMoney(txtAmtPaid.Text))
                    cmd.Parameters.AddWithValue("@RolloverBalance", 0)
                    cmd.Parameters.AddWithValue("@InterestNextPmt", 0)
                    cmd.Parameters.AddWithValue("@NextPmtTotal", 0)
                    cmd.Parameters.AddWithValue("@CapturedBy", Session("UserId"))
                    cmd.Parameters.AddWithValue("@ReceiptNo", txtReceiptNumber.Text)
                    If con.State = ConnectionState.Open Then
                        con.Close()
                    End If
                    con.Open()
                    If cmd.ExecuteNonQuery() Then
                    Else
                        notify("Error saving repayment", "error")
                    End If
                    con.Close()
                End Using
            End Using
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- saveRepayment()", ex.ToString)
        End Try
    End Sub

    Protected Sub saveTransaction(reference As String, category As String, description As String, debit As Double, credit As Double, account As String, contra As String, status As String, other As String, bankAccId As String, bankAccName As String, batchRef As String, trxnDate As Date, accName As String)
        Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
            'Using cmd As New SqlCommand("SaveAccountsTrxnsTempWithContra", con)
            ' Using cmd = New SqlCommand("SaveAccountsTrxnsWithContra", con)
            Using cmd = New SqlCommand("SaveAccountsTrxns", con)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("@Type", "System Entry")
                'cmd.Parameters.AddWithValue("@Category", "Loan Repayment")
                cmd.Parameters.AddWithValue("@Category", category)
                cmd.Parameters.AddWithValue("@Ref", reference)
                cmd.Parameters.AddWithValue("@Desc", description)
                cmd.Parameters.AddWithValue("@Debit", debit)
                cmd.Parameters.AddWithValue("@Credit", credit)
                cmd.Parameters.AddWithValue("@Account", account)
                cmd.Parameters.AddWithValue("@ContraAccount", contra)
                cmd.Parameters.AddWithValue("@Status", status)
                cmd.Parameters.AddWithValue("@Other", other)
                cmd.Parameters.AddWithValue("@BankAccID", bankAccId)
                'cmd.Parameters.AddWithValue("@BankAccName", bankAccName)
                cmd.Parameters.AddWithValue("@BankAccName", txtReceiptNumber.Text) 'receipt number for transaction
                cmd.Parameters.AddWithValue("@BatchRef", batchRef)
                cmd.Parameters.AddWithValue("@TrxnDate", trxnDate)
                cmd.Parameters.AddWithValue("@CaptureBy", Session("UserId"))
                cmd.Parameters.AddWithValue("@DebtorAccNo", txtCustNo.Text)
                cmd.Parameters.AddWithValue("@AccountName", accName)

                If con.State = ConnectionState.Open Then
                    con.Close()
                End If
                con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            End Using
        End Using
    End Sub

    Protected Sub saveRepaymentTransaction(reference As String, category As String, description As String, debit As Double, credit As Double, account As String, contra As String, status As String, other As String, bankAccId As String, bankAccName As String, batchRef As String, trxnDate As Date)
        Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
            'Using cmd As New SqlCommand("SaveAccountsTrxnsTempWithContra", con)
            Using cmd = New SqlCommand("SaveAccountsTrxns", con)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("@Type", "System Entry")
                'cmd.Parameters.AddWithValue("@Category", "Loan Repayment")
                cmd.Parameters.AddWithValue("@Category", category)
                cmd.Parameters.AddWithValue("@Ref", reference)
                cmd.Parameters.AddWithValue("@Desc", description)
                cmd.Parameters.AddWithValue("@Debit", debit)
                cmd.Parameters.AddWithValue("@Credit", credit)
                cmd.Parameters.AddWithValue("@Account", account)
                cmd.Parameters.AddWithValue("@ContraAccount", contra)
                cmd.Parameters.AddWithValue("@Status", status)
                cmd.Parameters.AddWithValue("@Other", other)
                cmd.Parameters.AddWithValue("@BankAccID", bankAccId)
                'cmd.Parameters.AddWithValue("@BankAccName", bankAccName)
                cmd.Parameters.AddWithValue("@BankAccName", txtReceiptNumber.Text) 'receipt number for transaction
                cmd.Parameters.AddWithValue("@BatchRef", batchRef)
                cmd.Parameters.AddWithValue("@TrxnDate", trxnDate)
                cmd.Parameters.AddWithValue("@CaptureBy", Session("UserId"))
                cmd.Parameters.AddWithValue("@DebtorAccNo", txtCustNo.Text)

                If con.State = ConnectionState.Open Then
                    con.Close()
                End If
                con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            End Using
        End Using
    End Sub

    Protected Function toMoney(inp As String) As Double
        Return inp.Replace("US", "").Replace("$", "").Replace(",", "").Replace("Z", "")
    End Function

    Protected Sub txtAmtPaid_TextChanged(sender As Object, e As EventArgs) Handles txtAmtPaid.TextChanged
        Try
            If IsNumeric(txtAmtPaid.Text) Then
                Dim remBalance As Double = CDbl(toMoney(txtAmtPaid.Text))
                allocateRepayment(ViewState("RepayOrder1"), ViewState("RepayOrder2"), ViewState("RepayOrder3"), ViewState("RepayOrder4"), remBalance, toMoney(ViewState("Principal")), toMoney(ViewState("Interest")), toMoney(ViewState("Penalty")), toMoney(ViewState("Fees")))

                txtCapital.Text = ViewState("PrincipalPaid")
                txtInterest.Text = ViewState("InterestPaid")
                txtPenalty.Text = ViewState("PenaltiesPaid")
                'fees amount
                'If ViewState("RepayOrder1") = "Principal" Then

                'End If
                'If CDbl(txtAmtPaid.Text) > CDbl(toMoney(ViewState("Principal"))) Then
                '    txtCapital.Text = ViewState("Principal")
                '    remBalance = remBalance - toMoney(txtCapital.Text)
                'Else
                '    txtCapital.Text = txtAmtPaid.Text
                '    remBalance = remBalance - toMoney(txtCapital.Text)
                'End If
                'If remBalance > 0 And remBalance > CDbl(toMoney(ViewState("Interest"))) Then
                '    txtInterest.Text = ViewState("Interest")
                '    remBalance = remBalance - toMoney(txtInterest.Text)
                'Else
                '    txtInterest.Text = remBalance
                '    remBalance = remBalance - toMoney(txtInterest.Text)
                'End If
                ''If remBalance > 0 And remBalance > CDbl(toMoney(ViewState("Admin"))) Then
                ''txtAdmin.Text = ViewState("Admin")
                ''remBalance = remBalance - toMoney(txtAdmin.Text)
                ''Else
                ''txtAdmin.Text = remBalance
                ''remBalance = remBalance - toMoney(txtAdmin.Text)
                ''End If
                'If remBalance > 0 Then
                '    txtCapital.Text = toMoney(txtCapital.Text) + remBalance
                'End If
                'txtPenalty.Text = 0
            End If
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- txtAmtPaid_TextChanged()", ex.ToString)
        End Try
    End Sub

    Protected Sub UpdateAllRepaidLoans()
        Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
            Using cmd As New SqlCommand("update QUEST_APPLICATION set status='REPAID' where convert(varchar,id) in (select refrence from Accounts_Transactions acct where account in (select customer_number from CUSTOMER_DETAILS) group by Refrence having sum(debit-credit)<=0)", con)
                con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            End Using
        End Using
    End Sub
End Class