<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/MasterPage/PublicMaster.Master" AutoEventWireup="true" CodeBehind="PublicHome.aspx.cs" Inherits="ISECCS_PJ.PublicPage.PublicHome" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <div class="jumbotron">
        <h1 class="h1Home">Protect your files now</h1>
        <br />
        <p class="lead">
            &Tab; Register with us today and use our free services that are available to you.
        </p>
        <%--<p><a href="#" class="btn btn-primary btn-lg">Learn more &raquo;</a></p>--%>
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>Encryption</h2>
            <p>
               Encrypt your files to prevent unauthorised access with our encryption service.
            </p>
            <p>
                <a class="btn btn-default" href="#">Learn more &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Steganography</h2>
            <p>
                Hiding messages behind your pictures? Steganography allows you to do it!
            </p>
            <p>
                <a class="btn btn-default" href="#">Learn more &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Watermarking</h2>
            <p>
                Prevent your image from being copyright by using our watermark 
                service that are available.
            </p>
            <p>
                <a class="btn btn-default" href="#">Learn more &raquo;</a>
            </p>
        </div>
    </div>

</asp:Content>
