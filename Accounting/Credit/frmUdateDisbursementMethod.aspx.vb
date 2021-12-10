Imports System.Data
Imports System.Data.SqlClient
Imports System.IO

Partial Class Credit_frmUdateDisbursementMethod
    Inherits System.Web.UI.Page
    Public Shared globLoanID = 0
    Public Shared prevUser As String = ""
    Dim adp As SqlDataAdapter
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

    Protected Sub btnSearch_Click(sender As Object, e As System.EventArgs) Handles btnSearch.Click
        Try

            If txtSearch.Text <> "" Then
                cmd = New SqlCommand("select ID,(SURNAME+' '+FORENAMES) as DISPLAY from Quest_Application where (SURNAME+' '+FORENAMES) like '" & txtSearch.Text & "%'", con)
            Else
                cmd = New SqlCommand("select ID,(SURNAME+' '+FORENAMES) as DISPLAY from Quest_Application", con)
            End If
            Dim ds As New DataSet
            Dim adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "LRS")
            If ds.Tables(0).Rows.Count > 0 Then
                lstCust.Visible = True
                lstCust.DataSource = ds.Tables(0)
                lstCust.DataTextField = "DISPLAY"
                lstCust.DataValueField = "ID"
            Else
                lstCust.DataSource = Nothing
            End If
            lstCust.DataBind()
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnUpdateCustNo_Click(sender As Object, e As System.EventArgs) Handles btnUpdateCustNo.Click
        cmd = New SqlCommand("update QUEST_APPLICATION set DISBURSE_OPTION='" & cmbDisMethod.Text & "' where ID='" & globLoanID & "'", con)
        If con.State = ConnectionState.Open Then
            con.Close()
        End If
        con.Open()
        cmd.ExecuteNonQuery()
        msgbox("Record Successfully Updated")
        txtcustomerNo.Text = ""
        txtName.Text = ""
        txtSearch.Text = ""
        cmbDisMethod.ClearSelection()
    End Sub

    Protected Sub lstCust_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles lstCust.SelectedIndexChanged
        Try
            globLoanID = lstCust.SelectedValue
            'msgbox(lstUnsanctions.SelectedValue)
            cmd = New SqlCommand("select * from Quest_Application where id='" & lstCust.SelectedValue & "' order by ID", con)
            Dim ds As New DataSet
            Dim adp = New SqlDataAdapter(cmd)
            adp.Fill(ds, "APP")
            If ds.Tables(0).Rows.Count > 0 Then
                txtcustomerNo.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("CUSTOMER_NUMBER"))
                txtName.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("SURNAME")) & " " & BankString.isNullString(ds.Tables(0).Rows(0).Item("FORENAMES"))
                cmbDisMethod.Text = BankString.isNullString(ds.Tables(0).Rows(0).Item("DISBURSE_OPTION"))
            End If
        Catch ex As Exception
            msgbox(ex.Message)
        End Try

    End Sub

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        ' isValidSession()
        Page.MaintainScrollPositionOnPostBack = True
        con = New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
        If Not IsPostBack Then

        End If
    End Sub
End Class