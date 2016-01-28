<%@ Page Title="Home" Language="C#" MasterPageFile="~/MasterPage/UserMaster.Master" AutoEventWireup="true" CodeBehind="UserHome.aspx.cs" Inherits="ISECCS_PJ.UserPage.UserHome" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <br />
                <%--Framework Scripts--%>Welcome,&nbsp;
                <asp:Label ID="lbl_session2" runat="server"></asp:Label>
                !</p>
</asp:Content>
