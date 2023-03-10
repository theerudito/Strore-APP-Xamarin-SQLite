using SQLite;
using System.ComponentModel.DataAnnotations;

namespace CRUD_SQLITE.Models
{
    public class MReport
    {
        [Key]
        public int IdReport { get; set; }
        public int IdDetailCart { get; set; }
    }
}
