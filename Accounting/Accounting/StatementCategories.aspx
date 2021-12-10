<%@ Page Title="Statement Categories" Language="VB" MasterPageFile="~/Site2.master" AutoEventWireup="false" CodeFile="StatementCategories.aspx.vb" Inherits="Accounting_StatementCategories" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="panel panel-primary small">
        <div class="panel-heading">
            <h4 class="panel-title">
                <a>Statement Categories</a>
            </h4>
        </div>
        <div class="panel-body">
            <div class="row">
                <div class="col-xs-2 control-label">
                    Statement
                </div>
                <div class="col-xs-4">
                    <asp:RadioButtonList ID="rdbStatementType" runat="server" RepeatDirection="Horizontal" CssClass="col-xs-12">
                        <asp:ListItem Text="Profit & Loss" Value="PL"></asp:ListItem>
                        <asp:ListItem Text="Balance Sheet" Value="BS"></asp:ListItem>
                    </asp:RadioButtonList>
                </div>
                <div class="col-xs-2 control-label">
                    Category
                </div>
                <div class="col-xs-4">
                    <asp:TextBox ID="txtCategory" runat="server" CssClass="col-xs-12 form-control input-sm"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12 text-center">
                    <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-primary btn-sm" />
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12 center-block">
                    <asp:GridView ID="grdCategories" runat="server" HorizontalAlign="Center" AutoGenerateColumns="false">
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
                            <asp:TemplateField HeaderText="Statement">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtGrdStatement" runat="server" Text='<%# Bind("Statement") %>' Visible="False"></asp:TextBox>
                                    <asp:DropDownList ID="cmbGrdStatement" runat="server">
                                    </asp:DropDownList>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblGrdStatement" runat="server" Text='<%# Bind("Statement") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Category">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtGrdCategory" runat="server" Text='<%# Bind("Category") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblGrdCategory" runat="server" Text='<%# Bind("Category") %>'></asp:Label>
                                    <asp:TextBox ID="txtGrdID" runat="server" Text='<%# Bind("id")%>' Visible="false"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12 label-info control-label">
                    Statement Subcategories
                </div>
            </div>
            <div class="row">
                <div class="col-xs-2 control-label">
                    Category
                </div>
                <div class="col-xs-4">
                    <asp:DropDownList ID="cmbCategory" CssClass="col-xs-12 form-control input-sm" runat="server"></asp:DropDownList>
                </div>
                <div class="col-xs-2 control-label">
                    Sub Category
                </div>
                <div class="col-xs-4">
                    <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtSubCategory" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-2 control-label">
                    Minimum Account Number
                </div>
                <div class="col-xs-4">
                    <asp:TextBox ID="txtMinAccNo" runat="server" CssClass="col-xs-12 form-control input-sm numeric"></asp:TextBox>
                </div>
                <div class="col-xs-2 control-label">
                    Maximum Account Number
                </div>
                <div class="col-xs-4">
                    <asp:TextBox ID="txtMaxAccNo" runat="server" CssClass="col-xs-12 form-control input-sm numeric"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12 text-center">
                    <asp:Button ID="btnSaveSubCategory" runat="server" Text="Save" CssClass="btn btn-primary btn-sm" />
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12 center-block">
                    <asp:GridView ID="grdSubCategory" runat="server" HorizontalAlign="Center" AutoGenerateColumns="false">
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
                            <asp:TemplateField HeaderText="Statement">
                                <EditItemTemplate>
                                    <asp:Label ID="txtGrdStatement" runat="server" Text='<%# Bind("Statement") %>'></asp:Label>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblGrdStatement" runat="server" Text='<%# Bind("Statement") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Category">
                                <EditItemTemplate>
                                    <asp:Label ID="txtGrdCategory" runat="server" Text='<%# Bind("Category") %>'></asp:Label>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblGrdCategory" runat="server" Text='<%# Bind("Category") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Sub Category">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtGrdSubCategory" runat="server" Text='<%# Bind("SubCategory") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblGrdSubCategory" runat="server" Text='<%# Bind("SubCategory") %>'></asp:Label>
                                    <asp:TextBox ID="txtGrdID" runat="server" Text='<%# Bind("id")%>' Visible="false"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Minimum Account Number">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtGrdMinAccount" runat="server" Text='<%# Bind("MinAccount") %>' CssClass="numeric"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblGrdMinAccount" runat="server" Text='<%# Bind("MinAccount") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Maximum Account Number">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtGrdMaxAccount" runat="server" Text='<%# Bind("MaxAccount") %>' CssClass="numeric"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblGrdMaxAccount" runat="server" Text='<%# Bind("MaxAccount") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12 label-info control-label">
                    Balance Sheet Items
                </div>
            </div>
            <div class="row">
                <div class="col-xs-1 control-label">
                    Sub Category
                </div>
                <div class="col-xs-5">
                    <asp:DropDownList ID="cmbSubCategory" CssClass="col-xs-12 form-control input-sm" runat="server"></asp:DropDownList>
                </div>
                <div class="col-xs-2 control-label">
                    Item Name
                </div>
                <div class="col-xs-4">
                    <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtItemName" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12 text-center">
                    <asp:Button ID="btnSaveItem" runat="server" Text="Save" CssClass="btn btn-primary btn-sm" />
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12 center-block">
                    <asp:GridView ID="grdBalanceSheetItems" runat="server" HorizontalAlign="Center">
                        <AlternatingRowStyle CssClass="altrowstyle" />
                        <HeaderStyle CssClass="headerstyle" HorizontalAlign="center" />
                        <RowStyle CssClass="rowstyle" />
                        <PagerStyle CssClass="pagination-ys" />
                        <SelectedRowStyle Font-Bold="true" BackColor="#A8B1B9" />
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
</asp:Content>