using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLThuQuan.Data.Models
{
    public class CheckIns
    {
        [Key]
        [Column("log_id")]
        public int Id { get; set; }

        // Chỉ có trường điều hướng User (không có UserId)
        public User User { get; set; }

        [Column("check_in")]
        public DateTime CheckIn { get; set; }
        [Column("check_out")]
        public DateTime? CheckOut { get; set; }
    }
}
