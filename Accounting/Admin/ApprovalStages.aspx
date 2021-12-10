<%@ Page Title="Loan Application Approval Stages" Language="VB" MasterPageFile="~/Site2.master" AutoEventWireup="false" CodeFile="ApprovalStages.aspx.vb" Inherits="Admin_ApprovalStages" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="panel panel-primary small">
        <div class="panel-heading">
            <h4 class="panel-title">
                <a>Loan Application Approval Stages</a>
            </h4>
        </div>
        <div class="panel-body">
            <div class="row">
                <div class="col-xs-2 control-label">
                    Applicant Type
                </div>
                <div class="col-xs-4">
                    <asp:DropDownList CssClass="col-xs-12 form-control input-sm" ID="cmbApplicantType" runat="server"></asp:DropDownList>
                </div>
                <div class="col-xs-2 control-label">
                    Number of Approval Stages
                </div>
                <div class="col-xs-4">
                    <asp:TextBox CssClass="col-xs-12 form-control input-sm numeric" ID="txtNoAppStages" runat="server"></asp:TextBox>
                </div>
            </div>
        </div>
    </div>
</asp:Content>