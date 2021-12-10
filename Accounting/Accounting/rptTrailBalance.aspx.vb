Imports System.Data
Imports System.Data.SqlClient
Partial Class QUEST_Accounting_rptTrailBalance
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

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        lblDateFrom.Text = Session("Date").ToString
        Page.MaintainScrollPositionOnPostBack = True
        con = New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
        If Not IsPostBack Then
            Try
                cmd = New SqlCommand("select distinct a.account [AccNo], isnull(b.AccountName,isnull(c.surname,'')+' '+isnull(c.forenames,'')) as 'Description', -(  case when (isnull(sum(Credit),0.00)-isnull(sum(Debit),0.00)) <=  0 then isnull(sum(Credit),0.00)-isnull(sum(Debit),0.00) else null end)  as 'Debit', case when (isnull(sum(Credit),0.00)-isnull(sum(Debit),0.00))  >0 then isnull(sum(Credit),0.00)-isnull(sum(Debit),0.00)  end as Credit from Accounts_Transactions a  left join tbl_FinancialAccountsCreation b on convert(varchar,b.MainAccount)+'/'+convert(varchar,b.subaccount)=a.account left join CUSTOMER_DETAILS c on a.Account=c.CUSTOMER_NUMBER  where a.TrxnDate<='" & Session("Date") & "' and convert(numeric(18,0),RIGHT(account,LEN(Account)-CHARINDEX('/',Account)))>1 group by a.account,b.AccountName, b.sub,c.customer_number,c.SURNAME,c.forenames", con)
                Dim ds As New DataSet
                adp = New SqlDataAdapter(cmd)
                adp.Fill(ds, "TB")
                If ds.Tables(0).Rows.Count > 0 Then
                    grdDetails.DataSource = ds.Tables("TB")
                    grdDetails.DataBind()
                Else
                    grdDetails.DataSource = Nothing
                    grdDetails.DataBind()
                End If
            Catch ex As Exception
                msgbox(ex.Message)
            End Try
        End If
    End Sub

    Dim debTotal = 0, credTotal = 0

    Protected Sub grdDetails_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles grdDetails.RowDataBound
        Try
            If e.Row.RowType = DataControlRowType.DataRow Or e.Row.RowType = DataControlRowType.EmptyDataRow Then
                Dim cred = IIf(Trim(e.Row.Cells(3).Text.ToString) = "&nbsp;", 0, e.Row.Cells(3).Text.ToString)
                Dim deb = IIf(Trim(e.Row.Cells(2).Text.ToString) = "&nbsp;", 0, e.Row.Cells(2).Text.ToString)
                debTotal = debTotal + deb
                credTotal = credTotal + cred
            ElseIf e.Row.RowType = DataControlRowType.Footer Then
                e.Row.Cells(0).Text = "Totals"
                e.Row.Cells(2).Text = FormatCurrency(debTotal).Replace("Z", "US")
                e.Row.Cells(3).Text = FormatCurrency(credTotal).Replace("Z", "US")
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
End Class