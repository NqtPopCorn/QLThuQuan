using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QLThuQuan.Data.Models;

namespace QLThuQuan.Data.Services
{
    public class ReservationService : IReservationService
    {
        private readonly AppDbContext _context;
        public ReservationService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<Reservation>> GetAllAsync()
        {
            return await _context.Reservations
                .Include(r => r.Device) // Include the Device navigation property
                .Include(r => r.User) // Include the User navigation property
                .ToListAsync();
        }
        public async Task<Reservation> GetByIdAsync(int id)
        {
            return await _context.Reservations
                .Include(r => r.Device)
                .Include(r => r.User)
                .FirstAsync(r => r.Id == id);
        }
        public async Task<Reservation> AddAsync(Reservation reservation)
        {
            await _context.Reservations.AddAsync(reservation);
            await _context.SaveChangesAsync();
            return reservation;
        }
        public async Task<Reservation> UpdateAsync(Reservation reservation)
        {
            _context.Reservations.Update(reservation);
            await _context.SaveChangesAsync();
            return reservation;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var reservation = await GetByIdAsync(id);
            if (reservation == null) return false;
            _context.Reservations.Remove(reservation);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<List<Reservation>> GetByUserIdAsync(int userId)
        {
            return await _context.Reservations
                .Where(r => r.UserId == userId)
                .ToListAsync();
        }
        public async Task<List<Reservation>> GetByDeviceIdAsync(int deviceId)
        {
            return await _context.Reservations
                .Where(r => r.DeviceId == deviceId)
                .ToListAsync();
        }
        public async Task<List<Reservation>> FindByKeywordAsync(string keyword)
        {
            return await _context.Reservations
                .Include(r => r.Device) // Include the Device navigation property
                .Include(r => r.User) // Include the User navigation property
                .Where(r => r.User.FirstName.Contains(keyword)
                    || r.User.LastName.Contains(keyword)
                    || r.Device.Name.Contains(keyword)
                    || ("" + r.Device.Id).Contains(keyword)
                    || ("" + r.User.Id).Contains(keyword))
                .ToListAsync();
        }

        public async Task<List<Reservation>> GetByStatusAsync(string status)
        {
            return await _context.Reservations
                .Where(r => r.Status == status)
                .Include(r => r.Device) // Include the Device navigation property
                .Include(r => r.User) // Include the User navigation property
                .ToListAsync();
        }

        public async Task<List<Reservation>> GetUserReservationsAsync(int userId)
        {
            return await _context.Reservations
                .Where(r => r.UserId == userId)
                .Include(r => r.Device) // Sửa từ DeviceId thành Device
                .OrderByDescending(r => r.ReservationAt)
                .ToListAsync();
        }

        public async Task<bool> ConfirmReservationAsync(int reservationId)
        {
            var reservation = await GetByIdAsync(reservationId);
            if (reservation == null) return false;

            //neu khong o trang thai pending thi khong lam gi ca
            if (reservation.Status != "pending")
            {
                return false;
            }

            // Tìm các phiếu đặt khác trùng khoảng thời gian
            var isConflict = await _context.Reservations.AnyAsync(r =>
                r.Id != reservation.Id &&
                r.DeviceId == reservation.DeviceId &&
                r.Status == "confirmed" &&
                (
                    (r.ExpectBorrowAt >= reservation.ExpectBorrowAt && r.ExpectBorrowAt <= reservation.ExpectReturnAt) ||
                    (r.ExpectReturnAt >= reservation.ExpectBorrowAt && r.ExpectReturnAt <= reservation.ExpectReturnAt) ||
                    (reservation.ExpectBorrowAt >= r.ExpectBorrowAt && reservation.ExpectBorrowAt <= r.ExpectReturnAt)
                )
            );
            if (isConflict)
            {
                throw new Exception("Đã có phiếu đặt khác trùng với thời gian này");
            }

            //kiem tra qua han mong mong muon
            if (reservation.ExpectReturnAt <= DateTime.Now)
            {
                // Đã quá hạn
                throw new Exception("Phiếu đặt đã quá hạn");
            }

            reservation.Status = "confirmed";
            _context.Reservations.Update(reservation);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Reservation>> FindByStatusAndKeywordAsync(string status, string keyword)
        {
            return await _context.Reservations
                .Include(r => r.Device) // Include the Device navigation property
                .Include(r => r.User) // Include the User navigation property
                .Where(r => (r.User.FirstName.Contains(keyword)
                                || r.User.LastName.Contains(keyword)
                                || r.Device.Name.Contains(keyword)
                                || ("" + r.Device.Id).Contains(keyword)
                                || ("" + r.User.Id).Contains(keyword))
                            && r.Status == status)
                .ToListAsync();
        }

        public async Task<bool> CancelReservationAsync(int reservationId)
        {
            var reservation = await GetByIdAsync(reservationId);
            if (reservation == null) return false;
            //neu khong o trang thai pending hoac confirmed thi khong lam gi ca
            if (reservation.Status != "pending" && reservation.Status != "confirmed")
            {
                throw new Exception("Phiếu đặt phải pending hoặc confirmed để có thể hủy");
            }
            reservation.Status = "canceled";
            _context.Reservations.Update(reservation);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Reservation> KiemTraPhieuMuonAsync(int userId, int deviceId)
        {
            Reservation phieuDatMuon = await _context.Reservations
                .Include(r => r.Device) // Include the Device navigation property
                .Include(r => r.User) // Include the User navigation property
                .FirstOrDefaultAsync(r => r.UserId == userId && r.DeviceId == deviceId && r.Status == "confirmed");

            if (phieuDatMuon == null)
            {
                throw new Exception("Chưa đặt mượn hoặc chưa được duyệt");
            }

            Device device = phieuDatMuon.Device;
            if (device.Status != "available")
            {
                throw new Exception("Thiết bị đang bảo trì hoặc đã được mượn");
            }

            if (phieuDatMuon.ExpectReturnAt < DateTime.Now)
            {
                throw new Exception("Phiếu đặt đã quá hạn");
            }
            if (phieuDatMuon.ExpectBorrowAt > DateTime.Now)
            {
                throw new Exception("Chưa đến thời gian hẹn lấy thiết bị");
            }

            return phieuDatMuon;
        }
    }
}
