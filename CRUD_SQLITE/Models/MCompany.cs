using SQLite;
using System;

namespace CRUD_SQLITE.Models
{
    public class MCompany
    {
        [PrimaryKey, AutoIncrement]
        public int IdCompany { get; set; }
        [MaxLength(50)]
        public string NameCompany { get; set; } = "";
        [MaxLength(50)]
        public string NameOwner { get; set; } = "";
        [MaxLength(50)]
        public string Direction { get; set; } = "";
        [MaxLength(50)]
        public string Email { get; set; } = "";
        [MaxLength(50)]
        public string RUC { get; set; } = "";
        [MaxLength(50)]
        public string Phone { get; set; } = "";
        public int NumDocument { get; set; }
        [MaxLength(50)]
        public string Serie1 { get; set; } = "";
        [MaxLength(50)]
        public string Serie2 { get; set; } = "";
        [MaxLength(50)]
        public string Document { get; set; } = "";
        [MaxLength(50)]
        public string DB { get; set; } = "";
        public float Iva { get; set; }
        [MaxLength(50)]
        public string Coin { get; set; } = "";
        [MaxLength(100)]
        public DateTime created_at { get; set; }
        [MaxLength(100)]
        public DateTime updated_at { get; set; }
    }
}
