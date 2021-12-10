<%@ Page Language="VB" AutoEventWireup="false" CodeFile="BalanceSheetReport.aspx.vb" Inherits="Accounting_BalanceSheet" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">

        .auto-style4 {
            width: 339px;
            text-align: center;
        }
        .auto-style3 {
            width: 399px;
        }
        .auto-style8 {
            width: 399px;
            height: 26px;
        }
        .auto-style13 {
            width: 399px;
            height: 23px;
        }
        .auto-style14 {
            text-align: right;
            width: 136px;
            height: 23px;
        }
        .auto-style15 {
            text-align: left;
            width: 117px;
            height: 23px;
        }
        .auto-style16 {
            background-color: #CCCCCC;
        }
        .auto-style17 {
            background-color: #999999;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table style="width:95%; margin-right: 6px;">
            <tr>
                <td class="auto-style1">
                    <table style="width:100%;">
                        <tr>
                            <td class="auto-style4" style="text-align: left">
                    <img alt="" src="../Images/quest_logo-cut.jpg" style="height: 120px; width: 120px" /></td>
                        </tr>
                        <tr>
                            <td class="auto-style4">
                    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Italic="False" Font-Size="16pt" Font-Underline="True" Text="Escrow Financial Services"></asp:Label>
                                <br />
                    <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Italic="False" Font-Size="16pt" Font-Underline="True" Text="Balance Sheet Report"></asp:Label>
                                <br />
                    <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Italic="False" Font-Size="14pt" Font-Underline="True" style="" Text="Period:"></asp:Label>
                    <asp:Label ID="lblDateFrom" runat="server" Font-Bold="True" Font-Italic="False" Font-Size="14pt" Font-Underline="True" style=""></asp:Label>
                    <asp:Label ID="lblDateTo" runat="server" Font-Bold="True" Font-Italic="False" Font-Size="14pt" Font-Underline="True" style=""></asp:Label>
                                <br />
                            </td>
                        </tr>
                        </table>
                </td>
            </tr>
            <tr>
                <td class="auto-style13">
                    <asp:HyperLink ID="HyperLink1" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="12pt" Font-Underline="True" ForeColor="Blue" NavigateUrl="Income.aspx" Target="_Blank">Assets</asp:HyperLink>
                </td>
            </tr>
            <tr>
                <td class="auto-style13">
                    <asp:Label ID="Label6" runat="server" Font-Bold="True" Font-Names="Arial" Font-Underline="True" Text="Fixed Assests"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">
                    <asp:GridView ID="grdIncome" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" GridLines="Vertical" Height="59px" style="margin-right: 58px" Width="1181px">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="Acc">
                            <HeaderStyle Width="400px" />
                            </asp:BoundField>
                            <asp:BoundField>
                            <HeaderStyle Width="100px" />
                            <ItemStyle HorizontalAlign="Right" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Amount" HeaderText="Amount">
                            <HeaderStyle Width="100px" />
                            <ItemStyle HorizontalAlign="Right" />
                            </asp:BoundField>
                        </Columns>
                        <FooterStyle BackColor="#CCCC99" />
                        <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                        <RowStyle BackColor="#F7F7DE" />
                        <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#FBFBF2" />
                        <SortedAscendingHeaderStyle BackColor="#848384" />
                        <SortedDescendingCellStyle BackColor="#EAEAD3" />
                        <SortedDescendingHeaderStyle BackColor="#575357" />
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">
                    <asp:Label ID="Label7" runat="server" Font-Bold="True" Font-Names="Arial" Font-Underline="True" Text="Current  Assests"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">
                    <asp:GridView ID="grdIncome1" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" GridLines="Vertical" Height="59px" style="margin-right: 58px" Width="1181px">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="Acc">
                            <HeaderStyle Width="400px" />
                            </asp:BoundField>
                            <asp:BoundField>
                            <HeaderStyle Width="100px" />
                            <ItemStyle HorizontalAlign="Right" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Amount" HeaderText="Amount">
                            <HeaderStyle Width="100px" />
                            <ItemStyle HorizontalAlign="Right" />
                            </asp:BoundField>
                        </Columns>
                        <FooterStyle BackColor="#CCCC99" />
                        <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                        <RowStyle BackColor="#F7F7DE" />
                        <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#FBFBF2" />
                        <SortedAscendingHeaderStyle BackColor="#848384" />
                        <SortedDescendingCellStyle BackColor="#EAEAD3" />
                        <SortedDescendingHeaderStyle BackColor="#575357" />
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">
                    <asp:Label ID="lblDateTo2" runat="server" Font-Bold="True" Font-Italic="False" Font-Size="11pt" Font-Underline="False" Font-Names="Calibri" CssClass="auto-style16">Total Assets</asp:Label>
                    <asp:Label ID="lblTotalIn" runat="server" Font-Bold="True" Font-Italic="False" Font-Size="11pt" Font-Underline="False" Font-Names="Calibri" BorderStyle="None" CssClass="auto-style16" style="text-align: right" Width="1057px">$0.00</asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">
                    <asp:HyperLink ID="HyperLink2" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="12pt" Font-Underline="True" ForeColor="Blue" NavigateUrl="rptExpenses.aspx" Target="_Blank">Liabilities</asp:HyperLink>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">
                    <asp:GridView ID="grdIncome0" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" GridLines="Vertical" Height="59px" Width="1178px">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="Acc">
                            <HeaderStyle Width="400px" />
                            </asp:BoundField>
                            <asp:BoundField>
                            <HeaderStyle Width="100px" />
                            <ItemStyle HorizontalAlign="Right" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Amount" HeaderText="Amount">
                            <HeaderStyle Width="100px" />
                            <ItemStyle HorizontalAlign="Right" />
                            </asp:BoundField>
                        </Columns>
                        <FooterStyle BackColor="#CCCC99" />
                        <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                        <RowStyle BackColor="#F7F7DE" />
                        <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#FBFBF2" />
                        <SortedAscendingHeaderStyle BackColor="#848384" />
                        <SortedDescendingCellStyle BackColor="#EAEAD3" />
                        <SortedDescendingHeaderStyle BackColor="#575357" />
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style8">
                </td>
            </tr>
            <tr>
                <td class="auto-style15">
                    <asp:Label ID="lblDateTo3" runat="server" Font-Bold="True" Font-Italic="False" Font-Size="11pt" Font-Underline="False" Font-Names="Calibri" CssClass="auto-style17">Total Liabilities</asp:Label>
                    <asp:Label ID="lblTotalEx" runat="server" Font-Bold="True" Font-Italic="False" Font-Size="11pt" Font-Underline="False" Font-Names="Calibri" BorderStyle="None" CssClass="auto-style17" style="text-align: right" Width="872px">$0.00</asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style15">
                    <asp:Label ID="lblDateTo4" runat="server" Font-Bold="True" Font-Italic="False" Font-Size="11pt" Font-Underline="False" Font-Names="Calibri" CssClass="auto-style17">Net Assests</asp:Label>
                    <asp:Label ID="lblNet" runat="server" Font-Bold="True" Font-Italic="False" Font-Size="11pt" Font-Underline="False" Font-Names="Calibri" BorderStyle="None" CssClass="auto-style17" style="text-align: right" Width="1028px">$0.00</asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style14">
                    &nbsp;</td>
            </tr>
            </table>
    
    </div>
    </form>
</body>
</html>
