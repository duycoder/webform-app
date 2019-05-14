<%@ Page Title="RegistrationForm"
    Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="RegistrationForm.aspx.cs"
    Inherits="WebFormApp.RegistrationForm" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        <%: Title%>
    </h2>
    <asp:TextBox runat="server" ID="txtUserName" CssClass="form-control" MaxLength="5"/>
    <asp:Button runat="server" ID="btnSubmit" CssClass="btn btn-primary" Text="Cập nhật"/>
</asp:Content>
