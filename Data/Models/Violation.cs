using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace QLThuQuan.Data.Models
{
    public class Violation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int violation_id { get; set; }

        [Required]
        [ForeignKey("User")]
        public int user_id { get; set; }
        public virtual User User { get; set; }

        [Required]
        [ForeignKey("Rule")]
        public int rule_id { get; set; }
        public virtual Rule Rule { get; set; }

        [Required]
        public DateTime violated_at { get; set; } = DateTime.UtcNow;

        public DateTime? unban_at { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal? compensation_paid { get; set; }

        [Required]
        [MaxLength(20)]
        public string? status { get; set; } // 'active' or 'resolved'

        public string? notes { get; set; }
    }
}