using _1_WPRFinal_PoolApp.businessForm;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1_WPRFinal_PoolApp.Forms
{
    public partial class frmBusiness : Form
    {
        public frmBusiness()
        {
            InitializeComponent();
        }



        // --- Functions --- 

        // -- Load Data functions -- 
        public void FillEmployeeDataGridView(DataGridView dgvEmployee, int businessID)
        {
            string query = @"SELECT GroupID, COUNT(*) AS NumberOfEmployee 
                     FROM Business 
                     WHERE MID = @BusinessID 
                     GROUP BY GroupID";

            try
            {
                using (SqlConnection connection = new SqlConnection(Fn.Con()))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@BusinessID", businessID);

                        connection.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        dgvEmployee.DataSource = dataTable;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error filling Employee DataGridView: " + ex.Message);
            }
        }

        public void FillFacilityDataGridView(DataGridView dgvFacility, int businessID)
        {
            string query = @"SELECT f.Image, f.FacilityName, f.Location, f.FacilityID
                     FROM Facility f 
                     INNER JOIN FacilityOwner fo ON f.FacilityID = fo.FacilityID 
                     WHERE fo.BusinessID = @BusinessID";
            try
            {
                using (SqlConnection connection = new SqlConnection(Fn.Con()))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@BusinessID", businessID);

                        connection.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

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

                        dgvFacility.DataSource = dataTable;
                        dgvFacility.Columns["FacilityID"].Visible = false;
                        dgvFacility.AutoResizeColumn(0);
                        dgvFacility.Columns["Image"].DefaultCellStyle.NullValue = null;
                        // Set auto size mode for other columns

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error filling Facility DataGridView: " + ex.Message);
            }
        }


        public void FillTournamentDataGridView(DataGridView dgvTournament, int businessID,int MID)
        {
            string query = @"SELECT Image, TournamentName, NumberOfPlayers, DateStart, DateEnd, Location, WinnerName,TournamentID
                     FROM Tournament 
                     WHERE UID = @BusinessID OR UID = @MID";

            try
            {
                using (SqlConnection connection = new SqlConnection(Fn.Con()))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@BusinessID", businessID);
                        command.Parameters.AddWithValue("@MID", MID);

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
        //

        //
       


        // --- COntrols --- 


        // -- Form Load -- 
        private void frmBusiness_Load(object sender, EventArgs e)
        {
            BUSINESS business = Data.BUSINESSes.FirstOrDefault(u => u.ID == Data.AccID);
            FillEmployeeDataGridView(dgvEmployee, business.ID);
            FillFacilityDataGridView(dgvFacility, business.ID);
            FillTournamentDataGridView(dgvTournament, business.ID,business.MID);

        }

        private void dgvEmployee_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
           
            int groupID = Convert.ToInt32(dgvEmployee.Rows[e.RowIndex].Cells["GroupID"].Value);

            // Query the database to get the required employee information
            string query = @"SELECT Picture, FirstName, LastName, CONVERT(date, DOB) AS DOB, Gender, Email, Phone, ID
                     FROM Business 
                     WHERE GroupID = @GroupID AND MID = @MID";

           
                using (SqlConnection connection = new SqlConnection(Fn.Con()))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@GroupID", groupID);
                        command.Parameters.AddWithValue("@MID", Data.AccID);

                        connection.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                    // Resize the picture column to 150x150 pixels with a zoom layout

                    foreach (DataRow row in dataTable.Rows)
                    {
                        if (row["Picture"] == DBNull.Value || row["Picture"] == null)
                            continue;
                        byte[] imageData = (byte[])row["Picture"];
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
                                    row["Picture"] = resizedImageData;
                                }
                            }
                        }
                    }

                    // Set the DataSource of another DataGridView to display the fetched data
                    dgvFull.DataSource = dataTable;

                        // Hide the ID column
                        dgvFull.Columns["ID"].Visible = false;

                    dgvFull.AutoResizeColumn(0);
                  
                        dgvFull.Columns["Picture"].DefaultCellStyle.NullValue = null;
                    }
                }
          /*  }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching employee data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }*/
        }
        

        //
        private void dgvFacility_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
        }
        //
        
        
        
        private void dgvTournament_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            // Check if a row header is clicked
            if (e.RowIndex >= 0)
            {
                // Get the tournament ID from the clicked row
                string tournamentID = dgvTournament.Rows[e.RowIndex].Cells["TournamentID"].Value?.ToString();

                // Check if the business ID matches the tournament UID or MID
                int businessID = Data.AccID;
                TOURNAMENT tournament = Data.TOURNAMENTs.FirstOrDefault(t => t.TournamentID == tournamentID);

                try
                {
                    // Update the tournament winner
                    if (businessID == tournament.UID || Data.BUSINESSes.Any(b => b.MID == tournament.UID))
                    {
                        // Prompt the user to enter the winner details
                        // For simplicity, let's assume you have a form to input the winner details
                        frmResult enterWinnerForm = new frmResult();

                        enterWinnerForm.SetTID(tournament);
                        enterWinnerForm.ShowDialog();
                       
                    }
                    else
                    {
                        MessageBox.Show("You do not have the authority to update the winner for this tournament.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating tournament winner: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }



        //
        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnAllEmployee_Click(object sender, EventArgs e)
        {

            // Query to select all employees from all groups ordered by groupID where MID = Acc.ID
            string query = @"SELECT Picture,FirstName, LastName, GroupID, DOB, Gender, Email, Phone
                     FROM Business 
                     WHERE MID = @ManagerID";

            try
            {
                using (SqlConnection connection = new SqlConnection(Fn.Con()))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ManagerID", Data.AccID);

                        connection.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        // Resize and display the employee pictures
                        foreach (DataRow row in dataTable.Rows)
                        {
                            if (row["Picture"] == DBNull.Value || row["Picture"] == null)
                                continue;

                            byte[] imageData = (byte[])row["Picture"];
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
                                        row["Picture"] = resizedImageData;
                                    }
                                }
                            }
                        }

                        // Bind the DataTable to the DataGridView to display the employee data
                        dgvFull.DataSource = dataTable;

                        // Hide the FacilityID column
                       

                        // Auto-resize columns
                        dgvFull.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

                        // Set the default cell value to null for the Image column
                        dgvFull.Columns["Picture"].DefaultCellStyle.NullValue = null;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching employee data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel21_Paint(object sender, PaintEventArgs e)
        {

        }
        //




        private void btnAdd_Click(object sender, EventArgs e)
        {
            TOURNAMENT tour = new TOURNAMENT();
            tour.TournamentID = Data.AccID + DateTime.Now.ToString() ;
            tour.TournamentName = txtName.Text;
            BUSINESS business = Data.BUSINESSes.FirstOrDefault(u => u.ID == Data.AccID);
            if (business.MID == 0 || business.MID == null||business.MID.ToString().Length >= 6) tour.UID = Data.AccID;
            else tour.UID = business.MID;
            tour.Organizer = txtOrganizer.Text;
            tour.Location = txtLocation.Text;
            tour.Description = txtDes.Text;
            tour.NumberOfPlayers = (int)numericUpDown1.Value;
            tour.DateStart = dtpStart.Value;
            tour.DateEnd = dtpEnd.Value;
            tour.PlayersNow = (int)numericUpDown1.Value;
            tour.image = pictureBox1.Image;

            tour.InsertTournament(tour);
        }

        private void dgvFacility_RowHeaderMouseDoubleClick_1(object sender, DataGridViewCellMouseEventArgs e)
        {
            // Get the FacilityID from the selected row
            int facilityID = Convert.ToInt32(dgvFacility.Rows[e.RowIndex].Cells["FacilityID"].Value);

            // Query the database to get the required table information
            string query = @"SELECT TableNumber, Date, Time, GameType, Status, UID, OID, IsPublic  
                     FROM Tables 
                     WHERE FacilityID = @FacilityID 
                     ORDER BY Date";

            try
            {
                using (SqlConnection connection = new SqlConnection(Fn.Con()))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@FacilityID", facilityID);

                        connection.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        // Add a new column for Customer
                        DataColumn customerColumn = new DataColumn("Customer", typeof(string));
                        dataTable.Columns.Add(customerColumn);


                        // Populate the Customer column with user names
                        foreach (DataRow row in dataTable.Rows)
                        {
                            int uid = Convert.ToInt32(row["UID"]);
                            string customerName = USER.GetUserNameFromID(uid);

                            row["Customer"] = customerName;
                            if (row["IsPublic"] == "False")
                            {
                                row["Time"] = "";
                                row["Customer"] = "";
                            }
                        }

                        // Bind the DataTable to the DataGridView
                        dgvFull.DataSource = dataTable;
                        // Hide UID and OID columns
                        dgvFull.Columns["UID"].Visible = false;
                        dgvFull.Columns["OID"].Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching table data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnChoose_Click(object sender, EventArgs e)
        {

            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Select Image(*.jpg;*.png;*.gif)|*.jpg;*.png;*.gif";

            if (opf.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(opf.FileName);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
        }

        private void dgvTournament_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnAllFacility_Click(object sender, EventArgs e)
        {
            // Query to select all tables from all facilities owned by a business
            string query = @"SELECT t.TableNumber, t.Date, t.Time, t.GameType, t.Status
                     FROM Tables t
                     INNER JOIN Facility f ON t.FacilityID = f.FacilityID
                     INNER JOIN FacilityOwner fo ON f.FacilityID = fo.FacilityID
                     WHERE fo.BusinessID = @BusinessID";

            try
            {
                using (SqlConnection connection = new SqlConnection(Fn.Con()))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@BusinessID", Data.AccID);

                        connection.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        // Bind the DataTable to the DataGridView
                        dgvFull.DataSource = dataTable;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching table data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            

        }

        private void btnAllTournament_Click(object sender, EventArgs e)
        {
            BUSINESS business = Data.BUSINESSes.FirstOrDefault(u => u.ID == Data.AccID);
            FillTournamentDataGridView(dgvFull, Data.AccID,business.MID);
        }

        private void button1_Click(object sender, EventArgs e)
        {

            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Select Image(*.jpg;*.png;*.gif)|*.jpg;*.png;*.gif";

            if (opf.ShowDialog() == DialogResult.OK)
            {
                pictureBox2.Image = Image.FromFile(opf.FileName);
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = null;
        }

        private void btnAddFacility_Click(object sender, EventArgs e)
        {
            if(txtFLocation.Text == "") { MessageBox.Show("Invalid Location");return; }
            if (txtCapacity.Text == "") { MessageBox.Show("Invalid Capacity"); return; }
            if (richTextBox1.Text == "") { MessageBox.Show("Invalid Name"); return; }

            Facility facility = new Facility();
            facility.ID = Fn.GenerateUniqueRandomID($"SELECT COUNT(*) FROM Facility WHERE FacilityID = @ID");
            facility.Name = richTextBox1.Text;
            facility.Capacity = txtCapacity.Text;
            facility.Description = txtFDes.Text;
            facility.Location = txtFLocation.Text;
            facility.image = pictureBox2.Image;

            facility.InsertFacility(facility);
            
        }
    }
}
