<%@ Page Title="Loan Adjustments Form" Language="VB" MasterPageFile="~/Site2.master" AutoEventWireup="false" CodeFile="frmAdjustmentsform.aspx.vb" Inherits="LoanAdjustmentsFormFile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <style type="text/css">
        .panel-heading {
            text-align: left;
            font-weight: bold;
        }

        .control-label {
            text-align: left;
            font-weight: bold;
        }

        .panel-body {
            background-color: #eeeeee;
        }

        .row {
            margin-bottom: 4px;
        }

        .auto-style2 {
            height: 24px;
        }

        .auto-style3 {
            height: 36px;
        }

        .auto-style8 {
            height: 145px;
        }

        .auto-style9 {
            height: 171px;
        }

        .auto-style10 {
            width: 123px;
        }

        .auto-style11 {
            height: 36px;
            width: 123px;
        }

        .auto-style12 {
            height: 22px;
        }

        .auto-style13 {
            height: 27px;
        }

        .auto-style14 {
            height: 37px;
        }

        .auto-style16 {
            height: 38px;
        }

        .auto-style17 {
            height: 247px;
        }

        .auto-style18 {
            width: 295px;
        }

        .auto-style19 {
            height: 36px;
            width: 295px;
        }
    </style>
    <script type="text/javascript">
        function isDelete() {
            return confirm("Are you sure you want to delete this record?");
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="">
        <div class="panel panel-primary">
            <div class="panel-heading">
                Loan Adjustments
            </div>
            <div class="panel-body">

                <table style="width: 100%; height: 518px;">
                    <tr>
                        <td style="text-align: left" class="auto-style14">
                            <asp:Label ID="Label22" runat="server" Text="Select Type"></asp:Label>
                            &nbsp;
                                              <asp:DropDownList ID="DropDownList1" runat="server" Height="22px" Width="200px" AutoPostBack="True">
                                                  <asp:ListItem>-SELECT-</asp:ListItem>
                                                  <asp:ListItem>New</asp:ListItem>
                                                  <asp:ListItem>Deletion</asp:ListItem>
                                                  <asp:ListItem>Change</asp:ListItem>
                                              </asp:DropDownList>
                        </td>
                    </tr>

                    <tr>
                        <td style="text-align: right" class="auto-style2">
                            <asp:Panel ID="Panel2" runat="server" Visible="False">
                                <table style="width: 100%;">
                                    <tr>
                                        <td colspan="4" style="text-align: left" class="auto-style16">
                                            <asp:Label ID="Label23" runat="server" Text="Search Name"></asp:Label>
                                            <asp:TextBox ID="txtSearchNameChange" runat="server" Width="200"></asp:TextBox>
                                            <asp:Button ID="btnSearchRange0" runat="server" Text="&gt;&gt;" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style16" colspan="4" style="text-align: left">&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style17" colspan="4" style="text-align: left">
                                            <asp:GridView ID="grdLoanAppsChange" runat="server" AllowPaging="True" EmptyDataText="No applications ready for processing" Width="100%">
                                                <AlternatingRowStyle CssClass="altrowstyle" />
                                                <Columns>
                                                    <asp:TemplateField ShowHeader="False">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandArgument='<%# Eval("ID") %>' CommandName="Select" Text="Select"></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <%--<asp:TemplateField ShowHeader="False">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False"
                                                                CommandName="Details" Text="Details" CommandArgument='<%# Eval("ID") %>'></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>--%>
                                                </Columns>
                                                <HeaderStyle CssClass="headerstyle" HorizontalAlign="center" />
                                                <RowStyle CssClass="rowstyle" />
                                                <SelectedRowStyle Font-Bold="True" Font-Italic="True" ForeColor="#990033" />
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style12" colspan="4" style="text-align: left">
                                            <asp:Label ID="lblDHName0" runat="server" CssClass="labelling" Font-Bold="True" Text="SELECTED LOAN"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style8" colspan="4">
                                            <asp:GridView ID="GridView1" runat="server" Width="100%">
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style13" colspan="4" style="text-align: left">
                                            <asp:Label ID="lblDHName1" runat="server" CssClass="labelling" Font-Bold="True" Text="SCHEDULED PAYMENTS"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style9" colspan="4">
                                            <asp:GridView ID="GridView2" runat="server" Width="100%">
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4" style="text-align: center">
                                            <asp:Label ID="lblDHName2" runat="server" CssClass="labelling" Font-Bold="True" Text="NEW LOAN DETAILS"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style18">
                                            <asp:Label ID="lblDHAsAt" runat="server" CssClass="labelling" Text="Loan Amount Applied For"></asp:Label>
                                        </td>
                                        <td class="auto-style10">
                                            <asp:TextBox ID="txtFinReqAmt" runat="server" Height="22px" Width="200px">0</asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblDHName" runat="server" CssClass="labelling" Text="Repayment (Months)"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtFinReqTenor" runat="server" Height="22px" Width="200px">0</asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style19">
                                            <asp:Label ID="lblDHAsAt0" runat="server" CssClass="labelling" Text="Admin Fee"></asp:Label>
                                        </td>
                                        <td class="auto-style11">
                                            <asp:TextBox ID="txtAdminFee" runat="server" Height="22px" Width="200px">0</asp:TextBox>
                                        </td>
                                        <td class="auto-style3">
                                            <asp:Label ID="Label47" runat="server" CssClass="labelling" Text="Interest Rate %"></asp:Label>
                                        </td>
                                        <td class="auto-style3">
                                            <asp:TextBox ID="txtFinReqIntRate" runat="server" Height="22px" Width="200px">0</asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style18">
                                            <asp:Label ID="Label18" runat="server" CssClass="labelling" Text="1st Repayment Date"></asp:Label>
                                        </td>
                                        <td class="auto-style10">
                                            <asp:TextBox ID="bdpFinReqRepaymt" runat="server" CssClass="form-control input-sm datepicker"></asp:TextBox>
                                            <span class="glyphicon glyphicon-calendar form-control-feedback" style="margin-right: 13px; background-color: #eeeeff; border-radius: 0 3px 3px 0; border: 1px solid rgb(149,188,219); z-index: 0;"></span>
                                        </td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td colspan="4" style="text-align: center">
                                            <asp:Button ID="btnModifyChange" runat="server" Text="Update Change" Width="149px" />
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>

                    <tr>
                        <td>
                            <asp:Panel ID="Panel1" runat="server" Visible="False">
                                <table style="width: 100%;">
                                    <tr>
                                        <td style="text-align: left">
                                            <asp:Label ID="Label21" runat="server" Text="Search Name"></asp:Label>
                                            <asp:TextBox ID="txtSearchName" runat="server" Width="200"></asp:TextBox>
                                            <asp:Button ID="btnSearchRange" runat="server" Text="&gt;&gt;" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: left">
                                            <asp:Label ID="Label48" runat="server" Text="By EC No."></asp:Label>
                                            &nbsp;&nbsp;&nbsp;&nbsp;
                                                              <asp:TextBox ID="txtECNumber" runat="server" Width="200"></asp:TextBox>
                                            <asp:Button ID="btnSearchECNo" runat="server" Text="&gt;&gt;" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: left">
                                            <asp:Button ID="btnSelectAll" runat="server" Text="Select All" Width="143px" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:GridView ID="grdApps" runat="server" AllowPaging="True" EmptyDataText="No applications ready for processing" Width="100%">
                                                <AlternatingRowStyle CssClass="altrowstyle" />
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Mark">
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="Chk" runat="server" AutoPostBack="false" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField ShowHeader="False">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandArgument='<%# Eval("ID") %>' CommandName="Select" Text="Select"></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                                <HeaderStyle CssClass="headerstyle" HorizontalAlign="center" />
                                                <RowStyle CssClass="rowstyle" />
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: center">
                                            <asp:Button ID="btnModify" runat="server" Text="Update for SSB" Width="149px" />
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>

                    <tr>
                        <td style="text-align: center">&nbsp;</td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
</asp:Content>