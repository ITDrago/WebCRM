using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebCRM.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        public string? Name { get; set; }
        public decimal Price { get; set; }

        public int Count { get; set; }

        public  ICollection<Sell>? Sells { get; set; }
    }
}
