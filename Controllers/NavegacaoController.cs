using Microsoft.AspNetCore.Mvc;

namespace OTAKode.Controllers
{
    public class NavegacaoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
