Imports System.Data
Imports System.Data.SqlClient
Imports ErrorLogging
Imports CreditManager

Partial Class Credit_ParaInternalControls
    Inherits System.Web.UI.Page

    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            If Trim(txtMaxExposure.Text) = "" Then
                notify("Enter maximum exposure", "error")
                txtMaxExposure.Focus()
            ElseIf Trim(txtMaxGrpMembers.Text) = "" Then
                notify("Enter maximum group members", "error")
                txtMaxGrpMembers.Focus()
            ElseIf Trim(txtMaxRunLoans.Text) = "" Then
                notify("Enter the maximum running loans", "error")
                txtMaxRunLoans.Focus()
            ElseIf Trim(txtMinGrpMembers.Text) = "" Then
                notify("Enter the minimum group members", "error")
                txtMinGrpMembers.Focus()
            ElseIf Trim(txtDebtorPrefix.Text) = "" Then
                notify("Enter the Debtor Account prefix", "error")
                txtDebtorPrefix.Focus()
            ElseIf Trim(txtDebtorSeparator.Text) = "" Then
                notify("Enter the Debtor Account separator", "error")
                txtDebtorSeparator.Focus()
            ElseIf rdbDebtorSuffixOption.SelectedIndex = -1 Then
                notify("Select the Debtor Account suffix option", "error")
                rdbDebtorSuffixOption.Focus()
            ElseIf Trim(txtSuffixLength.Text) = "" Or Not IsNumeric(txtSuffixLength.Text) Then
                notify("Enter numeric value for Suffix length", "error")
                txtSuffixLength.Focus()
            ElseIf rdbDebtorSuffixOption.SelectedValue = "Auto" And Not IsNumeric(txtSeed.Text) Then
                notify("Enter the start value for auto-increment account number", "error")
                txtSeed.Focus()
            Else
                Using con As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                    If isSaved() Then
                        Using cmd = New SqlCommand("update ParaInternalControls set MinGrpMembers=@MinGrpMembers,MaxGrpMembers=@MaxGrpMembers,MaxExposure=@MaxExposure,MaxNoLoans=@MaxNoLoans,ClientMoreThanOneGroup=@ClientMoreThanOneGroup,PrePopulateGuarantor=@PrePopulateGuarantor,AccountPrefix=@AccountPrefix,AccountSeparator=@AccountSeparator,AccountSuffixOption=@AccountSuffixOption,SuffixLength=@SuffixLength,AccountSeed=@AccountSeed,SMSClientDisbursement=@SMSClientDisbursement,SMSClientRepayment=@SMSClientRepayment,SMSClientInstalmentDue=@SMSClientInstalmentDue,SMSClientBirthday=@SMSClientBirthday,SMSUserApproval=@SMSUserApproval,SMSUserAccountLocked=@SMSUserAccountLocked,SMSUserAccountUnlocked=@SMSUserAccountUnlocked,SMSUserIncorrectLoginAttempt=@SMSUserIncorrectLoginAttempt,SMSClientDisbursementText=@SMSClientDisbursementText,SMSClientRepaymentText=@SMSClientRepaymentText,SMSClientInstalmentDueText=@SMSClientInstalmentDueText,SMSClientBirthdayText=@SMSClientBirthdayText,SMSUserApprovalText=@SMSUserApprovalText,SMSUserAccountLockedText=@SMSUserAccountLockedText,SMSUserAccountUnlockedText=@SMSUserAccountUnlockedText,SMSUserIncorrectLoginAttemptText=@SMSUserIncorrectLoginAttemptText,MFICompanyName=@MFICompanyName,FullMFICompanyName=@FullMFICompanyName", con)
                            cmd.Parameters.AddWithValue("@MinGrpMembers", txtMinGrpMembers.Text)
                            cmd.Parameters.AddWithValue("@MaxGrpMembers", txtMaxGrpMembers.Text)
                            cmd.Parameters.AddWithValue("@MaxExposure", txtMaxExposure.Text)
                            cmd.Parameters.AddWithValue("@MaxNoLoans", txtMaxRunLoans.Text)
                            cmd.Parameters.AddWithValue("@ClientMoreThanOneGroup", chkClientMoreThanOneGroup.Checked)
                            cmd.Parameters.AddWithValue("@PrePopulateGuarantor", chkPrePopulateGuarantor.Checked)
                            cmd.Parameters.AddWithValue("@AccountPrefix", txtDebtorPrefix.Text)
                            cmd.Parameters.AddWithValue("@AccountSeparator", txtDebtorSeparator.Text)
                            cmd.Parameters.AddWithValue("@AccountSuffixOption", rdbDebtorSuffixOption.SelectedValue)
                            cmd.Parameters.AddWithValue("@SuffixLength", txtSuffixLength.Text)
                            cmd.Parameters.AddWithValue("@AccountSeed", IIf(rdbDebtorSuffixOption.SelectedValue = "Auto", txtSeed.Text, DBNull.Value))
                            cmd.Parameters.AddWithValue("@SMSClientDisbursement", chkSMSDisbursement.Checked)
                            cmd.Parameters.AddWithValue("@SMSClientRepayment", chkSMSRepayment.Checked)
                            cmd.Parameters.AddWithValue("@SMSClientInstalmentDue", chkSMSInstalmentDue.Checked)
                            cmd.Parameters.AddWithValue("@SMSClientBirthday", chkSMSBirthday.Checked)
                            cmd.Parameters.AddWithValue("@SMSUserApproval", chkSMSUserNewApproval.Checked)
                            cmd.Parameters.AddWithValue("@SMSUserAccountLocked", chkSMSUserLocked.Checked)
                            cmd.Parameters.AddWithValue("@SMSUserAccountUnlocked", chkSMSUserUnlocked.Checked)
                            cmd.Parameters.AddWithValue("@SMSUserIncorrectLoginAttempt", chkSMSUserIncorrectLoginAttempt.Checked)
                            cmd.Parameters.AddWithValue("@SMSClientDisbursementText", txtSMSDisbursementTemplate.Text)
                            cmd.Parameters.AddWithValue("@SMSClientRepaymentText", txtSMSRepaymentTemplate.Text)
                            cmd.Parameters.AddWithValue("@SMSClientInstalmentDueText", txtSMSInstalmentDueTemplate.Text)
                            cmd.Parameters.AddWithValue("@SMSClientBirthdayText", txtSMSBirthdayTemplate.Text)
                            cmd.Parameters.AddWithValue("@SMSUserApprovalText", txtSMSUserNewApprovalTemplate.Text)
                            cmd.Parameters.AddWithValue("@SMSUserAccountLockedText", txtSMSUserAccountLockedTemplate.Text)
                            cmd.Parameters.AddWithValue("@SMSUserAccountUnlockedText", txtSMSUserAccountUnlockedTemplate.Text)
                            cmd.Parameters.AddWithValue("@SMSUserIncorrectLoginAttemptText", txtSMSUserIncorrectLoginAttemptTemplate.Text)
                            cmd.Parameters.AddWithValue("@MFICompanyName", txtMFICompanyName.Text)
                            cmd.Parameters.AddWithValue("@FullMFICompanyName", txtFullMFICompanyName.Text)
                            con.Open()
                            If cmd.ExecuteNonQuery() Then
                                notify("Controls saved", "success")
                            Else
                                notify("Error saving controls", "error")
                            End If
                            con.Close()
                        End Using
                    Else
                        Using cmd = New SqlCommand("insert into ParaInternalControls (MinGrpMembers,MaxGrpMembers,MaxExposure,MaxNoLoans,ClientMoreThanOneGroup,PrePopulateGuarantor,AccountPrefix,AccountSeparator,AccountSuffixOption,SuffixLength,AccountSeed,SMSClientDisbursement,SMSClientRepayment,SMSClientInstalmentDue,SMSClientBirthday,SMSUserApproval,SMSUserAccountLocked,SMSUserAccountUnlocked,SMSUserIncorrectLoginAttempt,SMSClientDisbursementText,SMSClientRepaymentText,SMSClientInstalmentDueText,SMSClientBirthdayText,SMSUserApprovalText,SMSUserAccountLockedText,SMSUserAccountUnlockedText,SMSUserIncorrectLoginAttemptText,MFICompanyName,FullMFICompanyName) values (@MinGrpMembers,@MaxGrpMembers,@MaxExposure,@MaxNoLoans,@ClientMoreThanOneGroup,@PrePopulateGuarantor,@AccountPrefix,@AccountSeparator,@AccountSuffixOption,@SuffixLength,@AccountSeed,@SMSClientDisbursement,@SMSClientRepayment,@SMSClientInstalmentDue,@SMSClientBirthday,@SMSUserApproval,@SMSUserAccountLocked,@SMSUserAccountUnlocked,@SMSUserIncorrectLoginAttempt,@SMSClientDisbursementText,@SMSClientRepaymentText,@SMSClientInstalmentDueText,@SMSClientBirthdayText,@SMSUserApprovalText,@SMSUserAccountLockedText,@SMSUserAccountUnlockedText,@SMSUserIncorrectLoginAttemptText,@MFICompanyName,@FullMFICompanyName)", con)
                            cmd.Parameters.AddWithValue("@MinGrpMembers", txtMinGrpMembers.Text)
                            cmd.Parameters.AddWithValue("@MaxGrpMembers", txtMaxGrpMembers.Text)
                            cmd.Parameters.AddWithValue("@MaxExposure", txtMaxExposure.Text)
                            cmd.Parameters.AddWithValue("@MaxNoLoans", txtMaxRunLoans.Text)
                            cmd.Parameters.AddWithValue("@ClientMoreThanOneGroup", chkClientMoreThanOneGroup.Checked)
                            cmd.Parameters.AddWithValue("@PrePopulateGuarantor", chkPrePopulateGuarantor.Checked)
                            cmd.Parameters.AddWithValue("@AccountPrefix", txtDebtorPrefix.Text)
                            cmd.Parameters.AddWithValue("@AccountSeparator", txtDebtorSeparator.Text)
                            cmd.Parameters.AddWithValue("@AccountSuffixOption", rdbDebtorSuffixOption.SelectedValue)
                            cmd.Parameters.AddWithValue("@SuffixLength", txtSuffixLength.Text)
                            cmd.Parameters.AddWithValue("@AccountSeed", IIf(rdbDebtorSuffixOption.SelectedValue = "Auto", txtSeed.Text, DBNull.Value))
                            cmd.Parameters.AddWithValue("@SMSClientDisbursement", chkSMSDisbursement.Checked)
                            cmd.Parameters.AddWithValue("@SMSClientRepayment", chkSMSRepayment.Checked)
                            cmd.Parameters.AddWithValue("@SMSClientInstalmentDue", chkSMSInstalmentDue.Checked)
                            cmd.Parameters.AddWithValue("@SMSClientBirthday", chkSMSBirthday.Checked)
                            cmd.Parameters.AddWithValue("@SMSUserApproval", chkSMSUserNewApproval.Checked)
                            cmd.Parameters.AddWithValue("@SMSUserAccountLocked", chkSMSUserLocked.Checked)
                            cmd.Parameters.AddWithValue("@SMSUserAccountUnlocked", chkSMSUserUnlocked.Checked)
                            cmd.Parameters.AddWithValue("@SMSUserIncorrectLoginAttempt", chkSMSUserIncorrectLoginAttempt.Checked)
                            cmd.Parameters.AddWithValue("@SMSClientDisbursementText", txtSMSDisbursementTemplate.Text)
                            cmd.Parameters.AddWithValue("@SMSClientRepaymentText", txtSMSRepaymentTemplate.Text)
                            cmd.Parameters.AddWithValue("@SMSClientInstalmentDueText", txtSMSInstalmentDueTemplate.Text)
                            cmd.Parameters.AddWithValue("@SMSClientBirthdayText", txtSMSBirthdayTemplate.Text)
                            cmd.Parameters.AddWithValue("@SMSUserApprovalText", txtSMSUserNewApprovalTemplate.Text)
                            cmd.Parameters.AddWithValue("@SMSUserAccountLockedText", txtSMSUserAccountLockedTemplate.Text)
                            cmd.Parameters.AddWithValue("@SMSUserAccountUnlockedText", txtSMSUserAccountUnlockedTemplate.Text)
                            cmd.Parameters.AddWithValue("@SMSUserIncorrectLoginAttemptText", txtSMSUserIncorrectLoginAttemptTemplate.Text)
                            cmd.Parameters.AddWithValue("@MFICompanyName", txtMFICompanyName.Text)
                            cmd.Parameters.AddWithValue("@FullMFICompanyName", txtFullMFICompanyName.Text)
                            con.Open()
                            If cmd.ExecuteNonQuery() Then
                                notify("Controls saved", "success")
                            Else
                                notify("Error saving stage", "error")
                            End If
                            con.Close()
                        End Using
                    End If
                End Using
            End If
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- btnSave_Click()", ex.ToString)
        End Try
    End Sub

    Protected Sub getInternalControls()
        Try
            Using con As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd = New SqlCommand("select * from ParaInternalControls", con)
                    Dim ds As New DataSet
                    Using adp = New SqlDataAdapter(cmd)
                        adp.Fill(ds)
                    End Using
                    If ds.Tables(0).Rows.Count > 0 Then
                        Dim dr = ds.Tables(0).Rows(0)
                        txtMaxRunLoans.Text = dr("MaxNoLoans")
                        txtMinGrpMembers.Text = dr("MinGrpMembers")
                        txtMaxGrpMembers.Text = dr("MaxGrpMembers")
                        Try
                            txtMaxExposure.Text = FormatNumber(dr("MaxExposure"), 2)
                        Catch ex As Exception
                            txtMaxExposure.Text = ""
                        End Try
                        Try
                            chkClientMoreThanOneGroup.Checked = dr("ClientMoreThanOneGroup")
                        Catch ex As Exception
                            chkClientMoreThanOneGroup.Checked = False
                        End Try
                        Try
                            chkPrePopulateGuarantor.Checked = dr("PrePopulateGuarantor")
                        Catch ex As Exception
                            chkPrePopulateGuarantor.Checked = False
                        End Try
                        Try
                            txtDebtorPrefix.Text = dr("AccountPrefix")
                        Catch ex As Exception
                            txtDebtorPrefix.Text = ""
                        End Try
                        Try
                            txtDebtorSeparator.Text = dr("AccountSeparator")
                        Catch ex As Exception
                            txtDebtorSeparator.Text = ""
                        End Try
                        Try
                            rdbDebtorSuffixOption.SelectedValue = dr("AccountSuffixOption")
                        Catch ex As Exception
                            rdbDebtorSuffixOption.ClearSelection()
                        End Try
                        showSeed()
                        Try
                            txtSuffixLength.Text = dr("SuffixLength")
                        Catch ex As Exception
                            txtSuffixLength.Text = ""
                        End Try
                        Try
                            txtSeed.Text = dr("AccountSeed")
                        Catch ex As Exception
                            txtSeed.Text = ""
                        End Try

                        Try
                            chkSMSDisbursement.Checked = dr("SMSClientDisbursement")
                        Catch ex As Exception
                            chkSMSDisbursement.Checked = False
                        End Try
                        Try
                            chkSMSRepayment.Checked = dr("SMSClientRepayment")
                        Catch ex As Exception
                            chkSMSRepayment.Checked = False
                        End Try
                        Try
                            chkSMSInstalmentDue.Checked = dr("SMSClientInstalmentDue")
                        Catch ex As Exception
                            chkSMSInstalmentDue.Checked = False
                        End Try
                        Try
                            chkSMSBirthday.Checked = dr("SMSClientBirthday")
                        Catch ex As Exception
                            chkSMSBirthday.Checked = False
                        End Try
                        Try
                            chkSMSUserNewApproval.Checked = dr("SMSUserApproval")
                        Catch ex As Exception
                            chkSMSUserNewApproval.Checked = False
                        End Try
                        Try
                            chkSMSUserLocked.Checked = dr("SMSUserAccountLocked")
                        Catch ex As Exception
                            chkSMSUserLocked.Checked = False
                        End Try
                        Try
                            chkSMSUserUnlocked.Checked = dr("SMSUserAccountUnlocked")
                        Catch ex As Exception
                            chkSMSUserUnlocked.Checked = False
                        End Try
                        Try
                            chkSMSUserIncorrectLoginAttempt.Checked = dr("SMSUserIncorrectLoginAttempt")
                        Catch ex As Exception
                            chkSMSUserIncorrectLoginAttempt.Checked = False
                        End Try
                        Try
                            txtSMSDisbursementTemplate.Text = dr("SMSClientDisbursementText")
                        Catch ex As Exception
                            txtSMSDisbursementTemplate.Text = ""
                        End Try
                        Try
                            txtSMSRepaymentTemplate.Text = dr("SMSClientRepaymentText")
                        Catch ex As Exception
                            txtSMSRepaymentTemplate.Text = ""
                        End Try
                        Try
                            txtSMSInstalmentDueTemplate.Text = dr("SMSClientInstalmentDueText")
                        Catch ex As Exception
                            txtSMSInstalmentDueTemplate.Text = ""
                        End Try
                        Try
                            txtSMSBirthdayTemplate.Text = dr("SMSClientBirthdayText")
                        Catch ex As Exception
                            txtSMSBirthdayTemplate.Text = ""
                        End Try
                        Try
                            txtSMSUserNewApprovalTemplate.Text = dr("SMSUserApprovalText")
                        Catch ex As Exception
                            txtSMSUserNewApprovalTemplate.Text = ""
                        End Try
                        Try
                            txtSMSUserAccountLockedTemplate.Text = dr("SMSUserAccountLockedText")
                        Catch ex As Exception
                            txtSMSUserAccountLockedTemplate.Text = ""
                        End Try
                        Try
                            txtSMSUserAccountUnlockedTemplate.Text = dr("SMSUserAccountUnlockedText")
                        Catch ex As Exception
                            txtSMSUserAccountUnlockedTemplate.Text = ""
                        End Try
                        Try
                            txtSMSUserIncorrectLoginAttemptTemplate.Text = dr("SMSUserIncorrectLoginAttemptText")
                        Catch ex As Exception
                            txtSMSUserIncorrectLoginAttemptTemplate.Text = ""
                        End Try
                        Try
                            txtMFICompanyName.Text = dr("MFICompanyName")
                        Catch ex As Exception
                            txtMFICompanyName.Text = ""
                        End Try
                    End If
                End Using
            End Using
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- getInternalControls()", ex.ToString)
        End Try
    End Sub

    Protected Function isSaved() As Boolean
        Try
            Using con As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("Constring").ConnectionString)
                Using cmd = New SqlCommand("select * from ParaInternalControls", con)
                    Dim ds As New DataSet
                    Using adp = New SqlDataAdapter(cmd)
                        adp.Fill(ds)
                    End Using
                    If ds.Tables(0).Rows.Count > 0 Then
                        Return True
                    Else
                        Return False
                    End If
                End Using
            End Using
        Catch ex As Exception
            WriteLogFile(Session("UserId"), Request.Url.ToString & " --- isSaved()", ex.ToString)
            Return False
        End Try
    End Function
    Protected Sub rdbDebtorSuffixOption_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rdbDebtorSuffixOption.SelectedIndexChanged
        showSeed()
    End Sub

    Protected Sub showSeed()
        If rdbDebtorSuffixOption.SelectedValue = "Auto" Then
            txtSeed.Visible = True
            lblSeed.Visible = True
        Else
            txtSeed.Visible = False
            lblSeed.Visible = False
        End If
    End Sub

    Private Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Page.MaintainScrollPositionOnPostBack = True
        If Not IsPostBack Then
            getInternalControls()
        End If
    End Sub
End Class