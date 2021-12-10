<%@ Page Title="Database Backup" Language="VB" MasterPageFile="~/Site2.master" AutoEventWireup="false" CodeFile="DatabaseBackup.aspx.vb" Inherits="Accounting_DatabaseBackup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="panel panel-primary small">
        <div class="panel-heading">
            <h4 class="panel-title">
                <a>Database Backup</a>
            </h4>
        </div>
        <div class="panel-body">
            <div class="row">
                <div class="col-xs-2 control-label">
                    Backup File Name
                </div>
                <div class="col-xs-2">
                    <asp:TextBox ID="txtFileName" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                </div>
                <div class="col-xs-1">
                    <asp:Button ID="btnBackup" runat="server" Text="Backup Database" CssClass="btn btn-sm btn-primary" />
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12 label-info control-label">
                    Restore Database
                </div>
            </div>
            <div class="row">
                <div class="col-xs-2 control-label">
                    Restore File
                </div>
                <div class="col-xs-2">
                    <asp:FileUpload ID="filRestore" runat="server" />
                </div>
                <div class="col-xs-1">
                    <asp:Button ID="btnRestore" runat="server" Text="Restore Database" CssClass="btn btn-sm btn-primary" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>