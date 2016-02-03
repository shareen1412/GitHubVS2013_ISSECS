using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;

namespace ISECCS_PJ.UserPage
{
    public partial class UserHome : System.Web.UI.Page
    {
        private string _connStr = Properties.Settings.Default.DBConnStr;

        protected void Page_Load(object sender, EventArgs e)
        {
            string queryStr = "SELECT * FROM FileStorage WHERE userName = '" + Session["UserName"] + "' ORDER BY currentTimeDate DESC";

            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);

            try
            {
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                //while (dr.Read())
                //{
                    //Label1.Text = dr["userName"].ToString();
                    //Image1.ImageUrl = dr["fileName"].ToString();
                    //Label2.Text = dr["currentTimeDate"].ToString() + " (GMT +8)";
                //}
                GridView1.DataSource = dr;
                GridView1.DataBind();

                if (GridView1.Rows.Count == 0)
                {
                    GridView1.Visible = false;
                    lbl_msg.Visible = true;
                }
                else if (GridView1.Rows.Count > 0)
                {
                    GridView1.Visible = true;
                    lbl_msg.Visible = false;
                }

            }//try
            catch
            {

            }//catch

            finally
            {
                conn.Close();
                conn.Dispose();
                cmd.Dispose();
            }//finally
        }//page_load

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }//class
}//namespace