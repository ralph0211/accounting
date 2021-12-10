<%@ Page Title="Cashbook Report" Language="VB" MasterPageFile="~/Site2.master" AutoEventWireup="false" CodeFile="CashbookReport.aspx.vb" Inherits="Accounting_CashbookReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="panel panel-primary small">
        <div class="panel-heading">
            <h4 class="panel-title">
                <a>Cashbook Report</a>
            </h4>
        </div>
        <div class="panel-body">
            <div class="row">
                <div class="col-xs-2 control-label hidden">
                    Report Type
                </div>
                <div class="col-xs-4 hidden">
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
                    <asp:Button CssClass="btn btn-primary btn-sm" ID="btnPrint" runat="server" Text="Print Report" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>