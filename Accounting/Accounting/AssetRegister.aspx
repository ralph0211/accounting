<%@ Page Title="Asset Register" Language="VB" MasterPageFile="~/Site2.master" AutoEventWireup="false" CodeFile="AssetRegister.aspx.vb" Inherits="Accounting_AssetRegister" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="panel panel-primary small">
        <div class="panel-heading">
            <h4 class="panel-title">
                <a>Asset Register</a>
            </h4>
        </div>
        <div class="panel-body">
            <div class="row">
                <div class="col-xs-2 control-label">
                    <asp:Label ID="Label1220" runat="server" Text="Name"></asp:Label>
                </div>
                <div class="col-xs-4">
                    <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtName" runat="server"></asp:TextBox>
                </div>
                <div class="col-xs-2 control-label">
                    <asp:Label ID="Label1221" runat="server" Text="Category"></asp:Label>
                </div>
                <div class="col-xs-4">
                    <asp:DropDownList CssClass="col-xs-12 form-control input-sm" ID="cmbCategory" runat="server">
                        <asp:ListItem>-Select-</asp:ListItem>
                        <asp:ListItem>Property (Building, Houses, Land etc)</asp:ListItem>
                        <asp:ListItem>Vehicle</asp:ListItem>
                        <asp:ListItem>Furniture</asp:ListItem>
                        <asp:ListItem>I.T Equipment(Hardware)</asp:ListItem>
                        <asp:ListItem>Other Equipment</asp:ListItem>
                        <asp:ListItem>miscellaneous</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-2 control-label">
                    <asp:Label ID="Label23" runat="server" Text="Asset ID"></asp:Label>
                </div>
                <div class="col-xs-4">
                    <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtID" runat="server"></asp:TextBox>
                </div>
                <div class="col-xs-2 control-label">
                    <asp:Label ID="Label24" runat="server" Text="Acquisition Date"></asp:Label>
                </div>
                <div class="col-xs-4">
                    <asp:TextBox ID="dtpTrxnDate" runat="server" CssClass="form-control input-sm datepicker"></asp:TextBox>
                    <span class="glyphicon glyphicon-calendar form-control-feedback" style="margin-right: 13px; background-color: #eeeeff; border-radius: 0 3px 3px 0; border: 1px solid rgb(149,188,219); z-index: 0;"></span>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-2 control-label">
                    <asp:Label ID="Label1222" runat="server" Text="Value at Acquisition"></asp:Label>
                </div>
                <div class="col-xs-4">
                    <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtInitValue" runat="server"></asp:TextBox>
                </div>
                <div class="col-xs-2 control-label">
                    <asp:Label ID="Label1223" runat="server" Text="Current Value"></asp:Label>
                </div>
                <div class="col-xs-4">
                    <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtCurrVal" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-2 control-label">
                    <asp:Label ID="Label1219" runat="server" Text="Description "></asp:Label>
                </div>
                <div class="col-xs-4">
                    <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtdesc" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12 text-center">
                    <asp:Button CssClass="btn btn-primary btn-sm" ID="btnSaveTrxn" runat="server" Text="Save" />
                    &nbsp;<asp:Button CssClass="btn btn-primary btn-sm" ID="btnSaveTrxn0" runat="server" Text="Update" />
                    &nbsp;<asp:Button CssClass="btn btn-primary btn-sm" ID="btnSaveTrxn1" runat="server" Text="Remove" />
                    &nbsp;<asp:Button CssClass="btn btn-primary btn-sm" ID="btnSaveTrxn2" runat="server" Text="New" />
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12 center-block">
                    <asp:GridView ID="grdDetails" runat="server" HorizontalAlign="Center" EnableModelValidation="True" AutoGenerateSelectButton="True">
                        <AlternatingRowStyle CssClass="altrowstyle" />
                        <HeaderStyle CssClass="headerstyle" HorizontalAlign="center" />
                        <RowStyle CssClass="rowstyle" />
                        <PagerStyle CssClass="pagination-ys" />
                        <SelectedRowStyle BackColor="#A8B1B9" Font-Bold="true" />
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