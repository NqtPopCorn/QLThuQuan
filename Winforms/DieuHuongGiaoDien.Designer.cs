namespace QLThuQuan.Winforms
{
    partial class DieuHuongGiaoDien
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
            tableLayoutPanel1 = new TableLayoutPanel();
            label1 = new Label();
            tableLayoutPanel2 = new TableLayoutPanel();
            btnWeb = new Button();
            btnCheckIns = new Button();
            btnAdmin = new Button();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 80F));
            tableLayoutPanel1.Size = new Size(800, 450);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Segoe UI", 27.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(794, 90);
            label1.TabIndex = 0;
            label1.Text = " Chọn Giao Diện Hệ Thống";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(btnWeb, 0, 1);
            tableLayoutPanel2.Controls.Add(btnCheckIns, 1, 0);
            tableLayoutPanel2.Controls.Add(btnAdmin, 0, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(3, 93);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Size = new Size(794, 354);
            tableLayoutPanel2.TabIndex = 1;
            // 
            // btnWeb
            // 
            btnWeb.BackColor = Color.Khaki;
            btnWeb.Dock = DockStyle.Fill;
            btnWeb.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            btnWeb.Location = new Point(3, 180);
            btnWeb.Name = "btnWeb";
            btnWeb.Size = new Size(391, 171);
            btnWeb.TabIndex = 2;
            btnWeb.Text = "GIao Diện Web";
            btnWeb.UseVisualStyleBackColor = false;
            btnWeb.Click += btnWeb_Click;
            // 
            // btnCheckIns
            // 
            btnCheckIns.BackColor = SystemColors.ActiveCaption;
            btnCheckIns.Dock = DockStyle.Fill;
            btnCheckIns.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            btnCheckIns.Location = new Point(400, 3);
            btnCheckIns.Name = "btnCheckIns";
            btnCheckIns.Size = new Size(391, 171);
            btnCheckIns.TabIndex = 1;
            btnCheckIns.Text = "GIao Diện CheckIns";
            btnCheckIns.UseVisualStyleBackColor = false;
            btnCheckIns.Click += btnCheckIns_Click;
            // 
            // btnAdmin
            // 
            btnAdmin.BackColor = Color.FromArgb(128, 255, 128);
            btnAdmin.Dock = DockStyle.Fill;
            btnAdmin.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            btnAdmin.Location = new Point(3, 3);
            btnAdmin.Name = "btnAdmin";
            btnAdmin.Size = new Size(391, 171);
            btnAdmin.TabIndex = 0;
            btnAdmin.Text = "GIao Diện Admin";
            btnAdmin.UseVisualStyleBackColor = false;
            btnAdmin.Click += btnAdmin_Click;
            // 
            // DieuHuongGiaoDien
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tableLayoutPanel1);
            Name = "DieuHuongGiaoDien";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "DieuHuongGiaoDien";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label label1;
        private TableLayoutPanel tableLayoutPanel2;
        private Button btnWeb;
        private Button btnCheckIns;
        private Button btnAdmin;
    }
}