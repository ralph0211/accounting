<%@ Page Title="Indicator Weighting" Language="VB" MasterPageFile="~/Site2.master" AutoEventWireup="false" CodeFile="IndicatorWeighting.aspx.vb" Inherits="Rating_IndicatorWeighting" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../Content/Rating.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <article>
        <div class="panel panel-primary">
            <div class="panel-heading">
                Indicator Weighting
            </div>
            <div class="panel-body">
                <div class="row">
                    <div class="control-label col-xs-2">
                        <asp:Label ID="Label1" runat="server" CssClass="label-font" Text="Entity Type" Visible="false"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:DropDownList ID="cmbEntityType" runat="server" AutoPostBack="True" CssClass="form-control input-sm" Visible="false"></asp:DropDownList>
                    </div>
                    <div class="control-label col-xs-2">
                        <asp:Label ID="Label2" runat="server" CssClass="label-font" Text="Category" Visible="false"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:DropDownList ID="cmbCategory" runat="server" AutoPostBack="True" CssClass="form-control input-sm" Visible="false"></asp:DropDownList>
                    </div>
                </div>
                <div class="row" style="text-align: center; margin: 0 auto; width: 90%">
                    <asp:Repeater ID="rptCategories" runat="server" OnItemDataBound="rptCategories_ItemDataBound">
                        <HeaderTemplate>
                            <table id="wgtTable" style="width: 100%; border-spacing: 0;">
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr class="Repeater">
                                <th align="left" colspan="7">
                                    <asp:Label ID="lblCategory" runat="server" Font-Names="Calibri"
                                        ForeColor="#ffffff" Style="margin-left: 15px;" Text='<%#DataBinder.Eval(Container.DataItem, "category")%>'></asp:Label>
                                    <asp:Label ID="lblCatID" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "cat_id")%>' Visible="False"></asp:Label>
                                </th>
                                <th align="right" colspan="1" style="text-align: right;">
                                    <asp:Label ID="txtWeight" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "weight")%>' Width="50px"></asp:Label>
                                    %
                                </th>
                            </tr>
                            <tr>
                                <td colspan="8">
                                    <asp:Repeater ID="rptSubCategory" runat="server" OnItemDataBound="rptSubCategory_ItemDataBound">
                                        <HeaderTemplate>
                                            <table id="wgtTable" style="width: 100%; border-spacing: 0;">
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <tr class="Repeater">
                                                <td align="left" colspan="7">
                                                    <asp:Label ID="lblSubCategory" runat="server" Font-Names="Calibri"
                                                        ForeColor="#000000" Style="margin-left: 15px;" Text='<%#DataBinder.Eval(Container.DataItem, "sub_category")%>'></asp:Label>
                                                    <asp:Label ID="lblSubCatID" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "subcatID")%>' Visible="False"></asp:Label>
                                                </td>
                                                <td align="right" colspan="1">
                                                    <asp:TextBox ID="txtSubWeight" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "weight")%>' Width="50px"></asp:TextBox>
                                                    %
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                        <AlternatingItemTemplate>
                                            <tr class="Repeater-alt">
                                                <td align="left" colspan="7">
                                                    <asp:Label ID="lblSubCategory" runat="server" Font-Names="Calibri"
                                                        ForeColor="#000000" Style="margin-left: 15px;" Text='<%#DataBinder.Eval(Container.DataItem, "sub_category")%>'></asp:Label>
                                                    <asp:Label ID="lblSubCatID" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "subcatID")%>' Visible="False"></asp:Label>
                                                </td>
                                                <td align="right" colspan="1">
                                                    <asp:TextBox ID="txtSubWeight" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "weight")%>' Width="50px"></asp:TextBox>
                                                    %
                                                </td>
                                            </tr>
                                        </AlternatingItemTemplate>
                                        <FooterTemplate>
                                            </table>
                                        </FooterTemplate>
                                    </asp:Repeater>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" colspan="2" style="text-align: left;">
                                    <asp:Label ID="lblSubCatError" runat="server" ForeColor="Red" Text=""></asp:Label>
                                </td>
                            </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                            <tr>
                                <td></td>
                            </tr>
                            </table>
                        </FooterTemplate>
                    </asp:Repeater>
                </div>
                <div style="height:20px;"></div>
                <div class="row" style="margin: 0 auto; display: table;">
                    <div style="text-align: right; width: 95%; font-weight: bold; font-size: large;">
                        <asp:Label ID="lblTotalWeightMessage" runat="server" Text="NB: Total weight must be 100%. Current total is: " Visible="false"></asp:Label>
                        <asp:Label ID="lblTotalWeight" runat="server" Text="" Visible="false"></asp:Label>
                        <asp:Label ID="lblTotalWeightPerc" runat="server" Text="%" Visible="false"></asp:Label>
                    </div>
                    <div style="text-align: center; width: 100%;">
                        <asp:Button ID="btnSaveWeight" runat="server" CssClass="btn btn-primary" OnClick="btnSaveWeight_Click" Text="Save" />
                    </div>
                </div>
            </div>
        </div>
    </article>
    <script type="text/javascript">
        function calcSum() {
            var container = document.getElementById("wgtTable");
            var inputs = container.getElementsByTagName("input");

            var sum = Number(0);

            for (var i = 0; i < inputs.length; i++) {
                sum += Number(inputs[i].value);
            }

            //alert(sum);
            $("#<%= lblTotalWeight.ClientID%>").text(sum);
            if (sum < 100 || sum > 100) {
                $("#<%= lblTotalWeight.ClientID%>").css("color", "red");
                $("#<%= lblTotalWeightMessage.ClientID%>").css("color", "red");
                $("#<%= lblTotalWeightPerc.ClientID%>").css("color", "red");
                $("#<%= btnSaveWeight.ClientID%>").attr('disabled', 'disabled');
                $("#<%= lblTotalWeightMessage.ClientID%>").text("NB: Total weight must be 100%. Current total is: ");
            } else if (sum == 100) {
                $("#<%= lblTotalWeight.ClientID%>").css("color", "green");
                $("#<%= lblTotalWeightMessage.ClientID%>").css("color", "green");
                $("#<%= lblTotalWeightPerc.ClientID%>").css("color", "green");
                $("#<%= btnSaveWeight.ClientID%>").removeAttr("disabled");
                $("#<%= lblTotalWeightMessage.ClientID%>").text("Total is: ");
            }
        }
    </script>
</asp:Content>