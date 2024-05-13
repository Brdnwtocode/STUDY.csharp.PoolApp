using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_WPRFinal_PoolApp
{
    public class TABLE
    {
        public int TableID { get; set; }
        public int FacilityID{ get; set; }
        public int UID { get; set; }

        public int TableNumber { get; set; }
        public bool IsPublic { get; set; }
        public string PrivateKey{ get; set; }
        public string Location { get; set; }
        public DateTime Date{ get; set; }
        public TimeOnly Time { get; set; }
        public string GameType { get; set; }
        public string GameRules { get; set; }
        public int PlayerLimit { get; set; }
        public string Status { get; set; }

        public TABLE () { }

        public static List<TABLE> LoadTablesFromDatabase()
        {
            List<TABLE> tables = new List<TABLE>();
            using (SqlConnection connection = new SqlConnection(Fn.Con()))
            {
                connection.Open();
                string query = "SELECT * FROM Tables";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            TABLE table = new TABLE
                            {
                                TableID = (int)reader["TableID"],
                                UID = (int)reader["UID"],
                                FacilityID = (int)reader["FacilityID"],
                                TableNumber = (int)reader["TableNumber"],
                                IsPublic = (bool)reader["IsPublic"],
                                PrivateKey = reader["PrivateKey"].ToString(),
                                Location = reader["Location"].ToString(),
                                GameType = reader["GameType"].ToString(),
                                GameRules = reader["GameRules"].ToString(),
                                PlayerLimit = reader.IsDBNull(reader.GetOrdinal("PlayerLimit")) ? 0 : (int)reader["PlayerLimit"],
                                Status = reader["Status"].ToString()
                            };
                            // Parse Date if it is not null
                            if (!reader.IsDBNull(reader.GetOrdinal("Date")))
                            {
                                // Extract the date part and create a DateOnly instance
                                table.Date = DateTime.Parse(reader["Date"].ToString());
                            }
                            // Parse Time if it is not null
                            if (!reader.IsDBNull(reader.GetOrdinal("Time")))
                            {
                                table.Time = TimeOnly.Parse(reader["Time"].ToString());
                            }


                            tables.Add(table);
                        }
                    }
                }
            }
            return tables;
        }


        public void InsertTable()
        {
            // Connection string to your SQL Server database
           

            // Query to insert a new table
            string query = "INSERT INTO Tables (TableID,FacilityID, UID, TableNumber, IsPublic, PrivateKey, Location, Date, Time, GameType, GameRules, PlayerLimit, Status) " +
                           "VALUES (@tableID,@FacilityID, @UID, @TableNumber, @IsPublic, @PrivateKey, @Location, @Date, @Time, @GameType, @GameRules, @PlayerLimit, @Status)";

            // Using statement ensures the connection is properly closed and disposed
            using (SqlConnection connection = new SqlConnection(Fn.Con()))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add parameters
                    command.Parameters.AddWithValue("@TableID", TableID);
                    command.Parameters.AddWithValue("@FacilityID", FacilityID);
                    command.Parameters.AddWithValue("@UID", UID);
                    command.Parameters.AddWithValue("@TableNumber", TableNumber);
                    command.Parameters.AddWithValue("@IsPublic", IsPublic);
                    command.Parameters.AddWithValue("@PrivateKey", PrivateKey);
                    command.Parameters.AddWithValue("@Location", Location);
                    command.Parameters.AddWithValue("@Date", Date);
                    command.Parameters.AddWithValue("@Time", Time);
                    command.Parameters.AddWithValue("@GameType", GameType);
                    command.Parameters.AddWithValue("@GameRules", GameRules);
                    command.Parameters.AddWithValue("@PlayerLimit", PlayerLimit);
                    command.Parameters.AddWithValue("@Status", Status);

                    // Execute the query
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
