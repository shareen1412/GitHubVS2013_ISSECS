using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Web;

using System.Security.Cryptography;
using System.IO;


namespace DataAccessLayer
{
    public class UserDAL
    {
        private string _connStr = Properties.Settings.Default.DBConnStr;

        private string userName = "";
        private string password = "";
        private string email = "";
        private string fullName = "";
        private string contactNo = "";

        public UserDAL(string password, string contactNo)
        {
            this.password = password;
            this.contactNo = contactNo;
        }

        public UserDAL(string userName, string password, string email, string fullName, string contactNo)
        {
            this.userName = userName;
            this.password = password;
            this.email = email;
            this.fullName = fullName;
            this.contactNo = contactNo;
        }

        public UserDAL()
        {
            // TODO: Complete member initialization
        }

        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string FullName
        {
            get { return fullName; }
            set { fullName = value; }
        }

        public string ContactNo
        {
            get { return contactNo; }
            set { contactNo = value; }
        }

        //string _username = "";
        //string _password = "";
        //string _email = "";
        //string _fullname = "";
        //string _contactNo = "";
        //string _connStr = "";


        //Insert a record into User table and return number of row affected.
        //If number of row = 0, it means that insert is not successful.
        public int UserInsert()
        {

            //try
            //{
                string queryStr = "INSERT INTO TableUser (userName, password, email, fullName, contactNo) " +
                          " VALUES('" +
                          userName + "','" +
                          password + "','" +
                          email + "','" +
                          fullName + "','" +
                          contactNo + "')";

            //string queryStr = "INSERT INTO TableUser (userName, password, email, fullName, contactNo) " +
            //                  " VALUES('111','bbb','ccc','ddd','eee')";
                             
                SqlConnection conn = new SqlConnection(_connStr);
                SqlCommand cmd = new SqlCommand(queryStr, conn);

                conn.Open();

                int nofRow = 0; 
                nofRow = cmd.ExecuteNonQuery();

                conn.Close();

                return nofRow;
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine("Error message is: " + ex.Message);
            //}
        }

        public int UserLogin(string userName, string password)
        {
            int nofRows = 0;
            //try
            //{
                //int nofRows = 0;
                string queryStr = "SELECT userName, password FROM TableUser WHERE userName = @userName and password = @pwd";

                SqlConnection conn = new SqlConnection(_connStr);
                SqlCommand cmd = new SqlCommand(queryStr, conn);
                cmd.Parameters.AddWithValue("@userName", userName);
                cmd.Parameters.AddWithValue("@pwd", password);

                conn.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    userName = dr["userName"].ToString();
                    password = dr["password"].ToString();

                    nofRows = 1;
                }

                conn.Close();
                dr.Close();
                dr.Dispose();

                //return nofRows;
            //}

            //catch(Exception ex)
            //{
            //    Console.WriteLine("Error! " + ex.Message);
            //}
            return nofRows;
            
        }

        public int UserUpdate()
        {
            string queryStr = "UPDATE TableUser SET password = @password, contactNo = @contactNo WHERE userName = @userName ";

            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@password", password);
            cmd.Parameters.AddWithValue("@contactNo", contactNo);

            conn.Open();
            int nofRow = 0;
            nofRow = cmd.ExecuteNonQuery();

            conn.Close();

            return nofRow;
        }

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
