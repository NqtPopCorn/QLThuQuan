using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLThuQuan.Data.Models
{
    public class User
    {
        // ID người dùng (khóa chính)
        [Key]
        [Column("user_id")]
        public int Id { get; set; }

        // Tên người dùng
        [Required]
        [StringLength(50)]
        [Column("firstName")]
        public string FirstName { get; set; }

        // Họ người dùng
        [Required]
        [StringLength(50)]
        [Column("lastName")]
        public string LastName { get; set; }

        // Email của người dùng
        [Required]
        [EmailAddress]
        [StringLength(100)]
        [Column("email")]
        public string Email { get; set; }

        // Mật khẩu người dùng
        [Required]
        [StringLength(100)]
        [Column("password")]
        public string Password { get; set; }

        // Quyền admin (true nếu là admin, false nếu không phải)
        [Column("isAdmin")]
        public bool IsAdmin { get; set; }

        // Thời gian tạo tài khoản
        [Column("createdAt")]
        public DateTime CreateAt { get; set; } = DateTime.UtcNow;
    }
}
