﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLThuQuan.Data.Models;

namespace QLThuQuan.Data.Services
{
        public interface IBorrowService
        {
                Task<List<BorrowRecord>> GetAllAsync();
                Task<BorrowRecord> GetByIdAsync(int id);
                Task<BorrowRecord> AddAsync(BorrowRecord borrowRecord);
                Task<BorrowRecord> UpdateAsync(BorrowRecord borrowRecord);
                Task<bool> DeleteAsync(int id);
                //Task<List<BorrowRecord>> FindByKeywordAsync(string keyword);
                Task<List<BorrowRecord>> GetByUserIdAsync(int userId);
                Task<List<BorrowRecord>> GetByDeviceIdAsync(int deviceId);
                Task<List<BorrowRecord>> GetUserBorrowRecordsAsync(int userId);
                Task<List<BorrowRecord>> GetByStatusAsync(string status);

                Task<BorrowRecord> ChoMuonThietBi(Reservation reservation);

                Task<bool> TraThietBi(BorrowRecord borrowRecord);

                Task<BorrowRecord> FindBorrowedRecordAsync(int userId, int deviceId);
                Task<Dictionary<string, double>> GetDeviceBorrowStatsByDateRangeAsync(DateTime startDate, DateTime endDate);

        }
}
