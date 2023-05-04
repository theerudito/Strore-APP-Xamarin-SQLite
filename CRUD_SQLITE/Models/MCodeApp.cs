using System.ComponentModel.DataAnnotations;

namespace MyStore.Models
{
    public class MCodeApp
    {
        [Key]
        public int IdCode { get; set; }

        public string CodeAdmin { get; set; } = "";
    }
}