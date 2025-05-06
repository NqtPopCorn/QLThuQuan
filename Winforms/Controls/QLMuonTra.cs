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

namespace QLThuQuan.Winforms.Controls
{
    public partial class QLMuonTra : UserControl
    {

        private IReservationService _reservationService;
        private IDeviceService _deviceService;
        private IBorrowService borrowService;

        public QLMuonTra(IReservationService reservationService, IDeviceService deviceService, IBorrowService borrowService)
        {
            _reservationService = reservationService;
            _deviceService = deviceService;
            this.borrowService = borrowService;
            InitializeComponent();

            pnlMuon.HandleCreated += pnlMuon_HandleCreated;
            pnlTra.HandleCreated += pnlTra_HandleCreated;
        }

        private void RenderTableDatMuon(List<Reservation> reservations)
        {
            // Clear existing rows
            gridViewDatChoMuon.Rows.Clear();
            // Add new rows
            foreach (var reservation in reservations)
            {
                gridViewDatChoMuon.Rows.Add(reservation.Id, reservation.UserId, reservation.DeviceId, reservation.ReservationAt, reservation.Status);
            }
        }

        private void RenderTableThietBiMuon(List<Device> devices)
        {
            // Clear existing rows
            gridViewThietBiMuon.Rows.Clear();
            // Add new rows
            foreach (var device in devices)
            {
                gridViewThietBiMuon.Rows.Add(device.Id, device.Name, device.Description, device.Status);
            }
        }

        private void RenderTableThietBiTra(List<Device> devices)
        {
            // Clear existing rows
            gridViewThietBiTra.Rows.Clear();
            // Add new rows
            foreach (var device in devices)
            {
                gridViewThietBiTra.Rows.Add(device.Id, device.Name, device.Description, device.Status);
            }
        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {

        }

        private async void pnlMuon_HandleCreated(object sender, EventArgs e)
        {
            // Load data from the reservation service
            var reservations = await _reservationService.GetByStatusAsync("confirmed");
            RenderTableDatMuon(reservations);
            // Load data from the device service
            //var devices = await _deviceService.GetAllByStatusAsync("available");
            //RenderTableThietBiMuon(devices);

            gridViewThietBiMuon.ClearSelection();
            gridViewDatChoMuon.ClearSelection();
        }

        private async void pnlTra_HandleCreated(object sender, EventArgs e)
        {
            // Load data from the device service
            var devices = await _deviceService.GetAllByStatusAsync("in_use");
            RenderTableThietBiTra(devices);

            gridViewThietBiTra.ClearSelection();
            gridViewPhieuMuon.ClearSelection();
        }

        private void RenderTablePhieuMuon(List<BorrowRecord> borrowRecords)
        {
            // Clear existing rows
            gridViewPhieuMuon.Rows.Clear();
            // Add new rows
            foreach (var borrowRecord in borrowRecords)
            {
                gridViewPhieuMuon.Rows.Add(borrowRecord.Id, borrowRecord.UserId, borrowRecord.DeviceId, borrowRecord.BorrowedAt);
            }
        }

        private async void gridViewThietBiTra_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = gridViewThietBiTra.CurrentCell.RowIndex;
            int deviceId = Convert.ToInt32(gridViewThietBiTra.Rows[rowIndex].Cells[0].Value);
            var borrowRecords = await borrowService.GetByDeviceIdAsync(deviceId);
            RenderTablePhieuMuon(borrowRecords.Where(r => r.Status.Equals("borrowed")).ToList());
        }

        private async void gridViewThietBiMuon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = gridViewThietBiMuon.CurrentCell.RowIndex;
            int deviceId = Convert.ToInt32(gridViewThietBiMuon.Rows[rowIndex].Cells[0].Value);
            var reservations = await _reservationService.GetByDeviceIdAsync(deviceId);
            RenderTableDatMuon(reservations.Where(r => r.Status.Equals("confirmed")).ToList());
        }

        private async void btnRefreshDatMuon_Click(object sender, EventArgs e)
        {
            gridViewThietBiMuon.ClearSelection();
            var reservations = await _reservationService.GetByStatusAsync("confirmed");
            RenderTableDatMuon(reservations);
        }

        private async void btnTimTBMuon_Click(object sender, EventArgs e)
        {
            string keyword = txtTimTBMuon.Text;
            if (string.IsNullOrEmpty(keyword))
            {
                MessageBox.Show("Vui lòng nhập từ khóa tìm kiếm");
                return;
            }
            var devices = await _deviceService.FindByKeywordAsync(keyword);
            devices = devices.Where(d => d.Status.Equals("available")).ToList();
            if (devices.Count == 0)
            {
                MessageBox.Show("Không tìm thấy thiết bị nào");
                return;
            }
            RenderTableThietBiMuon(devices);
        }

        private void btnQuetMaTVMuon_Click(object sender, EventArgs e)
        {

        }

        private async void btnRefreshTBMuon_Click(object sender, EventArgs e)
        {
            txtTimTBMuon.Text = "";
            var devices = await _deviceService.GetAllByStatusAsync("available");
            RenderTableThietBiMuon(devices);
        }

        private async void btnChoMuon_Click(object sender, EventArgs e)
        {
            if (gridViewThietBiMuon.CurrentCell == null || gridViewDatChoMuon.CurrentCell == null)
            {
                MessageBox.Show("Vui lòng chọn thiết bị và hàng đợi đặt trước");
                return;
            }
            int thietBiMuonRowIndex = gridViewThietBiMuon.CurrentCell.RowIndex;
            int datMuonRowIndex = gridViewDatChoMuon.CurrentCell.RowIndex;


            int thietBiMuonId = Convert.ToInt32(gridViewThietBiMuon.Rows[thietBiMuonRowIndex].Cells[0].Value);
            int datMuonId = Convert.ToInt32(gridViewDatChoMuon.Rows[datMuonRowIndex].Cells[0].Value);
            int userId = Convert.ToInt32(gridViewDatChoMuon.Rows[datMuonRowIndex].Cells[1].Value);

            Reservation reservation = await _reservationService.GetByIdAsync(datMuonId);
            BorrowRecord borrowRecord = new BorrowRecord
            {
                DeviceId = thietBiMuonId,
                UserId = userId,
                BorrowedAt = DateTime.Now,
                DueAt = reservation.ExpectReturnAt,
                Status = "borrowed"
            };
            reservation.Status = "borrowed";

            await borrowService.AddAsync(borrowRecord);
            await _reservationService.UpdateAsync(reservation);
            MessageBox.Show("Cho mượn thành công !");
        }

        private async void btnTimDatCho_Click(object sender, EventArgs e)
        {
            if (gridViewThietBiMuon.CurrentCell == null)
            {
                MessageBox.Show("Vui lòng chọn thiết bị");
                return;
            }

            int thietBiMuonRowIndex = gridViewThietBiMuon.CurrentCell.RowIndex;
            int thietBiMuonId = Convert.ToInt32(gridViewThietBiMuon.Rows[thietBiMuonRowIndex].Cells[0].Value);
            var reservations = await _reservationService.GetByStatusAsync("confirmed");
            reservations = reservations.Where(r => r.UserId.ToString().Contains(txtMaTVMuon.Text) && r.DeviceId == thietBiMuonId).ToList();
            if (reservations.Count == 0)
            {
                MessageBox.Show("Không tìm thấy thành viên nào");
                return;
            }
            RenderTableDatMuon(reservations);
        }

        private async void btnRefreshPhieuMuon_Click(object sender, EventArgs e)
        {
            txtThanhVienTra.Text = "";
            gridViewThietBiTra.ClearSelection();
            var borrowRecords = await borrowService.GetAllAsync();
            RenderTablePhieuMuon(borrowRecords.Where(r => r.Status.Equals("borrowed")).ToList());
        }

        private async void btnTimTBTra_Click(object sender, EventArgs e)
        {
            string keyword = txtTimTBTra.Text;
            if (string.IsNullOrEmpty(keyword))
            {
                MessageBox.Show("Vui lòng nhập từ khóa tìm kiếm");
                return;
            }
            var devices = await _deviceService.FindByKeywordAsync(keyword);
            string status = "in_use";
            devices = devices.Where(d => d.Status.Equals(status)).ToList();
            if (devices.Count == 0)
            {
                MessageBox.Show("Không tìm thấy thiết bị nào");
                return;
            }
            RenderTableThietBiTra(devices);
        }

        private async void cbTrangThaiTBTra_SelectedIndexChanged(object sender, EventArgs e)
        {
            string keyword = txtTimTBTra.Text;
            string status = "in_use";
            var devices = await _deviceService.GetAllByStatusAsync(status);
            
            if (!string.IsNullOrEmpty(keyword))
            {
                devices = devices.Where(d => d.Name.Contains(keyword) || d.Description.Contains(keyword)).ToList();
            }
            RenderTableThietBiTra(devices);
        }

        private async void btnTra_Click(object sender, EventArgs e)
        {
            if (gridViewThietBiTra.CurrentCell == null || gridViewPhieuMuon.CurrentCell == null)
            {
                MessageBox.Show("Vui lòng chọn thiết bị và phiếu mượn");
                return;
            }

            int thietBiTraRowIndex = gridViewThietBiTra.CurrentCell.RowIndex;
            int phieuMuonRowIndex = gridViewPhieuMuon.CurrentCell.RowIndex;

            int thietBiTraId = Convert.ToInt32(gridViewThietBiTra.Rows[thietBiTraRowIndex].Cells[0].Value);
            int phieuMuonId = Convert.ToInt32(gridViewPhieuMuon.Rows[phieuMuonRowIndex].Cells[0].Value);

            var borrowRecord = await borrowService.GetByIdAsync(phieuMuonId);
            if (borrowRecord == null || borrowRecord.DeviceId != thietBiTraId)
            {
                MessageBox.Show("Phiếu mượn không hợp lệ");
                return;
            }

            borrowRecord.Status = "returned";
            borrowRecord.ReturnedAt = DateTime.Now;
            await borrowService.UpdateAsync(borrowRecord);

            var device = await _deviceService.GetByIdAsync(thietBiTraId);
            device.Status = "available";
            await _deviceService.UpdateAsync(device);

            MessageBox.Show("Trả thiết bị thành công!");

            var devices = await _deviceService.GetAllByStatusAsync("in_use");
            RenderTableThietBiTra(devices);
            btnRefreshPhieuMuon_Click(sender, e);
        }

        private void btnQuetTVTra_Click(object sender, EventArgs e)
        {
        }

        private async void btnTimPhieuMuon_Click(object sender, EventArgs e)
        {
            if (gridViewThietBiTra.CurrentCell == null)
            {
                MessageBox.Show("Vui lòng chọn thiết bị");
                return;
            }

            int thietBiTraRowIndex = gridViewThietBiTra.CurrentCell.RowIndex;
            int thietBiTraId = Convert.ToInt32(gridViewThietBiTra.Rows[thietBiTraRowIndex].Cells[0].Value);
            var borrowRecords = await borrowService.GetByDeviceIdAsync(thietBiTraId);
            borrowRecords = borrowRecords.Where(r => r.UserId.ToString().Contains(txtThanhVienTra.Text) && r.Status.Equals("borrowed")).ToList();
            if (borrowRecords.Count == 0)
            {
                MessageBox.Show("Không tìm thấy phiếu mượn nào");
                return;
            }
            RenderTablePhieuMuon(borrowRecords);
        }

        private async void btnRefreshTBTra_Click(object sender, EventArgs e)
        {
            gridViewThietBiTra.ClearSelection();
            txtTimTBTra.Text = "";
            var devices = await _deviceService.GetAllByStatusAsync("in_use");
            RenderTableThietBiTra(devices);
        }
    }
}
