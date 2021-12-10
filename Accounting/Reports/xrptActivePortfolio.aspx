<%@ Page Language="VB" AutoEventWireup="false" CodeFile="xrptActivePortfolio.aspx.vb" Inherits="Reports_xrptActivePortfolio" %>

<%@ Register Assembly="DevExpress.XtraReports.v13.2.Web, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraReports.Web" TagPrefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Active Portfolio Report</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <dx:ASPxDocumentViewer ID="ASPxDocumentViewer1" runat="server" ReportTypeName="xrptActivePortfolio"></dx:ASPxDocumentViewer>
        </div>
    </form>
</body>
</html>