<%@ Page Title="Accounts Creation" Language="VB" MasterPageFile="~/Site2.master" AutoEventWireup="false" CodeFile="AccountsCreation.aspx.vb" Inherits="Accounting_AccountsCreation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="panel panel-primary small">
        <div class="panel-heading">
            <h4 class="panel-title">
                <a data-parent="#collapse" data-toggle="collapse" href="#collapse-one">Accounts Creation
                </a>
            </h4>
        </div>
        <div class="panel-body">
            <div class="row">
                <div class="col-xs-2 control-label">
                    Account Name
                    <asp:Label ID="Label123" runat="server" Text="*" ForeColor="Red" Font-Size="Large"></asp:Label>
                </div>
                <div class="col-xs-4">
                    <asp:TextBox ID="txtAccountName" runat="server" CssClass="col-xs-12 form-control input-sm"></asp:TextBox>
                    <asp:RequiredFieldValidator Display="Dynamic" ID="rfvIDNo" runat="server" ErrorMessage="Account Name is required" ControlToValidate="txtAccountName" ValidationGroup="valAcc"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-2 control-label">
                    Account Type
                    <asp:Label ID="Label1" runat="server" Text="*" ForeColor="Red" Font-Size="Large"></asp:Label>
                </div>
                <div class="col-xs-4">
                    <asp:RadioButtonList ID="rdbAccType" runat="server" RepeatDirection="Horizontal" CssClass="col-xs-12" AutoPostBack="true">
                        <asp:ListItem Text="Profit & Loss" Value="PL"></asp:ListItem>
                        <asp:ListItem Text="Balance Sheet" Value="BS"></asp:ListItem>
                    </asp:RadioButtonList>
                    <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator1" runat="server" ErrorMessage="Account Type is required" ControlToValidate="rdbAccType" ValidationGroup="valAcc"></asp:RequiredFieldValidator>
                </div>
                <div class="col-xs-2 control-label">
                    Category
                    <asp:Label ID="Label2" runat="server" Text="*" ForeColor="Red" Font-Size="Large"></asp:Label>
                </div>
                <div class="col-xs-4">
                    <asp:DropDownList ID="cmbCategory" runat="server" CssClass="col-xs-12 form-control input-sm" AutoPostBack="true"></asp:DropDownList>
                    <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator2" runat="server" ErrorMessage="Account Category is required" ControlToValidate="cmbCategory" ValidationGroup="valAcc"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-2 control-label">
                    Sub Category
                    <asp:Label ID="Label3" runat="server" Text="*" ForeColor="Red" Font-Size="Large"></asp:Label>
                </div>
                <div class="col-xs-4">
                    <asp:DropDownList ID="cmbSubCategory" runat="server" CssClass="col-xs-12 form-control input-sm" AutoPostBack="true"></asp:DropDownList>
                    <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator3" runat="server" ErrorMessage="Account Sub Category is required" ControlToValidate="cmbSubCategory" ValidationGroup="valAcc"></asp:RequiredFieldValidator>
                </div>
                <div class="col-xs-2 control-label">
                    Account Number
                    <asp:Label ID="Label4" runat="server" Text="*" ForeColor="Red" Font-Size="Large"></asp:Label>
                </div>
                <div class="col-xs-4">
                    <asp:TextBox ID="txtAccNumber" runat="server" CssClass="col-xs-12 form-control input-sm numeric"></asp:TextBox>
                    <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator4" runat="server" ErrorMessage="Account Number is required" ControlToValidate="txtAccNumber" ValidationGroup="valAcc"></asp:RequiredFieldValidator>
                    <asp:Label ID="lblAccNoRange" runat="server" Text="" ForeColor="Red"></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-2 control-label">
                    Account Description
                </div>
                <div class="col-xs-4">
                    <asp:TextBox ID="txtAccDesc" runat="server" CssClass="col-xs-12 form-control input-sm" TextMode="MultiLine"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12 text-center">
                    <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-primary btn-sm" ValidationGroup="valAcc" />
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12">
                    <asp:GridView ID="grdAccounts" runat="server" HorizontalAlign="Center" AutoGenerateColumns="false">
                        <AlternatingRowStyle CssClass="altrowstyle" />
                        <HeaderStyle CssClass="headerstyle" HorizontalAlign="center" />
                        <RowStyle CssClass="rowstyle" />
                        <PagerStyle CssClass="pagination-ys" />
                        <SelectedRowStyle Font-Bold="true" BackColor="#A8B1B9" />
                        <Columns>
                            <asp:TemplateField ShowHeader="False">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False"
                                        CommandName="Delete" Text="Delete" OnClientClick="return isDelete();"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField ShowHeader="False">
                                <EditItemTemplate>
                                    <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="True"
                                        CommandName="Update" Text="Update"></asp:LinkButton>
                                    &nbsp;<asp:LinkButton ID="LinkButton3" runat="server" CausesValidation="False"
                                        CommandName="Cancel" Text="Cancel"></asp:LinkButton>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton4" runat="server" CausesValidation="False"
                                        CommandName="Edit" Text="Edit"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Account Name">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtGrdAccountName" runat="server" Text='<%# Bind("AccountName") %>' CssClass="col-xs-12 form-control input-sm"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblGrdAccountName" runat="server" Text='<%# Bind("AccountName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Type">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtGrdType" runat="server" Text='<%# Bind("Type") %>' Visible="false"></asp:TextBox>
                                    <asp:DropDownList ID="cmbGrdType" runat="server" AutoPostBack="true" OnSelectedIndexChanged="cmbGrdType_SelectedIndexChanged" CssClass="col-xs-12 form-control input-sm">
                                        <asp:ListItem></asp:ListItem>
                                        <asp:ListItem Text="Profit & Loss" Value="PL"></asp:ListItem>
                                        <asp:ListItem Text="Balance Sheet" Value="BS"></asp:ListItem>
                                    </asp:DropDownList>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblGrdType" runat="server" Text='<%# Bind("Type") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Category">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtGrdCategory" runat="server" Text='<%# Bind("CatID") %>' Visible="false"></asp:TextBox>
                                    <asp:DropDownList ID="cmbGrdCategory" runat="server" AutoPostBack="true" OnSelectedIndexChanged="cmbGrdCategory_SelectedIndexChanged" CssClass="col-xs-12 form-control input-sm">
                                    </asp:DropDownList>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblGrdCategory" runat="server" Text='<%# Bind("Category") %>'></asp:Label>
                                    <asp:TextBox ID="txtGrdID" runat="server" Text='<%# Bind("Sysid")%>' Visible="false"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Sub Category">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtGrdSubCategory" runat="server" Text='<%# Bind("SubCatID") %>' Visible="false"></asp:TextBox>
                                    <asp:DropDownList ID="cmbGrdSubCategory" runat="server" CssClass="col-xs-12 form-control input-sm">
                                    </asp:DropDownList>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblGrdSubCategory" runat="server" Text='<%# Bind("SubCategory") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Account Number">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtGrdMainAccount" runat="server" Text='<%# Bind("MainAccount") %>' CssClass="col-xs-12 form-control input-sm"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblGrdMainAccount" runat="server" Text='<%# Bind("MainAccount") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Account Description">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtGrdDescription" runat="server" Text='<%# Bind("Description") %>' CssClass="col-xs-12 form-control input-sm"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblGrdDescription" runat="server" Text='<%# Bind("Description") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
</asp:Content>