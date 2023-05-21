using System.ComponentModel.DataAnnotations;

namespace WebCRM.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        public string? Name { get; set; }

        public ICollection<Check>? Checks { get; set; }
    }
}
