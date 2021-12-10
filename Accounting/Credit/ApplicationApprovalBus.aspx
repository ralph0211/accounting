<%@ Page Title="Application Approval" Language="VB" MasterPageFile="~/Site2.master" AutoEventWireup="false" CodeFile="ApplicationApprovalBus.aspx.vb" Inherits="Credit_ApplicationApprovalBus" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="panel panel-primary small">
        <div class="panel-heading">
            <h4 class="panel-title">Loan Application Approval
            </h4>
        </div>
        <div class="panel-body">
            <div class="row">
                <div class="col-xs-2 control-label">
                    <asp:Label ID="Label2" runat="server" Text="Customer Number"></asp:Label>
                </div>
                <div class="col-xs-3">
                    <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" CssClass="col-xs-12 form-control input-sm" ID="txtCustNo" runat="server"></asp:TextBox>
                </div>
                <div class="col-xs-1">
                    <asp:Button CssClass="btn btn-primary btn-sm" ID="btnSearchCustNo" runat="server" Text=">>" Visible="false" />
                </div>
                <div class="col-xs-2 control-label">
                    <asp:Label ID="Label1" runat="server" Text="Client Type"></asp:Label>
                </div>
                <div class="col-xs-4">
                    <asp:DropDownList ReadOnly="True" ForeColor="Black" Font-Bold="true" CssClass="col-xs-12 input-sm form-control" ID="rdbClientType" runat="server" AutoPostBack="True">
                    </asp:DropDownList>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12 center-block">
                    <asp:GridView ID="grdAppHistory" runat="server" HorizontalAlign="center" Caption="Application History">
                        <AlternatingRowStyle CssClass="altrowstyle" />
                        <HeaderStyle CssClass="headerstyle" HorizontalAlign="center" />
                        <RowStyle CssClass="rowstyle" />
                    </asp:GridView>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12 center-block">
                    <div class="row label-info">
                        <div class="col-xs-12 control-label">
                            BUSINESS DETAILS
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-2 control-label">
                            Business Type
                        <asp:Label ID="Labelpo123" runat="server" Text="*" ForeColor="Red" Font-Size="Large"></asp:Label>
                        </div>

                        <div class="col-xs-4">
                            <asp:RadioButtonList ID="rdbCompanyType" runat="server" RepeatDirection="Horizontal" CssClass="col-xs-12">
                                <asp:ListItem Text="Sole Trader" Value="Sole"></asp:ListItem>
                                <asp:ListItem Text="Registered Business" Value="Registered"></asp:ListItem>
                            </asp:RadioButtonList>
                            <asp:RequiredFieldValidator Display="Dynamic" ID="rfvCompType" runat="server" ErrorMessage="Business Type is required" ValidationGroup="valComp" ControlToValidate="rdbCompanyType"></asp:RequiredFieldValidator>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-xs-2 control-label">
                            Registered Name
                        <asp:Label ID="Labelu123" runat="server" Text="*" ForeColor="Red" Font-Size="Large"></asp:Label>
                        </div>
                        <div class="col-xs-4">
                            <asp:TextBox ID="txtRegdName" ReadOnly="True" runat="server" CssClass="form-control input-sm col-xs-12"></asp:TextBox>
                            <asp:RequiredFieldValidator Display="Dynamic" ID="rfvRegdName" runat="server" ErrorMessage="Registered Name is required" ValidationGroup="valComp" ControlToValidate="txtRegdName"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-xs-2 control-label">
                            Trade Name
                        <asp:Label ID="Labelsd123" runat="server" Text="*" ForeColor="Red" Font-Size="Large"></asp:Label>
                        </div>
                        <div class="col-xs-4">
                            <asp:TextBox ID="txtTradeName" ReadOnly="True" runat="server" CssClass="form-control input-sm col-xs-12"></asp:TextBox>
                            <asp:RequiredFieldValidator Display="Dynamic" ID="rfvTradeName" runat="server" ErrorMessage="Trade Name is required" ValidationGroup="valComp" ControlToValidate="txtTradeName"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-2 control-label">
                            Date Business was Registered
                        </div>
                        <div class="col-xs-4">
                            <asp:TextBox ID="txtBusRegdDate" ReadOnly="True" runat="server" CssClass="form-control input-sm nofuturedate"></asp:TextBox>
                            <span class="glyphicon glyphicon-calendar form-control-feedback" style="margin-right: 13px; background-color: #eeeeff; border-radius: 0 3px 3px 0; border: 1px solid rgb(149,188,219);"></span>
                        </div>
                    </div>
                    <div class="row">
                        <div class="control-label col-xs-2">
                            Street/Road
                        </div>
                        <div class="col-xs-4">
                            <asp:TextBox ID="txtRoad" ReadOnly="True" runat="server" CssClass="form-control input-sm col-xs-12"></asp:TextBox>
                        </div>
                        <div class="control-label col-xs-2">
                            City/Town
                        </div>
                        <div class="col-xs-4">
                            <asp:TextBox ID="txtCity" ReadOnly="True" runat="server" CssClass="form-control input-sm col-xs-12" onkeypress="return isTextOnly(event)"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="control-label col-xs-2">
                            P.O. Box
                        </div>
                        <div class="col-xs-4">
                            <asp:TextBox ID="txtBox" ReadOnly="True" runat="server" CssClass="form-control input-sm col-xs-12"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="control-label col-xs-2">
                            Business Tel No.
                        </div>
                        <div class="col-xs-4">
                            <asp:TextBox ID="txtBusinessPhone" ReadOnly="True" runat="server" CssClass="form-control input-sm col-xs-12" onkeypress="return isPhoneNo(event)"></asp:TextBox>
                        </div>
                        <div class="control-label col-xs-2">
                            Business Email Address
                        </div>
                        <div class="col-xs-4">
                            <asp:TextBox ID="txtBusinessEmail" ReadOnly="True" runat="server" CssClass="form-control input-sm col-xs-12"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="valBusinessEmail" runat="server" ControlToValidate="txtBusinessEmail" ValidationExpression="^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z\.][a-zA-Z]{1,3}$" ErrorMessage="Please enter a valid email address"></asp:RegularExpressionValidator>
                        </div>
                    </div>
                    <div class="row">
                        <div class="control-label col-xs-2">
                            Contact Name
                        </div>
                        <div class="col-xs-4">
                            <asp:TextBox ID="txtContactName" ReadOnly="True" runat="server" CssClass="form-control input-sm col-xs-12" onkeypress="return isTextOnly(event)"></asp:TextBox>
                        </div>
                        <div class="control-label col-xs-2">
                            Contact Phone No.
                        </div>
                        <div class="col-xs-4">
                            <asp:TextBox ID="txtContactTel" ReadOnly="True" runat="server" CssClass="form-control input-sm col-xs-12" onkeypress="return isPhoneNo(event)" Style="left: 0px; top: 0px"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="control-label col-xs-2">
                            Contact Email
                        </div>
                        <div class="col-xs-4">
                            <asp:TextBox ID="txtContactEmail" ReadOnly="True" runat="server" CssClass="form-control input-sm col-xs-12"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="valtxtContactEmail" runat="server" ControlToValidate="txtContactEmail" ValidationExpression="^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z\.][a-zA-Z]{1,3}$" ErrorMessage="Please enter a valid email address"></asp:RegularExpressionValidator>
                        </div>
                        <div class="col-xs-6 left">
                        </div>
                    </div>

                    <%--                    ....--%>

                    <div class="row label-info">
                        <div class="col-xs-12 control-label">
                            <asp:Label ID="lblDirectHolding" runat="server" Text="FINANCIAL REQUIREMENTS"></asp:Label>
                        </div>
                    </div>
                    <div class="row hidden">
                        <div class="col-xs-2 control-label">
                            <asp:Label ID="Label55" runat="server" Text="Choose Type"></asp:Label>
                        </div>
                        <div class="col-xs-4">
                            <asp:RadioButtonList ID="rdbType" runat="server" AutoPostBack="true" RepeatDirection="Horizontal" Style="margin-right: 0px; margin-left: 0px;" Width="212px">
                                <asp:ListItem Text="Cash" Value="Cash"></asp:ListItem>
                                <asp:ListItem Text="Asset Financing" Value="Asset Financing"></asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-2 control-label">
                            <asp:Label ID="lblAsset" runat="server" Text="Asset" Visible="false"></asp:Label>
                        </div>
                        <div class="col-xs-4">
                            <asp:DropDownList CssClass="col-xs-12 form-control input-sm" ID="ddlAssets" runat="server" AutoPostBack="true" Visible="false">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-2 control-label">
                            Application Fees Paid
                        </div>
                        <div class="col-xs-4 control-label">
                            <asp:Label ID="lblAppFee" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-2 control-label">
                            <asp:Label ID="lblDHAsAt" runat="server" Text="Amount Required ($)"></asp:Label>
                            <asp:Label ID="Label108" runat="server" Text="*" ForeColor="Red" Font-Size="Large"></asp:Label>
                        </div>
                        <div class="col-xs-4">
                            <asp:TextBox CssClass="col-xs-12 form-control input-sm" ReadOnly="True" ID="txtFinReqAmt" runat="server" onkeypress="return isnumeric(event)"></asp:TextBox>
                            <asp:RequiredFieldValidator Display="Dynamic" ID="rfvFinReqAmt" runat="server" ErrorMessage="Loan Amount is required" ValidationGroup="valIndiv" ControlToValidate="txtFinReqAmt"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-xs-2 control-label">
                            <%--<asp:Label ID="lblDHName" runat="server" Text="Tenure (Days)"></asp:Label>--%>
                                            No. of Repayments
                                            <asp:Label ID="Label109" runat="server" Text="*" ForeColor="Red" Font-Size="Large"></asp:Label>
                        </div>
                        <div class="col-xs-4">
                            <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtFinReqTenor" ReadOnly="True" runat="server" onkeypress="return isnumeric(event)"></asp:TextBox>
                            <asp:RequiredFieldValidator Display="Dynamic" ID="rfvFinReqTenor" runat="server" ErrorMessage="Loan Tenor is required" ValidationGroup="valIndiv" ControlToValidate="txtFinReqTenor"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-2 control-label">
                            <asp:Label ID="Label4347" runat="server" Text="Interest Rate (%)"></asp:Label>
                            <%--<asp:Label ID="Label104" runat="server" Text="*" ForeColor="Red" Font-Size="Large"></asp:Label>--%>
                        </div>
                        <div class="col-xs-4">
                            <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtInterestRate" runat="server" onkeypress="return isnumeric(event)" onkeyup="sum();" Style="left: 0px; top: 0px"></asp:TextBox>
                            <%--<asp:RequiredFieldValidator Display="Dynamic" ID="rfvInterestRate" runat="server" ErrorMessage="Interest Rate is required" ValidationGroup="valIndiv" ControlToValidate="txtInterestRate"></asp:RequiredFieldValidator>--%>
                        </div>
                        <div class="col-xs-2 control-label">
                            <asp:Label ID="lblInsurance" runat="server" Text="Insurance Rate (%)"></asp:Label>
                            <%--<asp:Label ID="Label1105" runat="server" Text="*" ForeColor="Red" Font-Size="Large"></asp:Label>--%>
                        </div>
                        <div class="col-xs-4">
                            <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtInsuranceRate" runat="server" onkeypress="return isnumeric(event)" onkeyup="sum();"></asp:TextBox>
                            <%--<asp:RequiredFieldValidator Display="Dynamic" ID="rfvInsuranceRate" runat="server" ErrorMessage="Insurance Rate is required" ValidationGroup="valIndiv" ControlToValidate="txtInsuranceRate"></asp:RequiredFieldValidator>--%>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-2 control-label">
                            <asp:Label ID="lblAdminRate" runat="server" Text="Admin Fee (%)"></asp:Label>
                            <%--<asp:Label ID="Label105" runat="server" Text="*" ForeColor="Red" Font-Size="Large"></asp:Label>--%>
                        </div>
                        <div class="col-xs-4">
                            <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtAdminRate" runat="server" onkeypress="return isnumeric(event)" onkeyup="sum();"></asp:TextBox>
                            <%--<asp:RequiredFieldValidator Display="Dynamic" ID="rfvAdminRate" runat="server" ErrorMessage="Admin Fee is required" ValidationGroup="valIndiv" ControlToValidate="txtAdminRate"></asp:RequiredFieldValidator>--%>
                        </div>
                        <div class="col-xs-2 control-label hidden">
                            Loan Duration (Days)
                        </div>
                        <div class="col-xs-4 hidden">
                            <asp:TextBox CssClass="col-xs-12 form-control input-sm numeric" ID="txtLoanDuration" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-xs-2 control-label">
                            <asp:Label ID="Label47" runat="server" Text="Total Interest Rate (%)"></asp:Label>
                            <asp:Label ID="Label103" runat="server" Text="*" ForeColor="Red" Font-Size="Large"></asp:Label>
                        </div>
                        <div class="col-xs-4">
                            <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtFinReqIntRate" runat="server" onkeypress="return isnumeric(event)" onkeyup="sum();"></asp:TextBox>
                            <asp:RequiredFieldValidator Display="Dynamic" ID="rfvFinReqIntRate" runat="server" ErrorMessage="Total Interest Rate is required" ValidationGroup="valIndiv" ControlToValidate="txtFinReqIntRate"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-2 control-label">
                            Repayment Intervals
                        </div>
                        <div class="col-xs-2">
                            <asp:TextBox CssClass="col-xs-12 form-control input-sm numeric" ReadOnly="True" ID="txtRepaymentInterval" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-xs-2">
                            <asp:TextBox CssClass="col-xs-12 form-control input-sm numeric" ReadOnly="True" ID="txtRepInts" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-2 control-label">
                            <asp:Label ID="lblDHDIEI" runat="server" Text="Purpose"></asp:Label>
                            <asp:Label ID="Label110" runat="server" Text="*" ForeColor="Red" Font-Size="Large"></asp:Label>
                        </div>
                        <div class="col-xs-4">
                            <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" CssClass="col-xs-12 form-control input-sm" ID="txtPurpose" runat="server"></asp:TextBox>
                        </div>

                        <div class="col-xs-2 control-label">
                            <asp:Label ID="lblDHHoldingPerc" runat="server" Text="Source of Repayment"></asp:Label>
                        </div>
                        <div class="col-xs-4">
                            <asp:TextBox ReadOnly="True" CssClass="col-xs-12 form-control input-sm" ID="txtFinReqSource" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-2 control-label">
                            <asp:Label ID="Label48" runat="server" Text="Security Offered"></asp:Label>
                        </div>
                        <div class="col-xs-4">
                            <asp:TextBox ReadOnly="True" CssClass="col-xs-12 form-control input-sm" ID="txtFinReqSecOffer" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-xs-2 control-label hidden">
                            <asp:Label ID="Label49" runat="server" Text="Bank"></asp:Label>
                        </div>
                        <div class="col-xs-4 hidden">
                            <asp:DropDownList CssClass="col-xs-12 form-control input-sm" ID="cmbFinReqBank" runat="server"
                                AutoPostBack="True">
                            </asp:DropDownList>
                            <asp:TextBox CssClass="col-xs-12 form-control input-sm" ReadOnly="True" ID="txtFinReqBank" runat="server" Visible="False"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-2 control-label">
                            <asp:Label ID="Label28" runat="server" Text="Application Date"></asp:Label>
                        </div>
                        <div class="col-xs-4">
                            <asp:TextBox ID="txtApplicationDate" runat="server" CssClass="col-xs-12 form-control input-sm datepicker" Enabled="false" ReadOnly="true"></asp:TextBox>
                            <span class="glyphicon glyphicon-calendar form-control-feedback" style="margin-right: 13px; background-color: #eeeeff; border-radius: 0 3px 3px 0; border: 1px solid rgb(149,188,219); z-index: 0;"></span>
                        </div>
                        <div class="col-xs-2 control-label">
                            <asp:Label ID="Label59" runat="server" Text="Recommended Disburse Date"></asp:Label>
                        </div>
                        <div class="col-xs-4">
                            <asp:TextBox ID="txtRecommendedDisbDate" runat="server" CssClass="col-xs-12 form-control input-sm datepicker" Enabled="false" ReadOnly="true"></asp:TextBox>
                            <span class="glyphicon glyphicon-calendar form-control-feedback" style="margin-right: 13px; background-color: #eeeeff; border-radius: 0 3px 3px 0; border: 1px solid rgb(149,188,219); z-index: 0;"></span>
                        </div>
                    </div>
                    <div class="row hidden">
                        <div class="col-xs-2 control-label">
                            <asp:Label ID="Label50" runat="server" Text="Branch Name"></asp:Label>
                        </div>
                        <div class="col-xs-4">
                            <asp:DropDownList CssClass="col-xs-12 form-control input-sm" ID="cmbFinReqBranch" runat="server"
                                AutoPostBack="True">
                            </asp:DropDownList>
                            <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtFinReqBranchName" runat="server" Visible="False"></asp:TextBox>
                        </div>
                        <div class="col-xs-2 control-label">
                            <asp:Label ID="Label51" runat="server" Text="Branch Code"></asp:Label>
                        </div>
                        <div class="col-xs-4">
                            <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtFinReqBranchCode" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-2 control-label hidden">
                            <asp:Label ID="Label52" runat="server" Text="A/c Number"></asp:Label>
                        </div>
                        <div class="col-xs-4 hidden">
                            <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtFinReqAccNo" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-xs-2 control-label">
                            <asp:Label ID="Label18" runat="server" Text="1st Repayment Date"></asp:Label>
                        </div>
                        <div class="col-xs-4">
                            <asp:TextBox ID="bdpFinReqRepaymt" runat="server" CssClass="col-xs-12 form-control input-sm datepicker"></asp:TextBox>
                            <span class="glyphicon glyphicon-calendar form-control-feedback" style="margin-right: 13px; background-color: #eeeeff; border-radius: 0 3px 3px 0; border: 1px solid rgb(149,188,219); z-index: 0;"></span>
                        </div>
                        <div class="col-xs-2 control-label">
                            <asp:Label ID="Label90" runat="server" Text="Other Charges"></asp:Label>
                        </div>
                        <div class="col-xs-4">
                            <asp:TextBox CssClass="col-xs-12 form-control input-sm" ReadOnly="True" ID="txtFinReqOtherCharges" runat="server" onkeypress="return isnumeric(event)"></asp:TextBox>
                        </div>
                    </div>

                    <div class="row label-info">
                        <div class="col-xs-12 center-block">
                            <asp:Label ID="Label78" runat="server" Text="Members Expense List (If Applicable)" Font-Bold="True"></asp:Label>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-12 center-block">
                            <asp:GridView ID="grdGrpDeclExpense" runat="server" HorizontalAlign="center">
                                <AlternatingRowStyle CssClass="altrowstyle" />
                                <HeaderStyle CssClass="headerstyle" HorizontalAlign="center" />
                                <RowStyle CssClass="rowstyle" />
                                <Columns>
                                    <asp:CommandField ShowEditButton="True" />
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-2 control-label">
                            <asp:Label ID="Label15" runat="server" Text="Recommended Amount (US$)"></asp:Label>
                        </div>
                        <div class="col-xs-4">
                            <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtRecAmt" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-xs-2 control-label">
                            <asp:Label ID="Label17" runat="server" Text="Comment"></asp:Label>
                        </div>
                        <div class="col-xs-4">
                            <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtComment" runat="server" TextMode="MultiLine"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-2 control-label">
                            <asp:Label ID="lblDisburseDate" runat="server" Text="Disbursement Date" Visible="False"></asp:Label>
                        </div>
                        <div class="col-xs-4">
                            <asp:TextBox CssClass="col-xs-12 form-control input-sm nofuturedate" ID="txtDisburseDate" runat="server" Visible="False"></asp:TextBox>
                            <span class="glyphicon glyphicon-calendar form-control-feedback" style="margin-right: 13px; background-color: #eeeeff; border-radius: 0 3px 3px 0; border: 1px solid rgb(149,188,219);" runat="server" id="disbSpan" visible="false"></span>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-12 text-center">
                            <asp:Button CssClass="btn btn-primary btn-sm" ID="btnGenAgrmt" runat="server" Text="Generate Agreement" Visible="false" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-12 text-center">
                            <asp:HyperLink ID="lnkAmortizationSchedule" runat="server" Target="_blank" Visible="false">View Amortization Schedule</asp:HyperLink>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-12 text-center">
                            <asp:HyperLink ID="lnkViewAppForm" runat="server" Visible="true">Create/Revise Armotization Schedule</asp:HyperLink>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-12 text-center">
                            <asp:Button CssClass="btn btn-success btn-sm" ID="btnGrpSubmitApp" runat="server" Text="Submit" />
                            <asp:Button CssClass="btn btn-danger btn-sm" ID="btnGrpReject" runat="server" Text="Reject" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>