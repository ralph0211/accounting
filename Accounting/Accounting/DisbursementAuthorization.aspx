<%@ Page Title="Authorise Disbursement Transaction" Language="VB" MasterPageFile="~/Site2.master" AutoEventWireup="false" CodeFile="DisbursementAuthorization.aspx.vb" Inherits="Accounting_DisbursementAuthorization" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="panel panel-primary small">
        <div class="panel-heading">
            <h4 class="panel-title">
                <a>Disbursement Authorisation</a>
            </h4>
        </div>
        <div class="panel-body">
            <div class="row">
                <div class="col-xs-2 control-label">
                    Authorise By
                </div>
                <div class="col-xs-4">
                    <asp:RadioButtonList ID="rdbAuthBy" runat="server" CssClass="col-xs-12" RepeatDirection="horizontal" AutoPostBack="true">
                        <asp:ListItem Text="Batch Number" Value="Batch"></asp:ListItem>
                        <asp:ListItem Text="Disbursement Date" Value="Date"></asp:ListItem>
                    </asp:RadioButtonList>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-2 control-label">
                    <asp:Label ID="lblBatchNo" runat="server" Text="Batch Number" Visible="false"></asp:Label>
                </div>
                <div class="col-xs-4">
                    <asp:DropDownList ID="cmbBatchNo" runat="server" AutoPostBack="True" CssClass="col-xs-12 form-control input-sm chosen" Visible="false">
                    </asp:DropDownList>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-2 control-label">
                    <asp:Label ID="lblDisbDate" runat="server" Text="Disbursement Date" Visible="false"></asp:Label>
                </div>
                <div class="col-xs-4">
                    <asp:TextBox ID="txtDisbDate" runat="server" CssClass="form-control input-sm nofuturedate" Visible="false"></asp:TextBox>
                    <span class="glyphicon glyphicon-calendar form-control-feedback" style="margin-right: 13px; background-color: #eeeeff; border-radius: 0 3px 3px 0; border: 1px solid rgb(149,188,219);" runat="server" id="spanDisbDate" visible="false"></span>
                </div>
                <div class="col-xs-1">
                    <asp:Button CssClass="btn btn-primary btn-sm" ID="btnSearchDate" runat="server" Text=">>" Visible="false" />
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12 center-block">
                    <asp:GridView ID="grdDetails" runat="server" HorizontalAlign="center" ShowFooter="true" CellSpacing="2">
                        <AlternatingRowStyle CssClass="altrowstyle" />
                        <HeaderStyle CssClass="headerstyle" HorizontalAlign="center" />
                        <RowStyle CssClass="rowstyle" />
                        <PagerStyle CssClass="pagination-ys" />
                        <SelectedRowStyle BackColor="#A8B1B9" Font-Bold="true" />
                        <FooterStyle Font-Bold="true" />
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkRow" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12 text-center">
                    <asp:Button ID="btnAuthorize" runat="server" CssClass="btn btn-primary btn-sm" Text="Authorise" />
                    <asp:Button ID="btnReverse" runat="server" CssClass="btn btn-primary btn-sm" Text="Reverse" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>