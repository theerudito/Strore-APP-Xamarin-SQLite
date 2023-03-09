using SQLite;

namespace CRUD_SQLITE.Models
{
    public class MReport
    {
        [PrimaryKey, AutoIncrement]
        public int IdReport { get; set; }
        public int IdDetailCart { get; set; }
    }
}
