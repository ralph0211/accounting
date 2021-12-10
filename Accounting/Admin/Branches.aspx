<%@ Page Title="Bank Branches" Language="VB" MasterPageFile="~/Site2.master" AutoEventWireup="false" CodeFile="Branches.aspx.vb" Inherits="Admin_Branches" %>

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
                    <asp:Label ID="Label4" runat="server" Text="Bank"></asp:Label>
                </div>
                <div class="col-xs-4">
                    <asp:DropDownList ID="cmbBankUpdate" runat="server" AutoPostBack="True" CssClass="form-control input-sm">
                    </asp:DropDownList>
                </div>
            </div>
            <div class="row hidden">
                <div class="col-xs-2 control-label">
                    <asp:Label ID="Label7" runat="server" Text="Branch Code"></asp:Label>
                </div>
                <div class="col-xs-4">
                    <asp:DropDownList ID="cmbBranchCodeUpdate" runat="server" AutoPostBack="True" CssClass="form-control input-sm">
                    </asp:DropDownList>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-2 control-label">
                    <asp:Label ID="Label5" runat="server"
                        Text="Branch Code"></asp:Label>
                </div>
                <div class="col-xs-4">
                    <asp:TextBox ID="txtBankCodeUpdate" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-2 control-label">
                    <asp:Label ID="Label6" runat="server"
                        Text="Branch Name"></asp:Label>
                </div>
                <div class="col-xs-4">
                    <asp:TextBox ID="txtBankNameUpdate" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12 text-center">
                    <asp:Button ID="btnSave" runat="server" CausesValidation="False" CssClass="btn btn-primary btn-sm"
                        Text="Save" />
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12">
                    <asp:GridView ID="grdBank" runat="server" HorizontalAlign="Center" AutoGenerateColumns="False">
                        <PagerSettings FirstPageText="First" NextPageText="Next" PreviousPageText="Previous" />
                        <AlternatingRowStyle CssClass="altrowstyle" />
                        <Columns>
                            <asp:TemplateField ShowHeader="False">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton5" runat="server" CausesValidation="False" CommandName="Delete" Text="Delete" OnClientClick="return isDelete();"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField ShowHeader="False">
                                <EditItemTemplate>
                                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" CommandName="Update" Text="Update"></asp:LinkButton>
                                    &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel"></asp:LinkButton>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit" Text="Edit"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Branch Code">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtGrdBranchCode" runat="server" Text='<%# Bind("branch") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("branch") %>'></asp:Label>
                                    <asp:TextBox ID="txtGrdID" runat="server" Text='<%# Bind("id") %>' Visible="false"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Branch Name">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtGrdBranchName" runat="server" Text='<%# Bind("branch_name") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("branch_name") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <HeaderStyle CssClass="headerstyle" HorizontalAlign="center" />
                        <RowStyle CssClass="rowstyle" />
                        <PagerStyle CssClass="pagination-ys" />
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
</asp:Content>