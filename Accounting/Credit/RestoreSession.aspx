<%@ Page Title="Session Restore" Language="VB" MasterPageFile="~/Site2.master" AutoEventWireup="false" CodeFile="RestoreSession.aspx.vb" Inherits="QuestCredit_RestoreSession" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="panel panel-primary small">
        <div class="panel-heading">
            <h4 class="panel-title">
                <a>Saved Sessions
                    <asp:Label ID="lblAppCount" runat="server" Text="0" CssClass="badge"></asp:Label></a>
            </h4>
        </div>
        <div class="panel-body">
            <div class="row hidden">
                <div class="col-xs-2 control-label">
                    <asp:Label ID="Label21" runat="server" Text="Search Name"></asp:Label>
                </div>
                <div class="col-xs-4">
                    <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtSearchName" runat="server"></asp:TextBox>
                </div>
                <div class="col-xs-3">
                    <asp:Button CssClass="btn btn-primary btn-sm" ID="btnSearchRange" runat="server" Text=">>" />
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12 center-block">
                    <asp:GridView ID="grdSessions" runat="server" AllowPaging="True"
                        HorizontalAlign="Center" CssClass="table table-bordered table-striped tablestyle success"
                        EmptyDataText="You have no saved sessions!" EmptyDataRowStyle-CssClass="text-warning text-center">
                        <AlternatingRowStyle CssClass="altrowstyle" />
                        <%--<HeaderStyle CssClass="headerstyle" HorizontalAlign="center" />--%>
                        <HeaderStyle CssClass="header info" />
                        <RowStyle CssClass="rowstyle" />
                        <PagerStyle CssClass="pagination-ys" />
                        <Columns>
                            <asp:TemplateField ShowHeader="False">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False"
                                        CommandName="Select" Text="Resume Session" CommandArgument='<%# Eval("ID") %>'></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
</asp:Content>