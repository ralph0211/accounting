Partial Class Credit_frmSSBUploadRpt
    Inherits System.Web.UI.Page

    Protected Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        Try
            'If rdbRepType.SelectedValue = "1" Then 'full report
            If txtFileDate.Text = "" Then
                MsgBox("Select file date")
            Else
                Try
                    Dim strscript As String
                    Dim EncQuery As New BankEncryption64
                    strscript = "<script langauage=JavaScript>"
                    strscript += "window.open('rptSSBUpload.aspx?date=" & txtFileDate.Text & "');"
                    strscript += "</script>"
                    ClientScript.RegisterStartupScript(Me.GetType(), "newwin", strscript)
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class