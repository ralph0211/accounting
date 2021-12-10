Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports CreditManager
Imports ErrorLogging

Partial Class Accounting_GeneralLedger
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            Page.MaintainScrollPositionOnPostBack = True
            If Not IsPostBack Then
                loadFinAccounts()
            End If
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- Page_Load()", ex.ToString)
        End Try
    End Sub

    Protected Sub loadFinAccounts()
        Try
            Using con = New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                'Using cmd = New SqlCommand("select AccountName + ' ' + convert(varchar,MainAccount) +'/'+ convert(varchar,SubAccount) as AccountName,convert(varchar,MainAccount) +'/'+ convert(varchar,SubAccount) as Acc from tbl_FinancialAccountsCreation order BY MainAccount,SubAccount", con)
                Using cmd = New SqlCommand("select AccountName + ' | ' + convert(varchar,MainAccount) as AccountName, convert(varchar,MainAccount) as 'Accno' from tbl_FinancialAccountsCreation union select accountName + ' | ' + accountNo as AccountName,accountNo AS Accno from cashbookaccounts union select accountName + ' | ' + accountNo as AccountName,accountNo AS Accno from CreditorAccounts union select accountName + ' | ' + accountNo as AccountName,accountNo AS Accno from DebtorAccounts order by 'AccountName'", con)
                    Dim ds As New DataSet
                    Using adp = New SqlDataAdapter(cmd)
                        adp.Fill(ds, "AccountsTypes")
                    End Using
                    loadCombo(ds.Tables(0), cmbAccount, "AccountName", "AccNo")
                End Using
            End Using
        Catch ex As Exception
            msgbox(ex.Message)
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- loadFinAccounts()", ex.ToString)
        End Try
    End Sub
    Protected Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        Try
            If Not IsDate(txtFromDate.Text) Or Not IsDate(txtToDate.Text) Then
                notify("Enter valid date range", "error")
            Else
                Dim DecQuery As New BankEncryption64
                Dim strscript As String
                strscript = "<script langauage=JavaScript>"
                If cmbAccount.SelectedValue = "" Then
                    strscript += "window.open('rptGeneralLedger.aspx?f=" & DecQuery.Encrypt(txtFromDate.Text) & "&t=" & DecQuery.Encrypt(txtToDate.Text) & "')"
                Else
                    strscript += "window.open('rptGeneralLedger.aspx?f=" & DecQuery.Encrypt(txtFromDate.Text) & "&t=" & DecQuery.Encrypt(txtToDate.Text) & "&a=" & DecQuery.Encrypt(cmbAccount.SelectedValue) & "')"
                End If
                strscript += "</script>"
                ClientScript.RegisterStartupScript(Me.GetType(), "newwin", strscript)
            End If
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- btnPrint_Click()", ex.ToString)

        End Try
    End Sub
End Class