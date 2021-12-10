<%@ Page Title="Balance Sheet" Language="VB" MasterPageFile="~/Site2.master" AutoEventWireup="false" CodeFile="BalanceSheet.aspx.vb" Inherits="Accounting_BalanceSheet" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="panel panel-primary small">
        <div class="panel-heading">
            <h4 class="panel-title">
                <a>Balance Sheet</a>
            </h4>
        </div>
        <div class="panel-body">
            <div class="row">
                <div class="col-xs-3 control-label">
                    <asp:Label ID="Label1220" runat="server" Text="Date From"></asp:Label>
                </div>
                <div class="col-xs-3">
                    <asp:TextBox ID="dtpTrxnDate" runat="server" CssClass="form-control input-sm datepicker"></asp:TextBox>
                    <span class="glyphicon glyphicon-calendar form-control-feedback" style="margin-right: 13px; background-color: #eeeeff; border-radius: 0 3px 3px 0; border: 1px solid rgb(149,188,219); z-index: 0;"></span>
                </div>
                <div class="col-xs-3 control-label">
                    <asp:Label ID="Label1221" runat="server" Text="Date To"></asp:Label>
                </div>
                <div class="col-xs-3">
                    <asp:TextBox ID="dtpTrxnDate0" runat="server" CssClass="form-control input-sm datepicker"></asp:TextBox>
                    <span class="glyphicon glyphicon-calendar form-control-feedback" style="margin-right: 13px; background-color: #eeeeff; border-radius: 0 3px 3px 0; border: 1px solid rgb(149,188,219); z-index: 0;"></span>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12 text-center">
                    <asp:Button ID="Button1" runat="server" Text="Print Report" CssClass="btn btn-primary btn-sm" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>