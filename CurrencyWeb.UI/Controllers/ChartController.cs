using Microsoft.AspNetCore.Mvc;

namespace CurrencyWeb.UI.Controllers
{
    public class ChartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetChart()
        {
            return View();
        }


    }
}
