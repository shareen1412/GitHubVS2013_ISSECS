using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogicLayer;
using DataAccessLayer;

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

    }
}