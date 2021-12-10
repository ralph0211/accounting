<%@ Page Title="Loan Enquiry - Credit Management System" Language="VB" EnableEventValidation="false" MasterPageFile="~/Site2.master" AutoEventWireup="false" CodeFile="Enquiry.aspx.vb" Inherits="Credit_Enquiry" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .sectionHeading {
            background-color: #023E7F;
            color: #FFF;
            font-weight: bold;
            padding-left: 10px;
            padding-right: 10px;
        }

        .labelling {
            color: #555555;
            font-family: Calibri;
            padding-left: 10px;
            padding-right: 10px;
            width: 76px;
        }

        .navButton {
            background-color: Navy;
            color: #FFF;
            font-family: Calibri;
            padding-left: 10px;
            padding-right: 10px;
        }

        .disabledNavButton {
            background-color: Silver;
            color: #FFF;
            font-family: Calibri;
            padding-left: 10px;
            padding-right: 10px;
        }

        .activeView {
            background-color: navy;
            color: White;
            font-family: Calibri;
            font-weight: bolder;
        }

        .inactiveView {
            background-color: Silver;
            color: #FFF;
            font-family: Calibri;
        }

        div.ui-datepicker {
            font-size: 8px;
        }
    </style>
    <script type="text/javascript">
        $(document).ready(function () {
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);

            function EndRequestHandler(sender, args) {
                $(function () {
                    <%--$("#<%= txtSearchFromDate.ClientID%>").datepicker({
                        defaultDate: "+1w",
                        dateFormat: 'd MM yy',
                        changeMonth: true,
                        numberOfMonths: 3,
                        onClose: function (selectedDate) {
                            $("#<%= txtSearchToDate.ClientID%>").datepicker("option", "minDate", selectedDate);
                        }
                    });
                    $("#<%= txtSearchToDate.ClientID%>").datepicker({
                        defaultDate: "+1w",
                        dateFormat: 'd MM yy',
                        changeMonth: true,
                        numberOfMonths: 3,
                        onClose: function (selectedDate) {
                            $("#<%= txtSearchFromDate.ClientID %>").datepicker("option", "maxDate", selectedDate);
                        }
                    });--%>
                });
                $('.nofuturedate').datepicker({
                    format: 'dd MM yyyy',
                    todayHighlight: true,
                    endDate: '+0d'
                });
            }

        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="panel panel-primary small">
        <div class="panel-heading">
            <h4 class="panel-title">
                <a>Loan Enquiry</a>
            </h4>
        </div>
        <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <div class="panel-body">
                    <div class="row">
                        <div class="col-xs-12 label-info control-label">
                            <asp:Label ID="Label3" runat="server" Text="Select the search fields to use for searching"></asp:Label>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-2 control-label">
                            <asp:CheckBox ID="chkBranch" Text="Branch" AutoPostBack="true" runat="server" />
                        </div>
                        <div class="col-xs-2">
                            <asp:DropDownList CssClass="col-xs-12 form-control input-sm" ID="cmbSearchBranch" runat="server" Visible="false" AppendDataBoundItems="True" Width="120px" AutoPostBack="True"></asp:DropDownList>
                        </div>
                        <div class="col-xs-2 control-label">
                            <asp:CheckBox ID="chkLoanOfficer" runat="server" Text="Loan Officer" AutoPostBack="true" />
                        </div>
                        <div class="col-xs-2">
                            <asp:DropDownList CssClass="col-xs-12 form-control input-sm" ID="cmbSearchLoanOfficer" runat="server" Visible="false" AppendDataBoundItems="True" Width="120px"></asp:DropDownList>
                        </div>
                        <div class="col-xs-2 control-label">
                            <asp:CheckBox ID="chkLoanStatus" runat="server" Text="Status" AutoPostBack="true" />
                        </div>
                        <div class="col-xs-2">
                            <asp:DropDownList CssClass="col-xs-12 form-control input-sm" ID="cmbSearchLoanStatus" runat="server" Visible="false" AppendDataBoundItems="True" Width="120px"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-2">
                            <asp:CheckBox ID="chkClientType" runat="server" AutoPostBack="True" Text="Client Type" />
                        </div>
                        <div class="col-xs-2">
                            <asp:DropDownList CssClass="col-xs-12 form-control input-sm" ID="cmbSearchClientType" runat="server" AutoPostBack="True" AppendDataBoundItems="True" Visible="False">
                            </asp:DropDownList>
                        </div>
                        <div class="col-xs-2">
                            <asp:CheckBox ID="chkDateRange" Text="Application Date" AutoPostBack="true" runat="server" />
                        </div>
                        <div class="col-xs-1 control-label">
                            <asp:Label ID="lblSearchDateFrom" runat="server" Text="From  " Visible="False"></asp:Label>
                        </div>
                        <div class="col-xs-2 control-label">
                            <asp:TextBox CssClass="col-xs-12 form-control input-sm nofuturedate" ID="txtSearchFromDate" runat="server" Visible="False"></asp:TextBox>
                            <%--<span class="glyphicon glyphicon-calendar form-control-feedback" style="margin-right: 13px; background-color: #eeeeff; border-radius: 0 3px 3px 0; border: 1px solid rgb(149,188,219); z-index: 0;"></span>--%>
                        </div>
                        <div class="col-xs-1 control-label">
                            <asp:Label ID="lblSearchDateTo" runat="server" Text="To  " Visible="False"></asp:Label>
                        </div>
                        <div class="col-xs-2 control-label">
                            <asp:TextBox CssClass="col-xs-12 form-control input-sm nofuturedate" ID="txtSearchToDate" runat="server" Visible="False"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-2">
                            <asp:CheckBox ID="chkDisbDateRange" Text="Disbursement Date" AutoPostBack="true" runat="server" />
                        </div>
                        <div class="col-xs-1 control-label">
                            <asp:Label ID="lblSearchDisbDateFrom" runat="server" Text="From  " Visible="False"></asp:Label>
                        </div>
                        <div class="col-xs-2 control-label">
                            <asp:TextBox CssClass="col-xs-12 form-control input-sm nofuturedate" ID="txtSearchDisbFromDate" runat="server" Visible="False"></asp:TextBox>
                        </div>
                        <div class="col-xs-1 control-label">
                            <asp:Label ID="lblSearchDisbDateTo" runat="server" Text="To  " Visible="False"></asp:Label>
                        </div>
                        <div class="col-xs-2 control-label">
                            <asp:TextBox CssClass="col-xs-12 form-control input-sm nofuturedate" ID="txtSearchDisbToDate" runat="server" Visible="False"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-2">
                            <asp:CheckBox ID="chkSearchName" runat="server" Text="Customer Name" AutoPostBack="True" />
                        </div>
                        <div class="col-xs-2 control-label">
                            <%--<asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" Enabled="false" CssClass="col-xs-12 form-control input-sm" ID="txtCustNo" runat="server"></asp:TextBox>--%>
                            <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtSearchCustName" runat="server" Visible="False"></asp:TextBox>
                        </div>
                        <div class="col-xs-1 control-label">
                            <asp:Button CssClass="btn btn-primary btn-sm" ID="btnSearchCustNo" runat="server" Text=">>" Visible="False" />
                        </div>
                        <div class="col-xs-2">
                            <asp:Button CssClass="btn btn-primary btn-sm" ID="btnSearchLoan" runat="server" Text="Search Loan" />
                        </div>
                        <div class="col-xs-5 center-block">
                            <asp:UpdateProgress runat="server" ID="UpdateProgress2" AssociatedUpdatePanelID="UpdatePanel2" DisplayAfter="0" DynamicLayout="false">
                                <ProgressTemplate>
                                    <img alt="In progress..." src="Images/progress.gif" />
                                </ProgressTemplate>
                            </asp:UpdateProgress>
                        </div>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
            <ContentTemplate>
                <div class="panel-body">
                    <div class="row">
                        <div class="col-xs-12 text-center">
                            <asp:UpdateProgress runat="server" ID="UpdateProgress4" AssociatedUpdatePanelID="UpdatePanel3" DisplayAfter="0" DynamicLayout="false">
                                <ProgressTemplate>
                                    <img alt="In progress..." src="Images/progress.gif" />
                                </ProgressTemplate>
                            </asp:UpdateProgress>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-12 center-block">
                            <asp:GridView ID="grdSearchResults" Width="100%" runat="server" HorizontalAlign="Center" AutoGenerateColumns="False"
                                AllowPaging="true" CssClass="table table-bordered table-striped tablestyle success"
                                EmptyDataText="No matches found!" EmptyDataRowStyle-CssClass="text-warning text-center">
                                <AlternatingRowStyle CssClass="altrowstyle" />
                                <%--<HeaderStyle CssClass="headerstyle" HorizontalAlign="center" />--%>
                                <HeaderStyle CssClass="header info" />
                                <RowStyle CssClass="rowstyle" HorizontalAlign="Left" />
                                <PagerStyle CssClass="pagination-ys" />
                                <SelectedRowStyle BackColor="#A8B1B9" Font-Bold="true" />
                                <Columns>
                                    <asp:TemplateField ShowHeader="False">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Select" Text="More Details"></asp:LinkButton>
                                            <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtLoanID" Text='<%# Bind("ID")%>' runat="server" Visible="False"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="CUSTOMER_NUMBER" HeaderText="Cust No." />
                                    <asp:BoundField DataField="ID" HeaderText="Loan ID" />
                                    <asp:BoundField DataField="CUSTOMER_TYPE" HeaderText="Client Type" />
                                    <asp:BoundField DataField="NAME" HeaderText="Name" />
                                    <asp:BoundField DataField="CREATED_DATE1" HeaderText="Date" />
                                    <asp:BoundField DataField="BRANCH_NAME" HeaderText="Branch" />
                                    <asp:BoundField DataField="STATUS" HeaderText="Status" />
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-12 text-center">
                            <asp:UpdateProgress runat="server" ID="UpdateProgress3" AssociatedUpdatePanelID="UpdatePanel3" DisplayAfter="0" DynamicLayout="false">
                                <ProgressTemplate>
                                    <img alt="In progress..." src="Images/progress.gif" />
                                </ProgressTemplate>
                            </asp:UpdateProgress>
                        </div>
                    </div>
                </div>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnSearchLoan" EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <div class="panel-body">
                    <div class="row label-info">
                        <div class="col-xs-12 control-label">
                            <asp:Label ID="Label18" runat="server" Text="APPLICATION HISTORY" Visible="False"></asp:Label>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-12 center-block">
                            <asp:GridView ID="grdAppHistory" runat="server" HorizontalAlign="center">
                                <AlternatingRowStyle CssClass="altrowstyle" />
                                <HeaderStyle CssClass="headerstyle" HorizontalAlign="center" />
                                <RowStyle CssClass="rowstyle" />
                            </asp:GridView>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-12 center-block">
                            <asp:GridView ID="grdRepaymentHistory" runat="server" HorizontalAlign="Center" AutoGenerateColumns="false" Caption="Loan Transactions">
                                <AlternatingRowStyle CssClass="altrowstyle" />
                                <Columns>
                                    <asp:BoundField DataField="Desc" HeaderText="Transaction Type" />
                                    <asp:BoundField DataField="PAYMENT_DATE" HeaderText="Date" />
                                    <asp:BoundField DataField="payment" HeaderText="Amount Due/Paid" />
                                    <asp:BoundField DataField="Balance" HeaderText="Loan Balance" />
                                </Columns>
                                <HeaderStyle CssClass="headerstyle" HorizontalAlign="center" />
                                <RowStyle CssClass="rowstyle" />
                            </asp:GridView>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-2 control-label">
                            On-time Repayment Rate
                        </div>
                        <div class="col-xs-2 control-label">
                            <asp:Label ID="lblOnTimeRate" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-2 control-label">
                            <asp:Label ID="Label79" runat="server" Text="Branch"></asp:Label>
                        </div>
                        <div class="col-xs-4 control-label">
                            <asp:Label ID="lblBranchCode" runat="server" Text=""></asp:Label>
                            <asp:Label ID="Label80" runat="server" Text="   "></asp:Label>
                            <asp:Label ID="lblBranchName" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                    <asp:HiddenField ID="TabName" runat="server" />
                    <div class="row">
                        <div class="col-xs-12 alert-info control-label">
                            <asp:Label ID="lblDisbDate" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                    <asp:Panel ID="panIndividual" runat="server">
                        <div id="Tabs" role="tabpanel">
                            <ul class="nav nav-tabs bg-info">
                                <li class="active"><a data-toggle="tab" href="#applicant"><b>Applicant Details</b></a></li>
                                <li><a data-toggle="tab" href="#guarantor"><b>Guarantor & Collateral Information</b></a></li>
                                <li><a data-toggle="tab" href="#product"><b>Other Loans</b></a></li>
                                <li><a data-toggle="tab" href="#questionnaire"><b>Attached Documents</b></a></li>
                                <li><a data-toggle="tab" href="#financial"><b>Financial Requirements</b></a></li>
                            </ul>
                            <div class="tab-content">
                                <div id="applicant" class="tab-pane fade in active">
                                    <div style="height: 15px;"></div>
                                    <div class="row">
                                        <div class="col-xs-12 text-center">
                                            <asp:Image ID="imgClientPhoto" runat="server" Width="140" Height="190" />
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-xs-2 control-label">
                                            <asp:Label ID="Label82" runat="server" Text="Customer Number"></asp:Label>
                                        </div>
                                        <div class="col-xs-4">
                                            <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" CssClass="col-xs-12 form-control input-sm" ID="txtCustNo" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-xs-2 control-label">
                                            <asp:Label ID="Label83" runat="server" Text="Client Type"></asp:Label>
                                        </div>
                                        <div class="col-xs-4">
                                            <asp:DropDownList CssClass="col-xs-12 form-control input-sm" ID="rdbClientType" runat="server" Font-Bold="true" AutoPostBack="True" Enabled="False">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-xs-2 control-label">
                                            Applicant Category
                                        </div>
                                        <div class="col-xs-4 text-center control-label">
                                            <asp:RadioButtonList ID="rdbSubIndividual" runat="server" ReadOnly="True" ForeColor="Black" Font-Bold="true"
                                                RepeatDirection="Horizontal" AutoPostBack="True" CssClass="col-xs-12">
                                                <asp:ListItem Text="SSB" Value="SSB"></asp:ListItem>
                                                <asp:ListItem Text="Bankers" Value="Bankers"></asp:ListItem>
                                                <asp:ListItem Text="PDAs" Value="PDAs"></asp:ListItem>
                                                <asp:ListItem Text="Other" Value="Other"></asp:ListItem>
                                            </asp:RadioButtonList>
                                        </div>
                                    </div>
                                    <div class="row alert-info">
                                        <div class="col-xs-12 control-label">
                                            <asp:Label ID="lblCurrExposure" runat="server" Text=""></asp:Label>
                                        </div>
                                    </div>
                                    <div class="row" id="divAppTypeBanker" runat="server" visible="false">
                                        <div class="col-xs-2 control-label">
                                            Bank
                                        </div>
                                        <div class="col-xs-4">
                                            <asp:DropDownList ReadOnly="True" ForeColor="Black" Font-Bold="true" Enabled="false" CssClass="col-xs-12 form-control input-sm" ID="cmbBankAppType" runat="server" AutoPostBack="true"></asp:DropDownList>
                                        </div>
                                        <div class="col-xs-2 control-label">
                                            Branch
                                        </div>
                                        <div class="col-xs-4">
                                            <asp:DropDownList ReadOnly="True" ForeColor="Black" Font-Bold="true" Enabled="false" CssClass="col-xs-12 form-control input-sm" ID="cmbBranchAppType" runat="server"></asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="row" id="divAppTypePDA" runat="server" visible="false">
                                        <div class="col-xs-2 control-label">
                                            Company
                                        </div>
                                        <div class="col-xs-4">
                                            <asp:DropDownList ReadOnly="True" ForeColor="Black" Font-Bold="true" Enabled="false" CssClass="col-xs-12 form-control input-sm" ID="cmbPDAAppType" runat="server"></asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="row" id="divAppTypeOther" runat="server" visible="false">
                                        <div class="col-xs-2 control-label">
                                            Description
                                        </div>
                                        <div class="col-xs-4">
                                            <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" CssClass="col-xs-12 form-control input-sm" ID="txtOtherAppType" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-xs-2 control-label">
                                            <asp:Label ID="lblSurname" runat="server" Text="Surname"></asp:Label>
                                            <asp:Label ID="Label53" runat="server" Text="*" ForeColor="Red" Font-Size="Large"></asp:Label>
                                        </div>
                                        <div class="col-xs-4">
                                            <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" CssClass="col-xs-12 form-control input-sm" ID="txtSurname" runat="server" onkeypress="return isTextOnly(event)"></asp:TextBox>
                                            <asp:RequiredFieldValidator Display="Dynamic" ID="rfvSurname" runat="server" ErrorMessage="Surname is required" ValidationGroup="valIndiv" ControlToValidate="txtSurname"></asp:RequiredFieldValidator>
                                        </div>
                                        <div class="col-xs-2 control-label">
                                            <asp:Label ID="lblForenames" runat="server" Text="Forenames"></asp:Label>
                                            <asp:Label ID="Label1" runat="server" Text="*" ForeColor="Red" Font-Size="Large"></asp:Label>
                                        </div>
                                        <div class="col-xs-4">
                                            <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" CssClass="col-xs-12 form-control input-sm" ID="txtForenames" runat="server" onkeypress="return isTextOnly(event)"></asp:TextBox>
                                            <asp:RequiredFieldValidator Display="Dynamic" ID="rfvForenames" runat="server" ErrorMessage="Forename is required" ValidationGroup="valIndiv" ControlToValidate="txtForenames"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-xs-2 control-label">
                                            <asp:Label ID="lblMinDept" runat="server" Text="Ministry/Department" Visible="False"></asp:Label>
                                        </div>
                                        <div class="col-xs-4">
                                            <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" CssClass="col-xs-12 form-control input-sm" ID="txtMinDept" runat="server" Visible="False"></asp:TextBox>
                                        </div>
                                        <div class="col-xs-2 control-label">
                                            <asp:Label ID="lblMinDeptNo" runat="server" Text="Min/Dept No." Visible="False"></asp:Label>
                                        </div>
                                        <div class="col-xs-4">
                                            <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" CssClass="col-xs-12 form-control input-sm" ID="txtMinDeptNo" runat="server" Visible="False"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-xs-2 control-label">
                                            <asp:Label ID="lblSector" runat="server" Text="Sector"></asp:Label>
                                        </div>
                                        <div class="col-xs-4">
                                            <asp:DropDownList ReadOnly="True" ForeColor="Black" Font-Bold="true" Enabled="false" ID="cmbSector" runat="server" CssClass="col-xs-12 form-control input-sm"></asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-xs-2 control-label">
                                            <asp:Label ID="lblEmpCode" runat="server" Text="Employee Code No." Visible="False"></asp:Label>
                                        </div>
                                        <div class="col-xs-4">
                                            <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" CssClass="col-xs-12 form-control input-sm" ID="txtECNo" runat="server" Visible="False"
                                                onblur="return isEmployeeCode()" Width="90px" onkeypress="return isnumeric(event)"></asp:TextBox>
                                            <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" CssClass="col-xs-12 form-control input-sm" ID="txtECNoCD" runat="server" Width="35px" Visible="False"></asp:TextBox>
                                        </div>
                                        <div class="col-xs-2 control-label">
                                            <asp:Label ID="lblDOB" runat="server" Text="Date of Birth"></asp:Label>
                                            <asp:Label ID="Label2" runat="server" Text="*" ForeColor="Red" Font-Size="Large"></asp:Label>
                                        </div>
                                        <div class="col-xs-4">
                                            <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" ID="bdpDOB" runat="server" CssClass="col-xs-12 form-control input-sm dob"></asp:TextBox>
                                            <span class="glyphicon glyphicon-calendar form-control-feedback" style="margin-right: 13px; background-color: #eeeeff; border-radius: 0 3px 3px 0; border: 1px solid rgb(149,188,219); z-index: 0;"></span>
                                            <asp:RequiredFieldValidator Display="Dynamic" ID="rfvDOB" runat="server" ErrorMessage="Date of Birth is required" ValidationGroup="valIndiv" ControlToValidate="bdpDOB"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-xs-2 control-label">
                                            <asp:Label ID="lblIDNo" runat="server" Text="ID Number"></asp:Label>
                                        </div>
                                        <div class="col-xs-4">
                                            <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" ID="txtIDNo" runat="server" CssClass="col-xs-12 form-control input-sm"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-xs-2 control-label">
                                            <asp:Label ID="lblIssDate" runat="server" Text="ID Issue Date"></asp:Label>
                                        </div>
                                        <div class="col-xs-4">
                                            <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" ID="bdpIssDate" runat="server" CssClass="col-xs-12 form-control input-sm nofuturedate"></asp:TextBox>
                                            <span class="glyphicon glyphicon-calendar form-control-feedback" style="margin-right: 13px; background-color: #eeeeff; border-radius: 0 3px 3px 0; border: 1px solid rgb(149,188,219); z-index: 0;"></span>
                                        </div>
                                        <div class="col-xs-2 control-label">
                                            <asp:Label ID="lblAddress" runat="server" Text="Address"></asp:Label>
                                            <asp:Label ID="Label4" runat="server" Text="*" ForeColor="Red" Font-Size="Large"></asp:Label>
                                        </div>
                                        <div class="col-xs-4">
                                            <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" CssClass="col-xs-12 form-control input-sm" ID="txtAddress" runat="server" Rows="2"
                                                TextMode="MultiLine"></asp:TextBox>
                                            <asp:RequiredFieldValidator Display="Dynamic" ID="rfvAddress" runat="server" ErrorMessage="Address is required" ValidationGroup="valIndiv" ControlToValidate="txtAddress"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-xs-2 control-label">
                                            <asp:Label ID="lblCity" runat="server" Text="City"></asp:Label>
                                        </div>
                                        <div class="col-xs-4">
                                            <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" CssClass="col-xs-12 form-control input-sm" ID="txtCity" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-xs-2 control-label">
                                            <asp:Label ID="Label89" runat="server" Text="Area"></asp:Label>
                                        </div>
                                        <div class="col-xs-4">
                                            <asp:DropDownList ReadOnly="True" ForeColor="Black" Font-Bold="true" Enabled="false" CssClass="col-xs-12 form-control input-sm" ID="cmbArea" runat="server">
                                                <asp:ListItem Text="Urban" Value="Urban"></asp:ListItem>
                                                <asp:ListItem Text="Periurban" Value="Periurban"></asp:ListItem>
                                                <asp:ListItem Text="Rural" Value="Rural"></asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-xs-2 control-label">
                                            <asp:Label ID="Label6" runat="server" Text="Phone No."></asp:Label>
                                        </div>
                                        <div class="col-xs-4">
                                            <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" CssClass="col-xs-12 form-control input-sm" ID="txtPhoneNo" runat="server" onkeypress="return isPhoneNo(event)"></asp:TextBox>
                                        </div>
                                        <div class="col-xs-2 control-label">
                                            <asp:Label ID="Label7" runat="server" Text="Nationality"></asp:Label>
                                        </div>
                                        <div class="col-xs-4">
                                            <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" CssClass="col-xs-12 form-control input-sm" ID="txtNationality" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-xs-2 control-label">
                                            <asp:Label ID="Label8" runat="server" Text="Gender"></asp:Label>
                                            <asp:Label ID="Label5" runat="server" Text="*" ForeColor="Red" Font-Size="Large"></asp:Label>
                                        </div>
                                        <div class="col-xs-4">
                                            <asp:RadioButtonList ReadOnly="True" ForeColor="Black" Font-Bold="true" ID="rdbGender" runat="server" CssClass="col-xs-12"
                                                RepeatDirection="Horizontal">
                                                <asp:ListItem Text="Male" Value="M"></asp:ListItem>
                                                <asp:ListItem Text="Female" Value="F"></asp:ListItem>
                                            </asp:RadioButtonList>
                                            <asp:RequiredFieldValidator Display="Dynamic" ID="rfvGender" runat="server" ErrorMessage="Gender is required" ValidationGroup="valIndiv" ControlToValidate="rdbGender"></asp:RequiredFieldValidator>
                                        </div>
                                        <div class="col-xs-2 control-label">
                                            Home Ownership
                                        </div>
                                        <div class="col-xs-4">
                                            <asp:RadioButtonList ReadOnly="True" ForeColor="Black" Font-Bold="true" ID="rdbHouse" runat="server" CssClass="col-xs-12"
                                                RepeatDirection="Horizontal">
                                                <asp:ListItem Text="Own" Value="Own"></asp:ListItem>
                                                <asp:ListItem Text="Rent" Value="Rent"></asp:ListItem>
                                            </asp:RadioButtonList>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-xs-2 control-label">
                                            <asp:Label ID="Label9" runat="server" Text="Monthly Payment or Rent($)"></asp:Label>
                                        </div>
                                        <div class="col-xs-4">
                                            <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" CssClass="col-xs-12 form-control input-sm" ID="txtRent" runat="server"
                                                onkeypress="return isNumberKey(event)"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-xs-2 control-label hidden">
                                            <asp:Label ID="Label10" runat="server" Text="Period at residence (months)"></asp:Label>
                                        </div>
                                        <div class="col-xs-4 hidden">
                                            <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" CssClass="col-xs-12 form-control input-sm" ID="txtHouseHowLong" runat="server"
                                                onkeypress="return isNumberKey(event)"></asp:TextBox>
                                        </div>
                                        <div class="col-xs-2 control-label">
                                            <asp:Label ID="Label11" runat="server" Text="Marital Status"></asp:Label>
                                        </div>
                                        <div class="col-xs-4">
                                            <asp:DropDownList ReadOnly="True" ForeColor="Black" Font-Bold="true" Enabled="false" CssClass="col-xs-12 form-control input-sm" ID="cmbMaritalStatus" runat="server">
                                                <asp:ListItem Text="" Value=""></asp:ListItem>
                                                <asp:ListItem Text="Single" Value="Single"></asp:ListItem>
                                                <asp:ListItem Text="Married" Value="Married"></asp:ListItem>
                                                <asp:ListItem Text="Divorced" Value="Divorced"></asp:ListItem>
                                                <asp:ListItem Text="Widowed" Value="Widowed"></asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-xs-2 control-label">
                                            <asp:Label ID="lblEduc" runat="server" Text="Education"></asp:Label>
                                        </div>
                                        <div class="col-xs-4">
                                            <asp:DropDownList ReadOnly="True" ForeColor="Black" Font-Bold="true" Enabled="false" CssClass="col-xs-12 form-control input-sm" ID="cmbEducation" runat="server" AutoPostBack="True">
                                                <asp:ListItem Text="" Value=""></asp:ListItem>
                                                <asp:ListItem Text="Primary" Value="Primary"></asp:ListItem>
                                                <asp:ListItem Text="Secondary" Value="Secondary"></asp:ListItem>
                                                <asp:ListItem Text="High School" Value="High School"></asp:ListItem>
                                                <asp:ListItem Text="Diploma" Value="Diploma"></asp:ListItem>
                                                <asp:ListItem Text="Degree" Value="Degree"></asp:ListItem>
                                                <asp:ListItem Text="Masters" Value="Masters"></asp:ListItem>
                                                <asp:ListItem Text="Other" Value="Other"></asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                        <div class="col-xs-4">
                                            <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" CssClass="col-xs-12 form-control input-sm" ID="txtEducationOther" runat="server" Visible="False"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row label-info">
                                        <div class="col-xs-12 control-label">
                                            Banking Details
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-xs-2 control-label">
                                            Bank
                                        </div>
                                        <div class="col-xs-4">
                                            <asp:DropDownList ReadOnly="True" ForeColor="Black" Font-Bold="true" Enabled="false" CssClass="col-xs-12 form-control input-sm" ID="cmbBank" runat="server" AutoPostBack="true"></asp:DropDownList>
                                        </div>
                                        <div class="col-xs-2 control-label">
                                            Branch
                                        </div>
                                        <div class="col-xs-4">
                                            <asp:DropDownList ReadOnly="True" ForeColor="Black" Font-Bold="true" Enabled="false" CssClass="col-xs-12 form-control input-sm" ID="cmbBankBranch" runat="server"></asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-xs-2 control-label">
                                            Account Number
                                        </div>
                                        <div class="col-xs-4">
                                            <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" CssClass="col-xs-12 form-control input-sm text-only" ID="txtBankAccountNo" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div id="spouseDetails">
                                        <div class="row label-info">
                                            <div class="col-xs-12 control-label">
                                                <asp:Label ID="Label107" runat="server"
                                                    Text="SPOUSE DETAILS"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-xs-2 control-label">
                                                <asp:Label ID="Label30" runat="server" Text="Name of spouse"></asp:Label>
                                            </div>
                                            <div class="col-xs-4">
                                                <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" CssClass="col-xs-12 form-control input-sm" ID="txtSpouse" runat="server"></asp:TextBox>
                                            </div>
                                            <div class="col-xs-2 control-label">
                                                <asp:Label ID="Label31" runat="server" Text="Spouse's Occupation"></asp:Label>
                                            </div>
                                            <div class="col-xs-4">
                                                <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" CssClass="col-xs-12 form-control input-sm" ID="txtSpouseOccupation" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-xs-2 control-label">
                                                <asp:Label ID="Label32" runat="server" Text="Phone"></asp:Label>
                                            </div>
                                            <div class="col-xs-4">
                                                <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" CssClass="col-xs-12 form-control input-sm" ID="txtSpousePhone" runat="server" onkeypress="return isPhoneNo(event)"></asp:TextBox>
                                            </div>
                                            <div class="col-xs-2 control-label">
                                                <asp:Label ID="Label33" runat="server" Text="Employer"></asp:Label>
                                            </div>
                                            <div class="col-xs-4">
                                                <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" CssClass="col-xs-12 form-control input-sm" ID="txtSpouseEmployer" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-xs-2 control-label">
                                                <asp:Label ID="Label34" runat="server" Text="Number of Children"></asp:Label>
                                            </div>
                                            <div class="col-xs-4">
                                                <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" CssClass="col-xs-12 form-control input-sm" ID="txtNoChildren" runat="server"
                                                    onkeypress="return isNumberKey(event)"></asp:TextBox>
                                            </div>
                                            <div class="col-xs-2 control-label">
                                                <asp:Label ID="Label35" runat="server" Text="Number of Dependants"></asp:Label>
                                            </div>
                                            <div class="col-xs-4">
                                                <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" CssClass="col-xs-12 form-control input-sm" ID="txtNoDependant" runat="server"
                                                    onkeypress="return isNumberKey(event)"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row label-info">
                                        <div class="col-xs-12 control-label">
                                            NEXT OF KIN DETAILS
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-xs-2 control-label">
                                            <asp:Label ID="lblPPPDPBusAdd" runat="server" Text="Name of relative"></asp:Label>
                                        </div>
                                        <div class="col-xs-4">
                                            <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" CssClass="col-xs-12 form-control input-sm" ID="txtGuarNameRelative" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-xs-2 control-label">
                                            <asp:Label ID="lblPPPDPResAdd" runat="server" Text="Address"></asp:Label>
                                        </div>
                                        <div class="col-xs-4">
                                            <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" CssClass="col-xs-12 form-control input-sm" ID="txtGuarRelAddress" runat="server" TextMode="MultiLine"></asp:TextBox>
                                        </div>
                                        <div class="col-xs-2 control-label">
                                            <asp:Label ID="lblPPPDPResAddIs" runat="server" Text="Phone"></asp:Label>
                                        </div>
                                        <div class="col-xs-4">
                                            <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" CssClass="col-xs-12 form-control input-sm" ID="txtGuarRelPhone" runat="server" onkeypress="return isPhoneNo(event)"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-xs-2 control-label">
                                            <asp:Label ID="Label45" runat="server" Text="City"></asp:Label>
                                        </div>
                                        <div class="col-xs-4">
                                            <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" CssClass="col-xs-12 form-control input-sm" ID="txtGuarRelCity" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-xs-2 control-label">
                                            <asp:Label ID="Label46" runat="server" Text="Relationship"></asp:Label>
                                        </div>
                                        <div class="col-xs-4">
                                            <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" CssClass="col-xs-12 form-control input-sm" ID="txtGuarRelReltnship" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row label-info">
                                        <div class="col-xs-12 control-label">
                                            <asp:Label ID="Label13" runat="server" Text="EMPLOYMENT INFORMATION"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-xs-2 control-label">
                                            <asp:Label ID="Label12" runat="server" Text="Current Employer"></asp:Label>
                                            <asp:Label ID="Label14" runat="server" Text="*" ForeColor="Red" Font-Size="Large"></asp:Label>
                                        </div>
                                        <div class="col-xs-4">
                                            <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" CssClass="col-xs-12 form-control input-sm" ID="txtCurrEmployer" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator Display="Dynamic" ID="rfvCurrEmployer" runat="server" ErrorMessage="Current Employer is required" ValidationGroup="valIndiv" ControlToValidate="txtCurrEmployer"></asp:RequiredFieldValidator>
                                        </div>
                                        <div class="col-xs-2 control-label">
                                            <asp:Label ID="Label15" runat="server" Text="Employer Address"></asp:Label>
                                            <asp:Label ID="Label16" runat="server" Text="*" ForeColor="Red" Font-Size="Large"></asp:Label>
                                        </div>
                                        <div class="col-xs-4">
                                            <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" CssClass="col-xs-12 form-control input-sm" ID="txtEmpAddress" runat="server" TextMode="MultiLine"></asp:TextBox>
                                            <asp:RequiredFieldValidator Display="Dynamic" ID="rfvEmpAddress" runat="server" ErrorMessage="Employer Address is required" ValidationGroup="valIndiv" ControlToValidate="txtEmpAddress"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-xs-2 control-label">
                                            <asp:Label ID="Label22" runat="server" Text="Period Employed (months)"></asp:Label>
                                        </div>
                                        <div class="col-xs-4">
                                            <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" CssClass="col-xs-12 form-control input-sm" ID="txtEmpHowLong" runat="server"
                                                onkeypress="return isNumberKey(event)"></asp:TextBox>
                                        </div>
                                        <div class="col-xs-2 control-label">
                                            <asp:Label ID="Label23" runat="server" Text="Phone"></asp:Label>
                                            <asp:Label ID="Label96" runat="server" Text="*" ForeColor="Red" Font-Size="Large"></asp:Label>
                                        </div>
                                        <div class="col-xs-4">
                                            <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" CssClass="col-xs-12 form-control input-sm" ID="txtEmpPhone" runat="server" onkeypress="return isPhoneNo(event)"></asp:TextBox>
                                            <asp:RequiredFieldValidator Display="Dynamic" ID="rfvEmpPhone" runat="server" ErrorMessage="Phone number is required" ValidationGroup="valIndiv" ControlToValidate="txtEmpPhone"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-xs-2 control-label">
                                            <asp:Label ID="Label24" runat="server" Text="E-mail"></asp:Label>
                                        </div>
                                        <div class="col-xs-4">
                                            <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" CssClass="col-xs-12 form-control input-sm" ID="txtEmpEmail" runat="server"></asp:TextBox>
                                            <asp:RegularExpressionValidator Display="Dynamic" ID="valEmpEmail" runat="server" ControlToValidate="txtEmpEmail" ValidationExpression="^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z\.][a-zA-Z]{1,3}$" ErrorMessage="Please enter a valid employer email address"></asp:RegularExpressionValidator>
                                        </div>
                                        <div class="col-xs-2 control-label">
                                            <asp:Label ID="Label25" runat="server" Text="Fax"></asp:Label>
                                        </div>
                                        <div class="col-xs-4">
                                            <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" CssClass="col-xs-12 form-control input-sm" ID="txtEmpFax" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-xs-2 control-label">
                                            <asp:Label ID="Label26" runat="server" Text="City"></asp:Label>
                                        </div>
                                        <div class="col-xs-4">
                                            <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" CssClass="col-xs-12 form-control input-sm" ID="txtEmpCity" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-xs-2 control-label">
                                            <asp:Label ID="Label27" runat="server" Text="Position"></asp:Label>
                                            <asp:Label ID="Label97" runat="server" Text="*" ForeColor="Red" Font-Size="Large"></asp:Label>
                                        </div>
                                        <div class="col-xs-4">
                                            <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" CssClass="col-xs-12 form-control input-sm" ID="txtEmpPosition" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator Display="Dynamic" ID="rfvEmpPosition" runat="server" ErrorMessage="Position is required" ValidationGroup="valIndiv" ControlToValidate="txtEmpPosition"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-xs-2 control-label">
                                            <asp:Label ID="Label17" runat="server" Text="Gross Salary"></asp:Label>
                                            <asp:Label ID="Label98" runat="server" Text="*" ForeColor="Red" Font-Size="Large"></asp:Label>
                                        </div>
                                        <div class="col-xs-4">
                                            <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" CssClass="col-xs-12 form-control input-sm" ID="txtEmpSalary" runat="server"
                                                onkeypress="return isNumberKey(event)"></asp:TextBox>
                                            <asp:RequiredFieldValidator Display="Dynamic" ID="rfvEmpSalary" runat="server" ErrorMessage="Gross salary is required" ValidationGroup="valIndiv" ControlToValidate="txtEmpSalary"></asp:RequiredFieldValidator>
                                        </div>
                                        <div class="col-xs-2 control-label">
                                            <asp:Label ID="Label1121" runat="server" Text="Net Salary"></asp:Label>
                                            <asp:Label ID="Label102" runat="server" Text="*" ForeColor="Red" Font-Size="Large"></asp:Label>
                                        </div>
                                        <div class="col-xs-4">
                                            <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" CssClass="col-xs-12 form-control input-sm" ID="txtEmpSalaryNet" runat="server"
                                                onkeypress="return isNumberKey(event)"></asp:TextBox>
                                            <asp:RequiredFieldValidator Display="Dynamic" ID="rfvEmpSalaryNet" runat="server" ErrorMessage="Net salary is required" ValidationGroup="valIndiv" ControlToValidate="txtEmpSalaryNet"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-xs-2 control-label">
                                            <asp:Label ID="Label29" runat="server" Text="Other Income"></asp:Label>
                                        </div>
                                        <div class="col-xs-4">
                                            <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" CssClass="col-xs-12 form-control input-sm" ID="txtEmpOtherIncome" runat="server"
                                                onkeypress="return isNumberKey(event)"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="row label-info hidden">
                                        <div class="col-xs-12 control-label">
                                            <asp:Label ID="Label129" runat="server"
                                                Text="Previous Employment"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="row hidden">
                                        <div class="col-xs-2 control-label">
                                            <asp:Label ID="Label113" runat="server" Text="Previous Employer"></asp:Label>
                                        </div>
                                        <div class="col-xs-4">
                                            <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" CssClass="col-xs-12 form-control input-sm" ID="txtPrevEmployer" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row hidden">
                                        <div class="col-xs-2 control-label">
                                            <asp:Label ID="Label114" runat="server" Text="Address"></asp:Label>
                                        </div>
                                        <div class="col-xs-4">
                                            <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" CssClass="col-xs-12 form-control input-sm" ID="txtPrevEmpAddress" runat="server" TextMode="MultiLine"></asp:TextBox>
                                        </div>
                                        <div class="col-xs-2 control-label">
                                            <asp:Label ID="Label115" runat="server" Text="Period Employed (months)"></asp:Label>
                                        </div>
                                        <div class="col-xs-4">
                                            <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" CssClass="col-xs-12 form-control input-sm" ID="txtPrevEmpHowLong" runat="server"
                                                onkeypress="return isNumberKey(event)"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row hidden">
                                        <div class="col-xs-2 control-label">
                                            <asp:Label ID="Label116" runat="server" Text="Phone"></asp:Label>
                                        </div>
                                        <div class="col-xs-4">
                                            <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" CssClass="col-xs-12 form-control input-sm" ID="txtPrevEmpPhone" runat="server" onkeypress="return isPhoneNo(event)"></asp:TextBox>
                                        </div>
                                        <div class="col-xs-2 control-label">
                                            <asp:Label ID="Label117" runat="server" Text="E-mail"></asp:Label>
                                        </div>
                                        <div class="col-xs-4">
                                            <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" CssClass="col-xs-12 form-control input-sm" ID="txtPrevEmpEmail" runat="server"></asp:TextBox>
                                            <asp:RegularExpressionValidator Display="Dynamic" ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtPrevEmpEmail" ValidationExpression="^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z\.][a-zA-Z]{1,3}$" ErrorMessage="Please enter a valid email address"></asp:RegularExpressionValidator>
                                        </div>
                                    </div>
                                    <div class="row hidden">
                                        <div class="col-xs-2 control-label">
                                            <asp:Label ID="Label118" runat="server" Text="Fax"></asp:Label>
                                        </div>
                                        <div class="col-xs-4">
                                            <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" CssClass="col-xs-12 form-control input-sm" ID="txtPrevEmpFax" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-xs-2 control-label">
                                            <asp:Label ID="Label119" runat="server" Text="City"></asp:Label>
                                        </div>
                                        <div class="col-xs-4">
                                            <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" CssClass="col-xs-12 form-control input-sm" ID="txtPrevEmpCity" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row hidden">
                                        <div class="col-xs-2 control-label">
                                            <asp:Label ID="Label120" runat="server" Text="Position"></asp:Label>
                                        </div>
                                        <div class="col-xs-4">
                                            <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" CssClass="col-xs-12 form-control input-sm" ID="txtPrevEmpPosition" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-xs-2 control-label">
                                            <asp:Label ID="Label121" runat="server" Text="Gross Salary"></asp:Label>
                                        </div>
                                        <div class="col-xs-4">
                                            <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" CssClass="col-xs-12 form-control input-sm" ID="txtPrevEmpSalary" runat="server"
                                                onkeypress="return isNumberKey(event)"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row hidden">
                                        <div class="col-xs-2 control-label">
                                            <asp:Label ID="Label111121" runat="server" Text="Net Salary"></asp:Label>
                                        </div>
                                        <div class="col-xs-4">
                                            <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" CssClass="col-xs-12 form-control input-sm" ID="txtPrevEmpSalaryNet" runat="server"
                                                onkeypress="return isNumberKey(event)"></asp:TextBox>
                                        </div>
                                        <div class="col-xs-2 control-label">
                                            <asp:Label ID="Label122" runat="server" Text="Annual Income"></asp:Label>
                                        </div>
                                        <div class="col-xs-4">
                                            <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" CssClass="col-xs-12 form-control input-sm" ID="txtPrevEmpAnnualIncome" runat="server"
                                                onkeypress="return isNumberKey(event)"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-xs-2 control-label">
                                            <asp:Label ID="Label36" runat="server" Text="Trade Ref"></asp:Label>
                                        </div>
                                        <div class="col-xs-4">
                                            <asp:Label ID="Label37" runat="server" Text="1)" Visible="false"></asp:Label>
                                            <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" CssClass="col-xs-12 form-control input-sm" ID="txtTradeRef1" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-xs-4">
                                            <asp:Label ID="Label130" runat="server" Text="2)" Visible="false"></asp:Label>
                                            <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" CssClass="col-xs-12 form-control input-sm" ID="txtTradeRef2" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-xs-10">
                                        </div>
                                        <div class="col-xs-2 text-right">
                                            <a class="btn btn-info btn-xs disabled">Previous</a>
                                            <a class="btn btn-info btnNext btn-xs">Next</a>
                                        </div>
                                    </div>
                                </div>
                                <div id="guarantor" class="tab-pane fade in">
                                    <div style="height: 15px;"></div>
                                    <div class="row label-info">
                                        <div class="col-xs-12 control-label">
                                            <asp:Label ID="Label19" runat="server" Text="GUARANTOR INFORMATION"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="row alert-info" id="divGuarAlert" runat="server" visible="false">
                                        <div class="col-xs-12 control-label text-center">
                                            Guarantor Details from last loan application
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-xs-2 control-label">
                                            <asp:Label ID="lblPPPDPPosition" runat="server" Text="Name"></asp:Label>
                                        </div>
                                        <div class="col-xs-4">
                                            <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" Enabled="false" CssClass="col-xs-12 form-control input-sm" ID="txtGuarName" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-xs-1">
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-xs-2 control-label">
                                            <asp:Label ID="lblPPPDPFullNames" runat="server" Text="Date of Birth"></asp:Label>
                                        </div>
                                        <div class="col-xs-4">
                                            <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" Enabled="false" ID="bdpGuarDOB" runat="server" CssClass="col-xs-12 form-control input-sm dob"></asp:TextBox>
                                            <span class="glyphicon glyphicon-calendar form-control-feedback" style="margin-right: 13px; background-color: #eeeeff; border-radius: 0 3px 3px 0; border: 1px solid rgb(149,188,219); z-index: 0;"></span>
                                        </div>
                                        <div class="col-xs-2 control-label">
                                            <asp:Label ID="lblPPPDPDOB" runat="server" Text="ID No"></asp:Label>
                                        </div>
                                        <div class="col-xs-4">
                                            <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" Enabled="false" CssClass="col-xs-12 form-control input-sm" ID="txtGuarIDNo" runat="server" data-toggle="tooltip" data-placement="top" ToolTip="Valid format: 01-2345678A90"></asp:TextBox>
                                            <asp:RegularExpressionValidator Display="dynamic" ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtGuarIDNo" ValidationGroup="valIndiv" ValidationExpression="\d{2}[-]\d{6,7}[a-zA-Z]\d{2}" ErrorMessage="Please enter a valid ID Number for guarantor"></asp:RegularExpressionValidator>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-xs-2 control-label">
                                            <asp:Label ID="Label38" runat="server" Text="Phone"></asp:Label>
                                        </div>
                                        <div class="col-xs-4">
                                            <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" Enabled="false" CssClass="col-xs-12 form-control input-sm" ID="txtGuarPhone" runat="server" onkeypress="return isPhoneNo(event)"></asp:TextBox>
                                        </div>
                                        <div class="col-xs-2 control-label">
                                            <asp:Label ID="lblPPPDPAge" runat="server" Text="Current Address"></asp:Label>
                                        </div>
                                        <div class="col-xs-4">
                                            <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" Enabled="false" CssClass="col-xs-12 form-control input-sm" ID="txtGuarCurrAdd" runat="server" TextMode="MultiLine"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-xs-2 control-label">
                                            <asp:Label ID="lblPPPDPSex" runat="server" Text="City"></asp:Label>
                                        </div>
                                        <div class="col-xs-4">
                                            <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" Enabled="false" CssClass="col-xs-12 form-control input-sm" ID="txtGuarCity" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-xs-2 control-label">
                                            Home Ownership
                                        </div>
                                        <div class="col-xs-4">
                                            <asp:RadioButtonList ID="rdbGuarHomeType" runat="server" CssClass="col-xs-12"
                                                RepeatDirection="Horizontal">
                                                <asp:ListItem Text="Own" Value="Own"></asp:ListItem>
                                                <asp:ListItem Text="Rent" Value="Rent"></asp:ListItem>
                                            </asp:RadioButtonList>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-xs-2 control-label">
                                            <asp:Label ID="Label39" runat="server" Text="Monthly payment or rent ($)"></asp:Label>
                                        </div>
                                        <div class="col-xs-4">
                                            <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" Enabled="false" CssClass="col-xs-12 form-control input-sm" ID="txtGuarMonthRent" runat="server"
                                                onkeypress="return isNumberKey(event)"></asp:TextBox>
                                        </div>
                                        <div class="col-xs-2 control-label">
                                            <asp:Label ID="Label40" runat="server" Text="Period at residence (months)"></asp:Label>
                                        </div>
                                        <div class="col-xs-4">
                                            <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" Enabled="false" CssClass="col-xs-12 form-control input-sm" ID="txtGuarHomeLength" runat="server"
                                                onkeypress="return isNumberKey(event)"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row label-info">
                                        <div class="col-xs-12 center-block">
                                            <asp:Label ID="Label41" runat="server" Text="EMPLOYMENT INFORMATION"
                                                Font-Bold="True"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-xs-2 control-label">
                                            <asp:Label ID="lblPPPDPIDPassport" runat="server" Text="Current Employer"></asp:Label>
                                        </div>
                                        <div class="col-xs-4">
                                            <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" Enabled="false" CssClass="col-xs-12 form-control input-sm" ID="txtGuarCurrEmp" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-xs-2 control-label">
                                            <asp:Label ID="lblPPPDPAppointmtDate" runat="server" Text="Employer Address"></asp:Label>
                                        </div>
                                        <div class="col-xs-4">
                                            <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" Enabled="false" CssClass="col-xs-12 form-control input-sm" ID="txtGuarEmpAdd" runat="server" TextMode="MultiLine"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-xs-2 control-label">
                                            <asp:Label ID="Label42" runat="server" Text="Period Employed (months)"></asp:Label>
                                        </div>
                                        <div class="col-xs-4">
                                            <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" Enabled="false" CssClass="col-xs-12 form-control input-sm" ID="txtGuarEmpLength" runat="server"
                                                onkeypress="return isNumberKey(event)"></asp:TextBox>
                                        </div>
                                        <div class="col-xs-2 control-label">
                                            <asp:Label ID="lblPPPDPYrsBus" runat="server" Text="Phone"></asp:Label>
                                        </div>
                                        <div class="col-xs-4">
                                            <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" Enabled="false" CssClass="col-xs-12 form-control input-sm" ID="txtGuarEmpPhone" runat="server" onkeypress="return isPhoneNo(event)"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-xs-2 control-label">
                                            <asp:Label ID="lblPPPDPPhBus" runat="server" Text="E-mail"></asp:Label>
                                        </div>
                                        <div class="col-xs-4">
                                            <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" Enabled="false" CssClass="col-xs-12 form-control input-sm" ID="txtGuarEmpEmail" runat="server"></asp:TextBox>
                                            <asp:RegularExpressionValidator Display="Dynamic" ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtGuarEmpEmail" ValidationExpression="^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z\.][a-zA-Z]{1,3}$" ErrorMessage="Please enter a valid email address"></asp:RegularExpressionValidator>
                                        </div>
                                        <div class="col-xs-2 control-label">
                                            <asp:Label ID="Label43" runat="server" Text="Fax"></asp:Label>
                                        </div>
                                        <div class="col-xs-4">
                                            <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" Enabled="false" CssClass="col-xs-12 form-control input-sm" ID="txtGuarEmpFax" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-xs-2 control-label">
                                            <asp:Label ID="lblPPPDPMobile" runat="server" Text="Position"></asp:Label>
                                        </div>
                                        <div class="col-xs-4">
                                            <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" Enabled="false" CssClass="col-xs-12 form-control input-sm" ID="txtGuarEmpPosition" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-xs-2 control-label">
                                            <asp:Label ID="lblPPPDPHome" runat="server" Text="Monthly Salary"></asp:Label>
                                        </div>
                                        <div class="col-xs-4">
                                            <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" Enabled="false" CssClass="col-xs-12 form-control input-sm" ID="txtGuarEmpSalary" runat="server"
                                                onkeypress="return isNumberKey(event)"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-xs-2 control-label">
                                            <asp:Label ID="Label44" runat="server" Text="Other Income"></asp:Label>
                                        </div>
                                        <div class="col-xs-4">
                                            <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" Enabled="false" CssClass="col-xs-12 form-control input-sm" ID="txtGuarEmpIncome" runat="server"
                                                onkeypress="return isNumberKey(event)"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row label-info">
                                        <div class="col-xs-12 control-label">
                                            Collateral Offered
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-xs-12 center-block">
                                            <asp:GridView ID="grdCollateral" runat="server" HorizontalAlign="center">
                                                <AlternatingRowStyle CssClass="altrowstyle" />
                                                <HeaderStyle CssClass="headerstyle" HorizontalAlign="center" />
                                                <RowStyle CssClass="rowstyle" />
                                                <PagerStyle CssClass="pagination-ys" />
                                                <SelectedRowStyle Font-Bold="true" BackColor="SeaShell" />
                                            </asp:GridView>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-xs-10">
                                        </div>
                                        <div class="col-xs-2 text-right">
                                            <a class="btn btn-info btnPrevious btn-xs">Previous</a>
                                            <a class="btn btn-info btnNext btn-xs">Next</a>
                                        </div>
                                    </div>
                                </div>
                                <div id="financial" class="tab-pane fade in">
                                    <div style="height: 15px;"></div>
                                    <div class="row label-info">
                                        <div class="col-xs-12 control-label">
                                            <asp:Label ID="lblDirectHolding" runat="server" Text="FINANCIAL REQUIREMENTS"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-xs-2 control-label">
                                            <asp:Label ID="Label20" runat="server" Text="Product Type"></asp:Label>
                                            <asp:Label ID="Label104" runat="server" Text="*" ForeColor="Red" Font-Size="Large"></asp:Label>
                                        </div>
                                        <div class="col-xs-4">
                                            <asp:DropDownList ReadOnly="True" ForeColor="Black" Font-Bold="true" Enabled="false" CssClass="col-xs-12 form-control input-sm" ID="cmbProductType" runat="server" AutoPostBack="true"></asp:DropDownList>
                                            <asp:RequiredFieldValidator Display="Dynamic" ID="rfvProductType" runat="server" ErrorMessage="Product type is required" ValidationGroup="valIndiv" ControlToValidate="cmbProductType"></asp:RequiredFieldValidator>
                                        </div>
                                        <div class="col-xs-2 control-label">
                                            <asp:Label ID="lblDHAsAt" runat="server" Text="Amount Required ($)"></asp:Label>
                                            <asp:Label ID="Label108" runat="server" Text="*" ForeColor="Red" Font-Size="Large"></asp:Label>
                                        </div>
                                        <div class="col-xs-4">
                                            <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" Enabled="false" CssClass="col-xs-12 form-control input-sm numeric" ID="txtFinReqAmt" runat="server" onchange="validateInput();"></asp:TextBox>
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
                                            <asp:DropDownList ReadOnly="True" ForeColor="Black" Font-Bold="true" Enabled="false" CssClass="col-xs-12 form-control input-sm" ID="ddlAssets" runat="server" AutoPostBack="true" Visible="false">
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
                                            <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" Enabled="false" CssClass="col-xs-12 form-control input-sm numeric" ID="txtFinReqTenor" runat="server" onchange="validateInput();"></asp:TextBox>
                                            <asp:Label ID="lblTenure" runat="server" Text="" ForeColor="red"></asp:Label>
                                            <asp:RequiredFieldValidator Display="Dynamic" ID="rfvFinReqTenor" runat="server" ErrorMessage="Loan Tenor is required" ValidationGroup="valIndiv" ControlToValidate="txtFinReqTenor"></asp:RequiredFieldValidator>
                                            <asp:HiddenField ID="hidMaxTenure" runat="server" />
                                            <asp:HiddenField ID="hidMinTenure" runat="server" />
                                        </div>
                                        <div class="col-xs-2 control-label">
                                            Repayment Intervals
                                        </div>
                                        <div class="col-xs-2">
                                            <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" Enabled="false" CssClass="col-xs-12 form-control input-sm numeric" ID="txtRepaymentInterval" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-xs-2">
                                            <asp:DropDownList ReadOnly="True" ForeColor="Black" Font-Bold="true" Enabled="false" CssClass="col-xs-12 form-control input-sm" ID="cmbRepaymentInterval" runat="server">
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
                                            <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" Enabled="false" CssClass="col-xs-12 form-control input-sm" ID="txtInterestRate" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-xs-2 control-label">
                                            <asp:Label ID="lblInsurance" runat="server" Text="Insurance Rate (%)"></asp:Label>
                                        </div>
                                        <div class="col-xs-4">
                                            <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" Enabled="false" CssClass="col-xs-12 form-control input-sm numeric" ID="txtInsuranceRate" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-xs-2 control-label">
                                            <asp:Label ID="lblAdminRate" runat="server" Text="Application Fees (%)"></asp:Label>
                                        </div>
                                        <div class="col-xs-4">
                                            <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" Enabled="false" CssClass="col-xs-12 form-control input-sm numeric" ID="txtAdminRate" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-xs-2 control-label">
                                            <asp:Label ID="lblInterestRate" runat="server" Text="Interest Rate (%)"></asp:Label>
                                            <asp:Label ID="Label103" runat="server" Text="*" ForeColor="Red" Font-Size="Large"></asp:Label>
                                        </div>
                                        <div class="col-xs-4">
                                            <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" Enabled="false" CssClass="col-xs-12 form-control input-sm numeric" ID="txtFinReqIntRate" runat="server" onchange="validateInput();"></asp:TextBox><%--onkeyup="sum();"--%>
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
                                            <asp:DropDownList ReadOnly="True" ForeColor="Black" Font-Bold="true" Enabled="false" CssClass="col-xs-12 form-control input-sm" ID="cmbFinReqPurpose" runat="server">
                                            </asp:DropDownList>
                                            <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" Enabled="false" CssClass="col-xs-12 form-control input-sm" ID="txtFinReqPurpose" runat="server" Visible="False"></asp:TextBox>
                                            <asp:RequiredFieldValidator Display="Dynamic" ID="rfvFinReqPurpose" runat="server" ErrorMessage="Loan purpose is required" ValidationGroup="valIndiv" ControlToValidate="cmbFinReqPurpose"></asp:RequiredFieldValidator>
                                        </div>
                                        <div class="col-xs-1 left">
                                            <button type="button" class="btn btn-info btn-sm" data-toggle="modal" data-target="#LoanPurposeModal">Add</button>
                                        </div>
                                        <div class="col-xs-2 control-label">
                                            <asp:Label ID="lblDHHoldingPerc" runat="server" Text="Source of Repayment"></asp:Label>
                                        </div>
                                        <div class="col-xs-4">
                                            <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" Enabled="false" CssClass="col-xs-12 form-control input-sm" ID="txtFinReqSource" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row hidden">
                                        <div class="col-xs-2 control-label">
                                            <asp:Label ID="Label48" runat="server" Text="Security Offered"></asp:Label>
                                        </div>
                                        <div class="col-xs-4">
                                            <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" Enabled="false" CssClass="col-xs-12 form-control input-sm" ID="txtFinReqSecOffer" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-xs-2 control-label">
                                            <asp:Label ID="Label49" runat="server" Text="Bank"></asp:Label>
                                        </div>
                                        <div class="col-xs-4">
                                            <asp:DropDownList ReadOnly="True" ForeColor="Black" Font-Bold="true" Enabled="false" CssClass="col-xs-12 form-control input-sm" ID="cmbFinReqBank" runat="server"
                                                AutoPostBack="True">
                                            </asp:DropDownList>
                                            <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" Enabled="false" CssClass="col-xs-12 form-control input-sm" ID="txtFinReqBank" runat="server" Visible="False"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row hidden">
                                        <div class="col-xs-2 control-label">
                                            <asp:Label ID="Label50" runat="server" Text="Branch Name"></asp:Label>
                                        </div>
                                        <div class="col-xs-4">
                                            <asp:DropDownList ReadOnly="True" ForeColor="Black" Font-Bold="true" Enabled="false" CssClass="col-xs-12 form-control input-sm" ID="cmbFinReqBranch" runat="server"
                                                AutoPostBack="True">
                                            </asp:DropDownList>
                                            <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" Enabled="false" CssClass="col-xs-12 form-control input-sm" ID="txtFinReqBranchName" runat="server" Visible="False"></asp:TextBox>
                                        </div>
                                        <div class="col-xs-2 control-label">
                                            <asp:Label ID="Label51" runat="server" Text="Branch Code"></asp:Label>
                                        </div>
                                        <div class="col-xs-4">
                                            <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" Enabled="false" CssClass="col-xs-12 form-control input-sm" ID="txtFinReqBranchCode" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-xs-2 control-label hidden">
                                            <asp:Label ID="Label52" runat="server" Text="A/c Number"></asp:Label>
                                        </div>
                                        <div class="col-xs-4 hidden">
                                            <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" Enabled="false" CssClass="col-xs-12 form-control input-sm" ID="txtFinReqAccNo" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-xs-2 control-label">
                                            <asp:Label ID="Label21" runat="server" Text="1st Repayment Date"></asp:Label>
                                        </div>
                                        <div class="col-xs-4">
                                            <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" Enabled="false" ID="bdpFinReqRepaymt" runat="server" CssClass="col-xs-12 form-control input-sm datepicker"></asp:TextBox>
                                            <span class="glyphicon glyphicon-calendar form-control-feedback" style="margin-right: 13px; background-color: #eeeeff; border-radius: 0 3px 3px 0; border: 1px solid rgb(149,188,219); z-index: 0;"></span>
                                        </div>
                                    </div>
                                    <div class="row hidden">
                                        <div class="col-xs-2 control-label">
                                            <asp:Label ID="Label28" runat="server" Text="Disbursement Option"></asp:Label>
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
                                            <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" Enabled="false" CssClass="col-xs-12 form-control input-sm" ID="txtEcocashNumber" runat="server" Visible="False"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row hidden">
                                        <div class="col-xs-2 control-label">
                                            <asp:Label ID="Label90" runat="server" Text="Other Charges"></asp:Label>
                                        </div>
                                        <div class="col-xs-4">
                                            <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" Enabled="false" CssClass="col-xs-12 form-control input-sm" ID="txtFinReqOtherCharges" runat="server" onkeypress="return isnumeric(event)"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row label-info">
                                        <div class="col-xs-12 control-label">
                                            <asp:Label ID="Label77" runat="server" Text="QUESTIONNAIRE & RECOMMENDATION"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-xs-3 control-label">
                                            <asp:Label ID="lblCorpStrOrgChart" runat="server" Text="How did you know about us?"></asp:Label>
                                        </div>
                                        <div class="col-xs-6">
                                            <asp:RadioButtonList ID="rdbQuesHow" runat="server" CssClass="col-xs-12"
                                                RepeatDirection="Horizontal" AutoPostBack="True">
                                                <asp:ListItem Text="Our Employee" Value="Employee"></asp:ListItem>
                                                <asp:ListItem Text="Agent" Value="Agent"></asp:ListItem>
                                                <asp:ListItem Text="Friend" Value="Friend"></asp:ListItem>
                                                <asp:ListItem Text="Media" Value="Media"></asp:ListItem>
                                                <asp:ListItem Text="Others" Value="Others"></asp:ListItem>
                                            </asp:RadioButtonList>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-xs-2 control-label">
                                            <asp:Label ID="lblQuesEmployee" runat="server" Text="Our Employee"></asp:Label>
                                        </div>
                                        <div class="col-xs-4">
                                            <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" Enabled="false" CssClass="col-xs-12 form-control input-sm" ID="txtQuesEmployee" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-xs-4">
                                            <asp:Label ID="lblHROrgDesc" runat="server"
                                                Text="Our Agent" Visible="False"></asp:Label>
                                        </div>
                                        <div class="col-xs-4">
                                            <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" Enabled="false" CssClass="col-xs-12 form-control input-sm" ID="txtQuesAgent" runat="server" Visible="False"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row hidden">
                                        <div class="col-xs-2 control-label">
                                            <asp:Label ID="Label94" runat="server" Text="Recommended Amount"></asp:Label>
                                        </div>
                                        <div class="col-xs-4">
                                            <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" Enabled="false" CssClass="col-xs-12 form-control input-sm" ID="txtRecAmt" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-xs-2 control-label">
                                            <asp:Label ID="Label95" runat="server" Text="Comment"></asp:Label>
                                        </div>
                                        <div class="col-xs-4">
                                            <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" Enabled="false" CssClass="col-xs-12 form-control input-sm" ID="txtComment" runat="server" TextMode="MultiLine"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-xs-12 text-center">
                                            <asp:CheckBox ID="chkTickSSB" Text="Acknowledgement Received"
                                                AutoPostBack="true" runat="server" Visible="False" />
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-xs-12 text-center">
                                            <asp:HyperLink ID="lnkFileUploaded" runat="server"></asp:HyperLink>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-xs-12 text-center">
                                            <asp:Button CssClass="btn btn-primary btn-sm" ID="btnGenAgrmt" runat="server" Text="Generate Agreement" Visible="False" />
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-xs-10">
                                        </div>
                                        <div class="col-xs-2 text-right">
                                            <a class="btn btn-info btnPrevious btn-xs">Previous</a>
                                            <a class="btn btn-info btn-xs disabled">Next</a>
                                        </div>
                                    </div>
                                </div>
                                <div id="product" class="tab-pane fade in">
                                    <div style="height: 15px;"></div>
                                    <div class="row label-info">
                                        <div class="col-xs-12 control-label">
                                            <asp:Label ID="Label78" runat="server" Text="OTHER LOANS, DEBTS, OR OBLIGATIONS"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-xs-12">
                                            <asp:GridView ID="grdOtherLoan" runat="server" HorizontalAlign="Center" AutoGenerateColumns="False" EnableModelValidation="True">
                                                <AlternatingRowStyle CssClass="altrowstyle" />
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Description">
                                                        <EditItemTemplate>
                                                            <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" Enabled="false" CssClass="col-xs-12 form-control input-sm" ID="txtDescEdit" runat="server" Text='<%# Bind("OTHER_DESC") %>'></asp:TextBox>
                                                        </EditItemTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblDesc" runat="server" Text='<%# Bind("OTHER_DESC") %>'></asp:Label>
                                                            <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" Enabled="false" CssClass="col-xs-12 form-control input-sm" ID="txtOtherId" runat="server" Text='<%#Eval("ID")%>'
                                                                Visible="False"></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Account Number">
                                                        <EditItemTemplate>
                                                            <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" Enabled="false" CssClass="col-xs-12 form-control input-sm" ID="txtAccNoEdit" runat="server" Text='<%# Bind("OTHER_ACCNO") %>'></asp:TextBox>
                                                        </EditItemTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblAccNo" runat="server" Text='<%# Bind("OTHER_ACCNO") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Amount">
                                                        <EditItemTemplate>
                                                            <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" Enabled="false" CssClass="col-xs-12 form-control input-sm" ID="txtAmtEdit" runat="server" Text='<%# Bind("OTHER_AMT") %>'></asp:TextBox>
                                                        </EditItemTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblAmt" runat="server" Text='<%# Bind("OTHER_AMT") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                                <HeaderStyle CssClass="headerstyle" HorizontalAlign="center" />
                                                <RowStyle CssClass="rowstyle" />
                                            </asp:GridView>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-xs-10">
                                        </div>
                                        <div class="col-xs-2 text-right">
                                            <a class="btn btn-info btnPrevious btn-xs">Previous</a>
                                            <a class="btn btn-info btnNext btn-xs">Next</a>
                                        </div>
                                    </div>
                                </div>
                                <div id="questionnaire" class="tab-pane fade in">
                                    <div style="height: 15px;"></div>
                                    <div class="row label-info">
                                        <div class="col-xs-12 control-label">
                                            <asp:Label ID="Label91" runat="server" Text="Attach Documents"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-xs-2 control-label">
                                            <asp:Label ID="Label93" runat="server" Text="Document Description"></asp:Label>
                                        </div>
                                        <div class="col-xs-4">
                                            <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" Enabled="false" CssClass="col-xs-12 form-control input-sm" ID="txtDocDesc" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-xs-4">
                                            <asp:FileUpload ID="filAttachApp" runat="server" />
                                        </div>
                                        <div class="col-xs-1">
                                            <asp:Button CssClass="btn btn-primary btn-sm" ID="btnUploadApp" runat="server" Text="Upload" />
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-xs-12 text-center">
                                            <asp:Label ID="lblAppUploadMsg" runat="server" Text=""></asp:Label>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-xs-12">
                                            <asp:GridView ID="grdDocuments" runat="server" HorizontalAlign="Center" AutoGenerateColumns="False" EnableModelValidation="True" Width="90%">
                                                <AlternatingRowStyle CssClass="altrowstyle" />
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Delete">
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="LinkButton1" ToolTip="Delete" AlternateText="Delete" OnClientClick="return isDelete();" CommandName="Delete" runat="server" ImageUrl="~/Credit/Images/recycle.jpg" Height="40px" Width="40px" ImageAlign="Middle" CausesValidation="False" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="View">
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="LinkButton2" ToolTip="View" AlternateText="View" CommandName="Select" runat="server" CommandArgument='<%#Eval("ID")%>' ImageUrl="~/Credit/Images/view3.jpg" Height="40px" Width="40px" ImageAlign="Middle" CausesValidation="False" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Description">
                                                        <EditItemTemplate>
                                                            <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" Enabled="false" CssClass="col-xs-12 form-control input-sm" ID="TextBox1" runat="server" Text='<%# Bind("DOC_DESC") %>'></asp:TextBox>
                                                        </EditItemTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("DOC_DESC") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="File Name">
                                                        <EditItemTemplate>
                                                            <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" Enabled="false" CssClass="col-xs-12 form-control input-sm" ID="TextBox2" runat="server" Text='<%# Bind("DOC_FILENAME") %>'></asp:TextBox>
                                                        </EditItemTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("DOC_FILENAME") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Type">
                                                        <EditItemTemplate>
                                                            <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" Enabled="false" CssClass="col-xs-12 form-control input-sm" ID="TextBox3" runat="server" Text='<%# Bind("DOC_TYPE") %>'></asp:TextBox>
                                                        </EditItemTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="Label3" runat="server" Text='<%# Bind("DOC_TYPE") %>'></asp:Label>
                                                            <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" Enabled="false" CssClass="col-xs-12 form-control input-sm" ID="txtDocId" runat="server" Text='<%#Eval("ID")%>'
                                                                Visible="False"></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                                <HeaderStyle CssClass="headerstyle" HorizontalAlign="center" />
                                                <RowStyle CssClass="rowstyle" />
                                            </asp:GridView>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-xs-10">
                                        </div>
                                        <div class="col-xs-2 text-right">
                                            <a class="btn btn-info btnPrevious btn-xs">Previous</a>
                                            <a class="btn btn-info btnNext btn-xs">Next</a>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-xs-12 text-center">
                                <asp:ValidationSummary ID="ValidationSummary1" runat="server" HeaderText="Please correct the following errors and save again"
                                    ShowMessageBox="false" DisplayMode="List" ShowSummary="true" BackColor="Snow" ForeColor="Red"
                                    Font-Italic="true" ValidationGroup="valIndiv" />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-xs-12 text-center">
                                <asp:Label ID="lblExposureExceededSubmit" runat="server" Text="" ForeColor="red"></asp:Label>
                            </div>
                        </div>
                        <div class="row hidden">
                            <div class="col-xs-12 text-center">
                                <asp:HyperLink ID="lnkAppRating" runat="server" Visible="false">Application Rating</asp:HyperLink>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-xs-12 text-center">
                                <asp:HyperLink ID="lnkAmortizationSchedule" runat="server" Target="_blank">View Amortization Schedule</asp:HyperLink>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-xs-12 text-center">
                                <asp:HyperLink ID="lnkViewAppForm" runat="server" Visible="false">Create/Revise Armotization Schedule</asp:HyperLink>
                            </div>
                        </div>
                    </asp:Panel>
                    <asp:Panel ID="panGroup" runat="server" Visible="False">
                        <div class="row">
                            <div class="col-xs-2 control-label">
                                <asp:Label ID="Label54" runat="server" Text="Group Name"></asp:Label>
                            </div>
                            <div class="col-xs-6">
                                <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" CssClass="col-xs-12 form-control input-sm" ID="txtGrpName" runat="server" Width="165px"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-xs-2 control-label">
                                <asp:Label ID="Label55" runat="server" Text="Full Name of Applicant"></asp:Label>
                            </div>
                            <div class="col-xs-6">
                                <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" CssClass="col-xs-12 form-control input-sm" ID="txtGrpApplicantName" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-xs-2 control-label">
                                <asp:Label ID="Label56" runat="server" Text="Date of Birth"></asp:Label>
                            </div>
                            <div class="col-xs-4">
                                <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" CssClass="col-xs-12 form-control input-sm" ID="txtGrpApplDOB" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-xs-2 control-label">
                                <asp:Label ID="Label57" runat="server" Text="ID Number"></asp:Label>
                            </div>
                            <div class="col-xs-4">
                                <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" CssClass="col-xs-12 form-control input-sm" ID="txtGrpApplID" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-xs-2 control-label">
                                <asp:Label ID="Label58" runat="server" Text="Issue Date"></asp:Label>
                            </div>
                            <div class="col-xs-4">
                                <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" CssClass="col-xs-12 form-control input-sm" ID="txtGrpApplIssueDate" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-xs-2 control-label">
                                <asp:Label ID="Label59" runat="server" Text="Current Address"></asp:Label>
                            </div>
                            <div class="col-xs-4">
                                <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" CssClass="col-xs-12 form-control input-sm" ID="txtGrpApplCurrAdd" runat="server" Width="180px" Rows="2"
                                    TextMode="MultiLine"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-xs-2 control-label">
                                <asp:Label ID="Label60" runat="server" Text="City"></asp:Label>
                            </div>
                            <div class="col-xs-4">
                                <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" CssClass="col-xs-12 form-control input-sm" ID="txtGrpApplCity" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-xs-2 control-label">
                                <asp:Label ID="Label61" runat="server" Text="Phone No."></asp:Label>
                            </div>
                            <div class="col-xs-4">
                                <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" CssClass="col-xs-12 form-control input-sm" ID="txtGrpApplPhone" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-xs-2 control-label">
                                <asp:Label ID="Label62" runat="server" Text="Nationality"></asp:Label>
                            </div>
                            <div class="col-xs-4">
                                <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" CssClass="col-xs-12 form-control input-sm" ID="txtGrpApplNationality" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-xs-2 control-label">
                                <asp:Label ID="Label63" runat="server" Text="Gender"></asp:Label>
                            </div>
                            <div class="col-xs-4">
                                <asp:RadioButtonList Enabled="false" ForeColor="Black" Font-Bold="true" ID="rdbGrpApplGender" runat="server"
                                    RepeatDirection="Horizontal">
                                    <asp:ListItem Text="Male" Value="M"></asp:ListItem>
                                    <asp:ListItem Text="Female" Value="F"></asp:ListItem>
                                </asp:RadioButtonList>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-xs-2 control-label">
                                <asp:Label ID="Label64" runat="server" Text="Line/Type of Business"></asp:Label>
                            </div>
                            <div class="col-xs-4">
                                <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" CssClass="col-xs-12 form-control input-sm" ID="txtGrpApplLineBus" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-xs-2 control-label">
                                <asp:Label ID="Label65" runat="server" Text="Period in Business"></asp:Label>
                            </div>
                            <div class="col-xs-4">
                                <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" CssClass="col-xs-12 form-control input-sm" ID="txtGrpApplPeriodBus" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-xs-2 control-label">
                                <asp:Label ID="Label66" runat="server" Text="Loan Amount Required"></asp:Label>
                            </div>
                            <div class="col-xs-4">
                                <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" CssClass="col-xs-12 form-control input-sm" ID="txtGrpApplLoanAmt" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-xs-2 control-label">
                                <asp:Label ID="Label67" runat="server" Text="Repayment Tenure"></asp:Label>
                            </div>
                            <div class="col-xs-4">
                                <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" CssClass="col-xs-12 form-control input-sm" ID="txtGrpApplRepayTenure" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-xs-2 control-label">
                                <asp:Label ID="Label68" runat="server" Text="Purpose of Loan"></asp:Label>
                            </div>
                            <div class="col-xs-4">
                                <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" CssClass="col-xs-12 form-control input-sm" ID="txtGrpApplPurpose" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-xs-2 control-label">
                                <asp:Label ID="Label1165" runat="server" Text="Interest Rate"></asp:Label>
                            </div>
                            <div class="col-xs-4">
                                <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" CssClass="col-xs-12 form-control input-sm" ID="txtGrpApplInterest" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-xs-2 control-label">
                                <asp:Label ID="Label69" runat="server" Text="Other sources of income"></asp:Label>
                            </div>
                            <div class="col-xs-3">
                                <asp:Label ID="Label70" runat="server" Text="1:" Visible="false"></asp:Label>
                                <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" CssClass="col-xs-12 form-control input-sm" ID="txtGrpApplSrcIncome1" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-xs-3">
                                <asp:Label ID="Label71" runat="server" Text="2:" Visible="false"></asp:Label>
                                <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" CssClass="col-xs-12 form-control input-sm" ID="txtGrpApplSrcIncome2" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-xs-3">
                                <asp:Label ID="Label72" runat="server" Text="3:" Visible="false"></asp:Label>
                                <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" CssClass="col-xs-12 form-control input-sm" ID="txtGrpApplSrcIncome3" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-xs-2 control-label">
                                <asp:Label ID="Label73" runat="server" Text="Other Borrowings"></asp:Label>
                            </div>
                            <div class="col-xs-3">
                                <asp:Label ID="Label74" runat="server" Text="1:" Visible="false"></asp:Label>
                                <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" CssClass="col-xs-12 form-control input-sm" ID="txtGrpApplBorrow1" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-xs-3">
                                <asp:Label ID="Label75" runat="server" Text="2:" Visible="false"></asp:Label>
                                <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" CssClass="col-xs-12 form-control input-sm" ID="txtGrpApplBorrow2" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-xs-3">
                                <asp:Label ID="Label76" runat="server" Text="3:" Visible="false"></asp:Label>
                                <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" CssClass="col-xs-12 form-control input-sm" ID="txtGrpApplBorrow3" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-xs-12 center-block">
                                <asp:GridView ID="grdGrpDeclMembers" runat="server" HorizontalAlign="center">
                                    <AlternatingRowStyle CssClass="altrowstyle" />
                                    <HeaderStyle CssClass="headerstyle" HorizontalAlign="center" />
                                    <RowStyle CssClass="rowstyle" />
                                </asp:GridView>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-xs-12 text-center">
                                <asp:Label ID="Label81" runat="server" Text="Members Expense List (If Applicable)" Font-Bold="True"></asp:Label>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-xs-12 center-block">
                                <asp:GridView ID="grdGrpDeclExpense" runat="server" HorizontalAlign="center">
                                    <AlternatingRowStyle CssClass="altrowstyle" />
                                    <HeaderStyle CssClass="headerstyle" HorizontalAlign="center" />
                                    <RowStyle CssClass="rowstyle" />
                                    <Columns>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </asp:Panel>
                </div>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="grdSearchResults" EventName="RowCommand" />
                <asp:PostBackTrigger ControlID="grdDocuments" />
            </Triggers>
        </asp:UpdatePanel>
    </div>
    <script type="text/javascript">
        $('.datepicker').datepicker({
            format: 'dd MM yyyy',
            todayHighlight: true
        });

        //$(function () {
        //    $("[id*=btnSearchLoan]").bind("click", function () {
        //        $("[id*=btnSearchLoan]").val("Searching Loan...");
        //        $("[id*=btnSearchLoan]").attr("disabled", true);
        //    });
        //});

        $('.nofuturedate').datepicker({
            format: 'dd MM yyyy',
            todayHighlight: true,
            endDate: '+0d'
        });

        $(function () {
            var tabName = $("[id*=TabName]").val() != "" ? $("[id*=TabName]").val() : "applicant";
            $('#Tabs a[href="#' + tabName + '"]').tab('show');
            $("#Tabs a").click(function () {
                $("[id*=TabName]").val($(this).attr("href").replace("#", ""));
            });
        });

        $('.btnNext').click(function () {
            $('.nav-tabs > .active').next('li').find('a').trigger('click');
        });

        $('.btnPrevious').click(function () {
            $('.nav-tabs > .active').prev('li').find('a').trigger('click');
        });
    </script>
</asp:Content>