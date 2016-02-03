<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PublicMaster.Master" AutoEventWireup="true" CodeBehind="PublicRegister.aspx.cs" Inherits="ISECCS_PJ.PublicPage.PublicRegister" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="../CSS/RegisterLogin.css" />
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <%-- Add Javascript for check at client side --%>
    <script language="javascript" type="text/javascript">
        function checkPassStrength() {
            var value = $('#<%=tb_password.ClientID %>').val();
            var score = 0;
            var status = "";
            var specialChars = "<>@!#$%^&*()_+[]{}?:;|'\"\\,./~`-="
            if (value.toString().length >= 8) {

                if (/[a-z]/.test(value)) {
                    score += 1;
                }
                if (/[A-Z]/.test(value)) {
                    score += 1;
                }
                if (/\d/.test(value)) {
                    score += 1;
                }
                for (i = 0; i < specialChars.length; i++) {
                    if (value.indexOf(specialChars[i]) > -1) {
                        score += 1;
                    }
                }
            }
            else {
                score = 1;
            }

            if (score == 2) {
                status = status = "<span style='color:#CCCC00'>Medium</span>";
            }
            else if (score == 3) {
                status = "<span style='color:#0DFF5B'>Strong</span>";
            }
            else if (score >= 4) {
                status = "<span style='color:#009933'>Very Strong</span>";
            }
            else {

                status = "<span style='color:red'>Week</span>";
            }
            if (value.toString().length > 0) {
                $('#<%=lblPasswordStrength.ClientID %>').html("Status :<span> " + status + "</span>");
            }
            else {
                $('#<%=lblPasswordStrength.ClientID %>').html("");
            }
        }
    </script>

    <div class="register-table">
        <div style="width: 100%; height: 100%; vertical-align: middle">
            <table class="nav-justified">
                <table align="center">
                    <tr>
                        <td style="width: 250px; font-size: xx-large; text-decoration: underline; height: 63px; vertical-align: middle"><strong>Registration</strong></td>
                    </tr>
                    <tr>
                        <td style="width: 250px; height: 62px; vertical-align: middle">Username:</td>
                        <td>
                            <asp:TextBox ID="tb_username" runat="server" Height="30px" Width="300px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td  style="width: 250px; height: 62px; vertical-align: middle">Password:</td>
                        <td>
                            <asp:TextBox ID="tb_password" runat="server" Height="30px" TextMode="Password" oncopy="return false" onpaste="return false" oncut="return false" ondelete="return false" Width="300px" ToolTip="Password must include alphanumeric, special characters, upper and lower case characters."></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 250px; height: 62px; vertical-align: middle">Confirm Password:</td>
                        <td>
                            <asp:TextBox ID="tb_cpassword" runat="server" Height="30px" TextMode="Password" oncopy="return false" onpaste="return false" oncut="return false" ondelete="return false" Width="300px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 250px; height: 62px; vertical-align: middle">Email:</td>
                        <td>
                            <asp:TextBox ID="tb_email" runat="server" Height="30px" Width="300px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 250px; height: 62px; vertical-align: middle">Name:</td>
                        <td>
                            <asp:TextBox ID="tb_name" runat="server" Height="30px" Width="300px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 250px; height: 62px; vertical-align: middle">Contact:</td>
                        <td>
                            <asp:TextBox ID="tb_contact" runat="server" Height="30px" Width="300px" ToolTip="Contact Number must be 8 digits."></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 250px; height: 62px; vertical-align: middle">Security Code:</td>
                        <td>
                            <asp:Image ID="imgCatpcha" runat="server" ImageUrl="~/PublicPage/CaptchaImage.aspx" />
                            <br />
                            [Case sensitive]</td>
                    </tr>
                    <tr>
                        <td style="width: 250px; height: 62px; vertical-align: middle">Type Security Code here:</td>
                        <td>
                            <asp:TextBox ID="txtCaptchaText" runat="server" Width="300px" Height="30px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 250px; height: 62px; vertical-align: middle">&nbsp;</td>
                        <td>
                            <asp:Button ID="btn_register" runat="server" OnClick="btn_register_Click" Text="Register" Width="100px" />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btn_clear" runat="server" Text="Clear" Width="100px" OnClick="btn_clear_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 250px">&nbsp;</td>
                        <td>
                            <asp:Label ID="lbl_msg" runat="server" Font-Size="Medium" ForeColor="#CC0000"></asp:Label>
                            <br />
                            <asp:Label ID="lbl_msg2" runat="server"></asp:Label>
                            <br />
                            <asp:Label ID="lblPasswordStrength" runat="server" ForeColor="#CC0000"></asp:Label>
                            <br />
                            <br />
                            <asp:Button ID="btn_sendemail" runat="server" Width="100px" OnClick="btn_sendemail_Click" Text="Send Email" />
                        </td>
                    </tr>
                </table>
            </table>
        </div>
    </div>
</asp:Content>
