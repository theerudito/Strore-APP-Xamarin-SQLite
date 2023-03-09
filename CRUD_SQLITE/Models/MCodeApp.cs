using SQLite;

namespace CRUD_SQLITE.Models
{
    public class MCodeApp
    {
        [PrimaryKey, AutoIncrement]
        public int IdCode { get; set; }
        public int CodeAdmin { get; set; }
    }
}
