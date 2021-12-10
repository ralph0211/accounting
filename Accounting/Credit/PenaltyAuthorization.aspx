<%@ Page Title="Penalty Posting" Language="VB" MasterPageFile="~/Site2.master" AutoEventWireup="false" CodeFile="PenaltyAuthorization.aspx.vb" Inherits="Credit_PenaltyAuthorization" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="panel panel-primary small">
        <div class="panel-heading">
            <h4 class="panel-title">Penalty Authorization
            </h4>
        </div>
        <div class="panel-body">
            <div class="row">
                <div class="col-xs-2 control-label">
                    Up to Date
                </div>
                <div class="col-xs-4">
                    <asp:TextBox ID="txtUptoDate" runat="server" CssClass="col-xs-12 form-control datepicker input-sm"></asp:TextBox>
                    <span class="glyphicon glyphicon-calendar form-control-feedback" style="margin-right: 13px; background-color: #eeeeff; border-radius: 0 3px 3px 0; border: 1px solid rgb(149,188,219); z-index: 0;"></span>
                </div>
                <div class="col-xs-1">
                    <asp:Button ID="btnSearchDate" CssClass="btn btn-primary btn-sm" runat="server" Text=">>" UseSubmitBehavior="false" />
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12">
                    <asp:CheckBox ID="chkAll" runat="server" Text="Select/Unselect All" AutoPostBack="true" />
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12 center-block">
                    <asp:GridView ID="grdPenalties" runat="server" HorizontalAlign="Center" AutoGenerateColumns="False">
                        <AlternatingRowStyle CssClass="altrowstyle" />
                        <HeaderStyle CssClass="headerstyle" HorizontalAlign="center" />
                        <RowStyle CssClass="rowstyle" />
                        <PagerStyle CssClass="pagination-ys" />
                        <Columns>
                            <asp:TemplateField HeaderText="Select">
                                <ItemTemplate>
                                    <asp:CheckBox ID="Chk" runat="server" AutoPostBack="false" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField ShowHeader="False">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandArgument='<%# Eval("LoanID") %>' CommandName="Select" Text="View Daily Transactions"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="CustNo" HeaderText="Customer No." />
                            <asp:BoundField DataField="Name" HeaderText="Name" />
                            <asp:BoundField DataField="IDNO" HeaderText="ID Number" />
                            <asp:BoundField DataField="LoanID" HeaderText="Loan ID" />
                            <asp:BoundField DataField="InstalmentNo" HeaderText="Instalment" />
                            <asp:BoundField DataField="InstalmentDueDate" HeaderText="Due Date" />
                            <asp:BoundField DataField="InstalmentBalance" HeaderText="Balance" />
                            <asp:BoundField DataField="PenaltyRate" HeaderText="Penalty Rate" />
                            <asp:BoundField DataField="PenaltyAmount" HeaderText="Penalty Amount" />
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12 text-center">
                    <asp:Button CssClass="btn btn-primary btn-sm" ID="btnAuthorize" runat="server" Text="Authorize" UseSubmitBehavior="false" />
                    <asp:Button CssClass="btn btn-danger btn-sm" ID="btnDiscard" runat="server" Text="Discard" UseSubmitBehavior="false" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>