﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PublicMaster.Master" AutoEventWireup="true" CodeBehind="PublicRegister.aspx.cs" Inherits="ISECCS_PJ.PublicPage.PublicRegister" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div style ="width:100%;height:100%;text-align:center; vertical-align:middle">
    <table class="nav-justified"> 
        <table align="center"> 
           
        <tr>
            <td id="middle" style="width: 212px; font-size: xx-large; text-decoration: underline; height: 63px; vertical-align: middle"><strong>Registration</strong></td>
            <td id="middle" style="height: 63px; vertical-align: middle""></td>
        </tr>
        <tr>
            <td id="middle" style="width: 212px; height: 62px; vertical-align: middle"">Username:</td>
            <td id="middle" style="height: 62px; vertical-align: middle"">
                <asp:TextBox ID="tb_username" runat="server" Height="35px" Width="300px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td id="middle" style="width: 212px; height: 62px; vertical-align: middle"">Password:</td>
            <td id="middle" style="height: 62px; vertical-align: middle"">
                <asp:TextBox ID="tb_password" runat="server" Height="35px" TextMode="Password" oncopy="return false" onpaste="return false" oncut="return false" ondelete="return false" Width="300px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td id="middle" style="width: 212px; height: 62px; vertical-align: middle"">Confirm Password:</td>
            <td id="middle" style="height: 62px; vertical-align: middle"">
                <asp:TextBox ID="tb_cpassword" runat="server" Height="35px" TextMode="Password" oncopy="return false" onpaste="return false" oncut="return false" ondelete="return false" Width="300px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td id="middle" style="width: 212px; height: 62px; vertical-align: middle"">Email:</td>
            <td id="middle" style="height: 62px; vertical-align: middle"">
                <asp:TextBox ID="tb_email" runat="server" Height="35px" Width="300px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td id="middle" style="width: 212px; height: 62px; vertical-align: middle"">Name:</td>
            <td id="middle" style="height: 62px; vertical-align: middle"">
                <asp:TextBox ID="tb_name" runat="server" Height="35px" Width="300px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td id="middle" style="width: 212px; height: 62px; vertical-align: middle"">Contact:</td>
            <td id="middle" style="height: 62px; vertical-align: middle"">
                <asp:TextBox ID="tb_contact" runat="server" Height="35px" Width="300px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td id="middle" style="width: 212px">&nbsp;</td>
            <td id="middle">
                <asp:Button ID="btn_next" runat="server" Text="Next" Width="113px" OnClick="btn_next_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btn_cancel" runat="server" Text="Cancel" Width="123px" />
&nbsp;&nbsp;&nbsp;&nbsp; 
                <br />
                <br />
                <asp:Button ID="btn_register" runat="server" OnClick="btn_register_Click" Text="Register" />
                <br />
                <br />
                <asp:Label ID="lbl_msg" runat="server" Font-Size="Medium" ForeColor="#CC0000"></asp:Label>
            </td>
        </tr>
    </table>
        </table>
        
      </div>
</asp:Content>
