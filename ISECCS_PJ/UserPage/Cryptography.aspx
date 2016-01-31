<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/UserMaster.Master" AutoEventWireup="true" CodeBehind="Cryptography.aspx.cs" Inherits="ISECCS_PJ.UserPage.Cryptography" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 251px;
            height: 26px;
        }
        .auto-style2 {
            height: 26px;
        }
        .auto-style5 {
            width: 251px;
            height: 28px;
        }
        .auto-style6 {
            height: 28px;
        }
        .auto-style7 {
            width: 251px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div style="margin-top: 100px; margin-left: 200px;">
        <div style="font-size: 20px;">
            <table class="nav-justified">
                <tr>
                    <td class="auto-style7">Select file:</td>
                    <td>Enter text:</td>
                </tr>
                <tr>
                    <td class="auto-style7">
                        <asp:FileUpload ID="fileUpload" runat="server" />
                    </td>
                    <td>
                        &nbsp;<asp:TextBox ID="txtPlain" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style7">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style1">Password:</td>
                    <td class="auto-style2">Password:</td>
                </tr>
                <tr>
                    <td class="auto-style7">
                        <asp:TextBox ID="tb_pw" runat="server" Width="320px"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="txtPlain0" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style5"></td>
                    <td class="auto-style6"></td>
                </tr>
                <tr>
                    <td class="auto-style7">
                        <asp:CheckBox ID="cb_watermark" runat="server" Text="  Include watermark" /></td>
                    <td>Enciphered text:</td>
                </tr>
                <tr>
                    <td class="auto-style7"></td>
                    <td>
                        <asp:TextBox ID="txtCipher" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style5"></td>
                    <td class="auto-style6"></td>
                </tr>
                <tr>
                    <td class="auto-style7" style="text-align: right;">
                        <asp:Button ID="btn_encrypt" runat="server" Text="Encrypt" OnClick="btn_encrypt_Click" />
                        </td>
                    <td>
                        <asp:Button ID="btn_decrypt" runat="server" Text="Decrypt" OnClick="btn_decrypt_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
