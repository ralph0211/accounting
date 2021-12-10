<%@ Page Title="Account Statement" Language="VB" MasterPageFile="~/Site2.master" AutoEventWireup="false" CodeFile="AccountStatement.aspx.vb" Inherits="Accounting_CashBankAccount" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../Content/chosen.min.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="panel panel-primary small">
        <div class="panel-heading">
            <h4 class="panel-title">
                <a>Account Statement</a>
            </h4>
        </div>
        <div class="panel-body">
            <div class="row">
                <div class="col-xs-12 text-center">
                    <asp:RadioButtonList ID="rdType" runat="server" CssClass="col-xs-6 control-label" AutoPostBack="True" RepeatDirection="Horizontal">
                        <asp:ListItem Value="Cashbook">Cashbook</asp:ListItem>
                        <asp:ListItem Value="Creditors">Creditors</asp:ListItem>
                        <asp:ListItem Value="Debtors">Debtors</asp:ListItem>
                        <asp:ListItem Value="Loans">Loans and Advances</asp:ListItem>
                        <asp:ListItem Value="Other">Other</asp:ListItem>
                    </asp:RadioButtonList>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-2 control-label">
                    <asp:Label ID="lblAccount" runat="server" Text="Account" Visible="False"></asp:Label>
                </div>
                <div class="col-xs-5">
                    <asp:DropDownList CssClass="col-xs-12 form-control input-sm chosen-select" ID="cmbAccount" runat="server" Visible="False">
                        <asp:ListItem></asp:ListItem>
                        <asp:ListItem>Receipting</asp:ListItem>
                        <asp:ListItem>CashBook</asp:ListItem>
                        <asp:ListItem>Journal</asp:ListItem>
                        <asp:ListItem></asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-2 control-label">
                    <asp:Label ID="Label1220" runat="server" Text="Date From"></asp:Label>
                </div>
                <div class="col-xs-4">
                    <asp:TextBox ID="dtpTrxnDate" runat="server" CssClass="form-control input-sm datepicker"></asp:TextBox>
                    <span class="glyphicon glyphicon-calendar form-control-feedback" style="margin-right: 13px; background-color: #eeeeff; border-radius: 0 3px 3px 0; border: 1px solid rgb(149,188,219); z-index: 0;"></span>
                </div>
                <div class="col-xs-2 control-label">
                    <asp:Label ID="Label1221" runat="server" Text="Date To"></asp:Label>
                </div>
                <div class="col-xs-4">
                    <asp:TextBox ID="dtpTrxnDate0" runat="server" CssClass="form-control input-sm datepicker"></asp:TextBox>
                    <span class="glyphicon glyphicon-calendar form-control-feedback" style="margin-right: 13px; background-color: #eeeeff; border-radius: 0 3px 3px 0; border: 1px solid rgb(149,188,219); z-index: 0;"></span>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12 text-center">
                    <asp:Button CssClass="btn btn-primary btn-sm" ID="btnSaveTrxn3" runat="server" Text="Print Report" />
                </div>
            </div>
        </div>
    </div>
    <script src="../Scripts/chosen.jquery.min.js"></script>
    <script type="text/javascript">
        var config = {
            '.chosen-select': {},
            '.chosen-select-deselect': { allow_single_deselect: true },
            '.chosen-select-no-single': { disable_search_threshold: 10 },
            '.chosen-select-no-results': { no_results_text: 'Oops, nothing found!' },
            '.chosen-select-width': { width: "95%" }
        }
        for (var selector in config) {
            $(selector).chosen(config[selector]);
        };
        $(".dd_select2").chosen();
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