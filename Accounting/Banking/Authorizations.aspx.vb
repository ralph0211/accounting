Imports System.Data
Imports System.Data.SqlClient
Imports CreditManager
Imports ErrorLogging
Partial Class Banking_Authorizations
    Inherits System.Web.UI.Page

    Private Sub Banking_Authorizations_Load(sender As Object, e As EventArgs) Handles Me.Load
        Page.MaintainScrollPositionOnPostBack = True
        If Not IsPostBack Then
            getAuthorizations()
        End If
    End Sub

    Protected Sub authorizeTrxn(trxnID As String)
        Try
            Using con As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd As New SqlCommand("update TellerOperations set [Authorized]=1,[ActionBy]=@ActBy,[ActionDateStamp]=GETDATE() where id=@trID", con)
                    cmd.Parameters.AddWithValue("@ActBy", Session("UserId"))
                    cmd.Parameters.AddWithValue("@trID", trxnID)
                    con.Open()
                    If cmd.ExecuteNonQuery Then
                        notify("Transaction authorized successfully", "success")
                    Else
                        notify("Error authorizing transaction", "error")
                    End If
                    con.Close()
                End Using
            End Using
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- authorizeTrxn()", ex.ToString)
        End Try
    End Sub

    Protected Sub discardTrxn(trxnID As String)
        Try
            Using con As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd As New SqlCommand("update TellerOperations set [Rejected]=1,[ActionBy]=@ActBy,[ActionDateStamp]=GETDATE() where id=@trID", con)
                    cmd.Parameters.AddWithValue("@ActBy", Session("UserId"))
                    cmd.Parameters.AddWithValue("@trID", trxnID)
                    con.Open()
                    If cmd.ExecuteNonQuery Then
                        notify("Transaction discarded successfully", "success")
                    Else
                        notify("Error discarding transaction", "error")
                    End If
                    con.Close()
                End Using
            End Using
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- discardTrxn()", ex.ToString)
        End Try
    End Sub

    Private Sub grdVaultAuthorization_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles grdVaultAuthorization.RowCommand
        Dim updateID = CDbl(e.CommandArgument)
        If e.CommandName = "Authorize" Then
            authorizeTrxn(updateID)
        ElseIf e.CommandName = "Discard" Then
            discardTrxn(updateID)
        End If
        getAuthorizations()
    End Sub

    Protected Sub getAuthorizations()
        Try
            Using con As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd As New SqlCommand("select id,[TrxnType] as [Transaction Type],convert(varchar,[TrxnDate],106) as [Transaction Date],[TellerID] as [Account Number],[TellerName] as [Account Name],[CapturedBy] as [Captured By],format([Amount],'n') as [Amount],[Comment] from TellerOperations where ([Authorized] is null or [Authorized]=0) and ([Rejected] is null or [Rejected]=0)", con)
                    Dim dt As New DataTable
                    Using adp As New SqlDataAdapter(cmd)
                        adp.Fill(dt)
                    End Using
                    bindGrid(dt, grdVaultAuthorization)
                End Using
            End Using
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- getAuthorizations()", ex.ToString)
        End Try
    End Sub
End Class