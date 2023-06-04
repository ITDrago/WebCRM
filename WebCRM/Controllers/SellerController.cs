using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using WebCRM.Data;
using WebCRM.Interfaces;
using WebCRM.Models;
using WebCRM.Repository;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace WebCRM.Controllers
{
    public class SellerController : Controller
    {
        private readonly ISellerRepository _sellerRepository;

        public SellerController(ISellerRepository sellerRepository)
        {
            _sellerRepository = sellerRepository;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<Seller> sellers = await _sellerRepository.GetAll();
            return View(sellers);
        }
        public IActionResult SellerAdd(Seller model)
        {
            if (model.Name != null)
            {
                _sellerRepository.Add(model);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");

        }
        [HttpPost]
        public IActionResult SellerDelete(int id)
        {
            var seller = _sellerRepository.GetById(id);
            if (seller != null)
            {
                _sellerRepository.Remove(seller);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult SellerEdit(int id, Seller model)
        {
            if (_sellerRepository.Edit(model, id))
                return RedirectToAction("Index");

            return RedirectToAction("Index");
        }
        
    }
}
