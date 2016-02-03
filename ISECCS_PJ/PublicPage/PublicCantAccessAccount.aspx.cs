using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogicLayer;
using DataAccessLayer;

using System.Text;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Drawing;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace ISECCS_PJ.PublicPage
{
    public partial class PublicCantAccessAccount : System.Web.UI.Page
    {
        private string _connStr = Properties.Settings.Default.DBConnStr;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_clear_Click(object sender, EventArgs e)
        {
            tb_username.Text = "";
            tb_email.Text = "";
            lbl_msg.Text = "";
        }

        protected void btn_sendemail_Click(object sender, EventArgs e)
        {
            //SendEmail();
            SendEmailUniqueCode();
            
        }

        //use hotspot
        //if use school wifi, error: failure sending email
        //Send email with unique code generated
        public void SendEmailUniqueCode()
        {
            string uniqueCode = "";
            //SqlCommand cmd = new SqlCommand();
            SqlDataReader dr;
            try
            {
                string queryStr = "SELECT * FROM TableUser2 WHERE userName = @userName OR email = @email";

                SqlConnection conn = new SqlConnection(_connStr);
                SqlCommand cmd = new SqlCommand(queryStr, conn);

                conn.Open();

                cmd.Parameters.AddWithValue("@userName", tb_username.Text);
                cmd.Parameters.AddWithValue("@email", tb_email.Text);
                dr = cmd.ExecuteReader();
                cmd.Dispose();

                if (dr.HasRows)
                {
                    dr.Read();
                    //generate uniquecode if username or email id is matched
                    //generate uniquecode
                    uniqueCode = Convert.ToString(System.Guid.NewGuid());
                    //updating an unique code random code in the uniqueCode field of database table
                    cmd = new SqlCommand("UPDATE TableUser2 SET uniqueCode = @uniqueCode WHERE userName = @userName OR email = @email", conn);//, con);
                    cmd.Parameters.AddWithValue("@uniqueCode", uniqueCode);
                    cmd.Parameters.AddWithValue("@userName", tb_username.Text);
                    cmd.Parameters.AddWithValue("@email", tb_email.Text);

                    StringBuilder strBody = new StringBuilder();
                    //passing email and generated unqie code via query string
                    strBody.Append("Dear " + tb_username.Text + ",<br/><br/>" + 
                        "To reset your password, please click on the following link.<br/>" +
                        "<a href=http://localhost:1398/UserPage/UserResetPassword.aspx?email=" + tb_email.Text + "&userName=" + tb_username.Text + "&uniqueCode=" + uniqueCode + ">Click here to change your password.</a><br/><br/>" +
                        "Regards, <br/>Security Team");
                    //System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage("suju4eva060396@gmail.com", dr["email"].ToString(),
                    //    "Reset Your Password", strBody.ToString());

                    //strBody.Append("<a href=http://localhost:1398/PublicPage/PublicAbout Click here to change your password</a>");
                    System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage("suju4eva060396@gmail.com", dr["email"].ToString(),
                        "Reset Your Password", strBody.ToString());
                    //pass Gmail credentials to send the email
                    System.Net.NetworkCredential mailAuthentication = new System.Net.NetworkCredential("meilingli172@gmail.com", "ASDqwe123");
                    System.Net.Mail.SmtpClient mailClient = new System.Net.Mail.SmtpClient("smtp.gmail.com", 587);
                    mailClient.EnableSsl = true;
                    mailClient.UseDefaultCredentials = false;
                    mailClient.Credentials = mailAuthentication;
                    mail.IsBodyHtml = true;
                    mailClient.Send(mail);
                    dr.Close();
                    dr.Dispose();
                    cmd.ExecuteReader();
                    cmd.Dispose();
                    conn.Close();
                    lbl_msg.ForeColor = Color.Green;
                    lbl_msg.Text = "Reset password link has been sent to your email address.";
                    tb_username.Text = "";
                    tb_email.Text = "";

                    Session["UserName"] = tb_username.Text;
                }
                else
                {
                    lbl_msg.Text = "Please enter a valid email address or username.";
                    tb_username.Text = "";
                    tb_email.Text = "";
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                lbl_msg.Text = "Error occurred: " + ex.Message.ToString();
            }
            
        }

        //Send email for forget password
        public void SendEmail()
        {
            if (lbl_msg.Text == "success")
            {
                MailMessage mail = new MailMessage();

                mail.From = new MailAddress(tb_email.Text);
                mail.To.Add(tb_email.Text);
                mail.Subject = "Can't access account";
                mail.Body = "Here is the link to reset your password: <br/>";
                //mail.Body = "http://localhost:1398/PublicPage/PublicAbout";
                //mail.Body = "Regards, <br/>Visual Studios";

                SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");
                smtpServer.Port = 587;
                smtpServer.Credentials = new System.Net.NetworkCredential("meilingli172@gmail.com", "ASDqwe123") as ICredentialsByHost;
                smtpServer.EnableSsl = true;
                ServicePointManager.ServerCertificateValidationCallback = delegate(object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
                {
                    return true;
                };
                smtpServer.Send(mail);
                lbl_msg.ForeColor = Color.Green;
                lbl_msg.Text = "success";
            }
            else
            {
                lbl_msg.Text = "Not successful";
            }
        }

        public void SendPasswordResetEmail(string ToEmail, string UserName, string UniqueId)
        {
            MailMessage mailMessage = new MailMessage("suju4eva060396@gmail.com", ToEmail);

            StringBuilder sbEmailBody = new StringBuilder();
            sbEmailBody.Append("Dear " + UserName + ",<br/><br/>");
            sbEmailBody.Append("Please click on the following link to reset your password");
            sbEmailBody.Append("<br/>");
            sbEmailBody.Append("http://localhost:1398/UserPage/UserChangePassword" + UniqueId);
            sbEmailBody.Append("<br/><br/>");
            sbEmailBody.Append("Visual Studios");

            mailMessage.IsBodyHtml = true;
            mailMessage.Subject = "Reset Your Password";
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);

            smtpClient.Credentials = new System.Net.NetworkCredential()
            {
                UserName = "suju4eva060396@gmail.com",
                Password = "0"
            };

            smtpClient.EnableSsl = true;
            smtpClient.Send(mailMessage);

        }

    }
}