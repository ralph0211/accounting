Imports System.Data.SqlClient
Imports System.Data
Partial Class Accounting_BankAccounts
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

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Page.MaintainScrollPositionOnPostBack = True
        con = New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
        If Not IsPostBack Then
            Try
                loadGrid()
                loadBanks()
            Catch ex As Exception
                msgbox(ex.ToString)
            End Try
        End If
    End Sub


    Protected Sub loadBanks()
        Try
            cmd = New SqlCommand("select * from para_bank", con)
            Dim ds As New DataSet
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "banks")
            If ds.Tables(0).Rows.Count > 0 Then
                cmbBank.DataSource = ds
                cmbBank.DataTextField = "bank_name"
                cmbBank.DataValueField = "bank"
                cmbBank.DataBind()
                cmbBank.Items.Add("-Select-")
                cmbBank.SelectedIndex = cmbBank.Items.Count - 1
            Else
                cmbBank.DataSource = Nothing
                cmbBank.DataBind()
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Protected Sub loadBranch()
        Try
            cmd = New SqlCommand("select * from para_branch where bank = '" & cmbBank.SelectedValue & "'", con)
            Dim ds As New DataSet
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "banks")
            If ds.Tables(0).Rows.Count > 0 Then
                cmbBranch.DataSource = ds
                cmbBranch.DataTextField = "branch_name"
                cmbBranch.DataValueField = "branch"
                cmbBranch.DataBind()
                cmbBranch.Items.Add("-Select-")
                cmbBranch.SelectedIndex = cmbBank.Items.Count - 1
            Else
                cmbBranch.DataSource = Nothing
                cmbBranch.DataBind()
            End If

        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub cmbAccount_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbBank.SelectedIndexChanged
        loadBranch()
    End Sub

    Protected Sub btnSaveTrxn3_Click(sender As Object, e As EventArgs) Handles btnSaveTrxn3.Click

        Try
            cmd = New SqlCommand("SaveBankAccs", con)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@AccName", txtCode.Text)
            cmd.Parameters.AddWithValue("@bankname", cmbBank.SelectedItem.Text)
            cmd.Parameters.AddWithValue("@bankcode", cmbBank.SelectedValue)
            cmd.Parameters.AddWithValue("@branchname", cmbBranch.SelectedItem.Text)
            cmd.Parameters.AddWithValue("@branchcode", cmbBranch.SelectedValue)
            cmd.Parameters.AddWithValue("@AccNo", txtAccNo.Text)
            cmd.Parameters.AddWithValue("@AccBal", txtAccNo0.Text)
            cmd.Parameters.AddWithValue("@CreatedBy", Session("UserID").ToString)
            cmd.Parameters.AddWithValue("@CreatedOn", Date.Today.ToString)
            cmd.Parameters.AddWithValue("@strType", "Save")

            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            con.Open()
            If cmd.ExecuteNonQuery() Then
                CreateBankBalance()
                msgbox("Account Added")
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

    Public Sub CreateBankBalance()
        Try
            Dim cramount, dramount As Double
            dramount = 0.0
            cramount = CDbl(txtAccNo0.Text)
            Dim bankid As Integer
            Try
                cmd = New SqlCommand("select id from [tbl_BankAccounts] where code = '" & txtCode.Text & "'", con)
                Dim ds As New DataSet
                adp = New SqlDataAdapter(cmd)
                adp.Fill(ds, "banks")
                If ds.Tables(0).Rows.Count > 0 Then
                    bankid = ds.Tables(0).Rows(0).Item("id").ToString
                End If

            Catch ex As Exception
                msgbox(ex.Message)
            End Try
            cmd = New SqlCommand("SaveAccountsTrxns", con)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@Type", "Bank Acc Setup")
            cmd.Parameters.AddWithValue("@Category", "")
            cmd.Parameters.AddWithValue("@Ref", "")
            cmd.Parameters.AddWithValue("@Desc", "Account Balance Bank Account Setup")
            cmd.Parameters.AddWithValue("@Debit", 0.0)
            cmd.Parameters.AddWithValue("@Credit", 0.0)
            cmd.Parameters.AddWithValue("@Account", "Bank")
            cmd.Parameters.AddWithValue("@ContraAccount", "")
            cmd.Parameters.AddWithValue("@Status", 1)
            cmd.Parameters.AddWithValue("@Other", "N/a")
            cmd.Parameters.AddWithValue("@BankAccID", bankid)
            cmd.Parameters.AddWithValue("@BankAccName", txtCode.Text)
            cmd.Parameters.AddWithValue("@BatchRef", "BASU")
            cmd.Parameters.AddWithValue("@TrxnDate", Date.Now.ToShortDateString)

                If con.State = ConnectionState.Open Then
                    con.Close()
                End If
                con.Open()
                If cmd.ExecuteNonQuery() Then
                    msgbox("Account Balance Updated Successfully")
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

    Protected Sub loadGrid()
        Try
            cmd = New SqlCommand("select Code, Bank, Branch, BranchCode, AccountNumber, CreatedBy,CreatedOn, AccountBalance from tbl_BankAccounts", con)
            Dim ds As New DataSet
            adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "banks")
            If ds.Tables(0).Rows.Count > 0 Then
                grdDetails.DataSource = ds.Tables(0)
                grdDetails.DataBind()
            Else
                grdDetails.DataSource = Nothing
                grdDetails.DataBind()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub ClearFeilds()
        txtAccNo.Text = ""
        txtCode.Text = ""
        cmbBank.SelectedIndex = cmbBank.Items.Count - 1
        cmbBranch.DataSource = Nothing
        cmbBranch.DataBind()
    End Sub

    Protected Sub grdDetails_SelectedIndexChanged(sender As Object, e As EventArgs) Handles grdDetails.SelectedIndexChanged
        Try
            cmbBank.SelectedIndex = 2
            txtCode.Text = grdDetails.SelectedRow.Cells(1).Text
            txtAccNo.Text = grdDetails.SelectedRow.Cells(5).Text
            txtAccNo0.Text = IIf(grdDetails.SelectedRow.Cells(8).Text = "&nbsp;", "", grdDetails.SelectedRow.Cells(8).Text)
            cmbBank.SelectedItem.Text = grdDetails.SelectedRow.Cells(2).Text
            cmbAccount_SelectedIndexChanged(Me, e)
            cmbBranch.SelectedItem.Text = grdDetails.SelectedRow.Cells(3).Text
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnSaveTrxn4_Click(sender As Object, e As EventArgs) Handles btnSaveTrxn4.Click

        Try
            cmd = New SqlCommand("SaveBankAccs", con)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@AccName", txtCode.Text)
            cmd.Parameters.AddWithValue("@bankname", cmbBank.SelectedItem.Text)
            cmd.Parameters.AddWithValue("@bankcode", cmbBank.SelectedValue)
            cmd.Parameters.AddWithValue("@branchname", cmbBranch.SelectedItem.Text)
            cmd.Parameters.AddWithValue("@branchcode", cmbBranch.SelectedValue)
            cmd.Parameters.AddWithValue("@AccNo", txtAccNo.Text)
            cmd.Parameters.AddWithValue("@AccBal", txtAccNo0.Text)
            cmd.Parameters.AddWithValue("@CreatedBy", Session("UserID").ToString)
            cmd.Parameters.AddWithValue("@CreatedOn", Date.Today.ToString)
            cmd.Parameters.AddWithValue("@strType", "Update")

            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            con.Open()
            If cmd.ExecuteNonQuery() Then
                msgbox("Account Added")
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
End Class
