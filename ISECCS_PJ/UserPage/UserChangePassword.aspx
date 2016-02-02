<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/UserMaster.Master" AutoEventWireup="true" CodeBehind="UserChangePassword.aspx.cs" Inherits="ISECCS_PJ.UserPage.UserChangePassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table class="nav-justified">
        <table align="center">
        <tr>
            <td class="auto-style1" colspan="2">
    <h1>Change Password</h1>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">Old Password:</td>
            <td style="height: 62px">
                <asp:TextBox ID="tb_oldpwd" runat="server" Height="35px" TextMode="Password" Width="300px" oncopy="return false" onpaste="return false" oncut="return false" ondelete="return false"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">New Password:</td>
            <td style="height: 62px">
                <asp:TextBox ID="tb_newpwd" runat="server" Height="35px" TextMode="Password" Width="300px" oncopy="return false" onpaste="return false" oncut="return false" ondelete="return false"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">Confirm New Password:</td>
            <td style="height: 62px">
                <asp:TextBox ID="tb_confirmnewpwd" runat="server" Height="35px" TextMode="Password" Width="300px" oncopy="return false" onpaste="return false" oncut="return false" ondelete="return false"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td>
                <asp:Button ID="btn_reset" runat="server" Text="Reset Password" Width="129px" OnClick="btn_reset_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btn_clear" runat="server" Text="Clear" OnClick="btn_clear_Click" Width="120px" />
            </td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td>
                <asp:Label ID="lbl_msg" runat="server" ForeColor="#CC0000"></asp:Label>
                <br />
                <asp:Label ID="lbl_msg2" runat="server" ForeColor="#CC0000"></asp:Label>
            </td>
        </tr>
    </table>
        </table>
</asp:Content>
<asp:Content ID="Content2" runat="server" contentplaceholderid="head">
    <style type="text/css">
        .auto-style1 {
            height: 62px;
        }
        .auto-style2 {
            width: 250px;
        }
    </style>
</asp:Content>

