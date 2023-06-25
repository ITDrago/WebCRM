using WebCRM.Models;

namespace WebCRM.Interfaces
{
    public interface IUserRepository
    {

        IEnumerable<AppUser> GetAll();
        Task<AppUser>  GetByEmail(string email);
        bool Remove(AppUser user);

        bool Save();

    }
}
