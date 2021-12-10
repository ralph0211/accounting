Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports CreditManager
Imports ErrorLogging
Partial Class Credt_uploadSSBFile
    Inherits System.Web.UI.Page
    Dim cmd As SqlCommand
    Dim adp As SqlDataAdapter
    Dim con As New SqlConnection
    Dim connection As String
    Public Shared typeEditID As Double
    Public Sub msgbox(ByVal strMessage As String)
        'finishes server processing, returns to client.
        Dim strScript As String = "<script language=JavaScript>"
        strScript += "window.alert(""" & strMessage & """);"
        strScript += "</script>"
        Dim lbl As New System.Web.UI.WebControls.Label
        lbl.Text = strScript
        Page.Controls.Add(lbl)
    End Sub
    Protected Sub DeleteRecords()
        cmd = New SqlCommand("truncate table CMS_SSB", con)
        If (con.State = ConnectionState.Open) Then
            con.Close()
        End If
        con.Open()
        If cmd.ExecuteNonQuery() Then

        End If
        con.Close()
    End Sub
    Protected Sub UpdateReferenceNo()
        cmd = New SqlCommand("update CMS_SSB set CUSTOMER_NO=replace(REFSYSNO,'CF','')", con)
        If (con.State = ConnectionState.Open) Then
            con.Close()
        End If
        con.Open()
        If cmd.ExecuteNonQuery() Then

        End If
        con.Close()
    End Sub
    Private Function GetData() As DataSet
        'msgbox(Server.MapPath(FileUpload1.FileName).ToString)
        'Exit Function
        Dim strLine As String
        Dim strArray() As String
        Dim charArray() As Char = {","c}
        Dim ds As New DataSet()
        Dim dt As DataTable = ds.Tables.Add("TheData")
        FileUpload1.SaveAs(Server.MapPath("~\Docs\" & FileUpload1.FileName))
        Dim aFile As New FileStream(Server.MapPath("~\Docs\" & FileUpload1.FileName), FileMode.Open)
        Dim sr As New StreamReader(aFile)
        Dim arrText As New ArrayList()
        For x As Integer = 0 To 5
            dt.Columns.Add(x)
        Next x
        'strLine = sr.ReadLine()
        Do
            strLine = sr.ReadLine()
            If Not strLine Is Nothing Then
                If strLine.Contains("CF") And strLine.Contains(".") Then
                    Dim str As String = strLine
                    '/////////////////////////TEST
                    Dim s As String = str
                    Dim words As String() = s.Split(New Char() {","c})
                    'Dim word As String
                    strLine = words(0) & " " & words(1).ToString.Remove(0, 15)
                    strLine = Regex.Replace(strLine, " {2,}", " ")
                    strLine = strLine.Replace(" ", ",")
                    arrText.Add(strLine)
                    strArray = strLine.Split(charArray)
                    Dim dr As DataRow = dt.NewRow()
                    Dim k As Integer = 0
                    For i As Integer = 0 To strArray.GetUpperBound(0)
                        If i = 2 Then
                            If IsNumeric(strArray(i)) = False Then
                                'dr(i) = strArray(4).Trim()
                                Continue For
                            End If
                        End If
                        dr(k) = strArray(i).Trim()
                        k = k + 1

                        'dr(i) = strArray(i).Trim()
                    Next i
                    dt.Rows.Add(dr)
                    ' strLine = sr.ReadLine()
                End If
            End If
            ' strLine = sr.ReadLine()
        Loop Until strLine Is Nothing
        sr.Close()
        Return ds
    End Function
    Sub insertNew()
        Dim fd As New DataSet
        fd = GetData()
        Dim rowcount = fd.Tables(0).Rows.Count
        Dim colcount = fd.Tables(0).Columns.Count
        Dim fileName As String = FileUpload1.FileName
        Dim comm As New SqlCommand
        If rowcount > 0 Then
            DeleteRecords()
            For i = 0 To rowcount - 1
                Dim ReferenceNo, EC_NO, AMOUNT, SURNAMES, REFSYSNO As String
                ReferenceNo = Trim(fileName)
                EC_NO = Trim(removeNULLString(fd, i, 3))
                AMOUNT = Trim(removeNULLString(fd, i, 2))
                SURNAMES = Trim(removeNULLString(fd, i, 1))
                REFSYSNO = Trim(removeNULLString(fd, i, 0))

                Using command As New SqlCommand("INSERT INTO CMS_SSB(ReferenceNo, EC_NO, AMOUNT,SURNAMES,REFSYSNO)VALUES(@data1,@data2,@data3,@data4,@data5)", con)
                    command.Parameters.AddWithValue("@data1", ReferenceNo)
                    command.Parameters.AddWithValue("@data2", EC_NO)
                    command.Parameters.AddWithValue("@data3", AMOUNT)
                    command.Parameters.AddWithValue("@data4", SURNAMES)
                    command.Parameters.AddWithValue("@data5", REFSYSNO)

                    If (con.State = ConnectionState.Open) Then
                        con.Close()
                    End If
                    con.Open()
                    command.ExecuteNonQuery()
                    con.Close()
                End Using
            Next
            UpdateReferenceNo()
        End If
    End Sub
    Function removeNULLString(ByVal myreader As DataSet, ByVal j As Integer, ByVal stval As Integer) As String

        Dim val As Object = myreader.Tables(0).Rows(j).Item(stval)
        If val IsNot DBNull.Value Then
            If val <> "" Then
                Return val.ToString()
            Else
                Return Convert.ToString("")
            End If
        Else
            Return Convert.ToString("")
        End If
    End Function
    Private Function CheckFileExists_Approved(ByVal filename As String) As Boolean
        cmd = New SqlCommand("select * from CMS_SSB_PAYMENTS Where ReferenceNo='" & filename & "' and Processed=1", con)
        Dim ds As New DataSet
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "CMS_SSB_PAYMENTS")
        If ds.Tables(0).Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function
    Protected Sub btnAddAgent_Click(sender As Object, e As EventArgs) Handles btnAddAgent.Click
        ' Try
        If FileUpload1.HasFile = False Then
                msgbox("Please Select File")
                Exit Sub
            Else
                If cmbCapitalAccount.SelectedIndex < 0 Or cmbInterestAccount.SelectedIndex < 0 Then
                    msgbox("Select Interest and Capital Accounts")
                    Exit Sub
                End If
                If cmbCapitalAccount.Text = "" Or cmbInterestAccount.Text = "" Then
                    msgbox("Select Interest and Capital Accounts")
                    Exit Sub
                End If
                If bdpPaymentDate.Text = "" Then
                    msgbox("Select Payment Date")
                    Exit Sub
                End If
                Dim fileName As String = FileUpload1.FileName
                    If CheckFileExists_Approved(fileName) = True Then
                        msgbox("File Already Uploaded")
                        Exit Sub
                    Else
                        insertNew()
                        ProcessFileFromSSB_Approved(fileName)
                        msgbox("Final SSB File Successfully Uploaded")
                    End If
                End If
        'Catch ex As Exception
        '    msgbox(ex.Message.ToString)
        'End Try
    End Sub
    Protected Sub ProcessFileFromSSB_Approved(ByVal Fil_name As String)
        cmd = New SqlCommand("insert into CMS_SSB_PAYMENTS (ReferenceNo, EC_NO, CUSTOMER_NO, AMOUNT, REFSYSNO, SURNAMES, ErrorCode, ADCODE, PAYEE, IDNUMBER, FROMDATE, TODATE, BRANCH, BANKACCOUNT) select ReferenceNo, EC_NO, CUSTOMER_NO, AMOUNT, REFSYSNO, SURNAMES, ErrorCode, ADCODE, PAYEE, IDNUMBER, FROMDATE, TODATE, BRANCH, BANKACCOUNT from CMS_SSB", con)
        If (con.State = ConnectionState.Open) Then
            con.Close()
        End If
        con.Open()
        If cmd.ExecuteNonQuery() Then
            'cmd = New SqlCommand("select * from CMS_SSB_PAYMENTS Where ReferenceNo='" & Fil_name & "' and Processed=0", con)
            cmd = New SqlCommand("select a.* from CMS_SSB_PAYMENTS a inner join QUEST_APPLICATION q on a.CUSTOMER_NO= convert(varchar,q.ID) where a.Processed = 0 and a.ReferenceNo='" & Fil_name & "'", con)
            Dim ds As New DataSet
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "CMS_SSB_PAYMENTS")
            If ds.Tables(0).Rows.Count > 0 Then
                For Each dr As DataRow In ds.Tables(0).Rows
                    Dim Principal As Double = 0
                    Dim Interest As Double = 0
                    Dim custNumber As String = ""
                    cmd = New SqlCommand("select top 1 *,isnull((select CUSTOMER_NUMBER from QUEST_APPLICATION where ID='" & dr.Item("CUSTOMER_NO") & "'),'0') AS CustNum from AMORTIZATION_SCHEDULE Where LOANID='" & dr.Item("CUSTOMER_NO") & "'", con)
                    Dim dse As New DataSet
                    adp = New SqlDataAdapter(cmd)
                    adp.Fill(dse, "CMS_SSB_PAYMENTS")
                    If dse.Tables(0).Rows.Count > 0 Then
                        If dse.Tables(0).Rows(0).Item("CustNum").ToString <> "0" Then
                            ' Principal = CDbl(dse.Tables(0).Rows(0).Item("PRINCIPAL"))
                            Interest = CDbl(dse.Tables(0).Rows(0).Item("INTEREST"))
                            Principal = CDbl(dr.Item("AMOUNT")) - Interest
                            custNumber = CStr(dse.Tables(0).Rows(0).Item("CustNum").ToString)
                            Using cmdT As New SqlCommand("SaveRepayment", con)
                                cmdT.CommandType = CommandType.StoredProcedure
                                cmdT.Parameters.AddWithValue("@loanID", dr.Item("CUSTOMER_NO"))
                                cmdT.Parameters.AddWithValue("@CustNo", custNumber)
                                cmdT.Parameters.AddWithValue("@TrxnDate", bdpPaymentDate.Text)
                                cmdT.Parameters.AddWithValue("@Interest", Interest)
                                cmdT.Parameters.AddWithValue("@Principal", Principal)
                                cmdT.Parameters.AddWithValue("@Penalty", 0)
                                cmdT.Parameters.AddWithValue("@TotalAmount", dr.Item("AMOUNT"))
                                cmdT.Parameters.AddWithValue("@RolloverBalance", 0)
                                cmdT.Parameters.AddWithValue("@InterestNextPmt", 0)
                                cmdT.Parameters.AddWithValue("@NextPmtTotal", 0)
                                cmdT.Parameters.AddWithValue("@CapturedBy", Session("UserId"))
                                cmdT.Parameters.AddWithValue("@ReceiptNo", dr.Item("REFSYSNO").ToString & dr.Item("ReferenceNo").ToString)
                                If con.State = ConnectionState.Open Then
                                    con.Close()
                                End If
                                con.Open()
                                If cmdT.ExecuteNonQuery() Then
                                    saveTransaction(dr.Item("CUSTOMER_NO").ToString, "Capital Repayment", Principal, 0, cmbCapitalAccount.SelectedValue, custNumber, "1", "", "", "", "", bdpPaymentDate.Text)
                                    saveTransaction(dr.Item("CUSTOMER_NO").ToString, "Interest Repayment", Interest, 0, cmbInterestAccount.SelectedValue, custNumber, "1", "", "", "", "", bdpPaymentDate.Text)
                                End If
                                con.Close()
                                cmd = New SqlCommand("update CMS_SSB_PAYMENTS set Processed=1 where ID='" & dr.Item("ID") & "'", con)
                                If (con.State = ConnectionState.Open) Then
                                    con.Close()
                                End If
                                con.Open()
                                cmd.ExecuteNonQuery()
                            End Using
                        End If
                    End If
                Next
            End If
        End If
    End Sub
    Protected Sub saveTransaction(reference As String, description As String, debit As Double, credit As Double, account As String, contra As String, status As String, other As String, bankAccId As String, bankAccName As String, batchRef As String, trxnDate As Date)
        Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
            Using cmd As New SqlCommand("SaveAccountsTrxnsTempWithContra", con)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("@Type", "System Entry")
                cmd.Parameters.AddWithValue("@Category", "Loan Repayment")
                cmd.Parameters.AddWithValue("@Ref", reference)
                cmd.Parameters.AddWithValue("@Desc", description)
                cmd.Parameters.AddWithValue("@Debit", debit)
                cmd.Parameters.AddWithValue("@Credit", credit)
                cmd.Parameters.AddWithValue("@Account", account)
                cmd.Parameters.AddWithValue("@ContraAccount", contra)
                cmd.Parameters.AddWithValue("@Status", status)
                cmd.Parameters.AddWithValue("@Other", other)
                cmd.Parameters.AddWithValue("@BankAccID", bankAccId)
                cmd.Parameters.AddWithValue("@BankAccName", bankAccName)
                cmd.Parameters.AddWithValue("@BatchRef", batchRef)
                cmd.Parameters.AddWithValue("@TrxnDate", trxnDate)
                cmd.Parameters.AddWithValue("@CaptureBy", Session("UserId"))

                If con.State = ConnectionState.Open Then
                    con.Close()
                End If
                con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            End Using
        End Using
    End Sub
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Page.MaintainScrollPositionOnPostBack = True
        con = New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
        If Not IsPostBack Then
            loadAccounts()
        End If
    End Sub
    Protected Sub loadAccounts()
        Try
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd = New SqlCommand("select convert(varchar,MainAccount)  + '/' + convert(varchar,SubAccount) as AccountNo, AccountName  + '  ' + convert(varchar,MainAccount)  + '/' + convert(varchar,SubAccount) as AccountName from tbl_FinancialAccountsCreation where (MainAccount='212' or MainAccount='211') and SubAccount<>1", con)
                    'End if
                    Dim ds As New DataSet
                    Using adp = New SqlDataAdapter(cmd)
                        adp.Fill(ds, "LRS2")
                    End Using
                    cmbCapitalAccount.Visible = True
                    loadCombo(ds.Tables(0), cmbCapitalAccount, "AccountName", "AccountNo")
                    loadCombo(ds.Tables(0), cmbInterestAccount, "AccountName", "AccountNo")
                End Using
            End Using
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- loadAccounts()", ex.ToString)
        End Try
    End Sub
End Class
