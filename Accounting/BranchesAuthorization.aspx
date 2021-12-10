<%@ Page Title="Authorize Branches" Language="VB" MasterPageFile="~/Site2.master" AutoEventWireup="false" CodeFile="BranchesAuthorization.aspx.vb" Inherits="BranchesAuthorization" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="panel panel-primary small">
        <div class="panel-heading">
            <h4 class="panel-title">Branch Authorization
            </h4>
        </div>
        <div class="panel-body">
            <div class="row hidden">
                <div class="col-xs-1 control-label">
                    <asp:Label ID="Label40" runat="server"
                        Text="Action"></asp:Label>
                </div>
                <div class="col-xs-3">
                    <asp:DropDownList CssClass="col-xs-12 form-control input-sm" ID="cmbAuthUsersAction" runat="server" AutoPostBack="True">
                        <asp:ListItem Text="All" Value="1"></asp:ListItem>
                        <asp:ListItem Text="Insert" Value="2"></asp:ListItem>
                        <asp:ListItem Text="Update" Value="3"></asp:ListItem>
                        <asp:ListItem Text="Delete" Value="4"></asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12 center-block">
                    <asp:GridView ID="grdAuthBranch" runat="server"
                        HorizontalAlign="Center" CssClass="table table-bordered table-striped tablestyle success"
                        EmptyDataText="No branches ready for authorization!" EmptyDataRowStyle-CssClass="text-danger text-center">
                        <AlternatingRowStyle CssClass="altrowstyle" />
                        <HeaderStyle CssClass="header info" />
                        <RowStyle CssClass="rowstyle" />
                        <PagerStyle CssClass="pagination-ys" />
                        <Columns>
                            <asp:TemplateField HeaderText="Authorize">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkBtnAuthorize" runat="server"
                                        CommandArgument='<%#Eval("ID")%>' CommandName="Authorize">Authorize</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Discard">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkBtnDiscard" runat="server"
                                        CommandArgument='<%#Eval("ID")%>' CommandName="Discard"
                                        OnClientClick="return isDelete();">Discard</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
</asp:Content>