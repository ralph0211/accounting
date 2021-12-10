<%@ Page Title="" Language="VB" MasterPageFile="~/Site2.master" AutoEventWireup="false" CodeFile="SSBUpload.aspx.vb" Inherits="Credit_SSBUpload" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        $(function () {
            $("#<%= txtRepayDate.ClientID %>").datepicker({ dateFormat: 'd MM yy' }).val();
            $("#<%= txtRepayDate.ClientID %>").datepicker("setDate", new Date());
        });
    </script>
    <style type="text/css">
        div.ui-datepicker {
            font-size: 8px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="panel panel-primary small">
        <div class="panel-heading">
            <h4 class="panel-title">
                <a>SSB File Upload</a>
            </h4>
        </div>
        <div class="panel-body">
            <div class="row">
                <div class="col-xs-1 control-label">
                    <asp:Label ID="lblDate" runat="server" Text="Date"></asp:Label>
                </div>
                <div class="col-xs-4">
                    <asp:TextBox ID="txtRepayDate" runat="server" CssClass="form-control input-sm nofuturedate"></asp:TextBox>
                    <span class="glyphicon glyphicon-calendar form-control-feedback" style="margin-right: 13px; background-color: #eeeeff; border-radius: 0 3px 3px 0; border: 1px solid rgb(149,188,219); z-index: 0;"></span>
                </div>
                <div class="col-xs-1 control-label">
                    <asp:Label ID="Label1" runat="server" Text="File"></asp:Label>
                </div>
                <div class="col-xs-4">
                    <asp:FileUpload ID="filSSBUpload" runat="server" />
                </div>
                <div class="col-xs-2">
                    <asp:Button CssClass="btn btn-primary btn-sm" ID="btnUpload" runat="server" Text="Upload" />
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
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