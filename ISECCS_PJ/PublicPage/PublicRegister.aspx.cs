using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogicLayer;
using DataAccessLayer;

using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Security.Cryptography;
using System.IO;

namespace ISECCS_PJ.PublicPage
{
    public partial class PublicRegister : System.Web.UI.Page
    {
        UserBLL userbll = new UserBLL();
        UserDAL userdal = new UserDAL();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_next_Click(object sender, EventArgs e)
        {
            Response.Redirect("PublicRegisterCaptcha.aspx");
        }

        protected void btn_register_Click(object sender, EventArgs e)
        {
            //calling BLL class for register button
            //userdal.UserInsert(tb_username.Text, tb_password.Text, tb_email.Text, tb_name.Text, tb_contact.Text);

            string  message = "";

            message = userbll.CreateUser(tb_username.Text, tb_password.Text, tb_cpassword.Text, tb_email.Text, tb_name.Text, tb_contact.Text);

            //userdal.UserInsert();

            //userbll.CreateUser1();

            if (message == "User record saved successfully.")
            {
                lbl_msg.Text = "Account successfully created.";

                tb_username.Text = "";
                tb_password.Text = "";
                tb_email.Text = "";
                tb_name.Text = "";
                tb_contact.Text = "";
            }
            else
                lbl_msg.Text = message;

            //byte[] rawTextBytes = Encoding.UTF8.GetBytes(tb_password.Text);

            //SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider();

            //byte[] hashBytes = sha1.ComputeHash(rawTextBytes);

            ////OID (object identifier) indicating SHA1 algorithm
            //RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            //rsa.ImportParameters(privateParams);
            //byte[] signature = rsa.SignHash(hashBytes, CryptoConfig.MapNameToOID("SHA1"));

            //tb_password.Text = Convert.ToBase64String(signature);
        }
    }
}