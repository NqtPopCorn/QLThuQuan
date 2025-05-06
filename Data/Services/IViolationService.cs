using QLThuQuan.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLThuQuan.Data.Services
{
    public interface IViolationService
    {

        Task<List<Violation>> GetUserViolationsAsync(int userId);
    }
}
