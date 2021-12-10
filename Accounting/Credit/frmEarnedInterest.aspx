<%@ Page Title="Earned Interest" Language="VB" MasterPageFile="~/Site2.master" AutoEventWireup="false" CodeFile="frmEarnedInterest.aspx.vb" Inherits="Credit_frmEarnedInterest" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="panel panel-primary small">
        <div class="panel-heading">
            <h4 class="panel-title">
                <a>Earned Interest Report</a>
            </h4>
        </div>
        <div class="panel-body">
            <div class="row">
                <div class="col-xs-2 control-label">
                    Report Type
                </div>
                <div class="col-xs-4">
                    <asp:RadioButtonList ID="rdbReportType" runat="server" RepeatDirection="horizontal" CssClass="col-xs-12">
                        <asp:ListItem Text="Daily Audit Trail" Value="Daily"></asp:ListItem>
                        <asp:ListItem Text="Loan Summary" Value="Summary"></asp:ListItem>
                    </asp:RadioButtonList>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-2 control-label">
                    <asp:Label ID="Label8" runat="server"
                        Text="From Date"></asp:Label>
                </div>
                <div class="col-xs-4">
                    <asp:TextBox ID="bdpFromDate" runat="server" CssClass="form-control input-sm datepicker"></asp:TextBox>
                    <span class="glyphicon glyphicon-calendar form-control-feedback" style="margin-right: 13px; background-color: #eeeeff; border-radius: 0 3px 3px 0; border: 1px solid rgb(149,188,219); z-index: 0;"></span>
                </div>
                <div class="col-xs-2 control-label">
                    <asp:Label ID="Label9" runat="server" Text="To Date"></asp:Label>
                </div>
                <div class="col-xs-4">
                    <asp:TextBox ID="bdpToDate" runat="server" CssClass="form-control input-sm datepicker"></asp:TextBox>
                    <span class="glyphicon glyphicon-calendar form-control-feedback" style="margin-right: 13px; background-color: #eeeeff; border-radius: 0 3px 3px 0; border: 1px solid rgb(149,188,219); z-index: 0;"></span>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12 text-center">
                    <asp:Button CssClass="btn btn-primary btn-sm" ID="btnPrint" runat="server" Text="Print" />
                </div>
            </div>
        </div>
    </div>
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