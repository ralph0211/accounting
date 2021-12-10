<%@ Page Title="SSB File Upload Report" Language="VB" MasterPageFile="~/Site2.master" AutoEventWireup="false" CodeFile="frmSSBUploadRpt.aspx.vb" Inherits="Credit_frmSSBUploadRpt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        $(function () {
            $("#<%= txtFileDate.ClientID %>").datepicker({ dateFormat: 'd MM yy' }).val();
            $("#<%= txtFileDate.ClientID %>").datepicker("setDate", new Date());
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
                <a>SSB File Upload Report</a>
            </h4>
        </div>
        <div class="panel-body">
            <div class="row">
                <div class="col-xs-3 control-label">
                    <asp:Label ID="lblDate" runat="server" Text="File Upload Date"></asp:Label>
                </div>
                <div class="col-xs-3">
                    <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtFileDate" runat="server"></asp:TextBox>
                </div>
                <div class="col-xs-1">
                    <asp:Button CssClass="btn btn-primary btn-sm" ID="btnPrint" runat="server" Text="Print" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>