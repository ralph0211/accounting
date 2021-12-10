<%@ Page Title="Static Details Reports" Language="VB" MasterPageFile="~/Site2.master" AutoEventWireup="false" CodeFile="StaticDetailsReports.aspx.vb" Inherits="Reports_StaticDetailsReports" %>

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
                <h5 class="col-xs-12 text-uppercase control-label col-xs-3">Parameters
                </h5>
                <h5 class="col-xs-12 text-uppercase control-label col-xs-3">System Settings
                </h5>
                <h5 class="col-xs-12 text-uppercase control-label col-xs-3">Branches, Roles & Users
                </h5>
                <h5 class="col-xs-12 text-uppercase control-label col-xs-3">Other
                </h5>
            </div>
            <div class="row">
                <div class="col-xs-3">
                    <asp:HyperLink ID="HypserLinkk12" runat="server"
                        NavigateUrl="~/Reports/xrptParaClientTypes.aspx" Target="_blank">Client Types</asp:HyperLink>
                </div>
                <div class="col-xs-3">
                    <asp:HyperLink ID="HyperLink112" runat="server"
                        NavigateUrl="~/Reports/xrptParaInternalControls.aspx" Target="_blank">Internal Controls</asp:HyperLink>
                </div>
                <div class="col-xs-3">
                    <asp:HyperLink ID="HyperLinnk1112" runat="server"
                        NavigateUrl="~/Reports/xrptParaBranches.aspx" Target="_blank">MFI Branches</asp:HyperLink>
                </div>
                <div class="col-xs-3">
                    <asp:HyperLink ID="HyperLinnk11" runat="server"
                        NavigateUrl="~/Reports/xrptParaCustomerDetails.aspx" Target="_blank">Customer Details</asp:HyperLink>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-3">
                    <asp:HyperLink ID="HyperLinkk12" runat="server"
                        NavigateUrl="~/Reports/xrptParaLoanPurpose.aspx" Target="_blank">Loan Purpose</asp:HyperLink>
                </div>
                <div class="col-xs-3">
                    <asp:HyperLink ID="HyperLdink112" runat="server"
                        NavigateUrl="~/Reports/xrptParaWorkingDays.aspx" Target="_blank">Working Days</asp:HyperLink>
                </div>
                <div class="col-xs-3">
                    <asp:HyperLink ID="HypaerLinnk1112" runat="server"
                        NavigateUrl="~/Reports/xrptParaUserRoles.aspx" Target="_blank">User Roles</asp:HyperLink>
                </div>
                <div class="col-xs-3">
                    <asp:HyperLink ID="Hypaennk1112" runat="server"
                        NavigateUrl="~/Reports/xrptParaGroupMembers.aspx" Target="_blank">Group Members</asp:HyperLink>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-3">
                    <asp:HyperLink ID="HypeLinkk12" runat="server"
                        NavigateUrl="~/Reports/xrptParaCreditProducts.aspx" Target="_blank">Credit Products</asp:HyperLink>
                </div>
                <div class="col-xs-3">
                    <asp:HyperLink ID="HyperLdxink112" runat="server"
                        NavigateUrl="~/Reports/xrptParaAnnualHolidays.aspx" Target="_blank">Annual Holidays</asp:HyperLink>
                </div>
                <div class="col-xs-3">
                    <asp:HyperLink ID="HypaerLinn112" runat="server"
                        NavigateUrl="~/Reports/xrptParaMasterUsers.aspx" Target="_blank">System Users</asp:HyperLink>
                </div>
                <div class="col-xs-3">
                </div>
            </div>
            <div class="row">
                <div class="col-xs-3">
                    <asp:HyperLink ID="HypeLifnkk12" runat="server"
                        NavigateUrl="~/Reports/xrptParaCollateralTypes.aspx" Target="_blank">Collateral Types</asp:HyperLink>
                </div>
                <div class="col-xs-3">
                    <%-- <asp:HyperLink ID="Hypedxink112" runat="server"
                        NavigateUrl="~/Reports/xrptParaAnnualHolidays.aspx" Target="_blank">Annual Holidays</asp:HyperLink> --%>
                </div>
                <div class="col-xs-3">
                    <asp:HyperLink ID="HyparLinn112" runat="server"
                        NavigateUrl="~/Reports/xrptParaMasterUsers.aspx" Target="_blank">System Users</asp:HyperLink>
                </div>
                <div class="col-xs-3">
                </div>
            </div>
            <div class="row">
                <div class="col-xs-3">
                    <asp:HyperLink ID="HypeLifnkkh12" runat="server"
                        NavigateUrl="~/Reports/xrptParaBanks.aspx" Target="_blank">Banks</asp:HyperLink>
                </div>
                <div class="col-xs-3">
                    <asp:HyperLink ID="Hypedxink112" runat="server"
                        NavigateUrl="~/Reports/xrptParaApprovalStages.aspx" Target="_blank">Loan Approval Stages</asp:HyperLink>
                </div>
                <div class="col-xs-3">
                </div>
                <div class="col-xs-3">
                </div>
            </div>
            <div class="row">
                <div class="col-xs-3">
                    <asp:HyperLink ID="HypeLifnkh12" runat="server"
                        NavigateUrl="~/Reports/xrptParaBankBranches.aspx" Target="_blank">Bank Branches</asp:HyperLink>
                </div>
                <div class="col-xs-3">
                    <asp:HyperLink ID="Hypekh12" runat="server"
                        NavigateUrl="~/Reports/xrptParaLoanGrades.aspx" Target="_blank">Loan Grades</asp:HyperLink>
                </div>
                <div class="col-xs-3">
                </div>
                <div class="col-xs-3">
                </div>
            </div>
            <div class="row">
                <div class="col-xs-3">
                    <asp:HyperLink ID="HypeLfnkh12" runat="server"
                        NavigateUrl="~/Reports/xrptParaSectors.aspx" Target="_blank">Sectors</asp:HyperLink>
                </div>
                <div class="col-xs-3">
                </div>
                <div class="col-xs-3">
                </div>
                <div class="col-xs-3">
                </div>
            </div>
            <div class="row">
                <div class="col-xs-3">
                    <asp:HyperLink ID="HypeLfnkh12b" runat="server"
                        NavigateUrl="~/Reports/xrptParaProductTypes.aspx" Target="_blank">Product Types</asp:HyperLink>
                </div>
                <div class="col-xs-3">
                </div>
                <div class="col-xs-3">
                </div>
                <div class="col-xs-3">
                </div>
            </div>
        </div>
    </div>
</asp:Content>