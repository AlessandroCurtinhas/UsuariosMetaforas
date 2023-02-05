using System.ComponentModel.DataAnnotations;

namespace MetaforasUserID.Application.Models
{
    public class UsuarioPutModel
    {
        [Required(ErrorMessage = "O Id é obrigatório")]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Por favor, informe o nome do usuário.")]
        [MinLength(3, ErrorMessage = "Por favor, informe no mínimo {1} caracteres.")]
        [MaxLength(100, ErrorMessage = "Por favor, informe no máximo {1} caracteres.")]
        public String? Nome { get; set; }
        [Required(ErrorMessage = "Por favor, informe o nome do usuário.")]
        [MinLength(3, ErrorMessage = "Por favor, informe no mínimo {1} caracteres.")]
        [MaxLength(100, ErrorMessage = "Por favor, informe no máximo {1} caracteres.")]
        public String? Email { get; set; }

    }
}
