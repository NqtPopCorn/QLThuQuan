using System;
using System.Linq;
using System.Threading.Tasks;
using QLThuQuan.Data.Models;
using QLThuQuan.Data;
using Microsoft.EntityFrameworkCore;

class Program
{
    static async Task Main()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseMySql("server=localhost;database=thuquan;user=root;password=",
                      new MySqlServerVersion(new Version(8, 0, 30)))
            .Options;

        using var context = new AppDbContext(options);


        // Tạo DB nếu chưa có
        context.Database.EnsureCreated();

        // Thêm mới
        var device = new Device
        {
            Name = "Test Device",
            Description = "Testing EF",
            Status = "available"
        };
        context.Devices.Add(device);
        await context.SaveChangesAsync();

        // Đọc danh sách
        List<Device> devices = await context.Devices.ToListAsync();
        foreach (Device d in devices)
        {
            Console.WriteLine($"{d.Id} - {d.Name} - {d.Status} - {d.ImagePath}");
        }
    }
}
