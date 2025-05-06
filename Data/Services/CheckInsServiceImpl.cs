using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QLThuQuan.Data.Models;

namespace QLThuQuan.Data.Services
{
    public class CheckInsServiceImpl : ICheckInsService
    {
        private readonly AppDbContext _context;

        public CheckInsServiceImpl(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddCheckInAsync(CheckIns checkIns)
        {
            await _context.CheckIns.AddAsync(checkIns);
            await _context.SaveChangesAsync();
        }

        public async Task<CheckIns> CheckOut(string email)
        {
            // Tìm bản ghi CheckIn mới nhất chưa CheckOut
            var checkInRecord = await _context.CheckIns
                .Where(c => c.User.Email == email && c.CheckOut == null)
                .OrderByDescending(c => c.CheckIn)
                .FirstOrDefaultAsync();

            if (checkInRecord != null)
            {
                checkInRecord.CheckOut = DateTime.Now;
                await _context.SaveChangesAsync();
            }

            return checkInRecord; // có thể là null nếu không tìm thấy
        }

        public async Task<IEnumerable<CheckIns>> GetAllCheckInsAsync()
        {
            return await _context.CheckIns.Include(c => c.User).ToListAsync();
        }

        public async Task<CheckIns> GetCheckInByIdAsync(int id)
        {
            return await _context.CheckIns.Include(c => c.User).FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Dictionary<string, double>> GetMonthlyCheckInStats(DateTime startDate, DateTime endDate)
        {
            // Tạo DbContext mới (không dùng DbContext được inject)
            await using var localContext = new AppDbContext();

            return await localContext.CheckIns
                .Where(c => c.CheckIn >= startDate && c.CheckIn <= endDate)
                .GroupBy(c => new { c.CheckIn.Year, c.CheckIn.Month })
                .OrderBy(g => g.Key.Year).ThenBy(g => g.Key.Month)
                .Select(g => new
                {
                    Month = $"{g.Key.Month:00}/{g.Key.Year}",
                    Count = g.Count()
                })
                .ToDictionaryAsync(g => g.Month, g => (double)g.Count);
        }

        public async Task<Dictionary<string, double>> GetViPhamStats(DateTime startDate, DateTime endDate)
        {
            await using var context = new AppDbContext();

            var violations = await context.Violations
                .Where(v => v.ViolationDate >= startDate && v.ViolationDate <= endDate)
                .ToListAsync();

            int unresolvedCount = violations.Count(v => v.Status == "active");
            int resolvedCount = violations.Count(v => v.Status == "resolved");

            // Lấy danh sách các RuleId duy nhất
            var ruleIds = violations.Select(v => v.RuleId).Distinct().ToList();

            // Lấy thông tin các Rule liên quan
            var rulesDict = await context.Rules
                .Where(r => ruleIds.Contains(r.Id))
                .ToDictionaryAsync(r => r.Id, r => r.CompensationAmount);

            // Tính tổng tiền vi phạm
            double totalCompensation = violations
                .Sum(v => rulesDict.TryGetValue(v.RuleId, out var amount) ? (double)amount : 0);

            double totalPaid = violations.Sum(v => (double)v.CompensationPaid);

            return new Dictionary<string, double>
            {
                { "Tổng vi phạm chưa xử lý", unresolvedCount },
                { "Tổng vi phạm đã xử lý", resolvedCount },
                { "Tổng tiền vi phạm", totalCompensation },
                { "Tổng tiền đã trả", totalPaid }
            };
        }

    }
}
