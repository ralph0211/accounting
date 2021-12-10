<%@ Page Language="VB" MasterPageFile="~/Site2.master" AutoEventWireup="false" CodeFile="ApplicationView.aspx.vb" Inherits="Credit_ApplicationView" Title="Application Approval" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        th {
            cursor: pointer;
            background-color: #dadada;
            color: Black;
            font-weight: bold;
            text-align: left;
        }

            th.headerSortUp {
                background-image: url(images/asc.gif);
                background-position: right center;
                background-repeat: no-repeat;
            }

            th.headerSortDown {
                background-image: url(images/desc.gif);
                background-position: right center;
                background-repeat: no-repeat;
            }

        td {
            border-bottom: solid 1px #dadada;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="panel panel-primary small">
        <div class="panel-heading">
            <h4 class="panel-title">
                <a>View Applications
                    <asp:Label ID="lblAppCount" runat="server" Text="0" CssClass="badge"></asp:Label></a>
            </h4>
        </div>
        <div class="panel-body">
            <div class="row">
                <div class="col-xs-2 control-label">
                    <asp:Label ID="Label21" runat="server" Text="Search Name"></asp:Label>
                </div>
                <div class="col-xs-4">
                    <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtSearchName" runat="server"></asp:TextBox>
                </div>
                <div class="col-xs-3">
                    <asp:Button CssClass="btn btn-primary btn-sm" ID="btnSearchRange" runat="server" Text=">>" />
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12 center-block">
                    <asp:GridView ID="grdApps" runat="server" AllowPaging="True" AutoGenerateColumns="false"
                        HorizontalAlign="Center" CssClass="table table-bordered table-striped tablestyle success"
                        EmptyDataText="No applications ready for processing!" EmptyDataRowStyle-CssClass="text-warning text-center">
                        <AlternatingRowStyle CssClass="altrowstyle" />
                        <%--<HeaderStyle CssClass="headerstyle" HorizontalAlign="center" />--%>
                        <HeaderStyle CssClass="header info" />
                        <RowStyle CssClass="rowstyle" />
                        <PagerStyle CssClass="pagination-ys" />
                        <Columns>
                            <asp:TemplateField ShowHeader="False">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False"
                                        CommandName="Select" Text='<%#Eval("StageName") %>' CommandArgument='<%# Eval("ID") %>'></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="View Application">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Application" Font-Size="Large" CommandArgument='<%# Eval("ID") %>' CssClass="text-center"><span class="glyphicon glyphicon-eye-open"></span></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False"
                                ReadOnly="True" SortExpression="ID" />
                            <asp:BoundField DataField="CUST NO." HeaderText="CUST NO." InsertVisible="False"
                                ReadOnly="True" SortExpression="CUST NO." />
                            <asp:BoundField DataField="TYPE" HeaderText="TYPE" InsertVisible="False"
                                ReadOnly="True" SortExpression="TYPE" />
                            <asp:BoundField DataField="NAME" HeaderText="NAME" InsertVisible="False"
                                ReadOnly="True" SortExpression="NAME" />
                            <asp:BoundField DataField="AMOUNT" HeaderText="AMOUNT" InsertVisible="False"
                                ReadOnly="True" SortExpression="AMOUNT" />
                            <asp:BoundField DataField="APPLICATION DATE" HeaderText="APPLICATION DATE" InsertVisible="False"
                                ReadOnly="True" SortExpression="APPLICATION DATE" />
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-3 control-label">
                    <asp:Label ID="lblDetailID" runat="server" Text=""></asp:Label>
                    <asp:Label ID="lblSessionRole" runat="server" Text=""></asp:Label>
                </div>
            </div>
        </div>
    </div>
    <div>
        <div id="modal_dialog" style="display: none">
        </div>
        <asp:Button CssClass="btn btn-primary btn-sm" ID="btnModalPopup" runat="server" Text="Show Modal Popup" Visible="False" />
        <asp:Label ID="lblTest" runat="server" Text=""></asp:Label>
    </div>
    <script type="text/javascript" src="../Scripts/tablesorter/jquery.tablesorter.combined.min.js"></script>
    <script type="text/javascript">
        $('.datepicker').datepicker({
            format: 'dd MM yyyy',
            todayHighlight: true
        });
        $(document).ready(function () {
            $("[id*=grdApps]").tablesorter();
        });

        $(function () {
            $("[id*=btnSaveLoginParameters]").bind("click", function () {
                $("[id*=btnSaveLoginParameters]").val("Saving...");
                $("[id*=btnSaveLoginParameters]").attr("disabled", true);
            });
        });

        $('.nofuturedate').datepicker({
            format: 'dd MM yyyy',
            todayHighlight: true,
            endDate: '+0d'
        });
    </script>
    <script type="text/javascript">
        $("[id*=btnModalPopup]").live("click", function () {
            $("#modal_dialog").dialog({
                title: "Approve Application",
                buttons: {
                    Show: function () {
                        //                        $(this).dialog('close');
                        $(this).dialog({ autoOpen: false });
                        $(this).load('popApplicationApproval.aspx?ID=' + $("[id*=lblDetailID]").text());
                        // Open the dialog
                        $(this).dialog('open');
                    },
                    Approve: function () {
                        var roleID = $("#<%=lblSessionRole.clientID %>").text();
                        var appID = $("#<%=lblDetailID.clientID %>").text();
                        var str = roleID + "," + appID
                        $.ajax({
                            type: "POST",
                            url: "ApplicationApproval.aspx/approveJQuery",
                            //                            data: JSON.stringify({roleID: $("[id*=lblSessionRole]").text(), appID: $("[id*=lblDetailID]").text()}),
                            data: "{'roleID':'" + roleID + "','appID':'" + appID + "'}",
                            //                          data: JSON.stringify({roleID: roleID, appID: appID}),
                            ContentType: 'application/json; charset=utf-8',
                            dataType: "html",
                            //                            dataType: 'json',
                            success: function (msg) {
                                $("#<%=lblTest.clientID %>").text(msg);
                                alert("Succesfully approved");
                            },
                            error: function (jqXHR, textStatus, errorThrown) {
                                alert("status: " + textStatus);
                                alert("errorThrown: " + errorThrown);
                            }
                        });
                    }
                },
                modal: true,
                width: 600,
                height: 450
            });
            return false;
        });
    </script>
</asp:Content>