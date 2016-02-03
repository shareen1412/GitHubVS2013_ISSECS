<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/UserMaster.Master" AutoEventWireup="true" CodeBehind="UserResetPassword.aspx.cs" Inherits="ISECCS_PJ.UserPage.UserResetPassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {}
        .auto-style2 {
            width: 191px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table align="center">
        <tr>
            <td class="auto-style1" colspan="2">
                <h1>Reset Password</h1>
            </td>
        </tr>
        <tr>
            <td class="auto-style1" colspan="2">
                Hi
                <asp:Label ID="lbl_session2" runat="server"></asp:Label>
                ,</td>
        </tr>
        <tr>
            <td class="auto-style2">New Password:</td>
            <td style="height: 62px">
                <asp:TextBox ID="tb_newpwd" runat="server" Height="35px" TextMode="Password" Width="300px" oncopy="return false" onpaste="return false" oncut="return false" ondelete="return false" ToolTip="New password must include alphanumeric, special characters, upper and lower case characters."></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">Confirm New Password:</td>
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
                <br />
                <asp:Label ID="lblPasswordStrength" runat="server" ForeColor="#CC0000"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
