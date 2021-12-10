<%@ Page Title="Banks" Language="VB" MasterPageFile="~/Site2.master" AutoEventWireup="false" CodeFile="Banks.aspx.vb" Inherits="Admin_Banks" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="panel panel-primary small">
        <div class="panel-heading">
            <h4 class="panel-title">
                <a>Bank Details</a>
            </h4>
        </div>
        <div class="panel-body">
            <div class="row">
                <div class="col-xs-2 control-label">
                    Bank Code
                </div>
                <div class="col-xs-4">
                    <asp:TextBox ID="txtBankCode" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtBankCode"
                        ErrorMessage="Bank Code?"></asp:RequiredFieldValidator>
                </div>
                <div class="col-xs-2 control-label">
                    Bank Name
                </div>
                <div class="col-xs-4">
                    <asp:TextBox ID="txtBankName" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtBankName"
                        ErrorMessage="Bank ?"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12 text-center">
                    <asp:Button ID="btnSave" runat="server" UseSubmitBehavior="false" Text="Save" CssClass="btn btn-primary btn-sm btn-save" />
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12 text-center">
                    <asp:GridView ID="grdBank" runat="server" AllowPaging="True" HorizontalAlign="Center">
                        <PagerSettings FirstPageText="First" NextPageText="Next" PreviousPageText="Previous" />
                        <AlternatingRowStyle CssClass="altrowstyle" />
                        <HeaderStyle CssClass="headerstyle" HorizontalAlign="center" />
                        <RowStyle CssClass="rowstyle" />
                        <PagerStyle CssClass="pagination-ys" />
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
</asp:Content>