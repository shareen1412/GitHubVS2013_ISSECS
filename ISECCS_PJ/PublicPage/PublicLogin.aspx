<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PublicMaster.Master" AutoEventWireup="true" CodeBehind="PublicLogin.aspx.cs" Inherits="ISECCS_PJ.PublicPage.PublicLogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table class="nav-justified">
        <table align="center">
        <tr>
            <td class="modal-sm" style="text-decoration: underline; font-size: xx-large; width: 250px; height: 57px"><strong>Login</strong></td>
            <td style="height: 57px"></td>
        </tr>
        <tr>
            <td class="modal-sm" style="width: 250px; height: 62px">Username:</td>
            <td style="height: 62px">
                <asp:TextBox ID="tb_username" runat="server" Height="35px" Width="300px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="modal-sm" style="width: 250px; height: 62px">Password:</td>
            <td style="height: 62px">
                <asp:TextBox ID="tb_password" runat="server" Height="35px" TextMode="Password" oncopy="return false" onpaste="return false" oncut="return false" ondelete="return false" Width="300px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="modal-sm" style="width: 250px; height: 62px;"></td>
            <td style="height: 62px">
                <asp:LinkButton ID="lbtn_cantaccessaccount" runat="server" OnClick="lbtn_cantaccessaccount_Click">Can&#39;t access your account?</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td class="modal-sm" style="width: 250px">&nbsp;</td>
            <td>
                <asp:Button ID="btn_login" runat="server" Text="Login" Width="120px" OnClick="btn_login_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
                <asp:Button ID="btn_clear" runat="server" Text="Clear" Width="120px" OnClick="btn_clear_Click" />
                <br />
                <br />
                <asp:Label ID="lbl_msg" runat="server" ForeColor="Red"></asp:Label>
                <br />
                <asp:Label ID="lblMsg2" runat="server" ForeColor="#CC0000"></asp:Label>
                <br />
            </td>
        </tr>
        <tr>
            <td class="modal-sm" style="width: 250px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
        </table>
</asp:Content>
