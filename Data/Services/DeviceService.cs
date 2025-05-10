using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QLThuQuan.Data.Models;

namespace QLThuQuan.Data.Services
{
    public class DeviceService: IDeviceService
    {
        private readonly AppDbContext _context;

        public DeviceService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Device>> GetAllAsync(bool includeSolfDeleted = false)
        {
            if (includeSolfDeleted)
            {
                return await _context.Devices.ToListAsync();
            }
            return await _context.Devices
                .Where(d => d.IsDeleted == 0)
                .ToListAsync();
        }

        public async Task<Device> GetByIdAsync(int id, bool includeSolfDeleted = true)
        {
            if (includeSolfDeleted)
            {
                return await _context.Devices.FindAsync(id);
            }
            return await _context.Devices
                .Where(d => d.IsDeleted == 0)
                .FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<Device> AddAsync(Device device)
        {
            _context.Devices.Add(device);
            await _context.SaveChangesAsync();
            return device;
        }

        public async Task<Device> UpdateAsync(Device device)
        {
            _context.Devices.Update(device);
            await _context.SaveChangesAsync();
            return device;
        }

        public async Task<bool> SoftDeleteAsync(int id)
        {
            var device = await _context.Devices.FindAsync(id);
            if (device == null)
            {
                return false;
            }
            device.IsDeleted = 1;
            _context.Devices.Update(device);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int deviceId)
        {
            try
            {
                var device = await _context.Devices.FindAsync(deviceId);
                if (device != null)
                {
                    _context.Devices.Remove(device);
                    await _context.SaveChangesAsync();
                }
                return true;
            }
            catch (DbUpdateException ex) when (ex.InnerException?.Message.Contains("foreign key") == true)
            {
                throw new InvalidOperationException("Không thể xóa thiết bị do vi phạm ràng buộc khóa ngoại.");
            }
        }

        public async Task<List<Device>> FindByKeywordAsync(string keyword, bool isRegex = false, bool includeSolfDeleted = true)
        {
            var devices = await _context.Devices.ToListAsync();
            if (isRegex)
            {
                return devices.Where(d => (includeSolfDeleted || d.IsDeleted == 0) &&
                                        (Regex.IsMatch(d.Id.ToString() ?? "", keyword) ||
                                        Regex.IsMatch(d.Name ?? "", keyword) || 
                                        Regex.IsMatch(d.Description ?? "", keyword)))
                              .ToList();
            }
            return devices.Where(d => (includeSolfDeleted || d.IsDeleted == 0) &&
                                    (d.Id.ToString().Contains(keyword, StringComparison.OrdinalIgnoreCase) == true ||
                                     d.Name?.Contains(keyword, StringComparison.OrdinalIgnoreCase) == true ||
                                     d.Description?.Contains(keyword, StringComparison.OrdinalIgnoreCase) == true))
                              .ToList();
        }

        public async Task<List<Device>> GetAllByStatusAsync(string status)
        {
            return await _context.Devices
                .Where(d => d.IsDeleted == 0 && d.Status == status)
                .ToListAsync();
        }

    }
}
