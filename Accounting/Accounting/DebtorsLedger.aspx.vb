Imports CreditManager
Partial Class Accounting_DebtorsLedger
    Inherits System.Web.UI.Page

    Protected Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        Try
            If Not IsDate(txtDateFrom.Text) Then
                notify("Enter valid Date From", "error")
                txtDateFrom.Focus()
            ElseIf Not IsDate(txtDateTo.Text) Then
                notify("Enter valid Date To", "error")
                txtDateTo.Focus()
            Else
                Dim EncQry As New BankEncryption64
                Dim strscript As String
                strscript = "<script langauage=JavaScript>"
                'If cusType = "Group" Then
                '    strscript += "window.open('rptaccountStatementGroup.aspx')"
                'Else
                strscript += "window.open('rptDebtorsLedger.aspx?f=" & EncQry.Encrypt(txtDateFrom.Text) & "&t=" & EncQry.Encrypt(txtDateTo.Text) & "')"
                'End If
                strscript += "</script>"
                ClientScript.RegisterStartupScript(Me.GetType(), "newwin", strscript)
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
End Class
