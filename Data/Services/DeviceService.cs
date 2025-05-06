using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public async Task<List<Device>> GetAllAsync()
        {
            return await _context.Devices.ToListAsync();
        }

        public async Task<Device> GetByIdAsync(int id)
        {
            return await _context.Devices.FindAsync(id);
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

        public async Task<bool> DeleteAsync(int id)
        {
            var device = await _context.Devices.FindAsync(id);
            if (device == null)
            {
                return false;
            }
            _context.Devices.Remove(device);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Device>> FindByKeywordAsync(string keyword)
        {
            //use linq
            return await _context.Devices
                .Where(d => d.Name.Contains(keyword) || d.Description.Contains(keyword))
                .ToListAsync();
        }

        public async Task<List<Device>> GetAllByStatusAsync(string status)
        {
            return await _context.Devices
                .Where(d => d.Status == status)
                .ToListAsync();
        }

    }
}
