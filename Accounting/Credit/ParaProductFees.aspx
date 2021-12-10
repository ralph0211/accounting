<%@ Page Title="Product Fee Setup" Language="VB" MasterPageFile="~/Site2.master" AutoEventWireup="false" CodeFile="ParaProductFees.aspx.vb" Inherits="Credit_ParaProductFees" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="panel panel-primary small">
        <div class="panel-heading">
            <h4 class="panel-title">Product Fees Setup
            </h4>
        </div>
        <div class="panel-body">
            <div class="row">
                <div class="col-xs-2 control-label">
                    Product Name
                </div>
                <div class="col-xs-4">
                    <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtProduct" runat="server"></asp:TextBox>
                </div>
                <div class="col-xs-2 control-label">
                    Fee Type
                </div>
                <div class="col-xs-4">
                    <asp:DropDownList ID="cmbFeeType" CssClass="col-xs-12 form-control input-sm" runat="server">
                        <asp:ListItem Text="" Value=""></asp:ListItem>
                        <asp:ListItem Text="Manual" Value="Manual"></asp:ListItem>
                        <asp:ListItem Text="Deducted Disbursement" Value="Deducted Disbursement"></asp:ListItem>
                        <asp:ListItem Text="Capitalized Disbursement" Value="Capitalized Disbursement"></asp:ListItem>
                        <asp:ListItem Text="Late Repayment" Value="Late Repayment"></asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-2 control-label">
                    Calculation Option
                </div>
                <div class="col-xs-5">
                    <asp:RadioButtonList ID="rdbCalcOption" RepeatDirection="Horizontal" CssClass="col-xs-12" runat="server">
                        <asp:ListItem Text="Flat Amount" Value="Flat Amount"></asp:ListItem>
                        <asp:ListItem Text="Percentage" Value="Percentage"></asp:ListItem>
                        <asp:ListItem Text="Case by Case" Value="Case by Case"></asp:ListItem>
                    </asp:RadioButtonList>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12 text-center">
                    <asp:Button ID="btnSaveFees" runat="server" CssClass="btn btn-primary btn-sm save-btn" Text="Save" UseSubmitBehavior="false" />
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12">
                    <asp:GridView ID="grdProductFees" runat="server" HorizontalAlign="Center" AutoGenerateColumns="False">
                        <AlternatingRowStyle CssClass="altrowstyle" />
                        <HeaderStyle CssClass="headerstyle" HorizontalAlign="center" />
                        <RowStyle CssClass="rowstyle" />
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
                            <asp:TemplateField HeaderText="Product Name">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtGrdProductName" runat="server" Text='<%# Bind("ProductName")%>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblGrdProductName" runat="server" Text='<%# Bind("ProductName")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Fee Type">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtGrdFeeType" runat="server" Text='<%# Bind("FeeType")%>' Visible="false"></asp:TextBox>
                                    <asp:DropDownList ID="cmbGrdFeeType" CssClass="col-xs-12 form-control input-sm" runat="server">
                                        <asp:ListItem Text="" Value=""></asp:ListItem>
                                        <asp:ListItem Text="Manual" Value="Manual"></asp:ListItem>
                                        <asp:ListItem Text="Deducted Disbursement" Value="Deducted Disbursement"></asp:ListItem>
                                        <asp:ListItem Text="Capitalized Disbursement" Value="Capitalized Disbursement"></asp:ListItem>
                                        <asp:ListItem Text="Late Repayment" Value="Late Repayment"></asp:ListItem>
                                    </asp:DropDownList>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblGrdFeeType" runat="server" Text='<%# Bind("FeeType")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Calculation Option">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtGrdCalcOption" runat="server" Text='<%# Bind("CalcOption")%>' Visible="false"></asp:TextBox>
                                    <asp:DropDownList ID="cmbGrdCalcOption" CssClass="col-xs-12 form-control input-sm" runat="server">
                                        <asp:ListItem Text="" Value=""></asp:ListItem>
                                        <asp:ListItem Text="Flat Amount" Value="Flat Amount"></asp:ListItem>
                                        <asp:ListItem Text="Percentage" Value="Percentage"></asp:ListItem>
                                        <asp:ListItem Text="Case by Case" Value="Case by Case"></asp:ListItem>
                                    </asp:DropDownList>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblGrdCalcOption" runat="server" Text='<%# Bind("CalcOption")%>'></asp:Label>
                                    <asp:TextBox ID="txtGrdProductFeeID" runat="server" Text='<%# Bind("id")%>' Visible="false"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
</asp:Content>