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
                <asp:CheckBox runat="server" Text="Select All" ID="cbSelectAll"/>
                <asp:CheckBoxList runat="server" ID="cblClub" RepeatDirection="Vertical">
                    <asp:ListItem Value="1">Miuwaukee Bucks</asp:ListItem>
                    <asp:ListItem Value="2">Portland Trail Blazzers</asp:ListItem>
                    <asp:ListItem Value="3">Toronto Raptors</asp:ListItem>
                    <asp:ListItem Value="4">Golden State Warriors</asp:ListItem>
                </asp:CheckBoxList>
            </td>
        </tr>
        <tr>
            <td>
                ListBox
            </td>
            <td>
                <asp:ListBox runat="server" ID="lbRapper" Rows="5" SelectionMode="Multiple" Width="300">
                    <asp:ListItem Value="1" Text="Eminem"/>
                    <asp:ListItem Value="2" Text="2Pac"/>
                    <asp:ListItem Value="3" Text="Snoop Dogg"/>
                    <asp:ListItem Value="4" Text="JayZ"/>
                    <asp:ListItem Value="5" Text="Notorious B.I.G"/>
                </asp:ListBox>
            </td>
        </tr>
        <tr>
            <td>Real time listbox checkbox</td>
            <td>
                <asp:CheckBoxList runat="server" ID="cbRealTimeFC">
                    <asp:ListItem Value="1" Text="Real Madrid"/>
                    <asp:ListItem Value="2" Text="Barcelona"/>
                    <asp:ListItem Value="3" Text="Liverpool"/>
                    <asp:ListItem Value="4" Text="Juventus"/>
                    <asp:ListItem Value="5" Text="Manchester City"/>
                </asp:CheckBoxList>

                <asp:ListBox runat="server" ID="lbRealTimeFC" SelectionMode="Multiple"/>
            </td>
        </tr>
        <tr>
            <td>
                Radio List:
            </td>
            <td>
                <asp:RadioButtonList runat="server" ID="rblBestNbaPlayer" RepeatDirection="Vertical" RepeatLayout="UnorderedList">
                    <asp:ListItem value="1" Text="Michael Jordan"/>
                    <asp:ListItem value="2" Text="Kobe Bryant"/>
                    <asp:ListItem value="3" Text="Lebron James"/>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label runat="server" AssociatedControlID="fuAvatar" ID="lblAvatar" Text="Ảnh đại diện"/>
            </td>
            <td>
                <asp:FileUpload runat="server" ID="fuAvatar"/>
            </td>
        </tr>
        <tr>
            <td>
                Bulleted List:
            </td>
            <td>
                <asp:BulletedList runat="server" 
                    ID="bllAnimal"
                    DisplayMode="HyperLink"
                    BulletStyle="CustomImage" 
                    BulletImageUrl="~/Resources/Images/edit.png" Target="_blank">
                    <asp:ListItem Value="http://youtube.com" Text="Human"></asp:ListItem>
                    <asp:ListItem Value="http://google.com" Text="AI"></asp:ListItem>
                    <asp:ListItem Value="3" Text="Monkey"></asp:ListItem>
                    <asp:ListItem Value="4" Text="Crocodile"></asp:ListItem>
                    <asp:ListItem Value="5" Text="Horse"></asp:ListItem>
                </asp:BulletedList>
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
