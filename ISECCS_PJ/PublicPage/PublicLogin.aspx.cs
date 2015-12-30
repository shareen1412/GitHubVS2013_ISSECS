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
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lbtn_cantaccessaccount_Click(object sender, EventArgs e)
        {
            Response.Redirect("PublicCantAccessAccount.aspx");
        }
    }
}