<%@ Page Title="Group Application Approval" Language="VB" MasterPageFile="~/Site2.master" AutoEventWireup="false" CodeFile="GroupApproval.aspx.vb" Inherits="Credit_GroupApproval" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="panel panel-primary small">
        <div class="panel-heading">
            <h4 class="panel-title">
                Group Loan Application Approval
            </h4>
        </div>
        <div class="panel-body">
            <div class="row label-info">
                <div class="col-xs-12 control-label">
                    <asp:Label ID="Label4" runat="server" Text="APPLICATION HISTORY"></asp:Label>
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
                        <asp:Label ID="Label34" runat="server" Text="Group Name"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtGrpName" runat="server" Enabled="false" Font-Bold="true"></asp:TextBox>
                    </div>
                    <div class="col-xs-2 control-label">
                        Group Account Number
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtGrpAccNo" runat="server" Enabled="false" Font-Bold="true"></asp:TextBox>
                    </div>
                </div>
                <div class="row label-info">
                    <div class="col-xs-12 control-label">
                        <asp:Label ID="Label32" runat="server" Text="Add Group Members"></asp:Label>
                    </div>
                </div>
                <div class="row alert-danger">
                    <div class="col-xs-12 control-label">
                        <asp:Label ID="lblGrpMemberCount" runat="server" Text=""></asp:Label>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-2 control-label">
                        Chairperson
                    </div>
                    <div class="col-xs-4 control-label">
                        <asp:Label ID="lblGrpChair" runat="server" Text=""></asp:Label>
                    </div>
                    <div class="col-xs-2 control-label">
                        Group Members
                    </div>
                    <div class="col-xs-4 control-label">
                        <asp:Label ID="lblGrpMembers" runat="server" Text=""></asp:Label>
                    </div>
                </div>
                <div class="row label-info">
                    <div class="col-xs-12 control-label">
                        Group Documentation
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-12">
                        <asp:GridView ID="grdDocuments" runat="server" HorizontalAlign="Center" AutoGenerateColumns="False" EnableModelValidation="True" Width="90%">
                            <AlternatingRowStyle CssClass="altrowstyle" />
                            <Columns>
                                <asp:TemplateField HeaderText="Delete" Visible="false">
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
                                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="TextBox1" runat="server" Text='<%# Bind("DOC_DESC") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("DOC_DESC") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="File Name">
                                    <EditItemTemplate>
                                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="TextBox2" runat="server" Text='<%# Bind("DOC_FILENAME") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("DOC_FILENAME") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Type">
                                    <EditItemTemplate>
                                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="TextBox3" runat="server" Text='<%# Bind("DOC_TYPE") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("DOC_TYPE") %>'></asp:Label>
                                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtDocId" runat="server" Text='<%#Eval("ID")%>'
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
                    <div class="col-xs-12">
                        <asp:GridView ID="grdDocumentsApp" runat="server" HorizontalAlign="Center" AutoGenerateColumns="False" EnableModelValidation="True" Width="90%">
                            <AlternatingRowStyle CssClass="altrowstyle" />
                            <Columns>
                                <asp:TemplateField HeaderText="Delete" Visible="false">
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
                                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="TextBox1" runat="server" Text='<%# Bind("DOC_DESC") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("DOC_DESC") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="File Name">
                                    <EditItemTemplate>
                                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="TextBox2" runat="server" Text='<%# Bind("DOC_FILENAME") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("DOC_FILENAME") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Type">
                                    <EditItemTemplate>
                                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="TextBox3" runat="server" Text='<%# Bind("DOC_TYPE") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("DOC_TYPE") %>'></asp:Label>
                                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtDocId" runat="server" Text='<%#Eval("ID")%>'
                                            Visible="False"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <HeaderStyle CssClass="headerstyle" HorizontalAlign="center" />
                            <RowStyle CssClass="rowstyle" />
                        </asp:GridView>
                    </div>
                </div>
                <div class="row label-info">
                    <div class="col-xs-12 control-label">
                        Group Financial Requirements
                    </div>
                </div>
                <div class="row alert-info">
                    <div class="col-xs-12 control-label">
                        <asp:Label ID="lblCurrExposure" runat="server" Text=""></asp:Label>
                    </div>
                </div>
                <div class="row hidden">
                    <div class="col-xs-2 control-label">
                        Loan Cycle
                    </div>
                    <div class="col-xs-4 control-label">
                        <asp:Label ID="lblLoanCycle" runat="server" Text="0"></asp:Label>
                    </div>
                    <div class="col-xs-2 control-label">
                        <asp:CheckBox runat="server" ID="chkExtension" Text="Extension"></asp:CheckBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="Label55" runat="server" Text="Product Type"></asp:Label>
                        <asp:Label ID="Label104" runat="server" Text="*" ForeColor="Red" Font-Size="Large"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:DropDownList CssClass="col-xs-12 form-control input-sm" ID="cmbProductType" runat="server" AutoPostBack="true" Enabled="false" Font-Bold="true"></asp:DropDownList>
                        <asp:RequiredFieldValidator Display="Dynamic" ID="rfvProductType" runat="server" ErrorMessage="Product type is required" ValidationGroup="valIndiv" ControlToValidate="cmbProductType"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="lblDHAsAt" runat="server" Text="Amount Required ($)"></asp:Label>
                        <asp:Label ID="Label108" runat="server" Text="*" ForeColor="Red" Font-Size="Large"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm numeric" ID="txtFinReqAmt" runat="server" onchange="validateInput();" Enabled="false" Font-Bold="true"></asp:TextBox>
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
                <div class="row">
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="lblAsset" runat="server" Text="Asset" Visible="false"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:DropDownList CssClass="col-xs-12 form-control input-sm" ID="ddlAssets" runat="server" AutoPostBack="true" Visible="false" Enabled="false" Font-Bold="true">
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
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm numeric" ID="txtFinReqTenor" runat="server" onchange="validateInput();" Enabled="false" Font-Bold="true"></asp:TextBox>
                        <asp:Label ID="lblTenure" runat="server" Text="" ForeColor="red"></asp:Label>
                        <asp:RequiredFieldValidator Display="Dynamic" ID="rfvFinReqTenor" runat="server" ErrorMessage="Loan Tenor is required" ValidationGroup="valIndiv" ControlToValidate="txtFinReqTenor"></asp:RequiredFieldValidator>
                        <asp:HiddenField ID="hidMaxTenure" runat="server" />
                        <asp:HiddenField ID="hidMinTenure" runat="server" />
                    </div>
                    <div class="col-xs-2 control-label">
                        Repayment Intervals
                    </div>
                    <div class="col-xs-2">
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm numeric" ID="txtRepaymentInterval" runat="server" Enabled="false" Font-Bold="true"></asp:TextBox>
                    </div>
                    <div class="col-xs-2">
                        <asp:DropDownList CssClass="col-xs-12 form-control input-sm" ID="cmbRepaymentInterval" runat="server" Enabled="false" Font-Bold="true">
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
                <div class="row">
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="lblAdminRate" runat="server" Text="Application Fees (%)"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm numeric" ID="txtAdminRate" runat="server" Enabled="false" Font-Bold="true"></asp:TextBox>
                    </div>
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="lblInterestRate" runat="server" Text="Interest Rate (%)"></asp:Label>
                        <asp:Label ID="Label103" runat="server" Text="*" ForeColor="Red" Font-Size="Large"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm numeric" ID="txtFinReqIntRate" runat="server" onchange="validateInput();" Enabled="false" Font-Bold="true"></asp:TextBox><%--onkeyup="sum();"--%>
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
                    <div class="col-xs-4">
                        <asp:DropDownList CssClass="col-xs-12 form-control input-sm" ID="cmbFinReqPurpose" runat="server" Enabled="false" Font-Bold="true">
                        </asp:DropDownList>
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtFinReqPurpose" runat="server" Visible="False"></asp:TextBox>
                        <asp:RequiredFieldValidator Display="Dynamic" ID="rfvFinReqPurpose" runat="server" ErrorMessage="Loan purpose is required" ValidationGroup="valIndiv" ControlToValidate="cmbFinReqPurpose"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="lblDHHoldingPerc" runat="server" Text="Source of Repayment"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtFinReqSource" runat="server" Enabled="false" Font-Bold="true"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="Label18" runat="server" Text="1st Repayment Date"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox ID="txtFinReqRepaymt" runat="server" CssClass="col-xs-12 form-control input-sm datepicker" Enabled="false" Font-Bold="true"></asp:TextBox>
                        <span class="glyphicon glyphicon-calendar form-control-feedback" style="margin-right: 13px; background-color: #eeeeff; border-radius: 0 3px 3px 0; border: 1px solid rgb(149,188,219); z-index: 0;"></span>
                    </div>
                </div>
                <div class="row hidden">
                    <div class="col-xs-2 control-label">
                        Monthly Instalment
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox Font-Bold="true" CssClass="col-xs-12 form-control input-sm text-uppercase" ID="txtMonthlyPayment" runat="server" onkeypress="return isnumeric(event)"></asp:TextBox>
                    </div>
                    <div class="col-xs-2 control-label">
                        DBR (%)
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox Font-Bold="true" CssClass="col-xs-12 form-control input-sm text-uppercase" ID="txtDBR" runat="server" onkeypress="return isnumeric(event)"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-2 control-label">
                        Application Date
                        <asp:Label runat="server" Text="*" Font-Size="Large" ForeColor="red"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox ID="txtApplicationDate" runat="server" CssClass="col-xs-12 form-control input-sm nofuturedate" Enabled="false" Font-Bold="true"></asp:TextBox>
                        <span class="glyphicon glyphicon-calendar form-control-feedback" style="margin-right: 13px; background-color: #eeeeff; border-radius: 0 3px 3px 0; border: 1px solid rgb(149,188,219); z-index: 0;"></span>
                        <asp:RequiredFieldValidator Display="Dynamic" ID="rfvAppDate" runat="server" ErrorMessage="Application Date is required" Font-Bold="true" ForeColor="Red" ControlToValidate="txtApplicationDate" ValidationGroup="valIndiv"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="row label-info">
                    <div class="col-xs-12 control-label">
                        Individual Financial Requirements
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-12 center-block">
                        <asp:GridView ID="grdIndivFinReq" runat="server" HorizontalAlign="center">
                            <AlternatingRowStyle CssClass="altrowstyle" />
                            <HeaderStyle CssClass="headerstyle" HorizontalAlign="center" />
                            <RowStyle CssClass="rowstyle" />
                            <Columns>
                                <%--<asp:CommandField ShowEditButton="True" />--%>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="Label94" runat="server" Text="Recommended Amount"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtRecAmt" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="Label95" runat="server" Text="Comment"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtComment" runat="server" TextMode="MultiLine"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-12 text-center">
                        <asp:Button CssClass="btn btn-primary btn-sm" ID="btnSubmit" runat="server" Text="Recommend" UseSubmitBehavior="false" />
                        <asp:Button CssClass="btn btn-danger btn-sm" ID="btnReject" runat="server" Text="Reject" UseSubmitBehavior="false" />
                        <%--<asp:Button CssClass="btn btn-primary btn-sm" ID="btnTerminate" runat="server" OnClientClick="return isTerminate();" Text="Terminate Application" Visible="False" />--%>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-12 text-center">
                        <asp:Label ID="lblExposureExceededSubmit" runat="server" Text="" ForeColor="red"></asp:Label>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-12 text-center">
                        <asp:HyperLink ID="lnkAmortizationSchedule" runat="server" Target="_blank" Visible="false">View Amortization Schedule</asp:HyperLink>
                    </div>
                </div>
            </div>
        </div>
</asp:Content>

