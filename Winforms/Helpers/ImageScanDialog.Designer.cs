namespace QLThuQuan.Winforms.Helpers
{
    partial class ImageScanDialog
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
            picturePreview = new PictureBox();
            txtDecodedValue = new TextBox();
            btnBrowse = new Button();
            btnStartCamera = new Button();
            btnStopCamera = new Button();
            btnCancel = new Button();
            ((System.ComponentModel.ISupportInitialize)picturePreview).BeginInit();
            SuspendLayout();
            // 
            // picturePreview
            // 
            picturePreview.Location = new Point(182, 73);
            picturePreview.Name = "picturePreview";
            picturePreview.Size = new Size(459, 351);
            picturePreview.TabIndex = 0;
            picturePreview.TabStop = false;
            // 
            // txtDecodedValue
            // 
            txtDecodedValue.Location = new Point(182, 25);
            txtDecodedValue.Name = "txtDecodedValue";
            txtDecodedValue.Size = new Size(459, 27);
            txtDecodedValue.TabIndex = 1;
            txtDecodedValue.TextChanged += txtDecodedValue_TextChanged;
            // 
            // btnBrowse
            // 
            btnBrowse.BackColor = Color.Blue;
            btnBrowse.ForeColor = Color.White;
            btnBrowse.Location = new Point(28, 120);
            btnBrowse.Name = "btnBrowse";
            btnBrowse.Size = new Size(117, 29);
            btnBrowse.TabIndex = 2;
            btnBrowse.Text = "Browse";
            btnBrowse.UseVisualStyleBackColor = false;
            btnBrowse.Click += btnBrowse_Click;
            // 
            // btnStartCamera
            // 
            btnStartCamera.BackColor = Color.ForestGreen;
            btnStartCamera.ForeColor = Color.WhiteSmoke;
            btnStartCamera.Location = new Point(28, 25);
            btnStartCamera.Name = "btnStartCamera";
            btnStartCamera.Size = new Size(117, 29);
            btnStartCamera.TabIndex = 3;
            btnStartCamera.Text = "Start Camera";
            btnStartCamera.UseVisualStyleBackColor = false;
            btnStartCamera.Click += btnStartCamera_Click;
            // 
            // btnStopCamera
            // 
            btnStopCamera.BackColor = Color.Red;
            btnStopCamera.ForeColor = Color.White;
            btnStopCamera.Location = new Point(28, 73);
            btnStopCamera.Name = "btnStopCamera";
            btnStopCamera.Size = new Size(117, 29);
            btnStopCamera.TabIndex = 4;
            btnStopCamera.Text = "Stop Camera";
            btnStopCamera.UseVisualStyleBackColor = false;
            btnStopCamera.Click += btnStopCamera_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = SystemColors.ControlDark;
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(28, 168);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(117, 29);
            btnCancel.TabIndex = 5;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // ImageScanDialog
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(669, 450);
            Controls.Add(btnCancel);
            Controls.Add(btnStopCamera);
            Controls.Add(btnStartCamera);
            Controls.Add(btnBrowse);
            Controls.Add(txtDecodedValue);
            Controls.Add(picturePreview);
            Name = "ImageScanDialog";
            Text = "DemoCodeScanner";
            FormClosing += DemoCodeScanner_FormClosing;
            Load += DemoCodeScanner_Load;
            ((System.ComponentModel.ISupportInitialize)picturePreview).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox picturePreview;
        private TextBox txtDecodedValue;
        private Button btnBrowse;
        private Button btnStartCamera;
        private Button btnStopCamera;
        private Button btnCancel;
    }
}