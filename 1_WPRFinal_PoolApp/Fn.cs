using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Security.Permissions;
using System.Drawing.Imaging;

namespace _1_WPRFinal_PoolApp
{
    public class LoginResult
    {
        public bool IsSuccessful { get; set; }
        public string Role { get; set; }
        public string Message { get; set; } // for error messages or other messages
    }

    public static class Data
    {

        public static List<Facility> facilities;
        public static List<TOURNAMENT> TOURNAMENTs;
        public static List<TABLE> TABLEs;
        public static void init()
        {
            facilities = Facility.LoadFacilitiesFromDatabase();
            TOURNAMENTs = TOURNAMENT.LoadTournamentsFromDatabase();
            TABLEs = TABLE.LoadTablesFromDatabase();

        }
    }
    public class Fn
    {
        public static int GenerateUniqueRandomID(string query)
        {
            int randomID;
            bool isUnique = false;
            Random rand = new Random();

            // Loop until a unique ID is generated
            while (!isUnique)
            {
                randomID = rand.Next(100000000, 1000000000); // Generate a random 9-digit integer ID

                // Check if the generated ID is unique in the database
                if (IsIDUniqueInDatabase(randomID,query))
                {
                    isUnique = true;
                    return randomID;
                }
            }

            return -1; // Return -1 if unable to generate a unique ID (this should ideally not happen)
        }


        private static bool IsIDUniqueInDatabase(int id,string query)
        {
            using (SqlConnection connection = new SqlConnection(Fn.Con()))
            {
                connection.Open();

                /*// SQL query to check if the ID exists in the Accounts table
                string query = "SELECT COUNT(*) FROM Accounts WHERE ID = @ID";*/

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID", id);
                    int count = (int)command.ExecuteScalar();

                    // If count is 0, ID is unique, otherwise it's not unique
                    return count == 0;
                }
            }
        }


        public static string Con()
        {
            CONNECT Con = new CONNECT();
            return Con.String;
        }
        public static (bool isValid, string errorMessage) ValidateInput(string firstName, string lastName, string gender, DateTime dob, string phone)
        {
            if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName))
            {
                return (false, "First name and last name are required.");
            }

            if (Regex.IsMatch(firstName, @"\d") || Regex.IsMatch(lastName, @"\d"))
            {
                return (false, "First name and last name should not contain numbers.");
            }

            if (string.IsNullOrWhiteSpace(gender))
            {
                return (false, "Please select a valid gender.");
            }

            int age = DateTime.Today.Year - dob.Year;
            if (age < 9 || age > 100)
            {
                return (false, "Age should be between 9 and 100 years old.");
            }

            if (string.IsNullOrWhiteSpace(phone) || !Regex.IsMatch(phone, @"^\d{10}$"))
            {
                return (false, "Phone number should be 10 digits and only contain numbers.");
            }

            return (true, "Input is valid.");
        }

        public static byte[] ImageToByteArray(Image image)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, ImageFormat.Jpeg);
                return ms.ToArray();
            }
        }
        public static bool IsValidEmail(string email)
        {
            // Use a regular expression to validate email format
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            Regex regex = new Regex(pattern);
            return regex.IsMatch(email);
        }
        public static string encrypt(string password)
        {
            byte[] data = Encoding.UTF8.GetBytes(password);
            using (SHA1 sha1 = SHA1.Create())
            {
                byte[] hashbyte = sha1.ComputeHash(data);


                StringBuilder sb = new StringBuilder();
                foreach (byte b in hashbyte)
                {
                    sb.Append(b.ToString("x2")); // "x2" means hexadecimal with two digits
                }

                return sb.ToString();
            }
        }
    }
}
