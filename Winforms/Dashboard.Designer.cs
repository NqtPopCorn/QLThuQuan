
namespace QLThuQuan.Winforms
{
    partial class Dashboard
    {

        

        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tableLayoutPanel1 = new TableLayoutPanel();
            btnThietBi = new Button();
            btnQLDatMuon = new Button();
            btnUser = new Button();
            btnQLMuonTra = new Button();
            button5 = new Button();
            btnDangXuat = new Button();
            btnTK = new Button();
            pictureBox1 = new PictureBox();
            cardPanel = new Panel();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(btnThietBi, 0, 2);
            tableLayoutPanel1.Controls.Add(btnQLDatMuon, 0, 3);
            tableLayoutPanel1.Controls.Add(btnUser, 0, 2);
            tableLayoutPanel1.Controls.Add(btnQLMuonTra, 0, 4);
            tableLayoutPanel1.Controls.Add(button5, 0, 1);
            tableLayoutPanel1.Controls.Add(btnDangXuat, 0, 7);
            tableLayoutPanel1.Controls.Add(btnTK, 0, 5);
            tableLayoutPanel1.Controls.Add(pictureBox1, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Left;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 8;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.Size = new Size(281, 840);
            tableLayoutPanel1.TabIndex = 0;
            tableLayoutPanel1.Paint += tableLayoutPanel1_Paint;
            // 
            // btnThietBi
            // 
            btnThietBi.Dock = DockStyle.Fill;
            btnThietBi.Location = new Point(3, 339);
            btnThietBi.Name = "btnThietBi";
            btnThietBi.Size = new Size(275, 78);
            btnThietBi.TabIndex = 0;
            btnThietBi.Text = "Thiết bị";
            btnThietBi.UseVisualStyleBackColor = true;
            // 
            // btnQLDatMuon
            // 
            btnQLDatMuon.Dock = DockStyle.Fill;
            btnQLDatMuon.Location = new Point(3, 507);
            btnQLDatMuon.Name = "btnQLDatMuon";
            btnQLDatMuon.Size = new Size(275, 78);
            btnQLDatMuon.TabIndex = 1;
            btnQLDatMuon.Text = "Đặt mượn";
            btnQLDatMuon.UseVisualStyleBackColor = true;
            // 
            // btnUser
            // 
            btnUser.Dock = DockStyle.Fill;
            btnUser.Location = new Point(3, 423);
            btnUser.Name = "btnUser";
            btnUser.Size = new Size(275, 78);
            btnUser.TabIndex = 0;
            btnUser.Text = "User";
            btnUser.UseVisualStyleBackColor = true;
            btnUser.Click += button1_Click;
            // 
            // btnQLMuonTra
            // 
            btnQLMuonTra.Dock = DockStyle.Fill;
            btnQLMuonTra.Location = new Point(3, 591);
            btnQLMuonTra.Name = "btnQLMuonTra";
            btnQLMuonTra.Size = new Size(275, 78);
            btnQLMuonTra.TabIndex = 2;
            btnQLMuonTra.Text = "Mượn trả";
            btnQLMuonTra.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            button5.Dock = DockStyle.Fill;
            button5.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button5.Location = new Point(3, 255);
            button5.Name = "button5";
            button5.Size = new Size(275, 78);
            button5.TabIndex = 4;
            button5.Text = "Info";
            button5.UseVisualStyleBackColor = true;
            // 
            // btnDangXuat
            // 
            btnDangXuat.Dock = DockStyle.Fill;
            btnDangXuat.Location = new Point(3, 759);
            btnDangXuat.Name = "btnDangXuat";
            btnDangXuat.Size = new Size(275, 78);
            btnDangXuat.TabIndex = 3;
            btnDangXuat.Text = "Đăng Xuất";
            btnDangXuat.UseVisualStyleBackColor = true;
            btnDangXuat.Click += btnDangXuat_Click;
            // 
            // btnTK
            // 
            btnTK.Dock = DockStyle.Fill;
            btnTK.Location = new Point(3, 675);
            btnTK.Name = "btnTK";
            btnTK.Size = new Size(275, 78);
            btnTK.TabIndex = 5;
            btnTK.Text = "Thống Kê";
            btnTK.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Image = Properties.Resources.anhtrangchieuroiconduonglacloi;
            pictureBox1.Location = new Point(3, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(275, 246);
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            // 
            // cardPanel
            // 
            cardPanel.BorderStyle = BorderStyle.Fixed3D;
            cardPanel.Dock = DockStyle.Fill;
            cardPanel.Location = new Point(281, 0);
            cardPanel.Name = "cardPanel";
            cardPanel.Size = new Size(1238, 840);
            cardPanel.TabIndex = 1;
            // 
            // Dashboard
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1519, 840);
            Controls.Add(cardPanel);
            Controls.Add(tableLayoutPanel1);
            Name = "Dashboard";
            Text = "Form1";
            tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Button btnThietBi;
        private Button btnQLDatMuon;
        private Button btnQLMuonTra;
        private Button btnDangXuat;
        private Panel cardPanel;
        private Button button5;
        private Button btnUser;
        private Button btnTK;
        private PictureBox pictureBox1;
    }
}
