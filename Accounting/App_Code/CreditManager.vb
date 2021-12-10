Imports System
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports System.Web
Imports System.Web.UI.WebControls

Public Class CreditManager
    'Shared adp As New SqlDataAdapter
    'Shared cmd As SqlCommand
    'Shared con As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
    'Shared connection As String

    Public Shared Sub bindGrid(ByVal dt As DataTable, ByVal grd As GridView)
        If dt.Rows.Count > 0 Then
            grd.DataSource = dt
        Else
            grd.DataSource = Nothing
        End If
        grd.DataBind()
    End Sub

    Public Shared Function writeTXTMessage(template As String, Optional name As String = "", Optional compName As String = "", Optional loanAmt As String = "", Optional instalment As String = "", Optional dueDate As String = "") As String
        Return template.Replace("{{NAME}}", name).Replace("{{COMPANY}}", compName).Replace("{{AMOUNT}}", loanAmt).Replace("{{INSTALMENT}}", instalment).Replace("{{DUEDATE}}", dueDate)
    End Function

    Public Shared Function getInternalControls() As DataRow
        Dim dt As New dsStaticDetails.ParaInternalControlsDataTable
        Dim dss As New dsStaticDetailsTableAdapters.ParaInternalControlsTableAdapter
        dss.Fill(dt)
        Return dt.Rows(0)
    End Function

    Public Shared Sub getAnswers(combo As DropDownList, varID As String)
        Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
            Using cmd = New SqlCommand("select lower_range from rating_ranges where variable_id='" & varID & "'", con)
                Dim ds As New DataSet
                Using adp = New SqlDataAdapter(cmd)
                    adp.Fill(ds, "rr")
                End Using
                If ds.Tables(0).Rows.Count > 0 Then
                    loadCombo(ds.Tables(0), combo, "lower_range", "lower_range")
                End If
            End Using
        End Using
    End Sub

    Public Shared Sub loadBankBranches(bnk As String, cmb As DropDownList)
        Try
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd = New SqlCommand("SELECT bank, branch, branch_name FROM para_branch where bank='" & bnk & "'", con)
                    Dim ds As New DataSet
                    Dim adp = New SqlDataAdapter(cmd)
                    adp.Fill(ds, "para_branch")
                    loadCombo(ds.Tables(0), cmb, "branch_name", "branch")
                End Using
            End Using
        Catch ex As Exception
            ErrorLogging.WriteLogFile(HttpContext.Current.Session("UserId"), HttpContext.Current.Request.Url.ToString & " --- loadBranches()", ex.ToString)
        End Try
    End Sub

    Public Shared Sub loadBranches(cmb As DropDownList)
        Try
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd = New SqlCommand("select * from BNCH_DETAILS", con)
                    Dim ds As New DataSet
                    Using adp = New SqlDataAdapter(cmd)
                        adp.Fill(ds, "BNCH")
                    End Using
                    loadCombo(ds.Tables(0), cmb, "BNCH_NAME", "BNCH_CODE")
                End Using
            End Using
        Catch ex As Exception
            cmb.ClearSelection()
        End Try
    End Sub

    Public Shared Function CashBoxActive() As Boolean
        Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
            Using cmd = New SqlCommand("select * from PARA_LOGIN", con)
                Dim ds As New DataSet
                Using adp = New SqlDataAdapter(cmd)
                    adp.Fill(ds, "BNCH")
                End Using
                If ds.Tables(0).Rows(0).Item("DisbursementOption").ToString = "CASH BOX" Then
                    Return True
                Else
                    Return False
                End If
            End Using
        End Using
    End Function

    Public Shared Sub loadClientType(cmbClientType As DropDownList)
        Try
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd = New SqlCommand("select * from PARA_CLIENT_TYPES where ENABLED=1", con)
                    Dim ds As New DataSet
                    Using adp = New SqlDataAdapter(cmd)
                        adp.Fill(ds, "CLIENT")
                    End Using
                    loadCombo(ds.Tables(0), cmbClientType, "CLIENT_TYPE", "ID")
                End Using
            End Using
        Catch ex As Exception
            cmbClientType.ClearSelection()
        End Try
    End Sub

    Public Shared Sub loadCombo(ByVal dt As DataTable, ByVal cmb As DropDownList, ByVal textField As String, ByVal valField As String)
        cmb.AppendDataBoundItems = True
        cmb.Items.Clear()
        cmb.Items.Add("")
        If dt.Rows.Count > 0 Then
            cmb.DataSource = dt
            cmb.DataTextField = textField
            cmb.DataValueField = valField
        Else
            cmb.DataSource = Nothing
        End If
        cmb.DataBind()
    End Sub

    Public Shared Sub loadCreditPurpose(cliType As String, cmb As DropDownList)
        Try
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                If Trim(cliType) <> "" Then
                    Using cmd = New SqlCommand("select * from PARA_PURPOSE where ClientType='" & cliType & "'", con)
                        Dim ds As New DataSet
                        Using adp = New SqlDataAdapter(cmd)
                            adp.Fill(ds, "CLIENT")
                        End Using
                        loadCombo(ds.Tables(0), cmb, "Purpose", "Purpose")
                    End Using
                End If
            End Using
        Catch ex As Exception

        End Try
    End Sub

    Public Shared Sub loadParaProductType(cmb As DropDownList)
        Try
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd = New SqlCommand("select * from ParaProductTypes", con)
                    Dim ds As New DataSet
                    Using adp = New SqlDataAdapter(cmd)
                        adp.Fill(ds, "Product")
                    End Using
                    loadCombo(ds.Tables(0), cmb, "Product", "id")
                End Using
            End Using
        Catch ex As Exception
            ErrorLogging.WriteLogFile(HttpContext.Current.Session("UserId"), HttpContext.Current.Request.Url.ToString & " --- loadParaProductType()", ex.ToString)
        End Try
    End Sub

    Public Shared Sub loadProductType(cmb As DropDownList)
        Try
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd = New SqlCommand("select * from CreditProducts where Active=1", con)
                    Dim ds As New DataSet
                    Using adp = New SqlDataAdapter(cmd)
                        adp.Fill(ds, "CLIENT")
                    End Using
                    loadCombo(ds.Tables(0), cmb, "DisplayName", "id")
                End Using
            End Using
        Catch ex As Exception
            ErrorLogging.WriteLogFile(HttpContext.Current.Session("UserId"), HttpContext.Current.Request.Url.ToString & " --- loadProductType()", ex.ToString)
        End Try
    End Sub

    Public Shared Function toMoney(inp As String) As Double
        If Trim(inp) = "" Then
            Return 0
        Else
            Return inp.Replace("US", "").Replace("$", "").Replace(",", "").Replace("Z", "")
        End If
    End Function

    Public Shared Sub loadQuestLoanStatus(cmbStatus As DropDownList)
        Try
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd = New SqlCommand("select distinct STATUS from QUEST_APPLICATION", con)
                    Dim ds As New DataSet
                    Using adp = New SqlDataAdapter(cmd)
                        adp.Fill(ds, "STATUS")
                    End Using
                    cmbStatus.Items.Clear()
                    cmbStatus.Items.Add("")
                    If ds.Tables(0).Rows.Count > 0 Then
                        cmbStatus.DataSource = ds.Tables(0)
                        cmbStatus.DataTextField = "STATUS"
                        cmbStatus.DataValueField = "STATUS"
                    Else
                        cmbStatus.DataSource = Nothing
                    End If
                    cmbStatus.DataBind()
                End Using
            End Using
        Catch ex As Exception
            cmbStatus.ClearSelection()
        End Try
    End Sub

    Public Shared Sub loadSectors(cmb As DropDownList)
        Try
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd = New SqlCommand("select * from PARA_SECTOR", con)
                    Dim ds As New DataSet
                    Using adp = New SqlDataAdapter(cmd)
                        adp.Fill(ds, "CLIENT")
                    End Using
                    loadCombo(ds.Tables(0), cmb, "SECTOR", "SECTOR")
                End Using
            End Using
        Catch ex As Exception
            ErrorLogging.WriteLogFile(HttpContext.Current.Session("UserId"), HttpContext.Current.Request.Url.ToString & " --- loadSectors()", ex.ToString)
        End Try
    End Sub

    Public Shared Sub loadUserRoles(cmb As DropDownList)
        Try
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd = New SqlCommand("select * from MASTER_ROLES", con)
                    Dim ds As New DataSet
                    Using adp = New SqlDataAdapter(cmd)
                        adp.Fill(ds, "CLIENT")
                    End Using
                    loadCombo(ds.Tables(0), cmb, "RoleName", "RoleID")
                End Using
            End Using
        Catch ex As Exception
            ErrorLogging.WriteLogFile(HttpContext.Current.Session("UserId"), HttpContext.Current.Request.Url.ToString & " --- loadUserRoles()", ex.ToString)
        End Try
    End Sub

    Public Shared Sub loadUsersByRole(cmb As DropDownList, role As String, Optional brnch As String = "")
        Try
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                If brnch = "" Then
                    Using cmd = New SqlCommand("select * from MASTER_USERS where [USER_TYPE]='" & role & "'", con)
                        Dim ds As New DataSet
                        Using adp = New SqlDataAdapter(cmd)
                            adp.Fill(ds, "CLIENT")
                        End Using
                        loadCombo(ds.Tables(0), cmb, "USER_LOGIN", "USERID")
                    End Using
                Else
                    Using cmd = New SqlCommand("select * from MASTER_USERS where [USER_TYPE]='" & role & "' and [USER_BRANCH]='" & brnch & "'", con)
                        Dim ds As New DataSet
                        Using adp = New SqlDataAdapter(cmd)
                            adp.Fill(ds, "CLIENT")
                        End Using
                        loadCombo(ds.Tables(0), cmb, "USER_LOGIN", "USERID")
                    End Using
                End If
            End Using
        Catch ex As Exception
            ErrorLogging.WriteLogFile(HttpContext.Current.Session("UserId"), HttpContext.Current.Request.Url.ToString & " --- loadUsersByRole()", ex.ToString)
        End Try
    End Sub

    Public Shared Sub msgbox(ByVal strMessage As String)

        'finishes server processing, returns to client.
        Dim strScript As String = "<script language=JavaScript>"
        strScript += "window.alert(""" & strMessage & """);"
        strScript += "</script>"
        Dim lbl As New System.Web.UI.WebControls.Label
        lbl.Text = strScript

        Dim page = TryCast(HttpContext.Current.CurrentHandler, System.Web.UI.Page)
        page.Controls.Add(lbl)
    End Sub

    Public Shared Sub notify(strMessage As String, NotificationType As String, Optional layout As String = "top")
        Dim strScript As String = "<script language=JavaScript>"
        strScript += "notify(""" & strMessage & """,""" & NotificationType & """,""" & layout & """);"
        strScript += "</script>"
        Dim page = TryCast(HttpContext.Current.CurrentHandler, System.Web.UI.Page)
        ' throw an exception, something bad happened
        If page Is Nothing Then
        Else
            ' now you have access to the current page...
            page.ClientScript.RegisterStartupScript(page.[GetType](), "noty" + DateTime.Now, strScript)
        End If
    End Sub

    Public Shared Sub loadBanks(cmb As DropDownList)
        Try
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd As New SqlCommand("select distinct bank, bank_name from para_bank order by bank", con)
                    Dim dss As New DataSet
                    Dim adp = New SqlDataAdapter(cmd)
                    adp.Fill(dss, "para_bank")
                    loadCombo(dss.Tables(0), cmb, "bank_name", "bank")
                End Using
            End Using
        Catch ex As Exception
            ErrorLogging.WriteLogFile(HttpContext.Current.Session("UserId"), HttpContext.Current.Request.Url.ToString & " --- loadBanks()", ex.ToString)
        End Try
    End Sub

    Function UserHasPermissionForModule(ByVal vUserName As String, ByVal PageUrl As String) As DataTable
        Dim ds As New DataSet
        Dim adp As New SqlDataAdapter
        Dim con As SqlConnection = New SqlConnection()
        con = New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
        adp = New SqlDataAdapter("Select_PermissionsForMultipleRole", con)
        adp.SelectCommand.CommandType = CommandType.StoredProcedure
        adp.SelectCommand.Parameters.AddWithValue("@RoleID", vUserName)
        adp.SelectCommand.Parameters.AddWithValue("@PageUrl", PageUrl)
        adp.Fill(ds)
        Return ds.Tables(0)
    End Function

    Public Shared Function saveTransaction(category As String, reference As String, description As String, debit As Double, credit As Double, account As String, contra As String, status As String, other As String, bankAccId As String, bankAccName As String, batchRef As String, trxnDate As Date) As Boolean
        Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
            Using cmd As New SqlCommand("SaveAccountsTrxnsWithContra", con)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("@Type", "System Entry")
                cmd.Parameters.AddWithValue("@Category", category)
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
                ' cmd.Parameters.AddWithValue("@CaptureBy", HttpContext.Current.Session("UserId"))

                If con.State = ConnectionState.Open Then
                    con.Close()
                End If
                con.Open()
                If cmd.ExecuteNonQuery() Then
                    Return True
                Else
                    Return False
                End If
                con.Close()
            End Using
        End Using
    End Function

    Public Shared Function saveTempTransaction(category As String, reference As String, description As String, debit As Double, credit As Double, account As String, contra As String, status As String, other As String, bankAccId As String, bankAccName As String, batchRef As String, trxnDate As Date) As Boolean
        Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
            Using cmd As New SqlCommand("SaveAccountsTrxnsWithContra", con)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("@Type", "System Entry")
                cmd.Parameters.AddWithValue("@Category", category)
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
                ' cmd.Parameters.AddWithValue("@CaptureBy", HttpContext.Current.Session("UserId"))

                If con.State = ConnectionState.Open Then
                    con.Close()
                End If
                con.Open()
                If cmd.ExecuteNonQuery() Then
                    Return True
                Else
                    Return False
                End If
                con.Close()
            End Using
        End Using
    End Function

    Shared Function validateNumeric(inp As String) As Object
        'Return IIf(IsNumeric(toMoney(inp)), DBNull.Value, inp)
        Return IIf(Trim(inp) = "", DBNull.Value, inp)
    End Function

    Shared Function validateDate(inp As String) As Object
        'Return IIf(IsNumeric(toMoney(inp)), DBNull.Value, inp)
        Return IIf(Trim(inp) = "" Or Not IsDate(inp) Or CDate(inp) = CDate("01 Jan 1900"), DBNull.Value, inp)
    End Function

    Shared Function validateDropdown(inp As DropDownList) As Object
        'Return IIf(IsNumeric(toMoney(inp)), DBNull.Value, inp)
        Return IIf(inp.SelectedIndex = -1, DBNull.Value, inp.SelectedValue)
    End Function

    Shared Function validateRadiobutton(inp As RadioButtonList) As Object
        'Return IIf(IsNumeric(toMoney(inp)), DBNull.Value, inp)
        Return IIf(inp.SelectedIndex = -1, DBNull.Value, inp.SelectedValue)
    End Function

    Shared Function displayDate(inp As String) As Object
        Return IIf(Trim(inp) = "" Or Not IsDate(inp) Or CDate(inp) = CDate("01 Jan 1900"), "", inp)
    End Function

    Shared Function removeNULL(ByVal myreader As DataSet, ByVal j As Integer, ByVal stval As Integer) As String
        Dim val As Object = myreader.Tables(0).Rows(j).Item(stval)
        If val IsNot DBNull.Value Then
            If val.ToString <> "" Then
                Return val.ToString()
            Else
                Return Convert.ToString(0)
            End If
        Else
            Return Convert.ToString(0)
        End If
    End Function

    Public Shared Sub loadCountry(cmb As DropDownList)
        Try
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd = New SqlCommand("select * from [ParaCountryCodes]", con)
                    Dim ds As New DataSet
                    Using adp = New SqlDataAdapter(cmd)
                        adp.Fill(ds, "Country")
                    End Using
                    loadCombo(ds.Tables(0), cmb, "ItemDesc", "ItemValue")
                End Using
            End Using
        Catch ex As Exception
            ErrorLogging.WriteLogFile(HttpContext.Current.Session("UserId"), HttpContext.Current.Request.Url.ToString, ex.ToString)
        End Try
    End Sub

    Public Shared Sub loadEducationLevel(cmb As DropDownList)
        Try
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd = New SqlCommand("select * from [ParaEducationLevel]", con)
                    Dim ds As New DataSet
                    Using adp = New SqlDataAdapter(cmd)
                        adp.Fill(ds, "Education")
                    End Using
                    loadCombo(ds.Tables(0), cmb, "ItemDesc", "ItemValue")
                End Using
            End Using
        Catch ex As Exception
            ErrorLogging.WriteLogFile(HttpContext.Current.Session("UserId"), HttpContext.Current.Request.Url.ToString, ex.ToString)
        End Try
    End Sub

    Public Shared Sub loadMaritalStatus(cmb As DropDownList)
        Try
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd = New SqlCommand("select * from [ParaMaritalStatus]", con)
                    Dim ds As New DataSet
                    Using adp = New SqlDataAdapter(cmd)
                        adp.Fill(ds, "MaritalStatus")
                    End Using
                    loadCombo(ds.Tables(0), cmb, "ItemDesc", "ItemValue")
                End Using
            End Using
        Catch ex As Exception
            ErrorLogging.WriteLogFile(HttpContext.Current.Session("UserId"), HttpContext.Current.Request.Url.ToString, ex.ToString)
        End Try
    End Sub

    Public Shared Sub loadClassificationOfIndividual(cmb As DropDownList)
        Try
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd = New SqlCommand("select * from [ParaClassificationOfIndividual]", con)
                    Dim ds As New DataSet
                    Using adp = New SqlDataAdapter(cmd)
                        adp.Fill(ds, "ClassificationOfIndividual")
                    End Using
                    loadCombo(ds.Tables(0), cmb, "ItemDesc", "ItemValue")
                End Using
            End Using
        Catch ex As Exception
            ErrorLogging.WriteLogFile(HttpContext.Current.Session("UserId"), HttpContext.Current.Request.Url.ToString, ex.ToString)
        End Try
    End Sub

    Public Shared Sub loadNegativeStatusOfIndividual(cmb As DropDownList)
        Try
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd = New SqlCommand("select * from [ParaNegativeStatusOfIndividual]", con)
                    Dim dt As New DataTable
                    Using adp = New SqlDataAdapter(cmd)
                        adp.Fill(dt)
                    End Using
                    loadCombo(dt, cmb, "ItemDesc", "ItemValue")
                End Using
            End Using
        Catch ex As Exception
            ErrorLogging.WriteLogFile(HttpContext.Current.Session("UserId"), HttpContext.Current.Request.Url.ToString, ex.ToString)
        End Try
    End Sub

End Class