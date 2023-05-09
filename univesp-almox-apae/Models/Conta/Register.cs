using System.ComponentModel.DataAnnotations;

namespace univesp.almox.apae.Models.Conta
{
    public class Register
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "A senha deve ter no mínimo 6 e no máximo 100 caracteres.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Senha", ErrorMessage = "A senha e a confirmação não são iguais.")]
        public string ConfirmaSenha { get; set; }

        public string? ReturnUrl { get; set; }
    }
}
