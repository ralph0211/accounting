<%@ Page Language="VB" MasterPageFile="~/Site2.master" AutoEventWireup="false" CodeFile="frmIndivStmt.aspx.vb" Inherits="Credit_frmIndivStmt" Title="Print Individual Statement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="panel panel-primary small">
        <div class="panel-heading">
            <h4 class="panel-title">
                <a>Print Individual Statement</a>
            </h4>
        </div>
        <div class="panel-body">
            <div class="row">
                <div class="col-xs-3 control-label">
                    <asp:Label ID="Label1" runat="server"
                        Text="Loan Application ID"></asp:Label>
                </div>
                <div class="col-xs-3">
                    <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtLoanID" runat="server"></asp:TextBox>
                </div>
                <div class="col-xs-1">
                    <asp:Button CssClass="btn btn-primary btn-sm" ID="btnSearchLoanID" runat="server" Text=">>" />
                </div>
            </div>
            <div class="row">
                <div class="col-xs-3 control-label">
                    <asp:Label ID="Label2" runat="server"
                        Text="Search by customer name"></asp:Label>
                </div>
                <div class="col-xs-3">
                    <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtSearchName" runat="server"></asp:TextBox>
                </div>
                <div class="col-xs-1">
                    <asp:Button CssClass="btn btn-primary btn-sm" ID="btnSearchName" runat="server" Text=">>" />
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12 center-block">
                    <asp:ListBox ID="lstLoans" runat="server" Visible="False" AutoPostBack="True"></asp:ListBox>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12 center-block">
                    <asp:Button CssClass="btn btn-primary btn-sm" ID="btnPrint" runat="server"
                        Text="Print Statement" Visible="False" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>