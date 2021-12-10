<%@ Page Title="View Rejected Applications" Language="VB" MasterPageFile="~/Site2.master" AutoEventWireup="false" CodeFile="Rejected.aspx.vb" Inherits="Credit_Rejected" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="panel panel-primary small">
        <div class="panel-heading">
            <h4 class="panel-title">
                <a>View Rejected Applications</a>
            </h4>
        </div>
        <div class="panel-body">
            <div class="row">
                <div class="col-xs-1 control-label">
                    <asp:Label ID="Label1" runat="server" Text="From"></asp:Label>
                </div>
                <div class="col-xs-4">
                    <asp:TextBox ID="bdpFrom" runat="server" CssClass="form-control input-sm nofuturedate"></asp:TextBox>
                    <span class="glyphicon glyphicon-calendar form-control-feedback" style="margin-right: 13px; background-color: #eeeeff; border-radius: 0 3px 3px 0; border: 1px solid rgb(149,188,219); z-index: 0;"></span>
                </div>
                <div class="col-xs-1 control-label">
                    <asp:Label ID="Label2" runat="server" Text="To"></asp:Label>
                </div>
                <div class="col-xs-4">
                    <asp:TextBox ID="bdpTo" runat="server" CssClass="form-control input-sm nofuturedate"></asp:TextBox>
                    <span class="glyphicon glyphicon-calendar form-control-feedback" style="margin-right: 13px; background-color: #eeeeff; border-radius: 0 3px 3px 0; border: 1px solid rgb(149,188,219); z-index: 0;"></span>
                </div>
                <div class="col-xs-1">
                    <asp:Button CssClass="btn btn-primary btn-sm" ID="btnSearchRange" runat="server" Text=">>" />
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12 center-block">
                    <asp:GridView ID="grdApps" runat="server" AllowPaging="True"
                        HorizontalAlign="Center" CssClass="table table-bordered table-striped tablestyle success"
                        EmptyDataText="No applications ready for processing!" EmptyDataRowStyle-CssClass="text-warning text-center">
                        <AlternatingRowStyle CssClass="altrowstyle" />
                        <HeaderStyle CssClass="header info" />
                        <RowStyle CssClass="rowstyle" />
                        <PagerStyle CssClass="pagination-ys" />
                        <Columns>
                            <asp:TemplateField ShowHeader="False">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False"
                                        CommandName="Select" Text="Select" CommandArgument='<%# Eval("ID") %>'></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-3">
                    <asp:Label ID="lblDetailID" runat="server" Text=""></asp:Label>
                    <asp:Label ID="lblSessionRole" runat="server" Text=""></asp:Label>
                </div>
            </div>
        </div>
    </div>
    <div>
        <div id="modal_dialog" style="display: none">
        </div>
        <asp:Button ID="btnModalPopup" runat="server" Text="Show Modal Popup" Visible="False" />
        <asp:Label ID="lblTest" runat="server" Text=""></asp:Label>
    </div>
    <script type="text/javascript">
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