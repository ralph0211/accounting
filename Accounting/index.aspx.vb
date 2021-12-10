Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports CreditManager
Imports ErrorLogging

Partial Class index
    Inherits System.Web.UI.Page
    Dim adp As SqlDataAdapter
    Dim con As New SqlConnection

    Public Function GetJSONString(ByVal Dt As DataTable) As String

        Dim StrDc(Dt.Columns.Count - 1) As String
        Dim HeadStr As String = String.Empty

        For i As Integer = 0 To Dt.Columns.Count - 1

            StrDc(i) = Dt.Columns(i).Caption

            HeadStr &= """" & StrDc(i) & """ : """ & StrDc(i) + i.ToString() & "¾" & ""","
        Next i

        HeadStr = HeadStr.Substring(0, HeadStr.Length - 1)

        Dim Sb As New StringBuilder()
        Sb.Append("{""" & Dt.TableName & """ : [")
        'Sb.Append("[")

        For i As Integer = 0 To Dt.Rows.Count - 1

            Dim TempStr As String = HeadStr
            Sb.Append("{")

            For j As Integer = 0 To Dt.Columns.Count - 1

                TempStr = TempStr.Replace(Dt.Columns(j).ToString + j.ToString() & "¾", Dt.Rows(i)(j).ToString())
            Next j

            Sb.Append(TempStr & "},")
        Next i

        Sb = New StringBuilder(Sb.ToString().Substring(0, Sb.ToString().Length - 1))
        Sb.Append("]}")
        'Sb.Append("]")

        Return Sb.ToString()
    End Function

    Public Sub PopulateMenu()
        Try
            Dim dt As DataTable = getPermissions(Session("ID").ToString(), Session("ROLE").ToString())
            'dt = dt.OrderBy("ORDERING")
            If dt.Rows.Count > 0 Then
                Dim categories = (From dr As DataRow In dt.Rows
                                  Select CStr(dr("CATEGORY"))).Distinct()

                Menu1.Items.Clear()
                For Each category As String In categories
                    Dim MasterItem As New MenuItem(category)
                    Menu1.Items.Add(MasterItem)
                    For Each dr As DataRow In dt.Rows
                        If dr("CATEGORY").ToString() = category Then
                            Dim subMenuItem As New MenuItem(CStr(dr("ModuleName")), "", "", "~/" & CStr(dr("URL_NAME")))
                            MasterItem.ChildItems.Add(subMenuItem)
                            Dim url As String = Request.Url.GetLeftPart(UriPartial.Path).Trim()
                            Dim navURL As String = subMenuItem.NavigateUrl.Trim()
                            If url = navURL Then
                                subMenuItem.Selected = True
                            End If
                        End If
                    Next dr
                Next category

            End If
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- PopulateMenu()", ex.ToString)
        End Try
    End Sub

    Protected Sub getApplications(ByVal roleID As String, cliName As String)
        Try
            lblAppCount.Text = 0
            Dim ds As New DataSet
            Dim cmd As New SqlCommand
            cmd = New SqlCommand("select StageName,qa.ID,CUSTOMER_NUMBER as [CUST NO.],CUSTOMER_TYPE as [TYPE],case IS_PARTIAL when 1 then RTRIM(isnull(SURNAME,'')+' '+isnull(FORENAMES,''))+' - PARTIALLY DISBURSED' else RTRIM(isnull(SURNAME,'')+' '+isnull(FORENAMES,'')) end as NAME,CONVERT(DECIMAL(30,2),FIN_AMT) as AMOUNT,convert(varchar,CREATED_DATE,113) as 'APPLICATION DATE' from QUEST_APPLICATION qa join	 paraapprovalstages pas on qa.SEND_TO=pas.roleid AND qa.ApprovalNumber=pas.stageorder-1 where SEND_TO='" & roleID & "' and STATUS<>'REJECTED' and RTRIM(isnull(SURNAME,'')+' '+isnull(FORENAMES,'')) like '%" & cliName & "%' order by SURNAME asc", con)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "APP")
            If ds.Tables(0).Rows.Count > 0 Then
                lblAppCount.Text = FormatNumber(ds.Tables(0).Rows.Count, 0)
                lblInbox.Text = FormatNumber(ds.Tables(0).Rows.Count, 0)
            End If
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- getApplications()", ex.ToString)
        End Try
    End Sub
    Protected Sub getBranches()
        Dim ds As New DataTable
        Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("conString").ConnectionString)
            Using cmd As New SqlCommand("select BNCH_CODE,BNCH_NAME from BNCH_DETAILS", con)
                Using sda As New SqlDataAdapter(cmd)
                    sda.Fill(ds)
                End Using
            End Using
        End Using
        loadCombo(ds, cmbViewDetails, "BNCH_NAME", "BNCH_CODE")
    End Sub

    Protected Sub getCaseload()
        Try
            lblCaseload.Text = 0
            Dim ds As New DataSet
            Dim cmd = New SqlCommand("select count(account) as Caseload from (select account,sum(acct.Debit-acct.Credit) as Bal	from Accounts_Transactions acct where acct.Account IN (SELECT customer_number from QUEST_APPLICATION) group by account having sum(acct.Debit-acct.Credit)>0) tbl", con)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "APP")
            If ds.Tables(0).Rows.Count > 0 Then
                lblCaseload.Text = FormatNumber(ds.Tables(0).Rows(0).Item("Caseload"), 0)
            End If
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- getCaseload()", ex.ToString)
        End Try
    End Sub
    Protected Sub getCaseloadBranch(brnch As String)
        Try
            lblCaseload.Text = 0
            Dim ds As New DataSet
            'Dim cmd = New SqlCommand("select count(account) as Caseload from (select account,sum(acct.Debit-acct.Credit) as Bal	from Accounts_Transactions acct JOIN QUEST_APPLICATION qa on convert(VARCHAR,qa.ID)=acct.Refrence and (qa.CUSTOMER_NUMBER=acct.Account or qa.CUSTOMER_NUMBER=acct.Other) where qa.BRANCH_CODE='" & brnch & "' AND acct.Account IN (SELECT customer_number from QUEST_APPLICATION) group by account having sum(acct.Debit-acct.Credit)>0) tbl", con)
            Dim cmd = New SqlCommand("select count(account) as Caseload from (select account,sum(acct.Debit-acct.Credit) as Bal	from Accounts_Transactions acct  where acct.Account IN (SELECT customer_number from QUEST_APPLICATION where BRANCH_CODE='" & brnch & "') group by account having sum(acct.Debit-acct.Credit)>0) tbl", con)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "APP")
            If ds.Tables(0).Rows.Count > 0 Then
                lblCaseload.Text = FormatNumber(ds.Tables(0).Rows(0).Item("Caseload"), 0)
            End If
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- getCaseloadBranch()", ex.ToString)
        End Try
    End Sub
    Protected Sub getCaseloadLoanOfficer(lo As String)
        Try
            lblCaseload.Text = 0
            Dim ds As New DataSet
            'Dim cmd = New SqlCommand("select count(account) as Caseload from (select account,sum(acct.Debit-acct.Credit) as Bal	from Accounts_Transactions acct JOIN QUEST_APPLICATION qa on convert(VARCHAR,qa.ID)=acct.Refrence and (qa.CUSTOMER_NUMBER=acct.Account or qa.CUSTOMER_NUMBER=acct.Other) where qa.LO_ID='" & lo & "' AND acct.Account IN (SELECT customer_number from QUEST_APPLICATION) group by account having sum(acct.Debit-acct.Credit)>0) tbl", con)
            Dim cmd = New SqlCommand("select count(account) as Caseload from (select account,sum(acct.Debit-acct.Credit) as Bal	from Accounts_Transactions acct  where acct.Account IN (SELECT customer_number from QUEST_APPLICATION where LO_ID='" & lo & "') group by account having sum(acct.Debit-acct.Credit)>0) tbl", con)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "APP")
            If ds.Tables(0).Rows.Count > 0 Then
                lblCaseload.Text = FormatNumber(ds.Tables(0).Rows(0).Item("Caseload"), 0)
            End If
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- getCaseloadLoanOfficer()", ex.ToString)
        End Try
    End Sub
    Protected Sub getDashBranch(brnchID As String)
        'divOverallView.Visible = False
        lblDashboardView.Text = "Branch Statistics"
        getGLPBranch(brnchID)
        getDisbursementsBranch(brnchID)
        getRepaymentsBranch(brnchID)
        getTotalAppCountBranch(brnchID)
        getCaseloadBranch(brnchID)
        getPAR30Branch(brnchID)
    End Sub

    Protected Sub getDashIndividual(loID As String)
        '    divOverallView.Visible = False
        lblDashboardView.Text = "Individual Statistics"
        getGLPLoanOfficer(loID)
        getDisbursementsLoanOfficer(loID)
        getRepaymentsLoanOfficer(loID)
        getTotalAppCountLoanOfficer(loID)
        getCaseloadLoanOfficer(loID)
        getPAR30LoanOfficer(loID)
    End Sub

    Protected Sub getDashOverall()
        'divOverallView.Visible = True
        lblDashboardView.Text = "Institution Statistics"
        getDisbursements()
        getRepayments()
        getTotalAppCount()
        getGLP()
        getCaseload()
        getPAR30()
    End Sub

    Protected Sub getDisbursements()
        Dim ds As New DataSet
        Dim cmd = New SqlCommand("Select format(isnull(sum(debit),0),'n') as DisbAmt, format(isnull(count(id),0),'n0') as DisbCount from Accounts_Transactions where Description = 'Disbursement' AND Account IN (SELECT customer_number from QUEST_APPLICATION)", con)
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "APP")
        If ds.Tables(0).Rows.Count > 0 Then
            lblDisbCount.Text = ds.Tables(0).Rows(0).Item("DisbCount")
            lblDisbAmt.Text = ds.Tables(0).Rows(0).Item("DisbAmt")
        End If
    End Sub
    Protected Sub getDisbursementsBranch(brnch As String)
        Try
            Dim ds As New DataSet
            Dim cmd = New SqlCommand("Select format(isnull(sum(debit),0),'n') as DisbAmt, format(isnull(count(acct.id),0),'n0') as DisbCount from Accounts_Transactions acct JOIN QUEST_APPLICATION qa on convert(VARCHAR,qa.ID)=acct.Refrence and (qa.CUSTOMER_NUMBER=acct.Account or qa.CUSTOMER_NUMBER=acct.Other) where Description = 'Disbursement' AND qa.BRANCH_CODE='" & brnch & "' AND acct.Account IN (SELECT customer_number from QUEST_APPLICATION)", con)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "APP")
            If ds.Tables(0).Rows.Count > 0 Then
                lblDisbCount.Text = ds.Tables(0).Rows(0).Item("DisbCount")
                lblDisbAmt.Text = ds.Tables(0).Rows(0).Item("DisbAmt")
            End If
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- getDisbursementsBranch()", ex.ToString)
        End Try
    End Sub
    Protected Sub getDisbursementsLoanOfficer(lo As String)
        Try
            Dim ds As New DataSet
            Dim cmd = New SqlCommand("Select format(isnull(sum(debit),0),'n') as DisbAmt, format(isnull(count(acct.id),0),'n0') as DisbCount from Accounts_Transactions acct JOIN QUEST_APPLICATION qa on convert(VARCHAR,qa.ID)=acct.Refrence and (qa.CUSTOMER_NUMBER=acct.Account or qa.CUSTOMER_NUMBER=acct.Other) where Description = 'Disbursement' AND qa.LO_ID='" & lo & "' AND acct.Account IN (SELECT customer_number from QUEST_APPLICATION)", con)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "APP")
            If ds.Tables(0).Rows.Count > 0 Then
                lblDisbCount.Text = ds.Tables(0).Rows(0).Item("DisbCount")
                lblDisbAmt.Text = ds.Tables(0).Rows(0).Item("DisbAmt")
            End If
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- getDisbursementsLoanOfficer()", ex.ToString)
        End Try
    End Sub

    Protected Sub getGLP()
        Try
            Dim ds As New DataSet
            'Dim cmd = New SqlCommand("select isnull(sum(acct.Debit),0)-isnull(sum(acct.Credit),0) as GLP from Accounts_Transactions acct where (acct.Category like '%Disbursement%' OR acct.Category like '%Repayment%' OR acct.Category like '%Disbursment%')", con)
            'Dim cmd = New SqlCommand("select isnull(sum(acct.Debit),0)-isnull(sum(acct.Credit),0) as GLP from Accounts_Transactions acct where (acct.Category like '%Disbursement%' OR acct.Category like '%Repayment%' OR acct.Category like '%Disbursment%') AND acct.Account IN (SELECT customer_number from QUEST_APPLICATION)", con)
            Dim cmd = New SqlCommand("select isnull(sum(acct.Debit),0)-isnull(sum(acct.Credit),0) as GLP from Accounts_Transactions acct where (acct.Description = 'Capital Repayment' OR acct.Description = 'Disbursement') AND acct.Account IN (SELECT customer_number from QUEST_APPLICATION)", con)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "APP")
            If ds.Tables(0).Rows.Count > 0 Then
                lblGLP.Text = FormatNumber(ds.Tables(0).Rows(0).Item("GLP"), 2)
            End If
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- getGLP()", ex.ToString)
        End Try
    End Sub

    Protected Sub getGLPBranch(brnch As String)
        Try
            Dim ds As New DataSet
            'Dim cmd = New SqlCommand("select isnull(sum(acct.Debit),0)-isnull(sum(acct.Credit),0) as GLP from Accounts_Transactions acct JOIN QUEST_APPLICATION qa on convert(VARCHAR,qa.ID)=acct.Refrence and (qa.CUSTOMER_NUMBER=acct.Account or qa.CUSTOMER_NUMBER=acct.Other) where (acct.Category like '%Disbursement%' OR acct.Category like '%Repayment%' OR acct.Category like '%Disbursment%') AND qa.BRANCH_CODE='" & brnch & "'", con)
            Dim cmd = New SqlCommand("select isnull(sum(acct.Debit),0)-isnull(sum(acct.Credit),0) as GLP from Accounts_Transactions acct where (acct.Description = 'Capital Repayment' OR acct.Description = 'Disbursement') AND acct.Account IN (SELECT customer_number from QUEST_APPLICATION where BRANCH_CODE='" & brnch & "')", con)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "APP")
            If ds.Tables(0).Rows.Count > 0 Then
                lblGLP.Text = FormatNumber(ds.Tables(0).Rows(0).Item("GLP"), 2)
            End If
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- getGLPBranch()", ex.ToString)
        End Try
    End Sub

    Protected Sub getGLPLoanOfficer(lo As String)
        Try
            Dim ds As New DataSet
            'Dim cmd = New SqlCommand("select isnull(sum(acct.Debit),0)-isnull(sum(acct.Credit),0) as GLP from Accounts_Transactions acct JOIN QUEST_APPLICATION qa on convert(VARCHAR,qa.ID)=acct.Refrence and (qa.CUSTOMER_NUMBER=acct.Account or qa.CUSTOMER_NUMBER=acct.Other) where (acct.Category like '%Disbursement%' OR acct.Category like '%Repayment%' OR acct.Category like '%Disbursment%') AND qa.LO_ID='" & lo & "'", con)
            Dim cmd = New SqlCommand("select isnull(sum(acct.Debit),0)-isnull(sum(acct.Credit),0) as GLP from Accounts_Transactions acct where (acct.Description = 'Capital Repayment' OR acct.Description = 'Disbursement') AND acct.Account IN (SELECT customer_number from QUEST_APPLICATION where LO_ID='" & lo & "')", con)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "APP")
            If ds.Tables(0).Rows.Count > 0 Then
                lblGLP.Text = FormatNumber(ds.Tables(0).Rows(0).Item("GLP"), 2)
            End If
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- getGLPLoanOfficer()", ex.ToString)
        End Try
    End Sub

    Protected Sub getLoanOfficers()
        Dim ds As New DataTable
        Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("conString").ConnectionString)
            Using cmd As New SqlCommand("SELECT mu.FNAME + ' '+mu.LNAME as Name,mu.USERID from MASTER_USERS mu join ParaApprovalStages pas on mu.USER_TYPE=pas.RoleId WHERE pas.StageAction='Origination'", con)
                Using sda As New SqlDataAdapter(cmd)
                    sda.Fill(ds)
                End Using
            End Using
        End Using
        loadCombo(ds, cmbViewDetails, "Name", "USERID")
    End Sub

    Protected Sub getPAR30()
        Try
            lblPAR30.Text = "0"
            Dim ds As New DataSet
            Dim txt As String = ""
            txt = txt + "select isnull(sum(tblAmort.Principal-tblRepay.Repayment),0) as PAR from "
            txt = txt + "(select loanid,sum(PRINCIPAL) as Principal from AMORTIZATION_SCHEDULE am where DATEDIFF(DAY,PAYMENT_DATE,GETDATE())>30 group by LOANID) tblAmort "
            txt = txt + "left join "
            txt = txt + "(Select act.Refrence,isnull(sum(debit-act.Credit),0) As Repayment from Accounts_Transactions act where act.Description <>'Interest Payable' and act.Description<>'Disbursement' group by act.Refrence) tblRepay "
            txt = txt + "On convert(varchar,tblAmort.LOANID)=tblRepay.Refrence"
            Dim cmd = New SqlCommand(txt, con)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "APP")
            If ds.Tables(0).Rows.Count > 0 Then
                lblPAR30.Text = FormatNumber((ds.Tables(0).Rows(0).Item("PAR") / lblGLP.Text) * 100, 2)
                If lblPAR30.Text = "NaN" Then
                    lblPAR30.Text = 0
                End If
            End If
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- getPAR30()", ex.ToString)
        End Try
    End Sub

    Protected Sub getPAR30Branch(brnch As String)
        Try
            lblPAR30.Text = "0"
            Dim ds As New DataSet
            Dim txt As String = ""
            txt = txt + "select isnull(sum(tblAmort.Principal-tblRepay.Repayment),0) as PAR from "
            txt = txt + "(select loanid,sum(PRINCIPAL) as Principal from AMORTIZATION_SCHEDULE am join QUEST_APPLICATION qa on am.LOANID=qa.ID where DATEDIFF(DAY,PAYMENT_DATE,GETDATE())>30 AND qa.BRANCH_CODE='" & brnch & "' group by LOANID) tblAmort "
            txt = txt + "left join "
            txt = txt + "(Select act.Refrence,isnull(sum(debit-act.Credit),0) As Repayment from Accounts_Transactions act join QUEST_APPLICATION qa on convert(varchar,act.Refrence)=qa.ID where act.Description <>'Interest Payable' and act.Description<>'Disbursement' AND qa.BRANCH_CODE='" & brnch & "' group by act.Refrence) tblRepay "
            txt = txt + "On convert(varchar,tblAmort.LOANID)=tblRepay.Refrence"
            Dim cmd = New SqlCommand(txt, con)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "APP")
            If ds.Tables(0).Rows.Count > 0 Then
                lblPAR30.Text = FormatNumber((ds.Tables(0).Rows(0).Item("PAR") / lblGLP.Text) * 100, 2)
                If lblPAR30.Text = "NaN" Then
                    lblPAR30.Text = 0
                End If
            End If
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- getPAR30Branch()", ex.ToString)
        End Try
    End Sub

    Protected Sub getPAR30LoanOfficer(lo As String)
        Try
            lblPAR30.Text = "0"
            Dim ds As New DataSet
            Dim txt As String = ""
            txt = txt + "select isnull(sum(tblAmort.Principal-tblRepay.Repayment),0) as PAR from "
            txt = txt + "(select loanid,sum(PRINCIPAL) as Principal from AMORTIZATION_SCHEDULE am join QUEST_APPLICATION qa on am.LOANID=qa.ID where DATEDIFF(DAY,PAYMENT_DATE,GETDATE())>30 AND qa.LO_ID='" & lo & "' group by LOANID) tblAmort "
            txt = txt + "left join "
            'txt = txt + "(Select act.Refrence,isnull(sum(debit-act.Credit),0) As Repayment from Accounts_Transactions act join QUEST_APPLICATION qa on convert(varchar,act.Refrence)=convert(varchar,qa.ID) where act.Description <>'Interest Payable' and act.Description<>'Disbursement' AND qa.LO_ID='" & lo & "' group by act.Refrence) tblRepay "
            txt = txt + "(Select act.Refrence,isnull(sum(debit-act.Credit),0) As Repayment from Accounts_Transactions act join QUEST_APPLICATION qa on convert(varchar,act.Refrence)=convert(varchar,qa.ID) where act.Description = 'Capital Repayment' AND qa.LO_ID='" & lo & "' group by act.Refrence) tblRepay "
            txt = txt + "On convert(varchar,tblAmort.LOANID)=tblRepay.Refrence"
            Dim cmd = New SqlCommand(txt, con)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "APP")
            If ds.Tables(0).Rows.Count > 0 Then
                lblPAR30.Text = FormatNumber((ds.Tables(0).Rows(0).Item("PAR") / lblGLP.Text) * 100, 2)
                If lblPAR30.Text = "NaN" Then
                    lblPAR30.Text = 0
                End If
            End If
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- getPAR30LoanOfficer()", ex.ToString)
        End Try
    End Sub
    Protected Function getPermissions(ByVal user_id As String, ByVal user_role As String) As DataTable
        Try
            Dim strConnString As String = ConfigurationManager.ConnectionStrings("Constring").ConnectionString
            Using con As New SqlConnection(strConnString)
                'string query = "INSERT INTO entity_types(description,active) values ('" + CreditRatingClass.removeSpecialCharacter(txtEntityType.Text) + "','1')";
                Dim query As String = "sp_getPermissions"
                Dim cmd As New SqlCommand(query)
                cmd.Connection = con
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("@userID", user_id)
                cmd.Parameters.AddWithValue("@userRole", user_role)
                Dim dt As New DataTable()
                If con.State = ConnectionState.Open Then
                    con.Close()
                End If
                con.Open()
                dt.Load(cmd.ExecuteReader())
                con.Close()

                If dt.Rows.Count > 0 Then
                    Return dt
                Else
                    Return Nothing
                End If
            End Using
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- getPermissions()", ex.ToString)
            Return Nothing
        End Try
    End Function
    Protected Sub getRepayments()
        Try
            Dim ds As New DataSet
            ' Dim cmd = New SqlCommand("select format(isnull(sum(credit),0),'n') as RepayAmt, format(isnull(count(id),0),'n0') as RepayCount from Accounts_Transactions where Description like '%repayment%' AND Account IN (SELECT customer_number from QUEST_APPLICATION)", con)
            'Dim cmd = New SqlCommand("select format(isnull(sum(totalamount),0),'n') as RepayAmt, format(isnull(count(id),0),'n0') as RepayCount from Repayments where CustNo IN (SELECT customer_number from QUEST_APPLICATION)", con)
            Dim cmd = New SqlCommand("select isnull(sum(acct.Credit),0)-isnull(sum(acct.Debit),0) as RepayAmt, format(isnull(count(acct.id),0),'n0') as RepayCount from Accounts_Transactions acct where (acct.Description = 'Capital Repayment') AND acct.Account IN (SELECT customer_number from QUEST_APPLICATION)", con)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "APP")
            If ds.Tables(0).Rows.Count > 0 Then
                lblRepayCount.Text = ds.Tables(0).Rows(0).Item("RepayCount")
                lblRepayAmt.Text = ds.Tables(0).Rows(0).Item("RepayAmt")
            End If
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- getRepayments()", ex.ToString)
        End Try
    End Sub

    Protected Sub getRepaymentsBranch(brnch As String)
        Try
            Dim ds As New DataSet
            'Dim cmd = New SqlCommand("select format(isnull(sum(credit),0),'n') as RepayAmt, format(isnull(count(acct.id),0),'n0') as RepayCount from Accounts_Transactions acct JOIN QUEST_APPLICATION qa on convert(VARCHAR,qa.ID)=acct.Refrence and (qa.CUSTOMER_NUMBER=acct.Account or qa.CUSTOMER_NUMBER=acct.Other) where Description like '%repayment%' AND qa.BRANCH_CODE='" & brnch & "' AND acct.Account IN (SELECT customer_number from QUEST_APPLICATION)", con)
            'Dim cmd = New SqlCommand("select format(isnull(sum(acct.totalAmount),0),'n') as RepayAmt, format(isnull(count(acct.id),0),'n0') as RepayCount from Repayments acct JOIN QUEST_APPLICATION qa on convert(VARCHAR,qa.ID)=acct.LoanID and (qa.CUSTOMER_NUMBER=acct.CustNo) where qa.BRANCH_CODE='" & brnch & "' AND acct.CustNo IN (SELECT customer_number from QUEST_APPLICATION)", con)
            Dim cmd = New SqlCommand("select isnull(sum(acct.Credit),0)-isnull(sum(acct.Debit),0) as RepayAmt, format(isnull(count(acct.id),0),'n0') as RepayCount from Accounts_Transactions acct where (acct.Description = 'Capital Repayment') AND acct.Account IN (SELECT customer_number from QUEST_APPLICATION where BRANCH_CODE='" & brnch & "')", con)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "APP")
            If ds.Tables(0).Rows.Count > 0 Then
                lblRepayCount.Text = ds.Tables(0).Rows(0).Item("RepayCount")
                lblRepayAmt.Text = ds.Tables(0).Rows(0).Item("RepayAmt")
            End If
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- getRepaymentsBranch()", ex.ToString)
        End Try
    End Sub

    Protected Sub getRepaymentsLoanOfficer(lo As String)
        Try
            Dim ds As New DataSet
            'Dim cmd = New SqlCommand("select format(isnull(sum(credit),0),'n') as RepayAmt, format(isnull(count(acct.id),0),'n0') as RepayCount from Accounts_Transactions acct JOIN QUEST_APPLICATION qa on convert(VARCHAR,qa.ID)=acct.Refrence and (qa.CUSTOMER_NUMBER=acct.Account or qa.CUSTOMER_NUMBER=acct.Other) where Description like '%repayment%' AND qa.LO_ID='" & lo & "' AND acct.Account IN (SELECT customer_number from QUEST_APPLICATION)", con)
            'Dim cmd = New SqlCommand("select format(isnull(sum(acct.totalamount),0),'n') as RepayAmt, format(isnull(count(acct.id),0),'n0') as RepayCount from Repayments acct JOIN QUEST_APPLICATION qa on convert(VARCHAR,qa.ID)=acct.LoanID and (qa.CUSTOMER_NUMBER=acct.CustNo) where qa.LO_ID='" & lo & "' AND acct.CustNo IN (SELECT customer_number from QUEST_APPLICATION)", con)
            Dim cmd = New SqlCommand("select isnull(sum(acct.Credit),0)-isnull(sum(acct.Debit),0) as RepayAmt, format(isnull(count(acct.id),0),'n0') as RepayCount from Accounts_Transactions acct where (acct.Description = 'Capital Repayment') AND acct.Account IN (SELECT customer_number from QUEST_APPLICATION where LO_ID='" & lo & "')", con)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "APP")
            If ds.Tables(0).Rows.Count > 0 Then
                lblRepayCount.Text = ds.Tables(0).Rows(0).Item("RepayCount")
                lblRepayAmt.Text = ds.Tables(0).Rows(0).Item("RepayAmt")
            End If
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- getRepaymentsLoanOfficer()", ex.ToString)
        End Try
    End Sub

    Protected Sub getTotalAppCount()
        Try
            Dim ds As New DataSet
            Dim cmd = New SqlCommand("select format(count(id),'n0') as AppCount from QUEST_APPLICATION", con)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "APP")
            If ds.Tables(0).Rows.Count > 0 Then
                lblTotalAppCount.Text = ds.Tables(0).Rows(0).Item("AppCount")
            End If
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- getTotalAppCount()", ex.ToString)
        End Try
    End Sub

    Protected Sub getTotalAppCountBranch(brnch As String)
        Try
            Dim ds As New DataSet
            Dim cmd = New SqlCommand("select format(count(id),'n0') as AppCount from QUEST_APPLICATION where BRANCH_CODE='" & brnch & "'", con)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "APP")
            If ds.Tables(0).Rows.Count > 0 Then
                lblTotalAppCount.Text = ds.Tables(0).Rows(0).Item("AppCount")
            End If
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- getTotalAppCountBranch()", ex.ToString)
        End Try
    End Sub

    Protected Sub getTotalAppCountLoanOfficer(lo As String)
        Try
            Dim ds As New DataSet
            Dim cmd = New SqlCommand("select format(count(id),'n0') as AppCount from QUEST_APPLICATION where LO_ID='" & lo & "'", con)
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "APP")
            If ds.Tables(0).Rows.Count > 0 Then
                lblTotalAppCount.Text = ds.Tables(0).Rows(0).Item("AppCount")
            End If
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- getTotalAppCountLoanOfficer()", ex.ToString)
        End Try
    End Sub
    Protected Sub mainMenu_MenuItemDataBound(ByVal sender As Object, ByVal e As MenuEventArgs)
        Dim menuitem As MenuItem = CType(e.Item, MenuItem)
        Dim url As String = Request.Url.GetLeftPart(UriPartial.Path).Trim()
        Dim navURL As String = menuitem.NavigateUrl.Trim()
        If url = navURL Then
            menuitem.Selected = True
        End If
    End Sub

    Protected Sub getRejections(ByVal roleID As String, ByVal userID As String)
        Try
            Using cmd = New SqlCommand("select ID,CUSTOMER_NUMBER as [CUST NO.],RTRIM(SURNAME+' '+FORENAMES) as NAME,CONVERT(DECIMAL(30,2),FIN_AMT) as AMOUNT,convert(varchar,isnull(nullif(APPL_DATE,'1900-01-01'),CREATED_DATE),106) as 'APPLICATION DATE' from QUEST_APPLICATION where SEND_TO='" & roleID & "' and STATUS='REJECTED' AND CREATED_BY='" & userID & "' order by CREATED_DATE desc", con)
                Dim ds As New DataSet
                adp = New SqlDataAdapter(cmd)
                adp.Fill(ds, "APP")
                If ds.Tables(0).Rows.Count > 0 Then
                    lblAppCount.Text = FormatNumber(ds.Tables(0).Rows.Count, 0)
                    lblInbox.Text = FormatNumber(ds.Tables(0).Rows.Count, 0)
                End If
            End Using
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- getRejections()", ex.ToString)
        End Try
    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            If (Trim(Session("SessionID")) = "" Or IsDBNull(Session("SessionID"))) Then
                'SecureBank.endSession(lblSessionID.Text)
                Response.Redirect("~/Login.aspx?sess=exp", True)
            End If

            If Session("OTPConfirmed") = "0" Then
                Response.Redirect("~/OTPConfirm.aspx", True)
            ElseIf Session("PasswordExpired") = "True" Or Session("PasswordTooShort") = "True" Or Session("DefaultPassword") = "True" Then
                Response.Redirect("~/ChangePassword.aspx", True)
            Else
                Page.MaintainScrollPositionOnPostBack = True
                con = New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                If Not IsPostBack Then
                    PopulateMenu()
                    lblSess.Text = Session("UserFullName").ToString
                    If Session("ROLE") = "4041" Then
                        getRejections(Session("ROLE"), Session("UserId"))
                        lblIncomingApps.Text = "REJECTED APPLICATIONS"
                        divInc.HRef = "Credit/Rejected.aspx"
                    Else
                        getApplications(Session("ROLE"), "")
                    End If
                    getArrears()
                    If Session("DASHBOARD") = "Overall" Then
                        divOverallView.Visible = True
                        getDashOverall()
                    ElseIf Session("DASHBOARD") = "Branch" Then
                        divOverallView.Visible = False
                        getDashBranch(Session("BRANCHCODE"))
                        lblSubInfo.Text = Session("BRANCHCODE") & " - " & Session("BRANCHNAME")
                    ElseIf Session("DASHBOARD") = "Individual" Then
                        divOverallView.Visible = False
                        getDashIndividual(Session("ID"))
                        lblSubInfo.Text = Session("UserFullName")
                    End If
                End If
            End If
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- Page_Load()", ex.ToString)
        End Try
    End Sub
    Protected Sub getArrears()
        Try
            Dim ds As New DataSet
            Dim dt As New dsAllReports.NewArrearsDataTable
            Dim dss As New dsAllReportsTableAdapters.NewArrearsTableAdapter
            dss.FillIncludingCurrent(dt)
            'lblGreen.Text = dt.Rows.Count
            Dim grn As Double = 0
            'lblGreenCount.Text = FormatNumber(dt.Select("DaysPast>0 and DaysPast<=90").Count, 0)
            lblGreenCount.Text = FormatNumber(dt.Select("DaysPast<=0").Count, 0)
            'grn = IIf(IsDBNull(dt.Compute("Sum(Balance)", "DaysInArrear>0 and DaysInArrear<=90")), 0, dt.Compute("Sum(Balance)", "DaysInArrear>0 and DaysInArrear<=90"))
            grn = IIf(IsDBNull(dt.Compute("Sum(InstalmentBal)", "DaysPast<=0")), 0, dt.Compute("Sum(InstalmentBal)", "DaysPast<=0"))
            lblGreen.Text = FormatNumber(grn)
            Dim yel As Double = 0
            lblYellowCount.Text = FormatNumber(dt.Select("DaysPast>0 and DaysPast<=30").Count, 0)
            yel = IIf(IsDBNull(dt.Compute("Sum(InstalmentBal)", "DaysPast>0 and DaysPast<=30")), 0, dt.Compute("Sum(InstalmentBal)", "DaysPast>0 and DaysPast<=30"))
            lblYellow.Text = FormatNumber(yel)
            Dim red As Double = 0
            lblRedCount.Text = Format(dt.Select("DaysPast>30 and DaysPast<=60").Count, 0)
            red = IIf(IsDBNull(dt.Compute("Sum(InstalmentBal)", "DaysPast>30 and DaysPast<=60")), 0, dt.Compute("Sum(InstalmentBal)", "DaysPast>30 and DaysPast<=60"))
            lblRed.Text = FormatNumber(red)
            Dim sixty As Double = 0
            lbl60Count.Text = Format(dt.Select("DaysPast>60 and DaysPast<=90").Count, 0)
            sixty = IIf(IsDBNull(dt.Compute("Sum(InstalmentBal)", "DaysPast>60 and DaysPast<=90")), 0, dt.Compute("Sum(InstalmentBal)", "DaysPast>60 and DaysPast<=90"))
            lbl60.Text = FormatNumber(sixty)
            Dim ninety As Double = 0
            lbl90Count.Text = Format(dt.Select("DaysPast>90 and DaysPast<=180").Count, 0)
            ninety = IIf(IsDBNull(dt.Compute("Sum(InstalmentBal)", "DaysPast>90 and DaysPast<=180")), 0, dt.Compute("Sum(InstalmentBal)", "DaysPast>90 and DaysPast<=180"))
            lbl90.Text = FormatNumber(ninety)
            Dim one As Double = 0
            lbl180Count.Text = Format(dt.Select("DaysPast>180").Count, 0)
            one = IIf(IsDBNull(dt.Compute("Sum(InstalmentBal)", "DaysPast>180")), 0, dt.Compute("Sum(InstalmentBal)", "DaysPast>180"))
            lbl180.Text = FormatNumber(one)
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- getArrears()", ex.ToString)
        End Try
    End Sub
    Protected Sub rdbViewBy_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rdbViewBy.SelectedIndexChanged
        If rdbViewBy.SelectedValue = "Officer" Then
            getLoanOfficers()
        ElseIf rdbViewBy.SelectedValue = "Branch" Then
            getBranches()
        ElseIf rdbViewBy.SelectedValue = "Institution" Then
            cmbViewDetails.Items.Clear()
        End If
        Dim sb = New StringBuilder()
        dashboardReportRange.RenderControl(New HtmlTextWriter(New StringWriter(sb)))
        'Dim str As String = dashboardReportRange.InnerHtml
        msgbox(sb.ToString)
    End Sub

    Private Sub cmbViewDetails_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbViewDetails.SelectedIndexChanged
        Try
            If rdbViewBy.SelectedValue = "Officer" Then
                lblSubInfo.Text = cmbViewDetails.SelectedItem.Text
                getDashIndividual(cmbViewDetails.SelectedValue)
            ElseIf rdbViewBy.SelectedValue = "Branch" Then
                lblSubInfo.Text = cmbViewDetails.SelectedItem.Text
                getDashBranch(cmbViewDetails.SelectedValue)
            ElseIf rdbViewBy.SelectedValue = "Institution" Then
                lblSubInfo.Text = ""
                getDashOverall()
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class