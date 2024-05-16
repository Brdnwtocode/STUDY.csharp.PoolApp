using iTextSharp.text.pdf;
using iTextSharp.text;
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

namespace _1_WPRFinal_PoolApp
{
    public partial class frmBusinessDetails : Form
    {
        private string _businessID;
        private string connectionString = @"Data Source=NERVOUS;Initial Catalog=Pool;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public frmBusinessDetails(string businessID)
        {
            InitializeComponent();
            _businessID = businessID;
            LoadFacilities();
            LoadTournaments();
            LoadBusinessDetails();
        }
        private void LoadBusinessDetails()
        {
            string query = "SELECT LastName, Email FROM dbo.Business WHERE ID = @BusinessID";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@BusinessID", _businessID);
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string lastName = reader["LastName"].ToString();
                        string email = reader["Email"].ToString();
                        // Store these details to use later in the PrintBusinessDetails method
                        lblLastName.Text = lastName;  // Assuming you have a Label control to display Last Name
                        lblEmail.Text = email;        // Assuming you have a Label control to display Email
                    }
                }
            }
        }

        /* private void frmBusinessDetails_Load(object sender, EventArgs e)
         {
             LoadFacilities();
             LoadTournaments();
         }*/

        private void LoadFacilities()
        {
            string query = @"SELECT f.* FROM Facility f
                    INNER JOIN FacilityOwner fo ON f.FacilityID = fo.FacilityID
                    WHERE fo.BusinessID = @BusinessID";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@BusinessID", _businessID);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    FacilityDataGridView.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading facilities: " + ex.Message);
            }
        }

        private void LoadTournaments()
        {
            string query = @"SELECT t.* FROM Tournament t
                     WHERE t.UID = @BusinessID";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open(); // Ensure you open the connection
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@BusinessID", _businessID);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    /*  if (dt.Rows.Count == 0)
                      {
                          MessageBox.Show("No tournaments found for this business.");
                      }*/

                    TournamentDataGridView.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load tournaments: " + ex.Message);
            }
        }

        private void PrintBusinessButton_Click(object sender, EventArgs e)
        {
            PrintBusinessDetails();
        }
        private void PrintBusinessDetails()
        {
            string[] excludeColumns = new string[] { "Image" };
            string lastName = lblLastName.Text;  // hoặc biến nếu bạn không sử dụng label
            string email = lblEmail.Text;

            SaveFileDialog save = new SaveFileDialog();
            save.FileName = "BusinessDetails.pdf";
            save.Filter = "PDF Files (*.pdf)|*.pdf|All files (*.*)|*.*";
            if (save.ShowDialog() == DialogResult.OK)
            {
                using (FileStream stream = new FileStream(save.FileName, FileMode.Create))
                {
                    Document pdfDoc = new Document(PageSize.A4, 50f, 50f, 80f, 50f);
                    PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);
                    pdfDoc.Open();

                    // Thêm logo
                    string logoPath = @"C:\HAIDUONG\2THYEARSEMESTER2\Window\FinalProject\1_WPRFinal_PoolApp\Icons\logo.png";
                    iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(logoPath);
                    logo.SetAbsolutePosition(pdfDoc.Left + 10, pdfDoc.Top - 70);
                    logo.ScaleToFit(140f, 70f);
                    pdfDoc.Add(logo);

                    // Thêm thông tin Business
                    iTextSharp.text.Font infoFont = FontFactory.GetFont(FontFactory.HELVETICA, 12);
                    Paragraph businessInfo = new Paragraph($"Last Name: {lastName}\nEmail: {email}", FontFactory.GetFont(FontFactory.HELVETICA, 12));
                    businessInfo.SpacingBefore = 80f; // Điều chỉnh khoảng cách nếu cần
                    pdfDoc.Add(businessInfo);

                    // Thêm header và bảng cho Facilities
                    Paragraph facilitiesHeader = new Paragraph("Facility of Business:", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 14));
                    facilitiesHeader.SpacingBefore = 40f;
                    pdfDoc.Add(facilitiesHeader);
                    AddTableToPDF(pdfDoc, FacilityDataGridView, excludeColumns);

                    // Thêm header và bảng cho Tournaments
                    Paragraph tournamentsHeader = new Paragraph("Tournament of Business:", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 14));
                    tournamentsHeader.SpacingBefore = 40f;
                    pdfDoc.Add(tournamentsHeader);
                    AddTableToPDF(pdfDoc, TournamentDataGridView, excludeColumns);

                    pdfDoc.Close();
                    stream.Close();
                }
                MessageBox.Show("PDF created successfully!");
            }
        }
        private void AddTableToPDF(Document pdfDoc, DataGridView dgv, string[] excludeColumns)
        {
            PdfPTable table = new PdfPTable(dgv.Columns.Cast<DataGridViewColumn>()
                .Where(c => !excludeColumns.Contains(c.Name))
                .Count());
            table.WidthPercentage = 100; // Width of the table

            // Add headers excluding specified columns
            foreach (DataGridViewColumn column in dgv.Columns)
            {
                if (!excludeColumns.Contains(column.Name))
                {
                    PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                    cell.BackgroundColor = new BaseColor(240, 240, 240);
                    table.AddCell(cell);
                }
            }

            // Add data rows excluding specified columns
            foreach (DataGridViewRow row in dgv.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (!excludeColumns.Contains(dgv.Columns[cell.ColumnIndex].Name))
                    {
                        table.AddCell(new Phrase(cell.Value?.ToString() ?? ""));
                    }
                }
            }

            pdfDoc.Add(table);
        }


    }
}
