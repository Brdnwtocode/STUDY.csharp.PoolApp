namespace _1_WPRFinal_PoolApp.Forms
{
    partial class frmBusiness
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvFull = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.dgvFacility = new System.Windows.Forms.DataGridView();
            this.btnAllEmployee = new System.Windows.Forms.Button();
            this.btnAllFacility = new System.Windows.Forms.Button();
            this.btnAllTournament = new System.Windows.Forms.Button();
            this.dgvTournament = new System.Windows.Forms.DataGridView();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.dgvEmployee = new System.Windows.Forms.DataGridView();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFull)).BeginInit();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFacility)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTournament)).BeginInit();
            this.flowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployee)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Controls.Add(this.panel3);
            this.flowLayoutPanel1.Controls.Add(this.panel4);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1321, 222);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.flowLayoutPanel2);
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 222);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(635, 376);
            this.panel1.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.Controls.Add(this.dgvFull);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(635, 222);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(686, 376);
            this.panel2.TabIndex = 3;
            // 
            // dgvFull
            // 
            this.dgvFull.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFull.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvFull.Location = new System.Drawing.Point(0, 0);
            this.dgvFull.Name = "dgvFull";
            this.dgvFull.RowHeadersWidth = 62;
            this.dgvFull.RowTemplate.Height = 33;
            this.dgvFull.Size = new System.Drawing.Size(686, 376);
            this.dgvFull.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(632, 213);
            this.panel3.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.Location = new System.Drawing.Point(641, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(663, 213);
            this.panel4.TabIndex = 1;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.btnAllTournament);
            this.panel5.Controls.Add(this.btnAllFacility);
            this.panel5.Controls.Add(this.btnAllEmployee);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(635, 90);
            this.panel5.TabIndex = 1;
            // 
            // dgvFacility
            // 
            this.dgvFacility.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFacility.Location = new System.Drawing.Point(3, 259);
            this.dgvFacility.Name = "dgvFacility";
            this.dgvFacility.RowHeadersWidth = 62;
            this.dgvFacility.RowTemplate.Height = 33;
            this.dgvFacility.Size = new System.Drawing.Size(596, 250);
            this.dgvFacility.TabIndex = 0;
            // 
            // btnAllEmployee
            // 
            this.btnAllEmployee.Location = new System.Drawing.Point(31, 22);
            this.btnAllEmployee.Name = "btnAllEmployee";
            this.btnAllEmployee.Size = new System.Drawing.Size(154, 51);
            this.btnAllEmployee.TabIndex = 0;
            this.btnAllEmployee.Text = "Employees";
            this.btnAllEmployee.UseVisualStyleBackColor = true;
            // 
            // btnAllFacility
            // 
            this.btnAllFacility.Location = new System.Drawing.Point(238, 22);
            this.btnAllFacility.Name = "btnAllFacility";
            this.btnAllFacility.Size = new System.Drawing.Size(154, 51);
            this.btnAllFacility.TabIndex = 1;
            this.btnAllFacility.Text = "Facility";
            this.btnAllFacility.UseVisualStyleBackColor = true;
            // 
            // btnAllTournament
            // 
            this.btnAllTournament.Location = new System.Drawing.Point(445, 22);
            this.btnAllTournament.Name = "btnAllTournament";
            this.btnAllTournament.Size = new System.Drawing.Size(154, 51);
            this.btnAllTournament.TabIndex = 2;
            this.btnAllTournament.Text = "Tournament";
            this.btnAllTournament.UseVisualStyleBackColor = true;
            // 
            // dgvTournament
            // 
            this.dgvTournament.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTournament.Location = new System.Drawing.Point(3, 515);
            this.dgvTournament.Name = "dgvTournament";
            this.dgvTournament.RowHeadersWidth = 62;
            this.dgvTournament.RowTemplate.Height = 33;
            this.dgvTournament.Size = new System.Drawing.Size(596, 250);
            this.dgvTournament.TabIndex = 1;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.AutoScroll = true;
            this.flowLayoutPanel2.Controls.Add(this.dgvEmployee);
            this.flowLayoutPanel2.Controls.Add(this.dgvFacility);
            this.flowLayoutPanel2.Controls.Add(this.dgvTournament);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 90);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(635, 286);
            this.flowLayoutPanel2.TabIndex = 2;
            // 
            // dgvEmployee
            // 
            this.dgvEmployee.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmployee.Location = new System.Drawing.Point(3, 3);
            this.dgvEmployee.Name = "dgvEmployee";
            this.dgvEmployee.RowHeadersWidth = 62;
            this.dgvEmployee.RowTemplate.Height = 33;
            this.dgvEmployee.Size = new System.Drawing.Size(596, 250);
            this.dgvEmployee.TabIndex = 2;
            // 
            // frmBusiness
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1321, 598);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Font = new System.Drawing.Font("VNI-Avo", 9.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "frmBusiness";
            this.Text = "Business";
            this.Load += new System.EventHandler(this.frmBusiness_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFull)).EndInit();
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFacility)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTournament)).EndInit();
            this.flowLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployee)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private FlowLayoutPanel flowLayoutPanel1;
        private Panel panel3;
        private Panel panel4;
        private Panel panel1;
        private Panel panel2;
        private DataGridView dgvFull;
        private DataGridView dgvFacility;
        private Panel panel5;
        private Button btnAllEmployee;
        private Button btnAllTournament;
        private Button btnAllFacility;
        private FlowLayoutPanel flowLayoutPanel2;
        private DataGridView dgvEmployee;
        private DataGridView dgvTournament;
    }
}