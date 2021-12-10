Imports System.Data
Imports System.Data.SqlClient

Partial Class Credit_Penalties
    Inherits System.Web.UI.Page
    Public Shared commEditID As String
    Dim adp As SqlDataAdapter
    Dim cmd As SqlCommand
    Dim con As New SqlConnection
    Public Sub msgbox(ByVal strMessage As String)

        'finishes server processing, returns to client.
        Dim strScript As String = "<script language=JavaScript>"
        strScript += "window.alert(""" & strMessage & """);"
        strScript += "</script>"
        Dim lbl As New System.Web.UI.WebControls.Label
        lbl.Text = strScript
        Page.Controls.Add(lbl)
    End Sub

    Protected Sub btnSavePayment_Click(sender As Object, e As EventArgs) Handles btnSavePayment.Click
        'show popup
        Try
            savePenalty()
            savePenaltyDebit(hidCustNo.Value, txtLoanID.Text, txtPaymentDate.Text, txtPenalty.Text)
            savePenaltyCredit(hidCustNo.Value, txtLoanID.Text, txtPaymentDate.Text, txtPenalty.Text)
            msgbox("Penalty saved")
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub btnSearchLoan_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearchLoan.Click
        Try
            cmd = New SqlCommand("select * from QUEST_APPLICATION where ID='" & txtLoanID.Text & "' and DISBURSED=1", con)
            Dim ds As New DataSet
            Dim adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "LOANS")
            Dim loanAmt As Double
            If ds.Tables(0).Rows.Count > 0 Then
                hidCustNo.Value = ds.Tables(0).Rows(0).Item("CUSTOMER_NUMBER")
                showLoanDetails(ds.Tables(0).Rows(0))
                loanAmt = ds.Tables(0).Rows(0).Item("FIN_AMT")
            Else
                msgbox("Loan not yet disbursed or not found")
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub btnSearchName_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearchName.Click
        Try
            'SecureBank.recordAction(btnSearchName.ID.ToString, "Searched by Name")
            'clearRepayParameters()
            cmd = New SqlCommand("select ID,SURNAME+' '+FORENAMES+' '+convert(varchar,CUSTOMER_NUMBER)+' '+convert(varchar,FIN_AMT) as DISPLAY from QUEST_APPLICATION where DISBURSED='1' AND SURNAME like '" & txtSearchName.Text & "%'", con)
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
                msgbox("Search name not found")
                txtLoanID.Text = ""
            End If
            lstLoans.DataBind()
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Function calculateTotalPenalty(calcMethod As String, amt As Double, rate As Double, noDays As Double) As Double
        Dim totPenalty As Double = 0
        If calcMethod = "Perc" Then
            totPenalty = (rate / 100) * amt * noDays
        ElseIf calcMethod = "Amt" Then
            totPenalty = rate * noDays
        End If
        Return totPenalty
    End Function

    Protected Sub cmbPenaltyType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPenaltyType.SelectedIndexChanged
        If cmbPenaltyType.SelectedValue = "Overdue" Then
            panPenalty.Visible = True
        Else
            panPenalty.Visible = False
        End If
    End Sub

    Protected Function getBalBFwd(loanID As String) As Double
        cmd = New SqlCommand("select top 1 BAL_CFWD from QUEST_TRANSACTIONS where loanid='" & loanID & "' order by id desc", con)
        Dim bBFwd As Double = 0
        If con.State = ConnectionState.Open Then
            con.Close()
        End If
        con.Open()
        bBFwd = cmd.ExecuteScalar
        con.Close()
        Return bBFwd
    End Function

    Protected Sub lstLoans_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstLoans.SelectedIndexChanged
        Try
            Dim loanID = lstLoans.SelectedValue
            txtLoanID.Text = loanID
            btnSearchLoan_Click(sender, New EventArgs)
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Page.MaintainScrollPositionOnPostBack = True
        con = New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
        If Not IsPostBack Then
        End If
    End Sub
    Protected Sub savePenalty()
        Try
            cmd = New SqlCommand("insert into penalties (cust_no,loan_id,date_charged,penalty_description,calc_method,calc_rate,days_overdue,total_penalty) values ('" & hidCustNo.Value & "','" & txtLoanID.Text & "','" & txtPaymentDate.Text & "','" & cmbPenaltyType.SelectedItem.Text & "','" & rdbCalcMethod.SelectedItem.Text & "','" & txtPenaltyRate.Text & "','" & txtNoDays.Text & "','" & txtPenalty.Text & "')", con)
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub savePenaltyCredit(custNo As String, loanID As String, transDate As Date, amt As Double)
        Dim balBFwd = getBalBFwd(loanID)
        cmd = New SqlCommand("insert into QUEST_TRANSACTIONS ([CUST_NO],[LOANID],[TRANS_DATE],[TRANS_DESC],[DEBIT],[CREDIT],[BAL_BFWD],[BAL_CFWD],[FIN_ACC],[FIN_ACC_CONTR]) values ('" & custNo & "','" & loanID & "','" & transDate & "','Penalty Charges Payment','0','" & amt & "','" & balBFwd & "','" & balBFwd - amt & "','110','101')", con)
        If con.State = ConnectionState.Open Then
            con.Close()
        End If
        con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Protected Sub savePenaltyDebit(custNo As String, loanID As String, transDate As Date, amt As Double)
        Dim balBFwd = getBalBFwd(loanID)
        cmd = New SqlCommand("insert into QUEST_TRANSACTIONS ([CUST_NO],[LOANID],[TRANS_DATE],[TRANS_DESC],[DEBIT],[CREDIT],[BAL_BFWD],[BAL_CFWD],[FIN_ACC],[FIN_ACC_CONTR]) values ('" & custNo & "','" & loanID & "','" & transDate & "','Penalty Charges','" & amt & "','0','" & balBFwd & "','" & balBFwd + amt & "','110','101')", con)
        If con.State = ConnectionState.Open Then
            con.Close()
        End If
        con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub
    Protected Sub showLoanDetails(dr As DataRow)
        Try
            lblApplicantName.Text = dr.Item("SURNAME") & " " & dr.Item("FORENAMES")
            lblApplAddress.Text = dr.Item("ADDRESS")
            lblLoanAmount.Text = dr.Item("FIN_AMT")
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub txtNoDays_TextChanged(sender As Object, e As EventArgs) Handles txtNoDays.TextChanged
        Try
            txtPenalty.Text = calculateTotalPenalty(rdbCalcMethod.SelectedValue, lblLoanAmount.Text, txtPenaltyRate.Text, txtNoDays.Text)
        Catch ex As Exception
            txtPenalty.Text = ""
        End Try
    End Sub

    Protected Sub txtPenaltyRate_TextChanged(sender As Object, e As EventArgs) Handles txtPenaltyRate.TextChanged
        Try
            txtPenalty.Text = calculateTotalPenalty(rdbCalcMethod.SelectedValue, Double.Parse(lblLoanAmount.Text), Double.Parse(txtPenaltyRate.Text), Double.Parse(txtNoDays.Text))
        Catch ex As Exception
            txtPenalty.Text = ""
        End Try
    End Sub
End Class