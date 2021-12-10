<%@ Page Title="Penalties" Language="VB" MasterPageFile="~/Site2.master" AutoEventWireup="false" CodeFile="Penalties.aspx.vb" Inherits="Credit_Penalties" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        $(function () {
            $("#<%= txtRepayDate.ClientID %>").datepicker({ dateFormat: 'd MM yy' }).val();
            $("#<%= txtRepayDate.ClientID %>").datepicker("setDate", new Date());
            $("#<%= txtPaymentDate.ClientID %>").datepicker({ dateFormat: 'd MM yy' }).val();
        });
        function showRepaymentPopup() {
            $("#repayDetails").dialog({
                title: "Capture Repayment",
                buttons: {
                    Cancel: function () {
                        $(this).dialog('close');
                    }
                },
                modal: true,
                width: 380,
                innerHeight: 400
            });
            $("#repayDetails").parent().appendTo(jQuery("form:first"));
            return false;
        }
    </script>
    <style type="text/css">
        div.ui-datepicker {
            font-size: 12px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="panel panel-primary small">
        <div class="panel-heading">
            <h4 class="panel-title">
                <a>Penalties</a>
            </h4>
        </div>
        <div class="panel-body">
            <div class="row">
                <div class="col-xs-3 control-label">
                    <asp:Label ID="Label1" runat="server" Text="Loan ID"></asp:Label>
                </div>
                <div class="col-xs-3">
                    <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtLoanID" runat="server"></asp:TextBox>
                </div>
                <div class="col-xs-1">
                    <asp:Button CssClass="btn btn-primary btn-sm" ID="btnSearchLoan" runat="server" Text=">>"
                        CausesValidation="False" />
                </div>
            </div>
            <div class="row">
                <div class="col-xs-3 control-label">
                    <asp:Label ID="Label22" runat="server"
                        Text="Search by customer name"></asp:Label>
                </div>
                <div class="col-xs-3">
                    <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtSearchName" runat="server"></asp:TextBox>
                    <asp:Button CssClass="btn btn-primary btn-sm" ID="btnSearchName" runat="server"
                        Text=">>" />
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12 center-block">
                    <asp:ListBox ID="lstLoans" runat="server" Visible="False" AutoPostBack="True"></asp:ListBox>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-3 control-label">
                    <asp:Label ID="lblLoanDetails" runat="server" Text="LOAN DETAILS"></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-3 control-label">
                    <asp:Label ID="Label6" runat="server" Text="Applicant Name"></asp:Label>
                </div>
                <div class="col-xs-3 control-label">
                    <asp:Label ID="lblApplicantName" runat="server" Text=""></asp:Label>
                </div>
                <div class="col-xs-3 control-label">
                    <asp:Label ID="Label7" runat="server" Text="Address"></asp:Label>
                </div>
                <div class="col-xs-3 control-label">
                    <asp:Label ID="lblApplAddress" runat="server" Text=""></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-3 control-label">
                    <asp:Label ID="Label8" runat="server" Text="Loan Amount"></asp:Label>
                </div>
                <div class="col-xs-3 control-label">
                    <asp:Label ID="lblLoanAmount" runat="server" Text=""></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-3 control-label">
                    <asp:Label ID="lblPenaltyType" runat="server"
                        Text="Penalty Type"></asp:Label>
                </div>
                <div class="col-xs-3">
                    <asp:DropDownList CssClass="col-xs-12 form-control input-sm" ID="cmbPenaltyType" runat="server" AutoPostBack="true">
                        <asp:ListItem Text="" Value=""></asp:ListItem>
                        <asp:ListItem Text="Overdue Payment" Value="Overdue"></asp:ListItem>
                        <asp:ListItem Text="Telephone" Value="Telephone"></asp:ListItem>
                        <asp:ListItem Text="Mileage" Value="Mileage"></asp:ListItem>
                        <asp:ListItem Text="Other" Value="Other"></asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12 center-block">
                    <asp:Panel ID="panPenalty" runat="server" Visible="False">
                        <div class="row">
                            <div class="col-xs-3 control-label">
                                <asp:Label ID="Label2" runat="server"
                                    Text="Calculation Method"></asp:Label>
                            </div>
                            <div class="col-xs-3 control-label">
                                <asp:RadioButtonList ID="rdbCalcMethod" runat="server"
                                    RepeatDirection="Horizontal">
                                    <asp:ListItem Text="Percentage" Value="Perc"></asp:ListItem>
                                    <asp:ListItem Text="Amount" Value="Amt"></asp:ListItem>
                                </asp:RadioButtonList>
                            </div>
                            <div class="col-xs-3 control-label">
                                <asp:Label ID="lblPenaltyRate" runat="server"
                                    Text="Rate"></asp:Label>
                            </div>
                            <div class="col-xs-3 control-label">
                                <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtPenaltyRate" runat="server" OnTextChanged="txtPenaltyRate_TextChanged" AutoPostBack="true"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-xs-3 control-label">
                                <asp:Label ID="Label4" runat="server"
                                    Text="Number of Days"></asp:Label>
                            </div>
                            <div class="col-xs-3 control-label">
                                <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtNoDays" runat="server" OnTextChanged="txtNoDays_TextChanged" AutoPostBack="true"></asp:TextBox>
                            </div>
                        </div>
                    </asp:Panel>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-3 control-label">
                    <asp:Label ID="Label5" runat="server"
                        Text="Total Penalty"></asp:Label>
                </div>
                <div class="col-xs-3">
                    <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtPenalty" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-3 control-label">
                    <asp:Label ID="Label10" runat="server"
                        Text="Penalty Date"></asp:Label>
                </div>
                <div class="col-xs-3">
                    <%--<bdp:basicdatepicker ID="bdpPaymentDate" runat="server" DateFormat="d"
                    Visible="False">
                </bdp:basicdatepicker>--%>
                    <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtPaymentDate" runat="server"></asp:TextBox>
                </div>
                <div class="col-xs-3 control-label">
                    <asp:Label ID="Label11" runat="server"
                        Text="Amount Paid" Visible="False"></asp:Label>
                </div>
                <div class="col-xs-3">
                    <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtAmountPaid" runat="server" Visible="False"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-3 control-label">
                    <asp:Label ID="Label12" runat="server"
                        Text="Receipt Number" Visible="False"></asp:Label>
                </div>
                <div class="col-xs-3">
                    <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtReceiptNo" runat="server" Visible="False"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12 text-center">
                    <asp:Button CssClass="btn btn-primary btn-sm" ID="btnSavePayment" runat="server" Text="Save" />
                </div>
            </div>
        </div>
    </div>
    <div id="repayDetails" style="display: none;">
        <div>
            <asp:Label ID="lblRepayAmt" runat="server" Text="Amount:"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtRepayAmt" runat="server"></asp:TextBox>
            <br />
            <p>Date: &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtRepayDate" runat="server"></asp:TextBox></p>

            <br />
            <asp:Button CssClass="btn btn-primary btn-sm" ID="btnRepay" runat="server" Text="Save Payment" />
            <asp:HiddenField ID="hidLoanID" runat="server" />
            <asp:HiddenField ID="hidPaymentNo" runat="server" />
            <asp:HiddenField ID="hidCustNo" runat="server" />
        </div>
    </div>
</asp:Content>