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
using QLThuQuan.Data;
using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using QLThuQuan.Winforms.Helpers;

namespace QLThuQuan.Winforms.Component.ThietBi
{
    public partial class AddDeviceDialog : Form
    {
        private IDeviceService _deviceService;
        private string filePath = "";
        private string relativePath = "";

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
                filePath = openFileDialog.FileName;
                relativePath = "/Image/" + openFileDialog.SafeFileName;
                picBoxImage.Image = Image.FromFile(filePath);
                lblImagePath.Text = openFileDialog.SafeFileName;

            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            SaveImageHelper.CopyImage(filePath, relativePath);

            Device device = new Device()
            {
                Name = txtName.Text,
                Description = txtDescription.Text,
                ImagePath = relativePath,
                Status = "available"
            };
            await _deviceService.AddAsync(device);
            MessageBox.Show("Thêm thiết bị thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
