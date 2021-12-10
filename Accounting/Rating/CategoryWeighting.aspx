<%@ Page Title="Category Weighting" Language="VB" MasterPageFile="~/Site2.master" AutoEventWireup="false" CodeFile="CategoryWeighting.aspx.vb" Inherits="Rating_CategoryWeighting" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../Content/Rating.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <article>
        <div class="panel panel-primary">
            <div class="panel-heading">
                Category Weighting
            </div>
            <div class="panel-body">
                <div class="horizon">
                    <div class="left-label">
                        <asp:Label ID="Label1" runat="server" Text="Entity Type" CssClass="label-font"></asp:Label>
                    </div>
                    <div class="right-input">
                        <asp:DropDownList ID="cmbEntityType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cmbEntityType_SelectedIndexChanged"></asp:DropDownList>
                    </div>
                </div>
                <div class="horizon" style="text-align: center; margin: 0 auto; width: 90%">
                    <asp:Repeater ID="rptCategories" runat="server">
                        <HeaderTemplate>
                            <table style="width: 100%; border-spacing: 0;" id="wgtTable">
                                <tr class="Repeater">
                                    <th colspan="7" align="left" style="">
                                        <asp:Label ID="Label2" runat="server" Text="Category" Style="margin-left: 15px;"></asp:Label>
                                    </th>
                                    <th style="text-align: right;">
                                        <asp:Label ID="Label3" runat="server" Text="Weight" Style="margin-right: 15px;"></asp:Label>
                                    </th>
                                </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr class="Repeater">
                                <td colspan="7" align="left">
                                    <asp:Label ID="lblCategory" runat="server" Font-Names="Calibri"
                                        ForeColor="#000000" Text='<%#DataBinder.Eval(Container.DataItem, "category")%>' Style="margin-left: 15px;"></asp:Label>
                                    <asp:Label ID="lblCatID" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "cat_id")%>' Visible="False"></asp:Label>
                                </td>
                                <td colspan="1" align="right">
                                    <asp:TextBox ID="txtWeight" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "weight")%>' Width="50px" OnChange="calcSum()"></asp:TextBox>
                                    %
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4">
                                    <asp:Label ID="lblActRating" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                        </ItemTemplate>
                        <AlternatingItemTemplate>
                            <tr class="Repeater-alt">
                                <td colspan="7" align="left">
                                    <asp:Label ID="lblCategory" runat="server" Font-Names="Calibri"
                                        ForeColor="#000000" Text='<%#DataBinder.Eval(Container.DataItem, "category")%>' Style="margin-left: 15px;"></asp:Label>
                                    <asp:Label ID="lblCatID" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "cat_id")%>' Visible="False"></asp:Label>
                                </td>
                                <td colspan="1" align="right">
                                    <asp:TextBox ID="txtWeight" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "weight")%>' Width="50px" OnChange="calcSum()"></asp:TextBox>
                                    %
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4">
                                    <asp:Label ID="lblActRating" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                        </AlternatingItemTemplate>
                        <FooterTemplate>
                            <tr>
                                <td></td>
                            </tr>
                            </table>
                        </FooterTemplate>
                    </asp:Repeater>
                </div>
                <div class="horizon" style="margin: 0 auto; display: table;">
                    <div style="text-align: right; width: 95%; font-weight: bold; font-size: large;">
                        <asp:Label ID="lblTotalWeightMessage" runat="server" Text="NB: Total weight must be 100%. Current total is: "></asp:Label>
                        <asp:Label ID="lblTotalWeight" runat="server" Text=""></asp:Label>
                        <asp:Label ID="lblTotalWeightPerc" runat="server" Text="%"></asp:Label>
                    </div>
                    <div style="text-align: center; width: 100%;">
                        <asp:Button ID="btnSaveWeight" runat="server" Text="Save" CssClass="btn btn-primary" />
                    </div>
                </div>
            </div>
        </div>
    </article>
    <%--<script src="../Scripts/jquery-2.1.3.min.js"></script>--%>
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