using System.ComponentModel.DataAnnotations;

namespace CRUD_SQLITE.Models
{
    public class MCodeApp
    {
        [Key]
        public int IdCode { get; set; }

        public string CodeAdmin { get; set; } = "";
    }
}