using QLThuQuan.Data;
using Microsoft.EntityFrameworkCore;
using QLThuQuan.Data.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using QLThuQuan.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSession();
builder.Services.AddRazorPages();
builder.Services.AddTransient<EmailService>();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Login";
        options.AccessDeniedPath = "/AccessDenied";
    });
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(AppDbContext.connectionString, ServerVersion.AutoDetect(AppDbContext.connectionString)));

//Services Injection
builder.Services.AddScoped<IDeviceService, DeviceService>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IBorrowService, BorrowService>();
builder.Services.AddScoped<IReservationService, ReservationService>();
builder.Services.AddScoped<IViolationService, ViolationService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseSession();
app.UseRouting();

//app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
