namespace QLThuQuan.Winforms.Component.ThietBi
{
    partial class AddDeviceDialog
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
            btnAdd = new Button();
            btnCancel = new Button();
            panel1 = new Panel();
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
            txtName.Size = new Size(231, 27);
            txtName.TabIndex = 1;
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(196, 74);
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(231, 27);
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
            lblImagePath.Location = new Point(34, 138);
            lblImagePath.Name = "lblImagePath";
            lblImagePath.Size = new Size(134, 20);
            lblImagePath.TabIndex = 4;
            lblImagePath.Text = "Vui lòng chọn ảnh*";
            // 
            // btnChooseImage
            // 
            btnChooseImage.Location = new Point(34, 174);
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
            // btnAdd
            // 
            btnAdd.BackColor = Color.Blue;
            btnAdd.ForeColor = SystemColors.ButtonHighlight;
            btnAdd.Location = new Point(333, 366);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(94, 32);
            btnAdd.TabIndex = 7;
            btnAdd.Text = "Thêm";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = SystemColors.ControlLight;
            btnCancel.Location = new Point(233, 366);
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
            panel1.Location = new Point(203, 138);
            panel1.Name = "panel1";
            panel1.Size = new Size(224, 215);
            panel1.TabIndex = 9;
            // 
            // AddDeviceDialog
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(465, 410);
            Controls.Add(panel1);
            Controls.Add(btnCancel);
            Controls.Add(btnAdd);
            Controls.Add(btnChooseImage);
            Controls.Add(lblImagePath);
            Controls.Add(label2);
            Controls.Add(txtDescription);
            Controls.Add(txtName);
            Controls.Add(label1);
            Name = "AddDeviceDialog";
            Text = "AddDeviceDialog";
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
        private Button btnAdd;
        private Button btnCancel;
        private Panel panel1;
    }
}