<%@ Page Language="VB" MasterPageFile="~/Site2.master" AutoEventWireup="false" CodeFile="frmDisbursements.aspx.vb" Inherits="Credit_frmDisbursements" Title="Disbursements Report - Credit Management System" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="panel panel-primary small">
        <div class="panel-heading">
            <h4 class="panel-title">
                <a>Disbursements Report</a>
            </h4>
        </div>
        <div class="panel-body">
            <div class="row">
                <div class="col-xs-3 control-label">
                    <asp:Label ID="Label8" runat="server" Text="From Date"></asp:Label>
                </div>
                <div class="col-xs-3">
                    <asp:TextBox ID="bdpFromDate" runat="server" CssClass="form-control input-sm datepicker"></asp:TextBox>
                    <span class="glyphicon glyphicon-calendar form-control-feedback" style="margin-right: 13px; background-color: #eeeeff; border-radius: 0 3px 3px 0; border: 1px solid rgb(149,188,219); z-index: 0;"></span>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-3 control-label">
                    <asp:Label ID="Label9" runat="server" Text="To Date"></asp:Label>
                </div>
                <div class="col-xs-3">
                    <asp:TextBox ID="bdpToDate" runat="server" CssClass="form-control input-sm datepicker"></asp:TextBox>
                    <span class="glyphicon glyphicon-calendar form-control-feedback" style="margin-right: 13px; background-color: #eeeeff; border-radius: 0 3px 3px 0; border: 1px solid rgb(149,188,219); z-index: 0;"></span>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-3 control-label">
                    <asp:Label ID="lblDisbursementOption" runat="server" Text="Disbursement Option"></asp:Label>
                </div>
                <div class="col-xs-3">
                    <asp:DropDownList CssClass="col-xs-12 form-control input-sm" ID="cmbDisburseOption" runat="server">
                        <asp:ListItem Text="All" Value=""></asp:ListItem>
                        <asp:ListItem Text="Cash" Value="Cash"></asp:ListItem>
                        <asp:ListItem Text="Ecocash" Value="Ecocash"></asp:ListItem>
                        <asp:ListItem Text="RTGS" Value="RTGS"></asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12 text-center">
                    <asp:Button CssClass="btn btn-primary btn-sm" ID="btnPrint" runat="server" Text="Print" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>