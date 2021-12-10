<%@ Page Title="Creditor Accounts Creation" Language="VB" MasterPageFile="~/Site2.master" AutoEventWireup="false" CodeFile="CreditorAccountCreation.aspx.vb" Inherits="Accounting_CreditorAccountCreation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="panel panel-primary small">
        <div class="panel-heading">
            <h4 class="panel-title">
                <a data-parent="#collapse" data-toggle="collapse" href="#collapse-one">Creditor Accounts Creation
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
                <div class="col-xs-2 control-label">
                    Main Account
                    <asp:Label ID="Label1r23" runat="server" Text="*" ForeColor="Red" Font-Size="Large"></asp:Label>
                </div>
                <div class="col-xs-4">
                    <asp:DropDownList ID="cmbMainAccount" runat="server" CssClass="col-xs-12 form-control input-sm"></asp:DropDownList>
                    <asp:RequiredFieldValidator Display="Dynamic" ID="rfvMainAcc" runat="server" ErrorMessage="Main Account is required" ControlToValidate="cmbMainAccount" ValidationGroup="valAcc"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-2 control-label">
                    Account Number
                    <asp:Label ID="Label4" runat="server" Text="*" ForeColor="Red" Font-Size="Large"></asp:Label>
                </div>
                <div class="col-xs-4">
                    <asp:TextBox ID="txtAccNumber" runat="server" CssClass="col-xs-12 form-control input-sm"></asp:TextBox>
                    <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator4" runat="server" ErrorMessage="Account Number is required" ControlToValidate="txtAccNumber" ValidationGroup="valAcc"></asp:RequiredFieldValidator>
                    <asp:Label ID="lblAccNoRange" runat="server" Text="" ForeColor="Red"></asp:Label>
                </div>
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
                            <asp:TemplateField HeaderText="Main Account">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtGrdMainAccountNo" runat="server" Text='<%# Bind("MAcc") %>' Visible="false"></asp:TextBox>
                                    <asp:DropDownList ID="cmbGrdMainAccount" runat="server" AutoPostBack="true" CssClass="col-xs-12 form-control input-sm">
                                    </asp:DropDownList>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblGrdMainAccountName" runat="server" Text='<%# Bind("MainAccName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Account Number">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtGrdMainAccount" runat="server" Text='<%# Bind("AccountNo") %>' CssClass="col-xs-12 form-control input-sm"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblGrdMainAccount" runat="server" Text='<%# Bind("AccountNo") %>'></asp:Label>
                                    <asp:TextBox ID="txtGrdID" runat="server" Text='<%# Bind("id")%>' Visible="false"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Account Description">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtGrdDescription" runat="server" Text='<%# Bind("AccountDesc") %>' CssClass="col-xs-12 form-control input-sm"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblGrdDescription" runat="server" Text='<%# Bind("AccountDesc") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
</asp:Content>