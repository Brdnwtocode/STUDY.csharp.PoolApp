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

        public void InsertUser(string firstName, string lastName, string gender, DateTime dob, string phone, string email, int userID, byte[] picture)
        {
            using (SqlConnection connection = new SqlConnection(Con.String))
            {
                connection.Open();
                string query = "INSERT INTO Users (ID, FirstName, LastName, DOB, Gender, Phone, Email, Picture) " +
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
    }
}
