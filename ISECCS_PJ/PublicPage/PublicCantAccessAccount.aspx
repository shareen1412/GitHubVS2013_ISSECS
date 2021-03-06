﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PublicMaster.Master" AutoEventWireup="true" CodeBehind="PublicCantAccessAccount.aspx.cs" Inherits="ISECCS_PJ.PublicPage.PublicCantAccessAccount" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table class="nav-justified">
        <table align="center">
        <tr>
            <td>
                <h1><span style="text-decoration: underline"><strong>Can&#39;t access your account?</strong></span></h1>
    <p>
        We can help you reset your password.</p>
    <p>
        First, please enter your username or email and follow the link sent to your email.</p>
                <table class="nav-justified">
                    <tr>
                        <td style="width: 162px; height: 62px;">Username:</td>
                        <td style="height: 62px">
                            <asp:TextBox ID="tb_username" runat="server" Height="35px" Width="300px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style1"></td>
                        <td class="auto-style2">
                            OR</td>
                    </tr>
                    <tr>
                        <td style="width: 162px; height: 62px;">Email:</td>
                        <td style="height: 62px">
                <asp:TextBox ID="tb_email" runat="server" Height="35px" TextMode="Email" Width="300px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 162px">&nbsp;</td>
                        <td>
                <asp:Button ID="btn_sendemail" runat="server" Text="Send Email" Width="120px" OnClick="btn_sendemail_Click"/>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btn_clear" runat="server" Text="Clear" Width="120px" OnClick="btn_clear_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 162px">&nbsp;</td>
                        <td>
                            <asp:Label ID="lbl_msg" runat="server" ForeColor="#CC0000"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 162px">&nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
        </table>
</asp:Content>
<asp:Content ID="Content2" runat="server" contentplaceholderid="head">
    <style type="text/css">
        .auto-style1 {
            width: 162px;
            height: 29px;
        }
        .auto-style2 {
            height: 29px;
        }
    </style>
</asp:Content>

