<%@ Page Title="Loan Rollover" Language="VB" MasterPageFile="~/Site2.master" AutoEventWireup="false" CodeFile="RollOver.aspx.vb" Inherits="Credit_RollOver" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="panel panel-primary small">
        <div class="panel-heading">Loan RollOver</div>
        <div class="panel-body">

            <div class="row">
                <div class="col-xs-2 control-label">Client Name</div>
                <div class="col-xs-4">
                    <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-xs-1">
                    <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-primary" />
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12">
                    <asp:GridView ID="grdApps" runat="server" AllowPaging="True" AutoGenerateColumns="True"
                        HorizontalAlign="Center" CssClass="table table-bordered table-striped tablestyle success"
                        EmptyDataText="Customer number not found!" EmptyDataRowStyle-CssClass="text-warning text-center">
                        <AlternatingRowStyle CssClass="altrowstyle" />
                        <HeaderStyle CssClass="header info" />
                        <RowStyle CssClass="rowstyle" />
                        <PagerStyle CssClass="pagination-ys" />
                        <SelectedRowStyle Font-Bold="true" />
                        <Columns>
                            <asp:CommandField SelectText="Roll Over" ShowSelectButton="True" />
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12 control-label label-info">
                    Loan Details
                </div>
            </div>
            <div class="row">
                <div class="control-label col-xs-2">
                    Loan Amount:
                </div>
                <div class="control-label col-xs-2">
                    <asp:Label ID="lblLoanAmount" runat="server" Text=""></asp:Label>
                </div>
                <div class="control-label col-xs-2">
                    Disbursement Date:
                </div>
                <div class="control-label col-xs-2">
                    <asp:Label ID="lblDisbDate" runat="server" Text=""></asp:Label>
                </div>
                <div class="control-label col-xs-2">
                    Maturity Date:
                </div>
                <div class="control-label col-xs-2">
                    <asp:Label ID="lblMaturityDate" runat="server" Text=""></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="control-label col-xs-2">
                    Interest Rate:
                </div>
                <div class="control-label col-xs-2">
                    <asp:Label ID="lblInterestRate" runat="server" Text=""></asp:Label>
                </div>
                <div class="control-label col-xs-2">
                    Interest Amount:
                </div>
                <div class="control-label col-xs-2">
                    <asp:Label ID="lblInterestAmount" runat="server" Text=""></asp:Label>
                </div>
                <div class="control-label col-xs-2">
                    Customer Number:
                </div>
                <div class="control-label col-xs-2">
                    <asp:Label ID="lblCustNo" runat="server" Text=""></asp:Label>
                </div>
            </div>
            <div class="row">
                <asp:GridView ID="grdRepaymentHistory" runat="server" Caption="Previous Repayments" CaptionAlign="Top" EmptyDataText="No repayments have been made" HorizontalAlign="Center">
                    <AlternatingRowStyle CssClass="altrowstyle" />
                    <HeaderStyle CssClass="headerstyle" HorizontalAlign="center" />
                    <RowStyle CssClass="rowstyle" />
                </asp:GridView>
            </div>
            <div class="row">
                <div class="col-xs-12 control-label label-info">
                    Rollover Details
                </div>
            </div>
            <div class="row">
                <div class="control-label col-xs-2">
                    Tenure of new facility
                </div>
                <div class="col-xs-4">
                    <asp:TextBox ID="txtTenure" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                </div>
                <div class="control-label col-xs-2">
                    Rollover Date
                </div>
                <div class="form-group col-xs-4">
                    <asp:TextBox ID="txtRolloverDate" runat="server" CssClass="form-control input-sm nofuturedate"></asp:TextBox>
                    <span class="glyphicon glyphicon-calendar form-control-feedback" style="margin-right: 13px; background-color: #eeeeff; border-radius: 0 3px 3px 0; border: 1px solid rgb(149,188,219); z-index: 0;"></span>
                </div>
            </div>
            <div class="row">
                <div class="control-label col-xs-2">
                    Capital Amount
                </div>
                <div class="form-group col-xs-4">
                    <asp:TextBox ID="txtCapital" runat="server" CssClass="form-control input-sm numeric"></asp:TextBox>
                </div>
                <div class="control-label col-xs-2">
                    Interest Amount
                </div>
                <div class="form-group col-xs-4">
                    <asp:TextBox ID="txtInterest" runat="server" CssClass="form-control input-sm numeric"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="control-label col-xs-2">
                    Total Amount to roll over
                </div>
                <div class="form-group col-xs-4">
                    <asp:TextBox ID="txtAmtPaid" runat="server" CssClass="form-control input-sm numeric"></asp:TextBox>
                </div>
                <div class="control-label col-xs-2">
                    Interest Rate
                </div>
                <div class="form-group col-xs-4">
                    <asp:TextBox ID="txtIntRate" runat="server" CssClass="form-control input-sm numeric"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-2 control-label">
                    Comment
                </div>
                <div class="col-xs-4">
                    <asp:TextBox ID="txtComment" runat="server" CssClass="form-control input-sm" TextMode="multiline"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12 text-center">
                    <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary" Text="Rollover" UseSubmitBehavior="false" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>