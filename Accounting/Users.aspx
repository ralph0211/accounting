<%@ Page Language="VB" MasterPageFile="~/Site2.master" AutoEventWireup="false" CodeFile="Users.aspx.vb" Inherits="Users" Title="Manage Users" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="panel panel-primary small">
        <div class="panel-heading">
            <h4 class="panel-title">Add/Edit Users
            </h4>
        </div>
        <div class="panel-body">
            <div class="row">
                <div class="col-xs-4">
                    <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtUserID" runat="server"
                        ReadOnly="True" Visible="False"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-2 control-label">
                    <asp:Label ID="Label5" runat="server" Text="User Role"></asp:Label>
                    <asp:Label ID="Label6" runat="server" Text="*" ForeColor="Red" Font-Size="Large"></asp:Label>
                </div>
                <div class="col-xs-4">
                    <asp:DropDownList CssClass="col-xs-12 form-control input-sm" ID="cmbUserRole" runat="server">
                    </asp:DropDownList>
                </div>
                <div class="col-xs-4">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic"
                        ControlToValidate="cmbUserRole" ErrorMessage="User Role is required" ValidationGroup="names"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-2 control-label">
                    <asp:Label ID="Label7" runat="server" Text="Branch"></asp:Label>
                    <asp:Label ID="Label8" runat="server" Text="*" ForeColor="Red" Font-Size="Large"></asp:Label>
                </div>
                <div class="col-xs-4">
                    <asp:DropDownList CssClass="col-xs-12 form-control input-sm" ID="cmbBranch" runat="server">
                    </asp:DropDownList>
                </div>
                <div class="col-xs-4">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="Dynamic"
                        ControlToValidate="cmbBranch" ErrorMessage="Branch is required" ValidationGroup="names"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-2 control-label">
                    <asp:Label ID="lblForename" runat="server" Text="Forenames"></asp:Label>
                    <asp:Label ID="Label9" runat="server" Text="*" ForeColor="Red" Font-Size="Large"></asp:Label>
                </div>
                <div class="col-xs-4">
                    <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtForeName" runat="server"
                        ValidationGroup="names"></asp:TextBox>
                </div>
                <div class="col-xs-4">
                    <asp:RequiredFieldValidator ID="rfvForenames" runat="server" Display="Dynamic"
                        ControlToValidate="txtForename" ErrorMessage="Forename is required" ValidationGroup="names"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-2 control-label">
                    <asp:Label ID="lblSurname" runat="server" Text="Surname"></asp:Label>
                    <asp:Label ID="Label10" runat="server" Text="*" ForeColor="Red" Font-Size="Large"></asp:Label>
                </div>
                <div class="col-xs-4">
                    <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtSurName" runat="server"
                        ValidationGroup="names"
                        AutoPostBack="True"></asp:TextBox>
                </div>
                <div class="col-xs-4">
                    <asp:RequiredFieldValidator ID="rfvSurname" runat="server" Display="Dynamic"
                        ControlToValidate="txtSurname" ErrorMessage="Surname is required" ValidationGroup="names"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-2 control-label">
                    <asp:Label ID="Label2" runat="server"
                        Text="User Name"></asp:Label>
                    <asp:Label ID="Label11" runat="server" Text="*" ForeColor="Red" Font-Size="Large"></asp:Label>
                </div>
                <div class="col-xs-4">
                    <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtUserName" runat="server"
                        ValidationGroup="names"></asp:TextBox>
                </div>
                <div class="col-xs-4">
                    <asp:RequiredFieldValidator ID="rfvUsername" runat="server" Display="Dynamic"
                        ControlToValidate="txtUserName" ErrorMessage="User name is required" ValidationGroup="names"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-2 control-label">
                    <asp:Label ID="lblEmail" runat="server"
                        Text="Email address"></asp:Label>
                    <asp:Label ID="Label12" runat="server" Text="*" ForeColor="Red" Font-Size="Large"></asp:Label>
                </div>
                <div class="col-xs-4">
                    <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtEmailAddress" runat="server"></asp:TextBox>
                </div>
                <div class="col-xs-4">
                    <asp:RequiredFieldValidator ID="rfvEmail" runat="server" Display="Dynamic"
                        ControlToValidate="txtEmailAddress" ErrorMessage="Email address is required" ValidationGroup="names"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator Display="Dynamic" ID="valEmpEmail" runat="server" ControlToValidate="txtEmailAddress" ValidationGroup="names" ValidationExpression="^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z\.][a-zA-Z]{1,3}$" ErrorMessage="Please enter a valid email address"></asp:RegularExpressionValidator>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-2 control-label">
                    <asp:Label ID="lblPhone" runat="server"
                        Text="Cellphone Number"></asp:Label>
                    <asp:Label ID="Label13" runat="server" Text="*" ForeColor="Red" Font-Size="Large"></asp:Label>
                </div>
                <div class="col-xs-4">
                    <asp:TextBox CssClass="col-xs-12 form-control input-sm phone" ID="txtPhoneNumber" runat="server"></asp:TextBox>
                </div>
                <div class="col-xs-4">
                    <asp:RequiredFieldValidator ID="rfvPhone" runat="server" Display="Dynamic"
                        ControlToValidate="txtPhoneNumber" ErrorMessage="Phone number is required" ValidationGroup="names"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-2 control-label">
                    <asp:Label ID="Label4" runat="server" Text="User Roles" Visible="False"></asp:Label>
                </div>
                <div class="col-xs-6">
                    <asp:Panel ID="Panel1" runat="server" Height="200px" ScrollBars="Auto"
                        Visible="False">
                        <asp:GridView ID="grdUserRoles" runat="server" AutoGenerateColumns="False"
                            BorderStyle="None" BorderWidth="1px" CellPadding="3">
                            <PagerSettings FirstPageText="First" NextPageText="Next"
                                PreviousPageText="Previous" />
                            <AlternatingRowStyle CssClass="altrowstyle" />
                            <HeaderStyle CssClass="headerstyle" HorizontalAlign="center" />
                            <RowStyle CssClass="rowstyle" />
                            <Columns>
                                <asp:TemplateField HeaderText="">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="Chk" runat="server" AutoPostBack="false" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Role ID">
                                    <ItemTemplate>
                                        <asp:Label ID="lblRoleId" runat="server" Text='<%#Eval("RoleId")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Role Name">
                                    <ItemTemplate>
                                        <asp:Label ID="lblRoleName" runat="server" Text='<%#Eval("RoleName")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </asp:Panel>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-2 control-label">
                    <asp:Label ID="Label3" runat="server"
                        Text="Password" Visible="False"></asp:Label>
                </div>
                <div class="col-xs-4">
                    <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtPwd" runat="server"
                        Visible="False"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12 text-center">
                    <asp:Button CssClass="btn btn-primary btn-sm" ID="btnSubmit" runat="server" Text="Submit"
                        ValidationGroup="names" UseSubmitBehavior="false" />
                    <asp:Button CssClass="btn btn-danger btn-sm" ID="btnReset" runat="server" Text="Reset"
                        CausesValidation="False" />
                </div>
            </div>
            <div class="row">
                <div class="col-xs-2 control-label">
                    <asp:Label ID="Label1" runat="server" Text="Search User" Visible="False"></asp:Label>
                </div>
                <div class="col-xs-4">
                    <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtSearchUser" runat="server" Visible="False"></asp:TextBox>
                </div>
                <div class="col-xs-4">
                    <asp:Button CssClass="btn btn-primary btn-sm" ID="btnSearchUser" runat="server" Text=">>" Visible="False" />
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12 center-block">
                    <asp:GridView ID="grdAddedUsers" runat="server" AllowPaging="True"
                        AutoGenerateColumns="False" CellPadding="3"
                        HorizontalAlign="Center">
                        <AlternatingRowStyle CssClass="altrowstyle" />
                        <HeaderStyle CssClass="headerstyle" HorizontalAlign="center" />
                        <RowStyle CssClass="rowstyle" />
                        <PagerStyle CssClass="pagination-ys" />
                        <Columns>
                            <asp:TemplateField ShowHeader="False">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False"
                                        CommandName="Delete" OnClientClick="return isDelete();" Text="Delete"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField ShowHeader="False">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False"
                                        CommandName="Edit" Text="Edit"></asp:LinkButton>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:LinkButton ID="LinkButton3" runat="server" CausesValidation="False"
                                        CommandName="Update" Text="Update"></asp:LinkButton>
                                    <asp:LinkButton ID="LinkButton4" runat="server" CausesValidation="False"
                                        CommandName="Cancel" Text="Cancel"></asp:LinkButton>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Username">
                                <ItemTemplate>
                                    <asp:Label ID="grdUsers_lblUsername" runat="server"><%#Eval("USER_LOGIN")%></asp:Label>
                                    <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="grdUsers_txtUsername" runat="server"
                                        Text='<%#Bind("USER_LOGIN") %>' Visible="False"></asp:TextBox>
                                    <asp:TextBox ID="grdUsers_txtUserId" runat="server" Visible="false" Text='<%#Bind("USERID")%>'></asp:TextBox>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="grdUsers_txtUsernameEdit" runat="server"
                                        Text='<%#Bind("USER_LOGIN") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="User Role">
                                <ItemTemplate>
                                    <asp:Label ID="grdUsers_lblUserType" runat="server"><%#Eval("FullRoleName")%></asp:Label>
                                    <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="grdUsers_txtUserType" runat="server" Text='<%#Bind("USER_TYPE") %>' Visible="False"></asp:TextBox>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="grdUsers_txtUserTypeEdit" runat="server"
                                        Text='<%#Bind("USER_TYPE") %>' Visible="False"></asp:TextBox>
                                    <asp:DropDownList CssClass="col-xs-12 form-control input-sm" ID="grdUsers_cmbUserTypeEdit" runat="server">
                                    </asp:DropDownList>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Forenames">
                                <ItemTemplate>
                                    <asp:Label ID="grdUsers_lblForenames" runat="server" Text='<%#Eval("FNAME")%>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="grdUsers_txtForenamesEdit" runat="server"
                                        Text='<%#Bind("FNAME") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Surname">
                                <ItemTemplate>
                                    <asp:Label ID="grdUsers_lblSurname" runat="server" Text='<%#Eval("LNAME")%>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="grdUsers_txtSurnameEdit" runat="server"
                                        Text='<%#Bind("LNAME") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Email">
                                <ItemTemplate>
                                    <asp:Label ID="grdUsers_lblEmail" runat="server" Text='<%#Eval("USER_EMAIL_ID")%>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="grdUsers_txtEmailEdit" runat="server"
                                        Text='<%#Bind("USER_EMAIL_ID") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Telephone">
                                <ItemTemplate>
                                    <asp:Label ID="grdUsers_lblTel" runat="server" Text='<%#Eval("USER_PHONE_NO1")%>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="grdUsers_txtTelEdit" runat="server"
                                        Text='<%#Bind("USER_PHONE_NO1") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Branch">
                                <ItemTemplate>
                                    <asp:Label ID="grdUsers_lblBranch" runat="server"><%#Eval("FullBranchName")%></asp:Label>
                                    <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="grdUsers_txtBranch" runat="server" Text='<%#Bind("USER_BRANCH") %>' Visible="False"></asp:TextBox>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="grdUsers_txtBranchEdit" runat="server" Visible="false"
                                        Text='<%#Bind("USER_BRANCH") %>'></asp:TextBox>
                                    <asp:DropDownList CssClass="col-xs-12 form-control input-sm" ID="grdUsers_cmbBranchEdit" runat="server">
                                    </asp:DropDownList>
                                </EditItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        function fnOnUpdateValidators() {
            for (var i = 0; i < Page_Validators.length; i++) {
                var val = Page_Validators[i];
                var ctrl = document.getElementById(val.controltovalidate);
                if (ctrl != null && ctrl.style != null) {
                    if (!val.isvalid)
                        //ctrl.style.background = '#FFAAAA';
                        ctrl.style.borderColor = '#FF0000';
                    else
                        //ctrl.style.backgroundColor = '';
                        ctrl.style.borderColor = '';
                }
            }
        };
    </script>
</asp:Content>