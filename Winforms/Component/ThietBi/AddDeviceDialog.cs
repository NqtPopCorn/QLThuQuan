using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLThuQuan.Data.Models;
using QLThuQuan.Data.Services;

namespace QLThuQuan.Winforms.Component.ThietBi
{
    public partial class AddDeviceDialog : Form
    {
        private IDeviceService _deviceService;
        private string _imagePath;

        public AddDeviceDialog(IDeviceService deviceService)
        {
            _deviceService = deviceService;
            InitializeComponent();
        }

        private void btnChooseImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
            openFileDialog.Title = "Chọn hình ảnh thiết bị";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                picBoxImage.Image = Image.FromFile(filePath);
                _imagePath = filePath;
                lblImagePath.Text = openFileDialog.SafeFileName;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            Device device = new Device()
            {
                Name = txtName.Text,
                Description = txtDescription.Text,
                ImagePath = _imagePath,
                Status = "available"
            };
            await _deviceService.AddAsync(device);
            MessageBox.Show("Thêm thiết bị thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Dispose();
        }
    }
}
