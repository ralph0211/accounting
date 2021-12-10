<%@ Page Title="Indicator Ranges" Language="VB" MasterPageFile="~/Site2.master" AutoEventWireup="false" CodeFile="VariableRanges.aspx.vb" Inherits="Rating_VariableRanges" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <article>
        <div class="panel panel-primary">
            <div class="panel-heading">
                Rating Values
            </div>
            <div class="panel-body small">
                <div class="row">
                    <div class="col-md-2 col-xs-2">
                        <label id="Label1" class="control-label">Entity Type</label>
                    </div>
                    <div class="col-xs-4">
                        <asp:DropDownList ID="cmbEntityType" runat="server" AutoPostBack="true" AppendDataBoundItems="true" OnSelectedIndexChanged="cmbEntityType_SelectedIndexChanged" CssClass="form-control input-sm"></asp:DropDownList>
                    </div>
                    <div class="col-md-2 col-xs-2">
                        <label class="control-label">Rating Category</label>
                    </div>
                    <div class="col-xs-4">
                        <asp:DropDownList ID="cmbRatingCategory" runat="server" AutoPostBack="true" AppendDataBoundItems="true" OnSelectedIndexChanged="cmbRatingCategory_SelectedIndexChanged" CssClass="form-control input-sm"></asp:DropDownList>
                    </div>
                </div>
                <div class="row" runat="server">
                    <div class="col-md-2 col-xs-2">
                        <label class="control-label">Rating Variable</label>
                    </div>
                    <div class="col-xs-4">
                        <asp:DropDownList ID="cmbRatingVariable" runat="server" AutoPostBack="true" AppendDataBoundItems="true" OnSelectedIndexChanged="cmbRatingVariable_SelectedIndexChanged" CssClass="form-control input-sm"></asp:DropDownList>
                    </div>
                </div>
                <div class="row" id="rangeInput" runat="server">
                    <div class="col-md-2 col-xs-2">
                        <label id="Label2" runat="server" class="control-label">Lower Range</label>
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox ID="txtLowerRange" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                    </div>
                    <div class="col-md-2 col-xs-2">
                        <label id="Label3" runat="server" class="control-label">Upper Range</label>
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox ID="txtUpperRange" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-2 col-xs-2" id="valLabel" runat="server">
                        <label class="control-label">Value</label>
                    </div>
                    <div class="col-md-4 col-xs-4" id="valText" runat="server">
                        <asp:TextBox ID="txtAbsValue" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                    </div>
                    <div class="col-md-2 col-xs-2">
                        <label class="control-label">Score</label>
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox ID="txtScore" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="control-label col-xs-2">
                        Scale
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox ID="txtScale" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                    </div>
                    <div class="control-label col-xs-2">
                        Interpretation/Comment
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox ID="txtComment" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                    </div>
                </div>
                <div class="row" style="text-align: center;">
                    <asp:Button ID="btnAddRange" runat="server" Text="Add Range" CssClass="btn btn-primary" />
                </div>
                <div class="hr-separator">
                    <asp:TextBox ID="txtValueType" runat="server" Visible="false" CssClass="form-control input-sm"></asp:TextBox>
                </div>
                <div id="jqxgrid" class="full-center">
                    <div style="margin: 0 auto; min-width: 200px;">
                        <asp:GridView ID="grdVariable" runat="server" AutoGenerateColumns="False" HorizontalAlign="center">
                            <AlternatingRowStyle CssClass="altrowstyle" />
                            <HeaderStyle CssClass="headerstyle" />
                            <RowStyle CssClass="rowstyle" />
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
                                <asp:TemplateField HeaderText="Range ID" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblRangeId0" runat="server" Text='<%#Eval("range_id")%>'></asp:Label>
                                        <asp:TextBox ID="txtRangeId0" runat="server" Text='<%#Eval("range_id")%>'
                                            Visible="False"></asp:TextBox>
                                        <asp:TextBox ID="txtValueTypeId0" runat="server" Text='<%#Eval("value_type")%>'
                                            Visible="False"></asp:TextBox>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:Label ID="lblRangeId0Edit" runat="server" Text='<%#Eval("range_id")%>'></asp:Label>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Question">
                                    <ItemTemplate>
                                        <asp:Label ID="lblQuestion0" runat="server" Text='<%#Eval("description")%>'></asp:Label>
                                        <asp:TextBox ID="txtQuestion0" runat="server" Text='<%#Eval("description")%>'
                                            Visible="False"></asp:TextBox>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:Label ID="txtQuestion0Edit" runat="server"
                                            Text='<%#Eval("description")%>'></asp:Label>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Lower Value">
                                    <ItemTemplate>
                                        <asp:Label ID="lblLowerValue0" runat="server" Text='<%#Eval("lower_range")%>'></asp:Label>
                                        <asp:TextBox ID="txtLowerValue0" runat="server" Text='<%#Eval("lower_range")%>'
                                            Visible="False"></asp:TextBox>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtLowerValue0Edit" runat="server"
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
                                <asp:TemplateField HeaderText="Score">
                                    <ItemTemplate>
                                        <asp:Label ID="lblScore0" runat="server" Text='<%#Eval("score")%>'></asp:Label>
                                        <asp:TextBox ID="txtScore0" runat="server" Text='<%#Eval("score")%>'
                                            Visible="False"></asp:TextBox>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtScore0Edit" runat="server" Width="40px"
                                            Text='<%#Eval("score")%>'></asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Scale">
                                    <ItemTemplate>
                                        <asp:Label ID="lblScale0" runat="server" Text='<%#Eval("scale")%>'></asp:Label>
                                        <asp:TextBox ID="txtScale0" runat="server" Text='<%#Eval("scale")%>'
                                            Visible="False"></asp:TextBox>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtScale0Edit" runat="server" Width="40px"
                                            Text='<%#Eval("scale")%>'></asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Comment">
                                    <ItemTemplate>
                                        <asp:Label ID="lblComment0" runat="server" Text='<%#Eval("comment")%>'></asp:Label>
                                        <asp:TextBox ID="txtComment0" runat="server" Text='<%#Eval("comment")%>'
                                            Visible="False"></asp:TextBox>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtComment0Edit" runat="server"
                                            Text='<%#Eval("comment")%>'></asp:TextBox>
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