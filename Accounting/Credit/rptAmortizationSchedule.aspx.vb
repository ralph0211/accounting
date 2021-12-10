Imports System.Data
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine

Partial Class rptAmortizationSchedule
    Inherits System.Web.UI.Page
    Dim cryRpt As ReportDocument = New ReportDocument()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Session("UserID") = String.Empty Then
                'not logged in redirect to login page
                Response.Redirect("~/Login.aspx", False)
                Exit Sub
            End If

            Dim EncQuery As New BankEncryption64
            Dim loanID = EncQuery.Decrypt(Request.QueryString("loanID").Replace(" ", "+"))

            Dim kk As String = ""
            Dim custType = getCustType(loanID)
            If custType = "Group" Then
                kk = Server.MapPath("rptAmortizationScheduleGroup.rpt")
            Else
                kk = Server.MapPath("rptAmortizationSchedule.rpt")
            End If
            cryRpt.Load(kk)
            cryRpt.SetParameterValue(0, loanID)
            CrystalReportViewer1.ReportSource = cryRpt
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Unload
        cryRpt.Close()
        cryRpt.Dispose()
        GC.Collect()
    End Sub

    Public Sub msgbox(ByVal strMessage As String)

        'finishes server processing, returns to client.
        Dim strScript As String = "<script language=JavaScript>"
        strScript += "window.alert(""" & strMessage & """);"
        strScript += "</script>"
        Dim lbl As New System.Web.UI.WebControls.Label
        lbl.Text = strScript
        Page.Controls.Add(lbl)

    End Sub

    Protected Function getCustType(lID As String) As String
        Try
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd = New SqlCommand("select CUSTOMER_TYPE from QUEST_APPLICATION where ID='" & lID & "'", con)
                    Dim custType = ""
                    If con.State = ConnectionState.Open Then
                        con.Close()
                    End If
                    Try
                        con.Open()
                        custType = cmd.ExecuteScalar
                        con.Close()
                    Catch ex As Exception
                        custType = ""
                    End Try
                    Return custType
                End Using
            End Using
        Catch ex As Exception
            ErrorLogging.WriteLogFile(Session("UserId"), Request.Url.ToString & " --- getCustType()", ex.ToString)
            Return ""
        End Try
    End Function
End Class