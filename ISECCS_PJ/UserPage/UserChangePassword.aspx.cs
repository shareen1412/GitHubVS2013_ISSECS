using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ISECCS_PJ.UserPage
{
    public partial class UserChangePassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_clear_Click(object sender, EventArgs e)
        {
            tb_oldpwd.Text = "";
            tb_newpwd.Text = "";
            tb_confirmnewpwd.Text = "";
        }
    }
}