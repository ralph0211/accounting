Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports CreditManager
Imports ErrorLogging

Partial Class Credit_AgreementLetters
    Inherits System.Web.UI.Page
    Public Shared firstPayDate, paymentDate As Date
    Public Shared globLoanID As Double = 0
    Public Shared intRate, monthlyPrincipal, loanAmount, paymentPeriod, finalMonthlyPayment, interest As Double
    Public Shared isApproval As Double = 0
    Shared adp As New SqlDataAdapter
    Shared cmd As SqlCommand
    Shared con As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
    Shared isFarmer As String

    Public Sub clearAmortization(ByVal loanID As Double)
        Try
            cmd = New SqlCommand("select * from amortization_schedule where LOANID='" & loanID & "'", con)
            Dim ds As New DataSet
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "AMORT")
            If ds.Tables(0).Rows.Count > 0 Then
                cmd = New SqlCommand("delete from amortization_schedule where LOANID='" & loanID & "'", con)
                If con.State = ConnectionState.Open Then
                    con.Close()
                End If
                con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Else

            End If
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

    Protected Sub btnSaveCreditParameters_Click(sender As Object, e As EventArgs) Handles btnSaveCreditParameters.Click

        ''cmd = New SqlCommand("update QUEST_APPLICATION set [REPAYMENT_OPTION]='" & rdbRepayOption.SelectedValue & "',[REPAYMENT_PERIOD]='" & txtRepayPeriod.Text & "',[INTEREST_RATE]='" & convertToSaveFormat(txtIntRate.Text) & "',[FIRST_REPAYMENT_DATE]='" & DateFormat.getSaveDate(bdp1stPayDate.SelectedDate.ToShortDateString) & "' where ID='" & txtLoanID.Text & "'", con)
        'cmd = New SqlCommand("update QUEST_APPLICATION set [FIN_REPAY_OPT]='" & rdbRepayOption.SelectedValue & "',[FIN_TENOR]='" & txtRepayPeriod.Text & "',[FIN_INT_RATE]='" & txtIntRate.Text & "',[FIN_ADMIN]='" & txtAdminCharge.Text & "',[FIN_REPAY_DATE]='" & txt1stPayDate.Text & "' where ID='" & ViewState("globLoanID") & "'", con)
        ''msgbox(cmd.CommandText)
        'If con.State = ConnectionState.Open Then
        '    con.Close()
        'End If
        'con.Open()
        Try
            'cmd.ExecuteNonQuery()
            ''msgbox("Repayment instructions saved")
            createAmortizationOptions(ViewState("globLoanID"))
            'Response.Redirect("AgreementLetters.aspx?ID=" & ViewState("globLoanID") & "&pop=1", False)
        Catch ex As Exception
            ErrorLogging.WriteLogFile(Session("UserId"), "AgreementLetters", ex.Message)
            CreditManager.notify("Error creating amortization schedule", "error")
            'Response.Redirect("AgreementLetters.aspx?ID=" & ViewState("globLoanID") & "&pop=0", False)
            'ClientScript.RegisterStartupScript(Me.GetType(), "Gritter", "<script type=""text/javascript"">$.gritter.add({title: 'Error saving instruction!',text: 'The amortization instructions could not be saved. Please make sure all parameters are entered correctly with the right format and try again.',image: 'images/error_button.png'});</script>")
        Finally
            con.Close()
        End Try
    End Sub

    Protected Sub btnSearchLoanID_Click(sender As Object, e As EventArgs) Handles btnSearchLoanID.Click
        Try
            If Trim(Session("SessionID")) = "" Or IsDBNull(Session("SessionID")) Then
                Response.Redirect("~/logout.aspx")
            ElseIf Trim(txtLoanID.Text) = "" Or Not IsNumeric(txtLoanID.Text) Then
                notify("Enter a valid loan ID", "error")
            Else
                ViewState("globLoanID") = txtLoanID.Text
                If isAmortized(txtLoanID.Text) = 0 Then
                    notify("Requested Loan ID not found", "error")
                ElseIf isAmortized(txtLoanID.Text) = 2 Then
                    loadAgreements()
                ElseIf isAmortized(txtLoanID.Text) = 1 Then
                    notify("This loan application has not yet been amortized. Create amortization schedule first.", "warning")
                    ClientScript.RegisterStartupScript(Me.GetType(), "showAmortization", "<script type=""text/javascript"">showAmortization();</script>")
                End If
                'End If
                'SecureBank.recordAction(btnSearchLoanID.ID.ToString, "Searched by Loan ID")
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub btnSearchName_Click(sender As Object, e As EventArgs) Handles btnSearchName.Click
        Try
            'SecureBank.recordAction(btnSearchName.ID.ToString, "Searched by Name")
            clearAgreements()
            cmd = New SqlCommand("select ID,SURNAME+' '+FORENAMES+' --- '+convert(varchar,CUSTOMER_NUMBER)+' --- '+ADDRESS+' --- '+convert(varchar,format(FIN_AMT,'c')) as DISPLAY from QUEST_APPLICATION where SURNAME like '" & txtSearchName.Text & "%' and [STATUS]<>'REJECTED'", con)
            Dim ds As New DataSet
            Dim adp As New SqlDataAdapter
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "LOANS")
            If ds.Tables(0).Rows.Count > 0 Then
                lstLoans.DataSource = ds.Tables(0)
                lstLoans.DataTextField = "DISPLAY"
                lstLoans.DataValueField = "ID"
                lstLoans.Visible = True
            Else
                lstLoans.DataSource = Nothing
                lstLoans.Visible = False
                'msgbox("Search name not found")
                ClientScript.RegisterStartupScript(Me.GetType(), "Gritter", "<script type=""text/javascript"">$.gritter.add({title: 'Name not found!',text: 'There is no record which matches the entered name.',image: 'images/error_button.png'});</script>")
                txtLoanID.Text = ""
            End If
            lstLoans.DataBind()
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub clearAgreements()
        repAgreements.DataSource = Nothing
        repAgreements.DataBind()
    End Sub

    Protected Function convertWeekendToFriday(payDate As Date) As Date
        While payDate.DayOfWeek = DayOfWeek.Saturday Or payDate.DayOfWeek = DayOfWeek.Sunday Or isHoliday(payDate)
            payDate = payDate.AddDays(-1)
        End While
        Return payDate
    End Function

    Protected Sub createAmortizationOptions(ByVal loanID As String)
        Try
            cmd = New SqlCommand("select * from QUEST_APPLICATION where ID='" & loanID & "'", con)
            Dim ds As New DataSet
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "LOANS")
            If ds.Tables(0).Rows.Count > 0 Then
                cmd = New SqlCommand("sp_amortize_balance_daily", con)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("@loanID", loanID)
                'End If
                If con.State <> ConnectionState.Closed Then
                    con.Close()
                End If
                con.Open()
                If cmd.ExecuteNonQuery() Then
                    CreditManager.notify("Amortization created", "success")
                End If
                con.Close()
            End If
        Catch ex As Exception
            'amortizeNormal(loanID)
            ErrorLogging.WriteLogFile(Session("UserId"), Request.Url.ToString & " --- createAmortizationOptions()", ex.ToString)
        End Try
    End Sub

    Protected Function isAmortized(loanID As String) As Integer
        Dim cmdApp = New SqlCommand("select * from QUEST_APPLICATION where ID='" & loanID & "'", con)
        Dim dsApp As New DataSet
        adp = New SqlDataAdapter(cmdApp)
        adp.Fill(dsApp, "qa")
        If dsApp.Tables(0).Rows.Count > 0 Then
            cmd = New SqlCommand("select * from AMORTIZATION_SCHEDULE where LOANID='" & loanID & "'", con)
            Dim ds As New DataSet
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "armo")
            If ds.Tables(0).Rows.Count > 0 Then
                Return 2
            Else
                Return 1
            End If
        Else
            Return 0
        End If

    End Function

    Protected Function isHoliday(payDate As Date) As Boolean
        cmd = New SqlCommand("select ID from HOLIDAYS where HOLIDAY_DATE='" & payDate & "'", con)
        Dim ds As New DataSet
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "holiday")
        If ds.Tables(0).Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Protected Function isLoanOfficer() As Boolean
        'cmd = New SqlCommand("select * from AMORTIZATION_SCHEDULE where LOANID='" & userID & "'", con)
        'Dim ds As New DataSet
        'adp = New SqlDataAdapter(cmd)
        'adp.Fill(ds, "armo")
        'If ds.Tables(0).Rows.Count > 0 Then
        '    Return True
        'Else
        '    Return False
        'End If
        If Session("ROLE") = "4041" Then
            Return True
        Else
            Return False
        End If
    End Function

    Protected Sub loadAgreements()
        Try
            cmd = New SqlCommand("select isnull([SUB_INDIVIDUAL],'') as [SUB_INDIVIDUAL],[FIN_AMT],[FIN_TENOR],[FIN_INT_RATE],[FIN_ADMIN],[FIN_REPAY_DATE],[FIN_REPAY_OPT],[CUSTOMER_TYPE],[CUSTOMER_NUMBER],[MD_ID],ISNULL(ASSET_NAME,'') as [ASSET_NAME] from QUEST_APPLICATION where ID='" & txtLoanID.Text & "' and [STATUS]<>'REJECTED'", con)
            'msgbox(cmd.CommandText)
            Dim ds As New DataSet
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "CREDIT")
            repAgreements.DataSource = Nothing
            repAgreements.DataBind()
            If ds.Tables(0).Rows.Count > 0 Then
                Try
                    Dim EncQuery As New BankEncryption64
                    Dim dt As New DataTable
                    dt.Columns.Add("navURL")
                    dt.Columns.Add("lnkText")
                    'If IsDBNull(ds.Tables(0).Rows(0).Item("MD_ID")) Then
                    '    msgbox("This application has not yet been approved")
                    'Else
                    If Trim(ds.Tables(0).Rows(0).Item("ASSET_NAME")) <> "" Then
                        'dt.Rows.Add("rptAcknowledgement.aspx?id=" & txtLoanID.Text & "&asset=1", "Acknowledgement of Debt")
                        'dt.Rows.Add("rptAssetFinancing.aspx?id=" & txtLoanID.Text & "&asset=1", "Agreement Letters")
                        dt.Rows.Add("rptAcknowledgeSSB.aspx?id=" & EncQuery.Encrypt(txtLoanID.Text.Replace(" ", "+")) & "", "Agreement Letter")

                    ElseIf ds.Tables(0).Rows(0).Item("CUSTOMER_TYPE") = "Group" Then
                        'dt.Rows.Add("rptFormLetter.aspx?id=" & txtLoanID.Text & "&typ=grp&cust=" & ds.Tables(0).Rows(0).Item("CUSTOMER_NUMBER") & "", "Form Letter")
                        ' dt.Rows.Add("rptAcknowledgement.aspx?id=" & txtLoanID.Text & "&typ=grp&cust=" & ds.Tables(0).Rows(0).Item("CUSTOMER_NUMBER") & "", "Agreement Letters")
                        dt.Rows.Add("rptAcknowledgeSSB.aspx?id=" & EncQuery.Encrypt(txtLoanID.Text.Replace(" ", "+")) & "", "Agreement Letter")
                    Else
                        If ds.Tables(0).Rows(0).Item("SUB_INDIVIDUAL") = "SSB" Then
                            'dt.Rows.Add("SSBSalaryDeduction.aspx?id=" & txtLoanID.Text & "", "SSB Deduction Form")
                            'dt.Rows.Add("rptFormLetter.aspx?id=" & txtLoanID.Text & "", "Form Letter")
                            dt.Rows.Add("rptAcknowledgeSSB.aspx?id=" & EncQuery.Encrypt(txtLoanID.Text.Replace(" ", "+")) & "", "Agreement Letter")
                        Else
                            'dt.Rows.Add("rptFormLetter.aspx?id=" & txtLoanID.Text & "", "Form Letter")
                            ' dt.Rows.Add("rptAcknowledgement.aspx?id=" & txtLoanID.Text & "", "Agreement Letters")
                            dt.Rows.Add("rptAcknowledgeSSB.aspx?id=" & EncQuery.Encrypt(txtLoanID.Text.Replace(" ", "+")) & "", "Agreement Letter")
                        End If
                    End If
                    repAgreements.DataSource = dt
                    repAgreements.DataBind()
                    'End If
                Catch ex As Exception
                    msgbox(ex.Message)
                End Try
            Else
                'ClientScript.RegisterStartupScript(Me.GetType(), "Gritter", "<script type=""text/javascript"">$.gritter.add({title: 'Loan ID not found!',text: 'There is no record which matches the entered Loan ID.',image: 'images/error_button.png'});</script>")
            End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub loadRepayParameters()
        Try
            Dim settInt As String = ""
            Dim repayOpt As String = ""
            Dim firstPayDate As String = ""
            cmd = New SqlCommand("select [FIN_AMT],[FIN_TENOR],[FIN_INT_RATE],[ADMIN_RATE],convert(varchar(30),[FIN_REPAY_DATE],113) as [FIN_REPAY_DATE],[FIN_REPAY_OPT],[CUSTOMER_TYPE],RepaymentIntervalNum,RepaymentIntervalUnit from QUEST_APPLICATION where ID='" & ViewState("globLoanID") & "'", con)
            Dim ds As New DataSet
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "CREDIT")
            If ds.Tables(0).Rows.Count > 0 Then
                Try
                    txtRepayPeriod.Text = ds.Tables(0).Rows(0).Item("FIN_TENOR")
                    txtIntRate.Text = ds.Tables(0).Rows(0).Item("FIN_INT_RATE")
                    bdp1stPayDate.Text = ds.Tables(0).Rows(0).Item("FIN_REPAY_DATE")
                    txtAdminCharge.Text = ds.Tables(0).Rows(0).Item("ADMIN_RATE")
                    Try
                        txtLoanAmt.Text = FormatNumber(ds.Tables(0).Rows(0).Item("FIN_AMT"), 2)
                    Catch ex As Exception
                        txtLoanAmt.Text = ""
                    End Try
                    Try
                        txtRepaymentInterval.Text = ds.Tables(0).Rows(0).Item("RepaymentIntervalNum")
                    Catch ex As Exception
                        txtRepaymentInterval.Text = ""
                    End Try
                    Try
                        cmbRepaymentInterval.SelectedValue = ds.Tables(0).Rows(0).Item("RepaymentIntervalUnit")
                    Catch ex As Exception
                        cmbRepaymentInterval.ClearSelection()
                    End Try
                    If ds.Tables(0).Rows(0).Item("CUSTOMER_TYPE") = "Farmer" Then
                        isFarmer = "1"
                    End If
                Catch ex As Exception
                    'msgbox(ex.Message)
                End Try
            Else
                'ClientScript.RegisterStartupScript(Me.GetType(), "Gritter", "<script type=""text/javascript"">$.gritter.add({title: 'Loan ID not found!',text: 'There is no record which matches the entered Loan ID.',image: 'images/error_button.png'});</script>")
            End If
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- loadRepayParameters()", ex.ToString)
        End Try
    End Sub

    Protected Sub lstLoans_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstLoans.SelectedIndexChanged
        Try
            Dim loanID = lstLoans.SelectedValue
            txtLoanID.Text = loanID
            ViewState("globLoanID") = loanID
            loadRepayParameters()
            btnSearchLoanID_Click(sender, New EventArgs)
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- lstLoans_SelectedIndexChanged()", ex.ToString)
        End Try
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Page.MaintainScrollPositionOnPostBack = True
        If Not IsPostBack Then
            If Trim(Request.QueryString("ID")) = "" Then
            Else
                'If Request.QueryString("pop") = "1" Then
                '    ClientScript.RegisterStartupScript(Me.GetType(), "amortizationSuccess", "<script type=""text/javascript"">amortizationSuccess();</script>")
                'ElseIf Request.QueryString("pop") = "0" Then
                '    ClientScript.RegisterStartupScript(Me.GetType(), "amortizationError", "<script type=""text/javascript"">amortizationError();</script>")
                'End If
                Dim EncQuery As New BankEncryption64
                Try
                    ViewState("globLoanID") = EncQuery.Decrypt(Request.QueryString("ID").Replace(" ", "+"))
                Catch ex As Exception
                    ViewState("globLoanID") = Request.QueryString("ID")
                End Try
                isApproval = Request.QueryString("App")
                txtLoanID.Text = ViewState("globLoanID")
                If isApproval Then
                    lblReturnApproval.Text = "<a href='ApplicationApproval.aspx?id=" & EncQuery.Encrypt(ViewState("globLoanID").Replace(" ", "+")) & "'>Return to Loan Approval</a>"
                End If
                loadAgreements()
                'btnSearchLoanID_Click(sender, New EventArgs)
            End If
        End If
    End Sub
End Class