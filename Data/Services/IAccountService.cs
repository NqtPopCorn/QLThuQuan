using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLThuQuan.Data.Models;

namespace QLThuQuan.Data.Services
{
    public interface IAccountService
    {
        //Task<List<User>> GetAllAsync();
        
        Task<User> AddAsync(User user);
        Task<bool> IsEmailExistAsync(string email);
        Task<List<User>> GetByUserIdAsync(int userId);
        Task<User> AuthenticateAsync(string email, string password);

        Task<User> UpdateUserInfoAsync(int userId, string firstName, string lastName, string email);
        Task<bool> ChangePasswordAsync(int userId, string oldPassword, string newPassword);
        Task<User> GetByIdAsync(int userId);
    }
}
