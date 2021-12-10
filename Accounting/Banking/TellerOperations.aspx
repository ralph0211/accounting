<%@ Page Title="Teller Operations" Language="VB" MasterPageFile="~/Site2.master" AutoEventWireup="false" CodeFile="TellerOperations.aspx.vb" Inherits="Banking_TellerOperations" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="panel panel-primary small">
        <div class="panel-heading">
            <h4 class="panel-title">
                <a>Teller Operations</a>
            </h4>
        </div>
        <div class="panel-body">
            <div class="row alert-info">
                <div class="col-xs-2 control-label">
                    Vault Balance:&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblVaultBalance" runat="server" Text=""></asp:Label>
                </div>
                <div class="col-xs-2 control-label">

                    <asp:Label ID="lblVaultAccNo" runat="server" Text="" Visible="false"></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-2 control-label">
                    Bank Teller
                </div>
                <div class="col-xs-4">
                    <asp:DropDownList ID="cmbBankTeller" runat="server" CssClass="col-xs-12 form-control input-sm"></asp:DropDownList>
                </div>
                <div class="col-xs-2 control-label">
                    Transaction Type
                </div>
                <div class="col-xs-4">
                    <asp:RadioButtonList ID="rdbTransactionType" runat="server" CssClass="col-xs-12 input-sm" RepeatDirection="Horizontal">
                        <asp:ListItem Text="Deposit into Teller Account" Value="Deposit"></asp:ListItem>
                        <asp:ListItem Text="Withdraw from Teller Account" Value="Withdrawal"></asp:ListItem>
                    </asp:RadioButtonList>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-2 control-label">
                    Transaction Date
                </div>
                <div class="col-xs-4">
                    <asp:TextBox ID="txtTrxnDate" runat="server" CssClass="col-xs-12 form-control input-sm nofuturedate"></asp:TextBox>
                    <span class="glyphicon glyphicon-calendar form-control-feedback" style="margin-right: 13px; background-color: #eeeeff; border-radius: 0 3px 3px 0; border: 1px solid rgb(149,188,219); z-index: 0;"></span>
                </div>
                <div class="col-xs-2 control-label">
                    Amount
                </div>
                <div class="col-xs-4">
                    <asp:TextBox ID="txtAmount" runat="server" CssClass="col-xs-12 form-control input-sm numeric"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-2 control-label">
                    Comment/Description
                </div>
                <div class="col-xs-4">
                    <asp:TextBox ID="txtComment" runat="server" CssClass="col-xs-12 form-control input-sm" TextMode="MultiLine"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12 text-center">
                    <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-sm btn-primary save-btn" UseSubmitBehavior="false" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>