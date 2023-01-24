using SQLite;
using System;

namespace CRUD_SQLITE.Models
{
    public class MDetailsCart
    {
        [PrimaryKey, AutoIncrement]
        public int IdDetailCart { get; set; }
        [MaxLength(50)]
        public int IdCart { get; set; }
        [MaxLength(50)]
        public string Date_Now { get; set; } = "";
        [MaxLength(50)]
        public string Hour_Now { get; set; } = "";
        [MaxLength(50)]
        public float Subtotal { get; set; }
        [MaxLength(50)]
        public float Subtotal12 { get; set; }
        [MaxLength(50)]
        public float SubTotal0 { get; set; }
        [MaxLength(50)]
        public float IvaTotal { get; set; }
        [MaxLength(50)]
        public float Total { get; set; }
        [MaxLength(100)]
        public DateTime created_at { get; set; }
        [MaxLength(100)]
        public DateTime updated_at { get; set; }
    }
}
