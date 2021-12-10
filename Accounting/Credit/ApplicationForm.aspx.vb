Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System.Net
Imports Mailhelper
Imports CreditManager
Imports ErrorLogging
Imports SecureBank
Imports System.Web.Services

Partial Class Credit_ApplicationForm
    Inherits System.Web.UI.Page

    Public Function InsertUpdateData(ByVal cmd As SqlCommand) As Boolean
        Dim strConnString As String = System.Configuration.ConfigurationManager.ConnectionStrings("conString").ConnectionString()
        Dim con As New SqlConnection(strConnString)
        cmd.CommandType = CommandType.Text
        cmd.Connection = con
        Try
            con.Open()
            cmd.ExecuteNonQuery()
            Return True
        Catch ex As Exception
            Response.Write(ex.ToString)
            Return False
        Finally
            con.Close()
            con.Dispose()
        End Try
    End Function

    Protected Function amortizationAlreadyCreated(loanID As String) As Boolean
        Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
            Using cmd = New SqlCommand("select * from AMORTIZATION_SCHEDULE where LOANID='" & loanID & "'", con)
                Dim ds As New DataSet
                Using adp = New SqlDataAdapter(cmd)
                    adp.Fill(ds, "AMO")
                End Using
                If ds.Tables(0).Rows.Count > 0 Then
                    Return True
                Else
                    Return False
                End If
            End Using
        End Using
    End Function

    Protected Sub applicantTypeSelector(appType As String)
        cmbBankAppType.ClearSelection()
        cmbBranchAppType.ClearSelection()
        cmbPDAAppType.ClearSelection()
        txtECNo.Text = ""
        txtECNoCD.Text = ""
        txtOtherAppType.Text = ""
        If appType = "SSB" Then
            lblEmpCode.Visible = True
            txtECNo.Visible = True
            txtECNoCD.Visible = True
            SSBVisible()
            divAppTypeBanker.Visible = False
            divAppTypeOther.Visible = False
            divAppTypePDA.Visible = False
        ElseIf appType = "Bankers" Then
            lblEmpCode.Visible = False
            txtECNo.Visible = False
            txtECNoCD.Visible = False
            divAppTypeBanker.Visible = True
            divAppTypeOther.Visible = False
            divAppTypePDA.Visible = False
            SSBInvisible()
        ElseIf appType = "PDAs" Then
            lblEmpCode.Visible = False
            txtECNo.Visible = False
            txtECNoCD.Visible = False
            divAppTypeBanker.Visible = False
            divAppTypeOther.Visible = False
            divAppTypePDA.Visible = True
            SSBInvisible()
        ElseIf appType = "Other" Then
            lblEmpCode.Visible = False
            txtECNo.Visible = False
            txtECNoCD.Visible = False
            divAppTypeBanker.Visible = False
            divAppTypeOther.Visible = True
            divAppTypePDA.Visible = False
            SSBInvisible()
        End If
    End Sub

    Protected Sub btnAddCollateral_Click(sender As Object, e As EventArgs) Handles btnAddCollateral.Click
        Try
            If Trim(txtCustNo.Text) = "" Then
                notify("Enter client customer number", "error")
                txtCustNo.Focus()
            ElseIf Trim(cmbCollateralType.SelectedItem.Text) = "" Then
                notify("Select the collateral type", "error")
                cmbCollateralType.Focus()
            ElseIf Trim(txtCollateralDesc.Text) = "" Then
                notify("Enter the collateral description", "error")
                txtCollateralDesc.Focus()
            ElseIf Trim(txtCollateralValue.Text) = "" Then
                notify("Enter the collateral value", "error")
                txtCollateralValue.Focus()
            Else
                Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                    Using cmd As New SqlCommand("insert into ClientCollateral (CustNo,LoanID,CollateralID,CollateralType,CollDesc,CollValue,CapturedBy,CaptureDate) values (@CustNo,@LoanID,@CollateralID,@CollateralType,@CollDesc,@CollValue,@CapturedBy,GETDATE())", con)
                        cmd.Parameters.AddWithValue("@CustNo", txtCustNo.Text)
                        cmd.Parameters.AddWithValue("@LoanID", 0)
                        cmd.Parameters.AddWithValue("@CollateralID", cmbCollateralType.SelectedValue)
                        cmd.Parameters.AddWithValue("@CollateralType", cmbCollateralType.SelectedItem.Text)
                        cmd.Parameters.AddWithValue("@CollDesc", txtCollateralDesc.Text)
                        cmd.Parameters.AddWithValue("@CollValue", txtCollateralValue.Text)
                        cmd.Parameters.AddWithValue("@CapturedBy", Session("UserId"))
                        con.Open()
                        If cmd.ExecuteNonQuery() Then
                            notify("Collateral saved", "success")
                            getClientCollateral(txtCustNo.Text, ViewState("globLoanID"))
                            cmbCollateralType.ClearSelection()
                            txtCollateralDesc.Text = ""
                            txtCollateralValue.Text = ""
                        Else
                            notify("Error saving collateral", "error")
                        End If
                        con.Close()
                    End Using
                End Using
            End If
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- btnAddCollateral_Click()", ex.ToString)
        End Try
    End Sub

    Protected Sub btnAddCollateralType_Click(sender As Object, e As EventArgs) Handles btnAddCollateralType.Click
        Try
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd As New SqlCommand("insert into CollateralTypes (CollateralName) values (@CollateralName)", con)
                    cmd.Parameters.AddWithValue("@CollateralName", txtCollateralType.Text)
                    con.Open()
                    If cmd.ExecuteNonQuery() Then
                        notify("Collateral type saved", "success")
                        loadCollateralTypes()
                        txtCollateralType.Text = ""
                    Else
                        notify("Error saving collateral type", "error")
                    End If
                    con.Close()
                End Using
            End Using
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- btnAddCollateralType_Click()", ex.ToString)
        End Try
    End Sub

    Protected Sub btnAddOtherLoan_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddOtherLoan.Click
        Try
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd = New SqlCommand("insert into QUEST_OTHER_LOANS (CUSTOMER_NUMBER,OTHER_DESC,OTHER_ACCNO,OTHER_AMT) values ('" & txtCustNo.Text & "','" & BankString.removeSpecialCharacter(txtOtherDesc.Text) & "','" & txtOtherAccNo.Text & "','" & txtOtherAmt.Text & "')", con)
                    If con.State = ConnectionState.Open Then
                        con.Close()
                    End If
                    con.Open()
                    If cmd.ExecuteNonQuery() Then
                        notify("Loan added successfully", "success")
                    Else
                        notify("Error adding loan", "error")
                    End If
                    con.Close()
                    txtOtherAccNo.Text = ""
                    txtOtherAmt.Text = ""
                    txtOtherDesc.Text = ""
                    getOtherLoans()
                End Using
            End Using
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- btnAddOtherLoan_Click()", ex.ToString)
        End Try
    End Sub

    Protected Sub btnFarmAddSec_Click(sender As Object, e As EventArgs) Handles btnFarmAddSec.Click

    End Sub

    Protected Sub btnGrpSubmitApp_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGrpSubmitApp.Click
        Try
            If CDbl(txtGrpApplInterest.Text) > CDbl(ViewState("MaxIntRate")) Then
                notify("Interest rate greater than the maximum allowed for this product", "error")
                Exit Sub
            ElseIf CDbl(txtGrpApplInterest.Text) < CDbl(ViewState("MinIntRate")) Then
                notify("Interest rate less than minimum allowed for this product", "error")
                Exit Sub
            ElseIf Val(txtGrpApplLoanAmt.Text) > Val(ViewState("MaxAmt")) Or Val(txtGrpApplLoanAmt.Text) < Val(ViewState("MinAmt")) Then
                notify("Required amount out of the range for this product", "error")
                Exit Sub
            ElseIf CDbl(txtGrpApplRepayTenure.Text) > CDbl(ViewState("MaximumTenure")) Or CDbl(txtGrpApplRepayTenure.Text) < CDbl(ViewState("MinimumTenure")) Then
                notify("Loan tenure out of the range for this product", "error")
                Exit Sub
            End If
            getNextApproval(1)
            If toMoney(txtGrpApplLoanAmt.Text) <> toMoney(getGrpTotalAmt) Then
                notify("Applied amount and member breakdown do not match", "error")
                Exit Sub
            End If
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd = New SqlCommand("insert into QUEST_APPLICATION ([APPL_DATE],[FinProductType],[CUSTOMER_TYPE],[CUSTOMER_NUMBER],[SURNAME],[FORENAMES],[IDNO],[ADDRESS],[CITY],[PHONE_NO],[NATIONALITY],[GENDER],[BUS_TYPE],[BUS_PERIOD],[SOURCE1],[SOURCE2],[SOURCE3],[BORROWING1],[BORROWING2],[BORROWING3],[FIN_AMT],[FIN_TENOR],[FIN_PURPOSE],[FIN_INT_RATE],[CREATED_BY],[CREATED_DATE],[MODIFIED_BY],[MODIFIED_DATE],[STATUS],[SEND_TO],[LO_ID],[LAST_ID],[AMT_APPLIED],[FIN_ADMIN],[BRANCH_CODE],[BRANCH_NAME],[ReadyToDisburse],[ApprovalNumber],RepaymentIntervalNum,RepaymentIntervalUnit,ADMIN_RATE,RECOMMENDED_AMT) values ('" & txtGrpAppDate.Text & "','" & cmbGrpProduct.SelectedValue & "','Group','" & txtCustNo.Text & "','" & BankString.removeSpecialCharacter(txtGrpName.Text) & "','','','','','','','','" & BankString.removeSpecialCharacter(txtGrpApplLineBus.Text) & "',nullif('" & txtGrpApplPeriodBus.Text & "',''),'" & BankString.removeSpecialCharacter(txtGrpApplSrcIncome1.Text) & "','" & BankString.removeSpecialCharacter(txtGrpApplSrcIncome2.Text) & "','" & BankString.removeSpecialCharacter(txtGrpApplSrcIncome3.Text) & "','" & BankString.removeSpecialCharacter(txtGrpApplBorrow1.Text) & "','" & BankString.removeSpecialCharacter(txtGrpApplBorrow2.Text) & "','" & BankString.removeSpecialCharacter(txtGrpApplBorrow3.Text) & "',nullif('" & txtGrpApplLoanAmt.Text & "',''),nullif('" & txtGrpApplRepayTenure.Text & "',''),'" & BankString.removeSpecialCharacter(cmbGrpFinReqPurpose.SelectedValue) & "',nullif('" & txtGrpApplInterest.Text & "',''),'" & Session("UserID") & "',getdate(),'','','SUBMITTED','" & ViewState("NextRole") & "','" & Session("ID") & "','" & Session("ID") & "',nullif('" & txtGrpApplLoanAmt.Text & "',''),nullif('" & txtGrpAdminFee.Text & "',''),'" & lblBranchCode.Text & "','" & BankString.removeSpecialCharacter(lblBranchName.Text) & "','" & ViewState("ReadyToDisburse") & "',1,NULLIF('" & txtRepaymentInterval.Text & "',''),'" & cmbRepaymentInterval.SelectedValue & "',nullif('" & toMoney(txtGrpAdminRate.Text) & "',''),nullif('" & toMoney(txtGrpApplLoanAmt.Text) & "',''))", con)
                    If con.State = ConnectionState.Open Then
                        con.Close()
                    End If
                    con.Open()
                    If cmd.ExecuteNonQuery() Then
                        ViewState("globLoanID") = getLastLoanID()
                        Dim strEmail As String
                        Dim SignatoryEMail As String
                        SignatoryEMail = Mailhelper.GetMultipleEMailID(ViewState("NextRole"))

                        strEmail = "Dear Sir/Madam,<br/><br/>You have received a request for " & ViewState("NextStageName") & ". Details of the application are as follows<br><br>"
                        strEmail = strEmail & "<table style='border: 1px solid black; width:750px;border-collapse: collapse; font-size:13px'>"
                        strEmail = strEmail & "<tr style='background-color: #f5f5f5;padding: 15px;text-align: left;'><th style='border: 1px solid black;text-align: left;'>Group Name:</th><td style='border: 1px solid black;'>" & txtGrpName.Text & " " & txtForenames.Text & "</td></tr>"
                        strEmail = strEmail & "<tr style='background-color: white;padding: 15px;text-align: left;'><th style='border: 1px solid black;text-align: left;'>Date:</th><td style='border: 1px solid black;'>" & Now.ToShortDateString() & "</td></tr>"
                        strEmail = strEmail & "<tr style='background-color: #f5f5f5;padding: 15px;text-align: left;'><th style='border: 1px solid black;text-align: left;'>Applicant Type:</th><td style='border: 1px solid black;'>" & rdbClientType.SelectedItem.Text & "</td></tr>"
                        strEmail = strEmail & "<tr style='background-color: white;padding: 15px;text-align: left;'><th style='border: 1px solid black;text-align: left;'>Product:</th><td style='border: 1px solid black;'>" & cmbGrpProduct.SelectedItem.Text.ToString & "</td></tr>"
                        strEmail = strEmail & "<tr style='background-color: white;padding: 15px;text-align: left;'><th style='border: 1px solid black;text-align: left;'>Branch:</th><td style='border: 1px solid black;'>" & lblBranchCode.Text.Trim() & " - " & lblBranchName.Text.Trim() & "</td></tr>"
                        strEmail = strEmail & "<tr style='background-color: #f5f5f5;padding: 15px;text-align: left;'><th style='border: 1px solid black;text-align: left;'>Amount:</th><td style='border: 1px solid black;'>" & FormatCurrency(txtGrpApplLoanAmt.Text).ToString.Replace("Z", "US") & "</td></tr>"
                        strEmail = strEmail & "</table>"
                        strEmail = strEmail & "<br/>Thanks & Regards,<br/><b>Escrow 360 Support Team</b>"

                        If SignatoryEMail = "" Then
                        Else
                            Mailhelper.SendMailMessage("administrator", SignatoryEMail, "", "", "Escrow Credit Management - Loan Application Request", strEmail)
                        End If
                        saveGrpMemberAmts(txtCustNo.Text, ViewState("globLoanID"))
                        saveInitiatorCommentGrp()
                        clearGroup()
                        Dim EncQuery As New BankEncryption64
                        lblTest.Text = ViewState("globLoanID")
                        lblTestEnc.Text = EncQuery.Encrypt(ViewState("globLoanID").replace(" ", "+"))

                        ClientScript.RegisterStartupScript(Me.GetType(), "HideLabel", "<script type=""text/javascript"">showPopup()</script>")
                    End If
                    con.Close()
                End Using
            End Using
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- btnGrpSubmitApp_Click()", ex.ToString)
        End Try
    End Sub

    Protected Sub btnGrpTerminate_Click(sender As Object, e As EventArgs) Handles btnGrpTerminate.Click
        Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
            Using cmd = New SqlCommand("update QUEST_APPLICATION set STATUS='TERMINATED',LAST_ID='" & Session("ID") & "',MODIFIED_DATE=GETDATE(),MODIFIED_BY='" & Session("UserID") & "' where ID='" & ViewState("globLoanID") & "'", con)
                If con.State = ConnectionState.Open Then
                    con.Close()
                End If
                con.Open()
                If cmd.ExecuteNonQuery() Then
                    Response.Write("<script>alert('Loan successfully terminated') ; location.href='ApplicationForm.aspx'</script>")
                End If
                con.Close()
            End Using
        End Using
    End Sub

    Protected Sub btnIDNo_Click(sender As Object, e As EventArgs) Handles btnIDNo.Click
        Try
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd = New SqlCommand("select *,convert(varchar,DOB,106) as DOB1,convert(varchar,ISSUE_DATE,106) as ISSUE_DATE1 from CUSTOMER_DETAILS where REPLACE(replace(IDNO,'-',''),' ','') = REPLACE(replace('" & txtIDNo.Text & "','-',''),' ','')", con)
                    Dim ds As New DataSet
                    Dim adp = New SqlDataAdapter(cmd)
                    adp.Fill(ds, "CUSTOMER")
                    If ds.Tables(0).Rows.Count > 0 Then
                        getNamesDT(ds.Tables(0))
                        Dim outs = getOutstandingLoans(txtCustNo.Text)
                        If outs = 0 Then
                        ElseIf outs = 1 Then
                            notify("This customer already has 1 loan currently running.", "warning")
                        ElseIf outs >= 2 Then
                            'modal confirmation
                            ClientScript.RegisterStartupScript(Me.GetType(), "Confirmation", "<script type=""text/javascript"">showConfirmOtherLoans();</script>")
                        End If
                        rdbSubIndividual_SelectedIndexChanged(sender, New EventArgs)
                    Else
                        notify("This ID number does not exist in the system", "error")
                    End If
                End Using
            End Using
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- btnIDNo_Click()", ex.ToString)
        End Try
    End Sub

    Protected Sub btnSaveFarmer_Click(sender As Object, e As EventArgs) Handles btnSaveFarmer.Click
        Try
            Dim adminCharge As Double = 0
            Try
                adminCharge = txtFarmOtherCharge.Text
            Catch ex As Exception
                adminCharge = 0
            End Try
            Dim cmtxt = ""
            If btnSaveFarmer.Text = "Update Application" Then
                cmtxt = "update QUEST_APPLICATION set [CUSTOMER_TYPE]=NULLIF('" & rdbClientType.SelectedItem.Text & "',''),[CUSTOMER_NUMBER]='" & txtCustNo.Text & "',[SURNAME]='" & BankString.removeSpecialCharacter(txtFarmNameOfGroup.Text) & "',[FORENAMES]='" & BankString.removeSpecialCharacter(txtFarmNameOfApplicant.Text) & "',[DOB]='" & txtFarmDOB.Text & "',[IDNO]='" & txtFarmIDNo.Text & "',[ISSUE_DATE]='" & txtFarmIssDate.Text & "',[ADDRESS]='" & BankString.removeSpecialCharacter(txtFarmCurrentAddress.Text) & "',[PHONE_NO]='" & txtFarmPhoneNo.Text & "',[GENDER]='" & rdbFarmGender.SelectedValue & "',[SPOUSE_NAME]='" & BankString.removeSpecialCharacter(txtFarmNameOfSpouse.Text) & "',[FIN_AMT]='" & txtFarmLoanAmtReqd.Text & "',[FIN_TENOR]='" & txtFarmTenure.Text & "',[FIN_INT_RATE]='" & txtFarmIntRate.Text & "',[FIN_REPAY_DATE]='" & txtFarmRepayDate.Text & "',[OTHER_AMT]=nullif('" & txtFarmOtherCharge.Text & "',''),[MODIFIED_BY]='" & Session("UserID") & "',[MODIFIED_DATE]=getdate(),[STATUS]='SUBMITTED',[SEND_TO]='4042',[BRANCH_CODE]='" & lblBranchCode.Text & "',[BRANCH_NAME]='" & BankString.removeSpecialCharacter(lblBranchName.Text) & "',[AMT_APPLIED]='" & txtFarmLoanAmtReqd.Text & "',[OTHER_CHARGES]='" & txtFarmOtherCharge.Text & "',[DISBURSE_OPTION]='" & rdbFarmDisburseOption.SelectedValue & "',LO_ID='" & Session("ID") & "',LAST_ID='" & Session("ID") & "', MONTH_EXPENSE='" & txtFarmMonthlyExpense.Text & "', MONTH_INCOME='" & txtFarmMonthlyIncome.Text & "', PREV_SALES='" & txtFarmPreviousSales.Text & "', CURR_ESTIMATE='" & txtFarmCurrentEstimate.Text & "', CROPS='" & txtFarmCropsGrown.Text & "', FARM_PERIOD='" & txtFarmPeriodFarming.Text & "', SPOUSE_ADDRESS='" & BankString.removeSpecialCharacter(txtFarmCurrAddressOfSpouse.Text) & "',FIN_ADMIN='" & adminCharge & "' where ID='" & ViewState("globLoanID") & "'"
            Else
                cmtxt = "insert into QUEST_APPLICATION ([CUSTOMER_TYPE],[CUSTOMER_NUMBER],[SURNAME],[FORENAMES],[DOB],[IDNO],[ISSUE_DATE],[ADDRESS],[PHONE_NO],[GENDER],[SPOUSE_NAME],[FIN_AMT],[FIN_TENOR],[FIN_INT_RATE],[FIN_REPAY_DATE],[APP1_APPROVED],[RECOMMENDED_AMT],[APP1_SIGNATURE],[APP2_APPROVED],[APPROVED_AMT],[APP2_SIGNATURE],[INSTALLMENT],[PERIOD],[CREATED_BY],[CREATED_DATE],[MODIFIED_BY],[MODIFIED_DATE],[STATUS],[SEND_TO],[BRANCH_CODE],[BRANCH_NAME],[AMT_APPLIED],[ECOCASH_NUMBER],[OTHER_CHARGES],[DISBURSE_OPTION],LO_ID,LAST_ID, MONTH_EXPENSE, MONTH_INCOME, PREV_SALES, CURR_ESTIMATE, CROPS, FARM_PERIOD, SPOUSE_ADDRESS,FIN_ADMIN) values (NULLIF('" & rdbClientType.SelectedItem.Text & "',''),'" & txtCustNo.Text & "','" & BankString.removeSpecialCharacter(txtFarmNameOfGroup.Text) & "','" & BankString.removeSpecialCharacter(txtFarmNameOfApplicant.Text) & "','" & txtFarmDOB.Text & "','" & txtFarmIDNo.Text & "','" & txtFarmIssDate.Text & "','" & BankString.removeSpecialCharacter(txtFarmCurrentAddress.Text) & "','" & txtFarmPhoneNo.Text & "','" & rdbFarmGender.SelectedValue & "','" & BankString.removeSpecialCharacter(txtFarmNameOfSpouse.Text) & "','" & txtFarmLoanAmtReqd.Text & "','" & txtFarmTenure.Text & "','" & txtFarmIntRate.Text & "','" & txtFarmRepayDate.Text & "','','','','','','','','','" & Session("UserID") & "',getdate(),'','','SUBMITTED','4042','" & lblBranchCode.Text & "','" & BankString.removeSpecialCharacter(lblBranchName.Text) & "','" & txtFarmLoanAmtReqd.Text & "','','" & txtFarmOtherCharge.Text & "','" & rdbFarmDisburseOption.SelectedValue & "','" & Session("ID") & "','" & Session("ID") & "','" & txtFarmMonthlyExpense.Text & "','" & txtFarmMonthlyIncome.Text & "','" & txtFarmPreviousSales.Text & "','" & txtFarmCurrentEstimate.Text & "','" & txtFarmCropsGrown.Text & "','" & txtFarmPeriodFarming.Text & "','" & txtFarmCurrAddressOfSpouse.Text & "','" & adminCharge & "')"
            End If
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd = New SqlCommand(cmtxt, con)
                    If con.State = ConnectionState.Open Then
                        con.Close()
                    End If
                    con.Open()
                    Try
                        If cmd.ExecuteNonQuery() Then
                            updateDocLoanID(txtCustNo.Text)
                            saveInitiatorComment()
                            Dim strEmail As String
                            Dim SignatoryEMail As String
                            strEmail = "<Strong>Dear Sir/Madam,</strong><br>You Have Received A New Loan Application Request. Details are as follows<br><br>"
                            strEmail = strEmail & "<Table bgcolor='444444'><font forecolor='ffffff'>"
                            strEmail = strEmail & "<tr bgcolor='999999'><td>Date:</td><td>" & Now & "</td></tr>"
                            strEmail = strEmail & "<tr bgcolor='eeeeee'><td>Applicant Type:</td><td>" & rdbClientType.SelectedItem.Text & "</td></tr>"
                            strEmail = strEmail & "<tr bgcolor='999999'><td>Branch:</td><td>" & lblBranchCode.Text.Trim() & " - " & lblBranchName.Text.Trim() & "</td></tr>"
                            strEmail = strEmail & "<tr bgcolor='999999'><td>Client Name:</td><td>" & txtGrpName.Text & "</td></tr>"
                            strEmail = strEmail & "<tr bgcolor='999999'><td>Amount:</td><td>" & txtFinReqAmt.Text & "</td></tr>"
                            strEmail = strEmail & "</font></Table>"
                            strEmail = strEmail & "<br/><Strong>Thanks & Regards,<br/>IT Support Team</strong>"
                            SignatoryEMail = Mailhelper.GetMultipleEMailID(ViewState("NextRole"))
                            Mailhelper.SendMailMessage("administrator", SignatoryEMail, "", "", "Escrow Credit Management - Loan Application", strEmail)
                            clearAll()
                            Dim EncQuery As New BankEncryption64
                            lblTest.Text = ViewState("globLoanID")
                            lblTestEnc.Text = EncQuery.Encrypt(ViewState("globLoanID").replace(" ", "+"))

                            ClientScript.RegisterStartupScript(Me.GetType(), "HideLabel", "<script type=""text/javascript"">showPopup()</script>")
                        End If
                    Catch ex As Exception
                        WriteLogFile(ex.ToString)
                    End Try
                    con.Close()
                End Using
            End Using
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- btnSaveFarmer_Click()", ex.ToString)
        End Try
    End Sub

    Protected Sub btnSearchCustNo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearchCustNo.Click
        clearAllExceptCustNo()
        If isBlacklisted(txtCustNo.Text) Then
            notify("This client is blacklisted", "error")
        Else
            If isValidCustID(txtCustNo.Text) Then
                Dim outs = getOutstandingLoans(txtCustNo.Text)

                If outs = 0 Then
                ElseIf outs = 1 Then
                    CreditManager.notify("This customer already has 1 loan currently running.", "warning")
                ElseIf outs >= 2 Then
                    'modal confirmation
                    ClientScript.RegisterStartupScript(Me.GetType(), "Confirmation", "<script type=""text/javascript"">showConfirmOtherLoans();</script>")
                End If
                If isGroupNotActivated(txtCustNo.Text) Then
                    notify("Group must be activated first", "error")
                Else
                    getNames(txtCustNo.Text)
                End If
            Else
                notify("No record with this customer number was found.", "error")
            End If
        End If
    End Sub

    Protected Function isBlacklisted(custNo As String) As Boolean
        Try
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd = New SqlCommand("select isnull(Blacklisted,0) as Blacklisted from CUSTOMER_DETAILS where CUSTOMER_NUMBER='" & custNo & "'", con)
                    Dim dt As New DataTable
                    Using adp = New SqlDataAdapter(cmd)
                        adp.Fill(dt)
                    End Using
                    If dt.Rows(0).Item("Blacklisted") Then
                        Return True
                    Else
                        Return False
                    End If
                End Using
            End Using
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- isBlacklisted()", ex.ToString)
            Return False
        End Try
    End Function

    Protected Sub btnSearchSurname_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearchSurname.Click
        Try
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd = New SqlCommand("select CUSTOMER_NUMBER, isnull(SURNAME,'')+' '+isnull(FORENAMES,'')+' --- '+isnull(CUSTOMER_NUMBER,'')+' --- '+isnull(IDNO,'')+' --- '+isnull(ADDRESS,'') as display from CUSTOMER_DETAILS where isnull(SURNAME,'')+' '+isnull(FORENAMES,'')+' --- '+isnull(IDNO,'')+' --- '+isnull(ADDRESS,'') like '%" & txtSearchSurname.Text & "%'", con)
                    Dim ds As New DataSet
                    Using adp = New SqlDataAdapter(cmd)
                        adp.Fill(ds, "cust")
                    End Using
                    If ds.Tables(0).Rows.Count > 0 Then
                        lstSurname.Visible = True
                        lstSurname.DataSource = ds.Tables(0)
                        lstSurname.DataTextField = "display"
                        lstSurname.DataValueField = "CUSTOMER_NUMBER"
                    Else
                        lstSurname.DataSource = Nothing
                        CreditManager.notify("The searched name was not found", "error")
                    End If
                    clearAll()
                    lstSurname.DataBind()
                End Using
            End Using
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- btnSearchSurname_Click()", ex.ToString)
        End Try
    End Sub

    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        submitApplication()
    End Sub

    Protected Sub btnTerminate_Click(sender As Object, e As EventArgs) Handles btnTerminate.Click
        Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
            Using cmd = New SqlCommand("update QUEST_APPLICATION set STATUS='TERMINATED',LAST_ID='" & Session("ID") & "',MODIFIED_DATE=GETDATE(),MODIFIED_BY='" & Session("UserID") & "' where ID='" & ViewState("globLoanID") & "'", con)
                If con.State = ConnectionState.Open Then
                    con.Close()
                End If
                con.Open()
                If cmd.ExecuteNonQuery() Then
                    Response.Write("<script>alert('Loan successfully terminated') ; location.href='ApplicationForm.aspx'</script>")
                End If
                con.Close()
            End Using
        End Using
    End Sub

    Protected Sub btnUploadApp_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUploadApp.Click
        Try
            Dim filePath As String = filAttachApp.PostedFile.FileName
            Dim filename As String = Path.GetFileName(filePath)
            Dim ext As String = Path.GetExtension(filename)
            Dim contenttype As String = String.Empty
            'Set the contenttype based on File Extension
            Select Case ext
                Case ".doc"
                    contenttype = "application/msword"
                    Exit Select
                Case ".docx"
                    contenttype = "application/msword"
                    Exit Select
                Case ".xls"
                    contenttype = "application/x-msexcel"
                    Exit Select
                Case ".xlsx"
                    contenttype = "application/x-msexcel"
                    Exit Select
                Case ".jpg"
                    contenttype = "image/jpg"
                    Exit Select
                Case ".png"
                    contenttype = "image/png"
                    Exit Select
                Case ".gif"
                    contenttype = "image/gif"
                    Exit Select
                Case ".pdf"
                    contenttype = "application/pdf"
                    Exit Select
            End Select

            If contenttype <> String.Empty Then
                Dim fs As Stream = filAttachApp.PostedFile.InputStream
                Dim br As New BinaryReader(fs)
                Dim bytes As Byte() = br.ReadBytes(fs.Length)

                'insert the file into database
                Dim strQuery As String = "insert into QUEST_DOCUMENTS" _
                & "(CUST_NO, LOAN_ID, DOC_DESC, DOC_DATA, DOC_TYPE, DOC_EXT, DOC_FILENAME)" _
                & " values (@CUST_NO, @LOAN_ID,@DOC_DESC, @DOC_DATA,@DOC_TYPE,@DOC_EXT, @DOC_FILENAME)"
                Dim cmd As New SqlCommand(strQuery)
                cmd.Parameters.Add("@CUST_NO", SqlDbType.VarChar).Value = txtCustNo.Text
                cmd.Parameters.Add("@LOAN_ID", SqlDbType.VarChar).Value = "" 'yet to be determined at this stage. Must be updated at form submit
                cmd.Parameters.Add("@DOC_FILENAME", SqlDbType.VarChar).Value = filename
                cmd.Parameters.Add("@DOC_DESC", SqlDbType.VarChar).Value = txtDocDesc.Text
                cmd.Parameters.Add("@DOC_EXT", SqlDbType.VarChar).Value = ext
                cmd.Parameters.Add("@DOC_TYPE", SqlDbType.VarChar).Value = contenttype
                cmd.Parameters.Add("@DOC_DATA", SqlDbType.Binary).Value = bytes
                If InsertUpdateData(cmd) Then
                    txtDocDesc.Text = ""
                    loadUploadedFiles(txtCustNo.Text)
                    notify("File uploaded successfully", "success")
                Else
                    notify("An error occurred while uploading the file", "error")
                End If
            Else
                notify("Select the file to upload", "error")
            End If
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- btnUploadApp_Click()", ex.ToString)
        End Try
    End Sub

    Protected Sub chkTickSSB_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkTickSSB.CheckedChanged
        Try
            If chkTickSSB.Checked Then
                btnSubmit.Enabled = True
            Else
                btnSubmit.Enabled = False
            End If
        Catch ex As Exception
            WriteLogFile(ex.ToString)
        End Try
    End Sub

    Protected Sub clearAll()
        Try
            clearAllExceptCustNo()
            txtCustNo.Text = ""
        Catch ex As Exception
            WriteLogFile(ex.ToString)
        End Try
    End Sub

    Protected Sub clearAllExceptCustNo()
        Try
            txtAddress.Text = ""
            txtForenames.Text = ""
            txtPhoneNo.Text = ""
            txtSurname.Text = ""
            txtCity.Text = ""
            txtCurrEmployer.Text = ""
            txtEducationOther.Text = ""
            txtEmpAddress.Text = ""
            txtEmpCity.Text = ""
            txtEmpEmail.Text = ""
            txtEmpFax.Text = ""
            txtEmpHowLong.Text = ""
            txtEmpOtherIncome.Text = ""
            txtEmpPhone.Text = ""
            txtEmpPosition.Text = ""
            txtEmpSalary.Text = ""
            txtEmpSalaryNet.Text = ""
            txtHouseHowLong.Text = ""
            txtIDNo.Text = ""
            txtNationality.Text = ""
            txtNoChildren.Text = ""
            txtNoDependant.Text = ""
            txtPhoneNo.Text = ""
            txtPrevEmpAddress.Text = ""
            txtPrevEmpAnnualIncome.Text = ""
            txtPrevEmpCity.Text = ""
            txtPrevEmpEmail.Text = ""
            txtPrevEmpFax.Text = ""
            txtPrevEmpHowLong.Text = ""
            txtPrevEmployer.Text = ""
            txtPrevEmpPhone.Text = ""
            txtPrevEmpPosition.Text = ""
            txtPrevEmpSalary.Text = ""
            txtPrevEmpSalaryNet.Text = ""
            txtRent.Text = ""
            txtSpouse.Text = ""
            txtSpouseEmployer.Text = ""
            txtSpouseOccupation.Text = ""
            txtSpousePhone.Text = ""
            txtTradeRef1.Text = ""
            txtTradeRef2.Text = ""
            txtFinReqAmt.Text = ""
            txtFinReqIntRate.Text = ""
            txtFinReqPurpose.Text = ""
            txtFinReqSource.Text = ""
            txtFinReqTenor.Text = ""
            txtGuarCity.Text = ""
            txtGuarCurrAdd.Text = ""
            txtGuarCurrEmp.Text = ""
            txtGuarEmpAdd.Text = ""
            txtGuarEmpEmail.Text = ""
            txtGuarEmpFax.Text = ""
            txtGuarEmpIncome.Text = ""
            txtGuarEmpLength.Text = ""
            txtGuarEmpPhone.Text = ""
            txtGuarEmpPosition.Text = ""
            txtGuarEmpSalary.Text = ""
            txtGuarHomeLength.Text = ""
            txtGuarIDNo.Text = ""
            txtGuarMonthRent.Text = ""
            txtGuarName.Text = ""
            txtGuarNameRelative.Text = ""
            txtGuarPhone.Text = ""
            txtGuarRelAddress.Text = ""
            txtGuarRelCity.Text = ""
            txtGuarRelPhone.Text = ""
            txtGuarRelReltnship.Text = ""
            txtOtherAccNo.Text = ""
            txtOtherAmt.Text = ""
            txtOtherDesc.Text = ""
            txtQuesAgent.Text = ""
            txtQuesEmployee.Text = ""
            'txtMinDept.Text = ""
            'txtMinDeptNo.Text = ""
            txtECNo.Text = ""
            txtECNoCD.Text = ""
            txtAdminRate.Text = ""

            'lblSurname.Text = "Surname"
            'lblForenames.Text = "Forenames"
            'lblForenames.Visible = True
            txtForenames.Visible = True
            rdbClientType.ClearSelection()
            rdbSubIndividual.ClearSelection()
            rdbGender.ClearSelection()
            rdbHouse.ClearSelection()
            rdbGuarHomeType.ClearSelection()
            rdbQuesHow.ClearSelection()
            cmbEducation.ClearSelection()
            cmbMaritalStatus.ClearSelection()
            bdpDOB.Text = ""
            txtIssDate.Text = ""
            bdpGuarDOB.Text = ""
            bdpFinReqRepaymt.Text = ""
            cmbSector.ClearSelection()
            cmbProductType.ClearSelection()
            imgClientPhoto.ImageUrl = "~/ClientPhotos/nuetral.jpeg"
            ViewState("NextRole") = "0"
            ViewState("ReadyToDisburse") = "0"
            ViewState("NextStageName") = ""
            ViewState("StageName") = ""
        Catch ex As Exception
            WriteLogFile(ex.ToString)
        End Try
    End Sub

    Protected Sub clearGroup()
        rdbClientType.ClearSelection()
        txtCustNo.Text = ""
        txtGrpName.Text = ""
        txtGrpApplLineBus.Text = ""
        txtGrpApplPeriodBus.Text = ""
        txtGrpApplSrcIncome1.Text = ""
        txtGrpApplSrcIncome2.Text = ""
        txtGrpApplSrcIncome3.Text = ""
        txtGrpApplBorrow1.Text = ""
        txtGrpApplBorrow2.Text = ""
        txtGrpApplBorrow3.Text = ""
        txtGrpApplLoanAmt.Text = ""
        txtGrpApplRepayTenure.Text = ""
        txtGrpApplPurpose.Text = ""
        cmbGrpFinReqPurpose.ClearSelection()
        chkGrpApplSigned.Checked = False
    End Sub

    Protected Sub clientTypeVisible()
        If rdbClientType.SelectedItem.Text = "Individual" Then
            panGroup.Visible = False
            panIndividual.Visible = True
            pnlFarmers.Visible = False
        ElseIf rdbClientType.SelectedItem.Text = "Business" Or rdbClientType.SelectedItem.Text = "Group" Then
            panGroup.Visible = True
            panIndividual.Visible = False
            pnlFarmers.Visible = False
        ElseIf rdbClientType.SelectedItem.Text = "Farmer" Then
            panGroup.Visible = False
            panIndividual.Visible = False
            pnlFarmers.Visible = True
        End If
    End Sub

    Protected Sub cmbBank_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbBank.SelectedIndexChanged
        loadBankBranches(cmbBank.SelectedValue, cmbBankBranch)
    End Sub

    Protected Sub cmbBankAppType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbBankAppType.SelectedIndexChanged
        loadBranch(cmbBranchAppType, cmbBankAppType)
    End Sub

    Protected Sub cmbEducation_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbEducation.SelectedIndexChanged
        If cmbEducation.SelectedValue = "Other" Then
            txtEducationOther.Visible = True
        Else
            txtEducationOther.Visible = False
        End If
    End Sub

    Protected Sub cmbGrpProduct_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbGrpProduct.SelectedIndexChanged
        getProductDefaults(cmbGrpProduct.SelectedValue)
        getCreditParams(cmbGrpProduct.SelectedValue)
    End Sub

    Protected Sub ddlAssets_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlAssets.SelectedIndexChanged
        txtFinReqAmt.Text = ddlAssets.SelectedValue
    End Sub

    Protected Sub getAppDetails(ByVal loanID As String)
        Try
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd = New SqlCommand("select *,convert(varchar,DOB,106) as DOB1,convert(varchar,GUARANTOR_DOB,106) as GUARANTOR_DOB1,convert(varchar,ISSUE_DATE,106) as ISSUE_DATE1,convert(varchar,FIN_REPAY_DATE,106) as FIN_REPAY_DATE1,convert(varchar,APPL_DATE,106) as APPL_DATE1 from QUEST_APPLICATION where ID='" & loanID & "'", con)
                    Dim ds As New DataSet
                    Dim adp = New SqlDataAdapter(cmd)
                    adp.Fill(ds, "APP")
                    If ds.Tables(0).Rows.Count > 0 Then
                        Try
                            If ds.Tables(0).Rows(0).Item("STATUS") = "REJECTED" Then
                                ViewState("prevUser") = ds.Tables(0).Rows(0).Item("LAST_ID")
                            Else
                                ViewState("prevUser") = ds.Tables(0).Rows(0).Item("LAST_ID")
                            End If
                        Catch ex As Exception
                            ViewState("prevUser") = ""
                        End Try
                        txtCustNo.Text = ds.Tables(0).Rows(0).Item("CUSTOMER_NUMBER")
                        txtSurname.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("SURNAME"))
                        txtForenames.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("FORENAMES"))
                        lblBranchCode.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("BRANCH_CODE"))
                        lblBranchName.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("BRANCH_NAME"))
                        txtAddress.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("ADDRESS"))
                        'txtCreditLimit.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("CREDIT_LIMIT"))
                        txtPhoneNo.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("PHONE_NO"))
                        txtCity.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("CITY"))
                        txtCurrEmployer.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("CURR_EMPLOYER"))
                        txtEducationOther.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("EDUCATION"))
                        txtEmpAddress.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("CURR_EMP_ADD"))
                        txtEmpCity.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("CURR_EMP_CITY"))
                        txtEmpEmail.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("CURR_EMP_EMAIL"))
                        txtEmpFax.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("CURR_EMP_FAX"))
                        Try
                            txtEmpHowLong.Text = FormatNumber(BankString.isNullString(ds.Tables(0).Rows(0).Item("CURR_EMP_LENGTH")), 0)
                        Catch ex As Exception
                            txtEmpHowLong.Text = ""
                        End Try
                        Try
                            txtEmpOtherIncome.Text = FormatNumber(BankString.isNullString(ds.Tables(0).Rows(0).Item("CURR_EMP_INCOME")), 2)
                        Catch ex As Exception
                            txtEmpOtherIncome.Text = ""
                        End Try

                        txtEmpPhone.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("CURR_EMP_PHONE"))
                        txtEmpPosition.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("CURR_EMP_POSITION"))
                        Try
                            txtEmpSalary.Text = FormatNumber(BankString.isNullString(ds.Tables(0).Rows(0).Item("CURR_EMP_SALARY")), 2)
                        Catch ex As Exception
                            txtEmpSalary.Text = ""
                        End Try
                        Try
                            txtEmpSalaryNet.Text = FormatNumber(BankString.isNullString(ds.Tables(0).Rows(0).Item("CURR_EMP_NET")), 2)
                        Catch ex As Exception
                            txtEmpSalaryNet.Text = ""
                        End Try
                        Try
                            txtHouseHowLong.Text = FormatNumber(BankString.isNullString(ds.Tables(0).Rows(0).Item("HOME_LENGTH")), 0)
                        Catch ex As Exception
                            txtHouseHowLong.Text = ""
                        End Try
                        Try
                            txtApplicationDate.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("APPL_DATE1"))
                        Catch ex As Exception
                        End Try
                        Try
                            chkExtension.Checked = BankString.isNullString(ds.Tables(0).Rows(0).Item("Extension"))
                        Catch ex As Exception

                        End Try

                        txtIDNo.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("IDNO"))
                        txtNationality.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("NATIONALITY"))
                        txtNoChildren.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("NO_CHILDREN"))
                        txtNoDependant.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("NO_DEPENDANTS"))
                        txtPrevEmpAddress.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("PREV_EMP_ADD"))
                        Try
                            txtPrevEmpAnnualIncome.Text = FormatNumber(BankString.isNullString(ds.Tables(0).Rows(0).Item("PREV_EMP_INCOME")), 2)
                        Catch ex As Exception
                            txtPrevEmpAnnualIncome.Text = ""
                        End Try
                        Try
                            bdpFinReqRepaymt.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("FIN_REPAY_DATE1"))
                        Catch ex As Exception
                            bdpFinReqRepaymt.Text = ""
                        End Try

                        txtPrevEmpCity.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("PREV_EMP_CITY"))
                        txtPrevEmpEmail.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("PREV_EMP_EMAIL"))
                        txtPrevEmpFax.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("PREV_EMP_FAX"))
                        Try
                            txtPrevEmpHowLong.Text = FormatNumber(BankString.isNullString(ds.Tables(0).Rows(0).Item("PREV_EMP_LENGTH")), 0)
                        Catch ex As Exception
                            txtPrevEmpHowLong.Text = ""
                        End Try

                        txtPrevEmployer.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("PREV_EMPLOYER"))
                        txtPrevEmpPhone.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("PREV_EMP_PHONE"))
                        txtPrevEmpPosition.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("PREV_EMP_POSITION"))
                        Try
                            txtPrevEmpSalary.Text = FormatNumber(BankString.isNullString(ds.Tables(0).Rows(0).Item("PREV_EMP_SALARY")), 2)
                        Catch ex As Exception
                            txtPrevEmpSalary.Text = ""
                        End Try

                        Try
                            txtRent.Text = FormatNumber(BankString.isNullString(ds.Tables(0).Rows(0).Item("MONTHLY_RENT")), 2)
                        Catch ex As Exception
                            txtRent.Text = ""
                        End Try

                        txtSpouse.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("SPOUSE_NAME"))
                        txtSpouseEmployer.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("SPOUSE_EMPLOYER"))
                        txtSpouseOccupation.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("SPOUSE_OCCUPATION"))
                        txtSpousePhone.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("SPOUSE_PHONE"))
                        txtTradeRef1.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("TRADE_REF1"))
                        txtTradeRef2.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("TRADE_REF2"))
                        txtGuarCity.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("GUARANTOR_CITY"))
                        txtGuarCurrAdd.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("GUARANTOR_ADD"))
                        txtGuarCurrEmp.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("GUARANTOR_EMPLOYER"))
                        txtGuarEmpAdd.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("GUARANTOR_EMP_ADD"))
                        txtGuarEmpEmail.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("GUARANTOR_EMP_EMAIL"))
                        txtGuarEmpFax.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("GUARANTOR_EMP_FAX"))
                        Try
                            txtGuarEmpIncome.Text = FormatNumber(BankString.isNullString(ds.Tables(0).Rows(0).Item("GUARANTOR_EMP_INCOME")), 2)
                        Catch ex As Exception
                            txtGuarEmpIncome.Text = ""
                        End Try
                        Try
                            txtGuarEmpLength.Text = FormatNumber(BankString.isNullString(ds.Tables(0).Rows(0).Item("GUARANTOR_EMP_LENGTH")), 0)
                        Catch ex As Exception
                            txtGuarEmpLength.Text = ""
                        End Try

                        txtGuarEmpPhone.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("GUARANTOR_EMP_PHONE"))
                        txtGuarEmpPosition.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("GUARANTOR_EMP_POSTN"))
                        Try
                            txtGuarEmpSalary.Text = FormatNumber(BankString.isNullString(ds.Tables(0).Rows(0).Item("GUARANTOR_EMP_SALARY")), 2)
                        Catch ex As Exception
                            txtGuarEmpSalary.Text = ""
                        End Try
                        Try
                            txtGuarHomeLength.Text = FormatNumber(BankString.isNullString(ds.Tables(0).Rows(0).Item("GUARANTOR_HOME_LENGTH")), 0)
                        Catch ex As Exception
                            txtGuarHomeLength.Text = ""
                        End Try

                        txtGuarIDNo.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("GUARANTOR_IDNO"))
                        Try
                            txtGuarMonthRent.Text = FormatNumber(BankString.isNullString(ds.Tables(0).Rows(0).Item("GUARANTOR_RENT")), 2)
                        Catch ex As Exception
                            txtGuarMonthRent.Text = ""
                        End Try

                        txtGuarName.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("GUARANTOR_NAME"))
                        txtGuarNameRelative.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("GUARANTOR_REL_NAME"))
                        txtGuarPhone.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("GUARANTOR_PHONE"))
                        txtGuarRelAddress.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("GUARANTOR_REL_ADD"))
                        txtGuarRelCity.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("GUARANTOR_REL_CITY"))
                        txtGuarRelPhone.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("GUARANTOR_REL_PHONE"))
                        txtGuarRelReltnship.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("GUARANTOR_REL_RELTNSHP"))
                        Try
                            txtFinReqAmt.Text = FormatNumber(BankString.isNullString(ds.Tables(0).Rows(0).Item("AMT_APPLIED")), 2)
                        Catch ex As Exception
                            txtFinReqAmt.Text = ""
                        End Try
                        Try
                            txtFinReqIntRate.Text = FormatNumber(BankString.isNullString(ds.Tables(0).Rows(0).Item("FIN_INT_RATE")), 2)
                        Catch ex As Exception
                            txtFinReqIntRate.Text = ""
                        End Try

                        txtFinReqPurpose.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("FIN_PURPOSE"))
                        txtFinReqSource.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("FIN_SRC_REPAYMT"))
                        Try
                            txtFinReqTenor.Text = FormatNumber(BankString.isNullString(ds.Tables(0).Rows(0).Item("FIN_TENOR")), 0)
                        Catch ex As Exception
                            txtFinReqTenor.Text = ""
                        End Try

                        txtOtherAccNo.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("OTHER_ACCNO"))
                        Try
                            txtOtherAmt.Text = FormatNumber(BankString.isNullString(ds.Tables(0).Rows(0).Item("OTHER_AMT")), 2)
                        Catch ex As Exception
                            txtOtherAmt.Text = ""
                        End Try

                        txtOtherDesc.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("OTHER_DESC"))
                        txtQuesAgent.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("QUES_AGENT"))
                        txtQuesEmployee.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("QUES_EMPLOYEE"))

                        Try
                            txtAdminRate.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("ADMIN_RATE"))
                        Catch ex As Exception
                        End Try
                        Try
                            cmbProductType.SelectedValue = BankString.isNullString(ds.Tables(0).Rows(0).Item("FinProductType"))
                        Catch ex As Exception
                            cmbProductType.ClearSelection()
                        End Try
                        getProductDefaults(cmbProductType.SelectedValue)
                        getCreditParams(cmbProductType.SelectedValue)
                        Try
                            loadOtherLoans()
                        Catch ex As Exception
                        End Try

                        Try
                            cmbFinReqPurpose.SelectedValue = BankString.isNullString(ds.Tables(0).Rows(0).Item("FIN_PURPOSE"))
                        Catch ex As Exception
                            cmbFinReqPurpose.ClearSelection()
                        End Try
                        Try
                            txtRecAmt.Text = FormatNumber(BankString.isNullString(ds.Tables(0).Rows(0).Item("RECOMMENDED_AMT")), 2)
                        Catch ex As Exception
                            txtRecAmt.Text = ""
                        End Try
                        Try
                            cmbOwner.SelectedValue = BankString.isNullString(ds.Tables(0).Rows(0).Item("ClientOwner"))
                        Catch ex As Exception

                        End Try
                        'Try
                        '    rdbClientType.SelectedValue = ds.Tables(0).Rows(0).Item("CUSTOMER_TYPE_ID")
                        'Catch ex As Exception
                        '    rdbClientType.ClearSelection()
                        'End Try
                        Try
                            rdbClientType.SelectedValue = ds.Tables(0).Rows(0).Item("CUSTOMER_TYPE")
                        Catch ex As Exception
                            rdbClientType.ClearSelection()
                        End Try
                        Try
                            cmbEducation.SelectedValue = ds.Tables(0).Rows(0).Item("EDUCATION")
                        Catch ex As Exception
                            cmbEducation.ClearSelection()
                        End Try
                        Try
                            cmbMaritalStatus.SelectedValue = ds.Tables(0).Rows(0).Item("MARITAL_STATUS")
                        Catch ex As Exception
                            cmbMaritalStatus.ClearSelection()
                        End Try
                        Try
                            rdbGender.SelectedValue = ds.Tables(0).Rows(0).Item("GENDER")
                        Catch ex As Exception
                            rdbGender.ClearSelection()
                        End Try
                        Try
                            rdbHouse.SelectedValue = ds.Tables(0).Rows(0).Item("HOME_TYPE")
                        Catch ex As Exception
                            rdbHouse.ClearSelection()
                        End Try
                        Try
                            rdbGuarHomeType.SelectedValue = ds.Tables(0).Rows(0).Item("GUARANTOR_HOME_TYPE")
                        Catch ex As Exception
                            rdbGuarHomeType.ClearSelection()
                        End Try
                        Try
                            rdbQuesHow.SelectedValue = ds.Tables(0).Rows(0).Item("QUES_HOW")
                        Catch ex As Exception
                            rdbQuesHow.ClearSelection()
                        End Try

                        Try
                            bdpDOB.Text = ds.Tables(0).Rows(0).Item("DOB1")
                        Catch ex As Exception
                            bdpDOB.Text = ""
                        End Try
                        Try
                            txtIssDate.Text = ds.Tables(0).Rows(0).Item("ISSUE_DATE1")
                        Catch ex As Exception
                            txtIssDate.Text = ""
                        End Try
                        Try
                            bdpGuarDOB.Text = ds.Tables(0).Rows(0).Item("GUARANTOR_DOB1")
                        Catch ex As Exception
                            bdpGuarDOB.Text = ""
                        End Try

                        Try
                            cmbBank.SelectedValue = BankString.isNullString(ds.Tables(0).Rows(0).Item("Bank"))
                        Catch ex As Exception
                            cmbBank.ClearSelection()
                        End Try
                        loadBankBranches(cmbBank.SelectedValue, cmbBankBranch)
                        Try
                            cmbBankBranch.SelectedValue = BankString.isNullString(ds.Tables(0).Rows(0).Item("BankBranch"))
                        Catch ex As Exception
                            cmbBankBranch.ClearSelection()
                        End Try
                        txtBankAccountNo.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("BankAccountNo"))

                        Try
                            txtRepaymentInterval.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("RepaymentIntervalNum"))
                        Catch ex As Exception
                        End Try
                        Try
                            cmbRepaymentInterval.SelectedValue = BankString.isNullString(ds.Tables(0).Rows(0).Item("RepaymentIntervalUnit"))
                        Catch ex As Exception
                            cmbRepaymentInterval.ClearSelection()
                        End Try

                        If rdbClientType.SelectedItem.Text = "Individual" Then
                            Try
                                rdbSubIndividual.Visible = True
                                rdbSubIndividual.SelectedValue = ds.Tables(0).Rows(0).Item("SUB_INDIVIDUAL")
                            Catch ex As Exception

                            End Try
                            'lblSurname.Text = "Surname"
                            'lblForenames.Text = "Forenames"
                            'lblForenames.Visible = True
                            txtForenames.Visible = True
                            If ViewState("PrePopulateGuarantor") Then
                                getGuarantorInfo(txtCustNo.Text)
                            End If
                        ElseIf rdbClientType.SelectedItem.Text = "Business" Then
                            'lblSurname.Text = "Name"
                            'lblForenames.Visible = False
                            txtForenames.Visible = False
                            txtForenames.Text = ""
                        End If
                        If rdbSubIndividual.SelectedValue = "SSB" Then
                            'txtMinDept.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("MIN_DEPT"))
                            'txtMinDeptNo.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("MIN_DEPT_NO"))
                            txtECNo.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("ECNO"))
                            txtECNoCD.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("CD"))

                            'lblMinDept.Visible = True
                            'lblMinDeptNo.Visible = True
                            lblEmpCode.Visible = True
                            'txtMinDept.Visible = True
                            'txtMinDeptNo.Visible = True
                            txtECNo.Visible = True
                            txtECNoCD.Visible = True
                        End If
                        Try
                            cmbBankAppType.SelectedValue = BankString.isNullString(ds.Tables(0).Rows(0).Item("AppTypeBank"))
                        Catch ex As Exception
                            cmbBankAppType.ClearSelection()
                        End Try
                        loadBankBranches(cmbBankAppType.SelectedValue, cmbBranchAppType)
                        Try
                            cmbBranchAppType.SelectedValue = BankString.isNullString(ds.Tables(0).Rows(0).Item("AppTypeBranch"))
                        Catch ex As Exception
                            cmbBranchAppType.ClearSelection()
                        End Try
                        Try
                            cmbPDAAppType.SelectedValue = BankString.isNullString(ds.Tables(0).Rows(0).Item("PDACode"))
                        Catch ex As Exception
                            cmbPDAAppType.ClearSelection()
                        End Try
                        Try
                            txtOtherAppType.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("AppTypeOtherDesc"))
                        Catch ex As Exception
                            txtOtherAppType.Text = ""
                        End Try
                        txtECNo.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("ECNO"))
                        txtECNoCD.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("CD"))
                    Else
                    End If
                End Using
            End Using
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- getAppDetails()", ex.ToString)
        End Try
    End Sub

    Protected Sub getAppHistory()
        Try
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd = New SqlCommand("select COMMENT_DATE as [DATE], USERID as [USER],CONVERT(DECIMAL(30,2),[RECOMMENDED_AMT]) as [RECOMMENDED AMOUNT],COMMENT from REQUEST_HISTORY where LOANID='" & ViewState("globLoanID") & "'", con)
                    Dim ds As New DataSet
                    Using adp = New SqlDataAdapter(cmd)
                        adp.Fill(ds, "COMMENT")
                    End Using
                    If ds.Tables(0).Rows.Count > 0 Then
                        grdAppHistory.DataSource = ds.Tables(0)
                    Else
                        grdAppHistory.DataSource = Nothing
                    End If
                    grdAppHistory.DataBind()
                End Using
            End Using
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- getAppHistory()", ex.ToString)
        End Try
    End Sub

    Protected Sub getClientCollateral(custNo As String, lID As String)
        Try
            If lID = "" Or IsDBNull(lID) Then
                lID = "0"
            End If
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd As New SqlCommand("select id,CollateralType,CollDesc,format(CollValue,'c') as [Value] from ClientCollateral where CustNo='" & custNo & "' and (LoanID=0 or LoanID='" & lID & "')", con)
                    'Using cmd As New SqlCommand("select id,CollateralType,CollDesc,format(CollValue,'c') as [Value] from ClientCollateral where CustNo='" & custNo & "' and (LoanID=0)", con)
                    Dim dt As New DataTable
                    Using adp = New SqlDataAdapter(cmd)
                        adp.Fill(dt)
                    End Using
                    bindGrid(dt, grdCollateral)
                End Using
            End Using
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- getClientCollateral()", ex.ToString)
        End Try
    End Sub

    Protected Sub getCreditParams(prod As String)
        Try
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd As New SqlCommand("Select * FROM [CreditProducts] where [id]='" & prod & "'", con)
                    Dim adp = New SqlDataAdapter(cmd)
                    Dim ds As New DataSet
                    adp.Fill(ds, "CP")
                    If ds.Tables(0).Rows.Count > 0 Then
                        Dim dr = ds.Tables(0).Rows(0)
                        lblValInterest.Text = "Minimum interest rate: " & dr("MinIntRate") & "%.  Maximum interest rate: " & dr("MaxIntRate") & "%"
                        lblGrpValInterest.Text = "Minimum interest rate: " & dr("MinIntRate") & "%.  Maximum interest rate: " & dr("MaxIntRate") & "%"
                        ViewState("MinIntRate") = dr("MinIntRate")
                        ViewState("MaxIntRate") = dr("MaxIntRate")
                        hidMinInterest.Value = dr("MinIntRate")
                        hidMaxInterest.Value = dr("MaxIntRate")

                        Dim salLimit As Double = getSalaryBasedLimit(dr, IIf(IsNumeric(txtEmpSalary.Text), txtEmpSalary.Text, 0), IIf(IsNumeric(txtEmpSalaryNet.Text), txtEmpSalaryNet.Text, 0))
                        Dim maxLimit As Double = dr("MaxAmt")
                        If salLimit <> 0 Then
                            If salLimit < maxLimit Then
                                maxLimit = salLimit
                            ElseIf salLimit > maxLimit Then
                                maxLimit = maxLimit
                            End If
                        End If
                        'lblValAmount.Text = "Minimum loan amount: " & FormatCurrency(dr("MinAmt")) & ".  Maximum loan amount: " & FormatCurrency(dr("MaxAmt"))
                        lblValAmount.Text = "Minimum loan amount: " & FormatCurrency(dr("MinAmt")) & ".  Maximum loan amount: " & FormatCurrency(maxLimit)
                        'lblGrpValAmount.Text = "Minimum loan amount: " & FormatCurrency(dr("MinAmt")) & ".  Maximum loan amount: " & FormatCurrency(dr("MaxAmt"))
                        lblGrpValAmount.Text = "Minimum loan amount: " & FormatCurrency(dr("MinAmt")) & ".  Maximum loan amount: " & FormatCurrency(maxLimit)
                        ViewState("MinAmt") = dr("MinAmt")
                        ViewState("MaxAmt") = maxLimit ' dr("MaxAmt")
                        hidMinLoanAmount.Value = dr("MinAmt")
                        hidMaxLoanAmount.Value = maxLimit ' dr("MaxAmt")
                        hidGrpMinLoanAmount.Value = dr("MinAmt")
                        hidGrpMaxLoanAmount.Value = maxLimit ' dr("MaxAmt")
                        lblValTenure.Text = "Minimum loan tenure: " & FormatNumber(dr("MinimumTenure"), 0) & ".  Maximum loan tenure: " & FormatNumber(dr("MaximumTenure"), 0)
                        lblGrpValTenure.Text = "Minimum loan tenure: " & FormatNumber(dr("MinimumTenure"), 0) & ".  Maximum loan tenure: " & FormatNumber(dr("MaximumTenure"), 0)
                        ViewState("MinimumTenure") = dr("MinimumTenure")
                        ViewState("MaximumTenure") = dr("MaximumTenure")
                        hidMinTenure.Value = dr("MinimumTenure")
                        hidMaxTenure.Value = dr("MaximumTenure")

                    Else
                        lblValInterest.Text = ""
                        lblValAmount.Text = ""
                        lblValTenure.Text = ""
                        lblGrpValInterest.Text = ""
                        lblGrpValAmount.Text = ""
                        lblGrpValTenure.Text = ""
                    End If
                End Using
            End Using
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- getCreditParams()", ex.ToString)
        End Try
    End Sub

    Protected Sub getCurrentExposure(custNo As String)
        Try
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd As New SqlCommand("Select isnull(sum(Debit-Credit),0) as Exposure FROM [Accounts_Transactions] where [Account]='" & custNo & "' or [Other]='" & custNo & "'", con)
                    Dim adp = New SqlDataAdapter(cmd)
                    Dim ds As New DataSet
                    adp.Fill(ds, "CP")
                    If ds.Tables(0).Rows.Count > 0 Then
                        Dim dr = ds.Tables(0).Rows(0)
                        lblCurrExposure.Text = "Current Exposure: " & FormatCurrency(dr("Exposure"))
                        lblGrdCurrExposure.Text = "Current Exposure: " & FormatCurrency(dr("Exposure"))
                        ViewState("CurrentExposure") = dr("Exposure")
                        If CDbl(ViewState("MaxExposure")) < CDbl(ViewState("CurrentExposure")) Then
                            ClientScript.RegisterStartupScript(Me.GetType, "exposure", "<script type='text/javascript'>alert('Client has an exposure greater than the allowed maximum of " & FormatCurrency(ViewState("MaxExposure")) & "'); location.href = 'ApplicationForm.aspx'</script>")
                        Else
                            hidCurrentExposure.Value = dr("Exposure")
                            hidMaxExposure.Value = ViewState("MaxExposure")
                            hidGrpCurrentExposure.Value = dr("Exposure")
                            hidGrpMaxExposure.Value = ViewState("MaxExposure")
                        End If
                    Else
                        lblCurrExposure.Text = ""
                        lblGrdCurrExposure.Text = ""
                    End If
                End Using
            End Using
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- getCreditParams()", ex.ToString)
        End Try
    End Sub

    Protected Sub getGrpMemberExpenses()
        Try
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd = New SqlCommand("select ID,POSITION,NAME,IDNO,cast(RENT as numeric(18,2)) as RENT,cast(FOOD as numeric(18,2)) as FOOD,cast(FEES as numeric(18,2)) as FEES,cast(AIRTIME as numeric(18,2)) as AIRTIME,cast(MEDICAL as numeric(18,2)) as MEDICAL,cast(ELECTRICITY as numeric(18,2)) as ELECTRICITY,cast(WATER as numeric(18,2)) as WATER,cast(RATES as numeric(18,2)) as RATES,cast(CITY_OF_HRE as numeric(18,2)) as [CITY OF HARARE] from QUEST_GROUP_MEMBERS where CUSTOMER_NUMBER='" & txtCustNo.Text & "'", con)
                    Dim ds As New DataSet
                    Using adp = New SqlDataAdapter(cmd)
                        adp.Fill(ds, "QGM")
                    End Using
                    If ds.Tables(0).Rows.Count > 0 Then
                        grdGrpDeclExpense.DataSource = ds.Tables(0)
                    Else
                        grdGrpDeclExpense.DataSource = Nothing
                    End If
                    grdGrpDeclExpense.DataBind()
                End Using
            End Using
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub getGrpMembers()
        Try
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd = New SqlCommand("select ID,POSITION,NAME,IDNO from QUEST_GROUP_MEMBERS where CUSTOMER_NUMBER='" & txtCustNo.Text & "'", con)
                    Dim ds As New DataSet
                    Using adp = New SqlDataAdapter(cmd)
                        adp.Fill(ds, "QGM")
                    End Using
                    If ds.Tables(0).Rows.Count > 0 Then
                        grdGrpDeclMembers.DataSource = ds.Tables(0)
                    Else
                        grdGrpDeclMembers.DataSource = Nothing
                    End If
                    grdGrpDeclMembers.DataBind()
                End Using
            End Using
        Catch ex As Exception

        End Try
    End Sub

    Protected Function getGrpTotalAmt() As Double
        Try
            Dim totAmt = 0
            For Each member As RepeaterItem In repGrpMembers.Items
                Dim amt As String = CType(member.FindControl("txtGrpMemberAmt"), TextBox).Text
                If IsNumeric(amt) Then
                    totAmt = totAmt + amt
                End If
            Next
            Return totAmt
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Protected Sub getGuarantorInfo(accNo As String)
        Try
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd = New SqlCommand("select *,convert(varchar,GUARANTOR_DOB,106) as GUARANTOR_DOB1 from QUEST_APPLICATION where [CUSTOMER_NUMBER]='" & accNo & "' order by id desc", con)
                    Dim ds As New DataSet
                    Dim adp = New SqlDataAdapter(cmd)
                    adp.Fill(ds, "APP")
                    If ds.Tables(0).Rows.Count > 0 Then
                        divGuarAlert.Visible = True
                        txtGuarCity.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("GUARANTOR_CITY"))
                        txtGuarCurrAdd.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("GUARANTOR_ADD"))
                        txtGuarCurrEmp.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("GUARANTOR_EMPLOYER"))
                        txtGuarEmpAdd.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("GUARANTOR_EMP_ADD"))
                        txtGuarEmpEmail.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("GUARANTOR_EMP_EMAIL"))
                        txtGuarEmpFax.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("GUARANTOR_EMP_FAX"))
                        Try
                            txtGuarEmpIncome.Text = FormatNumber(BankString.isNullString(ds.Tables(0).Rows(0).Item("GUARANTOR_EMP_INCOME")), 2)
                        Catch ex As Exception
                            txtGuarEmpIncome.Text = ""
                        End Try
                        Try
                            txtGuarEmpLength.Text = FormatNumber(BankString.isNullString(ds.Tables(0).Rows(0).Item("GUARANTOR_EMP_LENGTH")), 0)
                        Catch ex As Exception
                            txtGuarEmpLength.Text = ""
                        End Try
                        txtGuarEmpPhone.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("GUARANTOR_EMP_PHONE"))
                        txtGuarEmpPosition.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("GUARANTOR_EMP_POSTN"))
                        Try
                            txtGuarEmpSalary.Text = FormatNumber(BankString.isNullString(ds.Tables(0).Rows(0).Item("GUARANTOR_EMP_SALARY")), 2)
                        Catch ex As Exception
                            txtGuarEmpSalary.Text = ""
                        End Try
                        Try
                            txtGuarHomeLength.Text = FormatNumber(BankString.isNullString(ds.Tables(0).Rows(0).Item("GUARANTOR_HOME_LENGTH")), 0)
                        Catch ex As Exception
                            txtGuarHomeLength.Text = ""
                        End Try
                        txtGuarIDNo.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("GUARANTOR_IDNO"))
                        Try
                            txtGuarMonthRent.Text = FormatNumber(BankString.isNullString(ds.Tables(0).Rows(0).Item("GUARANTOR_RENT")), 2)
                        Catch ex As Exception
                            txtGuarMonthRent.Text = ""
                        End Try
                        txtGuarName.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("GUARANTOR_NAME"))
                        txtGuarNameRelative.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("GUARANTOR_REL_NAME"))
                        txtGuarPhone.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("GUARANTOR_PHONE"))
                        txtGuarRelAddress.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("GUARANTOR_REL_ADD"))
                        txtGuarRelCity.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("GUARANTOR_REL_CITY"))
                        txtGuarRelPhone.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("GUARANTOR_REL_PHONE"))
                        txtGuarRelReltnship.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("GUARANTOR_REL_RELTNSHP"))
                        Try
                            rdbGuarHomeType.SelectedValue = ds.Tables(0).Rows(0).Item("GUARANTOR_HOME_TYPE")
                        Catch ex As Exception

                        End Try

                        bdpGuarDOB.Text = ds.Tables(0).Rows(0).Item("GUARANTOR_DOB1")
                    Else
                        divGuarAlert.Visible = False
                        txtGuarCity.Text = ""
                        txtGuarCurrAdd.Text = ""
                        txtGuarCurrEmp.Text = ""
                        txtGuarEmpAdd.Text = ""
                        txtGuarEmpEmail.Text = ""
                        txtGuarEmpFax.Text = ""
                        txtGuarEmpIncome.Text = ""
                        txtGuarEmpLength.Text = ""
                        txtGuarEmpPhone.Text = ""
                        txtGuarEmpPosition.Text = ""
                        txtGuarEmpSalary.Text = ""
                        txtGuarHomeLength.Text = ""
                        txtGuarIDNo.Text = ""
                        txtGuarMonthRent.Text = ""
                        txtGuarName.Text = ""
                        txtGuarNameRelative.Text = ""
                        txtGuarPhone.Text = ""
                        txtGuarRelAddress.Text = ""
                        txtGuarRelCity.Text = ""
                        txtGuarRelPhone.Text = ""
                        txtGuarRelReltnship.Text = ""
                    End If
                End Using
            End Using
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- getGuarantorInfo()", ex.ToString)
        End Try
    End Sub

    Protected Function getLastLoanID() As String
        Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
            Using cmd = New SqlCommand("select max(ID) from QUEST_APPLICATION", con)
                Dim loanID = ""
                If con.State = ConnectionState.Open Then
                    con.Close()
                End If
                Try
                    con.Open()
                    loanID = cmd.ExecuteScalar
                    con.Close()
                Catch ex As Exception
                    loanID = "0"
                End Try
                Return loanID
            End Using
        End Using
    End Function

    Protected Sub getNames(ByVal custID As String)
        Try
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd = New SqlCommand("select *,convert(varchar,DOB,106) as DOB1,convert(varchar,ISSUE_DATE,106) as ISSUE_DATE1 from CUSTOMER_DETAILS where CUSTOMER_NUMBER='" & custID & "'", con)
                    Dim ds As New DataSet
                    Dim adp = New SqlDataAdapter(cmd)
                    adp.Fill(ds, "CUSTOMER")
                    If ds.Tables(0).Rows.Count > 0 Then
                        getNamesDT(ds.Tables(0))
                    Else
                    End If
                End Using
            End Using
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- getNames()", ex.ToString)
        End Try
    End Sub

    Protected Sub getNamesDT(ByVal dtNames As DataTable)
        Try
            If dtNames.Rows.Count > 0 Then
                Dim dr As DataRow = dtNames.Rows(0)
                If dr.Item("Blacklisted") <> 1 Then
                    If dr.Item("CUSTOMER_TYPE") = "Individual" Then
                        panGroup.Visible = False
                        panIndividual.Visible = True
                        Try
                            If Trim(BankString.isNullString(dr.Item("PhotoName"))) <> "" Then
                                imgClientPhoto.ImageUrl = "~/ClientPhotos/" & BankString.isNullString(dr.Item("PhotoName")) & ".jpg"
                            Else
                                If BankString.isNullString(dr.Item("GENDER")) = "Male" Or BankString.isNullString(dr.Item("GENDER")) = "M" Then
                                    imgClientPhoto.ImageUrl = "~/ClientPhotos/male-profile.png"
                                Else
                                    imgClientPhoto.ImageUrl = "~/ClientPhotos/female-profile.jpg"
                                End If
                            End If
                        Catch ex As Exception

                        End Try
                        txtCustNo.Text = BankString.isNullString(dr.Item("CUSTOMER_NUMBER"))
                        txtSurname.Text = BankString.isNullString(dr.Item("SURNAME"))
                        txtForenames.Text = BankString.isNullString(dr.Item("FORENAMES"))
                        txtAddress.Text = BankString.isNullString(dr.Item("ADDRESS"))
                        txtPhoneNo.Text = BankString.isNullString(dr.Item("PHONE_NO"))
                        txtCity.Text = BankString.isNullString(dr.Item("CITY"))
                        txtCurrEmployer.Text = BankString.isNullString(dr.Item("CURR_EMPLOYER"))
                        txtEducationOther.Text = BankString.isNullString(dr.Item("EDUCATION"))
                        txtEmpAddress.Text = BankString.isNullString(dr.Item("CURR_EMP_ADD"))
                        txtEmpCity.Text = BankString.isNullString(dr.Item("CURR_EMP_CITY"))
                        txtEmpEmail.Text = BankString.isNullString(dr.Item("CURR_EMP_EMAIL"))
                        txtEmpFax.Text = BankString.isNullString(dr.Item("CURR_EMP_FAX"))
                        Try
                            txtEmpHowLong.Text = FormatNumber(dr.Item("CURR_EMP_LENGTH"), 0)
                        Catch ex As Exception
                            txtEmpHowLong.Text = ""
                        End Try

                        Try
                            txtEmpOtherIncome.Text = FormatNumber(dr.Item("CURR_EMP_INCOME"), 2)
                        Catch ex As Exception
                            txtEmpOtherIncome.Text = ""
                        End Try

                        txtEmpPhone.Text = BankString.isNullString(dr.Item("CURR_EMP_PHONE"))
                        txtEmpPosition.Text = BankString.isNullString(dr.Item("CURR_EMP_POSITION"))
                        Try
                            txtEmpSalary.Text = FormatNumber(dr.Item("CURR_EMP_SALARY"), 2)
                        Catch ex As Exception
                            txtEmpSalary.Text = ""
                        End Try

                        Try
                            txtEmpSalaryNet.Text = FormatNumber(dr.Item("CURR_EMP_NET"), 2)
                        Catch ex As Exception
                            txtEmpSalaryNet.Text = ""
                        End Try

                        Try
                            txtHouseHowLong.Text = FormatNumber(dr.Item("HOME_LENGTH"), 0)
                        Catch ex As Exception
                            txtHouseHowLong.Text = ""
                        End Try

                        txtIDNo.Text = BankString.isNullString(dr.Item("IDNO"))
                        txtNationality.Text = BankString.isNullString(dr.Item("NATIONALITY"))
                        txtNoChildren.Text = BankString.isNullString(dr.Item("NO_CHILDREN"))
                        txtNoDependant.Text = BankString.isNullString(dr.Item("NO_DEPENDANTS"))
                        txtPrevEmpAddress.Text = BankString.isNullString(dr.Item("PREV_EMP_ADD"))
                        Try
                            txtPrevEmpAnnualIncome.Text = FormatNumber(BankString.isNullString(dr.Item("PREV_EMP_INCOME")), 2)
                        Catch ex As Exception
                            txtPrevEmpAnnualIncome.Text = ""
                        End Try

                        txtPrevEmpCity.Text = BankString.isNullString(dr.Item("PREV_EMP_CITY"))
                        txtPrevEmpEmail.Text = BankString.isNullString(dr.Item("PREV_EMP_EMAIL"))
                        txtPrevEmpFax.Text = BankString.isNullString(dr.Item("PREV_EMP_FAX"))
                        Try
                            txtPrevEmpHowLong.Text = FormatNumber(BankString.isNullString(dr.Item("PREV_EMP_LENGTH")), 0)
                        Catch ex As Exception
                            txtPrevEmpHowLong.Text = ""
                        End Try

                        txtPrevEmployer.Text = BankString.isNullString(dr.Item("PREV_EMPLOYER"))
                        txtPrevEmpPhone.Text = BankString.isNullString(dr.Item("PREV_EMP_PHONE"))
                        txtPrevEmpPosition.Text = BankString.isNullString(dr.Item("PREV_EMP_POSITION"))
                        Try
                            txtPrevEmpSalary.Text = FormatNumber(BankString.isNullString(dr.Item("PREV_EMP_SALARY")), 2)
                        Catch ex As Exception
                            txtPrevEmpSalary.Text = ""
                        End Try

                        Try
                            txtPrevEmpSalaryNet.Text = FormatNumber(BankString.isNullString(dr.Item("PREV_EMP_NET")), 2)
                        Catch ex As Exception
                            txtPrevEmpSalaryNet.Text = ""
                        End Try

                        Try
                            txtRent.Text = FormatNumber(BankString.isNullString(dr.Item("MONTHLY_RENT")), 2)
                        Catch ex As Exception
                            txtRent.Text = ""
                        End Try
                        txtSpouse.Text = BankString.isNullString(dr.Item("SPOUSE_NAME"))
                        txtSpouseEmployer.Text = BankString.isNullString(dr.Item("SPOUSE_EMPLOYER"))
                        txtSpouseOccupation.Text = BankString.isNullString(dr.Item("SPOUSE_OCCUPATION"))
                        txtSpousePhone.Text = BankString.isNullString(dr.Item("SPOUSE_PHONE"))
                        txtTradeRef1.Text = BankString.isNullString(dr.Item("TRADE_REF1"))
                        txtTradeRef2.Text = BankString.isNullString(dr.Item("TRADE_REF2"))
                        Try
                            rdbSubIndividual.SelectedValue = dr.Item("SUB_INDIVIDUAL")
                        Catch ex As Exception
                            rdbSubIndividual.ClearSelection()
                        End Try
                        rdbSubIndividual_SelectedIndexChanged(New Object, New EventArgs)
                        txtECNo.Text = BankString.isNullString(dr.Item("ECNO"))
                        txtECNoCD.Text = BankString.isNullString(dr.Item("CD"))

                        Try
                            cmbBankAppType.SelectedValue = BankString.isNullString(dr.Item("AppTypeBank"))
                        Catch ex As Exception
                            cmbBankAppType.ClearSelection()
                        End Try
                        Try
                            cmbBranchAppType.SelectedValue = BankString.isNullString(dr.Item("AppTypeBranch"))
                        Catch ex As Exception
                            cmbBranchAppType.ClearSelection()
                        End Try
                        Try
                            cmbPDAAppType.SelectedValue = BankString.isNullString(dr.Item("PDACode"))
                        Catch ex As Exception
                            cmbPDAAppType.ClearSelection()
                        End Try
                        Try
                            txtOtherAppType.Text = BankString.isNullString(dr.Item("AppTypeOtherDesc"))
                        Catch ex As Exception
                            txtOtherAppType.Text = ""
                        End Try

                        Try
                            rdbClientType.SelectedValue = BankString.isNullString(dr.Item("CUSTOMER_TYPE_ID"))
                        Catch ex As Exception
                            rdbClientType.ClearSelection()
                        End Try
                        Try
                            rdbGender.SelectedValue = BankString.isNullString(dr.Item("GENDER"))
                        Catch ex As Exception
                            rdbGender.ClearSelection()
                        End Try
                        Try
                            rdbHouse.SelectedValue = BankString.isNullString(dr.Item("HOME_TYPE"))
                        Catch ex As Exception
                            rdbHouse.ClearSelection()
                        End Try
                        Try
                            cmbEducation.SelectedValue = BankString.isNullString(dr.Item("EDUCATION"))
                        Catch ex As Exception
                            cmbEducation.ClearSelection()
                        End Try
                        Try
                            cmbMaritalStatus.SelectedValue = BankString.isNullString(dr.Item("MARITAL_STATUS"))
                        Catch ex As Exception
                            cmbMaritalStatus.ClearSelection()
                        End Try
                        Try
                            cmbSector.SelectedValue = BankString.isNullString(dr.Item("Sector"))
                        Catch ex As Exception
                            cmbSector.ClearSelection()
                        End Try
                        If BankString.isNullString(dr.Item("DOB1")) = "01 Jan 1900" Then
                            bdpDOB.Text = ""
                        Else
                            bdpDOB.Text = BankString.isNullString(dr.Item("DOB1"))
                        End If
                        If BankString.isNullString(dr.Item("ISSUE_DATE1")) = "01 Jan 1900" Then
                            txtIssDate.Text = ""
                        Else
                            txtIssDate.Text = BankString.isNullString(dr.Item("ISSUE_DATE1"))
                        End If
                        Try
                            cmbArea.SelectedValue = BankString.isNullString(dr.Item("AREA"))
                        Catch ex As Exception
                            cmbArea.ClearSelection()
                        End Try
                        Try
                            cmbBank.SelectedValue = BankString.isNullString(dr.Item("Bank"))
                        Catch ex As Exception
                            cmbBank.ClearSelection()
                        End Try
                        loadBankBranches(cmbBank.SelectedValue, cmbBankBranch)
                        Try
                            cmbBankBranch.SelectedValue = BankString.isNullString(dr.Item("BankBranch"))
                        Catch ex As Exception
                            cmbBankBranch.ClearSelection()
                        End Try
                        txtBankAccountNo.Text = BankString.isNullString(dr.Item("BankAccountNo"))

                        If rdbClientType.SelectedItem.Text = "Individual" Then
                            'lblSurname.Text = "Surname"
                            'lblForenames.Text = "Forenames"
                            'lblForenames.Visible = True
                            txtForenames.Visible = True
                            If ViewState("PrePopulateGuarantor") Then
                                getGuarantorInfo(txtCustNo.Text)
                            End If
                        ElseIf rdbClientType.SelectedItem.Text = "Business" Then
                            'lblSurname.Text = "Name"
                            'lblForenames.Visible = False
                            txtForenames.Visible = False
                            txtForenames.Text = ""
                        End If
                    ElseIf dr.Item("CUSTOMER_TYPE") = "Group" Or dr.Item("CUSTOMER_TYPE") = "Corporate" Then
                        panGroup.Visible = True
                        panIndividual.Visible = False
                        txtCustNo.Text = BankString.isNullString(dr.Item("CUSTOMER_NUMBER"))
                        txtGrpName.Text = BankString.isNullString(dr.Item("SURNAME"))
                        getGrpMembers()
                        getGrpMemberExpenses()
                        rdbClientType.SelectedValue = dr.Item("CUSTOMER_TYPE_ID")
                    End If
                Else
                    notify("This client has been blacklisted", "error")
                End If

                getOtherLoans()
            Else
            End If
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- getNamesDT()", ex.ToString)
        End Try
    End Sub

    Protected Sub getNamesGroup(ByVal custID As String)
        Try
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd = New SqlCommand("select *,convert(varchar,DOB,106) as DOB1,convert(varchar,ISSUE_DATE,106) as ISSUE_DATE1 from CUSTOMER_DETAILS where CUSTOMER_NUMBER='" & custID & "'", con)
                    Dim ds As New DataSet
                    Dim adp = New SqlDataAdapter(cmd)
                    adp.Fill(ds, "CUSTOMER")
                    If ds.Tables(0).Rows.Count > 0 Then
                        txtCustNo.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("CUSTOMER_NUMBER"))
                        txtSurname.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("SURNAME"))
                        txtForenames.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("FORENAMES"))
                        txtAddress.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("ADDRESS"))
                        txtPhoneNo.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("PHONE_NO"))
                        txtCity.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("CITY"))
                        txtCurrEmployer.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("CURR_EMPLOYER"))
                        txtEducationOther.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("EDUCATION"))
                        txtEmpAddress.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("CURR_EMP_ADD"))
                        txtEmpCity.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("CURR_EMP_CITY"))
                        txtEmpEmail.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("CURR_EMP_EMAIL"))
                        txtEmpFax.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("CURR_EMP_FAX"))
                        txtEmpHowLong.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("CURR_EMP_LENGTH"))
                        txtEmpOtherIncome.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("CURR_EMP_INCOME"))
                        txtEmpPhone.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("CURR_EMP_PHONE"))
                        txtEmpPosition.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("CURR_EMP_POSITION"))
                        txtEmpSalary.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("CURR_EMP_SALARY"))
                        txtHouseHowLong.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("HOME_LENGTH"))
                        txtIDNo.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("IDNO"))
                        txtNationality.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("NATIONALITY"))
                        txtNoChildren.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("NO_CHILDREN"))
                        txtNoDependant.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("NO_DEPENDANTS"))
                        txtPrevEmpAddress.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("PREV_EMP_ADD"))
                        txtPrevEmpAnnualIncome.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("PREV_EMP_INCOME"))
                        txtPrevEmpCity.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("PREV_EMP_CITY"))
                        txtPrevEmpEmail.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("PREV_EMP_EMAIL"))
                        txtPrevEmpFax.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("PREV_EMP_FAX"))
                        txtPrevEmpHowLong.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("PREV_EMP_LENGTH"))
                        txtPrevEmployer.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("PREV_EMPLOYER"))
                        txtPrevEmpPhone.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("PREV_EMP_PHONE"))
                        txtPrevEmpPosition.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("PREV_EMP_POSITION"))
                        txtPrevEmpSalary.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("PREV_EMP_SALARY"))
                        txtRent.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("MONTHLY_RENT"))
                        txtSpouse.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("SPOUSE_NAME"))
                        txtSpouseEmployer.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("SPOUSE_EMPLOYER"))
                        txtSpouseOccupation.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("SPOUSE_OCCUPATION"))
                        txtSpousePhone.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("SPOUSE_PHONE"))
                        txtTradeRef1.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("TRADE_REF1"))
                        txtTradeRef2.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("TRADE_REF2"))

                        rdbClientType.SelectedValue = BankString.isNullString(ds.Tables(0).Rows(0).Item("CUSTOMER_TYPE_ID"))
                        rdbGender.SelectedValue = BankString.isNullString(ds.Tables(0).Rows(0).Item("GENDER"))
                        rdbHouse.SelectedValue = BankString.isNullString(ds.Tables(0).Rows(0).Item("HOME_TYPE"))
                        cmbEducation.SelectedValue = BankString.isNullString(ds.Tables(0).Rows(0).Item("EDUCATION"))
                        cmbMaritalStatus.SelectedValue = BankString.isNullString(ds.Tables(0).Rows(0).Item("MARITAL_STATUS"))

                        bdpDOB.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("DOB1"))
                        txtIssDate.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("ISSUE_DATE1"))
                        If rdbClientType.SelectedItem.Text = "Individual" Then
                            'lblSurname.Text = "Surname"
                            'lblForenames.Text = "Forenames"
                            'lblForenames.Visible = True
                            txtForenames.Visible = True
                        ElseIf rdbClientType.SelectedItem.Text = "Business" Then
                            'lblSurname.Text = "Name"
                            'lblForenames.Visible = False
                            txtForenames.Visible = False
                            txtForenames.Text = ""
                        End If
                    Else
                    End If
                End Using
            End Using
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- getNamesGroup()", ex.ToString)
        End Try
    End Sub

    Protected Sub getNextApproval(currLevel As Integer)
        Try
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd = New SqlCommand("select * from [ParaApprovalStages] where [StageOrder]='" & currLevel & "'", con)
                    Dim ds As New DataSet
                    Dim adp = New SqlDataAdapter(cmd)
                    adp.Fill(ds, "PAS")
                    If ds.Tables(0).Rows.Count > 0 Then
                        Dim dr = ds.Tables(0).Rows(0)
                        ViewState("StageName") = dr("StageName")
                    End If
                End Using
                Using cmd = New SqlCommand("select * from [ParaApprovalStages] where [StageOrder]='" & currLevel + 1 & "'", con)
                    Dim ds As New DataSet
                    Dim adp = New SqlDataAdapter(cmd)
                    adp.Fill(ds, "PAS")
                    If ds.Tables(0).Rows.Count > 0 Then
                        Dim dr = ds.Tables(0).Rows(0)
                        ViewState("NextRole") = dr("RoleId")
                        ViewState("NextStageName") = dr("StageName")
                        If dr("StageAction") = "Disbursement" Then
                            ViewState("ReadyToDisburse") = "1"
                        Else
                            ViewState("ReadyToDisburse") = "0"
                        End If
                    Else
                        ViewState("NextRole") = "0"
                        ViewState("ReadyToDisburse") = "0"
                        ViewState("NextStageName") = ""
                    End If
                End Using
            End Using
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- getNextApproval()", ex.ToString)
        End Try
    End Sub

    Protected Sub getOtherLoans()
        Try
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd = New SqlCommand("select ID,OTHER_DESC,OTHER_ACCNO,cast(OTHER_AMT as numeric(20,2)) as OTHER_AMT from QUEST_OTHER_LOANS where CUSTOMER_NUMBER='" & txtCustNo.Text & "'", con)
                    Dim ds As New DataSet
                    Using adp = New SqlDataAdapter(cmd)
                        adp.Fill(ds, "Other")
                    End Using
                    If ds.Tables(0).Rows.Count > 0 Then
                        grdOtherLoan.DataSource = ds.Tables(0)
                    Else
                        grdOtherLoan.DataSource = Nothing
                    End If
                    grdOtherLoan.DataBind()
                End Using
            End Using
        Catch ex As Exception

        End Try
    End Sub

    Protected Function getOutstandingLoans(custNo As String) As Integer
        Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
            Using cmd = New SqlCommand("select ISNULL(count(ID), 0) as numLoan from QUEST_APPLICATION where (STATUS<>'REPAID') and CUSTOMER_NUMBER='" & custNo & "' and DISBURSED=1", con)
                Dim outs As Integer = 0
                If con.State = ConnectionState.Open Then
                    con.Close()
                End If
                con.Open()
                outs = cmd.ExecuteScalar
                con.Close()
                Return outs
            End Using
            Using cmd = New SqlCommand("select ISNULL(count(ID), 0) as numLoan from QUEST_APPLICATION where (STATUS='REPAID') and CUSTOMER_NUMBER='" & custNo & "' and DISBURSED=1", con)
                Dim outs As Integer = 0
                If con.State = ConnectionState.Open Then
                    con.Close()
                End If
                con.Open()
                outs = cmd.ExecuteScalar
                lblLoanCycle.Text = outs
                con.Close()
                Return outs
            End Using
        End Using
    End Function

    Protected Sub getPDACompanies()
        Try
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd = New SqlCommand("select * from para_pda", con)
                    Dim ds As New DataSet
                    Dim adp = New SqlDataAdapter(cmd)
                    adp.Fill(ds, "PDA")
                    loadCombo(ds.Tables(0), cmbPDAAppType, "PDAName", "PDACode")
                End Using
            End Using
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- getPDACompanies()", ex.ToString)
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
                        'rvFinReqAmt.MinimumValue = FormatNumber(dr("MinAmt"), 0).ToString.Replace(",", "")
                        'rvFinReqAmt.MaximumValue = FormatNumber(dr("MaxAmt"), 0).ToString.Replace(",", "")
                        'rvFinReqIntRate.MinimumValue = FormatNumber(dr("MinIntRate"), 2).ToString.Replace(",", "")
                        'rvFinReqIntRate.MaximumValue = FormatNumber(dr("MaxIntRate"), 2).ToString.Replace(",", "")
                        Try
                            txtFinReqIntRate.Text = dr("DefaultIntRate")
                            txtGrpApplInterest.Text = dr("DefaultIntRate")
                        Catch ex As Exception
                            txtFinReqIntRate.Text = ""
                            txtGrpApplInterest.Text = ""
                        End Try
                        Try
                            If dr("ProductFees") = "None" Then
                                lblAdminRate.Visible = False
                                txtAdminRate.Text = "0"
                                txtAdminRate.Visible = False
                                lblGrpAdminRate.Visible = False
                                txtGrpAdminRate.Text = "0"
                                txtGrpAdminRate.Visible = False
                            Else
                                lblAdminRate.Visible = True
                                txtAdminRate.Visible = True
                                lblGrpAdminRate.Visible = True
                                txtGrpAdminRate.Visible = True
                                Try
                                    lblAdminRate.Text = IIf(dr("ProductFeeCalc") = "Percentage", "Application Fees (%)", "Application Fees ($)")
                                    lblGrpAdminRate.Text = IIf(dr("ProductFeeCalc") = "Percentage", "Application Fees (%)", "Application Fees ($)")
                                Catch ex As Exception

                                End Try
                                Try
                                    txtAdminRate.Text = dr("ProductFeeAmtPerc")
                                    txtGrpAdminRate.Text = dr("ProductFeeAmtPerc")
                                Catch ex As Exception
                                    txtAdminRate.Text = ""
                                    txtGrpAdminRate.Text = ""
                                End Try
                            End If
                        Catch ex As Exception

                        End Try
                        Try
                            If dr("DefaultIntInterval") = "Daily" Then
                                lblInterestRate.Text = "Interest Rate (% per day)"
                                lblGrpInterestRate.Text = "Interest Rate (% per day)"
                            ElseIf dr("DefaultIntInterval") = "Weekly" Then
                                lblInterestRate.Text = "Interest Rate (% per week)"
                                lblGrpInterestRate.Text = "Interest Rate (% per week)"
                            ElseIf dr("DefaultIntInterval") = "Monthly" Then
                                lblInterestRate.Text = "Interest Rate (% per month)"
                                lblGrpInterestRate.Text = "Interest Rate (% per month)"
                            ElseIf dr("DefaultIntInterval") = "Annual" Then
                                lblInterestRate.Text = "Interest Rate (% per annum)"
                                lblGrpInterestRate.Text = "Interest Rate (% per annum)"
                            ElseIf dr("DefaultIntInterval") = "Duration" Then
                                lblInterestRate.Text = "Interest Rate (%)"
                                lblGrpInterestRate.Text = "Interest Rate (%)"
                            Else
                                lblInterestRate.Text = "Interest Rate (%)"
                                lblGrpInterestRate.Text = "Interest Rate (%)"
                            End If
                        Catch ex As Exception

                        End Try
                        Try
                            txtRepaymentInterval.Text = dr("RepaymentIntervalNum")
                            txtGrpRepaymentInterval.Text = dr("RepaymentIntervalNum")
                        Catch ex As Exception
                            txtRepaymentInterval.Text = ""
                            txtGrpRepaymentInterval.Text = ""
                        End Try

                        Try
                            cmbRepaymentInterval.SelectedValue = dr("RepaymentIntervalUnit")
                            cmbGrpRepaymentInterval.SelectedValue = dr("RepaymentIntervalUnit")
                        Catch ex As Exception
                            cmbRepaymentInterval.ClearSelection()
                            cmbGrpRepaymentInterval.ClearSelection()
                        End Try
                        Try
                            txtFinReqTenor.Text = FormatNumber(dr("DefaultTenure"), 0)
                            txtGrpApplRepayTenure.Text = FormatNumber(dr("DefaultTenure"), 0)
                        Catch ex As Exception
                            txtFinReqTenor.Text = ""
                            txtGrpApplRepayTenure.Text = ""
                        End Try
                    End If
                End Using
            End Using
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- getProductDefaults()", ex.ToString)
        End Try
    End Sub

    Protected Sub grdDocuments_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles grdDocuments.RowCommand
        If e.CommandName = "Select" Then
            Dim docID = e.CommandArgument
            Dim strscript As String

            strscript = "<script language=JavaScript>"
            strscript += "window.open('viewDocument.aspx?id=" & docID & "');"
            strscript += "</script>"
            ClientScript.RegisterStartupScript(Me.GetType(), "newwin", strscript)
        End If
    End Sub

    Protected Sub grdDocuments_RowDeleting(sender As Object, e As GridViewDeleteEventArgs) Handles grdDocuments.RowDeleting
        Try
            Dim docUploadEditID = DirectCast(grdDocuments.Rows(e.RowIndex).FindControl("txtDocId"), TextBox).Text
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd = New SqlCommand("delete from QUEST_DOCUMENTS where ID='" & docUploadEditID & "'", con)
                    If con.State = ConnectionState.Open Then
                        con.Close()
                    End If
                    con.Open()
                    If cmd.ExecuteNonQuery Then
                        notify("File has been deleted", "success")
                    Else
                        notify("Error deleting file", "error")
                    End If
                    con.Close()
                    loadUploadedFiles(txtCustNo.Text)
                End Using
            End Using
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- grdDocuments_RowDeleting()", ex.ToString)
        End Try
    End Sub
    Protected Sub grdGrpDeclExpense_RowCancelingEdit(sender As Object, e As GridViewCancelEditEventArgs) Handles grdGrpDeclExpense.RowCancelingEdit

    End Sub

    Protected Sub grdGrpDeclExpense_RowDeleting(sender As Object, e As GridViewDeleteEventArgs) Handles grdGrpDeclExpense.RowDeleting

    End Sub

    Protected Sub grdGrpDeclExpense_RowEditing(sender As Object, e As GridViewEditEventArgs) Handles grdGrpDeclExpense.RowEditing

    End Sub

    Protected Sub grdGrpDeclExpense_RowUpdating(sender As Object, e As GridViewUpdateEventArgs) Handles grdGrpDeclExpense.RowUpdating

    End Sub

    Protected Sub grdOtherLoan_RowCancelingEdit(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles grdOtherLoan.RowCancelingEdit
        grdOtherLoan.EditIndex = -1
        getOtherLoans()
    End Sub

    Protected Sub grdOtherLoan_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles grdOtherLoan.RowDeleting
        Try
            ViewState("otherEditID") = DirectCast(grdOtherLoan.Rows(e.RowIndex).FindControl("txtOtherId"), TextBox).Text
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd = New SqlCommand("delete from QUEST_OTHER_LOANS where ID='" & ViewState("otherEditID") & "'", con)
                    If con.State = ConnectionState.Open Then
                        con.Close()
                    End If
                    con.Open()
                    If cmd.ExecuteNonQuery Then
                        notify("Loan successfully deleted", "success")
                    Else
                        notify("Error deleting loan", "error")
                    End If
                    con.Close()
                    getOtherLoans()
                End Using
            End Using
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- grdOtherLoan_RowDeleting()", ex.ToString)
        End Try
    End Sub

    Protected Sub grdOtherLoan_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles grdOtherLoan.RowEditing
        ViewState("otherEditID") = DirectCast(grdOtherLoan.Rows(e.NewEditIndex).FindControl("txtOtherId"), TextBox).Text
        grdOtherLoan.EditIndex = e.NewEditIndex
        getOtherLoans()
    End Sub

    Protected Sub grdOtherLoan_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles grdOtherLoan.RowUpdating
        Try
            If Trim(ViewState("otherEditID")) = "" Or IsDBNull(ViewState("otherEditID")) Then
                notify("No loan selected for update", "error")
                Exit Sub
            End If
            Dim othDesc As String = DirectCast(grdOtherLoan.Rows(e.RowIndex).FindControl("txtDescEdit"), TextBox).Text
            Dim othAccNo As String = DirectCast(grdOtherLoan.Rows(e.RowIndex).FindControl("txtAccNoEdit"), TextBox).Text
            Dim othAmt As String = DirectCast(grdOtherLoan.Rows(e.RowIndex).FindControl("txtAmtEdit"), TextBox).Text
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd = New SqlCommand("update QUEST_OTHER_LOANS set OTHER_DESC='" & BankString.removeSpecialCharacter(othDesc) & "',OTHER_ACCNO='" & othAccNo & "',OTHER_AMT='" & othAmt & "' where ID='" & ViewState("otherEditID") & "'", con)
                    If con.State = ConnectionState.Open Then
                        con.Close()
                    End If
                    con.Open()
                    If cmd.ExecuteNonQuery Then
                        notify("Loan successfully updated", "success")
                    Else
                        notify("Error updating loan", "error")
                    End If
                    con.Close()
                    grdOtherLoan.EditIndex = -1
                    getOtherLoans()
                End Using
            End Using
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- grdOtherLoan_RowUpdating()", ex.ToString)
        End Try
    End Sub

    Protected Function internalControlsSaved() As Boolean
        Try
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd = New SqlCommand("select * from ParaInternalControls", con)
                    Dim ds As New DataSet
                    Dim adp = New SqlDataAdapter(cmd)
                    adp.Fill(ds, "PAS")
                    If ds.Tables(0).Rows.Count > 0 Then
                        Dim dr = ds.Tables(0).Rows(0)
                        ViewState("MaxExposure") = dr("MaxExposure")
                        ViewState("MaxNoLoans") = dr("MaxNoLoans")
                        ViewState("PrePopulateGuarantor") = dr("PrePopulateGuarantor")
                        Return True
                    Else
                        notify("You must first save Internal Controls before proceeding", "error")
                        Return False
                    End If
                End Using
            End Using
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- internalControlsSaved()", ex.ToString)
            notify("You must first save Internal Controls before proceeding", "error")
            Return False
        End Try
    End Function

    Protected Function isGroupNotActivated(custNo As String) As Boolean
        Try
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd = New SqlCommand("select ID from customer_details where customer_number='" & custNo & "' and customer_type='Group' and ([ACTIVATED]=0 or [ACTIVATED] is null)", con)
                    Dim dt As New DataTable
                    Using adp = New SqlDataAdapter(cmd)
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
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- isGroupNotActivated()", ex.ToString)
            Return False
        End Try
    End Function

    Protected Function isValidCustID(custID As String) As Boolean
        Try
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd = New SqlCommand("select ID from CUSTOMER_DETAILS where CUSTOMER_NUMBER='" & custID & "'", con)
                    Dim ds As New DataSet
                    Using adp = New SqlDataAdapter(cmd)
                        adp.Fill(ds, "CD")
                    End Using
                    If ds.Tables(0).Rows.Count > 0 Then
                        Return True
                    Else
                        Return False
                    End If
                End Using
            End Using
        Catch ex As Exception
            Return False
        End Try
    End Function

    Protected Sub loadBranch(cmbBranch As DropDownList, cmbBank As DropDownList)
        Try
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd = New SqlCommand("SELECT bank, branch, branch_name FROM para_branch where bank='" & cmbBank.SelectedValue & "'", con)
                    Dim ds As New DataSet
                    Dim adp = New SqlDataAdapter(cmd)
                    adp.Fill(ds, "para_branch")
                    loadCombo(ds.Tables(0), cmbBranch, "branch_name", "branch")
                End Using
            End Using
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- loadBranch()", ex.ToString)
        End Try
    End Sub

    Protected Sub loadClientTypes()
        Try
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd = New SqlCommand("select * from PARA_CLIENT_TYPES", con)
                    Dim ds As New DataSet
                    Using adp = New SqlDataAdapter(cmd)
                        adp.Fill(ds, "Clients")
                    End Using
                    loadCombo(ds.Tables(0), rdbClientType, "CLIENT_TYPE", "ID")
                End Using
            End Using
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- loadClientTypes()", ex.ToString)
        End Try
    End Sub

    Protected Sub loadCollateralTypes()
        Try
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd As New SqlCommand("select * from CollateralTypes", con)
                    Dim dt As New DataTable
                    Using adp = New SqlDataAdapter(cmd)
                        adp.Fill(dt)
                    End Using
                    loadCombo(dt, cmbCollateralType, "CollateralName", "id")
                End Using
            End Using
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- loadCollateralTypes()", ex.ToString)
        End Try
    End Sub

    Protected Sub loadOtherLoans()
        Try
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd = New SqlCommand("select [OTHER_DESC] as [DESCRIPTION],[OTHER_ACCNO] as [ACCOUNT NUMBER],CONVERT(DECIMAL(30,2),[OTHER_AMT]) as [AMOUNT] from QUEST_OTHER_LOANS where CUSTOMER_NUMBER='" & txtCustNo.Text & "'", con)
                    Dim ds As New DataSet
                    Using adp = New SqlDataAdapter(cmd)
                        adp.Fill(ds, "Other")
                    End Using
                    If ds.Tables(0).Rows.Count > 0 Then
                        grdOtherLoan.DataSource = ds.Tables(0)
                    Else
                        grdOtherLoan.DataSource = Nothing
                    End If
                    grdOtherLoan.DataBind()
                End Using
            End Using
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- loadOtherLoans()", ex.ToString)
        End Try
    End Sub

    Protected Sub loadPurpose(ByVal cmbPurpose As DropDownList)
        Try
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd = New SqlCommand("select * from PARA_PURPOSE", con)
                    Dim ds As New DataSet
                    Using adp = New SqlDataAdapter(cmd)
                        adp.Fill(ds, "purpose")
                    End Using
                    CreditManager.loadCombo(ds.Tables(0), cmbPurpose, "PURPOSE", "PURPOSE")
                End Using
            End Using
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- loadPurpose()", ex.ToString)
        End Try
    End Sub

    Protected Sub loadUploadedFiles(custNo As String)
        Try
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd = New SqlCommand("select * from QUEST_DOCUMENTS where CUST_NO='" & custNo & "' and (LOAN_ID='' or LOAN_ID is NULL)", con)
                    Dim ds As New DataSet
                    Using adp = New SqlDataAdapter(cmd)
                        adp.Fill(ds, "QD")
                    End Using
                    If ds.Tables(0).Rows.Count > 0 Then
                        grdDocuments.DataSource = ds.Tables(0)
                    Else
                        grdDocuments.DataSource = Nothing
                    End If
                    grdDocuments.DataBind()
                End Using
            End Using
        Catch ex As Exception
            WriteLogFile(ex.ToString)
        End Try
    End Sub

    Protected Sub loadUploadedFilesRej(loanID As String)
        Try
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd = New SqlCommand("select * from QUEST_DOCUMENTS where LOAN_ID='" & loanID & "'", con)
                    Dim ds As New DataSet
                    Using adp = New SqlDataAdapter(cmd)
                        adp.Fill(ds, "QD")
                    End Using
                    If ds.Tables(0).Rows.Count > 0 Then
                        grdDocuments.DataSource = ds.Tables(0)
                    Else
                        grdDocuments.DataSource = Nothing
                    End If
                    grdDocuments.DataBind()
                End Using
            End Using
        Catch ex As Exception
            WriteLogFile(ex.ToString)
        End Try
    End Sub

    Protected Sub lstSurname_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstSurname.SelectedIndexChanged
        Try
            Dim custID = lstSurname.SelectedValue
            txtCustNo.Text = custID
            btnSearchCustNo_Click(sender, New EventArgs)
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Page.MaintainScrollPositionOnPostBack = True
            Page.ClientScript.RegisterOnSubmitStatement(Me.GetType, "val", "fnOnUpdateValidators();")
            If Not IsPostBack Then
                mltGrpApp.ActiveViewIndex = 0
                loadClientTypes()
                'loadBank(cmbFinReqBank)
                'loadBank(cmbBankAppType)
                'loadBanks(cmbFinReqBank)
                loadBanks(cmbBankAppType)
                loadBanks(cmbBank)
                writeBranch()
                loadPurpose(cmbFinReqPurpose)
                loadPurpose(cmbGrpFinReqPurpose)
                getPDACompanies()
                loadProductType(cmbProductType)
                loadProductType(cmbGrpProduct)
                loadSectors(cmbSector)
                loadCollateralTypes()
                loadOwnerOfClient()

                'loadCountry(cmbCountryOfBirth)
                'loadCountry(cmbPassportIssuerCountry)
                'loadCountry(cmbMainAddCountry)
                'loadCountry(cmbSecondaryAddCountry)
                'loadCountry(cmbNationality)
                'loadCountry(cmbCitizenship)
                loadEducationLevel(cmbEducation)
                loadMaritalStatus(cmbMaritalStatus)
                'loadClassificationOfIndividual(cmbClassificationOfIndividual)
                'loadNegativeStatusOfIndividual(cmbNegativeStatus)
                getAnswers(cmbDefaultHistory, "40130")
                getAnswers(cmbEmploymentType, "40129")
                getAnswers(cmbMainIncomeSource, "40112")
                getAnswers(cmbOtherIncomeSources, "40115")
                getAnswers(cmbAccOtherBanks, "40123")
                getAnswers(cmbOtherPropertyOwnership, "40118")
                getAnswers(cmbPrevBorrowings, "40117")
                getAnswers(cmbCurrBorrowings, "40114")

                If Not processFlowSaved() Then
                ElseIf Not internalControlsSaved() Then

                End If
                Dim EncQuery As New BankEncryption64
                Try
                    ViewState("restoreID") = EncQuery.Decrypt(Request.QueryString("id").Replace(" ", "+"))
                    ViewState("isRestore") = EncQuery.Decrypt(Request.QueryString("s").Replace(" ", "+"))
                    If ViewState("isRestore") = "1" Then
                        getNamesDT(getSavedSession(ViewState("restoreID")))
                        getSessionGuarantorInfo(ViewState("restoreID"))
                    End If
                Catch ex As Exception
                End Try
                If Request.QueryString("rej") = 1 Then
                    ViewState("globLoanID") = EncQuery.Decrypt(Request.QueryString("id").Replace(" ", "+"))
                    loadClientTypes()
                    getAppHistory()
                    getAppDetails(ViewState("globLoanID"))
                    writeSubmitButton(Session("ROLE"))
                    btnTerminate.Visible = True
                    lnkViewAppForm.NavigateUrl = "Amortization.aspx?ID=" & EncQuery.Encrypt(ViewState("globLoanID").Replace(" ", "+")) & "&App=1"
                    lnkViewAppForm.Visible = True
                    lnkAppRating.NavigateUrl = "ApplicationRating.aspx?loanID=" & EncQuery.Encrypt(ViewState("globLoanID").Replace(" ", "+"))
                    lnkAppRating.Visible = True
                    If amortizationAlreadyCreated(ViewState("globLoanID")) Then
                        lnkAmortizationSchedule.NavigateUrl = "rptAmortizationSchedule.aspx?loanID=" & EncQuery.Encrypt(ViewState("globLoanID").Replace(" ", "+"))
                        lnkAmortizationSchedule.Visible = True
                    End If
                    loadUploadedFilesRej(ViewState("globLoanID"))
                End If
            End If
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- Page_Load()", ex.ToString)
        End Try
    End Sub

    Protected Function getSavedSession(sesID As String) As DataTable
        Try
            Using con As New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("conString").ConnectionString())
                Using cmd As New SqlCommand("Select *,convert(varchar,DOB,106) as DOB1,convert(varchar,ISSUE_DATE,106) as ISSUE_DATE1 from [QUEST_APPLICATION_AutoSave] where id=@id", con)
                    cmd.Parameters.AddWithValue("@id", sesID)
                    Dim dt As New DataTable
                    Using adp As New SqlDataAdapter(cmd)
                        adp.Fill(dt)
                    End Using
                    Return dt
                End Using
            End Using
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- getSavedSession()", ex.ToString)
            Return Nothing
        End Try
    End Function

    Protected Sub getSessionGuarantorInfo(sesID As String)
        Try
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd = New SqlCommand("select *,convert(varchar,GUARANTOR_DOB,106) as GUARANTOR_DOB1 from QUEST_APPLICATION_AutoSave where [ID]=@id", con)
                    cmd.Parameters.AddWithValue("@id", sesID)
                    Dim ds As New DataSet
                    Dim adp = New SqlDataAdapter(cmd)
                    adp.Fill(ds, "APP")
                    If ds.Tables(0).Rows.Count > 0 Then
                        txtGuarCity.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("GUARANTOR_CITY"))
                        txtGuarCurrAdd.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("GUARANTOR_ADD"))
                        txtGuarCurrEmp.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("GUARANTOR_EMPLOYER"))
                        txtGuarEmpAdd.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("GUARANTOR_EMP_ADD"))
                        txtGuarEmpEmail.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("GUARANTOR_EMP_EMAIL"))
                        txtGuarEmpFax.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("GUARANTOR_EMP_FAX"))
                        Try
                            txtGuarEmpIncome.Text = FormatNumber(BankString.isNullString(ds.Tables(0).Rows(0).Item("GUARANTOR_EMP_INCOME")), 2)
                        Catch ex As Exception
                            txtGuarEmpIncome.Text = ""
                        End Try
                        Try
                            txtGuarEmpLength.Text = FormatNumber(BankString.isNullString(ds.Tables(0).Rows(0).Item("GUARANTOR_EMP_LENGTH")), 0)
                        Catch ex As Exception
                            txtGuarEmpLength.Text = ""
                        End Try
                        txtGuarEmpPhone.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("GUARANTOR_EMP_PHONE"))
                        txtGuarEmpPosition.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("GUARANTOR_EMP_POSTN"))
                        Try
                            txtGuarEmpSalary.Text = FormatNumber(BankString.isNullString(ds.Tables(0).Rows(0).Item("GUARANTOR_EMP_SALARY")), 2)
                        Catch ex As Exception
                            txtGuarEmpSalary.Text = ""
                        End Try
                        Try
                            txtGuarHomeLength.Text = FormatNumber(BankString.isNullString(ds.Tables(0).Rows(0).Item("GUARANTOR_HOME_LENGTH")), 0)
                        Catch ex As Exception
                            txtGuarHomeLength.Text = ""
                        End Try
                        txtGuarIDNo.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("GUARANTOR_IDNO"))
                        Try
                            txtGuarMonthRent.Text = FormatNumber(BankString.isNullString(ds.Tables(0).Rows(0).Item("GUARANTOR_RENT")), 2)
                        Catch ex As Exception
                            txtGuarMonthRent.Text = ""
                        End Try
                        txtGuarName.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("GUARANTOR_NAME"))
                        txtGuarNameRelative.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("GUARANTOR_REL_NAME"))
                        txtGuarPhone.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("GUARANTOR_PHONE"))
                        txtGuarRelAddress.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("GUARANTOR_REL_ADD"))
                        txtGuarRelCity.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("GUARANTOR_REL_CITY"))
                        txtGuarRelPhone.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("GUARANTOR_REL_PHONE"))
                        txtGuarRelReltnship.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("GUARANTOR_REL_RELTNSHP"))
                        Try
                            rdbGuarHomeType.SelectedValue = ds.Tables(0).Rows(0).Item("GUARANTOR_HOME_TYPE")
                        Catch ex As Exception
                            rdbGuarHomeType.ClearSelection()
                        End Try

                        bdpGuarDOB.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("GUARANTOR_DOB1"))

                        Try
                            txtFinReqAmt.Text = FormatNumber(BankString.isNullString(ds.Tables(0).Rows(0).Item("FIN_AMT")), 2)
                        Catch ex As Exception
                            txtFinReqAmt.Text = ""
                        End Try
                        Try
                            txtRecAmt.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("FIN_AMT"))
                        Catch ex As Exception
                            txtRecAmt.Text = ""
                        End Try

                        txtFinReqIntRate.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("FIN_INT_RATE"))
                        txtFinReqPurpose.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("FIN_PURPOSE"))
                        txtFinReqSource.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("FIN_SRC_REPAYMT"))
                        'txtFinReqTenor.Text = FormatNumber(BankString.isNullString(ds.Tables(0).Rows(0).Item("FIN_TENOR")), 0)
                        txtFinReqTenor.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("FIN_TENOR"))
                        txtQuesAgent.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("QUES_AGENT"))
                        txtQuesEmployee.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("QUES_EMPLOYEE"))
                        txtAdminRate.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("ADMIN_RATE"))
                        Try
                            cmbFinReqPurpose.SelectedValue = BankString.isNullString(ds.Tables(0).Rows(0).Item("FIN_PURPOSE"))
                        Catch ex As Exception

                        End Try
                    Else
                        txtGuarCity.Text = ""
                        txtGuarCurrAdd.Text = ""
                        txtGuarCurrEmp.Text = ""
                        txtGuarEmpAdd.Text = ""
                        txtGuarEmpEmail.Text = ""
                        txtGuarEmpFax.Text = ""
                        txtGuarEmpIncome.Text = ""
                        txtGuarEmpLength.Text = ""
                        txtGuarEmpPhone.Text = ""
                        txtGuarEmpPosition.Text = ""
                        txtGuarEmpSalary.Text = ""
                        txtGuarHomeLength.Text = ""
                        txtGuarIDNo.Text = ""
                        txtGuarMonthRent.Text = ""
                        txtGuarName.Text = ""
                        txtGuarNameRelative.Text = ""
                        txtGuarPhone.Text = ""
                        txtGuarRelAddress.Text = ""
                        txtGuarRelCity.Text = ""
                        txtGuarRelPhone.Text = ""
                        txtGuarRelReltnship.Text = ""
                    End If
                End Using
            End Using
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- getSessionGuarantorInfo()", ex.ToString)
        End Try
    End Sub
    Protected Function processFlowSaved() As Boolean
        Try
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                'Using cmd = New SqlCommand("select * from ParaApprovalStages", con)
                Using cmd = New SqlCommand("select * from ParaApprovalStages where FinProductType='" & cmbProductType.SelectedValue & "'", con)
                    Dim ds As New DataSet
                    Dim adp = New SqlDataAdapter(cmd)
                    adp.Fill(ds, "PAS")
                    If ds.Tables(0).Rows.Count > 1 Then
                        Return True
                    Else
                        Return False
                    End If
                End Using
            End Using
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- processFlowSaved()", ex.ToString)
            Return False
        End Try
    End Function
    Protected Sub rdbClientType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdbClientType.SelectedIndexChanged
        clientTypeVisible()
    End Sub

    Protected Sub rdbQuesHow_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdbQuesHow.SelectedIndexChanged
        Try
            If rdbQuesHow.SelectedValue = "Employee" Then
                lblQuesEmployee.Text = "Our Employee"
            ElseIf rdbQuesHow.SelectedValue = "Agent" Then
                lblQuesEmployee.Text = "Agent Name"
            ElseIf rdbQuesHow.SelectedValue = "Friend" Then
                lblQuesEmployee.Text = "Friend Name"
            ElseIf rdbQuesHow.SelectedValue = "Media" Then
                lblQuesEmployee.Text = "Name"
            ElseIf rdbQuesHow.SelectedValue = "Others" Then
                lblQuesEmployee.Text = "Name"
            End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub rdbSubIndividual_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rdbSubIndividual.SelectedIndexChanged
        applicantTypeSelector(rdbSubIndividual.SelectedValue)
    End Sub

    Protected Sub saveGrpMemberAmts(cust As String, loanID As String)
        Try
            For Each member As RepeaterItem In repGrpMembers.Items
                Dim memberID As String = CType(member.FindControl("lblGrpMemberID"), Label).Text
                Dim memberName As String = CType(member.FindControl("lblGrpMemberName"), Label).Text
                Dim amt As String = CType(member.FindControl("txtGrpMemberAmt"), TextBox).Text
                Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                    Dim cmd1 As New SqlCommand("insert into [QUEST_GROUP_APPLICATION] ([CUST_NO],[LOAN_ID],[MEMBER_ID],[MEMBER_NAME],[AMOUNT]) values ('" & cust & "','" & loanID & "','" & memberID & "','" & memberName & "','" & amt & "')", con)
                    If con.State <> ConnectionState.Closed Then
                        con.Close()
                    End If
                    con.Open()
                    cmd1.ExecuteNonQuery()
                    con.Close()
                End Using
            Next
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- saveGrpMemberAmts()", ex.ToString)
        End Try
    End Sub
    Protected Sub saveInitiatorComment()
        Try
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd = New SqlCommand("insert into REQUEST_HISTORY (LOANID,COMMENT_DATE,USERID,COMMENT,RECOMMENDED_AMT) values('" & ViewState("globLoanID") & "',GETDATE(),'" & Session("UserID") & "','" & BankString.removeSpecialCharacter(txtComment.Text) & "','" & toMoney(txtFinReqAmt.Text) & "')", con)
                    If con.State = ConnectionState.Open Then
                        con.Close()
                    End If
                    con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                End Using
            End Using
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- saveInitiatorComment()", ex.ToString)
        End Try
    End Sub

    Protected Sub saveInitiatorCommentGrp()
        Try
            ViewState("globLoanID") = getLastLoanID()
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd = New SqlCommand("insert into REQUEST_HISTORY (LOANID,COMMENT_DATE,USERID,COMMENT,RECOMMENDED_AMT) values('" & ViewState("globLoanID") & "',GETDATE(),'" & Session("UserID") & "','','" & txtGrpApplLoanAmt.Text & "')", con)
                    If con.State = ConnectionState.Open Then
                        con.Close()
                    End If
                    con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                End Using
            End Using
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- saveInitiatorCommentGrp()", ex.ToString)
        End Try
    End Sub

    Protected Sub SSBInvisible()
        Try
            'lblMinDept.Visible = False
            'lblMinDeptNo.Visible = False
            'txtMinDept.Visible = False
            'txtMinDeptNo.Visible = False
            lblEmpCode.Visible = False
            txtECNo.Visible = False
            txtECNoCD.Visible = False
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub SSBVisible()
        Try
            'lblMinDept.Visible = True
            'lblMinDeptNo.Visible = True
            'txtMinDept.Visible = True
            'txtMinDeptNo.Visible = True
            lblEmpCode.Visible = True
            txtECNo.Visible = True
            txtECNoCD.Visible = True
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub updateDocLoanID(custNo As String)
        Try
            If btnSubmit.Text = "Update Application" Then
            Else
                ViewState("globLoanID") = getLastLoanID()
            End If
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd = New SqlCommand("update QUEST_DOCUMENTS set LOAN_ID='" & ViewState("globLoanID") & "' where CUST_NO='" & custNo & "' and (LOAN_ID='' or LOAN_ID is null or LOAN_ID='0')  update ClientCollateral set LOANID='" & ViewState("globLoanID") & "' where CUSTNO='" & custNo & "' and (LOANID is null or LOANID='0')  update [QUEST_OTHER_LOANS] set LoanID='" & ViewState("globLoanID") & "' where [CUSTOMER_NUMBER]='" & custNo & "' and (LoanID is null or LoanID='0')", con)
                    If con.State = ConnectionState.Open Then
                        con.Close()
                    End If
                    con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                End Using
            End Using
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- updateDocLoanID()", ex.ToString)
        End Try
    End Sub

    Protected Sub writeBranch()
        lblBranchCode.Text = Session("BRANCHCODE")
        lblBranchName.Text = Session("BRANCHNAME")
    End Sub

    Protected Sub writeSubmitButton(ByVal roleID As String)
        If roleID = "4042" Then
            btnSubmit.Text = "Recommend"
        ElseIf roleID = "4043" Then
            btnSubmit.Text = "Approve"
        ElseIf roleID = "4044" Then
            btnSubmit.Text = "Approve"
        ElseIf roleID = "1024" Then
            btnSubmit.Text = "Approve for Disbursal"
        ElseIf roleID = "4041" Then
            If Request.QueryString("rej") = 1 Then
                btnSubmit.Text = "Update Application"
            Else
                btnSubmit.Text = "Disburse"
            End If
        End If
    End Sub

    Private Sub btnAddPurpose_Click(sender As Object, e As EventArgs) Handles btnAddPurpose.Click
        Try
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd = New SqlCommand("select * from PARA_PURPOSE where PURPOSE=@purp", con)
                    cmd.Parameters.AddWithValue("@purp", txtPurpose.Text)
                    Dim ds As New DataSet
                    Using adp = New SqlDataAdapter(cmd)
                        adp.Fill(ds, "PRODUCTS")
                    End Using
                    Dim cmdSub As New SqlCommand
                    If ds.Tables(0).Rows.Count > 0 Then
                    Else
                        cmdSub = New SqlCommand("insert into PARA_PURPOSE ([PURPOSE]) values (@purp)", con)
                        cmdSub.Parameters.AddWithValue("@purp", txtPurpose.Text)
                    End If
                    If con.State = ConnectionState.Open Then
                        con.Close()
                    End If
                    con.Open()
                    cmdSub.ExecuteNonQuery()
                    con.Close()
                    CreditManager.notify("New purpose entered", "success")
                    txtPurpose.Text = ""
                    loadPurpose(cmbFinReqPurpose)
                    loadPurpose(cmbGrpFinReqPurpose)
                End Using
            End Using
        Catch ex As Exception
            ErrorLogging.WriteLogFile(Session("UserId"), Request.Url.ToString & " --- btnAddPurpose()", ex.ToString)
        End Try
    End Sub

    Private Sub cmbProductType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbProductType.SelectedIndexChanged
        getProductDefaults(cmbProductType.SelectedValue)
        getCreditParams(cmbProductType.SelectedValue)
    End Sub

    Protected Function getSalaryBasedLimit(dr As DataRow, gross As Double, nett As Double) As Double
        Try
            Dim limit As Double = 0
            If dr("SalaryBasedLimit") = "Y" Then
                'calculate limit on gross or net
                Dim calcRate As Double = dr("MaxRateAllowed")
                If dr("LimitBasedOn") = "Gross" Then
                    '
                    limit = (calcRate / 100) * gross
                ElseIf dr("LimitBasedOn") = "Net" Then
                    '
                    limit = (calcRate / 100) * nett
                End If
            Else
                'no salary based limit.
                limit = 0
            End If
            Return limit
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- getSalaryBasedLimit()", ex.ToString)
            Return 0
        End Try
    End Function

    Protected Sub loadOwnerOfClient()
        Try
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd As New SqlCommand("select [USER_LOGIN],isnull([FNAME],'')+' '+isnull([LNAME],'') as Name from [MASTER_USERS]", con)
                    Dim dt As New DataTable
                    Using adp As New SqlDataAdapter(cmd)
                        adp.Fill(dt)
                    End Using
                    loadCombo(dt, cmbOwner, "Name", "USER_LOGIN")
                End Using
            End Using
        Catch ex As Exception
            ErrorLogging.WriteLogFile(Session("UserId"), Request.Url.ToString & " --- loadOwnerOfClient()", ex.ToString)
        End Try
    End Sub

    Private Sub grdCollateral_RowCancelingEdit(sender As Object, e As GridViewCancelEditEventArgs) Handles grdCollateral.RowCancelingEdit
        grdCollateral.EditIndex = -1
        getClientCollateral(txtCustNo.Text, ViewState("globLoanID"))
    End Sub

    Private Sub grdCollateral_RowDeleting(sender As Object, e As GridViewDeleteEventArgs) Handles grdCollateral.RowDeleting
        ViewState("collEditID") = DirectCast(grdCollateral.Rows(e.RowIndex).FindControl("txtCollId"), TextBox).Text
        Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
            Using cmd = New SqlCommand("delete from [ClientCollateral] where ID='" & ViewState("collEditID") & "'", con)
                If con.State = ConnectionState.Open Then
                    con.Close()
                End If
                con.Open()
                If cmd.ExecuteNonQuery Then
                    notify("Collateral successfully deleted", "success")
                Else
                    notify("Error deleting collateral", "error")
                End If
                con.Close()
                getClientCollateral(txtCustNo.Text, ViewState("globLoanID"))
            End Using
        End Using
    End Sub

    Private Sub grdCollateral_RowEditing(sender As Object, e As GridViewEditEventArgs) Handles grdCollateral.RowEditing
        ViewState("collEditID") = DirectCast(grdCollateral.Rows(e.NewEditIndex).FindControl("txtCollId"), TextBox).Text
        grdCollateral.EditIndex = e.NewEditIndex
        getClientCollateral(txtCustNo.Text, ViewState("globLoanID"))
    End Sub

    Private Sub grdCollateral_RowUpdating(sender As Object, e As GridViewUpdateEventArgs) Handles grdCollateral.RowUpdating
        If Trim(ViewState("collEditID")) = "" Or IsDBNull(ViewState("collEditID")) Then
            notify("No collateral selected for update", "error")
            Exit Sub
        End If
        Dim des As String = DirectCast(grdCollateral.Rows(e.RowIndex).FindControl("txtCollDescEdit"), TextBox).Text
        Dim type As String = DirectCast(grdCollateral.Rows(e.RowIndex).FindControl("txtCollTypeEdit"), TextBox).Text
        Dim val As String = DirectCast(grdCollateral.Rows(e.RowIndex).FindControl("txtValueEdit"), TextBox).Text
        Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
            Using cmd = New SqlCommand("update [ClientCollateral] set [CollDesc]='" & BankString.removeSpecialCharacter(des) & "',[CollateralType]='" & type & "',[CollValue]='" & val & "' where ID='" & ViewState("collEditID") & "'", con)
                If con.State = ConnectionState.Open Then
                    con.Close()
                End If
                con.Open()
                If cmd.ExecuteNonQuery Then
                    notify("Collateral successfully updated", "success")
                Else
                    notify("Error updating collateral", "error")
                End If
                con.Close()
                grdCollateral.EditIndex = -1
                getClientCollateral(txtCustNo.Text, ViewState("globLoanID"))
            End Using
        End Using
    End Sub
    Protected Sub submitApplication()
        Try
            If CDbl(toMoney(txtFinReqIntRate.Text)) > CDbl(toMoney(ViewState("MaxIntRate"))) Then
                notify("Interest rate greater than the maximum allowed for this product", "error")
                Exit Sub
            ElseIf CDbl(toMoney(txtFinReqIntRate.Text)) < CDbl(toMoney(ViewState("MinIntRate"))) Then
                notify("Interest rate less than minimum allowed for this product", "error")
                Exit Sub
            ElseIf Val(toMoney(txtFinReqAmt.Text)) > Val(ViewState("MaxAmt")) Or Val(toMoney(txtFinReqAmt.Text)) < Val(toMoney(ViewState("MinAmt"))) Then
                notify("Required amount out of the range for this product", "error")
                Exit Sub
            ElseIf CDbl(txtFinReqTenor.Text) > CDbl(ViewState("MaximumTenure")) Or CDbl(txtFinReqTenor.Text) < CDbl(ViewState("MinimumTenure")) Then
                notify("Loan tenure out of the range for this product", "error")
                Exit Sub
                'ElseIf IsNumeric(txtDBR.Text) Then
                '    If CDbl(toMoney(txtDBR.Text)) > 40 Then
                '        ClientScript.RegisterStartupScript(Me.GetType(), "DBRExceeded", "<script type=""text/javascript"">showDBRExceeded();</script>")
                '        Exit Sub
                '    End If
            End If
            If bdpFinReqRepaymt.Text = "" Then
                notify("1st Repayment Date is Required", "error")
                Exit Sub
            End If
            Dim reqType = ""
            If cmbProductType.SelectedValue = "Asset Financing" Then
                reqType = ddlAssets.SelectedItem.Text
            End If
            '''''''''''''''''''''''SSB CUT-OFF DATE'''''''''''''''''''''''''
            'If rdbSubIndividual.SelectedValue = "SSB" Then
            '    If ViewState("SSBDate") <> "" And Not IsDBNull(ViewState("SSBDate")) Then
            '        If CDate(bdpFinReqRepaymt.Text) <= CDate(ViewState("SSBDate")) Then
            '            notify("Repayment date cannot be earlier than SSB cut off date", "error")
            '            bdpFinReqRepaymt.Focus()
            '            Exit Sub
            '        End If
            '    End If
            'End If
            If CDate(txtApplicationDate.Text) >= CDate(bdpFinReqRepaymt.Text) Then
                notify("The first repayment date must be after the application date", "error")
                Exit Sub
            End If

            If cmbOwner.SelectedValue = "" Then
                notify("Select the owner of the client", "error")
                Exit Sub
            End If
            getNextApproval(1)
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd1 = New SqlCommand("SaveLoanApplication", con)
                    cmd1.CommandType = CommandType.StoredProcedure
                    If btnSubmit.Text = "Update Application" Then
                        cmd1.Parameters.AddWithValue("@LoanID", ViewState("globLoanID"))
                        cmd1.Parameters.AddWithValue("@TranType", "Update")
                    Else
                        cmd1.Parameters.AddWithValue("@LoanID", 0)
                        cmd1.Parameters.AddWithValue("@TranType", "Save")
                    End If
                    cmd1.Parameters.AddWithValue("@CUSTOMER_TYPE", "Individual") ' rdbClientType.SelectedValue)
                    cmd1.Parameters.AddWithValue("@CUSTOMER_NUMBER", txtCustNo.Text)
                    cmd1.Parameters.AddWithValue("@SUB_INDIVIDUAL", validateRadiobutton(rdbSubIndividual))
                    cmd1.Parameters.AddWithValue("@ECNO", txtECNo.Text)
                    cmd1.Parameters.AddWithValue("@CD", txtECNoCD.Text)
                    cmd1.Parameters.AddWithValue("@SURNAME", txtSurname.Text.ToUpper)
                    cmd1.Parameters.AddWithValue("@FORENAMES", txtForenames.Text.ToUpper)
                    cmd1.Parameters.AddWithValue("@DOB", validateDate(bdpDOB.Text))
                    cmd1.Parameters.AddWithValue("@IDNO", txtIDNo.Text.ToUpper)

                    cmd1.Parameters.AddWithValue("@PDACode", cmbPDAAppType.SelectedValue)
                    cmd1.Parameters.AddWithValue("@AppTypeBank", cmbBankAppType.SelectedValue)
                    cmd1.Parameters.AddWithValue("@AppTypeBranch", cmbBranchAppType.SelectedValue)
                    cmd1.Parameters.AddWithValue("@AppTypeOtherDesc", txtOtherAppType.Text)

                    cmd1.Parameters.AddWithValue("@ISSUE_DATE", validateDate(txtIssDate.Text))
                    cmd1.Parameters.AddWithValue("@ADDRESS", txtAddress.Text.ToUpper)
                    cmd1.Parameters.AddWithValue("@CITY", txtCity.Text.ToUpper)
                    cmd1.Parameters.AddWithValue("@PHONE_NO", txtPhoneNo.Text)
                    'cmd1.Parameters.AddWithValue("@NATIONALITY", validateDropdown(cmbNationality))
                    cmd1.Parameters.AddWithValue("@NATIONALITY", txtNationality.Text)
                    cmd1.Parameters.AddWithValue("@GENDER", validateRadiobutton(rdbGender))
                    cmd1.Parameters.AddWithValue("@HOME_TYPE", validateRadiobutton(rdbHouse))
                    cmd1.Parameters.AddWithValue("@MONTHLY_RENT", validateNumeric(txtRent.Text))
                    cmd1.Parameters.AddWithValue("@MARITAL_STATUS", validateDropdown(cmbMaritalStatus))
                    cmd1.Parameters.AddWithValue("@EDUCATION", validateDropdown(cmbEducation))
                    cmd1.Parameters.AddWithValue("@CURR_EMPLOYER", txtCurrEmployer.Text)
                    cmd1.Parameters.AddWithValue("@CURR_EMP_ADD", txtEmpAddress.Text)
                    'cmd1.Parameters.AddWithValue("@CURR_EMP_LENGTH", validateNumeric(txtEmpHowLongMonth.Text))
                    cmd1.Parameters.AddWithValue("@CURR_EMP_LENGTH", validateNumeric(txtEmpHowLong.Text))
                    cmd1.Parameters.AddWithValue("@CURR_EMP_PHONE", txtEmpPhone.Text)
                    cmd1.Parameters.AddWithValue("@CURR_EMP_EMAIL", txtEmpEmail.Text)
                    cmd1.Parameters.AddWithValue("@CURR_EMP_FAX", txtEmpFax.Text)
                    cmd1.Parameters.AddWithValue("@CURR_EMP_CITY", txtEmpCity.Text)
                    cmd1.Parameters.AddWithValue("@CURR_EMP_POSITION", txtEmpPosition.Text)
                    cmd1.Parameters.AddWithValue("@CURR_EMP_SALARY", validateNumeric(txtEmpSalary.Text))
                    cmd1.Parameters.AddWithValue("@CURR_EMP_NET", validateNumeric(txtEmpSalaryNet.Text))
                    cmd1.Parameters.AddWithValue("@CURR_EMP_INCOME", validateNumeric(txtEmpOtherIncome.Text))
                    cmd1.Parameters.AddWithValue("@SPOUSE_NAME", txtSpouse.Text)
                    cmd1.Parameters.AddWithValue("@SPOUSE_OCCUPATION", txtSpouseOccupation.Text)
                    cmd1.Parameters.AddWithValue("@SPOUSE_EMPLOYER", txtSpouseEmployer.Text)
                    cmd1.Parameters.AddWithValue("@SPOUSE_PHONE", txtSpousePhone.Text)
                    cmd1.Parameters.AddWithValue("@NO_CHILDREN", validateNumeric(txtNoChildren.Text))
                    cmd1.Parameters.AddWithValue("@NO_DEPENDANTS", validateNumeric(txtNoDependant.Text))
                    cmd1.Parameters.AddWithValue("@TRADE_REF1", txtTradeRef1.Text)
                    cmd1.Parameters.AddWithValue("@TRADE_REF2", txtTradeRef2.Text)
                    cmd1.Parameters.AddWithValue("@GUARANTOR_NAME", txtGuarName.Text)
                    cmd1.Parameters.AddWithValue("@GUARANTOR_DOB", validateDate(bdpGuarDOB.Text))
                    cmd1.Parameters.AddWithValue("@GUARANTOR_IDNO", txtGuarIDNo.Text)
                    cmd1.Parameters.AddWithValue("@GUARANTOR_PHONE", txtGuarPhone.Text)
                    cmd1.Parameters.AddWithValue("@GUARANTOR_ADD", txtGuarCurrAdd.Text)
                    cmd1.Parameters.AddWithValue("@GUARANTOR_CITY", txtGuarCity.Text)
                    cmd1.Parameters.AddWithValue("@GUARANTOR_HOME_TYPE", validateRadiobutton(rdbGuarHomeType))
                    cmd1.Parameters.AddWithValue("@GUARANTOR_RENT", validateNumeric(txtGuarMonthRent.Text))
                    cmd1.Parameters.AddWithValue("@GUARANTOR_HOME_LENGTH", validateNumeric(txtGuarHomeLength.Text))
                    cmd1.Parameters.AddWithValue("@GUARANTOR_EMPLOYER", txtGuarCurrEmp.Text)
                    cmd1.Parameters.AddWithValue("@GUARANTOR_EMP_ADD", txtGuarEmpAdd.Text)
                    cmd1.Parameters.AddWithValue("@GUARANTOR_EMP_LENGTH", validateNumeric(txtGuarEmpLength.Text))
                    cmd1.Parameters.AddWithValue("@GUARANTOR_EMP_PHONE", txtGuarEmpPhone.Text)
                    cmd1.Parameters.AddWithValue("@GUARANTOR_EMP_EMAIL", txtGuarEmpEmail.Text)
                    cmd1.Parameters.AddWithValue("@GUARANTOR_EMP_FAX", txtGuarEmpFax.Text)
                    cmd1.Parameters.AddWithValue("@GUARANTOR_EMP_POSTN", txtGuarEmpPosition.Text)
                    cmd1.Parameters.AddWithValue("@GUARANTOR_EMP_SALARY", validateNumeric(txtGuarEmpSalary.Text))
                    cmd1.Parameters.AddWithValue("@GUARANTOR_EMP_INCOME", validateNumeric(txtGuarEmpIncome.Text))
                    cmd1.Parameters.AddWithValue("@GUARANTOR_REL_NAME", txtGuarNameRelative.Text)
                    cmd1.Parameters.AddWithValue("@GUARANTOR_REL_ADD", txtGuarRelAddress.Text)
                    cmd1.Parameters.AddWithValue("@GUARANTOR_REL_CITY", txtGuarRelCity.Text)
                    cmd1.Parameters.AddWithValue("@GUARANTOR_REL_PHONE", txtGuarRelPhone.Text)
                    cmd1.Parameters.AddWithValue("@GUARANTOR_REL_RELTNSHP", txtGuarRelReltnship.Text)
                    cmd1.Parameters.AddWithValue("@FIN_AMT", validateNumeric(txtFinReqAmt.Text))
                    cmd1.Parameters.AddWithValue("@FIN_TENOR", validateNumeric(txtFinReqTenor.Text))
                    cmd1.Parameters.AddWithValue("@FIN_INT_RATE", validateNumeric(txtFinReqIntRate.Text))
                    cmd1.Parameters.AddWithValue("@FIN_PURPOSE", cmbFinReqPurpose.Text)
                    cmd1.Parameters.AddWithValue("@FIN_SRC_REPAYMT", txtFinReqSource.Text)
                    'cmd1.Parameters.AddWithValue("@FIN_BANK", cmbFinReqBank.SelectedItem.Text)
                    'cmd1.Parameters.AddWithValue("@FIN_BRANCH", cmbFinReqBranch.SelectedItem.Text)
                    cmd1.Parameters.AddWithValue("@FIN_REPAY_DATE", validateDate(bdpFinReqRepaymt.Text))
                    cmd1.Parameters.AddWithValue("@QUES_HOW", validateRadiobutton(rdbQuesHow))
                    cmd1.Parameters.AddWithValue("@QUES_EMPLOYEE", txtQuesEmployee.Text)
                    cmd1.Parameters.AddWithValue("@QUES_AGENT", txtQuesAgent.Text)
                    cmd1.Parameters.AddWithValue("@APPL_DATE", validateDate(txtApplicationDate.Text))
                    cmd1.Parameters.AddWithValue("@RECOMMENDED_AMT", validateNumeric(txtRecAmt.Text))
                    cmd1.Parameters.AddWithValue("@STATUS", ViewState("StageName"))
                    cmd1.Parameters.AddWithValue("@SEND_TO", ViewState("NextRole"))
                    cmd1.Parameters.AddWithValue("@CREATED_BY", Session("UserId"))
                    cmd1.Parameters.AddWithValue("@BRANCH_CODE", lblBranchCode.Text)
                    cmd1.Parameters.AddWithValue("@BRANCH_NAME", lblBranchName.Text)
                    cmd1.Parameters.AddWithValue("@AREA", validateDropdown(cmbArea))
                    cmd1.Parameters.AddWithValue("@LOAN_SECTOR", validateDropdown(cmbSector))
                    cmd1.Parameters.AddWithValue("@AMT_APPLIED", validateNumeric(txtFinReqAmt.Text))
                    cmd1.Parameters.AddWithValue("@INITIATOR_ID", Session("Id"))
                    cmd1.Parameters.AddWithValue("@LO_ID", Session("Id"))
                    cmd1.Parameters.AddWithValue("@ADMIN_RATE", validateNumeric(txtAdminRate.Text))
                    cmd1.Parameters.AddWithValue("@FinProductType", validateDropdown(cmbProductType))
                    cmd1.Parameters.AddWithValue("@Sector", validateDropdown(cmbSector))
                    cmd1.Parameters.AddWithValue("@RepaymentIntervalNum", validateNumeric(txtRepaymentInterval.Text))
                    cmd1.Parameters.AddWithValue("@RepaymentIntervalUnit", validateDropdown(cmbRepaymentInterval))
                    cmd1.Parameters.AddWithValue("@Bank", validateDropdown(cmbBank))
                    cmd1.Parameters.AddWithValue("@BankBranch", validateDropdown(cmbBankBranch))
                    cmd1.Parameters.AddWithValue("@BankAccountNo", txtBankAccountNo.Text)
                    cmd1.Parameters.AddWithValue("@ApprovalNumber", 1)
                    cmd1.Parameters.AddWithValue("@LAST_ID", Session("ID"))
                    cmd1.Parameters.AddWithValue("@MonthlyPayment", validateNumeric(txtMonthlyPayment.Text))
                    cmd1.Parameters.AddWithValue("@DBR", validateNumeric(txtDBR.Text))
                    cmd1.Parameters.AddWithValue("@DefaultHistory", cmbDefaultHistory.SelectedValue)
                    cmd1.Parameters.AddWithValue("@EmploymentType", cmbEmploymentType.SelectedValue)
                    cmd1.Parameters.AddWithValue("@MainIncomeSource", cmbMainIncomeSource.SelectedValue)
                    cmd1.Parameters.AddWithValue("@OtherIncomeSources", cmbOtherIncomeSources.SelectedValue)
                    cmd1.Parameters.AddWithValue("@AccOtherBanks", cmbAccOtherBanks.SelectedValue)
                    cmd1.Parameters.AddWithValue("@OtherPropertyOwnership", cmbOtherPropertyOwnership.SelectedValue)
                    cmd1.Parameters.AddWithValue("@AccOpenDate", validateDate(txtAccOpeningDate.Text))
                    cmd1.Parameters.AddWithValue("@TimeCurrRes", txtTimeCurrResidence.Text)
                    cmd1.Parameters.AddWithValue("@TimePrevRes", txtTimePrevResidence.Text)
                    cmd1.Parameters.AddWithValue("@CurrBorrowings", cmbCurrBorrowings.SelectedValue)
                    cmd1.Parameters.AddWithValue("@PrevBorrowings", cmbPrevBorrowings.SelectedValue)
                    cmd1.Parameters.AddWithValue("@Extension", chkExtension.Checked)
                    cmd1.Parameters.AddWithValue("@ClientOwner", cmbOwner.SelectedValue)
                    cmd1.Parameters.AddWithValue("@LoanCycle", validateNumeric(lblLoanCycle.Text))
                    'cmd1.Parameters.AddWithValue("@IsTopUp", chkTopUp.Checked)

                    If con.State = ConnectionState.Open Then
                        con.Close()
                    End If
                    con.Open()
                    Try
                        If cmd1.ExecuteNonQuery() Then
                            updateDocLoanID(txtCustNo.Text)
                            saveInitiatorComment()
                            recordAction("btnSubmit", "Submitted loan application for " & txtForenames.Text & " " & txtSurname.Text & " " & FormatCurrency(txtFinReqAmt.Text) & ". Loan ID:  " & ViewState("globLoanID"))
                            Dim strEmail As String
                            Dim SignatoryEMail As String
                            'Dim SignatoryEMail As String = Mailhelper.GetMultiBranchRoleEMailID(Session("BRANCHCODE"), "4042")

                            strEmail = "Dear Sir/Madam,<br/><br/>You have received a request for " & ViewState("NextStageName") & ". Details of the application are as follows<br><br>"
                            strEmail = strEmail & "<table style='border: 1px solid black; width:750px;border-collapse: collapse; font-size:13px'>"
                            strEmail = strEmail & "<tr style='background-color: #f5f5f5;padding: 15px;text-align: left;'><th style='border: 1px solid black;text-align: left;'>Client Name:</th><td style='border: 1px solid black;'>" & txtSurname.Text & " " & txtForenames.Text & "</td></tr>"
                            strEmail = strEmail & "<tr style='background-color: white;padding: 15px;text-align: left;'><th style='border: 1px solid black;text-align: left;'>Application Date:</th><td style='border: 1px solid black;'>" & txtApplicationDate.Text & "</td></tr>"
                            strEmail = strEmail & "<tr style='background-color: #f5f5f5;padding: 15px;text-align: left;'><th style='border: 1px solid black;text-align: left;'>Applicant Type:</th><td style='border: 1px solid black;'>" & rdbClientType.SelectedItem.Text & "</td></tr>"
                            strEmail = strEmail & "<tr style='background-color: white;padding: 15px;text-align: left;'><th style='border: 1px solid black;text-align: left;'>Product:</th><td style='border: 1px solid black;'>" & cmbProductType.SelectedItem.Text.ToString & "</td></tr>"
                            strEmail = strEmail & "<tr style='background-color: #f5f5f5;padding: 15px;text-align: left;'><th style='border: 1px solid black;text-align: left;'>Sector:</th><td style='border: 1px solid black;'>" & cmbSector.SelectedItem.Text.ToString & "</td></tr>"
                            strEmail = strEmail & "<tr style='background-color: white;padding: 15px;text-align: left;'><th style='border: 1px solid black;text-align: left;'>Branch:</th><td style='border: 1px solid black;'>" & lblBranchCode.Text.Trim() & " - " & lblBranchName.Text.Trim() & "</td></tr>"
                            strEmail = strEmail & "<tr style='background-color: #f5f5f5;padding: 15px;text-align: left;'><th style='border: 1px solid black;text-align: left;'>Amount:</th><td style='border: 1px solid black;'>" & FormatCurrency(toMoney(txtFinReqAmt.Text)).ToString() & "</td></tr>"
                            strEmail = strEmail & "</table>"
                            strEmail = strEmail & "<br/>Thanks & Regards,<br/><b>Escrow 360 Support Team</b>"
                            'strEmail = strEmail + "<br/><br/><p style='font-size:10px; color:gray;'>Powered by <a href='escrowsystems.net'>Escrow Systems</a></p>"
                            'If Trim(SignatoryEMail) = "" Then
                            SignatoryEMail = Mailhelper.GetMultipleEMailID(ViewState("NextRole"))
                            'End If
                            Mailhelper.SendMailMessage("administrator", SignatoryEMail, "", "", "Escrow Credit Management - Loan Application", strEmail)
                            'clearAll()
                            Dim EncQuery As New BankEncryption64
                            lblTest.Text = ViewState("globLoanID")
                            lblTestEnc.Text = EncQuery.Encrypt(ViewState("globLoanID").replace(" ", "+"))

                            ClientScript.RegisterStartupScript(Me.GetType(), "HideLabel", "<script type=""text/javascript"">showPopup()</script>")
                            clearAll()
                        End If
                    Catch ex As Exception
                        WriteLogFile(ex.ToString)
                    End Try
                    con.Close()
                End Using
            End Using
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- submitApplication()", ex.ToString)
        End Try
    End Sub
    <WebMethod>
    Public Shared Function getMonthlyInstalment(intMonths As Integer, dblPrincipal As Double, dblAdmin As Double, ProductType As String, dblRate As Double) As Double
        Try
            Dim ds As New DataSet
            Dim dt As New dsPortfolioManagement.MonthlyInstalmentDataTable
            Dim dss As New dsPortfolioManagementTableAdapters.MonthlyInstalmentTableAdapter
            dss.FillByParameters(dt, intMonths, dblPrincipal, dblAdmin, ProductType, dblRate)
            Return dt.Rows(0).Item("Instalment")
        Catch ex As Exception
            'WriteLogFile(Session("UserId"), Request.Url.ToString & " --- getMonthlyInstalment()", ex.ToString)
            Return 0
        End Try
    End Function
    <WebMethod>
    Public Shared Function getDBR(ByVal custNo As String, ByVal prodtype As String, rent As String, sal As String, instal As String) As Double
        Try
            Dim MONTHLY_RENT As Double = 0
            Dim CURR_EMP_NET As Double = 0
            Dim NBS_DBR As Double = 0
            Dim PAYMENT As Double = 0
            Dim TOTLOANOBLG As Double = 0
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd = New SqlCommand("Select * FROM [CreditProducts] where [id]='" & prodtype & "'  SELECT ISNULL(SUM(OTHER_AMT),0) AS OTHERLOANS FROM QUEST_OTHER_LOANS WHERE CUSTOMER_NUMBER ='" & custNo & "' and loanid='0' and (TakeOver is null or TakeOver=0)", con)
                    Dim dsDBR As New DataSet
                    Using adp = New SqlDataAdapter(cmd)
                        adp.Fill(dsDBR, "QUEST_APPLICATION")
                    End Using

                    If IsNumeric(toMoney(rent)) Then
                        MONTHLY_RENT = toMoney(rent) ' txtRent.Text ' CDbl(dsDBR.Tables(0).Rows(0).Item("MONTHLY_RENT"))
                    Else
                        MONTHLY_RENT = 0
                    End If

                    If IsNumeric(toMoney(sal)) Then
                        CURR_EMP_NET = toMoney(sal) ' toMoney(txtEmpSalary.Text)  'CDbl(dsDBR.Tables(0).Rows(0).Item("CURR_EMP_NET"))
                    Else
                        CURR_EMP_NET = 0
                    End If
                    If dsDBR.Tables(0).Rows.Count > 0 Then
                        NBS_DBR = CDbl(dsDBR.Tables(0).Rows(0).Item("DBR_PERC"))
                    Else
                        NBS_DBR = 0
                    End If
                    If IsNumeric(toMoney(instal)) Then
                        PAYMENT = toMoney(instal) ' txtMonthlyPayment.Text ' CDbl(dsDBR.Tables(2).Rows(0).Item("PAYMENT"))
                    Else
                        PAYMENT = 0
                    End If
                    If dsDBR.Tables(1).Rows.Count > 0 Then
                        TOTLOANOBLG = CDbl(dsDBR.Tables(1).Rows(0).Item("OTHERLOANS"))
                    Else
                        TOTLOANOBLG = 0
                    End If
                    Dim dbLim As Double = (PAYMENT + TOTLOANOBLG) / CURR_EMP_NET * 100
                    Return dbLim
                End Using
            End Using
        Catch ex As Exception
            WriteLogFile(ex.ToString)
            Return 0
        End Try
    End Function
End Class