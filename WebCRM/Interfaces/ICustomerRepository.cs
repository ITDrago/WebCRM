using WebCRM.Models;

namespace WebCRM.Interfaces
{
    public interface ICustomerRepository
    {
        Task <IEnumerable<Customer>> GetAll();

        Customer GetById (int id);

        bool Add (Customer customer);

        bool Remove (Customer customer);

        bool Edit (Customer customer, int id);

        bool Save();
    }
}
