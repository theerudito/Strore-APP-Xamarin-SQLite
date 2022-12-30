using System.Data.SQLite;
using SQLite;

namespace CRUD_SQLITE.Models
{
    public class MClient
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(15)]
        public int DNI { get; set; }

        [MaxLength(50)]
        public string FirstName { get; set; }

        [MaxLength(50)]
        public string LastName { get; set; }

        [MaxLength(100)]
        public string Direction { get; set; }

        [MaxLength(10)]
        public int Phone { get; set; }

        [MaxLength(60)]
        public string Email { get; set; }

        [MaxLength(50)]
        public string City { get; set; }
    }
}
