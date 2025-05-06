using System.ComponentModel.DataAnnotations;

namespace QLThuQuan.Data.Models
{
    public class User
    {
        public int user_id { get; set; }

        [Required(ErrorMessage = "Họ là bắt buộc")]
        public string lastName { get; set; }

        [Required(ErrorMessage = "Tên là bắt buộc")]
        public string firstName { get; set; }

        [Required(ErrorMessage = "Email là bắt buộc")]
        [EmailAddress(ErrorMessage = "Email không hợp lệ")]
        public string email { get; set; }

        [Required(ErrorMessage = "Mật khẩu là bắt buộc")]
        [StringLength(255, MinimumLength = 6, ErrorMessage = "Mật khẩu phải từ 6-255 ký tự")]
        public string password { get; set; }

        public int isAdmin { get; set; } = 0;
    }
}