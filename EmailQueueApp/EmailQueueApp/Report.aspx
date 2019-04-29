<%@ Page Title="Report" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Report.aspx.cs" Inherits="EmailQueueApp.Report" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2 class="title">Report</h2>

    <asp:HyperLink runat="server" NavigateUrl="~/Create.aspx">Create a mailing</asp:HyperLink>
    <hr />

    <div class="panel panel-primary">
        <div class="panel-heading">
            Report
        </div>

        <div class="panel-body">
            <asp:GridView runat="server" ID="ReportGrid"
                ItemType="EmailQueueApp.ViewModel.MailingReportAddressVM"
                CssClass="table table-hover table-bordered"
                EmptyDataText="No addresses."
                AutoGenerateColumns="false"
                DataKeyNames="Id"
                SelectMethod="ReportGrid_GetData">
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="ID" />
                    <asp:BoundField DataField="Email" HeaderText="Email" />
                    <asp:BoundField DataField="Subject" HeaderText="Subject" />
                    <asp:BoundField DataField="SendingTime" HeaderText="Sending Time" />
                    <asp:BoundField DataField="RepeatCount" HeaderText="Repeat Count" />
                    <asp:TemplateField HeaderText="Status">
                        <ItemTemplate>
                            <asp:DropDownList runat="server" ID="StatusDropDown" CssClass="form-control app-mail-status"
                                SelectMethod="StatusDropDown_GetData"
                                DataTextField="Value"
                                DataValueField="Key"
                                SelectedValue='<%# Bind("StatusId") %>'
                                AutoPostBack="true"
                                OnSelectedIndexChanged="StatusDropDown_SelectedIndexChanged">
                            </asp:DropDownList>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>

            </asp:GridView>
        </div>
    </div>

    <script src="Scripts/Pages/report.js"></script>
    <script>
        Report.Initialize();
    </script>
</asp:Content>
