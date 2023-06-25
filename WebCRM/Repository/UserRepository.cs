using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client.Extensibility;
using WebCRM.Data;
using WebCRM.Interfaces;
using WebCRM.Models;

namespace WebCRM.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ApplicationDbContext _context;

        public UserRepository(UserManager<AppUser> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }
        public  IEnumerable<AppUser> GetAll()
        {
            return  _userManager.Users.ToList();
        }
        public async Task<AppUser> GetByEmail(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }

        public bool Remove(AppUser user)
        {
            _context.Users.Remove(user);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0;
        }
    }
}
