using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebCRM.Data;
using WebCRM.Models;
using WebCRM.Views;
using DataPoint = WebCRM.Views.DataPoint;

namespace WebCRM.Controllers
{
    public class ProfitController : Controller
    {
		private readonly ApplicationDbContext _context;
        public ProfitController(ApplicationDbContext context)
        {
				_context = context;
        }
        public ActionResult Index()
		{
			
			List<DataPoint> dataPoints = new List<DataPoint>();
			IEnumerable<Check> checks = _context.Checks.ToList();
			dataPoints.Add(new DataPoint("Initial", 0));
			foreach (Check check in checks)
			{

				int i = 0;
				dataPoints.Add(new DataPoint(check.Created.ToLongDateString(), Convert.ToDouble(Cart.CartHistory[i])));
				i++;
				
			}
			dataPoints.Add(new DataPoint("Final", true, "{y}"));

			ViewBag.DataPoints = JsonConvert.SerializeObject(dataPoints);

			return View();
		}

		
	}

}

