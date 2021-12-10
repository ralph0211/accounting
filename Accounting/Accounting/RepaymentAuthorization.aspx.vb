Imports System.Data
Imports System.Data.SqlClient
Imports CreditManager
Imports ErrorLogging

Partial Class Accounting_RepaymentAuthorization
    Inherits System.Web.UI.Page

    Protected Sub btnAuthorize_Click(sender As Object, e As EventArgs) Handles btnAuthorize.Click
        Try
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd As New SqlCommand("CommitDisbursementRepayment", con)
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.AddWithValue("@loanID", cmbBatchNo.SelectedValue)
                    cmd.Parameters.AddWithValue("@BatchRef", getBatchNo())
                    cmd.Parameters.AddWithValue("@Category", "Loan Repayment")
                    con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                End Using
            End Using
            notify("Transaction authorized", "success")
        Catch ex As Exception
            ErrorLogging.WriteLogFile(Session("UserId"), "Accounting/RepaymentAuthorization---loadBatches()", ex.Message)
        End Try
    End Sub

    Protected Sub cmbBatchNo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbBatchNo.SelectedIndexChanged
        getBatchEntries(cmbBatchNo.SelectedValue)
    End Sub

    Protected Sub getBatchEntries(bRef As String)
        Try
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd As New SqlCommand("select convert(varchar,TrxnDate,106) as [Trxn Date],Category,Description,Account,ContraAccount,Refrence,Debit,Credit from [Accounts_Transactions_Temp] ac join quest_application qa on ac.Refrence=convert(varchar,qa.ID) where ([Authorized] is null or [Authorized]=0) and Category='Loan Repayment' and Refrence='" & bRef & "'", con)
                    Dim ds As New DataSet
                    Dim adp = New SqlDataAdapter(cmd)
                    adp.Fill(ds, "APP")
                    bindGrid(ds.Tables(0), grdDetails)
                End Using
            End Using
        Catch ex As Exception
            ErrorLogging.WriteLogFile(Session("UserId"), "Accounting/RepaymentAuthorization---getBatchEntries()", ex.Message)
        End Try
    End Sub

    Protected Sub loadBatches()
        Try
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd As New SqlCommand("select distinct Refrence,Refrence + ' - ' + SURNAME + ' ' + FORENAMES + ' - ' + format(FIN_AMT,'c') as disp from [Accounts_Transactions_Temp] ac join quest_application qa on ac.Refrence=convert(varchar,qa.ID) where ([Authorized] is null or [Authorized]=0) and Category='Loan Repayment'", con)
                    Dim ds As New DataSet
                    Dim adp = New SqlDataAdapter(cmd)
                    adp.Fill(ds, "APP")
                    loadCombo(ds.Tables(0), cmbBatchNo, "disp", "Refrence")
                End Using
            End Using
        Catch ex As Exception
            ErrorLogging.WriteLogFile(Session("UserId"), "Accounting/RepaymentAuthorization---loadBatches()", ex.Message)
        End Try
    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Page.MaintainScrollPositionOnPostBack = True
        If Not IsPostBack Then
            loadBatches()
            getBatchEntries(cmbBatchNo.SelectedValue)
        End If
    End Sub
    Protected Function getBatchNo() As String
        Try
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd As New SqlCommand("select max(isnull(nullif(SUBSTRING(BatchRef,4,10),''),0)) as MaxBatch from Accounts_Transactions where Category='Loan Repayment'", con)
                    Dim ds As New DataSet
                    Dim adp = New SqlDataAdapter(cmd)
                    adp.Fill(ds, "APP")
                    Dim batchNo = ""
                    If ds.Tables(0).Rows(0).Item("MaxBatch") = 0 Then
                        batchNo = "10001"
                    Else
                        batchNo = ds.Tables(0).Rows(0).Item("MaxBatch") + 1
                    End If
                    Return "Rep" & batchNo
                End Using
            End Using
        Catch ex As Exception
            ErrorLogging.WriteLogFile(Session("UserId"), "Accounting/RepaymentAuthorization---getBatchNo()", ex.Message)
            Return "Rep10001"
        End Try
    End Function
End Class