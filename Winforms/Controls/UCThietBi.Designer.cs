namespace QLThuQuan.Winforms.Controls
{
    partial class UCThietBi
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
            panel1 = new Panel();
            tableDevice = new TableLayoutPanel();
            deviceItem4 = new QLThuQuan.Winforms.Components.ThietBi.DeviceItem();
            deviceItem1 = new QLThuQuan.Winforms.Components.ThietBi.DeviceItem();
            deviceItem2 = new QLThuQuan.Winforms.Components.ThietBi.DeviceItem();
            deviceItem3 = new QLThuQuan.Winforms.Components.ThietBi.DeviceItem();
            txtSearch = new TextBox();
            btnTim = new Button();
            btnThem = new Button();
            btnRefresh = new Button();
            panel1.SuspendLayout();
            tableDevice.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.AutoScroll = true;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(tableDevice);
            panel1.Location = new Point(23, 88);
            panel1.Name = "panel1";
            panel1.Size = new Size(1057, 687);
            panel1.TabIndex = 0;
            // 
            // tableDevice
            // 
            tableDevice.AutoSize = true;
            tableDevice.CellBorderStyle = TableLayoutPanelCellBorderStyle.Outset;
            tableDevice.ColumnCount = 1;
            tableDevice.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableDevice.Controls.Add(deviceItem4, 0, 3);
            tableDevice.Controls.Add(deviceItem1, 0, 0);
            tableDevice.Controls.Add(deviceItem2, 0, 1);
            tableDevice.Controls.Add(deviceItem3, 0, 2);
            tableDevice.Location = new Point(0, 0);
            tableDevice.Name = "tableDevice";
            tableDevice.RowCount = 4;
            tableDevice.RowStyles.Add(new RowStyle());
            tableDevice.RowStyles.Add(new RowStyle());
            tableDevice.RowStyles.Add(new RowStyle());
            tableDevice.RowStyles.Add(new RowStyle());
            tableDevice.Size = new Size(1004, 794);
            tableDevice.TabIndex = 0;
            // 
            // deviceItem4
            // 
            deviceItem4.Location = new Point(5, 599);
            deviceItem4.Name = "deviceItem4";
            deviceItem4.Size = new Size(994, 190);
            deviceItem4.TabIndex = 3;
            // 
            // deviceItem1
            // 
            deviceItem1.Location = new Point(5, 5);
            deviceItem1.Name = "deviceItem1";
            deviceItem1.Size = new Size(994, 190);
            deviceItem1.TabIndex = 0;
            // 
            // deviceItem2
            // 
            deviceItem2.Location = new Point(5, 203);
            deviceItem2.Name = "deviceItem2";
            deviceItem2.Size = new Size(994, 190);
            deviceItem2.TabIndex = 1;
            // 
            // deviceItem3
            // 
            deviceItem3.Location = new Point(5, 401);
            deviceItem3.Name = "deviceItem3";
            deviceItem3.Size = new Size(994, 190);
            deviceItem3.TabIndex = 2;
            // 
            // txtSearch
            // 
            txtSearch.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSearch.Location = new Point(27, 37);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(358, 30);
            txtSearch.TabIndex = 1;
            // 
            // btnTim
            // 
            btnTim.BackColor = Color.SpringGreen;
            btnTim.Location = new Point(388, 33);
            btnTim.Name = "btnTim";
            btnTim.Size = new Size(91, 39);
            btnTim.TabIndex = 2;
            btnTim.Text = "Tìm";
            btnTim.UseVisualStyleBackColor = false;
            btnTim.Click += btnTim_Click;
            // 
            // btnThem
            // 
            btnThem.BackColor = Color.DodgerBlue;
            btnThem.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnThem.ForeColor = SystemColors.ButtonFace;
            btnThem.Location = new Point(944, 23);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(136, 49);
            btnThem.TabIndex = 3;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = false;
            btnThem.Click += btnThem_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(485, 33);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(94, 39);
            btnRefresh.TabIndex = 4;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // UCThietBi
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnRefresh);
            Controls.Add(btnThem);
            Controls.Add(btnTim);
            Controls.Add(txtSearch);
            Controls.Add(panel1);
            Name = "UCThietBi";
            Size = new Size(1100, 800);
            Load += UCThietBi_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            tableDevice.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private TableLayoutPanel tableDevice;
        private QLThuQuan.Winforms.Components.ThietBi.DeviceItem deviceItem1;
        private QLThuQuan.Winforms.Components.ThietBi.DeviceItem deviceItem2;
        private QLThuQuan.Winforms.Components.ThietBi.DeviceItem deviceItem3;
        private QLThuQuan.Winforms.Components.ThietBi.DeviceItem deviceItem4;
        private TextBox txtSearch;
        private Button btnTim;
        private Button btnThem;
        private Button btnRefresh;
    }
}
