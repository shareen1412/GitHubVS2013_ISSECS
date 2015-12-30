<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PublicMaster.Master" AutoEventWireup="true" CodeBehind="PublicLogin.aspx.cs" Inherits="ISECCS_PJ.PublicPage.PublicLogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table class="nav-justified">
        <table align="center">
        <tr>
            <td class="modal-sm" style="text-decoration: underline; font-size: xx-large; width: 235px; height: 57px"><strong>Login</strong></td>
            <td style="height: 57px"></td>
        </tr>
        <tr>
            <td class="modal-sm" style="width: 235px; height: 62px">Username:</td>
            <td style="height: 62px">
                <asp:TextBox ID="tb_username" runat="server" Height="35px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="modal-sm" style="width: 235px; height: 62px">Password:</td>
            <td style="height: 62px">
                <asp:TextBox ID="tb_password" runat="server" Height="35px" TextMode="Password" oncopy="return false" onpaste="return false" oncut="return false" ondelete="return false"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="modal-sm" style="width: 235px; height: 62px;"></td>
            <td style="height: 62px">
                <asp:LinkButton ID="lbtn_cantaccessaccount" runat="server" OnClick="lbtn_cantaccessaccount_Click">Can&#39;t access your account?</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td class="modal-sm" style="width: 235px">&nbsp;</td>
            <td>
                <asp:Button ID="btn_login" runat="server" Text="Login" Width="113px" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
                <asp:Button ID="btn_cancel" runat="server" Text="Cancel" />
            </td>
        </tr>
        <tr>
            <td class="modal-sm" style="width: 235px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
        </table>
</asp:Content>
