Imports System.Data
Imports System.Data.SqlClient
Imports CreditManager
Imports ErrorLogging

Partial Class Credit_ApplicationApprovalGrp
    Inherits System.Web.UI.Page

    Protected Sub btnGenAgrmt_Click(sender As Object, e As EventArgs) Handles btnGenAgrmt.Click
        Try
            Dim strscript As String = "<script langauage=JavaScript>"
            strscript += "window.open('rptAcknowledgement.aspx?ID=" & ViewState("loanID") & "&typ=grp&cust=" & txtCustNo.Text & "');"
            strscript += "</script>"
            ClientScript.RegisterStartupScript(Me.GetType(), "newwin", strscript)
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- btnGenAgrmt_Click()", ex.ToString)
        End Try
    End Sub
    Protected Sub btnGrpReject_Click(sender As Object, e As EventArgs) Handles btnGrpReject.Click
        Try
            Dim retRole = ""
            If Session("ROLE") = "4044" Then
                retRole = "4043"
            ElseIf Session("ROLE") = "4043" Then
                retRole = "4042"
            ElseIf Session("ROLE") = "4042" Then
                retRole = "4041"
            ElseIf Session("ROLE") = "1024" Then
                retRole = "4044"
            End If
            Using con = New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd = New SqlCommand("update QUEST_APPLICATION set STATUS='REJECTED', SEND_TO='" & retRole & "',LAST_ID='" & Session("ID") & "' where ID='" & ViewState("loanID") & "'", con)
                    If con.State = ConnectionState.Open Then
                        con.Close()
                    End If
                    con.Open()
                    'msgbox(cmd.CommandText)
                    If cmd.ExecuteNonQuery Then
                        Dim comm = ""
                        If Trim(txtComment.Text) = "" Then
                            comm = "REJECTED"
                        Else
                            comm = txtComment.Text
                        End If
                        'If Not (Trim(txtComment.Text) = "" Or Trim(txtRecAmt.Text) = "") Then
                        'cmd = New SqlCommand("insert into REQUEST_HISTORY (LOANID,COMMENT_DATE,USERID,COMMENT,RECOMMENDED_AMT) values('" & Request.QueryString("id") & "',GETDATE(),'" & Session("UserID") & "','" & BankString.removeSpecialCharacter(comm) & "','" & txtRecAmt.Text & "')", con)
                        'cmd.ExecuteNonQuery()
                        'con.Close()
                        saveComment()
                        Dim strEmail As String
                        Dim SignatoryEMail As String
                        'SignatoryEMail = Mailhelper.GetEMailID(ddl_SendTo.SelectedValue.ToString())

                        strEmail = "<Strong>Dear Sir/Madam,</strong><br>The loan application you forwarded has been rejected. Details are as follows<br><br>"
                        strEmail = strEmail & "<Table bgcolor='444444'><font forecolor='ffffff'>"
                        strEmail = strEmail & "<tr bgcolor='999999'><td>Date:</td><td>" & Now & "</td></tr>"
                        strEmail = strEmail & "<tr bgcolor='eeeeee'><td>Applicant Type:</td><td>" & rdbClientType.SelectedValue & "</td></tr>"
                        strEmail = strEmail & "<tr bgcolor='999999'><td>Branch:</td><td>" & lblBranchCode.Text.Trim() & " - " & lblBranchName.Text.Trim() & "</td></tr>"
                        'strEmail = strEmail & "<tr bgcolor='999999'><td>Branch Name:</td><td>" & txt_BranchName.Text.Trim() & "</td></tr>"
                        strEmail = strEmail & "<tr bgcolor='999999'><td>Client Name:</td><td>" & txtGrpName.Text & "</td></tr>"
                        'strEmail = strEmail & "<tr bgcolor='999999'><td>Transaction Type:</td><td>" & ddl_TransactionTy.SelectedItem.Text.Trim() & "</td></tr>"
                        strEmail = strEmail & "<tr bgcolor='999999'><td>Amount:</td><td>" & txtGrpApplLoanAmt.Text & "</td></tr>"
                        strEmail = strEmail & "</font></Table>"
                        strEmail = strEmail & "<br><Strong>Thanks & Regards,<br>IT Support Team</strong>"
                        If Session("ROLE") = "4042" Then
                            SignatoryEMail = Mailhelper.GetEMailID(ViewState("prevUser"))
                            If Trim(SignatoryEMail) = "" Then
                                SignatoryEMail = Mailhelper.GetEMailID(ViewState("prevUser"))
                            End If
                            Mailhelper.SendMailMessage("administrator", SignatoryEMail, "", "", "Escrow Credit Management - Loan Application", strEmail)
                        ElseIf Session("ROLE") = "4043" Then
                            SignatoryEMail = Mailhelper.GetEMailID(ViewState("prevUser"))
                            If Trim(SignatoryEMail) = "" Then
                                SignatoryEMail = Mailhelper.GetEMailID(ViewState("prevUser"))
                            End If
                            Mailhelper.SendMailMessage("administrator", SignatoryEMail, "", "", "Escrow Credit Management - Loan Application", strEmail)
                        End If
                        Response.Write("<script>alert('Loan successfully rejected'); location.href='ApplicationView.aspx';</script>")
                        'ClientScript.RegisterStartupScript(Me.GetType(), "Gritter", "<script type=""text/javascript"">location.href='ApplicationView.aspx'; $.gritter.add({title: 'Loan Added Successfully!',text: 'The loan has been added successfully.',image: 'images/thumbs3.jpg'});</script>")
                    Else
                        msgbox("Error saving")
                        'ClientScript.RegisterStartupScript(Me.GetType(), "Gritter", "<script type=""text/javascript"">location.href='ApplicationView.aspx'; $.gritter.add({title: 'Loan Added Successfully!',text: 'The loan has been added successfully.',image: 'images/thumbs3.jpg'});</script>")
                    End If
                    con.Close()
                End Using
            End Using
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- btnGrpReject_Click()", ex.ToString)
        End Try
    End Sub

    Protected Sub btnGrpSubmitApp_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGrpSubmitApp.Click
        Try
            Using con = New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                'cmd = New SqlCommand("update QUEST_APPLICATION set STATUS='RECOMMENDED',SEND_TO='4043',APP1_APPROVED='1',APP1_DATE=GETDATE() where ID='" & Request.QueryString("id") & "'", con)
                Using cmd = New SqlCommand("update QUEST_APPLICATION set STATUS='" & ViewState("StageName") & "',SEND_TO='" & ViewState("NextRole") & "',LAST_ID='" & Session("ID") & "',[ApprovalNumber]=[ApprovalNumber]+1,RECOMMENDED_AMT=nullif('" & txtRecAmt.Text & "','') where ID='" & ViewState("loanID") & "'", con) ' getCommand(Session("ROLE"))
                    If con.State = ConnectionState.Open Then
                        con.Close()
                    End If
                    con.Open()
                    If cmd.ExecuteNonQuery() Then
                        'If Session("ROLE") = "1024" Then
                        '    recordDisbursalTrans(txtCustNo.Text, ViewState("loanID"), txtGrpApplLoanAmt.Text)
                        'End If
                        saveComment()
                        If btnGrpSubmitApp.Text = "Recommend" Then
                            Response.Write("<script>alert('Loan successfully recommended') ; location.href='ApplicationView.aspx'</script>")
                        ElseIf btnGrpSubmitApp.Text = "Approve" Then
                            Response.Write("<script>alert('Loan successfully approved') ; location.href='ApplicationView.aspx'</script>")
                        ElseIf btnGrpSubmitApp.Text = "Disburse" Then
                            Response.Write("<script>alert('Loan successfully disbursed') ; location.href='ApplicationView.aspx'</script>")
                        End If
                    End If
                    con.Close()
                End Using
            End Using
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- btnGrpSubmitApp_Click()", ex.ToString)
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
        txtGrpAdminFee.Text = ""
        chkGrpApplSigned.Checked = False
    End Sub

    Protected Sub getAppDetails(ByVal loanID As String)
        Try
            Using con = New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd = New SqlCommand("select *,convert(varchar,APPL_DATE,106) as APPL_DATE1 from QUEST_APPLICATION where ID='" & loanID & "'", con)
                    Dim ds As New DataSet
                    Dim adp = New SqlDataAdapter(cmd)
                    adp.Fill(ds, "APP")
                    If ds.Tables(0).Rows.Count > 0 Then
                        Try
                            ViewState("prev") = ds.Tables(0).Rows(0).Item("LAST_ID")
                        Catch ex As Exception
                            ViewState("prev") = ""
                        End Try
                        getNextApproval(ds.Tables(0).Rows(0).Item("ApprovalNumber") + 1)
                        txtCustNo.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("CUSTOMER_NUMBER"))
                        txtGrpName.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("SURNAME"))
                        lblBranchCode.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("BRANCH_CODE"))
                        lblBranchName.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("BRANCH_NAME"))
                        getGrpMembers()
                        getGrpMemberExpenses()
                        loadGrpApplicantNames()
                        rdbClientType.SelectedValue = BankString.isNullString(ds.Tables(0).Rows(0).Item("CUSTOMER_TYPE"))
                        txtGrpApplLineBus.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("BUS_TYPE"))
                        txtGrpApplPeriodBus.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("BUS_PERIOD"))
                        txtGrpApplSrcIncome1.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("SOURCE1"))
                        txtGrpApplSrcIncome2.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("SOURCE2"))
                        txtGrpApplSrcIncome3.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("SOURCE3"))
                        txtGrpApplBorrow1.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("BORROWING1"))
                        txtGrpApplBorrow2.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("BORROWING2"))
                        txtGrpApplBorrow3.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("BORROWING3"))
                        Try
                            txtGrpAppDate.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("APPL_DATE1"))
                        Catch ex As Exception

                        End Try
                        Try
                            txtGrpApplLoanAmt.Text = FormatNumber(BankString.isNullString(ds.Tables(0).Rows(0).Item("AMT_APPLIED")), 2)
                        Catch ex As Exception
                            txtGrpApplLoanAmt.Text = ""
                        End Try
                        Try
                            txtRecAmt.Text = FormatNumber(BankString.isNullString(ds.Tables(0).Rows(0).Item("FIN_AMT")), 2)
                        Catch ex As Exception
                            txtRecAmt.Text = ""
                        End Try
                        Try
                            txtGrpAdminFee.Text = FormatNumber(BankString.isNullString(ds.Tables(0).Rows(0).Item("FIN_ADMIN")), 2)
                        Catch ex As Exception
                            txtGrpAdminFee.Text = ""
                        End Try

                        'txtGrpApplLoanAmt.Text = FormatNumber(BankString.isNullString(ds.Tables(0).Rows(0).Item("FIN_AMT")), 2)
                        txtGrpApplRepayTenure.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("FIN_TENOR"))
                        txtGrpApplPurpose.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("FIN_PURPOSE"))
                        Try
                            txtGrpApplInterest.Text = FormatNumber(BankString.isNullString(ds.Tables(0).Rows(0).Item("FIN_INT_RATE")), 2)
                        Catch ex As Exception
                            txtGrpApplInterest.Text = ""
                        End Try
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
            Using con = New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd = New SqlCommand("select COMMENT_DATE as [DATE], USERID as [USER],cast([RECOMMENDED_AMT] as numeric(18,2)) as [RECOMMENDED AMOUNT],COMMENT from REQUEST_HISTORY where LOANID='" & ViewState("loanID") & "' order by ID", con)
                    Dim ds As New DataSet
                    Dim adp = New SqlDataAdapter(cmd)
                    adp.Fill(ds, "COMMENT")
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

    Protected Sub getGrpMemberExpenses()
        Try
            Using con = New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                'cmd = New SqlCommand("select ID,POSITION,NAME,IDNO,RENT,FOOD,FEES,AIRTIME,MEDICAL,ELECTRICITY,WATER,RATES,CITY_OF_HRE as [CITY OF HARARE] from QUEST_GROUP_MEMBERS where CUSTOMER_NUMBER='" & txtCustNo.Text & "'", con)
                Using cmd = New SqlCommand("select ID,POSITION,NAME,IDNO,cast(RENT as numeric(18,2)) as RENT,cast(FOOD as numeric(18,2)) as FOOD,cast(FEES as numeric(18,2)) as FEES,cast(AIRTIME as numeric(18,2)) as AIRTIME,cast(MEDICAL as numeric(18,2)) as MEDICAL,cast(ELECTRICITY as numeric(18,2)) as ELECTRICITY,cast(WATER as numeric(18,2)) as WATER,cast(RATES as numeric(18,2)) as RATES,cast(CITY_OF_HRE as numeric(18,2)) as [CITY OF HARARE] from QUEST_GROUP_MEMBERS where CUSTOMER_NUMBER='" & txtCustNo.Text & "'", con)
                    Dim ds As New DataSet
                    Dim adp = New SqlDataAdapter(cmd)
                    adp.Fill(ds, "QGM")
                    If ds.Tables(0).Rows.Count > 0 Then
                        grdGrpDeclExpense.DataSource = ds.Tables(0)
                    Else
                        grdGrpDeclExpense.DataSource = Nothing
                    End If
                    grdGrpDeclExpense.DataBind()
                End Using
            End Using
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- getGrpMemberExpenses()", ex.ToString)
        End Try
    End Sub

    Protected Sub getGrpMembers()
        Try
            Using con = New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                'cmd = New SqlCommand("select ID,POSITION,NAME,IDNO from QUEST_GROUP_MEMBERS where CUSTOMER_NUMBER='" & txtCustNo.Text & "'", con)
                Using cmd = New SqlCommand("select POSITION,NAME,IDNO,format(qga.AMOUNT,'c') as AMOUNT from QUEST_GROUP_MEMBERS qgm join QUEST_GROUP_APPLICATION qga on qgm.id=qga.MEMBER_ID where CUSTOMER_NUMBER='" & txtCustNo.Text & "' and LOAN_ID='" & ViewState("loanID") & "'", con)
                    Dim ds As New DataSet
                    Dim adp = New SqlDataAdapter(cmd)
                    adp.Fill(ds, "QGM")
                    If ds.Tables(0).Rows.Count > 0 Then
                        grdGrpDeclMembers.DataSource = ds.Tables(0)
                    Else
                        grdGrpDeclMembers.DataSource = Nothing
                    End If
                    grdGrpDeclMembers.DataBind()
                End Using
            End Using
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- getGrpMembers()", ex.ToString)
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
                        ViewState("StageAction") = dr("StageAction")
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
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- getNextApproval()", ex.Message)
        End Try
    End Sub
    Protected Sub insertInterestAccounts(loanID As String)
        Using con = New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
            'get ineterest to maturity
            Dim cmdInt = New SqlCommand("select max(cumulative_interest) from AMORTIZATION_SCHEDULE where LOANID='" & loanID & "'", con)
            Dim intToMaturity As Double = 0
            If con.State <> ConnectionState.Closed Then
                con.Close()
            End If
            con.Open()
            intToMaturity = cmdInt.ExecuteScalar
            con.Close()

            Dim cmd = New SqlCommand("SaveAccountsTrxns", con)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@Type", "System Entry")
            cmd.Parameters.AddWithValue("@Category", "Interest Payable")
            'cmd.Parameters.AddWithValue("@Date", Today.Date.ToString)
            'cmd.Parameters.AddWithValue("@Ref", [Refrence])
            cmd.Parameters.AddWithValue("@Ref", loanID)
            cmd.Parameters.AddWithValue("@Desc", "Interest to Maturity")
            'cmd.Parameters.AddWithValue("@Debit", txtFinReqAmt.Text)
            cmd.Parameters.AddWithValue("@Debit", intToMaturity)
            cmd.Parameters.AddWithValue("@Credit", 0.0)
            cmd.Parameters.AddWithValue("@Account", "213/1")
            cmd.Parameters.AddWithValue("@ContraAccount", "223/1")
            cmd.Parameters.AddWithValue("@Status", 1)
            'cmd.Parameters.AddWithValue("@Other", [Loan Debtor Account Number])
            cmd.Parameters.AddWithValue("@Other", txtCustNo.Text)
            cmd.Parameters.AddWithValue("@BankAccID", "")
            cmd.Parameters.AddWithValue("@BankAccName", "")
            'cmd.Parameters.AddWithValue("@BatchRef", cmbBatchNo.SelectedItem.Text)
            cmd.Parameters.AddWithValue("@BatchRef", "")
            cmd.Parameters.AddWithValue("@TrxnDate", txtDisburseDate.Text)

            Dim cmd1 = New SqlCommand("SaveAccountsTrxns", con)
            cmd1.CommandType = CommandType.StoredProcedure
            cmd1.Parameters.AddWithValue("@Type", "System Entry")
            cmd1.Parameters.AddWithValue("@Category", "Interest Payable")
            'cmd1.Parameters.AddWithValue("@Date", Today.Date.ToString)
            'cm1d.Parameters.AddWithValue("@Ref", [Refrence])
            cmd1.Parameters.AddWithValue("@Ref", loanID)
            cmd1.Parameters.AddWithValue("@Desc", "Interest to Maturity")
            'cmd1.Parameters.AddWithValue("@Debit", txtFinReqAmt.Text)
            cmd1.Parameters.AddWithValue("@Debit", 0.0)
            cmd1.Parameters.AddWithValue("@Credit", intToMaturity)
            cmd1.Parameters.AddWithValue("@Account", "223/1") 'unearned interest
            cmd1.Parameters.AddWithValue("@ContraAccount", "213/1") 'loan and advances
            cmd1.Parameters.AddWithValue("@Status", 1)
            'cm1d.Parameters.AddWithValue("@Other", [Loan Debtor Account Number])
            cmd1.Parameters.AddWithValue("@Other", txtCustNo.Text)
            cmd1.Parameters.AddWithValue("@BankAccID", "")
            cmd1.Parameters.AddWithValue("@BankAccName", "")
            'cm1d.Parameters.AddWithValue("@BatchRef", cmbBatchNo.SelectedItem.Text)
            cmd1.Parameters.AddWithValue("@BatchRef", "")
            cmd1.Parameters.AddWithValue("@TrxnDate", txtDisburseDate.Text)

            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            con.Open()
            cmd.ExecuteNonQuery()
            cmd1.ExecuteNonQuery()
            con.Close()
        End Using
    End Sub

    Protected Sub isValidSession()
        If Trim(Session("UserID")) = "" Then
            Response.Redirect("~/Logout.aspx")
        Else
        End If
    End Sub

    Protected Sub loadClientTypes()
        Try
            Using con = New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd = New SqlCommand("select * from PARA_CLIENT_TYPES", con)
                    Dim ds As New DataSet
                    Dim adp = New SqlDataAdapter(cmd)
                    adp.Fill(ds, "Clients")
                    If ds.Tables(0).Rows.Count > 0 Then
                        rdbClientType.DataSource = ds.Tables(0)
                        rdbClientType.DataValueField = "CLIENT_TYPE"
                        rdbClientType.DataTextField = "CLIENT_TYPE"
                    Else
                        rdbClientType.DataSource = Nothing
                    End If
                    rdbClientType.DataBind()
                End Using
            End Using
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub loadGrpApplicantNames()
        'Try
        '    cmbGrpApplicantName.Items.Clear()
        '    cmbGrpApplicantName.Items.Add("")
        '    cmd = New SqlCommand("select * from QUEST_GROUP_MEMBERS where CUSTOMER_NUMBER='" & txtCustNo.Text & "'", con)
        '    Dim ds As New DataSet
        '    adp = New SqlDataAdapter(cmd)
        '    adp.Fill(ds, "QGM")
        '    If ds.Tables(0).Rows.Count > 0 Then
        '        cmbGrpApplicantName.DataSource = ds.Tables(0)
        '        cmbGrpApplicantName.DataTextField = "NAME"
        '        cmbGrpApplicantName.DataValueField = "ID"
        '    Else
        '        cmbGrpApplicantName.DataSource = Nothing
        '    End If
        '    cmbGrpApplicantName.DataBind()
        'Catch ex As Exception
        '
        'End Try
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            isValidSession()
            Page.MaintainScrollPositionOnPostBack = True
            If Not IsPostBack Then
                Dim EncQuery As New BankEncryption64
                ViewState("loanID") = EncQuery.Decrypt(Request.QueryString("id").Replace(" ", "+"))
                'writeSubmitButton(Session("ROLE"))
                loadClientTypes()
                getAppHistory()
                getAppDetails(ViewState("loanID"))
                writeSubmitButton(ViewState("StageAction"))
            End If
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- Page_Load()", ex.ToString)
        End Try
    End Sub
    Protected Sub recordDisbursalTrans(custNo As String, loanID As String, amt As Double)
        Using con = New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
            'cmd = New SqlCommand("insert into QUEST_TRANSACTIONS (CUST_NO,LOANID,TRANS_DATE,TRANS_DESC,DEBIT,CREDIT,BAL_BFWD,BAL_CFWD) VALUES ('" & custNo & "','" & loanID & "',GETDATE(),'Loan Disbursement','" & amt & "','0','0','" & amt & "')", con)
            Using cmd = New SqlCommand("insert into QUEST_TRANSACTIONS (CUST_NO,LOANID,TRANS_DATE,TRANS_DESC,DEBIT,CREDIT,BAL_BFWD,BAL_CFWD) VALUES ('" & custNo & "','" & loanID & "','" & txtDisburseDate.Text & "','Loan Disbursement','" & amt & "','0','0','" & amt & "')", con)
                If con.State = ConnectionState.Open Then
                    con.Close()
                End If
                con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            End Using
            Dim cmdAcc = New SqlCommand("SaveAccountsTrxns", con)
            cmdAcc.CommandType = CommandType.StoredProcedure
            cmdAcc.Parameters.AddWithValue("@Type", "System Entry")
            cmdAcc.Parameters.AddWithValue("@Category", "Disbursment")
            'cmd.Parameters.AddWithValue("@Date", Today.Date.ToString)
            'cmd.Parameters.AddWithValue("@Ref", [Refrence])
            cmdAcc.Parameters.AddWithValue("@Ref", ViewState("loanID"))
            cmdAcc.Parameters.AddWithValue("@Desc", "Disbursement")
            'cmd.Parameters.AddWithValue("@Debit", txtFinReqAmt.Text)
            cmdAcc.Parameters.AddWithValue("@Debit", amt)
            cmdAcc.Parameters.AddWithValue("@Credit", 0.0)
            cmdAcc.Parameters.AddWithValue("@Account", "213/1") 'loan debtor
            cmdAcc.Parameters.AddWithValue("@ContraAccount", "211/1") 'cash
            cmdAcc.Parameters.AddWithValue("@Status", 1)
            'cmd.Parameters.AddWithValue("@Other", [Loan Debtor Account Number])
            cmdAcc.Parameters.AddWithValue("@Other", txtCustNo.Text)
            cmdAcc.Parameters.AddWithValue("@BankAccID", "")
            cmdAcc.Parameters.AddWithValue("@BankAccName", "")
            'cmd.Parameters.AddWithValue("@BatchRef", cmbBatchNo.SelectedItem.Text)
            cmdAcc.Parameters.AddWithValue("@BatchRef", "")
            cmdAcc.Parameters.AddWithValue("@TrxnDate", txtDisburseDate.Text)

            Dim cmd1 = New SqlCommand("SaveAccountsTrxns", con)
            cmd1.CommandType = CommandType.StoredProcedure
            cmd1.Parameters.AddWithValue("@Type", "System Entry")
            cmd1.Parameters.AddWithValue("@Category", "Disbursment")
            'cmd1.Parameters.AddWithValue("@Date", Today.Date.ToString)
            'cm1d.Parameters.AddWithValue("@Ref", [Refrence])
            cmd1.Parameters.AddWithValue("@Ref", ViewState("loanID"))
            cmd1.Parameters.AddWithValue("@Desc", "Disbursement")
            'cmd1.Parameters.AddWithValue("@Debit", txtFinReqAmt.Text)
            cmd1.Parameters.AddWithValue("@Debit", 0.0)
            cmd1.Parameters.AddWithValue("@Credit", amt)
            cmd1.Parameters.AddWithValue("@Account", "211/1")
            cmd1.Parameters.AddWithValue("@ContraAccount", "213/1")
            cmd1.Parameters.AddWithValue("@Status", 1)
            'cm1d.Parameters.AddWithValue("@Other", [Loan Debtor Account Number])
            cmd1.Parameters.AddWithValue("@Other", txtCustNo.Text)
            cmd1.Parameters.AddWithValue("@BankAccID", "")
            cmd1.Parameters.AddWithValue("@BankAccName", "")
            'cm1d.Parameters.AddWithValue("@BatchRef", cmbBatchNo.SelectedItem.Text)
            cmd1.Parameters.AddWithValue("@BatchRef", "")
            cmd1.Parameters.AddWithValue("@TrxnDate", txtDisburseDate.Text)

            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            con.Open()
            cmdAcc.ExecuteNonQuery()
            cmd1.ExecuteNonQuery()
            con.Close()

            'new function to insert interest to maturity on disbursement
            insertInterestAccounts(ViewState("loanID"))
        End Using
    End Sub
    Protected Sub saveComment()
        Try
            Using con = New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd = New SqlCommand("insert into REQUEST_HISTORY (LOANID,COMMENT_DATE,USERID,COMMENT,RECOMMENDED_AMT,ROLEID,APP_STAGE) values('" & ViewState("loanID") & "',GETDATE(),'" & Session("UserID") & "','" & BankString.removeSpecialCharacter(txtComment.Text) & "','" & txtRecAmt.Text & "','" & Session("ROLE") & "','" & ViewState("StageName") & "')", con)
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

    Protected Sub writeSubmitButton(ByVal appStage As String)
        If appStage = "Origination" Then
            btnGrpSubmitApp.Text = "Submit"
        ElseIf appStage = "Recommendation" Then
            btnGrpSubmitApp.Text = "Recommend"
        ElseIf appStage = "Approval" Then
            btnGrpSubmitApp.Text = "Approve"
        ElseIf appStage = "Disbursement" Then
            btnGrpSubmitApp.Text = "Disburse"
            lblDisburseDate.Visible = True
            txtDisburseDate.Visible = True
            'spanDDate.Visible = True
        End If
    End Sub
End Class