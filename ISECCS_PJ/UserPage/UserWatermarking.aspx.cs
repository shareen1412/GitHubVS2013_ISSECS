using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Drawing;
using DataAccessLayer;
using System.Windows.Forms;

using System.Web.Providers.Entities;
using BusinessLogicLayer;

namespace ISECCS_PJ.UserPage
{
    public partial class UserWatermarking : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
        }//page_load

        protected void bn_preview_Click(object sender, EventArgs e)
        {

            try
            {
                // Here we will upload image with watermark text
                string fileName = Guid.NewGuid() + Path.GetExtension(fu_fileName.PostedFile.FileName);
                System.Drawing.Image upImage = System.Drawing.Image.FromStream(fu_fileName.PostedFile.InputStream);

                using (Graphics g = Graphics.FromImage(upImage))
                {
                    // For Transparent Watermark Text 
                    // 25% -> 63.75
                    int opacity = 80; // range from 0 to 255

                    // Get the width and height of the image
                    System.Drawing.Image img1 = System.Drawing.Image.FromStream(fu_fileName.PostedFile.InputStream);

                    int wmHeight = img1.Height;
                    int wmWidth = img1.Width;

                    // Show the width and height of image in message box
                    //MessageBox.Show("Height: " + wmHeight.ToString() + " Width: " + wmWidth.ToString());

                    //int xPosOfWm = 10;
                    //int yPosOfWm = 10;

                    // Calcualte position of the text
                    int xPosOfWm = 5;
                    int yPosOfWm = wmHeight - 25;

                    // Defining watermark properties
                    SolidBrush brush = new SolidBrush(Color.FromArgb(opacity, 44, 44, 44));

                    Font font = new Font("Arial", 16);

                    g.DrawString(tb_watermarkText.Text.Trim(), font, brush, new PointF(xPosOfWm, yPosOfWm));

                    upImage.Save(Path.Combine(Server.MapPath("~/TempImages/"), fileName));
                    img_userImage.ImageUrl = "~/TempImages/" + "//" + fileName;

                    tb_watermarkText.Text = "";
                }
            }//try
            catch (Exception ex)
            {
                string fileName = Guid.NewGuid() + Path.GetExtension(fu_fileName.PostedFile.FileName);

                string a = Path.GetExtension(fileName);

                if (fu_fileName.PostedFile.FileName == "")
                {
                    Response.Write("<script>alert('Please select a file!')</script>");
                }

                else if (a != ".jpg" && a != ".png")
                {
                    Response.Write("<script>alert('Wrong file format! Only .jpg and .png files are accepted.')</script>");
                }

                else if (tb_watermarkText.Text == "")
                {
                    Response.Write("<script>alert('Please enter your desired watermark text.')</script>");
                }
            }//catch
        }//bn_preview

        protected void bn_download_Click(object sender, EventArgs e)
        {
            try
            {
                string filename = img_userImage.ImageUrl;

                //string fileName = Path.GetExtension(fu_fileName.PostedFile.FileName);

                Response.ContentType = "image/JPEG";
                //Response.AddHeader("Content-Disposition", "attachment; filename=" + filename + "");
                Response.AddHeader("Content-Disposition", "attachment; filename=" + "watermarked_" + filename.Remove(0, 15));

                Response.TransmitFile(filename);
                Response.End();
            }
            catch (Exception ex)
            {

            }
        }//bn_download

        protected void bn_back_Click(object sender, EventArgs e)
        {
            //string path = Server.MapPath("~/TempImages/");
            //File.Delete(path);
            Response.Redirect("~/UserPage/UserHome");
        }//bn_back

        protected void bn_upload_Click(object sender, EventArgs e)
        {
            string fileName = img_userImage.ImageUrl;

            //watermarkBLL.UploadFile(fileName, Session["UserName"].ToString());
        }//bn_upload
    }
}