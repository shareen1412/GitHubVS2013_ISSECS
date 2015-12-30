<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/UserMaster.Master" AutoEventWireup="true" CodeBehind="UserWatermarking.aspx.cs" Inherits="ISECCS_PJ.UserPage.UserWatermarking" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="head" runat="server">
    <script src="../JavaScript/PreviewImage.js" type="text/javascript"></script>
    <style type="text/css">
        .auto-style1 {
            width: 94px;
            height: 21px;
        }
        .auto-style2 {
            height: 21px;
        }
    </style>
    <script type="text/javascript">

    </script>
</asp:Content>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <table class="nav-justified">
        <tr>
            <td style="width: 94px">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td colspan="3">
                <h3>Step 1: Upload Your File</h3>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 94px; height: 30px;"></td>
            <td colspan="2" style="height: 30px">
                <asp:FileUpload ID="fu_fileName" runat="server" onchange="readURL(this);"/>
            </td>
        </tr>
        <tr>
            <td style="width: 94px">&nbsp;</td>
            <td colspan="2">&nbsp;</td>
        </tr>
        <tr>
            <td colspan="3" class="auto-style1">
                <h3>Step 2: Set Watermark Properties</h3>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 94px">&nbsp;</td>
            <td rowspan="13">
                <asp:Image ID="img_userImage" runat="server"/>
            </td>
            <td>Watermark Text:&nbsp; &nbsp;<asp:TextBox ID="tb_watermarkText" placeholder="Your text here" runat="server"></asp:TextBox></td>
        </tr>
<%--        <tr>
            <td style="width: 94px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 94px">&nbsp;</td>
            <td>Font Type:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="ddl_fontType" runat="server" Height="22px" Width="158px">
            </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="auto-style1"></td>
            <td class="auto-style2"></td>
        </tr>
        <tr>
            <td style="width: 94px">&nbsp;</td>
            <td>Font Size:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="ddl_fontSize" runat="server" Height="22px" Width="158px">
            </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="width: 94px; height: 21px;"></td>
            <td style="height: 21px"></td>
        </tr>
        <tr>
            <td class="auto-style1"></td>
            <td class="auto-style2">Font Colour:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="ddl_fontColour" runat="server" Height="22px" Width="158px">
            </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="width: 94px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>--%>
<%--        <tr>
            <td style="width: 94px">&nbsp;</td>
            <td>Transparency:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="ddl_transparency" runat="server" Height="22px" Width="158px">
            </asp:DropDownList>
            </td>
        </tr>--%>
        <tr>
            <td style="width: 94px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 94px">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 94px">&nbsp;</td>
            <td>
                <asp:Button ID="bn_preview" runat="server" OnClick="bn_preview_Click" Text="Preview" />
                <asp:Button ID="bn_upload" runat="server" Text="Upload" />
                <asp:Button ID="bn_download" runat="server" Text="Download" OnClick="bn_download_Click" />
                <asp:Button ID="bn_back" runat="server" OnClick="bn_back_Click" Text="Back" />
            </td>
        </tr>
    </table>
</asp:Content>
