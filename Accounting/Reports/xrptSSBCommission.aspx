<%@ Page Language="VB" AutoEventWireup="false" CodeFile="xrptSSBCommission.aspx.vb" Inherits="Reports_xrptSSBCommission" %>

<%@ Register Assembly="DevExpress.XtraReports.v13.2.Web, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraReports.Web" TagPrefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>SSB Commission Report</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <dx:ASPxDocumentViewer ID="ASPxDocumentViewer1" runat="server" ReportTypeName="xrptSSBCommission"></dx:ASPxDocumentViewer>
        </div>
    </form>
</body>
</html>