<%@ Page Title="Status Report" Language="VB" MasterPageFile="~/Site2.master" AutoEventWireup="false" CodeFile="frmStatus.aspx.vb" Inherits="Credit_frmStatus" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="panel panel-primary small">
        <div class="panel-heading">
            <h4 class="panel-title">
                <a>Status Report</a>
            </h4>
        </div>
        <div class="panel-body">
            <div class="row">
                <div class="col-xs-3 control-label">
                    <asp:Label ID="Label1" runat="server" Text="Branch" Visible="False"></asp:Label>
                </div>
                <div class="col-xs-3">
                    <asp:DropDownList CssClass="col-xs-12 form-control input-sm" ID="cmbBranch" runat="server" AppendDataBoundItems="True"
                        Visible="False">
                    </asp:DropDownList>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-3 control-label">
                    <asp:Label ID="Label12" runat="server" Text="Status"></asp:Label>
                </div>
                <div class="col-xs-3">
                    <asp:DropDownList CssClass="col-xs-12 form-control input-sm" ID="cmbStatus" runat="server" AppendDataBoundItems="True">
                    </asp:DropDownList>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-3 control-label">
                    <asp:Label ID="Label8" runat="server" Text="From Date"></asp:Label>
                </div>
                <div class="col-xs-3">
                    <asp:TextBox ID="bdpFromDate" runat="server" CssClass="col-xs-12 form-control input-sm datepicker"></asp:TextBox>
                    <span id="fromSpan" runat="server" class="glyphicon glyphicon-calendar form-control-feedback" style="margin-right: 13px; background-color: #eeeeff; border-radius: 0 3px 3px 0; border: 1px solid rgb(149,188,219);"></span>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-3 control-label">
                    <asp:Label ID="Label9" runat="server" Text="To Date"></asp:Label>
                </div>
                <div class="col-xs-3">
                    <asp:TextBox ID="bdpToDate" runat="server" CssClass="col-xs-12 form-control input-sm datepicker"></asp:TextBox>
                    <span id="Span1" runat="server" class="glyphicon glyphicon-calendar form-control-feedback" style="margin-right: 13px; background-color: #eeeeff; border-radius: 0 3px 3px 0; border: 1px solid rgb(149,188,219);"></span>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12 center-block">
                    <asp:Button CssClass="btn btn-primary btn-sm" ID="btnPrint" runat="server" Text="Print" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>