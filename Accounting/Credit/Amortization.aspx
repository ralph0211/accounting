<%@ Page Language="VB" MasterPageFile="~/Site2.master" AutoEventWireup="false" CodeFile="Amortization.aspx.vb" Inherits="Credit_Amortization" Title="Create Amortization" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="panel panel-primary small">
        <div class="panel-heading">
            <h4 class="panel-title">
                <a>Amortization</a>
            </h4>
        </div>
        <div class="panel-body">
            <div class="row">
                <div class="col-xs-3 control-label">
                    <asp:Label ID="Label1" runat="server" Text="Loan Application ID"></asp:Label>
                </div>
                <div class="col-xs-3">
                    <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtLoanID" runat="server"></asp:TextBox>
                </div>
                <div class="col-xs-1">
                    <asp:Button CssClass="btn btn-primary btn-sm" ID="btnSearchLoanID" runat="server" Text=">>" />
                </div>
            </div>
            <div class="row">
                <div class="col-xs-3 control-label">
                    <asp:Label ID="Label2" runat="server" Text="Search by customer name"></asp:Label>
                </div>
                <div class="col-xs-3">
                    <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtSearchName" runat="server"></asp:TextBox>
                </div>
                <div class="col-xs-1">
                    <asp:Button CssClass="btn btn-primary btn-sm" ID="btnSearchName" runat="server" Text=">>" />
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12 center-block">
                    <asp:ListBox ID="lstLoans" runat="server" Visible="False" AutoPostBack="True" CssClass="col-xs-12"></asp:ListBox>
                </div>
            </div>
            <div class="row alert-info">
                <div class="col-xs-2 control-label">
                    Applicant Name
                </div>
                <div class="col-xs-2 control-label">
                    <asp:Label ID="lblAppName" runat="server" Text=""></asp:Label>
                </div>
                <div class="col-xs-2 control-label">
                    Application Date
                </div>
                <div class="col-xs-2 control-label">
                    <asp:Label ID="lblAppDate" runat="server" Text=""></asp:Label>
                </div>
            </div>
            <div class="row label-info">
                <div class="col-xs-12 control-label">
                    <asp:Label runat="server" Text="Credit Calculation" ID="Label4"></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-3 control-label">
                    <asp:Label ID="lblLoanAmt" runat="server" Text="Loan Amount"></asp:Label>
                </div>
                <div class="col-xs-3">
                    <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtLoanAmt" runat="server" Enabled="false"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-3 control-label">
                    <asp:Label ID="lblRepPer" runat="server" Text="No. of Repayments"></asp:Label>
                </div>
                <div class="col-xs-3">
                    <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtRepayPeriod" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-3 control-label">
                    Repayment Intervals
                </div>
                <div class="col-xs-1">
                    <asp:TextBox CssClass="col-xs-12 form-control input-sm numeric" ID="txtRepaymentInterval" runat="server"></asp:TextBox>
                </div>
                <div class="col-xs-2">
                    <asp:DropDownList CssClass="col-xs-12 form-control input-sm" ID="cmbRepaymentInterval" runat="server">
                        <asp:ListItem Text="" Value=""></asp:ListItem>
                        <asp:ListItem Text="Days" Value="Days"></asp:ListItem>
                        <asp:ListItem Text="Weeks" Value="Weeks"></asp:ListItem>
                        <asp:ListItem Text="Months" Value="Months"></asp:ListItem>
                        <asp:ListItem Text="Years" Value="Years"></asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-3 control-label">
                    <asp:Label ID="Label7436" runat="server" Text="Interest Rate(%)"></asp:Label>
                </div>
                <div class="col-xs-3">
                    <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtIntRate" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-3 control-label">
                    <asp:Label ID="lblAdminRate" runat="server" Text="Product Fees"></asp:Label>
                </div>
                <div class="col-xs-3">
                    <asp:TextBox CssClass="col-xs-12 form-control input-sm numeric" ID="txtAdminCharge" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-3 control-label">
                    <asp:Label ID="Label7438" runat="server" Text="First Payment Date"></asp:Label>
                </div>
                <div class="col-xs-3">
                    <asp:TextBox ID="bdp1stPayDate" runat="server" CssClass="form-control input-sm datepicker"></asp:TextBox>
                    <span class="glyphicon glyphicon-calendar form-control-feedback" style="margin-right: 13px; background-color: #eeeeff; border-radius: 0 3px 3px 0; border: 1px solid rgb(149,188,219); z-index: 0;"></span>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12 text-center">
                    <asp:Button CssClass="btn btn-primary btn-sm" ID="btnSaveCreditParameters" runat="server" UseSubmitBehavior="false"
                        Text="Create Amortization" />
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12 text-center">
                    <asp:Button CssClass="btn btn-primary btn-sm" ID="btnAmortize" runat="server"
                        Text="Create Amortization Schedule" Visible="False" />
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12 text-center">
                    <asp:Label ID="lblViewSchedule" runat="server" Text=""></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12 text-center">
                    <asp:Label ID="lblReturnApproval" runat="server" Text=""></asp:Label>
                </div>
            </div>
            <asp:HiddenField ID="hidDisburseDate" runat="server" />
        </div>
    </div>
    <script type="text/javascript">
        $(function () {
            $("[id*=btnSaveCreditParameters]").bind("click", function () {
                $("[id*=btnSaveCreditParameters]").val("Creating Amortization...");
                $("[id*=btnSaveCreditParameters]").attr("disabled", true);
            });
        });
        $(document).ready(function () {
            $('[id*=rdbRepayWknd] input').click(function () {
                var value = $('[id*=rdbRepayWknd] input:checked').val();
                if (value == 'N') {
                    $("#divRepayWknd").show();
                }
                else if (value == 'Y') {
                    $("#divRepayWknd").hide();
                }
                else {
                    $("#divRepayWknd").hide();
                }
            });
        });

        $(document).ready(function () {
            var value = $('[id*=rdbRepayWknd] input:checked').val();
            if (value == 'N') {
                $("#divRepayWknd").show();
            }
            else if (value == 'Y') {
                $("#divRepayWknd").hide();
            }
            else {
                $("#divRepayWknd").hide();
            }
        });
    </script>
</asp:Content>