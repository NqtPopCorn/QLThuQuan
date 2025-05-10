using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLThuQuan.Data.Models;

namespace QLThuQuan.Data.Services
{
    public interface ICheckInsService
    {
        // Thêm lượt vào
        Task AddCheckInAsync(CheckIns checkIns);

        // Lấy tất cả lượt vào
        Task<IEnumerable<CheckIns>> GetAllCheckInsAsync();

        // Lấy lượt vào theo Id
        Task<CheckIns> GetCheckInByIdAsync(int id);

        Task<CheckIns> CheckOut(string email);

        // Thống kê lượt vào theo tháng
        Task<Dictionary<string, double>> GetMonthlyCheckInStats(DateTime startDate, DateTime endDate);

        // Thong ke vi pham
        Task<Dictionary<string, double>> GetViPhamStats(DateTime startDate, DateTime endDate);
    }
}
