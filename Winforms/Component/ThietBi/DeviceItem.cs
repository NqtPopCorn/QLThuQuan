using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;

using QLThuQuan.Data.Models;

namespace QLThuQuan.Winforms.Components.ThietBi
{
    public partial class DeviceItem : UserControl
    {
        public DeviceItem()
        {
            InitializeComponent();
        }

        public DeviceItem(Device device)
        {
            InitializeComponent();
            lblName.Text = "Tên thiết bị: "+device.Name;
            lblDeviceId.Text = "Mã thiết bị: " + device.Id.ToString();
            lblStatus.Text = "Trạng thái: "+device.Status;
            
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {

        }
    }
}
