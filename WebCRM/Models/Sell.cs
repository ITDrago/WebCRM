using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebCRM.Models
{
    public class Sell
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public  Product? Product { get; set; }
        [ForeignKey("Check")]
        public int CheckId { get; set; }
        public Check? Check { get; set; }
    }
}
