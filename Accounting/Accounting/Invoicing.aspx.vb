Imports System
Imports System.Data
Imports System.Data.SqlClient

Partial Class Accounting_Invoicing
    Inherits System.Web.UI.Page
    Dim cmd As SqlCommand
    Dim con As New SqlConnection
    Dim adp As New SqlDataAdapter
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

    Protected Sub btnSaveTrxn_Click(sender As Object, e As EventArgs) Handles btnSaveTrxn.Click
        Try
            Session("Ref") = grdDetails.Rows(0).Cells(3).Text
            Dim strscript As String
            strscript = "<script langauage=JavaScript>"
            strscript += "window.open('rotInvoicePrint.aspx')"
            strscript += "</script>"
            ClientScript.RegisterStartupScript(Me.GetType(), "newwin", strscript)
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub loadGrid()
        Try
            cmd = New SqlCommand("select * from tbl_Invoice where Refrence= '" & txtRef.Text & "'", con)
            Dim ds As New DataSet
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "Accounts")
            If ds.Tables(0).Rows.Count > 0 Then
                grdDetails.DataSource = ds.Tables(0)
                grdDetails.DataBind()
            Else
                grdDetails.DataSource = Nothing
                grdDetails.DataBind()
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub btnSaveTrxn3_Click(sender As Object, e As EventArgs) Handles btnSaveTrxn3.Click
        Try
            cmd = New SqlCommand("SaveInvoices", con)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@Type", IIf(rdbAccountType.SelectedIndex = 0, "Creditors", "Debitors"))
            cmd.Parameters.AddWithValue("@Date", dtpTrxnDate.Text)
            cmd.Parameters.AddWithValue("@Ref", txtRef.Text)
            cmd.Parameters.AddWithValue("@Desc", txtdesc.Text)
            cmd.Parameters.AddWithValue("@Amount", CDbl(txtAmount.Text))
            cmd.Parameters.AddWithValue("@Account", cmbAccount.SelectedValue)

            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            con.Open()
            If cmd.ExecuteNonQuery() Then
                msgbox("Invoice Saved Successfully")
                loadGrid()
                ClearFeilds()

            Else
                msgbox("Error Saving Details")
            End If
            con.Close()
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Public Sub ClearFeilds()
        txtAmount.Text = ""
        txtdesc.Text = ""
        txtRef.Text = ""
        cmbAccount.SelectedIndex = cmbAccount.Items.Count - 1
        rdbType0.SelectedIndex = -1
    End Sub

    Protected Sub rdbAccountType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rdbAccountType.SelectedIndexChanged
        If rdbAccountType.SelectedIndex = 0 Then
            loadFinAccs(221)
        Else
            loadFinAccs(100)
        End If
    End Sub

    Protected Sub loadFinAccs(ByVal strType As Integer)
        Try
            cmd = New SqlCommand("select * from tbl_FinancialAccountsCreation where [MainAccount]='" & strType & "'", con)
            Dim ds As New DataSet
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "AccountsTypes")
            If ds.Tables(0).Rows.Count > 0 Then
                cmbAccount.DataSource = ds
                cmbAccount.DataValueField = "AccountName"
                cmbAccount.DataBind()
                cmbAccount.Items.Add("-Select-")
                cmbAccount.SelectedIndex = cmbAccount.Items.Count - 1
            Else
                cmbAccount.DataSource = Nothing
                cmbAccount.DataBind()
            End If

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Page.MaintainScrollPositionOnPostBack = True
        con = New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
        If Not IsPostBack Then
            Try

            Catch ex As Exception

            End Try
        End If

    End Sub
End Class