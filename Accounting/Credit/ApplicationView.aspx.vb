Imports System.Data
Imports System.Data.SqlClient

Partial Class Credit_ApplicationView
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

    Protected Sub btnModalPopup_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnModalPopup.Click

    End Sub

    Protected Sub btnSearchRange_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearchRange.Click
        'Try
        '    cmd = New SqlCommand("select ID,CUSTOMER_NUMBER as [CUST NO.],RTRIM(SURNAME+' '+FORENAMES) as NAME,FIN_AMT as AMOUNT,CREATED_DATE as 'APPLICATION DATE' from QUEST_APPLICATION where SEND_TO='" & Session("ROLE") & "' and CREATED_DATE between '" & bdpFrom.Text & "' and '" & bdpTo.Text & "'  order by CREATED_DATE desc", con)
        '    Dim ds As New DataSet
        '    adp = New SqlDataAdapter(cmd)
        '    adp.Fill(ds, "APP")
        '    If ds.Tables(0).Rows.Count > 0 Then
        '        grdApps.DataSource = ds.Tables(0)
        '    Else
        '        grdApps.DataSource = Nothing
        '    End If
        '    grdApps.DataBind()
        'Catch ex As Exception

        'End Try
        getApplications(Session("ROLE"), Trim(txtSearchName.Text))
    End Sub

    Protected Sub getApplications(ByVal roleID As String, cliName As String)
        Try
            Dim ds As New DataSet
            cmd = New SqlCommand("select StageName,qa.ID,CUSTOMER_NUMBER as [CUST NO.],CUSTOMER_TYPE as [TYPE],case IS_PARTIAL when 1 then RTRIM(isnull(SURNAME,'')+' '+isnull(FORENAMES,''))+' - PARTIALLY DISBURSED' else RTRIM(isnull(SURNAME,'')+' '+isnull(FORENAMES,'')) end as NAME,CONVERT(DECIMAL(30,2),FIN_AMT) as AMOUNT,convert(varchar,isnull(APPL_DATE,CREATED_DATE),106) as 'APPLICATION DATE' from QUEST_APPLICATION qa join paraapprovalstages pas on qa.SEND_TO=pas.roleid AND qa.ApprovalNumber=pas.stageorder-1 AND qa.finProductType=pas.finProductType where SEND_TO='" & roleID & "' and STATUS<>'REJECTED' and RTRIM(isnull(SURNAME,'')+' '+isnull(FORENAMES,'')) like '%" & cliName & "%' order by SURNAME asc", con)
            'Dim ds As New DataSet
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "APP")
            If ds.Tables(0).Rows.Count > 0 Then
                grdApps.DataSource = ds.Tables(0)
            Else
                grdApps.DataSource = Nothing
            End If
            grdApps.DataBind()

            'End If
            lblAppCount.Text = ds.Tables(0).Rows.Count
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub grdApps_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles grdApps.PageIndexChanging
        grdApps.PageIndex = e.NewPageIndex
        'If Trim(txtSearchName.Text) = "" Then
        getApplications(Session("ROLE"), Trim(txtSearchName.Text))
        'Else
        '    searchGrid(txtSearchName.Text)
        'End If
    End Sub

    Protected Sub grdApps_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdApps.RowCommand
        Try
            Dim EncQuery As New BankEncryption64
            Dim loanID = e.CommandArgument
            Dim appType As String = getAppType(loanID)
            'appType = grdApps.Rows(e.CommandArgument).Cells(4).Text.ToString
            'e.
            If e.CommandName = "Select" Or e.CommandName = "Application" Then
                If Session("ROLE") = "1024" Or Session("ROLE") = "4045" Then
                    Response.Redirect("LoanDisbursement.aspx?id=" & EncQuery.Encrypt(loanID).Replace(" ", "+"))
                Else
                    If appType = "Individual" Then
                        Response.Redirect("ApplicationApproval.aspx?id=" & EncQuery.Encrypt(loanID).Replace(" ", "+"))
                    ElseIf appType = "Group" Then
                        'Response.Redirect("ApplicationApprovalGrp.aspx?id=" & EncQuery.Encrypt(loanID).Replace(" ", "+"))
                        Response.Redirect("GroupApproval.aspx?id=" & EncQuery.Encrypt(loanID).Replace(" ", "+"))
                    ElseIf appType = "Business" Or appType = "Company" Then
                        Response.Redirect("ApplicationApprovalBus.aspx?id=" & EncQuery.Encrypt(loanID).Replace(" ", "+"))
                    End If
                    'Response.Redirect("ApplicationApproval.aspx?id=" & EncQuery.Encrypt(loanID).Replace(" ", "+"))
                End If
            ElseIf e.CommandName = "Details" Then
                'Dim loanID = e.CommandArgument
                lblDetailID.Text = loanID
                lblSessionRole.Text = Session("ROLE")
                'btnModalPopup_Click(sender, New EventArgs)
            ElseIf e.CommandName = "Application" Then
                'Dim loanID = e.CommandArgument
            End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub grdApps_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles grdApps.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim lnk = CType(e.Row.FindControl("LinkButton1"), LinkButton)
            If Session("ROLE") = "1024" Or Session("ROLE") = "4045" Then
                lnk.Text = "Disburse"
            Else
                'Response.Redirect("ApplicationApproval.aspx?id=" & HttpUtility.UrlEncode(EncQuery.Encrypt(loanID)) & "&lev=" & HttpUtility.UrlEncode(EncQuery.Encrypt(ViewState("Level"))))
            End If
        End If
    End Sub

    Protected Sub grdApps_SelectedIndexChanged(sender As Object, e As EventArgs) Handles grdApps.SelectedIndexChanged

    End Sub

    Protected Function getAppType(ByVal loanID As String) As String
        Dim ind As String = ""
        cmd = New SqlCommand("select CUSTOMER_TYPE from QUEST_APPLICATION where ID='" & loanID & "'", con)
        If con.State = ConnectionState.Open Then
            con.Close()
        End If
        con.Open()
        ind = cmd.ExecuteScalar
        con.Close()
        Return ind
    End Function

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Page.MaintainScrollPositionOnPostBack = True
            con = New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
            If Not IsPostBack Then
                If Trim(Session("ROLE")) = "" Then
                    Response.Redirect("~/Login.aspx")
                Else
                    getApplications(Session("ROLE"), Trim(txtSearchName.Text))
                End If
                grdApps.UseAccessibleHeader = True
                grdApps.HeaderRow.TableSection = TableRowSection.TableHeader
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class