namespace QLThuQuan.Winforms.Controls
{
    partial class UCThongKe
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
            tableLayoutPanel1 = new TableLayoutPanel();
            label1 = new Label();
            tableLayoutPanel2 = new TableLayoutPanel();
            tableLayoutPanel3 = new TableLayoutPanel();
            label2 = new Label();
            cbLuaChon = new ComboBox();
            btnTaoThongKe = new Button();
            tableLayoutPanel4 = new TableLayoutPanel();
            label3 = new Label();
            mcStartDate = new MonthCalendar();
            tableLayoutPanel5 = new TableLayoutPanel();
            label4 = new Label();
            mcEndDate = new MonthCalendar();
            tbLayoutChartTK = new TableLayoutPanel();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            tableLayoutPanel4.SuspendLayout();
            tableLayoutPanel5.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 1);
            tableLayoutPanel1.Controls.Add(tbLayoutChartTK, 0, 2);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 5F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 65F));
            tableLayoutPanel1.Size = new Size(1100, 800);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(4, 1);
            label1.Name = "label1";
            label1.Size = new Size(202, 39);
            label1.TabIndex = 0;
            label1.Text = "Thống Kê";
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 3;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            tableLayoutPanel2.Controls.Add(tableLayoutPanel3, 0, 0);
            tableLayoutPanel2.Controls.Add(tableLayoutPanel4, 1, 0);
            tableLayoutPanel2.Controls.Add(tableLayoutPanel5, 2, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(4, 44);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 232F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 232F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 232F));
            tableLayoutPanel2.Size = new Size(1092, 232);
            tableLayoutPanel2.TabIndex = 1;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 1;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.Controls.Add(label2, 0, 0);
            tableLayoutPanel3.Controls.Add(cbLuaChon, 0, 1);
            tableLayoutPanel3.Controls.Add(btnTaoThongKe, 0, 2);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(3, 3);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 3;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 60F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel3.Size = new Size(212, 226);
            tableLayoutPanel3.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(3, 0);
            label2.Name = "label2";
            label2.Size = new Size(174, 45);
            label2.TabIndex = 0;
            label2.Text = " Chọn dữ liệu thống kê";
            // 
            // cbLuaChon
            // 
            cbLuaChon.Dock = DockStyle.Top;
            cbLuaChon.FormattingEnabled = true;
            cbLuaChon.Location = new Point(3, 48);
            cbLuaChon.Name = "cbLuaChon";
            cbLuaChon.Size = new Size(206, 28);
            cbLuaChon.TabIndex = 1;
            cbLuaChon.SelectedIndexChanged += cbLuaChon_SelectedIndexChanged;
            // 
            // btnTaoThongKe
            // 
            btnTaoThongKe.BackColor = Color.CornflowerBlue;
            btnTaoThongKe.Dock = DockStyle.Fill;
            btnTaoThongKe.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnTaoThongKe.ForeColor = SystemColors.ButtonHighlight;
            btnTaoThongKe.Location = new Point(3, 183);
            btnTaoThongKe.Name = "btnTaoThongKe";
            btnTaoThongKe.Size = new Size(206, 40);
            btnTaoThongKe.TabIndex = 2;
            btnTaoThongKe.Text = "Tạo Thống Kê";
            btnTaoThongKe.UseVisualStyleBackColor = false;
            btnTaoThongKe.Click += btnTaoThongKe_Click;
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.ColumnCount = 1;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 18F));
            tableLayoutPanel4.Controls.Add(label3, 0, 0);
            tableLayoutPanel4.Controls.Add(mcStartDate, 0, 1);
            tableLayoutPanel4.Dock = DockStyle.Fill;
            tableLayoutPanel4.Location = new Point(221, 3);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 2;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 80F));
            tableLayoutPanel4.Size = new Size(430, 226);
            tableLayoutPanel4.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(3, 0);
            label3.Name = "label3";
            label3.Size = new Size(168, 32);
            label3.TabIndex = 2;
            label3.Text = "Ngày bắt đầu";
            // 
            // mcStartDate
            // 
            mcStartDate.Dock = DockStyle.Fill;
            mcStartDate.Location = new Point(8, 54);
            mcStartDate.Margin = new Padding(8, 9, 8, 9);
            mcStartDate.Name = "mcStartDate";
            mcStartDate.TabIndex = 3;
            // 
            // tableLayoutPanel5
            // 
            tableLayoutPanel5.ColumnCount = 1;
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 18F));
            tableLayoutPanel5.Controls.Add(label4, 0, 0);
            tableLayoutPanel5.Controls.Add(mcEndDate, 0, 1);
            tableLayoutPanel5.Dock = DockStyle.Fill;
            tableLayoutPanel5.Location = new Point(657, 3);
            tableLayoutPanel5.Name = "tableLayoutPanel5";
            tableLayoutPanel5.RowCount = 2;
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 80F));
            tableLayoutPanel5.Size = new Size(432, 226);
            tableLayoutPanel5.TabIndex = 2;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(3, 0);
            label4.Name = "label4";
            label4.Size = new Size(173, 32);
            label4.TabIndex = 3;
            label4.Text = "Ngày kết thúc";
            // 
            // mcEndDate
            // 
            mcEndDate.Dock = DockStyle.Fill;
            mcEndDate.Location = new Point(8, 54);
            mcEndDate.Margin = new Padding(8, 9, 8, 9);
            mcEndDate.Name = "mcEndDate";
            mcEndDate.TabIndex = 4;
            // 
            // tbLayoutChartTK
            // 
            tbLayoutChartTK.ColumnCount = 1;
            tbLayoutChartTK.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tbLayoutChartTK.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 18F));
            tbLayoutChartTK.Dock = DockStyle.Fill;
            tbLayoutChartTK.Location = new Point(4, 283);
            tbLayoutChartTK.Name = "tbLayoutChartTK";
            tbLayoutChartTK.RowCount = 1;
            tbLayoutChartTK.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tbLayoutChartTK.RowStyles.Add(new RowStyle(SizeType.Absolute, 513F));
            tbLayoutChartTK.Size = new Size(1092, 513);
            tbLayoutChartTK.TabIndex = 2;
            // 
            // UCThongKe
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel1);
            Name = "UCThongKe";
            Size = new Size(1100, 800);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel3.PerformLayout();
            tableLayoutPanel4.ResumeLayout(false);
            tableLayoutPanel4.PerformLayout();
            tableLayoutPanel5.ResumeLayout(false);
            tableLayoutPanel5.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label label1;
        private TableLayoutPanel tableLayoutPanel2;
        private TableLayoutPanel tableLayoutPanel3;
        private Label label2;
        private TableLayoutPanel tableLayoutPanel4;
        private TableLayoutPanel tableLayoutPanel5;
        private Label label3;
        private MonthCalendar mcStartDate;
        private Label label4;
        private MonthCalendar mcEndDate;
        private ComboBox cbLuaChon;
        private TableLayoutPanel tbLayoutChartTK;
        private Button btnTaoThongKe;
    }
}
