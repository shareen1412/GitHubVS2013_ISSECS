﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class WatermarkUploadBLL
    {
        WatermarkUploadDAL wuDAL = new WatermarkUploadDAL();

        public string UploadFile(string userName, string file)
        {
            string message = "";

            wuDAL.UploadImage();

            return message;
        }
    }
}
