using System.ComponentModel.DataAnnotations;

namespace QLThuQuan.Data.Models
{
    public class User
    {
        // ID người dùng (khóa chính)
        [Key]
        public int Id { get; set; }

        // Tên người dùng
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        // Họ người dùng
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        // Email của người dùng
        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; }

        // Mật khẩu người dùng
        [Required]
        [StringLength(100)]
        public string Password { get; set; }

        // Quyền admin (true nếu là admin, false nếu không phải)
        public bool IsAdmin { get; set; }

        // Thời gian tạo tài khoản
        public DateTime CreateAt { get; set; } = DateTime.UtcNow;
    }
}
