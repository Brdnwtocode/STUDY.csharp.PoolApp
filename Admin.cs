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
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;


namespace _1_WPRFinal_PoolApp.Forms
{
    public partial class frmAdmin : Form
    {
        private string connectionString = @"Data Source=NERVOUS;Initial Catalog=Pool;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public frmAdmin()
        {
            InitializeComponent();
            LoadPendingAccounts();
            LoadActiveAccounts();
            LoadUsers();
            LoadBusinessData();
            BusinessDataGridView.CellDoubleClick += BusinessDataGridView_CellDoubleClick;
            LoadMatchResults();
        }
        //Account Tab
        private void LoadPendingAccounts()
        {
            string query = "SELECT Email, ID, Status, Type FROM dbo.Accounts WHERE Status = 'Pending'";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                // Lọc DataTable để loại bỏ tài khoản 'ADMIN'
                var filteredData = dt.AsEnumerable()
                                     .Where(row => row.Field<string>("Type") != "ADMIN")
                                     .CopyToDataTable();

                WaitApproveDataGridView.DataSource = filteredData;
            }
        }
        private void LoadActiveAccounts()
        {
            string query = "SELECT Email, ID, Status, Type FROM dbo.Accounts WHERE Status = 'Valid' AND Type <> 'ADMIN'";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                ActiveDataGridView.DataSource = dt;
            }
        }
        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void WaitApproveDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ActiveDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void UpdateAccountStatus(string email, string status)
        {
            string query = "UPDATE dbo.Accounts SET Status = @status WHERE Email = @email";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@status", status);
                cmd.Parameters.AddWithValue("@email", email);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }
        private void ApproveButton_Click(object sender, EventArgs e)
        {
            if (WaitApproveDataGridView.CurrentRow != null)
            {
                string email = WaitApproveDataGridView.CurrentRow.Cells["Email"].Value.ToString();
                UpdateAccountStatus(email, "Valid");
                LoadPendingAccounts();
                LoadActiveAccounts();
            }
        }
        private void DeleteAccount(string email)
        {
            string query = "DELETE FROM dbo.Accounts WHERE Email = @email";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@email", email);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }
        private void DeclineButton_Click(object sender, EventArgs e)
        {
            if (WaitApproveDataGridView.CurrentRow != null)
            {
                string email = WaitApproveDataGridView.CurrentRow.Cells["Email"].Value.ToString();
                DeleteAccount(email);
                LoadPendingAccounts();
            }

        }
        //Users Tab
        private void PrintToPdf()
        {
            if (UsersDataGridView.Rows.Count == 0)
            {
                MessageBox.Show("No data to print.");
                return;
            }

            SaveFileDialog save = new SaveFileDialog();
            save.FileName = "File.pdf";
            save.Filter = "PDF Files (*.pdf)|*.pdf|All files (*.*)|*.*";
            if (save.ShowDialog() == DialogResult.OK)
            {
                using (FileStream stream = new FileStream(save.FileName, FileMode.Create))
                {
                    Document pdfDoc = new Document(PageSize.A4, 50f, 50f, 80f, 50f); // Cập nhật lề để có chỗ cho header và logo
                    PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);
                    pdfDoc.Open();

                    // Thêm logo
                    string logoPath = @"C:\HAIDUONG\2THYEARSEMESTER2\Window\FinalProject\1_WPRFinal_PoolApp\Icons\logo.png";
                    iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(logoPath);
                    logo.SetAbsolutePosition(pdfDoc.Left + 10, pdfDoc.Top - 60); // Đặt vị trí tuyệt đối của logo
                    logo.ScaleAbsoluteWidth(100f); // Điều chỉnh chiều rộng
                    logo.ScaleAbsoluteHeight(50f); // Điều chỉnh chiều cao
                    pdfDoc.Add(logo);

                    // Thêm header text
                    iTextSharp.text.Font headerFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16);
                    Paragraph header = new Paragraph("List of Billiard App Players", headerFont);
                    header.Alignment = Element.ALIGN_CENTER;
                    header.SpacingBefore = 70f; // Cách khoảng trước header
                    pdfDoc.Add(header);

                    // Xác định chỉ số cột của 'DOB' và 'Picture'
                    int dobColumnIndex = UsersDataGridView.Columns["DOB"].Index;
                    int pictureColumnIndex = UsersDataGridView.Columns["Picture"].Index;

                    // Tạo bảng mà loại bỏ hai cột
                    PdfPTable table = new PdfPTable(UsersDataGridView.Columns.Count - 2); // Loại bỏ 2 cột
                    table.WidthPercentage = 100;
                    table.SpacingBefore = 30f; // Cách khoảng trước bảng

                    // Add headers
                    foreach (DataGridViewColumn column in UsersDataGridView.Columns)
                    {
                        if (column.Index != dobColumnIndex && column.Index != pictureColumnIndex) // Kiểm tra không phải cột 'DOB' và 'Picture'
                        {
                            PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                            cell.HorizontalAlignment = Element.ALIGN_CENTER;
                            cell.BackgroundColor = new BaseColor(240, 240, 240); // Màu nền cho header
                            table.AddCell(cell);
                        }
                    }

                    // Add data rows
                    foreach (DataGridViewRow row in UsersDataGridView.Rows)
                    {
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            if (cell.ColumnIndex != dobColumnIndex && cell.ColumnIndex != pictureColumnIndex) // Kiểm tra không phải cột 'DOB' và 'Picture'
                            {
                                string cellValue = cell.Value == null ? "" : cell.Value.ToString();
                                PdfPCell pdfCell = new PdfPCell(new Phrase(cellValue));
                                pdfCell.HorizontalAlignment = Element.ALIGN_LEFT;
                                table.AddCell(pdfCell);
                            }
                        }
                    }

                    pdfDoc.Add(table);
                    pdfDoc.Close();
                    stream.Close();
                }

                MessageBox.Show("PDF created successfully!");
            }
        }
        private void LoadUsers()
        {
            string query = "SELECT * FROM dbo.Users";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                UsersDataGridView.DataSource = dt;
            }
        }
        private void UsersDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void PrintToPdfButton_Click(object sender, EventArgs e)
        {
            PrintToPdf();
        }
        //FacOwner Tab
        private void BusinessDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void LoadBusinessData()
        {
            string query = "SELECT * FROM dbo.Business"; // Giả sử các cột này tồn tại
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                BusinessDataGridView.DataSource = dt;
            }
        }
        private void PrintToPdfBusiness()
        {
            if (BusinessDataGridView.Rows.Count == 0)
            {
                MessageBox.Show("No data to print.");
                return;
            }

            SaveFileDialog save = new SaveFileDialog();
            save.FileName = "BusinessData.pdf";
            save.Filter = "PDF Files (*.pdf)|*.pdf|All files (*.*)|*.*";
            if (save.ShowDialog() == DialogResult.OK)
            {
                using (FileStream stream = new FileStream(save.FileName, FileMode.Create))
                {
                    Document pdfDoc = new Document(PageSize.A4, 50f, 50f, 80f, 50f);
                    PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);
                    pdfDoc.Open();

                    // Add logo
                    string logoPath = @"C:\HAIDUONG\2THYEARSEMESTER2\Window\FinalProject\1_WPRFinal_PoolApp\Icons\logo.png";
                    iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(logoPath);
                    logo.SetAbsolutePosition(pdfDoc.Left + 10, pdfDoc.Top - 60);
                    logo.ScaleAbsoluteWidth(100f);
                    logo.ScaleAbsoluteHeight(50f);
                    pdfDoc.Add(logo);

                    // Add header text
                    iTextSharp.text.Font headerFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16);
                    Paragraph header = new Paragraph("List of Business", headerFont);
                    header.Alignment = Element.ALIGN_CENTER;
                    header.SpacingBefore = 70f;
                    pdfDoc.Add(header);

                    // Determine indices to exclude
                    int dobColumnIndex = BusinessDataGridView.Columns["DOB"]?.Index ?? -1;
                    int pictureColumnIndex = BusinessDataGridView.Columns["Picture"]?.Index ?? -1;

                    // Create a table excluding the DOB and Picture columns
                    PdfPTable table = new PdfPTable(BusinessDataGridView.Columns.Count - (dobColumnIndex != -1 ? 1 : 0) - (pictureColumnIndex != -1 ? 1 : 0));
                    table.WidthPercentage = 100;
                    table.SpacingBefore = 30f;

                    // Add headers excluding specified columns
                    foreach (DataGridViewColumn column in BusinessDataGridView.Columns)
                    {
                        if (column.Index != dobColumnIndex && column.Index != pictureColumnIndex)
                        {
                            PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                            cell.HorizontalAlignment = Element.ALIGN_CENTER;
                            cell.BackgroundColor = new BaseColor(240, 240, 240);
                            table.AddCell(cell);
                        }
                    }

                    // Add data rows excluding specified columns
                    foreach (DataGridViewRow row in BusinessDataGridView.Rows)
                    {
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            if (cell.ColumnIndex != dobColumnIndex && cell.ColumnIndex != pictureColumnIndex)
                            {
                                string cellValue = cell.Value == null ? "" : cell.Value.ToString();
                                PdfPCell pdfCell = new PdfPCell(new Phrase(cellValue));
                                pdfCell.HorizontalAlignment = Element.ALIGN_LEFT;
                                table.AddCell(pdfCell);
                            }
                        }
                    }

                    pdfDoc.Add(table);
                    pdfDoc.Close();
                    stream.Close();
                }

                MessageBox.Show("PDF created successfully!");
            }
        }

        private void PrintToPdf2Button_Click(object sender, EventArgs e)
        {
            PrintToPdfBusiness();
        }
        private void ShowBusinessDetails(string businessID)
        {
            frmBusinessDetails detailsForm = new frmBusinessDetails(businessID);
            detailsForm.ShowDialog();
        }

        private void BusinessDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Lấy ID của Business từ cột thích hợp, giả sử cột ID là cột đầu tiên
                string businessID = BusinessDataGridView.Rows[e.RowIndex].Cells["ID"].Value.ToString();

                // Gọi hàm hiển thị form chi tiết
                ShowBusinessDetails(businessID);
            }
        }
        //Match Resutl tab
        private void LoadMatchResults()
        {
            string query = "SELECT * FROM dbo.MatchResults";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                MatchResultDataGridView.DataSource = dt;
            }
        }
        private void PrintMatchResults()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileName = "MatchResults.pdf";
            saveFileDialog.Filter = "PDF Files (*.pdf)|*.pdf|All files (*.*)|*.*";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (FileStream stream = new FileStream(saveFileDialog.FileName, FileMode.Create))
                {
                    // Create a new PDF document
                    Document document = new Document(PageSize.A4, 50, 50, 25, 25);
                    PdfWriter writer = PdfWriter.GetInstance(document, stream);
                    document.Open();

                    // Add logo
                    string logoPath = @"C:\HAIDUONG\2THYEARSEMESTER2\Window\FinalProject\1_WPRFinal_PoolApp\Icons\logo.png";
                    iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(logoPath);
                    logo.SetAbsolutePosition(document.Left, document.Top - 70); // Adjust position as needed
                    logo.ScaleToFit(100, 100); // Correct method to set both width and height
                    document.Add(logo);

                    // Add header text
                    iTextSharp.text.Font headerFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16);
                    Paragraph header = new Paragraph("Match Results of players in app:", headerFont);
                    header.Alignment = Element.ALIGN_CENTER;
                    header.SpacingBefore = 50; // Spacing from logo
                    document.Add(header);

                    // Introduce some vertical space before the table
                    document.Add(new Paragraph("\n\n")); // Adding empty paragraphs for spacing

                    // Add a table with the appropriate column count
                    PdfPTable table = new PdfPTable(MatchResultDataGridView.ColumnCount);
                    table.WidthPercentage = 100; // Full width
                    table.SpacingBefore = 20; // Add more spacing here if needed

                    // Adding headers
                    foreach (DataGridViewColumn column in MatchResultDataGridView.Columns)
                    {
                        PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                        cell.BackgroundColor = new BaseColor(240, 240, 240); // Light grey background
                        table.AddCell(cell);
                    }

                    // Adding data rows
                    foreach (DataGridViewRow row in MatchResultDataGridView.Rows)
                    {
                        if (!row.IsNewRow) // Avoid adding the new row in DataGridView
                        {
                            foreach (DataGridViewCell cell in row.Cells)
                            {
                                table.AddCell(new Phrase(cell.Value?.ToString() ?? ""));
                            }
                        }
                    }

                    document.Add(table);
                    document.Close();
                    stream.Close();
                }

                MessageBox.Show("PDF created successfully!");
            }
        }

        private void PrintResultButton_Click(object sender, EventArgs e)
        {
            PrintMatchResults();
        }
        private void DeleteAccountCompletely(string email)
        {
            // Xóa khỏi bảng dbo.Accounts
            string deleteAccountsQuery = "DELETE FROM dbo.Accounts WHERE Email = @email";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(deleteAccountsQuery, conn);
                cmd.Parameters.AddWithValue("@email", email);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }

            // Xóa khỏi bảng dbo.Users
            string deleteUsersQuery = "DELETE FROM dbo.Users WHERE Email = @email";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(deleteUsersQuery, conn);
                cmd.Parameters.AddWithValue("@email", email);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }

            // Xóa khỏi bảng dbo.Business
            string deleteBusinessQuery = "DELETE FROM dbo.Business WHERE Email = @email";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(deleteBusinessQuery, conn);
                cmd.Parameters.AddWithValue("@email", email);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }
        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (ActiveDataGridView.CurrentRow != null)
            {
                string email = ActiveDataGridView.CurrentRow.Cells["Email"].Value.ToString();
                DeleteAccountCompletely(email);
                LoadActiveAccounts();
            }

        }
    }
}
