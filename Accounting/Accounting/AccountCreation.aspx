<%@ Page Title="Account Creation" Language="VB" MasterPageFile="~/Site2.master" AutoEventWireup="false" CodeFile="AccountCreation.aspx.vb" Inherits="Accounting_AccountCreation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="panel panel-primary small">
        <div class="panel-heading">
            <h4 class="panel-title">
                <a>Account Creation</a>
            </h4>
        </div>
        <div class="panel-body">
            <div class="row">
                <div class="col-xs-12 label-info control-label">
                    <asp:Label ID="Label1" runat="server" Text="ACCOUNT DETAILS" Font-Bold="True"></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12 center-block">
                    <asp:RadioButtonList ID="rdbAccountType" runat="server" AutoPostBack="True" RepeatDirection="Horizontal" CssClass="col-xs-12 control-label" Visible="False">
                        <asp:ListItem Value="221">Creditor</asp:ListItem>
                        <asp:ListItem Value="100">Debtor</asp:ListItem>
                        <asp:ListItem>Other</asp:ListItem>
                    </asp:RadioButtonList>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-2 control-label">
                    <asp:Label ID="Label1220" runat="server" Text="Account Name"></asp:Label>
                </div>
                <div class="col-xs-4">
                    <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtAccName" runat="server"></asp:TextBox>
                </div>
                <div class="col-xs-1">
                    <asp:Button CssClass="btn btn-primary btn-sm" ID="Button1" runat="server" Text="Search" />
                </div>
                <div class="col-xs-1 control-label">
                    <asp:Label ID="Label1221" runat="server" Text="Default" Visible="False"></asp:Label>
                </div>
                <div class="col-xs-4">
                    <asp:DropDownList CssClass="col-xs-12 form-control input-sm" ID="cmbDefault" runat="server" Visible="False">
                        <asp:ListItem>-Select-</asp:ListItem>
                        <asp:ListItem>Dr</asp:ListItem>
                        <asp:ListItem>Cr</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12 center-block">
                    <asp:ListBox ID="lstAccSearch" runat="server" CssClass="col-xs-12" AutoPostBack="true" Visible="false"></asp:ListBox>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-2 control-label">
                    <asp:Label ID="Label23" runat="server" Text="Main Account #"></asp:Label>
                </div>
                <div class="col-xs-4">
                    <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtMainAcc" runat="server"></asp:TextBox>
                </div>
                <div class="col-xs-2 control-label">
                    <asp:Label ID="Label24" runat="server" Text="Sub Account #"></asp:Label>
                </div>
                <div class="col-xs-3">
                    <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtSubAcc" runat="server"></asp:TextBox>
                </div>
                <div class="col-xs-1">
                    <asp:Button CssClass="btn btn-primary btn-sm" ID="btnSearchAccNo" runat="server" Text="Search" />
                </div>
            </div>
            <div class="row">
                <div class="col-xs-2 control-label">
                    <asp:Label ID="Label5" runat="server" Text="Type"></asp:Label>
                </div>
                <div class="col-xs-4">
                    <asp:RadioButtonList ID="rdbType" runat="server" AutoPostBack="True" RepeatDirection="horizontal" CssClass="col-xs-12 control-label">
                        <asp:ListItem Text="Income Statement" Value="Income"></asp:ListItem>
                        <asp:ListItem Text="Balance Sheet" Value="Balance Sheet"></asp:ListItem>
                    </asp:RadioButtonList>
                </div>
                <div class="col-xs-2 control-label">
                    <asp:Label ID="Label1218" runat="server" Text="Tax Processing"></asp:Label>
                </div>
                <div class="col-xs-4">
                    <asp:DropDownList CssClass="col-xs-12 form-control input-sm" ID="cmbTax" runat="server">
                    </asp:DropDownList>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-2 control-label">
                    Category
                </div>
                <div class="col-xs-4">
                    <asp:DropDownList ID="cmbCategory" runat="server" CssClass="col-xs-12 form-control input-sm" AutoPostBack="true"></asp:DropDownList>
                </div>
                <div class="col-xs-2 control-label">
                    <asp:Label ID="Label1217" runat="server" Text="Sub Category"></asp:Label>
                </div>
                <div class="col-xs-4">
                    <asp:DropDownList CssClass="col-xs-12 form-control input-sm" ID="cmbType" runat="server" AutoPostBack="true">
                    </asp:DropDownList>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-2 control-label">
                    <asp:Label ID="lblBSItem" runat="server" Text="Balance Sheet Item" Visible="false"></asp:Label>
                </div>
                <div class="col-xs-4">
                    <asp:DropDownList CssClass="col-xs-12 form-control input-sm" ID="cmbBSItem" runat="server" Visible="false">
                    </asp:DropDownList>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-2 control-label">
                    <asp:Label ID="Label1219" runat="server" Text="Account Description "></asp:Label>
                </div>
                <div class="col-xs-6">
                    <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtdesc" runat="server" TextMode="MultiLine"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12 center-block">
                    <asp:Panel ID="Panel1" runat="server" BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" Visible="False">
                        <div class="row">
                            <div class="col-xs-3 control-label">
                                <asp:Label ID="Label1222" runat="server" Text="Physical Address"></asp:Label>
                            </div>
                            <div class="col-xs-3">
                                <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtPhysAdd" runat="server" TextMode="MultiLine"></asp:TextBox>
                            </div>
                            <div class="col-xs-3 control-label">
                                <asp:Label ID="Label1225" runat="server" Text="Postal Address"></asp:Label>
                            </div>
                            <div class="col-xs-3">
                                <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtPostAddr" runat="server" TextMode="MultiLine"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-xs-3 control-label">
                                <asp:Label ID="Label1223" runat="server" Text="Tel. No"></asp:Label>
                            </div>
                            <div class="col-xs-3">
                                <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtTelNo" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-xs-3 control-label">
                                <asp:Label ID="Label1226" runat="server" Text="Fax. No"></asp:Label>
                            </div>
                            <div class="col-xs-3">
                                <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtFaxNo" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-xs-3 control-label">
                                <asp:Label ID="Label1224" runat="server" Text="Contact Person"></asp:Label>
                            </div>
                            <div class="col-xs-3">
                                <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtContactPerson" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-xs-3 control-label">
                                <asp:Label ID="Label1227" runat="server" Text="Email Add"></asp:Label>
                            </div>
                            <div class="col-xs-3">
                                <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtEmailAdd" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </asp:Panel>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12 text-center">
                    <asp:Button CssClass="btn btn-primary btn-sm" ID="btnSaveTrxn" runat="server" Text="Save" />
                    &nbsp;&nbsp;<asp:Button CssClass="btn btn-primary btn-sm" ID="btnSaveTrxn1" runat="server" Text="Update" Enabled="false" />
                    &nbsp;<asp:Button CssClass="btn btn-primary btn-sm" ID="btnSaveTrxn2" runat="server" Text="New" Visible="false" />
                    <asp:HiddenField ID="hfEditID" runat="server" />
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12 center-block">
                    <asp:GridView ID="grdDetails" runat="server" EnableModelValidation="True" HorizontalAlign="center" AutoGenerateSelectButton="True">
                        <AlternatingRowStyle CssClass="altrowstyle" />
                        <HeaderStyle CssClass="headerstyle" HorizontalAlign="center" />
                        <RowStyle CssClass="rowstyle" />
                        <PagerStyle CssClass="pagination-ys" />
                        <SelectedRowStyle Font-Bold="true" BackColor="#A8B1B9" />
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        $('.datepicker').datepicker({
            format: 'dd MM yyyy',
            todayHighlight: true
        });

        $(function () {
            $("[id*=btnSaveCreditParameters]").bind("click", function () {
                $("[id*=btnSaveCreditParameters]").val("Creating Amortization...");
                $("[id*=btnSaveCreditParameters]").attr("disabled", true);
            });
        });

        $('.nofuturedate').datepicker({
            format: 'dd MM yyyy',
            todayHighlight: true,
            endDate: '+0d'
        });
    </script>
</asp:Content>