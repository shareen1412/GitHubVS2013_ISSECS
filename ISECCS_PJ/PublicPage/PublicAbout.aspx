<%@ Page Title="About" Language="C#" MasterPageFile="~/MasterPage/PublicMaster.Master" AutoEventWireup="true" CodeBehind="PublicAbout.aspx.cs" Inherits="ISECCS_PJ.PublicPage.PublicAbout" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="../CSS/PublicAbout.css" />
</asp:Content>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="rules">
        <div class="password-rule">
            <h1>Password Rule</h1>
            <ol>
                <li>Password must be alphanumeric</li>
                <li>Password must include special characters (For eg. "@", "%", "#")</li>
                <li>Password must contain both uppercase and lowercase</li>
            </ol>
        </div>

        <div class="watermark-rule">
            <h1>Watermark Rule</h1>
            <ol>
                <li>Only .jpg and .png files are accepted</li>
                <li>Watermark text cannot be left blank</li>
            </ol>
        </div>

        <div class="steganography-rule">
            <h1>Steganography Rule</h1>
        </div>

        <div class="cryptography-rule">
            <h1>Cryptography Rule</h1>
        </div>
    </div>
</asp:Content>
