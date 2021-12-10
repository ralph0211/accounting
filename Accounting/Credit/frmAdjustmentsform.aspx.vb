Imports System.Data
Imports System.Data.SqlClient
Imports System.IO

Partial Class LoanAdjustmentsFormFile
    Inherits System.Web.UI.Page
    Dim cmd As SqlCommand
    Dim adp As SqlDataAdapter
    Dim con As New SqlConnection
    Dim connection As String
    Public Shared typeEditID As Double
    Public Sub msgbox(ByVal strMessage As String)
        'finishes server processing, returns to client.
        Dim strScript As String = "<script language=JavaScript>"
        strScript += "window.alert(""" & strMessage & """);"
        strScript += "</script>"
        Dim lbl As New System.Web.UI.WebControls.Label
        lbl.Text = strScript
        Page.Controls.Add(lbl)
    End Sub
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Page.MaintainScrollPositionOnPostBack = True
        con = New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
        If Not IsPostBack Then
            getApplications(Session("ROLE"), Trim(txtSearchName.Text))
            getApplications_Change(Session("ROLE"), Trim(txtSearchNameChange.Text))
        End If
    End Sub
    Protected Sub getApplications(ByVal roleID As String, cliName As String)
        Try
            cmd = New SqlCommand("select ID,CUSTOMER_NUMBER as [CUST NO.],case IS_PARTIAL when 1 then RTRIM(isnull(SURNAME,'')+' '+isnull(FORENAMES,''))+' - PARTIALLY DISBURSED' else RTRIM(isnull(SURNAME,'')+' '+isnull(FORENAMES,'')) end as NAME,CONVERT(DECIMAL(30,2),FIN_AMT) as AMOUNT,isnull(APPL_DATE,CREATED_DATE) as 'APPLICATION DATE',case isnull(SSB_FILE_TYPE,'') when 'd' then 'SSB Deletion' when 'c' then 'SSB Change' when 'n' then 'SSB New' else '' end as 'SSB MARKED',ECNO+CD AS 'EC No.' from QUEST_APPLICATION where SUB_INDIVIDUAL='SSB' and STATUS<>'REJECTED' and RTRIM(isnull(SURNAME,'')+' '+isnull(FORENAMES,'')) like '%" & cliName & "%' order by id desc", con)
            Dim ds As New DataSet
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "APP")
            If ds.Tables(0).Rows.Count > 0 Then
                grdApps.DataSource = ds.Tables(0)
            Else
                grdApps.DataSource = Nothing
            End If
            grdApps.DataBind()

            'End If
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub getApplications_ECNumber(ByVal roleID As String, cliName As String)
        Try
            cmd = New SqlCommand("select ID,CUSTOMER_NUMBER as [CUST NO.],case IS_PARTIAL when 1 then RTRIM(isnull(SURNAME,'')+' '+isnull(FORENAMES,''))+' - PARTIALLY DISBURSED' else RTRIM(isnull(SURNAME,'')+' '+isnull(FORENAMES,'')) end as NAME,CONVERT(DECIMAL(30,2),FIN_AMT) as AMOUNT,isnull(APPL_DATE,CREATED_DATE) as 'APPLICATION DATE',case isnull(SSB_FILE_TYPE,'') when 'd' then 'SSB Deletion' when 'c' then 'SSB Change' when 'n' then 'SSB New' else '' end as 'SSB MARKED',ECNO+CD AS 'EC No.' from QUEST_APPLICATION where SUB_INDIVIDUAL='SSB' and STATUS<>'REJECTED' and ECNO like '%" & cliName & "%' order by id desc", con)
            Dim ds As New DataSet
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "APP")
            If ds.Tables(0).Rows.Count > 0 Then
                grdApps.DataSource = ds.Tables(0)
            Else
                grdApps.DataSource = Nothing
            End If
            grdApps.DataBind()

            'End If
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub getApplications_Single(ByVal LOANID As Long)
        Try
            cmd = New SqlCommand("select ID as 'LOAN ID',CUSTOMER_NUMBER as [CUST NO.],case IS_PARTIAL when 1 then RTRIM(isnull(SURNAME,'')+' '+isnull(FORENAMES,''))+' - PARTIALLY DISBURSED' else RTRIM(isnull(SURNAME,'')+' '+isnull(FORENAMES,'')) end as NAME,CONVERT(DECIMAL(30,2),FIN_AMT) as AMOUNT,isnull(APPL_DATE,CREATED_DATE) as 'APPLICATION DATE',case isnull(SSB_FILE_TYPE,'') when 'd' then 'SSB Deletion' when 'c' then 'SSB Change' when 'n' then 'SSB New' else '' end as 'SSB MARKED',FIN_TENOR as 'TENURE',FIN_INT_RATE as 'INTEREST RATE',FIN_ADMIN AS 'ADMIN FEE',convert(varchar,FIN_REPAY_DATE,106) AS '1st REPAY DATE' from QUEST_APPLICATION where SUB_INDIVIDUAL='SSB' and ID='" & LOANID & "'", con)
            Dim ds As New DataSet
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "APP")
            If ds.Tables(0).Rows.Count > 0 Then
                GridView1.DataSource = ds.Tables(0)
                txtFinReqAmt.Text = ds.Tables(0).Rows(0).Item("AMOUNT").ToString
                txtFinReqTenor.Text = ds.Tables(0).Rows(0).Item("TENURE").ToString
                txtAdminFee.Text = ds.Tables(0).Rows(0).Item("ADMIN FEE").ToString
                txtFinReqIntRate.Text = ds.Tables(0).Rows(0).Item("INTEREST RATE").ToString
                bdpFinReqRepaymt.Text = CDate(ds.Tables(0).Rows(0).Item("1st REPAY DATE"))
            Else
                GridView1.DataSource = Nothing
            End If
            GridView1.DataBind()
            'End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub getScheduledPayments(ByVal LOANID As Long)
        Try
            cmd = New SqlCommand("select [LOANID] as 'Loan Id',[PAYMENT_DATE] as 'Payment Date',[PRINCIPAL] as 'Loan Amount',[INTEREST] as 'Interest',[PAYMENT] as 'Amount To Be Paid',[PRINCIPAL_BALANCE] as 'Loan Balance',[PAY_DATE] as 'Payment Received On',case [PAID] when 1 then 'Paid' when NULL then 'Not Paid' else 'Not Paid' end as 'Pay Status' from AMORTIZATION_SCHEDULE where LOANID='" & LOANID & "'", con)
            Dim ds As New DataSet
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "APP")
            If ds.Tables(0).Rows.Count > 0 Then
                GridView2.DataSource = ds.Tables(0)
            Else
                GridView2.DataSource = Nothing
            End If
            GridView2.DataBind()
            'End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub getApplications_Change(ByVal roleID As String, cliName As String)
        Try
            cmd = New SqlCommand("select ID,CUSTOMER_NUMBER as [CUST NO.],case IS_PARTIAL when 1 then RTRIM(isnull(SURNAME,'')+' '+isnull(FORENAMES,''))+' - PARTIALLY DISBURSED' else RTRIM(isnull(SURNAME,'')+' '+isnull(FORENAMES,'')) end as NAME,CONVERT(DECIMAL(30,2),FIN_AMT) as AMOUNT,isnull(APPL_DATE,CREATED_DATE) as 'APPLICATION DATE',case isnull(SSB_FILE_TYPE,'') when 'd' then 'SSB Deletion' when 'c' then 'SSB Change' when 'n' then 'SSB New' else '' end as 'SSB MARKED' from QUEST_APPLICATION where SUB_INDIVIDUAL='SSB' and STATUS<>'REJECTED' and RTRIM(isnull(SURNAME,'')+' '+isnull(FORENAMES,'')) like '%" & cliName & "%' order by id desc", con) '  and isnull(ssbApproved,0)=1 and
            Dim ds As New DataSet
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "APP")
            If ds.Tables(0).Rows.Count > 0 Then
                grdLoanAppsChange.DataSource = ds.Tables(0)
            Else
                grdLoanAppsChange.DataSource = Nothing
            End If
            grdLoanAppsChange.DataBind()

            'End If
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub grdApps_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles grdApps.PageIndexChanging
        grdApps.PageIndex = e.NewPageIndex
        'If Trim(txtSearchName.Text) = "" Then
        getApplications(Session("ROLE"), Trim(txtSearchName.Text))
        'Else
        '    searchGrid(txtSearchName.Text)
        'End If
    End Sub

    Protected Sub btnSearchRange_Click(sender As Object, e As EventArgs) Handles btnSearchRange.Click
        getApplications(Session("ROLE"), Trim(txtSearchName.Text))
    End Sub

    Protected Sub btnModify_Click(sender As Object, e As EventArgs) Handles btnModify.Click
        Dim myup As String = "n"

        If DropDownList1.SelectedIndex = 1 Then
            myup = "n"
        ElseIf DropDownList1.SelectedIndex = 2 Then
            myup = "d"
        ElseIf DropDownList1.SelectedIndex = 3 Then
            myup = "c"
        ElseIf DropDownList1.SelectedIndex = 0 Then
            msgbox("Please Select Change Type")
            Exit Sub
        End If
        For Each row As GridViewRow In grdApps.Rows
            Dim chkView As CheckBox = DirectCast(row.FindControl("chk"), CheckBox)
            'Dim modName = DirectCast(row.FindControl("lblModuleName"), Label).Text
            If chkView.Checked Then
                Dim LoanID As Integer = CInt(row.Cells(2).Text)
                cmd = New SqlCommand("select * from QUEST_APPLICATION where ID='" & LoanID & "'", con)
                Dim ds As New DataSet
                adp = New SqlDataAdapter(cmd)
                adp.Fill(ds, "QUEST_APPLICATION")
                If ds.Tables(0).Rows.Count > 0 Then
                    Dim cmdstr As String = ""
                    If myup = "d" Then
                        cmdstr = "update QUEST_APPLICATION Set SEND_TO='1024',SSB_FILE_TYPE='" & myup & "',FILE_SENT_TOSSB=0,SSB_FileNo=0 where ID=" & LoanID & ""
                    Else
                        cmdstr = "update QUEST_APPLICATION Set SSB_FILE_TYPE='" & myup & "',FILE_SENT_TOSSB=0,SSB_FileNo=0 where ID=" & LoanID & ""
                    End If
                    cmd = New SqlCommand(cmdstr, con)
                    If con.State = ConnectionState.Open Then
                        con.Close()
                    End If
                    con.Open()
                    If cmd.ExecuteNonQuery() Then
                    End If
                End If
            End If
        Next
        getApplications(Session("ROLE"), Trim(txtSearchName.Text))
        msgbox("Marked Applications Successfully Updated as New/Deletion for SSB download file")
    End Sub
    Protected Sub btnSelectAll_Click(sender As Object, e As EventArgs) Handles btnSelectAll.Click
        If grdApps.Rows.Count > 0 Then
            For Each row As GridViewRow In grdApps.Rows
                Dim chkView As CheckBox = DirectCast(row.FindControl("chk"), CheckBox)
                If chkView.Checked Then
                Else
                    chkView.Checked = True
                End If
            Next
        End If
    End Sub
    Protected Sub DropDownList1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownList1.SelectedIndexChanged
        If DropDownList1.SelectedIndex = 1 Then
            Panel1.Visible = True
            Panel2.Visible = False
        ElseIf DropDownList1.SelectedIndex = 2 Then
            Panel2.Visible = False
            Panel1.Visible = True
        ElseIf DropDownList1.SelectedIndex = 3 Then
            Panel1.Visible = True
            Panel2.Visible = False
        Else
            msgbox("Select Update Type")
            Panel1.Visible = False
            Panel2.Visible = False
            Exit Sub
        End If
    End Sub

    Protected Sub btnSearchRange0_Click(sender As Object, e As EventArgs) Handles btnSearchRange0.Click
        getApplications_Change(Session("ROLE"), Trim(txtSearchNameChange.Text))
    End Sub

    Protected Sub grdLoanAppsChange_SelectedIndexChanged(sender As Object, e As EventArgs) Handles grdLoanAppsChange.SelectedIndexChanged
        getApplications_Single(CLng(grdLoanAppsChange.SelectedRow.Cells(1).Text))
        getScheduledPayments(CLng(grdLoanAppsChange.SelectedRow.Cells(1).Text))
        ' msgbox(grdLoanAppsChange.SelectedRow.Cells(1).Text)
    End Sub
    Protected Sub grdLoanAppsChange_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles grdLoanAppsChange.PageIndexChanging
        Try
            grdLoanAppsChange.PageIndex = e.NewPageIndex
            getApplications_Change(Session("ROLE"), txtSearchNameChange.Text)
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btnModifyChange_Click(sender As Object, e As EventArgs) Handles btnModifyChange.Click
        'check values all provided
        If grdLoanAppsChange.Rows.Count <= 0 Then
            msgbox("Select a Loan")
            Exit Sub
        End If
        If grdLoanAppsChange.SelectedIndex < 0 Then
            msgbox("Select a Loan")
            Exit Sub
        End If
        If GridView1.Rows.Count <= 0 Then
            msgbox("Selected Loan is not yet Approved")
            Exit Sub
        End If
        If txtFinReqAmt.Text = "" Or txtFinReqIntRate.Text = "" Or txtFinReqTenor.Text = "" Or txtAdminFee.Text = "" Or bdpFinReqRepaymt.Text = "" Then
            msgbox("Provide New Loan Details")
            Exit Sub
        End If
        If IsNumeric(txtFinReqAmt.Text) = False Or IsNumeric(txtFinReqIntRate.Text) = False Or IsNumeric(txtFinReqTenor.Text) = False Or IsNumeric(txtAdminFee.Text) = False Then
            msgbox("Provide New Loan Details in correct formats")
            Exit Sub
        End If
        If Val(txtFinReqAmt.Text) = 0 Or Val(txtFinReqIntRate.Text) = 0 Or Val(txtFinReqTenor.Text) = 0 Or Val(txtAdminFee.Text) = 0 Then
            msgbox("Provide New Loan Details in correct formats")
            Exit Sub
        End If
        'check values all provided
        '-------------------------------------------------------------------------
        Dim LoanID As Long = CLng(grdLoanAppsChange.SelectedRow.Cells(1).Text)
        cmd = New SqlCommand("select * from QUEST_APPLICATION where ID='" & LoanID & "'", con)
        Dim ds As New DataSet
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "APP")
        If ds.Tables(0).Rows.Count > 0 Then
            'transfer to history be4 update

            cmd = New SqlCommand("insert into QUEST_APPLICATION_CHANGES (ID, CUSTOMER_TYPE, SUB_INDIVIDUAL, CUSTOMER_NUMBER, SURNAME, FORENAMES, DOB, IDNO, ISSUE_DATE, ADDRESS, CITY, PHONE_NO, NATIONALITY, GENDER, HOME_TYPE, MONTHLY_RENT, HOME_LENGTH, MARITAL_STATUS, EDUCATION, CURR_EMPLOYER, CURR_EMP_ADD, CURR_EMP_LENGTH, CURR_EMP_PHONE, CURR_EMP_EMAIL, CURR_EMP_FAX, CURR_EMP_CITY, CURR_EMP_POSITION, CURR_EMP_SALARY, CURR_EMP_NET, CURR_EMP_INCOME, PREV_EMPLOYER, PREV_EMP_ADD, PREV_EMP_LENGTH, PREV_EMP_PHONE, PREV_EMP_EMAIL, PREV_EMP_FAX, PREV_EMP_CITY, PREV_EMP_POSITION, PREV_EMP_SALARY, PREV_EMP_NET, PREV_EMP_INCOME, SPOUSE_NAME, SPOUSE_OCCUPATION, SPOUSE_EMPLOYER, SPOUSE_PHONE, NO_CHILDREN, NO_DEPENDANTS, TRADE_REF1, TRADE_REF2, CREDIT_LIMIT, HAS_ACCOUNT, ACCOUNT_BRANCH, ACCOUNT_NUMBER, GUARANTOR_NAME, GUARANTOR_DOB, GUARANTOR_IDNO, GUARANTOR_PHONE, GUARANTOR_ADD, GUARANTOR_CITY, GUARANTOR_HOME_TYPE, GUARANTOR_RENT, GUARANTOR_HOME_LENGTH, GUARANTOR_EMPLOYER, GUARANTOR_EMP_ADD, GUARANTOR_EMP_LENGTH, GUARANTOR_EMP_PHONE, GUARANTOR_EMP_EMAIL, GUARANTOR_EMP_FAX, GUARANTOR_EMP_POSTN, GUARANTOR_EMP_SALARY, GUARANTOR_EMP_INCOME, GUARANTOR_REL_NAME, GUARANTOR_REL_ADD, GUARANTOR_REL_CITY, GUARANTOR_REL_PHONE, GUARANTOR_REL_RELTNSHP, FIN_REPAY_OPT, FIN_AMT, FIN_TENOR, FIN_INT_RATE, FIN_ADMIN, FIN_PURPOSE, FIN_SRC_REPAYMT, FIN_SEC_OFFER, FIN_BANK, FIN_BRANCH, FIN_BRANCH_CODE, FIN_ACCNO, FIN_REPAY_DATE, OTHER_DESC, OTHER_ACCNO, OTHER_AMT, QUES_HOW, QUES_EMPLOYEE, QUES_AGENT, APPL_SIGNATURE, APPL_DATE, JOINT_APPL_SIGNATURE, APP1_APPROVED, RECOMMENDED_AMT, REC_DATE, RECOMMENDED, DISBURSED, DISBURSED_DATE, APP1_SIGNATURE, APP1_DATE, APP2_APPROVED, APPROVED_AMT, APP2_SIGNATURE, APP2_DATE, INSTALLMENT, PERIOD, STATUS, SEND_TO, CREATED_BY, CREATED_DATE, MODIFIED_BY, MODIFIED_DATE, BUS_TYPE, BUS_PERIOD, SOURCE1, SOURCE2, SOURCE3, BORROWING1, BORROWING2, BORROWING3, BRANCH_CODE, BRANCH_NAME, REPAID, AREA, LOAN_SECTOR, AMT_APPLIED, ECOCASH_NUMBER, OTHER_CHARGES, APP_FORM, APP_FORM_TYPE, DISBURSE_OPTION, APP_FORM_EXT, MIN_DEPT, MIN_DEPT_NO, ECNO, CD, SSB_NEW, SSB_CHANGE, SSB_CEASE, SSB_MONTHLY_RATE, SSB_FROM, SSB_TO, SSB_REF, SSB_GENERATOR, SSB_GEN_DATE, APPROVED_FOR_DISBURSAL, INITIATOR_ID, LM_ID, HL_ID, MD_ID, DB_IDD, LAST_ID, LO_ID, MONTH_EXPENSE, MONTH_INCOME, PREV_SALES, CURR_ESTIMATE, CROPS, FARM_PERIOD, SPOUSE_ADDRESS, SPOUSE_IDNO, IS_PARTIAL, ORIGINAL_ID, INT_RATE, INSURANCE_RATE, ADMIN_RATE, AGENT_CODE, FILE_SENT_TOSSB, SSB_FILE_TYPE, ssbApproved, ssbApprovedBy, ssbApprovedDate, AGENT_COMMISSION_PERC) select H.ID,H.CUSTOMER_TYPE,H.SUB_INDIVIDUAL,H.CUSTOMER_NUMBER,H.SURNAME,H.FORENAMES,H.DOB,H.IDNO,H.ISSUE_DATE,H.ADDRESS,H.CITY,H.PHONE_NO,H.NATIONALITY,H.GENDER,H.HOME_TYPE,H.MONTHLY_RENT,H.HOME_LENGTH,H.MARITAL_STATUS,H.EDUCATION,H.CURR_EMPLOYER,H.CURR_EMP_ADD,H.CURR_EMP_LENGTH,H.CURR_EMP_PHONE,H.CURR_EMP_EMAIL,H.CURR_EMP_FAX,H.CURR_EMP_CITY,H.CURR_EMP_POSITION,H.CURR_EMP_SALARY,H.CURR_EMP_NET,H.CURR_EMP_INCOME,H.PREV_EMPLOYER,H.PREV_EMP_ADD,H.PREV_EMP_LENGTH,H.PREV_EMP_PHONE,H.PREV_EMP_EMAIL,H.PREV_EMP_FAX,H.PREV_EMP_CITY,H.PREV_EMP_POSITION,H.PREV_EMP_SALARY,H.PREV_EMP_NET,H.PREV_EMP_INCOME,H.SPOUSE_NAME,H.SPOUSE_OCCUPATION,H.SPOUSE_EMPLOYER,H.SPOUSE_PHONE,H.NO_CHILDREN,H.NO_DEPENDANTS,H.TRADE_REF1,H.TRADE_REF2,H.CREDIT_LIMIT,H.HAS_ACCOUNT,H.ACCOUNT_BRANCH,H.ACCOUNT_NUMBER,H.GUARANTOR_NAME,H.GUARANTOR_DOB,H.GUARANTOR_IDNO,H.GUARANTOR_PHONE,H.GUARANTOR_ADD,H.GUARANTOR_CITY,H.GUARANTOR_HOME_TYPE,H.GUARANTOR_RENT,H.GUARANTOR_HOME_LENGTH,H.GUARANTOR_EMPLOYER,H.GUARANTOR_EMP_ADD,H.GUARANTOR_EMP_LENGTH,H.GUARANTOR_EMP_PHONE,H.GUARANTOR_EMP_EMAIL,H.GUARANTOR_EMP_FAX,H.GUARANTOR_EMP_POSTN,H.GUARANTOR_EMP_SALARY,H.GUARANTOR_EMP_INCOME,H.GUARANTOR_REL_NAME,H.GUARANTOR_REL_ADD,H.GUARANTOR_REL_CITY,H.GUARANTOR_REL_PHONE,H.GUARANTOR_REL_RELTNSHP,H.FIN_REPAY_OPT,H.FIN_AMT,H.FIN_TENOR,H.FIN_INT_RATE,H.FIN_ADMIN,H.FIN_PURPOSE,H.FIN_SRC_REPAYMT,H.FIN_SEC_OFFER,H.FIN_BANK,H.FIN_BRANCH,H.FIN_BRANCH_CODE,H.FIN_ACCNO,H.FIN_REPAY_DATE,H.OTHER_DESC,H.OTHER_ACCNO,H.OTHER_AMT,H.QUES_HOW,H.QUES_EMPLOYEE,H.QUES_AGENT,H.APPL_SIGNATURE,H.APPL_DATE,H.JOINT_APPL_SIGNATURE,H.APP1_APPROVED,H.RECOMMENDED_AMT,H.REC_DATE,H.RECOMMENDED,H.DISBURSED,H.DISBURSED_DATE,H.APP1_SIGNATURE,H.APP1_DATE,H.APP2_APPROVED,H.APPROVED_AMT,H.APP2_SIGNATURE,H.APP2_DATE,H.INSTALLMENT,H.PERIOD,H.STATUS,H.SEND_TO,H.CREATED_BY,H.CREATED_DATE,H.MODIFIED_BY,H.MODIFIED_DATE,H.BUS_TYPE,H.BUS_PERIOD,H.SOURCE1,H.SOURCE2,H.SOURCE3,H.BORROWING1,H.BORROWING2,H.BORROWING3,H.BRANCH_CODE,H.BRANCH_NAME,H.REPAID,H.AREA,H.LOAN_SECTOR,H.AMT_APPLIED,H.ECOCASH_NUMBER,H.OTHER_CHARGES,H.APP_FORM,H.APP_FORM_TYPE,H.DISBURSE_OPTION,H.APP_FORM_EXT,H.MIN_DEPT,H.MIN_DEPT_NO,H.ECNO,H.CD,H.SSB_NEW,H.SSB_CHANGE,H.SSB_CEASE,H.SSB_MONTHLY_RATE,H.SSB_FROM,H.SSB_TO,H.SSB_REF,H.SSB_GENERATOR,H.SSB_GEN_DATE,H.APPROVED_FOR_DISBURSAL,H.INITIATOR_ID,H.LM_ID,H.HL_ID,H.MD_ID,H.DB_IDD,H.LAST_ID,H.LO_ID,H.MONTH_EXPENSE,H.MONTH_INCOME,H.PREV_SALES,H.CURR_ESTIMATE,H.CROPS,H.FARM_PERIOD,H.SPOUSE_ADDRESS,H.SPOUSE_IDNO,H.IS_PARTIAL,H.ORIGINAL_ID,H.INT_RATE,H.INSURANCE_RATE,H.ADMIN_RATE,H.AGENT_CODE,H.FILE_SENT_TOSSB,H.SSB_FILE_TYPE,H.ssbApproved,H.ssbApprovedBy,H.ssbApprovedDate,H.AGENT_COMMISSION_PERC from QUEST_APPLICATION H where H.ID = " & LoanID & "", con)
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            con.Open()
            If cmd.ExecuteNonQuery() Then
                Dim NEWLOANAMOUNT As Double = 0
                Dim NEWADMINFEE As Double = 0
                Dim NEWINTEREST As Double = 0
                Dim NEWFIRSTREPAYDATE As Date = GetNextPaymentDate(LoanID) ' = bdpFinReqRepaymt.SelectedDate
                Dim NEWREPAYMONTHS As Long = 0
                Dim REMAININGBALANCE As Double = GetRemainingBalance(LoanID)
                Dim REMAININGMONTHS As Double = GetRemainingMonths(LoanID)
                NEWREPAYMONTHS = CLng(txtFinReqTenor.Text) + REMAININGMONTHS
                NEWADMINFEE = CDbl(txtAdminFee.Text)
                NEWINTEREST = CDbl(txtFinReqIntRate.Text)
                NEWLOANAMOUNT = REMAININGBALANCE + CDbl(txtFinReqAmt.Text)
                cmd = New SqlCommand("update QUEST_APPLICATION set FILE_SENT_TOSSB=0,SEND_TO='1024',APP2_APPROVED='1',APP2_DATE=GETDATE(),MD_ID='" & Session("ID") & "',LAST_ID='" & Session("ID") & "',FIN_AMT='" & NEWLOANAMOUNT & "', FIN_TENOR='" & NEWREPAYMONTHS & "', FIN_INT_RATE='" & NEWINTEREST & "', FIN_ADMIN='" & NEWADMINFEE & "',FIN_REPAY_DATE='" & NEWFIRSTREPAYDATE.ToString("dd-MMM-yyyy") & "',AMOUNT_TO_DISBURSE='" & txtFinReqAmt.Text & "',RECOMMENDED_AMT='" & NEWLOANAMOUNT & "',APPROVED_AMT='" & NEWLOANAMOUNT & "',AMT_APPLIED='" & NEWLOANAMOUNT & "',SSB_FILE_TYPE='c' where ID = '" & LoanID & "'", con)
                If con.State = ConnectionState.Open Then
                    con.Close()
                End If
                con.Open()
                Try
                    If cmd.ExecuteNonQuery() Then
                        msgbox("Loan Changes Applied")
                        Exit Sub
                    End If
                Catch ex As Exception
                    msgbox(ex.Message.ToString)
                End Try

            End If
            'transfer to history be4 update
        End If
    End Sub
    Protected Function GetRemainingMonths(ByVal LoanID As Long) As Long
        cmd = New SqlCommand("select isnull(COUNT(*),0) AS totUnpaid from AMORTIZATION_SCHEDULE where LOANID='" & LoanID & "' and ISNULL(PAID,0)<>1", con)
        Dim ds As New DataSet
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "APP")
        If ds.Tables(0).Rows.Count > 0 Then
            Return CLng(ds.Tables(0).Rows(0).Item("totUnpaid"))
        Else
            Return 0
        End If
    End Function
    Protected Function GetRemainingBalance(ByVal LoanID As Long) As Long
        cmd = New SqlCommand("select top 1 isnull(PRINCIPAL_BALANCE,0)+PRINCIPAL AS RemainingBal from AMORTIZATION_SCHEDULE where LOANID='" & LoanID & "' and ISNULL(PAID,0)<>1 order by PAYMENT_NO ASC", con)
        Dim ds As New DataSet
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "APP")
        If ds.Tables(0).Rows.Count > 0 Then
            Return CLng(ds.Tables(0).Rows(0).Item("RemainingBal"))
        Else
            Return 0
        End If
    End Function
    Protected Function GetNextPaymentDate(ByVal LoanID As Long) As Date
        cmd = New SqlCommand("select top 1 PAYMENT_DATE AS NextPaymentDate from AMORTIZATION_SCHEDULE where LOANID='" & LoanID & "' and ISNULL(PAID,0)<>1 order by PAYMENT_NO ASC", con)
        Dim ds As New DataSet
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "APP")
        If ds.Tables(0).Rows.Count > 0 Then
            Return CDate(ds.Tables(0).Rows(0).Item("NextPaymentDate"))
        Else
            Return bdpFinReqRepaymt.Text
        End If
    End Function
    Protected Sub btnSearchECNo_Click(sender As Object, e As EventArgs) Handles btnSearchECNo.Click
        If txtECNumber.Text <> "" Then
            getApplications_ECNumber(Session("ROLE"), txtECNumber.Text)
        Else
            msgbox("Enter EC No.")
            Exit Sub
        End If
    End Sub
End Class