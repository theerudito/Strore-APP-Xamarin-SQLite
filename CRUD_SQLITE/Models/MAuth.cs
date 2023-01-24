using SQLite;
using System;

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
        [MaxLength(50)]
        public string Password { get; set; } = "";
        [MaxLength(100)]
        public DateTime created_at { get; set; }
        [MaxLength(100)]
        public DateTime updated_at { get; set; }
    }
}
