using Microsoft.AspNetCore.Mvc;

namespace OTAKode.Controllers
{
    public class NavegacaoController1 : Controller
    {
        public IActionResult Sobre()
        {
            ViewData["Message"] = "É um de Venda de MANGÁS";
            return View();
        }
    }
}
