using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebCRM.Data;
using WebCRM.Interfaces;
using WebCRM.Models;
using WebCRM.Views.Account;

namespace WebCRM.Controllers
{
    public class UserController : Controller
    {
        //private readonly UserManager<AppUser> _userManager;
        //private readonly ApplicationDbContext _context;
        private readonly IUserRepository _userRepository;


        public UserController(IUserRepository userRepository)
        {
            //_userManager = userManager;
            //_context = context;
            _userRepository = userRepository;
        }
        [HttpGet("users")]
        public IActionResult Index()
        {
            IEnumerable<AppUser> users = _userRepository.GetAll();
            return View(users);
        }
        [HttpGet("{email}")]
        public async Task<IActionResult> Delete(string email)
        { 
            if (email != null)
            {
                var user = _userRepository.GetByEmail(email);
                _userRepository.Remove(await user);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }

}
