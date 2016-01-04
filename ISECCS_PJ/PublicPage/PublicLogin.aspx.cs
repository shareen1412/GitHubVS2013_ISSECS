using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogicLayer;
using DataAccessLayer;

namespace ISECCS_PJ.PublicPage
{
    public partial class PublicLogin : System.Web.UI.Page
    {
        UserBLL userbll = new UserBLL();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lbtn_cantaccessaccount_Click(object sender, EventArgs e)
        {
            Response.Redirect("PublicCantAccessAccount.aspx");
        }

        protected void btn_login_Click(object sender, EventArgs e)
        {
            try
            {
                string message = "";

                message = userbll.LoginUser(tb_username.Text, tb_password.Text);

                if (message == "Login successful.")
                {
                    lbl_msg.Text = "Successful Login.";

                    tb_username.Text = "";
                    tb_password.Text = "";

                    Response.Redirect("~/UserPage/UserHome.aspx");
                }
                else if (message == "Invalid username/password. Please try again.")
                    lbl_msg.Text = message;
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('An error occurred. Please try again.')</script>");
            }

            
        }

        protected void btn_clear_Click(object sender, EventArgs e)
        {
            tb_username.Text = "";
            tb_password.Text = "";
        }
    }
}