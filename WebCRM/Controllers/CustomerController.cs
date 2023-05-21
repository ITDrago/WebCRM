using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using WebCRM.Data;
using WebCRM.Models;

namespace WebCRM.Controllers
{
    public class CustomerController:Controller
    {
        private readonly ApplicationDbContext _context;

        public CustomerController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Customer> customers = _context.Customers.ToList();
            return View(customers);

        }
    }
}
