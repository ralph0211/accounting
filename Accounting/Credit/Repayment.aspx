<%@ Page Title="Loan Repayment" Language="VB" MasterPageFile="~/Site2.master" AutoEventWireup="false" CodeFile="Repayment.aspx.vb" Inherits="Credit_Repayment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <article>
        <div class="panel panel-primary">
            <div class="panel-heading">
                Loan Repayment
            </div>
            <div class="panel-body small">
                <div class="row">
                    <div class="col-md-2 col-xs-2 control-label">
                        Loan Application ID
                    </div>
                    <div class="col-xs-3">
                        <asp:TextBox ID="txtLoanID" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                    </div>
                    <div class="col-xs-1">
                        <asp:Button ID="btnSearchVCAID" runat="server" CssClass="btn btn-primary btn-sm" Text=">>" causesvalidation="false" />
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-2 col-xs-2 control-label">
                        Customer Number
                    </div>
                    <div class="col-xs-3">
                        <asp:TextBox ID="txtCustNo" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                    </div>
                    <div class="col-xs-1">
                        <asp:Button ID="btnSearchCustNo" runat="server" CssClass="btn btn-primary btn-sm" Text=">>" causesvalidation="false" />
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-2 col-xs-2 control-label">
                        Applicant Name
                    </div>
                    <div class="col-xs-6">
                        <asp:TextBox ID="txtApplicantName" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                    </div>
                    <div class="col-xs-1">
                        <asp:Button ID="btnSearchName" runat="server" CssClass="btn btn-primary btn-sm" Text=">>" causesvalidation="false" />
                    </div>
                </div>
                <div class="row center-block">
                    <asp:ListBox ID="lstLoans" runat="server" AutoPostBack="true" Visible="false" CssClass="col-xs-12"></asp:ListBox>
                </div>
                <div class="row">
                </div>
                <div id="loanDets" runat="server" visible="false">
                    <div class="row small col-xs-12" style="text-align: left;">
                        <h4 class="label-info left col-xs-3">Loan Details</h4>
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
                            Tenure (months):
                        </div>
                        <div class="control-label col-xs-2">
                            <asp:Label ID="lblTenure" runat="server" Text=""></asp:Label>
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
                            First Repayment Due Date:
                        </div>
                        <div class="control-label col-xs-2">
                            <asp:Label ID="lblRepayDate" runat="server" Text=""></asp:Label>
                        </div>
                        <div class="control-label col-xs-2">
                            Last Repayment Date:
                        </div>
                        <div class="control-label col-xs-2">
                            <asp:Label ID="lblLastRepayDate" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                    <div class="row">
                        <div class="control-label col-xs-2">
                            Amortized Interest to Maturity:
                        </div>
                        <div class="control-label col-xs-2">
                            <asp:Label ID="lblInterestAmount" runat="server" Text=""></asp:Label>
                        </div>
                        <div class="control-label col-xs-2 hidden">
                            Upfront Interest:
                        </div>
                        <div class="control-label col-xs-2 hidden">
                            <asp:Label ID="lblInterestUpfront" runat="server" Text=""></asp:Label>
                        </div>
                        <div class="control-label col-xs-2">
                            Net Amount Disbursed:
                        </div>
                        <div class="control-label col-xs-2">
                            <asp:Label ID="lblNetAmount" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                </div>
                <div id="divAmortization" runat="server">
                    <div class="row">
                        <asp:GridView ID="grdAmortization" runat="server" HorizontalAlign="center" Caption="Amortization Schedule" CaptionAlign="Top" EmptyDataText="No Amortization Schedule Created">
                            <AlternatingRowStyle CssClass="altrowstyle" />
                            <HeaderStyle CssClass="headerstyle" HorizontalAlign="center" />
                            <RowStyle CssClass="rowstyle" />
                        </asp:GridView>
                    </div>
                </div>
                <div style="height: 15px;"></div>
                <div id="prevRepayments" runat="server">
                    <div class="row">
                        <asp:GridView ID="grdRepaymentHistory" runat="server" HorizontalAlign="center" Caption="Previous Repayments" CaptionAlign="Top" EmptyDataText="No repayments have been made">
                            <AlternatingRowStyle CssClass="altrowstyle" />
                            <HeaderStyle CssClass="headerstyle" HorizontalAlign="center" />
                            <RowStyle CssClass="rowstyle" />
                        </asp:GridView>
                    </div>
                </div>
                <div style="height: 15px;"></div>
                <div class="row alert-info">
                    <div class="col-xs-4 control-label">
                        <span class="glyphicon glyphicon-info-sign info"></span>
                        Total Capital Repayment: &nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="lblTotalCapitalRepayment" runat="server" Text=""></asp:Label>
                    </div>
                    <div class="col-xs-4 control-label">
                        <span class="glyphicon glyphicon-info-sign info"></span>
                        Current Loan Balance: &nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="lblCurrentLoanBalance" runat="server" Text=""></asp:Label>
                    </div>
                    <div class="col-xs-4 control-label">
                        <span class="glyphicon glyphicon-info-sign info"></span>
                        Current Interest Balance: &nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="lblCurrentInterestBalance" runat="server" Text=""></asp:Label>
                    </div>
                </div>
                <div style="height: 15px;"></div>
                <div class="row alert-info">
                    <div class="col-xs-4 control-label">
                        <span class="glyphicon glyphicon-info-sign info"></span>
                        Capital Repayment Due: &nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="lblCapitalRepaymentDue" runat="server" Text=""></asp:Label>
                    </div>
                    <div class="col-xs-4 control-label">
                        <span class="glyphicon glyphicon-info-sign info"></span>
                        Interest Repayment Due: &nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="lblInterestRepaymentDue" runat="server" Text=""></asp:Label>
                    </div>
                    <div class="col-xs-4 control-label">
                        <span class="glyphicon glyphicon-info-sign info"></span>
                        Penalty Charges Accrued: &nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="lblPenaltyChargesAccrued" runat="server" Text=""></asp:Label>
                    </div>
                </div>
                <div style="height: 15px;"></div>
                <div class="row alert-info">
                    <div class="col-xs-4 control-label hidden">
                        <span class="glyphicon glyphicon-info-sign info"></span>
                        Early Repayment Deduction: &nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="lblEarlyRepaymentDeduction" runat="server" Text=""></asp:Label>
                    </div>
                    <div class="col-xs-4 control-label">
                        <span class="glyphicon glyphicon-info-sign info"></span>
                        Total Repayment Due: &nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="lblTotalRepaymentDue" runat="server" Text=""></asp:Label>
                    </div>
                </div>
                <div class="row small col-xs-12" style="text-align: left;">
                    <h4 class="label-info left col-xs-3">Repayment Details</h4>
                </div>
                <div class="row">
                    <div class="col-xs-2 control-label">
                        Receipt Number
                    <asp:Label ID="Label123" runat="server" Text="*" ForeColor="Red" Font-Size="Large"></asp:Label>
                    </div>
                    <div class="col-xs-2">
                        <asp:TextBox ID="txtReceiptNumber" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                    <asp:RequiredFieldValidator Display="Dynamic" ID="rfvIDNo" runat="server" ErrorMessage="Receipt Number is required" ValidationGroup="valRepay" ControlToValidate="txtReceiptNumber"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="row">
                    <div class="control-label col-xs-2">
                        Repayment Date
                    <asp:Label ID="Label23" runat="server" Text="*" ForeColor="Red" Font-Size="Large"></asp:Label>
                    </div>
                    <div class="form-group col-xs-2">
                        <asp:TextBox ID="txtRepaymentDate" runat="server" CssClass="form-control input-sm nofuturedate"></asp:TextBox>
                        <span class="glyphicon glyphicon-calendar form-control-feedback" style="margin-right: 13px; background-color: #eeeeff; border-radius: 0 3px 3px 0; border: 1px solid rgb(149,188,219); z-index: 0;"></span>
                    <asp:RequiredFieldValidator Display="Dynamic" ID="rfvRepDate" runat="server" ErrorMessage="Repayment Date is required" ValidationGroup="valRepay" ControlToValidate="txtRepaymentDate"></asp:RequiredFieldValidator>
                    </div>
                    <div class="control-label col-xs-2">
                        Total Amount Paid
                    <asp:Label ID="Label3" runat="server" Text="*" ForeColor="Red" Font-Size="Large"></asp:Label>
                    </div>
                    <div class="form-group col-xs-2">
                        <asp:TextBox ID="txtAmtPaid" runat="server" CssClass="form-control input-sm numeric" AutoPostBack="true"></asp:TextBox>
                    <asp:RequiredFieldValidator Display="Dynamic" ID="rfvAmtPaid" runat="server" ErrorMessage="Total Amount Paid is required" ValidationGroup="valRepay" ControlToValidate="txtAmtPaid"></asp:RequiredFieldValidator>
                    </div>
                    <div class="control-label col-xs-2">
                        Early Payment Deduction
                    </div>
                    <div class="form-group col-xs-2">
                        <asp:TextBox ID="txtEarlyPayment" runat="server" CssClass="form-control input-sm numeric"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="control-label col-xs-2">
                        Capital Amount
                    </div>
                    <div class="form-group col-xs-2">
                        <asp:TextBox ID="txtCapital" runat="server" CssClass="form-control input-sm numeric"></asp:TextBox>
                    </div>
                    <div class="control-label col-xs-2">
                        Interest Amount
                    </div>
                    <div class="form-group col-xs-2">
                        <asp:TextBox ID="txtInterest" runat="server" CssClass="form-control input-sm numeric"></asp:TextBox>
                    </div>
                    <div class="control-label col-xs-2">
                        Penalty Charges
                    </div>
                    <div class="form-group col-xs-2">
                        <asp:TextBox ID="txtPenalty" runat="server" CssClass="form-control input-sm numeric"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-2 control-label">
                        Repayment Account
                    <asp:Label ID="Label1" runat="server" Text="*" ForeColor="Red" Font-Size="Large"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:DropDownList ID="cmbCapitalAccount" runat="server" CssClass="form-control input-sm chosen"></asp:DropDownList>
                    <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator1" runat="server" ErrorMessage="Repayment Account is required" ValidationGroup="valRepay" ControlToValidate="cmbCapitalAccount"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-xs-2 control-label hidden">
                        Interest Account
                    </div>
                    <div class="col-xs-4 hidden">
                        <asp:DropDownList ID="cmbInterestAccount" runat="server" CssClass="form-control input-sm chosen"></asp:DropDownList>
                    </div>
                </div>
                <div class="row hidden">
                    <div class="col-xs-2 control-label">
                        Penalty Account
                    </div>
                    <div class="col-xs-4">
                        <asp:DropDownList ID="cmbPenaltyAccount" runat="server" CssClass="form-control input-sm chosen"></asp:DropDownList>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-12 text-center">
                        <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary btn-sm save-btn" Text="Save Payment" UseSubmitBehavior="false" validationgroup="valRepay" />
                    </div>
                </div>
            </div>
        </div>
    </article>
    <script type="text/javascript">

        $("[id*=txtRepaymentDate]").on('changeDate', function (ev) {
            //alert($("[id*=txtRepaymentDate]").val());
            //var firstDate = new Date($("[id*=lblRepayDate]").val());
            //var disbYear = firstDate.getFullYear();
            //var disbMonth = firstDate.getMonth();
            //var disbDate = firstDate.getDate();
            //var today = new Date();
            ////var repayDate = new Date(disbYear, disbMonth+1, disbDate);
            ////$("[id*=txt1stRepayDate]").datepicker('setDate', new Date(repayDate));
            //var tenure = $("[id*=txtTenure]").val();
            //var mat = Number(tenure);
            //var matDate = new Date(disbYear, disbMonth + mat, disbDate);
            //matDate = avoidWeekend(matDate)
            //$("[id*=txtMaturityDate]").datepicker('setDate', new Date(matDate));
        });

        //$("[id*=txtDisbursementDate]").on('changeDate', function (ev) {
        //    //alert($("[id*=txtDisbursementDate]").val());
        //    var disbFullDate = new Date($("[id*=txtDisbursementDate]").val());
        //    var disbYear = disbFullDate.getFullYear();
        //    var disbMonth = disbFullDate.getMonth();
        //    var disbDate = disbFullDate.getDate();
        //    //var repayDate = new Date(disbYear, disbMonth+1, disbDate);
        //    //$("[id*=txt1stRepayDate]").datepicker('setDate', new Date(repayDate));
        //    var tenure = $("[id*=txtTenure]").val();
        //    var mat = Number(tenure);
        //    var matDate = new Date(disbYear, disbMonth + mat, disbDate);
        //    matDate = avoidWeekend(matDate)
        //    $("[id*=txtMaturityDate]").datepicker('setDate', new Date(matDate));
        //});
    </script>
</asp:Content>