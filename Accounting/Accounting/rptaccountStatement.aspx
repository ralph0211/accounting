<%@ Page Language="VB" AutoEventWireup="false" CodeFile="rptaccountStatement.aspx.vb" Inherits="Accounting_rptaccountStatement" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Print Account Statement</title>
    <style type="text/css">
        .auto-style10 {
            width: 918px;
        }

        .auto-style7 {
            text-align: right;
        }

        .auto-style1 {
            height: 453px;
        }

        .auto-style9 {
            width: 760px;
        }

        .auto-style8 {
            width: 268435456px;
            height: 30px;
        }

        .auto-style2 {
            height: 17px;
            width: 268435456px;
        }

        .auto-style6 {
            width: 268435456px;
        }

        .auto-style11 {
            font-weight: bold;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <table style="border: thin solid #C0C0C0; width: 57%; font-family: verdana, Geneva, Tahoma, sans-serif; font-size: 11px; height: 1034px;">
                <tr>
                    <td class="auto-style10" rowspan="6" style="border: thin solid #C0C0C0; vertical-align: top;">
                        <img alt="" src="../Images/quest_logo-cut.jpg" style="height: 127px; width: 138px" /><br />
                        <asp:Label ID="Label12" runat="server" BorderStyle="None" Text='<%#Session("CompanyName") %>' Width="575px" Height="18px" Style="font-weight: 700; text-decoration: underline"></asp:Label>
                        <br />
                    </td>
                    <td colspan="2" style="border: thin solid #C0C0C0; text-align: center; background-color: #023E5A;">
                        <asp:Label ID="Label1" runat="server" BorderStyle="None" Style="font-weight: 700; color: #FFFFFF;" Text="Account Statement" Width="182px" Font-Names="Arial" Font-Size="14pt" ForeColor="#023E5A"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="border: thin solid #C0C0C0" class="auto-style7">
                        <asp:Label ID="lblAccType" runat="server" BorderStyle="None" CssClass="auto-style11">Acount Type:</asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="border: thin solid #C0C0C0" class="auto-style7">
                        <asp:Label ID="lblAccName" runat="server" BorderStyle="None" Text="Account Name:" CssClass="auto-style11"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="border: thin solid #C0C0C0" class="auto-style7">
                        <asp:Label ID="lblAccNo" runat="server" BorderStyle="None" Text="Account Number:" CssClass="auto-style11"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="border: thin solid #C0C0C0" class="auto-style7">
                        <asp:Label ID="lblPrintDate" runat="server" BorderStyle="None" Text="Print Date:   " CssClass="auto-style11"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="border: thin solid #C0C0C0" class="auto-style7">
                        <asp:Label ID="lblDateRange" runat="server" BorderStyle="None" Text="" CssClass="auto-style11"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style10" rowspan="2" style="border: thin solid #C0C0C0">&nbsp;</td>
                    <td colspan="2" style="border: thin solid #C0C0C0; background-color: #023E5A;" class="auto-style7">&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="2" style="border: thin solid #C0C0C0" class="auto-style7">
                        <asp:Label ID="Name" runat="server" BorderStyle="None"></asp:Label>
                        <asp:Label ID="lblAddress" runat="server" BorderStyle="None" Height="65px" Width="227px" Font-Bold="true"></asp:Label>
                        <br />
                        <asp:Label ID="lblAccruedCapital" runat="server" BorderStyle="None" Height="65px" Width="227px" Font-Bold="true"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4" colspan="3">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style1" colspan="3" style="border: thin solid #C0C0C0; vertical-align: top;">
                        <asp:Label ID="lblNoTrxns" runat="server" BorderStyle="None" Text="No Transactions for this Account in the selected Period" Width="575px" Height="18px" Style="font-weight: 700;" Visible="false"></asp:Label>
                        <br />
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
                    <td colspan="2" rowspan="5" style="border: thin solid #C0C0C0" class="auto-style9">
                        <asp:Label ID="lblOB0" runat="server" BorderStyle="None" Style="font-weight: 700" Text="Prepared By : ...................................................................................................................." Width="587px"></asp:Label>
                        <br />
                        <br />
                        <br />
                        <asp:Label ID="lblOB1" runat="server" BorderStyle="None" Style="font-weight: 700" Text="Sign / Stamp : ..................................................................................................................." Width="586px"></asp:Label>
                        <br />
                        <br />
                        <br />
                        <asp:Label ID="lblOB2" runat="server" BorderStyle="None" Style="font-weight: 700" Text="Date : .........................................................................................................................." Width="587px"></asp:Label>
                    </td>
                    <td class="auto-style8" style="border: thin solid #C0C0C0; text-align: center; background-color: #023E5A;">
                        <asp:Label ID="Label17" runat="server" BorderStyle="None" Style="font-weight: 700; color: #FFFFFF;" Text="Account Summary" Width="182px" Font-Names="Arial" Font-Size="11pt" ForeColor="#023E5A"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2" style="border: thin solid #C0C0C0">
                        <asp:Label ID="Label4" runat="server" BorderStyle="None" Text="Opening Balance" Width="300px"></asp:Label>
                        <asp:Label ID="lblOB" runat="server" BorderStyle="None" Style="font-weight: 700" Text="$0.00" Width="71px"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style6" style="border: thin solid #C0C0C0">
                        <asp:Label ID="Label5" runat="server" BorderStyle="None" Text="Total Debits" Width="300px" Height="16px"></asp:Label>
                        <asp:Label ID="lblTotDr" runat="server" BorderStyle="None" Style="font-weight: 700" Text="$0.00" Width="71px"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style6" style="border: thin solid #C0C0C0">
                        <asp:Label ID="Label6" runat="server" BorderStyle="None" Text="Total Credits" Width="300px"></asp:Label>
                        <asp:Label ID="lblTotCr" runat="server" BorderStyle="None" Style="font-weight: 700" Text="$0.00" Width="71px"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style8" style="border: thin solid #C0C0C0">
                        <asp:Label ID="Label7" runat="server" BorderStyle="None" Style="font-weight: 700" Text="Closing Balance" Width="300px"></asp:Label>
                        <asp:Label ID="lblCB" runat="server" BorderStyle="None" Style="font-weight: 700" Text="$0.00" Width="71px"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>