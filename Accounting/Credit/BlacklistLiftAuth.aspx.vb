Imports System.Data
Imports System.Data.SqlClient
Imports ErrorLogging
Imports CreditManager

Partial Class QuestCredit_BlacklistLiftAuth
    Inherits System.Web.UI.Page

    Protected Sub grdBlacklist_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdBlacklist.RowCommand
        Try
            Dim blackID = e.CommandArgument
            Dim row As GridViewRow = CType(CType(e.CommandSource, Control).NamingContainer, GridViewRow)
            Dim reas = row.Cells(6).Text.Replace("&nbsp;", "")
            Dim bld = row.Cells(7).Text.Replace("&nbsp;", "")
            Dim csn = row.Cells(2).Text.Replace("&nbsp;", "")
            If e.CommandName = "Uplift" Then
                Dim userID = e.CommandArgument
                Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                    Using cmd = New SqlCommand("update Blacklist set [LiftAuthorized]=1,LiftAuthorizedBy=@LiftedBy,[LiftAuthorizedTimestamp]=GETDATE() where id=@id", con)
                        cmd.Parameters.AddWithValue("@LiftedBy", Session("UserId"))
                        'cmd.Parameters.AddWithValue("@LiftDate", bld)
                        cmd.Parameters.AddWithValue("@id", userID)
                        If con.State = ConnectionState.Open Then
                            con.Close()
                        End If
                        con.Open()
                        If cmd.ExecuteNonQuery Then
                            Using cmd1 = New SqlCommand("update CUSTOMER_DETAILS set Blacklisted=0 where [CUSTOMER_NUMBER]=@CustNo", con)
                                'cmd1.Parameters.AddWithValue("@CustNo", getBlacklistCustNo(userID))
                                cmd1.Parameters.AddWithValue("@CustNo", csn)
                                cmd1.ExecuteNonQuery()
                                CreditManager.notify("Client uplifted from blacklist", "success")
                            End Using
                            getBlacklistedClients()
                        Else
                            CreditManager.notify("Error uplifting client from blacklist", "error")
                        End If
                        con.Close()
                    End Using
                End Using
            ElseIf e.CommandName = "Discard" Then
                Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                    Using cmd = New SqlCommand("update Blacklist set LiftDiscarded=1,LiftAuthorizedTimestamp=GETDATE(),LiftAuthorizedBy=@BlacklistAuthorizedBy where id=@id", con)
                        cmd.Parameters.AddWithValue("@BlacklistAuthorizedBy", Session("UserId"))
                        cmd.Parameters.AddWithValue("@id", blackID)
                        If con.State = ConnectionState.Open Then
                            con.Close()
                        End If
                        con.Open()
                        If cmd.ExecuteNonQuery Then
                            getBlacklistedClients()
                            notify("Discarded", "success")
                        Else
                            notify("Error discarding record", "error")
                        End If
                        con.Close()
                    End Using
                End Using
            End If
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- grdBlacklist_RowCommand()", ex.ToString)
        End Try
    End Sub

    Protected Function getBlacklistCustNo(BLId As String) As String
        Try
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd = New SqlCommand("SELECT CustNo FROM Blacklist where id=@id", con)
                    cmd.Parameters.AddWithValue("@id", BLId)
                    Dim ds As New DataSet
                    Using adp = New SqlDataAdapter(cmd)
                        adp.Fill(ds, "MASTER_USERS")
                    End Using
                    If ds.Tables(0).Rows.Count > 0 Then
                        Return ds.Tables(0).Rows(0).Item("CustNo")
                    Else
                        Return ""
                    End If
                End Using
            End Using
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- getBlacklistCustNo()", ex.ToString)
            Return ""
        End Try
    End Function

    Protected Sub getBlacklistedClients()
        Try
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd = New SqlCommand("SELECT *,CONVERT(VARCHAR,BlacklistTimeStamp,113) AS BlacklistTimeStamp1,CONVERT(VARCHAR,BlacklistDate,103) AS BlacklistDate1 FROM blacklist where Blacklisted=1 AND (Lifted=1) and ([LiftAuthorized]=0 or [LiftAuthorized] is null) and ([LiftDiscarded]=0 or [LiftDiscarded] is null)", con)
                    Dim ds As New DataSet
                    Using adp = New SqlDataAdapter(cmd)
                        adp.Fill(ds, "MASTER_USERS")
                    End Using
                    If ds.Tables(0).Rows.Count > 0 Then
                        grdBlacklist.DataSource = ds.Tables(0)
                    Else
                        grdBlacklist.DataSource = Nothing
                    End If
                    grdBlacklist.DataBind()
                End Using
            End Using
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- getBlacklistedClients()", ex.ToString)
        End Try
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Page.MaintainScrollPositionOnPostBack = True
            If Not IsPostBack Then
                getBlacklistedClients()
            End If
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- Page_Load()", ex.ToString)
        End Try
    End Sub
End Class