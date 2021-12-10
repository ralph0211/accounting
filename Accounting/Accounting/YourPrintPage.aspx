<%@ Page Language="VB" AutoEventWireup="false" CodeFile="YourPrintPage.aspx.vb" Inherits="Accounting_YourPrintPage" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <style type="text/css">
        @media print {
            * {
                margin: 0 !important;
                padding: 0 !important;
            }

            #controls, .footer, .header, .footerarea {
                display: none;
            }

            html, body {
                /*changing width to 100% causes huge overflow and wrap*/
                height: 100%;
                overflow: hidden;
                background: #FFF;
                font-size: 0pt;
            }
        }
    </style>
    <script language='VBScript'>
Sub Print()
       OLECMDID_PRINT = 6
       OLECMDEXECOPT_DONTPROMPTUSER = 2
       OLECMDEXECOPT_PROMPTUSER = 1
       call WB.ExecWB(OLECMDID_PRINT, OLECMDEXECOPT_DONTPROMPTUSER,1)
End Sub
document.write "<object ID='WB' WIDTH=0 HEIGHT=0 CLASSID='CLSID:8856F961-340A-11D0-A96B-00C04FD705A2'></object>"
    </script>
    <script language="javascript">
        window.print();
        window.close();
    </script>
    <script id="DivPrintt" type="text/javascript">
    </script>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div id="header"></div>
        <div class="noPrint" style="color: white; font-size: 0;">
        </div>
        <div id="crystal">
            <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true"
                EnableDatabaseLogonPrompt="False" EnableParameterPrompt="False"
                ReuseParameterValuesOnRefresh="True" HasToggleGroupTreeButton="False" HasDrilldownTabs="False"
                DisplayToolbar="False"></CR:CrystalReportViewer>
        </div>
        <div id="footer"></div>
    </form>
</body>
</html>
