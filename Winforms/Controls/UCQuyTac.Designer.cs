namespace QLThuQuan.Winforms.Controls
{
    partial class UCQuyTac
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

        private void InitializeComponent()
        {
            panelHeader = new Panel();
            lblTitle = new Label();
            panelSearch = new Panel();
            btnSearch = new Button();
            txtSearch = new TextBox();
            lblSearch = new Label();
            panelContent = new Panel();
            btnAddRule = new Button();
            dgvRules = new DataGridView();
            colId = new DataGridViewTextBoxColumn();
            colName = new DataGridViewTextBoxColumn();
            colDescription = new DataGridViewTextBoxColumn();
            colCreatedAt = new DataGridViewTextBoxColumn();
            colActions = new DataGridViewButtonColumn();
            panelHeader.SuspendLayout();
            panelSearch.SuspendLayout();
            panelContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRules).BeginInit();
            SuspendLayout();
            panelHeader.BackColor = System.Drawing.Color.FromArgb(240, 240, 240);
            panelHeader.Controls.Add(lblTitle);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(1100, 60);
            panelHeader.TabIndex = 0;

            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitle.ForeColor = Color.Black;
            lblTitle.Location = new Point(20, 12);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(242, 37);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Quản lý Quy Tắc";

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
            btnSearch.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnSearch.ForeColor = Color.Black;
            btnSearch.Location = new Point(500, 20);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(94, 29);
            btnSearch.TabIndex = 2;
            btnSearch.Text = "Tìm kiếm";
            btnSearch.UseVisualStyleBackColor = false;

            txtSearch.BorderStyle = BorderStyle.FixedSingle;
            txtSearch.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtSearch.Location = new Point(150, 20);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(330, 30);
            txtSearch.TabIndex = 1;

            lblSearch.AutoSize = true;
            lblSearch.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblSearch.Location = new Point(20, 22);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(80, 23);
            lblSearch.TabIndex = 0;
            lblSearch.Text = "Tìm kiếm:";

            btnReload = new Button();
            panelContent.Controls.Add(btnAddRule);
            panelContent.Controls.Add(btnReload);
            panelContent.Controls.Add(dgvRules);
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
            btnReload.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnReload.ForeColor = Color.White;
            btnReload.Location = new Point(750, 20);
            btnReload.Name = "btnReload";
            btnReload.Size = new Size(160, 35);
            btnReload.TabIndex = 2;
            btnReload.Text = "Refresh";
            btnReload.UseVisualStyleBackColor = false;
            btnReload.Click += btnReload_Click;

            btnAddRule.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAddRule.BackColor = Color.FromArgb(40, 167, 69);
            btnAddRule.FlatAppearance.BorderSize = 0;
            btnAddRule.FlatStyle = FlatStyle.Flat;
            btnAddRule.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnAddRule.ForeColor = Color.White;
            btnAddRule.Location = new Point(920, 20);
            btnAddRule.Name = "btnAddRule";
            btnAddRule.Size = new Size(160, 35);
            btnAddRule.TabIndex = 1;
            btnAddRule.Text = "Thêm quy tắc mới";
            btnAddRule.UseVisualStyleBackColor = false;

            dgvRules.AllowUserToAddRows = false;
            dgvRules.AllowUserToDeleteRows = false;
            dgvRules.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvRules.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRules.BackgroundColor = Color.White;
            dgvRules.BorderStyle = BorderStyle.None;
            dgvRules.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRules.Columns.AddRange(new DataGridViewColumn[] { colId, colName, colDescription, colCreatedAt, colActions });
            dgvRules.Location = new Point(20, 70);
            dgvRules.Name = "dgvRules";
            dgvRules.ReadOnly = true;
            dgvRules.RowHeadersVisible = false;
            dgvRules.RowHeadersWidth = 51;
            dgvRules.RowTemplate.Height = 29;
            dgvRules.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRules.Size = new Size(1060, 580);
            dgvRules.TabIndex = 0;

            colId.FillWeight = 50F;
            colId.HeaderText = "ID";
            colId.MinimumWidth = 6;
            colId.Name = "colId";
            colId.ReadOnly = true;

            colName.FillWeight = 150F;
            colName.HeaderText = "Tên quy tắc";
            colName.MinimumWidth = 6;
            colName.Name = "colName";
            colName.ReadOnly = true;

            colDescription.FillWeight = 250F;
            colDescription.HeaderText = "Mô tả";
            colDescription.MinimumWidth = 6;
            colDescription.Name = "colDescription";
            colDescription.ReadOnly = true;

            colCreatedAt.FillWeight = 120F;
            colCreatedAt.HeaderText = "Ngày tạo";
            colCreatedAt.MinimumWidth = 6;
            colCreatedAt.Name = "colCreatedAt";
            colCreatedAt.ReadOnly = true;

            colActions.FillWeight = 100F;
            colActions.HeaderText = "Thao tác";
            colActions.MinimumWidth = 6;
            colActions.Name = "colActions";
            colActions.ReadOnly = true;
            colActions.UseColumnTextForButtonValue = false;
            // UCQuyTac
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panelContent);
            Controls.Add(panelSearch);
            Controls.Add(panelHeader);
            Name = "UCQuyTac";
            Size = new Size(1100, 800);
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelSearch.ResumeLayout(false);
            panelSearch.PerformLayout();
            panelContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvRules).EndInit();
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
        private DataGridView dgvRules;
        private Button btnAddRule;
        private Button btnReload;
        private DataGridViewTextBoxColumn colId;
        private DataGridViewTextBoxColumn colName;
        private DataGridViewTextBoxColumn colDescription;
        private DataGridViewTextBoxColumn colCreatedAt;
        private DataGridViewButtonColumn colActions;
    }
}