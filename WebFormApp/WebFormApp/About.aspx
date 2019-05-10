<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="WebFormApp.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <asp:Label runat="server" ID="lblEventName" />
    <asp:Button runat="server" ID="btnClickMe" OnClick="OnClickMe" CssClass="btn btn-primary" Text="Click Me"/>
</asp:Content>
