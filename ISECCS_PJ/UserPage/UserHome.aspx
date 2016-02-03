<%@ Page Title="Home" Language="C#" MasterPageFile="~/MasterPage/UserMaster.Master" AutoEventWireup="true" CodeBehind="UserHome.aspx.cs" Inherits="ISECCS_PJ.UserPage.UserHome" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="../CSS/UserHome.css" />
    <style>
        .header-centre th {
            text-align: center;
        }

        .no-files{
            text-align:center;
            font-size: 50px;
            margin: 250px 0px 0px 0px;
            color:lightgray;
        }

        .now-hyper{
            color:lightgray;
        }
    </style>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="user-files">
        <asp:GridView ID="GridView1" class="header-centre" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" AutoGenerateColumns="False" GridLines="None" HorizontalAlign="Center" Width="1200px">
            <Columns>
                <asp:BoundField DataField="userName" HeaderText="Author" ItemStyle-HorizontalAlign="Center">
                    <HeaderStyle HorizontalAlign="Center" Height="50px" />
                    <ItemStyle HorizontalAlign="Center" Width="100px" />
                </asp:BoundField>
                <asp:ImageField DataImageUrlField="fileName" HeaderText="Files">
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    <ItemStyle Height="200px" HorizontalAlign="Center" VerticalAlign="Middle" Width="500px" />
                </asp:ImageField>
                <asp:BoundField DataField="currentTimeDate" HeaderText="Date/time uploaded <br/> (D/M/YYYY H:MM:SS)" HtmlEncode="false">
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="200px" />
                </asp:BoundField>
                <asp:ButtonField Text="Download">
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="200px" />
                </asp:ButtonField>
            </Columns>
            <EditRowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
        </asp:GridView>
    </div>
    <div class="no-files">
        <asp:Label ID="lbl_msg" runat="server">There are currently no files uploaded.
            <br />
            Get started <a class="now-hyper" href="UserWatermarking.aspx">now</a>
        </asp:Label>
    </div>
</asp:Content>
