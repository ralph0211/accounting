<%@ Page Title="Rating Sub-Categories" Language="VB" MasterPageFile="~/Site2.master" AutoEventWireup="false" CodeFile="RatingSubCategories.aspx.vb" Inherits="Rating_RatingSubCategories" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <article>
        <div class="panel panel-primary">
            <div class="panel-heading">
                Scoring Sub-Categories
            </div>
            <div class="panel-body small">
                <div class="row">
                    <div class="col-md-2 col-xs-2">
                        <label id="Label1" runat="server" class="control-label">Entity Type</label>
                    </div>
                    <div class="col-md-4 col-xs-4">
                        <asp:DropDownList ID="cmbEntityType" runat="server" AutoPostBack="true" CssClass="form-control input-sm"></asp:DropDownList>
                    </div>
                    <div class="col-md-2 col-xs-2">
                        <label class="control-label">Rating Category</label>
                    </div>
                    <div class="col-md-4 col-xs-4">
                        <asp:DropDownList ID="cmbRatingCategory" runat="server" AutoPostBack="true" CssClass="form-control input-sm"></asp:DropDownList>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-2 col-xs-2">
                        <label class="control-label">Rating Sub-Category</label>
                    </div>
                    <div class="col-md-4 col-xs-4">
                        <asp:TextBox ID="txtRatingSubCategory" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                    </div>
                    <div class="col-md-2 col-xs-2"></div>
                    <div class="col-md-4 col-xs-4"></div>
                </div>
                <div class="text-center row">
                    <asp:Button ID="btnAddCategory" runat="server" Text="Add Sub Category" CssClass="btn btn-primary" />
                </div>
                <div class="row">
                </div>
                <div id="jqxgrid" class="full-center">
                    <div style="margin: 0 auto; min-width: 200px;">
                        <asp:GridView ID="grdSubCategory" runat="server" AutoGenerateColumns="False" HorizontalAlign="center">
                            <AlternatingRowStyle CssClass="altrowstyle" />
                            <HeaderStyle CssClass="headerstyle" />
                            <RowStyle CssClass="rowstyle" />
                            <Columns>
                                <asp:TemplateField ShowHeader="False">
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
                                        <asp:Label ID="lblClassId0" runat="server" Text='<%#Eval("sub_id")%>'></asp:Label>
                                        <asp:TextBox ID="txtClassId0" runat="server" Text='<%#Eval("sub_id")%>'
                                            Visible="False"></asp:TextBox>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:Label ID="lblClassId0Edit" runat="server" Text='<%#Eval("sub_id")%>'></asp:Label>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Category">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCategory0" runat="server" Text='<%#Eval("description")%>'></asp:Label>
                                        <asp:TextBox ID="txtCategory0" runat="server" Text='<%#Eval("description")%>'
                                            Visible="False"></asp:TextBox>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtCategory0Edit" runat="server" Visible="false"
                                            Text='<%#Eval("category_id")%>'></asp:TextBox>
                                        <asp:DropDownList ID="cmbCategory0Edit" runat="server"></asp:DropDownList>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Sub Category">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSubCategory0" runat="server" Text='<%#Eval("sub_category")%>'></asp:Label>
                                        <asp:TextBox ID="txtSubCategory0" runat="server" Text='<%#Eval("sub_category")%>'
                                            Visible="False"></asp:TextBox>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtSubCategory0Edit" runat="server"
                                            Text='<%#Eval("sub_category")%>'></asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Enabled">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkActive0" runat="server" Checked='<%#Eval("activated")%>' Enabled="false" />
                                        <asp:TextBox ID="txtActive0" runat="server" Text='<%#Eval("activated")%>'
                                            Visible="False"></asp:TextBox>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:CheckBox ID="chkActive0Edit" runat="server" Checked='<%#Eval("activated")%>' />
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