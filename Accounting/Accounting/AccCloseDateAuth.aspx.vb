Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports CreditManager
Imports ErrorLogging
Partial Class Accounting_AccCloseDateAuth
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Page.MaintainScrollPositionOnPostBack = True
        If Not IsPostBack Then
            getDates()
            getCashDates()
        End If
    End Sub

    Protected Sub getDates()
        Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
            Using cmd As New SqlCommand("select id,convert(varchar,CutOff,106) as [Date],CapturedBy as [Captured By],convert(varchar,CaptureDate,113) as [Capture Date] from AccCutOffDates where (Authorised is null or Authorised=0) and (Rejected is null or Rejected=0)", con)
                Dim ds As New DataSet
                Dim adp = New SqlDataAdapter(cmd)
                adp.Fill(ds, "APP")
                If ds.Tables(0).Rows.Count > 0 Then
                    grdDate.DataSource = ds.Tables(0)
                Else
                    grdDate.DataSource = Nothing
                End If
                grdDate.DataBind()
            End Using
        End Using
    End Sub

    Protected Sub getCashDates()
        Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
            Using cmd As New SqlCommand("select id,convert(varchar,CutOff,106) as [Date],CapturedBy as [Captured By],convert(varchar,CaptureDate,113) as [Capture Date] from AccCashCutOffDates where (Authorised is null or Authorised=0) and (Rejected is null or Rejected=0)", con)
                Dim ds As New DataSet
                Dim adp = New SqlDataAdapter(cmd)
                adp.Fill(ds, "APP")
                If ds.Tables(0).Rows.Count > 0 Then
                    grdCash.DataSource = ds.Tables(0)
                Else
                    grdCash.DataSource = Nothing
                End If
                grdCash.DataBind()
            End Using
        End Using
    End Sub

    Protected Sub grdDate_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles grdDate.RowCommand
        Dim dateId = e.CommandArgument
        Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
            If e.CommandName = "Authorise" Then
                Using cmd As New SqlCommand("update AccCutOffDates set Authorised=1,Rejected=0,ActionBy='" & Session("UserId") & "',ActionDate=GETDATE() where id='" & dateId & "'", con)
                    If con.State <> ConnectionState.Closed Then
                        con.Close()
                    End If
                    con.Open()
                    cmd.ExecuteNonQuery()
                    notify("Cut Off Date authorized", "success")
                    con.Close()
                End Using
            ElseIf e.CommandName = "Delete" Then
                Using cmd As New SqlCommand("update AccCutOffDates set Authorised=0,Rejected=1,ActionBy='" & Session("UserId") & "',ActionDate=GETDATE() where id='" & dateId & "'", con)
                    If con.State <> ConnectionState.Closed Then
                        con.Close()
                    End If
                    con.Open()
                    cmd.ExecuteNonQuery()
                    notify("Cut Off Date discarded", "success")
                    con.Close()
                End Using
            End If
        End Using
        getDates()
    End Sub

    Protected Sub grdCash_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles grdCash.RowCommand
        Dim dateId = e.CommandArgument
        Try
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                If e.CommandName = "Authorise" Then
                    Using cmd As New SqlCommand("update AccCashCutOffDates set Authorised=1,Rejected=0,ActionBy='" & Session("UserId") & "',ActionDate=GETDATE() where id='" & dateId & "'", con)
                        If con.State <> ConnectionState.Closed Then
                            con.Close()
                        End If
                        con.Open()
                        cmd.ExecuteNonQuery()
                        notify("Cut Off Date authorized", "success")
                        con.Close()
                    End Using
                ElseIf e.CommandName = "Delete" Then
                    Using cmd As New SqlCommand("update AccCashCutOffDates set Authorised=0,Rejected=1,ActionBy='" & Session("UserId") & "',ActionDate=GETDATE() where id='" & dateId & "'", con)
                        If con.State <> ConnectionState.Closed Then
                            con.Close()
                        End If
                        con.Open()
                        cmd.ExecuteNonQuery()
                        notify("Cut Off Date discarded", "success")
                        con.Close()
                    End Using
                End If
            End Using
            getCashDates()

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
End Class