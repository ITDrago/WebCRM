using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Policy;

namespace WebCRM.Models
{
    public class Check
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public  Customer? Customer { get; set; }
        [ForeignKey("Seller")]
        public int SellerId { get; set; }

        public  Seller? Seller { get; set; }

        public DateTime Created { get; set; }

        
    }
}
