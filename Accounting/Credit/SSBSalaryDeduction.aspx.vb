Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports Mailhelper

Partial Class Credit_SSBSalaryDeduction
    Inherits System.Web.UI.Page
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

    Protected Sub btnGenerateSSB_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGenerateSSB.Click
        saveSSBDetails(txtLoanNo.Text)
        Dim strscript As String = "<script langauage=JavaScript>"
        strscript += "window.open('rptSSBDeduction.aspx?id=" & txtLoanNo.Text & "');"
        strscript += "</script>"
        ClientScript.RegisterStartupScript(Me.GetType(), "newwin", strscript)
    End Sub

    Protected Sub btnSearchLoanNo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearchLoanNo.Click
        getSSBDetails(txtLoanNo.Text)
    End Sub

    Protected Sub btnSearchSurname_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearchSurname.Click
        Try
            'cmd = New SqlCommand("select CUSTOMER_NUMBER, SURNAME+' '+FORENAMES+' '+IDNO+' '+ADDRESS as display from CUSTOMER_DETAILS where SURNAME like '" & txtSearchSurname.Text & "%'", con)
            cmd = New SqlCommand("select ID, SURNAME+' '+FORENAMES+' '+cast(FIN_AMT as varchar)+' '+IDNO+' '+ADDRESS as display from QUEST_APPLICATION where SURNAME like '" & txtSearchSurname.Text & "%'", con)
            'MsgBox(cmd.CommandText)
            Dim ds As New DataSet
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "cust")
            If ds.Tables(0).Rows.Count > 0 Then
                lstSurname.Visible = True
                lstSurname.DataSource = ds.Tables(0)
                lstSurname.DataTextField = "display"
                lstSurname.DataValueField = "ID"
            Else
                lstSurname.DataSource = Nothing
            End If
            lstSurname.DataBind()
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub getSSBDetails(ByVal loanID As String)
        Try
            cmd = New SqlCommand("select * from QUEST_APPLICATION where ID='" & loanID & "'", con)
            Dim ds As New DataSet
            Dim adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "LOAN")
            If ds.Tables(0).Rows.Count > 0 Then
                txtSSBName.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("SURNAME")) + " " + BankString.isNullString(ds.Tables(0).Rows(0).Item("FORENAMES"))
                txtMinistry.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("MIN_DEPT"))
                txtMinistryNo.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("MIN_DEPT_NO"))
                txtECNo.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("ECNO"))
                txtCD.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("CD"))
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub lstSurname_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstSurname.SelectedIndexChanged
        Try
            Dim loanID = lstSurname.SelectedValue
            txtLoanNo.Text = loanID
            btnSearchLoanNo_Click(sender, New EventArgs)
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Page.MaintainScrollPositionOnPostBack = True
            con = New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
            If Not IsPostBack Then

            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub saveSSBDetails(ByVal loanID As String)
        Try
            cmd = New SqlCommand("update QUEST_APPLICATION set MIN_DEPT='" & txtMinistry.Text & "', MIN_DEPT_NO='" & txtMinistryNo.Text & "',ECNO='" & txtECNo.Text & "',CD='" & txtCD.Text & "',SSB_NEW='" & chkApplicable.Items(0).Selected & "', SSB_CHANGE='" & chkApplicable.Items(1).Selected & "', SSB_CEASE='" & chkApplicable.Items(2).Selected & "', SSB_MONTHLY_RATE='" & txtMonthlyRate.Text & "', SSB_FROM='" & bdpFromDate.Text & "', SSB_TO='" & bdpToDate.Text & "', SSB_REF='" & txtSSBRefNo.Text & "', SSB_GENERATOR='" & Session("UserID") & "', SSB_GEN_DATE=GETDATE() where ID='" & loanID & "'", con)
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception

        End Try
    End Sub
End Class