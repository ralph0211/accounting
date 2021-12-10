<%@ Page Title="Loan Grading Parameters" Language="VB" MasterPageFile="~/Site2.master" AutoEventWireup="false" CodeFile="ParaLoanGrading.aspx.vb" Inherits="Credit_ParaLoanGrading" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="panel panel-primary small">
        <div class="panel-heading">
            <h4 class="panel-title">
                <a>Loan Grades
                </a>
            </h4>
        </div>
        <div class="panel-body">
            <div class="row">
                <div class="col-xs-2 control-label">
                    Loan Grade
                </div>
                <div class="col-xs-4">
                    <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtLoanGrade" runat="server"></asp:TextBox>
                </div>
                <div class="col-xs-2 control-label">
                    Days in arrears start
                </div>
                <div class="col-xs-4">
                    <asp:TextBox CssClass="col-xs-12 form-control input-sm numeric" ID="txtDIAStart" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-2 control-label">
                    Days in arrears end
                </div>
                <div class="col-xs-4">
                    <asp:TextBox CssClass="col-xs-12 form-control input-sm numeric" ID="txtDIAEnd" runat="server"></asp:TextBox>
                </div>
                <div class="col-xs-2 control-label">
                    Provision (%)
                </div>
                <div class="col-xs-4">
                    <asp:TextBox CssClass="col-xs-12 form-control input-sm numeric" ID="txtProvision" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12 text-center">
                    <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-primary btn-sm save-btn" UseSubmitBehavior="false" />
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12 center-block">
                    <asp:GridView ID="grdLoanGrade" runat="server" HorizontalAlign="Center">
                        <AlternatingRowStyle CssClass="altrowstyle" />
                        <HeaderStyle CssClass="headerstyle" HorizontalAlign="center" />
                        <RowStyle CssClass="rowstyle" />
                        <Columns>
                            <asp:CommandField ShowSelectButton="True" />
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
</asp:Content>