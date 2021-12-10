Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports CreditManager
Imports ErrorLogging

Partial Class Credit_ApplicationApproval
    Inherits System.Web.UI.Page
    Dim adp As SqlDataAdapter
    Dim cmd As SqlCommand
    Dim con As New SqlConnection

    Protected Function amortizationAlreadyCreated(loanID As String) As Boolean
        Dim ds As New DataSet
        Using cmd = New SqlCommand("select * from AMORTIZATION_SCHEDULE where LOANID='" & loanID & "'", con)
            adp = New SqlDataAdapter(cmd)
        End Using
        adp.Fill(ds, "AMO")
        If ds.Tables(0).Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Protected Sub btnDisburse_Click(sender As Object, e As EventArgs) Handles btnDisburse.Click
        Try
            If Trim(txtDisburseDate.Text) = "" Or Not IsDate(txtDisburseDate.Text) Then
                msgbox("Please enter disbursement date")
                'txtDisburseDate.Focus()
            ElseIf Trim(cmbBanks.SelectedItem.Text) = "Select Account" Then
                msgbox("Please select the account to disburse from")
            Else
                If Not chkPartial.Checked Then
                    txtAmtToDisburse.Text = txtFinReqAmt.Text
                End If
                If Convert.ToDouble(txtAmtToDisburse.Text) > Convert.ToDouble(txtFinReqAmt.Text) Then
                    msgbox("Amount to disburse is greater than amount applied")
                Else
                    '''''''''''''''''''''''first save amt to disburse********************
                    '''''''''''''''''''''''RUN IN STORED PROCEDURE************************
                    cmd = New SqlCommand("sp_disburse", con)
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.AddWithValue("@loanID", Request.QueryString("id"))
                    cmd.Parameters.AddWithValue("@amtToDisburse", txtAmtToDisburse.Text.Replace(",", ""))
                    cmd.Parameters.AddWithValue("@disburseDate", txtDisburseDate.Text)
                    cmd.Parameters.AddWithValue("@userID", Session("ID"))
                    If con.State = ConnectionState.Open Then
                        con.Close()
                    End If
                    con.Open()
                    If cmd.ExecuteNonQuery() Then
                        saveComment()
                        recordDisbursalTrans(txtCustNo.Text, Request.QueryString("id"), txtAmtToDisburse.Text)
                        'If Not isAmortized(Request.QueryString("id")) Then
                        createAmortizationOptions(Request.QueryString("id"))
                        'End If

                        Dim cmdAcc = New SqlCommand("SaveAccountsTrxnsTempWithContra", con)
                        cmdAcc.CommandType = CommandType.StoredProcedure
                        cmdAcc.Parameters.AddWithValue("@Type", "System Entry")
                        cmdAcc.Parameters.AddWithValue("@Category", "Loan Disbursement")
                        cmdAcc.Parameters.AddWithValue("@Ref", Request.QueryString("id"))
                        cmdAcc.Parameters.AddWithValue("@Desc", "Disbursement")
                        cmdAcc.Parameters.AddWithValue("@Debit", txtAmtToDisburse.Text.Replace(",", ""))
                        cmdAcc.Parameters.AddWithValue("@Credit", 0.0)
                        cmdAcc.Parameters.AddWithValue("@Account", "213/1") 'loan debtor
                        'cmdAcc.Parameters.AddWithValue("@ContraAccount", IIf(Session("ROLE") = "4045", cmbBanks.SelectedValue, "211/1")) 'cash
                        cmdAcc.Parameters.AddWithValue("@ContraAccount", cmbBanks.SelectedValue)
                        cmdAcc.Parameters.AddWithValue("@Status", 1)
                        cmdAcc.Parameters.AddWithValue("@Other", txtCustNo.Text)
                        cmdAcc.Parameters.AddWithValue("@BankAccID", "")
                        cmdAcc.Parameters.AddWithValue("@BankAccName", "")
                        cmdAcc.Parameters.AddWithValue("@BatchRef", "")
                        cmdAcc.Parameters.AddWithValue("@TrxnDate", txtDisburseDate.Text)
                        cmdAcc.Parameters.AddWithValue("@CaptureBy", Session("UserId"))

                        If con.State = ConnectionState.Open Then
                            con.Close()
                        End If
                        con.Open()
                        cmdAcc.ExecuteNonQuery()
                        con.Close()

                        'new function to insert interest to maturity on disbursement
                        'insertInterestAccounts(Request.QueryString("id"))
                        insertInterestAccountsTemp(Request.QueryString("id"))

                        If Session("ROLE") = "4042" Then
                            Response.Write("<script>alert('Loan successfully recommended') ; location.href='ApplicationView.aspx'</script>")
                        ElseIf Session("ROLE") = "1024" Then
                            Response.Write("<script>alert('Loan successfully disbursed') ; location.href='ApplicationView.aspx'</script>")
                        Else
                            Response.Write("<script>alert('Loan successfully approved') ; location.href='ApplicationView.aspx'</script>")
                        End If
                        Dim strEmail As String
                        Dim SignatoryEMail As String
                        'SignatoryEMail = Mailhelper.GetEMailID(ddl_SendTo.SelectedValue.ToString())

                        strEmail = "<Strong>Dear Sir/Madam,</strong><br>You Have Received A New Loan Application Request. Details are as follows<br><br>"
                        strEmail = strEmail & "<Table bgcolor='444444'><font forecolor='ffffff'>"
                        strEmail = strEmail & "<tr bgcolor='999999'><td>Date:</td><td>" & Now & "</td></tr>"
                        strEmail = strEmail & "<tr bgcolor='eeeeee'><td>Applicant Type:</td><td>" & rdbClientType.SelectedValue & "</td></tr>"
                        strEmail = strEmail & "<tr bgcolor='999999'><td>Branch:</td><td>" & lblBranchCode.Text.Trim() & " - " & lblBranchName.Text.Trim() & "</td></tr>"
                        'strEmail = strEmail & "<tr bgcolor='999999'><td>Branch Name:</td><td>" & txt_BranchName.Text.Trim() & "</td></tr>"
                        strEmail = strEmail & "<tr bgcolor='999999'><td>Client Name:</td><td>" & txtForenames.Text & " " & txtSurname.Text & "</td></tr>"
                        'strEmail = strEmail & "<tr bgcolor='999999'><td>Transaction Type:</td><td>" & ddl_TransactionTy.SelectedItem.Text.Trim() & "</td></tr>"
                        strEmail = strEmail & "<tr bgcolor='999999'><td>Amount:</td><td>" & txtFinReqAmt.Text & "</td></tr>"
                        strEmail = strEmail & "</font></Table>"
                        strEmail = strEmail & "<br><Strong>Thanks & Regards,<br>IT Support Team</strong>"
                        If Session("ROLE") = "4042" Then
                            SignatoryEMail = Mailhelper.GetMultiBranchRoleEMailID(Session("BRANCHCODE"), "4043")
                            If Trim(SignatoryEMail) = "" Then
                                SignatoryEMail = Mailhelper.GetMultipleEMailID("4043")
                            End If
                            Mailhelper.SendMailMessage("administrator", SignatoryEMail, "", "", "Escrow Credit Management - Loan Application", strEmail)
                        ElseIf Session("ROLE") = "4043" Then
                            SignatoryEMail = Mailhelper.GetMultiBranchRoleEMailID(Session("BRANCHCODE"), "4044")
                            If Trim(SignatoryEMail) = "" Then
                                SignatoryEMail = Mailhelper.GetMultipleEMailID("4044")
                            End If
                            Mailhelper.SendMailMessage("administrator", SignatoryEMail, "", "", "Escrow Credit Management - Loan Application", strEmail)
                        End If
                    End If

                End If
            End If

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub btnGenAgrmt_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGenAgrmt.Click
        Try
            Dim strscript As String = "<script langauage=JavaScript>"
            strscript += "window.open('rptAcknowledgement.aspx?ID=" & Request.QueryString("id") & "');"
            strscript += "</script>"
            ClientScript.RegisterStartupScript(Me.GetType(), "newwin", strscript)
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub btnReject_Click(sender As Object, e As EventArgs) Handles btnReject.Click
        Try
            If Trim(txtComment.Text) = "" Then
                notify("Enter the reason for rejecting the application", "error")
                txtComment.Focus()
                Exit Sub
            End If
            Dim retRole = ""
            If Session("ROLE") = "4044" Then
                retRole = "4043"
            ElseIf Session("ROLE") = "4043" Then
                retRole = "4042"
            ElseIf Session("ROLE") = "4042" Then
                retRole = "4041"
            ElseIf Session("ROLE") = "1024" Or Session("ROLE") = "4045" Then
                retRole = "4044"
            End If
            cmd = New SqlCommand("update QUEST_APPLICATION set STATUS='REJECTED', SEND_TO='" & retRole & "',LAST_ID='" & Session("ID") & "',[ApprovalNumber]=[ApprovalNumber]-1 where ID='" & ViewState("loanID") & "'", con)
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            con.Open()
            If cmd.ExecuteNonQuery Then
                Dim comm = ""
                If Trim(txtComment.Text) = "" Then
                    comm = "REJECTED"
                Else
                    comm = txtComment.Text
                End If
                'If Not (Trim(txtComment.Text) = "" Or Trim(txtRecAmt.Text) = "") Then
                saveComment()
                Dim strEmail As String
                Dim SignatoryEMail As String
                'SignatoryEMail = Mailhelper.GetEMailID(ddl_SendTo.SelectedValue.ToString())

                strEmail = "Dear Sir/Madam,<br/><br/>A loan applicaation you processed has been returned. Details of the application are as follows<br><br>"
                strEmail = strEmail & "<table style='border: 1px solid black; width:750px;border-collapse: collapse; font-size:13px'>"
                strEmail = strEmail & "<tr style='background-color: #f5f5f5;padding: 15px;text-align: left;'><th style='border: 1px solid black;text-align: left;'>Client Name:</th><td style='border: 1px solid black;'>" & txtSurname.Text & " " & txtForenames.Text & "</td></tr>"
                strEmail = strEmail & "<tr style='background-color: white;padding: 15px;text-align: left;'><th style='border: 1px solid black;text-align: left;'>Date:</th><td style='border: 1px solid black;'>" & Now & "</td></tr>"
                strEmail = strEmail & "<tr style='background-color: #f5f5f5;padding: 15px;text-align: left;'><th style='border: 1px solid black;text-align: left;'>Applicant Type:</th><td style='border: 1px solid black;'>" & rdbClientType.SelectedValue & "</td></tr>"
                strEmail = strEmail & "<tr style='background-color: white;padding: 15px;text-align: left;'><th style='border: 1px solid black;text-align: left;'>Product:</th><td style='border: 1px solid black;'>" & cmbProductType.SelectedItem.Text.ToString & "</td></tr>"
                strEmail = strEmail & "<tr style='background-color: #f5f5f5;padding: 15px;text-align: left;'><th style='border: 1px solid black;text-align: left;'>Sector:</th><td style='border: 1px solid black;'>" & cmbSector.SelectedItem.Text.ToString & "</td></tr>"
                strEmail = strEmail & "<tr style='background-color: white;padding: 15px;text-align: left;'><th style='border: 1px solid black;text-align: left;'>Branch:</th><td style='border: 1px solid black;'>" & lblBranchCode.Text.Trim() & " - " & lblBranchName.Text.Trim() & "</td></tr>"
                strEmail = strEmail & "<tr style='background-color: #f5f5f5;padding: 15px;text-align: left;'><th style='border: 1px solid black;text-align: left;'>Amount:</th><td style='border: 1px solid black;'>" & FormatCurrency(txtFinReqAmt.Text).ToString.Replace("Z", "US") & "</td></tr>"
                strEmail = strEmail & "</table>"
                strEmail = strEmail & "<br/>Thanks & Regards,<br/><b>Escrow 360 Support Team</b>"
                strEmail = strEmail + "<br/><br/><p style='font-size:10px; color:gray;'>Powered by <a href='escrowsystems.net'>Escrow Systems</a></p>"
                SignatoryEMail = Mailhelper.GetEMailID(ViewState("prev"))
                Mailhelper.SendMailMessage("administrator", SignatoryEMail, "", "", "Escrow Credit Management - Loan Application", strEmail)
                Response.Write("<script>alert('Loan successfully rejected'); location.href='ApplicationView.aspx';</script>")
            Else
                notify("Error saving", "error")
            End If
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- btnReject_Click", ex.ToString)
        End Try
    End Sub

    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        Try
            If Trim(txtRecAmt.Text) = "" Or Not IsNumeric(txtRecAmt.Text) Then
                CreditManager.notify("Enter recommended amount", "error")
                txtRecAmt.Focus()
                Exit Sub
            Else
                If CDbl(txtRecAmt.Text) = 0 Then
                    notify("Recommended amount cannot be 0", "error")
                    txtRecAmt.Focus()
                    Exit Sub
                ElseIf CDbl(txtRecAmt.Text) > CDbl(txtFinReqAmt.Text) Then
                    notify("Recommended amount cannot be greater than the applied amount", "error")
                    txtRecAmt.Focus()
                    Exit Sub
                End If
            End If
            If ViewState("StageAction") = "Disbursement" And btnSubmit.Text = "Disburse" Then
                ' btnDisburse_Click(sender, New EventArgs)
            Else
                Dim cmdStr As String = ""
                If ViewState("StageMulti") = "Y" Then
                    If NoOfRoundRobin(Session("ROLE"), ViewState("loanID")) + 1 > ViewState("StageNoApps") Then
                        'all round robin stages done, move to next level
                        'If SSB send to ssb download
                        If rdbSubIndividual.SelectedValue = "SSB" Then
                            cmdStr = "update QUEST_APPLICATION set [RECOMMENDED_AMT]='" & toMoney(txtRecAmt.Text) & "',STATUS='SSB Approval',SEND_TO='1024',SSB_FileNo=0,LAST_ID='" & Session("ID") & "',[ApprovalNumber]=[ApprovalNumber] where ID='" & ViewState("loanID") & "'"
                        Else
                            'cmdStr = "update QUEST_APPLICATION set STATUS='" & ViewState("StageName") & "',SEND_TO='" & ViewState("NextRole") & "',LAST_ID='" & Session("ID") & "',[ApprovalNumber]=[ApprovalNumber]+1 where ID='" & ViewState("loanID") & "'"
                            cmdStr = "update QUEST_APPLICATION set [RECOMMENDED_AMT]='" & toMoney(txtRecAmt.Text) & "',STATUS='" & ViewState("StageName") & "',SEND_TO='" & ViewState("NextRole") & "',LAST_ID='" & Session("ID") & "',[ApprovalNumber]='" & ViewState("NextAppNo") - 1 & "' where ID='" & ViewState("loanID") & "'"
                        End If
                    Else 'If NoOfRoundRobin(Session("ROLE"), ViewState("loanID")) < ViewState("StageNoApps") Then
                        'more round robin stages
                        'send to, stage name,status,approval number doesnt change
                        cmdStr = "update QUEST_APPLICATION set [RECOMMENDED_AMT]='" & toMoney(txtRecAmt.Text) & "',LAST_ID='" & Session("ID") & "' where ID='" & ViewState("loanID") & "'"
                    End If
                Else
                    'cmdStr = "update QUEST_APPLICATION set STATUS='" & ViewState("StageName") & "',SEND_TO='" & ViewState("NextRole") & "',LAST_ID='" & Session("ID") & "',[ApprovalNumber]=[ApprovalNumber]+1 where ID='" & ViewState("loanID") & "'"
                    cmdStr = "update QUEST_APPLICATION set [RECOMMENDED_AMT]='" & toMoney(txtRecAmt.Text) & "',STATUS='" & ViewState("StageName") & "',SEND_TO='" & ViewState("NextRole") & "',LAST_ID='" & Session("ID") & "',[ApprovalNumber]='" & ViewState("NextAppNo") - 1 & "' where ID='" & ViewState("loanID") & "'"
                End If

                'Dim cmdSubmit = New SqlCommand("update QUEST_APPLICATION set STATUS='" & ViewState("StageName") & "',SEND_TO='" & ViewState("NextRole") & "',LAST_ID='" & Session("ID") & "',[ApprovalNumber]=[ApprovalNumber]+1,[RECOMMENDED_AMT]='" & toMoney(txtRecAmt.Text) & "' where ID='" & ViewState("loanID") & "'", con)
                Dim cmdSubmit = New SqlCommand(cmdStr, con)
                If con.State = ConnectionState.Open Then
                    con.Close()
                End If
                con.Open()
                If cmdSubmit.ExecuteNonQuery() Then
                    saveComment()
                    If btnSubmit.Text = "Recommend" Then
                        Response.Write("<script>alert('Loan successfully recommended') ; location.href='ApplicationView.aspx'</script>")
                    ElseIf btnSubmit.Text = "Approve" Then
                        Response.Write("<script>alert('Loan successfully approved') ; location.href='ApplicationView.aspx'</script>")
                    ElseIf btnSubmit.Text = "Disburse" Then
                        Response.Write("<script>alert('Loan successfully disbursed') ; location.href='ApplicationView.aspx'</script>")
                    End If
                    Dim strEmail As String
                    Dim SignatoryEMail As String
                    strEmail = "Dear Sir/Madam,<br/><br/>You have received a request for " & ViewState("NextStageName") & ". Details of the application are as follows<br><br>"
                    strEmail = strEmail & "<table style='border: 1px solid black; width:750px;border-collapse: collapse; font-size:13px'>"
                    strEmail = strEmail & "<tr style='background-color: #f5f5f5;padding: 15px;text-align: left;'><th style='border: 1px solid black;text-align: left;'>Client Name:</th><td style='border: 1px solid black;'>" & txtSurname.Text & " " & txtForenames.Text & "</td></tr>"
                    strEmail = strEmail & "<tr style='background-color: white;padding: 15px;text-align: left;'><th style='border: 1px solid black;text-align: left;'>Date:</th><td style='border: 1px solid black;'>" & Now & "</td></tr>"
                    strEmail = strEmail & "<tr style='background-color: #f5f5f5;padding: 15px;text-align: left;'><th style='border: 1px solid black;text-align: left;'>Applicant Type:</th><td style='border: 1px solid black;'>" & rdbClientType.SelectedValue & "</td></tr>"
                    strEmail = strEmail & "<tr style='background-color: white;padding: 15px;text-align: left;'><th style='border: 1px solid black;text-align: left;'>Product:</th><td style='border: 1px solid black;'>" & cmbProductType.SelectedItem.Text.ToString & "</td></tr>"
                    strEmail = strEmail & "<tr style='background-color: #f5f5f5;padding: 15px;text-align: left;'><th style='border: 1px solid black;text-align: left;'>Sector:</th><td style='border: 1px solid black;'>" & cmbSector.SelectedItem.Text.ToString & "</td></tr>"
                    strEmail = strEmail & "<tr style='background-color: white;padding: 15px;text-align: left;'><th style='border: 1px solid black;text-align: left;'>Branch:</th><td style='border: 1px solid black;'>" & lblBranchCode.Text.Trim() & " - " & lblBranchName.Text.Trim() & "</td></tr>"
                    strEmail = strEmail & "<tr style='background-color: #f5f5f5;padding: 15px;text-align: left;'><th style='border: 1px solid black;text-align: left;'>Amount:</th><td style='border: 1px solid black;'>" & FormatCurrency(txtFinReqAmt.Text).ToString.Replace("Z", "US") & "</td></tr>"
                    strEmail = strEmail & "</table>"
                    strEmail = strEmail & "<br/>Thanks & Regards,<br/><b>Escrow 360 Support Team</b>"
                    strEmail = strEmail + "<br/><br/><p style='font-size:10px; color:gray;'>Powered by <a href='escrowsystems.net'>Escrow Systems</a></p>"

                    SignatoryEMail = Mailhelper.GetMultipleEMailID(ViewState("NextRole"))
                    'Mailhelper.SendMailMessage("administrator", SignatoryEMail, "", "", "Escrow 360 Credit Management - Loan Application", strEmail)

                    If ViewState("StageMulti") = "Y" Then
                        If NoOfRoundRobin(Session("ROLE"), ViewState("loanID")) + 1 > ViewState("StageNoApps") Then
                            'all round robin stages done, move to next level
                            Mailhelper.SendMailMessage("administrator", SignatoryEMail, "", "", "Escrow 360 Credit Management - Loan Application", strEmail)
                        Else 'If NoOfRoundRobin(Session("ROLE"), ViewState("loanID")) < ViewState("StageNoApps") Then
                            'more round robin stages
                        End If
                    Else
                        Mailhelper.SendMailMessage("administrator", SignatoryEMail, "", "", "Escrow 360 Credit Management - Loan Application", strEmail)
                    End If

                End If
                con.Close()
            End If
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- btnSubmit_Click()", ex.ToString)
        End Try
    End Sub

    Protected Function NoOfRoundRobin(role As String, loanID As String) As Integer
        Try
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd As New SqlCommand("select count(id) as NoApps from REQUEST_HISTORY where Approved=1 AND ROLEID='" & role & "' AND LOANID='" & loanID & "'", con)
                    Dim dt As New DataTable
                    Using adp As New SqlDataAdapter(cmd)
                        adp.Fill(dt)
                    End Using
                    If dt.Rows.Count > 0 Then
                        Return dt.Rows(0).Item("NoApps")
                    Else
                        Return 0
                    End If
                End Using
            End Using
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- NoOfRoundRobin()", ex.ToString)
            Return 0
        End Try
    End Function

    Protected Sub chkPartial_CheckedChanged(sender As Object, e As EventArgs) Handles chkPartial.CheckedChanged
        If chkPartial.Checked Then
            modalDisburse.Visible = True
        Else
            modalDisburse.Visible = False
        End If
    End Sub

    Protected Sub chkTickSSB_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkTickSSB.CheckedChanged
        Try
            If chkTickSSB.Checked Then
                lblTickSSB.Visible = False
                btnSubmit.Enabled = True
            Else
                lblTickSSB.Visible = True
                btnSubmit.Enabled = False
            End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub createAmortizationOptions(ByVal loanID As String)
        Try
            cmd = New SqlCommand("select * from QUEST_APPLICATION where ID='" & loanID & "'", con)
            Dim ds As New DataSet
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "LOANS")
            Dim repOpt As String = ""
            Dim intSett As String = ""
            If ds.Tables(0).Rows.Count > 0 Then
                If ds.Tables(0).Rows(0).Item("FIN_REPAY_OPT") = "Interest" Then
                    'amortizeSimple(loanID)
                    cmd = New SqlCommand("sp_amortize_simple_daily", con)
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.AddWithValue("@loanID", loanID)
                ElseIf ds.Tables(0).Rows(0).Item("FIN_REPAY_OPT") = "Balance" Then
                    'amortizeNormal(loanID)
                    cmd = New SqlCommand("sp_amortize_normal_daily", con)
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.AddWithValue("@loanID", loanID)
                    'amortizeInterestFixed(loanID)
                Else
                    'amortizeNormal(loanID)
                    cmd = New SqlCommand("sp_amortize_normal_daily", con)
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.AddWithValue("@loanID", loanID)
                End If
                If con.State <> ConnectionState.Closed Then
                    con.Close()
                End If
                con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            End If
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- createAmortizationOptions(" & loanID & ")", ex.Message)
            msgbox("Unable to create amortization schedule. Make sure all parameters are entered")
        End Try
    End Sub

    'Protected Sub ddlAssets_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlAssets.SelectedIndexChanged
    '    txtFinReqAmt.Text = ddlAssets.SelectedValue
    'End Sub

    Protected Sub getAppDetails(ByVal loanID As String)
        Try
            cmd = New SqlCommand("select *,convert(varchar,DOB,106) as DOB1,convert(varchar,ISSUE_DATE,106) as ISSUE_DATE1,convert(varchar,GUARANTOR_DOB,106) as GUARANTOR_DOB1,convert(varchar,FIN_REPAY_DATE,106) as FIN_REPAY_DATE1,convert(varchar,APPL_DATE,106) as APPL_DATE1 from QUEST_APPLICATION where ID='" & loanID & "'", con)
            Dim ds As New DataSet
            Dim adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "APP")
            If ds.Tables(0).Rows.Count > 0 Then
                Try
                    ViewState("prev") = ds.Tables(0).Rows(0).Item("LAST_ID")
                Catch ex As Exception
                    ViewState("prev") = ""
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
                    cmbOwner.SelectedValue = BankString.isNullString(ds.Tables(0).Rows(0).Item("ClientOwner"))
                Catch ex As Exception
                    cmbOwner.ClearSelection()
                End Try
                Try
                    lblLoanCycle.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("LoanCycle"))
                Catch ex As Exception

                End Try
                Try
                    txtApplicationDate.Text = displayDate(BankString.isNullString(ds.Tables(0).Rows(0).Item("APPL_DATE1")))
                Catch ex As Exception
                End Try
                Try
                    txtEmpHowLong.Text = FormatNumber(BankString.isNullString(ds.Tables(0).Rows(0).Item("CURR_EMP_LENGTH")), 0)
                Catch ex As Exception
                    txtEmpHowLong.Text = ""
                End Try
                Try
                    txtEmpOtherIncome.Text = FormatNumber(BankString.isNullString(ds.Tables(0).Rows(0).Item("CURR_EMP_INCOME")), 2)
                Catch ex As Exception

                End Try
                Try
                    chkExtension.Checked = BankString.isNullString(ds.Tables(0).Rows(0).Item("Extension"))
                Catch ex As Exception

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
                    txtGuarEmpLength.Text = FormatNumber(BankString.isNullString(ds.Tables(0).Rows(0).Item("GUARANTOR_EMP_LENGTH")), 0)
                Catch ex As Exception
                    txtGuarEmpLength.Text = 0
                End Try
                Try
                    txtGuarEmpIncome.Text = FormatNumber(BankString.isNullString(ds.Tables(0).Rows(0).Item("GUARANTOR_EMP_INCOME")), 2)
                Catch ex As Exception
                    txtGuarEmpIncome.Text = 0
                End Try
                txtGuarEmpPhone.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("GUARANTOR_EMP_PHONE"))
                txtGuarEmpPosition.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("GUARANTOR_EMP_POSTN"))
                Try
                    txtGuarHomeLength.Text = FormatNumber(BankString.isNullString(ds.Tables(0).Rows(0).Item("GUARANTOR_HOME_LENGTH")), 0)
                Catch ex As Exception
                    txtGuarHomeLength.Text = ""
                End Try
                Try
                    txtGuarEmpSalary.Text = FormatNumber(BankString.isNullString(ds.Tables(0).Rows(0).Item("GUARANTOR_EMP_SALARY")), 2)
                Catch ex As Exception
                    txtGuarEmpSalary.Text = ""
                End Try
                txtGuarIDNo.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("GUARANTOR_IDNO"))
                Try
                    txtGuarMonthRent.Text = FormatNumber(BankString.isNullString(ds.Tables(0).Rows(0).Item("GUARANTOR_RENT")), 2)
                Catch ex As Exception
                    txtGuarMonthRent.Text = ""
                End Try
                Try
                    cmbSector.SelectedValue = BankString.isNullString(ds.Tables(0).Rows(0).Item("Sector"))
                    'msgbox(cmbSector.Items.Count)
                Catch ex As Exception
                    cmbSector.ClearSelection()
                End Try
                txtGuarName.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("GUARANTOR_NAME"))
                txtGuarNameRelative.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("GUARANTOR_REL_NAME"))
                txtGuarPhone.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("GUARANTOR_PHONE"))
                txtGuarRelAddress.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("GUARANTOR_REL_ADD"))
                txtGuarRelCity.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("GUARANTOR_REL_CITY"))
                txtGuarRelPhone.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("GUARANTOR_REL_PHONE"))
                txtGuarRelReltnship.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("GUARANTOR_REL_RELTNSHP"))
                txtFinReqAccNo.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("FIN_ACCNO"))
                Try
                    txtFinReqAmt.Text = FormatNumber(BankString.isNullString(ds.Tables(0).Rows(0).Item("FIN_AMT")), 2)
                Catch ex As Exception
                    txtFinReqAmt.Text = ""
                End Try
                Try
                    'txtRecAmt.Text = FormatNumber(BankString.isNullString(ds.Tables(0).Rows(0).Item("FIN_AMT")), 2)
                    txtRecAmt.Text = FormatNumber(BankString.isNullString(ds.Tables(0).Rows(0).Item("RECOMMENDED_AMT")), 2)
                Catch ex As Exception
                    txtRecAmt.Text = ""
                End Try

                Try
                    txtAmtToDisburse.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("FIN_AMT"))
                Catch ex As Exception
                    txtAmtToDisburse.Text = ""
                End Try

                txtFinReqBank.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("FIN_BANK"))
                txtFinReqBranchCode.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("FIN_BRANCH_CODE"))
                txtFinReqBranchName.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("FIN_BRANCH"))
                txtFinReqIntRate.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("FIN_INT_RATE"))
                txtFinReqPurpose.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("FIN_PURPOSE"))
                txtFinReqSecOffer.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("FIN_SEC_OFFER"))
                txtFinReqSource.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("FIN_SRC_REPAYMT"))
                Try
                    txtFinReqTenor.Text = FormatNumber(BankString.isNullString(ds.Tables(0).Rows(0).Item("FIN_TENOR")), 0)
                Catch ex As Exception
                    txtFinReqTenor.Text = ""
                End Try
                txtQuesAgent.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("QUES_AGENT"))
                txtQuesEmployee.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("QUES_EMPLOYEE"))
                Try
                    txtInterestRate.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("INT_RATE"))
                Catch ex As Exception
                End Try
                Try
                    txtInsuranceRate.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("INSURANCE_RATE"))
                Catch ex As Exception
                End Try
                Try
                    txtAdminRate.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("ADMIN_RATE"))
                Catch ex As Exception
                End Try
                Try
                    cmbProductType.SelectedValue = BankString.isNullString(ds.Tables(0).Rows(0).Item("FinProductType"))
                Catch ex As Exception
                    cmbProductType.ClearSelection()
                End Try
                Try
                    loadOtherLoans()
                Catch ex As Exception

                End Try
                Try
                    getClientCollateral(txtCustNo.Text, loanID)
                Catch ex As Exception

                End Try

                Try
                    rdbClientType.SelectedValue = ds.Tables(0).Rows(0).Item("CUSTOMER_TYPE")
                Catch ex As Exception
                    rdbClientType.ClearSelection()
                End Try
                Try
                    rdbGender.SelectedValue = ds.Tables(0).Rows(0).Item("GENDER")
                Catch ex As Exception
                    rdbGender.ClearSelection()
                End Try
                Try
                    cmbEducation.SelectedValue = ds.Tables(0).Rows(0).Item("EDUCATION")
                Catch ex As Exception
                    cmbEducation.ClearSelection()
                End Try
                Try
                    rdbQuesHow.SelectedValue = ds.Tables(0).Rows(0).Item("QUES_HOW")
                Catch ex As Exception
                    rdbQuesHow.ClearSelection()
                End Try
                Try
                    rdbGuarHomeType.SelectedValue = ds.Tables(0).Rows(0).Item("GUARANTOR_HOME_TYPE")
                Catch ex As Exception
                    rdbGuarHomeType.ClearSelection()
                End Try
                Try
                    cmbMaritalStatus.SelectedValue = ds.Tables(0).Rows(0).Item("MARITAL_STATUS")
                Catch ex As Exception
                    cmbMaritalStatus.ClearSelection()
                End Try
                Try
                    rdbHouse.SelectedValue = ds.Tables(0).Rows(0).Item("HOME_TYPE")
                Catch ex As Exception
                    rdbHouse.ClearSelection()
                End Try

                Try
                    cmbFinReqPurpose.SelectedValue = BankString.isNullString(ds.Tables(0).Rows(0).Item("FIN_PURPOSE"))
                Catch ex As Exception
                    cmbFinReqPurpose.ClearSelection()
                End Try
                Try
                    rdbFinReqDisburseOption.SelectedValue = ds.Tables(0).Rows(0).Item("DISBURSE_OPTION")
                Catch ex As Exception
                    rdbFinReqDisburseOption.ClearSelection()
                End Try

                If BankString.isNullString(ds.Tables(0).Rows(0).Item("DOB1")) = "01 Jan 1900" Then
                    bdpDOB.Text = ""
                Else
                    bdpDOB.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("DOB1"))
                End If
                If BankString.isNullString(ds.Tables(0).Rows(0).Item("ISSUE_DATE1")) = "01 Jan 1900" Then
                    bdpIssDate.Text = ""
                Else
                    bdpIssDate.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("ISSUE_DATE1"))
                End If
                Try
                    If BankString.isNullString(ds.Tables(0).Rows(0).Item("GUARANTOR_DOB1")) = "01 Jan 1900" Then
                        bdpGuarDOB.Text = ""
                    Else
                        bdpGuarDOB.Text = ds.Tables(0).Rows(0).Item("GUARANTOR_DOB1")
                    End If
                Catch ex As Exception
                End Try
                If BankString.isNullString(ds.Tables(0).Rows(0).Item("FIN_REPAY_DATE1")) = "01 Jan 1900" Then
                    bdpFinReqRepaymt.Text = ""
                Else
                    bdpFinReqRepaymt.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("FIN_REPAY_DATE1"))
                End If

                Try
                    cmbBank.SelectedValue = BankString.isNullString(ds.Tables(0).Rows(0).Item("Bank"))
                Catch ex As Exception
                    cmbBank.ClearSelection()
                End Try
                loadBankBranches(BankString.isNullString(ds.Tables(0).Rows(0).Item("Bank")), cmbBankBranch)
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

                getNextApproval(cmbProductType.SelectedValue, ds.Tables(0).Rows(0).Item("ApprovalNumber") + 1)
                If rdbClientType.SelectedValue = "Individual" Then
                    Try
                        rdbSubIndividual.Visible = True
                        rdbSubIndividual.SelectedValue = ds.Tables(0).Rows(0).Item("SUB_INDIVIDUAL")
                    Catch ex As Exception

                    End Try
                    Try
                        cmbBankAppType.SelectedValue = BankString.isNullString(ds.Tables(0).Rows(0).Item("AppTypeBank"))
                    Catch ex As Exception
                        cmbBankAppType.ClearSelection()
                    End Try
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
                    lblSurname.Text = "Surname"
                    lblForenames.Text = "Forenames"
                    lblForenames.Visible = True
                    txtForenames.Visible = True
                ElseIf rdbClientType.SelectedValue = "Business" Then
                    lblSurname.Text = "Name"
                    lblForenames.Visible = False
                    txtForenames.Visible = False
                    txtForenames.Text = ""
                End If
                If rdbSubIndividual.SelectedValue = "SSB" Then
                    txtMinDept.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("MIN_DEPT"))
                    txtMinDeptNo.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("MIN_DEPT_NO"))
                    txtECNo.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("ECNO"))
                    txtECNoCD.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("CD"))

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
                    txtEcocashNumber.Text = ds.Tables(0).Rows(0).Item("ECOCASH_NUMBER")
                End If
            Else
            End If
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- getAppDetails()", ex.ToString)
        End Try
    End Sub

    Protected Sub cmbBank_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbBank.SelectedIndexChanged
        loadBankBranches(cmbBank.SelectedValue, cmbBankBranch)
    End Sub

    Protected Sub cmbBankAppType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbBankAppType.SelectedIndexChanged
        loadBranch(cmbBranchAppType, cmbBankAppType)
    End Sub

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
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- loadBranch()", ex.Message)
        End Try
    End Sub

    Protected Sub getAppHistory()
        Try
            cmd = New SqlCommand("select convert(varchar,COMMENT_DATE,113) as [DATE], USERID as [USER],CONVERT(DECIMAL(30,2),[RECOMMENDED_AMT]) as [RECOMMENDED AMOUNT],COMMENT from REQUEST_HISTORY where LOANID='" & ViewState("loanID") & "' order by COMMENT_DATE", con)
            Dim ds As New DataSet
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "COMMENT")
            If ds.Tables(0).Rows.Count > 0 Then
                grdAppHistory.DataSource = ds.Tables(0)
            Else
                grdAppHistory.DataSource = Nothing
            End If
            grdAppHistory.DataBind()
        Catch ex As Exception

        End Try
    End Sub

    Protected Function getBatchNo() As String
        Try
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd As New SqlCommand("select max(isnull(nullif(SUBSTRING(BatchRef,4,10),''),0)) as MaxBatch from Accounts_Transactions where Category='Disbursment'", con)
                    Dim ds As New DataSet
                    Dim adp = New SqlDataAdapter(cmd)
                    adp.Fill(ds, "APP")
                    Dim batchNo = ""
                    If ds.Tables(0).Rows(0).Item("MaxBatch") = 0 Then
                        batchNo = "10001"
                    Else
                        batchNo = ds.Tables(0).Rows(0).Item("MaxBatch") + 1
                    End If
                    Return "Dis" & batchNo
                End Using
            End Using
        Catch ex As Exception
            ErrorLogging.WriteLogFile(Session("UserId"), Request.Url.ToString & " --- getBatchNo()", ex.Message)
            Return ""
        End Try
    End Function

    Protected Function getCommand(ByVal roleID As String) As SqlCommand
        Dim comm As New SqlCommand
        comm = New SqlCommand("update QUEST_APPLICATION set STATUS='" & ViewState("StageName") & "',SEND_TO='" & ViewState("NextRole") & "',LAST_ID='" & Session("ID") & "' where ID='" & ViewState("loanID") & "'", con)
        Return comm
    End Function

    Protected Function getEducation() As String
        If cmbEducation.SelectedValue = "Other" Then
            Return Trim("Other: " & BankString.removeSpecialCharacter(txtEducationOther.Text))
        Else
            Return cmbEducation.SelectedValue
        End If
    End Function
    Protected Sub getNextApproval(prd As String, currLevel As Integer)
        Try
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd = New SqlCommand("select * from [ParaApprovalStages] where [StageOrder]='" & currLevel - 1 & "' AND FinProductType='" & prd & "'", con)
                    Dim ds As New DataSet
                    Dim adp = New SqlDataAdapter(cmd)
                    adp.Fill(ds, "PAS")
                    If ds.Tables(0).Rows.Count > 0 Then
                        Dim dr = ds.Tables(0).Rows(0)
                        ViewState("PrevStageNameRej") = dr("StageName")
                        ViewState("PrevStageActionRej") = dr("StageAction")
                    End If
                End Using
                Using cmd = New SqlCommand("select * from [ParaApprovalStages] where [StageOrder]='" & currLevel & "' AND FinProductType='" & prd & "'", con)
                    Dim ds As New DataSet
                    Dim adp = New SqlDataAdapter(cmd)
                    adp.Fill(ds, "PAS")
                    If ds.Tables(0).Rows.Count > 0 Then
                        Dim dr = ds.Tables(0).Rows(0)
                        ViewState("StageName") = dr("StageName")
                        ViewState("StageAction") = dr("StageAction")
                        ViewState("StageMulti") = BankString.isNullString(dr("IsRoundRobin"))
                        ViewState("StageNoApps") = BankString.isNullString(dr("NoOfApprovers"))
                        ViewState("StageLimit") = BankString.isNullString(dr("LoanBasedLimit"))
                        ViewState("StageLimitAmt") = BankString.isNullString(dr("LimitAmount"))
                        ViewState("AppNo") = BankString.isNullString(dr("StageOrder"))
                    End If
                End Using
                Using cmd = New SqlCommand("select * from [ParaApprovalStages] where [StageOrder]='" & currLevel + 1 & "' AND FinProductType='" & prd & "'", con)
                    Dim ds As New DataSet
                    Dim adp = New SqlDataAdapter(cmd)
                    adp.Fill(ds, "PAS")
                    If ds.Tables(0).Rows.Count > 0 Then
                        Dim dr = ds.Tables(0).Rows(0)
                        ViewState("NextRole") = dr("RoleId")
                        ViewState("NextStageName") = dr("StageName")
                        ViewState("NextStageLimit") = BankString.isNullString(dr("LoanBasedLimit"))
                        ViewState("NextStageLimitAmt") = BankString.isNullString(dr("LimitAmount"))
                        ViewState("NextAppNo") = BankString.isNullString(dr("StageOrder"))
                        'WriteLogFile("Limit Based: " & ViewState("NextStageLimit") & "; Limit Amount: " & ViewState("NextStageLimitAmt") & "; Applied Amount: " & txtFinReqAmt.Text)
                        If ViewState("NextStageLimit") = "Y" Then
                            'If txtRecAmt.Text <= CDbl(MyBase.ViewState("NextStageLimitAmt")) Then
                            If txtFinReqAmt.Text <= CDbl(ViewState("NextStageLimitAmt")) Then
                                Using cmdNext = New SqlCommand("select * from [ParaApprovalStages] where [StageOrder]='" & currLevel + 2 & "' AND FinProductType='" & prd & "'", con)
                                    Dim dt As New DataTable
                                    Using adpNext As New SqlDataAdapter(cmdNext)
                                        adpNext.Fill(dt)
                                    End Using
                                    If dt.Rows.Count > 0 Then
                                        ViewState("NextRole") = dt.Rows(0)("RoleId")
                                        ViewState("NextStageName") = dt.Rows(0)("StageName")
                                        ViewState("NextAppNo") = BankString.isNullString(dt.Rows(0)("StageOrder"))
                                        'WriteLogFile("Next role: " & ViewState("NextRole") & "; Next stage: " & ViewState("NextStageName"))
                                    End If
                                End Using
                            Else
                            End If
                        End If

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

    Protected Sub grdDocuments_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles grdDocuments.PageIndexChanging
        grdDocuments.PageIndex = e.NewPageIndex
        loadUploadedFiles(ViewState("loanID"))
    End Sub

    Protected Sub grdDocuments_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles grdDocuments.RowCommand
        If e.CommandName = "Select" Then
            Dim docID = e.CommandArgument
            'lblDetailID.Text = docID
            'btnModalPopup.Visible = True
            Dim strscript As String

            strscript = "<script langauage=JavaScript>"
            strscript += "window.open('viewDocument.aspx?id=" & docID & "');"
            strscript += "</script>"
            'ClientScript.RegisterStartupScript(Me.GetType(), "HideLabel", "<script type=""text/javascript"">setTimeout(""document.getElementById('" & lblAppUploadMsg.ClientID & "').style.display='none'"",5000)</script>")
            ClientScript.RegisterStartupScript(Me.GetType(), "newwin", strscript)

        End If
    End Sub

    Protected Sub insertInterestAccounts(loanID As String)
        'get ineterest to maturity
        Dim cmdInt = New SqlCommand("select max(cumulative_interest) from AMORTIZATION_SCHEDULE where LOANID='" & loanID & "'", con)
        Dim intToMaturity As Double = 0
        If con.State <> ConnectionState.Closed Then
            con.Close()
        End If
        con.Open()
        intToMaturity = cmdInt.ExecuteScalar
        con.Close()

        cmd = New SqlCommand("SaveAccountsTrxns", con)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@Type", "System Entry")
        cmd.Parameters.AddWithValue("@Category", "Interest Payable")
        cmd.Parameters.AddWithValue("@Ref", loanID)
        cmd.Parameters.AddWithValue("@Desc", "Interest to Maturity")
        cmd.Parameters.AddWithValue("@Debit", intToMaturity)
        cmd.Parameters.AddWithValue("@Credit", 0.0)
        cmd.Parameters.AddWithValue("@Account", "213/1")
        cmd.Parameters.AddWithValue("@ContraAccount", "223/1")
        cmd.Parameters.AddWithValue("@Status", 1)
        cmd.Parameters.AddWithValue("@Other", txtCustNo.Text)
        cmd.Parameters.AddWithValue("@BankAccID", "")
        cmd.Parameters.AddWithValue("@BankAccName", "")
        cmd.Parameters.AddWithValue("@BatchRef", "")
        cmd.Parameters.AddWithValue("@TrxnDate", txtDisburseDate.Text)

        Dim cmd1 = New SqlCommand("SaveAccountsTrxns", con)
        cmd1.CommandType = CommandType.StoredProcedure
        cmd1.Parameters.AddWithValue("@Type", "System Entry")
        cmd1.Parameters.AddWithValue("@Category", "Interest Payable")
        cmd1.Parameters.AddWithValue("@Ref", loanID)
        cmd1.Parameters.AddWithValue("@Desc", "Interest to Maturity")
        cmd1.Parameters.AddWithValue("@Debit", 0.0)
        cmd1.Parameters.AddWithValue("@Credit", intToMaturity)
        cmd1.Parameters.AddWithValue("@Account", "223/1") 'unearned interest
        cmd1.Parameters.AddWithValue("@ContraAccount", "213/1") 'loan and advances
        cmd1.Parameters.AddWithValue("@Status", 1)
        cmd1.Parameters.AddWithValue("@Other", txtCustNo.Text)
        cmd1.Parameters.AddWithValue("@BankAccID", "")
        cmd1.Parameters.AddWithValue("@BankAccName", "")
        cmd1.Parameters.AddWithValue("@BatchRef", "")
        cmd1.Parameters.AddWithValue("@TrxnDate", txtDisburseDate.Text)

        If con.State = ConnectionState.Open Then
            con.Close()
        End If
        con.Open()
        cmd.ExecuteNonQuery()
        cmd1.ExecuteNonQuery()
        con.Close()
    End Sub

    Protected Sub insertInterestAccountsTemp(loanID As String)
        'get ineterest to maturity
        Dim cmdInt = New SqlCommand("select max(cumulative_interest) from AMORTIZATION_SCHEDULE where LOANID='" & loanID & "'", con)
        Dim intToMaturity As Double = 0
        If con.State <> ConnectionState.Closed Then
            con.Close()
        End If
        con.Open()
        intToMaturity = cmdInt.ExecuteScalar
        con.Close()

        Using cmd = New SqlCommand("SaveAccountsTrxnsTempWithContra", con)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@Type", "System Entry")
            cmd.Parameters.AddWithValue("@Category", "Interest Payable")
            cmd.Parameters.AddWithValue("@Ref", loanID)
            cmd.Parameters.AddWithValue("@Desc", "Interest to Maturity")
            cmd.Parameters.AddWithValue("@Debit", intToMaturity)
            cmd.Parameters.AddWithValue("@Credit", 0.0)
            cmd.Parameters.AddWithValue("@Account", "213/1")
            cmd.Parameters.AddWithValue("@ContraAccount", "223/1")
            cmd.Parameters.AddWithValue("@Status", 1)
            cmd.Parameters.AddWithValue("@Other", txtCustNo.Text)
            cmd.Parameters.AddWithValue("@BankAccID", "")
            cmd.Parameters.AddWithValue("@BankAccName", "")
            cmd.Parameters.AddWithValue("@BatchRef", "")
            cmd.Parameters.AddWithValue("@TrxnDate", txtDisburseDate.Text)
            cmd.Parameters.AddWithValue("@CaptureBy", Session("UserId"))
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        End Using
    End Sub

    Protected Sub isValidSession()
        If Trim(Session("UserID")) = "" Then
            Response.Redirect("~/Logout.aspx")
        Else
        End If
    End Sub

    Protected Sub loadAppForm()
        Try
            cmd = New SqlCommand("select [APP_FORM],[APP_FORM_EXT] from QUEST_APPLICATION where ID = '" & Request.QueryString("id") & "'", con)
            Dim ds As New DataSet
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "appForm")
            If ds.Tables(0).Rows.Count > 0 Then
                Dim fileData As Byte() = DirectCast(ds.Tables(0).Rows(0).Item("APP_FORM"), Byte())
                Dim sTempFileName As String = Server.MapPath("~/Images/" & Request.QueryString("id") & "_AppForm" & ds.Tables(0).Rows(0).Item("APP_FORM_EXT"))
                Using fs As New FileStream(sTempFileName, FileMode.OpenOrCreate, FileAccess.Write)
                    fs.Write(fileData, 0, fileData.Length)
                    fs.Flush()
                    fs.Close()
                End Using
                lnkViewAppForm.Visible = True
                lnkViewAppForm.NavigateUrl = "~/Images/" & Request.QueryString("id") & "_AppForm" & ds.Tables(0).Rows(0).Item("APP_FORM_EXT")
                lnkViewAppForm.Target = "_blank"
            End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub loadClientTypes()
        Try
            cmd = New SqlCommand("select * from PARA_CLIENT_TYPES", con)
            Dim ds As New DataSet
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "Clients")
            If ds.Tables(0).Rows.Count > 0 Then
                rdbClientType.DataSource = ds.Tables(0)
                rdbClientType.DataValueField = "CLIENT_TYPE"
                rdbClientType.DataTextField = "CLIENT_TYPE"
            Else
                rdbClientType.DataSource = Nothing
            End If
            rdbClientType.DataBind()
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub loadDropDown(mainAcc As String)
        Try
            Using cmd = New SqlCommand("select convert(varchar,MainAccount)  + '/' + convert(varchar,SubAccount) as AccountNo, AccountName  + '  ' + convert(varchar,MainAccount)  + '/' + convert(varchar,SubAccount) as AccountName from tbl_FinancialAccountsCreation where MainAccount='" & mainAcc & "'", con)
                'End if
                Dim ds As New DataSet
                Using adp = New SqlDataAdapter(cmd)
                    adp.Fill(ds, "LRS2")
                End Using
                cmbBanks.Visible = True
                loadCombo(ds.Tables(0), cmbBanks, "AccountName", "AccountNo")
            End Using
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub loadOtherLoans()
        Try
            Using cmd = New SqlCommand("select [OTHER_DESC],[OTHER_ACCNO],FORMAT([OTHER_AMT],'c') as [OTHER_AMT] from QUEST_OTHER_LOANS where CUSTOMER_NUMBER='" & txtCustNo.Text & "'", con)
                Dim ds As New DataSet
                adp = New SqlDataAdapter(cmd)
                adp.Fill(ds, "Other")
                If ds.Tables(0).Rows.Count > 0 Then
                    grdOtherLoan.DataSource = ds.Tables(0)
                Else
                    grdOtherLoan.DataSource = Nothing
                End If
                grdOtherLoan.DataBind()
            End Using
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub getClientCollateral(custNo As String, lID As String)
        Try
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd As New SqlCommand("select id,CollateralType,CollDesc,format(CollValue,'c') as [Value] from ClientCollateral where CustNo='" & custNo & "' and (LoanID='" & lID & "')", con)
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

    Protected Sub loadUploadedFiles(loanID As String)
        Try
            cmd = New SqlCommand("select * from QUEST_DOCUMENTS where LOAN_ID='" & loanID & "'", con)
            Dim ds As New DataSet
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "QD")
            If ds.Tables(0).Rows.Count > 0 Then
                grdDocuments.DataSource = ds.Tables(0)
            Else
                grdDocuments.DataSource = Nothing
            End If
            grdDocuments.DataBind()
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub loadPurpose(ByVal cmbPurpose As DropDownList)
        Try
            Using cmd = New SqlCommand("select * from PARA_PURPOSE", con)
                Dim ds As New DataSet
                adp = New SqlDataAdapter(cmd)
                adp.Fill(ds, "purpose")
                CreditManager.loadCombo(ds.Tables(0), cmbPurpose, "PURPOSE", "PURPOSE")
            End Using
        Catch ex As Exception

        End Try
    End Sub

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
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- getPDACompanies()", ex.Message)
        End Try
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            isValidSession()
            Page.MaintainScrollPositionOnPostBack = True
            con = New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
            If Not IsPostBack Then
                Dim EncQuery As New BankEncryption64
                ViewState("loanID") = EncQuery.Decrypt(Request.QueryString("id").Replace(" ", "+"))
                loadProductType(cmbProductType)
                loadClientTypes()
                loadOwnerOfClient()
                getAppHistory()
                writeSubmitButton(ViewState("StageAction"))
                loadSectors(cmbSector)

                loadBanks(cmbFinReqBank)
                loadBanks(cmbBankAppType)
                loadBanks(cmbBank)
                'writeBranch()
                loadPurpose(cmbFinReqPurpose)
                getPDACompanies()
                loadProductType(cmbProductType)
                loadSectors(cmbSector)
                'loadCollateralTypes()
                getAppDetails(ViewState("loanID"))

                'loadAppForm()
                lnkViewAppForm.NavigateUrl = "Amortization.aspx?ID=" & EncQuery.Encrypt(ViewState("loanID").Replace(" ", "+")) & "&App=1"
                lnkAppRating.NavigateUrl = "ApplicationRating.aspx?loanID=" & EncQuery.Encrypt(ViewState("loanID").Replace(" ", "+"))
                If amortizationAlreadyCreated(ViewState("loanID")) Then
                    lnkAmortizationSchedule.NavigateUrl = "rptAmortizationSchedule.aspx?loanID=" & EncQuery.Encrypt(ViewState("loanID").Replace(" ", "+"))
                    lnkAmortizationSchedule.Visible = True
                End If
                loadUploadedFiles(ViewState("loanID"))
            End If
            'ClientScript.RegisterStartupScript(Me.GetType, "disburse", "<script type=""text/javascript"">showDisburseAmt();</script>")
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub rdbDisbursementOption_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rdbDisbursementOption.SelectedIndexChanged
        If rdbDisbursementOption.SelectedValue = "Cash" Then
            loadDropDown("211")
        ElseIf rdbDisbursementOption.SelectedValue = "RTGS" Then
            loadDropDown("212")
        ElseIf rdbDisbursementOption.SelectedValue = "Mobile" Then
            loadDropDown("212")
        ElseIf rdbDisbursementOption.SelectedValue = "Asset" Then
            loadDropDown("216")
        End If
    End Sub

    Protected Sub recordDisbursalTrans(custNo As String, loanID As String, amt As Double)
        'cmd = New SqlCommand("insert into QUEST_TRANSACTIONS (CUST_NO,LOANID,TRANS_DATE,TRANS_DESC,DEBIT,CREDIT,BAL_BFWD,BAL_CFWD) VALUES ('" & custNo & "','" & loanID & "',GETDATE(),'Loan Disbursement','" & amt & "','0','0','" & amt & "')", con)
        cmd = New SqlCommand("insert into QUEST_TRANSACTIONS (CUST_NO,LOANID,TRANS_DATE,TRANS_DESC,DEBIT,CREDIT,BAL_BFWD,BAL_CFWD) VALUES ('" & custNo & "','" & loanID & "','" & txtDisburseDate.Text & "','Loan Disbursement','" & amt & "','0','0','" & amt & "')", con)
        If con.State = ConnectionState.Open Then
            con.Close()
        End If
        con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub
    Protected Sub saveComment()
        Try
            Using cmd = New SqlCommand("insert into REQUEST_HISTORY (LOANID,COMMENT_DATE,USERID,COMMENT,RECOMMENDED_AMT,ROLEID,APP_STAGE) values('" & ViewState("loanID") & "',GETDATE(),'" & Session("UserID") & "','" & BankString.removeSpecialCharacter(txtComment.Text) & "','" & toMoney(txtRecAmt.Text) & "','" & Session("ROLE") & "','" & ViewState("StageName") & "')", con)
                If con.State = ConnectionState.Open Then
                    con.Close()
                End If
                con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            End Using
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- saveComment()", ex.ToString)
        End Try
    End Sub

    Protected Sub writeSubmitButton(ByVal appStage As String)
        If appStage = "Origination" Then
            btnSubmit.Text = "Submit"
        ElseIf appStage = "Recommendation" Then
            btnSubmit.Text = "Recommend"
        ElseIf appStage = "Approval" Then
            btnSubmit.Text = "Approve"
        ElseIf appStage = "Disbursement" Then
            btnSubmit.Text = "Disburse"
            lblDisburseDate.Visible = True
            txtDisburseDate.Visible = True
            spanDDate.Visible = True
        End If
    End Sub

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
End Class