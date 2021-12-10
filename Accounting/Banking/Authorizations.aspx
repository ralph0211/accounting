<%@ Page Title="Authorizations" Language="VB" MasterPageFile="~/Site2.master" AutoEventWireup="false" CodeFile="Authorizations.aspx.vb" Inherits="Banking_Authorizations" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="panel panel-primary small">
        <div class="panel-heading">
            <h4 class="panel-title">Vault Operations
            </h4>
        </div>
        <div class="panel-body">
            <div class="row">
                <div class="col-xs-12 center-block">
                    <asp:GridView ID="grdVaultAuthorization" runat="server" HorizontalAlign="Center">
                        <AlternatingRowStyle CssClass="altrowstyle" />
                        <HeaderStyle CssClass="headerstyle" HorizontalAlign="center" />
                        <RowStyle CssClass="rowstyle" />
                        <PagerStyle CssClass="pagination-ys" />
                        <SelectedRowStyle Font-Bold="true" BackColor="#A8B1B9" />
                        <Columns>
                            <asp:TemplateField HeaderText="Authorize">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkBtnAuthorizeVault" runat="server"
                                        CommandArgument='<%#Eval("ID")%>' CommandName="Authorize">Authorize</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Discard">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkBtnDiscardVault" runat="server"
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