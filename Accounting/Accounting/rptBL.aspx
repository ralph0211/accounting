<%@ Page Language="VB" AutoEventWireup="false" CodeFile="rptBL.aspx.vb" Inherits="Accounting_rptBL" %>

<%--<%@ Register Assembly="DevExpress.XtraReports.v13.2.Web, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraReports.Web" TagPrefix="dx" %>--%>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Balance Sheet</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <%--<dx:ASPxDocumentViewer ID="ASPxDocumentViewer1" runat="server" ReportTypeName="xrptBalanceSheet"></dx:ASPxDocumentViewer>--%>
            <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server"
                AutoDataBind="true" EnableDatabaseLogonPrompt="False"
                EnableParameterPrompt="False" ReuseParameterValuesOnRefresh="True" />
        </div>
    </form>
</body>
</html>