Imports Microsoft.VisualBasic
Imports System
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient

Public Class LoanCalculator
    Shared cmd As SqlCommand
    Shared con As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
    Shared adp As New SqlDataAdapter
    Public Shared intRate, monthlyPrincipal, loanAmount, paymentPeriod, finalMonthlyPayment, interest As Double
    Public Shared firstPayDate, paymentDate As Date

    Public Shared Sub amortize(ByVal loanID As Double)
        clearAmortization(loanID)
        Dim cumPrincipal, principalBalance, cumInterest As Double
        cmd = New SqlCommand("select * from Z_LOAN_SUBMISSION_DETAILS where LOAN_REQID='" & loanID & "'", con)
        Dim ds As New DataSet
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "LOANS")
        If ds.Tables(0).Rows.Count > 0 Then
            loanAmount = ds.Tables(0).Rows(0).Item("CLIENT_CREDITAPPLIED")
            intRate = ds.Tables(0).Rows(0).Item("INTEREST_RATE")
            firstPayDate = ds.Tables(0).Rows(0).Item("FIRST_REPAYMENT_DATE")
            paymentPeriod = ds.Tables(0).Rows(0).Item("REPAYMENT_PERIOD")
            monthlyPrincipal = calculateMonthlyPayment(loanAmount, paymentPeriod)
            interest = Math.Round(monthlyPrincipal * (intRate / 100), 2)
            finalMonthlyPayment = calculateFinalMonthlyPayment()
            paymentDate = firstPayDate
            cumPrincipal = 0
            cumInterest = 0
            principalBalance = loanAmount

            Dim i = 0
            For i = 0 To paymentPeriod - 2
                cumPrincipal = cumPrincipal + monthlyPrincipal
                cumInterest = cumInterest + interest
                principalBalance = principalBalance - monthlyPrincipal
                cmd = New SqlCommand("insert into AMORTIZATION_SCHEDULE(LOANID,PAYMENT_NO,PAYMENT_DATE,PRINCIPAL,INTEREST,CUMULATIVE_PRINCIPAL,CUMULATIVE_INTEREST,PRINCIPAL_BALANCE) values ('" & loanID & "','" & i + 1 & "','" & paymentDate & "','" & convertToSaveFormat(monthlyPrincipal) & "','" & convertToSaveFormat(interest) & "','" & convertToSaveFormat(cumPrincipal) & "','" & convertToSaveFormat(cumInterest) & "','" & convertToSaveFormat(principalBalance) & "')", con)
                If con.State = ConnectionState.Open Then
                    con.Close()
                End If
                con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                paymentDate = DateAdd(DateInterval.Month, 1, paymentDate)
            Next
            'interest = Math.Round(finalMonthlyPayment * (intRate / 100), 2)
            'cumPrincipal = Math.Round(cumPrincipal + finalMonthlyPayment, 2)
            'cumInterest = cumInterest + interest
            'principalBalance = principalBalance - finalMonthlyPayment
            'cmd = New SqlCommand("insert into AMORTIZATION_SCHEDULE(LOANID,PAYMENT_NO,PAYMENT_DATE,PRINCIPAL,INTEREST,CUMULATIVE_PRINCIPAL,CUMULATIVE_INTEREST,PRINCIPAL_BALANCE) values ('" & loanID & "','" & paymentPeriod & "','" & paymentDate & "','" & convertToSaveFormat(finalMonthlyPayment) & "','" & convertToSaveFormat(interest) & "','" & convertToSaveFormat(cumPrincipal) & "','" & convertToSaveFormat(cumInterest) & "','" & convertToSaveFormat(principalBalance) & "')", con)
            'If con.State = ConnectionState.Open Then
            '    con.Close()
            'End If
            'con.Open()
            'cmd.ExecuteNonQuery()
            'con.Close()


            interest = Math.Round(finalMonthlyPayment * (intRate / 100), 2)
            cumPrincipal = Math.Round(cumPrincipal + finalMonthlyPayment, 2)
            cumInterest = cumInterest + interest
            principalBalance = principalBalance - finalMonthlyPayment
            cmd = New SqlCommand("insert into AMORTIZATION_SCHEDULE(LOANID,PAYMENT_NO,PAYMENT_DATE,PRINCIPAL,INTEREST,CUMULATIVE_PRINCIPAL,CUMULATIVE_INTEREST,PRINCIPAL_BALANCE) values ('" & loanID & "','" & paymentPeriod & "','" & paymentDate & "','" & convertToSaveFormat(finalMonthlyPayment) & "','" & convertToSaveFormat(interest) & "','" & convertToSaveFormat(cumPrincipal) & "','" & convertToSaveFormat(cumInterest) & "','" & convertToSaveFormat(principalBalance) & "')", con)
            'msgbox(cmd.CommandText)
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        End If
    End Sub

    Public Shared Sub clearAmortization(ByVal loanID As Double)
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

    Public Shared Function calculateMonthlyPayment(ByVal loanAmount As Double, ByVal paymentPeriod As Double) As Double
        Dim monPaymt = loanAmount / paymentPeriod
        Return Math.Round(monPaymt, 2)
    End Function

    Public Shared Function calculateFinalMonthlyPayment() As Double
        Dim finPaymt = loanAmount - (monthlyPrincipal * (paymentPeriod - 1))
        Return Math.Round(finPaymt, 2)
    End Function

    Public Shared Function convertToSaveFormat(ByVal dbl As String) As String
        If dbl.ToString.Contains(",") Then
            dbl = dbl.ToString.Replace(",", ".")
        End If
        Return dbl
    End Function
End Class
