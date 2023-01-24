using SQLite;
using System;

namespace CRUD_SQLITE.Models
{
    public class MProduct
    {
        [PrimaryKey, AutoIncrement]
        public int IdProduct { get; set; }
        [MaxLength(50)]
        public string NameProduct { get; set; } = "";
        [MaxLength(50)]
        public string CodeProduct { get; set; } = "";
        [MaxLength(50)]
        public string Brand { get; set; } = "";
        [MaxLength(50)]
        public string Description { get; set; } = "";
        [MaxLength(50)]
        public int Quantity { get; set; }
        [MaxLength(50)]
        public float P_Unitary { get; set; }
        [MaxLength(50)]
        public float P_Total { get; set; }
        [MaxLength(50)]
        public string Image_Product { get; set; } = "";
        [MaxLength(100)]
        public DateTime created_at { get; set; }
        [MaxLength(100)]
        public DateTime updated_at { get; set; }
    }
}
