using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1_WPRFinal_PoolApp.userForms
{
    public partial class Players : Form
    {
        public Players()
        {
            InitializeComponent();
        }
        TOURNAMENT tour;

        public void SET(TOURNAMENT tour)
        {
            this.tour = tour;
            label1.Text = tour.Organizer;
            label2.Text = tour.TournamentName;
            label3.Text += tour.WinnerName;
        }
        private void Players_Load(object sender, EventArgs e)
        {
            UserTournament.LoadUsersInTournament(dataGridView1, tour.TournamentID);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
