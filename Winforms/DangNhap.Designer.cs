namespace QL_ThuQuan
{
    partial class DangNhap
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
            flpnlDangNhapAdmin = new FlowLayoutPanel();
            panel1 = new Panel();
            pImageDangNhapAdmin = new Panel();
            pDangNhap = new Panel();
            button1 = new Button();
            tbPasswordDN = new TextBox();
            label4 = new Label();
            tbUserNameDN = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            flpnlDangNhapAdmin.SuspendLayout();
            pDangNhap.SuspendLayout();
            SuspendLayout();
            // 
            // flpnlDangNhapAdmin
            // 
            flpnlDangNhapAdmin.BackColor = Color.White;
            flpnlDangNhapAdmin.BorderStyle = BorderStyle.FixedSingle;
            flpnlDangNhapAdmin.Controls.Add(panel1);
            flpnlDangNhapAdmin.Controls.Add(pImageDangNhapAdmin);
            flpnlDangNhapAdmin.Controls.Add(pDangNhap);
            flpnlDangNhapAdmin.Location = new Point(168, 142);
            flpnlDangNhapAdmin.Name = "flpnlDangNhapAdmin";
            flpnlDangNhapAdmin.Size = new Size(877, 493);
            flpnlDangNhapAdmin.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(8, 8);
            panel1.TabIndex = 0;
            // 
            // pImageDangNhapAdmin
            // 
            pImageDangNhapAdmin.BackgroundImage = Properties.Resources.anhtrangchieuroiconduonglacloi;
            pImageDangNhapAdmin.BackgroundImageLayout = ImageLayout.Stretch;
            pImageDangNhapAdmin.Location = new Point(17, 3);
            pImageDangNhapAdmin.Name = "pImageDangNhapAdmin";
            pImageDangNhapAdmin.Size = new Size(393, 489);
            pImageDangNhapAdmin.TabIndex = 1;
            // 
            // pDangNhap
            // 
            pDangNhap.Controls.Add(button1);
            pDangNhap.Controls.Add(tbPasswordDN);
            pDangNhap.Controls.Add(label4);
            pDangNhap.Controls.Add(tbUserNameDN);
            pDangNhap.Controls.Add(label3);
            pDangNhap.Controls.Add(label2);
            pDangNhap.Location = new Point(416, 3);
            pDangNhap.Name = "pDangNhap";
            pDangNhap.Size = new Size(452, 489);
            pDangNhap.TabIndex = 2;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(0, 192, 192);
            button1.Font = new Font("Arial", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.White;
            button1.Location = new Point(53, 304);
            button1.Name = "button1";
            button1.Size = new Size(383, 37);
            button1.TabIndex = 5;
            button1.Text = "Login";
            button1.UseVisualStyleBackColor = false;
            // 
            // tbPasswordDN
            // 
            tbPasswordDN.Location = new Point(52, 241);
            tbPasswordDN.Name = "tbPasswordDN";
            tbPasswordDN.Size = new Size(384, 29);
            tbPasswordDN.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Arial", 15.75F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.FromArgb(0, 192, 192);
            label4.Location = new Point(52, 214);
            label4.Name = "label4";
            label4.Size = new Size(109, 24);
            label4.TabIndex = 3;
            label4.Text = "Password:";
            label4.Click += label4_Click;
            // 
            // tbUserNameDN
            // 
            tbUserNameDN.Location = new Point(52, 167);
            tbUserNameDN.Name = "tbUserNameDN";
            tbUserNameDN.Size = new Size(384, 29);
            tbUserNameDN.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Arial", 15.75F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(0, 192, 192);
            label3.Location = new Point(52, 140);
            label3.Name = "label3";
            label3.Size = new Size(120, 24);
            label3.TabIndex = 1;
            label3.Text = "Username: ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial Narrow", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(159, 31);
            label2.Name = "label2";
            label2.Size = new Size(160, 37);
            label2.TabIndex = 0;
            label2.Text = "Đăng Nhập";
            label2.Click += label2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial Narrow", 27.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(500, 66);
            label1.Name = "label1";
            label1.Size = new Size(223, 43);
            label1.TabIndex = 1;
            label1.Text = "LOGIN ADMIN";
            label1.Click += label1_Click;
            // 
            // DangNhap
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(224, 224, 224);
            ClientSize = new Size(1184, 760);
            Controls.Add(label1);
            Controls.Add(flpnlDangNhapAdmin);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "DangNhap";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "DangNhap";
            flpnlDangNhapAdmin.ResumeLayout(false);
            pDangNhap.ResumeLayout(false);
            pDangNhap.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FlowLayoutPanel flpnlDangNhapAdmin;
        private Label label1;
        private Panel panel1;
        private Panel pImageDangNhapAdmin;
        private Panel pDangNhap;
        private Label label2;
        private TextBox tbPasswordDN;
        private Label label4;
        private TextBox tbUserNameDN;
        private Label label3;
        private Button button1;
    }
}