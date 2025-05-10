using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QLThuQuan.Data.Services;
using QLThuQuan.Services;

namespace QLThuQuan.WebPage.Pages
{
    public class ForgotPasswordModel : PageModel
    {
        private readonly IAccountService _accountService;
        private readonly EmailService _emailService;

        [BindProperty]
        [Required(ErrorMessage = "Vui lòng nhập email")]
        [EmailAddress(ErrorMessage = "Email không hợp lệ")]
        public string Email { get; set; }

        [TempData]
        public string Message { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }

        public ForgotPasswordModel(
            IAccountService accountService,
            EmailService emailService)
        {
            _accountService = accountService;
            _emailService = emailService;
        }

        public void OnGet()
        {
            // Hiển thị thông báo từ TempData nếu có
            if (TempData["Message"] != null)
            {
                Message = TempData["Message"] as string;
            }
            if (TempData["ErrorMessage"] != null)
            {
                ErrorMessage = TempData["ErrorMessage"] as string;
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                var user = await _accountService.GetByEmailAsync(Email);
                if (user != null)
                {
                    // Tạo link reset mật khẩu
                    var resetLink = Url.Page(
                        "/ResetPassword",
                        pageHandler: null,
                        values: new { email = Email },
                        protocol: Request.Scheme);

                    // Tạo nội dung email
                    var emailSubject = "Đặt lại mật khẩu - Hệ thống Quản lý Thư quán";
                    var emailMessage = $@"
                        <div style='font-family: Arial, sans-serif; max-width: 600px; margin: 0 auto;'>
                            <h2 style='color: #2b6cb0;'>Yêu cầu đặt lại mật khẩu</h2>
                            <p>Xin chào,</p>
                            <p>Chúng tôi nhận được yêu cầu đặt lại mật khẩu cho tài khoản của bạn.</p>
                            <p>Vui lòng nhấp vào nút bên dưới để đặt lại mật khẩu:</p>
                            <p>
                                <a href='{resetLink}' 
                                   style='display: inline-block; padding: 10px 20px; background-color: #4299e1; 
                                          color: white; text-decoration: none; border-radius: 4px;'>
                                    Đặt lại mật khẩu
                                </a>
                            </p>
                            <p>Link sẽ hết hạn sau 24 giờ.</p>
                            <p>Nếu bạn không yêu cầu đặt lại mật khẩu, vui lòng bỏ qua email này.</p>
                            <p>Trân trọng,<br>Đội ngũ hỗ trợ</p>
                        </div>";

                    // Gửi email
                    await _emailService.SendEmailAsync(Email, emailSubject, emailMessage);
                }

                // Luôn hiển thị thông báo thành công (bảo mật)
                Message = "Nếu email tồn tại, chúng tôi đã gửi link đặt lại mật khẩu. Vui lòng kiểm tra email của bạn.";
                return RedirectToPage("/ForgotPasswordConfirmation");
            }
            catch (Exception ex)
            {
                ErrorMessage = "Đã xảy ra lỗi khi xử lý yêu cầu. Vui lòng thử lại sau.";
                Console.WriteLine($"Lỗi gửi email reset mật khẩu: {ex.Message}");
                return Page();
            }
        }
    }
}