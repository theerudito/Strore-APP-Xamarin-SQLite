using SQLite;
using System;

namespace CRUD_SQLITE.Models
{
    public class MClient
    {
        [PrimaryKey, AutoIncrement]
        public int IdClient { get; set; }
        [MaxLength(50)]
        public string DNI { get; set; } = "";
        [MaxLength(50)]
        public string FirstName { get; set; } = "";
        [MaxLength(50)]
        public string LastName { get; set; } = "";
        [MaxLength(50)]
        public string Direction { get; set; } = "";
        [MaxLength(50)]
        public string Phone { get; set; } = "";
        [MaxLength(50)]
        public string Email { get; set; } = "";
        [MaxLength(50)]
        public string City { get; set; } = "";
        [MaxLength(100)]
        public DateTime created_at { get; set; }
        [MaxLength(100)]
        public DateTime updated_at { get; set; }
    }
}
