using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using BusinessLogicLayer;
using DataAccessLayer;

using System.Text;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
//using System.Security.Cryptography.RNGCryptoServiceProvider;

using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;
namespace ISECCS_PJ.PublicPage
{
    public partial class PublicLogin : System.Web.UI.Page
    {
        UserBLL userbll = new UserBLL();
        UserDAL userdal = new UserDAL();

        private string _connStr = Properties.Settings.Default.DBConnStr;

        protected void Page_Load(object sender, EventArgs e)
        {
            Session["UserName"] = tb_username.Text;

            tb_username.Focus();
        }

        protected void lbtn_cantaccessaccount_Click(object sender, EventArgs e)
        {
            Response.Redirect("PublicCantAccessAccount.aspx");
        }

        protected void btn_login_Click(object sender, EventArgs e)
        {

            if (tb_username.Text == "")
            {
                lbl_msg.Text = "Please enter your username.";
            }
            if (tb_password.Text == "")
            {
                lblMsg2.Text = "Please enter your password.";
            }
            else
            {
                if (checkAgainstSQLinjection(tb_username.Text) == true)// && checkAgainstSQLinjection(tb_password.Text) == true)
                {
                     
                    LoginWithPasswordHashFunction();
                    //string passwordhash = userdal.RetrieveHash(tb_username.Text);
                }
                else
                {
                    lbl_msg.Text = "Please don't insert any SQL injection.";
                }
            }

            
            //if (checkAgainstSQLinjection(tb_username.Text) == true && checkAgainstSQLinjection(tb_password.Text) == true)
            //{
            //    //try
            //    //{
            //    //    string message = "";
                    
            //    //    message = userbll.LoginUser(tb_username.Text, tb_password.Text);
            //    //    //lbl_msg.Text = "bye";
            //    //    if (message == "Login successful.")
            //    //    {
            //    //        lbl_msg.Text = "Successful Login.";

            //    //        tb_username.Text = "";
            //    //        tb_password.Text = "";
            //    //        lbl_msg.Text = "bye";
            //    //        //Session["userName"] = namesList[i];
            //    //        //Response.BufferOutput = true;
            //    //        Response.Redirect("~/UserPage/UserHome.aspx");//, false);
            //    //    }
            //    //    else if (message == "User is not authenticated. Please try again.")
            //    //        lbl_msg.Text = message;
            //    //}
            //    List<String> salthashList = null;
            //    List<String> namesList = null;

            //    try
            //    {
            //        String connString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();

            //        string queryStr = "SELECT userName, slowHashSalt FROM TableUser2 WHERE userName = @userName";

            //        SqlConnection conn = new SqlConnection(connString);
            //        SqlCommand cmd = new SqlCommand(queryStr, conn);

            //        conn.Open();

            //        cmd.Parameters.AddWithValue("@userName", tb_username.Text);
            //        SqlDataReader dr = cmd.ExecuteReader();

            //        while (dr.HasRows && dr.Read())
            //        {
            //            if (salthashList == null)
            //            {
            //                salthashList = new List<String>();
            //                namesList = new List<String>();
            //            }

            //            String saltHashes = dr.GetString(dr.GetOrdinal("slowHashSalt"));
            //            salthashList.Add(saltHashes);

            //            String username = dr.GetString(dr.GetOrdinal("userName"));
            //            namesList.Add(username);
            //        }
            //        //conn.Close();
            //        dr.Close();
            //        //dr.Dispose();

            //        //If not empty, means there are a few matching usernames
            //        if (salthashList != null)
            //        {
            //            for (int i = 0; i < salthashList.Count; i++)
            //            {
            //                queryStr = "";
            //                bool validUser = UserDAL.ValidatePassword(tb_password.Text, salthashList[i]);
            //                if (validUser == true)
            //                {
            //                    Session["userName"] = namesList[i];
            //                    Response.BufferOutput = true;
            //                    Response.Redirect("~/UserPage/UserHome.aspx", false);


            //                }
            //                else
            //                {
            //                    lbl_msg.Text = "User is not authenticated. Please try again.";
            //                }
            //            }
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        Response.Write("<script>alert('An error occurred. Please try again.')</script>");
            //    }
            //}
            //else
            //{
            //    lbl_msg.Text = "Please don't insert any SQL injection.";
            //}
         }

        public void LoginWithPasswordHashFunction()
        {
            List<String> salthashList = null;
            List<String> namesList = null;

            try
            {
                string queryStr = "SELECT userName, slowHashSalt FROM TableUser2 WHERE userName = @userName";

                SqlConnection conn = new SqlConnection(_connStr);
                SqlCommand cmd = new SqlCommand(queryStr, conn);

                conn.Open();

                cmd.Parameters.AddWithValue("@userName", tb_username.Text);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.HasRows && dr.Read())
                {
                    if (salthashList == null)
                    {
                        salthashList = new List<String>();
                        namesList = new List<String>();
                    }

                    String saltHashes = dr.GetString(dr.GetOrdinal("slowHashSalt"));
                    salthashList.Add(saltHashes);

                    String username = dr.GetString(dr.GetOrdinal("userName"));
                    namesList.Add(username);
                }
                //conn.Close();
                dr.Close();
                //dr.Dispose();

                //If not empty, means there are a few matching usernames
                if (salthashList != null)
                {
                    for (int i = 0; i < salthashList.Count; i++)
                    {
                        queryStr = "";
                        bool validUser = UserDAL.ValidatePassword(tb_password.Text, salthashList[i]);
                        if (validUser == true)
                        {
                            Session["userName"] = namesList[i];
                            Response.BufferOutput = true;
                            Response.Redirect("~/UserPage/UserHome.aspx", false);


                        }
                        else
                        {
                            lbl_msg.Text = "Invalid username or password. Please try again.";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error! " + ex.Message);
            }
        }

        //To prevent SQL injection by checking aganist values.
        private bool checkAgainstSQLinjection(string userName)
        {
            var regExpression = new System.Text.RegularExpressions.Regex(@"^[a-zA-Z0-9]*$");
            if (regExpression.IsMatch(userName))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        protected void btn_clear_Click(object sender, EventArgs e)
        {
            tb_username.Text = "";
            tb_password.Text = "";
            lbl_msg.Text = "";
            lblMsg2.Text = "";
        }

        //protected void btn_hash_Click(object sender, EventArgs e)
        //{
        //    string hashresult = FormsAuthentication.HashPasswordForStoringInConfigFile(tb_password.Text, "SHA1");
        //    lbl_msg.Text = "Your hash is: " + hashresult;
        //}
    }
}