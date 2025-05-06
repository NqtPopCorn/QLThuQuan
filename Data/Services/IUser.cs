using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLThuQuan.Data.Models;

namespace QLThuQuan.Data.Services
{
    public interface IUser
    {
        // Lấy danh sách tất cả người dùng
        Task<IEnumerable<User>> GetAllUsersAsync();

        // Lấy thông tin người dùng theo Id
        Task<User> GetUserByIdAsync(int id);

        // Lấy thông tin người dùng theo email
        Task<User> GetUserByEmailAsync(string email);

        // Thêm người dùng mới
        Task AddUserAsync(User user);

        // Cập nhật thông tin người dùng
        Task UpdateUserAsync(User user);

        // Xóa người dùng
        Task DeleteUserAsync(int id);

        // Thống kê lượt user đăng ký theo tháng
        Task<Dictionary<string, double>> GetMonthlyUserRegisterStats(DateTime startDate, DateTime endDate);
    }
}
