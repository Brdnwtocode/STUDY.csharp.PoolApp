namespace _1_WPRFinal_PoolApp.userForms
{
    partial class Tournaments
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
            this.fpnlTournaments = new System.Windows.Forms.FlowLayoutPanel();
            this.fpnlPosts = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // fpnlTournaments
            // 
            this.fpnlTournaments.AutoScroll = true;
            this.fpnlTournaments.Dock = System.Windows.Forms.DockStyle.Top;
            this.fpnlTournaments.Location = new System.Drawing.Point(0, 0);
            this.fpnlTournaments.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.fpnlTournaments.Name = "fpnlTournaments";
            this.fpnlTournaments.Size = new System.Drawing.Size(1318, 239);
            this.fpnlTournaments.TabIndex = 0;
            // 
            // fpnlPosts
            // 
            this.fpnlPosts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fpnlPosts.Location = new System.Drawing.Point(0, 239);
            this.fpnlPosts.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.fpnlPosts.Name = "fpnlPosts";
            this.fpnlPosts.Size = new System.Drawing.Size(1318, 355);
            this.fpnlPosts.TabIndex = 1;
            // 
            // Tournaments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1318, 594);
            this.Controls.Add(this.fpnlPosts);
            this.Controls.Add(this.fpnlTournaments);
            this.Font = new System.Drawing.Font("VNI-Avo", 9.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "Tournaments";
            this.Text = "Tournaments";
            this.ResumeLayout(false);

        }

        #endregion

        private FlowLayoutPanel fpnlTournaments;
        private FlowLayoutPanel fpnlPosts;
    }
}