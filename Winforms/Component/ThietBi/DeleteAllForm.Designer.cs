namespace QLThuQuan.Winforms.Component.ThietBi
{
    partial class DeleteAllForm
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
            txtFilter = new TextBox();
            chkIsRegex = new CheckBox();
            btnSearch = new Button();
            btnDeleteAll = new Button();
            lblFilter = new Label();
            dgvDevices = new DataGridView();
            colId = new DataGridViewTextBoxColumn();
            colName = new DataGridViewTextBoxColumn();
            colDescription = new DataGridViewTextBoxColumn();
            colStatus = new DataGridViewTextBoxColumn();
            colImagePath = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dgvDevices).BeginInit();
            SuspendLayout();
            // 
            // txtFilter
            // 
            txtFilter.Location = new Point(114, 27);
            txtFilter.Margin = new Padding(3, 4, 3, 4);
            txtFilter.Name = "txtFilter";
            txtFilter.Size = new Size(285, 27);
            txtFilter.TabIndex = 0;
            // 
            // chkIsRegex
            // 
            chkIsRegex.AutoSize = true;
            chkIsRegex.Location = new Point(114, 67);
            chkIsRegex.Margin = new Padding(3, 4, 3, 4);
            chkIsRegex.Name = "chkIsRegex";
            chkIsRegex.Size = new Size(219, 24);
            chkIsRegex.TabIndex = 1;
            chkIsRegex.Text = "Sử dụng biểu thức chính quy";
            chkIsRegex.UseVisualStyleBackColor = true;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(114, 105);
            btnSearch.Margin = new Padding(3, 4, 3, 4);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(114, 27);
            btnSearch.TabIndex = 2;
            btnSearch.Text = "Tìm";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // btnDeleteAll
            // 
            btnDeleteAll.Location = new Point(503, 51);
            btnDeleteAll.Margin = new Padding(3, 4, 3, 4);
            btnDeleteAll.Name = "btnDeleteAll";
            btnDeleteAll.Size = new Size(160, 40);
            btnDeleteAll.TabIndex = 3;
            btnDeleteAll.Text = "Xóa Tất Cả";
            btnDeleteAll.UseVisualStyleBackColor = true;
            btnDeleteAll.Click += btnDeleteAll_Click;
            // 
            // lblFilter
            // 
            lblFilter.AutoSize = true;
            lblFilter.Location = new Point(23, 31);
            lblFilter.Name = "lblFilter";
            lblFilter.Size = new Size(89, 20);
            lblFilter.TabIndex = 4;
            lblFilter.Text = "Từ khóa lọc:";
            // 
            // dgvDevices
            // 
            dgvDevices.AllowUserToAddRows = false;
            dgvDevices.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDevices.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDevices.Columns.AddRange(new DataGridViewColumn[] { colId, colName, colDescription, colStatus, colImagePath });
            dgvDevices.Location = new Point(23, 160);
            dgvDevices.Margin = new Padding(3, 4, 3, 4);
            dgvDevices.Name = "dgvDevices";
            dgvDevices.ReadOnly = true;
            dgvDevices.RowHeadersWidth = 51;
            dgvDevices.RowTemplate.Height = 25;
            dgvDevices.Size = new Size(640, 333);
            dgvDevices.TabIndex = 5;
            // 
            // colId
            // 
            colId.DataPropertyName = "Id";
            colId.HeaderText = "ID";
            colId.MinimumWidth = 6;
            colId.Name = "colId";
            colId.ReadOnly = true;
            // 
            // colName
            // 
            colName.DataPropertyName = "Name";
            colName.HeaderText = "Tên Thiết Bị";
            colName.MinimumWidth = 6;
            colName.Name = "colName";
            colName.ReadOnly = true;
            // 
            // colDescription
            // 
            colDescription.DataPropertyName = "Description";
            colDescription.HeaderText = "Mô Tả";
            colDescription.MinimumWidth = 6;
            colDescription.Name = "colDescription";
            colDescription.ReadOnly = true;
            // 
            // colStatus
            // 
            colStatus.DataPropertyName = "Status";
            colStatus.HeaderText = "Trạng Thái";
            colStatus.MinimumWidth = 6;
            colStatus.Name = "colStatus";
            colStatus.ReadOnly = true;
            // 
            // colImagePath
            // 
            colImagePath.DataPropertyName = "ImagePath";
            colImagePath.HeaderText = "Đường Dẫn Hình Ảnh";
            colImagePath.MinimumWidth = 6;
            colImagePath.Name = "colImagePath";
            colImagePath.ReadOnly = true;
            // 
            // DeleteAllForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(686, 533);
            Controls.Add(dgvDevices);
            Controls.Add(lblFilter);
            Controls.Add(btnDeleteAll);
            Controls.Add(btnSearch);
            Controls.Add(chkIsRegex);
            Controls.Add(txtFilter);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "DeleteAllForm";
            Text = "Xóa Tất Cả Thiết Bị";
            ((System.ComponentModel.ISupportInitialize)dgvDevices).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox txtFilter;
        private System.Windows.Forms.CheckBox chkIsRegex;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnDeleteAll;
        private System.Windows.Forms.Label lblFilter;
        private System.Windows.Forms.DataGridView dgvDevices;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colImagePath;
    }
}