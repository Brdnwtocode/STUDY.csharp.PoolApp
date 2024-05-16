namespace _1_WPRFinal_PoolApp
{
    partial class frmBusinessDetails
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            FacilityDataGridView = new DataGridView();
            TournamentDataGridView = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            PrintBusinessButton = new Button();
            lblLastName = new Label();
            lblEmail = new Label();
            ((System.ComponentModel.ISupportInitialize)FacilityDataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)TournamentDataGridView).BeginInit();
            SuspendLayout();
            // 
            // FacilityDataGridView
            // 
            FacilityDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            FacilityDataGridView.Location = new Point(12, 50);
            FacilityDataGridView.Name = "FacilityDataGridView";
            FacilityDataGridView.RowTemplate.Height = 25;
            FacilityDataGridView.Size = new Size(875, 236);
            FacilityDataGridView.TabIndex = 0;
            // 
            // TournamentDataGridView
            // 
            TournamentDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            TournamentDataGridView.Location = new Point(12, 321);
            TournamentDataGridView.Name = "TournamentDataGridView";
            TournamentDataGridView.RowTemplate.Height = 25;
            TournamentDataGridView.Size = new Size(875, 236);
            TournamentDataGridView.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(377, 16);
            label1.Name = "label1";
            label1.Size = new Size(45, 15);
            label1.TabIndex = 2;
            label1.Text = "Facility";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(389, 303);
            label2.Name = "label2";
            label2.Size = new Size(75, 15);
            label2.TabIndex = 3;
            label2.Text = "Tournament";
            // 
            // PrintBusinessButton
            // 
            PrintBusinessButton.Location = new Point(743, 578);
            PrintBusinessButton.Name = "PrintBusinessButton";
            PrintBusinessButton.Size = new Size(75, 23);
            PrintBusinessButton.TabIndex = 4;
            PrintBusinessButton.Text = "Print";
            PrintBusinessButton.UseVisualStyleBackColor = true;
            PrintBusinessButton.Click += PrintBusinessButton_Click;
            // 
            // lblLastName
            // 
            lblLastName.AutoSize = true;
            lblLastName.Location = new Point(37, 9);
            lblLastName.Name = "lblLastName";
            lblLastName.Size = new Size(38, 15);
            lblLastName.TabIndex = 5;
            lblLastName.Text = "label3";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(37, 32);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(38, 15);
            lblEmail.TabIndex = 6;
            lblEmail.Text = "label3";
            // 
            // frmBusinessDetails
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(899, 613);
            Controls.Add(lblEmail);
            Controls.Add(lblLastName);
            Controls.Add(PrintBusinessButton);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(TournamentDataGridView);
            Controls.Add(FacilityDataGridView);
            Name = "frmBusinessDetails";
            Text = "frmBusinessDetails";
            ((System.ComponentModel.ISupportInitialize)FacilityDataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)TournamentDataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView FacilityDataGridView;
        private DataGridView TournamentDataGridView;
        private Label label1;
        private Label label2;
        private Button PrintBusinessButton;
        private Label lblLastName;
        private Label lblEmail;
    }
}