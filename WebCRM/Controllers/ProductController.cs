using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebCRM.Data;
using WebCRM.Interfaces;
using WebCRM.Models;
using WebCRM.Repository;

namespace WebCRM.Controllers
{
    public class ProductController : Controller
    { 
        private readonly IProductRepository _productRepositrory;

        public ProductController(IProductRepository productRepositrory)
        {
           _productRepositrory = productRepositrory;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<Product> products = await _productRepositrory.GetAll();
            return View(products);
        }
        [HttpPost]
        public IActionResult ProductAdd(Product model)
        {
            if (model.Name != null && model.Price >=0 && model.Count > 0)
            {
                _productRepositrory.Add(model);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");

        }
        [HttpPost]
        public IActionResult ProductDelete(int id)
        {
            var product = _productRepositrory.GetById(id);
            if (product != null)
            {
                _productRepositrory.Remove(product);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");

        }
        [HttpPost]
        public IActionResult ProductEdit(int id, Product model)
        {
            if(_productRepositrory.Edit(model,id))
                return RedirectToAction("Index");
                
            return RedirectToAction("Index");

        }
    }
}
