<%@ Page Title="Static Details Authorization" Language="VB" MasterPageFile="~/Site2.master" AutoEventWireup="false" CodeFile="NamesAuthorization.aspx.vb" Inherits="Credit_NamesAuthorization" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel" runat="server">
        <ContentTemplate>
            <div class="panel panel-primary small">
                <div class="panel-heading">
                    <h4 class="panel-title">
                        <a>Authorise Static Details</a>
                    </h4>
                </div>
                <asp:HiddenField ID="TabName" runat="server" />
                <div class="panel-body">
                    <div class="row">
                        <div class="col-xs-12 center-block">
                            <asp:GridView ID="grdAuthorization"
                                runat="server" AllowPaging="True"
                                AllowSorting="True" AutoGenerateColumns="False" DataSourceID="AuthorizationsDS" HorizontalAlign="center"
                                OnDataBound="grdAuthorization_SelectedIndexChanged" OnSelectedIndexChanged="grdAuthorization_SelectedIndexChanged"
                                SelectedRowStyle-Font-Bold="true" Width="90%">
                                <AlternatingRowStyle CssClass="altrowstyle" />
                                <HeaderStyle CssClass="headerstyle" HorizontalAlign="center" />
                                <RowStyle CssClass="rowstyle" />
                                <PagerStyle CssClass="pagination-ys" />
                                <Columns>
                                    <asp:CommandField ShowSelectButton="True" />
                                    <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="ID" />
                                    <asp:BoundField DataField="Trans" HeaderText="Trans" SortExpression="Trans" />
                                    <asp:BoundField DataField="Type" HeaderText="Type" SortExpression="Type" />
                                    <asp:BoundField DataField="Cust No." HeaderText="Cust No." SortExpression="Cust No." />
                                    <asp:BoundField DataField="Name" HeaderText="Name" ReadOnly="True" SortExpression="Name" />
                                    <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address" />
                                    <asp:BoundField DataField="City" HeaderText="City" SortExpression="City" />
                                    <asp:BoundField DataField="Branch" HeaderText="Branch" SortExpression="Branch" />
                                </Columns>
                            </asp:GridView>
                            <asp:SqlDataSource ID="AuthorizationsDS" runat="server" ConnectionString="<%$ ConnectionStrings:Constring %>" SelectCommand="select ID,TRAN_TYPE as [Trans],CUSTOMER_TYPE as [Type],CUSTOMER_NUMBER as [Cust No.],SURNAME + ' ' + FORENAMES as Name,[Address],City,BRANCH_NAME as [Branch] from CUSTOMER_DETAILS_AUDIT where (AUTHORIZED=0 or AUTHORIZED is NULL) and (DISCARDED=0 or DISCARDED is NULL)"></asp:SqlDataSource>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-12 text-center">
                            <asp:UpdateProgress runat="server" ID="UpdateProgress" AssociatedUpdatePanelID="UpdatePanel" DisplayAfter="0" DynamicLayout="false">
                                <ProgressTemplate>
                                    <img alt="In progress..." src="Images/loading-bar.gif" height="25px" />
                                </ProgressTemplate>
                            </asp:UpdateProgress>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-2 control-label">
                            <asp:Label ID="Label33" runat="server" Text="Branch">
                            </asp:Label>
                        </div>
                        <div class="col-xs-4 control-label">
                            <asp:Label ID="lblBranchCode" runat="server" Text="">
                            </asp:Label>
                            <asp:Label ID="Label35" runat="server" Text="  ">
                            </asp:Label>
                            <asp:Label ID="lblBranchName" runat="server" Text="">
                            </asp:Label>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-2 control-label">
                            <asp:Label ID="Label1" runat="server" Text="Client Type">
                            </asp:Label>
                        </div>
                        <div class="col-xs-4">
                            <asp:DropDownList ReadOnly="True" ForeColor="Black" Font-Bold="true" CssClass="col-xs-12 form-control input-sm" ID="rdbClientType" runat="server" AutoPostBack="True">
                            </asp:DropDownList>
                        </div>
                        <div class="col-xs-2 control-label">
                            <asp:Label ID="Label2" runat="server" Text="Customer Number">
                            </asp:Label>
                        </div>
                        <div class="col-xs-2">
                            <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" CssClass="col-xs-12 form-control input-sm" ID="txtCustNo" runat="server">
                            </asp:TextBox>
                            <asp:RequiredFieldValidator Display="Dynamic" ID="rfvCustNo" runat="server" ErrorMessage="*" ControlToValidate="txtCustNo">
                            </asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <asp:Panel ID="panIndividual" runat="server">
                        <div class="row">
                            <div class="col-xs-2 control-label">
                                Applicant Type
                            </div>
                            <div class="col-xs-4 control-label">
                                <asp:RadioButtonList ReadOnly="True" ForeColor="Black" Font-Bold="true" Enabled="false" ID="rdbSubIndividual" runat="server" RepeatDirection="Horizontal" AutoPostBack="true" CssClass="col-xs-12">
                                    <asp:ListItem Text="SSB" Value="SSB"></asp:ListItem>
                                    <asp:ListItem Text="Bankers" Value="Bankers"></asp:ListItem>
                                    <asp:ListItem Text="PDAs" Value="PDAs"></asp:ListItem>
                                    <asp:ListItem Text="Other" Value="Other"></asp:ListItem>
                                </asp:RadioButtonList>
                            </div>
                            <div class="col-xs-2 control-label">
                                <asp:Label ID="lblEmpCode" runat="server" Text="EC Number" Visible="false"></asp:Label>
                            </div>
                            <div class="col-xs-2">
                                <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" Enabled="false" CssClass="col-xs-12 form-control input-sm" ID="txtECNo" runat="server" Visible="false"
                                    onblur="return isEmployeeCode()" onkeypress="return isnumeric(event)"></asp:TextBox>
                            </div>
                            <div class="col-xs-1">
                                <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" Enabled="false" CssClass="col-xs-12 form-control input-sm" ID="txtECNoCD" runat="server" Visible="false"></asp:TextBox>
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
                                <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" Enabled="false" CssClass="col-xs-12 form-control input-sm" ID="txtOtherAppType" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-xs-2 control-label">
                                <asp:Label ID="lblSurname" runat="server" Text="Surname"></asp:Label>
                                <asp:Label ID="Label3" runat="server" Text="*" ForeColor="Red" Font-Size="Large"></asp:Label>
                            </div>
                            <div class="col-xs-4">
                                <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" Enabled="false" CssClass="col-xs-12 form-control input-sm" ID="txtSurname" runat="server" onkeypress="return isTextOnly(event)"></asp:TextBox>
                                <asp:RequiredFieldValidator Display="Dynamic" ID="rfvSurname" runat="server" ErrorMessage="Surname is required" ValidationGroup="valIndiv" ControlToValidate="txtSurname"></asp:RequiredFieldValidator>
                            </div>
                            <div class="col-xs-2 control-label">
                                <asp:Label ID="lblForenames" runat="server" Text="Forenames"></asp:Label>
                                <asp:Label ID="Labelf3" runat="server" Text="*" ForeColor="Red" Font-Size="Large"></asp:Label>
                            </div>
                            <div class="col-xs-4">
                                <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" Enabled="false" CssClass="col-xs-12 form-control input-sm" ID="txtForenames" runat="server" onkeypress="return isTextOnly(event)"></asp:TextBox>
                                <asp:RequiredFieldValidator Display="Dynamic" ID="rfvForename" runat="server" ErrorMessage="Forename is required" ValidationGroup="valIndiv" ControlToValidate="txtForenames"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-xs-2 control-label">
                                <asp:Label ID="lblIDNo" runat="server" Text="ID Number"></asp:Label>
                                <asp:Label ID="Label36" runat="server" Text="*" ForeColor="Red" Font-Size="Large"></asp:Label>
                            </div>
                            <div class="col-xs-4">
                                <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" Enabled="false" ID="txtIDNo" runat="server" AutoPostBack="true" CssClass="col-xs-12 form-control input-sm" data-placement="top" data-toggle="tooltip" ToolTip="Valid format: 01-2345678A90"></asp:TextBox>
                                <asp:Label ID="lblIDError" runat="server" ForeColor="Red" Font-Size="Small"></asp:Label>
                                <asp:RequiredFieldValidator Display="Dynamic" ID="rfvIDNo" runat="server" ErrorMessage="ID Number is required" ValidationGroup="valIndiv" ControlToValidate="txtIDNo"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator Display="dynamic" ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtIDNo" ValidationGroup="valIndiv" ValidationExpression="\d{2}[-]\d{6,7}[a-zA-Z]\d{2}" ErrorMessage="Please enter a valid ID Number"></asp:RegularExpressionValidator>
                            </div>
                            <div class="col-xs-2 control-label">
                                <asp:Label ID="lblSector" runat="server" Text="Sector"></asp:Label>
                                <asp:Label ID="Label49" runat="server" Text="*" ForeColor="Red" Font-Size="Large"></asp:Label>
                            </div>
                            <div class="col-xs-4">
                                <asp:DropDownList ReadOnly="True" ForeColor="Black" Font-Bold="true" Enabled="false" ID="cmbSector" runat="server" CssClass="col-xs-12 form-control input-sm"></asp:DropDownList>
                                <asp:RequiredFieldValidator Display="Dynamic" ID="rfvSector" runat="server" ErrorMessage="Sector is required" ValidationGroup="valIndiv" ControlToValidate="cmbSector"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-xs-2 control-label">
                                <asp:Label ID="lblDOB" runat="server" Text="Date of Birth"></asp:Label>
                                <asp:Label ID="Label37" runat="server" Text="*" ForeColor="Red" Font-Size="Large"></asp:Label>
                            </div>
                            <div class="col-xs-4">
                                <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" Enabled="false" ID="bdpDOB" runat="server" CssClass="col-xs-12 form-control dob input-sm"></asp:TextBox>
                                <span class="glyphicon glyphicon-calendar form-control-feedback" style="margin-right: 13px; background-color: #eeeeff; border-radius: 0 3px 3px 0; border: 1px solid rgb(149,188,219); z-index: 0;"></span>
                                <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" Enabled="false" CssClass="col-xs-12 form-control input-sm" ID="txtDOB" runat="server" Visible="false"></asp:TextBox>
                                <asp:RequiredFieldValidator Display="Dynamic" ID="rfvDOB" runat="server" ErrorMessage="Date of Birth is required" ValidationGroup="valIndiv" ControlToValidate="bdpDOB"></asp:RequiredFieldValidator>
                            </div>
                            <div class="col-xs-2 control-label">
                                <asp:Label ID="lblIssDate" runat="server" Text="ID Issue Date"></asp:Label>
                            </div>
                            <div class="col-xs-4">
                                <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" Enabled="false" ID="bdpIssDate" runat="server" CssClass="col-xs-12 form-control nofuturedate input-sm"></asp:TextBox>
                                <span class="glyphicon glyphicon-calendar form-control-feedback" style="margin-right: 13px; background-color: #eeeeff; border-radius: 0 3px 3px 0; border: 1px solid rgb(149,188,219); z-index: 0;"></span>
                                <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" Enabled="false" CssClass="col-xs-12 form-control input-sm" ID="txtIssDate" runat="server" Visible="False"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-xs-2 control-label">
                                <asp:Label ID="lblAddress" runat="server" Text="Address"></asp:Label>
                                <asp:Label ID="Label38" runat="server" Text="*" ForeColor="Red" Font-Size="Large"></asp:Label>
                            </div>
                            <div class="col-xs-4">
                                <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" Enabled="false" CssClass="col-xs-12 form-control input-sm" ID="txtAddress" runat="server" Rows="2"
                                    TextMode="MultiLine"></asp:TextBox>
                                <asp:RequiredFieldValidator Display="Dynamic" ID="rfvAddress" runat="server" ErrorMessage="Address is required" ValidationGroup="valIndiv" ControlToValidate="txtAddress"></asp:RequiredFieldValidator>
                            </div>
                            <div class="col-xs-2 control-label">
                                <asp:Label ID="Label31" runat="server"
                                    Text="Home Ownership"></asp:Label>
                            </div>
                            <div class="col-xs-4">
                                <asp:RadioButtonList ReadOnly="True" ForeColor="Black" Font-Bold="true" Enabled="false" ID="rdbHouse" runat="server" CssClass="col-xs-12"
                                    RepeatDirection="Horizontal">
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
                                <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" Enabled="false" CssClass="col-xs-12 form-control input-sm" ID="txtRent" runat="server"
                                    onkeypress="return isnumeric(event)"></asp:TextBox>
                            </div>
                            <div class="col-xs-2 control-label">
                                <asp:Label ID="lblCity" runat="server" Text="City"></asp:Label>
                            </div>
                            <div class="col-xs-4">
                                <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" Enabled="false" CssClass="col-xs-12 form-control input-sm text-only" ID="txtCity" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-xs-2 control-label">
                                <asp:Label ID="Label89" runat="server" Text="Area"></asp:Label>
                            </div>
                            <div class="col-xs-4">
                                <asp:DropDownList ReadOnly="True" ForeColor="Black" Font-Bold="true" Enabled="false" CssClass="col-xs-12 form-control input-sm" ID="cmbArea" runat="server">
                                    <asp:ListItem Text="" Value=""></asp:ListItem>
                                    <asp:ListItem Text="Urban" Value="Urban"></asp:ListItem>
                                    <asp:ListItem Text="Periurban" Value="Periurban"></asp:ListItem>
                                    <asp:ListItem Text="Rural" Value="Rural"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="col-xs-2 control-label">
                                <asp:Label ID="Label6" runat="server" Text="Phone No."></asp:Label>
                            </div>
                            <div class="col-xs-4">
                                <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" Enabled="false" CssClass="col-xs-12 form-control input-sm" ID="txtPhoneNo" runat="server" onkeypress="return isPhoneNo(event)"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-xs-2 control-label">
                                <asp:Label ID="Label8" runat="server" Text="Gender"></asp:Label>
                                <asp:Label ID="Label39" runat="server" Text="*" ForeColor="Red" Font-Size="Large"></asp:Label>
                            </div>
                            <div class="col-xs-4">
                                <asp:RadioButtonList ReadOnly="True" ForeColor="Black" Font-Bold="true" Enabled="false" ID="rdbGender" runat="server" CssClass="col-xs-12"
                                    RepeatDirection="Horizontal">
                                    <asp:ListItem Text="Male" Value="M"></asp:ListItem>
                                    <asp:ListItem Text="Female" Value="F"></asp:ListItem>
                                </asp:RadioButtonList>
                                <asp:RequiredFieldValidator Display="Dynamic" ID="rfvGender" runat="server" ErrorMessage="Gender is required" ValidationGroup="valIndiv" ControlToValidate="rdbGender"></asp:RequiredFieldValidator>
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
                                <asp:Label ID="Label7" runat="server" Text="Nationality"></asp:Label>
                            </div>
                            <div class="col-xs-4">
                                <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" Enabled="false" CssClass="col-xs-12 form-control input-sm" ID="txtNationality" runat="server" onkeypress="return isTextOnly(event)"></asp:TextBox>
                            </div>
                            <%--<div class="col-xs-2 control-label">
                        <asp:Label ID="Label10" runat="server"
                            Text="How long?(months)"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" Enabled="false" CssClass="col-xs-12 form-control input-sm" ID="txtHouseHowLong" runat="server"
                            onkeypress="return isnumeric(event)"></asp:TextBox>
                    </div>--%>
                        </div>
                        <div class="row">
                            <div class="col-xs-2 control-label">
                                <asp:Label ID="Label12" runat="server"
                                    Text="Education"></asp:Label>
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
                                <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" Enabled="false" CssClass="col-xs-12 form-control input-sm" ID="txtEducationOther" runat="server" Visible="False"></asp:TextBox>
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
                                <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" Enabled="false" CssClass="col-xs-12 form-control input-sm" ID="txtBankAccountNo" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div id="spouseDetails">
                            <div class="row label-info">
                                <div class="col-xs-12 control-label">
                                    <asp:Label ID="Label46" runat="server"
                                        Text="Spouse Details"></asp:Label>
                                </div>
                            </div>
                            <div class="row alert-danger">
                                <div class="col-xs-12 control-label">
                                    Spouse Details compulsory for married clients
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-xs-2 control-label">
                                    <asp:Label ID="Label23" runat="server"
                                        Text="Name of spouse"></asp:Label>
                                </div>
                                <div class="col-xs-4">
                                    <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" Enabled="false" CssClass="col-xs-12 form-control input-sm text-only" ID="txtSpouse" runat="server"></asp:TextBox>
                                </div>
                                <div class="col-xs-2 control-label">
                                    <asp:Label ID="Label24" runat="server"
                                        Text="Spouse's Occupation"></asp:Label>
                                </div>
                                <div class="col-xs-4">
                                    <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" Enabled="false" CssClass="col-xs-12 form-control input-sm" ID="txtSpouseOccupation" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-xs-2 control-label">
                                    <asp:Label ID="Label25" runat="server"
                                        Text="Phone"></asp:Label>
                                </div>
                                <div class="col-xs-4">
                                    <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" Enabled="false" CssClass="col-xs-12 form-control input-sm" ID="txtSpousePhone" runat="server" onkeypress="return isPhoneNo(event)"></asp:TextBox>
                                </div>
                                <div class="col-xs-2 control-label">
                                    <asp:Label ID="Label26" runat="server"
                                        Text="Employer"></asp:Label>
                                </div>
                                <div class="col-xs-4">
                                    <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" Enabled="false" CssClass="col-xs-12 form-control input-sm" ID="txtSpouseEmployer" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-xs-2 control-label">
                                    <asp:Label ID="Label27" runat="server"
                                        Text="Number of Children"></asp:Label>
                                </div>
                                <div class="col-xs-4">
                                    <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" Enabled="false" CssClass="col-xs-12 form-control input-sm" ID="txtNoChildren" runat="server"
                                        onkeypress="return isnumeric(event)"></asp:TextBox>
                                </div>
                                <div class="col-xs-2 control-label">
                                    <asp:Label ID="Label28" runat="server"
                                        Text="Number of Dependants"></asp:Label>
                                </div>
                                <div class="col-xs-4">
                                    <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" Enabled="false" CssClass="col-xs-12 form-control input-sm" ID="txtNoDependant" runat="server"
                                        onkeypress="return isnumeric(event)"></asp:TextBox>
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
                                <asp:Label ID="lblPPPDPBusAdd" runat="server" Text="Name of relative not residing with you"></asp:Label>
                            </div>
                            <div class="col-xs-4">
                                <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" Enabled="false" CssClass="col-xs-12 form-control input-sm text-only" ID="txtGuarNameRelative" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-xs-2 control-label">
                                <asp:Label ID="lblPPPDPResAdd" runat="server" Text="Address"></asp:Label>
                            </div>
                            <div class="col-xs-4">
                                <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" Enabled="false" CssClass="col-xs-12 form-control input-sm" ID="txtGuarRelAddress" runat="server" TextMode="MultiLine"></asp:TextBox>
                            </div>
                            <div class="col-xs-2 control-label">
                                <asp:Label ID="lblPPPDPResAddIs" runat="server" Text="Phone"></asp:Label>
                            </div>
                            <div class="col-xs-4">
                                <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" Enabled="false" CssClass="col-xs-12 form-control input-sm" ID="txtGuarRelPhone" runat="server" onkeypress="return isPhoneNo(event)"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-xs-2 control-label">
                                <asp:Label ID="Label50" runat="server" Text="City"></asp:Label>
                            </div>
                            <div class="col-xs-4">
                                <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" Enabled="false" CssClass="col-xs-12 form-control input-sm text-only" ID="txtGuarRelCity" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-xs-2 control-label">
                                <asp:Label ID="Label51" runat="server" Text="Relationship"></asp:Label>
                            </div>
                            <div class="col-xs-4">
                                <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" Enabled="false" CssClass="col-xs-12 form-control input-sm" ID="txtGuarRelReltnship" runat="server"></asp:TextBox>
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
                                <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" Enabled="false" CssClass="col-xs-12 form-control input-sm" ID="txtCurrEmployer" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator Display="Dynamic" ID="rfvCurrEmployer" runat="server" ErrorMessage="Current Employer is required" ValidationGroup="valIndiv" ControlToValidate="txtCurrEmployer"></asp:RequiredFieldValidator>
                            </div>
                            <div class="col-xs-2 control-label">
                                <asp:Label ID="Label14" runat="server" Text="Employer Address"></asp:Label>
                                <asp:Label ID="Label41" runat="server" Text="*" ForeColor="Red" Font-Size="Large"></asp:Label>
                            </div>
                            <div class="col-xs-4">
                                <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" Enabled="false" CssClass="col-xs-12 form-control input-sm" ID="txtEmpAddress" runat="server" TextMode="MultiLine"></asp:TextBox>
                                <asp:RequiredFieldValidator Display="Dynamic" ID="rfvEmpAddress" runat="server" ErrorMessage="Employer Address is required" ValidationGroup="valIndiv" ControlToValidate="txtEmpAddress"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-xs-2 control-label">
                                <asp:Label ID="Label15" runat="server"
                                    Text="Employment Period(months)"></asp:Label>
                            </div>
                            <div class="col-xs-4">
                                <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" Enabled="false" CssClass="col-xs-12 form-control input-sm" ID="txtEmpHowLong" runat="server"
                                    onkeypress="return isnumeric(event)"></asp:TextBox>
                            </div>
                            <div class="col-xs-2 control-label">
                                <asp:Label ID="Label16" runat="server" Text="Phone"></asp:Label>
                                <asp:Label ID="Label42" runat="server" Text="*" ForeColor="Red" Font-Size="Large"></asp:Label>
                            </div>
                            <div class="col-xs-4">
                                <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" Enabled="false" CssClass="col-xs-12 form-control input-sm" ID="txtEmpPhone" runat="server" onkeypress="return isPhoneNo(event)"></asp:TextBox>
                                <asp:RequiredFieldValidator Display="Dynamic" ID="rfvEmpPhone" runat="server" ErrorMessage="Employer Phone is required" ValidationGroup="valIndiv" ControlToValidate="txtEmpPhone"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-xs-2 control-label">
                                <asp:Label ID="Label17" runat="server" Text="E-mail"></asp:Label>
                            </div>
                            <div class="col-xs-4">
                                <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" Enabled="false" CssClass="col-xs-12 form-control input-sm" ID="txtEmpEmail" runat="server"></asp:TextBox>
                                <asp:RegularExpressionValidator Display="Dynamic" ID="valEmpEmail" runat="server" ControlToValidate="txtEmpEmail" ValidationExpression="^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z\.][a-zA-Z]{1,3}$" ErrorMessage="Please enter a valid employer email address"></asp:RegularExpressionValidator>
                            </div>
                            <div class="col-xs-2 control-label">
                                <asp:Label ID="Label18" runat="server" Text="Fax"></asp:Label>
                            </div>
                            <div class="col-xs-4">
                                <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" Enabled="false" CssClass="col-xs-12 form-control input-sm phone" ID="txtEmpFax" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-xs-2 control-label">
                                <asp:Label ID="Label19" runat="server" Text="City"></asp:Label>
                            </div>
                            <div class="col-xs-4">
                                <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" Enabled="false" CssClass="col-xs-12 form-control input-sm text-only" ID="txtEmpCity" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-xs-2 control-label">
                                <asp:Label ID="Label20" runat="server" Text="Position"></asp:Label>
                                <asp:Label ID="Label43" runat="server" Text="*" ForeColor="Red" Font-Size="Large"></asp:Label>
                            </div>
                            <div class="col-xs-4">
                                <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" Enabled="false" CssClass="col-xs-12 form-control input-sm" ID="txtEmpPosition" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator Display="Dynamic" ID="rfvEmpPosition" runat="server" ErrorMessage="Position is required" ValidationGroup="valIndiv" ControlToValidate="txtEmpPosition"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-xs-2 control-label">
                                <asp:Label ID="Label21" runat="server" Text="Gross Salary($)"></asp:Label>
                                <asp:Label ID="Label44" runat="server" Text="*" ForeColor="Red" Font-Size="Large"></asp:Label>
                            </div>
                            <div class="col-xs-4">
                                <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" Enabled="false" CssClass="col-xs-12 form-control input-sm" ID="txtEmpSalary" runat="server"
                                    onkeypress="return isnumeric(event)" onblur="return netLessThanGross()"></asp:TextBox>
                                <asp:RequiredFieldValidator Display="Dynamic" ID="rfvEmpSalary" runat="server" ErrorMessage="Gross Salary is required" ValidationGroup="valIndiv" ControlToValidate="txtEmpSalary"></asp:RequiredFieldValidator>
                            </div>
                            <div class="col-xs-2 control-label">
                                <asp:Label ID="Label1121" runat="server" Text="Net Salary($)"></asp:Label>
                                <asp:Label ID="Label45" runat="server" Text="*" ForeColor="Red" Font-Size="Large"></asp:Label>
                            </div>
                            <div class="col-xs-4">
                                <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" Enabled="false" CssClass="col-xs-12 form-control input-sm" ID="txtEmpSalaryNet" runat="server"
                                    onkeypress="return isnumeric(event)" onblur="return netLessThanGross()"></asp:TextBox>
                                <asp:RequiredFieldValidator Display="Dynamic" ID="rfvEmpSalaryNet" runat="server" ErrorMessage="Net salary is required" ValidationGroup="valIndiv" ControlToValidate="txtEmpSalaryNet"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-xs-2 control-label">
                                <asp:Label ID="Label22" runat="server" Text="Other Income($)"></asp:Label>
                            </div>
                            <div class="col-xs-4">
                                <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" Enabled="false" CssClass="col-xs-12 form-control input-sm" ID="txtEmpOtherIncome" runat="server"
                                    onkeypress="return isnumeric(event)"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row label-info hidden">
                            <div class="col-xs-12 control-label">
                                <asp:Label ID="Label10" runat="server"
                                    Text="Previous Employment"></asp:Label>
                            </div>
                        </div>
                        <div class="row hidden">
                            <div class="col-xs-2 control-label">
                                <asp:Label ID="Label113" runat="server"
                                    Text="Previous Employer"></asp:Label>
                            </div>
                            <div class="col-xs-4">
                                <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" Enabled="false" CssClass="col-xs-12 form-control input-sm" ID="txtPrevEmployer" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row hidden">
                            <div class="col-xs-2 control-label">
                                <asp:Label ID="Label114" runat="server"
                                    Text="Address"></asp:Label>
                            </div>
                            <div class="col-xs-4">
                                <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" Enabled="false" CssClass="col-xs-12 form-control input-sm" ID="txtPrevEmpAddress" runat="server" TextMode="MultiLine"></asp:TextBox>
                            </div>
                            <div class="col-xs-2 control-label">
                                <asp:Label ID="Label115" runat="server"
                                    Text="Employment Period(months)"></asp:Label>
                            </div>
                            <div class="col-xs-4">
                                <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" Enabled="false" CssClass="col-xs-12 form-control input-sm" ID="txtPrevEmpHowLong" runat="server"
                                    onkeypress="return isnumeric(event)"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row hidden">
                            <div class="col-xs-2 control-label">
                                <asp:Label ID="Label116" runat="server"
                                    Text="Phone"></asp:Label>
                            </div>
                            <div class="col-xs-4">
                                <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" Enabled="false" CssClass="col-xs-12 form-control input-sm" ID="txtPrevEmpPhone" runat="server" onkeypress="return isPhoneNo(event)"></asp:TextBox>
                            </div>
                            <div class="col-xs-2 control-label">
                                <asp:Label ID="Label117" runat="server"
                                    Text="E-mail"></asp:Label>
                            </div>
                            <div class="col-xs-4">
                                <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" Enabled="false" CssClass="col-xs-12 form-control input-sm" ID="txtPrevEmpEmail" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row hidden">
                            <div class="col-xs-2 control-label">
                                <asp:Label ID="Label118" runat="server"
                                    Text="Fax"></asp:Label>
                            </div>
                            <div class="col-xs-4">
                                <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" Enabled="false" CssClass="col-xs-12 form-control input-sm phone" ID="txtPrevEmpFax" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-xs-2 control-label">
                                <asp:Label ID="Label119" runat="server"
                                    Text="City"></asp:Label>
                            </div>
                            <div class="col-xs-4">
                                <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" Enabled="false" CssClass="col-xs-12 form-control input-sm text-only" ID="txtPrevEmpCity" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row hidden">
                            <div class="col-xs-2 control-label">
                                <asp:Label ID="Label120" runat="server"
                                    Text="Position"></asp:Label>
                            </div>
                            <div class="col-xs-4">
                                <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" Enabled="false" CssClass="col-xs-12 form-control input-sm" ID="txtPrevEmpPosition" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-xs-2 control-label">
                                <asp:Label ID="Label121" runat="server"
                                    Text="Gross Salary($)"></asp:Label>
                            </div>
                            <div class="col-xs-4">
                                <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" Enabled="false" CssClass="col-xs-12 form-control input-sm" ID="txtPrevEmpSalary" runat="server"
                                    onkeypress="return isnumeric(event)"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row hidden">
                            <div class="col-xs-2 control-label">
                                <asp:Label ID="Label111121" runat="server"
                                    Text="Net Salary($)"></asp:Label>
                            </div>
                            <div class="col-xs-4">
                                <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" Enabled="false" CssClass="col-xs-12 form-control input-sm" ID="txtPrevEmpSalaryNet" runat="server"
                                    onkeypress="return isnumeric(event)"></asp:TextBox>
                            </div>
                            <div class="col-xs-2 control-label">
                                <asp:Label ID="Label122" runat="server"
                                    Text="Annual Income($)"></asp:Label>
                            </div>
                            <div class="col-xs-4">
                                <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" Enabled="false" CssClass="col-xs-12 form-control input-sm" ID="txtPrevEmpAnnualIncome" runat="server"
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
                                <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" Enabled="false" CssClass="col-xs-12 form-control input-sm" ID="txtTradeRef1" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-xs-4">
                                <asp:Label ID="Label130" runat="server"
                                    Text="2)" Visible="false"></asp:Label>
                                <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" Enabled="false" CssClass="col-xs-12 form-control input-sm" ID="txtTradeRef2" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row label-info">
                            <div class="col-xs-12 control-label">
                                Photo Upload
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-xs-12 text-center">
                                <asp:Button CssClass="btn btn-primary btn-sm" ID="btnAuthorize" runat="server" Text="Authorize" ValidationGroup="valIndiv" />
                                <asp:Button CssClass="btn btn-danger btn-sm" ID="btnDiscard" runat="server" CausesValidation="False" OnClientClick="return isDelete();" Text="Discard" />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-xs-12 text-center">
                                <asp:UpdateProgress runat="server" ID="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel" DisplayAfter="0" DynamicLayout="false">
                                    <ProgressTemplate>
                                        <img alt="In progress..." src="Images/loading-bar.gif" />
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                            </div>
                        </div>
                    </asp:Panel>
                    <asp:Panel ID="panGroup" runat="server" Visible="False">
                        <div class="row">
                            <div class="col-xs-2 control-label">
                                <asp:Label ID="Label34" runat="server" Text="Group Name">
                                </asp:Label>
                            </div>
                            <div class="col-xs-4">
                                <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" CssClass="col-xs-12 form-control input-sm" ID="txtGrpName" runat="server">
                                </asp:TextBox>
                            </div>
                            <div class="col-xs-4">
                                <asp:Button CssClass="btn btn-primary btn-sm" ID="btnGrpAddGroup" runat="server" Text="Add Group" />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-xs-12 text-center">
                                <asp:Label ID="lblGrpAdded" runat="server" CssClass="alert-info">
                                </asp:Label>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-xs-12 text-center">
                                <asp:Label ID="Label32" runat="server" Text="Add Group Members Information" Font-Bold="True">
                                </asp:Label>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-xs-2 control-label">
                                <asp:Label ID="Label74" runat="server" Text="Position">
                                </asp:Label>
                            </div>
                            <div class="col-xs-4">
                                <asp:DropDownList ReadOnly="True" ForeColor="Black" Font-Bold="true" CssClass="col-xs-12 form-control input-sm" ID="cmbGrpDeclPosition" runat="server">
                                    <asp:ListItem Text="" Value="">
                                    </asp:ListItem>
                                    <asp:ListItem Text="Chairperson" Value="Chairperson">
                                    </asp:ListItem>
                                    <asp:ListItem Text="Member" Value="Member">
                                    </asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="col-xs-2 control-label">
                                <asp:Label ID="Label75" runat="server" Text="Name">
                                </asp:Label>
                            </div>
                            <div class="col-xs-4">
                                <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" CssClass="col-xs-12 form-control input-sm" ID="txtGrpDeclName" runat="server" onkeypress="return isTextOnly(event)">
                                </asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-xs-2 control-label">
                                <asp:Label ID="Label76" runat="server" Text="ID No">
                                </asp:Label>
                            </div>
                            <div class="col-xs-4">
                                <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" CssClass="col-xs-12 form-control input-sm" ID="txtGrpDeclIDNo" runat="server">
                                </asp:TextBox>
                            </div>
                            <div class="col-xs-2 control-label">
                                <asp:Label ID="Label77" runat="server" Text="Signature" Visible="False">
                                </asp:Label>
                            </div>
                            <div class="col-xs-4">
                                <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" CssClass="col-xs-12 form-control input-sm" ID="txtGrpDeclSignature" runat="server" Visible="False">
                                </asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-xs-12 text-center">
                                <asp:Button CssClass="btn btn-primary btn-sm" ID="btnGrpDeclAdd" runat="server" Text="Add Member" />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-xs-12 text-center">
                                <asp:Label ID="lblGrpDeclMemberAdded" runat="server" CssClass="alert-info">
                                </asp:Label>
                            </div>
                        </div>
                        <div class="row">
                            <div style="height: 15px;">
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-xs-12 text-center">
                                <asp:GridView ID="grdGrpDeclMembers" runat="server">
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
                            <div class="col-xs-12 label-info control-label">
                                <asp:Label ID="Label78" runat="server" Text="Members Expense List (If Applicable)">
                                </asp:Label>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-xs-1 control-label">
                                <asp:Label ID="Label79" runat="server" Text="Member">
                                </asp:Label>
                            </div>
                            <div class="col-xs-3">
                                <asp:DropDownList ReadOnly="True" ForeColor="Black" Font-Bold="true" CssClass="col-xs-12 form-control input-sm" ID="cmbGrpDeclMember" runat="server" AppendDataBoundItems="True">
                                </asp:DropDownList>
                            </div>
                            <div class="col-xs-1 control-label">
                                <asp:Label ID="Label80" runat="server" Text="Rent">
                                </asp:Label>
                            </div>
                            <div class="col-xs-3">
                                <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" CssClass="col-xs-12 form-control input-sm" ID="txtGrpDeclRent" runat="server">
                                </asp:TextBox>
                            </div>
                            <div class="col-xs-1 control-label">
                                <asp:Label ID="Label81" runat="server" Text="Food">
                                </asp:Label>
                            </div>
                            <div class="col-xs-3">
                                <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" CssClass="col-xs-12 form-control input-sm" ID="txtGrpDeclFood" runat="server">
                                </asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-xs-1 control-label">
                                <asp:Label ID="Label82" runat="server" Text="School Fees">
                                </asp:Label>
                            </div>
                            <div class="col-xs-3">
                                <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" CssClass="col-xs-12 form-control input-sm" ID="txtGrpDeclFees" runat="server">
                                </asp:TextBox>
                            </div>
                            <div class="col-xs-1 control-label">
                                <asp:Label ID="Label83" runat="server" Text="Airtime">
                                </asp:Label>
                            </div>
                            <div class="col-xs-3">
                                <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" CssClass="col-xs-12 form-control input-sm" ID="txtGrpDeclAirtime" runat="server">
                                </asp:TextBox>
                            </div>
                            <div class="col-xs-1 control-label">
                                <asp:Label ID="Label84" runat="server" Text="Medical Expenses">
                                </asp:Label>
                            </div>
                            <div class="col-xs-3">
                                <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" CssClass="col-xs-12 form-control input-sm" ID="txtGrpDeclMedical" runat="server">
                                </asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-xs-1 control-label">
                                <asp:Label ID="Label85" runat="server" Text="Electricity">
                                </asp:Label>
                            </div>
                            <div class="col-xs-3">
                                <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" CssClass="col-xs-12 form-control input-sm" ID="txtGrpDeclElectricity" runat="server">
                                </asp:TextBox>
                            </div>
                            <div class="col-xs-1 control-label">
                                <asp:Label ID="Label86" runat="server" Text="Water">
                                </asp:Label>
                            </div>
                            <div class="col-xs-3">
                                <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" CssClass="col-xs-12 form-control input-sm" ID="txtGrpDeclWater" runat="server">
                                </asp:TextBox>
                            </div>
                            <div class="col-xs-1 control-label">
                                <asp:Label ID="Label87" runat="server" Text="Rates">
                                </asp:Label>
                            </div>
                            <div class="col-xs-3">
                                <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" CssClass="col-xs-12 form-control input-sm" ID="txtGrpDeclRates" runat="server">
                                </asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-xs-1 control-label">
                                <asp:Label ID="Label88" runat="server" Text="City of Harare">
                                </asp:Label>
                            </div>
                            <div class="col-xs-3">
                                <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" CssClass="col-xs-12 form-control input-sm" ID="txtGrpDeclCityOfHre" runat="server">
                                </asp:TextBox>
                            </div>
                            <div class="col-xs-4">
                                <asp:Button CssClass="btn btn-primary btn-sm" ID="btnGrpDeclAddExpense" runat="server" Text="Add" />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-xs-12 text-center">
                                <asp:Label ID="lblGrpExpense" runat="server" Text="" CssClass="alert-info">
                                </asp:Label>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-xs-12 text-center">
                                <asp:GridView ID="grdGrpDeclExpense" runat="server">
                                    <AlternatingRowStyle CssClass="altrowstyle" />
                                    <HeaderStyle CssClass="headerstyle" HorizontalAlign="center" />
                                    <RowStyle CssClass="rowstyle" />
                                </asp:GridView>
                            </div>
                        </div>
                    </asp:Panel>
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnAuthorize" />
            <asp:PostBackTrigger ControlID="btnDiscard" />
        </Triggers>
    </asp:UpdatePanel>
    <script type="text/javascript">
        $('.datepicker').datepicker({
            format: 'dd MM yyyy',
            todayHighlight: true
        });

        $(function () {
            $("[id*=btnSaveLoginParameters]").bind("click", function () {
                $("[id*=btnSaveLoginParameters]").val("Saving...");
                $("[id*=btnSaveLoginParameters]").attr("disabled", true);
            });
        });

        $('.nofuturedate').datepicker({
            format: 'dd MM yyyy',
            todayHighlight: true,
            endDate: '+0d'
        });
    </script>
</asp:Content>