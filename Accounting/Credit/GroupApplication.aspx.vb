Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports CreditManager
Imports ErrorLogging

Partial Class Credit_GroupApplication
    Inherits System.Web.UI.Page

    Protected Sub btnSearchGroup_Click(sender As Object, e As EventArgs) Handles btnSearchGroup.Click
        Try
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd = New SqlCommand("select CUSTOMER_NUMBER, isnull(SURNAME,'')+' '+isnull(FORENAMES,'')+' --- '+isnull(CUSTOMER_NUMBER,'') as display from CUSTOMER_DETAILS where isnull(SURNAME,'')+' '+isnull(FORENAMES,'') like '%'+@nam+'%'", con)
                    cmd.Parameters.AddWithValue("@nam", txtSearchGroup.Text)
                    Dim ds As New DataSet
                    Using adp = New SqlDataAdapter(cmd)
                        adp.Fill(ds, "cust")
                    End Using
                    If ds.Tables(0).Rows.Count > 0 Then
                        lstGroup.Visible = True
                        lstGroup.DataSource = ds.Tables(0)
                        lstGroup.DataTextField = "display"
                        lstGroup.DataValueField = "CUSTOMER_NUMBER"
                    Else
                        lstGroup.DataSource = Nothing
                        CreditManager.notify("The searched name was not found", "error")
                    End If
                    'clearAll()
                    lstGroup.DataBind()
                End Using
            End Using
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- btnSearchGroup_Click()", ex.ToString)
        End Try
    End Sub

    Protected Function getGrpTotalAmt() As Double
        Try
            Dim totAmt = 0
            For Each member As RepeaterItem In repGrpMembers.Items
                Dim amt As String = CType(member.FindControl("txtGrpMemberAmt"), TextBox).Text
                If IsNumeric(amt) Then
                    totAmt = totAmt + amt
                End If
            Next
            Return totAmt
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Protected Sub saveGrpMemberAmts(cust As String, loanID As String)
        Try
            For Each member As RepeaterItem In repGrpMembers.Items
                Dim memberID As String = CType(member.FindControl("lblGrpMemberID"), Label).Text
                Dim memberName As String = CType(member.FindControl("lblGrpMemberName"), Label).Text
                Dim amt As String = CType(member.FindControl("txtGrpMemberAmt"), TextBox).Text
                Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                    Dim cmd1 As New SqlCommand("insert into [QUEST_GROUP_APPLICATION] ([CUST_NO],[LOAN_ID],[MEMBER_ID],[MEMBER_NAME],[AMOUNT]) values ('" & cust & "','" & loanID & "','" & memberID & "','" & memberName & "','" & amt & "')", con)
                    If con.State <> ConnectionState.Closed Then
                        con.Close()
                    End If
                    con.Open()
                    cmd1.ExecuteNonQuery()
                    con.Close()
                End Using
            Next
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- saveGrpMemberAmts()", ex.ToString)
        End Try
    End Sub
    Protected Sub lstGroup_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstGroup.SelectedIndexChanged
        Try
            'get group members
            txtGrpAccNo.Text = lstGroup.SelectedValue
            lblGrpChair.Text = ""
            lblGrpMembers.Text = ""
            getGroupInfo(txtGrpAccNo.Text)
            getGroupMembers(txtGrpAccNo.Text)
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- lstGroup_SelectedIndexChanged()", ex.ToString)
        End Try
    End Sub

    Protected Sub getGroupInfo(custNo As String)
        Try
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd As New SqlCommand("select * from CUSTOMER_DETAILS cd WHERE cd.CUSTOMER_NUMBER=@gAcc", con)
                    cmd.Parameters.AddWithValue("@gAcc", custNo)
                    Dim dt As New DataTable
                    Using adp As New SqlDataAdapter(cmd)
                        adp.Fill(dt)
                    End Using
                    If dt.Rows.Count > 0 Then
                        txtGrpName.Text = dt.Rows(0).Item("SURNAME")
                        loadUploadedFiles(custNo)
                    End If
                End Using
            End Using
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- getGroupInfo()", ex.ToString)
        End Try
    End Sub

    Protected Sub getGroupMembers(custNo As String)
        Try
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd As New SqlCommand("select *,isnull(FORENAMES,'')+' '+isnull(SURNAME,'') as Name from GroupMembership gm JOIN CUSTOMER_DETAILS cd on gm.MemberAccNo=CD.CUSTOMER_NUMBER WHERE gm.GroupAccNo=@gAcc", con)
                    cmd.Parameters.AddWithValue("@gAcc", custNo)
                    Dim dt As New DataTable
                    Using adp As New SqlDataAdapter(cmd)
                        adp.Fill(dt)
                    End Using
                    If dt.Rows.Count > 0 Then
                        For Each row As DataRow In dt.Rows
                            If row("MemberType") = "Chairperson" Or row("MemberType") = "Chairman" Then
                                lblGrpChair.Text = row("FORENAMES") + " " + row("SURNAME")
                            Else
                                If lblGrpMembers.Text = "" Then
                                    lblGrpMembers.Text = lblGrpMembers.Text + row("FORENAMES") + " " + row("SURNAME")
                                Else
                                    lblGrpMembers.Text = lblGrpMembers.Text + ", " + row("FORENAMES") + " " + row("SURNAME")
                                End If
                            End If
                        Next
                        repGrpMembers.DataSource = dt
                        repGrpMembers.DataBind()
                    End If
                End Using
            End Using
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- getGroupMembers()", ex.ToString)
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
    Protected Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Try
            If CDbl(txtFinReqIntRate.Text) > CDbl(ViewState("MaxIntRate")) Then
                notify("Interest rate greater than the maximum allowed for this product", "error")
                Exit Sub
            ElseIf CDbl(txtFinReqIntRate.Text) < CDbl(ViewState("MinIntRate")) Then
                notify("Interest rate less than minimum allowed for this product", "error")
                Exit Sub
            ElseIf Val(txtFinReqAmt.Text) > Val(ViewState("MaxAmt")) Or Val(txtFinReqAmt.Text) < Val(ViewState("MinAmt")) Then
                notify("Required amount out of the range for this product", "error")
                Exit Sub
            ElseIf CDbl(txtFinReqTenor.Text) > CDbl(ViewState("MaximumTenure")) Or CDbl(txtFinReqTenor.Text) < CDbl(ViewState("MinimumTenure")) Then
                notify("Loan tenure out of the range for this product", "error")
                Exit Sub
            End If
            getNextApproval(1)
            If toMoney(txtFinReqAmt.Text) <> toMoney(getGrpTotalAmt) Then
                notify("Applied amount and member breakdown do not match", "error")
                Exit Sub
            End If
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd = New SqlCommand("insert into QUEST_APPLICATION ([FIN_REPAY_DATE],[APPL_DATE],[FinProductType],[CUSTOMER_TYPE],[CUSTOMER_NUMBER],[SURNAME],[FORENAMES],[IDNO],[ADDRESS],[CITY],[PHONE_NO],[NATIONALITY],[GENDER],[BUS_TYPE],[BUS_PERIOD],[SOURCE1],[SOURCE2],[SOURCE3],[BORROWING1],[BORROWING2],[BORROWING3],[FIN_AMT],[FIN_TENOR],[FIN_PURPOSE],[FIN_INT_RATE],[CREATED_BY],[CREATED_DATE],[MODIFIED_BY],[MODIFIED_DATE],[STATUS],[SEND_TO],[LO_ID],[LAST_ID],[AMT_APPLIED],[FIN_ADMIN],[BRANCH_CODE],[BRANCH_NAME],[ReadyToDisburse],[ApprovalNumber],RepaymentIntervalNum,RepaymentIntervalUnit,ADMIN_RATE,RECOMMENDED_AMT,GroupChairman,GroupMembers) values ('" & txtFinReqRepaymt.Text & "','" & txtApplicationDate.Text & "','" & cmbProductType.SelectedValue & "','Group','" & txtGrpAccNo.Text & "','" & BankString.removeSpecialCharacter(txtGrpName.Text) & "','','','','','','','','',nullif('',''),'','','','','','',nullif('" & txtFinReqAmt.Text & "',''),nullif('" & txtFinReqTenor.Text & "',''),'" & BankString.removeSpecialCharacter(cmbFinReqPurpose.SelectedValue) & "',nullif('" & txtFinReqIntRate.Text & "',''),'" & Session("UserID") & "',getdate(),'','','SUBMITTED','" & ViewState("NextRole") & "','" & Session("ID") & "','" & Session("ID") & "',nullif('" & txtFinReqAmt.Text & "',''),nullif('" & txtAdminRate.Text & "',''),'" & lblBranchCode.Text & "','" & BankString.removeSpecialCharacter(lblBranchName.Text) & "','" & ViewState("ReadyToDisburse") & "',1,NULLIF('" & txtRepaymentInterval.Text & "',''),'" & cmbRepaymentInterval.SelectedValue & "',nullif('" & toMoney(txtAdminRate.Text) & "',''),nullif('" & toMoney(txtFinReqAmt.Text) & "',''),@GroupChairman,@GroupMembers)", con)
                    cmd.Parameters.AddWithValue("@GroupChairman", lblGrpChair.Text)
                    cmd.Parameters.AddWithValue("@GroupMembers", lblGrpMembers.Text)
                    If con.State = ConnectionState.Open Then
                        con.Close()
                    End If
                    'WriteLogFile(cmd.CommandText)
                    con.Open()
                    If cmd.ExecuteNonQuery() Then
                        ViewState("globLoanID") = getLastLoanID()
                        For Each member As RepeaterItem In repGrpMembers.Items
                            Dim cstNo As String = ""
                            cstNo = DirectCast(member.FindControl("lblGrpMemberCustNo"), Label).Text
                            Dim amt = DirectCast(member.FindControl("txtGrpMemberAmt"), TextBox).Text
                            Using conMember As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                                'call stored procedure to create individual loan application
                                Using cmdMember As New SqlCommand("generateIndividualApplication", conMember)
                                    cmdMember.CommandType = CommandType.StoredProcedure
                                    cmdMember.Parameters.AddWithValue("@mainLoanID", ViewState("globLoanID"))
                                    cmdMember.Parameters.AddWithValue("@custNo", cstNo)
                                    cmdMember.Parameters.AddWithValue("@amount", amt)
                                    conMember.Open()
                                    cmdMember.ExecuteNonQuery()
                                    conMember.Close()
                                End Using
                            End Using
                        Next
                        updateDocLoanID(txtGrpAccNo.Text)
                        Dim strEmail As String
                        Dim SignatoryEMail As String
                        SignatoryEMail = Mailhelper.GetMultipleEMailID(ViewState("NextRole"))

                        strEmail = "Dear Sir/Madam,<br/><br/>You have received a request for " & ViewState("NextStageName") & ". Details of the application are as follows<br><br>"
                        strEmail = strEmail & "<table style='border: 1px solid black; width:750px;border-collapse: collapse; font-size:13px'>"
                        strEmail = strEmail & "<tr style='background-color: #f5f5f5;padding: 15px;text-align: left;'><th style='border: 1px solid black;text-align: left;'>Group Name:</th><td style='border: 1px solid black;'>" & txtGrpName.Text & "</td></tr>"
                        strEmail = strEmail & "<tr style='background-color: white;padding: 15px;text-align: left;'><th style='border: 1px solid black;text-align: left;'>Date:</th><td style='border: 1px solid black;'>" & txtApplicationDate.Text & "</td></tr>"
                        strEmail = strEmail & "<tr style='background-color: #f5f5f5;padding: 15px;text-align: left;'><th style='border: 1px solid black;text-align: left;'>Applicant Type:</th><td style='border: 1px solid black;'>Group</td></tr>"
                        strEmail = strEmail & "<tr style='background-color: white;padding: 15px;text-align: left;'><th style='border: 1px solid black;text-align: left;'>Product:</th><td style='border: 1px solid black;'>" & cmbProductType.SelectedItem.Text.ToString & "</td></tr>"
                        strEmail = strEmail & "<tr style='background-color: white;padding: 15px;text-align: left;'><th style='border: 1px solid black;text-align: left;'>Branch:</th><td style='border: 1px solid black;'>" & lblBranchCode.Text.Trim() & " - " & lblBranchName.Text.Trim() & "</td></tr>"
                        strEmail = strEmail & "<tr style='background-color: #f5f5f5;padding: 15px;text-align: left;'><th style='border: 1px solid black;text-align: left;'>Amount:</th><td style='border: 1px solid black;'>" & FormatCurrency(txtFinReqAmt.Text).ToString.Replace("Z", "US") & "</td></tr>"
                        strEmail = strEmail & "</table>"
                        strEmail = strEmail & "<br/>Thanks & Regards,<br/><b>Escrow 360 Support Team</b>"

                        If SignatoryEMail = "" Then
                        Else
                            Mailhelper.SendMailMessage("administrator", SignatoryEMail, "", "", "Escrow Credit Management - Loan Application Request", strEmail)
                        End If
                        saveGrpMemberAmts(txtGrpAccNo.Text, ViewState("globLoanID"))
                        saveInitiatorCommentGrp()
                        clearGroup()
                        Dim EncQuery As New BankEncryption64
                        lblTest.Text = ViewState("globLoanID")
                        lblTestEnc.Text = EncQuery.Encrypt(ViewState("globLoanID").replace(" ", "+"))

                        ClientScript.RegisterStartupScript(Me.GetType(), "HideLabel", "<script type=""text/javascript"">showPopup()</script>")
                    End If
                    con.Close()
                End Using
            End Using
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- btnSubmit_Click()", ex.ToString)
        End Try
    End Sub

    Protected Sub updateDocLoanID(custNo As String)
        Try
            If btnSubmit.Text = "Update Application" Then
            Else
                'ViewState("globLoanID") = getLastLoanID()
            End If
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd = New SqlCommand("update QUEST_DOCUMENTS set LOAN_ID='" & ViewState("globLoanID") & "' where CUST_NO='" & custNo & "' and (LOAN_ID='' or LOAN_ID is null or LOAN_ID='0')  update ClientCollateral set LOANID='" & ViewState("globLoanID") & "' where CUSTNO='" & custNo & "' and (LOANID is null or LOANID='0')  update [QUEST_OTHER_LOANS] set LoanID='" & ViewState("globLoanID") & "' where [CUSTOMER_NUMBER]='" & custNo & "' and (LoanID is null or LoanID='0')", con)
                    If con.State = ConnectionState.Open Then
                        con.Close()
                    End If
                    con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                End Using
            End Using
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- updateDocLoanID()", ex.ToString)
        End Try
    End Sub

    Protected Sub getNextApproval(currLevel As Integer)
        Try
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd = New SqlCommand("select * from [ParaApprovalStages] where [StageOrder]='" & currLevel & "' AND FinProductType='" & cmbProductType.SelectedValue & "'", con)
                    Dim ds As New DataSet
                    Dim adp = New SqlDataAdapter(cmd)
                    adp.Fill(ds, "PAS")
                    If ds.Tables(0).Rows.Count > 0 Then
                        Dim dr = ds.Tables(0).Rows(0)
                        ViewState("StageName") = dr("StageName")
                    End If
                End Using
                Using cmd = New SqlCommand("select * from [ParaApprovalStages] where [StageOrder]='" & currLevel + 1 & "' AND FinProductType='" & cmbProductType.SelectedValue & "'", con)
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

    Protected Function getLastLoanID() As String
        Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
            'Using cmd = New SqlCommand("select max(ID) from QUEST_APPLICATION", con)
            Using cmd = New SqlCommand("select max(ID) from QUEST_APPLICATION where isnull(IsGroupLoan,0)=0", con)
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
        End Using
    End Function

    Protected Sub saveInitiatorCommentGrp()
        Try
            ViewState("globLoanID") = getLastLoanID()
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd = New SqlCommand("insert into REQUEST_HISTORY (LOANID,COMMENT_DATE,USERID,COMMENT,RECOMMENDED_AMT) values('" & ViewState("globLoanID") & "',GETDATE(),'" & Session("UserID") & "','','" & txtFinReqAmt.Text & "')", con)
                    If con.State = ConnectionState.Open Then
                        con.Close()
                    End If
                    con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                End Using
            End Using
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- saveInitiatorCommentGrp()", ex.ToString)
        End Try
    End Sub

    Protected Sub clearGroup()
        txtGrpAccNo.Text = ""
        txtGrpName.Text = ""
        lblGrpMembers.Text = ""
        lblGrpChair.Text = ""
    End Sub

    Protected Sub writeBranch()
        lblBranchCode.Text = Session("BRANCHCODE")
        lblBranchName.Text = Session("BRANCHNAME")
    End Sub

    Private Sub Credit_GroupApplication_Load(sender As Object, e As EventArgs) Handles Me.Load
        Page.MaintainScrollPositionOnPostBack = True
        If Not IsPostBack Then
            writeBranch()
            loadPurpose(cmbFinReqPurpose)
            loadProductType(cmbProductType)
            If Not processFlowSaved() Then
            ElseIf Not internalControlsSaved() Then

            End If
            Dim EncQuery As New BankEncryption64
            Try
                ViewState("restoreID") = EncQuery.Decrypt(Request.QueryString("id").Replace(" ", "+"))
                ViewState("isRestore") = EncQuery.Decrypt(Request.QueryString("s").Replace(" ", "+"))
                If ViewState("isRestore") = "1" Then
                    'getNamesDT(getSavedSession(ViewState("restoreID")))
                End If
            Catch ex As Exception
            End Try
            If Request.QueryString("rej") = 1 Then
                ViewState("globLoanID") = EncQuery.Decrypt(Request.QueryString("id").Replace(" ", "+"))
                'getAppHistory()
                'getAppDetails(ViewState("globLoanID"))
                'writeSubmitButton(Session("ROLE"))
                'btnTerminate.Visible = True
                'lnkViewAppForm.NavigateUrl = "Amortization.aspx?ID=" & EncQuery.Encrypt(ViewState("globLoanID").Replace(" ", "+")) & "&App=1"
                'lnkViewAppForm.Visible = True
                'lnkAppRating.NavigateUrl = "ApplicationRating.aspx?loanID=" & EncQuery.Encrypt(ViewState("globLoanID").Replace(" ", "+"))
                'lnkAppRating.Visible = True
                'If amortizationAlreadyCreated(ViewState("globLoanID")) Then
                '    lnkAmortizationSchedule.NavigateUrl = "rptAmortizationSchedule.aspx?loanID=" & EncQuery.Encrypt(ViewState("globLoanID").Replace(" ", "+"))
                '    lnkAmortizationSchedule.Visible = True
                'End If
                'loadUploadedFilesRej(ViewState("globLoanID"))
            End If
        End If
    End Sub

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

    Protected Sub loadPurpose(ByVal cmbPurpose As DropDownList)
        Try
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd = New SqlCommand("select * from PARA_PURPOSE", con)
                    Dim ds As New DataSet
                    Using adp = New SqlDataAdapter(cmd)
                        adp.Fill(ds, "purpose")
                    End Using
                    CreditManager.loadCombo(ds.Tables(0), cmbPurpose, "PURPOSE", "PURPOSE")
                End Using
            End Using
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- loadPurpose()", ex.ToString)
        End Try
    End Sub
    Protected Function processFlowSaved() As Boolean
        Try
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                'Using cmd = New SqlCommand("select * from ParaApprovalStages", con)
                Using cmd = New SqlCommand("select * from ParaApprovalStages where FinProductType='" & cmbProductType.SelectedValue & "'", con)
                    Dim ds As New DataSet
                    Dim adp = New SqlDataAdapter(cmd)
                    adp.Fill(ds, "PAS")
                    If ds.Tables(0).Rows.Count > 1 Then
                        Return True
                    Else
                        Return False
                    End If
                End Using
            End Using
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- processFlowSaved()", ex.ToString)
            Return False
        End Try
    End Function

    Protected Function internalControlsSaved() As Boolean
        Try
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd = New SqlCommand("select * from ParaInternalControls", con)
                    Dim ds As New DataSet
                    Dim adp = New SqlDataAdapter(cmd)
                    adp.Fill(ds, "PAS")
                    If ds.Tables(0).Rows.Count > 0 Then
                        Dim dr = ds.Tables(0).Rows(0)
                        ViewState("MaxExposure") = dr("MaxExposure")
                        ViewState("MaxNoLoans") = dr("MaxNoLoans")
                        ViewState("PrePopulateGuarantor") = dr("PrePopulateGuarantor")
                        Return True
                    Else
                        notify("You must first save Internal Controls before proceeding", "error")
                        Return False
                    End If
                End Using
            End Using
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- internalControlsSaved()", ex.ToString)
            notify("You must first save Internal Controls before proceeding", "error")
            Return False
        End Try
    End Function

    Private Sub cmbProductType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbProductType.SelectedIndexChanged
        getProductDefaults(cmbProductType.SelectedValue)
        getCreditParams(cmbProductType.SelectedValue)
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

    Protected Sub loadUploadedFilesApp(custNo As String)
        Try
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd = New SqlCommand("select * from QUEST_DOCUMENTS where CUST_NO='" & custNo & "' and (LOAN_ID='' or LOAN_ID is NULL)", con)
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
    Protected Sub btnUploadApp_Click(sender As Object, e As EventArgs) Handles btnUploadApp.Click
        Try
            Dim filePath As String = filAttachApp.PostedFile.FileName
            Dim filename As String = Path.GetFileName(filePath)
            Dim ext As String = Path.GetExtension(filename)
            Dim contenttype As String = String.Empty
            'Set the contenttype based on File Extension
            Select Case ext
                Case ".doc"
                    contenttype = "application/msword"
                    Exit Select
                Case ".docx"
                    contenttype = "application/msword"
                    Exit Select
                Case ".xls"
                    contenttype = "application/x-msexcel"
                    Exit Select
                Case ".xlsx"
                    contenttype = "application/x-msexcel"
                    Exit Select
                Case ".jpg"
                    contenttype = "image/jpg"
                    Exit Select
                Case ".png"
                    contenttype = "image/png"
                    Exit Select
                Case ".gif"
                    contenttype = "image/gif"
                    Exit Select
                Case ".pdf"
                    contenttype = "application/pdf"
                    Exit Select
            End Select

            If contenttype <> String.Empty Then
                Dim fs As Stream = filAttachApp.PostedFile.InputStream
                Dim br As New BinaryReader(fs)
                Dim bytes As Byte() = br.ReadBytes(fs.Length)

                'insert the file into database
                Dim strQuery As String = "insert into QUEST_DOCUMENTS" _
                & "(CUST_NO, LOAN_ID, DOC_DESC, DOC_DATA, DOC_TYPE, DOC_EXT, DOC_FILENAME)" _
                & " values (@CUST_NO, @LOAN_ID,@DOC_DESC, @DOC_DATA,@DOC_TYPE,@DOC_EXT, @DOC_FILENAME)"
                Dim cmd As New SqlCommand(strQuery)
                cmd.Parameters.Add("@CUST_NO", SqlDbType.VarChar).Value = txtGrpAccNo.Text
                cmd.Parameters.Add("@LOAN_ID", SqlDbType.VarChar).Value = "" 'yet to be determined at this stage. Must be updated at form submit
                cmd.Parameters.Add("@DOC_FILENAME", SqlDbType.VarChar).Value = filename
                cmd.Parameters.Add("@DOC_DESC", SqlDbType.VarChar).Value = txtDocDesc.Text
                cmd.Parameters.Add("@DOC_EXT", SqlDbType.VarChar).Value = ext
                cmd.Parameters.Add("@DOC_TYPE", SqlDbType.VarChar).Value = contenttype
                cmd.Parameters.Add("@DOC_DATA", SqlDbType.Binary).Value = bytes
                If InsertUpdateData(cmd) Then
                    txtDocDesc.Text = ""
                    loadUploadedFilesApp(txtGrpAccNo.Text)
                    notify("File uploaded successfully", "success")
                Else
                    notify("An error occurred while uploading the file", "error")
                End If
            Else
                notify("Select the file to upload", "error")
            End If
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- btnUploadApp_Click()", ex.ToString)
        End Try
    End Sub

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
            Response.Write(ex.ToString)
            Return False
        Finally
            con.Close()
            con.Dispose()
        End Try
    End Function

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
