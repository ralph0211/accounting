<%@ Page Title="Blacklisting Authorization" Language="VB" MasterPageFile="~/Site2.master" AutoEventWireup="false" CodeFile="BlacklistAuth.aspx.vb" Inherits="QuestCredit_BlackListAuth" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="panel panel-primary small">
        <div class="panel-heading">
            <h4 class="panel-title">Authorize Client Blacklisting
            </h4>
        </div>
        <div class="panel-body">
            <div class="row">
                <div class="col-xs-2 control-label">
                    <asp:Label ID="Label1" runat="server" Text="Search User" Visible="False"></asp:Label>
                </div>
                <div class="col-xs-4">
                    <asp:TextBox ID="txtSearchUser" runat="server" Visible="False"></asp:TextBox>
                </div>
                <div class="col-xs-1">
                    <asp:Button ID="btnSearchUser" runat="server" Text=">>" Visible="False" />
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12 center">
                    <asp:GridView ID="grdBlacklist" runat="server" AllowPaging="True"
                        AutoGenerateColumns="False" CellPadding="3"
                        HorizontalAlign="Center" Caption="Blacklisted Clients"
                        EmptyDataText="No Blacklisted Clients">
                        <AlternatingRowStyle CssClass="altrowstyle" />
                        <HeaderStyle CssClass="headerstyle" HorizontalAlign="center" />
                        <RowStyle CssClass="rowstyle" />
                        <Columns>
                            <asp:TemplateField ShowHeader="False">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False"
                                        CommandName="Authorize" Text="Authorize" CommandArgument='<%#Eval("id")%>'></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField ShowHeader="False">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False"
                                        CommandName="Discard" Text="Discard" CommandArgument='<%#Eval("id")%>'></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="CustNo" HeaderText="Customer Number" />
                            <asp:BoundField DataField="Surname" HeaderText="Surname" />
                            <asp:BoundField DataField="Forenames" HeaderText="Forenames" />
                            <asp:BoundField DataField="BlacklistedBy" HeaderText="Blacklisted By" />
                            <asp:BoundField DataField="BlacklistReason" HeaderText="Reason" />
                            <asp:BoundField DataField="BlacklistDate1" HeaderText="Date Blacklisted" />
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
</asp:Content>