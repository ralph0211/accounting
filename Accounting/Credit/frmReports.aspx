<%@ Page Language="VB" MasterPageFile="~/Site2.master" AutoEventWireup="false" CodeFile="frmReports.aspx.vb" Inherits="Credit_frmReports" Title="Reports - Credit Management System" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="panel panel-primary small">
        <div class="panel-heading">
            <h4 class="panel-title">
                <a>Reports</a>
            </h4>
        </div>
        <div class="panel-body">
            <div class="row">
                <h5 class="col-xs-12 text-uppercase control-label col-xs-3">Credit Reports
                </h5>
                <h5 class="col-xs-12 text-uppercase control-label col-xs-3">Transactional Reports
                </h5>
                <h5 class="col-xs-12 text-uppercase control-label col-xs-3">Operational Reports
                </h5>
                <h5 class="col-xs-12 text-uppercase control-label col-xs-3">Financial Reports
                </h5>
            </div>
            <div class="row">
                <div class="col-xs-3">
                    <asp:HyperLink ID="HyperLink112" runat="server"
                        NavigateUrl="~/Reports/xrptLoanBook.aspx" Target="_blank">Loan Book</asp:HyperLink>
                </div>
                <div class="col-xs-3">
                    <%--<a data-target="#DisbModal" role="button" class="" data-toggle="modal" id="launchDisb">Disbursements Report</a>--%>
                    <asp:HyperLink ID="HyperLinkk12" runat="server"
                        NavigateUrl="~/Reports/xrptDisbursements.aspx" Target="_blank">Disbursements Report</asp:HyperLink>
                </div>
                <div class="col-xs-3">
                    <asp:HyperLink ID="HyperLinnk1112" runat="server"
                        NavigateUrl="~/Reports/xrptBranchSummary.aspx" Target="_blank">Branch Summary Report</asp:HyperLink>
                </div>
                <div class="col-xs-3">
                    <asp:HyperLink ID="HyperLinnk112" runat="server"
                        NavigateUrl="~/Reports/xrptMaturityAnalysis.aspx" Target="_blank">Maturity Analysis Report</asp:HyperLink>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-3">
                    <%--<a data-target="#ArrearsModal" role="button" class="" data-toggle="modal" id="launchArrears">Arrears Report</a>--%>
                    <asp:HyperLink ID="HyperLinnk1d12" runat="server"
                        NavigateUrl="~/Reports/xrptArrears.aspx" Target="_blank">Arrears Report</asp:HyperLink>
                </div>
                <div class="col-xs-3">
                    <asp:HyperLink ID="HyperLink21" runat="server"
                        NavigateUrl="~/Reports/xrptRepayments.aspx" Target="_blank">Repayments Report</asp:HyperLink>
                </div>
                <div class="col-xs-3">
                    <asp:HyperLink ID="HyperLinnk12" runat="server"
                        NavigateUrl="~/Reports/xrptLoanOfficerSummary.aspx" Target="_blank">Loan Officer Summary Report</asp:HyperLink>
                </div>
                <div class="col-xs-3">
                    <a data-target="#MaturityModal" role="button" class="" data-toggle="modal" id="launchMaturity">Maturity Profile</a>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-3">
                    <asp:HyperLink ID="HyperLink2" runat="server"
                        NavigateUrl="~/Credit/rptAging.aspx" Target="_blank" Visible="false">Aging (PAR)</asp:HyperLink>
                    <asp:HyperLink ID="HyperiLink2" runat="server"
                        NavigateUrl="~/Credit/xrptAgingArrearsGroup.aspx" Target="_blank">Grouped Aging of Arrears</asp:HyperLink>
                </div>
                <div class="col-xs-3">
                    <asp:HyperLink ID="HyperfLink2" runat="server"
                        NavigateUrl="~/Reports/xrptInterest.aspx" Target="_blank">Interest Report</asp:HyperLink>
                </div>
                <div class="col-xs-3">
                    <asp:HyperLink ID="HyperdLink2" runat="server"
                        NavigateUrl="~/Reports/xrptLoanMaturity.aspx" Target="_blank">Loan Maturity Report</asp:HyperLink>
                </div>
                <div class="col-xs-3">
                    <asp:HyperLink ID="HyperLink12" runat="server" Target="_blank" NavigateUrl="~/Reports/xrptTopTwenty.aspx">Top Twenty Borrowers Report</asp:HyperLink>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-3">
                    <asp:HyperLink ID="HyperLink6" runat="server" Target="_blank" NavigateUrl="~/Reports/xrptAgingArrears.aspx">Aging of Arrears</asp:HyperLink>
                </div>
                <div class="col-xs-3">
                    <%--<asp:HyperLink ID="HyperLink7" runat="server" Target="_blank" NavigateUrl="~/Reports/xrptDailyDisbursements.aspx">Daily Disbursements</asp:HyperLink>--%>
                </div>
                <div class="col-xs-3">
                    <asp:HyperLink ID="HyperLink31" runat="server" Target="_blank" NavigateUrl="~/Reports/xrptInstalmentsDue.aspx">Instalments Due Report</asp:HyperLink>
                </div>
                <div class="col-xs-3">
                    <asp:HyperLink ID="HyperLink14" runat="server" Target="_blank" NavigateUrl="~/Reports/xrptPortfolioActivity.aspx">Portfolio Activity Report</asp:HyperLink>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-3">
                    <asp:HyperLink ID="HyperLink124" runat="server" Target="_blank" NavigateUrl="~/Reports/xrptLoanGrading.aspx">Loan Grading and Provisions</asp:HyperLink>
                </div>
                <div class="col-xs-3">
                    <a data-target="#InterestModal" role="button" class="" data-toggle="modal" id="launchInterest">Interest and Income Report</a>
                </div>
                <div class="col-xs-3">
                    <asp:HyperLink ID="HyperLink10" runat="server" Target="_blank" NavigateUrl="~/Reports/xrptExpectedRepayments.aspx">Expected Repayments Report</asp:HyperLink>
                </div>
                <div class="col-xs-3">
                    <asp:HyperLink ID="HyperLink15" runat="server" Target="_blank" NavigateUrl="~/Reports/xrptPortfolioQuality.aspx">Portfolio Quality Report</asp:HyperLink>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-3">
                    <asp:HyperLink ID="HyperLink5" runat="server"
                        NavigateUrl="~/Reports/xrptActivePortfolio.aspx" Target="_blank">Active Portfolio Report</asp:HyperLink>
                </div>
                <div class="col-xs-3"></div>
                <div class="col-xs-3">
                    <asp:HyperLink ID="HyperLink4" runat="server" Target="_blank" NavigateUrl="~/Credit/rptOperationIndicator.aspx">Operational Indicators</asp:HyperLink>
                </div>
                <div class="col-xs-3">
                    <asp:HyperLink ID="HyperLink16" runat="server" Target="_blank" NavigateUrl="~/Reports/xrptPortfolioQualitySummary.aspx">Summarized Portfolio Quality Report</asp:HyperLink>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-3">
                    <%--<asp:HyperLink ID="HyperLink9" runat="server" Target="_blank" NavigateUrl="~/Reports/xrptDelinquency.aspx">Delinquency Report</asp:HyperLink>--%>
                    <asp:HyperLink ID="HyperLink8" runat="server"
                        NavigateUrl="~/Reports/xrptLoanAnalysis.aspx" Target="_blank">Loan Statistics Report</asp:HyperLink>
                </div>
                <div class="col-xs-3"></div>
                <div class="col-xs-3">
                    <asp:HyperLink ID="HyperLink3" runat="server" Target="_blank" NavigateUrl="~/Credit/rptOutreach.aspx">Outreach Indicators</asp:HyperLink>
                </div>
            </div>
            <div class="row">
                <h5 class="col-xs-12 text-uppercase control-label col-xs-3">Other Reports
                </h5>
                <div class="col-xs-3"></div>
                <div class="col-xs-3">
                    <asp:HyperLink ID="HyperLink13" runat="server" Target="_blank" NavigateUrl="~/Reports/xrptOutreach.aspx">Outreach Report</asp:HyperLink>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-3">
                    <asp:HyperLink ID="HyperLink11" runat="server" Target="_blank" NavigateUrl="~/Reports/xrptSectorAnalysis.aspx">Sector Analysis Report</asp:HyperLink>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-3">
                    <a data-target="#StatusModal" role="button" class="" data-toggle="modal" id="launchStatus">Loan Status Report</a>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-3">
                    <asp:LinkButton ID="LinkButton7" OnClientClick="return showIndivPopup();"
                        runat="server" Visible="false">Account Statement</asp:LinkButton>
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Accounting/AccountStatement.aspx">Account Statement</asp:HyperLink>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-6">
                    <a data-target="#RBZPackModal" role="button" class="" data-toggle="modal" id="launchRBZPack">RBZ Report Pack</a>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-3">
                    <asp:HyperLink ID="HyperLinkn1" runat="server" NavigateUrl="~/Reports/xrptBlacklist.aspx" Target="_blank">Blacklist Report</asp:HyperLink>
                </div>
            </div>
        </div>
    </div>
    <div id="RBZPackModal" class="modal fade" role="dialog">
        <div class="modal-dialog">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">RBZ Report Pack</h4>
                </div>
                <div class="modal-body panel-body small">
                    <div class="row">
                        <div class="col-xs-3 control-label">
                            <label for="from">
                                From Date
                            </label>
                        </div>
                        <div class="col-xs-6">
                            <asp:TextBox CssClass="col-xs-12 form-control input-sm datepicker" ID="txtRBZFrom" runat="server"></asp:TextBox>
                            <span class="glyphicon glyphicon-calendar form-control-feedback" style="margin-right: 13px; background-color: #eeeeff; border-radius: 0 3px 3px 0; border: 1px solid rgb(149,188,219); z-index: 0;"></span>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-3 control-label">
                            <label for="to">
                                To Date
                            </label>
                        </div>
                        <div class="col-xs-6">
                            <asp:TextBox CssClass="col-xs-12 form-control input-sm datepicker" ID="txtRBZTo" runat="server"></asp:TextBox>
                            <span class="glyphicon glyphicon-calendar form-control-feedback" style="margin-right: 13px; background-color: #eeeeff; border-radius: 0 3px 3px 0; border: 1px solid rgb(149,188,219); z-index: 0;"></span>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-xs-12 text-center">
                            <asp:Button CssClass="btn btn-primary btn-sm" ID="btnPrintRBZPack" runat="server" Text="Download" />
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                </div>
            </div>
        </div>
    </div>
    <div id="MaturityModal" class="modal fade" role="dialog">
        <div class="modal-dialog">

            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">Maturity Profile</h4>
                </div>
                <div class="modal-body panel-body small">
                    <div class="row">
                        <div class="col-xs-3 control-label">
                            <label for="from">
                                From Date
                            </label>
                        </div>
                        <div class="col-xs-6">
                            <asp:TextBox CssClass="col-xs-12 form-control input-sm datepicker" ID="txtFromDate" runat="server"></asp:TextBox>
                            <span class="glyphicon glyphicon-calendar form-control-feedback" style="margin-right: 13px; background-color: #eeeeff; border-radius: 0 3px 3px 0; border: 1px solid rgb(149,188,219); z-index: 0;"></span>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-3 control-label">
                            <label for="to">
                                To Date
                            </label>
                        </div>
                        <div class="col-xs-6">
                            <asp:TextBox CssClass="col-xs-12 form-control input-sm datepicker" ID="txtToDate" runat="server"></asp:TextBox>
                            <span class="glyphicon glyphicon-calendar form-control-feedback" style="margin-right: 13px; background-color: #eeeeff; border-radius: 0 3px 3px 0; border: 1px solid rgb(149,188,219); z-index: 0;"></span>
                        </div>
                    </div>
                    <div id="branch" style="display: none;" class="row">
                        <div class="col-xs-3 control-label">
                            <label for="branchOption">
                                Branch
                            </label>
                        </div>
                        <div class="col-xs-6">
                            <asp:DropDownList CssClass="col-xs-12 form-control input-sm" ID="branchOption" runat="server" AppendDataBoundItems="true">
                                <asp:ListItem Text="All" Value="All"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div id="status" style="display: none;" class="row">
                        <div class="col-xs-3 control-label">
                            <label for="statusOption">
                                Status
                            </label>
                        </div>
                        <div class="col-xs-6">
                            <asp:DropDownList CssClass="col-xs-12 form-control input-sm" ID="statusOption" runat="server"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-12 text-center">
                            <asp:Button CssClass="btn btn-primary btn-sm" ID="btnPrintMaturity" runat="server" Text="Print" />
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                </div>
            </div>
        </div>
    </div>
    <div id="DueModal" class="modal fade" role="dialog">
        <div class="modal-dialog">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">Due Payments Report</h4>
                </div>
                <div class="modal-body panel-body small">
                    <div class="row">
                        <div class="col-xs-3 control-label">
                            <label for="from">
                                From Date
                            </label>
                        </div>
                        <div class="col-xs-6">
                            <asp:TextBox CssClass="col-xs-12 form-control input-sm datepicker" ID="txtDueFromDate" runat="server"></asp:TextBox>
                            <span class="glyphicon glyphicon-calendar form-control-feedback" style="margin-right: 13px; background-color: #eeeeff; border-radius: 0 3px 3px 0; border: 1px solid rgb(149,188,219); z-index: 0;"></span>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-3 control-label">
                            <label for="to">
                                To Date
                            </label>
                        </div>
                        <div class="col-xs-6">
                            <asp:TextBox CssClass="col-xs-12 form-control input-sm datepicker" ID="txtDueToDate" runat="server"></asp:TextBox>
                            <span class="glyphicon glyphicon-calendar form-control-feedback" style="margin-right: 13px; background-color: #eeeeff; border-radius: 0 3px 3px 0; border: 1px solid rgb(149,188,219); z-index: 0;"></span>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-3 control-label">
                            <label for="branchOption">
                                Branch
                            </label>
                        </div>
                        <div class="col-xs-6">
                            <asp:DropDownList CssClass="col-xs-12 form-control input-sm" ID="cmbBranchDue" runat="server" AppendDataBoundItems="true">
                                <asp:ListItem Text="All" Value="All"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-12 text-center">
                            <asp:Button CssClass="btn btn-primary btn-sm" ID="btnPrintDuePayments" runat="server" Text="Print" />
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                </div>
            </div>
        </div>
    </div>
    <div id="ArrearsModal" class="modal fade" role="dialog">
        <div class="modal-dialog">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">Arrears Report</h4>
                </div>
                <div class="modal-body panel-body small">
                    <div class="row">
                        <div class="col-xs-3 control-label">
                            <label for="from">
                                From Date
                            </label>
                        </div>
                        <div class="col-xs-6">
                            <asp:TextBox CssClass="col-xs-12 form-control input-sm datepicker" ID="txtDueArrearFromDate" runat="server"></asp:TextBox>
                            <span class="glyphicon glyphicon-calendar form-control-feedback" style="margin-right: 13px; background-color: #eeeeff; border-radius: 0 3px 3px 0; border: 1px solid rgb(149,188,219); z-index: 0;"></span>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-3 control-label">
                            <label for="to">
                                To Date
                            </label>
                        </div>
                        <div class="col-xs-6">
                            <asp:TextBox CssClass="col-xs-12 form-control input-sm datepicker" ID="txtArrearToDate" runat="server"></asp:TextBox>
                            <span class="glyphicon glyphicon-calendar form-control-feedback" style="margin-right: 13px; background-color: #eeeeff; border-radius: 0 3px 3px 0; border: 1px solid rgb(149,188,219); z-index: 0;"></span>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-3 control-label">
                            <label for="branchOption">
                                Branch
                            </label>
                        </div>
                        <div class="col-xs-6">
                            <asp:DropDownList CssClass="col-xs-12 form-control input-sm" ID="cmbBranchArrear" runat="server" AppendDataBoundItems="true">
                                <asp:ListItem Text="All" Value="All"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-12 text-center">
                            <asp:Button CssClass="btn btn-primary btn-sm" ID="btnPrintArrear" runat="server" Text="Print" />
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                </div>
            </div>
        </div>
    </div>
    <div id="DisbModal" class="modal fade" role="dialog">
        <div class="modal-dialog">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">Disbursements Report</h4>
                </div>
                <div class="modal-body panel-body small">
                    <div class="row">
                        <div class="col-xs-3 control-label">
                            <label for="from">
                                From Date
                            </label>
                        </div>
                        <div class="col-xs-6">
                            <asp:TextBox CssClass="col-xs-12 form-control input-sm datepicker" ID="txtDisbFromDate" runat="server"></asp:TextBox>
                            <span class="glyphicon glyphicon-calendar form-control-feedback" style="margin-right: 13px; background-color: #eeeeff; border-radius: 0 3px 3px 0; border: 1px solid rgb(149,188,219); z-index: 0;"></span>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-3 control-label">
                            <label for="to">
                                To Date
                            </label>
                        </div>
                        <div class="col-xs-6">
                            <asp:TextBox CssClass="col-xs-12 form-control input-sm datepicker" ID="txtDisbToDate" runat="server"></asp:TextBox>
                            <span class="glyphicon glyphicon-calendar form-control-feedback" style="margin-right: 13px; background-color: #eeeeff; border-radius: 0 3px 3px 0; border: 1px solid rgb(149,188,219); z-index: 0;"></span>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-3 control-label">
                            <label for="disburseOption">
                                Option
                            </label>
                        </div>
                        <div class="col-xs-6">
                            <asp:DropDownList ID="cmbDisbOption" runat="server">
                                <%--<asp:ListItem Text="All" Value="All"></asp:ListItem>--%>
                                <asp:ListItem Value="Cash">Cash</asp:ListItem>
                                <asp:ListItem Value="Ecocash">Ecocash</asp:ListItem>
                                <asp:ListItem Value="RTGS">RTGS</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-3 control-label">
                            <label for="branchOption">
                                Branch
                            </label>
                        </div>
                        <div class="col-xs-6">
                            <asp:DropDownList CssClass="col-xs-12 form-control input-sm" ID="cmbBranchDisb" runat="server" AppendDataBoundItems="true">
                                <asp:ListItem Text="All" Value="All"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-12 text-center">
                            <asp:Button CssClass="btn btn-primary btn-sm" ID="btnPrintDisb" runat="server" Text="Print" />
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                </div>
            </div>
        </div>
    </div>
    <div id="BranchModal" class="modal fade" role="dialog">
        <div class="modal-dialog">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">Branch Report</h4>
                </div>
                <div class="modal-body panel-body small">
                    <div class="row">
                        <div class="col-xs-3 control-label">
                            <label for="from">
                                From Date
                            </label>
                        </div>
                        <div class="col-xs-6">
                            <asp:TextBox CssClass="col-xs-12 form-control input-sm datepicker" ID="txtBranchFromDate" runat="server"></asp:TextBox>
                            <span class="glyphicon glyphicon-calendar form-control-feedback" style="margin-right: 13px; background-color: #eeeeff; border-radius: 0 3px 3px 0; border: 1px solid rgb(149,188,219); z-index: 0;"></span>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-3 control-label">
                            <label for="to">
                                To Date
                            </label>
                        </div>
                        <div class="col-xs-6">
                            <asp:TextBox CssClass="col-xs-12 form-control input-sm datepicker" ID="txtBranchToDate" runat="server"></asp:TextBox>
                            <span class="glyphicon glyphicon-calendar form-control-feedback" style="margin-right: 13px; background-color: #eeeeff; border-radius: 0 3px 3px 0; border: 1px solid rgb(149,188,219); z-index: 0;"></span>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-3 control-label">
                            <label for="branchOption">
                                Branch
                            </label>
                        </div>
                        <div class="col-xs-6">
                            <asp:DropDownList CssClass="col-xs-12 form-control input-sm" ID="cmbBranchBranch" runat="server" AppendDataBoundItems="true">
                                <asp:ListItem Text="All" Value="All"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-12 text-center">
                            <asp:Button CssClass="btn btn-primary btn-sm" ID="btnPrintBranch" runat="server" Text="Print" />
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                </div>
            </div>
        </div>
    </div>
    <div id="InterestModal" class="modal fade" role="dialog">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">Interest & Income Report</h4>
                </div>
                <div class="modal-body panel-body small">
                    <div class="row">
                        <div class="col-xs-3 control-label">
                            <label for="from">
                                From Date
                            </label>
                        </div>
                        <div class="col-xs-6">
                            <asp:TextBox CssClass="col-xs-12 form-control input-sm datepicker" ID="txtInterestFromDate" runat="server"></asp:TextBox>
                            <span class="glyphicon glyphicon-calendar form-control-feedback" style="margin-right: 13px; background-color: #eeeeff; border-radius: 0 3px 3px 0; border: 1px solid rgb(149,188,219); z-index: 0;"></span>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-3 control-label">
                            <label for="to">
                                To Date
                            </label>
                        </div>
                        <div class="col-xs-6">
                            <asp:TextBox CssClass="col-xs-12 form-control input-sm datepicker" ID="txtInterestToDate" runat="server"></asp:TextBox>
                            <span class="glyphicon glyphicon-calendar form-control-feedback" style="margin-right: 13px; background-color: #eeeeff; border-radius: 0 3px 3px 0; border: 1px solid rgb(149,188,219); z-index: 0;"></span>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-3 control-label">
                            <label for="branchOption">
                                Branch
                            </label>
                        </div>
                        <div class="col-xs-6">
                            <asp:DropDownList CssClass="col-xs-12 form-control input-sm" ID="cmbInterestBranch" runat="server" AppendDataBoundItems="true">
                                <asp:ListItem Text="All" Value="All"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-12 text-center">
                            <asp:Button CssClass="btn btn-primary btn-sm" ID="btnPrintInterest" runat="server" Text="Print" />
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                </div>
            </div>
        </div>
    </div>
    <div id="StatusModal" class="modal fade" role="dialog">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">Loan Status Report</h4>
                </div>
                <div class="modal-body panel-body small">
                    <div class="row">
                        <div class="col-xs-3 control-label">
                            <label for="from">
                                From Date
                            </label>
                        </div>
                        <div class="col-xs-6">
                            <asp:TextBox CssClass="col-xs-12 form-control input-sm datepicker" ID="txtStatusFromDate" runat="server"></asp:TextBox>
                            <span class="glyphicon glyphicon-calendar form-control-feedback" style="margin-right: 13px; background-color: #eeeeff; border-radius: 0 3px 3px 0; border: 1px solid rgb(149,188,219); z-index: 0;"></span>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-3 control-label">
                            <label for="to">
                                To Date
                            </label>
                        </div>
                        <div class="col-xs-6">
                            <asp:TextBox CssClass="col-xs-12 form-control input-sm datepicker" ID="txtStatusToDate" runat="server"></asp:TextBox>
                            <span class="glyphicon glyphicon-calendar form-control-feedback" style="margin-right: 13px; background-color: #eeeeff; border-radius: 0 3px 3px 0; border: 1px solid rgb(149,188,219); z-index: 0;"></span>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-3 control-label">
                            <label for="branchOption">
                                Branch
                            </label>
                        </div>
                        <div class="col-xs-6">
                            <asp:DropDownList CssClass="col-xs-12 form-control input-sm" ID="cmbStatusBranch" runat="server" AppendDataBoundItems="true">
                                <asp:ListItem Text="All" Value="All"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-3 control-label">
                            <label for="branchOption">
                                Status
                            </label>
                        </div>
                        <div class="col-xs-6">
                            <asp:DropDownList CssClass="col-xs-12 form-control input-sm" ID="cmbStatus" runat="server" AppendDataBoundItems="true">
                                <%--<asp:ListItem Text="All" Value="All"></asp:ListItem>--%>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-12 text-center">
                            <asp:Button CssClass="btn btn-primary btn-sm" ID="btnPrintStatus" runat="server" Text="Print" />
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                </div>
            </div>
        </div>
    </div>
    <div id="modal_dialog" style="display: none">

        <br />
    </div>
    <div id="indiv_dialog" style="display: none;">
        <div class="panel-body">
            <div class="row">
                <div class="col-xs-3 control-label">
                    <asp:Label ID="Label1" runat="server"
                        Text="Loan Application ID"></asp:Label>
                </div>
                <div class="col-xs-3">
                    <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtLoanID" runat="server"></asp:TextBox>
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
                    <asp:ListBox ID="lstLoans" runat="server" Visible="False" AutoPostBack="True"></asp:ListBox>
                </div>
            </div>
        </div>
    </div>
    <%--<script src="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.9/jquery-ui.js" type="text/javascript"></script>
    <link href="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.9/themes/start/jquery-ui.css"
        rel="stylesheet" type="text/css" />--%>
    <script type="text/javascript">
        $('.datepicker').datepicker({
            format: 'dd MM yyyy',
            todayHighlight: true
        });

        $(function () {
            $("[id*=btnSaveCreditParameters]").bind("click", function () {
                $("[id*=btnSaveCreditParameters]").val("Creating Amortization...");
                $("[id*=btnSaveCreditParameters]").attr("disabled", true);
            });
        });

        $('.nofuturedate').datepicker({
            format: 'dd MM yyyy',
            todayHighlight: true,
            endDate: '+0d'
        });
        function showMaturityPopup() {
            $("#disburse").css("display", "none");
            $("#branch").css("display", "block");
            $("#status").css("display", "none");

            $("#modal_dialog").dialog({
                modal: true,
                title: 'Maturity Profile',
                buttons: {
                    "Print": function () {
                        window.open('rptMaturity.aspx?from=' + $("#from").val() + '&to=' + $("#to").val() + '&brnch=' + $("#<%= branchOption.ClientID %>").val() + '');
                    },
                    Cancel: function () {
                        $(this).dialog("close");
                    }
                }
            }).parent().appendTo(jQuery("form:first"));
            return false;
        }
        function showDuePaymtPopup() {
            $("#disburse").css("display", "none");
            $("#branch").css("display", "block");
            $("#status").css("display", "none");
            $("#modal_dialog").dialog({
                modal: true,
                title: 'Due Payments',
                buttons: {
                    "Print": function () {
                        window.open('rptDuePayments.aspx?from=' + $("#from").val() + '&to=' + $("#to").val() + '&brnch=' + $("#<%= branchOption.ClientID %>").val() + '');
                    },
                    Cancel: function () {
                        $(this).dialog("close");
                    }
                }
            }).parent().appendTo(jQuery("form:first"));
            return false;
        }
        function showArrearsPopup() {
            $("#disburse").css("display", "none");
            $("#branch").css("display", "block");
            $("#status").css("display", "none");
            $("#modal_dialog").dialog({
                modal: true,
                title: 'Arrears Report',
                buttons: {
                    "Print": function () {
                        window.open('rptArrears.aspx?from=' + $("#from").val() + '&to=' + $("#to").val() + '&brnch=' + $("#<%= branchOption.ClientID %>").val() + '');
                    },
                    Cancel: function () {
                        $(this).dialog("close");
                    }
                }
            }).parent().appendTo(jQuery("form:first"));
            return false;
        }
        function showDisbursementPopup() {
            $("#branch").css("display", "block");
            $("#disburse").css("display", "block");
            $("#status").css("display", "none");
            $("#modal_dialog").dialog({
                modal: true,
                title: 'Disbursements Report',
                buttons: {
                    "Print": function () {
                        window.open('rptDisbursements.aspx?from=' + $("#from").val() + '&to=' + $("#to").val() + '&disb=' + $("#disburseOption").val() + '&brnch=' + $("#<%= branchOption.ClientID %>").val() + '');
                    },
                    Cancel: function () {
                        $(this).dialog("close");
                    }
                }
            }).parent().appendTo(jQuery("form:first"));
            return false;
        }
        function showBranchPopup() {
            $("#disburse").css("display", "none");
            $("#branch").css("display", "block");
            $("#status").css("display", "none");
            $("#modal_dialog").dialog({
                modal: true,
                title: 'Branch Report',
                buttons: {
                    "Print": function () {
                        window.open('rptBranchReport.aspx?from=' + $("#from").val() + '&to=' + $("#to").val() + '&brnch=' + $("#<%= branchOption.ClientID %>").val() + '');
                    },
                    Cancel: function () {
                        $(this).dialog("close");
                    }
                }
            }).parent().appendTo(jQuery("form:first"));
            return false;
        }
        function showInterestPopup() {

            $("#disburse").css("display", "none");
            $("#branch").css("display", "block");
            $("#status").css("display", "none");

            $("#modal_dialog").dialog({
                modal: true,
                title: 'Interest and Income',
                buttons: {
                    "Print": function () {
                        //window.open('rptInterestIncome.aspx?from=' + $("#from").val() + '&to=' + $("#to").val() + '&brnch=' + $("#<%= branchOption.ClientID %>").val() + '');
                        window.open('rptEarnedInterest.aspx?from=' + $("#from").val() + '&to=' + $("#to").val() + '&brnch=' + $("#<%= branchOption.ClientID %>").val() + '');
                    },
                    Cancel: function () {
                        $(this).dialog("close");
                    }
                }
            }).parent().appendTo(jQuery("form:first"));
            return false;
        }
        function showIndivPopup() {
            $("#indiv_dialog").dialog({
                modal: true,
                title: 'Individual Statement',
                width: 500,
                buttons: {
                    "Print": function () {
                        window.open('rptIndivStmt.aspx?from=' + $("#from").val() + '&to=' + $("#to").val() + '');
                    },
                    Cancel: function () {
                        $(this).dialog("close");
                    }
                }
            }).parent().appendTo(jQuery("form:first"));
            return false;
        }
        function showStatusPopup() {
            $("#disburse").css("display", "none");
            $("#branch").css("display", "block");
            $("#status").css("display", "block");
            $("#modal_dialog").dialog({
                modal: true,
                title: 'Status Report',
                buttons: {
                    "Print": function () {
                        window.open('rptStatusReport.aspx?from=' + $("#from").val() + '&to=' + $("#to").val() + '&brnch=' + $("#<%= branchOption.ClientID %>").val() + '&status=' + $("#<%= statusOption.ClientID %>").val() + '');
                    },
                    Cancel: function () {
                        $(this).dialog("close");
                    }
                }
            }).parent().appendTo(jQuery("form:first"));
            return false;
        }
        $("#ui-datepicker-div").css("z-index", "9999");
    </script>
</asp:Content>