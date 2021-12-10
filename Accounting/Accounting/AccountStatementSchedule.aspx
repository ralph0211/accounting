<%@ Page Title="Account Statement Schedule" Language="VB" MasterPageFile="~/Site2.master" AutoEventWireup="false" CodeFile="AccountStatementSchedule.aspx.vb" Inherits="Accounting_AccountStatementSchedule" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../Content/chosen.min.css" rel="stylesheet" />
    <style type="text/css">
        .auto-style1 {
            width: 119px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table bgcolor="#EEEEEE" style="width: 100%;">
        <tr>
            <td bgcolor="#023E5A" colspan="5">&nbsp;<br />
                &nbsp;&nbsp;
                                            <asp:Label ID="Label9" runat="server" Font-Names="Calibri" Font-Size="Large"
                                                ForeColor="White" Text="Account Statement Schedule"></asp:Label>
                <br />
            </td>
        </tr>
        <tr>
            <td colspan="5">&nbsp;
                                            <hr size="1" style="color: #7C8D59" width="95%" />
            </td>
        </tr>
        <tr>
            <td align="center" colspan="5">
                <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Calibri" ForeColor="#555555" Text=""></asp:Label>
            </td>
        </tr>
        <%--<tr>
            <td colspan="5" align="center">
                <asp:RadioButtonList ID="rdType" runat="server" AutoPostBack="True" Font-Bold="True" Font-Names="Verdana" Font-Size="10pt" RepeatDirection="Horizontal" Width="398px">
                    <asp:ListItem Value="211/1">Cash</asp:ListItem>
                    <asp:ListItem Value="212/2">Bank</asp:ListItem>
                    <asp:ListItem Value="213/1">Loans and Advances</asp:ListItem>
                    <asp:ListItem>Other</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>--%>
        <tr>
            <td class="auto-style1">&nbsp;</td>
            <td align="right">
                <asp:Label ID="lblAccount" runat="server" Font-Names="Calibri" ForeColor="#555555" Text="Main Account&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;"></asp:Label>
            </td>
            <td colspan="2">
                <asp:DropDownList ID="cmbBatchRef" runat="server" CssClass="dd_select2" Width="300px">
                </asp:DropDownList>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td align="center" colspan="5">&nbsp;</td>
        </tr>
        <tr>
            <td align="center" colspan="5">
                <asp:Button ID="btnPrint" runat="server" Text="Print Report" />
            </td>
        </tr>
        <tr>
            <td align="center" colspan="5">&nbsp;</td>
        </tr>
    </table>
    <script src="../Scripts/jquery-1.8.0.min.js"></script>
    <script src="../Scripts/chosen.jquery.min.js"></script>
    <script type="text/javascript">
        $(".dd_select2").chosen();
    </script>
</asp:Content>