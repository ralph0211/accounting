<%@ Page Title="Loan Approval Stages" Language="VB" MasterPageFile="~/Site2.master" AutoEventWireup="false" CodeFile="ApprovalStageParameters.aspx.vb" Inherits="Credit_ApprovalStageParameters" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .selected {
            background-color: #b3dff8;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="panel panel-primary small">
        <div class="panel-heading">
            <h4 class="panel-title">
                <a>Approval Stages Setup</a>
            </h4>
        </div>
        <div class="panel-body">
            <div class="row">
                <div class="col-xs-2 control-label">
                    Product
                </div>
                <div class="col-xs-4">
                    <asp:DropDownList CssClass="col-xs-12 form-control input-sm" ID="cmbProduct" runat="server" AutoPostBack="True"></asp:DropDownList>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-2 control-label">
                    Role Name
                </div>
                <div class="col-xs-4">
                    <asp:DropDownList CssClass="col-xs-12 form-control input-sm" ID="cmbRole" runat="server"></asp:DropDownList>
                </div>
                <div class="col-xs-2 control-label">
                    Stage Name
                </div>
                <div class="col-xs-4">
                    <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtAppStageName" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-2 control-label">
                    Multiple Approvals
                </div>
                <div class="col-xs-4">
                    <asp:RadioButtonList ID="rdbMultiApproval" runat="server" RepeatDirection="horizontal" CssClass="col-xs-12">
                        <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                        <asp:ListItem Text="No" Value="N"></asp:ListItem>
                    </asp:RadioButtonList>
                </div>
                <div class="col-xs-2 control-label" id="lblNoApprovals">
                    Number of Approvals
                </div>
                <div class="col-xs-4" id="divNoApprovals">
                    <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtNumberOfApprovals" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-2 control-label">
                    Loan Amount Limit
                </div>
                <div class="col-xs-4">
                    <asp:RadioButtonList ID="rdbAmountBased" runat="server" RepeatDirection="horizontal" CssClass="col-xs-12">
                        <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                        <asp:ListItem Text="No" Value="N"></asp:ListItem>
                    </asp:RadioButtonList>
                </div>
                <div class="col-xs-2 control-label" id="lblAmtBased">
                    Minimum Amount
                </div>
                <div class="col-xs-4" id="divAmtBased">
                    <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtAmtBased" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-2 control-label">
                    Loan Process
                </div>
                <div class="col-xs-6 control-label">
                    <asp:RadioButtonList ID="rdbLoanProcess" runat="server" RepeatDirection="Horizontal" CssClass="col-xs-12">
                        <asp:ListItem Text="Loan Origination" Value="Origination"></asp:ListItem>
                        <asp:ListItem Text="Recommendation" Value="Recommendation"></asp:ListItem>
                        <asp:ListItem Text="Approval" Value="Approval"></asp:ListItem>
                        <asp:ListItem Text="Disbursement" Value="Disbursement"></asp:ListItem>
                    </asp:RadioButtonList>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12 text-center">
                    <asp:Button CssClass="btn btn-primary btn-sm save-btn" ID="btnSave" runat="server" Text="Save" UseSubmitBehavior="false" />
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12 center-block">
                    <asp:GridView ID="grdApprovalStages" runat="server" AutoGenerateColumns="False" HorizontalAlign="center">
                        <AlternatingRowStyle CssClass="altrowstyle" />
                        <HeaderStyle CssClass="headerstyle" HorizontalAlign="center" />
                        <RowStyle CssClass="rowstyle" />
                        <Columns>
                            <asp:TemplateField HeaderText="">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkDelete" runat="server" CommandName="Remove" CommandArgument='<%#Eval("ID") %>' OnClientClick="return isDelete();">Remove Process</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Role">
                                <ItemTemplate>
                                    <asp:Label ID="lblRoleName" runat="server" Text='<%#Eval("RoleName")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblModuleId" runat="server" Text='<%#Eval("StageName")%>'></asp:Label>
                                    <input type="hidden" name="lblStageId" value='<%# Eval("ID") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Action">
                                <ItemTemplate>
                                    <asp:Label ID="lblModuleName" runat="server" Text='<%#Eval("StageAction")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Multiple Approvals">
                                <ItemTemplate>
                                    <asp:Label ID="lblMultiApps" runat="server" Text='<%#Eval("IsRoundRobin")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Number of Approvals">
                                <ItemTemplate>
                                    <asp:Label ID="lblNoApps" runat="server" Text='<%#Eval("NoOfApprovers")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Limit Based">
                                <ItemTemplate>
                                    <asp:Label ID="lblAmtLimit" runat="server" Text='<%#Eval("LoanBasedLimit")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Limit">
                                <ItemTemplate>
                                    <asp:Label ID="lblLimitAmount" runat="server" Text='<%#Eval("LimitAmount")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Ranking">
                                <ItemTemplate>
                                    <asp:Label ID="lblURLName" runat="server" Text='<%#Eval("StageOrder")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12 label-info control-label">
                    <asp:Label ID="Label29" runat="server" Font-Bold="True" Text="Drag and drop the approval stages into the desired order and save"></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12 center-block">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <asp:GridView ID="grdApprovalOrder" runat="server" AutoGenerateColumns="False" HorizontalAlign="center">
                                <AlternatingRowStyle CssClass="altrowstyle" />
                                <HeaderStyle CssClass="headerstyle" HorizontalAlign="center" />
                                <RowStyle CssClass="rowstyle" />
                                <Columns>
                                    <asp:TemplateField HeaderText="Role">
                                        <ItemTemplate>
                                            <asp:Label ID="lblRoleName" runat="server" Text='<%#Eval("RoleName")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblModuleId" runat="server" Text='<%#Eval("StageName")%>'></asp:Label>
                                            <input type="hidden" name="lblPermissionId" value='<%# Eval("ID") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Action">
                                        <ItemTemplate>
                                            <asp:Label ID="lblModuleName" runat="server" Text='<%#Eval("StageAction")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Multiple Approvals">
                                        <ItemTemplate>
                                            <asp:Label ID="lblMultiApps" runat="server" Text='<%#Eval("IsRoundRobin")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Number of Approvals">
                                        <ItemTemplate>
                                            <asp:Label ID="lblNoApps" runat="server" Text='<%#Eval("NoOfApprovers")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Limit Based">
                                        <ItemTemplate>
                                            <asp:Label ID="lblAmtLimit" runat="server" Text='<%#Eval("LoanBasedLimit")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Limit">
                                        <ItemTemplate>
                                            <asp:Label ID="lblLimitAmount" runat="server" Text='<%#Eval("LimitAmount")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Ranking">
                                        <ItemTemplate>
                                            <asp:Label ID="lblURLName" runat="server" Text='<%#Eval("StageOrder")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="grdApprovalOrder" EventName="RowCommand" />
                        </Triggers>
                    </asp:UpdatePanel>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12 text-center">
                    <asp:Button CssClass="btn btn-primary btn-sm save-btn" ID="btnSaveOrder" runat="server" Text="Save Approval Order" UseSubmitBehavior="false" />
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        $(function () {
            $("[id*=grdApprovalOrder]").sortable({
                items: 'tr:not(tr:first-child)',
                cursor: 'hand',
                axis: 'y',
                dropOnEmpty: false,
                start: function (e, ui) {
                    ui.item.addClass("selected");
                },
                stop: function (e, ui) {
                    ui.item.removeClass("selected");
                },
                receive: function (e, ui) {
                    $(this).find("tbody").append(ui.item);
                }
            });
        });

        $(document).ready(function () {
            var value = $('[id*=rdbMultiApproval] input:checked').val();
            if (value == 'N') {
                $("#divNoApprovals").show();
                $("#lblNoApprovals").show();
            }
            else if (value == 'Y') {
                $("#divNoApprovals").hide();
                $("#lblNoApprovals").hide();
            }
            else {
                $("#divNoApprovals").hide();
                $("#lblNoApprovals").hide();
            }
        });
        $(document).ready(function () {
            $('[id*=rdbMultiApproval] input').click(function () {
                var value = $('[id*=rdbMultiApproval] input:checked').val();
                if (value == 'Y') {
                    $("#divNoApprovals").show();
                    $("#lblNoApprovals").show();
                }
                else if (value == 'N') {
                    $("#divNoApprovals").hide();
                    $("#lblNoApprovals").hide();
                }
                else {
                    $("#divNoApprovals").hide();
                    $("#lblNoApprovals").hide();
                }
            });
        });

        $(document).ready(function () {
            var value = $('[id*=rdbAmountBased] input:checked').val();
            if (value == 'N') {
                $("#divAmtBased").show();
                $("#lblAmtBased").show();
            }
            else if (value == 'Y') {
                $("#divAmtBased").hide();
                $("#lblAmtBased").hide();
            }
            else {
                $("#divAmtBased").hide();
                $("#lblAmtBased").hide();
            }
        });
        $(document).ready(function () {
            $('[id*=rdbAmountBased] input').click(function () {
                var value = $('[id*=rdbAmountBased] input:checked').val();
                if (value == 'Y') {
                    $("#divAmtBased").show();
                    $("#lblAmtBased").show();
                }
                else if (value == 'N') {
                    $("#divAmtBased").hide();
                    $("#lblAmtBased").hide();
                }
                else {
                    $("#divAmtBased").hide();
                    $("#lblAmtBased").hide();
                }
            });
        });
    </script>
</asp:Content>