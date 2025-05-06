namespace QLThuQuan.Winforms.Components.ThietBi
{
    partial class DeviceItem
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
            picBoxImage = new PictureBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            lblStatus = new Label();
            lblDeviceId = new Label();
            lblName = new Label();
            btnSua = new Button();
            btnXoa = new Button();
            ((System.ComponentModel.ISupportInitialize)picBoxImage).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // picBoxImage
            // 
            picBoxImage.BorderStyle = BorderStyle.FixedSingle;
            picBoxImage.Image = Properties.Resources._404;
            picBoxImage.InitialImage = null;
            picBoxImage.Location = new Point(17, 15);
            picBoxImage.Name = "picBoxImage";
            picBoxImage.Size = new Size(149, 126);
            picBoxImage.SizeMode = PictureBoxSizeMode.CenterImage;
            picBoxImage.TabIndex = 0;
            picBoxImage.TabStop = false;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(lblStatus, 0, 2);
            tableLayoutPanel1.Controls.Add(lblDeviceId, 0, 1);
            tableLayoutPanel1.Controls.Add(lblName, 0, 0);
            tableLayoutPanel1.Location = new Point(185, 16);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.Size = new Size(369, 125);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Dock = DockStyle.Fill;
            lblStatus.Location = new Point(3, 82);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(363, 43);
            lblStatus.TabIndex = 2;
            lblStatus.Text = "Trạng thái: Available";
            lblStatus.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblDeviceId
            // 
            lblDeviceId.AutoSize = true;
            lblDeviceId.Dock = DockStyle.Fill;
            lblDeviceId.Location = new Point(3, 41);
            lblDeviceId.Name = "lblDeviceId";
            lblDeviceId.Size = new Size(363, 41);
            lblDeviceId.TabIndex = 1;
            lblDeviceId.Text = "Mã thiết bị: DV0001";
            lblDeviceId.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Dock = DockStyle.Fill;
            lblName.Location = new Point(3, 0);
            lblName.Name = "lblName";
            lblName.Size = new Size(363, 41);
            lblName.TabIndex = 0;
            lblName.Text = "Tên thiết bị: Device A";
            lblName.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnSua
            // 
            btnSua.BackColor = Color.Gold;
            btnSua.FlatStyle = FlatStyle.Flat;
            btnSua.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSua.Location = new Point(672, 96);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(94, 29);
            btnSua.TabIndex = 2;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = false;
            btnSua.Click += btnSua_Click;
            // 
            // btnXoa
            // 
            btnXoa.BackColor = Color.IndianRed;
            btnXoa.FlatAppearance.BorderColor = SystemColors.ActiveCaptionText;
            btnXoa.FlatStyle = FlatStyle.Flat;
            btnXoa.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnXoa.ForeColor = SystemColors.ButtonHighlight;
            btnXoa.Location = new Point(807, 96);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(94, 29);
            btnXoa.TabIndex = 3;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = false;
            btnXoa.Click += btnXoa_Click;
            // 
            // DeviceItem
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnXoa);
            Controls.Add(btnSua);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(picBoxImage);
            Name = "DeviceItem";
            Size = new Size(929, 154);
            Load += UserControl1_Load;
            ((System.ComponentModel.ISupportInitialize)picBoxImage).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox picBoxImage;
        private TableLayoutPanel tableLayoutPanel1;
        private Button btnSua;
        private Button btnXoa;
        private Label lblName;
        private Label lblStatus;
        private Label lblDeviceId;
    }
}
