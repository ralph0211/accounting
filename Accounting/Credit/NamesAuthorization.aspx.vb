Imports System.Data
Imports System.Data.SqlClient
Imports CreditManager
Imports ErrorLogging

Partial Class Credit_NamesAuthorization
    Inherits System.Web.UI.Page
    Public Shared auditID As Double
    Public Shared requestTranType As String
    Dim adp As SqlDataAdapter
    Dim cmd As SqlCommand
    Dim con As New SqlConnection
    Dim connection As String
    Public Sub msgbox(ByVal strMessage As String)

        'finishes server processing, returns to client.
        Dim strScript As String = "<script language=JavaScript>"
        strScript += "window.alert(""" & strMessage & """);"
        strScript += "</script>"
        Dim lbl As New System.Web.UI.WebControls.Label
        lbl.Text = strScript
        Page.Controls.Add(lbl)
    End Sub

    Protected Sub btnAuthorize_Click(sender As Object, e As EventArgs) Handles btnAuthorize.Click
        Try
            Dim outNewCustNo = 0
            If requestTranType = "INSERT" Then
                Dim newCustNo = generateCustNum() + 1
                outNewCustNo = newCustNo
                cmd = New SqlCommand("insert into CUSTOMER_DETAILS ([Sector],[CUSTOMER_TYPE],[SUB_INDIVIDUAL],[CUSTOMER_NUMBER],[SURNAME],[FORENAMES],[DOB],[IDNO],[ISSUE_DATE],[ADDRESS],[CITY],[PHONE_NO],[NATIONALITY],[GENDER],[HOME_TYPE],[MONTHLY_RENT],[HOME_LENGTH],[MARITAL_STATUS],[EDUCATION],[CURR_EMPLOYER],[CURR_EMP_ADD],[CURR_EMP_LENGTH],[CURR_EMP_PHONE],[CURR_EMP_EMAIL],[CURR_EMP_FAX],[CURR_EMP_CITY],[CURR_EMP_POSITION],[CURR_EMP_SALARY],[CURR_EMP_NET],[CURR_EMP_INCOME],[PREV_EMPLOYER],[PREV_EMP_ADD],[PREV_EMP_LENGTH],[PREV_EMP_PHONE],[PREV_EMP_EMAIL],[PREV_EMP_FAX],[PREV_EMP_CITY],[PREV_EMP_POSITION],[PREV_EMP_SALARY],[PREV_EMP_NET],[PREV_EMP_INCOME],[SPOUSE_NAME],[SPOUSE_OCCUPATION],[SPOUSE_EMPLOYER],[NO_CHILDREN],[NO_DEPENDANTS],[TRADE_REF1],[TRADE_REF2],[CREATED_BY],[CREATED_DATE],[SPOUSE_PHONE],[CREDIT_LIMIT],[HAS_ACCOUNT],[ACCOUNT_BRANCH],[ACCOUNT_NUMBER],[BRANCH_CODE],[BRANCH_NAME],[AREA],[ECNO],[CD],PhotoName,PDACode,AppTypeBank,AppTypeBranch,AppTypeOtherDesc) SELECT [Sector],[CUSTOMER_TYPE],[SUB_INDIVIDUAL]," & outNewCustNo & ",[SURNAME],[FORENAMES],[DOB],[IDNO],[ISSUE_DATE],[ADDRESS],[CITY],[PHONE_NO],[NATIONALITY],[GENDER],[HOME_TYPE],[MONTHLY_RENT],[HOME_LENGTH],[MARITAL_STATUS],[EDUCATION],[CURR_EMPLOYER],[CURR_EMP_ADD],[CURR_EMP_LENGTH],[CURR_EMP_PHONE],[CURR_EMP_EMAIL],[CURR_EMP_FAX],[CURR_EMP_CITY],[CURR_EMP_POSITION],[CURR_EMP_SALARY],[CURR_EMP_NET],[CURR_EMP_INCOME],[PREV_EMPLOYER],[PREV_EMP_ADD],[PREV_EMP_LENGTH],[PREV_EMP_PHONE],[PREV_EMP_EMAIL],[PREV_EMP_FAX],[PREV_EMP_CITY],[PREV_EMP_POSITION],[PREV_EMP_SALARY],[PREV_EMP_NET],[PREV_EMP_INCOME],[SPOUSE_NAME],[SPOUSE_OCCUPATION],[SPOUSE_EMPLOYER],[NO_CHILDREN],[NO_DEPENDANTS],[TRADE_REF1],[TRADE_REF2],[CREATED_BY],[CREATED_DATE],[SPOUSE_PHONE],[CREDIT_LIMIT],[HAS_ACCOUNT],[ACCOUNT_BRANCH],[ACCOUNT_NUMBER],[BRANCH_CODE],[BRANCH_NAME],[AREA],[ECNO],[CD],PhotoName,PDACode,AppTypeBank,AppTypeBranch,AppTypeOtherDesc FROM CUSTOMER_DETAILS_AUDIT where ID='" & auditID & "'", con)
            ElseIf requestTranType = "UPDATE" Then
                Dim cmdText As String = "UPDATE CUSTOMER_DETAILS SET CUSTOMER_DETAILS.ACCOUNT_BRANCH= CUSTOMER_DETAILS_AUDIT.ACCOUNT_BRANCH, customer_Details.ACCOUNT_NUMBER = CUSTOMER_DETAILS_AUDIT.ACCOUNT_NUMBER, CUSTOMER_DETAILS.ADDRESS= CUSTOMER_DETAILS_AUDIT.ADDRESS,"
                cmdText = cmdText & "customer_Details.AREA = CUSTOMER_DETAILS_AUDIT.AREA, CUSTOMER_DETAILS.BRANCH_CODE= CUSTOMER_DETAILS_AUDIT.BRANCH_CODE, customer_Details.BRANCH_NAME = CUSTOMER_DETAILS_AUDIT.BRANCH_NAME, CUSTOMER_DETAILS.CITY= CUSTOMER_DETAILS_AUDIT.CITY, customer_Details.CREDIT_LIMIT = CUSTOMER_DETAILS_AUDIT.CREDIT_LIMIT,"
                cmdText = cmdText & "CUSTOMER_DETAILS.CURR_EMP_ADD= CUSTOMER_DETAILS_AUDIT.CURR_EMP_ADD, customer_Details.CURR_EMP_CITY = CUSTOMER_DETAILS_AUDIT.CURR_EMP_CITY, CUSTOMER_DETAILS.CURR_EMP_EMAIL= CUSTOMER_DETAILS_AUDIT.CURR_EMP_EMAIL, customer_Details.CURR_EMP_FAX = CUSTOMER_DETAILS_AUDIT.CURR_EMP_FAX, CUSTOMER_DETAILS.CURR_EMP_INCOME= CUSTOMER_DETAILS_AUDIT.CURR_EMP_INCOME,"
                cmdText = cmdText & "customer_Details.CURR_EMP_LENGTH = CUSTOMER_DETAILS_AUDIT.CURR_EMP_LENGTH, CUSTOMER_DETAILS.CURR_EMP_NET= CUSTOMER_DETAILS_AUDIT.CURR_EMP_NET, customer_Details.CURR_EMP_PHONE = CUSTOMER_DETAILS_AUDIT.CURR_EMP_PHONE, CUSTOMER_DETAILS.CURR_EMP_POSITION= CUSTOMER_DETAILS_AUDIT.CURR_EMP_POSITION, customer_Details.CURR_EMP_SALARY = CUSTOMER_DETAILS_AUDIT.CURR_EMP_SALARY, CUSTOMER_DETAILS.CURR_EMPLOYER= CUSTOMER_DETAILS_AUDIT.CURR_EMPLOYER,CUSTOMER_DETAILS.Bank=CUSTOMER_DETAILS_AUDIT.Bank, CUSTOMER_DETAILS.BankBranch=CUSTOMER_DETAILS_AUDIT.BankBranch, CUSTOMER_DETAILS.BankAccountNo=CUSTOMER_DETAILS_AUDIT.BankAccountNo,"
                cmdText = cmdText & "customer_Details.CUSTOMER_NUMBER = CUSTOMER_DETAILS_AUDIT.CUSTOMER_NUMBER, CUSTOMER_DETAILS.CUSTOMER_TYPE= CUSTOMER_DETAILS_AUDIT.CUSTOMER_TYPE, customer_Details.DOB = CUSTOMER_DETAILS_AUDIT.DOB, CUSTOMER_DETAILS.EDUCATION= CUSTOMER_DETAILS_AUDIT.EDUCATION, customer_Details.FORENAMES = CUSTOMER_DETAILS_AUDIT.FORENAMES, CUSTOMER_DETAILS.GENDER= CUSTOMER_DETAILS_AUDIT.GENDER, customer_Details.HAS_ACCOUNT = CUSTOMER_DETAILS_AUDIT.HAS_ACCOUNT,"
                cmdText = cmdText & "CUSTOMER_DETAILS.HOME_LENGTH= CUSTOMER_DETAILS_AUDIT.HOME_LENGTH, customer_Details.HOME_TYPE = CUSTOMER_DETAILS_AUDIT.HOME_TYPE, CUSTOMER_DETAILS.IDNO= CUSTOMER_DETAILS_AUDIT.IDNO, customer_Details.ISSUE_DATE = CUSTOMER_DETAILS_AUDIT.ISSUE_DATE, CUSTOMER_DETAILS.MARITAL_STATUS= CUSTOMER_DETAILS_AUDIT.MARITAL_STATUS, customer_Details.MONTHLY_RENT = CUSTOMER_DETAILS_AUDIT.MONTHLY_RENT, CUSTOMER_DETAILS.NATIONALITY= CUSTOMER_DETAILS_AUDIT.NATIONALITY,CUSTOMER_DETAILS.[ECNO]=CUSTOMER_DETAILS_AUDIT.[ECNO],CUSTOMER_DETAILS.[CD]=CUSTOMER_DETAILS_AUDIT.[CD],"
                cmdText = cmdText & "CUSTOMER_DETAILS.NO_CHILDREN= CUSTOMER_DETAILS_AUDIT.NO_CHILDREN, customer_Details.NO_DEPENDANTS = CUSTOMER_DETAILS_AUDIT.NO_DEPENDANTS, CUSTOMER_DETAILS.PHONE_NO= CUSTOMER_DETAILS_AUDIT.PHONE_NO, customer_Details.PREV_EMP_ADD = CUSTOMER_DETAILS_AUDIT.PREV_EMP_ADD, CUSTOMER_DETAILS.PREV_EMP_CITY= CUSTOMER_DETAILS_AUDIT.PREV_EMP_CITY, customer_Details.PREV_EMP_EMAIL = CUSTOMER_DETAILS_AUDIT.PREV_EMP_EMAIL, CUSTOMER_DETAILS.PREV_EMP_FAX= CUSTOMER_DETAILS_AUDIT.PREV_EMP_FAX,"
                cmdText = cmdText & "customer_Details.PREV_EMP_INCOME = CUSTOMER_DETAILS_AUDIT.PREV_EMP_INCOME, CUSTOMER_DETAILS.PREV_EMP_LENGTH= CUSTOMER_DETAILS_AUDIT.PREV_EMP_LENGTH, customer_Details.PREV_EMP_NET = CUSTOMER_DETAILS_AUDIT.PREV_EMP_NET, CUSTOMER_DETAILS.PREV_EMP_PHONE= CUSTOMER_DETAILS_AUDIT.PREV_EMP_PHONE, customer_Details.PREV_EMP_POSITION = CUSTOMER_DETAILS_AUDIT.PREV_EMP_POSITION, CUSTOMER_DETAILS.PREV_EMP_SALARY= CUSTOMER_DETAILS_AUDIT.PREV_EMP_SALARY, customer_Details.PREV_EMPLOYER = CUSTOMER_DETAILS_AUDIT.PREV_EMPLOYER,"
                cmdText = cmdText & "CUSTOMER_DETAILS.SPOUSE_EMPLOYER= CUSTOMER_DETAILS_AUDIT.SPOUSE_EMPLOYER, customer_Details.SPOUSE_NAME = CUSTOMER_DETAILS_AUDIT.SPOUSE_NAME, CUSTOMER_DETAILS.SPOUSE_OCCUPATION= CUSTOMER_DETAILS_AUDIT.SPOUSE_OCCUPATION, customer_Details.SPOUSE_PHONE = CUSTOMER_DETAILS_AUDIT.SPOUSE_PHONE, CUSTOMER_DETAILS.SUB_INDIVIDUAL= CUSTOMER_DETAILS_AUDIT.SUB_INDIVIDUAL, customer_Details.SURNAME = CUSTOMER_DETAILS_AUDIT.SURNAME, CUSTOMER_DETAILS.TRADE_REF1= CUSTOMER_DETAILS_AUDIT.TRADE_REF1, customer_Details.TRADE_REF2 = CUSTOMER_DETAILS_AUDIT.TRADE_REF2,"
                cmdText = cmdText & "CUSTOMER_DETAILS.Sector= CUSTOMER_DETAILS_AUDIT.Sector, customer_Details.PDACode = CUSTOMER_DETAILS_AUDIT.PDACode, CUSTOMER_DETAILS.AppTypeBank= CUSTOMER_DETAILS_AUDIT.AppTypeBank, customer_Details.AppTypeBranch = CUSTOMER_DETAILS_AUDIT.AppTypeBranch, CUSTOMER_DETAILS.AppTypeOtherDesc= CUSTOMER_DETAILS_AUDIT.AppTypeOtherDesc, customer_Details.PhotoName = CUSTOMER_DETAILS_AUDIT.PhotoName,"
                cmdText = cmdText & "CUSTOMER_DETAILS.GUARANTOR_REL_NAME= CUSTOMER_DETAILS_AUDIT.GUARANTOR_REL_NAME,CUSTOMER_DETAILS.GUARANTOR_REL_ADD= CUSTOMER_DETAILS_AUDIT.GUARANTOR_REL_ADD,CUSTOMER_DETAILS.GUARANTOR_REL_CITY= CUSTOMER_DETAILS_AUDIT.GUARANTOR_REL_CITY,CUSTOMER_DETAILS.GUARANTOR_REL_PHONE= CUSTOMER_DETAILS_AUDIT.GUARANTOR_REL_PHONE,CUSTOMER_DETAILS.GUARANTOR_REL_RELTNSHP= CUSTOMER_DETAILS_AUDIT.GUARANTOR_REL_RELTNSHP "
                cmdText = cmdText & " FROM CUSTOMER_DETAILS INNER JOIN CUSTOMER_DETAILS_AUDIT ON CUSTOMER_DETAILS.CUSTOMER_NUMBER = CUSTOMER_DETAILS_AUDIT.CUSTOMER_NUMBER WHERE CUSTOMER_DETAILS_AUDIT.ID='" & auditID & "'"
                cmd = New SqlCommand(cmdText, con)

                'Dim strScript As String = "<script language=JavaScript>"
                'strScript += "window.alert(""" & cmdText & """);"
                'strScript += "</script>"
                'ScriptManager.RegisterAsyncPostBackContro
            ElseIf requestTranType = "DELETE" Then
                cmd = New SqlCommand("update CUSTOMER_DETAILS set DELETED=1 where CUSTOMER_NUMBER='" & txtCustNo.Text & "'", con)
            End If
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            con.Open()
            If cmd.ExecuteNonQuery() Then
                grdAuthorization.SelectedIndex = -1
                'grdAuthorization.DataSource = AuthorizationsDS
                'grdAuthorization.DataBind()
                If requestTranType = "INSERT" Then
                    'ClientScript.RegisterStartupScript(Me.GetType, "alerttt", msgbox("Saved successfully. New customer number is " & outNewCustNo & ""))
                    notify("Saved successfully. New customer number is " & outNewCustNo & "", "success")
                ElseIf requestTranType = "UPDATE" Then
                    notify("Updated successfully.", "success")
                ElseIf requestTranType = "DELETE" Then
                    notify("Deleted successfully", "success")
                End If
                cmd = New SqlCommand("update CUSTOMER_DETAILS_AUDIT set AUTHORIZED=1,AUTHORIZE_DATE=GETDATE(),PERFORMED_BY='" & Session("UserID") & "' where ID='" & auditID & "'", con)
                cmd.ExecuteNonQuery()
                'clearAll()
                ''getAuthorizations()
                'grdAuthorization.DataSource = AuthorizationsDS
                'grdAuthorization.DataBind()
            Else
                notify("Error saving name", "error")
            End If
            con.Close()
            clearAll()
            'getAuthorizations()
            grdAuthorization.SelectedIndex = -1
            'grdAuthorization.DataSource = AuthorizationsDS
            grdAuthorization.DataBind()
            'getCreditLimit(rdbClientType.SelectedValue, "all")
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub btnDiscard_Click(sender As Object, e As EventArgs) Handles btnDiscard.Click
        Try
            cmd = New SqlCommand("update CUSTOMER_DETAILS_AUDIT set DISCARDED=1,DISCARD_DATE=GETDATE(),PERFORMED_BY='" & Session("UserID") & "' where ID='" & auditID & "'", con)
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            con.Open()
            If cmd.ExecuteNonQuery Then
                grdAuthorization.SelectedIndex = -1
                'grdAuthorization.DataSource = AuthorizationsDS
                grdAuthorization.DataBind()
                clearAll()
                msgbox("Record successfully discarded")
            Else
                msgbox("Error discarding record")
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub btnGrpAddGroup_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGrpAddGroup.Click
        Try
            If isUniqueCustNo(txtCustNo.Text) Then
                cmd = New SqlCommand("insert into CUSTOMER_DETAILS ([CUSTOMER_TYPE],[CUSTOMER_NUMBER],[SURNAME],[BRANCH_CODE],[BRANCH_NAME]) values ('" & rdbClientType.SelectedValue & "','" & txtCustNo.Text & "','" & BankString.removeSpecialCharacter(txtGrpName.Text) & "','" & lblBranchCode.Text & "','" & BankString.removeSpecialCharacter(lblBranchName.Text) & "')", con)
                If con.State = ConnectionState.Open Then
                    con.Close()
                End If
                con.Open()
                If cmd.ExecuteNonQuery Then
                    'lblGrpAdded.Text = "Group successfully added. You can capture the member details"
                    ClientScript.RegisterStartupScript(Me.GetType(), "Gritter", "<script type=""text/javascript"">$.gritter.add({title: 'Group added Successfully!',text: 'The group has been successfully added. Now you can capture the member details',image: 'images/thumbs3.jpg'});</script>")
                Else
                    'lblGrpAdded.Text = "Error adding group"
                    ClientScript.RegisterStartupScript(Me.GetType(), "Gritter", "<script type=""text/javascript"">$.gritter.add({title: 'Save Failure!',text: 'There was an error adding the group. Please try again later.',image: 'images/error_button.png'});</script>")
                End If
            Else
                ClientScript.RegisterStartupScript(Me.GetType(), "Gritter", "<script type=""text/javascript"">$.gritter.add({title: 'Duplicate Customer Number!',text: 'The requested Customer Number already exists. Try again with a new customer number.',image: 'images/error_button.png'});</script>")
            End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnGrpDeclAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGrpDeclAdd.Click
        Try
            Dim cmd1 = New SqlCommand("insert into QUEST_GROUP_MEMBERS (CUSTOMER_NUMBER,POSITION,NAME,IDNO) values ('" & txtCustNo.Text & "','" & cmbGrpDeclPosition.SelectedValue & "','" & BankString.removeSpecialCharacter(txtGrpDeclName.Text) & "','" & txtGrpDeclIDNo.Text & "')", con)
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
                    getGrpMembers()
                    loadGrpMembers()
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
                getGrpMemberExpenses()
                clearGrpExpense()
            Else
                ClientScript.RegisterStartupScript(Me.GetType(), "Gritter", "<script type=""text/javascript"">$.gritter.add({title: 'Failed to save expenses!',text: 'The group member expenses could not be saved at this moment. Please try again later.',image: 'images/error1.jpg'});</script>")
            End If
        Catch ex As Exception

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
            ' txtHouseHowLong.Text = ""
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
    End Sub

    Protected Function convertToSaveDecimal(ByVal str As String) As String
        Try
            Dim dbl As String
            dbl = str.Replace(",", ".")
            Return dbl
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Protected Function generateCustNum() As String
        Try
            Dim custNo As String
            cmd = New SqlCommand("select isnull(max(isnull(convert(numeric, CUSTOMER_NUMBER),0)),0) from CUSTOMER_DETAILS", con)
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            con.Open()
            custNo = cmd.ExecuteScalar()
            con.Close()
            If IsDBNull(custNo) Or custNo = 0 Then
                custNo = 1000
            End If
            Return custNo
        Catch ex As Exception
            msgbox(ex.Message)
            Return 1
        End Try
    End Function

    Protected Sub getCreditLimit(ByVal clientType As String, ByVal product As String)
        Try
            cmd = New SqlCommand("select max(isnull(LIMIT,0)) as LIMIT from PARA_CREDIT_LIMIT where CLIENT_TYPE='" & clientType & "'", con)
            Dim strLimit As String()
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            con.Open()
            strLimit = cmd.ExecuteScalar.ToString.Split(".")
            con.Close()
            Dim credLimit As Double
            Try
                credLimit = CDbl(strLimit(0))
            Catch ex As Exception
                credLimit = 0
            End Try
            'txtCreditLimit.Text = credLimit
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Function getEducation() As String
        If cmbEducation.SelectedValue = "Other" Then
            Return Trim("Other: " & BankString.removeSpecialCharacter(txtEducationOther.Text))
        Else
            Return cmbEducation.SelectedValue
        End If
    End Function
    Protected Sub getGrpMemberExpenses()
        Try
            cmd = New SqlCommand("select ID,POSITION,NAME,IDNO,RENT,FOOD,FEES,AIRTIME,MEDICAL,ELECTRICITY,WATER,RATES,CITY_OF_HRE as [CITY OF HARARE] from QUEST_GROUP_MEMBERS where CUSTOMER_NUMBER='" & txtCustNo.Text & "'", con)
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

    Protected Sub getGrpMembers()
        Try
            cmd = New SqlCommand("select ID,POSITION,NAME,IDNO from QUEST_GROUP_MEMBERS where CUSTOMER_NUMBER='" & txtCustNo.Text & "'", con)
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

    Protected Sub getNamesForEdit(ByVal custID As String)
        Try
            cmd = New SqlCommand("select *,convert(varchar,DOB,106) as DOB1,convert(varchar,ISSUE_DATE,106) as ISSUE_DATE1 from CUSTOMER_DETAILS_AUDIT where ID='" & custID & "'", con)
            Dim ds As New DataSet
            Dim adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "CUSTOMER")
            If ds.Tables(0).Rows.Count > 0 Then
                txtCustNo.Text = ds.Tables(0).Rows(0).Item("CUSTOMER_NUMBER")
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
                    txtEmpHowLong.Text = FormatNumber(ds.Tables(0).Rows(0).Item("CURR_EMP_LENGTH"), 2)
                Catch ex As Exception
                    txtEmpHowLong.Text = ""
                End Try
                Try
                    txtEmpOtherIncome.Text = FormatNumber(ds.Tables(0).Rows(0).Item("CURR_EMP_INCOME"), 2)
                Catch ex As Exception
                    txtEmpOtherIncome.Text = ""
                End Try

                txtEmpPhone.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("CURR_EMP_PHONE"))
                txtEmpPosition.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("CURR_EMP_POSITION"))
                Try
                    txtEmpSalary.Text = FormatNumber(ds.Tables(0).Rows(0).Item("CURR_EMP_SALARY"), 2)
                Catch ex As Exception
                    txtEmpSalary.Text = ""
                End Try
                Try
                    txtEmpSalaryNet.Text = FormatNumber(ds.Tables(0).Rows(0).Item("CURR_EMP_NET"), 2)
                Catch ex As Exception
                    txtEmpSalaryNet.Text = ""
                End Try
                'Try
                '    txtHouseHowLong.Text = FormatNumber(ds.Tables(0).Rows(0).Item("HOME_LENGTH"), 2)
                'Catch ex As Exception
                '    txtHouseHowLong.Text = ""
                'End Try

                txtIDNo.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("IDNO"))
                txtNationality.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("NATIONALITY"))
                txtNoChildren.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("NO_CHILDREN"))
                txtNoDependant.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("NO_DEPENDANTS"))
                txtPrevEmpAddress.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("PREV_EMP_ADD"))
                Try
                    txtPrevEmpAnnualIncome.Text = FormatNumber(ds.Tables(0).Rows(0).Item("PREV_EMP_INCOME"), 2)
                Catch ex As Exception
                    txtPrevEmpAnnualIncome.Text = ""
                End Try

                txtPrevEmpCity.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("PREV_EMP_CITY"))
                txtPrevEmpEmail.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("PREV_EMP_EMAIL"))
                txtPrevEmpFax.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("PREV_EMP_FAX"))
                Try
                    txtPrevEmpHowLong.Text = FormatNumber(ds.Tables(0).Rows(0).Item("PREV_EMP_LENGTH"), 2)
                Catch ex As Exception
                    txtPrevEmpHowLong.Text = ""
                End Try

                txtPrevEmployer.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("PREV_EMPLOYER"))
                txtPrevEmpPhone.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("PREV_EMP_PHONE"))
                txtPrevEmpPosition.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("PREV_EMP_POSITION"))
                Try
                    txtPrevEmpSalary.Text = FormatNumber(ds.Tables(0).Rows(0).Item("PREV_EMP_SALARY"), 2)
                Catch ex As Exception
                    txtPrevEmpSalary.Text = ""
                End Try
                Try
                    txtPrevEmpSalaryNet.Text = FormatNumber(ds.Tables(0).Rows(0).Item("PREV_EMP_NET"), 2)
                Catch ex As Exception
                    txtPrevEmpSalaryNet.Text = ""
                End Try
                Try
                    txtRent.Text = FormatNumber(ds.Tables(0).Rows(0).Item("MONTHLY_RENT"), 2)
                Catch ex As Exception
                    txtRent.Text = ""
                End Try

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
                Try
                    cmbSector.SelectedValue = BankString.isNullString(ds.Tables(0).Rows(0).Item("Sector"))
                Catch ex As Exception
                    cmbSector.ClearSelection()
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
                If rdbClientType.SelectedValue = "Individual" Then
                    lblSurname.Text = "Surname"
                    lblForenames.Text = "Forenames"
                    lblForenames.Visible = True
                    txtForenames.Visible = True
                    Try
                        rdbSubIndividual.SelectedValue = ds.Tables(0).Rows(0).Item("SUB_INDIVIDUAL")
                    Catch ex As Exception
                        rdbSubIndividual.ClearSelection()
                    End Try
                ElseIf rdbClientType.SelectedValue = "Business" Then
                    lblSurname.Text = "Name"
                    lblForenames.Visible = False
                    txtForenames.Visible = False
                    txtForenames.Text = ""
                End If
            Else
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
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

    Protected Sub grdAuthorization_SelectedIndexChanged(sender As Object, e As EventArgs) Handles grdAuthorization.SelectedIndexChanged
        Try
            auditID = grdAuthorization.Rows(grdAuthorization.SelectedIndex).Cells(1).Text
            requestTranType = grdAuthorization.Rows(grdAuthorization.SelectedIndex).Cells(2).Text
            getNamesForEdit(auditID)
            ClientScript.RegisterStartupScript(Me.GetType(), "Gritter", "<script type=""text/javascript"">$.gritter.add({title: 'Customer details loaded',text: 'The customer details have been loaded. Scroll below to authorize or discard change',image: 'images/notice.jpg'});</script>")
        Catch ex As Exception

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

    Protected Sub loadGrpMembers()
        Try
            cmbGrpDeclMember.Items.Clear()
            cmbGrpDeclMember.Items.Add("")
            cmd = New SqlCommand("select * from QUEST_GROUP_MEMBERS where CUSTOMER_NUMBER='" & txtCustNo.Text & "'", con)
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
        con = New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
        If Not IsPostBack Then
            writeBranch()
            loadClientTypes()
            loadSectors(cmbSector)
            loadBanks(cmbBankAppType)
            loadBanks(cmbBank)
            getPDACompanies()
        End If
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

    Protected Sub rdbClientType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdbClientType.SelectedIndexChanged
        If rdbClientType.SelectedValue = "Individual" Then
            panIndividual.Visible = True
            panGroup.Visible = False
            lblSurname.Text = "Surname"
            lblForenames.Text = "Forenames"
            lblForenames.Visible = True
            txtForenames.Visible = True
        ElseIf rdbClientType.SelectedValue = "Corporate" Or rdbClientType.SelectedValue = "Group" Then
            panIndividual.Visible = False
            panGroup.Visible = True
            lblSurname.Text = "Name"
            lblForenames.Visible = False
            txtForenames.Visible = False
            txtForenames.Text = ""
        Else
            lblSurname.Text = "Surname"
            lblForenames.Text = "Forenames"
            lblForenames.Visible = True
            txtForenames.Visible = True
        End If
        getCreditLimit(rdbClientType.SelectedValue, "all")
    End Sub

    Protected Sub writeBranch()
        lblBranchCode.Text = Session("BRANCHCODE")
        lblBranchName.Text = Session("BRANCHNAME")
    End Sub
End Class