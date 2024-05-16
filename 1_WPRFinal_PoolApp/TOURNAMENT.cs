using _1_WPRFinal_PoolApp.userForms;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace _1_WPRFinal_PoolApp
{
    public class TOURNAMENT
    {
        public string TournamentID { get; set; }
        public int UID { get; set; }
        public string TournamentName { get; set; }
        public string Organizer { get; set; }
        public string Location { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public string Description { get; set; }
        public int NumberOfPlayers { get; set; }
        public int PlayersNow { get; set; }
        public int WinnerID { get; set; }
        public string WinnerName { get; set; }
        public Image image { get; set; }

        public TOURNAMENT() { }


        public void InsertTournament(TOURNAMENT tournament)
        {
            string query = @"INSERT INTO Tournament (TournamentID,UID, TournamentName, Organizer, Location, DateStart, DateEnd, Description, NumberOfPlayers, PlayersNow, WinnerID, WinnerName, Image) 
                     VALUES (@TournamentID,@UID, @TournamentName, @Organizer, @Location, @DateStart, @DateEnd, @Description, @NumberOfPlayers, @PlayersNow, @WinnerID, @WinnerName, @Image)";

            try
            {
                using (SqlConnection connection = new SqlConnection(Fn.Con()))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@TournamentID", tournament.TournamentID);
                        command.Parameters.AddWithValue("@UID", tournament.UID);
                        command.Parameters.AddWithValue("@TournamentName", tournament.TournamentName);
                        command.Parameters.AddWithValue("@Organizer", tournament.Organizer);
                        command.Parameters.AddWithValue("@Location", tournament.Location);
                        command.Parameters.AddWithValue("@DateStart", tournament.DateStart.Date);
                        command.Parameters.AddWithValue("@DateEnd", tournament.DateEnd.Date);
                        command.Parameters.AddWithValue("@Description", tournament.Description);
                        command.Parameters.AddWithValue("@NumberOfPlayers", tournament.NumberOfPlayers);
                        command.Parameters.AddWithValue("@PlayersNow", 0);
                        command.Parameters.AddWithValue("@WinnerID", DBNull.Value);
                        command.Parameters.AddWithValue("@WinnerName", DBNull.Value);

                        // Convert Image to byte array
                        if (tournament.image != null)
                        {
                            byte[] imageBytes = Fn.ImageToByteArray(tournament.image);
                            command.Parameters.AddWithValue("@Image", imageBytes);
                        }
                        else command.Parameters.AddWithValue("@Image", DBNull.Value);

                        connection.Open();
                        command.ExecuteNonQuery();

                        MessageBox.Show("Tournament Created successfully!");
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

        // Generate Panels
        public static void LoadTournamentPanels(FlowLayoutPanel fpnlTournaments)
        {
            // Clear existing controls in the flow panel
            fpnlTournaments.Controls.Clear();

            // Iterate through the list of tournaments
            foreach (var tournament in Data.TOURNAMENTs)
            {
                // Create a panel to display tournament information
                Panel tournamentPanel = new Panel();
                tournamentPanel.BorderStyle = BorderStyle.FixedSingle;
                tournamentPanel.Width = 500;
                tournamentPanel.Height = 230;
                Random rnd = new Random(tournament.UID + 2000);
                tournamentPanel.BackColor = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));

                // Add tournament information to the panel
                Label lblTournamentName = new Label();
                lblTournamentName.Text = "Tournament Name: " + tournament.TournamentName;
                lblTournamentName.AutoSize = true;
                lblTournamentName.Location = new System.Drawing.Point(10, 10);
                tournamentPanel.Controls.Add(lblTournamentName);
                lblTournamentName.BackColor = Color.Black;
                lblTournamentName.ForeColor = Color.White;

                Label lblOrganizer = new Label();
                lblOrganizer.Text = "Organizer: " + tournament.Organizer;
                lblOrganizer.AutoSize = true;
                lblOrganizer.Location = new System.Drawing.Point(10, 40);
                tournamentPanel.Controls.Add(lblOrganizer);
                lblOrganizer.BackColor = Color.LightCoral;
                lblOrganizer.ForeColor = Color.Black;

                Label lblLocation = new Label();
                lblLocation.Text = "Location: " + tournament.Location;
                lblLocation.AutoSize = true;
                lblLocation.Location = new System.Drawing.Point(10, 65);
                tournamentPanel.Controls.Add(lblLocation);
                lblLocation.BackColor = Color.Black;
                lblLocation.ForeColor = Color.White;

                Label lblDate = new Label();
                lblDate.Text = "Date: " + tournament.DateStart.ToString("MM/dd/yyyy") + " - " + tournament.DateEnd.ToString("MM/dd/yyyy");
                lblDate.AutoSize = true;
                lblDate.Location = new System.Drawing.Point(10, 90);
                tournamentPanel.Controls.Add(lblDate);
                lblDate.BackColor = Color.LightGray;
                lblDate.ForeColor = Color.Black;

                Label lblAvailableSlots = new Label();
                lblAvailableSlots.Text = "Available Slots: " + (tournament.NumberOfPlayers - tournament.PlayersNow);
                lblAvailableSlots.AutoSize = true;
                lblAvailableSlots.Location = new System.Drawing.Point(10, 115);
                tournamentPanel.Controls.Add(lblAvailableSlots);
                lblAvailableSlots.BackColor = Color.Black;
                lblAvailableSlots.ForeColor = Color.White;

                // Create a button to enter the tournament
                Button btnEnterTournament = new Button();
                btnEnterTournament.Text = "Enter Tournament";
                btnEnterTournament.AutoSize = true;
                btnEnterTournament.Location = new System.Drawing.Point(10, 140);
                btnEnterTournament.BackColor = Color.SpringGreen;
                btnEnterTournament.ForeColor = Color.Black;

                // Use a lambda expression to capture the TournamentID within the event handler
                btnEnterTournament.Click += (sender, e) =>
                {
                    string tournamentID = tournament.TournamentID;
                    // Call a function to handle entering the tournament with the captured tournamentID
                    EnterTournament(Data.AccID, tournamentID); 
                    // Reload the panel generation function to reflect the changes
                    LoadTournamentPanels(fpnlTournaments);
                };

                // Add the button to the panel
                tournamentPanel.Controls.Add(btnEnterTournament);

                // Add the panel to the flow panel
                fpnlTournaments.Controls.Add(tournamentPanel);
            }
        }

        // Function to handle entering a tournament
        public static void EnterTournament(int userID, string tournamentID)
        {
            try
            {
                // Check if the user has already entered the tournament
                string query = @"SELECT COUNT(*) FROM UserTournamentRelationship WHERE UserID = @UserID AND TournamentID = @TournamentID";
                int existingRelationshipCount = 0;

                using (SqlConnection connection = new SqlConnection(Fn.Con()))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserID", userID);
                        command.Parameters.AddWithValue("@TournamentID", tournamentID);

                        existingRelationshipCount = (int)command.ExecuteScalar();
                    }
                }

                if (existingRelationshipCount > 0)
                {
                    // User has already entered the tournament, display a message
                    MessageBox.Show("You have already entered this tournament.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // If the user has not entered the tournament, insert a new relationship
                // Write your SQL query to insert the relationship into the UserTournamentRelationship table
                string insertQuery = @"INSERT INTO UserTournamentRelationship (UserID, TournamentID, RelationshipStatus) VALUES (@UserID, @TournamentID, 'Compete')";

                using (SqlConnection connection = new SqlConnection(Fn.Con()))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(insertQuery, connection))
                    {
                        command.Parameters.AddWithValue("@UserID", userID);
                        command.Parameters.AddWithValue("@TournamentID", tournamentID);

                        command.ExecuteNonQuery();
                    }
                }

                // Update the tournament
                UpdateTournament(tournamentID);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error entering tournament: " + ex.Message);
            }
        }

        public static void UpdateTournament(string tournamentID)
        {
            try
            {
                // Establish a connection to the database using SqlConnection
                using (SqlConnection connection = new SqlConnection(Fn.Con()))
                {
                    // Open the connection
                    connection.Open();

                    // Define your SQL query to update the tournament in the Tournament table
                    string updateQuery = @"UPDATE Tournament SET PlayersNow = PlayersNow + 1 WHERE TournamentID = @TournamentID";

                    // Create a SqlCommand object to execute the updateQuery
                    using (SqlCommand command = new SqlCommand(updateQuery, connection))
                    {
                        // Add parameters to the command
                        command.Parameters.AddWithValue("@TournamentID", tournamentID);

                        // Execute the updateQuery
                        command.ExecuteNonQuery();
                    }
                }

                // Update the tournament in the static list Data.Tournaments
                TOURNAMENT tournamentToUpdate = Data.TOURNAMENTs.FirstOrDefault(t => t.TournamentID == tournamentID);
                if (tournamentToUpdate != null)
                {
                    // Update the tournament object
                    tournamentToUpdate.PlayersNow++;

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error updating tournament: " + ex.Message);
            }
        }

        public static void UpdateTournamentWinner(string tournamentID, int winnerID)
        {
            // Update the tournament winner in the database
            string updateQuery = "UPDATE Tournament SET WinnerID = @WinnerID, WinnerName = @WinnerName,  WHERE TournamentID = @TournamentID";
            string WinnerName = USER.GetUserNameFromID(winnerID);
            using (SqlConnection connection = new SqlConnection(Fn.Con()))
            {
                using (SqlCommand command = new SqlCommand(updateQuery, connection))
                {
                    command.Parameters.AddWithValue("@WinnerID", winnerID);
                    command.Parameters.AddWithValue("@WinnerName", WinnerName);
                    command.Parameters.AddWithValue("@TournamentID", tournamentID);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }

            // Update the tournament winner in the static list Data.Tournaments
            TOURNAMENT tournamentToUpdate = Data.TOURNAMENTs.FirstOrDefault(t => t.TournamentID == tournamentID);
            if (tournamentToUpdate != null)
            {
                tournamentToUpdate.WinnerID = winnerID;
                tournamentToUpdate.WinnerName = WinnerName;
                // You can also update other properties of the tournament if needed
            }
            string q = "Congrats!! " + WinnerName+ " for becoming the winner!";
            MessageBox.Show(q);
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
                                UID  = (int)reader["UID"],
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
                                tournament.DateStart = DateTime.Parse(reader["DateStart"].ToString()).Date;
                            }
                            // Parse DateEnd if it is not null
                            if (!reader.IsDBNull(reader.GetOrdinal("DateEnd")))
                            {
                                tournament.DateEnd = DateTime.Parse(reader["DateEnd"].ToString()).Date;
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
