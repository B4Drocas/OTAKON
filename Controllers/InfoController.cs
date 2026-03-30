using Microsoft.AspNetCore.Mvc;

namespace OTAKode.Controllers
{
    public class InfoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
