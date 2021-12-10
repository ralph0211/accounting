<%@ Page Language="VB" MasterPageFile="~/Site2.master" AutoEventWireup="false" CodeFile="LoginParameters.aspx.vb" Inherits="LoginParameters" Title="Login Parameters - Credit Management System" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="panel panel-primary small">
        <div class="panel-heading">
            <h4 class="panel-title">
                Login Parameters
            </h4>
        </div>
        <div class="panel-body">
            <%--<div class="row">
                <div class="col-xs-3 control-label">
                    <asp:Label ID="Label3" runat="server"
                        Text="System Uptime"></asp:Label>
                </div>
                <div class="col-xs-3">
                    <bdp:timepicker id="bdpUptime" runat="server">
                    </bdp:timepicker>
                    <bdp:istimevalidator id="IsTimeUptime" runat="server"
                        controltovalidate="bdpUpTime" errormessage="Select Time Please">
                    </bdp:istimevalidator>
                </div>
                <div class="col-xs-3 control-label">
                    <asp:Label ID="Label8" runat="server"
                        Text="System Downtime"></asp:Label>
                </div>
                <div class="col-xs-3">
                    <bdp:timepicker id="bdpDowntime" runat="server">
                    </bdp:timepicker>
                    <bdp:istimevalidator id="IsTimeDowntime" runat="server"
                        controltovalidate="bdpDownTime" errormessage="Select Time Please">
                    </bdp:istimevalidator>
                </div>
            </div>--%>
            <div class="row">
                <div class="col-xs-3 control-label">
                    <asp:Label ID="Label9" runat="server"
                        Text="Password Expiry (days)"></asp:Label>
                </div>
                <div class="col-xs-3">
                    <asp:TextBox CssClass="col-xs-12 form-control input-sm numeric" ID="txtPasswordExpiry" runat="server"></asp:TextBox>
                </div>
                <div class="col-xs-3 control-label">
                    <asp:Label ID="Label10" runat="server"
                        Text="Min Password Length"></asp:Label>
                </div>
                <div class="col-xs-3">
                    <asp:TextBox CssClass="col-xs-12 form-control input-sm numeric" ID="txtPasswordLength" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-3 control-label">
                    <asp:Label ID="Label11" runat="server"
                        Text="Number of Access Users"></asp:Label>
                </div>
                <div class="col-xs-3">
                    <asp:TextBox CssClass="col-xs-12 form-control input-sm numeric" ID="txtAccessUsers" runat="server"></asp:TextBox>
                </div>
                <div class="col-xs-3">
                    <asp:CheckBox ID="chkSpecialCharacters" runat="server"
                        Text="Allow Special Characters" />
                </div>
            </div>
            <div class="row">
                <div class="col-xs-3 control-label">
                    <asp:Label ID="Label12" runat="server"
                        Text="Max Login Attempts"></asp:Label>
                </div>
                <div class="col-xs-3">
                    <asp:TextBox CssClass="col-xs-12 form-control input-sm numeric" ID="txtLoginAttempts" runat="server"></asp:TextBox>
                </div>
                <div class="col-xs-3">
                    <asp:CheckBox ID="chkUserCaseSensitive" runat="server"
                        Text="Username Case Sensitive" />
                </div>
            </div>
            <div class="row">
                <div class="col-xs-3 control-label">
                    <asp:Label ID="Label13" runat="server"
                        Text="Session Timeout"></asp:Label>
                </div>
                <div class="col-xs-3">
                    <asp:TextBox CssClass="col-xs-12 form-control input-sm numeric" ID="txtSessionTimeout" runat="server"></asp:TextBox>
                </div>
                <div class="col-xs-3 control-label hidden">
                    <asp:Label ID="Labelfff13" runat="server"
                        Text="Default User Password"></asp:Label>
                </div>
                <div class="col-xs-3 hidden">
                    <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtDefaultPassword" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-3 control-label">
                    <asp:Label ID="lblDomain" runat="server"
                        Text="Active Directory Domain"></asp:Label>
                </div>
                <div class="col-xs-3">
                    <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtDomain" runat="server"></asp:TextBox>
                </div>

                <%--<div class="col-xs-3 control-label">
                    <asp:Label ID="lbldisb" runat="server"
                        Text="Disbursement Option"></asp:Label>
                </div>
                <div class="col-xs-3">

                    <asp:DropDownList CssClass="col-xs-12 form-control input-sm" ID="cmbDisbOption" runat="server">
                        <asp:ListItem>FIN ACCOUNTS</asp:ListItem>
                        <asp:ListItem>CASH BOX</asp:ListItem>
                    </asp:DropDownList>
                </div>--%>
            </div>
            <div class="row">
                <div class="col-xs-12 control-label label-info">
                    OTP Settings
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12 control-label">
                    <asp:CheckBox ID="chkOTP" runat="server" Text="Send One-Time Password (OTP) when user logs in" />
                </div>
            </div>
            <div class="row">
                <div class="col-xs-2 control-label">
                    OTP Option
                </div>
                <div class="col-xs-4">
                    <asp:RadioButtonList ID="rdbOTPOption" runat="server" RepeatDirection="Horizontal" CssClass="col-xs-12">
                        <asp:ListItem Text="Email" Value="Email"></asp:ListItem>
                        <asp:ListItem Text="SMS" Value="SMS"></asp:ListItem>
                        <asp:ListItem Text="Both" Value="Both"></asp:ListItem>
                    </asp:RadioButtonList>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-2 control-label">
                    OTP Characters
                </div>
                <div class="col-xs-6">
                    <asp:RadioButtonList ID="rdbOTPCharacters" runat="server" RepeatDirection="Horizontal" CssClass="col-xs-12">
                        <asp:ListItem Text="Alphabetic Uppercase" Value="AU"></asp:ListItem>
                        <asp:ListItem Text="Alphabetic Lowercase" Value="AL"></asp:ListItem>
                        <asp:ListItem Text="Alphabetic Mixed" Value="AM"></asp:ListItem>
                        <asp:ListItem Text="Numeric" Value="Num"></asp:ListItem>
                        <asp:ListItem Text="Alpha-numeric" Value="AN"></asp:ListItem>
                    </asp:RadioButtonList>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-2 control-label">
                    OTP Length
                </div>
                <div class="col-xs-4">
                    <asp:TextBox ID="txtOTPLength" runat="server" CssClass="col-xs-12 form-control input-sm numeric"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12 text-center">
                    <asp:Button CssClass="btn btn-primary btn-sm" ID="btnSaveLoginParameters" runat="server" Text="Save" UseSubmitBehavior="false" />
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        $(function () {
            $("[id*=btnSaveLoginParameters]").bind("click", function () {
                $("[id*=btnSaveLoginParameters]").val("Saving...");
                $("[id*=btnSaveLoginParameters]").attr("disabled", true);
            });
        });
    </script>
</asp:Content>