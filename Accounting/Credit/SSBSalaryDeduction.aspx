<%@ Page Language="VB" MasterPageFile="~/Site2.master" AutoEventWireup="false" CodeFile="SSBSalaryDeduction.aspx.vb" Inherits="Credit_SSBSalaryDeduction" Title="Salary Deduction - Credit Management System" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="panel panel-primary small">
        <div class="panel-heading">
            <h4 class="panel-title">
                <a>SSB Salary Deduction</a>
            </h4>
        </div>
        <div class="panel-body">
            <div class="row">
                <div class="col-xs-3 control-label">
                    <asp:Label ID="Label92" runat="server" Text="Search Surname"></asp:Label>
                </div>
                <div class="col-xs-3">
                    <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtSearchSurname" runat="server"></asp:TextBox>
                </div>
                <div class="col-xs-1">
                    <asp:Button CssClass="btn btn-primary btn-sm" ID="btnSearchSurname" runat="server" Text=">>" />
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12 center-block">
                    <asp:ListBox ID="lstSurname" runat="server" AutoPostBack="True" Visible="False"></asp:ListBox>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-3 control-label">
                    <asp:Label ID="Label7" runat="server" Text="Loan Number"></asp:Label>
                </div>
                <div class="col-xs-3">
                    <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtLoanNo" runat="server"></asp:TextBox>
                </div>
                <div class="col-xs-1">
                    <asp:Button CssClass="btn btn-primary btn-sm" ID="btnSearchLoanNo" runat="server" Text=">>" />
                </div>
            </div>
            <div class="row">
                <div class="col-xs-3 control-label">
                    <asp:Label ID="Label8" runat="server"
                        Text="Name"></asp:Label>
                </div>
                <div class="col-xs-3">
                    <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtSSBName" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-3 control-label">
                    <asp:Label ID="Label9" runat="server"
                        Text="Ministry/Department"></asp:Label>
                </div>
                <div class="col-xs-3">
                    <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtMinistry" runat="server"></asp:TextBox>
                </div>
                <div class="col-xs-3 control-label">
                    <asp:Label ID="Label19" runat="server"
                        Text="Ministry/Department No."></asp:Label>
                </div>
                <div class="col-xs-3">
                    <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtMinistryNo" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-3 control-label">
                    <asp:Label ID="lblDisbursementOption" runat="server"
                        Text="Tick Applicable"></asp:Label>
                </div>
                <div class="col-xs-3">
                    <asp:CheckBoxList ID="chkApplicable" runat="server" CssClass="col-xs-12"
                        RepeatDirection="Horizontal">
                        <asp:ListItem Text="New" Value="New"></asp:ListItem>
                        <asp:ListItem Text="Change" Value="Change"></asp:ListItem>
                        <asp:ListItem Text="Cease" Value="Cease"></asp:ListItem>
                    </asp:CheckBoxList>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-3 control-label">
                    <asp:Label ID="Label1" runat="server"
                        Text="Employee Code Number"></asp:Label>
                </div>
                <div class="col-xs-3">
                    <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtECNo" runat="server"></asp:TextBox>
                </div>
                <div class="col-xs-3 control-label">
                    <asp:Label ID="Label2s" runat="server"
                        Text="C/D"></asp:Label>
                </div>
                <div class="col-xs-3">
                    <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtCD" runat="server" Width="35px"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-3 control-label">
                    <asp:Label ID="Label3" runat="server"
                        Text="Payee Code"></asp:Label>
                </div>
                <div class="col-xs-3">
                    <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtPayeeCode" runat="server"></asp:TextBox>
                </div>
                <div class="col-xs-3 control-label">
                    <asp:Label ID="Label4" runat="server"
                        Text="Monthly Rate"></asp:Label>
                </div>
                <div class="col-xs-3">
                    <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtMonthlyRate" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-3 control-label">
                    <asp:Label ID="Label5" runat="server"
                        Text="From Date"></asp:Label>
                </div>
                <div class="col-xs-3">
                    <asp:TextBox CssClass="col-xs-12 form-control input-sm datepicker" ID="bdpFromDate" runat="server"></asp:TextBox>
                    <span class="glyphicon glyphicon-calendar form-control-feedback" style="margin-right: 13px; background-color: #eeeeff; border-radius: 0 3px 3px 0; border: 1px solid rgb(149,188,219); z-index: 0;"></span>
                </div>
                <div class="col-xs-3 control-label">
                    <asp:Label ID="Label6" runat="server"
                        Text="To Date"></asp:Label>
                </div>
                <div class="col-xs-3">
                    <asp:TextBox CssClass="col-xs-12 form-control input-sm datepicker" ID="bdpToDate" runat="server"></asp:TextBox>
                    <span class="glyphicon glyphicon-calendar form-control-feedback" style="margin-right: 13px; background-color: #eeeeff; border-radius: 0 3px 3px 0; border: 1px solid rgb(149,188,219); z-index: 0;"></span>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-3 control-label">
                    <asp:Label ID="Label10" runat="server"
                        Text="Reference Number"></asp:Label>
                </div>
                <div class="col-xs-3">
                    <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtSSBRefNo" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12 text-center">
                    <asp:Button CssClass="btn btn-primary btn-sm" ID="btnGenerateSSB" runat="server" Text="Generate Form" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>