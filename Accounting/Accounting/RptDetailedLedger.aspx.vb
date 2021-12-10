Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports PasSDK

Partial Class Accounting_RptDetailedLedger
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

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Page.MaintainScrollPositionOnPostBack = True
        con = New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
        If Not IsPostBack Then

            lblAccount.Text = Session("Account").ToString
            lblDateFrom.Text = Session("DateFrom").ToString
            lblDateTo.Text = Session("DateTo").ToString
           
            Try
                'cmd = New SqlCommand("SP_GetLedger", con)
                'cmd.CommandType = CommandType.StoredProcedure
                'cmd.Parameters.AddWithValue("@DATEFROM", Session("DateFrom").ToString)
                'cmd.Parameters.AddWithValue("@DATETO", Session("DateTo").ToString)
                'cmd.Parameters.AddWithValue("@ACCNO", Session("Account").ToString)

                'Dim ds As New DataSet
                'adp = New SqlDataAdapter(cmd)
                'adp.Fill(ds, "LEDGERS")
                'If ds.Tables(0).Rows.Count > 0 Then
                '    grd.DataSource = ds
                '    grd.DataBind()
                'Else
                '    grd.DataSource = Nothing
                '    grd.DataBind()
                'End If


                'cmd = New SqlCommand("select isnull(Sum(isnull(Debit,0)) - SUM(isnull(Credit,0)),0) as Bbfwd from Accounts_Transactions where TrxnDate<='" & Session("DateFrom").ToString & "'", con)
                cmd = New SqlCommand("select isnull(Sum(isnull(Debit,0)) - SUM(isnull(Credit,0)),0) as Bbfwd from Accounts_Transactions a left outer join tbl_FinancialAccountsCreation b on a.Account= convert(varchar,b.mainaccount) +'/'+ convert(varchar,b.subaccount) where convert(varchar,b.mainaccount) +'/'+ convert(varchar,b.subaccount)='" & Session("Account").ToString & "' and TrxnDate<'" & Session("DateFrom").ToString & "'", con)
                Dim dsBbfwd As New DataSet
                adp = New SqlDataAdapter(cmd)
                adp.Fill(dsBbfwd, "BBFWD")
                Dim bfwd = dsBbfwd.Tables(0).Rows(0).Item("Bbfwd")

                cmd = New SqlCommand("select convert(varchar,'" & Session("DateFrom").ToString & "',113) as [Transaction Date],'Balance B/Fwd' as [Trxn Type],'' as [Trxn ID],'' as Debit,'' as Credit, FORMAT(" & bfwd & ",N'N') as 'Cumulative Balance'", con)
                Dim dsLedger As New DataSet
                adp = New SqlDataAdapter(cmd)
                adp.Fill(dsLedger, "bf")
                '    MsgBox(cmbAccount.SelectedValue.ToString)
                cmd = New SqlCommand("SP_GetLedger", con)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("@DATEFROM", Session("DateFrom").ToString)
                cmd.Parameters.AddWithValue("@DATETO", Session("DateTo").ToString)
                cmd.Parameters.AddWithValue("@ACCNO", Session("Account").ToString)
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
                msgbox(ex.ToString)
            End Try
        End If
    End Sub
End Class
