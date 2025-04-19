namespace QL_ThuQuan
{
    partial class UCUser
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
            panel1 = new Panel();
            bPrintPDFUser = new Button();
            bAddNewUser = new Button();
            bResetUser = new Button();
            tbSearchUser = new TextBox();
            label2 = new Label();
            panel3 = new Panel();
            label1 = new Label();
            label3 = new Label();
            dgvUsers = new DataGridView();
            label4 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsers).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(bPrintPDFUser);
            panel1.Controls.Add(bAddNewUser);
            panel1.Controls.Add(bResetUser);
            panel1.Controls.Add(tbSearchUser);
            panel1.Controls.Add(label2);
            panel1.Location = new Point(12, 71);
            panel1.Name = "panel1";
            panel1.Size = new Size(1198, 61);
            panel1.TabIndex = 0;
            // 
            // bPrintPDFUser
            // 
            bPrintPDFUser.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            bPrintPDFUser.Location = new Point(868, 13);
            bPrintPDFUser.Name = "bPrintPDFUser";
            bPrintPDFUser.Size = new Size(105, 35);
            bPrintPDFUser.TabIndex = 4;
            bPrintPDFUser.Text = "Print PDF";
            bPrintPDFUser.UseVisualStyleBackColor = true;
            // 
            // bAddNewUser
            // 
            bAddNewUser.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            bAddNewUser.Location = new Point(979, 13);
            bAddNewUser.Name = "bAddNewUser";
            bAddNewUser.Size = new Size(105, 35);
            bAddNewUser.TabIndex = 3;
            bAddNewUser.Text = "New";
            bAddNewUser.UseVisualStyleBackColor = true;
            bAddNewUser.Click += button2_Click;
            // 
            // bResetUser
            // 
            bResetUser.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            bResetUser.Location = new Point(1090, 13);
            bResetUser.Name = "bResetUser";
            bResetUser.Size = new Size(105, 35);
            bResetUser.TabIndex = 2;
            bResetUser.Text = "Reset";
            bResetUser.UseVisualStyleBackColor = true;
            bResetUser.Click += button1_Click;
            // 
            // tbSearchUser
            // 
            tbSearchUser.Location = new Point(87, 13);
            tbSearchUser.Name = "tbSearchUser";
            tbSearchUser.Size = new Size(418, 29);
            tbSearchUser.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial", 15.75F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label2.Location = new Point(3, 14);
            label2.Name = "label2";
            label2.Size = new Size(78, 24);
            label2.TabIndex = 0;
            label2.Text = "Search";
            // 
            // panel3
            // 
            panel3.Location = new Point(387, 746);
            panel3.Name = "panel3";
            panel3.Size = new Size(477, 37);
            panel3.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial Narrow", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 19);
            label1.Name = "label1";
            label1.Size = new Size(192, 37);
            label1.TabIndex = 3;
            label1.Text = "Quản Lý User";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Arial Narrow", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(542, 154);
            label3.Name = "label3";
            label3.Size = new Size(0, 31);
            label3.TabIndex = 4;
            // 
            // dgvUsers
            // 
            dgvUsers.BackgroundColor = SystemColors.ButtonHighlight;
            dgvUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsers.Location = new Point(12, 209);
            dgvUsers.Name = "dgvUsers";
            dgvUsers.Size = new Size(1195, 521);
            dgvUsers.TabIndex = 6;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Arial Narrow", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(542, 163);
            label4.Name = "label4";
            label4.Size = new Size(191, 31);
            label4.TabIndex = 7;
            label4.Text = "Thông Tin Users";
            label4.TextAlign = ContentAlignment.TopCenter;
            // 
            // UCUser
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1222, 800);
            Controls.Add(label4);
            Controls.Add(dgvUsers);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(panel3);
            Controls.Add(panel1);
            Name = "UCUser";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "UCUser";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsers).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Button bAddNewUser;
        private Button bResetUser;
        private TextBox tbSearchUser;
        private Label label2;
        private Panel panel3;
        private Label label1;
        private Label label3;
        private Button bPrintPDFUser;
        private DataGridView dgvUsers;
        private Label label4;
    }
}