<%@ Page Language="VB" AutoEventWireup="false" CodeFile="rptOutreach.aspx.vb" Inherits="Credit_rptOutreach" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Outreach Indicators - Credit Management System</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="Indicator"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="cmbIndicator" runat="server">
                            <asp:ListItem Text="Age" Value="Age"></asp:ListItem>
                            <asp:ListItem Text="Area" Value="A"></asp:ListItem>
                            <asp:ListItem Text="Gender" Value="G"></asp:ListItem>
                            <asp:ListItem Text="Purpose" Value="P"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="Date Range From"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" ID="bdpFromDate" runat="server" CssClass="col-xs-12 form-control input-sm datepicker"></asp:TextBox>
                        <span class="glyphicon glyphicon-calendar form-control-feedback" style="margin-right: 13px; background-color: #eeeeff; border-radius: 0 3px 3px 0; border: 1px solid rgb(149,188,219); z-index: 0;"></span>
                    </td>
                    <td>
                        <asp:Label ID="Label3" runat="server" Text="To"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" ID="bdpToDate" runat="server" CssClass="col-xs-12 form-control input-sm datepicker"></asp:TextBox>
                        <span class="glyphicon glyphicon-calendar form-control-feedback" style="margin-right: 13px; background-color: #eeeeff; border-radius: 0 3px 3px 0; border: 1px solid rgb(149,188,219); z-index: 0;"></span>
                    </td>
                    <td>
                        <asp:Button ID="btnLoadReport" runat="server" Text=">>" />
                    </td>
                </tr>
            </table>
        </div>
        <div>
            <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server"
                AutoDataBind="true" EnableDatabaseLogonPrompt="False"
                EnableParameterPrompt="False" />
        </div>
    </form>
</body>
</html>