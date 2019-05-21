<%@ Page Title="RegistrationForm"
    Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="RegistrationForm.aspx.cs"
    Inherits="WebFormApp.RegistrationForm" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <table class="table table-striped table-bordered">
        <tr>
            <td>Lịch làm việc</td>
            <td>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtCalWorking"/>
                <asp:Button runat="server" CssClass="btn btn-primary" Text="Chọn" Id="btnShowCalWorking"/>

                <asp:Calendar ID="calWorking" runat="server" BackColor="White" BorderColor="White" BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="190px" NextPrevFormat="FullMonth" Width="350px">
                    <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
                    <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" VerticalAlign="Bottom" />
                    <OtherMonthDayStyle ForeColor="#999999" />
                    <SelectedDayStyle BackColor="#333399" ForeColor="White" />
                    <TitleStyle BackColor="White" BorderColor="Black" BorderWidth="4px" Font-Bold="True" Font-Size="12pt" ForeColor="#333399" />
                    <TodayDayStyle BackColor="#CCCCCC" />
                </asp:Calendar>

            </td>
        </tr>
        <tr>
            <td>
                Quảng cáo
            </td>
            <td>
               <asp:AdRotator runat="server" AdvertisementFile="~/Resources/Data/Ads.xml" KeywordFilter="hinet,google"/>
            </td>
        </tr>
        <tr>
            <td>Họ tên
            </td>
            <td>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtName" />
            </td>
        </tr>
        <tr>
            <td>Giới tính:
            </td>
            <td>
                <asp:RadioButton runat="server" ID="rdbMale" Text="Nam" GroupName="rdbGender" />
                <asp:RadioButton runat="server" ID="rdbFemale" Text="Nữ" GroupName="rdbGender" />
            </td>
        </tr>
        <tr>
            <td>Ngôn ngữ</td>
            <td>
                <asp:CheckBox runat="server" ID="ckbCSharp" Text="C#" />
                <asp:CheckBox runat="server" ID="ckbJavaScript" Text="JavaScript" />
                <asp:CheckBox runat="server" ID="ckbSQL" Text="SQL" />
            </td>
        </tr>
        <tr>
            <td>Trang cá nhân</td>
            <td>
                <asp:HyperLink runat="server"
                    Text="Twitter" Target="_blank"
                    ID="hlPersonal"
                    NavigateUrl="https://twitter.com/nnduy1996"
                    ImageUrl="~/Resources/Images/avatar1.jpg" />
            </td>
        </tr>
        <tr>
            <td>Đất nước
            </td>
            <td>
                <asp:DropDownList runat="server" ID="ddlCountries" CssClass="form-control" />
            </td>
        </tr>
        <tr>
            <td>Thành phố
            </td>
            <td>
                <asp:DropDownList runat="server" ID="ddlCities" CssClass="form-control" />
            </td>
        </tr>
        <tr>
            <td>Đội bóng
            </td>
            <td>
                <asp:CheckBoxList runat="server" ID="cblClub">
                    <asp:ListItem Value="1">Miuwaukee Bucks</asp:ListItem>
                    <asp:ListItem Value="2">Portland Trail Blazzers</asp:ListItem>
                    <asp:ListItem Value="3">Toronto Raptors</asp:ListItem>
                    <asp:ListItem Value="4">Golden State Warriors</asp:ListItem>
                </asp:CheckBoxList>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button runat="server" ID="btnSubmit" Text="Đăng ký" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:ImageButton runat="server" ID="imgBtnDelete" Text="Xóa" ToolTip="Xóa" ImageUrl="~/Resources/Images/delete.png" OnClientClick="alert('Are you sure to delete')" />
            </td>
        </tr>

        <tr>
            <td colspan="2">
                <asp:ImageButton runat="server" ID="imgBtnEdit" Text="Sửa" ToolTip="Sửa" ImageUrl="~/Resources/Images/edit.png" OnClientClick="return confirm('Are you sure to edit')" />
            </td>
        </tr>
    </table>
</asp:Content>
