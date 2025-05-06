using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;

using QLThuQuan.Data.Models;
using QLThuQuan.Data.Services;
using QLThuQuan.Winforms.Component.ThietBi;

namespace QLThuQuan.Winforms.Components.ThietBi
{
    public partial class DeviceItem : UserControl
    {
        private IDeviceService _deviceService;
        private Device device;
        public delegate void OnAction(Device device);
        public event OnAction OnSave;

        public DeviceItem()
        {
            InitializeComponent();

        }
        //public DeviceItem(IDeviceService deviceService)
        //{
        //    _deviceService = deviceService;
        //    InitializeComponent();
        //}

        public DeviceItem(Device device, IDeviceService deviceService)
        {
            InitializeComponent();
            this.device = device;
            lblName.Text = "Tên thiết bị: " + device.Name;
            lblDeviceId.Text = "Mã thiết bị: " + device.Id.ToString();
            lblStatus.Text = "Trạng thái: " + device.Status;
            _deviceService = deviceService;

        }

        private void UserControl1_Load(object sender, EventArgs e)
        {

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            var dialog = new EditDeviceDialog(device);
            dialog.OnConfirm += async (updatedDevice) =>
            {
                //save device through service
                device.Name = updatedDevice.Name;
                device.Description = updatedDevice.Description;
                device.Status = updatedDevice.Status;
                device.ImagePath = updatedDevice.ImagePath;
                await _deviceService.UpdateAsync(device);
                MessageBox.Show("Cập nhật thiết bị thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                OnSave?.Invoke(device);
            };
            dialog.ShowDialog();

        }

        private async void btnXoa_Click(object sender, EventArgs e)
        {
            //confirm 
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa thiết bị này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                return;
            }

            await _deviceService.DeleteAsync(device.Id);
            OnSave?.Invoke(device);
        }
    }
}
