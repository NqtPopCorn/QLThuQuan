namespace QL_ThuQuan
{
    partial class UCViPham
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
            button11 = new Button();
            txtSearch = new TextBox();
            groupBox1 = new Panel();
            label1 = new Label();
            panel3 = new Panel();
            button1 = new Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            label2 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            label12 = new Label();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            label4 = new Label();
            groupBox1.SuspendLayout();
            panel3.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // button11
            // 
            button11.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            button11.BackColor = Color.Silver;
            button11.Location = new Point(905, 41);
            button11.Margin = new Padding(3, 4, 3, 4);
            button11.Name = "button11";
            button11.Size = new Size(102, 27);
            button11.TabIndex = 3;
            button11.Text = "Tìm";
            button11.UseVisualStyleBackColor = false;
            // 
            // txtSearch
            // 
            txtSearch.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtSearch.Location = new Point(240, 41);
            txtSearch.Margin = new Padding(3, 4, 3, 4);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(633, 27);
            txtSearch.TabIndex = 1;
            txtSearch.Text = "Tìm Kiếm";
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = SystemColors.ButtonShadow;
            groupBox1.BackgroundImageLayout = ImageLayout.None;
            groupBox1.Controls.Add(txtSearch);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(button11);
            groupBox1.Dock = DockStyle.Top;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1100, 118);
            groupBox1.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.FlatStyle = FlatStyle.Flat;
            label1.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(8, 41);
            label1.Name = "label1";
            label1.Size = new Size(183, 18);
            label1.TabIndex = 0;
            label1.Text = "Quản lý quy tắc và vi phạm";
            // 
            // panel3
            // 
            panel3.Controls.Add(button1);
            panel3.Controls.Add(tableLayoutPanel1);
            panel3.Controls.Add(label4);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(0, 118);
            panel3.Margin = new Padding(3, 4, 3, 4);
            panel3.Name = "panel3";
            panel3.Size = new Size(1100, 682);
            panel3.TabIndex = 12;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            button1.BackColor = Color.LimeGreen;
            button1.Location = new Point(946, 27);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(124, 38);
            button1.TabIndex = 4;
            button1.Text = "Thêm Vi Phạm";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.Outset;
            tableLayoutPanel1.ColumnCount = 5;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.Controls.Add(label2, 0, 0);
            tableLayoutPanel1.Controls.Add(label5, 1, 0);
            tableLayoutPanel1.Controls.Add(label6, 2, 0);
            tableLayoutPanel1.Controls.Add(label7, 0, 1);
            tableLayoutPanel1.Controls.Add(label8, 0, 2);
            tableLayoutPanel1.Controls.Add(label9, 0, 3);
            tableLayoutPanel1.Controls.Add(label10, 0, 4);
            tableLayoutPanel1.Controls.Add(label11, 3, 0);
            tableLayoutPanel1.Controls.Add(label12, 4, 0);
            tableLayoutPanel1.Controls.Add(button3, 4, 1);
            tableLayoutPanel1.Controls.Add(button4, 4, 2);
            tableLayoutPanel1.Controls.Add(button5, 4, 3);
            tableLayoutPanel1.Controls.Add(button6, 4, 4);
            tableLayoutPanel1.Location = new Point(33, 77);
            tableLayoutPanel1.Margin = new Padding(3, 4, 3, 4);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 5;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.Size = new Size(1037, 575);
            tableLayoutPanel1.TabIndex = 3;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.None;
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(60, 49);
            label2.Name = "label2";
            label2.Size = new Size(88, 18);
            label2.TabIndex = 0;
            label2.Text = "Mã Vi Phạm";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.None;
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(254, 49);
            label5.Name = "label5";
            label5.Size = new Size(115, 18);
            label5.TabIndex = 1;
            label5.Text = "Tên Người Dùng";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.None;
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(465, 49);
            label6.Name = "label6";
            label6.Size = new Size(106, 18);
            label6.TabIndex = 2;
            label6.Text = "Lý Do Vi Phạm";
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label7.AutoSize = true;
            label7.Location = new Point(5, 116);
            label7.Name = "label7";
            label7.Size = new Size(199, 112);
            label7.TabIndex = 3;
            label7.Text = "VP01";
            label7.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label8.AutoSize = true;
            label8.Location = new Point(5, 230);
            label8.Name = "label8";
            label8.Size = new Size(199, 112);
            label8.TabIndex = 4;
            label8.Text = "VP02";
            label8.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            label9.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label9.AutoSize = true;
            label9.Location = new Point(5, 344);
            label9.Name = "label9";
            label9.Size = new Size(199, 112);
            label9.TabIndex = 5;
            label9.Text = "VP03";
            label9.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            label10.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label10.AutoSize = true;
            label10.Location = new Point(5, 458);
            label10.Name = "label10";
            label10.Size = new Size(199, 115);
            label10.TabIndex = 6;
            label10.Text = "VP04";
            label10.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            label11.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label11.Location = new Point(626, 2);
            label11.Name = "label11";
            label11.Size = new Size(199, 112);
            label11.TabIndex = 7;
            label11.Text = "Ngày Vi Phạm";
            label11.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            label12.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label12.Location = new Point(833, 2);
            label12.Name = "label12";
            label12.Size = new Size(199, 112);
            label12.TabIndex = 8;
            label12.Text = "Trạng Thái";
            label12.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // button3
            // 
            button3.BackColor = Color.LimeGreen;
            button3.Location = new Point(833, 120);
            button3.Margin = new Padding(3, 4, 3, 4);
            button3.Name = "button3";
            button3.Size = new Size(75, 31);
            button3.TabIndex = 9;
            button3.Text = "Đã xử lý";
            button3.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            button4.BackColor = Color.Red;
            button4.Location = new Point(833, 234);
            button4.Margin = new Padding(3, 4, 3, 4);
            button4.Name = "button4";
            button4.Size = new Size(75, 31);
            button4.TabIndex = 10;
            button4.Text = "Chưa xử lý";
            button4.UseVisualStyleBackColor = false;
            // 
            // button5
            // 
            button5.BackColor = Color.LimeGreen;
            button5.Location = new Point(833, 348);
            button5.Margin = new Padding(3, 4, 3, 4);
            button5.Name = "button5";
            button5.Size = new Size(75, 31);
            button5.TabIndex = 11;
            button5.Text = "Đã xử lý";
            button5.UseVisualStyleBackColor = false;
            // 
            // button6
            // 
            button6.BackColor = Color.Red;
            button6.Location = new Point(833, 462);
            button6.Margin = new Padding(3, 4, 3, 4);
            button6.Name = "button6";
            button6.Size = new Size(75, 31);
            button6.TabIndex = 12;
            button6.Text = "Chưa xử lý";
            button6.UseVisualStyleBackColor = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(33, 29);
            label4.Name = "label4";
            label4.Size = new Size(158, 20);
            label4.TabIndex = 0;
            label4.Text = "Danh sách Vi Phạm";
            // 
            // UCViPham
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel3);
            Controls.Add(groupBox1);
            Name = "UCViPham";
            Size = new Size(1100, 800);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button button11;
        private TextBox txtSearch;
        private Panel groupBox1;
        private Panel panel3;
        private Button button1;
        private TableLayoutPanel tableLayoutPanel1;
        private Label label2;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label11;
        private Label label12;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;
        private Label label4;
        private Label label1;
    }
}
