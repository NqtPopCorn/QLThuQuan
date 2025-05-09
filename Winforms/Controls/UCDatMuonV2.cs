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
using ScottPlot.Hatches;
using DocumentFormat.OpenXml.Office2010.Excel;

namespace QLThuQuan.Winforms.Controls
{
    public partial class UCDatMuonV2 : UserControl
    {

        private IReservationService _reservationService;

        public UCDatMuonV2(IReservationService reservationService)
        {
            _reservationService = reservationService;
            InitializeComponent();
            this.HandleCreated += UC_HandleCreated;
        }

        public class ReservationDto
        {
            public int Id { get; set; }
            public string TenThanhVien { get; set; }

            public string TenThietBi { get; set; }

            public string NgayMuon { get; set; }

            public string NgayTra { get; set; }

            public string NgayDat { get; set; }

            public string Status { get; set; }
        }

        private async void loadData()
        {
            var keyword = txtTim.Text.ToLower();
            if (cbTrangThai.Text != "Tất cả")
            {
                var reservations = await _reservationService.FindByStatusAndKeywordAsync(cbTrangThai.Text, keyword);
                var dtos = ConvertToDto(reservations);
                RenderTable(dtos);
            }
            else
            {
                // Load data from the reservation service
                var reservations = await _reservationService.FindByKeywordAsync(keyword);
                var dtos = ConvertToDto(reservations);
                RenderTable(dtos);
            }
        }

        private List<ReservationDto> ConvertToDto(List<Reservation> reservations)
        {
            List<ReservationDto> dtos = new();
            reservations.ForEach(r =>
            {
                dtos.Add(new ReservationDto
                {
                    Id = r.Id,
                    TenThanhVien = r.User.FirstName + " " + r.User.LastName,
                    TenThietBi = r.Device.Name,
                    NgayMuon = r.ReservationAt.ToString("dd/MM/yyyy"),
                    NgayTra = r.ExpectReturnAt.ToString("dd/MM/yyyy"),
                    NgayDat = r.ReservationAt.ToString("dd/MM/yyyy"),
                    Status = r.Status
                });
            });
            return dtos;
        }

        private void RenderTable(List<ReservationDto> dtos)
        {
            // Clear existing rows
            gridViewPhieuDatMuon.Rows.Clear();
            // Add new rows
            foreach (var dto in dtos)
            {
                gridViewPhieuDatMuon.Rows.Add(dto.Id, dto.TenThanhVien, dto.TenThietBi, dto.NgayMuon, dto.NgayTra, dto.NgayDat, dto.Status);
            }
        }

        private void gridViewPhieuDatMuon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtTim.Text = "";
            cbTrangThai.SelectedIndex = 0;
            loadData();
        }

        private async void btnDuyet_Click(object sender, EventArgs e)
        {
            if (gridViewPhieuDatMuon.CurrentCell == null)
            {
                MessageBox.Show("Vui lòng chọn một hàng để duyệt");
                return;
            }

            int rowIndex = gridViewPhieuDatMuon.CurrentCell.RowIndex;
            int id = Convert.ToInt32(gridViewPhieuDatMuon.Rows[rowIndex].Cells[0].Value);
            string status = gridViewPhieuDatMuon.Rows[rowIndex].Cells[6].Value.ToString();
            if (status != "pending" && status != "confirmed")
            {
                MessageBox.Show("Phiếu đặt này đã được duyệt hoặc hủy", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //confirm dialog
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn duyệt đặt thiết bị này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.No)
            {
                return;
            }
            
            try
            {
                //dung service de duyet phieu dat muon co kiem tra
                bool isSuccess = await _reservationService.ConfirmReservationAsync(id);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi duyệt đặt thiết bị: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Đã duyệt đặt thiết bị", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            loadData();
        }

        private async void btnCancel_Click(object sender, EventArgs e)
        {
            if (gridViewPhieuDatMuon.CurrentCell == null)
            {
                MessageBox.Show("Vui lòng chọn một hàng để duyệt");
                return;
            }

            int rowIndex = gridViewPhieuDatMuon.CurrentCell.RowIndex;
            int id = Convert.ToInt32(gridViewPhieuDatMuon.Rows[rowIndex].Cells[0].Value);
            var reservation = await _reservationService.GetByIdAsync(id);

            if (reservation.Status != "pending")
            {
                MessageBox.Show("Phiếu đặt này đã được duyệt hoặc hủy", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //confirm dialog
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn duyệt đặt thiết bị này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.No)
            {
                return;
            }

            reservation.Status = "canceled";
            await _reservationService.UpdateAsync(reservation);
            MessageBox.Show("Đã huủy đặt thiết bị", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            loadData();
        }

        private void cbTrangThai_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private async void btnTim_Click(object sender, EventArgs e)
        {
            loadData();
            //var searchText = txtTim.Text.ToLower();
            ////tim theo trang thai
            //var reservations = new List<Reservation>();
            //if(cbTrangThai.Text == "Tất cả")
            //{
            //    reservations = await _reservationService.GetAllAsync();
            //}
            //else
            //{
            //    reservations = await _reservationService.GetByStatusAsync(cbTrangThai.Text);
            //}

            //var dtos = ConvertToDto(reservations
            //    .Where(reservations => reservations.User.FirstName.ToLower().Contains(searchText) 
            //            || reservations.User.LastName.ToLower().Contains(searchText) 
            //            || reservations.Device.Name.ToLower().Contains(searchText))
            //    .ToList());

            //RenderTable(dtos);

        }

        private void UC_HandleCreated(object sender, EventArgs e)
        {
            loadData();
        }
    }
}
