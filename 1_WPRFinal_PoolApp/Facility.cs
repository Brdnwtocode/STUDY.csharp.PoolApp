﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_WPRFinal_PoolApp
{
    public class Facility
    {

        public int ID { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Capacity { get; set; }
        public string Description { get; set; }
        public Image image { get; set; }

        public Facility() { }

        public static List<Facility> LoadFacilitiesFromDatabase()
        {
            List<Facility> facilities = new List<Facility>();
            using (SqlConnection connection = new SqlConnection(Fn.Con()))
            {
                connection.Open();
                string query = "SELECT * FROM Facility";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Facility facility = new Facility
                            {
                                ID = (int)reader["FacilityID"],
                                Name = reader["FacilityName"].ToString(),
                                Location = reader["Location"].ToString(),
                                Capacity = reader["Capacity"].ToString(),
                                Description = reader["Description"].ToString(),
                            };

                            // Retrieve and convert image if stored as byte array in the database
                            if (!reader.IsDBNull(reader.GetOrdinal("Image")))
                            {
                                byte[] pictureBytes = (byte[])reader["Image"];
                                using (MemoryStream ms = new MemoryStream(pictureBytes))
                                {
                                    facility.image = Image.FromStream(ms);
                                }
                            }
                            else
                            {
                                facility.image = null;
                            }

                            facilities.Add(facility);
                        }
                    }
                }
            }
            return facilities;
        }


        public static string GetFacilityNameFromID(int facilityID)
        {
            Facility facility = Data.facilities.FirstOrDefault(f => f.ID == facilityID);
            return facility != null ? facility.Name : null;
        }

        // -- Load Facility into panel
        public static void GenerateFacilityPanels(FlowLayoutPanel fpnlLocation)
        {
            // Clear existing panels from the flow panel
            fpnlLocation.Controls.Clear();

            // Width of the flow panel
            int panelWidth = 330;

            // Iterate over each facility in Data.facilities
            foreach (Facility facility in Data.facilities)
            {
                Panel facilityPanel = new Panel();
                if (TABLE.facilityColors.ContainsKey(facility.ID))
                {
                    facilityPanel.BackColor = TABLE.facilityColors[facility.ID];
                    facilityPanel.ForeColor = Color.Gold;
                }
                else
                {
                    // Default background color if FacilityID not found in dictionary
                    facilityPanel.BackColor = Color.RoyalBlue;
                    facilityPanel.ForeColor = Color.Gold;
                }

                // Create a new panel for the facility
                
                //facilityPanel.BackColor = Color.LightGray;
                facilityPanel.BorderStyle = BorderStyle.FixedSingle;
                facilityPanel.Padding = new Padding(10);
                facilityPanel.Width = panelWidth;
                facilityPanel.AutoSize = true;

                // Add PictureBox for facility image
                PictureBox pictureBox = new PictureBox();
                pictureBox.Image = facility.image;
                pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox.Size = new Size(100, 100); // Adjust size as needed
                pictureBox.Location = new Point(10, 10);
                facilityPanel.Controls.Add(pictureBox);

                // Add RichTextBox for facility name
                RichTextBox nameBox = new RichTextBox();
                nameBox.Text = "Name: " + facility.Name;
                nameBox.ReadOnly = true;
                nameBox.WordWrap = true;
                nameBox.BorderStyle = BorderStyle.None;
                nameBox.BackColor = facilityPanel.BackColor; // Match panel background color
                nameBox.Size = new Size(panelWidth - 20, 50); // Adjust size as needed
                nameBox.Location = new Point(10, pictureBox.Bottom + 10);
                facilityPanel.Controls.Add(nameBox);

                // Add RichTextBox for facility location
                RichTextBox locationBox = new RichTextBox();
                locationBox.Text = "Location: " + facility.Location;
                locationBox.ReadOnly = true;
                locationBox.WordWrap = true;
                locationBox.BorderStyle = BorderStyle.None;
                locationBox.BackColor = facilityPanel.BackColor; // Match panel background color
                locationBox.Size = new Size(panelWidth - 20, 50); // Adjust size as needed
                locationBox.Location = new Point(10, nameBox.Bottom + 10);
                facilityPanel.Controls.Add(locationBox);

                // Add RichTextBox for capacity
                RichTextBox capacityBox = new RichTextBox();
                capacityBox.Text = "Capacity: " + facility.Capacity;
                capacityBox.ReadOnly = true;
                capacityBox.WordWrap = true;
                capacityBox.BorderStyle = BorderStyle.None;
                capacityBox.BackColor = facilityPanel.BackColor; // Match panel background color
                capacityBox.Size = new Size(panelWidth - 20, 50); // Adjust size as needed
                capacityBox.Location = new Point(10, locationBox.Bottom + 10);
                facilityPanel.Controls.Add(capacityBox);

                // Add RichTextBox for description
                RichTextBox descriptionBox = new RichTextBox();
                descriptionBox.Text = "Description: " + facility.Description;
                descriptionBox.ReadOnly = true;
                descriptionBox.WordWrap = true;
                descriptionBox.BorderStyle = BorderStyle.None;
                descriptionBox.BackColor = facilityPanel.BackColor; // Match panel background color
                descriptionBox.Size = new Size(panelWidth - 20, 100); // Adjust size as needed
                descriptionBox.Location = new Point(10, capacityBox.Bottom + 10);
                facilityPanel.Controls.Add(descriptionBox);

                // Add the facility panel to the flow panel
                fpnlLocation.Controls.Add(facilityPanel);
            }
        }

    }


}
