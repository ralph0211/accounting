Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports CreditManager
Imports System
Imports ErrorLogging
Imports System.Drawing

Partial Class Credit_Enquiry
    Inherits System.Web.UI.Page
    Dim adp As SqlDataAdapter
    Dim cmd As SqlCommand
    Dim con As New SqlConnection

    Shared Sub approveJQuery(ByVal roleID As String, ByVal appID As String)
        Try
            Dim comm As New SqlCommand
            Dim con As New SqlConnection
            con = New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
            If roleID = "4042" Then
                comm = New SqlCommand(String.Format("update QUEST_APPLICATION set STATUS='RECOMMENDED',SEND_TO='4043',RECOMMENDED='1',REC_DATE=GETDATE() where ID='{0}'", appID), con)
            ElseIf roleID = "4043" Then
                comm = New SqlCommand(String.Format("update QUEST_APPLICATION set STATUS='APPROVED1',SEND_TO='4044',APP1_APPROVED='1',APP1_DATE=GETDATE() where ID='{0}'", appID), con)
            ElseIf roleID = "4044" Then
                comm = New SqlCommand(String.Format("update QUEST_APPLICATION set STATUS='APPROVED2',SEND_TO='1024',APP2_APPROVED='1',APP2_DATE=GETDATE() where ID='{0}'", appID), con)
            ElseIf roleID = "1024" Then
                comm = New SqlCommand(String.Format("update QUEST_APPLICATION set STATUS='DISBURSED',SEND_TO='',DISBURSED='1',DISBURSED_DATE=GETDATE() where ID='{0}'", appID), con)
            End If
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            con.Open()
            comm.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception

        End Try
    End Sub

    Shared Sub approveJQuery2(ByVal appID As String)
        Try
            Dim comm As New SqlCommand
            Dim con As New SqlConnection
            con = New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
            comm = New SqlCommand(String.Format("update QUEST_APPLICATION set STATUS='RECOMMENDED',SEND_TO='4043',RECOMMENDED='1',REC_DATE=GETDATE() where ID='{0}'", appID), con)
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            con.Open()
            comm.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception

        End Try
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

    Protected Sub bindGrid()
        Dim query = queryBuilder()
        If Trim(query) = "" Then
            cmd = New SqlCommand("select ID,CUSTOMER_NUMBER,CUSTOMER_TYPE,BRANCH_NAME,STATUS,SURNAME+' '+FORENAMES as NAME,convert(varchar,CREATED_DATE,113) as CREATED_DATE1 from QUEST_APPLICATION", con)
        Else
            cmd = New SqlCommand(String.Format("select ID,CUSTOMER_NUMBER,CUSTOMER_TYPE,BRANCH_NAME,STATUS,SURNAME+' '+FORENAMES as NAME,convert(varchar,CREATED_DATE,113) as CREATED_DATE1 from QUEST_APPLICATION where ID is not null {0}", query), con)
        End If
        Dim ds As New DataSet
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "RESLT")
        If ds.Tables(0).Rows.Count > 0 Then
            grdSearchResults.DataSource = ds.Tables(0)
        Else
            grdSearchResults.DataSource = Nothing
        End If
        grdSearchResults.DataBind()
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

    Protected Sub btnSearchLoan_Click(sender As Object, e As EventArgs) Handles btnSearchLoan.Click
        Try
            grdSearchResults.SelectedIndex = -1
            grdSearchResults.PageIndex = 0
            bindGrid()
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub chkBranch_CheckedChanged(sender As Object, e As EventArgs) Handles chkBranch.CheckedChanged
        If chkBranch.Checked Then
            cmbSearchBranch.Visible = True
            loadUsersByRole(cmbSearchLoanOfficer, "4041", cmbSearchBranch.SelectedValue)
        Else
            cmbSearchBranch.Visible = False
            loadUsersByRole(cmbSearchLoanOfficer, "4041")
        End If
    End Sub

    Protected Sub chkClientType_CheckedChanged(sender As Object, e As EventArgs) Handles chkClientType.CheckedChanged
        If chkClientType.Checked Then
            cmbSearchClientType.Visible = True
            loadClientType(cmbSearchClientType)
        Else
            cmbSearchClientType.Visible = False
        End If
    End Sub

    Protected Sub chkDateRange_CheckedChanged(sender As Object, e As EventArgs) Handles chkDateRange.CheckedChanged
        If chkDateRange.Checked Then
            lblSearchDateFrom.Visible = True
            lblSearchDateTo.Visible = True
            txtSearchFromDate.Visible = True
            txtSearchToDate.Visible = True
        Else
            lblSearchDateFrom.Visible = False
            lblSearchDateTo.Visible = False
            txtSearchFromDate.Visible = False
            txtSearchToDate.Visible = False
        End If
    End Sub

    Protected Sub chkDisbDateRange_CheckedChanged(sender As Object, e As EventArgs) Handles chkDisbDateRange.CheckedChanged
        If chkDisbDateRange.Checked Then
            lblSearchDisbDateFrom.Visible = True
            lblSearchDisbDateTo.Visible = True
            txtSearchDisbFromDate.Visible = True
            txtSearchDisbToDate.Visible = True
        Else
            lblSearchDisbDateFrom.Visible = False
            lblSearchDisbDateTo.Visible = False
            txtSearchDisbFromDate.Visible = False
            txtSearchDisbToDate.Visible = False
        End If
    End Sub

    '    getAppHistory()
    '    getAppDetails(txtCustNo.Text)
    '    writeSubmitButton(Session("ROLE"))
    '    loadAppForm()
    '    lnkAppRating.NavigateUrl = "ApplicationRating.aspx?loanID=" & txtCustNo.Text
    '    lnkAmortizationSchedule.NavigateUrl = "rptAmortizationSchedule.aspx?loanID=" & txtCustNo.Text
    'End Sub
    Protected Sub chkLoanOfficer_CheckedChanged(sender As Object, e As EventArgs) Handles chkLoanOfficer.CheckedChanged
        If chkLoanOfficer.Checked Then
            cmbSearchLoanOfficer.Visible = True
            loadUserType()
        Else
            cmbSearchLoanOfficer.Visible = False
            loadUserType()
        End If
    End Sub

    Protected Sub chkLoanStatus_CheckedChanged(sender As Object, e As EventArgs) Handles chkLoanStatus.CheckedChanged
        If chkLoanStatus.Checked Then
            cmbSearchLoanStatus.Visible = True
            loadQuestLoanStatus(cmbSearchLoanStatus)
        Else
            cmbSearchLoanStatus.Visible = False
        End If
    End Sub

    Protected Sub chkSearchName_CheckedChanged(sender As Object, e As EventArgs) Handles chkSearchName.CheckedChanged
        If chkSearchName.Checked Then
            txtSearchCustName.Visible = True
        Else
            txtSearchCustName.Visible = False
        End If
    End Sub

    Protected Sub cmbSearchBranch_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSearchBranch.SelectedIndexChanged
        If chkBranch.Checked Then
            loadUsersByRole(cmbSearchLoanOfficer, "4041", cmbSearchBranch.SelectedValue)
        Else
            loadUsersByRole(cmbSearchLoanOfficer, "4041")
        End If
    End Sub

    Protected Sub getAppDetails(ByVal loanID As String)
        Try
            cmd = New SqlCommand(String.Format("select *,convert(varchar,DOB,106) as DOB1,convert(varchar,ISSUE_DATE,106) as ISSUE_DATE1,convert(varchar,GUARANTOR_DOB,106) as GUARANTOR_DOB1,convert(varchar,FIN_REPAY_DATE,106) as FIN_REPAY_DATE1,convert(varchar(50),DISBURSED_DATE,106) as DISDATE from QUEST_APPLICATION where ID='{0}'", loanID), con)
            Dim ds As New DataSet
            Dim adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "APP")
            If ds.Tables(0).Rows.Count > 0 Then
                Dim EncQuery As New BankEncryption64
                lnkAmortizationSchedule.NavigateUrl = "rptAmortizationSchedule.aspx?loanID=" & EncQuery.Encrypt(loanID).Replace(" ", "+")

                getRepaymentHistory(loanID)
                calculateOnTime()
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
                txtAdminRate.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("ADMIN_RATE"))
                txtInsuranceRate.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("INSURANCE_RATE"))
                txtInterestRate.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("INT_RATE"))
                Try
                    cmbFinReqPurpose.Items.Add(BankString.isNullString(ds.Tables(0).Rows(0).Item("FIN_PURPOSE")))
                    cmbFinReqPurpose.SelectedItem.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("FIN_PURPOSE"))
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
                txtIDNo.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("IDNO"))
                txtNationality.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("NATIONALITY"))
                Try
                    txtNoChildren.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("NO_CHILDREN"))
                Catch ex As Exception
                    txtNoChildren.Text = ""
                End Try
                Try
                    txtNoDependant.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("NO_DEPENDANTS"))
                Catch ex As Exception
                    txtNoDependant.Text = ""
                End Try
                txtPrevEmpAddress.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("PREV_EMP_ADD"))
                txtPrevEmpAnnualIncome.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("PREV_EMP_INCOME"))
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
                txtFinReqAccNo.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("BankAccountNo"))
                bdpFinReqRepaymt.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("FIN_REPAY_DATE"))
                Try
                    txtFinReqAmt.Text = FormatNumber(BankString.isNullString(ds.Tables(0).Rows(0).Item("AMT_APPLIED")), 2)
                Catch ex As Exception
                    txtFinReqAmt.Text = ""
                End Try
                Try
                    txtRecAmt.Text = FormatNumber(BankString.isNullString(ds.Tables(0).Rows(0).Item("FIN_AMT")), 2)
                Catch ex As Exception
                    txtRecAmt.Text = ""
                End Try
                txtFinReqBank.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("BANK"))
                txtFinReqBranchCode.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("BankBranch"))
                txtFinReqBranchName.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("BankBranch"))
                Try
                    txtFinReqIntRate.Text = FormatNumber(BankString.isNullString(ds.Tables(0).Rows(0).Item("FIN_INT_RATE")), 2)
                Catch ex As Exception
                    txtFinReqIntRate.Text = ""
                End Try
                txtFinReqPurpose.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("FIN_PURPOSE"))
                txtFinReqSecOffer.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("FIN_SEC_OFFER"))
                txtFinReqSource.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("FIN_SRC_REPAYMT"))
                Try
                    txtFinReqTenor.Text = FormatNumber(BankString.isNullString(ds.Tables(0).Rows(0).Item("FIN_TENOR")), 0)
                Catch ex As Exception
                    txtFinReqTenor.Text = ""
                End Try
                'txtOtherAccNo.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("OTHER_ACCNO"))
                'Try
                '    txtOtherAmt.Text = FormatNumber(BankString.isNullString(ds.Tables(0).Rows(0).Item("OTHER_AMT")), 2)
                'Catch ex As Exception
                '    txtOtherAmt.Text = ""
                'End Try
                'txtOtherDesc.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("OTHER_DESC"))
                txtQuesAgent.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("QUES_AGENT"))
                txtQuesEmployee.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("QUES_EMPLOYEE"))
                lblDisbDate.Text = "Disbursement Date: " & BankString.isNullString(ds.Tables(0).Rows(0).Item("DISDATE"))

                loadOtherLoans(ds.Tables(0).Rows(0).Item("CUSTOMER_NUMBER").ToString)
                Try
                    rdbGender.SelectedValue = ds.Tables(0).Rows(0).Item("GENDER").ToString
                Catch ex As Exception
                    rdbGender.ClearSelection()
                End Try
                Try
                    rdbHouse.SelectedValue = ds.Tables(0).Rows(0).Item("HOME_TYPE").ToString
                Catch ex As Exception
                    rdbHouse.ClearSelection()
                End Try
                Try
                    rdbGuarHomeType.SelectedValue = ds.Tables(0).Rows(0).Item("GUARANTOR_HOME_TYPE").ToString
                Catch ex As Exception
                    rdbGuarHomeType.ClearSelection()
                End Try
                Try
                    rdbQuesHow.SelectedValue = ds.Tables(0).Rows(0).Item("QUES_HOW").ToString
                Catch ex As Exception
                    rdbQuesHow.ClearSelection()
                End Try
                Try
                    rdbFinReqDisburseOption.SelectedValue = ds.Tables(0).Rows(0).Item("DISBURSE_OPTION").ToString
                Catch ex As Exception
                    rdbFinReqDisburseOption.ClearSelection()
                End Try
                Try
                    cmbEducation.SelectedValue = ds.Tables(0).Rows(0).Item("EDUCATION").ToString
                Catch ex As Exception
                    cmbEducation.ClearSelection()
                End Try
                Try
                    cmbMaritalStatus.SelectedValue = ds.Tables(0).Rows(0).Item("MARITAL_STATUS").ToString
                Catch ex As Exception
                    cmbMaritalStatus.ClearSelection()
                End Try
                Try
                    cmbProductType.SelectedValue = BankString.isNullString(ds.Tables(0).Rows(0).Item("FinProductType"))
                Catch ex As Exception
                    cmbProductType.ClearSelection()
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
                If BankString.isNullString(ds.Tables(0).Rows(0).Item("GUARANTOR_DOB1")) = "01 Jan 1900" Then
                    bdpGuarDOB.Text = ""
                Else
                    bdpGuarDOB.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("GUARANTOR_DOB1"))
                End If
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

                txtRepaymentInterval.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("RepaymentIntervalNum"))
                Try
                    cmbRepaymentInterval.SelectedValue = BankString.isNullString(ds.Tables(0).Rows(0).Item("RepaymentIntervalUnit"))
                Catch ex As Exception
                    cmbRepaymentInterval.ClearSelection()
                End Try

                Try
                    cmbFinReqPurpose.SelectedValue = BankString.isNullString(ds.Tables(0).Rows(0).Item("FIN_PURPOSE"))
                Catch ex As Exception
                    cmbFinReqPurpose.ClearSelection()
                End Try
                Try
                    cmbSector.SelectedValue = BankString.isNullString(ds.Tables(0).Rows(0).Item("Sector"))
                Catch ex As Exception
                    cmbSector.ClearSelection()
                End Try

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
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub getAppDetailsGroup(ByVal loanID As String)
        Try
            cmd = New SqlCommand(String.Format("select *,convert(varchar(50),DISBURSED_DATE,106) as DISDATE,convert(varchar(50),DOB,106) as DOB1,convert(varchar(50),ISSUE_DATE,106) as ISSUE_DATE1 from QUEST_APPLICATION where ID='{0}'", loanID), con)
            Dim ds As New DataSet
            Dim adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "APP")
            If ds.Tables(0).Rows.Count > 0 Then
                txtGrpName.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("SURNAME"))
                txtGrpApplicantName.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("FORENAMES"))
                lblBranchCode.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("BRANCH_CODE"))
                lblBranchName.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("BRANCH_NAME"))
                txtGrpApplCurrAdd.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("ADDRESS"))
                txtGrpApplPhone.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("PHONE_NO"))
                txtGrpApplCity.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("CITY"))
                txtGrpApplLineBus.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("BUS_TYPE"))
                txtGrpApplPeriodBus.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("BUS_PERIOD"))
                txtGrpApplID.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("IDNO"))
                txtGrpApplNationality.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("NATIONALITY"))
                txtGrpApplSrcIncome1.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("SOURCE1"))
                txtGrpApplSrcIncome2.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("SOURCE2"))
                txtGrpApplSrcIncome3.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("SOURCE3"))
                txtGrpApplBorrow1.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("BORROWING1"))
                txtGrpApplBorrow2.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("BORROWING2"))
                txtGrpApplBorrow3.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("BORROWING3"))
                Try
                    txtGrpApplLoanAmt.Text = FormatNumber(BankString.isNullString(ds.Tables(0).Rows(0).Item("FIN_AMT")), 2)
                Catch ex As Exception
                    txtGrpApplLoanAmt.Text = ""
                End Try
                Try
                    txtGrpApplInterest.Text = FormatNumber(BankString.isNullString(ds.Tables(0).Rows(0).Item("FIN_INT_RATE")), 2)
                Catch ex As Exception
                    txtGrpApplInterest.Text = ""
                End Try
                txtGrpApplPurpose.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("FIN_PURPOSE"))
                Try
                    txtGrpApplRepayTenure.Text = FormatNumber(BankString.isNullString(ds.Tables(0).Rows(0).Item("FIN_TENOR")), 0)
                Catch ex As Exception
                    txtGrpApplRepayTenure.Text = ""
                End Try
                lblDisbDate.Text = "Disbursement Date: " & BankString.isNullString(ds.Tables(0).Rows(0).Item("DISDATE"))

                loadOtherLoans(ds.Tables(0).Rows(0).Item("CUSTOMER_NUMBER"))
                Try
                    rdbGrpApplGender.SelectedValue = ds.Tables(0).Rows(0).Item("GENDER")
                Catch ex As Exception

                End Try

                txtGrpApplDOB.Text = ds.Tables(0).Rows(0).Item("DOB1")
                txtGrpApplIssueDate.Text = ds.Tables(0).Rows(0).Item("ISSUE_DATE1")
            Else
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub getAppHistory(loanId As String)
        Try
            cmd = New SqlCommand(String.Format("select COMMENT_DATE as [DATE], USERID as [USER],CONVERT(DECIMAL(30,2),[RECOMMENDED_AMT]) as [RECOMMENDED AMOUNT],COMMENT from REQUEST_HISTORY where LOANID='{0}' order by COMMENT_DATE ", loanId), con)
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

    Protected Function getCommand(ByVal roleID As String) As SqlCommand
        Dim comm As New SqlCommand
        If roleID = "4042" Then
            comm = New SqlCommand(String.Format("update QUEST_APPLICATION set STATUS='RECOMMENDED',SEND_TO='4043',RECOMMENDED='1',REC_DATE=GETDATE(),FIN_AMT='{0}' where ID='{1}'", txtRecAmt.Text, Request.QueryString("id")), con)
        ElseIf roleID = "4043" Then
            comm = New SqlCommand(String.Format("update QUEST_APPLICATION set STATUS='APPROVED1',SEND_TO='4044',APP1_APPROVED='1',APP1_DATE=GETDATE(),FIN_AMT='{0}' where ID='{1}'", txtRecAmt.Text, Request.QueryString("id")), con)
        ElseIf roleID = "4044" Then
            comm = New SqlCommand(String.Format("update QUEST_APPLICATION set STATUS='APPROVED2',SEND_TO='1024',APP2_APPROVED='1',APP2_DATE=GETDATE(),FIN_AMT='{0}' where ID='{1}'", txtRecAmt.Text, Request.QueryString("id")), con)
        ElseIf roleID = "1024" Then
            comm = New SqlCommand(String.Format("update QUEST_APPLICATION set STATUS='DISBURSED',SEND_TO='',DISBURSED='1',DISBURSED_DATE=GETDATE() where ID='{0}'", Request.QueryString("id")), con)
        End If
        Return comm
    End Function

    Protected Function getEducation() As String
        If cmbEducation.SelectedValue = "Other" Then
            Return Trim("Other: " & BankString.removeSpecialCharacter(txtEducationOther.Text))
        Else
            Return cmbEducation.SelectedValue
        End If
    End Function

    Protected Sub grdDocuments_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles grdDocuments.RowCommand
        If e.CommandName = "Select" Then
            Dim docID = e.CommandArgument
            'lblDetailID.Text = docID
            'btnModalPopup.Visible = True
            Dim strscript As String

            strscript = "<script language=JavaScript>"
            strscript += "window.open('viewDocument.aspx?id=" & docID & "');"
            strscript += "</script>"
            'ClientScript.RegisterStartupScript(Me.GetType(), "HideLabel", "<script type=""text/javascript"">setTimeout(""document.getElementById('" & lblAppUploadMsg.ClientID & "').style.display='none'"",5000)</script>")
            ClientScript.RegisterStartupScript(Me.GetType(), "newwin", strscript)

        End If
    End Sub

    Protected Sub grdSearchResults_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles grdSearchResults.PageIndexChanging
        grdSearchResults.PageIndex = e.NewPageIndex
        bindGrid()
    End Sub

    Protected Sub grdSearchResults_SelectedIndexChanged(sender As Object, e As EventArgs) Handles grdSearchResults.SelectedIndexChanged
        Try
            Label18.Visible = True
            Dim loanID = grdSearchResults.SelectedRow.Cells(2).Text
            Dim appType = grdSearchResults.SelectedRow.Cells(3).Text
            If appType = "Individual" Then
                panIndividual.Visible = True
                panGroup.Visible = False
                getAppHistory(loanID)
                getAppDetails(loanID)
                loadUploadedFiles(loanID)
            ElseIf appType = "Group" Then
                panGroup.Visible = True
                panIndividual.Visible = False
                getAppHistory(loanID)
                getAppDetailsGroup(loanID)
            End If
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- grdSearchResults_SelectedIndexChanged()", ex.ToString)
            msgbox(ex.Message.ToString)
        End Try
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

    Protected Sub loadNavBar()
        'Try
        '    Dim ViewCount As Integer = Me.mltAppForm.Views.Count
        '    Dim ActiveIndex As Integer = Me.mltAppForm.ActiveViewIndex
        '    Dim lnk As LinkButton = DirectCast(repNavBar.FindControl("lnkNav"), LinkButton)
        '    Dim dt As New DataTable
        '    Dim ds As New DataSet
        '    dt.Columns.Add("PageNumber")
        '    dt.Columns.Add("ViewNumber")
        '    'For Each vw As View In mltappform.Views
        '    '    dt.Rows.Add(vw.
        '    'Next
        '    For i = 0 To ViewCount - 1
        '        dt.Rows.Add(i + 1, i)
        '        'dt.Rows.Add(mltappform.Views(i).ID, i)
        '    Next
        '    repNavBar.DataSource = dt
        '    repNavBar.DataBind()
        '    loadClasses()
        'Catch ex As Exception

        'End Try
    End Sub

    Protected Sub loadOtherLoans(custNo As String)
        Try
            cmd = New SqlCommand("select id,[OTHER_DESC],[OTHER_ACCNO],CONVERT(DECIMAL(30,2),[OTHER_AMT]) as [OTHER_AMT] from QUEST_OTHER_LOANS where CUSTOMER_NUMBER='" & custNo & "'", con)
            Dim ds As New DataSet
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "Other")
            If ds.Tables(0).Rows.Count > 0 Then
                grdOtherLoan.DataSource = ds.Tables(0)
            Else
                grdOtherLoan.DataSource = Nothing
            End If
            grdOtherLoan.DataBind()
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- loadOtherLoans()", ex.ToString)
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

    'Protected Sub btnSearchCustNo_Click(sender As Object, e As EventArgs) Handles btnSearchCustNo.Click
    Protected Sub loadUserType()
        If chkBranch.Checked Then
            loadUsersByRole(cmbSearchLoanOfficer, "4041", cmbSearchBranch.SelectedValue)
        Else
            loadUsersByRole(cmbSearchLoanOfficer, "4041")
        End If
    End Sub

    Public Sub fillType()
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("Select * from Quest_Assets", con)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "Assets")
            ddlAssets.Items.Add("")
            ddlAssets.DataSource = ds.Tables(0)
            ddlAssets.DataValueField = "Selling_Price"
            ddlAssets.DataTextField = "Name"
            ddlAssets.DataBind()
            ddlAssets.Items.Insert(0, "--SELECT--")
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

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            isValidSession()
            Page.MaintainScrollPositionOnPostBack = True
            con = New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
            If Not IsPostBack Then
                loadBranches(cmbSearchBranch)
                fillType()
                loadProductType(cmbProductType)
                loadClientTypes()
                loadSectors(cmbSector)

                loadBanks(cmbFinReqBank)
                loadBanks(cmbBankAppType)
                loadBanks(cmbBank)
                'writeBranch()
                loadPurpose(cmbFinReqPurpose)
                getPDACompanies()
                loadProductType(cmbProductType)
                loadSectors(cmbSector)
                'lnkAppRating.NavigateUrl = "ApplicationRating.aspx?loanID=" & Request.QueryString("id")
                If Session("ROLE") <> "1024" Then
                    btnGenAgrmt.Visible = False
                ElseIf Session("ROLE") = "4042" Then
                    btnGenAgrmt.Visible = True
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Function queryBuilder() As String
        Dim myQuery As String = ""
        If chkBranch.Checked Then
            myQuery = String.Format("{0} AND BRANCH_CODE='{1}'", myQuery, cmbSearchBranch.SelectedValue)
        End If
        If chkClientType.Checked Then
            myQuery = String.Format("{0} AND CUSTOMER_TYPE='{1}'", myQuery, cmbSearchClientType.SelectedValue)
        End If
        If chkLoanOfficer.Checked Then
            myQuery = String.Format("{0} AND CREATED_BY='{1}'", myQuery, cmbSearchLoanOfficer.SelectedValue)
        End If
        If chkLoanStatus.Checked Then
            myQuery = String.Format("{0} AND STATUS='{1}'", myQuery, cmbSearchLoanStatus.SelectedValue)
        End If
        If chkSearchName.Checked Then
            myQuery = String.Format("{0} AND SURNAME + ' ' + FORENAMES like '%{1}%'", myQuery, txtSearchCustName.Text)
        End If
        If chkDateRange.Checked Then
            myQuery = String.Format("{0} AND CREATED_DATE between '{1}' and '{2}'", myQuery, txtSearchFromDate.Text, txtSearchToDate.Text)
        End If
        If chkDisbDateRange.Checked Then
            myQuery = String.Format("{0} AND DISBURSED_DATE between '{1}' and '{2}'", myQuery, txtSearchDisbFromDate.Text, txtSearchDisbToDate.Text)
        End If
        Return myQuery
    End Function

    Protected Sub getRepaymentHistory(lID As String)
        Try
            grdRepaymentHistory.DataSource = Nothing
            grdRepaymentHistory.DataBind()

            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd = New SqlCommand("SELECT *,SUM(isnull(case WHEN [Desc]='Repayment' then payment*-1 when [Desc]='Expected Instalment' then r.PAYMENT END,0)) OVER (PARTITION by r.LOANID order by r.LOANID,convert(date,r.PAYMENT_DATE) rows unbounded preceding) as Balance FROM (SELECT 'Expected Instalment' as [Desc],am.PAYMENT_NO as [Num], am.LOANID,convert(varchar,am.PAYMENT_DATE,106) as PAYMENT_DATE,payment,am.CUMULATIVE_PRINCIPAL+am.CUMULATIVE_INTEREST as Total FROM AMORTIZATION_SCHEDULE am WHERE am.LOANID=@loanID UNION SELECT 'Repayment' as [Desc],ROW_NUMBER() OVER (PARTITION by acct.Refrence order by acct.Refrence,convert(date,acct.TrxnDate)) as [Num],acct.Refrence, convert(varchar,acct.TrxnDate,106) as [TrDate],SUM(acct.Credit-acct.Debit) as PaidToDate,SUM(isnull(sum(acct.Credit)-sum(acct.Debit),0)) OVER (PARTITION by acct.Refrence order by acct.Refrence,convert(date,acct.TrxnDate) rows unbounded preceding) as RunningTotal FROM Accounts_Transactions acct where acct.Category='Loan Repayment' AND Account in (SELECT customer_number from customer_details) and acct.Refrence=@loanID GROUP BY acct.Refrence,trxndate)r ORDER by loanid,convert(date,payment_date)", con)
                    cmd.Parameters.AddWithValue("@loanID", lID)
                    Dim dt As New DataTable
                    Using adp As New SqlDataAdapter(cmd)
                        adp.Fill(dt)
                    End Using
                    CreditManager.bindGrid(dt, grdRepaymentHistory)
                End Using
            End Using
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- getRepaymentHistory()", ex.ToString)
        End Try
    End Sub

    Protected Sub calculateOnTime()
        Try
            Dim tenure As Int64 = 0
            Dim onTime As Int64 = 0
            For Each row As GridViewRow In grdRepaymentHistory.Rows
                If row.Cells(0).Text = "Expected Instalment" Then
                    tenure = tenure + 1
                    If CDate(row.Cells(1).Text) >= Today Then
                        onTime = onTime + 1
                    Else
                        If row.Cells(3).Text <= 0 Then
                            onTime = onTime + 1
                        Else

                        End If
                    End If
                End If
            Next
            lblOnTimeRate.Text = Math.Round(CDbl(onTime) / CDbl(tenure) * 100, 2).ToString & "%"
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- calculateOnTime()", ex.ToString)
        End Try
    End Sub

    Private Sub grdRepaymentHistory_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles grdRepaymentHistory.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow And e.Row.Cells(0).Text = "Expected Instalment" Then
            Dim bal As Double = Double.Parse(e.Row.Cells(3).Text)
            Dim dat As Date = CDate(e.Row.Cells(1).Text)

            If dat >= Today Then
            Else
                If bal <= 0 Then
                Else
                    e.Row.ForeColor = Color.Red
                End If
            End If
            'For Each cell As TableCell In e.Row.Cells
            '    If bal = 0 Then
            '        cell.BackColor = Color.Red
            '    End If
            '    If quantity > 0 AndAlso quantity <= 50 Then
            '        cell.BackColor = Color.Yellow
            '    End If
            '    If quantity > 50 AndAlso quantity <= 100 Then
            '        cell.BackColor = Color.Orange
            '    End If
            'Next
        End If
    End Sub

End Class