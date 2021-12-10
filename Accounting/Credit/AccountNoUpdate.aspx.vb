Imports System.Data
Imports System.Data.SqlClient
Imports CreditManager

Partial Class Credit_AccountNoUpdate
    Inherits System.Web.UI.Page
    Dim cmd As SqlCommand
    Dim con As New SqlConnection
    Dim connection As String

    Public Sub msgbox(ByVal strMessage As String)

        'finishes server processing, returns to client.
        Dim strScript As String = "<script language=JavaScript>"
        strScript += "window.alert(""" & strMessage & """);"
        strScript += "</script>"
        Dim lbl As New System.Web.UI.WebControls.Label
        lbl.Text = strScript
        Page.Controls.Add(lbl)
    End Sub

    Protected Sub btnSearchECNo_Click(sender As Object, e As EventArgs) Handles btnSearchECNo.Click
        Try
            Using cmd = New SqlCommand("select CUSTOMER_NUMBER,isnull(SURNAME,'')+' '+isnull(FORENAMES,'')+' '+isnull(CUSTOMER_NUMBER,'')+' '+isnull(IDNO,'')+' '+isnull(ADDRESS,'') as DISPLAY from CUSTOMER_DETAILS where CUSTOMER_NUMBER='" & txtECNo.Text & "'", con)
                Dim ds As New DataSet
                Dim adp = New SqlDataAdapter(cmd)
                adp.Fill(ds, "LRS")
                If ds.Tables(0).Rows.Count > 0 Then
                    lstCust.Visible = True
                    lstCust.DataSource = ds.Tables(0)
                    lstCust.DataTextField = "DISPLAY"
                    lstCust.DataValueField = "CUSTOMER_NUMBER"
                Else
                    lstCust.DataSource = Nothing
                End If
                lstCust.DataBind()
            End Using
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub btnSearchName_Click(sender As Object, e As EventArgs) Handles btnSearchName.Click
        Try
            Using cmd = New SqlCommand("select CUSTOMER_NUMBER,isnull(SURNAME,'')+' '+isnull(FORENAMES,'')+' '+isnull(CUSTOMER_NUMBER,'')+' '+isnull(IDNO,'')+' '+isnull(ADDRESS,'') as DISPLAY from CUSTOMER_DETAILS where SURNAME+' '+FORENAMES like '%" & txtSearchName.Text & "%'", con)
                Dim ds As New DataSet
                Dim adp = New SqlDataAdapter(cmd)
                adp.Fill(ds, "LRS")
                If ds.Tables(0).Rows.Count > 0 Then
                    lstCust.Visible = True
                    lstCust.DataSource = ds.Tables(0)
                    lstCust.DataTextField = "DISPLAY"
                    lstCust.DataValueField = "CUSTOMER_NUMBER"
                Else
                    lstCust.DataSource = Nothing
                End If
                lstCust.DataBind()
            End Using
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnUpdateCustNo_Click(sender As Object, e As EventArgs) Handles btnUpdateCustNo.Click
        Try
            If lstCust.SelectedIndex = -1 Then
                notify("Select customer to update", "error")
                Exit Sub
            ElseIf Trim(txtQBAccNo.Text) = "" Then
                notify("Enter Business books account number", "error")
                Exit Sub
            ElseIf Trim(txtECNo.Text) = "" Then
                notify("Enter Escrow account number", "error")
                Exit Sub
            End If
            Dim currAccNo As String = txtECNo.Text
            Using cmd = New SqlCommand("update_account_no", con)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("@qb_acc", txtQBAccNo.Text)
                cmd.Parameters.AddWithValue("@cust_no", currAccNo)
                cmd.Parameters.AddWithValue("@User", Session("UserId"))
                If con.State <> ConnectionState.Closed Then
                    con.Close()
                End If
                con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
                notify("Account Number Updated", "success")
                txtECNo.Text = ""
                txtQBAccNo.Text = ""
                txtSearchName.Text = ""
                lstCust.DataSource = Nothing
                lstCust.DataBind()
                lstCust.Visible = False
            End Using
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub lstCust_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstCust.SelectedIndexChanged
        Try
            txtECNo.Text = lstCust.SelectedValue
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Page.MaintainScrollPositionOnPostBack = True
        con = New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
        If Not IsPostBack Then

        End If
    End Sub
End Class