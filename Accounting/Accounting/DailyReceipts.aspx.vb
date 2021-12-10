Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports CreditManager

Partial Class Accounting_DailyReceipts
    Inherits System.Web.UI.Page
    Dim cmd As SqlCommand
    Dim con As New SqlConnection
    Dim adp As New SqlDataAdapter
    Dim connection As String
    Public Sub msgbox(ByVal strMessage As String)

        'finishes server processing, returns to client.
        Dim strScript As String = "<script language=JavaScript>"
        strScript += "window.alert(""" & strMessage & """);"
        strScript += "</script>"
        Dim lbl As New System.Web.UI.WebControls.Label
        lbl.Text = strScript
        Page.Controls.Add(lbl)

    End Sub

    Protected Sub btnSearchDate_Click(sender As Object, e As EventArgs) Handles btnSearchDate.Click
        getUnclearedReceipts(bdpDate.Text)
    End Sub

    Protected Sub getUnclearedReceipts(recDate As String)
        Try
            'cmd = New SqlCommand("select att.Type,att.Category,att.TrxnDate,att.Account,att.ContraAccount,att.Refrence,att.Description,att.Debit,att.Credit,mu.USER_LOGIN as 'Captured By',att.CaptureDate as 'Date Captured' from Accounts_Transactions_Temp att join master_users mu on att.CapturedBy=mu.USERID where (Authorized<>1 or Authorized is null) and TrxnDate='" & recDate & "'", con)
            cmd = New SqlCommand("select att.Type,att.Category,att.TrxnDate,att.Account,att.ContraAccount,att.Refrence,att.Description,att.Debit,att.Credit,att.CapturedBy as 'Captured By',att.CaptureDate as 'Date Captured' from Accounts_Transactions_Temp att where (Authorized<>1 or Authorized is null) and TrxnDate='" & recDate & "' and ([Type]='Receipt' or [Type]='Cash')", con)
            Dim ds As New DataSet
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "ATT")
            If ds.Tables(0).Rows.Count > 0 Then
                'fill grid
                grdReceipts.DataSource = ds.Tables(0)
            Else
                grdReceipts.DataSource = Nothing
            End If
            grdReceipts.DataBind()
            calcTotal(recDate)
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub calcTotal(recDate As String)
        Try
            Dim cmdSum = New SqlCommand("select FORMAT(isnull(SUM(att.Credit),0),'c') as [Total] from Accounts_Transactions_Temp att where (Authorized<>1 or Authorized is null) and TrxnDate='" & recDate & "' and ([Type]='Receipt' or [Type]='Cash')", con)
            Dim dsSum As New DataSet
            Dim adpSum As New SqlDataAdapter
            adpSum = New SqlDataAdapter(cmdSum)
            adpSum.Fill(dsSum, "tot")
            lblRecTotal.Text = dsSum.Tables(0).Rows(0).Item("Total").ToString
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnCommit_Click(sender As Object, e As EventArgs) Handles btnCommit.Click
        Try
            If Trim(bdpDate.Text) = "" Or Not IsDate(bdpDate.Text) Then
                msgbox("Please enter the date to commit")
            Else
                cmd = New SqlCommand("CommitAccountsTrxns", con)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("@TrxnDate", bdpDate.Text)
                If con.State <> ConnectionState.Closed Then
                    con.Close()
                End If
                con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
                msgbox("Receipts committed")
                getUnclearedReceipts(bdpDate.Text)
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Page.MaintainScrollPositionOnPostBack = True
        con = New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
        If Not IsPostBack Then
        End If
    End Sub
End Class