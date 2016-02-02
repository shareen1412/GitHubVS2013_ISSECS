<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PublicMaster.Master" AutoEventWireup="true" CodeBehind="PublicRegister.aspx.cs" Inherits="ISECCS_PJ.PublicPage.PublicRegister" %>
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



    <div style ="width:100%;height:100%; vertical-align:middle">
    <table class="nav-justified"> 
        <table align="center"> 
           
        <tr>
            <td id="middle" style="width: 250px; font-size: xx-large; text-decoration: underline; height: 63px; vertical-align: middle"><strong>Registration</strong></td>
            <td id="middle" style="height: 63px; vertical-align: middle""></td>
        </tr>
        <tr>
            <td id="middle" style="width: 250px; height: 62px; vertical-align: middle">Username:</td>
            <td id="middle" style="height: 62px; vertical-align: middle"">
                <asp:TextBox ID="tb_username" runat="server" Height="35px" Width="300px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td id="middle" style="width: 250px; height: 62px; vertical-align: middle">Password:</td>
            <td id="middle" style="height: 62px; vertical-align: middle"">
                <asp:TextBox ID="tb_password" runat="server" Height="35px" TextMode="Password" oncopy="return false" onpaste="return false" oncut="return false" ondelete="return false" Width="300px" ToolTip="Password must include alphanumeric, special characters, upper and lower case characters."></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td id="middle" style="width: 250px; height: 62px; vertical-align: middle">Confirm Password:</td>
            <td id="middle" style="height: 62px; vertical-align: middle"">
                <asp:TextBox ID="tb_cpassword" runat="server" Height="35px" TextMode="Password" oncopy="return false" onpaste="return false" oncut="return false" ondelete="return false" Width="300px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td id="middle" style="width: 250px; height: 62px; vertical-align: middle">Email:</td>
            <td id="middle" style="height: 62px; vertical-align: middle"">
                <asp:TextBox ID="tb_email" runat="server" Height="35px" Width="300px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td id="middle" style="width: 250px; height: 62px; vertical-align: middle">Name:</td>
            <td id="middle" style="height: 62px; vertical-align: middle"">
                <asp:TextBox ID="tb_name" runat="server" Height="35px" Width="300px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td id="middle" style="width: 250px; height: 62px; vertical-align: middle">Contact:</td>
            <td id="middle" style="height: 62px; vertical-align: middle"">
                <asp:TextBox ID="tb_contact" runat="server" Height="35px" Width="300px" ToolTip="Contact Number must be 8 digits."></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td id="middle" style="width: 250px; height: 62px; vertical-align: middle">Security Code:</td>
            <td id="middle" style="height: 62px; vertical-align: middle"">
                <asp:Image ID="imgCatpcha" runat="server" ImageUrl="~/PublicPage/CaptchaImage.aspx" />
            </td>
        </tr>
        <tr>
            <td id="middle" style="width: 250px; height: 62px; vertical-align: middle">&nbsp;</td>
            <td id="middle" style="height: 62px; vertical-align: middle"">
                [Case sensitive]</td>
        </tr>
        <tr>
            <td id="middle" style="width: 250px; height: 62px; vertical-align: middle">Type Security Code here:</td>
            <td id="middle" style="height: 62px; vertical-align: middle"">
                <asp:TextBox ID="txtCaptchaText" runat="server" Width="300px" Height="35px"></asp:TextBox>
                </td>
        </tr>
        <tr>
            <td id="middle" style="width: 250px; height: 62px; vertical-align: middle">&nbsp;</td>
            <td id="middle" style="height: 62px; vertical-align: middle"">
                <asp:Button ID="btn_register" runat="server" OnClick="btn_register_Click" Text="Register" Width="120px" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btn_clear" runat="server" Text="Clear" Width="120px" OnClick="btn_clear_Click" />
            </td>
        </tr>
        <tr>
            <td id="middle" style="width: 250px">&nbsp;</td>
            <td id="middle">
                <asp:Label ID="lbl_msg" runat="server" Font-Size="Medium" ForeColor="#CC0000"></asp:Label>
                <br />
                <asp:Label ID="lbl_msg2" runat="server"></asp:Label>
                <br />
                <asp:Label ID="lblPasswordStrength" runat="server" ForeColor="#CC0000"></asp:Label>
                <br />
            </td>
        </tr>
    </table>
        </table>
        
      </div>
</asp:Content>
