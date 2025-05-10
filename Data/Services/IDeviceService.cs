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
        Task<List<Device>> GetAllAsync(bool includeSolfDeleted = false);
        Task<Device> GetByIdAsync(int id, bool includeSolfDeleted = true);
        Task<Device> AddAsync(Device device);
        Task<Device> UpdateAsync(Device device);
        Task<bool> DeleteAsync(int id);

        Task<bool> SoftDeleteAsync(int id);

        Task<List<Device>> GetAllByStatusAsync(string status);

        Task<List<Device>> FindByKeywordAsync(string keyword, bool isRegex = false, bool includeSolfDeleted = true);
    }
}
