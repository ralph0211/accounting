<%@ Page Title="Capital Account Funding" Language="VB" MasterPageFile="~/Site2.master" AutoEventWireup="false" CodeFile="capitalAccountFunding.aspx.vb" Inherits="Banking_Acc_Funding" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="panel panel-primary small">
        <div class="panel-heading">
            <h4 class="panel-title">Capital Account Funding
            </h4>
        </div>
        <div class="panel-body">
            <div class="row">
                <div class="col-xs-2 control-label">
                    Capital Account
                </div>
                <div class="col-xs-4">
                    <asp:DropDownList ID="cmbBankAccount" runat="server" CssClass="col-xs-12 form-control input-sm chosen" AutoPostBack="true"></asp:DropDownList>
                </div>
                <div class="col-xs-2 control-label">
                    Account Balance:&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblBankBalance" runat="server"></asp:Label>
                </div>
            </div>
            
            <div class="row">
                <div class="col-xs-2 control-label">
                    Transaction Date
                </div>
                <div class="col-xs-4">
                    <asp:TextBox ID="txtTrxnDate" runat="server" CssClass="col-xs-12 form-control input-sm nofuturedate"></asp:TextBox>
                    <span class="glyphicon glyphicon-calendar form-control-feedback" style="margin-right: 13px; background-color: #eeeeff; border-radius: 0 3px 3px 0; border: 1px solid rgb(149,188,219); z-index: 0;"></span>
                </div>
                <div class="col-xs-2 control-label">
                    Amount
                </div>
                <div class="col-xs-4">
                    <asp:TextBox ID="txtAmount" runat="server" CssClass="col-xs-12 form-control input-sm numeric"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-2 control-label">
                    Comment/Description
                </div>
                <div class="col-xs-4">
                    <asp:TextBox ID="txtComment" runat="server" CssClass="col-xs-12 form-control input-sm" TextMode="MultiLine"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12 text-center">
                    <asp:Button ID="btnSave" runat="server" CssClass="btn btn-sm btn-primary save-btn" Text="Save" UseSubmitBehavior="false" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>