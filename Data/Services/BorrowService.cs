using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QLThuQuan.Data.Models;

namespace QLThuQuan.Data.Services
{
    public class BorrowService : IBorrowService
    {
        private readonly AppDbContext _context;
        public BorrowService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<BorrowRecord>> GetAllAsync()
        {
            return await _context.BorrowRecords
                .Include(r => r.Device) // Include the Device navigation property
                .Include(r => r.User) // Include the User navigation property
                .ToListAsync();
        }
        public async Task<BorrowRecord> GetByIdAsync(int id)
        {
            return await _context.BorrowRecords
                .Include(r => r.Device)
                .Include(r => r.User)
                .FirstAsync(r => r.Id == id);
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
            return await _context.BorrowRecords.Include(r => r.Device).Include(r => r.User)
                .Where(br => br.UserId == userId)
                .ToListAsync();
        }
        public async Task<List<BorrowRecord>> GetByDeviceIdAsync(int deviceId)
        {
            return await _context.BorrowRecords.Include(r => r.Device).Include(r => r.User)
                .Where(br => br.DeviceId == deviceId)
                .ToListAsync();
        }

        public async Task<List<BorrowRecord>> GetByStatusAsync(string status)
        {
            return await _context.BorrowRecords.Include(r => r.Device).Include(r => r.User)
                .Where(br => br.Status.Equals(status))
                .ToListAsync();
        }


        public async Task<List<BorrowRecord>> GetUserBorrowRecordsAsync(int userId)
        {
            return await _context.BorrowRecords.Include(r => r.Device).Include(r => r.User)
                .Where(br => br.UserId == userId)
                .Include(br => br.Device) // Sửa từ DeviceId thành Device
                .OrderByDescending(br => br.BorrowedAt)
                .ToListAsync();
        }

        public async Task<Dictionary<string, double>> GetDeviceBorrowStatsByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            // Thống kê số lượt mượn theo tên thiết bị trong khoảng thời gian
            var borrowStats = await (
                from br in _context.BorrowRecords
                join d in _context.Devices on br.DeviceId equals d.Id
                where br.BorrowedAt >= startDate && br.BorrowedAt <= endDate
                group d by d.Name into g
                select new
                {
                    DeviceName = g.Key,
                    BorrowCount = g.Count()
                }
            ).ToDictionaryAsync(x => x.DeviceName, x => (double)x.BorrowCount);

            // Đếm số lượng thiết bị đang được mượn (status = "borrowed")
            double currentlyBorrowedCount = await _context.BorrowRecords
                .Where(br => br.Status == "borrowed")
                .CountAsync();

            // Thêm vào kết quả
            borrowStats["Thiết bị đang được mượn"] = currentlyBorrowedCount;

            return borrowStats;
        }



        public async Task<BorrowRecord> ChoMuonThietBi(Reservation reservation)
        {

            //tao borrow record dua tren phieu dat muon
            //han tra la ngay hen tra
            //chuyen status thieu bi thanh "borrowed"
            //chuyen status phieu dat muon thanh "borrowed"

            BorrowRecord borrowRecord = new BorrowRecord
            {
                UserId = reservation.UserId,
                DeviceId = reservation.DeviceId,
                BorrowedAt = DateTime.Now,
                DueAt = reservation.ExpectReturnAt,
                Status = "borrowed"
            };

            reservation.Status = "borrowed";
            reservation.Device.Status = "in_use";

            await _context.BorrowRecords.AddAsync(borrowRecord);
            _context.Reservations.Update(reservation);
            _context.Devices.Update(reservation.Device);

            await _context.SaveChangesAsync();

            return borrowRecord;
        }

        public async Task<bool> TraThietBi(BorrowRecord borrowRecord)
        {
            if (borrowRecord == null)
            {
                return false;
            }

            borrowRecord.Status = "returned";
            borrowRecord.ReturnedAt = DateTime.Now;
            _context.BorrowRecords.Update(borrowRecord);

            var device = await _context.Devices.FindAsync(borrowRecord.DeviceId);
            if (device != null)
            {
                device.Status = "available"; // Đặt lại trạng thái thiết bị
                _context.Devices.Update(device);
            }

            //neu tra han thi tao mot vi phạm
            if (borrowRecord.DueAt < DateTime.Now)
            {
                //tinh so ngay qua han
                TimeSpan overdueDuration = DateTime.Now - borrowRecord.DueAt;

                // Tạo một vi phạm
                Violation violation = new Violation
                {
                    UserId = borrowRecord.UserId,
                    RuleId = 1, // Giả sử quy tắc vi phạm có ID là 1
                    ViolationDate = DateTime.Now,
                    Description = "Quá hạn trả thiết bị " + Convert.ToInt16(overdueDuration.TotalDays) + " ngày",
                    Status = "pending"
                };
                await _context.Violations.AddAsync(violation);
            }

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<BorrowRecord> FindBorrowedRecordAsync(int userId, int deviceId)
        {
            return await _context.BorrowRecords
                .Include(br => br.Device)
                .Include(br => br.User)
                .FirstOrDefaultAsync(br => br.UserId == userId && br.DeviceId == deviceId && br.Status == "borrowed");
        }
    }
}