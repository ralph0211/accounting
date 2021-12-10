Imports System.Data
Imports System.Data.SqlClient

Partial Class QuestCredit_RestoreSession
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Page.MaintainScrollPositionOnPostBack = True
            If Not IsPostBack Then
                If Trim(Session("ROLE")) = "" Then
                    Response.Redirect("~/Login.aspx")
                Else
                    getApplications(Session("UserId"))
                End If
                grdSessions.UseAccessibleHeader = True
                grdSessions.HeaderRow.TableSection = TableRowSection.TableHeader
            End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub getApplications(ByVal uName As String)
        Try
            Dim ds As New DataSet
            Using con = New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd = New SqlCommand("SELECT ID,[SessionID] as [Session Id],'Application Capture' as [Action], ISNULL(surname,'')+' '+ISNULL(forenames,'') as [Client Name],convert(varchar,[AutoSaveDate],113) as [Date] FROM [QUEST_APPLICATION_AutoSave] where [SavedBy]='" & uName & "' union SELECT ID,[SessionID] as [Session Id],'Static Details Capture' as [Action], ISNULL(surname,'')+' '+ISNULL(forenames,'') as [Client Name],convert(varchar,[AutoSaveDate],113) as [Date] FROM [CUSTOMER_DETAILS_Autosave] where [SavedBy]='" & uName & "'", con)
                    Using adp = New SqlDataAdapter(cmd)
                        adp.Fill(ds, "APP")
                    End Using
                    If ds.Tables(0).Rows.Count > 0 Then
                        grdSessions.DataSource = ds.Tables(0)
                    Else
                        grdSessions.DataSource = Nothing
                    End If
                    grdSessions.DataBind()
                End Using
            End Using
            lblAppCount.Text = ds.Tables(0).Rows.Count
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub grdSessions_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles grdSessions.PageIndexChanging
        grdSessions.PageIndex = e.NewPageIndex
        'If Trim(txtSearchName.Text) = "" Then
        getApplications(Session("UserId"))
        'Else
        '    searchGrid(txtSearchName.Text)
        'End If
    End Sub

    Protected Sub grdSessions_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdSessions.RowCommand
        Try
            If e.CommandName = "Select" Then
                Dim loanID = e.CommandArgument
                Dim EncQuery As New BankEncryption64
                Dim row As GridViewRow = CType(CType(e.CommandSource, Control).NamingContainer, GridViewRow)
                Dim appType As String = CType(row.Cells(3), DataControlFieldCell).Text
                If appType = "Application Capture" Then
                    Response.Redirect("ApplicationForm.aspx?id=" & HttpUtility.UrlEncode(EncQuery.Encrypt(loanID)) & "&s=" & HttpUtility.UrlEncode(EncQuery.Encrypt("1")), False)
                ElseIf appType = "Static Details Capture" Then
                    Response.Redirect("NamesCapture.aspx?id=" & HttpUtility.UrlEncode(EncQuery.Encrypt(loanID)) & "&s=" & HttpUtility.UrlEncode(EncQuery.Encrypt("1")), False)
                End If
            ElseIf e.CommandName = "Details" Then
                Dim loanID = e.CommandArgument
            ElseIf e.CommandName = "Application" Then
                Dim loanID = e.CommandArgument
            End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Function isIndividual(ByVal loanID As String) As Boolean
        Dim ind As String = ""
        Using con = New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
            Using cmd = New SqlCommand("select CUSTOMER_TYPE from QUEST_APPLICATION where ID='" & loanID & "'", con)
                If con.State = ConnectionState.Open Then
                    con.Close()
                End If
                con.Open()
                ind = cmd.ExecuteScalar
                con.Close()
                If ind = "Individual" Then
                    Return True
                Else
                    Return False
                End If
            End Using
        End Using
    End Function

    Public Sub msgbox(ByVal strMessage As String)
        'finishes server processing, returns to client.
        Dim strScript As String = "<script language=JavaScript>"
        strScript += "window.alert(""" & strMessage & """);"
        strScript += "</script>"
        Dim lbl As New System.Web.UI.WebControls.Label
        lbl.Text = strScript
        Page.Controls.Add(lbl)
    End Sub

    Protected Sub btnSearchRange_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearchRange.Click
        getApplications(Session("ROLE"))
    End Sub

    Protected Sub grdSessions_SelectedIndexChanged(sender As Object, e As EventArgs) Handles grdSessions.SelectedIndexChanged

    End Sub

    Protected Sub grdSessions_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles grdSessions.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
        End If
    End Sub
End Class