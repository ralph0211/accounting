<%@ Page Language="VB" MasterPageFile="~/Site2.master" AutoEventWireup="false" CodeFile="frmLoanRepayments.aspx.vb" Inherits="frmLoanRepayments" Title="Loan Repayments Report" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table id="TABLE1" border="0" cellpadding="0" cellspacing="0" width="100%" style="height: 31%; margin-top: 0px;" align="center">
        <tr>
            <td valign="top" align="center" colspan="2">
                <asp:Menu ID="menuTabs" runat="server" BackColor="#336699"
                    DynamicHorizontalOffset="2" DynamicHoverStyle-BackColor="#336699"
                    DynamicHoverStyle-ForeColor="White" Font-Names="Verdana" Font-Size="0.8em"
                    ForeColor="White" Height="18px" Orientation="Horizontal"
                    StaticMenuItemStyle-CssClass="tab" StaticSelectedStyle-CssClass="selectedTab"
                    StaticSubMenuIndent="10px" Style="top: 4px; left: 2px" Width="776px">
                    <StaticMenuStyle BackColor="#336699" />
                    <StaticSelectedStyle BackColor="White" BorderColor="#1D72A7"
                        BorderStyle="Dotted" BorderWidth="1px" ForeColor="#FFFFFF" />
                    <StaticMenuItemStyle BackColor="#FA9221" HorizontalPadding="5px"
                        VerticalPadding="2px" />
                    <%--CssClass="tab"--%>

                    <DynamicHoverStyle BackColor="#FA9221" ForeColor="White" />
                    <DynamicMenuStyle BackColor="#FA9221" />
                    <DynamicSelectedStyle BackColor="#FA9221" />
                    <DynamicMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
                    <StaticHoverStyle BackColor="#FA9266" ForeColor="White" />
                    <Items>
                        <asp:MenuItem NavigateUrl="~/frmSumLoanReports.aspx" Text="Loan Reports"
                            Value="Loan Reports"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/LoanbyBranch.aspx" Text="Loan Type Report"
                            Value="Loan Type Report"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/Loanbytype.aspx" Text="Loan Branch Report"
                            Value="Loan Branch Report"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/LoanByStatus.aspx" Text="Loan Status Report"
                            Value="Loan Status Report"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/frmDueRepayments.aspx" Text="Due Repayments"
                            Value="Due Repayments"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="frmLoanRepayments.aspx" Text="Repayments Report"
                            Value="Repayments Report"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/frmLoanAudit.aspx" Text="Audit Trail"
                            Value="Audit Trail"></asp:MenuItem>
                    </Items>
                </asp:Menu>
            </td>
        </tr>
    </table>
    <table bgcolor="#EEEEEE" style="width: 100%;">
        <tr>
            <td bgcolor="#023E5A" colspan="4">&nbsp;&nbsp;
                                            <br />
                <asp:Label ID="Label2" runat="server" Font-Names="Calibri" Font-Size="Large"
                    ForeColor="#FFFFFF" Text="Repayments Report"></asp:Label>
                <br />
            </td>
        </tr>
        <tr>
            <td style="height: 25px"></td>
        </tr>
        <tr>
            <td align="right" style="width: 52%">
                <asp:Label ID="Label8" runat="server" Font-Names="Calibri" ForeColor="#555555"
                    Text="From Date"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </td>
            <td align="left" width="75%" colspan="5">
                <asp:TextBox CssClass="col-xs-12 form-control input-sm datepicker" ID="bdpFromDate" runat="server"></asp:TextBox>
                <span class="glyphicon glyphicon-calendar form-control-feedback" style="margin-right: 13px; background-color: #eeeeff; border-radius: 0 3px 3px 0; border: 1px solid rgb(149,188,219); z-index: 0;"></span>
            </td>
        </tr>
        <tr>
            <td align="right" style="width: 52%">
                <asp:Label ID="Label9" runat="server" Font-Names="Calibri" ForeColor="#555555"
                    Text="To Date"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </td>
            <td align="left" width="75%" colspan="5">
                <asp:TextBox CssClass="col-xs-12 form-control input-sm datepicker" ID="bdpToDate" runat="server"></asp:TextBox>
                <span class="glyphicon glyphicon-calendar form-control-feedback" style="margin-right: 13px; background-color: #eeeeff; border-radius: 0 3px 3px 0; border: 1px solid rgb(149,188,219); z-index: 0;"></span>
            </td>
        </tr>

        <tr>
            <td align="right" style="height: 13px; width: 19%;">
                <asp:Label ID="Label3" runat="server" Font-Names="Calibri" ForeColor="#555555"
                    Text="Status" Visible="False"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </td>
            <td style="height: 13px">
                <asp:DropDownList ID="cmbStatus" AppendDataBoundItems="true" runat="server"
                    Height="22px" Width="227px" Visible="False">
                    <asp:ListItem Text="Select loan status" Value="-1" Selected="True" />
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td align="left" style="height: 27px; width: 19%;">&nbsp;</td>
            <td>&nbsp;<asp:Button ID="btnCheck" runat="server" CssClass="Button_Style"
                Style="position: relative; top: 2px; left: -1px;" Text="Print"
                BackColor="Silver" ForeColor="#FF6600" />
            </td>
        </tr>
        <tr>
            <td style="height: 2px; width: 19%;">&nbsp;</td>
            <td style="height: 2px">&nbsp;</td>
        </tr>
        <tr>
            <td style="height: 2px; width: 19%;"></td>
            <td style="height: 2px">&nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="lblValid" runat="server" CssClass="Button_Style"
                    Font-Bold="True" Font-Names="Georgia" Font-Size="Small"
                    Style="position: relative"></asp:Label>
            </td>
        </tr>

        <tr>
            <td colspan="2">&nbsp;</td>
        </tr>
    </table>
</asp:Content>