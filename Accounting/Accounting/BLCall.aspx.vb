Imports System.Data

Partial Class Accounting_BLCall
    Inherits System.Web.UI.Page
    Public Sub msgbox(ByVal strMessage As String)

        'finishes server processing, returns to client.
        Dim strScript As String = "<script language=JavaScript>"
        strScript += "window.alert(""" & strMessage & """);"
        strScript += "</script>"
        Dim lbl As New System.Web.UI.WebControls.Label
        lbl.Text = strScript
        Page.Controls.Add(lbl)

    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Session("DateFrom") = dtpTrxnDate.Text
        Session("DateTo") = dtpTrxnDate0.Text

        'Dim ds As New DataSet
        'Dim dt As New dsAllReports.BalanceSheetDataTable
        'Dim dss As New dsAllReportsTableAdapters.BalanceSheetTableAdapter
        'dss.Fill(dt, CDate(dtpTrxnDate0.Text))
        'If dt.Rows.Count > 0 Then
        '    msgbox(dt.Rows.Count)
        'Else
        '    msgbox("Nothing")
        'End If
        Dim EncQuery As New BankEncryption64
        Try
            Dim strscript As String
            strscript = "<script langauage=JavaScript>"
            strscript += "window.open('rptBL.aspx?id=" & HttpUtility.UrlEncode(EncQuery.Encrypt(dtpTrxnDate0.Text, "taDz392018hbdER")) & "')"
            strscript += "</script>"
            ClientScript.RegisterStartupScript(Me.GetType(), "newwin", strscript)
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
End Class