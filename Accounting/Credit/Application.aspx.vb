Imports System.Data
Imports System.Data.SqlClient
Imports Mailhelper
Imports CreditManager
Imports BankString
Imports ErrorLogging
Partial Class Capital_Application
    Inherits System.Web.UI.Page
    Dim adp As SqlDataAdapter
    Dim con As New SqlConnection

    Dim querryCusNum = ""
    Dim querryBal = ""
    Dim querryRef = ""
    Dim rollOver = ""

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
            Response.Write(ex.Message)
            Return False
        Finally
            con.Close()
            con.Dispose()
        End Try
    End Function

    Public Sub msgbox(ByVal strMessage As String)
        'finishes server processing, returns to client.
        Dim strScript As String = "<script language=JavaScript>"
        strScript += "window.alert(""" & strMessage & """);"
        strScript += "</script>"
        Dim lbl As New System.Web.UI.WebControls.Label() With {.Text = strScript}
        Page.Controls.Add(lbl)
    End Sub

    Protected Sub btnIDNo_Click(sender As Object, e As EventArgs) Handles btnIDNo.Click
        Try
            ' Using cmd = New SqlCommand("select * from CUSTOMER_DETAILS where SURNAME = REPLACE(replace('" & txtSearchSurname.Text & "','-',''),' ','') and CUSTOMER_TYPE='Business' OR CUSTOMER_TYPE='Company'", con)

            Using cmd = New SqlCommand("select * from CUSTOMER_DETAILS where REPLACE(replace(IDNO,'-',''),' ','') = REPLACE(replace('" & txtIDNo.Text & "','-',''),' ','') and (CUSTOMER_TYPE in ('Company','Business'))", con)

                '                 Using cmd = New SqlCommand("select * from CUSTOMER_DETAILS where REPLACE(replace(IDNO,'-',''),' ','') = REPLACE(replace('" & txtIDNo.Text & "','-',''),' ','') and (CUSTOMER_TYPE='Company' OR CUSTOMER_TYPE='Business')", con)

                Dim ds As New DataSet
                Dim adp = New SqlDataAdapter(cmd)
                adp.Fill(ds, "CUSTOMER")
                If ds.Tables(0).Rows.Count > 0 Then
                    getNamesDT(ds.Tables(0))
                    Dim outs = getOutstandingLoans(txtCustNo.Text)
                    If outs = 0 Then
                    ElseIf outs = 1 Then
                        'gritter notification
                        'ClientScript.RegisterStartupScript(Me.GetType(), "Gritter", "<script type=""text/javascript"">$.gritter.add({title: 'Customer has 1 other loan',text: 'This customer already has 1 loan currently running.',image: 'images/notice.jpg'});</script>")
                    ElseIf outs >= 2 Then
                        'modal confirmation
                        ClientScript.RegisterStartupScript(Me.GetType(), "Confirmation", "<script type=""text/javascript"">showConfirmOtherLoans();</script>")
                    End If
                Else
                    'gritter notification
                    'ClientScript.RegisterStartupScript(Me.GetType(), "Gritter", "<script type=""text/javascript"">$.gritter.add({title: 'Customer not yet captured',text: 'This ID number does not exist in the system',image: 'images/error_button.png'});</script>")
                    notify("Business registration not found or client is not a Business", "error")
                End If
            End Using
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        Dim strscript As String
        Response.Write("<script> window.open('rptAssignmentLetter.aspx?ID=" & ViewState("globLoanID") & "'); location.href='Application.aspx'</script>")
        strscript = "<script langauage=JavaScript>"
        strscript += ";"
        strscript += "</script>"
        ClientScript.RegisterStartupScript(Me.GetType(), "newwin", strscript)
        Dim strscript1 As String

        strscript1 = "<script langauage=JavaScript>"
        strscript1 += "window.location.replace(""Application.aspx"");"
        strscript1 += "</script>"
        ClientScript.RegisterStartupScript(Me.GetType(), "reload", strscript1)
        clearALL()
    End Sub

    Protected Sub btnSearchCustNo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearchCustNo.Click
        'clearAllExceptCustNo()
        If isValidCustID(txtCustNo.Text) Then
            Dim outs = getOutstandingLoans(txtCustNo.Text)

            If outs = 0 Then
            ElseIf outs = 1 Then
                'ClientScript.RegisterStartupScript(Me.GetType(), "Gritter", "<script type=""text/javascript"">$.gritter.add({title: 'Customer has 1 other loan',text: 'This customer already has 1 loan currently running.',image: 'images/notice.jpg'});</script>")
                CreditManager.notify("This customer already has 1 loan currently running.", "warning")
            ElseIf outs >= 2 Then
                'modal confirmation
                ClientScript.RegisterStartupScript(Me.GetType(), "Confirmation", "<script type=""text/javascript"">showConfirmOtherLoans();</script>")
            End If
            getNames(txtCustNo.Text)
            getDirectors(txtCustNo.Text)
            'loadUploadedFiles(txtCustNo.Text)
            'getOtherLoans()
        Else
            'gritter notification
            'ClientScript.RegisterStartupScript(Me.GetType(), "Gritter2", "<script type= ""text/javascript"">$.gritter.add({title: 'Customer not found',text: 'No record with this customer ID was found.',image: 'images/error_button.png'});</script>")
        End If
    End Sub

    Protected Sub btnSearchSurname_Click(sender As Object, e As EventArgs) Handles btnSearchSurname.Click
        Try
            '              Using cmd = New SqlCommand("select * from CUSTOMER_DETAILS where SURNAME = REPLACE(replace('" & txtSearchSurname.Text & "','-',''),' ','') and CUSTOMER_TYPE='Business' OR CUSTOMER_TYPE='Company'", con)

            Using cmd = New SqlCommand("select *, CUSTOMER_NUMBER, isnull(SURNAME,'')+' '+isnull(FORENAMES,'')+' --- '+isnull(IDNO,'')+' --- '+isnull(ADDRESS,'') as display from CUSTOMER_DETAILS where isnull(SURNAME,'')+' '+isnull(FORENAMES,'')+' --- '+isnull(IDNO,'')+' --- '+isnull(ADDRESS,'') like '%" & txtSearchSurname.Text & "%' and (CUSTOMER_TYPE in ('Business','Company'))", con)

                '            Using cmd = New SqlCommand("select CUSTOMER_NUMBER, isnull(SURNAME,'')+' '+isnull(FORENAMES,'')+' --- '+isnull(IDNO,'')+' --- '+isnull(ADDRESS,'') as display from CUSTOMER_DETAILS where isnull(SURNAME,'')+' '+isnull(FORENAMES,'')+' --- '+isnull(IDNO,'')+' --- '+isnull(ADDRESS,'') like '%" & txtSearchSurname.Text & "%' and (CUSTOMER_TYPE='Business' OR CUSTOMER_TYPE='Company')", con)

                '                   Using cmd = New SqlCommand("select CUSTOMER_NUMBER, isnull(SURNAME,'')+' '+isnull(FORENAMES,'')+' --- '+isnull(IDNO,'')+' --- '+isnull(ADDRESS,'') as display from CUSTOMER_DETAILS where isnull(SURNAME,'')+' '+isnull(FORENAMES,'')+' --- '+isnull(IDNO,'')+' --- '+isnull(ADDRESS,'') like '%" & txtSearchSurname.Text & "%' and CUSTOMER_TYPE='Company'", con)

                Dim ds As New DataSet
                adp = New SqlDataAdapter(cmd)
                adp.Fill(ds, "cust")
                If ds.Tables(0).Rows.Count > 0 Then
                    lstSurname.Visible = True
                    lstSurname.DataSource = ds.Tables(0)
                    lstSurname.DataTextField = "display"
                    lstSurname.DataValueField = "CUSTOMER_NUMBER"
                Else
                    lstSurname.DataSource = Nothing
                    CreditManager.notify("The searched name was not found or not a Business client", "error")
                End If
            End Using
            clearALL()
            lstSurname.DataBind()
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        submitApplication()
    End Sub

    Protected Sub clearALL()
        txtContactName.Text = ""
        txtBusinessEmail.Text = ""
        txtBusinessPhone.Text = ""
        txtBox.Text = ""
        txtCity.Text = ""
        txtContactEmail.Text = ""
        txtRoad.Text = ""
        'txtAccountName.Text = ""
        'txtRecommendedDisbDate.Text = ""
        txtContactTel.Text = ""
        btnSubmit.Visible = True
    End Sub

    Protected Sub getDirectors(custNo As String)
        Try
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd = New SqlCommand("Select DirectorName as [Name],DirectorGender as [Gender],DirectorIDNo as [ID Number],DirectorTel as [Telephone],DirectorEmail as [Email],DirectorAddress as [Address],convert(varchar,DirectorDOB,106) as [Date of Birth] from [CompanyDirectors] where CustomerNo='" & custNo & "'", con)
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

    Protected Function getLastLoanID() As String
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
    End Function

    Protected Sub getNames(ByVal custID As String)
        Try
            Using cmd = New SqlCommand("select *,convert(varchar,DOB,106) as DOB1,convert(varchar,ISSUE_DATE,106) as ISSUE_DATE1,convert(varchar,DirectorDOB,106) as DirectorDOB1 from CUSTOMER_DETAILS where CUSTOMER_NUMBER='" & custID & "'", con)
                Dim ds As New DataSet
                Dim adp = New SqlDataAdapter(cmd)
                adp.Fill(ds, "CUSTOMER")
                If ds.Tables(0).Rows.Count > 0 Then
                    txtCustNo.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("CUSTOMER_NUMBER"))
                    txtCity.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("CITY"))
                    txtIDNo.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("IDNO"))
                    Try
                        rdbClientType.SelectedValue = BankString.isNullString(ds.Tables(0).Rows(0).Item("CUSTOMER_TYPE"))
                    Catch ex As Exception
                        rdbClientType.ClearSelection()
                    End Try
                    Try
                        rdbCompanyType.SelectedValue = BankString.isNullString(ds.Tables(0).Rows(0).Item("SUB_INDIVIDUAL"))
                    Catch ex As Exception
                        rdbCompanyType.ClearSelection()
                    End Try
                    txtRegdName.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("SURNAME"))
                    txtTradeName.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("FORENAMES"))
                    txtRoad.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("ADDRESS"))
                    'txtCityTown.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("CITY"))
                    txtBusinessPhone.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("PHONE_NO"))
                    'txtBusRegNo.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("IDNO"))

                    txtCustNo.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("CUSTOMER_NUMBER"))
                    txtContactName.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("ContactName"))
                    txtContactTel.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("ContactPhone"))
                    txtContactEmail.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("ContactEmail"))
                    txtBox.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("POBox"))
                    txtBusinessEmail.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("BusEmail"))
                    txtDirectorEmail.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("DirectorEmail"))
                    txtDirectorName.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("DirectorName"))
                    txtDirectorPhone.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("DirectorTel"))
                    Try
                        txtDirectorDOB.Text = ds.Tables(0).Rows(0).Item("DirectorDOB1")
                    Catch ex As Exception
                        txtDirectorDOB.Text = ""
                    End Try
                    Try
                        txtDirectorIDNumber.Text = ds.Tables(0).Rows(0).Item("DirectorIDNo")
                    Catch ex As Exception
                        txtDirectorIDNumber.Text = ""
                    End Try
                    Try
                        rdbDirectorGender.SelectedValue = BankString.isNullString(ds.Tables(0).Rows(0).Item("DirectorGender"))
                    Catch ex As Exception
                        rdbDirectorGender.ClearSelection()
                    End Try
                    Try
                        txtBusRegdDate.Text = ds.Tables(0).Rows(0).Item("DOB1")
                    Catch ex As Exception
                        txtBusRegdDate.Text = ""
                    End Try
                    Try
                        txtDirectorResAddress.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("DirectorAddress"))
                    Catch ex As Exception
                        txtDirectorResAddress.Text = ""
                    End Try
                    Try
                        getCurrentExposure(custID)
                    Catch ex As Exception
                    End Try
                Else
                End If
            End Using
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub getNamesDT(ByVal dtNames As DataTable)
        Try
            If dtNames.Rows.Count > 0 Then
                txtCustNo.Text = BankString.isNullString(dtNames.Rows(0).Item("CUSTOMER_NUMBER"))
                txtCity.Text = BankString.isNullString(dtNames.Rows(0).Item("CITY"))
                txtIDNo.Text = BankString.isNullString(dtNames.Rows(0).Item("IDNO"))

                rdbClientType.SelectedValue = BankString.isNullString(dtNames.Rows(0).Item("CUSTOMER_TYPE"))
            Else
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Function getOutstandingLoans(custNo As String) As Integer
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
    End Function

    Protected Sub getStaticDetails(ByVal accNo As String)
        Try
            'msgbox(accNo)
            Dim cmd As SqlCommand = New SqlCommand("select * from [ApplicantStaticDetails] where [ACCOUNTNO]='" & accNo & "'", con)
            Dim ds As New DataSet
            Dim adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "APP")
            If ds.Tables(0).Rows.Count > 0 Then
                Dim row = ds.Tables(0).Rows(0)
                ViewState("AccNo") = isNullString(row("ACCOUNTNO"))
                'txtAccountName.Text = isNullString(row("ACCOUNTNAME"))
                'Try
                '    cmbCompanyType.SelectedValue = isNullString(row("COMPANY_TYPE"))
                'Catch ex As Exception
                '    cmbCompanyType.ClearSelection()
                'End Try
                txtRoad.Text = isNullString(row("ROAD"))
                txtCity.Text = isNullString(row("CITY"))
                txtBox.Text = isNullString(row("POBOX"))
                txtBusinessPhone.Text = isNullString(row("TELNO"))
                txtBusinessEmail.Text = isNullString(row("EMAIL"))
                txtContactName.Text = isNullString(row("CONTACT_PERSON"))
                txtContactTel.Text = isNullString(row("CONTACT_NO"))
                txtContactEmail.Text = isNullString(row("EMAIL_PROCU_CONTACT"))
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Function isValidCustID(custID As String) As Boolean
        Try
            Using cmd = New SqlCommand("select ID from CUSTOMER_DETAILS where CUSTOMER_NUMBER='" & custID & "' and CUSTOMER_TYPE in ('Company', 'Business')", con)
                Dim ds As New DataSet
                adp = New SqlDataAdapter(cmd)
                adp.Fill(ds, "CD")
                If ds.Tables(0).Rows.Count > 0 Then
                    Return True
                Else
                    Return False
                End If
            End Using
        Catch ex As Exception
            Return False
        End Try
    End Function

    Protected Sub loadBank(cmbBank As DropDownList)
        Try
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd As New SqlCommand("select distinct bank, bank_name from para_bank order by bank", con)
                    Dim dss As New DataSet
                    Dim adp = New SqlDataAdapter(cmd)
                    adp.Fill(dss, "para_bank")
                    loadCombo(dss.Tables(0), cmbBank, "bank_name", "bank")
                End Using
            End Using
        Catch ex As Exception
            WriteLogFile(Session("UserId"), "Credit/NamesCapture - loadBank()", ex.Message)
        End Try
    End Sub

    Protected Sub loadBanks(cmbBankOther As DropDownList, cmbNameOfBankloan As DropDownList)
        Try
            Dim cmd As SqlCommand = New SqlCommand("select * from BANK_DETAILS order by BANK_NAME", con)
            Dim adp As SqlDataAdapter
            Dim ds As New DataSet
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "BANK")
            If ds.Tables(0).Rows.Count > 0 Then
                cmbBankOther.AppendDataBoundItems = True
                cmbNameOfBankloan.AppendDataBoundItems = True
                cmbBankOther.Items.Add("")
                cmbBankOther.DataSource = ds.Tables(0)
                cmbBankOther.DataTextField = "BANK_NAME"
                cmbBankOther.DataValueField = "BANK_CODE"

                cmbNameOfBankloan.Items.Add("")
                cmbNameOfBankloan.DataSource = ds.Tables(0)
                cmbNameOfBankloan.DataTextField = "BANK_NAME"
                cmbNameOfBankloan.DataValueField = "BANK_CODE"
            Else
                cmbBankOther.DataSource = Nothing
                cmbNameOfBankloan.DataSource = Nothing
            End If
            cmbNameOfBankloan.DataBind()
            cmbBankOther.DataBind()
        Catch ex As Exception

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

    Protected Sub lstSurname_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstSurname.SelectedIndexChanged
        Try
            Dim custID = lstSurname.SelectedValue

            '            Dim custID = lstSurname.SelectedI

            txtCustNo.Text = custID

            btnSearchCustNo_Click(sender, New EventArgs)
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Page.MaintainScrollPositionOnPostBack = True
        con = New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
        If Not IsPostBack Then
            loadBank(cmbFinReqBank)
            writeBranch()
            loadPurpose(cmbFinReqPurpose)
            rdbType.SelectedValue = "Cash"
            loadProductType(cmbProductType)
            If Request.QueryString("ID") <> "" Then
                'ViewState("LoanID") = Request.QueryString("ID")
                Dim EncQuery As New BankEncryption64
                ViewState("LoanID") = EncQuery.Decrypt(Request.QueryString("ID").Replace(" ", "+"))
            Else
                ViewState("LoanID") = 0
                ViewState("AccNo") = 0
            End If
            If Request.QueryString.AllKeys.Contains("cusNum") And Request.QueryString.AllKeys.Contains("bal") And
                      Request.QueryString.AllKeys.Contains("ref") Then

                Dim querryCusNum1 = Request.QueryString("cusNum")
                Dim querryBal1 = Request.QueryString("bal")
                Dim querryRef1 = Request.QueryString("ref")

                If Not String.IsNullOrEmpty(querryCusNum1) And Not String.IsNullOrEmpty(querryBal1) And Not String.IsNullOrEmpty(querryRef1) Then
                    rollOver = Request.QueryString("ref")
                    txtCustNo.Text = Request.QueryString("cusNum").ToString()
                    btnSearchCustNo_Click(sender, New EventArgs)
                    txtFinReqAmt.Text = Request.QueryString("bal").ToString()
                Else
                    rollOver = "NULL"
                End If
            Else
                rollOver = "NULL"
            End If
            '            Catch ex As Exception
            '                msgbox("Error" + ex.ToString())
            '            End Try
        End If
    End Sub

    Private Sub cmbProductType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbProductType.SelectedIndexChanged
        getProductDefaults(cmbProductType.SelectedValue)
        getCreditParams(cmbProductType.SelectedValue)
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
                        ViewState("MinIntRate") = dr("MinIntRate")
                        ViewState("MaxIntRate") = dr("MaxIntRate")
                        hidMinInterest.Value = dr("MinIntRate")
                        hidMaxInterest.Value = dr("MaxIntRate")

                        Dim salLimit As Double = 0 'getSalaryBasedLimit(dr, IIf(IsNumeric(txtEmpSalary.Text), txtEmpSalary.Text, 0), IIf(IsNumeric(txtEmpSalaryNet.Text), txtEmpSalaryNet.Text, 0))
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
                        ViewState("MinAmt") = dr("MinAmt")
                        ViewState("MaxAmt") = maxLimit ' dr("MaxAmt")
                        hidMinLoanAmount.Value = dr("MinAmt")
                        hidMaxLoanAmount.Value = maxLimit ' dr("MaxAmt")
                        lblValTenure.Text = "Minimum loan tenure: " & FormatNumber(dr("MinimumTenure"), 0) & ".  Maximum loan tenure: " & FormatNumber(dr("MaximumTenure"), 0)
                        ViewState("MinimumTenure") = dr("MinimumTenure")
                        ViewState("MaximumTenure") = dr("MaximumTenure")
                        hidMinTenure.Value = dr("MinimumTenure")
                        hidMaxTenure.Value = dr("MaximumTenure")

                    Else
                        lblValInterest.Text = ""
                        lblValAmount.Text = ""
                        lblValTenure.Text = ""
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
                        ViewState("CurrentExposure") = dr("Exposure")
                        If CDbl(ViewState("MaxExposure")) < CDbl(ViewState("CurrentExposure")) Then
                            ClientScript.RegisterStartupScript(Me.GetType, "exposure", "<script type='text/javascript'>alert('Client has an exposure greater than the allowed maximum of " & FormatCurrency(ViewState("MaxExposure")) & "'); location.href = 'ApplicationForm.aspx'</script>")
                        Else
                            hidCurrentExposure.Value = dr("Exposure")
                            hidMaxExposure.Value = ViewState("MaxExposure")
                        End If
                    Else
                        lblCurrExposure.Text = ""
                    End If
                End Using
            End Using
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- getCreditParams()", ex.ToString)
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
                        Try
                            txtFinReqIntRate.Text = dr("DefaultIntRate")
                        Catch ex As Exception
                            txtFinReqIntRate.Text = ""
                        End Try
                        Try
                            If dr("ProductFees") = "None" Then
                                lblAdminRate.Visible = False
                                txtAdminRate.Text = "0"
                                txtAdminRate.Visible = False
                            Else
                                lblAdminRate.Visible = True
                                txtAdminRate.Visible = True
                                Try
                                    lblAdminRate.Text = IIf(dr("ProductFeeCalc") = "Percentage", "Application Fees (%)", "Application Fees ($)")
                                Catch ex As Exception

                                End Try
                                Try
                                    txtAdminRate.Text = dr("ProductFeeAmtPerc")
                                Catch ex As Exception
                                    txtAdminRate.Text = ""
                                End Try
                            End If
                        Catch ex As Exception

                        End Try
                        Try
                            If dr("DefaultIntInterval") = "Daily" Then
                                lblInterestRate.Text = "Interest Rate (% per day)"
                            ElseIf dr("DefaultIntInterval") = "Weekly" Then
                                lblInterestRate.Text = "Interest Rate (% per week)"
                            ElseIf dr("DefaultIntInterval") = "Monthly" Then
                                lblInterestRate.Text = "Interest Rate (% per month)"
                            ElseIf dr("DefaultIntInterval") = "Annual" Then
                                lblInterestRate.Text = "Interest Rate (% per annum)"
                            ElseIf dr("DefaultIntInterval") = "Duration" Then
                                lblInterestRate.Text = "Interest Rate (%)"
                            Else
                                lblInterestRate.Text = "Interest Rate (%)"
                            End If
                        Catch ex As Exception

                        End Try
                        Try
                            txtRepaymentInterval.Text = dr("RepaymentIntervalNum")
                        Catch ex As Exception
                            txtRepaymentInterval.Text = ""
                        End Try

                        Try
                            cmbRepaymentInterval.SelectedValue = dr("RepaymentIntervalUnit")
                        Catch ex As Exception
                            cmbRepaymentInterval.ClearSelection()
                        End Try
                        Try
                            txtFinReqTenor.Text = FormatNumber(dr("DefaultTenure"), 0)
                        Catch ex As Exception
                            txtFinReqTenor.Text = ""
                        End Try
                    End If
                End Using
            End Using
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- getProductDefaults()", ex.ToString)
        End Try
    End Sub
    Protected Sub rdbCompanyType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rdbCompanyType.SelectedIndexChanged
        If rdbCompanyType.SelectedValue = "Sole" Then
            'btnAddDirector.Visible = False
        ElseIf rdbCompanyType.SelectedValue = "Registered" Then
            'btnAddDirector.Visible = True
        End If
    End Sub

    Protected Sub sendEmail(appDate As String, accName As String, amtApplied As String, duration As String, sendToRole As String, Optional comment As String = "", Optional isIndiv As Boolean = False)
        Dim strEmail As String
        Dim SignatoryEMail As String
        If isIndiv Then
            SignatoryEMail = GetEMailID(sendToRole)
        Else
            SignatoryEMail = GetMultipleEMailID(sendToRole)
        End If
        strEmail = "<Strong>Dear Sir/Madam,</strong><br>You Have Received A New Invoice Discount Application Request. Details are as follows:<br/><br/>"
        strEmail = strEmail & "<Table bgcolor='444444'><font forecolor='ffffff'>"
        strEmail = strEmail & "<tr bgcolor='999999'><td>Date:</td><td>" & appDate & "</td></tr>"
        strEmail = strEmail & "<tr bgcolor='eeeeee'><td>Account Name</td><td>" & accName & "</td></tr>"
        'strEmail = strEmail & "<tr bgcolor='999999'><td>Procuring Entity</td><td>" & procEntity & "</td></tr>"
        strEmail = strEmail & "<tr bgcolor='999999'><td>Amount Applied For</td><td>" & amtApplied & "</td></tr>"
        strEmail = strEmail & "<tr bgcolor='eeeeee'><td>Duration</td><td>" & duration & "</td></tr>"
        strEmail = strEmail & "</font></Table>"
        If Trim(comment) <> "" Then
            strEmail = strEmail & "<br/><i>Comment: " & comment & "</i><br/><br/>"
        End If
        strEmail = strEmail & "<br/><Strong>Thanks & Regards,<br/><br/>Escrow 360 Support Team</strong>"
        'If Trim(SignatoryEMail) = "" Then
        'End If
        Mailhelper.SendMailMessage("administrator", SignatoryEMail, "", "", "Escrow 360 Credit Management - Invoice Discount Application", strEmail)
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
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- getNextApproval()", ex.Message)
        End Try
    End Sub

    Protected Sub submitApplication()
        Dim cmd As New SqlCommand
        Try
            If bdpFinReqRepaymt.Text = "" Then
                notify("1st Repayment Date is Required", "error")
                Exit Sub
            End If
            'If txtRecommendedDisbDate.Text = "" Then
            '    notify("Recommended Disbursement Date is Required", "error")
            '    Exit Sub
            'End If
            getNextApproval(1)
            If btnSubmit.Text = "Update Application" Then
                'cmd = New SqlCommand("update QUEST_APPLICATION set [RecommendedDisbDate]='" & txtRecommendedDisbDate.Text & "',[ApplicationType]='" & rdbType.SelectedValue & "',[CUSTOMER_TYPE]='Company',[CUSTOMER_NUMBER]='" & txtCustNo.Text & "',[SURNAME]='" & BankString.removeSpecialCharacter(txtRegdName.Text) & "',[FORENAMES]='" & BankString.removeSpecialCharacter(txtTradeName.Text) & "',[DOB]='" & txtBusRegdDate.Text & "',[IDNO]='" & txtIDNo.Text & "',[ADDRESS]='" & BankString.removeSpecialCharacter(txtRoad.Text) & "',[CITY]='" & BankString.removeSpecialCharacter(txtCity.Text) & "',[PHONE_NO]='" & txtBusinessPhone.Text & "',[FIN_AMT]=NULLIF('" & txtFinReqAmt.Text.Replace(",", "") & "',''),[FIN_TENOR]=NULLIF('" & txtFinReqTenor.Text & "',''),[FIN_INT_RATE]=NULLIF('" & txtFinReqIntRate.Text & "',''),[FIN_PURPOSE]='" & BankString.removeSpecialCharacter(cmbFinReqPurpose.SelectedValue) & "',[FIN_SRC_REPAYMT]='" & BankString.removeSpecialCharacter(txtFinReqSource.Text) & "',[FIN_SEC_OFFER]='" & BankString.removeSpecialCharacter(txtFinReqSecOffer.Text) & "',[FIN_BANK]='" & BankString.removeSpecialCharacter(txtFinReqBank.Text) & "',[FIN_BRANCH]='" & BankString.removeSpecialCharacter(txtFinReqBranchName.Text) & "',[FIN_BRANCH_CODE]='" & txtFinReqBranchCode.Text & "',[FIN_ACCNO]='" & txtFinReqAccNo.Text & "',[FIN_REPAY_DATE]=NULLIF('" & bdpFinReqRepaymt.Text & "',''),[MODIFIED_BY]='" & Session("UserID") & "',[MODIFIED_DATE]=getdate(),[STATUS]='APPROVED2',[SEND_TO]='1024',[BRANCH_CODE]='" & lblBranchCode.Text & "',[BRANCH_NAME]='" & BankString.removeSpecialCharacter(lblBranchName.Text) & "',[AMT_APPLIED]=NULLIF('" & txtFinReqAmt.Text.Replace(",", "") & "',''),[ECOCASH_NUMBER]='" & txtEcocashNumber.Text & "',[OTHER_CHARGES]=NULLIF('" & Trim(txtFinReqOtherCharges.Text) & "',''),[FIN_ADMIN]=NULLIF('" & Trim(txtFinReqOtherCharges.Text) & "',''),[DISBURSE_OPTION]='',LO_ID='" & Session("ID") & "',LAST_ID='" & Session("ID") & "',INT_RATE=NULLIF('" & txtInterestRate.Text & "',''),INSURANCE_RATE=NULLIF('" & txtInsuranceRate.Text & "',''),ADMIN_RATE=NULLIF('" & txtAdminRate.Text & "',''),RepaymentIntervalNum=NULLIF('" & txtRepaymentInterval.Text & "',''),RepaymentIntervalUnit=NULLIF('" & cmbRepaymentInterval.SelectedValue & "',''),LoanDuration=NULLIF('" & txtLoanDuration.Text & "',''),AppDate=NULLIF('" & txtAppDate.Text & "',''),ContactName=NULLIF('" & txtContactName.Text & "',''),ContactPhone=NULLIF('" & txtContactTel.Text & "',''),ContactEmail=NULLIF('" & txtContactEmail.Text & "',''),POBox='" & txtBox.Text & "',BusEmail='" & txtBusinessEmail.Text & "',[DirectorName]='" & txtDirectorName.Text & "',[DirectorGender]='" & rdbDirectorGender.SelectedValue & "',[DirectorTel]='" & txtDirectorPhone.Text & "',[DirectorEmail]='" & txtDirectorEmail & "',[DirectorIDNo]='" & txtDirectorIDNumber.Text & "',[DirectorDOB]=NULLIF('" & txtDirectorDOB.Text & "','') where ID='" & ViewState("globLoanID") & "'", con)
                cmd = New SqlCommand("update QUEST_APPLICATION set LoanCycle=NULLIF('" & lblLoanCycle.Text & "',''),[STATUS]='" & ViewState("StageName") & "',[SEND_TO]='" & ViewState("NextRole") & "', APPL_DATE='" & txtAppDate.Text & "',[ReadyToDisburse]='" & ViewState("ReadyToDisburse") & "',[ApprovalNumber]=1,[FinProductType]='" & BankString.removeSpecialCharacter(cmbProductType.SelectedValue) & "',[ApplicationType]='" & rdbType.SelectedValue & "',[CUSTOMER_TYPE]='Business',[CUSTOMER_NUMBER]='" & txtCustNo.Text & "',[SURNAME]='" & BankString.removeSpecialCharacter(txtRegdName.Text) & "',[FORENAMES]='" & BankString.removeSpecialCharacter(txtTradeName.Text) & "',[DOB]='" & txtBusRegdDate.Text & "',[IDNO]='" & txtIDNo.Text & "',[ADDRESS]='" & BankString.removeSpecialCharacter(txtRoad.Text) & "',[CITY]='" & BankString.removeSpecialCharacter(txtCity.Text) & "',[PHONE_NO]='" & txtBusinessPhone.Text & "',[FIN_AMT]=NULLIF('" & txtFinReqAmt.Text.Replace(",", "") & "',''),[FIN_TENOR]=NULLIF('" & txtFinReqTenor.Text & "',''),[FIN_INT_RATE]=NULLIF('" & txtFinReqIntRate.Text & "',''),[FIN_PURPOSE]='" & BankString.removeSpecialCharacter(cmbFinReqPurpose.SelectedValue) & "',[FIN_SRC_REPAYMT]='" & BankString.removeSpecialCharacter(txtFinReqSource.Text) & "',[FIN_SEC_OFFER]='" & BankString.removeSpecialCharacter(txtFinReqSecOffer.Text) & "',[FIN_BANK]='" & BankString.removeSpecialCharacter(txtFinReqBank.Text) & "',[FIN_BRANCH]='" & BankString.removeSpecialCharacter(txtFinReqBranchName.Text) & "',[FIN_BRANCH_CODE]='" & txtFinReqBranchCode.Text & "',[FIN_ACCNO]='" & txtFinReqAccNo.Text & "',[FIN_REPAY_DATE]=NULLIF('" & bdpFinReqRepaymt.Text & "',''),[MODIFIED_BY]='" & Session("UserID") & "',[MODIFIED_DATE]=getdate(),[BRANCH_CODE]='" & lblBranchCode.Text & "',[BRANCH_NAME]='" & BankString.removeSpecialCharacter(lblBranchName.Text) & "',[AMT_APPLIED]=NULLIF('" & txtFinReqAmt.Text.Replace(",", "") & "',''),[ECOCASH_NUMBER]='" & txtEcocashNumber.Text & "',[OTHER_CHARGES]=NULLIF('" & Trim(txtFinReqOtherCharges.Text) & "',''),[FIN_ADMIN]=NULLIF('" & Trim(txtFinReqOtherCharges.Text) & "',''),[DISBURSE_OPTION]='',LO_ID='" & Session("ID") & "',LAST_ID='" & Session("ID") & "',INT_RATE=NULLIF('" & txtInterestRate.Text & "',''),INSURANCE_RATE=NULLIF('" & txtInsuranceRate.Text & "',''),ADMIN_RATE=NULLIF('" & txtAdminRate.Text & "',''),RepaymentIntervalNum=NULLIF('" & txtRepaymentInterval.Text & "',''),RepaymentIntervalUnit=NULLIF('" & cmbRepaymentInterval.SelectedValue & "',''),AppDate=NULLIF('" & txtAppDate.Text & "',''),ContactName=NULLIF('" & txtContactName.Text & "',''),ContactPhone=NULLIF('" & txtContactTel.Text & "',''),ContactEmail=NULLIF('" & txtContactEmail.Text & "',''),POBox='" & txtBox.Text & "',BusEmail='" & txtBusinessEmail.Text & "',[DirectorName]='" & txtDirectorName.Text & "',[DirectorGender]='" & rdbDirectorGender.SelectedValue & "',[DirectorTel]='" & txtDirectorPhone.Text & "',[DirectorEmail]='" & txtDirectorEmail & "',[DirectorIDNo]='" & txtDirectorIDNumber.Text & "',[DirectorDOB]=NULLIF('" & txtDirectorDOB.Text & "','') where ID='" & ViewState("globLoanID") & "'", con)
            Else

                Dim querRoll = ""

                If Request.QueryString.AllKeys.Contains("cusNum") And Request.QueryString.AllKeys.Contains("bal") And
                          Request.QueryString.AllKeys.Contains("ref") Then

                    Dim querryCusNum1 = Request.QueryString("cusNum")
                    Dim querryBal1 = Request.QueryString("bal")
                    Dim querryRef1 = Request.QueryString("ref")

                    If Not String.IsNullOrEmpty(querryCusNum1) And Not String.IsNullOrEmpty(querryBal1) And Not String.IsNullOrEmpty(querryRef1) Then
                        ' Response.Redirect("~/Credit/RollOver.aspx")

                        ' rollOver = querryRef
                        querRoll = querryRef1
                        rollOver = querryRef1

                    Else
                        rollOver = "NULL"
                    End If
                End If

                'cmd = New SqlCommand("INSERT INTO QUEST_APPLICATION ([RecommendedDisbDate],[ApplicationType],[CUSTOMER_TYPE],[CUSTOMER_NUMBER],[SURNAME],[FORENAMES],[DOB],[IDNO],[ADDRESS],[CITY],[PHONE_NO],[FIN_AMT],[FIN_TENOR],[FIN_INT_RATE],[FIN_PURPOSE],[FIN_SRC_REPAYMT],[FIN_SEC_OFFER],[FIN_BANK],[FIN_BRANCH],[FIN_BRANCH_CODE],[FIN_ACCNO],[FIN_REPAY_DATE],[MODIFIED_BY],[MODIFIED_DATE],[STATUS],[SEND_TO],[BRANCH_CODE],[BRANCH_NAME],[AMT_APPLIED],[ECOCASH_NUMBER],[OTHER_CHARGES],[FIN_ADMIN],[DISBURSE_OPTION],LO_ID,LAST_ID,INT_RATE,INSURANCE_RATE,ADMIN_RATE,RepaymentIntervalNum,RepaymentIntervalUnit,LoanDuration,AppDate,ContactName,ContactPhone,ContactEmail,POBox,BusEmail,[DirectorName],[DirectorGender],[DirectorTel],[DirectorEmail],[DirectorDOB],[DirectorIDNo], RolledOver) VALUES ('" & txtRecommendedDisbDate.Text & "','" & rdbType.SelectedValue & "','Company','" & txtCustNo.Text & "','" & BankString.removeSpecialCharacter(txtRegdName.Text) & "','" & BankString.removeSpecialCharacter(txtTradeName.Text) & "','" & txtBusRegdDate.Text & "','" & txtIDNo.Text & "','" & BankString.removeSpecialCharacter(txtRoad.Text) & "','" & BankString.removeSpecialCharacter(txtCity.Text) & "','" & txtBusinessPhone.Text & "',NULLIF('" & txtFinReqAmt.Text.Replace(",", "") & "',''),NULLIF('" & txtFinReqTenor.Text & "',''),NULLIF('" & txtFinReqIntRate.Text & "',''),'" & BankString.removeSpecialCharacter(cmbFinReqPurpose.SelectedValue) & "','" & BankString.removeSpecialCharacter(txtFinReqSource.Text) & "','" & BankString.removeSpecialCharacter(txtFinReqSecOffer.Text) & "','" & BankString.removeSpecialCharacter(txtFinReqBank.Text) & "','" & BankString.removeSpecialCharacter(txtFinReqBranchName.Text) & "','" & txtFinReqBranchCode.Text & "','" & txtFinReqAccNo.Text & "',NULLIF('" & bdpFinReqRepaymt.Text & "',''),'" & Session("UserID") & "',GETDATE(),'APPROVED2','4042','" & lblBranchCode.Text & "','" & BankString.removeSpecialCharacter(lblBranchName.Text) & "',NULLIF('" & txtFinReqAmt.Text.Replace(",", "") & "',''),'" & txtEcocashNumber.Text & "',NULLIF('" & Trim(txtFinReqOtherCharges.Text) & "',''),NULLIF('" & Trim(txtFinReqOtherCharges.Text) & "',''),'','" & Session("ID") & "','" & Session("ID") & "',NULLIF('" & txtInterestRate.Text & "',''),NULLIF('" & txtInsuranceRate.Text & "',''),NULLIF('" & txtAdminRate.Text & "',''),NULLIF('" & txtRepaymentInterval.Text & "',''),NULLIF('" & cmbRepaymentInterval.SelectedValue & "',''),NULLIF('" & txtLoanDuration.Text & "',''),NULLIF('" & txtAppDate.Text & "',''),NULLIF('" & txtContactName.Text & "',''),NULLIF('" & txtContactTel.Text & "',''),NULLIF('" & txtContactEmail.Text & "',''),'" & txtBox.Text & "','" & txtBusinessEmail.Text & "','" & txtDirectorName.Text & "','" & rdbDirectorGender.SelectedValue & "','" & txtDirectorPhone.Text & "','" & txtDirectorEmail.Text & "',NULLIF('" & txtDirectorDOB.Text & "',''),'" & txtDirectorIDNumber.Text & "', '" & querRoll & "')", con)
                cmd = New SqlCommand("INSERT INTO QUEST_APPLICATION (LoanCycle,[STATUS],[SEND_TO], APPL_DATE,[ReadyToDisburse],[ApprovalNumber],[FinProductType],[ApplicationType],[CUSTOMER_TYPE],[CUSTOMER_NUMBER],[SURNAME],[FORENAMES],[DOB],[IDNO],[ADDRESS],[CITY],[PHONE_NO],[FIN_AMT],[FIN_TENOR],[FIN_INT_RATE],[FIN_PURPOSE],[FIN_SRC_REPAYMT],[FIN_SEC_OFFER],[FIN_BANK],[FIN_BRANCH],[FIN_BRANCH_CODE],[FIN_ACCNO],[FIN_REPAY_DATE],[MODIFIED_BY],[MODIFIED_DATE],[BRANCH_CODE],[BRANCH_NAME],[AMT_APPLIED],[ECOCASH_NUMBER],[OTHER_CHARGES],[FIN_ADMIN],[DISBURSE_OPTION],LO_ID,LAST_ID,INT_RATE,INSURANCE_RATE,ADMIN_RATE,RepaymentIntervalNum,RepaymentIntervalUnit,LoanDuration,AppDate,ContactName,ContactPhone,ContactEmail,POBox,BusEmail,[DirectorName],[DirectorGender],[DirectorTel],[DirectorEmail],[DirectorDOB],[DirectorIDNo], RolledOver) VALUES (NULLIF('" & lblLoanCycle.Text & "',''),'" & ViewState("StageName") & "','" & ViewState("NextRole") & "','" & txtAppDate.Text & "','" & ViewState("ReadyToDisburse") & "',1,'" & BankString.removeSpecialCharacter(cmbProductType.SelectedValue) & "','" & rdbType.SelectedValue & "','Business','" & txtCustNo.Text & "','" & BankString.removeSpecialCharacter(txtRegdName.Text) & "','" & BankString.removeSpecialCharacter(txtTradeName.Text) & "','" & txtBusRegdDate.Text & "','" & txtIDNo.Text & "','" & BankString.removeSpecialCharacter(txtRoad.Text) & "','" & BankString.removeSpecialCharacter(txtCity.Text) & "','" & txtBusinessPhone.Text & "',NULLIF('" & txtFinReqAmt.Text.Replace(",", "") & "',''),NULLIF('" & txtFinReqTenor.Text & "',''),NULLIF('" & txtFinReqIntRate.Text & "',''),'" & BankString.removeSpecialCharacter(cmbFinReqPurpose.SelectedValue) & "','" & BankString.removeSpecialCharacter(txtFinReqSource.Text) & "','" & BankString.removeSpecialCharacter(txtFinReqSecOffer.Text) & "','" & BankString.removeSpecialCharacter(txtFinReqBank.Text) & "','" & BankString.removeSpecialCharacter(txtFinReqBranchName.Text) & "','" & txtFinReqBranchCode.Text & "','" & txtFinReqAccNo.Text & "',NULLIF('" & bdpFinReqRepaymt.Text & "',''),'" & Session("UserID") & "',GETDATE(),'" & lblBranchCode.Text & "','" & BankString.removeSpecialCharacter(lblBranchName.Text) & "',NULLIF('" & txtFinReqAmt.Text.Replace(",", "") & "',''),'" & txtEcocashNumber.Text & "',NULLIF('" & Trim(txtFinReqOtherCharges.Text) & "',''),NULLIF('" & Trim(txtFinReqOtherCharges.Text) & "',''),'','" & Session("ID") & "','" & Session("ID") & "',NULLIF('" & txtInterestRate.Text & "',''),NULLIF('" & txtInsuranceRate.Text & "',''),NULLIF('" & txtAdminRate.Text & "',''),NULLIF('" & txtRepaymentInterval.Text & "',''),NULLIF('" & cmbRepaymentInterval.SelectedValue & "',''),NULLIF('" & 0 & "',''),NULLIF('" & txtAppDate.Text & "',''),NULLIF('" & txtContactName.Text & "',''),NULLIF('" & txtContactTel.Text & "',''),NULLIF('" & txtContactEmail.Text & "',''),'" & txtBox.Text & "','" & txtBusinessEmail.Text & "','" & txtDirectorName.Text & "','" & rdbDirectorGender.SelectedValue & "','" & txtDirectorPhone.Text & "','" & txtDirectorEmail.Text & "',NULLIF('" & txtDirectorDOB.Text & "',''),'" & txtDirectorIDNumber.Text & "', '" & querRoll & "')", con)

                '"& Request.QueryString("ref") &"'
            End If
            'WriteLogFile(cmd.CommandText)
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            con.Open()
            Try
                If cmd.ExecuteNonQuery() Then
                    '
                    If Request.QueryString.AllKeys.Contains("cusNum") And Request.QueryString.AllKeys.Contains("bal") And
                              Request.QueryString.AllKeys.Contains("ref") Then

                        If Not String.IsNullOrEmpty(Request.QueryString("ref").ToString()) Then
                            saveTransaction(
                              Request.QueryString("ref").ToString(),
                              "Loan Rollover",
                               Double.Parse(Request.QueryString("bal").ToString()),
                              0,
                             "212/11",
                              txtCustNo.Text,
                              "1",
                              "",
                              "",
                              "",
                              "",
                              DateTime.Now,
                              DateTime.Now.ToString()
                              )
                        End If
                    End If

                    'updateDocLoanID(txtCustNo.Text)
                    'saveInitiatorComment()
                    Dim strEmail As String
                    Dim SignatoryEMail As String
                    'Dim SignatoryEMail As String = Mailhelper.GetMultiBranchRoleEMailID(Session("BRANCHCODE"), "4042")

                    strEmail = "<Strong>Dear Sir/Madam,</strong><br>You Have Received A New Loan Application Request. Details are as follows<br><br>"
                    strEmail = strEmail & "<Table bgcolor='444444'><font forecolor='ffffff'>"
                    strEmail = strEmail & "<tr bgcolor='999999'><td>Date:</td><td>" & Now.ToShortDateString & "</td></tr>"
                    strEmail = strEmail & "<tr bgcolor='eeeeee'><td>Applicant Type:</td><td>" & rdbClientType.SelectedValue & "</td></tr>"
                    strEmail = strEmail & "<tr bgcolor='999999'><td>Branch:</td><td>" & lblBranchCode.Text.Trim() & " - " & lblBranchName.Text.Trim() & "</td></tr>"
                    'strEmail = strEmail & "<tr bgcolor='999999'><td>Branch Name:</td><td>" & txt_BranchName.Text.Trim() & "</td></tr>"
                    strEmail = strEmail & "<tr bgcolor='999999'><td>Client Name:</td><td>" & txtRegdName.Text & "</td></tr>"
                    'strEmail = strEmail & "<tr bgcolor='999999'><td>Transaction Type:</td><td>" & ddl_TransactionTy.SelectedItem.Text.Trim() & "</td></tr>"
                    strEmail = strEmail & "<tr bgcolor='999999'><td>Amount:</td><td>" & txtFinReqAmt.Text & "</td></tr>"
                    strEmail = strEmail & "</font></Table>"
                    strEmail = strEmail & "<br/><Strong>Thanks & Regards,<br/>IT Support Team</strong>"
                    'If Trim(SignatoryEMail) = "" Then
                    SignatoryEMail = Mailhelper.GetMultipleEMailID("4042")
                    'End If
                    Mailhelper.SendMailMessage("administrator", SignatoryEMail, "", "", "Escrow Credit Management - Loan Application", strEmail)
                    clearALL()
                    ViewState("globLoanID") = getLastLoanID()
                    Dim EncQuery As New BankEncryption64
                    lblTest.Text = ViewState("globLoanID")
                    lblTestEnc.Text = EncQuery.Encrypt(ViewState("globLoanID").replace(" ", "+"))
                    'msgbox("Application saved. Loan ID is " & ViewState("globLoanID") & "")

                    ClientScript.RegisterStartupScript(Me.GetType(), "HideLabel", "<script type=""text/javascript"">showPopup()</script>")
                    'ClientScript.RegisterStartupScript(Me.GetType, "bootSaveAppInfo", "<script type='text/javascript'>alert('VCA Application submitted with ID " & ViewState("globVCAID") & "'); location.href = 'VCAApplication.aspx'</script>")
                End If
            Catch ex As Exception
                'WriteLogFile(cmd.CommandText)
                msgbox(ex.Message)
            End Try
            con.Close()
        Catch ex As Exception
            'WriteLogFile(cmd.CommandText)
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub saveTransaction(reference As String, description As String, debit As Double, credit As Double, account As String, contra As String, status As String, other As String, bankAccId As String, bankAccName As String, batchRef As String, trxnDate As Date, Optional receipt As String = Nothing)
        Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
            Using cmd As New SqlCommand("SaveAccountsTrxnsWithContra", con)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("@Type", "System Entry")
                cmd.Parameters.AddWithValue("@Category", "Loan Roll Over")
                cmd.Parameters.AddWithValue("@Ref", reference)
                cmd.Parameters.AddWithValue("@Desc", description)
                cmd.Parameters.AddWithValue("@Debit", debit)
                cmd.Parameters.AddWithValue("@Credit", credit)
                cmd.Parameters.AddWithValue("@Account", account)
                cmd.Parameters.AddWithValue("@ContraAccount", contra)
                cmd.Parameters.AddWithValue("@Status", status)
                cmd.Parameters.AddWithValue("@Other", other)
                cmd.Parameters.AddWithValue("@BankAccID", bankAccId)
                cmd.Parameters.AddWithValue("@BankAccName", bankAccName)
                cmd.Parameters.AddWithValue("@BatchRef", batchRef)
                cmd.Parameters.AddWithValue("@TrxnDate", trxnDate)
                cmd.Parameters.AddWithValue("@CaptureBy", Session("UserId"))
                cmd.Parameters.AddWithValue("@Receipt", receipt)

                If con.State = ConnectionState.Open Then
                    con.Close()
                End If
                con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            End Using
        End Using
    End Sub
    Protected Sub writeBranch()
        lblBranchCode.Text = Session("BRANCHCODE")
        lblBranchName.Text = Session("BRANCHNAME")
    End Sub

    Private Sub btnAddPurpose_Click(sender As Object, e As EventArgs) Handles btnAddPurpose.Click
        Try
            Using cmd = New SqlCommand("select * from PARA_PURPOSE where PURPOSE='" & txtPurpose.Text & "'", con)
                Dim ds As New DataSet
                adp = New SqlDataAdapter(cmd)
                adp.Fill(ds, "PRODUCTS")
                Dim cmdIns = New SqlCommand
                If ds.Tables(0).Rows.Count > 0 Then
                    'cmd = New SqlCommand("update PARA_PURPOSE set PURPOSE='" & BankString.removeSpecialCharacter(Trim(txtPurpose.Text)) & "', LOAN_MODIFIED_BY='" & Session("UserID") & "', LOAN_MODIFIED_DATE=getdate() where LOAN_SHORT_DESC='" & Trim(txtShortName.Text) & "'", con)
                Else
                    cmdIns = New SqlCommand("insert into PARA_PURPOSE ([PURPOSE]) values ('" & BankString.removeSpecialCharacter(Trim(txtPurpose.Text)) & "')", con)
                End If
                If con.State = ConnectionState.Open Then
                    con.Close()
                End If
                con.Open()
                cmdIns.ExecuteNonQuery()
                con.Close()
                CreditManager.notify("New purpose entered", "success")
                txtPurpose.Text = ""
                loadPurpose(cmbFinReqPurpose)
            End Using
        Catch ex As Exception
            ErrorLogging.WriteLogFile(Session("UserId"), "Credit/ApplicationForm.aspx -- btnAddPurpose()", ex.Message)
        End Try
    End Sub
    Protected Sub txtSearchSurname_TextChanged(sender As Object, e As EventArgs) Handles txtSearchSurname.TextChanged

    End Sub
End Class