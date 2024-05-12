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
    public class Fn
    {

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
