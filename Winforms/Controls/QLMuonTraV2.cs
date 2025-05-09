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
using QLThuQuan.Winforms.Helpers;

namespace QLThuQuan.Winforms.Controls
{
    public partial class QLMuonTraV2 : UserControl
    {
        private IUserService _userService;
        private IDeviceService _deviceService;
        private IReservationService _reservationService;
        private IBorrowService _borrowService;
        //Muon
        private Device Device;
        private User User;
        private Reservation Reservation;
        //Tra
        private Device DeviceTra;
        private User UserTra;
        private BorrowRecord BorrowRecordTra;

        public QLMuonTraV2(IUserService userService, IDeviceService deviceService, IReservationService reservationService, IBorrowService borrowService)
        {
            _userService = userService;
            _deviceService = deviceService;
            _reservationService = reservationService;
            _borrowService = borrowService;
            InitializeComponent();

        }

        public class BorrowRecordDto
        {
            public int Id { get; set; }
            public string UserName { get; set; }
            public string DeviceName { get; set; }
            public DateTime BorrowedAt { get; set; }
            public DateTime DueAt { get; set; }
            public string Status { get; set; }
        }

        private async void btnQuetMaThanhVien_Click(object sender, EventArgs e)
        {
            using (ImageScanDialog dialog = new ImageScanDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    string email = ParseCodeHelper.ParseUserEmail(dialog.DecodedValue);
                    User user = await KiemTraThanhVien(email);
                    ShowUserMuon(user);
                }
            }
        }

        private void ShowUserMuon(User user)
        {
            if (user == null) return;
            this.User = user;
            txtMaThanhVien.Text = user.Id + "";
            lblTenThanhVien.Text = user.FirstName + " " + user.LastName;
        }

        private async Task<User> KiemTraThanhVien(string uniqueKey, bool isEmail = true)
        {
            if (string.IsNullOrEmpty(uniqueKey))
            {
                MessageBox.Show("Mã không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            User user = null;
            if (isEmail)
            {
                user = await _userService.GetUserByEmailAsync(uniqueKey);
            }
            else
            {
                user = await _userService.GetUserByIdAsync(int.Parse(uniqueKey));
            }
            if (user == null)
            {
                MessageBox.Show("Người dùng không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            // Set the text of the TextBox to the email
            //txtMaThanhVien.Text = user.Id + "";
            //lblTenThanhVien.Text = user.FirstName + " " + user.LastName;

            //this.User = user;
            return user;
        }

        private async void btnQuetMaThietBi_Click(object sender, EventArgs e)
        {
            using (ImageScanDialog dialog = new ImageScanDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    int deviceId = ParseCodeHelper.ParseDeviceId(dialog.DecodedValue);
                    Device device = await KiemTraThietBi(deviceId);
                    ShowDeviceMuon(device);
                }
            }
        }

        private async Task<Device> KiemTraThietBi(int deviceId)
        {
            if (deviceId == -1)
            {
                MessageBox.Show("Mã không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            Device device = await _deviceService.GetByIdAsync(deviceId);
            if (device == null)
            {
                MessageBox.Show("Thiết bị không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }



            return device;
        }

        private void ShowDeviceMuon(Device device)
        {
            if (device == null) return;
            // Set the text of the TextBox to the device ID
            txtMaThietBi.Text = device.Id + "";
            lblTenThietBi.Text = device.Name;
            SetImageThietBi(device.ImagePath, pbThietBi);

            this.Device = device;
        }

        private void SetImageThietBi(string imagePath, PictureBox pbThietBi)
        {
            if (string.IsNullOrEmpty(imagePath))
            {
                pbThietBi.Image = null;
                return;
            }

            string absolutePath = SaveImageHelper.GetImageAbsolutePath(imagePath);
            if (File.Exists(absolutePath))
            {
                pbThietBi.Image = Image.FromFile(absolutePath);
                pbThietBi.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else
            {
                pbThietBi.Image = null;
            }
        }

        private async void btnKiemTraMuon_Click(object sender, EventArgs e)
        {
            if (User == null)
            {
                User user = await KiemTraThanhVien(txtMaThanhVien.Text, false);
                if (user == null) return;
                ShowUserMuon(user);
            }
            if (Device == null)
            {
                if (string.IsNullOrEmpty(txtMaThietBi.Text))
                {
                    MessageBox.Show("Vui lòng nhập mã thiết bị", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                Device device = await KiemTraThietBi(int.Parse(txtMaThietBi.Text));
                if (device == null) return;
                ShowDeviceMuon(device);
            }


            try
            {
                Reservation reservation = await _reservationService.KiemTraPhieuMuonAsync(int.Parse(txtMaThanhVien.Text), int.Parse(txtMaThietBi.Text));
                // show reservation info
                txtMaDatMuon.Text = reservation.Id.ToString();
                txtThanhVienDatMuon.Text = reservation.User.FirstName + " " + reservation.User.LastName;
                txtThietBiDatMuon.Text = reservation.Device.Name;
                txtNgayHenMuon.Text = reservation.ExpectBorrowAt.ToString("dd/MM/yyyy");
                txtNgayHenTra.Text = reservation.ExpectReturnAt.ToString("dd/MM/yyyy");
                txtNgayDatMuon.Text = reservation.ReservationAt.ToString("dd/MM/yyyy");
                txtTrangThaiDatMuon.Text = reservation.Status;
                this.Reservation = reservation;

                MessageBox.Show("Kiểm tra phiếu mượn thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi kiểm tra phiếu mượn: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private async void btnChoMuon_Click(object sender, EventArgs e)
        {
            if (Reservation == null)
            {
                MessageBox.Show("Vui lòng kiểm tra phiếu mượn trước", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            await _borrowService.ChoMuonThietBi(Reservation);
            MessageBox.Show("Cho mượn thiết bị thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            // Reset form
            btnReset_Click(sender, e);
        }

        private void txtMaThanhVien_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Chỉ cho phép số và phím điều khiển (như Backspace)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtMaThanhVien.Text = "0";
            txtMaThietBi.Text = "0";
            lblTenThanhVien.Text = "";
            lblTenThietBi.Text = "";
            pbThietBi.Image = null;
            this.Device = null;
            this.User = null;
            this.Reservation = null;

            txtMaDatMuon.Clear();
            txtThanhVienDatMuon.Clear();
            txtThietBiDatMuon.Clear();
            txtNgayHenMuon.Clear();
            txtNgayHenTra.Clear();
            txtNgayDatMuon.Clear();
            txtTrangThaiDatMuon.Clear();
        }

        private async void btnQuetMaThanhVienTra_Click(object sender, EventArgs e)
        {
            using (ImageScanDialog dialog = new ImageScanDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    string email = ParseCodeHelper.ParseUserEmail(dialog.DecodedValue);
                    User user = await KiemTraThanhVien(email);
                    ShowUserTra(user);
                }
            }
        }

        private void ShowUserTra(User user)
        {
            if (user == null) return;
            this.UserTra = user;
            txtMaThanhVienTra.Text = user.Id + "";
            lblTenThanhVienTra.Text = user.FirstName + " " + user.LastName;
        }

        private void ShowDeviceTra(Device device)
        {
            if (device == null) return;
            // Set the text of the TextBox to the device ID
            txtMaThietBiTra.Text = device.Id + "";
            lblTenThietBiTra.Text = device.Name;
            SetImageThietBi(device.ImagePath, pbAnhThietBiTra);
            this.DeviceTra = device;
        }

        private async void btnQuetMaThietBiTra_Click(object sender, EventArgs e)
        {
            using (ImageScanDialog dialog = new ImageScanDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    int deviceId = ParseCodeHelper.ParseDeviceId(dialog.DecodedValue);
                    Device device = await KiemTraThietBi(deviceId);
                    ShowDeviceTra(device);
                }
            }
        }

        private async void btnKiemTraPhieuMuon_Click(object sender, EventArgs e)
        {
            if (UserTra == null)
            {
                User user = await KiemTraThanhVien(txtMaThanhVienTra.Text, false);
                if (user == null) return;
                ShowUserTra(user);
            }
            if (DeviceTra == null)
            {
                if (string.IsNullOrEmpty(txtMaThietBiTra.Text))
                {
                    MessageBox.Show("Vui lòng nhập mã thiết bị", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                Device device = await KiemTraThietBi(int.Parse(txtMaThietBiTra.Text));
                if (device == null) return;
                ShowDeviceTra(device);
            }

            //tim phieu muon voi userId, deviceId va status = "Đang mượn"
            BorrowRecord borrowRecord = await _borrowService.FindBorrowedRecordAsync(UserTra.Id, DeviceTra.Id);

            if (borrowRecord == null)
            {
                MessageBox.Show("Không tìm thấy phiếu mượn nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // show borrow record info
            txtMaPhieuMuon.Text = borrowRecord.Id.ToString();
            txtThanhVienTra.Text = borrowRecord.User.FirstName + " " + borrowRecord.User.LastName;
            txtThietBiTra.Text = borrowRecord.Device.Name;
            txtNgayMuon.Text = borrowRecord.BorrowedAt.ToString("dd/MM/yyyy");
            txtNgayHetHan.Text = borrowRecord.DueAt.ToString("dd/MM/yyyy");
            txtTrangThaiMuon.Text = borrowRecord.Status;
            this.BorrowRecordTra = borrowRecord;

        }

        private async void btnTraThietBi_Click(object sender, EventArgs e)
        {
            if (BorrowRecordTra == null)
            {
                MessageBox.Show("Vui lòng kiểm tra phiếu mượn trước", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            bool isSuccess = await _borrowService.TraThietBi(BorrowRecordTra);
            if (isSuccess)
            {
                MessageBox.Show("Trả thiết bị thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Reset form
                btnResetTra_Click(sender, e);
            }
            else
            {
                MessageBox.Show("Trả thiết bị thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnResetTra_Click(object sender, EventArgs e)
        {
            txtMaThanhVienTra.Text = "0";
            txtMaThietBiTra.Text = "0";
            lblTenThanhVienTra.Text = "";
            lblTenThietBiTra.Text = "";
            pbAnhThietBiTra.Image = null;
            this.DeviceTra = null;
            this.UserTra = null;
            this.BorrowRecordTra = null;

            txtMaPhieuMuon.Clear();
            txtThanhVienTra.Clear();
            txtThietBiTra.Clear();
            txtNgayMuon.Clear();
            txtNgayHetHan.Clear();
            txtTrangThaiMuon.Clear();
        }

        private void btnTimPhieuMuon_Click(object sender, EventArgs e)
        {
            string keyword = txtSearchPhieuMuon.Text;
            string status = cbTrangThaiMuon.SelectedItem?.ToString();
            if (status == "Tất cả")
            {
                status = "";
            }
            FilterGridView(keyword, status);
        }

        private async void QLMuonTraV2_Load(object sender, EventArgs e)
        {
            var borrowRecords = await _borrowService.GetAllAsync();
            List<BorrowRecordDto> dtos = ConvertToDto(borrowRecords);
            RenderTablePhieuMuon(dtos);
        }

        private List<BorrowRecordDto> ConvertToDto(List<BorrowRecord> borrowRecords)
        {
            List<BorrowRecordDto> dtos = new List<BorrowRecordDto>();
            foreach (var record in borrowRecords)
            {
                dtos.Add(new BorrowRecordDto
                {
                    Id = record.Id,
                    UserName = record.User.FirstName + " " + record.User.LastName,
                    DeviceName = record.Device.Name,
                    BorrowedAt = record.BorrowedAt,
                    DueAt = record.DueAt,
                    Status = record.Status
                });
            }
            return dtos;
        }

        private void FilterGridView(string keyword, string status)
        {
            keyword = keyword?.Trim().ToLower() ?? "";
            status = status?.Trim().ToLower() ?? "";

            foreach (DataGridViewRow row in gridViewPhieuMuon.Rows)
            {
                if (row.IsNewRow) continue;

                string userName = row.Cells["UserName"].Value?.ToString().ToLower() ?? "";
                string deviceName = row.Cells["DeviceName"].Value?.ToString().ToLower() ?? "";
                string recordStatus = row.Cells["Status"].Value?.ToString().ToLower() ?? "";

                bool matchesKeyword = string.IsNullOrEmpty(keyword) || userName.Contains(keyword) || deviceName.Contains(keyword);
                bool matchesStatus = string.IsNullOrEmpty(status) || recordStatus == status;

                row.Visible = matchesKeyword && matchesStatus;
            }
        }


        private void RenderTablePhieuMuon(List<BorrowRecordDto> borrowRecords)
        {
            // Clear existing rows
            gridViewPhieuMuon.Rows.Clear();
            // Add new rows
            foreach (var record in borrowRecords)
            {
                gridViewPhieuMuon.Rows.Add(record.Id, record.UserName, record.DeviceName, record.BorrowedAt.ToString("dd/MM/yyyy"), record.DueAt.ToString("dd/MM/yyyy"), record.Status);
            }
        }

        private async void btnRefreshPhieuMuon_Click(object sender, EventArgs e)
        {
            var borrowRecords = await _borrowService.GetAllAsync();
            List<BorrowRecordDto> dtos = ConvertToDto(borrowRecords);
            RenderTablePhieuMuon(dtos);
        }
    }
}
