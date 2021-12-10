Imports System.Data
Imports System.Data.SqlClient
Imports ErrorLogging
Imports CreditManager
Imports SecureBank

Partial Class Credit_ApprovalStageParameters
    Inherits System.Web.UI.Page

    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            If cmbRole.SelectedValue = "" Then
                notify("Select role", "error")
            ElseIf rdbLoanProcess.SelectedIndex = -1 Then
                notify("Select the action to perform", "error")
            ElseIf Trim(txtAppStageName.Text) = "" Then
                notify("Enter the name of the stage", "error")
            ElseIf rdbMultiApproval.SelectedValue = "Y" And (Not IsNumeric(txtNumberOfApprovals.Text) Or BankString.isNullNumber(txtNumberOfApprovals.Text) <= 0) Then
                notify("Enter the number of approvals for this stage", "error")
            ElseIf rdbAmountBased.SelectedValue = "Y" And (Not IsNumeric(txtAmtBased.Text) Or BankString.isNullNumber(txtAmtBased.Text) <= 0) Then
                notify("Enter the number of approvals for this stage", "error")
            ElseIf cmbProduct.Text = "" Then
                notify("Select Product", "error")
            Else
                Using con As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                    Using cmd = New SqlCommand("insert into ParaApprovalStages (RoleId,StageName,StageAction,IsRoundRobin,NoOfApprovers,LoanBasedLimit,LimitAmount,FinProductType) values (@RoleId,@StageName,@StageAction,@IsRoundRobin,@NoOfApprovers,@LoanBasedLimit,@LimitAmount,@FinProductType)", con)
                        cmd.Parameters.AddWithValue("@RoleId", cmbRole.SelectedValue)
                        cmd.Parameters.AddWithValue("@StageName", txtAppStageName.Text)
                        cmd.Parameters.AddWithValue("@StageAction", rdbLoanProcess.SelectedValue)
                        cmd.Parameters.AddWithValue("@IsRoundRobin", validateRadiobutton(rdbMultiApproval))
                        cmd.Parameters.AddWithValue("@NoOfApprovers", validateNumeric(txtNumberOfApprovals.Text))
                        cmd.Parameters.AddWithValue("@LoanBasedLimit", validateRadiobutton(rdbAmountBased))
                        cmd.Parameters.AddWithValue("@LimitAmount", validateNumeric(txtAmtBased.Text))
                        cmd.Parameters.AddWithValue("@FinProductType", cmbProduct.SelectedValue)
                        con.Open()
                        If cmd.ExecuteNonQuery() Then
                            notify("Stage saved. Save the approval order to effect the approval stage", "success")
                            recordAction("Insert", "Saved new approval stage: " & txtAppStageName.Text)
                            getApprovalStages()
                            cmbRole.ClearSelection()
                            txtAppStageName.Text = ""
                            rdbLoanProcess.ClearSelection()
                        Else
                            notify("Error saving stage", "error")
                        End If
                        con.Close()
                    End Using
                End Using
            End If
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- btnSave_Click()", ex.ToString)
        End Try
    End Sub

    Protected Sub btnSaveOrder_Click(sender As Object, e As EventArgs) Handles btnSaveOrder.Click
        Try
            Dim locationIds As Integer() = (From p In Request.Form("lblPermissionId").Split(",")
                                            Select Integer.Parse(p)).ToArray()
            Dim preference As Integer = 1
            For Each locationId As Integer In locationIds
                Me.UpdatePreference(locationId, preference)
                preference += 1
            Next
            notify("New loan approval order saved", "success")
            recordAction("Insert", "Saved new approval order")
            getApprovalStages()
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- btnSaveOrder_Click()", ex.ToString)
        End Try
    End Sub
    Protected Sub getApprovalStages()
        Try
            If cmbProduct.Text <> "" Then
                Using con As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                    Using cmd = New SqlCommand("select pas.*,mr.RoleName from ParaApprovalStages pas join master_roles mr on pas.roleid=mr.RoleID WHERE FinProductType='" & cmbProduct.SelectedValue & "' order by StageOrder asc", con)
                        Dim ds As New DataSet
                        Using adp = New SqlDataAdapter(cmd)
                            adp.Fill(ds)
                        End Using
                        bindGrid(ds.Tables(0), grdApprovalStages)
                        bindGrid(ds.Tables(0), grdApprovalOrder)
                    End Using
                End Using
            End If
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- getApprovalStages()", ex.ToString)
        End Try
    End Sub

    Private Sub grdApprovalStages_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles grdApprovalStages.RowCommand
        Try
            If e.CommandName = "Remove" Then
                Dim stageID = e.CommandArgument
                Using con As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                    Using cmd = New SqlCommand("delete from ParaApprovalStages where id=@stageID", con)
                        cmd.Parameters.AddWithValue("@stageId", stageID)
                        con.Open()
                        If cmd.ExecuteNonQuery() Then
                            notify("Stage removed", "success")
                            recordAction("Delete", "Deleted approval stage: " & txtAppStageName.Text)
                            getApprovalStages()
                        Else
                            notify("Error removing stage", "error")
                        End If
                        con.Close()
                    End Using
                End Using
            End If
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- grdApprovalStages_RowCommand()", ex.ToString)
        End Try
    End Sub

    Private Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Page.MaintainScrollPositionOnPostBack = True
        If Not IsPostBack Then
            loadUserRoles(cmbRole)
            getProducts()
            getApprovalStages()
        End If
    End Sub
    Protected Sub getProducts()
        Try
            Using con As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd = New SqlCommand("select * from creditproducts order by id asc", con)
                    Dim ds As New DataSet
                    Using adp = New SqlDataAdapter(cmd)
                        adp.Fill(ds)
                    End Using
                    If ds.Tables(0).Rows.Count > 0 Then
                        cmbProduct.DataSource = ds
                        cmbProduct.DataTextField = "DisplayName"
                        cmbProduct.DataValueField = "ID"
                        cmbProduct.DataBind()
                    Else
                        cmbProduct.DataSource = Nothing
                        cmbProduct.DataBind()
                    End If
                End Using
            End Using
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- getApprovalStages()", ex.ToString)
        End Try
    End Sub
    Private Sub UpdatePreference(locationId As Integer, preference As Integer)
        Try
            Dim constr As String = ConfigurationManager.ConnectionStrings("conString").ConnectionString
            Using con As New SqlConnection(constr)
                Using cmd As New SqlCommand("UPDATE [ParaApprovalStages] SET [StageOrder] = @Preference WHERE Id = @Id")
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
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- UpdatePreference()", ex.ToString)
        End Try
    End Sub
    Protected Sub cmbProduct_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbProduct.SelectedIndexChanged
        getApprovalStages()
    End Sub
End Class