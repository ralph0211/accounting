Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports CreditManager
Imports ErrorLogging
Imports System.Text.RegularExpressions

Partial Class Accounting_AccAuditTrail
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Page.MaintainScrollPositionOnPostBack = True
        If Not IsPostBack Then
        End If
    End Sub
    Protected Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        Try
            If cmbTrxnType.SelectedValue = "" Then
                notify("Select transaction type", "error")
                'ElseIf Not IsDate(bdpFromDate.Text) Then
                '    notify("Enter valid from date", "error")
                'ElseIf Not IsDate(bdpToDate.Text) Then
                '    notify("Enter valid to date", "error")
            Else
                Dim strscript As String
                strscript = "<script langauage=JavaScript>"
                strscript += "window.open('rptAccAudit.aspx?t=" & cmbTrxnType.SelectedValue & "&df=" & bdpFromDate.Text & "&dt=" & bdpToDate.Text & "&b=" & cmbBatchRef.SelectedValue & "')"
                strscript += "</script>"
                ClientScript.RegisterStartupScript(Me.GetType(), "newwin", strscript)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub cmbTrxnType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTrxnType.SelectedIndexChanged
        If cmbTrxnType.SelectedValue = "1" Then
            getBatchRef("Loan Disbursement")
        ElseIf cmbTrxnType.SelectedValue = "2" Then
            getBatchRef("Loan Repayment")
        ElseIf cmbTrxnType.SelectedValue = "4" Then
            getBatchRef("New Journal entry")
        ElseIf cmbTrxnType.SelectedValue = "5" Then
            getBatchRef("Receipt")
        Else
            getBatchRef("")
        End If
    End Sub

    Protected Sub getBatchRef(trxnType As String)
        Using con = New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
            Using cmd As New SqlCommand("select distinct BatchRef from Accounts_Transactions where Category='" & trxnType & "'", con)
                Dim ds As New DataSet
                Dim adp As New SqlDataAdapter(cmd)
                adp.Fill(ds, "btc")
                loadCombo(ds.Tables(0), cmbBatchRef, "BatchRef", "BatchRef")
            End Using
        End Using
    End Sub
End Class