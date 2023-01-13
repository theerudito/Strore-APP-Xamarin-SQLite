using SQLite;

namespace CRUD_SQLITE.Models
{
    public class Code
    {
        [PrimaryKey, AutoIncrement]
        public int IdCode { get; set; }
        [MaxLength(50)]
        public string CodeAdmin { get; set; }

    }
}
