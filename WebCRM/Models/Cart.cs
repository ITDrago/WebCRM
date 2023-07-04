using System.ComponentModel.DataAnnotations.Schema;

namespace WebCRM.Models
{
    public static class Cart
    {
        [Column(TypeName = "decimal(18.2)")]
        public static  decimal AllPrice { get; set; }
    }
}
