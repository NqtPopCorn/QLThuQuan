using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QLThuQuan.Data.Models;

namespace QLThuQuan.Data.Services
{
    public class BorrowService: IBorrowService
    {
        private readonly AppDbContext _context;
        public BorrowService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<BorrowRecord>> GetAllAsync()
        {
            return await _context.BorrowRecords.ToListAsync();
        }
        public async Task<BorrowRecord> GetByIdAsync(int id)
        {
            return await _context.BorrowRecords.FindAsync(id);
        }
        public async Task<BorrowRecord> AddAsync(BorrowRecord borrowRecord)
        {
            await _context.BorrowRecords.AddAsync(borrowRecord);
            await _context.SaveChangesAsync();
            return borrowRecord;
        }
        public async Task<BorrowRecord> UpdateAsync(BorrowRecord borrowRecord)
        {
            _context.BorrowRecords.Update(borrowRecord);
            await _context.SaveChangesAsync();
            return borrowRecord;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var borrowRecord = await GetByIdAsync(id);
            if (borrowRecord == null) return false;
            _context.BorrowRecords.Remove(borrowRecord);
            await _context.SaveChangesAsync();
            return true;
        }
        //public async Task<List<BorrowRecord>> FindByKeywordAsync(string keyword)
        //{
        //    return await _context.BorrowRecords
        //        .Where(br => br.Device.Name.Contains(keyword) || br.User.Name.Contains(keyword))
        //        .ToListAsync();
        //}
        public async Task<List<BorrowRecord>> GetByUserIdAsync(int userId)
        {
            return await _context.BorrowRecords
                .Where(br => br.UserId == userId)
                .ToListAsync();
        }
        public async Task<List<BorrowRecord>> GetByDeviceIdAsync(int deviceId)
        {
            return await _context.BorrowRecords
                .Where(br => br.DeviceId == deviceId)
                .ToListAsync();
        }
    }
}
