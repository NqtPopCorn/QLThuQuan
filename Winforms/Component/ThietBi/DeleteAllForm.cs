using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLThuQuan.Data.Services;

namespace QLThuQuan.Winforms.Component.ThietBi
{
    public partial class DeleteAllForm : Form
    {
        private readonly IDeviceService _deviceService;
        public DeleteAllForm(IDeviceService deviceService)
        {
            _deviceService = deviceService;
            InitializeComponent();
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            string filter = txtFilter.Text;
            if (string.IsNullOrEmpty(filter))
            {
                MessageBox.Show("Vui lòng nhập từ khóa lọc.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var devices = await _deviceService.FindByKeywordAsync(filter, chkIsRegex.Checked);
                dgvDevices.DataSource = devices;
                MessageBox.Show($"Tìm thấy {devices.Count} thiết bị.", "Kết quả", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (RegexParseException)
            {
                MessageBox.Show("Biểu thức chính quy không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnDeleteAll_Click(object sender, EventArgs e)
        {
            string filter = txtFilter.Text;
            if (string.IsNullOrEmpty(filter))
            {
                MessageBox.Show("Vui lòng nhập từ khóa lọc.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show("Bạn có chắc chắn muốn xóa tất cả thiết bị được lọc?", "Xác nhận xóa",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    var devices = await _deviceService.FindByKeywordAsync(filter, chkIsRegex.Checked);
                    foreach (var device in devices)
                    {
                        await _deviceService.SoftDeleteAsync(device.Id);
                    }
                    dgvDevices.DataSource = null;
                    MessageBox.Show("Đã xóa tất cả thiết bị được lọc.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK; // Đặt lại DialogResult để thông báo thành công
                    Close();
                }
                catch (RegexParseException)
                {
                    MessageBox.Show("Biểu thức chính quy không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi xóa thiết bị: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
