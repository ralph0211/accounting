Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Web.Script.Services
Imports System.Data.SqlClient
Imports System.Data
Imports System.Configuration
Imports System.Collections.Generic

' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
' <System.Web.Script.Services.ScriptService()> _
<WebService(Namespace:="http://tempuri.org/")>
<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)>
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
<ScriptService>
Public Class DashboardData
    Inherits System.Web.Services.WebService

    <WebMethod()>
    Public Function HelloWorld() As String
        Return "Hello World"
    End Function

    <WebMethod>
    <ScriptMethod(UseHttpGet:=True, ResponseFormat:=ResponseFormat.Json)>
    Public Function GetWeeklyData() As String
        'Dim customers As New List(Of String)()
        Using conn As New SqlConnection()
            conn.ConnectionString = ConfigurationManager.ConnectionStrings("Constring").ConnectionString
            Using cmd As New SqlCommand()
                cmd.CommandText = "SELECT * from (select top 7 isnull(tblDisb.WeekEnding,tblRep.WeekEnding) as Ending,isnull(DisbCount,0) as DisbCount,isnull(DisbAmt,0) as DisbAmt,isnull(RepayCount,0) as RepayCount,isnull(RepayAmt,0) as RepayAmt from ((select sum(debit-Credit) as DisbAmt, count(DISTINCT Refrence) as DisbCount,WeekEnding = convert(varchar, DateAdd(day, -1 * datepart(dw, CONVERT(varchar,trxnDate,101)) + 7,    CONVERT(varchar,trxnDate,101)),106) from Accounts_Transactions where Description='Disbursement' AND Account IN (SELECT customer_number from CUSTOMER_DETAILS) GROUP BY DateAdd(day, -1 * datepart(dw, CONVERT(varchar,TrxnDate,101)) + 7, CONVERT(varchar,TrxnDate,101))) tblDisb full outer join (select sum(credit-debit) as RepayAmt, count(distinct refrence) as RepayCount,WeekEnding = convert(varchar, DateAdd(day, -1 * datepart(dw, CONVERT(varchar,trxnDate,101)) + 7,    CONVERT(varchar,trxnDate,101)),106) from Accounts_Transactions where Description like '%repayment%' and account in (select customer_number from customer_details) GROUP BY DateAdd(day, -1 * datepart(dw, CONVERT(varchar,TrxnDate,101)) + 7, CONVERT(varchar,TrxnDate,101))) tblRep on tblDisb.WeekEnding=tblRep.WeekEnding) order by cast(isnull(tblDisb.WeekEnding,tblRep.WeekEnding) as date) desc) tbl ORDER BY cast(WeekEnding as date) asc"
                cmd.Connection = conn
                'conn.Open()

                Dim adp = New SqlDataAdapter(cmd)
                Dim dt As New DataTable
                adp.Fill(dt)
                'Using sdr As SqlDataReader = cmd.ExecuteReader()
                'While sdr.Read()
                'customers.Add(String.Format("{0}--{1}", sdr("display"), sdr("CUSTOMER_NUMBER")))

                Dim serializer As New System.Web.Script.Serialization.JavaScriptSerializer()
                Dim rows As List(Of Dictionary(Of String, Object)) = New List(Of Dictionary(Of String, Object))()
                Dim row As Dictionary(Of String, Object)
                For Each dr As DataRow In dt.Rows
                    row = New Dictionary(Of String, Object)()
                    For Each col As DataColumn In dt.Columns
                        row.Add(col.ColumnName, dr(col))
                    Next col
                    rows.Add(row)
                Next dr
                Return serializer.Serialize(rows)

                'End While
                'End Using
                'conn.Close()
            End Using
            'Return customers.ToArray()
        End Using
    End Function

    '<WebMethod>
    '<ScriptMethod(UseHttpGet:=True, ResponseFormat:=ResponseFormat.Json)>
    'Public Function GetMonthlyData() As String
    '    'Dim customers As New List(Of String)()
    '    Using conn As New SqlConnection()
    '        conn.ConnectionString = ConfigurationManager.ConnectionStrings("Constring").ConnectionString
    '        Using cmd As New SqlCommand()
    '            cmd.CommandText = "SELECT * from (select top 12 isnull(tblDisb.MonthEnding,tblRep.MonthEnding) as Ending,isnull(DisbCount,0) as DisbCount,isnull(DisbAmt,0) as DisbAmt,isnull(RepayCount,0) as RepayCount,isnull(RepayAmt,0) as RepayAmt,ISNULL(tblDisb.Yearr,tblRep.Yearr) as Yearr,ISNULL(tblDisb.Monthh,tblRep.Monthh) as Monthh from ((select sum(debit-Credit) as DisbAmt, count(DISTINCT Refrence) as DisbCount,MonthEnding = convert(varchar,DATENAME(Month, TrxnDate)) +' '+ convert(varchar,DATEPART(Year, TrxnDate)),DATEPART(YEAR,TrxnDate) as Yearr,DATEPART(MONTH,TrxnDate) as Monthh from Accounts_Transactions where Description='Disbursement' AND Account IN (SELECT customer_number from CUSTOMER_DETAILS) GROUP BY DATEPART(Year, TrxnDate), DATENAME(Month, TrxnDate), DATEPART(Month, TrxnDate)) tblDisb full outer join (select sum(credit-debit) as RepayAmt, count(distinct refrence) as RepayCount,MonthEnding = convert(varchar,DATENAME(Month, TrxnDate)) +' '+ convert(varchar,DATEPART(Year, TrxnDate)),DATEPART(YEAR,TrxnDate) as Yearr,DATEPART(MONTH,TrxnDate) as Monthh from Accounts_Transactions where Description like '%repayment%' and account in (select customer_number from customer_details) GROUP BY DATEPART(Year, TrxnDate), DATENAME(Month, TrxnDate), DATEPART(Month, TrxnDate)) tblRep on tblDisb.MonthEnding=tblRep.MonthEnding) order by ISNULL(tblDisb.Yearr,tblRep.Yearr),ISNULL(tblDisb.Monthh,tblRep.Monthh) desc) tbl ORDER BY yearr,monthh asc"
    '            cmd.Connection = conn
    '            'conn.Open()

    '            Dim adp = New SqlDataAdapter(cmd)
    '            Dim dt As New DataTable
    '            adp.Fill(dt)

    '            Dim serializer As New System.Web.Script.Serialization.JavaScriptSerializer()
    '            Dim rows As List(Of Dictionary(Of String, Object)) = New List(Of Dictionary(Of String, Object))()
    '            Dim row As Dictionary(Of String, Object)
    '            For Each dr As DataRow In dt.Rows
    '                row = New Dictionary(Of String, Object)()
    '                For Each col As DataColumn In dt.Columns
    '                    row.Add(col.ColumnName, dr(col))
    '                Next col
    '                rows.Add(row)
    '            Next dr
    '            Return serializer.Serialize(rows)

    '            'End While
    '            'End Using
    '            'conn.Close()
    '        End Using
    '        'Return customers.ToArray()
    '    End Using
    'End Function

    <WebMethod>
    <ScriptMethod(UseHttpGet:=False, ResponseFormat:=ResponseFormat.Json)>
    Public Function GetWeeklyData(userId As String, brnc As String, dashView As String) As String
        'Dim customers As New List(Of String)()
        'ErrorLogging.WriteLogFile("weekly data", userId, role)
        Using conn As New SqlConnection()
            conn.ConnectionString = ConfigurationManager.ConnectionStrings("Constring").ConnectionString
            Using cmd As New SqlCommand()
                If dashView = "Individual" Then
                    cmd.CommandText = "SELECT * from (select top 12 isnull(tblDisb.MonthEnding,tblRep.MonthEnding) as MonthEnding,isnull(DisbCount,0) as DisbCount,isnull(DisbAmt,0) as DisbAmt,isnull(RepayCount,0) as RepayCount,isnull(RepayAmt,0) as RepayAmt,ISNULL(tblDisb.Yearr,tblRep.Yearr) as Yearr,ISNULL(tblDisb.Monthh,tblRep.Monthh) as Monthh from ((select sum(debit-Credit) as DisbAmt, count(DISTINCT Refrence) as DisbCount,MonthEnding = convert(varchar,DATENAME(Month, TrxnDate)) +' '+ convert(varchar,DATEPART(Year, TrxnDate)),DATEPART(YEAR,TrxnDate) as Yearr,DATEPART(MONTH,TrxnDate) as Monthh from Accounts_Transactions where Description='Disbursement' AND Refrence IN (SELECT convert(varchar,id) from QUEST_APPLICATION where CREATED_BY=@lo) AND Account IN (SELECT customer_number from CUSTOMER_DETAILS) GROUP BY DATEPART(Year, TrxnDate), DATENAME(Month, TrxnDate), DATEPART(Month, TrxnDate)) tblDisb full outer join (select sum(credit-debit) as RepayAmt, count(distinct refrence) as RepayCount,MonthEnding = convert(varchar,DATENAME(Month, TrxnDate)) +' '+ convert(varchar,DATEPART(Year, TrxnDate)),DATEPART(YEAR,TrxnDate) as Yearr,DATEPART(MONTH,TrxnDate) as Monthh from Accounts_Transactions where Description like '%repayment%' AND Account IN (SELECT customer_number from quest_application where CREATED_BY=@lo) GROUP BY DATEPART(Year, TrxnDate), DATENAME(Month, TrxnDate), DATEPART(Month, TrxnDate)) tblRep on tblDisb.MonthEnding=tblRep.MonthEnding) order by ISNULL(tblDisb.Yearr,tblRep.Yearr),ISNULL(tblDisb.Monthh,tblRep.Monthh) desc) tbl ORDER BY yearr,monthh asc"
                    cmd.Parameters.AddWithValue("@lo", userId)
                ElseIf dashView = "Branch" Then
                    cmd.CommandText = "SELECT * from (select top 12 isnull(tblDisb.MonthEnding,tblRep.MonthEnding) as MonthEnding,isnull(DisbCount,0) as DisbCount,isnull(DisbAmt,0) as DisbAmt,isnull(RepayCount,0) as RepayCount,isnull(RepayAmt,0) as RepayAmt,ISNULL(tblDisb.Yearr,tblRep.Yearr) as Yearr,ISNULL(tblDisb.Monthh,tblRep.Monthh) as Monthh from ((select sum(debit-Credit) as DisbAmt, count(DISTINCT Refrence) as DisbCount,MonthEnding = convert(varchar,DATENAME(Month, TrxnDate)) +' '+ convert(varchar,DATEPART(Year, TrxnDate)),DATEPART(YEAR,TrxnDate) as Yearr,DATEPART(MONTH,TrxnDate) as Monthh from Accounts_Transactions where Description='Disbursement' AND Refrence IN (SELECT convert(varchar,id) from QUEST_APPLICATION where BRANCH_CODE=@brn) AND Account IN (SELECT customer_number from CUSTOMER_DETAILS) GROUP BY DATEPART(Year, TrxnDate), DATENAME(Month, TrxnDate), DATEPART(Month, TrxnDate)) tblDisb full outer join (select sum(credit-debit) as RepayAmt, count(distinct refrence) as RepayCount,MonthEnding = convert(varchar,DATENAME(Month, TrxnDate)) +' '+ convert(varchar,DATEPART(Year, TrxnDate)),DATEPART(YEAR,TrxnDate) as Yearr,DATEPART(MONTH,TrxnDate) as Monthh from Accounts_Transactions where Description like '%repayment%' AND Account IN (SELECT customer_number from quest_application where BRANCH_CODE=@brn) GROUP BY DATEPART(Year, TrxnDate), DATENAME(Month, TrxnDate), DATEPART(Month, TrxnDate)) tblRep on tblDisb.MonthEnding=tblRep.MonthEnding) order by ISNULL(tblDisb.Yearr,tblRep.Yearr),ISNULL(tblDisb.Monthh,tblRep.Monthh) desc) tbl ORDER BY yearr,monthh asc"
                    cmd.Parameters.AddWithValue("@brn", brnc)
                Else
                    cmd.CommandText = "SELECT * from (select top 12 isnull(tblDisb.MonthEnding,tblRep.MonthEnding) as MonthEnding,isnull(DisbCount,0) as DisbCount,isnull(DisbAmt,0) as DisbAmt,isnull(RepayCount,0) as RepayCount,isnull(RepayAmt,0) as RepayAmt,ISNULL(tblDisb.Yearr,tblRep.Yearr) as Yearr,ISNULL(tblDisb.Monthh,tblRep.Monthh) as Monthh from ((select sum(debit-Credit) as DisbAmt, count(DISTINCT Refrence) as DisbCount,MonthEnding = convert(varchar,DATENAME(Month, TrxnDate)) +' '+ convert(varchar,DATEPART(Year, TrxnDate)),DATEPART(YEAR,TrxnDate) as Yearr,DATEPART(MONTH,TrxnDate) as Monthh from Accounts_Transactions where Description='Disbursement' AND Account IN (SELECT customer_number from CUSTOMER_DETAILS) GROUP BY DATEPART(Year, TrxnDate), DATENAME(Month, TrxnDate), DATEPART(Month, TrxnDate)) tblDisb full outer join (select sum(credit-debit) as RepayAmt, count(distinct refrence) as RepayCount,MonthEnding = convert(varchar,DATENAME(Month, TrxnDate)) +' '+ convert(varchar,DATEPART(Year, TrxnDate)),DATEPART(YEAR,TrxnDate) as Yearr,DATEPART(MONTH,TrxnDate) as Monthh from Accounts_Transactions where Description like '%repayment%' and account in (select customer_number from customer_details) GROUP BY DATEPART(Year, TrxnDate), DATENAME(Month, TrxnDate), DATEPART(Month, TrxnDate)) tblRep on tblDisb.MonthEnding=tblRep.MonthEnding) order by ISNULL(tblDisb.Yearr,tblRep.Yearr),ISNULL(tblDisb.Monthh,tblRep.Monthh) desc) tbl ORDER BY yearr,monthh asc"
                End If
                cmd.Connection = conn
                'conn.Open()

                Dim adp = New SqlDataAdapter(cmd)
                Dim dt As New DataTable
                adp.Fill(dt)

                Dim serializer As New System.Web.Script.Serialization.JavaScriptSerializer()
                Dim rows As List(Of Dictionary(Of String, Object)) = New List(Of Dictionary(Of String, Object))()
                Dim row As Dictionary(Of String, Object)
                For Each dr As DataRow In dt.Rows
                    row = New Dictionary(Of String, Object)()
                    For Each col As DataColumn In dt.Columns
                        row.Add(col.ColumnName, dr(col))
                    Next col
                    rows.Add(row)
                Next dr
                Return serializer.Serialize(rows)

            End Using
            'Return customers.ToArray()
        End Using
    End Function

    '<WebMethod>
    '<ScriptMethod(UseHttpGet:=True, ResponseFormat:=ResponseFormat.Json)>
    'Public Function GetSectorAnalysis() As String
    '    Dim ds As New DataSet
    '    Dim dt As New dsAllReports.SectorAnalysisDataTable
    '    Dim dss As New dsAllReportsTableAdapters.SectorAnalysisTableAdapter
    '    dss.Fill(dt)

    '    Dim serializer As New System.Web.Script.Serialization.JavaScriptSerializer()
    '    Dim rows As List(Of Dictionary(Of String, Object)) = New List(Of Dictionary(Of String, Object))()
    '    Dim row As Dictionary(Of String, Object)
    '    For Each dr As DataRow In dt.Rows
    '        row = New Dictionary(Of String, Object)()
    '        For Each col As DataColumn In dt.Columns
    '            row.Add(col.ColumnName, dr(col))
    '        Next col
    '        rows.Add(row)
    '    Next dr
    '    Return serializer.Serialize(rows)
    'End Function

    <WebMethod>
    <ScriptMethod(UseHttpGet:=True, ResponseFormat:=ResponseFormat.Json)>
    Public Function GetLoanOfficerAnalysis() As String
        Dim ds As New DataSet
        Dim dt As New dsAnalystReports.LoanOfficerSummaryDataTable
        Dim dss As New dsAnalystReportsTableAdapters.LoanOfficerSummaryTableAdapter
        dss.Fill(dt)

        Dim serializer As New System.Web.Script.Serialization.JavaScriptSerializer()
        Dim rows As List(Of Dictionary(Of String, Object)) = New List(Of Dictionary(Of String, Object))()
        Dim row As Dictionary(Of String, Object)
        For Each dr As DataRow In dt.Rows
            row = New Dictionary(Of String, Object)()
            For Each col As DataColumn In dt.Columns
                row.Add(col.ColumnName, dr(col))
            Next col
            rows.Add(row)
        Next dr
        Return serializer.Serialize(rows)
    End Function

    <WebMethod>
    <ScriptMethod(UseHttpGet:=True, ResponseFormat:=ResponseFormat.Json)>
    Public Function GetBranchAnalysis() As String
        Dim ds As New DataSet
        Dim dt As New dsAnalystReports.BranchSummaryDataTable
        Dim dss As New dsAnalystReportsTableAdapters.BranchSummaryTableAdapter
        dss.Fill(dt)

        Dim serializer As New System.Web.Script.Serialization.JavaScriptSerializer()
        Dim rows As List(Of Dictionary(Of String, Object)) = New List(Of Dictionary(Of String, Object))()
        Dim row As Dictionary(Of String, Object)
        For Each dr As DataRow In dt.Rows
            row = New Dictionary(Of String, Object)()
            For Each col As DataColumn In dt.Columns
                row.Add(col.ColumnName, dr(col))
            Next col
            rows.Add(row)
        Next dr
        Return serializer.Serialize(rows)
    End Function

    <WebMethod>
    <ScriptMethod(UseHttpGet:=True, ResponseFormat:=ResponseFormat.Json)>
    Public Function GetProductAnalysis() As String
        Dim ds As New DataSet
        Dim dt As New dsAnalystReports.ProductSummaryDataTable
        Dim dss As New dsAnalystReportsTableAdapters.ProductSummaryTableAdapter
        dss.Fill(dt)

        Dim serializer As New System.Web.Script.Serialization.JavaScriptSerializer()
        Dim rows As List(Of Dictionary(Of String, Object)) = New List(Of Dictionary(Of String, Object))()
        Dim row As Dictionary(Of String, Object)
        For Each dr As DataRow In dt.Rows
            row = New Dictionary(Of String, Object)()
            For Each col As DataColumn In dt.Columns
                row.Add(col.ColumnName, dr(col))
            Next col
            rows.Add(row)
        Next dr
        Return serializer.Serialize(rows)
    End Function

    <WebMethod>
    <ScriptMethod(UseHttpGet:=True, ResponseFormat:=ResponseFormat.Json)>
    Public Function GetLoanPurposeAnalysis() As String
        Dim ds As New DataSet
        Dim dt As New dsAnalystReports.LoanPurposeSummaryDataTable
        Dim dss As New dsAnalystReportsTableAdapters.LoanPurposeSummaryTableAdapter
        dss.Fill(dt)

        Dim serializer As New System.Web.Script.Serialization.JavaScriptSerializer()
        Dim rows As List(Of Dictionary(Of String, Object)) = New List(Of Dictionary(Of String, Object))()
        Dim row As Dictionary(Of String, Object)
        For Each dr As DataRow In dt.Rows
            row = New Dictionary(Of String, Object)()
            For Each col As DataColumn In dt.Columns
                row.Add(col.ColumnName, dr(col))
            Next col
            rows.Add(row)
        Next dr
        Return serializer.Serialize(rows)
    End Function
End Class