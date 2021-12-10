<%@ Page Title="Account Number Consolidation" Language="VB" MasterPageFile="~/Site2.master" AutoEventWireup="false" CodeFile="AccNoConsolidation.aspx.vb" Inherits="Credit_AccNoConsolidation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="panel panel-primary small">
        <div class="panel-heading">
            <h4 class="panel-title">Accounts Consolidation
            </h4>
        </div>
        <div class="panel-body">
            <div class="row label-info">
                <div class="col-xs-6 text-center">
                    <asp:Label ID="Label2" runat="server" Text="Account to Maintain(213)"></asp:Label>
                </div>
                <div class="col-xs-6 text-center">
                    <asp:Label ID="Label4" runat="server" Text="Account to Discard"></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-2 control-label">
                    <asp:Label ID="Label1" runat="server" Text="Search customer name"></asp:Label>
                </div>
                <div class="col-xs-3">
                    <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtAccToKeep" runat="server"></asp:TextBox>
                </div>
                <div class="col-xs-1">
                    <asp:Button CssClass="btn btn-primary btn-sm" ID="btnSearchAccToKeep" runat="server" Text=">>"
                        CausesValidation="False" />
                </div>
                <div class="col-xs-2 control-label">
                    <asp:Label ID="Label22" runat="server"
                        Text="Search by customer name"></asp:Label>
                </div>
                <div class="col-xs-3">
                    <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtSearchOldAcc" runat="server"></asp:TextBox>
                </div>
                <div class="col-xs-1">
                    <asp:Button CssClass="btn btn-primary btn-sm" ID="btnSearchOldAcc" runat="server"
                        Text=">>" />
                </div>
            </div>
            <div class="row">
                <div class="col-xs-6 text-center">
                    <asp:ListBox ID="lstAccToKeep" runat="server" Height="450px" Width="450px"></asp:ListBox>
                </div>
                <div class="col-xs-6 text-center">
                    <asp:ListBox ID="lstOldAcc" runat="server" Height="450px" Width="450px"></asp:ListBox>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-2 control-label">
                    <asp:Label ID="lblQBAccNo" runat="server"
                        Text="Business books Account Number" Visible="false"></asp:Label>
                </div>
                <div class="col-xs-4">
                    <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtQBAccNo" runat="server" Visible="false"></asp:TextBox>
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