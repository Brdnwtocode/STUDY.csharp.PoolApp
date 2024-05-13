using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_WPRFinal_PoolApp
{
    public class TOURNAMENT
    {
        public string TournamentID { get; set; }
        public string TournamentName { get; set; }
        public string Organizer { get; set; }
        public string Location { get; set; }
        public DateOnly DateStart { get; set; }
        public DateOnly DateEnd { get; set; }
        public string Description { get; set; }
        public int NumberOfPlayers { get; set; }
        public int PlayersNow { get; set; }
        public int WinnerID { get; set; }
        public string WinnerName { get; set; }
        public Image image { get; set; }

        public TOURNAMENT() { }

        public static List<TOURNAMENT> LoadTournamentsFromDatabase()
        {
            List<TOURNAMENT> tournaments = new List<TOURNAMENT>();
            using (SqlConnection connection = new SqlConnection(Fn.Con()))
            {
                connection.Open();
                string query = "SELECT * FROM TOURNAMENT";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            TOURNAMENT tournament = new TOURNAMENT
                            {
                                TournamentID = reader["TournamentID"].ToString(),
                                TournamentName = reader["TournamentName"].ToString(),
                                Organizer = reader["Organizer"].ToString(),
                                Location = reader["Location"].ToString(),
                                Description = reader["Description"].ToString(),
                                NumberOfPlayers = reader.IsDBNull(reader.GetOrdinal("NumberOfPlayers")) ? 0 : (int)reader["NumberOfPlayers"],
                                PlayersNow = reader.IsDBNull(reader.GetOrdinal("PlayersNow")) ? 0 : (int)reader["PlayersNow"],
                                WinnerID = reader.IsDBNull(reader.GetOrdinal("WinnerID")) ? 0 : (int)reader["WinnerID"],
                                WinnerName = reader["WinnerName"].ToString(),
                            };

                            // Retrieve and convert image if stored as byte array in the database
                            if (!reader.IsDBNull(reader.GetOrdinal("Image")))
                            {
                                byte[] imageBytes = (byte[])reader["Image"];
                                using (MemoryStream ms = new MemoryStream(imageBytes))
                                {
                                    tournament.image = Image.FromStream(ms);
                                }
                            }
                            else
                            {
                                tournament.image = null;
                            }
                            // Parse DateStart if it is not null
                            if (!reader.IsDBNull(reader.GetOrdinal("DateStart")))
                            {
                                tournament.DateStart = DateOnly.Parse(reader["DateStart"].ToString());
                            }
                            // Parse DateEnd if it is not null
                            if (!reader.IsDBNull(reader.GetOrdinal("DateEnd")))
                            {
                                tournament.DateEnd = DateOnly.Parse(reader["DateEnd"].ToString());
                            }

                            tournaments.Add(tournament);
                        }
                    }
                }
            }
            return tournaments;
        }
    }
}
