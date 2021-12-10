Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports CreditManager
Imports ErrorLogging

Partial Class Accounting_BudgetVarianceReport
    Inherits System.Web.UI.Page

    Protected Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        Try
            Dim EncQuery As New BankEncryption64
            Dim strscript As String
            strscript = "<script langauage=JavaScript>"
            strscript += "window.open('rptBudgetVariance.aspx?f" & EncQuery.Encrypt(txtDateFrom.Text) & "&t=" & EncQuery.Encrypt(txtDateTo.Text) & "')"
            strscript += "</script>"
            ClientScript.RegisterStartupScript(Me.GetType(), "newwin", strscript)
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- btnPrint_Click()", ex.ToString)
        End Try
    End Sub

    Private Sub Accounting_BudgetVarianceReport_Load(sender As Object, e As EventArgs) Handles Me.Load
        Page.MaintainScrollPositionOnPostBack = True
        If Not IsPostBack Then

        End If
    End Sub

End Class