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
            string query = @"SELECT f.* 
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

                        dgvFacility.DataSource = dataTable;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error filling Facility DataGridView: " + ex.Message);
            }
        }

        public void FillTournamentDataGridView(DataGridView dgvTournament, int businessID,int MID)
        {
            string query = @"SELECT * 
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

                        dgvTournament.DataSource = dataTable;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error filling Tournament DataGridView: " + ex.Message);
            }
        }
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
        




    }
}
