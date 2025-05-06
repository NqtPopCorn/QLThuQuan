using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLThuQuan.Data.Services;
using QLThuQuan.Data.Models;
using QLThuQuan.Winforms.Helpers;

namespace QLThuQuan.Winforms.Controls
{
    public partial class QLDatMuon : UserControl
    {
        private IReservationService _reservationService;
        private IDeviceService _deviceService;
        //Chua co
        //private IUserService _userService;

        public QLDatMuon(IReservationService reservationService, IDeviceService deviceService)
        {
            _reservationService = reservationService;
            _deviceService = deviceService;
            InitializeComponent();
            trackBarSoNgayMuon.ValueChanged += OnTrackBarChange;
            loadData();
        }

        public void OnTrackBarChange(object sender, EventArgs e)
        {
            int value = trackBarSoNgayMuon.Value;
            txtSoNgayMuon.Text = value.ToString() + " Ngày";
        }

        private async void loadData()
        {
            cbTrangThai.Text = "pending";
            // Load data from the reservation service
            var reservations = await _reservationService.GetByStatusAsync("pending");
            RenderTable(reservations);
        }

        private void RenderTable(List<Reservation> reservations)
        {
            // Clear existing rows
            gridViewPhieuDatMuon.Rows.Clear();
            // Add new rows
            foreach (var reservation in reservations)
            {
                gridViewPhieuDatMuon.Rows.Add(reservation.Id, reservation.UserId, reservation.DeviceId, reservation.ReservationAt, reservation.Status);
            }
        }

        private async void btnQuetMaThietBi_Click(object sender, EventArgs e)
        {
            ImageScanDialog dialog = new ImageScanDialog();
            dialog.ShowDialog();
            try
            {
                String decodedValue = dialog.GetDecodedValue();
                String[] values = decodedValue.Split("-");
                if (values[0].Equals("device"))
                {
                    //kiem tra ton tai
                    Device dv = await _deviceService.GetByIdAsync(Convert.ToInt16(values[1]));
                    if (dv == null) throw new Exception("Thiết bị không tồn tại");

                    txtMaThietBi.Text = values[1];

                }
                else throw new Exception("Mã không hợp lệ");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi quét mã: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnQuetMaThanhVien_Click(object sender, EventArgs e)
        {

        }

        private void btnReset_Click(object sender, EventArgs e)
        {

        }

        private async void btnTaoVaDuyet_Click(object sender, EventArgs e)
        {
            try
            {
                await _reservationService.AddAsync(new Reservation()
                {
                    UserId = Convert.ToInt16(txtMaThanhVien.Text),
                    DeviceId = Convert.ToInt16(txtMaThietBi.Text),
                    ExpectBorrowAt = DateTime.Now,
                    ExpectReturnAt = DateTime.Now.AddDays(trackBarSoNgayMuon.Value),
                    ReservationAt = DateTime.Now,
                    Status = "confirmed"
                });
                MessageBox.Show("Đặt thiết bị thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi đặt thiết bị: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnDuyet_Click(object sender, EventArgs e)
        {
            int rowIndex = gridViewPhieuDatMuon.CurrentCell.RowIndex;
            if (rowIndex >= 0)
            {
                int reservationId = Convert.ToInt32(gridViewPhieuDatMuon.Rows[rowIndex].Cells[0].Value);
                var reservation = _reservationService.GetByIdAsync(reservationId).Result;
                if (reservation != null)
                {
                    reservation.Status = "confirmed";
                    await _reservationService.UpdateAsync(reservation);
                    MessageBox.Show("Đã duyệt đặt thiết bị", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadData();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một hàng để duyệt", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async void btnHuy_Click(object sender, EventArgs e)
        {
            int rowIndex = gridViewPhieuDatMuon.CurrentCell.RowIndex;
            if (rowIndex >= 0)
            {
                int reservationId = Convert.ToInt32(gridViewPhieuDatMuon.Rows[rowIndex].Cells[0].Value);
                var reservation = _reservationService.GetByIdAsync(reservationId).Result;
                if (reservation != null)
                {
                    reservation.Status = "canceled";
                    await _reservationService.UpdateAsync(reservation);
                    MessageBox.Show("Đã duyệt đặt thiết bị", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadData();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một hàng để duyệt", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async void cbTrangThai_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = cbTrangThai.SelectedItem.ToString();
            if (selectedValue.Equals("Tất cả"))
            {
                var reservations = await _reservationService.GetAllAsync();
                RenderTable(reservations);
            }
            else
            {
                var reservations = await _reservationService.FindByKeywordAsync(selectedValue);
                RenderTable(reservations);
            }
        }

        private void gridViewPhieuDatMuon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = gridViewPhieuDatMuon.CurrentCell.RowIndex;
            if (rowIndex >= 0)
            {
                string status = gridViewPhieuDatMuon.Rows[rowIndex].Cells[4].Value.ToString();
                if (status.Equals("pending"))
                {
                    btnDuyet.Enabled = true;
                    btnHuy.Enabled = true;
                }
                else
                {
                    btnDuyet.Enabled = false;
                    btnHuy.Enabled = false;
                }
            }
        }

        private void btnRefreshTable_Click(object sender, EventArgs e)
        {
            loadData();
        }
    }
}
