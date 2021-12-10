<%@ Page Language="VB" MasterPageFile="~/Site2.master" AutoEventWireup="false" CodeFile="ParaPurpose.aspx.vb" Inherits="Credit_ParaPurpose" Title="Borrowing Purpose Parameters - Credit Management System" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="panel panel-primary small">
        <div class="panel-heading">
            <h4 class="panel-title">
                <a>Credit Purpose Parameters</a>
            </h4>
        </div>
        <div class="panel-body">
            <div class="row">
                <div class="col-xs-2 control-label">
                    Client Type
                </div>
                <div class="col-xs-4">
                    <asp:DropDownList CssClass="form-control input-sm col-xs-12" ID="cmbClientType" runat="server" AutoPostBack="true"></asp:DropDownList>
                </div>
                <div class="col-xs-1 control-label">
                    <asp:Label ID="Label5" runat="server" Text="Purpose"></asp:Label>
                </div>
                <div class="col-xs-4">
                    <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtPurpose" runat="server"></asp:TextBox>
                </div>

                <div class="col-xs-1">
                    <asp:Button CssClass="btn btn-primary btn-sm" ID="btnAddPurpose" runat="server" Text="Add" ValidationGroup="insert" />
                </div>
            </div>
            <div class="row">
                <div class="col-xs-2">
                </div>
                <div class="col-xs-5">
                    <asp:RequiredFieldValidator ID="reqCliType" runat="server" ErrorMessage="Client Type is required" Font-Bold="true" ForeColor="Red" ControlToValidate="cmbClientType" Display="Dynamic" ValidationGroup="insert"></asp:RequiredFieldValidator>
                </div>
                <div class="col-xs-2">
                    <asp:RequiredFieldValidator ID="reqPurpose" runat="server" ErrorMessage="Purpose is required" Font-Bold="true" ForeColor="Red" ControlToValidate="txtPurpose" Display="Dynamic" ValidationGroup="insert"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12 center-block">
                    <asp:GridView ID="grdPurpose" runat="server" AutoGenerateColumns="False"
                        EmptyDataText="No credit purpose added yet" HorizontalAlign="Center" Width="90%">
                        <AlternatingRowStyle CssClass="altrowstyle" />
                        <HeaderStyle CssClass="headerstyle" HorizontalAlign="center" />
                        <RowStyle CssClass="rowstyle" />
                        <PagerStyle CssClass="pagination-ys" />
                        <Columns>
                            <asp:TemplateField ShowHeader="False">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton3" runat="server" CausesValidation="False"
                                        CommandName="Delete" Text="Delete" OnClientClick="return isDelete();"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField ShowHeader="False">
                                <EditItemTemplate>
                                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True"
                                        CommandName="Update" Text="Update"></asp:LinkButton>
                                    <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False"
                                        CommandName="Cancel" Text="Cancel"></asp:LinkButton>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton4" runat="server" CausesValidation="False"
                                        CommandName="Edit" Text="Edit"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Purpose">
                                <EditItemTemplate>
                                    <asp:TextBox CssClass="col-xs-12 form-control input-sm" runat="server" Text='<%#Bind("PURPOSE")%>' ID="txtGrdPurpose">
                                    </asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblPurpose" runat="server"><%#Eval("PURPOSE")%></asp:Label>
                                    <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtGrdPurposeID" runat="server" Visible="False" Text='<%#Bind("ID")%>'></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
</asp:Content>