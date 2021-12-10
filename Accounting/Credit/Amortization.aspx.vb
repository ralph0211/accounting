Imports System.Data
Imports System.Data.SqlClient
Imports ErrorLogging

Partial Class Credit_Amortization
    Inherits System.Web.UI.Page
    Public Shared firstPayDate, paymentDate As Date
    Public Shared intRate, monthlyPrincipal, loanAmount, paymentPeriod, finalMonthlyPayment, interest As Double
    Public Shared isApproval As Double = 0
    Shared adp As New SqlDataAdapter
    Shared cmd As SqlCommand
    Shared con As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
    Public Shared Function convertToSaveFormat(ByVal dbl As String) As String
        If dbl.ToString.Contains(",") Then
            dbl = dbl.ToString.Replace(",", ".")
        End If
        Return dbl
    End Function

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
            WriteLogFile(Session("UserId"), Request.Url.ToString & "clearAmortization()", ex.ToString)
        End Try
    End Sub

    Protected Sub btnAmortize_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAmortize.Click
        Try
            createAmortizationOptions(txtLoanID.Text)
            'End If
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- btnAmortize_Click()", ex.ToString)
        End Try
    End Sub

    Protected Sub btnSaveCreditParameters_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSaveCreditParameters.Click
        If Trim(txtLoanID.Text) = "" Then
            CreditManager.notify("Enter loan ID", "error")
            txtLoanID.Focus()
            Exit Sub
        ElseIf Trim(bdp1stPayDate.Text) = "" Or bdp1stPayDate.Text = "01 January 1900" Then
            CreditManager.notify("Enter valid date", "error")
            bdp1stPayDate.Focus()
            Exit Sub
        End If

        If Trim(txtRepaymentInterval.Text) = "" Or Not IsNumeric(txtRepaymentInterval.Text) Then
            CreditManager.notify("Enter numeric value for Repayment interval", "error")
            txtRepaymentInterval.Focus()
        ElseIf cmbRepaymentInterval.SelectedValue = "" Then
            CreditManager.notify("Select repayment interval", "error")
            cmbRepaymentInterval.Focus()
        ElseIf Trim(txtRepayPeriod.Text) = "" Or Not IsNumeric(txtRepayPeriod.Text) Then
            CreditManager.notify("Enter numeric number of repayments", "error")
            txtRepayPeriod.Focus()
        Else
            'Using cmd = New SqlCommand("update QUEST_APPLICATION set [FIN_TENOR]='" & txtRepayPeriod.Text & "',[FIN_INT_RATE]='" & convertToSaveFormat(txtIntRate.Text) & "',[FIN_ADMIN]='" & convertToSaveFormat(txtAdminCharge.Text) & "',[FIN_REPAY_DATE]='" & bdp1stPayDate.Text & "',RepaymentIntervalNum=NULLIF('" & txtRepaymentInterval.Text & "',''),RepaymentIntervalUnit='" & cmbRepaymentInterval.SelectedValue & "' where ID='" & txtLoanID.Text & "'", con)
            'Using cmd = New SqlCommand("update QUEST_APPLICATION set [FIN_TENOR]='" & txtRepayPeriod.Text & "',[FIN_INT_RATE]='" & convertToSaveFormat(txtIntRate.Text) & "',[ADMIN_RATE]='" & convertToSaveFormat(txtAdminCharge.Text) & "',[FIN_REPAY_DATE]='" & bdp1stPayDate.Text & "',RepaymentIntervalNum=NULLIF('" & txtRepaymentInterval.Text & "',''),RepaymentIntervalUnit='" & cmbRepaymentInterval.SelectedValue & "' where ID='" & txtLoanID.Text & "'", con)
            Using cmd = New SqlCommand("update QUEST_APPLICATION set [FIN_TENOR]='" & txtRepayPeriod.Text & "',[FIN_INT_RATE]='" & convertToSaveFormat(txtIntRate.Text) & "',[ADMIN_RATE]='" & convertToSaveFormat(txtAdminCharge.Text) & "',[FIN_REPAY_DATE]='" & bdp1stPayDate.Text & "',RepaymentIntervalNum=NULLIF('" & txtRepaymentInterval.Text & "',''),RepaymentIntervalUnit='" & cmbRepaymentInterval.SelectedValue & "' where ID='" & txtLoanID.Text & "' or GroupLoanID='" & txtLoanID.Text & "'", con)
                'cmd.Parameters.AddWithValue("@DefaultIntInterval", rdbInterestFrequency.SelectedValue)
                If con.State = ConnectionState.Open Then
                    con.Close()
                End If
                con.Open()
                Try
                    cmd.ExecuteNonQuery()
                    btnAmortize_Click(sender, New EventArgs)
                Catch ex As Exception
                    WriteLogFile(Session("UserId"), Request.Url.ToString & "btnSaveCreditParameters_Click()", ex.ToString)
                    CreditManager.notify("Error saving instructions", "error")
                Finally
                    con.Close()
                End Try
            End Using
        End If
    End Sub

    Protected Sub btnSearchLoanID_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearchLoanID.Click
        Try
            If Trim(Session("SessionID")) = "" Or IsDBNull(Session("SessionID")) Then
                Response.Redirect("~/logout.aspx")
            Else
                'SecureBank.recordAction(btnSearchLoanID.ID.ToString, "Searched by Loan ID")
                loadRepayParameters()
            End If

        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & "btnSearchLoanID_Click()", ex.ToString)
        End Try
    End Sub

    Protected Sub btnSearchName_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearchName.Click
        Try
            clearRepayParameters()
            cmd = New SqlCommand("select ID,isnull(ltrim(rtrim(SURNAME)),'')+' '+isnull(ltrim(rtrim(FORENAMES))+' --- ','')+isnull(convert(varchar,CUSTOMER_NUMBER)+' --- ','')+isnull(ADDRESS+' --- ','')+isnull(convert(varchar,[DISBURSED_DATE],106)+' --- ','')+isnull(convert(varchar,format(FIN_AMT,'c')),'') as DISPLAY from QUEST_APPLICATION where ltrim(rtrim(SURNAME)) + ' ' + ltrim(rtrim(FORENAMES)) like '" & txtSearchName.Text & "%' and STATUS<>'DISBURSED' and STATUS<>'REPAID' and STATUS<>'PARTIALLY DISBURSED'", con)
            Dim ds As New DataSet
            Using adp As New SqlDataAdapter(cmd)
                adp.Fill(ds, "LOANS")
            End Using
            If ds.Tables(0).Rows.Count > 0 Then
                lstLoans.DataSource = ds.Tables(0)
                lstLoans.DataTextField = "DISPLAY"
                lstLoans.DataValueField = "ID"
                lstLoans.Visible = True
            Else
                lstLoans.DataSource = Nothing
                lstLoans.Visible = False
                CreditManager.notify("No matches found", "error")
                txtLoanID.Text = ""
            End If
            lstLoans.DataBind()
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & "btnSearchName_Click()", ex.ToString)
        End Try
    End Sub

    Protected Sub clearRepayParameters()
        Try
            'rdbRepayOption.ClearSelection()
            txtRepayPeriod.Text = ""
            txtIntRate.Text = ""
            bdp1stPayDate.Text = ""
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & "clearRepayParameters()", ex.ToString)
        End Try
    End Sub

    Protected Function convertWeekendToFriday(payDate As Date) As Date
        While payDate.DayOfWeek = DayOfWeek.Saturday Or payDate.DayOfWeek = DayOfWeek.Sunday Or isHoliday(payDate)
            payDate = payDate.AddDays(-1)
        End While
        Return payDate
    End Function

    Protected Sub createAmortizationOptions(ByVal loanID As String)
        Try
            Dim ds As New DataSet
            Using cmdSel = New SqlCommand("select *,isnull(FIN_REPAY_OPT,'') as FIN_REPAY_OPT1,convert(varchar(50),fin_repay_date,106) as FIN_REPAY_DATE1 from QUEST_APPLICATION where ID='" & loanID & "'", con)
                adp = New SqlDataAdapter(cmdSel)
                adp.Fill(ds, "LOANS")
            End Using
            If ds.Tables(0).Rows.Count > 0 Then
                'Using cmd = New SqlCommand("sp_amortize_balance_daily", con)
                Using cmd = New SqlCommand("sp_amortize", con)
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.AddWithValue("@loanID", loanID)
                    'End If
                    If con.State <> ConnectionState.Closed Then
                        con.Close()
                    End If
                    con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                End Using
                Dim EncQuery As New BankEncryption64
                CreditManager.notify("Amortization schedule successfully created", "success")
                lblViewSchedule.Text = "<a href='rptAmortizationSchedule.aspx?loanID=" & EncQuery.Encrypt(loanID.Replace(" ", "+")) & "' target='new'>View Schedule</a>"
                'ClientScript.RegisterStartupScript(Me.GetType(), "Gritter", "<script type=""text/javascript"">$.gritter.add({title: 'Amortization Schedule Created!',text: 'The amortization schedule has been successfully created. Click ""View Schedule"" to view the created schedule.',image: 'images/thumbs3.jpg'});</script>")
            End If
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & "createAmortizationOptions()", ex.ToString)
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
                            If dr("ProductFees") = "None" Then
                                lblAdminRate.Visible = False
                                txtAdminCharge.Text = "0"
                                txtAdminCharge.Visible = False
                            Else
                                lblAdminRate.Visible = True
                                txtAdminCharge.Visible = True
                                Try
                                    lblAdminRate.Text = IIf(dr("ProductFeeCalc") = "Percentage", "Application Fees (%)", "Application Fees ($)")
                                Catch ex As Exception

                                End Try
                                Try
                                    txtAdminCharge.Text = dr("ProductFeeAmtPerc")
                                Catch ex As Exception
                                    txtAdminCharge.Text = ""
                                End Try
                            End If
                        Catch ex As Exception

                        End Try
                    End If
                End Using
            End Using
        Catch ex As Exception
            WriteLogFile(ex.ToString)
        End Try
    End Sub

    Protected Function isHoliday(payDate As Date) As Boolean
        cmd = New SqlCommand("select ID from HOLIDAYS where HOLIDAY_DATE='" & payDate.ToLongDateString & "'", con)
        Dim ds As New DataSet
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "holiday")
        If ds.Tables(0).Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Protected Sub loadRepayParameters()
        Try
            'cmd = New SqlCommand("select [FIN_AMT],[FIN_TENOR],[FIN_INT_RATE],[FIN_ADMIN],convert(varchar(50),fin_repay_date,106) as [FIN_REPAY_DATE],[FIN_REPAY_OPT],[CUSTOMER_TYPE],[DefaultIntInterval],[IntCalcMethod],[IntTrigger],[DaysInYear],[RepaymentFreq],[HasGracePeriod],[GracePeriodType],[GracePeriodLength],[GracePeriodUnit],[AllowRepaymentOnWknd],[IfRepaymentFallsOnWknd],[AllowEditingPaymentSchedule],[RepayOrder1],[RepayOrder2],[RepayOrder3],[RepayOrder4],[TolerancePeriodNum],[TolerancePeriodUnit],[ArrearNonWorkingDays],[PenaltyCharged],[PenaltyOption],[AmtToPenalise],[ProductFees],[ProductFeeCalc],[ProductFeeAmtPerc] from QUEST_APPLICATION where ID='" & txtLoanID.Text & "'", con)
            Using cmd = New SqlCommand("select FORENAMES,SURNAME,convert(varchar,[APPL_DATE],106) as APPL_DATE,[FIN_AMT],[FIN_TENOR],[FIN_INT_RATE],qa.ADMIN_RATE, [FIN_ADMIN],convert(varchar(50),fin_repay_date,106) as [FIN_REPAY_DATE],[FIN_REPAY_OPT],[CUSTOMER_TYPE],ISNULL(qa.[DefaultIntInterval],cp.DefaultIntInterval) as [DefaultIntInterval],ISNULL(qa.[IntCalcMethod],cp.[IntCalcMethod]) as [IntCalcMethod],ISNULL(qa.[IntTrigger],cp.[IntTrigger]) as [IntTrigger],ISNULL(qa.[DaysInYear],cp.[DaysInYear]) as [DaysInYear],ISNULL(qa.[RepaymentFreq],cp.[RepaymentFreq]) as [RepaymentFreq],ISNULL(qa.[HasGracePeriod],cp.[HasGracePeriod]) as [HasGracePeriod],ISNULL(qa.[GracePeriodType],cp.[GracePeriodType]) as [GracePeriodType],ISNULL(qa.[GracePeriodLength],cp.[GracePeriodLength]) as [GracePeriodLength],ISNULL(qa.[GracePeriodUnit],cp.[GracePeriodUnit]) as [GracePeriodUnit],ISNULL(qa.[AllowRepaymentOnWknd],cp.[AllowRepaymentOnWknd]) as [AllowRepaymentOnWknd],ISNULL(qa.[IfRepaymentFallsOnWknd],cp.[IfRepaymentFallsOnWknd]) as [IfRepaymentFallsOnWknd],ISNULL(qa.[AllowEditingPaymentSchedule],cp.[AllowEditingPaymentSchedule]) as [AllowEditingPaymentSchedule],ISNULL(qa.[RepayOrder1],cp.[RepayOrder1]) as [RepayOrder1],ISNULL(qa.[RepayOrder2],cp.[RepayOrder2]) as [RepayOrder2],ISNULL(qa.[RepayOrder3],cp.[RepayOrder3]) as [RepayOrder3],ISNULL(qa.[RepayOrder4],cp.[RepayOrder4]) as [RepayOrder4],ISNULL(qa.[TolerancePeriodNum],cp.[TolerancePeriodNum]) as [TolerancePeriodNum],ISNULL(qa.[TolerancePeriodUnit],cp.[TolerancePeriodUnit]) as [TolerancePeriodUnit],ISNULL(qa.[ArrearNonWorkingDays],cp.[ArrearNonWorkingDays]) as [ArrearNonWorkingDays],ISNULL(qa.[PenaltyCharged],cp.[PenaltyCharged]) as [PenaltyCharged],ISNULL(qa.[PenaltyOption],cp.[PenaltyOption]) as [PenaltyOption],ISNULL(qa.[AmtToPenalise],cp.[AmtToPenalise]) as [AmtToPenalise],ISNULL(qa.[ProductFees],cp.[ProductFees]) as [ProductFees],ISNULL(qa.[ProductFeeCalc],cp.[ProductFeeCalc]) as [ProductFeeCalc],ISNULL(qa.[ProductFeeAmtPerc],cp.[ProductFeeAmtPerc]) as [ProductFeeAmtPerc],qa.RepaymentIntervalNum, qa.RepaymentIntervalUnit,FinProductType from QUEST_APPLICATION qa JOIN creditproducts cp ON qa.FinProductType=cp.id where qa.ID='" & txtLoanID.Text & "' and STATUS<>'DISBURSED' and STATUS<>'REPAID' and STATUS<>'PARTIALLY DISBURSED'", con)
                Dim ds As New DataSet
                adp = New SqlDataAdapter(cmd)
                adp.Fill(ds, "CREDIT")
                If ds.Tables(0).Rows.Count > 0 Then
                    Try
                        Try
                            txtRepayPeriod.Text = FormatNumber(ds.Tables(0).Rows(0).Item("FIN_TENOR"), 0)
                        Catch ex As Exception
                            txtRepayPeriod.Text = ""
                        End Try

                        txtIntRate.Text = ds.Tables(0).Rows(0).Item("FIN_INT_RATE")
                        Try
                            txtAdminCharge.Text = ds.Tables(0).Rows(0).Item("ADMIN_RATE")
                        Catch ex As Exception
                            txtAdminCharge.Text = "0"
                        End Try
                        Try
                            bdp1stPayDate.Text = ds.Tables(0).Rows(0).Item("FIN_REPAY_DATE")
                        Catch ex As Exception
                            bdp1stPayDate.Text = ""
                        End Try
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
                        Try
                            lblAppName.Text = ds.Tables(0).Rows(0).Item("FORENAMES") & " " & ds.Tables(0).Rows(0).Item("SURNAME")
                        Catch ex As Exception
                        End Try
                        Try
                            lblAppDate.Text = ds.Tables(0).Rows(0).Item("APPL_DATE")
                        Catch ex As Exception
                        End Try
                        getProductDefaults(ds.Tables(0).Rows(0).Item("FinProductType"))
                        Dim EncQuery As New BankEncryption64
                        lblViewSchedule.Text = "<a href='rptAmortizationSchedule.aspx?loanID=" & EncQuery.Encrypt(txtLoanID.Text.Replace(" ", "+")) & "' target='new'>View Schedule</a>"
                    Catch ex As Exception
                        WriteLogFile(Session("UserId"), Request.Url.ToString & " --- loadRepayParameters()", ex.ToString)
                    End Try
                Else
                    CreditManager.notify("No matches found", "error")
                End If
            End Using
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- loadRepayParameters()", ex.ToString)
        End Try
    End Sub
    Protected Sub lstLoans_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstLoans.SelectedIndexChanged
        Try
            Dim loanID = lstLoans.SelectedValue
            txtLoanID.Text = loanID
            btnSearchLoanID_Click(sender, New EventArgs)
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- lstLoans_SelectedIndexChanged()", ex.ToString)
        End Try
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Page.MaintainScrollPositionOnPostBack = True
        If Not IsPostBack Then
            Dim EncQuery As New BankEncryption64
            If Trim(Request.QueryString("ID")) = "" Then
            Else
                ViewState("loanID") = EncQuery.Decrypt(Request.QueryString("ID").Replace(" ", "+"))
                isApproval = Request.QueryString("App")
                txtLoanID.Text = ViewState("loanID")
                If isApproval Then
                    lblReturnApproval.Text = "<a href='ApplicationApproval.aspx?id=" & EncQuery.Encrypt(ViewState("loanID").replace(" ", "+")) & "'>Return to Loan Approval</a>"
                End If
                loadRepayParameters()
            End If
        End If
    End Sub
End Class