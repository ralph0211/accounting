<%@ Page Title="Update Disbursement Method" Language="VB" MasterPageFile="~/Site2.master" AutoEventWireup="false" CodeFile="frmUdateDisbursementMethod.aspx.vb" Inherits="Credit_frmUdateDisbursementMethod" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="panel panel-primary small">
        <div class="panel-heading">
            <h4 class="panel-title">
                <a>Update Disbursement Method</a>
            </h4>
        </div>
        <div class="panel-body">
            <div class="row">
                <div class="col-xs-3 control-label">
                    <asp:Label ID="Label1" runat="server" Text="Search Customer"></asp:Label>
                </div>
                <div class="col-xs-3">
                    <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtSearch" runat="server"></asp:TextBox>
                </div>
                <div class="col-xs-1">
                    <asp:Button CssClass="btn btn-primary btn-sm" ID="btnSearch" runat="server" Text=">>"
                        CausesValidation="False" />
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12 center-block">
                    <asp:ListBox ID="lstCust" runat="server" Visible="False" AutoPostBack="true"></asp:ListBox>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-3 control-label">
                    <asp:Label ID="Label4" runat="server"
                        Text="Customer No"></asp:Label>
                </div>
                <div class="col-xs-3">
                    <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtcustomerNo" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-3 control-label">
                    <asp:Label ID="Label5" runat="server"
                        Text="Customer Name"></asp:Label>
                </div>
                <div class="col-xs-3">
                    <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtName" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-3 control-label">
                    <asp:Label ID="Label6" runat="server"
                        Text="Disbursement Method"></asp:Label>
                </div>
                <div class="col-xs-3">
                    <asp:DropDownList CssClass="col-xs-12 form-control input-sm" ID="cmbDisMethod" runat="server">
                        <asp:ListItem>Ecocash</asp:ListItem>
                        <asp:ListItem>Cash</asp:ListItem>
                        <asp:ListItem>RTGS</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12 text-center">
                    <asp:Button CssClass="btn btn-primary btn-sm" ID="btnUpdateCustNo" runat="server" Text="Update" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>