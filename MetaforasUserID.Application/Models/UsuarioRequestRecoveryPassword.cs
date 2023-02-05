using System.ComponentModel.DataAnnotations;

namespace MetaforasUserID.Application.Models
{
    public class UsuarioRequestRecoveryPassword
    {
        [EmailAddress(ErrorMessage = "Por favor, informe um endereço de email válido.")]
        [Required(ErrorMessage = "Por favor, informe o email de acesso.")]
        public String? Email { get; set; }
    }
}
