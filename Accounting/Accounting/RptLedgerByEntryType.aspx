<%@ Page Language="VB" AutoEventWireup="false" CodeFile="RptLedgerByEntryType.aspx.vb" Inherits="Accounting_RptLedgerByEntryType" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 86px;
        }
        .auto-style2 {
            width: 650px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table style="width:100%;">
            <tr>
                <td class="auto-style1">
                    <img alt="" src="../Images/quest_logo-cut.jpg" style="height: 157px; width: 163px" /></td>
                <td class="auto-style2" style="text-align: center">
                    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Italic="False" Font-Size="16pt" Font-Underline="True" Text="Ledger By Entry Type"></asp:Label>
                    <br />
                    <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Italic="False" Font-Size="14pt" Font-Underline="True" style="" Text="Entry"></asp:Label>
&nbsp;&nbsp;
                    <asp:Label ID="lblAccount" runat="server" Font-Bold="True" Font-Italic="False" Font-Size="14pt" Font-Underline="True" style=""></asp:Label>
                    <br />
                    <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Italic="False" Font-Size="14pt" Font-Underline="True" style="" Text="Period:"></asp:Label>
                    <asp:Label ID="lblDateFrom" runat="server" Font-Bold="True" Font-Italic="False" Font-Size="14pt" Font-Underline="True" style=""></asp:Label>
&nbsp;-
                    <asp:Label ID="lblDateTo" runat="server" Font-Bold="True" Font-Italic="False" Font-Size="14pt" Font-Underline="True" style=""></asp:Label>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:GridView ID="grdDetails" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" Font-Names="Calibri" Font-Size="10pt" ForeColor="Black" GridLines="Horizontal" style="text-align: left" Width="1132px">
                        <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                        <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                        <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F7F7F7" />
                        <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                        <SortedDescendingCellStyle BackColor="#E5E5E5" />
                        <SortedDescendingHeaderStyle BackColor="#242121" />
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style2">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
