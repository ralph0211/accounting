Imports System.Data
Imports System.Data.SqlClient

Partial Class Credit_Rejected
    Inherits System.Web.UI.Page
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

    Protected Sub btnSearchRange_Click(sender As Object, e As EventArgs) Handles btnSearchRange.Click
        Try
            cmd = New SqlCommand("select ID,CUSTOMER_NUMBER as [CUST NO.],RTRIM(SURNAME+' '+FORENAMES) as NAME,FIN_AMT as AMOUNT,CREATED_DATE as 'APPLICATION DATE' from QUEST_APPLICATION where SEND_TO='" & Session("ROLE") & "' and STATUS='REJECTED' and CREATED_DATE >= '" & bdpFrom.Text & "' and CREATED_DATE <= '" & bdpTo.Text & "' order by CREATED_DATE desc", con)
            Dim ds As New DataSet
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "APP")
            If ds.Tables(0).Rows.Count > 0 Then
                grdApps.DataSource = ds.Tables(0)
            Else
                grdApps.DataSource = Nothing
            End If
            grdApps.DataBind()
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub getRejections(ByVal roleID As String, ByVal userID As String)
        Try
            If roleID = "4041" Then
                'cmd = New SqlCommand("select ID,CUSTOMER_NUMBER as [CUST NO.],RTRIM(SURNAME+' '+FORENAMES) as NAME,CONVERT(DECIMAL(30,2),FIN_AMT) as AMOUNT,convert(varchar,isnull(nullif(APPL_DATE,'1900-01-01'),CREATED_DATE),106) as 'APPLICATION DATE' from QUEST_APPLICATION where SEND_TO='" & roleID & "' and LO_ID='" & userID & "' and STATUS='REJECTED' order by CREATED_DATE desc", con)
                cmd = New SqlCommand("select ID,CUSTOMER_NUMBER as [CUST NO.],RTRIM(SURNAME+' '+FORENAMES) as NAME,CONVERT(DECIMAL(30,2),FIN_AMT) as AMOUNT,convert(varchar,isnull(nullif(APPL_DATE,'1900-01-01'),CREATED_DATE),106) as 'APPLICATION DATE' from QUEST_APPLICATION where SEND_TO='" & roleID & "' and STATUS='REJECTED' AND LO_ID='" & userID & "' order by CREATED_DATE desc", con)
            ElseIf roleID = "4042" Then
                cmd = New SqlCommand("select ID,CUSTOMER_NUMBER as [CUST NO.],RTRIM(SURNAME+' '+FORENAMES) as NAME,CONVERT(DECIMAL(30,2),FIN_AMT) as AMOUNT,CREATED_DATE as 'APPLICATION DATE' from QUEST_APPLICATION where SEND_TO='" & roleID & "' and LM_ID='" & userID & "' and STATUS='REJECTED' order by CREATED_DATE desc", con)
            ElseIf roleID = "4043" Then
                cmd = New SqlCommand("select ID,CUSTOMER_NUMBER as [CUST NO.],RTRIM(SURNAME+' '+FORENAMES) as NAME,CONVERT(DECIMAL(30,2),FIN_AMT) as AMOUNT,CREATED_DATE as 'APPLICATION DATE' from QUEST_APPLICATION where SEND_TO='" & roleID & "' and HL_ID='" & userID & "' and STATUS='REJECTED' order by CREATED_DATE desc", con)
            ElseIf roleID = "4044" Then
                cmd = New SqlCommand("select ID,CUSTOMER_NUMBER as [CUST NO.],RTRIM(SURNAME+' '+FORENAMES) as NAME,CONVERT(DECIMAL(30,2),FIN_AMT) as AMOUNT,CREATED_DATE as 'APPLICATION DATE' from QUEST_APPLICATION where SEND_TO='" & roleID & "' and MD_ID='" & userID & "' and STATUS='REJECTED' order by CREATED_DATE desc", con)
            ElseIf roleID = "1024" Then
                cmd = New SqlCommand("select ID,CUSTOMER_NUMBER as [CUST NO.],RTRIM(SURNAME+' '+FORENAMES) as NAME,CONVERT(DECIMAL(30,2),FIN_AMT) as AMOUNT,CREATED_DATE as 'APPLICATION DATE' from QUEST_APPLICATION where SEND_TO='" & roleID & "' and DB_ID='" & userID & "' and STATUS='REJECTED' order by CREATED_DATE desc", con)
            End If
            'cmd = New SqlCommand("select ID,CUSTOMER_NUMBER as [CUST NO.],RTRIM(SURNAME+' '+FORENAMES) as NAME,CONVERT(DECIMAL(30,2),FIN_AMT) as AMOUNT,CREATED_DATE as 'APPLICATION DATE' from QUEST_APPLICATION where SEND_TO='" & roleID & "' and STATUS='REJECTED' order by CREATED_DATE desc", con)
            Dim ds As New DataSet
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "APP")
            If ds.Tables(0).Rows.Count > 0 Then
                grdApps.DataSource = ds.Tables(0)
            Else
                grdApps.DataSource = Nothing
            End If
            grdApps.DataBind()
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub grdApps_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles grdApps.PageIndexChanging
        grdApps.PageIndex = e.NewPageIndex
        getRejections(Session("ROLE"), Session("ID"))
    End Sub

    'Protected Sub grdApps_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdApps.RowCommand
    '    Try
    '        If e.CommandName = "Select" Then
    '            Dim loanID = e.CommandArgument
    '            If Session("ROLE") = "4041" Then
    '                If isIndividual(loanID) Then
    '                    Response.Redirect("ApplicationForm.aspx?id=" & loanID & "&rej=1" & "")
    '                Else
    '                    Response.Redirect("ApplicationApprovalGrp.aspx?id=" & loanID)
    '                End If
    '            Else
    '                If isIndividual(loanID) Then
    '                    Response.Redirect("ApplicationApproval.aspx?id=" & loanID & "&rej=1")
    '                Else
    '                    Response.Redirect("ApplicationApprovalGrp.aspx?id=" & loanID)
    '                End If
    '            End If
    '        ElseIf e.CommandName = "Details" Then
    '            Dim loanID = e.CommandArgument
    '            lblDetailID.Text = loanID
    '            lblSessionRole.Text = Session("ROLE")
    '            'btnModalPopup_Click(sender, New EventArgs)
    '        End If
    '    Catch ex As Exception

    '    End Try
    'End Sub

    Protected Sub grdApps_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdApps.RowCommand
        Try
            If e.CommandName = "Select" Then
                Dim loanID = e.CommandArgument
                Dim EncQuery As New BankEncryption64
                If Session("ROLE") = "4041" Then
                    If isIndividual(loanID) Then
                        Response.Redirect("ApplicationForm.aspx?id=" & EncQuery.Encrypt(loanID.replace(" ", "+")) & "&rej=1" & "")
                    Else
                        Response.Redirect("ApplicationApprovalGrp.aspx?id=" & EncQuery.Encrypt(loanID.replace(" ", "+")))
                    End If
                Else
                    If isIndividual(loanID) Then
                        Response.Redirect("ApplicationApproval.aspx?id=" & EncQuery.Encrypt(loanID.replace(" ", "+")) & "&rej=1")
                    Else
                        Response.Redirect("ApplicationApprovalGrp.aspx?id=" & EncQuery.Encrypt(loanID.replace(" ", "+")))
                    End If
                End If
            ElseIf e.CommandName = "Details" Then
                Dim loanID = e.CommandArgument
                lblDetailID.Text = loanID
                lblSessionRole.Text = Session("ROLE")
                'btnModalPopup_Click(sender, New EventArgs)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Function isIndividual(ByVal loanID As String) As Boolean
        Dim ind As String = ""
        cmd = New SqlCommand("select CUSTOMER_TYPE from QUEST_APPLICATION where ID='" & loanID & "'", con)
        If con.State = ConnectionState.Open Then
            con.Close()
        End If
        con.Open()
        ind = cmd.ExecuteScalar
        con.Close()
        msgbox(ind)
        If ind = "Individual" Then
            Return True
        Else
            Return False
        End If
    End Function

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Page.MaintainScrollPositionOnPostBack = True
            con = New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
            If Not IsPostBack Then
                If Trim(Session("ROLE")) = "" Then
                    Response.Redirect("~/Login.aspx")
                Else
                    getRejections(Session("ROLE"), Session("ID"))
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class