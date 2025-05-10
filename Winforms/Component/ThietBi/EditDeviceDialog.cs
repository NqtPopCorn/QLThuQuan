using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLThuQuan.Data;
using QLThuQuan.Data.Models;
using QLThuQuan.Data.Services;
using QLThuQuan.Winforms.Helpers;

namespace QLThuQuan.Winforms.Component.ThietBi
{
    public partial class EditDeviceDialog : Form
    {
        public Action<Device> OnConfirm;
        private Device Device;
        private string filePath = "";
        private string relativePath = "";

        public EditDeviceDialog(Device device)
        {
            InitializeComponent();

            this.Device = device;
            txtName.Text = device.Name;
            txtDescription.Text = device.Description;
            cbTrangThai.Text = device.Status;

            relativePath = device.ImagePath;
            filePath = SaveImageHelper.GetImageAbsolutePath(relativePath);
            if ( !string.IsNullOrEmpty(filePath) )
            {
                //neu ton tao file thi gan vao picBoxImage, khong thi bo qua
                if(File.Exists(filePath))
                {
                    picBoxImage.Image = Image.FromFile(filePath);
                }
            }

            lblImagePath.Text = Path.GetFileName(relativePath);
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


        private async void btnXacNhan_Click(object sender, EventArgs e)
        {
            SaveImageHelper.CopyImage(filePath, relativePath);

            Device.Name = txtName.Text;
            Device.Description = txtDescription.Text;
            Device.Status = cbTrangThai.Text;
            Device.ImagePath = relativePath;

            OnConfirm?.Invoke(Device);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
