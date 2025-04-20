using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace QLThuQuan.Data
{
    public class AppDbContext: DbContext
    {

        public static string connectionString = "server=localhost;port=3306;database=thuquan;user=root;password=";

        public DbSet<Models.Device> Devices { get; set; }

        public DbSet<Models.BorrowRecord> BorrowRecords { get; set; }

        public DbSet<Models.Reservation> Reservations { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
    }
}
