<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/UserMaster.Master" AutoEventWireup="true" CodeBehind="UserChangePassword.aspx.cs" Inherits="ISECCS_PJ.UserPage.UserChangePassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table class="nav-justified">
        <table align="center">
        <tr>
            <td style="width: 356px; height: 62px">
    <h1>Change Password</h1>
            </td>
            <td style="height: 62px">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 356px; height: 62px">Old Password:</td>
            <td style="height: 62px">
                <asp:TextBox ID="tb_oldpwd" runat="server" Height="35px" TextMode="Password" Width="221px" oncopy="return false" onpaste="return false" oncut="return false" ondelete="return false"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 356px; height: 62px">New Password:</td>
            <td style="height: 62px">
                <asp:TextBox ID="tb_newpwd" runat="server" Height="35px" TextMode="Password" Width="221px" oncopy="return false" onpaste="return false" oncut="return false" ondelete="return false"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 356px; height: 62px">Confirm New Password:</td>
            <td style="height: 62px">
                <asp:TextBox ID="tb_confirmnewpwd" runat="server" Height="35px" TextMode="Password" Width="221px" oncopy="return false" onpaste="return false" oncut="return false" ondelete="return false"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 356px">&nbsp;</td>
            <td>
                <asp:Button ID="btn_reset" runat="server" Text="Reset" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btn_cancel" runat="server" Text="Cancel" />
            </td>
        </tr>
    </table>
        </table>
</asp:Content>
