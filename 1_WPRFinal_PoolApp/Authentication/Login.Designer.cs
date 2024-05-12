namespace _1_WPRFinal_PoolApp.Authentication
{
    partial class frmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnRegis = new System.Windows.Forms.Button();
            this.lblRes = new System.Windows.Forms.Label();
            this.ckbSaveLogin = new System.Windows.Forms.CheckBox();
            this.lblForgotPass = new System.Windows.Forms.LinkLabel();
            this.btnSee = new System.Windows.Forms.Button();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.panel1.Controls.Add(this.btnLogin);
            this.panel1.Controls.Add(this.btnRegis);
            this.panel1.Controls.Add(this.lblRes);
            this.panel1.Controls.Add(this.ckbSaveLogin);
            this.panel1.Controls.Add(this.lblForgotPass);
            this.panel1.Controls.Add(this.btnSee);
            this.panel1.Controls.Add(this.txtPass);
            this.panel1.Controls.Add(this.txtUsername);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(40, 68);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(493, 510);
            this.panel1.TabIndex = 0;
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(128, 402);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(131, 52);
            this.btnLogin.TabIndex = 11;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnRegis
            // 
            this.btnRegis.Location = new System.Drawing.Point(305, 402);
            this.btnRegis.Name = "btnRegis";
            this.btnRegis.Size = new System.Drawing.Size(131, 52);
            this.btnRegis.TabIndex = 10;
            this.btnRegis.Text = "Register";
            this.btnRegis.UseVisualStyleBackColor = true;
            this.btnRegis.Click += new System.EventHandler(this.btnRegis_Click);
            // 
            // lblRes
            // 
            this.lblRes.AutoSize = true;
            this.lblRes.Location = new System.Drawing.Point(128, 344);
            this.lblRes.Name = "lblRes";
            this.lblRes.Size = new System.Drawing.Size(318, 28);
            this.lblRes.TabIndex = 8;
            this.lblRes.Text = "Welcome Back to The PoolApp";
            // 
            // ckbSaveLogin
            // 
            this.ckbSaveLogin.AutoSize = true;
            this.ckbSaveLogin.Location = new System.Drawing.Point(128, 251);
            this.ckbSaveLogin.Name = "ckbSaveLogin";
            this.ckbSaveLogin.Size = new System.Drawing.Size(229, 32);
            this.ckbSaveLogin.TabIndex = 7;
            this.ckbSaveLogin.Text = "Save my Login info ";
            this.ckbSaveLogin.UseVisualStyleBackColor = true;
            // 
            // lblForgotPass
            // 
            this.lblForgotPass.AutoSize = true;
            this.lblForgotPass.Location = new System.Drawing.Point(128, 286);
            this.lblForgotPass.Name = "lblForgotPass";
            this.lblForgotPass.Size = new System.Drawing.Size(173, 28);
            this.lblForgotPass.TabIndex = 6;
            this.lblForgotPass.TabStop = true;
            this.lblForgotPass.Text = "Forgot Password";
            // 
            // btnSee
            // 
            this.btnSee.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSee.BackgroundImage")));
            this.btnSee.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSee.Location = new System.Drawing.Point(442, 193);
            this.btnSee.Name = "btnSee";
            this.btnSee.Size = new System.Drawing.Size(35, 36);
            this.btnSee.TabIndex = 5;
            this.btnSee.UseVisualStyleBackColor = true;
            this.btnSee.Click += new System.EventHandler(this.btnSee_Click);
            // 
            // txtPass
            // 
            this.txtPass.Location = new System.Drawing.Point(128, 193);
            this.txtPass.Name = "txtPass";
            this.txtPass.Size = new System.Drawing.Size(308, 36);
            this.txtPass.TabIndex = 4;
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(128, 135);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(308, 36);
            this.txtUsername.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 193);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 28);
            this.label3.TabIndex = 2;
            this.label3.Text = "Password";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 138);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 28);
            this.label2.TabIndex = 1;
            this.label2.Text = "Email";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(128, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "Login";
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(930, 630);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("VNI-Avo", 9.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "frmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.frmLogin_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private Button btnLogin;
        private Button btnRegis;
        private Label lblRes;
        private CheckBox ckbSaveLogin;
        private LinkLabel lblForgotPass;
        private Button btnSee;
        private TextBox txtPass;
        private TextBox txtUsername;
        private Label label3;
        private Label label2;
        private Label label1;
    }
}