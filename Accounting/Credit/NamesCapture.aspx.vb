Imports System.Data
Imports System.Data.SqlClient
Imports System.Web
Imports System.Web.Services
Imports CreditManager
Imports ErrorLogging

Partial Class NamesCapture
    Inherits System.Web.UI.Page
    Public Shared grpMembersEditID As String
    Dim adp As SqlDataAdapter
    Dim cmd As SqlCommand
    Dim con As New SqlConnection
    Dim grpCount As Int16 = 0

    <WebMethod>
    Public Shared Sub Upload(ByVal base64 As String)
        Dim parts = base64.Split(New Char() {","c}, 2)
        Dim bytes = Convert.FromBase64String(parts(1))
        HttpContext.Current.Session("PhotoName") = DateTime.Now.Ticks
        'Dim path = HttpContext.Current.Server.MapPath(String.Format("~/{0}.jpg", DateTime.Now.Ticks))
        Dim path = HttpContext.Current.Server.MapPath(String.Format("~/ClientPhotos/{0}.jpg", HttpContext.Current.Session("PhotoName")))
        System.IO.File.WriteAllBytes(path, bytes)
        notify("Photo saved", "success")
    End Sub

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
        ElseIf appType = "PDAs" Then
            lblEmpCode.Visible = False
            txtECNo.Visible = False
            txtECNoCD.Visible = False
            divAppTypeBanker.Visible = False
            divAppTypeOther.Visible = False
            divAppTypePDA.Visible = True
        ElseIf appType = "Other" Then
            lblEmpCode.Visible = False
            txtECNo.Visible = False
            txtECNoCD.Visible = False
            divAppTypeBanker.Visible = False
            divAppTypeOther.Visible = True
            divAppTypePDA.Visible = False
        End If
    End Sub

    Protected Sub btnActivateGrp_Click(sender As Object, e As EventArgs) Handles btnActivateGrp.Click
        Try
            If Trim(txtCustNo.Text) = "" Then
                notify("Enter client customer number", "error")
                txtCustNo.Focus()
            Else
                Dim memCount = grdGrpDeclMembers.Rows.Count
                If ViewState("MinGrpMembers") > memCount Or ViewState("MaxGrpMembers") < memCount Then
                    notify("Number of group members out of the allowed range. Cannot activate group", "error")
                Else
                    Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                        Using cmd = New SqlCommand("update customer_details set ACTIVATED=1 where customer_number=@cust", con)
                            cmd.Parameters.AddWithValue("@cust", txtCustNo.Text)
                            con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()
                            ClientScript.RegisterStartupScript(Me.GetType(), "Dates", "<script type=""text/javascript"">alert('Goup activated');location:NamesCapture.aspx;</script>")
                        End Using
                    End Using
                End If
            End If
        Catch ex As Exception
            ErrorLogging.WriteLogFile(Session("UserId"), Request.Url.ToString & " -- btnActivateGrp_Click()", ex.ToString)
        End Try
    End Sub

    Protected Sub btnDeleteName_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDeleteName.Click
        Try
            'cmd = New SqlCommand("delete from CUSTOMER_DETAILS where CUSTOMER_NUMBER='" & txtCustNo.Text & "'", con)
            Using cmd = New SqlCommand("insert into CUSTOMER_DETAILS_AUDIT ([CUSTOMER_TYPE],[SUB_INDIVIDUAL],[CUSTOMER_NUMBER],[SURNAME],[FORENAMES],[DOB],[IDNO],[ISSUE_DATE],[ADDRESS],[CITY],[PHONE_NO],[NATIONALITY],[GENDER],[HOME_TYPE],[MONTHLY_RENT],[MARITAL_STATUS],[EDUCATION],[CURR_EMPLOYER],[CURR_EMP_ADD],[CURR_EMP_LENGTH],[CURR_EMP_PHONE],[CURR_EMP_EMAIL],[CURR_EMP_FAX],[CURR_EMP_CITY],[CURR_EMP_POSITION],[CURR_EMP_SALARY],[CURR_EMP_NET],[CURR_EMP_INCOME],[PREV_EMPLOYER],[PREV_EMP_ADD],[PREV_EMP_LENGTH],[PREV_EMP_PHONE],[PREV_EMP_EMAIL],[PREV_EMP_FAX],[PREV_EMP_CITY],[PREV_EMP_POSITION],[PREV_EMP_SALARY],[PREV_EMP_NET],[PREV_EMP_INCOME],[SPOUSE_NAME],[SPOUSE_OCCUPATION],[SPOUSE_EMPLOYER],[NO_CHILDREN],[NO_DEPENDANTS],[TRADE_REF1],[TRADE_REF2],[CREATED_BY],[CREATED_DATE],[MODIFIED_BY],[MODIFIED_DATE],[SPOUSE_PHONE],[BRANCH_CODE],[BRANCH_NAME],[AREA],[TRAN_TYPE],[AUTHORIZED]) values ('" & rdbClientType.SelectedValue & "','" & rdbSubIndividual.SelectedValue & "','" & txtCustNo.Text & "','" & BankString.removeSpecialCharacter(txtSurname.Text) & "','" & BankString.removeSpecialCharacter(txtForenames.Text) & "','" & bdpDOB.Text & "','" & txtIDNo.Text & "','" & bdpIssDate.Text & "','" & BankString.removeSpecialCharacter(txtAddress.Text) & "','" & BankString.removeSpecialCharacter(txtCity.Text) & "','" & txtPhoneNo.Text & "','" & BankString.removeSpecialCharacter(txtNationality.Text) & "','" & rdbGender.SelectedValue & "','" & rdbHouse.SelectedValue & "','" & txtRent.Text & "','" & cmbMaritalStatus.SelectedValue & "','" & getEducation() & "','" & BankString.removeSpecialCharacter(txtCurrEmployer.Text) & "','" & BankString.removeSpecialCharacter(txtEmpAddress.Text) & "',NULLIF('" & txtEmpHowLong.Text & "',''),'" & txtEmpPhone.Text & "','" & txtEmpEmail.Text & "','" & txtEmpFax.Text & "','" & BankString.removeSpecialCharacter(txtEmpCity.Text) & "','" & BankString.removeSpecialCharacter(txtEmpPosition.Text) & "',NULLIF('" & txtEmpSalary.Text & "',''),NULLIF('" & txtEmpSalaryNet.Text & "',''),NULLIF('" & txtEmpOtherIncome.Text & "',''),'" & BankString.removeSpecialCharacter(txtPrevEmployer.Text) & "','" & BankString.removeSpecialCharacter(txtPrevEmpAddress.Text) & "',NULLIF('" & txtPrevEmpHowLong.Text & "',''),'" & txtPrevEmpPhone.Text & "','" & txtPrevEmpEmail.Text & "','" & txtPrevEmpFax.Text & "','" & BankString.removeSpecialCharacter(txtPrevEmpCity.Text) & "','" & BankString.removeSpecialCharacter(txtPrevEmpPosition.Text) & "',NULLIF('" & txtPrevEmpSalary.Text & "',''),NULLIF('" & txtPrevEmpSalaryNet.Text & "',''),NULLIF('" & txtPrevEmpAnnualIncome.Text & "',''),'" & BankString.removeSpecialCharacter(txtSpouse.Text) & "','" & BankString.removeSpecialCharacter(txtSpouseOccupation.Text) & "','" & BankString.removeSpecialCharacter(txtSpouseEmployer.Text) & "',NULLIF('" & txtNoChildren.Text & "',''),NULLIF('" & txtNoDependant.Text & "',''),'" & txtTradeRef1.Text & "','" & txtTradeRef2.Text & "','" & Session("UserID") & "',getdate(),'','','" & txtSpousePhone.Text & "','" & lblBranchCode.Text & "','" & BankString.removeSpecialCharacter(lblBranchName.Text) & "','" & cmbArea.SelectedValue & "','DELETE',0)", con)
                If con.State = ConnectionState.Open Then
                    con.Close()
                End If
                con.Open()
                If cmd.ExecuteNonQuery Then
                    notify("Name successfully marked for deletion. Authorization pending.", "success")
                    getNames()
                    clearAll()
                    btnSaveName.Text = "Save Static Details"
                    btnDeleteName.Visible = False
                Else
                    notify("Error deleting name", "error")
                End If
            End Using
        Catch ex As Exception
            WriteLogFile(ex.ToString)
        End Try
    End Sub

    Protected Sub btnGrpAddGroup_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGrpAddGroup.Click
        Try
            If btnGrpAddGroup.Text = "Add Group" Then
                Dim custNo = generateCustNum()
                'Using cmd = New SqlCommand("insert into CUSTOMER_DETAILS ([CUSTOMER_TYPE],[CUSTOMER_NUMBER],[SURNAME],[BRANCH_CODE],[BRANCH_NAME],[CUSTOMER_TYPE_ID]) values ('" & rdbClientType.SelectedItem.Text & "','" & custNo & "','" & BankString.removeSpecialCharacter(txtGrpName.Text) & "','" & lblBranchCode.Text & "','" & BankString.removeSpecialCharacter(lblBranchName.Text) & "','" & rdbClientType.SelectedValue & "')", con)
                Using cmd = New SqlCommand("insert into CUSTOMER_DETAILS ([CUSTOMER_TYPE],[CUSTOMER_NUMBER],[SURNAME],[BRANCH_CODE],[BRANCH_NAME]) values ('" & rdbClientType.SelectedItem.Text & "','" & custNo & "','" & BankString.removeSpecialCharacter(txtGrpName.Text) & "','" & lblBranchCode.Text & "','" & BankString.removeSpecialCharacter(lblBranchName.Text) & "')", con)
                    If con.State = ConnectionState.Open Then
                        con.Close()
                    End If
                    con.Open()
                    If cmd.ExecuteNonQuery Then
                        txtCustNo.Text = custNo
                        notify("Group created successfully with customer number " & custNo & ". You can add the group members", "success")
                    Else
                        notify("Error saving group", "error")
                    End If
                End Using
            ElseIf btnGrpAddGroup.Text = "Update Group Name" Then
                If Trim(txtCustNo.Text) = "" Then
                    notify("Select the group to update.", "error")
                    txtCustNo.Focus()
                Else
                    If Not isUniqueCustNo(txtCustNo.Text) And getCustomerType(txtCustNo.Text) = "Group" Then
                        Using cmd = New SqlCommand("update CUSTOMER_DETAILS set [SURNAME]='" & BankString.removeSpecialCharacter(txtGrpName.Text) & "' where CUSTOMER_NUMBER='" & txtCustNo.Text & "'", con)
                            If con.State = ConnectionState.Open Then
                                con.Close()
                            End If
                            con.Open()
                            If cmd.ExecuteNonQuery Then
                                notify("Group name successfully updated", "success")
                            Else
                                notify("Error updating group name", "error")
                            End If
                        End Using
                    Else
                        notify("Customer number does not exist or not a group", "error")
                    End If
                End If
            End If
        Catch ex As Exception
            WriteLogFile(ex.ToString)
        End Try
    End Sub

    Protected Sub btnGrpDeclAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGrpDeclAdd.Click
        Try
            Dim cmd1 = New SqlCommand("insert into QUEST_GROUP_MEMBERS (CUSTOMER_NUMBER,POSITION,NAME,IDNO,ISSUE_DATE,DOB,ADDRESS,CITY,PHONE,NATIONALITY,GENDER) values ('" & txtCustNo.Text & "','" & cmbGrpDeclPosition.SelectedValue & "','" & BankString.removeSpecialCharacter(txtGrpDeclName.Text) & "','" & txtGrpDeclIDNo.Text & "','" & bdpGrpIssDate.Text & "','" & bdpGrpDOB.Text & "','" & txtGrpDeclAddress.Text & "','" & txtGrpDeclCity.Text & "','" & txtGrpDeclPhoneNo.Text & "','" & txtGrpDeclNationality.Text & "','" & rdbGrpGender.SelectedValue & "')", con)
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            'msgbox(cmd.CommandText)
            con.Open()
            If isUniqueCustNo(txtCustNo.Text) Then
                notify("Entered customer number does not exist", "error")
                txtCustNo.Focus()
            ElseIf Not isUniqueGrpMemberIDNo(txtCustNo.Text, txtGrpDeclIDNo.Text) Then
                notify("ID Number already entered for another member of this group", "error")
                txtGrpDeclIDNo.Focus()
            ElseIf ViewState("ClientMoreThanOneGroup") = "0" And Not isUniqueGrpIDNo(txtGrpDeclIDNo.Text) Then
                notify("A member of another group has an identical ID Number. An individual cannot belong to more than one group", "error")
                txtGrpDeclIDNo.Focus()
            Else
                If cmd1.ExecuteNonQuery Then
                    'lblGrpDeclMemberAdded.Text = "Group member added"
                    getGrpMembers(txtCustNo.Text)
                    loadGrpMembers(txtCustNo.Text)
                    clearGrpMemberInfo()
                    notify("Group member successfully added", "success")
                Else
                    notify("Error saving member", "error")
                End If
            End If
            con.Close()
        Catch ex As Exception
            WriteLogFile(ex.ToString)
        End Try
    End Sub

    Protected Sub btnGrpDeclAddExpense_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGrpDeclAddExpense.Click
        Try
            If cmbGrpDeclMember.SelectedValue = "" Then
                notify("Select the group member to update", "error")
                cmbGrpDeclMember.Focus()
            Else
                Using cmd = New SqlCommand("update QUEST_GROUP_MEMBERS set RENT=NULLIF(@RENT,''),FOOD=NULLIF(@FOOD,''),FEES=NULLIF(@FEES,''),AIRTIME=NULLIF(@AIRTIME,''),MEDICAL=NULLIF(@MEDICAL,''),ELECTRICITY=NULLIF(@ELECTRICITY,''),WATER=NULLIF(@WATER,''),RATES=NULLIF(@RATES,''),CITY_OF_HRE=NULLIF(@COH,'') where ID='" & cmbGrpDeclMember.SelectedValue & "'", con)
                    cmd.Parameters.AddWithValue("@RENT", txtGrpDeclRent.Text.Replace("$", "").Replace("US", ""))
                    cmd.Parameters.AddWithValue("@FOOD", txtGrpDeclFood.Text.Replace("$", "").Replace("US", ""))
                    cmd.Parameters.AddWithValue("@FEES", txtGrpDeclFees.Text.Replace("$", "").Replace("US", ""))
                    cmd.Parameters.AddWithValue("@AIRTIME", txtGrpDeclAirtime.Text.Replace("$", "").Replace("US", ""))
                    cmd.Parameters.AddWithValue("@MEDICAL", txtGrpDeclMedical.Text.Replace("$", "").Replace("US", ""))
                    cmd.Parameters.AddWithValue("@ELECTRICITY", txtGrpDeclElectricity.Text.Replace("$", "").Replace("US", ""))
                    cmd.Parameters.AddWithValue("@WATER", txtGrpDeclWater.Text.Replace("$", "").Replace("US", ""))
                    cmd.Parameters.AddWithValue("@RATES", txtGrpDeclRates.Text.Replace("$", "").Replace("US", ""))
                    cmd.Parameters.AddWithValue("@COH", txtGrpDeclCityOfHre.Text.Replace("$", "").Replace("US", ""))
                    If con.State = ConnectionState.Open Then
                        con.Close()
                    End If
                    con.Open()
                    If cmd.ExecuteNonQuery Then
                        notify("Member expenses added successfully", "success")
                        getGrpMemberExpenses(txtCustNo.Text)
                        clearGrpExpense()
                    Else
                        notify("Expenses could not be saved", "error")
                    End If
                End Using
            End If
        Catch ex As Exception
            WriteLogFile(ex.ToString)
        End Try
    End Sub

    Protected Sub btnSaveFarmer_Click(sender As Object, e As EventArgs) Handles btnSaveFarmer.Click
        Try
            Dim outNewCustNo = 0
            If btnSaveFarmer.Text = "Save" Then
                ''''''remove customer number generation here, to be done on authorizing'''''''''''''''''
                Dim newCustNo = generateCustNum() ' + 1
                outNewCustNo = newCustNo

                cmd = New SqlCommand("insert into CUSTOMER_DETAILS ([CUSTOMER_TYPE],[CUSTOMER_NUMBER],[SURNAME],[FORENAMES],[DOB],[IDNO],[ISSUE_DATE],[ADDRESS],[PHONE_NO],[GENDER],[SPOUSE_NAME],[CREATED_BY],[CREATED_DATE],[MODIFIED_BY],[MODIFIED_DATE],[SPOUSE_PHONE],[BRANCH_CODE],[BRANCH_NAME],[MONTH_EXPENSE], [MONTH_INCOME], [PREV_SALES], [CURR_ESTIMATE], [CROPS], [FARM_PERIOD],[SPOUSE_ADDRESS],[SPOUSE_IDNO],[CUSTOMER_TYPE_ID]) values ('" & rdbClientType.SelectedItem.Text & "','" & newCustNo & "','" & BankString.removeSpecialCharacter(txtFarmNameOfGroup.Text) & "','" & BankString.removeSpecialCharacter(txtFarmNameOfApplicant.Text) & "','" & txtFarmDOB.Text & "','" & txtFarmIDNo.Text & "','" & txtFarmIssDate.Text & "','" & BankString.removeSpecialCharacter(txtFarmCurrentAddress.Text) & "',NULLIF('" & txtFarmPhoneNo.Text & "',''),'" & rdbFarmGender.SelectedValue & "','" & BankString.removeSpecialCharacter(txtFarmNameOfSpouse.Text) & "','" & Session("UserID") & "',getdate(),'','','" & txtFarmSpousePhoneNo.Text & "','" & lblBranchCode.Text & "','" & BankString.removeSpecialCharacter(lblBranchName.Text) & "',NULLIF('" & txtFarmMonthlyExpense.Text & "',''),NULLIF('" & txtFarmMonthlyIncome.Text & "',''),NULLIF('" & txtFarmPreviousSales.Text & "',''),NULLIF('" & txtFarmCurrentEstimate.Text & "',''),'" & txtFarmCropsGrown.Text & "',NULLIF('" & txtFarmPeriodFarming.Text & "',''),'" & txtFarmCurrAddressOfSpouse.Text & "','" & txtFarmSpouseIDNo.Text & "','" & rdbClientType.SelectedValue & "')", con)

            ElseIf btnSaveFarmer.Text = "Update" Then

                cmd = New SqlCommand("insert into CUSTOMER_DETAILS_AUDIT ([CUSTOMER_TYPE],[CUSTOMER_NUMBER],[SURNAME],[FORENAMES],[DOB],[IDNO],[ISSUE_DATE],[ADDRESS],[PHONE_NO],[GENDER],[SPOUSE_NAME],[CREATED_BY],[CREATED_DATE],[MODIFIED_BY],[MODIFIED_DATE],[SPOUSE_PHONE],[BRANCH_CODE],[BRANCH_NAME],[TRAN_TYPE],[AUTHORIZED],[MONTH_EXPENSE], [MONTH_INCOME], [PREV_SALES], [CURR_ESTIMATE], [CROPS], [FARM_PERIOD],[SPOUSE_ADDRESS],[SPOUSE_IDNO],[CUSTOMER_TYPE_ID]) values ('" & rdbClientType.SelectedItem.Text & "','" & txtCustNo.Text & "','" & BankString.removeSpecialCharacter(txtFarmNameOfGroup.Text) & "','" & BankString.removeSpecialCharacter(txtFarmNameOfApplicant.Text) & "','" & txtFarmDOB.Text & "','" & txtFarmIDNo.Text & "','" & txtFarmIssDate.Text & "','" & BankString.removeSpecialCharacter(txtFarmCurrentAddress.Text) & "','" & txtFarmPhoneNo.Text & "','" & rdbFarmGender.SelectedValue & "','" & BankString.removeSpecialCharacter(txtFarmNameOfSpouse.Text) & "','" & Session("UserID") & "',getdate(),'','','" & txtFarmSpousePhoneNo.Text & "','" & lblBranchCode.Text & "','" & BankString.removeSpecialCharacter(lblBranchName.Text) & "','UPDATE',0,NULLIF('" & txtFarmMonthlyExpense.Text & "',''),NULLIF('" & txtFarmMonthlyIncome.Text & "',''),NULLIF('" & txtFarmPreviousSales.Text & "',''),NULLIF('" & txtFarmCurrentEstimate.Text & "',''),'" & txtFarmCropsGrown.Text & "',NULLIF('" & txtFarmPeriodFarming.Text & "',''),'" & txtFarmCurrAddressOfSpouse.Text & "','" & txtFarmSpouseIDNo.Text & "','" & rdbClientType.SelectedValue & "')", con)
            End If
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            con.Open()
            If cmd.ExecuteNonQuery() Then
                If btnSaveName.Text = "Save Static Details" Then
                    notify("Customer saved successfully. Customer number is " & outNewCustNo & "", "success")
                Else
                    notify("Updated successfully. Authorization Pending", "success")
                End If
                clearAll()
                getFarmers()
                btnSaveFarmer.Text = "Save"
                btnDeleteFarmer.Visible = False
                grdFarmers.SelectedIndex = -1
                rdbClientType_SelectedIndexChanged(sender, New EventArgs)
            Else
                notify("Error saving name", "error")
            End If
            con.Close()
        Catch ex As Exception
            WriteLogFile(ex.ToString)
        End Try
    End Sub

    Protected Sub btnSaveName_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSaveName.Click
        Try
            Dim outNewCustNo As String = "0"
            If rdbSubIndividual.SelectedIndex = -1 Then
                notify("Select applicant type", "error")
                rdbSubIndividual.Focus()
            ElseIf rdbSubIndividual.SelectedValue = "SSB" Then
                If Trim(txtECNo.Text) = "" Or Trim(txtECNoCD.Text) = "" Then
                    notify("Enter EC Number for SSB client", "error")
                    txtECNo.Focus()
                    Exit Sub
                End If
            ElseIf rdbSubIndividual.SelectedValue = "Bankers" Then
                If cmbBankAppType.SelectedValue = "" Or cmbBranchAppType.SelectedValue = "" Then
                    notify("Select bank and branch for Bankers client", "error")
                    cmbBankAppType.Focus()
                    Exit Sub
                End If
            ElseIf rdbSubIndividual.SelectedValue = "PDAs" Then
                If cmbPDAAppType.SelectedValue = "" Then
                    notify("Select company for PDA client", "error")
                    cmbPDAAppType.Focus()
                    Exit Sub
                End If
            ElseIf rdbSubIndividual.SelectedValue = "Other" Then
                If Trim(txtOtherAppType.Text) = "" Then
                    notify("Enter description for other client type", "error")
                    txtOtherAppType.Focus()
                    Exit Sub
                End If
            End If
            If cmbMaritalStatus.SelectedValue = "Married" Then
                If Trim(txtSpouse.Text) = "" Then
                    notify("Name of spouse is required", "error")
                    txtSpouse.Focus()
                    Exit Sub
                ElseIf Trim(txtSpousePhone.Text) = "" Then
                    notify("Spouse phone number is required", "error")
                    txtSpousePhone.Focus()
                    Exit Sub
                End If
            End If
            If btnSaveName.Text = "Save Static Details" Then
                ''''''remove customer number generation here, to be done on authorizing'''''''''''''''''
                Dim newCustNo = generateCustNum() ' + 1
                outNewCustNo = newCustNo
                cmd = New SqlCommand("insert into CUSTOMER_DETAILS ([Sector],[CUSTOMER_TYPE],[SUB_INDIVIDUAL],[CUSTOMER_NUMBER],[SURNAME],[FORENAMES],[DOB],[IDNO],[ISSUE_DATE],[ADDRESS],[CITY],[PHONE_NO],[NATIONALITY],[GENDER],[HOME_TYPE],[MONTHLY_RENT],[MARITAL_STATUS],[EDUCATION],[CURR_EMPLOYER],[CURR_EMP_ADD],[CURR_EMP_LENGTH],[CURR_EMP_PHONE],[CURR_EMP_EMAIL],[CURR_EMP_FAX],[CURR_EMP_CITY],[CURR_EMP_POSITION],[CURR_EMP_SALARY],[CURR_EMP_NET],[CURR_EMP_INCOME],[PREV_EMPLOYER],[PREV_EMP_ADD],[PREV_EMP_LENGTH],[PREV_EMP_PHONE],[PREV_EMP_EMAIL],[PREV_EMP_FAX],[PREV_EMP_CITY],[PREV_EMP_POSITION],[PREV_EMP_SALARY],[PREV_EMP_NET],[PREV_EMP_INCOME],[SPOUSE_NAME],[SPOUSE_OCCUPATION],[SPOUSE_EMPLOYER],[NO_CHILDREN],[NO_DEPENDANTS],[TRADE_REF1],[TRADE_REF2],[CREATED_BY],[CREATED_DATE],[MODIFIED_BY],[MODIFIED_DATE],[SPOUSE_PHONE],[BRANCH_CODE],[BRANCH_NAME],[AREA],[ECNO],[CD],PDACode,AppTypeBank,AppTypeBranch,AppTypeOtherDesc,PhotoName,AccountSuffix,[CUSTOMER_TYPE_ID],[GUARANTOR_REL_NAME],[GUARANTOR_REL_ADD],[GUARANTOR_REL_CITY],[GUARANTOR_REL_PHONE],[GUARANTOR_REL_RELTNSHP],Bank, BankBranch, BankAccountNo) values ('" & cmbSector.SelectedValue & "','" & rdbClientType.SelectedItem.Text & "','" & rdbSubIndividual.SelectedValue & "','" & newCustNo & "','" & BankString.removeSpecialCharacter(txtSurname.Text) & "','" & BankString.removeSpecialCharacter(txtForenames.Text) & "',NULLIF('" & bdpDOB.Text & "',''),'" & txtIDNo.Text & "',NULLIF('" & bdpIssDate.Text & "',''),'" & BankString.removeSpecialCharacter(txtAddress.Text) & "','" & BankString.removeSpecialCharacter(txtCity.Text) & "','" & txtPhoneNo.Text & "','" & BankString.removeSpecialCharacter(txtNationality.Text) & "','" & rdbGender.SelectedValue & "','" & rdbHouse.SelectedValue & "',NULLIF('" & txtRent.Text & "',''),'" & cmbMaritalStatus.SelectedValue & "','" & getEducation() & "','" & BankString.removeSpecialCharacter(txtCurrEmployer.Text) & "','" & BankString.removeSpecialCharacter(txtEmpAddress.Text) & "',NULLIF('" & txtEmpHowLong.Text & "',''),'" & txtEmpPhone.Text & "','" & txtEmpEmail.Text & "','" & txtEmpFax.Text & "','" & BankString.removeSpecialCharacter(txtEmpCity.Text) & "','" & BankString.removeSpecialCharacter(txtEmpPosition.Text) & "',NULLIF('" & txtEmpSalary.Text & "',''),NULLIF('" & txtEmpSalaryNet.Text & "',''),NULLIF('" & txtEmpOtherIncome.Text & "',''),'" & BankString.removeSpecialCharacter(txtPrevEmployer.Text) & "','" & BankString.removeSpecialCharacter(txtPrevEmpAddress.Text) & "',NULLIF('" & txtPrevEmpHowLong.Text & "',''),'" & txtPrevEmpPhone.Text & "','" & txtPrevEmpEmail.Text & "','" & txtPrevEmpFax.Text & "','" & BankString.removeSpecialCharacter(txtPrevEmpCity.Text) & "','" & BankString.removeSpecialCharacter(txtPrevEmpPosition.Text) & "',NULLIF('" & txtPrevEmpSalary.Text & "',''),NULLIF('" & txtPrevEmpSalaryNet.Text & "',''),NULLIF('" & txtPrevEmpAnnualIncome.Text & "',''),'" & BankString.removeSpecialCharacter(txtSpouse.Text) & "','" & BankString.removeSpecialCharacter(txtSpouseOccupation.Text) & "','" & BankString.removeSpecialCharacter(txtSpouseEmployer.Text) & "',NULLIF('" & txtNoChildren.Text & "',''),NULLIF('" & txtNoDependant.Text & "',''),'" & txtTradeRef1.Text & "','" & txtTradeRef2.Text & "','" & Session("UserID") & "',getdate(),'','','" & txtSpousePhone.Text & "','" & lblBranchCode.Text & "','" & BankString.removeSpecialCharacter(lblBranchName.Text) & "','" & cmbArea.SelectedValue & "','" & txtECNo.Text & "','" & txtECNoCD.Text & "','" & cmbPDAAppType.SelectedValue & "','" & cmbBankAppType.SelectedValue & "','" & cmbBranchAppType.SelectedValue & "','" & txtOtherAppType.Text & "','" & Session("PhotoName") & "',NULLIF('" & ViewState("AccSuffix") & "',''),nullif('" & rdbClientType.SelectedValue & "',''),'" & BankString.removeSpecialCharacter(txtGuarNameRelative.Text) & "','" & BankString.removeSpecialCharacter(txtGuarRelAddress.Text) & "','" & BankString.removeSpecialCharacter(txtGuarRelCity.Text) & "','" & txtGuarRelPhone.Text & "','" & BankString.removeSpecialCharacter(txtGuarRelReltnship.Text) & "','" & cmbBank.SelectedValue & "','" & cmbBankBranch.SelectedValue & "','" & txtBankAccountNo.Text & "')", con)
                'msgbox(cmd.CommandText)
            ElseIf btnSaveName.Text = "Update" Then
                cmd = New SqlCommand("insert into CUSTOMER_DETAILS_AUDIT ([Sector],[CUSTOMER_TYPE],[SUB_INDIVIDUAL],[CUSTOMER_NUMBER],[SURNAME],[FORENAMES],[DOB],[IDNO],[ISSUE_DATE],[ADDRESS],[CITY],[PHONE_NO],[NATIONALITY],[GENDER],[HOME_TYPE],[MONTHLY_RENT],[MARITAL_STATUS],[EDUCATION],[CURR_EMPLOYER],[CURR_EMP_ADD],[CURR_EMP_LENGTH],[CURR_EMP_PHONE],[CURR_EMP_EMAIL],[CURR_EMP_FAX],[CURR_EMP_CITY],[CURR_EMP_POSITION],[CURR_EMP_SALARY],[CURR_EMP_NET],[CURR_EMP_INCOME],[PREV_EMPLOYER],[PREV_EMP_ADD],[PREV_EMP_LENGTH],[PREV_EMP_PHONE],[PREV_EMP_EMAIL],[PREV_EMP_FAX],[PREV_EMP_CITY],[PREV_EMP_POSITION],[PREV_EMP_SALARY],[PREV_EMP_NET],[PREV_EMP_INCOME],[SPOUSE_NAME],[SPOUSE_OCCUPATION],[SPOUSE_EMPLOYER],[NO_CHILDREN],[NO_DEPENDANTS],[TRADE_REF1],[TRADE_REF2],[CREATED_BY],[CREATED_DATE],[MODIFIED_BY],[MODIFIED_DATE],[SPOUSE_PHONE],[BRANCH_CODE],[BRANCH_NAME],[AREA],[ECNO],[CD],[TRAN_TYPE],[AUTHORIZED],PDACode,AppTypeBank,AppTypeBranch,AppTypeOtherDesc,PhotoName,[CUSTOMER_TYPE_ID],[GUARANTOR_REL_NAME],[GUARANTOR_REL_ADD],[GUARANTOR_REL_CITY],[GUARANTOR_REL_PHONE],[GUARANTOR_REL_RELTNSHP],Bank, BankBranch, BankAccountNo) values ('" & cmbSector.SelectedValue & "','" & rdbClientType.SelectedItem.Text & "','" & rdbSubIndividual.SelectedValue & "','" & txtCustNo.Text & "','" & BankString.removeSpecialCharacter(txtSurname.Text) & "','" & BankString.removeSpecialCharacter(txtForenames.Text) & "','" & bdpDOB.Text & "','" & txtIDNo.Text & "','" & bdpIssDate.Text & "','" & BankString.removeSpecialCharacter(txtAddress.Text) & "','" & BankString.removeSpecialCharacter(txtCity.Text) & "','" & txtPhoneNo.Text & "','" & BankString.removeSpecialCharacter(txtNationality.Text) & "','" & rdbGender.SelectedValue & "','" & rdbHouse.SelectedValue & "',NULLIF('" & txtRent.Text & "',''),'" & cmbMaritalStatus.SelectedValue & "','" & getEducation() & "','" & BankString.removeSpecialCharacter(txtCurrEmployer.Text) & "','" & BankString.removeSpecialCharacter(txtEmpAddress.Text) & "',NULLIF('" & txtEmpHowLong.Text & "',''),'" & txtEmpPhone.Text & "','" & txtEmpEmail.Text & "','" & txtEmpFax.Text & "','" & BankString.removeSpecialCharacter(txtEmpCity.Text) & "','" & BankString.removeSpecialCharacter(txtEmpPosition.Text) & "',NULLIF('" & txtEmpSalary.Text & "',''),NULLIF('" & txtEmpSalaryNet.Text & "',''),NULLIF('" & txtEmpOtherIncome.Text & "',''),'" & BankString.removeSpecialCharacter(txtPrevEmployer.Text) & "','" & BankString.removeSpecialCharacter(txtPrevEmpAddress.Text) & "',NULLIF('" & txtPrevEmpHowLong.Text & "',''),'" & txtPrevEmpPhone.Text & "','" & txtPrevEmpEmail.Text & "','" & txtPrevEmpFax.Text & "','" & BankString.removeSpecialCharacter(txtPrevEmpCity.Text) & "','" & BankString.removeSpecialCharacter(txtPrevEmpPosition.Text) & "',NULLIF('" & txtPrevEmpSalary.Text & "',''),NULLIF('" & txtPrevEmpSalaryNet.Text & "',''),NULLIF('" & txtPrevEmpAnnualIncome.Text & "',''),'" & BankString.removeSpecialCharacter(txtSpouse.Text) & "','" & BankString.removeSpecialCharacter(txtSpouseOccupation.Text) & "','" & BankString.removeSpecialCharacter(txtSpouseEmployer.Text) & "',NULLIF('" & txtNoChildren.Text & "',''),NULLIF('" & txtNoDependant.Text & "',''),'" & txtTradeRef1.Text & "','" & txtTradeRef2.Text & "','" & Session("UserID") & "',getdate(),'','','" & txtSpousePhone.Text & "','" & lblBranchCode.Text & "','" & BankString.removeSpecialCharacter(lblBranchName.Text) & "','" & cmbArea.SelectedValue & "','" & txtECNo.Text & "','" & txtECNoCD.Text & "','UPDATE',0,'" & cmbPDAAppType.SelectedValue & "','" & cmbBankAppType.SelectedValue & "','" & cmbBranchAppType.SelectedValue & "','" & txtOtherAppType.Text & "','" & Session("PhotoName") & "',nullif('" & rdbClientType.SelectedValue & "',''),'" & BankString.removeSpecialCharacter(txtGuarNameRelative.Text) & "','" & BankString.removeSpecialCharacter(txtGuarRelAddress.Text) & "','" & BankString.removeSpecialCharacter(txtGuarRelCity.Text) & "','" & txtGuarRelPhone.Text & "','" & BankString.removeSpecialCharacter(txtGuarRelReltnship.Text) & "','" & cmbBank.SelectedValue & "','" & cmbBankBranch.SelectedValue & "','" & txtBankAccountNo.Text & "')", con)
            End If
            Session("PhotoName") = ""
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            con.Open()
            If cmd.ExecuteNonQuery() Then
                'Dim drSMS = CreditManager.getInternalControls
                If btnSaveName.Text = "Save Static Details" Then
                    notify("Customer saved successfully. Customer number is " & outNewCustNo & "", "success")
                    'If drSMS("SMSClientDisbursement") Then
                    '    ViaNettSMS.sendTXT(txtPhoneNo.Text, CreditManager.writeTXTMessage(drSMS("SMSClientDisbursementText").ToString, txtSurname.Text & " " & txtForenames.Text, drSMS("MFICompanyName").ToString))
                    'End If
                Else
                    notify("Updated successfully. Authorization Pending", "success")
                End If
                clearAll()
                getNames()
                btnSaveName.Text = "Save Static Details"
                btnDeleteName.Visible = False
                grdNames.SelectedIndex = -1
            Else
                notify("Error saving name", "error")
            End If
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- btnSaveName_Click()", ex.ToString)
        End Try
    End Sub

    Protected Sub btnSearchSurname_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearchSurname.Click
        getNamesBySurname(txtSearchSurname.Text)
    End Sub

    Protected Sub btnUploadPassport_Click(sender As Object, e As EventArgs) Handles btnUploadPassport.Click
        Try
            If filPassportPhoto.HasFile Then
                HttpContext.Current.Session("PhotoName") = DateTime.Now.Ticks
                Dim path = HttpContext.Current.Server.MapPath(String.Format("~/ClientPhotos/{0}.jpg", HttpContext.Current.Session("PhotoName")))
                filPassportPhoto.SaveAs(path)
                notify("Photo saved", "success")
            Else
                notify("Error saving photo", "error")
            End If
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- btnUploadPassport_Click()", ex.ToString)
        End Try
    End Sub

    Protected Sub chkAutoGenCustNo_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkAutoGenCustNo.CheckedChanged
        Try
            If chkAutoGenCustNo.Checked = True Then
                txtCustNo.Text = generateCustNum() ' + 1
            ElseIf chkAutoGenCustNo.Checked = False Then
                txtCustNo.Text = ""
            End If
        Catch ex As Exception
            WriteLogFile(ex.ToString)
        End Try
    End Sub

    Protected Sub clearAll()
        Try
            txtAddress.Text = ""
            txtCustNo.Text = ""
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
            'txtHouseHowLong.Text = ""
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
            lblSurname.Text = "Surname"
            lblForenames.Text = "Forenames"
            chkAutoGenCustNo.Checked = False
            lblForenames.Visible = True
            txtForenames.Visible = True
            rdbClientType.ClearSelection()
            rdbGender.ClearSelection()
            rdbHouse.ClearSelection()
            rdbSubIndividual.ClearSelection()
            cmbEducation.ClearSelection()
            cmbMaritalStatus.ClearSelection()
            cmbArea.ClearSelection()
            bdpDOB.Text = ""
            bdpIssDate.Text = ""
            txtECNo.Text = ""
            txtECNoCD.Text = ""
            txtGuarNameRelative.Text = ""
            txtGuarRelAddress.Text = ""
            txtGuarRelPhone.Text = ""
            txtGuarRelCity.Text = ""
            txtGuarRelReltnship.Text = ""

            cmbBankAppType.ClearSelection()
            cmbBranchAppType.ClearSelection()
            cmbBank.ClearSelection()
            cmbBankBranch.ClearSelection()
            cmbPDAAppType.ClearSelection()
            cmbSector.ClearSelection()
            txtOtherAppType.Text = ""
            txtBankAccountNo.Text = ""

            txtFarmCropsGrown.Text = ""
            txtFarmCurrAddressOfSpouse.Text = ""
            txtFarmCurrentAddress.Text = ""
            txtFarmCurrentEstimate.Text = ""
            txtFarmDOB.Text = ""
            txtFarmIDNo.Text = ""
            txtFarmIssDate.Text = ""
            txtFarmMonthlyExpense.Text = ""
            txtFarmMonthlyIncome.Text = ""
            txtFarmNameOfApplicant.Text = ""
            txtFarmNameOfGroup.Text = ""
            txtFarmNameOfSpouse.Text = ""
            txtFarmPeriodFarming.Text = ""
            txtFarmPhoneNo.Text = ""
            txtFarmPreviousSales.Text = ""
            txtFarmSpouseIDNo.Text = ""
            txtFarmSpousePhoneNo.Text = ""
            rdbFarmGender.ClearSelection()
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub clearGrpExpense()
        cmbGrpDeclMember.ClearSelection()
        txtGrpDeclAirtime.Text = ""
        txtGrpDeclCityOfHre.Text = ""
        txtGrpDeclElectricity.Text = ""
        txtGrpDeclFees.Text = ""
        txtGrpDeclFood.Text = ""
        txtGrpDeclIDNo.Text = ""
        txtGrpDeclMedical.Text = ""
        txtGrpDeclRates.Text = ""
        txtGrpDeclRent.Text = ""
        txtGrpDeclWater.Text = ""
    End Sub

    Protected Sub clearGrpMemberInfo()
        cmbGrpDeclPosition.ClearSelection()
        txtGrpDeclName.Text = ""
        txtGrpDeclIDNo.Text = ""
        txtGrpDeclAddress.Text = ""
        txtGrpDeclCity.Text = ""
        txtGrpDeclNationality.Text = ""
        txtGrpDeclPhoneNo.Text = ""
        rdbGrpGender.ClearSelection()
        bdpGrpDOB.Text = ""
        bdpGrpIssDate.Text = ""
    End Sub

    Protected Sub cmbBank_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbBank.SelectedIndexChanged
        loadBankBranches(cmbBank.SelectedValue, cmbBankBranch)
    End Sub

    Protected Sub cmbBankAppType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbBankAppType.SelectedIndexChanged
        loadBankBranches(cmbBankAppType.SelectedValue, cmbBranchAppType)
    End Sub

    Protected Sub cmbEducation_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbEducation.SelectedIndexChanged
        If cmbEducation.SelectedValue = "Other" Then
            txtEducationOther.Visible = True
        Else
            txtEducationOther.Visible = False
        End If
        txtEducationOther.Text = ""
    End Sub

    Protected Function getCustomerType(custNo As String)
        Using con = New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
            Using cmd = New SqlCommand("select [CUSTOMER_TYPE] from [CUSTOMER_DETAILS] where [CUSTOMER_NUMBER]='" & custNo & "'", con)
                Dim dt As New DataTable
                Using adp = New SqlDataAdapter(cmd)
                    adp.Fill(dt)
                End Using
                Try
                    Return dt.Rows(0).Item("CUSTOMER_TYPE")
                Catch ex As Exception
                    Return ""
                End Try
            End Using
        End Using
    End Function
    Protected Function generateCustNum() As String
        Try
            Dim custNo As String = "0"
            Dim prefLen = ViewState("AccountPrefix").ToString.Length
            Dim sepLen = ViewState("AccountSeparator").ToString.Length
            If ViewState("AccountSuffixOption") = "Auto" Then
                Using cmd = New SqlCommand("select isnull(max(convert(numeric, AccountSuffix)),0) from CUSTOMER_DETAILS", con)
                    If con.State = ConnectionState.Open Then
                        con.Close()
                    End If
                    con.Open()
                    custNo = cmd.ExecuteScalar() + 1
                    con.Close()
                    If IsDBNull(custNo) Or custNo = 0 Then 'Or custNo = 1
                        custNo = ViewState("AccountSeed").ToString().PadLeft(ViewState("SuffixLength"), "0")
                    End If
                End Using
                'Return ViewState("AccountPrefix").ToString & ViewState("AccountSeparator").ToString & custNo.ToString().PadLeft(ViewState("SuffixLength"), "0")
            ElseIf ViewState("AccountSuffixOption") = "Random" Then
                Dim ran As New Random
                custNo = CInt(ran.NextDouble * 10 ^ ViewState("SuffixLength"))
                Do While Not isUniqueSuffix(custNo)
                Loop
                custNo = CInt(ran.NextDouble * 10 ^ ViewState("SuffixLength"))
            End If
            ViewState("AccSuffix") = custNo.ToString.PadLeft(ViewState("SuffixLength"), "0")
            Return ViewState("AccountPrefix").ToString & ViewState("AccountSeparator").ToString & custNo.ToString().PadLeft(ViewState("SuffixLength"), "0")
        Catch ex As Exception
            msgbox(ex.ToString)
            Return "2".ToString().PadLeft(5, "0")
        End Try
    End Function

    Protected Function getEducation() As String
        If cmbEducation.SelectedValue = "Other" Then
            Return Trim("Other: " & BankString.removeSpecialCharacter(txtEducationOther.Text))
        Else
            Return cmbEducation.SelectedValue
        End If
    End Function
    Protected Sub getFarmers()
        Try
            cmd = New SqlCommand("select ID as [orderID], CUSTOMER_NUMBER as [ID],SURNAME as [Group Name],FORENAMES as [Farmer Name],ADDRESS from CUSTOMER_DETAILS where [CUSTOMER_TYPE]='Farmer' order by orderID DESC", con)
            Dim ds As New DataSet
            Using adp = New SqlDataAdapter(cmd)
                adp.Fill(ds, "CUSTOMER")
            End Using
            If ds.Tables(0).Rows.Count > 0 Then
                ds.Tables(0).Columns.RemoveAt(0)
                grdFarmers.DataSource = ds.Tables(0)
            Else
                grdFarmers.DataSource = Nothing
            End If
            grdFarmers.DataBind()
        Catch ex As Exception
            WriteLogFile(ex.ToString)
        End Try
    End Sub

    Protected Sub getFarmersByName(ByVal name As String)
        Try
            cmd = New SqlCommand("select ID as [orderID], CUSTOMER_NUMBER as [ID],SURNAME as [Group Name],FORENAMES as [Farmer Name],ADDRESS from CUSTOMER_DETAILS where [CUSTOMER_TYPE]='Farmer' and FORENAMES + ' ' + SURNAME like '%" & name & "%' order by orderID DESC", con)
            Dim ds As New DataSet
            Dim adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "CUSTOMER")
            If ds.Tables(0).Rows.Count > 0 Then
                ds.Tables(0).Columns.RemoveAt(0)
                grdFarmers.DataSource = ds.Tables(0)
            Else
                grdFarmers.DataSource = Nothing
            End If
            grdFarmers.DataBind()
        Catch ex As Exception
            WriteLogFile(ex.ToString)
        End Try
    End Sub

    Protected Sub getGroupLimits()
        Try
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd = New SqlCommand("select * from [ParaInternalControls]", con)
                    Dim ds As New DataSet
                    Dim adp = New SqlDataAdapter(cmd)
                    adp.Fill(ds, "cntrl")
                    If ds.Tables(0).Rows.Count > 0 Then
                        Dim dr = ds.Tables(0).Rows(0)
                        ViewState("MinGrpMembers") = dr("MinGrpMembers")
                        ViewState("MaxGrpMembers") = dr("MaxGrpMembers")
                        lblGrpMemberCount.Text = "Minimum allowed group members: " & ViewState("MinGrpMembers").ToString & ". Maximum allowed group members: " & ViewState("MaxGrpMembers").ToString
                        If dr("ClientMoreThanOneGroup") = "1" Then
                            ViewState("ClientMoreThanOneGroup") = "1"
                            lblGrpMemberCount.Text = lblGrpMemberCount.Text & "    Individual can belong to more than one group"
                        Else
                            ViewState("ClientMoreThanOneGroup") = "0"
                            lblGrpMemberCount.Text = lblGrpMemberCount.Text & "    Individual cannot belong to more than one group"
                        End If
                    End If
                End Using
            End Using
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- getGroupLimits()", ex.ToString)
        End Try
    End Sub

    Protected Sub getGroups()
        Try
            cmd = New SqlCommand("select ID as [orderID], CUSTOMER_NUMBER as [ID],SURNAME as [Group Name] from CUSTOMER_DETAILS where [CUSTOMER_TYPE]='Group' order by orderID DESC", con)
            Dim ds As New DataSet
            Using adp = New SqlDataAdapter(cmd)
                adp.Fill(ds, "CUSTOMER")
            End Using
            If ds.Tables(0).Rows.Count > 0 Then
                ds.Tables(0).Columns.RemoveAt(0)
                grdGroup.DataSource = ds.Tables(0)
            Else
                grdGroup.DataSource = Nothing
            End If
            grdGroup.DataBind()
        Catch ex As Exception
            WriteLogFile(ex.ToString)
        End Try
    End Sub

    Protected Sub getGroupsByName(ByVal name As String)
        Try
            cmd = New SqlCommand("select ID as [orderID], CUSTOMER_NUMBER as [ID],SURNAME as [Group Name] from CUSTOMER_DETAILS where [CUSTOMER_TYPE]='Group' and SURNAME like '%" & name & "%' order by orderID DESC", con)
            Dim ds As New DataSet
            Dim adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "CUSTOMER")
            If ds.Tables(0).Rows.Count > 0 Then
                ds.Tables(0).Columns.RemoveAt(0)
                grdGroup.DataSource = ds.Tables(0)
            Else
                grdGroup.DataSource = Nothing
            End If
            grdGroup.DataBind()
        Catch ex As Exception
            WriteLogFile(ex.ToString)
        End Try
    End Sub

    Protected Sub getGrpMemberExpenses(grpNo As String)
        Try
            cmd = New SqlCommand("select ID,NAME,format(Rent,'n') as RENT,format(Food,'n') as FOOD,format(Fees,'n') as FEES,format(AIRTIME,'n') as AIRTIME,format(MEDICAL,'n') as MEDICAL,format(ELECTRICITY,'n') as ELECTRICITY,format(WATER,'n') as WATER,format(RATES,'n') as RATES,format(CITY_OF_HRE,'n') as [CITY OF HARARE] from QUEST_GROUP_MEMBERS where CUSTOMER_NUMBER='" & grpNo & "'", con)
            Dim ds As New DataSet
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "QGM")
            If ds.Tables(0).Rows.Count > 0 Then
                grdGrpDeclExpense.DataSource = ds.Tables(0)
            Else
                grdGrpDeclExpense.DataSource = Nothing
            End If
            grdGrpDeclExpense.DataBind()
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub getGrpMembers(grpNo As String)
        Try
            cmd = New SqlCommand("select ID,Position,Name,IDNO,format(Rent,'n') as Rent,format(Food,'n') as Food,format(Fees,'n') as Fees,format(AIRTIME,'n') as AIRTIME,format(MEDICAL,'n') as MEDICAL,format(ELECTRICITY,'n') as ELECTRICITY,format(WATER,'n') as WATER,format(RATES,'n') as RATES,format(CITY_OF_HRE,'n') as CITY_OF_HRE,convert(varchar,ISSUE_DATE,106) as ISSUE_DATE,convert(varchar,DOB,106) as DOB,ADDRESS,CITY,[PHONE],[NATIONALITY],[GENDER] from QUEST_GROUP_MEMBERS where CUSTOMER_NUMBER='" & grpNo & "'", con)
            Dim ds As New DataSet
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "QGM")
            If ds.Tables(0).Rows.Count > 0 Then
                grdGrpDeclMembers.DataSource = ds.Tables(0)
            Else
                grdGrpDeclMembers.DataSource = Nothing
            End If
            grdGrpDeclMembers.DataBind()
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub getInternalControls()
        Try
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd = New SqlCommand("select * from [ParaInternalControls]", con)
                    Dim ds As New DataSet
                    Dim adp = New SqlDataAdapter(cmd)
                    adp.Fill(ds, "cntrl")
                    If ds.Tables(0).Rows.Count > 0 Then
                        Dim dr = ds.Tables(0).Rows(0)
                        ViewState("AccountPrefix") = dr("AccountPrefix")
                        ViewState("AccountSeparator") = dr("AccountSeparator")
                        ViewState("AccountSuffixOption") = dr("AccountSuffixOption")
                        ViewState("SuffixLength") = dr("SuffixLength")
                        ViewState("AccountSeed") = dr("AccountSeed")
                    End If
                End Using
            End Using
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- getInternalControls()", ex.ToString)
        End Try
    End Sub
    Protected Sub getNames()
        Try
            cmd = New SqlCommand("select ID as [orderID], CUSTOMER_NUMBER as [ID],SURNAME,FORENAMES,ADDRESS from CUSTOMER_DETAILS where [CUSTOMER_TYPE]='Individual' order by orderID DESC", con)
            Dim ds As New DataSet
            Dim adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "CUSTOMER")
            If ds.Tables(0).Rows.Count > 0 Then
                ds.Tables(0).Columns.RemoveAt(0)
                grdNames.DataSource = ds.Tables(0)
            Else
                grdNames.DataSource = Nothing
            End If
            grdNames.DataBind()
        Catch ex As Exception
            WriteLogFile(ex.ToString)
        End Try
    End Sub

    Protected Sub getNamesBySurname(ByVal surname As String)
        Try
            cmd = New SqlCommand("select ID as [orderID], CUSTOMER_NUMBER as [ID],SURNAME,FORENAMES,ADDRESS from CUSTOMER_DETAILS where [CUSTOMER_TYPE]='Individual' and SURNAME + ' ' + FORENAMES like '" & surname & "%' order by orderID DESC", con)
            Dim ds As New DataSet
            Dim adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "CUSTOMER")
            If ds.Tables(0).Rows.Count > 0 Then
                ds.Tables(0).Columns.RemoveAt(0)
                grdNames.DataSource = ds.Tables(0)
            Else
                grdNames.DataSource = Nothing
            End If
            grdNames.DataBind()
        Catch ex As Exception
            WriteLogFile(ex.ToString)
        End Try
    End Sub

    Protected Sub getNamesForEdit(ByVal custID As String)
        Try
            cmd = New SqlCommand("select *,convert(varchar,DOB,106) as DOB1,convert(varchar,ISSUE_DATE,106) as ISSUE_DATE1 from CUSTOMER_DETAILS where CUSTOMER_NUMBER='" & custID & "'", con)
            Dim ds As New DataSet
            Dim adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "CUSTOMER")
            If ds.Tables(0).Rows.Count > 0 Then
                clearAll()
                Try
                    rdbClientType.SelectedValue = ds.Tables(0).Rows(0).Item("CUSTOMER_TYPE_ID")
                Catch ex As Exception
                    rdbClientType.ClearSelection()
                End Try
                txtCustNo.Text = ds.Tables(0).Rows(0).Item("CUSTOMER_NUMBER")
                rdbClientType_SelectedIndexChanged(sender:=New Object, e:=New EventArgs)
                If ds.Tables(0).Rows(0).Item("CUSTOMER_TYPE") = "Group" Then
                    txtGrpName.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("SURNAME"))
                    btnGrpAddGroup.Text = "Update Group Name"
                    getGrpMembers(txtCustNo.Text)
                    getGrpMemberExpenses(txtCustNo.Text)
                    loadGrpMembers(txtCustNo.Text)
                ElseIf ds.Tables(0).Rows(0).Item("CUSTOMER_TYPE") = "Farmer" Then
                    txtFarmNameOfGroup.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("SURNAME"))
                    txtFarmNameOfApplicant.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("FORENAMES"))
                    txtFarmCurrentAddress.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("ADDRESS"))
                    'txtCreditLimit.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("CREDIT_LIMIT"))
                    txtFarmPhoneNo.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("PHONE_NO"))
                    txtFarmIDNo.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("IDNO"))

                    txtFarmNameOfSpouse.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("SPOUSE_NAME"))
                    txtFarmSpouseIDNo.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("SPOUSE_IDNO"))
                    txtFarmCropsGrown.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("CROPS"))
                    txtFarmSpousePhoneNo.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("SPOUSE_PHONE"))
                    txtFarmCurrAddressOfSpouse.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("SPOUSE_ADDRESS"))
                    txtFarmCurrentEstimate.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("CURR_ESTIMATE"))
                    txtFarmMonthlyExpense.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("MONTH_EXPENSE"))
                    txtFarmMonthlyIncome.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("MONTH_INCOME"))
                    txtFarmPeriodFarming.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("FARM_PERIOD"))
                    txtFarmPreviousSales.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("PREV_SALES"))
                    Try
                        txtFarmDOB.Text = ds.Tables(0).Rows(0).Item("DOB1")
                    Catch ex As Exception
                        txtFarmDOB.Text = ""
                    End Try
                    Try
                        txtFarmIssDate.Text = ds.Tables(0).Rows(0).Item("ISSUE_DATE1")
                    Catch ex As Exception
                        txtFarmIssDate.Text = ""
                    End Try
                    Try
                        rdbFarmGender.SelectedValue = ds.Tables(0).Rows(0).Item("GENDER")
                    Catch ex As Exception
                        rdbFarmGender.ClearSelection()
                    End Try
                    btnSaveFarmer.Text = "Update"
                    btnDeleteFarmer.Visible = True
                Else
                    txtSurname.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("SURNAME"))
                    txtForenames.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("FORENAMES"))
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
                        txtEmpHowLong.Text = FormatNumber(BankString.isNullString(ds.Tables(0).Rows(0).Item("CURR_EMP_LENGTH")), 2)
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
                    'Try
                    '    txtHouseHowLong.Text = FormatNumber(BankString.isNullString(ds.Tables(0).Rows(0).Item("HOME_LENGTH")), 2)
                    'Catch ex As Exception
                    '    txtHouseHowLong.Text = ""
                    'End Try
                    Try
                        txtPrevEmpAnnualIncome.Text = FormatNumber(BankString.isNullString(ds.Tables(0).Rows(0).Item("PREV_EMP_INCOME")), 2)
                    Catch ex As Exception
                        txtPrevEmpAnnualIncome.Text = ""
                    End Try
                    Try
                        txtPrevEmpHowLong.Text = FormatNumber(BankString.isNullString(ds.Tables(0).Rows(0).Item("PREV_EMP_LENGTH")), 2)
                    Catch ex As Exception
                        txtPrevEmpHowLong.Text = ""
                    End Try
                    Try
                        txtPrevEmpSalary.Text = FormatNumber(BankString.isNullString(ds.Tables(0).Rows(0).Item("PREV_EMP_SALARY")), 2)
                    Catch ex As Exception
                        txtPrevEmpSalary.Text = ""
                    End Try
                    Try
                        txtPrevEmpSalaryNet.Text = FormatNumber(BankString.isNullString(ds.Tables(0).Rows(0).Item("PREV_EMP_NET")), 2)
                    Catch ex As Exception
                        txtPrevEmpSalaryNet.Text = ""
                    End Try
                    Try
                        txtRent.Text = FormatNumber(BankString.isNullString(ds.Tables(0).Rows(0).Item("MONTHLY_RENT")), 2)
                    Catch ex As Exception
                        txtRent.Text = ""
                    End Try
                    txtIDNo.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("IDNO"))
                    txtNationality.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("NATIONALITY"))
                    txtNoChildren.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("NO_CHILDREN"))
                    txtNoDependant.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("NO_DEPENDANTS"))
                    txtPrevEmpAddress.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("PREV_EMP_ADD"))
                    txtPrevEmpCity.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("PREV_EMP_CITY"))
                    txtPrevEmpEmail.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("PREV_EMP_EMAIL"))
                    txtPrevEmpFax.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("PREV_EMP_FAX"))
                    txtPrevEmployer.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("PREV_EMPLOYER"))
                    txtPrevEmpPhone.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("PREV_EMP_PHONE"))
                    txtPrevEmpPosition.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("PREV_EMP_POSITION"))
                    txtSpouse.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("SPOUSE_NAME"))
                    txtSpouseEmployer.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("SPOUSE_EMPLOYER"))
                    txtSpouseOccupation.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("SPOUSE_OCCUPATION"))
                    txtSpousePhone.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("SPOUSE_PHONE"))
                    txtTradeRef1.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("TRADE_REF1"))
                    txtTradeRef2.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("TRADE_REF2"))
                    txtGuarNameRelative.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("GUARANTOR_REL_NAME"))
                    txtGuarRelAddress.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("GUARANTOR_REL_ADD"))
                    txtGuarRelCity.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("GUARANTOR_REL_CITY"))
                    txtGuarRelPhone.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("GUARANTOR_REL_PHONE"))
                    txtGuarRelReltnship.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("GUARANTOR_REL_RELTNSHP"))
                    Try
                        rdbSubIndividual.SelectedValue = ds.Tables(0).Rows(0).Item("SUB_INDIVIDUAL")
                    Catch ex As Exception
                        rdbSubIndividual.ClearSelection()
                    End Try
                    rdbSubIndividual_SelectedIndexChanged(New Object, New EventArgs)
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
                        cmbSector.SelectedValue = BankString.isNullString(ds.Tables(0).Rows(0).Item("Sector"))
                    Catch ex As Exception
                        cmbSector.ClearSelection()
                    End Try
                    Try
                        cmbArea.SelectedValue = ds.Tables(0).Rows(0).Item("AREA")
                    Catch ex As Exception
                        cmbArea.ClearSelection()
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

                    If rdbClientType.SelectedItem.Text = "Individual" Then
                        lblSurname.Text = "Surname"
                        lblForenames.Text = "Forenames"
                        lblForenames.Visible = True
                        txtForenames.Visible = True
                    ElseIf rdbClientType.SelectedItem.Text = "Business" Then
                        lblSurname.Text = "Name"
                        lblForenames.Visible = False
                        txtForenames.Visible = False
                        txtForenames.Text = ""
                    Else
                        lblSurname.Text = "Surname"
                        lblForenames.Text = "Forenames"
                        lblForenames.Visible = True
                        txtForenames.Visible = True
                        Try
                            rdbSubIndividual.SelectedValue = ds.Tables(0).Rows(0).Item("SUB_INDIVIDUAL")
                        Catch ex As Exception
                            rdbSubIndividual.ClearSelection()
                        End Try
                    End If
                    btnSaveName.Text = "Update"
                    btnDeleteName.Visible = True

                End If
            Else
                btnSaveName.Text = "Save Static Details"
                btnDeleteName.Visible = False
            End If
        Catch ex As Exception
            WriteLogFile(ex.ToString)
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
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- getPDACompanies()", ex.ToString)
        End Try
    End Sub

    Protected Sub grdFarmers_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles grdFarmers.PageIndexChanging
        Try
            grdFarmers.PageIndex = e.NewPageIndex
            If txtSearchFarmer.Text.Trim = "" Then
                getFarmers()
            Else
                getFarmersByName(txtSearchFarmer.Text)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub grdFarmers_SelectedIndexChanged(sender As Object, e As EventArgs) Handles grdFarmers.SelectedIndexChanged
        getNamesForEdit(grdFarmers.SelectedRow.Cells(1).Text)
    End Sub

    Protected Sub grdGroup_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles grdGroup.PageIndexChanging
        Try
            grdGroup.PageIndex = e.NewPageIndex
            If txtSearchGroup.Text.Trim = "" Then
                getGroups()
            Else
                getGroupsByName(txtSearchGroup.Text)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub grdGroup_SelectedIndexChanged(sender As Object, e As EventArgs) Handles grdGroup.SelectedIndexChanged
        getNamesForEdit(grdGroup.SelectedRow.Cells(1).Text)
    End Sub

    Protected Sub grdGrpDeclMembers_PageIndexChanged(sender As Object, e As EventArgs) Handles grdGrpDeclMembers.PageIndexChanged

    End Sub

    Protected Sub grdGrpDeclMembers_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles grdGrpDeclMembers.PageIndexChanging
        grdGrpDeclMembers.PageIndex = e.NewPageIndex
        getGrpMembers(txtCustNo.Text)
    End Sub

    Protected Sub grdGrpDeclMembers_RowCancelingEdit(sender As Object, e As GridViewCancelEditEventArgs) Handles grdGrpDeclMembers.RowCancelingEdit
        Try
            grdGrpDeclMembers.EditIndex = -1
            getGrpMembers(txtCustNo.Text)
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub grdGrpDeclMembers_RowDeleting(sender As Object, e As GridViewDeleteEventArgs) Handles grdGrpDeclMembers.RowDeleting
        grpMembersEditID = DirectCast(grdGrpDeclMembers.Rows(e.RowIndex).FindControl("txtRoleIDEdit"), TextBox).Text
        'cmd = New SqlCommand("delete from MASTER_ROLES where RoleID='" & rolesEditID & "'", con)
        Dim cmd = New SqlCommand("delete from QUEST_GROUP_MEMBERS where ID=''" & grpMembersEditID & "''", con)
        If con.State = ConnectionState.Open Then
            con.Close()
        End If
        con.Open()
        If cmd.ExecuteNonQuery Then
            notify("Member successfully deleted.", "success")
        Else
            notify("Error deleting member", "error")
        End If
        con.Close()
        getGrpMembers(txtCustNo.Text)
        getGrpMemberExpenses(txtCustNo.Text)
        loadGrpMembers(txtCustNo.Text)
    End Sub

    Protected Sub grdGrpDeclMembers_RowEditing(sender As Object, e As GridViewEditEventArgs) Handles grdGrpDeclMembers.RowEditing
        grpMembersEditID = DirectCast(grdGrpDeclMembers.Rows(e.NewEditIndex).FindControl("lblGrdGrpID"), Label).Text
        grdGrpDeclMembers.EditIndex = e.NewEditIndex
        getGrpMembers(txtCustNo.Text)
    End Sub

    Protected Sub grdGrpDeclMembers_RowUpdating(sender As Object, e As GridViewUpdateEventArgs) Handles grdGrpDeclMembers.RowUpdating
        If Trim(grpMembersEditID) = "" Or IsDBNull(grpMembersEditID) Then
            msgbox("No group member selected for update")
            Exit Sub
        End If
        Dim position As String = DirectCast(grdGrpDeclMembers.Rows(e.RowIndex).FindControl("txtGrdGrpPosition"), TextBox).Text
        Dim name = DirectCast(grdGrpDeclMembers.Rows(e.RowIndex).FindControl("txtGrdGrpName"), TextBox).Text
        Dim idno = DirectCast(grdGrpDeclMembers.Rows(e.RowIndex).FindControl("txtGrdGrpIDNo"), TextBox).Text
        Dim address As String = DirectCast(grdGrpDeclMembers.Rows(e.RowIndex).FindControl("txtGrdGrpAddress"), TextBox).Text
        Dim city = DirectCast(grdGrpDeclMembers.Rows(e.RowIndex).FindControl("txtGrdGrpCity"), TextBox).Text
        Dim dob = DirectCast(grdGrpDeclMembers.Rows(e.RowIndex).FindControl("txtGrdGrpDOB"), TextBox).Text
        Dim issDate As String = DirectCast(grdGrpDeclMembers.Rows(e.RowIndex).FindControl("txtGrdGrpIssDate"), TextBox).Text
        Dim phone = DirectCast(grdGrpDeclMembers.Rows(e.RowIndex).FindControl("txtGrdGrpPhone"), TextBox).Text
        Dim nationality = DirectCast(grdGrpDeclMembers.Rows(e.RowIndex).FindControl("txtGrdGrpNat"), TextBox).Text
        Dim gender = DirectCast(grdGrpDeclMembers.Rows(e.RowIndex).FindControl("txtGrdGrpIssGender"), TextBox).Text

        Dim oldUserStatus, oldRoleName As String
        oldUserStatus = ""
        oldRoleName = ""

        Dim updateCmd As New SqlCommand
        updateCmd = New SqlCommand("update QUEST_GROUP_MEMBERS set POSITION='" & BankString.removeSpecialCharacter(position) & "', NAME='" & BankString.removeSpecialCharacter(name) & "', IDNO='" & BankString.removeSpecialCharacter(idno) & "',ISSUE_DATE='" & issDate & "',DOB='" & dob & "',ADDRESS='" & address & "',CITY='" & city & "',PHONE='" & phone & "',NATIONALITY='" & nationality & "',GENDER='" & gender & "' where ID='" & grpMembersEditID & "'", con)

        If con.State = ConnectionState.Open Then
            con.Close()
        End If
        con.Open()
        If updateCmd.ExecuteNonQuery Then
            msgbox("Group member successfully updated")
        Else
            msgbox("Error updating member")
        End If
        con.Close()
        grdGrpDeclMembers.EditIndex = -1
        getGrpMembers(txtCustNo.Text)
        getGrpMemberExpenses(txtCustNo.Text)
        loadGrpMembers(txtCustNo.Text)
    End Sub

    Protected Sub grdNames_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdNames.PageIndexChanging
        Try
            grdNames.PageIndex = e.NewPageIndex
            If txtSearchSurname.Text.Trim = "" Then
                getNames()
            Else
                getNamesBySurname(txtSearchSurname.Text)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub grdNames_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdNames.SelectedIndexChanged
        getNamesForEdit(grdNames.SelectedRow.Cells(1).Text)
    End Sub

    Protected Function IDNoAlreadyExists(IDNo As String) As Boolean
        'cmd = New SqlCommand("select * from CUSTOMER_DETAILS where IDNO like '%" & IDNo & "%'", con)
        cmd = New SqlCommand("select * from CUSTOMER_DETAILS where REPLACE(replace(IDNO,'-',''),' ','') = REPLACE(replace('" & IDNo & "','-',''),' ','')", con)
        Dim ds As New DataSet
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "CD")
        If ds.Tables(0).Rows.Count > 0 Then
            IDNoAlreadyExists = True
        Else
            IDNoAlreadyExists = False
        End If
    End Function

    Protected Function isUniqueCustNo(CustNo As String) As Boolean
        Using cmd = New SqlCommand("select ID from CUSTOMER_DETAILS where CUSTOMER_NUMBER='" & CustNo & "'", con)
            Dim ds As New DataSet
            Using adp = New SqlDataAdapter(cmd)
                adp.Fill(ds, "CD")
            End Using
            If ds.Tables(0).Rows.Count > 0 Then
                Return False
            Else
                Return True
            End If
        End Using
    End Function

    Protected Function isUniqueGrpIDNo(IdNo As String) As Boolean
        Dim ds As New DataSet
        Using cmd = New SqlCommand("select ID from [QUEST_GROUP_MEMBERS] where  replace(replace(replace([IDNO],'-',''),'/',''),' ','')=replace(replace(replace('" & IdNo & "','-',''),'/',''),' ','')", con)
            Using adp = New SqlDataAdapter(cmd)
                adp.Fill(ds, "QGM")
            End Using
            If ds.Tables(0).Rows.Count > 0 Then
                Return False
            Else
                Return True
            End If
        End Using
    End Function

    Protected Function isUniqueGrpMemberIDNo(custNo As String, IdNo As String) As Boolean
        Dim ds As New DataSet
        Using cmd = New SqlCommand("select ID from [QUEST_GROUP_MEMBERS] where [CUSTOMER_NUMBER]='" & custNo & "' and replace(replace(replace([IDNO],'-',''),'/',''),' ','')=replace(replace(replace('" & IdNo & "','-',''),'/',''),' ','')", con)
            Using adp = New SqlDataAdapter(cmd)
                adp.Fill(ds, "QGM")
                If ds.Tables(0).Rows.Count > 0 Then
                    Return False
                Else
                    Return True
                End If
            End Using
        End Using
    End Function

    Protected Function isUniqueSuffix(suff As String) As Boolean
        Using cmd = New SqlCommand("select ID from CUSTOMER_DETAILS where AccountSuffix='" & suff & "'", con)
            Dim ds As New DataSet
            Using adp = New SqlDataAdapter(cmd)
                adp.Fill(ds, "CD")
            End Using
            If ds.Tables(0).Rows.Count > 0 Then
                Return False
            Else
                Return True
            End If
        End Using
    End Function

    Protected Sub loadClientTypes()
        Try
            cmd = New SqlCommand("select * from PARA_CLIENT_TYPES", con)
            Dim ds As New DataSet
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "Clients")
            If ds.Tables(0).Rows.Count > 0 Then
                rdbClientType.DataSource = ds.Tables(0)
                rdbClientType.DataValueField = "ID"
                rdbClientType.DataTextField = "CLIENT_TYPE"
            Else
                rdbClientType.DataSource = Nothing
            End If
            rdbClientType.DataBind()
        Catch ex As Exception
            WriteLogFile(ex.ToString)
        End Try
    End Sub

    Protected Sub loadGrpMembers(grpNo As String)
        Try
            cmbGrpDeclMember.Items.Clear()
            cmbGrpDeclMember.Items.Add("")
            cmd = New SqlCommand("select * from QUEST_GROUP_MEMBERS where CUSTOMER_NUMBER='" & grpNo & "'", con)
            Dim ds As New DataSet
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "QGM")
            If ds.Tables(0).Rows.Count > 0 Then
                cmbGrpDeclMember.DataSource = ds.Tables(0)
                cmbGrpDeclMember.DataTextField = "NAME"
                cmbGrpDeclMember.DataValueField = "ID"
            Else
                cmbGrpDeclMember.DataSource = Nothing
            End If
            cmbGrpDeclMember.DataBind()
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Page.MaintainScrollPositionOnPostBack = True
        Page.ClientScript.RegisterOnSubmitStatement(Me.GetType, "val", "fnOnUpdateValidators();")
        con = New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
        If Not IsPostBack Then
            Session("PhotoName") = ""
            writeBranch()
            loadClientTypes()
            getNames()
            getFarmers()
            getGroups()
            getCompanies()
            'loadBank()
            getIndividualGroups()
            loadBanks(cmbBankAppType)
            loadBanks(cmbBank)
            getPDACompanies()
            loadSectors(cmbSector)
            getInternalControls()
            Try
                Dim EncQuery As New BankEncryption64
                ViewState("restoreID") = EncQuery.Decrypt(Request.QueryString("id"))
                ViewState("isRestore") = EncQuery.Decrypt(Request.QueryString("s"))
                If ViewState("isRestore") = "1" Then
                    getNamesDT(getSavedSession(ViewState("restoreID")))
                    'getSessionGuarantorInfo(ViewState("restoreID"))
                End If
            Catch ex As Exception
            End Try
        End If
    End Sub

    Protected Function getSavedSession(sesID As String) As DataTable
        Try
            Using con As New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("conString").ConnectionString())
                Using cmd = New SqlCommand("select *,convert(varchar,DOB,106) as DOB1,convert(varchar,ISSUE_DATE,106) as ISSUE_DATE1 from CUSTOMER_DETAILS_AutoSave where ID=@id", con)
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

    Protected Sub getNamesDT(ByVal dtt As DataTable)
        Try
            If dtt.Rows.Count > 0 Then
                clearAll()
                Try
                    rdbClientType.SelectedValue = dtt.Rows(0).Item("CUSTOMER_TYPE")
                Catch ex As Exception
                    rdbClientType.ClearSelection()
                End Try
                txtCustNo.Text = dtt.Rows(0).Item("CUSTOMER_NUMBER")
                rdbClientType_SelectedIndexChanged(sender:=New Object, e:=New EventArgs)
                If dtt.Rows(0).Item("CUSTOMER_TYPE") = "Group" Then
                    txtGrpName.Text = BankString.isNullString(dtt.Rows(0).Item("SURNAME"))
                    btnGrpAddGroup.Text = "Update Group Name"
                    getGrpMembers(txtCustNo.Text)
                    getGrpMemberExpenses(txtCustNo.Text)
                    loadGrpMembers(txtCustNo.Text)
                ElseIf dtt.Rows(0).Item("CUSTOMER_TYPE") = "Farmer" Then
                    txtFarmNameOfGroup.Text = BankString.isNullString(dtt.Rows(0).Item("SURNAME"))
                    txtFarmNameOfApplicant.Text = BankString.isNullString(dtt.Rows(0).Item("FORENAMES"))
                    txtFarmCurrentAddress.Text = BankString.isNullString(dtt.Rows(0).Item("ADDRESS"))
                    txtFarmPhoneNo.Text = BankString.isNullString(dtt.Rows(0).Item("PHONE_NO"))
                    txtFarmIDNo.Text = BankString.isNullString(dtt.Rows(0).Item("IDNO"))

                    txtFarmNameOfSpouse.Text = BankString.isNullString(dtt.Rows(0).Item("SPOUSE_NAME"))
                    txtFarmSpouseIDNo.Text = BankString.isNullString(dtt.Rows(0).Item("SPOUSE_IDNO"))
                    txtFarmCropsGrown.Text = BankString.isNullString(dtt.Rows(0).Item("CROPS"))
                    txtFarmSpousePhoneNo.Text = BankString.isNullString(dtt.Rows(0).Item("SPOUSE_PHONE"))
                    txtFarmCurrAddressOfSpouse.Text = BankString.isNullString(dtt.Rows(0).Item("SPOUSE_ADDRESS"))
                    txtFarmCurrentEstimate.Text = BankString.isNullString(dtt.Rows(0).Item("CURR_ESTIMATE"))
                    txtFarmMonthlyExpense.Text = BankString.isNullString(dtt.Rows(0).Item("MONTH_EXPENSE"))
                    txtFarmMonthlyIncome.Text = BankString.isNullString(dtt.Rows(0).Item("MONTH_INCOME"))
                    txtFarmPeriodFarming.Text = BankString.isNullString(dtt.Rows(0).Item("FARM_PERIOD"))
                    txtFarmPreviousSales.Text = BankString.isNullString(dtt.Rows(0).Item("PREV_SALES"))
                    Try
                        txtFarmDOB.Text = dtt.Rows(0).Item("DOB1")
                    Catch ex As Exception
                        txtFarmDOB.Text = ""
                    End Try
                    Try
                        txtFarmIssDate.Text = dtt.Rows(0).Item("ISSUE_DATE1")
                    Catch ex As Exception
                        txtFarmIssDate.Text = ""
                    End Try
                    Try
                        rdbFarmGender.SelectedValue = dtt.Rows(0).Item("GENDER")
                    Catch ex As Exception
                        rdbFarmGender.ClearSelection()
                    End Try
                    btnSaveFarmer.Text = "Update"
                    btnDeleteFarmer.Visible = True
                Else
                    txtSurname.Text = BankString.isNullString(dtt.Rows(0).Item("SURNAME"))
                    txtForenames.Text = BankString.isNullString(dtt.Rows(0).Item("FORENAMES"))
                    txtAddress.Text = BankString.isNullString(dtt.Rows(0).Item("ADDRESS"))
                    txtPhoneNo.Text = BankString.isNullString(dtt.Rows(0).Item("PHONE_NO"))
                    txtCity.Text = BankString.isNullString(dtt.Rows(0).Item("CITY"))
                    txtCurrEmployer.Text = BankString.isNullString(dtt.Rows(0).Item("CURR_EMPLOYER"))
                    txtEducationOther.Text = BankString.isNullString(dtt.Rows(0).Item("EDUCATION"))
                    txtEmpAddress.Text = BankString.isNullString(dtt.Rows(0).Item("CURR_EMP_ADD"))
                    txtEmpCity.Text = BankString.isNullString(dtt.Rows(0).Item("CURR_EMP_CITY"))
                    txtEmpEmail.Text = BankString.isNullString(dtt.Rows(0).Item("CURR_EMP_EMAIL"))
                    txtEmpFax.Text = BankString.isNullString(dtt.Rows(0).Item("CURR_EMP_FAX"))
                    Try
                        txtEmpHowLong.Text = FormatNumber(BankString.isNullString(dtt.Rows(0).Item("CURR_EMP_LENGTH")), 2)
                    Catch ex As Exception
                        txtEmpHowLong.Text = ""
                    End Try
                    Try
                        txtEmpOtherIncome.Text = FormatNumber(BankString.isNullString(dtt.Rows(0).Item("CURR_EMP_INCOME")), 2)
                    Catch ex As Exception
                        txtEmpOtherIncome.Text = ""
                    End Try
                    txtEmpPhone.Text = BankString.isNullString(dtt.Rows(0).Item("CURR_EMP_PHONE"))
                    txtEmpPosition.Text = BankString.isNullString(dtt.Rows(0).Item("CURR_EMP_POSITION"))
                    Try
                        txtEmpSalary.Text = FormatNumber(BankString.isNullString(dtt.Rows(0).Item("CURR_EMP_SALARY")), 2)
                    Catch ex As Exception
                        txtEmpSalary.Text = ""
                    End Try
                    Try
                        txtEmpSalaryNet.Text = FormatNumber(BankString.isNullString(dtt.Rows(0).Item("CURR_EMP_NET")), 2)
                    Catch ex As Exception
                        txtEmpSalaryNet.Text = ""
                    End Try
                    Try
                        txtPrevEmpAnnualIncome.Text = FormatNumber(BankString.isNullString(dtt.Rows(0).Item("PREV_EMP_INCOME")), 2)
                    Catch ex As Exception
                        txtPrevEmpAnnualIncome.Text = ""
                    End Try
                    Try
                        txtPrevEmpHowLong.Text = FormatNumber(BankString.isNullString(dtt.Rows(0).Item("PREV_EMP_LENGTH")), 2)
                    Catch ex As Exception
                        txtPrevEmpHowLong.Text = ""
                    End Try
                    Try
                        txtPrevEmpSalary.Text = FormatNumber(BankString.isNullString(dtt.Rows(0).Item("PREV_EMP_SALARY")), 2)
                    Catch ex As Exception
                        txtPrevEmpSalary.Text = ""
                    End Try
                    Try
                        txtPrevEmpSalaryNet.Text = FormatNumber(BankString.isNullString(dtt.Rows(0).Item("PREV_EMP_NET")), 2)
                    Catch ex As Exception
                        txtPrevEmpSalaryNet.Text = ""
                    End Try
                    Try
                        txtRent.Text = FormatNumber(BankString.isNullString(dtt.Rows(0).Item("MONTHLY_RENT")), 2)
                    Catch ex As Exception
                        txtRent.Text = ""
                    End Try
                    txtIDNo.Text = BankString.isNullString(dtt.Rows(0).Item("IDNO"))
                    txtNationality.Text = BankString.isNullString(dtt.Rows(0).Item("NATIONALITY"))
                    txtNoChildren.Text = BankString.isNullString(dtt.Rows(0).Item("NO_CHILDREN"))
                    txtNoDependant.Text = BankString.isNullString(dtt.Rows(0).Item("NO_DEPENDANTS"))
                    txtPrevEmpAddress.Text = BankString.isNullString(dtt.Rows(0).Item("PREV_EMP_ADD"))
                    txtPrevEmpCity.Text = BankString.isNullString(dtt.Rows(0).Item("PREV_EMP_CITY"))
                    txtPrevEmpEmail.Text = BankString.isNullString(dtt.Rows(0).Item("PREV_EMP_EMAIL"))
                    txtPrevEmpFax.Text = BankString.isNullString(dtt.Rows(0).Item("PREV_EMP_FAX"))
                    txtPrevEmployer.Text = BankString.isNullString(dtt.Rows(0).Item("PREV_EMPLOYER"))
                    txtPrevEmpPhone.Text = BankString.isNullString(dtt.Rows(0).Item("PREV_EMP_PHONE"))
                    txtPrevEmpPosition.Text = BankString.isNullString(dtt.Rows(0).Item("PREV_EMP_POSITION"))
                    txtSpouse.Text = BankString.isNullString(dtt.Rows(0).Item("SPOUSE_NAME"))
                    txtSpouseEmployer.Text = BankString.isNullString(dtt.Rows(0).Item("SPOUSE_EMPLOYER"))
                    txtSpouseOccupation.Text = BankString.isNullString(dtt.Rows(0).Item("SPOUSE_OCCUPATION"))
                    txtSpousePhone.Text = BankString.isNullString(dtt.Rows(0).Item("SPOUSE_PHONE"))
                    txtTradeRef1.Text = BankString.isNullString(dtt.Rows(0).Item("TRADE_REF1"))
                    txtTradeRef2.Text = BankString.isNullString(dtt.Rows(0).Item("TRADE_REF2"))
                    Try
                        rdbSubIndividual.SelectedValue = dtt.Rows(0).Item("SUB_INDIVIDUAL")
                    Catch ex As Exception
                        rdbSubIndividual.ClearSelection()
                    End Try
                    rdbSubIndividual_SelectedIndexChanged(New Object, New EventArgs)
                    txtECNo.Text = BankString.isNullString(dtt.Rows(0).Item("ECNO"))
                    txtECNoCD.Text = BankString.isNullString(dtt.Rows(0).Item("CD"))
                    Try
                        cmbBankAppType.SelectedValue = BankString.isNullString(dtt.Rows(0).Item("AppTypeBank"))
                    Catch ex As Exception
                        cmbBankAppType.ClearSelection()
                    End Try
                    Try
                        cmbBranchAppType.SelectedValue = BankString.isNullString(dtt.Rows(0).Item("AppTypeBranch"))
                    Catch ex As Exception
                        cmbBranchAppType.ClearSelection()
                    End Try
                    Try
                        cmbPDAAppType.SelectedValue = BankString.isNullString(dtt.Rows(0).Item("PDACode"))
                    Catch ex As Exception
                        cmbPDAAppType.ClearSelection()
                    End Try
                    Try
                        txtOtherAppType.Text = BankString.isNullString(dtt.Rows(0).Item("AppTypeOtherDesc"))
                    Catch ex As Exception
                        txtOtherAppType.Text = ""
                    End Try
                    Try
                        rdbGender.SelectedValue = dtt.Rows(0).Item("GENDER")
                    Catch ex As Exception
                        rdbGender.ClearSelection()
                    End Try
                    Try
                        rdbHouse.SelectedValue = dtt.Rows(0).Item("HOME_TYPE")
                    Catch ex As Exception
                        rdbHouse.ClearSelection()
                    End Try
                    Try
                        cmbEducation.SelectedValue = dtt.Rows(0).Item("EDUCATION")
                    Catch ex As Exception
                        cmbEducation.ClearSelection()
                    End Try
                    Try
                        cmbMaritalStatus.SelectedValue = dtt.Rows(0).Item("MARITAL_STATUS")
                    Catch ex As Exception
                        cmbMaritalStatus.ClearSelection()
                    End Try
                    Try
                        cmbArea.SelectedValue = dtt.Rows(0).Item("AREA")
                    Catch ex As Exception
                        cmbArea.ClearSelection()
                    End Try
                    If BankString.isNullString(dtt.Rows(0).Item("DOB1")) = "01 Jan 1900" Then
                        bdpDOB.Text = ""
                    Else
                        bdpDOB.Text = BankString.isNullString(dtt.Rows(0).Item("DOB1"))
                    End If
                    If BankString.isNullString(dtt.Rows(0).Item("ISSUE_DATE1")) = "01 Jan 1900" Then
                        bdpIssDate.Text = ""
                    Else
                        bdpIssDate.Text = BankString.isNullString(dtt.Rows(0).Item("ISSUE_DATE1"))
                    End If

                    If rdbClientType.SelectedValue = "Individual" Then
                        lblSurname.Text = "Surname"
                        lblForenames.Text = "Forenames"
                        lblForenames.Visible = True
                        txtForenames.Visible = True
                    ElseIf rdbClientType.SelectedValue = "Business" Then
                        lblSurname.Text = "Name"
                        lblForenames.Visible = False
                        txtForenames.Visible = False
                        txtForenames.Text = ""
                    Else
                        lblSurname.Text = "Surname"
                        lblForenames.Text = "Forenames"
                        lblForenames.Visible = True
                        txtForenames.Visible = True
                        Try
                            rdbSubIndividual.SelectedValue = dtt.Rows(0).Item("SUB_INDIVIDUAL")
                        Catch ex As Exception
                            rdbSubIndividual.ClearSelection()
                        End Try
                    End If
                    If dtt.Rows(0).Item("Operation") = "Save" Then
                    Else
                        btnSaveName.Text = "Update"
                        'btnDeleteName.Visible = True
                    End If

                End If
            Else
                btnSaveName.Text = "Save"
                btnDeleteName.Visible = False
            End If
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- getNamesDT()", ex.ToString)
        End Try
    End Sub
    Protected Sub rdbClientType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdbClientType.SelectedIndexChanged
        If rdbClientType.SelectedItem.Text = "Individual" Then
            panIndividual.Visible = True
            panGroup.Visible = False
            pnlFarmers.Visible = False
            panCompany.Visible = False
            lblSurname.Text = "Surname"
            lblForenames.Text = "Forenames"
            lblForenames.Visible = True
            txtForenames.Visible = True
        ElseIf rdbClientType.SelectedItem.Text = "Corporate" Or rdbClientType.SelectedItem.Text = "Group" Then
            getGroupLimits()
            panIndividual.Visible = False
            panGroup.Visible = True
            pnlFarmers.Visible = False
            panCompany.Visible = False
            lblSurname.Text = "Name"
            lblForenames.Visible = False
            txtForenames.Visible = False
            txtForenames.Text = ""
        ElseIf rdbClientType.SelectedItem.Text = "Farmer" Then
            panIndividual.Visible = False
            panGroup.Visible = False
            pnlFarmers.Visible = True
            panCompany.Visible = False
            lblSurname.Text = "Surname"
            lblForenames.Text = "Forenames"
            lblForenames.Visible = True
            txtForenames.Visible = True
        ElseIf rdbClientType.SelectedItem.Text = "Business" Then
            panIndividual.Visible = False
            panGroup.Visible = False
            pnlFarmers.Visible = False
            panCompany.Visible = True
            lblSurname.Text = "Registered Name"
            lblForenames.Text = "Trade Name"
            lblForenames.Visible = True
            txtForenames.Visible = True
        Else
            lblSurname.Text = "Surname"
            lblForenames.Text = "Forenames"
            lblForenames.Visible = True
            txtForenames.Visible = True
        End If
    End Sub

    Protected Sub rdbSubIndividual_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rdbSubIndividual.SelectedIndexChanged
        applicantTypeSelector(rdbSubIndividual.SelectedValue)
    End Sub

    Protected Sub txtIDNo_TextChanged(sender As Object, e As EventArgs) Handles txtIDNo.TextChanged
        If IDNoAlreadyExists(txtIDNo.Text) Then
            lblIDError.Text = "ID Number already registered"
            txtIDNo.CssClass = "col-xs-12 form-control input-sm tb_with_border"
        Else
            lblIDError.Text = ""
            txtIDNo.CssClass = "col-xs-12 form-control input-sm tb_without_border"
        End If
        'ClientScript.RegisterStartupScript(Me.GetType(), "Dates", "<script type=""text/javascript"">registerDates();</script>")
    End Sub

    Protected Sub writeBranch()
        lblBranchCode.Text = Session("BRANCHCODE")
        lblBranchName.Text = Session("BRANCHNAME")
    End Sub

    Private Sub btnAddSector_Click(sender As Object, e As EventArgs) Handles btnAddSector.Click
        Try
            If Trim(txtSector.Text) <> "" Then
                Dim ds As New DataSet
                Using cmd = New SqlCommand("select * from PARA_SECTOR where SECTOR='" & txtSector.Text & "'", con)
                    Using adp = New SqlDataAdapter(cmd)
                        adp.Fill(ds, "PRODUCTS")
                    End Using
                End Using
                If ds.Tables(0).Rows.Count > 0 Then
                    notify("Sector already captured", "warning")
                Else
                    Using cmd = New SqlCommand("insert into PARA_SECTOR ([SECTOR]) values (@Sector)", con)
                        cmd.Parameters.AddWithValue("@Sector", txtSector.Text)
                        If con.State = ConnectionState.Open Then
                            con.Close()
                        End If
                        con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                        CreditManager.notify("New sector entered", "success")
                        txtSector.Text = ""
                        loadSectors(cmbSector)
                    End Using
                End If
            Else
                notify("Enter text for Sector", "error")
            End If
        Catch ex As Exception
            ErrorLogging.WriteLogFile(Session("UserId"), Request.Url.ToString & " --- btnAddSector_Click()", ex.ToString)
        End Try
    End Sub
    Private Sub grdGrpDeclMembers_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles grdGrpDeclMembers.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            grpCount += 1
            lblCurrGrpMembers.Text = grpCount & " group members added"
            If ViewState("MinGrpMembers") > grpCount Then
                'change label class to warning
                divGrpCount.Attributes.Add("class", "row alert-warning")
            ElseIf ViewState("MaxGrpMembers") <= grpCount Then
                'change label class to danger. Disable add button
                divGrpCount.Attributes.Add("class", "row alert-danger")
                btnGrpDeclAdd.Enabled = False
                lblGrpDeclMemberAdded.Text = "Maximum number of group members added."
            Else
                'change label class to success
                divGrpCount.Attributes.Add("class", "row alert-success")
            End If
        End If
    End Sub

    Protected Sub getIndividualGroups()
        Try
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd As New SqlCommand("select ISNULL(SURNAME,'')+' - '+ISNULL(CUSTOMER_NUMBER,'') as display,CUSTOMER_NUMBER from CUSTOMER_DETAILS where CUSTOMER_TYPE='Group'", con)
                    Dim dt As New DataTable
                    Using adp As New SqlDataAdapter(cmd)
                        adp.Fill(dt)
                    End Using
                    If dt.Rows.Count > 0 Then
                        chkGroups.DataSource = dt
                        chkGroups.DataMember = "CUSTOMER_NUMBER"
                        chkGroups.DataTextField = "display"
                        chkGroups.DataBind()
                    End If
                End Using
            End Using
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- getIndividualGroups()", ex.ToString)
        End Try
    End Sub
    Protected Sub chkIsGroup_CheckedChanged(sender As Object, e As EventArgs) Handles chkIsGroup.CheckedChanged
        If chkIsGroup.Checked Then
            chkGroups.Visible = True
        Else
            chkGroups.Visible = False
        End If
    End Sub

    Protected Sub btnSearchCompany_Click(sender As Object, e As EventArgs) Handles btnSearchCompany.Click
        getCompaniesByName(txtSearchCompany.Text)
    End Sub

    Protected Sub getCompanies()
        Try
            Using cmd = New SqlCommand("select ID as [orderID], CUSTOMER_NUMBER as [ID],SURNAME as [Registered Name],FORENAMES as [Trade Name],ADDRESS +' '+ CITY as [Address] from CUSTOMER_DETAILS where [CUSTOMER_TYPE] in ('Company','Business') order by orderID DESC", con)
                Dim ds As New DataSet
                Using adp = New SqlDataAdapter(cmd)
                    adp.Fill(ds, "CUSTOMER")
                End Using
                ds.Tables(0).Columns.RemoveAt(0)
                bindGrid(ds.Tables(0), grdCompany)
            End Using
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- getCompanies()", ex.ToString)
        End Try
    End Sub

    Protected Sub getCompaniesByName(nam As String)
        Try
            Using cmd = New SqlCommand("select ID as [orderID], CUSTOMER_NUMBER as [ID],SURNAME as [Registered Name],FORENAMES as [Trade Name],ADDRESS +' '+ CITY as [Address] from CUSTOMER_DETAILS where [CUSTOMER_TYPE] in ('Company','Business') and isnull(Surname,'') + ' '+ isnull(forenames,'') like '%'+@cName+'%' order by orderID DESC", con)
                cmd.Parameters.AddWithValue("@cName", nam)
                Dim ds As New DataSet
                Using adp = New SqlDataAdapter(cmd)
                    adp.Fill(ds, "CUSTOMER")
                End Using
                ds.Tables(0).Columns.RemoveAt(0)
                bindGrid(ds.Tables(0), grdCompany)
            End Using
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- getCompaniesByName()", ex.ToString)
        End Try
    End Sub

    Protected Sub btnSaveBus_Click(sender As Object, e As EventArgs) Handles btnSaveBus.Click
        Try
            Dim cmd As New SqlCommand
            Dim custNo = generateCustNum()
            If btnSaveBus.Text = "Update" Then
                cmd = New SqlCommand("INSERT INTO CUSTOMER_DETAILS_AUDIT ([CUSTOMER_TYPE],[CUSTOMER_TYPE_ID],[SUB_INDIVIDUAL],[CUSTOMER_NUMBER],[SURNAME],[FORENAMES],[DOB],[IDNO],[ADDRESS],[CITY],[PHONE_NO],[MODIFIED_BY],[MODIFIED_DATE],[BRANCH_CODE],[BRANCH_NAME],ContactName,ContactPhone,ContactEmail,POBox,BusEmail,[TRAN_TYPE],[AUTHORIZED],[DirectorName],[DirectorGender],[DirectorTel],[DirectorEmail],[DirectorAddress],[DirectorDOB],[DirectorIDNo]) values ('" & rdbClientType.SelectedItem.Text & "','" & rdbClientType.SelectedValue & "','" & rdbCompanyType.SelectedValue & "','" & txtCustNo.Text & "','" & BankString.removeSpecialCharacter(txtRegdName.Text) & "','" & BankString.removeSpecialCharacter(txtTradeName.Text) & "','" & txtBusRegdDate.Text & "','" & txtBusRegNo.Text & "','" & BankString.removeSpecialCharacter(txtRoad.Text) & "','" & BankString.removeSpecialCharacter(txtCityTown.Text) & "','" & txtBusinessPhone.Text & "','" & Session("UserID") & "',getdate(),'" & lblBranchCode.Text & "','" & BankString.removeSpecialCharacter(lblBranchName.Text) & "',NULLIF('" & txtContactName.Text.Replace("'", "''") & "',''),NULLIF('" & txtContactTel.Text & "',''),NULLIF('" & txtContactEmail.Text & "',''),'" & txtBox.Text & "','" & txtBusinessEmail.Text & "','UPDATE',0,'" & txtDirectorName.Text.Replace("'", "''") & "','" & rdbDirectorGender.SelectedValue & "','" & txtDirectorPhone.Text & "','" & txtDirectorEmail.Text.Replace("'", "''") & "','" & txtDirectorResAddress.Text.Replace("'", "''") & "',NULLIF('" & txtDirectorDOB.Text & "',''),'" & txtDirectorIDNumber.Text & "')", con)
            Else
                txtCustNo.Text = custNo
                cmd = New SqlCommand("INSERT INTO CUSTOMER_DETAILS ([CUSTOMER_TYPE],[CUSTOMER_TYPE_ID],[SUB_INDIVIDUAL],[CUSTOMER_NUMBER],[SURNAME],[FORENAMES],[DOB],[IDNO],[ADDRESS],[CITY],[PHONE_NO],[MODIFIED_BY],[MODIFIED_DATE],[BRANCH_CODE],[BRANCH_NAME],ContactName,ContactPhone,ContactEmail,POBox,BusEmail,[DirectorName],[DirectorGender],[DirectorTel],[DirectorEmail],[DirectorAddress],[DirectorDOB],[DirectorIDNo]) values ('" & rdbClientType.SelectedItem.Text & "','" & rdbClientType.SelectedValue & "','" & rdbCompanyType.SelectedValue & "','" & custNo & "','" & BankString.removeSpecialCharacter(txtRegdName.Text) & "','" & BankString.removeSpecialCharacter(txtTradeName.Text) & "','" & txtBusRegdDate.Text & "','" & txtBusRegNo.Text & "','" & BankString.removeSpecialCharacter(txtRoad.Text) & "','" & BankString.removeSpecialCharacter(txtCityTown.Text) & "','" & txtBusinessPhone.Text & "','" & Session("UserID") & "',getdate(),'" & lblBranchCode.Text & "','" & BankString.removeSpecialCharacter(lblBranchName.Text) & "',NULLIF('" & txtContactName.Text.Replace("'", "''") & "',''),NULLIF('" & txtContactTel.Text & "',''),NULLIF('" & txtContactEmail.Text & "',''),'" & txtBox.Text.Replace("'", "''") & "','" & txtBusinessEmail.Text & "','" & txtDirectorName.Text.Replace("'", "''") & "','" & rdbDirectorGender.SelectedValue & "','" & txtDirectorPhone.Text & "','" & txtDirectorEmail.Text.Replace("'", "''") & "','" & txtDirectorResAddress.Text.Replace("'", "''") & "',NULLIF('" & txtDirectorDOB.Text & "',''),'" & txtDirectorIDNumber.Text & "')", con)
            End If
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            con.Open()
            If cmd.ExecuteNonQuery() Then
                updateDirectorCustNo(txtCustNo.Text)
                getCompanies()
                If btnSaveBus.Text = "Update" Then
                    notify("Client details updated", "success")
                Else
                    notify("Client details saved with customer number: " & custNo, "success")
                End If
            Else
                notify("Error saving client details", "error")
            End If
            con.Close()
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- btnSaveBus_Click()", ex.ToString)
        End Try
    End Sub

    Protected Sub updateDirectorCustNo(custNo As String)
        Try
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd = New SqlCommand("update [CompanyDirectors] set CustomerNo='" & custNo & "' where (CustomerNo='' and CapturedBy='" & Session("UserId") & "')", con)
                    con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                End Using
            End Using
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- updateDirectorCustNo()", ex.ToString)
        End Try
    End Sub

    Protected Sub btnAddDirector_Click(sender As Object, e As EventArgs) Handles btnAddDirector.Click
        Try
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd = New SqlCommand("INSERT INTO [CompanyDirectors] (CustomerNo,DirectorName,DirectorGender,DirectorTel,DirectorEmail,DirectorAddress,DirectorDOB,DirectorIDNo,CapturedBy,CaptureDate) VALUES (@CustomerNo,@DirectorName,@DirectorGender,@DirectorTel,@DirectorEmail,@DirectorAddress,@DirectorDOB,@DirectorIDNo,@CapturedBy,GETDATE())", con)
                    cmd.Parameters.AddWithValue("@CustomerNo", "")
                    cmd.Parameters.AddWithValue("@DirectorName", txtDirectorName.Text)
                    cmd.Parameters.AddWithValue("@DirectorGender", rdbDirectorGender.SelectedValue)
                    cmd.Parameters.AddWithValue("@DirectorTel", txtDirectorPhone.Text)
                    cmd.Parameters.AddWithValue("@DirectorEmail", txtDirectorEmail.Text)
                    cmd.Parameters.AddWithValue("@DirectorAddress", txtDirectorResAddress.Text)
                    cmd.Parameters.AddWithValue("@DirectorDOB", txtDirectorDOB.Text)
                    cmd.Parameters.AddWithValue("@DirectorIDNo", txtDirectorIDNumber.Text)
                    cmd.Parameters.AddWithValue("@CapturedBy", Session("UserId"))
                    con.Open()
                    If cmd.ExecuteNonQuery Then
                        notify("Director information saved", "success")
                        getDirectors(txtCustNo.Text)
                        txtDirectorDOB.Text = ""
                        txtDirectorEmail.Text = ""
                        txtDirectorIDNumber.Text = ""
                        txtDirectorName.Text = ""
                        txtDirectorPhone.Text = ""
                        txtDirectorResAddress.Text = ""
                        rdbDirectorGender.ClearSelection()
                    Else
                        notify("Error saving director information", "error")
                    End If
                End Using
            End Using
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- btnAddDirector_Click()", ex.ToString)
        End Try
    End Sub
    Protected Sub btnDeleteBus_Click(sender As Object, e As EventArgs) Handles btnDeleteBus.Click
        Try
            Using cmd = New SqlCommand("INSERT INTO CUSTOMER_DETAILS_AUDIT ([CUSTOMER_TYPE],[CUSTOMER_NUMBER],[SURNAME],[FORENAMES],[DOB],[IDNO],[ADDRESS],[CITY],[PHONE_NO],[MODIFIED_BY],[MODIFIED_DATE],[BRANCH_CODE],[BRANCH_NAME],ContactName,ContactPhone,ContactEmail,POBox,BusEmail,[DirectorName],[DirectorGender],[DirectorTel],[DirectorEmail],[DirectorAddress],[DirectorIDNo],[DirectorDOB],[TRAN_TYPE],[AUTHORIZED]) values ('" & rdbClientType.SelectedValue & "','" & txtCustNo.Text & "','" & BankString.removeSpecialCharacter(txtRegdName.Text) & "','" & BankString.removeSpecialCharacter(txtTradeName.Text) & "','" & txtBusRegdDate.Text & "','" & txtBusRegNo.Text & "','" & BankString.removeSpecialCharacter(txtRoad.Text) & "','" & BankString.removeSpecialCharacter(txtCityTown.Text) & "','" & txtBusinessPhone.Text & "','" & Session("UserID") & "',getdate(),'" & lblBranchCode.Text & "','" & BankString.removeSpecialCharacter(lblBranchName.Text) & "',NULLIF('" & txtContactName.Text & "',''),NULLIF('" & txtContactTel.Text & "',''),NULLIF('" & txtContactEmail.Text & "',''),'" & txtBox.Text & "','" & txtBusinessEmail.Text & "','" & BankString.removeSpecialCharacter(txtDirectorName.Text) & "','" & rdbDirectorGender.SelectedValue & "','" & txtDirectorPhone.Text & "','" & txtDirectorEmail.Text & "','" & BankString.removeSpecialCharacter(txtDirectorResAddress.Text) & "','" & txtDirectorIDNumber.Text & "','" & txtDirectorDOB.Text & "','DELETE',0)", con)
                If con.State = ConnectionState.Open Then
                    con.Close()
                End If
                con.Open()
                If cmd.ExecuteNonQuery Then
                    notify("Name successfully marked for deletion. Authorization pending.", "success")
                    getCompanies()
                    clearAll()
                    rdbClientType_SelectedIndexChanged(sender, New EventArgs)
                    btnSaveBus.Text = "Save"
                    btnDeleteBus.Visible = False
                Else
                    notify("Error deleting name", "error")
                End If
            End Using
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- btnDeleteName_Click()", ex.ToString)
        End Try
    End Sub

    Protected Sub getDirectors(custNo As String)
        Try
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd = New SqlCommand("Select DirectorName as [Name],DirectorGender as [Gender],DirectorIDNo as [ID Number],DirectorTel as [Telephone],DirectorEmail as [Email],DirectorAddress as [Address],convert(varchar,DirectorDOB,106) as [Date of Birth] from [CompanyDirectors] where CustomerNo='" & custNo & "' or (CustomerNo='' and CapturedBy='" & Session("UserId") & "')", con)
                    Dim dt As New DataTable
                    Using adp = New SqlDataAdapter(cmd)
                        adp.Fill(dt)
                    End Using
                    bindGrid(dt, grdDirector)
                End Using
            End Using
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- getDirectors()", ex.ToString)
        End Try
    End Sub

    Private Sub rdbCompanyType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rdbCompanyType.SelectedIndexChanged
        If rdbCompanyType.SelectedValue = "Sole" Then
            btnAddDirector.Visible = False
        ElseIf rdbCompanyType.SelectedValue = "Registered" Then
            btnAddDirector.Visible = True
        End If
    End Sub

    Protected Sub grdCompany_SelectedIndexChanged(sender As Object, e As EventArgs) Handles grdCompany.SelectedIndexChanged
        getCompanyForEdit(grdCompany.SelectedRow.Cells(1).Text)
        btnSaveBus.Text = "Update"
        rdbCompanyType_SelectedIndexChanged(sender, New EventArgs)
    End Sub

    Protected Sub getCompanyForEdit(custNo As String)
        Try
            Using cmd = New SqlCommand("select *,convert(varchar,DOB,106) as DOB1,convert(varchar,DirectorDOB,106) as DirectorDOB1 from CUSTOMER_DETAILS where [CUSTOMER_NUMBER] = @custNo", con)
                cmd.Parameters.AddWithValue("@custNo", custNo)
                Dim dt As New DataTable
                Using adp = New SqlDataAdapter(cmd)
                    adp.Fill(dt)
                End Using
                If dt.Rows.Count > 0 Then
                    txtCustNo.Text = custNo
                    rdbCompanyType.SelectedValue = BankString.isNullString(dt.Rows(0).Item("SUB_INDIVIDUAL"))
                    txtRegdName.Text = BankString.isNullString(dt.Rows(0).Item("SURNAME"))
                    txtTradeName.Text = BankString.isNullString(dt.Rows(0).Item("FORENAMES"))
                    txtBusRegNo.Text = BankString.isNullString(dt.Rows(0).Item("IDNO"))
                    txtBusRegdDate.Text = BankString.isNullString(dt.Rows(0).Item("DOB1"))
                    txtRoad.Text = BankString.isNullString(dt.Rows(0).Item("ADDRESS"))
                    txtCityTown.Text = BankString.isNullString(dt.Rows(0).Item("CITY"))
                    txtBox.Text = BankString.isNullString(dt.Rows(0).Item("POBox"))
                    txtBusinessPhone.Text = BankString.isNullString(dt.Rows(0).Item("PHONE_NO"))
                    txtBusinessEmail.Text = BankString.isNullString(dt.Rows(0).Item("BusEmail"))
                    txtContactName.Text = BankString.isNullString(dt.Rows(0).Item("ContactName"))
                    txtContactTel.Text = BankString.isNullString(dt.Rows(0).Item("ContactPhone"))
                    txtContactEmail.Text = BankString.isNullString(dt.Rows(0).Item("ContactEmail"))
                    txtDirectorDOB.Text = BankString.isNullString(dt.Rows(0).Item("DirectorDOB1"))
                    txtDirectorEmail.Text = BankString.isNullString(dt.Rows(0).Item("DirectorEmail"))
                    txtDirectorIDNumber.Text = BankString.isNullString(dt.Rows(0).Item("DirectorIDNo"))
                    txtDirectorName.Text = BankString.isNullString(dt.Rows(0).Item("DirectorName"))
                    txtDirectorPhone.Text = BankString.isNullString(dt.Rows(0).Item("DirectorTel"))
                    txtDirectorResAddress.Text = BankString.isNullString(dt.Rows(0).Item("DirectorAddress"))
                    Try
                        rdbDirectorGender.SelectedValue = dt.Rows(0).Item("DirectorGender")
                    Catch ex As Exception
                        rdbDirectorGender.ClearSelection()
                    End Try
                    getDirectors(txtCustNo.Text)
                End If
            End Using
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- getCompaniesByName()", ex.ToString)
        End Try
    End Sub
End Class