using System.ComponentModel.DataAnnotations;

namespace Almoxarifado.APAE.Models.Account
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Informe o e-mail.")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe a senha.")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
        public string? ReturnUrl { get; set; }
        public bool ManterConectado { get; set; }
    }
}
