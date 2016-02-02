using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using System.IO;
using System.Text;
using System.Drawing;

namespace ISECCS_PJ.UserPage
{
    public partial class Cryptography : System.Web.UI.Page
    {
        byte[] Key;
        byte[] IV;

        protected void Page_Load(object sender, EventArgs e)
        {
            //btn_encrypt.Enabled = false;
            //if (fileUpload.HasFile == true)
            //    btn_encrypt.Enabled = true;
        }

        protected void btn_decrypt_Click(object sender, EventArgs e)
        {
            
        }

        protected void btn_encrypt_Click(object sender, EventArgs e)
        {
            SymmetricAlgorithm sa = new RijndaelManaged();
            sa.GenerateKey();
            Key = sa.Key;
            IV = sa.IV;

            //Initialize instance for encryption
            //SymmetricAlgorithm sa = new RijndaelManaged();
            sa.Key = Key;
            sa.IV = IV;
            ICryptoTransform cryptTransform = sa.CreateEncryptor();
            byte[] plainText = Encoding.UTF8.GetBytes(txtPlain.Text);
            byte[] cipherText = cryptTransform.TransformFinalBlock(plainText, 0, plainText.Length);
            txtCipher.Text = Convert.ToBase64String(cipherText);
            btn_decrypt.Enabled = true;

            /*-----------------*/
        }

    }
}