﻿﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QLThuQuan.Data.Models;

namespace QLThuQuan.Data.Services
{
    public class ViolationService : IViolationService
    {
        private readonly AppDbContext _context;

        public ViolationService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Violation>> GetAllAsync()
        {
            try
            {
                return await _context.Violations
                    .Include(v => v.User)
                    .Include(v => v.Rule)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                // Ghi lại lỗi chi tiết và ném lại ngoại lệ
                throw new InvalidOperationException($"Lỗi khi lấy danh sách vi phạm: {ex.Message}", ex);
            }
        }

        public async Task<Violation> GetByIdAsync(int id)
        {
            try
            {
                return await _context.Violations
                    .Include(v => v.User)
                    .Include(v => v.Rule)
                    .FirstOrDefaultAsync(v => v.Id == id);
            }
            catch (Exception ex)
            {
                // Ghi lại lỗi chi tiết và ném lại ngoại lệ
                throw new InvalidOperationException($"Lỗi khi lấy vi phạm theo ID: {ex.Message}", ex);
            }
        }

        public async Task<Violation> AddAsync(Violation violation)
        {
            try
            {
                violation.ViolationDate = DateTime.Now;
                _context.Violations.Add(violation);
                await _context.SaveChangesAsync();

                // Tải lại đối tượng đã thêm với các quan hệ
                var addedViolation = await _context.Violations
                    .Include(v => v.User)
                    .Include(v => v.Rule)
                    .FirstOrDefaultAsync(v => v.Id == violation.Id);

                return addedViolation ?? violation;
            }
            catch (Exception ex)
            {
                // Ghi lại lỗi chi tiết và ném lại ngoại lệ
                throw new InvalidOperationException($"Lỗi khi thêm vi phạm: {ex.Message}", ex);
            }
        }

        public async Task<Violation> UpdateAsync(Violation violation)
        {
            try
            {
                // Tìm vi phạm hiện có trong cơ sở dữ liệu
                var existingViolation = await _context.Violations.FindAsync(violation.Id);
                if (existingViolation == null)
                    throw new InvalidOperationException($"Không tìm thấy vi phạm với ID {violation.Id}");

                // Tách đối tượng khỏi context để tránh lỗi tracking
                _context.Entry(existingViolation).State = EntityState.Detached;

                // Cập nhật trực tiếp đối tượng vi phạm
                violation.ViolationDate = existingViolation.ViolationDate; // Giữ nguyên ngày vi phạm gốc
                _context.Violations.Update(violation);
                await _context.SaveChangesAsync();

                // Tải lại đối tượng đã cập nhật với các quan hệ
                var updatedViolation = await _context.Violations
                    .Include(v => v.User)
                    .Include(v => v.Rule)
                    .FirstOrDefaultAsync(v => v.Id == violation.Id);

                return updatedViolation;
            }
            catch (DbUpdateConcurrencyException)
            {
                // Xử lý lỗi đồng thời
                throw;
            }
            catch (Exception ex)
            {
                // Ghi lại lỗi chi tiết và ném lại ngoại lệ
                throw new InvalidOperationException($"Lỗi khi cập nhật vi phạm: {ex.Message}", ex);
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                // Tìm vi phạm hiện có trong cơ sở dữ liệu
                var violation = await _context.Violations.FindAsync(id);
                if (violation == null)
                    return false;

                // Đánh dấu thực thể để xóa
                _context.Violations.Remove(violation);

                // Lưu thay đổi và kiểm tra số hàng bị ảnh hưởng
                int rowsAffected = await _context.SaveChangesAsync();

                // Nếu không có hàng nào bị ảnh hưởng, ném ngoại lệ
                if (rowsAffected == 0)
                    throw new DbUpdateConcurrencyException("Không thể xóa vi phạm. Dữ liệu có thể đã bị thay đổi.");

                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                // Xử lý lỗi đồng thời
                throw;
            }
            catch (Exception ex)
            {
                // Ghi lại lỗi chi tiết và ném lại ngoại lệ
                throw new InvalidOperationException($"Lỗi khi xóa vi phạm: {ex.Message}", ex);
            }
        }

        public async Task<List<Violation>> GetByUserIdAsync(int userId)
        {
            try
            {
                return await _context.Violations
                    .Include(v => v.User)
                    .Include(v => v.Rule)
                    .Where(v => v.UserId == userId)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                // Ghi lại lỗi chi tiết và ném lại ngoại lệ
                throw new InvalidOperationException($"Lỗi khi lấy vi phạm theo người dùng: {ex.Message}", ex);
            }
        }

        public async Task<List<Violation>> GetByRuleIdAsync(int ruleId)
        {
            try
            {
                return await _context.Violations
                    .Include(v => v.User)
                    .Include(v => v.Rule)
                    .Where(v => v.RuleId == ruleId)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                // Ghi lại lỗi chi tiết và ném lại ngoại lệ
                throw new InvalidOperationException($"Lỗi khi lấy vi phạm theo quy tắc: {ex.Message}", ex);
            }
        }

        public async Task<List<Violation>> GetByStatusAsync(string status)
        {
            try
            {
                return await _context.Violations
                    .Include(v => v.User)
                    .Include(v => v.Rule)
                    .Where(v => v.Status == status)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                // Ghi lại lỗi chi tiết và ném lại ngoại lệ
                throw new InvalidOperationException($"Lỗi khi lấy vi phạm theo trạng thái: {ex.Message}", ex);
            }
        }

        public async Task<List<Violation>> FindByKeywordAsync(string keyword)
        {
            if (string.IsNullOrEmpty(keyword))
                return await GetAllAsync();

            try
            {
                return await _context.Violations
                    .Include(v => v.User)
                    .Include(v => v.Rule)
                    .Where(v => v.Description.Contains(keyword) ||
                               v.User.FirstName.Contains(keyword) ||
                               v.User.LastName.Contains(keyword) ||
                               v.Rule.Name.Contains(keyword))
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                // Ghi lại lỗi chi tiết và ném lại ngoại lệ
                throw new InvalidOperationException($"Lỗi khi tìm kiếm vi phạm: {ex.Message}", ex);
            }
        }
    }
}
