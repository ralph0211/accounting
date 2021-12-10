Imports System.Data
Imports System.Data.SqlClient

Partial Class Accounting_rptTrialBalanceFull
    Inherits System.Web.UI.Page
    Dim adp As New SqlDataAdapter
    Dim cmd As SqlCommand
    Dim con As New SqlConnection

    Dim debTotal = 0, credTotal = 0

    Public Sub msgbox(ByVal strMessage As String)

        'finishes server processing, returns to client.
        Dim strScript As String = "<script language=JavaScript>"
        strScript += "window.alert(""" & strMessage & """);"
        strScript += "</script>"
        Dim lbl As New System.Web.UI.WebControls.Label
        lbl.Text = strScript
        Page.Controls.Add(lbl)

    End Sub

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

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        lblDateFrom.Text = Session("Date").ToString
        Page.MaintainScrollPositionOnPostBack = True
        con = New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
        If Not IsPostBack Then
            Try
                Dim txt As String = ""
                txt = txt + "select AccNo,AccountName as [Description],-(  case when (sum(Bal)) <=  0 then sum(Bal) else null end)  as 'Debit', case when (sum(Bal))  >0 then sum(Bal)  end as Credit from ("
                txt = txt + " select  case when ISNUMERIC(Account)=1 then 'SW' when ISNUMERIC(Account)=0 then left(account,CHARINDEX('/',account)-1) end as AccNo,sum(debit) as Debit,sum(credit) as Credit,sum(credit)-sum(debit) as Bal from Accounts_Transactions where TrxnDate<='" & Session("Date").ToString & "' group by case when ISNUMERIC(Account)=1 then 'SW' when ISNUMERIC(Account)=0 then left(account,CHARINDEX('/',account)-1) end"
                txt = txt + " UNION select  '211' as AccNo,sum(debit) as Debit,sum(credit) as Credit,sum(Credit)-sum(Debit) as Bal from Accounts_Transactions where TrxnDate <= '" & Session("Date").ToString & "' AND Description='Interest Repayment' AND Account LIKE 'SW/%' group by TrxnDate,Description"
                txt = txt + " UNION select  '223' as AccNo,sum(debit) as Debit,sum(credit) as Credit,sum(Debit)-sum(Credit) as Bal from Accounts_Transactions where TrxnDate <= '" & Session("Date").ToString & "' AND Description='Interest Repayment' AND Account LIKE 'SW/%' group by TrxnDate,Description"
                txt = txt + " )tblTrxn join"
                txt = txt + " tbl_FinancialAccountsCreation fin on tblTrxn.AccNo=fin.MainAccount"
                txt = txt + " where fin.subaccount=1 group by accno,accountname order by accno"

                cmd = New SqlCommand(txt, con)
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
End Class