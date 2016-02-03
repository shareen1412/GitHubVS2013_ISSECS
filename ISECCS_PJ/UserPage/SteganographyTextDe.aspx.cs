using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Drawing;

namespace ISECCS_PJ.UserPage
{
    public partial class SteganographyTextDe : System.Web.UI.Page
    {
        private Bitmap
            OriginalImage = null;

        System.Drawing.Image stegImage;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_submit_Click(object sender, EventArgs e)
        {
            // Decode.
            try
            {
                stegImage = System.Drawing.Image.FromStream(fileUpload_Steg.PostedFile.InputStream);
                OriginalImage = (Bitmap)stegImage;
                long fileSize = fileUpload_Steg.PostedFile.ContentLength;
                //string text = DecodeMessageInImage(OriginalImage, tb_pw.Text);
                tb_textToReveal.Text = DecodeMessageInImage(OriginalImage, tb_pw.Text);
            }
            catch (Exception ex)
            {
                
            }
        }

        // Decode the message hidden in a picture.
        private string DecodeMessageInImage(Bitmap bm, string password)
        {
            // Initialize a random number generator.
            Random rand = new Random(NumericPassword(password));

            // Create a new HashSet.
            HashSet<string> used_positions = new HashSet<string>();

            // Make a byte array big enough to hold the message length.
            int len = 0;
            byte[] bytes = BitConverter.GetBytes(len);

            // Decode the message length.
            for (int i = 0; i < bytes.Length; i++)
            {
                bytes[i] = DecodeByte(bm, rand, used_positions);
            }
            len = BitConverter.ToInt32(bytes, 0);

            // Sanity check.
            if (len > 10000)
            {
                throw new InvalidDataException(
                    "Message length " + len.ToString() +
                    " is too big to make sense. Invalid password.");
            }

            // Decode the message bytes.
            char[] chars = new char[len];
            for (int i = 0; i < chars.Length; i++)
            {
                chars[i] = (char)DecodeByte(bm, rand, used_positions);
            }
            return new string(chars);
        }

        // Decode a byte.
        private byte DecodeByte(Bitmap bm, Random rand, HashSet<string> used_positions)
        {
            byte value = 0;
            byte value_mask = 1;
            for (int i = 0; i < 8; i++)
            {
                // Find the position for the ith bit.
                int row, col, pix;
                PickPosition(bm, rand, used_positions, out row, out col, out pix);

                // Get the color component value.
                byte color_value = 0;
                switch (pix)
                {
                    case 0:
                        color_value = bm.GetPixel(row, col).R;
                        break;
                    case 1:
                        color_value = bm.GetPixel(row, col).G;
                        break;
                    case 2:
                        color_value = bm.GetPixel(row, col).B;
                        break;
                }

                // Set the next bit if appropriate.
                if ((color_value & 1) == 1)
                {
                    // Set the bit.
                    value = (byte)(value | value_mask);
                }

                // Move to the next bit.
                value_mask <<= 1;
            }

            return value;
        }

        // Convert a string password into a numeric value.
        private int NumericPassword(string password)
        {
            // Initialize the shift values to different non-zero values.
            int shift1 = 3;
            int shift2 = 17;

            // Process the message.
            char[] chars = password.ToCharArray();
            int value = 0;
            for (int i = 1; i < password.Length; i++)
            {
                // Add the next letter.
                int ch_value = (int)chars[i];
                value ^= (ch_value << shift1);
                value ^= (ch_value << shift2);

                // Change the shifts.
                shift1 = (shift1 + 7) % 19;
                shift2 = (shift2 + 13) % 23;
            }
            return value;
        }

        // Pick an unused (r, c, pixel) combination.
        private void PickPosition(Bitmap bm, Random rand,
            HashSet<string> used_positions,
            out int row, out int col, out int pix)
        {
            for (; ; )
            {
                // Pick random r, c, and pix.
                row = rand.Next(0, bm.Width);
                col = rand.Next(0, bm.Height);
                pix = rand.Next(0, 3);

                // See if this location is available.
                string key =
                    row.ToString() + "/" +
                    col.ToString() + "/" +
                    pix.ToString();
                if (!used_positions.Contains(key))
                {
                    used_positions.Add(key);
                    return;
                }
            }
        }
    }
}