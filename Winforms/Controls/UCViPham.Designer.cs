namespace QLThuQuan.Winforms.Controls
{
    partial class UCViPham
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
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
            panelHeader = new Panel();
            lblTitle = new Label();
            panelSearch = new Panel();
            btnSearch = new Button();
            txtSearch = new TextBox();
            lblSearch = new Label();
            panelContent = new Panel();
            btnAddViolation = new Button();
            dgvViolations = new DataGridView();
            colId = new DataGridViewTextBoxColumn();
            colUser = new DataGridViewTextBoxColumn();
            colRule = new DataGridViewTextBoxColumn();
            colDescription = new DataGridViewTextBoxColumn();
            colViolationDate = new DataGridViewTextBoxColumn();
            colStatus = new DataGridViewTextBoxColumn();
            colActions = new DataGridViewButtonColumn();
            panelHeader.SuspendLayout();
            panelSearch.SuspendLayout();
            panelContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvViolations).BeginInit();
            SuspendLayout();

            panelHeader.BackColor = Color.FromArgb(240, 240, 240);
            panelHeader.Controls.Add(lblTitle);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(1100, 60);
            panelHeader.TabIndex = 0;
 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.Black;
            lblTitle.Location = new Point(20, 12);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(227, 37);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Quản lý Vi Phạm";

            panelSearch.BackColor = Color.White;
            panelSearch.Controls.Add(btnSearch);
            panelSearch.Controls.Add(txtSearch);
            panelSearch.Controls.Add(lblSearch);
            panelSearch.Dock = DockStyle.Top;
            panelSearch.Location = new Point(0, 60);
            panelSearch.Name = "panelSearch";
            panelSearch.Size = new Size(1100, 70);
            panelSearch.TabIndex = 1;

            btnSearch.BackColor = Color.FromArgb(240, 240, 240);
            btnSearch.FlatAppearance.BorderSize = 0;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.Font = new Font("Segoe UI", 10F);
            btnSearch.ForeColor = Color.Black;
            btnSearch.Location = new Point(500, 20);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(100, 30);
            btnSearch.TabIndex = 2;
            btnSearch.Text = "Tìm kiếm";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += button11_Click;

            txtSearch.BorderStyle = BorderStyle.FixedSingle;
            txtSearch.Font = new Font("Segoe UI", 10F);
            txtSearch.Location = new Point(150, 20);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(330, 30);
            txtSearch.TabIndex = 1;

            lblSearch.AutoSize = true;
            lblSearch.Font = new Font("Segoe UI", 10F);
            lblSearch.Location = new Point(20, 22);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(83, 23);
            lblSearch.TabIndex = 0;
            lblSearch.Text = "Tìm kiếm:";

            btnReload = new Button();
            panelContent.Controls.Add(btnAddViolation);
            panelContent.Controls.Add(btnReload);
            panelContent.Controls.Add(dgvViolations);
            panelContent.Dock = DockStyle.Fill;
            panelContent.Location = new Point(0, 130);
            panelContent.Name = "panelContent";
            panelContent.Padding = new Padding(20);
            panelContent.Size = new Size(1100, 670);
            panelContent.TabIndex = 2;

            btnReload.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnReload.BackColor = Color.FromArgb(23, 162, 184);
            btnReload.FlatAppearance.BorderSize = 0;
            btnReload.FlatStyle = FlatStyle.Flat;
            btnReload.Font = new Font("Segoe UI", 10F);
            btnReload.ForeColor = Color.White;
            btnReload.Location = new Point(750, 20);
            btnReload.Name = "btnReload";
            btnReload.Size = new Size(160, 35);
            btnReload.TabIndex = 2;
            btnReload.Text = "Refresh";
            btnReload.UseVisualStyleBackColor = false;
            btnReload.Click += btnReload_Click;

            btnAddViolation.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAddViolation.BackColor = Color.FromArgb(0, 122, 204);
            btnAddViolation.FlatAppearance.BorderSize = 0;
            btnAddViolation.FlatStyle = FlatStyle.Flat;
            btnAddViolation.Font = new Font("Segoe UI", 10F);
            btnAddViolation.ForeColor = Color.White;
            btnAddViolation.Location = new Point(920, 20);
            btnAddViolation.Name = "btnAddViolation";
            btnAddViolation.Size = new Size(160, 35);
            btnAddViolation.TabIndex = 1;
            btnAddViolation.Text = "Thêm Vi Phạm";
            btnAddViolation.UseVisualStyleBackColor = false;
            btnAddViolation.Click += button1_Click;

            dgvViolations.AllowUserToAddRows = false;
            dgvViolations.AllowUserToDeleteRows = false;
            dgvViolations.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvViolations.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvViolations.BackgroundColor = Color.White;
            dgvViolations.BorderStyle = BorderStyle.None;
            dgvViolations.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvViolations.Columns.AddRange(new DataGridViewColumn[] { colId, colUser, colRule, colDescription, colViolationDate, colStatus, colActions });
            dgvViolations.Location = new Point(20, 70);
            dgvViolations.Name = "dgvViolations";
            dgvViolations.ReadOnly = true;
            dgvViolations.RowHeadersVisible = false;
            dgvViolations.RowHeadersWidth = 51;
            dgvViolations.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvViolations.Size = new Size(1060, 580);
            dgvViolations.TabIndex = 0;

            colId.HeaderText = "ID";
            colId.MinimumWidth = 6;
            colId.Name = "colId";
            colId.ReadOnly = true;

            colUser.HeaderText = "Người dùng";
            colUser.MinimumWidth = 6;
            colUser.Name = "colUser";
            colUser.ReadOnly = true;

            colRule.HeaderText = "Quy tắc";
            colRule.MinimumWidth = 6;
            colRule.Name = "colRule";
            colRule.ReadOnly = true;

            colDescription.HeaderText = "Mô tả";
            colDescription.MinimumWidth = 6;
            colDescription.Name = "colDescription";
            colDescription.ReadOnly = true;

            colViolationDate.HeaderText = "Ngày vi phạm";
            colViolationDate.MinimumWidth = 6;
            colViolationDate.Name = "colViolationDate";
            colViolationDate.ReadOnly = true;

            colStatus.HeaderText = "Trạng thái";
            colStatus.MinimumWidth = 6;
            colStatus.Name = "colStatus";
            colStatus.ReadOnly = true;

            colActions.HeaderText = "Thao tác";
            colActions.MinimumWidth = 6;
            colActions.Name = "colActions";
            colActions.ReadOnly = true;

            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panelContent);
            Controls.Add(panelSearch);
            Controls.Add(panelHeader);
            Name = "UCViPham";
            Size = new Size(1100, 800);
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelSearch.ResumeLayout(false);
            panelSearch.PerformLayout();
            panelContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvViolations).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelHeader;
        private Label lblTitle;
        private Panel panelSearch;
        private Button btnSearch;
        private TextBox txtSearch;
        private Label lblSearch;
        private Panel panelContent;
        private DataGridView dgvViolations;
        private Button btnAddViolation;
        private Button btnReload;
        private DataGridViewTextBoxColumn colId;
        private DataGridViewTextBoxColumn colUser;
        private DataGridViewTextBoxColumn colRule;
        private DataGridViewTextBoxColumn colDescription;
        private DataGridViewTextBoxColumn colViolationDate;
        private DataGridViewTextBoxColumn colStatus;
        private DataGridViewButtonColumn colActions;
    }
}