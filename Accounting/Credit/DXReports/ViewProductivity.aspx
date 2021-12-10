<%@ Page Language="VB" AutoEventWireup="false" CodeFile="ViewProductivity.aspx.vb" Inherits="Credit_DXReports_ViewProductivity" %>

<%@ Register Assembly="DevExpress.XtraReports.v13.2.Web, Version=13.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraReports.Web" TagPrefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Productivity Report</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table style="width: 100%;">
                <tr>
                    <td>
                        <dx:ReportToolbar ID="ReportToolbar1" runat="server" ReportViewerID="ReportViewer1" ShowDefaultButtons="False">
                            <Items>
                                <dx:ReportToolbarButton ItemKind="Search" />
                                <dx:ReportToolbarSeparator />
                                <dx:ReportToolbarButton ItemKind="PrintReport" />
                                <dx:ReportToolbarButton ItemKind="PrintPage" />
                                <dx:ReportToolbarSeparator />
                                <dx:ReportToolbarButton Enabled="False" ItemKind="FirstPage" />
                                <dx:ReportToolbarButton Enabled="False" ItemKind="PreviousPage" />
                                <dx:ReportToolbarLabel ItemKind="PageLabel" />
                                <dx:ReportToolbarComboBox ItemKind="PageNumber" Width="65px">
                                </dx:ReportToolbarComboBox>
                                <dx:ReportToolbarLabel ItemKind="OfLabel" />
                                <dx:ReportToolbarTextBox IsReadOnly="True" ItemKind="PageCount" />
                                <dx:ReportToolbarButton ItemKind="NextPage" />
                                <dx:ReportToolbarButton ItemKind="LastPage" />
                                <dx:ReportToolbarSeparator />
                                <dx:ReportToolbarButton ItemKind="SaveToDisk" />
                                <dx:ReportToolbarButton ItemKind="SaveToWindow" />
                                <dx:ReportToolbarComboBox ItemKind="SaveFormat" Width="70px">
                                    <Elements>
                                        <dx:ListElement Value="pdf" />
                                        <dx:ListElement Value="xls" />
                                        <dx:ListElement Value="xlsx" />
                                        <dx:ListElement Value="rtf" />
                                        <dx:ListElement Value="mht" />
                                        <dx:ListElement Value="html" />
                                        <dx:ListElement Value="txt" />
                                        <dx:ListElement Value="csv" />
                                        <dx:ListElement Value="png" />
                                    </Elements>
                                </dx:ReportToolbarComboBox>
                            </Items>
                            <Styles>
                                <LabelStyle>
                                    <Margins MarginLeft='3px' MarginRight='3px' />
                                </LabelStyle>
                            </Styles>
                        </dx:ReportToolbar>
                    </td>
                </tr>
                <tr>
                    <td>
                        <dx:ReportViewer ID="ReportViewer1" runat="server" Report="<%# new rptProductivity() %>" ReportName="BooksRpt">
                        </dx:ReportViewer>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>