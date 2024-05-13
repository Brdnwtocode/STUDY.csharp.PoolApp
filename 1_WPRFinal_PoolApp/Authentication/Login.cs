using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.VisualBasic.ApplicationServices;
using _1_WPRFinal_PoolApp.Forms;

namespace _1_WPRFinal_PoolApp.Authentication
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }
        CONNECT Con = new CONNECT();
        bool saveinfo = false;
        int AccID;

        // --- functions in controls
        private void loadInfo()
        { 
            saveinfo = false;
            txtUsername.Text = Properties.Settings.Default.Email;
            txtPass.Text = Properties.Settings.Default.Password;
            if (Properties.Settings.Default.Email != "")
            {
                ckbSaveLogin.Checked = true;
            }
        }

        // --- Login fucntions
        bool verif()
        {
            if (txtUsername.Text == "" || txtUsername.Text.Length > 30)
            {
                MessageBox.Show("Invalid username ", "Error");
                return false;
            }
            if (txtPass.Text == "" || txtPass.Text.Length > 30)
            {
                MessageBox.Show("Invalid password", "Error");
                return false;
            }
            return true;
        }
       
        private LoginResult CheckLogin(string userName, string password)
        {
            LoginResult result = new LoginResult();

            try
            {
                using (SqlConnection connection = new SqlConnection(Con.String))
                {
                    connection.Open();

                    // SQL query to check login credentials and retrieve role and status
                    string query = "SELECT Type, Status,ID FROM Accounts WHERE Email = @UserName AND Password = @Password";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserName", userName);
                        command.Parameters.AddWithValue("@Password", password);

                        // Execute the query and read the result
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Get the role and status
                                string role = reader["Type"].ToString();
                                string status = Convert.ToString(reader["Status"]);

                                if (status == "Pending" || status == "Valid")
                                {
                                    // Account is active; login successful
                                    result.IsSuccessful = true;
                                    result.Role = role;
                                    result.Message = "Login successful";
                                    AccID = int.Parse(Convert.ToString(reader["ID"]));
                                }
                                else
                                {
                                    // Account is inactive; set an appropriate message
                                    result.IsSuccessful = false;
                                    result.Message = $"This account is inactive. \n {role}";
                                }
                            }
                            else
                            {
                                // No matching account found
                                result.IsSuccessful = false;
                                result.Message = "Invalid username or password.";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.IsSuccessful = false;
                result.Message = "Error: " + ex.Message;
            }

            return result;
        } 

        void ExecuteLogin()
        {
            if (!verif())
            {
                return;
            }

            string username = txtUsername.Text;
            string password = Fn.encrypt(txtPass.Text);

            // Using the modified CheckLogin to get a LoginResult object
            LoginResult loginResult = CheckLogin(username, password);

            if (loginResult.IsSuccessful)
            {
                // Save login details if checkbox is checked
                if (ckbSaveLogin.Checked == true)
                {
                    Properties.Settings.Default.Email = txtUsername.Text;
                    Properties.Settings.Default.Password = txtPass.Text;
                    Properties.Settings.Default.Save();
                }
                else
                {
                    Properties.Settings.Default.Reset();
                }

                // Open the corresponding form based on the role
                if (loginResult.Role == "User")
                {
                    frmUser frmUser = new frmUser();
                    frmUser.SetUserData(AccID);
                    this.Hide();
                    //user.Admin();
                    frmUser.ShowDialog();
                    
                }
                else if (loginResult.Role == "ADMIN")
                {
                    frmAdmin mainForm = new frmAdmin();
                    this.Hide();
                    mainForm.ShowDialog();
                    
                }
                else 
                {
                    // Set the HR ID in the static 
                    //HRsession.SetHRId(int.Parse(loginResult.Role));
                    frmBusiness hrForm = new frmBusiness();
                    this.Hide();
                    hrForm.ShowDialog();
                }

                this.Show();
            }
            else
            {
                // Display the message returned from CheckLogin
                lblRes.Text = loginResult.Message;
            }
        }
        
        // --- See Password
        void SeePassword()
        {
            // Check if PasswordChar is currently '*'
            if (txtPass.PasswordChar == '*')
            {
                // If so, make password characters visible
                txtPass.PasswordChar = '\0'; // Setting PasswordChar to '\0' makes characters visible
            }
            else
            {
                // Otherwise, hide password characters
                txtPass.PasswordChar = '*';
            }
        }


        // --- controls in forms
        private void btnLogin_Click(object sender, EventArgs e)
        {
            ExecuteLogin();
        }
        
        private void frmLogin_Load(object sender, EventArgs e)
        {
            loadInfo();
        }

        private void btnSee_Click(object sender, EventArgs e)
        {
            SeePassword();
        }

        private void btnRegis_Click(object sender, EventArgs e)
        {
            frmRegister frmRegister = new frmRegister();
            this.Hide();
            frmRegister.ShowDialog();
            this.Show();
        }
    }
}
