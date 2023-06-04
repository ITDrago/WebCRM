using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using WebCRM.Data;
using WebCRM.Interfaces;
using WebCRM.Models;

namespace WebCRM.Controllers
{
    public class CustomerController:Controller
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<Customer> customers = await  _customerRepository.GetAll();
            return View(customers);
        }
        [HttpPost]
        public IActionResult CustomerAdd(Customer model)
        {
            if (model.Name != null)
            {
                _customerRepository.Add(model);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");

        }
        [HttpPost] 
        public IActionResult CustomerDelete(int id)
        {
            var customer = _customerRepository.GetById(id);
            if (customer != null)
            {
                _customerRepository.Remove(customer);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");

        }
        [HttpPost]
        public IActionResult CustomerEdit(int id, Customer model)
        {
            if (_customerRepository.Edit(model, id))
                return RedirectToAction("Index");

            return RedirectToAction("Index");
        }
    }
}
