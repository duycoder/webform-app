<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="WebFormApp.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <asp:Label runat="server" ID="lblEventName" />
    <asp:TextBox runat="server" ID="txtEventName" OnTextChanged="txtEventName_TextChanged" AutoPostBack="true" />

    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator_txtEventName" runat="server" ControlToValidate="txtEventName" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>--%>
    <br />
    <asp:Button ID="btnClickMe" runat="server" CssClass="btn btn-primary" OnClick="OnClickMe" Text="Click Me" />

    <table class="table table-bordered">
        <tr>
            <td>Họ tên:</td>
            <td>
                <asp:TextBox runat="server" ID="txtFullName" CssClass="form-control" ToolTip="Your name" />
            </td>
        </tr>

        <tr>
            <td>Địa chỉ:</td>
            <td>
                <asp:TextBox runat="server" ID="txtAddress" CssClass="form-control" ToolTip="Your address" />
            </td>
        </tr>

        <tr>
            <td>Giới tính</td>
            <td>
                <asp:DropDownList runat="server" ID="ddlGender" CssClass="form-control" EnableViewState="false" />
            </td>
        </tr>

        <tr>
            <td>Mật khẩu</td>
            <td>
                <asp:TextBox runat="server" ID="txtPassword" TextMode="Password" CssClass="form-control" />
            </td>
        </tr>

        <tr>
            <td colspan="2">
                <asp:Button runat="server" ID="btnSaveInfo" OnClick="btnSaveInfo_Clicked" Text="Lưu" />
            </td>
        </tr>
    </table>

    <fieldset>
        <legend>RADIO</legend>
        <asp:RadioButtonList ID="rdbTech" runat="server">
            <asp:ListItem>Công nghệ phần mềm</asp:ListItem>
            <asp:ListItem>Hệ thống thông tin</asp:ListItem>
            <asp:ListItem>Mạng máy tính</asp:ListItem>
            <asp:ListItem>Khoa học máy tính</asp:ListItem>
        </asp:RadioButtonList>
    </fieldset>

    <fieldset>
        <legend>CHECKBOX</legend>
        <asp:CheckBox ID="CheckBox1" runat="server" Text="J2SE" />
        <asp:CheckBox ID="CheckBox2" runat="server" Text="J2EE" />
        <asp:CheckBox ID="CheckBox3" runat="server" Text="Spring" />
    </fieldset>

    <asp:Button runat="server" ID="btnCommand" OnCommand="btnCommand_Command" Text="Test Command"/>

</asp:Content>
