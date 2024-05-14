using _1_WPRFinal_PoolApp.Forms;
using _1_WPRFinal_PoolApp.userForms;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_WPRFinal_PoolApp
{
    public class TABLE
    {
        public int TableID { get; set; }
        public int FacilityID { get; set; }
        public int UID { get; set; }
        public int OID { get; set; }

        public int TableNumber { get; set; }
        public bool IsPublic { get; set; }
        public string PrivateKey { get; set; }
        public string Location { get; set; }
        public DateTime DATE { get; set; }
        public string Time { get; set; }
        public string GameType { get; set; }
        public string GameRules { get; set; }
        public int PlayerLimit { get; set; }
        public string Status { get; set; }

        public TABLE() { }

        public static Dictionary<int, Color> facilityColors = new Dictionary<int, Color>();
        public static List<TABLE> LoadTablesFromDatabase(string query)
        {
            List<TABLE> tables = new List<TABLE>();
            using (SqlConnection connection = new SqlConnection(Fn.Con()))
            {
                connection.Open();
                //                string query = "SELECT * FROM Tables";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            TABLE table = new TABLE
                            {
                                TableID = (int)reader["TableID"],
                                UID = (int)reader["UID"],
                                OID = reader.IsDBNull(reader.GetOrdinal("OID")) ? 0 : (int)reader["OID"],
                                FacilityID = (int)reader["FacilityID"],
                                TableNumber = (int)reader["TableNumber"],
                                IsPublic = (bool)reader["IsPublic"],
                                PrivateKey = reader["PrivateKey"].ToString(),
                                Location = reader["Location"].ToString(),
                                Time = reader["Time"].ToString(),
                                GameType = reader["GameType"].ToString(),
                                GameRules = reader["GameRules"].ToString(),
                                PlayerLimit = reader.IsDBNull(reader.GetOrdinal("PlayerLimit")) ? 0 : (int)reader["PlayerLimit"],
                                Status = reader["Status"].ToString()
                            };
                            // Parse Date if it is not null
                            if (!reader.IsDBNull(reader.GetOrdinal("Date")))
                            {
                                // Extract the date part and create a DateOnly instance
                                table.DATE = DateTime.Parse(reader["Date"].ToString()).Date;
                            }
                            // Parse Time if it is not null

                            tables.Add(table);
                        }
                    }
                }
            }
            return tables;
        }




        public void InsertTable()
        {
            // Connection string to your SQL Server database


            // Query to insert a new table
            string query = "INSERT INTO Tables (TableID,FacilityID, UID,OID, TableNumber, IsPublic, PrivateKey, Location, Date, Time, GameType, GameRules, PlayerLimit, Status) " +
                           "VALUES (@tableID,@FacilityID, @UID,@OID, @TableNumber, @IsPublic, @PrivateKey, @Location, @Date, @Time, @GameType, @GameRules, @PlayerLimit, @Status)";

            // Using statement ensures the connection is properly closed and disposed
            using (SqlConnection connection = new SqlConnection(Fn.Con()))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add parameters
                    command.Parameters.AddWithValue("@TableID", TableID);
                    command.Parameters.AddWithValue("@FacilityID", FacilityID);
                    command.Parameters.AddWithValue("@UID", UID);
                    command.Parameters.AddWithValue("@OID", OID);
                    command.Parameters.AddWithValue("@TableNumber", TableNumber);
                    command.Parameters.AddWithValue("@IsPublic", IsPublic);
                    command.Parameters.AddWithValue("@PrivateKey", PrivateKey);
                    command.Parameters.AddWithValue("@Location", Location);
                    command.Parameters.AddWithValue("@Date", DATE.Date);
                    command.Parameters.AddWithValue("@Time", Time);
                    command.Parameters.AddWithValue("@GameType", GameType);
                    command.Parameters.AddWithValue("@GameRules", GameRules);
                    command.Parameters.AddWithValue("@PlayerLimit", PlayerLimit);
                    command.Parameters.AddWithValue("@Status", Status);

                    // Execute the query
                    command.ExecuteNonQuery();
                }
            }
        }


        // -- Functions to help set Color by Facility
        public static void GenerateFacilityColors()
        {
            Dictionary<int, Color> facilityColors = new Dictionary<int, Color>();

            // Get unique FacilityIDs from Data.Facilities
            var uniqueFacilityIDs = Data.facilities.Select(f => f.ID).Distinct();

            // Generate colors for each unique FacilityID
            foreach (var facilityID in uniqueFacilityIDs)
            {
                // Generate a unique color based on the facilityID index
                Color color = GenerateRandomColor(facilityID);

                // Add the facilityID and color to the dictionary
                facilityColors.Add(facilityID, color);

            }
            TABLE.facilityColors = facilityColors;
            //return facilityColors;
        }
        public static Color GenerateRandomColor(int index)
        {
            // You can implement your own logic to generate unique colors based on the index
            // For simplicity, we'll generate a random color here
            Random rnd = new Random(index + 2000);
            Color color = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
            return color;
        }
        //



        // -- Load The Panel Controls
        public static void LoadTables(FlowLayoutPanel fpnlTables )
        {
            // Store the reference to the pnlAddTable panel
            Panel pnlAddTable = null;

            // Find the pnlAddTable panel and store the reference
            foreach (Control control in fpnlTables.Controls)
            {
                if (control is Panel panel && panel.Name == "pnlAddTable")
                {
                    pnlAddTable = panel;
                    break;
                }
            }
            fpnlTables.Controls.Clear();
            if (pnlAddTable != null)
            {
                fpnlTables.Controls.Add(pnlAddTable); // Re-add the pnlAddTable panel
            }
            TABLE.GenerateFacilityColors();
            // Clear existing controls in the flow panel
            //fpnlTables.Controls.Clear();

            // Iterate through the Data.TABLEs list
            foreach (var table in Data.TABLEs)
            {
                // Check if the table meets the conditions (IsPublic true and status Open)
                if (table.IsPublic && table.Status == "Open")
                {

                    // Create a panel to display table information
                    Panel tablePanel = new Panel();
                    tablePanel.BorderStyle = BorderStyle.FixedSingle;
                    tablePanel.Width = 230;
                    tablePanel.Height = 230;


                    // Apply background color or image based on FacilityID
                    if (TABLE.facilityColors.ContainsKey(table.FacilityID))
                    {
                        tablePanel.BackColor = facilityColors[table.FacilityID];
                        tablePanel.ForeColor = Color.Gold;
                    }
                    else
                    {
                        // Default background color if FacilityID not found in dictionary
                        tablePanel.BackColor = Color.RoyalBlue;
                    }

                    // Create labels to display table information
                    Label lblTableNumber = new Label();
                    lblTableNumber.Text = "Table Number: " + table.TableNumber;
                    lblTableNumber.AutoSize = true;
                    lblTableNumber.Location = new System.Drawing.Point(10, 10);
                    tablePanel.Controls.Add(lblTableNumber);


                    Label lblLocation = new Label();
                    lblLocation.Text = "Location: " + table.Location;
                    lblLocation.AutoSize = true;
                    lblLocation.Location = new System.Drawing.Point(10, 35);
                    tablePanel.Controls.Add(lblLocation);

                    // Create a button to check on the table
                    Button btnCheck = new Button();
                    btnCheck.Text = "Check Table";
                    btnCheck.AutoSize = true;
                    btnCheck.Location = new System.Drawing.Point(10, 60);

                    // Use a lambda expression to capture the TableID within the event handler
                    btnCheck.Click += (sender, e) =>
                    {
                        // Now you can use the clickedTableID for other functions
                        frmOpenTable frm = new frmOpenTable();
                        frm.LoadTable(table.TableID);
                        frm.ShowDialog();
                        TABLE.LoadTables(fpnlTables);
                        
                    };

                    // Add the button to the panel
                    tablePanel.Controls.Add(btnCheck);

                    // Add the panel to the flow panel
                    fpnlTables.Controls.Add(tablePanel);
                }
            }

        }
        //


        // -- Open Table Details
        private void OpenTableDetailsForm(int ID)
        {
            frmOpenTable frm = new frmOpenTable();
            frm.LoadTable(ID);
        }
        //

        // -- Set up a table from ID
        public void SetUpTableData(int TableID)
        {
            using (SqlConnection connection = new SqlConnection(Fn.Con()))
            {
                connection.Open();
                string query = "SELECT * FROM Tables WHERE TableID = @TableID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@TableID", TableID);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            TableID = Convert.ToInt32(reader["TableID"]);
                            FacilityID = Convert.ToInt32(reader["FacilityID"]);
                            UID = Convert.ToInt32(reader["UID"]);
                            OID = reader["OID"] == DBNull.Value ? 0 : Convert.ToInt32(reader["OID"]);
                            TableNumber = Convert.ToInt32(reader["TableNumber"]);
                            IsPublic = Convert.ToBoolean(reader["IsPublic"]);
                            PrivateKey = reader["PrivateKey"].ToString();
                            Location = reader["Location"].ToString();
                            
                            Time = reader["Time"].ToString();
                            GameType = reader["GameType"].ToString();
                            GameRules = reader["GameRules"].ToString();
                            PlayerLimit = reader.IsDBNull(reader.GetOrdinal("PlayerLimit")) ? 0 : (int)reader["PlayerLimit"];
                            Status = reader["Status"].ToString();

                            // Parse Date if it is not null
                            if (!reader.IsDBNull(reader.GetOrdinal("Date")))
                            {
                                // Extract the date part and create a DateOnly instance
                                DATE = DateTime.Parse(reader["Date"].ToString());
                            }
                        }
                    }
                }
            }
        }
        //


        // -- Update OID of table 
        public string AddOpponentIDToTable(int tableID, int opponentID)
        {
            // Construct the SQL Update query
            string query = "UPDATE Tables SET OID = @OpponentID,Status = 'Closed' WHERE TableID = @TableID";

            // Create connection and command objects
            using (SqlConnection connection = new SqlConnection(Fn.Con()))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add parameters to the command
                    command.Parameters.AddWithValue("@OpponentID", opponentID);
                    command.Parameters.AddWithValue("@TableID", tableID);

                    try
                    {
                        // Open the connection
                        connection.Open();
                        // Execute the update query
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            TABLE updatedTable = Data.TABLEs.FirstOrDefault(t => t.TableID == tableID);
                            if (updatedTable != null)
                            {
                                updatedTable.OID = opponentID;
                                updatedTable.Status = "Closed";
                            }
                                return "Opponent ID added to table successfully.";
                        }
                        else
                        {
                            return "Table with specified ID not found.";
                        }
                    }
                    catch (Exception ex)
                    {
                        return "Error adding opponent ID to table: " + ex.Message;
                    }
                }
            }
        }

    }
}
