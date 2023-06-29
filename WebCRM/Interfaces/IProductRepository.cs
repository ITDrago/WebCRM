using WebCRM.Models;

namespace WebCRM.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAll();

        Product GetById(int id);

        bool Add(Product product);

        bool Remove(Product product);

        bool Edit(Product product, int id);

        bool Save();
    }
}
