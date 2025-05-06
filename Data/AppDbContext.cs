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
        public DbSet<Models.Violation> Violations { get; set; }
        public DbSet<Models.Rule> Rules { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasIndex(u => u.email).IsUnique();
            modelBuilder.Entity<User>()
                .HasKey(u => u.user_id); // Xác định UserId là khóa chính

            // Cấu hình auto-increment
            modelBuilder.Entity<User>()
                .Property(u => u.user_id)
                .ValueGeneratedOnAdd();
        }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
    }
}
