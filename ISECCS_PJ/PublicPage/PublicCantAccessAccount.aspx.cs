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


namespace ISECCS_PJ.PublicPage
{
    public partial class PublicCantAccessAccount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_clear_Click(object sender, EventArgs e)
        {
            tb_email.Text = "";
            lbl_msg.Text = "";
        }

        protected void btn_sendemail_Click(object sender, EventArgs e)
        {
            SendEmail();
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
                mail.Body = "Your password is: ";

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