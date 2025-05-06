using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QLThuQuan.Data.Models;

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

                Console.WriteLine($"Trước khi cập nhật: {user.firstName} {user.lastName} {user.email}"); // Log trạng thái trước

                if (email != user.email && await _context.Users.AnyAsync(u => u.email == email))
                {
                    Console.WriteLine("Email đã tồn tại");
                    throw new InvalidOperationException("Email đã được sử dụng bởi tài khoản khác");
                }

                user.firstName = firstName;
                user.lastName = lastName;
                user.email = email;

                _context.Entry(user).State = EntityState.Modified;
                Console.WriteLine($"Sau khi cập nhật: {user.firstName} {user.lastName} {user.email}"); // Log trạng thái sau

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

            if (!BCrypt.Net.BCrypt.Verify(oldPassword, user.password))
            {
                return false;
            }

            user.password = BCrypt.Net.BCrypt.HashPassword(newPassword);
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
        // To debug why the information is not being saved to the database, you can follow these steps:

        // 1. Ensure that the `AppDbContext` is properly configured and injected into the `AccountService`.
        // 2. Check if the `SaveChangesAsync` method is being called after adding the entity.
        // 3. Verify if there are any validation errors or exceptions being thrown silently.
        // 4. Add logging or debug statements to trace the flow of execution.

        public async Task<User> AddAsync(User user)
        {
            try
            {
                // Add the user to the database context
                await _context.Users.AddAsync(user);

                // Save changes to the database
                var result = await _context.SaveChangesAsync();

                // Check if the save operation was successful
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
                // Log the exception for debugging
                Console.WriteLine($"Error adding user: {ex.Message}");
                throw;
            }
        }
        public async Task<bool> IsEmailExistAsync(string email)
        {
            return await _context.Users.AnyAsync(u => u.email == email);
        }
        public async Task<List<User>> GetByUserIdAsync(int userId)
        {
            return await _context.Users
                .Where(u => u.user_id == userId)
                .ToListAsync();
        }
        public async Task<User> AuthenticateAsync(string email, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.email == email);
            
            if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.password))
                return null;
            
            return user;
        }
        
    }

}