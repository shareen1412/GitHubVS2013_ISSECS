<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/UserMaster.Master" AutoEventWireup="true" CodeBehind="UserWatermarking.aspx.cs" Inherits="ISECCS_PJ.UserPage.UserWatermarking" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="../CSS/UserWatermark.css" />
    <style type="text/css">
        .auto-style1 {
            color: #2C2C2C;
        }
    </style>
</asp:Content>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="watermark-properties">
        <div class="watermark-properties-text">
            <h4>Watermark Properties:</h4>
            <ol>
                <li>Default colour for watermark text is <span class="auto-style1">#2C2C2C</span></li>
                <li>Position of watermark text is at bottom left of the image</li>
                <li>Transparency of watermark text is set at 30%</li>
                <li>Font size and family of text is 16 and Arial</li>
            </ol>
        </div>

        <div class="watermark-properties-image">
            Example:
            <asp:Image class="effectfront" ID="Image1" runat="server" Height="53px" ImageUrl="~/Images/974c9ec6-2412-4899-b49a-b7d4b686c31a.jpg" Width="90px" />
        </div>
        <br />
    </div>

    <div class="set-watermark">
        <div class="user-watermark">
            <table class="nav-justified">
                <tr>
                    <td colspan="3">
                        <h3>Step 1: Upload your file</h3>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 94px; height: 30px;"></td>
                    <td colspan="2" style="height: 30px">
                        <asp:FileUpload ID="fu_fileName" runat="server" onchange="readURL(this);" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 94px">&nbsp;</td>
                    <td colspan="2">&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="3">
                        <h3>Step 2: Set watermark text</h3>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 94px">&nbsp;</td>
                    <td rowspan="5">
                        <asp:Image ID="img_userImage" runat="server" />
                    </td>
                    <td rowspan="2">Watermark Text:&nbsp; &nbsp;<asp:TextBox ID="tb_watermarkText" placeholder="Your text here" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 94px">&nbsp;</td>
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
                        <%--<asp:Button ID="bn_back" runat="server" OnClick="bn_back_Click" Text="Back" />--%>
                    </td>
                </tr>
                <tr>
                    <td style="width: 94px">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="3">
                        <h3>Step 3: Upload/download your file</h3>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;
                    </td>
                    <td colspan="2">
                        <asp:Button ID="bn_upload" runat="server" Text="Upload" OnClick="bn_upload_Click" />
                        <asp:Button ID="bn_download" runat="server" Text="Download" OnClick="bn_download_Click" /></td>
                    </td>
                    </table>
            <br />
        </div>
    </div>
</asp:Content>
