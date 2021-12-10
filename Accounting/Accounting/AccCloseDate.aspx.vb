Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports CreditManager
Imports ErrorLogging

Partial Class Accounting_AccCloseDate
    Inherits System.Web.UI.Page

    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            If Not IsDate(bdpCutDate.Text) Then
                notify("Enter valid date", "error")
            ElseIf rdbType.SelectedIndex = -1 Then
                notify("Select the account to close", "error")
            Else
                If rdbType.SelectedValue = "Cash" Then
                    Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                        Using cmd As New SqlCommand("insert into AccCashCutOffDates (CutOff,CapturedBy,CaptureDate) values ('" & bdpCutDate.Text & "','" & Session("UserId") & "',GETDATE())", con)
                            If con.State <> ConnectionState.Closed Then
                                con.Close()
                            End If
                            con.Open()
                            cmd.ExecuteNonQuery()
                            getDates()
                            notify("Cut Off Date saved. Authorization pending", "success")
                            bdpCutDate.Text = ""
                            con.Close()
                        End Using
                    End Using
                ElseIf rdbType.SelectedValue = "Other" Then
                    Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                        Using cmd As New SqlCommand("insert into AccCutOffDates (CutOff,CapturedBy,CaptureDate) values ('" & bdpCutDate.Text & "','" & Session("UserId") & "',GETDATE())", con)
                            If con.State <> ConnectionState.Closed Then
                                con.Close()
                            End If
                            con.Open()
                            cmd.ExecuteNonQuery()
                            getDates()
                            notify("Cut Off Date saved. Authorization pending", "success")
                            bdpCutDate.Text = ""
                            con.Close()
                        End Using
                    End Using
                End If

            End If
        Catch ex As Exception
            WriteLogFile(Session("UserId"), "Accounting/AccCloseDate.aspx --- btnSave_Click()", ex.Message)
        End Try
    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Page.MaintainScrollPositionOnPostBack = True
        If Not IsPostBack Then
            getDates()
        End If
    End Sub

    Protected Sub getDates()
        Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
            Using cmd As New SqlCommand("select id,convert(varchar,CutOff,106) as [Date],CapturedBy as [Captured By],convert(varchar,CaptureDate,113) as [Capture Date],Authorised,Rejected from AccCutOffDates where (Authorised is null or Authorised=0) and (Rejected is null or Rejected=0)", con)
                Dim ds As New DataSet
                Dim adp = New SqlDataAdapter(cmd)
                adp.Fill(ds, "APP")
                If ds.Tables(0).Rows.Count > 0 Then
                    grdDates.DataSource = ds.Tables(0)
                Else
                    grdDates.DataSource = Nothing
                End If
                grdDates.DataBind()
            End Using
        End Using
    End Sub
End Class