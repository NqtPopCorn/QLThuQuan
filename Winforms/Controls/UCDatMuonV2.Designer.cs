namespace QLThuQuan.Winforms.Controls
{
    partial class UCDatMuonV2
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            panel1 = new Panel();
            btnCancel = new Button();
            btnDuyet = new Button();
            cbTrangThai = new ComboBox();
            gridViewPhieuDatMuon = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            TenThanhVien = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            Column5 = new DataGridViewTextBoxColumn();
            Column6 = new DataGridViewTextBoxColumn();
            Column7 = new DataGridViewTextBoxColumn();
            btnRefresh = new Button();
            btnTim = new Button();
            txtTim = new TextBox();
            panel2 = new Panel();
            label1 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridViewPhieuDatMuon).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(btnCancel);
            panel1.Controls.Add(btnDuyet);
            panel1.Controls.Add(cbTrangThai);
            panel1.Controls.Add(gridViewPhieuDatMuon);
            panel1.Controls.Add(btnRefresh);
            panel1.Controls.Add(btnTim);
            panel1.Controls.Add(txtTim);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1100, 800);
            panel1.TabIndex = 0;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.Red;
            btnCancel.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancel.ForeColor = SystemColors.ButtonHighlight;
            btnCancel.Location = new Point(972, 188);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(94, 33);
            btnCancel.TabIndex = 7;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnDuyet
            // 
            btnDuyet.BackColor = Color.Lime;
            btnDuyet.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDuyet.ForeColor = SystemColors.ButtonHighlight;
            btnDuyet.Location = new Point(972, 136);
            btnDuyet.Name = "btnDuyet";
            btnDuyet.Size = new Size(94, 33);
            btnDuyet.TabIndex = 6;
            btnDuyet.Text = "Duyệt";
            btnDuyet.UseVisualStyleBackColor = false;
            btnDuyet.Click += btnDuyet_Click;
            // 
            // cbTrangThai
            // 
            cbTrangThai.FormattingEnabled = true;
            cbTrangThai.Items.AddRange(new object[] { "Tất cả", "pending", "confirmed", "canceled", "borrowed" });
            cbTrangThai.Location = new Point(387, 90);
            cbTrangThai.Name = "cbTrangThai";
            cbTrangThai.Size = new Size(151, 28);
            cbTrangThai.TabIndex = 5;
            cbTrangThai.Text = "Tất cả";
            cbTrangThai.SelectedIndexChanged += cbTrangThai_SelectedIndexChanged;
            // 
            // gridViewPhieuDatMuon
            // 
            gridViewPhieuDatMuon.AllowUserToAddRows = false;
            gridViewPhieuDatMuon.AllowUserToDeleteRows = false;
            gridViewPhieuDatMuon.AllowUserToResizeColumns = false;
            gridViewPhieuDatMuon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            gridViewPhieuDatMuon.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            gridViewPhieuDatMuon.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridViewPhieuDatMuon.Columns.AddRange(new DataGridViewColumn[] { Column1, TenThanhVien, Column3, Column4, Column5, Column6, Column7 });
            gridViewPhieuDatMuon.Location = new Point(43, 136);
            gridViewPhieuDatMuon.Name = "gridViewPhieuDatMuon";
            gridViewPhieuDatMuon.RowHeadersWidth = 51;
            gridViewPhieuDatMuon.Size = new Size(904, 629);
            gridViewPhieuDatMuon.TabIndex = 4;
            gridViewPhieuDatMuon.CellClick += gridViewPhieuDatMuon_CellClick;
            // 
            // Column1
            // 
            Column1.FillWeight = 60F;
            Column1.HeaderText = "ID";
            Column1.MinimumWidth = 6;
            Column1.Name = "Column1";
            // 
            // TenThanhVien
            // 
            TenThanhVien.HeaderText = "Thành viên";
            TenThanhVien.MinimumWidth = 6;
            TenThanhVien.Name = "TenThanhVien";
            TenThanhVien.ReadOnly = true;
            // 
            // Column3
            // 
            Column3.HeaderText = "Thiết bị";
            Column3.MinimumWidth = 6;
            Column3.Name = "Column3";
            Column3.ReadOnly = true;
            // 
            // Column4
            // 
            Column4.HeaderText = "Ngày mượn";
            Column4.MinimumWidth = 6;
            Column4.Name = "Column4";
            Column4.ReadOnly = true;
            // 
            // Column5
            // 
            Column5.HeaderText = "Ngày trả";
            Column5.MinimumWidth = 6;
            Column5.Name = "Column5";
            Column5.ReadOnly = true;
            // 
            // Column6
            // 
            Column6.HeaderText = "Ngày đặt";
            Column6.MinimumWidth = 6;
            Column6.Name = "Column6";
            // 
            // Column7
            // 
            Column7.HeaderText = "Trạng thái";
            Column7.MinimumWidth = 6;
            Column7.Name = "Column7";
            Column7.ReadOnly = true;
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(972, 87);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(94, 29);
            btnRefresh.TabIndex = 3;
            btnRefresh.Text = "refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // btnTim
            // 
            btnTim.Location = new Point(544, 89);
            btnTim.Name = "btnTim";
            btnTim.Size = new Size(94, 29);
            btnTim.TabIndex = 2;
            btnTim.Text = "Tìm";
            btnTim.UseVisualStyleBackColor = true;
            btnTim.Click += btnTim_Click;
            // 
            // txtTim
            // 
            txtTim.Location = new Point(43, 90);
            txtTim.Name = "txtTim";
            txtTim.Size = new Size(338, 27);
            txtTim.TabIndex = 1;
            // 
            // panel2
            // 
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(label1);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(1100, 58);
            panel2.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(52, 18);
            label1.Name = "label1";
            label1.Size = new Size(166, 25);
            label1.TabIndex = 0;
            label1.Text = "Quản lý đặt mượn";
            // 
            // UCDatMuonV2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "UCDatMuonV2";
            Size = new Size(1100, 800);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gridViewPhieuDatMuon).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private TextBox txtTim;
        private DataGridView gridViewPhieuDatMuon;
        private Button btnRefresh;
        private Button btnTim;
        private Panel panel2;
        private Label label1;
        private ComboBox cbTrangThai;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn TenThanhVien;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn Column5;
        private DataGridViewTextBoxColumn Column6;
        private DataGridViewTextBoxColumn Column7;
        private Button btnCancel;
        private Button btnDuyet;
    }
}
