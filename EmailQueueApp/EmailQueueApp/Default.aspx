<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="EmailQueueApp._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Mailing Application</h1>
        <p class="lead">An application that allows creating mailing lists with multiple addresses and specify time to send.</p>

        <a href="Create.aspx" class="btn btn-primary btn-lg">Create &raquo;</a>
        <a href="Report.aspx" class="btn btn-primary btn-lg">Report &raquo;</a>
    </div>
</asp:Content>
