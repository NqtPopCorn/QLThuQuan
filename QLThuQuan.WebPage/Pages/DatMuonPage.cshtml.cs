using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QLThuQuan.Data.Models;
using QLThuQuan.Data.Services;
using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;

namespace QLThuQuan.Web.Pages
{
    public class DatMuonPageModel : PageModel
    {
        private readonly IDeviceService _deviceService;
        private readonly IReservationService _reservationService;

        public DatMuonPageModel(IDeviceService deviceService, IReservationService reservationService)
        {
            _deviceService = deviceService;
            _reservationService = reservationService;
        }

        [BindProperty]
        public Device Device { get; set; }

        [BindProperty]
        public Reservation Reservation { get; set; }

        public string Message { get; set; }
        public string MessageType { get; set; }

        public async Task<IActionResult> OnGetAsync(int deviceId)
        {
            // Kiểm tra người dùng đã đăng nhập chưa
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToPage("/Login");
            }

            // Lấy UserId từ Claims
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userIdClaim) || !int.TryParse(userIdClaim, out int userId))
            {
                Message = "Không thể xác định thông tin người dùng.";
                MessageType = "danger";
                return Page();
            }

            Device = await _deviceService.GetByIdAsync(deviceId);
            if (Device == null)
            {
                Message = "Không tìm thấy thiết bị.";
                MessageType = "danger";
                return Page();
            }

            Reservation = new Reservation
            {
                DeviceId = deviceId,
                UserId = userId, // Sử dụng UserId từ Claims
                Status = "pending",
                ReservationAt = DateTime.Now
            };

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            // Kiểm tra người dùng đã đăng nhập chưa
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToPage("/Login");
            }

            // Lấy UserId từ Claims
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userIdClaim) || !int.TryParse(userIdClaim, out int userId))
            {
                Message = "Không thể xác định thông tin người dùng.";
                MessageType = "danger";
                return Page();
            }

            // Kiểm tra thiết bị có sẵn
            Device = await _deviceService.GetByIdAsync(Reservation.DeviceId);
            if (Device == null || Device.Status != "available")
            {
                Message = "Thiết bị không tồn tại hoặc không thể đặt mượn.";
                MessageType = "danger";
                return Page();
            }

            //if (!ModelState.IsValid)
            //{
            //    Console.WriteLine("ModelState không hợp lệ");
            //    foreach (var key in ModelState.Keys)
            //    {
            //        var errors = ModelState[key].Errors;
            //        foreach (var error in errors)
            //        {
            //            Console.WriteLine($"ModelState Error - {key}: {error.ErrorMessage}");
            //        }
            //    }
            //    Device = await _deviceService.GetByIdAsync(Reservation.DeviceId);
            //    Message = "Vui lòng kiểm tra lại thông tin nhập.";
            //    MessageType = "danger";
            //    return Page();
            //}


            // Kiểm tra thời gian hợp lệ
            if (Reservation.ExpectBorrowAt < DateTime.UtcNow)
            {
                ModelState.AddModelError("Reservation.ExpectBorrowAt", "Thời gian mượn phải sau thời điểm hiện tại.");
                Message = "Thời gian mượn không hợp lệ.";
                MessageType = "danger";
                return Page();
            }

            if (Reservation.ExpectReturnAt <= Reservation.ExpectBorrowAt)
            {
                ModelState.AddModelError("Reservation.ExpectReturnAt", "Thời gian trả phải sau thời gian mượn.");
                Message = "Thời gian trả không hợp lệ.";
                MessageType = "danger";
                return Page();
            }

            // Đặt UserId cho Reservation
            Reservation.UserId = userId;

            // Kiểm tra trùng lặp đặt mượn
            var existingReservations = await _reservationService.GetByUserIdAsync(userId);
            if (existingReservations.Any(r => r.DeviceId == Reservation.DeviceId && r.Status != "canceled"))
            {
                ModelState.AddModelError("", "Bạn đã đặt mượn thiết bị này.");
                Message = "Bạn đã đặt mượn thiết bị này.";
                MessageType = "danger";
                return Page();
            }

            // Lưu đặt mượn
            try
            {
                await _reservationService.AddAsync(Reservation);
                Message = "Đặt mượn thành công! Vui lòng chờ xác nhận.";
                MessageType = "success";
            }
            catch (Exception ex)
            {
                Message = $"Lỗi khi đặt mượn: {ex.Message}";
                MessageType = "danger";
            }

            return Page();
        }
    }
}