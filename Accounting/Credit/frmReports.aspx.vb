Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports ClosedXML.Excel
Imports CreditManager

Partial Class Credit_frmReports
    Inherits System.Web.UI.Page
    Dim adp As SqlDataAdapter
    Dim cmd As SqlCommand
    Dim con As New SqlConnection
    Dim connection As String

    Protected Sub btnPrintArrear_Click(sender As Object, e As EventArgs) Handles btnPrintArrear.Click
        openReport("rptArrears.aspx?from=" + txtDueArrearFromDate.Text + "&to=" + txtArrearToDate.Text + "&brnch=" + cmbBranchArrear.SelectedValue + "")
    End Sub

    Protected Sub btnPrintDisb_Click(sender As Object, e As EventArgs) Handles btnPrintDisb.Click
        openReport("rptDisbursements.aspx?from=" + txtDisbFromDate.Text + "&to=" + txtDisbToDate.Text + "&disb=" + cmbDisbOption.SelectedValue + "&brnch=" + cmbBranchDisb.SelectedValue + "")
    End Sub

    Protected Sub btnPrintDuePayments_Click(sender As Object, e As EventArgs) Handles btnPrintDuePayments.Click
        openReport("rptDuePayments.aspx?from=" + txtDueFromDate.Text + "&to=" + txtDueToDate.Text + "&brnch=" + cmbBranchDue.SelectedValue + "")
    End Sub

    Protected Sub btnPrintInterest_Click(sender As Object, e As EventArgs) Handles btnPrintInterest.Click
        openReport("rptEarnedInterest.aspx?from=" + txtInterestFromDate.Text + "&to=" + txtInterestToDate.Text + "&brnch=" + cmbInterestBranch.SelectedValue + "")
    End Sub

    Protected Sub btnPrintMaturity_Click(sender As Object, e As EventArgs) Handles btnPrintMaturity.Click
        openReport("rptMaturity.aspx?from=" + txtFromDate.Text + "&to=" + txtToDate.Text + "&brnch=" + branchOption.SelectedValue + "")
    End Sub

    Protected Sub btnPrintStatus_Click(sender As Object, e As EventArgs) Handles btnPrintStatus.Click
        openReport("rptStatusReport.aspx?from=" + txtStatusFromDate.Text + "&to=" + txtStatusToDate.Text + "&brnch=" + cmbStatusBranch.SelectedValue + "&status=" + cmbStatus.SelectedValue)
    End Sub

    Protected Sub btnSearchLoanID_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearchLoanID.Click
        Try
            If Trim(Session("SessionID")) = "" Or IsDBNull(Session("SessionID")) Then
                Response.Redirect("~/logout.aspx")
            Else
                'btnPrint_Click(sender, New EventArgs)
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub btnSearchName_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearchName.Click
        Try
            cmd = New SqlCommand("select ID,SURNAME+' '+FORENAMES+' '+convert(varchar,CUSTOMER_NUMBER)+' '+convert(varchar,FIN_AMT) as DISPLAY from QUEST_APPLICATION where SURNAME like '" & txtSearchName.Text & "%'", con)
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

    Protected Sub loadBranches()
        Try
            cmd = New SqlCommand("select * from BNCH_DETAILS", con)
            Dim ds As New DataSet
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "bnch")
            If ds.Tables(0).Rows.Count > 0 Then
                branchOption.DataSource = ds.Tables(0)
                branchOption.DataTextField = "BNCH_NAME"
                branchOption.DataValueField = "BNCH_CODE"
                cmbBranchArrear.DataSource = ds.Tables(0)
                cmbBranchArrear.DataTextField = "BNCH_NAME"
                cmbBranchArrear.DataValueField = "BNCH_CODE"
                cmbBranchDisb.DataSource = ds.Tables(0)
                cmbBranchDue.DataSource = ds.Tables(0)
                cmbBranchDisb.DataTextField = "BNCH_NAME"
                cmbBranchDisb.DataValueField = "BNCH_CODE"
                cmbBranchDue.DataTextField = "BNCH_NAME"
                cmbBranchDue.DataValueField = "BNCH_CODE"
                cmbBranchBranch.DataSource = ds.Tables(0)
                cmbBranchBranch.DataTextField = "BNCH_NAME"
                cmbBranchBranch.DataValueField = "BNCH_CODE"
                cmbInterestBranch.DataSource = ds.Tables(0)
                cmbInterestBranch.DataTextField = "BNCH_NAME"
                cmbInterestBranch.DataValueField = "BNCH_CODE"
                'loadCombo(ds.Tables(0), cmbInterestBranch, "BNCH_NAME", "BNCH_CODE")
                cmbStatusBranch.DataSource = ds.Tables(0)
                cmbStatusBranch.DataTextField = "BNCH_NAME"
                cmbStatusBranch.DataValueField = "BNCH_CODE"
            Else
                branchOption.DataSource = Nothing
            End If
            branchOption.DataBind()
            cmbBranchArrear.DataBind()
            cmbBranchDue.DataBind()
            cmbBranchDisb.DataBind()
            cmbBranchBranch.DataBind()
            cmbInterestBranch.DataBind()
            cmbStatusBranch.DataBind()
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub loadStatus()
        Try
            statusOption.Items.Clear()
            statusOption.Items.Add("")
            cmd = New SqlCommand("select distinct STATUS from QUEST_APPLICATION", con)
            Dim ds As New DataSet
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "bnch")
            If ds.Tables(0).Rows.Count > 0 Then
                statusOption.DataSource = ds.Tables(0)
                statusOption.DataTextField = "STATUS"
                statusOption.DataValueField = "STATUS"
                cmbStatus.DataSource = ds.Tables(0)
                cmbStatus.DataTextField = "STATUS"
                cmbStatus.DataValueField = "STATUS"
            Else
                statusOption.DataSource = Nothing
            End If
            statusOption.DataBind()
            cmbStatus.DataBind()
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub lstLoans_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstLoans.SelectedIndexChanged
        Try
            Dim loanID = lstLoans.SelectedValue
            txtLoanID.Text = loanID
            btnSearchLoanID_Click(sender, New EventArgs)
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub openReport(url As String)
        Dim EncQuery As New BankEncryption64
        Dim strscript As String
        strscript = "<script langauage=JavaScript>"
        strscript += "window.open('" & url & "')"
        strscript += "</script>"
        ClientScript.RegisterStartupScript(Me.GetType(), "newwin", strscript)
    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            Page.MaintainScrollPositionOnPostBack = True
            con = New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
            If Not IsPostBack Then
                loadBranches()
                loadStatus()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub btnPrintBranch_Click(sender As Object, e As EventArgs) Handles btnPrintBranch.Click
        openReport("rptBranchReport.aspx?from=" + txtBranchFromDate.Text + "&to=" + txtBranchToDate.Text + "&brnch=" + cmbBranchBranch.SelectedValue + "")
    End Sub
    Protected Sub btnPrintRBZPack_Click(sender As Object, e As EventArgs) Handles btnPrintRBZPack.Click
        If txtRBZFrom.Text <> "" And txtRBZTo.Text <> "" Then
            ExportExcel(sender, e)
        Else
            notify("Enter Required Parameters", "error")
            Exit Sub
        End If
    End Sub
    Protected Sub ExportExcel(sender As Object, e As EventArgs)
        ' get instruction details
        ' get instruction details
        ' Try
        'Using con
        Dim dateFrom As String = txtRBZFrom.Text
            Dim dateTo As String = txtRBZTo.Text
        Dim fullConame As String = "Escrow Financial Services"
        ' createReportfile(dateTo)
        Dim cmdfull As New SqlCommand("SP_IncomeStatement")
            cmdfull.CommandType = CommandType.StoredProcedure
            cmdfull.Parameters.AddWithValue("@DATEFROM", dateFrom)
            cmdfull.Parameters.AddWithValue("@DATETO", dateTo)

            Dim cmdeft As New SqlCommand("declare @tDate date ='" & dateTo & "' SELECT DaysOverdue as [CATEGORY],CustType as [CLIENT GROUP],(case DaysOverdue when 'TOTAL DOUBTFUL' then '61-90 Days' when 'TOTAL LOSS' then '91+ Days' when 'TOTAL PASS - CURRENT' then '0' when 'TOTAL SPECIAL MENTION' then '1-30 Days' when 'TOTAL SUBSTANDARD' then '31-60 Days' end) AS [DAYS OUTSTANDING/ARREARS],sum(LoanAmount) as [TOTAL LOANS],(case DaysOverdue when 'TOTAL DOUBTFUL' then 0.75 when 'TOTAL LOSS' then 1.0 when 'TOTAL PASS - CURRENT' then 0.01 when 'TOTAL SPECIAL MENTION' then 0.2 when 'TOTAL SUBSTANDARD' then 0.5 end) AS [SUPERVISORY PROVISION x100%],(case DaysOverdue when 'TOTAL DOUBTFUL' then 0.75*sum(LoanAmount) when 'TOTAL LOSS' then sum(LoanAmount) when 'TOTAL PASS - CURRENT' then 0.01*sum(LoanAmount) when 'TOTAL SPECIAL MENTION' then 0.2*sum(LoanAmount) when 'TOTAL SUBSTANDARD' then 0.5*sum(LoanAmount) end) as [PROVISIONS AMOUNT] FROM (SELECT *,CASE WHEN NoDays<=0 then 'TOTAL PASS - CURRENT' when NoDays>0 and NoDays<=30 then 'TOTAL SPECIAL MENTION' when NoDays>30 and NoDays<=60 then 'TOTAL SUBSTANDARD' when NoDays>60 and NoDays<=90 then 'TOTAL DOUBTFUL' when NoDays>90 and NoDays<=180 then 'TOTAL LOSS' when NoDays>180 then 'TOTAL LOSS' end as DaysOverdue FROM (SELECT sum(Balance) as Balance,sum(NoLoans) as NoLoans,sum(LoanAmount) as LoanAmount,DATEDIFF(day,maturitydate_,getdate()) as NoDays,CustType FROM ((SELECT account,Refrence ,SUM(debit-credit) as Balance FROM Accounts_Transactions where trxndate<=@tDate group BY Refrence,Account) tblBal join (SELECT qa.customer_type as CustType,qa.ID,qa.CUSTOMER_NUMBER,max(am.payment_date) as MaturityDate_,count(distinct qa.id) as NoLoans,FIN_AMT as LoanAmount from AMORTIZATION_SCHEDULE am JOIN QUEST_APPLICATION qa ON am.LOANID=qa.ID where qa.DISBURSED_DATE<=@tDate GROUP BY qa.CUSTOMER_TYPE,qa.ID,qa.CUSTOMER_NUMBER,qa.FIN_AMT) tblMatDate on tblbal.account=tblmatdate.customer_number and tblBal.Refrence =convert(varchar,tblMatDate.ID) JOIN (SELECT k.* from QUEST_APPLICATION k) cd on cd.customer_number=tblmatdate.customer_number and cd.ID=tblMatDate.ID) group by MaturityDate_,CustType) tbl) tblTotal where Balance >0  group by DaysOverdue,CustType order by [DAYS OUTSTANDING/ARREARS]")
        Dim cmdWNP As New SqlCommand("select  case when r.Sector = '' then 'Other' else r.Sector end as 'Purpose of Loan',COUNT(r.ID) as 'Total Number of Loans',(select count(q.id) from QUEST_APPLICATION q where q.GENDER = 'F' and q.Sector = r.Sector) as 'Number of Female Clients',sum (r.fin_amt) as 'Value',convert(numeric(18,6),(convert(numeric(18,6),sum(r.fin_amt))/convert(numeric(18,6),(select sum(m.FIN_AMT) from quest_application m)))*100) as [Percentage Tot Amount] from QUEST_APPLICATION r group by r.Sector")
        Dim cmdCHEQUES As New SqlCommand("declare @fdate date ='" & dateFrom & "' declare @tDate date='" & dateTo & "' select a.PAYMENT_DATE as [MATURITY DATE],b.SURNAME + ' ' + b.FORENAMES as [NAME],b.FIN_AMT AS [LOAN AMOUNT],case when isnull((select sum(k.payment) from AMORTIZATION_SCHEDULE k where k.LOANID =b.ID),0)<isnull((select sum(e.totalamount) from Repayments e where e.LoanID =b.ID),0) then 0 else isnull((select sum(k.payment) from AMORTIZATION_SCHEDULE k where k.LOANID =b.ID),0)-isnull((select sum(e.totalamount) from Repayments e where e.LoanID =b.ID),0) end as [OUTSTANDING BALANCE],case when isnull((select sum(k.payment) from AMORTIZATION_SCHEDULE k where k.LOANID =b.ID and k.PAYMENT_DATE  between @fdate and @tDate),0)< isnull((select sum(e.totalamount) from Repayments e where e.LoanID =b.ID and e.TrxnDate between @fdate and @tDate),0) then 0 else isnull((select sum(k.payment) from AMORTIZATION_SCHEDULE k where k.LOANID =b.ID and k.PAYMENT_DATE  between @fdate and @tDate),0)- isnull((select sum(e.totalamount) from Repayments e where e.LoanID =b.ID and e.TrxnDate between @fdate and @tDate),0) end as [ARREARS] from AMORTIZATION_SCHEDULE a,QUEST_APPLICATION b where a.ID in (select max(v.ID) from AMORTIZATION_SCHEDULE v where v.PAYMENT_DATE  between @fdate and @tDate group by v.LOANID) and a.LOANID=b.ID order by a.PAYMENT_DATE desc")
        Dim cmdFOREIGN As New SqlCommand("declare @fdate date ='" & dateFrom & "' declare @tDate date='" & dateTo & "' SELECT 'A' AS [No.],'NUMBER OF BRANCHES' AS [ATTRIBUTE],convert(nvarchar(500), count(BNCH_CODE)) as 'VALUE'  FROM BNCH_DETAILS union select 'B' AS [No.],'NUMBER OF OUTSTANDING LOANS' AS [ATTRIBUTE],convert(nvarchar(500), count(qa.ID)) as 'VALUE' from QUEST_APPLICATION qa left join (select Refrence,sum(debit-credit) as Bal from Accounts_Transactions where ISNUMERIC(refrence)=1 and account IN (Select t.customer_number from QUEST_APPLICATION t) and trxndate<=@tDate group by Refrence) t on qa.id=t.refrence where t.bal>0 and qa.DISBURSED_DATE>=@fDate and qa.DISBURSED_DATE<=@tDate union select 'C' AS [No.],'NUMBER OF BORROWING GROUPS' AS [ATTRIBUTE],convert(nvarchar(500), count(id)) as 'VALUE' from QUEST_APPLICATION where [CUSTOMER_TYPE]='Group' union select 'D' AS [No.],'NUMBER OF ACTIVE LOAN CLIENTS RECEIVING LOANS AS MEMBERS OF A GROUP' AS [ATTRIBUTE], convert(nvarchar(500),count(qa.ID)) as 'VALUE' from QUEST_GROUP_MEMBERS qa WHERE qa.CUSTOMER_NUMBER in (select h.customer_number from QUEST_APPLICATION h) union select 'E' AS [No.],'NUMBER OF ACTIVE LOAN CLIENTS RECEIVING LOANS AS INDIVIDUAL' AS [ATTRIBUTE], convert(nvarchar(500),count(distinct qa.customer_number)) as 'VALUE' from QUEST_APPLICATION qa left join (select Refrence,sum(debit-credit) as Bal from Accounts_Transactions where ISNUMERIC(refrence)=1 and account IN (Select t.customer_number from QUEST_APPLICATION t)  and trxndate<=@tDate group by Refrence) t on qa.id=t.refrence where t.bal>0 and qa.DISBURSED_DATE>=@fDate and qa.DISBURSED_DATE<=@tDate and CUSTOMER_TYPE in ('Individual') UNION select 'F' AS [No.],'NUMBER OF LOANS WITH A DISBURSED LOAN AMOUNT MORE THAN $10,000' AS [ATTRIBUTE], convert(nvarchar(500),count(qa.id)) as 'VALUE' from QUEST_APPLICATION qa where qa.FIN_AMT>10000 and qa.DISBURSED_DATE between @fDate and @tDate union select 'G' AS [No.],'NUMBER OF LOANS WITH A DISBURSED LOAN AMOUNT MORE THAN $20,000' AS [ATTRIBUTE], convert(nvarchar(500),count(qa.id)) as 'VALUE' from QUEST_APPLICATION qa where qa.FIN_AMT>20000 and qa.DISBURSED_DATE between @fDate and @tDate UNION select 'H' AS [No.],'NUMBER OF FEMALE BORROWERS' AS [ATTRIBUTE], convert(nvarchar(500),count(qa.id)) as 'VALUE' from QUEST_APPLICATION qa where qa.DISBURSED_DATE between @fDate and @tDate AND qa.CUSTOMER_TYPE in ('Individual') and ISNULL(qa.GENDER,qa.DirectorGender)='F' UNION select 'I' AS [No.],'NUMBER OF INDIVIDUAL LOANS' AS [ATTRIBUTE], convert(nvarchar(500),count(qa.id)) as 'VALUE' from QUEST_APPLICATION qa where qa.DISBURSED_DATE between @fDate and @tDate AND qa.CUSTOMER_TYPE in ('Individual')")

        Dim sdafull As New SqlDataAdapter()
        Dim sdaeft As New SqlDataAdapter()
        Dim sdaWNP As New SqlDataAdapter()
        Dim sdaCHEQUES As New SqlDataAdapter()
        Dim sdaFOREIGN As New SqlDataAdapter()

        cmdfull.Connection = con
        cmdeft.Connection = con
        cmdWNP.Connection = con
        cmdCHEQUES.Connection = con
        cmdFOREIGN.Connection = con

        sdafull.SelectCommand = cmdfull
        sdaeft.SelectCommand = cmdeft
        sdaWNP.SelectCommand = cmdWNP
        sdaCHEQUES.SelectCommand = cmdCHEQUES
        sdaFOREIGN.SelectCommand = cmdFOREIGN

        Dim dtfull_income As New DataTable()
        Dim dteft_AssetQuality As New DataTable()
        Dim dtWNP_DISTRIBUTION As New DataTable()
        Dim dtCHEQUES_MATURITY As New DataTable()
        Dim dtFOREIGN_OUTREACH As New DataTable()

        sdafull.Fill(dtfull_income)

        sdaeft.Fill(dteft_AssetQuality)
        sdaWNP.Fill(dtWNP_DISTRIBUTION)
        sdaCHEQUES.Fill(dtCHEQUES_MATURITY)
        sdaFOREIGN.Fill(dtFOREIGN_OUTREACH)
        con.Close()
        Using wb As New XLWorkbook()
            Dim Coverpage_dset = Co_COVERPAGE_DSet()
            wb.Worksheets.Add(Coverpage_dset, "COVER SHEET").Row(1).InsertRowsAbove(6)
            wb.Worksheet("COVER SHEET").Row(1).Cell("A").SetValue("RESERVE BANK OF ZIMBABWE")
            wb.Worksheet("COVER SHEET").Row(2).Cell("B").SetValue("Licence No : ")

            wb.Worksheets.Add(dtfull_income, "COMPREHENSIVE INCOME").Row(1).InsertRowsAbove(6)
            wb.Worksheet("COMPREHENSIVE INCOME").Row(1).Cell("A").SetValue("COMPREHENSIVE INCOME REPORT FOR " & fullConame)
            wb.Worksheet("COMPREHENSIVE INCOME").Row(2).Cell("A").SetValue("Financial Year: ")
            wb.Worksheet("COMPREHENSIVE INCOME").Row(2).Cell("B").SetValue(Date.Now.Year)
            wb.Worksheet("COMPREHENSIVE INCOME").Row(3).Cell("A").SetValue("Start Date: ")
            wb.Worksheet("COMPREHENSIVE INCOME").Row(3).Cell("B").SetValue(dateFrom)
            wb.Worksheet("COMPREHENSIVE INCOME").Row(4).Cell("A").SetValue("End Date: ")
            wb.Worksheet("COMPREHENSIVE INCOME").Row(4).Cell("B").SetValue(dateTo)

            Dim BalSheet_DS = BalSheet_DSet(dateFrom, dateTo)
            wb.Worksheets.Add(BalSheet_DS, "BALANCE SHEET").Row(1).InsertRowsAbove(6)
            wb.Worksheet("BALANCE SHEET").Row(1).Cell("A").SetValue("BALANCE SHEET")
            wb.Worksheet("BALANCE SHEET").Row(2).Cell("A").SetValue("Financial Year: ")
            wb.Worksheet("BALANCE SHEET").Row(2).Cell("B").SetValue(Date.Now.Year)
            wb.Worksheet("BALANCE SHEET").Row(3).Cell("A").SetValue("Start Date: ")
            wb.Worksheet("BALANCE SHEET").Row(3).Cell("B").SetValue(dateFrom)
            wb.Worksheet("BALANCE SHEET").Row(4).Cell("A").SetValue("End Date: ")
            wb.Worksheet("BALANCE SHEET").Row(4).Cell("B").SetValue(dateTo)

            wb.Worksheets.Add(dteft_AssetQuality, "ASSET QUALITY").Row(1).InsertRowsAbove(6)
            wb.Worksheet("ASSET QUALITY").Row(1).Cell("A").SetValue("ASSET QUALITY REPORT FOR " & fullConame)
            wb.Worksheet("ASSET QUALITY").Row(2).Cell("A").SetValue("Financial Year: ")
            wb.Worksheet("ASSET QUALITY").Row(2).Cell("B").SetValue(Date.Now.Year)
            wb.Worksheet("ASSET QUALITY").Row(3).Cell("A").SetValue("Start Date: ")
            wb.Worksheet("ASSET QUALITY").Row(3).Cell("B").SetValue(dateFrom)
            wb.Worksheet("ASSET QUALITY").Row(4).Cell("A").SetValue("End Date: ")
            wb.Worksheet("ASSET QUALITY").Row(4).Cell("B").SetValue(dateTo)

            wb.Worksheets.Add(dtWNP_DISTRIBUTION, "DISTRIBUTION").Row(1).InsertRowsAbove(6)
            wb.Worksheet("DISTRIBUTION").Row(1).Cell("A").SetValue("DISTRIBUTION REPORT FOR " & fullConame)
            wb.Worksheet("DISTRIBUTION").Row(2).Cell("A").SetValue("Financial Year: ")
            wb.Worksheet("DISTRIBUTION").Row(2).Cell("B").SetValue(Date.Now.Year)
            wb.Worksheet("DISTRIBUTION").Row(3).Cell("A").SetValue("Start Date: ")
            wb.Worksheet("DISTRIBUTION").Row(3).Cell("B").SetValue(dateFrom)
            wb.Worksheet("DISTRIBUTION").Row(4).Cell("A").SetValue("End Date: ")
            wb.Worksheet("DISTRIBUTION").Row(4).Cell("B").SetValue(dateTo)

            wb.Worksheets.Add(dtCHEQUES_MATURITY, "MATURITY PROFILE").Row(1).InsertRowsAbove(6)
            wb.Worksheet("MATURITY PROFILE").Row(1).Cell("A").SetValue("MATURITY PROFILE REPORT FOR " & fullConame)
            wb.Worksheet("MATURITY PROFILE").Row(2).Cell("A").SetValue("Financial Year: ")
            wb.Worksheet("MATURITY PROFILE").Row(2).Cell("B").SetValue(Date.Now.Year)
            wb.Worksheet("MATURITY PROFILE").Row(3).Cell("A").SetValue("Start Date: ")
            wb.Worksheet("MATURITY PROFILE").Row(3).Cell("B").SetValue(dateFrom)
            wb.Worksheet("MATURITY PROFILE").Row(4).Cell("A").SetValue("End Date: ")
            wb.Worksheet("MATURITY PROFILE").Row(4).Cell("B").SetValue(dateTo)

            wb.Worksheets.Add(dtFOREIGN_OUTREACH, "OUTREACH").Row(1).InsertRowsAbove(6)
            wb.Worksheet("OUTREACH").Row(1).Cell("A").SetValue("OUTREACH REPORT FOR " & fullConame)
            wb.Worksheet("OUTREACH").Row(2).Cell("A").SetValue("Financial Year: ")
            wb.Worksheet("OUTREACH").Row(2).Cell("B").SetValue(Date.Now.Year)
            wb.Worksheet("OUTREACH").Row(3).Cell("A").SetValue("Start Date: ")
            wb.Worksheet("OUTREACH").Row(3).Cell("B").SetValue(dateFrom)
            wb.Worksheet("OUTREACH").Row(4).Cell("A").SetValue("End Date: ")
            wb.Worksheet("OUTREACH").Row(4).Cell("B").SetValue(dateTo)

            Dim Clas_Set_PORTaCTIVITY = Class_DSet(dateFrom, dateTo)
            wb.Worksheets.Add(Clas_Set_PORTaCTIVITY, "PORTFOLIO ACTIVITY REPORT").Row(1).InsertRowsAbove(6)
            wb.Worksheet("PORTFOLIO ACTIVITY REPORT").Row(1).Cell("A").SetValue("PORTFOLIO ACTIVITY REPORT FOR " & fullConame)
            wb.Worksheet("PORTFOLIO ACTIVITY REPORT").Row(2).Cell("A").SetValue("Financial Year: ")
            wb.Worksheet("PORTFOLIO ACTIVITY REPORT").Row(2).Cell("B").SetValue(Date.Now.Year)
            wb.Worksheet("PORTFOLIO ACTIVITY REPORT").Row(3).Cell("A").SetValue("Start Date: ")
            wb.Worksheet("PORTFOLIO ACTIVITY REPORT").Row(3).Cell("B").SetValue(dateFrom)
            wb.Worksheet("PORTFOLIO ACTIVITY REPORT").Row(4).Cell("A").SetValue("End Date: ")
            wb.Worksheet("PORTFOLIO ACTIVITY REPORT").Row(4).Cell("B").SetValue(dateTo)

            Dim IND_Set_PORTQUALITY = INDUSTRY_DSet(dateTo)
            wb.Worksheets.Add(IND_Set_PORTQUALITY, "PORTFOLIO QUALITY").Row(1).InsertRowsAbove(6)
            wb.Worksheet("PORTFOLIO QUALITY").Row(1).Cell("A").SetValue("PORTFOLIO QUALITY REPORT FOR " & fullConame)
            wb.Worksheet("PORTFOLIO QUALITY").Row(2).Cell("A").SetValue("Financial Year: ")
            wb.Worksheet("PORTFOLIO QUALITY").Row(2).Cell("B").SetValue(Date.Now.Year)
            wb.Worksheet("PORTFOLIO QUALITY").Row(3).Cell("A").SetValue("Start Date: ")
            wb.Worksheet("PORTFOLIO QUALITY").Row(3).Cell("B").SetValue(dateFrom)
            wb.Worksheet("PORTFOLIO QUALITY").Row(4).Cell("A").SetValue("End Date: ")
            wb.Worksheet("PORTFOLIO QUALITY").Row(4).Cell("B").SetValue(dateTo)

            Dim INDUSTRY_DSet_TOPTWENTY = INDUSTRY_DSet_TOPTWE(dateFrom, dateTo)
            wb.Worksheets.Add(INDUSTRY_DSet_TOPTWENTY, "TOP TWENTY BORROWERS").Row(1).InsertRowsAbove(6)
            wb.Worksheet("TOP TWENTY BORROWERS").Row(1).Cell("A").SetValue("TOP TWENTY BORROWERS REPORT FOR " & fullConame)
            wb.Worksheet("TOP TWENTY BORROWERS").Row(2).Cell("A").SetValue("Financial Year: ")
            wb.Worksheet("TOP TWENTY BORROWERS").Row(2).Cell("B").SetValue(Date.Now.Year)
            wb.Worksheet("TOP TWENTY BORROWERS").Row(3).Cell("A").SetValue("Start Date: ")
            wb.Worksheet("TOP TWENTY BORROWERS").Row(3).Cell("B").SetValue(dateFrom)
            wb.Worksheet("TOP TWENTY BORROWERS").Row(4).Cell("A").SetValue("End Date: ")
            wb.Worksheet("TOP TWENTY BORROWERS").Row(4).Cell("B").SetValue(dateTo)

            Dim INDUSTRY_DSet_Profile = Co_Profile_DSet()
            wb.Worksheets.Add(INDUSTRY_DSet_Profile, "COMPANY PROFILE").Row(1).InsertRowsAbove(6)
            wb.Worksheet("COMPANY PROFILE").Row(1).Cell("A").SetValue("TOP TWENTY BORROWERS REPORT FOR " & fullConame)
            wb.Worksheet("COMPANY PROFILE").Row(2).Cell("A").SetValue("Financial Year: ")
            wb.Worksheet("COMPANY PROFILE").Row(2).Cell("B").SetValue(Date.Now.Year)
            wb.Worksheet("COMPANY PROFILE").Row(3).Cell("A").SetValue("Start Date: ")
            wb.Worksheet("COMPANY PROFILE").Row(3).Cell("B").SetValue(dateFrom)
            wb.Worksheet("COMPANY PROFILE").Row(4).Cell("A").SetValue("End Date: ")
            wb.Worksheet("COMPANY PROFILE").Row(4).Cell("B").SetValue(dateTo)
            Response.Clear()
            Response.Buffer = True
            Response.Charset = ""
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"
            Response.AddHeader("content-disposition", "attachment;filename=RBZREPORTPACKFOR_" & fullConame.Replace(" ", "_") & Date.Now.ToString("dd_MM_yy_mmsss") & ".xlsx")
            Using MyMemoryStream As New MemoryStream()
                wb.SaveAs(MyMemoryStream)
                MyMemoryStream.WriteTo(Response.OutputStream)
                Response.Flush()
                Response.End()
            End Using
        End Using
        ' End Using
        'Catch ex As Exception
        '    msgbox(ex.Message.ToString)
        'End Try
    End Sub
    Private Function Class_DSet(dateFrom As String, dateTo As String) As DataTable
        ' get analysis by class details
        Dim strClss As String = "declare @fdate date ='" & dateFrom & "' declare @tDate date='" & dateTo & "' select * from (select * from (select ISNULL(AVG(fin_tenor),0) as AvgLoanTerm from QUEST_APPLICATION where DISBURSED_DATE >= @fDate and DISBURSED_DATE <= @tDate) lt left join (select count(id) as NoLoansDisbursed,ISNULL(sum(fin_amt),0) as ValueLoansDisbursed from QUEST_APPLICATION where DISBURSED_DATE >= @fDate and DISBURSED_DATE <= @tDate) dis on 1=1 left join (select count(id) as TotNoClients from CUSTOMER_DETAILS) tot on 1=1 left join (select count(ID) as NoOutstandingLoans,count(distinct customer_number) as NoActiveClients from QUEST_APPLICATION qa left join (select Refrence,sum(debit-credit) as Bal from Accounts_Transactions where ISNUMERIC(refrence)=1 and account in (select t.customer_number from QUEST_APPLICATION t) and trxndate<=@tDate group by Refrence) t on qa.id=t.refrence where t.bal>0 and qa.DISBURSED_DATE>=@fDate and qa.DISBURSED_DATE<=@tDate) o on 1=1 left join (select count(ID) as NoOutstandingLoansAtStart,count(distinct customer_number) as NoActiveClientsAtStart from QUEST_APPLICATION qa left join (select Refrence,sum(debit-credit) as Bal from Accounts_Transactions where ISNUMERIC(refrence)=1 and account in (select t.customer_number from QUEST_APPLICATION t) and trxndate<@fDate group by Refrence) t on qa.id=t.refrence where t.bal>0 and qa.DISBURSED_DATE<@fDate) u on 1=1 left join (select count(ID) as NoOutstandingLoansAtEnd,count(distinct customer_number) as NoActiveClientsAtEnd from QUEST_APPLICATION qa left join (select Refrence,sum(debit-credit) as Bal from Accounts_Transactions where ISNUMERIC(refrence)=1 and account in (select t.customer_number from QUEST_APPLICATION t) and trxndate<@tDate group by Refrence) t on qa.id=t.refrence where t.bal>0 and qa.DISBURSED_DATE<@tDate) p on 1=1 left join (select count(id) as NoNewClientLoans, count(distinct customer_number) as NoClients1stLoan from QUEST_APPLICATION qa where CUSTOMER_NUMBER not in (select CUSTOMER_NUMBER from QUEST_APPLICATION q where DISBURSED_DATE<@fDate) and DISBURSED_DATE>=@fDate and DISBURSED_DATE<=@tDate) s on 1=1 left join (select count(id) as NoOldClientLoans, count(distinct customer_number) as NoClients2ndLoan from QUEST_APPLICATION qa where CUSTOMER_NUMBER in (select CUSTOMER_NUMBER from QUEST_APPLICATION q where DISBURSED_DATE<@fDate) and DISBURSED_DATE>=@fDate and DISBURSED_DATE<=@tDate) k on 1=1) tbl "
        Dim daClss As New SqlDataAdapter
        Dim dsClss As New DataTable
        Dim cmdselectClss As SqlCommand = New SqlCommand(strClss, con)
        daClss.SelectCommand = cmdselectClss
        con.Open()
        daClss.Fill(dsClss)
        con.Close()
        Return dsClss
        ' get analysis by class details
    End Function
    Private Function INDUSTRY_DSet(dateTo As String) As DataTable
        ' get analysis by class details
        Dim strClss As String = "declare @tdate date ='" & dateTo & "' select surname + ' ' + forenames AS [NAME OF BORROWER],[ADDRESS],ISNULL(GENDER,DirectorGender) AS [GENDER],FIN_AMT AS [AMOUNT DISBURSED],FIN_TENOR AS [TENURE],FIN_PURPOSE AS [PURPOSE] ,ValueArrears AS [VALUE OF ARREARS],NoDays AS [No. OF DAYS],case when (select sum(h.debit-h.credit) from Accounts_Transactions h where ISNUMERIC(h.refrence)=1 and h.account=q.CUSTOMER_NUMBER and h.Refrence =convert(varchar,q.ID))<0 then 0 else ([ValueArrears] / (select sum(h.debit-h.credit) from Accounts_Transactions h where ISNUMERIC(h.refrence)=1 and h.account=q.CUSTOMER_NUMBER and h.Refrence =convert(varchar,q.ID)))*100 end AS [ARREARS %],DaysOverdue ,Case when FIN_AMT <=0 then 0 else (case when (select sum(h.debit-h.credit) from Accounts_Transactions h where ISNUMERIC(h.refrence)=1 and h.account=q.CUSTOMER_NUMBER and h.Refrence =convert(varchar,q.ID))<0 then 0 else (select sum(h.debit-h.credit) from Accounts_Transactions h where ISNUMERIC(h.refrence)=1 and h.account=q.CUSTOMER_NUMBER and h.Refrence =convert(varchar,q.ID)) end)/ [FIN_AMT]*100 end as [OUTSTANDING %],isnull(CREATED_BY,MODIFIED_BY) as CREATED_BY from QUEST_APPLICATION q join (select loanid,sum(t.bal) as ValueArrears,count(LOANID) as NoLoansArrears,nodays,case when NoDays<0 then 'Unexpired' when NoDays>0 and NoDays<=30 then '1-30Days' when NoDays>30 and NoDays<=60 then '31-60Days' when NoDays>60 and NoDays<=90 then '61-90Days' when NoDays>90 and NoDays<=180 then '91-180Days' when NoDays>180 then '>180Days' end as DaysOverdue from ((select am.LOANID,max(am.PAYMENT_DATE) as MaturityDate,datediff(day,max(am.PAYMENT_DATE),@tDate) as NoDays from QUEST_APPLICATION qa left join AMORTIZATION_SCHEDULE am on qa.id=am.LOANID group by am.loanid having max(am.payment_no)>0) qa left join (select Refrence,sum(debit-credit) as Bal from Accounts_Transactions where ISNUMERIC(refrence)=1 and account in (select t.customer_number from QUEST_APPLICATION t) and trxndate<@tDate group by Refrence) t on qa.LOANID=t.refrence) where t.bal>0 and qa.MaturityDate<@tDate group by NoDays,loanid ) ag on q.id=ag.LOANID "
        Dim daClss As New SqlDataAdapter
        Dim dsClss As New DataTable
        Dim cmdselectClss As SqlCommand = New SqlCommand(strClss, con)
        daClss.SelectCommand = cmdselectClss
        con.Open()
        daClss.Fill(dsClss)
        con.Close()
        Return dsClss
        ' get analysis by class details
    End Function
    Private Function INDUSTRY_DSet_TOPTWE(dateFrom As String, dateTo As String) As DataTable
        ' get analysis by class details
        Dim strClss As String = "declare @fdate date ='" & dateFrom & "' declare @tDate date='" & dateTo & "' select top 20 t.CUSTOMER_NUMBER as [Account No.],SURNAME + ' ' + FORENAMES as [NAME OF BORROWER],NoLoans AS [No. OF LOANS],SumAmt AS [TOTAL VALUE OF LOANS],Balance AS [OUTSTANDING BALANCE], ISNULL(CREATED_BY, MODIFIED_BY) AS [CREATED BY] from CUSTOMER_DETAILS cd join (select customer_number, count(id) as NoLoans,sum(fin_amt) as SumAmt from QUEST_APPLICATION where DISBURSED_DATE between @fDate  and @tDate group by customer_number) t left join (select Account,sum(debit-credit) as Balance from Accounts_Transactions where Account in (select t.customer_number from QUEST_APPLICATION t) and TrxnDate between @fDate  and @tDate group by Account) trxn on trxn.Account=t.customer_number on cd.CUSTOMER_NUMBER=t.CUSTOMER_NUMBER order by SumAmt desc "
        Dim daClss As New SqlDataAdapter
        Dim dsClss As New DataTable
        Dim cmdselectClss As SqlCommand = New SqlCommand(strClss, con)
        daClss.SelectCommand = cmdselectClss
        con.Open()
        daClss.Fill(dsClss)
        con.Close()
        Return dsClss
        ' get analysis by class details
    End Function
    Private Function Co_Profile_DSet() As DataTable
        ' get analysis by class details
        Dim strClss As String = "(SELECT TOP 1 'A' AS [No.],'NAME OF INSTITUTION' AS [COMPANY PROFILE],convert(nvarchar(500), [1 NAME OF INSTITUTION]) as 'Desc'  FROM Comp_profile) union (SELECT TOP 1  'B' AS [No.],'LICENCE NUMBER',convert(nvarchar(500), [2 LICENCE NUMBER])  FROM Comp_profile) union (SELECT TOP 1  'C' AS [No.],'DATE COMMENCED OPERATIONS',convert(nvarchar(500), [3 DATE COMMENCED OPERATIONS])  FROM Comp_profile)  union  (SELECT TOP 1  'D' AS [No.],'PHYSICAL ADDRESS',convert(nvarchar(500), [4 PHYSICAL ADDRESS])  FROM Comp_profile)  union (SELECT TOP 1  'E' AS [No.],'POSTAL ADDRESS',convert(nvarchar(500), [5 POSTAL ADDRESS])  FROM Comp_profile)  union   (SELECT TOP 1  'F' AS [No.],'CONTACT TELEPHONES',convert(nvarchar(500), [6 CONTACT TELEPHONES])  FROM Comp_profile)  union  (SELECT TOP 1  'G' AS [No.],'CONTACT PERSON',convert(nvarchar(500), [7 CONTACT PERSON])  FROM Comp_profile)  union   (SELECT TOP 1  'H' AS [No.],'NUMBER OF BRANCHES',convert(nvarchar(500), [8 NUMBER OF BRANCHES])  FROM Comp_profile)  union  (SELECT TOP 1  'I' AS [No.],'NUMBER OF EMPLOYEES',convert(nvarchar(500), [9 NUMBER OF EMPLOYEES])  FROM Comp_profile)  union (SELECT TOP 1  'J' AS [No.],'(a) Female',convert(nvarchar(500), [9 (a) Female])  FROM Comp_profile)  union  (SELECT TOP 1  'K' AS [No.], '(b) Male',convert(nvarchar(500), [9 (b) Male])  FROM Comp_profile)  union      (SELECT TOP 1  'L' AS [No.],'NUMBER OF LOAN OFFICERS',convert(nvarchar(500), [10 NUMBER OF LOAN OFFICERS])  FROM Comp_profile)  union  (SELECT TOP 1 'M'AS [No.],'(a) Female',convert(nvarchar(500), [10 (a) Female])  FROM Comp_profile)  union 	 (SELECT TOP 1  'N' AS [No.],'( b) Male',convert(nvarchar(500), [10( b) Male])  FROM Comp_profile)  union  (SELECT TOP 1  'O' AS [No.],'EXTERNAL AUDITORS',convert(nvarchar(500), [11 EXTERNAL AUDITORS])  FROM Comp_profile)  union      (SELECT TOP 1  'P' AS [No.],'BANKERS',convert(nvarchar(500), [12 BANKERS])  FROM Comp_profile)  union  (SELECT TOP 1  'Q' AS [No.],'LAWYERS',convert(nvarchar(500), [13 LAWYERS])  FROM Comp_profile) ORDER BY [No.]"
        Dim daClss As New SqlDataAdapter
        Dim dsClss As New DataTable
        Dim cmdselectClss As SqlCommand = New SqlCommand(strClss, con)
        daClss.SelectCommand = cmdselectClss
        con.Open()
        daClss.Fill(dsClss)
        con.Close()
        Return dsClss
        ' get analysis by class details
    End Function
    Private Function Co_COVERPAGE_DSet() As DataTable
        ' get analysis by class details
        Dim strClss As String = "(SELECT TOP 1 'A' AS [No.],'NAME OF INSTITUTION' AS [COMPANY PROFILE],convert(nvarchar(500), [1 NAME OF INSTITUTION]) as 'Desc'  FROM Comp_profile) union (SELECT TOP 1  'B' AS [No.],'LICENCE NUMBER',convert(nvarchar(500), [2 LICENCE NUMBER])  FROM Comp_profile) union (SELECT TOP 1  'C' AS [No.],'DATE COMMENCED OPERATIONS',convert(nvarchar(500), [3 DATE COMMENCED OPERATIONS])  FROM Comp_profile)  union  (SELECT TOP 1  'D' AS [No.],'PHYSICAL ADDRESS',convert(nvarchar(500), [4 PHYSICAL ADDRESS])  FROM Comp_profile)  union (SELECT TOP 1  'E' AS [No.],'POSTAL ADDRESS',convert(nvarchar(500), [5 POSTAL ADDRESS])  FROM Comp_profile)  union   (SELECT TOP 1  'F' AS [No.],'CONTACT TELEPHONES',convert(nvarchar(500), [6 CONTACT TELEPHONES])  FROM Comp_profile)  union  (SELECT TOP 1  'G' AS [No.],'CONTACT PERSON',convert(nvarchar(500), [7 CONTACT PERSON])  FROM Comp_profile)  union   (SELECT TOP 1  'H' AS [No.],'NUMBER OF BRANCHES',convert(nvarchar(500), [8 NUMBER OF BRANCHES])  FROM Comp_profile)  union  (SELECT TOP 1  'I' AS [No.],'NUMBER OF EMPLOYEES',convert(nvarchar(500), [9 NUMBER OF EMPLOYEES])  FROM Comp_profile)  union (SELECT TOP 1  'J' AS [No.],'(a) Female',convert(nvarchar(500), [9 (a) Female])  FROM Comp_profile)  union  (SELECT TOP 1  'K' AS [No.], '(b) Male',convert(nvarchar(500), [9 (b) Male])  FROM Comp_profile)  union      (SELECT TOP 1  'L' AS [No.],'NUMBER OF LOAN OFFICERS',convert(nvarchar(500), [10 NUMBER OF LOAN OFFICERS])  FROM Comp_profile)  union  (SELECT TOP 1 'M'AS [No.],'(a) Female',convert(nvarchar(500), [10 (a) Female])  FROM Comp_profile)  union 	 (SELECT TOP 1  'N' AS [No.],'( b) Male',convert(nvarchar(500), [10( b) Male])  FROM Comp_profile)  union  (SELECT TOP 1  'O' AS [No.],'EXTERNAL AUDITORS',convert(nvarchar(500), [11 EXTERNAL AUDITORS])  FROM Comp_profile)  union      (SELECT TOP 1  'P' AS [No.],'BANKERS',convert(nvarchar(500), [12 BANKERS])  FROM Comp_profile)  union  (SELECT TOP 1  'Q' AS [No.],'LAWYERS',convert(nvarchar(500), [13 LAWYERS])  FROM Comp_profile) ORDER BY [No.]"
        Dim daClss As New SqlDataAdapter
        Dim dsClss As New DataTable
        Dim cmdselectClss As SqlCommand = New SqlCommand(strClss, con)
        daClss.SelectCommand = cmdselectClss
        con.Open()
        daClss.Fill(dsClss)
        con.Close()
        dsClss = Nothing
        Return dsClss
        ' get analysis by class details
    End Function
    Private Function BalSheet_DSet(dateFrom As String, dateTo As String) As DataTable
        ' get analysis by class details
        'Dim strClss As String = "SP_BalanceSheet"
        Dim strClss As String = "select 'a' AS [No.],'ASSETS' as 'BALANCE SHEET','' as 'TOTAL AMOUNT($)' union select 'a.i' AS [No.],'Fixed Assets' as 'BALANCE SHEET','' as 'TOTAL AMOUNT($)' union select 'a.ii' AS [No.],'Current Assets' as 'BALANCE SHEET','' as 'TOTAL AMOUNT($)' union select 'a.iii' AS [No.],'Total Assets' as 'BALANCE SHEET','' as 'TOTAL AMOUNT($)' UNION select 'b' AS [No.],'LIABILITIES' as 'BALANCE SHEET','' as 'TOTAL AMOUNT($)'  UNION select 'b.i' AS [No.],'Long Term Liabilities' as 'BALANCE SHEET','' as 'TOTAL AMOUNT($)'  UNION select 'b.ii' AS [No.],'Current Liabilities' as 'BALANCE SHEET','' as 'TOTAL AMOUNT($)'  UNION select 'b.iii' AS [No.],'Total Liabilities' as 'BALANCE SHEET','' as 'TOTAL AMOUNT($)'  UNION select 'c' AS [No.],'EQUITIES' as 'BALANCE SHEET','' as 'TOTAL AMOUNT($)'  UNION select 'c.i' AS [No.],'Total Equities' as 'BALANCE SHEET','' as 'TOTAL AMOUNT($)' UNION select 'd' AS [No.],'NET ASSETS' as 'BALANCE SHEET','' as 'TOTAL AMOUNT($)'  "
        'cmd = New SqlCommand("SP_BalanceSheet", con)
        Dim daClss As New SqlDataAdapter
        Dim dsClss As New DataTable
        Dim cmdselectClss As SqlCommand = New SqlCommand(strClss, con)
        'cmdselectClss.CommandType = CommandType.StoredProcedure
        'cmdselectClss.Parameters.AddWithValue("@DATEFROM", dateFrom)
        'cmdselectClss.Parameters.AddWithValue("@DATETO", dateTo)
        daClss.SelectCommand = cmdselectClss
        con.Open()
        daClss.Fill(dsClss)
        con.Close()
        Return dsClss
        ' get analysis by class details
    End Function
    Private Function InsiderLoans_DSet(dateFrom As String, dateTo As String) As DataTable
        ' get analysis by class details
        Dim strClss As String = "declare @fdate date ='" & dateFrom & "' declare @tDate date='" & dateTo & "' "
        'cmd = New SqlCommand("SP_BalanceSheet", con)
        Dim daClss As New SqlDataAdapter
        Dim dsClss As New DataTable
        Dim cmdselectClss As SqlCommand = New SqlCommand(strClss, con)
        daClss.SelectCommand = cmdselectClss
        con.Open()
        daClss.Fill(dsClss)
        con.Close()
        Return dsClss
        ' get analysis by class details
    End Function
End Class