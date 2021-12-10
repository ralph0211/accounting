<%@ Page Title="Print Agreement Letters" Language="VB" MasterPageFile="~/Site2.master" AutoEventWireup="false" CodeFile="AgreementLetters.aspx.vb" Inherits="Credit_AgreementLetters" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="panel panel-primary small">
        <div class="panel-heading">
            <h4 class="panel-title">
                <a>Generate Letter of Agreement</a>
            </h4>
        </div>
        <div class="panel-body">
            <div class="row">
                <div class="col-xs-3 control-label">
                    <asp:Label ID="Label1" runat="server"
                        Text="Loan Application ID"></asp:Label>
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
                    <asp:Label ID="Label2" runat="server"
                        Text="Search by customer name"></asp:Label>
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
            <div class="row">
                <div class="col-xs-12 center-block">
                    <asp:Panel ID="panCreditCalc" runat="server">
                        <div class="row">
                            <div class="col-xs-12 text-center">
                                <asp:Repeater ID="repAgreements" runat="server">
                                    <ItemTemplate>
                                        <asp:HyperLink ID="lnkRepAgreement" Text='<%#Eval("lnkText") %>' NavigateUrl='<%#Eval("navURL") %>' runat="server" Target="_blank"></asp:HyperLink>
                                        <br />
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                        </div>
                    </asp:Panel>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12 text-center">
                    <asp:Button CssClass="btn btn-primary btn-sm" ID="btnAmortize" runat="server" Text="Create Amortization Schedule" Visible="False" />
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
        </div>
    </div>
    <a data-target="#AmortModal" role="button" class="btn" data-toggle="modal" id="launchAmortization" style="height: 0;"></a>
    <div>
        <div id="modal_dialog" style="display: none">
        </div>
    </div>
    <div id="AmortModal" class="modal fade" role="dialog">
        <div class="modal-dialog">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">Loan Amortization</h4>
                </div>
                <div class="modal-body panel-body small">

                    <div class="row">
                        <div class="col-xs-3 control-label">
                            <asp:Label ID="lblLoanAmt" runat="server" Text="Loan Amount"></asp:Label>
                        </div>
                        <div class="col-xs-9">
                            <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtLoanAmt" runat="server" Enabled="false"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-3 control-label">
                            <asp:Label ID="lblRepPer" runat="server" Text="No. of Repayments"></asp:Label>
                        </div>
                        <div class="col-xs-9">
                            <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtRepayPeriod" runat="server" Enabled="false"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-3 control-label">
                            Repayment Intervals
                        </div>
                        <div class="col-xs-3">
                            <asp:TextBox CssClass="col-xs-12 form-control input-sm numeric" ID="txtRepaymentInterval" runat="server" Enabled="false"></asp:TextBox>
                        </div>
                        <div class="col-xs-6">
                            <asp:DropDownList CssClass="col-xs-12 form-control input-sm" ID="cmbRepaymentInterval" runat="server" Enabled="false">
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
                        <div class="col-xs-9">
                            <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtIntRate" runat="server" Enabled="false"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-3 control-label">
                            <asp:Label ID="lblAdminRate" runat="server" Text="Product Fees"></asp:Label>
                        </div>
                        <div class="col-xs-9">
                            <asp:TextBox CssClass="col-xs-12 form-control input-sm numeric" ID="txtAdminCharge" runat="server" Enabled="false"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-3 control-label">
                            <asp:Label ID="Label7438" runat="server" Text="First Payment Date"></asp:Label>
                        </div>
                        <div class="col-xs-9">
                            <asp:TextBox ID="bdp1stPayDate" runat="server" CssClass="form-control input-sm datepicker" Enabled="false"></asp:TextBox>
                            <span class="glyphicon glyphicon-calendar form-control-feedback" style="margin-right: 13px; background-color: #eeeeff; border-radius: 0 3px 3px 0; border: 1px solid rgb(149,188,219); z-index: 0;"></span>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-12 text-center">
                            <asp:Button CssClass="btn btn-primary btn-sm" ID="btnSaveCreditParameters" runat="server" UseSubmitBehavior="false"
                                Text="Create Amortization" />
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        function showAmortization() {
            $("#launchAmortization").click();
        };
        function amortizationSuccess() {
            var n = noty({
                layout: 'top',
                theme: 'defaultTheme',
                type: 'success',
                text: 'Loan successfully amortized!',
                timeout: 5000
            });
        };
        function amortizationError() {
            var n = noty({
                layout: 'top',
                theme: 'defaultTheme',
                type: 'error',
                text: 'There was an error with the amortization. Try again!',
                timeout: 5000
            });
        };
        function isLoanOfficer() {
            var n = noty({
                layout: 'top',
                theme: 'defaultTheme',
                type: 'error',
                text: 'You cannot print agreement letters while logged in as loan officer!',
                timeout: 5000
            });
        };

        $(function () {
            $("[id*=btnSaveCreditParameters]").bind("click", function () {
                $("[id*=btnSaveCreditParameters]").val("Creating Amortization...");
                $("[id*=btnSaveCreditParameters]").attr("disabled", true);
            });
        });
    </script>
</asp:Content>