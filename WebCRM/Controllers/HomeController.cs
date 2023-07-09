using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using WebCRM.Data;
using WebCRM.Models;

namespace WebCRM.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;


		public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
			List<DataPoint> dataPoints = new List<DataPoint>();
            List<Customer> customers = _context.Customers.ToList();
			List<Seller> sellers = _context.Sellers.ToList();


			dataPoints.Add(new DataPoint("Customers", customers.Count));
			dataPoints.Add(new DataPoint("Sellers", sellers.Count));
			

			ViewBag.DataPoints = JsonConvert.SerializeObject(dataPoints);

			return View();
		}

        public IActionResult Privacy()
        {
            return View();
        }
 

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}