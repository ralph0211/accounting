<%@ Page Title="General Ledger" Language="VB" MasterPageFile="~/Site2.master" AutoEventWireup="false" CodeFile="GeneralLedger.aspx.vb" Inherits="Accounting_GeneralLedger" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="panel panel-primary small">
        <div class="panel-heading">
            <h4 class="panel-title">
                <a>General Ledger</a>
            </h4>
        </div>
        <div class="panel-body">
            <div class="row">
                <div class="col-xs-2 control-label">
                    <asp:Label ID="Label1" runat="server" Font-Bold="True" Text="From"></asp:Label>
                </div>
                <div class="col-xs-4">
                    <asp:TextBox ID="txtFromDate" runat="server" CssClass="col-xs-12 form-control input-sm nofuturedate"></asp:TextBox>
                    <span class="glyphicon glyphicon-calendar form-control-feedback" style="margin-right: 13px; background-color: #eeeeff; border-radius: 0 3px 3px 0; border: 1px solid rgb(149,188,219); z-index: 0;"></span>
                </div>
                <div class="col-xs-2 control-label">
                    <asp:Label ID="Labehl1" runat="server" Font-Bold="True" Text="To"></asp:Label>
                </div>
                <div class="col-xs-4">
                    <asp:TextBox ID="txtToDate" runat="server" CssClass="col-xs-12 form-control input-sm datepicker"></asp:TextBox>
                    <span class="glyphicon glyphicon-calendar form-control-feedback" style="margin-right: 13px; background-color: #eeeeff; border-radius: 0 3px 3px 0; border: 1px solid rgb(149,188,219); z-index: 0;"></span>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-2 control-label">
                    Account
                </div>
                <div class="col-xs-4">
                    <asp:DropDownList ID="cmbAccount" runat="server" CssClass="col-xs-12 form-control input-sm chosen"></asp:DropDownList>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12 text-center">
                    <asp:Button CssClass="btn btn-primary btn-sm" ID="btnPrint" runat="server" Text="Print View" />
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12 center-block">
                    <asp:GridView ID="grd" runat="server" CellPadding="4" EnableModelValidation="True" Font-Names="Verdana" Font-Size="10pt" ForeColor="#333333" GridLines="None" Width="844px">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <EditRowStyle BackColor="#999999" />
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#023E5A" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
</asp:Content>