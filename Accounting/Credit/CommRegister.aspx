<%@ Page Title="Communication Register" Language="VB" MasterPageFile="~/Site2.master" AutoEventWireup="false" CodeFile="CommRegister.aspx.vb" Inherits="Credit_CommRegister" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        div.ui-datepicker {
            font-size: 10px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="panel panel-primary small">
                <div class="panel-heading">
                    <h4 class="panel-title">
                        <a>Communication Register</a>
                    </h4>
                </div>
                <div class="panel-body">
                    <div class="row">
                        <div class="col-xs-3 control-label">
                            <asp:Label ID="Label1" runat="server" Text="Customer Number"></asp:Label>
                        </div>
                        <div class="col-xs-3">
                            <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtCustNo" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-xs-1">
                            <asp:Button CssClass="btn btn-primary btn-sm" ID="btnSearchCustNo" runat="server" Text=">>" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-3 control-label">
                            <asp:Label ID="lblNatID" runat="server" Text="National ID Number"></asp:Label>
                        </div>
                        <div class="col-xs-3">
                            <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtNationalID" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-xs-1">
                            <asp:Button CssClass="btn btn-primary btn-sm" ID="btnSearchNationalID" runat="server" Text=">>" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-3 control-label">
                            <asp:Label ID="Label2" runat="server" Text="Search by customer name"></asp:Label>
                        </div>
                        <div class="col-xs-3">
                            <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtSearchName" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-xs-1">
                            <asp:Button CssClass="btn btn-primary btn-sm" ID="btnSearchName" runat="server" Text=">>" Visible="false" />
                        </div>
                        <div class="col-xs-5">
                            <asp:UpdateProgress ID="updateProgress" runat="server">
                                <ProgressTemplate>
                                    <div style="text-align: center; height: 30px;">
                                        <asp:Image ID="imgUpdateProgress" runat="server" ImageUrl="Images/loading-bar.gif" AlternateText="Loading ..." ToolTip="Loading ..." Height="30px" />
                                    </div>
                                </ProgressTemplate>
                            </asp:UpdateProgress>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-12 center-block">
                            <asp:ListBox ID="lstLoans" runat="server" Visible="False" AutoPostBack="True"></asp:ListBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-3 control-label">
                            <asp:Label ID="lblName" runat="server" Text=""></asp:Label>
                        </div>
                        <div class="col-xs-3 control-label">
                            <asp:Label ID="lblAddress" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-12 center-block">
                            <asp:GridView ID="grdLoans" runat="server" AutoGenerateColumns="false" Caption="Loan Details" CaptionAlign="Top">
                                <AlternatingRowStyle CssClass="altrowstyle" />
                                <HeaderStyle CssClass="headerstyle" HorizontalAlign="center" />
                                <RowStyle CssClass="rowstyle" />
                                <Columns>
                                    <asp:TemplateField HeaderText="ID">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDateCommCode" runat="server"><%#Eval("ID")%></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Date">
                                        <ItemTemplate>
                                            <asp:Label ID="lblOfficer" runat="server"><%#Eval("REC_DATE1")%></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Amount">
                                        <ItemTemplate>
                                            <asp:Label ID="lblResponse" runat="server"><%#Eval("FIN_AMT")%></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-3 control-label">
                            <asp:CheckBox ID="chkAddResponse" runat="server"
                                Text="Add Response" AutoPostBack="true" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-12 center-block">
                            <div id="CaptureResponse" runat="server" style="width: 80%; margin: 0 auto;" visible="false">
                                <div class="row">
                                    <div class="col-xs-3 control-label">
                                        <asp:Label ID="lblDate" runat="server" Text="Date"></asp:Label>
                                    </div>
                                    <div class="col-xs-3">
                                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtDate" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-xs-3 control-label">
                                        <asp:Label ID="lblOfficer" runat="server" Text="Officer"></asp:Label>
                                    </div>
                                    <div class="col-xs-3">
                                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtOfficer" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-xs-3 control-label">
                                        <asp:Label ID="lblResponse" runat="server" Text="Response"></asp:Label>
                                    </div>
                                    <div class="col-xs-3">
                                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtResponse" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-xs-1 control-label">
                                        <asp:Button CssClass="btn btn-primary btn-sm" ID="btnAddResponse" runat="server" Text="Add" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-12 center-block">
                            <asp:Panel ID="panCreditCalc" runat="server">
                                <div class="row">
                                    <div class="col-xs-12 center-block">
                                        <asp:GridView ID="grdRegister" runat="server" AutoGenerateColumns="False" Caption="Communication History" CaptionAlign="Top">
                                            <AlternatingRowStyle CssClass="altrowstyle" />
                                            <Columns>
                                                <asp:TemplateField ShowHeader="False">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="LinkButton3" runat="server" CausesValidation="False"
                                                            CommandName="Delete" Text="Delete" OnClientClick="return isDelete();"></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ShowHeader="False">
                                                    <EditItemTemplate>
                                                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True"
                                                            CommandName="Update" Text="Update"></asp:LinkButton>
                                                        <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False"
                                                            CommandName="Cancel" Text="Cancel"></asp:LinkButton>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="LinkButton4" runat="server" CausesValidation="False"
                                                            CommandName="Edit" Text="Edit"></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Date">
                                                    <EditItemTemplate>
                                                        <asp:TextBox CssClass="col-xs-12 form-control input-sm datepicker" ID="txtDateCommEdit" runat="server" Text='<%#Bind("date_comm")%>'></asp:TextBox>
                                                        <%--<bdp:basicdatepicker id="bdpEditDate" runat="server" selecteddate='<%#Bind("HOLIDAY_DATE")%>'></bdp:basicdatepicker>--%>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblDateCommCode" runat="server"><%#Eval("date_comm")%></asp:Label>
                                                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtCommId0" runat="server" Text='<%#Eval("id")%>'
                                                            Visible="False"></asp:TextBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Quest Officer">
                                                    <EditItemTemplate>
                                                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" runat="server" Text='<%#Bind("officer")%>' ID="txtGrdOfficerEdit">
                                                        </asp:TextBox>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblOfficer" runat="server"><%#Eval("officer")%></asp:Label>
                                                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtGrdRegID" runat="server" Visible="False" Text='<%#Bind("ID")%>'></asp:TextBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Response">
                                                    <EditItemTemplate>
                                                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" runat="server" Text='<%#Bind("response")%>' ID="txtGrdResponseEdit">
                                                        </asp:TextBox>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblResponse" runat="server"><%#Eval("response")%></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <HeaderStyle CssClass="headerstyle" HorizontalAlign="center" />
                                            <RowStyle CssClass="rowstyle" />
                                        </asp:GridView>
                                    </div>
                                </div>
                            </asp:Panel>
                            <asp:Label ID="hfCustomerId" runat="server" />
                        </div>
                    </div>
                </div>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnAddResponse" />
        </Triggers>
    </asp:UpdatePanel>
    <div>
        <div id="modal_dialog" style="display: none">
        </div>
    </div>
    <script type="text/javascript" src="js/jquery-1.11.1.min.js"></script>
    <script type="text/javascript" src="js/jquery-ui-1.10.4.min.js"></script>
    <script type="text/javascript" src="js/noty/packaged/jquery.noty.packaged.min.js"></script>
    <script type="text/javascript">

        function pageLoad(sender, args) {
            $(document).ready(function () {
                $("#<%=txtSearchName.ClientID %>").autocomplete({
                    source: function (request, response) {
                        $.ajax({
                            url: '<%=ResolveUrl("Service.asmx/GetApplicants") %>',
                            data: "{ 'prefix': '" + request.term + "'}",
                            dataType: "json",
                            type: "POST",
                            contentType: "application/json; charset=utf-8",
                            success: function (data) {
                                response($.map(data.d, function (item) {
                                    return {
                                        label: item.split('--')[0],
                                        val: item.split('--')[1]
                                    }
                                }))
                            },
                            error: function (response) {
                                alert(response.responseText);
                            },
                            failure: function (response) {
                                alert(response.responseText);
                            }
                        });
                    },
                    select: function (e, i) {
                        $("#<%=hfCustomerId.ClientID %>").text(i.item.val);
                        $("#<%=txtCustNo.ClientID %>").val(i.item.val);
                        $("#<%=btnSearchCustNo.ClientID%>").click();
                    },
                    minLength: 1
                });
            });

            $(function () {
                $('.ui-autocomplete').css('height', 'auto');

                var $input = $('#<%= txtSearchName.ClientID %>'),
                inputTop = $input.offset().top,
                inputHeight = $input.height(),
                autocompleteHeight = $('.ui-autocomplete').height(),
                windowHeight = $(window).height();
                if ((inputHeight + inputTop + autocompleteHeight) > windowHeight) {

                    $('.ui-autocomplete')
                        .css('height', (windowHeight - inputHeight - inputTop - 20) + 'px');
                }
            });

            $(function () {
                $("#<%= txtDate.ClientID%>").datepicker({
                    defaultDate: "+1w",
                    dateFormat: 'd MM yy',
                    yearRange: '-10:+1',
                    changeMonth: true,
                    changeYear: true
                });
            });

            $(function genDates() {
                $(".datepicker").datepicker({
                    dateFormat: 'd MM yy',
                    yearRange: '-10:+1',
                    changeMonth: true,
                    changeYear: true
                });
            });
        }
    </script>
</asp:Content>