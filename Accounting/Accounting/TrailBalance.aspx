<%@ Page Title="Trial Balance" Language="VB" MasterPageFile="~/Site2.master" AutoEventWireup="false" CodeFile="TrailBalance.aspx.vb" Inherits="Accounting_TrailBalance" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="panel panel-primary small">
        <div class="panel-heading">
            <h4 class="panel-title">
                <a>Trial Balance</a>
            </h4>
        </div>
        <div class="panel-body">
            <div class="row">
                <div class="col-xs-2 control-label">
                    Report Type
                </div>
                <div class="col-xs-4">
                    <asp:RadioButtonList ID="rdbReportType" runat="server" RepeatDirection="horizontal" CssClass="col-xs-12">
                        <asp:ListItem Text="Main Accounts Only" Value="Main"></asp:ListItem>
                        <asp:ListItem Text="Detailed Trial Balance" Value="Detail"></asp:ListItem>
                    </asp:RadioButtonList>
                </div>
                <div class="col-xs-1 control-label">
                    <asp:Label ID="Label1220" runat="server" Text="As At"></asp:Label>
                </div>
                <div class="col-xs-4">
                    <asp:TextBox ID="dtpTrxnDate" runat="server" CssClass="form-control input-sm datepicker"></asp:TextBox>
                    <span class="glyphicon glyphicon-calendar form-control-feedback" style="margin-right: 13px; background-color: #eeeeff; border-radius: 0 3px 3px 0; border: 1px solid rgb(149,188,219); z-index: 0;"></span>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12 text-center">
                    <asp:Button CssClass="btn btn-primary btn-sm" ID="Button1" runat="server" Text="Print Report" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>