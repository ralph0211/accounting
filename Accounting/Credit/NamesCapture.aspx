<%@ Page Language="VB" MasterPageFile="~/Site2.master" AutoEventWireup="false" CodeFile="NamesCapture.aspx.vb" Inherits="NamesCapture" Title="Capture Static Details - Credit Management System" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .tb_with_border {
            border: 1px #FF0000 solid;
        }

        .tb_without_border {
            border: 1px solid gray;
        }

        div.ui-datepicker {
            font-size: 8px;
        }

        .vid-cont {
            width: 320px;
            height: 240px;
            position: relative;
            border: 1px solid #d3d3d3;
            float: left;
            margin-left: 20px;
        }

            .vid-cont video {
                width: 100%;
                height: 100%;
                position: absolute;
            }

            .vid-cont .photoArea {
                border: 2px dashed white;
                width: 140px;
                height: 190px;
                position: relative;
                margin: 0 auto;
                top: 40px;
            }

        canvas, img {
            float: left;
        }

        .controls {
            clear: both;
        }
    </style>
    <link href="../css/noty-buttons.css" rel="stylesheet" />
    <script type="text/javascript">
        function isDelete() {
            return confirm("Are you sure you want to delete this record?");
        }
    </script>
    <script type="text/javascript">
        function isEmployeeCode() {

            var regex = "^\d{7}$";

            //var regex = "^\{0-9}{7}$";

            var ECNo = document.getElementById('<%= txtECNo.ClientID%>').value.concat("").toString();

            //if (/^[0-9]{7}$/.test(+ECNo)) {

            if (/^[0-9]{7}$/.test(ECNo) || ECNo == '') {

                return true;

            }

            else {

                alert('Please enter 7 numbers only or leave blank');
                setTimeout(function () { document.getElementById('<%= txtECNo.ClientID%>').focus(); }, 1);
                return false;

            }

        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="panel panel-primary small">
        <div class="panel-heading">
            <h4 class="panel-title">
                <a>Capture Static Details
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
                    <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtCustNo" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator Display="Dynamic" ID="rfvCustNo" runat="server" ErrorMessage="*" ControlToValidate="txtCustNo"></asp:RequiredFieldValidator>
                </div>
                <div class="col-xs-2">
                    <asp:CheckBox ID="chkAutoGenCustNo" runat="server" Text="Generate"
                        AutoPostBack="True" />
                </div>
            </div>
            <asp:Panel ID="panIndividual" runat="server">
                <div class="row">
                    <div class="col-xs-2 control-label">
                        Applicant Type
                    </div>
                    <div class="col-xs-4 control-label">
                        <asp:RadioButtonList ID="rdbSubIndividual" runat="server" RepeatDirection="Horizontal" AutoPostBack="true" CssClass="col-xs-12">
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
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtECNo" runat="server" Visible="false"
                            onblur="return isEmployeeCode()" onkeypress="return isnumeric(event)"></asp:TextBox>
                    </div>
                    <div class="col-xs-1">
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtECNoCD" runat="server" Visible="false"></asp:TextBox>
                    </div>
                </div>
                <div class="row" id="divAppTypeBanker" runat="server" visible="false">
                    <div class="col-xs-2 control-label">
                        Bank
                    </div>
                    <div class="col-xs-4">
                        <asp:DropDownList CssClass="col-xs-12 form-control input-sm" ID="cmbBankAppType" runat="server" AutoPostBack="true"></asp:DropDownList>
                    </div>
                    <div class="col-xs-2 control-label">
                        Branch
                    </div>
                    <div class="col-xs-4">
                        <asp:DropDownList CssClass="col-xs-12 form-control input-sm" ID="cmbBranchAppType" runat="server"></asp:DropDownList>
                    </div>
                </div>
                <div class="row" id="divAppTypePDA" runat="server" visible="false">
                    <div class="col-xs-2 control-label">
                        Company
                    </div>
                    <div class="col-xs-4">
                        <asp:DropDownList CssClass="col-xs-12 form-control input-sm" ID="cmbPDAAppType" runat="server"></asp:DropDownList>
                    </div>
                </div>
                <div class="row" id="divAppTypeOther" runat="server" visible="false">
                    <div class="col-xs-2 control-label">
                        Description
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtOtherAppType" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="lblSurname" runat="server" Text="Surname"></asp:Label>
                        <asp:Label ID="Label3" runat="server" Text="*" ForeColor="Red" Font-Size="Large"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtSurname" runat="server" onkeypress="return isTextOnly(event)"></asp:TextBox>
                        <asp:RequiredFieldValidator Display="Dynamic" ID="rfvSurname" runat="server" ErrorMessage="Surname is required" ValidationGroup="valIndiv" ControlToValidate="txtSurname"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="lblForenames" runat="server" Text="Forenames"></asp:Label>
                        <asp:Label ID="Labelf3" runat="server" Text="*" ForeColor="Red" Font-Size="Large"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtForenames" runat="server" onkeypress="return isTextOnly(event)"></asp:TextBox>
                        <asp:RequiredFieldValidator Display="Dynamic" ID="rfvForename" runat="server" ErrorMessage="Forename is required" ValidationGroup="valIndiv" ControlToValidate="txtForenames"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="lblIDNo" runat="server" Text="ID Number"></asp:Label>
                        <asp:Label ID="Label36" runat="server" Text="*" ForeColor="Red" Font-Size="Large"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox ID="txtIDNo" runat="server" AutoPostBack="true" CssClass="col-xs-12 form-control input-sm" data-placement="top" data-toggle="tooltip" OnTextChanged="txtIDNo_TextChanged" ToolTip="Valid format: 01-2345678A90"></asp:TextBox>
                        <asp:Label ID="lblIDError" runat="server" ForeColor="Red" Font-Size="Small"></asp:Label>
                        <asp:RequiredFieldValidator Display="Dynamic" ID="rfvIDNo" runat="server" ErrorMessage="ID Number is required" ValidationGroup="valIndiv" ControlToValidate="txtIDNo"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator Display="dynamic" ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtIDNo" ValidationGroup="valIndiv" ValidationExpression="\d{2}[-]\d{6,7}[a-zA-Z]\d{2}" ErrorMessage="Please enter a valid ID Number"></asp:RegularExpressionValidator>
                    </div>
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="lblSector" runat="server" Text="Sector"></asp:Label>
                        <asp:Label ID="Label49" runat="server" Text="*" ForeColor="Red" Font-Size="Large"></asp:Label>
                    </div>
                    <div class="col-xs-3">
                        <asp:DropDownList ID="cmbSector" runat="server" CssClass="col-xs-12 form-control input-sm"></asp:DropDownList>
                        <asp:RequiredFieldValidator Display="Dynamic" ID="rfvSector" runat="server" ErrorMessage="Sector is required" ValidationGroup="valIndiv" ControlToValidate="cmbSector"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-xs-1">
                        <button type="button" class="btn btn-info btn-sm" data-toggle="modal" data-target="#SectorModal">Add</button>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="lblDOB" runat="server" Text="Date of Birth"></asp:Label>
                        <asp:Label ID="Label37" runat="server" Text="*" ForeColor="Red" Font-Size="Large"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox ID="bdpDOB" runat="server" CssClass="col-xs-12 form-control dob input-sm"></asp:TextBox>
                        <span class="glyphicon glyphicon-calendar form-control-feedback" style="margin-right: 13px; background-color: #eeeeff; border-radius: 0 3px 3px 0; border: 1px solid rgb(149,188,219); z-index: 0;"></span>
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtDOB" runat="server" Visible="false"></asp:TextBox>
                        <asp:RequiredFieldValidator Display="Dynamic" ID="rfvDOB" runat="server" ErrorMessage="Date of Birth is required" ValidationGroup="valIndiv" ControlToValidate="bdpDOB"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="lblIssDate" runat="server" Text="ID Issue Date"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox ID="bdpIssDate" runat="server" CssClass="col-xs-12 form-control nofuturedate input-sm"></asp:TextBox>
                        <span class="glyphicon glyphicon-calendar form-control-feedback" style="margin-right: 13px; background-color: #eeeeff; border-radius: 0 3px 3px 0; border: 1px solid rgb(149,188,219); z-index: 0;"></span>
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtIssDate" runat="server" Visible="False"></asp:TextBox>
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
                        <asp:Label ID="lblAddress" runat="server" Text="Address"></asp:Label>
                        <asp:Label ID="Label38" runat="server" Text="*" ForeColor="Red" Font-Size="Large"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtAddress" runat="server" Rows="2"
                            TextMode="MultiLine"></asp:TextBox>
                        <asp:RequiredFieldValidator Display="Dynamic" ID="rfvAddress" runat="server" ErrorMessage="Address is required" ValidationGroup="valIndiv" ControlToValidate="txtAddress"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="Label31" runat="server"
                            Text="Home Ownership"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:RadioButtonList ID="rdbHouse" runat="server" CssClass="col-xs-12"
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
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtRent" runat="server"
                            onkeypress="return isnumeric(event)"></asp:TextBox>
                    </div>
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="lblCity" runat="server" Text="City"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm text-only" ID="txtCity" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="Label89" runat="server" Text="Area"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:DropDownList CssClass="col-xs-12 form-control input-sm" ID="cmbArea" runat="server">
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
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtPhoneNo" runat="server" onkeypress="return isPhoneNo(event)"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="Label8" runat="server" Text="Gender"></asp:Label>
                        <asp:Label ID="Label39" runat="server" Text="*" ForeColor="Red" Font-Size="Large"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:RadioButtonList ID="rdbGender" runat="server" CssClass="col-xs-12"
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
                        <asp:DropDownList CssClass="col-xs-12 form-control input-sm" ID="cmbMaritalStatus" runat="server">
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
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtNationality" runat="server" onkeypress="return isTextOnly(event)"></asp:TextBox>
                    </div>
                    <%--<div class="col-xs-2 control-label">
                        <asp:Label ID="Label10" runat="server"
                            Text="How long?(months)"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtHouseHowLong" runat="server"
                            onkeypress="return isnumeric(event)"></asp:TextBox>
                    </div>--%>
                </div>
                <div class="row">
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="Label12" runat="server"
                            Text="Education"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:DropDownList CssClass="col-xs-12 form-control input-sm" ID="cmbEducation" runat="server" AutoPostBack="True">
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
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtEducationOther" runat="server" Visible="False"></asp:TextBox>
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
                        <asp:DropDownList CssClass="col-xs-12 form-control input-sm" ID="cmbBank" runat="server" AutoPostBack="true"></asp:DropDownList>
                    </div>
                    <div class="col-xs-2 control-label">
                        Branch
                    </div>
                    <div class="col-xs-4">
                        <asp:DropDownList CssClass="col-xs-12 form-control input-sm" ID="cmbBankBranch" runat="server"></asp:DropDownList>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-2 control-label">
                        Account Number
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtBankAccountNo" runat="server"></asp:TextBox>
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
                            <asp:TextBox CssClass="col-xs-12 form-control input-sm text-only" ID="txtSpouse" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-xs-2 control-label">
                            <asp:Label ID="Label24" runat="server"
                                Text="Spouse's Occupation"></asp:Label>
                        </div>
                        <div class="col-xs-4">
                            <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtSpouseOccupation" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-2 control-label">
                            <asp:Label ID="Label25" runat="server"
                                Text="Phone"></asp:Label>
                        </div>
                        <div class="col-xs-4">
                            <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtSpousePhone" runat="server" onkeypress="return isPhoneNo(event)"></asp:TextBox>
                        </div>
                        <div class="col-xs-2 control-label">
                            <asp:Label ID="Label26" runat="server"
                                Text="Employer"></asp:Label>
                        </div>
                        <div class="col-xs-4">
                            <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtSpouseEmployer" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-2 control-label">
                            <asp:Label ID="Label27" runat="server"
                                Text="Number of Children"></asp:Label>
                        </div>
                        <div class="col-xs-4">
                            <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtNoChildren" runat="server"
                                onkeypress="return isnumeric(event)"></asp:TextBox>
                        </div>
                        <div class="col-xs-2 control-label">
                            <asp:Label ID="Label28" runat="server"
                                Text="Number of Dependants"></asp:Label>
                        </div>
                        <div class="col-xs-4">
                            <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtNoDependant" runat="server"
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
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm text-only" ID="txtGuarNameRelative" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="lblPPPDPResAdd" runat="server" Text="Address"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtGuarRelAddress" runat="server" TextMode="MultiLine"></asp:TextBox>
                    </div>
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="lblPPPDPResAddIs" runat="server" Text="Phone"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtGuarRelPhone" runat="server" onkeypress="return isPhoneNo(event)"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="Label50" runat="server" Text="City"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm text-only" ID="txtGuarRelCity" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="Label51" runat="server" Text="Relationship"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtGuarRelReltnship" runat="server"></asp:TextBox>
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
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtCurrEmployer" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator Display="Dynamic" ID="rfvCurrEmployer" runat="server" ErrorMessage="Current Employer is required" ValidationGroup="valIndiv" ControlToValidate="txtCurrEmployer"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="Label14" runat="server" Text="Employer Address"></asp:Label>
                        <asp:Label ID="Label41" runat="server" Text="*" ForeColor="Red" Font-Size="Large"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtEmpAddress" runat="server" TextMode="MultiLine"></asp:TextBox>
                        <asp:RequiredFieldValidator Display="Dynamic" ID="rfvEmpAddress" runat="server" ErrorMessage="Employer Address is required" ValidationGroup="valIndiv" ControlToValidate="txtEmpAddress"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="Label15" runat="server"
                            Text="Employment Period(months)"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtEmpHowLong" runat="server"
                            onkeypress="return isnumeric(event)"></asp:TextBox>
                    </div>
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="Label16" runat="server" Text="Phone"></asp:Label>
                        <asp:Label ID="Label42" runat="server" Text="*" ForeColor="Red" Font-Size="Large"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtEmpPhone" runat="server" onkeypress="return isPhoneNo(event)"></asp:TextBox>
                        <asp:RequiredFieldValidator Display="Dynamic" ID="rfvEmpPhone" runat="server" ErrorMessage="Employer Phone is required" ValidationGroup="valIndiv" ControlToValidate="txtEmpPhone"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="Label17" runat="server" Text="E-mail"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtEmpEmail" runat="server"></asp:TextBox>
                        <asp:RegularExpressionValidator Display="Dynamic" ID="valEmpEmail" runat="server" ControlToValidate="txtEmpEmail" ValidationExpression="^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z\.][a-zA-Z]{1,3}$" ErrorMessage="Please enter a valid employer email address"></asp:RegularExpressionValidator>
                    </div>
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="Label18" runat="server" Text="Fax"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm phone" ID="txtEmpFax" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="Label19" runat="server" Text="City"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm text-only" ID="txtEmpCity" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="Label20" runat="server" Text="Position"></asp:Label>
                        <asp:Label ID="Label43" runat="server" Text="*" ForeColor="Red" Font-Size="Large"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtEmpPosition" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator Display="Dynamic" ID="rfvEmpPosition" runat="server" ErrorMessage="Position is required" ValidationGroup="valIndiv" ControlToValidate="txtEmpPosition"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="Label21" runat="server" Text="Gross Salary($)"></asp:Label>
                        <asp:Label ID="Label44" runat="server" Text="*" ForeColor="Red" Font-Size="Large"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtEmpSalary" runat="server"
                            onkeypress="return isnumeric(event)" onblur="return netLessThanGross()"></asp:TextBox>
                        <asp:RequiredFieldValidator Display="Dynamic" ID="rfvEmpSalary" runat="server" ErrorMessage="Gross Salary is required" ValidationGroup="valIndiv" ControlToValidate="txtEmpSalary"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="Label1121" runat="server" Text="Net Salary($)"></asp:Label>
                        <asp:Label ID="Label45" runat="server" Text="*" ForeColor="Red" Font-Size="Large"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtEmpSalaryNet" runat="server"
                            onkeypress="return isnumeric(event)" onblur="return netLessThanGross()"></asp:TextBox>
                        <asp:RequiredFieldValidator Display="Dynamic" ID="rfvEmpSalaryNet" runat="server" ErrorMessage="Net salary is required" ValidationGroup="valIndiv" ControlToValidate="txtEmpSalaryNet"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="Label22" runat="server" Text="Other Income($)"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtEmpOtherIncome" runat="server"
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
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtPrevEmployer" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="row hidden">
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="Label114" runat="server"
                            Text="Address"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtPrevEmpAddress" runat="server" TextMode="MultiLine"></asp:TextBox>
                    </div>
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="Label115" runat="server"
                            Text="Employment Period(months)"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtPrevEmpHowLong" runat="server"
                            onkeypress="return isnumeric(event)"></asp:TextBox>
                    </div>
                </div>
                <div class="row hidden">
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="Label116" runat="server"
                            Text="Phone"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtPrevEmpPhone" runat="server" onkeypress="return isPhoneNo(event)"></asp:TextBox>
                    </div>
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="Label117" runat="server"
                            Text="E-mail"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtPrevEmpEmail" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="row hidden">
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="Label118" runat="server"
                            Text="Fax"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm phone" ID="txtPrevEmpFax" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="Label119" runat="server"
                            Text="City"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm text-only" ID="txtPrevEmpCity" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="row hidden">
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="Label120" runat="server"
                            Text="Position"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtPrevEmpPosition" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="Label121" runat="server"
                            Text="Gross Salary($)"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtPrevEmpSalary" runat="server"
                            onkeypress="return isnumeric(event)"></asp:TextBox>
                    </div>
                </div>
                <div class="row hidden">
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="Label111121" runat="server"
                            Text="Net Salary($)"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtPrevEmpSalaryNet" runat="server"
                            onkeypress="return isnumeric(event)"></asp:TextBox>
                    </div>
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="Label122" runat="server"
                            Text="Annual Income($)"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtPrevEmpAnnualIncome" runat="server"
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
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtTradeRef1" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-xs-4">
                        <asp:Label ID="Label130" runat="server"
                            Text="2)" Visible="false"></asp:Label>
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtTradeRef2" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-2 control-label">
                        <asp:CheckBox ID="chkIsGroup" runat="server" Text="Is member of group" AutoPostBack="true" />
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-12 center-block">
                        <asp:CheckBoxList ID="chkGroups" runat="server" Visible="false"></asp:CheckBoxList>
                    </div>
                </div>
                <div class="row label-info">
                    <div class="col-xs-12 control-label">
                        Photo Upload
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-4 control-label">
                        <asp:RadioButtonList ID="rdbPhotoType" runat="server" RepeatDirection="Horizontal" CssClass="col-xs-12">
                            <asp:ListItem Text="Upload photo" Value="1"></asp:ListItem>
                            <asp:ListItem Text="Capture photo" Value="2"></asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                </div>
                <div id="divCapture">
                    <div class="row alert alert-warning">
                        <div class="col-xs-12 control-label">
                            You need the latest Mozilla Firefox browser to capture photos using your webcam. If your browser is not compatible, use the Upload option.
                        </div>
                    </div>
                    <div class="row">
                        <div class="vid-cont">
                            <video autoplay></video>
                            <div class="photoArea"></div>
                        </div>
                        <canvas width='140' height='190' style="border: 1px solid #d3d3d3; margin-left: 10px;"></canvas>
                        <img width="140" height="190" class="uploadImg" style="margin-left: 10px;" />
                    </div>
                    <div class="controls">
                        <input type="button" value="start capture" onclick="startCapture()" />
                        <input type="button" value="take snapshot" onclick="takePhoto()" />
                        <input type="button" value="stop capture" onclick="stopCapture()" />
                        <input type="button" value="upload" onclick="upload()" />
                    </div>
                </div>
                <div id="divUpload">
                    <div class="row">
                        <div class="col-xs-2 control-label">
                            Select File
                        </div>
                        <div class="col-xs-4">
                            <asp:FileUpload ID="filPassportPhoto" runat="server" />
                            <asp:RegularExpressionValidator ID="uplValidator" runat="server" ControlToValidate="filPassportPhoto"
                                ErrorMessage=".jpg, .png & .jpeg formats are allowed" ValidationGroup="Passport"
                                ValidationExpression="(.+\.([Jj][Pp][Gg])|.+\.([Pp][Nn][Gg])|.+\.([Jj][Pp][Ee][Gg]))"></asp:RegularExpressionValidator>
                        </div>
                        <div class="col-xs-1">
                            <asp:Button CssClass="btn btn-primary btn-sm upload-btn" ID="btnUploadPassport" runat="server" Text="Upload" ValidationGroup="Passport" UseSubmitBehavior="false" />
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
                        <asp:Button CssClass="btn btn-primary btn-sm" ID="btnSaveName" runat="server" Text="Save Static Details" ValidationGroup="valIndiv"
                            OnClientClick="window.scrollTo = function(x,y) { return true; };" UseSubmitBehavior="false" />
                        <asp:Button CssClass="btn btn-primary btn-sm" ID="btnDeleteName" runat="server" CausesValidation="False"
                            OnClientClick="return isDelete();" Text="Delete" Visible="False" />
                    </div>
                </div>
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
                        <asp:GridView ID="grdNames" runat="server" AllowPaging="True"
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
            </asp:Panel>
            <asp:Panel ID="panGroup" runat="server" Visible="False">
                <div class="row">
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="Label34" runat="server" Text="Group Name"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtGrpName" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="reqGrpName" runat="server" ErrorMessage="Group name is required" ValidationGroup="valGrpName" Display="Dynamic" ControlToValidate="txtGrpName"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-xs-2">
                        <asp:Button CssClass="btn btn-primary btn-sm" ID="btnGrpAddGroup" runat="server" Text="Add Group" ValidationGroup="valGrpName" />
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
                <div class="row alert-danger">
                    <div class="col-xs-12 control-label">
                        <asp:Label ID="lblGrpMemberCount" runat="server" Text=""></asp:Label>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="Label74" runat="server" Text="Position"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:DropDownList CssClass="col-xs-12 form-control input-sm" ID="cmbGrpDeclPosition" runat="server">
                            <asp:ListItem Text="" Value=""></asp:ListItem>
                            <asp:ListItem Text="Chairperson" Value="Chairperson"></asp:ListItem>
                            <asp:ListItem Text="Member" Value="Member"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="Label75" runat="server" Text="Name"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtGrpDeclName" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvGrpDeclName" runat="server" ErrorMessage="Member's name is required" ValidationGroup="valGrpMember" ControlToValidate="txtGrpDeclName" Display="Dynamic"></asp:RequiredFieldValidator>
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
                        <asp:RequiredFieldValidator ID="rfvGrpGender" runat="server" ErrorMessage="Member's gender is required" ValidationGroup="valGrpMember" ControlToValidate="rdbGrpGender" Display="Dynamic"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="Label76" runat="server" Text="ID No"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtGrpDeclIDNo" runat="server" data-toggle="tooltip" data-placement="top" ToolTip="Valid format: 01-2345678A90"></asp:TextBox>
                        <asp:RegularExpressionValidator Display="dynamic" ID="regGrpIDNo" runat="server" ControlToValidate="txtGrpDeclIDNo" ValidationGroup="valGrpMember" ValidationExpression="\d{2}[-]\d{6,7}[a-zA-Z]\d{2}" ErrorMessage="Please enter a valid ID Number"></asp:RegularExpressionValidator>
                        <asp:RequiredFieldValidator ID="rfvGrpDeclIDNo" runat="server" ErrorMessage="Member's ID Number is required" ValidationGroup="valGrpMember" ControlToValidate="txtGrpDeclIDNo" Display="Dynamic"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="Label77" runat="server" Text="Date of Birth"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox ID="bdpGrpDOB" runat="server" CssClass="col-xs-12 form-control dob input-sm"></asp:TextBox>
                        <span class="glyphicon glyphicon-calendar form-control-feedback" style="margin-right: 13px; background-color: #eeeeff; border-radius: 0 3px 3px 0; border: 1px solid rgb(149,188,219); z-index: 0;"></span>
                    </div>
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="Labelk76" runat="server" Text="ID Issue Date"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox ID="bdpGrpIssDate" runat="server" CssClass="col-xs-12 form-control nofuturedate input-sm"></asp:TextBox>
                        <span class="glyphicon glyphicon-calendar form-control-feedback" style="margin-right: 13px; background-color: #eeeeff; border-radius: 0 3px 3px 0; border: 1px solid rgb(149,188,219); z-index: 0;"></span>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="Labelhyu76" runat="server" Text="Address"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtGrpDeclAddress" runat="server" TextMode="MultiLine"></asp:TextBox>
                    </div>
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="Labeluj77" runat="server" Text="City"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtGrpDeclCity" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="Labelfy76" runat="server" Text="Phone No."></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm phone" ID="txtGrpDeclPhoneNo" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="Labelfy7876" runat="server" Text="Nationality"></asp:Label>
                    </div>
                    <div class="col-xs-3">
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtGrpDeclNationality" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-xs-1">
                        <asp:Button CssClass="btn btn-primary btn-sm" ID="btnGrpDeclAdd" runat="server" Text="Add" ValidationGroup="valGrpMember" UseSubmitBehavior="false" />
                    </div>
                </div>
                <div class="row alert-danger">
                    <div class="col-xs-12 control-label text-center">
                        <asp:Label ID="lblGrpDeclMemberAdded" runat="server"></asp:Label>
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
                                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtGrdGrpPosition" runat="server" Text='<%# Bind("POSITION") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblGrdGrpPosition" runat="server" Text='<%# Bind("POSITION") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="NAME">
                                    <EditItemTemplate>
                                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtGrdGrpName" runat="server" Text='<%# Bind("NAME") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblGrdGrpName" runat="server" Text='<%# Bind("NAME") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ID NUMBER">
                                    <EditItemTemplate>
                                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtGrdGrpIDNo" runat="server" Text='<%# Bind("IDNO") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblGrdGrpIDNo" runat="server" Text='<%# Bind("IDNO") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ADDRESS">
                                    <EditItemTemplate>
                                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtGrdGrpAddress" runat="server" Text='<%# Bind("ADDRESS")%>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblGrdGrpAddress" runat="server" Text='<%# Bind("ADDRESS")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="CITY">
                                    <EditItemTemplate>
                                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtGrdGrpCity" runat="server" Text='<%# Bind("CITY")%>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblGrdGrpCity" runat="server" Text='<%# Bind("CITY")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="DOB">
                                    <EditItemTemplate>
                                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtGrdGrpDOB" runat="server" Text='<%# Bind("DOB")%>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblGrdGrpDOB" runat="server" Text='<%# Bind("DOB")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ID ISSUE DATE">
                                    <EditItemTemplate>
                                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtGrdGrpIssDate" runat="server" Text='<%# Bind("ISSUE_DATE")%>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblGrdGrpIssDate" runat="server" Text='<%# Bind("ISSUE_DATE")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="PHONE">
                                    <EditItemTemplate>
                                        <asp:TextBox CssClass="col-xs-12 form-control input-sm nofuturedate" ID="txtGrdGrpPhone" runat="server" Text='<%# Bind("PHONE")%>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblGrdGrpPhone" runat="server" Text='<%# Bind("PHONE")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="NATIONALITY">
                                    <EditItemTemplate>
                                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtGrdGrpNat" runat="server" Text='<%# Bind("NATIONALITY")%>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblGrdGrpNat" runat="server" Text='<%# Bind("NATIONALITY")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="GENDER">
                                    <EditItemTemplate>
                                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtGrdGrpIssGender" runat="server" Text='<%# Bind("GENDER")%>' Width="40px"></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblGrdGrpIssGender" runat="server" Text='<%# Bind("GENDER")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
                <div class="" id="divGrpCount" runat="server">
                    <div class="col-xs-12 control-label">
                        <asp:Label ID="lblCurrGrpMembers" runat="server" Text=""></asp:Label>
                    </div>
                </div>
                <div style="height: 10px;"></div>
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
                            AppendDataBoundItems="True">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvGrpDeclMember" ControlToValidate="cmbGrpDeclMember" Display="dynamic" runat="server" ErrorMessage="Select group member to update" ValidationGroup="GrpExpense"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="Label80" runat="server" Text="Rent"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm numeric" ID="txtGrpDeclRent" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="Label81" runat="server" Text="Food"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm numeric" ID="txtGrpDeclFood" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="Label82" runat="server" Text="School Fees"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm numeric" ID="txtGrpDeclFees" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="Label83" runat="server" Text="Airtime"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm numeric" ID="txtGrpDeclAirtime" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="Label84" runat="server" Text="Medical Expenses"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm numeric" ID="txtGrpDeclMedical" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="Label85" runat="server" Text="Electricity"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm numeric" ID="txtGrpDeclElectricity" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="Label86" runat="server" Text="Water"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm numeric" ID="txtGrpDeclWater" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="Label87" runat="server" Text="Rates"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm numeric" ID="txtGrpDeclRates" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="Label88" runat="server" Text="City of Harare"></asp:Label>
                    </div>
                    <div class="col-xs-3">
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm numeric" ID="txtGrpDeclCityOfHre" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-xs-1">
                        <asp:Button CssClass="btn btn-primary btn-sm" ID="btnGrpDeclAddExpense" runat="server" Text="Add" UseSubmitBehavior="false" ValidationGroup="GrpExpense" />
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
                <div class="row">
                    <div class="col-xs-12 text-center">
                        <asp:Button CssClass="btn btn-primary btn-sm save-btn" ID="btnActivateGrp" runat="server" Text="Activate Group" UseSubmitBehavior="false" />
                    </div>
                </div>
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
            </asp:Panel>
            <asp:Panel ID="pnlFarmers" runat="server" Visible="false">
                <div class="row">
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="lblFarmNameOfGroup" runat="server" Text="Name of Farmers Group"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtFarmNameOfGroup" runat="server"></asp:TextBox>
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
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtFarmNameOfApplicant" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="lblFarmGender" runat="server" Text="Gender"></asp:Label>
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
                        <asp:Label ID="lblFarmDOB" runat="server" Text="Date of Birth"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm dob" ID="txtFarmDOB" runat="server"></asp:TextBox>
                        <span class="glyphicon glyphicon-calendar form-control-feedback" style="margin-right: 13px; background-color: #eeeeff; border-radius: 0 3px 3px 0; border: 1px solid rgb(149,188,219); z-index: 0;"></span>
                    </div>
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="lblFarmIDNo" runat="server" Text="ID Number"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtFarmIDNo" runat="server" data-toggle="tooltip" data-placement="top" ToolTip="Valid format: 01-2345678A90"></asp:TextBox>
                        <asp:RegularExpressionValidator Display="dynamic" ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtFarmIDNo" ValidationGroup="valFarmer" ValidationExpression="\d{2}[-]\d{6,7}[a-zA-Z]\d{2}" ErrorMessage="Please enter a valid ID Number"></asp:RegularExpressionValidator>
                        <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator1" runat="server" ErrorMessage="ID Number is required" ValidationGroup="valFarmer" ControlToValidate="txtFarmIDNo"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="lblFarmIssDate" runat="server" Text="ID Issue Date"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm nofuturedate" ID="txtFarmIssDate" runat="server"></asp:TextBox>
                        <span class="glyphicon glyphicon-calendar form-control-feedback" style="margin-right: 13px; background-color: #eeeeff; border-radius: 0 3px 3px 0; border: 1px solid rgb(149,188,219); z-index: 0;"></span>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="lblFarmCurrentAddress" runat="server" Text="Current Address"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtFarmCurrentAddress" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="lblFarmPhoneNo" runat="server" Text="Phone No"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm phone" ID="txtFarmPhoneNo" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="lblFarmNameOfSpouse" runat="server" Text="Name of Spouse"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtFarmNameOfSpouse" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="lblFarmSpouseIDNo" runat="server" Text="ID Number"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtFarmSpouseIDNo" runat="server"></asp:TextBox>
                        <asp:RegularExpressionValidator Display="dynamic" ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtFarmSpouseIDNo" ValidationGroup="valFarmer" ValidationExpression="\d{2}[-]\d{6,7}[a-zA-Z]\d{2}" ErrorMessage="Please enter a valid ID Number"></asp:RegularExpressionValidator>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="lblFarmCurrAddressOfSpouse" runat="server" Text="Current Address of Spouse"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtFarmCurrAddressOfSpouse" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="lblFarmSpousePhoneNo" runat="server" Text="Phone No"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm phone" ID="txtFarmSpousePhoneNo" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="lblFarmMonthlyExpense" runat="server" Text="Monthly Expense($)"></asp:Label>
                    </div>
                    <div class="col-xs-2">
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm numeric" ID="txtFarmMonthlyExpense" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="lblFarmMonthlyIncome" runat="server" Text="Monthly Income($)"></asp:Label>
                    </div>
                    <div class="col-xs-2">
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm numeric" ID="txtFarmMonthlyIncome" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="lblFarmPreviousSales" runat="server" Text="Previous Sales($)"></asp:Label>
                    </div>
                    <div class="col-xs-2">
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm numeric" ID="txtFarmPreviousSales" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="lblFarmCurrentEstimate" runat="server" Text="Current Estimate($)"></asp:Label>
                    </div>
                    <div class="col-xs-2">
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm numeric" ID="txtFarmCurrentEstimate" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="lblFarmCropsGrown" runat="server" Text="Crops Grown"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtFarmCropsGrown" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="lblFarmPeriodFarming" runat="server" Text="Period Farming (months)"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm numeric" ID="txtFarmPeriodFarming" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-12 text-center">
                        <asp:Button CssClass="btn btn-primary btn-sm save-btn" ID="btnSaveFarmer" runat="server" Text="Save" ValidationGroup="valFarmer" UseSubmitBehavior="false" />
                        <asp:Button CssClass="btn btn-primary btn-sm" ID="btnDeleteFarmer" runat="server" Text="Delete" Visible="false" UseSubmitBehavior="false" />
                    </div>
                </div>
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
            </asp:Panel>
            <asp:Panel ID="panCompany" runat="server" Visible="false">
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
                        <asp:RadioButtonList ID="rdbCompanyType" runat="server" RepeatDirection="Horizontal" CssClass="col-xs-12" AutoPostBack="true">
                            <asp:ListItem Text="Sole Trader" Value="Sole"></asp:ListItem>
                            <asp:ListItem Text="Registered Business" Value="Registered"></asp:ListItem>
                        </asp:RadioButtonList>
                        <asp:RequiredFieldValidator Display="Dynamic" ID="rfvCompType" runat="server" ErrorMessage="Company Type is required" ValidationGroup="valComp" ControlToValidate="rdbCompanyType"></asp:RequiredFieldValidator>
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
                        <asp:Label ID="Label52" runat="server" Text="Business Registration Number"></asp:Label>
                        <asp:Label ID="Label123" runat="server" Text="*" ForeColor="Red" Font-Size="Large"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtBusRegNo" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator Display="Dynamic" ID="rfvComp" runat="server" ErrorMessage="Business Registration Number is required" ValidationGroup="valComp" ControlToValidate="txtBusRegNo"></asp:RequiredFieldValidator>
                    </div>
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
                        <asp:TextBox ID="txtCityTown" runat="server" CssClass="form-control input-sm col-xs-12" onkeypress="return isTextOnly(event)"></asp:TextBox>
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
                        <asp:RegularExpressionValidator ID="valBusinessEmail" runat="server" ControlToValidate="txtBusinessEmail" ValidationGroup="valComp" ValidationExpression="^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z\.][a-zA-Z]{1,3}$" ErrorMessage="Please enter a valid email address"></asp:RegularExpressionValidator>
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
                        <asp:RegularExpressionValidator ID="valtxtContactEmail" Display="Dynamic" runat="server" ValidationGroup="valComp" ControlToValidate="txtContactEmail" ValidationExpression="^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z\.][a-zA-Z]{1,3}$" ErrorMessage="Please enter a valid email address"></asp:RegularExpressionValidator>
                    </div>
                    <div class="col-xs-6 left">
                    </div>
                </div>
                <div class="row label-info">
                    <div class="col-xs-12 control-label">
                        Director Details
                    </div>
                </div>
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
                        <asp:Label ID="Label53" runat="server" Text="*" ForeColor="Red" Font-Size="Large"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox ID="txtDirectorIDNumber" runat="server" CssClass="form-control input-sm col-xs-12" data-placement="top" data-toggle="tooltip" ToolTip="Valid format: 01-2345678A90"></asp:TextBox>
                        <asp:RequiredFieldValidator Display="dynamic" ID="rfvDirectorIDNumber" runat="server" ErrorMessage="Director's ID Number is required" ControlToValidate="txtDirectorIDNumber" ValidationGroup="valDirector"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator Display="dynamic" ID="revDirectorIDNumber" runat="server" ControlToValidate="txtDirectorIDNumber" ValidationGroup="valComp" ValidationExpression="\d{2}[-]\d{6,7}[a-zA-Z]\d{2}" ErrorMessage="Please enter a valid ID Number"></asp:RegularExpressionValidator>
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
                <div class="row">
                    <div class="col-xs-12 text-center">
                        <asp:Button ID="btnAddDirector" runat="server" Text="Add Director" CssClass="btn btn-primary btn-sm" ValidationGroup="valDirector" UseSubmitBehavior="false" />
                    </div>
                </div>
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
                <div class="row">
                    <div class="col-xs-12 text-center">
                        <asp:Button ID="btnSaveBus" runat="server" Text="Save" CssClass="btn btn-primary btn-sm btn-disable" UseSubmitBehavior="false" ValidationGroup="valComp" />
                        <asp:Button ID="btnDeleteBus" runat="server" Text="Delete" CssClass="btn btn-primary btn-sm btn-disable" UseSubmitBehavior="false" Visible="false" />
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="Label54" runat="server"
                            Text="Search by Business Name"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtSearchCompany" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-xs-1">
                        <asp:Button CssClass="btn btn-primary btn-sm" ID="btnSearchCompany" runat="server" CausesValidation="False"
                            Text="Search" />
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-12 center-block">
                        <asp:GridView ID="grdCompany" runat="server" HorizontalAlign="Center" AllowPaging="true" SelectedRowStyle-Font-Bold="true">
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
            </asp:Panel>
        </div>
    </div>
    <div id="SectorModal" class="modal fade" role="dialog">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">Add Sector</h4>
                </div>
                <div class="modal-body panel-body small">
                    <div class="row">
                        <div class="col-xs-2 control-label">
                            <asp:Label ID="Label106" runat="server" Text="Sector" Font-Size="Medium"></asp:Label>
                        </div>
                        <div class="col-xs-8">
                            <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtSector" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator Display="Dynamic" ID="reqSector" runat="server" ErrorMessage="Sector is required" Font-Bold="true" ForeColor="Red" ControlToValidate="txtSector" ValidationGroup="valSector"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-xs-1">
                            <asp:Button CssClass="btn btn-primary btn-sm" ID="btnAddSector" runat="server" Text="Add" ValidationGroup="valSector" />
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default btn-sm" data-dismiss="modal">Close</button>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        //window.scrollTo = function () { };

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
        };
        function netLessThanGross() {
            var net = document.getElementById('<%= txtEmpSalaryNet.ClientID%>').value;
            var gross = document.getElementById('<%= txtEmpSalary.ClientID%>').value;
            if (net == '' || gross == '') {
                //alert('blank');
            } else {
                if (parseFloat(gross, 10) < parseFloat(net, 10)) {
                    alert('Net salary must be less or equal to the gross');
                    setTimeout(function () { document.getElementById('<%= txtEmpSalaryNet.ClientID%>').focus(); }, 1);
                    return false;
                } else {
                    return true;
                }
            }
        };

        $(function () {
            $('[data-toggle=tooltip]').popover();
            $('[rel=tooltip]').popover();
        });

        function hidePhotosDiv() {
            $("#divUpload").hide();
            $("#divCapture").hide();
        }

        $(document).ready(function () {
            $('[id*=rdbPhotoType] input').click(function () {
                var value = $('[id*=rdbPhotoType] input:checked').val();
                if (value == 1) {
                    $("#divUpload").show();
                    $("#divCapture").hide();
                }
                else if (value == 2) {
                    $("#divUpload").hide();
                    $("#divCapture").show();
                }
                else {
                    $("#divUpload").hide();
                    $("#divCapture").hide();
                }
            });
        });

        $(document).ready(function () {
            var value = $('[id*=rdbPhotoType] input:checked').val();
            if (value == 1) {
                $("#divUpload").show();
                $("#divCapture").hide
            }
            else if (value == 2) {
                $("#divUpload").hide();
                $("#divCapture").show();
            }
            else {
                $("#divUpload").hide();
                $("#divCapture").hide();
            }
        });
    </script>
    <script type="text/javascript">
        var localMediaStream = null;
        var video = document.querySelector('video');
        var canvas = document.querySelector('canvas');

        function upload() {
            //var base64 = document.querySelector('img').src;
            var base64 = document.querySelector('.uploadImg').src;
            PageMethods.Upload(base64,
                function () { /* TODO: do something for success */ notify('Photo successfully uploaded', 'success', 'top'); },
                function (e) { console.log(e); alert(e); }
            );
        }

        function takePhoto() {
            if (localMediaStream) {
                var ctx = canvas.getContext('2d');
                //ctx.drawImage(video, 0, 0, 320, 240); // original draw image
                //ctx.drawImage(video, 0, 0, 640, 480, 0, 0, 320, 240); // entire image

                //instead of
                //ctx.drawImage(video, 90, 40, 140, 190, 0, 0, 140, 190);

                // we double the source coordinates
                ctx.drawImage(video, 180, 80, 280, 380, 0, 0, 140, 190);
                //document.querySelector('img').src = canvas.toDataURL('image/jpeg');
                document.querySelector('.uploadImg').src = canvas.toDataURL('image/jpeg');
            }
        }

        navigator.getUserMedia = navigator.getUserMedia || navigator.webkitGetUserMedia || navigator.mozGetUserMedia || navigator.msGetUserMedia;
        window.URL = window.URL || window.webkitURL;

        function startCapture() {
            navigator.getUserMedia({ video: true }, function (stream) {
                video.src = window.URL.createObjectURL(stream);
                localMediaStream = stream;
            }, function (e) {
                console.log(e);
            });
        }

        function stopCapture() {
            video.pause();
            localMediaStream.stop();
        }

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
                    page: 'NamesCapture.aspx',
                    address: $("#<%=txtAddress.ClientID %>").val(),
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
                    grpDeclAddress: $("#<%=txtGrpDeclAddress.ClientID %>").val(),
                    grpDeclAirtime: $("#<%=txtGrpDeclAirtime.ClientID %>").val(),
                    grpDeclCity: $("#<%=txtGrpDeclCity.ClientID %>").val(),
                    grpDeclCityOfHre: $("#<%=txtGrpDeclCityOfHre.ClientID %>").val(),
                    grpDeclElectricity: $("#<%=txtGrpDeclElectricity.ClientID %>").val(),
                    grpDeclFees: $("#<%=txtGrpDeclFees.ClientID %>").val(),
                    grpDeclFood: $("#<%=txtGrpDeclFood.ClientID %>").val(),
                    grpDeclIDNo: $("#<%=txtGrpDeclIDNo.ClientID %>").val(),
                    grpDeclMedical: $("#<%=txtGrpDeclMedical.ClientID %>").val(),
                    grpDeclName: $("#<%=txtGrpDeclName.ClientID %>").val(),
                    grpDeclNationality: $("#<%=txtGrpDeclNationality.ClientID %>").val(),
                    grpDeclPhoneNo: $("#<%=txtGrpDeclPhoneNo.ClientID %>").val(),
                    grpDeclRates: $("#<%=txtGrpDeclRates.ClientID %>").val(),
                    grpDeclRent: $("#<%=txtGrpDeclRent.ClientID %>").val(),
                    grpDeclWater: $("#<%=txtGrpDeclWater.ClientID %>").val(),
                    grpName: $("#<%=txtGrpName.ClientID %>").val(),
                    grpDOB: $("#<%=bdpGrpDOB.ClientID %>").val(),
                    grpIssDate: $("#<%=bdpGrpIssDate.ClientID %>").val(),
                    idNo: $("#<%=txtIDNo.ClientID %>").val(),
                    issDate: $("#<%=bdpIssDate.ClientID %>").val(),
                    nationality: $("#<%=txtNationality.ClientID %>").val(),
                    noChildren: $("#<%=txtNoChildren.ClientID %>").val(),
                    noDependant: $("#<%=txtNoDependant.ClientID %>").val(),
                    otherAppType: $("#<%=txtOtherAppType.ClientID %>").val(),
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
                    rent: $("#<%=txtRent.ClientID %>").val(),
                    searchFarmer: $("#<%=txtSearchFarmer.ClientID %>").val(),
                    searchGroup: $("#<%=txtSearchGroup.ClientID %>").val(),
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
                    cmbGrpDeclMember: $("#<%=cmbGrpDeclMember.ClientID %>").val(),
                    cmbGrpDeclPosition: $("#<%=cmbGrpDeclPosition.ClientID %>").val(),
                    cmbMaritalStatus: $("#<%=cmbMaritalStatus.ClientID %>").val(),
                    cmbPDAAppType: $("#<%=cmbPDAAppType.ClientID %>").val(),
                    rdbClientType: $("#<%=rdbClientType.ClientID %>").val(),
                    rdbFarmGender: $("#<%=rdbFarmGender.ClientID %> input:checked").val(),
                    rdbGender: $("#<%=rdbGender.ClientID %> input:checked").val(),
                    rdbGrpGender: $("#<%=rdbGrpGender.ClientID %> input:checked").val(),
                    rdbHouse: $("#<%=rdbHouse.ClientID %> input:checked").val(),
                    rdbSubIndividual: $("#<%=rdbSubIndividual.ClientID %> input:checked").val(),
                    lblBranchCode: $("#<%=lblBranchCode.ClientID %>").text(),
                    lblBranchName: $("#<%=lblBranchName.ClientID %>").text(),
                    action: document.getElementById('<%=btnSaveName.ClientID%>').value
                }),
                success: function (response) {
                    notify('Auto-saved as draft', 'success');
                }
            });
        }
    </script>
</asp:Content>