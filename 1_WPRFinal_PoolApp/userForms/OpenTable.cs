using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1_WPRFinal_PoolApp.userForms
{
    public partial class frmOpenTable : Form
    {
        public frmOpenTable()
        {
            InitializeComponent();
        }

        TABLE table = new TABLE();
        int TableID;
        private Image ResizeImage(Image imgToResize, Size size)
        {
            Bitmap bmp = new Bitmap(size.Width, size.Height);
            using (Graphics g = Graphics.FromImage((Image)bmp))
            {
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.DrawImage(imgToResize, 0, 0, size.Width, size.Height);
            }
            return (Image)bmp;
        }
        public void LoadTable(int ID)
        {
            TableID = ID;
            table.SetUpTableData(ID);
            lblFacility.Text = Facility.GetFacilityNameFromID(table.FacilityID);
            lblName.Text = USER.GetUserNameFromID(table.UID);
            lblLocation.Text = table.Location;
            lblDate.Text = table.DATE.Date.ToString("dd-MM-yyyy");
            lblTime.Text = table.Time;
            lblRules.Text = table.GameRules;
            lblType.Text = table.GameType;
            lblTableNumber.Text += table.TableNumber;
            lblStatus.Text += table.Status;

            USER user = Data.USERs.FirstOrDefault(u => u.ID == table.UID); // Assuming userID is the ID of the user
            if (user != null && user.Picture != null)
            {
                // Resize the image to fit the panel size
                using (Image resizedImage = ResizeImage(user.Picture, pictureBox1.Size))
                {
                    pictureBox1.BackgroundImage = (Image)resizedImage.Clone(); // Set the resized image as the background
                }
            }

            // Set background image of the form to the facility's picture
            Facility facility = Data.facilities.FirstOrDefault(f => f.ID == table.FacilityID); // Assuming facilityID is the ID of the facility
            if (facility != null && facility.image != null)
            {
                this.BackgroundImage = facility.image;
            }


            if(Data.AccID == table.UID)
            {
                lblStatus.Visible = true;
                pnlbtn.Visible = false;
                btn.Visible = false;

            }

        }

        private void btn_Click(object sender, EventArgs e)
        {
            MessageBox.Show(table.AddOpponentIDToTable(TableID, Data.AccID));
        }

        private void lblStatus_Click(object sender, EventArgs e)
        {

        }
    }
}
