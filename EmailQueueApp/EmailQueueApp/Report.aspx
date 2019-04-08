<%@ Page Title="Report" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Report.aspx.cs" Inherits="EmailQueueApp.Report" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2 class="title">Report</h2>
    <hr />

    <asp:GridView runat="server" ID="ReportGrid"
        ItemType="EmailQueueApp.ViewModel.MailingReportAddressVM"
        CssClass="table table-hover table-bordered"
        EmptyDataText="No addresses."
        AutoGenerateColumns="false"
        DataKeyNames="Id"
        SelectMethod="ReportGrid_GetData"
        DeleteMethod="ReportGrid_DeleteItem"
        UpdateMethod="ReportGrid_UpdateItem"
        OnRowDataBound="ReportGrid_RowDataBound"
        >
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="ID" />
                <asp:BoundField DataField="Email" HeaderText="Email" />
                <asp:BoundField DataField="Subject" HeaderText="Subject" />
                <asp:BoundField DataField="SendingTime" HeaderText="Sending Time" />
                <asp:BoundField DataField="RepeatCount" HeaderText="Repeat Count" />
                <asp:TemplateField HeaderText="Status">
                    <ItemTemplate>
                        <asp:DropDownList runat="server" ID="StatusDropDown" CssClass="form-control">

                        </asp:DropDownList>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>

    </asp:GridView>
</asp:Content>
