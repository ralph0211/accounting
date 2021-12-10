Imports System.Data
Imports System.Data.SqlClient
Imports CreditManager

Partial Class Admin_Banks
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Page.MaintainScrollPositionOnPostBack = True
        txtBankCode.Focus()
        Try
            Using cn As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)

                If (Not IsPostBack) Then
                    BindGrid()
                    getBanksToEdit()
                    getBankDetails()
                End If
                BindGrid()
                txtBankCode.Focus()
            End Using
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            Using cn As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd As New SqlCommand("insert into para_bank(bank,bank_name) values('" & txtBankCode.Text & "','" & txtBankName.Text & "')", cn)
                    cn.Open()
                    If cmd.ExecuteNonQuery() Then
                        notify("Bank successfully added", "error")
                    Else
                        txtBankCode.Text = ""
                        txtBankCode.Focus()
                    End If
                    cn.Close()
                    BindGrid()
                    ClearAll()
                End Using
            End Using
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Public Sub ClearAll()
        txtBankCode.Text = ""
        txtBankName.Text = ""
        txtBankCode.Focus()
    End Sub

    Public Sub BindGrid()
        Dim ds As New DataSet
        Try
            Using cn As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd = New SqlCommand("select * from para_bank", cn)
                    Using adp = New SqlDataAdapter(cmd)
                        adp.Fill(ds, "para_bank")
                    End Using
                    grdBank.DataSource = ds
                    grdBank.DataBind()
                End Using
            End Using
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub grdBank_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdBank.PageIndexChanging
        Try
            grdBank.PageIndex = e.NewPageIndex
            BindGrid()
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub getBanksToEdit()
        Try
            Using cn As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Dim ds As New DataSet
                Using cmd = New SqlCommand("select distinct (bank) from para_bank", cn)
                    Using adp = New SqlDataAdapter(cmd)
                        adp.Fill(ds, "para_bank")
                    End Using
                    'If (ds.Tables(0).Rows.Count > 0) Then
                    '        cmbBankUpdate.DataSource = ds.Tables(0)
                    '        cmbBankUpdate.DataValueField = "bank"
                    '        cmbBankUpdate.DataBind()
                    '    End If
                End Using
            End Using
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
    Public Sub getBankDetails()
        'Try
        '    Using cn As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
        '        Dim ds As New DataSet
        '        Using cmd = New SqlCommand("select * from para_bank where bank='" & cmbBankUpdate.Text & "'", cn)
        '            Using adp = New SqlDataAdapter(cmd)
        '                adp.Fill(ds, "para_bank")
        '            End Using

        '            txtBankCodeUpdate.Text = ds.Tables(0).Rows(0).Item("bank").ToString.ToUpper
        '            txtBankNameUpdate.Text = ds.Tables(0).Rows(0).Item("bank_name").ToString.ToUpper

        '            If (CBool(ds.Tables(0).Rows(0).Item("EFT").ToString) = False) Then
        '                chkEft1.Checked = False
        '            Else
        '                chkEft1.Checked = True
        '            End If
        '        End Using
        '    End Using
        'Catch ex As Exception
        '    msgbox(ex.Message)
        'End Try
    End Sub
    'Protected Sub cmbBankUpdate_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbBankUpdate.SelectedIndexChanged
    '    getBankDetails()
    'End Sub

    Public Sub DoUpdate()
        Try
            'If (chkDel.Checked = True) Then
            '    cmd = New SqlCommand("Delete from para_bank where bank='" & cmbBankUpdate.Text & "'", cn)
            '    If (cn.State = ConnectionState.Open) Then
            '        cn.Close()
            '    End If
            '    cn.Open()
            '    cmd.ExecuteNonQuery()
            '    cn.Close()

            '    msgbox("Bank details updated")

            '    BindGrid()

            '    txtBankCodeUpdate.Text = ""
            '    txtBankNameUpdate.Text = ""
            'Else
            Using cn As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                'Using cmd = New SqlCommand("Update para_bank set bank='" & txtBankCode.Text & "', bank_name='" & txtBankName.Text & "' where bank='" & cmbBankUpdate.Text & "'", cn)
                '    If (cn.State = ConnectionState.Open) Then
                '        cn.Open()
                '    End If
                '    cn.Open()
                '    cmd.ExecuteNonQuery()
                '    cn.Close()

                '    msgbox("Bank details updated")

                '    BindGrid()

                '    'txtBankCodeUpdate.Text = ""
                '    'txtBankNameUpdate.Text = ""
                'End Using
            End Using
            'End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub
End Class