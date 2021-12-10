Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports BankString

Partial Class Credit_popAmortization
    Inherits System.Web.UI.Page
    Public Shared firstPayDate, paymentDate As Date
    Public Shared globLoanID As Double = 0
    Public Shared intRate, monthlyPrincipal, loanAmount, paymentPeriod, finalMonthlyPayment, interest As Double
    Public Shared isApproval As Double = 0
    Shared actionTime As Date
    Shared adp As New SqlDataAdapter
    Shared cmd As SqlCommand
    Shared con As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
    Shared IPAdd, machName, browser, url, isFarmer As String
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
    Protected Sub btnSaveCreditParameters_Click(sender As Object, e As EventArgs) Handles btnSaveCreditParameters.Click

        'cmd = New SqlCommand("update QUEST_APPLICATION set [REPAYMENT_OPTION]='" & rdbRepayOption.SelectedValue & "',[REPAYMENT_PERIOD]='" & txtRepayPeriod.Text & "',[INTEREST_RATE]='" & convertToSaveFormat(txtIntRate.Text) & "',[FIRST_REPAYMENT_DATE]='" & DateFormat.getSaveDate(bdp1stPayDate.SelectedDate.ToShortDateString) & "' where ID='" & txtLoanID.Text & "'", con)
        cmd = New SqlCommand("update QUEST_APPLICATION set [FIN_TENOR]='" & txtRepayPeriod.Text & "',[FIN_INT_RATE]='" & txtIntRate.Text & "',[FIN_ADMIN]='" & txtAdminCharge.Text & "',[FIN_REPAY_DATE]='" & txt1stPayDate.Text & "' where ID='" & globLoanID & "'", con)
        'msgbox(cmd.CommandText)
        If con.State = ConnectionState.Open Then
            con.Close()
        End If
        con.Open()
        Try
            cmd.ExecuteNonQuery()
            'msgbox("Repayment instructions saved")
            createAmortizationOptions(globLoanID)
            Response.Redirect("AgreementLetters.aspx?ID=" & globLoanID & "&pop=1", False)
        Catch ex As Exception
            'msgbox("Error saving instructions")
            Response.Redirect("AgreementLetters.aspx?ID=" & globLoanID & "&pop=0", False)
            ClientScript.RegisterStartupScript(Me.GetType(), "Gritter", "<script type=""text/javascript"">$.gritter.add({title: 'Error saving instruction!',text: 'The amortization instructions could not be saved. Please make sure all parameters are entered correctly with the right format and try again.',image: 'images/error_button.png'});</script>")
        Finally
            con.Close()
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

    Protected Sub loadRepayParameters()
        Try
            Dim settInt As String = ""
            Dim repayOpt As String = ""
            Dim repayPer, intRate, adminCharge As Double
            Dim firstPayDate As String = ""
            cmd = New SqlCommand("select [FIN_AMT],[FIN_TENOR],[FIN_INT_RATE],[FIN_ADMIN],convert(varchar(30),[FIN_REPAY_DATE],113) as [FIN_REPAY_DATE],[FIN_REPAY_OPT],[CUSTOMER_TYPE] from QUEST_APPLICATION where ID='" & globLoanID & "'", con)
            Dim ds As New DataSet
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "CREDIT")
            If ds.Tables(0).Rows.Count > 0 Then
                Try
                    repayPer = ds.Tables(0).Rows(0).Item("FIN_TENOR")
                    intRate = ds.Tables(0).Rows(0).Item("FIN_INT_RATE")
                    firstPayDate = ds.Tables(0).Rows(0).Item("FIN_REPAY_DATE")
                    adminCharge = ds.Tables(0).Rows(0).Item("FIN_ADMIN")
                    If ds.Tables(0).Rows(0).Item("CUSTOMER_TYPE") = "Farmer" Then
                        isFarmer = "1"
                    End If
                Catch ex As Exception
                    'msgbox(ex.Message)
                End Try
            Else
                'ClientScript.RegisterStartupScript(Me.GetType(), "Gritter", "<script type=""text/javascript"">$.gritter.add({title: 'Loan ID not found!',text: 'There is no record which matches the entered Loan ID.',image: 'images/error_button.png'});</script>")
            End If
            txtRepayPeriod.Text = repayPer
            txtIntRate.Text = intRate
            txtAdminCharge.Text = adminCharge
            txt1stPayDate.Text = firstPayDate
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Page.MaintainScrollPositionOnPostBack = True
        If Not IsPostBack Then
            'txtRepayPeriod.Text = Request.QueryString("loanID")
            globLoanID = Request.QueryString("loanID")
            'txtLoanID.Text = globLoanID

            loadRepayParameters()
            'btnSearchLoanID_Click(sender, New EventArgs)
        End If
    End Sub
End Class