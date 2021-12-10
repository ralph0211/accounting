<%@ Page Title="Lift Blacklist" Language="VB" MasterPageFile="~/Site2.master" AutoEventWireup="false" CodeFile="BlacklistLift.aspx.vb" Inherits="QuestCredit_BlacklistLift" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="panel panel-primary small">
        <div class="panel-heading">
            <h4 class="panel-title">
                <a>Lift Blacklisted Client
                </a>
            </h4>
        </div>
        <div class="panel-body">
            <div class="row">
                <div class="col-xs-1 control-label">
                    <asp:Label ID="Label33" runat="server" Text="Branch"></asp:Label>
                </div>
                <div class="col-xs-4 control-label left">
                    <asp:Label ID="lblBranchCode" runat="server" Text=""></asp:Label>
                    <asp:Label ID="Label35" runat="server" Text="  "></asp:Label>
                    <asp:Label ID="lblBranchName" runat="server" Text=""></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-2 control-label">
                    <asp:Label ID="Label1" runat="server" Text="Client Type"></asp:Label>
                </div>
                <div class="col-xs-4">
                    <asp:DropDownList CssClass="col-xs-12 form-control input-sm" ID="rdbClientType" runat="server" AutoPostBack="True">
                    </asp:DropDownList>
                </div>
                <div class="col-xs-2 control-label">
                    <asp:Label ID="Label2" runat="server" Text="Customer Number"></asp:Label>
                </div>
                <div class="col-xs-2">
                    <asp:TextBox CssClass="col-xs-12 form-control input-sm" Enabled="false" ReadOnly="true" Font-Bold="true" ID="txtCustNo" runat="server"></asp:TextBox>
                </div>
                <div class="col-xs-2">
                </div>
            </div>
            <asp:Panel ID="panIndividual" runat="server">
                <div class="row">
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="Label5" runat="server"
                            Text="Search by Surname"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtSearchSurname" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-xs-1">
                        <asp:Button CssClass="btn btn-primary btn-sm" ID="btnSearchSurname" runat="server" CausesValidation="False"
                            Text="Search" />
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-12 center-block">
                        <asp:GridView ID="grdNames" runat="server" AllowPaging="True" Caption="Blacklisted Clients" EmptyDataText="There are no blacklisted clients"
                            HorizontalAlign="Center" SelectedRowStyle-Font-Bold="true">
                            <AlternatingRowStyle CssClass="altrowstyle" />
                            <HeaderStyle CssClass="headerstyle" HorizontalAlign="center" />
                            <RowStyle CssClass="rowstyle" />
                            <PagerStyle CssClass="pagination-ys" />
                            <Columns>
                                <asp:CommandField ShowSelectButton="true" />
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-2 control-label">
                        Applicant Type
                    </div>
                    <div class="col-xs-4 control-label">
                        <asp:RadioButtonList ID="rdbSubIndividual" runat="server" RepeatDirection="Horizontal" CssClass="col-xs-12" AutoPostBack="true" Enabled="false" ReadOnly="true" Font-Bold="true">
                            <asp:ListItem Text="SSB" Value="SSB"></asp:ListItem>
                            <asp:ListItem Text="Bankers" Value="Bankers"></asp:ListItem>
                            <asp:ListItem Text="PDAs" Value="PDAs"></asp:ListItem>
                            <asp:ListItem Text="Other" Value="Other"></asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="lblEmpCode" runat="server" Text="EC Number"></asp:Label>
                    </div>
                    <div class="col-xs-2">
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" Enabled="false" ReadOnly="true" Font-Bold="true" ID="txtECNo" runat="server"
                            onblur="return isEmployeeCode()" onkeypress="return isnumeric(event)"></asp:TextBox>
                    </div>
                    <div class="col-xs-1">
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" Enabled="false" ReadOnly="true" Font-Bold="true" ID="txtECNoCD" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="row" id="divAppTypeBanker" runat="server" visible="false">
                    <div class="col-xs-2 control-label">
                        Bank
                    </div>
                    <div class="col-xs-4">
                        <asp:DropDownList CssClass="col-xs-12 form-control input-sm" ID="cmbBankAppType" runat="server" AutoPostBack="true" Enabled="false" ReadOnly="true" Font-Bold="true"></asp:DropDownList>
                    </div>
                    <div class="col-xs-2 control-label">
                        Branch
                    </div>
                    <div class="col-xs-4">
                        <asp:DropDownList CssClass="col-xs-12 form-control input-sm" ID="cmbBranchAppType" runat="server" Enabled="false" ReadOnly="true" Font-Bold="true"></asp:DropDownList>
                    </div>
                </div>
                <div class="row" id="divAppTypePDA" runat="server" visible="false">
                    <div class="col-xs-2 control-label">
                        Company
                    </div>
                    <div class="col-xs-4">
                        <asp:DropDownList CssClass="col-xs-12 form-control input-sm" ID="cmbPDAAppType" runat="server" Enabled="false" ReadOnly="true" Font-Bold="true"></asp:DropDownList>
                    </div>
                </div>
                <div class="row" id="divAppTypeOther" runat="server" visible="false">
                    <div class="col-xs-2 control-label">
                        Description
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" Enabled="false" ReadOnly="true" Font-Bold="true" ID="txtOtherAppType" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="lblSurname" runat="server" Text="Surname"></asp:Label>
                        <asp:Label ID="Label3" runat="server" Text="*" ForeColor="Red" Font-Size="Large"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" Enabled="false" ReadOnly="true" Font-Bold="true" ID="txtSurname" runat="server" onkeypress="return isTextOnly(event)"></asp:TextBox>
                    </div>
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="lblForenames" runat="server" Text="Forenames"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" Enabled="false" ReadOnly="true" Font-Bold="true" ID="txtForenames" runat="server" onkeypress="return isTextOnly(event)"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="lblIDNo" runat="server" Text="ID Number"></asp:Label>
                        <asp:Label ID="Label36" runat="server" Text="*" ForeColor="Red" Font-Size="Large"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox ID="txtIDNo" runat="server" AutoPostBack="true" CssClass="col-xs-12 form-control input-sm" data-placement="top" data-toggle="tooltip" ToolTip="Valid format: 01-2345678A90" Enabled="false" ReadOnly="true" Font-Bold="true"></asp:TextBox>
                    </div>
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="lblDOB" runat="server" Text="Date of Birth"></asp:Label>
                        <asp:Label ID="Label37" runat="server" Text="*" ForeColor="Red" Font-Size="Large"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox ID="bdpDOB" runat="server" CssClass="col-xs-12 form-control dob input-sm" Enabled="false" ReadOnly="true" Font-Bold="true"></asp:TextBox>
                        <span class="glyphicon glyphicon-calendar form-control-feedback" style="margin-right: 13px; background-color: #eeeeff; border-radius: 0 3px 3px 0; border: 1px solid rgb(149,188,219); z-index: 0;"></span>
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" Enabled="false" ReadOnly="true" Font-Bold="true" ID="txtDOB" runat="server" Visible="false"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="lblIssDate" runat="server" Text="ID Issue Date"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox ID="bdpIssDate" runat="server" CssClass="col-xs-12 form-control nofuturedate input-sm" Enabled="false" ReadOnly="true" Font-Bold="true"></asp:TextBox>
                        <span class="glyphicon glyphicon-calendar form-control-feedback" style="margin-right: 13px; background-color: #eeeeff; border-radius: 0 3px 3px 0; border: 1px solid rgb(149,188,219); z-index: 0;"></span>
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" Enabled="false" ReadOnly="true" Font-Bold="true" ID="txtIssDate" runat="server" Visible="False"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="lblAddress" runat="server" Text="Address"></asp:Label>
                        <asp:Label ID="Label38" runat="server" Text="*" ForeColor="Red" Font-Size="Large"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" Enabled="false" ReadOnly="true" Font-Bold="true" ID="txtAddress" runat="server" Rows="2"
                            TextMode="MultiLine"></asp:TextBox>
                    </div>
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="Label31" runat="server"
                            Text="Ownership"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:RadioButtonList ID="rdbHouse" runat="server" CssClass="col-xs-12"
                            RepeatDirection="Horizontal" Enabled="false" ReadOnly="true" Font-Bold="true">
                            <asp:ListItem Text="Own" Value="Own"></asp:ListItem>
                            <asp:ListItem Text="Rent" Value="Rent"></asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="Label9" runat="server" Text="Monthly Payment or Rent"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" Enabled="false" ReadOnly="true" Font-Bold="true" ID="txtRent" runat="server"
                            onkeypress="return isnumeric(event)"></asp:TextBox>
                    </div>
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="lblCity" runat="server" Text="City"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" Enabled="false" ReadOnly="true" Font-Bold="true" ID="txtCity" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="Label89" runat="server" Text="Area"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:DropDownList CssClass="col-xs-12 form-control input-sm" ID="cmbArea" runat="server" Enabled="false" ReadOnly="true" Font-Bold="true">
                            <asp:ListItem Text="Urban" Value="Urban"></asp:ListItem>
                            <asp:ListItem Text="Periurban" Value="Periurban"></asp:ListItem>
                            <asp:ListItem Text="Rural" Value="Rural"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="Label6" runat="server" Text="Phone No."></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" Enabled="false" ReadOnly="true" Font-Bold="true" ID="txtPhoneNo" runat="server" onkeypress="return isPhoneNo(event)"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="Label8" runat="server" Text="Gender"></asp:Label>
                        <asp:Label ID="Label39" runat="server" Text="*" ForeColor="Red" Font-Size="Large"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:RadioButtonList ID="rdbGender" runat="server" CssClass="col-xs-12"
                            RepeatDirection="Horizontal" Enabled="false" ReadOnly="true" Font-Bold="true">
                            <asp:ListItem Text="Male" Value="M"></asp:ListItem>
                            <asp:ListItem Text="Female" Value="F"></asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="Label11" runat="server" Text="Marital Status"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:DropDownList CssClass="col-xs-12 form-control input-sm" ID="cmbMaritalStatus" runat="server" Enabled="false" ReadOnly="true" Font-Bold="true">
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
                        <asp:Label ID="Label7" runat="server" Text="Nationality"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" Enabled="false" ReadOnly="true" Font-Bold="true" ID="txtNationality" runat="server" onkeypress="return isTextOnly(event)"></asp:TextBox>
                    </div>
                    <%--<div class="col-xs-2 control-label">
                        <asp:Label ID="Label10" runat="server"
                            Text="How long?(months)"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" Enabled="false" Readonly="true" Font-Bold="true" ID="txtHouseHowLong" runat="server"
                            onkeypress="return isnumeric(event)"></asp:TextBox>
                    </div>--%>
                </div>
                <div class="row">
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="Label12" runat="server"
                            Text="Education"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:DropDownList CssClass="col-xs-12 form-control input-sm" ID="cmbEducation" runat="server" AutoPostBack="True" Enabled="false" ReadOnly="true" Font-Bold="true">
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
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" Enabled="false" ReadOnly="true" Font-Bold="true" ID="txtEducationOther" runat="server" Visible="False"></asp:TextBox>
                    </div>
                </div>
                <div class="row label-info">
                    <div class="col-xs-12 control-label">
                        <asp:Label ID="Label4" runat="server"
                            Text="Employment Information"></asp:Label>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="Label13" runat="server" Text="Current Employer"></asp:Label>
                        <asp:Label ID="Label40" runat="server" Text="*" ForeColor="Red" Font-Size="Large"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" Enabled="false" ReadOnly="true" Font-Bold="true" ID="txtCurrEmployer" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="Label14" runat="server" Text="Employer Address"></asp:Label>
                        <asp:Label ID="Label41" runat="server" Text="*" ForeColor="Red" Font-Size="Large"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" Enabled="false" ReadOnly="true" Font-Bold="true" ID="txtEmpAddress" runat="server" TextMode="MultiLine"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="Label15" runat="server"
                            Text="Employment Period(months)"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" Enabled="false" ReadOnly="true" Font-Bold="true" ID="txtEmpHowLong" runat="server"
                            onkeypress="return isnumeric(event)"></asp:TextBox>
                    </div>
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="Label16" runat="server" Text="Phone"></asp:Label>
                        <asp:Label ID="Label42" runat="server" Text="*" ForeColor="Red" Font-Size="Large"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" Enabled="false" ReadOnly="true" Font-Bold="true" ID="txtEmpPhone" runat="server" onkeypress="return isPhoneNo(event)"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="Label17" runat="server" Text="E-mail"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" Enabled="false" ReadOnly="true" Font-Bold="true" ID="txtEmpEmail" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="Label18" runat="server" Text="Fax"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" Enabled="false" ReadOnly="true" Font-Bold="true" ID="txtEmpFax" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="Label19" runat="server" Text="City"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" Enabled="false" ReadOnly="true" Font-Bold="true" ID="txtEmpCity" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="Label20" runat="server" Text="Position"></asp:Label>
                        <asp:Label ID="Label43" runat="server" Text="*" ForeColor="Red" Font-Size="Large"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" Enabled="false" ReadOnly="true" Font-Bold="true" ID="txtEmpPosition" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="Label21" runat="server" Text="Gross Salary($)"></asp:Label>
                        <asp:Label ID="Label44" runat="server" Text="*" ForeColor="Red" Font-Size="Large"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" Enabled="false" ReadOnly="true" Font-Bold="true" ID="txtEmpSalary" runat="server"
                            onkeypress="return isnumeric(event)" onblur="return netLessThanGross()"></asp:TextBox>
                    </div>
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="Label1121" runat="server" Text="Net Salary($)"></asp:Label>
                        <asp:Label ID="Label45" runat="server" Text="*" ForeColor="Red" Font-Size="Large"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" Enabled="false" ReadOnly="true" Font-Bold="true" ID="txtEmpSalaryNet" runat="server"
                            onkeypress="return isnumeric(event)" onblur="return netLessThanGross()"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="Label22" runat="server" Text="Other Income($)"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" Enabled="false" ReadOnly="true" Font-Bold="true" ID="txtEmpOtherIncome" runat="server"
                            onkeypress="return isnumeric(event)"></asp:TextBox>
                    </div>
                </div>
                <div class="row label-info">
                    <div class="col-xs-12 control-label">
                        <asp:Label ID="Label10" runat="server"
                            Text="Previous Employment"></asp:Label>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="Label113" runat="server"
                            Text="Previous Employer"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" Enabled="false" ReadOnly="true" Font-Bold="true" ID="txtPrevEmployer" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="Label114" runat="server"
                            Text="Address"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" Enabled="false" ReadOnly="true" Font-Bold="true" ID="txtPrevEmpAddress" runat="server" TextMode="MultiLine"></asp:TextBox>
                    </div>
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="Label115" runat="server"
                            Text="Employment Period(months)"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" Enabled="false" ReadOnly="true" Font-Bold="true" ID="txtPrevEmpHowLong" runat="server"
                            onkeypress="return isnumeric(event)"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="Label116" runat="server"
                            Text="Phone"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" Enabled="false" ReadOnly="true" Font-Bold="true" ID="txtPrevEmpPhone" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="Label117" runat="server"
                            Text="E-mail"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" Enabled="false" ReadOnly="true" Font-Bold="true" ID="txtPrevEmpEmail" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="Label118" runat="server"
                            Text="Fax"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" Enabled="false" ReadOnly="true" Font-Bold="true" ID="txtPrevEmpFax" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="Label119" runat="server"
                            Text="City"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" Enabled="false" ReadOnly="true" Font-Bold="true" ID="txtPrevEmpCity" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="Label120" runat="server"
                            Text="Position"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" Enabled="false" ReadOnly="true" Font-Bold="true" ID="txtPrevEmpPosition" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="Label121" runat="server"
                            Text="Gross Salary($)"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" Enabled="false" ReadOnly="true" Font-Bold="true" ID="txtPrevEmpSalary" runat="server"
                            onkeypress="return isnumeric(event)"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="Label111121" runat="server"
                            Text="Net Salary($)"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" Enabled="false" ReadOnly="true" Font-Bold="true" ID="txtPrevEmpSalaryNet" runat="server"
                            onkeypress="return isnumeric(event)"></asp:TextBox>
                    </div>
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="Label122" runat="server"
                            Text="Annual Income($)"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" Enabled="false" ReadOnly="true" Font-Bold="true" ID="txtPrevEmpAnnualIncome" runat="server"
                            onkeypress="return isnumeric(event)"></asp:TextBox>
                    </div>
                </div>
                <div class="row label-info">
                    <div class="col-xs-12 control-label">
                        <asp:Label ID="Label46" runat="server"
                            Text="Spouse Details"></asp:Label>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="Label23" runat="server"
                            Text="Name of spouse"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" Enabled="false" ReadOnly="true" Font-Bold="true" ID="txtSpouse" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="Label24" runat="server"
                            Text="Spouse's Occupation"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" Enabled="false" ReadOnly="true" Font-Bold="true" ID="txtSpouseOccupation" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="Label25" runat="server"
                            Text="Phone"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" Enabled="false" ReadOnly="true" Font-Bold="true" ID="txtSpousePhone" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="Label26" runat="server"
                            Text="Employer"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" Enabled="false" ReadOnly="true" Font-Bold="true" ID="txtSpouseEmployer" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="Label27" runat="server"
                            Text="Number of Children"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" Enabled="false" ReadOnly="true" Font-Bold="true" ID="txtNoChildren" runat="server"
                            onkeypress="return isnumeric(event)"></asp:TextBox>
                    </div>
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="Label28" runat="server"
                            Text="Number of Dependants"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" Enabled="false" ReadOnly="true" Font-Bold="true" ID="txtNoDependant" runat="server"
                            onkeypress="return isnumeric(event)"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="Label29" runat="server"
                            Text="Trade Ref"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:Label ID="Label30" runat="server"
                            Text="1)" Visible="false"></asp:Label>
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" Enabled="false" ReadOnly="true" Font-Bold="true" ID="txtTradeRef1" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-xs-4">
                        <asp:Label ID="Label130" runat="server"
                            Text="2)" Visible="false"></asp:Label>
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" Enabled="false" ReadOnly="true" Font-Bold="true" ID="txtTradeRef2" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="row hidden">
                    <div class="col-xs-2 control-label">
                        Blacklist Reason
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox ID="txtBlacklistReason" runat="server" CssClass="col-xs-12 form-control input-sm" Enabled="false" ReadOnly="true" Font-Bold="true" TextMode="MultiLine"></asp:TextBox>
                    </div>
                    <div class="col-xs-2 control-label">
                        Date Blacklisted
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox ID="txtDateBlacklisted" runat="server" CssClass="col-xs-12 form-control input-sm " Enabled="false" ReadOnly="true" Font-Bold="true"></asp:TextBox>
                        <span class="glyphicon glyphicon-calendar form-control-feedback" style="margin-right: 13px; background-color: #eeeeff; border-radius: 0 3px 3px 0; border: 1px solid rgb(149,188,219); z-index: 0;"></span>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-2 control-label">
                        Lift Reason
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox ID="txtBlacklistLiftReason" runat="server" CssClass="col-xs-12 form-control input-sm" TextMode="MultiLine"></asp:TextBox>
                    </div>
                    <div class="col-xs-2 control-label">
                        Date Lifted
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox ID="txtDateLifted" runat="server" CssClass="col-xs-12 form-control input-sm nofuturedate"></asp:TextBox>
                        <span class="glyphicon glyphicon-calendar form-control-feedback" style="margin-right: 13px; background-color: #eeeeff; border-radius: 0 3px 3px 0; border: 1px solid rgb(149,188,219); z-index: 0;"></span>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-12 text-center">
                        <asp:Button CssClass="btn btn-primary btn-sm" ID="btnSaveName" runat="server" Text="Lift Blacklist"
                            OnClientClick="return isBlacklist();" />
                        <asp:Button CssClass="btn btn-primary btn-sm" ID="btnDeleteName" runat="server" CausesValidation="False"
                            OnClientClick="return isDelete();" Text="Delete" Visible="False" />
                    </div>
                </div>
            </asp:Panel>
            <asp:Panel ID="panGroup" runat="server" Visible="False">
                <div class="row">
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="Label48" runat="server"
                            Text="Search by Group Name"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtSearchGroup" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-xs-1">
                        <asp:Button CssClass="btn btn-primary btn-sm" ID="btnSearchGroup" runat="server" CausesValidation="False"
                            Text="Search" />
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-12 center-block">
                        <asp:GridView ID="grdGroup" runat="server" AllowPaging="True"
                            HorizontalAlign="Center" SelectedRowStyle-Font-Bold="true">
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
                <div class="row">
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="Label34" runat="server" Text="Group Name"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" Enabled="false" ReadOnly="true" Font-Bold="true" ID="txtGrpName" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-xs-2">
                        <asp:Button CssClass="btn btn-primary btn-sm" ID="btnGrpAddGroup" runat="server" Text="Blacklist Client" />
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-12 center-block">
                        <asp:Label ID="lblGrpAdded" runat="server" ForeColor="#FF6600"></asp:Label>
                    </div>
                </div>
                <div class="row label-info">
                    <div class="col-xs-12 control-label">
                        <asp:Label ID="Label32" runat="server" Text="Add Group Members Information" Font-Bold="True"></asp:Label>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="Label74" runat="server" Text="Position"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:DropDownList CssClass="col-xs-12 form-control input-sm" ID="cmbGrpDeclPosition" runat="server" Enabled="false" ReadOnly="true" Font-Bold="true">
                            <asp:ListItem Text="" Value=""></asp:ListItem>
                            <asp:ListItem Text="Chairperson" Value="Chairperson"></asp:ListItem>
                            <asp:ListItem Text="Member" Value="Member"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="Label75" runat="server" Text="Name"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" Enabled="false" ReadOnly="true" Font-Bold="true" ID="txtGrpDeclName" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="Labeld75" runat="server" Text="Gender"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:RadioButtonList ID="rdbGrpGender" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Text="Male" Value="M"></asp:ListItem>
                            <asp:ListItem Text="Female" Value="F"></asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="Label76" runat="server" Text="ID No"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" Enabled="false" ReadOnly="true" Font-Bold="true" ID="txtGrpDeclIDNo" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="Label77" runat="server" Text="Date of Birth"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox ID="bdpGrpDOB" runat="server" CssClass="col-xs-12 form-control dob input-sm" Enabled="false" ReadOnly="true" Font-Bold="true"></asp:TextBox>
                        <span class="glyphicon glyphicon-calendar form-control-feedback" style="margin-right: 13px; background-color: #eeeeff; border-radius: 0 3px 3px 0; border: 1px solid rgb(149,188,219); z-index: 0;"></span>
                    </div>
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="Labelk76" runat="server" Text="Issue Date"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox ID="bdpGrpIssDate" runat="server" CssClass="col-xs-12 form-control nofuturedate input-sm" Enabled="false" ReadOnly="true" Font-Bold="true"></asp:TextBox>
                        <span class="glyphicon glyphicon-calendar form-control-feedback" style="margin-right: 13px; background-color: #eeeeff; border-radius: 0 3px 3px 0; border: 1px solid rgb(149,188,219); z-index: 0;"></span>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="Labelhyu76" runat="server" Text="Address"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" Enabled="false" ReadOnly="true" Font-Bold="true" ID="txtGrpDeclAddress" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="Labeluj77" runat="server" Text="City"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" Enabled="false" ReadOnly="true" Font-Bold="true" ID="txtGrpDeclCity" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="Labelfy76" runat="server" Text="Phone No."></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" Enabled="false" ReadOnly="true" Font-Bold="true" ID="txtGrpDeclPhoneNo" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="Labelfy7876" runat="server" Text="Nationality"></asp:Label>
                    </div>
                    <div class="col-xs-3">
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" Enabled="false" ReadOnly="true" Font-Bold="true" ID="txtGrpDeclNationality" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-xs-1">
                        <asp:Button CssClass="btn btn-primary btn-sm" ID="btnGrpDeclAdd" runat="server" Text="Add" />
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-12 center-block">
                        <asp:Label ID="lblGrpDeclMemberAdded" runat="server" ForeColor="#FF6600"></asp:Label>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-12 center-block">
                        <asp:GridView ID="grdGrpDeclMembers" runat="server" AutoGenerateColumns="False" HorizontalAlign="Center">
                            <AlternatingRowStyle CssClass="altrowstyle" />
                            <HeaderStyle CssClass="headerstyle" HorizontalAlign="center" />
                            <RowStyle CssClass="rowstyle" />
                            <PagerStyle CssClass="pagination-ys" />
                            <Columns>
                                <asp:TemplateField ShowHeader="False">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkGrdGrpDelete" runat="server" CausesValidation="False" CommandName="Delete" Text="Delete"></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ShowHeader="False">
                                    <EditItemTemplate>
                                        <asp:LinkButton ID="lnkGrdGrpUpdate" runat="server" CausesValidation="True" CommandName="Update" Text="Update"></asp:LinkButton>
                                        &nbsp;<asp:LinkButton ID="lnkGrdGrpCancel" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel"></asp:LinkButton>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkGrdGrpEdit" runat="server" CausesValidation="False" CommandName="Edit" Text="Edit"></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField AccessibleHeaderText="ID" HeaderText="ID">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblGrdGrpIDEdit" runat="server" Text='<%# Bind("ID") %>'></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblGrdGrpID" runat="server" Text='<%# Bind("ID") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="POSITION">
                                    <EditItemTemplate>
                                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" Enabled="false" ReadOnly="true" Font-Bold="true" ID="txtGrdGrpPosition" runat="server" Text='<%# Bind("POSITION") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblGrdGrpPosition" runat="server" Text='<%# Bind("POSITION") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="NAME">
                                    <EditItemTemplate>
                                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" Enabled="false" ReadOnly="true" Font-Bold="true" ID="txtGrdGrpName" runat="server" Text='<%# Bind("NAME") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblGrdGrpName" runat="server" Text='<%# Bind("NAME") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ID NUMBER">
                                    <EditItemTemplate>
                                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" Enabled="false" ReadOnly="true" Font-Bold="true" ID="txtGrdGrpIDNo" runat="server" Text='<%# Bind("IDNO") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblGrdGrpIDNo" runat="server" Text='<%# Bind("IDNO") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ADDRESS">
                                    <EditItemTemplate>
                                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" Enabled="false" ReadOnly="true" Font-Bold="true" ID="txtGrdGrpAddress" runat="server" Text='<%# Bind("ADDRESS")%>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblGrdGrpAddress" runat="server" Text='<%# Bind("ADDRESS")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="CITY">
                                    <EditItemTemplate>
                                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" Enabled="false" ReadOnly="true" Font-Bold="true" ID="txtGrdGrpCity" runat="server" Text='<%# Bind("CITY")%>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblGrdGrpCity" runat="server" Text='<%# Bind("CITY")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="DOB">
                                    <EditItemTemplate>
                                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" Enabled="false" ReadOnly="true" Font-Bold="true" ID="txtGrdGrpDOB" runat="server" Text='<%# Bind("DOB")%>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblGrdGrpDOB" runat="server" Text='<%# Bind("DOB")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ISSUE DATE">
                                    <EditItemTemplate>
                                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" Enabled="false" ReadOnly="true" Font-Bold="true" ID="txtGrdGrpIssDate" runat="server" Text='<%# Bind("ISSUE_DATE")%>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblGrdGrpIssDate" runat="server" Text='<%# Bind("ISSUE_DATE")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="PHONE">
                                    <EditItemTemplate>
                                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" Enabled="false" ReadOnly="true" Font-Bold="true" ID="txtGrdGrpPhone" runat="server" Text='<%# Bind("PHONE")%>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblGrdGrpPhone" runat="server" Text='<%# Bind("PHONE")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="NATIONALITY">
                                    <EditItemTemplate>
                                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" Enabled="false" ReadOnly="true" Font-Bold="true" ID="txtGrdGrpNat" runat="server" Text='<%# Bind("NATIONALITY")%>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblGrdGrpNat" runat="server" Text='<%# Bind("NATIONALITY")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="GENDER">
                                    <EditItemTemplate>
                                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" Enabled="false" ReadOnly="true" Font-Bold="true" ID="txtGrdGrpIssGender" runat="server" Text='<%# Bind("GENDER")%>' Width="40px"></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblGrdGrpIssGender" runat="server" Text='<%# Bind("GENDER")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
                <div class="row label-info">
                    <div class="col-xs-12 control-label">
                        <asp:Label ID="Label78" runat="server" Text="Members Expense List (If Applicable)" Font-Bold="True"></asp:Label>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="Label79" runat="server" Text="Member"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:DropDownList CssClass="col-xs-12 form-control input-sm" ID="cmbGrpDeclMember" runat="server"
                            AppendDataBoundItems="True" Enabled="false" ReadOnly="true" Font-Bold="true">
                        </asp:DropDownList>
                    </div>
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="Label80" runat="server" Text="Rent"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" Enabled="false" ReadOnly="true" Font-Bold="true" ID="txtGrpDeclRent" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="Label81" runat="server" Text="Food"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" Enabled="false" ReadOnly="true" Font-Bold="true" ID="txtGrpDeclFood" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="Label82" runat="server" Text="School Fees"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" Enabled="false" ReadOnly="true" Font-Bold="true" ID="txtGrpDeclFees" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="Label83" runat="server" Text="Airtime"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" Enabled="false" ReadOnly="true" Font-Bold="true" ID="txtGrpDeclAirtime" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="Label84" runat="server" Text="Medical Expenses"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" Enabled="false" ReadOnly="true" Font-Bold="true" ID="txtGrpDeclMedical" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="Label85" runat="server" Text="Electricity"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" Enabled="false" ReadOnly="true" Font-Bold="true" ID="txtGrpDeclElectricity" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="Label86" runat="server" Text="Water"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" Enabled="false" ReadOnly="true" Font-Bold="true" ID="txtGrpDeclWater" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="Label87" runat="server" Text="Rates"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" Enabled="false" ReadOnly="true" Font-Bold="true" ID="txtGrpDeclRates" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="Label88" runat="server" Text="City of Harare"></asp:Label>
                    </div>
                    <div class="col-xs-3">
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" Enabled="false" ReadOnly="true" Font-Bold="true" ID="txtGrpDeclCityOfHre" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-xs-1">
                        <asp:Button CssClass="btn btn-primary btn-sm" ID="btnGrpDeclAddExpense" runat="server" Text="Add" />
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-12 center-block">
                        <asp:Label ID="lblGrpExpense" runat="server" Text="" ForeColor="#FF6600"></asp:Label>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-12">
                        <asp:GridView ID="grdGrpDeclExpense" runat="server" HorizontalAlign="Center">
                            <AlternatingRowStyle CssClass="altrowstyle" />
                            <HeaderStyle CssClass="headerstyle" HorizontalAlign="center" />
                            <RowStyle CssClass="rowstyle" />
                        </asp:GridView>
                    </div>
                </div>
            </asp:Panel>
            <asp:Panel ID="pnlFarmers" runat="server" Visible="false">
                <div class="row">
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="Label47" runat="server"
                            Text="Search by Farmer Name"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtSearchFarmer" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-xs-1">
                        <asp:Button CssClass="btn btn-primary btn-sm" ID="btnSearchFarmer" runat="server" CausesValidation="False"
                            Text="Search" />
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-12 center-block">
                        <asp:GridView ID="grdFarmers" runat="server" AllowPaging="True"
                            HorizontalAlign="Center" SelectedRowStyle-Font-Bold="true">
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
                <div class="row">
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="lblFarmNameOfGroup" runat="server" Text="Name of Farmers Group"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" Enabled="false" ReadOnly="true" Font-Bold="true" ID="txtFarmNameOfGroup" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-xs-1">
                        <asp:Button CssClass="btn btn-primary btn-sm" runat="server" ID="btnAddGroup" Text="Add Group" Visible="false" />
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="lblFarmNameOfApplicant" runat="server" Text="Full Name of Applicant"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" Enabled="false" ReadOnly="true" Font-Bold="true" ID="txtFarmNameOfApplicant" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="lblFarmGender" runat="server" Text="Gender"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:RadioButtonList ID="rdbFarmGender" runat="server" RepeatDirection="Horizontal" Enabled="false" ReadOnly="true" Font-Bold="true">
                            <asp:ListItem Text="Male" Value="M"></asp:ListItem>
                            <asp:ListItem Text="Female" Value="F"></asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="lblFarmDOB" runat="server" Text="Date of Birth"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm dob" ID="txtFarmDOB" runat="server" Enabled="false" ReadOnly="true" Font-Bold="true"></asp:TextBox>
                        <span class="glyphicon glyphicon-calendar form-control-feedback" style="margin-right: 13px; background-color: #eeeeff; border-radius: 0 3px 3px 0; border: 1px solid rgb(149,188,219); z-index: 0;"></span>
                    </div>
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="lblFarmIDNo" runat="server" Text="ID Number"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" Enabled="false" ReadOnly="true" Font-Bold="true" ID="txtFarmIDNo" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="lblFarmIssDate" runat="server" Text="ID Issue Date"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm nofuturedate" ID="txtFarmIssDate" runat="server" Enabled="false" ReadOnly="true" Font-Bold="true"></asp:TextBox>
                        <span class="glyphicon glyphicon-calendar form-control-feedback" style="margin-right: 13px; background-color: #eeeeff; border-radius: 0 3px 3px 0; border: 1px solid rgb(149,188,219); z-index: 0;"></span>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="lblFarmCurrentAddress" runat="server" Text="Current Address"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" Enabled="false" ReadOnly="true" Font-Bold="true" ID="txtFarmCurrentAddress" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="lblFarmPhoneNo" runat="server" Text="Phone No"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" Enabled="false" ReadOnly="true" Font-Bold="true" ID="txtFarmPhoneNo" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="lblFarmNameOfSpouse" runat="server" Text="Name of Spouse"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" Enabled="false" ReadOnly="true" Font-Bold="true" ID="txtFarmNameOfSpouse" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="lblFarmSpouseIDNo" runat="server" Text="ID Number"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" Enabled="false" ReadOnly="true" Font-Bold="true" ID="txtFarmSpouseIDNo" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="lblFarmCurrAddressOfSpouse" runat="server" Text="Current Address of Spouse"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" Enabled="false" ReadOnly="true" Font-Bold="true" ID="txtFarmCurrAddressOfSpouse" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="lblFarmSpousePhoneNo" runat="server" Text="Phone No"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" Enabled="false" ReadOnly="true" Font-Bold="true" ID="txtFarmSpousePhoneNo" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="lblFarmMonthlyExpense" runat="server" Text="Monthly Expense($)"></asp:Label>
                    </div>
                    <div class="col-xs-2">
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" Enabled="false" ReadOnly="true" Font-Bold="true" ID="txtFarmMonthlyExpense" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="lblFarmMonthlyIncome" runat="server" Text="Monthly Income($)"></asp:Label>
                    </div>
                    <div class="col-xs-2">
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" Enabled="false" ReadOnly="true" Font-Bold="true" ID="txtFarmMonthlyIncome" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="lblFarmPreviousSales" runat="server" Text="Previous Sales($)"></asp:Label>
                    </div>
                    <div class="col-xs-2">
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" Enabled="false" ReadOnly="true" Font-Bold="true" ID="txtFarmPreviousSales" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="lblFarmCurrentEstimate" runat="server" Text="Current Estimate($)"></asp:Label>
                    </div>
                    <div class="col-xs-2">
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" Enabled="false" ReadOnly="true" Font-Bold="true" ID="txtFarmCurrentEstimate" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="lblFarmCropsGrown" runat="server" Text="Crops Grown"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" Enabled="false" ReadOnly="true" Font-Bold="true" ID="txtFarmCropsGrown" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="lblFarmPeriodFarming" runat="server" Text="Period Farming (months)"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" Enabled="false" ReadOnly="true" Font-Bold="true" ID="txtFarmPeriodFarming" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-12 text-center">
                        <asp:Button CssClass="btn btn-primary btn-sm" ID="btnSaveFarmer" runat="server" Text="Uplift Blacklist" OnClientClick="return isBlacklist();" />
                        <asp:Button CssClass="btn btn-primary btn-sm" ID="btnDeleteFarmer" runat="server" Text="Delete" Visible="false" />
                    </div>
                </div>
            </asp:Panel>
        </div>
    </div>
    <script type="text/javascript">
        $('.nofuturedate').datepicker({
            format: 'dd MM yyyy',
            todayHighlight: true,
            endDate: '+0d'
        });

        function fnOnUpdateValidators() {

        };
    </script>
</asp:Content>