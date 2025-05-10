// Pages/Login.cshtml.cs
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QLThuQuan.Data.Models;
using QLThuQuan.Data.Services;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;

namespace QLThuQuan.WebPage.Pages
{
    public class LoginModel : PageModel
    {
        private readonly IAccountService _accountService;
      
        [BindProperty]
        public LoginInputModel Input { get; set; }

        public string ErrorMessage { get; set; }

        public class LoginInputModel
        {
            [Required(ErrorMessage = "Email là bắt buộc")]
            [EmailAddress(ErrorMessage = "Email không hợp lệ")]
            public string Email { get; set; }

            [Required(ErrorMessage = "Mật khẩu là bắt buộc")]
            public string Password { get; set; }
        }

        public LoginModel(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Kiểm tra xem người dùng có đang bị cấm không
            var activeViolation = await _accountService.GetActiveViolationAsync(Input.Email);
            if (activeViolation != null)
            {
                ErrorMessage = $"Tài khoản của bạn đang bị cấm do vi phạm: {activeViolation.Rule.Name}. " +
                              $"Thời gian cấm đến: {activeViolation.UnbanAt?.ToString("dd/MM/yyyy HH:mm")}";
                return Page();
            }

            var user = await _accountService.AuthenticateAsync(Input.Email, Input.Password);

            if (user == null)
            {
                ErrorMessage = "Email hoặc mật khẩu không đúng";
                return Page();
            }

            // Tạo claims identity
            var claims = new List<Claim>
    {
        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
        new Claim(ClaimTypes.Email, user.Email),
        new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}"),
        new Claim("IsAdmin", user.IsAdmin.ToString())
    };

            var claimsIdentity = new ClaimsIdentity(
                claims, CookieAuthenticationDefaults.AuthenticationScheme);

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity));

            return RedirectToPage("/Index");
        }
    }
}