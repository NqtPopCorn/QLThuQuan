
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
            btnInfo = new Button();
            cardPanel = new Panel();
            btnThongKe = new Button();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(btnThongKe, 0, 4);
            tableLayoutPanel1.Controls.Add(btnThietBi, 0, 1);
            tableLayoutPanel1.Controls.Add(btnQLDatMuon, 0, 3);
            tableLayoutPanel1.Controls.Add(btnUser, 0, 2);
            tableLayoutPanel1.Controls.Add(btnQLMuonTra, 0, 5);
            tableLayoutPanel1.Controls.Add(btnInfo, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Left;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 7;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 200F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 80F));
            tableLayoutPanel1.Size = new Size(250, 800);
            tableLayoutPanel1.TabIndex = 0;
            tableLayoutPanel1.Paint += tableLayoutPanel1_Paint;
            // 
            // btnThietBi
            // 
            btnThietBi.Dock = DockStyle.Fill;
            btnThietBi.Location = new Point(3, 203);
            btnThietBi.Name = "btnThietBi";
            btnThietBi.Size = new Size(244, 98);
            btnThietBi.TabIndex = 0;
            btnThietBi.Text = "Thiết bị";
            btnThietBi.UseVisualStyleBackColor = true;
            // 
            // btnQLDatMuon
            // 
            btnQLDatMuon.Dock = DockStyle.Fill;
            btnQLDatMuon.Location = new Point(3, 411);
            btnQLDatMuon.Name = "btnQLDatMuon";
            btnQLDatMuon.Size = new Size(244, 98);
            btnQLDatMuon.TabIndex = 1;
            btnQLDatMuon.Text = "Đặt mượn";
            btnQLDatMuon.UseVisualStyleBackColor = true;
            // 
            // btnUser
            // 
            btnUser.Dock = DockStyle.Fill;
            btnUser.Location = new Point(3, 307);
            btnUser.Name = "btnUser";
            btnUser.Size = new Size(244, 98);
            btnUser.TabIndex = 0;
            btnUser.Text = "User";
            btnUser.UseVisualStyleBackColor = true;
            btnUser.Click += button1_Click;
            // 
            // btnQLMuonTra
            // 
            btnQLMuonTra.Dock = DockStyle.Fill;
            btnQLMuonTra.Location = new Point(3, 619);
            btnQLMuonTra.Name = "btnQLMuonTra";
            btnQLMuonTra.Size = new Size(244, 98);
            btnQLMuonTra.TabIndex = 2;
            btnQLMuonTra.Text = "Mượn trả";
            btnQLMuonTra.UseVisualStyleBackColor = true;
            // 
            // btnInfo
            // 
            btnInfo.Dock = DockStyle.Fill;
            btnInfo.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnInfo.Location = new Point(3, 3);
            btnInfo.Name = "btnInfo";
            btnInfo.Size = new Size(244, 194);
            btnInfo.TabIndex = 4;
            btnInfo.Text = "Info";
            btnInfo.UseVisualStyleBackColor = true;
            // 
            // cardPanel
            // 
            cardPanel.Dock = DockStyle.Fill;
            cardPanel.Location = new Point(250, 0);
            cardPanel.Name = "cardPanel";
            cardPanel.Size = new Size(1100, 800);
            cardPanel.TabIndex = 1;
            // 
            // btnThongKe
            // 
            btnThongKe.Dock = DockStyle.Fill;
            btnThongKe.Location = new Point(3, 515);
            btnThongKe.Name = "btnThongKe";
            btnThongKe.Size = new Size(244, 98);
            btnThongKe.TabIndex = 5;
            btnThongKe.Text = "Thống kê";
            btnThongKe.UseVisualStyleBackColor = true;
            // 
            // Dashboard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1350, 800);
            Controls.Add(cardPanel);
            Controls.Add(tableLayoutPanel1);
            Name = "Dashboard";
            Text = "Form1";
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Button btnThietBi;
        private Button btnQLDatMuon;
        private Button btnQLMuonTra;
        private Panel cardPanel;
        private Button btnInfo;
        private Button btnUser;
        private Button btnThongKe;
    }
}
