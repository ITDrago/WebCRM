using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using WebCRM.Data;
using WebCRM.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace WebCRM.Controllers
{
    public class SellerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SellerController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            List<Seller> sellers = _context.Sellers.ToList();
            return View(sellers);
        }
        public IActionResult SellerAdd(Seller model)
        {
            if (model.Name != null)
            { 
                _context.Sellers.Add(model);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");

        }
        [HttpPost]
        public IActionResult SellerDelete(int id)
        {
            var seller = _context.Sellers.Find(id);
            if (seller != null)
            {
                _context.Sellers.Remove(_context.Sellers.Single(x => x.Id == id));
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult SellerEdit(int id, Seller model)
        {
            var tmpSeller = _context.Sellers.Find(id);
            if (tmpSeller != null && tmpSeller.Name != null)
            {
                var seller = _context.Sellers.Single(x => x.Id == id);
                if (model.Name != null)
                {
                    seller.Name = model.Name;
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Index");
        }
        
    }
}
