using Microsoft.EntityFrameworkCore;
using WebCRM.Data;
using WebCRM.Interfaces;
using WebCRM.Models;

namespace WebCRM.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool Add(Product product)
        {
            _context.Add(product);
            return Save();
        }

        public bool Edit(Product product, int id)
        {
            var editedProduct = _context.Products.Find(id);
            if (editedProduct != null && editedProduct.Name != null && editedProduct.Price >= 0 && editedProduct.Count > 0)
            {
                if (product.Name != null && product.Name != null && product.Price >= 0 && product.Count > 0)
                {
                    editedProduct!.Name = product.Name;
                    editedProduct!.Price = product.Price;
                    editedProduct!.Count = product.Count;
                    return Save();
                }
            }
            return false;
        }
        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _context.Products.ToListAsync();
        }

        public Product GetById(int id)
        {
            return _context.Products.Find(id)!;
        }

        public bool Remove(Product product)
        {
            _context.Remove(product);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0;
        }
    }
}

