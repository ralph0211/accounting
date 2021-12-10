<%@ Page Title="Unlock Users" Language="VB" MasterPageFile="~/Site2.master" AutoEventWireup="false" CodeFile="UnlockUsers.aspx.vb" Inherits="Admin_UnlockUsers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="panel panel-primary small">
        <div class="panel-heading">
            <h4 class="panel-title">Unlock Users / Password Reset
            </h4>
        </div>
        <div class="panel-body">
                    <div class="row">
                        <div class="col-xs-12 label-info control-label">
                            Unlock User Account
                        </div>
                    </div>
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
                            <asp:GridView ID="grdLockedUsers" runat="server" AllowPaging="True"
                                AutoGenerateColumns="False" CellPadding="3"
                                HorizontalAlign="Center" Caption="Locked User Accounts"
                                EmptyDataText="No Locked Out Users" CssClass="table table-bordered table-striped tablestyle success"
                                EmptyDataRowStyle-CssClass="text-warning text-center">
                                <AlternatingRowStyle CssClass="altrowstyle" />
                                <HeaderStyle CssClass="header info" />
                                <RowStyle CssClass="rowstyle" />
                                <PagerStyle CssClass="pagination-ys" />
                                <Columns>
                                    <asp:TemplateField ShowHeader="False">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False"
                                                CommandName="Unlock" Text="Unlock" CommandArgument='<%#Eval("USERID")%>'></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Username">
                                        <ItemTemplate>
                                            <asp:Label ID="grdUsers_lblUsername" runat="server"><%#Eval("USER_LOGIN")%></asp:Label>
                                            <asp:TextBox ID="grdUsers_txtUsername" runat="server"
                                                Text='<%#Bind("USER_LOGIN") %>' Visible="False"></asp:TextBox>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="grdUsers_txtUsernameEdit" runat="server"
                                                Text='<%#Bind("USER_LOGIN") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="User Role">
                                        <ItemTemplate>
                                            <asp:Label ID="grdUsers_lblUserType" runat="server"><%#Eval("FullRoleName")%></asp:Label>
                                            <asp:TextBox ID="grdUsers_txtUserType" runat="server" Text='<%#Bind("USER_TYPE") %>' Visible="False"></asp:TextBox>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="grdUsers_txtUserTypeEdit" runat="server"
                                                Text='<%#Bind("USER_TYPE") %>' Visible="False"></asp:TextBox>
                                            <asp:DropDownList ID="grdUsers_cmbUserTypeEdit" runat="server">
                                            </asp:DropDownList>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Forenames">
                                        <ItemTemplate>
                                            <asp:Label ID="grdUsers_lblForenames" runat="server"><%#Eval("FNAME")%></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="grdUsers_txtForenamesEdit" runat="server"
                                                Text='<%#Bind("FNAME") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Surname">
                                        <ItemTemplate>
                                            <asp:Label ID="grdUsers_lblSurname" runat="server"><%#Eval("LNAME")%></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="grdUsers_txtSurnameEdit" runat="server"
                                                Text='<%#Bind("LNAME") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Email">
                                        <ItemTemplate>
                                            <asp:Label ID="grdUsers_lblEmail" runat="server"><%#Eval("USER_EMAIL_ID")%></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="grdUsers_txtEmailEdit" runat="server"
                                                Text='<%#Bind("USER_EMAIL_ID") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Telephone">
                                        <ItemTemplate>
                                            <asp:Label ID="grdUsers_lblTel" runat="server"><%#Eval("USER_PHONE_NO1")%></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="grdUsers_txtTelEdit" runat="server"
                                                Text='<%#Bind("USER_PHONE_NO1") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Branch">
                                        <ItemTemplate>
                                            <asp:Label ID="grdUsers_lblBranch" runat="server"><%#Eval("FullBranchName")%></asp:Label>
                                            <asp:TextBox ID="grdUsers_txtBranch" runat="server" Text='<%#Bind("USER_BRANCH") %>' Visible="False"></asp:TextBox>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="grdUsers_txtBranchEdit" runat="server"
                                                Text='<%#Bind("USER_BRANCH") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-12 label-info control-label">
                            Password Reset
                        </div>
                    </div>
                   <div class="row">
                        <div class="col-xs-12 center">
                            <asp:GridView ID="grdResetPassword" runat="server" AllowPaging="True" AutoGenerateColumns="false"
                                HorizontalAlign="Center" CssClass="table table-bordered table-striped tablestyle success"
                                EmptyDataRowStyle-CssClass="text-warning text-center">
                                <AlternatingRowStyle CssClass="altrowstyle" />
                                <HeaderStyle CssClass="header info" />
                                <RowStyle CssClass="rowstyle" />
                                <PagerStyle CssClass="pagination-ys" />
                                <Columns>
                                    <asp:TemplateField ShowHeader="False">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" OnClientClick="return isReset();"
                                                CommandName="Reset" Text="Reset" CommandArgument='<%#Eval("USERID")%>'></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Username">
                                        <ItemTemplate>
                                            <asp:Label ID="grdUsers_lblUsername" runat="server"><%#Eval("USER_LOGIN")%></asp:Label>
                                            <asp:TextBox ID="grdUsers_txtUsername" runat="server"
                                                Text='<%#Bind("USER_LOGIN") %>' Visible="False"></asp:TextBox>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="grdUsers_txtUsernameEdit" runat="server"
                                                Text='<%#Bind("USER_LOGIN") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="User Role">
                                        <ItemTemplate>
                                            <asp:Label ID="grdUsers_lblUserType" runat="server"><%#Eval("FullRoleName")%></asp:Label>
                                            <asp:TextBox ID="grdUsers_txtUserType" runat="server" Text='<%#Bind("USER_TYPE") %>' Visible="False"></asp:TextBox>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="grdUsers_txtUserTypeEdit" runat="server"
                                                Text='<%#Bind("USER_TYPE") %>' Visible="False"></asp:TextBox>
                                            <asp:DropDownList ID="grdUsers_cmbUserTypeEdit" runat="server">
                                            </asp:DropDownList>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Forenames">
                                        <ItemTemplate>
                                            <asp:Label ID="grdUsers_lblForenames" runat="server"><%#Eval("FNAME")%></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="grdUsers_txtForenamesEdit" runat="server"
                                                Text='<%#Bind("FNAME") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Surname">
                                        <ItemTemplate>
                                            <asp:Label ID="grdUsers_lblSurname" runat="server"><%#Eval("LNAME")%></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="grdUsers_txtSurnameEdit" runat="server"
                                                Text='<%#Bind("LNAME") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Email">
                                        <ItemTemplate>
                                            <asp:Label ID="grdUsers_lblEmail" runat="server"><%#Eval("USER_EMAIL_ID")%></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="grdUsers_txtEmailEdit" runat="server"
                                                Text='<%#Bind("USER_EMAIL_ID") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Telephone">
                                        <ItemTemplate>
                                            <asp:Label ID="grdUsers_lblTel" runat="server"><%#Eval("USER_PHONE_NO1")%></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="grdUsers_txtTelEdit" runat="server"
                                                Text='<%#Bind("USER_PHONE_NO1") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Branch">
                                        <ItemTemplate>
                                            <asp:Label ID="grdUsers_lblBranch" runat="server"><%#Eval("FullBranchName")%></asp:Label>
                                            <asp:TextBox ID="grdUsers_txtBranch" runat="server" Text='<%#Bind("USER_BRANCH") %>' Visible="False"></asp:TextBox>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="grdUsers_txtBranchEdit" runat="server"
                                                Text='<%#Bind("USER_BRANCH") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
               </div>
            </div>
    <script type="text/javascript">
        function isReset() {
            return confirm("Are you sure you want to reset this password?");
        };
    </script>
</asp:Content>