using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QLThuQuan.Data.Models;

namespace QLThuQuan.Data.Services
{
    public class UserServiceImpl : IUserService
    {
        private readonly AppDbContext _context;

        public UserServiceImpl(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task AddUserAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateUserAsync(User user)
        {
            var existingUser = await _context.Users.FindAsync(user.Id);
            if (existingUser != null)
            {
                // Cập nhật thủ công từng thuộc tính
                existingUser.FirstName = user.FirstName;
                existingUser.LastName = user.LastName;
                existingUser.Email = user.Email;
                existingUser.Password = user.Password;
                existingUser.IsAdmin = user.IsAdmin;
                existingUser.CreateAt = user.CreateAt;

                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteUserAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            Console.WriteLine("email enter: " + email);
            return await _context.Users.FirstOrDefaultAsync(u => u.Email.ToLower() == email.Trim().ToLower());
        }

        public async Task<Dictionary<string, double>> GetMonthlyUserRegisterStats(DateTime startDate, DateTime endDate)
        {
            // Tạo DbContext mới (không dùng DbContext được inject)
            await using var localContext = new AppDbContext();

            var stats = await localContext.Users
                .AsNoTracking() // Tắt tracking để tối ưu
                .Where(u => u.CreateAt >= startDate && u.CreateAt <= endDate)
                .GroupBy(u => new { u.CreateAt.Year, u.CreateAt.Month })
                .OrderBy(g => g.Key.Year)
                .ThenBy(g => g.Key.Month)
                .Select(g => new
                {
                    Month = $"{g.Key.Month:00}/{g.Key.Year}",
                    Count = g.Count()
                })
                .ToDictionaryAsync(g => g.Month, g => (double)g.Count)
                .ConfigureAwait(false); // Quan trọng trong WinForms

            return stats ?? new Dictionary<string, double>();
        }
    }
}
