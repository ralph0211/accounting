<%@ Page Title="Balance Sheet Order" Language="VB" MasterPageFile="~/Site2.master" AutoEventWireup="false" CodeFile="OrderStatementItems.aspx.vb" Inherits="Accounting_OrderStatementItems" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .selected {
            background-color: #b3dff8;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="panel panel-primary small">
        <div class="panel-heading">
            <h4 class="panel-title">
                <a>Balance Sheet Ordering</a>
            </h4>
        </div>
        <div class="panel-body">
            <div class="row hidden">
                <div class="col-xs-2 control-label">
                    Statement
                </div>
                <div class="col-xs-4">
                    <asp:DropDownList ID="cmbStatement" runat="server" AutoPostBack="True" CssClass="col-xs-12 form-control input-sm">
                    </asp:DropDownList>
                </div>
            </div>
            <div class="row hidden">
                <div class="col-xs-2 control-label">
                    <asp:Label ID="Labelllll1" runat="server" Text="Module Category"></asp:Label>
                </div>
                <div class="col-xs-4">
                    <asp:DropDownList ID="cmbModuleCategory" runat="server" AppendDataBoundItems="True" AutoPostBack="True" CssClass="col-xs-12 form-control input-sm">
                    </asp:DropDownList>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12 label-info control-label">
                    <asp:Label ID="Label29" runat="server" Font-Bold="True" Text="Drag and drop the statement items into the desired order and save"></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12 center-block">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <asp:GridView ID="grdItems" runat="server" AutoGenerateColumns="False" EmptyDataText="No items for this statement" HorizontalAlign="center">
                                <PagerSettings FirstPageText="First" NextPageText="Next" PreviousPageText="Previous" />
                                <AlternatingRowStyle CssClass="altrowstyle" />
                                <HeaderStyle CssClass="headerstyle" HorizontalAlign="center" />
                                <RowStyle CssClass="rowstyle" />
                                <Columns>
                                    <asp:TemplateField HeaderText="Category">
                                        <ItemTemplate>
                                            <asp:Label ID="lblModuleId" runat="server" Text='<%#Eval("Category")%>'></asp:Label>
                                            <input name="lblPermissionId" type="hidden" value='<%# Eval("ID") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Sub Category">
                                        <ItemTemplate>
                                            <asp:Label ID="lblModuleName" runat="server" Text='<%#Eval("SubType")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Item">
                                        <ItemTemplate>
                                            <asp:Label ID="lblURLName" runat="server" Text='<%#Eval("Description")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12 text-center">
                    <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary btn-sm" OnClick="UpdatePreference" Text="Save" />
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        $(function () {
            $("[id*=grdItems]").sortable({
                items: 'tr:not(tr:first-child)',
                cursor: 'hand',
                axis: 'y',
                dropOnEmpty: false,
                start: function (e, ui) {
                    ui.item.addClass("selected");
                },
                stop: function (e, ui) {
                    ui.item.removeClass("selected");
                },
                receive: function (e, ui) {
                    $(this).find("tbody").append(ui.item);
                }
            });
        });
    </script>
</asp:Content>