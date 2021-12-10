Imports System.Data
Imports System.Data.SqlClient
Imports CreditManager
Imports ErrorLogging

Partial Class Credit_ParaProductFees
    Inherits System.Web.UI.Page

    Protected Sub btnSaveFees_Click(sender As Object, e As EventArgs) Handles btnSaveFees.Click
        Try
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd As New SqlCommand("insert into ParaProductFees (ProductName,FeeType,CalcOption) values (@ProductName,@FeeType,@CalcOption)", con)
                    cmd.Parameters.AddWithValue("@ProductName", txtProduct.Text)
                    cmd.Parameters.AddWithValue("@FeeType", cmbFeeType.SelectedValue)
                    cmd.Parameters.AddWithValue("@CalcOption", rdbCalcOption.SelectedValue)
                    con.Open()
                    If cmd.ExecuteNonQuery() Then
                        notify("Product fee saved", "success")
                        getProductFees()
                        txtProduct.Text = ""
                        cmbFeeType.ClearSelection()
                        rdbCalcOption.ClearSelection()
                    Else
                        notify("Error saving product fee", "error")
                    End If
                    con.Close()
                End Using
            End Using
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- btnSaveFees_Click()", ex.Message)
        End Try
    End Sub

    Protected Sub getProductFees()
        Try
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd As New SqlCommand("select * from ParaProductFees", con)
                    Dim ds As New DataSet
                    Using adp As New SqlDataAdapter(cmd)
                        adp.Fill(ds)
                    End Using
                    bindGrid(ds.Tables(0), grdProductFees)
                End Using
            End Using
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- getProductFees()", ex.Message)
        End Try
    End Sub

    Protected Sub grdProductFees_RowCancelingEdit(sender As Object, e As GridViewCancelEditEventArgs) Handles grdProductFees.RowCancelingEdit
        grdProductFees.EditIndex = -1
        getProductFees()
    End Sub

    Protected Sub grdProductFees_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles grdProductFees.RowDataBound
        Try
            If e.Row.RowType = DataControlRowType.DataRow AndAlso grdProductFees.EditIndex = e.Row.RowIndex Then
                Dim cmbGrdCalcOption As DropDownList = DirectCast(e.Row.FindControl("cmbGrdCalcOption"), DropDownList)
                Dim cmbGrdFeeType As DropDownList = DirectCast(e.Row.FindControl("cmbGrdFeeType"), DropDownList)
                Dim calcOption As String = DirectCast(e.Row.FindControl("txtGrdCalcOption"), TextBox).Text
                Dim feeType As String = DirectCast(e.Row.FindControl("txtGrdFeeType"), TextBox).Text
                Try
                    cmbGrdCalcOption.Items.FindByValue(calcOption).Selected = True
                Catch ex As Exception
                    cmbGrdCalcOption.ClearSelection()
                End Try
                Try
                    cmbGrdFeeType.Items.FindByValue(feeType).Selected = True
                Catch ex As Exception
                    cmbGrdFeeType.ClearSelection()
                End Try
            End If
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- grdProductFees_RowDataBound", ex.ToString)
        End Try
    End Sub

    Protected Sub grdProductFees_RowDeleting(sender As Object, e As GridViewDeleteEventArgs) Handles grdProductFees.RowDeleting
        Try
            ViewState("productFeeEditID") = DirectCast(grdProductFees.Rows(e.RowIndex).FindControl("txtGrdProductFeeID"), TextBox).Text
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd = New SqlCommand("delete from [ParaProductFees] where id='" & ViewState("productFeeEditID") & "'", con)
                    If con.State = ConnectionState.Open Then
                        con.Close()
                    End If
                    con.Open()
                    If cmd.ExecuteNonQuery Then
                        CreditManager.notify("Successfully deleted", "success")
                    Else
                        CreditManager.notify("Error deleting", "error")
                    End If
                    con.Close()
                    getProductFees()
                End Using
            End Using
        Catch ex As Exception
            ErrorLogging.WriteLogFile(Session("UserId"), Request.Url.ToString & " --- grdProductFees_RowDeleting", ex.ToString)
        End Try
    End Sub

    Protected Sub grdProductFees_RowEditing(sender As Object, e As GridViewEditEventArgs) Handles grdProductFees.RowEditing
        Try
            ViewState("productFeeEditID") = DirectCast(grdProductFees.Rows(e.NewEditIndex).FindControl("txtGrdProductFeeID"), TextBox).Text
            grdProductFees.EditIndex = e.NewEditIndex
            getProductFees()
        Catch ex As Exception
            ErrorLogging.WriteLogFile(Session("UserId"), Request.Url.ToString & " --- grdProductFees_RowEditing", ex.Message)
        End Try
    End Sub

    Protected Sub grdProductFees_RowUpdating(sender As Object, e As GridViewUpdateEventArgs) Handles grdProductFees.RowUpdating
        Try
            If Trim(ViewState("productFeeEditID")) = "" Or IsDBNull(ViewState("productFeeEditID")) Then
                CreditManager.notify("No record selected for update", "error")
                Exit Sub
            End If
            Dim prdName As String = DirectCast(grdProductFees.Rows(e.RowIndex).FindControl("txtGrdProductName"), TextBox).Text
            Dim calcOption As String = DirectCast(grdProductFees.Rows(e.RowIndex).FindControl("cmbGrdCalcOption"), DropDownList).SelectedValue
            Dim feeType As String = DirectCast(grdProductFees.Rows(e.RowIndex).FindControl("cmbGrdFeeType"), DropDownList).SelectedValue

            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd = New SqlCommand("update [ParaProductFees] set [ProductName]=@ProductName, [FeeType]=@FeeType, [CalcOption]=@CalcOption where id='" & ViewState("productFeeEditID") & "'", con)
                    cmd.Parameters.AddWithValue("@ProductName", prdName)
                    cmd.Parameters.AddWithValue("@FeeType", feeType)
                    cmd.Parameters.AddWithValue("@CalcOption", calcOption)
                    If con.State <> ConnectionState.Closed Then
                        con.Close()
                    End If
                    con.Open()
                    If cmd.ExecuteNonQuery Then
                        CreditManager.notify("Successfully updated", "success")
                    Else
                        CreditManager.notify("Error updating value", "error")
                    End If
                    con.Close()
                    grdProductFees.EditIndex = -1
                    getProductFees()
                End Using
            End Using
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- grdProductFees_RowUpdating()", ex.Message)
        End Try
    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Page.MaintainScrollPositionOnPostBack = True
        If Not IsPostBack Then
            getProductFees()
        End If
    End Sub
End Class