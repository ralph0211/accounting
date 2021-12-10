<%@ Page Language="VB" AutoEventWireup="false" CodeFile="rptTrailBalance.aspx.vb" Inherits="QUEST_Accounting_rptTrailBalance" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Full Trial Balance</title>
    <style type="text/css">
        .auto-style2 {
        }

        .auto-style3 {
            height: 20px;
        }

        .auto-style4 {
            width: 121px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div>

                <table style="width: 22%; margin-left: 40px;">
                    <tr>
                        <td class="auto-style4">
                            <img alt="" src="../Images/quest_logo-cut.jpg" style="height: 157px; width: 163px" /></td>
                        <td class="auto-style2" style="text-align: center">
                            <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Italic="False" Font-Size="16pt" Font-Underline="True" Text="Trial Balance"></asp:Label>
                            <br />
                            <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Italic="False" Font-Size="14pt" Font-Underline="True" Style="" Text="As At"></asp:Label>
                            <asp:Label ID="lblDateFrom" runat="server" Font-Bold="True" Font-Italic="False" Font-Size="14pt" Font-Underline="True" Style=""></asp:Label>
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:GridView ID="grdDetails" runat="server" BackColor="White" ShowFooter="true" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" Font-Names="Calibri" Font-Size="11pt" ForeColor="Black" GridLines="None" Width="1291px" AutoGenerateColumns="false">
                                <AlternatingRowStyle BackColor="White" />
                                <FooterStyle BackColor="#CCCC99" Font-Bold="true" />
                                <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                                <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                                <RowStyle BackColor="#F7F7DE" HorizontalAlign="Left" />
                                <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                                <SortedAscendingCellStyle BackColor="#FBFBF2" />
                                <SortedAscendingHeaderStyle BackColor="#848384" />
                                <SortedDescendingCellStyle BackColor="#EAEAD3" />
                                <SortedDescendingHeaderStyle BackColor="#575357" />
                                <Columns>
                                    <asp:BoundField DataField="AccNo" HeaderText="Account Number" ItemStyle-HorizontalAlign="Left" />
                                    <asp:TemplateField HeaderText="Description">
                                        <ItemTemplate>
                                            <asp:Label ID="Label2" runat="server" Text='<%# Eval("Description")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Debit" HeaderText="Debit" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="right" FooterStyle-HorizontalAlign="Right" DataFormatString="{0:N}" />
                                    <asp:BoundField DataField="Credit" HeaderText="Credit" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="right" FooterStyle-HorizontalAlign="Right" DataFormatString="{0:N}" />
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" class="auto-style3" style="text-align: right; margin-left: 40px">
                            <asp:Label ID="lblDebitsTotal" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Verdana" Font-Size="10pt" Width="195px" Style="text-align: left"></asp:Label>
                            <asp:Label ID="lblCreditotal" runat="server" BorderStyle="None" Font-Bold="True" Font-Names="Verdana" Font-Size="10pt" Width="188px" Style="text-align: left"></asp:Label>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </form>
</body>
</html>