<%@ Page Title="Receipting" Language="VB" MasterPageFile="~/Site2.master" AutoEventWireup="false" CodeFile="Receipting.aspx.vb" Inherits="Accounting_Receipting" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="panel panel-primary small">
        <div class="panel-heading">
            <h4 class="panel-title">
                <a>Receipting</a>
            </h4>
        </div>
        <div class="panel-body">
            <div class="row">
                <div class="col-xs-2 control-label">
                    <asp:Label ID="Label1225" runat="server" Text="Batch Number"></asp:Label>
                </div>
                <div class="col-xs-3">
                    <asp:DropDownList CssClass="col-xs-12 form-control input-sm" ID="cmbBatchNo" runat="server" AutoPostBack="True">
                    </asp:DropDownList>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12 center-block">
                    <asp:GridView ID="grdDetails0" runat="server" HorizontalAlign="Center">
                        <AlternatingRowStyle CssClass="altrowstyle" />
                        <HeaderStyle CssClass="headerstyle" HorizontalAlign="center" />
                        <RowStyle CssClass="rowstyle" />
                        <PagerStyle CssClass="pagination-ys" />
                        <SelectedRowStyle Font-Bold="true" BackColor="#A8B1B9" />
                    </asp:GridView>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12 text-center label-danger">
                    <asp:Label ID="Label2" runat="server" Text="The cut off date for Cash Account is "></asp:Label>&nbsp;<asp:Label ID="lblCashCutOffDate" runat="server" Text=""></asp:Label>&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label3" runat="server" Text="The cut off date  for other accounts is "></asp:Label>&nbsp;<asp:Label ID="lblCutOffDate" runat="server" Text=""></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-2 control-label">
                    <asp:Label ID="Label1220" runat="server" Text="Date"></asp:Label>
                </div>
                <div class="col-xs-3">
                    <asp:TextBox ID="dtpTrxnDate" runat="server" CssClass="form-control input-sm nofuturedate"></asp:TextBox>
                    <span class="glyphicon glyphicon-calendar form-control-feedback" style="margin-right: 13px; background-color: #eeeeff; border-radius: 0 3px 3px 0; border: 1px solid rgb(149,188,219); z-index: 0;"></span>
                </div>
                <div class="col-xs-2 control-label">
                    <asp:Label ID="Label1223" runat="server" Text="Status"></asp:Label>
                </div>
                <div class="col-xs-3">
                    <asp:RadioButtonList ID="rdbType0" runat="server" RepeatDirection="Horizontal" CssClass="col-xs-12">
                        <asp:ListItem>Posted</asp:ListItem>
                        <asp:ListItem>Not Posted</asp:ListItem>
                    </asp:RadioButtonList>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-2 control-label">
                    <asp:Label ID="Label23" runat="server" Text="Account "></asp:Label>
                </div>
                <div class="col-xs-3">
                    <asp:DropDownList CssClass="col-xs-12 form-control input-sm chosen" ID="cmbAccount" runat="server" AutoPostBack="True">
                    </asp:DropDownList>
                </div>
                <div class="col-xs-2 control-label">
                    <asp:Label ID="Label5" runat="server" Text="Pay Type"></asp:Label>
                </div>
                <div class="col-xs-3">
                    <asp:RadioButtonList ID="rdbPayType" runat="server" RepeatDirection="Horizontal" AutoPostBack="True" CssClass="col-xs-12">
                        <asp:ListItem Text="Cash" Value="Cash"></asp:ListItem>
                        <asp:ListItem Text="Bank" Value="Bank"></asp:ListItem>
                    </asp:RadioButtonList>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-7"></div>
                <div class="col-xs-3">
                    <asp:DropDownList CssClass="col-xs-12 form-control input-sm chosen" ID="cmbAccount1" runat="server" AutoPostBack="True">
                    </asp:DropDownList>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-2 control-label">
                    <asp:Label ID="Label1219" runat="server" Text="Transaction Amount"></asp:Label>
                </div>
                <div class="col-xs-3">
                    <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtAmount" runat="server"></asp:TextBox>
                </div>
                <div class="col-xs-2 control-label">
                    <asp:Label ID="Label1217" runat="server" Text="Refrence"></asp:Label>
                </div>
                <div class="col-xs-3">
                    <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtRef" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-2 control-label">
                    <asp:Label ID="lblLoanDebtor" runat="server" Text="Loan Debtor" Visible="False"></asp:Label>
                </div>
                <div class="col-xs-3">
                    <asp:DropDownList CssClass="col-xs-12 form-control input-sm chosen" ID="cmbAccount0" runat="server" AutoPostBack="True" Visible="False">
                    </asp:DropDownList>
                </div>
                <div class="col-xs-2 control-label">
                    <asp:Label ID="Label1221" runat="server" Text="Description"></asp:Label>
                </div>
                <div class="col-xs-3">
                    <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtdesc" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12 text-center">
                    <asp:Label ID="lblDefault" runat="server" Visible="False"></asp:Label>
                    <asp:Button CssClass="btn btn-primary btn-sm" ID="btnSaveTrxn3" runat="server" Text="Add" />
                    <asp:Button CssClass="btn btn-primary btn-sm" ID="btnSaveTrxn" runat="server" Text="Commit" />
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12 center-block">
                    <asp:GridView ID="grdDetails" runat="server" HorizontalAlign="Center">
                        <Columns>
                            <asp:TemplateField HeaderText="SELECT">
                                <ItemTemplate>
                                    <asp:CheckBox ID="checkbox2" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <AlternatingRowStyle CssClass="altrowstyle" />
                        <HeaderStyle CssClass="headerstyle" HorizontalAlign="center" />
                        <RowStyle CssClass="rowstyle" />
                        <PagerStyle CssClass="pagination-ys" />
                        <SelectedRowStyle Font-Bold="true" BackColor="#A8B1B9" />
                    </asp:GridView>
                    <br />
                    <br />
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12 text-center">
                    <asp:Button CssClass="btn btn-primary btn-sm" ID="Button1" runat="server" Text="Remove Selected Item(s)" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>