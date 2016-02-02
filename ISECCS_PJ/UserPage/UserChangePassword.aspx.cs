using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using BusinessLogicLayer;
using DataAccessLayer;

//using System.Text;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
//using System.Security.Cryptography.RNGCryptoServiceProvider;
using System.Drawing;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;

namespace ISECCS_PJ.UserPage
{
    public partial class UserChangePassword : System.Web.UI.Page
    {
        private string _connStr = Properties.Settings.Default.DBConnStr;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_clear_Click(object sender, EventArgs e)
        {
            tb_oldpwd.Text = "";
            tb_newpwd.Text = "";
            tb_confirmnewpwd.Text = "";
            lbl_msg.Text = "";
        }

        protected void btn_reset_Click(object sender, EventArgs e)
        {
            //List<String> salthashList = null;
            ////List<String> namesList = null;

            //try
            //{
            //    string queryStr = "SELECT slowHashSalt FROM TableUser2 WHERE userName = @userName";
            //    SqlConnection conn = new SqlConnection(_connStr);
            //    SqlCommand cmd = new SqlCommand(queryStr, conn);

            //    conn.Open();

            //    SqlDataReader dr = cmd.ExecuteReader();

            //    while (dr.HasRows && dr.Read())
            //    {
            //        if (salthashList == null)
            //        {
            //            salthashList = new List<String>();
            //        }

            //        String saltHashes = dr.GetString(dr.GetOrdinal("slowHashSalt"));
            //        salthashList.Add(saltHashes);
            //    }
            //    dr.Close();

            //    //If not empty, means there are a few matching usernames
            //    if (salthashList != null)
            //    {
            //        for (int i = 0; i < salthashList.Count; i++)
            //        {
            //            queryStr = "";
            //            bool validUser = UserDAL.ValidatePassword(tb_oldpwd.Text, salthashList[i]);
            //            if (tb_oldpwd.Text == salthashList)
            //            {



            //            }
            //            else
            //            {
            //                lbl_msg.Text = "Passwords do not match/Old password not match. Please try again.";
            //            }
            //        }
            //    }


            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine("Error! " + ex.Message);
            //}

            ////Check old password entered and old password hash in database
            //string queryStr2 = "SELECT slowHashSalt FROM TableUser2 WHERE userName = @userName";
            //SqlConnection conn2 = new SqlConnection(_connStr);
            //SqlCommand cmd2 = new SqlCommand(queryStr2, conn2);

            //conn2.Open();
            //cmd2.Parameters.AddWithValue("@userName", Session["userName"]);

            ////Hash the old password
            ////Hashing
            //String saltHashReturned2 = UserDAL.CreateHash(tb_oldpwd.Text);
            //int commaIndex2 = saltHashReturned2.IndexOf(":");
            //String extractedString2 = saltHashReturned2.Substring(0, commaIndex2);
            //commaIndex2 = saltHashReturned2.IndexOf(":");
            //extractedString2 = saltHashReturned2.Substring(commaIndex2 + 1);
            //commaIndex2 = extractedString2.IndexOf(":");
            //String salt2 = extractedString2.Substring(0, commaIndex2);

            //commaIndex2 = extractedString2.IndexOf(":");
            //extractedString2 = extractedString2.Substring(commaIndex2 + 1);
            //String hash2 = extractedString2;
            ////from the first: to the second: is the salt
            ////from the second : to the end is the salt
            //cmd2.Parameters.AddWithValue("@slowHashSalt2", saltHashReturned2);

            //cmd2.ExecuteReader();

            //conn2.Close();

            

            //if (oldHashPassword.Length == oldHashDatabase.Length)
            //{
            //    lbl_msg.Text = "Old password MATCH.";
                //If new passwords match, hash new password and replaced the old password hash in the database.
                if (tb_newpwd.Text == tb_confirmnewpwd.Text)
                {
                    string queryStr = "UPDATE TableUser2 SET slowHashSalt = @slowHashSalt WHERE userName = @userName";
                    SqlConnection conn = new SqlConnection(_connStr);
                    SqlCommand cmd = new SqlCommand(queryStr, conn);

                    conn.Open();
                    cmd.Parameters.AddWithValue("@userName", Session["userName"]);
                    
                    //Hash the new password
                    //Hashing
                    String saltHashReturned = UserDAL.CreateHash(tb_newpwd.Text);
                    int commaIndex = saltHashReturned.IndexOf(":");
                    String extractedString = saltHashReturned.Substring(0, commaIndex);
                    commaIndex = saltHashReturned.IndexOf(":");
                    extractedString = saltHashReturned.Substring(commaIndex + 1);
                    commaIndex = extractedString.IndexOf(":");
                    String salt = extractedString.Substring(0, commaIndex);

                    commaIndex = extractedString.IndexOf(":");
                    extractedString = extractedString.Substring(commaIndex + 1);
                    String hash = extractedString;
                    //from the first: to the second: is the salt
                    //from the second : to the end is the salt
                    cmd.Parameters.AddWithValue("@slowHashSalt", saltHashReturned);

                    cmd.ExecuteReader();

                    conn.Close();
                    cmd.Dispose();
                    
                    lbl_msg2.ForeColor = Color.Green;
                    lbl_msg2.Text = "New password saved successfully.";
                    //Prevent too many resetting of passwords.
                    btn_reset.Enabled = false;
                }
                else
                {
                    //If new passwords do not match
                    lbl_msg2.Text = "Passwords do not match. Please try again.";
                }
            }
            //else
            //{
            //    //Old password is not correct
            //    lbl_msg.Text = "Old password does not match. Please try again.";
            //}

            
        
    }
}