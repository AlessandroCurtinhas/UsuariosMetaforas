﻿using System.ComponentModel.DataAnnotations;

namespace MetaforasUserID.Application.Models
{
    public class RecoveryPasswordModel
    {
        [Required(ErrorMessage = "Por favor, informe o nome do usuário.")]
        [MinLength(3, ErrorMessage = "Por favor, informe no mínimo {1} caracteres.")]
        [MaxLength(100, ErrorMessage = "Por favor, informe no máximo {1} caracteres.")]
        public String Senha { get; set; }
        [Required(ErrorMessage = "Por favor, informe o nome do usuário.")]
        [MinLength(3, ErrorMessage = "Por favor, informe no mínimo {1} caracteres.")]
        [MaxLength(100, ErrorMessage = "Por favor, informe no máximo {1} caracteres.")]
        public String ConfirmacaoSenha { get; set; }
        [EmailAddress(ErrorMessage = "Por favor, informe um endereço de email válido.")]
        [Required(ErrorMessage = "Por favor, informe o nome do usuário.")]
        [MinLength(3, ErrorMessage = "Por favor, informe no mínimo {1} caracteres.")]
        [MaxLength(100, ErrorMessage = "Por favor, informe no máximo {1} caracteres.")]
        public String Email { get; set; }
        [Required(ErrorMessage = "Token é obrigatório")]
        public Guid Token { get; set; }
    }
}
