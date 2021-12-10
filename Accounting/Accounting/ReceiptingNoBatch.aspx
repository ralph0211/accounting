<%@ Page Title="" Language="VB" MasterPageFile="~/Site2.master" AutoEventWireup="false" CodeFile="ReceiptingNoBatch.aspx.vb" Inherits="Accounting_ReceiptingNoBatch" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../Content/chosen.min.css" rel="stylesheet" />
    <style type="text/css">
        @media print {
            .no-print, .noPrint, .no-print * {
                display: none !important;
            }
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="panel panel-primary small">
        <div class="panel-heading">
            <h4 class="panel-title">
                <a>Receipting</a>
            </h4>
        </div>
        <div class="panel-body">
            <div class="row">
                <div class="col-xs-12 label-info control-label">
                    <asp:Label ID="Label1" runat="server" Text="RECEIPT  DETAILS" Font-Bold="True"></asp:Label>
                </div>
            </div>
            <div class="row" style="visibility: hidden;">
                div class="col-xs-12 center-block"
                <asp:Label ID="Label1225" runat="server" Text="Batch Number"></asp:Label>
                <asp:DropDownList CssClass="form-control input-sm col-xs-12" ID="cmbBatchNo" runat="server" AutoPostBack="True">
                </asp:DropDownList>
            </div>
            <div class="row">
                <div class="col-xs-12 center-block">
                    <asp:GridView ID="grdDetails0" runat="server" CellPadding="4" HorizontalAlign="center">
                        <AlternatingRowStyle CssClass="altrowstyle" />
                        <HeaderStyle CssClass="headerstyle" HorizontalAlign="center" />
                        <RowStyle CssClass="rowstyle" />
                        <PagerStyle CssClass="pagination-ys" />
                        <SelectedRowStyle Font-Bold="true" BackColor="#A8B1B9" />
                    </asp:GridView>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12 text-center alert-danger">
                    <asp:Label ID="Label3" runat="server" Text="The cut off date for Cash Account is "></asp:Label>&nbsp;<asp:Label ID="lblCashCutOffDate" runat="server" Text=""></asp:Label>&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label4" runat="server" Text="The cut off date  for other accounts is "></asp:Label>&nbsp;<asp:Label ID="lblCutOffDate" runat="server" Text=""></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-2 control-label">
                    <asp:Label ID="Label1220" runat="server" Text="Date"></asp:Label>
                </div>
                <div class="col-xs-4">
                    <asp:TextBox ID="dtpTrxnDate" runat="server" CssClass="form-control input-sm datepicker"></asp:TextBox>
                    <span class="glyphicon glyphicon-calendar form-control-feedback" style="margin-right: 13px; background-color: #eeeeff; border-radius: 0 3px 3px 0; border: 1px solid rgb(149,188,219); z-index: 0;"></span>
                </div>
                <div class="col-xs-2 control-label">
                    <asp:Label ID="Label1223" runat="server" Text="Status"></asp:Label>
                </div>
                <div class="col-xs-4">
                    <asp:RadioButtonList ID="rdbType0" runat="server" CssClass="col-xs-12 control-label" RepeatDirection="Horizontal">
                        <asp:ListItem>Posted</asp:ListItem>
                        <asp:ListItem>Not Posted</asp:ListItem>
                    </asp:RadioButtonList>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-2 control-label">
                    <asp:Label ID="Label23" runat="server" Text="Account "></asp:Label>
                </div>
                <div class="col-xs-4">
                    <asp:DropDownList CssClass="form-control input-sm col-xs-12 dd_select2" ID="cmbAccount" runat="server" AutoPostBack="True">
                    </asp:DropDownList>
                </div>
                <div class="col-xs-2 control-label">
                    <asp:Label ID="Label5" runat="server" Text="Pay Type"></asp:Label>
                </div>
                <div class="col-xs-4">
                    <asp:RadioButtonList ID="rdbPayType" runat="server" CssClass="col-xs-12 control-label" RepeatDirection="Horizontal" AutoPostBack="True">
                        <asp:ListItem>Cash</asp:ListItem>
                        <asp:ListItem>Bank</asp:ListItem>
                    </asp:RadioButtonList>
                    <asp:DropDownList CssClass="form-control input-sm col-xs-12 dd_select2" ID="cmbAccount1" runat="server" AutoPostBack="True" Visible="False">
                    </asp:DropDownList>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-2 control-label">
                    <asp:Label ID="Label1219" runat="server" Text="Transaction Amount"></asp:Label>
                </div>
                <div class="col-xs-4">
                    <asp:TextBox CssClass="form-control input-sm col-xs-12" ID="txtAmount" runat="server" onkeypress="return isnumeric(event)"></asp:TextBox>
                </div>
                <div class="col-xs-2 control-label">
                    <asp:Label ID="Label1217" runat="server" Text="Refrence"></asp:Label>
                </div>
                <div class="col-xs-4">
                    <asp:TextBox CssClass="form-control input-sm col-xs-12" ID="txtRef" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-2 control-label">
                    <asp:Label ID="lblLoanDebtor" runat="server" Text="Loan Debtor" Visible="False"></asp:Label>
                </div>
                <div class="col-xs-4">
                    <asp:DropDownList CssClass="form-control input-sm col-xs-12 dd_select2" ID="cmbAccount0" runat="server" AutoPostBack="True" Visible="False">
                    </asp:DropDownList>
                </div>
                <div class="col-xs-2 control-label">
                    <asp:Label ID="Label1221" runat="server" Text="Received From"></asp:Label>
                </div>
                <div class="col-xs-4">
                    <asp:TextBox CssClass="form-control input-sm col-xs-12" ID="txtdesc" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-2 control-label">
                    Printer
                </div>
                <div class="col-xs-4">
                    <asp:DropDownList CssClass="form-control input-sm col-xs-12" ID="cmbPrinters" runat="server" Visible="false"></asp:DropDownList>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12 text-center">
                    <asp:Label ID="lblDefault" runat="server" Visible="False"></asp:Label>
                    <asp:Button CssClass="btn btn-primary btn-sm" ID="btnSaveTrxn3" runat="server" Text="Add" />
                    <asp:Button CssClass="btn btn-primary btn-sm" ID="btnSaveTrxn" runat="server" Visible="false" Text="Commit" />
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12 text-center">
                    <asp:Label ID="lblReceipt" runat="server"></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12 center-block">
                    <asp:GridView ID="grdDetails" runat="server" HorizontalAlign="center">
                        <Columns>
                            <asp:TemplateField HeaderText="Select">
                                <ItemTemplate>
                                    <asp:CheckBox ID="checkbox2" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <AlternatingRowStyle CssClass="altrowstyle" />
                        <HeaderStyle CssClass="headerstyle" HorizontalAlign="center" />
                        <RowStyle CssClass="rowstyle" />
                        <PagerStyle CssClass="pagination-ys" />
                        <SelectedRowStyle Font-Bold="true" BackColor="#A8B1B9" />
                    </asp:GridView>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12 control-label">
                    <asp:Label ID="Label2" runat="server" Text="Receipts Total: "></asp:Label>
                    <asp:Label ID="lblRecTotal" runat="server" Text=""></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12 text-center">
                    <asp:Button CssClass="btn btn-primary btn-sm" ID="Button1" runat="server" Text="Remove Selected Item(s)" />
                </div>
            </div>
        </div>
    </div>
    <iframe id="printFrame" style="width: 1px; height: 1px;" visible="false"></iframe>
    <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server"
        AutoDataBind="true" EnableDatabaseLogonPrompt="False"
        EnableParameterPrompt="False" ReuseParameterValuesOnRefresh="True" />
    <br />
    <div id="print-page-container" class="noPrint"></div>
    <script src="../Scripts/chosen.jquery.min.js"></script>
    <script type="text/javascript">
        $(".dd_select2").chosen();

        //document.getElementById('header').style.display = 'none';
        //                  document.getElementById('footer').style.display = 'none';
        function loadPrintPage(url) {
            // create a hidden frame.
            var printFrame = $("<iframe>").hide();
            // set the "src" of the iframe to the URL containing what you want to print
            printFrame.attr("src", url);
            // add the hidden iframe somewhere in your page
            $("#print-page-container").append(printFrame);
            //    document.getElementById("print-page-container").contentWindow.print();
        }
        $('.datepicker').datepicker({
            format: 'dd MM yyyy',
            todayHighlight: true
        });

        $(function () {
            $("[id*=btnSaveCreditParameters]").bind("click", function () {
                $("[id*=btnSaveCreditParameters]").val("Creating Amortization...");
                $("[id*=btnSaveCreditParameters]").attr("disabled", true);
            });
        });

        $('.nofuturedate').datepicker({
            format: 'dd MM yyyy',
            todayHighlight: true,
            endDate: '+0d'
        });
    </script>
</asp:Content>