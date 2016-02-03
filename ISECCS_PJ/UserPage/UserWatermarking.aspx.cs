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
using System.Data;
using System.Data.SqlClient;

using System.Web.Providers.Entities;
using BusinessLogicLayer;

namespace ISECCS_PJ.UserPage
{
    public partial class UserWatermarking : System.Web.UI.Page
    {
        WatermarkUploadBLL wuBLL = new WatermarkUploadBLL();
        WatermarkUploadDAL wuDAL = new WatermarkUploadDAL();

        private string _connStr = Properties.Settings.Default.DBConnStr;

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
                    Response.Write("<script>alert('Invalid file format! Only .jpg and .png files are accepted.')</script>");
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

                if (img_userImage.ImageUrl == "")
                {
                    Response.Write("<script>alert('No image is available to download.')</script>");
                }
                else
                {
                    string filename = img_userImage.ImageUrl;

                    Response.ContentType = "image/JPEG";
                    //Response.AddHeader("Content-Disposition", "attachment; filename=" + filename + "");
                    Response.AddHeader("Content-Disposition", "attachment; filename=" + "watermarked_" + filename.Remove(0, 15));

                    Response.TransmitFile(filename);
                    Response.End();
                }
            }//try
            catch
            {
            }//catch
        }//bn_download

        protected void bn_upload_Click(object sender, EventArgs e)
        {
            //string filename = img_userImage.ImageUrl;
            //string pathName = Path.Combine(Server.MapPath("~/TempImages/"),fileName);

            //byte[] data = File.ReadAllBytes(filename);

            //UploadFile(Session["UserName"].ToString(), filename);

            if (img_userImage.ImageUrl == "")
            {
                Response.Write("<script>alert('No image is available to preview.')</script>");
            }
            else
            {
                UploadImage();
                Response.Write("<script>alert('File successfully uploaded.')</script>");
                img_userImage.ImageUrl = "";
            }
        }//bn_upload

        public void UploadImage()
        {
            string imagePath = img_userImage.ImageUrl;

            string queryStr = "INSERT INTO FileStorage (userName, fileName, currentTimeDate) " +
                "VALUES(@userName, @fileName, @currentTimeDate)";

            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);

            conn.Open();

            cmd.Parameters.AddWithValue("@userName", Session["UserName"].ToString());
            cmd.Parameters.AddWithValue("@fileName", imagePath);
            cmd.Parameters.AddWithValue("@currentTimeDate", DateTime.Now);

            cmd.ExecuteNonQuery();

            conn.Close();

            //try
            //{

            //}
            //catch
            //{

            //}
        }//UploadImage()
    }
}