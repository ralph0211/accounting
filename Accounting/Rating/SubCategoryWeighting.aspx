<%@ Page Title="Sub-Category Weighting" Language="VB" MasterPageFile="~/Site2.master" AutoEventWireup="false" CodeFile="SubCategoryWeighting.aspx.vb" Inherits="Rating_SubCategoryWeighting" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../Content/Rating.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <article>
        <div class="panel panel-primary">
            <div class="panel-heading">
                Sub Category Weighting
            </div>
            <div class="panel-body">
                <div class="row">
                    <div class="control-label col-xs-3">
                        <asp:Label ID="Label1" runat="server" Text="Entity Type" CssClass="label-font" Visible="false"></asp:Label>
                    </div>
                    <div class="col-xs-3">
                        <asp:DropDownList ID="cmbEntityType" runat="server" AutoPostBack="True" CssClass="form-control input-sm" Visible="false"></asp:DropDownList>
                    </div>
                    <div class="control-label col-xs-3">
                        <asp:Label ID="Label2" runat="server" Text="Category" CssClass="label-font" Visible="false"></asp:Label>
                    </div>
                    <div class="col-xs-3">
                        <asp:DropDownList ID="cmbCategory" runat="server" AutoPostBack="True" CssClass="form-control input-sm" Visible="false"></asp:DropDownList>
                    </div>
                </div>
                <div class="row" style="text-align: center; margin: 0 auto; width: 90%">
                    <asp:Repeater ID="rptCategories" runat="server" OnItemDataBound="rptCategories_ItemDataBound">
                        <HeaderTemplate>
                            <table style="width: 100%; border-spacing: 0;" id="wgtTable">
                                <%--<tr class="Repeater">
                            <th colspan="7" align="left" style="">
                                <asp:Label ID="Label2" runat="server" Text="Category" style=" margin-left:15px;"></asp:Label>
                            </th>
                            <th style="text-align:right;">
                                <asp:Label ID="Label3" runat="server" Text="Weight" style=" margin-right:15px;"></asp:Label>
                            </th>
                        </tr>--%>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr class="Repeater">
                                <th colspan="7" align="left">
                                    <asp:Label ID="lblCategory" runat="server" Font-Names="Calibri"
                                        ForeColor="#ffffff" Text='<%#DataBinder.Eval(Container.DataItem, "category")%>' Style="margin-left: 15px;"></asp:Label>
                                    <asp:Label ID="lblCatID" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "cat_id")%>' Visible="False"></asp:Label>
                                </th>
                                <th colspan="1" align="right" style="text-align: right;">
                                    <asp:Label ID="txtWeight" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "weight")%>' Width="50px"></asp:Label>
                                    %
                                </th>
                            </tr>
                            <tr>
                                <td colspan="8">
                                    <asp:Repeater ID="rptSubCategory" runat="server" OnItemDataBound="rptSubCategory_ItemDataBound">
                                        <HeaderTemplate>
                                            <table style="width: 100%; border-spacing: 0;" id="wgtTable">
                                                <%--<tr class="Repeater">
                                            <th colspan="7" align="left" style="">
                                                <asp:Label ID="Label2" runat="server" Text="Sub Category" style=" margin-left:15px;"></asp:Label>
                                            </th>
                                            <th style="text-align:right;">
                                                <asp:Label ID="Label3" runat="server" Text="Weight" style=" margin-right:15px;"></asp:Label>
                                            </th>
                                        </tr>--%>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <tr class="Repeater">
                                                <td colspan="7" align="left">
                                                    <asp:Label ID="lblSubCategory" runat="server" Font-Names="Calibri"
                                                        ForeColor="#000000" Text='<%#DataBinder.Eval(Container.DataItem, "sub_category")%>' Style="margin-left: 15px;"></asp:Label>
                                                    <asp:Label ID="lblSubCatID" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "subcatID")%>' Visible="False"></asp:Label>
                                                </td>
                                                <td colspan="1" align="right">
                                                    <asp:TextBox ID="txtSubWeight" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "weight")%>' Width="50px"></asp:TextBox>
                                                    %
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                        <AlternatingItemTemplate>
                                            <tr class="Repeater-alt">
                                                <td colspan="7" align="left">
                                                    <asp:Label ID="lblSubCategory" runat="server" Font-Names="Calibri"
                                                        ForeColor="#000000" Text='<%#DataBinder.Eval(Container.DataItem, "sub_category")%>' Style="margin-left: 15px;"></asp:Label>
                                                    <asp:Label ID="lblSubCatID" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "subcatID")%>' Visible="False"></asp:Label>
                                                </td>
                                                <td colspan="1" align="right">
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
                                <td colspan="2" align="left" style="text-align: left;">
                                    <asp:Label ID="lblSubCatError" runat="server" Text="" ForeColor="Red"></asp:Label>
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
                <div class="row" style="margin: 0 auto; display: table;">
                    <div style="text-align: right; width: 95%; font-weight: bold; font-size: large;">
                        <asp:Label ID="lblTotalWeightMessage" runat="server" Text="NB: Total weight must be 100%. Current total is: " Visible="false"></asp:Label>
                        <asp:Label ID="lblTotalWeight" runat="server" Text="" Visible="false"></asp:Label>
                        <asp:Label ID="lblTotalWeightPerc" runat="server" Text="%" Visible="false"></asp:Label>
                    </div>
                    <div style="text-align: center; width: 100%;">
                        <asp:Button ID="btnSaveWeight" runat="server" Text="Save" OnClick="btnSaveWeight_Click" CssClass="btn btn-primary btn-sm" />
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