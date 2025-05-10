using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QLThuQuan.Data.Models;

namespace QLThuQuan.Data
{
    public class AppDbContext: DbContext
    {
        public static string connectionString = "server=localhost;port=3306;database=thuquan;user=root;password=";

        public DbSet<Models.Device> Devices { get; set; }

        public DbSet<Models.BorrowRecord> BorrowRecords { get; set; }

        public DbSet<Models.Reservation> Reservations { get; set; }

        public DbSet<Models.User> Users { get; set; }

        public DbSet<CheckIns> CheckIns { get; set; }

        public DbSet<Models.Rule> Rules { get; set; }

        public DbSet<Models.Violation> Violations { get; set; }
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasIndex(u => u.Email).IsUnique();
            modelBuilder.Entity<User>()
                .HasKey(u => u.Id); // Xác định UserId là khóa chính

            // Cấu hình auto-increment
            modelBuilder.Entity<User>()
                .Property(u => u.Id)
                .ValueGeneratedOnAdd();
        }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // Đây là construct để tạo AppDbContext độc lập
        public AppDbContext() : base(CreateOptions()) { }

        private static DbContextOptions<AppDbContext> CreateOptions()
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            return optionsBuilder.Options;
        }
    }
}
