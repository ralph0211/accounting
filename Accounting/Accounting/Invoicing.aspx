<%@ Page Title="" Language="VB" MasterPageFile="~/Site2.master" AutoEventWireup="false" CodeFile="Invoicing.aspx.vb" Inherits="Accounting_Invoicing" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="panel panel-primary small">
        <div class="panel-heading">
            <h4 class="panel-title">Invoicing
            </h4>
        </div>
        <div class="panel-body">
            <div class="row">
                <div class="col-xs-2 control-label">
                    Account Type
                </div>
                <div class="col-xs-4">
                    <asp:RadioButtonList ID="rdbAccountType" runat="server" AutoPostBack="True" RepeatDirection="Horizontal" CssClass="col-xs-12">
                        <asp:ListItem Value="221">Creditor</asp:ListItem>
                        <asp:ListItem Value="100">Debtor</asp:ListItem>
                    </asp:RadioButtonList>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-2 control-label">
                    <asp:Label ID="Label1220" runat="server" Text="Date"></asp:Label>
                </div>
                <div class="col-xs-4">
                    <asp:TextBox ID="dtpTrxnDate" runat="server" CssClass="form-control input-sm datepicker"></asp:TextBox>
                    <span class="glyphicon glyphicon-calendar form-control-feedback" style="margin-right: 13px; background-color: #eeeeff; border-radius: 0 3px 3px 0; border: 1px solid rgb(149,188,219); z-index: 0;"></span>
                </div>
                <div class="col-xs-2 control-label">
                    <asp:Label ID="Label1223" runat="server" Text="Status"></asp:Label>
                </div>
                <div class="col-xs-4">
                    <asp:RadioButtonList ID="rdbType0" runat="server" RepeatDirection="Horizontal" CssClass="col-xs-12">
                        <asp:ListItem>Posted</asp:ListItem>
                        <asp:ListItem>Not Posted</asp:ListItem>
                    </asp:RadioButtonList>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-2 control-label">
                    <asp:Label ID="Label23" runat="server" Text="Account "></asp:Label>
                </div>
                <div class="col-xs-4">
                    <asp:DropDownList ID="cmbAccount" runat="server" CssClass="form-control input-sm chosen">
                    </asp:DropDownList>
                </div>
                <div class="col-xs-2 control-label">
                    <asp:Label ID="Label1219" runat="server" Text="Transaction Amount"></asp:Label>
                </div>
                <div class="col-xs-4">
                    <asp:TextBox ID="txtAmount" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-2 control-label">
                    <asp:Label ID="Label1217" runat="server" Text="Reference"></asp:Label>
                </div>
                <div class="col-xs-4">
                    <asp:TextBox ID="txtRef" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                </div>
                <div class="col-xs-2 control-label">
                    <asp:Label ID="Label1221" runat="server" Text="Description"></asp:Label>
                </div>
                <div class="col-xs-4">
                    <asp:TextBox ID="txtdesc" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12 text-center">
                    <asp:Button ID="btnSaveTrxn3" runat="server" Text="Add" CssClass="btn btn-primary btn-sm" />
                    <asp:Button ID="btnSaveTrxn" runat="server" Text="Print" CssClass="btn btn-primary btn-sm" />
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12 center-block">
                    <asp:GridView ID="grdDetails" runat="server" HorizontalAlign="Center">
                        <AlternatingRowStyle CssClass="altrowstyle" />
                        <HeaderStyle CssClass="headerstyle" HorizontalAlign="center" />
                        <RowStyle CssClass="rowstyle" />
                        <PagerStyle CssClass="pagination-ys" />
                        <SelectedRowStyle Font-Bold="true" BackColor="#A8B1B9" />
                        <Columns>
                            <asp:TemplateField HeaderText="SELECT">
                                <ItemTemplate>
                                    <asp:CheckBox ID="checkbox2" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12 text-center">
                    <asp:Button ID="btnRemove" runat="server" Text="Remove Selected Item(s)" CssClass="btn btn-primary btn-sm" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>