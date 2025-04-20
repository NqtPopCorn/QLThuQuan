namespace QLThuQuan.Winforms.Controls
{
    partial class QLDatMuon
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            panel1 = new Panel();
            button7 = new Button();
            button6 = new Button();
            button5 = new Button();
            btnReset = new Button();
            btnTaoVaDuyet = new Button();
            tableLayoutPanel2 = new TableLayoutPanel();
            panel5 = new Panel();
            trackBarSoNgayMuon = new TrackBar();
            label5 = new Label();
            panel4 = new Panel();
            label4 = new Label();
            panel3 = new Panel();
            button2 = new Button();
            label3 = new Label();
            txtMaThietBi = new TextBox();
            panel2 = new Panel();
            button1 = new Button();
            label2 = new Label();
            txtMaThanhVien = new TextBox();
            gridViewPhieuDatMuon = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            txtMaDatCho = new TextBox();
            cbAutoID = new CheckBox();
            tableLayoutPanel1.SuspendLayout();
            panel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trackBarSoNgayMuon).BeginInit();
            panel4.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridViewPhieuDatMuon).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ImageAlign = ContentAlignment.TopLeft;
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(1094, 50);
            label1.TabIndex = 0;
            label1.Text = "Quản lý đặt mượn";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Top;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(1100, 50);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // panel1
            // 
            panel1.AutoSize = true;
            panel1.Controls.Add(gridViewPhieuDatMuon);
            panel1.Controls.Add(button7);
            panel1.Controls.Add(button6);
            panel1.Controls.Add(button5);
            panel1.Controls.Add(btnReset);
            panel1.Controls.Add(btnTaoVaDuyet);
            panel1.Controls.Add(tableLayoutPanel2);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 50);
            panel1.Name = "panel1";
            panel1.Size = new Size(1100, 750);
            panel1.TabIndex = 2;
            // 
            // button7
            // 
            button7.BackColor = SystemColors.ActiveBorder;
            button7.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button7.ForeColor = SystemColors.ButtonFace;
            button7.Location = new Point(350, 705);
            button7.Name = "button7";
            button7.Size = new Size(111, 29);
            button7.TabIndex = 6;
            button7.Text = "Reset";
            button7.UseVisualStyleBackColor = false;
            // 
            // button6
            // 
            button6.BackColor = Color.Red;
            button6.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button6.ForeColor = SystemColors.ButtonFace;
            button6.Location = new Point(228, 705);
            button6.Name = "button6";
            button6.Size = new Size(94, 29);
            button6.TabIndex = 5;
            button6.Text = "Hủy";
            button6.UseVisualStyleBackColor = false;
            // 
            // button5
            // 
            button5.BackColor = Color.ForestGreen;
            button5.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button5.ForeColor = SystemColors.ButtonFace;
            button5.Location = new Point(105, 705);
            button5.Name = "button5";
            button5.Size = new Size(94, 29);
            button5.TabIndex = 4;
            button5.Text = "Duyệt";
            button5.UseVisualStyleBackColor = false;
            // 
            // btnReset
            // 
            btnReset.BackColor = SystemColors.ActiveBorder;
            btnReset.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnReset.ForeColor = SystemColors.ButtonFace;
            btnReset.Location = new Point(281, 286);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(111, 29);
            btnReset.TabIndex = 2;
            btnReset.Text = "Reset";
            btnReset.UseVisualStyleBackColor = false;
            // 
            // btnTaoVaDuyet
            // 
            btnTaoVaDuyet.BackColor = Color.DodgerBlue;
            btnTaoVaDuyet.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnTaoVaDuyet.ForeColor = SystemColors.ButtonFace;
            btnTaoVaDuyet.Location = new Point(113, 286);
            btnTaoVaDuyet.Name = "btnTaoVaDuyet";
            btnTaoVaDuyet.Size = new Size(144, 29);
            btnTaoVaDuyet.TabIndex = 1;
            btnTaoVaDuyet.Text = "Tạo và duyệt";
            btnTaoVaDuyet.UseVisualStyleBackColor = false;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Controls.Add(panel4, 0, 2);
            tableLayoutPanel2.Controls.Add(panel5, 0, 3);
            tableLayoutPanel2.Controls.Add(panel3, 0, 1);
            tableLayoutPanel2.Controls.Add(panel2, 0, 0);
            tableLayoutPanel2.Location = new Point(110, 11);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 4;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33333F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333359F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333359F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 90F));
            tableLayoutPanel2.Size = new Size(753, 259);
            tableLayoutPanel2.TabIndex = 0;
            // 
            // panel5
            // 
            panel5.Controls.Add(trackBarSoNgayMuon);
            panel5.Controls.Add(label5);
            panel5.Dock = DockStyle.Fill;
            panel5.Location = new Point(3, 171);
            panel5.Name = "panel5";
            panel5.Size = new Size(747, 85);
            panel5.TabIndex = 3;
            // 
            // trackBarSoNgayMuon
            // 
            trackBarSoNgayMuon.Location = new Point(150, 16);
            trackBarSoNgayMuon.Name = "trackBarSoNgayMuon";
            trackBarSoNgayMuon.Size = new Size(535, 56);
            trackBarSoNgayMuon.TabIndex = 1;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 16);
            label5.Name = "label5";
            label5.Size = new Size(105, 20);
            label5.TabIndex = 0;
            label5.Text = "Số ngày mượn";
            // 
            // panel4
            // 
            panel4.Controls.Add(cbAutoID);
            panel4.Controls.Add(txtMaDatCho);
            panel4.Controls.Add(label4);
            panel4.Dock = DockStyle.Fill;
            panel4.Location = new Point(3, 115);
            panel4.Name = "panel4";
            panel4.Size = new Size(747, 50);
            panel4.TabIndex = 2;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Enabled = false;
            label4.Location = new Point(12, 16);
            label4.Name = "label4";
            label4.Size = new Size(84, 20);
            label4.TabIndex = 0;
            label4.Text = "Mã đặt chỗ";
            // 
            // panel3
            // 
            panel3.Controls.Add(button2);
            panel3.Controls.Add(label3);
            panel3.Controls.Add(txtMaThietBi);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(3, 59);
            panel3.Name = "panel3";
            panel3.Size = new Size(747, 50);
            panel3.TabIndex = 1;
            // 
            // button2
            // 
            button2.BackColor = Color.DodgerBlue;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.ForeColor = SystemColors.ButtonFace;
            button2.Location = new Point(591, 13);
            button2.Name = "button2";
            button2.Size = new Size(94, 30);
            button2.TabIndex = 2;
            button2.Text = "Quét mã";
            button2.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 16);
            label3.Name = "label3";
            label3.Size = new Size(81, 20);
            label3.TabIndex = 0;
            label3.Text = "Mã thiết bị";
            // 
            // txtMaThietBi
            // 
            txtMaThietBi.Location = new Point(150, 13);
            txtMaThietBi.Name = "txtMaThietBi";
            txtMaThietBi.Size = new Size(417, 27);
            txtMaThietBi.TabIndex = 1;
            // 
            // panel2
            // 
            panel2.Controls.Add(button1);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(txtMaThanhVien);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(3, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(747, 50);
            panel2.TabIndex = 0;
            // 
            // button1
            // 
            button1.BackColor = Color.DodgerBlue;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = SystemColors.ButtonFace;
            button1.Location = new Point(591, 13);
            button1.Name = "button1";
            button1.Size = new Size(94, 30);
            button1.TabIndex = 2;
            button1.Text = "Quét mã";
            button1.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 16);
            label2.Name = "label2";
            label2.Size = new Size(102, 20);
            label2.TabIndex = 0;
            label2.Text = "Mã thành viên";
            // 
            // txtMaThanhVien
            // 
            txtMaThanhVien.Location = new Point(150, 13);
            txtMaThanhVien.Name = "txtMaThanhVien";
            txtMaThanhVien.Size = new Size(417, 27);
            txtMaThanhVien.TabIndex = 1;
            // 
            // gridViewPhieuDatMuon
            // 
            gridViewPhieuDatMuon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridViewPhieuDatMuon.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridViewPhieuDatMuon.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2, Column3, Column4 });
            gridViewPhieuDatMuon.Location = new Point(106, 335);
            gridViewPhieuDatMuon.Name = "gridViewPhieuDatMuon";
            gridViewPhieuDatMuon.RowHeadersWidth = 51;
            gridViewPhieuDatMuon.Size = new Size(908, 364);
            gridViewPhieuDatMuon.TabIndex = 7;
            // 
            // Column1
            // 
            Column1.FillWeight = 50F;
            Column1.HeaderText = "ID";
            Column1.MinimumWidth = 6;
            Column1.Name = "Column1";
            // 
            // Column2
            // 
            Column2.HeaderText = "Thành viên";
            Column2.MinimumWidth = 6;
            Column2.Name = "Column2";
            // 
            // Column3
            // 
            Column3.HeaderText = "Thiết bị";
            Column3.MinimumWidth = 6;
            Column3.Name = "Column3";
            // 
            // Column4
            // 
            Column4.HeaderText = "Ngày đặt";
            Column4.MinimumWidth = 6;
            Column4.Name = "Column4";
            // 
            // txtMaDatCho
            // 
            txtMaDatCho.Location = new Point(150, 14);
            txtMaDatCho.Name = "txtMaDatCho";
            txtMaDatCho.Size = new Size(295, 27);
            txtMaDatCho.TabIndex = 1;
            // 
            // cbAutoID
            // 
            cbAutoID.AutoSize = true;
            cbAutoID.Location = new Point(469, 17);
            cbAutoID.Name = "cbAutoID";
            cbAutoID.Size = new Size(126, 24);
            cbAutoID.TabIndex = 2;
            cbAutoID.Text = "Auto generate";
            cbAutoID.UseVisualStyleBackColor = true;
            // 
            // QLDatMuon
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            Controls.Add(panel1);
            Controls.Add(tableLayoutPanel1);
            Name = "QLDatMuon";
            Size = new Size(1100, 800);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            panel1.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trackBarSoNgayMuon).EndInit();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gridViewPhieuDatMuon).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel1;
        private Button btnReset;
        private Button btnTaoVaDuyet;
        private TableLayoutPanel tableLayoutPanel2;
        private Panel panel5;
        private TrackBar trackBarSoNgayMuon;
        private Label label5;
        private Panel panel4;
        private Label label4;
        private Panel panel3;
        private Button button2;
        private Label label3;
        private TextBox txtMaThietBi;
        private Panel panel2;
        private Button button1;
        private Label label2;
        private TextBox txtMaThanhVien;
        private Button button5;
        private Button button7;
        private Button button6;
        private DataGridView gridViewPhieuDatMuon;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private CheckBox cbAutoID;
        private TextBox txtMaDatCho;
    }
}
