<%@ Page Title="Upload Final SSB(DED) File" Language="VB" MasterPageFile="~/Site2.master" AutoEventWireup="false" CodeFile="frmUploadFinalSSBFile.aspx.vb" Inherits="Credt_uploadSSBFile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <style type="text/css">
        .panel-heading {
            text-align: left;
            font-weight: bold;
        }

        .control-label {
            text-align: left;
            font-weight: bold;
        }

        .panel-body {
            background-color: #eeeeee;
        }

        .row {
            margin-bottom: 4px;
        }
    </style>
    <script type="text/javascript">
        function isDelete() {
            return confirm("Are you sure you want to delete this record?");
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="">
        <div class="panel panel-primary">
            <div class="panel-heading">
                Upload Final SSB Deduction File
            </div>
            <div class="panel-body">

                <div class="row">

                    <div class="col-xs-2 control-label">
                        <asp:Label ID="Label116" runat="server" Text="Select File To Upload" Font-Bold="True"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:FileUpload ID="FileUpload1" runat="server" Width="403px" />
                    </div>
                </div>

                <div class="row">
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="Label117" runat="server" Text="Payment Date" Font-Bold="True"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox ReadOnly="True" ForeColor="Black" Font-Bold="true" ID="bdpPaymentDate" runat="server" CssClass="col-xs-12 form-control input-sm datepicker"></asp:TextBox>
                        <span class="glyphicon glyphicon-calendar form-control-feedback" style="margin-right: 13px; background-color: #eeeeff; border-radius: 0 3px 3px 0; border: 1px solid rgb(149,188,219); z-index: 0;"></span>
                    </div>
                    <div class="col-xs-2 control-label">
                        Capital Account
                    </div>
                    <div class="col-xs-4">
                        <asp:DropDownList ID="cmbCapitalAccount" runat="server" CssClass="form-control input-sm chosen"></asp:DropDownList>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-2 control-label">
                        Interest Account
                    </div>
                    <div class="col-xs-4">
                        <asp:DropDownList ID="cmbInterestAccount" runat="server" CssClass="form-control input-sm chosen"></asp:DropDownList>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-12 text-center">
                        <asp:Button ID="btnAddAgent" runat="server" Text="Process Final  SSB File" CssClass="btn btn-primary" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>