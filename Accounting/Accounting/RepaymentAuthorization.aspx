<%@ Page Title="Authorise Repayment Transaction" Language="VB" MasterPageFile="~/Site2.master" AutoEventWireup="false" CodeFile="RepaymentAuthorization.aspx.vb" Inherits="Accounting_RepaymentAuthorization" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="panel panel-primary small">
        <div class="panel-heading">
            <h4 class="panel-title">
                <a>Repayment Authorisation</a>
            </h4>
        </div>
        <div class="panel-body">
            <div class="row">
                <div class="col-xs-2 control-label">
                    <asp:Label ID="Label1225" runat="server" Text="Batch Number"></asp:Label>
                </div>
                <div class="col-xs-4">
                    <asp:DropDownList ID="cmbBatchNo" runat="server" AutoPostBack="True" CssClass="col-xs-12 form-control input-sm chosen">
                    </asp:DropDownList>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12 center-block">
                    <asp:GridView ID="grdDetails" runat="server" HorizontalAlign="center">
                        <AlternatingRowStyle CssClass="altrowstyle" />
                        <HeaderStyle CssClass="headerstyle" HorizontalAlign="center" />
                        <RowStyle CssClass="rowstyle" />
                        <PagerStyle CssClass="pagination-ys" />
                        <SelectedRowStyle BackColor="#A8B1B9" Font-Bold="true" />
                        <Columns>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12 text-center">
                    <asp:Button ID="btnAuthorize" runat="server" CssClass="btn btn-primary btn-sm" Text="Authorise" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>