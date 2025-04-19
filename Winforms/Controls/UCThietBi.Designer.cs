namespace QL_ThuQuan.Controls
{
    partial class UCThietBi
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
            panel1 = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            deviceItem4 = new QL_ThuQuan.GUI.ThietBi.DeviceItem();
            deviceItem1 = new QL_ThuQuan.GUI.ThietBi.DeviceItem();
            deviceItem2 = new QL_ThuQuan.GUI.ThietBi.DeviceItem();
            deviceItem3 = new QL_ThuQuan.GUI.ThietBi.DeviceItem();
            textBox1 = new TextBox();
            button1 = new Button();
            button2 = new Button();
            panel1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.AutoScroll = true;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(tableLayoutPanel1);
            panel1.Location = new Point(23, 88);
            panel1.Name = "panel1";
            panel1.Size = new Size(1057, 687);
            panel1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.AutoSize = true;
            tableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.Outset;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(deviceItem4, 0, 3);
            tableLayoutPanel1.Controls.Add(deviceItem1, 0, 0);
            tableLayoutPanel1.Controls.Add(deviceItem2, 0, 1);
            tableLayoutPanel1.Controls.Add(deviceItem3, 0, 2);
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.Size = new Size(1004, 794);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // deviceItem4
            // 
            deviceItem4.Location = new Point(5, 599);
            deviceItem4.Name = "deviceItem4";
            deviceItem4.Size = new Size(994, 190);
            deviceItem4.TabIndex = 3;
            // 
            // deviceItem1
            // 
            deviceItem1.Location = new Point(5, 5);
            deviceItem1.Name = "deviceItem1";
            deviceItem1.Size = new Size(994, 190);
            deviceItem1.TabIndex = 0;
            // 
            // deviceItem2
            // 
            deviceItem2.Location = new Point(5, 203);
            deviceItem2.Name = "deviceItem2";
            deviceItem2.Size = new Size(994, 190);
            deviceItem2.TabIndex = 1;
            // 
            // deviceItem3
            // 
            deviceItem3.Location = new Point(5, 401);
            deviceItem3.Name = "deviceItem3";
            deviceItem3.Size = new Size(994, 190);
            deviceItem3.TabIndex = 2;
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox1.Location = new Point(27, 37);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(358, 30);
            textBox1.TabIndex = 1;
            // 
            // button1
            // 
            button1.BackColor = Color.SpringGreen;
            button1.Location = new Point(388, 33);
            button1.Name = "button1";
            button1.Size = new Size(91, 39);
            button1.TabIndex = 2;
            button1.Text = "Tìm";
            button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            button2.BackColor = Color.DodgerBlue;
            button2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.ForeColor = SystemColors.ButtonFace;
            button2.Location = new Point(967, 33);
            button2.Name = "button2";
            button2.Size = new Size(113, 38);
            button2.TabIndex = 3;
            button2.Text = "Thêm";
            button2.UseVisualStyleBackColor = false;
            // 
            // UCThietBi
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(textBox1);
            Controls.Add(panel1);
            Name = "UCThietBi";
            Size = new Size(1100, 800);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private TableLayoutPanel tableLayoutPanel1;
        private GUI.ThietBi.DeviceItem deviceItem1;
        private GUI.ThietBi.DeviceItem deviceItem2;
        private GUI.ThietBi.DeviceItem deviceItem3;
        private GUI.ThietBi.DeviceItem deviceItem4;
        private TextBox textBox1;
        private Button button1;
        private Button button2;
    }
}
