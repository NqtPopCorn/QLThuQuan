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

namespace QLThuQuan.Winforms.Controls
{
    public partial class QLDatMuon : UserControl
    {
        private IReservationService _reservationService;
        public QLDatMuon(IReservationService reservationService)
        {
            _reservationService = reservationService;
            InitializeComponent();
            loadData();
        }

        private async void loadData()
        {
            // Load data from the reservation service
            var reservations = await _reservationService.GetAllAsync();
            RenderTable(reservations);
        }

        private void RenderTable(List<Reservation> reservations)
        {
            // Clear existing rows
            gridViewPhieuDatMuon.Rows.Clear();
            // Add new rows
            foreach (var reservation in reservations)
            {
                gridViewPhieuDatMuon.Rows.Add(reservation.Id, reservation.UserId, reservation.DeviceId, reservation.ReservationAt);
            }
        }

    }
}
