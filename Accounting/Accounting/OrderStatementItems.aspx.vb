Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports CreditManager
Imports ErrorLogging

Partial Class Accounting_OrderStatementItems
    Inherits System.Web.UI.Page

    Private Sub Accounting_OrderStatementItems_Load(sender As Object, e As EventArgs) Handles Me.Load
        Page.MaintainScrollPositionOnPostBack = True
        If Not IsPostBack Then
            getBSItems()
        End If
    End Sub

    Protected Sub getBSItems()
        Try
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("conString").ConnectionString)
                Using cmd As New SqlCommand("(select fin.id, fin.[Type],fin.Sub,subCat.SubType,sc.Category,bsi.ItemName as [Statement],mainaccount as AccNo,CONVERT(VARCHAR,subaccount) as SubAccNo,AccountName as [Description],subcat.ordering as CatOrder,bsi.Ordering ,fin.Ordering as finOrder from tbl_FinancialAccountsCreation fin LEFT JOIN tbl_FinancialCategory subCat ON fin.Sub=convert(varchar,Subcat.id) LEFT JOIN statementCategories sc ON subCat.category=convert(varchar,sc.id) LEFT JOIN balancesheetitems bsi ON convert(varchar,fin.BSItemId)=convert(varchar,bsi.id) where fin.subaccount<>'1' and sc.Statement='Balance Sheet') order by category,CatOrder,finOrder", con)
                    Dim dt As New DataTable
                    Using sda As New SqlDataAdapter(cmd)
                        sda.Fill(dt)
                    End Using
                    bindGrid(dt, grdItems)
                End Using
            End Using
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- getBSItems()", ex.ToString)
        End Try
    End Sub
    Protected Sub UpdatePreference(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim locationIds As Integer() = (From p In Request.Form("lblPermissionId").Split(",")
                                        Select Integer.Parse(p)).ToArray()
        Dim preference As Integer = 1
        For Each locationId As Integer In locationIds
            Me.UpdatePreference(locationId, preference)
            preference += 1
        Next
        notify("New balance sheet order saved", "success")
        getBSItems()
    End Sub

    Private Sub UpdatePreference(locationId As Integer, preference As Integer)
        Dim constr As String = ConfigurationManager.ConnectionStrings("conString").ConnectionString
        Using con As New SqlConnection(constr)
            Using cmd As New SqlCommand("UPDATE [tbl_FinancialAccountsCreation] SET [ORDERING] = @Preference WHERE Id = @Id")
                Using sda As New SqlDataAdapter()
                    cmd.CommandType = CommandType.Text
                    cmd.Parameters.AddWithValue("@Id", locationId)
                    cmd.Parameters.AddWithValue("@Preference", preference)
                    cmd.Connection = con
                    con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                End Using
            End Using
        End Using
    End Sub
End Class