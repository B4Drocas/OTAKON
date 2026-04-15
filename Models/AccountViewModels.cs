using System.ComponentModel.DataAnnotations;

namespace OTAKode.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Usuário é obrigatório")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Senha é obrigatória")]
        public string Password { get; set; }
    }

    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Usuário é obrigatório")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Email é obrigatório")]
        [EmailAddress(ErrorMessage = "Email inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Senha é obrigatória")]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "A senha deve ter entre 8 e 100 caracteres")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirme a senha")]
        [Compare("Password", ErrorMessage = "As senhas não coincidem")]
        public string PasswordConfirm { get; set; }

        public string FullName { get; set; }
    }
}
