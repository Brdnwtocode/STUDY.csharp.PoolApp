using Microsoft.VisualBasic.ApplicationServices;
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

namespace _1_WPRFinal_PoolApp.userForms
{
    public partial class frmCareer : Form
    {
        public frmCareer()
        {
            InitializeComponent();
        }


        // --- Functions ---

        // -- Fill datagridview --
        public static void FillDataGridViewWithMatchResults(DataGridView dataGridView1, int userID)
        {
            string query = @"SELECT * FROM MatchResults WHERE UserID1 = @UserID OR UserID2 = @UserID";

            try
            {
                using (SqlConnection connection = new SqlConnection(Fn.Con()))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserID", userID);

                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        // Clear existing data in DataGridView
                        dataGridView1.Rows.Clear();
                        dataGridView1.Columns.Clear();

                        // Bind the DataTable to the DataGridView
                        dataGridView1.DataSource = dataTable;
                        // Calculate winrate and matches
                        int matches = dataTable.Rows.Count;
                        int wins = 0;

                        foreach (DataRow row in dataTable.Rows)
                        {
                            int winnerID = Convert.ToInt32(row["WinnerID"]);

                            if (winnerID == userID)
                            {
                                wins++;
                            }
                        }

                        float winrate = (matches > 0) ? (float)wins / matches : 0f;

                        // Update user's winrate and matches
                        USER user = Data.USERs.FirstOrDefault(u => u.ID == userID);
                        if (user != null)
                        {
                            user.Matches = matches;
                            user.Winrate = winrate;
                            
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching match results: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //


        // -- SetUpPage
        public void Filldata()
        {
            FillDataGridViewWithMatchResults(dataGridView1, Data.AccID);
            USER user = Data.USERs.FirstOrDefault(u => u.ID == Data.AccID);
            lblMatches.Text = "Match played: " + user.Matches + "";
            lblWinrate.Text = "Winrate: " + user.Winrate + "";
            lblRank.Text = "Rank: " + user.Rank;
        }


        // ---  controls  --- 

        // -- Load Form 
        private void frmCareer_Load(object sender, EventArgs e)
        {   
            Filldata();
            TABLE.GenerateTablePanels(fpnlMyTables);
            TABLE.GenerateTablePanels(fpnlClosedTable);
        }
    }
}
