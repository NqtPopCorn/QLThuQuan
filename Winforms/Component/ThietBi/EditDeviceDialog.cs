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
    public partial class EditDeviceDialog : Form
    {
        public Action<Device> OnConfirm;
        private Device Device;
        private string _imagePath;

        public EditDeviceDialog(Device device)
        {
            InitializeComponent();

            this.Device = device;
            txtName.Text = device.Name;
            txtDescription.Text = device.Description;
            cbTrangThai.Text = device.Status;

            _imagePath = device.ImagePath;
            if( !string.IsNullOrEmpty(_imagePath) )
            {
                //neu ton tao file thi gan vao picBoxImage, khong thi bo qua
                if(File.Exists(_imagePath))
                {
                    picBoxImage.Image = Image.FromFile(_imagePath);
                }
            }

            lblImagePath.Text = _imagePath;
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
            this.Close();
        }

        private async void btnXacNhan_Click(object sender, EventArgs e)
        {
            Device.Name = txtName.Text;
            Device.Description = txtDescription.Text;
            Device.Status = cbTrangThai.Text;
            Device.ImagePath = _imagePath;

            OnConfirm?.Invoke(Device);
            this.DialogResult = DialogResult.OK;
            this.Dispose();
        }
    }
}
