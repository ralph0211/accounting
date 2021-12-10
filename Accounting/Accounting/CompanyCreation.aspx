<%@ Page Title="Company Creation" Language="VB" MasterPageFile="~/Site2.master" AutoEventWireup="false" CodeFile="CompanyCreation.aspx.vb" Inherits="Accounting_CompanyCreation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="panel panel-primary small">
        <div class="panel-heading">
            <h4 class="panel-title">Company Creation
            </h4>
        </div>
        <div class="panel-body">
            <div class="row">
                <div class="col-xs-2 control-label">
                    Name
                    <asp:Label ID="Label123" runat="server" Text="*" ForeColor="Red" Font-Size="Large"></asp:Label>
                </div>
                <div class="col-xs-4">
                    <asp:TextBox ID="txtCompanyName" runat="server" CssClass="col-xs-12 form-control input-sm"></asp:TextBox>
                    <asp:RequiredFieldValidator Display="Dynamic" ID="rfvIDNo" runat="server" ErrorMessage="Company Name is required" ControlToValidate="txtCompanyName" ValidationGroup="valAcc"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-2 control-label">
                    Trade Name
                    <asp:Label ID="Label1" runat="server" Text="*" ForeColor="Red" Font-Size="Large"></asp:Label>
                </div>
                <div class="col-xs-4">
                    <asp:TextBox ID="txtTradeName" runat="server" CssClass="col-xs-12 form-control input-sm"></asp:TextBox>
                    <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator1" runat="server" ErrorMessage="Trade Name is required" ControlToValidate="txtTradeName" ValidationGroup="valAcc"></asp:RequiredFieldValidator>
                </div>
                <div class="col-xs-2 control-label">
                    Address
                </div>
                <div class="col-xs-4">
                    <asp:TextBox ID="txtAddress" runat="server" CssClass="col-xs-12 form-control input-sm" TextMode="MultiLine"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-2 control-label">
                    Contact Name
                </div>
                <div class="col-xs-4">
                    <asp:TextBox ID="txtContactName" runat="server" CssClass="col-xs-12 form-control input-sm"></asp:TextBox>
                </div>
                <div class="col-xs-2 control-label">
                    Contact Surname
                </div>
                <div class="col-xs-4">
                    <asp:TextBox ID="txtContactSurname" runat="server" CssClass="col-xs-12 form-control input-sm numeric"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-2 control-label">
                    Email
                </div>
                <div class="col-xs-4">
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="col-xs-12 form-control input-sm"></asp:TextBox>
                </div>
                <div class="col-xs-2 control-label">
                    Telephone 1
                </div>
                <div class="col-xs-4">
                    <asp:TextBox ID="txtTel1" runat="server" CssClass="col-xs-12 form-control input-sm"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-2 control-label">
                    Telephone 2
                </div>
                <div class="col-xs-4">
                    <asp:TextBox ID="txtTel2" runat="server" CssClass="col-xs-12 form-control input-sm"></asp:TextBox>
                </div>
                <div class="col-xs-2 control-label">
                    Mobile Phone
                </div>
                <div class="col-xs-4">
                    <asp:TextBox ID="txtMobile" runat="server" CssClass="col-xs-12 form-control input-sm"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-2 control-label">
                    Information
                </div>
                <div class="col-xs-4">
                    <asp:TextBox ID="txtInformation" runat="server" CssClass="col-xs-12 form-control input-sm"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12 text-center">
                    <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-primary btn-sm" ValidationGroup="valAcc" />
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12">
                    <asp:GridView ID="grdCompany" runat="server" HorizontalAlign="Center" AutoGenerateColumns="false">
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
                            <asp:TemplateField HeaderText="Company Name">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtGrdCompanyName" runat="server" Text='<%# Bind("CompanyName") %>' CssClass="col-xs-12 form-control input-sm"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblGrdCompanyName" runat="server" Text='<%# Bind("CompanyName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Trade Name">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtGrdTradeName" runat="server" Text='<%# Bind("TradeName") %>' CssClass="col-xs-12 form-control input-sm"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblGrdTradeName" runat="server" Text='<%# Bind("TradeName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Address">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtGrdAddress" runat="server" Text='<%# Bind("Address") %>' CssClass="col-xs-12 form-control input-sm"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblGrdAddress" runat="server" Text='<%# Bind("Address") %>'></asp:Label>
                                    <asp:TextBox ID="txtGrdID" runat="server" Text='<%# Bind("id")%>' Visible="false"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Contact Name">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtGrdContactName" runat="server" Text='<%# Bind("ContactName") %>' CssClass="col-xs-12 form-control input-sm"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblGrdContactName" runat="server" Text='<%# Bind("ContactName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Contact Surname">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtGrdContactSurname" runat="server" Text='<%# Bind("ContactSurname") %>' CssClass="col-xs-12 form-control input-sm"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblGrdContactSurname" runat="server" Text='<%# Bind("ContactSurname") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Email">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtGrdEmail" runat="server" Text='<%# Bind("Email") %>' CssClass="col-xs-12 form-control input-sm"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblGrdEmail" runat="server" Text='<%# Bind("Email") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Telephone 1">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtGrdTelephone1" runat="server" Text='<%# Bind("Telephone1") %>' CssClass="col-xs-12 form-control input-sm"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblGrdTelephone1" runat="server" Text='<%# Bind("Telephone1") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Telephone 2">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtGrdTelephone2" runat="server" Text='<%# Bind("Telephone2") %>' CssClass="col-xs-12 form-control input-sm"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblGrdTelephone2" runat="server" Text='<%# Bind("Telephone2") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Mobile">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtGrdMobile" runat="server" Text='<%# Bind("Mobile") %>' CssClass="col-xs-12 form-control input-sm"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblGrdMobile" runat="server" Text='<%# Bind("Mobile") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Information">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtGrdInformation" runat="server" Text='<%# Bind("Information") %>' CssClass="col-xs-12 form-control input-sm"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblGrdInformation" runat="server" Text='<%# Bind("Information") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
</asp:Content>