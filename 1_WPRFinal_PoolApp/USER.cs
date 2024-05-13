using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_WPRFinal_PoolApp
{
    public class USER
    {
        CONNECT Con = new CONNECT();

        public USER() { }

        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateOnly DOB { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Rank { get; set; }
        public bool Private { get; set; }
        public int Matches { get; set; }
        public float Winrate { get; set; }
        public string Flag { get; set; }
        public string Bio { get; set; }
        public string Favourite { get; set; }
        public Image Picture { get; set; }
        public void InsertUser(string firstName, string lastName, string gender, DateTime dob, string phone, string email, int userID, byte[] picture)
        {
            using (SqlConnection connection = new SqlConnection(Con.String))
            {
                connection.Open();
                string query = "INSERT INTO Users (ID, FirstName, LastName, DOB, Gender,PrivateAcc,Matches, Phone, Email, Picture) " +
                               "VALUES (@ID, @FirstName, @LastName, @DOB, @Gender,@Private,@Matches, @Phone, @Email, @Picture)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID", userID);
                    command.Parameters.AddWithValue("@FirstName", firstName);
                    command.Parameters.AddWithValue("@LastName", lastName);
                    command.Parameters.AddWithValue("@DOB", dob);
                    command.Parameters.AddWithValue("@Gender", gender);
                    command.Parameters.AddWithValue("@Private", false);
                    command.Parameters.AddWithValue("@Matches", 0);
                    command.Parameters.AddWithValue("@Phone", phone);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Picture", (object)picture ?? DBNull.Value); // Handle null picture
                    command.ExecuteNonQuery();
                }
            }
        }


        // --- init user data
        public void SetUpUserData(int UserID)
        {
            using (SqlConnection connection = new SqlConnection(Con.String))
            {
                connection.Open();
                string query = "SELECT * FROM Users WHERE ID = @UserID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserID", UserID);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            ID = Convert.ToInt32(reader["ID"]);
                            FirstName = reader["FirstName"].ToString();
                            LastName = reader["LastName"].ToString();
                            DateTime dob = Convert.ToDateTime(reader["DOB"]);
                            DOB = new DateOnly(dob.Year, dob.Month, dob.Day); // Extract date part
                            Gender = reader["Gender"].ToString();
                            Phone = reader["Phone"].ToString();
                            Email = reader["Email"].ToString();
                            Rank = reader["Rank"].ToString();
                            Private = Convert.ToBoolean(reader["PrivateAcc"].ToString());
                            Matches = Convert.ToInt32(reader["Matches"]);
                            // Handle null value for Winrate
                            Winrate = reader["Winrate"] != DBNull.Value ? Convert.ToSingle(reader["Winrate"]) : 0.0f;
                            Flag = reader["Flag"].ToString();
                            Bio = reader["Bio"].ToString();
                            Favourite = reader["Favorite"].ToString();
                            // Read the picture as byte array
                            byte[] pictureBytes = reader["Picture"] as byte[];
                            if (pictureBytes != null && pictureBytes.Length > 0)
                            {
                                using (MemoryStream ms = new MemoryStream(pictureBytes))
                                {
                                    Picture = Image.FromStream(ms);// --- ver 1 using memorystream
                                }
                            }
                            else
                            {
                                Picture = null;
                            }
                            /*
                             if (!reader.IsDBNull(reader.GetOrdinal("Picture"))) // --- ver 2 
                            {
                                byte[] pictureData = (byte[])reader["Picture"];
                                using (MemoryStream ms = new MemoryStream(pictureData))
                                {
                                    Picture = Image.FromStream(ms);
                                }
                            }
                            */
                            // Populate other properties similarly
                        }
                    }
                }
            }
        }


    }
}
