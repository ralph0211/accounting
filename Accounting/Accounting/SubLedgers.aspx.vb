Imports System
Imports System.Data
Imports System.Data.SqlClient

Partial Class Accounting_SubLedgers
    Inherits System.Web.UI.Page
    Dim cmd As SqlCommand
    Dim con As New SqlConnection
    Dim adp As New SqlDataAdapter
    Dim connection As String

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Page.MaintainScrollPositionOnPostBack = True
        con = New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
        If Not IsPostBack Then
            Try
                'cmd = New SqlCommand("SELECT [MainAccount], convert(varchar,[MainAccount]) + ' - '+ [AccountName] as 'Name'  FROM [tbl_FinancialAccountsCreation] where SubAccount=1 ", con)
                cmd = New SqlCommand("SELECT convert(varchar,MainAccount) +'/'+ convert(varchar,subaccount) as Account, convert(varchar,[MainAccount]) +'/'+ convert(varchar,subaccount) + ' - '+ [AccountName] as 'Name'  FROM [tbl_FinancialAccountsCreation]-- where SubAccount=1", con)
                Dim ds As New DataSet
                adp = New SqlDataAdapter(cmd)
                adp.Fill(ds, "CUST")
                If ds.Tables(0).Rows.Count > 0 Then
                    cmbAccount.DataSource = ds
                    cmbAccount.DataTextField = "Name"
                    cmbAccount.DataValueField = "Account"
                    cmbAccount.Items.Add("-Select-")
                    cmbAccount.DataBind()
                End If

            Catch ex As Exception
                msgbox(ex.ToString)
            End Try
        End If
    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        lblSubName.Text = "Sub Ledger for: " & cmbAccount.SelectedItem.Text & " Account"
        Try
            'cmd = New SqlCommand("select isnull(Sum(isnull(Debit,0)) - SUM(isnull(Credit,0)),0) as Bbfwd from Accounts_Transactions a left outer join tbl_FinancialAccountsCreation b on a.Account= convert(varchar,b.mainaccount) +'/'+ convert(varchar,b.subaccount) where MainAccount='" & cmbAccount.SelectedValue & "' and TrxnDate<'" & dtpTrxnDate.Text & "'", con)
            cmd = New SqlCommand("select isnull(Sum(isnull(Debit,0)) - SUM(isnull(Credit,0)),0) as Bbfwd from Accounts_Transactions a left outer join tbl_FinancialAccountsCreation b on a.Account= convert(varchar,b.mainaccount) +'/'+ convert(varchar,b.subaccount) where convert(varchar,MainAccount) +'/'+ convert(varchar,subaccount)='" & cmbAccount.SelectedValue & "' and TrxnDate<'" & dtpTrxnDate.Text & "'", con)
            Dim dsBbfwd As New DataSet
            adp = New SqlDataAdapter(cmd)
            adp.Fill(dsBbfwd, "BBFWD")
            Dim bfwd = dsBbfwd.Tables(0).Rows(0).Item("Bbfwd")

            cmd = New SqlCommand("select convert(varchar,'" & dtpTrxnDate.Text & "',113) as [Transaction Date],'Balance B/Fwd' as [Trxn Type],'' as [Trxn ID],'' as Debit,'' as Credit, FORMAT(" & bfwd & ",N'N') as 'Cumulative Balance'", con)
            Dim dsLedger As New DataSet
            adp = New SqlDataAdapter(cmd)
            adp.Fill(dsLedger, "bf")
            '    MsgBox(cmbAccount.SelectedValue.ToString)
            cmd = New SqlCommand("SP_GetLedger", con)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@DATEFROM", dtpTrxnDate.Text)
            cmd.Parameters.AddWithValue("@DATETO", dtpTrxnDate0.Text)
            cmd.Parameters.AddWithValue("@ACCNO", cmbAccount.SelectedValue)
            Dim ds As New DataSet
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "LEDGERS")
            For Each row As DataRow In ds.Tables(0).Rows
                dsLedger.Tables(0).ImportRow(row)
            Next
            If ds.Tables(0).Rows.Count > 0 Then
                grd.DataSource = dsLedger
                grd.DataBind()
            Else
                grd.DataSource = Nothing
                grd.DataBind()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub cmbAccount_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbAccount.SelectedIndexChanged

    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim acc As String
        acc = cmbAccount.SelectedValue

        Session("Account") = acc
        Session("DateFrom") = dtpTrxnDate.Text
        Session("DateTo") = dtpTrxnDate0.Text
        Try
            Dim strscript As String
            strscript = "<script langauage=JavaScript>"
            strscript += "window.open('RptDetailedLedger.aspx')"
            strscript += "</script>"
            ClientScript.RegisterStartupScript(Me.GetType(), "newwin", strscript)
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub msgbox(ByVal strMessage As String)

        'finishes server processing, returns to client.
        Dim strScript As String = "<script language=JavaScript>"
        strScript += "window.alert(""" & strMessage & """);"
        strScript += "</script>"
        Dim lbl As New System.Web.UI.WebControls.Label
        lbl.Text = strScript
        Page.Controls.Add(lbl)

    End Sub
End Class