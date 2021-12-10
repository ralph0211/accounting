Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient

Partial Class Credit_CapturePDA
    Inherits System.Web.UI.Page

    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If Trim(txtPDACode.Text) = "" Or Trim(txtPDAName.Text) = "" Then
            CreditManager.msgbox("Enter PDA code and PDA name")
        Else
            Try
                Using cmd As New SqlCommand("SavePDA")
                    cmd.CommandType = CommandType.StoredProcedure
                    Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                        cmd.Connection = con
                        cmd.Parameters.AddWithValue("@PDACode", txtPDACode.Text)
                        cmd.Parameters.AddWithValue("@PDAName", txtPDAName.Text)
                        con.Open()
                        If cmd.ExecuteNonQuery() Then
                            CreditManager.msgbox("PDA successfully saved")
                            clearAll()
                            getPDAs()
                        Else
                            CreditManager.msgbox("Error saving bank")
                        End If
                        con.Close()
                    End Using
                End Using
            Catch ex As Exception
                CreditManager.msgbox(ex.Message)
            End Try
        End If
    End Sub

    Protected Sub clearAll()
        txtPDACode.Text = ""
        txtPDAName.Text = ""
    End Sub

    Protected Sub getPDAs()
        Try
            Using cmd As New SqlCommand("Select id,[PDACode] as [Code],[PDAName] as [Name] FROM [para_PDA]")
                cmd.CommandType = CommandType.Text
                Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                    cmd.Connection = con
                    Dim ds As New DataSet
                    Dim adp As New SqlDataAdapter(cmd)
                    adp.Fill(ds, "FUN")
                    If ds.Tables(0).Rows.Count > 0 Then
                        grdPDA.DataSource = ds.Tables(0)
                    Else
                        grdPDA.DataSource = Nothing
                    End If
                    grdPDA.DataBind()
                End Using
            End Using
        Catch ex As Exception
            CreditManager.msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub grdPDA_RowCancelingEdit(sender As Object, e As GridViewCancelEditEventArgs) Handles grdPDA.RowCancelingEdit
        grdPDA.EditIndex = -1
        getPDAs()
    End Sub

    Protected Sub grdPDA_RowDeleting(sender As Object, e As GridViewDeleteEventArgs) Handles grdPDA.RowDeleting
        Try
            ViewState("bankEditID") = DirectCast(grdPDA.Rows(e.RowIndex).FindControl("txtgrdPDAID"), TextBox).Text
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd = New SqlCommand("delete from [para_PDA] where id='" & ViewState("bankEditID") & "'", con)
                    If con.State = ConnectionState.Open Then
                        con.Close()
                    End If
                    con.Open()
                    If cmd.ExecuteNonQuery Then
                        CreditManager.msgbox("Successfully deleted")
                    Else
                        CreditManager.msgbox("Error deleting")
                    End If
                    con.Close()
                    getPDAs()
                End Using
            End Using
        Catch ex As Exception
            CreditManager.msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub grdPDA_RowEditing(sender As Object, e As GridViewEditEventArgs) Handles grdPDA.RowEditing
        Try
            ViewState("bankEditID") = DirectCast(grdPDA.Rows(e.NewEditIndex).FindControl("txtgrdPDAID"), TextBox).Text
            grdPDA.EditIndex = e.NewEditIndex
            getPDAs()
        Catch ex As Exception
            CreditManager.msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub grdPDA_RowUpdating(sender As Object, e As GridViewUpdateEventArgs) Handles grdPDA.RowUpdating
        Try
            If Trim(ViewState("bankEditID")) = "" Or IsDBNull(ViewState("bankEditID")) Then
                CreditManager.msgbox("No record selected for update")
                Exit Sub
            End If
            Dim bankName As String = DirectCast(grdPDA.Rows(e.RowIndex).FindControl("txtgrdPDAName"), TextBox).Text
            Dim bankCode As String = DirectCast(grdPDA.Rows(e.RowIndex).FindControl("txtgrdPDACode"), TextBox).Text

            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd = New SqlCommand("update [para_bank] set [bank_name]='" & bankName.Replace("'", "''") & "', [bank]='" & bankCode & "' where id='" & ViewState("bankEditID") & "'", con)
                    If con.State <> ConnectionState.Closed Then
                        con.Close()
                    End If
                    con.Open()
                    If cmd.ExecuteNonQuery Then
                        CreditManager.msgbox("Successfully updated")
                    Else
                        CreditManager.msgbox("Error updating value")
                    End If
                    con.Close()
                    grdPDA.EditIndex = -1
                    getPDAs()
                End Using
            End Using
        Catch ex As Exception
            CreditManager.msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Page.MaintainScrollPositionOnPostBack = True
        If Not IsPostBack Then
            getPDAs()
        End If
    End Sub
End Class