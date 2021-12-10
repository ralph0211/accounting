<%@ Page Title="Stop Transaction Posting" Language="VB" MasterPageFile="~/Site2.master" AutoEventWireup="false" CodeFile="AccCloseDate.aspx.vb" Inherits="Accounting_AccCloseDate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="panel panel-primary small">
        <div class="panel-heading">
            <h4 class="panel-title">Transaction Cut Off
            </h4>
        </div>
        <div class="panel-body">
            <div class="row">
                <div class="col-xs-12 text-center">
                    <asp:RadioButtonList ID="rdbType" runat="server" RepeatDirection="horizontal">
                        <asp:ListItem Text="Cash Account" Value="Cash"></asp:ListItem>
                        <asp:ListItem Text="Other Accounts" Value="Other"></asp:ListItem>
                    </asp:RadioButtonList>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-3 control-label">
                    <asp:Label ID="Label1220" runat="server" Text="Accounts balanced upto"></asp:Label>
                </div>
                <div class="col-xs-4">
                    <asp:TextBox ID="bdpCutDate" runat="server" CssClass="col-xs-12 form-control input-sm nofuturedate"></asp:TextBox>
                    <span class="glyphicon glyphicon-calendar form-control-feedback" style="margin-right: 13px; background-color: #eeeeff; border-radius: 0 3px 3px 0; border: 1px solid rgb(149,188,219); z-index: 0;"></span>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12 text-center">
                    <asp:Button CssClass="btn btn-primary btn-sm" ID="btnSave" runat="server" Text="Save" UseSubmitBehavior="false" />
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12 center-block">
                    <asp:GridView ID="grdDates" runat="server" HorizontalAlign="center">
                        <AlternatingRowStyle CssClass="altrowstyle" />
                        <HeaderStyle CssClass="headerstyle" HorizontalAlign="center" />
                        <RowStyle CssClass="rowstyle" />
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
</asp:Content>