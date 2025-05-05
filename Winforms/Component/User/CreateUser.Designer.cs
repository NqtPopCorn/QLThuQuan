namespace QLThuQuan.Winforms.Component.User
{
    partial class CreateUser
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
            tableLayoutPanel1 = new TableLayoutPanel();
            flowLayoutPanel2 = new FlowLayoutPanel();
            btnCancel = new Button();
            btnSave = new Button();
            flowLayoutPanel3 = new FlowLayoutPanel();
            label1 = new Label();
            tableLayoutPanel2 = new TableLayoutPanel();
            flowLayoutPanel1 = new FlowLayoutPanel();
            label2 = new Label();
            tbEmail = new TextBox();
            flowLayoutPanel4 = new FlowLayoutPanel();
            label3 = new Label();
            tbFirstName = new TextBox();
            flowLayoutPanel5 = new FlowLayoutPanel();
            label4 = new Label();
            tbLastName = new TextBox();
            flowLayoutPanel6 = new FlowLayoutPanel();
            label5 = new Label();
            tbPassword = new TextBox();
            flowLayoutPanel7 = new FlowLayoutPanel();
            IsAdmin = new Label();
            cbIsAdmin = new CheckBox();
            tableLayoutPanel1.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            flowLayoutPanel3.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            flowLayoutPanel4.SuspendLayout();
            flowLayoutPanel5.SuspendLayout();
            flowLayoutPanel6.SuspendLayout();
            flowLayoutPanel7.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(flowLayoutPanel2, 0, 2);
            tableLayoutPanel1.Controls.Add(flowLayoutPanel3, 0, 0);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 80F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(559, 442);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Controls.Add(btnCancel);
            flowLayoutPanel2.Controls.Add(btnSave);
            flowLayoutPanel2.Dock = DockStyle.Fill;
            flowLayoutPanel2.FlowDirection = FlowDirection.RightToLeft;
            flowLayoutPanel2.Location = new Point(3, 400);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(553, 39);
            flowLayoutPanel2.TabIndex = 2;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.Red;
            btnCancel.ForeColor = SystemColors.ButtonHighlight;
            btnCancel.Location = new Point(475, 3);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 36);
            btnCancel.TabIndex = 0;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.ForestGreen;
            btnSave.ForeColor = SystemColors.ButtonHighlight;
            btnSave.Location = new Point(394, 3);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 36);
            btnSave.TabIndex = 1;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = false;
            // 
            // flowLayoutPanel3
            // 
            flowLayoutPanel3.Controls.Add(label1);
            flowLayoutPanel3.Dock = DockStyle.Fill;
            flowLayoutPanel3.Location = new Point(3, 3);
            flowLayoutPanel3.Name = "flowLayoutPanel3";
            flowLayoutPanel3.Size = new Size(553, 38);
            flowLayoutPanel3.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(175, 30);
            label1.TabIndex = 0;
            label1.Text = "Create New User";
            label1.TextAlign = ContentAlignment.TopCenter;
            label1.Click += label1_Click;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Controls.Add(flowLayoutPanel1, 0, 0);
            tableLayoutPanel2.Controls.Add(flowLayoutPanel4, 0, 1);
            tableLayoutPanel2.Controls.Add(flowLayoutPanel5, 0, 2);
            tableLayoutPanel2.Controls.Add(flowLayoutPanel6, 0, 3);
            tableLayoutPanel2.Controls.Add(flowLayoutPanel7, 0, 4);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(3, 47);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 5;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel2.Size = new Size(553, 347);
            tableLayoutPanel2.TabIndex = 4;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(label2);
            flowLayoutPanel1.Controls.Add(tbEmail);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.Location = new Point(3, 3);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(547, 63);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(3, 0);
            label2.Name = "label2";
            label2.Size = new Size(48, 21);
            label2.TabIndex = 0;
            label2.Text = "Email";
            // 
            // tbEmail
            // 
            tbEmail.Dock = DockStyle.Bottom;
            tbEmail.Location = new Point(3, 24);
            tbEmail.Name = "tbEmail";
            tbEmail.Size = new Size(523, 29);
            tbEmail.TabIndex = 1;
            // 
            // flowLayoutPanel4
            // 
            flowLayoutPanel4.Controls.Add(label3);
            flowLayoutPanel4.Controls.Add(tbFirstName);
            flowLayoutPanel4.Dock = DockStyle.Fill;
            flowLayoutPanel4.Location = new Point(3, 72);
            flowLayoutPanel4.Name = "flowLayoutPanel4";
            flowLayoutPanel4.Size = new Size(547, 63);
            flowLayoutPanel4.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(3, 0);
            label3.Name = "label3";
            label3.Size = new Size(82, 21);
            label3.TabIndex = 0;
            label3.Text = "FirstName";
            // 
            // tbFirstName
            // 
            tbFirstName.Location = new Point(3, 24);
            tbFirstName.Name = "tbFirstName";
            tbFirstName.Size = new Size(523, 29);
            tbFirstName.TabIndex = 1;
            // 
            // flowLayoutPanel5
            // 
            flowLayoutPanel5.Controls.Add(label4);
            flowLayoutPanel5.Controls.Add(tbLastName);
            flowLayoutPanel5.Dock = DockStyle.Fill;
            flowLayoutPanel5.Location = new Point(3, 141);
            flowLayoutPanel5.Name = "flowLayoutPanel5";
            flowLayoutPanel5.Size = new Size(547, 63);
            flowLayoutPanel5.TabIndex = 2;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(3, 0);
            label4.Name = "label4";
            label4.Size = new Size(80, 21);
            label4.TabIndex = 0;
            label4.Text = "LastName";
            // 
            // tbLastName
            // 
            tbLastName.Location = new Point(3, 24);
            tbLastName.Name = "tbLastName";
            tbLastName.Size = new Size(523, 29);
            tbLastName.TabIndex = 1;
            // 
            // flowLayoutPanel6
            // 
            flowLayoutPanel6.Controls.Add(label5);
            flowLayoutPanel6.Controls.Add(tbPassword);
            flowLayoutPanel6.Dock = DockStyle.Fill;
            flowLayoutPanel6.Location = new Point(3, 210);
            flowLayoutPanel6.Name = "flowLayoutPanel6";
            flowLayoutPanel6.Size = new Size(547, 63);
            flowLayoutPanel6.TabIndex = 3;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(3, 0);
            label5.Name = "label5";
            label5.Size = new Size(76, 21);
            label5.TabIndex = 0;
            label5.Text = "Password";
            // 
            // tbPassword
            // 
            tbPassword.Location = new Point(3, 24);
            tbPassword.Name = "tbPassword";
            tbPassword.Size = new Size(523, 29);
            tbPassword.TabIndex = 1;
            // 
            // flowLayoutPanel7
            // 
            flowLayoutPanel7.Controls.Add(IsAdmin);
            flowLayoutPanel7.Controls.Add(cbIsAdmin);
            flowLayoutPanel7.Dock = DockStyle.Fill;
            flowLayoutPanel7.Location = new Point(3, 279);
            flowLayoutPanel7.Name = "flowLayoutPanel7";
            flowLayoutPanel7.Size = new Size(547, 65);
            flowLayoutPanel7.TabIndex = 4;
            // 
            // IsAdmin
            // 
            IsAdmin.AutoSize = true;
            IsAdmin.Location = new Point(3, 0);
            IsAdmin.Name = "IsAdmin";
            IsAdmin.Size = new Size(67, 21);
            IsAdmin.TabIndex = 0;
            IsAdmin.Text = "IsAdmin";
            // 
            // cbIsAdmin
            // 
            cbIsAdmin.AutoSize = true;
            cbIsAdmin.Location = new Point(76, 3);
            cbIsAdmin.Name = "cbIsAdmin";
            cbIsAdmin.Size = new Size(75, 25);
            cbIsAdmin.TabIndex = 1;
            cbIsAdmin.Text = "Admin";
            cbIsAdmin.UseVisualStyleBackColor = true;
            // 
            // CreateUser
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(559, 442);
            Controls.Add(tableLayoutPanel1);
            Name = "CreateUser";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CreateUser";
            tableLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel2.ResumeLayout(false);
            flowLayoutPanel3.ResumeLayout(false);
            flowLayoutPanel3.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            flowLayoutPanel4.ResumeLayout(false);
            flowLayoutPanel4.PerformLayout();
            flowLayoutPanel5.ResumeLayout(false);
            flowLayoutPanel5.PerformLayout();
            flowLayoutPanel6.ResumeLayout(false);
            flowLayoutPanel6.PerformLayout();
            flowLayoutPanel7.ResumeLayout(false);
            flowLayoutPanel7.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private FlowLayoutPanel flowLayoutPanel2;
        private Button btnCancel;
        private Button btnSave;
        private FlowLayoutPanel flowLayoutPanel3;
        private Label label1;
        private TableLayoutPanel tableLayoutPanel2;
        private FlowLayoutPanel flowLayoutPanel1;
        private FlowLayoutPanel flowLayoutPanel4;
        private FlowLayoutPanel flowLayoutPanel5;
        private FlowLayoutPanel flowLayoutPanel6;
        private FlowLayoutPanel flowLayoutPanel7;
        private Label label2;
        private TextBox tbEmail;
        private Label label3;
        private TextBox tbFirstName;
        private Label label4;
        private TextBox tbLastName;
        private Label label5;
        private TextBox tbPassword;
        private Label IsAdmin;
        private CheckBox cbIsAdmin;
    }
}