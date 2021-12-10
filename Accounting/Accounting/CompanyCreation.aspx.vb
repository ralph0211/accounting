Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports CreditManager
Imports ErrorLogging

Partial Class Accounting_CompanyCreation
    Inherits System.Web.UI.Page

    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd = New SqlCommand("INSERT INTO [AccountingCompanies] ([CompanyName],[TradeName],[Address],[ContactName],[ContactSurname],[Email],[Telephone1],[Telephone2],[Mobile],[Information],[SavedBy],[SaveDate]) VALUES (@CompanyName,@TradeName,@Address,@ContactName,@ContactSurname,@Email,@Telephone1,@Telephone2,@Mobile,@Information,@SavedBy,GETDATE())", con)
                    cmd.Parameters.AddWithValue("@CompanyName", txtCompanyName.Text)
                    cmd.Parameters.AddWithValue("@TradeName", txtTradeName.Text)
                    cmd.Parameters.AddWithValue("@Address", txtAddress.Text)
                    cmd.Parameters.AddWithValue("@ContactName", txtContactName.Text)
                    cmd.Parameters.AddWithValue("@ContactSurname", txtContactSurname.Text)
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text)
                    cmd.Parameters.AddWithValue("@Telephone1", txtTel1.Text)
                    cmd.Parameters.AddWithValue("@Telephone2", txtTel2.Text)
                    cmd.Parameters.AddWithValue("@Mobile", txtMobile.Text)
                    cmd.Parameters.AddWithValue("@Information", txtInformation.Text)
                    cmd.Parameters.AddWithValue("@SavedBy", Session("UserId"))
                    con.Open()
                    If cmd.ExecuteNonQuery Then
                        notify("Company saved", "success")
                        txtAddress.Text = ""
                        txtCompanyName.Text = ""
                        txtContactName.Text = ""
                        txtContactSurname.Text = ""
                        txtEmail.Text = ""
                        txtInformation.Text = ""
                        txtMobile.Text = ""
                        txtTel1.Text = ""
                        txtTel2.Text = ""
                        txtTradeName.Text = ""
                        getCompanies()
                    Else
                        notify("Error saving company", "error")
                    End If
                    con.Close()
                End Using
            End Using
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- btnSave_Click()", ex.ToString)
        End Try
    End Sub

    Protected Sub getCompanies()
        Try
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd = New SqlCommand("select * from AccountingCompanies", con)
                    Dim ds As New DataSet
                    Using adp = New SqlDataAdapter(cmd)
                        adp.Fill(ds, "CLIENT")
                    End Using
                    bindGrid(ds.Tables(0), grdCompany)
                End Using
            End Using
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- getCompanies()", ex.ToString)
        End Try
    End Sub

    Private Sub Accounting_CompanyCreation_Load(sender As Object, e As EventArgs) Handles Me.Load
        Page.MaintainScrollPositionOnPostBack = True
        If Not IsPostBack Then
            getCompanies()
        End If
    End Sub

    Private Sub grdCompany_RowCancelingEdit(sender As Object, e As GridViewCancelEditEventArgs) Handles grdCompany.RowCancelingEdit
        grdCompany.EditIndex = -1
        getCompanies()
    End Sub

    Private Sub grdCompany_RowDeleting(sender As Object, e As GridViewDeleteEventArgs) Handles grdCompany.RowDeleting
        Try
            ViewState("compEditID") = DirectCast(grdCompany.Rows(e.RowIndex).FindControl("txtGrdID"), TextBox).Text
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd = New SqlCommand("delete from [AccountingCompanies] where id='" & ViewState("compEditID") & "'", con)
                    If con.State = ConnectionState.Open Then
                        con.Close()
                    End If
                    con.Open()
                    If cmd.ExecuteNonQuery Then
                        notify("Successfully deleted", "success")
                    Else
                        notify("Error deleting", "error")
                    End If
                    con.Close()
                    getCompanies()
                End Using
            End Using
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- grdCompany_RowDeleting()", ex.ToString)
        End Try
    End Sub

    Private Sub grdCompany_RowEditing(sender As Object, e As GridViewEditEventArgs) Handles grdCompany.RowEditing
        Try
            ViewState("compEditID") = DirectCast(grdCompany.Rows(e.NewEditIndex).FindControl("txtGrdID"), TextBox).Text
            grdCompany.EditIndex = e.NewEditIndex
            getCompanies()
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- grdCompany_RowEditing()", ex.ToString)
        End Try
    End Sub

    Private Sub grdCompany_RowUpdating(sender As Object, e As GridViewUpdateEventArgs) Handles grdCompany.RowUpdating
        Try
            If Trim(ViewState("compEditID")) = "" Or IsDBNull(ViewState("compEditID")) Then
                notify("No record selected for update", "error")
                Exit Sub
            End If
            Dim compName As TextBox = DirectCast(grdCompany.Rows(e.RowIndex).FindControl("txtGrdCompanyName"), TextBox)
            Dim tradeName As TextBox = DirectCast(grdCompany.Rows(e.RowIndex).FindControl("txtGrdTradeName"), TextBox)
            Dim address As TextBox = DirectCast(grdCompany.Rows(e.RowIndex).FindControl("txtGrdAddress"), TextBox)
            Dim contactName As TextBox = DirectCast(grdCompany.Rows(e.RowIndex).FindControl("txtGrdContactName"), TextBox)
            Dim contactSurname As TextBox = DirectCast(grdCompany.Rows(e.RowIndex).FindControl("txtGrdContactSurname"), TextBox)
            Dim email As TextBox = DirectCast(grdCompany.Rows(e.RowIndex).FindControl("txtGrdEmail"), TextBox)
            Dim tel1 As TextBox = DirectCast(grdCompany.Rows(e.RowIndex).FindControl("txtGrdTelephone1"), TextBox)
            Dim tel2 As TextBox = DirectCast(grdCompany.Rows(e.RowIndex).FindControl("txtGrdTelephone2"), TextBox)
            Dim mobile As TextBox = DirectCast(grdCompany.Rows(e.RowIndex).FindControl("txtGrdMobile"), TextBox)
            Dim info As TextBox = DirectCast(grdCompany.Rows(e.RowIndex).FindControl("txtGrdInformation"), TextBox)

            If Trim(compName.Text) = "" Then
                notify("Enter the company name", "error")
                compName.Focus()
            ElseIf Trim(tradeName.Text) = "" Then
                notify("Enter the trade name", "error")
            Else
                Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                    Using cmd = New SqlCommand("update [AccountingCompanies] set CompanyName=@CompanyName,TradeName=@TradeName,Address=@Address,ContactName=@ContactName,ContactSurname=@ContactSurname,Email=@Email,Telephone1=@Telephone1,Telephone2=@Telephone2,Mobile=@Mobile,Information=@Information where id='" & ViewState("compEditID") & "'", con)
                        cmd.Parameters.AddWithValue("@CompanyName", compName.Text)
                        cmd.Parameters.AddWithValue("@TradeName", tradeName.Text)
                        cmd.Parameters.AddWithValue("@Address", address.Text)
                        cmd.Parameters.AddWithValue("@ContactName", contactName.Text)
                        cmd.Parameters.AddWithValue("@ContactSurname", contactSurname.Text)
                        cmd.Parameters.AddWithValue("@Email", email.Text)
                        cmd.Parameters.AddWithValue("@Telephone1", tel1.Text)
                        cmd.Parameters.AddWithValue("@Telephone2", tel2.Text)
                        cmd.Parameters.AddWithValue("@Mobile", mobile.Text)
                        cmd.Parameters.AddWithValue("@Information", info.Text)
                        con.Open()
                        If cmd.ExecuteNonQuery Then
                            notify("Successfully updated", "success")
                        Else
                            notify("Error updating value", "error")
                        End If
                        con.Close()
                        grdCompany.EditIndex = -1
                        getCompanies()
                    End Using
                End Using
            End If
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- grdCompany_RowUpdating()", ex.ToString)
        End Try
    End Sub

End Class