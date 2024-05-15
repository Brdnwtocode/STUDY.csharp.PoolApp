using _1_WPRFinal_PoolApp.userForms;
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
        // -- SetData
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
        //

        // -- Load Combobox
        private void LoadFacilitiesComboBox()
        {
            // Clear existing items in the ComboBox
            cbFacility.Items.Clear();

            // Iterate through each facility in the Data.facilities list
            foreach (Facility facility in Data.facilities)
            {
                // Display facility name and location in the ComboBox
                cbFacility.Items.Add($"{facility.Name} - {facility.Location}");
            }
        }
        private (int, string) GetSelectedFacilityInfo()
        {
            // Check if an item is selected in the ComboBox
            if (cbFacility.SelectedIndex != -1)
            {
                // Get the selected facility from the ComboBox
                string selectedFacility = cbFacility.SelectedItem.ToString();

                // Split the selected item to extract FacilityID and Location
                string[] facilityParts = selectedFacility.Split(new string[] { " - " }, StringSplitOptions.None);

                // Extract FacilityID and Location
                int facilityID = Data.facilities[cbFacility.SelectedIndex].ID;
                string location = facilityParts[1]; // Second part contains the location

                // Return the FacilityID and Location
                return (facilityID, location);
            }
            else
            {
                // If no item is selected, return default values
                return (0, "");
            }
        }
        //

        // -- verif
        private bool verif()
        {

            if(nudDayOfDate.Value < 1 || nudDayOfDate.Value > 30)
            {
                MessageBox.Show("Invalid date");
                return false;
            }
            if (nudMonthOfDate.Value < 1 || nudMonthOfDate.Value > 12)
            {
                MessageBox.Show("Invalid month");
                return false;
            }
            if (nudHourOfTime.Value < 0 || nudHourOfTime.Value > 23)
            {
                MessageBox.Show("Invalid Hour");
                return false;
            }
            if (nudMinuteOfTime.Value < 0 || nudMinuteOfTime.Value > 60)
            {
                MessageBox.Show("Invalid Minute");
                return false;
            }
            if (nudPlayerLimit.Value < 1 || nudPlayerLimit.Value > 6)
            {
                MessageBox.Show("Invalid Player Limit");
                return false;
            }
            if ( txtPrivateKey.Text.Length > 8 )
            {
                MessageBox.Show("Invalid Key, key must be less than 8 character");
                return false;
            }
            return true;
        }
        //

         // -- Clear controls 
         private void clearControl()
        {
            cbFacility.ResetText();
            cbGameRules.ResetText();
            cbGameType.ResetText();
            nudDayOfDate.ResetText();
            nudHourOfTime.ResetText();
            nudMinuteOfTime.ResetText();
            nudMonthOfDate.ResetText();
            nudPlayerLimit.ResetText();
            txtPrivateKey.ResetText();
            ckbPrivate.Checked = false;

        }
     

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }



        // --- controls

        // -- load
        private void frmUser_Load(object sender, EventArgs e)
        {
            LoadFacilitiesComboBox();
            TABLE.LoadTables(fpnlTables);
            Facility.GenerateFacilityPanels(fpnlLocation);
        }

        private void cbFacility_SelectedIndexChanged(object sender, EventArgs e)
        {
        } //


        // -- Create Button
        
        private void btnCreateTable_Click(object sender, EventArgs e)
        {

            if(!verif()) return;
            // Create a new instance of TABLE
            TABLE tb = new TABLE();

            // Generate a unique TableID
            tb.TableID = Fn.GenerateUniqueRandomID("SELECT COUNT(*) FROM Tables WHERE TableID = @ID");

            // Set the User's ID
            tb.UID = user.ID;
            tb.TableNumber = (int)nudTableNumber.Value;
            // Get the selected FacilityID and Location from the ComboBox
            (int facilityID, string location) = GetSelectedFacilityInfo();
            tb.FacilityID = facilityID;
            tb.Location = location;

            // Set IsPublic based on the state of the checkbox
            tb.IsPublic = !ckbPrivate.Checked;
            tb.PrivateKey = "";
            // If IsPublic is false, set PrivateKey from the textbox
            if (!tb.IsPublic)
            {
                tb.PrivateKey = txtPrivateKey.Text;
            }

            // Retrieve Date from NumericUpDown controls

            tb.DATE = new DateTime((DateTime.Now.Year), (int)nudMonthOfDate.Value, (int)nudDayOfDate.Value);
            // Retrieve Time from NumericUpDown controls
            int hour = (int)nudHourOfTime.Value; 
            int minute = (int)nudMinuteOfTime.Value ;
            tb.Time = string.Format("{0:D2}:{1:D2}:00", hour, minute); 
            // Retrieve selected GameType and GameRules from ComboBoxes
            tb.GameType = cbGameType.Text.ToString();
            tb.GameRules = cbGameRules.Text.ToString();

            // Retrieve PlayerLimit from NumericUpDown control
            tb.PlayerLimit = (int)nudPlayerLimit.Value;

            // Set default Status
            tb.Status = "Open";
            try
            {
                tb.InsertTable();
                Data.TABLEs.Add(tb);
                TABLE.LoadTables(fpnlTables);
            }
            catch(Exception ex)
            {
                throw ex;
                return;
            }
            MessageBox.Show("Create Table Complete!");
            clearControl();
            
        }

        private void ckbPrivate_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbPrivate.Checked == true) txtPrivateKey.Visible = true;
            else txtPrivateKey.Visible = false;
        }

        private void btnFind_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnRank_Click(object sender, EventArgs e)
        {
            frmCareer frm = new frmCareer();
            this.Hide();
            frm.ShowDialog();
            this.Show();
        }
    }
}
