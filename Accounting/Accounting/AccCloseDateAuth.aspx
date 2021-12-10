<%@ Page Title="Stop Transaction Posting" Language="VB" MasterPageFile="~/Site2.master" AutoEventWireup="false" CodeFile="AccCloseDateAuth.aspx.vb" Inherits="Accounting_AccCloseDateAuth" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="panel panel-primary small">
        <div class="panel-heading">
            <h4 class="panel-title">Cut-Off Dates Authorisation
            </h4>
        </div>
        <div class="panel-body">
            <div class="row">
                <div class="col-xs-12 center-block">
                    <asp:GridView ID="grdDate" Caption="Accounts Cut Off" runat="server" HorizontalAlign="Center" EmptyDataText="No authorisation pending">
                        <Columns>
                            <asp:TemplateField ShowHeader="False">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="false" CommandName="Authorise" CommandArgument='<%# Eval("ID")%>' Text="Authorise"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField ShowHeader="False">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="false" CommandName="Discard" CommandArgument='<%# Eval("ID")%>' Text="Discard"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <AlternatingRowStyle CssClass="altrowstyle" />
                        <HeaderStyle CssClass="headerstyle" HorizontalAlign="center" />
                        <RowStyle CssClass="rowstyle" />
                    </asp:GridView>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12 center-block">
                    <asp:GridView ID="grdCash" Caption="Cash Account Cut Off" runat="server" HorizontalAlign="Center" EmptyDataText="No authorisation pending">
                        <Columns>
                            <asp:TemplateField ShowHeader="False">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="false" CommandName="Authorise" CommandArgument='<%# Eval("ID")%>' Text="Authorise"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField ShowHeader="False">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="false" CommandName="Discard" CommandArgument='<%# Eval("ID")%>' Text="Discard"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <AlternatingRowStyle CssClass="altrowstyle" />
                        <HeaderStyle CssClass="headerstyle" HorizontalAlign="center" />
                        <RowStyle CssClass="rowstyle" />
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
</asp:Content>