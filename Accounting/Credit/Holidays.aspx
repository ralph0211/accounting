<%@ Page Title="Holidays" Language="VB" MasterPageFile="~/Site2.master" AutoEventWireup="false" CodeFile="Holidays.aspx.vb" Inherits="Credit_Holidays" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="panel panel-primary small">
        <div class="panel-heading">
            <h4 class="panel-title">Holidays & Working Week Settings
            </h4>
        </div>
        <div class="panel-body">
            <div class="row label-info">
                <div class="col-xs-12 control-label">
                    Working Days
                </div>
            </div>
            <div class="row">
                <div class="col-xs-2 control-label">
                    Working Days
                </div>
                <div class="col-xs-8">
                    <asp:CheckBoxList ID="chkWorkingDays" RepeatDirection="horizontal" CssClass="col-xs-12" runat="server">
                        <asp:ListItem Text="Monday" Value="2"></asp:ListItem>
                        <asp:ListItem Text="Tuesday" Value="3"></asp:ListItem>
                        <asp:ListItem Text="Wednesday" Value="4"></asp:ListItem>
                        <asp:ListItem Text="Thursday" Value="5"></asp:ListItem>
                        <asp:ListItem Text="Friday" Value="6"></asp:ListItem>
                        <asp:ListItem Text="Saturday" Value="7"></asp:ListItem>
                        <asp:ListItem Text="Sunday" Value="1"></asp:ListItem>
                    </asp:CheckBoxList>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12 text-center">
                    <asp:Button CssClass="btn btn-primary btn-sm" ID="btnSaveWorkingDays" runat="server" Text="Save" UseSubmitBehavior="false" />
                </div>
            </div>
            <div class="row label-info">
                <div class="col-xs-12 control-label">
                    Static Annual Holidays
                </div>
            </div>
            <div class="row">
                <div class="col-xs-1 control-label">
                    Month
                </div>
                <div class="col-xs-2">
                    <asp:DropDownList ID="cmbMonths" runat="server" CssClass="col-xs-12 form-control input-sm" AutoPostBack="true"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvMonths" runat="server" ErrorMessage="Month is required" ControlToValidate="cmbMonths" ValidationGroup="3" Display="dynamic"></asp:RequiredFieldValidator>
                </div>
                <div class="col-xs-1 control-label">
                    Day
                </div>
                <div class="col-xs-2">
                    <asp:DropDownList ID="cmbDay" runat="server" CssClass="col-xs-12 form-control input-sm"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvDay" runat="server" ErrorMessage="Day is required" ControlToValidate="cmbDay" ValidationGroup="3" Display="dynamic"></asp:RequiredFieldValidator>
                </div>
                <div class="col-xs-2 control-label">
                    Holiday Name
                </div>
                <div class="col-xs-4">
                    <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtSpecialHolName" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvSpecialHolName" runat="server" ErrorMessage="Name is required" ValidationGroup="3" ControlToValidate="txtSpecialHolName" Display="dynamic"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12 text-center">
                    <asp:Button CssClass="btn btn-primary btn-sm" ID="btnAddAnnual" runat="server" Text="Save" ValidationGroup="3" UseSubmitBehavior="false" />
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12 center-block">
                    <asp:GridView ID="grdAnnual" runat="server" AutoGenerateColumns="False" EnableModelValidation="True" HorizontalAlign="center">
                        <AlternatingRowStyle CssClass="altrowstyle" />
                        <Columns>
                            <asp:TemplateField ShowHeader="False">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton3" runat="server" CausesValidation="False"
                                        CommandName="Delete" Text="Delete" OnClientClick="return isDelete();"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField ShowHeader="False">
                                <EditItemTemplate>
                                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True"
                                        CommandName="Update" Text="Update"></asp:LinkButton>
                                    &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False"
                                        CommandName="Cancel" Text="Cancel"></asp:LinkButton>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton4" runat="server" CausesValidation="False"
                                        CommandName="Edit" Text="Edit"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Month">
                                <EditItemTemplate>
                                    <asp:TextBox CssClass="col-xs-12 form-control input-sm" runat="server" Text='<%#Bind("MMonth")%>' ID="txtGrdMonthEdit" Visible="false">
                                    </asp:TextBox>
                                    <asp:DropDownList ID="cmbGrdMonthEdit" CssClass="col-xs-12 form-control input-sm" runat="server" AutoPostBack="true" OnSelectedIndexChanged="cmbGrdMonthEdit_SelectedIndexChanged"></asp:DropDownList>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblMonth" runat="server"><%#Eval("MonthName")%></asp:Label>
                                    <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtGrdMonthID" runat="server" Visible="False" Text='<%#Bind("ID")%>'></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Day">
                                <EditItemTemplate>
                                    <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtGrdDay" runat="server" Text='<%#Bind("DDay")%>' Visible="False"></asp:TextBox>
                                    <asp:DropDownList CssClass="col-xs-12 form-control input-sm" ID="cmbGrdDayEdit" runat="server"></asp:DropDownList>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblGrdDay" runat="server"><%#Eval("DDay")%></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Holiday Name">
                                <EditItemTemplate>
                                    <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtGrdHolidayName" runat="server" Text='<%#Bind("HolidayName")%>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblGrdHolidayName" runat="server"><%#Eval("HolidayName")%></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <HeaderStyle CssClass="headerstyle" HorizontalAlign="center" />
                        <RowStyle CssClass="rowstyle" />
                    </asp:GridView>
                </div>
            </div>
            <div class="row label-info">
                <div class="col-xs-12 control-label">
                    Special Holidays
                </div>
            </div>
            <div class="row">
                <div class="col-xs-2 control-label">
                    <asp:Label ID="Label17" runat="server" Text="Date"></asp:Label>
                </div>
                <div class="col-xs-4">
                    <asp:TextBox ID="bdpHolDate" runat="server" CssClass="col-xs-12 form-control input-sm datepicker"></asp:TextBox>
                    <span class="glyphicon glyphicon-calendar form-control-feedback" style="margin-right: 13px; background-color: #eeeeff; border-radius: 0 3px 3px 0; border: 1px solid rgb(149,188,219); z-index: 0;"></span>
                    <asp:RequiredFieldValidator ID="rfvHolDate" runat="server" ErrorMessage="Date is required" ValidationGroup="2" ControlToValidate="bdpHolDate" Display="dynamic"></asp:RequiredFieldValidator>
                </div>
                <div class="col-xs-2 control-label">
                    <asp:Label ID="Labelaaa17" runat="server" Text="Holiday Name"></asp:Label>
                </div>
                <div class="col-xs-4">
                    <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtHolName" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvHolName" runat="server" ErrorMessage="Name is required" ValidationGroup="2" ControlToValidate="txtHolName" Display="dynamic"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12 text-center">
                    <asp:Button CssClass="btn btn-primary btn-sm" ID="btnSaveHoliday" runat="server" Text="Submit" ValidationGroup="2" UseSubmitBehavior="false" />
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12 center-block">
                    <asp:GridView ID="grdHolidays" runat="server" AutoGenerateColumns="False" EnableModelValidation="True" HorizontalAlign="center">
                        <AlternatingRowStyle CssClass="altrowstyle" />
                        <Columns>
                            <asp:TemplateField ShowHeader="False">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton3" runat="server" CausesValidation="False"
                                        CommandName="Delete" Text="Delete" OnClientClick="return isDelete();"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField ShowHeader="False">
                                <EditItemTemplate>
                                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True"
                                        CommandName="Update" Text="Update"></asp:LinkButton>
                                    &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False"
                                        CommandName="Cancel" Text="Cancel"></asp:LinkButton>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton4" runat="server" CausesValidation="False"
                                        CommandName="Edit" Text="Edit"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Date">
                                <EditItemTemplate>
                                    <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtMktCodeEdit" runat="server" Text='<%#Bind("HOLIDAY_DATE")%>' Visible="False"></asp:TextBox>
                                    <asp:TextBox CssClass="col-xs-12 form-control input-sm datepicker" ID="bdpEditDate" runat="server" Text='<%#Bind("HOLIDAY_DATE1")%>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblMktCode" runat="server"><%#Eval("HOLIDAY_DATE1")%></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Holiday Name">
                                <EditItemTemplate>
                                    <asp:TextBox CssClass="col-xs-12 form-control input-sm" runat="server" Text='<%#Bind("HOLIDAY_DESC")%>' ID="txtGrdMktNameEdit">
                                    </asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblMktName" runat="server"><%#Eval("HOLIDAY_DESC")%></asp:Label>
                                    <asp:TextBox CssClass="col-xs-12 form-control input-sm" ID="txtGrdMktID" runat="server" Visible="False" Text='<%#Bind("ID")%>'></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <HeaderStyle CssClass="headerstyle" HorizontalAlign="center" />
                        <RowStyle CssClass="rowstyle" />
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
</asp:Content>