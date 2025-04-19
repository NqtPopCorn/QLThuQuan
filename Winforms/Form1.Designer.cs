namespace QL_ThuQuan
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tableLayoutPanel1 = new TableLayoutPanel();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            cardPanel = new Panel();
            userControl11 = new QL_ThuQuan.Controls.UCThietBi();
            tableLayoutPanel1.SuspendLayout();
            cardPanel.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(button1, 0, 1);
            tableLayoutPanel1.Controls.Add(button2, 0, 2);
            tableLayoutPanel1.Controls.Add(button3, 0, 3);
            tableLayoutPanel1.Controls.Add(button4, 0, 4);
            tableLayoutPanel1.Controls.Add(button5, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Left;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 5;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 200F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 80F));
            tableLayoutPanel1.Size = new Size(250, 800);
            tableLayoutPanel1.TabIndex = 0;
            tableLayoutPanel1.Paint += tableLayoutPanel1_Paint;
            // 
            // button1
            // 
            button1.Dock = DockStyle.Fill;
            button1.Location = new Point(3, 203);
            button1.Name = "button1";
            button1.Size = new Size(244, 167);
            button1.TabIndex = 0;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Dock = DockStyle.Fill;
            button2.Location = new Point(3, 376);
            button2.Name = "button2";
            button2.Size = new Size(244, 167);
            button2.TabIndex = 1;
            button2.Text = "button2";
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Dock = DockStyle.Fill;
            button3.Location = new Point(3, 549);
            button3.Name = "button3";
            button3.Size = new Size(244, 167);
            button3.TabIndex = 2;
            button3.Text = "button3";
            button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Dock = DockStyle.Fill;
            button4.Location = new Point(3, 722);
            button4.Name = "button4";
            button4.Size = new Size(244, 75);
            button4.TabIndex = 3;
            button4.Text = "btnDangXuat";
            button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            button5.Dock = DockStyle.Fill;
            button5.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button5.Location = new Point(3, 3);
            button5.Name = "button5";
            button5.Size = new Size(244, 194);
            button5.TabIndex = 4;
            button5.Text = "Info";
            button5.UseVisualStyleBackColor = true;
            // 
            // cardPanel
            // 
            cardPanel.Controls.Add(userControl11);
            cardPanel.Dock = DockStyle.Fill;
            cardPanel.Location = new Point(250, 0);
            cardPanel.Name = "cardPanel";
            cardPanel.Size = new Size(1100, 800);
            cardPanel.TabIndex = 1;
            // 
            // userControl11
            // 
            userControl11.Dock = DockStyle.Fill;
            userControl11.Location = new Point(0, 0);
            userControl11.Name = "userControl11";
            userControl11.Size = new Size(1100, 800);
            userControl11.TabIndex = 0;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1350, 800);
            Controls.Add(cardPanel);
            Controls.Add(tableLayoutPanel1);
            Name = "Form1";
            Text = "Form1";
            tableLayoutPanel1.ResumeLayout(false);
            cardPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Panel cardPanel;
        private Button button5;
        private Controls.UCThietBi userControl11;
    }
}
