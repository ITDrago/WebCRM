using Microsoft.EntityFrameworkCore;
using WebCRM.Data;
using WebCRM.Interfaces;
using WebCRM.Models;

namespace WebCRM.Repository
{
    public class SellerRepository : ISellerRepository
    {
        private readonly ApplicationDbContext _context;

        public SellerRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool Add(Seller seller)
        {
            _context.Add(seller);
            return Save();
        }

        public bool Edit(Seller seller, int id)
        {
            var editedSeller = _context.Sellers.Find(id);
            if (editedSeller != null && editedSeller.Name != null)
            {
                if (seller.Name != null)
                {
                    editedSeller!.Name = seller.Name;
                    return Save();
                }
            }
            return false;
        }

        public async Task<IEnumerable<Seller>> GetAll()
        {
            return await _context.Sellers.ToListAsync();
        }

        public Seller GetById(int id)
        {
            return _context.Sellers.Find(id)!;
        }

        public bool Remove(Seller seller)
        {
            _context.Remove(seller);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0;
        }
    }
}
