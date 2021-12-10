<%@ Page Title="Internal Controls" Language="VB" MasterPageFile="~/Site2.master" AutoEventWireup="false" CodeFile="ParaInternalControls.aspx.vb" Inherits="Credit_ParaInternalControls" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="panel panel-primary small">
        <div class="panel-heading">
            <h4 class="panel-title">
                <a>Internal Controls</a>
            </h4>
        </div>
        <div class="panel-body">
            <div class="row">
                <div class="col-xs-2 control-label">
                    MFI Company Name (SMS Sending)
                </div>
                <div class="col-xs-4">
                    <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtMFICompanyName" runat="server"></asp:TextBox>
                </div>
                <div class="col-xs-2 control-label">
                    Full MFI Company Name (For Reports)
                </div>
                <div class="col-xs-4">
                    <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtFullMFICompanyName" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-3 control-label">
                    Minimum members in group
                </div>
                <div class="col-xs-3">
                    <asp:TextBox CssClass="col-xs-12 form-control input-sm numeric" ID="txtMinGrpMembers" runat="server"></asp:TextBox>
                </div>
                <div class="col-xs-3 control-label">
                    Maximum members in group
                </div>
                <div class="col-xs-3">
                    <asp:TextBox CssClass="col-xs-12 form-control input-sm numeric" ID="txtMaxGrpMembers" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-3 control-label">
                    Maximum Exposure to any 1 client
                </div>
                <div class="col-xs-3">
                    <asp:TextBox CssClass="col-xs-12 form-control input-sm numeric" ID="txtMaxExposure" runat="server"></asp:TextBox>
                </div>
                <div class="col-xs-3 control-label">
                    Maximum running loans to any 1 client
                </div>
                <div class="col-xs-3">
                    <asp:TextBox CssClass="col-xs-12 form-control input-sm numeric" ID="txtMaxRunLoans" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-6 control-label">
                    <asp:CheckBox ID="chkClientMoreThanOneGroup" runat="server" Text="Client can belong to more than one group" />
                </div>
                <div class="col-xs-6 control-label">
                    <asp:CheckBox ID="chkPrePopulateGuarantor" runat="server" Text="Pre-populate previous guarantor for individual applications" />
                </div>
            </div>
            <div class="row label-info">
                <div class="col-xs-12 control-label">
                    Debtor Account Number Settings
                </div>
            </div>
            <div class="row">
                <div class="col-xs-3 control-label">
                    Debtor Account Prefix
                </div>
                <div class="col-xs-3">
                    <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtDebtorPrefix" runat="server"></asp:TextBox>
                </div>
                <div class="col-xs-3 control-label">
                    Debtor Account Separator
                </div>
                <div class="col-xs-3">
                    <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtDebtorSeparator" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-3 control-label">
                    Debtor Account Suffix Option
                </div>
                <div class="col-xs-3">
                    <asp:RadioButtonList ID="rdbDebtorSuffixOption" CssClass="col-xs-12" RepeatDirection="Horizontal" runat="server" AutoPostBack="true">
                        <asp:ListItem Text="Auto-increment" Value="Auto"></asp:ListItem>
                        <asp:ListItem Text="Random" Value="Random"></asp:ListItem>
                    </asp:RadioButtonList>
                </div>
                <div class="col-xs-3 control-label">
                    <asp:Label ID="lblSuffixLength" runat="server" Text="Suffix Length (Number of digits)"></asp:Label>
                </div>
                <div class="col-xs-3">
                    <asp:TextBox CssClass="col-xs-12 form-control input-sm numeric" ID="txtSuffixLength" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-3 control-label">
                    <asp:Label ID="lblSeed" runat="server" Text="Start Value (Seed)" Visible="false"></asp:Label>
                </div>
                <div class="col-xs-3">
                    <asp:TextBox CssClass="col-xs-12 form-control input-sm numeric" ID="txtSeed" runat="server" Visible="false"></asp:TextBox>
                </div>
            </div>
            <div class="row label-info">
                <div class="col-xs-12 control-label">
                    System-generated SMS Settings
                </div>
            </div>
            <div class="row">
                <div class="col-xs-3 control-label">
                    <asp:CheckBox ID="chkSMSDisbursement" runat="server" Text="Send SMS to client on Disbursement" />
                </div>
                <div class="col-xs-3 control-label">
                    <asp:CheckBox ID="chkSMSRepayment" runat="server" Text="Send SMS to client on Repayment" />
                </div>
                <div class="col-xs-3 control-label">
                    <asp:CheckBox ID="chkSMSInstalmentDue" runat="server" Text="Send SMS to client when Instalment Due" />
                </div>
                <div class="col-xs-3 control-label">
                    <asp:CheckBox ID="chkSMSBirthday" runat="server" Text="Send SMS to client on Birthday" />
                </div>
            </div>
            <div class="row">
                <div class="col-xs-3 control-label">
                    <asp:CheckBox ID="chkSMSUserNewApproval" runat="server" Text="Send SMS to system user when new approval received" />
                </div>
                <div class="col-xs-3 control-label">
                    <asp:CheckBox ID="chkSMSUserLocked" runat="server" Text="Send SMS to system user when account locked" />
                </div>
                <div class="col-xs-3 control-label">
                    <asp:CheckBox ID="chkSMSUserUnlocked" runat="server" Text="Send SMS to system user when account unlocked" />
                </div>
                <div class="col-xs-3 control-label">
                    <asp:CheckBox ID="chkSMSUserIncorrectLoginAttempt" runat="server" Text="Send SMS to system user on Incorrect Login Attempt" />
                </div>
            </div>
            <div class="row">
                <div id="DisbTemplate">
                    <div class="col-xs-2 control-label">
                        Disbursement SMS Template
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox ID="txtSMSDisbursementTemplate" runat="server" TextMode="MultiLine" CssClass="col-xs-12 input-sm form-control"></asp:TextBox>
                    </div>
                </div>
                <div id="RepayTemplate">
                    <div class="col-xs-2 control-label">
                        Repayment SMS Template
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox ID="txtSMSRepaymentTemplate" runat="server" TextMode="MultiLine" CssClass="col-xs-12 input-sm form-control"></asp:TextBox>
                    </div>
                </div>
                <div id="InstalmentDueTemplate">
                    <div class="col-xs-2 control-label">
                        Instalment Due SMS Template
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox ID="txtSMSInstalmentDueTemplate" runat="server" TextMode="MultiLine" CssClass="col-xs-12 input-sm form-control"></asp:TextBox>
                    </div>
                </div>
                <div id="BirthdayTemplate">
                    <div class="col-xs-2 control-label">
                        Birthday SMS Template
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox ID="txtSMSBirthdayTemplate" runat="server" TextMode="MultiLine" CssClass="col-xs-12 input-sm form-control"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="row">
                <div id="UserNewApprovalTemplate">
                    <div class="col-xs-2 control-label">
                        New Approval SMS Template
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox ID="txtSMSUserNewApprovalTemplate" runat="server" TextMode="MultiLine" CssClass="col-xs-12 input-sm form-control"></asp:TextBox>
                    </div>
                </div>
                <div id="UserAccountLockedTemplate">
                    <div class="col-xs-2 control-label">
                        User Account Locked SMS Template
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox ID="txtSMSUserAccountLockedTemplate" runat="server" TextMode="MultiLine" CssClass="col-xs-12 input-sm form-control"></asp:TextBox>
                    </div>
                </div>
                <div id="UserAccountUnlockedTemplate">
                    <div class="col-xs-2 control-label">
                        User Account Unlocked SMS Template
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox ID="txtSMSUserAccountUnlockedTemplate" runat="server" TextMode="MultiLine" CssClass="col-xs-12 input-sm form-control"></asp:TextBox>
                    </div>
                </div>
                <div id="UserIncorrectLoginAttemptTemplate">
                    <div class="col-xs-2 control-label">
                        Incorrect Login Attempt SMS Template
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox ID="txtSMSUserIncorrectLoginAttemptTemplate" runat="server" TextMode="MultiLine" CssClass="col-xs-12 input-sm form-control"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12 text-center">
                    <asp:Button CssClass="btn btn-primary btn-sm save-btn" ID="btnSave" runat="server" Text="Save" UseSubmitBehavior="false" />
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        <%-- $(document).ready(
        $("#<%# chkSMSDisbursement.ClientID %>").onchange = function () {
            alert("Checked:" + $("#<%# chkSMSDisbursement.ClientID %>").checked);
        });--%>

        $(document).ready(function () {
            if ("#<%= chkSMSDisbursement.ClientID %>".checked) {
                $('#DisbTemplate').show();
            } else {
                $('#DisbTemplate').hide();
            }
            if ("#<%= chkSMSRepayment.ClientID %>".checked) {
                $('#RepayTemplate').show();
            } else {
                $('#RepayTemplate').hide();
            }
            if ("#<%= chkSMSInstalmentDue.ClientID %>".checked) {
                $('#InstalmentDueTemplate').show();
            } else {
                $('#InstalmentDueTemplate').hide();
            }
            if ("#<%= chkSMSBirthday.ClientID %>".checked) {
                $('#BirthdayTemplate').show();
            } else {
                $('#BirthdayTemplate').hide();
            }
            if ("#<%= chkSMSUserNewApproval.ClientID %>".checked) {
                $('#UserNewApprovalTemplate').show();
            } else {
                $('#UserNewApprovalTemplate').hide();
            }
            if ("#<%= chkSMSUserLocked.ClientID %>".checked) {
                $('#UserAccountLockedTemplate').show();
            } else {
                $('#UserAccountLockedTemplate').hide();
            }
            if ("#<%= chkSMSUserUnlocked.ClientID %>".checked) {
                $('#UserAccountUnlockedTemplate').show();
            } else {
                $('#UserAccountUnlockedTemplate').hide();
            }
            if ("#<%= chkSMSUserIncorrectLoginAttempt.ClientID %>".checked) {
                $('#UserIncorrectLoginAttemptTemplate').show();
            } else {
                $('#UserIncorrectLoginAttemptTemplate').hide();
            }
        });

        $(document).ready(function () {
            $("#<%= chkSMSDisbursement.ClientID %>").change(function () {
                if (this.checked) {
                    $('#DisbTemplate').show();
                } else {
                    $('#DisbTemplate').hide();
                }
            })
            $("#<%= chkSMSRepayment.ClientID %>").change(function () {
                if (this.checked) {
                    $('#RepayTemplate').show();
                } else {
                    $('#RepayTemplate').hide();
                }
            })
            $("#<%= chkSMSInstalmentDue.ClientID %>").change(function () {
                if (this.checked) {
                    $('#InstalmentDueTemplate').show();
                } else {
                    $('#InstalmentDueTemplate').hide();
                }
            })
            $("#<%= chkSMSBirthday.ClientID %>").change(function () {
                if (this.checked) {
                    $('#BirthdayTemplate').show();
                } else {
                    $('#BirthdayTemplate').hide();
                }
            })
            $("#<%= chkSMSUserNewApproval.ClientID %>").change(function () {
                if (this.checked) {
                    $('#UserNewApprovalTemplate').show();
                } else {
                    $('#UserNewApprovalTemplate').hide();
                }
            })
            $("#<%= chkSMSUserLocked.ClientID %>").change(function () {
                if (this.checked) {
                    $('#UserAccountLockedTemplate').show();
                } else {
                    $('#UserAccountLockedTemplate').hide();
                }
            })
            $("#<%= chkSMSUserUnlocked.ClientID %>").change(function () {
                if (this.checked) {
                    $('#UserAccountUnlockedTemplate').show();
                } else {
                    $('#UserAccountUnlockedTemplate').hide();
                }
            })
            $("#<%= chkSMSUserIncorrectLoginAttempt.ClientID %>").change(function () {
                if (this.checked) {
                    $('#UserIncorrectLoginAttemptTemplate').show();
                } else {
                    $('#UserIncorrectLoginAttemptTemplate').hide();
                }
            })
        });
    </script>
</asp:Content>