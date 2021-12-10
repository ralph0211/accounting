<%@ Page Language="VB" MasterPageFile="~/Site2.master" AutoEventWireup="false" CodeFile="UserActivityReports.aspx.vb" Inherits="UserActivityReports" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="panel panel-primary small">
        <div class="panel-heading">
            <h4 class="panel-title">
                <a data-parent="#collapse" data-toggle="collapse" href="#collapse-one">User Activity Reports
                </a>
            </h4>
        </div>
        <div class="panel-body">
            <div class="row">
                <div class="col-xs-2 control-label">
                    <asp:Label ID="Label1" runat="server"
                        Text="Activity Type"></asp:Label>
                </div>
                <div class="col-xs-4">
                    <asp:RadioButtonList ID="rdbActivityType" runat="server"
                        RepeatDirection="Horizontal" CssClass="col-xs-12">
                        <asp:ListItem Text="Logins" Value="Logins"></asp:ListItem>
                        <asp:ListItem Text="Page Views" Value="Page Views"></asp:ListItem>
                        <asp:ListItem Text="Actions" Value="Actions"></asp:ListItem>
                    </asp:RadioButtonList>
                </div>
                <div class="col-xs-1">
                    <asp:Button ID="btnView" runat="server" CssClass="btn btn-primary btn-sm"
                        Text="View" UseSubmitBehavior="false" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>