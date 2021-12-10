Imports System
Imports System.Data
Imports System.Data.SqlClient

Partial Class Accounting_CashBankAccount
    Inherits System.Web.UI.Page
    Dim cmd As SqlCommand
    Dim con As New SqlConnection
    Dim adp As New SqlDataAdapter

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

        End If
    End Sub
    Protected Sub RadioButtonList1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rdType.SelectedIndexChanged
        'If rdType.SelectedIndex = 1 Then
        '    loadBanks()
        '    cmbAccount.Visible = True
        '    lblAccount.Visible = True
        'ElseIf rdType.SelectedIndex = 2 Then
        '    loadIndvAccs()
        '    cmbAccount.Visible = True
        '    lblAccount.Visible = True
        'ElseIf rdType.SelectedIndex = 3 Then
        '    loadFinAccounts()
        '    cmbAccount.Visible = True
        '    lblAccount.Visible = True
        'Else
        '    loadCash()
        '    cmbAccount.Visible = True
        '    lblAccount.Visible = True
        'End If
        If rdType.SelectedIndex <> -1 Then
            cmbAccount.Visible = True
            lblAccount.Visible = True
            If rdType.SelectedValue = "Cashbook" Then
                loadCashbook()
            ElseIf rdType.SelectedValue = "Creditors" Then
                loadCreditors()
            ElseIf rdType.SelectedValue = "Debtors" Then
                loadDebtors()
            ElseIf rdType.SelectedValue = "Loans" Then
                loadIndvAccs()
            ElseIf rdType.SelectedValue = "Other" Then
                loadFinAccounts()
            End If
        End If
    End Sub

    Protected Sub loadFinAccounts()
        Try
            'cmd = New SqlCommand("select AccountName + ' ' + convert(varchar,MainAccount) +'/'+ convert(varchar,SubAccount) as AccountName,convert(varchar,MainAccount) +'/'+ convert(varchar,SubAccount) as Acc from tbl_FinancialAccountsCreation where SubAccount<>1", con)
            Using cmd = New SqlCommand("select AccountName + ' | ' + convert(varchar,MainAccount) as AccountName, convert(varchar,MainAccount) as 'Accno' from tbl_FinancialAccountsCreation union select Distinct(isnull([SURNAME],'')+' '+ isnull([FORENAMES],'') + ' | ' + isnull(CUSTOMER_NUMBER,'')) as AccountName, CUSTOMER_NUMBER as 'Accno' from CUSTOMER_DETAILS union select accountName + ' | ' + accountNo as AccountName,accountNo AS Accno from cashbookaccounts union select accountName + ' | ' + accountNo as AccountName,accountNo AS Accno from CreditorAccounts union select accountName + ' | ' + accountNo as AccountName,accountNo AS Accno from DebtorAccounts order by 'AccountName'", con)
                Dim ds As New DataSet
                adp = New SqlDataAdapter(cmd)
                adp.Fill(ds, "AccountsTypes")
                CreditManager.loadCombo(ds.Tables(0), cmbAccount, "AccountName", "AccNo")
            End Using
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub loadBanks()
        Try
            Using cmd = New SqlCommand("select AccountName + ' ' + convert(varchar,MainAccount) +'/'+ convert(varchar,SubAccount) as AccountName,convert(varchar,MainAccount) +'/'+ convert(varchar,SubAccount) as Acc from [tbl_FinancialAccountsCreation] where MainAccount='212' and SubAccount<>1", con)
                Dim ds As New DataSet
                adp = New SqlDataAdapter(cmd)
                adp.Fill(ds, "banks")
                CreditManager.loadCombo(ds.Tables(0), cmbAccount, "AccountName", "Acc")
            End Using
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub loadCreditors()
        Try
            Using cmd = New SqlCommand("select accountName + ' | ' + accountNo as AccountName,accountNo AS Accno from CreditorAccounts", con)
                Dim ds As New DataSet
                adp = New SqlDataAdapter(cmd)
                adp.Fill(ds, "banks")
                CreditManager.loadCombo(ds.Tables(0), cmbAccount, "AccountName", "Accno")
            End Using
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub loadDebtors()
        Try
            Using cmd = New SqlCommand("select accountName + ' | ' + accountNo as AccountName,accountNo AS Accno from DebtorAccounts", con)
                Dim ds As New DataSet
                adp = New SqlDataAdapter(cmd)
                adp.Fill(ds, "banks")
                CreditManager.loadCombo(ds.Tables(0), cmbAccount, "AccountName", "Accno")
            End Using
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Protected Sub loadCashbook()
        Try
            Using cmd = New SqlCommand("select accountName + ' | ' + accountNo as AccountName,accountNo AS Accno from cashbookaccounts", con)
                Dim ds As New DataSet
                adp = New SqlDataAdapter(cmd)
                adp.Fill(ds, "banks")
                CreditManager.loadCombo(ds.Tables(0), cmbAccount, "AccountName", "Accno")
            End Using
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub loadIndvAccs()
        Try
            Using cmd = New SqlCommand("select Distinct case when sub_individual='PDAs' and (PDACode is not null and ltrim(PDACode)<>'') then (isnull([SURNAME],'')+' '+ isnull([FORENAMES],'') + ' ('+ isnull(pdacode,'') +') | ' + CUSTOMER_NUMBER) else (isnull([SURNAME],'')+' '+ isnull([FORENAMES],'') + ' | ' + CUSTOMER_NUMBER) end as Name, CUSTOMER_NUMBER from CUSTOMER_DETAILS order by 'Name'", con)
                Dim ds As New DataSet
                adp = New SqlDataAdapter(cmd)
                adp.Fill(ds, "QUEST_APPLICATION")
                CreditManager.loadCombo(ds.Tables(0), cmbAccount, "Name", "CUSTOMER_NUMBER")
            End Using
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub btnSaveTrxn3_Click(sender As Object, e As EventArgs) Handles btnSaveTrxn3.Click
        Session("AccNo") = ""
        Session("Type") = rdType.SelectedItem.Text
        Session("DateFrom") = dtpTrxnDate.Text
        Session("DateTo") = dtpTrxnDate0.Text
        Dim cusType = ""
        If rdType.SelectedIndex = 0 Then
            Session("Account") = cmbAccount.SelectedItem.Text
            'Session("Account") = cmbAccount.SelectedValue
            'Session("AccNo") = rdType.SelectedValue
            Session("AccNo") = cmbAccount.SelectedValue
        ElseIf rdType.SelectedIndex = 1 Then
            'Session("Account") = rdType.SelectedItem.Text
            Session("Account") = cmbAccount.SelectedItem.Text
            Session("AccNo") = cmbAccount.SelectedValue
        ElseIf rdType.SelectedIndex = 2 Then
            Session("Account") = cmbAccount.SelectedItem.Text
            Session("AccNo") = cmbAccount.SelectedValue
        Else
            cusType = getCustType(cmbAccount.SelectedValue)
            'Session("Account") = rdType.SelectedItem.Text
            'Session("AccNo") = rdType.SelectedValue
            Session("Account") = cmbAccount.SelectedItem.Text
            Session("AccNo") = cmbAccount.SelectedValue
        End If

        Try
            Dim strscript As String
            strscript = "<script langauage=JavaScript>"
            If cusType = "Group" Then
                strscript += "window.open('rptaccountStatementGroup.aspx')"
            Else
                strscript += "window.open('rptaccountStatement.aspx')"
            End If
            strscript += "</script>"
            ClientScript.RegisterStartupScript(Me.GetType(), "newwin", strscript)
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Function getCustType(lID As String) As String
        Try
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd = New SqlCommand("select CUSTOMER_TYPE from CUSTOMER_DETAILS where CUSTOMER_NUMBER='" & lID & "'", con)
                    Dim custType = ""
                    If con.State = ConnectionState.Open Then
                        con.Close()
                    End If
                    Try
                        con.Open()
                        custType = cmd.ExecuteScalar
                        con.Close()
                    Catch ex As Exception
                        custType = ""
                    End Try
                    Return custType
                End Using
            End Using
        Catch ex As Exception
            ErrorLogging.WriteLogFile(Session("UserId"), Request.Url.ToString & " --- getCustType()", ex.ToString)
            Return ""
        End Try
    End Function
End Class