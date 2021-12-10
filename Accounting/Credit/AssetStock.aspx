<%@ Page Title="Asset Stock" Language="VB" MasterPageFile="~/Site2.master" AutoEventWireup="false" CodeFile="AssetStock.aspx.vb" Inherits="Credit_AssetStock" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="panel panel-primary small">
        <div class="panel-heading">
            <h4 class="panel-title">
                <a>Asset Stock</a>
            </h4>
        </div>
        <div class="panel-body">
            <div class="row">
                <div class="col-xs-2 control-label">
                    Transaction Type
                </div>
                <div class="col-xs-4">
                    <asp:RadioButtonList ID="rdbTrxnType" runat="server" RepeatDirection="horizontal" CssClass="col-xs-12">
                        <asp:ListItem Text="Assets Stocking" Value="Received"></asp:ListItem>
                        <asp:ListItem Text="Assets Removed" Value="Withdraw"></asp:ListItem>
                    </asp:RadioButtonList>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-2 control-label">
                    <asp:Label ID="Label1" runat="server"
                        Text="Asset Name"></asp:Label>
                </div>
                <div class="col-xs-4">
                    <asp:DropDownList CssClass="col-xs-12 form-control input-sm" ID="cmbAsset" runat="server"></asp:DropDownList>
                </div>
                <div class="col-xs-2 control-label">
                    Date
                </div>
                <div class="col-xs-4">
                    <asp:TextBox ID="txtTrxnDate" runat="server" CssClass="col-xs-12 form-control input-sm nofuturedate"></asp:TextBox>
                    <span class="glyphicon glyphicon-calendar form-control-feedback" style="margin-right: 13px; background-color: #eeeeff; border-radius: 0 3px 3px 0; border: 1px solid rgb(149,188,219); z-index: 0;"></span>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-2 control-label">
                    <asp:Label ID="Label2" runat="server"
                        Text="Quantity (units)"></asp:Label>
                </div>
                <div class="col-xs-4">
                    <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtQuantity" runat="server"></asp:TextBox>
                </div>
                <div class="col-xs-2 control-label">
                    Description
                </div>
                <div class="col-xs-4">
                    <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtDesc" runat="server" TextMode="multiline"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12 text-center">
                    <asp:Button CssClass="btn btn-primary btn-sm" ID="btnSave" runat="server" Text="Save" />
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12">
                    <asp:GridView ID="grdStock" runat="server" HorizontalAlign="Center">
                        <AlternatingRowStyle CssClass="altrowstyle" />
                        <HeaderStyle CssClass="headerstyle" HorizontalAlign="center" />
                        <RowStyle CssClass="rowstyle" />
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
</asp:Content>