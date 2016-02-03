<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/UserMaster.Master" AutoEventWireup="true" CodeBehind="CryptographyFile.aspx.cs" Inherits="ISECCS_PJ.UserPage.CryptographyFile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div style="margin-top: 100px; margin-left: 200px;">
        <div style="font-size: 20px;">
            <table class="nav-justified">
                <tr>
                    <td class="auto-style7">Enter plain text:</td>
                    <td>Enter ciphered text:</td>
                </tr>
                <tr>
                    <td class="auto-style7">
                        <asp:FileUpload ID="fileupload_en" runat="server" Width="320px" />
                    </td>
                    <td>
                        <asp:FileUpload ID="fileupload_de" runat="server" Width="320px" />
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
                        <asp:TextBox ID="tb_pw_en" runat="server" Width="320px" TextMode="Password"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="tb_pw_de" runat="server" TextMode="Password" Width="320px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style5"></td>
                    <td class="auto-style6"></td>
                </tr>
                <tr>
                    <td class="auto-style7">Ciphered text:</td>
                    <td>Enciphered text:</td>
                </tr>
                <tr>
                    <td class="auto-style7">
                        <asp:TextBox ID="tb_cipher_en" runat="server" Width="320px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="tb_plain_de" runat="server" Width="320px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style5">&nbsp;</td>
                    <td class="auto-style6"></td>
                </tr>
                <tr>
                    <td class="auto-style7" style="text-align: right;">
                        <asp:Button ID="btn_encrypt" runat="server" Text="Encrypt" OnClick="btn_encrypt_Click" />
                    </td>
                    <td>
                        <asp:Button ID="btn_decrypt" runat="server" Text="Decrypt" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
