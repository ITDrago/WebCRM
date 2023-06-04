using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using WebCRM.Data;
using WebCRM.Interfaces;
using WebCRM.Models;

namespace WebCRM.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDbContext _context;

        public CustomerRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool Add(Customer customer)
        {
            _context.Add(customer);
            return Save();
        }

        public bool Edit(Customer customer, int id)
        {
            var editedCustomer = _context.Customers.Find(id);
            if (editedCustomer != null && editedCustomer.Name != null)
            {
                if (customer.Name != null)
                {
                    editedCustomer!.Name = customer.Name;
                    return Save();
                }
            }
            return false;
        }

        public async Task<IEnumerable<Customer>> GetAll()
        {
            return await  _context.Customers.ToListAsync();
        }

        public  Customer GetById(int id)
        {
            return _context.Customers.Find(id)!;
        }

        public bool Remove(Customer customer)
        {
            _context.Remove(customer);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0;
        }
    }
}
