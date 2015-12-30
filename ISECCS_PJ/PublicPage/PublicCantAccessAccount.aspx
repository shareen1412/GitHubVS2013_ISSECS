<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PublicMaster.Master" AutoEventWireup="true" CodeBehind="PublicCantAccessAccount.aspx.cs" Inherits="ISECCS_PJ.PublicPage.PublicCantAccessAccount" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table class="nav-justified">
        <table align="center">
        <tr>
            <td>
                <h1><span style="text-decoration: underline"><strong>Can&#39;t access your account?</strong></span></h1>
    <p style="font-size: x-large">
        We can help you reset your password.</p>
    <p style="font-size: x-large">
        First, please enter your email and follow the link sent to your email.</p>
                <table class="nav-justified">
                    <tr>
                        <td style="width: 162px; height: 62px;">Email:</td>
                        <td style="height: 62px">
                <asp:TextBox ID="tb_email" runat="server" Height="35px" TextMode="Email" Width="300px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 162px">&nbsp;</td>
                        <td>
                <asp:Button ID="btn_sendemail" runat="server" Text="Send Email" Width="150px"/>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btn_cancel" runat="server" Text="Cancel" Width="138px" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
        </table>
</asp:Content>
