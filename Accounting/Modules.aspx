<%@ Page Language="VB" MasterPageFile="~/Site2.master" AutoEventWireup="false" CodeFile="Modules.aspx.vb" Inherits="Modules" Title="Modules" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="panel panel-primary small">
        <div class="panel-heading">
            <h4 class="panel-title">Add/Edit Modules
            </h4>
        </div>
        <div class="panel-body">
            <div class="row">
                <div class="col-xs-2 control-label">
                    Module Category
                    <asp:Label ID="Label3" runat="server" Text="*" ForeColor="Red" Font-Size="Large"></asp:Label>
                </div>
                <div class="col-xs-6">
                    <asp:DropDownList CssClass="col-xs-12 form-control input-sm" ID="cmbModuleCategory" runat="server"
                        AppendDataBoundItems="True">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator Display="Dynamic" ID="rfvBrCode" runat="server" ErrorMessage="Module Category is required" ValidationGroup="valBr" ControlToValidate="cmbModuleCategory"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-2 control-label">
                    Module Name
                    <asp:Label ID="Label1" runat="server" Text="*" ForeColor="Red" Font-Size="Large"></asp:Label>
                </div>
                <div class="col-xs-6">
                    <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtModuleName" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator1" runat="server" ErrorMessage="Module Name is required" ValidationGroup="valBr" ControlToValidate="txtModuleName"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-2 control-label">
                    URL
                    <asp:Label ID="Label2" runat="server" Text="*" ForeColor="Red" Font-Size="Large"></asp:Label>
                </div>
                <div class="col-xs-6">
                    <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtURL" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator2" runat="server" ErrorMessage="URL is required" ValidationGroup="valBr" ControlToValidate="txtURL"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12 text-center">
                    <asp:Button CssClass="btn btn-primary btn-sm" ID="btnSaveModule" runat="server" Text="Save" UseSubmitBehavior="false" ValidationGroup="valBr" />
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12 control-label label-info">
                    Modules
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12 center-block">
                    <asp:GridView ID="grdModules" runat="server" AutoGenerateColumns="False"
                        BorderStyle="None" BorderWidth="1px" CellPadding="3"
                        HorizontalAlign="Center" s="">
                        <PagerSettings FirstPageText="First" NextPageText="Next"
                            PreviousPageText="Previous" />
                        <AlternatingRowStyle CssClass="altrowstyle" />
                        <HeaderStyle CssClass="headerstyle" HorizontalAlign="center" />
                        <RowStyle CssClass="rowstyle" />
                        <PagerStyle CssClass="pagination-ys" />
                        <Columns>
                            <asp:TemplateField ShowHeader="False">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkBtnDel" runat="server" CausesValidation="False"
                                        CommandName="Delete" OnClientClick="return isDelete();" Text="Delete"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField ShowHeader="False">
                                <EditItemTemplate>
                                    <asp:LinkButton ID="lnkBtnUpd" runat="server" CausesValidation="False"
                                        CommandName="Update" Text="Update"></asp:LinkButton>
                                    <asp:LinkButton ID="lnkBtnCan" runat="server" CausesValidation="False"
                                        CommandName="Cancel" Text="Cancel"></asp:LinkButton>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkBtnEdt" runat="server" CausesValidation="False"
                                        CommandName="Edit" Text="Edit"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Module ID">
                                <ItemTemplate>
                                    <asp:Label ID="lblModuleId0" runat="server" Text='<%#Eval("ModuleId")%>'></asp:Label>
                                    <asp:TextBox ID="txtModuleId0" runat="server" Text='<%#Eval("ModuleId")%>'
                                        Visible="False"></asp:TextBox>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:Label ID="lblModuleId0Edit" runat="server" Text='<%#Eval("ModuleId")%>'></asp:Label>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Module Category">
                                <ItemTemplate>
                                    <asp:Label ID="lblModuleCategory0" runat="server" Text='<%#Eval("CATEGORY")%>'></asp:Label>
                                    <asp:TextBox ID="txtModuleCategory0" runat="server" Text='<%#Eval("MODULE_CATEGORY")%>'
                                        Visible="False"></asp:TextBox>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtModuleCategory0Edit" runat="server"
                                        Text='<%#Eval("MODULE_CATEGORY")%>' Visible="False"></asp:TextBox>
                                    <asp:DropDownList ID="cmbModuleCategoryEdit" runat="server"
                                        AppendDataBoundItems="True">
                                    </asp:DropDownList>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Module Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblModuleName0" runat="server" Text='<%#Eval("ModuleName")%>'></asp:Label>
                                    <asp:TextBox ID="txtModuleName0" runat="server" Text='<%#Eval("ModuleName")%>'
                                        Visible="False"></asp:TextBox>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtModuleName0Edit" runat="server"
                                        Text='<%#Eval("ModuleName")%>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="URL Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblURLName0" runat="server" Text='<%#Eval("URL_NAME")%>'></asp:Label>
                                    <asp:TextBox ID="txtURLName0" runat="server" Text='<%#Eval("URL_NAME")%>'
                                        Visible="False"></asp:TextBox>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtURLName0Edit" runat="server" Text='<%#Eval("URL_NAME")%>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        $(function () {
            $("[id*=btnSaveModule]").bind("click", function () {
                $("[id*=btnSaveModule]").val("Saving...");
                $("[id*=btnSaveModule]").attr("disabled", true);
            });
        });
    </script>
</asp:Content>