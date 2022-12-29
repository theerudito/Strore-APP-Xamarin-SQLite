using System.Data.SQLite;
using SQLite;

namespace CRUD_SQLITE.Models
{
    public class Cart
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        // product
        [MaxLength(50)]
        public string NameProduct { get; set; }
        [MaxLength(50)]
        public string Code { get; set; }
        [MaxLength(50)]
        public string Brand { get; set; }
        [MaxLength(50)]
        public string Description { get; set; }
        [MaxLength(50)]
        public double vUnitary { get; set; }
        [MaxLength(50)]
        public int Quantity { get; set; }
        [MaxLength(50)]
        public double vTotal { get; set; }

        // client 
        [MaxLength(50)]
        public string FirstName { get; set; }
        [MaxLength(50)]
        public string LastName { get; set; }
        [MaxLength(50)]
        public int DNI { get; set; }
        [MaxLength(50)]
        public string Direction { get; set; }
        [MaxLength(50)]
        public string Email { get; set; }
        [MaxLength(50)]
        public int Phone { get; set; }

        // total factura

        [MaxLength(50)]
        public double Total { get; set; }

        // fecha
        [MaxLength(50)]
        public string Date { get; set; }

        // hora
        [MaxLength(50)]
        public string Hour { get; set; }

    }
}
