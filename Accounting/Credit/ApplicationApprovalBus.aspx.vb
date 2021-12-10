Imports System.Data
Imports System.Data.SqlClient

Partial Class Credit_ApplicationApprovalBus
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtFinReqIntRate.Visible = False
        Label47.Visible = False
        Label103.Visible = False
        Try
            isValidSession()
            Page.MaintainScrollPositionOnPostBack = True
            If Session("ROLE") = "1024" Then
                btnGenAgrmt.Visible = True
            ElseIf Session("ROLE") = "4045" Then
                btnGenAgrmt.Visible = True
            End If
            If Not IsPostBack Then
                Dim EncQuery As New BankEncryption64
                ViewState("loanID") = EncQuery.Decrypt(Request.QueryString("id").Replace(" ", "+"))
                loadClientTypes()
                getAppHistory()
                getAppDetails(ViewState("loanID"))
                writeSubmitButton(Session("ROLE"))
                lnkViewAppForm.NavigateUrl = "Amortization.aspx?ID=" & ViewState("loanID") & "&App=1"
                If amortizationAlreadyCreated(ViewState("loanID")) Then
                    lnkAmortizationSchedule.NavigateUrl = "rptAmortizationSchedule.aspx?loanID=" & ViewState("loanID")
                    lnkAmortizationSchedule.Visible = True
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
    Protected Function amortizationAlreadyCreated(loanID As String) As Boolean
        Using con = New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
            Dim cmd As New SqlCommand
            cmd = New SqlCommand("select * from AMORTIZATION_SCHEDULE where LOANID='" & loanID & "'", con)
            Dim ds As New DataSet
            Dim adp = New SqlDataAdapter(cmd)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "AMO")
            If ds.Tables(0).Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If
        End Using
    End Function
    Protected Sub isValidSession()
        If Trim(Session("UserID")) = "" Then
            Response.Redirect("~/Logout.aspx")
        Else
        End If
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

    Protected Function getCommand(ByVal roleID As String) As SqlCommand
        Dim comm As New SqlCommand
        Using con = New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)

            Dim newInsuranceRate
            If txtInsuranceRate.Text <> "" Then
                newInsuranceRate = Double.Parse(txtInsuranceRate.Text)
            Else
                newInsuranceRate = 0
            End If

            Dim newInterestRate
            If txtInterestRate.Text <> "" Then
                newInterestRate = Double.Parse(txtInterestRate.Text)
            Else
                newInterestRate = 0
            End If

            Dim newAdminRate = Double.Parse(txtAdminRate.Text)
            If txtAdminRate.Text <> "" Then
                newAdminRate = Double.Parse(txtAdminRate.Text)
            Else
                newAdminRate = 0
            End If
            Dim newTotalInt = newInterestRate + newInsuranceRate + newAdminRate

            If roleID = "4042" Then
                comm = New SqlCommand("update QUEST_APPLICATION set STATUS='RECOMMENDED',SEND_TO='1024', FIN_INT_RATE ='" & newTotalInt & "',  FIN_REPAY_DATE ='" & bdpFinReqRepaymt.Text & "', INT_RATE='" & newInterestRate & "',INSURANCE_RATE='" & newInsuranceRate & "',ADMIN_RATE ='" & newAdminRate & "',   RECOMMENDED='1',REC_DATE=GETDATE(),FIN_AMT='" & txtRecAmt.Text & "',LM_ID='" & Session("ID").ToString() & "',LAST_ID='" & Session("ID").ToString() & "' where ID='" & ViewState("loanID").ToString() & "'", con)
            ElseIf roleID = "4043" Then
                comm = New SqlCommand("update QUEST_APPLICATION set STATUS='APPROVED1',SEND_TO='1024',APP1_APPROVED='1',APP1_DATE=GETDATE(),FIN_AMT='" & txtRecAmt.Text & "',HL_ID='" & Session("ID").ToString() & "',LAST_ID='" & Session("ID").ToString() & "' where ID='" & ViewState("loanID").ToString() & "'", con)
            ElseIf roleID = "4044" Then
                comm = New SqlCommand("update QUEST_APPLICATION set STATUS='APPROVED2',SEND_TO='1024',APP2_APPROVED='1',APP2_DATE=GETDATE(),FIN_AMT='" & txtRecAmt.Text & "',MD_ID='" & Session("ID").ToString() & "',LAST_ID='" & Session("ID").ToString() & "' where ID='" & ViewState("loanID").ToString() & "'", con)
            ElseIf roleID = "1024" Then
                comm = New SqlCommand("update QUEST_APPLICATION set STATUS='DISBURSED',SEND_TO='',DISBURSED='1',DISBURSED_DATE='" & txtDisburseDate.Text & "',FIN_AMT='" & txtRecAmt.Text & "',LAST_ID='" & Session("ID").ToString() & "' where ID='" & ViewState("loanID").ToString() & "'", con)
            ElseIf roleID = "4041" Then
            End If
        End Using
        Return comm
    End Function

    Protected Sub writeSubmitButton(ByVal roleID As String)
        If roleID = "4042" Then
            btnGrpSubmitApp.Text = "Approve"
        ElseIf roleID = "4043" Then
            btnGrpSubmitApp.Text = "Approve"
        ElseIf roleID = "4044" Then
            btnGrpSubmitApp.Text = "Approve"
        ElseIf roleID = "1024" Then
            btnGrpSubmitApp.Text = "Disburse"
            lblDisburseDate.Visible = True
            txtDisburseDate.Visible = True
            disbSpan.Visible = True
        ElseIf roleID = "4041" Then
            btnGrpSubmitApp.Text = "Submit"
        End If
    End Sub

    Protected Sub saveComment()
        Try
            Using con = New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd = New SqlCommand("insert into REQUEST_HISTORY (LOANID,COMMENT_DATE,USERID,COMMENT,RECOMMENDED_AMT) values('" & ViewState("loanID") & "',GETDATE(),'" & Session("UserID") & "','" & BankString.removeSpecialCharacter(txtComment.Text) & "','" & txtRecAmt.Text & "')", con)
                    If con.State = ConnectionState.Open Then
                        con.Close()
                    End If
                    con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                End Using
            End Using
        Catch ex As Exception

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

        End Try
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

    Protected Sub getAppDetails(ByVal loanID As String)
        Try
            Using con = New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd = New SqlCommand("select *,ISNULL([CREATED_DATE],[MODIFIED_DATE]) AS APP_DATET from QUEST_APPLICATION where ID='" & loanID & "'", con)
                    Dim ds As New DataSet
                    Dim adp = New SqlDataAdapter(cmd)
                    adp.Fill(ds, "APP")
                    If ds.Tables(0).Rows.Count > 0 Then
                        Try
                            If ds.Tables(0).Rows(0).Item("STATUS") = "REJECTED" Then
                                If Session("ROLE") = "4042" Then
                                    ViewState("prevUser") = ds.Tables(0).Rows(0).Item("LO_ID")
                                ElseIf Session("ROLE") = "4043" Then
                                    ViewState("prevUser") = ds.Tables(0).Rows(0).Item("LM_ID")
                                ElseIf Session("ROLE") = "4044" Then
                                    ViewState("prevUser") = ds.Tables(0).Rows(0).Item("HL_ID")
                                End If
                            Else
                                ViewState("prevUser") = ds.Tables(0).Rows(0).Item("LAST_ID")
                            End If
                        Catch ex As Exception
                            ViewState("prevUser") = ""
                        End Try
                        txtCustNo.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("CUSTOMER_NUMBER"))

                        txtRegdName.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("FORENAMES"))
                        txtTradeName.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("FORENAMES"))
                        txtBusRegdDate.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("DOB"))
                        txtRoad.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("ADDRESS"))
                        txtCity.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("CITY"))
                        Dim fin_ammt = BankString.isNullString(ds.Tables(0).Rows(0).Item("FIN_AMT"))
                        txtBox.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("POBox"))
                        txtBusinessPhone.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("PHONE_NO"))
                        txtBusinessEmail.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("BusEmail"))
                        txtContactName.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("ContactName"))
                        txtContactTel.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("ContactPhone"))
                        txtContactEmail.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("ContactEmail"))
                        txtRecAmt.Text = FormatNumber(fin_ammt, 2)
                        txtFinReqAmt.Text = FormatNumber(fin_ammt, 2)
                        txtFinReqTenor.Text = FormatNumber(BankString.isNullString(ds.Tables(0).Rows(0).Item("FIN_TENOR")), 2)
                        txtInterestRate.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("INT_RATE"))

                        txtFinReqIntRate.Text = FormatNumber(BankString.isNullString(ds.Tables(0).Rows(0).Item("FIN_INT_RATE")), 2)
                        txtAdminRate.Text = FormatNumber(BankString.isNullString(ds.Tables(0).Rows(0).Item("ADMIN_RATE")), 2)
                        txtRepaymentInterval.Text = FormatNumber(BankString.isNullString(ds.Tables(0).Rows(0).Item("RepaymentIntervalNum")), 2)

                        txtPurpose.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("FIN_PURPOSE"))

                        txtRepInts.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("RepaymentIntervalUnit"))
                        txtFinReqSource.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("FIN_SRC_REPAYMT"))
                        txtFinReqSecOffer.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("FIN_SEC_OFFER"))
                        bdpFinReqRepaymt.Text = CDate(BankString.isNullString(ds.Tables(0).Rows(0).Item("FIN_REPAY_DATE"))).ToString("dd MMMM yyyy")
                        txtFinReqOtherCharges.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("OTHER_CHARGES"))

                        Try
                            txtApplicationDate.Text = CDate(ds.Tables(0).Rows(0).Item("APP_DATET")).ToString("dd MMMM yyyy")
                        Catch ex As Exception
                            txtApplicationDate.Text = ""
                        End Try

                        Try
                            txtRecommendedDisbDate.Text = CDate(ds.Tables(0).Rows(0).Item("RecommendedDisbDate")).ToString("dd MMMM yyyy")
                        Catch ex As Exception
                            txtRecommendedDisbDate.Text = ""
                        End Try
                    Else
                    End If
                End Using
            End Using
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub loadGrpApplicantNames()
    End Sub

    Protected Sub getGrpMemberExpenses()
        Try
            Using con = New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
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

        End Try
    End Sub

    Protected Sub getGrpMembers()
        Try
            Using con = New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd = New SqlCommand("select POSITION,NAME,IDNO,format(qga.AMOUNT,'c') as AMOUNT from QUEST_GROUP_MEMBERS qgm join QUEST_GROUP_APPLICATION qga on qgm.id=qga.MEMBER_ID where CUSTOMER_NUMBER='" & txtCustNo.Text & "'", con)
                    Dim ds As New DataSet
                    Dim adp = New SqlDataAdapter(cmd)
                    adp.Fill(ds, "QGM")
                End Using
            End Using
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub clearGroup()
        rdbClientType.ClearSelection()
        txtCustNo.Text = ""
    End Sub

    Protected Sub btnGrpSubmitApp_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGrpSubmitApp.Click
        Try
            Using con = New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                If con.State = ConnectionState.Open Then
                    con.Close()
                End If
                Using cmd = getCommand(Session("ROLE").ToString())
                    If con.State = ConnectionState.Open Then
                        con.Close()
                    End If
                    con.Open()

                    If cmd.ExecuteNonQuery() Then
                        If Session("ROLE") = "1024" Then
                            recordDisbursalTrans(txtCustNo.Text, ViewState("loanID").ToString(), Double.Parse(txtRecAmt.Text.ToString()))
                        End If
                        saveComment()
                        Response.Write("<script>alert('Loan successfully approved') ; location.href='ApplicationView.aspx'</script>")
                        'clearAll()
                    End If
                    con.Close()
                End Using
            End Using
        Catch ex As Exception
            msgbox(ex.Message)
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
                Using cmd = New SqlCommand("update QUEST_APPLICATION set STATUS='REJECTED', SEND_TO='" & retRole & "',LAST_ID='" & Session("ID").ToString() & "' where ID='" & ViewState("loanID").ToString() & "'", con)
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
                        saveComment()
                        Dim strEmail As String
                        Dim SignatoryEMail As String
                        strEmail = "<Strong>Dear Sir/Madam,</strong><br>The loan application you forwarded has been rejected. Details are as follows<br><br>"
                        strEmail = strEmail & "<Table bgcolor='444444'><font forecolor='ffffff'>"
                        strEmail = strEmail & "<tr bgcolor='999999'><td>Date:</td><td>" & Now & "</td></tr>"
                        strEmail = strEmail & "<tr bgcolor='eeeeee'><td>Applicant Type:</td><td>" & rdbClientType.SelectedValue & "</td></tr>"
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
                    Else
                        msgbox("Error saving")
                    End If
                    con.Close()
                End Using
            End Using
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub btnGenAgrmt_Click(sender As Object, e As EventArgs) Handles btnGenAgrmt.Click
        Try
            Dim strscript As String = "<script langauage=JavaScript>"
            strscript += "window.open('rptAcknowledgement.aspx?ID=" & ViewState("loanID") & "&typ=grp&cust=" & txtCustNo.Text & "');"
            strscript += "</script>"
            ClientScript.RegisterStartupScript(Me.GetType(), "newwin", strscript)
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub txtTradeName_TextChanged(sender As Object, e As EventArgs) Handles txtTradeName.TextChanged

    End Sub
    Protected Sub txtInsuranceRate_TextChanged(sender As Object, e As EventArgs) Handles txtInsuranceRate.TextChanged
        txtFinReqIntRate.Text = txtInsuranceRate.Text + txtInterestRate.Text + txtAdminRate.Text
    End Sub
    Protected Sub txtFinReqIntRate_TextChanged(sender As Object, e As EventArgs) Handles txtFinReqIntRate.TextChanged

    End Sub
    Protected Sub txtInterestRate_TextChanged(sender As Object, e As EventArgs) Handles txtInterestRate.TextChanged
        txtFinReqIntRate.Text = txtInsuranceRate.Text + txtInterestRate.Text + txtAdminRate.Text
    End Sub
    Protected Sub txtAdminRate_TextChanged(sender As Object, e As EventArgs) Handles txtAdminRate.TextChanged
        txtFinReqIntRate.Text = txtInsuranceRate.Text + txtInterestRate.Text + txtAdminRate.Text
    End Sub
End Class