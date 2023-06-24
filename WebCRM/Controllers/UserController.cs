using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebCRM.Data;
using WebCRM.Models;
using WebCRM.Views.Account;

namespace WebCRM.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ApplicationDbContext _context;


        public UserController(UserManager<AppUser> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }
        [HttpGet("users")]
        public IActionResult Index()
        {
            IEnumerable<AppUser> users = _userManager.Users;
            return View(users);
        }
        [HttpGet("{email}")]
        public async Task<IActionResult> Delete(string email)
        { 
            if (email != null)
            {
                var user = _userManager.FindByEmailAsync(email);
                _context.Users.Remove(await user);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }

}
