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

namespace _1_WPRFinal_PoolApp.Authentication
{
    public partial class frmRegister : Form
    {
        public frmRegister()
        {
            InitializeComponent();
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        CONNECT Con = new CONNECT();
        string type;
        int ID;

        // --- Functions 
        public int GenerateUniqueRandomID()
        {
            int randomID;
            bool isUnique = false;
            Random rand = new Random();

            // Loop until a unique ID is generated
            while (!isUnique)
            {
                randomID = rand.Next(100000000, 1000000000); // Generate a random 9-digit integer ID

                // Check if the generated ID is unique in the database
                if (IsIDUniqueInDatabase(randomID))
                {
                    isUnique = true;
                    return randomID;
                }
            }

            return -1; // Return -1 if unable to generate a unique ID (this should ideally not happen)
        }

        // Function to check if a given ID is unique in the database
        private bool IsIDUniqueInDatabase(int id)
        {
            using (SqlConnection connection = new SqlConnection(Con.String))
            {
                connection.Open();

                // SQL query to check if the ID exists in the Accounts table
                string query = "SELECT COUNT(*) FROM Accounts WHERE ID = @ID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID", id);
                    int count = (int)command.ExecuteScalar();

                    // If count is 0, ID is unique, otherwise it's not unique
                    return count == 0;
                }
            }
        }

        public void InsertAccount(string email, string password, string type)
        {
           

            // Generate unique random ID
            int randomID = GenerateUniqueRandomID();
            

            // Insert into Accounts table
            using (SqlConnection connection = new SqlConnection(Con.String))
            {
                connection.Open();

                // SQL query to insert into Accounts table
                string query = "INSERT INTO Accounts (Email, Password, ID, Status,Type) VALUES (@Email, @Password, @ID,@Status, @Type)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Password", password);
                    command.Parameters.AddWithValue("@ID", randomID);
                    command.Parameters.AddWithValue("@Status", "Pending");
                    command.Parameters.AddWithValue("@Type", type);
                    command.ExecuteNonQuery();
                }
            }
            ID = randomID;

            MessageBox.Show("Sign Up completed!");
        }




        // --- Controls 
        

        // --- Accounts
        private void btnSignUp_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            // Validate email format
            if (!Fn.IsValidEmail(email))
            {
                MessageBox.Show("Invalid email format.");
                return;
            }
            string pass = Fn.encrypt(txtPass.Text);
            type = "User";
            InsertAccount(email, pass, type);
            pnlInfo.Visible = true;
            pnlPicture.Visible = true;
        }

        private void lblBusiness_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string email = txtEmail.Text;
            string pass = txtPass.Text;
            type = "Business";
            InsertAccount(email, pass, type);
        }
        // ---


        // --- Image
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
        //


        // --- Form Load 
        private void frmRegister_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
        }
        //


        // --- Register 
        private void btnRegister_Click(object sender, EventArgs e)
        {
            string firstName = txtFirstName.Text;
            string lastName = txtLastName.Text;
            string gender = cbGender.SelectedItem.ToString();
            DateTime dob = dateTimePicker1.Value.Date;
            string phone = txtPhone.Text;
            string email = txtEmail.Text;
            int userID = ID; // Assuming txtID contains the user ID obtained from sign up

            var Result = Fn.ValidateInput(firstName, lastName, gender, dob, phone);
            if (!Result.isValid) return;
            
            // Convert PictureBox image to byte array
            byte[] picture = null;
            if (pictureBox1.Image != null)
            {
                picture = Fn.ImageToByteArray(pictureBox1.Image);
            }

            // Insert into respective table based on type
            if (type == "User")
            {
                USER user = new USER();
                user.InsertUser(firstName, lastName, gender, dob, phone, email, userID, picture);
            }
            else if (type == "Business")
            {
                BUSINESS bUSINESS = new BUSINESS();

                bUSINESS.InsertBusiness(firstName, lastName, gender, dob, phone, email, userID, picture);
            }

            MessageBox.Show(Result.errorMessage + "Register Completed!");
        }
    }
}
