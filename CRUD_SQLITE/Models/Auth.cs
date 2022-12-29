using System.Data.SQLite;
using SQLite;

namespace CRUD_SQLITE.Models
{
    public class Auth
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(50)]
        public string Email { get; set; }

        [MaxLength(50)]
        public string Password { get; set; }

    }
}
