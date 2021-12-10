Imports System.Data
Imports System.Data.SqlClient
Imports System.IO

Partial Class Credit_DownloadSSBFile
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
    Public Function GetLastDayOfMonth(intMonth, intYear) As Date
        GetLastDayOfMonth = DateSerial(intYear, intMonth + 1, 0)
    End Function
    Protected Sub btnAddAgent_Click(sender As Object, e As EventArgs) Handles btnAddAgent.Click
        ' msgbox(datLastDay)
        If DropDownList1.SelectedIndex = 0 Then
            msgbox("Select File Type")
            Exit Sub
        ElseIf DropDownList1.SelectedIndex = 1 Then
            If dtpStartDate.Text <> "" Then
                generateSSBfile("n','c")
            Else
                msgbox("Select Date")
                Exit Sub
            End If
        ElseIf DropDownList1.SelectedIndex = 2 Then
            If dtpStartDate.Text <> "" Then
                generateSSBfile("d")
            Else
                msgbox("Select Date")
                Exit Sub
            End If
        End If

    End Sub
    Public Sub generateSSBfile(ByVal f_type As String)
        Try
            If Not IsDate(dtpStartDate.Text) Then
                msgbox("Enter valid date")
                dtpStartDate.Focus()
                Exit Sub
            ElseIf Not IsDate(txtStartDate.Text) Then
                msgbox("Enter valid start date")
                txtStartDate.Focus()
                Exit Sub
            ElseIf Not IsDate(txtEndDate.Text) Then
                msgbox("Enter valid end date")
                txtEndDate.Focus()
                Exit Sub
            End If
            Dim csv As String = String.Empty
            '   Dim sr As StreamWriter = File.CreateText(filpath)
            Dim trailerID As String = "TRL"
            Dim transactionType, ECNO, accno, membershipNo, NIDNO, filetype As String
            Dim checksum As String = ""
            Dim processdate As String = CDate(dtpStartDate.Text).ToString("yyyyMMdd")

            Dim Amt As Double
            Dim lineDetails, trailer As String
            Dim senderName, headerID, header As String
            headerID = "HDR"
            senderName = "LIC FINANCE(PVT) LTD"
            Dim a As String = String.Format("{0,-30}", senderName)
            Dim spxh As String = Space(32)
            header = headerID & a & processdate & spxh
            'sr.WriteLine(header)
            csv += header
            ' csv += vbCr & vbLf
            Try
                Dim cmd As SqlCommand
                Dim adp As SqlDataAdapter
                ' cmd = New SqlCommand("select cast(((((ISNULL(FIN_AMT,0)*isnull(FIN_INT_RATE,0)/100)*isnull(FIN_TENOR,0))+isnull(FIN_AMT,0))/isnull(FIN_TENOR,1))*100  as numeric(18,0)) AS PREMIUMAMT, * from QUEST_APPLICATION where SSB_FileNo=0 and FIN_TENOR<>0 and FIN_AMT<>0 and SUB_INDIVIDUAL='SSB' and STATUS LIKE 'APPROVE%' AND isnull(FILE_SENT_TOSSB,0) <>1 and SSB_FILE_TYPE is NOT NULL and SSB_FILE_TYPE in ('" & f_type & "') order by ID asc", con)
                If f_type = "d" Then
                    'cmd = New SqlCommand("select DATEADD(m, DATEDIFF(m, 0, FIN_REPAY_DATE), 0) as newdate,(case when isnull(LoanExtension,'')='EXTENSION' then (select top 1 CONVERT(VARCHAR(24),e.payment_DATE,112) from AMORTIZATION_SCHEDULE e where e.LOANID=QUEST_APPLICATION.ID order by e.PAYMENT_DATE desc) ELSE CONVERT(VARCHAR(24),DATEADD(s,-1,DATEADD(mm, DATEDIFF(m,0,dateadd(mm,FIN_TENOR-1,FIN_REPAY_DATE))+1,0)),112) END) as FINENDDATE,(case when isnull(LoanExtension,'')='EXTENSION' then (select top 1 convert(numeric(18,2),e.payment)*100 from AMORTIZATION_SCHEDULE e where e.LOANID=QUEST_APPLICATION.ID order by e.PAYMENT_DATE desc) else cast(((((ISNULL(FIN_AMT,0)*isnull(FIN_INT_RATE,0)/100)*isnull(FIN_TENOR,0))+isnull(FIN_AMT,0))/isnull(FIN_TENOR,1))*100  as numeric(18,2)) end) AS PREMIUMAMT, *,CONVERT(VARCHAR,'" & txtStartDate.Text & "',112) as SSBStart,CONVERT(VARCHAR,'" & txtEndDate.Text & "',112) as SSBEnd from QUEST_APPLICATION where (SSB_FileNo=0 or SSB_FileNo is null) and FIN_TENOR<>0 and FIN_AMT<>0 and SUB_INDIVIDUAL='SSB' and SSB_FILE_TYPE is NOT NULL and SSB_FILE_TYPE in ('" & f_type & "') and isnull(ssbDeletionApproved,0)<>1 order by ID asc", con)
                    cmd = New SqlCommand("select DATEADD(m, DATEDIFF(m, 0, FIN_REPAY_DATE), 0) as newdate,(case when isnull(LoanExtension,'')='EXTENSION' then (select top 1 CONVERT(VARCHAR(24),e.payment_DATE,112) from AMORTIZATION_SCHEDULE e where e.LOANID=QUEST_APPLICATION.ID order by e.PAYMENT_DATE desc) ELSE CONVERT(VARCHAR(24),DATEADD(s,-1,DATEADD(mm, DATEDIFF(m,0,dateadd(mm,FIN_TENOR-1,FIN_REPAY_DATE))+1,0)),112) END) as FINENDDATE,(select top 1 convert(numeric(18,2),e.payment) from AMORTIZATION_SCHEDULE e where e.LOANID=QUEST_APPLICATION.ID order by e.PAYMENT_DATE desc) AS PREMIUMAMT, *,CONVERT(VARCHAR,'" & txtStartDate.Text & "',112) as SSBStart,CONVERT(VARCHAR,'" & txtEndDate.Text & "',112) as SSBEnd from QUEST_APPLICATION where (SSB_FileNo=0 or SSB_FileNo is null) and FIN_TENOR<>0 and FIN_AMT<>0 and SUB_INDIVIDUAL='SSB' and SSB_FILE_TYPE is NOT NULL and SSB_FILE_TYPE in ('" & f_type & "') and isnull(ssbDeletionApproved,0)<>1 order by ID asc", con)
                Else
                    'cmd = New SqlCommand("select DATEADD(m, DATEDIFF(m, 0, FIN_REPAY_DATE), 0) as newdate,(case when isnull(LoanExtension,'')='EXTENSION' then (select top 1 CONVERT(VARCHAR(24),e.payment_DATE,112) from AMORTIZATION_SCHEDULE e where e.LOANID=QUEST_APPLICATION.ID order by e.PAYMENT_DATE desc) ELSE CONVERT(VARCHAR(24),DATEADD(s,-1,DATEADD(mm, DATEDIFF(m,0,dateadd(mm,FIN_TENOR-1,FIN_REPAY_DATE))+1,0)),112) END) as FINENDDATE,(case when isnull(LoanExtension,'')='EXTENSION' then (select top 1 convert(numeric(18,2),e.payment)*100 from AMORTIZATION_SCHEDULE e where e.LOANID=QUEST_APPLICATION.ID order by e.PAYMENT_DATE desc) else cast(((((ISNULL(FIN_AMT,0)*isnull(FIN_INT_RATE,0)/100)*isnull(FIN_TENOR,0))+isnull(FIN_AMT,0))/isnull(FIN_TENOR,1))*100  as numeric(18,2)) end) AS PREMIUMAMT, *,CONVERT(VARCHAR,'" & txtStartDate.Text & "',112) as SSBStart,CONVERT(VARCHAR,'" & txtEndDate.Text & "',112) as SSBEnd from QUEST_APPLICATION where (SSB_FileNo=0 or SSB_FileNo is null) and FIN_TENOR<>0 and FIN_AMT<>0 and SUB_INDIVIDUAL='SSB' and STATUS = 'SSB Approval' AND isnull(FILE_SENT_TOSSB,0) <>1 and SSB_FILE_TYPE is NOT NULL and SSB_FILE_TYPE in ('" & f_type & "') order by ID asc", con)
                    'cmd = New SqlCommand("select DATEADD(m, DATEDIFF(m, 0, FIN_REPAY_DATE), 0) as newdate,(case when isnull(LoanExtension,'')='EXTENSION' then (select top 1 CONVERT(VARCHAR(24),e.payment_DATE,112) from AMORTIZATION_SCHEDULE e where e.LOANID=QUEST_APPLICATION.ID order by e.PAYMENT_DATE desc) ELSE CONVERT(VARCHAR(24),DATEADD(s,-1,DATEADD(mm, DATEDIFF(m,0,dateadd(mm,FIN_TENOR-1,FIN_REPAY_DATE))+1,0)),112) END) as FINENDDATE,(select top 1 convert(numeric(18,2),e.payment) from AMORTIZATION_SCHEDULE e where e.LOANID=QUEST_APPLICATION.ID order by e.PAYMENT_DATE desc) AS PREMIUMAMT, *,CONVERT(VARCHAR,'" & txtStartDate.Text & "',112) as SSBStart,CONVERT(VARCHAR,'" & txtEndDate.Text & "',112) as SSBEnd from QUEST_APPLICATION where (SSB_FileNo=0 or SSB_FileNo is null) and FIN_TENOR<>0 and FIN_AMT<>0 and SUB_INDIVIDUAL='SSB' and STATUS = 'SSB Approval' AND isnull(FILE_SENT_TOSSB,0) <>1 and SSB_FILE_TYPE is NOT NULL and SSB_FILE_TYPE in ('" & f_type & "') order by ID asc", con)
                    cmd = New SqlCommand("select DATEADD(m, DATEDIFF(m, 0, FIN_REPAY_DATE), 0) as newdate,(case when isnull(LoanExtension,'')='EXTENSION' then (select top 1 CONVERT(VARCHAR(24),e.payment_DATE,112) from AMORTIZATION_SCHEDULE e where e.LOANID=QUEST_APPLICATION.ID order by e.PAYMENT_DATE desc) ELSE CONVERT(VARCHAR(24),DATEADD(s,-1,DATEADD(mm, DATEDIFF(m,0,dateadd(mm,FIN_TENOR-1,FIN_REPAY_DATE))+1,0)),112) END) as FINENDDATE,(select top 1 convert(numeric(18,2),e.payment) from AMORTIZATION_SCHEDULE e where e.LOANID=QUEST_APPLICATION.ID order by e.PAYMENT_DATE desc) AS PREMIUMAMT, *,CONVERT(VARCHAR,'" & txtStartDate.Text & "',112) as SSBStart,CONVERT(VARCHAR,'" & txtEndDate.Text & "',112) as SSBEnd from QUEST_APPLICATION where (SSB_FileNo=0 or SSB_FileNo is null) and FIN_TENOR<>0 and FIN_AMT<>0 and SUB_INDIVIDUAL='SSB' AND isnull(FILE_SENT_TOSSB,0) <>1 and SSB_FILE_TYPE is NOT NULL and SSB_FILE_TYPE in ('" & f_type & "') order by ID asc", con)
                End If
                Dim ds As New DataSet
                adp = New SqlDataAdapter(cmd)
                adp.Fill(ds, "QUEST_APPLICATION")
                If ds.Tables(0).Rows.Count > 0 Then
                    Dim totRec As Integer = 0
                    Dim totamt As Double = 0
                    For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                        transactionType = "DED"
                        ECNO = ds.Tables(0).Rows(i).Item("ECNO").ToString & ds.Tables(0).Rows(i).Item("CD").ToString.ToLower
                        accno = "800081353"
                        membershipNo = "CF" & ds.Tables(0).Rows(i).Item("ID").ToString
                        NIDNO = ds.Tables(0).Rows(i).Item("IDNO").ToString.Replace("-", "")
                        NIDNO = NIDNO.Replace(" ", "").ToLower
                        Amt = Val(ds.Tables(0).Rows(i).Item("PREMIUMAMT"))
                        filetype = ds.Tables(0).Rows(i).Item("SSB_FILE_TYPE").ToString
                        Dim b As String = transactionType
                        '  Dim datLastDay As Date = GetLastDayOfMonth(3, 2016)
                        '  Dim FINENDDATE As Date = GetLastDayOfMonth(CDate(ds.Tables(0).Rows(i).Item("FIN_REPAY_DATE")).AddMonths(CInt(ds.Tables(0).Rows(i).Item("FIN_TENOR")) - 1).Month, CDate(ds.Tables(0).Rows(i).Item("FIN_REPAY_DATE")).AddMonths(CInt(ds.Tables(0).Rows(i).Item("FIN_TENOR"))).Year)
                        'Dim FINENDDATE As String = CStr(ds.Tables(0).Rows(i).Item("FINENDDATE"))
                        Dim FINENDDATE As String = CDate(ds.Tables(0).Rows(i).Item("SSBEnd")).ToString("yyyyMMdd")
                        'Dim StartDatet As String = CDate(ds.Tables(0).Rows(i).Item("newdate")).ToString("yyyyMMdd") & FINENDDATE
                        'Dim StartDatet As String = "2016120120181130"
                        Dim StartDatet As String = CDate(ds.Tables(0).Rows(i).Item("SSBStart")).ToString("yyyyMMdd") & FINENDDATE
                        Dim c As String = String.Format("{0,-8}", ECNO)
                        Dim d As String = String.Format("{0,-9}", accno)
                        Dim e As String = String.Format("{0,-12}", membershipNo)
                        Dim f As String = String.Format("{0,-15}", NIDNO)
                        Dim g As String = String.Format("{0,-16}", StartDatet)
                        Dim p As String = filetype
                        Dim h As String = Format(Amt, "0000000000000000")
                        lineDetails = b & c & p & d & e & g & f & h
                        'header = header + details
                        ' sr.WriteLine(lineDetails)
                        csv += vbCr & vbLf
                        csv += lineDetails
                        totamt = totamt + Amt
                    Next

                    totRec = ds.Tables(0).Rows.Count
                    Dim j As String = Format(ds.Tables(0).Rows.Count, "000000")
                    ' Dim k As String = Format(getTotalAmt(), "000000000000000000")
                    Dim k As String = Format(totamt, "000000000000000000")
                    Dim spx As String = Space(32)
                    trailer = trailerID & j & k & spx
                    csv += vbCr & vbLf
                    csv += trailer
                    csv += vbCr & vbLf
                    ' sr.WriteLine(trailer)
                    '   msgbox("File created")
                    ' sr.Close()
                    If f_type = "d" Then
                        updateSentTOSSB_del(GetFileNo)
                    Else
                        updateSentTOSSB(GetFileNo)
                    End If
                    'updateSentTOSSB(GetFileNo)
                    Dim filenammm As String = "ssb81353.ins"
                    Response.Clear()
                    Response.Buffer = True
                    Response.AddHeader("content-disposition", "attachment;filename*=UTF-8''" + Uri.EscapeDataString(filenammm))
                    Response.Charset = ""
                    Response.ContentType = "application/notepad"
                    Response.Headers.Set(filenammm, filenammm)
                    Response.Output.Write(csv)
                    Response.Flush()
                    Response.End()
                Else
                    msgbox("No Applications Ready for SSB")
                    Exit Sub
                End If
            Catch ex As Exception
                msgbox(ex.Message)
            End Try
        Catch ex As Exception

        End Try
    End Sub
    Protected Function GetFileNo() As Long
        Dim F_No As Long
        Dim cmd As SqlCommand
        Dim adp As SqlDataAdapter
        cmd = New SqlCommand("select max(isnull(SSB_FileNo,0))+1 as NextFileNo from QUEST_APPLICATION", con)
        Dim ds As New DataSet
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "QUEST_APPLICATION")
        If ds.Tables(0).Rows.Count > 0 Then
            F_No = CLng(ds.Tables(0).Rows(0).Item("NextFileNo"))
        Else
            F_No = 1
        End If
        Return F_No
    End Function
    Protected Sub updateSentTOSSB_del(ByVal FileNo As Long)
        Try
            'cmd = New SqlCommand("update QUEST_APPLICATION set FILE_SENT_TOSSB=1,SSB_FileNo='" & FileNo & "',SSB_TO=GETDATE(),SSB_GENERATOR='" & Session("Userid") & "' where SSB_FileNo=0 and FIN_TENOR<>0 and FIN_AMT<>0 and SUB_INDIVIDUAL='SSB' and SSB_FILE_TYPE is NOT NULL and SSB_FILE_TYPE in ('d') and isnull(ssbDeletionApproved,0)<>1 and SSB_FileNo=0", con)
            cmd = New SqlCommand("update QUEST_APPLICATION set FILE_SENT_TOSSB=1,SSB_FileNo='" & FileNo & "',SSB_TO=GETDATE(),SSB_GENERATOR='" & Session("Userid") & "' where (SSB_FileNo=0 or SSB_FileNo is null) and FIN_TENOR<>0 and FIN_AMT<>0 and SUB_INDIVIDUAL='SSB' and STATUS = 'SSB Approval' and SSB_FILE_TYPE is NOT NULL and SSB_FILE_TYPE in ('d') and isnull(ssbDeletionApproved,0)<>1 and SSB_FileNo=0", con)
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub updateSentTOSSB(ByVal FileNo As Long)
        Try
            'cmd = New SqlCommand("update QUEST_APPLICATION set FILE_SENT_TOSSB=1,SSB_FileNo='" & FileNo & "',SSB_TO=GETDATE(),SSB_GENERATOR='" & Session("Userid") & "' where SSB_FileNo=0 and FIN_TENOR<>0 and FIN_AMT<>0 and SUB_INDIVIDUAL='SSB' and STATUS LIKE'APPROVE%' AND isnull(FILE_SENT_TOSSB,0) <>1 and SSB_FILE_TYPE is NOT NULL", con)
            cmd = New SqlCommand("update QUEST_APPLICATION set FILE_SENT_TOSSB=1,SSB_FileNo='" & FileNo & "',SSB_TO=GETDATE(),SSB_GENERATOR='" & Session("Userid") & "' where (SSB_FileNo=0 or SSB_FileNo is null) and FIN_TENOR<>0 and FIN_AMT<>0 and SUB_INDIVIDUAL='SSB' and STATUS = 'SSB Approval' AND isnull(FILE_SENT_TOSSB,0) <>1 and SSB_FILE_TYPE is NOT NULL", con)
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Function getTotalAmt() As Double
        Dim amt As Double
        Dim cmd As SqlCommand
        Dim adp As SqlDataAdapter
        cmd = New SqlCommand("select sum(((((ISNULL(FIN_AMT,0)*isnull(FIN_INT_RATE,0)/100)*isnull(FIN_TENOR,0))+isnull(FIN_AMT,0))/isnull(FIN_TENOR,1))*100) AS amt from QUEST_APPLICATION where FIN_TENOR<>0 and FIN_AMT<>0 and SUB_INDIVIDUAL='SSB' and STATUS LIKE 'APPROVE%' AND isnull(FILE_SENT_TOSSB,0) <>1 and SSB_FILE_TYPE is NOT NULL", con)
        Dim ds As New DataSet
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "CD")
        If ds.Tables(0).Rows.Count > 0 Then
            amt = Val(ds.Tables(0).Rows(0).Item("amt"))
        End If
        Return amt
    End Function
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Page.MaintainScrollPositionOnPostBack = True
        con = New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
        If Not IsPostBack Then

        End If
    End Sub
End Class