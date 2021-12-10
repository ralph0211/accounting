Imports System.Data.SqlClient
Imports System.Data
Imports CreditManager
Imports ErrorLogging

Partial Class Credit_LoanDisbursement
    Inherits System.Web.UI.Page
    Dim cmd2 As SqlCommand
    Public Sub loadAssets()
        Try
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd As New SqlCommand("Select * from Quest_Assets", con)
                    Using adp As New SqlDataAdapter(cmd)
                        Dim ds As New DataSet
                        adp.Fill(ds, "Assets")
                        loadCombo(ds.Tables(0), ddlAssets, "Name", "Selling_Price")
                    End Using
                End Using
            End Using
        Catch ex As Exception
            msgbox(ex.ToString)
        End Try
    End Sub

    Protected Sub btnDisburse_Click(sender As Object, e As EventArgs) Handles btnDisburse.Click
        Try
            If isAlredyDisbursed(ViewState("loanID")) Then
                notify("Loan already disbursed", "error")
            Else
                If Trim(txtDisburseDate.Text) = "" Or Not IsDate(txtDisburseDate.Text) Then
                    notify("Please enter disbursement date", "error")
                    txtDisburseDate.Focus()
                ElseIf Trim(txtFirstPayDate.Text) = "" Or Not IsDate(txtFirstPayDate.Text) Then
                    notify("Please enter the first payment date", "error")
                    txtFirstPayDate.Focus()
                ElseIf cmbDisbursementAccount.SelectedItem.Text = "Select Account" Or Trim(cmbDisbursementAccount.SelectedValue) = "" Then
                    notify("Please select the account to disburse from", "error")
                    cmbDisbursementAccount.Focus()
                    'ElseIf cmbInterestAccount.SelectedItem.Text = "Select Account" Or Trim(cmbInterestAccount.SelectedValue) = "" Then
                    '    notify("Please select the interest account", "error")
                    '    cmbInterestAccount.Focus()
                ElseIf txtAmtToDisburse.Text = "" Or Not IsNumeric(txtAmtToDisburse.Text) Then
                    notify("Please enter the amount to disburse", "error")
                    txtAmtToDisburse.Focus()
                ElseIf txtUpfrontFees.Text = "" Or Not IsNumeric(txtUpfrontFees.Text) Then
                    notify("Please enter the upfront fees amount", "error")
                    txtUpfrontFees.Focus()
                ElseIf CDate(txtDisburseDate.Text) > CDate(txtFirstPayDate.Text) Then
                    notify("The first repayment date must be later than the disbursement date", "error")
                    txtFirstPayDate.Focus()
                Else
                    If Convert.ToDouble(txtAmtToDisburse.Text) > Convert.ToDouble(txtRecAmt.Text) Then
                        notify("Amount to disburse cannot be greater than amount approved", "error")
                    ElseIf CDbl(txtAmtToDisburse.Text) + CDbl(txtUpfrontFees.Text) > CDbl(txtRecAmt.Text) Then
                        notify("Amount to disburse and upfront fees cannot be greater than amount approved", "error")
                    Else
                        '''''''''''''''''''''''first save amt to disburse********************
                        '''''''''''''''''''''''RUN IN STORED PROCEDURE************************
                        Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                            Using cmd As New SqlCommand("sp_disburse", con)
                                cmd.CommandType = CommandType.StoredProcedure
                                cmd.Parameters.AddWithValue("@loanID", ViewState("loanID"))
                                ' cmd.Parameters.AddWithValue("@amtToDisburse", txtAmtToDisburse.Text.Replace(",", ""))
                                cmd.Parameters.AddWithValue("@amtToDisburse", toMoney(txtRecAmt.Text))
                                cmd.Parameters.AddWithValue("@disburseDate", txtDisburseDate.Text)
                                cmd.Parameters.AddWithValue("@disburseOption", rdbFinReqDisburseOption.SelectedValue)
                                cmd.Parameters.AddWithValue("@userID", Session("ID"))
                                cmd.Parameters.AddWithValue("@voucherNo", txtVoucherNo.Text)
                                cmd.Parameters.AddWithValue("@fpDate", txtFirstPayDate.Text)
                                'msgbox(Request.QueryString("id") + ";" + txtAmtToDisburse.Text + ";" + txtDisburseDate.Text)
                                If con.State = ConnectionState.Open Then
                                    con.Close()
                                End If
                                con.Open()
                                If cmd.ExecuteNonQuery() Then
                                    saveDisbursement()
                                    saveComment()
                                    'recordDisbursalTrans(txtCustNo.Text, ViewState("loanID"), txtAmtToDisburse.Text)
                                    recordDisbursalTrans(txtCustNo.Text, ViewState("loanID"), toMoney(txtRecAmt.Text))
                                    createAmortizationOptions(ViewState("loanID"))

                                    If rdbClientType.SelectedItem.Text = "Group" Then
                                        For Each row As GridViewRow In grdIndivFinReq.Rows
                                            If row.RowType = DataControlRowType.DataRow Then
                                                Dim loanID As String = row.Cells(0).Text
                                                Dim cstNo As String = row.Cells(1).Text
                                                Dim indivName As String = row.Cells(2).Text
                                                Dim amt = row.Cells(4).Text
                                                saveTransaction(loanID, "Disbursement", toMoney(amt), 0, cstNo, cmbDisbursementAccount.SelectedValue, 1, cstNo, "", "", "", txtDisburseDate.Text, txtName.Text, cstNo, ViewState("loanID"))
                                                saveTransaction(loanID, "Disbursement", 0, toMoney(amt), cmbDisbursementAccount.SelectedValue, cstNo, 1, cstNo, "", "", "", txtDisburseDate.Text, cmbDisbursementAccount.SelectedItem.Text, cstNo, ViewState("loanID"))
                                                If rdbInterestTrigger.SelectedValue = "Disbursement" Then
                                                    ''save interest to maturity
                                                    ''new function to insert interest to maturity on disbursement
                                                    insertInterestAccountsTempGroup(loanID, txtCustNo.Text, cstNo, ViewState("loanID"), indivName)
                                                End If
                                                If IsNumeric(toMoney(txtUpfrontFees.Text)) And CDbl(toMoney(txtUpfrontFees.Text)) > 0 Then
                                                    insertUpfrontTemp(ViewState("loanID"))
                                                End If
                                            End If
                                        Next
                                    Else
                                        'principal amount disbursed
                                        'saveTransaction(ViewState("loanID"), "Disbursement", toMoney(txtAmtToDisburse.Text), 0, txtCustNo.Text, cmbDisbursementAccount.SelectedValue, 1, txtCustNo.Text, "", "", "", txtDisburseDate.Text)
                                        saveTransaction(ViewState("loanID"), "Disbursement", toMoney(txtRecAmt.Text), 0, txtCustNo.Text, cmbDisbursementAccount.SelectedValue, 1, txtCustNo.Text, "", "", "", txtDisburseDate.Text, txtName.Text)
                                        saveTransaction(ViewState("loanID"), "Disbursement", 0, toMoney(txtRecAmt.Text), cmbDisbursementAccount.SelectedValue, txtCustNo.Text, 1, txtCustNo.Text, "", "", "", txtDisburseDate.Text, cmbDisbursementAccount.SelectedItem.Text)
                                        If rdbInterestTrigger.SelectedValue = "Disbursement" Then
                                            'save interest to maturity
                                            'new function to insert interest to maturity on disbursement
                                            insertInterestAccountsTemp(ViewState("loanID"))
                                        End If
                                        If IsNumeric(toMoney(txtUpfrontFees.Text)) And CDbl(toMoney(txtUpfrontFees.Text)) > 0 Then
                                            insertUpfrontTemp(ViewState("loanID"))
                                        End If
                                    End If
                                    Dim drSMS = CreditManager.getInternalControls
                                    If drSMS("SMSClientDisbursement") Then
                                        Try
                                            'ViaNettSMS.sendTXT(ViewState("Phone"), CreditManager.writeTXTMessage(drSMS("SMSClientDisbursementText").ToString, txtName.Text, drSMS("MFICompanyName").ToString, txtRecAmt.Text))
                                            ViaNettSMS.messagesend("Loan Disbursement", ViewState("Phone"), CreditManager.writeTXTMessage(drSMS("SMSClientDisbursementText").ToString, txtName.Text, drSMS("MFICompanyName").ToString, txtRecAmt.Text))
                                        Catch ex As Exception
                                        End Try
                                    End If
                                    Response.Write("<script>alert('Loan successfully disbursed') ; location.href='LoanDisbursement.aspx'</script>")
                                End If
                                con.Close()
                            End Using
                        End Using
                    End If
                End If

            End If
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- btnDisburse_Click()", ex.ToString)
        End Try
    End Sub
    Protected Sub btnSaveCreditParameters_Click(sender As Object, e As EventArgs) Handles btnSaveCreditParameters.Click
        If Not IsDate(txt1stPayDate.Text) Then
            notify("Enter valid first payment Date", "error")
            txt1stPayDate.Focus()
        Else
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                'Using cmd = New SqlCommand("update QUEST_APPLICATION set [FIN_REPAY_OPT]='" & rdbRepayOption.SelectedValue & "',[FIN_TENOR]='" & txtRepayPeriod.Text & "',[FIN_INT_RATE]='" & txtIntRate.Text & "',[FIN_ADMIN]='" & txtAdminCharge.Text & "',[FIN_REPAY_DATE]='" & txt1stPayDate.Text & "' where ID='" & ViewState("loanID") & "'", con)
                Using cmd = New SqlCommand("update QUEST_APPLICATION set [FIN_REPAY_DATE]='" & txt1stPayDate.Text & "' where ID='" & ViewState("loanID") & "'", con)
                    If con.State = ConnectionState.Open Then
                        con.Close()
                    End If
                    con.Open()
                    Try
                        cmd.ExecuteNonQuery()
                        createAmortizationOptions(ViewState("loanID"))
                        notify("Amortization schedule created", "success")
                    Catch ex As Exception
                        ErrorLogging.WriteLogFile(Session("UserId"), Request.Url.ToString & " --- btnSaveCreditParameters_Click()", ex.ToString)
                        CreditManager.notify("Error creating amortization schedule", "error")
                    Finally
                        con.Close()
                    End Try
                End Using
            End Using
        End If
    End Sub

    Protected Sub clearAgreements()
        repAgreements.DataSource = Nothing
        repAgreements.DataBind()
    End Sub

    Protected Sub createAmortizationOptions(ByVal loanID As String)
        Try
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd As New SqlCommand("select FIN_REPAY_OPT from QUEST_APPLICATION where ID='" & loanID & "'", con)
                    Dim ds As New DataSet
                    Dim adp = New SqlDataAdapter(cmd)
                    adp.Fill(ds, "LOANS")
                    If ds.Tables(0).Rows.Count > 0 Then
                        'Using cmdNormal = New SqlCommand("sp_amortize_balance_daily", con)
                        Using cmdNormal = New SqlCommand("sp_amortize", con)
                            cmdNormal.CommandType = CommandType.StoredProcedure
                            cmdNormal.Parameters.AddWithValue("@loanID", loanID)
                            If con.State <> ConnectionState.Closed Then
                                con.Close()
                            End If
                            con.Open()
                            cmdNormal.ExecuteNonQuery()
                            con.Close()
                        End Using
                        'End If
                    End If
                End Using
            End Using
        Catch ex As Exception
            notify("Unable to create amortization schedule. Make sure all parameters are entered", "error")
            'ClientScript.RegisterStartupScript(Me.GetType(), "Gritter", "<script type=""text/javascript"">$.gritter.add({title: 'Amortization Failure!',text: 'An error occurred while creating the amortization schedule. Please make sure all parameters are entered correctly with the right format and try again.',image: 'images/error_button.png'});</script>")
        End Try
    End Sub

    Protected Sub getAppDetails(ByVal loanID As String)
        Try
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd As New SqlCommand("select *,convert(varchar,DOB,106) as DOB1,convert(varchar,ISSUE_DATE,106) as ISSUE_DATE1,convert(varchar,GUARANTOR_DOB,106) as GUARANTOR_DOB1,convert(varchar,FIN_REPAY_DATE,106) as FIN_REPAY_DATE1 from QUEST_APPLICATION where (SEND_TO='" & Session("ROLE") & "' or SEND_TO='1024') and ID='" & loanID & "' and STATUS<>'DISBURSED' and STATUS<>'REPAID'", con)
                    Dim ds As New DataSet
                    Dim adp = New SqlDataAdapter(cmd)
                    adp.Fill(ds, "APP")
                    If ds.Tables(0).Rows.Count > 0 Then
                        Dim dr = ds.Tables(0).Rows(0)
                        txtCustNo.Text = dr.Item("CUSTOMER_NUMBER")
                        txtName.Text = Trim(BankString.isNullString(dr.Item("SURNAME"))) + " " + BankString.isNullString(dr.Item("FORENAMES"))
                        lblBranchCode.Text = BankString.isNullString(dr.Item("BRANCH_CODE"))
                        lblBranchName.Text = BankString.isNullString(dr.Item("BRANCH_NAME"))
                        txtFinReqAccNo.Text = BankString.isNullString(dr.Item("FIN_ACCNO"))
                        ViewState("Phone") = BankString.isNullString(dr.Item("PHONE_NO"))
                        Try
                            txtFinReqAmt.Text = FormatNumber(BankString.isNullString(dr.Item("AMT_APPLIED")), 2)
                        Catch ex As Exception
                            txtFinReqAmt.Text = ""
                        End Try

                        Try
                            txtAmtToDisburse.Text = FormatNumber(BankString.isNullString(dr.Item("FIN_AMT")), 2)
                        Catch ex As Exception
                            txtAmtToDisburse.Text = ""
                        End Try
                        Try
                            txtRecAmt.Text = FormatNumber(BankString.isNullString(dr.Item("RECOMMENDED_AMT")), 2)
                        Catch ex As Exception
                            txtRecAmt.Text = ""
                        End Try
                        txtFinReqIntRate.Text = BankString.isNullString(dr.Item("FIN_INT_RATE"))
                        txtFinReqPurpose.Text = BankString.isNullString(dr.Item("FIN_PURPOSE"))
                        txtFinReqSecOffer.Text = BankString.isNullString(dr.Item("FIN_SEC_OFFER"))
                        txtFinReqSource.Text = BankString.isNullString(dr.Item("FIN_SRC_REPAYMT"))
                        txtFinReqTenor.Text = BankString.isNullString(dr.Item("FIN_TENOR"))
                        txtInterestRate.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("INT_RATE"))
                        txtInsuranceRate.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("INSURANCE_RATE"))
                        txtAdminRate.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("ADMIN_RATE"))
                        Try
                            rdbClientType.SelectedValue = dr.Item("CUSTOMER_TYPE")
                        Catch ex As Exception
                            rdbClientType.ClearSelection()
                        End Try
                        Try
                            rdbFinReqDisburseOption.SelectedValue = dr.Item("DISBURSE_OPTION")
                        Catch ex As Exception
                            rdbFinReqDisburseOption.ClearSelection()
                        End Try
                        Try
                            cmbProductType.SelectedValue = dr.Item("FinProductType")
                        Catch ex As Exception
                            cmbProductType.ClearSelection()
                        End Try
                        Try
                            getProductDefaults(dr.Item("FinProductType"))
                        Catch ex As Exception

                        End Try
                        Try
                            cmbSector.SelectedValue = BankString.isNullString(ds.Tables(0).Rows(0).Item("Sector"))
                        Catch ex As Exception
                            cmbSector.ClearSelection()
                        End Try
                        Try
                            txtFirstPayDate.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("FIN_REPAY_DATE1"))
                        Catch ex As Exception
                            txtFirstPayDate.Text = ""
                        End Try
                        If rdbClientType.SelectedValue = "Individual" Then
                            Try
                                rdbSubIndividual.Visible = True
                                rdbSubIndividual.SelectedValue = ds.Tables(0).Rows(0).Item("SUB_INDIVIDUAL")
                            Catch ex As Exception

                            End Try
                            If Session("ROLE") = "4042" Then
                                'tickSSB()
                            End If
                        ElseIf rdbClientType.SelectedValue = "Business" Then
                        End If
                        If rdbSubIndividual.SelectedValue = "SSB" Then
                            txtMinDept.Text = BankString.isNullString(dr.Item("MIN_DEPT"))
                            txtMinDeptNo.Text = BankString.isNullString(dr.Item("MIN_DEPT_NO"))
                            txtECNo.Text = BankString.isNullString(dr.Item("ECNO"))
                            txtECNoCD.Text = BankString.isNullString(dr.Item("CD"))

                            lblMinDept.Visible = True
                            lblMinDeptNo.Visible = True
                            lblEmpCode.Visible = True
                            txtMinDept.Visible = True
                            txtMinDeptNo.Visible = True
                            txtECNo.Visible = True
                            txtECNoCD.Visible = True
                        End If

                        If rdbFinReqDisburseOption.SelectedValue = "Ecocash" Then
                            lblEcocashNumber.Visible = True
                            txtEcocashNumber.Visible = True
                            txtEcocashNumber.Text = dr.Item("ECOCASH_NUMBER")
                        End If
                        getIndividualAmounts(loanID)
                    Else
                    End If
                End Using
            End Using
        Catch ex As Exception
            msgbox(ex.ToString)
        End Try
    End Sub

    Protected Sub getDisbursements(ByVal roleID As String, cliName As String)
        Try
            Dim ds As New DataSet
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd As New SqlCommand("select ID,CUSTOMER_NUMBER as [CUST NO.],CUSTOMER_TYPE as [TYPE],case IS_PARTIAL when 1 then RTRIM(isnull(SURNAME,'')+' '+isnull(FORENAMES,''))+' - PARTIALLY DISBURSED' else RTRIM(isnull(SURNAME,'')+' '+isnull(FORENAMES,'')) end as NAME,CONVERT(DECIMAL(30,2),FIN_AMT) as AMOUNT,convert(varchar,CREATED_DATE,113) as 'APPLICATION DATE' from QUEST_APPLICATION where (SEND_TO='" & roleID & "' or SEND_TO='1024') and STATUS<>'REJECTED' and STATUS<>'DISBURSED' and STATUS<>'REPAID' and RTRIM(isnull(SURNAME,'')+' '+isnull(FORENAMES,'')) like '%" & cliName & "%' order by SURNAME asc", con)
                    Dim adp = New SqlDataAdapter(cmd)
                    adp.Fill(ds, "APP")
                    If ds.Tables(0).Rows.Count > 0 Then
                        grdDisbursements.DataSource = ds.Tables(0)
                    Else
                        grdDisbursements.DataSource = Nothing
                    End If
                    grdDisbursements.DataBind()
                End Using
            End Using
            lblAppCount.Text = ds.Tables(0).Rows.Count
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub getProductDefaults(productID As String)
        Try
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd = New SqlCommand("select * from [CreditProducts] where id='" & productID & "'", con)
                    Dim ds As New DataSet
                    Using adp = New SqlDataAdapter(cmd)
                        adp.Fill(ds, "PDA")
                    End Using
                    If ds.Tables(0).Rows.Count > 0 Then
                        Dim dr = ds.Tables(0).Rows(0)
                        Try
                            If dr("ProductFees") = "None" Then
                                lblAdminRate.Visible = False
                                txtAdminCharge.Text = "0"
                                txtAdminCharge.Visible = False
                            Else
                                lblAdminRate.Visible = True
                                txtAdminCharge.Visible = True
                                Try
                                    lblAdminRate.Text = IIf(dr("ProductFeeCalc") = "Percentage", "Application Fees (%)", "Application Fees ($)")
                                Catch ex As Exception

                                End Try
                                Try
                                    txtAdminCharge.Text = dr("ProductFeeAmtPerc")
                                Catch ex As Exception
                                    txtAdminCharge.Text = ""
                                End Try
                                ViewState("ProductFees") = dr("ProductFees")
                                ViewState("ProductFeeAmt") = IIf(dr("ProductFeeCalc") = "Percentage", txtRecAmt.Text * dr("ProductFeeAmtPerc") / 100, dr("ProductFeeAmtPerc"))
                                If dr("ProductFees") = "Deducted" Then
                                    txtUpfrontFees.Text = ViewState("ProductFeeAmt")
                                    lblProductFee.Text = "Application Fees amount of " & FormatCurrency(ViewState("ProductFeeAmt")) & " Deducted on Disbursement"
                                ElseIf dr("ProductFees") = "Capitalized" Then
                                    txtUpfrontFees.Text = 0
                                    lblProductFee.Text = "Application Fees amount of " & FormatCurrency(ViewState("ProductFeeAmt")) & " capitalized"
                                Else
                                    txtUpfrontFees.Text = 0
                                End If
                            End If
                        Catch ex As Exception

                        End Try
                        Try
                            rdbInterestTrigger.SelectedValue = dr("IntTrigger")
                        Catch ex As Exception
                            rdbInterestTrigger.ClearSelection()
                        End Try
                        txtUpfrontFees_TextChanged(DBNull.Value, New EventArgs)
                    End If
                End Using
            End Using
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- getProductDefaults()", ex.ToString)
        End Try
    End Sub

    Protected Sub grdDisbursements_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles grdDisbursements.PageIndexChanging
        grdDisbursements.PageIndex = e.NewPageIndex
        getDisbursements(Session("ROLE"), "")
    End Sub

    Protected Sub grdDisbursements_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles grdDisbursements.RowCommand
        Try
            Dim EncQuery As New BankEncryption64
            If e.CommandName = "Select" Then
                Dim loanID = e.CommandArgument
                Response.Redirect("LoanDisbursement.aspx?id=" & EncQuery.Encrypt(loanID.Replace(" ", "+")), False)
                'Response.Redirect("LoanDisbursement.aspx?id=" & loanID, False)
            ElseIf e.CommandName = "Details" Then
                Dim loanID = e.CommandArgument
            End If
        Catch ex As Exception
            ErrorLogging.WriteLogFile(Session("UserId"), Request.Url.ToString & " --- grdDisbursements_RowCommand()", ex.ToString)
        End Try
    End Sub

    Protected Sub grdDisbursements_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles grdDisbursements.RowDataBound
        Try
            If e.Row.RowType = DataControlRowType.DataRow Then
                Dim lnk As LinkButton = CType(e.Row.FindControl("LinkButton1"), LinkButton)
                If lnk.CommandArgument = ViewState("loanID") Then
                    Dim ri = (e.Row.RowIndex)
                    e.Row.RowState = DataControlRowState.Selected
                End If
            End If
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- grdDisbursements_RowDataBound()", ex.ToString)
        End Try
    End Sub

    Protected Sub insertInterestAccountsTemp(loanID As String)
        'get ineterest to maturity
        Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
            Dim cmdInt = New SqlCommand("select max(cumulative_interest) from AMORTIZATION_SCHEDULE where LOANID='" & loanID & "'", con)
            Dim intToMaturity As Double = 0
            If con.State <> ConnectionState.Closed Then
                con.Close()
            End If
            con.Open()
            intToMaturity = cmdInt.ExecuteScalar
            con.Close()

            'Using cmd = New SqlCommand("SaveAccountsTrxnsTempWithContra", con)
            Using cmd = New SqlCommand("SaveAccountsTrxns", con)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("@Type", "System Entry")
                cmd.Parameters.AddWithValue("@Category", "Interest Payable")
                cmd.Parameters.AddWithValue("@Ref", loanID)
                cmd.Parameters.AddWithValue("@Desc", "Interest to Maturity")
                cmd.Parameters.AddWithValue("@Debit", intToMaturity)
                cmd.Parameters.AddWithValue("@Credit", 0.0)
                cmd.Parameters.AddWithValue("@Account", txtCustNo.Text)
                'cmd.Parameters.AddWithValue("@Account", "112/2")
                'cmd.Parameters.AddWithValue("@ContraAccount", cmbInterestAccount.SelectedValue)
                cmd.Parameters.AddWithValue("@ContraAccount", "223/2")
                'cmd.Parameters.AddWithValue("@ContraAccount", "112/2")
                cmd.Parameters.AddWithValue("@Status", 1)
                cmd.Parameters.AddWithValue("@Other", txtCustNo.Text)
                cmd.Parameters.AddWithValue("@BankAccID", "")
                'cmd.Parameters.AddWithValue("@BankAccName", "")
                cmd.Parameters.AddWithValue("@BankAccName", txtVoucherNo.Text)
                cmd.Parameters.AddWithValue("@BatchRef", "")
                cmd.Parameters.AddWithValue("@TrxnDate", txtDisburseDate.Text)
                cmd.Parameters.AddWithValue("@CaptureBy", Session("UserId"))
                cmd.Parameters.AddWithValue("@DebtorAccNo", txtCustNo.Text)
                cmd.Parameters.AddWithValue("@AccountName", txtName.Text)
                If con.State = ConnectionState.Open Then
                    con.Close()
                End If
                con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            End Using
            Using cmd = New SqlCommand("SaveAccountsTrxns", con)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("@Type", "System Entry")
                cmd.Parameters.AddWithValue("@Category", "Interest Payable")
                cmd.Parameters.AddWithValue("@Ref", loanID)
                cmd.Parameters.AddWithValue("@Desc", "Interest to Maturity")
                cmd.Parameters.AddWithValue("@Debit", 0)
                cmd.Parameters.AddWithValue("@Credit", intToMaturity)
                cmd.Parameters.AddWithValue("@Account", "223/2")
                cmd.Parameters.AddWithValue("@ContraAccount", txtCustNo.Text)
                'cmd.Parameters.AddWithValue("@ContraAccount", "112/2")
                cmd.Parameters.AddWithValue("@Status", 1)
                cmd.Parameters.AddWithValue("@Other", txtCustNo.Text)
                cmd.Parameters.AddWithValue("@BankAccID", "")
                'cmd.Parameters.AddWithValue("@BankAccName", "")
                cmd.Parameters.AddWithValue("@BankAccName", txtVoucherNo.Text)
                cmd.Parameters.AddWithValue("@BatchRef", "")
                cmd.Parameters.AddWithValue("@TrxnDate", txtDisburseDate.Text)
                cmd.Parameters.AddWithValue("@CaptureBy", Session("UserId"))
                cmd.Parameters.AddWithValue("@DebtorAccNo", txtCustNo.Text)
                cmd.Parameters.AddWithValue("@AccountName", "Unearned Interest")
                If con.State = ConnectionState.Open Then
                    con.Close()
                End If
                con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            End Using
        End Using
    End Sub

    Protected Sub insertInterestAccountsTempGroup(loanID As String, GrpAccNo As String, indivAccNo As String, groupLoanID As String, indivName As String)
        'get ineterest to maturity
        Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
            Dim cmdInt = New SqlCommand("select max(cumulative_interest) from AMORTIZATION_SCHEDULE where LOANID='" & loanID & "'", con)
            Dim intToMaturity As Double = 0
            If con.State <> ConnectionState.Closed Then
                con.Close()
            End If
            con.Open()
            intToMaturity = cmdInt.ExecuteScalar
            con.Close()

            'Using cmd = New SqlCommand("SaveAccountsTrxnsTempWithContra", con)
            Using cmd = New SqlCommand("SaveAccountsTrxns", con)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("@Type", "System Entry")
                cmd.Parameters.AddWithValue("@Category", "Interest Payable")
                cmd.Parameters.AddWithValue("@Ref", loanID)
                cmd.Parameters.AddWithValue("@Desc", "Interest to Maturity")
                cmd.Parameters.AddWithValue("@Debit", intToMaturity)
                cmd.Parameters.AddWithValue("@Credit", 0.0)
                cmd.Parameters.AddWithValue("@Account", indivAccNo)
                'cmd.Parameters.AddWithValue("@Account", "112/2")
                'cmd.Parameters.AddWithValue("@ContraAccount", cmbInterestAccount.SelectedValue)
                cmd.Parameters.AddWithValue("@ContraAccount", "223/2")
                'cmd.Parameters.AddWithValue("@ContraAccount", "112/2")
                cmd.Parameters.AddWithValue("@Status", 1)
                cmd.Parameters.AddWithValue("@Other", indivAccNo)
                cmd.Parameters.AddWithValue("@BankAccID", "")
                'cmd.Parameters.AddWithValue("@BankAccName", "")
                cmd.Parameters.AddWithValue("@BankAccName", txtVoucherNo.Text)
                cmd.Parameters.AddWithValue("@BatchRef", "")
                cmd.Parameters.AddWithValue("@TrxnDate", txtDisburseDate.Text)
                cmd.Parameters.AddWithValue("@CaptureBy", Session("UserId"))
                cmd.Parameters.AddWithValue("@DebtorAccNo", indivAccNo)
                cmd.Parameters.AddWithValue("@AccountName", indivName)
                cmd.Parameters.AddWithValue("@GroupAccNo", GrpAccNo)
                cmd.Parameters.AddWithValue("@GroupLoanID", groupLoanID)
                If con.State = ConnectionState.Open Then
                    con.Close()
                End If
                con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            End Using
            Using cmd = New SqlCommand("SaveAccountsTrxns", con)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("@Type", "System Entry")
                cmd.Parameters.AddWithValue("@Category", "Interest Payable")
                cmd.Parameters.AddWithValue("@Ref", loanID)
                cmd.Parameters.AddWithValue("@Desc", "Interest to Maturity")
                cmd.Parameters.AddWithValue("@Debit", 0)
                cmd.Parameters.AddWithValue("@Credit", intToMaturity)
                cmd.Parameters.AddWithValue("@Account", "223/2")
                cmd.Parameters.AddWithValue("@ContraAccount", indivAccNo)
                'cmd.Parameters.AddWithValue("@ContraAccount", "112/2")
                cmd.Parameters.AddWithValue("@Status", 1)
                cmd.Parameters.AddWithValue("@Other", indivAccNo)
                cmd.Parameters.AddWithValue("@BankAccID", "")
                'cmd.Parameters.AddWithValue("@BankAccName", "")
                cmd.Parameters.AddWithValue("@BankAccName", txtVoucherNo.Text)
                cmd.Parameters.AddWithValue("@BatchRef", "")
                cmd.Parameters.AddWithValue("@TrxnDate", txtDisburseDate.Text)
                cmd.Parameters.AddWithValue("@CaptureBy", Session("UserId"))
                cmd.Parameters.AddWithValue("@DebtorAccNo", indivAccNo)
                cmd.Parameters.AddWithValue("@AccountName", "Unearned Interest")
                cmd.Parameters.AddWithValue("@GroupAccNo", GrpAccNo)
                cmd.Parameters.AddWithValue("@GroupLoanID", groupLoanID)
                If con.State = ConnectionState.Open Then
                    con.Close()
                End If
                con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            End Using
        End Using
    End Sub

    Protected Sub insertUpfrontTemp(loanID As String)
        'get interest to maturity
        Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)

            'Using cmd = New SqlCommand("SaveAccountsTrxnsTempWithContra", con)
            Using cmd = New SqlCommand("SaveAccountsTrxnsWithContra", con)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("@Type", "System Entry")
                cmd.Parameters.AddWithValue("@Category", "Loan Disbursement")
                cmd.Parameters.AddWithValue("@Ref", loanID)
                cmd.Parameters.AddWithValue("@Desc", "Upfront Fees Charged")
                cmd.Parameters.AddWithValue("@Debit", toMoney(txtUpfrontFees.Text))
                cmd.Parameters.AddWithValue("@Credit", 0.0)
                'cmd.Parameters.AddWithValue("@Account", cmbInterestAccount.SelectedValue)
                cmd.Parameters.AddWithValue("@Account", txtCustNo.Text)
                cmd.Parameters.AddWithValue("@ContraAccount", cmbUpfrontFeesAccount.SelectedValue)
                cmd.Parameters.AddWithValue("@Status", 1)
                cmd.Parameters.AddWithValue("@Other", txtCustNo.Text)
                cmd.Parameters.AddWithValue("@BankAccID", "")
                cmd.Parameters.AddWithValue("@BankAccName", "")
                cmd.Parameters.AddWithValue("@BatchRef", "")
                cmd.Parameters.AddWithValue("@TrxnDate", txtDisburseDate.Text)
                cmd.Parameters.AddWithValue("@CaptureBy", Session("UserId"))
                cmd.Parameters.AddWithValue("@DebtorAccNo", txtCustNo.Text)
                cmd.Parameters.AddWithValue("@AccountName", cmbUpfrontFeesAccount.SelectedItem.Text)
                If con.State = ConnectionState.Open Then
                    con.Close()
                End If
                con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            End Using
            Using cmd = New SqlCommand("SaveAccountsTrxnsWithContra", con)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("@Type", "System Entry")
                cmd.Parameters.AddWithValue("@Category", "Loan Disbursement")
                cmd.Parameters.AddWithValue("@Ref", loanID)
                cmd.Parameters.AddWithValue("@Desc", "Upfront Fees")
                cmd.Parameters.AddWithValue("@Debit", 0.0)
                cmd.Parameters.AddWithValue("@Credit", toMoney(txtUpfrontFees.Text))
                'cmd.Parameters.AddWithValue("@Account", cmbInterestAccount.SelectedValue)
                cmd.Parameters.AddWithValue("@Account", txtCustNo.Text)
                cmd.Parameters.AddWithValue("@ContraAccount", cmbDisbursementAccount.SelectedValue)
                cmd.Parameters.AddWithValue("@Status", 1)
                cmd.Parameters.AddWithValue("@Other", txtCustNo.Text)
                cmd.Parameters.AddWithValue("@BankAccID", "")
                cmd.Parameters.AddWithValue("@BankAccName", "")
                cmd.Parameters.AddWithValue("@BatchRef", "")
                cmd.Parameters.AddWithValue("@TrxnDate", txtDisburseDate.Text)
                cmd.Parameters.AddWithValue("@CaptureBy", Session("UserId"))
                cmd.Parameters.AddWithValue("@DebtorAccNo", txtCustNo.Text)
                cmd.Parameters.AddWithValue("@AccountName", cmbDisbursementAccount.SelectedItem.Text)
                If con.State = ConnectionState.Open Then
                    con.Close()
                End If
                con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            End Using
        End Using
    End Sub

    Protected Function isAmortized(loanID As String) As Integer
        Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
            Using cmdApp = New SqlCommand("select * from QUEST_APPLICATION where ID='" & loanID & "'", con)
                Dim dsApp As New DataSet
                Using adp = New SqlDataAdapter(cmdApp)
                    adp.Fill(dsApp, "qa")
                End Using
                If dsApp.Tables(0).Rows.Count > 0 Then
                    Using cmd = New SqlCommand("select * from AMORTIZATION_SCHEDULE where LOANID='" & loanID & "' or [GroupLoanID]='" & loanID & "'", con)
                        Dim ds As New DataSet
                        Using adp = New SqlDataAdapter(cmd)
                            adp.Fill(ds, "armo")
                        End Using
                        If ds.Tables(0).Rows.Count > 0 Then
                            Return 2
                        Else
                            Return 1
                        End If
                    End Using
                Else
                    Return 0
                End If
            End Using
        End Using
    End Function

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
                    cmbDisbursementAccount.Visible = True
                    loadCombo(ds.Tables(0), cmbDisbursementAccount, "AccountName", "AccountNo")
                End Using
            End Using
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- loadAccounts()", ex.ToString)
        End Try
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
    '                cmbDisbursementAccount.Visible = True
    '                loadCombo(ds.Tables(0), cmbDisbursementAccount, "AccountName", "AccountNo")
    '            End Using
    '        End Using
    '    Catch ex As Exception
    '        WriteLogFile(Session("UserId"), Request.Url.ToString & " --- loadAccounts()", ex.ToString)
    '    End Try
    'End Sub

    Protected Sub loadAgreements()
        Try
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd = New SqlCommand("select isnull([SUB_INDIVIDUAL],'') as [SUB_INDIVIDUAL],[FIN_AMT],[FIN_TENOR],[FIN_INT_RATE],[FIN_ADMIN],[FIN_REPAY_DATE],[FIN_REPAY_OPT],[CUSTOMER_TYPE],[CUSTOMER_NUMBER],[MD_ID],ISNULL(ASSET_NAME,'') as [ASSET_NAME] from QUEST_APPLICATION where ID='" & ViewState("loanID") & "' and [STATUS]<>'REJECTED'", con)
                    'msgbox(cmd.CommandText)
                    Dim ds As New DataSet
                    Using adp = New SqlDataAdapter(cmd)
                        adp.Fill(ds, "CREDIT")
                    End Using
                    repAgreements.DataSource = Nothing
                    repAgreements.DataBind()
                    Dim EncQuery As New BankEncryption64
                    If ds.Tables(0).Rows.Count > 0 Then
                        Try
                            Dim dt As New DataTable
                            dt.Columns.Add("navURL")
                            dt.Columns.Add("lnkText")
                            If Trim(ds.Tables(0).Rows(0).Item("ASSET_NAME")) <> "" Then
                                dt.Rows.Add("rptAssetFinancing.aspx?id=" & EncQuery.Encrypt(ViewState("loanID").Replace(" ", "+")) & "&asset=1", "Acknowledgement of Debt")

                            ElseIf ds.Tables(0).Rows(0).Item("CUSTOMER_TYPE") = "Group" Then
                                dt.Rows.Add("rptFormLetter.aspx?id=" & EncQuery.Encrypt(ViewState("loanID").Replace(" ", "+")) & "&typ=grp&cust=" & EncQuery.Encrypt(ds.Tables(0).Rows(0).Item("CUSTOMER_NUMBER").Replace(" ", "+")) & "", "Form Letter")
                                dt.Rows.Add("rptAcknowledgement.aspx?id=" & EncQuery.Encrypt(ViewState("loanID").Replace(" ", "+")) & "&typ=grp&cust=" & EncQuery.Encrypt(ds.Tables(0).Rows(0).Item("CUSTOMER_NUMBER").Replace(" ", "+")) & "", "Acknowledgement of Debt")
                            Else
                                If ds.Tables(0).Rows(0).Item("SUB_INDIVIDUAL") = "SSB" Then
                                    dt.Rows.Add("rptFormLetter.aspx?id=" & EncQuery.Encrypt(ViewState("loanID").Replace(" ", "+")) & "", "Form Letter")
                                    dt.Rows.Add("rptAcknowledgeSSB.aspx?id=" & EncQuery.Encrypt(ViewState("loanID").Replace(" ", "+")) & "", "Acknowledgement of Debt")
                                Else
                                    dt.Rows.Add("rptFormLetter.aspx?id=" & EncQuery.Encrypt(ViewState("loanID").Replace(" ", "+")) & "", "Form Letter")
                                    dt.Rows.Add("rptAcknowledgement.aspx?id=" & EncQuery.Encrypt(ViewState("loanID").Replace(" ", "+")) & "", "Acknowledgement of Debt")
                                End If
                            End If
                            repAgreements.DataSource = dt
                            repAgreements.DataBind()
                            'End If
                        Catch ex As Exception
                            msgbox(ex.ToString)
                        End Try
                    Else
                    End If
                End Using
            End Using
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub loadClientTypes()
        Try
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd As New SqlCommand("select * from PARA_CLIENT_TYPES", con)
                    Using adp As New SqlDataAdapter(cmd)
                        Dim ds As New DataSet
                        adp.Fill(ds, "Clients")
                        loadCombo(ds.Tables(0), rdbClientType, "CLIENT_TYPE", "CLIENT_TYPE")
                    End Using
                End Using
            End Using
        Catch ex As Exception
            msgbox(ex.ToString)
        End Try
    End Sub

    Protected Sub loadUpfrontAccounts()
        Try
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd = New SqlCommand("select convert(varchar,MainAccount) as AccountNo, AccountName  + '  ' + convert(varchar,MainAccount) as AccountName from tbl_FinancialAccountsCreation-- where convert(varchar,MainAccount) + '/' + convert(varchar,SubAccount)='302/2' or convert(varchar,MainAccount) + '/' + convert(varchar,SubAccount)='223/2'", con)
                    'End if
                    Dim ds As New DataSet
                    Using adp = New SqlDataAdapter(cmd)
                        adp.Fill(ds, "LRS2")
                    End Using
                    cmbUpfrontFeesAccount.Visible = True
                    loadCombo(ds.Tables(0), cmbUpfrontFeesAccount, "AccountName", "AccountNo")
                End Using
            End Using
        Catch ex As Exception
            msgbox(ex.ToString)
        End Try
    End Sub

    Protected Sub loadRepayParameters()
        Try
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd = New SqlCommand("select [FIN_AMT],[FIN_TENOR],[FIN_INT_RATE],qa.ADMIN_RATE, [FIN_ADMIN],convert(varchar(50),fin_repay_date,106) as [FIN_REPAY_DATE],[FIN_REPAY_OPT],[CUSTOMER_TYPE],ISNULL(qa.[DefaultIntInterval],cp.DefaultIntInterval) as [DefaultIntInterval],ISNULL(qa.[IntCalcMethod],cp.[IntCalcMethod]) as [IntCalcMethod],ISNULL(qa.[IntTrigger],cp.[IntTrigger]) as [IntTrigger],ISNULL(qa.[DaysInYear],cp.[DaysInYear]) as [DaysInYear],ISNULL(qa.[RepaymentFreq],cp.[RepaymentFreq]) as [RepaymentFreq],ISNULL(qa.[HasGracePeriod],cp.[HasGracePeriod]) as [HasGracePeriod],ISNULL(qa.[GracePeriodType],cp.[GracePeriodType]) as [GracePeriodType],ISNULL(qa.[GracePeriodLength],cp.[GracePeriodLength]) as [GracePeriodLength],ISNULL(qa.[GracePeriodUnit],cp.[GracePeriodUnit]) as [GracePeriodUnit],ISNULL(qa.[AllowRepaymentOnWknd],cp.[AllowRepaymentOnWknd]) as [AllowRepaymentOnWknd],ISNULL(qa.[IfRepaymentFallsOnWknd],cp.[IfRepaymentFallsOnWknd]) as [IfRepaymentFallsOnWknd],ISNULL(qa.[AllowEditingPaymentSchedule],cp.[AllowEditingPaymentSchedule]) as [AllowEditingPaymentSchedule],ISNULL(qa.[RepayOrder1],cp.[RepayOrder1]) as [RepayOrder1],ISNULL(qa.[RepayOrder2],cp.[RepayOrder2]) as [RepayOrder2],ISNULL(qa.[RepayOrder3],cp.[RepayOrder3]) as [RepayOrder3],ISNULL(qa.[RepayOrder4],cp.[RepayOrder4]) as [RepayOrder4],ISNULL(qa.[TolerancePeriodNum],cp.[TolerancePeriodNum]) as [TolerancePeriodNum],ISNULL(qa.[TolerancePeriodUnit],cp.[TolerancePeriodUnit]) as [TolerancePeriodUnit],ISNULL(qa.[ArrearNonWorkingDays],cp.[ArrearNonWorkingDays]) as [ArrearNonWorkingDays],ISNULL(qa.[PenaltyCharged],cp.[PenaltyCharged]) as [PenaltyCharged],ISNULL(qa.[PenaltyOption],cp.[PenaltyOption]) as [PenaltyOption],ISNULL(qa.[AmtToPenalise],cp.[AmtToPenalise]) as [AmtToPenalise],ISNULL(qa.[ProductFees],cp.[ProductFees]) as [ProductFees],ISNULL(qa.[ProductFeeCalc],cp.[ProductFeeCalc]) as [ProductFeeCalc],ISNULL(qa.[ProductFeeAmtPerc],cp.[ProductFeeAmtPerc]) as [ProductFeeAmtPerc],qa.RepaymentIntervalNum, qa.RepaymentIntervalUnit,FinProductType from QUEST_APPLICATION qa JOIN creditproducts cp ON qa.FinProductType=cp.id where qa.ID='" & ViewState("loanID") & "'", con)
                    Dim ds As New DataSet
                    Using adp = New SqlDataAdapter(cmd)
                        adp.Fill(ds, "CREDIT")
                    End Using
                    If ds.Tables(0).Rows.Count > 0 Then
                        Try
                            Try
                                txtRepayPeriod.Text = FormatNumber(ds.Tables(0).Rows(0).Item("FIN_TENOR"), 0)
                            Catch ex As Exception
                                txtRepayPeriod.Text = ""
                            End Try

                            txtIntRate.Text = ds.Tables(0).Rows(0).Item("FIN_INT_RATE")
                            Try
                                txtAdminCharge.Text = ds.Tables(0).Rows(0).Item("ADMIN_RATE")
                            Catch ex As Exception
                                txtAdminCharge.Text = "0"
                            End Try
                            Try
                                txt1stPayDate.Text = ds.Tables(0).Rows(0).Item("FIN_REPAY_DATE")
                            Catch ex As Exception
                                txt1stPayDate.Text = ""
                            End Try
                            'Try
                            '    txtLoanAmt.Text = FormatNumber(ds.Tables(0).Rows(0).Item("FIN_AMT"), 2)
                            'Catch ex As Exception
                            '    txtLoanAmt.Text = ""
                            'End Try
                            Try
                                txtRepaymentInterval.Text = ds.Tables(0).Rows(0).Item("RepaymentIntervalNum")
                                txtRepayInterval.Text = ds.Tables(0).Rows(0).Item("RepaymentIntervalNum")
                            Catch ex As Exception
                                txtRepaymentInterval.Text = ""
                                txtRepayInterval.Text = ""
                            End Try
                            Try
                                cmbRepaymentInterval.SelectedValue = ds.Tables(0).Rows(0).Item("RepaymentIntervalUnit")
                                cmbRepayInterval.SelectedValue = ds.Tables(0).Rows(0).Item("RepaymentIntervalUnit")
                            Catch ex As Exception
                                cmbRepaymentInterval.ClearSelection()
                                cmbRepayInterval.ClearSelection()
                            End Try
                            'getProductDefaults(ds.Tables(0).Rows(0).Item("FinProductType"))
                            'lblViewSchedule.Text = "<a href='rptAmortizationSchedule.aspx?loanID=" & txtLoanID.Text & "' target='new'>View Schedule</a>"
                        Catch ex As Exception
                            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- loadRepayParameters()", ex.ToString)
                        End Try
                    Else
                        'CreditManager.notify("No matches found", "error")
                    End If
                End Using
            End Using
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- loadRepayParameters()", ex.ToString)
        End Try
    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Page.MaintainScrollPositionOnPostBack = True
        If Not IsPostBack Then
            loadProductType(cmbProductType)
            loadSectors(cmbSector)
            Dim EncQuery As New BankEncryption64

            Try
                ViewState("loanID") = EncQuery.Decrypt(Request.QueryString("id").Replace(" ", "+"))
            Catch ex As Exception
                'ViewState("loanID") = "0"
            End Try
            loadAccounts()
            cmbDisbursementAccount.Visible = True
            loadUpfrontAccounts()
            getDisbursements(Session("ROLE"), "")
            loadAssets()
            loadClientTypes()
            txtUpfrontFees.Text = "0"
            If ViewState("loanID") <> "" And ViewState("loanID") <> "0" Then
                'msgbox(ViewState("loanID"))
                getAppDetails(ViewState("loanID"))
                loadRepayParameters()
                If isAmortized(ViewState("loanID")) = 0 Then
                    notify("Requested Loan ID not found", "error")
                ElseIf isAmortized(ViewState("loanID")) = 2 Then
                    loadAgreements()
                ElseIf isAmortized(ViewState("loanID")) = 1 Then
                    notify("This loan application has not yet been amortized. Create amortization schedule first.", "warning")
                    ClientScript.RegisterStartupScript(Me.GetType(), "showAmortization", "<script type=""text/javascript"">showAmortization();</script>")
                End If
                lnkArmotize.NavigateUrl = "Amortization.aspx?ID=" & EncQuery.Encrypt(ViewState("loanID").Replace(" ", "+")) & "&App=1"
                'lnkAppRating.NavigateUrl = "ApplicationRating.aspx?loanID=" & EncQuery.Encrypt(ViewState("loanID").Replace(" ", "+"))
                lnkAmortizationSchedule.NavigateUrl = "rptAmortizationSchedule.aspx?loanID=" & EncQuery.Encrypt(ViewState("loanID").Replace(" ", "+"))
            End If
            'If CashBoxActive() = True Then
            '    loadCashBox()

            'End If
        End If
    End Sub

    Protected Sub recordDisbursalTrans(custNo As String, loanID As String, amt As Double)
        Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
            Using cmd = New SqlCommand("insert into QUEST_TRANSACTIONS (CUST_NO,LOANID,TRANS_DATE,TRANS_DESC,DEBIT,CREDIT,BAL_BFWD,BAL_CFWD) VALUES ('" & custNo & "','" & loanID & "','" & txtDisburseDate.Text & "','Loan Disbursement','" & amt & "','0','0','" & amt & "')", con)
                If con.State = ConnectionState.Open Then
                    con.Close()
                End If
                con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            End Using
        End Using
    End Sub

    Protected Sub saveComment()
        'Try
        'Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
        'Using cmd As New SqlCommand("insert into REQUEST_HISTORY (LOANID,COMMENT_DATE,USERID,COMMENT,RECOMMENDED_AMT) values('" & Request.QueryString("id") & "',GETDATE(),'" & Session("UserID") & "','" & BankString.removeSpecialCharacter(txtComment.Text) & "','" & txtRecAmt.Text & "')", con)
        'If con.State = ConnectionState.Open Then
        'con.Close()
        'End If
        'con.Open()
        'cmd.ExecuteNonQuery()
        'con.Close()
        'End Using
        'End Using
        'Catch ex As Exception
        '
        'End Try
    End Sub

    Protected Sub saveDisbursement()
        Try
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd = New SqlCommand("SaveDisbursement", con)
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.AddWithValue("@CustNo", txtCustNo.Text)
                    cmd.Parameters.AddWithValue("@LoanID", ViewState("loanID"))
                    cmd.Parameters.AddWithValue("@TrxnDate", txtDisburseDate.Text)
                    cmd.Parameters.AddWithValue("@Name", txtName.Text)
                    cmd.Parameters.AddWithValue("@ProductID", cmbProductType.SelectedValue)
                    cmd.Parameters.AddWithValue("@ProductName", cmbProductType.SelectedItem.Text)
                    cmd.Parameters.AddWithValue("@Sector", cmbSector.SelectedItem.Text)
                    cmd.Parameters.AddWithValue("@AmountRequired", toMoney(txtFinReqAmt.Text))
                    cmd.Parameters.AddWithValue("@NoOfRepayments", toMoney(txtFinReqTenor.Text))
                    cmd.Parameters.AddWithValue("@RepaymentIntervalNum", txtRepayInterval.Text)
                    cmd.Parameters.AddWithValue("@RepaymentIntervalUnit", cmbRepayInterval.SelectedValue)
                    cmd.Parameters.AddWithValue("@InterestRate", toMoney(txtFinReqIntRate.Text))
                    cmd.Parameters.AddWithValue("@ApplicationFees", toMoney(txtAdminRate.Text))
                    cmd.Parameters.AddWithValue("@Purpose", txtFinReqPurpose.Text)
                    cmd.Parameters.AddWithValue("@DisbursementChannel", rdbFinReqDisburseOption.SelectedValue)
                    cmd.Parameters.AddWithValue("@UpfrontFees", toMoney(txtUpfrontFees.Text))
                    cmd.Parameters.AddWithValue("@AmountToDisburse", toMoney(txtAmtToDisburse.Text))
                    cmd.Parameters.AddWithValue("@PrincipalAccount", cmbDisbursementAccount.SelectedValue)
                    'cmd.Parameters.AddWithValue("@InterestAccount", cmbInterestAccount.SelectedValue)
                    cmd.Parameters.AddWithValue("@InterestAccount", "223/2")
                    cmd.Parameters.AddWithValue("@User", Session("UserId"))
                    cmd.Parameters.AddWithValue("@ApprovedAmt", toMoney(txtRecAmt.Text))
                    con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                End Using
            End Using
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub saveTransaction(reference As String, description As String, debit As Double, credit As Double, account As String, contra As String, status As String, other As String, bankAccId As String, bankAccName As String, batchRef As String, trxnDate As Date, accName As String, Optional grpCustNo As String = "", Optional grpLoanID As String = "0")
        Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
            'Using cmd As New SqlCommand("SaveAccountsTrxnsTempWithContra", con)
            ' Using cmd = New SqlCommand("SaveAccountsTrxnsWithContra", con)
            Using cmd = New SqlCommand("SaveAccountsTrxns", con)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("@Type", "System Entry")
                cmd.Parameters.AddWithValue("@Category", "Loan Disbursement")
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
                cmd.Parameters.AddWithValue("@BankAccName", txtVoucherNo.Text)
                cmd.Parameters.AddWithValue("@BatchRef", batchRef)
                cmd.Parameters.AddWithValue("@TrxnDate", trxnDate)
                cmd.Parameters.AddWithValue("@CaptureBy", Session("UserId"))
                cmd.Parameters.AddWithValue("@DebtorAccNo", txtCustNo.Text)
                cmd.Parameters.AddWithValue("@AccountName", accName)
                If grpCustNo <> "" Then
                    cmd.Parameters.AddWithValue("@GroupAccNo", grpCustNo)
                End If
                If grpLoanID <> "0" Then
                    cmd.Parameters.AddWithValue("@GroupLoanID", grpLoanID)
                End If

                If con.State = ConnectionState.Open Then
                    con.Close()
                End If
                con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            End Using
        End Using
    End Sub
    Protected Sub txtUpfrontFees_TextChanged(sender As Object, e As EventArgs) Handles txtUpfrontFees.TextChanged
        Try
            If IsNumeric(toMoney(txtFinReqAmt.Text)) And IsNumeric(toMoney(txtUpfrontFees.Text)) Then
                If CDbl(txtFinReqAmt.Text) <= CDbl(txtUpfrontFees.Text) Then
                    notify("Upfront fees cannot be greater than or equal to amount required", "error")
                Else
                    'txtAmtToDisburse.Text = FormatNumber(txtFinReqAmt.Text - txtUpfrontFees.Text, 2)
                    txtAmtToDisburse.Text = FormatNumber(txtRecAmt.Text - txtUpfrontFees.Text, 2)
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
    Public Sub loadCashBox()
        Dim accNo As String = ""
        Dim balance As String = ""
        Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
            Dim ds As New DataSet
            Try
                cmd2 = New SqlCommand("select FNAME + ' '+ LNAME + ' | ' + 'LO/'+ CONVERT(VARCHAR,USERID) as AccountName, 'LO/'+ CONVERT(VARCHAR,USERID) as AccNo from MASTER_USERS where USER_TYPE in ('4041','5049') and USER_LOGIN='" & Session("UserID").ToString() & "'", con)
                Dim ds4 As New DataSet
                Dim adp2 = New SqlDataAdapter(cmd2)
                adp2.Fill(ds4, "users")
                If ds4.Tables(0).Rows.Count > 0 Then
                    accNo = ds4.Tables(0).Rows(0).Item("AccNo")
                    con.Close()
                End If
            Catch ex As Exception
            End Try
            Try
                con.Open()
                cmd2 = New SqlCommand("select isnull(sum(debit-credit),0) as Bal from Accounts_Transactions where Account='" & accNo & "'", con)
                Dim ds5 As New DataSet
                Dim adp = New SqlDataAdapter(cmd2)
                adp.Fill(ds5, "Accounts_Transactions")
                If ds5.Tables(0).Rows.Count > 0 Then
                    balance = ds5.Tables(0).Rows(0).Item("Bal")
                    con.Close()
                End If
            Catch ex As Exception
            End Try
            Session("CashBox") = balance
            TextBox1.Text = "USD" + balance
        End Using
    End Sub

    Protected Function isAlredyDisbursed(lID As String) As Boolean
        Try
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd = New SqlCommand("select isnull(id,0) from [Accounts_Transactions] where description='Disbursement' AND credit>0 AND Refrence='" & lID & "'", con)
                    Dim disb As Double = 0
                    con.Open()
                    disb = cmd.ExecuteScalar
                    con.Close()
                    If disb > 0 Then
                        Return True
                    Else
                        Return False
                    End If
                End Using
            End Using
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- isAlredyDisbursed()", ex.ToString)
            Return False
        End Try
    End Function

    Protected Sub getIndividualAmounts(lID As String)
        Try
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd = New SqlCommand("select ID,CUSTOMER_NUMBER as [Account No.],ISNULL(FORENAMES,'')+' '+ISNULL(SURNAME,'') as [Name],IDNO as [ID Number],FORMAT(FIN_AMT,'n2') as [Amount] from QUEST_APPLICATION where GroupLoanID='" & lID & "'", con)
                    Dim dt As New DataTable
                    Using adp As New SqlDataAdapter(cmd)
                        adp.Fill(dt)
                    End Using
                    bindGrid(dt, grdIndivFinReq)
                End Using
            End Using
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- getIndividualAmounts()", ex.ToString)
        End Try
    End Sub
End Class