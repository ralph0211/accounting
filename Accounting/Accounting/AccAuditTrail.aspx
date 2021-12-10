<%@ Page Title="Accounts Transactions Audit Trail" Language="VB" MasterPageFile="~/Site2.master" AutoEventWireup="false" CodeFile="AccAuditTrail.aspx.vb" Inherits="Accounting_AccAuditTrail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="panel panel-primary small">
        <div class="panel-heading">
            <h4 class="panel-title">Accounts Transactions Audit Trail
            </h4>
        </div>
        <div class="panel-body">
            <div class="row">
                <div class="col-xs-2 control-label">
                    <asp:Label ID="lblAccount" runat="server" Text="Transaction Type"></asp:Label>
                </div>
                <div class="col-xs-4">
                    <asp:DropDownList ID="cmbTrxnType" runat="server" CssClass="col-xs-12 form-control input-sm chosen" AutoPostBack="true">
                        <asp:ListItem Text="" Value=""></asp:ListItem>
                        <asp:ListItem Text="Disbursement" Value="1"></asp:ListItem>
                        <asp:ListItem Text="Repayment" Value="2"></asp:ListItem>
                        <%--<asp:ListItem Text="Interest Payable" Value="3"></asp:ListItem>--%>
                        <asp:ListItem Text="Journal Entries" Value="4"></asp:ListItem>
                        <asp:ListItem Text="Receipts" Value="5"></asp:ListItem>
                        <asp:ListItem Text="All" Value="6"></asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="col-xs-2 control-label">
                    <asp:Label ID="lblAccdsount" runat="server" Text="Batch Reference"></asp:Label>
                </div>
                <div class="col-xs-4">
                    <asp:DropDownList ID="cmbBatchRef" runat="server" CssClass="col-xs-12 form-control input-sm chosen">
                    </asp:DropDownList>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-2 control-label">
                    <asp:Label ID="Label1220" runat="server" Text="From Date"></asp:Label>
                </div>
                <div class="col-xs-4">
                    <asp:TextBox ID="bdpFromDate" runat="server" CssClass="col-xs-12 form-control input-sm nofuturedate"></asp:TextBox>
                    <span class="glyphicon glyphicon-calendar form-control-feedback" style="margin-right: 13px; background-color: #eeeeff; border-radius: 0 3px 3px 0; border: 1px solid rgb(149,188,219); z-index: 0;"></span>
                </div>
                <div class="col-xs-2 control-label">
                    <asp:Label ID="Label12" runat="server" Text="To Date"></asp:Label>
                </div>
                <div class="col-xs-4">
                    <asp:TextBox ID="bdpToDate" runat="server" CssClass="col-xs-12 form-control input-sm nofuturedate"></asp:TextBox>
                    <span class="glyphicon glyphicon-calendar form-control-feedback" style="margin-right: 13px; background-color: #eeeeff; border-radius: 0 3px 3px 0; border: 1px solid rgb(149,188,219); z-index: 0;"></span>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12 text-center">
                    <asp:Button CssClass="btn btn-primary btn-sm" ID="btnPrint" runat="server" Text="Print Report" UseSubmitBehavior="false" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>