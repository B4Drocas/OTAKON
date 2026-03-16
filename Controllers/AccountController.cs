using Microsoft.AspNetCore.Mvc;
using OTAKode.Data;
using OTAKode.Models;

namespace OTAKode.Controllers
{
    public class AccountController : Controller
    {
        private readonly OtakonDbContext _context;

        public AccountController(OtakonDbContext context)
        {
            _context = context;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                ViewData["ErrorMessage"] = "Usuário e senha são obrigatórios.";
                return View();
            }

            var user = _context.Users.FirstOrDefault(u => u.Username == username && u.IsActive);

            if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
            {
                ViewData["ErrorMessage"] = "Usuário ou senha inválidos.";
                return View();
            }

            // Atualizar último login
            user.LastLogin = DateTime.UtcNow;
            _context.SaveChanges();

            // Guardar informações na sessão
            HttpContext.Session.SetInt32("UserId", user.Id);
            HttpContext.Session.SetString("Username", user.Username);
            HttpContext.Session.SetString("Email", user.Email);
            HttpContext.Session.SetInt32("IsAdmin", user.IsAdmin ? 1 : 0);

            return RedirectToAction("Dashboard");
        }

        public IActionResult Dashboard()
        {
            if (HttpContext.Session.GetInt32("UserId") == null)
            {
                return RedirectToAction("Login");
            }

            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(string username, string email, string password, string passwordConfirm, string fullName)
        {
            // Validações
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                ViewData["ErrorMessage"] = "Preencha todos os campos obrigatórios.";
                return View();
            }

            if (password != passwordConfirm)
            {
                ViewData["ErrorMessage"] = "As senhas não coincidem.";
                return View();
            }

            // Verificar se usuário já existe
            if (_context.Users.Any(u => u.Username == username))
            {
                ViewData["ErrorMessage"] = "Este usuário já existe.";
                return View();
            }

            if (_context.Users.Any(u => u.Email == email))
            {
                ViewData["ErrorMessage"] = "Este email já está registrado.";
                return View();
            }

            // Criar novo usuário
            var newUser = new User
            {
                Username = username,
                Email = email,
                FullName = fullName ?? username,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(password),
                IsAdmin = false,
                IsActive = true,
                CreatedAt = DateTime.UtcNow
            };

            _context.Users.Add(newUser);
            _context.SaveChanges();

            ViewData["SuccessMessage"] = "Conta criada com sucesso! Faça login para continuar.";
            return RedirectToAction("Login");
        }
    }
}

