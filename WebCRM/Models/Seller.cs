using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebCRM.Models
{
    public class Seller
    {
        [Key]
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? AppUserId { get; set; }
        public AppUser? AppUser { get; set; }

        public ICollection<Check>? Checks { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }
}
