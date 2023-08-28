using Microsoft.AspNetCore.Mvc;

namespace CurrencyWeb.MVC.Controllers
{
    public class ShowDataController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ShowChartData()
        {
            return View();
        }
    }
}
