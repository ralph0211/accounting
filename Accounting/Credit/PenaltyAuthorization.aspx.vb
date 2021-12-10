Imports System.Data
Imports System.Data.SqlClient
Imports CreditManager
Imports ErrorLogging

Partial Class Credit_PenaltyAuthorization
    Inherits System.Web.UI.Page

    Protected Sub chkAll_CheckedChanged(sender As Object, e As EventArgs) Handles chkAll.CheckedChanged
        Try
            If grdPenalties.Rows.Count > 0 Then
                If chkAll.Checked Then
                    For Each row As GridViewRow In grdPenalties.Rows
                        Dim chkView As CheckBox = DirectCast(row.FindControl("chk"), CheckBox)
                        chkView.Checked = True
                    Next
                Else
                    For Each row As GridViewRow In grdPenalties.Rows
                        Dim chkView As CheckBox = DirectCast(row.FindControl("chk"), CheckBox)
                        chkView.Checked = False
                    Next
                End If
            End If
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- chkAll_CheckedChanged()", ex.ToString)
        End Try
    End Sub

    Protected Sub getPenalties(tDate As String)
        Try
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd As New SqlCommand("select CustNo,loanid,InstalmentNo,InstalmentDueDate,InstalmentBalance,isnull(CONVERT(VARCHAR,PenaltyInterestRate),'')+'% '+isnull(PenaltyInterval,'') as PenaltyRate,round(SUM(PenaltyAmount),2) as PenaltyAmount,ISNULL(surname,'')+' '+isnull(forenames,'') as Name,IDNO from penalties pen JOIN QUEST_APPLICATION qa ON qa.ID=loanid WHERE penaltyCalcDate<=@tDate AND (Posted IS NULL OR Posted=0) AND (Discarded IS NULL OR Discarded=0) GROUP by CustNo,loanid,InstalmentNo,InstalmentDueDate,InstalmentBalance,PenaltyInterestRate,PenaltyInterval,qa.SURNAME,qa.FORENAMES,qa.IDNO", con)
                    cmd.Parameters.AddWithValue("@tDate", tDate)
                    Dim dt As New DataTable
                    Using adp As New SqlDataAdapter(cmd)
                        adp.Fill(dt)
                    End Using
                    bindGrid(dt, grdPenalties)
                End Using
            End Using
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- getPenalties()", ex.ToString)
        End Try
    End Sub

    Private Sub Credit_PenaltyAuthorization_Load(sender As Object, e As EventArgs) Handles Me.Load
        Page.MaintainScrollPositionOnPostBack = True
        If Not IsPostBack Then
            txtUptoDate.Text = Now.ToString("dd MMM yyyy")
            btnSearchDate_Click(sender, e)
        End If
    End Sub
    Protected Sub btnSearchDate_Click(sender As Object, e As EventArgs) Handles btnSearchDate.Click
        Try
            If IsDate(txtUptoDate.Text) Then
                getPenalties(txtUptoDate.Text)
            End If
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- btnSearchDate_Click()", ex.ToString)
        End Try
    End Sub
    Protected Sub btnAuthorize_Click(sender As Object, e As EventArgs) Handles btnAuthorize.Click
        Try
            For Each row As GridViewRow In grdPenalties.Rows
                Dim chk As CheckBox = DirectCast(row.FindControl("chk"), CheckBox)
                If chk.Checked Then
                    'Dim cstNo = CType(row.FindControl(""), TextBox).Text
                    Dim cstNo = row.Cells(2).Text
                    Dim lID = row.Cells(5).Text
                    saveTransaction(lID, "Penalty Charged", toMoney(getClientPenalty(cstNo, txtUptoDate.Text)), 0, cstNo, "218/15", "1", "", "", "", "", txtUptoDate.Text)
                    Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                        Using cmd As New SqlCommand("update Penalties set Posted=1,PostedBy=@PostBy,PostDate=GETDATE() where CustNo=@cstNo", con)
                            cmd.Parameters.AddWithValue("@PostBy", Session("UserId"))
                            cmd.Parameters.AddWithValue("@cstNo", cstNo)
                            con.Open()
                            cmd.ExecuteNonQuery()
                            con.Close()
                        End Using
                    End Using
                End If
            Next
            notify("Penalty authorized", "success")
            getPenalties(txtUptoDate.Text)
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- btnAuthorize_Click()", ex.ToString)
        End Try
    End Sub

    Protected Function getClientPenalty(cstNo As String, calDate As String) As Double
        Try
            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd As New SqlCommand("select round(sum(PenaltyAmount),2) as PenaltyAmount from Penalties where CustNo=@cstNo and penaltyCalcDate<=@tDate AND (Posted IS NULL OR Posted=0) AND (Discarded IS NULL OR Discarded=0)", con)
                    cmd.Parameters.AddWithValue("@cstNo", cstNo)
                    cmd.Parameters.AddWithValue("@tDate", calDate)
                    Dim dt As New DataTable
                    Using adp As New SqlDataAdapter(cmd)
                        adp.Fill(dt)
                    End Using
                    If dt.Rows.Count > 0 Then
                        Return dt.Rows(0).Item("PenaltyAmount")
                    Else
                        Return 0
                    End If
                End Using
            End Using
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- getClientPenalty()", ex.ToString)
            Return 0
        End Try
    End Function

    Protected Sub recordPenaltyTransaction()
        Try

        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- recordPenaltyTransaction()", ex.ToString)
        End Try
    End Sub

    Protected Sub saveTransaction(reference As String, description As String, debit As Double, credit As Double, account As String, contra As String, status As String, other As String, bankAccId As String, bankAccName As String, batchRef As String, trxnDate As Date)
        Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
            Using cmd As New SqlCommand("SaveAccountsTrxnsWithContra", con)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("@Type", "System Entry")
                cmd.Parameters.AddWithValue("@Category", "Penalty")
                cmd.Parameters.AddWithValue("@Ref", reference)
                cmd.Parameters.AddWithValue("@Desc", description)
                cmd.Parameters.AddWithValue("@Debit", debit)
                cmd.Parameters.AddWithValue("@Credit", credit)
                cmd.Parameters.AddWithValue("@Account", account)
                cmd.Parameters.AddWithValue("@ContraAccount", contra)
                cmd.Parameters.AddWithValue("@Status", status)
                cmd.Parameters.AddWithValue("@Other", other)
                cmd.Parameters.AddWithValue("@BankAccID", bankAccId)
                cmd.Parameters.AddWithValue("@BankAccName", bankAccName)
                cmd.Parameters.AddWithValue("@BatchRef", batchRef)
                cmd.Parameters.AddWithValue("@TrxnDate", trxnDate)
                cmd.Parameters.AddWithValue("@CaptureBy", Session("UserId"))

                If con.State = ConnectionState.Open Then
                    con.Close()
                End If
                con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            End Using
        End Using
    End Sub
End Class