using SQLite;

namespace CRUD_SQLITE.Models
{
    public class MCart
    {
        [PrimaryKey, AutoIncrement]
        public int IdCart { get; set; }
        public MClient client { get; set; }
        public MProduct product { get; set; }
        public Company company { get; set; }
        [MaxLength(50)]
        public decimal SubTotal { get; set; }
        [MaxLength(50)]
        public decimal Descuent { get; set; }
        [MaxLength(50)]
        public decimal SubTotal12 { get; set; }
        [MaxLength(50)]
        public decimal SubTotal0 { get; set; }
        [MaxLength(50)]
        public decimal Total { get; set; }
        [MaxLength(50)]
        public decimal IvaCart { get; set; }

    }
}
