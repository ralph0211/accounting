<%@ Page Language="VB" AutoEventWireup="false" CodeFile="popAmortization.aspx.vb" Inherits="Credit_popAmortization" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript" src="js/jquery-1.11.1.min.js"></script>
    <script type="text/javascript" src="js/jquery-ui-1.10.4.min.js"></script>
    <link href="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.10.4/themes/start/jquery-ui.css"
        rel="stylesheet" type="text/css" />
    <style type="text/css">
        div.ui-datepicker {
            font-size: 8px;
        }
    </style>
    <script type="text/javascript">
        $(function () {
            $("#<%= txt1stPayDate.ClientID%>").datepicker({
                defaultDate: "+1w",
                dateFormat: 'd MM yy',
                changeMonth: true,
                changeYear: true,
                yearRange: '-05:+02'
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="modal fade hide">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                    <h3 id="myModalLabel">Loan Amortization</h3>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-xs-4 control-label">
                            <asp:Label ID="lblRepPer" runat="server" Text="Tenor(Months)"
                                Font-Names="Calibri" ForeColor="#555555"></asp:Label>
                        </div>
                        <div class="col-xs-8">
                            <asp:TextBox ID="txtRepayPeriod" runat="server" Width="70px"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-4 control-label">
                            <asp:Label ID="Label7436" runat="server" Text="Interest Rate(%)"
                                Font-Names="Calibri" ForeColor="#555555"></asp:Label>
                        </div>
                        <div class="col-xs-8">
                            <asp:TextBox ID="txtIntRate" runat="server" Width="70px"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-4 control-label">
                            <asp:Label ID="Label746" runat="server" Text="Interest Adjustment($)"
                                Font-Names="Calibri" ForeColor="#555555"></asp:Label>
                        </div>
                        <div class="col-xs-8">
                            <asp:TextBox ID="txtAdminCharge" runat="server" Width="70px"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-4 control-label">
                            <asp:Label ID="Label7438" runat="server" Text="First Payment Date"
                                Font-Names="Calibri" ForeColor="#555555"></asp:Label>
                        </div>
                        <div class="col-xs-8">
                            <asp:TextBox ID="txt1stPayDate" runat="server" Width="170px"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-12 text-center">
                            <asp:Button ID="btnSaveCreditParameters" runat="server" Font-Names="Calibri"
                                ForeColor="#555555" Text="Create Amortization" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>