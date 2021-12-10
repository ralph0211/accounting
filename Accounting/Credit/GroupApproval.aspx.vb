Imports System.Data
Imports System.Data.SqlClient
Imports CreditManager
Imports ErrorLogging

Partial Class Credit_GroupApproval
    Inherits System.Web.UI.Page

    Private Sub Credit_GroupApproval_Load(sender As Object, e As EventArgs) Handles Me.Load
        Page.MaintainScrollPositionOnPostBack = True
        If Not IsPostBack Then
            Dim EncQuery As New BankEncryption64
            ViewState("loanID") = EncQuery.Decrypt(Request.QueryString("id").Replace(" ", "+"))
            loadProductType(cmbProductType)
            'loadClientTypes()
            'loadOwnerOfClient()
            getAppHistory()
            'writeSubmitButton(ViewState("StageAction"))
            'loadSectors(cmbSector)

            'loadBanks(cmbFinReqBank)
            'loadBanks(cmbBankAppType)
            'loadBanks(cmbBank)
            ''writeBranch()
            loadPurpose(cmbFinReqPurpose)
            'getPDACompanies()
            loadProductType(cmbProductType)
            'loadSectors(cmbSector)
            'loadCollateralTypes()
            getAppDetails(ViewState("loanID"))

            ''loadAppForm()
            'lnkViewAppForm.NavigateUrl = "Amortization.aspx?ID=" & EncQuery.Encrypt(ViewState("loanID").Replace(" ", "+")) & "&App=1"
            'lnkAppRating.NavigateUrl = "ApplicationRating.aspx?loanID=" & EncQuery.Encrypt(ViewState("loanID").Replace(" ", "+"))
            If amortizationAlreadyCreated(ViewState("loanID")) Then
                lnkAmortizationSchedule.NavigateUrl = "rptAmortizationSchedule.aspx?loanID=" & EncQuery.Encrypt(ViewState("loanID").Replace(" ", "+"))
                lnkAmortizationSchedule.Visible = True
            End If
            loadUploadedFiles(txtGrpAccNo.Text)
            loadUploadedFilesApp(ViewState("loanID"))
        End If
    End Sub

    Protected Sub loadUploadedFilesApp(loanID As String)
        Try
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd = New SqlCommand("select * from QUEST_DOCUMENTS where LOAN_ID='" & loanID & "'", con)
                    Dim ds As New DataSet
                    Using adp = New SqlDataAdapter(cmd)
                        adp.Fill(ds, "QD")
                    End Using
                    If ds.Tables(0).Rows.Count > 0 Then
                        grdDocumentsApp.DataSource = ds.Tables(0)
                    Else
                        grdDocumentsApp.DataSource = Nothing
                    End If
                    grdDocumentsApp.DataBind()
                End Using
            End Using
        Catch ex As Exception
            WriteLogFile(ex.ToString)
        End Try
    End Sub

    Protected Sub getAppHistory()
        Try
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd = New SqlCommand("select convert(varchar,COMMENT_DATE,113) as [DATE], USERID as [USER],CONVERT(DECIMAL(30,2),[RECOMMENDED_AMT]) as [RECOMMENDED AMOUNT],COMMENT from REQUEST_HISTORY where LOANID='" & ViewState("loanID") & "' order by COMMENT_DATE", con)
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
                    loadCombo(ds.Tables(0), cmbPurpose, "PURPOSE", "PURPOSE")
                End Using
            End Using
        Catch ex As Exception

        End Try
    End Sub

    Protected Function amortizationAlreadyCreated(loanID As String) As Boolean
        Dim ds As New DataSet
        Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
            Using cmd = New SqlCommand("select * from AMORTIZATION_SCHEDULE where LOANID='" & loanID & "'", con)
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

    Protected Sub loadUploadedFiles(custNo As String)
        Try
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd = New SqlCommand("select qd.* from CUSTOMER_DOCUMENTS qd where CUST_NO='" & custNo & "'", con)
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

    Protected Sub getAppDetails(ByVal loanID As String)
        Try
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd = New SqlCommand("select *,convert(varchar,DOB,106) as DOB1,convert(varchar,ISSUE_DATE,106) as ISSUE_DATE1,convert(varchar,GUARANTOR_DOB,106) as GUARANTOR_DOB1,convert(varchar,FIN_REPAY_DATE,106) as FIN_REPAY_DATE1,convert(varchar,APPL_DATE,106) as APPL_DATE1 from QUEST_APPLICATION where ID='" & loanID & "'", con)
                    Dim ds As New DataSet
                    Dim adp = New SqlDataAdapter(cmd)
                    adp.Fill(ds, "APP")
                    If ds.Tables(0).Rows.Count > 0 Then
                        Try
                            ViewState("prev") = ds.Tables(0).Rows(0).Item("LAST_ID")
                        Catch ex As Exception
                            ViewState("prev") = ""
                        End Try
                        txtGrpAccNo.Text = ds.Tables(0).Rows(0).Item("CUSTOMER_NUMBER")
                        txtGrpName.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("SURNAME"))
                        lblBranchCode.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("BRANCH_CODE"))
                        lblBranchName.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("BRANCH_NAME"))
                        Try
                            lblLoanCycle.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("LoanCycle"))
                        Catch ex As Exception

                        End Try
                        Try
                            txtApplicationDate.Text = displayDate(BankString.isNullString(ds.Tables(0).Rows(0).Item("APPL_DATE1")))
                        Catch ex As Exception
                        End Try
                        Try
                            chkExtension.Checked = BankString.isNullString(ds.Tables(0).Rows(0).Item("Extension"))
                        Catch ex As Exception

                        End Try
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

                        'Try
                        '    txtAmtToDisburse.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("FIN_AMT"))
                        'Catch ex As Exception
                        '    txtAmtToDisburse.Text = ""
                        'End Try

                        'txtFinReqBank.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("FIN_BANK"))
                        'txtFinReqBranchCode.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("FIN_BRANCH_CODE"))
                        'txtFinReqBranchName.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("FIN_BRANCH"))
                        txtFinReqIntRate.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("FIN_INT_RATE"))
                        txtFinReqPurpose.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("FIN_PURPOSE"))
                        'txtFinReqSecOffer.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("FIN_SEC_OFFER"))
                        txtFinReqSource.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("FIN_SRC_REPAYMT"))
                        Try
                            lblGrpChair.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("GroupChairman"))
                        Catch ex As Exception
                            lblGrpChair.Text = ""
                        End Try
                        Try
                            lblGrpMembers.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("GroupMembers"))
                        Catch ex As Exception
                            lblGrpMembers.Text = ""
                        End Try
                        Try
                            txtFinReqTenor.Text = FormatNumber(BankString.isNullString(ds.Tables(0).Rows(0).Item("FIN_TENOR")), 0)
                        Catch ex As Exception
                            txtFinReqTenor.Text = ""
                        End Try
                        'Try
                        '    txtInterestRate.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("INT_RATE"))
                        'Catch ex As Exception
                        'End Try
                        'Try
                        '    txtInsuranceRate.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("INSURANCE_RATE"))
                        'Catch ex As Exception
                        'End Try
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
                            cmbFinReqPurpose.SelectedValue = BankString.isNullString(ds.Tables(0).Rows(0).Item("FIN_PURPOSE"))
                        Catch ex As Exception
                            cmbFinReqPurpose.ClearSelection()
                        End Try
                        If BankString.isNullString(ds.Tables(0).Rows(0).Item("FIN_REPAY_DATE1")) = "01 Jan 1900" Then
                            txtFinReqRepaymt.Text = ""
                        Else
                            txtFinReqRepaymt.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("FIN_REPAY_DATE1"))
                        End If

                        'Try
                        '    cmbBank.SelectedValue = BankString.isNullString(ds.Tables(0).Rows(0).Item("Bank"))
                        'Catch ex As Exception
                        '    cmbBank.ClearSelection()
                        'End Try
                        'loadBankBranches(BankString.isNullString(ds.Tables(0).Rows(0).Item("Bank")), cmbBankBranch)
                        'Try
                        '    cmbBankBranch.SelectedValue = BankString.isNullString(ds.Tables(0).Rows(0).Item("BankBranch"))
                        'Catch ex As Exception
                        '    cmbBankBranch.ClearSelection()
                        'End Try
                        'txtBankAccountNo.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("BankAccountNo"))

                        getNextApproval(cmbProductType.SelectedValue, ds.Tables(0).Rows(0).Item("ApprovalNumber") + 1)
                        Try
                            txtRepaymentInterval.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("RepaymentIntervalNum"))
                        Catch ex As Exception
                        End Try
                        Try
                            cmbRepaymentInterval.SelectedValue = BankString.isNullString(ds.Tables(0).Rows(0).Item("RepaymentIntervalUnit"))
                        Catch ex As Exception
                            cmbRepaymentInterval.ClearSelection()
                        End Try
                        getIndividualAmounts(loanID)
                    Else
                    End If
                End Using
            End Using
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- getAppDetails()", ex.ToString)
        End Try
    End Sub

    Protected Sub getIndividualAmounts(lID As String)
        Try
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd = New SqlCommand("select CUSTOMER_NUMBER as [Account No.],ISNULL(FORENAMES,'')+' '+ISNULL(SURNAME,'') as [Name],IDNO as [ID Number],FORMAT(FIN_AMT,'n2') as [Amount] from QUEST_APPLICATION where GroupLoanID='" & lID & "'", con)
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
    Protected Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
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
                Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                    Dim cmdStr As String = ""
                    If ViewState("StageMulti") = "Y" Then
                        If NoOfRoundRobin(Session("ROLE"), ViewState("loanID")) + 1 > ViewState("StageNoApps") Then
                            'all round robin stages done, move to next level
                            'If SSB send to ssb download
                            'If rdbSubIndividual.SelectedValue = "SSB" Then
                            '    cmdStr = "update QUEST_APPLICATION set [RECOMMENDED_AMT]='" & toMoney(txtRecAmt.Text) & "',STATUS='SSB Approval',SEND_TO='1024',SSB_FileNo=0,LAST_ID='" & Session("ID") & "',[ApprovalNumber]=[ApprovalNumber] where ID='" & ViewState("loanID") & "'"
                            'Else
                            '    'cmdStr = "update QUEST_APPLICATION set STATUS='" & ViewState("StageName") & "',SEND_TO='" & ViewState("NextRole") & "',LAST_ID='" & Session("ID") & "',[ApprovalNumber]=[ApprovalNumber]+1 where ID='" & ViewState("loanID") & "'"
                            cmdStr = "update QUEST_APPLICATION set [RECOMMENDED_AMT]='" & toMoney(txtRecAmt.Text) & "',STATUS='" & ViewState("StageName") & "',SEND_TO='" & ViewState("NextRole") & "',LAST_ID='" & Session("ID") & "',[ApprovalNumber]='" & ViewState("NextAppNo") - 1 & "' where ID='" & ViewState("loanID") & "'"
                            'End If
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
                        strEmail = strEmail & "<tr style='background-color: #f5f5f5;padding: 15px;text-align: left;'><th style='border: 1px solid black;text-align: left;'>Client Name:</th><td style='border: 1px solid black;'>" & txtGrpName.Text & "</td></tr>"
                        strEmail = strEmail & "<tr style='background-color: white;padding: 15px;text-align: left;'><th style='border: 1px solid black;text-align: left;'>Date:</th><td style='border: 1px solid black;'>" & Now & "</td></tr>"
                        strEmail = strEmail & "<tr style='background-color: #f5f5f5;padding: 15px;text-align: left;'><th style='border: 1px solid black;text-align: left;'>Applicant Type:</th><td style='border: 1px solid black;'>Group</td></tr>"
                        strEmail = strEmail & "<tr style='background-color: white;padding: 15px;text-align: left;'><th style='border: 1px solid black;text-align: left;'>Product:</th><td style='border: 1px solid black;'>" & cmbProductType.SelectedItem.Text.ToString & "</td></tr>"
                        'strEmail = strEmail & "<tr style='background-color: #f5f5f5;padding: 15px;text-align: left;'><th style='border: 1px solid black;text-align: left;'>Sector:</th><td style='border: 1px solid black;'>" & cmbSector.SelectedItem.Text.ToString & "</td></tr>"
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
                End Using
            End If
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- btnSubmit_Click()", ex.ToString)
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
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd = New SqlCommand("update QUEST_APPLICATION set STATUS='REJECTED', SEND_TO='" & retRole & "',LAST_ID='" & Session("ID") & "',[ApprovalNumber]=[ApprovalNumber]-1 where ID='" & ViewState("loanID") & "'", con)
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
                        strEmail = strEmail & "<tr style='background-color: #f5f5f5;padding: 15px;text-align: left;'><th style='border: 1px solid black;text-align: left;'>Client Name:</th><td style='border: 1px solid black;'>" & txtGrpName.Text & "</td></tr>"
                        strEmail = strEmail & "<tr style='background-color: white;padding: 15px;text-align: left;'><th style='border: 1px solid black;text-align: left;'>Date:</th><td style='border: 1px solid black;'>" & Now & "</td></tr>"
                        strEmail = strEmail & "<tr style='background-color: #f5f5f5;padding: 15px;text-align: left;'><th style='border: 1px solid black;text-align: left;'>Applicant Type:</th><td style='border: 1px solid black;'>Group</td></tr>"
                        strEmail = strEmail & "<tr style='background-color: white;padding: 15px;text-align: left;'><th style='border: 1px solid black;text-align: left;'>Product:</th><td style='border: 1px solid black;'>" & cmbProductType.SelectedItem.Text.ToString & "</td></tr>"
                        'strEmail = strEmail & "<tr style='background-color: #f5f5f5;padding: 15px;text-align: left;'><th style='border: 1px solid black;text-align: left;'>Sector:</th><td style='border: 1px solid black;'>" & cmbSector.SelectedItem.Text.ToString & "</td></tr>"
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
                End Using
            End Using
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- btnReject_Click()", ex.ToString)
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
    Protected Sub saveComment()
        Try
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd = New SqlCommand("insert into REQUEST_HISTORY (LOANID,COMMENT_DATE,USERID,COMMENT,RECOMMENDED_AMT,ROLEID,APP_STAGE) values('" & ViewState("loanID") & "',GETDATE(),'" & Session("UserID") & "','" & BankString.removeSpecialCharacter(txtComment.Text) & "','" & toMoney(txtRecAmt.Text) & "','" & Session("ROLE") & "','" & ViewState("StageName") & "')", con)
                    If con.State = ConnectionState.Open Then
                        con.Close()
                    End If
                    con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                End Using
            End Using
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- saveComment()", ex.ToString)
        End Try
    End Sub

    Protected Sub grdDocuments_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles grdDocuments.RowCommand
        If e.CommandName = "Select" Then
            Dim docID = e.CommandArgument
            'lblDetailID.Text = docID
            'btnModalPopup.Visible = True
            Dim strscript As String

            strscript = "<script language=JavaScript>"
            strscript += "window.open('viewDocumentStatic.aspx?id=" & docID & "');"
            strscript += "</script>"
            'ClientScript.RegisterStartupScript(Me.GetType(), "HideLabel", "<script type=""text/javascript"">setTimeout(""document.getElementById('" & lblAppUploadMsg.ClientID & "').style.display='none'"",5000)</script>")
            ClientScript.RegisterStartupScript(Me.GetType(), "newwin", strscript)

        End If
    End Sub

    Private Sub grdDocumentsApp_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles grdDocumentsApp.RowCommand
        If e.CommandName = "Select" Then
            Dim docID = e.CommandArgument
            Dim strscript As String

            strscript = "<script language=JavaScript>"
            strscript += "window.open('viewDocument.aspx?id=" & docID & "');"
            strscript += "</script>"
            ClientScript.RegisterStartupScript(Me.GetType(), "newwin", strscript)
        End If
    End Sub
End Class
