<%@ Page Title="Rating Variables" Language="VB" MasterPageFile="~/Site2.master" AutoEventWireup="false" CodeFile="RatingVariables.aspx.vb" Inherits="Rating_RatingVariables" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <article>
        <div class="panel panel-primary">
            <div class="panel-heading">
                Scoring Variables
            </div>
            <div class="panel-body">
                <div class="row">
                    <div class="col-md-2 col-xs-2">
                        <label id="Label1" runat="server" class="control-label">Entity Type</label>
                    </div>
                    <div class="col-md-4 col-xs-4">
                        <asp:DropDownList ID="cmbEntityType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cmbEntityType_SelectedIndexChanged" CssClass="form-control input-sm"></asp:DropDownList>
                    </div>
                    <div class="col-md-2 col-xs-2">
                        <label class="control-label">Rating Category</label>
                    </div>
                    <div class="col-md-4 col-xs-4">
                        <asp:DropDownList ID="cmbRatingCategory" runat="server" AutoPostBack="true" AppendDataBoundItems="true" OnSelectedIndexChanged="cmbRatingCategory_SelectedIndexChanged" CssClass="form-control input-sm"></asp:DropDownList>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-2 col-xs-2">
                        <label class="control-label">Sub Category</label>
                    </div>
                    <div class="col-md-4 col-xs-4">
                        <asp:DropDownList ID="cmbRatingSubCategory" runat="server" AutoPostBack="true" AppendDataBoundItems="true" CssClass="form-control input-sm"></asp:DropDownList>
                    </div>
                    <div class="col-md-2 col-xs-2">
                        <label class="control-label">Rating Variable</label>
                    </div>
                    <div class="col-md-4 col-xs-4">
                        <asp:TextBox ID="txtRatingVariable" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-2 col-xs-2">
                        <label class="control-label">Value Type</label>
                    </div>
                    <div class="col-md-4 col-xs-4">
                        <asp:RadioButtonList ID="rdbValueType" runat="server" CssClass="control-label col-xs-12" RepeatDirection="horizontal">
                            <asp:ListItem Text="Range" Value="R"></asp:ListItem>
                            <asp:ListItem Text="Absolute Value" Value="A"></asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                    <div class="col-md-2 col-xs-2">
                        <asp:Button ID="btnAddVariable" runat="server" Text="Add" CssClass="btn btn-primary btn-sm" />
                    </div>
                    <div class="col-md-4 col-xs-4">
                    </div>
                </div>
                <div class="row">
                </div>
                <div id="jqxgrid" class="full-center">
                    <div style="margin: 0 auto; min-width: 200px;">
                        <asp:GridView ID="grdVariable" runat="server" AutoGenerateColumns="False" HorizontalAlign="center">
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
                                        <asp:Label ID="lblClassId0" runat="server" Text='<%#Eval("var_id")%>'></asp:Label>
                                        <asp:TextBox ID="txtClassId0" runat="server" Text='<%#Eval("var_id")%>'
                                            Visible="False"></asp:TextBox>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:Label ID="lblClassId0Edit" runat="server" Text='<%#Eval("var_id")%>'></asp:Label>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Category">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCategory0" runat="server" Text='<%#Eval("category")%>'></asp:Label>
                                        <asp:TextBox ID="txtCategory0" runat="server" Text='<%#Eval("category")%>'
                                            Visible="False"></asp:TextBox>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtCategory0Edit" runat="server" Visible="false"
                                            Text='<%#Eval("category_id")%>'></asp:TextBox>
                                        <asp:DropDownList ID="cmbCategory0Edit" runat="server" AutoPostBack="true" OnSelectedIndexChanged="cmbCategory0Edit_SelectedIndexChanged"></asp:DropDownList>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Sub Category">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSubCategory0" runat="server" Text='<%#Eval("sub_category")%>'></asp:Label>
                                        <asp:TextBox ID="txtSubCategory0" runat="server" Text='<%#Eval("sub_category")%>'
                                            Visible="False"></asp:TextBox>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtSubCategory0Edit" runat="server" Visible="false"
                                            Text='<%#Eval("subcat_id")%>'></asp:TextBox>
                                        <asp:DropDownList ID="cmbSubCategory0Edit" runat="server"></asp:DropDownList>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Question">
                                    <ItemTemplate>
                                        <asp:Label ID="lblQuestion0" runat="server" Text='<%#Eval("question")%>'></asp:Label>
                                        <asp:TextBox ID="txtQuestion0" runat="server" Text='<%#Eval("question")%>'
                                            Visible="False"></asp:TextBox>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtQuestion0Edit" runat="server"
                                            Text='<%#Eval("question")%>'></asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Value Type">
                                    <ItemTemplate>
                                        <asp:Label ID="lblvalType0" runat="server" Text='<%#Eval("valType")%>'></asp:Label>
                                        <asp:TextBox ID="txtvalType0" runat="server" Text='<%#Eval("valType")%>'
                                            Visible="False"></asp:TextBox>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtvalType0Edit" runat="server" Visible="false"
                                            Text='<%#Eval("value_type")%>'></asp:TextBox>
                                        <asp:DropDownList ID="cmbvalType0Edit" runat="server" Width="150px">
                                            <asp:ListItem Text="" Value=""></asp:ListItem>
                                            <asp:ListItem Text="Range" Value="R"></asp:ListItem>
                                            <asp:ListItem Text="Absolute Value" Value="A"></asp:ListItem>
                                        </asp:DropDownList>
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