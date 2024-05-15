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


        public void InsertTournament(TOURNAMENT tournament)
        {
            string query = @"INSERT INTO Tournament (TournamentID, TournamentName, Organizer, Location, DateStart, DateEnd, Description, NumberOfPlayers, PlayersNow, WinnerID, WinnerName, Image) 
                     VALUES (@TournamentID, @TournamentName, @Organizer, @Location, @DateStart, @DateEnd, @Description, @NumberOfPlayers, @PlayersNow, @WinnerID, @WinnerName, @Image)";

            try
            {
                using (SqlConnection connection = new SqlConnection(Fn.Con()))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@TournamentID", tournament.TournamentID);
                        command.Parameters.AddWithValue("@TournamentName", tournament.TournamentName);
                        command.Parameters.AddWithValue("@Organizer", tournament.Organizer);
                        command.Parameters.AddWithValue("@Location", tournament.Location);
                        command.Parameters.AddWithValue("@DateStart", tournament.DateStart);
                        command.Parameters.AddWithValue("@DateEnd", tournament.DateEnd);
                        command.Parameters.AddWithValue("@Description", tournament.Description);
                        command.Parameters.AddWithValue("@NumberOfPlayers", tournament.NumberOfPlayers);
                        command.Parameters.AddWithValue("@PlayersNow", tournament.PlayersNow);
                        command.Parameters.AddWithValue("@WinnerID", tournament.WinnerID);
                        command.Parameters.AddWithValue("@WinnerName", tournament.WinnerName);

                        // Convert Image to byte array
                        byte[] imageBytes = ImageToByteArray(tournament.image);
                        command.Parameters.AddWithValue("@Image", imageBytes);

                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error inserting tournament: " + ex.Message);
            }
        }

        // Helper method to convert Image to byte array
        private byte[] ImageToByteArray(Image image)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Png); // Change ImageFormat as per your image type
                return ms.ToArray();
            }
        }


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
