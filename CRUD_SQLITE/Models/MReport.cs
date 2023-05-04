using System.ComponentModel.DataAnnotations;

namespace MyStore.Models
{
    public class MReport
    {
        [Key]
        public int IdReport { get; set; }

        public int IdDetailCart { get; set; }
    }
}