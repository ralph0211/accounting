<%@ Page Title="Receipts By Day" Language="VB" MasterPageFile="~/Site2.master" AutoEventWireup="false" CodeFile="DailyReceipts.aspx.vb" Inherits="Accounting_DailyReceipts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="panel panel-primary small">
        <div class="panel-heading">
            <h4 class="panel-title">
                <a>Receipts By Day</a>
            </h4>
        </div>
        <div class="panel-body">
            <div class="row">
                <div class="col-xs-2 control-label">
                    <asp:Label ID="Label1" runat="server" Text="Date"></asp:Label>
                </div>
                <div class="col-xs-3">
                    <asp:TextBox ID="bdpDate" runat="server" CssClass="form-control input-sm nofuturedate"></asp:TextBox>
                    <span class="glyphicon glyphicon-calendar form-control-feedback" style="margin-right: 13px; background-color: #eeeeff; border-radius: 0 3px 3px 0; border: 1px solid rgb(149,188,219); z-index: 0;"></span>
                </div>
                <div class="col-xs-1">
                    <asp:Button CssClass="btn btn-primary btn-sm" ID="btnSearchDate" runat="server" Text=">>"
                        CausesValidation="False" />
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12 center-block">
                    <asp:GridView ID="grdReceipts" runat="server" HorizontalAlign="Center">
                        <AlternatingRowStyle CssClass="altrowstyle" />
                        <HeaderStyle CssClass="headerstyle" HorizontalAlign="center" />
                        <RowStyle CssClass="rowstyle" />
                        <PagerStyle CssClass="pagination-ys" />
                        <SelectedRowStyle BackColor="#A8B1B9" Font-Bold="true" />
                    </asp:GridView>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-9"></div>
                <div class="col-xs-3 control-label">
                    <asp:Label ID="Label2" runat="server" Text="Receipts Total: "></asp:Label>
                    <asp:Label ID="lblRecTotal" runat="server" Text=""></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12 text-center">
                    <asp:Button CssClass="btn btn-primary btn-sm" ID="btnCommit" runat="server" Text="Commit Transactions" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>