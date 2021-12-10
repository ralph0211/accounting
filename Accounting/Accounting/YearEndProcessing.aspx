<%@ Page Title="Year-End Processing" Language="VB" MasterPageFile="~/Site2.master" AutoEventWireup="false" CodeFile="YearEndProcessing.aspx.vb" Inherits="Accounting_YearEndProcessing" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="panel panel-primary small">
        <div class="panel-heading">
            <h4 class="panel-title">
                Year-End Processing
            </h4>
        </div>
        <div class="panel-body">
            <div class="row">
                <div class="col-xs-2 control-label">
                    <asp:Label ID="Label21" runat="server" Text="End Date"></asp:Label>
                </div>
                <div class="col-xs-4">
                    <asp:TextBox CssClass="col-xs-12 form-control input-sm nofuturedate" ID="txtEndDate" runat="server"></asp:TextBox>
                    <span class="glyphicon glyphicon-calendar form-control-feedback" style="margin-right: 13px; background-color: #eeeeff; border-radius: 0 3px 3px 0; border: 1px solid rgb(149,188,219); z-index: 0;"></span>
                </div>
                <div class="col-xs-3">
                    <asp:Button CssClass="btn btn-primary btn-sm" ID="btnSearchRange" runat="server" Text=">>" />
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12 center-block">
                    <asp:GridView ID="grdApps" runat="server" AutoGenerateColumns="False"
                        HorizontalAlign="Center" CssClass="table table-bordered table-striped tablestyle success"
                        EmptyDataText="No applications ready for processing!" EmptyDataRowStyle-CssClass="text-warning text-center">
                        <AlternatingRowStyle CssClass="altrowstyle" />
                        <EmptyDataRowStyle CssClass="text-warning text-center"></EmptyDataRowStyle>
                        <HeaderStyle CssClass="header info" />
                        <RowStyle CssClass="rowstyle" />
                        <PagerStyle CssClass="pagination-ys" />
                        <Columns>
                            <asp:TemplateField ShowHeader="True" HeaderText="Move">
                                <ItemTemplate>
                                    <%--<asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False"
                                        CommandName="Select" Text='<%#Eval("StageName") %>' CommandArgument='<%# Eval("ID") %>'></asp:LinkButton>--%>
                                    <asp:CheckBox ID="chkProcess" runat="server" />
                                    <asp:Label ID="lblType" runat="server" Text='<%#Eval("Type") %>' Visible="false"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="MainAccount" HeaderText="Main Account" />
                            <asp:BoundField DataField="AccountName" HeaderText="Account Name" />
                            <asp:BoundField DataField="Debit" HeaderText="Debit" />
                            <asp:BoundField DataField="Credit" HeaderText="Credit" />
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
            <div class="row">
            <div class="col-xs-2 control-label">
                Move all Balances to this account
            </div>
                <div class="col-xs-4">
                    <asp:DropDownList ID="cmbMoveAccount" runat="server" CssClass="col-xs-12 input-sm chosen"></asp:DropDownList>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12 text-center">
                    <asp:Button CssClass="btn btn-primary btn-sm" ID="btnProcess" runat="server" Text="Process" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>

