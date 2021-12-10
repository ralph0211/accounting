Imports System.Data
Imports System.Data.SqlClient
Imports System.IO

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
    Protected Sub btnAddAgent_Click(sender As Object, e As EventArgs) Handles btnAddAgent.Click
        'Try
        If RadioButtonList1.SelectedIndex = 0 Then
            If FileUpload1.HasFile = False Then
                msgbox("Please Select Errors File")
                Exit Sub
            Else
                If FileUpload1.FileName.ToString.Contains("err") Then
                    insertNew_Error()
                    'to  review from file from SSB
                Else
                    msgbox("File is Not Error Report")
                    Exit Sub
                End If
            End If
        ElseIf RadioButtonList1.SelectedIndex = 1 Then
            If FileUpload1.HasFile = False Then
                msgbox("Please Select Approved File")
                Exit Sub
            Else
                If FileUpload1.FileName.ToString.Contains("rep") Then
                    insertNew_Approved()
                    'to  review from file from SSB
                Else
                    msgbox("File is Not Approved Applications Report")
                    Exit Sub
                End If
            End If
        Else
            msgbox("Please Select File Type")
            Exit Sub
        End If
        '  Catch ex As Exception
        'msgbox(ex.Message.ToString)
        ' End Try
    End Sub
    Protected Sub ProcessFileFromSSB_Errors()
        cmd = New SqlCommand("insert into CMS_SSB_Error(ReferenceNo, EC_NO, CUSTOMER_NO, AMOUNT,DateCreated, REFSYSNO, ErrorCode, ADCODE, PAYEE, IDNUMBER, FROMDATE, TODATE) select ReferenceNo, EC_NO, CUSTOMER_NO, AMOUNT, GETDATE(),REFSYSNO, ErrorCode, ADCODE, PAYEE, IDNUMBER, FROMDATE, TODATE from CMS_SSB ", con)
        If (con.State = ConnectionState.Open) Then
            con.Close()
        End If
        con.Open()
        If cmd.ExecuteNonQuery() Then
        End If

        cmd = New SqlCommand("select * from CMS_SSB_Error Where Processed=0", con)
        Dim ds As New DataSet
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "LG_SSB_Error")
        If ds.Tables(0).Rows.Count > 0 Then

            For Each dr As DataRow In ds.Tables(0).Rows
                cmd = New SqlCommand("update QUEST_APPLICATION set ssbApproved=0,ssbApprovedBy='" & Session("Userid") & "',ssbApprovedDate=GETDATE() where ID='" & Replace(dr.Item("REFSYSNO").ToString, "CF", "") & "' AND ECNO='" & dr.Item("EC_NO").ToString & "' update CMS_SSB_Error set Processed=1 where REFSYSNO='" & dr.Item("REFSYSNO").ToString & "' AND EC_NO='" & dr.Item("EC_NO") & "'", con)
                If (con.State = ConnectionState.Open) Then
                    con.Close()
                End If
                con.Open()
                If cmd.ExecuteNonQuery() Then
                End If
            Next
            msgbox("SSB Error File Successfully Uploaded")
        End If
    End Sub
    Sub UpdateAppNo()
        cmd = New SqlCommand("update CMS_SSB_Success set AppNo = SUBSTRING(REFSYSNO,3,100 ) where AppNo IS NULL", con)
        If (con.State = ConnectionState.Open) Then
            con.Close()
        End If
        con.Open()
        If cmd.ExecuteNonQuery() Then
        End If
    End Sub
    Protected Sub ProcessFileFromSSB_Approved()
        cmd = New SqlCommand("insert into CMS_SSB_Success([ReferenceNo],[EC_NO],[CUSTOMER_NO],[AMOUNT],SURNAMES,REFSYSNO,ADCODE,PAYEE,IDNUMBER,FROMDATE,TODATE,BRANCH,BANKACCOUNT,[DateCreated]) select [ReferenceNo],[EC_NO],[CUSTOMER_NO],[AMOUNT],SURNAMES,REFSYSNO,ADCODE,PAYEE,IDNUMBER,FROMDATE,TODATE,BRANCH,BANKACCOUNT,GETDATE() from CMS_SSB ", con)
        If (con.State = ConnectionState.Open) Then
            con.Close()
        End If
        con.Open()
        If cmd.ExecuteNonQuery() Then
        End If
        UpdateAppNo()
        cmd = New SqlCommand("select * from CMS_SSB_Success Where Processed=0 AND AppNo is not NULL", con)
        Dim ds As New DataSet
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "CMS_SSB_Success")
        If ds.Tables(0).Rows.Count > 0 Then
            For Each dr As DataRow In ds.Tables(0).Rows
                Dim qECNo As String = dr.Item("EC_NO").ToString.Remove(7, 1)
                Dim thisAppNo As Long = CLng(dr.Item("AppNo"))
                If dr.Item("CUSTOMER_NO").ToString.Trim = "d" Then
                    cmd = New SqlCommand("update QUEST_APPLICATION set ssbDeletionApproved=1,ssbApproved=1,ssbApprovedBy='" & Session("Userid") & "',ssbApprovedDate=GETDATE() where ID=CONVERT(NUMERIC(18,0)," & thisAppNo & ") and ECNO='" & qECNo & "' update CMS_SSB_Success set Processed=1 where EC_NO='" & dr.Item("EC_NO") & "' and REFSYSNO= '" & dr.Item("REFSYSNO").ToString & "'", con)
                Else
                    cmd = New SqlCommand("update QUEST_APPLICATION set STATUS='MCC Approval',SEND_TO='1024',[ApprovalNumber]=[ApprovalNumber]+1,ssbApproved=1,ssbApprovedBy='" & Session("Userid") & "',ssbApprovedDate=GETDATE() where ID=CONVERT(NUMERIC(18,0)," & thisAppNo & ") and ECNO='" & qECNo & "' update CMS_SSB_Success set Processed=1 where EC_NO='" & dr.Item("EC_NO") & "' and REFSYSNO= '" & dr.Item("REFSYSNO").ToString & "'", con)
                End If
                If (con.State = ConnectionState.Open) Then
                    con.Close()
                End If
                con.Open()
                If cmd.ExecuteNonQuery() Then
                End If
            Next
            msgbox("SSB Approved File Successfully Uploaded")
        End If
    End Sub
    Private Function CheckFileExists_Approved(ByVal filename As String) As Boolean
        cmd = New SqlCommand("select * from CMS_SSB_Success Where ReferenceNo='" & filename & "' and Processed=1", con)
        Dim ds As New DataSet
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "CMS_SSB_Success")
        If ds.Tables(0).Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Page.MaintainScrollPositionOnPostBack = True
        con = New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
        If Not IsPostBack Then

        End If
    End Sub
    Private Function GetData() As DataSet
        Dim strLine As String
        Dim strArray() As String
        Dim charArray() As Char = {","c}
        Dim ds As New DataSet()
        Dim dt As DataTable = ds.Tables.Add("TheData")
        FileUpload1.SaveAs(Server.MapPath("~\Docs\" & FileUpload1.FileName))
        Dim aFile As New FileStream(Server.MapPath("~\Docs\" & FileUpload1.FileName), FileMode.Open)
        Dim sr As New StreamReader(aFile)
        Dim arrText As New ArrayList()
        For x As Integer = 0 To 12
            dt.Columns.Add(x)
        Next x
        Do
            strLine = sr.ReadLine()
            If Not strLine Is Nothing Then
                If (strLine.Contains(" n ") Or strLine.Contains(" c ") Or strLine.Contains(" d ")) And strLine.Contains("CF") Then
                    strLine = Regex.Replace(strLine, " {2,}", " ")
                    strLine = strLine.Replace(" ", ",")
                    arrText.Add(strLine)
                    strArray = strLine.Split(charArray)
                    Dim dr As DataRow = dt.NewRow()
                    Dim k As Integer = 0
                    For i As Integer = 0 To strArray.GetUpperBound(0)
                        ' k=i
                        If i = 3 Then
                            If IsNumeric(strArray(i)) = False Then
                                'dr(i) = strArray(4).Trim()

                                Continue For
                            End If
                        End If
                        dr(k) = strArray(i).Trim()
                        k = k + 1
                    Next i
                    dt.Rows.Add(dr)
                End If
            End If
        Loop Until strLine Is Nothing
        sr.Close()
        Return ds
    End Function
    Sub insertNew_Approved()
        Dim fd As New DataSet
        fd = GetData()
        Dim rowcount = fd.Tables(0).Rows.Count
        Dim colcount = fd.Tables(0).Columns.Count
        Dim fileName As String = FileUpload1.FileName
        If CheckFileExists_Approved(fileName) = True Then
            msgbox("File Already Uploaded")
            Exit Sub
        Else
            Dim comm As New SqlCommand
            If rowcount > 0 Then
                DeleteRecords()
                For i = 0 To rowcount - 1
                    Dim ReferenceNo, EC_NO, CUSTOMER_NO, AMOUNT, SURNAMES, ADCODE, PAYEE, REFSYSNO, IDNUMBER, FROMDATE, TODATE, BRANCH, BANKACCOUNT As String
                    ReferenceNo = Trim(fileName)
                    EC_NO = Trim(removeNULLString(fd, i, 0))
                    CUSTOMER_NO = Trim(removeNULLString(fd, i, 1))
                    AMOUNT = Trim(removeNULLString(fd, i, 9))
                    SURNAMES = Trim(removeNULLString(fd, i, 2))
                    ADCODE = Trim(removeNULLString(fd, i, 3))
                    PAYEE = Trim(removeNULLString(fd, i, 4))
                    REFSYSNO = Trim(removeNULLString(fd, i, 5))
                    IDNUMBER = Trim(removeNULLString(fd, i, 6))
                    FROMDATE = Trim(removeNULLString(fd, i, 7))
                    TODATE = Trim(removeNULLString(fd, i, 8))
                    BRANCH = Trim(removeNULLString(fd, i, 10))
                    BANKACCOUNT = Trim(removeNULLString(fd, i, 11))
                    Using command As New SqlCommand("INSERT INTO CMS_SSB(ReferenceNo, EC_NO, CUSTOMER_NO, AMOUNT,SURNAMES, ADCODE, PAYEE, REFSYSNO, IDNUMBER, FROMDATE, TODATE, BRANCH, BANKACCOUNT)VALUES(@data1,@data2,@data3,@data4,@data5,@data6,@data7,@data8,@data9,@data10,@data11,@data12,@data13)", con)
                        command.Parameters.AddWithValue("@data1", ReferenceNo)
                        command.Parameters.AddWithValue("@data2", EC_NO)
                        command.Parameters.AddWithValue("@data3", CUSTOMER_NO)
                        command.Parameters.AddWithValue("@data4", AMOUNT)
                        command.Parameters.AddWithValue("@data5", SURNAMES)
                        command.Parameters.AddWithValue("@data6", ADCODE)
                        command.Parameters.AddWithValue("@data7", PAYEE)
                        command.Parameters.AddWithValue("@data8", REFSYSNO)
                        command.Parameters.AddWithValue("@data9", IDNUMBER)
                        command.Parameters.AddWithValue("@data10", FROMDATE)
                        command.Parameters.AddWithValue("@data11", TODATE)
                        command.Parameters.AddWithValue("@data12", BRANCH)
                        command.Parameters.AddWithValue("@data13", BANKACCOUNT)
                        If (con.State = ConnectionState.Open) Then
                            con.Close()
                        End If
                        con.Open()
                        command.ExecuteNonQuery()
                        con.Close()
                    End Using
                Next
                ProcessFileFromSSB_Approved()
            End If
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
    Private Function GetData_Error() As DataSet
        Dim strLine As String
        Dim strArray() As String
        Dim charArray() As Char = {","c}
        Dim ds As New DataSet()
        Dim dt As DataTable = ds.Tables.Add("TheData")
        FileUpload1.SaveAs(Server.MapPath("~\Docs\" & FileUpload1.FileName))
        Dim aFile As New FileStream(Server.MapPath("~\Docs\" & FileUpload1.FileName), FileMode.Open)
        Dim sr As New StreamReader(aFile)
        Dim arrText As New ArrayList()
        For x As Integer = 0 To 9
            dt.Columns.Add(x)
        Next x
        Do
            strLine = sr.ReadLine()
            If Not strLine Is Nothing Then
                If (strLine.Contains(" n ") Or strLine.Contains(" c ")) And strLine.Contains("CF") Then
                    strLine = Regex.Replace(strLine, " {2,}", " ")

                    Dim wordArr As String() = strLine.Split(".")
                    Dim Errorresult As String = wordArr(1).Replace(",", "")
                    Errorresult = Errorresult.Remove(0, 3)
                    Dim sents As String = "." & wordArr(1).Substring(0, 2)

                    Errorresult = Errorresult.Replace(" ", "_")
                    Errorresult = " " & Errorresult
                    strLine = wordArr(0) & sents & Errorresult

                    strLine = strLine.Replace(" ", ",")
                    arrText.Add(strLine)
                    strArray = strLine.Split(charArray)
                    Dim dr As DataRow = dt.NewRow()
                    For i As Integer = 0 To strArray.GetUpperBound(0)
                        dr(i) = strArray(i).Trim()
                    Next i
                    dt.Rows.Add(dr)
                End If
            End If
        Loop Until strLine Is Nothing
        sr.Close()
        Return ds
    End Function
    Sub insertNew_Error()
        Dim fd As New DataSet
        fd = GetData_Error()
        Dim rowcount = fd.Tables(0).Rows.Count
        Dim colcount = fd.Tables(0).Columns.Count
        Dim fileName As String = FileUpload1.FileName
        If CheckFileExists_Error(fileName) = True Then
            msgbox("Error File Already Uploaded")
            Exit Sub
        Else
            Dim comm As New SqlCommand
            If rowcount > 0 Then
                DeleteRecords()
                For i = 0 To rowcount - 1
                    Dim ReferenceNo, EC_NO, CUSTOMER_NO, AMOUNT, ErrorDesc, ADCODE, PAYEE, REFSYSNO, IDNUMBER, FROMDATE, TODATE As String
                    ReferenceNo = Trim(fileName)
                    EC_NO = Trim(removeNULLString(fd, i, 0))
                    CUSTOMER_NO = Trim(removeNULLString(fd, i, 1))
                    AMOUNT = Trim(removeNULLString(fd, i, 8))
                    ErrorDesc = Trim(removeNULLString(fd, i, 9))
                    ADCODE = Trim(removeNULLString(fd, i, 2))
                    PAYEE = Trim(removeNULLString(fd, i, 3))
                    REFSYSNO = Trim(removeNULLString(fd, i, 4))
                    IDNUMBER = Trim(removeNULLString(fd, i, 5))
                    FROMDATE = Trim(removeNULLString(fd, i, 6))
                    TODATE = Trim(removeNULLString(fd, i, 7))

                    Using command As New SqlCommand("INSERT INTO CMS_SSB(ReferenceNo, EC_NO, CUSTOMER_NO, AMOUNT,ErrorCode, ADCODE, PAYEE, REFSYSNO, IDNUMBER, FROMDATE, TODATE)VALUES(@data1,@data2,@data3,@data4,@data5,@data6,@data7,@data8,@data9,@data10,@data11)", con)
                        command.Parameters.AddWithValue("@data1", ReferenceNo)
                        command.Parameters.AddWithValue("@data2", EC_NO)
                        command.Parameters.AddWithValue("@data3", CUSTOMER_NO)
                        command.Parameters.AddWithValue("@data4", AMOUNT)
                        command.Parameters.AddWithValue("@data5", ErrorDesc)
                        command.Parameters.AddWithValue("@data6", ADCODE)
                        command.Parameters.AddWithValue("@data7", PAYEE)
                        command.Parameters.AddWithValue("@data8", REFSYSNO)
                        command.Parameters.AddWithValue("@data9", IDNUMBER)
                        command.Parameters.AddWithValue("@data10", FROMDATE)
                        command.Parameters.AddWithValue("@data11", TODATE)
                        If (con.State = ConnectionState.Open) Then
                            con.Close()
                        End If
                        con.Open()
                        command.ExecuteNonQuery()
                        con.Close()
                    End Using
                Next
                ProcessFileFromSSB_Errors()
            End If
        End If
    End Sub
    Private Function CheckFileExists_Error(ByVal filename As String) As Boolean
        cmd = New SqlCommand("select * from CMS_SSB_Error Where ReferenceNo='" & filename & "' and Processed=1", con)
        Dim ds As New DataSet
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "CMS_SSB_Error")
        If ds.Tables(0).Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function
End Class