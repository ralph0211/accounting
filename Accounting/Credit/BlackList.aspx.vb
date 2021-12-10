Imports System.Data
Imports System.Data.SqlClient
Imports CreditManager
Imports ErrorLogging

Partial Class QuestCredit_BlackList
    Inherits System.Web.UI.Page
    Public Shared grpMembersEditID As String
    Dim adp As SqlDataAdapter
    Dim cmd As SqlCommand
    Dim con As New SqlConnection
    Dim connection As String
    Protected Sub btnSaveName_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSaveName.Click
        Try
            If Trim(txtCustNo.Text) = "" Then
                notify("Select the client to blacklist", "error")
            ElseIf Trim(txtBlacklistReason.Text) = "" Then
                notify("Enter the reason for blacklisting", "error")
                txtBlacklistReason.Focus()
            ElseIf Trim(txtDateBlacklisted.Text) = "" Or Not IsDate(txtDateBlacklisted.Text) Then
                notify("Enter blacklist Date", "error")
                txtDateBlacklisted.Focus()
            Else
                'Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                '    Using cmd = New SqlCommand("update [CUSTOMER_DETAILS] set Blacklisted=1 where [CUSTOMER_NUMBER]=@CustNo", con)
                '        cmd.Parameters.AddWithValue("@CustNo", txtCustNo.Text)
                '        If con.State = ConnectionState.Open Then
                '            con.Close()
                '        End If
                '        con.Open()
                '        If cmd.ExecuteNonQuery() Then
                blacklistClient()
                '            notify("Client blacklisted", "success")
                '        Else
                '            notify("Error blacklisting client", "error")
                '        End If
                '        con.Close()
                '        clearAll()
                '        getNames()
                '        btnDeleteName.Visible = False
                '        grdNames.SelectedIndex = -1
                '    End Using
                'End Using
            End If
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- btnSaveName_Click()", ex.ToString)
        End Try
    End Sub

    Protected Function getEducation() As String
        If cmbEducation.SelectedValue = "Other" Then
            Return Trim("Other: " & BankString.removeSpecialCharacter(txtEducationOther.Text))
        Else
            Return cmbEducation.SelectedValue
        End If
    End Function

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Page.MaintainScrollPositionOnPostBack = True
        Page.ClientScript.RegisterOnSubmitStatement(Me.GetType, "val", "fnOnUpdateValidators();")
        con = New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
        If Not IsPostBack Then
            writeBranch()
            loadClientTypes()
            getNames()
            getFarmers()
            getGroups()
            loadBank()
            getPDACompanies()
        End If
    End Sub

    Protected Sub writeBranch()
        lblBranchCode.Text = Session("BRANCHCODE")
        lblBranchName.Text = Session("BRANCHNAME")
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

    Protected Sub rdbClientType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdbClientType.SelectedIndexChanged
        If rdbClientType.SelectedValue = "Individual" Then
            panIndividual.Visible = True
            panGroup.Visible = False
            pnlFarmers.Visible = False
            lblSurname.Text = "Surname"
            lblForenames.Text = "Forenames"
            lblForenames.Visible = True
            txtForenames.Visible = True
        ElseIf rdbClientType.SelectedValue = "Corporate" Or rdbClientType.SelectedValue = "Group" Then
            panIndividual.Visible = False
            panGroup.Visible = True
            pnlFarmers.Visible = False
            lblSurname.Text = "Name"
            lblForenames.Visible = False
            txtForenames.Visible = False
            txtForenames.Text = ""
        ElseIf rdbClientType.SelectedValue = "Farmer" Then
            panIndividual.Visible = False
            panGroup.Visible = False
            pnlFarmers.Visible = True
            lblSurname.Text = "Surname"
            lblForenames.Text = "Forenames"
            lblForenames.Visible = True
            txtForenames.Visible = True
        Else
            lblSurname.Text = "Surname"
            lblForenames.Text = "Forenames"
            lblForenames.Visible = True
            txtForenames.Visible = True
        End If
    End Sub

    Protected Sub getNames()
        Try
            cmd = New SqlCommand("select ID as [orderID], CUSTOMER_NUMBER as [ID],SURNAME,FORENAMES,ADDRESS from CUSTOMER_DETAILS where [CUSTOMER_TYPE]='Individual' and ([Blacklisted]=0 or [Blacklisted] is null) order by orderID DESC", con)
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
            msgbox(ex.Message)
        End Try
    End Sub

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
            msgbox(ex.Message)
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
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub getNamesBySurname(ByVal surname As String)
        Try
            cmd = New SqlCommand("select ID as [orderID], CUSTOMER_NUMBER as [ID],SURNAME,FORENAMES,ADDRESS from CUSTOMER_DETAILS where [CUSTOMER_TYPE]='Individual' and SURNAME + ' ' + FORENAMES like '" & surname & "%' and ([Blacklisted]=0 or [Blacklisted] is null) order by orderID DESC", con)
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
            msgbox(ex.Message)
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
            msgbox(ex.Message)
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
            msgbox(ex.Message)
        End Try
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

    Protected Sub getNamesForEdit(ByVal custID As String)
        Try
            cmd = New SqlCommand("select *,convert(varchar,DOB,106) as DOB1,convert(varchar,ISSUE_DATE,106) as ISSUE_DATE1 from CUSTOMER_DETAILS where CUSTOMER_NUMBER='" & custID & "'", con)
            Dim ds As New DataSet
            Dim adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "CUSTOMER")
            If ds.Tables(0).Rows.Count > 0 Then
                clearAll()
                Try
                    rdbClientType.SelectedValue = ds.Tables(0).Rows(0).Item("CUSTOMER_TYPE")
                Catch ex As Exception
                    rdbClientType.ClearSelection()
                End Try
                txtCustNo.Text = ds.Tables(0).Rows(0).Item("CUSTOMER_NUMBER")
                rdbClientType_SelectedIndexChanged(sender:=New Object, e:=New EventArgs)
                If ds.Tables(0).Rows(0).Item("CUSTOMER_TYPE") = "Group" Then
                    txtGrpName.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("SURNAME"))
                    'btnGrpAddGroup.Text = "Update Group Name"
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
                    'btnSaveFarmer.Text = "Update"
                    'btnDeleteFarmer.Visible = True
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
                    Try
                        rdbSubIndividual.SelectedValue = ds.Tables(0).Rows(0).Item("SUB_INDIVIDUAL")
                    Catch ex As Exception
                        rdbSubIndividual.ClearSelection()
                    End Try
                    rdbSubIndividual_SelectedIndexChanged(New Object, New EventArgs)
                    txtECNo.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("ECNO"))
                    txtECNoCD.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("CD"))
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
                            rdbSubIndividual.SelectedValue = ds.Tables(0).Rows(0).Item("SUB_INDIVIDUAL")
                        Catch ex As Exception
                            rdbSubIndividual.ClearSelection()
                        End Try
                    End If
                    'btnSaveName.Text = "Update"
                    'btnDeleteName.Visible = True

                End If
            Else
                btnSaveName.Text = "Save"
                btnDeleteName.Visible = False
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub btnDeleteName_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDeleteName.Click
        Try
            cmd = New SqlCommand("insert into CUSTOMER_DETAILS_AUDIT ([CUSTOMER_TYPE],[SUB_INDIVIDUAL],[CUSTOMER_NUMBER],[SURNAME],[FORENAMES],[DOB],[IDNO],[ISSUE_DATE],[ADDRESS],[CITY],[PHONE_NO],[NATIONALITY],[GENDER],[HOME_TYPE],[MONTHLY_RENT],[MARITAL_STATUS],[EDUCATION],[CURR_EMPLOYER],[CURR_EMP_ADD],[CURR_EMP_LENGTH],[CURR_EMP_PHONE],[CURR_EMP_EMAIL],[CURR_EMP_FAX],[CURR_EMP_CITY],[CURR_EMP_POSITION],[CURR_EMP_SALARY],[CURR_EMP_NET],[CURR_EMP_INCOME],[PREV_EMPLOYER],[PREV_EMP_ADD],[PREV_EMP_LENGTH],[PREV_EMP_PHONE],[PREV_EMP_EMAIL],[PREV_EMP_FAX],[PREV_EMP_CITY],[PREV_EMP_POSITION],[PREV_EMP_SALARY],[PREV_EMP_NET],[PREV_EMP_INCOME],[SPOUSE_NAME],[SPOUSE_OCCUPATION],[SPOUSE_EMPLOYER],[NO_CHILDREN],[NO_DEPENDANTS],[TRADE_REF1],[TRADE_REF2],[CREATED_BY],[CREATED_DATE],[MODIFIED_BY],[MODIFIED_DATE],[SPOUSE_PHONE],[BRANCH_CODE],[BRANCH_NAME],[AREA],[TRAN_TYPE],[AUTHORIZED]) values ('" & rdbClientType.SelectedValue & "','" & rdbSubIndividual.SelectedValue & "','" & txtCustNo.Text & "','" & BankString.removeSpecialCharacter(txtSurname.Text) & "','" & BankString.removeSpecialCharacter(txtForenames.Text) & "','" & bdpDOB.Text & "','" & txtIDNo.Text & "','" & bdpIssDate.Text & "','" & BankString.removeSpecialCharacter(txtAddress.Text) & "','" & BankString.removeSpecialCharacter(txtCity.Text) & "','" & txtPhoneNo.Text & "','" & BankString.removeSpecialCharacter(txtNationality.Text) & "','" & rdbGender.SelectedValue & "','" & rdbHouse.SelectedValue & "','" & txtRent.Text & "','" & cmbMaritalStatus.SelectedValue & "','" & getEducation() & "','" & BankString.removeSpecialCharacter(txtCurrEmployer.Text) & "','" & BankString.removeSpecialCharacter(txtEmpAddress.Text) & "',NULLIF('" & txtEmpHowLong.Text & "',''),'" & txtEmpPhone.Text & "','" & txtEmpEmail.Text & "','" & txtEmpFax.Text & "','" & BankString.removeSpecialCharacter(txtEmpCity.Text) & "','" & BankString.removeSpecialCharacter(txtEmpPosition.Text) & "',NULLIF('" & txtEmpSalary.Text & "',''),NULLIF('" & txtEmpSalaryNet.Text & "',''),NULLIF('" & txtEmpOtherIncome.Text & "',''),'" & BankString.removeSpecialCharacter(txtPrevEmployer.Text) & "','" & BankString.removeSpecialCharacter(txtPrevEmpAddress.Text) & "',NULLIF('" & txtPrevEmpHowLong.Text & "',''),'" & txtPrevEmpPhone.Text & "','" & txtPrevEmpEmail.Text & "','" & txtPrevEmpFax.Text & "','" & BankString.removeSpecialCharacter(txtPrevEmpCity.Text) & "','" & BankString.removeSpecialCharacter(txtPrevEmpPosition.Text) & "',NULLIF('" & txtPrevEmpSalary.Text & "',''),NULLIF('" & txtPrevEmpSalaryNet.Text & "',''),NULLIF('" & txtPrevEmpAnnualIncome.Text & "',''),'" & BankString.removeSpecialCharacter(txtSpouse.Text) & "','" & BankString.removeSpecialCharacter(txtSpouseOccupation.Text) & "','" & BankString.removeSpecialCharacter(txtSpouseEmployer.Text) & "',NULLIF('" & txtNoChildren.Text & "',''),NULLIF('" & txtNoDependant.Text & "',''),'" & txtTradeRef1.Text & "','" & txtTradeRef2.Text & "','" & Session("UserID") & "',getdate(),'','','" & txtSpousePhone.Text & "','" & lblBranchCode.Text & "','" & BankString.removeSpecialCharacter(lblBranchName.Text) & "','" & cmbArea.SelectedValue & "','DELETE',0)", con)
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            con.Open()
            If cmd.ExecuteNonQuery Then
                msgbox("Name successfully marked for deletion. Authorization pending.")
                getNames()
                clearAll()
                btnSaveName.Text = "Save"
                btnDeleteName.Visible = False
            Else
                msgbox("Error deleting name")
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub btnSearchSurname_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearchSurname.Click
        getNamesBySurname(txtSearchSurname.Text)
    End Sub

    Protected Function generateCustNum() As String
        Try
            Dim custNo As String
            cmd = New SqlCommand("select isnull(max(isnull(convert(numeric, nullif(substring(CUSTOMER_NUMBER,5,10),'')),0)),0) from CUSTOMER_DETAILS where CUSTOMER_NUMBER like '213/%' and ISNUMERIC(substring(CUSTOMER_NUMBER,5,10))=1", con)
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            con.Open()
            custNo = cmd.ExecuteScalar() + 1
            con.Close()
            If IsDBNull(custNo) Or custNo = 0 Then
                custNo = 1000
            End If
            Return "213/" & custNo
        Catch ex As Exception
            msgbox(ex.Message)
            Return 1
        End Try
    End Function

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

   
    Protected Sub btnGrpAddGroup_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGrpAddGroup.Click
        Try
            If Trim(txtCustNo.Text) = "" Then
                notify("Select the client to blacklist", "error")
            Else
                Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                    Using cmd = New SqlCommand("update [CUSTOMER_DETAILS] set Blacklisted=1 where [CUSTOMER_NUMBER]=@CustNo", con)
                        cmd.Parameters.AddWithValue("@CustNo", txtCustNo.Text)
                        If con.State = ConnectionState.Open Then
                            con.Close()
                        End If
                        con.Open()
                        If cmd.ExecuteNonQuery() Then
                            blacklistClient()
                            notify("Client blacklisted", "success")
                        Else
                            notify("Error blacklisting client", "error")
                        End If
                        con.Close()
                        clearAll()
                        getNames()
                        btnDeleteName.Visible = False
                        grdNames.SelectedIndex = -1
                    End Using
                End Using
            End If
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- btnSaveName_Click()", ex.ToString)
        End Try
    End Sub

    Protected Function isUniqueCustNo(CustNo As String) As Boolean
        cmd = New SqlCommand("select * from CUSTOMER_DETAILS where CUSTOMER_NUMBER='" & CustNo & "'", con)
        Dim ds As New DataSet
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "CD")
        If ds.Tables(0).Rows.Count > 0 Then
            Return False
        Else
            Return True
        End If
    End Function

    Protected Sub btnGrpDeclAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGrpDeclAdd.Click
        Try
            Dim cmd1 = New SqlCommand("insert into QUEST_GROUP_MEMBERS (CUSTOMER_NUMBER,POSITION,NAME,IDNO,ISSUE_DATE,DOB,ADDRESS,CITY,PHONE,NATIONALITY,GENDER) values ('" & txtCustNo.Text & "','" & cmbGrpDeclPosition.SelectedValue & "','" & BankString.removeSpecialCharacter(txtGrpDeclName.Text) & "','" & txtGrpDeclIDNo.Text & "','" & bdpGrpIssDate.Text & "','" & bdpGrpDOB.Text & "','" & txtGrpDeclAddress.Text & "','" & txtGrpDeclCity.Text & "','" & txtGrpDeclPhoneNo.Text & "','" & txtGrpDeclNationality.Text & "','" & rdbGrpGender.SelectedValue & "')", con)
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            'msgbox(cmd.CommandText)
            con.Open()
            If isUniqueCustNo(txtCustNo.Text) Then
                ClientScript.RegisterStartupScript(Me.GetType(), "Gritter", "<script type=""text/javascript"">$.gritter.add({title: 'Invalid Group Customer Number!',text: 'The entered Customer Number does not exist. Please verify that you have created the group.',image: 'images/error_button.png'});</script>")
            Else
                If cmd1.ExecuteNonQuery Then
                    'lblGrpDeclMemberAdded.Text = "Group member added"
                    getGrpMembers(txtCustNo.Text)
                    loadGrpMembers(txtCustNo.Text)
                    clearGrpMemberInfo()
                    ClientScript.RegisterStartupScript(Me.GetType(), "Gritter", "<script type=""text/javascript"">$.gritter.add({title: 'Member added Successfully!',text: 'The group member has been successfully added.',image: 'images/thumbs3.jpg'});</script>")
                Else
                    ClientScript.RegisterStartupScript(Me.GetType(), "Gritter", "<script type=""text/javascript"">$.gritter.add({title: 'Duplicate Customer Number!',text: 'The requested Customer Number already exists.',image: 'images/error_button.png'});</script>")
                End If
            End If
            con.Close()
        Catch ex As Exception

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

    Protected Sub getGrpMembers(grpNo As String)
        Try
            cmd = New SqlCommand("select * from QUEST_GROUP_MEMBERS where CUSTOMER_NUMBER='" & grpNo & "'", con)
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

    Protected Sub getGrpMemberExpenses(grpNo As String)
        Try
            cmd = New SqlCommand("select ID,POSITION,NAME,IDNO,RENT,FOOD,FEES,AIRTIME,MEDICAL,ELECTRICITY,WATER,RATES,CITY_OF_HRE as [CITY OF HARARE] from QUEST_GROUP_MEMBERS where CUSTOMER_NUMBER='" & grpNo & "'", con)
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

    Protected Sub btnGrpDeclAddExpense_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGrpDeclAddExpense.Click
        Try
            cmd = New SqlCommand("update QUEST_GROUP_MEMBERS set RENT='" & txtGrpDeclRent.Text & "',FOOD='" & txtGrpDeclFood.Text & "',FEES='" & txtGrpDeclFees.Text & "',AIRTIME='" & txtGrpDeclAirtime.Text & "',MEDICAL='" & txtGrpDeclMedical.Text & "',ELECTRICITY='" & txtGrpDeclElectricity.Text & "',WATER='" & txtGrpDeclWater.Text & "',RATES='" & txtGrpDeclRates.Text & "',CITY_OF_HRE='" & txtGrpDeclCityOfHre.Text & "' where ID='" & cmbGrpDeclMember.SelectedValue & "'", con)
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            con.Open()
            If cmd.ExecuteNonQuery Then
                'lblGrpExpense.Text = "Member expenses added"
                ClientScript.RegisterStartupScript(Me.GetType(), "Gritter", "<script type=""text/javascript"">$.gritter.add({title: 'Member expenses added Successfully!',text: 'The group member expenses have been successfully added.',image: 'images/thumbs3.jpg'});</script>")
                getGrpMemberExpenses(txtCustNo.Text)
                clearGrpExpense()
            Else
                ClientScript.RegisterStartupScript(Me.GetType(), "Gritter", "<script type=""text/javascript"">$.gritter.add({title: 'Failed to save expenses!',text: 'The group member expenses could not be saved at this moment. Please try again later.',image: 'images/error1.jpg'});</script>")
            End If
        Catch ex As Exception

        End Try
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

    Protected Sub txtIDNo_TextChanged(sender As Object, e As EventArgs) Handles txtIDNo.TextChanged
        If IDNoAlreadyExists(txtIDNo.Text) Then
            lblIDError.Text = "ID Number already registered"
            txtIDNo.CssClass = "col-xs-12 form-control input-sm tb_with_border"
        Else
            lblIDError.Text = ""
            txtIDNo.CssClass = "col-xs-12 form-control input-sm tb_without_border"
        End If
    End Sub

    Protected Sub btnSaveFarmer_Click(sender As Object, e As EventArgs) Handles btnSaveFarmer.Click
        Try
            If Trim(txtCustNo.Text) = "" Then
                notify("Select the client to blacklist", "error")
            ElseIf Trim(txtBlacklistReason.Text) = "" Then
                notify("Enter the reason for blacklisting this client", "error")
                txtBlacklistReason.Focus()
            ElseIf Trim(txtDateBlacklisted.Text) = "" Then
                notify("Enter the date when client was blacklisted", "error")
                txtDateBlacklisted.Focus()
            Else
                Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                    Using cmd = New SqlCommand("update [CUSTOMER_DETAILS] set Blacklisted=1,BlacklistReason=@Reason,BlacklistDate=@BlacklistDate where [CUSTOMER_NUMBER]=@CustNo", con)
                        cmd.Parameters.AddWithValue("@CustNo", txtCustNo.Text)
                        cmd.Parameters.AddWithValue("@Reason", txtBlacklistReason.Text)
                        cmd.Parameters.AddWithValue("@BlacklistDate", txtDateBlacklisted.Text)
                        If con.State = ConnectionState.Open Then
                            con.Close()
                        End If
                        con.Open()
                        If cmd.ExecuteNonQuery() Then
                            blacklistClient()
                            notify("Client blacklisted", "success")
                        Else
                            notify("Error blacklisting client", "error")
                        End If
                        con.Close()
                        clearAll()
                        getFarmers()
                        btnDeleteFarmer.Visible = False
                        grdFarmers.SelectedIndex = -1
                        rdbClientType_SelectedIndexChanged(sender, New EventArgs)
                    End Using
                End Using
            End If
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- btnSaveFarmer_Click()", ex.ToString)
        End Try
    End Sub

    Protected Sub blacklistClient()
        Try
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd = New SqlCommand("insert into Blacklist (CustNo,Surname,Forenames,Blacklisted,BlacklistDate,BlacklistedBy,BlacklistTimeStamp,BlacklistReason) values (@CustNo,@Surname,@Forenames,1,@BlacklistDate,@BlacklistedBy,GETDATE(),@Reason)", con)
                    Dim surname = "", forenames = ""
                    If rdbClientType.SelectedValue = "Individual" Then
                        surname = txtSurname.Text
                        forenames = txtForenames.Text
                    ElseIf rdbClientType.SelectedValue = "Corporate" Or rdbClientType.SelectedValue = "Group" Then
                        surname = txtGrpName.Text
                    ElseIf rdbClientType.SelectedValue = "Farmer" Then
                        surname = txtFarmNameOfGroup.Text
                        forenames = txtFarmNameOfApplicant.Text
                    Else
                        surname = txtSurname.Text
                        forenames = txtForenames.Text
                    End If
                    cmd.Parameters.AddWithValue("@CustNo", txtCustNo.Text)
                    cmd.Parameters.AddWithValue("@Surname", surname)
                    cmd.Parameters.AddWithValue("@Forenames", forenames)
                    cmd.Parameters.AddWithValue("@BlacklistedBy", Session("UserId"))
                    cmd.Parameters.AddWithValue("@Reason", txtBlacklistReason.Text)
                    cmd.Parameters.AddWithValue("@BlacklistDate", txtDateBlacklisted.Text)
                    con.Open()
                    If cmd.ExecuteNonQuery() Then
                        notify("Client blacklisted. Authorization pending", "success")
                        clearAll()
                        grdNames.SelectedIndex = -1
                        txtDateBlacklisted.Text = ""
                        txtBlacklistReason.Text = ""
                        getNames()
                    Else
                        notify("Error blacklisting client", "error")
                    End If
                    con.Close()
                End Using
            End Using
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- blacklistClient()", ex.ToString)
        End Try
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
            msgbox("Member successfully deleted.")
        Else
            msgbox("Error deleting member")
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

    Protected Sub cmbEducation_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbEducation.SelectedIndexChanged
        If cmbEducation.SelectedValue = "Other" Then
            txtEducationOther.Visible = True
        Else
            txtEducationOther.Visible = False
        End If
        txtEducationOther.Text = ""
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

    Protected Sub grdFarmers_SelectedIndexChanged(sender As Object, e As EventArgs) Handles grdFarmers.SelectedIndexChanged
        getNamesForEdit(grdFarmers.SelectedRow.Cells(1).Text)
    End Sub

    Protected Sub grdGroup_SelectedIndexChanged(sender As Object, e As EventArgs) Handles grdGroup.SelectedIndexChanged
        getNamesForEdit(grdGroup.SelectedRow.Cells(1).Text)
    End Sub

    Protected Sub rdbSubIndividual_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rdbSubIndividual.SelectedIndexChanged
        applicantTypeSelector(rdbSubIndividual.SelectedValue)
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

    Protected Sub loadBank()
        Try
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd As New SqlCommand("select distinct bank, bank_name from para_bank order by bank", con)
                    Dim dss As New DataSet
                    Dim adp = New SqlDataAdapter(cmd)
                    adp.Fill(dss, "para_bank")
                    loadCombo(dss.Tables(0), cmbBankAppType, "bank_name", "bank")
                End Using
            End Using
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " - loadBank()", ex.Message)
        End Try
    End Sub

    Protected Sub loadBranch(bnk As String)
        Try
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd = New SqlCommand("SELECT bank, branch, branch_name FROM para_branch where bank='" & bnk & "'", con)
                    Dim ds As New DataSet
                    Dim adp = New SqlDataAdapter(cmd)
                    adp.Fill(ds, "para_branch")
                    loadCombo(ds.Tables(0), cmbBranchAppType, "branch_name", "branch")
                End Using
            End Using
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " - loadBranch()", ex.Message)
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
            WriteLogFile(Session("UserId"), Request.Url.ToString & " - getPDACompanies()", ex.Message)
        End Try
    End Sub

    Protected Sub cmbBankAppType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbBankAppType.SelectedIndexChanged
        loadBranch(cmbBankAppType.SelectedValue)
    End Sub
End Class