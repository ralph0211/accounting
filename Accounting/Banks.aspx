<%@ Page Language="VB" MasterPageFile="~/Site2.master" AutoEventWireup="false" CodeFile="Banks.aspx.vb" Inherits="Banks" Title="Banks" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="Content/themes/redmond/jquery-ui.theme.min.css" rel="stylesheet" />
    <link href="Content/bootstrap-datepicker3.css" rel="stylesheet" />
    <link href="Content/bootstrap-chosen.css" rel="stylesheet" />
    <style type="text/css">
        .panel-heading {
            text-align: left;
            font-weight: bold;
        }

        .panel-body {
            background-color: #EEEEEE;
        }

        .panel-title a {
            font-weight: bold;
            width: 100%;
            display: block;
            padding: 10px 15px;
            margin: -10px -15px;
        }

        .control-label {
            /* text-align:right; */
            text-align: left;
            font-weight: bold;
        }

        .row {
            margin-bottom: 3px;
        }

        .left {
            text-align: left;
        }

        ul.ui-autocomplete {
            list-style: none;
            list-style-type: none;
            padding: 0px;
            margin: 0px;
            margin-left: 5px;
            font-size: small;
            max-width: 500px;
        }

        .ui-autocomplete-loading {
            background: url('../Images/loading.gif') no-repeat right center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="panel panel-primary small">
        <div class="panel-heading">
            <h4 class="panel-title">
                <a data-parent="#collapse" data-toggle="collapse" href="#collapse-one">Add/Edit Banks
                </a>
            </h4>
        </div>
        <div class="panel-body">
            <div class="row">
                <div class="col-xs-2 control-label">
                    <asp:Label ID="Label5" runat="server"
                        Text="Bank Code"></asp:Label>
                </div>
                <div class="col-xs-4">
                    <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtBranchCode" runat="server"></asp:TextBox>
                </div>
                <div class="col-xs-2 control-label">
                    <asp:Label ID="Label18" runat="server"
                        Text="Bank Name"></asp:Label>
                </div>
                <div class="col-xs-4">
                    <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtBranchName" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-3"></div>
                <div class="col-xs-3">
                    <asp:RequiredFieldValidator ID="valBankCode" ValidationGroup="main" runat="server" ErrorMessage="Bank Code is required" ControlToValidate="txtBranchCode"></asp:RequiredFieldValidator>
                </div>
                <div class="col-xs-3"></div>
                <div class="col-xs-3">
                    <asp:RequiredFieldValidator ID="valBankName" ValidationGroup="main" runat="server" ErrorMessage="Bank Name is required" ControlToValidate="txtBranchName"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12 text-center">
                    <asp:Button CssClass="btn btn-primary btn-sm" ValidationGroup="main" ID="btnAddBranch" runat="server" Text="Add Bank" UseSubmitBehavior="false" />
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12 center-block">
                    <asp:GridView ID="grdBranches" runat="server" HorizontalAlign="Center"
                        AutoGenerateColumns="False">
                        <AlternatingRowStyle CssClass="altrowstyle" />
                        <HeaderStyle CssClass="headerstyle" HorizontalAlign="center" />
                        <RowStyle CssClass="rowstyle" />
                        <Columns>
                            <asp:TemplateField ShowHeader="False">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False"
                                        CommandName="Delete" Text="Delete" OnClientClick="return isDelete();"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField ShowHeader="False">
                                <EditItemTemplate>
                                    <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="True"
                                        CommandName="Update" Text="Update"></asp:LinkButton>
                                    &nbsp;<asp:LinkButton ID="LinkButton3" runat="server" CausesValidation="False"
                                        CommandName="Cancel" Text="Cancel"></asp:LinkButton>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton4" runat="server" CausesValidation="False"
                                        CommandName="Edit" Text="Edit"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Bank Code">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtGrdBranchCode" runat="server" Text='<%#Bind("BANK_CODE")%>'></asp:TextBox>
                                    <asp:TextBox ID="txtOldBranchCode11" runat="server" Text='<%#Bind("BANK_CODE")%>' Visible="False"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblBranchCode" runat="server"><%#Eval("BANK_CODE")%></asp:Label>
                                    <asp:TextBox ID="txtOldBranchCode" runat="server" Text='<%#Bind("BANK_CODE")%>' Visible="False"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Bank Name">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtBranchNameEdit" runat="server" Text='<%#Bind("BANK_NAME")%>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblBranchName" runat="server"><%#Eval("BANK_NAME")%></asp:Label>
                                    <asp:TextBox ID="txtGrdBranch" runat="server" Text='<%#Bind("ID")%>' Visible="False"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
    <script src="Scripts/jquery-2.1.4.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <script src="Scripts/jquery-ui-1.11.4.min.js"></script>
    <script src="Scripts/bootstrap-datepicker.js"></script>
    <script src="Scripts/jquery.validate.min.js"></script>
    <script src="Scripts/bootbox.min.js"></script>
    <script src="Scripts/noty/jquery.noty.js"></script>
    <script src="Scripts/noty/layouts/top.js"></script>
    <script src="Scripts/noty/layouts/topCenter.js"></script>
    <script src="Scripts/noty/layouts/inline.js"></script>
    <script src="Scripts/noty/layouts/center.js"></script>
    <script src="Scripts/noty/themes/relax.js"></script>
    <script src="Scripts/chosen.jquery.js"></script>
    <script type="text/javascript">
        $('.datepicker').datepicker({
            format: 'dd MM yyyy',
            todayHighlight: true
        });

        $(function () {
            $("[id*=btnAddBranch]").bind("click", function () {
                $("[id*=btnAddBranch]").val("Adding Bank...");
                $("[id*=btnAddBranch]").attr("disabled", true);
            });
        });

        $('.nofuturedate').datepicker({
            format: 'dd MM yyyy',
            todayHighlight: true,
            endDate: '+0d'
        });

        function notify(txt, noteType, layout) {
            layout = layout || 'top';
            var n = noty({
                layout: layout,
                theme: 'relax',
                type: noteType,
                text: txt,
                timeout: 10000
            });
        };

        function isDelete() {
            return confirm("Are you sure you want to delete this record?");
        };

        function isnumeric(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode;
            if ((charCode >= 48 && charCode <= 57) || charCode == 8 || charCode == 190 || charCode == 188 || charCode == 46 || charCode == 44) {
                return true;
            }
            else {
                notify("This field requires numbers only!", "error", "center");
                return false;
            }
        };

        function isPhoneNo(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode;
            if ((charCode >= 48 && charCode <= 57) || charCode == 8 || charCode == 47 || charCode == 45 || charCode == 32 || charCode == 43) {
                return true;
            }
            else {
                notify("Enter valid phone number characters only!", "error", "center");
                return false;
            }
        };

        function isTextOnly(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode;
            if ((charCode >= 48 && charCode <= 57) || charCode == 190 || charCode == 188 || charCode == 46 || charCode == 44) {
                notify("Numeric input not allowed for this field!", "error", "center");
                return false;
            }
            else {
                return true;
            }
        };
    </script>
</asp:Content>