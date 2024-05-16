namespace _1_WPRFinal_PoolApp.Forms
{
    partial class frmAdmin
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
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            WaitApproveDataGridView = new DataGridView();
            DeclineButton = new Button();
            ApproveButton = new Button();
            ActiveDataGridView = new DataGridView();
            tabPage2 = new TabPage();
            PrintToPdfButton = new Button();
            UsersDataGridView = new DataGridView();
            tabPage3 = new TabPage();
            PrintToPdf2Button = new Button();
            BusinessDataGridView = new DataGridView();
            tabPage4 = new TabPage();
            PrintResultButton = new Button();
            MatchResultDataGridView = new DataGridView();
            DeleteButton = new Button();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)WaitApproveDataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ActiveDataGridView).BeginInit();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)UsersDataGridView).BeginInit();
            tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)BusinessDataGridView).BeginInit();
            tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)MatchResultDataGridView).BeginInit();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Controls.Add(tabPage4);
            tabControl1.Location = new Point(12, 12);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1118, 601);
            tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(WaitApproveDataGridView);
            tabPage1.Controls.Add(DeclineButton);
            tabPage1.Controls.Add(ApproveButton);
            tabPage1.Controls.Add(ActiveDataGridView);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1110, 573);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Account";
            tabPage1.UseVisualStyleBackColor = true;
            tabPage1.Click += tabPage1_Click;
            // 
            // WaitApproveDataGridView
            // 
            WaitApproveDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            WaitApproveDataGridView.Location = new Point(17, 6);
            WaitApproveDataGridView.Name = "WaitApproveDataGridView";
            WaitApproveDataGridView.RowTemplate.Height = 25;
            WaitApproveDataGridView.Size = new Size(1087, 226);
            WaitApproveDataGridView.TabIndex = 4;
            WaitApproveDataGridView.CellContentClick += WaitApproveDataGridView_CellContentClick;
            // 
            // DeclineButton
            // 
            DeclineButton.Location = new Point(867, 262);
            DeclineButton.Name = "DeclineButton";
            DeclineButton.Size = new Size(89, 32);
            DeclineButton.TabIndex = 3;
            DeclineButton.Text = "Decline";
            DeclineButton.UseVisualStyleBackColor = true;
            DeclineButton.Click += DeclineButton_Click;
            // 
            // ApproveButton
            // 
            ApproveButton.Location = new Point(744, 262);
            ApproveButton.Name = "ApproveButton";
            ApproveButton.Size = new Size(89, 32);
            ApproveButton.TabIndex = 2;
            ApproveButton.Text = "Approve";
            ApproveButton.UseVisualStyleBackColor = true;
            ApproveButton.Click += ApproveButton_Click;
            // 
            // ActiveDataGridView
            // 
            ActiveDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            ActiveDataGridView.Location = new Point(17, 319);
            ActiveDataGridView.Name = "ActiveDataGridView";
            ActiveDataGridView.RowTemplate.Height = 25;
            ActiveDataGridView.Size = new Size(1087, 226);
            ActiveDataGridView.TabIndex = 1;
            ActiveDataGridView.CellContentClick += ActiveDataGridView_CellContentClick;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(PrintToPdfButton);
            tabPage2.Controls.Add(UsersDataGridView);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1110, 573);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Players";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // PrintToPdfButton
            // 
            PrintToPdfButton.Location = new Point(951, 385);
            PrintToPdfButton.Name = "PrintToPdfButton";
            PrintToPdfButton.Size = new Size(140, 54);
            PrintToPdfButton.TabIndex = 1;
            PrintToPdfButton.Text = "Print";
            PrintToPdfButton.UseVisualStyleBackColor = true;
            PrintToPdfButton.Click += PrintToPdfButton_Click;
            // 
            // UsersDataGridView
            // 
            UsersDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            UsersDataGridView.Location = new Point(17, 17);
            UsersDataGridView.Name = "UsersDataGridView";
            UsersDataGridView.RowTemplate.Height = 25;
            UsersDataGridView.Size = new Size(1074, 342);
            UsersDataGridView.TabIndex = 0;
            UsersDataGridView.CellContentClick += UsersDataGridView_CellContentClick;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(PrintToPdf2Button);
            tabPage3.Controls.Add(BusinessDataGridView);
            tabPage3.Location = new Point(4, 24);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(1110, 573);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "FacOwner";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // PrintToPdf2Button
            // 
            PrintToPdf2Button.Location = new Point(953, 318);
            PrintToPdf2Button.Name = "PrintToPdf2Button";
            PrintToPdf2Button.Size = new Size(142, 57);
            PrintToPdf2Button.TabIndex = 1;
            PrintToPdf2Button.Text = "Print";
            PrintToPdf2Button.UseVisualStyleBackColor = true;
            PrintToPdf2Button.Click += PrintToPdf2Button_Click;
            // 
            // BusinessDataGridView
            // 
            BusinessDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            BusinessDataGridView.Location = new Point(16, 6);
            BusinessDataGridView.Name = "BusinessDataGridView";
            BusinessDataGridView.RowTemplate.Height = 25;
            BusinessDataGridView.Size = new Size(1079, 281);
            BusinessDataGridView.TabIndex = 0;
            BusinessDataGridView.CellContentClick += BusinessDataGridView_CellContentClick;
            BusinessDataGridView.CellDoubleClick += BusinessDataGridView_CellDoubleClick;
            // 
            // tabPage4
            // 
            tabPage4.Controls.Add(PrintResultButton);
            tabPage4.Controls.Add(MatchResultDataGridView);
            tabPage4.Location = new Point(4, 24);
            tabPage4.Name = "tabPage4";
            tabPage4.Padding = new Padding(3);
            tabPage4.Size = new Size(1110, 573);
            tabPage4.TabIndex = 3;
            tabPage4.Text = "Match Result";
            tabPage4.UseVisualStyleBackColor = true;
            // 
            // PrintResultButton
            // 
            PrintResultButton.Location = new Point(885, 413);
            PrintResultButton.Name = "PrintResultButton";
            PrintResultButton.Size = new Size(89, 40);
            PrintResultButton.TabIndex = 1;
            PrintResultButton.Text = "Print";
            PrintResultButton.UseVisualStyleBackColor = true;
            PrintResultButton.Click += PrintResultButton_Click;
            // 
            // MatchResultDataGridView
            // 
            MatchResultDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            MatchResultDataGridView.Location = new Point(6, 17);
            MatchResultDataGridView.Name = "MatchResultDataGridView";
            MatchResultDataGridView.RowTemplate.Height = 25;
            MatchResultDataGridView.Size = new Size(1098, 363);
            MatchResultDataGridView.TabIndex = 0;
            // 
            // DeleteButton
            // 
            DeleteButton.Location = new Point(883, 619);
            DeleteButton.Name = "DeleteButton";
            DeleteButton.Size = new Size(89, 44);
            DeleteButton.TabIndex = 1;
            DeleteButton.Text = "Delete";
            DeleteButton.UseVisualStyleBackColor = true;
            DeleteButton.Click += DeleteButton_Click;
            // 
            // frmAdmin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1142, 675);
            Controls.Add(DeleteButton);
            Controls.Add(tabControl1);
            Margin = new Padding(2);
            Name = "frmAdmin";
            Text = "Admin";
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)WaitApproveDataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)ActiveDataGridView).EndInit();
            tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)UsersDataGridView).EndInit();
            tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)BusinessDataGridView).EndInit();
            tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)MatchResultDataGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private TabPage tabPage4;
        private Button DeclineButton;
        private Button ApproveButton;
        private DataGridView ActiveDataGridView;
        private DataGridView WaitApproveDataGridView;
        private Button PrintToPdfButton;
        private DataGridView UsersDataGridView;
        private DataGridView BusinessDataGridView;
        private Button PrintToPdf2Button;
        private Button PrintResultButton;
        private DataGridView MatchResultDataGridView;
        private Button DeleteButton;
    }
}