using SQLite;

namespace CRUD_SQLITE.Models
{
    public class MAuth
    {
        [PrimaryKey, AutoIncrement]
        public int IdAuth { get; set; }
        [MaxLength(50)]
        public string User { get; set; } = "";
        [MaxLength(50)]
        public string Email { get; set; } = "";
        [MaxLength(300)]
        public string Password { get; set; } = "";
    }
}
