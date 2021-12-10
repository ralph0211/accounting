<%@ Page Title="" Language="VB" MasterPageFile="~/Site2.master" AutoEventWireup="false" CodeFile="AccountNoUpdate.aspx.vb" Inherits="Credit_AccountNoUpdate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="panel panel-primary small">
        <div class="panel-heading">
            <h4 class="panel-title">Accounts Update
            </h4>
        </div>
        <div class="panel-body">
            <div class="row">
                <div class="col-xs-2 control-label">
                    <asp:Label ID="Label1" runat="server" Text="Escrow Account Number"></asp:Label>
                </div>
                <div class="col-xs-3">
                    <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtECNo" runat="server"></asp:TextBox>
                </div>
                <div class="col-xs-1">
                    <asp:Button CssClass="btn btn-primary btn-sm" ID="btnSearchECNo" runat="server" Text=">>"
                        CausesValidation="False" />
                </div>
                <div class="col-xs-2 control-label">
                    <asp:Label ID="Label22" runat="server"
                        Text="Search by customer name"></asp:Label>
                </div>
                <div class="col-xs-3">
                    <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtSearchName" runat="server"></asp:TextBox>
                </div>
                <div class="col-xs-1">
                    <asp:Button CssClass="btn btn-primary btn-sm" ID="btnSearchName" runat="server"
                        Text=">>" />
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12 center-block">
                    <asp:ListBox ID="lstCust" runat="server" Visible="False" AutoPostBack="true"></asp:ListBox>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-2 control-label">
                    <asp:Label ID="Label2" runat="server"
                        Text="Business books Account Number"></asp:Label>
                </div>
                <div class="col-xs-4">
                    <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtQBAccNo" runat="server"></asp:TextBox>
                </div>
                <div class="col-xs-2">
                    <asp:Button CssClass="btn btn-primary btn-sm" ID="btnUpdateCustNo" runat="server" Text="Update" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>