using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLThuQuan.Data.Models
{
    [Serializable]
    [Table("violations")]
    public class Violation
    {
        [Key]
        [Column("violation_id")]
        public int Id { get; set; }

        [Column("user_id")]
        public int UserId { get; set; }

        [Column("rule_id")]
        public int RuleId { get; set; }

        [Column("notes")]
        public string? Description { get; set; }

        [Column("violation_date")]
        public DateTime ViolationDate { get; set; } = DateTime.Now;

        [Column("unban_at")]
        public DateTime? UnbanAt { get; set; } = null;

        [Column("status")]
        public string Status { get; set; } = "pending"; // 'active','resolved','pending'

        [Column("UserId")]
        public User User { get; set; }

        [Column("RuleId")]
        public Rule Rule { get; set; }

        [Column("compensation_paid")]
        public Decimal? CompensationPaid { get; set; }
    }
}
