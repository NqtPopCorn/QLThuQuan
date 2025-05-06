using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLThuQuan.Data.Models;

namespace QLThuQuan.Data.Services
{
    public interface IViolationService
    {
        Task<List<Violation>> GetAllAsync();
        Task<Violation> GetByIdAsync(int id);
        Task<Violation> AddAsync(Violation violation);
        Task<Violation> UpdateAsync(Violation violation);
        Task<bool> DeleteAsync(int id);
        Task<List<Violation>> GetByUserIdAsync(int userId);
        Task<List<Violation>> GetByRuleIdAsync(int ruleId);
        Task<List<Violation>> GetByStatusAsync(string status);
        Task<List<Violation>> FindByKeywordAsync(string keyword);
        Task<List<Violation>> GetUserViolationsAsync(int userId);
    }
}
