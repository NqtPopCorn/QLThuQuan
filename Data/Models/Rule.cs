using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLThuQuan.Data.Models
{
    public enum PenaltyType
    {
        ban_account,
        compensation,
        warning,
        other
    }

    public class Rule
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int rule_id { get; set; }

        [Required]
        [MaxLength(255)]
        public string rule_name { get; set; }

        public string? description { get; set; }

        [Required]
        [Column(TypeName = "ENUM('ban_account','compensation','warning','other')")]
        public PenaltyType penalty_type { get; set; }

        public int? ban_days { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal compensation_amount { get; set; }

        public virtual ICollection<Violation> Violations { get; set; } = new List<Violation>();
    }
}
