Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports SecureBank
Imports CreditManager
Imports ErrorLogging

Partial Class Branches
    Inherits System.Web.UI.Page
    Dim adp As New SqlDataAdapter
    Dim cmd As SqlCommand
    Dim con As New SqlConnection
    Dim connection As String
    Dim urlPermission As String = "PermissionDenied.aspx"
    Public Sub insertData()
        Try
            Dim bankCode = cmbBanks.SelectedValue
            Dim bankName = cmbBanks.SelectedItem.Text
            Dim fd As New DataSet
            fd = GetData()
            Dim rowcount = fd.Tables(0).Rows.Count
            Dim colcount = fd.Tables(0).Columns.Count
            For i = 0 To rowcount - 1
                'msgbox(fd.Tables(0).Rows(i).Item(6).ToString)
                Dim branchCode = Trim(removeNULL(fd, i, 0))
                Dim branchName = Trim(removeNULL(fd, i, 2))
                Dim closureDate = Trim(removeNULL(fd, i, 4))
                Dim status = getStatus(Trim(removeNULL(fd, i, 6)))
                cmd = New SqlCommand()
                cmd.Connection = con
                If isUniqueCode(branchCode) Then
                    cmd.CommandText = "insert into BANK_BNCH_DETAILS(BNK_CODE,BNK_NAME,BNCH_CODE,BNCH_NAME,ACTIVE,CLOSURE_DATE) values ('39','','" & branchCode & "','" & branchName & "'," & status & ",'" & closureDate & "')"
                Else
                    cmd.CommandText = "update BANK_BNCH_DETAILS set BNCH_NAME='" & branchName & "',ACTIVE=" & status & ",CLOSURE_DATE='" & closureDate & "' where BNK_CODE='39' and BNCH_CODE='" & branchCode & "')"
                End If

                If con.State = ConnectionState.Open Then
                    con.Close()
                End If
                con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Next
            notify("Import successful", "success")
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- insertData()", ex.ToString)
        End Try
    End Sub

    Protected Sub btnAddBranch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddBranch.Click
        Try
            Dim cmdIMPIns = New SqlCommand("insert into BNCH_DETAILS (BNK_CODE,BNK_NAME,BNCH_CODE,BNCH_NAME,BNCH_ADDRESS,BNCH_PHONENO,ACTIVE) values ('39','','" & txtBranchCode.Text & "','" & BankString.removeSpecialCharacter(txtBranchName.Text) & "','" & BankString.removeSpecialCharacter(txtBranchAddress.Text) & "','" & txtPhoneNumber.Text & "',1)", con)
            Dim cmdAudit As SqlCommand
            cmdAudit = New SqlCommand("insert into TEMP_BNCH_DETAILS ([ACTION],[PERFORMED_BY],[PERFORMED_DATE],BNK_CODE,BNK_NAME,[BNCH_CODE],[BNCH_NAME],[BNCH_ADDRESS],[BNCH_PHONENO],[BNCH_FAXNO]) values ('INSERT','" & Session("UserID") & "',getDate(),'39','" & BankString.removeSpecialCharacter("") & "','" & txtBranchCode.Text & "','" & BankString.removeSpecialCharacter(txtBranchName.Text) & "','" & BankString.removeSpecialCharacter(txtBranchAddress.Text) & "','" & txtPhoneNumber.Text & "','')", con)
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            con.Open()
            If isUniqueCode(txtBranchCode.Text) Then
                'If cmdIns.ExecuteNonQuery Then
                cmdAudit.ExecuteNonQuery()
                cmdIMPIns.ExecuteNonQuery()
                msgbox("Branch successfully saved")
                recordAction("btnAddBranch", "Saved branch: " & txtBranchCode.Text & " - " & txtBranchName.Text)
                clearAll()
                getBranches()
            Else
                msgbox("A branch with this code already exists")
                txtBranchCode.Focus()
            End If
            con.Close()
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- btnAddBranch_Click()", ex.ToString)
        End Try
    End Sub

    Protected Sub btnUploadBranches_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUploadBranches.Click
        Try
            insertData()
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- btnUploadBranches_Click()", ex.ToString)
        End Try
    End Sub

    Protected Sub clearAll()
        Try
            txtBranchAddress.Text = ""
            txtBranchCode.Text = ""
            txtBranchName.Text = ""
            txtPhoneNumber.Text = ""
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- clearAll()", ex.ToString)
        End Try
    End Sub

    Protected Sub cmbBanks_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbBanks.SelectedIndexChanged
        getBranches()
    End Sub

    Protected Sub cmbBrBank_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbBrBank.SelectedIndexChanged
        Try
            getBranches()
            lblBankCode.Text = cmbBrBank.SelectedValue
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub getBranches()
        Try
            Using cmd = New SqlCommand("select [ID],[BNCH_CODE],[BNCH_NAME],[BNCH_ADDRESS],[BNCH_PHONENO],[BNCH_FAXNO],ISNULL([ACTIVE],1) as [ACTIVE],[CLOSURE_DATE] from BNCH_DETAILS order by BNCH_NAME", con)
                Dim ds As New DataSet
                adp = New SqlDataAdapter(cmd)
                adp.Fill(ds, "Category")
                If ds.Tables(0).Rows.Count > 0 Then
                    grdBranches.DataSource = ds.Tables(0)
                Else
                    grdBranches.DataSource = Nothing
                End If
                grdBranches.DataBind()
            End Using
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- getBranches()", ex.ToString)
        End Try
    End Sub
    Protected Function getStatus(ByVal stt As String) As Integer
        If stt = "Stopped" Then
            Return 0
        ElseIf stt = "Open" Then
            Return 1
        Else
            Return 1
        End If
    End Function

    Protected Sub grdBranches_RowCancelingEdit(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles grdBranches.RowCancelingEdit
        grdBranches.EditIndex = -1
        getBranches()
    End Sub

    Protected Sub grdBranches_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles grdBranches.RowDeleting
        Try
            ViewState("branchEditID") = DirectCast(grdBranches.Rows(e.RowIndex).FindControl("txtOldBranchCode"), TextBox).Text
            ViewState("branchID") = DirectCast(grdBranches.Rows(e.RowIndex).FindControl("txtbranchID"), TextBox).Text

            Dim cmdSelect = New SqlCommand("select * from BNCH_DETAILS where id='" & ViewState("branchID") & "'", con)
            Dim dsSelect As New DataSet
            Dim adpSel = New SqlDataAdapter(cmdSelect)
            adpSel.Fill(dsSelect, "BRANCH")

            Dim cmdAudit As SqlCommand
            cmdAudit = New SqlCommand("insert into TEMP_BNCH_DETAILS ([ACTION],[PERFORMED_BY],[PERFORMED_DATE],[BNK_CODE],[BNK_NAME],[BNCH_CODE],[BNCH_NAME],[BNCH_ADDRESS],[BNCH_PHONENO],[BNCH_FAXNO],[BNCH_ID]) values ('DELETE','" & Session("UserID") & "',getDate(),'','" & BankString.removeSpecialCharacter(isNullValue(dsSelect.Tables(0).Rows(0).Item("BNK_NAME"))) & "','" & isNullValue(dsSelect.Tables(0).Rows(0).Item("BNCH_CODE")) & "','" & BankString.removeSpecialCharacter(dsSelect.Tables(0).Rows(0).Item("BNCH_NAME")) & "','','','','" & ViewState("branchID") & "')", con)

            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            con.Open()
            If cmdAudit.ExecuteNonQuery Then
                notify("Successfully marked for deletion. Authorization pending.", "success")
            Else
                notify("Error deleting", "error")
            End If
            con.Close()
            getBranches()

        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- grdBranches_RowDeleting()", ex.ToString)
        End Try
    End Sub

    Protected Sub grdBranches_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles grdBranches.RowEditing
        Try
            ViewState("branchID") = DirectCast(grdBranches.Rows(e.NewEditIndex).FindControl("txtbranchID"), TextBox).Text
            ViewState("branchEditID") = DirectCast(grdBranches.Rows(e.NewEditIndex).FindControl("txtOldBranchCode"), TextBox).Text
            grdBranches.EditIndex = e.NewEditIndex
            getBranches()
            Dim chk1 As New CheckBox
            chk1 = DirectCast(grdBranches.Rows(e.NewEditIndex).FindControl("chkStatusEdit"), CheckBox)
            Dim chkValue As String
            chkValue = DirectCast(grdBranches.Rows(e.NewEditIndex).FindControl("txtStatusEdit"), TextBox).Text
            chk1.Checked = chkValue

        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- grdBranches_RowEditing()", ex.ToString)
        End Try
    End Sub

    Protected Sub grdBranches_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles grdBranches.RowUpdating
        Try
            If Trim(ViewState("branchEditID")) = "" Or IsDBNull(ViewState("branchEditID")) Then
                msgbox("No record selected for update")
                Exit Sub
            End If
            Dim bnchCode As String = DirectCast(grdBranches.Rows(e.RowIndex).FindControl("txtGrdBranchCode"), TextBox).Text
            Dim bnchName As String = DirectCast(grdBranches.Rows(e.RowIndex).FindControl("txtBranchNameEdit"), TextBox).Text
            Dim bnchAddress As String = DirectCast(grdBranches.Rows(e.RowIndex).FindControl("txtBranchAddressEdit"), TextBox).Text
            'msgbox("here")

            Dim bnchPhone As String = DirectCast(grdBranches.Rows(e.RowIndex).FindControl("txtBranchPhoneEdit"), TextBox).Text
            Dim chkStatus As CheckBox = DirectCast(grdBranches.Rows(e.RowIndex).FindControl("chkStatusEdit"), CheckBox)

            Dim oldBnchCode, oldBnchName, oldBnchAddress, oldBnchPhone, oldBnchFax As String
            oldBnchCode = ""
            oldBnchName = ""
            oldBnchAddress = ""
            oldBnchPhone = ""
            oldBnchFax = ""

            cmd = New SqlCommand("select * from BNCH_DETAILS where id='" & ViewState("branchID") & "'", con)
            Dim ds1 As New DataSet
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds1, "DETAILS")
            If ds1.Tables(0).Rows.Count > 0 Then
                oldBnchCode = ds1.Tables(0).Rows(0).Item("BNCH_CODE").ToString
                oldBnchName = ds1.Tables(0).Rows(0).Item("BNCH_NAME").ToString
                oldBnchAddress = ds1.Tables(0).Rows(0).Item("BNCH_ADDRESS").ToString
                oldBnchPhone = ds1.Tables(0).Rows(0).Item("BNCH_PHONENO").ToString
                oldBnchFax = ds1.Tables(0).Rows(0).Item("BNCH_FAXNO").ToString
            End If

            Dim cmdAudit As SqlCommand
            cmdAudit = New SqlCommand("insert into TEMP_BNCH_DETAILS ([ACTION],[PERFORMED_BY],[PERFORMED_DATE],[OLD_BNCH_CODE],[BNCH_CODE],[OLD_BNCH_NAME],[BNCH_NAME],[OLD_BNCH_ADDRESS],[BNCH_ADDRESS],[OLD_BNCH_PHONENO],[BNCH_PHONENO],[OLD_BNCH_FAXNO],[BNCH_FAXNO],[BNCH_ID]) values ('UPDATE','" & Session("UserID") & "',getDate(),'" & oldBnchCode & "','" & bnchCode & "',@oldBnchName,@bnchName,@oldBnchAddress,@bnchAddress,'" & oldBnchPhone & "','" & bnchPhone & "','" & oldBnchFax & "','','" & ViewState("branchID") & "')", con)
            cmdAudit.Parameters.AddWithValue("@oldBnchName", oldBnchName)
            cmdAudit.Parameters.AddWithValue("@oldBnchAddress", oldBnchAddress)
            cmdAudit.Parameters.AddWithValue("@bnchName", bnchName)
            cmdAudit.Parameters.AddWithValue("@bnchAddress", bnchAddress)
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            con.Open()
            If cmdAudit.ExecuteNonQuery Then
                notify("Successfully marked for update. Authorization pending", "success")
                recordAction("grdBranches_RowUpdating", "Updated branch: " & bnchCode & " - " & bnchName)
            Else
                notify("Error updating value", "error")
            End If
            con.Close()
            grdBranches.EditIndex = -1
            getBranches()

        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- grdBranches_RowUpdating()", ex.ToString)
        End Try
    End Sub

    Protected Sub grdBranches_SelectedIndexChanged(sender As Object, e As EventArgs) Handles grdBranches.SelectedIndexChanged

    End Sub

    Protected Function isNullValue(str As String) As String
        Try
            If IsDBNull(str) Then
                Return ""
            Else
                Return str
            End If
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Protected Function isUniqueCode(ByVal bnchCode As String) As Boolean
        Try
            'cmd = New SqlCommand("select * from BNCH_DETAILS where BNCH_CODE='" & bnchCode & "' and BNK_NAME='" & cmbBrBank.SelectedItem.Text & "'", con)
            cmd = New SqlCommand("select * from BNCH_DETAILS where BNCH_CODE='" & bnchCode & "'", con)
            Dim ds As New DataSet
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "BRANCHES")
            If ds.Tables(0).Rows.Count > 0 Then
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- isUniqueCode()", ex.ToString)
            Return True
        End Try
    End Function

    Protected Sub loadBanks(cmbBank As DropDownList)
        Try
            cmd = New SqlCommand("select * from BANK_DETAILS", con)
            Dim ds As New DataSet
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "BANK")
            CreditManager.loadCombo(ds.Tables(0), cmbBank, "BANK_NAME", "BANK_CODE")
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- loadBanks()", ex.ToString)
        End Try
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            con = New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
            Page.MaintainScrollPositionOnPostBack = True
            If Not IsPostBack Then
                loadBanks(cmbBanks)
                loadBanks(cmbBrBank)
                getBranches()
            End If
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- Page_Load()", ex.ToString)
        End Try
    End Sub
    Private Function GetData() As DataSet
        'msgbox(Server.MapPath(FileUpload1.FileName).ToString)
        'Exit Function
        Dim strLine As String
        Dim strArray() As String
        Dim charArray() As Char = {","c}
        Dim ds As New DataSet()
        Dim dt As DataTable = ds.Tables.Add("TheData")
        filUploadBranches.SaveAs(Server.MapPath("BranchUploads/" & filUploadBranches.FileName))
        Dim aFile As New FileStream(Server.MapPath("BranchUploads/" & filUploadBranches.FileName), FileMode.Open) 'c:/example.csv
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
    End Function
End Class