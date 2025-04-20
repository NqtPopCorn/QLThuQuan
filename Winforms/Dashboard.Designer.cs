
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
            btnQLMuonTra = new Button();
            button4 = new Button();
            button5 = new Button();
            cardPanel = new Panel();
            btnUser = new Button();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(btnThietBi, 0, 1);
            tableLayoutPanel1.Controls.Add(btnQLDatMuon, 0, 3);
            tableLayoutPanel1.Controls.Add(btnUser, 0, 2);
            tableLayoutPanel1.Controls.Add(btnQLMuonTra, 0, 4);
            tableLayoutPanel1.Controls.Add(button4, 0, 5);
            tableLayoutPanel1.Controls.Add(button5, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Left;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 6;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 200F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
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
            btnThietBi.Size = new Size(244, 124);
            btnThietBi.TabIndex = 0;
            btnThietBi.Text = "Thiết bị";
            btnThietBi.UseVisualStyleBackColor = true;
            // 
            // btnQLDatMuon
            // 
            btnQLDatMuon.Dock = DockStyle.Fill;
            btnQLDatMuon.Location = new Point(3, 463);
            btnQLDatMuon.Name = "btnQLDatMuon";
            btnQLDatMuon.Size = new Size(244, 124);
            btnQLDatMuon.TabIndex = 1;
            btnQLDatMuon.Text = "Đặt mượn";
            btnQLDatMuon.UseVisualStyleBackColor = true;
            // 
            // btnQLMuonTra
            // 
            btnQLMuonTra.Dock = DockStyle.Fill;
            btnQLMuonTra.Location = new Point(3, 593);
            btnQLMuonTra.Name = "btnQLMuonTra";
            btnQLMuonTra.Size = new Size(244, 124);
            btnQLMuonTra.TabIndex = 2;
            btnQLMuonTra.Text = "Mượn trả";
            btnQLMuonTra.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Dock = DockStyle.Fill;
            button4.Location = new Point(3, 723);
            button4.Name = "button4";
            button4.Size = new Size(244, 74);
            button4.TabIndex = 3;
            button4.Text = "btnDangXuat";
            button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            button5.Dock = DockStyle.Fill;
            button5.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button5.Location = new Point(3, 3);
            button5.Name = "button5";
            button5.Size = new Size(244, 194);
            button5.TabIndex = 4;
            button5.Text = "Info";
            button5.UseVisualStyleBackColor = true;
            // 
            // cardPanel
            // 
            cardPanel.Dock = DockStyle.Fill;
            cardPanel.Location = new Point(250, 0);
            cardPanel.Name = "cardPanel";
            cardPanel.Size = new Size(1100, 800);
            cardPanel.TabIndex = 1;
            // 
            // btnUser
            // 
            btnUser.Dock = DockStyle.Fill;
            btnUser.Location = new Point(3, 333);
            btnUser.Name = "btnUser";
            btnUser.Size = new Size(244, 124);
            btnUser.TabIndex = 0;
            btnUser.Text = "User";
            btnUser.UseVisualStyleBackColor = true;
            btnUser.Click += button1_Click;
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
        private Button button4;
        private Panel cardPanel;
        private Button button5;
        private Button btnUser;
    }
}
