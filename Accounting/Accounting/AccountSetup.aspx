<%@ Page Title="Account Setup" Language="VB" MasterPageFile="~/Site2.master" AutoEventWireup="false" CodeFile="AccountSetup.aspx.vb" Inherits="Accounting_AccountSetup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="panel panel-primary small">
        <div class="panel-heading">
            <h4 class="panel-title">Account Setup
            </h4>
        </div>
        <div class="panel-body">
            <div id="Tabs" role="tabpanel">
                <ul class="nav nav-tabs bg-info">
                    <li class="active"><a data-toggle="tab" href="#stmtCat"><b>Statement Categories</b></a></li>
                    <li><a data-toggle="tab" href="#stmtSubCat"><b>Statement Subcategories</b></a></li>
                    <li><a data-toggle="tab" href="#BSItems"><b>Balance Sheet Items</b></a></li>
                    <li><a data-toggle="tab" href="#accCreation"><b>Account Creation</b></a></li>
                </ul>

                <div class="tab-content">
                    <div id="stmtCat" class="tab-pane fade in active">
                        <div style="height: 15px;"></div>
                        <div class="row">
                            <div class="col-xs-12 label-info control-label">
                                Statement Categories
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-xs-2 control-label">
                                Statement
                            </div>
                            <div class="col-xs-4">
                                <asp:RadioButtonList ID="rdbStatementType" runat="server" RepeatDirection="Horizontal" CssClass="col-xs-12">
                                    <asp:ListItem Text="Profit & Loss" Value="PL"></asp:ListItem>
                                    <asp:ListItem Text="Balance Sheet" Value="BS"></asp:ListItem>
                                </asp:RadioButtonList>
                            </div>
                            <div class="col-xs-2 control-label">
                                Category
                            </div>
                            <div class="col-xs-4">
                                <asp:TextBox ID="txtCategory" runat="server" CssClass="col-xs-12 form-control input-sm" ToolTip="Category of Financial Statement" data-toggle="tooltip" data-placement="top"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-xs-12 text-center">
                                <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-primary btn-sm" />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-xs-12 center-block">
                                <asp:GridView ID="grdCategories" runat="server" HorizontalAlign="Center" AutoGenerateColumns="false">
                                    <AlternatingRowStyle CssClass="altrowstyle" />
                                    <HeaderStyle CssClass="headerstyle" HorizontalAlign="center" />
                                    <RowStyle CssClass="rowstyle" />
                                    <PagerStyle CssClass="pagination-ys" />
                                    <SelectedRowStyle Font-Bold="true" BackColor="#A8B1B9" />
                                    <Columns>
                                        <asp:TemplateField ShowHeader="False">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False"
                                                    CommandName="Delete" Text="Delete" OnClientClick="return isDelete();"></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ShowHeader="False">
                                            <EditItemTemplate>
                                                <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="True"
                                                    CommandName="Update" Text="Update"></asp:LinkButton>
                                                &nbsp;<asp:LinkButton ID="LinkButton3" runat="server" CausesValidation="False"
                                                    CommandName="Cancel" Text="Cancel"></asp:LinkButton>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:LinkButton ID="LinkButton4" runat="server" CausesValidation="False"
                                                    CommandName="Edit" Text="Edit"></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Statement">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtGrdStatement" runat="server" Text='<%# Bind("Statement") %>' Visible="False"></asp:TextBox>
                                                <asp:DropDownList ID="cmbGrdStatement" runat="server">
                                                </asp:DropDownList>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblGrdStatement" runat="server" Text='<%# Bind("Statement") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Category">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtGrdCategory" runat="server" Text='<%# Bind("Category") %>'></asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblGrdCategory" runat="server" Text='<%# Bind("Category") %>'></asp:Label>
                                                <asp:TextBox ID="txtGrdID" runat="server" Text='<%# Bind("id")%>' Visible="false"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-xs-10">
                            </div>
                            <div class="col-xs-2 text-right">
                                <a class="btn btn-info btn-xs disabled">Previous</a>
                                <a class="btn btn-info btnNext btn-xs">Next</a>
                            </div>
                        </div>
                    </div>
                    <div id="stmtSubCat" class="tab-pane fade in">
                        <div style="height: 15px;"></div>
                        <div class="row">
                            <div class="col-xs-12 label-info control-label">
                                Statement Subcategories
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-xs-2 control-label">
                                Category
                            </div>
                            <div class="col-xs-4">
                                <asp:DropDownList ID="cmbCategory" CssClass="col-xs-12 form-control input-sm" runat="server"></asp:DropDownList>
                            </div>
                            <div class="col-xs-2 control-label">
                                Sub Category
                            </div>
                            <div class="col-xs-4">
                                <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtSubCategory" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-xs-2 control-label">
                                Minimum Account Number
                            </div>
                            <div class="col-xs-4">
                                <asp:TextBox ID="txtMinAccNo" runat="server" CssClass="col-xs-12 form-control input-sm numeric"></asp:TextBox>
                            </div>
                            <div class="col-xs-2 control-label">
                                Maximum Account Number
                            </div>
                            <div class="col-xs-4">
                                <asp:TextBox ID="txtMaxAccNo" runat="server" CssClass="col-xs-12 form-control input-sm numeric"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-xs-12 text-center">
                                <asp:Button ID="btnSaveSubCategory" runat="server" Text="Save" CssClass="btn btn-primary btn-sm" />
                            </div>
                        </div>
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <div class="row">
                                    <div class="col-xs-12 text-center">
                                        <asp:UpdateProgress runat="server" ID="UpdateProgress4" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="0" DynamicLayout="false">
                                            <ProgressTemplate>
                                                <img alt="In progress..." src="../Credit/Images/progress.gif" />
                                            </ProgressTemplate>
                                        </asp:UpdateProgress>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-xs-12 center-block">
                                        <asp:GridView ID="grdSubCategory" runat="server" HorizontalAlign="Center" AutoGenerateColumns="false">
                                            <AlternatingRowStyle CssClass="altrowstyle" />
                                            <HeaderStyle CssClass="headerstyle" HorizontalAlign="center" />
                                            <RowStyle CssClass="rowstyle" />
                                            <PagerStyle CssClass="pagination-ys" />
                                            <SelectedRowStyle Font-Bold="true" BackColor="#A8B1B9" />
                                            <Columns>
                                                <asp:TemplateField ShowHeader="False">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False"
                                                            CommandName="Delete" Text="Delete" OnClientClick="return isDelete();"></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ShowHeader="False">
                                                    <EditItemTemplate>
                                                        <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="True"
                                                            CommandName="Update" Text="Update"></asp:LinkButton>
                                                        &nbsp;<asp:LinkButton ID="LinkButton3" runat="server" CausesValidation="False"
                                                            CommandName="Cancel" Text="Cancel"></asp:LinkButton>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="LinkButton4" runat="server" CausesValidation="False"
                                                            CommandName="Edit" Text="Edit"></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Statement">
                                                    <EditItemTemplate>
                                                        <asp:Label ID="txtGrdStatement" runat="server" Text='<%# Bind("Statement") %>'></asp:Label>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblGrdStatement" runat="server" Text='<%# Bind("Statement") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Category">
                                                    <EditItemTemplate>
                                                        <asp:Label ID="txtGrdCategory" runat="server" Text='<%# Bind("Category") %>'></asp:Label>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblGrdCategory" runat="server" Text='<%# Bind("Category") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Sub Category">
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="txtGrdSubCategory" runat="server" Text='<%# Bind("SubCategory") %>'></asp:TextBox>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblGrdSubCategory" runat="server" Text='<%# Bind("SubCategory") %>'></asp:Label>
                                                        <asp:TextBox ID="txtGrdID" runat="server" Text='<%# Bind("id")%>' Visible="false"></asp:TextBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Minimum Account Number">
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="txtGrdMinAccount" runat="server" Text='<%# Bind("MinAccount") %>' CssClass="numeric"></asp:TextBox>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblGrdMinAccount" runat="server" Text='<%# Bind("MinAccount") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Maximum Account Number">
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="txtGrdMaxAccount" runat="server" Text='<%# Bind("MaxAccount") %>' CssClass="numeric"></asp:TextBox>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblGrdMaxAccount" runat="server" Text='<%# Bind("MaxAccount") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </div>
                            </ContentTemplate>
                            <Triggers>
                            </Triggers>
                        </asp:UpdatePanel>
                        <div class="row">
                            <div class="col-xs-10">
                            </div>
                            <div class="col-xs-2 text-right">
                                <a class="btn btn-info btn-xs btnPrevious">Previous</a>
                                <a class="btn btn-info btnNext btn-xs">Next</a>
                            </div>
                        </div>
                    </div>
                    <div id="BSItems" class="tab-pane fade in">
                        <div style="height: 15px;"></div>
                        <div class="row">
                            <div class="col-xs-12 label-info control-label">
                                Balance Sheet Items
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-xs-1 control-label">
                                Sub Category
                            </div>
                            <div class="col-xs-5">
                                <asp:DropDownList ID="cmbSubCategory" CssClass="col-xs-12 form-control input-sm" runat="server"></asp:DropDownList>
                            </div>
                            <div class="col-xs-2 control-label">
                                Item Name
                            </div>
                            <div class="col-xs-4">
                                <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtItemName" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-xs-12 text-center">
                                <asp:Button ID="btnSaveItem" runat="server" Text="Save" CssClass="btn btn-primary btn-sm" />
                            </div>
                        </div>
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>
                                <div class="row">
                                    <div class="col-xs-12 text-center">
                                        <asp:UpdateProgress runat="server" ID="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel2" DisplayAfter="0" DynamicLayout="false">
                                            <ProgressTemplate>
                                                <img alt="In progress..." src="../Credit/Images/progress.gif" />
                                            </ProgressTemplate>
                                        </asp:UpdateProgress>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-xs-12 center-block">
                                        <asp:GridView ID="grdBalanceSheetItems" runat="server" HorizontalAlign="Center">
                                            <AlternatingRowStyle CssClass="altrowstyle" />
                                            <HeaderStyle CssClass="headerstyle" HorizontalAlign="center" />
                                            <RowStyle CssClass="rowstyle" />
                                            <PagerStyle CssClass="pagination-ys" />
                                            <SelectedRowStyle Font-Bold="true" BackColor="#A8B1B9" />
                                        </asp:GridView>
                                    </div>
                                </div>
                            </ContentTemplate>
                            <Triggers>
                            </Triggers>
                        </asp:UpdatePanel>
                        <div class="row">
                            <div class="col-xs-10">
                            </div>
                            <div class="col-xs-2 text-right">
                                <a class="btn btn-info btn-xs btnPrevious">Previous</a>
                                <a class="btn btn-info btnNext btn-xs">Next</a>
                            </div>
                        </div>
                    </div>
                    <div id="accCreation" class="tab-pane fade in">
                        <div style="height: 15px;"></div>
                        <div class="row">
                            <div class="col-xs-12 label-info control-label">
                                Account Creation
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-xs-2 control-label">
                                Account Name
                    <asp:Label ID="Label123" runat="server" Text="*" ForeColor="Red" Font-Size="Large"></asp:Label>
                            </div>
                            <div class="col-xs-4">
                                <asp:TextBox ID="txtAccountName" runat="server" CssClass="col-xs-12 form-control input-sm"></asp:TextBox>
                                <asp:RequiredFieldValidator Display="Dynamic" ID="rfvIDNo" runat="server" ErrorMessage="Account Name is required" ControlToValidate="txtAccountName" ValidationGroup="valAcc"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-xs-2 control-label">
                                Account Type
                    <asp:Label ID="Label1" runat="server" Text="*" ForeColor="Red" Font-Size="Large"></asp:Label>
                            </div>
                            <div class="col-xs-4">
                                <asp:RadioButtonList ID="rdbAccType" runat="server" RepeatDirection="Horizontal" CssClass="col-xs-12" AutoPostBack="true">
                                    <asp:ListItem Text="Profit & Loss" Value="PL"></asp:ListItem>
                                    <asp:ListItem Text="Balance Sheet" Value="BS"></asp:ListItem>
                                </asp:RadioButtonList>
                                <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator1" runat="server" ErrorMessage="Account Type is required" ControlToValidate="rdbAccType" ValidationGroup="valAcc"></asp:RequiredFieldValidator>
                            </div>
                            <div class="col-xs-2 control-label">
                                Category
                    <asp:Label ID="Label2" runat="server" Text="*" ForeColor="Red" Font-Size="Large"></asp:Label>
                            </div>
                            <div class="col-xs-4">
                                <asp:DropDownList ID="cmbCategoryAcc" runat="server" CssClass="col-xs-12 form-control input-sm" AutoPostBack="true"></asp:DropDownList>
                                <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator2" runat="server" ErrorMessage="Account Category is required" ControlToValidate="cmbCategory" ValidationGroup="valAcc"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-xs-2 control-label">
                                Sub Category
                    <asp:Label ID="Label3" runat="server" Text="*" ForeColor="Red" Font-Size="Large"></asp:Label>
                            </div>
                            <div class="col-xs-4">
                                <asp:DropDownList ID="cmbSubCategoryAcc" runat="server" CssClass="col-xs-12 form-control input-sm" AutoPostBack="true"></asp:DropDownList>
                                <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator3" runat="server" ErrorMessage="Account Sub Category is required" ControlToValidate="cmbSubCategory" ValidationGroup="valAcc"></asp:RequiredFieldValidator>
                            </div>
                            <div class="col-xs-2 control-label">
                                Account Number
                    <asp:Label ID="Label4" runat="server" Text="*" ForeColor="Red" Font-Size="Large"></asp:Label>
                            </div>
                            <div class="col-xs-4">
                                <asp:TextBox ID="txtAccNumber" runat="server" CssClass="col-xs-12 form-control input-sm numeric"></asp:TextBox>
                                <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator4" runat="server" ErrorMessage="Account Number is required" ControlToValidate="txtAccNumber" ValidationGroup="valAcc"></asp:RequiredFieldValidator>
                                <asp:Label ID="lblAccNoRange" runat="server" Text="" ForeColor="Red"></asp:Label>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-xs-2 control-label">
                                Account Description
                            </div>
                            <div class="col-xs-4">
                                <asp:TextBox ID="txtAccDesc" runat="server" CssClass="col-xs-12 form-control input-sm" TextMode="MultiLine"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-xs-12 text-center">
                                <asp:Button ID="btnSaveAcc" runat="server" Text="Save" CssClass="btn btn-primary btn-sm" ValidationGroup="valAcc" />
                            </div>
                        </div>
                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                            <ContentTemplate>
                                <div class="row">
                                    <div class="col-xs-12 text-center">
                                        <asp:UpdateProgress runat="server" ID="UpdateProgress2" AssociatedUpdatePanelID="UpdatePanel3" DisplayAfter="0" DynamicLayout="false">
                                            <ProgressTemplate>
                                                <img alt="In progress..." src="../Credit/Images/progress.gif" />
                                            </ProgressTemplate>
                                        </asp:UpdateProgress>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-xs-12">
                                        <asp:GridView ID="grdAccounts" runat="server" HorizontalAlign="Center" AutoGenerateColumns="false">
                                            <AlternatingRowStyle CssClass="altrowstyle" />
                                            <HeaderStyle CssClass="headerstyle" HorizontalAlign="center" />
                                            <RowStyle CssClass="rowstyle" />
                                            <PagerStyle CssClass="pagination-ys" />
                                            <SelectedRowStyle Font-Bold="true" BackColor="#A8B1B9" />
                                            <Columns>
                                                <asp:TemplateField ShowHeader="False">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False"
                                                            CommandName="Delete" Text="Delete" OnClientClick="return isDelete();"></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField ShowHeader="False">
                                                    <EditItemTemplate>
                                                        <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="True"
                                                            CommandName="Update" Text="Update"></asp:LinkButton>
                                                        &nbsp;<asp:LinkButton ID="LinkButton3" runat="server" CausesValidation="False"
                                                            CommandName="Cancel" Text="Cancel"></asp:LinkButton>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="LinkButton4" runat="server" CausesValidation="False"
                                                            CommandName="Edit" Text="Edit"></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Account Name">
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="txtGrdAccountName" runat="server" Text='<%# Bind("AccountName") %>' CssClass="col-xs-12 form-control input-sm"></asp:TextBox>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblGrdAccountName" runat="server" Text='<%# Bind("AccountName") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Type">
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="txtGrdType" runat="server" Text='<%# Bind("Type") %>' Visible="false"></asp:TextBox>
                                                        <asp:DropDownList ID="cmbGrdType" runat="server" AutoPostBack="true" OnSelectedIndexChanged="cmbGrdType_SelectedIndexChanged" CssClass="col-xs-12 form-control input-sm">
                                                            <asp:ListItem></asp:ListItem>
                                                            <asp:ListItem Text="Profit & Loss" Value="PL"></asp:ListItem>
                                                            <asp:ListItem Text="Balance Sheet" Value="BS"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblGrdType" runat="server" Text='<%# Bind("Type") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Category">
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="txtGrdCategory" runat="server" Text='<%# Bind("CatID") %>' Visible="false"></asp:TextBox>
                                                        <asp:DropDownList ID="cmbGrdCategory" runat="server" AutoPostBack="true" OnSelectedIndexChanged="cmbGrdCategory_SelectedIndexChanged" CssClass="col-xs-12 form-control input-sm">
                                                        </asp:DropDownList>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblGrdCategory" runat="server" Text='<%# Bind("Category") %>'></asp:Label>
                                                        <asp:TextBox ID="txtGrdID" runat="server" Text='<%# Bind("Sysid")%>' Visible="false"></asp:TextBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Sub Category">
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="txtGrdSubCategory" runat="server" Text='<%# Bind("SubCatID") %>' Visible="false"></asp:TextBox>
                                                        <asp:DropDownList ID="cmbGrdSubCategory" runat="server" CssClass="col-xs-12 form-control input-sm">
                                                        </asp:DropDownList>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblGrdSubCategory" runat="server" Text='<%# Bind("SubCategory") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Account Number">
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="txtGrdMainAccount" runat="server" Text='<%# Bind("MainAccount") %>' CssClass="col-xs-12 form-control input-sm"></asp:TextBox>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblGrdMainAccount" runat="server" Text='<%# Bind("MainAccount") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Account Description">
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="txtGrdDescription" runat="server" Text='<%# Bind("Description") %>' CssClass="col-xs-12 form-control input-sm"></asp:TextBox>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblGrdDescription" runat="server" Text='<%# Bind("Description") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </div>
                            </ContentTemplate>
                            <Triggers>
                            </Triggers>
                        </asp:UpdatePanel>
                        <div class="row">
                            <div class="col-xs-10">
                            </div>
                            <div class="col-xs-2 text-right">
                                <a class="btn btn-info btn-xs btnPrevious">Previous</a>
                                <a class="btn btn-info disabled btn-xs">Next</a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <asp:HiddenField ID="TabName" runat="server" />
        </div>
    </div>
    <script type="text/javascript">
        $(function () {
            var tabName = $("[id*=TabName]").val() != "" ? $("[id*=TabName]").val() : "stmtCat";
            $('#Tabs a[href="#' + tabName + '"]').tab('show');
            $("#Tabs a").click(function () {
                $("[id*=TabName]").val($(this).attr("href").replace("#", ""));
            });
        });

<%--        $(document).ready(function () {
            var selectedTab = $("#<%=TabName.ClientID%>");
            var tabId = selectedTab.val() != "" ? selectedTab.val() : "stmtCat";
            $('#Tabs a[href="#' + tabId + '"]').tab('show');
            $("#Tabs a").click(function () {
                selectedTab.val($(this).attr("href").substring(1));
            });
        });--%>

        $('.btnNext').click(function () {
            $('.nav-tabs > .active').next('li').find('a').trigger('click');
        });

        $('.btnPrevious').click(function () {
            $('.nav-tabs > .active').prev('li').find('a').trigger('click');
        });
        $(document).ready(function () {
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);

            function EndRequestHandler(sender, args) {
                $(function notify(txt, noteType, layout) {
                    layout = layout || 'top';
                    var n = noty({
                        layout: layout,
                        theme: 'relax',
                        type: noteType,
                        text: txt,
                        timeout: 10000
                    });
                });
            }

        });

        $(document).ready(function () {
            $('[data-toggle="tooltip"]').tooltip();
        });
    </script>
</asp:Content>