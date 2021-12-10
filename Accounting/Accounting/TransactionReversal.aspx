<%@ Page Title="Reverse Committed Transactions" Language="VB" MasterPageFile="~/Site2.master" AutoEventWireup="false" CodeFile="TransactionReversal.aspx.vb" Inherits="Accounting_TransactionReversal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="panel panel-primary small">
        <div class="panel-heading">
            <h4 class="panel-title">
                <a>Reverse Committed Transactions</a>
            </h4>
        </div>
        <div class="panel-body">
            <div class="row">
                <div class="col-xs-2 control-label">
                    Transaction Type
                </div>
                <div class="col-xs-6 control-label">
                    <asp:RadioButtonList ID="rdbTrxnType" runat="server" RepeatDirection="Horizontal" CssClass="col-xs-12" AutoPostBack="true">
                        <asp:ListItem Text="Journal Entry" Value="Journal"></asp:ListItem>
                        <asp:ListItem Text="Loan Disbursement" Value="Disbursement"></asp:ListItem>
                        <asp:ListItem Text="Loan Repayment" Value="Repayment"></asp:ListItem>
                    </asp:RadioButtonList>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-2 control-label">
                    Transaction Details
                </div>
                <div class="col-xs-6">
                    <asp:DropDownList ID="cmbTransactionDetails" runat="server" CssClass="col-xs-12 input-sm chosen" AutoPostBack="true"></asp:DropDownList>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12">
                    <asp:GridView ID="grdDetails" runat="server" EnableModelValidation="True" HorizontalAlign="Center">
                        <AlternatingRowStyle CssClass="altrowstyle" />
                        <HeaderStyle CssClass="headerstyle" HorizontalAlign="center" />
                        <RowStyle CssClass="rowstyle" />
                        <PagerStyle CssClass="pagination-ys" />
                        <SelectedRowStyle BackColor="#A8B1B9" Font-Bold="true" />
                    </asp:GridView>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-2 control-label">
                    Reversal Date
                </div>
                <div class="col-xs-4">
                    <asp:TextBox CssClass="col-xs-12 form-control input-sm nofuturedate" ID="txtReverseDate" runat="server"></asp:TextBox>
                    <span class="glyphicon glyphicon-calendar form-control-feedback" style="margin-right: 13px; background-color: #eeeeff; border-radius: 0 3px 3px 0; border: 1px solid rgb(149,188,219); z-index: 0;"></span>
                </div>
                <div class="col-xs-2 control-label">
                    Description/Reason
                </div>
                <div class="col-xs-4">
                    <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtReverseDesc" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="row text-center">
                <asp:Button ID="btnReverse" runat="server" Text="Reverse Transaction" CssClass="btn btn-sm btn-primary btn-save" />
            </div>
        </div>
    </div>
</asp:Content>