namespace QLThuQuan.Winforms.Component.ThietBi
{
    partial class EditDeviceDialog
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
            label1 = new Label();
            txtName = new TextBox();
            txtDescription = new TextBox();
            label2 = new Label();
            openFileDialog1 = new OpenFileDialog();
            lblImagePath = new Label();
            btnChooseImage = new Button();
            picBoxImage = new PictureBox();
            btnXacNhan = new Button();
            btnCancel = new Button();
            panel1 = new Panel();
            cbTrangThai = new ComboBox();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)picBoxImage).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(34, 27);
            label1.Name = "label1";
            label1.Size = new Size(89, 20);
            label1.TabIndex = 0;
            label1.Text = "Tên thiết bị*";
            // 
            // txtName
            // 
            txtName.Location = new Point(196, 24);
            txtName.Name = "txtName";
            txtName.Size = new Size(272, 27);
            txtName.TabIndex = 1;
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(196, 74);
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(272, 27);
            txtDescription.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(34, 81);
            label2.Name = "label2";
            label2.Size = new Size(48, 20);
            label2.TabIndex = 3;
            label2.Text = "Mô tả";
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // lblImagePath
            // 
            lblImagePath.AutoSize = true;
            lblImagePath.Location = new Point(34, 181);
            lblImagePath.Name = "lblImagePath";
            lblImagePath.Size = new Size(134, 20);
            lblImagePath.TabIndex = 4;
            lblImagePath.Text = "Vui lòng chọn ảnh*";
            // 
            // btnChooseImage
            // 
            btnChooseImage.Location = new Point(34, 217);
            btnChooseImage.Name = "btnChooseImage";
            btnChooseImage.Size = new Size(94, 29);
            btnChooseImage.TabIndex = 5;
            btnChooseImage.Text = "Chọn";
            btnChooseImage.UseVisualStyleBackColor = true;
            btnChooseImage.Click += btnChooseImage_Click;
            // 
            // picBoxImage
            // 
            picBoxImage.Image = Properties.Resources._404;
            picBoxImage.Location = new Point(0, 0);
            picBoxImage.Name = "picBoxImage";
            picBoxImage.Size = new Size(368, 278);
            picBoxImage.SizeMode = PictureBoxSizeMode.AutoSize;
            picBoxImage.TabIndex = 6;
            picBoxImage.TabStop = false;
            // 
            // btnXacNhan
            // 
            btnXacNhan.BackColor = Color.Blue;
            btnXacNhan.ForeColor = SystemColors.ButtonHighlight;
            btnXacNhan.Location = new Point(382, 409);
            btnXacNhan.Name = "btnXacNhan";
            btnXacNhan.Size = new Size(94, 32);
            btnXacNhan.TabIndex = 7;
            btnXacNhan.Text = "Xác nhận";
            btnXacNhan.UseVisualStyleBackColor = false;
            btnXacNhan.Click += btnXacNhan_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = SystemColors.ControlLight;
            btnCancel.Location = new Point(271, 409);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(94, 32);
            btnCancel.TabIndex = 8;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // panel1
            // 
            panel1.AutoScroll = true;
            panel1.Controls.Add(picBoxImage);
            panel1.Location = new Point(203, 181);
            panel1.Name = "panel1";
            panel1.Size = new Size(273, 215);
            panel1.TabIndex = 9;
            // 
            // cbTrangThai
            // 
            cbTrangThai.FormattingEnabled = true;
            cbTrangThai.Items.AddRange(new object[] { "available", "in_use", "maintainance" });
            cbTrangThai.Location = new Point(196, 124);
            cbTrangThai.Name = "cbTrangThai";
            cbTrangThai.Size = new Size(272, 28);
            cbTrangThai.TabIndex = 10;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(34, 127);
            label3.Name = "label3";
            label3.Size = new Size(75, 20);
            label3.TabIndex = 11;
            label3.Text = "Trạng thái";
            // 
            // EditDeviceDialog
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(517, 457);
            Controls.Add(label3);
            Controls.Add(cbTrangThai);
            Controls.Add(panel1);
            Controls.Add(btnCancel);
            Controls.Add(btnXacNhan);
            Controls.Add(btnChooseImage);
            Controls.Add(lblImagePath);
            Controls.Add(label2);
            Controls.Add(txtDescription);
            Controls.Add(txtName);
            Controls.Add(label1);
            Name = "EditDeviceDialog";
            Text = "EditDeviceDialog";
            ((System.ComponentModel.ISupportInitialize)picBoxImage).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtName;
        private TextBox txtDescription;
        private Label label2;
        private OpenFileDialog openFileDialog1;
        private Label lblImagePath;
        private Button btnChooseImage;
        private PictureBox picBoxImage;
        private Button btnXacNhan;
        private Button btnCancel;
        private Panel panel1;
        private ComboBox cbTrangThai;
        private Label label3;
    }
}