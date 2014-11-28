<%@ Page Title="Courts" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Courts.aspx.cs" Inherits="TCCAMD.Pages.Courts" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h1><%: Title %></h1>

    <asp:Table ID="tblBookings" runat="server"></asp:Table>
</asp:Content>