// RegisterModel.cs
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QLThuQuan.Data;
using QLThuQuan.Data.Models;
using BCrypt.Net;
using QLThuQuan.Data.Services;
using System.Threading.Tasks;

namespace QLThuQuan.WebPage.Pages
{
    public class RegisterModel : PageModel
    {
        private readonly IAccountService _accountService;

        [BindProperty]
        public User User { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Vui lòng xác nhận mật khẩu")]
        public string ConfirmPassword { get; set; }

        public string ErrorMessage { get; set; }

        public RegisterModel(IAccountService accountService)
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
                ErrorMessage = string.Join("<br>",
                    ModelState.Values.SelectMany(v => v.Errors)
                                   .Select(e => e.ErrorMessage));
                return Page();
            }

            if (!new EmailAddressAttribute().IsValid(User.email))
            {
                ModelState.AddModelError("User.email", "Email không hợp lệ");
                return Page();
            }

            if (User.password != ConfirmPassword)
            {
                ModelState.AddModelError("ConfirmPassword", "Mật khẩu không khớp");
                return Page();
            }

            if (await _accountService.IsEmailExistAsync(User.email))
            {
                ErrorMessage = "Email đã được sử dụng";
                return Page();
            }

            try
            {
                User.password = BCrypt.Net.BCrypt.HashPassword(User.password);
                User.isAdmin = 0;

                await _accountService.AddAsync(User);

                TempData["SuccessMessage"] = "Đăng ký thành công!";
                return RedirectToPage("/Login");
            }
            catch (Exception ex)
            {
                ErrorMessage = $"Có lỗi xảy ra khi đăng ký: {ex.Message}";
                return Page();
            }
        }
    }
}