using Microsoft.AspNetCore.Mvc;

namespace OTAKON.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult Index()
        {
            // TODO: Implementar lógica de autenticação
            // TODO: Carregar dados do utilizador da base de dados
            return View();
        }

        [HttpPost]
        public IActionResult UpdateProfile(string fullName, string email, string phone, string address, string city, string country)
        {
            // TODO: Validar dados
            // TODO: Atualizar utilizador na base de dados
            TempData["SuccessMessage"] = "Perfil atualizado com sucesso!";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult ChangePassword(string currentPassword, string newPassword, string confirmPassword)
        {
            // TODO: Validar senha atual
            // TODO: Validar nova senha
            // TODO: Atualizar senha na base de dados
            TempData["SuccessMessage"] = "Senha alterada com sucesso!";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult UpdateNotifications(bool emailNotifications, bool productUpdates, bool specialOffers, bool communityMessages)
        {
            // TODO: Atualizar preferências de notificações
            TempData["SuccessMessage"] = "Preferências salvas com sucesso!";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult DeleteAccount()
        {
            // TODO: Implementar confirmação
            // TODO: Deletar conta da base de dados
            // TODO: Limpar sessão
            TempData["SuccessMessage"] = "Conta deletada com sucesso!";
            return RedirectToAction("Index", "Home");
        }
    }
}
