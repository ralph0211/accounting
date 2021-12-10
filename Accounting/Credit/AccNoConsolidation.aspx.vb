Imports System.Data
Imports System.Data.SqlClient

Partial Class Credit_AccNoConsolidation
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

    Protected Sub btnSearchAccToKeep_Click(sender As Object, e As EventArgs) Handles btnSearchAccToKeep.Click
        Try
            loadAccount(Trim(txtAccToKeep.Text))
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnSearchOldAcc_Click(sender As Object, e As EventArgs) Handles btnSearchOldAcc.Click
        Try
            loadOldAccount(Trim(txtSearchOldAcc.Text))
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnUpdateCustNo_Click(sender As Object, e As EventArgs) Handles btnUpdateCustNo.Click
        Try
            Dim accToKeep As String = ""
            Dim oldAccNo As String = ""
            accToKeep = lstAccToKeep.SelectedValue
            oldAccNo = lstOldAcc.SelectedValue
            If accToKeep.Substring(0, 4) <> "213/" Then
                msgbox("Select 213 account to keep")
            ElseIf accToKeep = "" Or oldAccNo = "" Then
                msgbox("Select each account")
            Else
                cmd = New SqlCommand("update_old_account", con)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("@old_acc", oldAccNo)
                cmd.Parameters.AddWithValue("@acc_to_keep", accToKeep)
                If con.State <> ConnectionState.Closed Then
                    con.Close()
                End If
                con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
                msgbox("Account Number Updated")
                loadAccount(Trim(txtAccToKeep.Text))
                loadOldAccount(Trim(txtSearchOldAcc.Text))
            End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub loadAccount(Optional search As String = "")
        Try
            If search <> "" Then
                cmd = New SqlCommand("select CUSTOMER_NUMBER,ltrim(isnull(SURNAME,'')+' ')+ltrim(isnull(FORENAMES,'')+' ')+ltrim(isnull(CUSTOMER_NUMBER,'')+' ')+ltrim(isnull(IDNO,'')+' ')+isnull(ADDRESS,'') as DISPLAY from CUSTOMER_DETAILS where ltrim(isnull(SURNAME,'')+' ')+ltrim(isnull(FORENAMES,'')+' ')+ltrim(isnull(CUSTOMER_NUMBER,'')+' ')+ltrim(isnull(IDNO,'')+' ')+isnull(ADDRESS,'') like '%" & Trim(search) & "%' order by DISPLAY", con)
            Else
                cmd = New SqlCommand("select CUSTOMER_NUMBER,ltrim(isnull(SURNAME,'')+' ')+ltrim(isnull(FORENAMES,'')+' ')+ltrim(isnull(CUSTOMER_NUMBER,'')+' ')+ltrim(isnull(IDNO,'')+' ')+isnull(ADDRESS,'') as DISPLAY from CUSTOMER_DETAILS order by DISPLAY", con)
            End If
            Dim ds As New DataSet
            Dim adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "LRS")
            If ds.Tables(0).Rows.Count > 0 Then
                lstAccToKeep.Visible = True
                lstAccToKeep.DataSource = ds.Tables(0)
                lstAccToKeep.DataTextField = "DISPLAY"
                lstAccToKeep.DataValueField = "CUSTOMER_NUMBER"
            Else
                lstAccToKeep.DataSource = Nothing
            End If
            lstAccToKeep.DataBind()
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub loadOldAccount(Optional search As String = "")
        Try
            If search <> "" Then
                cmd = New SqlCommand("select CUSTOMER_NUMBER,ltrim(isnull(SURNAME,'')+' ')+ltrim(isnull(FORENAMES,'')+' ')+ltrim(isnull(CUSTOMER_NUMBER,'')+' ')+ltrim(isnull(IDNO,'')+' ')+isnull(ADDRESS,'') as DISPLAY from CUSTOMER_DETAILS where ltrim(isnull(SURNAME,'')+' ')+ltrim(isnull(FORENAMES,'')+' ')+ltrim(isnull(CUSTOMER_NUMBER,'')+' ')+ltrim(isnull(IDNO,'')+' ')+isnull(ADDRESS,'') like '%" & Trim(search) & "%' order by DISPLAY", con)
            Else
                cmd = New SqlCommand("select CUSTOMER_NUMBER,ltrim(isnull(SURNAME,'')+' ')+ltrim(isnull(FORENAMES,'')+' ')+ltrim(isnull(CUSTOMER_NUMBER,'')+' ')+ltrim(isnull(IDNO,'')+' ')+isnull(ADDRESS,'') as DISPLAY from CUSTOMER_DETAILS order by DISPLAY", con)
            End If
            Dim ds As New DataSet
            Dim adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "LRS")
            If ds.Tables(0).Rows.Count > 0 Then
                lstOldAcc.Visible = True
                lstOldAcc.DataSource = ds.Tables(0)
                lstOldAcc.DataTextField = "DISPLAY"
                lstOldAcc.DataValueField = "CUSTOMER_NUMBER"
            Else
                lstOldAcc.DataSource = Nothing
            End If
            lstOldAcc.DataBind()
        Catch ex As Exception
            msgbox(ex.Message)
        End Try
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Page.MaintainScrollPositionOnPostBack = True
        con = New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
        If Not IsPostBack Then
            loadAccount()
            loadOldAccount()
        End If
    End Sub
End Class