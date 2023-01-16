using SQLite;

namespace CRUD_SQLITE.Models
{
    public class MProduct
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(50)]
        public int Code { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(50)]
        public string Brand { get; set; }
        [MaxLength(50)]
        public string Description { get; set; }
        [MaxLength(50)]
        public decimal Price { get; set; }
        [MaxLength(50)]
        public decimal P_Total { get; set; }
        [MaxLength(50)]
        public int Quantity { get; set; }
        [MaxLength(500)]
        public string ImageProduct { get; set; }
    }
}
