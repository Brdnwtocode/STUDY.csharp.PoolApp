using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_WPRFinal_PoolApp
{
    public class BUSINESS
    {
        CONNECT Con = new CONNECT();
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateOnly DOB { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Flag { get; set; }
        public int MID { get; set; }
        public int GroupID { get; set; }
        public Image Picture { get; set; }

        public BUSINESS() { }
        public void InsertBusiness(string firstName, string lastName, string gender, DateTime dob, string phone, string email, int userID, byte[] picture)
        {
            using (SqlConnection connection = new SqlConnection(Con.String))
            {
                connection.Open();
                string query = "INSERT INTO Business (ID, FirstName, LastName, DOB, Gender, Phone, Email, Picture) " +
                               "VALUES (@ID, @FirstName, @LastName, @DOB, @Gender, @Phone, @Email, @Picture)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID", userID);
                    command.Parameters.AddWithValue("@FirstName", firstName);
                    command.Parameters.AddWithValue("@LastName", lastName);
                    command.Parameters.AddWithValue("@DOB", dob);
                    command.Parameters.AddWithValue("@Gender", gender);
                    command.Parameters.AddWithValue("@Phone", phone);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Picture", (object)picture ?? DBNull.Value); // Handle null picture
                    command.ExecuteNonQuery();
                }
            }
        }



        //
        private static Image LoadImageFromDatabase(object imageData)
        {
            if (imageData == null || imageData == DBNull.Value)
                return null;

            byte[] imageBytes = (byte[])imageData;
            using (MemoryStream ms = new MemoryStream(imageBytes))
            {
                return Image.FromStream(ms);
            }
        }
        public static List<BUSINESS> LoadBusninessFromDatabase(string query)
        {
            List<BUSINESS> business = new List<BUSINESS>();

            using (SqlConnection connection = new SqlConnection(Fn.Con()))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DateTime dob = Convert.ToDateTime(reader["DOB"]);
                            BUSINESS Busineses = new BUSINESS
                            {
                                ID = (int)reader["ID"],
                                FirstName = reader["FirstName"].ToString(),
                                LastName = reader["LastName"].ToString(),
                                // Parse Date of Birth

                                DOB = new DateOnly(dob.Year, dob.Month, dob.Day), // Extract date part
                                Gender = reader["Gender"].ToString(),
                                Phone = reader["Phone"].ToString(),
                                Email = reader["Email"].ToString(),
                                MID = reader["MID"] != DBNull.Value ? Convert.ToInt32(reader["MID"]) : 0, // Check for DBNull before casting
                                GroupID = reader["GroupID"] != DBNull.Value ? Convert.ToInt32(reader["GroupID"]) : 0, // Check for DBNull before casting
                                Flag = reader["Flag"].ToString(),
                                
                               
                                // Load Picture if available
                                Picture = LoadImageFromDatabase(reader["Picture"]),
                            };

                            business.Add(Busineses);
                        }
                    }
                }
            }

            return business;
        }
    }
}
