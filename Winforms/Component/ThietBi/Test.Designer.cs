namespace QL_ThuQuan.GUI.ThietBi
{
    partial class Test
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
            flowLayoutPanel1 = new FlowLayoutPanel();
            userControl11 = new DeviceItem();
            userControl12 = new DeviceItem();
            userControl13 = new DeviceItem();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.Controls.Add(userControl11);
            flowLayoutPanel1.Controls.Add(userControl12);
            flowLayoutPanel1.Controls.Add(userControl13);
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.Location = new Point(29, 81);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(878, 357);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // userControl11
            // 
            userControl11.BorderStyle = BorderStyle.FixedSingle;
            userControl11.Location = new Point(3, 3);
            userControl11.Name = "userControl11";
            userControl11.Size = new Size(823, 159);
            userControl11.TabIndex = 1;
            // 
            // userControl12
            // 
            userControl12.BorderStyle = BorderStyle.FixedSingle;
            userControl12.Location = new Point(3, 168);
            userControl12.Name = "userControl12";
            userControl12.Size = new Size(823, 159);
            userControl12.TabIndex = 2;
            // 
            // userControl13
            // 
            userControl13.BorderStyle = BorderStyle.FixedSingle;
            userControl13.Location = new Point(3, 333);
            userControl13.Name = "userControl13";
            userControl13.Size = new Size(823, 159);
            userControl13.TabIndex = 3;
            // 
            // Test
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(988, 450);
            Controls.Add(flowLayoutPanel1);
            Name = "Test";
            Text = "Test";
            Load += Test_Load;
            flowLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel flowLayoutPanel1;
        private DeviceItem userControl11;
        private DeviceItem userControl12;
        private DeviceItem userControl13;
    }
}