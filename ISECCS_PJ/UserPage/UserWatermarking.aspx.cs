using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Drawing;
using BusinessLogicLayer;
using DataAccessLayer;

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
                // Here We will upload image with watermark text
                string fileName = Guid.NewGuid() + Path.GetExtension(fu_fileName.PostedFile.FileName);
                System.Drawing.Image upImage = System.Drawing.Image.FromStream(fu_fileName.PostedFile.InputStream);

                //string a = Path.GetExtension(fileName);

                //if (a != ".jpg" && a != ".png")
                //{
                //    Response.Write("<script>alert('Wrong file format')</script>");
                //}

                //if (tb_watermarkText.Text == "")
                //{
                //    Response.Write("<script>alert('Please enter your desired watermark')</script>");
                //}

                using (Graphics g = Graphics.FromImage(upImage))
                {
                    // For Transparent Watermark Text 
                    // 25% -> 63.75
                    int opacity = 64; // range from 0 to 255

                    // Defining watermark properties
                    SolidBrush brush = new SolidBrush(Color.FromArgb(opacity, Color.Red));
                    //SolidBrush brush = new SolidBrush(Color.FromArgb(ddl_transparency.SelectedIndex, Color.Red));

                    Font font = new Font("Arial", 16);
                    //Font font = new Font((ddl_fontType.SelectedItem).ToString(), ddl_fontSize.SelectedIndex);

                    g.DrawString(tb_watermarkText.Text.Trim(), font, brush, new PointF(200, 20));

                    upImage.Save(Path.Combine(Server.MapPath("~/TempImages/"), fileName));
                    img_userImage.ImageUrl = "~/TempImages/" + "//" + fileName;
                }
            }//try
            catch (Exception ex)
            {
                string fileName = Guid.NewGuid() + Path.GetExtension(fu_fileName.PostedFile.FileName);

                string a = Path.GetExtension(fileName);

                if (a != ".jpg" && a != ".png")
                {
                    Response.Write("<script>alert('Wrong file format!!')</script>");
                }

                else if (tb_watermarkText.Text == "")
                {
                    Response.Write("<script>alert('Please enter your desired watermark text.')</script>");
                }
                //Response.Write("<script> alert('Error lah')</script>");
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
    }
}