<%@ Page Language="VB" MasterPageFile="~/Site2.master" AutoEventWireup="false" CodeFile="ApplicationForm.aspx.vb" Inherits="Credit_ApplicationForm" Title="Application Form" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .tooltip-inner {
            max-width: 350px;
            /* If max-width does not work, try using width instead */
            width: 350px;
            text-align: right;
        }

        .tooltip {
            max-width: 350px;
            /* If max-width does not work, try using width instead */
            width: 350px;
            text-align: right;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="panel panel-primary small">
        <div class="panel-heading">
            <h4 class="panel-title">Loan Application Form
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
                    <asp:Label ID="Label92" runat="server" Text="Search Surname"></asp:Label>
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
                    <asp:Label ID="lblIDNo" runat="server" Text="ID Number"></asp:Label>
                    <asp:Label ID="Label123" runat="server" Text="*" ForeColor="Red" Font-Size="Large"></asp:Label>
                </div>
                <div class="col-xs-3">
                    <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtIDNo" runat="server" data-toggle="tooltip" data-placement="top" ToolTip="Valid format: 01-2345678A90"></asp:TextBox>
                    <asp:RegularExpressionValidator Display="dynamic" ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtIDNo" ValidationGroup="valIndiv" ValidationExpression="\d{2}[-]\d{6,7}[a-zA-Z]\d{2}" ErrorMessage="Please enter a valid ID Number"></asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator Display="Dynamic" ID="rfvIDNo" runat="server" ErrorMessage="ID Number is required" ValidationGroup="valIndiv" ControlToValidate="txtIDNo"></asp:RequiredFieldValidator>
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
                <div class="col-xs-2 control-label">
                    <asp:Label ID="Label1" runat="server" Text="Client Type"></asp:Label>
                </div>
                <div class="col-xs-4">
                    <asp:DropDownList CssClass="col-xs-12 form-control input-sm" ID="rdbClientType" runat="server" AutoPostBack="True" Enabled="False">
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
            <asp:HiddenField ID="TabName" runat="server" />
            <div class="row">
                <div class="col-xs-12 center-block">
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
                                            <asp:Image ID="imgClientPhoto" runat="server" Width="140" Height="190" BorderColor="black" BorderStyle="Solid" BorderWidth="1" ImageUrl="~/ClientPhotos/nuetral.jpeg" />
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-xs-2 control-label">
                                            Applicant Category
                                        </div>
                                        <div class="col-xs-6 text-center control-label">
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
                                            <asp:DropDownList ReadOnly="True" ForeColor="Black" Font-Bold="true" CssClass="col-xs-12 form-control input-sm" ID="cmbBankAppType" runat="server" AutoPostBack="true"></asp:DropDownList>
                                        </div>
                                        <div class="col-xs-2 control-label">
                                            Branch
                                        </div>
                                        <div class="col-xs-4">
                                            <asp:DropDownList ReadOnly="True" ForeColor="Black" Font-Bold="true" CssClass="col-xs-12 form-control input-sm" ID="cmbBranchAppType" runat="server"></asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="row" id="divAppTypePDA" runat="server" visible="false">
                                        <div class="col-xs-2 control-label">
                                            Company
                                        </div>
                                        <div class="col-xs-4">
                                            <asp:DropDownList ReadOnly="True" ForeColor="Black" Font-Bold="true" CssClass="col-xs-12 form-control input-sm" ID="cmbPDAAppType" runat="server"></asp:DropDownList>
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
                                            Surname
                                            <asp:Label ID="Label53" runat="server" Text="*" ForeColor="Red" Font-Size="Large"></asp:Label>
                                        </div>
                                        <div class="col-xs-4">
                                            <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" CssClass="col-xs-12 form-control input-sm" ID="txtSurname" runat="server" onkeypress="return isTextOnly(event)"></asp:TextBox>
                                            <asp:RequiredFieldValidator Display="Dynamic" ID="rfvSurname" runat="server" ErrorMessage="Surname is required" ValidationGroup="valIndiv" ControlToValidate="txtSurname"></asp:RequiredFieldValidator>
                                        </div>
                                        <div class="col-xs-2 control-label">
                                            Forenames
                                            <asp:Label ID="Label54" runat="server" Text="*" ForeColor="Red" Font-Size="Large"></asp:Label>
                                        </div>
                                        <div class="col-xs-4">
                                            <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" CssClass="col-xs-12 form-control input-sm" ID="txtForenames" runat="server" onkeypress="return isTextOnly(event)"></asp:TextBox>
                                            <asp:RequiredFieldValidator Display="Dynamic" ID="rfvForenames" runat="server" ErrorMessage="Forename is required" ValidationGroup="valIndiv" ControlToValidate="txtForenames"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-xs-2 control-label">
                                            Sector
                                        </div>
                                        <div class="col-xs-4">
                                            <asp:DropDownList ReadOnly="True" ForeColor="Black" Font-Bold="true" ID="cmbSector" runat="server" CssClass="col-xs-12 form-control input-sm"></asp:DropDownList>
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
                                            Date of Birth
                                            <asp:Label ID="Label56" runat="server" Text="*" ForeColor="Red" Font-Size="Large"></asp:Label>
                                        </div>
                                        <div class="col-xs-4">
                                            <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" ID="bdpDOB" runat="server" CssClass="col-xs-12 form-control input-sm dob"></asp:TextBox>
                                            <span class="glyphicon glyphicon-calendar form-control-feedback" style="margin-right: 13px; background-color: #eeeeff; border-radius: 0 3px 3px 0; border: 1px solid rgb(149,188,219); z-index: 0;"></span>
                                            <asp:RequiredFieldValidator Display="Dynamic" ID="rfvDOB" runat="server" ErrorMessage="Date of Birth is required" ValidationGroup="valIndiv" ControlToValidate="bdpDOB"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-xs-2 control-label">
                                            ID Issue Date
                                        </div>
                                        <div class="col-xs-4">
                                            <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" ID="txtIssDate" runat="server" CssClass="col-xs-12 form-control input-sm nofuturedate"></asp:TextBox>
                                            <span class="glyphicon glyphicon-calendar form-control-feedback" style="margin-right: 13px; background-color: #eeeeff; border-radius: 0 3px 3px 0; border: 1px solid rgb(149,188,219); z-index: 0;"></span>
                                        </div>
                                        <div class="col-xs-2 control-label">
                                            Address
                                            <asp:Label ID="Label57" runat="server" Text="*" ForeColor="Red" Font-Size="Large"></asp:Label>
                                        </div>
                                        <div class="col-xs-4">
                                            <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" CssClass="col-xs-12 form-control input-sm" ID="txtAddress" runat="server" Rows="2"
                                                TextMode="MultiLine"></asp:TextBox>
                                            <asp:RequiredFieldValidator Display="Dynamic" ID="rfvAddress" runat="server" ErrorMessage="Address is required" ValidationGroup="valIndiv" ControlToValidate="txtAddress"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-xs-2 control-label">
                                            Default History
                    <asp:Label ID="Label105" runat="server" Text="*" ForeColor="Red" Font-Size="Large"></asp:Label>
                                        </div>
                                        <div class="col-xs-4">
                                            <asp:DropDownList ReadOnly="True" ForeColor="Black" Font-Bold="true" Enabled="false" CssClass="col-xs-12 form-control input-sm text-uppercase" ID="cmbDefaultHistory" runat="server">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator2" runat="server" ErrorMessage="Default History is required" ValidationGroup="valIndiv" ControlToValidate="cmbDefaultHistory"></asp:RequiredFieldValidator>
                                        </div>
                                        <div class="col-xs-2 control-label">
                                            Employment Type
                    <asp:Label ID="Label111" runat="server" Text="*" ForeColor="Red" Font-Size="Large"></asp:Label>
                                        </div>
                                        <div class="col-xs-4">
                                            <asp:DropDownList ReadOnly="True" ForeColor="Black" Font-Bold="true" Enabled="false" CssClass="col-xs-12 form-control input-sm text-uppercase" ID="cmbEmploymentType" runat="server">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator3" runat="server" ErrorMessage="Employment Type is required" ValidationGroup="valIndiv" ControlToValidate="cmbEmploymentType"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-xs-2 control-label ">
                                            Time at current residence (years)
                    <asp:Label ID="Label112" runat="server" Text="*" ForeColor="Red" Font-Size="Large"></asp:Label>
                                        </div>
                                        <div class="col-xs-4">
                                            <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" Enabled="false" CssClass="col-xs-12 form-control input-sm text-uppercase numeric" ID="txtTimeCurrResidence" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator4" runat="server" ErrorMessage="Time at current residence is required" ValidationGroup="valIndiv" ControlToValidate="txtTimeCurrResidence"></asp:RequiredFieldValidator>
                                        </div>
                                        <div class="col-xs-2 control-label ">
                                            Time at previous residence (years)
                    <asp:Label ID="Label124" runat="server" Text="*" ForeColor="Red" Font-Size="Large"></asp:Label>
                                        </div>
                                        <div class="col-xs-4">
                                            <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" Enabled="false" CssClass="col-xs-12 form-control input-sm text-uppercase numeric" ID="txtTimePrevResidence" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator5" runat="server" ErrorMessage="Time at previous residence is required" ValidationGroup="valIndiv" ControlToValidate="txtTimePrevResidence"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-xs-2 control-label">
                                            Main Income Source
                    <asp:Label ID="Label125" runat="server" Text="*" ForeColor="Red" Font-Size="Large"></asp:Label>
                                        </div>
                                        <div class="col-xs-4">
                                            <asp:DropDownList ReadOnly="True" ForeColor="Black" Font-Bold="true" Enabled="false" CssClass="col-xs-12 form-control input-sm text-uppercase" ID="cmbMainIncomeSource" runat="server">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator6" runat="server" ErrorMessage="Main income source is required" ValidationGroup="valIndiv" ControlToValidate="cmbMainIncomeSource"></asp:RequiredFieldValidator>
                                        </div>
                                        <div class="col-xs-2 control-label">
                                            Other Income Sources
                    <asp:Label ID="Label126" runat="server" Text="*" ForeColor="Red" Font-Size="Large"></asp:Label>
                                        </div>
                                        <div class="col-xs-4">
                                            <asp:DropDownList ReadOnly="True" ForeColor="Black" Font-Bold="true" Enabled="false" CssClass="col-xs-12 form-control input-sm text-uppercase" ID="cmbOtherIncomeSources" runat="server">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator7" runat="server" ErrorMessage="Other income sources is required" ValidationGroup="valIndiv" ControlToValidate="cmbOtherIncomeSources"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-xs-2 control-label ">
                                            Accounts with Other Banks
                    <asp:Label ID="Label127" runat="server" Text="*" ForeColor="Red" Font-Size="Large"></asp:Label>
                                        </div>
                                        <div class="col-xs-4">
                                            <asp:DropDownList ReadOnly="True" ForeColor="Black" Font-Bold="true" Enabled="false" CssClass="col-xs-12 form-control input-sm text-uppercase" ID="cmbAccOtherBanks" runat="server">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator8" runat="server" ErrorMessage="Accounts with other banks is required" ValidationGroup="valIndiv" ControlToValidate="cmbAccOtherBanks"></asp:RequiredFieldValidator>
                                        </div>
                                        <div class="col-xs-2 control-label ">
                                            Other Property Ownership
                    <asp:Label ID="Label128" runat="server" Text="*" ForeColor="Red" Font-Size="Large"></asp:Label>
                                        </div>
                                        <div class="col-xs-4">
                                            <asp:DropDownList ReadOnly="True" ForeColor="Black" Font-Bold="true" Enabled="false" CssClass="col-xs-12 form-control input-sm text-uppercase" ID="cmbOtherPropertyOwnership" runat="server">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator9" runat="server" ErrorMessage="Other property ownership is required" ValidationGroup="valIndiv" ControlToValidate="cmbOtherPropertyOwnership"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-xs-2 control-label">
                                            Date Account was opened
                                        </div>
                                        <div class="col-xs-4">
                                            <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" ID="txtAccOpeningDate" runat="server" CssClass="col-xs-12 form-control input-sm nofuturedate"></asp:TextBox>
                                            <span class="glyphicon glyphicon-calendar form-control-feedback" style="margin-right: 13px; background-color: #eeeeff; border-radius: 0 3px 3px 0; border: 1px solid rgb(149,188,219); z-index: 0;"></span>
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
                                            <asp:DropDownList ReadOnly="True" ForeColor="Black" Font-Bold="true" CssClass="col-xs-12 form-control input-sm" ID="cmbArea" runat="server">
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
                                            <asp:Label ID="Label58" runat="server" Text="*" ForeColor="Red" Font-Size="Large"></asp:Label>
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
                                            <asp:DropDownList ReadOnly="True" ForeColor="Black" Font-Bold="true" CssClass="col-xs-12 form-control input-sm" ID="cmbMaritalStatus" runat="server">
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
                                            <asp:DropDownList ReadOnly="True" ForeColor="Black" Font-Bold="true" CssClass="col-xs-12 form-control input-sm" ID="cmbEducation" runat="server" AutoPostBack="True">
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
                                            <asp:DropDownList ReadOnly="True" ForeColor="Black" Font-Bold="true" CssClass="col-xs-12 form-control input-sm" ID="cmbBank" runat="server" AutoPostBack="true"></asp:DropDownList>
                                        </div>
                                        <div class="col-xs-2 control-label">
                                            Branch
                                        </div>
                                        <div class="col-xs-4">
                                            <asp:DropDownList ReadOnly="True" ForeColor="Black" Font-Bold="true" CssClass="col-xs-12 form-control input-sm" ID="cmbBankBranch" runat="server"></asp:DropDownList>
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
                                            <asp:Label ID="Label4" runat="server" Text="Current Employer"></asp:Label>
                                            <asp:Label ID="Label59" runat="server" Text="*" ForeColor="Red" Font-Size="Large"></asp:Label>
                                        </div>
                                        <div class="col-xs-4">
                                            <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" CssClass="col-xs-12 form-control input-sm" ID="txtCurrEmployer" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator Display="Dynamic" ID="rfvCurrEmployer" runat="server" ErrorMessage="Current Employer is required" ValidationGroup="valIndiv" ControlToValidate="txtCurrEmployer"></asp:RequiredFieldValidator>
                                        </div>
                                        <div class="col-xs-2 control-label">
                                            <asp:Label ID="Label5" runat="server" Text="Employer Address"></asp:Label>
                                            <asp:Label ID="Label60" runat="server" Text="*" ForeColor="Red" Font-Size="Large"></asp:Label>
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
                                            <asp:Label ID="Label15" runat="server" Text="Gross Salary"></asp:Label>
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
                                            <asp:Label ID="Label14" runat="server" Text="GUARANTOR INFORMATION"></asp:Label>
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
                                            <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtGuarName" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-xs-1">
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-xs-2 control-label">
                                            <asp:Label ID="lblPPPDPFullNames" runat="server" Text="Date of Birth"></asp:Label>
                                        </div>
                                        <div class="col-xs-4">
                                            <asp:TextBox ID="bdpGuarDOB" runat="server" CssClass="col-xs-12 form-control input-sm dob"></asp:TextBox>
                                            <span class="glyphicon glyphicon-calendar form-control-feedback" style="margin-right: 13px; background-color: #eeeeff; border-radius: 0 3px 3px 0; border: 1px solid rgb(149,188,219); z-index: 0;"></span>
                                        </div>
                                        <div class="col-xs-2 control-label">
                                            <asp:Label ID="lblPPPDPDOB" runat="server" Text="ID No"></asp:Label>
                                        </div>
                                        <div class="col-xs-4">
                                            <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtGuarIDNo" runat="server" data-toggle="tooltip" data-placement="top" ToolTip="Valid format: 01-2345678A90"></asp:TextBox>
                                            <asp:RegularExpressionValidator Display="dynamic" ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtGuarIDNo" ValidationGroup="valIndiv" ValidationExpression="\d{2}[-]\d{6,7}[a-zA-Z]\d{2}" ErrorMessage="Please enter a valid ID Number for guarantor"></asp:RegularExpressionValidator>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-xs-2 control-label">
                                            <asp:Label ID="Label38" runat="server" Text="Phone"></asp:Label>
                                        </div>
                                        <div class="col-xs-4">
                                            <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtGuarPhone" runat="server" onkeypress="return isPhoneNo(event)"></asp:TextBox>
                                        </div>
                                        <div class="col-xs-2 control-label">
                                            <asp:Label ID="lblPPPDPAge" runat="server" Text="Current Address"></asp:Label>
                                        </div>
                                        <div class="col-xs-4">
                                            <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtGuarCurrAdd" runat="server" TextMode="MultiLine"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-xs-2 control-label">
                                            <asp:Label ID="lblPPPDPSex" runat="server" Text="City"></asp:Label>
                                        </div>
                                        <div class="col-xs-4">
                                            <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtGuarCity" runat="server"></asp:TextBox>
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
                                            <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtGuarMonthRent" runat="server"
                                                onkeypress="return isNumberKey(event)"></asp:TextBox>
                                        </div>
                                        <div class="col-xs-2 control-label">
                                            <asp:Label ID="Label40" runat="server" Text="Period at residence (months)"></asp:Label>
                                        </div>
                                        <div class="col-xs-4">
                                            <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtGuarHomeLength" runat="server"
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
                                            <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtGuarCurrEmp" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-xs-2 control-label">
                                            <asp:Label ID="lblPPPDPAppointmtDate" runat="server" Text="Employer Address"></asp:Label>
                                        </div>
                                        <div class="col-xs-4">
                                            <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtGuarEmpAdd" runat="server" TextMode="MultiLine"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-xs-2 control-label">
                                            <asp:Label ID="Label42" runat="server" Text="Period Employed (months)"></asp:Label>
                                        </div>
                                        <div class="col-xs-4">
                                            <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtGuarEmpLength" runat="server"
                                                onkeypress="return isNumberKey(event)"></asp:TextBox>
                                        </div>
                                        <div class="col-xs-2 control-label">
                                            <asp:Label ID="lblPPPDPYrsBus" runat="server" Text="Phone"></asp:Label>
                                        </div>
                                        <div class="col-xs-4">
                                            <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtGuarEmpPhone" runat="server" onkeypress="return isPhoneNo(event)"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-xs-2 control-label">
                                            <asp:Label ID="lblPPPDPPhBus" runat="server" Text="E-mail"></asp:Label>
                                        </div>
                                        <div class="col-xs-4">
                                            <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtGuarEmpEmail" runat="server"></asp:TextBox>
                                            <asp:RegularExpressionValidator Display="Dynamic" ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtGuarEmpEmail" ValidationExpression="^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z\.][a-zA-Z]{1,3}$" ErrorMessage="Please enter a valid email address"></asp:RegularExpressionValidator>
                                        </div>
                                        <div class="col-xs-2 control-label">
                                            <asp:Label ID="Label43" runat="server" Text="Fax"></asp:Label>
                                        </div>
                                        <div class="col-xs-4">
                                            <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtGuarEmpFax" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-xs-2 control-label">
                                            <asp:Label ID="lblPPPDPMobile" runat="server" Text="Position"></asp:Label>
                                        </div>
                                        <div class="col-xs-4">
                                            <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtGuarEmpPosition" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-xs-2 control-label">
                                            <asp:Label ID="lblPPPDPHome" runat="server" Text="Monthly Salary"></asp:Label>
                                        </div>
                                        <div class="col-xs-4">
                                            <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtGuarEmpSalary" runat="server"
                                                onkeypress="return isNumberKey(event)"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-xs-2 control-label">
                                            <asp:Label ID="Label44" runat="server" Text="Other Income"></asp:Label>
                                        </div>
                                        <div class="col-xs-4">
                                            <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtGuarEmpIncome" runat="server"
                                                onkeypress="return isNumberKey(event)"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row label-info">
                                        <div class="col-xs-12 control-label">
                                            Collateral Offered
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-xs-2 control-label">
                                            Collateral Type
                                        </div>
                                        <div class="col-xs-3">
                                            <asp:DropDownList ID="cmbCollateralType" runat="server" CssClass="col-xs-12 form-control input-sm"></asp:DropDownList>
                                        </div>
                                        <div class="col-xs-1 left">
                                            <button type="button" class="btn btn-info btn-sm" data-toggle="modal" data-target="#CollateralModal">Add</button>
                                        </div>
                                        <div class="col-xs-2 control-label">
                                            Description
                                        </div>
                                        <div class="col-xs-4">
                                            <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtCollateralDesc" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-xs-2 control-label ">
                                            Collateral Value ($)
                                        </div>
                                        <div class="col-xs-4">
                                            <asp:TextBox CssClass="col-xs-12 form-control input-sm numeric" ID="txtCollateralValue" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-xs-1">
                                            <asp:Button ID="btnAddCollateral" runat="server" Text="Add" CssClass="btn btn-primary btn-sm" />
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-xs-12 center-block">
                                            <asp:GridView ID="grdCollateral" runat="server" HorizontalAlign="center" AutoGenerateColumns="false">
                                                <AlternatingRowStyle CssClass="altrowstyle" />
                                                <HeaderStyle CssClass="headerstyle" HorizontalAlign="center" />
                                                <RowStyle CssClass="rowstyle" />
                                                <PagerStyle CssClass="pagination-ys" />
                                                <SelectedRowStyle Font-Bold="true" BackColor="SeaShell" />
                                                <Columns>
                                                    <asp:TemplateField ShowHeader="False">
                                                        <EditItemTemplate>
                                                            <asp:LinkButton ID="lnkUpdate" runat="server" CausesValidation="True"
                                                                CommandName="Update" Text="Update"></asp:LinkButton>
                                                            &nbsp;<asp:LinkButton ID="lnkCancel" runat="server" CausesValidation="False"
                                                                CommandName="Cancel" Text="Cancel"></asp:LinkButton>
                                                        </EditItemTemplate>
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lnkEdit" runat="server" CausesValidation="False"
                                                                CommandName="Edit" Text="Edit"></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField ShowHeader="False">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lnkDelete" runat="server" CausesValidation="False"
                                                                CommandName="Delete" Text="Delete" OnClientClick="return isDelete();"></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Collateral Type">
                                                        <EditItemTemplate>
                                                            <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtCollTypeEdit" runat="server" Text='<%# Bind("CollateralType") %>'></asp:TextBox>
                                                        </EditItemTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblCollType" runat="server" Text='<%# Bind("CollateralType") %>'></asp:Label>
                                                            <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtCollId" runat="server" Text='<%#Eval("ID")%>'
                                                                Visible="False"></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Description">
                                                        <EditItemTemplate>
                                                            <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtCollDescEdit" runat="server" Text='<%# Bind("CollDesc") %>'></asp:TextBox>
                                                        </EditItemTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblCollDesc" runat="server" Text='<%# Bind("CollDesc") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Value">
                                                        <EditItemTemplate>
                                                            <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtValueEdit" runat="server" Text='<%# Bind("Value") %>'></asp:TextBox>
                                                        </EditItemTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblValue" runat="server" Text='<%# Bind("Value") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
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
                                <div id="product" class="tab-pane fade in">
                                    <div style="height: 15px;"></div>
                                    <div class="row label-info">
                                        <div class="col-xs-12 control-label">
                                            <asp:Label ID="Label16" runat="server" Text="OTHER LOANS, DEBTS, OR OBLIGATIONS"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-xs-2 control-label">
                                            <asp:Label ID="lblDSAsAt" runat="server" Text="Description"></asp:Label>
                                        </div>
                                        <div class="col-xs-4">
                                            <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtOtherDesc" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-xs-2 control-label">
                                            <asp:Label ID="lblDSHolderName" runat="server" Text="Account No"></asp:Label>
                                        </div>
                                        <div class="col-xs-4">
                                            <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtOtherAccNo" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-xs-2 control-label">
                                            <asp:Label ID="lblDSReltnToComp" runat="server" Text="Amount"></asp:Label>
                                        </div>
                                        <div class="col-xs-4">
                                            <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtOtherAmt" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-xs-1">
                                            <asp:Button CssClass="btn btn-primary btn-sm" ID="btnAddOtherLoan" runat="server" Text=">>" />
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-xs-12">
                                            <asp:GridView ID="grdOtherLoan" runat="server" HorizontalAlign="Center" AutoGenerateColumns="False" EnableModelValidation="True">
                                                <AlternatingRowStyle CssClass="altrowstyle" />
                                                <Columns>
                                                    <asp:TemplateField ShowHeader="False">
                                                        <EditItemTemplate>
                                                            <asp:LinkButton ID="lnkUpdate" runat="server" CausesValidation="True"
                                                                CommandName="Update" Text="Update"></asp:LinkButton>
                                                            &nbsp;<asp:LinkButton ID="lnkCancel" runat="server" CausesValidation="False"
                                                                CommandName="Cancel" Text="Cancel"></asp:LinkButton>
                                                        </EditItemTemplate>
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lnkEdit" runat="server" CausesValidation="False"
                                                                CommandName="Edit" Text="Edit"></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField ShowHeader="False">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lnkDelete" runat="server" CausesValidation="False"
                                                                CommandName="Delete" Text="Delete" OnClientClick="return isDelete();"></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Description">
                                                        <EditItemTemplate>
                                                            <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtDescEdit" runat="server" Text='<%# Bind("OTHER_DESC") %>'></asp:TextBox>
                                                        </EditItemTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblDesc" runat="server" Text='<%# Bind("OTHER_DESC") %>'></asp:Label>
                                                            <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtOtherId" runat="server" Text='<%#Eval("ID")%>'
                                                                Visible="False"></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Account Number">
                                                        <EditItemTemplate>
                                                            <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtAccNoEdit" runat="server" Text='<%# Bind("OTHER_ACCNO") %>'></asp:TextBox>
                                                        </EditItemTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblAccNo" runat="server" Text='<%# Bind("OTHER_ACCNO") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Amount">
                                                        <EditItemTemplate>
                                                            <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtAmtEdit" runat="server" Text='<%# Bind("OTHER_AMT") %>'></asp:TextBox>
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
                                        <div class="col-xs-2 control-label">
                                            Previous Borrowings
                        <asp:Label ID="Label133" runat="server" Text="*" ForeColor="Red" Font-Size="Large"></asp:Label>
                                        </div>
                                        <div class="col-xs-4">
                                            <asp:DropDownList ID="cmbPrevBorrowings" runat="server" CssClass="col-xs-12 form-control input-sm"></asp:DropDownList>
                                            <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator10" runat="server" ErrorMessage="Previous borrowings is required" ValidationGroup="valIndiv" ControlToValidate="cmbPrevBorrowings"></asp:RequiredFieldValidator>
                                        </div>
                                        <div class="col-xs-2 control-label">
                                            Current Borrowings
                        <asp:Label ID="Label134" runat="server" Text="*" ForeColor="Red" Font-Size="Large"></asp:Label>
                                        </div>
                                        <div class="col-xs-4">
                                            <asp:DropDownList ID="cmbCurrBorrowings" runat="server" CssClass="col-xs-12 form-control input-sm"></asp:DropDownList>
                                            <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator11" runat="server" ErrorMessage="Current borrowings is required" ValidationGroup="valIndiv" ControlToValidate="cmbCurrBorrowings"></asp:RequiredFieldValidator>
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
                                    <div class="row">
                                        <div class="col-xs-2 control-label">
                                            <asp:Label ID="Label18" runat="server" Text="1st Repayment Date"></asp:Label>
                                        </div>
                                        <div class="col-xs-4">
                                            <asp:TextBox ID="bdpFinReqRepaymt" runat="server" CssClass="col-xs-12 form-control input-sm datepicker"></asp:TextBox>
                                            <span class="glyphicon glyphicon-calendar form-control-feedback" style="margin-right: 13px; background-color: #eeeeff; border-radius: 0 3px 3px 0; border: 1px solid rgb(149,188,219); z-index: 0;"></span>
                                        </div>
                                    </div>
                                    <div class="row">
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
                                    <div class="row label-info">
                                        <div class="col-xs-12 control-label">
                                            QUESTIONNAIRE & RECOMMENDATION
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-xs-3 control-label">
                                            How did you know about us?
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
                                            <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtQuesEmployee" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-xs-4">
                                            Our Agent
                                        </div>
                                        <div class="col-xs-4">
                                            <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtQuesAgent" runat="server" Visible="False"></asp:TextBox>
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
                                    <div class="row">
                                        <div class="col-xs-2 control-label">
                                            Recommended Amount
                                        </div>
                                        <div class="col-xs-4">
                                            <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtRecAmt" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-xs-2 control-label">
                                            Comment
                                        </div>
                                        <div class="col-xs-4">
                                            <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtComment" runat="server" TextMode="MultiLine"></asp:TextBox>
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
                                        <div class="col-xs-10">
                                        </div>
                                        <div class="col-xs-2 text-right">
                                            <a class="btn btn-info btnPrevious btn-xs">Previous</a>
                                            <a class="btn btn-info btn-xs disabled">Next</a>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-xs-2 control-label">
                                Owner of Client
                            </div>
                            <div class="col-xs-4">
                                <asp:DropDownList ID="cmbOwner" CssClass="col-xs-12 input-sm form-control" runat="server"></asp:DropDownList>
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
                                <asp:HyperLink ID="lnkAppRating" runat="server" Visible="false">Application Rating</asp:HyperLink>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-xs-12 text-center">
                                <asp:HyperLink ID="lnkAmortizationSchedule" runat="server" Target="_blank" Visible="false">View Amortization Schedule</asp:HyperLink>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-xs-12 text-center">
                                <asp:HyperLink ID="lnkViewAppForm" runat="server" Visible="false">Create/Revise Armotization Schedule</asp:HyperLink>
                            </div>
                        </div>
                    </asp:Panel>
                    <asp:Panel ID="panGroup" runat="server" Visible="False">
                        <asp:MultiView ID="mltGrpApp" runat="server">
                            <asp:View ID="vwGrpAppInfo" runat="server">
                                <div class="row">
                                    <div class="col-xs-2 control-label">
                                        Group Name
                                    </div>
                                    <div class="col-xs-6">
                                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtGrpName" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="row alert-info">
                                    <div class="col-xs-12 control-label">
                                        <asp:Label ID="lblGrdCurrExposure" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-xs-2 control-label">
                                        Line/Type of Business
                                    </div>
                                    <div class="col-xs-4">
                                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtGrpApplLineBus" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-xs-2 control-label">
                                        Period in Business (months)
                                    </div>
                                    <div class="col-xs-4">
                                        <asp:TextBox CssClass="col-xs-12 form-control input-sm numeric" ID="txtGrpApplPeriodBus" runat="server" onkeypress="return isNumberKey(event)"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-xs-2 control-label">
                                        Product
                                    </div>
                                    <div class="col-xs-4">
                                        <asp:DropDownList ID="cmbGrpProduct" CssClass="col-xs-12 form-control input-sm" runat="server" AutoPostBack="true"></asp:DropDownList>
                                    </div>
                                    <div class="col-xs-2 control-label">
                                        Loan Amount Required (US$)
                                    </div>
                                    <div class="col-xs-4">
                                        <asp:TextBox CssClass="col-xs-12 form-control input-sm numeric" ID="txtGrpApplLoanAmt" runat="server" onkeypress="return isNumberKey(event)" onchange="validateInputGrp();"></asp:TextBox>
                                        <asp:HiddenField ID="hidGrpMaxExposure" runat="server" />
                                        <asp:HiddenField ID="hidGrpCurrentExposure" runat="server" />
                                        <asp:HiddenField ID="hidGrpMinLoanAmount" runat="server" />
                                        <asp:HiddenField ID="hidGrpMaxLoanAmount" runat="server" />
                                        <asp:Label ID="lblGrpAmount" runat="server" Text="" ForeColor="red"></asp:Label>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-xs-12 control-label">
                                        <asp:Label ID="lblGrpValAmount" runat="server" Text="" ForeColor="red"></asp:Label>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-xs-2 control-label">
                                        Number of Repayments (Tenure)
                                    </div>
                                    <div class="col-xs-4">
                                        <asp:TextBox CssClass="col-xs-12 form-control input-sm numeric" ID="txtGrpApplRepayTenure" runat="server" onkeypress="return isNumberKey(event)" onchange="validateInputGrp();"></asp:TextBox>
                                        <asp:Label ID="lblGrpTenure" runat="server" Text="" ForeColor="red"></asp:Label>
                                        <asp:HiddenField ID="hidGrpMinTenure" runat="server" />
                                        <asp:HiddenField ID="hidGrpMaxTenure" runat="server" />
                                    </div>
                                    <div class="col-xs-2 control-label">
                                        Repayment Intervals
                                    </div>
                                    <div class="col-xs-2">
                                        <asp:TextBox CssClass="col-xs-12 form-control input-sm numeric" ID="txtGrpRepaymentInterval" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-xs-2">
                                        <asp:DropDownList CssClass="col-xs-12 form-control input-sm" ID="cmbGrpRepaymentInterval" runat="server">
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
                                        <asp:Label ID="lblGrpValTenure" runat="server" Text="" ForeColor="red"></asp:Label>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-xs-2 control-label">
                                        <asp:Label ID="lblGrpAdminRate" runat="server" Text="Application Fees (%)"></asp:Label>
                                    </div>
                                    <div class="col-xs-4">
                                        <asp:TextBox CssClass="col-xs-12 form-control input-sm numeric" ID="txtGrpAdminRate" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-xs-2 control-label">
                                        <asp:Label ID="lblGrpInterestRate" runat="server" Text="Interest Rate (%)"></asp:Label>
                                    </div>
                                    <div class="col-xs-4">
                                        <asp:TextBox CssClass="col-xs-12 form-control input-sm numeric" ID="txtGrpApplInterest" runat="server" onkeypress="return isNumberKey(event)" onchange="validateInputGrp();"></asp:TextBox>
                                        <asp:Label ID="lblGrpInterest" runat="server" Text="" ForeColor="red"></asp:Label>
                                        <asp:HiddenField ID="hidGrpMinInterest" runat="server" />
                                        <asp:HiddenField ID="hidGrpMaxInterest" runat="server" />
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-xs-12 control-label">
                                        <asp:Label ID="lblGrpValInterest" runat="server" Text="" ForeColor="red"></asp:Label>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-xs-2 control-label">
                                        Purpose of Loan
                                    </div>
                                    <div class="col-xs-4 hidden">
                                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtGrpApplPurpose" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-xs-3">
                                        <asp:DropDownList CssClass="col-xs-12 form-control input-sm" ID="cmbGrpFinReqPurpose" runat="server">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-xs-1 left">
                                        <button type="button" class="btn btn-info btn-sm" data-toggle="modal" data-target="#LoanPurposeModal">Add</button>
                                    </div>
                                    <div class="col-xs-2 control-label">
                                        Application Date
                                            <asp:Label runat="server" Text="*" Font-Size="Large" ForeColor="red"></asp:Label>
                                    </div>
                                    <div class="col-xs-4">
                                        <asp:TextBox ID="txtGrpAppDate" runat="server" CssClass="col-xs-12 form-control input-sm nofuturedate"></asp:TextBox>
                                        <span class="glyphicon glyphicon-calendar form-control-feedback" style="margin-right: 13px; background-color: #eeeeff; border-radius: 0 3px 3px 0; border: 1px solid rgb(149,188,219); z-index: 0;"></span>
                                        <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator1" runat="server" ErrorMessage="Application Date is required" Font-Bold="true" ForeColor="Red" ControlToValidate="txtApplicationDate" ValidationGroup="valGrp"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-xs-3 control-label">
                                        Other sources of income
                                    </div>
                                    <div class="col-xs-3">
                                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtGrpApplSrcIncome1" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-xs-3">
                                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtGrpApplSrcIncome2" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-xs-3">
                                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtGrpApplSrcIncome3" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-xs-3 control-label">
                                        Other Borrowings
                                    </div>
                                    <div class="col-xs-3">
                                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtGrpApplBorrow1" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-xs-3">
                                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtGrpApplBorrow2" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-xs-3">
                                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtGrpApplBorrow3" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-xs-2 control-label">
                                        Admin Fees
                                    </div>
                                    <div class="col-xs-4">
                                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtGrpAdminFee" runat="server" onkeypress="return isNumberKey(event)"></asp:TextBox>
                                    </div>
                                    <div class="col-xs-2 control-label">
                                        <asp:CheckBox ID="chkGrpApplSigned" runat="server" Text="Signed" />
                                    </div>
                                </div>
                                <div class="row label-info">
                                    <div class="col-xs-12 control-label">
                                        Member Financial Requirements
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
                                    <div class="col-xs-12 center-block">
                                        <asp:GridView ID="grdGrpDeclMembers" HorizontalAlign="Center" runat="server">
                                            <AlternatingRowStyle CssClass="altrowstyle" />
                                            <HeaderStyle CssClass="headerstyle" HorizontalAlign="center" />
                                            <RowStyle CssClass="rowstyle" />
                                        </asp:GridView>
                                    </div>
                                </div>
                                <div class="row label-info">
                                    <div class="col-xs-12 control-label">
                                        Members Expense List (If Applicable)
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-xs-12">
                                        <asp:GridView ID="grdGrpDeclExpense" HorizontalAlign="Center" runat="server">
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
                                    <div class="col-xs-12 text-center">
                                        <asp:Label ID="lblGrpSubmitError" runat="server" Text="" ForeColor="red"></asp:Label>
                                        <asp:Button CssClass="btn btn-primary btn-sm" ID="btnGrpSubmitApp" runat="server" Text="Submit" ValidationGroup="valGrp" />
                                        <asp:Button CssClass="btn btn-primary btn-sm" ID="btnGrpTerminate" runat="server" Text="Terminate"
                                            Visible="False" />
                                    </div>
                                </div>
                            </asp:View>
                        </asp:MultiView>
                    </asp:Panel>
                    <asp:Panel ID="pnlFarmers" runat="server" Visible="false">
                        <div class="row">
                            <div class="col-xs-2 control-label">
                                Name of Farmers Group
                            </div>
                            <div class="col-xs-6">
                                <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtFarmNameOfGroup" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-xs-2 control-label">
                                Full Name of Applicant
                            </div>
                            <div class="col-xs-4">
                                <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtFarmNameOfApplicant" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-xs-2 control-label">
                                Gender
                            </div>
                            <div class="col-xs-4">
                                <asp:RadioButtonList ID="rdbFarmGender" runat="server" RepeatDirection="Horizontal">
                                    <asp:ListItem Text="Male" Value="M"></asp:ListItem>
                                    <asp:ListItem Text="Female" Value="F"></asp:ListItem>
                                </asp:RadioButtonList>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-xs-2 control-label">
                                Date of Birth
                            </div>
                            <div class="col-xs-4">
                                <asp:TextBox CssClass="col-xs-12 form-control input-sm dob" ID="txtFarmDOB" runat="server"></asp:TextBox>
                                <span class="glyphicon glyphicon-calendar form-control-feedback" style="margin-right: 13px; background-color: #eeeeff; border-radius: 0 3px 3px 0; border: 1px solid rgb(149,188,219);" runat="server"></span>
                            </div>
                            <div class="col-xs-2 control-label">
                                ID Number
                            </div>
                            <div class="col-xs-4">
                                <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtFarmIDNo" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-xs-2 control-label">
                                ID Issue Date
                            </div>
                            <div class="col-xs-4">
                                <asp:TextBox CssClass="col-xs-12 form-control input-sm nofuturedate" ID="txtFarmIssDate" runat="server"></asp:TextBox>
                                <span class="glyphicon glyphicon-calendar form-control-feedback" style="margin-right: 13px; background-color: #eeeeff; border-radius: 0 3px 3px 0; border: 1px solid rgb(149,188,219);" runat="server"></span>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-xs-2 control-label">
                                Current Address
                            </div>
                            <div class="col-xs-4">
                                <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtFarmCurrentAddress" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-xs-2 control-label">
                                Phone No
                            </div>
                            <div class="col-xs-4">
                                <asp:TextBox CssClass="col-xs-12 form-control input-sm phone" ID="txtFarmPhoneNo" runat="server" onkeypress="return isPhoneNo(event)"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-xs-2 control-label">
                                Name of Spouse
                            </div>
                            <div class="col-xs-4">
                                <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtFarmNameOfSpouse" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-xs-2 control-label">
                                ID Number
                            </div>
                            <div class="col-xs-4">
                                <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtFarmSpouseIDNo" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-xs-2 control-label">
                                Current Address of Spouse
                            </div>
                            <div class="col-xs-4">
                                <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtFarmCurrAddressOfSpouse" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-xs-2 control-label">
                                Phone No
                            </div>
                            <div class="col-xs-4">
                                <asp:TextBox CssClass="col-xs-12 form-control input-sm phone" ID="txtFarmSpousePhoneNo" runat="server" onkeypress="return isPhoneNo(event)"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-xs-2 control-label">
                                Monthly Expense($)
                            </div>
                            <div class="col-xs-1">
                                <asp:TextBox CssClass="col-xs-12 form-control input-sm numeric" ID="txtFarmMonthlyExpense" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-xs-2 control-label">
                                Monthly Income($)
                            </div>
                            <div class="col-xs-1">
                                <asp:TextBox CssClass="col-xs-12 form-control input-sm numeric" ID="txtFarmMonthlyIncome" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-xs-2 control-label">
                                Previous Sales($)
                            </div>
                            <div class="col-xs-1">
                                <asp:TextBox CssClass="col-xs-12 form-control input-sm numeric" ID="txtFarmPreviousSales" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-xs-2 control-label">
                                Current Estimate($)
                            </div>
                            <div class="col-xs-1">
                                <asp:TextBox CssClass="col-xs-12 form-control input-sm numeric" ID="txtFarmCurrentEstimate" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-xs-2 control-label">
                                Crops Grown
                            </div>
                            <div class="col-xs-4">
                                <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtFarmCropsGrown" runat="server" Width="280px"></asp:TextBox>
                            </div>
                            <div class="col-xs-2 control-label">
                                Period Farming(months)
                            </div>
                            <div class="col-xs-4">
                                <asp:TextBox CssClass="col-xs-12 form-control input-sm numeric" ID="txtFarmPeriodFarming" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-xs-2 control-label">
                                Loan Amount Required
                            </div>
                            <div class="col-xs-4">
                                <asp:TextBox CssClass="col-xs-12 form-control input-sm numeric" ID="txtFarmLoanAmtReqd" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-xs-2 control-label">
                                Repayment Tenure
                            </div>
                            <div class="col-xs-4">
                                <asp:TextBox CssClass="col-xs-12 form-control input-sm numeric" ID="txtFarmTenure" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-xs-2 control-label">
                                Interest Rate
                            </div>
                            <div class="col-xs-4">
                                <asp:TextBox CssClass="col-xs-12 form-control input-sm numeric" ID="txtFarmIntRate" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-xs-2 control-label">
                                Repayment Date
                            </div>
                            <div class="col-xs-4">
                                <asp:TextBox CssClass="col-xs-12 form-control input-sm datepicker" ID="txtFarmRepayDate" runat="server"></asp:TextBox>
                                <span class="glyphicon glyphicon-calendar form-control-feedback" style="margin-right: 13px; background-color: #eeeeff; border-radius: 0 3px 3px 0; border: 1px solid rgb(149,188,219);" runat="server"></span>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-xs-2 control-label">
                                Other Charges
                            </div>
                            <div class="col-xs-4">
                                <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtFarmOtherCharge" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-xs-2 control-label">
                                Disbursement Option
                            </div>
                            <div class="col-xs-4">
                                <asp:RadioButtonList ID="rdbFarmDisburseOption" runat="server" RepeatDirection="Horizontal" AutoPostBack="True" RepeatLayout="Flow">
                                    <asp:ListItem Text="Cash" Value="Cash"></asp:ListItem>
                                    <asp:ListItem Text="Ecocash" Value="Ecocash"></asp:ListItem>
                                    <asp:ListItem Text="RTGS" Value="RTGS"></asp:ListItem>
                                </asp:RadioButtonList>
                            </div>
                        </div>
                        <div class="row label-info hidden">
                            <div class="col-xs-12">
                                SECURITY ITEMS PLEDGED
                            </div>
                        </div>
                        <div class="row hidden">
                            <div class="col-xs-2 control-label">
                                Item
                            </div>
                            <div class="col-xs-4">
                                <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtFarmSecItem" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-xs-2 control-label">
                                Officer Value
                            </div>
                            <div class="col-xs-2">
                                <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtFarmOfficerValue" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-xs-2">
                                <asp:Button CssClass="btn btn-primary btn-sm" ID="btnFarmAddSec" runat="server" Text="Add Security" />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-xs-12 text-center">
                                <asp:Button CssClass="btn btn-primary btn-sm" ID="btnSaveFarmer" runat="server" Text="Save" />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-xs-12">
                                <asp:GridView ID="grdFarmers" runat="server" HorizontalAlign="Center">
                                    <AlternatingRowStyle CssClass="altrowstyle" />
                                    <HeaderStyle CssClass="headerstyle" HorizontalAlign="center" />
                                    <RowStyle CssClass="rowstyle" />
                                    <Columns>
                                        <asp:CommandField ShowEditButton="True" />
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </asp:Panel>
                </div>
            </div>
            <a data-target="#SubmitModal" role="button" class="btn" data-toggle="modal" id="launchSubmit" style="height: 0;" data-backdrop="static"></a>
        </div>
    </div>
    <div>
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
    <div id="LoanPurposeModal" class="modal fade" role="dialog">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">Add Loan Purpose</h4>
                </div>
                <div class="modal-body panel-body small">
                    <div class="row">
                        <div class="col-xs-2 control-label">
                            Purpose
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
                    <button type="button" class="btn btn-default btn-sm" data-dismiss="modal">Close</button>
                </div>
            </div>
        </div>
    </div>
    <div id="CollateralModal" class="modal fade" role="dialog">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">Add Collateral Type</h4>
                </div>
                <div class="modal-body panel-body small">
                    <div class="row">
                        <div class="col-xs-2 control-label">
                            Type
                        </div>
                        <div class="col-xs-8">
                            <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtCollateralType" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator Display="Dynamic" ID="reqCollType" runat="server" ErrorMessage="Type is required" Font-Bold="true" ForeColor="Red" ControlToValidate="txtCollateralType" ValidationGroup="valCollateral"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-xs-1">
                            <asp:Button CssClass="btn btn-primary btn-sm" ID="btnAddCollateralType" runat="server" Text="Add" ValidationGroup="valCollateral" />
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                </div>
            </div>
        </div>
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
        function showConfirmOtherLoans() {
            bootbox.confirm({
                message: "This customer already has <b><%= getOutstandingLoans(txtCustNo.Text) %></b> running loans. Are you sure you want to give him more money?",
                callback: function (response) {
                    if (response) {
                        //$('#form').submit();
                    } else {
                        window.location.replace('ApplicationForm.aspx');
                    }
                },
                buttons: {
                    'cancel': {
                        label: 'No',
                        className: 'btn-danger'
                    },
                    'confirm': {
                        label: 'Yes',
                        className: 'btn-success pull-right'
                    }
                }
            });
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
        function isEmployeeCode() {

            var regex = "^\d{7}$";

            //var regex = "^\{0-9}{7}$";

            var ECNo = document.getElementById('<%= txtECNo.ClientID%>').value.concat("").toString();

            //if (/^[0-9]{7}$/.test(+ECNo)) {

            if (/^[0-9]{7}$/.test(ECNo) || ECNo == '') {

                return true;

            }

            else {

                //setTimeout(bootbox.alert('Please enter 7 numbers only or leave blank'), 1);

                setTimeout(function () { alert('Please enter 7 numbers only or leave blank'); document.getElementById('<%= txtECNo.ClientID%>').focus(); }, 1);
                return false;

            }

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
            var cst = document.getElementById('<%=txtCustNo.ClientID %>').value;
            var instal = '';
            PageMethods.getMonthlyInstalment(ten, amt, adm, prd, intr, onSucess, onError);
            function onSucess(result) {
                $("#<%= txtMonthlyPayment.ClientID%>").val(result);
                //$("#<%= txtMonthlyPayment.ClientID%>").innerHTML = result;
                instal = result;
                var rnt = document.getElementById('<%=txtRent.ClientID %>').value;
                var sal = document.getElementById('<%=txtEmpSalary.ClientID %>').value;
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

            function tenureGrp() {
                if ($("#<%= cmbGrpProduct.ClientID%>").val() == '') {
                    notify('Select the product type', 'error');
                    $("#<%= txtGrpApplRepayTenure.ClientID%>").val('') = '';
                } else {
                    var tenor = $("#<%= txtGrpApplRepayTenure.ClientID%>").val();
                    var maxTenor = $("#<%= hidGrpMaxTenure.ClientID%>").val();
                    var minTenor = $("#<%= hidGrpMinTenure.ClientID%>").val();
                    //LEFT OFF HERE
                    if (parseFloat(tenor) > parseFloat(maxTenor) || parseFloat(tenor) < parseFloat(minTenor)) {
                        $("#<%= lblGrpTenure.ClientID%>").text('Entered tenure out of range for this product');
                        $("#<%= lblGrpSubmitError.ClientID%>").text('Application cannot be submitted because the entered tenure is out of the allowed range for selected product');
                        $("#<%= btnGrpSubmitApp.ClientID%>").attr("disabled", true);
                    } else {
                        $("#<%= lblGrpTenure.ClientID%>").text('');
                        $("#<%= lblGrpSubmitError.ClientID%>").text('');
                        $("#<%= btnGrpSubmitApp.ClientID%>").attr("disabled", false);
                    }
                }
            }

            function interestGrp() {
                if ($("#<%= cmbGrpProduct.ClientID%>").val() == '') {
                    notify('Select the product type', 'error');
                    $("#<%= txtGrpApplInterest.ClientID%>").val('') = '';
                } else {
                    var intr = $("#<%= txtGrpApplInterest.ClientID%>").val();
                    var maxInt = $("#<%= hidGrpMaxInterest.ClientID%>").val();
                    var minInt = $("#<%= hidGrpMinInterest.ClientID%>").val();

                    if (parseFloat(intr) > parseFloat(maxInt) || parseFloat(intr) < parseFloat(minInt)) {
                        $("#<%= lblGrpInterest.ClientID%>").text('Entered interest rate out of range for this product');
                        $("#<%= lblGrpSubmitError.ClientID%>").text('Application cannot be submitted because the entered interest rate is out of the allowed range for selected product');
                        $("#<%= btnGrpSubmitApp.ClientID%>").attr("disabled", true);
                    } else {
                        $("#<%= lblGrpInterest.ClientID%>").text('');
                        $("#<%= lblGrpSubmitError.ClientID%>").text('');
                        $("#<%= btnGrpSubmitApp.ClientID%>").attr("disabled", false);
                    }
                }
            }

            function exposureGrp() {
                if ($("#<%= cmbGrpProduct.ClientID%>").val() == '') {
                    notify('Select the product type', 'error');
                    $("#<%= txtGrpApplLoanAmt.ClientID%>").val('') = '';
                } else {
                    var amt = $("#<%= txtGrpApplLoanAmt.ClientID%>").val();
                    var maxExp = $("#<%= hidGrpMaxExposure.ClientID%>").val();
                    var currExp = $("#<%= hidGrpCurrentExposure.ClientID%>").val();

                    var maxAmt = $("#<%= hidGrpMaxLoanAmount.ClientID%>").val();
                    var minAmt = $("#<%= hidGrpMinLoanAmount.ClientID%>").val();

                    var res = parseFloat(amt) + parseFloat(currExp);
                    if (parseFloat(amt) > parseFloat(maxAmt) || parseFloat(amt) < parseFloat(minAmt)) {
                        $("#<%= lblGrpAmount.ClientID%>").text('Entered amount out of range for this product');
                        $("#<%= lblGrpSubmitError.ClientID%>").text('Application cannot be submitted because the required amount is out of the allowed range for product');
                        $("#<%= btnGrpSubmitApp.ClientID%>").attr("disabled", true);
                    } else {
                        if (parseFloat(res) > parseFloat(maxExp)) {
                            $("#<%= lblGrpAmount.ClientID%>").text('Entered value will exceed maximum exposure');
                            $("#<%= lblGrpSubmitError.ClientID%>").text('Application cannot be submitted because the required amount will exceed maximum exposure');
                            $("#<%= btnGrpSubmitApp.ClientID%>").attr("disabled", true);
                        } else {
                            $("#<%= lblGrpAmount.ClientID%>").text('');
                            $("#<%= lblGrpSubmitError.ClientID%>").text('');
                            $("#<%= btnGrpSubmitApp.ClientID%>").attr("disabled", false);
                        }
                    }
                }
            }

            function validateInputGrp() {
                exposureGrp();
                tenureGrp();
                interestGrp();
            }

            $(document).ready(function () {
                $('[id*=rdbGracePeriod] input').click(function () {
                    var value = $('[id*=rdbGracePeriod] input:checked').val();
                    if (value == 1) {
                        $("#divGracePeriod").show();
                    }
                    else if (value == 0) {
                        $("#divGracePeriod").hide();
                    }
                    else {
                        $("#divGracePeriod").hide();
                    }
                });
            });

            $(document).ready(function () {
                var value = $('[id*=rdbGracePeriod] input:checked').val();
                if (value == 1) {
                    $("#divGracePeriod").show();
                }
                else if (value == 0) {
                    $("#divGracePeriod").hide();
                }
                else {
                    $("#divGracePeriod").hide();
                }
            });
            $(document).ready(function () {
                $('[id*=rdbRepayWknd] input').click(function () {
                    var value = $('[id*=rdbRepayWknd] input:checked').val();
                    if (value == 0) {
                        $("#divRepayWknd").show();
                    }
                    else if (value == 1) {
                        $("#divRepayWknd").hide();
                    }
                    else {
                        $("#divRepayWknd").hide();
                    }
                });
            });

            $(document).ready(function () {
                var value = $('[id*=rdbRepayWknd] input:checked').val();
                if (value == 0) {
                    $("#divRepayWknd").show();
                }
                else if (value == 1) {
                    $("#divRepayWknd").hide();
                }
                else {
                    $("#divRepayWknd").hide();
                }
            });
            $(function () {
                var value = $('#<%= cmbMaritalStatus.ClientID%>').val();
                if (value == 'Married') {
                    $("#spouseDetails").show();
                } else {
                    $("#spouseDetails").hide();
                }
            });

                $(function () {
                    $('#<%= cmbMaritalStatus.ClientID%>').change(
                function () {
                    var value = $('#<%= cmbMaritalStatus.ClientID%>').val();
                    if (value == 'Married') {
                        $("#spouseDetails").show();
                    } else {
                        $("#spouseDetails").hide();
                    }
                });
                });

                $(document).ready(function () {
                    // Configure to save every 5 seconds
                    window.setInterval(saveDraft, 60000);
                });

                // The magic happens here...
                function saveDraft() {
                    $.ajax({
                        type: "POST",
                        url: "AutoSave.aspx",
                        data: ({
                            username: '<%=Session("UserId") %>',
                            SessionID: '<%=Session("SessionID") %>',
                            page: 'ApplicationForm.aspx',
                            address: $("#<%=txtAddress.ClientID %>").val(),
                            adminRate: $("#<%=txtAdminRate.ClientID %>").val(),
                            city: $("#<%=txtCity.ClientID %>").val(),
                            currEmployer: $("#<%=txtCurrEmployer.ClientID %>").val(),
                            custNo: $("#<%=txtCustNo.ClientID %>").val(),
                            dob: $("#<%=bdpDOB.ClientID %>").val(),
                            ecno: $("#<%=txtECNo.ClientID %>").val(),
                            ecnocd: $("#<%=txtECNoCD.ClientID %>").val(),
                            educationOther: $("#<%=txtEducationOther.ClientID %>").val(),
                            empAddress: $("#<%=txtEmpAddress.ClientID %>").val(),
                            empCity: $("#<%=txtEmpCity.ClientID %>").val(),
                            empEmail: $("#<%=txtEmpEmail.ClientID %>").val(),
                            empFax: $("#<%=txtEmpFax.ClientID %>").val(),
                            empHowLong: $("#<%=txtEmpHowLong.ClientID %>").val(),
                            empOtherIncome: $("#<%=txtEmpOtherIncome.ClientID %>").val(),
                            empPhone: $("#<%=txtEmpPhone.ClientID %>").val(),
                            empPosition: $("#<%=txtEmpPosition.ClientID %>").val(),
                            empSalary: $("#<%=txtEmpSalary.ClientID %>").val(),
                            empSalaryNet: $("#<%=txtEmpSalaryNet.ClientID %>").val(),
                            farmCropsGrown: $("#<%=txtFarmCropsGrown.ClientID %>").val(),
                            farmCurrAddressOfSpouse: $("#<%=txtFarmCurrAddressOfSpouse.ClientID %>").val(),
                            farmCurrentAddress: $("#<%=txtFarmCurrentAddress.ClientID %>").val(),
                            farmCurrentEstimate: $("#<%=txtFarmCurrentEstimate.ClientID %>").val(),
                            farmDOB: $("#<%=txtFarmDOB.ClientID %>").val(),
                            farmIDNo: $("#<%=txtFarmIDNo.ClientID %>").val(),
                            farmIssDate: $("#<%=txtFarmIssDate.ClientID %>").val(),
                            farmMonthlyExpense: $("#<%=txtFarmMonthlyExpense.ClientID %>").val(),
                            farmMonthlyIncome: $("#<%=txtFarmMonthlyIncome.ClientID %>").val(),
                            farmNameOfApplicant: $("#<%=txtFarmNameOfApplicant.ClientID %>").val(),
                            farmNameOfGroup: $("#<%=txtFarmNameOfGroup.ClientID %>").val(),
                            farmNameOfSpouse: $("#<%=txtFarmNameOfSpouse.ClientID %>").val(),
                            farmPeriodFarming: $("#<%=txtFarmPeriodFarming.ClientID %>").val(),
                            farmPhoneNo: $("#<%=txtFarmPhoneNo.ClientID %>").val(),
                            farmPreviousSales: $("#<%=txtFarmPreviousSales.ClientID %>").val(),
                            farmSpouseIDNo: $("#<%=txtFarmSpouseIDNo.ClientID %>").val(),
                            farmSpousePhoneNo: $("#<%=txtFarmSpousePhoneNo.ClientID %>").val(),
                            forenames: $("#<%=txtForenames.ClientID %>").val(),
                            finReqAmt: $("#<%=txtFinReqAmt.ClientID %>").val(),
                            finReqIntRate: $("#<%=txtFinReqIntRate.ClientID %>").val(),
                            finReqPurpose: $("#<%=txtFinReqPurpose.ClientID %>").val(),
                            finReqSource: $("#<%=txtFinReqSource.ClientID %>").val(),
                            finReqTenor: $("#<%=txtFinReqTenor.ClientID %>").val(),
                            grpName: $("#<%=txtGrpName.ClientID %>").val(),
                            guarCity: $("#<%=txtGuarCity.ClientID %>").val(),
                            guarCurrAdd: $("#<%=txtGuarCurrAdd.ClientID %>").val(),
                            guarCurrEmp: $("#<%=txtGuarCurrEmp.ClientID %>").val(),
                            guarEmpAdd: $("#<%=txtGuarEmpAdd.ClientID %>").val(),
                            guarEmpEmail: $("#<%=txtGuarEmpEmail.ClientID %>").val(),
                            guarEmpFax: $("#<%=txtGuarEmpFax.ClientID %>").val(),
                            guarEmpIncome: $("#<%=txtGuarEmpIncome.ClientID %>").val(),
                            guarEmpLength: $("#<%=txtGuarEmpLength.ClientID %>").val(),
                            guarEmpPhone: $("#<%=txtGuarEmpPhone.ClientID %>").val(),
                            guarEmpPosition: $("#<%=txtGuarEmpPosition.ClientID %>").val(),
                            guarEmpSalary: $("#<%=txtGuarEmpSalary.ClientID %>").val(),
                            guarHomeLength: $("#<%=txtGuarHomeLength.ClientID %>").val(),
                            guarIDNo: $("#<%=txtGuarIDNo.ClientID %>").val(),
                            guarMonthRent: $("#<%=txtGuarMonthRent.ClientID %>").val(),
                            guarName: $("#<%=txtGuarName.ClientID %>").val(),
                            guarNameRelative: $("#<%=txtGuarNameRelative.ClientID %>").val(),
                            guarPhone: $("#<%=txtGuarPhone.ClientID %>").val(),
                            guarRelAddress: $("#<%=txtGuarRelAddress.ClientID %>").val(),
                            guarRelCity: $("#<%=txtGuarRelCity.ClientID %>").val(),
                            guarRelPhone: $("#<%=txtGuarRelPhone.ClientID %>").val(),
                            guarRelReltnship: $("#<%=txtGuarRelReltnship.ClientID %>").val(),
                            guarDOB: $("#<%=bdpGuarDOB.ClientID %>").val(),
                            finReqRepaymt: $("#<%=bdpFinReqRepaymt.ClientID %>").val(),
                            houseHowLong: $("#<%=txtHouseHowLong.ClientID %>").val(),
                            idNo: $("#<%=txtIDNo.ClientID %>").val(),
                            issDate: $("#<%=txtIssDate.ClientID %>").val(),
                            minDept: '',
                            minDeptNo: '',
                            nationality: $("#<%=txtNationality.ClientID %>").val(),
                            noChildren: $("#<%=txtNoChildren.ClientID %>").val(),
                            noDependant: $("#<%=txtNoDependant.ClientID %>").val(),
                            otherAppType: $("#<%=txtOtherAppType.ClientID %>").val(),
                            otherAccNo: $("#<%=txtOtherAccNo.ClientID %>").val(),
                            otherAmt: $("#<%=txtOtherAmt.ClientID %>").val(),
                            otherDesc: $("#<%=txtOtherDesc.ClientID %>").val(),
                            phoneNo: $("#<%=txtPhoneNo.ClientID %>").val(),
                            prevEmpAddress: $("#<%=txtPrevEmpAddress.ClientID %>").val(),
                            prevEmpAnnualIncome: $("#<%=txtPrevEmpAnnualIncome.ClientID %>").val(),
                            prevEmpCity: $("#<%=txtPrevEmpCity.ClientID %>").val(),
                            prevEmpEmail: $("#<%=txtPrevEmpEmail.ClientID %>").val(),
                            prevEmpFax: $("#<%=txtPrevEmpFax.ClientID %>").val(),
                            prevEmpHowLong: $("#<%=txtPrevEmpHowLong.ClientID %>").val(),
                            prevEmployer: $("#<%=txtPrevEmployer.ClientID %>").val(),
                            prevEmpPhone: $("#<%=txtPrevEmpPhone.ClientID %>").val(),
                            prevEmpPosition: $("#<%=txtPrevEmpPosition.ClientID %>").val(),
                            prevEmpSalary: $("#<%=txtPrevEmpSalary.ClientID %>").val(),
                            prevEmpSalaryNet: $("#<%=txtPrevEmpSalaryNet.ClientID %>").val(),
                            quesAgent: $("#<%=txtQuesAgent.ClientID %>").val(),
                            quesEmployee: $("#<%=txtQuesEmployee.ClientID %>").val(),
                            recAmt: $("#<%=txtRecAmt.ClientID %>").val(),
                            rent: $("#<%=txtRent.ClientID %>").val(),
                            searchSurname: $("#<%=txtSearchSurname.ClientID %>").val(),
                            spouse: $("#<%=txtSpouse.ClientID %>").val(),
                            spouseEmployer: $("#<%=txtSpouseEmployer.ClientID %>").val(),
                            spouseOccupation: $("#<%=txtSpouseOccupation.ClientID %>").val(),
                            spousePhone: $("#<%=txtSpousePhone.ClientID %>").val(),
                            surname: $("#<%=txtSurname.ClientID %>").val(),
                            tradeRef1: $("#<%=txtTradeRef1.ClientID %>").val(),
                            tradeRef2: $("#<%=txtTradeRef2.ClientID %>").val(),
                            cmbArea: $("#<%=cmbArea.ClientID %>").val(),
                            cmbBankAppType: $("#<%=cmbBankAppType.ClientID %>").val(),
                            cmbBranchAppType: $("#<%=cmbBranchAppType.ClientID %>").val(),
                            cmbEducation: $("#<%=cmbEducation.ClientID %>").val(),
                            cmbMaritalStatus: $("#<%=cmbMaritalStatus.ClientID %>").val(),
                            cmbPDAAppType: $("#<%=cmbPDAAppType.ClientID %>").val(),
                            cmbFinReqPurpose: $("#<%=cmbFinReqPurpose.ClientID %>").val(),
                            ddlAssets: $("#<%=ddlAssets.ClientID %>").val(),
                            rdbClientType: $("#<%=rdbClientType.ClientID %>").val(),
                            rdbFarmGender: $("#<%=rdbFarmGender.ClientID %> input:checked").val(),
                            rdbGender: $("#<%=rdbGender.ClientID %> input:checked").val(),
                            rdbHouse: $("#<%=rdbHouse.ClientID %> input:checked").val(),
                            rdbGuarHomeType: $("#<%=rdbGuarHomeType.ClientID %> input:checked").val(),
                            rdbQuesHow: $("#<%=rdbQuesHow.ClientID %> input:checked").val(),
                            rdbType: $("#<%=rdbType.ClientID %> input:checked").val(),
                            rdbSubIndividual: $("#<%=rdbSubIndividual.ClientID %> input:checked").val(),
                            rdbFarmDisburseOption: $("#<%=rdbFarmDisburseOption.ClientID %> input:checked").val(),
                            lblBranchCode: $("#<%=lblBranchCode.ClientID %>").text(),
                            lblBranchName: $("#<%=lblBranchName.ClientID %>").text()
                        }),
                        success: function (response) {
                            notify('Auto-saved as draft', 'success');
                        }
                    });
                }
    </script>
</asp:Content>