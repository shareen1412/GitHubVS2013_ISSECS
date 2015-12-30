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
                <asp:Button ID="btn_register" runat="server" Height="41px" Text="Register" Width="100px" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btn_cancel" runat="server" Height="41px" Text="Cancel" Width="108px" />
            </td>
        </tr>
    </table>
        </table>
</asp:Content>
