using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLThuQuan.Data.Models
{
    public class CheckIns
    {
        [Key]
        public int Id { get; set; }

        // Chỉ có trường điều hướng User (không có UserId)
        public User User { get; set; }

        public DateTime CheckIn { get; set; }
        public DateTime? CheckOut { get; set; }
    }
}
