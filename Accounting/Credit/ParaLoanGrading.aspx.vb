Imports System.Data
Imports System.Data.SqlClient
Imports CreditManager
Imports ErrorLogging

Partial Class Credit_ParaLoanGrading
    Inherits System.Web.UI.Page

    Protected Sub getGrades()
        Try
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd As New SqlCommand("Select Grade as [Loan Grade],convert(varchar,DIAStart) + ' - ' + convert(varchar,DIAEnd) as [Days in arrears],format(Provision,'n') as [Provision (%)] FROM [ParaLoanGrades]")
                    cmd.CommandType = CommandType.Text
                    cmd.Connection = con
                    Dim ds As New DataSet
                    Dim adp As New SqlDataAdapter(cmd)
                    adp.Fill(ds, "FUN")
                    bindGrid(ds.Tables(0), grdLoanGrade)
                End Using
            End Using
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- getGrades()", ex.Message)
        End Try
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            If Trim(txtLoanGrade.Text) = "" Then
                notify("Enter the loan grade", "error")
                txtLoanGrade.Focus()
            ElseIf Trim(txtDIAStart.Text) = "" Or Not IsNumeric(txtDIAStart.Text) Then
                notify("Enter numeric days in arrears", "error")
                txtDIAStart.Focus()
            ElseIf Trim(txtDIAEnd.Text) = "" Or Not IsNumeric(txtDIAEnd.Text) Then
                notify("Enter numeric days in arrears", "error")
                txtDIAEnd.Focus()
            ElseIf Trim(txtProvision.Text) = "" Or Not IsNumeric(txtProvision.Text) Then
                notify("Enter numeric provision", "error")
                txtProvision.Focus()
            Else
                Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                    Using cmd As New SqlCommand("insert into [ParaLoanGrades](Grade,DIAStart,DIAEnd,Provision) values (@Grade,@DIAStart,@DIAEnd,@Provision)")
                        cmd.Parameters.AddWithValue("@Grade", txtLoanGrade.Text)
                        cmd.Parameters.AddWithValue("@DIAStart", txtDIAStart.Text)
                        cmd.Parameters.AddWithValue("@DIAEnd", txtDIAEnd.Text)
                        cmd.Parameters.AddWithValue("@Provision", txtProvision.Text)
                        cmd.Connection = con
                        con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                    End Using
                End Using
                getGrades()
                txtLoanGrade.Text = ""
                txtDIAEnd.Text = ""
                txtDIAStart.Text = ""
                txtProvision.Text = ""
            End If
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- btnSave_Click()", ex.Message)
        End Try
    End Sub

    Private Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Page.MaintainScrollPositionOnPostBack = True
        If Not IsPostBack Then
            getGrades()
        End If
    End Sub
End Class