Imports System.Data
Imports System.Data.SqlClient
Imports CreditManager
Imports ErrorLogging

Partial Class Accounting_DisbursementAuthorization
    Inherits System.Web.UI.Page

    Dim debTotal = 0, credTotal = 0
    Dim intDebTotal = 0, intCredTotal = 0

    Protected Sub btnAuthorize_Click(sender As Object, e As EventArgs) Handles btnAuthorize.Click
        Try
            Dim btch = getBatchNo()
            If rdbAuthBy.SelectedValue = "Batch" Then
                Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                    Using cmd As New SqlCommand("CommitDisbursementRepayment", con)
                        cmd.CommandType = CommandType.StoredProcedure
                        cmd.Parameters.AddWithValue("@loanID", cmbBatchNo.SelectedValue)
                        'cmd.Parameters.AddWithValue("@BatchRef", getBatchNo())
                        cmd.Parameters.AddWithValue("@BatchRef", btch)
                        cmd.Parameters.AddWithValue("@Category", "Loan Disbursement")
                        con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    End Using
                    Using cmd As New SqlCommand("CommitDisbursementRepayment", con)
                        cmd.CommandType = CommandType.StoredProcedure
                        cmd.Parameters.AddWithValue("@loanID", cmbBatchNo.SelectedValue)
                        'cmd.Parameters.AddWithValue("@BatchRef", getBatchNo())
                        cmd.Parameters.AddWithValue("@BatchRef", btch)
                        cmd.Parameters.AddWithValue("@Category", "Interest Payable")
                        con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    End Using
                End Using
                notify("Transaction authorized", "success")
                loadBatches()
                getBatchEntries(cmbBatchNo.SelectedValue)
            ElseIf rdbAuthBy.SelectedValue = "Date" Then
                Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                    Using cmd As New SqlCommand("CommitDisbursementRepaymentByDate", con)
                        cmd.CommandType = CommandType.StoredProcedure
                        cmd.Parameters.AddWithValue("@trxnDate", txtDisbDate.Text)
                        'cmd.Parameters.AddWithValue("@BatchRef", getBatchNo())
                        cmd.Parameters.AddWithValue("@BatchRef", btch)
                        cmd.Parameters.AddWithValue("@Category", "Loan Disbursement")
                        con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    End Using
                    Using cmd As New SqlCommand("CommitDisbursementRepaymentByDate", con)
                        cmd.CommandType = CommandType.StoredProcedure
                        cmd.Parameters.AddWithValue("@trxnDate", txtDisbDate.Text)
                        'cmd.Parameters.AddWithValue("@BatchRef", getBatchNo())
                        cmd.Parameters.AddWithValue("@BatchRef", btch)
                        cmd.Parameters.AddWithValue("@Category", "Interest Payable")
                        con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    End Using
                End Using
                notify("Batch authorized", "success")
                loadBatches()
                getBatchEntries(cmbBatchNo.SelectedValue)
            Else
                notify("Select the authorization option", "error")
                rdbAuthBy.Focus()
            End If
        Catch ex As Exception
            ErrorLogging.WriteLogFile(Session("UserId"), Request.Url.ToString & " --- loadBatches()", ex.Message)
        End Try
    End Sub

    Protected Sub btnReverse_Click(sender As Object, e As EventArgs) Handles btnReverse.Click
        Try
            Dim cnt = 0
            For Each row As GridViewRow In grdDetails.Rows
                If row.RowType = DataControlRowType.DataRow Then
                    Dim chkRow As CheckBox = TryCast(row.Cells(0).FindControl("chkRow"), CheckBox)
                    If chkRow.Checked Then
                        Dim loanId As String = row.Cells(4).Text
                        'procedure to reverse
                        Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                            Using cmd As New SqlCommand("delete from Accounts_Transactions_Temp where Refrence=@ref and ([Authorized] is null or [Authorized]=0) and (Category='Loan Disbursement' or Category='Interest Payable')", con)
                                cmd.Parameters.AddWithValue("@ref", loanId)
                                con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()
                            End Using
                            Using cmd As New SqlCommand("delete from AMORTIZATION_SCHEDULE where LOANID=@ref", con)
                                cmd.Parameters.AddWithValue("@ref", loanId)
                                con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()
                            End Using
                            Using cmd As New SqlCommand("delete from AMORTIZATION_SCHEDULE_DAILY where LOANID=@ref", con)
                                cmd.Parameters.AddWithValue("@ref", loanId)
                                con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()
                            End Using
                            Using cmd As New SqlCommand("update QUEST_APPLICATION set [STATUS]='APPROVED2',SEND_TO='1024',DISBURSED='0',DISBURSED_DATE=NULL,DB_IDD=NULL,LAST_ID=@userID where ID=@loanID", con)
                                cmd.Parameters.AddWithValue("@userID", Session("id"))
                                cmd.Parameters.AddWithValue("@loanID", loanId)
                                con.Open()
                                cmd.ExecuteNonQuery()
                                con.Close()
                            End Using
                        End Using
                        cnt += 1
                    End If
                End If
            Next
            If cnt = 0 Then
                notify("Select the transaction to reverse", "error")
            Else
                notify("Transaction reversed", "success")
            End If
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- btnReverse_Click()", ex.ToString)
        End Try
    End Sub

    Protected Sub btnSearchDate_Click(sender As Object, e As EventArgs) Handles btnSearchDate.Click
        If Trim(txtDisbDate.Text) = "" Or Not IsDate(txtDisbDate.Text) Then
            notify("Enter valid date", "error")
        Else
            getBatchEntriesByDate(txtDisbDate.Text)
        End If
    End Sub

    Protected Sub cmbBatchNo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbBatchNo.SelectedIndexChanged
        getBatchEntries(cmbBatchNo.SelectedValue)
    End Sub

    Protected Sub getBatchEntries(bRef As String)
        Try
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                'Using cmd As New SqlCommand("select convert(varchar,TrxnDate,106) as [Date],Account,ContraAccount,Refrence,Description,Debit,Credit from [Accounts_Transactions_Temp] ac join quest_application qa on ac.Refrence=convert(varchar,qa.ID) where ([Authorized] is null or [Authorized]=0) and (Category='Loan Disbursement' or Category='Interest Payable') and ac.Refrence='" & bRef & "'", con)
                Using cmd As New SqlCommand("select convert(varchar,TrxnDate,106) as [Date],Account + ' - '+ qa.SURNAME+' '+qa.FORENAMES AS Account,ContraAccount,Refrence,Description,case when Category='Loan Disbursement' then Debit ELSE 0 end as [Principal Debit],case when Category='Loan Disbursement' then Credit else 0 end as [Principal Credit],case when Category='Interest Payable' then Debit ELSE 0 end as [Interest Debit],case when Category='Interest Payable' then Credit else 0 end as [Interest Credit] from [Accounts_Transactions_Temp] ac join quest_application qa on ac.Refrence=convert(varchar,qa.ID) where ([Authorized] is null or [Authorized]=0) and (Category='Loan Disbursement' or Category='Interest Payable') and ac.Refrence='" & bRef & "'", con)
                    Dim ds As New DataSet
                    Dim adp = New SqlDataAdapter(cmd)
                    adp.Fill(ds, "APP")
                    bindGrid(ds.Tables(0), grdDetails)
                End Using
            End Using
        Catch ex As Exception
            ErrorLogging.WriteLogFile(Session("UserId"), Request.Url.ToString & " --- loadBatchEntries()", ex.Message)
        End Try
    End Sub

    Protected Sub getBatchEntriesByDate(bDate As String)
        Try
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                'Using cmd As New SqlCommand("select convert(varchar,TrxnDate,106) as [Date],Account,ContraAccount,Refrence,Description,Debit,Credit from [Accounts_Transactions_Temp] ac join quest_application qa on ac.Refrence=convert(varchar,qa.ID) where ([Authorized] is null or [Authorized]=0) and (Category='Loan Disbursement' or Category='Interest Payable') and ac.TrxnDate='" & bDate & "'", con)
                Using cmd As New SqlCommand("select convert(varchar,TrxnDate,106) as [Date],Account + ' - '+ qa.SURNAME+' '+qa.FORENAMES AS Account,ContraAccount,Refrence,Description,case when Category='Loan Disbursement' then Debit ELSE 0 end as [Principal Debit],case when Category='Loan Disbursement' then Credit else 0 end as [Principal Credit],case when Category='Interest Payable' then Debit ELSE 0 end as [Interest Debit],case when Category='Interest Payable' then Credit else 0 end as [Interest Credit] from [Accounts_Transactions_Temp] ac join quest_application qa on ac.Refrence=convert(varchar,qa.ID) where ([Authorized] is null or [Authorized]=0) and (Category='Loan Disbursement' or Category='Interest Payable') and ac.TrxnDate='" & bDate & "'", con)
                    Dim ds As New DataSet
                    Dim adp = New SqlDataAdapter(cmd)
                    adp.Fill(ds, "APP")
                    bindGrid(ds.Tables(0), grdDetails)
                End Using
            End Using
        Catch ex As Exception
            ErrorLogging.WriteLogFile(Session("UserId"), Request.Url.ToString & " --- loadBatches()", ex.Message)
        End Try
    End Sub

    Protected Function getBatchNo() As String
        Try
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd As New SqlCommand("select max(isnull(nullif(SUBSTRING(BatchRef,4,10),''),0)) as MaxBatch from Accounts_Transactions where Category='Loan Disbursement'", con)
                    Dim ds As New DataSet
                    Dim adp = New SqlDataAdapter(cmd)
                    adp.Fill(ds, "APP")
                    Dim batchNo = ""
                    If ds.Tables(0).Rows(0).Item("MaxBatch") = 0 Then
                        batchNo = "10001"
                    Else
                        batchNo = ds.Tables(0).Rows(0).Item("MaxBatch") + 1
                    End If
                    Return "Dis" & batchNo
                End Using
            End Using
        Catch ex As Exception
            ErrorLogging.WriteLogFile(Session("UserId"), Request.Url.ToString & " --- getBatchNo()", ex.Message)
            Return "Dis10001"
        End Try
    End Function

    Protected Sub grdDetails_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles grdDetails.RowDataBound
        Try
            If e.Row.RowType = DataControlRowType.DataRow Or e.Row.RowType = DataControlRowType.EmptyDataRow Then
                Dim cred = IIf(Trim(e.Row.Cells(7).Text.ToString) = "&nbsp;", 0, e.Row.Cells(7).Text.ToString)
                Dim deb = IIf(Trim(e.Row.Cells(6).Text.ToString) = "&nbsp;", 0, e.Row.Cells(6).Text.ToString)
                Dim intCred = IIf(Trim(e.Row.Cells(9).Text.ToString) = "&nbsp;", 0, e.Row.Cells(9).Text.ToString)
                Dim intDeb = IIf(Trim(e.Row.Cells(8).Text.ToString) = "&nbsp;", 0, e.Row.Cells(8).Text.ToString)
                debTotal = debTotal + deb
                credTotal = credTotal + cred
                intDebTotal = intDebTotal + intDeb
                intCredTotal = intCredTotal + intCred
                e.Row.Cells(6).HorizontalAlign = HorizontalAlign.Right
                e.Row.Cells(7).HorizontalAlign = HorizontalAlign.Right
                e.Row.Cells(8).HorizontalAlign = HorizontalAlign.Right
                e.Row.Cells(9).HorizontalAlign = HorizontalAlign.Right
            ElseIf e.Row.RowType = DataControlRowType.Footer Then
                e.Row.Cells(0).Text = "Totals"
                e.Row.Cells(1).Text = FormatCurrency(debTotal).Replace("Z$", "&nbsp;&nbsp;&nbsp;")
                e.Row.Cells(2).Text = FormatCurrency(credTotal).Replace("Z$", "&nbsp;&nbsp;&nbsp;")
                e.Row.Cells(3).Text = FormatCurrency(intDebTotal).Replace("Z$", "&nbsp;&nbsp;&nbsp;")
                e.Row.Cells(4).Text = FormatCurrency(intCredTotal).Replace("Z$", "&nbsp;&nbsp;&nbsp;")
                e.Row.Cells(0).ColumnSpan = 6
                e.Row.Cells(1).HorizontalAlign = HorizontalAlign.Right
                e.Row.Cells(2).HorizontalAlign = HorizontalAlign.Right
                e.Row.Cells(3).HorizontalAlign = HorizontalAlign.Right
                e.Row.Cells(4).HorizontalAlign = HorizontalAlign.Right
                'e.Row.Cells(3).Visible = False
                'e.Row.Cells(4).Visible = False
                e.Row.Cells(5).Visible = False
                e.Row.Cells(6).Visible = False
                e.Row.Cells(7).Visible = False
                e.Row.Cells(8).Visible = False
                e.Row.Cells(9).Visible = False
            End If
        Catch ex As Exception
            ErrorLogging.WriteLogFile(Session("UserId"), Request.Url.ToString & " --- grdDetails_RowDataBound()", ex.ToString)
        End Try
    End Sub

    Protected Sub loadBatches()
        Try
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd As New SqlCommand("select distinct Refrence,Refrence + ' - ' + SURNAME + ' ' + FORENAMES + ' - ' + format(FIN_AMT,'c') as disp from [Accounts_Transactions_Temp] ac join quest_application qa on ac.Refrence=convert(varchar,qa.ID) where ([Authorized] is null or [Authorized]=0) and Category='Loan Disbursement'", con)
                    Dim ds As New DataSet
                    Dim adp = New SqlDataAdapter(cmd)
                    adp.Fill(ds, "APP")
                    loadCombo(ds.Tables(0), cmbBatchNo, "disp", "Refrence")
                End Using
            End Using
        Catch ex As Exception
            ErrorLogging.WriteLogFile(Session("UserId"), Request.Url.ToString & " --- loadBatches()", ex.ToString)
        End Try
    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Page.MaintainScrollPositionOnPostBack = True
        If Not IsPostBack Then
            loadBatches()
            getBatchEntries(cmbBatchNo.SelectedValue)
        End If
    End Sub
    Protected Sub rdbAuthBy_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rdbAuthBy.SelectedIndexChanged
        If rdbAuthBy.SelectedValue = "Batch" Then
            lblBatchNo.Visible = True
            cmbBatchNo.Visible = True
            lblDisbDate.Visible = False
            txtDisbDate.Visible = False
            spanDisbDate.Visible = False
            btnSearchDate.Visible = False
            cmbBatchNo.ClearSelection()
        ElseIf rdbAuthBy.SelectedValue = "Date" Then
            lblBatchNo.Visible = False
            cmbBatchNo.Visible = False
            lblDisbDate.Visible = True
            txtDisbDate.Visible = True
            spanDisbDate.Visible = True
            btnSearchDate.Visible = True
            txtDisbDate.Text = ""
        End If
        grdDetails.DataSource = Nothing
        grdDetails.DataBind()
    End Sub
End Class