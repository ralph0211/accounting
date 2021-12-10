<%@ Page Language="VB" AutoEventWireup="false" CodeFile="rotInvoicePrint.aspx.vb" Inherits="Accounting_rotInvoicePrint" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 453px;
        }
        .auto-style2 {
            height: 17px;
            width: 268435456px;
        }
        .auto-style4 {
        }
        .auto-style6 {
            width: 268435456px;
        }
        .auto-style7 {
            text-align: right;
        }
        .auto-style8 {
            width: 268435456px;
            height: 30px;
        }
        .auto-style9 {
            width: 760px;
        }
        .auto-style10 {
            width: 992px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    <div>
    
        <table style="border: thin solid #C0C0C0; width: 57%; font-family: verdana, Geneva, Tahoma, sans-serif; font-size: 11px; height: 1034px;">
            <tr>
                <td class="auto-style10" rowspan="5" style="border: thin solid #C0C0C0; vertical-align: top;">
                    <img alt="" src="../Images/quest_logo-cut.jpg" style="height: 127px; width: 138px" /><br />
                    <asp:Label ID="Label12" runat="server" BorderStyle="None" Text="Escrow Financial Services" Width="575px" Height="18px" style="font-weight: 700; text-decoration: underline"></asp:Label>
                    <br />
                </td>
                <td colspan="2" style="border: thin solid #C0C0C0; text-align: center;">
                    <asp:Label ID="Label1" runat="server" BorderStyle="None" style="font-weight: 700" Text="Fiscal/Supplyer Invoice" Width="182px"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2" style="border: thin solid #C0C0C0" class="auto-style7">
                    <asp:Label ID="Label2" runat="server" BorderStyle="None" Text="Page" Width="150px"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2" style="border: thin solid #C0C0C0" class="auto-style7">
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="2" style="border: thin solid #C0C0C0" class="auto-style7">
                    <asp:Label ID="Label3" runat="server" BorderStyle="None" Text="Refrence" Width="150px"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2" style="border: thin solid #C0C0C0" class="auto-style7">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style10" rowspan="2" style="border: thin solid #C0C0C0">
                    &nbsp;</td>
                <td colspan="2" style="border: thin solid #C0C0C0" class="auto-style7">&nbsp;</td>
            </tr>
            <tr>
                <td colspan="2" style="border: thin solid #C0C0C0" class="auto-style7">
                    <asp:Label ID="Name" runat="server" BorderStyle="None" Width="150px"></asp:Label>
                    <br />
                    <asp:Label ID="lblAddress" runat="server" BorderStyle="None" Height="65px" Width="227px"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style4" colspan="3">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1" colspan="3" style="border: thin solid #C0C0C0; vertical-align: top;">
                    <asp:GridView ID="grdDetails" runat="server" CellPadding="4" Font-Names="Arial" Font-Size="Small" ForeColor="#333333" GridLines="None" HorizontalAlign="Left" Width="988px">
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Left" />
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        <HeaderStyle BackColor="#023E5A" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                        <EditRowStyle BackColor="#999999" Font-Names="Arial" Font-Size="Small" HorizontalAlign="Left" />
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" HorizontalAlign="Left" />
                        <SortedAscendingCellStyle BackColor="#E9E7E2" />
                        <SortedAscendingHeaderStyle BackColor="#506C8C" />
                        <SortedDescendingCellStyle BackColor="#FFFDF8" />
                        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td colspan="2" rowspan="5" style="border: thin solid #C0C0C0" class="auto-style9">&nbsp;</td>
                <td class="auto-style8" style="border: thin solid #C0C0C0">
                    <asp:Label ID="Label4" runat="server" BorderStyle="None" Text="Sub Total" Width="300px"></asp:Label>
                    <asp:Label ID="Label8" runat="server" BorderStyle="None" style="font-weight: 700" Text="$0.00" Width="71px"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style2" style="border: thin solid #C0C0C0">
                    <asp:Label ID="Label5" runat="server" BorderStyle="None" Text="Discount" Width="300px" Height="16px"></asp:Label>
                    <asp:Label ID="Label9" runat="server" BorderStyle="None" style="font-weight: 700" Text="$0.00" Width="71px"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style6" style="border: thin solid #C0C0C0">
                    <asp:Label ID="Label6" runat="server" BorderStyle="None" Text="Amount Excl Tax" Width="300px"></asp:Label>
                    <asp:Label ID="Label10" runat="server" BorderStyle="None" style="font-weight: 700" Text="$0.00" Width="71px"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style6" style="border: thin solid #C0C0C0">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style8" style="border: thin solid #C0C0C0">
                    <asp:Label ID="Label7" runat="server" BorderStyle="None" style="font-weight: 700" Text="Total" Width="300px"></asp:Label>
                    <asp:Label ID="Label11" runat="server" BorderStyle="None" style="font-weight: 700" Text="$0.00" Width="71px"></asp:Label>
                </td>
            </tr>
        </table>
    
    </div>
    
    </div>
    </form>
</body>
</html>
