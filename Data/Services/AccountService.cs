using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QLThuQuan.Data.Models;
using Microsoft.Extensions.Logging;
namespace QLThuQuan.Data.Services
{
    public class AccountService : IAccountService
    {
        private readonly AppDbContext _context;
        public AccountService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<User> UpdateUserInfoAsync(int userId, string firstName, string lastName, string email)
        {
            try
            {
                Console.WriteLine($"Bắt đầu cập nhật user"); // Thêm log

                var user = await _context.Users.FindAsync(userId);
                if (user == null)
                {
                    Console.WriteLine("Không tìm thấy user");
                    throw new KeyNotFoundException("User not found.");
                }

                Console.WriteLine($"Trước khi cập nhật: {user.FirstName} {user.LastName} {user.Email}"); // Log trạng thái trước

                if (email != user.Email && await _context.Users.AnyAsync(u => u.Email == email))
                {
                    Console.WriteLine("Email đã tồn tại");
                    throw new InvalidOperationException("Email đã được sử dụng bởi tài khoản khác");
                }

                user.FirstName = firstName;
                user.LastName = lastName;
                user.Email = email;

                _context.Entry(user).State = EntityState.Modified;
                Console.WriteLine($"Sau khi cập nhật: {user.FirstName} {user.LastName} {user.Email}"); // Log trạng thái sau

                var result = await _context.SaveChangesAsync();
                Console.WriteLine($"SaveChanges trả về: {result}"); // Log kết quả SaveChanges

                if (result <= 0)
                {
                    Console.WriteLine("SaveChanges không thành công");
                    throw new Exception("Failed to update user information.");
                }

                return user;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi: {ex.ToString()}"); // Log toàn bộ exception
                throw;
            }
        }

        public async Task<bool> ChangePasswordAsync(int userId, string oldPassword, string newPassword)
        {
            var user = await _context.Users.FindAsync(userId);
            
            if (user == null) return false;

            if (!BCrypt.Net.BCrypt.Verify(oldPassword, user.Password))
            {
                return false;
            }

            user.Password = BCrypt.Net.BCrypt.HashPassword(newPassword);
            _context.Entry(user).State = EntityState.Modified; // Đánh dấu entity đã thay đổi
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<User> GetByIdAsync(int userId)
        {
            return await _context.Users.FindAsync(userId);
        }
        public async Task<List<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }
        
        public async Task<User> AddAsync(User user)
        {
            try
            {              
                await _context.Users.AddAsync(user);
                var result = await _context.SaveChangesAsync();

             
                if (result > 0)
                {
                    return user;
                }
                else
                {
                    throw new Exception("Failed to save the user to the database.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding user: {ex.Message}");
                throw;
            }
        }
        public async Task<bool> IsEmailExistAsync(string email)
        {
            return await _context.Users.AnyAsync(u => u.Email == email);
        }
        public async Task<List<User>> GetByUserIdAsync(int userId)
        {
            return await _context.Users
                .Where(u => u.Id == userId)
                .ToListAsync();
        }
        public async Task<User> AuthenticateAsync(string email, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
            
            if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.Password))
                return null;
            
            return user;
        }
        public async Task<Violation> GetActiveViolationAsync(string email)
        {
            return await _context.Violations
                .Include(v => v.Rule)
                .Include(v => v.User)
                .Where(v => v.User.Email == email &&
                           v.Status == "active" &&
                           (v.ExpiredAt == null || v.ExpiredAt > DateTime.UtcNow))
                .OrderByDescending(v => v.ViolationDate)
                .FirstOrDefaultAsync();
        }
        public async Task<User> GetByEmailAsync(string email)
        {
            try
            {
                // Tìm user theo email (không phân biệt hoa thường)
                var user = await _context.Users
                    .FirstOrDefaultAsync(u => u.Email.ToLower() == email.ToLower());

                return user;
            }
            catch (Exception)
            {
                throw; // Ném lại exception để xử lý ở tầng cao hơn
            }
        }

        public async Task<bool> UpdateAsync(User user)
        {
            try
            {
                // Đánh dấu entity là đã được chỉnh sửa
                _context.Entry(user).State = EntityState.Modified;

                // Lưu thay đổi vào database
                var result = await _context.SaveChangesAsync();

                return result > 0;
            }
            catch (DbUpdateConcurrencyException)
            {
                throw new Exception("Dữ liệu đã bị thay đổi bởi người khác. Vui lòng thử lại.");
            }
            catch (Exception)
            {
                throw new Exception("Có lỗi xảy ra khi cập nhật thông tin người dùng.");
            }
        }

    }

}