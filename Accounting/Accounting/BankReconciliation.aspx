<%@ Page Title="Bank Reconciliation Report" Language="VB" MasterPageFile="~/Site2.master" AutoEventWireup="false" CodeFile="BankReconciliation.aspx.vb" Inherits="Accounting_BankReconciliation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="panel panel-primary small">
        <div class="panel-heading">
            <h4 class="panel-title">
                <a>Bank Reconciliation Statement</a>
            </h4>
        </div>
        <div class="panel-body">
            <div class="row">
                <div class="col-xs-2 control-label">
                    Bank Account
                </div>
                <div class="col-xs-4">
                    <asp:DropDownList CssClass="form-control input-sm" ID="cmbBankAccount" runat="server"></asp:DropDownList>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-2 control-label">
                    <asp:Label ID="Label1220" runat="server" Text="Reconciliation Date"></asp:Label>
                </div>
                <div class="col-xs-4">
                    <asp:TextBox ID="txtFromDate" runat="server" CssClass="form-control input-sm datepicker"></asp:TextBox>
                    <span class="glyphicon glyphicon-calendar form-control-feedback" style="margin-right: 13px; background-color: #eeeeff; border-radius: 0 3px 3px 0; border: 1px solid rgb(149,188,219); z-index:99;"></span>
                </div>
                <div class="col-xs-3 control-label">
                    <asp:Label ID="Label1221" runat="server" Text="Bank Statement Balance"></asp:Label>
                </div>
                <div class="col-xs-3">
                    <asp:TextBox ID="txtBankStmtBal" runat="server" CssClass="form-control input-sm numeric"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12 text-center">
                    <asp:Button CssClass="btn btn-primary btn-sm" ID="btnPrint" runat="server" Text="Print Report" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>