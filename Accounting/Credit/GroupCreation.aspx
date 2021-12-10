<%@ Page Title="Group Account Creation" Language="VB" MasterPageFile="~/Site2.master" AutoEventWireup="false" CodeFile="GroupCreation.aspx.vb" Inherits="Credit_GroupCreation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="panel panel-primary small">
        <div class="panel-heading">
            <h4 class="panel-title">
                Group Account Creation
            </h4>
        </div>
        <div class="panel-body">
                <div class="row">
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="Label34" runat="server" Text="Group Name"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtGrpName" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="reqGrpName" runat="server" ErrorMessage="Group name is required" ValidationGroup="valGrpName" Display="Dynamic" ControlToValidate="txtGrpName"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-xs-2">
                        <%--<asp:Button CssClass="btn btn-primary btn-sm" ID="btnGrpAddGroup" runat="server" Text="Add Group" ValidationGroup="valGrpName" />--%>
                    </div>
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="lbl" runat="server" Text="Group Account No."></asp:Label>
                        <asp:Label ID="lblGrpAccNo" runat="server" Text=""></asp:Label>
                    </div>
                </div>
                <div class="row label-info">
                    <div class="col-xs-12 control-label">
                        <asp:Label ID="Label32" runat="server" Text="Add Group Members"></asp:Label>
                    </div>
                </div>
                <div class="row alert-danger">
                    <div class="col-xs-12 control-label">
                        <asp:Label ID="lblGrpMemberCount" runat="server" Text=""></asp:Label>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-2 control-label">
                        Chairperson</div>
                    <div class="col-xs-4">
                        <asp:DropDownList CssClass="col-xs-12 form-control input-sm chosen" ID="cmbChairperson" runat="server">
                        </asp:DropDownList>
                    </div>
                    <div class="col-xs-2 control-label">
                        Group Members
                    </div>
                    <div class="col-xs-4">
                        <asp:ListBox CssClass="col-xs-12 form-control input-sm chosen-multi" ID="cmbGrpMembers" runat="server" SelectionMode="Multiple"></asp:ListBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-12 text-center">
                        <asp:Button CssClass="btn btn-primary btn-sm" ID="btnGrpDeclAdd" runat="server" Text="Save Group Membership" UseSubmitBehavior="false" />
                    </div>
                </div>
                <div class="" id="divGrpCount" runat="server">
                    <div class="col-xs-12 control-label">
                        <asp:Label ID="lblCurrGrpMembers" runat="server" Text=""></asp:Label>
                    </div>
                </div>
                <div class="row label-info">
                    <div class="col-xs-12 control-label">
                        Group Documentation
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="Label93" runat="server" Text="Document Description"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtDocDesc" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-xs-4">
                        <asp:FileUpload ID="filAttachApp" runat="server" />
                    </div>
                    <div class="col-xs-1">
                        <asp:Button CssClass="btn btn-primary btn-sm" ID="btnUploadApp" runat="server" Text="Upload" />
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-12">
                        <asp:GridView ID="grdDocuments" runat="server" HorizontalAlign="Center" AutoGenerateColumns="False" EnableModelValidation="True" Width="90%">
                            <AlternatingRowStyle CssClass="altrowstyle" />
                            <Columns>
                                <asp:TemplateField HeaderText="Delete">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="LinkButton1" ToolTip="Delete" AlternateText="Delete" OnClientClick="return isDelete();" CommandName="Delete" runat="server" ImageUrl="~/Credit/Images/recycle.jpg" Height="40px" Width="40px" ImageAlign="Middle" CausesValidation="False" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="View">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="LinkButton2" ToolTip="View" AlternateText="View" CommandName="Select" runat="server" CommandArgument='<%#Eval("ID")%>' ImageUrl="~/Credit/Images/view3.jpg" Height="40px" Width="40px" ImageAlign="Middle" CausesValidation="False" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Description">
                                    <EditItemTemplate>
                                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="TextBox1" runat="server" Text='<%# Bind("DOC_DESC") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("DOC_DESC") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="File Name">
                                    <EditItemTemplate>
                                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="TextBox2" runat="server" Text='<%# Bind("DOC_FILENAME") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("DOC_FILENAME") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Type">
                                    <EditItemTemplate>
                                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="TextBox3" runat="server" Text='<%# Bind("DOC_TYPE") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("DOC_TYPE") %>'></asp:Label>
                                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtDocId" runat="server" Text='<%#Eval("ID")%>'
                                            Visible="False"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <HeaderStyle CssClass="headerstyle" HorizontalAlign="center" />
                            <RowStyle CssClass="rowstyle" />
                        </asp:GridView>
                    </div>
                </div>
                <div style="height: 10px;"></div>
                <div class="row">
                    <div class="col-xs-12 text-center">
                        <asp:Button CssClass="btn btn-primary btn-sm save-btn" ID="btnActivateGrp" runat="server" Text="Activate Group" UseSubmitBehavior="false" />
                    </div>
                </div>
                <div class="row hidden">
                    <div class="col-xs-2 control-label">
                        <asp:Label ID="Label48" runat="server"
                            Text="Search by Group Name"></asp:Label>
                    </div>
                    <div class="col-xs-4">
                        <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtSearchGroup" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-xs-1">
                        <asp:Button CssClass="btn btn-primary btn-sm" ID="btnSearchGroup" runat="server" CausesValidation="False"
                            Text="Search" />
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-12 center-block">
                        <asp:GridView ID="grdGroup" runat="server" AllowPaging="True"
                            HorizontalAlign="Center" SelectedRowStyle-Font-Bold="true">
                            <AlternatingRowStyle CssClass="altrowstyle" />
                            <HeaderStyle CssClass="headerstyle" HorizontalAlign="center" />
                            <RowStyle CssClass="rowstyle" />
                            <PagerStyle CssClass="pagination-ys" />
                            <Columns>
                                <asp:CommandField ShowSelectButton="True" />
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
</asp:Content>

