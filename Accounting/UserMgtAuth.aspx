<%@ Page Language="VB" MasterPageFile="~/Site2.master" AutoEventWireup="false" CodeFile="UserMgtAuth.aspx.vb" Inherits="UserMgtAuth" Title="User and Role Authorization" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="panel panel-primary small">
        <div class="panel-heading">
            <h4 class="panel-title">User / Role Authorization
            </h4>
        </div>
        <div class="panel-body">
            <div class="row">
                <div class="col-xs-12 control-label label-info">
                    <asp:Label ID="Label1" runat="server" Text="Users Authorization"></asp:Label>
                </div>
            </div>
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
                    <asp:Panel ID="Panel1" runat="server" ScrollBars="Auto">
                        <asp:GridView ID="grdAuthUsers" runat="server" 
                        HorizontalAlign="Center" CssClass="table table-bordered table-striped tablestyle success"
                        EmptyDataText="No authorizations ready for processing!" EmptyDataRowStyle-CssClass="text-warning text-center">
                        <AlternatingRowStyle CssClass="altrowstyle" />
                        <EmptyDataRowStyle CssClass="text-warning text-center"></EmptyDataRowStyle>
                        <HeaderStyle CssClass="header info" />
                        <RowStyle CssClass="rowstyle" />
                        <PagerStyle CssClass="pagination-ys" />
                            <Columns>
                                <asp:TemplateField HeaderText="Authorize">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkBtnAuthorizeUser" runat="server"
                                            CommandArgument='<%#Eval("ID")%>' CommandName="Authorize">Authorize</asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Discard">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkBtnDiscardUser" runat="server"
                                            CommandArgument='<%#Eval("ID")%>' CommandName="Discard"
                                            OnClientClick="return isDelete();">Discard</asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </asp:Panel>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12 control-label label-info">
                    <asp:Label ID="Label125" runat="server" Text="Roles Authorization"></asp:Label>
                </div>
            </div>
            <div class="row hidden">
                <div class="col-xs-1 control-label">
                    <asp:Label ID="Label4000" runat="server"
                        Text="Action"></asp:Label>
                </div>
                <div class="col-xs-3">
                    <asp:DropDownList CssClass="col-xs-12 form-control input-sm" ID="cmbAuthRolesAction" runat="server" AutoPostBack="True">
                        <asp:ListItem Text="All" Value="1"></asp:ListItem>
                        <asp:ListItem Text="Insert" Value="2"></asp:ListItem>
                        <asp:ListItem Text="Update" Value="3"></asp:ListItem>
                        <asp:ListItem Text="Delete" Value="4"></asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12 center-block">
                    <asp:Panel ID="Panel2" runat="server" Direction="LeftToRight" ScrollBars="Auto">
                        <asp:GridView ID="grdAuthRoles" runat="server" 
                        HorizontalAlign="Center" CssClass="table table-bordered table-striped tablestyle success"
                        EmptyDataText="No authorizations ready for processing!" EmptyDataRowStyle-CssClass="text-warning text-center">
                        <AlternatingRowStyle CssClass="altrowstyle" />
                        <EmptyDataRowStyle CssClass="text-warning text-center"></EmptyDataRowStyle>
                        <HeaderStyle CssClass="header info" />
                        <RowStyle CssClass="rowstyle" />
                        <PagerStyle CssClass="pagination-ys" />
                            <Columns>
                                <asp:TemplateField HeaderText="Authorize">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkBtnAuthorizeRole" runat="server"
                                            CommandArgument='<%#Eval("ID")%>' CommandName="AuthorizeRole">Authorize</asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Discard">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkBtnDiscardRole" runat="server"
                                            CommandArgument='<%#Eval("ID")%>' CommandName="DiscardRole"
                                            OnClientClick="return isDelete();">Discard</asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </asp:Panel>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12 text-center">
                    <asp:Button Visible="false" CssClass="btn btn-primary btn-sm" ID="Btn_CM_Save" runat="server" Text="Save" UseSubmitBehavior="false" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>