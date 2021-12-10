Imports System
Imports System.Data
Imports System.Data.SqlClient

Partial Class Accounting_rotInvoicePrint
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
                cmd = New SqlCommand("select   Refrence,CONVERT(varchar, TrxnDate,106) AS 'Trxn-Date', Description, Amount  from tbl_Invoice where Refrence= '" & Session("Ref").ToString & "'", con)
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

            Try
                cmd = New SqlCommand("SELECT a.[Type], Refrence, Account, Amount, a.[Description], CONVERT(date, TrxnDate) AS TrxnDate, 'Att: ' + b.Contact + CHAR(13) + b.PhysicalAddress + CHAR(13) + B.TelNo+ CHAR(13) + B.FaxNo + CHAR(13) + b.Email  as Address FROM tbl_Invoice a, tbl_DebtorCreditors b where a.Account= b.AccountName and Refrence= '" & Session("Ref").ToString & "'", con)
                Dim ds As New DataSet
                adp = New SqlDataAdapter(cmd)
                adp.Fill(ds, "Accounts")
                If ds.Tables(0).Rows.Count > 0 Then
                    lblAddress.Text = ds.Tables(0).Rows(0).Item("Address").ToString

                Else
                    grdDetails.DataSource = Nothing
                    grdDetails.DataBind()
                End If
            Catch ex As Exception
                msgbox(ex.Message)
            End Try
        End If
    End Sub
End Class
