<%@ Page Title="Journal Entries" Language="VB" MasterPageFile="~/Site2.master" AutoEventWireup="false" CodeFile="Journals.aspx.vb" Inherits="Accounting_Journals" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="panel panel-primary small">
        <div class="panel-heading">
            <h4 class="panel-title">
                <a>Journal Entries</a>
            </h4>
        </div>
        <div class="panel-body">
            <div class="row">
                <div class="col-xs-12 center-block">
                    <asp:RadioButtonList ID="rdTranType" runat="server" AutoPostBack="True" CssClass="col-xs-12 control-label" RepeatDirection="Horizontal">
                        <asp:ListItem>Trxn Reversal</asp:ListItem>
                        <asp:ListItem>New Journal Entry</asp:ListItem>
                    </asp:RadioButtonList>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-2 control-label">
                    <asp:Label ID="Label1225" runat="server" Text="Batch Number"></asp:Label>
                </div>
                <div class="col-xs-4">
                    <asp:DropDownList CssClass="col-xs-12 form-control input-sm chosen" ID="cmbBatchNo" runat="server" AutoPostBack="True">
                    </asp:DropDownList>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12">
                    <asp:GridView ID="grdBatchRec" runat="server" HorizontalAlign="center" Caption="Batch Details">
                        <AlternatingRowStyle CssClass="altrowstyle" />
                        <HeaderStyle CssClass="headerstyle" HorizontalAlign="center" />
                        <RowStyle CssClass="rowstyle" />
                        <PagerStyle CssClass="pagination-ys" />
                    </asp:GridView>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12 text-center alert-danger">
                    <%--<span class="glyphicon glyphicon-exclamation-sign"></span>--%>
                    <asp:Label ID="Label2" runat="server" Text="The cut off date for Cash Account is "></asp:Label>&nbsp;<asp:Label ID="lblCashCutOffDate" runat="server" Text=""></asp:Label>&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label3" runat="server" Text="The cut off date  for other accounts is "></asp:Label>&nbsp;<asp:Label ID="lblCutOffDate" runat="server" Text=""></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12 center-block">
                    <asp:Panel ID="Panel1" runat="server">
                        <div class="row">
                            <div class="col-xs-2 control-label">
                                <asp:Label ID="Label1220" runat="server" Text="Date"></asp:Label>
                            </div>
                            <div class="col-xs-4">
                                <asp:TextBox ID="dtpTrxnDate" runat="server" CssClass="form-control input-sm nofuturedate"></asp:TextBox>
                                <span class="glyphicon glyphicon-calendar form-control-feedback" style="margin-right: 13px; background-color: #eeeeff; border-radius: 0 3px 3px 0; border: 1px solid rgb(149,188,219); z-index: 0;"></span>
                            </div>
                            <div class="col-xs-2 control-label">
                                <asp:Label ID="Label1221" runat="server" Text="Description"></asp:Label>
                            </div>
                            <div class="col-xs-4">
                                <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtdesc" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-xs-2 control-label">
                                <asp:Label ID="Label23" runat="server" Text="Account "></asp:Label>
                            </div>
                            <div class="col-xs-4">
                                <asp:DropDownList CssClass="col-xs-12 form-control input-sm chosen" ID="cmbAccount" runat="server" AutoPostBack="True">
                                </asp:DropDownList>
                                <br />
                                <asp:DropDownList CssClass="col-xs-12 form-control input-sm chosen" ID="cmbAccount0" runat="server" AutoPostBack="True" Visible="False">
                                </asp:DropDownList>
                            </div>
                            <div class="col-xs-2 control-label">
                                <asp:Label ID="Label5" runat="server" Text="Type"></asp:Label>
                            </div>
                            <div class="col-xs-4">
                                <asp:RadioButtonList ID="rdbType" runat="server" CssClass="col-xs-12 control-label" RepeatDirection="Horizontal">
                                    <asp:ListItem>Debit</asp:ListItem>
                                    <asp:ListItem>Credit</asp:ListItem>
                                </asp:RadioButtonList>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-xs-2 control-label">
                                <asp:Label ID="Label1217" runat="server" Text="Refrence"></asp:Label>
                            </div>
                            <div class="col-xs-4">
                                <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtRef" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-xs-2 control-label">
                                <asp:Label ID="Label1219" runat="server" Text="Transaction Amount ($)"></asp:Label>
                            </div>
                            <div class="col-xs-4">
                                <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtAmount" runat="server" onkeypress="return isnumeric(event)"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-xs-2 control-label">
                                <asp:Label ID="Label24" runat="server" Text="Contra Account" Visible="False"></asp:Label>
                            </div>
                            <div class="col-xs-4">
                                <asp:DropDownList CssClass="col-xs-12 form-control input-sm" ID="cmbAccount1" runat="server" AutoPostBack="True" Visible="False">
                                </asp:DropDownList>
                                <br />
                                <asp:DropDownList CssClass="col-xs-12 form-control input-sm" ID="cmbContraAccount" runat="server" AutoPostBack="True" Visible="False">
                                </asp:DropDownList>
                            </div>
                        </div>
                    </asp:Panel>
                </div>
            </div>

            <div class="row">
                <div class="col-xs-12 text-center">
                    <asp:Button CssClass="btn btn-primary btn-sm" ID="btnSaveTrxn3" runat="server" Text="Add" />
                    <asp:Button CssClass="btn btn-primary btn-sm" ID="btnSaveTrxn" runat="server" Text="Commit" />
                    <asp:Button CssClass="btn btn-primary btn-sm" ID="btnSaveTrxn4" runat="server" Text="Search Transaction" />
                </div>
            </div>
            <div class="row">
                <div class="col-xs-2 control-label">
                    <asp:Label ID="lblTrxnSearch" runat="server" Text="Trxn Ref" Visible="False"></asp:Label>
                </div>
                <div class="col-xs-4">
                    <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtTrxnSearch" runat="server" Visible="False"></asp:TextBox>
                </div>
                <div class="col-xs-1">
                    <asp:Button CssClass="btn btn-primary btn-sm" ID="btnSearch" runat="server" Text="&gt;&gt;" Visible="False" />
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12 center-block">
                    <asp:GridView ID="grdDetails" runat="server" HorizontalAlign="center">
                        <AlternatingRowStyle CssClass="altrowstyle" />
                        <HeaderStyle CssClass="headerstyle" HorizontalAlign="center" />
                        <RowStyle CssClass="rowstyle" />
                        <PagerStyle CssClass="pagination-ys" />
                        <SelectedRowStyle BackColor="#A8B1B9" Font-Bold="true" />
                        <Columns>
                            <asp:TemplateField HeaderText="SELECT">
                                <ItemTemplate>
                                    <asp:CheckBox ID="checkbox2" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12 text-center">
                    <asp:Button CssClass="btn btn-primary btn-sm" ID="Button1" runat="server" Text="Remove Selected Item(s)" />
                </div>
            </div>
        </div>
    </div>
    <script src="../Scripts/chosen.jquery.min.js"></script>
    <script type="text/javascript">
        //$(".dd_select2").chosen();

        $(function () {
            $("[id*=btnSaveCreditParameters]").bind("click", function () {
                $("[id*=btnSaveCreditParameters]").val("Creating Amortization...");
                $("[id*=btnSaveCreditParameters]").attr("disabled", true);
            });
        });
    </script>
</asp:Content>