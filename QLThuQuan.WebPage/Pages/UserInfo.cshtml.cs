using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QLThuQuan.Data.Models;
using QLThuQuan.Data.Services;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace QLThuQuan.WebPage.Pages
{
    public class UserInfoModel : PageModel
    {
        private readonly IAccountService _accountService;
        private readonly IBorrowService _borrowService;
        private readonly IReservationService _reservationService;
        private readonly IViolationService _violationService;
        [BindProperty(SupportsGet = false)]
        public InputModel Input { get; set; }

        [BindProperty(SupportsGet = false)]
        public ChangePasswordModel PasswordInput { get; set; }

        public User CurrentUser { get; set; }
        public List<BorrowRecord> BorrowHistory { get; set; }
        public List<Reservation> ReservationHistory { get; set; }
        public string ActiveSection { get; set; } = "info";
        public List<Violation> Violations { get; set; }
        public UserInfoModel(
            IAccountService accountService,
            IBorrowService borrowService,
            IReservationService reservationService,
            IViolationService violationService)
        {
            _accountService = accountService;
            _borrowService = borrowService;
            _reservationService = reservationService;
            _violationService = violationService;
        }

        public async Task<IActionResult> OnGetAsync(string section = "info")
        {
            ActiveSection = section;
            await LoadCurrentUser();

            if (CurrentUser == null)
            {
                return NotFound();
            }

            switch (section)
            {
                case "borrow-history":
                    BorrowHistory = await _borrowService.GetUserBorrowRecordsAsync(CurrentUser.Id);
                    break;
                case "reservation-history":
                    ReservationHistory = await _reservationService.GetUserReservationsAsync(CurrentUser.Id);
                    break;

                case "violations":
                    Violations = await _violationService.GetUserViolationsAsync(CurrentUser.Id);
                    Console.WriteLine($"Found {Violations?.Count ?? 0} violations for user {CurrentUser.Id}");
                    break;
                default:
                    break;
            }

            return Page();
        }



        private async Task LoadCurrentUser()
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            CurrentUser = await _accountService.GetByIdAsync(userId);

            if (CurrentUser != null)
            {

                Input = new InputModel
                {
                    FirstName = CurrentUser.FirstName,
                    LastName = CurrentUser.LastName,
                    Email = CurrentUser.Email
                };
            }
        }

        public async Task<IActionResult> OnPostUpdateInfoAsync()
        {

            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            Console.WriteLine(userId);
            try
            {
                var updatedUser = await _accountService.UpdateUserInfoAsync(
                    userId,
                    Input.FirstName,
                    Input.LastName,
                    Input.Email
                );

                if (updatedUser != null)
                {
                    await UpdateAuthenticationState(updatedUser);
                    TempData["SuccessMessage"] = "Cập nhật thông tin thành công!";
                }
                else
                {
                    TempData["ErrorMessage"] = "Không tìm thấy người dùng";
                }
            }
            catch (InvalidOperationException ex)
            {
                TempData["ErrorMessage"] = ex.Message;
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Lỗi khi cập nhật: {ex.Message}";
            }

            await LoadCurrentUser();
            return Page();
        }
        private async Task UpdateAuthenticationState(User user)
        {
            var claims = new List<Claim>
    {
        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
        new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}"),

    };

            var identity = new ClaimsIdentity(claims, "Custom");
            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(principal);
        }
        public async Task<IActionResult> OnPostChangePasswordAsync()
        {


            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            var success = await _accountService.ChangePasswordAsync(
                userId,
                PasswordInput.OldPassword,
                PasswordInput.NewPassword
            );

            if (success)
            {
                TempData["SuccessMessage"] = "Đổi mật khẩu thành công!";
            }
            else
            {
                TempData["ErrorMessage"] = "Mật khẩu cũ không đúng";
            }

            await LoadCurrentUser();
            return Page(); // Không Redirect để giữ lại thông báo
        }
        public class InputModel
        {
            [Required(ErrorMessage = "Họ là bắt buộc")]
            public string LastName { get; set; }

            [Required(ErrorMessage = "Tên là bắt buộc")]
            public string FirstName { get; set; }

            [Required(ErrorMessage = "Email là bắt buộc")]
            [EmailAddress(ErrorMessage = "Email không hợp lệ")]
            public string Email { get; set; }
        }

        public class ChangePasswordModel
        {
            [Required(ErrorMessage = "Mật khẩu cũ là bắt buộc")]
            public string OldPassword { get; set; }

            [Required(ErrorMessage = "Mật khẩu mới là bắt buộc")]
            [StringLength(100, MinimumLength = 6, ErrorMessage = "Mật khẩu phải từ 6-100 ký tự")]
            public string NewPassword { get; set; }

            [Compare("NewPassword", ErrorMessage = "Mật khẩu xác nhận không khớp")]
            public string ConfirmPassword { get; set; }
        }
    }
}