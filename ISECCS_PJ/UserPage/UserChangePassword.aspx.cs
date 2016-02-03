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
        UserDAL userdal = new UserDAL();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_clear_Click(object sender, EventArgs e)
        {
            tb_oldpwd.Text = "";
            tb_newpwd.Text = "";
            tb_confirmnewpwd.Text = "";
            lbl_msg.Text = "";
            lbl_msg2.Text = "";
            lblPasswordStrength.Text = "";
        }

        //Password strength = very weak,weak, medium, strong and very strong.
        private int GetPasswordStrength(string password)
        {
            int Marks = 0;
            //check password strength
            if (password.Length < 6)
            {
                //very weak
                return 1;
            }
            else
            {
                Marks = 1;
            }
            if (System.Text.RegularExpressions.Regex.IsMatch(password, "[a-z]"))
            {
                //2 weak
                Marks++;
            }
            if (System.Text.RegularExpressions.Regex.IsMatch(password, "[A-Z]"))
            {
                //3 medium
                Marks++;
            }
            if (System.Text.RegularExpressions.Regex.IsMatch(password, "[0-9]"))
            {
                //4 strong
                Marks++;
            }
            if (System.Text.RegularExpressions.Regex.IsMatch(password, "[<,>,@,!,#,$,%,^,&,*,(,),_,+,\\[,\\],{,},?,:,;,|,',\\,.,/,~,`,-,=]"))
            {
                //5 very strong
                Marks++;
            }
            return Marks;

        }

        protected void btn_reset_Click(object sender, EventArgs e)
        {
            ////Check password strength
            //int marks = GetPasswordStrength(tb_newpwd.Text);
            //string status = "";
            //switch (marks)
            //{
            //    case 1:
            //        status = "Very Weak";
            //        break;
            //    case 2:
            //        status = "Weak";
            //        break;
            //    case 3:
            //        status = "Medium";
            //        break;
            //    case 4:
            //        status = "Strong";
            //        break;
            //    case 5:
            //        status = "Very Strong";
            //        break;
            //    default:
            //        break;
            //}

            ////If password meets the requirement
            //if (marks > 4)
            //{
            //    //If both new password textboxes match
            //    if(tb_newpwd.Text == tb_confirmnewpwd.Text)
            //    {
            //        string queryStr = "UPDATE TableUser2 SET slowHashSalt = @slowHashSalt WHERE userName = @userName";
            //        SqlConnection conn = new SqlConnection(_connStr);
            //        SqlCommand cmd = new SqlCommand(queryStr, conn);

            //        conn.Open();
            //        cmd.Parameters.AddWithValue("@userName", Session["userName"]);

            //        //Hash the new password
            //        //Hashing
            //        String saltHashReturned = UserDAL.CreateHash(tb_newpwd.Text);
            //        int commaIndex = saltHashReturned.IndexOf(":");
            //        String extractedString = saltHashReturned.Substring(0, commaIndex);
            //        commaIndex = saltHashReturned.IndexOf(":");
            //        extractedString = saltHashReturned.Substring(commaIndex + 1);
            //        commaIndex = extractedString.IndexOf(":");
            //        String salt = extractedString.Substring(0, commaIndex);

            //        commaIndex = extractedString.IndexOf(":");
            //        extractedString = extractedString.Substring(commaIndex + 1);
            //        String hash = extractedString;
            //        //from the first: to the second: is the salt
            //        //from the second : to the end is the salt
            //        cmd.Parameters.AddWithValue("@slowHashSalt", saltHashReturned);

            //        cmd.ExecuteReader();

            //        conn.Close();
            //        cmd.Dispose();

            //        lbl_msg2.ForeColor = Color.Green;
            //        lbl_msg2.Text = "New password saved successfully.";

            //        //to prevent too many resetting of passwords
            //        btn_reset.Enabled = false;

            //        lblPasswordStrength.ForeColor = Color.Green;
            //        lblPasswordStrength.Text = "Password strength: " + status;
            //    }
            //    else
            //    {
            //        lbl_msg.Text = "Both passwords do not match. Please try again.";
            //    }
            //}
            //else
            //{
            //    lbl_msg.Text = "New password does not meet the requirement of alphanumeric, special characters, upper and lower case characters. Please try again";
            //}


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

            //check hashed value of entered password and current password hash
            //string queryStr2 = "SELECT slowHashSalt FROM TableUser2 WHERE userName = @userName";
            //SqlConnection conn2 = new SqlConnection(_connStr);
            //SqlCommand cmd2 = new SqlCommand(queryStr2, conn2);

            //conn2.Open();
            //cmd2.Parameters.AddWithValue("@userName", Session["userName"]);

            ////Hash the old password
            ////Hashing
            //String saltHashReturned2 = UserDAL.CreateHash(tb_oldpwd.Text); // can
            //int commaIndex2 = saltHashReturned2.IndexOf(":");
            //String extractedString2 = saltHashReturned2.Substring(0, commaIndex2); // get string "1000"
            //commaIndex2 = saltHashReturned2.IndexOf(":"); 
            //extractedString2 = saltHashReturned2.Substring(commaIndex2 + 1); //
            //commaIndex2 = extractedString2.IndexOf(":");
            //String salt2 = extractedString2.Substring(0, commaIndex2);

            //commaIndex2 = extractedString2.IndexOf(":");
            //extractedString2 = extractedString2.Substring(commaIndex2 + 1);
            //String hash2 = extractedString2;
            ////from the first: to the second: is the salt
            ////from the second : to the end is the salt
            //cmd2.Parameters.AddWithValue("@slowHashSalt2", saltHashReturned2);

            /*------*/
            //string username = Session["userName"].ToString();
            //string enteredPasswordHash = UserDAL.CreateHash(tb_oldpwd.Text);
            //string dbPasswordHash = userdal.RetrieveHash(username);
            //if (enteredPasswordHash == dbPasswordHash)
            //{
            //    if (tb_newpwd.Text == tb_confirmnewpwd.Text)
            //    {
            //        string newPasswordHash = UserDAL.CreateHash(tb_newpwd.Text);
            //        userdal.UpdatePassword(newPasswordHash, username);
            //    }
            //    else
            //    {
            //        //If new passwords do not match
            //        lbl_msg2.Text = "Passwords do not match. Please try again.";
            //    }
            //}
            //else if (enteredPasswordHash != dbPasswordHash)
            //{
            //    //Old password is not correct
            //     lbl_msg.Text = "Old password does not match. Please try again.";
            //}
            /*------*/

            //cmd2.ExecuteReader();

            //conn2.Close();

            //SqlDataAdapter sda = new SqlDataAdapter("SELECT slowHashSalt FROM TableUser2 WHERE Password = '" + tb_oldpwd.Text + "' ",conn2);
            //DataTable dt = new DataTable();
            //sda.Fill(dt);

            //if(dt.Rows.Count.ToString() == "1")
            //{
            //    if (tb_newpwd.Text == tb_confirmnewpwd.Text)
            //    {
            //        conn2.Open();
            //        SqlCommand cmd = new SqlCommand("UPDATE TableUser2 SET slowHashSalt = @slowHashSalt WHERE userName = @userName");
            //        cmd.ExecuteNonQuery();
            //        conn2.Close();

            //    }
            //}


            ////if (oldHashPassword.Length == oldHashDatabase.Length)
            ////{
            ////    lbl_msg.Text = "Old password MATCH.";

            //Check password strength
            int marks = GetPasswordStrength(tb_newpwd.Text);
            string status = "";
            switch (marks)
            {
                case 1:
                    status = "Very Weak";
                    break;
                case 2:
                    status = "Weak";
                    break;
                case 3:
                    status = "Medium";
                    break;
                case 4:
                    status = "Strong";
                    break;
                case 5:
                    status = "Very Strong";
                    break;
                default:
                    break;
            }

            //If password meets the requirement
            if (marks >= 4)
            {

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
            else
            {
                lblPasswordStrength.Text = "Password strength: " + status + ". Please try again.";
            }

            //}
            //else
            //{
            //    //Old password is not correct
            //    lbl_msg.Text = "Old password does not match. Please try again.";
            //}


        }
    }
}