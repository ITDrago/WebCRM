using WebCRM.Models;

namespace WebCRM.Interfaces
{
    public interface ISellerRepository
    {
        Task<IEnumerable<Seller>> GetAll();

        Seller GetById(int id);

        bool Add(Seller seller);

        bool Remove(Seller seller);

        bool Edit(Seller seller, int id);

        bool Save();
    }
}
