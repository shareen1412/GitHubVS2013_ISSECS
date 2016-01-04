<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PublicMaster.Master" AutoEventWireup="true" CodeBehind="PublicRegisterCaptcha.aspx.cs" Inherits="ISECCS_PJ.PublicPage.PublicRegisterCaptcha" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table class="nav-justified">
        <table align="center">
        <tr>
            <td>
                <br />
                Visual Captcha</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btn_register" runat="server" Height="30px" Text="Register" Width="120px" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btn_cancel" runat="server" Height="30px" Text="Cancel" Width="120px" />
                <br />
                <br />
                <asp:Button ID="btn_back" runat="server" OnClick="btn_back_Click" Text="Back" Width="120px" />
            </td>
        </tr>
    </table>
        </table>
</asp:Content>
