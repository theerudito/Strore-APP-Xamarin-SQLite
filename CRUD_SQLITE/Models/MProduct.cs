using System;
using System.Data.SQLite;
using System.Threading.Tasks;
using SQLite;

namespace CRUD_SQLITE.Models
{
    public class MProduct
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(50)]
        public string Code { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(50)]
        public string Brand { get; set; }

        [MaxLength(50)]
        public string Description { get; set; }

        [MaxLength(50)]
        public decimal Price { get; set; }

        [MaxLength(50)]
        public int Quantity { get; set; }

        public static explicit operator MProduct(Task<bool> v)
        {
            throw new NotImplementedException();
        }
    }
}
