<%@ Page Title="Reprint Receipts" Language="VB" MasterPageFile="~/Site2.master" AutoEventWireup="false" CodeFile="ReprintReceipt.aspx.vb" Inherits="Credit_ReprintReceipt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="panel panel-primary small">
        <div class="panel-heading">
            <h4 class="panel-title">
                <a>Reprint Receipts</a>
            </h4>
        </div>
        <div class="panel-body">
            <div class="row">
                <div class="col-xs-3 control-label">
                    <asp:label id="Label1" runat="server" text="Loan ID"></asp:label>
                </div>
                <div class="col-xs-3">
                    <asp:textbox cssclass="col-xs-12 form-control input-sm" id="txtLoanID" runat="server"></asp:textbox>
                </div>
                <div class="col-xs-1">
                    <asp:button cssclass="btn btn-primary btn-sm" id="btnSearchLoan" runat="server" text=">>"
                        causesvalidation="False" />
                </div>
            </div>
            <div class="row">
                <div class="col-xs-3 control-label">
                    <asp:label id="Label22" runat="server"
                        text="Search by customer name"></asp:label>
                </div>
                <div class="col-xs-3">
                    <asp:textbox cssclass="col-xs-12 form-control input-sm" id="txtSearchName" runat="server"></asp:textbox>
                </div>
                <div class="col-xs-1">
                    <asp:button cssclass="btn btn-primary btn-sm" id="btnSearchName" runat="server" forecolor="#555555" text=">>" />
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12 center-block">
                    <asp:listbox id="lstLoans" runat="server" visible="False" autopostback="True"></asp:listbox>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-3">
                    <asp:label id="lblLoanDetails" runat="server" text="LOAN DETAILS"></asp:label>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-3 control-label">
                    <asp:label id="Label6" runat="server" text="Applicant Name"></asp:label>
                </div>
                <div class="col-xs-3 control-label">
                    <asp:label id="lblApplicantName" runat="server" text=""></asp:label>
                </div>
                <div class="col-xs-3 control-label">
                    <asp:label id="Label7" runat="server" text="Address"></asp:label>
                </div>
                <div class="col-xs-3 control-label">
                    <asp:label id="lblApplAddress" runat="server" text=""></asp:label>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-3 control-label">
                    <asp:label id="Label8" runat="server" text="Loan Amount"></asp:label>
                </div>
                <div class="col-xs-3 control-label">
                    <asp:label id="lblLoanAmount" runat="server" text=""></asp:label>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-3 control-label">
                    <asp:label id="lblPenaltyType" runat="server" text="Penalty Type"></asp:label>
                </div>
                <div class="col-xs-3">
                    <asp:dropdownlist cssclass="col-xs-12 form-control input-sm" id="cmbPenaltyType" runat="server" autopostback="true">
                        <asp:ListItem Text="" Value=""></asp:ListItem>
                        <asp:ListItem Text="Overdue Payment" Value="Overdue"></asp:ListItem>
                        <asp:ListItem Text="Telephone" Value="Telephone"></asp:ListItem>
                        <asp:ListItem Text="Mileage" Value="Mileage"></asp:ListItem>
                        <asp:ListItem Text="Other" Value="Other"></asp:ListItem>
                    </asp:dropdownlist>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12 center-block">
                    <asp:panel id="panPenalty" runat="server" visible="False">
                        <div class="row">
                            <div class="col-xs-3">
                                <asp:Label ID="Label2" runat="server" Text="Calculation Method"></asp:Label>
                            </div>
                            <div class="col-xs-3">
                                <asp:RadioButtonList ID="rdbCalcMethod" runat="server"
                                    RepeatDirection="Horizontal">
                                    <asp:ListItem Text="Percentage" Value="Perc"></asp:ListItem>
                                    <asp:ListItem Text="Amount" Value="Amt"></asp:ListItem>
                                </asp:RadioButtonList>
                            </div>
                            <div class="col-xs-3">
                                <asp:Label ID="lblPenaltyRate" runat="server" Text="Rate"></asp:Label>
                            </div>
                            <div class="col-xs-3">
                                <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtPenaltyRate" runat="server" AutoPostBack="true"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-xs-3">
                                <asp:Label ID="Label4" runat="server" Text="Number of Days"></asp:Label>
                            </div>
                            <div class="col-xs-3">
                                <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtNoDays" runat="server" AutoPostBack="true"></asp:TextBox>
                            </div>
                        </div>
                    </asp:panel>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-3 control-label">
                    <asp:label id="Label5" runat="server"
                        text="Total Penalty"></asp:label>
                </div>
                <div class="col-xs-3">
                    <asp:textbox cssclass="col-xs-12 form-control input-sm" id="txtPenalty" runat="server"></asp:textbox>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-3 control-label">
                    <asp:label id="Label10" runat="server"
                        text="Penalty Date"></asp:label>
                </div>
                <div class="col-xs-3">
                    <asp:textbox cssclass="col-xs-12 form-control input-sm" id="txtPaymentDate" runat="server"></asp:textbox>
                </div>
                <div class="col-xs-3 control-label">
                    <asp:label id="Label11" runat="server"
                        text="Amount Paid" visible="False"></asp:label>
                </div>
                <div class="col-xs-3">
                    <asp:textbox cssclass="col-xs-12 form-control input-sm" id="txtAmountPaid" runat="server" visible="False"></asp:textbox>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-3 control-label">
                    <asp:label id="Label12" runat="server"
                        text="Receipt Number" visible="False"></asp:label>
                </div>
                <div class="col-xs-3">
                    <asp:textbox cssclass="col-xs-12 form-control input-sm" id="txtReceiptNo" runat="server" visible="False"></asp:textbox>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12 center-block">
                    <asp:button cssclass="btn btn-primary btn-sm" id="btnSavePayment" runat="server" text="Save" />
                </div>
            </div>
        </div>
    </div>
    <div id="repayDetails" style="display: none;">
        <div>
            <asp:label id="lblRepayAmt" runat="server" text="Amount:"></asp:label>
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:textbox cssclass="col-xs-12 form-control input-sm" id="txtRepayAmt" runat="server"></asp:textbox>
            <br />
            <p>Date: &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;<asp:textbox cssclass="col-xs-12 form-control input-sm" id="txtRepayDate" runat="server"></asp:textbox></p>

            <br />
            <asp:button cssclass="btn btn-primary btn-sm" id="btnRepay" runat="server" text="Save Payment" />
            <asp:hiddenfield id="hidLoanID" runat="server" />
            <asp:hiddenfield id="hidPaymentNo" runat="server" />
            <asp:hiddenfield id="hidCustNo" runat="server" />
        </div>
    </div>
</asp:Content>