<%@ Page Title="Detailed Ledger" Language="VB" MasterPageFile="~/Site2.master" AutoEventWireup="false" CodeFile="SubLedgers.aspx.vb" Inherits="Accounting_SubLedgers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../Content/chosen.min.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="panel panel-primary small">
        <div class="panel-heading">
            <h4 class="panel-title">
                <a>Detailed Ledger</a>
            </h4>
        </div>
        <div class="panel-body">
            <div class="row">
                <div class="col-xs-2 control-label">
                    <asp:Label ID="Label8" runat="server" Text="Select Account"></asp:Label>
                </div>
                <div class="col-xs-4">
                    <asp:DropDownList CssClass="col-xs-12 form-control input-sm dd_select2" ID="cmbAccount" runat="server" AutoPostBack="True">
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
                <div class="col-xs-12 center-block">
                    <asp:Label ID="lblSubName" runat="server" Font-Bold="True"></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12 text-center">
                    <asp:Button CssClass="btn btn-primary btn-sm" ID="Button2" runat="server" Text="View" />
                    <asp:Button CssClass="btn btn-primary btn-sm" ID="Button1" runat="server" Text="Print View" />
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12 center-block">
                    <asp:GridView ID="grd" runat="server" EnableModelValidation="True" HorizontalAlign="center">
                        <AlternatingRowStyle CssClass="altrowstyle" />
                        <HeaderStyle CssClass="headerstyle" HorizontalAlign="center" />
                        <RowStyle CssClass="rowstyle" />
                        <PagerStyle CssClass="pagination-ys" />
                        <SelectedRowStyle BackColor="#A8B1B9" Font-Bold="true" />
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
    <script src="../Scripts/jquery-1.8.0.min.js"></script>
    <script src="../Scripts/chosen.jquery.min.js"></script>
    <script type="text/javascript">
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