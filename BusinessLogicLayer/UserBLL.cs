using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using DataAccessLayer;

using System.Security.Cryptography;
using System.IO;

namespace BusinessLogicLayer
{
    public class UserBLL
    {
        UserDAL user = new UserDAL();

        public string CreateUser(string userName, string password, string confirmPassword, string email, string fullName, string contactNo)
        {
            string returnMessage = "";

            //if (userName.Length < 0 || password.Length < 0 || email.Length < 0 || fullName.Length < 0 || contactNo.Length < 0)
            //{
            //    returnMessage = "Please enter all fields.";
            //}

            if (userName.Length > 120)
                returnMessage += "UserName exceeds 120 characters!<br />";
            if (userName.Length == 0)
                returnMessage += "Please enter an username.<br />";
            if (password.Length > 120)
                returnMessage += "Password exceeds 120 characters!<br />";
            if (password.Length == 0)
                returnMessage += "Please enter a password.<br />";
            if (password != confirmPassword)
                returnMessage += "Passwords do not match. Please try again.<br />";
            if (email.Length > 120)
                returnMessage += "Email exceeds 120 characters!<br />";
            if (email.Length == 0)
                returnMessage += "Please enter an email.<br />";
            if (fullName.Length > 120)
                returnMessage += "Name exceeds 120 characters!<br />";
            if (fullName.Length == 0)
                returnMessage += "Please enter your name.<br />";
            if (contactNo.Length != 8)
                returnMessage += "Contact Number needs to be 8 integers!<br />";

            if (returnMessage.Length == 0)
            {
                //No error; proceed
                UserDAL userdal = new UserDAL(userName, password, email, fullName, contactNo);

                int nofRows = 0;
                nofRows = userdal.UserInsert();

                if (nofRows > 0)
                    returnMessage = "User record saved successfully.";
                else
                    returnMessage = "Unable to save user record. Please try again.";
            }
            return returnMessage;
        }

        public string LoginUser(string userName, string password)
        {
            string returnMessage = "";

            if (userName.Length == 0)
                returnMessage += "Please enter your username.<br />";
            if (password.Length == 0)
                returnMessage += "Please enter your password.<br />";

            if (returnMessage.Length == 0)
            {
                //proceed if no error

                int nofRows = 0;
                nofRows = user.UserLogin(userName, password);

                if (nofRows > 0)
                    returnMessage = "Login successful.";
                if (nofRows <= 0)
                    returnMessage = "Invalid username/password. Please try again.";
            }
            return returnMessage;
        }

        public string UpdateUser(string password, string confirmPassword, string contactNo)
        {
            string returnMessage = "";

            if (password.Length > 120)
                returnMessage += "Password exceeds 120 characters!<br />";
            if (password.Length == 0)
                returnMessage += "Please enter a password.<br />";
            if (password != confirmPassword)
                returnMessage += "Both new passwords do not match. Please try again.<br />";
            if (contactNo.Length != 8)
                returnMessage += "Contact Number needs to be 8 integers!<br />";

            if (returnMessage.Length == 0)
            {
                //proceed if no error
                UserDAL user = new UserDAL(password, contactNo);

                int nofRows = 0;
                nofRows = user.UserUpdate();

                if (nofRows > 0)
                    returnMessage = "User record updated successfully.";
                else
                    returnMessage = "Unable to update user record. Please try again.";
            }
            return returnMessage;
        }

        public void hhh()
        {

        }

        //public void InsertUser(string p1, string p2, string p3, string p4, string p5)
        //{
        //    throw new NotImplementedException();
        //}

        //public int Hash()
        //{
        //    byte[] rawTextBytes = Encoding.UTF8.GetBytes(tb_password.Text);

        //    SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider();

        //    byte[] hashBytes = sha1.ComputeHash(rawTextBytes);

        //    //OID (object identifier) indicating SHA1 algorithm
        //    RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
        //    rsa.ImportParameters(privateParams);
        //    byte[] signature = rsa.SignHash(hashBytes, CryptoConfig.MapNameToOID("SHA1"));

        //    tb_password.Text = Convert.ToBase64String(signature);
        //}


    }
}