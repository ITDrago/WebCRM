using Microsoft.AspNetCore.Mvc;
using WebCRM.Data;
using WebCRM.Interfaces;
using WebCRM.Models;
using WebCRM.Repository;

namespace WebCRM.Controllers
{
    public class SellController : Controller
    {
        private readonly IProductRepository _productRepositrory;
        private readonly ApplicationDbContext _context;
        private readonly ICustomerRepository _customerRepository;
        public SellController(IProductRepository productRepositrory, ApplicationDbContext context, ICustomerRepository customerRepository)
        {
            _productRepositrory = productRepositrory;
            _context = context;
            _customerRepository = customerRepository;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<Product> products = await _productRepositrory.GetAll();
            return View(products);
        }
        [HttpGet("{price:decimal}")]
        public IActionResult Buy(decimal price)
        {
            Cart.AllPrice += price;
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Pay(string name)
        {
            var customer = new Customer() { Name = name };
            var check = new Check
            {
                Customer = customer,
                Seller = _context.Sellers.FirstOrDefault(),
                Created = DateTime.Now
            };
            _customerRepository.Add(customer);
            _context.Checks.Add(check);
            _context.SaveChanges();
            Cart.AllPrice = 0;
            return RedirectToAction("Index");
        } 
    }
}
