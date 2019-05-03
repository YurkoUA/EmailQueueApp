<%@ Page Title="Create Mailing" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Create.aspx.cs" Inherits="EmailQueueApp.Create" EnableEventValidation="false" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2 class="title">Create Mailing</h2>
    <hr />

    <form>
        <div class="form-group">
            <asp:Label runat="server" CssClass="control-label" AssociatedControlID="SubjectTextBox">Subject</asp:Label>
            <asp:TextBox runat="server" ID="SubjectTextBox" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
        </div>

        <div class="form-group">
            <asp:Label runat="server" CssClass="control-label" AssociatedControlID="BodyTextBox">Body</asp:Label>
            <asp:TextBox runat="server" ID="BodyTextBox" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
        </div>

        <div class="form-group" style="position: relative">
            <asp:Label runat="server" CssClass="control-label" AssociatedControlID="SendingDatePicker">Sending Time</asp:Label>
            <asp:TextBox runat="server" ID="SendingDatePicker" CssClass="form-control"></asp:TextBox>
        </div>

        <div class="form-group">
            <asp:Label runat="server" CssClass="control-label" AssociatedControlID="AddressesGrid">Addresses</asp:Label>

            <asp:GridView runat="server" ID="AddressesGrid"
                ItemType="EmailQueueApp.ViewModel.AddressPM"
                CssClass="table table-hover table-bordered"
                UpdateMethod="Addresses_UpdateItem"
                DeleteMethod="Addresses_DeleteItem"
                SelectMethod="Addresses_GetData"
                DataKeyNames="Guid"
                EmptyDataText="There are no addresses.">

                <Columns>
                    <asp:BoundField DataField="Guid" Visible="false" />
                    <asp:BoundField DataField="Email" HeaderText="Email" />
                    <asp:BoundField DataField="RepeatCount" HeaderText="Repeat Count" />
                    <asp:CommandField ShowEditButton="true" ButtonType="Button" ControlStyle-CssClass="btn btn-sm" />
                    <asp:CommandField ShowDeleteButton="true" ButtonType="Button" ControlStyle-CssClass="btn btn-sm" />
                </Columns>
            </asp:GridView>
        </div>
    </form>

    <hr />

    <h4 class="title">Add address</h4>

    <div class="form form-inline">
        <div class="form-group">
            <asp:TextBox runat="server" ID="EmailAddressTextBox" CssClass="form-control" placeholder="Email Address" TextMode="Email"></asp:TextBox>
        </div>

        <div class="form-group">
            <asp:TextBox runat="server" ID="RepeatCountTextBox" CssClass="form-control" placeholder="Repeat Count" TextMode="Number"></asp:TextBox>
        </div>

        <div class="form-group">
            <asp:Button runat="server" ID="AddressAddBtn" CssClass="btn btn-default" Text="Add" OnClick="AddressAddBtn_Click" UseSubmitBehavior="false" />
        </div>
    </div>

    <div class="form-group">
        <asp:Button runat="server" ID="CreateBtn" CssClass="btn btn-primary" Text="Create" OnClick="CreateBtn_Click" />
    </div>

    <script src="Scripts/Pages/mailing-create.js"></script>
    <script>
        MailingCreate.Initialize();
    </script>
</asp:Content>
