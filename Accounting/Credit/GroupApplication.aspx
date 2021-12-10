<%@ Page Title="Group Loan Application" Language="VB" MasterPageFile="~/Site2.master" AutoEventWireup="false" CodeFile="GroupApplication.aspx.vb" Inherits="Credit_GroupApplication" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="panel panel-primary small">
        <div class="panel-heading">
            <h4 class="panel-title">
                Group Loan Application
            </h4>
        </div>
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
                    <asp:Label ID="Label92" runat="server" Text="Search Group"></asp:Label>
                </div>
                <div class="col-xs-6">
                    <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtSearchGroup" runat="server"></asp:TextBox>
                </div>
                <div class="col-xs-1">
                    <asp:Button CssClass="btn btn-primary btn-sm" ID="btnSearchGroup" runat="server" Text=">>" />
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12 center-block">
                    <asp:ListBox ID="lstGroup" runat="server" AutoPostBack="True" Visible="False" CssClass="col-xs-12"></asp:ListBox>
                </div>
            </div>
                <div class="row">
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="Label34" runat="server" Text="Group Name"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtGrpName" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-xs-2 control-label">
                        Group Account Number
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtGrpAccNo" runat="server"></asp:TextBox>
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
                                <asp:TemplateField HeaderText="Delete" visible="false">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ImageButton1" ToolTip="Delete" AlternateText="Delete" OnClientClick="return isDelete();" CommandName="Delete" runat="server" ImageUrl="~/Credit/Images/recycle.jpg" Height="40px" Width="40px" ImageAlign="Middle" CausesValidation="False" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="View">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ImageButton2" ToolTip="View" AlternateText="View" CommandName="Select" runat="server" CommandArgument='<%#Eval("ID")%>' ImageUrl="~/Credit/Images/view3.jpg" Height="40px" Width="40px" ImageAlign="Middle" CausesValidation="False" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Description">
                                    <EditItemTemplate>
                                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="TextBox4" runat="server" Text='<%# Bind("DOC_DESC") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label4" runat="server" Text='<%# Bind("DOC_DESC") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="File Name">
                                    <EditItemTemplate>
                                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="TextBox5" runat="server" Text='<%# Bind("DOC_FILENAME") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label5" runat="server" Text='<%# Bind("DOC_FILENAME") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Type">
                                    <EditItemTemplate>
                                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="TextBox6" runat="server" Text='<%# Bind("DOC_TYPE") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label6" runat="server" Text='<%# Bind("DOC_TYPE") %>'></asp:Label>
                                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="TextBox7" runat="server" Text='<%#Eval("ID")%>'
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
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="Label93" runat="server" Text="Document Description"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtDocDesc" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-xs-4">
                        <asp:FileUpload ID="filAttachApp" runat="server" />
                    </div>
                    <div class="col-xs-1">
                        <asp:Button CssClass="btn btn-primary btn-sm" ID="btnUploadApp" runat="server" Text="Upload" />
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-12">
                        <asp:GridView ID="grdDocumentsApp" runat="server" HorizontalAlign="Center" AutoGenerateColumns="False" EnableModelValidation="True" Width="90%">
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
                    <div class="col-xs-4">
                        <asp:DropDownList CssClass="col-xs-12 form-control input-sm" ID="cmbFinReqPurpose" runat="server">
                        </asp:DropDownList>
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtFinReqPurpose" runat="server" Visible="False"></asp:TextBox>
                        <asp:RequiredFieldValidator Display="Dynamic" ID="rfvFinReqPurpose" runat="server" ErrorMessage="Loan purpose is required" ValidationGroup="valIndiv" ControlToValidate="cmbFinReqPurpose"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="lblDHHoldingPerc" runat="server" Text="Source of Repayment"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtFinReqSource" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="Label18" runat="server" Text="1st Repayment Date"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox ID="txtFinReqRepaymt" runat="server" CssClass="col-xs-12 form-control input-sm datepicker"></asp:TextBox>
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
                        <asp:TextBox ID="txtApplicationDate" runat="server" CssClass="col-xs-12 form-control input-sm nofuturedate"></asp:TextBox>
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
                        <asp:Repeater ID="repGrpMembers" runat="server">
                            <HeaderTemplate>
                                <table class="row table table-striped table-bordered">
                                    <tr>
                                        <th>
                                            <asp:Label ID="Label99" runat="server" Text="Name"></asp:Label>
                                        </th>
                                        <th>
                                            <asp:Label ID="Label1001" runat="server" Text="Customer Number"></asp:Label>
                                        </th>
                                        <th>
                                            <asp:Label ID="Label100" runat="server" Text="ID Number"></asp:Label>
                                        </th>
                                        <th>
                                            <asp:Label ID="Label101" runat="server" Text="Amount"></asp:Label>
                                        </th>
                                    </tr>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblGrpMemberName" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "NAME")%>'></asp:Label>
                                        <asp:Label ID="lblGrpMemberID" Visible="false" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "ID")%>'></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblGrpMemberCustNo" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "CUSTOMER_NUMBER")%>'></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblGrpMemberIDNo" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "IDNO")%>'></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox CssClass="form-control input-sm" ID="txtGrpMemberAmt" runat="server" Text='0' Width="100px" onkeypress="return isNumberKey(event)"></asp:TextBox>
                                    </td>
                                </tr>
                            </ItemTemplate>
                            <FooterTemplate>
                                </table>
                            </FooterTemplate>
                        </asp:Repeater>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-12 text-center">
                        <asp:Button CssClass="btn btn-primary btn-sm save-btn" ID="btnSubmit" runat="server" Text="Submit" ValidationGroup="valIndiv" UseSubmitBehavior="false" />
                        <asp:Button CssClass="btn btn-primary btn-sm save-btn" ID="btnTerminate" runat="server" OnClientClick="return isTerminate();" Text="Terminate Application" Visible="False" UseSubmitBehavior="false" />
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
    <div>
            <a data-target="#SubmitModal" role="button" class="btn" data-toggle="modal" id="launchSubmit" style="height: 0;" data-backdrop="static"></a>
        <div id="SubmitModal" class="modal fade" role="dialog">
            <div class="modal-dialog">
                <!-- Modal content-->
                <div class="modal-content">
                    <div class="modal-header">
                        <h4 class="modal-title">Loan Submission Successful</h4>
                    </div>
                    <div class="modal-body panel-body small">
                        <h5>The loan application has been submitted successfully with a Loan ID of <b><%= lblTest.Text %></b>.<br />
                            You can now &nbsp;
                        <a href="Amortization.aspx?ID=<%= lblTestEnc.Text %>">Create Armotization Schedule</a>.</h5>
                    </div>
                    <div class="modal-footer">
                    </div>
                </div>
            </div>
        </div>

        <asp:Button CssClass="btn btn-primary btn-sm" ID="btnModalPopup" runat="server" Text="Show Modal Popup" Visible="False" />
        <asp:Label ID="lblTest" runat="server" Text=""></asp:Label>
        <asp:Label ID="lblTestEnc" runat="server" Text=""></asp:Label>
    </div>
    <script type="text/javascript">
        function disableSubmitButton() {
            window.setTimeout(function () {
                $("#<%= btnSubmit.ClientID%>").disabled = true;
            }, 1);
        };

        function showPopup() {
            $("#launchSubmit").click();
        }

        function showLogin() {
            $("#modal_dialog").load("popApplicationApproval.aspx", function () {
                $(this).dialog({
                    modal: true,
                    height: 200
                });
                return false;
            })
        }
        //setTimeout("showLogin();", 3000);
        function isDelete() {
            return confirm("Are you sure you want to delete this record?");
        }
        function isTerminate() {
            return confirm("Are you sure you want to terminate this application?");
        }

        $(function () {
            $("[id*=btnSaveLoginParameters]").bind("click", function () {
                $("[id*=btnSaveLoginParameters]").val("Saving...");
                $("[id*=btnSaveLoginParameters]").attr("disabled", true);
            });
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
            getInstalment();
        }

        function getInstalment() {
            var amt = document.getElementById('<%=txtFinReqAmt.ClientID %>').value;
            var prd = document.getElementById('<%=cmbProductType.ClientID %>').value;
            var ten = document.getElementById('<%=txtFinReqTenor.ClientID %>').value;
            var adm = document.getElementById('<%=txtAdminRate.ClientID %>').value;
            var intr = document.getElementById('<%=txtFinReqIntRate.ClientID %>').value;
            var cst = document.getElementById('<%=txtGrpAccNo.ClientID %>').value;
            var instal = '';
            PageMethods.getMonthlyInstalment(ten, amt, adm, prd, intr, onSucess, onError);
            function onSucess(result) {
                $("#<%= txtMonthlyPayment.ClientID%>").val(result);
                //$("#<%= txtMonthlyPayment.ClientID%>").innerHTML = result;
                instal = result;
                var rnt =0;
                var sal = 0;
                var inst = document.getElementById('<%=txtMonthlyPayment.ClientID %>').value;
                //alert(rnt);
                //alert(sal);
                PageMethods.getDBR(cst, prd, rnt, sal, instal, onSucess1, onError1);
                function onSucess1(result) {
                    $("#<%= txtDBR.ClientID%>").val(result);
                    //alert(result);
                }
                function onError1(result) {
                    alert('Something wrong.');
                }
                }
                function onError(result) {
                    //alert('Something wrong.');
                }

            }
    </script>
</asp:Content>

