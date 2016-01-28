<%@ Page Title="Contact" Language="C#" MasterPageFile="~/MasterPage/PublicMaster.Master" AutoEventWireup="true" CodeBehind="PublicContact.aspx.cs" Inherits="ISECCS_PJ.PublicPage.PublicContact" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="../CSS/PublicContact.css"/>
</asp:Content>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <h1 class="h1Contact">Our developers:</h1>
    <br />
    <div class="row">
        <div class="contactInfo">
            <asp:Image ID="img_shareen" runat="server" ImageUrl="~/Images/girl-face-cartoon-md.png" Width="100px"/>
            <h2>Shareen</h2>
            <p>
                Contact no: 9486 9573
                <br />
                Email: <a href="mailto:shareen@gmail.com">shareen@gmail.com</a>
            </p>
        </div>
        <div class="contactInfo">
            <asp:Image ID="img_jane" runat="server" ImageUrl="~/Images/1195444816475588749Gerald_G_Lady_Face_Cartoon.svg.hi.png" Width="110px"/>
            <h2>Jane</h2>
            <p>
                Contact no: 8583 8640
                <br />
                Email: <a href="mailto:jane@gmail.com">jane@gmail.com</a>
            </p>
        </div>
        <div class="contactInfo">
            <asp:Image ID="img_guobao" runat="server" ImageUrl="~/Images/calm-clipart-7iaReRo5T.png" Width="113px"/>
            <h2>GuoBao</h2>
            <p>
                Contact no: 9475 9473
                <br />
                Email: <a href="mailto:guobao@gmail.com">guobao@gmail.com</a>
            </p>
        </div>
    </div>
</asp:Content>