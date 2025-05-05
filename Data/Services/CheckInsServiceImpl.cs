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

    }
}
