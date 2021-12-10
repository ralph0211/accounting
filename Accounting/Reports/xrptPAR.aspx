<%@ Page Language="VB" AutoEventWireup="false" CodeFile="xrptPAR.aspx.vb" Inherits="Reports_xrptPAR" %>

<%@ Register Assembly="DevExpress.XtraReports.v13.2.Web, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraReports.Web" TagPrefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Portfolio At Risk (PAR) Report</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <dx:ASPxDocumentViewer ID="ASPxDocumentViewer1" runat="server" ReportTypeName="xrptPAR"></dx:ASPxDocumentViewer>
        </div>
    </form>
</body>
</html>