using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1_WPRFinal_PoolApp.userForms
{
    public partial class UserTournament : Form
    {
        public UserTournament()
        {
            InitializeComponent();
        }



        public void FillTournamentDataGridView(DataGridView dgvTournament)
        {
            string query = @"SELECT Image, TournamentName, NumberOfPlayers, DateStart, DateEnd, Location,       WinnerName,TournamentID
                     FROM Tournament 
                    ";

            try
            {
                using (SqlConnection connection = new SqlConnection(Fn.Con()))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {


                        connection.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        // Convert the image data to 100x100 size
                        foreach (DataRow row in dataTable.Rows)
                        {
                            if (row["Image"] == DBNull.Value || row["Image"] == null)
                                continue;
                            byte[] imageData = (byte[])row["Image"];
                            if (imageData != null && imageData.Length > 0)
                            {
                                using (MemoryStream ms = new MemoryStream(imageData))
                                {
                                    Image originalImage = Image.FromStream(ms);
                                    Image resizedImage = new Bitmap(originalImage, 150, 150);

                                    using (MemoryStream resizedMs = new MemoryStream())
                                    {
                                        resizedImage.Save(resizedMs, ImageFormat.Jpeg); // Use appropriate image format
                                        byte[] resizedImageData = resizedMs.ToArray();

                                        // Update the row with the resized image byte array
                                        row["Image"] = resizedImageData;
                                    }
                                }
                            }
                        }

                        dgvTournament.DataSource = dataTable;
                        dgvTournament.Columns["TournamentID"].Visible = false;
                        dgvTournament.AutoResizeColumn(0);
                        dgvTournament.Columns["Image"].DefaultCellStyle.NullValue = null;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error filling Tournament DataGridView: " + ex.Message);
            }
        }
        public void FillMyTournamentDataGridView(DataGridView dgvTournament)
        {
            string query = @"SELECT Image, TournamentName, NumberOfPlayers, DateStart, DateEnd, Location, WinnerName,TournamentID
                     FROM Tournament 
                     INNER JOIN UserTournamentRelationship ON Tournament.TournamentID = UserTournamentRelationship.TournamentID
                     WHERE UserID = @UserID";

            try
            {
                using (SqlConnection connection = new SqlConnection(Fn.Con()))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {

                        command.Parameters.AddWithValue("@UserID", Data.AccID);

                        connection.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        // Convert the image data to 100x100 size
                        foreach (DataRow row in dataTable.Rows)
                        {
                            if (row["Image"] == DBNull.Value || row["Image"] == null)
                                continue;
                            byte[] imageData = (byte[])row["Image"];
                            if (imageData != null && imageData.Length > 0)
                            {
                                using (MemoryStream ms = new MemoryStream(imageData))
                                {
                                    Image originalImage = Image.FromStream(ms);
                                    Image resizedImage = new Bitmap(originalImage, 150, 150);

                                    using (MemoryStream resizedMs = new MemoryStream())
                                    {
                                        resizedImage.Save(resizedMs, ImageFormat.Jpeg); // Use appropriate image format
                                        byte[] resizedImageData = resizedMs.ToArray();

                                        // Update the row with the resized image byte array
                                        row["Image"] = resizedImageData;
                                    }
                                }
                            }
                        }

                        dgvTournament.DataSource = dataTable;
                        dgvTournament.Columns["TournamentID"].Visible = false;
                        dgvTournament.AutoResizeColumn(0);
                        dgvTournament.Columns["Image"].DefaultCellStyle.NullValue = null;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error filling Tournament DataGridView: " + ex.Message);
            }
        }


        public static void LoadUsersInTournament(DataGridView dataGridView1, string tournamentID)
        {
            // Clear existing data in DataGridView
            dataGridView1.Rows.Clear();

            // Query to get information of users in the tournament
            string query = @"SELECT UT.UserID, U.FirstName, U.LastName, U.Rank, U.WinRate, U.Gender, CONVERT(NVARCHAR(10), U.DOB, 101) AS DOB
                     FROM UserTournamentRelationship UT
                     INNER JOIN Users U ON UT.UserID = U.ID
                     WHERE UT.TournamentID = @TournamentID AND UT.RelationshipStatus != 'Disqualified'";

            try
            {
                using (SqlConnection connection = new SqlConnection(Fn.Con()))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@TournamentID", tournamentID);
                        connection.Open();

                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                       dataGridView1.DataSource = dataTable;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading users in tournament: " + ex.Message);
            }
        }

        private void UserTournament_Load(object sender, EventArgs e)
        {
            FillTournamentDataGridView(dataGridView1);
            FillMyTournamentDataGridView(dataGridView2);
        }

        private void dataGridView2_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // Check if a row header is clicked
            if (e.RowIndex >= 0)
            {
                // Get the tournament ID from the clicked row
                string tournamentID = dataGridView2.Rows[e.RowIndex].Cells["TournamentID"].Value.ToString();

                TOURNAMENT tournamentToUpdate = Data.TOURNAMENTs.FirstOrDefault(t => t.TournamentID == tournamentID);
                Players players = new Players();
                players.SET(tournamentToUpdate);
                players.ShowDialog();
                // Call function to load information of users in the tournament

            }
        }

        private void dataGridView1_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // Check if a row header is clicked
            if (e.RowIndex >= 0)
            {
                // Get the tournament ID from the clicked row
                string tournamentID = dataGridView1.Rows[e.RowIndex].Cells["TournamentID"].Value.ToString();

                TOURNAMENT tournamentToUpdate = Data.TOURNAMENTs.FirstOrDefault(t => t.TournamentID == tournamentID);
                Players players = new Players();
                players.SET(tournamentToUpdate);
                players.ShowDialog();
                // Call function to load information of users in the tournament

            }
        }
    }
}
