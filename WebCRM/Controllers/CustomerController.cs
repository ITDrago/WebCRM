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
        [HttpGet]
        public IActionResult Index()
        {
            List<Customer> customers = _context.Customers.ToList();
            return View(customers);
        }
        [HttpPost]
        public IActionResult CustomerAdd(Customer model)
        {
            if (model.Name != null)
            {
                _context.Customers.Add(model);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");

        }
        [HttpPost] 
        public IActionResult CustomerDelete(int id)
        {
            var customer = _context.Sellers.Find(id);
            if (customer != null)
            {
                _context.Customers.Remove(_context.Customers.Single(x => x.Id == id));
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");

        }
        [HttpPost]
        public IActionResult CustomerEdit(int id, Customer model)
        {
            var tmpCustomer = _context.Sellers.Find(id);
            if (tmpCustomer != null)
            {
                var customer = _context.Customers.Single(x => x.Id == id);
                customer.Name = model.Name;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}
