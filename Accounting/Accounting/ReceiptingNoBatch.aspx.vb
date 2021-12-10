Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Drawing.Printing
Imports CreditManager
Imports ErrorLogging

Partial Class Accounting_ReceiptingNoBatch
    Inherits System.Web.UI.Page
    Dim cmd As SqlCommand
    Dim con As New SqlConnection
    Dim adp As New SqlDataAdapter
    Dim connection As String
    Dim receiptno As String
    Dim cryRpt As ReportDocument = New ReportDocument()

    Public Sub msgbox(ByVal strMessage As String)
        'finishes server processing, returns to client.
        Dim strScript As String = "<script language=JavaScript>"
        strScript += "window.alert(""" & strMessage & """);"
        strScript += "</script>"
        Dim lbl As New System.Web.UI.WebControls.Label
        lbl.Text = strScript
        Page.Controls.Add(lbl)

    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Page.MaintainScrollPositionOnPostBack = True
        con = New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
        If Not IsPostBack Then
            loadBathces()
            loadFinAccs()
            loadIndvAccs()
            getUnclearedReceipts()
            getPrinters()
            getCutOffDate()
            'lblReceipt.Text = "<a href='rptReceipt.aspx?BatchNo='" & cmbBatchNo.SelectedItem.Text & "'' target='_new'>Print Receipt</a>"
        End If
    End Sub

    Protected Sub loadFinAccs()
        Try
            'cmd = New SqlCommand("select AccountName + ' | ' + convert(varchar,MainAccount) +'/'+ convert(varchar,SubAccount) as AccountName,  convert(varchar,MainAccount) +'/'+ convert(varchar,SubAccount) as 'Accno' from tbl_FinancialAccountsCreation", con)
            cmd = New SqlCommand("select AccountName + ' ' + convert(varchar,MainAccount) +'/'+ convert(varchar,SubAccount) as AccountName,  convert(varchar,MainAccount) +'/'+ convert(varchar,SubAccount) as 'Accno' from tbl_FinancialAccountsCreation where SubAccount<>1 union select LTRIM(isnull(surname,'')+' ')+rtrim(isnull(forenames,''))+' '+customer_number as AccountName,customer_number as 'Accno' from customer_details order by AccountName", con)
            Dim ds As New DataSet
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "AccountsTypes")
            loadCombo(ds.Tables(0), cmbAccount, "AccountName", "Accno")
            'If ds.Tables(0).Rows.Count > 0 Then
            '    cmbAccount.DataSource = ds
            '    cmbAccount.DataTextField = "AccountName"
            '    cmbAccount.DataValueField = "Accno"
            '    cmbAccount.DataBind()
            '    cmbAccount.Items.Add("-Select-")
            '    cmbAccount.SelectedIndex = cmbAccount.Items.Count - 1
            'Else
            '    cmbAccount.DataSource = Nothing
            '    cmbAccount.DataBind()
            'End If

        Catch ex As Exception
            msgbox(ex.Message)
        End Try

    End Sub
    Protected Sub loadBathces()
        '  Try
        cmd = New SqlCommand("select * from [tbl_BatchRec] where BatchType= 'Receipting' and [status]=0", con)
        Dim ds As New DataSet
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "BatchRec")
        If ds.Tables(0).Rows.Count > 0 Then
            cmbBatchNo.DataSource = ds
            cmbBatchNo.DataTextField = "BatchNo"
            cmbBatchNo.DataValueField = "id"
            cmbBatchNo.DataBind()
            cmbBatchNo.Items.Add(" ")
            cmbBatchNo.SelectedIndex = cmbBatchNo.Items.Count - 1
        Else
            cmbBatchNo.DataSource = Nothing
            cmbBatchNo.DataBind()
        End If

        'Catch ex As Exception
        'msgbox(ex.Message)
        'End Try
    End Sub
    Protected Sub loadIndvAccs()
        Try
            cmd = New SqlCommand("select [SURNAME]+' '+ [FORENAMES] + ' | ' + CUSTOMER_NUMBER as Name, CUSTOMER_NUMBER from QUEST_APPLICATION order by 'Name'", con)
            Dim ds As New DataSet
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "QUEST_APPLICATION")
            If ds.Tables(0).Rows.Count > 0 Then
                cmbAccount0.DataSource = ds
                cmbAccount0.DataTextField = "Name"
                cmbAccount0.DataValueField = "CUSTOMER_NUMBER"
                cmbAccount0.DataBind()
                cmbAccount0.Items.Add("-Select-")
                cmbAccount0.SelectedIndex = cmbAccount0.Items.Count - 1
            Else
                cmbAccount0.DataSource = Nothing
                cmbAccount0.DataBind()
            End If

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub loadGrid()
        Try
            cmd = New SqlCommand("select * from Accounts_Transactions where BatchRef= '" & cmbBatchNo.SelectedItem.Text & "'", con)
            Dim ds As New DataSet
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "Accounts")
            If ds.Tables(0).Rows.Count > 0 Then
                grdDetails.DataSource = ds.Tables(0)
                grdDetails.DataBind()
            Else
                grdDetails.DataSource = Nothing
                grdDetails.DataBind()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub loadGrid2()
        Try
            cmd = New SqlCommand("select [BatchNo],[BatchType] ,[Amount] ,[NumberOfTrxns],[CreatedBy],convert(varchar,[DateCreated],106) as BatchDate from tbl_BatchRec where [BatchNo]= '" & cmbBatchNo.SelectedItem.Text & "'", con)
            Dim ds As New DataSet
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "Accounts")
            If ds.Tables(0).Rows.Count > 0 Then
                grdDetails0.DataSource = ds.Tables(0)
                grdDetails0.DataBind()
            Else
                grdDetails0.DataSource = Nothing
                grdDetails0.DataBind()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Function Checkfeilds() As Boolean
        Checkfeilds = False
        Try
            If Not IsNumeric(txtAmount.Text) Then
                msgbox("Amount Must Be Numeric")
                txtAmount.Focus()
                Exit Function
            End If
            If txtAmount.Text = "" Then
                msgbox("Amount Is Mandatory")
                txtAmount.Focus()
                Exit Function
            End If
            If cmbAccount.SelectedValue = "-Select-" Then
                msgbox("Account Is Mandatory")
                cmbAccount.Focus()
                Exit Function
            End If
            If txtRef.Text = "" Then
                msgbox("Ref Is Mandatory")
                txtRef.Focus()
                Exit Function
            End If
            If cmbAccount.SelectedValue = "100/1" Or cmbAccount.SelectedValue = "213/1" Then
                If cmbAccount0.SelectedItem.Text = "-Select-" Then
                    msgbox("Loan Debtor Account Is Mandatory")
                    cmbAccount0.Focus()
                    Exit Function
                End If
            End If
            Checkfeilds = True
        Catch ex As Exception

        End Try
    End Function
    Protected Sub btnSaveTrxn_Click(sender As Object, e As EventArgs) Handles btnSaveTrxn.Click
        ' Try
        If cmbBatchNo.Text.Trim <> "" Then
            cmd = New SqlCommand("select (amount) as batch_amount, sum(debit) as debits, sum(credit) as credits, count(b.id) as trxns from tbl_BatchRec a, Accounts_Transactions b where a.batchno=b.batchref and  a.BatchNo= '" & cmbBatchNo.SelectedItem.Text & "' group by amount", con)
            Dim ds As New DataSet
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "batch")
            If ds.Tables(0).Rows.Count > 0 Then
                If ds.Tables(0).Rows(0).Item("batch_amount") <> ds.Tables(0).Rows(0).Item("debits") Or ds.Tables(0).Rows(0).Item("debits") <> ds.Tables(0).Rows(0).Item("credits") Then
                    msgbox("Batch Not Balanced, Not Comitted!")
                    Exit Sub
                Else
                    cmd = New SqlCommand("Update tbl_BatchRec set status = 1 where BatchNo='" & cmbBatchNo.SelectedItem.Text & "'", con)
                    If con.State = ConnectionState.Open Then
                        con.Close()
                    End If
                    con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()

                    Dim strscript As String
                    strscript = "<script langauage=JavaScript>"
                    strscript += "window.open('rptReceipt.aspx?BatchNo=" & cmbBatchNo.SelectedItem.Text & "');"
                    strscript += "</script>"
                    ClientScript.RegisterStartupScript(Me.GetType(), "newwin", strscript)

                    loadBathces()
                    ClearFeilds()

                    msgbox("Batch Balanced, Committed")

                    Response.Redirect("~/Accounting/Cashbook.aspx")

                End If
            End If
        Else
        End If
    End Sub
    Protected Sub getReceiptNo()
        Try
            cmd = New SqlCommand("select max(ID) as Receipt from Accounts_Transactions_Temp", con)
            Dim ds As New DataSet
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "APP")
            If ds.Tables(0).Rows.Count > 0 Then
                receiptno = ds.Tables(0).Rows(0).Item("Receipt").ToString
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub BalanceBatch()
        Try

        Catch ex As Exception
            msgbox(ex.ToString)
        End Try
    End Sub

    Protected Sub btnSaveTrxn3_Click(sender As Object, e As EventArgs) Handles btnSaveTrxn3.Click
        Try
            If Checkfeilds() = True Then
                Dim PayType As String
                If rdbPayType.SelectedIndex = 0 Then
                    PayType = "211/26"
                ElseIf rdbPayType.SelectedIndex = 1 Then
                    'PayType = "212/1"
                    PayType = cmbAccount1.SelectedValue
                Else
                    msgbox("Select payment type")
                    Exit Sub
                End If
                Dim cramount, dramount As Double
                dramount = 0.0
                cramount = CDbl(txtAmount.Text)

                'cmd = New SqlCommand("SaveTempAccountsTrxns", con)
                cmd = New SqlCommand("SaveAccountsTrxnsTempWithContra", con)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("@Type", rdbPayType.SelectedItem.Text)
                cmd.Parameters.AddWithValue("@Category", "")
                cmd.Parameters.AddWithValue("@Ref", txtRef.Text)
                cmd.Parameters.AddWithValue("@Desc", txtdesc.Text)
                cmd.Parameters.AddWithValue("@Debit", dramount)
                cmd.Parameters.AddWithValue("@Credit", cramount)
                cmd.Parameters.AddWithValue("@Account", cmbAccount.SelectedValue)
                cmd.Parameters.AddWithValue("@ContraAccount", PayType)
                'cmd.Parameters.AddWithValue("@ContraAccount", cmbAccount1.SelectedValue)
                cmd.Parameters.AddWithValue("@Status", IIf(rdbType0.SelectedIndex = 0, 1, 0))
                cmd.Parameters.AddWithValue("@Other", IIf(cmbAccount0.SelectedValue <> "-Select-", cmbAccount0.SelectedValue, 0))
                cmd.Parameters.AddWithValue("@BankAccID", "")
                cmd.Parameters.AddWithValue("@BankAccName", "")
                'cmd.Parameters.AddWithValue("@BatchRef", cmbBatchNo.SelectedItem.Text)
                cmd.Parameters.AddWithValue("@BatchRef", "")
                cmd.Parameters.AddWithValue("@TrxnDate", dtpTrxnDate.Text)
                cmd.Parameters.AddWithValue("@CaptureBy", Session("UserId"))

                If con.State = ConnectionState.Open Then
                    con.Close()
                End If
                con.Open()
                If cmd.ExecuteNonQuery() Then
                    getReceiptNo()
                    msgbox("Receipt No: " & receiptno & " generated")
                    'If SaveContra() = True Then
                    msgbox("Receipt posted for authorization")
                    printReceipt(receiptno)
                    'lblReceipt.Text = "<a href='rptReceipt.aspx?receiptno=" & receiptno & "' target='_new'>Print Receipt</a>"
                    'ClearFeilds()
                    getUnclearedReceipts()
                    'Else
                    '    msgbox("Error Saving Details")
                    'End If

                Else
                    msgbox("Error Saving Details")
                End If
                con.Close()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub printReceipt(recNo As String)
        Try
            Dim queryString As String = "YourPrintPage.aspx?id=" & recNo
            ClientScript.RegisterStartupScript(Me.GetType(), "abc", "loadPrintPage('" & queryString & "');", True)

            'Dim myreport = New CrystalDecisions.CrystalReports.Engine.ReportDocument()

            'Dim kk As String = ""
            'kk = Server.MapPath("rptReceipt.rpt")
            'cryRpt.Load(kk)
            'cryRpt.SetParameterValue(0, recNo)
            'Dim PrinterName = cmbPrinters.Text
            'cryRpt.PrintOptions.PrinterName = PrinterName
            'cryRpt.PrintToPrinter(1, False, 0, 0)

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub getPrinters()
        For Each Printer In PrinterSettings.InstalledPrinters
            cmbPrinters.Items.Add(Printer)
        Next
    End Sub

    Public Function SaveContra() As Boolean
        SaveContra = False
        Try
            SaveContra = False
            Dim bankacc As String
            Dim acc As String
            If Checkfeilds() = True Then
                Dim PayType As String
                If rdbPayType.SelectedIndex = 0 Then
                    PayType = "211/1"
                    bankacc = ""
                    acc = 0
                Else
                    'PayType = "212/1"
                    PayType = cmbAccount1.SelectedValue
                    If cmbAccount1.Text = "" Then
                        bankacc = ""
                        acc = 0
                    Else
                        bankacc = cmbAccount1.SelectedItem.Text
                        acc = cmbAccount1.SelectedValue
                    End If
                End If
                Dim cramount, dramount As Double
                dramount = CDbl(txtAmount.Text)
                cramount = 0.0

                cmd = New SqlCommand("SaveTempAccountsTrxns", con)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("@Type", "Receipt")
                cmd.Parameters.AddWithValue("@Category", "")
                cmd.Parameters.AddWithValue("@Ref", txtRef.Text)
                cmd.Parameters.AddWithValue("@Desc", txtdesc.Text)
                cmd.Parameters.AddWithValue("@Debit", dramount)
                cmd.Parameters.AddWithValue("@Credit", cramount)
                cmd.Parameters.AddWithValue("@Account", PayType)
                cmd.Parameters.AddWithValue("@ContraAccount", cmbAccount.SelectedValue)
                cmd.Parameters.AddWithValue("@Status", IIf(rdbType0.SelectedIndex = 0, 1, 0))
                cmd.Parameters.AddWithValue("@Other", IIf(cmbAccount0.SelectedValue <> "-Select-", cmbAccount0.SelectedValue, 0))
                cmd.Parameters.AddWithValue("@BankAccID", acc)
                cmd.Parameters.AddWithValue("@BankAccName", bankacc)
                'cmd.Parameters.AddWithValue("@BatchRef", cmbBatchNo.SelectedItem.Text)
                cmd.Parameters.AddWithValue("@BatchRef", "")
                cmd.Parameters.AddWithValue("@TrxnDate", dtpTrxnDate.Text)
                cmd.Parameters.AddWithValue("@CapturedBy", Session("ID"))

                If con.State = ConnectionState.Open Then
                    con.Close()
                End If
                con.Open()
                If cmd.ExecuteNonQuery() Then
                    SaveContra = True
                Else
                    msgbox("Error Saving Details")
                End If
                con.Close()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Function
    Public Sub ClearFeilds()
        txtAmount.Text = ""
        txtdesc.Text = ""
        txtRef.Text = ""
        cmbAccount.SelectedIndex = cmbAccount.Items.Count - 1
        cmbAccount0.SelectedIndex = cmbAccount0.Items.Count - 1
        rdbPayType.SelectedIndex = -1
        rdbType0.SelectedIndex = -1
    End Sub

    Protected Sub getUnclearedReceipts()
        Try
            cmd = New SqlCommand("select att.ID,att.Type,att.Category,convert(varchar,att.TrxnDate,106) as [Date],att.Account,att.ContraAccount,att.Refrence,att.Description as [Received From],att.Debit,att.Credit from Accounts_Transactions_Temp att where CapturedBy='" & Session("ID") & "' and (Authorized<>1 or Authorized is null)", con)
            Dim ds As New DataSet
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "ATT")
            If ds.Tables(0).Rows.Count > 0 Then
                'fill grid
                grdDetails.DataSource = ds.Tables(0)
            Else
                grdDetails.DataSource = Nothing
            End If
            grdDetails.DataBind()
            calcTotal()
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub calcTotal()
        Try
            Dim cmdSum = New SqlCommand("select FORMAT(isnull(SUM(att.Credit),0),'c') as [Total] from Accounts_Transactions_Temp att where CapturedBy='" & Session("ID") & "' and (Authorized<>1 or Authorized is null)", con)
            Dim dsSum As New DataSet
            Dim adpSum As New SqlDataAdapter
            adpSum = New SqlDataAdapter(cmdSum)
            adpSum.Fill(dsSum, "tot")
            lblRecTotal.Text = dsSum.Tables(0).Rows(0).Item("Total").ToString
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub rdbPayType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rdbPayType.SelectedIndexChanged
        If rdbPayType.SelectedIndex = 1 Then
            cmbAccount1.Visible = True
            loadBanks()
        Else
            'cmbAccount1.Visible = True
            'loadCash()
            cmbAccount1.Visible = False
            cmbAccount1.DataSource = Nothing
            cmbAccount1.DataBind()
        End If
    End Sub
    Protected Sub loadCash()
        Try
            cmd = New SqlCommand("select *,convert(varchar,MainAccount) +'/'+ convert(varchar,SubAccount) as Acc,AccountName + ' | ' + CONVERT(varchar,mainaccount) + '/' + CONVERT(varchar,subaccount) as 'AccName' from [tbl_FinancialAccountsCreation] where MainAccount='211' and SubAccount<>1 order by AccountName", con)
            Dim ds As New DataSet
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "banks")
            loadCombo(ds.Tables(0), cmbAccount1, "AccName", "Acc")
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub loadBanks()
        Try
            'cmd = New SqlCommand("select * from tbl_BankAccounts", con)
            cmd = New SqlCommand("select *,convert(varchar,MainAccount) +'/'+ convert(varchar,SubAccount) as Acc from [tbl_FinancialAccountsCreation] where MainAccount='212'", con)
            Dim ds As New DataSet
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "banks")
            If ds.Tables(0).Rows.Count > 0 Then
                cmbAccount1.DataSource = ds
                cmbAccount1.DataTextField = "AccountName"
                cmbAccount1.DataValueField = "Acc"
                cmbAccount1.DataBind()
                cmbAccount1.Items.Add("-Select-")
                cmbAccount1.SelectedIndex = cmbAccount1.Items.Count - 1
            Else
                cmbAccount1.DataSource = Nothing
                cmbAccount1.DataBind()
            End If

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    'Protected Sub cmbBatchNo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbBatchNo.SelectedIndexChanged
    '    loadGrid2()
    '    loadGrid()
    'End Sub

    Protected Sub cmbAccount_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbAccount.SelectedIndexChanged
        If cmbAccount.SelectedValue = "100/1" Or cmbAccount.SelectedValue = "213/1" Then
            lblLoanDebtor.Visible = True
            cmbAccount0.Visible = True
            getDefault()
        Else
            lblLoanDebtor.Visible = False
            cmbAccount0.Visible = False
            getDefault()
        End If
    End Sub

    Public Sub getDefault()
        '  Try

        cmd = New SqlCommand("select [Default]  from tbl_FinancialAccountsCreation where [AccountName]= '" & cmbAccount.SelectedItem.Text & "'", con)
        Dim ds As New DataSet
        adp = New SqlDataAdapter(cmd)
        adp.Fill(ds, "Accounts")
        If ds.Tables(0).Rows.Count > 0 Then
            lblDefault.Text = ds.Tables(0).Rows(0).Item("Default").ToString
        End If

        'Catch ex As Exception
        '    msgbox(ex.ToString)
        'End Try
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Try

        Dim i As Integer
        For i = 0 To grdDetails.Rows.Count - 1
            Dim ch As CheckBox
            ch = CType(grdDetails.Rows(i).Cells(0).FindControl("CheckBox2"), CheckBox)
            If ch.Checked Then

                cmd = New SqlCommand("delete from  Accounts_Transactions_Temp where ID=" & grdDetails.Rows(i).Cells(1).Text & "", con)
                cmd.CommandType = CommandType.Text
                If con.State = ConnectionState.Open Then
                    con.Close()
                End If
                con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
                'If cmd.ExecuteNonQuery() Then
                '    loadGrid()
                'Else
                '    msgbox("Trxns Not Found")
                '    loadGrid()
                'End If
            End If
        Next
        'loadGrid()
        getUnclearedReceipts()
        'Catch ex As Exception

        'End Try

    End Sub

    Protected Sub getCutOffDate()
        Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
            Using cmd As New SqlCommand("select id,convert(varchar,CutOff,106) as [Date],CapturedBy as [Captured By],convert(varchar,CaptureDate,113) as [Capture Date] from AccCutOffDates where Authorised=1 order by CutOff desc", con)
                Dim ds As New DataSet
                Dim adp = New SqlDataAdapter(cmd)
                adp.Fill(ds, "APP")
                If ds.Tables(0).Rows.Count > 0 Then
                    lblCutOffDate.Text = ds.Tables(0).Rows(0).Item("Date")
                Else
                    lblCutOffDate.Text = ""
                End If
            End Using
        End Using
    End Sub
End Class