<%@ Page Title="Pricing Sheet" Language="VB" MasterPageFile="~/Site2.master" AutoEventWireup="false" CodeFile="PricingSheet.aspx.vb" Inherits="Rating_PricingSheet" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <article>
        <div class="panel panel-primary">
            <div class="panel-heading">
                Pricing Sheet
            </div>
            <div class="panel-body small">
                <div class="row">
                    <div class="col-md-2 col-xs-2">
                        <label id="Label1" runat="server" class="control-label">Entity Type</label>
                    </div>
                    <div class="col-md-4 col-xs-4">
                        <asp:DropDownList ID="cmbEntityType" runat="server" AutoPostBack="true" AppendDataBoundItems="true" OnSelectedIndexChanged="cmbEntityType_SelectedIndexChanged" CssClass="form-control input-sm"></asp:DropDownList>
                    </div>
                </div>
                <div class="row" id="rangeInput" runat="server">
                    <div class="col-md-2 col-xs-2">
                        <label id="Label2" runat="server" class="control-label">Lower Range</label>
                    </div>
                    <div class="col-md-4 col-xs-4">
                        <asp:TextBox ID="txtLowerRange" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                    </div>
                    <div class="col-md-2 col-xs-2">
                        <label id="Label3" runat="server" class="control-label">Upper Range</label>
                    </div>
                    <div class="col-md-4 col-xs-4">
                        <asp:TextBox ID="txtUpperRange" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-2 col-xs-2">
                        <label class="control-label">Descriptive Class</label>
                    </div>
                    <div class="col-md-4 col-xs-4">
                        <asp:TextBox ID="txtClass" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                    </div>
                    <div class="col-md-2 col-xs-2">
                        <label class="control-label">Grade</label>
                    </div>
                    <div class="col-md-4 col-xs-4">
                        <asp:TextBox ID="txtLetterClass" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-2 col-xs-2">
                        <label class="control-label">Premium</label>
                    </div>
                    <div class="col-md-4 col-xs-4">
                        <asp:TextBox ID="txtPremium" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                    </div>
                    <div class="col-md-2 col-xs-2">
                        <label class="control-label">S&P Rating</label>
                    </div>
                    <div class="col-md-4 col-xs-4">
                        <asp:TextBox ID="txtSPRating" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-2 col-xs-2">
                        <label class="control-label">Moody's Rating</label>
                    </div>
                    <div class="col-md-4 col-xs-4">
                        <asp:TextBox ID="txtMoodyRating" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                    </div>
                    <div class="col-md-2 col-xs-2">
                        <label class="control-label">Recommended Percentage</label>
                    </div>
                    <div class="col-md-4 col-xs-4">
                        <asp:TextBox ID="txtRecPerc" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-2 col-xs-2">
                        <asp:CheckBox ID="chkRejectApp" Text="Reject Application" runat="server" CssClass="control-label" />
                    </div>
                </div>
                <div class="text-center row">
                    <asp:Button ID="btnAddClass" runat="server" Text="Add Class" CssClass="btn btn-primary" />
                </div>
                <div class="hr-separator">
                </div>
                <div id="jqxgrid" class="center-block row">
                    <div style="margin: 0 auto;">
                        <asp:GridView ID="grdClass" runat="server" AutoGenerateColumns="False" HorizontalAlign="center">
                            <AlternatingRowStyle CssClass="altrowstyle" HorizontalAlign="left" />
                            <HeaderStyle CssClass="headerstyle" HorizontalAlign="left" />
                            <RowStyle CssClass="rowstyle" HorizontalAlign="left" />
                            <Columns>
                                <asp:TemplateField ShowHeader="False" Visible="false">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkBtnDel" runat="server" CausesValidation="False"
                                            CommandName="Delete" OnClientClick="return isDelete();" Text="Delete"></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ShowHeader="False">
                                    <EditItemTemplate>
                                        <asp:LinkButton ID="lnkBtnUpd" runat="server" CausesValidation="False"
                                            CommandName="Update" Text="Update"></asp:LinkButton>
                                        &nbsp;<asp:LinkButton ID="lnkBtnCan" runat="server" CausesValidation="False"
                                            CommandName="Cancel" Text="Cancel"></asp:LinkButton>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkBtnEdt" runat="server" CausesValidation="False"
                                            CommandName="Edit" Text="Edit"></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Class ID" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblClassId0" runat="server" Text='<%#Eval("id")%>'></asp:Label>
                                        <asp:TextBox ID="txtClassId0" runat="server" Text='<%#Eval("id")%>'
                                            Visible="False"></asp:TextBox>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:Label ID="lblClassId0Edit" runat="server" Text='<%#Eval("id")%>'></asp:Label>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Description">
                                    <ItemTemplate>
                                        <asp:Label ID="lblClass0" runat="server" Text='<%#Eval("class")%>'></asp:Label>
                                        <asp:TextBox ID="txtClass0" runat="server" Text='<%#Eval("class")%>'
                                            Visible="False"></asp:TextBox>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtClass0Edit" runat="server"
                                            Text='<%#Eval("class")%>'></asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Grade">
                                    <ItemTemplate>
                                        <asp:Label ID="lblLetterClass0" runat="server" Text='<%#Eval("letter_class")%>'></asp:Label>
                                        <asp:TextBox ID="txtLetterClass0" runat="server" Text='<%#Eval("letter_class")%>'
                                            Visible="False"></asp:TextBox>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtLetterClass0Edit" runat="server" Width="40px"
                                            Text='<%#Eval("letter_class")%>'></asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="S&P">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSP0" runat="server" Text='<%#Eval("s_p")%>'></asp:Label>
                                        <asp:TextBox ID="txtSP0" runat="server" Text='<%#Eval("s_p")%>'
                                            Visible="False"></asp:TextBox>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtSP0Edit" runat="server" Width="80px"
                                            Text='<%#Eval("s_p")%>'></asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Moody's">
                                    <ItemTemplate>
                                        <asp:Label ID="lblMoody0" runat="server" Text='<%#Eval("moody")%>'></asp:Label>
                                        <asp:TextBox ID="txtMoody0" runat="server" Text='<%#Eval("moody")%>'
                                            Visible="False"></asp:TextBox>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtMoody0Edit" runat="server" Width="80px"
                                            Text='<%#Eval("moody")%>'></asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Lower Value">
                                    <ItemTemplate>
                                        <asp:Label ID="lblLowerValue0" runat="server" Text='<%#Eval("lower_range")%>'></asp:Label>
                                        <asp:TextBox ID="txtLowerValue0" runat="server" Text='<%#Eval("lower_range")%>'
                                            Visible="False"></asp:TextBox>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtLowerValue0Edit" runat="server" Width="40px"
                                            Text='<%#Eval("lower_range")%>'></asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Upper Value">
                                    <ItemTemplate>
                                        <asp:Label ID="lblUpperValue0" runat="server" Text='<%#Eval("upper_range")%>'></asp:Label>
                                        <asp:TextBox ID="txtUpperValue0" runat="server" Text='<%#Eval("upper_range")%>'
                                            Visible="False"></asp:TextBox>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtUpperValue0Edit" runat="server" Width="40px"
                                            Text='<%#Eval("upper_range")%>'></asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Premium">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPremium0" runat="server" Text='<%#Eval("premium")%>'></asp:Label>
                                        <asp:TextBox ID="txtPremium0" runat="server" Text='<%#Eval("premium")%>'
                                            Visible="False"></asp:TextBox>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtPremium0Edit" runat="server" Width="40px"
                                            Text='<%#Eval("premium")%>'></asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Recommended %">
                                    <ItemTemplate>
                                        <asp:Label ID="lblRecommend0" runat="server" Text='<%#Eval("recommended")%>'></asp:Label>
                                        <asp:TextBox ID="txtRecommend0" runat="server" Text='<%#Eval("recommended")%>'
                                            Visible="False"></asp:TextBox>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtRecommend0Edit" runat="server" Width="40px"
                                            Text='<%#Eval("recommended")%>'></asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Reject">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkReject0" runat="server" Checked='<%#Eval("reject")%>' Enabled="false" />
                                        <asp:TextBox ID="txtReject0" runat="server" Text='<%#Eval("reject")%>'
                                            Visible="False"></asp:TextBox>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:CheckBox ID="chkReject0Edit" runat="server" Checked='<%#Eval("reject")%>' />
                                    </EditItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </article>
</asp:Content>