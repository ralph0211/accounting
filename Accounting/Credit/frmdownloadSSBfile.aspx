<%@ Page Title="Download SSB File" Language="VB" MasterPageFile="~/Site2.master" AutoEventWireup="false" CodeFile="frmdownloadSSBfile.aspx.vb" Inherits="Credit_DownloadSSBFile" %>

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

        .auto-style1 {
            height: 35px;
        }

        .auto-style2 {
            height: 44px;
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
                Download Credit Management SSB File
            </div>
            <div class="panel-body">
                <div class="row">
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="Label118" runat="server" Text="Select File Type" Font-Bold="True"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control input-sm">
                            <asp:ListItem>-SELECT-</asp:ListItem>
                            <asp:ListItem>New/Changes</asp:ListItem>
                            <asp:ListItem>Deletions</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>

                <div class="row">
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="Label117" runat="server" Text="Select Date" Font-Bold="True"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox ID="dtpStartDate" runat="server" CssClass="form-control input-sm datepicker"></asp:TextBox>
                        <span class="glyphicon glyphicon-calendar form-control-feedback" style="margin-right: 13px; background-color: #eeeeff; border-radius: 0 3px 3px 0; border: 1px solid rgb(149,188,219); z-index: 0;"></span>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-2 control-label">
                        Start Date
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox ID="txtStartDate" runat="server" CssClass="form-control input-sm datepicker"></asp:TextBox>
                        <span class="glyphicon glyphicon-calendar form-control-feedback" style="margin-right: 13px; background-color: #eeeeff; border-radius: 0 3px 3px 0; border: 1px solid rgb(149,188,219); z-index: 0;"></span>
                    </div>
                    <div class="col-xs-2 control-label">
                        End Date
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox ID="txtEndDate" runat="server" CssClass="form-control input-sm datepicker"></asp:TextBox>
                        <span class="glyphicon glyphicon-calendar form-control-feedback" style="margin-right: 13px; background-color: #eeeeff; border-radius: 0 3px 3px 0; border: 1px solid rgb(149,188,219); z-index: 0;"></span>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-12 text-center">
                        <asp:Button ID="btnAddAgent" runat="server" Text="Download SSB File" CssClass="btn btn-primary" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>