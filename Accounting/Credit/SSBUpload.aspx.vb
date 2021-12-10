Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System.Text
Imports Microsoft.VisualBasic.FileIO
Imports CreditManager

Partial Class Credit_SSBUpload
    Inherits System.Web.UI.Page
    Dim cmd As SqlCommand
    Dim con As New SqlConnection
    Dim connection As String

    Public Sub createTabbedFile(ByVal csvFileFullPath As String, ByVal tabFileFullPath As String)
        Using tabStreamWriter As New StreamWriter(tabFileFullPath)
            Using csvFileReader As New TextFieldParser(csvFileFullPath)
                csvFileReader.TextFieldType = FieldType.Delimited
                csvFileReader.Delimiters = New String() {","}
                csvFileReader.HasFieldsEnclosedInQuotes = True
                csvFileReader.TrimWhiteSpace = True
                Dim currentRow As String()
                While Not (csvFileReader.EndOfData)
                    Try
                        Dim i As Int32 = 1
                        Dim outputRow As New Text.StringBuilder()
                        currentRow = csvFileReader.ReadFields()
                        For Each currentField As String In currentRow
                            'currentField = currentField.Replace(Chr(34), Chr(39)) 'replace double quote with single quote if needed
                            outputRow.Append(currentField)
                            If i < currentRow.Length Then
                                outputRow.Append(Chr(9)) 'add a tab for each field except last one
                            End If
                            i = i + 1
                        Next
                        tabStreamWriter.WriteLine(outputRow.ToString())
                    Catch ex As Microsoft.VisualBasic.FileIO.MalformedLineException
                        'Dts.TaskResult = Dts.Results.Failure
                    End Try
                End While
            End Using
        End Using
        'Dts.TaskResult = Dts.Results.Success
    End Sub

    Public Sub insertData(ext As String)
        'Try
        Dim fd As New DataSet
        If ext = ".csv" Then
            fd = GetDataCSV()
        Else
            fd = GetData()
        End If
        Dim rowcount = fd.Tables(0).Rows.Count
        Dim colcount = fd.Tables(0).Columns.Count
        'msgbox(colcount)
        For i = 0 To rowcount - 1
            'msgbox(fd.Tables(0).Rows(i).Item(6).ToString)
            Dim reference = BankString.removeSpecialCharacter(removeNULL(fd, i, 0))
            Dim names = BankString.removeSpecialCharacter(removeNULL(fd, i, 1))
            Dim amount = BankString.removeSpecialCharacter(removeNULL(fd, i, 3))
            Dim ECNo = BankString.removeSpecialCharacter(removeNULL(fd, i, 4))
            'msgbox(reference & ";" & names & ";" & amount & ";" & ECNo)
            Try
                If IsNumeric(amount) And amount <> 0 And names <> "" And names <> "0" Then
                    cmd = New SqlCommand()
                    cmd.Connection = con
                    cmd.CommandText = "insert into SSB_UPLOAD([REFERENCE],[NAMES],[AMOUNT],[ECNO],[FILE_DATE]) values ('" & reference & "','" & names & "','" & amount & "','" & ECNo & "','" & txtRepayDate.Text & "')"

                    If con.State = ConnectionState.Open Then
                        con.Close()
                    End If
                    con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()

                End If
            Catch ex As Exception
                Continue For
            End Try
        Next
        'this is where the balance calculation should come
        'updatePayments()
        notify("Import successful", "success")
        consolidateDuePayments(txtRepayDate.Text)
        'Catch ex As Exception
        '    msgbox(ex.Message)
        'End Try
    End Sub

    Public Sub msgbox(ByVal strMessage As String)

        'finishes server processing, returns to client.
        Dim strScript As String = "<script language=JavaScript>"
        strScript += String.Format("window.alert(""{0}"");", strMessage)
        strScript += "</script>"
        Dim lbl As New System.Web.UI.WebControls.Label() With {.Text = strScript}
        Page.Controls.Add(lbl)
    End Sub

    Function removeNULL(ByVal myreader As DataSet, ByVal j As Integer, ByVal stval As Integer) As String

        Dim val As Object = myreader.Tables(0).Rows(j).Item(stval)
        If val IsNot DBNull.Value And val <> "" Then
            Return val.ToString()
        Else
            Return Convert.ToString(0)
        End If
    End Function

    Protected Sub btnUpload_Click(sender As Object, e As EventArgs) Handles btnUpload.Click
        'Try
        If filSSBUpload.HasFile Then
            deleteExisting(txtRepayDate.Text)
            Dim ext = Path.GetExtension(filSSBUpload.FileName)
            insertData(ext)
        Else
            notify("Select the file to upload", "error")
        End If
        'consolidateDuePayments(txtRepayDate.Text)
        'Catch ex As Exception
        '    msgbox(ex.Message)
        'End Try
    End Sub

    ''function to update CUST_DUE_AMT balance
    Protected Sub compareBalance(fileDate As String)
        cmd = New SqlCommand("select * from SSB_UPLOAD where FILE_DATE='" & fileDate & "'", con)
        Dim ds As New DataSet
        Dim adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "SU")
        If ds.Tables(0).Rows.Count > 0 Then
            For Each ssb As DataRow In ds.Tables(0).Rows
                Dim ssbCmd As New SqlCommand("update CUST_DUE_AMT set [PAYMENT]='" & ssb.Item("AMOUNT") & "',NEW_BALANCE=BALANCE-" & ssb.Item("AMOUNT") & " where [ECNO]='" & ssb.Item("ECNO") & "' and PAYMENT_DATE='" & fileDate & "'", con)
                If con.State = ConnectionState.Open Then
                    con.Close()
                End If
                Dim updateSuccess = 0
                con.Open()
                updateSuccess = ssbCmd.ExecuteNonQuery()
                con.Close()
                'If updateSuccess = 0 Then
                'no record updated
                Dim indivCustNo As String = ""
                indivCustNo = getCustNo(ssb.Item("ECNO"))
                If Trim(indivCustNo) = "" Or IsDBNull(indivCustNo) Then
                    cmd = New SqlCommand("SaveAccountsTrxnsTempWithContra", con)
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.AddWithValue("@Type", "SSB Upload")
                    cmd.Parameters.AddWithValue("@Category", "Loan Repayment")
                    cmd.Parameters.AddWithValue("@Ref", "000000")
                    'cmd.Parameters.AddWithValue("@Ref", ssb.Item("ID"))
                    cmd.Parameters.AddWithValue("@Desc", "Repayment - " & ssb.Item("NAMES") & " - " & ssb.Item("ECNO"))
                    cmd.Parameters.AddWithValue("@Debit", 0.0)
                    cmd.Parameters.AddWithValue("@Credit", ssb.Item("AMOUNT"))
                    cmd.Parameters.AddWithValue("@Account", "221/27")
                    cmd.Parameters.AddWithValue("@ContraAccount", "211/1")
                    cmd.Parameters.AddWithValue("@Status", 1)
                    cmd.Parameters.AddWithValue("@Other", indivCustNo)
                    cmd.Parameters.AddWithValue("@BankAccID", "")
                    cmd.Parameters.AddWithValue("@BankAccName", "")
                    cmd.Parameters.AddWithValue("@BatchRef", "")
                    cmd.Parameters.AddWithValue("@TrxnDate", txtRepayDate.Text)

                    Dim cmd1 = New SqlCommand("SaveAccountsTrxns", con)
                    cmd1.CommandType = CommandType.StoredProcedure
                    cmd1.Parameters.AddWithValue("@Type", "SSB Upload")
                    cmd1.Parameters.AddWithValue("@Category", "Repayment")
                    cmd1.Parameters.AddWithValue("@Ref", "000000")
                    'cmd1.Parameters.AddWithValue("@Ref", ssb.Item("ID"))
                    cmd1.Parameters.AddWithValue("@Desc", "Repayment - " & ssb.Item("NAMES") & " - " & ssb.Item("ECNO"))
                    cmd1.Parameters.AddWithValue("@Debit", ssb.Item("AMOUNT"))
                    cmd1.Parameters.AddWithValue("@Credit", 0.0)
                    cmd1.Parameters.AddWithValue("@Account", "211/1")
                    cmd1.Parameters.AddWithValue("@ContraAccount", "221/27")
                    cmd1.Parameters.AddWithValue("@Status", 1)
                    cmd1.Parameters.AddWithValue("@Other", indivCustNo)
                    cmd1.Parameters.AddWithValue("@BankAccID", "")
                    cmd1.Parameters.AddWithValue("@BankAccName", "")
                    'cm1d.Parameters.AddWithValue("@BatchRef", cmbBatchNo.SelectedItem.Text)
                    cmd1.Parameters.AddWithValue("@BatchRef", "")
                    cmd1.Parameters.AddWithValue("@TrxnDate", txtRepayDate.Text)

                    If con.State = ConnectionState.Open Then
                        con.Close()
                    End If
                    con.Open()
                    cmd.ExecuteNonQuery()
                    cmd1.ExecuteNonQuery()
                    con.Close()
                Else
                    'check if customer has loan

                    Dim dsAcc = getLoanId(ssb.Item("ECNO"))
                    If Not IsNothing(dsAcc) Then
                        Dim indivLoanId As String = dsAcc.Rows(0).Item("ID")
                        indivCustNo = dsAcc.Rows(0).Item("CUSTOMER_NUMBER")

                        cmd = New SqlCommand("SaveAccountsTrxns", con)
                        cmd.CommandType = CommandType.StoredProcedure
                        cmd.Parameters.AddWithValue("@Type", "SSB Upload")
                        cmd.Parameters.AddWithValue("@Category", "Repayment")
                        cmd.Parameters.AddWithValue("@Ref", indivLoanId)
                        'cmd.Parameters.AddWithValue("@Ref", ssb.Item("ID"))
                        cmd.Parameters.AddWithValue("@Desc", "Repayment")
                        cmd.Parameters.AddWithValue("@Debit", 0.0)
                        cmd.Parameters.AddWithValue("@Credit", ssb.Item("AMOUNT"))
                        cmd.Parameters.AddWithValue("@Account", "213/1") 'Loan Debtor
                        cmd.Parameters.AddWithValue("@ContraAccount", "211/1") 'Cash
                        cmd.Parameters.AddWithValue("@Status", 1)
                        'cmd.Parameters.AddWithValue("@Other", [Loan Debtor Account Number])
                        cmd.Parameters.AddWithValue("@Other", indivCustNo)
                        cmd.Parameters.AddWithValue("@BankAccID", "")
                        cmd.Parameters.AddWithValue("@BankAccName", "")
                        'cmd.Parameters.AddWithValue("@BatchRef", cmbBatchNo.SelectedItem.Text)
                        cmd.Parameters.AddWithValue("@BatchRef", "")
                        cmd.Parameters.AddWithValue("@TrxnDate", txtRepayDate.Text)

                        Dim cmd1 = New SqlCommand("SaveAccountsTrxns", con)
                        cmd1.CommandType = CommandType.StoredProcedure
                        cmd1.Parameters.AddWithValue("@Type", "SSB Upload")
                        cmd1.Parameters.AddWithValue("@Category", "Repayment")
                        cmd1.Parameters.AddWithValue("@Ref", indivLoanId)
                        'cmd1.Parameters.AddWithValue("@Ref", ssb.Item("ID"))
                        cmd1.Parameters.AddWithValue("@Desc", "Repayment")
                        cmd1.Parameters.AddWithValue("@Debit", ssb.Item("AMOUNT"))
                        cmd1.Parameters.AddWithValue("@Credit", 0.0)
                        cmd1.Parameters.AddWithValue("@Account", "211/1")
                        cmd1.Parameters.AddWithValue("@ContraAccount", "213/1")
                        cmd1.Parameters.AddWithValue("@Status", 1)
                        'cm1d.Parameters.AddWithValue("@Other", [Loan Debtor Account Number])
                        cmd1.Parameters.AddWithValue("@Other", indivCustNo)
                        cmd1.Parameters.AddWithValue("@BankAccID", "")
                        cmd1.Parameters.AddWithValue("@BankAccName", "")
                        'cm1d.Parameters.AddWithValue("@BatchRef", cmbBatchNo.SelectedItem.Text)
                        cmd1.Parameters.AddWithValue("@BatchRef", "")
                        cmd1.Parameters.AddWithValue("@TrxnDate", txtRepayDate.Text)

                        If con.State = ConnectionState.Open Then
                            con.Close()
                        End If
                        con.Open()
                        cmd.ExecuteNonQuery()
                        cmd1.ExecuteNonQuery()
                        con.Close()
                    Else
                        Try
                            cmd = New SqlCommand("SaveAccountsTrxns", con)
                            cmd.CommandType = CommandType.StoredProcedure
                            cmd.Parameters.AddWithValue("@Type", "SSB Upload")
                            cmd.Parameters.AddWithValue("@Category", "Repayment")
                            cmd.Parameters.AddWithValue("@Ref", "000000")
                            'cmd.Parameters.AddWithValue("@Ref", ssb.Item("ID"))
                            cmd.Parameters.AddWithValue("@Desc", "Repayment - " & ssb.Item("NAMES") & " - " & ssb.Item("ECNO"))
                            cmd.Parameters.AddWithValue("@Debit", 0.0)
                            cmd.Parameters.AddWithValue("@Credit", ssb.Item("AMOUNT"))
                            cmd.Parameters.AddWithValue("@Account", "213/1") 'Loan Debtor
                            cmd.Parameters.AddWithValue("@ContraAccount", "211/1") 'Cash
                            cmd.Parameters.AddWithValue("@Status", 1)
                            'cmd.Parameters.AddWithValue("@Other", [Loan Debtor Account Number])
                            cmd.Parameters.AddWithValue("@Other", indivCustNo)
                            cmd.Parameters.AddWithValue("@BankAccID", "")
                            cmd.Parameters.AddWithValue("@BankAccName", "")
                            'cmd.Parameters.AddWithValue("@BatchRef", cmbBatchNo.SelectedItem.Text)
                            cmd.Parameters.AddWithValue("@BatchRef", "")
                            cmd.Parameters.AddWithValue("@TrxnDate", txtRepayDate.Text)

                            Dim cmd1 = New SqlCommand("SaveAccountsTrxns", con)
                            cmd1.CommandType = CommandType.StoredProcedure
                            cmd1.Parameters.AddWithValue("@Type", "SSB Upload")
                            cmd1.Parameters.AddWithValue("@Category", "Repayment")
                            cmd1.Parameters.AddWithValue("@Ref", "000000")
                            ''cmd1.Parameters.AddWithValue("@Ref", ssb.Item("ID"))
                            cmd1.Parameters.AddWithValue("@Desc", "Repayment - " & ssb.Item("NAMES") & " - " & ssb.Item("ECNO"))
                            cmd1.Parameters.AddWithValue("@Debit", ssb.Item("AMOUNT"))
                            cmd1.Parameters.AddWithValue("@Credit", 0.0)
                            cmd1.Parameters.AddWithValue("@Account", "211/1")
                            cmd1.Parameters.AddWithValue("@ContraAccount", "213/1")
                            cmd1.Parameters.AddWithValue("@Status", 1)
                            'cm1d.Parameters.AddWithValue("@Other", [Loan Debtor Account Number])
                            cmd1.Parameters.AddWithValue("@Other", indivCustNo)
                            cmd1.Parameters.AddWithValue("@BankAccID", "")
                            cmd1.Parameters.AddWithValue("@BankAccName", "")
                            'cm1d.Parameters.AddWithValue("@BatchRef", cmbBatchNo.SelectedItem.Text)
                            cmd1.Parameters.AddWithValue("@BatchRef", "")
                            cmd1.Parameters.AddWithValue("@TrxnDate", txtRepayDate.Text)

                            If con.State = ConnectionState.Open Then
                                con.Close()
                            End If
                            con.Open()
                            cmd.ExecuteNonQuery()
                            cmd1.ExecuteNonQuery()
                            con.Close()

                        Catch ex As Exception
                            msgbox(ex.Message)
                        End Try

                    End If

                End If
                'End If
            Next
        End If
    End Sub

    Protected Sub consolidateDuePayments(cutOffDate As String)
        'for each customer find all loans and add up all due amounts as at cutOffDate
        cmd = New SqlCommand("select sum(PAYMENT) as sumPaymt,sum(isnull(amount_paid,0)) paid,sum(payment)-sum(isnull(amount_paid,0)) balance,cust_no,ecno from LOAN_REPAYMENT_SCHEDULE where PAYMENT_DATE<='" & cutOffDate & "' /*and (FULLY_PAID=0 or FULLY_PAID is null) */group by cust_no,ecno order by cust_no", con)
        Dim ds As New DataSet
        Dim adp As New SqlDataAdapter(cmd)
        adp.Fill(ds, "LRS")
        If ds.Tables(0).Rows.Count > 0 Then
            For Each acc As DataRow In ds.Tables(0).Rows
                Dim accCmd As New SqlCommand("insert into CUST_DUE_AMT([CUST_NO],[ECNO],[PAYMENT_DATE],[AMT_DUE],[AMT_PAID],[BALANCE]) values ('" & acc.Item("cust_no") & "','" & acc.Item("ecno") & "','" & cutOffDate & "','" & acc.Item("sumPaymt") & "','" & acc.Item("paid") & "','" & acc.Item("balance") & "')", con)
                If con.State = ConnectionState.Open Then
                    con.Close()
                End If
                con.Open()
                accCmd.ExecuteNonQuery()
                con.Close()
            Next
            'call compareBalance()
            compareBalance(cutOffDate)
        End If
    End Sub

    Protected Sub deleteExisting(fDate As String)
        cmd = New SqlCommand("delete from SSB_UPLOAD where FILE_DATE='" & fDate & "'", con)
        Dim cmdCDA = New SqlCommand("delete from CUST_DUE_AMT where PAYMENT_DATE='" & fDate & "'", con)
        If con.State = ConnectionState.Open Then
            con.Close()
        End If
        con.Open()
        cmd.ExecuteNonQuery()
        cmdCDA.ExecuteNonQuery()
        con.Close()
    End Sub

    Protected Function getBalBFwd(loanID As String) As Double
        cmd = New SqlCommand("select ID,ISNULL(BAL_CFWD,0) as BAL from QUEST_TRANSACTIONS where LOANID='" & loanID & "' order by ID desc", con)
        Dim ds As New DataSet
        Dim adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "QT")
        If ds.Tables(0).Rows.Count > 0 Then
            Return ds.Tables(0).Rows(0).Item("BAL")
        Else
            Return 0
        End If
    End Function

    Protected Function getCustNo(ECNo As String) As String
        cmd = New SqlCommand("select CUSTOMER_NUMBER from [CUSTOMER_DETAILS] where ECNO + CD = replace('" & ECNo & "','0 ','')", con)
        Dim ds As New DataSet
        Dim adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "QA")
        If ds.Tables(0).Rows.Count > 0 Then
            Return ds.Tables(0).Rows(0).Item("CUSTOMER_NUMBER")
        Else
            Return ""
        End If
    End Function

    Protected Function getInstalment(LoanID As String) As Int16
        cmd = New SqlCommand("select MIN(PAYMENT_NO) from LOAN_REPAYMENT_SCHEDULE where LOANID='" & LoanID & "' and (FULLY_PAID=0 or FULLY_PAID IS NULL)", con)
        If con.State = ConnectionState.Open Then
            con.Close()
        End If
        Dim payNo As Int16 = 0
        con.Open()
        payNo = cmd.ExecuteScalar
        con.Close()
        Return payNo
    End Function

    Protected Function getLoanId(ECNo As String) As DataTable
        'cmd = New SqlCommand("select ID,CUSTOMER_NUMBER from QUEST_APPLICATION where ECNO + CD = replace('" & ECNo & "','0 ','') and REPAID=1", con)
        cmd = New SqlCommand("select ID,CUSTOMER_NUMBER from QUEST_APPLICATION where ECNO + CD = replace('" & ECNo & "','0 ','') and (REPAID=0 or REPAID IS NULL)", con)
        Dim ds As New DataSet
        Dim adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "QA")
        If ds.Tables(0).Rows.Count > 0 Then
            Return ds.Tables(0)
        Else
            Return Nothing
        End If
    End Function

    Protected Function isFullyPaid(loanID As String, payNo As Int16) As Boolean
        cmd = New SqlCommand("select AMOUNT_PAID,PAYMENT from LOAN_REPAYMENT_SCHEDULE where LOANID='" & loanID & "' and PAYMENT_NO='" & payNo & "'", con)
        Dim ds As New DataSet
        Dim adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "LRS")
        Try
            If IsDBNull(ds.Tables(0).Rows(0).Item("AMOUNT_PAID")) Or ds.Tables(0).Rows(0).Item("AMOUNT_PAID") <= 0 Then
                Return False
            Else
                If ds.Tables(0).Rows(0).Item("AMOUNT_PAID") >= ds.Tables(0).Rows(0).Item("PAYMENT") <= 0 Then
                    Return True
                Else
                    Return False
                End If
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function

    Protected Function isPartiallyPaid(loanID As String, payNo As Int16) As Boolean
        cmd = New SqlCommand("select AMOUNT_PAID from LOAN_REPAYMENT_SCHEDULE where LOANID='" & loanID & "' and PAYMENT_NO='" & payNo & "'", con)
        Dim ds As New DataSet
        Dim adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "LRS")
        Try
            If IsDBNull(ds.Tables(0).Rows(0).Item("AMOUNT_PAID")) Or ds.Tables(0).Rows(0).Item("AMOUNT_PAID") <= 0 Then
                isPartiallyPaid = False
            Else
                isPartiallyPaid = True
            End If
        Catch ex As Exception
            isPartiallyPaid = False
        End Try
    End Function

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            Page.MaintainScrollPositionOnPostBack = True
            con = New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
            If Not IsPostBack Then
            End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub updateFullyPaid(loanID As String, payNo As Int16)
        cmd = New SqlCommand("update LOAN_REPAYMENT_SCHEDULE set FULLY_PAID=1 where LOANID='" & loanID & "' and PAYMENT_NO='" & payNo & "'", con)
        If con.State = ConnectionState.Open Then
            con.Close()
        End If
        con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
        cmd = New SqlCommand("update AMORTIZATION_SCHEDULE set PAID=1,PAY_DATE=GETDATE(),PAY_CAPTURE_BY='" & Session("UserID") & "',PAY_CAPTURE_DATE=GETDATE() where LOANID='" & loanID & "' and PAYMENT_NO='" & payNo & "'", con)
        If con.State = ConnectionState.Open Then
            con.Close()
        End If
        con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Protected Sub updateLoanRepaid(loanID As String)
        cmd = New SqlCommand("select distinct ISNULL(FULLY_PAID,0) from LOAN_REPAYMENT_SCHEDULE where LOANID='" & loanID & "'", con)
        Dim ds As New DataSet
        Dim adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "LRS")
        If ds.Tables(0).Rows.Count = 1 Then
            If ds.Tables(0).Rows(0).Item(0).ToString = "1" Then
                cmd = New SqlCommand("update QUEST_APPLICATION set STATUS='REPAID' where ID='" & loanID & "'", con)
                If con.State = ConnectionState.Open Then
                    con.Close()
                End If
                con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            End If
        End If
    End Sub

    Protected Sub updatePayments()
        'GET ECNOs FROM NEW UPLOAD FILE AND LOOP THROUGH EACH UPDATING PAYMENTS
        Dim cmdEC = New SqlCommand("select ECNO,AMOUNT from SSB_UPLOAD where FILE_DATE='" & txtRepayDate.Text & "' and (UPDATED is NULL or UPDATED=0)", con)
        Dim dsEC As New DataSet
        Dim adpEC As New SqlDataAdapter
        adpEC = New SqlDataAdapter(cmdEC)
        adpEC.Fill(dsEC, "SSB")
        If dsEC.Tables(0).Rows.Count > 0 Then
            For Each row As DataRow In dsEC.Tables(0).Rows
                Dim LIDs As DataTable
                LIDs = getLoanId(row("ECNO"))
                Dim amt = row("AMOUNT")
                'For Each lID As DataRow In LIDs.Rows

                'Next
                'Dim loanID = getLoanId(row("ECNO"))
                Dim loanID = LIDs.Rows(0).Item("ID")
                Dim custNo = LIDs.Rows(0).Item("CUSTOMER_NUMBER")
                Dim payNo = getInstalment(loanID)
                Dim datePaid = txtRepayDate.Text
                If isPartiallyPaid(loanID, payNo) Then
                    'cmd = New SqlCommand("update LOAN_REPAYMENT_SCHEDULE set DATE_PAID=GETDATE(),AMOUNT_PAID=isnull(AMOUNT_PAID,0) + " & txtRepayAmt.Text & ",INST_PRINCIPAL_BALANCE=INST_PRINCIPAL_BALANCE + " & txtRepayAmt.Text & " where LOANID='" & loanID & "' and PAYMENT_NO='" & payNo & "'", con)
                    cmd = New SqlCommand("update LOAN_REPAYMENT_SCHEDULE set DATE_PAID='" & datePaid & "',AMOUNT_PAID=isnull(AMOUNT_PAID,0) + " & amt & ",INST_PRINCIPAL_BALANCE=INST_PRINCIPAL_BALANCE + " & amt & " where LOANID='" & loanID & "' and PAYMENT_NO='" & payNo & "'", con)
                Else
                    'cmd = New SqlCommand("update LOAN_REPAYMENT_SCHEDULE set DATE_PAID=GETDATE(),AMOUNT_PAID='" & txtRepayAmt.Text & "',INST_PRINCIPAL_BALANCE=" & txtRepayAmt.Text & "-PAYMENT where LOANID='" & loanID & "' and PAYMENT_NO='" & payNo & "'", con)
                    cmd = New SqlCommand("update LOAN_REPAYMENT_SCHEDULE set DATE_PAID='" & datePaid & "',AMOUNT_PAID='" & amt & "',INST_PRINCIPAL_BALANCE=" & amt & "-PAYMENT where LOANID='" & loanID & "' and PAYMENT_NO='" & payNo & "'", con)
                End If
                If con.State = ConnectionState.Open Then
                    con.Close()
                End If
                con.Open()
                If cmd.ExecuteNonQuery Then
                    Dim bbfwd = getBalBFwd(loanID)
                    'insert into QUEST_TRANSACTIONS
                    'cmd = New SqlCommand("insert into QUEST_TRANSACTIONS (CUST_NO,LOANID,TRANS_DATE,TRANS_DESC,DEBIT,CREDIT,BAL_BFWD,BAL_CFWD) values ('" & hidCustNo.Value & "','" & loanID & "',GETDATE(),'Loan Repayment',0," & txtRepayAmt.Text & "," & bbfwd & "," & bbfwd & "-" & txtRepayAmt.Text & ")", con)
                    cmd = New SqlCommand("insert into QUEST_TRANSACTIONS (CUST_NO,LOANID,TRANS_DATE,TRANS_DESC,DEBIT,CREDIT,BAL_BFWD,BAL_CFWD) values ('" & custNo & "','" & loanID & "',GETDATE(),'Loan Repayment-SSBsys',0," & amt & "," & bbfwd & "," & bbfwd & "-" & amt & ")", con)
                    cmd.ExecuteNonQuery()
                    If isFullyPaid(loanID, payNo) Then
                        updateFullyPaid(loanID, payNo)
                        updateLoanRepaid(loanID)
                    Else
                    End If
                Else
                End If
                con.Close()
            Next
        End If

    End Sub

    Private Function GetData() As DataSet
        Dim strLine As String
        Dim strArray(4) As String
        'Dim charArray() As Char = {","c}
        Dim ds As New DataSet()
        Dim dt As DataTable = ds.Tables.Add("TheData")
        filSSBUpload.SaveAs(Server.MapPath("Uploads/" & filSSBUpload.FileName))

        Dim aFile As New FileStream(Server.MapPath("Uploads/" & filSSBUpload.FileName), FileMode.Open) 'c:/example.csv
        Dim sr As New StreamReader(aFile)

        strLine = sr.ReadLine()
        dt.Columns.Add("Ref")
        dt.Columns.Add("Name")
        dt.Columns.Add("Amount")
        dt.Columns.Add("Ref2")
        strLine = sr.ReadLine()
        Do While strLine IsNot Nothing
            strArray = Nothing
            'strArray = strLine.Split(charArray)
            'strArray = strLine.Split(Chr(9))
            'Dim ref, name, amt, ecno As String
            Dim newStr = Trim(strLine.Substring(0, 12)) & Chr(9) & Trim(strLine.Substring(13, 30)) & Chr(9) & Trim(strLine.Substring(44, 23)) & Chr(9) & Trim(strLine.Substring(66, 10))
            'msgbox(newStr)
            strArray = newStr.Split(Chr(9))
            Dim dr As DataRow = dt.NewRow()
            For i As Integer = 0 To 3 ' strArray.GetUpperBound(0)
                dr(i) = strArray(i).Trim()
                'msgbox(dr(i))
            Next i
            'cmd = New SqlCommand("insert into SSB_UPLOAD([REFERENCE],[NAMES],[AMOUNT],[ECNO]) values ('" & ref & "','" & name & "','" & amt & "','" & ecno & "')", con)
            dt.Rows.Add(dr)
            strLine = sr.ReadLine()
            ''msgbox(strLine)
        Loop
        sr.Close()
        Return ds
    End Function

    Private Function GetDataCSV() As DataSet
        Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
            Dim strLine As String
            Dim strArray() As String
            Dim charArray() As Char = {"	"c}
            Dim ds As New DataSet()
            Dim dt As DataTable = ds.Tables.Add("TheData")
            filSSBUpload.SaveAs(Server.MapPath("Uploads/" & filSSBUpload.FileName))
            createTabbedFile(Server.MapPath("Uploads/" & filSSBUpload.FileName), Server.MapPath("Uploads/tab" & filSSBUpload.FileName))
            Dim aFile As New FileStream(Server.MapPath("Uploads/tab" & filSSBUpload.FileName), FileMode.Open)
            Dim sr As New StreamReader(aFile)

            strLine = sr.ReadLine()
            strArray = strLine.Split(charArray)

            For x As Integer = 0 To strArray.GetUpperBound(0)
                dt.Columns.Add(strArray(x).Trim())
            Next x

            strLine = sr.ReadLine()
            Do While strLine IsNot Nothing
                strArray = strLine.Split(charArray)
                Dim dr As DataRow = dt.NewRow()
                For i As Integer = 0 To strArray.GetUpperBound(0)
                    dr(i) = strArray(i).Trim()
                Next i
                dt.Rows.Add(dr)
                strLine = sr.ReadLine()
            Loop
            sr.Close()
            Return ds
        End Using
    End Function
End Class