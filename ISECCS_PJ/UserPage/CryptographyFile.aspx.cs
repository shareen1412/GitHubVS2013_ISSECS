using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using System.Text;
using System.IO;
using System.Drawing;

namespace ISECCS_PJ.UserPage
{
    public partial class CryptographyFile : System.Web.UI.Page
    {
        string PasswordKey = "";

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_encrypt_Click(object sender, EventArgs e)
        {
            
            string inputFile = fileupload_en.PostedFile.FileName;
            fileupload_en.SaveAs(Path.Combine(Server.MapPath(null), inputFile));
            string outputFile = Path.Combine(Server.MapPath(null), inputFile);
            string skey = tb_pw_en.Text;

            EncryptFile(inputFile, outputFile, skey);
            

            //afterEncode.Save(Path.Combine(Server.MapPath(null), fileName));

            //fileName = Path.Combine(Server.MapPath(null), fileName);
            //string fileName = img_userImage.ImageUrl;

            Response.ContentType = "text/html";
            Response.AddHeader("Content-Disposition", "attachment; filename=" + "encrypted_" + outputFile.Remove(0, 15));

            Response.TransmitFile(outputFile);
            Response.End();
        }

        //initially a static method
        private static void EncryptFile(string inputFile, string outputFile, string skey)
        {
            try
            {
                using (AesCryptoServiceProvider aes = new AesCryptoServiceProvider())
                {
                    byte[] key = ASCIIEncoding.UTF8.GetBytes(skey);

                    /* This is for demostrating purposes only. 
                     * Ideally you will want the IV key to be different from your key 
                     * and you should always generate a new one for each encryption in other to achieve maximum security*/
                    byte[] IV = ASCIIEncoding.UTF8.GetBytes(skey);

                    using (FileStream fsCrypt = new FileStream(outputFile, FileMode.Create))
                    {
                        using (ICryptoTransform encryptor = aes.CreateEncryptor(key, IV))
                        {
                            using (CryptoStream cs = new CryptoStream(fsCrypt, encryptor, CryptoStreamMode.Write))
                            {
                                using (FileStream fsIn = new FileStream(inputFile, FileMode.Open))
                                {
                                    int data;
                                    while ((data = fsIn.ReadByte()) != -1)
                                    {
                                        cs.WriteByte((byte)data);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // failed to encrypt file
            }
        }
    }
}