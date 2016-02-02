using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogicLayer;
using DataAccessLayer;

using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.IO;

using System.Net.Mail;

namespace ISECCS_PJ.PublicPage
{
    public partial class PublicRegister : System.Web.UI.Page
    {
        UserBLL userbll = new UserBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            tb_username.Focus();
        }

        //protected void btn_next_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect("PublicRegisterCaptcha.aspx");
        //}

        protected void btn_register_Click(object sender, EventArgs e)
        {
            if (checkAgainstSQLinjection(tb_username.Text) == true && checkAgainstSQLinjection(tb_name.Text) == true && checkAgainstSQLinjection(tb_contact.Text) == true) 
            {
                string message = "";

                message = userbll.CreateUser(tb_username.Text, tb_password.Text, tb_cpassword.Text, tb_email.Text, tb_name.Text, tb_contact.Text);

                //Check password strength
                int marks = GetPasswordStrength(tb_password.Text);
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

            //lblPasswordStrength.Text = "Status : " + status;
            //if (marks < 4)
            //{
            //    lblPasswordStrength.ForeColor = Color.Red;
            //    return;
            //}
            //else
            //{
            //    lblPasswordStrength.ForeColor = Color.Green;
            //}

                //Validating captcha
                bool isCaptchaValid = false;
                if (Session["CaptchaText"] != null && Session["CaptchaText"].ToString() == txtCaptchaText.Text)
                {
                    isCaptchaValid = true;
                }

                if (isCaptchaValid == true)
                {
                    if (message == "User record saved successfully.")
                    {
                        if (marks >= 4)
                        {
                            lbl_msg.Text = "Account successfully created.";
                            lbl_msg.ForeColor = Color.Green;

                            lbl_msg2.Text = "Captcha is successfully validated.";
                            lbl_msg2.ForeColor = Color.Green;

                            lblPasswordStrength.Text = "Password strength: " + status;
                            lblPasswordStrength.ForeColor = Color.Green;

                            tb_username.Text = "";
                            tb_password.Text = "";
                            tb_email.Text = "";
                            tb_name.Text = "";
                            tb_contact.Text = "";
                            txtCaptchaText.Text = "";
                        }
                        else
                        {
                            lbl_msg.Text = message;
                            lbl_msg2.Text = "Captcha Validation Failed. Please try again.";
                            lbl_msg2.ForeColor = Color.Red;
                            lblPasswordStrength.Text = "Password strength: " + status + ". Please try again.";
                            lblPasswordStrength.ForeColor = Color.Red;
                        }

                    
                    }
                    else
                    {
                        lbl_msg.Text = message;
                        lbl_msg2.Text = "Captcha Validation Failed. Please try again.";
                        lbl_msg2.ForeColor = Color.Red;
                        lblPasswordStrength.Text = "Password strength: " + status + ". Please try again.";
                        lblPasswordStrength.ForeColor = Color.Red;
                    }
                
                }
                else
                {
                    lbl_msg.Text = message;
                    lbl_msg2.Text = "Captcha Validation Failed. Please try again.";
                    lbl_msg2.ForeColor = Color.Red;
                    lblPasswordStrength.Text = "Password strength: " + status + ". Please try again.";
                    lblPasswordStrength.ForeColor = Color.Red;
                }
            }
            else
            {
                lbl_msg.Text = "Please don't insert any Cross site scripting.";
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

        //Clear textboxes
        protected void btn_clear_Click(object sender, EventArgs e)
        {
            tb_username.Text = "";
            tb_password.Text = "";
            tb_cpassword.Text = "";
            tb_email.Text = "";
            tb_name.Text = "";
            tb_contact.Text = "";
            txtCaptchaText.Text = "";
            lbl_msg.Text = "";
            lbl_msg2.Text = "";
            lblPasswordStrength.Text = "";
        }

        ////Check password strength
        //protected void btnSave_Click(object sender, EventArgs e)
        //{
        //    int marks = GetPasswordStrength(tb_password.Text);
        //    string status = "";
        //    switch (marks)
        //    {
        //        case 1:
        //            status = "Very Weak";
        //            break;
        //        case 2:
        //            status = "Weak";
        //            break;
        //        case 3:
        //            status = "Medium";
        //            break;
        //        case 4:
        //            status = "Strong";
        //            break;
        //        case 5:
        //            status = "Very Strong";
        //            break;
        //        default:
        //            break;
        //    }

        //    lblPasswordStrength.Text = "Status : " + status;
        //    if (marks < 4)
        //    {               
        //        lblPasswordStrength.ForeColor = Color.Red;
        //        return;
        //    }
        //    else
        //    {
        //        lblPasswordStrength.ForeColor = Color.Green;
        //    }

        //}
        
        //Password strength = very weak,weak, medium, strong and very strong.
        private int GetPasswordStrength(string password)
        {
            int Marks = 0;
            //check password strength
            if (password.Length < 8)
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

        //protected void btnSave_Click(object sender, EventArgs e)
        //{
        //    //Validating captcha
        //        bool isCaptchaValid = false;
        //        if (Session["CaptchaText"] != null && Session["CaptchaText"].ToString() == txtCaptchaText.Text)
        //        {
        //            isCaptchaValid = true;
        //        }
        //        if (isCaptchaValid)
        //        {
        //            lbl_msg2.Text = "Captcha is successfully validated.";
        //            lbl_msg2.ForeColor = Color.Green;
        //        }
        //        else
        //        {
        //            lbl_msg2.Text = "Captcha Validation Failed. Please try again.";
        //            lbl_msg2.ForeColor = Color.Red;
        //        }
        //}

        //protected void btn_checkpwd_Click(object sender, EventArgs e)
        //{
        //    int marks = GetPasswordStrength(tb_password.Text);
        //    string status = "";
        //    switch (marks)
        //    {
        //        case 1:
        //            status = "Very Weak";
        //            break;
        //        case 2:
        //            status = "Weak";
        //            break;
        //        case 3:
        //            status = "Medium";
        //            break;
        //        case 4:
        //            status = "Strong";
        //            break;
        //        case 5:
        //            status = "Very Strong";
        //            break;
        //        default:
        //            break;
        //    }

        //    lblPasswordStrength.Text = "Status : " + status;
        //    if (marks < 4)
        //    {
        //        lblPasswordStrength.ForeColor = Color.Red;
        //        return;
        //    }
        //    else
        //    {
        //        lblPasswordStrength.ForeColor = Color.Green;
        //    }
        //}

        protected void btn_sendemail_Click(object sender, EventArgs e)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient smtpC = new SmtpClient("smtp.gmail.com");
                //From address to send email
                mail.From = new MailAddress("suju4eva060396@gmail.com");
                //To address to send email
                mail.To.Add("suju4eva060396@gmail.com");
                mail.Body = "This is a test mail from C# program";
                mail.Subject = "TEST";
                smtpC.Port = 587;
                //Credentials for From address
                smtpC.Credentials = new System.Net.NetworkCredential("EmailID", "password");
                smtpC.EnableSsl = true;
                smtpC.Send(mail);
                Console.WriteLine("Message sent successfully");
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.GetBaseException());
                Console.ReadLine();
            }
        }
        

        ////To validate captcha
        //protected void btn_submitcaptcha_Click(object sender, EventArgs e)
        //{
        //    //Validating captcha
        //    bool isCaptchaValid = false;
        //    if (Session["CaptchaText"] != null && Session["CaptchaText"].ToString() == txtCaptchaText.Text)
        //    {
        //        isCaptchaValid = true;
        //    }
        //    if (isCaptchaValid)
        //    {
        //        lbl_msg2.Text = "Captcha is successfully validated.";
        //        lbl_msg2.ForeColor = Color.Green;
        //    }
        //    else
        //    {
        //        lbl_msg2.Text = "Captcha Validation Failed. Please try again.";
        //        lbl_msg2.ForeColor = Color.Red;
        //    }
        //}
    }
}