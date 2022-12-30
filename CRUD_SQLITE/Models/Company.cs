﻿using System.Data.SQLite;
using SQLite;


namespace CRUD_SQLITE.Models
{
    public class Company
    {
        [PrimaryKey, AutoIncrement]
        public int IdCompany { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(50)]
        public string Owner { get; set; }
        [MaxLength(50)]
        public string Direction { get; set; }
        [MaxLength(50)]
        public string Email { get; set; }
        [MaxLength(10)]
        public int RUC { get; set; }
        [MaxLength(50)]
        public int Phone { get; set; }
        [MaxLength(50)]
        public int NumDocument { get; set; }
        [MaxLength(50)]
        public int Serie1 { get; set; }
        [MaxLength(50)]
        public int Serie2 { get; set; }
        [MaxLength(50)]
        public string DB { get; set; }
        [MaxLength(50)]
        public string Document { get; set; }
        [MaxLength(15)]
        public decimal Iva { get; set; }
        [MaxLength(50)]
        public string Current { get; set; }
        [MaxLength(10)]
        public string Code { get; set; }

    }
}