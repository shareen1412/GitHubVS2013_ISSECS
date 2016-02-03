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
    public partial class UserResetPassword : System.Web.UI.Page
    {
        private string _connStr = Properties.Settings.Default.DBConnStr;
        protected void Page_Load(object sender, EventArgs e)
        {
            //lbl_session2.Text = Session["UserName"].ToString();
            lbl_session2.Text = Request.QueryString["UserName"];
        }

        protected void btn_clear_Click(object sender, EventArgs e)
        {
            tb_newpwd.Text = "";
            tb_confirmnewpwd.Text = "";
            lbl_msg.Text = "";
            lbl_msg2.Text = "";
            lblPasswordStrength.Text = "";
        }

        protected void btn_reset_Click(object sender, EventArgs e)
        {
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
            if(marks >= 4)
            {
                //If both new password textboxes match
                if (tb_newpwd.Text == tb_confirmnewpwd.Text)
                {
                    string queryStr = "UPDATE TableUser2 SET slowHashSalt = @slowHashSalt WHERE userName = @userName";
                    SqlConnection conn = new SqlConnection(_connStr);
                    SqlCommand cmd = new SqlCommand(queryStr, conn);

                    conn.Open();
                    cmd.Parameters.AddWithValue("@userName", lbl_session2.Text);

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
                    lbl_msg.Text = "";

                    //to prevent too many resetting of passwords
                    btn_reset.Enabled = false;

                    lblPasswordStrength.ForeColor = Color.Green;
                    lblPasswordStrength.Text = "Password strength: " + status;
                
                }
                else
                {
                    lbl_msg.Text = "Both passwords do not match. Please try again.";   
                }
            
            }
            else
            {
                lblPasswordStrength.Text = "Password strength: " + status + ". Please try again.";
            }
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

    }
}