<%@ Page Title="RegistrationForm" 
    Language="C#" MasterPageFile="~/Site.Master" 
    AutoEventWireup="true" CodeBehind="RegistrationForm.aspx.cs" 
    Inherits="WebFormApp.RegistrationForm" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <table class="table table-bordered table-striped">
        <tr>
            <td>
                Tên đăng nhập:
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtName" CssClass="form-control" 
                    MaxLength="255" ReadOnly="false" ToolTip="Tên đăng nhập"/>
            </td>
        </tr>

        <tr>
            <td>
                Mật khẩu:
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtPassword" CssClass="form-control" TextMode="Password" MaxLength="255" ToolTip="Mật khẩu"/>
            </td>
        </tr>
        <tr>
            <td>Giới tính:</td>
            <td>
                <asp:RadioButton runat="server" ID="rdbMale" Text="Nam" TextAlign="Left" GroupName="rdbGender"/>
                <asp:RadioButton runat="server" ID="rdbFemale" Text="Nữ" TextAlign="Left" GroupName="rdbGender"/>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button runat="server" ID="btnRegister" CssClass="btn btn-primary" Text="Đăng nhập"/>
            </td>
        </tr>
    </table>
</asp:Content>