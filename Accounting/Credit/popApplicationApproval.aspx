<%@ Page Language="VB" AutoEventWireup="false" CodeFile="popApplicationApproval.aspx.vb" Inherits="Credit_popApplicationApproval" Title="Application Approval - Credit Management System" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>
                <asp:Label ID="Label1" runat="server" Text="Application Approval"></asp:Label>
            </h1>
            <br />
            <table>
                <tr>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="Application Number: "></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblAppNo" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label3" runat="server" Text="Applicant Name"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblAppName" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label4" runat="server" Text="Application Date"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblAppDate" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label6" runat="server" Text="Amount"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblAmount" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="2">
                        <asp:Button ID="btnApprove" runat="server" Text="Approve" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>