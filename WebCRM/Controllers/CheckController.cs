using Microsoft.AspNetCore.Mvc;
using System.Data.Entity;
using WebCRM.Data;
using WebCRM.Interfaces;
using WebCRM.Models;
using WebCRM.Repository;

namespace WebCRM.Controllers
{
    public class CheckController : Controller
    {
        private readonly ApplicationDbContext _context;
        public CheckController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public  IActionResult Index()
        {
            IEnumerable<Check> checks = _context.Checks.ToList();
            return View(checks);
        }
        [HttpPost]
        public  IActionResult Delete(int id)
        {
            if (id != null && id > 0)
            {
                var check = _context.Checks.Find(id);
                _context.Checks.Remove(check);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}
