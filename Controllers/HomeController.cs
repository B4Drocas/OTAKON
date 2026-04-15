using Microsoft.AspNetCore.Mvc;
using OTAKode.Models;
using System.Diagnostics;

namespace OTAKode.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() => View(model: GetErrorViewModel());

        private ErrorViewModel GetErrorViewModel()
        {
            return new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier };
        }
    }
}
