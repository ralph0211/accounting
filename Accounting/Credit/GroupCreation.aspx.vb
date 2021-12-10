
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports CreditManager
Imports ErrorLogging

Partial Class Credit_GroupCreation
    Inherits System.Web.UI.Page

    Protected Sub grdDocuments_RowDeleting(sender As Object, e As GridViewDeleteEventArgs) Handles grdDocuments.RowDeleting
        Dim docUploadEditID = DirectCast(grdDocuments.Rows(e.RowIndex).FindControl("txtDocId"), TextBox).Text
        Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
            Using cmd = New SqlCommand("delete from CUSTOMER_DOCUMENTS where ID='" & docUploadEditID & "'", con)
                If con.State = ConnectionState.Open Then
                    con.Close()
                End If
                con.Open()
                If cmd.ExecuteNonQuery Then
                    'lblAppUploadMsg.ForeColor = Drawing.Color.Green
                    'lblAppUploadMsg.Text = "Document successfully deleted"
                    notify("File has been deleted", "success")
                Else
                    'lblAppUploadMsg.ForeColor = Drawing.Color.Red
                    'lblAppUploadMsg.Text = "Error deleting document"
                    notify("Error deleting file", "error")
                End If
                con.Close()
                loadUploadedFiles(ViewState("CustNo"))
            End Using
        End Using
        'ClientScript.RegisterStartupScript(Me.GetType(), "HideLabel", "<script type=""text/javascript"">setTimeout(""document.getElementById('" & lblAppUploadMsg.ClientID & "').style.display='none'"",5000)</script>")
    End Sub

    Protected Sub grdDocuments_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles grdDocuments.RowCommand
        If e.CommandName = "Select" Then
            Dim docID = e.CommandArgument
            'lblDetailID.Text = docID
            'btnModalPopup.Visible = True
            Dim strscript As String

            strscript = "<script language=JavaScript>"
            strscript += "window.open('viewDocumentStatic.aspx?id=" & docID & "');"
            strscript += "</script>"
            'ClientScript.RegisterStartupScript(Me.GetType(), "HideLabel", "<script type=""text/javascript"">setTimeout(""document.getElementById('" & lblAppUploadMsg.ClientID & "').style.display='none'"",5000)</script>")
            ClientScript.RegisterStartupScript(Me.GetType(), "newwin", strscript)

        End If
    End Sub

    Protected Sub btnUploadApp_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUploadApp.Click
        Try
            If ViewState("CustNo") = "" Or IsDBNull(ViewState("CustNo")) Then
                notify("Save group membership first before uploading documentation", "error")
            Else
                Dim filePath As String = filAttachApp.PostedFile.FileName
            Dim filename As String = Path.GetFileName(filePath)
            Dim ext As String = Path.GetExtension(filename)
            Dim contenttype As String = String.Empty
            'Set the contenttype based on File Extension
            Select Case ext
                Case ".doc"
                    contenttype = "application/msword"
                    Exit Select
                Case ".docx"
                    contenttype = "application/msword"
                    Exit Select
                Case ".xls"
                    contenttype = "application/x-msexcel"
                    Exit Select
                Case ".xlsx"
                    contenttype = "application/x-msexcel"
                    Exit Select
                Case ".jpg"
                    contenttype = "image/jpg"
                    Exit Select
                Case ".png"
                    contenttype = "image/png"
                    Exit Select
                Case ".gif"
                    contenttype = "image/gif"
                    Exit Select
                Case ".pdf"
                    contenttype = "application/pdf"
                    Exit Select
            End Select

                If contenttype <> String.Empty Then
                    Dim fs As Stream = filAttachApp.PostedFile.InputStream
                    Dim br As New BinaryReader(fs)
                    Dim bytes As Byte() = br.ReadBytes(fs.Length)

                    'insert the file into database
                    Dim strQuery As String = "insert into CUSTOMER_DOCUMENTS" _
                    & "(CUST_NO, DOC_DESC, DOC_DATA, DOC_TYPE, DOC_EXT, DOC_FILENAME)" _
                    & " values (@CUST_NO,@DOC_DESC, @DOC_DATA,@DOC_TYPE,@DOC_EXT, @DOC_FILENAME)"
                    Dim cmd As New SqlCommand(strQuery)
                    cmd.Parameters.Add("@CUST_NO", SqlDbType.VarChar).Value = ViewState("CustNo")
                    'cmd.Parameters.Add("@LOAN_ID", SqlDbType.VarChar).Value = "" 'yet to be determined at this stage. Must be updated at form submit
                    cmd.Parameters.Add("@DOC_FILENAME", SqlDbType.VarChar).Value = filename
                    cmd.Parameters.Add("@DOC_DESC", SqlDbType.VarChar).Value = txtDocDesc.Text
                    cmd.Parameters.Add("@DOC_EXT", SqlDbType.VarChar).Value = ext
                    cmd.Parameters.Add("@DOC_TYPE", SqlDbType.VarChar).Value = contenttype
                    cmd.Parameters.Add("@DOC_DATA", SqlDbType.Binary).Value = bytes
                    If InsertUpdateData(cmd) Then
                        txtDocDesc.Text = ""
                        loadUploadedFiles(ViewState("CustNo"))
                        notify("File uploaded successfully", "success")
                    Else
                        notify("An error occurred while uploading the file", "error")
                    End If
                Else
                    notify("Select the file to upload", "error")
                End If
            End If
        Catch ex As Exception
            WriteLogFile(ex.ToString)
        End Try
    End Sub

    Protected Sub loadUploadedFiles(custNo As String)
        Try
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                'cmd = New SqlCommand("select * from CUSTOMER_DOCUMENTS where CUST_NO='" & custNo & "'", con)
                'Using cmd = New SqlCommand("select qd.*,pdt.DocType,pdt.id as [docTypeID] from paradocumenttypes pdt JOIN CUSTOMER_DOCUMENTS qd ON pdt.id=qd.DocumentTypeID and CUST_NO='" & custNo & "'", con)
                Using cmd = New SqlCommand("select qd.* from CUSTOMER_DOCUMENTS qd where CUST_NO='" & custNo & "'", con)
                    Dim ds As New DataSet
                    Using adp = New SqlDataAdapter(cmd)
                        adp.Fill(ds, "QD")
                    End Using
                    If ds.Tables(0).Rows.Count > 0 Then
                        grdDocuments.DataSource = ds.Tables(0)
                    Else
                        grdDocuments.DataSource = Nothing
                    End If
                    grdDocuments.DataBind()
                End Using
            End Using
        Catch ex As Exception
            WriteLogFile(ex.ToString)
        End Try
    End Sub

    Public Function InsertUpdateData(ByVal cmd As SqlCommand) As Boolean
        Dim strConnString As String = System.Configuration.ConfigurationManager.ConnectionStrings("conString").ConnectionString()
        Dim con As New SqlConnection(strConnString)
        cmd.CommandType = CommandType.Text
        cmd.Connection = con
        Try
            con.Open()
            cmd.ExecuteNonQuery()
            Return True
        Catch ex As Exception
            Response.Write(ex.ToString)
            Return False
        Finally
            con.Close()
            con.Dispose()
        End Try
    End Function

    'Protected Sub loadUploadedFiles(custNo As String)
    '    Try
    '        Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
    '            Using cmd = New SqlCommand("select * from QUEST_DOCUMENTS where CUST_NO='" & custNo & "' and (LOAN_ID='' or LOAN_ID is NULL)", con)
    '                Dim ds As New DataSet
    '                Using adp = New SqlDataAdapter(cmd)
    '                    adp.Fill(ds, "QD")
    '                End Using
    '                If ds.Tables(0).Rows.Count > 0 Then
    '                    grdDocuments.DataSource = ds.Tables(0)
    '                Else
    '                    grdDocuments.DataSource = Nothing
    '                End If
    '                grdDocuments.DataBind()
    '            End Using
    '        End Using
    '    Catch ex As Exception
    '        WriteLogFile(ex.ToString)
    '    End Try
    'End Sub

    Protected Sub getAllIndividuals()
        Try
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd = New SqlCommand("select *,ISNULL(FORENAMES,'')+' '+ISNULL(SURNAME,'') +' --- '+CUSTOMER_NUMBER as Name from CUSTOMER_DETAILS where CUSTOMER_TYPE='Individual'", con)
                    Dim ds As New DataSet
                    Using adp = New SqlDataAdapter(cmd)
                        adp.Fill(ds, "QD")
                    End Using
                    If ds.Tables(0).Rows.Count > 0 Then
                        cmbGrpMembers.DataSource = ds.Tables(0)
                        cmbGrpMembers.DataTextField = "Name"
                        cmbGrpMembers.DataValueField = "CUSTOMER_NUMBER"
                        loadCombo(ds.Tables(0), cmbChairperson, "Name", "CUSTOMER_NUMBER")
                    Else
                        cmbGrpMembers.DataSource = Nothing
                        cmbChairperson.DataSource = Nothing
                        cmbChairperson.DataBind()
                    End If
                    cmbGrpMembers.DataBind()
                End Using
            End Using
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- getAllIndividuals()", ex.ToString)
        End Try
    End Sub

    Private Sub Credit_GroupCreation_Load(sender As Object, e As EventArgs) Handles Me.Load
        Page.MaintainScrollPositionOnPostBack = True
        If Not IsPostBack Then
            getInternalControls()
            getAllIndividuals()
            getAllGroups()
        End If
    End Sub
    Protected Sub btnGrpDeclAdd_Click(sender As Object, e As EventArgs) Handles btnGrpDeclAdd.Click
        Try
            'save group info
            Dim newCustNo = generateCustNum()
            If lblGrpAccNo.Text = "" Then
                ViewState("CustNo") = newCustNo
                ViewState("IsSaved") = "0"
            Else
                ViewState("CustNo") = lblGrpAccNo.Text
                ViewState("IsSaved") = "1"
            End If
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                If ViewState("IsSaved") = "0" Then
                    Using cmd = New SqlCommand("insert into CUSTOMER_DETAILS (CUSTOMER_TYPE,SURNAME,FORENAMES,CUSTOMER_NUMBER,AccountSuffix) values (@CUSTOMER_TYPE,@SURNAME,@FORENAMES,@CUSTOMER_NUMBER,@AccountSuffix)", con)
                        cmd.Parameters.AddWithValue("@CUSTOMER_TYPE", "Group")
                        cmd.Parameters.AddWithValue("@SURNAME", txtGrpName.Text)
                        cmd.Parameters.AddWithValue("@FORENAMES", "")
                        cmd.Parameters.AddWithValue("@CUSTOMER_NUMBER", ViewState("CustNo"))
                        cmd.Parameters.AddWithValue("@AccountSuffix", ViewState("AccSuffix"))
                        con.Open()
                        cmd.ExecuteNonQuery()
                        lblGrpAccNo.Text = ViewState("CustNo")
                        con.Close()
                    End Using
                ElseIf ViewState("IsSaved") = "1" Then
                    Using cmd = New SqlCommand("update CUSTOMER_DETAILS set CUSTOMER_TYPE=@CUSTOMER_TYPE,SURNAME=@SURNAME,FORENAMES=@FORENAMES where CUSTOMER_NUMBER=@CUSTOMER_NUMBER", con)
                        cmd.Parameters.AddWithValue("@CUSTOMER_TYPE", "Group")
                        cmd.Parameters.AddWithValue("@SURNAME", txtGrpName.Text)
                        cmd.Parameters.AddWithValue("@FORENAMES", "")
                        cmd.Parameters.AddWithValue("@CUSTOMER_NUMBER", ViewState("CustNo"))
                        con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    End Using
                End If

                Using cmd = New SqlCommand("delete from GroupMembership where GroupAccNo=@GroupAccNo", con)
                    cmd.Parameters.AddWithValue("@GroupAccNo", ViewState("CustNo"))
                    con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                End Using

                Using cmd = New SqlCommand("insert into GroupMembership (GroupAccNo,MemberAccNo,MemberType) values (@GroupAccNo,@MemberAccNo,@MemberType)", con)
                    cmd.Parameters.AddWithValue("@GroupAccNo", ViewState("CustNo"))
                    cmd.Parameters.AddWithValue("@MemberAccNo", cmbChairperson.SelectedValue)
                    cmd.Parameters.AddWithValue("@MemberType", "Chairperson")
                    con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                End Using
                For Each row As ListItem In cmbGrpMembers.Items
                    If row.Selected Then
                        Using cmd = New SqlCommand("insert into GroupMembership (GroupAccNo,MemberAccNo,MemberType) values (@GroupAccNo,@MemberAccNo,@MemberType)", con)
                            cmd.Parameters.AddWithValue("@GroupAccNo", ViewState("CustNo"))
                            cmd.Parameters.AddWithValue("@MemberAccNo", row.Value)
                            cmd.Parameters.AddWithValue("@MemberType", "Member")
                            con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()
                        End Using
                    End If
                Next
                notify("Group information saved", "success")
                getAllGroups()
            End Using
            'save group members
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- btnGrpDeclAdd_Click()", ex.ToString)
        End Try
    End Sub
    Protected Function generateCustNum() As String
        Try
            Dim custNo As String = "0"
            Dim prefLen = ViewState("AccountPrefix").ToString.Length
            Dim sepLen = ViewState("AccountSeparator").ToString.Length
            If ViewState("AccountSuffixOption") = "Auto" Then
                Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                    Using cmd = New SqlCommand("select isnull(max(convert(numeric, AccountSuffix)),0) from CUSTOMER_DETAILS", con)
                        If con.State = ConnectionState.Open Then
                            con.Close()
                        End If
                        con.Open()
                        custNo = cmd.ExecuteScalar() + 1
                        con.Close()
                        If IsDBNull(custNo) Or custNo = 0 Then 'Or custNo = 1
                            custNo = ViewState("AccountSeed").ToString().PadLeft(ViewState("SuffixLength"), "0")
                        End If
                    End Using
                End Using
                'Return ViewState("AccountPrefix").ToString & ViewState("AccountSeparator").ToString & custNo.ToString().PadLeft(ViewState("SuffixLength"), "0")
            ElseIf ViewState("AccountSuffixOption") = "Random" Then
                Dim ran As New Random
                custNo = CInt(ran.NextDouble * 10 ^ ViewState("SuffixLength"))
                Do While Not isUniqueSuffix(custNo)
                Loop
                custNo = CInt(ran.NextDouble * 10 ^ ViewState("SuffixLength"))
            End If
            ViewState("AccSuffix") = custNo.ToString.PadLeft(ViewState("SuffixLength"), "0")
            Return ViewState("AccountPrefix").ToString & ViewState("AccountSeparator").ToString & custNo.ToString().PadLeft(ViewState("SuffixLength"), "0")
        Catch ex As Exception
            msgbox(ex.ToString)
            Return "2".ToString().PadLeft(5, "0")
        End Try
    End Function

    Protected Function isUniqueSuffix(suff As String) As Boolean
        Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
            Using cmd = New SqlCommand("select ID from CUSTOMER_DETAILS where AccountSuffix='" & suff & "'", con)
                Dim ds As New DataSet
                Using adp = New SqlDataAdapter(cmd)
                    adp.Fill(ds, "CD")
                End Using
                If ds.Tables(0).Rows.Count > 0 Then
                    Return False
                Else
                    Return True
                End If
            End Using
        End Using
    End Function

    Protected Sub getInternalControls()
        Try
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd = New SqlCommand("select * from [ParaInternalControls]", con)
                    Dim ds As New DataSet
                    Dim adp = New SqlDataAdapter(cmd)
                    adp.Fill(ds, "cntrl")
                    If ds.Tables(0).Rows.Count > 0 Then
                        Dim dr = ds.Tables(0).Rows(0)
                        ViewState("AccountPrefix") = dr("AccountPrefix")
                        ViewState("AccountSeparator") = dr("AccountSeparator")
                        ViewState("AccountSuffixOption") = dr("AccountSuffixOption")
                        ViewState("SuffixLength") = dr("SuffixLength")
                        ViewState("AccountSeed") = dr("AccountSeed")
                    End If
                End Using
            End Using
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- getInternalControls()", ex.ToString)
        End Try
    End Sub

    Protected Sub getAllGroups()
        Try
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd = New SqlCommand("select ID,CUSTOMER_NUMBER as [Group Account No.],SURNAME as [Group Name] from [CUSTOMER_DETAILS] where CUSTOMER_TYPE='Group'", con)
                    Dim ds As New DataSet
                    Dim adp = New SqlDataAdapter(cmd)
                    adp.Fill(ds, "cntrl")
                    bindGrid(ds.Tables(0), grdGroup)
                End Using
            End Using
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- getInternalControls()", ex.ToString)
        End Try
    End Sub

    Private Sub grdGroup_SelectedIndexChanged(sender As Object, e As EventArgs) Handles grdGroup.SelectedIndexChanged
        Try
            Dim custNo = grdGroup.SelectedRow.Cells(2).Text
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd As New SqlCommand("select *,isnull(FORENAMES,'')+' '+isnull(SURNAME,'') as Name from GroupMembership gm JOIN CUSTOMER_DETAILS cd on gm.MemberAccNo=CD.CUSTOMER_NUMBER WHERE gm.GroupAccNo=@gAcc", con)
                    cmd.Parameters.AddWithValue("@gAcc", custNo)
                    Dim dt As New DataTable
                    Using adp As New SqlDataAdapter(cmd)
                        adp.Fill(dt)
                    End Using
                    'If dt.Rows.Count > 0 Then
                    '    For Each row As DataRow In dt.Rows
                    '        If row("MemberType") = "Chairperson" Or row("MemberType") = "Chairman" Then
                    '            cmbChairperson.SelectedValue = row("CUSTOMER_NUMBER")
                    '        Else
                    '            cmbGrpMembers.SelectedValue = row("CUSTOMER_NUMBER")
                    '            'If lblGrpMembers.Text = "" Then
                    '            '    lblGrpMembers.Text = lblGrpMembers.Text + row("FORENAMES") + " " + row("SURNAME")
                    '            'Else
                    '            '    lblGrpMembers.Text = lblGrpMembers.Text + ", " + row("FORENAMES") + " " + row("SURNAME")
                    '            'End If
                    '        End If
                    '    Next
                    '    'repGrpMembers.DataSource = dt
                    '    'repGrpMembers.DataBind()
                    'End If
                    cmbGrpMembers.ClearSelection()

                    If dt.Rows.Count > 0 Then
                        For Each mem As ListItem In cmbGrpMembers.Items
                            Dim memVal = mem.Value
                            For Each rowMember As DataRow In dt.Rows
                                If rowMember("MemberType") = "Chairperson" Or rowMember("MemberType") = "Chairman" Then
                                    cmbChairperson.SelectedValue = rowMember("CUSTOMER_NUMBER")
                                Else
                                    Try
                                        If memVal = rowMember.Item("CUSTOMER_NUMBER") Then
                                            mem.Selected = True
                                        End If
                                    Catch ex As Exception
                                    End Try
                                End If
                            Next
                        Next
                    End If
                    getGroupDetails(custNo)

                End Using
            End Using
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- grdGroup_SelectedIndexChanged()", ex.ToString)
        End Try
    End Sub

    Protected Sub getGroupDetails(custNo As String)
        Try
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd As New SqlCommand("select * from CUSTOMER_DETAILS where CUSTOMER_NUMBER=@gAcc", con)
                    cmd.Parameters.AddWithValue("@gAcc", custNo)
                    Dim dt As New DataTable
                    Using adp As New SqlDataAdapter(cmd)
                        adp.Fill(dt)
                    End Using
                    If dt.Rows.Count > 0 Then
                        txtGrpName.Text = dt.Rows(0).Item("SURNAME")
                        lbl.Visible = True
                        lblGrpAccNo.Text = custNo
                        loadUploadedFiles(custNo)
                    End If
                End Using
            End Using
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- getGroupDetails()", ex.ToString)
        End Try
    End Sub
    Protected Sub btnActivateGrp_Click(sender As Object, e As EventArgs) Handles btnActivateGrp.Click
        Try

        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- btnActivateGrp_Click()", ex.ToString)
        End Try
    End Sub
End Class
