namespace QLThuQuan.Winforms.Controls
{
    partial class UCUser
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
            flowLayoutPanel1 = new FlowLayoutPanel();
            Search = new Label();
            txtSearch = new TextBox();
            btnEnter = new Button();
            flowLayoutPanel2 = new FlowLayoutPanel();
            btnReset = new Button();
            btnNew = new Button();
            dtgView = new DataGridView();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dtgView).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.AutoSize = true;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 1);
            tableLayoutPanel1.Controls.Add(dtgView, 0, 2);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 80F));
            tableLayoutPanel1.Size = new Size(1238, 840);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(216, 45);
            label1.TabIndex = 0;
            label1.Text = "Quản Lý User";
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(flowLayoutPanel1, 0, 0);
            tableLayoutPanel2.Controls.Add(flowLayoutPanel2, 1, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(3, 87);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new Size(1232, 78);
            tableLayoutPanel2.TabIndex = 1;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(Search);
            flowLayoutPanel1.Controls.Add(txtSearch);
            flowLayoutPanel1.Controls.Add(btnEnter);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.Location = new Point(3, 3);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(610, 72);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // Search
            // 
            Search.AutoSize = true;
            Search.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            Search.Location = new Point(3, 0);
            Search.Name = "Search";
            Search.Size = new Size(70, 25);
            Search.TabIndex = 0;
            Search.Text = "Search";
            Search.Click += label2_Click;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(79, 3);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(429, 29);
            txtSearch.TabIndex = 1;
            // 
            // btnEnter
            // 
            btnEnter.BackColor = Color.Red;
            btnEnter.Font = new Font("Showcard Gothic", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnEnter.ForeColor = SystemColors.ButtonHighlight;
            btnEnter.Location = new Point(514, 3);
            btnEnter.Name = "btnEnter";
            btnEnter.Size = new Size(85, 32);
            btnEnter.TabIndex = 2;
            btnEnter.Text = "Enter";
            btnEnter.UseVisualStyleBackColor = false;
            btnEnter.Click += btnEnter_Click;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Controls.Add(btnReset);
            flowLayoutPanel2.Controls.Add(btnNew);
            flowLayoutPanel2.Dock = DockStyle.Fill;
            flowLayoutPanel2.FlowDirection = FlowDirection.RightToLeft;
            flowLayoutPanel2.Location = new Point(619, 3);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(610, 72);
            flowLayoutPanel2.TabIndex = 1;
            // 
            // btnReset
            // 
            btnReset.BackColor = Color.FromArgb(192, 192, 0);
            btnReset.Font = new Font("Showcard Gothic", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnReset.ForeColor = SystemColors.ButtonHighlight;
            btnReset.Location = new Point(507, 3);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(100, 29);
            btnReset.TabIndex = 0;
            btnReset.Text = "Reset";
            btnReset.UseVisualStyleBackColor = false;
            btnReset.Click += btnReset_Click;
            // 
            // btnNew
            // 
            btnNew.BackColor = Color.FromArgb(0, 192, 0);
            btnNew.Font = new Font("Showcard Gothic", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnNew.ForeColor = SystemColors.ButtonHighlight;
            btnNew.Location = new Point(392, 3);
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(109, 29);
            btnNew.TabIndex = 1;
            btnNew.Text = "New";
            btnNew.UseVisualStyleBackColor = false;
            btnNew.Click += btnNew_Click;
            // 
            // dtgView
            // 
            dtgView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgView.Dock = DockStyle.Fill;
            dtgView.Location = new Point(3, 171);
            dtgView.Name = "dtgView";
            dtgView.Size = new Size(1232, 666);
            dtgView.TabIndex = 2;
            // 
            // UCUser
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel1);
            Name = "UCUser";
            Size = new Size(1238, 840);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            flowLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dtgView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label label1;
        private TableLayoutPanel tableLayoutPanel2;
        private FlowLayoutPanel flowLayoutPanel1;
        private Label Search;
        private TextBox txtSearch;
        private Button btnEnter;
        private FlowLayoutPanel flowLayoutPanel2;
        private Button btnReset;
        private Button btnNew;
        private DataGridView dtgView;
    }
}
