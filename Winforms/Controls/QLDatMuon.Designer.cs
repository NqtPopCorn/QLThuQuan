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
            cbTrangThai = new ComboBox();
            gridViewPhieuDatMuon = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            colTrangThai = new DataGridViewTextBoxColumn();
            btnRefreshTable = new Button();
            btnHuy = new Button();
            btnDuyet = new Button();
            btnTaoVaDuyet = new Button();
            tableLayoutPanel2 = new TableLayoutPanel();
            panel5 = new Panel();
            txtSoNgayMuon = new Label();
            trackBarSoNgayMuon = new TrackBar();
            label5 = new Label();
            panel3 = new Panel();
            btnQuetMaThietBi = new Button();
            label3 = new Label();
            txtMaThietBi = new TextBox();
            panel2 = new Panel();
            btnQuetMaThanhVien = new Button();
            label2 = new Label();
            txtMaThanhVien = new TextBox();
            tableLayoutPanel1.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridViewPhieuDatMuon).BeginInit();
            tableLayoutPanel2.SuspendLayout();
            panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trackBarSoNgayMuon).BeginInit();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
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
            label1.Size = new Size(1094, 40);
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
            tableLayoutPanel1.Size = new Size(1100, 40);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // panel1
            // 
            panel1.AutoSize = true;
            panel1.Controls.Add(cbTrangThai);
            panel1.Controls.Add(gridViewPhieuDatMuon);
            panel1.Controls.Add(btnRefreshTable);
            panel1.Controls.Add(btnHuy);
            panel1.Controls.Add(btnDuyet);
            panel1.Controls.Add(btnTaoVaDuyet);
            panel1.Controls.Add(tableLayoutPanel2);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 40);
            panel1.Name = "panel1";
            panel1.Size = new Size(1100, 760);
            panel1.TabIndex = 2;
            // 
            // cbTrangThai
            // 
            cbTrangThai.FormattingEnabled = true;
            cbTrangThai.Items.AddRange(new object[] { "Tất cả", "pending", "confirmed", "canceled", "borrowed" });
            cbTrangThai.Location = new Point(876, 278);
            cbTrangThai.Name = "cbTrangThai";
            cbTrangThai.Size = new Size(146, 28);
            cbTrangThai.TabIndex = 9;
            cbTrangThai.Text = "pending";
            cbTrangThai.SelectedIndexChanged += cbTrangThai_SelectedIndexChanged;
            // 
            // gridViewPhieuDatMuon
            // 
            gridViewPhieuDatMuon.AllowUserToAddRows = false;
            gridViewPhieuDatMuon.AllowUserToDeleteRows = false;
            gridViewPhieuDatMuon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridViewPhieuDatMuon.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridViewPhieuDatMuon.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2, Column3, Column4, colTrangThai });
            gridViewPhieuDatMuon.Location = new Point(72, 312);
            gridViewPhieuDatMuon.Name = "gridViewPhieuDatMuon";
            gridViewPhieuDatMuon.RowHeadersWidth = 51;
            gridViewPhieuDatMuon.Size = new Size(950, 373);
            gridViewPhieuDatMuon.TabIndex = 7;
            gridViewPhieuDatMuon.CellClick += gridViewPhieuDatMuon_CellClick;
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
            // colTrangThai
            // 
            colTrangThai.HeaderText = "Trạng thái";
            colTrangThai.MinimumWidth = 6;
            colTrangThai.Name = "colTrangThai";
            // 
            // btnRefreshTable
            // 
            btnRefreshTable.BackColor = SystemColors.ActiveBorder;
            btnRefreshTable.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRefreshTable.ForeColor = SystemColors.ButtonFace;
            btnRefreshTable.Location = new Point(349, 703);
            btnRefreshTable.Name = "btnRefreshTable";
            btnRefreshTable.Size = new Size(111, 29);
            btnRefreshTable.TabIndex = 6;
            btnRefreshTable.Text = "Reset";
            btnRefreshTable.UseVisualStyleBackColor = false;
            btnRefreshTable.Click += btnRefreshTable_Click;
            // 
            // btnHuy
            // 
            btnHuy.BackColor = Color.Red;
            btnHuy.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnHuy.ForeColor = SystemColors.ButtonFace;
            btnHuy.Location = new Point(212, 703);
            btnHuy.Name = "btnHuy";
            btnHuy.Size = new Size(94, 29);
            btnHuy.TabIndex = 5;
            btnHuy.Text = "Hủy";
            btnHuy.UseVisualStyleBackColor = false;
            btnHuy.Click += btnHuy_Click;
            // 
            // btnDuyet
            // 
            btnDuyet.BackColor = Color.ForestGreen;
            btnDuyet.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDuyet.ForeColor = SystemColors.ButtonFace;
            btnDuyet.Location = new Point(75, 703);
            btnDuyet.Name = "btnDuyet";
            btnDuyet.Size = new Size(94, 29);
            btnDuyet.TabIndex = 4;
            btnDuyet.Text = "Duyệt";
            btnDuyet.UseVisualStyleBackColor = false;
            btnDuyet.Click += btnDuyet_Click;
            // 
            // btnTaoVaDuyet
            // 
            btnTaoVaDuyet.BackColor = Color.DodgerBlue;
            btnTaoVaDuyet.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnTaoVaDuyet.ForeColor = SystemColors.ButtonFace;
            btnTaoVaDuyet.Location = new Point(72, 241);
            btnTaoVaDuyet.Name = "btnTaoVaDuyet";
            btnTaoVaDuyet.Size = new Size(128, 35);
            btnTaoVaDuyet.TabIndex = 1;
            btnTaoVaDuyet.Text = "Tạo và duyệt";
            btnTaoVaDuyet.UseVisualStyleBackColor = false;
            btnTaoVaDuyet.Click += btnTaoVaDuyet_Click;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Controls.Add(panel5, 0, 2);
            tableLayoutPanel2.Controls.Add(panel3, 0, 1);
            tableLayoutPanel2.Controls.Add(panel2, 0, 0);
            tableLayoutPanel2.Location = new Point(3, 6);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 3;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.Size = new Size(909, 219);
            tableLayoutPanel2.TabIndex = 0;
            // 
            // panel5
            // 
            panel5.Controls.Add(txtSoNgayMuon);
            panel5.Controls.Add(trackBarSoNgayMuon);
            panel5.Controls.Add(label5);
            panel5.Dock = DockStyle.Fill;
            panel5.Location = new Point(3, 147);
            panel5.Name = "panel5";
            panel5.Size = new Size(903, 69);
            panel5.TabIndex = 3;
            // 
            // txtSoNgayMuon
            // 
            txtSoNgayMuon.AutoSize = true;
            txtSoNgayMuon.Location = new Point(418, 49);
            txtSoNgayMuon.Name = "txtSoNgayMuon";
            txtSoNgayMuon.Size = new Size(56, 20);
            txtSoNgayMuon.TabIndex = 2;
            txtSoNgayMuon.Text = "1 Ngày";
            // 
            // trackBarSoNgayMuon
            // 
            trackBarSoNgayMuon.LargeChange = 1;
            trackBarSoNgayMuon.Location = new Point(206, 16);
            trackBarSoNgayMuon.Maximum = 7;
            trackBarSoNgayMuon.Minimum = 1;
            trackBarSoNgayMuon.Name = "trackBarSoNgayMuon";
            trackBarSoNgayMuon.Size = new Size(479, 56);
            trackBarSoNgayMuon.TabIndex = 1;
            trackBarSoNgayMuon.Value = 1;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(81, 16);
            label5.Name = "label5";
            label5.Size = new Size(105, 20);
            label5.TabIndex = 0;
            label5.Text = "Số ngày mượn";
            // 
            // panel3
            // 
            panel3.Controls.Add(btnQuetMaThietBi);
            panel3.Controls.Add(label3);
            panel3.Controls.Add(txtMaThietBi);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(3, 75);
            panel3.Name = "panel3";
            panel3.Size = new Size(903, 66);
            panel3.TabIndex = 1;
            // 
            // btnQuetMaThietBi
            // 
            btnQuetMaThietBi.BackColor = Color.DodgerBlue;
            btnQuetMaThietBi.FlatStyle = FlatStyle.Flat;
            btnQuetMaThietBi.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnQuetMaThietBi.ForeColor = SystemColors.ButtonFace;
            btnQuetMaThietBi.Location = new Point(715, 16);
            btnQuetMaThietBi.Name = "btnQuetMaThietBi";
            btnQuetMaThietBi.Size = new Size(94, 30);
            btnQuetMaThietBi.TabIndex = 2;
            btnQuetMaThietBi.Text = "Quét mã";
            btnQuetMaThietBi.UseVisualStyleBackColor = false;
            btnQuetMaThietBi.Click += btnQuetMaThietBi_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(81, 21);
            label3.Name = "label3";
            label3.Size = new Size(81, 20);
            label3.TabIndex = 0;
            label3.Text = "Mã thiết bị";
            // 
            // txtMaThietBi
            // 
            txtMaThietBi.Location = new Point(206, 18);
            txtMaThietBi.Name = "txtMaThietBi";
            txtMaThietBi.Size = new Size(479, 27);
            txtMaThietBi.TabIndex = 1;
            // 
            // panel2
            // 
            panel2.Controls.Add(btnQuetMaThanhVien);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(txtMaThanhVien);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(3, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(903, 66);
            panel2.TabIndex = 0;
            // 
            // btnQuetMaThanhVien
            // 
            btnQuetMaThanhVien.BackColor = Color.DodgerBlue;
            btnQuetMaThanhVien.FlatStyle = FlatStyle.Flat;
            btnQuetMaThanhVien.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnQuetMaThanhVien.ForeColor = SystemColors.ButtonFace;
            btnQuetMaThanhVien.Location = new Point(715, 16);
            btnQuetMaThanhVien.Name = "btnQuetMaThanhVien";
            btnQuetMaThanhVien.Size = new Size(94, 30);
            btnQuetMaThanhVien.TabIndex = 2;
            btnQuetMaThanhVien.Text = "Quét mã";
            btnQuetMaThanhVien.UseVisualStyleBackColor = false;
            btnQuetMaThanhVien.Click += btnQuetMaThanhVien_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(81, 21);
            label2.Name = "label2";
            label2.Size = new Size(102, 20);
            label2.TabIndex = 0;
            label2.Text = "Mã thành viên";
            // 
            // txtMaThanhVien
            // 
            txtMaThanhVien.Location = new Point(206, 19);
            txtMaThanhVien.Name = "txtMaThanhVien";
            txtMaThanhVien.Size = new Size(479, 27);
            txtMaThanhVien.TabIndex = 1;
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
            ((System.ComponentModel.ISupportInitialize)gridViewPhieuDatMuon).EndInit();
            tableLayoutPanel2.ResumeLayout(false);
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trackBarSoNgayMuon).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel1;
        private Button btnTaoVaDuyet;
        private TableLayoutPanel tableLayoutPanel2;
        private Panel panel5;
        private TrackBar trackBarSoNgayMuon;
        private Label label5;
        private Panel panel3;
        private Button btnQuetMaThietBi;
        private Label label3;
        private TextBox txtMaThietBi;
        private Panel panel2;
        private Button btnQuetMaThanhVien;
        private Label label2;
        private TextBox txtMaThanhVien;
        private Button btnDuyet;
        private Button btnRefreshTable;
        private Button btnHuy;
        private DataGridView gridViewPhieuDatMuon;
        private Label txtSoNgayMuon;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn colTrangThai;
        private ComboBox cbTrangThai;
    }
}
