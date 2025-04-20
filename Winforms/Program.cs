using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using QLThuQuan.Data;
using QLThuQuan.Data.Services;
using QLThuQuan.Winforms.Controls;

namespace QLThuQuan.Winforms
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        /// 
        internal readonly static string connectionString = AppDbContext.connectionString;

        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            var host = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    services.AddDbContext<AppDbContext>(options =>
                        options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

                    //device service
                    services.AddScoped<IDeviceService, DeviceService>();
                    //borrow service
                    services.AddScoped<IBorrowService, BorrowService>();
                    //reservation service
                    services.AddScoped<IReservationService, ReservationService> ();

                    services.AddScoped<Dashboard>();
                    services.AddScoped<UCThietBi>();
                    services.AddScoped<QLDatMuon>();
                })
                .Build();

            // Lấy dashboard từ container → các dependency trong dashboard sẽ được inject
            var form = host.Services.GetRequiredService<Dashboard>();
            Application.Run(form);
        }

    }
}