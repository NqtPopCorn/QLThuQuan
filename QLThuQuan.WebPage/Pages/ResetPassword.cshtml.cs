using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QLThuQuan.Data.Services;

namespace QLThuQuan.WebPage.Pages
{
    public class ResetPasswordModel : PageModel
    {
        private readonly IAccountService _accountService;

        public ResetPasswordModel(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [BindProperty]
        public string Email { get; set; }

        [BindProperty]
        public string NewPassword { get; set; }

        public void OnGet(string email)
        {
            Email = email;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _accountService.GetByEmailAsync(Email);
            if (user != null)
            {
                user.Password = BCrypt.Net.BCrypt.HashPassword(NewPassword);
                await _accountService.UpdateAsync(user);
            }

            return RedirectToPage("/ResetPasswordConfirmation");
        }
    }
}