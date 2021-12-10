Imports System.Data
Imports CreditManager
Imports ErrorLogging
Imports System.Data.SqlClient

Partial Class Credit_AssetStock
    Inherits System.Web.UI.Page

    Public Sub getAssets()
        Try
            Dim ds As New DataSet
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd = New SqlCommand("Select * from Quest_Assets", con)
                    Using adp = New SqlDataAdapter(cmd)
                        adp.Fill(ds, "Assets")
                    End Using
                    loadCombo(ds.Tables(0), cmbAsset, "Name", "id")
                End Using
            End Using
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- getAssets()", ex.ToString)
            msgbox(ex.Message)
        End Try
    End Sub

    Public Sub loadStock()
        Try
            Dim ds As New DataSet
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd = New SqlCommand("Select Name,sum(Quantity) as Quantity from Quest_Assets qa join AssetStock ass on qa.ID=ass.AssetID group by Name", con)
                    Using adp = New SqlDataAdapter(cmd)
                        adp.Fill(ds, "Assets")
                    End Using
                    grdStock.DataSource = ds.Tables(0)
                    grdStock.DataBind()
                End Using
            End Using
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- loadStock()", ex.ToString)
        End Try
    End Sub

    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            If rdbTrxnType.SelectedIndex = -1 Then
                notify("Select the transaction type", "error")
            ElseIf Trim(txtTrxnDate.Text) = "" Or Not IsDate(txtTrxnDate.Text) Then
                notify("Enter the transaction date", "error")
            ElseIf Trim(txtQuantity.Text) = "" Or Not IsNumeric(txtQuantity.Text) Then
                notify("Enter numeric value for quantity", "error")
            Else
                Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                    Using cmd = New SqlCommand("insert into AssetStock (TrxnDate,TrxnType,AssetID,Notes,Quantity,Price,CaptureBy,CaptureDate) values ('" + txtTrxnDate.Text + "','" + rdbTrxnType.SelectedValue + "','" + cmbAsset.SelectedValue + "','" + txtDesc.Text.ToString.Replace("'", "''") + "','" + txtQuantity.Text + "',0,'" + Session("UserId") + "',GETDATE())", con)
                        con.Open()
                        cmd.ExecuteNonQuery()
                        con.Close()
                        notify("Stock saved", "success")
                    End Using
                End Using
            End If
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- btnSave_Click()", ex.ToString)
        End Try
    End Sub
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Page.MaintainScrollPositionOnPostBack = True
        If Not IsPostBack Then
            getAssets()
            loadStock()
        End If
    End Sub
End Class