<%@ Page Title="Transaction Batching" Language="VB" MasterPageFile="~/Site2.master" AutoEventWireup="false" CodeFile="Batching.aspx.vb" Inherits="Accounting_Batching" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="panel panel-primary small">
        <div class="panel-heading">
            <h4 class="panel-title">
                <a>Transaction Batching</a>
            </h4>
        </div>
        <div class="panel-body">
            <div class="row">
                <div class="col-xs-12 center-block">
                    <asp:CheckBox ID="chkSingle" runat="server" AutoPostBack="True" Text="Single Account" Visible="False" />
                </div>
            </div>
            <div class="row">
                <div class="col-xs-2 control-label">
                    <asp:Label ID="lblAccount" runat="server" Text="Account" Visible="False"></asp:Label>
                </div>
                <div class="col-xs-4">
                    <asp:DropDownList CssClass="col-xs-12 form-control input-sm" ID="cmbAccount" runat="server" AutoPostBack="True" Visible="False">
                        <asp:ListItem></asp:ListItem>
                        <asp:ListItem>Receipting</asp:ListItem>
                        <asp:ListItem>CashBook</asp:ListItem>
                        <asp:ListItem>Journal</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-2 control-label">
                    <asp:Label ID="Label1220" runat="server" Text="Batch Type"></asp:Label>
                </div>
                <div class="col-xs-4">
                    <asp:DropDownList CssClass="col-xs-12 form-control input-sm" ID="cmbBatchType" runat="server" AutoPostBack="True">
                        <asp:ListItem></asp:ListItem>
                        <asp:ListItem>Receipting</asp:ListItem>
                        <asp:ListItem>CashBook</asp:ListItem>
                        <asp:ListItem>Journal</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="col-xs-2 control-label hidden">
                    <asp:Label ID="Label5" runat="server" Text="Batch Number"></asp:Label>
                </div>
                <div class="col-xs-4 hidden">
                    <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtBatchNo" runat="server" Enabled="False"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-2 control-label">
                    <asp:Label ID="Label23" runat="server" Text="Total Amount"></asp:Label>
                </div>
                <div class="col-xs-4">
                    <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtAmount" runat="server" onkeypress="return isnumeric(event)"></asp:TextBox>
                </div>
                <div class="col-xs-2 control-label">
                    <asp:Label ID="Label1219" runat="server" Text="Number Of Transactions"></asp:Label>
                </div>
                <div class="col-xs-4">
                    <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtTrxns" runat="server" onkeypress="return isnumeric(event)"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-2 control-label">
                    <asp:Label ID="Label1221" runat="server" Text="Batch Name (Description)"></asp:Label>
                </div>
                <div class="col-xs-4">
                    <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtBatchName" runat="server"></asp:TextBox>
                </div>
                <div class="col-xs-2 control-label">
                    <asp:Label ID="Label12d21" runat="server" Text="Batch Date"></asp:Label>
                </div>
                <div class="col-xs-4">
                    <asp:TextBox CssClass="col-xs-12 form-control input-sm nofuturedate" ID="txtBatchDate" runat="server"></asp:TextBox>
                    <span class="glyphicon glyphicon-calendar form-control-feedback" style="margin-right: 13px; background-color: #eeeeff; border-radius: 0 3px 3px 0; border: 1px solid rgb(149,188,219); z-index: 0;"></span>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12 text-center">
                    <asp:Button CssClass="btn btn-primary btn-sm" ID="btnSaveTrxn3" runat="server" Text="Add" />
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12 center-block">
                    <asp:GridView ID="grdDetails" runat="server" EnableModelValidation="True" HorizontalAlign="Center" AutoGenerateColumns="false">
                        <AlternatingRowStyle CssClass="altrowstyle" />
                        <HeaderStyle CssClass="headerstyle" HorizontalAlign="center" />
                        <RowStyle CssClass="rowstyle" />
                        <PagerStyle CssClass="pagination-ys" />
                        <SelectedRowStyle BackColor="#A8B1B9" Font-Bold="true" />
                        <Columns>
                            <asp:TemplateField ShowHeader="False">
                                <EditItemTemplate>
                                    <asp:LinkButton ID="lnkUpdate" runat="server" CausesValidation="True"
                                        CommandName="Update" Text="Update"></asp:LinkButton>
                                    &nbsp;<asp:LinkButton ID="lnkCancel" runat="server" CausesValidation="False"
                                        CommandName="Cancel" Text="Cancel"></asp:LinkButton>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkEdit" runat="server" CausesValidation="False"
                                        CommandName="Edit" Text="Edit"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField ShowHeader="False">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkDelete" runat="server" CausesValidation="False"
                                        CommandName="Delete" Text="Delete" OnClientClick="return isDelete();"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Batch Type">
                                <%--<EditItemTemplate>
                                    <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtBatchTypeEdit" runat="server" Text='<%# Bind("BatchType") %>'></asp:TextBox>
                                </EditItemTemplate>--%>
                                <ItemTemplate>
                                    <asp:Label ID="lblBatchType" runat="server" Text='<%# Bind("BatchType") %>'></asp:Label>
                                    <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtBatchId" runat="server" Text='<%#Eval("ID")%>'
                                        Visible="False"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Batch Number">
                                <%--<EditItemTemplate>
                                    <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtBatchNoEdit" runat="server" Text='<%# Bind("BatchNo") %>'></asp:TextBox>
                                </EditItemTemplate>--%>
                                <ItemTemplate>
                                    <asp:Label ID="lblBatchNo" runat="server" Text='<%# Bind("BatchNo") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Batch Date">
                                <EditItemTemplate>
                                    <asp:TextBox CssClass="col-xs-12 form-control input-sm nofuturedate" ID="txtBatchDateEdit" runat="server" Text='<%# Bind("BatchDate1") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblBatchDate" runat="server" Text='<%# Bind("BatchDate1") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Description">
                                <EditItemTemplate>
                                    <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtBatchNameEdit" runat="server" Text='<%# Bind("BatchName") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblBatchName" runat="server" Text='<%# Bind("BatchName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Amount">
                                <EditItemTemplate>
                                    <asp:TextBox CssClass="col-xs-12 form-control input-sm numeric" ID="txtAmountEdit" runat="server" Text='<%# Bind("Amount") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblAmount" runat="server" Text='<%# Bind("Amount") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Number of Transactions">
                                <EditItemTemplate>
                                    <asp:TextBox CssClass="col-xs-12 form-control input-sm numeric" ID="txtNumberOfTrxnsEdit" runat="server" Text='<%# Bind("NumberOfTrxns") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblNumberOfTrxns" runat="server" Text='<%# Bind("NumberOfTrxns") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        $(".dd_select2").chosen();
        $('.datepicker').datepicker({
            format: 'dd MM yyyy',
            todayHighlight: true
        });

        $(function () {
            $("[id*=btnSaveCreditParameters]").bind("click", function () {
                $("[id*=btnSaveCreditParameters]").val("Creating Amortization...");
                $("[id*=btnSaveCreditParameters]").attr("disabled", true);
            });
        });

        $('.nofuturedate').datepicker({
            format: 'dd MM yyyy',
            todayHighlight: true,
            endDate: '+0d'
        });
    </script>
</asp:Content>