using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLThuQuan.Data.Models;

namespace QLThuQuan.Data.Services
{
    public interface IDeviceService
    {
        Task<List<Device>> GetAllAsync();
        Task<Device> GetByIdAsync(int id);
        Task<Device> AddAsync(Device device);
        Task<Device> UpdateAsync(Device device);
        Task<bool> DeleteAsync(int id);

    }
}
