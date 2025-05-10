using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QLThuQuan.Data.Models;

namespace QLThuQuan.Data.Services
{
    public interface IReservationService
    {
        Task<List<Reservation>> GetAllAsync();
        Task<Reservation> GetByIdAsync(int id);
        Task<Reservation> AddAsync(Reservation reservation);
        Task<Reservation> UpdateAsync(Reservation reservation);
        Task<bool> DeleteAsync(int id);
        Task<List<Reservation>> GetByUserIdAsync(int userId);
        Task<List<Reservation>> GetByDeviceIdAsync(int deviceId);
        Task<List<Reservation>> FindByKeywordAsync(string keyword);
        Task<List<Reservation>> FindByStatusAndKeywordAsync(string status, string keyword);

        Task<bool> CancelReservationAsync(int reservationId);

        Task<List<Reservation>> GetByStatusAsync(string status);
        Task<List<Reservation>> GetUserReservationsAsync(int userId);

        Task<bool> ConfirmReservationAsync(int reservationId);

        Task<Reservation> KiemTraPhieuMuonAsync(int userId, int deviceId);
    }
}
