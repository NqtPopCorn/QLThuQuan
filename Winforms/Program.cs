using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using QLThuQuan.Data;
using QLThuQuan.Data.Services;
using QLThuQuan.Winforms.Controls;
using QLThuQuan.Winforms.Helpers;
using QLThuQuan.Winforms.Component.User;

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
                    services.AddScoped<IReservationService, ReservationService>();
                    //borrow record service
                    services.AddScoped<IBorrowService, BorrowService>();
                    //user service
                    services.AddScoped<IUserService, UserServiceImpl>();
                    //check ins service
                    services.AddScoped<ICheckInsService, CheckInsServiceImpl>();

                    services.AddScoped<Dashboard>();
                    services.AddScoped<UCThietBi>();
                    services.AddScoped<QLDatMuon>();
                    services.AddScoped<QLMuonTra>();
                    services.AddScoped<UCThongKe>();
                    services.AddScoped<UCUser>();
                    services.AddScoped<UCViPham>();
                    services.AddScoped<UCQuyTac>();

                    services.AddScoped<CreateUser>();
                    services.AddScoped<UpdateUser>();
                    services.AddScoped<CheckInForm>();
                    services.AddScoped<DieuHuongGiaoDien>();
                })
                .Build();

            // Lấy dashboard từ container → các dependency trong dashboard sẽ được inject
            //var form = host.Services.GetRequiredService<Dashboard>();
            //var formCheckIns = host.Services.GetRequiredService<CheckInForm>();
            var formDieuHuong = host.Services.GetRequiredService<DieuHuongGiaoDien>();
            Application.Run(formDieuHuong);
        }

    }
}