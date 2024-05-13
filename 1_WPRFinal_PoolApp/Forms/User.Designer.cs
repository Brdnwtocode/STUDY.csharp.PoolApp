namespace _1_WPRFinal_PoolApp.Forms
{
    partial class frmUser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUser));
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lblBio = new System.Windows.Forms.Label();
            this.lblFavourite = new System.Windows.Forms.Label();
            this.lblWinrate = new System.Windows.Forms.Label();
            this.lblRank = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnRank = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnTournament = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnFind = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.pnlTourPost = new System.Windows.Forms.Panel();
            this.pnlLocation = new System.Windows.Forms.Panel();
            this.fpnlTables = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel8.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.AutoScroll = true;
            this.flowLayoutPanel2.Controls.Add(this.panel1);
            this.flowLayoutPanel2.Controls.Add(this.panel3);
            this.flowLayoutPanel2.Controls.Add(this.panel2);
            this.flowLayoutPanel2.Controls.Add(this.panel4);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(450, 544);
            this.flowLayoutPanel2.TabIndex = 4;
            this.flowLayoutPanel2.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanel2_Paint);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.RoyalBlue;
            this.panel1.Controls.Add(this.panel7);
            this.panel1.Controls.Add(this.lblFavourite);
            this.panel1.Controls.Add(this.lblWinrate);
            this.panel1.Controls.Add(this.lblRank);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(413, 291);
            this.panel1.TabIndex = 0;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.White;
            this.panel7.Controls.Add(this.pictureBox1);
            this.panel7.Controls.Add(this.lblName);
            this.panel7.Controls.Add(this.lblBio);
            this.panel7.Location = new System.Drawing.Point(15, 9);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(382, 157);
            this.panel7.TabIndex = 6;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(150, 150);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.BackColor = System.Drawing.Color.Transparent;
            this.lblName.Font = new System.Drawing.Font("VNI-Avo", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblName.ForeColor = System.Drawing.Color.Black;
            this.lblName.Location = new System.Drawing.Point(159, 24);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(75, 31);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Hello ";
            // 
            // lblBio
            // 
            this.lblBio.AutoSize = true;
            this.lblBio.BackColor = System.Drawing.Color.Transparent;
            this.lblBio.Font = new System.Drawing.Font("VNI-Avo", 8.999999F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.lblBio.ForeColor = System.Drawing.Color.Black;
            this.lblBio.Location = new System.Drawing.Point(159, 65);
            this.lblBio.Name = "lblBio";
            this.lblBio.Size = new System.Drawing.Size(76, 25);
            this.lblBio.TabIndex = 4;
            this.lblBio.Text = "Set Bio!";
            // 
            // lblFavourite
            // 
            this.lblFavourite.AutoSize = true;
            this.lblFavourite.BackColor = System.Drawing.Color.RoyalBlue;
            this.lblFavourite.Font = new System.Drawing.Font("VNI-Avo", 8.999999F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.lblFavourite.ForeColor = System.Drawing.Color.SpringGreen;
            this.lblFavourite.Location = new System.Drawing.Point(286, 202);
            this.lblFavourite.Name = "lblFavourite";
            this.lblFavourite.Size = new System.Drawing.Size(93, 27);
            this.lblFavourite.TabIndex = 5;
            this.lblFavourite.Text = "Favourite";
            // 
            // lblWinrate
            // 
            this.lblWinrate.AutoSize = true;
            this.lblWinrate.BackColor = System.Drawing.Color.RoyalBlue;
            this.lblWinrate.Font = new System.Drawing.Font("VNI-Avo", 8.999999F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.lblWinrate.ForeColor = System.Drawing.Color.SpringGreen;
            this.lblWinrate.Location = new System.Drawing.Point(147, 202);
            this.lblWinrate.Name = "lblWinrate";
            this.lblWinrate.Size = new System.Drawing.Size(83, 27);
            this.lblWinrate.TabIndex = 3;
            this.lblWinrate.Text = "WinRate";
            // 
            // lblRank
            // 
            this.lblRank.AutoSize = true;
            this.lblRank.BackColor = System.Drawing.Color.RoyalBlue;
            this.lblRank.Font = new System.Drawing.Font("VNI-Avo", 8.999999F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.lblRank.ForeColor = System.Drawing.Color.SpringGreen;
            this.lblRank.Location = new System.Drawing.Point(26, 202);
            this.lblRank.Name = "lblRank";
            this.lblRank.Size = new System.Drawing.Size(65, 27);
            this.lblRank.TabIndex = 2;
            this.lblRank.Text = "Rank ";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.RoyalBlue;
            this.panel3.Controls.Add(this.btnRank);
            this.panel3.Location = new System.Drawing.Point(3, 300);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(413, 120);
            this.panel3.TabIndex = 2;
            // 
            // btnRank
            // 
            this.btnRank.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnRank.FlatAppearance.BorderSize = 0;
            this.btnRank.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRank.Font = new System.Drawing.Font("VNI-Avo", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.btnRank.ForeColor = System.Drawing.Color.SpringGreen;
            this.btnRank.Image = ((System.Drawing.Image)(resources.GetObject("btnRank.Image")));
            this.btnRank.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRank.Location = new System.Drawing.Point(3, 6);
            this.btnRank.Name = "btnRank";
            this.btnRank.Size = new System.Drawing.Size(407, 111);
            this.btnRank.TabIndex = 0;
            this.btnRank.Text = "Career";
            this.btnRank.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.RoyalBlue;
            this.panel2.Controls.Add(this.btnTournament);
            this.panel2.Location = new System.Drawing.Point(3, 426);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(413, 120);
            this.panel2.TabIndex = 3;
            // 
            // btnTournament
            // 
            this.btnTournament.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnTournament.FlatAppearance.BorderSize = 0;
            this.btnTournament.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTournament.Font = new System.Drawing.Font("VNI-Avo", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.btnTournament.ForeColor = System.Drawing.Color.SpringGreen;
            this.btnTournament.Image = ((System.Drawing.Image)(resources.GetObject("btnTournament.Image")));
            this.btnTournament.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnTournament.Location = new System.Drawing.Point(6, 3);
            this.btnTournament.Name = "btnTournament";
            this.btnTournament.Size = new System.Drawing.Size(404, 117);
            this.btnTournament.TabIndex = 2;
            this.btnTournament.Text = "Tournament";
            this.btnTournament.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.RoyalBlue;
            this.panel4.Controls.Add(this.btnFind);
            this.panel4.Location = new System.Drawing.Point(3, 552);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(413, 120);
            this.panel4.TabIndex = 2;
            // 
            // btnFind
            // 
            this.btnFind.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnFind.FlatAppearance.BorderSize = 0;
            this.btnFind.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFind.Font = new System.Drawing.Font("VNI-Avo", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.btnFind.ForeColor = System.Drawing.Color.SpringGreen;
            this.btnFind.Image = ((System.Drawing.Image)(resources.GetObject("btnFind.Image")));
            this.btnFind.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFind.Location = new System.Drawing.Point(3, 3);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(407, 114);
            this.btnFind.TabIndex = 0;
            this.btnFind.Text = "Find";
            this.btnFind.UseVisualStyleBackColor = true;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.panel6);
            this.panel5.Controls.Add(this.flowLayoutPanel2);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1178, 544);
            this.panel5.TabIndex = 5;
            // 
            // panel6
            // 
            this.panel6.AutoScroll = true;
            this.panel6.Controls.Add(this.panel8);
            this.panel6.Controls.Add(this.fpnlTables);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(450, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(728, 544);
            this.panel6.TabIndex = 5;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.pnlTourPost);
            this.panel8.Controls.Add(this.pnlLocation);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel8.Location = new System.Drawing.Point(0, 213);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(728, 331);
            this.panel8.TabIndex = 1;
            // 
            // pnlTourPost
            // 
            this.pnlTourPost.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTourPost.Location = new System.Drawing.Point(356, 0);
            this.pnlTourPost.Name = "pnlTourPost";
            this.pnlTourPost.Size = new System.Drawing.Size(372, 331);
            this.pnlTourPost.TabIndex = 1;
            // 
            // pnlLocation
            // 
            this.pnlLocation.AutoScroll = true;
            this.pnlLocation.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLocation.Location = new System.Drawing.Point(0, 0);
            this.pnlLocation.Name = "pnlLocation";
            this.pnlLocation.Size = new System.Drawing.Size(356, 331);
            this.pnlLocation.TabIndex = 0;
            // 
            // fpnlTables
            // 
            this.fpnlTables.Dock = System.Windows.Forms.DockStyle.Top;
            this.fpnlTables.Location = new System.Drawing.Point(0, 0);
            this.fpnlTables.Name = "fpnlTables";
            this.fpnlTables.Size = new System.Drawing.Size(728, 213);
            this.fpnlTables.TabIndex = 0;
            // 
            // frmUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1178, 544);
            this.Controls.Add(this.panel5);
            this.Font = new System.Drawing.Font("VNI-Avo", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.MinimumSize = new System.Drawing.Size(1200, 600);
            this.Name = "frmUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "User";
            this.flowLayoutPanel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private FlowLayoutPanel flowLayoutPanel2;
        private Panel panel1;
        private Label lblFavourite;
        private Label lblWinrate;
        private Label lblRank;
        private Label lblName;
        private PictureBox pictureBox1;
        private Panel panel3;
        private Button btnRank;
        private Panel panel2;
        private Button btnTournament;
        private Panel panel4;
        private Button btnFind;
        private Panel panel5;
        private Panel panel6;
        private Panel panel7;
        private FlowLayoutPanel fpnlTables;
        private Panel panel8;
        private Panel pnlTourPost;
        private Panel pnlLocation;
        private Label lblBio;
    }
}