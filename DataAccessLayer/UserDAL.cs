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

        //For hashing
        private string salt = "";
        private string saltedPassword = "";
        private string slowHashSalt = "";

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

        public string Salt
        {
            get { return salt; }
            set { salt = value; }
        }

        public string SaltedPassword
        {
            get { return saltedPassword; }
            set { saltedPassword = value; }
        }

        public string SlowHashSalt
        {
            get { return slowHashSalt; }
            set { slowHashSalt = value; }
        }

        //string _username = "";
        //string _password = "";
        //string _email = "";
        //string _fullname = "";
        //string _contactNo = "";
        //string _connStr = "";

        public const int SALT_BYTE_SIZE = 24;
        public const int HASH_BYTE_SIZE = 24;
        public const int PBKDF2_ITERATIONS = 1000;

        public const int ITERATION_INDEX = 0;
        public const int SALT_INDEX = 1;
        public const int PBKDF2_INDEX = 2;

        //Creates a salted PBKDF2 hash of the password
        //Input = password, Returns = hash of password
        public static string CreateHash(string password)
        {
            //Generate a random salt
            RNGCryptoServiceProvider csprng = new RNGCryptoServiceProvider();
            byte[] salt = new byte[SALT_BYTE_SIZE];
            csprng.GetBytes(salt);

            //Hash password and encode parameters
            byte[] hash = PBKDF2(password, salt, PBKDF2_ITERATIONS, HASH_BYTE_SIZE);
            return PBKDF2_ITERATIONS + ":" + Convert.ToBase64String(salt) + ":" + Convert.ToBase64String(hash);

        }

        //Computes the PBKDF2-SHA1 hash of a password
        //Password = password to hash
        //Salt = salt
        //Iterations = PBKDF2 iteration count
        //OutputBytes = length of hash to generate, in bytes
        //Returns = a hash of the password
        private static byte[] PBKDF2(string password, byte[] salt, int iterations, int outputBytes)
        {
            Rfc2898DeriveBytes pbkdf2 = new Rfc2898DeriveBytes(password, salt);
            pbkdf2.IterationCount = iterations;
            return pbkdf2.GetBytes(outputBytes);
        }

        //Validates a password given a hash of the correct one
        //Password = the password to check
        //CorrectHash = a hash of the correct password
        //Returns = True if password is correct, False if password is incorrect
        public static bool ValidatePassword(string password, string correctHash)
        {
            // Extract the parameters from the hash
            char[] delimiter = { ':' };
            string[] split = correctHash.Split(delimiter);
            int iterations = Int32.Parse(split[ITERATION_INDEX]);
            byte[] salt = Convert.FromBase64String(split[SALT_INDEX]);
            byte[] hash = Convert.FromBase64String(split[PBKDF2_INDEX]);

            byte[] testHash = PBKDF2(password, salt, iterations, hash.Length);
            return SlowEquals(hash, testHash);
        }

        //Compares 2 byte arrays in length-constant time.
        //So that password hashes cannot be extracted
        //a = first byte array
        //b = second byte array
        private static bool SlowEquals(byte[] a, byte[] b)
        {
            uint diff = (uint)a.Length ^ (uint)b.Length;
            for (int i = 0; i < a.Length && i < b.Length; i++)
                diff |= (uint)(a[i] ^ b[i]);
            return diff == 0;
        }

        public void UserInsert()
        {
            try
            {
                string queryStr = "INSERT INTO TableUser2 (userName, email, fullName, contactNo, slowHashSalt) " +
                      "VALUES(@userName, @email, @fullName, @contactNo, @slowHashSalt)";
                             
                SqlConnection conn = new SqlConnection(_connStr);
                SqlCommand cmd = new SqlCommand(queryStr, conn);

                conn.Open();

                cmd.Parameters.AddWithValue("@userName", userName);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@fullName", fullName);
                cmd.Parameters.AddWithValue("@contactNo", contactNo);
                
                //Hashing
                String saltHashReturned = UserDAL.CreateHash(password);
                int commaIndex = saltHashReturned.IndexOf(":");
                String extractedString = saltHashReturned.Substring(0, commaIndex);
                commaIndex = saltHashReturned.IndexOf(":");
                extractedString = saltHashReturned.Substring(commaIndex + 1);
                commaIndex = extractedString.IndexOf(":");
                String salt = extractedString.Substring(0, commaIndex);

                commaIndex = extractedString.IndexOf(":");
                extractedString = extractedString.Substring(commaIndex + 1);
                String hash = extractedString;
                //from the first: to the second: is the salt
                //from the second : to the end is the salt
                cmd.Parameters.AddWithValue("@slowHashSalt", saltHashReturned);

                cmd.ExecuteReader();
          
                conn.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error message is: " + ex.Message);
            }
        }

        public void LoginWithPasswordHashFunction()
        {
            List<String> salthashList = null;
            List<String> namesList = null;

            try
            {
                string queryStr = "SELECT userName, slowHashSalt FROM TableUser2 WHERE userName = @userName";

                SqlConnection conn = new SqlConnection(_connStr);
                SqlCommand cmd = new SqlCommand(queryStr, conn);

                conn.Open();

                cmd.Parameters.AddWithValue("@userName", userName);
                SqlDataReader dr = cmd.ExecuteReader();

                while(dr.HasRows && dr.Read())
                {
                    if(salthashList == null)
                    {
                        salthashList = new List<String>();
                        namesList = new List<String>();
                    }

                    String saltHashes = dr.GetString(dr.GetOrdinal("slowHashSalt"));
                    salthashList.Add(saltHashes);

                    String username = dr.GetString(dr.GetOrdinal("userName"));
                    namesList.Add(username);
                }
                //conn.Close();
                dr.Close();
                //dr.Dispose();

                //If not empty, means there are a few matching usernames
                if (salthashList != null)
                {
                    for (int i = 0; i < salthashList.Count; i++)
                    {
                        queryStr = "";
                        bool validUser = UserDAL.ValidatePassword(password, salthashList[i]);
                        if (validUser == true)
                        {
                            //Session["userName"] = namesList[i];
                            //Response.BufferOutput = true;
                            //Response.Redirect("~/UserPage/UserHome.aspx", false);
                            
                            
                        }
                        else
                        {
                            //lbl_msg.Text = "User is not authenticated. Please try again.";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error! " + ex.Message);
            }
        }

        public int UserLogin(string userName, string password)
        {
            int nofRows = 0;
            try
            {
                //int nofRows = 0;
                string queryStr = "SELECT userName, password FROM TableUser2 WHERE userName = @userName and password = @pwd";

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
            }

            catch(Exception ex)
            {
                Console.WriteLine("Error! " + ex.Message);
            }
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
