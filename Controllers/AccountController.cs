using Microsoft.AspNetCore.Mvc;

public class AccountController : Controller
{
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Login(LoginViewModel model)
    {
        if (model.Email == "admin@email.com" && model.Senha == "123456")
        {
            return RedirectToAction("Index", "Home");
        }

        ModelState.AddModelError("", "Email ou senha inválidos");

        return View(model);
    }
}