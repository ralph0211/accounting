Partial Class Accounting_TrailBalance
    Inherits System.Web.UI.Page

    Protected Sub Button1_Click(sender As Object, e As System.EventArgs) Handles Button1.Click
        If rdbReportType.SelectedIndex = -1 Then
            CreditManager.notify("Select report type", "error")
        ElseIf dtpTrxnDate.Text = "" Or Not IsDate(dtpTrxnDate.Text) Then
            CreditManager.notify("Enter the date to print", "error")
        Else
            Dim EncQuery As New BankEncryption64
            Session("Date") = dtpTrxnDate.Text
            If rdbReportType.SelectedValue = "Main" Then
                Try
                    Dim strscript As String
                    strscript = "<script langauage=JavaScript>"
                    'strscript += "window.open('rptTrialBalanceFull.aspx')"
                    strscript += "window.open('rptTrialBalanceRpt.aspx?d=" & EncQuery.Encrypt(dtpTrxnDate.Text) & "&m=1')"
                    strscript += "</script>"
                    ClientScript.RegisterStartupScript(Me.GetType(), "newwin", strscript)
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            ElseIf rdbReportType.SelectedValue = "Detail" Then
                Try
                    Dim strscript As String
                    strscript = "<script langauage=JavaScript>"
                    'strscript += "window.open('rptTrailBalance.aspx')"
                    strscript += "window.open('rptTrialBalanceRpt.aspx?d=" & EncQuery.Encrypt(dtpTrxnDate.Text) & "&m=0')"
                    strscript += "</script>"
                    ClientScript.RegisterStartupScript(Me.GetType(), "newwin", strscript)
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End If
        End If

    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Page.MaintainScrollPositionOnPostBack = True
        If Not IsPostBack Then
            Try

            Catch ex As Exception

            End Try
        End If
    End Sub
End Class