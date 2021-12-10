Imports System.Data
Imports System.Data.SqlClient
Imports CreditManager
Imports ErrorLogging
Imports BankString

Partial Class Accounting_TransactionReversal
    Inherits System.Web.UI.Page

    Protected Sub rdbTrxnType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rdbTrxnType.SelectedIndexChanged
        Try
            grdDetails.DataSource = Nothing
            grdDetails.DataBind()
            cmbTransactionDetails.Items.Clear()
            If rdbTrxnType.SelectedValue = "Journal" Then
                loadJournals()
            ElseIf rdbTrxnType.SelectedValue = "Disbursement" Then
                loadDisbursements()
            ElseIf rdbTrxnType.SelectedValue = "Repayment" Then
                loadRepayments()
            End If
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- rdbTrxnType_SelectedIndexChanged()", ex.ToString)
        End Try
    End Sub

    Private Sub Accounting_TransactionReversal_Load(sender As Object, e As EventArgs) Handles Me.Load
        Page.MaintainScrollPositionOnPostBack = True
        If Not IsPostBack Then

        End If
    End Sub

    Protected Sub loadJournals()
        Try
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd As New SqlCommand("select BatchNo,BatchName+' --- '+BatchNo as Name from [tbl_BatchRec] where status=1", con)
                    Dim dt As New DataTable
                    Using adp = New SqlDataAdapter(cmd)
                        adp.Fill(dt)
                    End Using
                    loadCombo(dt, cmbTransactionDetails, "Name", "BatchNo")
                End Using
            End Using
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- loadJournals()", ex.ToString)
        End Try
    End Sub

    Protected Sub loadDisbursements()
        Try
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd As New SqlCommand("select id,isnull(SURNAME,'')+' '+isnull(FORENAMES,'')+' --- '+convert(varchar,DISBURSED_DATE,106)+' --- '+format(isnull(nullif(RECOMMENDED_AMT,0),[FIN_AMT]),'c') as Name from [QUEST_APPLICATION] where DISBURSED=1", con)
                    Dim dt As New DataTable
                    Using adp = New SqlDataAdapter(cmd)
                        adp.Fill(dt)
                    End Using
                    loadCombo(dt, cmbTransactionDetails, "Name", "id")
                End Using
            End Using
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- loadDisbursements()", ex.ToString)
        End Try
    End Sub

    Protected Sub loadRepayments()
        Try
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd As New SqlCommand("select ReceiptNo,isnull(SURNAME,'')+' '+isnull(FORENAMES,'')+' --- '+convert(varchar,r.TrxnDate,106)+' --- '+format(isnull(r.TotalAmount,0),'c')+' --- '+r.ReceiptNo as Name from Repayments r LEFT join QUEST_APPLICATION q ON r.LoanID=q.ID", con)
                    Dim dt As New DataTable
                    Using adp = New SqlDataAdapter(cmd)
                        adp.Fill(dt)
                    End Using
                    loadCombo(dt, cmbTransactionDetails, "Name", "ReceiptNo")
                End Using
            End Using
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- loadRepayments()", ex.ToString)
        End Try
    End Sub

    Protected Sub cmbTransactionDetails_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTransactionDetails.SelectedIndexChanged
        Try
            grdDetails.DataSource = Nothing
            grdDetails.DataBind()
            getTransactionDetails(rdbTrxnType.SelectedValue, cmbTransactionDetails.SelectedValue)
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- cmbTransactionDetails_SelectedIndexChanged()", ex.ToString)
        End Try
    End Sub

    Protected Sub getTransactionDetails(trxnType As String, trxnID As String)
        Try
            If trxnType = "Journal" Then
                Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                    Using cmd As New SqlCommand("select Type,Category,convert(varchar,TrxnDate,106) as [Date],Account,ContraAccount as [Contra],Refrence as [Reference],[Description],Debit,Credit from [Accounts_Transactions] where BatchRef='" & trxnID & "'", con)
                        Dim dt As New DataTable
                        Using adp = New SqlDataAdapter(cmd)
                            adp.Fill(dt)
                        End Using
                        bindGrid(dt, grdDetails)
                    End Using
                End Using
            ElseIf trxnType = "Disbursement" Then
                Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                    Using cmd As New SqlCommand("select Type,Category,convert(varchar,TrxnDate,106) as [Date],Account,ContraAccount as [Contra],Refrence as [Reference],[Description],Debit,Credit,BankAccName as [Voucher Number] from [Accounts_Transactions] where Refrence='" & trxnID & "' and (category like '%Disbursement%' or  category like '%Disbursment%')", con)
                        Dim dt As New DataTable
                        Using adp = New SqlDataAdapter(cmd)
                            adp.Fill(dt)
                        End Using
                        bindGrid(dt, grdDetails)
                    End Using
                End Using
            ElseIf trxnType = "Repayment" Then
                Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                    Using cmd As New SqlCommand("select Type,Category,convert(varchar,TrxnDate,106) as [Date],Account,ContraAccount as [Contra],Refrence as [Reference],[Description],Debit,Credit,BankAccName as [Receipt Number] from [Accounts_Transactions] where BankAccName='" & trxnID & "' and category like '%Repayment%'", con)
                        Dim dt As New DataTable
                        Using adp = New SqlDataAdapter(cmd)
                            adp.Fill(dt)
                        End Using
                        bindGrid(dt, grdDetails)
                    End Using
                End Using
            End If
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- getTransactionDetails()", ex.ToString)
        End Try
    End Sub
    Protected Sub btnReverse_Click(sender As Object, e As EventArgs) Handles btnReverse.Click
        Try
            If rdbTrxnType.SelectedIndex = -1 Then
                notify("Select the transaction type", "error")
            ElseIf Trim(txtReverseDate.Text) = "" Or Not IsDate(txtReverseDate.Text) Then
                notify("Select the transaction date", "error")
            Else
                Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                    Using cmd As New SqlCommand("reverseTransaction", con)
                        cmd.CommandType = CommandType.StoredProcedure
                        cmd.Parameters.AddWithValue("@trxnType", rdbTrxnType.SelectedValue)
                        cmd.Parameters.AddWithValue("@trxnID", cmbTransactionDetails.SelectedValue)
                        cmd.Parameters.AddWithValue("@trxnDate", txtReverseDate.Text)
                        cmd.Parameters.AddWithValue("@trxnDesc", txtReverseDesc.Text)
                        cmd.Parameters.AddWithValue("@userID", Session("UserId"))
                        con.Open()
                        If cmd.ExecuteNonQuery Then
                            notify("Transaction reversed", "success")
                            rdbTrxnType.ClearSelection()
                            cmbTransactionDetails.Items.Clear()
                            txtReverseDate.Text = ""
                            txtReverseDesc.Text = ""
                            grdDetails.DataSource = Nothing
                            grdDetails.DataBind()
                        Else
                            notify("Error reversing transaction", "error")
                        End If
                        con.Close()
                    End Using
                End Using
            End If
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- btnReverse_Click()", ex.ToString)
        End Try
    End Sub
End Class