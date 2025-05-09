using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLThuQuan.Data.Models
{
    [Serializable]
    [Table("borrow_records")]
    public class BorrowRecord
    {
        //        +-------------+----------------------------------------+------+-----+-------------------+-------------------+
        //| Field       | Type                                   | Null | Key | Default           | Extra             |
        //+-------------+----------------------------------------+------+-----+-------------------+-------------------+
        //| borrow_id   | int                                    | NO   | PRI | NULL              | auto_increment    |
        //| user_id     | int                                    | NO   | MUL | NULL              |                   |
        //| device_id   | int                                    | NO   | MUL | NULL              |                   |
        //| borrowed_at | timestamp                              | NO   |     | CURRENT_TIMESTAMP | DEFAULT_GENERATED |
        //| due_at      | timestamp                              | NO   |     | NULL              |                   |
        //| returned_at | timestamp                              | YES  |     | NULL              |                   |
        //| status      | enum('borrowed','returned','over_due') | NO   |     | NULL              |                   |
        //+-------------+----------------------------------------+------+-----+-------------------+-------------------+

        [Key]
        [Column("borrow_id")]
        public int Id { get; set; }

        [Column("user_id")]
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        [Column("device_id")]
        public int DeviceId { get; set; }

        [ForeignKey("DeviceId")]
        public virtual Device Device { get; set; }

        [Column("borrowed_at")]
        public DateTime BorrowedAt { get; set; }

        [Column("due_at")]
        public DateTime DueAt { get; set; }

        [Column("returned_at")]
        public DateTime? ReturnedAt { get; set; }

        [Column("status")]
        public string Status { get; set; } // borrowed, returned, over_due

    }
}
