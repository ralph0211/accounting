<%@ Page Title="Business Loan Application Form" Language="VB" MasterPageFile="~/Site2.master" AutoEventWireup="false" CodeFile="Application.aspx.vb" Inherits="Capital_Application" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="panel panel-primary small">
        <div class="panel-heading">
            <h4 class="panel-title">Business Loan Application Form
            </h4>
        </div>
        <div id="collapse-one" class="panel-collapse collapse in">
            <div class="panel-body">
                <div class="row">
                    <div class="col-xs-1 control-label">
                        <asp:Label ID="Label12" runat="server" Text="Branch"></asp:Label>
                    </div>
                    <div class="col-xs-6 control-label left">
                        <asp:Label ID="lblBranchCode" runat="server" Text=""></asp:Label>
                        <asp:Label ID="Label28" runat="server" Text="  "></asp:Label>
                        <asp:Label ID="lblBranchName" runat="server" Text=""></asp:Label>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="Label92" runat="server" Text="Search Business Name"></asp:Label>
                    </div>
                    <div class="col-xs-6">
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtSearchSurname" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-xs-1">
                        <asp:Button CssClass="btn btn-primary btn-sm" ID="btnSearchSurname" runat="server" Text=">>" />
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-12 center-block">
                        <asp:ListBox ID="lstSurname" runat="server" AutoPostBack="True" Visible="False" CssClass="col-xs-12"></asp:ListBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="lblIDNo" runat="server" Text="Business Registration Number"></asp:Label>
                        <asp:Label ID="Label123" runat="server" Text="*" ForeColor="Red" Font-Size="Large"></asp:Label>
                    </div>
                    <div class="col-xs-3">
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtIDNo" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator Display="Dynamic" ID="rfvIDNo" runat="server" ErrorMessage="Business Registration Number is required" ValidationGroup="valIndiv" ControlToValidate="txtIDNo"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-xs-1">
                        <asp:Button CssClass="btn btn-primary btn-sm" ID="btnIDNo" runat="server" Text=">>" />
                    </div>
                    <div class="col-xs-1 left">
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="Label2" runat="server" Text="Customer Number"></asp:Label>
                    </div>
                    <div class="col-xs-3">
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtCustNo" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-xs-1">
                        <asp:Button CssClass="btn btn-primary btn-sm" ID="btnSearchCustNo" runat="server" Text=">>" />
                    </div>
                    <div class="col-xs-2 control-label hidden">
                        <asp:Label ID="Label1" runat="server" Text="Client Type"></asp:Label>
                    </div>
                    <div class="col-xs-4 hidden">
                        <asp:DropDownList CssClass="col-xs-12 form-control input-sm" ID="rdbClientType" runat="server" AutoPostBack="True" Enabled="False">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="Label8" runat="server" Text="Application Date"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox ID="txtAppDate" runat="server" CssClass="form-control input-sm nofuturedate"></asp:TextBox>
                        <span class="glyphicon glyphicon-calendar form-control-feedback" style="margin-right: 13px; background-color: #eeeeff; border-radius: 0 3px 3px 0; border: 1px solid rgb(149,188,219);"></span>
                    </div>
                </div>
                <div class="row alert-info">
                    <div class="col-xs-12 control-label">
                        <asp:Label ID="lblCurrExposure" runat="server" Text=""></asp:Label>
                    </div>
                </div>
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
                        <asp:TextBox ID="txtRegdName" runat="server" CssClass="form-control input-sm col-xs-12"></asp:TextBox>
                        <asp:RequiredFieldValidator Display="Dynamic" ID="rfvRegdName" runat="server" ErrorMessage="Registered Name is required" ValidationGroup="valComp" ControlToValidate="txtRegdName"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-xs-2 control-label">
                        Trade Name
                        <asp:Label ID="Labelsd123" runat="server" Text="*" ForeColor="Red" Font-Size="Large"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox ID="txtTradeName" runat="server" CssClass="form-control input-sm col-xs-12"></asp:TextBox>
                        <asp:RequiredFieldValidator Display="Dynamic" ID="rfvTradeName" runat="server" ErrorMessage="Trade Name is required" ValidationGroup="valComp" ControlToValidate="txtTradeName"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-2 control-label">
                        Date Business was Registered
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox ID="txtBusRegdDate" runat="server" CssClass="form-control input-sm nofuturedate"></asp:TextBox>
                        <span class="glyphicon glyphicon-calendar form-control-feedback" style="margin-right: 13px; background-color: #eeeeff; border-radius: 0 3px 3px 0; border: 1px solid rgb(149,188,219);"></span>
                    </div>
                </div>
                <div class="row">
                    <div class="control-label col-xs-2">
                        Street/Road
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox ID="txtRoad" runat="server" CssClass="form-control input-sm col-xs-12"></asp:TextBox>
                    </div>
                    <div class="control-label col-xs-2">
                        City/Town
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox ID="txtCity" runat="server" CssClass="form-control input-sm col-xs-12" onkeypress="return isTextOnly(event)"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="control-label col-xs-2">
                        P.O. Box
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox ID="txtBox" runat="server" CssClass="form-control input-sm col-xs-12"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="control-label col-xs-2">
                        Business Tel No.
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox ID="txtBusinessPhone" runat="server" CssClass="form-control input-sm col-xs-12" onkeypress="return isPhoneNo(event)"></asp:TextBox>
                    </div>
                    <div class="control-label col-xs-2">
                        Business Email Address
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox ID="txtBusinessEmail" runat="server" CssClass="form-control input-sm col-xs-12"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="valBusinessEmail" runat="server" ControlToValidate="txtBusinessEmail" ValidationExpression="^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z\.][a-zA-Z]{1,3}$" ErrorMessage="Please enter a valid email address"></asp:RegularExpressionValidator>
                    </div>
                </div>
                <div class="row">
                    <div class="control-label col-xs-2">
                        Contact Name
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox ID="txtContactName" runat="server" CssClass="form-control input-sm col-xs-12" onkeypress="return isTextOnly(event)"></asp:TextBox>
                    </div>
                    <div class="control-label col-xs-2">
                        Contact Phone No.
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox ID="txtContactTel" runat="server" CssClass="form-control input-sm col-xs-12" onkeypress="return isPhoneNo(event)"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="control-label col-xs-2">
                        Contact Email
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox ID="txtContactEmail" runat="server" CssClass="form-control input-sm col-xs-12"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="valtxtContactEmail" runat="server" ControlToValidate="txtContactEmail" ValidationExpression="^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z\.][a-zA-Z]{1,3}$" ErrorMessage="Please enter a valid email address"></asp:RegularExpressionValidator>
                    </div>
                    <div class="col-xs-6 left">
                    </div>
                </div>
                <div class="row label-info">
                    <div class="col-xs-12 control-label">
                        Director Details
                    </div>
                </div>
                <div id="divSoleTraderDirector">
                    <div class="row">
                        <div class="col-xs-2 control-label">
                            Name
                        </div>
                        <div class="col-xs-4">
                            <asp:TextBox ID="txtDirectorName" runat="server" CssClass="form-control input-sm col-xs-12"></asp:TextBox>
                        </div>
                        <div class="col-xs-2 control-label">
                            Gender
                        </div>
                        <div class="col-xs-4">
                            <asp:RadioButtonList ID="rdbDirectorGender" runat="server" RepeatDirection="Horizontal" CssClass="col-xs-12">
                                <asp:ListItem Text="Male" Value="M"></asp:ListItem>
                                <asp:ListItem Text="Female" Value="F"></asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-2 control-label">
                            ID Number
                        </div>
                        <div class="col-xs-4">
                            <asp:TextBox ID="txtDirectorIDNumber" runat="server" CssClass="form-control input-sm col-xs-12"></asp:TextBox>
                        </div>
                        <div class="col-xs-2 control-label">
                            Date of Birth
                        </div>
                        <div class="col-xs-4">
                            <asp:TextBox ID="txtDirectorDOB" runat="server" CssClass="form-control input-sm col-xs-12 dob"></asp:TextBox>
                            <span class="glyphicon glyphicon-calendar form-control-feedback" style="margin-right: 13px; background-color: #eeeeff; border-radius: 0 3px 3px 0; border: 1px solid rgb(149,188,219);"></span>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-2 control-label">
                            Telephone Number
                        </div>
                        <div class="col-xs-4">
                            <asp:TextBox ID="txtDirectorPhone" runat="server" CssClass="form-control input-sm col-xs-12 phone"></asp:TextBox>
                        </div>
                        <div class="col-xs-2 control-label">
                            Email Address
                        </div>
                        <div class="col-xs-4">
                            <asp:TextBox ID="txtDirectorEmail" runat="server" CssClass="form-control input-sm col-xs-12"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-2 control-label">
                            Residential Address
                        </div>
                        <div class="col-xs-4">
                            <asp:TextBox ID="txtDirectorResAddress" runat="server" CssClass="form-control input-sm col-xs-12" TextMode="MultiLine"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div id="divRegisteredDirector">
                    <div class="row">
                        <div class="col-xs-12">
                            <asp:GridView ID="grdDirector" runat="server" HorizontalAlign="Center" AllowPaging="true" SelectedRowStyle-Font-Bold="true">
                                <AlternatingRowStyle CssClass="altrowstyle" />
                                <HeaderStyle CssClass="headerstyle" HorizontalAlign="center" />
                                <RowStyle CssClass="rowstyle" />
                                <PagerStyle CssClass="pagination-ys" />
                                <Columns>
                                    <asp:CommandField ShowSelectButton="True" />
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-3 text-center">
                        <asp:Button ID="btnPrint" runat="server" Text="Print Assignment" Visible="false" CssClass="btn btn-primary btn-sm btn-disable" UseSubmitBehavior="false" />
                    </div>
                </div>
                <div class="row label-info">
                    <div class="col-xs-12 control-label">
                        <asp:Label ID="lblDirectHolding" runat="server" Text="Financial Requirements"></asp:Label>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-2 control-label">
                        Loan Cycle
                    </div>
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="lblLoanCycle" runat="server" Text="0"></asp:Label>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="Label55" runat="server" Text="Product Type"></asp:Label>
                        <asp:Label ID="Label104" runat="server" Text="*" ForeColor="Red" Font-Size="Large"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:DropDownList CssClass="col-xs-12 form-control input-sm" ID="cmbProductType" runat="server" AutoPostBack="true"></asp:DropDownList>
                        <asp:RequiredFieldValidator Display="Dynamic" ID="rfvProductType" runat="server" ErrorMessage="Product type is required" ValidationGroup="valIndiv" ControlToValidate="cmbProductType"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="lblDHAsAt" runat="server" Text="Amount Required ($)"></asp:Label>
                        <asp:Label ID="Label108" runat="server" Text="*" ForeColor="Red" Font-Size="Large"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm numeric" ID="txtFinReqAmt" runat="server" onchange="validateInput();"></asp:TextBox>
                        <asp:HiddenField ID="hidMaxExposure" runat="server" />
                        <asp:HiddenField ID="hidCurrentExposure" runat="server" />
                        <asp:HiddenField ID="hidMaxLoanAmount" runat="server" />
                        <asp:HiddenField ID="hidMinLoanAmount" runat="server" />
                        <asp:Label ID="lblExposureExceeded" runat="server" Text="" ForeColor="red"></asp:Label>
                        <asp:RequiredFieldValidator Display="Dynamic" ID="rfvFinReqAmt" runat="server" ErrorMessage="Loan Amount is required" ValidationGroup="valIndiv" ControlToValidate="txtFinReqAmt"></asp:RequiredFieldValidator>
                        <%--<asp:RangeValidator Display="Dynamic" ID="rvFinReqAmt" runat="server" ErrorMessage="Amount required is out of range for this product" ValidationGroup="valIndiv" ControlToValidate="txtFinReqAmt"></asp:RangeValidator>--%>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-12 control-label text-right pull-right">
                        <asp:Label ID="lblValAmount" runat="server" Text="" ForeColor="red"></asp:Label>
                    </div>
                </div>
                <div class="row hidden">
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="Label47" runat="server" Text="Choose Type"></asp:Label>
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
                        <%--<asp:Label ID="lblDHName" runat="server" Text="Tenor (Months)"></asp:Label>--%>
                                            No. of Repayments (Tenure)
                                            <asp:Label ID="Label109" runat="server" Text="*" ForeColor="Red" Font-Size="Large"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm numeric" ID="txtFinReqTenor" runat="server" onchange="validateInput();"></asp:TextBox>
                        <asp:Label ID="lblTenure" runat="server" Text="" ForeColor="red"></asp:Label>
                        <asp:RequiredFieldValidator Display="Dynamic" ID="rfvFinReqTenor" runat="server" ErrorMessage="Loan Tenor is required" ValidationGroup="valIndiv" ControlToValidate="txtFinReqTenor"></asp:RequiredFieldValidator>
                        <asp:HiddenField ID="hidMaxTenure" runat="server" />
                        <asp:HiddenField ID="hidMinTenure" runat="server" />
                    </div>
                    <div class="col-xs-2 control-label">
                        Repayment Intervals
                    </div>
                    <div class="col-xs-2">
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
                    <div class="col-xs-12 control-label">
                        <asp:Label ID="lblValTenure" runat="server" Text="" ForeColor="red"></asp:Label>
                    </div>
                </div>
                <div class="row hidden">
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="Label4347" runat="server" Text="Interest Rate (%)"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtInterestRate" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="lblInsurance" runat="server" Text="Insurance Rate (%)"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm numeric" ID="txtInsuranceRate" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="lblAdminRate" runat="server" Text="Application Fees (%)"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm numeric" ID="txtAdminRate" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="lblInterestRate" runat="server" Text="Interest Rate (%)"></asp:Label>
                        <asp:Label ID="Label103" runat="server" Text="*" ForeColor="Red" Font-Size="Large"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm numeric" ID="txtFinReqIntRate" runat="server" onchange="validateInput();"></asp:TextBox><%--onkeyup="sum();"--%>
                        <asp:RequiredFieldValidator Display="Dynamic" ID="rfvFinReqIntRate" runat="server" ErrorMessage="Interest Rate is required" ValidationGroup="valIndiv" ControlToValidate="txtFinReqIntRate"></asp:RequiredFieldValidator>
                        <%--<asp:RangeValidator Display="Dynamic" ID="rvFinReqIntRate" runat="server" ErrorMessage="Interest rate is out of range for this product" ValidationGroup="valIndiv" ControlToValidate="txtFinReqIntRate"></asp:RangeValidator>--%>
                        <asp:HiddenField ID="hidMaxInterest" runat="server" />
                        <asp:HiddenField ID="hidMinInterest" runat="server" />
                        <asp:Label ID="lblInterestError" runat="server" Text="" ForeColor="red"></asp:Label>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-12 control-label text-right pull-right">
                        <asp:Label ID="lblValInterest" runat="server" Text="" ForeColor="red"></asp:Label>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="lblDHDIEI" runat="server" Text="Purpose"></asp:Label>
                        <asp:Label ID="Label110" runat="server" Text="*" ForeColor="Red" Font-Size="Large"></asp:Label>
                    </div>
                    <div class="col-xs-3">
                        <asp:DropDownList CssClass="col-xs-12 form-control input-sm" ID="cmbFinReqPurpose" runat="server">
                        </asp:DropDownList>
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtFinReqPurpose" runat="server" Visible="False"></asp:TextBox>
                        <asp:RequiredFieldValidator Display="Dynamic" ID="rfvFinReqPurpose" runat="server" ErrorMessage="Loan purpose is required" ValidationGroup="valIndiv" ControlToValidate="cmbFinReqPurpose"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-xs-1 left">
                        <button type="button" class="btn btn-info btn-sm" data-toggle="modal" data-target="#LoanPurposeModal">Add</button>
                    </div>
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="lblDHHoldingPerc" runat="server" Text="Source of Repayment"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtFinReqSource" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="row hidden">
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="Label48" runat="server" Text="Security Offered"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtFinReqSecOffer" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="Label49" runat="server" Text="Bank"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:DropDownList CssClass="col-xs-12 form-control input-sm" ID="cmbFinReqBank" runat="server"
                            AutoPostBack="True">
                        </asp:DropDownList>
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtFinReqBank" runat="server" Visible="False"></asp:TextBox>
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
                </div>
                <div class="row hidden">
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="Label17" runat="server" Text="Disbursement Option"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:RadioButtonList ID="rdbFinReqDisburseOption" runat="server" RepeatDirection="Horizontal" AutoPostBack="True" CssClass="col-xs-12 text-center">
                            <asp:ListItem Text="Cash" Value="Cash"></asp:ListItem>
                            <asp:ListItem Text="Ecocash" Value="Ecocash"></asp:ListItem>
                            <asp:ListItem Text="RTGS" Value="RTGS"></asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="lblEcocashNumber" runat="server" Text="Ecocash Number" Visible="False"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtEcocashNumber" runat="server" Visible="False"></asp:TextBox>
                    </div>
                </div>
                <div class="row hidden">
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="Label90" runat="server" Text="Other Charges"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtFinReqOtherCharges" runat="server" onkeypress="return isnumeric(event)"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="Label95" runat="server" Text="Comment"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtComment" runat="server" TextMode="MultiLine"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-12 text-center">
                        <asp:Label ID="lblExposureExceededSubmit" runat="server" Text="" ForeColor="red"></asp:Label>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-12 text-center">
                        <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-primary btn-disable" Text="Submit" UseSubmitBehavior="false" ValidationGroup="submit" />
                    </div>
                </div>
            </div>
            <a data-target="#SubmitModal" role="button" class="btn" data-toggle="modal" id="launchSubmit" style="height: 0;"></a>
        </div>
        <asp:HiddenField ID="TabName" runat="server" />
        <asp:Label ID="hfCustomerId" runat="server" />
        <div id="SubmitModal" class="modal fade" role="dialog">
            <div class="modal-dialog">
                <!-- Modal content-->
                <div class="modal-content">
                    <div class="modal-header">
                        <%--<button type="button" class="close" data-dismiss="modal">&times;</button>--%>
                        <h4 class="modal-title">Loan Submission Successful</h4>
                    </div>
                    <div class="modal-body panel-body small">
                        <h5>The loan application has been submitted successfully with a Loan ID of <b><%= lblTest.Text %></b>.<br />
                            You can now &nbsp;
                        <a href="Amortization.aspx?ID=<%= lblTestEnc.Text %>">Create Armotization Schedule</a>.</h5>
                    </div>
                    <div class="modal-footer">
                        <%--<button type="button" class="btn btn-default" data-dismiss="modal">Close</button>--%>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div id="LoanPurposeModal" class="modal fade" role="dialog">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">Add Loan Purpose</h4>
                </div>
                <div class="modal-body panel-body">
                    <div class="row">
                        <div class="col-xs-2 control-label">
                            <asp:Label ID="Label106" runat="server" Text="Purpose"></asp:Label>
                        </div>
                        <div class="col-xs-8">
                            <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtPurpose" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator Display="Dynamic" ID="reqPurpose" runat="server" ErrorMessage="Purpose is required" Font-Bold="true" ForeColor="Red" ControlToValidate="txtPurpose" ValidationGroup="valPurpose"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-xs-1">
                            <asp:Button CssClass="btn btn-primary btn-sm" ID="btnAddPurpose" runat="server" Text="Add" ValidationGroup="valPurpose" />
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                </div>
            </div>
        </div>
    </div>
    <asp:Label ID="lblTest" runat="server" Text=""></asp:Label>
    <asp:Label ID="lblTestEnc" runat="server" Text=""></asp:Label>
    <script type="text/javascript" src="http://cdn.ucb.org.br/Scripts/formValidator/js/languages/jquery.validationEngine-en.js" charset="utf-8"></script>
    <script type="text/javascript" src="http://cdn.ucb.org.br/Scripts/formValidator/js/jquery.validationEngine.js" charset="utf-8"></script>
    <script type="text/javascript">
        $('.datepicker').datepicker({
            format: 'dd MM yyyy',
            todayHighlight: true
        });

        $('.nofuturedate').datepicker({
            format: 'dd MM yyyy',
            todayHighlight: true,
            endDate: '+0d'
        });

        function showPopup() {
            $("#launchSubmit").click();
        }

        $(function () {
            $("#form1").validationEngine('attach', { promptPosition: "topRight" });
        });

        $(function () {
            $('.btn-disable').bind("click", function () {
                //$("[id*=btnDisburse]").val("Updating...");
                $('.btn-disable').attr("disabled", true);
            });
        });
        var config = {
            '.chosen-select': {},
            '.chosen-select-deselect': { allow_single_deselect: true },
            '.chosen-select-no-single': { disable_search_threshold: 10 },
            '.chosen-select-no-results': { no_results_text: 'Oops, nothing found!' },
            '.chosen-select-width': { width: "95%" }
        }
        for (var selector in config) {
            $(selector).chosen(config[selector]);
        };

        $(function () {
            var tabName = $("[id*=TabName]").val() != "" ? $("[id*=TabName]").val() : "personal";
            $('#Tabs a[href="#' + tabName + '"]').tab('show');
            $("#Tabs a").click(function () {
                $("[id*=TabName]").val($(this).attr("href").replace("#", ""));
            });
        });

        $(function () {
            var value = $('#<%= rdbCompanyType.ClientID%> input:checked').val();
            if (value == 'Sole') {
                $("#divSoleTraderDirector").show();
                $("#divRegisteredDirector").hide();
            } else {
                $("#divSoleTraderDirector").hide();
                $("#divRegisteredDirector").show();
            }
        });

            $(function () {
                $('#<%= rdbCompanyType.ClientID%>').change(
            function () {
                var value = $('#<%= rdbCompanyType.ClientID%> input:checked').val();
                if (value == 'Sole') {
                    $("#divSoleTraderDirector").show();
                    $("#divRegisteredDirector").hide();
                } else {
                    $("#divSoleTraderDirector").hide();
                    $("#divRegisteredDirector").show();
                }
            });
            });

            function fnOnUpdateValidators() {
                for (var i = 0; i < Page_Validators.length; i++) {
                    var val = Page_Validators[i];
                    var ctrl = document.getElementById(val.controltovalidate);
                    if (ctrl != null && ctrl.style != null) {
                        if (!val.isvalid)
                            //ctrl.style.background = '#FFAAAA';
                            ctrl.style.borderColor = '#FF0000';
                        else
                            //ctrl.style.backgroundColor = '';
                            ctrl.style.borderColor = '';
                    }
                }
            }

            $(function () {
                $('[data-toggle=tooltip]').popover();
                $('[rel=tooltip]').popover();
            });

            function sum() {
                var txtFirstNumberValue = $("[id*=txtInterestRate]").val();
                var txtSecondNumberValue = $("[id*=txtInsuranceRate]").val();
                var txtThirdNumberValue = $("[id*=txtAdminRate]").val();
                var txtFourthNumberValue = $("[id*=txtFinReqIntRate]").val();
                if (txtFirstNumberValue == "")
                    txtFirstNumberValue = 0;
                if (txtSecondNumberValue == "")
                    txtSecondNumberValue = 0;
                if (txtThirdNumberValue == "")
                    txtThirdNumberValue = 0;
                if (txtFourthNumberValue == "")
                    txtFourthNumberValue = 0;

                var result = parseFloat(txtFirstNumberValue) + parseFloat(txtSecondNumberValue) + parseFloat(txtThirdNumberValue);
                if (!isNaN(result)) {
                    $("[id*=txtFinReqIntRate]").val(result);
                }
            };

            function tenure() {
                if ($("#<%= cmbProductType.ClientID%>").val() == '') {
                    notify('Select the product type', 'error');
                    $("#<%= txtFinReqTenor.ClientID%>").val('') = '';
                } else {
                    var tenor = $("#<%= txtFinReqTenor.ClientID%>").val();
                    var maxTenor = $("#<%= hidMaxTenure.ClientID%>").val();
                    var minTenor = $("#<%= hidMinTenure.ClientID%>").val();

                    if (parseFloat(tenor) > parseFloat(maxTenor) || parseFloat(tenor) < parseFloat(minTenor)) {
                        $("#<%= lblTenure.ClientID%>").text('Entered tenure out of range for this product');
                        $("#<%= lblExposureExceededSubmit.ClientID%>").text('Application cannot be submitted because the entered tenure is out of the allowed range for selected product');
                        $("#<%= btnSubmit.ClientID%>").attr("disabled", true);
                    } else {
                        $("#<%= lblTenure.ClientID%>").text('');
                        $("#<%= lblExposureExceededSubmit.ClientID%>").text('');
                        $("#<%= btnSubmit.ClientID%>").attr("disabled", false);
                    }
                }
            }

            function interest() {
                if ($("#<%= cmbProductType.ClientID%>").val() == '') {
                    notify('Select the product type', 'error');
                    $("#<%= txtFinReqIntRate.ClientID%>").val('') = '';
            } else {
                var intr = $("#<%= txtFinReqIntRate.ClientID%>").val();
                    var maxInt = $("#<%= hidMaxInterest.ClientID%>").val();
                    var minInt = $("#<%= hidMinInterest.ClientID%>").val();

                    if (parseFloat(intr) > parseFloat(maxInt) || parseFloat(intr) < parseFloat(minInt)) {
                        $("#<%= lblInterestError.ClientID%>").text('Entered interest rate out of range for this product');
                    $("#<%= lblExposureExceededSubmit.ClientID%>").text('Application cannot be submitted because the entered interest rate is out of the allowed range for selected product');
                    $("#<%= btnSubmit.ClientID%>").attr("disabled", true);
                } else {
                    $("#<%= lblInterestError.ClientID%>").text('');
                    $("#<%= lblExposureExceededSubmit.ClientID%>").text('');
                    $("#<%= btnSubmit.ClientID%>").attr("disabled", false);
                }
            }
        }

        function exposure() {
            if ($("#<%= cmbProductType.ClientID%>").val() == '') {
                notify('Select the product type', 'error');
                $("#<%= txtFinReqAmt.ClientID%>").val('') = '';
            } else {
                var amt = $("#<%= txtFinreqamt.Clientid%>").val();
                var maxExp = $("#<%= hidMaxExposure.ClientID%>").val();
                var currExp = $("#<%= hidCurrentExposure.ClientID%>").val();

                var maxAmt = $("#<%= hidMaxLoanAmount.ClientID%>").val();
                var minAmt = $("#<%= hidMinLoanAmount.ClientID%>").val();

                var res = parseFloat(amt) + parseFloat(currExp);
                if (parseFloat(amt) > parseFloat(maxAmt) || parseFloat(amt) < parseFloat(minAmt)) {
                    $("#<%= lblExposureExceeded.ClientID%>").text('Entered amount out of range for this product');
                    $("#<%= lblExposureExceededSubmit.ClientID%>").text('Application cannot be submitted because the required amount is out of the allowed range for product');
                    $("#<%= btnSubmit.ClientID%>").attr("disabled", true);
                } else {
<%--                $("#<%= lblExposureExceeded.ClientID%>").text('');
                $("#<%= lblExposureExceededSubmit.ClientID%>").text('');
                $("#<%= btnSubmit.ClientID%>").attr("disabled", false);--%>
                    if (parseFloat(res) > parseFloat(maxExp)) {
                        $("#<%= lblExposureExceeded.ClientID%>").text('Entered value will exceed maximum exposure');
                        $("#<%= lblExposureExceededSubmit.ClientID%>").text('Application cannot be submitted because the required amount will exceed maximum exposure');
                        $("#<%= btnSubmit.ClientID%>").attr("disabled", true);
                    } else {
                        $("#<%= lblExposureExceeded.ClientID%>").text('');
                        $("#<%= lblExposureExceededSubmit.ClientID%>").text('');
                        $("#<%= btnSubmit.ClientID%>").attr("disabled", false);
                    }
                }
            }
        }

        function validateInput() {
            exposure();
            tenure();
            interest();
        }
    </script>
</asp:Content>