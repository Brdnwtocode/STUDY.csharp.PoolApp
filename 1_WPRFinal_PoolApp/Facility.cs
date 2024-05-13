using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_WPRFinal_PoolApp
{
    public class Facility
    {

        public int ID { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Capacity { get; set; }
        public string Description { get; set; }
        public Image image { get; set; }

        public Facility() { }

        public static List<Facility> LoadFacilitiesFromDatabase()
        {
            List<Facility> facilities = new List<Facility>();
            using (SqlConnection connection = new SqlConnection(Fn.Con()))
            {
                connection.Open();
                string query = "SELECT * FROM Facility";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Facility facility = new Facility
                            {
                                ID = (int)reader["FacilityID"],
                                Name = reader["FacilityName"].ToString(),
                                Location = reader["Location"].ToString(),
                                Capacity = reader["Capacity"].ToString(),
                                Description = reader["Description"].ToString(),
                            };

                            // Retrieve and convert image if stored as byte array in the database
                            if (!reader.IsDBNull(reader.GetOrdinal("Image")))
                            {
                                byte[] pictureBytes = (byte[])reader["Image"];
                                using (MemoryStream ms = new MemoryStream(pictureBytes))
                                {
                                    facility.image = Image.FromStream(ms);
                                }
                            }
                            else
                            {
                                facility.image = null;
                            }

                            facilities.Add(facility);
                        }
                    }
                }
            }
            return facilities;
        }

    }
}
