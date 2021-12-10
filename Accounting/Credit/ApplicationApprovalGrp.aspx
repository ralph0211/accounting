<%@ Page Language="VB" MasterPageFile="~/Site2.master" AutoEventWireup="false" CodeFile="ApplicationApprovalGrp.aspx.vb" Inherits="Credit_ApplicationApprovalGrp" Title="Loan Application Approval" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="panel panel-primary small">
        <div class="panel-heading">
            <h4 class="panel-title">Loan Application Approval
            </h4>
        </div>
        <div class="panel-body">
            <div class="row">
                <div class="col-xs-2 control-label">
                    <asp:Label ID="Label2" runat="server" Text="Customer Number"></asp:Label>
                </div>
                <div class="col-xs-3">
                    <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" CssClass="col-xs-12 form-control input-sm" ID="txtCustNo" runat="server"></asp:TextBox>
                </div>
                <div class="col-xs-1">
                    <asp:Button CssClass="btn btn-primary btn-sm" ID="btnSearchCustNo" runat="server" Text=">>" Visible="false" />
                </div>
                <div class="col-xs-2 control-label">
                    <asp:Label ID="Label1" runat="server" Text="Client Type"></asp:Label>
                </div>
                <div class="col-xs-4">
                    <asp:DropDownList ReadOnly="True" ForeColor="Black" Font-Bold="true" CssClass="col-xs-12 input-sm form-control" ID="rdbClientType" runat="server" AutoPostBack="True">
                    </asp:DropDownList>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12 center-block">
                    <asp:GridView ID="grdAppHistory" runat="server" HorizontalAlign="center" Caption="Application History">
                        <AlternatingRowStyle CssClass="altrowstyle" />
                        <HeaderStyle CssClass="headerstyle" HorizontalAlign="center" />
                        <RowStyle CssClass="rowstyle" />
                    </asp:GridView>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12 center-block">
                    <div class="row">
                        <div class="col-xs-2 control-label">
                            <asp:Label ID="Label20" runat="server" Text="Group Name"></asp:Label>
                        </div>
                        <div class="col-xs-4">
                            <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" CssClass="col-xs-12 form-control input-sm" ID="txtGrpName" runat="server" Width="165px"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-2 control-label">
                            <asp:Label ID="Label4" runat="server" Text="Branch"></asp:Label>
                        </div>
                        <div class="col-xs-4 control-label">
                            <asp:Label ID="lblBranchCode" runat="server" Text=""></asp:Label>
                            <asp:Label ID="Label5" runat="server" Text="   "></asp:Label>
                            <asp:Label ID="lblBranchName" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-2 control-label">
                            <asp:Label ID="Label62" runat="server" Text="Line/Type of Business"></asp:Label>
                        </div>
                        <div class="col-xs-4">
                            <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" CssClass="col-xs-12 form-control input-sm" ID="txtGrpApplLineBus" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-xs-2 control-label">
                            <asp:Label ID="Label63" runat="server" Text="Period in Business (months)"></asp:Label>
                        </div>
                        <div class="col-xs-4">
                            <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" CssClass="col-xs-12 form-control input-sm" ID="txtGrpApplPeriodBus" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-2 control-label">
                            <asp:Label ID="Label64" runat="server" Text="Loan Amount Required (US$)"></asp:Label>
                        </div>
                        <div class="col-xs-4">
                            <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" CssClass="col-xs-12 form-control input-sm" ID="txtGrpApplLoanAmt" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-xs-2 control-label">
                            <asp:Label ID="Label61" runat="server" Text="Repayment Tenure (months)"></asp:Label>
                        </div>
                        <div class="col-xs-4">
                            <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" CssClass="col-xs-12 form-control input-sm" ID="txtGrpApplRepayTenure" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-2 control-label">
                            <asp:Label ID="Label65" runat="server" Text="Purpose of Loan"></asp:Label>
                        </div>
                        <div class="col-xs-4">
                            <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" CssClass="col-xs-12 form-control input-sm" ID="txtGrpApplPurpose" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-xs-2 control-label">
                            <asp:Label ID="Label1165" runat="server" Text="Interest Rate (%)"></asp:Label>
                        </div>
                        <div class="col-xs-4">
                            <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" CssClass="col-xs-12 form-control input-sm" ID="txtGrpApplInterest" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-2 control-label">
                            <asp:Label ID="Label66" runat="server" Text="Other sources of income"></asp:Label>
                        </div>
                        <div class="col-xs-3">
                            <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" CssClass="col-xs-12 form-control input-sm" ID="txtGrpApplSrcIncome1" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-xs-3">
                            <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" CssClass="col-xs-12 form-control input-sm" ID="txtGrpApplSrcIncome2" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-xs-3">
                            <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" CssClass="col-xs-12 form-control input-sm" ID="txtGrpApplSrcIncome3" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-2 control-label">
                            <asp:Label ID="Label70" runat="server" Text="Other Borrowings"></asp:Label>
                        </div>
                        <div class="col-xs-3">
                            <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" CssClass="col-xs-12 form-control input-sm" ID="txtGrpApplBorrow1" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-xs-3">
                            <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" CssClass="col-xs-12 form-control input-sm" ID="txtGrpApplBorrow2" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-xs-3">
                            <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" CssClass="col-xs-12 form-control input-sm" ID="txtGrpApplBorrow3" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-2 control-label">
                            <asp:Label ID="Label21" runat="server" Text="Admin Fees"></asp:Label>
                        </div>
                        <div class="col-xs-4">
                            <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" CssClass="col-xs-12 form-control input-sm" ID="txtGrpAdminFee" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-xs-2 control-label hidden">
                            <asp:CheckBox ID="chkGrpApplSigned" runat="server" Text="Signed" />
                        </div>
                        <div class="col-xs-2 control-label">
                            Application Date
                        </div>
                        <div class="col-xs-4">
                            <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" ID="txtGrpAppDate" runat="server" CssClass="col-xs-12 form-control input-sm nofuturedate"></asp:TextBox>
                            <span class="glyphicon glyphicon-calendar form-control-feedback" style="margin-right: 13px; background-color: #eeeeff; border-radius: 0 3px 3px 0; border: 1px solid rgb(149,188,219); z-index: 0;"></span>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-2 control-label">
                            <asp:Label ID="Label74" runat="server"
                                Text="Position" Visible="False"></asp:Label>
                        </div>
                        <div class="col-xs-4">
                            <asp:DropDownList CssClass="col-xs-12 input-sm form-control" ID="cmbGrpDeclPosition" runat="server" Visible="False">
                                <asp:ListItem Text="" Value=""></asp:ListItem>
                                <asp:ListItem Text="Chairperson" Value="Chairperson"></asp:ListItem>
                                <asp:ListItem Text="Member" Value="Member"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="col-xs-2 control-label">
                            <asp:Label ID="Label75" runat="server"
                                Text="Name" Visible="False"></asp:Label>
                        </div>
                        <div class="col-xs-4">
                            <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" CssClass="col-xs-12 form-control input-sm" ID="txtGrpDeclName" runat="server" Visible="False"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-2 control-label">
                            <asp:Label ID="Label76" runat="server"
                                Text="ID No" Visible="False"></asp:Label>
                        </div>
                        <div class="col-xs-4">
                            <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" CssClass="col-xs-12 form-control input-sm" ID="txtGrpDeclIDNo" runat="server" Visible="False"></asp:TextBox>
                        </div>
                        <div class="col-xs-2 control-label">
                            <asp:Label ID="Label77" runat="server"
                                Text="Signature" Visible="False"></asp:Label>
                        </div>
                        <div class="col-xs-4">
                            <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" CssClass="col-xs-12 form-control input-sm" ID="txtGrpDeclSignature" runat="server" Visible="False"></asp:TextBox>
                            <asp:Button CssClass="btn btn-primary btn-sm" ID="btnGrpDeclAdd" runat="server"
                                Text="Add" Visible="False" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-12 center-block">
                            <asp:GridView ID="grdGrpDeclMembers" runat="server" HorizontalAlign="center">
                                <AlternatingRowStyle CssClass="altrowstyle" />
                                <HeaderStyle CssClass="headerstyle" HorizontalAlign="center" />
                                <RowStyle CssClass="rowstyle" />
                            </asp:GridView>
                        </div>
                    </div>
                    <div class="row label-info">
                        <div class="col-xs-12 center-block">
                            <asp:Label ID="Label78" runat="server" Text="Members Expense List (If Applicable)" Font-Bold="True"></asp:Label>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-12 center-block">
                            <asp:GridView ID="grdGrpDeclExpense" runat="server" HorizontalAlign="center">
                                <AlternatingRowStyle CssClass="altrowstyle" />
                                <HeaderStyle CssClass="headerstyle" HorizontalAlign="center" />
                                <RowStyle CssClass="rowstyle" />
                                <Columns>
                                    <asp:CommandField ShowEditButton="True" />
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-2 control-label">
                            <asp:Label ID="Label15" runat="server" Text="Recommended Amount (US$)"></asp:Label>
                        </div>
                        <div class="col-xs-4">
                            <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtRecAmt" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-xs-2 control-label">
                            <asp:Label ID="Label17" runat="server" Text="Comment"></asp:Label>
                        </div>
                        <div class="col-xs-4">
                            <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtComment" runat="server" TextMode="MultiLine"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-2 control-label">
                            <asp:Label ID="lblDisburseDate" runat="server" Text="Disbursement Date" Visible="False"></asp:Label>
                        </div>
                        <div class="col-xs-4">
                            <asp:TextBox CssClass="col-xs-12 form-control input-sm nofuturedate" ID="txtDisburseDate" runat="server" Visible="False"></asp:TextBox>
                            <span class="glyphicon glyphicon-calendar form-control-feedback" style="margin-right: 13px; background-color: #eeeeff; border-radius: 0 3px 3px 0; border: 1px solid rgb(149,188,219);" runat="server" id="disbSpan" visible="false"></span>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-12 text-center">
                            <asp:Button CssClass="btn btn-primary btn-sm" ID="btnGenAgrmt" runat="server" Text="Generate Agreement" Visible="false" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-12 text-center">
                            <asp:Button CssClass="btn btn-success btn-sm" ID="btnGrpSubmitApp" runat="server" Text="Submit" />
                            <asp:Button CssClass="btn btn-danger btn-sm" ID="btnGrpReject" runat="server" Text="Reject" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>