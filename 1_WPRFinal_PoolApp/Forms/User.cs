using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1_WPRFinal_PoolApp.Forms
{
    public partial class frmUser : Form
    {
        public frmUser()
        {
            InitializeComponent();
        }

        USER user = new USER();

        // --- functions 
        public void SetUserData(int UserID)
        {
            user.SetUpUserData(UserID);
            lblName.Text += user.FirstName;
            if(user.Picture != null) 
                pictureBox1.Image = user.Picture;
            if (user.Bio != "") lblBio.Text = user.Bio;
            else lblBio.ForeColor = Color.RoyalBlue;
            if (user.Rank != null) lblRank.Text +="\n"+ user.Rank;
            if (user.Winrate != null) lblWinrate.Text += "\n" + user.Winrate+"";
            if (user.Favourite != null) lblFavourite.Text += "\n" + user.Favourite;
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
