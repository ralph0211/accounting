Imports System.Data
Imports System.Data.SqlClient
Imports SecureBank
Imports CreditManager
Imports ErrorLogging

Partial Class BranchesAuthorization
    Inherits System.Web.UI.Page

    Protected Sub getAuthorizations()
        Try
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Dim ds As New DataSet
                Using cmd = New SqlCommand("SELECT id as [ID],[OLD_BNCH_CODE],[BNCH_CODE],[OLD_BNCH_NAME],[BNCH_NAME],[OLD_BNCH_ADDRESS],[BNCH_ADDRESS],[OLD_BNCH_PHONENO],[BNCH_PHONENO] from [TEMP_BNCH_DETAILS] where ([Authorized] is null or [Authorized]=0) and ([Discarded] is null or [Discarded]=0) and [PERFORMED_BY]<>@creater", con)
                    cmd.Parameters.AddWithValue("@creater", Session("UserId"))
                    Using adp = New SqlDataAdapter(cmd)
                        adp.Fill(ds, "APP")
                    End Using
                    If ds.Tables(0).Rows.Count > 0 Then
                        grdAuthBranch.DataSource = ds.Tables(0)
                    Else
                        grdAuthBranch.DataSource = Nothing
                    End If
                    grdAuthBranch.DataBind()
                End Using
            End Using
        Catch ex As Exception
            ErrorLogging.WriteLogFile(Session("UserId"), Request.Url.ToString & " --- getAuthorizations()", ex.ToString)
        End Try
    End Sub

    Private Sub BranchesAuthorization_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            Page.MaintainScrollPositionOnPostBack = True
            If Not IsPostBack Then
                getAuthorizations()
            End If
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- Page_Load()", ex.ToString)
        End Try
    End Sub

    Private Sub grdAuthBranch_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles grdAuthBranch.RowCommand
        Try
            Dim action = e.CommandName
            Dim rID = e.CommandArgument
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd As New SqlCommand("AuthorizeBranch", con)
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.AddWithValue("@editID", rID)
                    cmd.Parameters.AddWithValue("@Decision", action)
                    cmd.Parameters.AddWithValue("@User", Session("UserId"))
                    con.Open()
                    If cmd.ExecuteNonQuery Then
                        If action = "Authorize" Then
                            notify("Branch successfully authorized", "success")
                        Else
                            notify("Branch successfully discarded", "success")
                        End If
                        getAuthorizations()
                    Else
                        If action = "Authorize" Then
                            notify("Error authorizing branch", "error")
                        Else
                            notify("Error discarding branch", "error")
                        End If
                    End If
                    con.Close()
                End Using
            End Using
        Catch ex As Exception
            ErrorLogging.WriteLogFile(Session("UserId"), Request.Url.ToString & " --- grdAuthBranch_RowCommand()", ex.ToString)
        End Try
    End Sub
End Class