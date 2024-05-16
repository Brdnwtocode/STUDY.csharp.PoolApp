using _1_WPRFinal_PoolApp.userForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1_WPRFinal_PoolApp.businessForm
{
    public partial class frmResult : Form
    {
        public frmResult()
        {
            InitializeComponent();
        }
        TOURNAMENT tournament;

        public void SetTID(TOURNAMENT tour)
        {
            tournament = tour;
        }



        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "" && comboBox1.Text == "")
            {
                MessageBox.Show("missing winnerID");
                return;
            }
            if(int.TryParse(comboBox1.Tag.ToString(), out int id))
                TOURNAMENT.UpdateTournamentWinner(tournament.TournamentID, id);

            else 
            // Update the tournament winner in the database and static list
            TOURNAMENT.UpdateTournamentWinner(tournament.TournamentID, int.Parse(txtID.Text));
        }

        private void frmResult_Load(object sender, EventArgs e)
        {
            lblLoca.Text += tournament.Location;
            lblName.Text = tournament.TournamentName;
            lblOrg.Text += tournament.Organizer;
            lblPlayers.Text += tournament.NumberOfPlayers + "";
            txtDes.Text = tournament.Description;

            pictureBox1.Image = tournament.image;
            LoadPlayersIntoComboBox(tournament.TournamentID);
        }
        public void LoadPlayersIntoComboBox(string tournamentID)
        {
            comboBox1.Items.Clear(); // Clear existing items

            string query = @"SELECT UserID, FirstName, LastName
                         FROM UserTournamentRelationship
                         INNER JOIN Users ON UserTournamentRelationship.UserID = Users.ID
                         WHERE TournamentID = @TournamentID AND RelationshipStatus != 'Disqualified'";

            try
            {
                using (SqlConnection connection = new SqlConnection(Fn.Con()))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@TournamentID", tournamentID);
                        connection.Open();

                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            string userID = reader["UserID"].ToString();
                            string firstName = reader["FirstName"].ToString();
                            string lastName = reader["LastName"].ToString();
                            string playerName = $"{firstName} {lastName}-{userID}";

                            // Add player name to ComboBox display
                            comboBox1.Items.Add(playerName);

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading players: " + ex.Message);
            }
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                string[] parts = comboBox1.SelectedItem.ToString().Split('-');
                if (parts.Length == 2)
                {
                    string selectedUserID = parts[1];
                    string selectedPlayerName = parts[0];

                    comboBox1.Tag = selectedUserID;
                }

            }

        }
    }
}
