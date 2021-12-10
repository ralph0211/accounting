<%@ Page Language="VB" MasterPageFile="~/Site2.master" AutoEventWireup="false" CodeFile="SpecialPermissions.aspx.vb" Inherits="SpecialPermissions" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="panel panel-primary small">
        <div class="panel-heading">
            <h4 class="panel-title">
                <a data-parent="#collapse" data-toggle="collapse" href="#collapse-one">Special Permission Management
                </a>
            </h4>
        </div>
        <div class="panel-body">
            <div class="row">
                <div class="col-xs-12 center-block">
                    <asp:Menu ID="menuTabs" DynamicHoverStyle-BackColor="#336699"
                        DynamicHoverStyle-ForeColor="White" StaticMenuItemStyle-CssClass="tab"
                        StaticSelectedStyle-CssClass="selectedTab" Orientation="Horizontal"
                        runat="server" Width="776px"
                        ForeColor="White" Style="top: 4px; left: 2px" BackColor="#336699"
                        DynamicHorizontalOffset="2" Font-Names="Verdana" Font-Size="0.8em"
                        StaticSubMenuIndent="10px" Height="18px">
                        <StaticMenuStyle BackColor="#336699" />
                        <StaticSelectedStyle BackColor="White" BorderColor="#1D72A7"
                            BorderStyle="Dotted" BorderWidth="1px" ForeColor="#FFFFFF"></StaticSelectedStyle>
                        <StaticMenuItemStyle BackColor="#FA9221" HorizontalPadding="5px"
                            VerticalPadding="2px"></StaticMenuItemStyle>
                        <DynamicHoverStyle ForeColor="White" BackColor="#FA9221"></DynamicHoverStyle>
                        <DynamicMenuStyle BackColor="#FA9221" />
                        <DynamicSelectedStyle BackColor="#FA9221" />
                        <DynamicMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
                        <StaticHoverStyle BackColor="#FA9266" ForeColor="White" />
                        <Items>
                            <asp:MenuItem Text="Users" Value="Users" NavigateUrl="~/Users.aspx"></asp:MenuItem>
                            <asp:MenuItem Text="Roles" Value="Roles" NavigateUrl="~/Roles.aspx"></asp:MenuItem>
                            <asp:MenuItem Text="Modules" Value="Modules" NavigateUrl="~/Modules.aspx"></asp:MenuItem>
                            <asp:MenuItem Text="Permissions" Value="Permissions"
                                NavigateUrl="~/Permissions.aspx"></asp:MenuItem>
                            <asp:MenuItem Text="Special Permissions" Value="Special Permissions"
                                NavigateUrl="~/SpecialPermissions.aspx"></asp:MenuItem>
                            <asp:MenuItem Text="Authorization" Value="Authorization"
                                NavigateUrl="~/UserMgtAuth.aspx"></asp:MenuItem>
                            <asp:MenuItem Text="Login Parameters" Value="Login Parameters"
                                NavigateUrl="~/LoginParameters.aspx"></asp:MenuItem>
                            <asp:MenuItem NavigateUrl="~/Admin/UnlockUsers.aspx" Text="Unlock Users" Value="Unlock Users"></asp:MenuItem>
                        </Items>
                    </asp:Menu>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-2 control-label">
                    <asp:Label ID="lblSpecPermUserlabel" runat="server"
                        Text="User"></asp:Label>
                </div>
                <div class="col-xs-4">
                    <asp:DropDownList CssClass="col-xs-12 form-control input-sm" ID="cmbSpecPermUser" runat="server" AutoPostBack="True">
                    </asp:DropDownList>
                </div>
                <div class="col-xs-2 control-label">
                    <asp:Label ID="lblSpecPermUserName" runat="server"></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-2 control-label">
                    <asp:Label ID="lblSpecPermModlabel" runat="server"
                        Text="Module"></asp:Label>
                </div>
                <div class="col-xs-4">
                    <asp:DropDownList CssClass="col-xs-12 form-control input-sm" ID="cmbSpecPermModule" runat="server" AutoPostBack="True">
                    </asp:DropDownList>
                </div>
                <div class="col-xs-2 control-label">
                    <asp:Label ID="lblSpecPermUserRole" runat="server"></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-2 control-label">
                    <asp:Label ID="lblSpecPermStartDate" runat="server"
                        Text="Start Date"></asp:Label>
                </div>
                <div class="col-xs-4">
                    <asp:TextBox CssClass="col-xs-12 form-control input-sm datepicker" ID="bdpStartDate" runat="server"></asp:TextBox>
                    <span class="glyphicon glyphicon-calendar form-control-feedback" style="margin-right: 13px; background-color: #eeeeff; border-radius: 0 3px 3px 0; border: 1px solid rgb(149,188,219); z-index: 0;"></span>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-2 control-label">
                    <asp:Label ID="lblSpecPermEndDate" runat="server"
                        Text="End Date"></asp:Label>
                </div>
                <div class="col-xs-4">
                    <asp:TextBox CssClass="col-xs-12 form-control input-sm datepicker" ID="bdpEndDate" runat="server"></asp:TextBox>
                    <span class="glyphicon glyphicon-calendar form-control-feedback" style="margin-right: 13px; background-color: #eeeeff; border-radius: 0 3px 3px 0; border: 1px solid rgb(149,188,219); z-index: 0;"></span>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-2 control-label">
                    <asp:Label ID="lblSpecPermReason" runat="server"
                        Text="Reason"></asp:Label>
                </div>
                <div class="col-xs-6">
                    <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtSpecPermReason" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12 text-center">
                    <asp:Button CssClass="btn btn-primary btn-sm" ID="btnAddSpecPerm" runat="server" Text="Add Permission" UseSubmitBehavior="false" />
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12 center-block label-info control-label">
                    <asp:Label ID="Label6" runat="server" Text="Modules"></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12 center-block">
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                            <asp:GridView ID="grdSpecPermModules" runat="server" HorizontalAlign="center"
                                AutoGenerateColumns="False" BorderColor="#CCCCCC" BorderStyle="None"
                                BorderWidth="1px" CellPadding="3" Width="360px">
                                <PagerSettings FirstPageText="First" NextPageText="Next"
                                    PreviousPageText="Previous" />
                                <AlternatingRowStyle CssClass="altrowstyle" />
                                <HeaderStyle CssClass="headerstyle" HorizontalAlign="center" />
                                <RowStyle CssClass="rowstyle" />
                                <PagerStyle CssClass="pagination-ys" />
                                <Columns>
                                    <asp:TemplateField HeaderText="View">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkSpecPermView" runat="server" AutoPostBack="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Module ID">
                                        <ItemTemplate>
                                            <asp:Label ID="lblModuleId" runat="server" Text='<%#Eval("ModuleId")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Module Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblModuleName" runat="server" Text='<%#Eval("ModuleName")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="URL Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblURLName" runat="server" Text='<%#Eval("URL_NAME")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12 center-block">
                    <asp:Repeater ID="Repeater2" runat="server">
                        <ItemTemplate>
                            <li style="list-style-type: none" class="alert-info">
                                <asp:Label ID="role_pagelbl" runat="server" Font-Size="Medium"
                                    Text="<%# Container.DataItem %>"></asp:Label>
                            </li>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12 text-center">
                    <asp:Button CssClass="btn btn-primary btn-sm" ID="Button3" runat="server" Text="Save" UseSubmitBehavior="false" />
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        $('.datepicker').datepicker({
            format: 'dd MM yyyy',
            todayHighlight: true
        });

        $(function () {
            $("[id*=btn_SaveRole]").bind("click", function () {
                $("[id*=btn_SaveRole]").val("Saving...");
                $("[id*=btn_SaveRole]").attr("disabled", true);
            });
        });

        $('.nofuturedate').datepicker({
            format: 'dd MM yyyy',
            todayHighlight: true,
            endDate: '+0d'
        });
    </script>
</asp:Content>