using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLThuQuan.Data.Models
{
    [Serializable]
    [Table("devices")]
    public class Device
    {
        [Key]
        [Column("device_id")]
        public int Id { get; set; }

        [Column("device_name")]
        public string Name { get; set; }

        [Column("description")]
        public string Description { get; set; }

        [Column("status")]
        [Required]
        public string Status { get; set; }

        [Column("image_path")]
        public string? ImagePath { get; set; }
    }
}
