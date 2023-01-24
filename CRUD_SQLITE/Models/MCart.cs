using SQLite;

namespace CRUD_SQLITE.Models
{
    public class MCart
    {
        [PrimaryKey, AutoIncrement]
        public int IdCart { get; set; }
        [MaxLength(50)]
        public int IdClient { get; set; }
        [MaxLength(50)]
        public int IdProduct { get; set; }
        [MaxLength(50)]
        public float P_Total { get; set; }
    }
}
