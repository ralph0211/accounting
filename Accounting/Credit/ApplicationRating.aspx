<%@ Page Language="VB" MasterPageFile="~/Site2.master" AutoEventWireup="false" CodeFile="ApplicationRating.aspx.vb" Inherits="Credit_ApplicationRating" Title="Individual Rating" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="panel panel-primary small">
        <div class="panel-heading">
            <h4 class="panel-title">
                <a>Client Rating</a>
            </h4>
        </div>
        <div class="panel-body">
            <div class="row">
                <div class="col-xs-12 center-block">
                    <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtCategoryRating" runat="server" Visible="false"></asp:TextBox>
                    <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtLoanSearchID" runat="server" Visible="False"></asp:TextBox>
                    <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtCustSearchID" runat="server" Visible="False"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-2 control-label">
                    <asp:Label ID="Label5" runat="server" Text="Loan ID"></asp:Label>
                </div>
                <div class="col-xs-3">
                    <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtLoanID" runat="server"></asp:TextBox>
                </div>
                <div class="col-xs-1">
                    <asp:Button CssClass="btn btn-primary btn-sm" ID="btnSearchLoanID" runat="server" Text="Search" />
                </div>
                <div class="col-xs-2 control-label">
                    <asp:Label ID="Label18" runat="server" Text="Client ID"></asp:Label>
                </div>
                <div class="col-xs-3">
                    <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtClientID" runat="server"></asp:TextBox>
                </div>
                <div class="col-xs-1">
                    <asp:Button CssClass="btn btn-primary btn-sm" ID="btnSearchClientID" runat="server" Text="Search" />
                </div>
            </div>
            <div class="row">
                <div class="col-xs-3 control-label">
                    <asp:Label ID="lblClientName" runat="server"></asp:Label>
                </div>
                <div class="col-xs-3 control-label">
                    <asp:Label ID="lblClientType" runat="server"></asp:Label>
                </div>
                <div class="col-xs-3 control-label">
                    <asp:Label ID="lblLoanType" runat="server"></asp:Label>
                </div>
                <div class="col-xs-3 control-label">
                    <asp:Label ID="lblLoanAmt" runat="server"></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12 center-block">
                    <asp:Repeater ID="rptCategories" runat="server">
                        <HeaderTemplate>
                            <div class="well">
                        </HeaderTemplate>
                        <ItemTemplate>
                            <div class="row">
                                <div class="col-xs-12 label-info">
                                    <asp:Label ID="lblCategory" runat="server"
                                        ForeColor="#FFFFFF" Text='<%#DataBinder.Eval(Container.DataItem, "CATEGORY")%>'></asp:Label>
                                    <asp:Label ID="lblCatID" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "ID")%>' Visible="False"></asp:Label>
                                </div>
                            </div>

                            <asp:Repeater ID="rptQuestions" runat="server" OnItemDataBound="rptQuestions_ItemDatabound">
                                <ItemTemplate>
                                    <div class="row">
                                        <div class="col-xs-6 left">
                                            <asp:Label ID="lblQuestions" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "QUESTION")%>'></asp:Label>
                                            <asp:Label ID="lblQuestionID" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "ID")%>' Visible="False"></asp:Label>
                                        </div>
                                        <div class="col-xs-6">
                                            <asp:RadioButtonList ID="rdbQuestionRating" runat="server" RepeatDirection="Horizontal" CssClass="col-xs-12">
                                            </asp:RadioButtonList>
                                        </div>
                                    </div>
                                </ItemTemplate>
                                <AlternatingItemTemplate>
                                    <div class="row">
                                        <div class="col-xs-6 left">
                                            <asp:Label ID="lblQuestions" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "QUESTION")%>'></asp:Label>
                                            <asp:Label ID="lblQuestionID" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "ID")%>' Visible="False"></asp:Label>
                                        </div>
                                        <div class="col-xs-6">
                                            <asp:RadioButtonList ID="rdbQuestionRating" runat="server" RepeatDirection="Horizontal" CssClass="col-xs-12">
                                            </asp:RadioButtonList>
                                        </div>
                                    </div>
                                </AlternatingItemTemplate>
                            </asp:Repeater>

                            <div class="row">
                                <div class="col-xs-12 center-block">
                                    <asp:Label ID="lblActRating" runat="server" Text=""></asp:Label>
                                </div>
                            </div>
                        </ItemTemplate>
                        <FooterTemplate>
                            </div>
                        </FooterTemplate>
                    </asp:Repeater>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12 text-center">
                    <asp:Label ID="lblOverallRatingText" runat="server" Text="Overall Rating: "
                        Font-Size="Large" Visible="False"></asp:Label>
                    <asp:Label ID="lblOverallRating" runat="server" Font-Size="Large"></asp:Label>
                </div>
            </div>
            <div class="row" style="height: 10px;"></div>
            <div id="divDecision" runat="server">
                <asp:Repeater ID="repSystemDecision" runat="server">
                    <HeaderTemplate>
                        <div class="row label-info">
                            <div class="col-xs-12 control-label">
                                System Decision
                            </div>
                        </div>
                        <div class="row alert-info">
                            <div class="col-xs-1 control-label text-left">
                                Rating
                            </div>
                            <div class="col-xs-1 control-label text-left">
                                Grade
                            </div>
                            <div class="col-xs-2 control-label text-left">
                                S&P
                            </div>
                            <div class="col-xs-2 control-label text-left">
                                Moody
                            </div>
                            <div class="col-xs-2 control-label text-left">
                                Recommended %
                            </div>
                            <div class="col-xs-3 control-label text-left">
                                Description
                            </div>
                        </div>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <div class="row" id="decRow" runat="server">
                            <div class="col-xs-1 control-label text-left">
                                <asp:Label ID="lblRating" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "rating")%>'></asp:Label>
                            </div>
                            <div class="col-xs-1 control-label text-left">
                                <asp:Label ID="lblGrade" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "letter_class")%>'></asp:Label>
                            </div>
                            <div class="col-xs-2 control-label text-left">
                                <asp:Label ID="lblSP" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "S_P")%>'></asp:Label>
                            </div>
                            <div class="col-xs-2 control-label text-left">
                                <asp:Label ID="lblMoody" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "moody")%>'></asp:Label>
                            </div>
                            <div class="col-xs-2 control-label text-left">
                                <asp:Label ID="lblRecommend" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "recommended")%>'></asp:Label>
                            </div>
                            <div class="col-xs-3 control-label text-left">
                                <asp:Label ID="lblDecision" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "class")%>'></asp:Label>
                            </div>
                        </div>
                    </ItemTemplate>
                    <%--<FooterTemplate>
                        <hr style="color: black;" />
                        <div class="row" id="footRow" runat="server">
                            <div class="col-xs-7 control-label">
                                <asp:Label ID="lblVariableTot" runat="server" Text='Overall Decision' Font-Size="large"></asp:Label>
                            </div>
                            <div class="col-xs-1 control-label">
                                <asp:Label ID="lblScaleTot" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "dec_scale")%>' Font-Size="large"></asp:Label>
                            </div>
                            <div class="col-xs-4 control-label">
                                <asp:Label ID="lblDecisionTot" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "dec_interpretation")%>' Font-Size="large"></asp:Label>
                            </div>
                        </div>
                    </FooterTemplate>--%>
                </asp:Repeater>
            </div>
            <div class="row" style="height: 20px;"></div>
            <div class="row">
                <div class="col-xs-12 text-center">
                    <asp:Label ID="lblWhoRated" runat="server" Text=""></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12 text-center">
                    <asp:Button CssClass="btn btn-primary btn-sm" ID="btnSaveRating" runat="server" Text="Calculate Rating"
                        Visible="False" />
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12 text-center">
                    <asp:Label ID="lblViewReport" runat="server" Text=""></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12 text-center">
                    <asp:Label ID="lblReturn" runat="server"></asp:Label>
                </div>
            </div>
        </div>
    </div>
</asp:Content>