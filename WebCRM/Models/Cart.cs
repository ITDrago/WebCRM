using Microsoft.Extensions.Caching.Memory;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebCRM.Models
{
    public static class Cart
    {
        private static readonly MemoryCache _cache = new MemoryCache(new MemoryCacheOptions());

        [Column(TypeName = "decimal(18.2)")]
        public static  decimal AllPrice { get; set; }
        public static List<decimal> CartHistory
        {
            get
            {
                if (!_cache.TryGetValue("cartHistory", out List<decimal> list))
                {
                    list = new List<decimal>();
                    _cache.Set("cartHistory", list);
                }
                return list;
            }
        }




    }
}
