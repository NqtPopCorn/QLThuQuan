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
    [Table("reservations")]
    public class Reservation
    {

        //        +------------------+----------------------------------------+------+-----+-------------------+-------------------+
        //| Field            | Type                                   | Null | Key | Default           | Extra             |
        //+------------------+----------------------------------------+------+-----+-------------------+-------------------+
        //| reservation_id   | int                                    | NO   | PRI | NULL              | auto_increment    |
        //| user_id          | int                                    | NO   | MUL | NULL              |                   |
        //| device_id        | int                                    | NO   | MUL | NULL              |                   |
        //| expect_borrow_at | timestamp                              | NO   |     | NULL              |                   |
        //| expect_return_at | timestamp                              | NO   |     | NULL              |                   |
        //| reservation_at   | timestamp                              | NO   |     | CURRENT_TIMESTAMP | DEFAULT_GENERATED |
        //| status           | enum('pending','confirmed','canceled') | NO   |     | NULL              |                   |
        //+------------------+----------------------------------------+------+-----+-------------------+-------------------+

        [Key]
        [Column("reservation_id")]
        public int Id { get; set; }

        [Column("user_id")]
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        [Column("device_id")]
        public int DeviceId { get; set; }

        [ForeignKey("DeviceId")]
        public virtual Device Device { get; set; }

        [Column("expect_borrow_at")]
        public DateTime ExpectBorrowAt { get; set; } = DateTime.Now;

        [Column("expect_return_at")]
        public DateTime ExpectReturnAt { get; set; } = DateTime.Now;

        [Column("reservation_at")]
        public DateTime ReservationAt { get; set; } = DateTime.Now;

        [Column("status")]
        public string Status { get; set; } // pending, confirmed, canceled

    }
}
