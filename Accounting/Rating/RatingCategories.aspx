<%@ Page Title="Rating Categories" Language="VB" MasterPageFile="~/Site2.master" AutoEventWireup="false" CodeFile="RatingCategories.aspx.vb" Inherits="Rating_RatingCategories" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <article>
        <div class="panel panel-primary small">
            <div class="panel-heading">
                <div class="panel-title">
                    Scoring Categories
                </div>
            </div>
            <div class="panel-body">
                <div class="row">
                    <div class="col-md-2 col-xs-2">
                        <label id="Label1" runat="server" class="control-label">Entity Type</label>
                    </div>
                    <div class="col-md-4 col-xs-4">
                        <asp:DropDownList ID="cmbEntityType" runat="server" CssClass="form-control input-sm"></asp:DropDownList>
                    </div>
                    <div class="col-md-2 col-xs-2">
                        <label class="control-label">Rating Category</label>
                    </div>
                    <div class="col-md-4 col-xs-4">
                        <asp:TextBox ID="txtRatingCategory" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                    </div>
                </div>
                <div class="row text-center">
                    <asp:Button ID="btnAddCategory" runat="server" Text="Add Category" CssClass="btn btn-primary btn-sm" />
                </div>
                <div class="row">
                </div>
                <div id="jqxgrid" class="row center-block">
                    <div style="margin: 0 auto; min-width: 200px;">
                        <asp:GridView ID="grdCategory" runat="server" AutoGenerateColumns="False" HorizontalAlign="center">
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
                                <asp:TemplateField HeaderText="Category ID" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCategoryId0" runat="server" Text='<%#Eval("cat_id")%>'></asp:Label>
                                        <asp:TextBox ID="txtCategoryId0" runat="server" Text='<%#Eval("cat_id")%>'
                                            Visible="False"></asp:TextBox>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:Label ID="lblCategoryId0Edit" runat="server" Text='<%#Eval("cat_id")%>'></asp:Label>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Client Type">
                                    <ItemTemplate>
                                        <asp:Label ID="lblClientType0" runat="server" Text='<%#Eval("CLIENT_TYPE")%>'></asp:Label>
                                        <asp:TextBox ID="txtClientType0" runat="server" Text='<%#Eval("CLIENT_TYPE")%>'
                                            Visible="False"></asp:TextBox>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:Label ID="txtClientType0Edit" runat="server" Visible="false"
                                            Text='<%#Eval("CLIENT_TYPE")%>'></asp:Label>
                                        <asp:Label ID="lblClientType0Edit" runat="server"
                                            Text='<%#Eval("entity_id")%>' Visible="False"></asp:Label>
                                        <asp:DropDownList ID="cmbClientTypeEdit" runat="server"
                                            AppendDataBoundItems="True">
                                        </asp:DropDownList>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Category">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCategory0" runat="server" Text='<%#Eval("description")%>'></asp:Label>
                                        <asp:TextBox ID="txtCategory0" runat="server" Text='<%#Eval("description")%>'
                                            Visible="False"></asp:TextBox>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtCategory0Edit" runat="server"
                                            Text='<%#Eval("description")%>'></asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Enabled">
                                    <ItemTemplate>
                                        <asp:Label ID="lblActive0" runat="server" Text='<%#Eval("active")%>' Visible="false"></asp:Label>
                                        <asp:CheckBox ID="chkActive0" runat="server" Checked='<%#Eval("active")%>' Enabled="false" />
                                        <asp:TextBox ID="txtActive0" runat="server" Text='<%#Eval("active")%>'
                                            Visible="False"></asp:TextBox>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtActive0Edit" runat="server"
                                            Text='<%#Eval("active")%>' Visible="false"></asp:TextBox>
                                        <asp:CheckBox ID="chkActive0Edit" runat="server" Checked='<%#Eval("active")%>' />
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